using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class TextGroupVisual3D : ModelVisual3D
{
	public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(TextGroupVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(TextGroupVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(TextGroupVisual3D), new UIPropertyMetadata(new Thickness(1.0), VisualChanged));

	public static readonly DependencyProperty FontFamilyProperty = DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(TextGroupVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register("FontSize", typeof(double), typeof(TextGroupVisual3D), new UIPropertyMetadata(10.0, VisualChanged));

	public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(TextGroupVisual3D), new UIPropertyMetadata(FontWeights.Normal, VisualChanged));

	public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register("Foreground", typeof(Brush), typeof(TextGroupVisual3D), new UIPropertyMetadata(Brushes.Black, VisualChanged));

	public static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height", typeof(double), typeof(TextGroupVisual3D), new UIPropertyMetadata(1.0, VisualChanged));

	public static readonly DependencyProperty IsDoubleSidedProperty = DependencyProperty.Register("IsDoubleSided", typeof(bool), typeof(TextGroupVisual3D), new UIPropertyMetadata(false, VisualChanged));

	public static readonly DependencyProperty IsFlippedProperty = DependencyProperty.Register("IsFlipped", typeof(bool), typeof(TextGroupVisual3D), new PropertyMetadata(false, VisualChanged));

	public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(IList<SpatialTextItem>), typeof(TextGroupVisual3D), new UIPropertyMetadata(new List<SpatialTextItem>(), VisualChanged));

	public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register("Padding", typeof(Thickness), typeof(TextGroupVisual3D), new UIPropertyMetadata(new Thickness(0.0), VisualChanged));

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

	public IList<SpatialTextItem> Items
	{
		get
		{
			return (IList<SpatialTextItem>)GetValue(ItemsProperty);
		}
		set
		{
			SetValue(ItemsProperty, value);
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

	public static Material CreateTextMaterial(IEnumerable<TextItem> items, Func<string, FrameworkElement> createElement, Brush background, out Dictionary<string, FrameworkElement> elementMap, out Dictionary<FrameworkElement, Rect> elementPositions)
	{
		WrapPanel wrapPanel = new WrapPanel();
		elementMap = new Dictionary<string, FrameworkElement>();
		double num = 16.0;
		foreach (TextItem item in items)
		{
			if (!elementMap.ContainsKey(item.Text))
			{
				FrameworkElement frameworkElement = createElement(item.Text);
				frameworkElement.Measure(new Size(2048.0, 2048.0));
				num = Math.Max(num, frameworkElement.DesiredSize.Width);
				elementMap[item.Text] = frameworkElement;
				wrapPanel.Children.Add(frameworkElement);
			}
		}
		int num2 = (int)OptimizeSize(wrapPanel, num, 1024.0);
		int num3 = (int)Math.Min(num2, wrapPanel.ActualHeight);
		elementPositions = new Dictionary<FrameworkElement, Rect>();
		foreach (FrameworkElement child in wrapPanel.Children)
		{
			Point point = child.TranslatePoint(new Point(0.0, 0.0), wrapPanel);
			double num4 = (int)Math.Floor(point.X);
			double num5 = (int)Math.Floor(point.Y);
			double num6 = (int)Math.Ceiling(point.X + child.RenderSize.Width);
			double num7 = (int)Math.Ceiling(point.Y + child.RenderSize.Height);
			elementPositions[child] = new Rect(num4 / (double)num2, num5 / (double)num3, (num6 - num4) / (double)num2, (num7 - num5) / (double)num3);
		}
		RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(num2, num3, 96.0, 96.0, PixelFormats.Pbgra32);
		renderTargetBitmap.Render(wrapPanel);
		renderTargetBitmap.Freeze();
		ImageBrush brush = new ImageBrush(renderTargetBitmap)
		{
			Stretch = Stretch.Fill,
			ViewboxUnits = BrushMappingMode.RelativeToBoundingBox,
			Viewbox = new Rect(0.0, 0.0, 1.0, 1.0),
			ViewportUnits = BrushMappingMode.Absolute,
			Viewport = new Rect(0.0, 0.0, 1.0, 1.0),
			TileMode = TileMode.None,
			AlignmentX = AlignmentX.Left,
			AlignmentY = AlignmentY.Top
		};
		if (background != null && !background.Equals(Brushes.Transparent))
		{
			MaterialGroup materialGroup = new MaterialGroup();
			materialGroup.Children.Add(new DiffuseMaterial(Brushes.Black));
			materialGroup.Children.Add(new EmissiveMaterial(brush));
			return materialGroup;
		}
		return new DiffuseMaterial(brush)
		{
			Color = Colors.White
		};
	}

	private static double OptimizeSize(UIElement panel, double minWidth, double maxWidth)
	{
		double num;
		for (num = minWidth; num < maxWidth; num += 50.0)
		{
			panel.Measure(new Size(num, num + 1.0));
			if (panel.DesiredSize.Height <= num)
			{
				break;
			}
		}
		panel.Arrange(new Rect(0.0, 0.0, num, num));
		return num;
	}

	private static void VisualChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((TextGroupVisual3D)d).VisualChanged();
	}

	private FrameworkElement CreateElement(string text)
	{
		TextBlock textBlock = new TextBlock(new Run(text))
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
		if (BorderBrush != null)
		{
			return new Border
			{
				BorderBrush = BorderBrush,
				BorderThickness = BorderThickness,
				Child = textBlock
			};
		}
		return textBlock;
	}

	private void VisualChanged()
	{
		if (Items == null)
		{
			base.Content = null;
			return;
		}
		List<SpatialTextItem> list = Items.Where((SpatialTextItem i) => !string.IsNullOrEmpty(i.Text)).ToList();
		Model3DGroup model3DGroup = new Model3DGroup();
		while (list.Count > 0)
		{
			Material material = CreateTextMaterial(list, CreateElement, Background, out var elementMap, out var elementPositions);
			MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false);
			List<SpatialTextItem> list2 = new List<SpatialTextItem>();
			foreach (SpatialTextItem item in list)
			{
				FrameworkElement frameworkElement = elementMap[item.Text];
				Rect rect = elementPositions[frameworkElement];
				double num = rect.Left;
				double top = rect.Top;
				double num2 = rect.Right;
				double bottom = rect.Bottom;
				if (bottom > 1.0)
				{
					break;
				}
				if (IsFlipped)
				{
					double num3 = num;
					num = num2;
					num2 = num3;
				}
				double num4 = -0.5;
				if (item.HorizontalAlignment == HorizontalAlignment.Left)
				{
					num4 = 0.0;
				}
				if (item.HorizontalAlignment == HorizontalAlignment.Right)
				{
					num4 = -1.0;
				}
				double num5 = -0.5;
				if (item.VerticalAlignment == VerticalAlignment.Top)
				{
					num5 = -1.0;
				}
				if (item.VerticalAlignment == VerticalAlignment.Bottom)
				{
					num5 = 0.0;
				}
				Point3D position = item.Position;
				Vector3D textDirection = item.TextDirection;
				Vector3D upDirection = item.UpDirection;
				double height = Height;
				double num6 = Height / frameworkElement.ActualHeight * frameworkElement.ActualWidth;
				Point3D point3D = position + num4 * num6 * textDirection + num5 * height * upDirection;
				Point3D point3D2 = point3D + textDirection * num6;
				Point3D point3D3 = point3D + upDirection * height + textDirection * num6;
				Point3D point3D4 = point3D + upDirection * height;
				meshBuilder.AddQuad(point3D, point3D2, point3D3, point3D4, new Point(num, bottom), new Point(num2, bottom), new Point(num2, top), new Point(num, top));
				if (IsDoubleSided)
				{
					meshBuilder.AddQuad(point3D2, point3D, point3D4, point3D3, new Point(num, bottom), new Point(num2, bottom), new Point(num2, top), new Point(num, top));
				}
				list2.Add(item);
			}
			MeshGeometry3D geometry = meshBuilder.ToMesh();
			model3DGroup.Children.Add(new GeometryModel3D(geometry, material));
			foreach (SpatialTextItem item2 in list2)
			{
				list.Remove(item2);
			}
		}
		base.Content = model3DGroup;
	}
}
