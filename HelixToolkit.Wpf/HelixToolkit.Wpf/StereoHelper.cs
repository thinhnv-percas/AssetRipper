using System;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public static class StereoHelper
{
	public static double CalculateStereoBase(double L, double N, double screenWidth, double depthRatio, double hfov)
	{
		double f = FindFocalLength(hfov, screenWidth);
		double p = depthRatio * screenWidth;
		return CalculateStereoBase(p, L, N, f);
	}

	public static double CalculateStereoBase(double P, double L, double N, double F)
	{
		return P * (L * N / (L - N)) * (1.0 / F - (L + N) / (2.0 * L * N));
	}

	public static Visual3D CreateClone(Visual3D v)
	{
		if (v is ModelUIElement3D)
		{
			ModelUIElement3D modelUIElement3D = v as ModelUIElement3D;
			if (modelUIElement3D.Model != null)
			{
				Model3D model = modelUIElement3D.Model.Clone();
				ModelUIElement3D modelUIElement3D2 = new ModelUIElement3D();
				modelUIElement3D2.Transform = modelUIElement3D.Transform;
				modelUIElement3D2.Model = model;
				return modelUIElement3D2;
			}
		}
		if (v is ModelVisual3D)
		{
			ModelVisual3D modelVisual3D = v as ModelVisual3D;
			ModelVisual3D modelVisual3D2 = new ModelVisual3D();
			modelVisual3D2.Transform = modelVisual3D.Transform;
			if (modelVisual3D.Content != null && modelVisual3D.Content.CanFreeze)
			{
				modelVisual3D.Content.Freeze();
				Model3D content = modelVisual3D.Content.Clone();
				modelVisual3D2.Content = content;
			}
			if (modelVisual3D.Children.Count > 0)
			{
				foreach (Visual3D child in modelVisual3D.Children)
				{
					Visual3D value = CreateClone(child);
					modelVisual3D2.Children.Add(value);
				}
			}
			return modelVisual3D2;
		}
		return null;
	}

	public static double FindFocalLength(double fov, double format)
	{
		return format / 2.0 / Math.Tan(fov / 2.0 * Math.PI / 180.0);
	}

	public static void UpdateStereoCameras(PerspectiveCamera centerCamera, PerspectiveCamera leftCamera, PerspectiveCamera rightCamera, double stereoBase, bool crossViewing = false, bool sameUpDirection = true, bool sameDirection = true)
	{
		if (centerCamera != null && leftCamera != null && rightCamera != null)
		{
			if (crossViewing)
			{
				stereoBase *= -1.0;
			}
			Point3D point3D = centerCamera.Position + centerCamera.LookDirection;
			Vector3D vector3D = Vector3D.CrossProduct(centerCamera.LookDirection, centerCamera.UpDirection);
			vector3D.Normalize();
			leftCamera.Position = centerCamera.Position - vector3D * stereoBase / 2.0;
			rightCamera.Position = centerCamera.Position + vector3D * stereoBase / 2.0;
			if (sameDirection)
			{
				leftCamera.LookDirection = centerCamera.LookDirection;
				rightCamera.LookDirection = centerCamera.LookDirection;
			}
			else
			{
				leftCamera.LookDirection = point3D - leftCamera.Position;
				rightCamera.LookDirection = point3D - rightCamera.Position;
			}
			if (sameUpDirection)
			{
				leftCamera.UpDirection = centerCamera.UpDirection;
				rightCamera.UpDirection = centerCamera.UpDirection;
			}
			else
			{
				leftCamera.UpDirection = Vector3D.CrossProduct(vector3D, leftCamera.LookDirection);
				rightCamera.UpDirection = Vector3D.CrossProduct(vector3D, rightCamera.LookDirection);
			}
			leftCamera.FieldOfView = centerCamera.FieldOfView;
			leftCamera.NearPlaneDistance = centerCamera.NearPlaneDistance;
			leftCamera.FarPlaneDistance = centerCamera.FarPlaneDistance;
			rightCamera.FieldOfView = centerCamera.FieldOfView;
			rightCamera.NearPlaneDistance = centerCamera.NearPlaneDistance;
			rightCamera.FarPlaneDistance = centerCamera.FarPlaneDistance;
		}
	}
}
