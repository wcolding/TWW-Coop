using System.Runtime.InteropServices;

namespace TWW_Coop
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Bag
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] public byte[] contents;

        public bool HasItem(WWItem item)
        {
            for (int i = 0; i < 8; i++)
                if (contents[i] == (byte)item)
                    return true;
            return false;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Status
    {
        public ushort maxHP;
        public ushort currentHP;
        public byte wallet;
        public ushort currentRupees;
        public byte maxMagic;
        public byte currentMagic;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Inventory
    {
        public byte telescope;
        public byte sail;
        public byte windwaker;
        public byte grapplingHook;
        public byte spoilsBag;
        public byte boomerang;
        public byte dekuLeaf;
        public byte tingleTuner;
        public byte pictoBox;
        public byte ironBoots;
        public byte magicArmor;
        public byte baitBag;
        public byte bow;
        public byte bombs;
        public byte bottle1;
        public byte bottle2;
        public byte bottle3;
        public byte bottle4;
        public byte deliveryBag;
        public byte hookshot;
        public byte skullHammer;
        public byte sword;
        public byte shield;
        public byte bracelets;
        public byte spinAttack;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Ammo
    {
        public byte bowCapacity;
        public byte bowAmmo;
        public byte bombCapacity;
        public byte bombAmmo;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class BagSection
    {
        public Bag spoilsBag;
        public Bag baitBag;
        public Bag deliveryBag;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class QuestState
    {
        public byte swords;
        public byte shields;
        public byte bows;
        public byte bombs;
        public byte bracelets;
        public WWSongMask songs;
        public WWTriforceMask triforce;
        public WWPearlMask pearls;
        public WWStatueMask statues;
        public WWChartMask charts;

        public int GetTriforceCount()
        {
            int count = 0;
            int shard = 0;
            for (int i = 0; i < 8; i++)
            {
                shard = 1 << i;
                if (((int)triforce & shard) != 0)
                    count++;
            }
            return count;
        }

        public int GetStatueCount()
        {
            int count = 0;
            int statue = 0;
            for (int i = 2; i < 7; i++) // statues are in a weird range of the bitmask
            {
                statue = 1 << i;
                if (((int)statues & statue) != 0)
                    count++;
            }
            return count;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class PlayerState
    {
        public Status status;
        public Inventory inventory;
        public Ammo ammo;
        public BagSection bags;
        public QuestState questState;
    }
}
