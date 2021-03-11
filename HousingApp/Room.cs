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
        private double wallMod; //decimal representation of percent
        private GroupBox box;
        private List<bool> wallMods;

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
        private List<string> addons;
        private string[] possibleAddons;

        private int margin;

        public Room(Panel roomPanel, List<string[]> roomOptions, List<bool> wallMods) {
            roomSize = 1;
            qualityMod = 1;
            margin = 6;
            wallMod = 1;
            wallUpCost = 0;
            addons = new List<string>();
            this.wallMods = wallMods;
            box = new GroupBox();
            roomPanel.Controls.Add(box);
            box.Location = new Point(12,
                    roomPanel.Controls[roomPanel.Controls.Count - 2].Height
                    + roomPanel.Controls[roomPanel.Controls.Count - 2].Location.Y + 12);
            box.Size = new Size(roomPanel.Width - 41, 154);
            box.Text = $"Room {roomPanel.Controls.Count - 1}";
            SetUpControls();
            typeDrop.DataSource = roomOptions[0].Clone();
            qualityDrop.DataSource = new string[] { "Basic", "Fnacy", "Luxury" };
            wallDrop.DataSource = roomOptions[1].Clone();
            wallUpDrop.DataSource = roomOptions[2].Clone();
            possibleAddons = (string[])roomOptions[3].Clone();

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
            //buttons
            addonButton = new Button();
            box.Controls.Add(addonButton);
            addonButton.Text = "New Add-on";
            addonButton.AutoSize = true;
            addonButton.Location = new Point((box.Width - addonButton.Width) / 2,
                125);
            addonButton.Click += AddAddon;

            closeButton = new Button();
            box.Controls.Add(closeButton);
            closeButton.Size = new Size(10, 14);
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
            wallDrop.SelectedIndexChanged += UpdateWallCost;
            wallUpDrop.SelectedIndexChanged += UpdateWallUpgrade;
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

        private void RoomSizeUpdate(Object sender, EventArgs e) {
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

        private void UpdateWallUpgrade(Object sender, EventArgs e) {
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

        private void AddAddon(Object sender, EventArgs e) {
            ComboBox cb = new ComboBox();
            box.Controls.Add(cb);
            cb.DataSource = possibleAddons.Clone();
            addons.Add(possibleAddons[cb.SelectedIndex]);
            cb.Location = new Point(box.Width - margin - cb.Width, 96 + 24 * addons.Count);
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.SelectedIndexChanged += UpdateAddon;

            Label l = new Label();
            box.Controls.Add(l);
            l.Text = $"Add-on {addons.Count}";
            l.Location = new Point(margin + 10, 96 + 24 * addons.Count);

            Button b = new Button();
            box.Controls.Add(b);
            b.Size = new Size(10, 13);
            b.Location = new Point(0, 96 + 24 * addons.Count);
            b.Text = "x";
            b.FlatStyle = FlatStyle.System;
            b.Click += RemoveAddon;

            Button s = (Button)sender;
            s.Location = new Point(s.Location.X, s.Location.Y + 24);
            box.Height += 24;
            for (int i = box.Parent.Controls.IndexOf(box)+1; i < box.Parent.Controls.Count; i++) {
                box.Parent.Controls[i].Location = new Point(box.Parent.Controls[i].Location.X, box.Parent.Controls[i].Location.Y + 24);
            }
        }

        private void UpdateAddon(Object sender, EventArgs e) {
            ComboBox cb = (ComboBox)sender;
            addons[((cb.Location.Y - 96) / 24) - 1] = possibleAddons[cb.SelectedIndex];
        }

        private void RemoveAddon(Object sender, EventArgs e) {
            Button b = (Button)sender;
            int addonNum = ((b.Location.Y - 96 ) / 24) - 1;
            addons.RemoveAt(addonNum);
            box.Controls[12 + 3 * addonNum].Dispose();
            box.Controls[11 + 3 * addonNum].Dispose();
            box.Controls[10 + 3 * addonNum].Dispose();
            for (int i = 10 + (3 * addonNum); i < box.Controls.Count; i++) {
                box.Controls[i].Location = new Point(box.Controls[i].Location.X, box.Controls[i].Location.Y - 24);
                if (box.Controls[i] is Label)
                    box.Controls[i].Text = $"Add-on {++addonNum}";
            }
            box.Controls[4].Location = new Point(box.Controls[4].Location.X, box.Controls[4].Location.Y - 24);
            box.Height -= 24;
            for (int i = box.Parent.Controls.IndexOf(box) + 1; i < box.Parent.Controls.Count; i++) {
                box.Parent.Controls[i].Location = new Point(box.Parent.Controls[i].Location.X, box.Parent.Controls[i].Location.Y - 24);
            }
        }

        private int AddonCost() {
            //IMPORTANT NOTE: for two-portals to properly be accounted for, the addon after the kind of portal must be Portal, Two-Way
            int cost = 0;
            for (int i = 0; i < addons.Count; i++) {
                if (addons[i] == possibleAddons[(int)Addon.LockSimple])
                    cost += 5;
                else if (addons[i] == possibleAddons[(int)Addon.LockAverage] ||
                    addons[i] == possibleAddons[(int)Addon.WindowShutterGood])
                    cost += 15;
                else if (addons[i] == possibleAddons[(int)Addon.DoorWoodGood])
                    cost += 25;
                else if (addons[i] == possibleAddons[(int)Addon.WindowIronBar] ||
                    addons[i] == possibleAddons[(int)Addon.WindowMurderHoles])
                    cost += 30;
                else if (addons[i] == possibleAddons[(int)Addon.DoorWoodStrong])
                    cost += 50;
                else if (addons[i] == possibleAddons[(int)Addon.DoorStoneSimple] ||
                    addons[i] == possibleAddons[(int)Addon.LockGood] ||
                    addons[i] == possibleAddons[(int)Addon.DoorSecretSimple] ||
                    addons[i] == possibleAddons[(int)Addon.GateWoodSimple] ||
                    addons[i] == possibleAddons[(int)Addon.WindowGlass])
                    cost += 100;
                else if (addons[i] == possibleAddons[(int)Addon.DoorStoneGood] ||
                    addons[i] == possibleAddons[(int)Addon.GateWoodGood])
                    cost += 200;
                else if (addons[i] == possibleAddons[(int)Addon.DoorIronSimple] ||
                    addons[i] == possibleAddons[(int)Addon.LockAmazing] ||
                    addons[i] == possibleAddons[(int)Addon.DoorSecretAverage] ||
                    addons[i] == possibleAddons[(int)Addon.GateIronSimple] ||
                    addons[i] == possibleAddons[(int)Addon.WindowStainedGlass])
                    cost += 250;
                else if (addons[i] == possibleAddons[(int)Addon.DoorStoneStrong] ||
                    addons[i] == possibleAddons[(int)Addon.GateWoodStrong])
                    cost += 400;
                else if (addons[i] == possibleAddons[(int)Addon.DoorIronGood] ||
                    addons[i] == possibleAddons[(int)Addon.LockImpossible] ||
                    addons[i] == possibleAddons[(int)Addon.DoorSecretGood] ||
                    addons[i] == possibleAddons[(int)Addon.GateIronGood] ||
                    addons[i] == possibleAddons[(int)Addon.WindowStainedGlassFancy])
                    cost += 500;
                else if (addons[i] == possibleAddons[(int)Addon.GateIronStrong])
                    cost += 750;
                else if (addons[i] == possibleAddons[(int)Addon.DoorIronStrong] ||
                    addons[i] == possibleAddons[(int)Addon.DoorSecretAmazing] ||
                    addons[i] == possibleAddons[(int)Addon.DrawbridgeWood])
                    cost += 1000;
                else if (addons[i] == possibleAddons[(int)Addon.DoorSecretImpossible] ||
                    addons[i] == possibleAddons[(int)Addon.DrawbridgeIron])
                    cost += 1500;
                else if (addons[i] == possibleAddons[(int)Addon.PortalSPLU]) {
                    if (addons[i + 1] == possibleAddons[(int)Addon.PortalTW]) {
                        cost += 45000;
                        i++;
                    }
                    else
                        cost += 30000;
                }
                else if (addons[i] == possibleAddons[(int)Addon.PortalOPLU]) {
                    if (addons[i + 1] == possibleAddons[(int)Addon.PortalTW]) {
                        cost += 67500;
                        i++;
                    }
                    else
                        cost += 45000;
                }
                else if (addons[i] == possibleAddons[(int)Addon.PortalSP]) {
                    if (addons[i + 1] == possibleAddons[(int)Addon.PortalTW]) {
                        cost += 75000;
                        i++;
                    }
                    else
                        cost += 50000;
                }
                else if (addons[i] == possibleAddons[(int)Addon.PortalOP]) {
                    if (addons[i + 1] == possibleAddons[(int)Addon.PortalTW]) {
                        cost += 112500;
                        i++;
                    }
                    else
                        cost += 75000;
                }
            }
            return cost;
        }
        
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
                    if (wallMods[(int)WallModsIndex.Fabricate] ||
                        wallMods[(int)WallModsIndex.PlantGrowth] ||
                        wallMods[(int)WallModsIndex.Forest])
                        wallMod = .75;
                    else if (wallMods[(int)WallModsIndex.Above])
                        wallMod = 0;
                    break;
            }
        }

        public void MoveUp() {
            box.Location = new Point(12,
                    box.Parent.Controls[box.Parent.Controls.IndexOf(box)-1].Height
                    + box.Parent.Controls[box.Parent.Controls.IndexOf(box) - 1].Location.Y + 12);
        }

        public GroupBox Box { get { return box; } }
        public double Cost { get { return (roomCost * qualityMod) + (wallCost * wallMod * roomSize) + wallUpCost + AddonCost(); } }
        public double RoomSize { get { return roomSize; } }
        public List<bool> WallMods { set { wallMods = value; } }
    }
}
