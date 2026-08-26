using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class ViewCubeVisual3D : ModelVisual3D
{
	public class ClickedEventArgs : EventArgs
	{
		public Vector3D LookDirection { get; set; }

		public Vector3D UpDirection { get; set; }
	}

	public static readonly DependencyProperty BackTextProperty = DependencyProperty.Register("BackText", typeof(string), typeof(ViewCubeVisual3D), new UIPropertyMetadata("B", delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Brush cubefaceColor = (d as ViewCubeVisual3D).GetCubefaceColor(1);
		(d as ViewCubeVisual3D).UpdateCubefaceMaterial(1, cubefaceColor, (e.NewValue == null) ? "" : ((string)e.NewValue));
	}));

	public static readonly DependencyProperty BottomTextProperty = DependencyProperty.Register("BottomText", typeof(string), typeof(ViewCubeVisual3D), new UIPropertyMetadata("D", delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Brush cubefaceColor = (d as ViewCubeVisual3D).GetCubefaceColor(5);
		(d as ViewCubeVisual3D).UpdateCubefaceMaterial(5, cubefaceColor, (e.NewValue == null) ? "" : ((string)e.NewValue));
	}));

	public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point3D), typeof(ViewCubeVisual3D), new UIPropertyMetadata(new Point3D(0.0, 0.0, 0.0)));

	public static readonly DependencyProperty FrontTextProperty = DependencyProperty.Register("FrontText", typeof(string), typeof(ViewCubeVisual3D), new UIPropertyMetadata("F", delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Brush cubefaceColor = (d as ViewCubeVisual3D).GetCubefaceColor(0);
		(d as ViewCubeVisual3D).UpdateCubefaceMaterial(0, cubefaceColor, (e.NewValue == null) ? "" : ((string)e.NewValue));
	}));

	public static readonly DependencyProperty LeftTextProperty = DependencyProperty.Register("LeftText", typeof(string), typeof(ViewCubeVisual3D), new UIPropertyMetadata("L", delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Brush cubefaceColor = (d as ViewCubeVisual3D).GetCubefaceColor(2);
		(d as ViewCubeVisual3D).UpdateCubefaceMaterial(2, cubefaceColor, (e.NewValue == null) ? "" : ((string)e.NewValue));
	}));

	public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.Register("IsEnabled", typeof(bool), typeof(ViewCubeVisual3D), new UIPropertyMetadata(true));

	public static readonly DependencyProperty ModelUpDirectionProperty = DependencyProperty.Register("ModelUpDirection", typeof(Vector3D), typeof(ViewCubeVisual3D), new UIPropertyMetadata(new Vector3D(0.0, 0.0, 1.0), VisualModelChanged));

	public static readonly DependencyProperty RightTextProperty = DependencyProperty.Register("RightText", typeof(string), typeof(ViewCubeVisual3D), new UIPropertyMetadata("R", delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Brush cubefaceColor = (d as ViewCubeVisual3D).GetCubefaceColor(3);
		(d as ViewCubeVisual3D).UpdateCubefaceMaterial(3, cubefaceColor, (e.NewValue == null) ? "" : ((string)e.NewValue));
	}));

	public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(double), typeof(ViewCubeVisual3D), new UIPropertyMetadata(5.0));

	public static readonly DependencyProperty TopTextProperty = DependencyProperty.Register("TopText", typeof(string), typeof(ViewCubeVisual3D), new UIPropertyMetadata("U", delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Brush cubefaceColor = (d as ViewCubeVisual3D).GetCubefaceColor(4);
		(d as ViewCubeVisual3D).UpdateCubefaceMaterial(4, cubefaceColor, (e.NewValue == null) ? "" : ((string)e.NewValue));
	}));

	public static readonly DependencyProperty ViewportProperty = DependencyProperty.Register("Viewport", typeof(Viewport3D), typeof(ViewCubeVisual3D), new PropertyMetadata(null));

	public static readonly DependencyProperty EnableEdgeClicksProperty = DependencyProperty.Register("EnableEdgeClicks", typeof(bool), typeof(ViewCubeVisual3D), new PropertyMetadata(false, delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as ViewCubeVisual3D).EnableDisableEdgeClicks();
	}));

	private readonly Dictionary<object, Vector3D> faceNormals = new Dictionary<object, Vector3D>();

	private readonly Dictionary<object, Vector3D> faceUpVectors = new Dictionary<object, Vector3D>();

	private readonly IList<GeometryModel3D> CubeFaceModels = new List<GeometryModel3D>(6);

	private readonly IList<ModelUIElement3D> EdgeModels = new List<ModelUIElement3D>();

	private readonly IList<ModelUIElement3D> CornerModels = new List<ModelUIElement3D>();

	private readonly Brush CornerBrush = Brushes.Gold;

	private readonly Brush EdgeBrush = Brushes.Silver;

	public bool EnableEdgeClicks
	{
		get
		{
			return (bool)GetValue(EnableEdgeClicksProperty);
		}
		set
		{
			SetValue(EnableEdgeClicksProperty, value);
		}
	}

	public string BackText
	{
		get
		{
			return (string)GetValue(BackTextProperty);
		}
		set
		{
			SetValue(BackTextProperty, value);
		}
	}

	public string BottomText
	{
		get
		{
			return (string)GetValue(BottomTextProperty);
		}
		set
		{
			SetValue(BottomTextProperty, value);
		}
	}

	public Point3D Center
	{
		get
		{
			return (Point3D)GetValue(CenterProperty);
		}
		set
		{
			SetValue(CenterProperty, value);
		}
	}

	public string FrontText
	{
		get
		{
			return (string)GetValue(FrontTextProperty);
		}
		set
		{
			SetValue(FrontTextProperty, value);
		}
	}

	public string LeftText
	{
		get
		{
			return (string)GetValue(LeftTextProperty);
		}
		set
		{
			SetValue(LeftTextProperty, value);
		}
	}

	public Vector3D ModelUpDirection
	{
		get
		{
			return (Vector3D)GetValue(ModelUpDirectionProperty);
		}
		set
		{
			SetValue(ModelUpDirectionProperty, value);
		}
	}

	public string RightText
	{
		get
		{
			return (string)GetValue(RightTextProperty);
		}
		set
		{
			SetValue(RightTextProperty, value);
		}
	}

	public double Size
	{
		get
		{
			return (double)GetValue(SizeProperty);
		}
		set
		{
			SetValue(SizeProperty, value);
		}
	}

	public string TopText
	{
		get
		{
			return (string)GetValue(TopTextProperty);
		}
		set
		{
			SetValue(TopTextProperty, value);
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

	[Browsable(false)]
	public Viewport3D Viewport
	{
		get
		{
			return (Viewport3D)GetValue(ViewportProperty);
		}
		set
		{
			SetValue(ViewportProperty, value);
		}
	}

	public event EventHandler<ClickedEventArgs> Clicked;

	public ViewCubeVisual3D()
	{
		UpdateVisuals();
	}

	protected virtual void OnClicked(Vector3D lookDirection, Vector3D upDirection)
	{
		Clicked?.Invoke(this, new ClickedEventArgs
		{
			LookDirection = lookDirection,
			UpDirection = upDirection
		});
	}

	private static void VisualModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ViewCubeVisual3D)d).UpdateVisuals();
	}

	private void UpdateVisuals()
	{
		base.Children.Clear();
		faceNormals.Clear();
		faceUpVectors.Clear();
		CubeFaceModels.Clear();
		EdgeModels.Clear();
		CornerModels.Clear();
		Vector3D modelUpDirection = ModelUpDirection;
		Vector3D vector3D = new Vector3D(modelUpDirection.Y, modelUpDirection.Z, modelUpDirection.X);
		Vector3D vector3D2 = Vector3D.CrossProduct(vector3D, modelUpDirection);
		CubeFaceModels.Add(AddCubeFace(vector3D2, modelUpDirection, GetCubefaceColor(0), FrontText));
		CubeFaceModels.Add(AddCubeFace(-vector3D2, modelUpDirection, GetCubefaceColor(1), BackText));
		CubeFaceModels.Add(AddCubeFace(vector3D, modelUpDirection, GetCubefaceColor(2), LeftText));
		CubeFaceModels.Add(AddCubeFace(-vector3D, modelUpDirection, GetCubefaceColor(3), RightText));
		CubeFaceModels.Add(AddCubeFace(modelUpDirection, vector3D, GetCubefaceColor(4), TopText));
		CubeFaceModels.Add(AddCubeFace(-modelUpDirection, -vector3D, GetCubefaceColor(5), BottomText));
		PieSliceVisual3D pieSliceVisual3D = new PieSliceVisual3D();
		pieSliceVisual3D.BeginEdit();
		pieSliceVisual3D.Center = (ModelUpDirection * ((0.0 - Size) / 2.0)).ToPoint3D();
		pieSliceVisual3D.Normal = ModelUpDirection;
		pieSliceVisual3D.UpVector = vector3D;
		pieSliceVisual3D.InnerRadius = Size;
		pieSliceVisual3D.OuterRadius = Size * 1.3;
		pieSliceVisual3D.StartAngle = 0.0;
		pieSliceVisual3D.EndAngle = 360.0;
		pieSliceVisual3D.Fill = Brushes.Gray;
		pieSliceVisual3D.EndEdit();
		base.Children.Add(pieSliceVisual3D);
		AddCorners();
		AddEdges();
		EnableDisableEdgeClicks();
	}

	private Brush GetCubefaceColor(int index)
	{
		switch (index)
		{
		case 0:
		case 1:
			return Brushes.Red;
		case 2:
		case 3:
			if (ModelUpDirection.Z < 1.0)
			{
				return Brushes.Blue;
			}
			return Brushes.Green;
		case 4:
		case 5:
			if (ModelUpDirection.Z < 1.0)
			{
				return Brushes.Green;
			}
			return Brushes.Blue;
		default:
			return Brushes.White;
		}
	}

	private void EnableDisableEdgeClicks()
	{
		if (EnableEdgeClicks)
		{
			foreach (ModelUIElement3D edgeModel in EdgeModels)
			{
				edgeModel.MouseLeftButtonDown -= FaceMouseLeftButtonDown;
				edgeModel.MouseEnter -= EdggesMouseEnters;
				edgeModel.MouseLeave -= EdgesMouseLeaves;
				edgeModel.MouseLeftButtonDown += FaceMouseLeftButtonDown;
				edgeModel.MouseEnter += EdggesMouseEnters;
				edgeModel.MouseLeave += EdgesMouseLeaves;
				ModelUIElement3D modelUIElement3D = edgeModel;
				(modelUIElement3D.Model as GeometryModel3D).Material = MaterialHelper.CreateMaterial(EdgeBrush);
			}
			{
				foreach (ModelUIElement3D cornerModel in CornerModels)
				{
					cornerModel.MouseLeftButtonDown -= FaceMouseLeftButtonDown;
					cornerModel.MouseEnter -= CornersMouseEnters;
					cornerModel.MouseLeave -= CornersMouseLeave;
					cornerModel.MouseLeftButtonDown += FaceMouseLeftButtonDown;
					cornerModel.MouseEnter += CornersMouseEnters;
					cornerModel.MouseLeave += CornersMouseLeave;
					ModelUIElement3D modelUIElement3D2 = cornerModel;
					(modelUIElement3D2.Model as GeometryModel3D).Material = MaterialHelper.CreateMaterial(CornerBrush);
				}
				return;
			}
		}
		foreach (ModelUIElement3D edgeModel2 in EdgeModels)
		{
			edgeModel2.MouseLeftButtonDown -= FaceMouseLeftButtonDown;
			edgeModel2.MouseEnter -= EdggesMouseEnters;
			edgeModel2.MouseLeave -= EdgesMouseLeaves;
			ModelUIElement3D modelUIElement3D3 = edgeModel2;
			(modelUIElement3D3.Model as GeometryModel3D).Material = MaterialHelper.CreateMaterial(Colors.Transparent);
		}
		foreach (ModelUIElement3D cornerModel2 in CornerModels)
		{
			cornerModel2.MouseLeftButtonDown -= FaceMouseLeftButtonDown;
			cornerModel2.MouseEnter -= CornersMouseEnters;
			cornerModel2.MouseLeave -= CornersMouseLeave;
			ModelUIElement3D modelUIElement3D4 = cornerModel2;
			(modelUIElement3D4.Model as GeometryModel3D).Material = MaterialHelper.CreateMaterial(Colors.Transparent);
		}
	}

	private void UpdateCubefaceMaterial(int index, Brush b, string text)
	{
		if (CubeFaceModels.Count > 0 && index < CubeFaceModels.Count)
		{
			CubeFaceModels[index].Material = CreateTextMaterial(b, text);
		}
		else
		{
			UpdateVisuals();
		}
	}

	private void AddEdges()
	{
		double num = Size / 2.0;
		double num2 = num / 2.0;
		Point3D[] array = new Point3D[4]
		{
			new Point3D(0.0, -1.0, -1.0),
			new Point3D(0.0, 1.0, -1.0),
			new Point3D(0.0, -1.0, 1.0),
			new Point3D(0.0, 1.0, 1.0)
		};
		Point3D[] array2 = array;
		foreach (Point3D point3D in array2)
		{
			Point3D center = point3D.Multiply(num);
			AddEdge(center, 1.5 * num, num2, num2, point3D.ToVector3D());
		}
		Point3D[] array3 = new Point3D[4]
		{
			new Point3D(-1.0, 0.0, -1.0),
			new Point3D(1.0, 0.0, -1.0),
			new Point3D(-1.0, 0.0, 1.0),
			new Point3D(1.0, 0.0, 1.0)
		};
		Point3D[] array4 = array3;
		foreach (Point3D point3D2 in array4)
		{
			Point3D center2 = point3D2.Multiply(num);
			AddEdge(center2, num2, 1.5 * num, num2, point3D2.ToVector3D());
		}
		Point3D[] array5 = new Point3D[4]
		{
			new Point3D(-1.0, -1.0, 0.0),
			new Point3D(-1.0, 1.0, 0.0),
			new Point3D(1.0, -1.0, 0.0),
			new Point3D(1.0, 1.0, 0.0)
		};
		Point3D[] array6 = array5;
		foreach (Point3D point3D3 in array6)
		{
			Point3D center3 = point3D3.Multiply(num);
			AddEdge(center3, num2, num2, 1.5 * num, point3D3.ToVector3D());
		}
	}

	private void AddEdge(Point3D center, double x, double y, double z, Vector3D faceNormal)
	{
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false);
		meshBuilder.AddBox(center, x, y, z);
		MeshGeometry3D meshGeometry3D = meshBuilder.ToMesh();
		meshGeometry3D.Freeze();
		GeometryModel3D model = new GeometryModel3D
		{
			Geometry = meshGeometry3D,
			Material = MaterialHelper.CreateMaterial(EdgeBrush)
		};
		ModelUIElement3D modelUIElement3D = new ModelUIElement3D
		{
			Model = model
		};
		faceNormals.Add(modelUIElement3D, faceNormal);
		faceUpVectors.Add(modelUIElement3D, ModelUpDirection);
		modelUIElement3D.MouseLeftButtonDown += FaceMouseLeftButtonDown;
		modelUIElement3D.MouseEnter += EdggesMouseEnters;
		modelUIElement3D.MouseLeave += EdgesMouseLeaves;
		base.Children.Add(modelUIElement3D);
		EdgeModels.Add(modelUIElement3D);
	}

	private void AddCorners()
	{
		double num = Size / 2.0;
		double num2 = num / 2.0;
		Point3D[] array = new Point3D[8]
		{
			new Point3D(-1.0, -1.0, -1.0),
			new Point3D(1.0, -1.0, -1.0),
			new Point3D(1.0, 1.0, -1.0),
			new Point3D(-1.0, 1.0, -1.0),
			new Point3D(-1.0, -1.0, 1.0),
			new Point3D(1.0, -1.0, 1.0),
			new Point3D(1.0, 1.0, 1.0),
			new Point3D(-1.0, 1.0, 1.0)
		};
		Point3D[] array2 = array;
		foreach (Point3D point3D in array2)
		{
			MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false);
			Point3D center = point3D.Multiply(num);
			meshBuilder.AddBox(center, num2, num2, num2);
			MeshGeometry3D meshGeometry3D = meshBuilder.ToMesh();
			meshGeometry3D.Freeze();
			GeometryModel3D model = new GeometryModel3D
			{
				Geometry = meshGeometry3D,
				Material = MaterialHelper.CreateMaterial(CornerBrush)
			};
			ModelUIElement3D modelUIElement3D = new ModelUIElement3D
			{
				Model = model
			};
			faceNormals.Add(modelUIElement3D, point3D.ToVector3D());
			faceUpVectors.Add(modelUIElement3D, ModelUpDirection);
			modelUIElement3D.MouseLeftButtonDown += FaceMouseLeftButtonDown;
			modelUIElement3D.MouseEnter += CornersMouseEnters;
			modelUIElement3D.MouseLeave += CornersMouseLeave;
			base.Children.Add(modelUIElement3D);
			CornerModels.Add(modelUIElement3D);
		}
	}

	private void EdgesMouseLeaves(object sender, MouseEventArgs e)
	{
		ModelUIElement3D modelUIElement3D = sender as ModelUIElement3D;
		(modelUIElement3D.Model as GeometryModel3D).Material = MaterialHelper.CreateMaterial(Colors.Silver);
	}

	private void EdggesMouseEnters(object sender, MouseEventArgs e)
	{
		ModelUIElement3D modelUIElement3D = sender as ModelUIElement3D;
		(modelUIElement3D.Model as GeometryModel3D).Material = MaterialHelper.CreateMaterial(Colors.Goldenrod);
	}

	private void CornersMouseLeave(object sender, MouseEventArgs e)
	{
		ModelUIElement3D modelUIElement3D = sender as ModelUIElement3D;
		(modelUIElement3D.Model as GeometryModel3D).Material = MaterialHelper.CreateMaterial(Colors.Gold);
	}

	private void CornersMouseEnters(object sender, MouseEventArgs e)
	{
		ModelUIElement3D modelUIElement3D = sender as ModelUIElement3D;
		(modelUIElement3D.Model as GeometryModel3D).Material = MaterialHelper.CreateMaterial(Colors.Goldenrod);
	}

	private GeometryModel3D AddCubeFace(Vector3D normal, Vector3D up, Brush b, string text)
	{
		Material material = CreateTextMaterial(b, text);
		double size = Size;
		MeshBuilder meshBuilder = new MeshBuilder(generateNormals: false);
		meshBuilder.AddCubeFace(Center, normal, up, size, size, size);
		MeshGeometry3D meshGeometry3D = meshBuilder.ToMesh();
		meshGeometry3D.Freeze();
		GeometryModel3D geometryModel3D = new GeometryModel3D
		{
			Geometry = meshGeometry3D,
			Material = material
		};
		ModelUIElement3D modelUIElement3D = new ModelUIElement3D
		{
			Model = geometryModel3D
		};
		modelUIElement3D.MouseLeftButtonDown += FaceMouseLeftButtonDown;
		faceNormals.Add(modelUIElement3D, normal);
		faceUpVectors.Add(modelUIElement3D, up);
		base.Children.Add(modelUIElement3D);
		return geometryModel3D;
	}

	private Material CreateTextMaterial(Brush b, string text)
	{
		Grid grid = new Grid
		{
			Width = 20.0,
			Height = 20.0,
			Background = b
		};
		grid.Children.Add(new TextBlock
		{
			Text = text,
			VerticalAlignment = VerticalAlignment.Center,
			HorizontalAlignment = HorizontalAlignment.Center,
			FontSize = 15.0,
			Foreground = Brushes.White
		});
		grid.Arrange(new Rect(new Point(0.0, 0.0), new Size(20.0, 20.0)));
		RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)grid.Width, (int)grid.Height, 96.0, 96.0, PixelFormats.Default);
		renderTargetBitmap.Render(grid);
		return MaterialHelper.CreateMaterial(new ImageBrush(renderTargetBitmap));
	}

	private void FaceMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		if (!IsEnabled)
		{
			return;
		}
		Vector3D vector3D = faceNormals[sender];
		Vector3D vector3D2 = faceUpVectors[sender];
		Vector3D vector3D3 = -vector3D;
		Vector3D vector3D4 = vector3D2;
		vector3D3.Normalize();
		vector3D4.Normalize();
		if (e.ClickCount == 2)
		{
			vector3D3 *= -1.0;
			if (vector3D4 != ModelUpDirection)
			{
				vector3D4 *= -1.0;
			}
		}
		if (Viewport != null && Viewport.Camera is ProjectionCamera projectionCamera)
		{
			Point3D point3D = projectionCamera.Position + projectionCamera.LookDirection;
			double length = projectionCamera.LookDirection.Length;
			vector3D3 *= length;
			Point3D newPosition = point3D - vector3D3;
			projectionCamera.AnimateTo(newPosition, vector3D3, vector3D4, 500.0);
		}
		e.Handled = true;
		OnClicked(vector3D3, vector3D4);
	}
}
