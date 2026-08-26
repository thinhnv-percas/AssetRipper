using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class BillboardVisual3D : RenderingModelVisual3D
{
	public static readonly DependencyProperty DepthOffsetProperty = DependencyProperty.Register("DepthOffset", typeof(double), typeof(BillboardVisual3D), new UIPropertyMetadata(0.0));

	public static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height", typeof(double), typeof(BillboardVisual3D), new UIPropertyMetadata(10.0, GeometryChanged));

	public static readonly DependencyProperty HorizontalAlignmentProperty = DependencyProperty.Register("HorizontalAlignment", typeof(HorizontalAlignment), typeof(BillboardVisual3D), new UIPropertyMetadata(HorizontalAlignment.Center));

	public static readonly DependencyProperty MaterialProperty = DependencyProperty.Register("Material", typeof(Material), typeof(BillboardVisual3D), new UIPropertyMetadata(Materials.Red, MaterialChanged));

	public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("Position", typeof(Point3D), typeof(BillboardVisual3D), new UIPropertyMetadata(default(Point3D), GeometryChanged));

	public static readonly DependencyProperty VerticalAlignmentProperty = DependencyProperty.Register("VerticalAlignment", typeof(VerticalAlignment), typeof(BillboardVisual3D), new UIPropertyMetadata(VerticalAlignment.Center));

	public static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width", typeof(double), typeof(BillboardVisual3D), new UIPropertyMetadata(10.0, GeometryChanged));

	private readonly BillboardGeometryBuilder builder;

	private bool isRendering;

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

	public double Height
	{
		get
		{
			return (double)GetValue(HeightProperty);
		}
		set
		{
			SetValue(HeightProperty, value);
		}
	}

	public HorizontalAlignment HorizontalAlignment
	{
		get
		{
			return (HorizontalAlignment)GetValue(HorizontalAlignmentProperty);
		}
		set
		{
			SetValue(HorizontalAlignmentProperty, value);
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

	public Material Material
	{
		get
		{
			return (Material)GetValue(MaterialProperty);
		}
		set
		{
			SetValue(MaterialProperty, value);
		}
	}

	public Point3D Position
	{
		get
		{
			return (Point3D)GetValue(PositionProperty);
		}
		set
		{
			SetValue(PositionProperty, value);
		}
	}

	public VerticalAlignment VerticalAlignment
	{
		get
		{
			return (VerticalAlignment)GetValue(VerticalAlignmentProperty);
		}
		set
		{
			SetValue(VerticalAlignmentProperty, value);
		}
	}

	public double Width
	{
		get
		{
			return (double)GetValue(WidthProperty);
		}
		set
		{
			SetValue(WidthProperty, value);
		}
	}

	protected MeshGeometry3D Mesh { get; set; }

	protected GeometryModel3D Model { get; set; }

	public BillboardVisual3D()
	{
		builder = new BillboardGeometryBuilder(this);
		Mesh = new MeshGeometry3D
		{
			TriangleIndices = BillboardGeometryBuilder.CreateIndices(1),
			TextureCoordinates = new PointCollection
			{
				new Point(0.0, 1.0),
				new Point(1.0, 1.0),
				new Point(1.0, 0.0),
				new Point(0.0, 0.0)
			}
		};
		Model = new GeometryModel3D
		{
			Geometry = Mesh
		};
		base.Content = Model;
		OnMaterialChanged();
		OnGeometryChanged();
	}

	public void OnMaterialChanged()
	{
		Model.Material = Material;
	}

	protected static void GeometryChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((BillboardVisual3D)d).OnGeometryChanged();
	}

	protected override void OnCompositionTargetRendering(object sender, RenderingEventArgs e)
	{
		if (isRendering && this.IsAttachedToViewport3D() && UpdateTransforms())
		{
			UpdateGeometry();
		}
	}

	protected override void OnVisualParentChanged(DependencyObject oldParent)
	{
		base.OnVisualParentChanged(oldParent);
		DependencyObject parent = VisualTreeHelper.GetParent(this);
		IsRendering = parent != null;
	}

	protected void UpdateGeometry()
	{
		Billboard billboard = new Billboard(Position, Width, Height, HorizontalAlignment, VerticalAlignment, DepthOffset);
		Mesh.Positions = builder.GetPositions(new Billboard[1] { billboard }, default(Vector));
	}

	protected bool UpdateTransforms()
	{
		return builder.UpdateTransforms();
	}

	private static void MaterialChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((BillboardVisual3D)d).OnMaterialChanged();
	}

	private void OnGeometryChanged()
	{
		UpdateGeometry();
	}
}
