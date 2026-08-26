using System;

namespace ImageMagick;

internal sealed class ArtifactEventArgs : EventArgs
{
	public string Key { get; private set; }

	public string Value { get; private set; }

	internal ArtifactEventArgs(string key, string value)
	{
		Key = key;
		Value = value;
	}
}
