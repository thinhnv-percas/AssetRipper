using System;
using System.IO;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace HelixToolkit.Wpf;

public abstract class ModelReader : IModelReader
{
	public bool Freeze { get; set; }

	public Material DefaultMaterial { get; set; }

	public Dispatcher Dispatcher { get; private set; }

	public string Directory { get; set; }

	public string TexturePath
	{
		get
		{
			return Directory;
		}
		set
		{
			Directory = value;
		}
	}

	protected ModelReader(Dispatcher dispatcher = null)
	{
		DefaultMaterial = Materials.Gold;
		Dispatcher = dispatcher;
	}

	public virtual Model3DGroup Read(string path)
	{
		Directory = Path.GetDirectoryName(path);
		using FileStream s = File.OpenRead(path);
		return Read(s);
	}

	public abstract Model3DGroup Read(Stream s);

	protected void Dispatch(Action action)
	{
		if (Dispatcher == null)
		{
			action();
		}
		else
		{
			Dispatcher.Invoke(action, new object[0]);
		}
	}
}
