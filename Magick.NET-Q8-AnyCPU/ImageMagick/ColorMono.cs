using System;

namespace ImageMagick;

public sealed class ColorMono : ColorBase
{
	public bool IsBlack { get; set; }

	public ColorMono(bool isBlack)
		: base(isBlack ? MagickColors.Black : MagickColors.White)
	{
		IsBlack = isBlack;
	}

	private ColorMono(MagickColor color)
		: base(color)
	{
		if (color == MagickColors.Black)
		{
			IsBlack = true;
			return;
		}
		if (color == MagickColors.White)
		{
			IsBlack = false;
			return;
		}
		throw new ArgumentException("Invalid color specified.", "color");
	}

	public static implicit operator ColorMono(MagickColor color)
	{
		return FromMagickColor(color);
	}

	public static ColorMono FromMagickColor(MagickColor color)
	{
		if (color == null)
		{
			return null;
		}
		return new ColorMono(color);
	}

	protected override void UpdateColor()
	{
		byte b = (byte)((!IsBlack) ? Quantum.Max : 0);
		base.Color.R = b;
		base.Color.G = b;
		base.Color.B = b;
	}
}
