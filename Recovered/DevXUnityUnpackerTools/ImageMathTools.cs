using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

public class ImageMathTools
{
	public class FastBitmap
	{
		public struct PixelData
		{
			public byte blue;

			public byte green;

			public byte red;

			public byte alpha;
		}

		private Bitmap _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020;

		private int _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A;

		private BitmapData _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020;

		private unsafe byte* _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A = null;

		private bool _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020;

		private int _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A;

		public Bitmap Bitmap => _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020;

		public unsafe FastBitmap(Bitmap SubjectBitmap, int bits)
		{
			_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020 = SubjectBitmap;
			_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A = bits;
		}

		public void Release()
		{
			try
			{
				_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public unsafe void SetPixel(int X, int Y, Color Colour)
		{
			try
			{
				PixelData* intPtr = _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020(X, Y);
				intPtr->red = Colour.R;
				intPtr->green = Colour.G;
				intPtr->blue = Colour.B;
				intPtr->alpha = Colour.A;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public unsafe Color GetPixel(int X, int Y)
		{
			try
			{
				PixelData* ptr = _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020(X, Y);
				return Color.FromArgb(ptr->alpha, ptr->red, ptr->green, ptr->blue);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Width()
		{
			return _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020.Width;
		}

		public int Height()
		{
			return _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020.Height;
		}

		public bool IsLocked()
		{
			return _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020;
		}

		public BitmapData Data()
		{
			return _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020;
		}

		public unsafe void LockBits()
		{
			if (!_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020)
			{
				try
				{
					GraphicsUnit pageUnit = GraphicsUnit.Pixel;
					RectangleF bounds = _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020.GetBounds(ref pageUnit);
					Rectangle rect = new Rectangle((int)bounds.X, (int)bounds.Y, (int)bounds.Width, (int)bounds.Height);
					_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A = (int)bounds.Width * sizeof(PixelData);
					if (_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A % _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A != 0)
					{
						_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A = _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A * (_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A / _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A + 1);
					}
					if (_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A == 3)
					{
						_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 = _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
					}
					else
					{
						_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 = _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
					}
					_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A = (byte*)_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020.Scan0.ToPointer();
				}
				finally
				{
					_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020 = true;
				}
			}
		}

		private unsafe PixelData* _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020(int _0020, int _0020_000A)
		{
			return (PixelData*)(_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A + _0020_000A * _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A + _0020 * sizeof(PixelData));
		}

		private unsafe void _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A()
		{
			if (_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 != null)
			{
				_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020.UnlockBits(_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020);
				_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 = null;
				_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A = null;
				_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020 = false;
			}
		}
	}

	public static Bitmap GetImageTrace(Bitmap image)
	{
		return GetImage_Контрастность(image, 1.5f);
	}

	public static Bitmap GetImageProtector(Bitmap image)
	{
		return GetImage_Контрастность(image, 1.2f);
	}

	public static Bitmap GetImage_SetAplha0xFF(Bitmap image)
	{
		if (image == null)
		{
			return null;
		}
		try
		{
			FastBitmap fastBitmap = new FastBitmap(image, 4);
			int[] array = new int[fastBitmap.Width() * fastBitmap.Height()];
			fastBitmap.LockBits();
			Marshal.Copy(fastBitmap.Data().Scan0, array, 0, array.Length);
			fastBitmap.Release();
			fastBitmap.Width();
			fastBitmap.Height();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] |= -16777216;
			}
			fastBitmap.LockBits();
			Marshal.Copy(array, 0, fastBitmap.Data().Scan0, array.Length);
			fastBitmap.Release();
			return image;
		}
		catch
		{
			return null;
		}
	}

	public static Bitmap GetImage_Контрастность(Bitmap image, float degree)
	{
		if (image == null)
		{
			return null;
		}
		try
		{
			FastBitmap fastBitmap = new FastBitmap(image, 4);
			int[] array = new int[fastBitmap.Width() * fastBitmap.Height()];
			fastBitmap.LockBits();
			Marshal.Copy(fastBitmap.Data().Scan0, array, 0, array.Length);
			fastBitmap.Release();
			fastBitmap.Width();
			fastBitmap.Height();
			int num = 0;
			for (int i = 0; i < array.Length; i++)
			{
				int num2 = array[i];
				int num3 = num2 & 0xFF;
				int num4 = (num2 >> 8) & 0xFF;
				int num5 = (num2 >> 16) & 0xFF;
				if (num3 < num4)
				{
					num3 = num4;
				}
				if (num3 < num5)
				{
					num3 = num5;
				}
				num += num3;
				array[i] = num3;
			}
			num /= array.Length;
			for (int j = 0; j < array.Length; j++)
			{
				int num6 = array[j];
				num6 = ((num6 > num) ? (255 - (int)((255f - (float)num6) / degree)) : ((int)((float)num6 / degree)));
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num6 > 255)
				{
					num6 = 255;
				}
				array[j] = ((num6 << 16) | (num6 << 8) | num6);
			}
			fastBitmap.LockBits();
			Marshal.Copy(array, 0, fastBitmap.Data().Scan0, array.Length);
			fastBitmap.Release();
			return image;
		}
		catch
		{
			return null;
		}
	}

	public static Image GetImage_Выделение_Границы(Image image)
	{
		if (image == null)
		{
			return null;
		}
		try
		{
			FastBitmap fastBitmap = new FastBitmap(new Bitmap(image), 4);
			int[] array = new int[fastBitmap.Width() * fastBitmap.Height()];
			int[] array2 = new int[fastBitmap.Width() * fastBitmap.Height()];
			fastBitmap.LockBits();
			Marshal.Copy(fastBitmap.Data().Scan0, array, 0, array.Length);
			Marshal.Copy(fastBitmap.Data().Scan0, array2, 0, array2.Length);
			fastBitmap.Release();
			int num = fastBitmap.Width();
			int num2 = fastBitmap.Height();
			int num3 = 0;
			int num4 = 3;
			for (int i = 0; i < array.Length; i++)
			{
				int num5 = array[i];
				int num6 = num5 & 0xFF;
				int num7 = (num5 >> 8) & 0xFF;
				int num8 = (num5 >> 16) & 0xFF;
				if (num6 < num7)
				{
					num6 = num7;
				}
				if (num6 < num8)
				{
					num6 = num8;
				}
				num3 += num6;
				array[i] = num6;
			}
			num3 /= array.Length;
			for (int j = 0; j < array.Length; j++)
			{
				int num9 = array[j];
				num9 = ((num9 > num3) ? (255 - (255 - num9) / num4) : (num9 / num4));
				if (num9 < 0)
				{
					num9 = 0;
				}
				if (num9 > 255)
				{
					num9 = 255;
				}
				array[j] = ((num9 << 16) | (num9 << 8) | num9);
			}
			for (int k = 11; k < num2 - 11; k++)
			{
				for (int l = 11; l < num - 11; l++)
				{
					int num10 = array[k * num + l];
					num10 &= 0xFF;
					if (num10 < 170)
					{
						int num11 = 0;
						int num12 = 0;
						for (int m = k - 10; m < k + 10; m++)
						{
							for (int n = l - 10; n < l + 10; n++)
							{
								int num13 = array[m * num + n];
								num11 += num13;
								num12++;
							}
						}
						num11 /= num12;
						if (num11 - num10 > 150)
						{
							num10 = num11;
						}
						else if (num10 - num11 > 150)
						{
							num10 = num11;
						}
						else if (num10 > num11)
						{
							num10 += num10 / 3;
						}
						if (num10 > 255)
						{
							num10 = 255;
						}
						if (num10 < 0)
						{
							num10 = 0;
						}
					}
					array2[k * num + l] = ((num10 << 16) | (num10 << 8) | num10);
				}
			}
			fastBitmap.LockBits();
			Marshal.Copy(array2, 0, fastBitmap.Data().Scan0, array2.Length);
			fastBitmap.Release();
			Bitmap bitmap = new Bitmap(image.Size.Width, image.Size.Height, PixelFormat.Format24bppRgb);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Clear(Color.White);
			graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			graphics.DrawImage(fastBitmap.Bitmap, new Rectangle(0, 0, image.Size.Width, image.Size.Height), new Rectangle(0, 0, image.Size.Width, image.Size.Height), GraphicsUnit.Pixel);
			graphics.Dispose();
			return bitmap;
		}
		catch
		{
			return null;
		}
	}

	public static Image GetImage_Удаление_шума(Image image, int level)
	{
		if (image == null)
		{
			return null;
		}
		try
		{
			FastBitmap fastBitmap = new FastBitmap(new Bitmap(image), 4);
			int[] array = new int[fastBitmap.Width() * fastBitmap.Height()];
			int[] array2 = new int[fastBitmap.Width() * fastBitmap.Height()];
			fastBitmap.LockBits();
			Marshal.Copy(fastBitmap.Data().Scan0, array, 0, array.Length);
			Marshal.Copy(fastBitmap.Data().Scan0, array2, 0, array2.Length);
			fastBitmap.Release();
			int num = fastBitmap.Width();
			int num2 = fastBitmap.Height();
			int num3 = 0;
			for (int i = 0; i < array.Length; i++)
			{
				int num4 = array[i];
				int num5 = num4 & 0xFF;
				int num6 = (num4 >> 8) & 0xFF;
				int num7 = (num4 >> 16) & 0xFF;
				if (num5 < num6)
				{
					num5 = num6;
				}
				if (num5 < num7)
				{
					num5 = num7;
				}
				num3 += num5;
				array[i] = num5;
			}
			num3 /= array.Length;
			for (int j = 11; j < num2 - 11; j++)
			{
				for (int k = 11; k < num - 11; k++)
				{
					int num8 = array[j * num + k];
					num8 &= 0xFF;
					int num9 = 0;
					int num10 = 0;
					int[] array3 = new int[256];
					for (int l = j - 6; l < j + 6; l++)
					{
						for (int m = k - 6; m < k + 6; m++)
						{
							int num11 = array[l * num + m];
							num9 += num11;
							array3[num11 & -8]++;
							num10++;
						}
					}
					num9 /= num10;
					int num12 = 0;
					for (int n = 0; n < 256; n++)
					{
						if (num12 < array3[n])
						{
							num12 = array3[n];
							num9 = n;
						}
					}
					if (Math.Abs(num9 - num8) < level)
					{
						num8 = num9;
					}
					array2[j * num + k] = ((num8 << 16) | (num8 << 8) | num8);
				}
			}
			fastBitmap.LockBits();
			Marshal.Copy(array2, 0, fastBitmap.Data().Scan0, array2.Length);
			fastBitmap.Release();
			Bitmap bitmap = new Bitmap(image.Size.Width, image.Size.Height, PixelFormat.Format24bppRgb);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Clear(Color.White);
			graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
			graphics.DrawImage(fastBitmap.Bitmap, new Rectangle(0, 0, image.Size.Width, image.Size.Height), new Rectangle(0, 0, image.Size.Width, image.Size.Height), GraphicsUnit.Pixel);
			graphics.Dispose();
			return bitmap;
		}
		catch
		{
			return null;
		}
	}
}
