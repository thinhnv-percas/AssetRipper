using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class CombinedManipulator : ModelVisual3D
{
	public static readonly DependencyProperty CanRotateXProperty = DependencyProperty.Register("CanRotateX", typeof(bool), typeof(CombinedManipulator), new UIPropertyMetadata(true, ChildrenChanged));

	public static readonly DependencyProperty CanRotateYProperty = DependencyProperty.Register("CanRotateY", typeof(bool), typeof(CombinedManipulator), new UIPropertyMetadata(true, ChildrenChanged));

	public static readonly DependencyProperty CanRotateZProperty = DependencyProperty.Register("CanRotateZ", typeof(bool), typeof(CombinedManipulator), new UIPropertyMetadata(true, ChildrenChanged));

	public static readonly DependencyProperty CanTranslateXProperty = DependencyProperty.Register("CanTranslateX", typeof(bool), typeof(CombinedManipulator), new UIPropertyMetadata(true, ChildrenChanged));

	public static readonly DependencyProperty CanTranslateYProperty = DependencyProperty.Register("CanTranslateY", typeof(bool), typeof(CombinedManipulator), new UIPropertyMetadata(true, ChildrenChanged));

	public static readonly DependencyProperty CanTranslateZProperty = DependencyProperty.Register("CanTranslateZ", typeof(bool), typeof(CombinedManipulator), new UIPropertyMetadata(true, ChildrenChanged));

	public static readonly DependencyProperty DiameterProperty = DependencyProperty.Register("Diameter", typeof(double), typeof(CombinedManipulator), new UIPropertyMetadata(2.0));

	public static readonly DependencyProperty TargetTransformProperty = DependencyProperty.Register("TargetTransform", typeof(Transform3D), typeof(CombinedManipulator), new FrameworkPropertyMetadata(Transform3D.Identity, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	private readonly RotateManipulator rotateXManipulator;

	private readonly RotateManipulator rotateYManipulator;

	private readonly RotateManipulator rotateZManipulator;

	private readonly TranslateManipulator translateXManipulator;

	private readonly TranslateManipulator translateYManipulator;

	private readonly TranslateManipulator translateZManipulator;

	public bool CanRotateX
	{
		get
		{
			return (bool)GetValue(CanRotateXProperty);
		}
		set
		{
			SetValue(CanRotateXProperty, value);
		}
	}

	public bool CanRotateY
	{
		get
		{
			return (bool)GetValue(CanRotateYProperty);
		}
		set
		{
			SetValue(CanRotateYProperty, value);
		}
	}

	public bool CanRotateZ
	{
		get
		{
			return (bool)GetValue(CanRotateZProperty);
		}
		set
		{
			SetValue(CanRotateZProperty, value);
		}
	}

	public bool CanTranslateX
	{
		get
		{
			return (bool)GetValue(CanTranslateXProperty);
		}
		set
		{
			SetValue(CanTranslateXProperty, value);
		}
	}

	public bool CanTranslateY
	{
		get
		{
			return (bool)GetValue(CanTranslateYProperty);
		}
		set
		{
			SetValue(CanTranslateYProperty, value);
		}
	}

	public bool CanTranslateZ
	{
		get
		{
			return (bool)GetValue(CanTranslateZProperty);
		}
		set
		{
			SetValue(CanTranslateZProperty, value);
		}
	}

	public double Diameter
	{
		get
		{
			return (double)GetValue(DiameterProperty);
		}
		set
		{
			SetValue(DiameterProperty, value);
		}
	}

	public Vector3D Offset
	{
		get
		{
			return translateXManipulator.Offset;
		}
		set
		{
			translateXManipulator.Offset = value;
			translateYManipulator.Offset = value;
			translateZManipulator.Offset = value;
			rotateXManipulator.Offset = value;
			rotateYManipulator.Offset = value;
			rotateZManipulator.Offset = value;
		}
	}

	public Point3D Pivot
	{
		get
		{
			return rotateXManipulator.Pivot;
		}
		set
		{
			rotateXManipulator.Pivot = value;
			rotateYManipulator.Pivot = value;
			rotateZManipulator.Pivot = value;
		}
	}

	public Point3D Position
	{
		get
		{
			return translateXManipulator.Position;
		}
		set
		{
			translateXManipulator.Position = value;
			translateYManipulator.Position = value;
			translateZManipulator.Position = value;
			rotateXManipulator.Position = value;
			rotateYManipulator.Position = value;
			rotateZManipulator.Position = value;
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

	public CombinedManipulator()
	{
		translateXManipulator = new TranslateManipulator
		{
			Direction = new Vector3D(1.0, 0.0, 0.0),
			Color = Colors.Red
		};
		translateYManipulator = new TranslateManipulator
		{
			Direction = new Vector3D(0.0, 1.0, 0.0),
			Color = Colors.Green
		};
		translateZManipulator = new TranslateManipulator
		{
			Direction = new Vector3D(0.0, 0.0, 1.0),
			Color = Colors.Blue
		};
		rotateXManipulator = new RotateManipulator
		{
			Axis = new Vector3D(1.0, 0.0, 0.0),
			Color = Colors.Red
		};
		rotateYManipulator = new RotateManipulator
		{
			Axis = new Vector3D(0.0, 1.0, 0.0),
			Color = Colors.Green
		};
		rotateZManipulator = new RotateManipulator
		{
			Axis = new Vector3D(0.0, 0.0, 1.0),
			Color = Colors.Blue
		};
		BindingOperations.SetBinding(this, ModelVisual3D.TransformProperty, new Binding("TargetTransform")
		{
			Source = this
		});
		BindingOperations.SetBinding(translateXManipulator, Manipulator.TargetTransformProperty, new Binding("TargetTransform")
		{
			Source = this
		});
		BindingOperations.SetBinding(translateYManipulator, Manipulator.TargetTransformProperty, new Binding("TargetTransform")
		{
			Source = this
		});
		BindingOperations.SetBinding(translateZManipulator, Manipulator.TargetTransformProperty, new Binding("TargetTransform")
		{
			Source = this
		});
		BindingOperations.SetBinding(rotateXManipulator, RotateManipulator.DiameterProperty, new Binding("Diameter")
		{
			Source = this
		});
		BindingOperations.SetBinding(rotateYManipulator, RotateManipulator.DiameterProperty, new Binding("Diameter")
		{
			Source = this
		});
		BindingOperations.SetBinding(rotateZManipulator, RotateManipulator.DiameterProperty, new Binding("Diameter")
		{
			Source = this
		});
		BindingOperations.SetBinding(rotateXManipulator, Manipulator.TargetTransformProperty, new Binding("TargetTransform")
		{
			Source = this
		});
		BindingOperations.SetBinding(rotateYManipulator, Manipulator.TargetTransformProperty, new Binding("TargetTransform")
		{
			Source = this
		});
		BindingOperations.SetBinding(rotateZManipulator, Manipulator.TargetTransformProperty, new Binding("TargetTransform")
		{
			Source = this
		});
		UpdateChildren();
	}

	public virtual void Bind(ModelVisual3D source)
	{
		BindingOperations.SetBinding(this, TargetTransformProperty, new Binding("Transform")
		{
			Source = source
		});
		BindingOperations.SetBinding(this, ModelVisual3D.TransformProperty, new Binding("Transform")
		{
			Source = source
		});
	}

	public virtual void UnBind()
	{
		BindingOperations.ClearBinding(this, TargetTransformProperty);
		BindingOperations.ClearBinding(this, ModelVisual3D.TransformProperty);
	}

	protected void UpdateChildren()
	{
		base.Children.Clear();
		if (CanTranslateX)
		{
			base.Children.Add(translateXManipulator);
		}
		if (CanTranslateY)
		{
			base.Children.Add(translateYManipulator);
		}
		if (CanTranslateZ)
		{
			base.Children.Add(translateZManipulator);
		}
		if (CanRotateX)
		{
			base.Children.Add(rotateXManipulator);
		}
		if (CanRotateY)
		{
			base.Children.Add(rotateYManipulator);
		}
		if (CanRotateZ)
		{
			base.Children.Add(rotateZManipulator);
		}
	}

	private static void ChildrenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((CombinedManipulator)d).UpdateChildren();
	}
}
