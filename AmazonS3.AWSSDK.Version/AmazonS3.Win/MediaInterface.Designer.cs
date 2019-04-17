namespace AmazonS3.Win
{
	partial class MediaInterface
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabReadMedia = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.userMessages = new System.Windows.Forms.GroupBox();
			this.userMessagesList = new System.Windows.Forms.ListBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.profileDataListBox = new System.Windows.Forms.ListBox();
			this.radioButtonUseRole = new System.Windows.Forms.RadioButton();
			this.radioButtonUseKeys = new System.Windows.Forms.RadioButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.lblLoadPictureFromAmazonS3 = new System.Windows.Forms.Label();
			this.amazonLoadedPicture = new System.Windows.Forms.PictureBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lblLoadPictureFromLocal = new System.Windows.Forms.Label();
			this.loadedPictureBox = new System.Windows.Forms.PictureBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.comboTakeXRecords = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboS3PictureList = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnOpenMedia = new System.Windows.Forms.Button();
			this.btnSaveLocalToS3 = new System.Windows.Forms.Button();
			this.tabS3ProfileSelected = new System.Windows.Forms.TabPage();
			this.gridS3ConnectionProfile = new System.Windows.Forms.DataGridView();
			this.radioButtonActiveMode = new System.Windows.Forms.RadioButton();
			this.radioButtonEditMode = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.selectMediaDialog = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.timerRefreshTabData = new System.Windows.Forms.Timer(this.components);
			this.btnDeleteCurrent = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.tabReadMedia.SuspendLayout();
			this.userMessages.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.amazonLoadedPicture)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.loadedPictureBox)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabS3ProfileSelected.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridS3ConnectionProfile)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabReadMedia);
			this.tabControl.Controls.Add(this.tabS3ProfileSelected);
			this.tabControl.Location = new System.Drawing.Point(14, 12);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(1404, 512);
			this.tabControl.TabIndex = 0;
			// 
			// tabReadMedia
			// 
			this.tabReadMedia.Controls.Add(this.label3);
			this.tabReadMedia.Controls.Add(this.userMessages);
			this.tabReadMedia.Controls.Add(this.groupBox5);
			this.tabReadMedia.Controls.Add(this.groupBox4);
			this.tabReadMedia.Controls.Add(this.groupBox3);
			this.tabReadMedia.Controls.Add(this.groupBox2);
			this.tabReadMedia.Controls.Add(this.groupBox1);
			this.tabReadMedia.Location = new System.Drawing.Point(4, 22);
			this.tabReadMedia.Name = "tabReadMedia";
			this.tabReadMedia.Padding = new System.Windows.Forms.Padding(3);
			this.tabReadMedia.Size = new System.Drawing.Size(1396, 486);
			this.tabReadMedia.TabIndex = 0;
			this.tabReadMedia.Text = "Media Maestro";
			this.tabReadMedia.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(25, 454);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(301, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Note: For this demo, it is assumed that all media is of type JPG.";
			// 
			// userMessages
			// 
			this.userMessages.Controls.Add(this.userMessagesList);
			this.userMessages.Location = new System.Drawing.Point(878, 322);
			this.userMessages.Name = "userMessages";
			this.userMessages.Size = new System.Drawing.Size(430, 115);
			this.userMessages.TabIndex = 12;
			this.userMessages.TabStop = false;
			this.userMessages.Text = "User Messages";
			// 
			// userMessagesList
			// 
			this.userMessagesList.FormattingEnabled = true;
			this.userMessagesList.Location = new System.Drawing.Point(17, 20);
			this.userMessagesList.Name = "userMessagesList";
			this.userMessagesList.Size = new System.Drawing.Size(394, 82);
			this.userMessagesList.TabIndex = 0;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.profileDataListBox);
			this.groupBox5.Controls.Add(this.radioButtonUseRole);
			this.groupBox5.Controls.Add(this.radioButtonUseKeys);
			this.groupBox5.Location = new System.Drawing.Point(878, 21);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(430, 281);
			this.groupBox5.TabIndex = 11;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Connection Profile";
			// 
			// profileDataListBox
			// 
			this.profileDataListBox.FormattingEnabled = true;
			this.profileDataListBox.Location = new System.Drawing.Point(17, 50);
			this.profileDataListBox.Name = "profileDataListBox";
			this.profileDataListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.profileDataListBox.Size = new System.Drawing.Size(394, 147);
			this.profileDataListBox.TabIndex = 0;
			// 
			// radioButtonUseRole
			// 
			this.radioButtonUseRole.AutoSize = true;
			this.radioButtonUseRole.Checked = true;
			this.radioButtonUseRole.Location = new System.Drawing.Point(96, 200);
			this.radioButtonUseRole.Name = "radioButtonUseRole";
			this.radioButtonUseRole.Size = new System.Drawing.Size(69, 17);
			this.radioButtonUseRole.TabIndex = 11;
			this.radioButtonUseRole.TabStop = true;
			this.radioButtonUseRole.Text = "Use Role";
			this.radioButtonUseRole.UseVisualStyleBackColor = true;
			this.radioButtonUseRole.CheckedChanged += new System.EventHandler(this.radioButtonUseRole_CheckedChanged);
			// 
			// radioButtonUseKeys
			// 
			this.radioButtonUseKeys.AutoSize = true;
			this.radioButtonUseKeys.Location = new System.Drawing.Point(20, 200);
			this.radioButtonUseKeys.Name = "radioButtonUseKeys";
			this.radioButtonUseKeys.Size = new System.Drawing.Size(70, 17);
			this.radioButtonUseKeys.TabIndex = 10;
			this.radioButtonUseKeys.Text = "Use Keys";
			this.radioButtonUseKeys.UseVisualStyleBackColor = true;
			this.radioButtonUseKeys.CheckedChanged += new System.EventHandler(this.radioButtonUseKeys_CheckedChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.lblLoadPictureFromAmazonS3);
			this.groupBox4.Controls.Add(this.amazonLoadedPicture);
			this.groupBox4.Location = new System.Drawing.Point(456, 21);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(397, 281);
			this.groupBox4.TabIndex = 10;
			this.groupBox4.TabStop = false;
			// 
			// lblLoadPictureFromAmazonS3
			// 
			this.lblLoadPictureFromAmazonS3.AutoSize = true;
			this.lblLoadPictureFromAmazonS3.Location = new System.Drawing.Point(7, 19);
			this.lblLoadPictureFromAmazonS3.Name = "lblLoadPictureFromAmazonS3";
			this.lblLoadPictureFromAmazonS3.Size = new System.Drawing.Size(93, 13);
			this.lblLoadPictureFromAmazonS3.TabIndex = 6;
			this.lblLoadPictureFromAmazonS3.Text = "Waiting for input...";
			// 
			// amazonLoadedPicture
			// 
			this.amazonLoadedPicture.Location = new System.Drawing.Point(6, 50);
			this.amazonLoadedPicture.Name = "amazonLoadedPicture";
			this.amazonLoadedPicture.Size = new System.Drawing.Size(385, 221);
			this.amazonLoadedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.amazonLoadedPicture.TabIndex = 5;
			this.amazonLoadedPicture.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.lblLoadPictureFromLocal);
			this.groupBox3.Controls.Add(this.loadedPictureBox);
			this.groupBox3.Location = new System.Drawing.Point(22, 21);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(415, 281);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			// 
			// lblLoadPictureFromLocal
			// 
			this.lblLoadPictureFromLocal.AutoSize = true;
			this.lblLoadPictureFromLocal.Location = new System.Drawing.Point(7, 20);
			this.lblLoadPictureFromLocal.Name = "lblLoadPictureFromLocal";
			this.lblLoadPictureFromLocal.Size = new System.Drawing.Size(93, 13);
			this.lblLoadPictureFromLocal.TabIndex = 4;
			this.lblLoadPictureFromLocal.Text = "Waiting for input...";
			// 
			// loadedPictureBox
			// 
			this.loadedPictureBox.Location = new System.Drawing.Point(6, 50);
			this.loadedPictureBox.Name = "loadedPictureBox";
			this.loadedPictureBox.Size = new System.Drawing.Size(402, 221);
			this.loadedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.loadedPictureBox.TabIndex = 3;
			this.loadedPictureBox.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnDeleteCurrent);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.comboTakeXRecords);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.comboS3PictureList);
			this.groupBox2.Location = new System.Drawing.Point(262, 322);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(591, 115);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Amazon S3 Media";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(41, 69);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(110, 17);
			this.label4.TabIndex = 16;
			this.label4.Text = "Take X Records";
			// 
			// comboTakeXRecords
			// 
			this.comboTakeXRecords.FormattingEnabled = true;
			this.comboTakeXRecords.Items.AddRange(new object[] {
            "10",
            "25",
            "50",
            "100",
            "500",
            "1000",
            "All"});
			this.comboTakeXRecords.Location = new System.Drawing.Point(157, 65);
			this.comboTakeXRecords.Name = "comboTakeXRecords";
			this.comboTakeXRecords.Size = new System.Drawing.Size(121, 21);
			this.comboTakeXRecords.TabIndex = 15;
			this.comboTakeXRecords.SelectedValueChanged += new System.EventHandler(this.comboTakeXRecords_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(41, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 17);
			this.label2.TabIndex = 14;
			this.label2.Text = "Load From S3";
			// 
			// comboS3PictureList
			// 
			this.comboS3PictureList.FormattingEnabled = true;
			this.comboS3PictureList.Location = new System.Drawing.Point(157, 38);
			this.comboS3PictureList.Name = "comboS3PictureList";
			this.comboS3PictureList.Size = new System.Drawing.Size(428, 21);
			this.comboS3PictureList.TabIndex = 13;
			this.comboS3PictureList.SelectedIndexChanged += new System.EventHandler(this.comboS3PictureList_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnOpenMedia);
			this.groupBox1.Controls.Add(this.btnSaveLocalToS3);
			this.groupBox1.Location = new System.Drawing.Point(22, 322);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(216, 115);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Local Media";
			// 
			// btnOpenMedia
			// 
			this.btnOpenMedia.Location = new System.Drawing.Point(26, 34);
			this.btnOpenMedia.Name = "btnOpenMedia";
			this.btnOpenMedia.Size = new System.Drawing.Size(152, 23);
			this.btnOpenMedia.TabIndex = 2;
			this.btnOpenMedia.Text = "Open Local Media";
			this.btnOpenMedia.UseVisualStyleBackColor = true;
			this.btnOpenMedia.Click += new System.EventHandler(this.btnOpenLocalMedia_Click);
			// 
			// btnSaveLocalToS3
			// 
			this.btnSaveLocalToS3.Location = new System.Drawing.Point(26, 63);
			this.btnSaveLocalToS3.Name = "btnSaveLocalToS3";
			this.btnSaveLocalToS3.Size = new System.Drawing.Size(152, 23);
			this.btnSaveLocalToS3.TabIndex = 12;
			this.btnSaveLocalToS3.Text = "Save Local To S3";
			this.btnSaveLocalToS3.UseVisualStyleBackColor = true;
			this.btnSaveLocalToS3.Click += new System.EventHandler(this.btnSaveLocalToS3_Click);
			// 
			// tabS3ProfileSelected
			// 
			this.tabS3ProfileSelected.Controls.Add(this.gridS3ConnectionProfile);
			this.tabS3ProfileSelected.Controls.Add(this.radioButtonActiveMode);
			this.tabS3ProfileSelected.Controls.Add(this.radioButtonEditMode);
			this.tabS3ProfileSelected.Controls.Add(this.label1);
			this.tabS3ProfileSelected.Location = new System.Drawing.Point(4, 22);
			this.tabS3ProfileSelected.Name = "tabS3ProfileSelected";
			this.tabS3ProfileSelected.Padding = new System.Windows.Forms.Padding(3);
			this.tabS3ProfileSelected.Size = new System.Drawing.Size(1396, 486);
			this.tabS3ProfileSelected.TabIndex = 2;
			this.tabS3ProfileSelected.Text = "Select S3 Profile";
			this.tabS3ProfileSelected.UseVisualStyleBackColor = true;
			// 
			// gridS3ConnectionProfile
			// 
			this.gridS3ConnectionProfile.AllowUserToAddRows = false;
			this.gridS3ConnectionProfile.AllowUserToDeleteRows = false;
			this.gridS3ConnectionProfile.AllowUserToResizeRows = false;
			this.gridS3ConnectionProfile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.gridS3ConnectionProfile.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.gridS3ConnectionProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridS3ConnectionProfile.Location = new System.Drawing.Point(25, 24);
			this.gridS3ConnectionProfile.MultiSelect = false;
			this.gridS3ConnectionProfile.Name = "gridS3ConnectionProfile";
			this.gridS3ConnectionProfile.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.gridS3ConnectionProfile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gridS3ConnectionProfile.Size = new System.Drawing.Size(1351, 334);
			this.gridS3ConnectionProfile.TabIndex = 4;
			this.gridS3ConnectionProfile.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridS3ConnectionProfile_CellClick);
			// 
			// radioButtonActiveMode
			// 
			this.radioButtonActiveMode.AutoSize = true;
			this.radioButtonActiveMode.Checked = true;
			this.radioButtonActiveMode.Location = new System.Drawing.Point(36, 399);
			this.radioButtonActiveMode.Name = "radioButtonActiveMode";
			this.radioButtonActiveMode.Size = new System.Drawing.Size(85, 17);
			this.radioButtonActiveMode.TabIndex = 3;
			this.radioButtonActiveMode.TabStop = true;
			this.radioButtonActiveMode.Text = "Active Mode";
			this.radioButtonActiveMode.UseVisualStyleBackColor = true;
			this.radioButtonActiveMode.CheckedChanged += new System.EventHandler(this.radioButtonActiveMode_CheckedChanged);
			// 
			// radioButtonEditMode
			// 
			this.radioButtonEditMode.AutoSize = true;
			this.radioButtonEditMode.Location = new System.Drawing.Point(130, 399);
			this.radioButtonEditMode.Name = "radioButtonEditMode";
			this.radioButtonEditMode.Size = new System.Drawing.Size(73, 17);
			this.radioButtonEditMode.TabIndex = 2;
			this.radioButtonEditMode.Text = "Edit Mode";
			this.radioButtonEditMode.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 372);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(815, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Note: Data source comes from an XML file in the Data project. Click Edit Mode bef" +
    "ore making changes. Once in Edit Mode, you can change the Active Profile by clic" +
    "king it.";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// timerRefreshTabData
			// 
			this.timerRefreshTabData.Enabled = true;
			this.timerRefreshTabData.Interval = 5000;
			this.timerRefreshTabData.Tick += new System.EventHandler(this.timerRefreshTabData_Tick);
			// 
			// btnDeleteCurrent
			// 
			this.btnDeleteCurrent.Location = new System.Drawing.Point(444, 63);
			this.btnDeleteCurrent.Name = "btnDeleteCurrent";
			this.btnDeleteCurrent.Size = new System.Drawing.Size(141, 23);
			this.btnDeleteCurrent.TabIndex = 17;
			this.btnDeleteCurrent.Text = "Delete Current From S3";
			this.btnDeleteCurrent.UseVisualStyleBackColor = true;
			this.btnDeleteCurrent.Click += new System.EventHandler(this.btnDeleteCurrent_Click);
			// 
			// MediaInterface
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1430, 536);
			this.Controls.Add(this.tabControl);
			this.Name = "MediaInterface";
			this.Text = "MediaInterface";
			this.Load += new System.EventHandler(this.MediaInterface_Load);
			this.tabControl.ResumeLayout(false);
			this.tabReadMedia.ResumeLayout(false);
			this.tabReadMedia.PerformLayout();
			this.userMessages.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.amazonLoadedPicture)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.loadedPictureBox)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.tabS3ProfileSelected.ResumeLayout(false);
			this.tabS3ProfileSelected.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridS3ConnectionProfile)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabReadMedia;
		private System.Windows.Forms.OpenFileDialog selectMediaDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnOpenMedia;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.PictureBox amazonLoadedPicture;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.PictureBox loadedPictureBox;
		private System.Windows.Forms.Button btnSaveLocalToS3;
		private System.Windows.Forms.RadioButton radioButtonUseRole;
		private System.Windows.Forms.RadioButton radioButtonUseKeys;
		private System.Windows.Forms.ComboBox comboS3PictureList;
		private System.Windows.Forms.TabPage tabS3ProfileSelected;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ListBox profileDataListBox;
		private System.Windows.Forms.Timer timerRefreshTabData;
		private System.Windows.Forms.GroupBox userMessages;
		private System.Windows.Forms.ListBox userMessagesList;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblLoadPictureFromAmazonS3;
		private System.Windows.Forms.Label lblLoadPictureFromLocal;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboTakeXRecords;
		private System.Windows.Forms.RadioButton radioButtonEditMode;
		private System.Windows.Forms.RadioButton radioButtonActiveMode;
		private System.Windows.Forms.DataGridView gridS3ConnectionProfile;
		private System.Windows.Forms.Button btnDeleteCurrent;
	}
}