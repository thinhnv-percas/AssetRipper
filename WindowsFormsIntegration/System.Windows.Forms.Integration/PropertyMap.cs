using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Security.Permissions;

namespace System.Windows.Forms.Integration;

[PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
public class PropertyMap
{
	protected object SourceObject
	{
		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public PropertyTranslator this[string propertyName]
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

	public ICollection Keys
	{
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public ICollection Values
	{
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	protected Dictionary<string, PropertyTranslator> DefaultTranslators
	{
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	public event EventHandler<PropertyMappingExceptionEventArgs> PropertyMappingError
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

	public PropertyMap()
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
	public PropertyMap(object source)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	public void Add(string propertyName, PropertyTranslator translator)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	public void Apply(string propertyName)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	public void ApplyAll()
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	public void Clear()
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	public bool Contains(string propertyName)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	public void Remove(string propertyName)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	public void Reset(string propertyName)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	public void ResetAll()
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}
}
