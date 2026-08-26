using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class BitmapExporter : IExporter
{
	public enum OutputFormat
	{
		Png,
		Jpg,
		Bmp
	}

	public Brush Background { get; set; }

	public OutputFormat Format { get; set; }

	public int OversamplingMultiplier { get; set; }

	public BitmapExporter()
	{
		OversamplingMultiplier = 2;
		Format = OutputFormat.Png;
	}

	public void Export(Viewport3D viewport, Stream stream)
	{
		Brush background = Background ?? Brushes.Transparent;
		BitmapSource source = viewport.RenderBitmap(background, OversamplingMultiplier);
		BitmapEncoder bitmapEncoder = Format switch
		{
			OutputFormat.Jpg => new JpegBitmapEncoder(), 
			OutputFormat.Bmp => new BmpBitmapEncoder(), 
			OutputFormat.Png => new PngBitmapEncoder(), 
			_ => throw new InvalidOperationException("Not supported file format."), 
		};
		bitmapEncoder.Frames.Add(BitmapFrame.Create(source));
		bitmapEncoder.Save(stream);
	}

	public void Export(Visual3D visual, Stream stream)
	{
		throw new NotImplementedException();
	}

	public void Export(Model3D model, Stream stream)
	{
		throw new NotImplementedException();
	}
}
