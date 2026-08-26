using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

[ContentProperty("Items")]
public class BillboardTextGroupVisual3D : RenderingModelVisual3D, IBoundsIgnoredVisual3D
{
	public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(BillboardTextGroupVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(BillboardTextGroupVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(BillboardTextGroupVisual3D), new UIPropertyMetadata(new Thickness(1.0), VisualChanged));

	public static readonly DependencyProperty FontFamilyProperty = DependencyProperty.Register("FontFamily", typeof(FontFamily), typeof(BillboardTextGroupVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register("FontSize", typeof(double), typeof(BillboardTextGroupVisual3D), new UIPropertyMetadata(0.0, VisualChanged));

	public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(BillboardTextGroupVisual3D), new UIPropertyMetadata(FontWeights.Normal, VisualChanged));

	public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register("Foreground", typeof(Brush), typeof(BillboardTextGroupVisual3D), new UIPropertyMetadata(Brushes.Black, VisualChanged));

	public static readonly DependencyProperty HeightFactorProperty = DependencyProperty.Register("HeightFactor", typeof(double), typeof(BillboardTextGroupVisual3D), new PropertyMetadata(1.0, VisualChanged));

	public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(IList<BillboardTextItem>), typeof(BillboardTextGroupVisual3D), new UIPropertyMetadata(null, VisualChanged));

	public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register("Padding", typeof(Thickness), typeof(BillboardTextGroupVisual3D), new UIPropertyMetadata(new Thickness(0.0), VisualChanged));

	public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register("Offset", typeof(Vector), typeof(BillboardTextGroupVisual3D), new PropertyMetadata(new Vector(0.0, 0.0), VisualChanged));

	public static readonly DependencyProperty PinWidthProperty = DependencyProperty.Register("PinWidth", typeof(double), typeof(BillboardTextGroupVisual3D), new PropertyMetadata(4.0));

	public static readonly DependencyProperty PinBrushProperty = DependencyProperty.Register("PinBrush", typeof(Brush), typeof(BillboardTextGroupVisual3D), new PropertyMetadata(Brushes.Black, VisualChanged));

	public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.Register("IsEnabled", typeof(bool), typeof(BillboardTextGroupVisual3D), new PropertyMetadata(true));

	private readonly BillboardGeometryBuilder builder;

	private readonly Dictionary<MeshGeometry3D, IList<Billboard>> meshes = new Dictionary<MeshGeometry3D, IList<Billboard>>();

	private readonly Dictionary<MeshGeometry3D, IList<Billboard>> pinMeshes = new Dictionary<MeshGeometry3D, IList<Billboard>>();

	private bool isRendering;

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

	public bool IsEnabled
	{
		get
		{
			return (bool)GetValue(IsEnabledProperty);
		}
		set
		{
			SetValue(IsEnabledProperty, value);
		}
	}

	public Brush PinBrush
	{
		get
		{
			return (Brush)GetValue(PinBrushProperty);
		}
		set
		{
			SetValue(PinBrushProperty, value);
		}
	}

	public double PinWidth
	{
		get
		{
			return (double)GetValue(PinWidthProperty);
		}
		set
		{
			SetValue(PinWidthProperty, value);
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

	public bool IsRendering
	{
		get
		{
			return isRendering;
		}
		set
		{
			if (value != isRendering)
			{
				isRendering = value;
				if (isRendering)
				{
					SubscribeToRenderingEvent();
				}
				else
				{
					UnsubscribeRenderingEvent();
				}
			}
		}
	}

	public IList<BillboardTextItem> Items
	{
		get
		{
			return (IList<BillboardTextItem>)GetValue(ItemsProperty);
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

	public Vector Offset
	{
		get
		{
			return (Vector)GetValue(OffsetProperty);
		}
		set
		{
			SetValue(OffsetProperty, value);
		}
	}

	public BillboardTextGroupVisual3D()
	{
		builder = new BillboardGeometryBuilder(this);
	}

	protected override void OnCompositionTargetRendering(object sender, RenderingEventArgs eventArgs)
	{
		if (isRendering && IsEnabled && this.IsAttachedToViewport3D() && UpdateTransforms())
		{
			UpdateGeometry();
		}
	}

	protected override void OnVisualParentChanged(DependencyObject oldParent)
	{
		base.OnVisualParentChanged(oldParent);
		DependencyObject parent = VisualTreeHelper.GetParent(this);
		IsRendering = parent != null;
	}

	protected void UpdateGeometry()
	{
		foreach (KeyValuePair<MeshGeometry3D, IList<Billboard>> mesh in meshes)
		{
			mesh.Key.Positions = builder.GetPositions(mesh.Value, Offset);
		}
		foreach (KeyValuePair<MeshGeometry3D, IList<Billboard>> pinMesh in pinMeshes)
		{
			pinMesh.Key.Positions = builder.GetPinPositions(pinMesh.Value, Offset, PinWidth);
		}
	}

	protected bool UpdateTransforms()
	{
		return builder.UpdateTransforms();
	}

	private static void VisualChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((BillboardTextGroupVisual3D)d).VisualChanged();
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
		meshes.Clear();
		pinMeshes.Clear();
		if (Items == null)
		{
			base.Content = null;
			return;
		}
		DiffuseMaterial material = new DiffuseMaterial(PinBrush);
		List<BillboardTextItem> list = Items.Where((BillboardTextItem i) => !string.IsNullOrEmpty(i.Text)).ToList();
		Model3DGroup model3DGroup = new Model3DGroup();
		while (list.Count > 0)
		{
			Material material2 = TextGroupVisual3D.CreateTextMaterial(list, CreateElement, Background, out var elementMap, out var elementPositions);
			material2.Freeze();
			List<Billboard> list2 = new List<Billboard>();
			List<BillboardTextItem> list3 = new List<BillboardTextItem>();
			PointCollection pointCollection = new PointCollection();
			foreach (BillboardTextItem item in list)
			{
				FrameworkElement frameworkElement = elementMap[item.Text];
				Rect rect = elementPositions[frameworkElement];
				if (rect.Bottom > 1.0)
				{
					break;
				}
				list2.Add(new Billboard(item.Position, frameworkElement.ActualWidth, frameworkElement.ActualHeight, item.HorizontalAlignment, item.VerticalAlignment, item.DepthOffset, item.WorldDepthOffset));
				pointCollection.Add(new Point(rect.Left, rect.Bottom));
				pointCollection.Add(new Point(rect.Right, rect.Bottom));
				pointCollection.Add(new Point(rect.Right, rect.Top));
				pointCollection.Add(new Point(rect.Left, rect.Top));
				list3.Add(item);
			}
			Int32Collection int32Collection = BillboardGeometryBuilder.CreateIndices(list2.Count);
			int32Collection.Freeze();
			MeshGeometry3D meshGeometry3D = new MeshGeometry3D
			{
				TriangleIndices = int32Collection,
				TextureCoordinates = pointCollection,
				Positions = builder.GetPositions(list2, Offset)
			};
			model3DGroup.Children.Add(new GeometryModel3D(meshGeometry3D, material2));
			meshes.Add(meshGeometry3D, list2);
			if (Offset.Length > 0.0)
			{
				MeshGeometry3D meshGeometry3D2 = new MeshGeometry3D
				{
					TriangleIndices = int32Collection,
					Positions = builder.GetPinPositions(list2, Offset, PinWidth)
				};
				model3DGroup.Children.Add(new GeometryModel3D(meshGeometry3D2, material));
				pinMeshes.Add(meshGeometry3D2, list2);
			}
			foreach (BillboardTextItem item2 in list3)
			{
				list.Remove(item2);
			}
		}
		base.Content = model3DGroup;
	}
}
