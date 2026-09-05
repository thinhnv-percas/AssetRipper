using System.Collections.Concurrent;
using System.Reflection;
using System.Text;

namespace AssetRipper.Il2CppRestore.Metadata;

/// <summary>
/// Reads <c>global-metadata.dat</c> structs whose shape depends on the metadata version, by honoring
/// each field's <see cref="VersionAttribute"/> instead of hand-writing a reader per version.
/// </summary>
/// <remarks>
/// Two things this deliberately does NOT do, because both are wrong for this file format:
/// <list type="bullet">
/// <item>It never uses <c>Marshal.SizeOf</c> — the metadata file packs its structs with no padding,
/// unlike the CLR's own layout rules.</item>
/// <item><see cref="SizeOf{T}"/> is computed per-call rather than cached once, because which fields
/// count depends on <see cref="Version"/>, which can change between reads of different sections.</item>
/// </list>
/// </remarks>
public class VersionedReader : BinaryReader
{
	/// <summary>
	/// The metadata version currently in effect. Field visibility is decided against this.
	/// </summary>
	public double Version { get; set; }

	/// <summary>
	/// Whether pointer-sized binary fields (only relevant to structs shared with the binary reader,
	/// never to the metadata file itself) are 4 or 8 bytes.
	/// </summary>
	public bool Is32Bit { get; set; }

	// Reading 20k+ TypeDefinitions and calling GetFields() every time is roughly 50x slower than caching it.
	private static readonly ConcurrentDictionary<Type, FieldInfo[]> FieldCache = new();

	public VersionedReader(Stream input) : base(input, Encoding.UTF8, leaveOpen: true)
	{
	}

	public long Position
	{
		get => BaseStream.Position;
		set => BaseStream.Position = value;
	}

	/// <summary>
	/// A native pointer: 4 bytes on a 32-bit target, 8 on a 64-bit one.
	/// </summary>
	public ulong ReadPointer() => Is32Bit ? ReadUInt32() : ReadUInt64();

	public T ReadStruct<T>() where T : new()
	{
		T result = new();
		foreach (FieldInfo field in FieldsFor(typeof(T)))
		{
			VersionAttribute[] attributes = (VersionAttribute[])field.GetCustomAttributes(typeof(VersionAttribute), false);
			if (attributes.Length > 0 && !Array.Exists(attributes, a => a.Applies(Version)))
			{
				// The field does not exist at this version: skip it, reading zero bytes for it.
				continue;
			}

			field.SetValue(result, ReadPrimitive(field.FieldType));
		}
		return result;
	}

	public T[] ReadStructArray<T>(long offset, long byteCount) where T : new()
	{
		Position = offset;
		int stride = SizeOf<T>();
		if (stride <= 0 || byteCount <= 0)
		{
			return [];
		}

		T[] array = new T[byteCount / stride];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = ReadStruct<T>();
		}
		return array;
	}

	private object ReadPrimitive(Type type)
	{
		if (type == typeof(byte))
		{
			return ReadByte();
		}
		if (type == typeof(sbyte))
		{
			return ReadSByte();
		}
		if (type == typeof(short))
		{
			return ReadInt16();
		}
		if (type == typeof(ushort))
		{
			return ReadUInt16();
		}
		if (type == typeof(int))
		{
			return ReadInt32();
		}
		if (type == typeof(uint))
		{
			return ReadUInt32();
		}
		if (type == typeof(long))
		{
			return ReadInt64();
		}
		if (type == typeof(ulong))
		{
			return ReadUInt64();
		}
		if (type == typeof(IntPtr))
		{
			// A pointer-shaped field declared this way belongs to a struct shared with the binary
			// (never global-metadata.dat itself, which has no pointers of its own).
			return (IntPtr)(long)ReadPointer();
		}
		if (type.IsValueType || type.IsClass)
		{
			// A nested struct (e.g. Il2CppSectionMetadata inside the v39+ header).
			MethodInfo generic = typeof(VersionedReader).GetMethod(nameof(ReadStruct))!.MakeGenericMethod(type);
			return generic.Invoke(this, null)!;
		}
		throw new NotSupportedException($"Unsupported metadata field type: {type}");
	}

	/// <summary>
	/// The struct's size at the current <see cref="Version"/>. Has to be computed, not cached, because
	/// fields toggle on and off by version.
	/// </summary>
	public int SizeOf<T>() => SizeOfType(typeof(T));

	private int SizeOfType(Type type)
	{
		int size = 0;
		foreach (FieldInfo field in FieldsFor(type))
		{
			VersionAttribute[] attributes = (VersionAttribute[])field.GetCustomAttributes(typeof(VersionAttribute), false);
			if (attributes.Length > 0 && !Array.Exists(attributes, a => a.Applies(Version)))
			{
				continue;
			}
			size += SizeOfPrimitive(field.FieldType);
		}
		return size;
	}

	private int SizeOfPrimitive(Type type)
	{
		if (type == typeof(byte) || type == typeof(sbyte))
		{
			return 1;
		}
		if (type == typeof(short) || type == typeof(ushort))
		{
			return 2;
		}
		if (type == typeof(int) || type == typeof(uint))
		{
			return 4;
		}
		if (type == typeof(long) || type == typeof(ulong))
		{
			return 8;
		}
		if (type == typeof(IntPtr))
		{
			return Is32Bit ? 4 : 8;
		}
		return SizeOfType(type);
	}

	private static FieldInfo[] FieldsFor(Type type) =>
		FieldCache.GetOrAdd(type, static t => t.GetFields(BindingFlags.Public | BindingFlags.Instance));
}
