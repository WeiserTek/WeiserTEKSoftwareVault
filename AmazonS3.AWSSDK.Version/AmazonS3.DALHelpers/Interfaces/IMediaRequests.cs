using System.Collections.Generic;
using System.Drawing;
using AmazonS3.Entities.Entity;

namespace AmazonS3.DALHelpers.Interfaces
{
	public interface IMediaRequests
	{
		List<S3MediaEntity> GetS3MediaList(S3ConnectionProfileEntity currentConnectionProfile,int topNumber);
		Bitmap GetS3Media(S3ConnectionProfileEntity currentConnectionProfile, S3MediaEntity currentS3MediaSelected);
		string SaveImageToS3(S3ConnectionProfileEntity currentConnectionProfile, S3PictureEntity picture);
		void DeleteS3Media(S3ConnectionProfileEntity currentConnectionProfile, S3MediaEntity currentS3MediaSelected);
	}
}
