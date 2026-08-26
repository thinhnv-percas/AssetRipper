using System.Windows;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class ClonedVisual3D : ModelVisual3D
{
	public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ModelVisual3D), typeof(ClonedVisual3D), new UIPropertyMetadata(null, SourceChanged));

	public ModelVisual3D Source
	{
		get
		{
			return (ModelVisual3D)GetValue(SourceProperty);
		}
		set
		{
			SetValue(SourceProperty, value);
		}
	}

	protected static void SourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ClonedVisual3D)d).OnSourceChanged();
	}

	protected virtual void OnSourceChanged()
	{
		if (Source == null)
		{
			base.Content = null;
			return;
		}
		Model3D content = Source.Content.Clone();
		base.Content = content;
	}
}
