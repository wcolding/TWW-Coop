using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TWW_Coop
{
    public enum DungeonFlags : byte
    {
        Map       = 0,
        Compass   = 0x01,
        BigKey    = 0x02,
        BossDead  = 0x04,
        BossHC    = 0x08,
        BossIntro = 0x10
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class StageInfo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public byte[] chestFlags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)] public byte[] eventSwitches;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public byte[] itemPickupFlags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] public byte[] visitedRooms;
        public byte smallKeys;
        public byte dungeonFlags;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class WorldState
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] private char[] playerName;
        public byte stageID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] private char[] stageName;
        public byte zone;
        public StageInfo sea;
        public StageInfo sea_alt;
        public StageInfo ff;
        public StageInfo drc;
        public StageInfo fw;
        public StageInfo totg;
        public StageInfo earth;
        public StageInfo wind;
        public StageInfo ganon;
        public StageInfo hyrule;
        public StageInfo ships;
        public StageInfo houses;
        public StageInfo caves;
        public StageInfo caves_alt;
        public StageInfo chuchu;
        public StageInfo local;

        public string PlayerName
        { 
            get { return TrimToString(playerName); }
        }

        public string StageName
        {
            get { return TrimToString(stageName); }
        }

        private string TrimToString(char[] cstr)
        {
            string str = new string(cstr);
            int index = str.IndexOf('\0');
            if (index > 0)
                str = str.Remove(index);
            return str;
        }
    }
}
