using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class SortingVisual3D : RenderingModelVisual3D
{
	public static readonly DependencyProperty CheckForOpaqueVisualsProperty = DependencyProperty.Register("CheckForOpaqueVisuals", typeof(bool), typeof(SortingVisual3D), new UIPropertyMetadata(false));

	public static readonly DependencyProperty IsSortingProperty = DependencyProperty.Register("IsSorting", typeof(bool), typeof(SortingVisual3D), new UIPropertyMetadata(false, IsSortingChanged));

	public static readonly DependencyProperty MethodProperty = DependencyProperty.Register("Method", typeof(SortingMethod), typeof(SortingVisual3D), new UIPropertyMetadata(SortingMethod.BoundingBoxCorners));

	public static readonly DependencyProperty SortingFrequencyProperty = DependencyProperty.Register("SortingFrequency", typeof(double), typeof(SortingVisual3D), new UIPropertyMetadata(60.0));

	private long startTick;

	public bool CheckForOpaqueVisuals
	{
		get
		{
			return (bool)GetValue(CheckForOpaqueVisualsProperty);
		}
		set
		{
			SetValue(CheckForOpaqueVisualsProperty, value);
		}
	}

	public bool IsSorting
	{
		get
		{
			return (bool)GetValue(IsSortingProperty);
		}
		set
		{
			SetValue(IsSortingProperty, value);
		}
	}

	public SortingMethod Method
	{
		get
		{
			return (SortingMethod)GetValue(MethodProperty);
		}
		set
		{
			SetValue(MethodProperty, value);
		}
	}

	public double SortingFrequency
	{
		get
		{
			return (double)GetValue(SortingFrequencyProperty);
		}
		set
		{
			SetValue(SortingFrequencyProperty, value);
		}
	}

	public SortingVisual3D()
	{
		IsSorting = true;
	}

	protected override void OnCompositionTargetRendering(object sender, RenderingEventArgs e)
	{
		if (startTick == 0)
		{
			startTick = e.RenderingTime.Ticks;
		}
		double num = 1E-07 * (double)(e.RenderingTime.Ticks - startTick);
		if (IsSorting && num >= 1.0 / SortingFrequency)
		{
			startTick = e.RenderingTime.Ticks;
			SortChildren();
		}
	}

	private static void IsSortingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((SortingVisual3D)d).OnIsSortingChanged();
	}

	private double GetCameraDistance(Visual3D c, Point3D cameraPos, Transform3D transform)
	{
		Rect3D rect = c.FindBounds(transform);
		switch (Method)
		{
		case SortingMethod.BoundingBoxCenter:
		{
			Point3D point3D = new Point3D(rect.X + rect.SizeX * 0.5, rect.Y + rect.SizeY * 0.5, rect.Z + rect.SizeZ * 0.5);
			return (point3D - cameraPos).LengthSquared;
		}
		case SortingMethod.BoundingBoxCorners:
		{
			double val = double.MaxValue;
			val = Math.Min(val, cameraPos.DistanceTo(new Point3D(rect.X, rect.Y, rect.Z)));
			val = Math.Min(val, cameraPos.DistanceTo(new Point3D(rect.X + rect.SizeX, rect.Y, rect.Z)));
			val = Math.Min(val, cameraPos.DistanceTo(new Point3D(rect.X + rect.SizeX, rect.Y + rect.SizeY, rect.Z)));
			val = Math.Min(val, cameraPos.DistanceTo(new Point3D(rect.X, rect.Y + rect.SizeY, rect.Z)));
			val = Math.Min(val, cameraPos.DistanceTo(new Point3D(rect.X, rect.Y, rect.Z + rect.SizeZ)));
			val = Math.Min(val, cameraPos.DistanceTo(new Point3D(rect.X + rect.SizeX, rect.Y, rect.Z + rect.SizeZ)));
			val = Math.Min(val, cameraPos.DistanceTo(new Point3D(rect.X + rect.SizeX, rect.Y + rect.SizeY, rect.Z + rect.SizeZ)));
			return Math.Min(val, cameraPos.DistanceTo(new Point3D(rect.X, rect.Y + rect.SizeY, rect.Z + rect.SizeZ)));
		}
		default:
		{
			BoundingSphere boundingSphere = BoundingSphere.CreateFromRect3D(rect);
			return boundingSphere.DistanceFrom(cameraPos);
		}
		}
	}

	private bool IsVisualTransparent(Visual3D visual)
	{
		return ElementSortingHelper.IsTransparent(visual);
	}

	private void OnIsSortingChanged()
	{
		if (IsSorting)
		{
			startTick = 0L;
			SubscribeToRenderingEvent();
		}
		else
		{
			UnsubscribeRenderingEvent();
		}
	}

	private void SortChildren()
	{
		Viewport3D viewport3D = this.GetViewport3D();
		if (viewport3D == null || !(viewport3D.Camera is ProjectionCamera projectionCamera))
		{
			return;
		}
		Point3D cameraPos = projectionCamera.Position;
		MatrixTransform3D transform = new MatrixTransform3D(this.GetTransform());
		IList<Visual3D> list = new List<Visual3D>();
		IList<Visual3D> list2 = new List<Visual3D>();
		if (CheckForOpaqueVisuals)
		{
			foreach (Visual3D child in base.Children)
			{
				if (IsVisualTransparent(child))
				{
					list.Add(child);
				}
				else
				{
					list2.Add(child);
				}
			}
		}
		else
		{
			list = base.Children;
		}
		List<Visual3D> list3 = list.OrderBy((Visual3D item) => 0.0 - GetCameraDistance(item, cameraPos, transform)).ToList();
		base.Children.Clear();
		foreach (Visual3D item in list2)
		{
			base.Children.Add(item);
		}
		foreach (Visual3D item2 in list3)
		{
			base.Children.Add(item2);
		}
	}
}
