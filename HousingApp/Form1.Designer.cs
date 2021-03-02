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
            this.buildingSizeDropDown = new System.Windows.Forms.ComboBox();
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.mobilityGroup.SuspendLayout();
            this.buildingSizeGroup.SuspendLayout();
            this.totalCostGroup.SuspendLayout();
            this.roomPanel.SuspendLayout();
            this.roomGroup1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
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
            this.mobilitySpeedDropDown.Location = new System.Drawing.Point(72, 19);
            this.mobilitySpeedDropDown.Name = "mobilitySpeedDropDown";
            this.mobilitySpeedDropDown.Size = new System.Drawing.Size(121, 21);
            this.mobilitySpeedDropDown.TabIndex = 0;
            // 
            // mobilityGroup
            // 
            this.mobilityGroup.Controls.Add(this.label3);
            this.mobilityGroup.Controls.Add(this.mobilitySpecialDropDown);
            this.mobilityGroup.Controls.Add(this.label2);
            this.mobilityGroup.Controls.Add(this.mobilityTypeDropDown);
            this.mobilityGroup.Controls.Add(this.label1);
            this.mobilityGroup.Controls.Add(this.mobilitySpeedDropDown);
            this.mobilityGroup.Location = new System.Drawing.Point(32, 185);
            this.mobilityGroup.Name = "mobilityGroup";
            this.mobilityGroup.Size = new System.Drawing.Size(211, 109);
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
            this.mobilitySpecialDropDown.Items.AddRange(new object[] {
            "None",
            "Astral",
            "Ethereal",
            "Plane Linked",
            "Plane Shifting",
            "Teleporting"});
            this.mobilitySpecialDropDown.Location = new System.Drawing.Point(72, 73);
            this.mobilitySpecialDropDown.Name = "mobilitySpecialDropDown";
            this.mobilitySpecialDropDown.Size = new System.Drawing.Size(121, 21);
            this.mobilitySpecialDropDown.TabIndex = 4;
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
            this.mobilityTypeDropDown.Location = new System.Drawing.Point(72, 46);
            this.mobilityTypeDropDown.Name = "mobilityTypeDropDown";
            this.mobilityTypeDropDown.Size = new System.Drawing.Size(121, 21);
            this.mobilityTypeDropDown.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
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
            this.goldCostText.TabIndex = 3;
            // 
            // buildingSizeGroup
            // 
            this.buildingSizeGroup.Controls.Add(this.buildingSizeDropDown);
            this.buildingSizeGroup.Location = new System.Drawing.Point(32, 106);
            this.buildingSizeGroup.Name = "buildingSizeGroup";
            this.buildingSizeGroup.Size = new System.Drawing.Size(133, 51);
            this.buildingSizeGroup.TabIndex = 4;
            this.buildingSizeGroup.TabStop = false;
            this.buildingSizeGroup.Text = "Building Size";
            // 
            // buildingSizeDropDown
            // 
            this.buildingSizeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buildingSizeDropDown.Enabled = false;
            this.buildingSizeDropDown.FormattingEnabled = true;
            this.buildingSizeDropDown.Items.AddRange(new object[] {
            "Cottage",
            "Simple House",
            "Grand House",
            "Mansion",
            "Galder\'s Tower",
            "Keep",
            "Castle",
            "Mighty Fortress",
            "Daern\'s Instant Fortress",
            "Huge Castle",
            "Small Dungeon",
            "Medium Dungeon",
            "Large Dungeon"});
            this.buildingSizeDropDown.Location = new System.Drawing.Point(6, 19);
            this.buildingSizeDropDown.Name = "buildingSizeDropDown";
            this.buildingSizeDropDown.Size = new System.Drawing.Size(121, 21);
            this.buildingSizeDropDown.TabIndex = 6;
            // 
            // totalCostGroup
            // 
            this.totalCostGroup.Controls.Add(this.DTPCostLabel);
            this.totalCostGroup.Controls.Add(this.DTPCostText);
            this.totalCostGroup.Controls.Add(this.goldCostLabel);
            this.totalCostGroup.Controls.Add(this.goldCostText);
            this.totalCostGroup.Location = new System.Drawing.Point(32, 21);
            this.totalCostGroup.Name = "totalCostGroup";
            this.totalCostGroup.Size = new System.Drawing.Size(169, 79);
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
            this.roomPanel.Location = new System.Drawing.Point(298, 24);
            this.roomPanel.Name = "roomPanel";
            this.roomPanel.Size = new System.Drawing.Size(250, 637);
            this.roomPanel.TabIndex = 6;
            // 
            // addNewRoomButton
            // 
            this.addNewRoomButton.AutoSize = true;
            this.addNewRoomButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addNewRoomButton.Location = new System.Drawing.Point(79, 12);
            this.addNewRoomButton.Name = "addNewRoomButton";
            this.addNewRoomButton.Size = new System.Drawing.Size(92, 23);
            this.addNewRoomButton.TabIndex = 3;
            this.addNewRoomButton.Text = "Add New Room";
            this.addNewRoomButton.UseVisualStyleBackColor = true;
            this.addNewRoomButton.Click += new System.EventHandler(this.newRoomButton_Click);
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
            this.label4.Location = new System.Drawing.Point(301, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rooms";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox5);
            this.groupBox5.Controls.Add(this.checkBox6);
            this.groupBox5.Controls.Add(this.checkBox3);
            this.groupBox5.Controls.Add(this.checkBox4);
            this.groupBox5.Controls.Add(this.checkBox2);
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Location = new System.Drawing.Point(32, 314);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(142, 351);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Access to Cost Modifiers";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(9, 148);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(88, 17);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Text = "Stone Shape";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(9, 125);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(95, 17);
            this.checkBox6.TabIndex = 4;
            this.checkBox6.Text = "Wall of Thorns";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(9, 102);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(91, 17);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "Wall of Water";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(9, 79);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(88, 17);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "Underground";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(9, 56);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(81, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Move Earth";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Fabricate";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox9
            // 
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Location = new System.Drawing.Point(63, 23);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(121, 21);
            this.comboBox9.TabIndex = 9;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 23);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(35, 20);
            this.numericUpDown1.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(42, 55);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Add New";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.comboBox9);
            this.panel2.Location = new System.Drawing.Point(585, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 298);
            this.panel2.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(591, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Wonderous Architecture";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button4);
            this.groupBox6.Controls.Add(this.numericUpDown2);
            this.groupBox6.Controls.Add(this.comboBox10);
            this.groupBox6.Location = new System.Drawing.Point(585, 356);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 309);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Freestanding Walls";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(43, 60);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Add New Section";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(14, 23);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(35, 20);
            this.numericUpDown2.TabIndex = 13;
            // 
            // comboBox10
            // 
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.Location = new System.Drawing.Point(65, 23);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(121, 21);
            this.comboBox10.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 677);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.roomPanel);
            this.Controls.Add(this.totalCostGroup);
            this.Controls.Add(this.buildingSizeGroup);
            this.Controls.Add(this.mobilityGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Lantern\'s Housing Calculator";
            this.mobilityGroup.ResumeLayout(false);
            this.mobilityGroup.PerformLayout();
            this.buildingSizeGroup.ResumeLayout(false);
            this.totalCostGroup.ResumeLayout(false);
            this.totalCostGroup.PerformLayout();
            this.roomPanel.ResumeLayout(false);
            this.roomPanel.PerformLayout();
            this.roomGroup1.ResumeLayout(false);
            this.roomGroup1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
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
        private System.Windows.Forms.ComboBox buildingSizeDropDown;
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
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button addNewRoomButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.ComboBox comboBox10;
        private System.Windows.Forms.Label DTPCostLabel;
        private System.Windows.Forms.TextBox DTPCostText;
        private System.Windows.Forms.Label goldCostLabel;
    }
}

