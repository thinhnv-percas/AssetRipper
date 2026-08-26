using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization;

namespace ICSharpCode.NRefactory.Utils
{
	public class FastSerializer
	{
		private sealed class SerializationType
		{
			public readonly int ID;

			public readonly Type Type;

			public ObjectScanner Scanner;

			public ObjectWriter Writer;

			public string TypeName;

			public int AssemblyNameID;

			public SerializationType(int iD, Type type)
			{
				ID = iD;
				Type = type;
			}
		}

		private sealed class SerializationContext
		{
			private readonly Dictionary<object, int> objectToID = new Dictionary<object, int>(ReferenceComparer.Instance);

			private readonly List<object> instances = new List<object>();

			private readonly List<SerializationType> objectTypes = new List<SerializationType>();

			private SerializationType stringType;

			private readonly Dictionary<Type, SerializationType> typeMap = new Dictionary<Type, SerializationType>();

			private readonly List<SerializationType> types = new List<SerializationType>();

			private readonly Dictionary<string, int> assemblyNameToID = new Dictionary<string, int>();

			private readonly List<string> assemblyNames = new List<string>();

			private readonly FastSerializer fastSerializer;

			public readonly BinaryWriter writer;

			private int fixedInstanceCount;

			internal SerializationContext(FastSerializer fastSerializer, BinaryWriter writer)
			{
				this.fastSerializer = fastSerializer;
				this.writer = writer;
				instances.Add(null);
				objectTypes.Add(null);
			}

			public void MarkFixedInstances(object[] fixedInstances)
			{
				if (fixedInstances == null)
				{
					return;
				}
				foreach (object obj in fixedInstances)
				{
					if (!objectToID.ContainsKey(obj))
					{
						objectToID.Add(obj, instances.Count);
						instances.Add(obj);
						fixedInstanceCount++;
					}
				}
			}

			public void Mark(object instance)
			{
				if (instance != null && !objectToID.ContainsKey(instance))
				{
					objectToID.Add(instance, instances.Count);
					instances.Add(instance);
				}
			}

			internal void Scan()
			{
				for (int i = 1 + fixedInstanceCount; i < instances.Count; i++)
				{
					object obj = instances[i];
					ISerializable serializable = obj as ISerializable;
					Type type = obj.GetType();
					SerializationType serializationType = MarkType(type);
					objectTypes.Add(serializationType);
					if (serializable != null)
					{
						SerializationInfo serializationInfo = new SerializationInfo(type, fastSerializer.formatterConverter);
						serializable.GetObjectData(serializationInfo, fastSerializer.streamingContext);
						instances[i] = serializationInfo;
						SerializationInfoEnumerator enumerator = serializationInfo.GetEnumerator();
						while (enumerator.MoveNext())
						{
							Mark(enumerator.Current.Value);
						}
						serializationType.Writer = serializationInfoWriter;
					}
					else
					{
						ObjectScanner objectScanner = serializationType.Scanner;
						if (objectScanner == null)
						{
							objectScanner = (serializationType.Scanner = fastSerializer.GetScanner(type));
							serializationType.Writer = fastSerializer.GetWriter(type);
						}
						objectScanner(this, obj);
					}
				}
			}

			private SerializationType MarkType(Type type)
			{
				if (!typeMap.TryGetValue(type, out SerializationType value))
				{
					string assemblyName = null;
					string typeName = null;
					if (type.HasElementType)
					{
						MarkType(type.GetElementType());
					}
					else if (type.IsGenericType && !type.IsGenericTypeDefinition)
					{
						MarkType(type.GetGenericTypeDefinition());
						Type[] genericArguments = type.GetGenericArguments();
						foreach (Type type2 in genericArguments)
						{
							MarkType(type2);
						}
					}
					else
					{
						if (type.IsGenericParameter)
						{
							throw new NotSupportedException();
						}
						SerializationBinder serializationBinder = fastSerializer.SerializationBinder;
						if (serializationBinder != null)
						{
							serializationBinder.BindToName(type, out assemblyName, out typeName);
						}
						else
						{
							assemblyName = type.Assembly.FullName;
							typeName = type.FullName;
						}
					}
					value = new SerializationType(typeMap.Count, type);
					value.TypeName = typeName;
					if (assemblyName != null && !assemblyNameToID.TryGetValue(assemblyName, out value.AssemblyNameID))
					{
						value.AssemblyNameID = assemblyNames.Count;
						assemblyNameToID.Add(assemblyName, value.AssemblyNameID);
						assemblyNames.Add(assemblyName);
					}
					typeMap.Add(type, value);
					types.Add(value);
					if (type == typeof(string))
					{
						stringType = value;
					}
				}
				return value;
			}

			internal void ScanTypes()
			{
				for (int i = 0; i < types.Count; i++)
				{
					Type type = types[i].Type;
					if (!type.IsGenericTypeDefinition && !type.HasElementType && !typeof(ISerializable).IsAssignableFrom(type))
					{
						foreach (FieldInfo serializableField in GetSerializableFields(type))
						{
							MarkType(serializableField.FieldType);
						}
					}
				}
			}

			public void WriteObjectID(object instance)
			{
				int num = (instance != null) ? objectToID[instance] : 0;
				if (instances.Count <= 65535)
				{
					writer.Write((ushort)num);
				}
				else
				{
					writer.Write(num);
				}
			}

			private void WriteTypeID(Type type)
			{
				int iD = typeMap[type].ID;
				if (types.Count <= 65535)
				{
					writer.Write((ushort)iD);
				}
				else
				{
					writer.Write(iD);
				}
			}

			internal void Write()
			{
				writer.Write(1909623390);
				writer.Write(instances.Count);
				writer.Write(types.Count);
				writer.Write(assemblyNames.Count);
				writer.Write(fixedInstanceCount);
				foreach (string assemblyName in assemblyNames)
				{
					writer.Write(assemblyName);
				}
				foreach (SerializationType type4 in types)
				{
					Type type = type4.Type;
					if (type.HasElementType)
					{
						if (!type.IsArray)
						{
							throw new NotSupportedException();
						}
						if (type.GetArrayRank() != 1)
						{
							throw new NotSupportedException();
						}
						writer.Write((byte)3);
						WriteTypeID(type.GetElementType());
					}
					else if (type.IsGenericType && !type.IsGenericTypeDefinition)
					{
						writer.Write((byte)4);
						WriteTypeID(type.GetGenericTypeDefinition());
						Type[] genericArguments = type.GetGenericArguments();
						foreach (Type type2 in genericArguments)
						{
							WriteTypeID(type2);
						}
					}
					else
					{
						if (type.IsValueType)
						{
							writer.Write((byte)2);
						}
						else
						{
							writer.Write((byte)1);
						}
						if (assemblyNames.Count <= 65535)
						{
							writer.Write((ushort)type4.AssemblyNameID);
						}
						else
						{
							writer.Write(type4.AssemblyNameID);
						}
						writer.Write(type4.TypeName);
					}
				}
				foreach (SerializationType type5 in types)
				{
					Type type3 = type5.Type;
					if (!type3.IsGenericTypeDefinition && !type3.HasElementType)
					{
						writer.Write(FastSerializerVersionAttribute.GetVersionNumber(type3));
						if (type3.IsPrimitive || typeof(ISerializable).IsAssignableFrom(type3))
						{
							writer.Write(byte.MaxValue);
						}
						else
						{
							List<FieldInfo> serializableFields = GetSerializableFields(type3);
							if (serializableFields.Count >= 255)
							{
								throw new SerializationException("Too many fields.");
							}
							writer.Write((byte)serializableFields.Count);
							foreach (FieldInfo item in serializableFields)
							{
								WriteTypeID(item.FieldType);
								writer.Write(item.Name);
							}
						}
					}
				}
				for (int j = 1 + fixedInstanceCount; j < instances.Count; j++)
				{
					SerializationType serializationType = objectTypes[j];
					if (types.Count <= 65535)
					{
						writer.Write((ushort)serializationType.ID);
					}
					else
					{
						writer.Write(serializationType.ID);
					}
					if (serializationType == stringType)
					{
						writer.Write((string)instances[j]);
					}
					else if (serializationType.Type.IsArray)
					{
						writer.Write(((Array)instances[j]).Length);
					}
				}
				for (int k = 1 + fixedInstanceCount; k < instances.Count; k++)
				{
					objectTypes[k].Writer(this, instances[k]);
				}
			}
		}

		private delegate void ObjectScanner(SerializationContext context, object instance);

		private delegate void ObjectWriter(SerializationContext context, object instance);

		private delegate void TypeSerializer(object instance, SerializationContext context);

		private sealed class DeserializationContext
		{
			public Type[] Types;

			public object[] Objects;

			public BinaryReader Reader;

			public object ReadObject()
			{
				if (Objects.Length <= 65535)
				{
					return Objects[Reader.ReadUInt16()];
				}
				return Objects[Reader.ReadInt32()];
			}

			internal int ReadTypeID()
			{
				if (Types.Length <= 65535)
				{
					return Reader.ReadUInt16();
				}
				return Reader.ReadInt32();
			}

			internal void DeserializeTypeDescriptions()
			{
				int num = 0;
				Type type;
				while (true)
				{
					if (num >= Types.Length)
					{
						return;
					}
					type = Types[num];
					if (!type.IsGenericTypeDefinition && !type.HasElementType)
					{
						int num2 = Reader.ReadInt32();
						if (num2 != FastSerializerVersionAttribute.GetVersionNumber(type))
						{
							throw new SerializationException("Type '" + type.FullName + "' was serialized with version " + num2 + ", but is version " + FastSerializerVersionAttribute.GetVersionNumber(type));
						}
						bool flag = typeof(ISerializable).IsAssignableFrom(type);
						bool flag2 = type.IsPrimitive | flag;
						byte b = Reader.ReadByte();
						if (b == byte.MaxValue)
						{
							if (!flag2)
							{
								throw new SerializationException("Type '" + type.FullName + "' was serialized as special type, but isn't special now.");
							}
						}
						else
						{
							if (flag2)
							{
								throw new SerializationException("Type '" + type.FullName + "' wasn't serialized as special type, but is special now.");
							}
							List<FieldInfo> serializableFields = GetSerializableFields(Types[num]);
							if (serializableFields.Count != b)
							{
								break;
							}
							for (int i = 0; i < b; i++)
							{
								int num3 = ReadTypeID();
								string text = Reader.ReadString();
								FieldInfo fieldInfo = serializableFields[i];
								if (fieldInfo.Name != text)
								{
									throw new SerializationException("Field mismatch on type " + type.FullName);
								}
								if (fieldInfo.FieldType != Types[num3])
								{
									throw new SerializationException(type.FullName + "." + text + " was serialized as " + Types[num3] + ", but now is " + fieldInfo.FieldType);
								}
							}
						}
					}
					num++;
				}
				throw new SerializationException("Number of fields on " + type.FullName + " has changed.");
			}
		}

		private delegate void ObjectReader(DeserializationContext context, object instance);

		private struct CustomDeserialization
		{
			private readonly object instance;

			private readonly SerializationInfo serializationInfo;

			private readonly CustomDeserializationAction action;

			public CustomDeserialization(object instance, SerializationInfo serializationInfo, CustomDeserializationAction action)
			{
				this.instance = instance;
				this.serializationInfo = serializationInfo;
				this.action = action;
			}

			public void Run(StreamingContext context)
			{
				action(instance, serializationInfo, context);
			}
		}

		private delegate void CustomDeserializationAction(object instance, SerializationInfo info, StreamingContext context);

		private const int magic = 1909623390;

		private const byte Type_ReferenceType = 1;

		private const byte Type_ValueType = 2;

		private const byte Type_SZArray = 3;

		private const byte Type_ParameterizedType = 4;

		private static readonly MethodInfo mark = typeof(SerializationContext).GetMethod("Mark", new Type[1]
		{
			typeof(object)
		});

		private static readonly FieldInfo writerField = typeof(SerializationContext).GetField("writer");

		private Dictionary<Type, ObjectScanner> scanners = new Dictionary<Type, ObjectScanner>();

		private static readonly MethodInfo writeObjectID = typeof(SerializationContext).GetMethod("WriteObjectID", new Type[1]
		{
			typeof(object)
		});

		private static readonly MethodInfo writeByte = typeof(BinaryWriter).GetMethod("Write", new Type[1]
		{
			typeof(byte)
		});

		private static readonly MethodInfo writeShort = typeof(BinaryWriter).GetMethod("Write", new Type[1]
		{
			typeof(short)
		});

		private static readonly MethodInfo writeInt = typeof(BinaryWriter).GetMethod("Write", new Type[1]
		{
			typeof(int)
		});

		private static readonly MethodInfo writeLong = typeof(BinaryWriter).GetMethod("Write", new Type[1]
		{
			typeof(long)
		});

		private static readonly MethodInfo writeFloat = typeof(BinaryWriter).GetMethod("Write", new Type[1]
		{
			typeof(float)
		});

		private static readonly MethodInfo writeDouble = typeof(BinaryWriter).GetMethod("Write", new Type[1]
		{
			typeof(double)
		});

		private OpCode callVirt = OpCodes.Callvirt;

		private static readonly ObjectWriter serializationInfoWriter = delegate(SerializationContext context, object instance)
		{
			BinaryWriter writer = context.writer;
			SerializationInfo serializationInfo = (SerializationInfo)instance;
			writer.Write(serializationInfo.MemberCount);
			SerializationInfoEnumerator enumerator = serializationInfo.GetEnumerator();
			while (enumerator.MoveNext())
			{
				SerializationEntry current = enumerator.Current;
				writer.Write(current.Name);
				context.WriteObjectID(current.Value);
			}
		};

		private Dictionary<Type, ObjectWriter> writers = new Dictionary<Type, ObjectWriter>();

		private StreamingContext streamingContext = new StreamingContext(StreamingContextStates.All);

		private FormatterConverter formatterConverter = new FormatterConverter();

		private static readonly FieldInfo readerField = typeof(DeserializationContext).GetField("Reader");

		private static readonly MethodInfo readObject = typeof(DeserializationContext).GetMethod("ReadObject");

		private static readonly MethodInfo readByte = typeof(BinaryReader).GetMethod("ReadByte");

		private static readonly MethodInfo readShort = typeof(BinaryReader).GetMethod("ReadInt16");

		private static readonly MethodInfo readInt = typeof(BinaryReader).GetMethod("ReadInt32");

		private static readonly MethodInfo readLong = typeof(BinaryReader).GetMethod("ReadInt64");

		private static readonly MethodInfo readFloat = typeof(BinaryReader).GetMethod("ReadSingle");

		private static readonly MethodInfo readDouble = typeof(BinaryReader).GetMethod("ReadDouble");

		private Dictionary<Type, ObjectReader> readers = new Dictionary<Type, ObjectReader>();

		private Dictionary<Type, CustomDeserializationAction> customDeserializationActions = new Dictionary<Type, CustomDeserializationAction>();

		public SerializationBinder SerializationBinder
		{
			get;
			set;
		}

		public object[] FixedInstances
		{
			get;
			set;
		}

		private ObjectScanner GetScanner(Type type)
		{
			if (!scanners.TryGetValue(type, out ObjectScanner value))
			{
				value = CreateScanner(type);
				scanners.Add(type, value);
			}
			return value;
		}

		private ObjectScanner CreateScanner(Type type)
		{
			bool isArray = type.IsArray;
			if (isArray)
			{
				if (type.GetArrayRank() != 1)
				{
					throw new NotSupportedException();
				}
				type = type.GetElementType();
				if (!type.IsValueType)
				{
					return delegate(SerializationContext context, object array)
					{
						object[] array2 = (object[])array;
						foreach (object instance in array2)
						{
							context.Mark(instance);
						}
					};
				}
			}
			Type type2 = type;
			while (type2 != null)
			{
				if (!type2.IsSerializable)
				{
					throw new SerializationException("Type " + type2 + " is not [Serializable].");
				}
				type2 = type2.BaseType;
			}
			List<FieldInfo> serializableFields = GetSerializableFields(type);
			serializableFields.RemoveAll((FieldInfo f) => !IsReferenceOrContainsReferences(f.FieldType));
			if (serializableFields.Count == 0)
			{
				return delegate
				{
				};
			}
			DynamicMethod dynamicMethod = new DynamicMethod((isArray ? "ScanArray_" : "Scan_") + type.Name, typeof(void), new Type[2]
			{
				typeof(SerializationContext),
				typeof(object)
			}, restrictedSkipVisibility: true);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			if (isArray)
			{
				LocalBuilder local = iLGenerator.DeclareLocal(type.MakeArrayType());
				iLGenerator.Emit(OpCodes.Ldarg_1);
				iLGenerator.Emit(OpCodes.Castclass, type.MakeArrayType());
				iLGenerator.Emit(OpCodes.Stloc, local);
				Label label = iLGenerator.DefineLabel();
				Label label2 = iLGenerator.DefineLabel();
				LocalBuilder local2 = iLGenerator.DeclareLocal(typeof(int));
				iLGenerator.Emit(OpCodes.Ldc_I4_0);
				iLGenerator.Emit(OpCodes.Stloc, local2);
				iLGenerator.Emit(OpCodes.Br, label2);
				iLGenerator.MarkLabel(label);
				iLGenerator.Emit(OpCodes.Ldloc, local);
				iLGenerator.Emit(OpCodes.Ldloc, local2);
				iLGenerator.Emit(OpCodes.Ldelem, type);
				EmitScanValueType(iLGenerator, type);
				iLGenerator.Emit(OpCodes.Ldloc, local2);
				iLGenerator.Emit(OpCodes.Ldc_I4_1);
				iLGenerator.Emit(OpCodes.Add);
				iLGenerator.Emit(OpCodes.Stloc, local2);
				iLGenerator.MarkLabel(label2);
				iLGenerator.Emit(OpCodes.Ldloc, local2);
				iLGenerator.Emit(OpCodes.Ldloc, local);
				iLGenerator.Emit(OpCodes.Ldlen);
				iLGenerator.Emit(OpCodes.Conv_I4);
				iLGenerator.Emit(OpCodes.Blt, label);
			}
			else if (type.IsValueType)
			{
				iLGenerator.Emit(OpCodes.Ldarg_1);
				iLGenerator.Emit(OpCodes.Unbox_Any, type);
				EmitScanValueType(iLGenerator, type);
			}
			else
			{
				LocalBuilder localBuilder = iLGenerator.DeclareLocal(type);
				iLGenerator.Emit(OpCodes.Ldarg_1);
				iLGenerator.Emit(OpCodes.Castclass, type);
				iLGenerator.Emit(OpCodes.Stloc, localBuilder);
				foreach (FieldInfo item in serializableFields)
				{
					EmitScanField(iLGenerator, localBuilder, item);
				}
			}
			iLGenerator.Emit(OpCodes.Ret);
			return (ObjectScanner)dynamicMethod.CreateDelegate(typeof(ObjectScanner));
		}

		private void EmitScanField(ILGenerator il, LocalBuilder instance, FieldInfo field)
		{
			if (field.FieldType.IsValueType)
			{
				il.Emit(OpCodes.Ldloc, instance);
				il.Emit(OpCodes.Ldfld, field);
				EmitScanValueType(il, field.FieldType);
			}
			else
			{
				il.Emit(OpCodes.Ldarg_0);
				il.Emit(OpCodes.Ldloc, instance);
				il.Emit(OpCodes.Ldfld, field);
				il.Emit(OpCodes.Call, mark);
			}
		}

		private void EmitScanValueType(ILGenerator il, Type valType)
		{
			LocalBuilder localBuilder = il.DeclareLocal(valType);
			il.Emit(OpCodes.Stloc, localBuilder);
			foreach (FieldInfo serializableField in GetSerializableFields(valType))
			{
				if (IsReferenceOrContainsReferences(serializableField.FieldType))
				{
					EmitScanField(il, localBuilder, serializableField);
				}
			}
		}

		private static List<FieldInfo> GetSerializableFields(Type type)
		{
			List<FieldInfo> list = new List<FieldInfo>();
			Type type2 = type;
			while (type2 != null)
			{
				FieldInfo[] fields = type2.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				Array.Sort(fields, (FieldInfo a, FieldInfo b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
				list.AddRange(fields);
				type2 = type2.BaseType;
			}
			list.RemoveAll((FieldInfo f) => f.IsNotSerialized);
			return list;
		}

		private static bool IsReferenceOrContainsReferences(Type type)
		{
			if (!type.IsValueType)
			{
				return true;
			}
			if (type.IsPrimitive)
			{
				return false;
			}
			foreach (FieldInfo serializableField in GetSerializableFields(type))
			{
				if (IsReferenceOrContainsReferences(serializableField.FieldType))
				{
					return true;
				}
			}
			return false;
		}

		private ObjectWriter GetWriter(Type type)
		{
			if (!writers.TryGetValue(type, out ObjectWriter value))
			{
				value = CreateWriter(type);
				writers.Add(type, value);
			}
			return value;
		}

		private ObjectWriter CreateWriter(Type type)
		{
			if (type == typeof(string))
			{
				return delegate
				{
				};
			}
			bool isArray = type.IsArray;
			if (isArray)
			{
				if (type.GetArrayRank() != 1)
				{
					throw new NotSupportedException();
				}
				type = type.GetElementType();
				if (!type.IsValueType)
				{
					return delegate(SerializationContext context, object array)
					{
						object[] array2 = (object[])array;
						foreach (object instance in array2)
						{
							context.WriteObjectID(instance);
						}
					};
				}
				if (type == typeof(byte))
				{
					return delegate(SerializationContext context, object array)
					{
						context.writer.Write((byte[])array);
					};
				}
			}
			List<FieldInfo> serializableFields = GetSerializableFields(type);
			if (serializableFields.Count == 0)
			{
				return delegate
				{
				};
			}
			DynamicMethod dynamicMethod = new DynamicMethod((isArray ? "WriteArray_" : "Write_") + type.Name, typeof(void), new Type[2]
			{
				typeof(SerializationContext),
				typeof(object)
			}, restrictedSkipVisibility: true);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			LocalBuilder localBuilder = iLGenerator.DeclareLocal(typeof(BinaryWriter));
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldfld, writerField);
			iLGenerator.Emit(OpCodes.Stloc, localBuilder);
			if (isArray)
			{
				LocalBuilder local = iLGenerator.DeclareLocal(type.MakeArrayType());
				iLGenerator.Emit(OpCodes.Ldarg_1);
				iLGenerator.Emit(OpCodes.Castclass, type.MakeArrayType());
				iLGenerator.Emit(OpCodes.Stloc, local);
				Label label = iLGenerator.DefineLabel();
				Label label2 = iLGenerator.DefineLabel();
				LocalBuilder local2 = iLGenerator.DeclareLocal(typeof(int));
				iLGenerator.Emit(OpCodes.Ldc_I4_0);
				iLGenerator.Emit(OpCodes.Stloc, local2);
				iLGenerator.Emit(OpCodes.Br, label2);
				iLGenerator.MarkLabel(label);
				if (type.IsEnum || type.IsPrimitive)
				{
					if (type.IsEnum)
					{
						type = type.GetEnumUnderlyingType();
					}
					iLGenerator.Emit(OpCodes.Ldloc, localBuilder);
					iLGenerator.Emit(OpCodes.Ldloc, local);
					iLGenerator.Emit(OpCodes.Ldloc, local2);
					switch (Type.GetTypeCode(type))
					{
					case TypeCode.Boolean:
					case TypeCode.SByte:
					case TypeCode.Byte:
						iLGenerator.Emit(OpCodes.Ldelem_I1);
						iLGenerator.Emit(callVirt, writeByte);
						break;
					case TypeCode.Char:
					case TypeCode.Int16:
					case TypeCode.UInt16:
						iLGenerator.Emit(OpCodes.Ldelem_I2);
						iLGenerator.Emit(callVirt, writeShort);
						break;
					case TypeCode.Int32:
					case TypeCode.UInt32:
						iLGenerator.Emit(OpCodes.Ldelem_I4);
						iLGenerator.Emit(callVirt, writeInt);
						break;
					case TypeCode.Int64:
					case TypeCode.UInt64:
						iLGenerator.Emit(OpCodes.Ldelem_I8);
						iLGenerator.Emit(callVirt, writeLong);
						break;
					case TypeCode.Single:
						iLGenerator.Emit(OpCodes.Ldelem_R4);
						iLGenerator.Emit(callVirt, writeFloat);
						break;
					case TypeCode.Double:
						iLGenerator.Emit(OpCodes.Ldelem_R8);
						iLGenerator.Emit(callVirt, writeDouble);
						break;
					default:
						throw new NotSupportedException("Unknown primitive type " + type);
					}
				}
				else
				{
					iLGenerator.Emit(OpCodes.Ldloc, local);
					iLGenerator.Emit(OpCodes.Ldloc, local2);
					iLGenerator.Emit(OpCodes.Ldelem, type);
					EmitWriteValueType(iLGenerator, localBuilder, type);
				}
				iLGenerator.Emit(OpCodes.Ldloc, local2);
				iLGenerator.Emit(OpCodes.Ldc_I4_1);
				iLGenerator.Emit(OpCodes.Add);
				iLGenerator.Emit(OpCodes.Stloc, local2);
				iLGenerator.MarkLabel(label2);
				iLGenerator.Emit(OpCodes.Ldloc, local2);
				iLGenerator.Emit(OpCodes.Ldloc, local);
				iLGenerator.Emit(OpCodes.Ldlen);
				iLGenerator.Emit(OpCodes.Conv_I4);
				iLGenerator.Emit(OpCodes.Blt, label);
			}
			else if (type.IsValueType)
			{
				if (type.IsEnum || type.IsPrimitive)
				{
					iLGenerator.Emit(OpCodes.Ldloc, localBuilder);
					iLGenerator.Emit(OpCodes.Ldarg_1);
					iLGenerator.Emit(OpCodes.Unbox_Any, type);
					WritePrimitiveValue(iLGenerator, type);
				}
				else
				{
					iLGenerator.Emit(OpCodes.Ldarg_1);
					iLGenerator.Emit(OpCodes.Unbox_Any, type);
					EmitWriteValueType(iLGenerator, localBuilder, type);
				}
			}
			else
			{
				LocalBuilder localBuilder2 = iLGenerator.DeclareLocal(type);
				iLGenerator.Emit(OpCodes.Ldarg_1);
				iLGenerator.Emit(OpCodes.Castclass, type);
				iLGenerator.Emit(OpCodes.Stloc, localBuilder2);
				foreach (FieldInfo item in serializableFields)
				{
					EmitWriteField(iLGenerator, localBuilder, localBuilder2, item);
				}
			}
			iLGenerator.Emit(OpCodes.Ret);
			return (ObjectWriter)dynamicMethod.CreateDelegate(typeof(ObjectWriter));
		}

		private void EmitWriteField(ILGenerator il, LocalBuilder writer, LocalBuilder instance, FieldInfo field)
		{
			Type fieldType = field.FieldType;
			if (fieldType.IsValueType)
			{
				if (fieldType.IsPrimitive || fieldType.IsEnum)
				{
					il.Emit(OpCodes.Ldloc, writer);
					il.Emit(OpCodes.Ldloc, instance);
					il.Emit(OpCodes.Ldfld, field);
					WritePrimitiveValue(il, fieldType);
				}
				else
				{
					il.Emit(OpCodes.Ldloc, instance);
					il.Emit(OpCodes.Ldfld, field);
					EmitWriteValueType(il, writer, fieldType);
				}
			}
			else
			{
				il.Emit(OpCodes.Ldarg_0);
				il.Emit(OpCodes.Ldloc, instance);
				il.Emit(OpCodes.Ldfld, field);
				il.Emit(OpCodes.Call, writeObjectID);
			}
		}

		private void WritePrimitiveValue(ILGenerator il, Type fieldType)
		{
			if (fieldType.IsEnum)
			{
				fieldType = fieldType.GetEnumUnderlyingType();
			}
			switch (Type.GetTypeCode(fieldType))
			{
			case TypeCode.Boolean:
			case TypeCode.SByte:
			case TypeCode.Byte:
				il.Emit(callVirt, writeByte);
				break;
			case TypeCode.Char:
			case TypeCode.Int16:
			case TypeCode.UInt16:
				il.Emit(callVirt, writeShort);
				break;
			case TypeCode.Int32:
			case TypeCode.UInt32:
				il.Emit(callVirt, writeInt);
				break;
			case TypeCode.Int64:
			case TypeCode.UInt64:
				il.Emit(callVirt, writeLong);
				break;
			case TypeCode.Single:
				il.Emit(callVirt, writeFloat);
				break;
			case TypeCode.Double:
				il.Emit(callVirt, writeDouble);
				break;
			default:
				throw new NotSupportedException("Unknown primitive type " + fieldType);
			}
		}

		private void EmitWriteValueType(ILGenerator il, LocalBuilder writer, Type valType)
		{
			LocalBuilder localBuilder = il.DeclareLocal(valType);
			il.Emit(OpCodes.Stloc, localBuilder);
			foreach (FieldInfo serializableField in GetSerializableFields(valType))
			{
				EmitWriteField(il, writer, localBuilder, serializableField);
			}
		}

		public void Serialize(Stream stream, object instance)
		{
			Serialize(new BinaryWriterWith7BitEncodedInts(stream), instance);
		}

		public void Serialize(BinaryWriter writer, object instance)
		{
			SerializationContext serializationContext = new SerializationContext(this, writer);
			serializationContext.MarkFixedInstances(FixedInstances);
			serializationContext.Mark(instance);
			serializationContext.Scan();
			serializationContext.ScanTypes();
			serializationContext.Write();
			serializationContext.WriteObjectID(instance);
		}

		public object Deserialize(Stream stream)
		{
			return Deserialize(new BinaryReaderWith7BitEncodedInts(stream));
		}

		public object Deserialize(BinaryReader reader)
		{
			if (reader.ReadInt32() != 1909623390)
			{
				throw new SerializationException("The data cannot be read by FastSerializer (unknown magic value)");
			}
			DeserializationContext deserializationContext = new DeserializationContext();
			deserializationContext.Reader = reader;
			deserializationContext.Objects = new object[reader.ReadInt32()];
			deserializationContext.Types = new Type[reader.ReadInt32()];
			string[] array = new string[reader.ReadInt32()];
			int num = reader.ReadInt32();
			if (num != 0)
			{
				if (FixedInstances == null || FixedInstances.Length != num)
				{
					throw new SerializationException("Number of fixed instances doesn't match");
				}
				for (int i = 0; i < num; i++)
				{
					deserializationContext.Objects[i + 1] = FixedInstances[i];
				}
			}
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = reader.ReadString();
			}
			int num2 = -1;
			for (int k = 0; k < deserializationContext.Types.Length; k++)
			{
				byte b = reader.ReadByte();
				switch (b)
				{
				case 1:
				case 2:
				{
					int num3 = (array.Length > 65535) ? reader.ReadInt32() : reader.ReadUInt16();
					string text = array[num3];
					string text2 = reader.ReadString();
					Type type2 = (SerializationBinder == null) ? Assembly.Load(text).GetType(text2) : SerializationBinder.BindToType(text, text2);
					if (type2 == null)
					{
						throw new SerializationException("Could not find '" + text2 + "' in '" + text + "'");
					}
					if (b == 2 && !type2.IsValueType)
					{
						throw new SerializationException("Expected '" + text2 + "' to be a value type, but it is reference type");
					}
					if (b == 1 && type2.IsValueType)
					{
						throw new SerializationException("Expected '" + text2 + "' to be a reference type, but it is value type");
					}
					deserializationContext.Types[k] = type2;
					if (type2 == typeof(string))
					{
						num2 = k;
					}
					break;
				}
				case 3:
					deserializationContext.Types[k] = deserializationContext.Types[deserializationContext.ReadTypeID()].MakeArrayType();
					break;
				case 4:
				{
					Type type = deserializationContext.Types[deserializationContext.ReadTypeID()];
					Type[] array2 = new Type[type.GetGenericArguments().Length];
					for (int l = 0; l < array2.Length; l++)
					{
						array2[l] = deserializationContext.Types[deserializationContext.ReadTypeID()];
					}
					deserializationContext.Types[k] = type.MakeGenericType(array2);
					break;
				}
				default:
					throw new SerializationException("Unknown type kind");
				}
			}
			deserializationContext.DeserializeTypeDescriptions();
			int[] array3 = new int[deserializationContext.Objects.Length];
			for (int m = 1 + num; m < deserializationContext.Objects.Length; m++)
			{
				int num4 = deserializationContext.ReadTypeID();
				object obj;
				if (num4 == num2)
				{
					obj = reader.ReadString();
				}
				else
				{
					Type type3 = deserializationContext.Types[num4];
					if (type3.IsArray)
					{
						int length = reader.ReadInt32();
						obj = Array.CreateInstance(type3.GetElementType(), length);
					}
					else
					{
						obj = FormatterServices.GetUninitializedObject(type3);
					}
				}
				deserializationContext.Objects[m] = obj;
				array3[m] = num4;
			}
			List<CustomDeserialization> list = new List<CustomDeserialization>();
			ObjectReader[] array4 = new ObjectReader[deserializationContext.Types.Length];
			for (int n = 1 + num; n < deserializationContext.Objects.Length; n++)
			{
				object obj2 = deserializationContext.Objects[n];
				int num5 = array3[n];
				if (obj2 is ISerializable)
				{
					Type type4 = deserializationContext.Types[num5];
					SerializationInfo serializationInfo = new SerializationInfo(type4, formatterConverter);
					int num6 = reader.ReadInt32();
					for (int num7 = 0; num7 < num6; num7++)
					{
						string name = reader.ReadString();
						object value = deserializationContext.ReadObject();
						serializationInfo.AddValue(name, value);
					}
					CustomDeserializationAction customDeserializationAction = GetCustomDeserializationAction(type4);
					list.Add(new CustomDeserialization(obj2, serializationInfo, customDeserializationAction));
				}
				else
				{
					ObjectReader objectReader = array4[num5];
					if (objectReader == null)
					{
						objectReader = (array4[num5] = GetReader(deserializationContext.Types[num5]));
					}
					objectReader(deserializationContext, obj2);
				}
			}
			foreach (CustomDeserialization item in list)
			{
				item.Run(streamingContext);
			}
			for (int num8 = 1 + num; num8 < deserializationContext.Objects.Length; num8++)
			{
				(deserializationContext.Objects[num8] as IDeserializationCallback)?.OnDeserialization(null);
			}
			return deserializationContext.ReadObject();
		}

		private ObjectReader GetReader(Type type)
		{
			if (!readers.TryGetValue(type, out ObjectReader value))
			{
				value = CreateReader(type);
				readers.Add(type, value);
			}
			return value;
		}

		private ObjectReader CreateReader(Type type)
		{
			if (type == typeof(string))
			{
				return delegate
				{
				};
			}
			bool isArray = type.IsArray;
			if (isArray)
			{
				if (type.GetArrayRank() != 1)
				{
					throw new NotSupportedException();
				}
				type = type.GetElementType();
				if (!type.IsValueType)
				{
					return delegate(DeserializationContext context, object arrayInstance)
					{
						object[] array2 = (object[])arrayInstance;
						for (int i = 0; i < array2.Length; i++)
						{
							array2[i] = context.ReadObject();
						}
					};
				}
				if (type == typeof(byte))
				{
					return delegate(DeserializationContext context, object arrayInstance)
					{
						byte[] array = (byte[])arrayInstance;
						BinaryReader reader = context.Reader;
						int num = 0;
						int num2;
						do
						{
							num2 = reader.Read(array, num, array.Length - num);
							num += num2;
						}
						while (num2 > 0);
						if (num != array.Length)
						{
							throw new EndOfStreamException();
						}
					};
				}
			}
			List<FieldInfo> serializableFields = GetSerializableFields(type);
			if (serializableFields.Count == 0)
			{
				return delegate
				{
				};
			}
			DynamicMethod dynamicMethod = new DynamicMethod((isArray ? "ReadArray_" : "Read_") + type.Name, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, CallingConventions.Standard, typeof(void), new Type[2]
			{
				typeof(DeserializationContext),
				typeof(object)
			}, type, skipVisibility: true);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			LocalBuilder localBuilder = iLGenerator.DeclareLocal(typeof(BinaryReader));
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldfld, readerField);
			iLGenerator.Emit(OpCodes.Stloc, localBuilder);
			if (isArray)
			{
				LocalBuilder local = iLGenerator.DeclareLocal(type.MakeArrayType());
				iLGenerator.Emit(OpCodes.Ldarg_1);
				iLGenerator.Emit(OpCodes.Castclass, type.MakeArrayType());
				iLGenerator.Emit(OpCodes.Stloc, local);
				Label label = iLGenerator.DefineLabel();
				Label label2 = iLGenerator.DefineLabel();
				LocalBuilder local2 = iLGenerator.DeclareLocal(typeof(int));
				iLGenerator.Emit(OpCodes.Ldc_I4_0);
				iLGenerator.Emit(OpCodes.Stloc, local2);
				iLGenerator.Emit(OpCodes.Br, label2);
				iLGenerator.MarkLabel(label);
				if (type.IsEnum || type.IsPrimitive)
				{
					if (type.IsEnum)
					{
						type = type.GetEnumUnderlyingType();
					}
					iLGenerator.Emit(OpCodes.Ldloc, local);
					iLGenerator.Emit(OpCodes.Ldloc, local2);
					ReadPrimitiveValue(iLGenerator, localBuilder, type);
					switch (Type.GetTypeCode(type))
					{
					case TypeCode.Boolean:
					case TypeCode.SByte:
					case TypeCode.Byte:
						iLGenerator.Emit(OpCodes.Stelem_I1);
						break;
					case TypeCode.Char:
					case TypeCode.Int16:
					case TypeCode.UInt16:
						iLGenerator.Emit(OpCodes.Stelem_I2);
						break;
					case TypeCode.Int32:
					case TypeCode.UInt32:
						iLGenerator.Emit(OpCodes.Stelem_I4);
						break;
					case TypeCode.Int64:
					case TypeCode.UInt64:
						iLGenerator.Emit(OpCodes.Stelem_I8);
						break;
					case TypeCode.Single:
						iLGenerator.Emit(OpCodes.Stelem_R4);
						break;
					case TypeCode.Double:
						iLGenerator.Emit(OpCodes.Stelem_R8);
						break;
					default:
						throw new NotSupportedException("Unknown primitive type " + type);
					}
				}
				else
				{
					iLGenerator.Emit(OpCodes.Ldloc, local);
					iLGenerator.Emit(OpCodes.Ldloc, local2);
					iLGenerator.Emit(OpCodes.Ldelema, type);
					EmitReadValueType(iLGenerator, localBuilder, type);
				}
				iLGenerator.Emit(OpCodes.Ldloc, local2);
				iLGenerator.Emit(OpCodes.Ldc_I4_1);
				iLGenerator.Emit(OpCodes.Add);
				iLGenerator.Emit(OpCodes.Stloc, local2);
				iLGenerator.MarkLabel(label2);
				iLGenerator.Emit(OpCodes.Ldloc, local2);
				iLGenerator.Emit(OpCodes.Ldloc, local);
				iLGenerator.Emit(OpCodes.Ldlen);
				iLGenerator.Emit(OpCodes.Conv_I4);
				iLGenerator.Emit(OpCodes.Blt, label);
			}
			else if (type.IsValueType)
			{
				iLGenerator.Emit(OpCodes.Ldarg_1);
				iLGenerator.Emit(OpCodes.Unbox, type);
				if (type.IsEnum || type.IsPrimitive)
				{
					if (type.IsEnum)
					{
						type = type.GetEnumUnderlyingType();
					}
					ReadPrimitiveValue(iLGenerator, localBuilder, type);
					switch (Type.GetTypeCode(type))
					{
					case TypeCode.Boolean:
					case TypeCode.SByte:
					case TypeCode.Byte:
						iLGenerator.Emit(OpCodes.Stind_I1);
						break;
					case TypeCode.Char:
					case TypeCode.Int16:
					case TypeCode.UInt16:
						iLGenerator.Emit(OpCodes.Stind_I2);
						break;
					case TypeCode.Int32:
					case TypeCode.UInt32:
						iLGenerator.Emit(OpCodes.Stind_I4);
						break;
					case TypeCode.Int64:
					case TypeCode.UInt64:
						iLGenerator.Emit(OpCodes.Stind_I8);
						break;
					case TypeCode.Single:
						iLGenerator.Emit(OpCodes.Stind_R4);
						break;
					case TypeCode.Double:
						iLGenerator.Emit(OpCodes.Stind_R8);
						break;
					default:
						throw new NotSupportedException("Unknown primitive type " + type);
					}
				}
				else
				{
					EmitReadValueType(iLGenerator, localBuilder, type);
				}
			}
			else
			{
				LocalBuilder localBuilder2 = iLGenerator.DeclareLocal(type);
				iLGenerator.Emit(OpCodes.Ldarg_1);
				iLGenerator.Emit(OpCodes.Castclass, type);
				iLGenerator.Emit(OpCodes.Stloc, localBuilder2);
				foreach (FieldInfo item in serializableFields)
				{
					EmitReadField(iLGenerator, localBuilder, localBuilder2, item);
				}
			}
			iLGenerator.Emit(OpCodes.Ret);
			return (ObjectReader)dynamicMethod.CreateDelegate(typeof(ObjectReader));
		}

		private void EmitReadField(ILGenerator il, LocalBuilder reader, LocalBuilder instance, FieldInfo field)
		{
			Type fieldType = field.FieldType;
			if (fieldType.IsValueType)
			{
				if (fieldType.IsPrimitive || fieldType.IsEnum)
				{
					il.Emit(OpCodes.Ldloc, instance);
					ReadPrimitiveValue(il, reader, fieldType);
					il.Emit(OpCodes.Stfld, field);
				}
				else
				{
					il.Emit(OpCodes.Ldloc, instance);
					il.Emit(OpCodes.Ldflda, field);
					EmitReadValueType(il, reader, fieldType);
				}
			}
			else
			{
				il.Emit(OpCodes.Ldloc, instance);
				il.Emit(OpCodes.Ldarg_0);
				il.Emit(OpCodes.Call, readObject);
				il.Emit(OpCodes.Castclass, fieldType);
				il.Emit(OpCodes.Stfld, field);
			}
		}

		private void ReadPrimitiveValue(ILGenerator il, LocalBuilder reader, Type fieldType)
		{
			if (fieldType.IsEnum)
			{
				fieldType = fieldType.GetEnumUnderlyingType();
			}
			il.Emit(OpCodes.Ldloc, reader);
			switch (Type.GetTypeCode(fieldType))
			{
			case TypeCode.Boolean:
			case TypeCode.SByte:
			case TypeCode.Byte:
				il.Emit(callVirt, readByte);
				break;
			case TypeCode.Char:
			case TypeCode.Int16:
			case TypeCode.UInt16:
				il.Emit(callVirt, readShort);
				break;
			case TypeCode.Int32:
			case TypeCode.UInt32:
				il.Emit(callVirt, readInt);
				break;
			case TypeCode.Int64:
			case TypeCode.UInt64:
				il.Emit(callVirt, readLong);
				break;
			case TypeCode.Single:
				il.Emit(callVirt, readFloat);
				break;
			case TypeCode.Double:
				il.Emit(callVirt, readDouble);
				break;
			default:
				throw new NotSupportedException("Unknown primitive type " + fieldType);
			}
		}

		private void EmitReadValueType(ILGenerator il, LocalBuilder reader, Type valType)
		{
			LocalBuilder localBuilder = il.DeclareLocal(valType.MakeByRefType());
			il.Emit(OpCodes.Stloc, localBuilder);
			foreach (FieldInfo serializableField in GetSerializableFields(valType))
			{
				EmitReadField(il, reader, localBuilder, serializableField);
			}
		}

		private CustomDeserializationAction GetCustomDeserializationAction(Type type)
		{
			if (!customDeserializationActions.TryGetValue(type, out CustomDeserializationAction value))
			{
				value = CreateCustomDeserializationAction(type);
				customDeserializationActions.Add(type, value);
			}
			return value;
		}

		private static CustomDeserializationAction CreateCustomDeserializationAction(Type type)
		{
			ConstructorInfo constructor = type.GetConstructor(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.ExactBinding, null, new Type[2]
			{
				typeof(SerializationInfo),
				typeof(StreamingContext)
			}, null);
			if (constructor == null)
			{
				throw new SerializationException("Could not find deserialization constructor for " + type.FullName);
			}
			DynamicMethod dynamicMethod = new DynamicMethod("CallCtor_" + type.Name, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static, CallingConventions.Standard, typeof(void), new Type[3]
			{
				typeof(object),
				typeof(SerializationInfo),
				typeof(StreamingContext)
			}, type, skipVisibility: true);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldarg_1);
			iLGenerator.Emit(OpCodes.Ldarg_2);
			iLGenerator.Emit(OpCodes.Call, constructor);
			iLGenerator.Emit(OpCodes.Ret);
			return (CustomDeserializationAction)dynamicMethod.CreateDelegate(typeof(CustomDeserializationAction));
		}

		[Conditional("DEBUG_SERIALIZER")]
		private static void Log(string format, params object[] args)
		{
		}
	}
}
