using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Resources;
using System.IO;
using System.IO.Pipes;

namespace TWW_Coop
{

    public class DolphinManager
    {

        private readonly int PLAYER_STATUS_SIZE = 79;
        private readonly int WORLD_STATE_SIZE = 562;
        private readonly int GIVE_ITEM_SIZE = 5;

        private Process process;
        private bool started = false;
        private readonly int bufferSize = 1024;
        private byte[] readBuffer;
        private StreamReader fromStream;
        private StreamWriter toStream;

        private NamedPipeServerStream fromDolphin = new NamedPipeServerStream("fromDolphin", PipeDirection.In);
        private NamedPipeServerStream toDolphin = new NamedPipeServerStream("toDolphin", PipeDirection.Out);

        public bool isRunning
        {
            get
            {
                return !process.HasExited;
            }
        }

        public DolphinManager()
        {
            process = new Process();
            process.StartInfo.FileName = @"Dolphin\Dolphin.exe";
            process.StartInfo.UseShellExecute = false;

            fromStream = new StreamReader(fromDolphin);
            toStream = new StreamWriter(toDolphin);

            process.Start();
            started = true;
            readBuffer = new byte[bufferSize];
            ZeroReadBuffer();
            fromDolphin.WaitForConnection();
            toDolphin.WaitForConnection();
        }

        public void Kill()
        {
            process.CloseMainWindow();
            
            process.Close();
        }

        public DolphinPacket ReadPacket()
        {
            DolphinPacket thisPacket = new DolphinPacket();
            if (!fromDolphin.IsConnected || !started)
                return thisPacket;

            ZeroReadBuffer();
            fromStream.BaseStream.Read(readBuffer, 0, bufferSize);

            thisPacket.type = (PacketType)BitConverter.ToInt32(readBuffer, 0);

            switch (thisPacket.type)
            {
                case PacketType.None:
                    break;
                case PacketType.PlayerStatusInfo:
                    thisPacket.data = new byte[PLAYER_STATUS_SIZE];
                    Array.Copy(readBuffer, 4, thisPacket.data, 0, PLAYER_STATUS_SIZE);
                    break;
                case PacketType.WorldState:
                    thisPacket.data = new byte[WORLD_STATE_SIZE];
                    Array.Copy(readBuffer, 4, thisPacket.data, 0, WORLD_STATE_SIZE);
                    break;
                default:
                    thisPacket.type = PacketType.None;
                    break;
            }

            return thisPacket;
        }

        public void GiveItem(WWItem item)
        {
            if (!toDolphin.IsConnected || !started)
                return;

            DolphinPacket givePacket = new DolphinPacket();
            givePacket.type = PacketType.GiveItem;
            givePacket.data[0] = (byte)item;
            byte[] buffer = givePacket.Pack();

            toStream.BaseStream.Write(buffer, 0, buffer.Length);
        }

        public void UpgradeItem(ItemCode code)
        {
            if (!toDolphin.IsConnected || !started)
                return;

            DolphinPacket upgradePacket = new DolphinPacket();
            upgradePacket.type = PacketType.UpgradeItem;
            byte[] codeBytes = BitConverter.GetBytes((int)code);
            upgradePacket.data = new byte[4];
            Array.Copy(codeBytes, upgradePacket.data, 4);
            byte[] buffer = upgradePacket.Pack();

            toStream.BaseStream.Write(buffer, 0, buffer.Length);
        }

        public void DowngradeItem(ItemCode code)
        {
            if (!toDolphin.IsConnected || !started)
                return;

            DolphinPacket downgradePacket = new DolphinPacket();
            downgradePacket.type = PacketType.DowngradeItem;
            byte[] codeBytes = BitConverter.GetBytes((int)code);
            downgradePacket.data = new byte[4];
            Array.Copy(codeBytes, downgradePacket.data, 4);
            byte[] buffer = downgradePacket.Pack();

            toStream.BaseStream.Write(buffer, 0, buffer.Length);
        }

        public void RevokeItem(WWItem item)
        {
            if (!toDolphin.IsConnected || !started)
                return;

            DolphinPacket revokePacket = new DolphinPacket();
            revokePacket.type = PacketType.RevokeItem;
            revokePacket.data = new byte[1];
            revokePacket.data[0] = (byte)item;
            byte[] buffer = revokePacket.Pack();

            toStream.BaseStream.Write(buffer, 0, buffer.Length);
        }

        private void ZeroReadBuffer()
        {
            for (int i = 0; i < readBuffer.Length; i++)
            {
                readBuffer[i] = 0;
            }
        }
    }

    public class DolphinPacket
    {
        public PacketType type;
        public byte[] data;

        public DolphinPacket()
        {
            type = PacketType.None;
            data = new byte[1];
            data[0] = 0;
        }

        public byte[] Pack()
        {
            byte[] buffer = new byte[data.Length + 4];
            byte[] typeBuffer = new byte[4];
            typeBuffer = BitConverter.GetBytes((int)type);
            Array.Copy(typeBuffer, 0, buffer, 0, 4);
            Array.Copy(data, 0, buffer, 4, data.Length);
            
            return buffer;
        }
    }

    public enum PacketType : int
    {
        None = 0,
        PlayerStatusInfo = 1,
        WorldState = 2,
        GiveItem = 3,
        GiveKeys = 4,
        UpgradeItem = 5,
        DowngradeItem = 6,
        RevokeItem = 7,
        GiveSong = 8,
        RemoveSong = 9,
        GivePearl = 10,
        RemovePearl = 11
    }
}
