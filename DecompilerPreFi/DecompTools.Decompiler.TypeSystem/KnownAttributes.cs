#define DEBUG
using System;
using System.Diagnostics;
using System.Linq;

namespace DecompTools.Decompiler.TypeSystem;

internal static class KnownAttributes
{
	internal const int Count = 42;

	private static readonly TopLevelTypeName[] typeNames = new TopLevelTypeName[42]
	{
		default(TopLevelTypeName),
		new TopLevelTypeName("System.Runtime.CompilerServices", "CompilerGeneratedAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "ExtensionAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "DynamicAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "TupleElementNamesAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "NullableAttribute"),
		new TopLevelTypeName("System.Diagnostics", "ConditionalAttribute"),
		new TopLevelTypeName("System", "ObsoleteAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "IsReadOnlyAttribute"),
		new TopLevelTypeName("System.Diagnostics", "DebuggerHiddenAttribute"),
		new TopLevelTypeName("System.Diagnostics", "DebuggerStepThroughAttribute"),
		new TopLevelTypeName("System.Reflection", "AssemblyVersionAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "InternalsVisibleToAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "TypeForwardedToAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "ReferenceAssemblyAttribute"),
		new TopLevelTypeName("System", "SerializableAttribute"),
		new TopLevelTypeName("System", "FlagsAttribute"),
		new TopLevelTypeName("System.Runtime.InteropServices", "ComImportAttribute"),
		new TopLevelTypeName("System.Runtime.InteropServices", "CoClassAttribute"),
		new TopLevelTypeName("System.Runtime.InteropServices", "StructLayoutAttribute"),
		new TopLevelTypeName("System.Reflection", "DefaultMemberAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "IsByRefLikeAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "IteratorStateMachineAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "AsyncStateMachineAttribute"),
		new TopLevelTypeName("System.Runtime.InteropServices", "FieldOffsetAttribute"),
		new TopLevelTypeName("System", "NonSerializedAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "DecimalConstantAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "FixedBufferAttribute"),
		new TopLevelTypeName("System.Runtime.InteropServices", "DllImportAttribute"),
		new TopLevelTypeName("System.Runtime.InteropServices", "PreserveSigAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "MethodImplAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "IndexerNameAttribute"),
		new TopLevelTypeName("System", "ParamArrayAttribute"),
		new TopLevelTypeName("System.Runtime.InteropServices", "InAttribute"),
		new TopLevelTypeName("System.Runtime.InteropServices", "OutAttribute"),
		new TopLevelTypeName("System.Runtime.InteropServices", "OptionalAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "CallerMemberNameAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "CallerFilePathAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "CallerLineNumberAttribute"),
		new TopLevelTypeName("System.Runtime.CompilerServices", "IsUnmanagedAttribute"),
		new TopLevelTypeName("System.Runtime.InteropServices", "MarshalAsAttribute"),
		new TopLevelTypeName("System.Security.Permissions", "PermissionSetAttribute")
	};

	public static ref readonly TopLevelTypeName GetTypeName(this KnownAttribute attr)
	{
		Debug.Assert(attr != KnownAttribute.None);
		return ref typeNames[(int)attr];
	}

	public static IType FindType(this ICompilation compilation, KnownAttribute attrType)
	{
		return compilation.FindType(attrType.GetTypeName());
	}

	public static KnownAttribute IsKnownAttributeType(this ITypeDefinition attributeType)
	{
		if (!Enumerable.Any<IType>(attributeType.GetNonInterfaceBaseTypes(), (Func<IType, bool>)((IType t) => t.IsKnownType(KnownTypeCode.Attribute))))
		{
			return KnownAttribute.None;
		}
		for (int num = 1; num < typeNames.Length; num = checked(num + 1))
		{
			if (typeNames[num] == attributeType.FullTypeName)
			{
				return (KnownAttribute)num;
			}
		}
		return KnownAttribute.None;
	}
}
