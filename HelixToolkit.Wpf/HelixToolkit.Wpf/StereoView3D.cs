using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace HelixToolkit.Wpf;

public class StereoView3D : StereoControl, IComponentConnector
{
	internal StereoView3D thisControl;

	internal Viewport3D LeftView;

	internal CameraController LeftCameraControl;

	internal Viewport3D RightView;

	internal CameraController RightCameraControl;

	private bool _contentLoaded;

	public StereoView3D()
	{
		InitializeComponent();
		BindViewports(LeftView, RightView);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocator = new Uri("/HelixToolkit.Wpf;component/controls/stereo/stereoview3d.xaml", UriKind.Relative);
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
			thisControl = (StereoView3D)target;
			break;
		case 2:
			LeftView = (Viewport3D)target;
			break;
		case 3:
			LeftCameraControl = (CameraController)target;
			break;
		case 4:
			RightView = (Viewport3D)target;
			break;
		case 5:
			RightCameraControl = (CameraController)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
