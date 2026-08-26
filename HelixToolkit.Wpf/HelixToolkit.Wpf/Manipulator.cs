using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public abstract class Manipulator : UIElement3D
{
	public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(Manipulator), new UIPropertyMetadata(delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Manipulator)s).ColorChanged();
	}));

	public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register("Offset", typeof(Vector3D), typeof(Manipulator), new FrameworkPropertyMetadata(new Vector3D(0.0, 0.0, 0.0), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Manipulator)s).PositionChanged(e);
	}));

	public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("Position", typeof(Point3D), typeof(Manipulator), new FrameworkPropertyMetadata(default(Point3D), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Manipulator)s).PositionChanged(e);
	}));

	public static readonly DependencyProperty TargetTransformProperty = DependencyProperty.Register("TargetTransform", typeof(Transform3D), typeof(Manipulator), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(Manipulator), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((Manipulator)s).ValueChanged(e);
	}));

	public static readonly DependencyProperty MaterialProperty = DependencyProperty.Register("Material", typeof(Material), typeof(Manipulator), new PropertyMetadata(null));

	public static readonly DependencyProperty BackMaterialProperty = DependencyProperty.Register("BackMaterial", typeof(Material), typeof(Manipulator), new PropertyMetadata(null));

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

	public Material BackMaterial
	{
		get
		{
			return (Material)GetValue(BackMaterialProperty);
		}
		set
		{
			SetValue(BackMaterialProperty, value);
		}
	}

	public Vector3D Offset
	{
		get
		{
			return (Vector3D)GetValue(OffsetProperty);
		}
		set
		{
			SetValue(OffsetProperty, value);
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

	public Transform3D TargetTransform
	{
		get
		{
			return (Transform3D)GetValue(TargetTransformProperty);
		}
		set
		{
			SetValue(TargetTransformProperty, value);
		}
	}

	public double Value
	{
		get
		{
			return (double)GetValue(ValueProperty);
		}
		set
		{
			SetValue(ValueProperty, value);
		}
	}

	protected ProjectionCamera Camera { get; set; }

	protected Vector3D HitPlaneNormal { get; set; }

	protected GeometryModel3D Model { get; set; }

	protected Viewport3D ParentViewport { get; set; }

	protected Manipulator()
	{
		Model = new GeometryModel3D();
		BindingOperations.SetBinding(Model, GeometryModel3D.MaterialProperty, new Binding("Material")
		{
			Source = this
		});
		BindingOperations.SetBinding(Model, GeometryModel3D.BackMaterialProperty, new Binding("BackMaterial")
		{
			Source = this
		});
		base.Visual3DModel = Model;
	}

	public virtual void Bind(ModelVisual3D source)
	{
		BindingOperations.SetBinding(this, TargetTransformProperty, new Binding("Transform")
		{
			Source = source
		});
		BindingOperations.SetBinding(this, Visual3D.TransformProperty, new Binding("Transform")
		{
			Source = source
		});
	}

	public virtual void UnBind()
	{
		BindingOperations.ClearBinding(this, TargetTransformProperty);
		BindingOperations.ClearBinding(this, Visual3D.TransformProperty);
	}

	protected static void UpdateGeometry(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((Manipulator)d).UpdateGeometry();
	}

	protected virtual Point3D? GetHitPlanePoint(Point p, Point3D hitPlaneOrigin, Vector3D hitPlaneNormal)
	{
		return ParentViewport.UnProject(p, hitPlaneOrigin, hitPlaneNormal);
	}

	protected abstract void UpdateGeometry();

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		base.OnMouseDown(e);
		ParentViewport = this.GetViewport3D();
		Camera = ParentViewport.Camera as ProjectionCamera;
		ProjectionCamera camera = Camera;
		if (camera != null)
		{
			HitPlaneNormal = camera.LookDirection;
		}
		CaptureMouse();
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		base.OnMouseUp(e);
		ReleaseMouseCapture();
	}

	protected virtual void PositionChanged(DependencyPropertyChangedEventArgs e)
	{
		base.Transform = new TranslateTransform3D(Position.X + Offset.X, Position.Y + Offset.Y, Position.Z + Offset.Z);
	}

	protected virtual void ValueChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	protected Point3D ToLocal(Point3D worldPoint)
	{
		Matrix3D transform = this.GetTransform();
		transform.Invert();
		MatrixTransform3D matrixTransform3D = new MatrixTransform3D(transform);
		return matrixTransform3D.Transform(worldPoint);
	}

	protected Point3D ToWorld(Point3D point)
	{
		Matrix3D transform = this.GetTransform();
		MatrixTransform3D matrixTransform3D = new MatrixTransform3D(transform);
		return matrixTransform3D.Transform(point);
	}

	protected Vector3D ToWorld(Vector3D vector)
	{
		Matrix3D transform = this.GetTransform();
		MatrixTransform3D matrixTransform3D = new MatrixTransform3D(transform);
		return matrixTransform3D.Transform(vector);
	}

	private void ColorChanged()
	{
		Material = MaterialHelper.CreateMaterial(Color);
		BackMaterial = Material;
	}
}
