namespace AmazonS3.Entities.Entity
{
	public class S3MediaEntity
	{
		public string Key { get; set; }
		public string ProfileName { get; set; }
		public string BucketName { get; set; }
		public string FolderName { get; set; }

		public override string ToString()
		{
			return $"{Key}";
		}
	}
}
