using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TWW_Coop
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Bag
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)] public byte[] contents;
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
    public class QuestStatus
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
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class PlayerStatus
    {
        public Status status;
        public Inventory inventory;
        public Ammo ammo;
        public BagSection bags;
        public QuestStatus questStatus;
    }
}
