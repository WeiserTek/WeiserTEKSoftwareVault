using System;
using System.Runtime.Serialization;

namespace AmazonS3.Entities.Entity
{
	[Serializable()]
	public class S3ConnectionProfileEntity:ISerializable
	{
		public string Id { get; set; }
		public string ProfileName { get; set; }

		// ReSharper disable once InconsistentNaming
		public string CannedACL;
		public string BucketName { get; set; }
		public string AccessKeyId { get; set; }
		public string SecretAccessKey { get; set; }
		public string AccountNumber { get; set; }
		public string AccountType { get; set; }
		public bool KeyBasedAccessFlag { get; set; }
		public bool SelectedFlag { get; set; }
		public string Region { get; set; }
		public string FolderName { get; set; }

		//Parameter-less Constructor required for serialization
		public S3ConnectionProfileEntity() { }

		public S3ConnectionProfileEntity
		(
			string id = null,
			string profileName = null,
			// ReSharper disable once InconsistentNaming
			string cannedACL = null,
			string region = null,
			string bucketName = null,
			string folderName = null,
			string accessKeyId = null,
			string secretAccessKey = null,
			string accountNumber = null,
			string accountType = null,
			bool keyBasedAccessFlag = false,
			bool selectedFlag = false
		)
		{
			Id = id;
			ProfileName = profileName;
			CannedACL = cannedACL;
			BucketName = bucketName;
			FolderName = folderName;
			Region = region;
			AccessKeyId = accessKeyId;
			SecretAccessKey = secretAccessKey;
			AccountNumber = accountNumber;
			AccountType = accountType;
			KeyBasedAccessFlag = keyBasedAccessFlag;
			SelectedFlag = selectedFlag;
		}

		public override string ToString()
		{
			return $"ProfileName: {ProfileName}";
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Id",Id);
			info.AddValue("ProfileName", ProfileName);
			info.AddValue("CannedACL", CannedACL);
			info.AddValue("BucketName", BucketName);
			info.AddValue("FolderName",FolderName);
			info.AddValue("Region", Region);
			info.AddValue("AccessKeyId", AccessKeyId);
			info.AddValue("SecretAccessKey", SecretAccessKey);
			info.AddValue("AccountNumber", AccountNumber);
			info.AddValue("AccountType", AccountType);
			info.AddValue("KeyBasedAccessFlag", KeyBasedAccessFlag);
			info.AddValue("SelectedFlag", SelectedFlag);
		}

		public S3ConnectionProfileEntity(SerializationInfo info, StreamingContext context)
		{
			Id = (string) info.GetValue("Id", typeof(string));
			ProfileName = (string)info.GetValue("ProfileName", typeof(string));
			CannedACL = (string)info.GetValue("CannedACL", typeof(string));
			BucketName = (string)info.GetValue("BucketName", typeof(string));
			FolderName = (string) info.GetValue("FolderName", typeof(string));
			Region = (string) info.GetValue("Region", typeof(string));
			AccessKeyId = (string)info.GetValue("AccessKeyId", typeof(string));
			SecretAccessKey = (string)info.GetValue("SecretAccessKey", typeof(string));
			AccountNumber = (string)info.GetValue("AccountNumber", typeof(string));
			AccountType = (string)info.GetValue("AccountType", typeof(string));
			KeyBasedAccessFlag = (bool)info.GetValue("KeyBasedAccessFlag", typeof(bool));
			SelectedFlag = (bool)info.GetValue("SelectedFlag", typeof(bool));
		}

	}
}
