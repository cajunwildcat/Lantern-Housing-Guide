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

        private int numORooms; //room slots filled
        private int maxRooms; //max room slots
        private int margin;
        private int costTotal;

        private string[] roomTypes;
        private string[] roomQualities;
        private string[] wallTypes;
        private string[] wallUpgrades;

        public Form1() {
            InitializeComponent();
            numORooms = 0;
            maxRooms = 0;
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
                {
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
            int c;
            ComboBox cb;
            for (int i = 1; i < roomPanel.Controls.Count; i++) {
                c = 0;
                cb = (ComboBox)roomPanel.Controls[i].Controls[4];
                if (cb.SelectedIndex == 4 || //bath
                    cb.SelectedIndex == 18) //storage
                    c = 250;
                else if (cb.SelectedIndex == 5) //bedroom
                    c = 300;
                else if (cb.SelectedIndex == 3) //barracks
                    c = 400;
                else if (cb.SelectedIndex == 0 || //armory
                    cb.SelectedIndex == 6 || //bedroom suite
                    cb.SelectedIndex == 8 || //common area
                    cb.SelectedIndex == 9 || //courtyard
                    cb.SelectedIndex == 17 || //stable
                    cb.SelectedIndex == 19 || //study/office
                    cb.SelectedIndex == 25) //workshop
                    c = 500;
                else if (cb.SelectedIndex == 13 || //kitchen
                    cb.SelectedIndex == 14 || //library
                    cb.SelectedIndex == 15 || //magic laboratory
                    cb.SelectedIndex == 16 || //sohp
                    cb.SelectedIndex == 20 || //tavern
                    cb.SelectedIndex == 22 || //training hall, combat
                    cb.SelectedIndex == 23) //training hall, rogue
                    c = 750;
                else if (cb.SelectedIndex == 1 || //auditorium
                    cb.SelectedIndex == 2 || //barbican
                    cb.SelectedIndex == 7 || //chapel
                    cb.SelectedIndex == 10 || //dining hall
                    cb.SelectedIndex == 11 || //dock
                    cb.SelectedIndex == 12 || //gatehouse
                    cb.SelectedIndex == 24) //trophy hall
                    c = 1000;
                else
                    c = 2500;

                    cb = (ComboBox)roomPanel.Controls[i].Controls[5];
                if (cb.SelectedIndex == 1)
                    c *= 5;
                else if (cb.SelectedIndex == 2)
                    c *= 15;
                costTotal += c;
            }
            goldCostText.Text = costTotal.ToString();
        }
    }
}
