using System;
using System.Collections.Generic;

namespace ImageMagick;

public sealed class ColorCMYK : ColorBase
{
	public byte A
	{
		get
		{
			return base.Color.A;
		}
		set
		{
			base.Color.A = value;
		}
	}

	public byte C
	{
		get
		{
			return base.Color.R;
		}
		set
		{
			base.Color.R = value;
		}
	}

	public byte K
	{
		get
		{
			return base.Color.K;
		}
		set
		{
			base.Color.K = value;
		}
	}

	public byte M
	{
		get
		{
			return base.Color.G;
		}
		set
		{
			base.Color.G = value;
		}
	}

	public byte Y
	{
		get
		{
			return base.Color.B;
		}
		set
		{
			base.Color.B = value;
		}
	}

	public ColorCMYK(Percentage cyan, Percentage magenta, Percentage yellow, Percentage key)
		: base(new MagickColor(cyan.ToQuantumType(), magenta.ToQuantumType(), yellow.ToQuantumType(), key.ToQuantumType(), Quantum.Max))
	{
	}

	public ColorCMYK(Percentage cyan, Percentage magenta, Percentage yellow, Percentage key, Percentage alpha)
		: base(new MagickColor(cyan.ToQuantumType(), magenta.ToQuantumType(), yellow.ToQuantumType(), key.ToQuantumType(), alpha.ToQuantumType()))
	{
	}

	public ColorCMYK(byte cyan, byte magenta, byte yellow, byte key)
		: base(new MagickColor(cyan, magenta, yellow, key, Quantum.Max))
	{
	}

	public ColorCMYK(byte cyan, byte magenta, byte yellow, byte key, byte alpha)
		: base(new MagickColor(cyan, magenta, yellow, key, alpha))
	{
	}

	public ColorCMYK(string color)
		: base(CreateColor(color))
	{
	}

	private ColorCMYK(MagickColor color)
		: base(color)
	{
	}

	public static implicit operator ColorCMYK(MagickColor color)
	{
		return FromMagickColor(color);
	}

	public static ColorCMYK FromMagickColor(MagickColor color)
	{
		if (color == null)
		{
			return null;
		}
		return new ColorCMYK(color);
	}

	private static MagickColor CreateColor(string color)
	{
		Throw.IfNullOrEmpty("color", color);
		if (color[0] == '#')
		{
			List<byte> list = HexColor.Parse(color);
			if (list.Count == 4)
			{
				return new MagickColor(list[0], list[1], list[2], list[3], Quantum.Max);
			}
		}
		throw new ArgumentException("Invalid color specified", "color");
	}
}
