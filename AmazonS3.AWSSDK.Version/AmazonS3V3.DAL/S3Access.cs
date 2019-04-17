using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using AmazonS3.Entities.Entity;
using Amazon.SecurityToken;
using Amazon.S3;
using Amazon.S3.Model;
using AmazonS3.DALHelpers;
using AmazonS3.DALHelpers.Interfaces;

namespace AmazonS3V3.DAL
{
	public class S3Access:IMediaRequests
	{
		/// <summary>
		/// Gets a list of object Keys when given the specified parameters. Please note that the maximum value of takeXRecords is determined by the bucket setup.
		/// </summary>
		/// <param name="currentConnectionProfile">Contains the profile information driving the type of connection we will use with Amazon S3.</param>
		/// <param name="takeXRecords">Specifies how many records to pull. This might be limited to 1000 records, as set up in the Amazon account.</param>
		/// <returns>A list of entity S3MediaEntity, where the Key is probably the most important data used.</returns>
		public List<S3MediaEntity> GetS3MediaList(S3ConnectionProfileEntity currentConnectionProfile, int takeXRecords)
		{
			try
			{
				var s3Client = GetAmazonS3Client();
				var listObjectsRequest = new ListObjectsRequest
				{
					MaxKeys = takeXRecords,
					BucketName = currentConnectionProfile.BucketName,
					Prefix = currentConnectionProfile.FolderName
				};

				var files = s3Client.ListObjects(listObjectsRequest);
				var mediaList = new List<S3MediaEntity>();

				foreach (var record in files.S3Objects)
				{
					if (record.Key.Contains("_$folder$")) continue;
					var media = new S3MediaEntity()
					{

						ProfileName = currentConnectionProfile.ProfileName,
						BucketName = currentConnectionProfile.BucketName,
						FolderName = currentConnectionProfile.FolderName,
						Key = record.Key
					};
					mediaList.Add(media);
				}

				return mediaList;
			}
			catch (Exception exception)
			{
				throw new SystemException(exception.Message);
			}
		}

		private static IAmazonS3 GetAmazonS3Client()
		{
			var stsClient = new AmazonSecurityTokenServiceClient();
			using (var client = stsClient)
			{
				var token = client.GetSessionToken();
				var stsUser = token.Credentials;
				var s3Client = new AmazonS3Client(stsUser);
				return s3Client;
			}
		}


		public Bitmap GetS3Media(S3ConnectionProfileEntity currentConnectionProfile, S3MediaEntity currentS3MediaSelected)
		{
			try
			{
				var objectResponse = (GetAmazonS3Client()).GetObject(currentConnectionProfile.BucketName, currentS3MediaSelected.Key);
				var bitmap = DataAccessHelper.GetBitmapFromByteArray(S3ObjectToByteArray(objectResponse).ToArray());

				return bitmap;
			}
			catch (Exception exception)
			{
				throw new Exception(exception.Message);
			}
		}

		private static MemoryStream S3ObjectToByteArray(GetObjectResponse objectResponse)
		{
			var msLocalCopy = new MemoryStream();

			var chunk = new byte[32768];
			int nBytesRead;
			do
			{
				nBytesRead = objectResponse.ResponseStream.Read(chunk, 0, chunk.Length);
				msLocalCopy.Write(chunk, 0, nBytesRead);
			} while (nBytesRead > 0);

			objectResponse.ResponseStream.Close();
			return msLocalCopy;
		}

		public string SaveImageToS3(S3ConnectionProfileEntity currentConnectionProfile, S3PictureEntity picture)
		{
			try
			{
				var client = GetAmazonS3Client();

				var stream = DataAccessHelper.GetStream(picture.S3Image, ImageFormat.Jpeg); //We are assuming all JPG for our images

				var key = $"{currentConnectionProfile.FolderName}/{picture.FileName}";
				if (currentConnectionProfile.FolderName.Length == 0) { key = $"{picture.FileName}"; }

				var request = new PutObjectRequest
				{
					BucketName = currentConnectionProfile.BucketName,
					InputStream = stream,
					ContentType = "image/jpeg",
					Key = key,
					CannedACL = S3CannedACL.FindValue(currentConnectionProfile.CannedACL),
					AutoCloseStream = true,
					StorageClass = S3StorageClass.Standard,
				};


				client.PutObject(request);
				return key;
			}
			catch (Exception exception)
			{
				throw new Exception($"Error {exception.Message}");
			}
		}

		public void DeleteS3Media(S3ConnectionProfileEntity currentConnectionProfile, S3MediaEntity currentS3MediaSelected)
		{
			throw new NotImplementedException();
		}
	}
}
