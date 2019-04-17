using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AmazonS3.DAL;
using AmazonS3.DALHelpers;
using AmazonS3.Entities.Entity;

namespace AmazonS3.BL
{
	public class S3Library
	{
		public static S3PictureEntity GetAPicture()
		{
			S3PictureEntity  s3PictureEntity = new S3PictureEntity();
			
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					//Read the contents of the file into a stream
					var fileStream = openFileDialog.OpenFile();

					s3PictureEntity.S3Image = Image.FromStream(fileStream);
					s3PictureEntity.FileName = openFileDialog.FileName;
					s3PictureEntity.SafeFileName = openFileDialog.SafeFileName;
				}
			}

			return s3PictureEntity;
		}

		public static DataTable GetS3ConnectionProfileTable()
		{
			return DataAccessHelper.GetTable(ConnectionProfileData.GetS3ConnectionProfileList());
		}

		public static void SaveS3ConnectionProfileTable(DataGridView dataGridView)
		{
			ConnectionProfileData.SaveS3ConnectionProfileData(dataGridView);
		}

		public static List<S3ConnectionProfileEntity> GetS3ConnectionProfileList()
		{
			return ConnectionProfileData.GetS3ConnectionProfileList();
		}

		public static S3ConnectionProfileEntity GetCurrentConnectionProfile()
		{
			try
			{
				return ConnectionProfileData.GetCurrentConnectionProfile();
			}
			catch (Exception exception)
			{
				throw new Exception(exception.Message);
			}
		}

		public static List<S3MediaEntity> GetS3MediaList(S3ConnectionProfileEntity currentConnectionProfile,int takeXRecords)
		{
			try
			{
				var data = DataAccess.GetS3MediaList(currentConnectionProfile,takeXRecords);
				return data;
			}
			catch (Exception exception)
			{
				throw new SystemException(exception.Message);
			}
		
		}

		public static Bitmap GetS3Media(S3ConnectionProfileEntity currentConnectionProfile, S3MediaEntity currentS3MediaSelected)
		{
			try
			{
				return DataAccess.GetS3Media(currentConnectionProfile, currentS3MediaSelected);
			}
			catch (Exception exception)
			{
				throw new Exception(exception.Message);
			}

		}

		public static string SaveImageToS3(S3ConnectionProfileEntity currentConnectionProfile, S3PictureEntity picture)
		{
			try
			{
				return DataAccess.SaveImageToS3(currentConnectionProfile, picture);
			}
			catch (Exception exception)
			{
				throw new Exception(exception.Message);
			}
		}

		public static void DeleteS3Media(S3ConnectionProfileEntity currentConnectionProfile, S3MediaEntity currentS3MediaSelected)
		{
			try
			{
				DataAccess.DeleteS3Media(currentConnectionProfile, currentS3MediaSelected);
			}
			catch (Exception exception)
			{
				throw new Exception(exception.Message);
			}
			
		}
	}


}
