using System.Collections.Generic;

namespace ImageMagick;

public sealed class DrawablePath : IDrawable, IDrawingWand
{
	private readonly List<IPath> _paths;

	public IEnumerable<IPath> Paths => _paths;

	public DrawablePath(params IPath[] paths)
	{
		_paths = new List<IPath>(paths);
	}

	public DrawablePath(IEnumerable<IPath> paths)
	{
		_paths = new List<IPath>(paths);
	}

	void IDrawingWand.Draw(DrawingWand wand)
	{
		if (wand == null)
		{
			return;
		}
		wand.PathStart();
		foreach (IDrawingWand path in _paths)
		{
			path.Draw(wand);
		}
		wand.PathFinish();
	}
}
