using System;

namespace ImageMagick;

public sealed class ScriptWriteEventArgs : EventArgs
{
	public string Id { get; private set; }

	public IMagickImage Image { get; private set; }

	internal ScriptWriteEventArgs(string id, IMagickImage image)
	{
		Id = id;
		Image = image;
	}
}
