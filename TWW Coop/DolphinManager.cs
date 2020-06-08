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

        private Process process;
        private bool started = false;
        private readonly int bufferSize = 128;
        private byte[] readBuffer;
        private StreamReader fromStream;

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

            process.Start();
            started = true;
            readBuffer = new byte[bufferSize];
            ZeroReadBuffer();
            fromDolphin.WaitForConnection();
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
                default:
                    thisPacket.type = PacketType.None;
                    break;
            }

            return thisPacket;
        }

        public void WriteLine(string msg)
        {
            if (started)
                process.StandardInput.WriteLine(msg);
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
    }

    public enum PacketType : int
    {
        None = 0,
        PlayerStatusInfo = 1
    }
}
