using System.IO;

namespace ImageMagick.ImageOptimizers;

public interface IImageOptimizer
{
	MagickFormatInfo Format { get; }

	bool OptimalCompression { get; set; }

	bool Compress(FileInfo file);

	bool Compress(string fileName);

	bool LosslessCompress(FileInfo file);

	bool LosslessCompress(string fileName);
}
