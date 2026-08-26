using System;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public static class Model3DHelper
{
	public static GeneralTransform3D GetTransform(this Model3D current, Model3D model, Transform3D parentTransform)
	{
		Transform3D transform3D = Transform3DHelper.CombineTransform(current.Transform, parentTransform);
		if (current == model)
		{
			return transform3D;
		}
		if (current is Model3DGroup model3DGroup)
		{
			foreach (Model3D child in model3DGroup.Children)
			{
				GeneralTransform3D transform = child.GetTransform(model, transform3D);
				if (transform != null)
				{
					return transform;
				}
			}
		}
		return null;
	}

	public static void Traverse<T>(this Model3D model, Action<T, Transform3D> action) where T : Model3D
	{
		model.Traverse(Transform3D.Identity, action);
	}

	public static void Traverse<T>(this Model3D model, Transform3D transform, Action<T, Transform3D> action) where T : Model3D
	{
		if (model is Model3DGroup model3DGroup)
		{
			Transform3D transform2 = Transform3DHelper.CombineTransform(model.Transform, transform);
			foreach (Model3D child in model3DGroup.Children)
			{
				child.Traverse(transform2, action);
			}
		}
		if (model is T arg)
		{
			Transform3D arg2 = Transform3DHelper.CombineTransform(model.Transform, transform);
			action(arg, arg2);
		}
	}
}
