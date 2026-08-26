using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class TextVisual3D : ModelVisual3D
{
	public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(TextVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(TextVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(TextVisual3D), new UIPropertyMetadata(new Thickness(1.0), VisualChanged));

	public static readonly DependencyProperty IsFlippedProperty = DependencyProperty.Register("IsFlipped", typeof(bool), typeof(TextVisual3D), new PropertyMetadata(false, VisualChanged));

	public static readonly DependencyProperty FontFamilyProperty = DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(TextVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register("FontSize", typeof(double), typeof(TextVisual3D), new UIPropertyMetadata(0.0, VisualChanged));

	public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(TextVisual3D), new UIPropertyMetadata(FontWeights.Normal, VisualChanged));

	public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register("Foreground", typeof(Brush), typeof(TextVisual3D), new UIPropertyMetadata(Brushes.Black, VisualChanged));

	public static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height", typeof(double), typeof(TextVisual3D), new UIPropertyMetadata(11.0, VisualChanged));

	public static readonly DependencyProperty HorizontalAlignmentProperty = DependencyProperty.Register("HorizontalAlignment", typeof(HorizontalAlignment), typeof(TextVisual3D), new UIPropertyMetadata(HorizontalAlignment.Center, VisualChanged));

	public static readonly DependencyProperty IsDoubleSidedProperty = DependencyProperty.Register("IsDoubleSided", typeof(bool), typeof(TextVisual3D), new UIPropertyMetadata(true, VisualChanged));

	public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register("Padding", typeof(Thickness), typeof(TextVisual3D), new UIPropertyMetadata(new Thickness(0.0), VisualChanged));

	public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("Position", typeof(Point3D), typeof(TextVisual3D), new UIPropertyMetadata(new Point3D(0.0, 0.0, 0.0), VisualChanged));

	public static readonly DependencyProperty TextDirectionProperty = DependencyProperty.Register("TextDirection", typeof(Vector3D), typeof(TextVisual3D), new UIPropertyMetadata(new Vector3D(1.0, 0.0, 0.0), VisualChanged));

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty UpDirectionProperty = DependencyProperty.Register("UpDirection", typeof(Vector3D), typeof(TextVisual3D), new UIPropertyMetadata(new Vector3D(0.0, 0.0, 1.0), VisualChanged));

	public static readonly DependencyProperty VerticalAlignmentProperty = DependencyProperty.Register("VerticalAlignment", typeof(VerticalAlignment), typeof(TextVisual3D), new UIPropertyMetadata(VerticalAlignment.Center, VisualChanged));

	public bool IsFlipped
	{
		get
		{
			return (bool)GetValue(IsFlippedProperty);
		}
		set
		{
			SetValue(IsFlippedProperty, value);
		}
	}

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

	public double Height
	{
		get
		{
			return (double)GetValue(HeightProperty);
		}
		set
		{
			SetValue(HeightProperty, value);
		}
	}

	public HorizontalAlignment HorizontalAlignment
	{
		get
		{
			return (HorizontalAlignment)GetValue(HorizontalAlignmentProperty);
		}
		set
		{
			SetValue(HorizontalAlignmentProperty, value);
		}
	}

	public bool IsDoubleSided
	{
		get
		{
			return (bool)GetValue(IsDoubleSidedProperty);
		}
		set
		{
			SetValue(IsDoubleSidedProperty, value);
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

	public Vector3D TextDirection
	{
		get
		{
			return (Vector3D)GetValue(TextDirectionProperty);
		}
		set
		{
			SetValue(TextDirectionProperty, value);
		}
	}

	public Vector3D UpDirection
	{
		get
		{
			return (Vector3D)GetValue(UpDirectionProperty);
		}
		set
		{
			SetValue(UpDirectionProperty, value);
		}
	}

	public VerticalAlignment VerticalAlignment
	{
		get
		{
			return (VerticalAlignment)GetValue(VerticalAlignmentProperty);
		}
		set
		{
			SetValue(VerticalAlignmentProperty, value);
		}
	}

	private static void VisualChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((TextVisual3D)d).VisualChanged();
	}

	private void VisualChanged()
	{
		if (string.IsNullOrEmpty(Text))
		{
			base.Content = null;
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
		Material material;
		if (FontSize > 0.0)
		{
			RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)frameworkElement.ActualWidth + 1, (int)frameworkElement.ActualHeight + 1, 96.0, 96.0, PixelFormats.Pbgra32);
			renderTargetBitmap.Render(frameworkElement);
			renderTargetBitmap.Freeze();
			material = new DiffuseMaterial(new ImageBrush(renderTargetBitmap));
		}
		else
		{
			material = new DiffuseMaterial
			{
				Brush = new VisualBrush(frameworkElement)
			};
		}
		double num = frameworkElement.ActualWidth / frameworkElement.ActualHeight * Height;
		Point3D position = Position;
		Vector3D textDirection = TextDirection;
		Vector3D upDirection = UpDirection;
		double height = Height;
		double num2 = -0.5;
		if (HorizontalAlignment == HorizontalAlignment.Left)
		{
			num2 = 0.0;
		}
		if (HorizontalAlignment == HorizontalAlignment.Right)
		{
			num2 = -1.0;
		}
		double num3 = -0.5;
		if (VerticalAlignment == VerticalAlignment.Top)
		{
			num3 = -1.0;
		}
		if (VerticalAlignment == VerticalAlignment.Bottom)
		{
			num3 = 0.0;
		}
		Point3D point3D = position + num2 * num * textDirection + num3 * height * upDirection;
		Point3D value = point3D + upDirection * height;
		Point3D value2 = point3D + textDirection * num;
		Point3D value3 = point3D + upDirection * height + textDirection * num;
		MeshGeometry3D meshGeometry3D = new MeshGeometry3D
		{
			Positions = new Point3DCollection { point3D, value, value2, value3 }
		};
		bool isDoubleSided = IsDoubleSided;
		if (isDoubleSided)
		{
			meshGeometry3D.Positions.Add(point3D);
			meshGeometry3D.Positions.Add(value);
			meshGeometry3D.Positions.Add(value2);
			meshGeometry3D.Positions.Add(value3);
		}
		meshGeometry3D.TriangleIndices.Add(0);
		meshGeometry3D.TriangleIndices.Add(3);
		meshGeometry3D.TriangleIndices.Add(1);
		meshGeometry3D.TriangleIndices.Add(0);
		meshGeometry3D.TriangleIndices.Add(2);
		meshGeometry3D.TriangleIndices.Add(3);
		if (isDoubleSided)
		{
			meshGeometry3D.TriangleIndices.Add(4);
			meshGeometry3D.TriangleIndices.Add(5);
			meshGeometry3D.TriangleIndices.Add(7);
			meshGeometry3D.TriangleIndices.Add(4);
			meshGeometry3D.TriangleIndices.Add(7);
			meshGeometry3D.TriangleIndices.Add(6);
		}
		double x = (IsFlipped ? 1 : 0);
		double x2 = ((!IsFlipped) ? 1 : 0);
		meshGeometry3D.TextureCoordinates.Add(new Point(x, 1.0));
		meshGeometry3D.TextureCoordinates.Add(new Point(x, 0.0));
		meshGeometry3D.TextureCoordinates.Add(new Point(x2, 1.0));
		meshGeometry3D.TextureCoordinates.Add(new Point(x2, 0.0));
		if (isDoubleSided)
		{
			meshGeometry3D.TextureCoordinates.Add(new Point(x2, 1.0));
			meshGeometry3D.TextureCoordinates.Add(new Point(x2, 0.0));
			meshGeometry3D.TextureCoordinates.Add(new Point(x, 1.0));
			meshGeometry3D.TextureCoordinates.Add(new Point(x, 0.0));
		}
		base.Content = new GeometryModel3D(meshGeometry3D, material);
	}
}
