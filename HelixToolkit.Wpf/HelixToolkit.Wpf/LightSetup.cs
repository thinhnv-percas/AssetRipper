using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public abstract class LightSetup : ModelVisual3D
{
	public static readonly DependencyProperty ShowLightsProperty = DependencyProperty.Register("ShowLights", typeof(bool), typeof(LightSetup), new UIPropertyMetadata(false, ShowLightsChanged));

	private readonly Model3DGroup lightGroup = new Model3DGroup();

	private readonly ModelVisual3D lightsVisual = new ModelVisual3D();

	public bool ShowLights
	{
		get
		{
			return (bool)GetValue(ShowLightsProperty);
		}
		set
		{
			SetValue(ShowLightsProperty, value);
		}
	}

	protected LightSetup()
	{
		base.Content = lightGroup;
		base.Children.Add(lightsVisual);
		OnSetupChanged();
		OnShowLightsChanged();
	}

	protected static void SetupChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((LightSetup)d).OnSetupChanged();
	}

	protected abstract void AddLights(Model3DGroup lightGroup);

	protected void OnSetupChanged()
	{
		lightGroup.Children.Clear();
		AddLights(lightGroup);
	}

	protected void OnShowLightsChanged()
	{
		lightsVisual.Children.Clear();
		if (!ShowLights)
		{
			return;
		}
		foreach (Model3D child in lightGroup.Children)
		{
			if (child is PointLight pointLight)
			{
				SphereVisual3D sphereVisual3D = new SphereVisual3D();
				sphereVisual3D.BeginEdit();
				sphereVisual3D.Center = pointLight.Position;
				sphereVisual3D.Radius = 1.0;
				sphereVisual3D.Fill = new SolidColorBrush(pointLight.Color);
				sphereVisual3D.EndEdit();
				lightsVisual.Children.Add(sphereVisual3D);
			}
			if (child is DirectionalLight { Direction: var direction } directionalLight)
			{
				direction.Normalize();
				Point3D point3D = new Point3D(0.0, 0.0, 0.0);
				Point3D point3D2 = point3D - direction * 20.0;
				Point3D point = point3D2 + direction * 10.0;
				SphereVisual3D sphereVisual3D2 = new SphereVisual3D();
				sphereVisual3D2.BeginEdit();
				sphereVisual3D2.Center = point3D2;
				sphereVisual3D2.Radius = 1.0;
				sphereVisual3D2.Fill = new SolidColorBrush(directionalLight.Color);
				sphereVisual3D2.EndEdit();
				lightsVisual.Children.Add(sphereVisual3D2);
				ArrowVisual3D arrowVisual3D = new ArrowVisual3D();
				arrowVisual3D.BeginEdit();
				arrowVisual3D.Point1 = point3D2;
				arrowVisual3D.Point2 = point;
				arrowVisual3D.Diameter = 0.5;
				arrowVisual3D.Fill = new SolidColorBrush(directionalLight.Color);
				arrowVisual3D.EndEdit();
				lightsVisual.Children.Add(arrowVisual3D);
			}
			if (child is AmbientLight ambientLight)
			{
				Point3D center = new Point3D(0.0, 0.0, 20.0);
				lightsVisual.Children.Add(new CubeVisual3D
				{
					Center = center,
					SideLength = 1.0,
					Fill = new SolidColorBrush(ambientLight.Color)
				});
			}
		}
	}

	private static void ShowLightsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((LightSetup)d).OnShowLightsChanged();
	}
}
