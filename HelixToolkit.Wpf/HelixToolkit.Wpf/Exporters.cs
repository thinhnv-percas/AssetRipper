using System;
using System.IO;

namespace HelixToolkit.Wpf;

public static class Exporters
{
	public static readonly string DefaultExtension = ".png";

	public static readonly string Filter = "Bitmap Files (*.png;*.jpg)|*.png;*.jpg|XAML Files (*.xaml)|*.xaml|Kerkythea Files (*.xml)|*.xml|Wavefront Files (*.obj)|*.obj|Wavefront Files zipped (*.objz)|*.objz|Extensible 3D Graphics Files (*.x3d)|*.x3d|Collada Files (*.dae)|*.dae|STereoLithography (*.stl)|*.stl";

	public static IExporter Create(string path)
	{
		if (path == null)
		{
			return null;
		}
		string extension = Path.GetExtension(path);
		switch (extension.ToLower())
		{
		case ".png":
		case ".jpg":
			return new BitmapExporter();
		case ".obj":
		case ".objz":
			return new ObjExporter();
		case ".xaml":
			return new XamlExporter();
		case ".xml":
			return new KerkytheaExporter();
		case ".x3d":
			return new X3DExporter();
		case ".dae":
			return new ColladaExporter();
		case ".stl":
			return new StlExporter();
		default:
			throw new InvalidOperationException("File format not supported.");
		}
	}
}
