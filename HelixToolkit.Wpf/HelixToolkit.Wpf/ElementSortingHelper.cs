using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public static class ElementSortingHelper
{
	public static void AlphaSort(Point3D cameraPosition, Model3DCollection models, Transform3D worldTransform)
	{
		IOrderedEnumerable<Model3D> orderedEnumerable = models.OrderBy((Model3D model) => Point3D.Subtract(cameraPosition, worldTransform.Transform(model.Bounds.Location)).Length);
		models.Clear();
		foreach (Model3D item in orderedEnumerable)
		{
			models.Add(item);
		}
	}

	public static double GetDistanceSquared(Point3D position, Visual3D visual)
	{
		return Point3D.Subtract(visual.FindBounds(Transform3D.Identity).Location, position).LengthSquared;
	}

	public static double GetDistanceSquared(Point3D position, GeometryModel3D model)
	{
		return Point3D.Subtract(model.Bounds.Location, position).LengthSquared;
	}

	public static bool IsTransparent(Visual3D v)
	{
		if (v is ModelVisual3D modelVisual3D)
		{
			if (IsTransparent(modelVisual3D.Content))
			{
				return true;
			}
			return modelVisual3D.Children.Any(IsTransparent);
		}
		return false;
	}

	public static bool IsTransparent(Model3D model)
	{
		if (model is GeometryModel3D gm3D && IsTransparent(gm3D))
		{
			return true;
		}
		if (model is Model3DGroup model3DGroup)
		{
			return model3DGroup.Children.Any(IsTransparent);
		}
		return false;
	}

	public static bool IsTransparent(GeometryModel3D gm3D)
	{
		if (IsTransparent(gm3D.Material))
		{
			return true;
		}
		if (IsTransparent(gm3D.BackMaterial))
		{
			return true;
		}
		return false;
	}

	public static bool IsTransparent(Material material)
	{
		if (material is MaterialGroup materialGroup && materialGroup.Children.Any(IsTransparent))
		{
			return true;
		}
		if (material is DiffuseMaterial diffuseMaterial)
		{
			if (IsTransparent(diffuseMaterial.Brush))
			{
				return true;
			}
			if (diffuseMaterial.Color.A < byte.MaxValue)
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsTransparent(Brush brush)
	{
		if (brush.Opacity < 1.0)
		{
			return true;
		}
		if (brush is SolidColorBrush { Color: var color })
		{
			return color.A < byte.MaxValue;
		}
		if (brush is GradientBrush gradientBrush)
		{
			return gradientBrush.GradientStops.Any((GradientStop gs) => gs.Color.A < byte.MaxValue);
		}
		return false;
	}

	public static void SortModel(Point3D position, IList<Visual3D> model)
	{
		List<Visual3D> list = new List<Visual3D>();
		List<Visual3D> list2 = new List<Visual3D>();
		foreach (Visual3D item in model)
		{
			if (IsTransparent(item))
			{
				list2.Add(item);
			}
			else
			{
				list.Add(item);
			}
		}
		model.Clear();
		IOrderedEnumerable<Visual3D> orderedEnumerable = list2.OrderBy((Visual3D visual) => GetDistanceSquared(position, visual));
		foreach (Visual3D item2 in list)
		{
			model.Add(item2);
		}
		foreach (Visual3D item3 in orderedEnumerable)
		{
			model.Add(item3);
		}
	}
}
