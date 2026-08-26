using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class HighDpiHelper
{
	[CompilerGenerated]
	internal sealed class _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A
	{
		public Control _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A;

		internal float _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020()
		{
			using (Graphics graphics = _0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A.CreateGraphics())
			{
				return graphics.DpiX / 96f;
			}
		}
	}

	public static void AdjustControlImagesDpiScale(Control container)
	{
		float value = _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020(container).Value;
		if (!_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A(value))
		{
			_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A(container.Controls, value);
		}
	}

	internal static void _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020(ButtonBase _0020, float _0020_000A)
	{
		Image image = _0020.Image;
		if (image != null)
		{
			_0020.Image = _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A(image, _0020_000A);
		}
	}

	internal static void _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A(Control.ControlCollection _0020, float _0020_000A)
	{
		foreach (Control item in _0020)
		{
			ButtonBase buttonBase = item as ButtonBase;
			if (buttonBase != null)
			{
				_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020(buttonBase, _0020_000A);
			}
			else
			{
				PictureBox pictureBox = item as PictureBox;
				if (pictureBox != null)
				{
					_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020(pictureBox, _0020_000A);
				}
			}
			_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A(item.Controls, _0020_000A);
		}
	}

	internal static void _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020(PictureBox _0020, float _0020_000A)
	{
		if (_0020.Image != null && _0020.SizeMode == PictureBoxSizeMode.CenterImage)
		{
			_0020.Image = _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A(_0020.Image, _0020_000A);
		}
	}

	internal static bool _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A(float _0020)
	{
		return (double)Math.Abs(_0020 - 1f) < 0.001;
	}

	internal static Lazy<float> _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020(Control _0020)
	{
		_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A = new _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A();
		_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A._0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A = _0020;
		return new Lazy<float>(_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A._0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020);
	}

	internal static Image _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A(Image _0020, float _0020_000A)
	{
		Size size = _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020(_0020.Size, _0020_000A);
		Bitmap bitmap = new Bitmap(size.Width, size.Height);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			InterpolationMode interpolationMode = InterpolationMode.HighQualityBicubic;
			if (_0020_000A >= 2f)
			{
				interpolationMode = InterpolationMode.NearestNeighbor;
			}
			graphics.InterpolationMode = interpolationMode;
			graphics.DrawImage(_0020, new Rectangle(default(Point), size));
			return bitmap;
		}
	}

	internal static Size _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020(Size _0020, float _0020_000A)
	{
		return new Size((int)((float)_0020.Width * _0020_000A), (int)((float)_0020.Height * _0020_000A));
	}
}
