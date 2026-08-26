using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class TerrainVisual3D : ModelVisual3D
{
	public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(TerrainVisual3D), new UIPropertyMetadata(null, SourceChanged));

	private readonly ModelVisual3D visualChild;

	public string Source
	{
		get
		{
			return (string)GetValue(SourceProperty);
		}
		set
		{
			SetValue(SourceProperty, value);
		}
	}

	public TerrainVisual3D()
	{
		visualChild = new ModelVisual3D();
		base.Children.Add(visualChild);
	}

	protected static void SourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
	{
		((TerrainVisual3D)obj).UpdateModel();
	}

	private void UpdateModel()
	{
		TerrainModel terrainModel = new TerrainModel();
		terrainModel.Load(Source);
		terrainModel.Texture = new SlopeTexture(8);
		visualChild.Content = terrainModel.CreateModel(2);
	}
}
