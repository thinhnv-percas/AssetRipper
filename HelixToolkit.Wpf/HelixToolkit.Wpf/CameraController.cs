using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

public class CameraController : Grid
{
	public static readonly DependencyProperty CameraModeProperty;

	public static readonly DependencyProperty CameraProperty;

	public static readonly DependencyProperty CameraRotationModeProperty;

	public static readonly DependencyProperty ChangeFieldOfViewCursorProperty;

	public static readonly DependencyProperty DefaultCameraProperty;

	public static readonly DependencyProperty EnabledProperty;

	public static readonly DependencyProperty InertiaFactorProperty;

	public static readonly DependencyProperty InfiniteSpinProperty;

	public static readonly DependencyProperty IsChangeFieldOfViewEnabledProperty;

	public static readonly DependencyProperty IsInertiaEnabledProperty;

	public static readonly DependencyProperty IsMoveEnabledProperty;

	public static readonly DependencyProperty IsPanEnabledProperty;

	public static readonly DependencyProperty IsRotationEnabledProperty;

	public static readonly DependencyProperty IsTouchZoomEnabledProperty;

	public static readonly DependencyProperty IsZoomEnabledProperty;

	public static readonly DependencyProperty LeftRightPanSensitivityProperty;

	public static readonly DependencyProperty LeftRightRotationSensitivityProperty;

	public static readonly RoutedEvent LookAtChangedEvent;

	public static readonly DependencyProperty MaximumFieldOfViewProperty;

	public static readonly DependencyProperty MinimumFieldOfViewProperty;

	public static readonly DependencyProperty ModelUpDirectionProperty;

	public static readonly DependencyProperty MoveSensitivityProperty;

	public static readonly DependencyProperty PageUpDownZoomSensitivityProperty;

	public static readonly DependencyProperty PanCursorProperty;

	public static readonly DependencyProperty RotateAroundMouseDownPointProperty;

	public static readonly DependencyProperty RotateCursorProperty;

	public static readonly DependencyProperty RotationSensitivityProperty;

	public static readonly DependencyProperty ShowCameraTargetProperty;

	public static readonly DependencyProperty SpinReleaseTimeProperty;

	public static readonly DependencyProperty UpDownPanSensitivityProperty;

	public static readonly DependencyProperty UpDownRotationSensitivityProperty;

	public static readonly DependencyProperty ViewportProperty;

	public static readonly DependencyProperty ZoomAroundMouseDownPointProperty;

	public static readonly DependencyProperty ZoomCursorProperty;

	public static readonly DependencyProperty ZoomRectangleCursorProperty;

	public static readonly DependencyProperty ZoomSensitivityProperty;

	public static readonly RoutedEvent ZoomedByRectangleEvent;

	private readonly LinkedList<CameraSetting> cameraHistory = new LinkedList<CameraSetting>();

	private readonly RenderingEventListener renderingEventListener;

	private readonly Stack<Cursor> cursorStack = new Stack<Cursor>();

	private ZoomHandler changeFieldOfViewHandler;

	private RotateHandler changeLookAtHandler;

	private bool isSpinning;

	private long lastTick;

	private Vector3D moveSpeed;

	private PanHandler panHandler;

	private Vector3D panSpeed;

	private RectangleAdorner rectangleAdorner;

	private RotateHandler rotateHandler;

	private Point3D rotationPoint3D;

	private Point rotationPosition;

	private Vector rotationSpeed;

	private Point3D spinningPoint3D;

	private Point spinningPosition;

	private Vector spinningSpeed;

	private Adorner targetAdorner;

	private Point touchPreviousPoint;

	private int manipulatorCount;

	private ZoomHandler zoomHandler;

	private Point3D zoomPoint3D;

	private ZoomRectangleHandler zoomRectangleHandler;

	private double zoomSpeed;

	public static RoutedCommand BackViewCommand { get; private set; }

	public static RoutedCommand BottomViewCommand { get; private set; }

	public static RoutedCommand ChangeFieldOfViewCommand { get; private set; }

	public static RoutedCommand ChangeLookAtCommand { get; private set; }

	public static RoutedCommand FrontViewCommand { get; private set; }

	public static RoutedCommand LeftViewCommand { get; private set; }

	public static RoutedCommand PanCommand { get; private set; }

	public static RoutedCommand ResetCameraCommand { get; private set; }

	public static RoutedCommand RightViewCommand { get; private set; }

	public static RoutedCommand RotateCommand { get; private set; }

	public static RoutedCommand TopViewCommand { get; private set; }

	public static RoutedCommand ZoomCommand { get; private set; }

	public static RoutedCommand ZoomExtentsCommand { get; private set; }

	public static RoutedCommand ZoomRectangleCommand { get; private set; }

	public ProjectionCamera ActualCamera
	{
		get
		{
			if (Camera != null)
			{
				return Camera;
			}
			if (Viewport != null)
			{
				return Viewport.Camera as ProjectionCamera;
			}
			return null;
		}
	}

	public ProjectionCamera Camera
	{
		get
		{
			return (ProjectionCamera)GetValue(CameraProperty);
		}
		set
		{
			SetValue(CameraProperty, value);
		}
	}

	public Vector3D CameraLookDirection
	{
		get
		{
			return ActualCamera.LookDirection;
		}
		set
		{
			ActualCamera.LookDirection = value;
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

	public Point3D CameraPosition
	{
		get
		{
			return ActualCamera.Position;
		}
		set
		{
			ActualCamera.Position = value;
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

	public Point3D CameraTarget
	{
		get
		{
			return CameraPosition + CameraLookDirection;
		}
		set
		{
			CameraLookDirection = value - CameraPosition;
		}
	}

	public Vector3D CameraUpDirection
	{
		get
		{
			return ActualCamera.UpDirection;
		}
		set
		{
			ActualCamera.UpDirection = value;
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

	public bool Enabled
	{
		get
		{
			return (bool)GetValue(EnabledProperty);
		}
		set
		{
			SetValue(EnabledProperty, value);
		}
	}

	public double InertiaFactor
	{
		get
		{
			return (double)GetValue(InertiaFactorProperty);
		}
		set
		{
			SetValue(InertiaFactorProperty, value);
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

	public bool IsActive => Enabled && Viewport != null && ActualCamera != null;

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

	public double MoveSensitivity
	{
		get
		{
			return (double)GetValue(MoveSensitivityProperty);
		}
		set
		{
			SetValue(MoveSensitivityProperty, value);
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

	public int SpinReleaseTime
	{
		get
		{
			return (int)GetValue(SpinReleaseTimeProperty);
		}
		set
		{
			SetValue(SpinReleaseTimeProperty, value);
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

	protected bool IsOrthographicCamera => ActualCamera is OrthographicCamera;

	protected bool IsPerspectiveCamera => ActualCamera is PerspectiveCamera;

	protected OrthographicCamera OrthographicCamera => ActualCamera as OrthographicCamera;

	protected PerspectiveCamera PerspectiveCamera => ActualCamera as PerspectiveCamera;

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

	static CameraController()
	{
		CameraModeProperty = DependencyProperty.Register("CameraMode", typeof(CameraMode), typeof(CameraController), new UIPropertyMetadata(CameraMode.Inspect));
		CameraProperty = DependencyProperty.Register("Camera", typeof(ProjectionCamera), typeof(CameraController), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, CameraChanged));
		CameraRotationModeProperty = DependencyProperty.Register("CameraRotationMode", typeof(CameraRotationMode), typeof(CameraController), new UIPropertyMetadata(CameraRotationMode.Turntable));
		ChangeFieldOfViewCursorProperty = DependencyProperty.Register("ChangeFieldOfViewCursor", typeof(Cursor), typeof(CameraController), new UIPropertyMetadata(Cursors.ScrollNS));
		DefaultCameraProperty = DependencyProperty.Register("DefaultCamera", typeof(ProjectionCamera), typeof(CameraController), new UIPropertyMetadata(null));
		EnabledProperty = DependencyProperty.Register("Enabled", typeof(bool), typeof(CameraController), new UIPropertyMetadata(true));
		InertiaFactorProperty = DependencyProperty.Register("InertiaFactor", typeof(double), typeof(CameraController), new UIPropertyMetadata(0.9));
		InfiniteSpinProperty = DependencyProperty.Register("InfiniteSpin", typeof(bool), typeof(CameraController), new UIPropertyMetadata(false));
		IsChangeFieldOfViewEnabledProperty = DependencyProperty.Register("IsChangeFieldOfViewEnabled", typeof(bool), typeof(CameraController), new UIPropertyMetadata(true));
		IsInertiaEnabledProperty = DependencyProperty.Register("IsInertiaEnabled", typeof(bool), typeof(CameraController), new UIPropertyMetadata(true));
		IsMoveEnabledProperty = DependencyProperty.Register("IsMoveEnabled", typeof(bool), typeof(CameraController), new UIPropertyMetadata(true));
		IsPanEnabledProperty = DependencyProperty.Register("IsPanEnabled", typeof(bool), typeof(CameraController), new UIPropertyMetadata(true));
		IsRotationEnabledProperty = DependencyProperty.Register("IsRotationEnabled", typeof(bool), typeof(CameraController), new UIPropertyMetadata(true));
		IsTouchZoomEnabledProperty = DependencyProperty.Register("IsTouchZoomEnabled", typeof(bool), typeof(CameraController), new UIPropertyMetadata(true));
		IsZoomEnabledProperty = DependencyProperty.Register("IsZoomEnabled", typeof(bool), typeof(CameraController), new UIPropertyMetadata(true));
		LeftRightPanSensitivityProperty = DependencyProperty.Register("LeftRightPanSensitivity", typeof(double), typeof(CameraController), new UIPropertyMetadata(1.0));
		LeftRightRotationSensitivityProperty = DependencyProperty.Register("LeftRightRotationSensitivity", typeof(double), typeof(CameraController), new UIPropertyMetadata(1.0));
		LookAtChangedEvent = EventManager.RegisterRoutedEvent("LookAtChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CameraController));
		MaximumFieldOfViewProperty = DependencyProperty.Register("MaximumFieldOfView", typeof(double), typeof(CameraController), new UIPropertyMetadata(160.0));
		MinimumFieldOfViewProperty = DependencyProperty.Register("MinimumFieldOfView", typeof(double), typeof(CameraController), new UIPropertyMetadata(5.0));
		ModelUpDirectionProperty = DependencyProperty.Register("ModelUpDirection", typeof(Vector3D), typeof(CameraController), new UIPropertyMetadata(new Vector3D(0.0, 0.0, 1.0)));
		MoveSensitivityProperty = DependencyProperty.Register("MoveSensitivity", typeof(double), typeof(CameraController), new UIPropertyMetadata(1.0));
		PageUpDownZoomSensitivityProperty = DependencyProperty.Register("PageUpDownZoomSensitivity", typeof(double), typeof(CameraController), new UIPropertyMetadata(1.0));
		PanCursorProperty = DependencyProperty.Register("PanCursor", typeof(Cursor), typeof(CameraController), new UIPropertyMetadata(Cursors.Hand));
		RotateAroundMouseDownPointProperty = DependencyProperty.Register("RotateAroundMouseDownPoint", typeof(bool), typeof(CameraController), new UIPropertyMetadata(false));
		RotateCursorProperty = DependencyProperty.Register("RotateCursor", typeof(Cursor), typeof(CameraController), new UIPropertyMetadata(Cursors.SizeAll));
		RotationSensitivityProperty = DependencyProperty.Register("RotationSensitivity", typeof(double), typeof(CameraController), new UIPropertyMetadata(1.0));
		ShowCameraTargetProperty = DependencyProperty.Register("ShowCameraTarget", typeof(bool), typeof(CameraController), new UIPropertyMetadata(true));
		SpinReleaseTimeProperty = DependencyProperty.Register("SpinReleaseTime", typeof(int), typeof(CameraController), new UIPropertyMetadata(200));
		UpDownPanSensitivityProperty = DependencyProperty.Register("UpDownPanSensitivity", typeof(double), typeof(CameraController), new UIPropertyMetadata(1.0));
		UpDownRotationSensitivityProperty = DependencyProperty.Register("UpDownRotationSensitivity", typeof(double), typeof(CameraController), new UIPropertyMetadata(1.0));
		ViewportProperty = DependencyProperty.Register("Viewport", typeof(Viewport3D), typeof(CameraController), new PropertyMetadata(null, ViewportChanged));
		ZoomAroundMouseDownPointProperty = DependencyProperty.Register("ZoomAroundMouseDownPoint", typeof(bool), typeof(CameraController), new UIPropertyMetadata(false));
		ZoomCursorProperty = DependencyProperty.Register("ZoomCursor", typeof(Cursor), typeof(CameraController), new UIPropertyMetadata(Cursors.SizeNS));
		ZoomRectangleCursorProperty = DependencyProperty.Register("ZoomRectangleCursor", typeof(Cursor), typeof(CameraController), new UIPropertyMetadata(Cursors.ScrollSE));
		ZoomSensitivityProperty = DependencyProperty.Register("ZoomSensitivity", typeof(double), typeof(CameraController), new UIPropertyMetadata(1.0));
		ZoomedByRectangleEvent = EventManager.RegisterRoutedEvent("ZoomedByRectangle", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CameraController));
		Panel.BackgroundProperty.OverrideMetadata(typeof(CameraController), new FrameworkPropertyMetadata(Brushes.Transparent));
		FrameworkElement.FocusVisualStyleProperty.OverrideMetadata(typeof(CameraController), new FrameworkPropertyMetadata(null));
		BackViewCommand = new RoutedCommand();
		BottomViewCommand = new RoutedCommand();
		ChangeFieldOfViewCommand = new RoutedCommand();
		ChangeLookAtCommand = new RoutedCommand();
		FrontViewCommand = new RoutedCommand();
		LeftViewCommand = new RoutedCommand();
		PanCommand = new RoutedCommand();
		ResetCameraCommand = new RoutedCommand();
		RightViewCommand = new RoutedCommand();
		RotateCommand = new RoutedCommand();
		TopViewCommand = new RoutedCommand();
		ZoomCommand = new RoutedCommand();
		ZoomExtentsCommand = new RoutedCommand();
		ZoomRectangleCommand = new RoutedCommand();
	}

	public CameraController()
	{
		base.Loaded += CameraControllerLoaded;
		base.Unloaded += CameraControllerUnloaded;
		base.Focusable = true;
		base.FocusVisualStyle = null;
		base.IsManipulationEnabled = true;
		InitializeBindings();
		renderingEventListener = new RenderingEventListener(OnCompositionTargetRendering);
	}

	public void AddMoveForce(double dx, double dy, double dz)
	{
		AddMoveForce(new Vector3D(dx, dy, dz));
	}

	public void AddMoveForce(Vector3D delta)
	{
		if (IsMoveEnabled)
		{
			PushCameraSetting();
			moveSpeed += delta * 40.0;
		}
	}

	public void AddPanForce(double dx, double dy)
	{
		AddPanForce(FindPanVector(dx, dy));
	}

	public void AddPanForce(Vector3D pan)
	{
		if (IsPanEnabled)
		{
			PushCameraSetting();
			if (IsInertiaEnabled)
			{
				panSpeed += pan * 40.0;
			}
			else
			{
				panHandler.Pan(pan);
			}
		}
	}

	public void AddRotateForce(double dx, double dy)
	{
		if (IsRotationEnabled)
		{
			PushCameraSetting();
			if (IsInertiaEnabled)
			{
				rotationPoint3D = CameraTarget;
				rotationPosition = new Point(base.ActualWidth / 2.0, base.ActualHeight / 2.0);
				rotationSpeed.X += dx * 40.0;
				rotationSpeed.Y += dy * 40.0;
			}
			else
			{
				rotationPosition = new Point(base.ActualWidth / 2.0, base.ActualHeight / 2.0);
				rotateHandler.Rotate(rotationPosition, rotationPosition + new Vector(dx, dy), CameraTarget);
			}
		}
	}

	public void AddZoomForce(double delta)
	{
		AddZoomForce(delta, CameraTarget);
	}

	public void AddZoomForce(double delta, Point3D zoomOrigin)
	{
		if (IsZoomEnabled)
		{
			PushCameraSetting();
			if (IsInertiaEnabled)
			{
				zoomPoint3D = zoomOrigin;
				zoomSpeed += delta * 8.0;
			}
			else
			{
				zoomHandler.Zoom(delta, zoomOrigin);
			}
		}
	}

	public void ChangeDirection(Vector3D lookDir, Vector3D upDir, double animationTime = 500.0)
	{
		if (IsRotationEnabled)
		{
			StopAnimations();
			PushCameraSetting();
			ActualCamera.ChangeDirection(lookDir, upDir, animationTime);
		}
	}

	public void ChangeDirection(Vector3D lookDir, double animationTime = 500.0)
	{
		if (IsRotationEnabled)
		{
			StopAnimations();
			PushCameraSetting();
			ActualCamera.ChangeDirection(lookDir, ActualCamera.UpDirection, animationTime);
		}
	}

	public void HideRectangle()
	{
		AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(Viewport);
		if (rectangleAdorner != null)
		{
			adornerLayer.Remove(rectangleAdorner);
		}
		rectangleAdorner = null;
		Viewport.InvalidateVisual();
	}

	public void HideTargetAdorner()
	{
		AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(Viewport);
		if (targetAdorner != null)
		{
			adornerLayer.Remove(targetAdorner);
		}
		targetAdorner = null;
		RefreshViewport();
	}

	[Obsolete]
	public void LookAt(Point3D target, double animationTime)
	{
		if (IsPanEnabled)
		{
			PushCameraSetting();
			Camera.LookAt(target, animationTime);
		}
	}

	public void PushCameraSetting()
	{
		cameraHistory.AddLast(new CameraSetting(ActualCamera));
		if (cameraHistory.Count > 100)
		{
			cameraHistory.RemoveFirst();
		}
	}

	public void ResetCamera()
	{
		if (IsZoomEnabled && IsRotationEnabled && IsPanEnabled)
		{
			PushCameraSetting();
			if (DefaultCamera != null)
			{
				DefaultCamera.Copy(ActualCamera);
				return;
			}
			ActualCamera.Reset();
			ActualCamera.ZoomExtents(Viewport);
		}
	}

	public void ResetCameraUpDirection()
	{
		CameraUpDirection = ModelUpDirection;
	}

	public bool RestoreCameraSetting()
	{
		if (cameraHistory.Count > 0)
		{
			CameraSetting value = cameraHistory.Last.Value;
			cameraHistory.RemoveLast();
			value.UpdateCamera(ActualCamera);
			return true;
		}
		return false;
	}

	public void ShowRectangle(Rect rect, Color color1, Color color2)
	{
		if (rectangleAdorner == null)
		{
			AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(Viewport);
			rectangleAdorner = new RectangleAdorner(Viewport, rect, color1, color2, 3.0, 1.0, 10.0, DashStyles.Solid);
			adornerLayer.Add(rectangleAdorner);
		}
	}

	public void ShowTargetAdorner(Point position)
	{
		if (ShowCameraTarget && targetAdorner == null)
		{
			AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(Viewport);
			targetAdorner = new TargetSymbolAdorner(Viewport, position);
			adornerLayer.Add(targetAdorner);
		}
	}

	public void StartSpin(Vector speed, Point position, Point3D aroundPoint)
	{
		spinningSpeed = speed;
		spinningPosition = position;
		spinningPoint3D = aroundPoint;
		isSpinning = true;
	}

	public void StopSpin()
	{
		isSpinning = false;
	}

	public void UpdateRectangle(Rect rect)
	{
		if (rectangleAdorner != null)
		{
			rectangleAdorner.Rectangle = rect;
			rectangleAdorner.InvalidateVisual();
		}
	}

	public void Zoom(double delta)
	{
		zoomHandler.Zoom(delta);
	}

	public void ZoomExtents(double animationTime = 200.0)
	{
		if (IsZoomEnabled)
		{
			PushCameraSetting();
			ActualCamera.ZoomExtents(Viewport, animationTime);
		}
	}

	public void RestoreCursor()
	{
		base.Cursor = cursorStack.Pop();
	}

	public void SetCursor(Cursor cursor)
	{
		cursorStack.Push(base.Cursor);
		base.Cursor = cursor;
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

	protected override void OnManipulationCompleted(ManipulationCompletedEventArgs e)
	{
		base.OnManipulationCompleted(e);
		Point currentPosition = e.ManipulationOrigin + e.TotalManipulation.Translation;
		if (manipulatorCount == 1)
		{
			rotateHandler.Completed(new ManipulationEventArgs(currentPosition));
		}
		if (manipulatorCount == 2)
		{
			panHandler.Completed(new ManipulationEventArgs(currentPosition));
			zoomHandler.Completed(new ManipulationEventArgs(currentPosition));
		}
		e.Handled = true;
	}

	protected override void OnManipulationDelta(ManipulationDeltaEventArgs e)
	{
		base.OnManipulationDelta(e);
		int num = e.Manipulators.Count();
		Point currentPosition = (touchPreviousPoint += e.DeltaManipulation.Translation);
		if (manipulatorCount != num)
		{
			if (manipulatorCount == 1)
			{
				rotateHandler.Completed(new ManipulationEventArgs(currentPosition));
			}
			if (manipulatorCount == 2)
			{
				panHandler.Completed(new ManipulationEventArgs(currentPosition));
				zoomHandler.Completed(new ManipulationEventArgs(currentPosition));
			}
			if (num == 2)
			{
				panHandler.Started(new ManipulationEventArgs(currentPosition));
				zoomHandler.Started(new ManipulationEventArgs(e.ManipulationOrigin));
			}
			else
			{
				rotateHandler.Started(new ManipulationEventArgs(currentPosition));
			}
			manipulatorCount = num;
			e.Handled = true;
			return;
		}
		if (num == 1)
		{
			rotateHandler.Delta(new ManipulationEventArgs(currentPosition));
		}
		if (num == 2)
		{
			panHandler.Delta(new ManipulationEventArgs(currentPosition));
		}
		if (IsTouchZoomEnabled && num == 2)
		{
			Point3D? point3D = zoomHandler.UnProject(e.ManipulationOrigin, zoomHandler.Origin, CameraLookDirection);
			if (point3D.HasValue)
			{
				zoomHandler.Zoom(1.0 - e.DeltaManipulation.Scale.Length / Math.Sqrt(2.0), point3D.Value);
			}
		}
		e.Handled = true;
	}

	protected override void OnManipulationStarted(ManipulationStartedEventArgs e)
	{
		base.OnManipulationStarted(e);
		Focus();
		touchPreviousPoint = e.ManipulationOrigin;
		manipulatorCount = 0;
		e.Handled = true;
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		base.OnMouseDown(e);
		Focus();
		if (e.ChangedButton == MouseButton.XButton1)
		{
			RestoreCameraSetting();
		}
	}

	protected override void OnStylusSystemGesture(StylusSystemGestureEventArgs e)
	{
		base.OnStylusSystemGesture(e);
		if (e.SystemGesture == SystemGesture.HoldEnter)
		{
			Point position = e.GetPosition(this);
			changeLookAtHandler.Started(new ManipulationEventArgs(position));
			changeLookAtHandler.Completed(new ManipulationEventArgs(position));
			e.Handled = true;
		}
		if (e.SystemGesture == SystemGesture.TwoFingerTap)
		{
			ZoomExtents();
			e.Handled = true;
		}
	}

	private static void CameraChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((CameraController)d).OnCameraChanged();
	}

	private static void ViewportChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((CameraController)d).OnViewportChanged();
	}

	private void BackViewHandler(object sender, ExecutedRoutedEventArgs e)
	{
		ChangeDirection(new Vector3D(1.0, 0.0, 0.0), new Vector3D(0.0, 0.0, 1.0));
	}

	private void BottomViewHandler(object sender, ExecutedRoutedEventArgs e)
	{
		ChangeDirection(new Vector3D(0.0, 0.0, 1.0), new Vector3D(0.0, -1.0, 0.0));
	}

	private void CameraControllerLoaded(object sender, RoutedEventArgs e)
	{
		SubscribeEvents();
	}

	private void CameraControllerUnloaded(object sender, RoutedEventArgs e)
	{
		UnSubscribeEvents();
	}

	private double Clamp(double value, double min, double max)
	{
		if (value < min)
		{
			return min;
		}
		if (value > max)
		{
			return max;
		}
		return value;
	}

	private Vector3D FindPanVector(double dx, double dy)
	{
		Vector3D vector3D = Vector3D.CrossProduct(CameraLookDirection, CameraUpDirection);
		Vector3D vector3D2 = Vector3D.CrossProduct(vector3D, CameraLookDirection);
		vector3D.Normalize();
		vector3D2.Normalize();
		double length = CameraLookDirection.Length;
		double num = length * 0.001;
		return -vector3D * num * dx + vector3D2 * num * dy;
	}

	private void FrontViewHandler(object sender, ExecutedRoutedEventArgs e)
	{
		ChangeDirection(new Vector3D(-1.0, 0.0, 0.0), new Vector3D(0.0, 0.0, 1.0));
	}

	private void InitializeBindings()
	{
		changeLookAtHandler = new RotateHandler(this, changeLookAt: true);
		rotateHandler = new RotateHandler(this);
		zoomRectangleHandler = new ZoomRectangleHandler(this);
		zoomHandler = new ZoomHandler(this);
		panHandler = new PanHandler(this);
		changeFieldOfViewHandler = new ZoomHandler(this, changeFieldOfView: true);
		base.CommandBindings.Add(new CommandBinding(ZoomRectangleCommand, zoomRectangleHandler.Execute));
		base.CommandBindings.Add(new CommandBinding(ZoomExtentsCommand, ZoomExtentsHandler));
		base.CommandBindings.Add(new CommandBinding(RotateCommand, rotateHandler.Execute));
		base.CommandBindings.Add(new CommandBinding(ZoomCommand, zoomHandler.Execute));
		base.CommandBindings.Add(new CommandBinding(PanCommand, panHandler.Execute));
		base.CommandBindings.Add(new CommandBinding(ResetCameraCommand, ResetCameraHandler));
		base.CommandBindings.Add(new CommandBinding(ChangeLookAtCommand, changeLookAtHandler.Execute));
		base.CommandBindings.Add(new CommandBinding(ChangeFieldOfViewCommand, changeFieldOfViewHandler.Execute));
		base.CommandBindings.Add(new CommandBinding(TopViewCommand, TopViewHandler));
		base.CommandBindings.Add(new CommandBinding(BottomViewCommand, BottomViewHandler));
		base.CommandBindings.Add(new CommandBinding(LeftViewCommand, LeftViewHandler));
		base.CommandBindings.Add(new CommandBinding(RightViewCommand, RightViewHandler));
		base.CommandBindings.Add(new CommandBinding(FrontViewCommand, FrontViewHandler));
		base.CommandBindings.Add(new CommandBinding(BackViewCommand, BackViewHandler));
	}

	private void LeftViewHandler(object sender, ExecutedRoutedEventArgs e)
	{
		ChangeDirection(new Vector3D(0.0, 1.0, 0.0), new Vector3D(0.0, 0.0, 1.0));
	}

	private void OnCameraChanged()
	{
		cameraHistory.Clear();
		PushCameraSetting();
	}

	private void OnCompositionTargetRendering(object sender, RenderingEventArgs e)
	{
		long ticks = e.RenderingTime.Ticks;
		double time = 1E-07 * (double)(ticks - lastTick);
		if (lastTick != 0)
		{
			OnTimeStep(time);
		}
		lastTick = ticks;
	}

	private void OnKeyDown(object sender, KeyEventArgs e)
	{
		OnKeyDown(e);
		bool flag = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
		double num = ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) ? 0.25 : 1.0);
		if (!flag)
		{
			switch (e.Key)
			{
			case Key.Left:
				AddRotateForce(-1.0 * num * LeftRightRotationSensitivity, 0.0);
				e.Handled = true;
				break;
			case Key.Right:
				AddRotateForce(1.0 * num * LeftRightRotationSensitivity, 0.0);
				e.Handled = true;
				break;
			case Key.Up:
				AddRotateForce(0.0, -1.0 * num * UpDownRotationSensitivity);
				e.Handled = true;
				break;
			case Key.Down:
				AddRotateForce(0.0, 1.0 * num * UpDownRotationSensitivity);
				e.Handled = true;
				break;
			}
		}
		else
		{
			switch (e.Key)
			{
			case Key.Left:
				AddPanForce(-5.0 * num * LeftRightPanSensitivity, 0.0);
				e.Handled = true;
				break;
			case Key.Right:
				AddPanForce(5.0 * num * LeftRightPanSensitivity, 0.0);
				e.Handled = true;
				break;
			case Key.Up:
				AddPanForce(0.0, -5.0 * num * UpDownPanSensitivity);
				e.Handled = true;
				break;
			case Key.Down:
				AddPanForce(0.0, 5.0 * num * UpDownPanSensitivity);
				e.Handled = true;
				break;
			}
		}
		switch (e.Key)
		{
		case Key.Prior:
			AddZoomForce(-0.1 * num * PageUpDownZoomSensitivity);
			e.Handled = true;
			break;
		case Key.Next:
			AddZoomForce(0.1 * num * PageUpDownZoomSensitivity);
			e.Handled = true;
			break;
		case Key.Back:
			if (RestoreCameraSetting())
			{
				e.Handled = true;
			}
			break;
		}
		switch (e.Key)
		{
		case Key.W:
			AddMoveForce(0.0, 0.0, 0.1 * num * MoveSensitivity);
			break;
		case Key.A:
			AddMoveForce(-0.1 * num * LeftRightPanSensitivity, 0.0, 0.0);
			break;
		case Key.S:
			AddMoveForce(0.0, 0.0, -0.1 * num * MoveSensitivity);
			break;
		case Key.D:
			AddMoveForce(0.1 * num * LeftRightPanSensitivity, 0.0, 0.0);
			break;
		case Key.Z:
			AddMoveForce(0.0, -0.1 * num * LeftRightPanSensitivity, 0.0);
			break;
		case Key.Q:
			AddMoveForce(0.0, 0.1 * num * LeftRightPanSensitivity, 0.0);
			break;
		}
	}

	private void OnMouseWheel(object sender, MouseWheelEventArgs e)
	{
		if (!IsZoomEnabled)
		{
			return;
		}
		if (ZoomAroundMouseDownPoint)
		{
			Point position = e.GetPosition(this);
			if (Viewport.FindNearest(position, out var point, out var _, out var _))
			{
				AddZoomForce((double)(-e.Delta) * 0.001, point);
				e.Handled = true;
				return;
			}
			Point3D? point3D = Viewport.UnProject(position);
			if (point3D.HasValue)
			{
				AddZoomForce((double)(-e.Delta) * 0.001, point3D.Value);
				e.Handled = true;
				return;
			}
		}
		AddZoomForce((double)(-e.Delta) * 0.001);
		e.Handled = true;
	}

	private void OnTimeStep(double time)
	{
		double value = (IsInertiaEnabled ? Math.Pow(InertiaFactor, time / 0.012) : 0.0);
		value = Clamp(value, 0.2, 1.0);
		if (isSpinning && spinningSpeed.LengthSquared > 0.0)
		{
			rotateHandler.Rotate(spinningPosition, spinningPosition + spinningSpeed * time, spinningPoint3D);
			if (!InfiniteSpin)
			{
				spinningSpeed *= value;
			}
		}
		if (rotationSpeed.LengthSquared > 0.1)
		{
			rotateHandler.Rotate(rotationPosition, rotationPosition + rotationSpeed * time, rotationPoint3D);
			rotationSpeed *= value;
		}
		if (Math.Abs(panSpeed.LengthSquared) > 0.0001)
		{
			panHandler.Pan(panSpeed * time);
			panSpeed *= value;
		}
		if (Math.Abs(moveSpeed.LengthSquared) > 0.0001)
		{
			zoomHandler.MoveCameraPosition(moveSpeed * time);
			moveSpeed *= value;
		}
		if (Math.Abs(zoomSpeed) > 0.1)
		{
			zoomHandler.Zoom(zoomSpeed * time, zoomPoint3D);
			zoomSpeed *= value;
		}
	}

	private void OnViewportChanged()
	{
	}

	private void RefreshViewport()
	{
		Camera camera = Viewport.Camera;
		Viewport.Camera = null;
		Viewport.Camera = camera;
	}

	private void ResetCameraHandler(object sender, ExecutedRoutedEventArgs e)
	{
		if (IsPanEnabled && IsZoomEnabled && CameraMode != CameraMode.FixedPosition)
		{
			StopAnimations();
			ResetCamera();
		}
	}

	private void RightViewHandler(object sender, ExecutedRoutedEventArgs e)
	{
		ChangeDirection(new Vector3D(0.0, -1.0, 0.0), new Vector3D(0.0, 0.0, 1.0));
	}

	private void StopAnimations()
	{
		rotationSpeed = default(Vector);
		panSpeed = default(Vector3D);
		zoomSpeed = 0.0;
	}

	private void SubscribeEvents()
	{
		base.MouseWheel += OnMouseWheel;
		base.KeyDown += OnKeyDown;
		WeakEventManagerBase<RenderingEventManager>.AddListener(renderingEventListener);
	}

	private void TopViewHandler(object sender, ExecutedRoutedEventArgs e)
	{
		ChangeDirection(new Vector3D(0.0, 0.0, -1.0), new Vector3D(0.0, 1.0, 0.0));
	}

	private void UnSubscribeEvents()
	{
		base.MouseWheel -= OnMouseWheel;
		base.KeyDown -= OnKeyDown;
		WeakEventManagerBase<RenderingEventManager>.RemoveListener(renderingEventListener);
	}

	private void ZoomExtentsHandler(object sender, ExecutedRoutedEventArgs e)
	{
		StopAnimations();
		ZoomExtents();
	}
}
