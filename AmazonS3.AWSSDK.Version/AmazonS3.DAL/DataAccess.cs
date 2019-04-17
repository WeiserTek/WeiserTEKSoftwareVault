using System;
using System.Collections.Generic;
using System.Drawing;
using AmazonS3.Entities.Entity;

namespace AmazonS3.DAL
{
	public static class DataAccess
	{
		public static List<S3MediaEntity> GetS3MediaList(S3ConnectionProfileEntity currentConnectionProfile,int takeXRecords)
		{
			try
			{
				if (currentConnectionProfile.KeyBasedAccessFlag)
				{
					return (new AmazonS3V2.DAL.S3Access()).GetS3MediaList(currentConnectionProfile,takeXRecords);
				}
				else
				{
					return (new AmazonS3V3.DAL.S3Access()).GetS3MediaList(currentConnectionProfile,takeXRecords);
				}
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
				if (currentConnectionProfile.KeyBasedAccessFlag)
				{
					return (new AmazonS3V2.DAL.S3Access()).GetS3Media(currentConnectionProfile, currentS3MediaSelected);
				}
				else
				{
					return (new AmazonS3V3.DAL.S3Access()).GetS3Media(currentConnectionProfile, currentS3MediaSelected);
				}

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
				var key = String.Empty;

				if (currentConnectionProfile.KeyBasedAccessFlag)
				{
					key = (new AmazonS3V2.DAL.S3Access()).SaveImageToS3(currentConnectionProfile, picture);
				}
				else
				{
					key = (new AmazonS3V3.DAL.S3Access()).SaveImageToS3(currentConnectionProfile, picture);
				}

				return key;
			}
			catch (Exception exception)
			{
				throw new Exception($"Error {exception.Message}");
			}
		}

		public static void DeleteS3Media(S3ConnectionProfileEntity currentConnectionProfile, S3MediaEntity currentS3MediaSelected)
		{
			try
			{
				if (currentConnectionProfile.KeyBasedAccessFlag)
				{
					(new AmazonS3V2.DAL.S3Access()).DeleteS3Media(currentConnectionProfile, currentS3MediaSelected);
				}
				else
				{
					(new AmazonS3V3.DAL.S3Access()).DeleteS3Media(currentConnectionProfile, currentS3MediaSelected);
				}
			}
			catch (Exception exception)
			{
				throw new Exception($"Error {exception.Message}");
			}

		}
	}
}

