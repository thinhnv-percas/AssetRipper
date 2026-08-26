using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

public class ImageTools
{
	public static int Jpeg_Default_Image_Quality = 90;

	public static int Jpeg_Default_ImagePreview_Quality = 15;

	private static EncoderParameters _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A;

	private static ImageCodecInfo _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020;

	private static char[] _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A = new char[16]
	{
		'0',
		'1',
		'2',
		'3',
		'4',
		'5',
		'6',
		'7',
		'8',
		'9',
		'A',
		'B',
		'C',
		'D',
		'E',
		'F'
	};

	public static Image ScaleImage(int width, int height, Image image)
	{
		return ScaleImage(width, height, image, Color.White);
	}

	public static Image ScaleImage(int width, int height, Image image, Color back_color)
	{
		if (image == null)
		{
			return null;
		}
		try
		{
			Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Clear(back_color);
			graphics.InterpolationMode = InterpolationMode.Bicubic;
			int width2 = image.Width;
			int height2 = image.Height;
			if (image.Width > image.Height)
			{
				width2 = width;
				height2 = width2 * image.Height / image.Width;
			}
			else
			{
				height2 = height;
				width2 = height2 * image.Width / image.Height;
			}
			graphics.DrawImage(image, new Rectangle((width - width2) / 2, (height - height2) / 2, width2, height2), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
			graphics.Dispose();
			return bitmap;
		}
		catch
		{
			return null;
		}
	}

	public static Bitmap ScaleImageWithProportion(int width, int height, Image image)
	{
		if (image == null)
		{
			return null;
		}
		try
		{
			int width2 = image.Width;
			int height2 = image.Height;
			if (image.Width > image.Height)
			{
				width2 = width;
				height2 = width2 * image.Height / image.Width;
				if (height2 > height)
				{
					width2 = width2 * height / height2;
					height2 = height;
				}
			}
			else
			{
				height2 = height;
				width2 = height2 * image.Width / image.Height;
				if (width2 > width)
				{
					height2 = height2 * width / width2;
					width2 = width;
				}
			}
			Bitmap bitmap = new Bitmap(width2, height2, PixelFormat.Format24bppRgb);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(Color.White);
				graphics.InterpolationMode = InterpolationMode.Bicubic;
				graphics.DrawImage(image, new Rectangle(0, 0, width2, height2), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
			}
			return bitmap;
		}
		catch
		{
			return null;
		}
	}

	public static byte[] GetImageBytesWithJpegQuality(Image image, int level)
	{
		if (image == null)
		{
			return null;
		}
		try
		{
			if (_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A == null)
			{
				_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020 = null;
				ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
				foreach (ImageCodecInfo imageCodecInfo in imageEncoders)
				{
					if (imageCodecInfo.MimeType.ToLower() == "image/jpeg")
					{
						_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020 = imageCodecInfo;
						break;
					}
				}
				EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, level);
				_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A = new EncoderParameters(1);
				_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A.Param[0] = encoderParameter;
			}
			MemoryStream memoryStream = new MemoryStream();
			image.Save(memoryStream, _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020, _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A);
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			return result;
		}
		catch
		{
		}
		try
		{
			MemoryStream memoryStream2 = new MemoryStream();
			image.Save(memoryStream2, ImageFormat.Jpeg);
			byte[] result2 = memoryStream2.ToArray();
			memoryStream2.Close();
			return result2;
		}
		catch
		{
		}
		try
		{
			MemoryStream memoryStream3 = new MemoryStream();
			image.Save(memoryStream3, ImageFormat.Gif);
			byte[] result3 = memoryStream3.ToArray();
			memoryStream3.Close();
			return result3;
		}
		catch
		{
		}
		try
		{
			MemoryStream memoryStream4 = new MemoryStream();
			image.Save(memoryStream4, ImageFormat.Bmp);
			byte[] result4 = memoryStream4.ToArray();
			memoryStream4.Close();
			return result4;
		}
		catch
		{
		}
		return null;
	}

	public static Image GetImageWithOutAplha(Image image, Color back_color)
	{
		if (image == null)
		{
			return null;
		}
		try
		{
			Bitmap bitmap = new Bitmap(image.Size.Width, image.Size.Height, PixelFormat.Format24bppRgb);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Clear(back_color);
			graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			graphics.DrawImage(image, new Rectangle(0, 0, image.Size.Width, image.Size.Height), new Rectangle(0, 0, image.Size.Width, image.Size.Height), GraphicsUnit.Pixel);
			graphics.Dispose();
			return bitmap;
		}
		catch
		{
			return null;
		}
	}

	public static Image GetVerticalGradientImage(int height, Color top_color, Color bottom_color)
	{
		if (height <= 0)
		{
			return null;
		}
		try
		{
			Image image = new Bitmap(1, height, PixelFormat.Format24bppRgb);
			Graphics graphics = Graphics.FromImage(image);
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			using (LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, 1, height), top_color, bottom_color, LinearGradientMode.Vertical))
			{
				graphics.FillRectangle(brush, 0, 0, 1, height);
			}
			graphics.Dispose();
			return image;
		}
		catch
		{
			return null;
		}
	}

	public static byte[] GetImageBytes(Image img)
	{
		MemoryStream memoryStream = new MemoryStream();
		img.Save(memoryStream, ImageFormat.Bmp);
		byte[] result = memoryStream.ToArray();
		memoryStream.Close();
		return result;
	}

	public static Image GetImageByBytes(byte[] buff)
	{
		Image result = null;
		try
		{
			using (MemoryStream memoryStream = new MemoryStream(buff))
			{
				result = Image.FromStream(memoryStream);
				memoryStream.Close();
			}
			return result;
		}
		catch
		{
		}
		return null;
	}

	public static Bitmap GetBitmap_ByBytes(byte[] buff)
	{
		if (buff == null)
		{
			return null;
		}
		MemoryStream memoryStream = new MemoryStream(buff);
		Bitmap bitmap = new Bitmap(memoryStream);
		Bitmap bitmap2 = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format24bppRgb);
		Graphics graphics = Graphics.FromImage(bitmap2);
		int width = bitmap.Width;
		int height = bitmap.Height;
		graphics.DrawImage(bitmap, new Rectangle(0, 0, width, height), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
		graphics.Dispose();
		bitmap.Dispose();
		memoryStream.Close();
		return bitmap2;
	}

	public static byte[] GetImageBytesAsBmp(Image img)
	{
		if (img == null)
		{
			return null;
		}
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			ScaleImage(img.Width, img.Height, img).Save(memoryStream, ImageFormat.Bmp);
			byte[] array = new byte[memoryStream.Length];
			memoryStream.Seek(0L, SeekOrigin.Begin);
			memoryStream.Read(array, 0, (int)memoryStream.Length);
			memoryStream.Close();
			return array;
		}
		catch
		{
		}
		return null;
	}

	public static string CovertToRTF(Image img)
	{
		try
		{
			byte[] imageBytesAsBmp = GetImageBytesAsBmp(img);
			int num = 15 * img.Width;
			int num2 = 15 * img.Height;
			return "{\\pict\\picwgoal" + num.ToString() + "\\pichgoal" + num2.ToString() + "\\wmetafile8 " + ToHexString(imageBytesAsBmp) + "}";
		}
		catch
		{
		}
		return null;
	}

	public static string ToHexString(byte[] bytes)
	{
		char[] array = new char[bytes.Length * 2];
		for (int i = 0; i < bytes.Length; i++)
		{
			int num = bytes[i];
			array[i * 2] = _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A[num >> 4];
			array[i * 2 + 1] = _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A[num & 0xF];
		}
		return new string(array);
	}
}
