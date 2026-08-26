using System;

namespace ImageMagick;

internal interface INativeInstance : IDisposable
{
	IntPtr Instance { get; }
}
