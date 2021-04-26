using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;

namespace TWW_Coop
{
    public class DolphinManager
    {
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

        public WWPacket ReadPacket()
        {
            WWPacket thisPacket = new WWPacket();
            if (!fromDolphin.IsConnected || !started)
                return thisPacket;

            ZeroReadBuffer();
            fromStream.BaseStream.Read(readBuffer, 0, bufferSize);
            thisPacket = WWPacket.ReadPacket(readBuffer);

            return thisPacket;
        }

        public void WritePacket(WWPacket packet)
        {
            if (!toDolphin.IsConnected || !started)
                return;

            byte[] buffer = packet.Pack();
            toStream.BaseStream.Write(buffer, 0, buffer.Length);
        }

        public void GiveItem(WWItem item)
        {
            WWPacket givePacket = new WWPacket(PacketType.GiveItem);
            givePacket.data[0] = (byte)item;
            WritePacket(givePacket);
        }

        public void UpgradeItem(ItemCode code)
        {
            WWPacket upgradePacket = new WWPacket(PacketType.UpgradeItem);
            byte[] codeBytes = BitConverter.GetBytes((int)code);
            Array.Copy(codeBytes, upgradePacket.data, 4);
            WritePacket(upgradePacket);
        }

        public void DowngradeItem(ItemCode code)
        {
            WWPacket downgradePacket = new WWPacket(PacketType.DowngradeItem);
            byte[] codeBytes = BitConverter.GetBytes((int)code);
            Array.Copy(codeBytes, downgradePacket.data, 4);
            WritePacket(downgradePacket);
        }

        public void RevokeItem(WWItem item)
        {
            WWPacket revokePacket = new WWPacket(PacketType.RevokeItem);
            revokePacket.data[0] = (byte)item;
            WritePacket(revokePacket);
        }

        public void SetTriforce(byte mask)
        {
            WWPacket triforcePacket = new WWPacket(PacketType.SetTriforce);
            triforcePacket.data[0] = mask;
            WritePacket(triforcePacket);
        }

        public void AddPearl(WWPearlMask pearl)
        {
            WWPacket pearlPacket = new WWPacket(PacketType.GivePearl);
            pearlPacket.data[0] = (byte)pearl;
            WritePacket(pearlPacket);
        }

        public void RemovePearl(WWPearlMask pearl)
        {
            WWPacket pearlPacket = new WWPacket(PacketType.RemovePearl);
            pearlPacket.data[0] = (byte)pearl;
            WritePacket(pearlPacket);
        }

        public void AddSong(WWSongMask song)
        {
            WWPacket songPacket = new WWPacket(PacketType.GiveSong);
            songPacket.data[0] = (byte)song;
            WritePacket(songPacket);
        }

        public void RemoveSong(WWSongMask song)
        {
            WWPacket songPacket = new WWPacket(PacketType.RemoveSong);
            songPacket.data[0] = (byte)song;
            WritePacket(songPacket);
        }

        public void SetStatues(byte mask)
        {
            WWPacket statuePacket = new WWPacket(PacketType.SetStatues);
            statuePacket.data[0] = mask;
            WritePacket(statuePacket);
        }

        public void SetBottleSlot(int slot, byte value)
        {
            WWPacket bottlePacket = new WWPacket(PacketType.SetBottleSlot);
            byte[] slotBytes = BitConverter.GetBytes(slot);
            Array.Copy(slotBytes, bottlePacket.data, 4);
            bottlePacket.data[4] = value;
            WritePacket(bottlePacket);
        }
        public void GiveChart(WWChartMask charts)
        {
            WWPacket chartPacket = new WWPacket(PacketType.GiveChart);
            byte[] chartBytes = BitConverter.GetBytes((long)charts);
            Array.Copy(chartBytes, chartPacket.data, 8);
            WritePacket(chartPacket);
        }

        public void RemoveChart(WWChartMask charts)
        {
            WWPacket chartPacket = new WWPacket(PacketType.RemoveChart);
            byte[] chartBytes = BitConverter.GetBytes((long)charts);
            Array.Copy(chartBytes, chartPacket.data, 8);
            WritePacket(chartPacket);
        }
        public void SetMailBagSlot(int slot, byte value)
        {
            WWPacket mailPacket = new WWPacket(PacketType.SetMailSlot);
            byte[] slotBytes = BitConverter.GetBytes(slot);
            Array.Copy(slotBytes, mailPacket.data, 4);
            mailPacket.data[4] = value;
            WritePacket(mailPacket);
        }

        public void AddKeys(short keys)
        {
            WWPacket keysPacket = new WWPacket(PacketType.GiveKeys);
            byte[] keyBytes = BitConverter.GetBytes(keys);
            Array.Copy(keyBytes, keysPacket.data, 2);
            WritePacket(keysPacket);
        }

        private void ZeroReadBuffer()
        {
            for (int i = 0; i < readBuffer.Length; i++)
                readBuffer[i] = 0;
        }
    }

    

    
}
