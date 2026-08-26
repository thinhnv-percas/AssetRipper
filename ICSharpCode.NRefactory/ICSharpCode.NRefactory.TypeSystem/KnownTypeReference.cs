using System;

namespace ICSharpCode.NRefactory.TypeSystem;

[Serializable]
public sealed class KnownTypeReference : ITypeReference
{
	internal const int KnownTypeCodeCount = 46;

	private static readonly KnownTypeReference[] knownTypeReferences = new KnownTypeReference[46]
	{
		null,
		new KnownTypeReference(KnownTypeCode.Object, "System", "Object", 0, KnownTypeCode.None),
		new KnownTypeReference(KnownTypeCode.DBNull, "System", "DBNull"),
		new KnownTypeReference(KnownTypeCode.Boolean, "System", "Boolean", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.Char, "System", "Char", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.SByte, "System", "SByte", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.Byte, "System", "Byte", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.Int16, "System", "Int16", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.UInt16, "System", "UInt16", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.Int32, "System", "Int32", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.UInt32, "System", "UInt32", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.Int64, "System", "Int64", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.UInt64, "System", "UInt64", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.Single, "System", "Single", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.Double, "System", "Double", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.Decimal, "System", "Decimal", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.DateTime, "System", "DateTime", 0, KnownTypeCode.ValueType),
		null,
		new KnownTypeReference(KnownTypeCode.String, "System", "String"),
		new KnownTypeReference(KnownTypeCode.Void, "System", "Void"),
		new KnownTypeReference(KnownTypeCode.Type, "System", "Type"),
		new KnownTypeReference(KnownTypeCode.Array, "System", "Array"),
		new KnownTypeReference(KnownTypeCode.Attribute, "System", "Attribute"),
		new KnownTypeReference(KnownTypeCode.ValueType, "System", "ValueType"),
		new KnownTypeReference(KnownTypeCode.Enum, "System", "Enum", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.Delegate, "System", "Delegate"),
		new KnownTypeReference(KnownTypeCode.MulticastDelegate, "System", "MulticastDelegate", 0, KnownTypeCode.Delegate),
		new KnownTypeReference(KnownTypeCode.Exception, "System", "Exception"),
		new KnownTypeReference(KnownTypeCode.IntPtr, "System", "IntPtr", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.UIntPtr, "System", "UIntPtr", 0, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.IEnumerable, "System.Collections", "IEnumerable"),
		new KnownTypeReference(KnownTypeCode.IEnumerator, "System.Collections", "IEnumerator"),
		new KnownTypeReference(KnownTypeCode.IEnumerableOfT, "System.Collections.Generic", "IEnumerable", 1),
		new KnownTypeReference(KnownTypeCode.IEnumeratorOfT, "System.Collections.Generic", "IEnumerator", 1),
		new KnownTypeReference(KnownTypeCode.ICollection, "System.Collections", "ICollection"),
		new KnownTypeReference(KnownTypeCode.ICollectionOfT, "System.Collections.Generic", "ICollection", 1),
		new KnownTypeReference(KnownTypeCode.IList, "System.Collections", "IList"),
		new KnownTypeReference(KnownTypeCode.IListOfT, "System.Collections.Generic", "IList", 1),
		new KnownTypeReference(KnownTypeCode.IReadOnlyCollectionOfT, "System.Collections.Generic", "IReadOnlyCollection", 1),
		new KnownTypeReference(KnownTypeCode.IReadOnlyListOfT, "System.Collections.Generic", "IReadOnlyList", 1),
		new KnownTypeReference(KnownTypeCode.Task, "System.Threading.Tasks", "Task"),
		new KnownTypeReference(KnownTypeCode.TaskOfT, "System.Threading.Tasks", "Task", 1, KnownTypeCode.Task),
		new KnownTypeReference(KnownTypeCode.NullableOfT, "System", "Nullable", 1, KnownTypeCode.ValueType),
		new KnownTypeReference(KnownTypeCode.IDisposable, "System", "IDisposable"),
		new KnownTypeReference(KnownTypeCode.INotifyCompletion, "System.Runtime.CompilerServices", "INotifyCompletion"),
		new KnownTypeReference(KnownTypeCode.ICriticalNotifyCompletion, "System.Runtime.CompilerServices", "ICriticalNotifyCompletion")
	};

	public static readonly KnownTypeReference Object = Get(KnownTypeCode.Object);

	public static readonly KnownTypeReference DBNull = Get(KnownTypeCode.DBNull);

	public static readonly KnownTypeReference Boolean = Get(KnownTypeCode.Boolean);

	public static readonly KnownTypeReference Char = Get(KnownTypeCode.Char);

	public static readonly KnownTypeReference SByte = Get(KnownTypeCode.SByte);

	public static readonly KnownTypeReference Byte = Get(KnownTypeCode.Byte);

	public static readonly KnownTypeReference Int16 = Get(KnownTypeCode.Int16);

	public static readonly KnownTypeReference UInt16 = Get(KnownTypeCode.UInt16);

	public static readonly KnownTypeReference Int32 = Get(KnownTypeCode.Int32);

	public static readonly KnownTypeReference UInt32 = Get(KnownTypeCode.UInt32);

	public static readonly KnownTypeReference Int64 = Get(KnownTypeCode.Int64);

	public static readonly KnownTypeReference UInt64 = Get(KnownTypeCode.UInt64);

	public static readonly KnownTypeReference Single = Get(KnownTypeCode.Single);

	public static readonly KnownTypeReference Double = Get(KnownTypeCode.Double);

	public static readonly KnownTypeReference Decimal = Get(KnownTypeCode.Decimal);

	public static readonly KnownTypeReference DateTime = Get(KnownTypeCode.DateTime);

	public static readonly KnownTypeReference String = Get(KnownTypeCode.String);

	public static readonly KnownTypeReference Void = Get(KnownTypeCode.Void);

	public static readonly KnownTypeReference Type = Get(KnownTypeCode.Type);

	public static readonly KnownTypeReference Array = Get(KnownTypeCode.Array);

	public static readonly KnownTypeReference Attribute = Get(KnownTypeCode.Attribute);

	public static readonly KnownTypeReference ValueType = Get(KnownTypeCode.ValueType);

	public static readonly KnownTypeReference Enum = Get(KnownTypeCode.Enum);

	public static readonly KnownTypeReference Delegate = Get(KnownTypeCode.Delegate);

	public static readonly KnownTypeReference MulticastDelegate = Get(KnownTypeCode.MulticastDelegate);

	public static readonly KnownTypeReference Exception = Get(KnownTypeCode.Exception);

	public static readonly KnownTypeReference IntPtr = Get(KnownTypeCode.IntPtr);

	public static readonly KnownTypeReference UIntPtr = Get(KnownTypeCode.UIntPtr);

	public static readonly KnownTypeReference IEnumerable = Get(KnownTypeCode.IEnumerable);

	public static readonly KnownTypeReference IEnumerator = Get(KnownTypeCode.IEnumerator);

	public static readonly KnownTypeReference IEnumerableOfT = Get(KnownTypeCode.IEnumerableOfT);

	public static readonly KnownTypeReference IEnumeratorOfT = Get(KnownTypeCode.IEnumeratorOfT);

	public static readonly KnownTypeReference ICollection = Get(KnownTypeCode.ICollection);

	public static readonly KnownTypeReference ICollectionOfT = Get(KnownTypeCode.ICollectionOfT);

	public static readonly KnownTypeReference IList = Get(KnownTypeCode.IList);

	public static readonly KnownTypeReference IListOfT = Get(KnownTypeCode.IListOfT);

	public static readonly KnownTypeReference IReadOnlyCollectionOfT = Get(KnownTypeCode.IReadOnlyCollectionOfT);

	public static readonly KnownTypeReference IReadOnlyListOfT = Get(KnownTypeCode.IReadOnlyListOfT);

	public static readonly KnownTypeReference Task = Get(KnownTypeCode.Task);

	public static readonly KnownTypeReference TaskOfT = Get(KnownTypeCode.TaskOfT);

	public static readonly KnownTypeReference NullableOfT = Get(KnownTypeCode.NullableOfT);

	public static readonly KnownTypeReference IDisposable = Get(KnownTypeCode.IDisposable);

	public static readonly KnownTypeReference INotifyCompletion = Get(KnownTypeCode.INotifyCompletion);

	public static readonly KnownTypeReference ICriticalNotifyCompletion = Get(KnownTypeCode.ICriticalNotifyCompletion);

	private readonly KnownTypeCode knownTypeCode;

	private readonly string namespaceName;

	private readonly string name;

	private readonly int typeParameterCount;

	internal readonly KnownTypeCode baseType;

	public KnownTypeCode KnownTypeCode => knownTypeCode;

	public string Namespace => namespaceName;

	public string Name => name;

	public int TypeParameterCount => typeParameterCount;

	public static KnownTypeReference Get(KnownTypeCode typeCode)
	{
		return knownTypeReferences[(int)typeCode];
	}

	private KnownTypeReference(KnownTypeCode knownTypeCode, string namespaceName, string name, int typeParameterCount = 0, KnownTypeCode baseType = KnownTypeCode.Object)
	{
		this.knownTypeCode = knownTypeCode;
		this.namespaceName = namespaceName;
		this.name = name;
		this.typeParameterCount = typeParameterCount;
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
