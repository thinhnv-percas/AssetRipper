using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public abstract class ScreenSpaceVisual3D : RenderingModelVisual3D
{
	public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ScreenSpaceVisual3D), new UIPropertyMetadata(Colors.Black, ColorChanged));

	public static readonly DependencyProperty DepthOffsetProperty = DependencyProperty.Register("DepthOffset", typeof(double), typeof(ScreenSpaceVisual3D), new UIPropertyMetadata(0.0, GeometryChanged));

	public static readonly DependencyProperty PointsProperty = DependencyProperty.Register("Points", typeof(Point3DCollection), typeof(ScreenSpaceVisual3D), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, PointsChanged));

	private bool isRendering;

	private Point3DCollection collectionBeingListenedTo;

	public Color Color
	{
		get
		{
			return (Color)GetValue(ColorProperty);
		}
		set
		{
			SetValue(ColorProperty, value);
		}
	}

	public double DepthOffset
	{
		get
		{
			return (double)GetValue(DepthOffsetProperty);
		}
		set
		{
			SetValue(DepthOffsetProperty, value);
		}
	}

	public bool IsRendering
	{
		get
		{
			return isRendering;
		}
		set
		{
			if (value != isRendering)
			{
				isRendering = value;
				if (isRendering)
				{
					SubscribeToRenderingEvent();
				}
				else
				{
					UnsubscribeRenderingEvent();
				}
			}
		}
	}

	public Point3DCollection Points
	{
		get
		{
			return (Point3DCollection)GetValue(PointsProperty);
		}
		set
		{
			SetValue(PointsProperty, value);
		}
	}

	protected CohenSutherlandClipping Clipping { get; set; }

	protected MeshGeometry3D Mesh { get; set; }

	protected GeometryModel3D Model { get; set; }

	protected ScreenSpaceVisual3D()
	{
		Mesh = new MeshGeometry3D();
		Model = new GeometryModel3D
		{
			Geometry = Mesh
		};
		base.Content = Model;
		Points = new Point3DCollection();
		ColorChanged();
	}

	protected static void GeometryChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		((ScreenSpaceVisual3D)sender).UpdateGeometry();
	}

	private static void PointsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	{
		ScreenSpaceVisual3D screenSpaceVisual3D = (ScreenSpaceVisual3D)sender;
		screenSpaceVisual3D.UpdateGeometry();
		if (screenSpaceVisual3D.collectionBeingListenedTo != null && !screenSpaceVisual3D.collectionBeingListenedTo.IsFrozen)
		{
			screenSpaceVisual3D.collectionBeingListenedTo.Changed -= screenSpaceVisual3D.HandlePointsChanged;
		}
		Point3DCollection point3DCollection = e.NewValue as Point3DCollection;
		if (point3DCollection != null && !point3DCollection.IsFrozen)
		{
			screenSpaceVisual3D.collectionBeingListenedTo = point3DCollection;
			point3DCollection.Changed += screenSpaceVisual3D.HandlePointsChanged;
		}
		else
		{
			screenSpaceVisual3D.collectionBeingListenedTo = point3DCollection;
		}
	}

	protected override void OnCompositionTargetRendering(object sender, RenderingEventArgs e)
	{
		if (isRendering && this.IsAttachedToViewport3D() && UpdateTransforms())
		{
			UpdateClipping();
			UpdateGeometry();
		}
	}

	protected override void OnVisualParentChanged(DependencyObject oldParent)
	{
		base.OnVisualParentChanged(oldParent);
		DependencyObject parent = VisualTreeHelper.GetParent(this);
		IsRendering = parent != null;
	}

	protected abstract void UpdateGeometry();

	protected abstract bool UpdateTransforms();

	private static void ColorChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		((ScreenSpaceVisual3D)sender).ColorChanged();
	}

	private void HandlePointsChanged(object sender, EventArgs e)
	{
		UpdateGeometry();
	}

	private void ColorChanged()
	{
		MaterialGroup materialGroup = new MaterialGroup();
		materialGroup.Children.Add(new DiffuseMaterial(Brushes.Black));
		materialGroup.Children.Add(new EmissiveMaterial(new SolidColorBrush(Color)));
		materialGroup.Freeze();
		Model.Material = materialGroup;
	}

	private void UpdateClipping()
	{
		Viewport3D viewport3D = this.GetViewport3D();
		if (viewport3D != null)
		{
			Clipping = new CohenSutherlandClipping(10.0, viewport3D.ActualWidth - 20.0, 10.0, viewport3D.ActualHeight - 20.0);
		}
	}
}
