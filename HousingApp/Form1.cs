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

        private string[] roomTypes;
        private string[] roomQaulities;
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
            roomQaulities = new string[] { "Basic", "Fancy", "Luxury" };
            wallTypes = new string[] { "Adamantine", "Bone", "Deep Coral", "Earth, Packed", "Glass, Treated", 
                "Ice", "Iron", "Living Wood", "Masonry", "Masonry, Superior", "Masonry Reinforced", "Mithral", 
                "Stone, Hewn", "Stone, Unworked", "Wall of Force", "Wood" };
            wallUpgrades = new string[] { "None", "Airtight", "Bladed", "Elemental Protection", "Elemental Proticetion, Improved",
                "Ethereally Solid", "Fiery", "Fog Veil", "Fog Veil, Solid", "Fog Veil, Stinking", "Fog Veil, Killing",
                "Fog Veil, Killing", "Fog Veil Incendiary", "Frostwall", "Magic Warding", "Prismatic Screen", "Slick",
                "Spiderwalk", "Tanglewood", "Thornwood", "Transparent", "Webbed", "Windwall" };
        }

        private void newRoomButton_Click(object sender, EventArgs e) {
            //TODO if shift is being helf when clicked, add 10 rooms
            //if (numORooms < maxRooms || numORooms == 0) {
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
                string[] rt = new string[roomTypes.Length - 1];
                string[] rq = new string[roomQaulities.Length - 1];
                //string[]
                for (int i = 0; i < rt.Length; i++)
                    rt[i] = roomTypes[i];
                for (int i = 0; i < rq.Length; i++)
                    rq[i] = roomQaulities[i];
                //for (int i = 0; i < rt.Length; i++)


                    ComboBox cb1 = new ComboBox();
                ComboBox cb2 = new ComboBox();
                ComboBox cb3 = new ComboBox();
                ComboBox cb4 = new ComboBox();
                cb1.DataSource = rt;
                cb2.DataSource = roomQaulities;
                cb3.DataSource = wallTypes;
                cb4.DataSource = wallUpgrades;
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
                cb3.SelectedIndex = wallTypes.Length - 1;
            }
            //}
            //gb.Visible = true;
        }

        private void RoomCountChanged(object sender, EventArgs e) {
            if (numORooms == 1)
                buildingSizeDropDown.SelectedIndex = 0;
            else if (numORooms <= 4)
                buildingSizeDropDown.SelectedIndex = 1;
            else if (numORooms <= 7)
                buildingSizeDropDown.SelectedIndex = 2;
            else if (numORooms <= 12)
                buildingSizeDropDown.SelectedIndex = 5;
            else if (numORooms <= 15)
                buildingSizeDropDown.SelectedIndex = 3;
            else if (numORooms <= 20)
                buildingSizeDropDown.SelectedIndex = 6;
            else if (numORooms <= 60)
                buildingSizeDropDown.SelectedIndex = 10;
            else if (numORooms <= 80)
                buildingSizeDropDown.SelectedIndex = 9;
            else if (numORooms <= 120)
                buildingSizeDropDown.SelectedIndex = 11;
            else
                buildingSizeDropDown.SelectedIndex = 12;
        }
    }
}
