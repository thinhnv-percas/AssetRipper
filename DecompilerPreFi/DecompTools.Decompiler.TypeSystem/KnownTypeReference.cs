using System;

namespace DecompTools.Decompiler.TypeSystem;

[Serializable]
public sealed class KnownTypeReference : ITypeReference
{
	internal const int KnownTypeCodeCount = 52;

	private static readonly KnownTypeReference[] knownTypeReferences = new KnownTypeReference[52]
	{
		null,
		new KnownTypeReference(KnownTypeCode.Object, TypeKind.Class, "System", "Object", 0, KnownTypeCode.None),
		new KnownTypeReference(KnownTypeCode.DBNull, TypeKind.Class, "System", "DBNull"),
		new KnownTypeReference(KnownTypeCode.Boolean, TypeKind.Struct, "System", "Boolean"),
		new KnownTypeReference(KnownTypeCode.Char, TypeKind.Struct, "System", "Char"),
		new KnownTypeReference(KnownTypeCode.SByte, TypeKind.Struct, "System", "SByte"),
		new KnownTypeReference(KnownTypeCode.Byte, TypeKind.Struct, "System", "Byte"),
		new KnownTypeReference(KnownTypeCode.Int16, TypeKind.Struct, "System", "Int16"),
		new KnownTypeReference(KnownTypeCode.UInt16, TypeKind.Struct, "System", "UInt16"),
		new KnownTypeReference(KnownTypeCode.Int32, TypeKind.Struct, "System", "Int32"),
		new KnownTypeReference(KnownTypeCode.UInt32, TypeKind.Struct, "System", "UInt32"),
		new KnownTypeReference(KnownTypeCode.Int64, TypeKind.Struct, "System", "Int64"),
		new KnownTypeReference(KnownTypeCode.UInt64, TypeKind.Struct, "System", "UInt64"),
		new KnownTypeReference(KnownTypeCode.Single, TypeKind.Struct, "System", "Single"),
		new KnownTypeReference(KnownTypeCode.Double, TypeKind.Struct, "System", "Double"),
		new KnownTypeReference(KnownTypeCode.Decimal, TypeKind.Struct, "System", "Decimal"),
		new KnownTypeReference(KnownTypeCode.DateTime, TypeKind.Struct, "System", "DateTime"),
		null,
		new KnownTypeReference(KnownTypeCode.String, TypeKind.Class, "System", "String"),
		new KnownTypeReference(KnownTypeCode.Void, TypeKind.Void, "System", "Void", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.Type, TypeKind.Class, "System", "Type"),
		new KnownTypeReference(KnownTypeCode.Array, TypeKind.Class, "System", "Array"),
		new KnownTypeReference(KnownTypeCode.Attribute, TypeKind.Class, "System", "Attribute"),
		new KnownTypeReference(KnownTypeCode.ValueType, TypeKind.Class, "System", "ValueType"),
		new KnownTypeReference(KnownTypeCode.Enum, TypeKind.Class, "System", "Enum", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.Delegate, TypeKind.Class, "System", "Delegate"),
		new KnownTypeReference(KnownTypeCode.MulticastDelegate, TypeKind.Class, "System", "MulticastDelegate", 0, KnownTypeCode.Delegate),
		new KnownTypeReference(KnownTypeCode.Exception, TypeKind.Class, "System", "Exception"),
		new KnownTypeReference(KnownTypeCode.IntPtr, TypeKind.Struct, "System", "IntPtr"),
		new KnownTypeReference(KnownTypeCode.UIntPtr, TypeKind.Struct, "System", "UIntPtr"),
		new KnownTypeReference(KnownTypeCode.IEnumerable, TypeKind.Interface, "System.Collections", "IEnumerable"),
		new KnownTypeReference(KnownTypeCode.IEnumerator, TypeKind.Interface, "System.Collections", "IEnumerator"),
		new KnownTypeReference(KnownTypeCode.IEnumerableOfT, TypeKind.Interface, "System.Collections.Generic", "IEnumerable", 1),
		new KnownTypeReference(KnownTypeCode.IEnumeratorOfT, TypeKind.Interface, "System.Collections.Generic", "IEnumerator", 1),
		new KnownTypeReference(KnownTypeCode.ICollection, TypeKind.Interface, "System.Collections", "ICollection"),
		new KnownTypeReference(KnownTypeCode.ICollectionOfT, TypeKind.Interface, "System.Collections.Generic", "ICollection", 1),
		new KnownTypeReference(KnownTypeCode.IList, TypeKind.Interface, "System.Collections", "IList"),
		new KnownTypeReference(KnownTypeCode.IListOfT, TypeKind.Interface, "System.Collections.Generic", "IList", 1),
		new KnownTypeReference(KnownTypeCode.IReadOnlyCollectionOfT, TypeKind.Interface, "System.Collections.Generic", "IReadOnlyCollection", 1),
		new KnownTypeReference(KnownTypeCode.IReadOnlyListOfT, TypeKind.Interface, "System.Collections.Generic", "IReadOnlyList", 1),
		new KnownTypeReference(KnownTypeCode.Task, TypeKind.Class, "System.Threading.Tasks", "Task"),
		new KnownTypeReference(KnownTypeCode.TaskOfT, TypeKind.Class, "System.Threading.Tasks", "Task", 1, KnownTypeCode.Task),
		new KnownTypeReference(KnownTypeCode.NullableOfT, TypeKind.Struct, "System", "Nullable", 1),
		new KnownTypeReference(KnownTypeCode.IDisposable, TypeKind.Interface, "System", "IDisposable"),
		new KnownTypeReference(KnownTypeCode.INotifyCompletion, TypeKind.Interface, "System.Runtime.CompilerServices", "INotifyCompletion"),
		new KnownTypeReference(KnownTypeCode.ICriticalNotifyCompletion, TypeKind.Interface, "System.Runtime.CompilerServices", "ICriticalNotifyCompletion"),
		new KnownTypeReference(KnownTypeCode.TypedReference, TypeKind.Struct, "System", "TypedReference"),
		new KnownTypeReference(KnownTypeCode.IFormattable, TypeKind.Interface, "System", "IFormattable"),
		new KnownTypeReference(KnownTypeCode.FormattableString, TypeKind.Class, "System", "FormattableString", 0, KnownTypeCode.IFormattable),
		new KnownTypeReference(KnownTypeCode.SpanOfT, TypeKind.Struct, "System", "Span", 1),
		new KnownTypeReference(KnownTypeCode.ReadOnlySpanOfT, TypeKind.Struct, "System", "ReadOnlySpan", 1),
		new KnownTypeReference(KnownTypeCode.MemoryOfT, TypeKind.Struct, "System", "Memory", 1)
	};

	private readonly KnownTypeCode knownTypeCode;

	private readonly string namespaceName;

	private readonly string name;

	private readonly int typeParameterCount;

	internal readonly KnownTypeCode baseType;

	internal readonly TypeKind typeKind;

	public KnownTypeCode KnownTypeCode => knownTypeCode;

	public string Namespace => namespaceName;

	public string Name => name;

	public int TypeParameterCount => typeParameterCount;

	public TopLevelTypeName TypeName => new TopLevelTypeName(namespaceName, name, typeParameterCount);

	public static KnownTypeReference Get(KnownTypeCode typeCode)
	{
		return knownTypeReferences[(int)typeCode];
	}

	private KnownTypeReference(KnownTypeCode knownTypeCode, TypeKind typeKind, string namespaceName, string name, int typeParameterCount = 0, KnownTypeCode baseType = KnownTypeCode.Object)
	{
		if (typeKind == TypeKind.Struct && baseType == KnownTypeCode.Object)
		{
			baseType = KnownTypeCode.ValueType;
		}
		this.knownTypeCode = knownTypeCode;
		this.namespaceName = namespaceName;
		this.name = name;
		this.typeParameterCount = typeParameterCount;
		this.typeKind = typeKind;
		this.baseType = baseType;
	}

	public IType Resolve(ITypeResolveContext context)
	{
		return context.Compilation.FindType(knownTypeCode);
	}

	public override string ToString()
	{
		return GetCSharpNameByTypeCode(knownTypeCode) ?? (Namespace + "." + Name);
	}

	public static string GetCSharpNameByTypeCode(KnownTypeCode knownTypeCode)
	{
		return knownTypeCode switch
		{
			KnownTypeCode.Object => "object", 
			KnownTypeCode.Boolean => "bool", 
			KnownTypeCode.Char => "char", 
			KnownTypeCode.SByte => "sbyte", 
			KnownTypeCode.Byte => "byte", 
			KnownTypeCode.Int16 => "short", 
			KnownTypeCode.UInt16 => "ushort", 
			KnownTypeCode.Int32 => "int", 
			KnownTypeCode.UInt32 => "uint", 
			KnownTypeCode.Int64 => "long", 
			KnownTypeCode.UInt64 => "ulong", 
			KnownTypeCode.Single => "float", 
			KnownTypeCode.Double => "double", 
			KnownTypeCode.Decimal => "decimal", 
			KnownTypeCode.String => "string", 
			KnownTypeCode.Void => "void", 
			_ => null, 
		};
	}
}
