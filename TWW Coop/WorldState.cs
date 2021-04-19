using System;
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

    public enum StageID : byte
    {
        Sea      = 0,
        SeaAlt   = 1,
        FF       = 2,
        DRC      = 3,
        FW       = 4,
        TotG     = 5,
        Earth    = 6,
        Wind     = 7,
        Ganon    = 8,
        Hyrule   = 9,
        Ships    = 10,
        Houses   = 11,
        Caves    = 12,
        CavesAlt = 13,
        ChuChu   = 14,
        NULL     = 255
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
        public StageID stageID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] private char[] stageName;
        public byte zone;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = UnmanagedType.Struct)] public StageInfo[] stageInfos;
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
        public StageInfo interiors;
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

        public StageInfo[] GetStageInfos()
        {
            StageInfo[] infos = new StageInfo[15];
            infos[0]  = sea;
            infos[1]  = sea_alt;
            infos[2]  = ff;
            infos[3]  = drc;
            infos[4]  = fw;
            infos[5]  = totg;
            infos[6]  = earth;
            infos[7]  = wind;
            infos[8]  = ganon;
            infos[9]  = hyrule;
            infos[10] = ships;
            infos[11] = interiors;
            infos[12] = caves;
            infos[13] = caves_alt;
            infos[14] = chuchu;
            return infos;
        }

        public void SetStageInfos(StageInfo[] infos) // may need to initialize these first
        {
            sea       = infos[0];
            sea_alt   = infos[1];
            ff        = infos[2];
            drc       = infos[3];
            fw        = infos[4];
            totg      = infos[5];
            earth     = infos[6];
            wind      = infos[7];
            ganon     = infos[8];
            hyrule    = infos[9];
            ships     = infos[10];
            interiors = infos[11];
            caves     = infos[12];
            caves_alt = infos[13];
            chuchu    = infos[14];
        }
    }

    public static class WWState
    {

        public static StageInfo syncStages(StageInfo a, StageInfo b)
        {
            StageInfo merged = new StageInfo();

            IntPtr aPtr = Marshal.AllocHGlobal(34);
            IntPtr bPtr = Marshal.AllocHGlobal(34);
            IntPtr mergedPtr = Marshal.AllocHGlobal(34);

            Marshal.StructureToPtr<StageInfo>(a, aPtr, false);
            Marshal.StructureToPtr<StageInfo>(b, bPtr, false);

            byte[] aBuffer = new byte[34];
            byte[] bBuffer = new byte[34];
            byte[] mergedBuffer = new byte[34];

            Marshal.Copy(aPtr, aBuffer, 0, 34);
            Marshal.Copy(bPtr, bBuffer, 0, 34);

            for (int i = 0; i < 34; i++)
            {
                if (i != 32)  // don't OR keys
                    mergedBuffer[i] = (byte)(aBuffer[i] | bBuffer[i]);
            }

            Marshal.Copy(mergedBuffer, 0, mergedPtr, 34);
            merged = Marshal.PtrToStructure<StageInfo>(mergedPtr);

            return merged;
        }

        public static WorldState syncWorldStates(WorldState a, WorldState b)
        {
            WorldState merged = new WorldState();
            StageInfo[] aStageInfos = a.GetStageInfos();
            StageInfo[] bStageInfos = b.GetStageInfos();
            StageInfo[] mergedInfos = new StageInfo[15];

            int curStageID = 0;

            // Are players in the same stage
            if (a.stageID == b.stageID)
            {
                merged.local = syncStages(a.local, b.local);
                // Handle keys....timestamp?
            }
            else
            {
                // Players are in different stages
                //
                // Sync Player A's local flags to Player B's permanent flags
                curStageID = (int)a.stageID;
                if ((curStageID < 15) && (curStageID >= 0))
                    mergedInfos[curStageID] = syncStages(a.local, bStageInfos[curStageID]);

                // Sync Player B's local flags to Player A's permanent flags
                curStageID = (int)b.stageID;
                if ((curStageID < 15) && (curStageID >= 0))
                    mergedInfos[curStageID] = syncStages(b.local, aStageInfos[curStageID]);
            }

            return merged;
        }
    }
}
