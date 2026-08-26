using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class DefaultLights : LightSetup
{
	protected override void AddLights(Model3DGroup lightGroup)
	{
		lightGroup.Children.Add(new DirectionalLight(Color.FromRgb(180, 180, 180), new Vector3D(-1.0, -1.0, -1.0)));
		lightGroup.Children.Add(new DirectionalLight(Color.FromRgb(120, 120, 120), new Vector3D(1.0, -1.0, -0.1)));
		lightGroup.Children.Add(new DirectionalLight(Color.FromRgb(60, 60, 60), new Vector3D(0.1, 1.0, -1.0)));
		lightGroup.Children.Add(new DirectionalLight(Color.FromRgb(50, 50, 50), new Vector3D(0.1, 0.1, 1.0)));
		lightGroup.Children.Add(new AmbientLight(Color.FromRgb(30, 30, 30)));
	}
}
