using System.Globalization;

namespace ImageMagick;

public sealed class MagickReadSettings : MagickSettings
{
	public IReadDefines Defines { get; set; }

	public MagickGeometry ExtractArea
	{
		get
		{
			return base.Extract;
		}
		set
		{
			base.Extract = value;
		}
	}

	public int? FrameIndex { get; set; }

	public int? FrameCount { get; set; }

	public int? Height { get; set; }

	public PixelStorageSettings PixelStorage { get; set; }

	public bool UseMonochrome
	{
		get
		{
			return base.Monochrome;
		}
		set
		{
			base.Monochrome = value;
		}
	}

	public int? Width { get; set; }

	public MagickReadSettings()
	{
	}

	public MagickReadSettings(IReadDefines readDefines)
	{
		SetDefines(readDefines);
	}

	internal MagickReadSettings(MagickSettings settings)
	{
		Copy(settings);
	}

	internal MagickReadSettings(MagickReadSettings settings)
	{
		Copy(settings);
		ApplyDefines();
		ApplyDimensions();
		ApplyFrame();
	}

	internal void ForceSingleFrame()
	{
		FrameCount = 1;
		ApplyFrame();
	}

	private static string GetDefineKey(IDefine define)
	{
		if (define.Format == MagickFormat.Unknown)
		{
			return define.Name;
		}
		return EnumHelper.GetName(define.Format) + ":" + define.Name;
	}

	private string GetScenes()
	{
		if (!FrameIndex.HasValue && !FrameCount.HasValue)
		{
			return null;
		}
		if (FrameIndex.HasValue && (!FrameCount.HasValue || FrameCount.Value == 1))
		{
			return FrameIndex.Value.ToString(CultureInfo.InvariantCulture);
		}
		int num = FrameIndex ?? 0;
		return string.Format(CultureInfo.InvariantCulture, "{0}-{1}", new object[2]
		{
			num,
			num + FrameCount.Value
		});
	}

	private void ApplyDefines()
	{
		if (Defines == null)
		{
			return;
		}
		foreach (IDefine define in Defines.Defines)
		{
			SetOption(GetDefineKey(define), define.Value);
		}
	}

	private void ApplyDimensions()
	{
		if (Width.HasValue && Height.HasValue)
		{
			base.Size = Width + "x" + Height;
		}
		else if (Width.HasValue)
		{
			base.Size = Width + "x";
		}
		else if (Height.HasValue)
		{
			base.Size = "x" + Height;
		}
	}

	private void ApplyFrame()
	{
		if (FrameIndex.HasValue || FrameCount.HasValue)
		{
			base.Scenes = GetScenes();
			base.Scene = FrameIndex ?? 0;
			base.NumberScenes = FrameCount ?? 1;
		}
	}

	private void Copy(MagickReadSettings settings)
	{
		Copy((MagickSettings)settings);
		Defines = settings.Defines;
		FrameIndex = settings.FrameIndex;
		FrameCount = settings.FrameCount;
		Height = settings.Height;
		Width = settings.Width;
		PixelStorage = settings.PixelStorage?.Clone();
	}
}
