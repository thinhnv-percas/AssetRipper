using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace HelixToolkit.Wpf;

public class ParticleSystem : RenderingModelVisual3D
{
	internal class Particle
	{
		internal Point3D Position;

		internal Vector3D Velocity;

		internal double Rotation;

		internal double Size;

		internal double Age;
	}

	public static readonly DependencyProperty TextureProperty = DependencyPropertyEx.Register<Brush, ParticleSystem>("Texture", null, delegate(ParticleSystem s, DependencyPropertyChangedEventArgs e)
	{
		s.TextureChanged();
	});

	public static readonly DependencyProperty LifeTimeProperty = DependencyPropertyEx.Register<double, ParticleSystem>("LifeTime", 20.0);

	public static readonly DependencyProperty FadeOutTimeProperty = DependencyPropertyEx.Register<double, ParticleSystem>("FadeOutTime", 0.5);

	public static readonly DependencyProperty AngularVelocityProperty = DependencyPropertyEx.Register<double, ParticleSystem>("AngularVelocity", 20.0);

	public static readonly DependencyProperty SizeRateProperty = DependencyPropertyEx.Register<double, ParticleSystem>("SizeRate", 2.0);

	public static readonly DependencyProperty VelocityDampingProperty = DependencyPropertyEx.Register<double, ParticleSystem>("VelocityDamping", 1.0);

	public static readonly DependencyProperty AccelerationProperty = DependencyPropertyEx.Register<double, ParticleSystem>("Acceleration", 4.0);

	public static readonly DependencyProperty AccelerationDirectionProperty = DependencyPropertyEx.Register<Vector3D, ParticleSystem>("AccelerationDirection", new Vector3D(3.0, 0.0, 1.0));

	public static readonly DependencyProperty AccelerationSpreadingProperty = DependencyPropertyEx.Register<double, ParticleSystem>("AccelerationSpreading", 10.0);

	public static readonly DependencyProperty EmitRateProperty = DependencyPropertyEx.Register<double, ParticleSystem>("EmitRate", 40.0);

	public static readonly DependencyProperty PositionProperty = DependencyPropertyEx.Register<Point3D, ParticleSystem>("Position", new Point3D(0.0, 0.0, 0.0));

	public static readonly DependencyProperty StartRadiusProperty = DependencyPropertyEx.Register<double, ParticleSystem>("StartRadius", 1.0);

	public static readonly DependencyProperty StartSizeProperty = DependencyPropertyEx.Register<double, ParticleSystem>("StartSize", 0.5);

	public static readonly DependencyProperty StartDirectionProperty = DependencyPropertyEx.Register<Vector3D, ParticleSystem>("StartDirection", new Vector3D(0.0, 0.0, 1.0));

	public static readonly DependencyProperty StartVelocityProperty = DependencyPropertyEx.Register<double, ParticleSystem>("StartVelocity", 2.0);

	public static readonly DependencyProperty StartVelocityRandomnessProperty = DependencyPropertyEx.Register<double, ParticleSystem>("StartVelocityRandomness", 1.0);

	public static readonly DependencyProperty StartSpreadingProperty = DependencyPropertyEx.Register<double, ParticleSystem>("StartSpreading", 40.0);

	public static readonly DependencyProperty AliveParticlesProperty = DependencyPropertyEx.Register<int, ParticleSystem>("AliveParticles", 0);

	private const double DegToRad = Math.PI / 180.0;

	private const double TwoPi = Math.PI * 2.0;

	private static readonly Random r = new Random();

	private readonly int opacityLevels = 10;

	private readonly Stopwatch watch = Stopwatch.StartNew();

	private readonly MeshGeometry3D mesh;

	private readonly GeometryModel3D model;

	private readonly List<Particle> particles = new List<Particle>(1000);

	private double particlesToEmit;

	private double previousTime = double.NaN;

	private ProjectionCamera camera;

	public int AliveParticles
	{
		get
		{
			return (int)GetValue(AliveParticlesProperty);
		}
		set
		{
			SetValue(AliveParticlesProperty, value);
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

	public Vector3D StartDirection
	{
		get
		{
			return (Vector3D)GetValue(StartDirectionProperty);
		}
		set
		{
			SetValue(StartDirectionProperty, value);
		}
	}

	public double Acceleration
	{
		get
		{
			return (double)GetValue(AccelerationProperty);
		}
		set
		{
			SetValue(AccelerationProperty, value);
		}
	}

	public Vector3D AccelerationDirection
	{
		get
		{
			return (Vector3D)GetValue(AccelerationDirectionProperty);
		}
		set
		{
			SetValue(AccelerationDirectionProperty, value);
		}
	}

	public double AccelerationSpreading
	{
		get
		{
			return (double)GetValue(AccelerationSpreadingProperty);
		}
		set
		{
			SetValue(AccelerationSpreadingProperty, value);
		}
	}

	public double StartRadius
	{
		get
		{
			return (double)GetValue(StartRadiusProperty);
		}
		set
		{
			SetValue(StartRadiusProperty, value);
		}
	}

	public double StartSize
	{
		get
		{
			return (double)GetValue(StartSizeProperty);
		}
		set
		{
			SetValue(StartSizeProperty, value);
		}
	}

	public double StartVelocity
	{
		get
		{
			return (double)GetValue(StartVelocityProperty);
		}
		set
		{
			SetValue(StartVelocityProperty, value);
		}
	}

	public double VelocityDamping
	{
		get
		{
			return (double)GetValue(VelocityDampingProperty);
		}
		set
		{
			SetValue(VelocityDampingProperty, value);
		}
	}

	public double StartVelocityRandomness
	{
		get
		{
			return (double)GetValue(StartVelocityRandomnessProperty);
		}
		set
		{
			SetValue(StartVelocityRandomnessProperty, value);
		}
	}

	public double StartSpreading
	{
		get
		{
			return (double)GetValue(StartSpreadingProperty);
		}
		set
		{
			SetValue(StartSpreadingProperty, value);
		}
	}

	public double LifeTime
	{
		get
		{
			return (double)GetValue(LifeTimeProperty);
		}
		set
		{
			SetValue(LifeTimeProperty, value);
		}
	}

	public double AngularVelocity
	{
		get
		{
			return (double)GetValue(AngularVelocityProperty);
		}
		set
		{
			SetValue(AngularVelocityProperty, value);
		}
	}

	public double SizeRate
	{
		get
		{
			return (double)GetValue(SizeRateProperty);
		}
		set
		{
			SetValue(SizeRateProperty, value);
		}
	}

	public double FadeOutTime
	{
		get
		{
			return (double)GetValue(FadeOutTimeProperty);
		}
		set
		{
			SetValue(FadeOutTimeProperty, value);
		}
	}

	public double EmitRate
	{
		get
		{
			return (double)GetValue(EmitRateProperty);
		}
		set
		{
			SetValue(EmitRateProperty, value);
		}
	}

	public Brush Texture
	{
		get
		{
			return (Brush)GetValue(TextureProperty);
		}
		set
		{
			SetValue(TextureProperty, value);
		}
	}

	public ParticleSystem()
	{
		mesh = new MeshGeometry3D();
		model = new GeometryModel3D
		{
			Geometry = mesh
		};
		base.Content = model;
		EmitOne();
	}

	protected void TextureChanged()
	{
		int num = 256;
		int num2 = 256;
		RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(opacityLevels * num, num2, 96.0, 96.0, PixelFormats.Pbgra32);
		for (int i = 0; i < opacityLevels; i++)
		{
			Rectangle rectangle = new Rectangle
			{
				Opacity = 1.0 - (double)i / (double)opacityLevels,
				Fill = Texture,
				Width = num,
				Height = num2
			};
			rectangle.Arrange(new Rect(num * i, 0.0, num, num2));
			renderTargetBitmap.Render(rectangle);
		}
		ImageBrush imageBrush = new ImageBrush(renderTargetBitmap)
		{
			ViewportUnits = BrushMappingMode.Absolute
		};
		imageBrush.Freeze();
		DiffuseMaterial diffuseMaterial = new DiffuseMaterial(imageBrush)
		{
			AmbientColor = Colors.White
		};
		diffuseMaterial.Freeze();
		model.Material = diffuseMaterial;
	}

	protected override void OnVisualParentChanged(DependencyObject oldParent)
	{
		base.OnVisualParentChanged(oldParent);
		if (oldParent == null)
		{
			SubscribeToRenderingEvent();
		}
		else
		{
			UnsubscribeRenderingEvent();
		}
	}

	protected void EmitOne()
	{
		Vector3D vector3D = CreateRandomVector(StartDirection, StartSpreading);
		Point3D position = Position;
		Vector3D startDirection = StartDirection;
		startDirection.Normalize();
		Vector3D vector3D2 = startDirection.FindAnyPerpendicular();
		Vector3D vector3D3 = Vector3D.CrossProduct(startDirection, vector3D2);
		if (StartRadius > 0.0)
		{
			double num = Math.PI * 2.0 * r.NextDouble();
			position += StartRadius * (vector3D2 * Math.Cos(num) + vector3D3 * Math.Sin(num));
		}
		double num2 = StartVelocity + StartVelocityRandomness * (r.NextDouble() - 0.5);
		Particle particle = new Particle
		{
			Position = position,
			Size = StartSize,
			Age = 0.0,
			Rotation = 0.0,
			Velocity = num2 * vector3D
		};
		int num3 = particles.FindIndex((Particle p) => p == null);
		if (num3 >= 0)
		{
			particles[num3] = particle;
		}
		else
		{
			particles.Add(particle);
		}
	}

	protected void Update(double time)
	{
		if (double.IsNaN(previousTime))
		{
			previousTime = time;
			return;
		}
		double num = time - previousTime;
		previousTime = time;
		particlesToEmit += num * EmitRate;
		while (particlesToEmit > 1.0)
		{
			EmitOne();
			particlesToEmit--;
		}
		double num2 = AngularVelocity * (Math.PI / 180.0);
		double velocityDamping = VelocityDamping;
		Vector3D accelerationDirection = AccelerationDirection;
		accelerationDirection.Normalize();
		double acceleration = Acceleration;
		double accelerationSpreading = AccelerationSpreading;
		double sizeRate = SizeRate;
		double fadeOutTime = FadeOutTime;
		double lifeTime = LifeTime;
		for (int i = 0; i < particles.Count; i++)
		{
			Particle particle = particles[i];
			particle.Age += num;
			if (particle.Age > lifeTime)
			{
				particles.RemoveAt(i);
				i--;
				continue;
			}
			Vector3D vector3D = ((accelerationSpreading > 0.0) ? CreateRandomVector(accelerationDirection, accelerationSpreading) : accelerationDirection);
			particle.Position += particle.Velocity * num;
			particle.Rotation += num2 * num;
			particle.Size += sizeRate * num;
			particle.Velocity = particle.Velocity * velocityDamping + vector3D * acceleration * num;
		}
		int count = particles.Count;
		Point3DCollection point3DCollection = mesh.Positions;
		PointCollection pointCollection = mesh.TextureCoordinates;
		Int32Collection int32Collection = mesh.TriangleIndices;
		mesh.Positions = null;
		mesh.TextureCoordinates = null;
		mesh.TriangleIndices = null;
		AliveParticles = count;
		if (point3DCollection == null)
		{
			point3DCollection = new Point3DCollection(count * 4);
			pointCollection = new PointCollection(count * 4);
			int32Collection = new Int32Collection(count * 6);
		}
		if (point3DCollection.Count != count * 4)
		{
			int num3 = point3DCollection.Count / 4;
			AdjustListLength(point3DCollection, count * 4);
			AdjustListLength(pointCollection, count * 4);
			AdjustListLength(int32Collection, count * 6);
			for (int j = num3; j < count; j++)
			{
				int num4 = j * 4;
				int num5 = j * 6;
				int32Collection[num5] = num4;
				int32Collection[num5 + 1] = num4 + 1;
				int32Collection[num5 + 2] = num4 + 2;
				int32Collection[num5 + 3] = num4 + 2;
				int32Collection[num5 + 4] = num4 + 3;
				int32Collection[num5 + 5] = num4;
			}
		}
		if (camera == null)
		{
			Viewport3D viewport3D = this.GetViewport3D();
			camera = (ProjectionCamera)viewport3D.Camera;
		}
		Point3D cameraPosition = camera.Position;
		Vector3D upDirection = camera.UpDirection;
		Vector3D lookDirection = camera.LookDirection;
		Vector3D vector3D2 = Vector3D.CrossProduct(lookDirection, upDirection);
		Vector3D vector3D3 = Vector3D.CrossProduct(vector3D2, lookDirection);
		vector3D2.Normalize();
		vector3D3.Normalize();
		IOrderedEnumerable<Particle> orderedEnumerable = particles.OrderBy((Particle p) => 0.0 - Vector3D.DotProduct(p.Position - cameraPosition, camera.LookDirection));
		int num6 = 0;
		foreach (Particle item in orderedEnumerable)
		{
			double num7 = item.Size * 0.5;
			int num8 = num6 * 4;
			num6++;
			double num9 = Math.Cos(item.Rotation);
			double num10 = Math.Sin(item.Rotation);
			Point point = new Point(num7 * (num9 + num10), num7 * (num10 - num9));
			Point point2 = new Point(num7 * (num9 - num10), num7 * (num9 + num10));
			Point point3 = new Point((0.0 - num7) * (num9 + num10), num7 * (num9 - num10));
			Point point4 = new Point(num7 * (num10 - num9), (0.0 - num7) * (num9 + num10));
			Point3D position = item.Position;
			point3DCollection[num8] = position + vector3D2 * point.X + vector3D3 * point.Y;
			point3DCollection[num8 + 1] = position + vector3D2 * point2.X + vector3D3 * point2.Y;
			point3DCollection[num8 + 2] = position + vector3D2 * point3.X + vector3D3 * point3.Y;
			point3DCollection[num8 + 3] = position + vector3D2 * point4.X + vector3D3 * point4.Y;
			double num11 = 1.0;
			if (fadeOutTime < 1.0 && item.Age > lifeTime * fadeOutTime)
			{
				num11 = 1.0 - (item.Age / lifeTime - fadeOutTime) / (1.0 - fadeOutTime);
			}
			int num12 = (int)((1.0 - num11) * (double)opacityLevels);
			double x = (double)num12 / (double)opacityLevels;
			double x2 = ((double)num12 + 1.0) / (double)opacityLevels;
			pointCollection[num8] = new Point(x2, 1.0);
			pointCollection[num8 + 1] = new Point(x2, 0.0);
			pointCollection[num8 + 2] = new Point(x, 0.0);
			pointCollection[num8 + 3] = new Point(x, 1.0);
		}
		mesh.Positions = point3DCollection;
		mesh.TextureCoordinates = pointCollection;
		mesh.TriangleIndices = int32Collection;
	}

	protected static void AdjustListLength<T>(IList<T> list, int targetLength)
	{
		int count = list.Count;
		for (int num = count - 1; num >= targetLength; num--)
		{
			list.RemoveAt(num);
		}
		for (int i = 0; i < targetLength - count; i++)
		{
			list.Add(default(T));
		}
	}

	protected static Vector3D CreateRandomVector(Vector3D z, double spreading)
	{
		double num = spreading * (Math.PI / 180.0) * r.NextDouble();
		double num2 = Math.PI * 2.0 * r.NextDouble();
		Vector3D vector3D = z.FindAnyPerpendicular();
		Vector3D vector3D2 = Vector3D.CrossProduct(z, vector3D);
		double num3 = Math.Sin(num);
		return vector3D * num3 * Math.Cos(num2) + vector3D2 * num3 * Math.Sin(num2) + z * Math.Cos(num);
	}

	protected override void OnCompositionTargetRendering(object sender, RenderingEventArgs eventArgs)
	{
		Update((double)watch.ElapsedMilliseconds * 0.001);
	}
}
