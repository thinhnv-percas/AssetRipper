using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class FileModelVisual3D : UIElement3D
{
	public static readonly DependencyProperty DefaultMaterialProperty = DependencyProperty.Register("DefaultMaterial", typeof(Material), typeof(FileModelVisual3D), new PropertyMetadata(null, SourceChanged));

	public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(FileModelVisual3D), new UIPropertyMetadata(null, SourceChanged));

	private static readonly RoutedEvent ModelLoadedEvent = EventManager.RegisterRoutedEvent("ModelLoaded", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FileModelVisual3D));

	public Material DefaultMaterial
	{
		get
		{
			return (Material)GetValue(DefaultMaterialProperty);
		}
		set
		{
			SetValue(DefaultMaterialProperty, value);
		}
	}

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

	public event RoutedEventHandler ModelLoaded
	{
		add
		{
			AddHandler(ModelLoadedEvent, value);
		}
		remove
		{
			RemoveHandler(ModelLoadedEvent, value);
		}
	}

	protected static void SourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
	{
		((FileModelVisual3D)obj).SourceChanged();
	}

	protected virtual void OnModelLoaded()
	{
		RoutedEventArgs e = new RoutedEventArgs
		{
			RoutedEvent = ModelLoadedEvent
		};
		RaiseEvent(e);
	}

	protected virtual void SourceChanged()
	{
		ModelImporter modelImporter = new ModelImporter
		{
			DefaultMaterial = DefaultMaterial
		};
		base.Visual3DModel = ((Source != null) ? modelImporter.Load(Source) : null);
		OnModelLoaded();
	}
}
