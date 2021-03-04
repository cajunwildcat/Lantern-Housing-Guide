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
    public partial class Form1 : Form {

        private double numORooms; //room slots filled
        private int margin;
        private double costTotal;

        private string[] roomTypes;
        private string[] roomQualities;
        private string[] wallTypes;
        private string[] wallUpgrades;
        private string[] addons;

        public Form1() {
            InitializeComponent();
            numORooms = 0;
            margin = 6;
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
        }

        private void newRoomButton_Click(object sender, EventArgs e) {
            //TODO if shift is being helf when clicked, add 10 rooms
            int roomsToAdd = 1;
            if (Control.ModifierKeys == Keys.Shift)
                roomsToAdd = 10;
            for (int j = 0; j < roomsToAdd; j++) {
                numORooms += 1;
                RoomCountChanged(sender, e);
                GroupBox gb = new GroupBox();
                roomPanel.Controls.Add(gb);
                gb.Location = new Point(12,
                    roomPanel.Controls[roomPanel.Controls.Count - 2].Height 
                    + roomPanel.Controls[roomPanel.Controls.Count - 2].Location.Y + 12);
                //height is the starting point + height of the last room added + 12
                gb.Size = new Size(roomPanel.Width - 24 - 17, 170);
                gb.Text = $"Room {roomPanel.Controls.Count - 1}";
                { //labels
                    Label l1 = new Label();
                    Label l2 = new Label();
                    Label l3 = new Label();
                    Label l4 = new Label();
                    gb.Controls.Add(l1);
                    gb.Controls.Add(l2);
                    gb.Controls.Add(l3);
                    gb.Controls.Add(l4);
                    l1.Text = "Type";
                    l2.Text = "Quality";
                    l3.Text = "Walls";
                    l4.Text = "Wall Upgrade";
                    l1.Location = new Point(margin, 24);
                    l2.Location = new Point(margin, 48);
                    l3.Location = new Point(margin, 72);
                    l4.Location = new Point(margin, 96);
                    l1.AutoSize = true;
                    l2.AutoSize = true;
                    l3.AutoSize = true;
                    l4.AutoSize = true;
                }
                { //drop downs
                    string[] rt = new string[roomTypes.Length];
                    string[] rq = new string[roomQualities.Length];
                    string[] wt = new string[wallTypes.Length];
                    string[] wu = new string[wallUpgrades.Length];
                    //string[]
                    for (int i = 0; i < rt.Length; i++)
                        rt[i] = roomTypes[i];
                    for (int i = 0; i < rq.Length; i++)
                        rq[i] = roomQualities[i];
                    for (int i = 0; i < wt.Length; i++)
                        wt[i] = wallTypes[i];
                    for (int i = 0; i < wu.Length; i++)
                        wu[i] = wallUpgrades[i];


                    ComboBox cb1 = new ComboBox();
                    ComboBox cb2 = new ComboBox();
                    ComboBox cb3 = new ComboBox();
                    ComboBox cb4 = new ComboBox();
                    cb1.DataSource = rt;
                    cb2.DataSource = rq;
                    cb3.DataSource = wt;
                    cb4.DataSource = wu;
                    gb.Controls.Add(cb1);
                    gb.Controls.Add(cb2);
                    gb.Controls.Add(cb3);
                    gb.Controls.Add(cb4);
                    cb1.Location = new Point(gb.Width - margin - cb1.Width, 24);
                    cb2.Location = new Point(gb.Width - margin - cb2.Width, 48);
                    cb3.Location = new Point(gb.Width - margin - cb3.Width, 72);
                    cb4.Location = new Point(gb.Width - margin - cb4.Width, 96);
                    cb1.DropDownStyle = ComboBoxStyle.DropDownList;
                    cb2.DropDownStyle = ComboBoxStyle.DropDownList;
                    cb3.DropDownStyle = ComboBoxStyle.DropDownList;
                    cb4.DropDownStyle = ComboBoxStyle.DropDownList;
                    cb1.SelectedIndexChanged += RoomCountChanged;
                    cb2.SelectedIndexChanged += RoomCountChanged;
                    cb3.SelectedIndexChanged += RoomCountChanged;
                    cb4.SelectedIndexChanged += RoomCountChanged;
                    cb3.SelectedIndex = cb3.Items.Count - 1;
                }
                Button b1 = new Button();
                gb.Controls.Add(b1);
                b1.Text = "New Add-on";
                b1.AutoSize = true;
                b1.Location = new Point((gb.Width - b1.Width) / 2,
                    125);
                b1.Click += AddRoomArchitecture;
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
            int wallCost = 0;
            ComboBox cb;
            for (int i = 1; i < roomPanel.Controls.Count; i++) {
                //room type
                cb = (ComboBox)roomPanel.Controls[i].Controls[4];
                if (cb.SelectedIndex == 4 || //bath
                    cb.SelectedIndex == 18) //storage
                   roomCost= 250;
                else if (cb.SelectedIndex == 5) //bedroom
                   roomCost= 300;
                else if (cb.SelectedIndex == 3) //barracks
                   roomCost= 400;
                else if (cb.SelectedIndex == 0 || //armory
                    cb.SelectedIndex == 6 || //bedroom suite
                    cb.SelectedIndex == 8 || //common area
                    cb.SelectedIndex == 9 || //courtyard
                    cb.SelectedIndex == 17 || //stable
                    cb.SelectedIndex == 19 || //study/office
                    cb.SelectedIndex == 25) //workshop
                   roomCost= 500;
                else if (cb.SelectedIndex == 13 || //kitchen
                    cb.SelectedIndex == 14 || //library
                    cb.SelectedIndex == 15 || //magic laboratory
                    cb.SelectedIndex == 16 || //sohp
                    cb.SelectedIndex == 20 || //tavern
                    cb.SelectedIndex == 22 || //training hall, combat
                    cb.SelectedIndex == 23) //training hall, rogue
                   roomCost= 750;
                else if (cb.SelectedIndex == 1 || //auditorium
                    cb.SelectedIndex == 2 || //barbican
                    cb.SelectedIndex == 7 || //chapel
                    cb.SelectedIndex == 10 || //dining hall
                    cb.SelectedIndex == 11 || //dock
                    cb.SelectedIndex == 12 || //gatehouse
                    cb.SelectedIndex == 24) //trophy hall
                   roomCost= 1000;
                else
                   roomCost= 2500; //throne room
                //room quality
                cb = (ComboBox)roomPanel.Controls[i].Controls[5];
                if (cb.SelectedIndex == 1)
                   roomCost*= 5;
                else if (cb.SelectedIndex == 2)
                   roomCost*= 15;

                //wall type
                cb = (ComboBox)roomPanel.Controls[i].Controls[6];
                switch (cb.SelectedIndex) {
                    case 0: //adamantine
                       wallCost= 5000;
                        if (fabricateCheck.Checked)
                           wallCost-=wallCost/ 4;
                        break;
                    case 1: //bone
                       wallCost= 400;
                        if (fabricateCheck.Checked)
                           wallCost-=wallCost/ 4;
                        break;
                    case 2: //deep coral
                       wallCost= 600;
                        if (fabricateCheck.Checked)
                           wallCost-=wallCost/ 4;
                        break;
                    case 3: //earth, packed
                       wallCost= 50;
                        /*if (underGround.Checked)
                           wallCost-= c;
                        else*/ if (moveEarthCheck.Checked)
                           wallCost-=wallCost/ 4;
                        break;
                    case 4: //glass, magically treated
                       wallCost= 2000;
                        if (fabricateCheck.Checked)
                           wallCost-=wallCost/ 4;
                        break;
                    case 5: //ice
                       wallCost= 500;
                        if (articCheck.Checked || 
                            wallOIceCheck.Checked)
                           wallCost-=wallCost/ 2;
                        else if (wallOWaterCheck.Checked ||
                            fabricateCheck.Checked)
                           wallCost-=wallCost/ 4;
                        break;
                    case 6: //iron
                       wallCost= 600;
                        if (fabricateCheck.Checked)
                           wallCost-=wallCost/ 4;
                        break;
                    case 7: //living wood
                       wallCost= 1000;
                        if (wallOThornsCheck.Checked)
                           wallCost-=wallCost/ 2;
                        else if (plantGrowthCheck.Checked)
                           wallCost-=wallCost/ 4;
                        break;
                    case 8: //masonry
                       wallCost= 200;
                        if (fabricateCheck.Checked)
                           wallCost-=wallCost/ 2;
                        break;
                    case 9: //masonry, superior
                       wallCost= 300;
                        if (fabricateCheck.Checked)
                           wallCost-=wallCost/ 4;
                        break;
                    case 10: //masonry, reinforced
                       wallCost= 400;
                        if (fabricateCheck.Checked)
                           wallCost-=wallCost/ 4;
                        break;
                    case 11: //mithril
                       wallCost= 2500;
                        if (fabricateCheck.Checked)
                           wallCost-=wallCost/ 4;
                        break;
                    case 12: //stone, hewn
                       wallCost= 200;
                        if (fabricateCheck.Checked ||
                            stoneShapeCheck.Checked ||
                            mountainCheck.Checked)
                           wallCost-=wallCost/ 4;
                        else if (wallOStoneCheck.Checked)
                           wallCost-=wallCost/ 2;
                        break;
                    case 13: //stone, unworked
                       wallCost= 100;
                        if (fabricateCheck.Checked ||
                            stoneShapeCheck.Checked ||
                            mountainCheck.Checked)
                           wallCost-=wallCost/ 4;
                        else if (wallOStoneCheck.Checked)
                           wallCost-=wallCost/ 2;
                        break;
                    case 14: //wall of force
                       wallCost= 7500;
                        if (wallOForceCheck.Checked)
                           wallCost-=wallCost/ 2;
                        break;
                    /*case 15: //wood
                       wallCost= 0;
                        if (fabricateCheck.Checked ||
                            plantGrowthCheck.Checked ||
                            forestCheck.Checked)
                           wallCost-=wallCost/ 4;
                        break;*/
                }

                costTotal += roomCost + wallCost;
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
