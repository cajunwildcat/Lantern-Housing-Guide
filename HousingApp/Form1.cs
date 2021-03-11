﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HousingApp {

    delegate void RoomSizeDelegate();
    delegate void RoomRemovedDelegate(Object sender);

    enum RoomType: int {
        Armory = 0,
        Auditorium = 1,
        Barbican = 2,
        Barracks = 3,
        Bath = 4,
        Bedrooms = 5,
        BedroomSuite = 6,
        Chapel = 7,
        CommonArea = 8,
        Courtyard = 9,
        DiningHall = 10,
        Dock = 11,
        Gatehouse = 12,
        Kitchen = 13,
        Library = 14,
        MagicLaboratory = 15,
        Shop = 16,
        Stable = 17,
        Storage = 18,
        Study = 19,
        Tavern = 20,
        ThroneRoom = 21,
        TrainingHallCombat = 22,
        TrainingHallRogue = 23,
        Trophy = 24,
        Workshop = 25
    }

    enum WallType: int {
        Adamatine = 0,
        Bone = 1,
        DeepCoral = 2,
        EarthPacked = 3,
        GlassTreated = 4,
        Ice = 5,
        Iron = 6,
        LivingWood = 7,
        Masonry = 8,
        MasonrySuperior = 9,
        MasonryReinforced = 10,
        Mithril = 11,
        StoneHewn = 12,
        StoneUnworked = 13,
        WallOfForce = 14,
        Wood = 15
    }

    enum WallModsIndex: int {
        Above = 0,
        Artic = 1,
        Forest = 2,
        Moutain = 3,
        Fabricate = 4,
        MoveEarth = 5,
        PlantGrowth = 6,
        StoneShape = 7,
        Underground = 8,
        WallOfForce = 9,
        WallOfIce = 10,
        WallOfStone = 11,
        WallOfThorns = 12,
        WallOfWater = 13
    }

    enum WallUpgrade: int {
        None = 0,
        Airtight = 1,
        Bladed = 2,
        ElementalProtection = 3,
        ElementalProtectionImproved = 4,
        EtherallySolid = 5,
        Fiery = 6,
        FogVeil = 7,
        FogVeilSolid = 8,
        FogVeilStinking = 9,
        FogVeilKilling = 10,
        FogVeilIncendiary = 11,
        Frostwall = 12,
        MagicWarding = 13,
        PrismaticScreen = 14,
        Slick = 15,
        Spiderwalk = 16,
        Tanglewood = 17,
        Thornwood = 18,
        Transparent = 19,
        Webbed = 20,
        Windwall = 21
    }

    enum Addon: int {
        DoorWoodGood = 0,
        DoorWoodStrong = 1,
        DoorStoneSimple = 2,
        DoorStoneGood = 3,
        DoorStoneStrong = 4,
        DoorIronSimple = 5,
        DoorIronGood = 6,
        DoorIronStrong = 7,
        LockSimple = 8,
        LockAverage = 9,
        LockGood = 10,
        LockAmazing = 11,
        LockImpossible = 12,
        DoorSecretSimple = 13,
        DoorSecretAverage = 14,
        DoorSecretGood = 15,
        DoorSecretAmazing = 16,
        DoorSecretImpossible = 17,
        GateWoodSimple = 18,
        GateWoodGood = 19,
        GateWoodStrong = 20,
        GateIronSimple = 21,
        GateIronGood = 22,
        GateIronStrong = 23,
        DrawbridgeWood = 24,
        DrawbridgeIron = 25,
        WindowShutterGood = 26,
        WindowIronBar = 27,
        WindowMurderHoles = 28,
        WindowGlass = 29,
        WindowStainedGlass = 30,
        WindowStainedGlassFancy = 31,
        PortalSPLU = 32,
        PortalOPLU = 33,
        PortalSP = 34,
        PortalOP = 35,
        PortalTW = 36
    }

    enum WondrousArch:int {
        AmbassadorsChambers = 0,
        BedofRegeneration = 1,
        BedofRestorationLesser = 2,
        BedofRestorationGreater = 3,
        BedofWellness = 4,
        BierofInquisition = 5,
        BlackLuminary = 6,
        BrazierofBrightBursts = 7,
        BrightLuminary = 8,
        CabinetofStasis = 9,
        CacophonousChamber = 10,
        ChamberofAiryWater = 11,
        ChamberofClimbing = 12,
        ChamberofComfort = 13,
        ChamberofCourage = 14,
        ChamberoftheEarthbound = 15,
        ChamberofGuidance = 16,
        ChamberofSafety = 17,
        ChamberofSafetyGreater = 18,
        ChamberofSeeing = 19,
        ChamberofSloth = 20,
        ChamberofSpeed = 21,
        ChamberoftheUnliving = 22,
        EverfulBasin = 23,
        EverfulLarder = 24,
        GardenofUnderstanding = 25,
        GuardianStatue = 26,
        HallofBabbling = 27,
        HallofDespair = 28,
        HallofFriendship = 29,
        HallofFriendshipGreater = 30,
        HallofHoliness = 31,
        HallofHope = 32,
        HallofSilence = 33,
        HallofSpeech = 34,
        HallofTruth = 35,
        HoleofHiding = 36,
        HurricanesEye = 37,
        IllusoryLandscape = 38,
        InscriptionsofConcealment = 39,
        InscriptionsofConcealmentGreater = 40,
        InscriptionsofPrivacy = 41,
        InvisibleHelper = 42,
        JestersTheater = 43,
        MapofGuidance = 44,
        MapofTactics = 45,
        MapofTacticsGreater = 46,
        MorgueofPreservation = 47,
        OakenGuardian = 48,
        OrbofPleasantBreezes = 49,
        PathofWaterySolidity = 50,
        PlatformofJaunting = 51,
        PlatformofJauntingGreater = 52,
        PlatformofLevitation = 53,
        PlatformofLevitationGreater = 54,
        PoolofScrying = 55,
        SanctumSanctorum = 56,
        SigilsofAntimagic = 57,
        SpeakingStones = 58,
        StableofUnderstanding = 59,
        TableofFeasting = 60,
        TableofFreshness = 61,
        TouchstoneofFaith = 62,
        TouchstoneofSafety = 63,
        TreeofJaunting = 64,
        TreeofJauntingGreater = 65,
        VegetativeTrap = 66,
        WardingBell = 67,
        WellofFalling = 68,
        WellofFlying = 69
    }
    public partial class Form1 : Form {

        private double numORooms; //room slots
        private double costTotal;

        //room info
        private string[] roomTypes;
        private string[] wallTypes;
        private string[] wallUpgrades;
        private string[] addons;
        private string[] wondrousArch;

        //lists
        private List<string[]> roomInfo;
        private List<Room> rooms;
        private List<bool> wallMods;

        public Form1() {
            InitializeComponent();
            //building selection information
            roomTypes = new string[26];
            wallTypes = new string[16];
            wallUpgrades = new string[22];
            addons = new string[37];
            wondrousArch = new string[70];
            LoadInfo();
            //initialize lists
            numORooms = 0;

            roomInfo = new List<string[]>();
            roomInfo.Add(roomTypes);
            roomInfo.Add(wallTypes);
            roomInfo.Add(wallUpgrades);
            roomInfo.Add(addons);
            rooms = new List<Room>();

            wallMods = new List<bool>();
            for (int i = 0; i < wallModsBox.Controls.Count; i++) {
                wallMods.Add(((CheckBox)wallModsBox.Controls[i]).Checked);
            }

            //default control settings
            mobilitySpeedDropDown.SelectedIndex = 0;
            mobilityTypeDropDown.SelectedIndex = 0;
            mobilitySpecialDropDown.SelectedIndex = 0;

        }

        private void LoadInfo() {
            FileStream instream = File.OpenRead("housing.data");
            BinaryReader reader = new BinaryReader(instream);
            for (int i = 0; i < roomTypes.Length; i++) 
                roomTypes[i] = reader.ReadString();
            for (int i = 0; i < wallTypes.Length; i++) 
                wallTypes[i] = reader.ReadString();
            for (int i = 0; i < wallUpgrades.Length; i++) 
                wallUpgrades[i] = reader.ReadString();
            for (int i = 0; i < addons.Length; i++) 
                addons[i] = reader.ReadString();
            for (int i = 0; i < wondrousArch.Length; i++) 
                wondrousArch[i] = reader.ReadString();
        }

        private void WallModsUpdated(Object sender, EventArgs e) {
            for (int i = 0; i < wallMods.Count; i++)
                wallMods[i] = ((CheckBox)wallModsBox.Controls[i]).Checked;
            for (int i = 0; i < rooms.Count; i++) {
                rooms[i].WallMods = wallMods;
                rooms[i].UpdateWallMod();
            }
        }

        private void NewRoomButton_Click(object sender, EventArgs e) {
            //TODO if shift is being helf when clicked, add 10 rooms
            int roomsToAdd = 1;
            if (Control.ModifierKeys == Keys.Shift)
                roomsToAdd = 10;
            for (int j = 0; j < roomsToAdd; j++) {
                Room room = new Room(roomPanel, roomInfo, wallMods);
                rooms.Add(room);
                room.RoomSizeChanged += RoomCountChanged;
                room.RoomRemoved += RoomRemoved;
            }
            RoomCountChanged();
        }

        private void RoomRemoved(Object sender) {
            rooms.Remove((Room)sender);
            for (int i = 0; i < rooms.Count; i++) {
                roomPanel.Controls[i+1].Text = $"Room {i+1}";
                rooms[i].MoveUp();
            }
        }

        private void RoomCountChanged() {
            numORooms = 0;
            foreach (Room r in rooms)
                numORooms += r.RoomSize;
            if (numORooms == 1)
                buildingSizeText.Text = "Cottage";
            else if (numORooms <= 4)
                buildingSizeText.Text = "Simple House";
            else if (numORooms <= 7)
                buildingSizeText.Text = "Grand House";
            else if (numORooms <= 12)
                buildingSizeText.Text = "Keep";
            else if (numORooms <= 15)
                buildingSizeText.Text = "Mansion";
            else if (numORooms <= 20)
                buildingSizeText.Text = "Castle";
            else if (numORooms <= 60)
                buildingSizeText.Text = "Small Dungeon";
            else if (numORooms <= 80)
                buildingSizeText.Text = "Huge Castle";
            else if (numORooms <= 120)
                buildingSizeText.Text = "Medium Dungeon";
            else
                buildingSizeText.Text = "Large Dungeon";
        }

        private void CalculateButton_Click(object sender, EventArgs e) {
            costTotal = 0;
            //rooms
            for (int i = 0; i < rooms.Count; i++)
                costTotal += rooms[i].Cost;

            double speedCost = 0;
            //speed
            switch (mobilitySpeedDropDown.SelectedIndex) {
                case 1: //extremely slothful
                    speedCost = 500 * numORooms;
                    break;
                case 2: //very sloth
                    speedCost = 750 * numORooms;
                    break;
                case 3: //sloth
                    speedCost = 1000 * numORooms;
                    break;
                case 4: //extremely slow
                    speedCost = 1500 * numORooms;
                    break;
                case 5: //very slow
                    speedCost = 2000 * numORooms;
                    break;
                case 6: //slow
                    speedCost = 2500 * numORooms;
                    break;
                case 7: //fair
                    speedCost = 3000 * numORooms;
                    break;
                case 8: //fleet
                    speedCost = 4000 * numORooms;
                    break;
                case 9: //fast
                    speedCost = 5000 * numORooms;
                    break;
                case 10: //very fast
                    speedCost = 7500 * numORooms;
                    break;
                case 11: //extraordinary
                    speedCost = 10000 * numORooms;
                    break;
                case 12: //incredible
                    speedCost = 12500 * numORooms;
                    break;
            }
            //type
            if (mobilityTypeDropDown.SelectedIndex == 0)
                speedCost = 0;
            else if (mobilityTypeDropDown.SelectedIndex == 3 || //burrowing
                mobilityTypeDropDown.SelectedIndex == 4) //submersive
                speedCost *= 2;
            else if (mobilityTypeDropDown.SelectedIndex == 5) //flying
                speedCost *= 2.5;
            costTotal += speedCost;
            //special
            if (mobilitySpecialDropDown.SelectedIndex == 2 ||
                mobilitySpecialDropDown.SelectedIndex == 1)
                speedCost += 5000 * numORooms;
            else if (mobilitySpecialDropDown.SelectedIndex == 3)
                speedCost += 10000 * numORooms;
            else if (mobilitySpecialDropDown.SelectedIndex == 4 ||
                mobilitySpecialDropDown.SelectedIndex == 5)
                speedCost += 25000 * numORooms;

            costTotal += CalculateWondrous();
            costTotal += CalculateFreeStandWalls();

            //dtp cost
            if (costTotal < 5000)
                DTPCostText.Text = "25";
            else if (costTotal < 10000)
                DTPCostText.Text = "50";
            else if (costTotal < 25000)
                DTPCostText.Text = "100";
            else if (costTotal < 100000)
                DTPCostText.Text = "200";
            else if (costTotal < 250000)
                DTPCostText.Text = "300";
            else if (costTotal < 500000)
                DTPCostText.Text = "400";
            else
                DTPCostText.Text = "500";
            goldCostText.Text = costTotal.ToString();
        }

        private void addNewWondrousArch_Click(object sender, EventArgs e) {
            Button xb = new Button();
            wondrousArchPanel.Controls.Add(xb);
            xb.Location = new Point(6,
                wondrousArchPanel.Controls[wondrousArchPanel.Controls.Count - 2].Location.Y + 30);
            xb.Size = new Size(13, 21);
            xb.Text = "X";
            xb.FlatStyle = FlatStyle.System;
            xb.Click += RemoveWondrousArch;

            ComboBox cb = new ComboBox();
            wondrousArchPanel.Controls.Add(cb);
            cb.Width = 172;
            cb.Location = new Point(wondrousArchPanel.Controls[wondrousArchPanel.Controls.Count - 2].Location.X + 16,
               wondrousArchPanel.Controls[wondrousArchPanel.Controls.Count - 2].Location.Y);
            cb.DataSource = wondrousArch.Clone();
            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            
        }

        private void RemoveWondrousArch(Object sender, EventArgs e) {
            Button b = (Button)sender;
            int index = wondrousArchPanel.Controls.IndexOf(b);
            wondrousArchPanel.Controls[index].Dispose();
            wondrousArchPanel.Controls[index].Dispose();
            for (int i = index; i < wondrousArchPanel.Controls.Count; i += 2) {
                wondrousArchPanel.Controls[i].Location = new Point(wondrousArchPanel.Controls[i].Location.X,
                    wondrousArchPanel.Controls[i - 1].Location.Y + 24);
                wondrousArchPanel.Controls[i + 1].Location = new Point(wondrousArchPanel.Controls[i + 1].Location.X,
                    wondrousArchPanel.Controls[i].Location.Y);
            }
        }

        private double CalculateWondrous() {
            ComboBox cb;
            double cost = 0;
            for (int i = 2; i < wondrousArchPanel.Controls.Count; i+=2) {
                cb = (ComboBox)wondrousArchPanel.Controls[i];
                if (cb.SelectedIndex == (int)WondrousArch.ChamberofGuidance)
                    cost += 500;
                else if (cb.SelectedIndex == (int)WondrousArch.EverfulBasin ||
                    cb.SelectedIndex == (int)WondrousArch.GuardianStatue ||
                    cb.SelectedIndex == (int)WondrousArch.InvisibleHelper ||
                    cb.SelectedIndex == (int)WondrousArch.TouchstoneofFaith ||
                    cb.SelectedIndex == (int)WondrousArch.WellofFalling)
                    cost += 1250;
                else if (cb.SelectedIndex == (int)WondrousArch.BlackLuminary ||
                    cb.SelectedIndex == (int)WondrousArch.BrazierofBrightBursts ||
                    cb.SelectedIndex == (int)WondrousArch.BrightLuminary ||
                    cb.SelectedIndex == (int)WondrousArch.ChamberofClimbing ||
                    cb.SelectedIndex == (int)WondrousArch.ChamberofComfort ||
                    cb.SelectedIndex == (int)WondrousArch.ChamberofCourage ||
                    cb.SelectedIndex == (int)WondrousArch.EverfulLarder ||
                    cb.SelectedIndex == (int)WondrousArch.GardenofUnderstanding ||
                    cb.SelectedIndex == (int)WondrousArch.HallofSilence ||
                    cb.SelectedIndex == (int)WondrousArch.HallofSpeech ||
                    cb.SelectedIndex == (int)WondrousArch.HoleofHiding ||
                    cb.SelectedIndex == (int)WondrousArch.MorgueofPreservation ||
                    cb.SelectedIndex == (int)WondrousArch.PathofWaterySolidity ||
                    cb.SelectedIndex == (int)WondrousArch.PlatformofLevitation ||
                    cb.SelectedIndex == (int)WondrousArch.SanctumSanctorum ||
                    cb.SelectedIndex == (int)WondrousArch.StableofUnderstanding ||
                    cb.SelectedIndex == (int)WondrousArch.TableofFreshness ||
                    cb.SelectedIndex == (int)WondrousArch.VegetativeTrap)
                    cost += 2500;
                else if (cb.SelectedIndex == (int)WondrousArch.BedofRestorationLesser ||
                    cb.SelectedIndex == (int)WondrousArch.BierofInquisition ||
                    cb.SelectedIndex == (int)WondrousArch.ChamberofAiryWater ||
                    cb.SelectedIndex == (int)WondrousArch.HallofTruth ||
                    cb.SelectedIndex == (int)WondrousArch.JestersTheater ||
                    cb.SelectedIndex == (int)WondrousArch.MapofGuidance ||
                    cb.SelectedIndex == (int)WondrousArch.TouchstoneofSafety ||
                    cb.SelectedIndex == (int)WondrousArch.WellofFlying)
                    cost += 5000;
                else if (cb.SelectedIndex == (int)WondrousArch.AmbassadorsChambers ||
                    cb.SelectedIndex == (int)WondrousArch.CacophonousChamber ||
                    cb.SelectedIndex == (int)WondrousArch.ChamberoftheEarthbound ||
                    cb.SelectedIndex == (int)WondrousArch.TouchstoneofSafety ||
                    cb.SelectedIndex == (int)WondrousArch.ChamberofSeeing ||
                    cb.SelectedIndex == (int)WondrousArch.ChamberofSloth ||
                    cb.SelectedIndex == (int)WondrousArch.HallofBabbling ||
                    cb.SelectedIndex == (int)WondrousArch.HallofDespair ||
                    cb.SelectedIndex == (int)WondrousArch.HallofHope ||
                    cb.SelectedIndex == (int)WondrousArch.InscriptionsofPrivacy ||
                    cb.SelectedIndex == (int)WondrousArch.MapofTactics ||
                    cb.SelectedIndex == (int)WondrousArch.PlatformofJaunting ||
                    cb.SelectedIndex == (int)WondrousArch.TreeofJaunting ||
                    cb.SelectedIndex == (int)WondrousArch.WardingBell)
                    cost += 7500;
                else if (cb.SelectedIndex == (int)WondrousArch.BedofWellness ||
                    cb.SelectedIndex == (int)WondrousArch.ChamberofSpeed ||
                    cb.SelectedIndex == (int)WondrousArch.IllusoryLandscape ||
                    cb.SelectedIndex == (int)WondrousArch.OakenGuardian ||
                    cb.SelectedIndex == (int)WondrousArch.OrbofPleasantBreezes ||
                    cb.SelectedIndex == (int)WondrousArch.PlatformofLevitationGreater ||
                    cb.SelectedIndex == (int)WondrousArch.PoolofScrying ||
                    cb.SelectedIndex == (int)WondrousArch.SpeakingStones)
                    cost += 10000;
                else if (cb.SelectedIndex == (int)WondrousArch.PlatformofJauntingGreater)
                    cost += 12500;
                else if (cb.SelectedIndex == (int)WondrousArch.ChamberofSafetyGreater ||
                    cb.SelectedIndex == (int)WondrousArch.HallofFriendship ||
                    cb.SelectedIndex == (int)WondrousArch.MapofTacticsGreater)
                    cost += 15000;
                else if (cb.SelectedIndex == (int)WondrousArch.InscriptionsofConcealment)
                    cost += 20000;
                else if (cb.SelectedIndex == (int)WondrousArch.BedofRestorationGreater ||
                    cb.SelectedIndex == (int)WondrousArch.CabinetofStasis ||
                    cb.SelectedIndex == (int)WondrousArch.ChamberoftheUnliving ||
                    cb.SelectedIndex == (int)WondrousArch.HallofFriendshipGreater ||
                    cb.SelectedIndex == (int)WondrousArch.TableofFeasting ||
                    cb.SelectedIndex == (int)WondrousArch.TreeofJauntingGreater)
                    cost += 25000;
                else if (cb.SelectedIndex == (int)WondrousArch.InscriptionsofConcealmentGreater)
                    cost += 30000;
                else if (cb.SelectedIndex == (int)WondrousArch.BedofRegeneration)
                    cost += 35000;
                else if (cb.SelectedIndex == (int)WondrousArch.HallofHoliness ||
                    cb.SelectedIndex == (int)WondrousArch.HurricanesEye ||
                    cb.SelectedIndex == (int)WondrousArch.SigilsofAntimagic)
                    cost += 50000;
            }
            return cost;
        }

        private void newWallSectionButton_Click(object sender, EventArgs e) {
            Button xb = new Button();
            freeStandWallsPanel.Controls.Add(xb);
            xb.Location = new Point(6,
                freeStandWallsPanel.Controls[freeStandWallsPanel.Controls.IndexOf(xb)-1].Location.Y + 30 + 11);
            xb.Size = new Size(13, 20);
            xb.Text = "X";
            xb.FlatStyle = FlatStyle.System;
            xb.Click += RemoveWallSection;

            NumericUpDown nud = new NumericUpDown();
            freeStandWallsPanel.Controls.Add(nud);
            nud.Location = new Point(28,
                freeStandWallsPanel.Controls[freeStandWallsPanel.Controls.Count - 2].Location.Y);
            nud.Size = new Size(35, 20);
            nud.UpDownAlign = LeftRightAlignment.Left;
            nud.TextAlign = HorizontalAlignment.Center;

            ComboBox cb = new ComboBox();
            freeStandWallsPanel.Controls.Add(cb);
            cb.Location = new Point(73,
                freeStandWallsPanel.Controls[freeStandWallsPanel.Controls.Count - 3].Location.Y - 11);
            cb.DataSource = wallTypes.Clone();
            cb.DropDownStyle = ComboBoxStyle.DropDownList;

            ComboBox wb = new ComboBox();
            freeStandWallsPanel.Controls.Add(wb);
            wb.Location = new Point(73,
                freeStandWallsPanel.Controls[freeStandWallsPanel.Controls.Count - 2].Location.Y + 21);
            wb.DataSource = wallUpgrades.Clone();
            wb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void RemoveWallSection(Object sender, EventArgs e) {
            Button b = (Button)sender;
            int index = freeStandWallsPanel.Controls.IndexOf(b);
            freeStandWallsPanel.Controls[index].Dispose();
            freeStandWallsPanel.Controls[index].Dispose();
            freeStandWallsPanel.Controls[index].Dispose();
            freeStandWallsPanel.Controls[index].Dispose();
            for (int i = index; i < freeStandWallsPanel.Controls.Count; i += 4) {
                freeStandWallsPanel.Controls[i].Location = new Point(freeStandWallsPanel.Controls[i].Location.X,
                    freeStandWallsPanel.Controls[i-1].Location.Y + 41);
                freeStandWallsPanel.Controls[i+1].Location = new Point(freeStandWallsPanel.Controls[i+1].Location.X,
                    freeStandWallsPanel.Controls[i].Location.Y);
                freeStandWallsPanel.Controls[i+2].Location = new Point(freeStandWallsPanel.Controls[i+2].Location.X,
                    freeStandWallsPanel.Controls[i].Location.Y-11);
                freeStandWallsPanel.Controls[i + 3].Location = new Point(freeStandWallsPanel.Controls[i + 3].Location.X,
                    freeStandWallsPanel.Controls[i+2].Location.Y+21);
            }
        }

        private double CalculateFreeStandWalls() {
            double cost = 0;
            double costReduction = .25;
            double wallCount;
            for (int i = 3; i < freeStandWallsPanel.Controls.Count; i += 4) {
                wallCount = (double)((NumericUpDown)freeStandWallsPanel.Controls[i - 1]).Value;
                switch (((ComboBox)freeStandWallsPanel.Controls[i]).SelectedIndex) {
                    case (int)WallType.Adamatine:
                        cost = 5000;
                        break;
                    case (int)WallType.Bone:
                        cost = 400;
                        break;
                    case (int)WallType.DeepCoral:
                        cost = 600;
                        break;
                    case (int)WallType.EarthPacked:
                        cost = 50;
                        break;
                    case (int)WallType.GlassTreated:
                        cost = 2000;
                        break;
                    case (int)WallType.Ice:
                        cost = 500;
                        break;
                    case (int)WallType.Iron:
                        cost = 600;
                        break;
                    case (int)WallType.LivingWood:
                        cost = 1000;
                        break;
                    case (int)WallType.Masonry:
                        cost = 200;
                        break;
                    case (int)WallType.MasonrySuperior:
                        cost = 300;
                        break;
                    case (int)WallType.MasonryReinforced:
                        cost = 400;
                        break;
                    case (int)WallType.Mithril:
                        cost = 2500;
                        break;
                    case (int)WallType.StoneHewn:
                        cost = 200;
                        break;
                    case (int)WallType.StoneUnworked:
                        cost = 100;
                        break;
                    case (int)WallType.WallOfForce:
                        cost = 7500;
                        break;
                    case (int)WallType.Wood:
                        cost = 100;
                        break;
                }
                double wallMod = 1;
                switch (((ComboBox)freeStandWallsPanel.Controls[i]).SelectedIndex) {
                    case (int)WallType.Adamatine:
                        if (wallMods[(int)WallModsIndex.Fabricate])
                            wallMod = .75;
                        break;
                    case (int)WallType.Bone:
                        if (wallMods[(int)WallModsIndex.Fabricate])
                            wallMod = .75;
                        break;
                    case (int)WallType.DeepCoral:
                        if (wallMods[(int)WallModsIndex.Fabricate])
                            wallMod = .75;
                        break;
                    case (int)WallType.EarthPacked:
                        if (wallMods[(int)WallModsIndex.Underground])
                            wallMod = 0;
                        else if (wallMods[(int)WallModsIndex.MoveEarth])
                            wallMod = .75;
                        break;
                    case (int)WallType.GlassTreated:
                        if (wallMods[(int)WallModsIndex.Fabricate])
                            wallMod = .75;
                        break;
                    case (int)WallType.Ice:
                        if (wallMods[(int)WallModsIndex.WallOfIce])
                            wallMod = .5;
                        else if (wallMods[(int)WallModsIndex.WallOfWater] ||
                            wallMods[(int)WallModsIndex.Artic] ||
                            wallMods[(int)WallModsIndex.Fabricate])
                            wallMod = .75;
                        break;
                    case (int)WallType.Iron:
                        if (wallMods[(int)WallModsIndex.Fabricate])
                            wallMod = .75;
                        break;
                    case (int)WallType.LivingWood:
                        if (wallMods[(int)WallModsIndex.WallOfThorns])
                            wallMod = .5;
                        else if (wallMods[(int)WallModsIndex.PlantGrowth])
                            wallMod = .75;
                        break;
                    case (int)WallType.Masonry:
                        if (wallMods[(int)WallModsIndex.Fabricate])
                            wallMod = .75;
                        break;
                    case (int)WallType.MasonrySuperior:
                        if (wallMods[(int)WallModsIndex.Fabricate])
                            wallMod = .75;
                        break;
                    case (int)WallType.MasonryReinforced:
                        if (wallMods[(int)WallModsIndex.Fabricate])
                            wallMod = .75;
                        break;
                    case (int)WallType.Mithril:
                        if (wallMods[(int)WallModsIndex.Fabricate])
                            wallMod = .75;
                        break;
                    case (int)WallType.StoneHewn:
                        if (wallMods[(int)WallModsIndex.Fabricate] ||
                            wallMods[(int)WallModsIndex.StoneShape] ||
                            wallMods[(int)WallModsIndex.Moutain])
                            wallMod = .75;
                        else if (wallMods[(int)WallModsIndex.WallOfStone])
                            wallMod = .5;
                        break;
                    case (int)WallType.StoneUnworked:
                        if (wallMods[(int)WallModsIndex.Fabricate] ||
                            wallMods[(int)WallModsIndex.StoneShape] ||
                            wallMods[(int)WallModsIndex.Moutain])
                            wallMod = .75;
                        else if (wallMods[(int)WallModsIndex.WallOfStone])
                            wallMod = .5;
                        break;
                    case (int)WallType.WallOfForce:
                        if (wallMods[(int)WallModsIndex.WallOfForce])
                            wallMod = .5;
                        break;
                    case (int)WallType.Wood:
                        if (wallMods[(int)WallModsIndex.Fabricate] ||
                            wallMods[(int)WallModsIndex.PlantGrowth] ||
                            wallMods[(int)WallModsIndex.Forest])
                            wallMod = .75;
                        else if (wallMods[(int)WallModsIndex.Above])
                            wallMod = .5;
                        break;
                }
                cost *= wallMod * costReduction * wallCount;
                if (((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.None)
                    cost += wallCount *  0;
                else if (((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.Slick)
                    cost += wallCount *  500;
                else if (((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.Airtight)
                    cost += wallCount *  1000;
                else if (((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.Spiderwalk ||
                    ((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.Webbed)
                    cost += wallCount *  1500;
                else if (((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.EtherallySolid ||
                    ((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.Tanglewood)
                    cost += wallCount *  2500;
                else if (((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.ElementalProtection ||
                    ((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.FogVeil ||
                    ((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.Windwall)
                    cost += wallCount *  3000;
                else if (((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.FogVeilSolid ||
                    ((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.MagicWarding ||
                    ((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.Transparent)
                    cost += wallCount *  5000;
                else if (((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.ElementalProtectionImproved)
                    cost += wallCount *  6000;
                else if (((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.Fiery ||
                    ((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.FogVeilStinking ||
                    ((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.FogVeilKilling ||
                    ((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.Frostwall ||
                    ((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.Thornwood)
                    cost += wallCount *  7500;
                else if (((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.Bladed ||
                    ((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.FogVeilIncendiary)
                    cost += wallCount *  12500;
                else if (((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex == (int)WallUpgrade.PrismaticScreen)
                    cost += wallCount *  20000;
            }
            return cost;
        }

        private void saveButton_Click(object sender, EventArgs e) {
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                string filePath = saveFileDialog.FileName;
                FileStream outstream = File.OpenWrite(filePath);
                BinaryWriter writer = new BinaryWriter(outstream);
                //wall cost modifiers
                writer.Write('w');
                foreach (Control c in wallModsBox.Controls)
                    writer.Write(((CheckBox)c).Checked);

                //mobility
                writer.Write('m');
                writer.Write(mobilitySpeedDropDown.SelectedIndex);
                writer.Write(mobilityTypeDropDown.SelectedIndex);
                writer.Write(mobilitySpecialDropDown.SelectedIndex);

                //rooms
                foreach (Room r in rooms) {
                    writer.Write('r');
                    writer.Write(r.RoomIndex);
                    writer.Write(r.QualityIndex);
                    writer.Write(r.WallIndex);
                    writer.Write(r.WallUpIndex);
                    writer.Write(r.Addons.Length);
                    foreach (Addon a in r.Addons)
                        writer.Write((int)a);
                }

                //wondrous architecture
                for (int i = 2; i < wondrousArchPanel.Controls.Count; i += 2) {
                    writer.Write('a');
                    writer.Write(((ComboBox)wondrousArchPanel.Controls[i]).SelectedIndex);
                }

                //freestanding walls
                for (int i = 2; i < freeStandWallsPanel.Controls.Count; i+= 4) {
                    writer.Write('f');
                    writer.Write(((ComboBox)freeStandWallsPanel.Controls[i+1]).SelectedIndex);
                    writer.Write(((ComboBox)freeStandWallsPanel.Controls[i+2]).SelectedIndex);
                    writer.Write((int)(((NumericUpDown)freeStandWallsPanel.Controls[i]).Value));
                }

                saveFileDialog.FileName = null;
                writer.Close();
            }
        }

        private void loadButton_Click(object sender, EventArgs e) {
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                FileStream instream = File.OpenRead(openFileDialog.FileName);
                BinaryReader reader = new BinaryReader(instream);
                rooms.Clear();
                while (roomPanel.Controls.Count > 1)
                    roomPanel.Controls.RemoveAt(1);

                while (wondrousArchPanel.Controls.Count > 1)
                    wondrousArchPanel.Controls.RemoveAt(1);

                while (freeStandWallsPanel.Controls.Count > 1)
                    freeStandWallsPanel.Controls.RemoveAt(1);

                bool moreToRead = true;
                char c;
                while (moreToRead) {
                    try {
                        c = reader.ReadChar();
                        switch (c) {
                            case 'w':
                                CheckBox cb;
                                for (int i = 0; i < wallModsBox.Controls.Count; i++) {
                                    cb = (CheckBox)wallModsBox.Controls[i];
                                    cb.Checked = reader.ReadBoolean();
                                }
                                break;

                            case 'm':
                                mobilitySpeedDropDown.SelectedIndex = reader.ReadInt32();
                                mobilityTypeDropDown.SelectedIndex = reader.ReadInt32();
                                mobilitySpecialDropDown.SelectedIndex = reader.ReadInt32();
                                break;

                            case 'r':
                                int typeIn = reader.ReadInt32();
                                int quaIn = reader.ReadInt32();
                                int wallIn = reader.ReadInt32();
                                int wallUpIn = reader.ReadInt32();
                                int addinsLength = reader.ReadInt32();
                                int[] addins = new int[addinsLength];
                                for (int i = 0; i < addinsLength; i++)
                                    addins[i] = reader.ReadInt32();
                                Room r = new Room(roomPanel, roomInfo, wallMods, typeIn, quaIn, wallIn, wallUpIn, addins);
                                rooms.Add(r);
                                break;

                            case 'a':
                                addNewWondrousArch_Click(sender, e);
                                ((ComboBox)wondrousArchPanel.Controls[wondrousArchPanel.Controls.Count-1]).SelectedIndex = reader.ReadInt32();
                                break;

                            case 'f':
                                newWallSectionButton_Click(sender, e);
                                ((ComboBox)freeStandWallsPanel.Controls[freeStandWallsPanel.Controls.Count - 2]).SelectedIndex = reader.ReadInt32();
                                ((ComboBox)freeStandWallsPanel.Controls[freeStandWallsPanel.Controls.Count - 1]).SelectedIndex = reader.ReadInt32();
                                ((NumericUpDown)freeStandWallsPanel.Controls[freeStandWallsPanel.Controls.Count - 3]).Value = reader.Read();
                                break;
                        }
                    } catch (Exception) {
                        moreToRead = false;
                    }
                }
                reader.Close();
                openFileDialog.FileName = null;
            }
        }
    }
}
