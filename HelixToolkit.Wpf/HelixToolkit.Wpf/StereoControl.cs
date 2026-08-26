using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HelixToolkit.Wpf;

[ContentProperty("Content")]
public class StereoControl : ContentControl
{
	public static readonly DependencyProperty CameraProperty;

	public static readonly DependencyProperty CameraRotationModeProperty;

	public static readonly DependencyProperty CopyDirectionVectorProperty;

	public static readonly DependencyProperty CopyUpVectorProperty;

	public static readonly DependencyProperty CrossViewingProperty;

	public static readonly DependencyProperty StereoBaseProperty;

	public PerspectiveCamera Camera
	{
		get
		{
			return (PerspectiveCamera)GetValue(CameraProperty);
		}
		set
		{
			SetValue(CameraProperty, value);
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

	public ObservableCollection<Visual3D> Children { get; private set; }

	public bool CopyDirectionVector
	{
		get
		{
			return (bool)GetValue(CopyDirectionVectorProperty);
		}
		set
		{
			SetValue(CopyDirectionVectorProperty, value);
		}
	}

	public bool CopyUpVector
	{
		get
		{
			return (bool)GetValue(CopyUpVectorProperty);
		}
		set
		{
			SetValue(CopyUpVectorProperty, value);
		}
	}

	public bool CrossViewing
	{
		get
		{
			return (bool)GetValue(CrossViewingProperty);
		}
		set
		{
			SetValue(CrossViewingProperty, value);
		}
	}

	public PerspectiveCamera LeftCamera { get; set; }

	public Viewport3D LeftViewport { get; set; }

	public PerspectiveCamera RightCamera { get; set; }

	public Viewport3D RightViewport { get; set; }

	public double StereoBase
	{
		get
		{
			return (double)GetValue(StereoBaseProperty);
		}
		set
		{
			SetValue(StereoBaseProperty, value);
		}
	}

	static StereoControl()
	{
		CameraProperty = DependencyProperty.Register("Camera", typeof(PerspectiveCamera), typeof(StereoControl), new UIPropertyMetadata(null));
		CameraRotationModeProperty = DependencyProperty.Register("CameraRotationMode", typeof(CameraRotationMode), typeof(StereoControl), new UIPropertyMetadata(CameraRotationMode.Turntable));
		CopyDirectionVectorProperty = DependencyProperty.Register("CopyDirectionVector", typeof(bool), typeof(StereoControl), new UIPropertyMetadata(true, StereoViewChanged));
		CopyUpVectorProperty = DependencyProperty.Register("CopyUpVector", typeof(bool), typeof(StereoControl), new UIPropertyMetadata(false, StereoViewChanged));
		CrossViewingProperty = DependencyProperty.Register("CrossViewing", typeof(bool), typeof(StereoControl), new UIPropertyMetadata(false));
		StereoBaseProperty = DependencyProperty.Register("StereoBase", typeof(double), typeof(StereoControl), new UIPropertyMetadata(0.12, StereoViewChanged));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(StereoControl), new FrameworkPropertyMetadata(typeof(StereoControl)));
	}

	public StereoControl()
	{
		Camera = CameraHelper.CreateDefaultCamera();
		Camera.Changed += CameraChanged;
		Children = new ObservableCollection<Visual3D>();
	}

	public void BindViewports(Viewport3D left, Viewport3D right)
	{
		BindViewports(left, right, createLights: true, createCamera: true);
	}

	public void BindViewports(Viewport3D left, Viewport3D right, bool createLights, bool createCamera)
	{
		LeftViewport = left;
		RightViewport = right;
		Children.CollectionChanged += ChildrenCollectionChanged;
		if (createLights)
		{
			Children.Add(new DefaultLights());
		}
		if (createCamera)
		{
			if (LeftViewport.Camera == null)
			{
				LeftViewport.Camera = CameraHelper.CreateDefaultCamera();
			}
			else
			{
				(LeftViewport.Camera as PerspectiveCamera).Reset();
			}
			if (RightViewport != null && RightViewport.Camera == null)
			{
				RightViewport.Camera = new PerspectiveCamera();
			}
		}
		LeftCamera = LeftViewport.Camera as PerspectiveCamera;
		if (RightViewport != null)
		{
			RightCamera = RightViewport.Camera as PerspectiveCamera;
		}
		UpdateCameras();
	}

	public void Clear()
	{
		Children.Clear();
		SynchronizeStereoModel();
	}

	public void ExportKerkythea(string leftFileName, string rightFileName)
	{
		SolidColorBrush solidColorBrush = base.Background as SolidColorBrush;
		KerkytheaExporter kerkytheaExporter = new KerkytheaExporter();
		if (solidColorBrush != null)
		{
			kerkytheaExporter.BackgroundColor = solidColorBrush.Color;
		}
		kerkytheaExporter.Reflections = true;
		kerkytheaExporter.Shadows = true;
		kerkytheaExporter.SoftShadows = true;
		kerkytheaExporter.Width = (int)LeftViewport.ActualWidth;
		kerkytheaExporter.Height = (int)LeftViewport.ActualHeight;
		using (FileStream stream = File.Create(leftFileName))
		{
			kerkytheaExporter.Export(LeftViewport, stream);
		}
		KerkytheaExporter kerkytheaExporter2 = new KerkytheaExporter();
		if (solidColorBrush != null)
		{
			kerkytheaExporter2.BackgroundColor = solidColorBrush.Color;
		}
		kerkytheaExporter2.Reflections = true;
		kerkytheaExporter2.Shadows = true;
		kerkytheaExporter2.SoftShadows = true;
		kerkytheaExporter2.Width = (int)RightViewport.ActualWidth;
		kerkytheaExporter2.Height = (int)RightViewport.ActualHeight;
		using FileStream stream2 = File.Create(rightFileName);
		kerkytheaExporter2.Export(RightViewport, stream2);
	}

	public void SynchronizeStereoModel()
	{
		LeftViewport.Children.Clear();
		if (RightViewport != null)
		{
			RightViewport.Children.Clear();
		}
		foreach (Visual3D child in Children)
		{
			LeftViewport.Children.Add(child);
			if (RightViewport != null)
			{
				Visual3D visual3D = StereoHelper.CreateClone(child);
				if (visual3D != null)
				{
					RightViewport.Children.Add(visual3D);
				}
			}
		}
	}

	public void UpdateCameras()
	{
		StereoHelper.UpdateStereoCameras(Camera, LeftCamera, RightCamera, StereoBase, CrossViewing, CopyUpVector, CopyDirectionVector);
	}

	protected static void StereoViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		StereoControl stereoControl = (StereoControl)d;
		stereoControl.UpdateCameras();
	}

	private void CameraChanged(object sender, EventArgs e)
	{
		UpdateCameras();
	}

	private void ChildrenCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
	}
}
