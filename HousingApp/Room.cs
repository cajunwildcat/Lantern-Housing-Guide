﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HousingApp {
    class Room {
        /// <summary>
        /// called when the room size is changed either from room type or quality change
        /// </summary>
        public event RoomSizeDelegate RoomSizeChanged;
        /// <summary>
        /// called when the room is removed
        /// </summary>
        public event RoomRemovedDelegate RoomRemoved;
        /// <summary>
        /// called when any information is changed
        /// </summary>
        public event CostDelegate CostUpdated;

        //costs & reference data
        private int margin;
        private int roomCost;
        private int qualityMod;
        private int wallCost;
        private int wallUpCost;
        private double wallMod; //decimal representation of percent
        private double roomSize;
        private List<bool> wallMods;
        private List<string[]> roomOptions;
        private List<Addon> addons;
        private string[] possibleAddons;

        //base controls
        private Panel roomPanel;
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

        /// <summary>
        /// creates a new Room with basic selections
        /// </summary>
        /// <param name="roomPanel">the panel to place the room in</param>
        /// <param name="roomOptions">list of string arrays used to fill the drop down boxes</param>
        /// <param name="wallMods">list of bools that determine cost reductions for wall costs</param>
        public Room(Panel roomPanel, List<string[]> roomOptions, List<bool> wallMods) {
            this.roomPanel = roomPanel;
            this.roomOptions = roomOptions;
            this.wallMods = wallMods;
            SetUpControls();

            roomSize = 1;
            qualityMod = 1;
            wallMod = 1;
            wallUpCost = 0;
            RoomTypeChanged(typeDrop, new EventArgs());
            wallDrop.SelectedIndex = wallDrop.Items.Count - 1;
        }

        /// <summary>
        /// creates a new Room with information from a loaded room
        /// </summary>
        /// <param name="roomPanel">the panel to place the room in</param>
        /// <param name="roomOptions">list of string arrays used to fill the drop down boxes</param>
        /// <param name="wallMods">list of bools that determine cost reductions for wall costs</param>
        /// <param name="typeIndex">the index of the selected room type</param>
        /// <param name="qualityIndex">the index of the selected room quality </param>
        /// <param name="wallIndex">the index of the selected wall type</param>
        /// <param name="wallUpIndex">the index of the selected wall upgrade</param>
        /// <param name="addonsIndexes">the indices of any add-ons</param>
        public Room(Panel roomPanel, List<string[]> roomOptions, List<bool> wallMods, 
            int typeIndex, int qualityIndex, int wallIndex, int wallUpIndex, int[] addonsIndexes) {
            this.roomPanel = roomPanel;
            this.roomOptions = roomOptions;
            this.wallMods = wallMods;
            SetUpControls();

            typeDrop.SelectedIndex = typeIndex;
            qualityDrop.SelectedIndex = qualityIndex;
            wallDrop.SelectedIndex = wallIndex;
            wallUpDrop.SelectedIndex = wallUpIndex;

            for (int i = 0; i < addonsIndexes.Length; i++) {
                AddAddon(addonButton, new EventArgs());
                ((ComboBox)box.Controls[12 + 3 * i]).SelectedIndex = addonsIndexes[i];
                UpdateAddon(box.Controls[12 + 3 * i], new EventArgs());
            }
        }

        /// <summary>
        /// setus the base controls' positions, properties, and events
        /// </summary>
        private void SetUpControls() {
            margin = 6;
            addons = new List<Addon>();

            //groupbox
            box = new GroupBox();
            roomPanel.Controls.Add(box);
            box.Location = new Point(12,
                    roomPanel.Controls[roomPanel.Controls.Count - 2].Height
                    + roomPanel.Controls[roomPanel.Controls.Count - 2].Location.Y + 12);
            box.Size = new Size(roomPanel.Width - 41, 154);
            box.Text = $"Room {roomPanel.Controls.Count - 1}";

            //remove room button
            closeButton = new Button();
            box.Controls.Add(closeButton);
            closeButton.Size = new Size(10, 14);
            closeButton.Location = new Point(box.Width - closeButton.Width, 5);
            closeButton.Text = "x";
            closeButton.FlatStyle = FlatStyle.System;
            closeButton.TabStop = false;
            closeButton.Click += RemoveRoom;

            //room type
            typeLabel = new Label();
            box.Controls.Add(typeLabel);
            typeLabel.Text = "Type";
            typeLabel.Location = new Point(margin, 24);
            typeLabel.AutoSize = true;

            typeDrop = new ComboBox();
            box.Controls.Add(typeDrop);
            typeDrop.Location = new Point(box.Width - margin - typeDrop.Width, 24);
            typeDrop.DropDownStyle = ComboBoxStyle.DropDownList;
            typeDrop.DataSource = roomOptions[0].Clone();
            typeDrop.TabStop = false;

            //room quality
            qualityLabel = new Label();
            box.Controls.Add(qualityLabel);
            qualityLabel.Text = "Quality";
            qualityLabel.Location = new Point(margin, 48);
            qualityLabel.AutoSize = true;

            qualityDrop = new ComboBox();
            box.Controls.Add(qualityDrop);
            qualityDrop.Location = new Point(box.Width - margin - qualityDrop.Width, 48);
            qualityDrop.DropDownStyle = ComboBoxStyle.DropDownList;
            qualityDrop.DataSource = new string[] { "Basic", "Fnacy", "Luxury" };
            qualityDrop.TabStop = false;

            //wall type
            wallLabel = new Label();
            box.Controls.Add(wallLabel);
            wallLabel.Text = "Walls";
            wallLabel.Location = new Point(margin, 72);
            wallLabel.AutoSize = true;

            wallDrop = new ComboBox();
            box.Controls.Add(wallDrop);
            wallDrop.Location = new Point(box.Width - margin - wallDrop.Width, 72);
            wallDrop.DropDownStyle = ComboBoxStyle.DropDownList;
            wallDrop.DataSource = roomOptions[1].Clone();
            wallDrop.TabStop = false;

            //wall upgrades
            wallUpLabel = new Label();
            box.Controls.Add(wallUpLabel);
            wallUpLabel.Text = "Wall Upgrade";
            wallUpLabel.Location = new Point(margin, 96);
            wallUpLabel.AutoSize = true;

            wallUpDrop = new ComboBox();
            box.Controls.Add(wallUpDrop);
            wallUpDrop.Location = new Point(wallUpLabel.Location.X + wallUpLabel.Width + margin, 96);
            wallUpDrop.Width = box.Width - wallUpDrop.Location.X - margin;
            wallUpDrop.DropDownStyle = ComboBoxStyle.DropDownList;
            wallUpDrop.DataSource = roomOptions[2].Clone();
            wallUpDrop.SelectedIndex = 0;
            wallUpDrop.TabStop = false;

            //add add-on button
            addonButton = new Button();
            box.Controls.Add(addonButton);
            addonButton.Text = "New Add-on";
            addonButton.AutoSize = true;
            addonButton.Location = new Point((box.Width - addonButton.Width) / 2,
                125);
            addonButton.BackColor = Color.FromName("ControlLight");
            addonButton.Click += AddAddon;
            addonButton.TabStop = false;

            //setup events for comboboxes
            typeDrop.SelectedIndexChanged += RoomTypeChanged;
            typeDrop.SelectedIndexChanged += UpdateRoomSize;
            qualityDrop.SelectedIndexChanged += QualityChanged;
            qualityDrop.SelectedIndexChanged += UpdateRoomSize;
            wallDrop.SelectedIndexChanged += UpdateWallCost;
            wallDrop.SelectedIndexChanged += CalculateCall;
            wallUpDrop.SelectedIndexChanged += WallUpgradeChanged;
            wallUpDrop.SelectedIndexChanged += CalculateCall;


            possibleAddons = (string[])roomOptions[3].Clone();
        }

        /// <summary>
        /// removes the current room by disposing of the coresponding GroupBox and alerts the parent container to move
        /// the remainder rooms to the correct position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveRoom(Object sender, EventArgs e) {
            box.Parent.Controls.Remove(box);
            box.Dispose();
            if (RoomRemoved != null)
                RoomRemoved(this);
        }

        /// <summary>
        /// updates the base room cost & available qualities depending on the selected index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoomTypeChanged(Object sender, EventArgs e) {
            ComboBox drop = (ComboBox)sender;
            //room quality
            if (drop.SelectedIndex == (int)RoomType.Barbican ||
                drop.SelectedIndex == (int)RoomType.Barracks ||
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

        /// <summary>
        /// updates the quality modifier based on the selected index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QualityChanged(Object sender, EventArgs e) {
            if (qualityDrop.SelectedIndex == 0)
                qualityMod = 1;
            else if (qualityDrop.SelectedIndex == 1)
                qualityMod = 5;
            else if (qualityDrop.SelectedIndex == 2)
                qualityMod = 15;
        }

        /// <summary>
        /// updates the room size when the room type or quality is changed and alerts the main 
        /// form to recalculate building size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateRoomSize(Object sender, EventArgs e) {
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

        /// <summary>
        /// updates the base wall cost based on the selected index and calls UpdateWallMod
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateWallCost(Object sender, EventArgs e) {
            switch (wallDrop.SelectedIndex) {
                case (int)WallType.Adamatine:
                    wallCost = 5000;
                    break;
                case (int)WallType.Bone:
                    wallCost = 400;
                    break;
                case (int)WallType.DeepCoral:
                    wallCost = 600;
                    break;
                case (int)WallType.EarthPacked:
                    wallCost = 50;
                    break;
                case (int)WallType.GlassTreated:
                    wallCost = 2000;
                    break;
                case (int)WallType.Ice:
                    wallCost = 500;
                    break;
                case (int)WallType.Iron:
                    wallCost = 600;
                    break;
                case (int)WallType.LivingWood:
                    wallCost = 1000;
                    break;
                case (int)WallType.Masonry:
                    wallCost = 200;
                    break;
                case (int)WallType.MasonrySuperior:
                    wallCost = 300;
                    break;
                case (int)WallType.MasonryReinforced:
                    wallCost = 400;
                    break;
                case (int)WallType.Mithril:
                    wallCost = 2500;
                    break;
                case (int)WallType.StoneHewn:
                    wallCost = 200;
                    break;
                case (int)WallType.StoneUnworked:
                    wallCost = 100;
                    break;
                case (int)WallType.WallOfForce:
                    wallCost = 7500;
                    break;
                case (int)WallType.Wood:
                    wallCost = 100;
                    break;
            }
            UpdateWallMod();
        }
        
        /// <summary>
        /// updates the wallMod depending on the selected checkboxes represented in the wallMods list
        /// </summary>
        public void UpdateWallMod() {
            wallMod = 1;
            switch (wallDrop.SelectedIndex) {
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
                    if (wallMods[(int)WallModsIndex.Above])
                        wallMod = 0;
                    else if (wallMods[(int)WallModsIndex.Fabricate] ||
                        wallMods[(int)WallModsIndex.PlantGrowth] ||
                        wallMods[(int)WallModsIndex.Forest])
                        wallMod = .75;
                    break;
            }
        }

        /// <summary>
        /// updates the wallUpCost corresponding to the selected index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WallUpgradeChanged(Object sender, EventArgs e) {
            if (wallUpDrop.SelectedIndex == (int)WallUpgrade.None)
                wallUpCost = 0;
            else if (wallUpDrop.SelectedIndex == (int)WallUpgrade.Slick)
                wallUpCost = 500;
            else if (wallUpDrop.SelectedIndex == (int)WallUpgrade.Airtight)
                wallUpCost = 1000;
            else if (wallUpDrop.SelectedIndex == (int)WallUpgrade.Spiderwalk ||
                wallUpDrop.SelectedIndex == (int)WallUpgrade.Webbed)
                wallUpCost = 1500;
            else if (wallUpDrop.SelectedIndex == (int)WallUpgrade.EtherallySolid ||
                wallUpDrop.SelectedIndex == (int)WallUpgrade.Tanglewood)
                wallUpCost = 2500;
            else if (wallUpDrop.SelectedIndex == (int)WallUpgrade.ElementalProtection ||
                wallUpDrop.SelectedIndex == (int)WallUpgrade.FogVeil ||
                wallUpDrop.SelectedIndex == (int)WallUpgrade.Windwall)
                wallUpCost = 3000;
            else if (wallUpDrop.SelectedIndex == (int)WallUpgrade.FogVeilSolid ||
                wallUpDrop.SelectedIndex == (int)WallUpgrade.MagicWarding ||
                wallUpDrop.SelectedIndex == (int)WallUpgrade.Transparent)
                wallUpCost = 5000;
            else if (wallUpDrop.SelectedIndex == (int)WallUpgrade.ElementalProtectionImproved)
                wallUpCost = 6000;
            else if (wallUpDrop.SelectedIndex == (int)WallUpgrade.Fiery ||
                wallUpDrop.SelectedIndex == (int)WallUpgrade.FogVeilStinking ||
                wallUpDrop.SelectedIndex == (int)WallUpgrade.FogVeilKilling ||
                wallUpDrop.SelectedIndex == (int)WallUpgrade.Frostwall ||
                wallUpDrop.SelectedIndex == (int)WallUpgrade.Thornwood)
                wallUpCost = 7500;
            else if (wallUpDrop.SelectedIndex == (int)WallUpgrade.Bladed ||
                wallUpDrop.SelectedIndex == (int)WallUpgrade.FogVeilIncendiary)
                wallUpCost = 12500;
            else if (wallUpDrop.SelectedIndex == (int)WallUpgrade.PrismaticScreen)
                wallUpCost = 20000;
        }

        /// <summary>
        /// adds a new addon drop down and associated label and remove button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAddon(Object sender, EventArgs e) {
            addons.Add(Addon.DoorWoodGood);

            Button b = new Button();
            box.Controls.Add(b);
            b.Size = new Size(10, 13);
            b.Location = new Point(0, 96 + 24 * addons.Count);
            b.Text = "x";
            b.FlatStyle = FlatStyle.System;
            b.Click += RemoveAddon;
            b.TabStop = false;

            Label l = new Label();
            box.Controls.Add(l);
            l.AutoSize = true;
            l.Location = new Point(margin + 10, 96 + 24 * addons.Count);
            l.Text = $"Add-on {addons.Count}";

            ComboBox cb = new ComboBox();
            box.Controls.Add(cb);
            cb.DataSource = possibleAddons.Clone();
            cb.Location = new Point(l.Location.X + l.Size.Width + margin, 96 + 24 * addons.Count);
            cb.Width = box.Width - cb.Location.X - margin;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.SelectedIndexChanged += UpdateAddon;
            cb.SelectedIndexChanged += CalculateCall;
            cb.TabStop = false;

            Button s = (Button)sender;
            s.Location = new Point(s.Location.X, s.Location.Y + 24);
            box.Height += 24;
            for (int i = box.Parent.Controls.IndexOf(box)+1; i < box.Parent.Controls.Count; i++) {
                box.Parent.Controls[i].Location = new Point(box.Parent.Controls[i].Location.X, box.Parent.Controls[i].Location.Y + 24);
            }
            CalculateCall(sender, e);
        }

        /// <summary>
        /// updates the addon in the addon array to correspond to the selected index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateAddon(Object sender, EventArgs e) {
            ComboBox cb = (ComboBox)sender;
            addons[(box.Controls.IndexOf(cb) - 12) /3] = (Addon)cb.SelectedIndex;
        }

        /// <summary>
        /// removes the current addon and moves the ones below up and re-numbers them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveAddon(Object sender, EventArgs e) {
            Button b = (Button)sender;
            int addonIndex = box.Controls.IndexOf(b);
            addons.RemoveAt((addonIndex - 10) / 3);
            box.Controls[addonIndex].Dispose();
            box.Controls[addonIndex].Dispose();
            box.Controls[addonIndex].Dispose();
            for (int i = addonIndex; i < box.Controls.Count; i += 3) {
                box.Controls[i].Location = new Point(box.Controls[i].Location.X, box.Controls[i].Location.Y - 24);
                box.Controls[i+1].Location = new Point(box.Controls[i+1].Location.X, box.Controls[i].Location.Y);
                box.Controls[i+2].Location = new Point(box.Controls[i+2].Location.X, box.Controls[i].Location.Y);
                box.Controls[i+1].Text = $"Add-on {(i - 10) / 3 + 1}";
            }

            box.Controls[9].Location = new Point(box.Controls[9].Location.X, box.Controls[9].Location.Y - 24);
            box.Height -= 24;

            for (int i = roomPanel.Controls.IndexOf(box) + 1; i < roomPanel.Controls.Count; i++) {
                roomPanel.Controls[i].Location = new Point(roomPanel.Controls[i].Location.X, roomPanel.Controls[i].Location.Y - 24);
            }
            CalculateCall(sender, e);
        }

        /// <summary>
        /// calculates the total cost of the selected addons
        /// </summary>
        /// <returns></returns>
        private int AddonCost() {
            //IMPORTANT NOTE: for two-portals to properly be accounted for, the addon after the kind of portal must be Portal, Two-Way
            int cost = 0;
            for (int i = 0; i < addons.Count; i++) {
                if (addons[i] == Addon.LockSimple)
                    cost += 5;
                else if (addons[i] == Addon.LockAverage ||
                    addons[i] == Addon.WindowShutterGood)
                    cost += 15;
                else if (addons[i] == Addon.DoorWoodGood)
                    cost += 25;
                else if (addons[i] == Addon.WindowIronBar ||
                    addons[i] == Addon.WindowMurderHoles)
                    cost += 30;
                else if (addons[i] == Addon.DoorWoodStrong)
                    cost += 50;
                else if (addons[i] == Addon.DoorStoneSimple ||
                    addons[i] == Addon.LockGood ||
                    addons[i] == Addon.DoorSecretSimple ||
                    addons[i] == Addon.GateWoodSimple ||
                    addons[i] == Addon.WindowGlass)
                    cost += 100;
                else if (addons[i] == Addon.DoorStoneGood ||
                    addons[i] == Addon.GateWoodGood)
                    cost += 200;
                else if (addons[i] == Addon.DoorIronSimple ||
                    addons[i] == Addon.LockAmazing ||
                    addons[i] == Addon.DoorSecretAverage ||
                    addons[i] == Addon.GateIronSimple ||
                    addons[i] == Addon.WindowStainedGlass)
                    cost += 250;
                else if (addons[i] == Addon.DoorStoneStrong ||
                    addons[i] == Addon.GateWoodStrong)
                    cost += 400;
                else if (addons[i] == Addon.DoorIronGood ||
                    addons[i] == Addon.LockImpossible ||
                    addons[i] == Addon.DoorSecretGood ||
                    addons[i] == Addon.GateIronGood ||
                    addons[i] == Addon.WindowStainedGlassFancy)
                    cost += 500;
                else if (addons[i] == Addon.GateIronStrong)
                    cost += 750;
                else if (addons[i] == Addon.DoorIronStrong ||
                    addons[i] == Addon.DoorSecretAmazing ||
                    addons[i] == Addon.DrawbridgeWood)
                    cost += 1000;
                else if (addons[i] == Addon.DoorSecretImpossible ||
                    addons[i] == Addon.DrawbridgeIron)
                    cost += 1500;
                else if (addons[i] == Addon.PortalSPLU) {
                    if (addons.Count > i+1 && addons[i + 1] == Addon.PortalTW) {
                        cost += 45000;
                        i++;
                    }
                    else
                        cost += 30000;
                }
                else if (addons[i] == Addon.PortalOPLU) {
                    if (addons.Count > i + 1 && addons[i + 1] == Addon.PortalTW) {
                        cost += 67500;
                        i++;
                    }
                    else
                        cost += 45000;
                }
                else if (addons[i] == Addon.PortalSP) {
                    if (addons.Count > i + 1 && addons[i + 1] == Addon.PortalTW) {
                        cost += 75000;
                        i++;
                    }
                    else
                        cost += 50000;
                }
                else if (addons[i] == Addon.PortalOP) {
                    if (addons.Count > i + 1 && addons[i + 1] == Addon.PortalTW) {
                        cost += 112500;
                        i++;
                    }
                    else
                        cost += 75000;
                }
            }
            return cost;
        }

        /// <summary>
        /// tells the main form to update the cost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateCall(Object sender, EventArgs e) {
            if (CostUpdated != null)
                CostUpdated(sender, e);
        }

        /// <summary>
        /// moves the GroupBox up, called when a room above is removed
        /// </summary>
        public void MoveUp() {
            box.Location = new Point(12,
                    box.Parent.Controls[box.Parent.Controls.IndexOf(box)-1].Height
                    + box.Parent.Controls[box.Parent.Controls.IndexOf(box) - 1].Location.Y + 12);
        }

        /// <summary>
        /// the total cost of the room
        /// </summary>
        public double Cost { get { return (roomCost * qualityMod) + (wallCost * wallMod * roomSize) + wallUpCost + AddonCost(); } }
        /// <summary>
        /// the size of the room used in calculating the building type
        /// </summary>
        public double RoomSize { get { return roomSize; } }
        /// <summary>
        /// the current list of bools representing the wall cost modifiers
        /// </summary>
        public List<bool> WallMods { set { wallMods = value; } }
        /// <summary>
        /// the room type index
        /// </summary>
        public int RoomIndex { get { return typeDrop.SelectedIndex; } }
        /// <summary>
        /// the room quality index
        /// </summary>
        public int QualityIndex { get { return qualityDrop.SelectedIndex; } }
        /// <summary>
        /// the room's wall type index
        /// </summary>
        public int WallIndex { get { return wallDrop.SelectedIndex; } }
        /// <summary>
        /// the room's wall upgrade index
        /// </summary>
        public int WallUpIndex { get { return wallUpDrop.SelectedIndex; } }
        /// <summary>
        /// the current addons in the room
        /// </summary>
        public Addon[] Addons { get { return addons.ToArray(); } }
    }
}