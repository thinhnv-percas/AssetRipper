using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;

namespace HelixToolkit.Wpf;

[ContentProperty("Children")]
[Localizability(LocalizationCategory.NeverLocalize)]
public class InterlacedView3D : StereoControl, IComponentConnector
{
	public static readonly DependencyProperty HorizontalOffsetProperty = DependencyProperty.Register("HorizontalOffset", typeof(double), typeof(InterlacedView3D), new UIPropertyMetadata(0.0, HorizontalOffsetChanged));

	public static readonly DependencyProperty EvenLeftProperty = DependencyProperty.Register("EvenLeft", typeof(bool), typeof(InterlacedView3D), new UIPropertyMetadata(true));

	internal InterlacedView3D thisControl;

	internal Grid LeftPanel;

	internal Viewport3D LeftView;

	internal Grid RightPanel;

	internal InterlacedEffect InterlacedEffect1;

	internal Viewport3D RightView;

	internal CameraController CameraControl;

	private bool _contentLoaded;

	public double HorizontalOffset
	{
		get
		{
			return (double)GetValue(HorizontalOffsetProperty);
		}
		set
		{
			SetValue(HorizontalOffsetProperty, value);
		}
	}

	public bool EvenLeft
	{
		get
		{
			return (bool)GetValue(EvenLeftProperty);
		}
		set
		{
			SetValue(EvenLeftProperty, value);
		}
	}

	public InterlacedView3D()
	{
		InitializeComponent();
		BindViewports(LeftView, RightView);
		DispatcherTimer dispatcherTimer = new DispatcherTimer
		{
			Interval = TimeSpan.FromSeconds(1.0)
		};
		dispatcherTimer.Tick += delegate
		{
			UpdateEvenLeft();
		};
		dispatcherTimer.Start();
	}

	public void UpdateEvenLeft()
	{
		if (base.IsLoaded && base.IsVisible)
		{
			int num = (int)PointToScreen(default(Point)).Y;
			EvenLeft = num % 2 == 0;
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		base.OnKeyDown(e);
		switch (e.Key)
		{
		case Key.Left:
			HorizontalOffset -= 0.0010000000474974513;
			break;
		case Key.Right:
			HorizontalOffset += 0.0010000000474974513;
			break;
		}
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		base.OnMouseDown(e);
		Focus();
	}

	private static void HorizontalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((InterlacedView3D)d).OnHorizontalOffsetChanged();
	}

	private void OnHorizontalOffsetChanged()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocator = new Uri("/HelixToolkit.Wpf;component/controls/stereo/interlacedview3d.xaml", UriKind.Relative);
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
			thisControl = (InterlacedView3D)target;
			break;
		case 2:
			LeftPanel = (Grid)target;
			break;
		case 3:
			LeftView = (Viewport3D)target;
			break;
		case 4:
			RightPanel = (Grid)target;
			break;
		case 5:
			InterlacedEffect1 = (InterlacedEffect)target;
			break;
		case 6:
			RightView = (Viewport3D)target;
			break;
		case 7:
			CameraControl = (CameraController)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
