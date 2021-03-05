using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HousingApp {

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
    public partial class Form1 : Form {

        private double numORooms; //room slots filled
        private int margin;
        private double costTotal;

        private string[] roomTypes;
        private string[] roomQualities;
        private string[] wallTypes;
        private string[] wallUpgrades;
        private string[] addons;

        private List<string[]> roomInfo;
        private List<Room> rooms;

        public Form1() {
            InitializeComponent();
            numORooms = 0;
            margin = 6;
            roomInfo = new List<string[]>();
            rooms = new List<Room>();
            roomTypes = new string[] { "Armory", "Auditorium", 
                "Barbican", "Barracks", "Bath", "Bedrooms", "Bedroom Suite", 
                "Chapel", "Common Area", "Courtyard",
                "Dining Hall", "Dock", 
                "Gatehouse", 
                "Kitchen",
                "Library",
                "Magic Laboratory",
                "Shop", "Stable", "Storage", "Study",
                "Tavern", "Throne Room", "Training Hall, Combat", "Training Hall, Rogue", "Trophy Room", 
                "Workshop"};
            roomQualities = new string[] { "Basic", "Fancy", "Luxury" };
            wallTypes = new string[] { "Adamantine", "Bone", "Deep Coral", "Earth, Packed", "Glass, Treated", 
                "Ice", "Iron", "Living Wood", "Masonry", "Masonry, Superior", "Masonry Reinforced", "Mithral", 
                "Stone, Hewn", "Stone, Unworked", "Wall of Force", "Wood" };
            wallUpgrades = new string[] { "None", "Airtight", "Bladed", "Elemental Protection", "Elemental Proticetion, Improved",
                "Ethereally Solid", "Fiery", "Fog Veil", "Fog Veil, Solid", "Fog Veil, Stinking", "Fog Veil, Killing",
                "Fog Veil, Killing", "Fog Veil Incendiary", "Frostwall", "Magic Warding", "Prismatic Screen", "Slick",
                "Spiderwalk", "Tanglewood", "Thornwood", "Transparent", "Webbed", "Windwall" };
            addons = new string[] {/*"Door, Wood Simple",*/ "Door, Wood Good", "Door, Wood Strong",
            "Door, Stone Simple", "Door, Stone Good", "Door, Stone Strong",
            "Door, Iron Simple", "Door, Iron Good", "Door, Iron Strong",
            "Lock, Simple", "Lock, Average", "Lock, Good", "Lock, Amazing", "Lock, Impossible",
            "Door, Secret Simple", "Door, Secret Average", "Door, Secret Good", "Door, Secret Amazing", "Door, Secret Impossible",
            "Gate, Wood Simple", "Gate, Wood Good", "Gate, Wood Strong",
            "Gate, Iron Simple", "Gate Iron Good", "Gate, Iron Strong",
            "Drawbridge, Wood", "Drawbridge Iron",
            /*"Window, Shutters Simple",*/ "Window, Shutters Good", "Window, Iron Bars", "Window, Murder Holes", "Window, Glass", "Window, Stained Glass", "Window, Stained Glass Fnacy",
            "Portal, Same Plane, Limited Use", "Portal, Other Plane, Limited Use", "Portal, Same Plane", "Portal, Other Plane", "Two-Way Portal"};
            mobilitySpeedDropDown.SelectedIndex = 0;
            mobilityTypeDropDown.SelectedIndex = 0;
            mobilitySpecialDropDown.SelectedIndex = 0;
            roomInfo.Add(roomTypes);
            roomInfo.Add(wallTypes);
            roomInfo.Add(wallUpgrades);
            roomInfo.Add(addons);
        }

        private void newRoomButton_Click(object sender, EventArgs e) {
            //TODO if shift is being helf when clicked, add 10 rooms
            int roomsToAdd = 1;
            if (Control.ModifierKeys == Keys.Shift)
                roomsToAdd = 10;
            for (int j = 0; j < roomsToAdd; j++) {
                Room room = new Room(roomPanel, roomInfo);
                rooms.Add(room);
            }
        }

        private void RoomCountChanged(object sender, EventArgs e) {
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

        private void calculateButton_Click(object sender, EventArgs e) {
            costTotal = 0;
            int roomCost = 0;
            numORooms = 0;
            int wallCost = 0;
            ComboBox cb;
            for (int i = 0; i < rooms.Count; i++) {
                costTotal += rooms[i].Cost;
                numORooms += rooms[i].RoomSize;
            }
            //mobility
            double speedCost = 0;
            //speed
            switch (mobilitySpeedDropDown.SelectedIndex) {
                case 0: //extremely slothful
                    speedCost = 500 * numORooms;
                    break;
                case 1: //very sloth
                    speedCost = 750 * numORooms;
                    break;
                case 2: //sloth
                    speedCost = 1000 * numORooms;
                    break;
                case 3: //extremely slow
                    speedCost = 1500 * numORooms;
                    break;
                case 4: //very slow
                    speedCost = 2000 * numORooms;
                    break;
                case 5: //slow
                    speedCost = 2500 * numORooms;
                    break;
                case 6: //fair
                    speedCost = 3000 * numORooms;
                    break;
                case 7: //fleet
                    speedCost = 4000 * numORooms;
                    break;
                case 8: //fast
                    speedCost = 5000 * numORooms;
                    break;
                case 9: //very fast
                    speedCost = 7500 * numORooms;
                    break;
                case 10: //extraordinary
                    speedCost = 10000 * numORooms;
                    break;
                case 11: //incredible
                    speedCost = 12500 * numORooms;
                    break;
            }
            //special
            if (mobilitySpecialDropDown.SelectedIndex <= 1)
                speedCost += 5000 * numORooms;
            else if (mobilitySpecialDropDown.SelectedIndex == 2)
                speedCost += 10000 * numORooms;
            else
                speedCost += 25000 * numORooms;
            //type
            if (mobilityTypeDropDown.SelectedIndex == 2 || //burrowing
                mobilityTypeDropDown.SelectedIndex == 3) //submersive
                speedCost *= 2;
            else if (mobilityTypeDropDown.SelectedIndex == 4) //flying
                speedCost *= 2.5;
            costTotal += speedCost;
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

        private void AddRoomArchitecture(object sender, EventArgs e) {
            Button b1 = (Button)sender;
            //adjust heights & locations of all room groups
            b1.Parent.Height += 24;
            for (int i = roomPanel.Controls.IndexOf(b1.Parent) + 1; i < roomPanel.Controls.Count; i++) {
                roomPanel.Controls[i].Location = new Point(roomPanel.Controls[i].Location.X,
                    roomPanel.Controls[i].Location.Y + 24);
            }
            b1.Location = new Point(b1.Location.X, b1.Location.Y + 24);
            Label l1 = new Label();
            b1.Parent.Controls.Add(l1); 
            l1.Text = "Add-on";
            l1.Location = new Point(margin, ((b1.Parent.Controls.Count) / 2) * 24);
            l1.AutoSize = true;

            string[] ad = new string[addons.Length];
            for (int i = 0; i < ad.Length; i++)
                ad[i] = addons[i];
            ComboBox cb1 = new ComboBox();
            b1.Parent.Controls.Add(cb1);
            cb1.DataSource = ad;
            cb1.Location = new Point(b1.Parent.Width - margin - cb1.Width, l1.Location.Y);
            cb1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
