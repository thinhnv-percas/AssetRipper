using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Media.Media3D;

namespace WFTools3D
{
	public class CameraBox : INotifyPropertyChanged
	{
		[CompilerGenerated]
		internal PropertyChangedEventHandler _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020;

		public PerspectiveCamera Camera = new PerspectiveCamera();

		public Vector3D MovingDirection;

		public bool MovingDirectionIsLocked;

		internal int _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A;

		public double Scale = 1.0;

		internal int _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020;

		internal bool _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A;

		internal Vector3D _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020;

		internal Vector3D _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A;

		public Point3D Position
		{
			get
			{
				return Camera.Position;
			}
			set
			{
				Camera.Position = value;
			}
		}

		public Vector3D LookDirection
		{
			get
			{
				return Camera.LookDirection;
			}
			set
			{
				Camera.LookDirection = value;
				if (!MovingDirectionIsLocked)
				{
					MovingDirection = Camera.LookDirection;
				}
			}
		}

		public Vector3D UpDirection
		{
			get
			{
				return Camera.UpDirection;
			}
			set
			{
				Camera.UpDirection = value;
			}
		}

		public double NearPlaneDistance
		{
			get
			{
				return Camera.NearPlaneDistance;
			}
			set
			{
				Camera.NearPlaneDistance = value;
			}
		}

		public double FarPlaneDistance
		{
			get
			{
				return Camera.FarPlaneDistance;
			}
			set
			{
				Camera.FarPlaneDistance = value;
			}
		}

		public double FieldOfView
		{
			get
			{
				return Camera.FieldOfView;
			}
			set
			{
				Camera.FieldOfView = MathUtils.Clamp(value, 1.0, 170.0);
			}
		}

		public Vector3D LeftDirection => Camera.UpDirection.Cross(Camera.LookDirection);

		public Vector3D RightDirection => Camera.LookDirection.Cross(Camera.UpDirection);

		public double RollAngle => _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A(LeftDirection.AngleTo(Math3D.UnitZ) - 90.0);

		public double PitchAngle => _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A(LookDirection.AngleTo(Math3D.UnitZ) - 90.0);

		public int Speed
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A;
			}
			set
			{
				if (_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A != value)
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A = value;
					FirePropertyChanged("Speed");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		internal void FirePropertyChanged(string propertyName)
		{
			if (_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020 != null)
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public void ChangeYaw(double angle)
		{
			LookDirection = LookDirection.Rotate(UpDirection, angle);
		}

		public void ChangeRoll(double angle)
		{
			UpDirection = UpDirection.Rotate(LookDirection, angle);
		}

		public void ChangePitch(double angle)
		{
			Quaternion q = Math3D.Rotation(LeftDirection, angle);
			UpDirection = q.Transform(UpDirection);
			LookDirection = q.Transform(LookDirection);
		}

		public void ChangeHeading(double angle)
		{
			Quaternion q = Math3D.RotationZ(angle);
			UpDirection = q.Transform(UpDirection);
			LookDirection = q.Transform(LookDirection);
		}

		public void Move(Vector3D direction, double amount)
		{
			Position += direction * amount;
		}

		public void Rotate(Vector3D axis, double angle)
		{
			Quaternion q = Math3D.Rotation(axis, angle);
			Position = q.Transform(Position);
			UpDirection = q.Transform(UpDirection);
			LookDirection = q.Transform(LookDirection);
		}

		public void Rotate(Vector3D axis, double angle, Point3D center)
		{
			if (!center.IsValid())
			{
				center = Math3D.Origin;
			}
			Position = Position.Subtract(center);
			Rotate(axis, angle);
			Position = Position.Add(center);
		}

		public void LookBack()
		{
			if (_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 == 0)
			{
				if (Speed == 0)
				{
					ChangeYaw(180.0);
				}
				else
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 = 1;
				}
			}
		}

		public void LookAtOrigin()
		{
			LookAt(Math3D.Origin);
		}

		public void LookAt(Point3D targetPoint)
		{
			Math3D.LookAt(targetPoint, Position, out _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A, out _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020);
			if (Speed == 0)
			{
				UpDirection = _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020;
				LookDirection = _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A;
			}
			else
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A = true;
			}
		}

		public void FlyParallel(int mode = 0)
		{
			if (_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A != 0)
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A = LookDirection;
				_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A.Z = 0.0;
				_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A.Normalize();
				_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020 = Math3D.UnitZ;
				if (mode != 0)
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020 = _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020.Rotate(_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A, mode * 15);
				}
				if (_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A == 0 || mode != 0)
				{
					UpDirection = _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020;
					LookDirection = _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A;
				}
				else
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A = true;
				}
			}
		}

		public void StopAnyTurn()
		{
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A = false;
		}

		public void Update()
		{
			if (Speed == 0)
			{
				return;
			}
			if (_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A)
			{
				_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020();
			}
			if (_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 != 0)
			{
				ChangeYaw(6.0);
				if ((_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 += 6) > 180)
				{
					_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 = 0;
				}
			}
			else
			{
				double num = Math.Log10(Math.Abs(Speed) + 1);
				double a = MathUtils.ToRadians(RollAngle);
				ChangeHeading(num * Math.Sin(a));
				Move(MovingDirection, (double)Speed * Scale / 300.0);
			}
		}

		internal double _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A(double _0020)
		{
			if (!(Math.Abs(_0020) < 0.5))
			{
				return _0020;
			}
			return 0.0;
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020()
		{
			double lengthSquared = (UpDirection - _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020).LengthSquared;
			double lengthSquared2 = (LookDirection - _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A).LengthSquared;
			double num = 3E-05;
			if (lengthSquared > num || lengthSquared2 > num)
			{
				num = 0.03;
				UpDirection = Math3D.Lerp(UpDirection, _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020, num);
				LookDirection = Math3D.Lerp(LookDirection, _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A, num);
			}
			else
			{
				UpDirection = _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020;
				LookDirection = _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A;
				_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A = false;
			}
		}
	}
}
