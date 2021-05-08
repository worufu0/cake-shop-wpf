using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CakeShop
{
	// Toàn cục
	public class Global
	{
		// Dữ liệu
		public static Data data = new Data();
	}

	// Bánh
	public class Cake
	{
		// Số thứ tự
		public int id { get; set; }

		// Tên bánh
		public string cakeName { get; set; }

		// Hình ảnh
		public string image { get; set; }

		// Loại bánh
		public int type { get; set; }

		// Đơn giá.
		public int price { get; set; }

		// Số lượng đã bán.
		public int quantitySold { get; set; }

		// Số lượng còn lại.
		public int quantityLeft { get; set; }
	}

	// Hóa đơn
	public class Bill
	{
		// Tên khách hàng
		public string customerName { get; set; }

		// Danh sách các loại bánh khách hàng mua
		public List<Cake> cakes { get; set; }

		// Ngày mua
		public string date { get; set; }
	}

	// Doanh thu
	public class Revenue
	{
		// Tiêu chí phân loại
		public int criteria { get; set; }

		// Thu nhập
		public int revenue { get; set; }
	}

	// Thông số cài đặt
	public class ParameterSettings
	{
		// Vô hiệu hóa màn hình splash screen
		public bool splashScreenDisabled { get; set; }
	}

	// Toàn bộ dữ liệu chương trình.
	public class Data
	{
		// Thông số cài đặt chương trình
		public ParameterSettings parameterSettings { get; set; }
		// Danh sách loại bánh.
		public List<Cake> cakes { get; set; }
		// Danh sách mẹo.
		public List<string> tips { get; set; }

		// Doanh thu theo tháng
		public List<Revenue> monthRevenue { get; set; }

		// Doanh thu theo loại bánh
		public List<Revenue> cakeTypeRevenue { get; set; }

		/// <summary>
		/// Lưu dữ liệu vào file
		/// </summary>
		/// <param name="obj"> Dữ liệu cần lưu </param>
		/// <param name="fileName"> Đường dẫn file </param>
		public void save(object obj, string fileName)
		{
			XmlSerializer serializer = new XmlSerializer(obj.GetType());
			StreamWriter writer = new StreamWriter(fileName);

			serializer.Serialize(writer, obj);
			writer.Close();
		}

		/// <summary>
		/// Đọc dữ liệu từ file
		/// </summary>
		/// <param name="data"> Kiểu của dữ liệu </param>
		/// <param name="fileName"> Đường dẫn file </param>
		/// <returns> Dữ liệu chương trình </returns>
		public Data load(Data data, string fileName)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Data));
			StreamReader reader = new StreamReader(fileName);

			data = (Data)serializer.Deserialize(reader);
			reader.Close();
			return data;
		}
	}
}
