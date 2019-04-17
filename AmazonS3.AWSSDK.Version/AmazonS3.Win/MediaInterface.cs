using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static AmazonS3.BL.S3Library;
using System.Linq;
using AmazonS3.BL;
using AmazonS3.Entities.Entity;

namespace AmazonS3.Win
{
	public partial class MediaInterface : Form
	{
		private int _takeXRecords=10;
		public S3ConnectionProfileEntity CurrentConnectionProfile => GetCurrentConnectionProfile();

		public S3MediaEntity CurrentS3MediaSelected { get; set; }

		public string LocalFileName { get; set; }

		public int TakeXRecords
		{
			get { return _takeXRecords; }
			set
			{
				_takeXRecords = value;
				if (_takeXRecords == 0)
				{
					_takeXRecords = 10;
				}
			}
		}

		public MediaInterface()
		{
			InitializeComponent();
		}

		private void LoadImageToPictureBox(PictureBox loadedPicture)
		{
			var picture = GetAPicture();
			if (loadedPicture != null) loadedPicture.Image = picture.S3Image;
			lblLoadPictureFromLocal.Text = $@"{picture.SafeFileName}";
			LocalFileName = picture.SafeFileName;

		}

		private void btnOpenLocalMedia_Click(object sender, EventArgs e)
		{
			LoadImageToPictureBox(loadedPictureBox);
		}

		private void btnSaveLocalToS3_Click(object sender, EventArgs e)
		{
			SaveImageToS3();
			RebindMediaSelectionList();
		}

		private void MediaInterface_Load(object sender, EventArgs e)
		{
			RebindS3ConnectionProfileData();
			RefreshInterfaceTab();
			RebindMediaSelectionList();
		}

		private void RebindMediaSelectionList()
		{
			try
			{
				var s3MediaList = GetS3MediaList(CurrentConnectionProfile,TakeXRecords);
				comboS3PictureList.DataSource = s3MediaList;

				var foundItem = (((comboS3PictureList.Items)).Cast<S3MediaEntity>()).Where(x => x.Key.Contains(LocalFileName)).Take(1);

				// ReSharper disable once PossibleMultipleEnumeration
				if (foundItem.Any())
				{
					// ReSharper disable once PossibleMultipleEnumeration
					var indexNumber = comboS3PictureList.FindString(foundItem.ToList()[0].Key);
					comboS3PictureList.SelectedIndex = indexNumber;
				}

			}
			catch (Exception exception)
			{
				AddUserMessage(exception.Message);
			}
		}

		private void RefreshInterfaceTab()
		{
			RefreshProfileDisplay();
		}

		private void RefreshProfileDisplay()
		{
			ClearMessagesListWhenFull();
			PopulateProfileDataListBox();
			UpdateProfileOptionsRadioButtons();
		}

		private void UpdateProfileOptionsRadioButtons()
		{
			if (CurrentConnectionProfile.KeyBasedAccessFlag)
			{
				radioButtonUseKeys.Checked = true;
			}
			else
			{
				radioButtonUseRole.Checked = true;
			}
		}

		private void PopulateProfileDataListBox()
		{
			profileDataListBox.Items.Clear();
			profileDataListBox.Items.Add($"Id: {CurrentConnectionProfile.Id}");
			profileDataListBox.Items.Add($"Profile Name: {CurrentConnectionProfile.ProfileName}");
			profileDataListBox.Items.Add($"CannedACL: {CurrentConnectionProfile.CannedACL}");
			profileDataListBox.Items.Add($"Region: {CurrentConnectionProfile.Region}");
			profileDataListBox.Items.Add($"Bucket Name: {CurrentConnectionProfile.BucketName}");
			profileDataListBox.Items.Add($"Folder: {CurrentConnectionProfile.FolderName}");
			profileDataListBox.Items.Add($"Key Based: {CurrentConnectionProfile.KeyBasedAccessFlag}");
			profileDataListBox.Items.Add($"Access Key Id: {CurrentConnectionProfile.AccessKeyId}");
			profileDataListBox.Items.Add($"Account Type: {CurrentConnectionProfile.AccountType}");
		}

		private void ClearMessagesListWhenFull()
		{
			var count = userMessagesList.Items.Count - 5; //Keep 5 in list
			for (int x=1;x<=count;x++)
			{ 
				userMessagesList.Items.RemoveAt(0);
			}
		}

		private void RebindS3ConnectionProfileData()
		{
			var source = (GetS3ConnectionProfileList()).OrderBy(s => s.Id).ToList();
			var selectedIndex = source.FindIndex(n => n.SelectedFlag);
			gridS3ConnectionProfile.DataSource = source;
			gridS3ConnectionProfile.ClearSelection();
			gridS3ConnectionProfile.Rows[selectedIndex].Selected = true;
			gridS3ConnectionProfile.CurrentCell = gridS3ConnectionProfile.Rows[selectedIndex].Cells[0];
		}

		private void radioButtonUseRole_CheckedChanged(object sender, EventArgs e)
		{
			RefreshProfileDisplay();
		}

		private void radioButtonUseKeys_CheckedChanged(object sender, EventArgs e)
		{
			RefreshProfileDisplay();
		}

		private void timerRefreshTabData_Tick(object sender, EventArgs e)
		{
			RefreshProfileDisplay();

			if (radioButtonActiveMode.Checked)
			{
				RebindS3ConnectionProfileData();
			}

			SetGridColors();
		}

		private void comboS3PictureList_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateCurrentS3MediaSelected((S3MediaEntity)((ComboBox)sender).SelectedItem);
			UpdateLoadedS3Image(CurrentConnectionProfile, CurrentS3MediaSelected);
		}

		private void UpdateLoadedS3Image(S3ConnectionProfileEntity connectionProfileEntity, S3MediaEntity mediaEntity)
		{
			var s3Media = GetS3Media(connectionProfileEntity, mediaEntity);
			amazonLoadedPicture.Image = s3Media;
		}

		private Bitmap GetS3Media(S3ConnectionProfileEntity currentConnectionProfile, S3MediaEntity currentS3MediaSelected)
		{
			try
			{
				return S3Library.GetS3Media(currentConnectionProfile, currentS3MediaSelected);
			}
			catch (Exception exception)
			{
				AddUserMessage(exception.Message);
				return null;
			}
		}

		private void AddUserMessage(string userMessage)
		{
			userMessagesList.Items.Add(userMessage);
		}

		private void UpdateCurrentS3MediaSelected(S3MediaEntity sender)
		{
			try
			{
				var record = (sender);
				var item = record.Key;
				CurrentS3MediaSelected = record;
				AddUserMessage($"Media file {item} selected");
				lblLoadPictureFromAmazonS3.Text = $@"{record.Key}";
			}
			catch (Exception exception)
			{
				throw new Exception(exception.Message);
			}
		}

		private void SaveImageToS3()
		{
			try
			{
				var picture = new S3PictureEntity
				{
					FileName = lblLoadPictureFromLocal.Text,
					S3Image = loadedPictureBox.Image,
					SafeFileName = lblLoadPictureFromLocal.Text
				};

				var key = S3Library.SaveImageToS3(CurrentConnectionProfile, picture);

				UpdateLoadedS3Image(CurrentConnectionProfile,
					new S3MediaEntity()
					{
						FolderName = CurrentConnectionProfile.FolderName,
						BucketName = CurrentConnectionProfile.BucketName,
						Key = key,
						ProfileName = CurrentConnectionProfile.ProfileName
					});

			}
			catch (Exception exception)
			{
				AddUserMessage(exception.Message);
			}
		}

		private void comboTakeXRecords_SelectedValueChanged(object sender, EventArgs e)
		{
			var selectedItem = ((ComboBox) sender).SelectedItem;
			if (selectedItem.ToString() == "All")
			{
				selectedItem = "9999999";
			}

			TakeXRecords = Convert.ToInt32(selectedItem);
			RebindMediaSelectionList();
		}

		private void radioButtonActiveMode_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonActiveMode.Checked)
			{
				SaveConnectionProfileDataChanges();
			}
			else
			{
				SetProfileSelectionGridToEditMode();
			}
		}

		private void SetProfileSelectionGridToEditMode()
		{
			SetGridColors();
		}

		private void SetGridColors()
		{
			gridS3ConnectionProfile.DefaultCellStyle.SelectionBackColor = radioButtonActiveMode.Checked ? Color.Green : Color.Red;
			gridS3ConnectionProfile.Enabled = !radioButtonActiveMode.Checked;
		}

		private void SaveConnectionProfileDataChanges()
		{
			SaveS3ConnectionProfileTable(gridS3ConnectionProfile);
			RebindMediaSelectionList();
			radioButtonActiveMode.Checked = true;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void gridS3ConnectionProfile_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			SetConnectionProfileDataSelectedFlag(sender);
		}

		private void SetConnectionProfileDataSelectedFlag(object sender)
		{
			var selectedIndex = gridS3ConnectionProfile.SelectedRows[0].Index;

			ClearAllSelectedFlagsInConnectionProfiles(sender);

			var records = (List<S3ConnectionProfileEntity>)(((DataGridView)sender).DataSource);
			records[selectedIndex].SelectedFlag = true;
			gridS3ConnectionProfile.DataSource = records;
			gridS3ConnectionProfile.Refresh();
		}

		private static void ClearAllSelectedFlagsInConnectionProfiles(object sender)
		{
			var records = (List<S3ConnectionProfileEntity>)(((DataGridView)sender).DataSource);
			foreach (var updateRow in records.Where(x => x.SelectedFlag))
			{
				updateRow.SelectedFlag = false;
			}
		}

		private void btnDeleteCurrent_Click(object sender, EventArgs e)
		{
			try
			{
				DeleteS3Media(CurrentConnectionProfile, CurrentS3MediaSelected);
				AddUserMessage($"{CurrentS3MediaSelected.Key} deleted!");
				RebindMediaSelectionList();
			}
			catch (Exception exception)
			{
				AddUserMessage(exception.Message);
			}
			
		}
	}
}

