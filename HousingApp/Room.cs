using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HousingApp {
    class Room {

        public event RoomSizeDelegate RoomSizeChanged;
        public event RoomRemovedDelegate RoomRemoved;

        private double roomSize;
        private int roomCost;
        private int qualityMod;
        private int wallCost;
        private int wallUpCost;
        private GroupBox box;

        private Label typeLabel;
        private Label qualityLabel;
        private Label wallLabel;
        private Label wallUpLabel;
        private ComboBox typeDrop;
        private ComboBox qualityDrop;
        private ComboBox wallDrop;
        private ComboBox wallUpDrop;
        private Button addonButton;
        private Button closeButton;
        private string[] adddons;

        private int margin;

        public Room(Panel roomPanel, List<string[]> roomOptions) {
            roomSize = 1;
            qualityMod = 1;
            margin = 6;
            box = new GroupBox();
            roomPanel.Controls.Add(box);
            box.Location = new Point(12,
                    roomPanel.Controls[roomPanel.Controls.Count - 2].Height
                    + roomPanel.Controls[roomPanel.Controls.Count - 2].Location.Y + 12);
            box.Size = new Size(roomPanel.Width - 41, 170);
            box.Text = $"Room {roomPanel.Controls.Count - 1}";
            SetUpControls();
            typeDrop.DataSource = roomOptions[0].Clone();
            qualityDrop.DataSource = new string[] { "Basic", "Fnacy", "Luxury" };
            wallDrop.DataSource = roomOptions[1].Clone();
            wallUpDrop.DataSource = roomOptions[2].Clone();


            wallDrop.SelectedIndex = wallDrop.Items.Count - 1;
        }

        public Room(Panel roomPanel, int typeIndex, int qualityIndex, int wallIndex, int wallUpIndex) {
            //TODO load a room from a file
        }

        private void SetUpControls() {
            //labels
            typeLabel = new Label();
            qualityLabel = new Label();
            wallLabel = new Label();
            wallUpLabel = new Label();
            box.Controls.Add(typeLabel);
            box.Controls.Add(qualityLabel);
            box.Controls.Add(wallLabel);
            box.Controls.Add(wallUpLabel);
            typeLabel.Text = "Type";
            qualityLabel.Text = "Quality";
            wallLabel.Text = "Walls";
            wallUpLabel.Text = "Wall Upgrade";
            typeLabel.Location = new Point(margin, 24);
            qualityLabel.Location = new Point(margin, 48);
            wallLabel.Location = new Point(margin, 72);
            wallUpLabel.Location = new Point(margin, 96);
            typeLabel.AutoSize = true;
            qualityLabel.AutoSize = true;
            wallLabel.AutoSize = true;
            wallUpLabel.AutoSize = true;
            //addon button
            addonButton = new Button();
            box.Controls.Add(addonButton);
            addonButton.Text = "New Add-on";
            addonButton.AutoSize = true;
            addonButton.Location = new Point((box.Width - addonButton.Width) / 2,
                125);
            closeButton = new Button();
            box.Controls.Add(closeButton);
            closeButton.Size = new Size(10, 11);
            closeButton.Location = new Point(box.Width - closeButton.Width, 5);
            closeButton.Text = "x";
            closeButton.FlatStyle = FlatStyle.System;
            closeButton.Click += RemoveRoom;
            //comboboxes
            typeDrop = new ComboBox();
            qualityDrop = new ComboBox();
            wallDrop = new ComboBox();
            wallUpDrop = new ComboBox();
            box.Controls.Add(typeDrop);
            box.Controls.Add(qualityDrop);
            box.Controls.Add(wallDrop);
            box.Controls.Add(wallUpDrop);
            typeDrop.Location = new Point(box.Width - margin - typeDrop.Width, 24);
            qualityDrop.Location = new Point(box.Width - margin - qualityDrop.Width, 48);
            wallDrop.Location = new Point(box.Width - margin - wallDrop.Width, 72);
            wallUpDrop.Location = new Point(box.Width - margin - wallUpDrop.Width, 96);
            typeDrop.DropDownStyle = ComboBoxStyle.DropDownList;
            qualityDrop.DropDownStyle = ComboBoxStyle.DropDownList;
            wallDrop.DropDownStyle = ComboBoxStyle.DropDownList;
            wallUpDrop.DropDownStyle = ComboBoxStyle.DropDownList;

            typeDrop.SelectedIndexChanged += RoomChanged;
            typeDrop.SelectedIndexChanged += RoomSizeUpdate;
            qualityDrop.SelectedIndexChanged += QualityChanged;
            qualityDrop.SelectedIndexChanged += RoomSizeUpdate;
        }

        private void RemoveRoom(Object sender, EventArgs e) {
            box.Parent.Controls.Remove(box);
            box.Dispose();
            if (RoomRemoved != null)
                RoomRemoved(this);
        }

        private void RoomChanged(Object sender, EventArgs e) {
            ComboBox drop = (ComboBox)sender;
            if (drop.SelectedIndex == (int)RoomType.Auditorium ||
                drop.SelectedIndex == (int)RoomType.Barbican ||
                drop.SelectedIndex == (int)RoomType.Gatehouse)
                qualityDrop.DataSource = new string[] { "Basic" };
            else
                qualityDrop.DataSource = new string[] { "Basic", "Fancy", "Luxury" };

            //cost
            if (drop.SelectedIndex == (int)RoomType.Bath ||
                drop.SelectedIndex == (int)RoomType.Storage) 
                roomCost = 250;
            else if (drop.SelectedIndex == (int)RoomType.Bedrooms) 
                roomCost = 300;
            else if (drop.SelectedIndex == (int)RoomType.Barracks) 
                roomCost = 400;
            else if (drop.SelectedIndex == (int)RoomType.Armory || 
                drop.SelectedIndex == (int)RoomType.BedroomSuite || 
                drop.SelectedIndex == (int)RoomType.CommonArea || 
                drop.SelectedIndex == (int)RoomType.Courtyard || 
                drop.SelectedIndex == (int)RoomType.Stable || 
                drop.SelectedIndex == (int)RoomType.Study || 
                drop.SelectedIndex == (int)RoomType.Workshop)
                roomCost = 500;
            else if (drop.SelectedIndex == (int)RoomType.Kitchen || 
                drop.SelectedIndex == (int)RoomType.Library || 
                drop.SelectedIndex == (int)RoomType.MagicLaboratory || 
                drop.SelectedIndex == (int)RoomType.Shop || 
                drop.SelectedIndex == (int)RoomType.Tavern || 
                drop.SelectedIndex == (int)RoomType.TrainingHallCombat || 
                drop.SelectedIndex == (int)RoomType.TrainingHallRogue) 
                roomCost = 750;
            else if (drop.SelectedIndex == (int)RoomType.Auditorium || 
                drop.SelectedIndex == (int)RoomType.Barbican || 
                drop.SelectedIndex == (int)RoomType.Chapel || 
                drop.SelectedIndex == (int)RoomType.DiningHall ||
                drop.SelectedIndex == (int)RoomType.Dock ||
                drop.SelectedIndex == (int)RoomType.Gatehouse ||
                drop.SelectedIndex == (int)RoomType.Trophy)
                roomCost = 1000;
            else if (drop.SelectedIndex == (int)RoomType.ThroneRoom)
                roomCost = 2500;
        }

        private void QualityChanged(Object sender, EventArgs e) {
            if (qualityDrop.SelectedIndex == 0)
                qualityMod = 1;
            else if (qualityDrop.SelectedIndex == 1)
                qualityMod = 5;
            else if (qualityDrop.SelectedIndex == 2)
                qualityMod = 15;
        }

        public void RoomSizeUpdate(Object sender, EventArgs e) {
            //room size
            if (qualityDrop.SelectedIndex == 0) {
                if (typeDrop.SelectedIndex == (int)RoomType.Bath)
                    roomSize = 0.5;
                else if (typeDrop.SelectedIndex == (int)RoomType.Auditorium ||
                    typeDrop.SelectedIndex == (int)RoomType.DiningHall ||
                    typeDrop.SelectedIndex == (int)RoomType.Dock)
                    roomSize = 2;
                else
                    roomSize = 1;
            }
            else if (qualityDrop.SelectedIndex == 1) {
                if (typeDrop.SelectedIndex == (int)RoomType.Dock)
                    roomSize = 3;
                else if (typeDrop.SelectedIndex == (int)RoomType.Auditorium ||
                    typeDrop.SelectedIndex == (int)RoomType.Chapel ||
                    typeDrop.SelectedIndex == (int)RoomType.Courtyard ||
                    typeDrop.SelectedIndex == (int)RoomType.DiningHall ||
                    typeDrop.SelectedIndex == (int)RoomType.Tavern ||
                    typeDrop.SelectedIndex == (int)RoomType.ThroneRoom ||
                    typeDrop.SelectedIndex == (int)RoomType.Trophy)
                    roomSize = 2;
                else
                    roomSize = 1;
            }
            else {
                if (typeDrop.SelectedIndex == (int)RoomType.TrainingHallCombat ||
                    typeDrop.SelectedIndex == (int)RoomType.TrainingHallRogue)
                    roomSize = 1;
                else if (typeDrop.SelectedIndex == (int)RoomType.Dock)
                    roomSize = 4;
                else if (typeDrop.SelectedIndex == (int)RoomType.Auditorium ||
                    typeDrop.SelectedIndex == (int)RoomType.Chapel ||
                    typeDrop.SelectedIndex == (int)RoomType.Courtyard ||
                    typeDrop.SelectedIndex == (int)RoomType.DiningHall ||
                    typeDrop.SelectedIndex == (int)RoomType.Tavern ||
                    typeDrop.SelectedIndex == (int)RoomType.ThroneRoom ||
                    typeDrop.SelectedIndex == (int)RoomType.Trophy)
                    roomSize = 3;
                else
                    roomSize = 2;
            }
            if (RoomSizeChanged != null)
                RoomSizeChanged();
        }

        public void MoveUp() {
            box.Location = new Point(12,
                    box.Parent.Controls[box.Parent.Controls.IndexOf(box)-1].Height
                    + box.Parent.Controls[box.Parent.Controls.IndexOf(box) - 1].Location.Y + 12);
        }

        public GroupBox Box { get { return box; } }
        public double Cost { get { return (roomCost * qualityMod) + (wallCost * roomSize) + wallUpCost; } }
        public double RoomSize { get { return roomSize; } }

    }
}
