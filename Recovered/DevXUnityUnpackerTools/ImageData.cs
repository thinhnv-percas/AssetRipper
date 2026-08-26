using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class ImageData : IDisposable
{
	internal class Utils
	{
		internal class Size
		{
			internal int width;

			internal int height;

			internal Size(int width, int height)
			{
				this.width = width;
				this.height = height;
			}
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class SizeGetter
		{
			public static readonly SizeGetter instance;

			public static Func<byte[], int> func;

			static SizeGetter()
			{
				instance = new SizeGetter();
			}

			internal int GetSize(byte[] arr)
			{
				return arr.Length;
			}
		}

		private const string errTxt = "Could not recognise image format.";

		private static Dictionary<byte[], Func<BinaryReader, Size>> sizeGetters;

		internal static Size TryGetImgSizeByPath(string path)
		{
			try
			{
				using (BinaryReader reader = new BinaryReader(File.OpenRead(path)))
				{
					try
					{
						return TryGetImgSize(reader);
					}
					catch (ArgumentException innerException)
					{
						throw new ArgumentException(string.Format("{0} file: '{1}' ", "Could not recognise image format.", path), "path", innerException);
					}
				}
			}
			catch (ArgumentException)
			{
				return new Size(0, 0);
			}
		}

		internal static Size TryGetImgSizeByStream(Stream stream)
		{
			try
			{
				using (BinaryReader reader = new BinaryReader(stream))
				{
					try
					{
						return TryGetImgSize(reader);
					}
					catch (ArgumentException innerException)
					{
						throw new ArgumentException(string.Format("{0} file: '{1}' ", "Could not recognise image format.", ""), "path", innerException);
					}
				}
			}
			catch (ArgumentException)
			{
				return new Size(0, 0);
			}
		}

		internal static Size TryGetImgSize(BinaryReader reader)
		{
			int num = sizeGetters.Keys.OrderByDescending(SizeGetter.instance.GetSize).First().Length;
			byte[] array = new byte[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = reader.ReadByte();
				foreach (KeyValuePair<byte[], Func<BinaryReader, Size>> sizeGetter in sizeGetters)
				{
					if (IsSame(array, sizeGetter.Key))
					{
						return sizeGetter.Value(reader);
					}
				}
			}
			throw new ArgumentException("Could not recognise image format.", "binaryReader");
		}

		private static bool IsSame(byte[] l, byte[] r)
		{
			for (int i = 0; i < r.Length; i++)
			{
				if (l[i] != r[i])
				{
					return false;
				}
			}
			return true;
		}

		private static short ReadInt16(BinaryReader reader)
		{
			byte[] array = new byte[2];
			for (int i = 0; i < 2; i++)
			{
				array[1 - i] = reader.ReadByte();
			}
			return BitConverter.ToInt16(array, 0);
		}

		private static ushort readUint16(BinaryReader reader)
		{
			byte[] array = new byte[2];
			for (int i = 0; i < 2; i++)
			{
				array[1 - i] = reader.ReadByte();
			}
			return BitConverter.ToUInt16(array, 0);
		}

		private static int ReadInt(BinaryReader reader)
		{
			byte[] array = new byte[4];
			for (int i = 0; i < 4; i++)
			{
				array[3 - i] = reader.ReadByte();
			}
			return BitConverter.ToInt32(array, 0);
		}

		private static Size ReadImgSize32(BinaryReader reader)
		{
			reader.ReadBytes(16);
			int width = reader.ReadInt32();
			int height = reader.ReadInt32();
			return new Size(width, height);
		}

		private static Size ReadImgSize16(BinaryReader reader)
		{
			short width = reader.ReadInt16();
			int height = reader.ReadInt16();
			return new Size(width, height);
		}

		private static Size ReadImgSize32_2(BinaryReader reader)
		{
			reader.ReadBytes(8);
			int width = ReadInt(reader);
			int height = ReadInt(reader);
			return new Size(width, height);
		}

		private static Size ReadImgSize(BinaryReader reader)
		{
			while (reader.ReadByte() == byte.MaxValue)
			{
				byte num = reader.ReadByte();
				short num2 = ReadInt16(reader);
				if (num == 192)
				{
					reader.ReadByte();
					int height = ReadInt16(reader);
					return new Size(ReadInt16(reader), height);
				}
				if (num2 < 0)
				{
					ushort num3 = (ushort)num2;
					reader.ReadBytes(num3 - 2);
				}
				else
				{
					reader.ReadBytes(num2 - 2);
				}
			}
			throw new ArgumentException("Could not recognise image format.");
		}

		static Utils()
		{
			sizeGetters = new Dictionary<byte[], Func<BinaryReader, Size>>
			{
				{
					new byte[2]
					{
						66,
						77
					},
					ReadImgSize32
				},
				{
					new byte[6]
					{
						71,
						73,
						70,
						56,
						55,
						97
					},
					ReadImgSize16
				},
				{
					new byte[6]
					{
						71,
						73,
						70,
						56,
						57,
						97
					},
					ReadImgSize16
				},
				{
					new byte[8]
					{
						137,
						80,
						78,
						71,
						13,
						10,
						26,
						10
					},
					ReadImgSize32_2
				},
				{
					new byte[2]
					{
						255,
						216
					},
					ReadImgSize
				}
			};
		}
	}

	internal ARGB_RAW rawARGB;

	internal int Width;

	internal int Height;

	internal string str2;

	internal bool needMirrorY;

	private Bitmap bitmap;

	private string str1Data;

	internal Bitmap Bitmap
	{
		get
		{
			if (bitmap != null)
			{
				return bitmap;
			}
			if (rawARGB != null)
			{
				MakeBitmap(rawARGB);
			}
			return bitmap;
		}
		private set
		{
			bitmap = value;
		}
	}

	internal string str1
	{
		get
		{
			return str1Data;
		}
		set
		{
			str1Data = value;
		}
	}

	internal ImageData()
	{
	}

	internal static ImageData FromBytes(byte[] buff)
	{
		return new ImageData(ARGB_RAW.FromPNG(buff));
	}

	public ImageData ResizeImageKeepMaxDimensions(int max_Width, int max_Height)
	{
		double num = Math.Min((double)max_Width / (double)Width, (double)max_Height / (double)Height);
		int width = (int)Math.Ceiling((double)Width * num);
		int height = (int)Math.Ceiling((double)Height * num);
		return ResizeImage(width, height);
	}

	internal byte[] doJpgThing(float f = 50f)
	{
		return TryGetRawData()?.doJpgThing(f);
	}

	internal byte[] ToPNG()
	{
		return TryGetRawData()?.ToPNG();
	}

	internal ImageData MakeMirroredData()
	{
		ARGB_RAW aRGB_RAW = TryGetRawData().MakeRawCopy();
		aRGB_RAW.MirrorY();
		return new ImageData(aRGB_RAW)
		{
			needMirrorY = !needMirrorY,
			str1 = str1,
			str2 = str2
		};
	}

	internal ImageData GetSubImage(int x, int y, int w, int h, bool needMirrorY = false)
	{
		ARGB_RAW aRGB_RAW = TryGetRawData();
		if (aRGB_RAW != null)
		{
			return new ImageData(aRGB_RAW.GetSubImage(x, y, w, h, needMirrorY))
			{
				str1 = str1,
				str2 = str2
			};
		}
		return null;
	}

	internal void SetSubImage(ImageData img, int x, int y)
	{
		ARGB_RAW aRGB_RAW = TryGetRawData();
		if (aRGB_RAW != null)
		{
			aRGB_RAW.SetSubImage(img.TryGetRawData(), x, y);
			Bitmap = null;
		}
	}

	internal ImageData MakeSthWithImg()
	{
		ARGB_RAW aRGB_RAW = TryGetRawData();
		if (aRGB_RAW != null)
		{
			return new ImageData(aRGB_RAW.MakeSthWithImg())
			{
				str1 = str1,
				str2 = str2
			};
		}
		return null;
	}

	internal ImageData MakeCopy()
	{
		return new ImageData(TryGetRawData().MakeRawCopy())
		{
			str1 = str1,
			str2 = str2
		};
	}

	internal void AddSquares()
	{
		ARGB_RAW aRGB_RAW = TryGetRawData();
		if (aRGB_RAW == null)
		{
			return;
		}
		int num = Height / 16;
		int num2 = Width / 16;
		int num3 = 0;
		for (int i = 0; i < Height; i++)
		{
			num3++;
			if (num3 > num)
			{
				if (num3 <= num * 2)
				{
					continue;
				}
				num3 = 0;
			}
			int num4 = 0;
			for (int j = 0; j < Width; j++)
			{
				num4++;
				if (num4 > num2)
				{
					if (num4 <= num2 * 2)
					{
						continue;
					}
					num4 = 0;
				}
				aRGB_RAW.SetPixelRGBA(j, i, byte.MaxValue, 0, 0, 0);
			}
		}
	}

	internal ImageData(Bitmap img)
	{
		Bitmap = img;
		Width = img.Width;
		Height = img.Height;
	}

	internal ImageData(ARGB_RAW raw)
	{
		if (raw != null)
		{
			rawARGB = raw;
			Width = rawARGB.Width;
			Height = rawARGB.Height;
			str2 = rawARGB.str1;
		}
	}

	private void MakeBitmap(ARGB_RAW raw)
	{
		if (raw != null)
		{
			Width = raw.Width;
			Height = raw.Height;
			str2 = raw.str1;
			if (raw.Width <= 0)
			{
				throw new Exception("ImageEx: raw.Width: " + raw.Width.ToString());
			}
			if (raw.Height <= 0)
			{
				throw new Exception("ImageEx: raw.Height: " + raw.Height.ToString());
			}
			Bitmap bitmap = new Bitmap(raw.Width, raw.Height, PixelFormat.Format32bppArgb);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, raw.Width, raw.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
			IntPtr scan = bitmapData.Scan0;
			Marshal.Copy(raw.texData, 0, scan, Math.Min(raw.Width * raw.Height * 4, raw.texData.Length));
			bitmap.UnlockBits(bitmapData);
			if (raw.needYmirror)
			{
				bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
			}
			Bitmap = bitmap;
		}
	}

	internal ImageData(Stream stream)
	{
		LoadImg(stream);
	}

	internal ImageData(byte[] buff)
	{
		LoadImg(new MemoryStream(buff));
	}

	internal ImageData(string file_name)
	{
		using (Stream stream = FileManager.MakeStream(file_name))
		{
			LoadImg(stream);
		}
	}

	private void LoadImg(Stream stream)
	{
		Bitmap = new Bitmap(stream);
		Width = Bitmap.Width;
		Height = Bitmap.Height;
	}

	internal void MakeFormat32bppArgb()
	{
		if ((rawARGB != null && this.bitmap == null) || Bitmap.PixelFormat == PixelFormat.Format32bppArgb)
		{
			return;
		}
		Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
		for (int i = 0; i < Height; i++)
		{
			for (int j = 0; j < Width; j++)
			{
				Color pixel = Bitmap.GetPixel(j, i);
				bitmap.SetPixel(j, i, pixel);
			}
		}
		Bitmap bitmap2 = this.bitmap;
		this.bitmap = bitmap;
		bitmap2?.Dispose();
	}

	public void DestroryImage()
	{
		bitmap?.Dispose();
		bitmap = null;
	}

	public void Dispose()
	{
	}

	private byte[] MakeDataCopy()
	{
		Rectangle rect = new Rectangle(0, 0, Bitmap.Width, Bitmap.Height);
		BitmapData bitmapData = Bitmap.LockBits(rect, ImageLockMode.ReadWrite, Bitmap.PixelFormat);
		IntPtr scan = bitmapData.Scan0;
		int num = bitmapData.Stride * Bitmap.Height;
		byte[] array = new byte[num];
		Marshal.Copy(scan, array, 0, num);
		Bitmap.UnlockBits(bitmapData);
		return array;
	}

	internal ARGB_RAW TryGetRawData()
	{
		if (rawARGB != null)
		{
			return rawARGB;
		}
		ARGB_RAW aRGB_RAW = new ARGB_RAW(Width, Height);
		aRGB_RAW.str1 = str2;
		if (Bitmap.PixelFormat == PixelFormat.Format32bppArgb)
		{
			aRGB_RAW.texData = MakeDataCopy();
		}
		else if (Bitmap.PixelFormat == PixelFormat.Format24bppRgb)
		{
			byte[] array = MakeDataCopy();
			int num = aRGB_RAW.texData.Length / 4;
			for (int i = 0; i < num; i++)
			{
				aRGB_RAW.texData[i * 4] = array[i * 3];
				aRGB_RAW.texData[i * 4 + 1] = array[i * 3 + 1];
				aRGB_RAW.texData[i * 4 + 2] = array[i * 3 + 2];
				aRGB_RAW.texData[i * 4 + 3] = byte.MaxValue;
			}
		}
		else
		{
			for (int j = 0; j < Height; j++)
			{
				for (int k = 0; k < Width; k++)
				{
					Color pixel = Bitmap.GetPixel(k, j);
					aRGB_RAW.SetPixel(k, j, pixel);
				}
			}
		}
		if (aRGB_RAW.needYmirror)
		{
			aRGB_RAW.MirrorY();
		}
		return aRGB_RAW;
	}

	internal void SetPixel(int x, int y, Color color)
	{
		Bitmap.SetPixel(x, y, color);
	}

	internal Color GetPixel(int x, int y)
	{
		return Bitmap.GetPixel(x, y);
	}

	public ImageData ResizeImage(int width, int height)
	{
		Rectangle destRect = new Rectangle(0, 0, width, height);
		Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
		bitmap.SetResolution(Bitmap.HorizontalResolution, Bitmap.VerticalResolution);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			graphics.CompositingMode = CompositingMode.SourceCopy;
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			using (ImageAttributes imageAttributes = new ImageAttributes())
			{
				imageAttributes.SetWrapMode(WrapMode.TileFlipXY);
				graphics.DrawImage(Bitmap, destRect, 0, 0, Bitmap.Width, Bitmap.Height, GraphicsUnit.Pixel, imageAttributes);
			}
		}
		return new ImageData(bitmap)
		{
			Width = width,
			Height = height,
			str2 = str2,
			str1 = str1
		};
	}
}
