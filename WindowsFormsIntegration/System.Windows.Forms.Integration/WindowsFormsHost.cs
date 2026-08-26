using System.ComponentModel;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Automation.Peers;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;

namespace System.Windows.Forms.Integration;

[DefaultEvent("ChildChanged")]
[DesignerCategory("code")]
[ContentProperty("Child")]
public class WindowsFormsHost : HwndHost, IKeyboardInputSink
{
	public static readonly DependencyProperty PaddingProperty;

	public static readonly DependencyProperty TabIndexProperty;

	public static readonly DependencyProperty FontFamilyProperty;

	public static readonly DependencyProperty FontSizeProperty;

	public static readonly DependencyProperty FontStyleProperty;

	public static readonly DependencyProperty FontWeightProperty;

	public static readonly DependencyProperty ForegroundProperty;

	public static readonly DependencyProperty BackgroundProperty;

	public Control Child
	{
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	public Thickness Padding
	{
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	[Bindable(true)]
	[Category("Behavior")]
	public int TabIndex
	{
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public FontFamily FontFamily
	{
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public double FontSize
	{
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public FontStyle FontStyle
	{
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public FontWeight FontWeight
	{
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public Brush Foreground
	{
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public Brush Background
	{
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
		set
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public PropertyMap PropertyMap
	{
		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public event EventHandler<LayoutExceptionEventArgs> LayoutError
	{
		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		add
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		remove
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public event EventHandler<ChildChangedEventArgs> ChildChanged
	{
		add
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
		remove
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public WindowsFormsHost()
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	protected override IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	protected virtual Vector ScaleChild(Vector newScale)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	protected override Size MeasureOverride(Size constraint)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public static void EnableWindowsFormsInterop()
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	public virtual bool TabInto(TraversalRequest request)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	protected override HandleRef BuildWindowCore(HandleRef hwndParent)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	protected override void DestroyWindowCore(HandleRef hwnd)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	protected override void Dispose(bool disposing)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	protected override AutomationPeer OnCreateAutomationPeer()
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	static WindowsFormsHost()
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}
}
