﻿using System;

namespace TWW_Coop
{
    public enum WWItem : byte
    {
        GreenRupee = 0x01, // 1
        BlueRupee = 0x02, // 5
        YellowRupee = 0x03, // 10
        RedRupee = 0x04, // 20
        PurpleRupee = 0x05, // 50
        OrangeRupee = 0x06, // 100
        SilverRupee = 0x0F, // 200

        PieceOfHeart = 0x07,
        HeartContainer = 0x08,

        Sword1 = 0x38, // Hero's Sword
        Sword2 = 0x39, // Master Sword
        Sword3 = 0x3A, // Half charged
        Sword4 = 0x3E, // Fully charged

        Shield1 = 0x3B, // Hero's Shield
        Shield2 = 0x3C, // Mirror Shield

        Bow1 = 0x27,
        Bow2 = 0x35, // Fire and Ice arrows
        Bow3 = 0x36, // Light arrows

        GrapplingHook = 0x25,
        DekuLeaf = 0x34,
        Boomerang = 0x2D,
        Bombs = 0x31,
        Hammer = 0x33,
        Hookshot = 0x2F,

        Sail = 0x78,
        WW = 0x22,

        SpoilsBag = 0x24,
        BaitBag = 0x2C,
        MailBag = 0x30,

        Bracelet = 0x28,
        Boots = 0x29,

        MagicArmor = 0x2A,
        HerosCharm = 0x43,
        TingleTuner = 0x21,
        Telecope = 0x20,
        PictoBox1 = 0x23,
        PictoBox2 = 0x26,

        Bottle = 0x50, // Empty

        i_WindsRequiem = 0x6D,
        i_BalladofGales = 0x6E,
        i_CommandMelody = 0x6F,
        i_EarthGodsLyric = 0x70,
        i_WindGodsAria = 0x71,
        i_SongofPassing = 0x72,

        FathersLetter = 0x98,
        NotetoMom = 0x99,
        MaggiesLetter = 0x9A,
        MoblinsLetter = 0x9B,
        CabanaDeed = 0x9C,
        ComplimentaryID = 0x9D,
        FillupCoupon = 0x9E,

        TownFlower = 0x8C,
        SeaFlower = 0x8D,
        ExoticFlower = 0x8E,
        HerosFlag = 0x8F,
        BigCatchFlag = 0x90,
        BigSaleFlag = 0x91,
        Pinwheel = 0x92,
        SickleMoonFlag = 0x93,
        SkullTowerIdol = 0x94,
        FountainIdol = 0x95,
        PostmanStatue = 0x96,
        ShopGuruStatue = 0x97,

        HurricaneSpin = 0xAA,
        TingleStatue1 = 0xA3, // Dragon 00000100
        TingleStatue2 = 0xA4, // Forbidden 00001000
        TingleStatue3 = 0xA5, // Goddess 00010000
        TingleStatue4 = 0xA6, // Earth 00100000
        TingleStatue5 = 0xA7, // Wind 01000000

        NoItem = 0xFF
    }

    public enum WWBottleContents : byte
    {
        NoBottle    = 0xFF,
        Empty       = 0x50,
        RedPotion   = 0x51,
        GreenPotion = 0x52,
        BluePotion  = 0x53,
        HalfSoup    = 0x54,
        FullSoup    = 0x55,
        Water       = 0x56,
        Fairy       = 0x57,
        Firefly     = 0x58,
        ForestWater = 0x59
    }

    [Flags]
    public enum WWSongMask : byte
    {
        None           = 0,
        WindsRequiem   = 0x01,
        BalladofGales  = 0x02,
        CommandMelody  = 0x04,
        EarthGodsLyric = 0x08,
        WindGodsAria   = 0x10,
        SongofPassing  = 0x20
    }

    [Flags]
    public enum WWPearlMask : byte
    { 
        None   = 0,
        Nayru  = 0x01,
	    Din    = 0x02,
	    Farore = 0x04
    }

    [Flags]
    public enum WWTriforceMask : byte
    {
        None      = 0,
        Triforce1 = 0x01,
        Triforce2 = 0x02,
        Triforce3 = 0x04,
        Triforce4 = 0x08,
        Triforce5 = 0x10,
        Triforce6 = 0x20,
        Triforce7 = 0x40,
        Triforce8 = 0x80,
    }

    [Flags]
    public enum WWStatueMask : byte
    {
        None      = 0,
        Dragon    = 0b00000100,
        Forbidden = 0b00001000,
        Goddess   = 0b00010000,
        Earth     = 0b00100000,
        Wind      = 0b01000000
    }

    [Flags]
    public enum WWChartMask : long
    {
        None = 0,
        TreasureChart10 = (long)1,
        TreasureChart14 = (long)1 << 1,
        TinglesChart = (long)1 << 2,
        GhostShipChart = (long)1 << 3,
        TreasureChart9 = (long)1 << 4,
        TreasureChart22 = (long)1 << 5,
        TreasureChart36 = (long)1 << 6,
        TreasureChart17 = (long)1 << 7,

        TreasureChart25 = (long)1 << 8,
        TreasureChart37 = (long)1 << 9,
        TreasureChart8 = (long)1 << 10,
        TreasureChart26 = (long)1 << 11,
        TreasureChart41 = (long)1 << 12,
        TreasureChart19 = (long)1 << 13,
        TreasureChart32 = (long)1 << 14,
        TreasureChart13 = (long)1 << 15,

        TreasureChart21 = (long)1 << 16,
        TreasureChart27 = (long)1 << 17,
        TreasureChart7 = (long)1 << 18,
        IncredibleChart = (long)1 << 19,
        OctoChart       = (long)1 << 20,
        GreatFairyChart = (long)1 << 21,
        IslandHeartsChart = (long)1 << 22,
        SeaHeartsChart = (long)1 << 23,

        SecretCaveChart = (long)1 << 24,
        LightRingChart = (long)1 << 25,
        PlatformChart = (long)1 << 26,
        BeedlesChart = (long)1 << 27,
        SubmarineChart = (long)1 << 28,

        TriforceChart1 = (long)1 << 32,
        TriforceChart2 = (long)1 << 33,
        TriforceChart3 = (long)1 << 34,
        TriforceChart4 = (long)1 << 35,
        TriforceChart5 = (long)1 << 36,
        TriforceChart6 = (long)1 << 37,
        TriforceChart7 = (long)1 << 38,
        TriforceChart8 = (long)1 << 39,

        TreasureChart11 = (long)1 << 40,
        TreasureChart15 = (long)1 << 41,
        TreasureChart30 = (long)1 << 42,
        TreasureChart20 = (long)1 << 43,
        TreasureChart5 = (long)1 << 44,
        TreasureChart23 = (long)1 << 45,
        TreasureChart31 = (long)1 << 46,
        TreasureChart33 = (long)1 << 47,

        TreasureChart2 = (long)1 << 48,
        TreasureChart38 = (long)1 << 49,
        TreasureChart39 = (long)1 << 50,
        TreasureChart24 = (long)1 << 51,
        TreasureChart6 = (long)1 << 52,
        TreasureChart12 = (long)1 << 53,
        TreasureChart35 = (long)1 << 54,
        TreasureChart1 = (long)1 << 55,

        TreasureChart29 = (long)1 << 56,
        TreasureChart34 = (long)1 << 57,
        TreasureChart18 = (long)1 << 58,
        TreasureChart16 = (long)1 << 59,
        TreasureChart28 = (long)1 << 60,
        TreasureChart4 = (long)1 << 61,
        TreasureChart3 = (long)1 << 62,
        TreasureChart40 = (long)1 << 63
    }
}
