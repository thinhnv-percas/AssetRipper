using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace HelixToolkit.Wpf;

public class WiggleView3D : StereoControl, IComponentConnector
{
	public static readonly DependencyProperty WiggleRateProperty = DependencyProperty.Register("WiggleRate", typeof(double), typeof(WiggleView3D), new UIPropertyMetadata(5.0, WiggleRateChanged));

	private readonly DispatcherTimer timer = new DispatcherTimer();

	private readonly Stopwatch watch = new Stopwatch();

	private readonly RenderingEventListener renderingEventListener;

	internal WiggleView3D thisControl;

	internal Viewport3D View1;

	internal CameraController CameraControl1;

	private bool _contentLoaded;

	public double WiggleRate
	{
		get
		{
			return (double)GetValue(WiggleRateProperty);
		}
		set
		{
			SetValue(WiggleRateProperty, value);
		}
	}

	public WiggleView3D()
	{
		InitializeComponent();
		base.RightCamera = new PerspectiveCamera();
		BindViewports(View1, null, createLights: true, createCamera: true);
		base.Loaded += ControlLoaded;
		base.Unloaded += ControlUnloaded;
		UpdateTimer();
		watch.Start();
		renderingEventListener = new RenderingEventListener(OnCompositionTargetRendering);
	}

	private void ControlUnloaded(object sender, RoutedEventArgs e)
	{
		WeakEventManagerBase<RenderingEventManager>.RemoveListener(renderingEventListener);
	}

	private void ControlLoaded(object sender, RoutedEventArgs e)
	{
		WeakEventManagerBase<RenderingEventManager>.AddListener(renderingEventListener);
	}

	protected static void WiggleRateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((WiggleView3D)d).UpdateTimer();
	}

	private void OnCompositionTargetRendering(object sender, EventArgs e)
	{
		if ((double)watch.ElapsedMilliseconds > 1000.0 / WiggleRate)
		{
			watch.Reset();
			watch.Start();
			Wiggle();
		}
	}

	private void UpdateTimer()
	{
		timer.Interval = TimeSpan.FromSeconds(1.0 / WiggleRate);
	}

	private void Wiggle()
	{
		if (View1.Camera == base.LeftCamera)
		{
			View1.Camera = base.RightCamera;
		}
		else
		{
			View1.Camera = base.LeftCamera;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocator = new Uri("/HelixToolkit.Wpf;component/controls/stereo/wiggleview3d.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			thisControl = (WiggleView3D)target;
			break;
		case 2:
			View1 = (Viewport3D)target;
			break;
		case 3:
			CameraControl1 = (CameraController)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
