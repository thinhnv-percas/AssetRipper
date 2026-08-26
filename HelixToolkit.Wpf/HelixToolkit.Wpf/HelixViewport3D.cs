using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

[ContentProperty("Children")]
[TemplatePart(Name = "PART_CameraController", Type = typeof(CameraController))]
[TemplatePart(Name = "PART_ViewportGrid", Type = typeof(Grid))]
[TemplatePart(Name = "PART_AdornerLayer", Type = typeof(AdornerDecorator))]
[TemplatePart(Name = "PART_CoordinateView", Type = typeof(Viewport3D))]
[TemplatePart(Name = "PART_ViewCubeViewport", Type = typeof(Viewport3D))]
[Localizability(LocalizationCategory.NeverLocalize)]
public class HelixViewport3D : ItemsControl, IHelixViewport3D
{
	public static readonly DependencyProperty BackViewGestureProperty;

	public static readonly DependencyProperty BottomViewGestureProperty;

	public static readonly RoutedEvent CameraChangedEvent;

	public static readonly DependencyProperty CameraInertiaFactorProperty;

	public static readonly DependencyProperty CameraInfoProperty;

	public static readonly DependencyProperty CameraModeProperty;

	public static readonly DependencyProperty CameraRotationModeProperty;

	public static readonly DependencyProperty ChangeFieldOfViewCursorProperty;

	public static readonly DependencyProperty ChangeFieldOfViewGestureProperty;

	public static readonly DependencyProperty ChangeLookAtGestureProperty;

	public static readonly DependencyProperty CoordinateSystemHeightProperty;

	public static readonly DependencyProperty CoordinateSystemHorizontalPositionProperty;

	public static readonly DependencyProperty CoordinateSystemLabelForegroundProperty;

	public static readonly DependencyProperty CoordinateSystemLabelXProperty;

	public static readonly DependencyProperty CoordinateSystemLabelYProperty;

	public static readonly DependencyProperty CoordinateSystemLabelZProperty;

	public static readonly DependencyProperty CoordinateSystemVerticalPositionProperty;

	public static readonly DependencyProperty CoordinateSystemWidthProperty;

	public static readonly DependencyProperty CurrentPositionProperty;

	public static readonly DependencyProperty EnableCurrentPositionProperty;

	public static readonly DependencyProperty CalculateCursorPositionProperty;

	public static readonly DependencyProperty CursorPositionProperty;

	public static readonly DependencyProperty CursorOnElementPositionProperty;

	public static readonly DependencyProperty CursorOnConstructionPlanePositionProperty;

	public static readonly DependencyProperty ConstructionPlaneProperty;

	public static readonly DependencyProperty CursorRayProperty;

	public static readonly DependencyProperty DebugInfoProperty;

	public static readonly DependencyProperty DefaultCameraProperty;

	public static readonly DependencyProperty FieldOfViewTextProperty;

	public static readonly DependencyProperty FrameRateProperty;

	public static readonly DependencyProperty FrameRateTextProperty;

	public static readonly DependencyProperty FrontViewGestureProperty;

	public static readonly DependencyProperty InfiniteSpinProperty;

	public static readonly DependencyProperty InfoBackgroundProperty;

	public static readonly DependencyProperty InfoForegroundProperty;

	public static readonly DependencyProperty IsChangeFieldOfViewEnabledProperty;

	public static readonly DependencyProperty IsHeadlightEnabledProperty;

	public static readonly DependencyProperty IsInertiaEnabledProperty;

	public static readonly DependencyProperty IsPanEnabledProperty;

	public static readonly DependencyProperty IsMoveEnabledProperty;

	public static readonly DependencyProperty IsViewCubeEdgeClicksEnabledProperty;

	public static readonly DependencyProperty IsRotationEnabledProperty;

	public static readonly DependencyProperty IsTouchZoomEnabledProperty;

	public static readonly DependencyProperty IsZoomEnabledProperty;

	public static readonly DependencyProperty LeftRightPanSensitivityProperty;

	public static readonly DependencyProperty LeftRightRotationSensitivityProperty;

	public static readonly DependencyProperty LeftViewGestureProperty;

	public static readonly RoutedEvent LookAtChangedEvent;

	public static readonly DependencyProperty MaximumFieldOfViewProperty;

	public static readonly DependencyProperty MinimumFieldOfViewProperty;

	public static readonly DependencyProperty ModelUpDirectionProperty;

	public static readonly DependencyProperty OrthographicProperty;

	public static readonly DependencyProperty OrthographicToggleGestureProperty;

	public static readonly DependencyProperty PageUpDownZoomSensitivityProperty;

	public static readonly DependencyProperty PanCursorProperty;

	public static readonly DependencyProperty PanGesture2Property;

	public static readonly DependencyProperty PanGestureProperty;

	public static readonly DependencyProperty ResetCameraGestureProperty;

	public static readonly DependencyProperty ResetCameraKeyGestureProperty;

	public static readonly DependencyProperty RightViewGestureProperty;

	public static readonly DependencyProperty RotateAroundMouseDownPointProperty;

	public static readonly DependencyProperty RotateCursorProperty;

	public static readonly DependencyProperty RotateGesture2Property;

	public static readonly DependencyProperty RotateGestureProperty;

	public static readonly DependencyProperty RotationSensitivityProperty;

	public static readonly DependencyProperty ShowCameraInfoProperty;

	public static readonly DependencyProperty ShowCameraTargetProperty;

	public static readonly DependencyProperty ShowCoordinateSystemProperty;

	public static readonly DependencyProperty ShowFieldOfViewProperty;

	public static readonly DependencyProperty ShowFrameRateProperty;

	public static readonly DependencyProperty ShowTriangleCountInfoProperty;

	public static readonly DependencyProperty ShowViewCubeProperty;

	public static readonly DependencyProperty StatusProperty;

	public static readonly DependencyProperty SubTitleProperty;

	public static readonly DependencyProperty SubTitleSizeProperty;

	public static readonly DependencyProperty TextBrushProperty;

	public static readonly DependencyProperty TitleBackgroundProperty;

	public static readonly DependencyProperty TitleFontFamilyProperty;

	public static readonly DependencyProperty TitleProperty;

	public static readonly DependencyProperty TitleSizeProperty;

	public static readonly DependencyProperty TopViewGestureProperty;

	public static readonly DependencyProperty TriangleCountInfoProperty;

	public static readonly DependencyProperty UpDownPanSensitivityProperty;

	public static readonly DependencyProperty UpDownRotationSensitivityProperty;

	public static readonly DependencyProperty ViewCubeBackTextProperty;

	public static readonly DependencyProperty ViewCubeBottomTextProperty;

	public static readonly DependencyProperty ViewCubeFrontTextProperty;

	public static readonly DependencyProperty ViewCubeHeightProperty;

	public static readonly DependencyProperty ViewCubeHorizontalPositionProperty;

	public static readonly DependencyProperty ViewCubeLeftTextProperty;

	public static readonly DependencyProperty ViewCubeOpacityProperty;

	public static readonly DependencyProperty ViewCubeRightTextProperty;

	public static readonly DependencyProperty ViewCubeTopTextProperty;

	public static readonly DependencyProperty ViewCubeVerticalPositionProperty;

	public static readonly DependencyProperty ViewCubeWidthProperty;

	public static readonly DependencyProperty ZoomAroundMouseDownPointProperty;

	public static readonly DependencyProperty ZoomCursorProperty;

	public static readonly DependencyProperty ZoomExtentsGestureProperty;

	public static readonly DependencyProperty ZoomExtentsWhenLoadedProperty;

	public static readonly DependencyProperty ZoomGesture2Property;

	public static readonly DependencyProperty ZoomGestureProperty;

	public static readonly DependencyProperty ZoomRectangleCursorProperty;

	public static readonly DependencyProperty ZoomRectangleGestureProperty;

	public static readonly DependencyProperty ZoomSensitivityProperty;

	public static readonly RoutedEvent ZoomedByRectangleEvent;

	private const string PartAdornerLayer = "PART_AdornerLayer";

	private const string PartViewportGrid = "PART_ViewportGrid";

	private const string PartCameraController = "PART_CameraController";

	private const string PartCoordinateView = "PART_CoordinateView";

	private const string PartViewCube = "PART_ViewCube";

	private const string PartViewCubeViewport = "PART_ViewCubeViewport";

	private readonly Stopwatch fpsWatch = new Stopwatch();

	private readonly DirectionalLight headLight = new DirectionalLight
	{
		Color = Colors.White
	};

	private readonly Model3DGroup lights;

	private readonly OrthographicCamera orthographicCamera;

	private readonly PerspectiveCamera perspectiveCamera;

	private readonly RenderingEventListener renderingEventListener;

	private readonly Viewport3D viewport;

	private AdornerDecorator adornerLayer;

	private CameraController cameraController;

	private Model3DGroup coordinateSystemLights;

	private Viewport3D coordinateView;

	private Camera currentCamera;

	private int frameCounter;

	private bool hasBeenLoadedBefore;

	private int infoFrameCounter;

	private bool isSubscribedToRenderingEvent;

	private ViewCubeVisual3D viewCube;

	private Model3DGroup viewCubeLights;

	private Viewport3D viewCubeViewport;

	public static RoutedCommand OrthographicToggleCommand { get; private set; }

	public InputGesture BackViewGesture
	{
		get
		{
			return (InputGesture)GetValue(BackViewGestureProperty);
		}
		set
		{
			SetValue(BackViewGestureProperty, value);
		}
	}

	public InputGesture BottomViewGesture
	{
		get
		{
			return (InputGesture)GetValue(BottomViewGestureProperty);
		}
		set
		{
			SetValue(BottomViewGestureProperty, value);
		}
	}

	public ProjectionCamera Camera
	{
		get
		{
			return Viewport.Camera as ProjectionCamera;
		}
		set
		{
			if (currentCamera != null)
			{
				currentCamera.Changed -= CameraPropertyChanged;
			}
			Viewport.Camera = value;
			currentCamera = Viewport.Camera;
			currentCamera.Changed += CameraPropertyChanged;
		}
	}

	public CameraController CameraController => cameraController;

	public double CameraInertiaFactor
	{
		get
		{
			return (double)GetValue(CameraInertiaFactorProperty);
		}
		set
		{
			SetValue(CameraInertiaFactorProperty, value);
		}
	}

	public string CameraInfo
	{
		get
		{
			return (string)GetValue(CameraInfoProperty);
		}
		private set
		{
			SetValue(CameraInfoProperty, value);
		}
	}

	public CameraMode CameraMode
	{
		get
		{
			return (CameraMode)GetValue(CameraModeProperty);
		}
		set
		{
			SetValue(CameraModeProperty, value);
		}
	}

	public CameraRotationMode CameraRotationMode
	{
		get
		{
			return (CameraRotationMode)GetValue(CameraRotationModeProperty);
		}
		set
		{
			SetValue(CameraRotationModeProperty, value);
		}
	}

	public Cursor ChangeFieldOfViewCursor
	{
		get
		{
			return (Cursor)GetValue(ChangeFieldOfViewCursorProperty);
		}
		set
		{
			SetValue(ChangeFieldOfViewCursorProperty, value);
		}
	}

	public MouseGesture ChangeFieldOfViewGesture
	{
		get
		{
			return (MouseGesture)GetValue(ChangeFieldOfViewGestureProperty);
		}
		set
		{
			SetValue(ChangeFieldOfViewGestureProperty, value);
		}
	}

	public MouseGesture ChangeLookAtGesture
	{
		get
		{
			return (MouseGesture)GetValue(ChangeLookAtGestureProperty);
		}
		set
		{
			SetValue(ChangeLookAtGestureProperty, value);
		}
	}

	public Visual3DCollection Children => viewport.Children;

	public double CoordinateSystemHeight
	{
		get
		{
			return (double)GetValue(CoordinateSystemHeightProperty);
		}
		set
		{
			SetValue(CoordinateSystemHeightProperty, value);
		}
	}

	public HorizontalAlignment CoordinateSystemHorizontalPosition
	{
		get
		{
			return (HorizontalAlignment)GetValue(CoordinateSystemHorizontalPositionProperty);
		}
		set
		{
			SetValue(CoordinateSystemHorizontalPositionProperty, value);
		}
	}

	public Brush CoordinateSystemLabelForeground
	{
		get
		{
			return (Brush)GetValue(CoordinateSystemLabelForegroundProperty);
		}
		set
		{
			SetValue(CoordinateSystemLabelForegroundProperty, value);
		}
	}

	public string CoordinateSystemLabelX
	{
		get
		{
			return (string)GetValue(CoordinateSystemLabelXProperty);
		}
		set
		{
			SetValue(CoordinateSystemLabelXProperty, value);
		}
	}

	public string CoordinateSystemLabelY
	{
		get
		{
			return (string)GetValue(CoordinateSystemLabelYProperty);
		}
		set
		{
			SetValue(CoordinateSystemLabelYProperty, value);
		}
	}

	public string CoordinateSystemLabelZ
	{
		get
		{
			return (string)GetValue(CoordinateSystemLabelZProperty);
		}
		set
		{
			SetValue(CoordinateSystemLabelZProperty, value);
		}
	}

	public VerticalAlignment CoordinateSystemVerticalPosition
	{
		get
		{
			return (VerticalAlignment)GetValue(CoordinateSystemVerticalPositionProperty);
		}
		set
		{
			SetValue(CoordinateSystemVerticalPositionProperty, value);
		}
	}

	public double CoordinateSystemWidth
	{
		get
		{
			return (double)GetValue(CoordinateSystemWidthProperty);
		}
		set
		{
			SetValue(CoordinateSystemWidthProperty, value);
		}
	}

	[Obsolete("CurrentPosition is now obsolete, please use CursorPosition instead", false)]
	public Point3D CurrentPosition
	{
		get
		{
			return (Point3D)GetValue(CurrentPositionProperty);
		}
		set
		{
			SetValue(CurrentPositionProperty, value);
		}
	}

	public string DebugInfo
	{
		get
		{
			return (string)GetValue(DebugInfoProperty);
		}
		set
		{
			SetValue(DebugInfoProperty, value);
		}
	}

	public ProjectionCamera DefaultCamera
	{
		get
		{
			return (ProjectionCamera)GetValue(DefaultCameraProperty);
		}
		set
		{
			SetValue(DefaultCameraProperty, value);
		}
	}

	[Obsolete("EnableCurrentPosition is now obsolete, please use CalculateCursorPosition instead", false)]
	public bool EnableCurrentPosition
	{
		get
		{
			return CalculateCursorPosition;
		}
		set
		{
			CalculateCursorPosition = value;
		}
	}

	public bool CalculateCursorPosition
	{
		get
		{
			return (bool)GetValue(CalculateCursorPositionProperty);
		}
		set
		{
			SetValue(CalculateCursorPositionProperty, value);
		}
	}

	public Point3D? CursorPosition
	{
		get
		{
			return (Point3D?)GetValue(CursorPositionProperty);
		}
		private set
		{
			SetValue(CursorPositionProperty, value);
		}
	}

	public Point3D? CursorOnConstructionPlanePosition
	{
		get
		{
			return (Point3D?)GetValue(CursorOnConstructionPlanePositionProperty);
		}
		private set
		{
			SetValue(CursorOnConstructionPlanePositionProperty, value);
		}
	}

	public Plane3D ConstructionPlane
	{
		get
		{
			return (Plane3D)GetValue(ConstructionPlaneProperty);
		}
		set
		{
			SetValue(ConstructionPlaneProperty, value);
		}
	}

	public Ray3D CursorRay
	{
		get
		{
			return (Ray3D)GetValue(CursorRayProperty);
		}
		private set
		{
			SetValue(CursorRayProperty, value);
		}
	}

	public Point3D? CursorOnElementPosition
	{
		get
		{
			return (Point3D?)GetValue(CursorOnElementPositionProperty);
		}
		private set
		{
			SetValue(CursorOnElementPositionProperty, value);
		}
	}

	public string FieldOfViewText
	{
		get
		{
			return (string)GetValue(FieldOfViewTextProperty);
		}
		private set
		{
			SetValue(FieldOfViewTextProperty, value);
		}
	}

	public int FrameRate
	{
		get
		{
			return (int)GetValue(FrameRateProperty);
		}
		private set
		{
			SetValue(FrameRateProperty, value);
		}
	}

	public string FrameRateText
	{
		get
		{
			return (string)GetValue(FrameRateTextProperty);
		}
		private set
		{
			SetValue(FrameRateTextProperty, value);
		}
	}

	public InputGesture FrontViewGesture
	{
		get
		{
			return (InputGesture)GetValue(FrontViewGestureProperty);
		}
		set
		{
			SetValue(FrontViewGestureProperty, value);
		}
	}

	public bool InfiniteSpin
	{
		get
		{
			return (bool)GetValue(InfiniteSpinProperty);
		}
		set
		{
			SetValue(InfiniteSpinProperty, value);
		}
	}

	public Brush InfoBackground
	{
		get
		{
			return (Brush)GetValue(InfoBackgroundProperty);
		}
		set
		{
			SetValue(InfoBackgroundProperty, value);
		}
	}

	public Brush InfoForeground
	{
		get
		{
			return (Brush)GetValue(InfoForegroundProperty);
		}
		set
		{
			SetValue(InfoForegroundProperty, value);
		}
	}

	public bool IsChangeFieldOfViewEnabled
	{
		get
		{
			return (bool)GetValue(IsChangeFieldOfViewEnabledProperty);
		}
		set
		{
			SetValue(IsChangeFieldOfViewEnabledProperty, value);
		}
	}

	public bool IsHeadLightEnabled
	{
		get
		{
			return (bool)GetValue(IsHeadlightEnabledProperty);
		}
		set
		{
			SetValue(IsHeadlightEnabledProperty, value);
		}
	}

	public bool IsInertiaEnabled
	{
		get
		{
			return (bool)GetValue(IsInertiaEnabledProperty);
		}
		set
		{
			SetValue(IsInertiaEnabledProperty, value);
		}
	}

	public bool IsPanEnabled
	{
		get
		{
			return (bool)GetValue(IsPanEnabledProperty);
		}
		set
		{
			SetValue(IsPanEnabledProperty, value);
		}
	}

	public bool IsMoveEnabled
	{
		get
		{
			return (bool)GetValue(IsMoveEnabledProperty);
		}
		set
		{
			SetValue(IsMoveEnabledProperty, value);
		}
	}

	public bool IsViewCubeEdgeClicksEnabled
	{
		get
		{
			return (bool)GetValue(IsViewCubeEdgeClicksEnabledProperty);
		}
		set
		{
			SetValue(IsViewCubeEdgeClicksEnabledProperty, value);
		}
	}

	public bool IsRotationEnabled
	{
		get
		{
			return (bool)GetValue(IsRotationEnabledProperty);
		}
		set
		{
			SetValue(IsRotationEnabledProperty, value);
		}
	}

	public bool IsTouchZoomEnabled
	{
		get
		{
			return (bool)GetValue(IsTouchZoomEnabledProperty);
		}
		set
		{
			SetValue(IsTouchZoomEnabledProperty, value);
		}
	}

	public bool IsZoomEnabled
	{
		get
		{
			return (bool)GetValue(IsZoomEnabledProperty);
		}
		set
		{
			SetValue(IsZoomEnabledProperty, value);
		}
	}

	public double LeftRightPanSensitivity
	{
		get
		{
			return (double)GetValue(LeftRightPanSensitivityProperty);
		}
		set
		{
			SetValue(LeftRightPanSensitivityProperty, value);
		}
	}

	public double LeftRightRotationSensitivity
	{
		get
		{
			return (double)GetValue(LeftRightRotationSensitivityProperty);
		}
		set
		{
			SetValue(LeftRightRotationSensitivityProperty, value);
		}
	}

	public InputGesture LeftViewGesture
	{
		get
		{
			return (InputGesture)GetValue(LeftViewGestureProperty);
		}
		set
		{
			SetValue(LeftViewGestureProperty, value);
		}
	}

	public Model3DGroup Lights => lights;

	public double MaximumFieldOfView
	{
		get
		{
			return (double)GetValue(MaximumFieldOfViewProperty);
		}
		set
		{
			SetValue(MaximumFieldOfViewProperty, value);
		}
	}

	public double MinimumFieldOfView
	{
		get
		{
			return (double)GetValue(MinimumFieldOfViewProperty);
		}
		set
		{
			SetValue(MinimumFieldOfViewProperty, value);
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

	public bool Orthographic
	{
		get
		{
			return (bool)GetValue(OrthographicProperty);
		}
		set
		{
			SetValue(OrthographicProperty, value);
		}
	}

	public InputGesture OrthographicToggleGesture
	{
		get
		{
			return (InputGesture)GetValue(OrthographicToggleGestureProperty);
		}
		set
		{
			SetValue(OrthographicToggleGestureProperty, value);
		}
	}

	public double PageUpDownZoomSensitivity
	{
		get
		{
			return (double)GetValue(PageUpDownZoomSensitivityProperty);
		}
		set
		{
			SetValue(PageUpDownZoomSensitivityProperty, value);
		}
	}

	public Cursor PanCursor
	{
		get
		{
			return (Cursor)GetValue(PanCursorProperty);
		}
		set
		{
			SetValue(PanCursorProperty, value);
		}
	}

	public MouseGesture PanGesture
	{
		get
		{
			return (MouseGesture)GetValue(PanGestureProperty);
		}
		set
		{
			SetValue(PanGestureProperty, value);
		}
	}

	public MouseGesture PanGesture2
	{
		get
		{
			return (MouseGesture)GetValue(PanGesture2Property);
		}
		set
		{
			SetValue(PanGesture2Property, value);
		}
	}

	public InputGesture ResetCameraGesture
	{
		get
		{
			return (InputGesture)GetValue(ResetCameraGestureProperty);
		}
		set
		{
			SetValue(ResetCameraGestureProperty, value);
		}
	}

	public KeyGesture ResetCameraKeyGesture
	{
		get
		{
			return (KeyGesture)GetValue(ResetCameraKeyGestureProperty);
		}
		set
		{
			SetValue(ResetCameraKeyGestureProperty, value);
		}
	}

	public InputGesture RightViewGesture
	{
		get
		{
			return (InputGesture)GetValue(RightViewGestureProperty);
		}
		set
		{
			SetValue(RightViewGestureProperty, value);
		}
	}

	public bool RotateAroundMouseDownPoint
	{
		get
		{
			return (bool)GetValue(RotateAroundMouseDownPointProperty);
		}
		set
		{
			SetValue(RotateAroundMouseDownPointProperty, value);
		}
	}

	public Cursor RotateCursor
	{
		get
		{
			return (Cursor)GetValue(RotateCursorProperty);
		}
		set
		{
			SetValue(RotateCursorProperty, value);
		}
	}

	public MouseGesture RotateGesture
	{
		get
		{
			return (MouseGesture)GetValue(RotateGestureProperty);
		}
		set
		{
			SetValue(RotateGestureProperty, value);
		}
	}

	public MouseGesture RotateGesture2
	{
		get
		{
			return (MouseGesture)GetValue(RotateGesture2Property);
		}
		set
		{
			SetValue(RotateGesture2Property, value);
		}
	}

	public double RotationSensitivity
	{
		get
		{
			return (double)GetValue(RotationSensitivityProperty);
		}
		set
		{
			SetValue(RotationSensitivityProperty, value);
		}
	}

	public bool ShowCameraInfo
	{
		get
		{
			return (bool)GetValue(ShowCameraInfoProperty);
		}
		set
		{
			SetValue(ShowCameraInfoProperty, value);
		}
	}

	public bool ShowCameraTarget
	{
		get
		{
			return (bool)GetValue(ShowCameraTargetProperty);
		}
		set
		{
			SetValue(ShowCameraTargetProperty, value);
		}
	}

	public bool ShowCoordinateSystem
	{
		get
		{
			return (bool)GetValue(ShowCoordinateSystemProperty);
		}
		set
		{
			SetValue(ShowCoordinateSystemProperty, value);
		}
	}

	public bool ShowFieldOfView
	{
		get
		{
			return (bool)GetValue(ShowFieldOfViewProperty);
		}
		set
		{
			SetValue(ShowFieldOfViewProperty, value);
		}
	}

	public bool ShowFrameRate
	{
		get
		{
			return (bool)GetValue(ShowFrameRateProperty);
		}
		set
		{
			SetValue(ShowFrameRateProperty, value);
		}
	}

	public bool ShowTriangleCountInfo
	{
		get
		{
			return (bool)GetValue(ShowTriangleCountInfoProperty);
		}
		set
		{
			SetValue(ShowTriangleCountInfoProperty, value);
		}
	}

	public bool ShowViewCube
	{
		get
		{
			return (bool)GetValue(ShowViewCubeProperty);
		}
		set
		{
			SetValue(ShowViewCubeProperty, value);
		}
	}

	public string Status
	{
		get
		{
			return (string)GetValue(StatusProperty);
		}
		set
		{
			SetValue(StatusProperty, value);
		}
	}

	public string SubTitle
	{
		get
		{
			return (string)GetValue(SubTitleProperty);
		}
		set
		{
			SetValue(SubTitleProperty, value);
		}
	}

	public double SubTitleSize
	{
		get
		{
			return (double)GetValue(SubTitleSizeProperty);
		}
		set
		{
			SetValue(SubTitleSizeProperty, value);
		}
	}

	public Brush TextBrush
	{
		get
		{
			return (Brush)GetValue(TextBrushProperty);
		}
		set
		{
			SetValue(TextBrushProperty, value);
		}
	}

	public string Title
	{
		get
		{
			return (string)GetValue(TitleProperty);
		}
		set
		{
			SetValue(TitleProperty, value);
		}
	}

	public Brush TitleBackground
	{
		get
		{
			return (Brush)GetValue(TitleBackgroundProperty);
		}
		set
		{
			SetValue(TitleBackgroundProperty, value);
		}
	}

	public FontFamily TitleFontFamily
	{
		get
		{
			return (FontFamily)GetValue(TitleFontFamilyProperty);
		}
		set
		{
			SetValue(TitleFontFamilyProperty, value);
		}
	}

	public double TitleSize
	{
		get
		{
			return (double)GetValue(TitleSizeProperty);
		}
		set
		{
			SetValue(TitleSizeProperty, value);
		}
	}

	public InputGesture TopViewGesture
	{
		get
		{
			return (InputGesture)GetValue(TopViewGestureProperty);
		}
		set
		{
			SetValue(TopViewGestureProperty, value);
		}
	}

	public string TriangleCountInfo
	{
		get
		{
			return (string)GetValue(TriangleCountInfoProperty);
		}
		private set
		{
			SetValue(TriangleCountInfoProperty, value);
		}
	}

	public double UpDownPanSensitivity
	{
		get
		{
			return (double)GetValue(UpDownPanSensitivityProperty);
		}
		set
		{
			SetValue(UpDownPanSensitivityProperty, value);
		}
	}

	public double UpDownRotationSensitivity
	{
		get
		{
			return (double)GetValue(UpDownRotationSensitivityProperty);
		}
		set
		{
			SetValue(UpDownRotationSensitivityProperty, value);
		}
	}

	public string ViewCubeBackText
	{
		get
		{
			return (string)GetValue(ViewCubeBackTextProperty);
		}
		set
		{
			SetValue(ViewCubeBackTextProperty, value);
		}
	}

	public string ViewCubeBottomText
	{
		get
		{
			return (string)GetValue(ViewCubeBottomTextProperty);
		}
		set
		{
			SetValue(ViewCubeBottomTextProperty, value);
		}
	}

	public string ViewCubeFrontText
	{
		get
		{
			return (string)GetValue(ViewCubeFrontTextProperty);
		}
		set
		{
			SetValue(ViewCubeFrontTextProperty, value);
		}
	}

	public double ViewCubeHeight
	{
		get
		{
			return (double)GetValue(ViewCubeHeightProperty);
		}
		set
		{
			SetValue(ViewCubeHeightProperty, value);
		}
	}

	public HorizontalAlignment ViewCubeHorizontalPosition
	{
		get
		{
			return (HorizontalAlignment)GetValue(ViewCubeHorizontalPositionProperty);
		}
		set
		{
			SetValue(ViewCubeHorizontalPositionProperty, value);
		}
	}

	public string ViewCubeLeftText
	{
		get
		{
			return (string)GetValue(ViewCubeLeftTextProperty);
		}
		set
		{
			SetValue(ViewCubeLeftTextProperty, value);
		}
	}

	public double ViewCubeOpacity
	{
		get
		{
			return (double)GetValue(ViewCubeOpacityProperty);
		}
		set
		{
			SetValue(ViewCubeOpacityProperty, value);
		}
	}

	public string ViewCubeRightText
	{
		get
		{
			return (string)GetValue(ViewCubeRightTextProperty);
		}
		set
		{
			SetValue(ViewCubeRightTextProperty, value);
		}
	}

	public string ViewCubeTopText
	{
		get
		{
			return (string)GetValue(ViewCubeTopTextProperty);
		}
		set
		{
			SetValue(ViewCubeTopTextProperty, value);
		}
	}

	public VerticalAlignment ViewCubeVerticalPosition
	{
		get
		{
			return (VerticalAlignment)GetValue(ViewCubeVerticalPositionProperty);
		}
		set
		{
			SetValue(ViewCubeVerticalPositionProperty, value);
		}
	}

	public double ViewCubeWidth
	{
		get
		{
			return (double)GetValue(ViewCubeWidthProperty);
		}
		set
		{
			SetValue(ViewCubeWidthProperty, value);
		}
	}

	public Viewport3D Viewport => viewport;

	public bool ZoomAroundMouseDownPoint
	{
		get
		{
			return (bool)GetValue(ZoomAroundMouseDownPointProperty);
		}
		set
		{
			SetValue(ZoomAroundMouseDownPointProperty, value);
		}
	}

	public Cursor ZoomCursor
	{
		get
		{
			return (Cursor)GetValue(ZoomCursorProperty);
		}
		set
		{
			SetValue(ZoomCursorProperty, value);
		}
	}

	public InputGesture ZoomExtentsGesture
	{
		get
		{
			return (InputGesture)GetValue(ZoomExtentsGestureProperty);
		}
		set
		{
			SetValue(ZoomExtentsGestureProperty, value);
		}
	}

	public bool ZoomExtentsWhenLoaded
	{
		get
		{
			return (bool)GetValue(ZoomExtentsWhenLoadedProperty);
		}
		set
		{
			SetValue(ZoomExtentsWhenLoadedProperty, value);
		}
	}

	public MouseGesture ZoomGesture
	{
		get
		{
			return (MouseGesture)GetValue(ZoomGestureProperty);
		}
		set
		{
			SetValue(ZoomGestureProperty, value);
		}
	}

	public MouseGesture ZoomGesture2
	{
		get
		{
			return (MouseGesture)GetValue(ZoomGesture2Property);
		}
		set
		{
			SetValue(ZoomGesture2Property, value);
		}
	}

	public Cursor ZoomRectangleCursor
	{
		get
		{
			return (Cursor)GetValue(ZoomRectangleCursorProperty);
		}
		set
		{
			SetValue(ZoomRectangleCursorProperty, value);
		}
	}

	public MouseGesture ZoomRectangleGesture
	{
		get
		{
			return (MouseGesture)GetValue(ZoomRectangleGestureProperty);
		}
		set
		{
			SetValue(ZoomRectangleGestureProperty, value);
		}
	}

	public double ZoomSensitivity
	{
		get
		{
			return (double)GetValue(ZoomSensitivityProperty);
		}
		set
		{
			SetValue(ZoomSensitivityProperty, value);
		}
	}

	public event RoutedEventHandler CameraChanged
	{
		add
		{
			AddHandler(CameraChangedEvent, value);
		}
		remove
		{
			RemoveHandler(CameraChangedEvent, value);
		}
	}

	public event RoutedEventHandler LookAtChanged
	{
		add
		{
			AddHandler(LookAtChangedEvent, value);
		}
		remove
		{
			RemoveHandler(LookAtChangedEvent, value);
		}
	}

	public event RoutedEventHandler ZoomedByRectangle
	{
		add
		{
			AddHandler(ZoomedByRectangleEvent, value);
		}
		remove
		{
			RemoveHandler(ZoomedByRectangleEvent, value);
		}
	}

	static HelixViewport3D()
	{
		BackViewGestureProperty = DependencyProperty.Register("BackViewGesture", typeof(InputGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new KeyGesture(Key.B, ModifierKeys.Control)));
		BottomViewGestureProperty = DependencyProperty.Register("BottomViewGesture", typeof(InputGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new KeyGesture(Key.D, ModifierKeys.Control)));
		CameraChangedEvent = EventManager.RegisterRoutedEvent("CameraChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(HelixViewport3D));
		CameraInertiaFactorProperty = DependencyProperty.Register("CameraInertiaFactor", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(0.93));
		CameraInfoProperty = DependencyProperty.Register("CameraInfo", typeof(string), typeof(HelixViewport3D), new UIPropertyMetadata(null));
		CameraModeProperty = DependencyProperty.Register("CameraMode", typeof(CameraMode), typeof(HelixViewport3D), new UIPropertyMetadata(CameraMode.Inspect));
		CameraRotationModeProperty = DependencyProperty.Register("CameraRotationMode", typeof(CameraRotationMode), typeof(HelixViewport3D), new UIPropertyMetadata(CameraRotationMode.Turntable, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((HelixViewport3D)s).OnCameraRotationModeChanged();
		}));
		ChangeFieldOfViewCursorProperty = DependencyProperty.Register("ChangeFieldOfViewCursor", typeof(Cursor), typeof(HelixViewport3D), new UIPropertyMetadata(Cursors.ScrollNS));
		ChangeFieldOfViewGestureProperty = DependencyProperty.Register("ChangeFieldOfViewGesture", typeof(MouseGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new MouseGesture(MouseAction.RightClick, ModifierKeys.Alt)));
		ChangeLookAtGestureProperty = DependencyProperty.Register("ChangeLookAtGesture", typeof(MouseGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new MouseGesture(MouseAction.RightDoubleClick)));
		CoordinateSystemHeightProperty = DependencyProperty.Register("CoordinateSystemHeight", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(80.0));
		CoordinateSystemHorizontalPositionProperty = DependencyProperty.Register("CoordinateSystemHorizontalPosition", typeof(HorizontalAlignment), typeof(HelixViewport3D), new UIPropertyMetadata(HorizontalAlignment.Left));
		CoordinateSystemLabelForegroundProperty = DependencyProperty.Register("CoordinateSystemLabelForeground", typeof(Brush), typeof(HelixViewport3D), new PropertyMetadata(Brushes.Black));
		CoordinateSystemLabelXProperty = DependencyProperty.Register("CoordinateSystemLabelX", typeof(string), typeof(HelixViewport3D), new PropertyMetadata("X"));
		CoordinateSystemLabelYProperty = DependencyProperty.Register("CoordinateSystemLabelY", typeof(string), typeof(HelixViewport3D), new PropertyMetadata("Y"));
		CoordinateSystemLabelZProperty = DependencyProperty.Register("CoordinateSystemLabelZ", typeof(string), typeof(HelixViewport3D), new PropertyMetadata("Z"));
		CoordinateSystemVerticalPositionProperty = DependencyProperty.Register("CoordinateSystemVerticalPosition", typeof(VerticalAlignment), typeof(HelixViewport3D), new UIPropertyMetadata(VerticalAlignment.Bottom));
		CoordinateSystemWidthProperty = DependencyProperty.Register("CoordinateSystemWidth", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(80.0));
		CurrentPositionProperty = DependencyProperty.Register("CurrentPosition", typeof(Point3D), typeof(HelixViewport3D), new FrameworkPropertyMetadata(new Point3D(0.0, 0.0, 0.0)));
		EnableCurrentPositionProperty = DependencyProperty.Register("EnableCurrentPosition", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(false));
		CalculateCursorPositionProperty = DependencyProperty.Register("CalculateCursorPosition", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(false));
		CursorPositionProperty = DependencyProperty.Register("CursorPosition", typeof(Point3D?), typeof(HelixViewport3D), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
		CursorOnElementPositionProperty = DependencyProperty.Register("CursorOnElementPosition", typeof(Point3D?), typeof(HelixViewport3D), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
		CursorOnConstructionPlanePositionProperty = DependencyProperty.Register("CursorOnConstructionPlanePosition", typeof(Point3D?), typeof(HelixViewport3D), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
		ConstructionPlaneProperty = DependencyProperty.Register("ConstructionPlane", typeof(Plane3D), typeof(HelixViewport3D), new FrameworkPropertyMetadata(new Plane3D(new Point3D(0.0, 0.0, 0.0), new Vector3D(0.0, 0.0, 1.0)), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
		CursorRayProperty = DependencyProperty.Register("CursorRay", typeof(Ray3D), typeof(HelixViewport3D), new FrameworkPropertyMetadata(new Ray3D(new Point3D(0.0, 0.0, 0.0), new Vector3D(0.0, 0.0, -1.0)), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
		DebugInfoProperty = DependencyProperty.Register("DebugInfo", typeof(string), typeof(HelixViewport3D), new UIPropertyMetadata(null));
		DefaultCameraProperty = DependencyProperty.Register("DefaultCamera", typeof(ProjectionCamera), typeof(HelixViewport3D), new UIPropertyMetadata(null));
		FieldOfViewTextProperty = DependencyProperty.Register("FieldOfViewText", typeof(string), typeof(HelixViewport3D), new UIPropertyMetadata(null));
		FrameRateProperty = DependencyProperty.Register("FrameRate", typeof(int), typeof(HelixViewport3D));
		FrameRateTextProperty = DependencyProperty.Register("FrameRateText", typeof(string), typeof(HelixViewport3D), new UIPropertyMetadata(null));
		FrontViewGestureProperty = DependencyProperty.Register("FrontViewGesture", typeof(InputGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new KeyGesture(Key.F, ModifierKeys.Control)));
		InfiniteSpinProperty = DependencyProperty.Register("InfiniteSpin", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(false));
		InfoBackgroundProperty = DependencyProperty.Register("InfoBackground", typeof(Brush), typeof(HelixViewport3D), new UIPropertyMetadata(new SolidColorBrush(Color.FromArgb(128, byte.MaxValue, byte.MaxValue, byte.MaxValue))));
		InfoForegroundProperty = DependencyProperty.Register("InfoForeground", typeof(Brush), typeof(HelixViewport3D), new UIPropertyMetadata(Brushes.Black));
		IsChangeFieldOfViewEnabledProperty = DependencyProperty.Register("IsChangeFieldOfViewEnabled", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(true));
		IsHeadlightEnabledProperty = DependencyProperty.Register("IsHeadLightEnabled", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((HelixViewport3D)s).OnHeadlightChanged();
		}));
		IsInertiaEnabledProperty = DependencyProperty.Register("IsInertiaEnabled", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(true));
		IsPanEnabledProperty = DependencyProperty.Register("IsPanEnabled", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(true));
		IsMoveEnabledProperty = DependencyProperty.Register("IsMoveEnabled", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(true));
		IsViewCubeEdgeClicksEnabledProperty = DependencyProperty.Register("IsViewCubeEdgeClicksEnabled", typeof(bool), typeof(HelixViewport3D), new PropertyMetadata(false));
		IsRotationEnabledProperty = DependencyProperty.Register("IsRotationEnabled", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(true));
		IsTouchZoomEnabledProperty = DependencyProperty.Register("IsTouchZoomEnabled", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(true));
		IsZoomEnabledProperty = DependencyProperty.Register("IsZoomEnabled", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(true));
		LeftRightPanSensitivityProperty = DependencyProperty.Register("LeftRightPanSensitivity", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(1.0));
		LeftRightRotationSensitivityProperty = DependencyProperty.Register("LeftRightRotationSensitivity", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(1.0));
		LeftViewGestureProperty = DependencyProperty.Register("LeftViewGesture", typeof(InputGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new KeyGesture(Key.L, ModifierKeys.Control)));
		LookAtChangedEvent = EventManager.RegisterRoutedEvent("LookAtChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(HelixViewport3D));
		MaximumFieldOfViewProperty = DependencyProperty.Register("MaximumFieldOfView", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(140.0));
		MinimumFieldOfViewProperty = DependencyProperty.Register("MinimumFieldOfView", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(5.0));
		ModelUpDirectionProperty = DependencyProperty.Register("ModelUpDirection", typeof(Vector3D), typeof(HelixViewport3D), new FrameworkPropertyMetadata(new Vector3D(0.0, 0.0, 1.0), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
		OrthographicProperty = DependencyProperty.Register("Orthographic", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((HelixViewport3D)s).OnOrthographicChanged();
		}));
		OrthographicToggleGestureProperty = DependencyProperty.Register("OrthographicToggleGesture", typeof(InputGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new KeyGesture(Key.O, ModifierKeys.Control | ModifierKeys.Shift)));
		PageUpDownZoomSensitivityProperty = DependencyProperty.Register("PageUpDownZoomSensitivity", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(1.0));
		PanCursorProperty = DependencyProperty.Register("PanCursor", typeof(Cursor), typeof(HelixViewport3D), new UIPropertyMetadata(Cursors.Hand));
		PanGesture2Property = DependencyProperty.Register("PanGesture2", typeof(MouseGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new MouseGesture(MouseAction.MiddleClick)));
		PanGestureProperty = DependencyProperty.Register("PanGesture", typeof(MouseGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new MouseGesture(MouseAction.RightClick, ModifierKeys.Shift)));
		ResetCameraGestureProperty = DependencyProperty.Register("ResetCameraGesture", typeof(InputGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new MouseGesture(MouseAction.MiddleDoubleClick)));
		ResetCameraKeyGestureProperty = DependencyProperty.Register("ResetCameraKeyGesture", typeof(KeyGesture), typeof(HelixViewport3D), new FrameworkPropertyMetadata(new KeyGesture(Key.Home), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
		RightViewGestureProperty = DependencyProperty.Register("RightViewGesture", typeof(InputGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new KeyGesture(Key.R, ModifierKeys.Control)));
		RotateAroundMouseDownPointProperty = DependencyProperty.Register("RotateAroundMouseDownPoint", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(false));
		RotateCursorProperty = DependencyProperty.Register("RotateCursor", typeof(Cursor), typeof(HelixViewport3D), new UIPropertyMetadata(Cursors.SizeAll));
		RotateGesture2Property = DependencyProperty.Register("RotateGesture2", typeof(MouseGesture), typeof(HelixViewport3D), new UIPropertyMetadata(null));
		RotateGestureProperty = DependencyProperty.Register("RotateGesture", typeof(MouseGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new MouseGesture(MouseAction.RightClick)));
		RotationSensitivityProperty = DependencyProperty.Register("RotationSensitivity", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(1.0));
		ShowCameraInfoProperty = DependencyProperty.Register("ShowCameraInfo", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((HelixViewport3D)s).UpdateCameraInfo();
		}));
		ShowCameraTargetProperty = DependencyProperty.Register("ShowCameraTarget", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(true));
		ShowCoordinateSystemProperty = DependencyProperty.Register("ShowCoordinateSystem", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(false));
		ShowFieldOfViewProperty = DependencyProperty.Register("ShowFieldOfView", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((HelixViewport3D)s).UpdateFieldOfViewInfo();
		}));
		ShowFrameRateProperty = DependencyProperty.Register("ShowFrameRate", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((HelixViewport3D)s).OnShowFrameRateChanged();
		}));
		ShowTriangleCountInfoProperty = DependencyProperty.Register("ShowTriangleCountInfo", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(false, delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((HelixViewport3D)s).OnShowTriangleCountInfoChanged();
		}));
		ShowViewCubeProperty = DependencyProperty.Register("ShowViewCube", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(true));
		StatusProperty = DependencyProperty.Register("Status", typeof(string), typeof(HelixViewport3D), new UIPropertyMetadata(null));
		SubTitleProperty = DependencyProperty.Register("SubTitle", typeof(string), typeof(HelixViewport3D), new UIPropertyMetadata(null));
		SubTitleSizeProperty = DependencyProperty.Register("SubTitleSize", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(12.0));
		TextBrushProperty = DependencyProperty.Register("TextBrush", typeof(Brush), typeof(HelixViewport3D), new UIPropertyMetadata(Brushes.Black));
		TitleBackgroundProperty = DependencyProperty.Register("TitleBackground", typeof(Brush), typeof(HelixViewport3D), new UIPropertyMetadata(null));
		TitleFontFamilyProperty = DependencyProperty.Register("TitleFontFamily", typeof(FontFamily), typeof(HelixViewport3D), new UIPropertyMetadata(null));
		TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(HelixViewport3D), new UIPropertyMetadata(null));
		TitleSizeProperty = DependencyProperty.Register("TitleSize", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(12.0));
		TopViewGestureProperty = DependencyProperty.Register("TopViewGesture", typeof(InputGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new KeyGesture(Key.U, ModifierKeys.Control)));
		TriangleCountInfoProperty = DependencyProperty.Register("TriangleCountInfo", typeof(string), typeof(HelixViewport3D), new UIPropertyMetadata(null));
		UpDownPanSensitivityProperty = DependencyProperty.Register("UpDownPanSensitivity", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(1.0));
		UpDownRotationSensitivityProperty = DependencyProperty.Register("UpDownRotationSensitivity", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(1.0));
		ViewCubeBackTextProperty = DependencyProperty.Register("ViewCubeBackText", typeof(string), typeof(HelixViewport3D), new UIPropertyMetadata("B"));
		ViewCubeBottomTextProperty = DependencyProperty.Register("ViewCubeBottomText", typeof(string), typeof(HelixViewport3D), new UIPropertyMetadata("D"));
		ViewCubeFrontTextProperty = DependencyProperty.Register("ViewCubeFrontText", typeof(string), typeof(HelixViewport3D), new UIPropertyMetadata("F"));
		ViewCubeHeightProperty = DependencyProperty.Register("ViewCubeHeight", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(80.0));
		ViewCubeHorizontalPositionProperty = DependencyProperty.Register("ViewCubeHorizontalPosition", typeof(HorizontalAlignment), typeof(HelixViewport3D), new UIPropertyMetadata(HorizontalAlignment.Right));
		ViewCubeLeftTextProperty = DependencyProperty.Register("ViewCubeLeftText", typeof(string), typeof(HelixViewport3D), new UIPropertyMetadata("L"));
		ViewCubeOpacityProperty = DependencyProperty.Register("ViewCubeOpacity", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(0.5));
		ViewCubeRightTextProperty = DependencyProperty.Register("ViewCubeRightText", typeof(string), typeof(HelixViewport3D), new UIPropertyMetadata("R"));
		ViewCubeTopTextProperty = DependencyProperty.Register("ViewCubeTopText", typeof(string), typeof(HelixViewport3D), new UIPropertyMetadata("U"));
		ViewCubeVerticalPositionProperty = DependencyProperty.Register("ViewCubeVerticalPosition", typeof(VerticalAlignment), typeof(HelixViewport3D), new UIPropertyMetadata(VerticalAlignment.Bottom));
		ViewCubeWidthProperty = DependencyProperty.Register("ViewCubeWidth", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(80.0));
		ZoomAroundMouseDownPointProperty = DependencyProperty.Register("ZoomAroundMouseDownPoint", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(false));
		ZoomCursorProperty = DependencyProperty.Register("ZoomCursor", typeof(Cursor), typeof(HelixViewport3D), new UIPropertyMetadata(Cursors.SizeNS));
		ZoomExtentsGestureProperty = DependencyProperty.Register("ZoomExtentsGesture", typeof(InputGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new KeyGesture(Key.E, ModifierKeys.Control | ModifierKeys.Shift)));
		ZoomExtentsWhenLoadedProperty = DependencyProperty.Register("ZoomExtentsWhenLoaded", typeof(bool), typeof(HelixViewport3D), new UIPropertyMetadata(false));
		ZoomGesture2Property = DependencyProperty.Register("ZoomGesture2", typeof(MouseGesture), typeof(HelixViewport3D), new UIPropertyMetadata(null));
		ZoomGestureProperty = DependencyProperty.Register("ZoomGesture", typeof(MouseGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new MouseGesture(MouseAction.RightClick, ModifierKeys.Control)));
		ZoomRectangleCursorProperty = DependencyProperty.Register("ZoomRectangleCursor", typeof(Cursor), typeof(HelixViewport3D), new UIPropertyMetadata(Cursors.ScrollSE));
		ZoomRectangleGestureProperty = DependencyProperty.Register("ZoomRectangleGesture", typeof(MouseGesture), typeof(HelixViewport3D), new UIPropertyMetadata(new MouseGesture(MouseAction.RightClick, ModifierKeys.Control | ModifierKeys.Shift)));
		ZoomSensitivityProperty = DependencyProperty.Register("ZoomSensitivity", typeof(double), typeof(HelixViewport3D), new UIPropertyMetadata(1.0));
		ZoomedByRectangleEvent = EventManager.RegisterRoutedEvent("ZoomedByRectangle", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(HelixViewport3D));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(HelixViewport3D), new FrameworkPropertyMetadata(typeof(HelixViewport3D)));
		UIElement.ClipToBoundsProperty.OverrideMetadata(typeof(HelixViewport3D), new FrameworkPropertyMetadata(true));
		OrthographicToggleCommand = new RoutedCommand();
	}

	public HelixViewport3D()
	{
		viewport = new Viewport3D();
		lights = new Model3DGroup();
		viewport.Children.Add(new ModelVisual3D
		{
			Content = lights
		});
		perspectiveCamera = new PerspectiveCamera();
		orthographicCamera = new OrthographicCamera();
		perspectiveCamera.Reset();
		orthographicCamera.Reset();
		Camera = (Orthographic ? ((ProjectionCamera)orthographicCamera) : ((ProjectionCamera)perspectiveCamera));
		fpsWatch.Start();
		base.Loaded += OnControlLoaded;
		base.Unloaded += OnControlUnloaded;
		base.CommandBindings.Add(new CommandBinding(ApplicationCommands.Copy, CopyHandler));
		base.CommandBindings.Add(new CommandBinding(OrthographicToggleCommand, OrthographicToggle));
		renderingEventListener = new RenderingEventListener(CompositionTargetRendering);
	}

	public void ChangeCameraDirection(Vector3D newDirection, double animationTime = 0.0)
	{
		if (cameraController != null)
		{
			cameraController.ChangeDirection(newDirection, animationTime);
		}
	}

	public void Copy()
	{
		Viewport.Copy(Viewport.ActualWidth * 2.0, Viewport.ActualHeight * 2.0, Brushes.White, 2);
	}

	public void CopyXaml()
	{
		Clipboard.SetText(XamlHelper.GetXaml(Viewport.Children));
	}

	public void Export(string fileName)
	{
		Viewport.Export(fileName, base.Background);
	}

	public void ExportStereo(string fileName, double stereoBase)
	{
		Viewport.ExportStereo(fileName, stereoBase, base.Background);
	}

	public bool FindNearest(Point pt, out Point3D pos, out Vector3D normal, out DependencyObject obj)
	{
		return Viewport.FindNearest(pt, out pos, out normal, out obj);
	}

	public Point3D? FindNearestPoint(Point pt)
	{
		return Viewport.FindNearestPoint(pt);
	}

	public Visual3D FindNearestVisual(Point pt)
	{
		return Viewport.FindNearestVisual(pt);
	}

	public void LookAt(Point3D target, double animationTime = 0.0)
	{
		Camera.LookAt(target, animationTime);
	}

	public void LookAt(Point3D target, double distance, double animationTime)
	{
		Camera.LookAt(target, distance, animationTime);
	}

	public void LookAt(Point3D target, Vector3D direction, double animationTime)
	{
		Camera.LookAt(target, direction, animationTime);
	}

	public override void OnApplyTemplate()
	{
		if (adornerLayer == null)
		{
			adornerLayer = base.Template.FindName("PART_AdornerLayer", this) as AdornerDecorator;
		}
		if (!(base.Template.FindName("PART_ViewportGrid", this) is Grid grid))
		{
			throw new HelixToolkitException("{0} is missing from the template.", "PART_ViewportGrid");
		}
		grid.Children.Add(viewport);
		if (adornerLayer == null)
		{
			throw new HelixToolkitException("{0} is missing from the template.", "PART_AdornerLayer");
		}
		if (cameraController == null)
		{
			cameraController = base.Template.FindName("PART_CameraController", this) as CameraController;
			if (cameraController != null)
			{
				cameraController.Viewport = Viewport;
				cameraController.LookAtChanged += delegate
				{
					OnLookAtChanged();
				};
				cameraController.ZoomedByRectangle += delegate
				{
					OnZoomedByRectangle();
				};
			}
		}
		if (cameraController == null)
		{
			throw new HelixToolkitException("{0} is missing from the template.", "PART_CameraController");
		}
		if (coordinateView == null)
		{
			coordinateView = base.Template.FindName("PART_CoordinateView", this) as Viewport3D;
			coordinateSystemLights = new Model3DGroup();
			coordinateSystemLights.Children.Add(new AmbientLight(Colors.LightGray));
			if (coordinateView != null)
			{
				coordinateView.Camera = new PerspectiveCamera();
				coordinateView.Children.Add(new ModelVisual3D
				{
					Content = coordinateSystemLights
				});
			}
		}
		if (coordinateView == null)
		{
			throw new HelixToolkitException("{0} is missing from the template.", "PART_CoordinateView");
		}
		if (viewCubeViewport == null)
		{
			viewCubeViewport = base.Template.FindName("PART_ViewCubeViewport", this) as Viewport3D;
			viewCubeLights = new Model3DGroup();
			viewCubeLights.Children.Add(new AmbientLight(Colors.White));
			if (viewCubeViewport != null)
			{
				viewCubeViewport.Camera = new PerspectiveCamera();
				viewCubeViewport.Children.Add(new ModelVisual3D
				{
					Content = viewCubeLights
				});
				viewCubeViewport.MouseEnter += ViewCubeViewportMouseEnter;
				viewCubeViewport.MouseLeave += ViewCubeViewportMouseLeave;
			}
			viewCube = base.Template.FindName("PART_ViewCube", this) as ViewCubeVisual3D;
			if (viewCube != null)
			{
				viewCube.Viewport = Viewport;
			}
		}
		OnCameraChanged();
		OnHeadlightChanged();
		base.OnApplyTemplate();
	}

	public void ResetCamera()
	{
		if (cameraController != null)
		{
			cameraController.ResetCamera();
		}
	}

	public void SetView(Point3D newPosition, Vector3D newDirection, Vector3D newUpDirection, double animationTime = 0.0)
	{
		Camera.AnimateTo(newPosition, newDirection, newUpDirection, animationTime);
	}

	public void FitView(Vector3D newDirection, Vector3D newUpDirection, double animationTime = 0.0)
	{
		Camera.FitView(Viewport, newDirection, newUpDirection, animationTime);
	}

	public void ZoomExtents(double animationTime = 0.0)
	{
		if (cameraController != null)
		{
			cameraController.ZoomExtents(animationTime);
		}
	}

	public void ZoomExtents(Rect3D bounds, double animationTime = 0.0)
	{
		Camera.ZoomExtents(Viewport, bounds, animationTime);
	}

	protected internal virtual void OnLookAtChanged()
	{
		RoutedEventArgs e = new RoutedEventArgs(LookAtChangedEvent);
		RaiseEvent(e);
	}

	protected internal virtual void OnZoomedByRectangle()
	{
		RoutedEventArgs e = new RoutedEventArgs(ZoomedByRectangleEvent);
		RaiseEvent(e);
	}

	protected virtual void OnCameraChanged()
	{
		if (coordinateView != null)
		{
			Camera.CopyDirectionOnly(coordinateView.Camera as PerspectiveCamera, 30.0);
		}
		if (viewCubeViewport != null)
		{
			Camera.CopyDirectionOnly(viewCubeViewport.Camera as PerspectiveCamera, 20.0);
		}
		if (Camera != null)
		{
			if (headLight != null)
			{
				headLight.Direction = Camera.LookDirection;
			}
			if (coordinateSystemLights != null && coordinateSystemLights.Children[0] is DirectionalLight directionalLight)
			{
				directionalLight.Direction = Camera.LookDirection;
			}
		}
		if (ShowFieldOfView)
		{
			UpdateFieldOfViewInfo();
		}
		if (ShowCameraInfo)
		{
			UpdateCameraInfo();
		}
	}

	protected void OnHeadlightChanged()
	{
		if (lights != null)
		{
			if (IsHeadLightEnabled && !lights.Children.Contains(headLight))
			{
				lights.Children.Add(headLight);
			}
			if (!IsHeadLightEnabled && lights.Children.Contains(headLight))
			{
				lights.Children.Remove(headLight);
			}
		}
	}

	protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
			AddItems(e.NewItems);
			break;
		case NotifyCollectionChangedAction.Move:
			throw new NotImplementedException("Move operation not implemented.");
		case NotifyCollectionChangedAction.Remove:
			RemoveItems(e.OldItems);
			break;
		case NotifyCollectionChangedAction.Replace:
			throw new NotImplementedException("Replace operation not implemented.");
		case NotifyCollectionChangedAction.Reset:
			Children.Clear();
			break;
		}
	}

	protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
	{
		RemoveItems(oldValue);
		AddItems(newValue);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (CalculateCursorPosition)
		{
			Point position = e.GetPosition(this);
			UpdateCursorPosition(position);
		}
	}

	protected virtual void RaiseCameraChangedEvent()
	{
		RoutedEventArgs e = new RoutedEventArgs(CameraChangedEvent);
		RaiseEvent(e);
	}

	private void UpdateCursorPosition(Point pt)
	{
		CursorOnElementPosition = FindNearestPoint(pt);
		CursorPosition = Viewport.UnProject(pt);
		if (Viewport.Point2DtoPoint3D(pt, out var pointNear, out var pointFar))
		{
			Ray3D cursorRay = new Ray3D(pointFar, pointNear);
			CursorRay = cursorRay;
		}
		else
		{
			CursorOnConstructionPlanePosition = null;
			CursorRay = null;
		}
		if (CursorRay != null)
		{
			CursorOnConstructionPlanePosition = ConstructionPlane.LineIntersection(CursorRay.Origin, CursorRay.Origin + CursorRay.Direction);
		}
		else
		{
			CursorOnConstructionPlanePosition = null;
		}
		if (CursorOnElementPosition.HasValue)
		{
			CurrentPosition = CursorOnElementPosition.Value;
		}
		else if (CursorPosition.HasValue)
		{
			CurrentPosition = CursorPosition.Value;
		}
	}

	private void AddItems(IEnumerable newValue)
	{
		if (newValue == null)
		{
			return;
		}
		foreach (object item in newValue)
		{
			if (item is Visual3D value)
			{
				Children.Add(value);
			}
		}
	}

	private void CameraPropertyChanged(object sender, EventArgs e)
	{
		RaiseCameraChangedEvent();
		OnCameraChanged();
	}

	private void CompositionTargetRendering(object sender, EventArgs e)
	{
		frameCounter++;
		if (ShowFrameRate && fpsWatch.ElapsedMilliseconds > 500)
		{
			FrameRate = (int)((double)frameCounter / (0.001 * (double)fpsWatch.ElapsedMilliseconds));
			FrameRateText = FrameRate + " FPS";
			frameCounter = 0;
			fpsWatch.Reset();
			fpsWatch.Start();
		}
		infoFrameCounter++;
		if (ShowTriangleCountInfo && infoFrameCounter > 100)
		{
			int totalNumberOfTriangles = viewport.GetTotalNumberOfTriangles();
			TriangleCountInfo = $"Triangles: {totalNumberOfTriangles}";
			infoFrameCounter = 0;
		}
	}

	private void CopyHandler(object sender, ExecutedRoutedEventArgs e)
	{
		Copy();
	}

	private void OnCameraRotationModeChanged()
	{
		if (CameraRotationMode != CameraRotationMode.Trackball && cameraController != null)
		{
			cameraController.ResetCameraUpDirection();
		}
	}

	private void OnControlLoaded(object sender, RoutedEventArgs e)
	{
		if (!hasBeenLoadedBefore)
		{
			if (DefaultCamera != null)
			{
				DefaultCamera.Copy(perspectiveCamera);
				DefaultCamera.Copy(orthographicCamera);
			}
			hasBeenLoadedBefore = true;
		}
		UpdateRenderingEventSubscription();
		if (ZoomExtentsWhenLoaded)
		{
			ZoomExtents();
		}
	}

	private void OnControlUnloaded(object sender, RoutedEventArgs e)
	{
		UnsubscribeRenderingEvent();
	}

	private void OnOrthographicChanged()
	{
		ProjectionCamera camera = Camera;
		if (Orthographic)
		{
			Camera = orthographicCamera;
		}
		else
		{
			Camera = perspectiveCamera;
		}
		camera.Copy(Camera, copyNearFarPlaneDistances: false);
	}

	private void OnShowFrameRateChanged()
	{
		UpdateRenderingEventSubscription();
	}

	private void OnShowTriangleCountInfoChanged()
	{
		UpdateRenderingEventSubscription();
	}

	private void OrthographicToggle(object sender, ExecutedRoutedEventArgs e)
	{
		Orthographic = !Orthographic;
	}

	private void RemoveItems(IEnumerable oldValue)
	{
		if (oldValue == null)
		{
			return;
		}
		foreach (object item in oldValue)
		{
			if (item is Visual3D value)
			{
				Children.Remove(value);
			}
		}
	}

	private void SubscribeToRenderingEvent()
	{
		if (!isSubscribedToRenderingEvent)
		{
			WeakEventManagerBase<RenderingEventManager>.AddListener(renderingEventListener);
			isSubscribedToRenderingEvent = true;
		}
	}

	private void UnsubscribeRenderingEvent()
	{
		if (isSubscribedToRenderingEvent)
		{
			WeakEventManagerBase<RenderingEventManager>.RemoveListener(renderingEventListener);
			isSubscribedToRenderingEvent = false;
		}
	}

	private void UpdateCameraInfo()
	{
		CameraInfo = Camera.GetInfo();
	}

	private void UpdateFieldOfViewInfo()
	{
		PerspectiveCamera perspectiveCamera = Camera as PerspectiveCamera;
		FieldOfViewText = ((perspectiveCamera != null) ? $"FoV ∠ {perspectiveCamera.FieldOfView:0}°" : null);
	}

	private void UpdateRenderingEventSubscription()
	{
		if (ShowFrameRate || ShowTriangleCountInfo)
		{
			SubscribeToRenderingEvent();
		}
		else
		{
			UnsubscribeRenderingEvent();
		}
	}

	private void ViewCubeViewportMouseEnter(object sender, MouseEventArgs e)
	{
		viewCubeViewport.AnimateOpacity(1.0, 200.0);
	}

	private void ViewCubeViewportMouseLeave(object sender, MouseEventArgs e)
	{
		viewCubeViewport.AnimateOpacity(ViewCubeOpacity, 200.0);
	}
}
