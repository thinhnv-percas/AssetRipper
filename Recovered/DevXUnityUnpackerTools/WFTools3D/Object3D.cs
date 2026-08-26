using System.Windows;
using System.Windows.Media.Media3D;

namespace WFTools3D
{
	public class Object3D : ModelVisual3D
	{
		public static DependencyProperty ScaleXProperty = DependencyProperty.Register("ScaleX", typeof(double), typeof(Object3D), new UIPropertyMetadata(1.0, _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A));

		public static DependencyProperty ScaleYProperty = DependencyProperty.Register("ScaleY", typeof(double), typeof(Object3D), new UIPropertyMetadata(1.0, _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A));

		public static DependencyProperty ScaleZProperty = DependencyProperty.Register("ScaleZ", typeof(double), typeof(Object3D), new UIPropertyMetadata(1.0, _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A));

		public static DependencyProperty PositionProperty = DependencyProperty.Register("Position", typeof(Point3D), typeof(Object3D), new UIPropertyMetadata(Math3D.Origin, _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A));

		public static readonly DependencyProperty Rotation1Property = DependencyProperty.Register("Rotation1", typeof(Quaternion), typeof(Object3D), new UIPropertyMetadata(Quaternion.Identity, _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A));

		public static readonly DependencyProperty Rotation2Property = DependencyProperty.Register("Rotation2", typeof(Quaternion), typeof(Object3D), new UIPropertyMetadata(Quaternion.Identity, _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A));

		public static readonly DependencyProperty Rotation3Property = DependencyProperty.Register("Rotation3", typeof(Quaternion), typeof(Object3D), new UIPropertyMetadata(Quaternion.Identity, _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A));

		private int _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;

		public virtual double ScaleX
		{
			get
			{
				return (double)GetValue(ScaleXProperty);
			}
			set
			{
				SetValue(ScaleXProperty, value);
			}
		}

		public virtual double ScaleY
		{
			get
			{
				return (double)GetValue(ScaleYProperty);
			}
			set
			{
				SetValue(ScaleYProperty, value);
			}
		}

		public virtual double ScaleZ
		{
			get
			{
				return (double)GetValue(ScaleZProperty);
			}
			set
			{
				SetValue(ScaleZProperty, value);
			}
		}

		public virtual double Scale
		{
			set
			{
				double num2 = ScaleZ = value;
				double num5 = ScaleX = (ScaleY = num2);
			}
		}

		public virtual Point3D Position
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

		public virtual Quaternion Rotation1
		{
			get
			{
				return (Quaternion)GetValue(Rotation1Property);
			}
			set
			{
				SetValue(Rotation1Property, value);
			}
		}

		public virtual Quaternion Rotation2
		{
			get
			{
				return (Quaternion)GetValue(Rotation2Property);
			}
			set
			{
				SetValue(Rotation2Property, value);
			}
		}

		public virtual Quaternion Rotation3
		{
			get
			{
				return (Quaternion)GetValue(Rotation3Property);
			}
			set
			{
				SetValue(Rotation3Property, value);
			}
		}

		internal static void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A(object _0020, DependencyPropertyChangedEventArgs _0020_000A)
		{
			(_0020 as Object3D).NewTransform();
		}

		protected virtual void NewTransform()
		{
			if (_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A == 0)
			{
				Matrix3D matrix = default(Matrix3D);
				matrix.Scale(new Vector3D(ScaleX, ScaleY, ScaleZ));
				matrix.Rotate(Rotation1);
				matrix.Rotate(Rotation2);
				matrix.Translate(new Vector3D(Position.X, Position.Y, Position.Z));
				matrix.Rotate(Rotation3);
				base.Transform = new MatrixTransform3D(matrix);
			}
		}

		public void LockUpdates(bool mode)
		{
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A += (mode ? 1 : (-1));
			if (_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A == 0)
			{
				NewTransform();
			}
		}

		public Point3D TranslatePoint(Point3D pt, DependencyObject relativeTo = null)
		{
			return Math3D.GetTransformationMatrix(this, relativeTo).Transform(pt);
		}
	}
}
