using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal abstract class SerializationContextBase
{
	[Flags]
	private enum TypeRefFlags : byte
	{
		None = 0,
		IsArray = 1,
		HasGenericParameterDeclaringMember = 8,
		HasGenericParameterDeclaringMemberIndex = 0x10
	}

	protected enum ObjectType : byte
	{
		Null,
		String,
		CreationPolicy,
		Type,
		Array,
		BinaryFormattedObject,
		TypeRef,
		BoolTrue,
		BoolFalse,
		Int32,
		Char,
		Guid,
		Enum32Substitution,
		TypeSubstitution,
		TypeArraySubstitution,
		Single,
		Double,
		UInt16,
		Int64,
		UInt64,
		Int16,
		UInt32,
		Byte,
		SByte
	}

	protected struct SerializationTrace : IDisposable
	{
		private const string Indent = "  ";

		private readonly SerializationContextBase context;

		private readonly string elementName;

		private readonly bool isArray;

		private readonly Stream stream;

		private readonly int startStreamPosition;

		internal SerializationTrace(SerializationContextBase context, string elementName, bool isArray, Stream stream)
		{
			this.context = context;
			this.elementName = elementName;
			this.isArray = isArray;
			this.stream = stream;
			this.context.indentationLevel++;
			startStreamPosition = (int)((stream != null) ? stream.Position : 0);
		}

		public void Dispose()
		{
			context.indentationLevel--;
			_ = stream;
		}
	}

	private class SmartInterningEqualityComparer : IEqualityComparer<object>
	{
		internal static readonly IEqualityComparer<object> Default = new SmartInterningEqualityComparer();

		private static readonly IEqualityComparer<object> Fallback = EqualityComparer<object>.Default;

		private SmartInterningEqualityComparer()
		{
		}

		public new bool Equals(object x, object y)
		{
			if (x is AssemblyName && y is AssemblyName)
			{
				return ByValueEquality.AssemblyName.Equals((AssemblyName)x, (AssemblyName)y);
			}
			return Fallback.Equals(x, y);
		}

		public int GetHashCode(object obj)
		{
			if (obj is AssemblyName)
			{
				return ByValueEquality.AssemblyName.GetHashCode((AssemblyName)obj);
			}
			return Fallback.GetHashCode(obj);
		}
	}

	protected BinaryReader reader;

	protected BinaryWriter writer;

	protected Dictionary<object, uint> serializingObjectTable;

	protected Dictionary<uint, object> deserializingObjectTable;

	protected int indentationLevel;

	private readonly ImmutableDictionary<string, object>.Builder metadataBuilder = ImmutableDictionary.CreateBuilder<string, object>();

	private long objectTableCapacityStreamPosition = -1L;

	protected Resolver Resolver { get; }

	internal SerializationContextBase(BinaryReader reader, Resolver resolver)
	{
		Requires.NotNull(reader, "reader");
		Requires.NotNull(resolver, "resolver");
		this.reader = reader;
		Resolver = resolver;
		int capacity = Math.Min(reader.ReadInt32(), 1000000);
		deserializingObjectTable = new Dictionary<uint, object>(capacity);
	}

	internal SerializationContextBase(BinaryWriter writer, int estimatedObjectCount, Resolver resolver)
	{
		Requires.NotNull(writer, "writer");
		Requires.NotNull(resolver, "resolver");
		this.writer = writer;
		serializingObjectTable = new Dictionary<object, uint>(estimatedObjectCount, SmartInterningEqualityComparer.Default);
		Resolver = resolver;
		Stream baseStream = writer.BaseStream;
		objectTableCapacityStreamPosition = (baseStream.CanSeek ? writer.BaseStream.Position : (-1));
		this.writer.Write(estimatedObjectCount);
	}

	protected internal void FinalizeObjectTableCapacity()
	{
		Verify.Operation(writer != null, Strings.OnlySupportedOnWriteOperations);
		if (objectTableCapacityStreamPosition >= 0)
		{
			writer.Flush();
			Stream baseStream = writer.BaseStream;
			long position = baseStream.Position;
			baseStream.Position = objectTableCapacityStreamPosition;
			writer.Write(serializingObjectTable.Count);
			writer.Flush();
			baseStream.Position = position;
		}
	}

	protected SerializationTrace Trace(string elementName, bool isArray = false)
	{
		Stream stream = null;
		return new SerializationTrace(this, elementName, isArray, stream);
	}

	protected void Write(MethodRef methodRef)
	{
		using (Trace("MethodRef"))
		{
			if (methodRef.IsEmpty)
			{
				writer.Write((byte)0);
				return;
			}
			writer.Write((byte)1);
			Write(methodRef.DeclaringType);
			WriteCompressedMetadataToken(methodRef.MetadataToken, MetadataTokenType.Method);
			Write(methodRef.Name);
			Write(methodRef.ParameterTypes, Write);
			Write(methodRef.GenericMethodArguments, Write);
		}
	}

	protected MethodRef ReadMethodRef()
	{
		using (Trace("MethodRef"))
		{
			if (reader.ReadByte() == 1)
			{
				TypeRef declaringType = ReadTypeRef();
				int metadataToken = ReadCompressedMetadataToken(MetadataTokenType.Method);
				string name = ReadString();
				ImmutableArray<TypeRef> parameterTypes = ReadList(reader, ReadTypeRef).ToImmutableArray();
				ImmutableArray<TypeRef> genericMethodArguments = ReadList(reader, ReadTypeRef).ToImmutableArray();
				return new MethodRef(declaringType, metadataToken, name, parameterTypes, genericMethodArguments);
			}
			return default(MethodRef);
		}
	}

	protected void Write(MemberRef memberRef)
	{
		using (Trace("MemberRef"))
		{
			if (memberRef.IsConstructor)
			{
				writer.Write((byte)1);
				Write(memberRef.Constructor);
			}
			else if (memberRef.IsField)
			{
				writer.Write((byte)2);
				Write(memberRef.Field);
			}
			else if (memberRef.IsProperty)
			{
				writer.Write((byte)3);
				Write(memberRef.Property);
			}
			else if (memberRef.IsMethod)
			{
				writer.Write((byte)4);
				Write(memberRef.Method);
			}
			else
			{
				writer.Write((byte)0);
			}
		}
	}

	protected MemberRef ReadMemberRef()
	{
		using (Trace("MemberRef"))
		{
			return (int)reader.ReadByte() switch
			{
				0 => default(MemberRef), 
				1 => new MemberRef(ReadConstructorRef()), 
				2 => new MemberRef(ReadFieldRef()), 
				3 => new MemberRef(ReadPropertyRef()), 
				4 => new MemberRef(ReadMethodRef()), 
				_ => throw new NotSupportedException(), 
			};
		}
	}

	protected void Write(PropertyRef propertyRef)
	{
		using (Trace("PropertyRef"))
		{
			Write(propertyRef.DeclaringType);
			WriteCompressedMetadataToken(propertyRef.MetadataToken, MetadataTokenType.Property);
			Write(propertyRef.Name);
			byte b = 0;
			b = (byte)(b | (propertyRef.GetMethodMetadataToken.HasValue ? 1 : 0));
			b = (byte)(b | (propertyRef.SetMethodMetadataToken.HasValue ? 2 : 0));
			writer.Write(b);
			if (propertyRef.GetMethodMetadataToken.HasValue)
			{
				WriteCompressedMetadataToken(propertyRef.GetMethodMetadataToken.Value, MetadataTokenType.Method);
			}
			if (propertyRef.SetMethodMetadataToken.HasValue)
			{
				WriteCompressedMetadataToken(propertyRef.SetMethodMetadataToken.Value, MetadataTokenType.Method);
			}
		}
	}

	protected PropertyRef ReadPropertyRef()
	{
		using (Trace("PropertyRef"))
		{
			TypeRef declaringType = ReadTypeRef();
			int metadataToken = ReadCompressedMetadataToken(MetadataTokenType.Property);
			string name = ReadString();
			byte num = reader.ReadByte();
			int? getMethodMetadataToken = null;
			int? setMethodMetadataToken = null;
			if ((num & 1) != 0)
			{
				getMethodMetadataToken = ReadCompressedMetadataToken(MetadataTokenType.Method);
			}
			if ((num & 2) != 0)
			{
				setMethodMetadataToken = ReadCompressedMetadataToken(MetadataTokenType.Method);
			}
			return new PropertyRef(declaringType, metadataToken, getMethodMetadataToken, setMethodMetadataToken, name);
		}
	}

	protected void Write(FieldRef fieldRef)
	{
		using (Trace("FieldRef"))
		{
			writer.Write(!fieldRef.IsEmpty);
			if (!fieldRef.IsEmpty)
			{
				Write(fieldRef.DeclaringType);
				WriteCompressedMetadataToken(fieldRef.MetadataToken, MetadataTokenType.Field);
				Write(fieldRef.Name);
			}
		}
	}

	protected FieldRef ReadFieldRef()
	{
		using (Trace("FieldRef"))
		{
			if (reader.ReadBoolean())
			{
				TypeRef declaringType = ReadTypeRef();
				int metadataToken = ReadCompressedMetadataToken(MetadataTokenType.Field);
				string name = ReadString();
				return new FieldRef(declaringType, metadataToken, name);
			}
			return default(FieldRef);
		}
	}

	protected void Write(ParameterRef parameterRef)
	{
		using (Trace("ParameterRef"))
		{
			writer.Write(!parameterRef.IsEmpty);
			if (!parameterRef.IsEmpty)
			{
				Write(parameterRef.Constructor);
				Write(parameterRef.Method);
				writer.Write((byte)parameterRef.ParameterIndex);
			}
		}
	}

	protected ParameterRef ReadParameterRef()
	{
		using (Trace("ParameterRef"))
		{
			if (reader.ReadBoolean())
			{
				ConstructorRef ctor = ReadConstructorRef();
				MethodRef method = ReadMethodRef();
				byte parameterIndex = reader.ReadByte();
				return ctor.IsEmpty ? new ParameterRef(method, parameterIndex) : new ParameterRef(ctor, parameterIndex);
			}
			return default(ParameterRef);
		}
	}

	protected void WriteCompressedMetadataToken(int metadataToken, MetadataTokenType type)
	{
		Requires.Argument((metadataToken & -16777216) == (int)type, "type", Strings.WrongType);
		WriteCompressedUInt((uint)(metadataToken & 0xFFFFFF));
	}

	protected int ReadCompressedMetadataToken(MetadataTokenType type)
	{
		return (int)ReadCompressedUInt() | (int)type;
	}

	protected void Write(ConstructorRef constructorRef)
	{
		Requires.Argument(!constructorRef.IsEmpty, "constructorRef", Strings.CannotBeEmpty);
		using (Trace("ConstructorRef"))
		{
			Write(constructorRef.DeclaringType);
			WriteCompressedMetadataToken(constructorRef.MetadataToken, MetadataTokenType.Method);
			Write(constructorRef.ParameterTypes, Write);
		}
	}

	protected ConstructorRef ReadConstructorRef()
	{
		using (Trace("ConstructorRef"))
		{
			TypeRef declaringType = ReadTypeRef();
			int metadataToken = ReadCompressedMetadataToken(MetadataTokenType.Method);
			ImmutableArray<TypeRef> parameterTypes = ReadList(reader, ReadTypeRef).ToImmutableArray();
			return new ConstructorRef(declaringType, metadataToken, parameterTypes);
		}
	}

	protected void Write(TypeRef typeRef)
	{
		using (Trace("TypeRef"))
		{
			if (TryPrepareSerializeReusableObject(typeRef))
			{
				Write(typeRef.AssemblyName);
				WriteCompressedMetadataToken(typeRef.MetadataToken, MetadataTokenType.Type);
				Write(typeRef.FullName);
				TypeRefFlags typeRefFlags = TypeRefFlags.None;
				typeRefFlags = (TypeRefFlags)((uint)typeRefFlags | (uint)(typeRef.IsArray ? 1 : 0));
				typeRefFlags = (TypeRefFlags)((uint)typeRefFlags | (uint)((!typeRef.GenericParameterDeclaringMemberRef.IsEmpty) ? 8 : 0));
				typeRefFlags = (TypeRefFlags)((uint)typeRefFlags | (uint)((typeRef.GenericParameterDeclaringMemberIndex >= 0) ? 16 : 0));
				writer.Write((byte)typeRefFlags);
				WriteCompressedUInt((uint)typeRef.GenericTypeParameterCount);
				Write(typeRef.GenericTypeArguments, Write);
				if (!typeRef.GenericParameterDeclaringMemberRef.IsEmpty)
				{
					Write(typeRef.GenericParameterDeclaringMemberRef);
				}
				if (typeRef.GenericParameterDeclaringMemberIndex >= 0)
				{
					WriteCompressedUInt((uint)typeRef.GenericParameterDeclaringMemberIndex);
				}
			}
		}
	}

	protected TypeRef ReadTypeRef()
	{
		using (Trace("TypeRef"))
		{
			if (TryPrepareDeserializeReusableObject<TypeRef>(out var id, out var value))
			{
				AssemblyName assemblyName = ReadAssemblyName();
				int metadataToken = ReadCompressedMetadataToken(MetadataTokenType.Type);
				string fullName = ReadString();
				TypeRefFlags typeRefFlags = (TypeRefFlags)reader.ReadByte();
				int genericTypeParameterCount = (int)ReadCompressedUInt();
				ImmutableArray<TypeRef> genericTypeArguments = ReadList(reader, ReadTypeRef).ToImmutableArray();
				MemberRef declaringMember = (typeRefFlags.HasFlag(TypeRefFlags.HasGenericParameterDeclaringMember) ? ReadMemberRef() : default(MemberRef));
				int declaringMethodParameterIndex = (typeRefFlags.HasFlag(TypeRefFlags.HasGenericParameterDeclaringMemberIndex) ? ((int)ReadCompressedUInt()) : (-1));
				value = ((!declaringMember.IsEmpty) ? TypeRef.Get(Resolver, assemblyName, metadataToken, fullName, typeRefFlags.HasFlag(TypeRefFlags.IsArray), genericTypeParameterCount, genericTypeArguments, declaringMember, declaringMethodParameterIndex) : TypeRef.Get(Resolver, assemblyName, metadataToken, fullName, typeRefFlags.HasFlag(TypeRefFlags.IsArray), genericTypeParameterCount, genericTypeArguments));
				OnDeserializedReusableObject(id, value);
			}
			return value;
		}
	}

	protected void Write(AssemblyName assemblyName)
	{
		using (Trace("AssemblyName"))
		{
			if (TryPrepareSerializeReusableObject(assemblyName))
			{
				Write(assemblyName.FullName);
				Write(assemblyName.CodeBase);
			}
		}
	}

	protected AssemblyName ReadAssemblyName()
	{
		using (Trace("AssemblyName"))
		{
			if (TryPrepareDeserializeReusableObject<AssemblyName>(out var id, out var value))
			{
				string assemblyName = ReadString();
				string codeBase = ReadString();
				value = new AssemblyName(assemblyName);
				value.CodeBase = codeBase;
				OnDeserializedReusableObject(id, value);
			}
			return value;
		}
	}

	protected void Write(string value)
	{
		using (Trace("String"))
		{
			if (TryPrepareSerializeReusableObject(value))
			{
				writer.Write(value);
			}
		}
	}

	protected string ReadString()
	{
		using (Trace("String"))
		{
			if (TryPrepareDeserializeReusableObject<string>(out var id, out var value))
			{
				value = reader.ReadString();
				OnDeserializedReusableObject(id, value);
			}
			return value;
		}
	}

	protected void WriteCompressedUInt(uint value)
	{
		CompressedUInt.WriteCompressedUInt(writer, value);
	}

	protected uint ReadCompressedUInt()
	{
		return CompressedUInt.ReadCompressedUInt(reader);
	}

	protected void Write<T>(IReadOnlyCollection<T> list, Action<T> itemWriter)
	{
		Requires.NotNull(list, "list");
		using (Trace("List<" + typeof(T).Name + ">"))
		{
			WriteCompressedUInt((uint)list.Count);
			foreach (T item in list)
			{
				itemWriter(item);
			}
		}
	}

	protected void Write(Array list, Action<object> itemWriter)
	{
		Requires.NotNull(list, "list");
		using (Trace(((list != null) ? list.GetType().GetElementType().Name : "null") + "[]"))
		{
			WriteCompressedUInt((uint)list.Length);
			foreach (object item in list)
			{
				itemWriter(item);
			}
		}
	}

	protected IReadOnlyList<T> ReadList<T>(Func<T> itemReader)
	{
		return ReadList(reader, itemReader);
	}

	protected IReadOnlyList<T> ReadList<T>(BinaryReader reader, Func<T> itemReader)
	{
		using (Trace(typeof(T).Name, isArray: true))
		{
			uint num = ReadCompressedUInt();
			if (num > 65535)
			{
				throw new NotSupportedException();
			}
			T[] array = new T[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = itemReader();
			}
			return array;
		}
	}

	protected Array ReadArray(BinaryReader reader, Func<object> itemReader, Type elementType)
	{
		using (Trace(elementType.Name, isArray: true))
		{
			uint num = ReadCompressedUInt();
			if (num > 65535)
			{
				throw new NotSupportedException();
			}
			Array array = Array.CreateInstance(elementType, (int)num);
			for (int i = 0; i < array.Length; i++)
			{
				object value = itemReader();
				array.SetValue(value, i);
			}
			return array;
		}
	}

	protected void Write(IReadOnlyDictionary<string, object> metadata)
	{
		using (Trace("Metadata"))
		{
			WriteCompressedUInt((uint)metadata.Count);
			foreach (KeyValuePair<string, object> item in new LazyMetadataWrapper(metadata.ToImmutableDictionary(), LazyMetadataWrapper.Direction.ToSubstitutedValue, Resolver))
			{
				Write(item.Key);
				WriteObject(item.Value);
			}
		}
	}

	protected IReadOnlyDictionary<string, object> ReadMetadata()
	{
		using (Trace("Metadata"))
		{
			uint num = ReadCompressedUInt();
			ImmutableDictionary<string, object> metadata = ImmutableDictionary<string, object>.Empty;
			if (num != 0)
			{
				ImmutableDictionary<string, object>.Builder builder = metadataBuilder;
				for (int i = 0; i < num; i++)
				{
					string key = ReadString();
					object value = ReadObject();
					builder.Add(key, value);
				}
				metadata = builder.ToImmutable();
				builder.Clear();
			}
			return new LazyMetadataWrapper(metadata, LazyMetadataWrapper.Direction.ToOriginalValue, Resolver);
		}
	}

	protected void Write(ImportCardinality cardinality)
	{
		using (Trace("ImportCardinality"))
		{
			writer.Write((byte)cardinality);
		}
	}

	protected ImportCardinality ReadImportCardinality()
	{
		using (Trace("ImportCardinality"))
		{
			return (ImportCardinality)reader.ReadByte();
		}
	}

	protected bool TryPrepareSerializeReusableObject(object value)
	{
		uint value2;
		bool result;
		if (value == null)
		{
			value2 = 0u;
			result = false;
		}
		else if (serializingObjectTable.TryGetValue(value, out value2))
		{
			result = false;
		}
		else
		{
			serializingObjectTable.Add(value, value2 = (uint)(serializingObjectTable.Count + 1));
			result = true;
		}
		WriteCompressedUInt(value2);
		return result;
	}

	protected bool TryPrepareDeserializeReusableObject<T>(out uint id, out T value) where T : class
	{
		id = ReadCompressedUInt();
		if (id == 0)
		{
			value = null;
			return false;
		}
		bool result = !deserializingObjectTable.TryGetValue(id, out var value2);
		value = (T)value2;
		return result;
	}

	protected void OnDeserializedReusableObject(uint id, object value)
	{
		deserializingObjectTable.Add(id, value);
	}

	protected void WriteObject(object value)
	{
		if (value == null)
		{
			using (Trace("Object (null)"))
			{
				Write(ObjectType.Null);
				return;
			}
		}
		Type type = value.GetType();
		using (Trace("Object (" + type.Name + ")"))
		{
			if (type.IsArray)
			{
				Array list = (Array)value;
				Write(ObjectType.Array);
				TypeRef typeRef = TypeRef.Get(type.GetElementType(), Resolver);
				Write(typeRef);
				Write(list, WriteObject);
			}
			else if (type == typeof(bool))
			{
				Write(((bool)value) ? ObjectType.BoolTrue : ObjectType.BoolFalse);
			}
			else if (type == typeof(string))
			{
				Write(ObjectType.String);
				Write((string)value);
			}
			else if (type == typeof(long))
			{
				Write(ObjectType.Int64);
				writer.Write((long)value);
			}
			else if (type == typeof(ulong))
			{
				Write(ObjectType.UInt64);
				writer.Write((ulong)value);
			}
			else if (type == typeof(int))
			{
				Write(ObjectType.Int32);
				writer.Write((int)value);
			}
			else if (type == typeof(uint))
			{
				Write(ObjectType.UInt32);
				writer.Write((uint)value);
			}
			else if (type == typeof(short))
			{
				Write(ObjectType.Int16);
				writer.Write((short)value);
			}
			else if (type == typeof(ushort))
			{
				Write(ObjectType.UInt16);
				writer.Write((ushort)value);
			}
			else if (type == typeof(byte))
			{
				Write(ObjectType.Byte);
				writer.Write((byte)value);
			}
			else if (type == typeof(sbyte))
			{
				Write(ObjectType.SByte);
				writer.Write((sbyte)value);
			}
			else if (type == typeof(float))
			{
				Write(ObjectType.Single);
				writer.Write((float)value);
			}
			else if (type == typeof(double))
			{
				Write(ObjectType.Double);
				writer.Write((double)value);
			}
			else if (type == typeof(char))
			{
				Write(ObjectType.Char);
				writer.Write((char)value);
			}
			else if (type == typeof(Guid))
			{
				Write(ObjectType.Guid);
				writer.Write(((Guid)value).ToByteArray());
			}
			else if (type == typeof(CreationPolicy))
			{
				Write(ObjectType.CreationPolicy);
				writer.Write((byte)(CreationPolicy)value);
			}
			else if (typeof(Type).GetTypeInfo().IsAssignableFrom(type))
			{
				Write(ObjectType.Type);
				Write(TypeRef.Get((Type)value, Resolver));
			}
			else if (typeof(TypeRef) == type)
			{
				Write(ObjectType.TypeRef);
				Write((TypeRef)value);
			}
			else if (typeof(LazyMetadataWrapper.Enum32Substitution) == type)
			{
				LazyMetadataWrapper.Enum32Substitution enum32Substitution = (LazyMetadataWrapper.Enum32Substitution)value;
				Write(ObjectType.Enum32Substitution);
				Write(enum32Substitution.EnumType);
				writer.Write(enum32Substitution.RawValue);
			}
			else if (typeof(LazyMetadataWrapper.TypeSubstitution) == type)
			{
				LazyMetadataWrapper.TypeSubstitution typeSubstitution = (LazyMetadataWrapper.TypeSubstitution)value;
				Write(ObjectType.TypeSubstitution);
				Write(typeSubstitution.TypeRef);
			}
			else if (typeof(LazyMetadataWrapper.TypeArraySubstitution) == type)
			{
				LazyMetadataWrapper.TypeArraySubstitution typeArraySubstitution = (LazyMetadataWrapper.TypeArraySubstitution)value;
				Write(ObjectType.TypeArraySubstitution);
				Write(typeArraySubstitution.TypeRefArray, Write);
			}
			else
			{
				Write(ObjectType.BinaryFormattedObject);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				writer.Flush();
				binaryFormatter.Serialize(writer.BaseStream, value);
			}
		}
	}

	protected object ReadObject()
	{
		using (Trace("Object"))
		{
			ObjectType objectType = ReadObjectType();
			switch (objectType)
			{
			case ObjectType.Null:
				return null;
			case ObjectType.Array:
			{
				Type elementType = ReadTypeRef().Resolve();
				return ReadArray(reader, ReadObject, elementType);
			}
			case ObjectType.BoolTrue:
				return true;
			case ObjectType.BoolFalse:
				return false;
			case ObjectType.Int64:
				return reader.ReadInt64();
			case ObjectType.UInt64:
				return reader.ReadUInt64();
			case ObjectType.Int32:
				return reader.ReadInt32();
			case ObjectType.UInt32:
				return reader.ReadUInt32();
			case ObjectType.Int16:
				return reader.ReadInt16();
			case ObjectType.UInt16:
				return reader.ReadUInt16();
			case ObjectType.Byte:
				return reader.ReadByte();
			case ObjectType.SByte:
				return reader.ReadSByte();
			case ObjectType.Single:
				return reader.ReadSingle();
			case ObjectType.Double:
				return reader.ReadDouble();
			case ObjectType.String:
				return ReadString();
			case ObjectType.Char:
				return reader.ReadChar();
			case ObjectType.Guid:
				return new Guid(reader.ReadBytes(16));
			case ObjectType.CreationPolicy:
				return (CreationPolicy)reader.ReadByte();
			case ObjectType.Type:
				return ReadTypeRef().Resolve();
			case ObjectType.TypeRef:
				return ReadTypeRef();
			case ObjectType.Enum32Substitution:
			{
				TypeRef enumType = ReadTypeRef();
				int rawValue = reader.ReadInt32();
				return new LazyMetadataWrapper.Enum32Substitution(enumType, rawValue);
			}
			case ObjectType.TypeSubstitution:
				return new LazyMetadataWrapper.TypeSubstitution(ReadTypeRef());
			case ObjectType.TypeArraySubstitution:
				return new LazyMetadataWrapper.TypeArraySubstitution(ReadList(reader, ReadTypeRef), Resolver);
			case ObjectType.BinaryFormattedObject:
				return new BinaryFormatter().Deserialize(reader.BaseStream);
			default:
				throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, Strings.UnsupportedFormat, new object[1] { objectType }));
			}
		}
	}

	protected void Write(ObjectType type)
	{
		writer.Write((byte)type);
	}

	protected ObjectType ReadObjectType()
	{
		return (ObjectType)reader.ReadByte();
	}

	[Conditional("TRACESTATS")]
	protected void TraceStats()
	{
	}
}
