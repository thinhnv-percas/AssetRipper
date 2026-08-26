using System.Runtime;

namespace System.Windows.Forms.Integration;

public class ChildChangedEventArgs : EventArgs
{
	public object PreviousChild
	{
		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
	public ChildChangedEventArgs(object previousChild)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}
}
