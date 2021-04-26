using System;
using System.Runtime.InteropServices;

namespace TWW_Coop
{
    public class WWPacket
    {
        public static readonly int PLAYER_STATUS_SIZE = 79;
        public static readonly int WORLD_STATE_SIZE = 562;
        //public static readonly int GIVE_ITEM_SIZE = 5;

        public PacketType type;
        public byte[] data;

        public WWPacket()
        {
            type = PacketType.None;
            data = new byte[1];
            data[0] = 0;
        }

        public WWPacket(PacketType packetType)
        {
            type = packetType;

            dataSize = 1;

            switch (type)
            {
                case PacketType.PlayerStatusInfo:
                    dataSize = PLAYER_STATUS_SIZE;
                    break;
                case PacketType.WorldState:
                    dataSize = WORLD_STATE_SIZE;
                    break;
                case PacketType.UpgradeItem:
                    dataSize = 4;
                    break;
                case PacketType.DowngradeItem:
                    dataSize = 4;
                    break;
                case PacketType.GiveKeys:
                    dataSize = 2;
                    break;
                case PacketType.SetBottleSlot:
                    dataSize = 5;
                    break;
                case PacketType.GiveChart:
                    dataSize = 8;
                    break;
                case PacketType.RemoveChart:
                    dataSize = 8;
                    break;
                case PacketType.SetMailSlot:
                    dataSize = 5;
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

        public object ToObject()
        {
            dataPtr = Marshal.AllocHGlobal(dataSize);
            Marshal.Copy(data, 0, dataPtr, dataSize);
            object obj = Marshal.PtrToStructure<object>(dataPtr);
            Marshal.FreeHGlobal(dataPtr);
            return obj;
        }

        private static int dataSize = 0;
        private static IntPtr dataPtr = IntPtr.Zero;

        public static WWPacket ReadPacket(byte[] buffer)
        {
            WWPacket thisPacket = new WWPacket();

            thisPacket.type = (PacketType)BitConverter.ToInt32(buffer, 0);

            switch (thisPacket.type)
            {
                case PacketType.None:
                    break;
                case PacketType.PlayerStatusInfo:
                    thisPacket.data = new byte[PLAYER_STATUS_SIZE];
                    Array.Copy(buffer, 4, thisPacket.data, 0, PLAYER_STATUS_SIZE);
                    break;
                case PacketType.WorldState:
                    thisPacket.data = new byte[WORLD_STATE_SIZE];
                    Array.Copy(buffer, 4, thisPacket.data, 0, WORLD_STATE_SIZE);
                    break;
                default:
                    thisPacket.type = PacketType.None;
                    break;
            }

            return thisPacket;
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
        SetTriforce = 12,
        SetStatues = 13,
        SetBottleSlot = 14,
        GiveChart = 15,
        RemoveChart = 16,
        SetMailSlot = 17
    }

    public enum ItemCode : int
    {
        PictoBox = 1,
        Bow = 2,
        Sword = 3,
        Shield = 4,
        Magic = 5,
        Wallet = 6,
        BowCapacity = 7,
        BombCapacity = 8,
        HeartContainer = 9
    }
}
