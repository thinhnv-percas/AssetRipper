using System;

namespace ImageMagick;

public sealed class ScriptReadEventArgs : EventArgs
{
	public string Id { get; private set; }

	public MagickImage Image { get; set; }

	public MagickReadSettings Settings { get; private set; }

	internal ScriptReadEventArgs(string id, MagickReadSettings settings)
	{
		Id = id;
		Settings = settings;
	}
}
