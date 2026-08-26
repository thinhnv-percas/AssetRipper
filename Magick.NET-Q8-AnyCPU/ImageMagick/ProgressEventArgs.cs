using System;

namespace ImageMagick;

public sealed class ProgressEventArgs : EventArgs
{
	public string Origin { get; private set; }

	public Percentage Progress { get; private set; }

	public bool Cancel { get; set; }

	internal ProgressEventArgs(string origin, int offset, int extent)
	{
		Origin = origin;
		Progress = new Percentage((double)(offset + 1) / (double)extent * 100.0);
	}
}
