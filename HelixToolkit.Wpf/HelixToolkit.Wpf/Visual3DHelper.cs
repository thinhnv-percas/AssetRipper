using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public static class Visual3DHelper
{
	private static readonly PropertyInfo Visual3DModelPropertyInfo = typeof(Visual3D).GetProperty("Visual3DModel", BindingFlags.Instance | BindingFlags.NonPublic);

	public static T Find<T>(DependencyObject parent) where T : DependencyObject
	{
		foreach (DependencyObject child in LogicalTreeHelper.GetChildren(parent))
		{
			T val = Find<T>(child);
			if (val != null)
			{
				return val;
			}
		}
		if (parent is ModelVisual3D { Content: Model3DGroup content })
		{
			return content.Children.OfType<T>().FirstOrDefault();
		}
		return null;
	}

	public static Rect3D FindBounds(this Visual3DCollection children)
	{
		Rect3D empty = Rect3D.Empty;
		foreach (Visual3D child in children)
		{
			if (!(child is IBoundsIgnoredVisual3D))
			{
				Rect3D rect = child.FindBounds(Transform3D.Identity);
				empty.Union(rect);
			}
		}
		return empty;
	}

	public static Rect3D FindBounds(this Visual3D visual, Transform3D transform)
	{
		Rect3D empty = Rect3D.Empty;
		Transform3D transform3D = Transform3DHelper.CombineTransform(visual.Transform, transform);
		Model3D model = visual.GetModel();
		if (model != null)
		{
			Rect3D rect = transform3D.TransformBounds(model.Bounds);
			if (!double.IsNaN(rect.X))
			{
				empty.Union(rect);
			}
		}
		foreach (Visual3D child in visual.GetChildren())
		{
			if (!(child is IBoundsIgnoredVisual3D))
			{
				Rect3D rect2 = child.FindBounds(transform3D);
				empty.Union(rect2);
			}
		}
		return empty;
	}

	public static Matrix3D GetTransform(this Visual3D visual)
	{
		Matrix3D identity = Matrix3D.Identity;
		for (DependencyObject dependencyObject = visual; dependencyObject != null; dependencyObject = VisualTreeHelper.GetParent(dependencyObject))
		{
			if (dependencyObject is Viewport3DVisual)
			{
				return identity;
			}
			if (dependencyObject is ModelVisual3D { Transform: not null } modelVisual3D)
			{
				identity.Append(modelVisual3D.Transform.Value);
			}
		}
		throw new InvalidOperationException("The visual is not added to a Viewport3D.");
	}

	public static Viewport3D GetViewport3D(this Visual3D visual)
	{
		for (DependencyObject dependencyObject = visual; dependencyObject != null; dependencyObject = VisualTreeHelper.GetParent(dependencyObject))
		{
			if (dependencyObject is Viewport3DVisual)
			{
				return VisualTreeHelper.GetParent(dependencyObject) as Viewport3D;
			}
		}
		return null;
	}

	public static Matrix3D GetViewportTransform(this Visual3D visual)
	{
		Matrix3D identity = Matrix3D.Identity;
		for (DependencyObject dependencyObject = visual; dependencyObject != null; dependencyObject = VisualTreeHelper.GetParent(dependencyObject))
		{
			if (dependencyObject is Viewport3DVisual viewport3DVisual)
			{
				Matrix3D totalTransform = viewport3DVisual.GetTotalTransform();
				identity.Append(totalTransform);
				return identity;
			}
			if (dependencyObject is ModelVisual3D { Transform: not null } modelVisual3D)
			{
				identity.Append(modelVisual3D.Transform.Value);
			}
		}
		throw new InvalidOperationException("The visual is not added to a Viewport3D.");
	}

	public static bool IsAttachedToViewport3D(this Visual3D visual)
	{
		for (DependencyObject dependencyObject = visual; dependencyObject != null; dependencyObject = VisualTreeHelper.GetParent(dependencyObject))
		{
			if (dependencyObject is Viewport3DVisual)
			{
				return true;
			}
		}
		return false;
	}

	public static void Traverse<T>(this Visual3DCollection visuals, Action<T, Transform3D> action) where T : Model3D
	{
		foreach (Visual3D visual in visuals)
		{
			visual.Traverse(action);
		}
	}

	public static void Traverse<T>(this Visual3D visual, Action<T, Transform3D> action) where T : Model3D
	{
		Traverse(visual, Transform3D.Identity, action);
	}

	public static GeneralTransform3D GetTransformTo(this Visual3D visual, Model3D model)
	{
		if (visual is ModelVisual3D modelVisual3D)
		{
			return modelVisual3D.Content.GetTransform(model, Transform3D.Identity);
		}
		return null;
	}

	public static Viewport3D GetViewport(this Visual3D visual)
	{
		for (DependencyObject dependencyObject = visual; dependencyObject != null; dependencyObject = VisualTreeHelper.GetParent(dependencyObject))
		{
			if (dependencyObject is Viewport3DVisual viewport3DVisual)
			{
				return (Viewport3D)viewport3DVisual.Parent;
			}
		}
		return null;
	}

	private static IEnumerable<Visual3D> GetChildren(this Visual3D parent)
	{
		int n = VisualTreeHelper.GetChildrenCount(parent);
		for (int i = 0; i < n; i++)
		{
			if (VisualTreeHelper.GetChild(parent, i) is Visual3D child)
			{
				yield return child;
			}
		}
	}

	private static Model3D GetModel(this Visual3D visual)
	{
		if (!(visual is ModelVisual3D { Content: var content }))
		{
			return Visual3DModelPropertyInfo.GetValue(visual, null) as Model3D;
		}
		return content;
	}

	private static void Traverse<T>(Visual3D visual, Transform3D transform, Action<T, Transform3D> action) where T : Model3D
	{
		Transform3D transform2 = Transform3DHelper.CombineTransform(visual.Transform, transform);
		visual.GetModel()?.Traverse(transform2, action);
		foreach (Visual3D child in visual.GetChildren())
		{
			Traverse(child, transform2, action);
		}
	}
}
