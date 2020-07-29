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

        public static readonly int PLAYER_STATUS_SIZE = 79;
        public static readonly int WORLD_STATE_SIZE = 562;
        public static readonly int GIVE_ITEM_SIZE = 5;

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

        public void WritePacket(DolphinPacket packet)
        {
            if (!toDolphin.IsConnected || !started)
                return;

            byte[] buffer = packet.Pack();
            toStream.BaseStream.Write(buffer, 0, buffer.Length);
        }

        public void GiveItem(WWItem item)
        {
            DolphinPacket givePacket = new DolphinPacket(PacketType.GiveItem);
            givePacket.data[0] = (byte)item;
            WritePacket(givePacket);
        }

        public void UpgradeItem(ItemCode code)
        {
            DolphinPacket upgradePacket = new DolphinPacket(PacketType.UpgradeItem);
            byte[] codeBytes = BitConverter.GetBytes((int)code);
            Array.Copy(codeBytes, upgradePacket.data, 4);
            WritePacket(upgradePacket);
        }

        public void DowngradeItem(ItemCode code)
        {
            DolphinPacket downgradePacket = new DolphinPacket(PacketType.DowngradeItem);
            byte[] codeBytes = BitConverter.GetBytes((int)code);
            Array.Copy(codeBytes, downgradePacket.data, 4);
            WritePacket(downgradePacket);
        }

        public void RevokeItem(WWItem item)
        {
            DolphinPacket revokePacket = new DolphinPacket(PacketType.RevokeItem);
            revokePacket.data[0] = (byte)item;
            WritePacket(revokePacket);
        }

        public void SetTriforce(byte mask)
        {
            DolphinPacket triforcePacket = new DolphinPacket(PacketType.SetTriforce);
            triforcePacket.data[0] = mask;
            WritePacket(triforcePacket);
        }

        private void ZeroReadBuffer()
        {
            for (int i = 0; i < readBuffer.Length; i++)
                readBuffer[i] = 0;
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

        public DolphinPacket(PacketType packetType)
        {
            type = packetType;

            int dataSize = 1;

            switch (type)
            {
                case PacketType.PlayerStatusInfo:
                    dataSize = DolphinManager.PLAYER_STATUS_SIZE;
                    break;
                case PacketType.WorldState:
                    dataSize = DolphinManager.WORLD_STATE_SIZE;
                    break;
                case PacketType.UpgradeItem:
                    dataSize = 4;
                    break;
                case PacketType.DowngradeItem:
                    dataSize = 4;
                    break;
                default:
                    break;
            }

            data = new byte[dataSize];
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
        RemovePearl = 11,
        SetTriforce = 12
    }
}
