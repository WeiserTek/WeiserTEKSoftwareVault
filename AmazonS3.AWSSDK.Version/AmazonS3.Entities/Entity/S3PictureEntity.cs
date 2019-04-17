using System.Drawing;
using AmazonS3.Entities.Interfaces;

namespace AmazonS3.Entities.Entity
{
	public class S3PictureEntity : IS3MediaBase
	{
		public string FileName{get; set;}

		public string SafeFileName { get; set; }

		public Image S3Image { get; set; }
	}
}
