using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;

namespace AmazonS3.DALHelpers
{
	public static class DataAccessHelper
	{
		public static Bitmap GetBitmapFromByteArray(byte[] byteArray)
		{
			var imageType = (GetImageType(byteArray)).ToUpper();
			if (imageType != "JPG")
			{
				throw new Exception($"Unknown image type found for key.");
			}

			var bitmap = ByteToImage(byteArray);
			return bitmap;
		}

		public static string GetHeaderInfo(byte[] bytes)
		{

			StringBuilder sb = new StringBuilder();
			foreach (byte b in bytes)
				sb.Append(b.ToString("X2"));

			return sb.ToString();
		}
		public static MemoryStream GetStream(Image image, ImageFormat format)
		{
			var memoryStream = new MemoryStream();
			image.Save(memoryStream, format);

			return memoryStream;
		}

		public static DataTable ToDataTable<T>(List<T> items)
		{
			var dataTable = new DataTable(typeof(T).Name);

			//Get all the properties
			var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (var prop in props)
			{
				//Setting column names as Property names
				dataTable.Columns.Add(prop.Name);
			}
			foreach (var item in items)
			{
				var values = new object[props.Length];
				for (var i = 0; i < props.Length; i++)
				{
					values[i] = props[i].GetValue(item, null);
				}
				dataTable.Rows.Add(values);
			}
			return dataTable;
		}

		public static DataTable GetTable<T>(List<T> items)
		{
			return ToDataTable(items);
		}

		public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
		{
			try
			{
				var list = new List<T>();

				foreach (var row in table.AsEnumerable())
				{
					var obj = new T();

					foreach (var prop in obj.GetType().GetProperties())
					{
						try
						{
							var propertyInfo = obj.GetType().GetProperty(prop.Name);
							if (propertyInfo == null) throw new ArgumentNullException(nameof(propertyInfo));
							propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
						}
						catch (Exception exception)
						{
							throw new SystemException(exception.Message);
						}
					}

					list.Add(obj);
				}

				return list;
			}
			catch
			{
				return null;
			}
		}

		public static Bitmap ByteToImage(byte[] blob)
		{
			var mStream = new MemoryStream();
			var pData = blob;
			mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
			var bm = new Bitmap(mStream, false);
			mStream.Dispose();
			return bm;
		}

		public static string GetImageType(Byte[] bytes)
		{
			string headerCode = GetHeaderInfo(bytes);

			if (headerCode.StartsWith("FFD8FFE0"))
			{
				return "JPG";
			}
			else if (headerCode.StartsWith("49492A"))
			{
				return "TIFF";
			}
			else if (headerCode.StartsWith("424D"))
			{
				return "BMP";
			}
			else if (headerCode.StartsWith("474946"))
			{
				return "GIF";
			}
			else if (headerCode.StartsWith("89504E470D0A1A0A"))
			{
				return "PNG";
			}
			else
			{
				return "UNK"; //UnKnown
			}
		}


	}


}

