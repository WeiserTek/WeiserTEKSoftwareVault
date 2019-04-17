using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using AmazonS3.Entities.Entity;

namespace AmazonS3.DALHelpers
{
	public class ConnectionProfileData
	{
		public static string S3ConnectionProfileXmlFilename => ConfigurationManager.AppSettings["S3ConnectionProfileXMLFilename"];
		public static string S3ConnectionProfileXmlTempFilename => ConfigurationManager.AppSettings["S3ConnectionProfileXMLTempFilename"];

		public static List<S3ConnectionProfileEntity> GetS3ConnectionProfileList()
		{
			List<S3ConnectionProfileEntity> connectionProfileEntityList;
			var serializer = new XmlSerializer(typeof(List<S3ConnectionProfileEntity>));
			using (var fileStream = File.OpenRead(S3ConnectionProfileXmlFilename))
			{
				connectionProfileEntityList = (List<S3ConnectionProfileEntity>)serializer.Deserialize(fileStream);
			}

			return connectionProfileEntityList;
		}


		public static void SaveS3ConnectionProfileData(DataGridView dataGridView)
		{
			//var newTable = (DataTable)dataSource.DataSource;
			var list = new List<S3ConnectionProfileEntity>();

			try
			{
				//list = newTable.DataTableToList<S3ConnectionProfileEntity>();
				list = (List<S3ConnectionProfileEntity>)dataGridView.DataSource;

			}
			catch (Exception exception)
			{
				Console.WriteLine("Write Fail:{0}", exception.Message);
			}
			finally
			{
				SaveS3ConnectionProfileData(list);

			}
		}

		public static void SaveS3ConnectionProfileData(List<S3ConnectionProfileEntity> list)
		{
			try
			{
				using (Stream fs = new FileStream(S3ConnectionProfileXmlTempFilename, FileMode.Create, FileAccess.Write, FileShare.None))
				{
					var serializer2 = new XmlSerializer(typeof(List<S3ConnectionProfileEntity>));
					serializer2.Serialize(fs, list);
				}

				if (S3ConnectionProfileXmlTempFilename.Length != 0)
				{
					File.Copy(S3ConnectionProfileXmlTempFilename, S3ConnectionProfileXmlFilename, true);
					File.Delete(S3ConnectionProfileXmlTempFilename);
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine("Write Fail:{0}", exception.Message);
			}
		}

		public static S3ConnectionProfileEntity GetCurrentConnectionProfile()
		{
			var profileList = GetS3ConnectionProfileList();
			var entity = ((profileList).Where(t => t.SelectedFlag)).ToList()[0];
			return entity;
		}
	}
}
