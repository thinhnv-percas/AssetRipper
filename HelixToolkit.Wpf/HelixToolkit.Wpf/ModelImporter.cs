using System;
using System.IO;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace HelixToolkit.Wpf;

public class ModelImporter
{
	public Material DefaultMaterial { get; set; }

	public ModelImporter()
	{
		DefaultMaterial = Materials.Blue;
	}

	public Model3DGroup Load(string path, Dispatcher dispatcher = null, bool freeze = false)
	{
		if (path == null)
		{
			return null;
		}
		if (dispatcher == null)
		{
			dispatcher = Dispatcher.CurrentDispatcher;
		}
		string text = Path.GetExtension(path);
		if (text != null)
		{
			text = text.ToLower();
		}
		Model3DGroup result;
		switch (text)
		{
		case ".3ds":
		{
			StudioReader studioReader = new StudioReader(dispatcher)
			{
				DefaultMaterial = DefaultMaterial,
				Freeze = freeze
			};
			result = studioReader.Read(path);
			break;
		}
		case ".lwo":
		{
			LwoReader lwoReader = new LwoReader(dispatcher)
			{
				DefaultMaterial = DefaultMaterial,
				Freeze = freeze
			};
			result = lwoReader.Read(path);
			break;
		}
		case ".obj":
		{
			ObjReader objReader2 = new ObjReader(dispatcher)
			{
				DefaultMaterial = DefaultMaterial,
				Freeze = freeze
			};
			result = objReader2.Read(path);
			break;
		}
		case ".objz":
		{
			ObjReader objReader = new ObjReader(dispatcher)
			{
				DefaultMaterial = DefaultMaterial,
				Freeze = freeze
			};
			result = objReader.ReadZ(path);
			break;
		}
		case ".stl":
		{
			StLReader stLReader = new StLReader(dispatcher)
			{
				DefaultMaterial = DefaultMaterial,
				Freeze = freeze
			};
			result = stLReader.Read(path);
			break;
		}
		case ".off":
		{
			OffReader offReader = new OffReader(dispatcher)
			{
				DefaultMaterial = DefaultMaterial,
				Freeze = freeze
			};
			result = offReader.Read(path);
			break;
		}
		default:
			throw new InvalidOperationException("File format not supported.");
		}
		return result;
	}

	public Model3DGroup LoadObj(Stream stream, Dispatcher dispatcher = null, bool freeze = false)
	{
		if (stream == null)
		{
			return null;
		}
		if (dispatcher == null)
		{
			dispatcher = Dispatcher.CurrentDispatcher;
		}
		ObjReader objReader = new ObjReader(dispatcher)
		{
			DefaultMaterial = DefaultMaterial,
			Freeze = freeze
		};
		return objReader.Read(stream);
	}
}
