using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class BillboardTextVisual3D : BillboardVisual3D, IBoundsIgnoredVisual3D
{
	public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(BillboardTextVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(BillboardTextVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(BillboardTextVisual3D), new UIPropertyMetadata(new Thickness(1.0), VisualChanged));

	public static readonly DependencyProperty FontFamilyProperty = DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(BillboardTextVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register("FontSize", typeof(double), typeof(BillboardTextVisual3D), new UIPropertyMetadata(0.0, VisualChanged));

	public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(BillboardTextVisual3D), new UIPropertyMetadata(FontWeights.Normal, VisualChanged));

	public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register("Foreground", typeof(Brush), typeof(BillboardTextVisual3D), new UIPropertyMetadata(Brushes.Black, VisualChanged));

	public static readonly DependencyProperty HeightFactorProperty = DependencyProperty.Register("HeightFactor", typeof(double), typeof(BillboardTextVisual3D), new PropertyMetadata(1.0, VisualChanged));

	public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register("Padding", typeof(Thickness), typeof(BillboardTextVisual3D), new UIPropertyMetadata(new Thickness(0.0), VisualChanged));

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(BillboardTextVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty MaterialTypeProperty = DependencyProperty.Register("MaterialType", typeof(MaterialType), typeof(BillboardTextVisual3D), new PropertyMetadata(MaterialType.Diffuse));

	public Brush Background
	{
		get
		{
			return (Brush)GetValue(BackgroundProperty);
		}
		set
		{
			SetValue(BackgroundProperty, value);
		}
	}

	public Brush BorderBrush
	{
		get
		{
			return (Brush)GetValue(BorderBrushProperty);
		}
		set
		{
			SetValue(BorderBrushProperty, value);
		}
	}

	public Thickness BorderThickness
	{
		get
		{
			return (Thickness)GetValue(BorderThicknessProperty);
		}
		set
		{
			SetValue(BorderThicknessProperty, value);
		}
	}

	public FontFamily FontFamily
	{
		get
		{
			return (FontFamily)GetValue(FontFamilyProperty);
		}
		set
		{
			SetValue(FontFamilyProperty, value);
		}
	}

	public double FontSize
	{
		get
		{
			return (double)GetValue(FontSizeProperty);
		}
		set
		{
			SetValue(FontSizeProperty, value);
		}
	}

	public FontWeight FontWeight
	{
		get
		{
			return (FontWeight)GetValue(FontWeightProperty);
		}
		set
		{
			SetValue(FontWeightProperty, value);
		}
	}

	public Brush Foreground
	{
		get
		{
			return (Brush)GetValue(ForegroundProperty);
		}
		set
		{
			SetValue(ForegroundProperty, value);
		}
	}

	public double HeightFactor
	{
		get
		{
			return (double)GetValue(HeightFactorProperty);
		}
		set
		{
			SetValue(HeightFactorProperty, value);
		}
	}

	public MaterialType MaterialType
	{
		get
		{
			return (MaterialType)GetValue(MaterialTypeProperty);
		}
		set
		{
			SetValue(MaterialTypeProperty, value);
		}
	}

	public Thickness Padding
	{
		get
		{
			return (Thickness)GetValue(PaddingProperty);
		}
		set
		{
			SetValue(PaddingProperty, value);
		}
	}

	public string Text
	{
		get
		{
			return (string)GetValue(TextProperty);
		}
		set
		{
			SetValue(TextProperty, value);
		}
	}

	private static void VisualChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((BillboardTextVisual3D)d).VisualChanged();
	}

	private void VisualChanged()
	{
		if (string.IsNullOrEmpty(Text))
		{
			base.Material = null;
			return;
		}
		TextBlock textBlock = new TextBlock(new Run(Text))
		{
			Foreground = Foreground,
			Background = Background,
			FontWeight = FontWeight,
			Padding = Padding
		};
		if (FontFamily != null)
		{
			textBlock.FontFamily = FontFamily;
		}
		if (FontSize > 0.0)
		{
			textBlock.FontSize = FontSize;
		}
		FrameworkElement frameworkElement = ((BorderBrush != null) ? ((FrameworkElement)new Border
		{
			BorderBrush = BorderBrush,
			BorderThickness = BorderThickness,
			Child = textBlock
		}) : ((FrameworkElement)textBlock));
		frameworkElement.Measure(new Size(1000.0, 1000.0));
		frameworkElement.Arrange(new Rect(frameworkElement.DesiredSize));
		RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)frameworkElement.ActualWidth + 1, (int)frameworkElement.ActualHeight + 1, 96.0, 96.0, PixelFormats.Pbgra32);
		renderTargetBitmap.Render(frameworkElement);
		ImageBrush brush = new ImageBrush(renderTargetBitmap);
		if (MaterialType == MaterialType.Diffuse)
		{
			base.Material = new DiffuseMaterial(brush);
		}
		if (MaterialType == MaterialType.Emissive)
		{
			base.Material = new EmissiveMaterial(brush);
		}
		base.Width = frameworkElement.ActualWidth;
		base.Height = frameworkElement.ActualHeight * HeightFactor;
	}
}
