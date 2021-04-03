namespace HousingApp {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mobilitySpeedDropDown = new System.Windows.Forms.ComboBox();
            this.mobilityGroup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mobilitySpecialDropDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mobilityTypeDropDown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.goldCostText = new System.Windows.Forms.TextBox();
            this.buildingSizeGroup = new System.Windows.Forms.GroupBox();
            this.buildingSizeText = new System.Windows.Forms.TextBox();
            this.totalCostGroup = new System.Windows.Forms.GroupBox();
            this.DTPCostLabel = new System.Windows.Forms.Label();
            this.DTPCostText = new System.Windows.Forms.TextBox();
            this.goldCostLabel = new System.Windows.Forms.Label();
            this.roomPanel = new System.Windows.Forms.Panel();
            this.addNewRoomButton = new System.Windows.Forms.Button();
            this.roomGroup1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.wallModsBox = new System.Windows.Forms.GroupBox();
            this.aboveGroundCheck = new System.Windows.Forms.CheckBox();
            this.articCheck = new System.Windows.Forms.CheckBox();
            this.forestCheck = new System.Windows.Forms.CheckBox();
            this.mountainCheck = new System.Windows.Forms.CheckBox();
            this.fabricateCheck = new System.Windows.Forms.CheckBox();
            this.moveEarthCheck = new System.Windows.Forms.CheckBox();
            this.plantGrowthCheck = new System.Windows.Forms.CheckBox();
            this.stoneShapeCheck = new System.Windows.Forms.CheckBox();
            this.underGround = new System.Windows.Forms.CheckBox();
            this.wallOForceCheck = new System.Windows.Forms.CheckBox();
            this.wallOIceCheck = new System.Windows.Forms.CheckBox();
            this.wallOStoneCheck = new System.Windows.Forms.CheckBox();
            this.wallOThornsCheck = new System.Windows.Forms.CheckBox();
            this.wallOWaterCheck = new System.Windows.Forms.CheckBox();
            this.addNewWondrousArch = new System.Windows.Forms.Button();
            this.wondrousArchPanel = new System.Windows.Forms.Panel();
            this.wondrousArchitectureLabel = new System.Windows.Forms.Label();
            this.freeStandWallsPanel = new System.Windows.Forms.Panel();
            this.newWallSectionButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.fileDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.submitFeedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mobilityGroup.SuspendLayout();
            this.buildingSizeGroup.SuspendLayout();
            this.totalCostGroup.SuspendLayout();
            this.roomPanel.SuspendLayout();
            this.roomGroup1.SuspendLayout();
            this.wallModsBox.SuspendLayout();
            this.wondrousArchPanel.SuspendLayout();
            this.freeStandWallsPanel.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mobilitySpeedDropDown
            // 
            this.mobilitySpeedDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mobilitySpeedDropDown.FormattingEnabled = true;
            this.mobilitySpeedDropDown.Items.AddRange(new object[] {
            "None",
            "Extremely Slow",
            "Very Slothful",
            "Slothful",
            "Extremely Slow",
            "Very Slow",
            "Slow",
            "Fair",
            "Fleet",
            "Fast",
            "Very Fast",
            "Extraordinary",
            "Incredible"});
            this.mobilitySpeedDropDown.Location = new System.Drawing.Point(48, 19);
            this.mobilitySpeedDropDown.Name = "mobilitySpeedDropDown";
            this.mobilitySpeedDropDown.Size = new System.Drawing.Size(121, 21);
            this.mobilitySpeedDropDown.TabIndex = 0;
            this.mobilitySpeedDropDown.TabStop = false;
            this.mobilitySpeedDropDown.SelectedIndexChanged += new System.EventHandler(this.CalculateTotal);
            // 
            // mobilityGroup
            // 
            this.mobilityGroup.Controls.Add(this.label3);
            this.mobilityGroup.Controls.Add(this.mobilitySpecialDropDown);
            this.mobilityGroup.Controls.Add(this.label2);
            this.mobilityGroup.Controls.Add(this.mobilityTypeDropDown);
            this.mobilityGroup.Controls.Add(this.label1);
            this.mobilityGroup.Controls.Add(this.mobilitySpeedDropDown);
            this.mobilityGroup.Location = new System.Drawing.Point(32, 200);
            this.mobilityGroup.Name = "mobilityGroup";
            this.mobilityGroup.Size = new System.Drawing.Size(178, 109);
            this.mobilityGroup.TabIndex = 1;
            this.mobilityGroup.TabStop = false;
            this.mobilityGroup.Text = "Mobility";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Special";
            // 
            // mobilitySpecialDropDown
            // 
            this.mobilitySpecialDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mobilitySpecialDropDown.FormattingEnabled = true;
            this.mobilitySpecialDropDown.ItemHeight = 13;
            this.mobilitySpecialDropDown.Items.AddRange(new object[] {
            "None",
            "Astral",
            "Ethereal",
            "Plane Linked",
            "Plane Shifting",
            "Teleporting"});
            this.mobilitySpecialDropDown.Location = new System.Drawing.Point(48, 73);
            this.mobilitySpecialDropDown.Name = "mobilitySpecialDropDown";
            this.mobilitySpecialDropDown.Size = new System.Drawing.Size(121, 21);
            this.mobilitySpecialDropDown.TabIndex = 4;
            this.mobilitySpecialDropDown.TabStop = false;
            this.mobilitySpecialDropDown.SelectedIndexChanged += new System.EventHandler(this.CalculateTotal);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type";
            // 
            // mobilityTypeDropDown
            // 
            this.mobilityTypeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mobilityTypeDropDown.FormattingEnabled = true;
            this.mobilityTypeDropDown.Items.AddRange(new object[] {
            "None",
            "Walking",
            "Sailing",
            "Burrowing",
            "Submersible",
            "Flying"});
            this.mobilityTypeDropDown.Location = new System.Drawing.Point(48, 46);
            this.mobilityTypeDropDown.Name = "mobilityTypeDropDown";
            this.mobilityTypeDropDown.Size = new System.Drawing.Size(121, 21);
            this.mobilityTypeDropDown.TabIndex = 2;
            this.mobilityTypeDropDown.TabStop = false;
            this.mobilityTypeDropDown.SelectedIndexChanged += new System.EventHandler(this.CalculateTotal);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Speed";
            // 
            // goldCostText
            // 
            this.goldCostText.Location = new System.Drawing.Point(6, 19);
            this.goldCostText.Name = "goldCostText";
            this.goldCostText.ReadOnly = true;
            this.goldCostText.Size = new System.Drawing.Size(100, 20);
            this.goldCostText.TabIndex = 1;
            // 
            // buildingSizeGroup
            // 
            this.buildingSizeGroup.Controls.Add(this.buildingSizeText);
            this.buildingSizeGroup.Location = new System.Drawing.Point(55, 129);
            this.buildingSizeGroup.Name = "buildingSizeGroup";
            this.buildingSizeGroup.Size = new System.Drawing.Size(133, 51);
            this.buildingSizeGroup.TabIndex = 4;
            this.buildingSizeGroup.TabStop = false;
            this.buildingSizeGroup.Text = "Building Size";
            // 
            // buildingSizeText
            // 
            this.buildingSizeText.Location = new System.Drawing.Point(7, 19);
            this.buildingSizeText.Name = "buildingSizeText";
            this.buildingSizeText.ReadOnly = true;
            this.buildingSizeText.Size = new System.Drawing.Size(120, 20);
            this.buildingSizeText.TabIndex = 7;
            this.buildingSizeText.TabStop = false;
            // 
            // totalCostGroup
            // 
            this.totalCostGroup.Controls.Add(this.DTPCostLabel);
            this.totalCostGroup.Controls.Add(this.DTPCostText);
            this.totalCostGroup.Controls.Add(this.goldCostLabel);
            this.totalCostGroup.Controls.Add(this.goldCostText);
            this.totalCostGroup.Location = new System.Drawing.Point(32, 31);
            this.totalCostGroup.Name = "totalCostGroup";
            this.totalCostGroup.Size = new System.Drawing.Size(178, 79);
            this.totalCostGroup.TabIndex = 5;
            this.totalCostGroup.TabStop = false;
            this.totalCostGroup.Text = "Total Cost";
            // 
            // DTPCostLabel
            // 
            this.DTPCostLabel.AutoSize = true;
            this.DTPCostLabel.Location = new System.Drawing.Point(121, 48);
            this.DTPCostLabel.Name = "DTPCostLabel";
            this.DTPCostLabel.Size = new System.Drawing.Size(29, 13);
            this.DTPCostLabel.TabIndex = 6;
            this.DTPCostLabel.Text = "DTP";
            // 
            // DTPCostText
            // 
            this.DTPCostText.Location = new System.Drawing.Point(6, 45);
            this.DTPCostText.Name = "DTPCostText";
            this.DTPCostText.ReadOnly = true;
            this.DTPCostText.Size = new System.Drawing.Size(100, 20);
            this.DTPCostText.TabIndex = 5;
            this.DTPCostText.TabStop = false;
            // 
            // goldCostLabel
            // 
            this.goldCostLabel.AutoSize = true;
            this.goldCostLabel.Location = new System.Drawing.Point(121, 22);
            this.goldCostLabel.Name = "goldCostLabel";
            this.goldCostLabel.Size = new System.Drawing.Size(29, 13);
            this.goldCostLabel.TabIndex = 4;
            this.goldCostLabel.Text = "Gold";
            // 
            // roomPanel
            // 
            this.roomPanel.AutoScroll = true;
            this.roomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roomPanel.Controls.Add(this.addNewRoomButton);
            this.roomPanel.Location = new System.Drawing.Point(232, 32);
            this.roomPanel.Name = "roomPanel";
            this.roomPanel.Size = new System.Drawing.Size(270, 633);
            this.roomPanel.TabIndex = 6;
            // 
            // addNewRoomButton
            // 
            this.addNewRoomButton.AutoSize = true;
            this.addNewRoomButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addNewRoomButton.Location = new System.Drawing.Point(89, 12);
            this.addNewRoomButton.Name = "addNewRoomButton";
            this.addNewRoomButton.Size = new System.Drawing.Size(92, 23);
            this.addNewRoomButton.TabIndex = 3;
            this.addNewRoomButton.TabStop = false;
            this.addNewRoomButton.Text = "Add New Room";
            this.addNewRoomButton.UseVisualStyleBackColor = true;
            this.addNewRoomButton.Click += new System.EventHandler(this.NewRoomButton_Click);
            // 
            // roomGroup1
            // 
            this.roomGroup1.Controls.Add(this.button1);
            this.roomGroup1.Controls.Add(this.label8);
            this.roomGroup1.Controls.Add(this.comboBox8);
            this.roomGroup1.Controls.Add(this.label7);
            this.roomGroup1.Controls.Add(this.comboBox7);
            this.roomGroup1.Controls.Add(this.label6);
            this.roomGroup1.Controls.Add(this.comboBox6);
            this.roomGroup1.Controls.Add(this.label5);
            this.roomGroup1.Controls.Add(this.comboBox5);
            this.roomGroup1.Location = new System.Drawing.Point(11, 331);
            this.roomGroup1.Name = "roomGroup1";
            this.roomGroup1.Size = new System.Drawing.Size(226, 170);
            this.roomGroup1.TabIndex = 2;
            this.roomGroup1.TabStop = false;
            this.roomGroup1.Text = "Room 1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Add New Add-on";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Wall Upgrade";
            // 
            // comboBox8
            // 
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(73, 108);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(121, 21);
            this.comboBox8.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Walls";
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(73, 81);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(121, 21);
            this.comboBox7.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Quality";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(73, 54);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(121, 21);
            this.comboBox6.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Type";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(73, 27);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 21);
            this.comboBox5.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rooms";
            // 
            // wallModsBox
            // 
            this.wallModsBox.Controls.Add(this.aboveGroundCheck);
            this.wallModsBox.Controls.Add(this.articCheck);
            this.wallModsBox.Controls.Add(this.forestCheck);
            this.wallModsBox.Controls.Add(this.mountainCheck);
            this.wallModsBox.Controls.Add(this.fabricateCheck);
            this.wallModsBox.Controls.Add(this.moveEarthCheck);
            this.wallModsBox.Controls.Add(this.plantGrowthCheck);
            this.wallModsBox.Controls.Add(this.stoneShapeCheck);
            this.wallModsBox.Controls.Add(this.underGround);
            this.wallModsBox.Controls.Add(this.wallOForceCheck);
            this.wallModsBox.Controls.Add(this.wallOIceCheck);
            this.wallModsBox.Controls.Add(this.wallOStoneCheck);
            this.wallModsBox.Controls.Add(this.wallOThornsCheck);
            this.wallModsBox.Controls.Add(this.wallOWaterCheck);
            this.wallModsBox.Location = new System.Drawing.Point(46, 325);
            this.wallModsBox.Name = "wallModsBox";
            this.wallModsBox.Size = new System.Drawing.Size(142, 340);
            this.wallModsBox.TabIndex = 8;
            this.wallModsBox.TabStop = false;
            this.wallModsBox.Text = "Wall Cost Modifiers";
            // 
            // aboveGroundCheck
            // 
            this.aboveGroundCheck.AutoSize = true;
            this.aboveGroundCheck.Checked = true;
            this.aboveGroundCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aboveGroundCheck.Location = new System.Drawing.Point(6, 19);
            this.aboveGroundCheck.Name = "aboveGroundCheck";
            this.aboveGroundCheck.Size = new System.Drawing.Size(95, 17);
            this.aboveGroundCheck.TabIndex = 11;
            this.aboveGroundCheck.TabStop = false;
            this.aboveGroundCheck.Text = "Above Ground";
            this.aboveGroundCheck.UseVisualStyleBackColor = true;
            this.aboveGroundCheck.CheckedChanged += new System.EventHandler(this.WallModsUpdated);
            // 
            // articCheck
            // 
            this.articCheck.AutoSize = true;
            this.articCheck.Location = new System.Drawing.Point(6, 42);
            this.articCheck.Name = "articCheck";
            this.articCheck.Size = new System.Drawing.Size(118, 17);
            this.articCheck.TabIndex = 6;
            this.articCheck.TabStop = false;
            this.articCheck.Text = "Environment, Arctic";
            this.articCheck.UseVisualStyleBackColor = true;
            this.articCheck.CheckedChanged += new System.EventHandler(this.WallModsUpdated);
            // 
            // forestCheck
            // 
            this.forestCheck.AutoSize = true;
            this.forestCheck.Location = new System.Drawing.Point(6, 65);
            this.forestCheck.Name = "forestCheck";
            this.forestCheck.Size = new System.Drawing.Size(126, 17);
            this.forestCheck.TabIndex = 12;
            this.forestCheck.TabStop = false;
            this.forestCheck.Text = "Envirvonment, Forest";
            this.forestCheck.UseVisualStyleBackColor = true;
            this.forestCheck.CheckedChanged += new System.EventHandler(this.WallModsUpdated);
            // 
            // mountainCheck
            // 
            this.mountainCheck.AutoSize = true;
            this.mountainCheck.Location = new System.Drawing.Point(6, 88);
            this.mountainCheck.Name = "mountainCheck";
            this.mountainCheck.Size = new System.Drawing.Size(135, 17);
            this.mountainCheck.TabIndex = 9;
            this.mountainCheck.TabStop = false;
            this.mountainCheck.Text = "Environment, Mountain";
            this.mountainCheck.UseVisualStyleBackColor = true;
            this.mountainCheck.CheckedChanged += new System.EventHandler(this.WallModsUpdated);
            // 
            // fabricateCheck
            // 
            this.fabricateCheck.AutoSize = true;
            this.fabricateCheck.Location = new System.Drawing.Point(6, 111);
            this.fabricateCheck.Name = "fabricateCheck";
            this.fabricateCheck.Size = new System.Drawing.Size(70, 17);
            this.fabricateCheck.TabIndex = 0;
            this.fabricateCheck.TabStop = false;
            this.fabricateCheck.Text = "Fabricate";
            this.fabricateCheck.UseVisualStyleBackColor = true;
            this.fabricateCheck.CheckedChanged += new System.EventHandler(this.WallModsUpdated);
            // 
            // moveEarthCheck
            // 
            this.moveEarthCheck.AutoSize = true;
            this.moveEarthCheck.Location = new System.Drawing.Point(6, 134);
            this.moveEarthCheck.Name = "moveEarthCheck";
            this.moveEarthCheck.Size = new System.Drawing.Size(81, 17);
            this.moveEarthCheck.TabIndex = 1;
            this.moveEarthCheck.TabStop = false;
            this.moveEarthCheck.Text = "Move Earth";
            this.moveEarthCheck.UseVisualStyleBackColor = true;
            this.moveEarthCheck.CheckedChanged += new System.EventHandler(this.WallModsUpdated);
            // 
            // plantGrowthCheck
            // 
            this.plantGrowthCheck.AutoSize = true;
            this.plantGrowthCheck.Location = new System.Drawing.Point(6, 157);
            this.plantGrowthCheck.Name = "plantGrowthCheck";
            this.plantGrowthCheck.Size = new System.Drawing.Size(87, 17);
            this.plantGrowthCheck.TabIndex = 7;
            this.plantGrowthCheck.TabStop = false;
            this.plantGrowthCheck.Text = "Plant Growth";
            this.plantGrowthCheck.UseVisualStyleBackColor = true;
            this.plantGrowthCheck.CheckedChanged += new System.EventHandler(this.WallModsUpdated);
            // 
            // stoneShapeCheck
            // 
            this.stoneShapeCheck.AutoSize = true;
            this.stoneShapeCheck.Location = new System.Drawing.Point(6, 180);
            this.stoneShapeCheck.Name = "stoneShapeCheck";
            this.stoneShapeCheck.Size = new System.Drawing.Size(88, 17);
            this.stoneShapeCheck.TabIndex = 5;
            this.stoneShapeCheck.TabStop = false;
            this.stoneShapeCheck.Text = "Stone Shape";
            this.stoneShapeCheck.UseVisualStyleBackColor = true;
            this.stoneShapeCheck.CheckedChanged += new System.EventHandler(this.WallModsUpdated);
            // 
            // underGround
            // 
            this.underGround.AutoSize = true;
            this.underGround.Location = new System.Drawing.Point(6, 203);
            this.underGround.Name = "underGround";
            this.underGround.Size = new System.Drawing.Size(88, 17);
            this.underGround.TabIndex = 2;
            this.underGround.TabStop = false;
            this.underGround.Text = "Underground";
            this.underGround.UseVisualStyleBackColor = true;
            this.underGround.CheckedChanged += new System.EventHandler(this.WallModsUpdated);
            // 
            // wallOForceCheck
            // 
            this.wallOForceCheck.AutoSize = true;
            this.wallOForceCheck.Location = new System.Drawing.Point(6, 226);
            this.wallOForceCheck.Name = "wallOForceCheck";
            this.wallOForceCheck.Size = new System.Drawing.Size(89, 17);
            this.wallOForceCheck.TabIndex = 10;
            this.wallOForceCheck.TabStop = false;
            this.wallOForceCheck.Text = "Wall of Force";
            this.wallOForceCheck.UseVisualStyleBackColor = true;
            this.wallOForceCheck.CheckedChanged += new System.EventHandler(this.WallModsUpdated);
            // 
            // wallOIceCheck
            // 
            this.wallOIceCheck.AutoSize = true;
            this.wallOIceCheck.Location = new System.Drawing.Point(6, 249);
            this.wallOIceCheck.Name = "wallOIceCheck";
            this.wallOIceCheck.Size = new System.Drawing.Size(77, 17);
            this.wallOIceCheck.TabIndex = 13;
            this.wallOIceCheck.TabStop = false;
            this.wallOIceCheck.Text = "Wall of Ice";
            this.wallOIceCheck.UseVisualStyleBackColor = true;
            this.wallOIceCheck.CheckedChanged += new System.EventHandler(this.WallModsUpdated);
            // 
            // wallOStoneCheck
            // 
            this.wallOStoneCheck.AutoSize = true;
            this.wallOStoneCheck.Location = new System.Drawing.Point(6, 272);
            this.wallOStoneCheck.Name = "wallOStoneCheck";
            this.wallOStoneCheck.Size = new System.Drawing.Size(90, 17);
            this.wallOStoneCheck.TabIndex = 8;
            this.wallOStoneCheck.TabStop = false;
            this.wallOStoneCheck.Text = "Wall of Stone";
            this.wallOStoneCheck.UseVisualStyleBackColor = true;
            this.wallOStoneCheck.CheckedChanged += new System.EventHandler(this.WallModsUpdated);
            // 
            // wallOThornsCheck
            // 
            this.wallOThornsCheck.AutoSize = true;
            this.wallOThornsCheck.Location = new System.Drawing.Point(6, 295);
            this.wallOThornsCheck.Name = "wallOThornsCheck";
            this.wallOThornsCheck.Size = new System.Drawing.Size(95, 17);
            this.wallOThornsCheck.TabIndex = 4;
            this.wallOThornsCheck.TabStop = false;
            this.wallOThornsCheck.Text = "Wall of Thorns";
            this.wallOThornsCheck.UseVisualStyleBackColor = true;
            this.wallOThornsCheck.CheckedChanged += new System.EventHandler(this.WallModsUpdated);
            // 
            // wallOWaterCheck
            // 
            this.wallOWaterCheck.AutoSize = true;
            this.wallOWaterCheck.Location = new System.Drawing.Point(6, 318);
            this.wallOWaterCheck.Name = "wallOWaterCheck";
            this.wallOWaterCheck.Size = new System.Drawing.Size(91, 17);
            this.wallOWaterCheck.TabIndex = 3;
            this.wallOWaterCheck.TabStop = false;
            this.wallOWaterCheck.Text = "Wall of Water";
            this.wallOWaterCheck.UseVisualStyleBackColor = true;
            this.wallOWaterCheck.CheckedChanged += new System.EventHandler(this.WallModsUpdated);
            // 
            // addNewWondrousArch
            // 
            this.addNewWondrousArch.AutoSize = true;
            this.addNewWondrousArch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addNewWondrousArch.Location = new System.Drawing.Point(47, 12);
            this.addNewWondrousArch.Name = "addNewWondrousArch";
            this.addNewWondrousArch.Size = new System.Drawing.Size(121, 23);
            this.addNewWondrousArch.TabIndex = 4;
            this.addNewWondrousArch.TabStop = false;
            this.addNewWondrousArch.Text = "Add New Architecture";
            this.addNewWondrousArch.UseVisualStyleBackColor = true;
            this.addNewWondrousArch.Click += new System.EventHandler(this.addNewWondrousArch_Click);
            // 
            // wondrousArchPanel
            // 
            this.wondrousArchPanel.AutoScroll = true;
            this.wondrousArchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wondrousArchPanel.Controls.Add(this.addNewWondrousArch);
            this.wondrousArchPanel.Location = new System.Drawing.Point(519, 32);
            this.wondrousArchPanel.Name = "wondrousArchPanel";
            this.wondrousArchPanel.Size = new System.Drawing.Size(217, 300);
            this.wondrousArchPanel.TabIndex = 11;
            // 
            // wondrousArchitectureLabel
            // 
            this.wondrousArchitectureLabel.AutoSize = true;
            this.wondrousArchitectureLabel.Location = new System.Drawing.Point(525, 27);
            this.wondrousArchitectureLabel.Name = "wondrousArchitectureLabel";
            this.wondrousArchitectureLabel.Size = new System.Drawing.Size(116, 13);
            this.wondrousArchitectureLabel.TabIndex = 11;
            this.wondrousArchitectureLabel.Text = "Wondrous Architecture";
            // 
            // freeStandWallsPanel
            // 
            this.freeStandWallsPanel.AutoScroll = true;
            this.freeStandWallsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.freeStandWallsPanel.Controls.Add(this.newWallSectionButton);
            this.freeStandWallsPanel.Location = new System.Drawing.Point(519, 362);
            this.freeStandWallsPanel.Name = "freeStandWallsPanel";
            this.freeStandWallsPanel.Size = new System.Drawing.Size(217, 303);
            this.freeStandWallsPanel.TabIndex = 12;
            // 
            // newWallSectionButton
            // 
            this.newWallSectionButton.AutoSize = true;
            this.newWallSectionButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.newWallSectionButton.Location = new System.Drawing.Point(58, 12);
            this.newWallSectionButton.Name = "newWallSectionButton";
            this.newWallSectionButton.Size = new System.Drawing.Size(100, 23);
            this.newWallSectionButton.TabIndex = 14;
            this.newWallSectionButton.TabStop = false;
            this.newWallSectionButton.Text = "Add New Section";
            this.newWallSectionButton.UseVisualStyleBackColor = true;
            this.newWallSectionButton.Click += new System.EventHandler(this.newWallSectionButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(525, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Freestanding Walls";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.house";
            this.saveFileDialog.Filter = "Building files|*.house";
            this.saveFileDialog.Title = "Save a house";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.house";
            this.openFileDialog.Filter = "Building files|*.house";
            // 
            // toolBar
            // 
            this.toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileDropDown,
            this.toolStripDropDownButton1});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.toolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolBar.Size = new System.Drawing.Size(757, 25);
            this.toolBar.TabIndex = 21;
            // 
            // fileDropDown
            // 
            this.fileDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openToolStripMenuItem,
            this.calculateToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileDropDown.Name = "fileDropDown";
            this.fileDropDown.ShowDropDownArrow = false;
            this.fileDropDown.Size = new System.Drawing.Size(29, 22);
            this.fileDropDown.Text = "File";
            this.fileDropDown.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openToolStripMenuItem.Click += new System.EventHandler(this.Load_Click);
            // 
            // calculateToolStripMenuItem
            // 
            this.calculateToolStripMenuItem.Name = "calculateToolStripMenuItem";
            this.calculateToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.calculateToolStripMenuItem.Text = "Calculate";
            this.calculateToolStripMenuItem.Click += new System.EventHandler(this.CalculateTotal);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.submitFeedbackToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(36, 22);
            this.toolStripDropDownButton1.Text = "Help";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // submitFeedbackToolStripMenuItem
            // 
            this.submitFeedbackToolStripMenuItem.Name = "submitFeedbackToolStripMenuItem";
            this.submitFeedbackToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.submitFeedbackToolStripMenuItem.Text = "Submit Feedback";
            this.submitFeedbackToolStripMenuItem.Click += new System.EventHandler(this.submitFeedbackToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(757, 677);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.freeStandWallsPanel);
            this.Controls.Add(this.wondrousArchitectureLabel);
            this.Controls.Add(this.wondrousArchPanel);
            this.Controls.Add(this.wallModsBox);
            this.Controls.Add(this.roomPanel);
            this.Controls.Add(this.totalCostGroup);
            this.Controls.Add(this.buildingSizeGroup);
            this.Controls.Add(this.mobilityGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Untitled - Lantern\'s Housing Calculator";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyCombos);
            this.mobilityGroup.ResumeLayout(false);
            this.mobilityGroup.PerformLayout();
            this.buildingSizeGroup.ResumeLayout(false);
            this.buildingSizeGroup.PerformLayout();
            this.totalCostGroup.ResumeLayout(false);
            this.totalCostGroup.PerformLayout();
            this.roomPanel.ResumeLayout(false);
            this.roomPanel.PerformLayout();
            this.roomGroup1.ResumeLayout(false);
            this.roomGroup1.PerformLayout();
            this.wallModsBox.ResumeLayout(false);
            this.wallModsBox.PerformLayout();
            this.wondrousArchPanel.ResumeLayout(false);
            this.wondrousArchPanel.PerformLayout();
            this.freeStandWallsPanel.ResumeLayout(false);
            this.freeStandWallsPanel.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox mobilitySpeedDropDown;
        private System.Windows.Forms.GroupBox mobilityGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox mobilitySpecialDropDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox mobilityTypeDropDown;
        private System.Windows.Forms.TextBox goldCostText;
        private System.Windows.Forms.GroupBox buildingSizeGroup;
        private System.Windows.Forms.GroupBox totalCostGroup;
        private System.Windows.Forms.Panel roomPanel;
        private System.Windows.Forms.GroupBox roomGroup1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox wallModsBox;
        private System.Windows.Forms.CheckBox stoneShapeCheck;
        private System.Windows.Forms.CheckBox wallOThornsCheck;
        private System.Windows.Forms.CheckBox wallOWaterCheck;
        private System.Windows.Forms.CheckBox underGround;
        private System.Windows.Forms.CheckBox moveEarthCheck;
        private System.Windows.Forms.CheckBox fabricateCheck;
        private System.Windows.Forms.Button addNewRoomButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addNewWondrousArch;
        private System.Windows.Forms.Panel wondrousArchPanel;
        private System.Windows.Forms.Label wondrousArchitectureLabel;
        private System.Windows.Forms.Label DTPCostLabel;
        private System.Windows.Forms.TextBox DTPCostText;
        private System.Windows.Forms.Label goldCostLabel;
        private System.Windows.Forms.TextBox buildingSizeText;
        private System.Windows.Forms.Panel freeStandWallsPanel;
        private System.Windows.Forms.Button newWallSectionButton;
        private System.Windows.Forms.CheckBox forestCheck;
        private System.Windows.Forms.CheckBox aboveGroundCheck;
        private System.Windows.Forms.CheckBox wallOForceCheck;
        private System.Windows.Forms.CheckBox mountainCheck;
        private System.Windows.Forms.CheckBox wallOStoneCheck;
        private System.Windows.Forms.CheckBox plantGrowthCheck;
        private System.Windows.Forms.CheckBox articCheck;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox wallOIceCheck;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripDropDownButton fileDropDown;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem submitFeedbackToolStripMenuItem;
    }
}

