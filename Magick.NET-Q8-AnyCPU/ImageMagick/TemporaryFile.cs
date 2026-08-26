using System;
using System.IO;

namespace ImageMagick;

internal sealed class TemporaryFile : IDisposable
{
	private FileInfo _tempFile;

	public long Length => _tempFile.Length;

	public TemporaryFile()
	{
		_tempFile = new FileInfo(Path.GetTempFileName());
	}

	public static implicit operator FileInfo(TemporaryFile file)
	{
		return file._tempFile;
	}

	public void CopyTo(FileInfo file)
	{
		_tempFile.CopyTo(file.FullName, overwrite: true);
		file.Refresh();
	}

	public void Dispose()
	{
		if (_tempFile.Exists)
		{
			_tempFile.Delete();
		}
	}
}
