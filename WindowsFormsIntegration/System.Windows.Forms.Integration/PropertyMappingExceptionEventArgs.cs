using System.Runtime;

namespace System.Windows.Forms.Integration;

public class PropertyMappingExceptionEventArgs : IntegrationExceptionEventArgs
{
	public string PropertyName
	{
		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public object PropertyValue
	{
		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public PropertyMappingExceptionEventArgs(Exception exception, string propertyName, object propertyValue)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}
}
