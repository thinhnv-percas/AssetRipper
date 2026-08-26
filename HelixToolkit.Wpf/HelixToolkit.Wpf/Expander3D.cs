using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class Expander3D : ModelVisual3D
{
	public static readonly DependencyProperty ExpandOriginProperty = DependencyProperty.Register("ExpandOrigin", typeof(Point3D?), typeof(Expander3D), new UIPropertyMetadata(null, ExpansionChanged));

	public static readonly DependencyProperty ExpansionProperty = DependencyProperty.Register("Expansion", typeof(double), typeof(Expander3D), new UIPropertyMetadata(2.0, ExpansionChanged));

	private readonly Dictionary<Model3D, Transform3D> originalTransforms = new Dictionary<Model3D, Transform3D>();

	private Point3D actualExpandOrigin;

	public Point3D? ExpandOrigin
	{
		get
		{
			return (Point3D?)GetValue(ExpandOriginProperty);
		}
		set
		{
			SetValue(ExpandOriginProperty, value);
		}
	}

	public double Expansion
	{
		get
		{
			return (double)GetValue(ExpansionProperty);
		}
		set
		{
			SetValue(ExpansionProperty, value);
		}
	}

	public void ExpandTo(double value, double animationTime)
	{
		DoubleAnimation animation = new DoubleAnimation(value, new Duration(TimeSpan.FromMilliseconds(animationTime)))
		{
			AccelerationRatio = 0.3,
			DecelerationRatio = 0.5
		};
		BeginAnimation(ExpansionProperty, animation);
	}

	private static void ExpansionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((Expander3D)d).OnExpansionChanged();
	}

	protected virtual void OnExpansionChanged()
	{
		if (!ExpandOrigin.HasValue)
		{
			if (base.Content != null)
			{
				actualExpandOrigin = base.Content.Bounds.Location;
			}
		}
		else
		{
			actualExpandOrigin = ExpandOrigin.Value;
		}
		base.Content.Traverse<GeometryModel3D>(Expand);
	}

	private void Expand(GeometryModel3D model, Transform3D transformation)
	{
		Transform3D transform3D;
		if (originalTransforms.ContainsKey(model))
		{
			transform3D = originalTransforms[model];
		}
		else
		{
			transform3D = model.Transform;
			originalTransforms.Add(model, transform3D);
		}
		Transform3D transform3D2 = Transform3DHelper.CombineTransform(transformation, transform3D);
		if (!(model.Geometry is MeshGeometry3D meshGeometry3D))
		{
			return;
		}
		Rect3D rect3D = default(Rect3D);
		foreach (int triangleIndex in meshGeometry3D.TriangleIndices)
		{
			rect3D.Union(transform3D2.Transform(meshGeometry3D.Positions[triangleIndex]));
		}
		Point3D location = rect3D.Location;
		Vector3D vector3D = location - actualExpandOrigin;
		vector3D *= Expansion;
		Point3D point3D = actualExpandOrigin + vector3D;
		TranslateTransform3D t = new TranslateTransform3D(point3D - location);
		model.Transform = Transform3DHelper.CombineTransform(transform3D, t);
	}
}
