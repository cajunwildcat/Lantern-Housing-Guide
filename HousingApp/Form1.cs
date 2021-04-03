using System;
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
    delegate void CostDelegate(Object sender, EventArgs e);

    /// <summary>
    /// integer indicies of each room type
    /// </summary>
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
    /// <summary>
    /// integer indicies of each wall type
    /// </summary>
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
    /// <summary>
    /// integer indicies of each wallcost modifier
    /// </summary>
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
    /// <summary>
    /// integer indicies of each wall upgrade
    /// </summary>
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
    /// <summary>
    /// integer indicies of each addon
    /// </summary>
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
    /// <summary>
    /// integer indicies of each wondrous architecture
    /// </summary>
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
        //building info
        private double numORooms;
        private double costTotal;

        //file info
        private string fileName;
        private string fileDir;

        //room info arrays
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
            //suck my dick im not making these more than 1 line
            roomTypes = new string[] { "Armory", "Auditorium", "Barbican", "Barracks/Quarters", "Bath", "Bedroom", "Bedroom Suite", "Chapel", "Common Area", "Courtyard", "Dining Hall", "Dock", "Gatehouse", "Kitchen", "Library", "Magic Laboratory", "Shop", "Stable", "Storage", "Study/Office", "Tavern", "Throne Room", "Combat Training Hall", "Rogue Training Hall", "Trophy Hall", "Workshop" };
            wallTypes = new string[] { "Adamantine", "Bone", "Deep Coral", "Earth, Packed", "Glass, Magically Treated", "Ice", "Iron", "Living Wood", "Masonry", "Masonry Superior", "Masonry, Reinforced", "Mithral", "Stone, Hewn", "Stone, Unworked", "Wall of Force", "Wood" };
            wallUpgrades = new string[] { "None", "Airtight", "Bladed", "Elemental Protection", "Elemental Protection, Improved", "Ethereally Solid", "Fiery", "Fog Veil", "Fog Veil, Solid", "Fog Veil, Stinking", "Fog Veil, Killing", "Fog Veil, Incendiary", "Frostwall", "Magic Warding", "Prismatic Screen", "Slick", "Spiderwalk", "Tanglewood", "Thornwood", "Transparent", "Webbed", "Windwall" };
            addons = new string[] { "Door, Wood Good", "Door, Wood Strong", "Door, Stone Simple", "Door, Stone Good", "Door, Stone Strong", "Door, Iron Simple", "Door, Iron Good", "Door, Iron Strong", "Lock, Simple", "Lock, Average", "Lock, Good", "Lock, Amazing", "Lock, Impossible", "Secret Door, Simple", "Secret Door, Average", "Secret Door, Good", "Secret Door, Amazing", "Secret Door, Impossible", "Gate, Wood Simple", "Gate, Wood Good", "Gate, Wood Strong", "Gate, Iron, Simple", "Gate, Iron, Good", "Gate, Iron, Strong", "Drawbridge, Wood", "Drawbridge, Iron", "Window, Shutters, Good", "Window, Iron Bars", "Window, Arrow Slit", "Window, Glass", "Window, Stained glass", "Window, Stained glass, Fancy", "Portal, Same Plane, Limited", "Portal, Other Plane, Limited", "Portal, Same Plane", "Portal, Other Plane", "Two-Way Portal" };
            wondrousArch = new string[] { "Ambassador's Chambers", "Bed of Regeneration", "Bed of Restoration, Lesser", "Bed of Restoration, Greater", "Bed of Wellness", "Bier of Inquisition", "Black Luminary", "Brazier of Bright Bursts", "Bright Luminary", "Cabinet of Stasis", "Cacophonous Chamber", "Chamber of Airy Water", "Chamber of Climbing", "Chamber of Comfort", "Chamber of Courage", "Chamber of the Earthbound", "Chamber of Guidance", "Chamber of Safety", "Chamber of Safety, Greater", "Chamber of Seeing", "Chamber of Sloth", "Chamber of Speed", "Chamber of the Unliving", "Everful Basin", "Everful Larder", "Garden of Understanding", "Guardian Statue", "Hall of Babbling", "Hall of Despair", "Hall of Friendship", "Hall of Friendship, Greater", "Hall of Holiness", "Hall of Hope", "Hall of Silence", "Hall of Speech", "Hall of Truth", "Hole of Hiding", "Hurricane's Eye", "Illusory Landscape", "Inscriptions of Concealment", "Inscriptions of Concealment, Greater", "Inscriptions of Privacy", "Invisible Helper", "Jester's Theater", "Map of Guidance", "Map of Tactics", "Map of Tactics, Greater", "Morgue of Preservation", "Oaken Guardian", "Orb of Pleasant Breezes", "Path of Watery Solidity", "Platform of Jaunting", "Platform of Jaunting, Greater", "Platform of Levitation", "Platform of Levitation, Greater", "Pool of Scrying", "Sanctum Sanctorum", "Sigils of Antimagic", "Speaking Stones", "Stable of Understanding", "Table of Feasting", "Table of Freshness", "Touchstone of Faith", "Touchstone of Safety", "Tree of Jaunting", "Tree of Jaunting, Greater", "Vegetative Trap", "Warding Bell", "Well of Falling", "Well of Flying" };
            //initialize lists
            numORooms = 0;

            roomInfo = new List<string[]> {
                roomTypes,
                wallTypes,
                wallUpgrades,
                addons
            };
            rooms = new List<Room>();

            wallMods = new List<bool>();
            for (int i = 0; i < wallModsBox.Controls.Count; i++) {
                wallMods.Add(((CheckBox)wallModsBox.Controls[i]).Checked);
            }

            //default index for mobility drop downs
            mobilitySpeedDropDown.SelectedIndex = 0;
            mobilityTypeDropDown.SelectedIndex = 0;
            mobilitySpecialDropDown.SelectedIndex = 0;
            this.Text = this.Text.Substring(1);
        }
        /// <summary>
        /// updates the list of wall mods in every room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WallModsUpdated(Object sender, EventArgs e) {
            for (int i = 0; i < wallMods.Count; i++)
                wallMods[i] = ((CheckBox)wallModsBox.Controls[i]).Checked;
            for (int i = 0; i < rooms.Count; i++) {
                rooms[i].WallMods = wallMods;
                rooms[i].UpdateWallMod();
            }
            CalculateTotal(sender, e);
        }
        /// <summary>
        /// adds a new room the room panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewRoomButton_Click(object sender, EventArgs e) {
            int roomsToAdd = 1;
            if (Control.ModifierKeys == Keys.Shift)
                roomsToAdd = 10;
            for (int j = 0; j < roomsToAdd; j++) {
                if (rooms.Count > 190) {
                    MessageBox.Show("Maximum amount of rooms added!", "Error");
                    break;
                }
                Room room = new Room(roomPanel, roomInfo, wallMods);
                rooms.Add(room);
                room.RoomSizeChanged += RoomCountChanged;
                room.RoomRemoved += RoomRemoved;
                room.CostUpdated += CalculateTotal;
            }
            RoomCountChanged();
        }
        /// <summary>
        /// called when a room is removed, removes it from the list and calls every room below to move up
        /// </summary>
        /// <param name="sender"></param>
        private void RoomRemoved(Object sender) {
            rooms.Remove((Room)sender);
            for (int i = 0; i < rooms.Count; i++) {
                roomPanel.Controls[i+1].Text = $"Room {i+1}";
                rooms[i].MoveUp();
            }
            RoomCountChanged();
            CalculateTotal(sender, new EventArgs());
        }
        /// <summary>
        /// updates the building size when the room size is changed
        /// </summary>
        private void RoomCountChanged() {
            numORooms = 0;
            foreach (Room r in rooms)
                numORooms += r.RoomSize;
            if (numORooms <= 1)
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
            CalculateTotal(new Object(), new EventArgs());
        }
        /// <summary>
        /// calculates the total cost of the building whenever an aspect is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateTotal(Object sender, EventArgs e) {
            if (!(this.Text[0] == '*'))
                this.Text = "*" + this.Text;
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
            //special
            if (mobilitySpecialDropDown.SelectedIndex == 2 ||
                mobilitySpecialDropDown.SelectedIndex == 1)
                speedCost += 5000 * numORooms;
            else if (mobilitySpecialDropDown.SelectedIndex == 3)
                speedCost += 10000 * numORooms;
            else if (mobilitySpecialDropDown.SelectedIndex == 4 ||
                mobilitySpecialDropDown.SelectedIndex == 5)
                speedCost += 25000 * numORooms;
            costTotal += speedCost;

            costTotal += CalculateWondrous();
            costTotal += CalculateFreeStandWalls();

            //dtp cost
            if (costTotal < 5000 && costTotal >= 0)
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
        /// <summary>
        /// adds a new wondrous architecture drop down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewWondrousArch_Click(object sender, EventArgs e) {
            Button xb = new Button();
            wondrousArchPanel.Controls.Add(xb);
            xb.Location = new Point(6,
                wondrousArchPanel.Controls[wondrousArchPanel.Controls.Count - 2].Location.Y + 30);
            xb.Size = new Size(13, 21);
            xb.Text = "X";
            xb.FlatStyle = FlatStyle.System;
            xb.Click += RemoveWondrousArch;
            xb.TabStop = false;

            ComboBox cb = new ComboBox();
            wondrousArchPanel.Controls.Add(cb);
            cb.Width = 172;
            cb.Location = new Point(wondrousArchPanel.Controls[wondrousArchPanel.Controls.Count - 2].Location.X + 16,
               wondrousArchPanel.Controls[wondrousArchPanel.Controls.Count - 2].Location.Y);
            cb.DataSource = wondrousArch.Clone();
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.SelectedIndexChanged += CalculateTotal;
            cb.TabStop = false;

            CalculateTotal(sender, e);
        }
        /// <summary>
        /// removes wondrous acrchitecture and moves the ones below it up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            CalculateTotal(sender, e);
        }
        /// <summary>
        /// calculates the cost of all wondrous architectures
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// creates a new freestanding wall section
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newWallSectionButton_Click(object sender, EventArgs e) {
            Button xb = new Button();
            freeStandWallsPanel.Controls.Add(xb);
            xb.Location = new Point(6,
                freeStandWallsPanel.Controls[freeStandWallsPanel.Controls.IndexOf(xb)-1].Location.Y + 30 + 11);
            xb.Size = new Size(13, 20);
            xb.Text = "X";
            xb.FlatStyle = FlatStyle.System;
            xb.Click += RemoveWallSection;
            xb.TabStop = false;

            NumericUpDown nud = new NumericUpDown();
            freeStandWallsPanel.Controls.Add(nud);
            nud.Location = new Point(28,
                freeStandWallsPanel.Controls[freeStandWallsPanel.Controls.Count - 2].Location.Y);
            nud.Size = new Size(35, 20);
            nud.UpDownAlign = LeftRightAlignment.Left;
            nud.TextAlign = HorizontalAlignment.Center;
            nud.ValueChanged += CalculateTotal;
            nud.TabStop = false;

            ComboBox cb = new ComboBox();
            freeStandWallsPanel.Controls.Add(cb);
            cb.Location = new Point(73,
                freeStandWallsPanel.Controls[freeStandWallsPanel.Controls.Count - 3].Location.Y - 11);
            cb.DataSource = wallTypes.Clone();
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.SelectedIndexChanged += CalculateTotal;
            cb.TabStop = false;

            ComboBox wb = new ComboBox();
            freeStandWallsPanel.Controls.Add(wb);
            wb.Location = new Point(73,
                freeStandWallsPanel.Controls[freeStandWallsPanel.Controls.Count - 2].Location.Y + 21);
            wb.DataSource = wallUpgrades.Clone();
            wb.DropDownStyle = ComboBoxStyle.DropDownList;
            wb.SelectedIndexChanged += CalculateTotal;
            wb.TabStop = false;
        }
        /// <summary>
        /// removes a freestanding wall section and moves the section below up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            CalculateTotal(sender, e);
        }
        /// <summary>
        /// calculates the cost of all the freestanding wall sections
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// checks for user input key combos to save and load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyCombos(object sender, KeyEventArgs e) {
            if (e.Control && e.Shift && e.KeyCode == Keys.S)
                SaveAs_Click(sender, new EventArgs());
            else if (e.Control && e.KeyCode == Keys.S)
                Save_Click(sender, new EventArgs());
            else if (e.Control && e.KeyCode == Keys.O)
                Load_Click(sender, new EventArgs());
        }
        /// <summary>
        /// saves the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e) {
            if (this.Text[0] != '*')
                return;
            else if (this.Text.Substring(1,8) == "Untitled") {
                SaveAs_Click(sender, e);
            }
            else {
                FileStream outstream = File.OpenWrite(fileDir + fileName + ".house");
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
                for (int i = 2; i < freeStandWallsPanel.Controls.Count; i += 4) {
                    writer.Write('f');
                    writer.Write(((ComboBox)freeStandWallsPanel.Controls[i + 1]).SelectedIndex);
                    writer.Write(((ComboBox)freeStandWallsPanel.Controls[i + 2]).SelectedIndex);
                    writer.Write((int)(((NumericUpDown)freeStandWallsPanel.Controls[i]).Value));
                }

                writer.Close();
                this.Text = fileName + " - Lantern's Housing Calculator";
            }
        }
        /// <summary>
        /// opens the saveFileDialog to prompt the user on where to save thefile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAs_Click(object sender, EventArgs e) {
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                fileName = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('\\') + 1);
                fileName = fileName.Substring(0, fileName.IndexOf('.'));
                fileDir = saveFileDialog.FileName.Substring(0, saveFileDialog.FileName.LastIndexOf('\\') + 1);
                Save_Click(sender, e);
            }
        }
        /// <summary>
        /// loads a file chosen by the user through the file browser dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Load_Click(object sender, EventArgs e) {
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                fileName = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('\\') + 1);
                fileName = fileName.Substring(0, fileName.IndexOf('.'));
                fileDir = openFileDialog.FileName.Substring(0, openFileDialog.FileName.LastIndexOf('\\') + 1);
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
                try {
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
                                    r.RoomSizeChanged += RoomCountChanged;
                                    r.RoomRemoved += RoomRemoved;
                                    r.CostUpdated += CalculateTotal;
                                    break;

                                case 'a':
                                    addNewWondrousArch_Click(sender, e);
                                    ((ComboBox)wondrousArchPanel.Controls[wondrousArchPanel.Controls.Count - 1]).SelectedIndex = reader.ReadInt32();
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
                } catch (Exception) {
                    ;//TODO: show message box about corrupted file
                }
                RoomCountChanged();
                reader.Close();
                openFileDialog.FileName = null;
            }
            CalculateTotal(sender, e);
            this.Text = fileName + " - Lantern's Housing Calculator";
        }
        /// <summary>
        /// closes the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, EventArgs e) {
            //TODO check for if the user has saved
            this.Dispose();
        }
        /// <summary>
        /// opens the webpage to submit issues on Github
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitFeedbackToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/cajunwildcat/Lantern-Housing-Guide/issues");
        }
        /// <summary>
        /// opens the webpage containing the README on Github
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void infoToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/cajunwildcat/Lantern-Housing-Guide/blob/main/README.md");
        }
    }
}