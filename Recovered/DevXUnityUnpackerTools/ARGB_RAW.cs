using @as;
using Hjg.Pngcs;
using JpegEncoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using XnaGeometry;

internal class ARGB_RAW
{
	internal byte[] texData;

	internal int Width;

	internal int Height;

	internal string str1;

	internal bool needYmirror = true;

	public const int PIXEL_REGION = 60;

	public const int TRANSPARENT_DISTANCE = 60;

	internal static ARGB_RAW FromPNG(byte[] buff)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		if (buff == null)
		{
			ConsoleManager.Info.WriteLine("ARGB_RAW.FromPNG - null");
			return null;
		}
		using (MemoryStream memoryStream = new MemoryStream(buff))
		{
			PngReader val = new PngReader((Stream)memoryStream);
			ImageInfo imgInfo = val.get_ImgInfo();
			if (imgInfo == null)
			{
				ConsoleManager.Info.WriteLine("ARGB_RAW.FromPNG imi - null");
			}
			if (imgInfo.Cols == 0 || imgInfo.Rows == 0)
			{
				ConsoleManager.Info.WriteLine(((object)imgInfo).ToString() ?? "");
			}
			ARGB_RAW aRGB_RAW = new ARGB_RAW(imgInfo.Cols, imgInfo.Rows);
			for (int i = 0; i < imgInfo.Rows; i++)
			{
				ImageLine val2 = val.ReadRowByte(i);
				for (int j = 0; j < imgInfo.Cols; j++)
				{
					byte g = val2.get_ScanlineB()[j * imgInfo.Channels];
					byte b = val2.get_ScanlineB()[j * imgInfo.Channels + 1];
					byte a = val2.get_ScanlineB()[j * imgInfo.Channels + 2];
					byte r_0020_0020 = (imgInfo.Channels < 4) ? byte.MaxValue : val2.get_ScanlineB()[j * imgInfo.Channels + 3];
					if (aRGB_RAW.needYmirror)
					{
						aRGB_RAW.SetPixelRGBA(j, imgInfo.Rows - 1 - i, r_0020_0020, g, b, a);
					}
					else
					{
						aRGB_RAW.SetPixelRGBA(j, i, r_0020_0020, g, b, a);
					}
				}
			}
			return aRGB_RAW;
		}
	}

	internal byte[] ToPNG()
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		if (Width == 0 || Height == 0)
		{
			ConsoleManager.Info.WriteLine("ToPNG Width=" + Width + ", Height=" + Height);
			return null;
		}
		ImageInfo val = new ImageInfo(Width, Height, 8, true, false, false);
		using (MemoryStream memoryStream = new MemoryStream())
		{
			PngWriter val2 = new PngWriter((Stream)memoryStream, val);
			ImageLine val3 = new ImageLine(val, 1, true);
			for (int i = 0; i < val2.ImgInfo.Rows; i++)
			{
				for (int j = 0; j < val.Cols; j++)
				{
					if (needYmirror)
					{
						(byte, byte, byte, byte) rGBA = GetRGBA(j, val2.ImgInfo.Rows - 1 - i);
						val3.get_ScanlineB()[j * val.Channels] = rGBA.Item1;
						val3.get_ScanlineB()[j * val.Channels + 1] = rGBA.Item2;
						val3.get_ScanlineB()[j * val.Channels + 2] = rGBA.Item3;
						val3.get_ScanlineB()[j * val.Channels + 3] = rGBA.Item4;
					}
					else
					{
						(byte, byte, byte, byte) rGBA2 = GetRGBA(j, i);
						val3.get_ScanlineB()[j * val.Channels] = rGBA2.Item1;
						val3.get_ScanlineB()[j * val.Channels + 1] = rGBA2.Item2;
						val3.get_ScanlineB()[j * val.Channels + 2] = rGBA2.Item3;
						val3.get_ScanlineB()[j * val.Channels + 3] = rGBA2.Item4;
					}
				}
				val2.WriteRow(val3, i);
			}
			val2.End();
			return memoryStream.ToArray();
		}
	}

	internal byte[] doJpgThing(float f = 50f)
	{
		_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A = new _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A();
		MemoryStream memoryStream = new MemoryStream();
		_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_0020_0020(this, new BinaryWriter(memoryStream), f, needYmirror);
		return memoryStream.ToArray();
	}

	internal ARGB_RAW GetSubImage(int x, int y, int width, int height, bool needMirrorY = false)
	{
		if (width == 0 || height == 0)
		{
			ConsoleManager.Info.WriteLine("GetSubImage m_Width=" + width + ", m_Height=" + height);
			return new ARGB_RAW(width, height);
		}
		try
		{
			ARGB_RAW aRGB_RAW = new ARGB_RAW(width, height);
			aRGB_RAW.str1 = str1;
			aRGB_RAW.needYmirror = needYmirror;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					if (needMirrorY)
					{
						(byte, byte, byte, byte) rGBA = GetRGBA(j + x, Height - 1 - (i + y));
						aRGB_RAW.SetPixelRGBA(j, i, rGBA.Item4, rGBA.Item1, rGBA.Item2, rGBA.Item3);
					}
					else
					{
						(byte, byte, byte, byte) rGBA2 = GetRGBA(j + x, i + y);
						aRGB_RAW.SetPixelRGBA(j, i, rGBA2.Item4, rGBA2.Item1, rGBA2.Item2, rGBA2.Item3);
					}
				}
			}
			return aRGB_RAW;
		}
		catch (Exception ex)
		{
			ConsoleManager.Info.WriteLine("Exception.GetSubImage Width=" + Width + ", Height=" + Height + ", m_Width=" + width + ", m_Height=" + height + ", m_X=" + x + ", m_Y=" + y + "\r\n" + ex);
			return null;
		}
	}

	internal ARGB_RAW MakeSthWithImg()
	{
		ARGB_RAW aRGB_RAW = new ARGB_RAW(Width >> 1, Height >> 1);
		aRGB_RAW.str1 = str1;
		aRGB_RAW.needYmirror = needYmirror;
		for (int i = 0; i < Height; i += 2)
		{
			for (int j = 0; j < Width; j += 2)
			{
				(byte, byte, byte, byte) rGBA = GetRGBA(j, i);
				(byte, byte, byte, byte) rGBA2 = GetRGBA(j + 1, i);
				(byte, byte, byte, byte) rGBA3 = GetRGBA(j, i + 1);
				(byte, byte, byte, byte) rGBA4 = GetRGBA(j + 1, i + 1);
				aRGB_RAW.SetPixelRGBA(j >> 1, i >> 1, (byte)(rGBA.Item4 + rGBA2.Item4 + rGBA3.Item4 + rGBA4.Item4 >> 2), (byte)(rGBA.Item1 + rGBA2.Item1 + rGBA3.Item1 + rGBA4.Item1 >> 2), (byte)(rGBA.Item2 + rGBA2.Item2 + rGBA3.Item2 + rGBA4.Item2 >> 2), (byte)(rGBA.Item3 + rGBA2.Item3 + rGBA3.Item3 + rGBA4.Item3 >> 2));
			}
		}
		return aRGB_RAW;
	}

	internal void SetSubImage(ARGB_RAW raw, int x, int y)
	{
		if (raw == null)
		{
			return;
		}
		for (int i = 0; i < raw.Height; i++)
		{
			for (int j = 0; j < raw.Width; j++)
			{
				(byte, byte, byte, byte) rGBA = raw.GetRGBA(j, i);
				SetPixelRGBA(j + x, i + y, rGBA.Item4, rGBA.Item1, rGBA.Item2, rGBA.Item3);
			}
		}
	}

	internal ARGB_RAW MakeRawCopy()
	{
		ARGB_RAW aRGB_RAW = new ARGB_RAW(Width, Height);
		aRGB_RAW.needYmirror = needYmirror;
		aRGB_RAW.str1 = str1;
		for (int i = 0; i < texData.Length; i++)
		{
			aRGB_RAW.texData[i] = texData[i];
		}
		return aRGB_RAW;
	}

	internal static decimal _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A(decimal _0020, decimal _0020_000A, decimal _0020_0020)
	{
		return _0020 + (_0020_000A - _0020) * _0020_0020;
	}

	internal static decimal _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020(decimal _0020, decimal _0020_000A, decimal _0020_0020, decimal _0020_000A_000A, decimal _0020_000A_0020, decimal _0020_0020_000A)
	{
		return _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A(_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A(_0020, _0020_000A, _0020_000A_0020), _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A(_0020_0020, _0020_000A_000A, _0020_000A_0020), _0020_0020_000A);
	}

	internal ARGB_RAW _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A(float _0020, float _0020_000A)
	{
		int num = (int)((float)Width * _0020);
		int num2 = (int)((float)Height * _0020_000A);
		ARGB_RAW aRGB_RAW = new ARGB_RAW(num, num2);
		aRGB_RAW.needYmirror = needYmirror;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				decimal num3 = (decimal)i / (decimal)num * (decimal)(Width - 1);
				decimal num4 = (decimal)j / (decimal)num2 * (decimal)(Height - 1);
				int num5 = (int)num3;
				int num6 = (int)num4;
				(byte, byte, byte, byte) rGBA = GetRGBA(num5, num6);
				(byte, byte, byte, byte) rGBA2 = GetRGBA(num5 + 1, num6);
				(byte, byte, byte, byte) rGBA3 = GetRGBA(num5, num6 + 1);
				(byte, byte, byte, byte) rGBA4 = GetRGBA(num5 + 1, num6 + 1);
				byte g = (byte)Math.Min(255m, _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020(rGBA.Item1, rGBA2.Item1, rGBA3.Item1, rGBA4.Item1, num3 - (decimal)num5, num4 - (decimal)num6));
				byte b = (byte)Math.Min(255m, _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020(rGBA.Item2, rGBA2.Item2, rGBA3.Item2, rGBA4.Item1, num3 - (decimal)num5, num4 - (decimal)num6));
				byte a = (byte)Math.Min(255m, _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020(rGBA.Item3, rGBA2.Item3, rGBA3.Item3, rGBA4.Item1, num3 - (decimal)num5, num4 - (decimal)num6));
				byte r_0020_0020 = (byte)Math.Min(255m, _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020(rGBA.Item4, rGBA2.Item4, rGBA3.Item4, rGBA4.Item4, num3 - (decimal)num5, num4 - (decimal)num6));
				aRGB_RAW.SetPixelRGBA(i, j, r_0020_0020, g, b, a);
			}
		}
		return aRGB_RAW;
	}

	internal void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(ARGB_RAW _0020, List<_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020> _0020_000A)
	{
		if (_0020_000A != null && _0020_000A.Count >= 3)
		{
			for (int i = 0; i < _0020_000A.Count; i += 3)
			{
				_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A2 = _0020_000A[i];
				_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_0020 = _0020_000A[i + 1];
				_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A_000A = _0020_000A[i + 2];
				_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020(_0020, _0020_000A2, _0020_0020, _0020_000A_000A);
			}
		}
	}

	internal void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A(ARGB_RAW _0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A_000A)
	{
		if (_0020 == null)
		{
			return;
		}
		int num = (int)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020;
		int num2 = (int)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A;
		int num3 = (int)_0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020;
		int num4 = (int)_0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A;
		int num5 = (int)_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020;
		int num6 = (int)_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A;
		int num7 = num;
		int num8 = num;
		int num9 = Math.Abs(num5 - num) / (num6 - num2);
		int num10 = Math.Abs(num3 - num) / (num4 - num2);
		for (int i = num2; i <= num4; i++)
		{
			for (int j = num7; j <= num8; j++)
			{
				_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A(j, i, _0020.GetRGBA(j, i));
			}
			num7 += num9;
			num8 += num10;
		}
		num10 = Math.Abs(num5 - num3) / (num6 - num4);
		for (int i = num4; i <= num6; i++)
		{
			for (int j = num7; j <= num8; j++)
			{
				_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A(j, i, _0020.GetRGBA(j, i));
			}
			num7 += num9;
			num8 += num10;
		}
	}

	internal static void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref int _0020, ref int _0020_000A)
	{
		int num = _0020_000A;
		_0020_000A = _0020;
		_0020 = num;
	}

	internal void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A(ARGB_RAW _0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A_000A)
	{
		int num = (int)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020;
		int num2 = (int)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A;
		int num3 = (int)_0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020;
		int num4 = (int)_0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A;
		int num5 = (int)_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020;
		int num6 = (int)_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A;
		int width = Width;
		int height = Height;
		if (num4 > num6)
		{
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref num3, ref num5);
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref num4, ref num6);
		}
		if (num2 > num4)
		{
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref num, ref num3);
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref num2, ref num4);
		}
		if (num4 > num6)
		{
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref num3, ref num5);
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref num4, ref num6);
		}
		double num7 = Convert.ToDouble(num5 - num) / (double)(num6 - num2 + 1);
		double num8 = Convert.ToDouble(num3 - num) / (double)(num4 - num2 + 1);
		double num9 = Convert.ToDouble(num5 - num3) / (double)(num6 - num4 + 1);
		double num10 = num;
		double num11 = (double)num + num8;
		for (int i = num2; i <= ((num6 > height - 1) ? (height - 1) : num6); i++)
		{
			if (i >= 0)
			{
				for (int j = (num10 > 0.0) ? Convert.ToInt32(num10 + 0.5) : 0; (double)j <= ((num11 < (double)width) ? num11 : ((double)(width - 1))); j++)
				{
					_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A(j, i, _0020.GetRGBA(j, i));
				}
				int num12 = (num10 < (double)width) ? Convert.ToInt32(num10 + 0.5) : (width - 1);
				while ((double)num12 >= ((num11 > 0.0) ? num11 : 0.0))
				{
					_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A(num12, i, _0020.GetRGBA(num12, i));
					num12--;
				}
			}
			num10 += num7;
			num11 = ((i >= num4) ? (num11 + num9) : (num11 + num8));
		}
	}

	internal void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020(ARGB_RAW _0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A_000A)
	{
		int num = (int)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020;
		int num2 = (int)_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A;
		int num3 = (int)_0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020;
		int num4 = (int)_0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A;
		int num5 = (int)_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020;
		int num6 = (int)_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A;
		int num7 = Width;
		int height = Height;
		if (num4 > num6)
		{
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref num3, ref num5);
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref num4, ref num6);
		}
		if (num2 > num4)
		{
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref num, ref num3);
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref num2, ref num4);
		}
		if (num4 > num6)
		{
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref num3, ref num5);
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref num4, ref num6);
		}
		double num8 = Convert.ToDouble(num5 - num) / (double)(num6 - num2 + 1);
		double num9 = Convert.ToDouble(num3 - num) / (double)(num4 - num2 + 1);
		double num10 = Convert.ToDouble(num5 - num3) / (double)(num6 - num4 + 1);
		double num11 = num;
		double num12 = (double)num + num9;
		for (int i = num2; i <= ((num6 > height - 1) ? (height - 1) : num6); i++)
		{
			if (i >= 0)
			{
				int num13 = (int)(num12 + 0.5);
				if (num13 >= num7)
				{
					num7--;
				}
				for (int j = (num11 > 0.0) ? Convert.ToInt32(num11 - 0.5) : 0; j <= num13; j++)
				{
					_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A(j, i, _0020.GetRGBA(j, i));
				}
				int num14 = (int)(num12 - 0.5);
				if (num14 < 0)
				{
					num14 = 0;
				}
				for (int num15 = (Convert.ToInt32(num11 + 0.5) < num7) ? Convert.ToInt32(num11 + 0.5) : (num7 - 1); num15 >= num14; num15--)
				{
					_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A(num15, i, _0020.GetRGBA(num15, i));
				}
			}
			num11 += num8;
			num12 = ((i >= num4) ? (num12 + num10) : (num12 + num9));
		}
	}

	internal static float _0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A(float _0020, float _0020_000A = 0f, float _0020_0020 = 1f)
	{
		return Math.Max(_0020_000A, Math.Min(_0020, _0020_0020));
	}

	internal static float _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A(float _0020, float _0020_000A, float _0020_0020)
	{
		return _0020 + (_0020_000A - _0020) * _0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A(_0020_0020);
	}

	internal void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020(int _0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A_000A, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A_0020, ARGB_RAW _0020_0020_000A)
	{
		float _0020_00202 = (_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A != _0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A) ? (((float)_0020 - _0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A) / (_0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A - _0020_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020)) : 1f;
		float _0020_00203 = (_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A != _0020_000A_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A) ? (((float)_0020 - _0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A) / (_0020_000A_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A - _0020_000A_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020)) : 1f;
		int num = (int)_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A(_0020_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A, _0020_0020._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A, _0020_00202);
		int num2 = (int)_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A(_0020_000A_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A, _0020_000A_0020._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A, _0020_00203);
		for (int i = num; i < num2; i++)
		{
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A(i, _0020, _0020_0020_000A.GetRGBA(i, _0020));
		}
	}

	internal void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A(ARGB_RAW _0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A_000A)
	{
		if (_0020_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 > _0020_0020._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020)
		{
			_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 = _0020_0020;
			_0020_0020 = _0020_000A;
			_0020_000A = _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020;
		}
		if (_0020_0020._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 > _0020_000A_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020)
		{
			_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_00202 = _0020_0020;
			_0020_0020 = _0020_000A_000A;
			_0020_000A_000A = _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_00202;
		}
		if (_0020_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 > _0020_0020._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020)
		{
			_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_00203 = _0020_0020;
			_0020_0020 = _0020_000A;
			_0020_000A = _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_00203;
		}
		float num = (!(_0020_0020._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 - _0020_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 > 0f)) ? 0f : ((_0020_0020._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A - _0020_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A) / (_0020_0020._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 - _0020_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020));
		float num2 = (!(_0020_000A_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 - _0020_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 > 0f)) ? 0f : ((_0020_000A_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A - _0020_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A) / (_0020_000A_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 - _0020_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020));
		if (num > num2)
		{
			for (int i = (int)_0020_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020; i <= (int)_0020_000A_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020; i++)
			{
				if ((float)i < _0020_0020._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020)
				{
					_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020(i, _0020_000A, _0020_000A_000A, _0020_000A, _0020_0020, _0020);
				}
				else
				{
					_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020(i, _0020_000A, _0020_000A_000A, _0020_0020, _0020_000A_000A, _0020);
				}
			}
			return;
		}
		for (int j = (int)_0020_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020; j <= (int)_0020_000A_000A._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020; j++)
		{
			if ((float)j < _0020_0020._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020)
			{
				_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020(j, _0020_000A, _0020_0020, _0020_000A, _0020_000A_000A, _0020);
			}
			else
			{
				_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020(j, _0020_0020, _0020_000A_000A, _0020_000A, _0020_000A_000A, _0020);
			}
		}
	}

	internal static void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020, ref _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A)
	{
		_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 = _0020_000A;
		_0020_000A = _0020;
		_0020 = _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020;
	}

	internal void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020(ARGB_RAW _0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_0020, _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A_000A)
	{
		if (_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A == _0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A && _0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A == _0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A)
		{
			return;
		}
		if (_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A > _0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A)
		{
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref _0020_000A, ref _0020_0020);
		}
		if (_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A > _0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A)
		{
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref _0020_000A, ref _0020_000A_000A);
		}
		if (_0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A > _0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A)
		{
			_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref _0020_0020, ref _0020_000A_000A);
		}
		int num = (int)(_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A - _0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A + 0.5f);
		for (float num2 = 0f; num2 < (float)num; num2 += 1f)
		{
			bool flag = num2 > _0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A - _0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A || _0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A == _0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A;
			float num3 = flag ? (_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A - _0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A) : (_0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A - _0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A);
			float f = num2 / (float)num;
			float f2 = (num2 - (flag ? (_0020_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A - _0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A) : 0f)) / num3;
			_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 = _0020_000A + (_0020_000A_000A - _0020_000A) * f;
			_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_00202 = flag ? (_0020_0020 + (_0020_000A_000A - _0020_0020) * f2) : (_0020_000A + (_0020_0020 - _0020_000A) * f2);
			if (_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020 > _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_00202._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020)
			{
				_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(ref _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020, ref _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_00202);
			}
			int num4 = (int)(_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_00202._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020 + 0.5f);
			for (int i = (int)(_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020 - 0.5f); i <= num4; i++)
			{
				int num5 = i;
				int num6 = (int)(_0020_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A + num2);
				_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A(num5, num6, _0020.GetRGBA(num5, num6));
			}
		}
	}

	internal ARGB_RAW(int width, int height, byte[] buff = null)
	{
		if (width == 0 || height == 0)
		{
			ConsoleManager.Info.WriteLine("ARGB_RAW width=" + width + ", height=" + height);
			ConsoleManager.Info.WriteLine(Environment.StackTrace);
			return;
		}
		texData = buff;
		if (texData == null)
		{
			texData = new byte[width * height * 4];
		}
		Width = width;
		Height = height;
	}

	internal void SetPixelRGBA(int x, int y, byte r_0020_0020, byte g, byte b, byte a)
	{
		if (x >= 0 && x < Width && y >= 0 && y < Height)
		{
			int num = y * Width + x << 2;
			texData[num + 3] = r_0020_0020;
			texData[num + 2] = g;
			texData[num + 1] = b;
			texData[num] = a;
		}
	}

	internal void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A(int _0020, int _0020_000A, (byte R, byte G, byte B, byte A) c)
	{
		if (_0020 >= 0 && _0020 < Width && _0020_000A >= 0 && _0020_000A < Height)
		{
			int num = _0020_000A * Width + _0020 << 2;
			texData[num + 3] = c.A;
			texData[num + 2] = c.R;
			texData[num + 1] = c.G;
			texData[num] = c.B;
		}
	}

	internal void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020(int _0020, byte _0020_000A, byte _0020_0020, byte _0020_000A_000A, byte _0020_000A_0020)
	{
		int num = _0020 << 2;
		texData[num + 3] = _0020_000A;
		texData[num + 2] = _0020_0020;
		texData[num + 1] = _0020_000A_000A;
		texData[num] = _0020_000A_0020;
	}

	internal void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(int _0020, int _0020_000A, byte _0020_0020)
	{
		if (_0020 >= 0 && _0020 < Width && _0020_000A >= 0 && _0020_000A < Height)
		{
			int num = _0020_000A * Width + _0020 << 2;
			texData[num + 3] = _0020_0020;
		}
	}

	internal static void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020(byte[] _0020, int _0020_000A, int _0020_0020, int _0020_000A_000A, int _0020_000A_0020, int _0020_0020_000A)
	{
		_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A(_0020, _0020_000A, (byte)_0020_0020, (byte)_0020_000A_000A, (byte)_0020_000A_0020, (byte)_0020_0020_000A);
	}

	internal static void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A(byte[] _0020, int _0020_000A, byte _0020_0020, byte _0020_000A_000A, byte _0020_000A_0020, byte _0020_0020_000A)
	{
		_0020[_0020_000A + 3] = _0020_0020;
		_0020[_0020_000A + 2] = _0020_000A_000A;
		_0020[_0020_000A + 1] = _0020_000A_0020;
		_0020[_0020_000A] = _0020_0020_000A;
	}

	internal static void _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020(byte[] _0020, int _0020_000A, int _0020_0020, int _0020_000A_000A, byte _0020_000A_0020, byte _0020_0020_000A, byte _0020_0020_0020, byte _0020_000A_000A_000A)
	{
		int num = _0020_000A_000A * _0020_000A + _0020_0020 << 2;
		_0020[num + 3] = _0020_000A_0020;
		_0020[num + 2] = _0020_0020_000A;
		_0020[num + 1] = _0020_0020_0020;
		_0020[num] = _0020_000A_000A_000A;
	}

	internal (byte R, byte G, byte B, byte A) GetRGBA(int x, int y)
	{
		if (x < 0 || x >= Width || y < 0 || y >= Height)
		{
			return (0, 0, 0, 0);
		}
		int num = y * Width + x << 2;
		byte item = texData[num + 3];
		byte item2 = texData[num + 2];
		byte item3 = texData[num + 1];
		byte item4 = texData[num];
		return (item2, item3, item4, item);
	}

	internal void _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020(int _0020, int _0020_000A, out byte _0020_0020, out byte _0020_000A_000A, out byte _0020_000A_0020, out byte _0020_0020_000A)
	{
		if (_0020 < 0 || _0020 >= Width || _0020_000A < 0 || _0020_000A >= Height)
		{
			_0020_0020 = 0;
			_0020_000A_000A = 0;
			_0020_0020_000A = 0;
			_0020_000A_0020 = 0;
		}
		else
		{
			int num = _0020_000A * Width + _0020 << 2;
			_0020_0020 = texData[num + 3];
			_0020_000A_000A = texData[num + 2];
			_0020_000A_0020 = texData[num + 1];
			_0020_0020_000A = texData[num];
		}
	}

	internal byte _0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020(int _0020, int _0020_000A)
	{
		if (_0020 < 0 || _0020 >= Width || _0020_000A < 0 || _0020_000A >= Height)
		{
			return 0;
		}
		int num = _0020_000A * Width + _0020 << 2;
		return texData[num + 3];
	}

	internal void SetPixel(int x, int y, Color color)
	{
		if (x >= 0 && x < Width && y >= 0 && y < Height)
		{
			int num = y * Width + x << 2;
			texData[num + 3] = color.A;
			texData[num + 2] = color.R;
			texData[num + 1] = color.G;
			texData[num] = color.B;
		}
	}

	internal Color GetPixel(int x, int y)
	{
		if (x < 0 || x >= Width || y < 0 || y >= Height)
		{
			return Color.FromArgb(0, 0, 0, 0);
		}
		int num = y * Width + x << 2;
		byte alpha = texData[num + 3];
		byte red = texData[num + 2];
		byte green = texData[num + 1];
		byte blue = texData[num];
		return Color.FromArgb(alpha, red, green, blue);
	}

	internal static void SwapByte(byte[] buff, int i)
	{
		byte b = buff[i + 2];
		byte b2 = buff[i];
		buff[i] = b;
		buff[i + 2] = b2;
	}

	internal void ToRGBA()
	{
		for (int i = 0; i < texData.Length; i += 4)
		{
			byte b = texData[i + 2];
			byte b2 = texData[i];
			texData[i] = b;
			texData[i + 2] = b2;
		}
	}

	internal void MirrorY()
	{
		for (int i = 0; i < Height / 2; i++)
		{
			for (int j = 0; j < Width; j++)
			{
				Color pixel = GetPixel(j, i);
				Color pixel2 = GetPixel(j, Height - i - 1);
				SetPixel(j, i, pixel2);
				SetPixel(j, Height - i - 1, pixel);
			}
		}
	}

	internal void _0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A()
	{
		for (int i = 0; i < Height; i++)
		{
			for (int j = 0; j < Width; j++)
			{
				(byte R, byte G, byte B, byte A) rGBA = GetRGBA(j, i);
				float num = (float)(int)rGBA.A / 255f * 2f - 1f;
				float num2 = (float)(int)rGBA.G / 255f * 2f - 1f;
				float num3 = Mathf.Sqrt(1f - Mathf.Clamp01((float)Vector2.Dot(new Vector2(num, num2), new Vector2(num, num2))));
				num = Mathf.Clamp01(num * 0.5f + 0.5f);
				num2 = Mathf.Clamp01(num2 * 0.5f + 0.5f);
				num3 = Mathf.Clamp01(num3 * 0.5f + 0.5f);
				SetPixelRGBA(j, i, byte.MaxValue, (byte)(num * 255f), (byte)(num2 * 255f), (byte)(num3 * 255f));
			}
		}
	}

	internal ARGB_RAW _0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020()
	{
		ARGB_RAW aRGB_RAW = new ARGB_RAW(Width, Height);
		Color white = Color.White;
		Color transparent = Color.Transparent;
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				Color pixel = GetPixel(i, j);
				if ((i < 60 || i > Width - 60 || j < 60 || j > Height - 60) && _0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A(white, pixel) < 60.0)
				{
					aRGB_RAW.SetPixel(i, j, transparent);
				}
				else
				{
					aRGB_RAW.SetPixel(i, j, pixel);
				}
			}
		}
		return aRGB_RAW;
	}

	internal double _0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A(Color _0020, Color _0020_000A)
	{
		int num = _0020_000A.A - _0020.A;
		int num2 = _0020_000A.R - _0020.R;
		int num3 = _0020_000A.G - _0020.G;
		int num4 = _0020_000A.B - _0020.B;
		return Math.Sqrt(Math.Pow(num, 2.0) + Math.Pow(num2, 2.0) + Math.Pow(num3, 2.0) + Math.Pow(num4, 2.0));
	}

	internal ARGB_RAW _0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020()
	{
		ARGB_RAW aRGB_RAW = new ARGB_RAW(Width, Height);
		texData.CopyTo(aRGB_RAW.texData, 0);
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				byte num3 = aRGB_RAW._0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020(i, j);
				if (num3 < 2)
				{
					num++;
				}
				if (num3 > 250)
				{
					num2++;
				}
			}
		}
		List<(int, int)> list = new List<(int, int)>();
		if (100f * (float)(Width * Height - (num + num2)) / (float)(Width * Height) < 5f)
		{
			for (int k = 0; k < Width; k++)
			{
				for (int l = 0; l < Height; l++)
				{
					byte b = _0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020(k, l);
					if (b != 0 && b < byte.MaxValue)
					{
						list.Add((k, l));
						aRGB_RAW._0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(k, l, 0);
					}
				}
			}
		}
		ARGB_RAW aRGB_RAW2 = new ARGB_RAW(Width, Height);
		aRGB_RAW.texData.CopyTo(aRGB_RAW2.texData, 0);
		foreach (var item in list)
		{
			int num4 = 0;
			int num5 = 0;
			for (int m = item.Item1 - 2; m < item.Item1 + 2; m++)
			{
				if (m >= 0 && m < Width)
				{
					for (int n = item.Item2 - 2; n < item.Item2 + 2; n++)
					{
						if (n >= 0 && n < Height && (m != 0 || n != 0))
						{
							byte b2 = aRGB_RAW._0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020(m, n);
							num4 += b2;
							num5++;
						}
					}
				}
			}
			num4 /= num5;
			aRGB_RAW2._0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(item.Item1, item.Item2, (byte)num4);
		}
		return aRGB_RAW2;
	}
}
