using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public abstract class Exporter<T> : IExporter
{
	public virtual void Export(Viewport3D viewport, Stream stream)
	{
		T writer = Create(stream);
		ExportHeader(writer);
		ExportViewport(writer, viewport);
		viewport.Children.Traverse(delegate(GeometryModel3D m, Transform3D t)
		{
			ExportModel(writer, m, t);
		});
		ExportCamera(writer, viewport.Camera);
		viewport.Children.Traverse(delegate(Light m, Transform3D t)
		{
			ExportLight(writer, m, t);
		});
		Close(writer);
	}

	public virtual void Export(Visual3D visual, Stream stream)
	{
		T writer = Create(stream);
		ExportHeader(writer);
		visual.Traverse(delegate(GeometryModel3D m, Transform3D t)
		{
			ExportModel(writer, m, t);
		});
		Close(writer);
	}

	public virtual void Export(Model3D model, Stream stream)
	{
		T writer = Create(stream);
		ExportHeader(writer);
		model.Traverse(delegate(GeometryModel3D m, Transform3D t)
		{
			ExportModel(writer, m, t);
		});
		Close(writer);
	}

	protected abstract T Create(Stream stream);

	protected virtual void Close(T writer)
	{
	}

	protected virtual void ExportCamera(T writer, Camera camera)
	{
	}

	protected virtual void ExportHeader(T writer)
	{
	}

	protected virtual void ExportLight(T writer, Light light, Transform3D inheritedTransform)
	{
	}

	protected virtual void ExportModel(T writer, GeometryModel3D model, Transform3D inheritedTransform)
	{
	}

	protected virtual void ExportViewport(T writer, Viewport3D viewport)
	{
	}

	protected void RenderBrush(Stream stm, Brush brush, int w, int h, int qualityLevel)
	{
		Encode(RenderBrush(brush, w, h), stm, qualityLevel);
	}

	protected void RenderBrush(Stream stm, Brush brush, int w, int h)
	{
		Encode(RenderBrush(brush, w, h), stm);
	}

	protected RenderTargetBitmap RenderBrush(Brush brush, int w, int h)
	{
		if (brush is ImageBrush { ImageSource: BitmapImage imageSource })
		{
			w = imageSource.PixelWidth;
			h = imageSource.PixelHeight;
		}
		RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(w, h, 96.0, 96.0, PixelFormats.Pbgra32);
		Grid grid = new Grid
		{
			Background = brush,
			Width = 1.0,
			Height = 1.0,
			LayoutTransform = new ScaleTransform(w, h)
		};
		grid.Arrange(new Rect(0.0, 0.0, w, h));
		renderTargetBitmap.Render(grid);
		return renderTargetBitmap;
	}

	protected void Encode(RenderTargetBitmap bmp, Stream stm)
	{
		PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
		pngBitmapEncoder.Frames.Add(BitmapFrame.Create(bmp));
		pngBitmapEncoder.Save(stm);
	}

	protected void Encode(RenderTargetBitmap bmp, Stream stm, int qualityLevel)
	{
		JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder
		{
			QualityLevel = qualityLevel
		};
		jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(bmp));
		jpegBitmapEncoder.Save(stm);
	}
}
