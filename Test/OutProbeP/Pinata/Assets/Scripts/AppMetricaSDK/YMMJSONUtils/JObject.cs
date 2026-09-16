using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace YMMJSONUtils
{
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x72E9FC", Offset = "0x72E9FC")]
	[Token(Token = "0x200001D")]
	public class JObject
	{
		[CompilerGenerated]
		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x10")]
		private JObjectKind _003CKind_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x18")]
		private Dictionary<string, JObject> _003CObjectValue_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x20")]
		private List<JObject> _003CArrayValue_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x28")]
		private string _003CStringValue_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x30")]
		private bool _003CBooleanValue_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x38")]
		private double _003CDoubleValue_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x40")]
		private float _003CFloatValue_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x48")]
		private ulong _003CULongValue_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x50")]
		private long _003CLongValue_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000059")]
		[FieldOffset(Offset = "0x58")]
		private uint _003CUIntValue_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400005A")]
		[FieldOffset(Offset = "0x5C")]
		private int _003CIntValue_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x60")]
		private ushort _003CUShortValue_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x62")]
		private short _003CShortValue_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0x64")]
		private byte _003CByteValue_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0x65")]
		private sbyte _003CSByteValue_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0x66")]
		private bool _003CIsNegative_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x67")]
		private bool _003CIsFractional_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x68")]
		private IntegerSize _003CMinInteger_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x6C")]
		private FloatSize _003CMinFloat_003Ek__BackingField;

		[Token(Token = "0x17000026")]
		public JObjectKind Kind
		{
			[CompilerGenerated]
			[Token(Token = "0x60000CB")]
			[Address(RVA = "0x15BBB64", Offset = "0x15BBB64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Kind>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Kind;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000CC")]
			[Address(RVA = "0x15BBB6C", Offset = "0x15BBB6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Kind>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CKind_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000027")]
		public Dictionary<string, JObject> ObjectValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000CD")]
			[Address(RVA = "0x15BBB74", Offset = "0x15BBB74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ObjectValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ObjectValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000CE")]
			[Address(RVA = "0x15BBB7C", Offset = "0x15BBB7C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ObjectValue>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CObjectValue_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000028")]
		public List<JObject> ArrayValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000CF")]
			[Address(RVA = "0x15BBB84", Offset = "0x15BBB84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ArrayValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ArrayValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000D0")]
			[Address(RVA = "0x15BBB8C", Offset = "0x15BBB8C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ArrayValue>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CArrayValue_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000029")]
		public string StringValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000D1")]
			[Address(RVA = "0x15BBB94", Offset = "0x15BBB94", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<StringValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return StringValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000D2")]
			[Address(RVA = "0x15BBB9C", Offset = "0x15BBB9C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<StringValue>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CStringValue_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700002A")]
		public bool BooleanValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000D3")]
			[Address(RVA = "0x15BBBA4", Offset = "0x15BBBA4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<BooleanValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BooleanValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000D4")]
			[Address(RVA = "0x15BBBAC", Offset = "0x15BBBAC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<BooleanValue>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CBooleanValue_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700002B")]
		public int Count
		{
			[Token(Token = "0x60000D5")]
			[Address(RVA = "0x15BBBB8", Offset = "0x15BBBB8", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE95B8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029926]) = v38;\nL_0018:\n\tv44 = this.<Kind>k__BackingField == 1;\n\tif (v44) goto L_002E;\n\tv49 = this.<Kind>k__BackingField == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_FFFFFFFF;\n\treturnVal3 = System.Collections.Generic.Dictionary`2<System.String, YMMJSONUtils.JObject>::get_Count(this.<ObjectValue>k__BackingField);\n\treturn returnVal3;\nL_002E:\n\tv51 = this.<ArrayValue>k__BackingField;\n\treturnVal1 = v51._size;\n\tgoto L_0039;\nL_0039:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (Kind != JObjectKind.Array)
				{
					if (Kind == JObjectKind.Object)
					{
						return ObjectValue.Count;
					}
					return 0;
				}
				List<JObject> arrayValue = ArrayValue;
				return arrayValue.Count;
			}
		}

		[Token(Token = "0x1700002C")]
		public double DoubleValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000D6")]
			[Address(RVA = "0x15BBC48", Offset = "0x15BBC48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<DoubleValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DoubleValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000D7")]
			[Address(RVA = "0x15BBC50", Offset = "0x15BBC50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<DoubleValue>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CDoubleValue_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700002D")]
		public float FloatValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000D8")]
			[Address(RVA = "0x15BBC58", Offset = "0x15BBC58", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<FloatValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FloatValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000D9")]
			[Address(RVA = "0x15BBC60", Offset = "0x15BBC60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<FloatValue>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CFloatValue_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700002E")]
		public ulong ULongValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000DA")]
			[Address(RVA = "0x15BBC68", Offset = "0x15BBC68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ULongValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ULongValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000DB")]
			[Address(RVA = "0x15BBC70", Offset = "0x15BBC70", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ULongValue>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CULongValue_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700002F")]
		public long LongValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000DC")]
			[Address(RVA = "0x15BBC78", Offset = "0x15BBC78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<LongValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LongValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000DD")]
			[Address(RVA = "0x15BBC80", Offset = "0x15BBC80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<LongValue>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CLongValue_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000030")]
		public uint UIntValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000DE")]
			[Address(RVA = "0x15BBC88", Offset = "0x15BBC88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<UIntValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UIntValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000DF")]
			[Address(RVA = "0x15BBC90", Offset = "0x15BBC90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<UIntValue>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CUIntValue_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000031")]
		public int IntValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000E0")]
			[Address(RVA = "0x15BBC98", Offset = "0x15BBC98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IntValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IntValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000E1")]
			[Address(RVA = "0x15BBCA0", Offset = "0x15BBCA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IntValue>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CIntValue_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000032")]
		public ushort UShortValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000E2")]
			[Address(RVA = "0x15BBCA8", Offset = "0x15BBCA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<UShortValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UShortValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000E3")]
			[Address(RVA = "0x15BBCB0", Offset = "0x15BBCB0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<UShortValue>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CUShortValue_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000033")]
		public short ShortValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000E4")]
			[Address(RVA = "0x15BBCB8", Offset = "0x15BBCB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ShortValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ShortValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000E5")]
			[Address(RVA = "0x15BBCC0", Offset = "0x15BBCC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ShortValue>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CShortValue_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000034")]
		public byte ByteValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000E6")]
			[Address(RVA = "0x15BBCC8", Offset = "0x15BBCC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ByteValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ByteValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000E7")]
			[Address(RVA = "0x15BBCD0", Offset = "0x15BBCD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ByteValue>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CByteValue_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000035")]
		public sbyte SByteValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000E8")]
			[Address(RVA = "0x15BBCD8", Offset = "0x15BBCD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<SByteValue>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SByteValue;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000E9")]
			[Address(RVA = "0x15BBCE0", Offset = "0x15BBCE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<SByteValue>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CSByteValue_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000036")]
		public bool IsNegative
		{
			[CompilerGenerated]
			[Token(Token = "0x60000EA")]
			[Address(RVA = "0x15BBCE8", Offset = "0x15BBCE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsNegative>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsNegative;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000EB")]
			[Address(RVA = "0x15BBCF0", Offset = "0x15BBCF0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsNegative>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CIsNegative_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000037")]
		public bool IsFractional
		{
			[CompilerGenerated]
			[Token(Token = "0x60000EC")]
			[Address(RVA = "0x15BBCFC", Offset = "0x15BBCFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsFractional>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsFractional;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000ED")]
			[Address(RVA = "0x15BBD04", Offset = "0x15BBD04", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsFractional>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CIsFractional_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000038")]
		public IntegerSize MinInteger
		{
			[CompilerGenerated]
			[Token(Token = "0x60000EE")]
			[Address(RVA = "0x15BBD10", Offset = "0x15BBD10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<MinInteger>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MinInteger;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000EF")]
			[Address(RVA = "0x15BBD18", Offset = "0x15BBD18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MinInteger>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CMinInteger_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000039")]
		public FloatSize MinFloat
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F0")]
			[Address(RVA = "0x15BBD20", Offset = "0x15BBD20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<MinFloat>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MinFloat;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000F1")]
			[Address(RVA = "0x15BBD28", Offset = "0x15BBD28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MinFloat>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CMinFloat_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700003A")]
		public JObject Item
		{
			[Token(Token = "0x60000F2")]
			[Address(RVA = "0x15BBD30", Offset = "0x15BBD30", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = *([1F0F370]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, key, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029927]) = v41;\nL_0022:\n\treturnVal1 = System.Collections.Generic.Dictionary`2<System.String, YMMJSONUtils.JObject>::get_Item(this.<ObjectValue>k__BackingField, key);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ObjectValue.get_Item(key);
			}
		}

		[Token(Token = "0x1700003B")]
		public JObject Item
		{
			[Token(Token = "0x60000F3")]
			[Address(RVA = "0x15BBD98", Offset = "0x15BBD98", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC5538]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, key, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029928]) = v41;\nL_0015:\n\tv42 = this.<ArrayValue>k__BackingField;\n\tv45 = v42._size < key;\n\tv46 = ~v45;\n\tv47 = v42._size - key;\n\tv49 = v47 == 0;\n\tv54 = ~v49;\n\tv55 = v46 & v54;\n\tif (v55) goto L_0027;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0027:\n\tv60 = v42._items;\n\treturn v60[key @ X1 (System.Int32)];\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<JObject> arrayValue = ArrayValue;
				bool flag = arrayValue.Count < key;
				bool flag2 = !flag;
				int num = arrayValue.Count - key;
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				JObject[] items = arrayValue._items;
				return items[key];
			}
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x15BBE14", Offset = "0x15BBE14", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn obj.<StringValue>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static explicit operator string(JObject obj)
		{
			return obj.StringValue;
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0x15BBE2C", Offset = "0x15BBE2C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn obj.<BooleanValue>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static explicit operator bool(JObject obj)
		{
			return obj.BooleanValue;
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x15BBE44", Offset = "0x15BBE44", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn obj.<DoubleValue>k__BackingField;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static explicit operator double(JObject obj)
		{
			return obj.DoubleValue;
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0x15BBE5C", Offset = "0x15BBE5C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn obj.<FloatValue>k__BackingField;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static explicit operator float(JObject obj)
		{
			return obj.FloatValue;
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0x15BBE74", Offset = "0x15BBE74", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn obj.<ULongValue>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static explicit operator ulong(JObject obj)
		{
			return obj.ULongValue;
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0x15BBE8C", Offset = "0x15BBE8C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn obj.<LongValue>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static explicit operator long(JObject obj)
		{
			return obj.LongValue;
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0x15BBEA4", Offset = "0x15BBEA4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn obj.<UIntValue>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static explicit operator uint(JObject obj)
		{
			return obj.UIntValue;
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0x15BBEBC", Offset = "0x15BBEBC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn obj.<IntValue>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static explicit operator int(JObject obj)
		{
			return obj.IntValue;
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0x15BBED4", Offset = "0x15BBED4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn obj.<UShortValue>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static explicit operator ushort(JObject obj)
		{
			return obj.UShortValue;
		}

		[Token(Token = "0x60000FD")]
		[Address(RVA = "0x15BBEEC", Offset = "0x15BBEEC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn obj.<ShortValue>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static explicit operator short(JObject obj)
		{
			return obj.ShortValue;
		}

		[Token(Token = "0x60000FE")]
		[Address(RVA = "0x15BBF04", Offset = "0x15BBF04", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn obj.<ByteValue>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static explicit operator byte(JObject obj)
		{
			return obj.ByteValue;
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0x15BBF1C", Offset = "0x15BBF1C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn obj.<SByteValue>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static explicit operator sbyte(JObject obj)
		{
			return obj.SByteValue;
		}

		[Token(Token = "0x6000100")]
		[Address(RVA = "0x15BBF34", Offset = "0x15BBF34", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC38D8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029929]) = v38;\nL_0016:\n\tv42 = new YMMJSONUtils.JObject();\n\tSystem.Object::.ctor(v42);\n\tv42.<Kind>k__BackingField = 2;\n\tv42.<StringValue>k__BackingField = str;\n\treturn v42;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static JObject CreateString(string str)
		{
			JObject jObject = new JObject();
			jObject.Kind = JObjectKind.String;
			jObject.StringValue = str;
			return jObject;
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0x15BBFD4", Offset = "0x15BBFD4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB0D30]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202992A]) = v38;\nL_0016:\n\tv42 = new YMMJSONUtils.JObject();\n\tSystem.Object::.ctor(v42);\n\tv42.<Kind>k__BackingField = 4;\n\tv42.<BooleanValue>k__BackingField = b;\n\treturn v42;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static JObject CreateBoolean(bool b)
		{
			JObject jObject = new JObject();
			jObject.Kind = JObjectKind.Boolean;
			jObject.BooleanValue = b;
			return jObject;
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0x15BC07C", Offset = "0x15BC07C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EA37A8]);\n\tv15 = *([v14 @ X8_v7]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202992B]) = v35;\nL_0014:\n\tv39 = new YMMJSONUtils.JObject();\n\tSystem.Object::.ctor(v39);\n\tv39.<Kind>k__BackingField = 5;\n\treturn v39;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static JObject CreateNull()
		{
			JObject jObject = new JObject();
			jObject.Kind = JObjectKind.Null;
			return jObject;
		}

		[Token(Token = "0x6000103")]
		[Address(RVA = "0x15BC10C", Offset = "0x15BC10C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv42 = *([1EC2818]);\n\tv43 = *([v42 @ X8_v6]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, isFractional, negativeExponent, integerPart, fractionalPart, fractionalPartLength, exponent, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([202992C]) = v56;\nL_0022:\n\tv60 = new YMMJSONUtils.JObject();\n\tYMMJSONUtils.JObject::.ctor(v60, isNegative, isFractional, negativeExponent, integerPart, fractionalPart, fractionalPartLength, exponent);\n\treturn v60;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static JObject CreateNumber(bool isNegative, bool isFractional, bool negativeExponent, ulong integerPart, ulong fractionalPart, int fractionalPartLength, ulong exponent)
		{
			return new JObject(isNegative, isFractional, negativeExponent, integerPart, fractionalPart, fractionalPartLength, exponent);
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0x15BC25C", Offset = "0x15BC25C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB7398]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202992D]) = v38;\nL_0016:\n\tv42 = new YMMJSONUtils.JObject();\n\tSystem.Object::.ctor(v42);\n\tv42.<Kind>k__BackingField = 1;\n\tv42.<ArrayValue>k__BackingField = list;\n\treturn v42;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static JObject CreateArray(List<JObject> list)
		{
			JObject jObject = new JObject();
			jObject.Kind = JObjectKind.Array;
			jObject.ArrayValue = list;
			return jObject;
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0x15BC2FC", Offset = "0x15BC2FC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC3D90]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202992E]) = v38;\nL_0016:\n\tv42 = new YMMJSONUtils.JObject();\n\tSystem.Object::.ctor(v42);\n\tv42.<Kind>k__BackingField = 0;\n\tv42.<ObjectValue>k__BackingField = dict;\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static JObject CreateObject(Dictionary<string, JObject> dict)
		{
			JObject jObject = new JObject();
			jObject.Kind = default(JObjectKind);
			jObject.ObjectValue = dict;
			return jObject;
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0x15BBFA0", Offset = "0x15BBFA0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<Kind>k__BackingField = 2;\n\tthis.<StringValue>k__BackingField = str;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private JObject(string str)
		{
			Kind = JObjectKind.String;
			StringValue = str;
		}

		[Token(Token = "0x6000107")]
		[Address(RVA = "0x15BC044", Offset = "0x15BC044", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<Kind>k__BackingField = 4;\n\tthis.<BooleanValue>k__BackingField = b;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private JObject(bool b)
		{
			Kind = JObjectKind.Boolean;
			BooleanValue = b;
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0x15BC0E0", Offset = "0x15BC0E0", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<Kind>k__BackingField = 5;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private JObject()
		{
			Kind = JObjectKind.Null;
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0x15BC1BC", Offset = "0x15BC1BC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<Kind>k__BackingField = 3;\n\tv42 = isFractional == 0;\n\tif (v42) goto L_003C;\n\tYMMJSONUtils.JObject::MakeFloat(this, isNegative, negativeExponent, integerPart, fractionalPart, fractionalPartLength, exponent);\n\treturn;\nL_003C:\n\tYMMJSONUtils.JObject::MakeInteger(this, isNegative, integerPart);\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private JObject(bool isNegative, bool isFractional, bool negativeExponent, ulong integerPart, ulong fractionalPart, int fractionalPartLength, ulong exponent)
		{
			Kind = JObjectKind.Number;
			if (isFractional)
			{
				MakeFloat(isNegative, negativeExponent, integerPart, fractionalPart, fractionalPartLength, exponent);
			}
			else
			{
				MakeInteger(isNegative, integerPart);
			}
		}

		[Token(Token = "0x600010A")]
		[Address(RVA = "0x15BC2C8", Offset = "0x15BC2C8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<Kind>k__BackingField = 1;\n\tthis.<ArrayValue>k__BackingField = list;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private JObject(List<JObject> list)
		{
			Kind = JObjectKind.Array;
			ArrayValue = list;
		}

		[Token(Token = "0x600010B")]
		[Address(RVA = "0x15BC364", Offset = "0x15BC364", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<Kind>k__BackingField = 0;\n\tthis.<ObjectValue>k__BackingField = dict;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private JObject(Dictionary<string, JObject> dict)
		{
			Kind = default(JObjectKind);
			ObjectValue = dict;
		}

		[Token(Token = "0x600010C")]
		[Address(RVA = "0x15BC394", Offset = "0x15BC394", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsNegative>k__BackingField = isNegative;\n\tv4 = isNegative == 0;\n\tif (v4) goto L_0031;\n\tv5 = 0 - integerPart;\n\tthis.<LongValue>k__BackingField = v5;\n\tthis.<MinInteger>k__BackingField = 1;\n\tv19 = v5 < 0xFFFFFFFF80000000;\n\tif (v19) goto L_FFFFFFFF;\n\tv24 = v5 + 0x8000;\n\tv25 = v24 < 0;\n\tthis.<IntValue>k__BackingField = v5;\n\tthis.<MinInteger>k__BackingField = 3;\n\tv29 = v25 == 0;\n\tv30 = ~v29;\n\tif (v30) goto L_FFFFFFFF;\n\tv45 = v5 + 0x80;\n\tv38 = v45 < 0;\n\tthis.<ShortValue>k__BackingField = v5;\n\tthis.<MinInteger>k__BackingField = 5;\n\tv104 = v38 == 0;\n\tv32 = ~v104;\n\tif (v32) goto L_FFFFFFFF;\n\tthis.<SByteValue>k__BackingField = v5;\n\tthis.<MinInteger>k__BackingField = 7;\n\tgoto L_0075;\nL_0031:\n\tthis.<ULongValue>k__BackingField = integerPart;\n\tthis.<MinInteger>k__BackingField = 0;\n\tv20 = integerPart & 0x8000000000000000;\n\tv21 = v20 == 0;\n\tv22 = ~v21;\n\tif (v22) goto L_FFFFFFFF;\n\tv48 = integerPart >> 0x20;\n\tthis.<LongValue>k__BackingField = integerPart;\n\tthis.<MinInteger>k__BackingField = 1;\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_FFFFFFFF;\n\tv90 = integerPart >> 0x1F;\n\tthis.<UIntValue>k__BackingField = integerPart;\n\tthis.<MinInteger>k__BackingField = 2;\n\tv122 = v90 == 0;\n\tv94 = ~v122;\n\tif (v94) goto L_FFFFFFFF;\n\tv91 = integerPart >> 0x10;\n\tthis.<IntValue>k__BackingField = integerPart;\n\tthis.<MinInteger>k__BackingField = 3;\n\tv123 = v91 == 0;\n\tv95 = ~v123;\n\tif (v95) goto L_FFFFFFFF;\n\tv88 = integerPart >> 0xF;\n\tthis.<UShortValue>k__BackingField = integerPart;\n\tthis.<MinInteger>k__BackingField = 4;\n\tv124 = v88 == 0;\n\tv93 = ~v124;\n\tif (v93) goto L_FFFFFFFF;\n\tv125 = integerPart < 0xFF;\n\tv86 = ~v125;\n\tv82 = integerPart - 0xFF;\n\tv74 = v82 == 0;\n\tthis.<ShortValue>k__BackingField = integerPart;\n\tthis.<MinInteger>k__BackingField = 5;\n\tv126 = ~v74;\n\tv54 = v86 & v126;\n\tif (v54) goto L_FFFFFFFF;\n\tv127 = integerPart < 0x7F;\n\tv84 = ~v127;\n\tv80 = integerPart - 0x7F;\n\tv72 = v80 == 0;\n\tthis.<ByteValue>k__BackingField = integerPart;\n\tthis.<MinInteger>k__BackingField = 6;\n\tv128 = ~v72;\n\tv52 = v84 & v128;\n\tif (v52) goto L_FFFFFFFF;\n\tthis.<SByteValue>k__BackingField = integerPart;\n\tthis.<MinInteger>k__BackingField = 7;\nL_0075:\n\tthis.<DoubleValue>k__BackingField = v105;\n\tthis.<FloatValue>k__BackingField = v105;\n\tthis.<MinFloat>k__BackingField = 1;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void MakeInteger(bool isNegative, ulong integerPart)
		{
			//IL_008e: Expected I4, but got I8
			//IL_01f0: Expected I4, but got I8
			//IL_00e8: Expected I4, but got I8
			//IL_023b: Expected I4, but got I8
			//IL_0125: Expected I4, but got I8
			//IL_0286: Expected I4, but got I8
			//IL_02fa: Expected I4, but got I8
			//IL_036c: Expected I4, but got I8
			//IL_03a7: Expected I4, but got I8
			IsNegative = isNegative;
			double num4;
			if (isNegative)
			{
				long num = (LongValue = (long)(0 - integerPart));
				MinInteger = IntegerSize.Int64;
				if (num >= int.MinValue)
				{
					long num2 = num + 32768;
					bool flag = num2 < 0;
					IntValue = (int)num;
					MinInteger = IntegerSize.Int32;
					if (!flag)
					{
						long num3 = num + 128;
						bool flag2 = num3 < 0;
						ShortValue = (short)num;
						MinInteger = IntegerSize.Int16;
						if (!flag2)
						{
							SByteValue = (sbyte)num;
							MinInteger = IntegerSize.Int8;
						}
					}
				}
				num4 = num;
			}
			else
			{
				ULongValue = integerPart;
				MinInteger = default(IntegerSize);
				long num5 = (long)integerPart & long.MinValue;
				if (num5 == 0)
				{
					long num6 = (long)integerPart >> 32;
					LongValue = (long)integerPart;
					MinInteger = IntegerSize.Int64;
					if (num6 == 0)
					{
						long num7 = (long)integerPart >> 31;
						UIntValue = (uint)integerPart;
						MinInteger = IntegerSize.UInt32;
						if (num7 == 0)
						{
							long num8 = (long)integerPart >> 16;
							IntValue = (int)integerPart;
							MinInteger = IntegerSize.Int32;
							if (num8 == 0)
							{
								long num9 = (long)integerPart >> 15;
								UShortValue = (ushort)integerPart;
								MinInteger = IntegerSize.UInt16;
								if (num9 == 0)
								{
									bool flag3 = (long)integerPart < 255L;
									bool flag4 = !flag3;
									long num10 = (long)(integerPart - 255);
									bool flag5 = num10 == 0;
									ShortValue = (short)integerPart;
									MinInteger = IntegerSize.Int16;
									bool flag6 = !flag5;
									if (!(flag4 && flag6))
									{
										bool flag7 = (long)integerPart < 127L;
										bool flag8 = !flag7;
										long num11 = (long)(integerPart - 127);
										bool flag9 = num11 == 0;
										ByteValue = (byte)integerPart;
										MinInteger = IntegerSize.UInt8;
										bool flag10 = !flag9;
										if (!(flag8 && flag10))
										{
											SByteValue = (sbyte)integerPart;
											MinInteger = IntegerSize.Int8;
										}
									}
								}
							}
						}
					}
				}
				num4 = (long)integerPart;
			}
			DoubleValue = num4;
			FloatValue = (float)num4;
			MinFloat = FloatSize.Single;
		}

		[Token(Token = "0x600010D")]
		[Address(RVA = "0x15BC4A4", Offset = "0x15BC4A4", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv46 = *([1EBA908]);\n\tv47 = *([v46 @ X8_v17]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, isNegative, negativeExponent, integerPart, fractionalPart, fractionalPartLength, exponent, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv60 = 0 | 1;\n\t*([202992F]) = v60;\nL_0025:\n\tv65 = isNegative == 0;\n\tv71 = ~v65;\n\tv72 = ~v71;\n\tif (v72) goto L_FFFFFFFF;\n\tgoto L_0035;\nL_0035:\n\tgoto L_003D;\n\tv79 = *([v70 @ X0_v2 (Il2CppClass<System.Math>)+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tgoto L_003D;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v70, isNegative, negativeExponent, integerPart, fractionalPart, fractionalPartLength, exponent, methodInfo, v68, v69, v52, v53, v54, v55, v56, v57);\nL_003D:\n\tv88 = 0x6D2390(System.Math, isNegative, negativeExponent, integerPart, fractionalPart, fractionalPartLength, exponent, methodInfo, 8.000000000465661d, fractionalPartLength, v52, v53, v54, v55, v56, v57);\n\tv92 = negativeExponent == 0;\n\tv98 = ~v92;\n\tif (v98) goto L_FFFFFFFF;\n\tgoto L_004F;\nL_004F:\n\tgoto L_0055;\n\tv104 = *([v89 @ X0_v5 (Il2CppClass<System.Math>)+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tgoto L_0055;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v89, isNegative, negativeExponent, integerPart, fractionalPart, fractionalPartLength, exponent, methodInfo, v87, v86, v52, v53, v54, v55, v56, v57);\nL_0055:\n\tv111 = v101 * exponent;\n\tv114 = 0x6D2390(System.Math, isNegative, negativeExponent, integerPart, fractionalPart, fractionalPartLength, exponent, methodInfo, 8.000000000465661d, v111, v52, v53, v54, v55, v56, v57);\n\tv118 = fractionalPart / 8.000000000465661d;\n\tv119 = v118 + integerPart;\n\tv120 = v75 * v119;\n\tv121 = v120 * 8.000000000465661d;\n\tthis.<MinFloat>k__BackingField = 0;\n\tthis.<DoubleValue>k__BackingField = v121;\n\tthis.<IsFractional>k__BackingField = 1;\n\tv132 = v121 >= 0;\n\tif (v132) goto L_0081;\n\tthis.<IsNegative>k__BackingField = 1;\n\tv146 = v121 >= -3.4028234663852886E+38d;\n\tif (v146) goto L_008F;\n\tgoto L_009E;\nL_0081:\n\tv149 = v121 < 3.4028234663852886E+38d;\n\tv150 = ~v149;\n\tv151 = v121 - 3.4028234663852886E+38d;\n\tv153 = v151 == 0;\n\tv158 = ~v153;\n\tv159 = v150 & v158;\n\tif (v159) goto L_009E;\nL_008F:\n\tthis.<FloatValue>k__BackingField = v121;\n\tthis.<MinFloat>k__BackingField = 1;\nL_009E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void MakeFloat(bool isNegative, bool negativeExponent, ulong integerPart, ulong fractionalPart, int fractionalPartLength, ulong exponent)
		{
			//IL_0077: Expected O, but got I4
			//IL_0069: Expected O, but got I4
			//IL_008a: Expected O, but got I8
			double num = ((!isNegative) ? 1.0 : (-1.0));
			Il2CppRuntime.Boundary("SYSTEM_API:pow", "Method not found @6D2390 (native pow)");
			object obj = (negativeExponent ? ((object)(-1)) : ((object)1));
			object obj2 = (long)(IntPtr)obj * (long)exponent;
			Il2CppRuntime.Boundary("SYSTEM_API:pow", "Method not found @6D2390 (native pow)");
			double num2 = (double)(long)fractionalPart / 8.000000000465661;
			double num3 = num2 + (double)(long)integerPart;
			double num4 = num * num3;
			double num5 = num4 * 8.000000000465661;
			MinFloat = default(FloatSize);
			DoubleValue = num5;
			IsFractional = true;
			if (num5 < 0.0)
			{
				IsNegative = true;
				if (num5 < -3.4028234663852886E+38)
				{
					return;
				}
			}
			else
			{
				bool flag = num5 < 3.4028234663852886E+38;
				bool flag2 = !flag;
				double num6 = num5 - 3.4028234663852886E+38;
				bool flag3 = num6 == 0.0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					return;
				}
			}
			FloatValue = (float)num5;
			MinFloat = FloatSize.Single;
		}

		[Token(Token = "0x600010E")]
		[Address(RVA = "0x15BC604", Offset = "0x15BC604", Length = "0x340")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1EBCB58]);\n\tv29 = *([v28 @ X8_v15]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, obj, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2029930]) = v47;\nL_001D:\n\tv53 = v45 == obj;\n\tif (v53) goto L_FFFFFFFF;\n\tv61 = obj == 0;\n\tif (v61) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv113 = v113_asT == 0;\n\tif (v113) goto L_FFFFFFFF;\n\tv95 = *([obj @ X1 (System.Object)+10]);\n\tv114 = *([obj @ X1 (System.Object)+10]) != v45.<Kind>k__BackingField;\n\tif (v114) goto L_FFFFFFFF;\n\tv200 = *([obj @ X1 (System.Object)+10]) < 4;\n\tv83 = ~v200;\n\tv81 = *([obj @ X1 (System.Object)+10]) - 4;\n\tv77 = v81 == 0;\n\tv201 = ~v77;\n\tv66 = v83 & v201;\n\tif (v66) goto L_FFFFFFFF;\n\tv190 = 0x183B000 + 0xD00;\n\tv196 = *([v190 @ X9_v10 (System.Int32)+v95 @ X8_v9 (System.Int32)*4]) + v190;\n\t// 102 IndirectJump v196 @ X8_v12, v45 @ X0_v1 (YMMJSONUtils.JObject), v45 @ X0_v1 (YMMJSONUtils.JObject), obj @ X1 (System.Object), methodInfo @ X2 (Il2CppMethodInfo), v32 @ X3, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, 0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tX0 = *([X20+18]);\n\tif (TEMP) goto L_0148;\n\tX22 = *([1EA70A0]);\n\tX1 = *([X22]);\n\tX0 = System.Collections.Generic.Dictionary`2::get_Count /* +17 sharing this address */(X0, X1);\n\tX8 = *([X19+18]);\n\tX21 = X0;\n\tif (TEMP) goto L_0147;\n\tX1 = *([X22]);\n\tX0 = X8;\n\tX0 = System.Collections.Generic.Dictionary`2::get_Count /* +17 sharing this address */(X0, X1);\n\tC = X21 < X0;\n\tC = ~C;\n\tTEMP1 = X21 - X0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X21 ^ X0;\n\tTEMP3 = X21 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_FFFFFFFF;\n\tX0 = *([X20+18]);\n\tif (TEMP) goto L_0148;\n\tX8 = *([1EF1C38]);\n\tX1 = *([X8]);\n\tX8 = &stack[8];\n\tX0 = System.Collections.Generic.Dictionary`2<EasyMobile.AdPlacement, EasyMobile.AdId>::GetEnumerator /* +10 sharing this address */(X0, X1);\n\tX22 = *([1ECC0E8]);\n\tX23 = *([1EAE1F8]);\n\tX24 = *([1EBBF98]);\nL_008E:\n\tX1 = *([X22]);\n\tX0 = &stack[8];\n\tX0 = 0xDE960C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0140;\n\tX0 = *([X19+18]);\n\tif (TEMP) goto L_0149;\n\tX21 = stack[18];\n\tX20 = stack[20];\n\tX2 = *([X23]);\n\tX1 = X21;\n\tX0 = System.Collections.Generic.Dictionary`2::ContainsKey /* +29 sharing this address */(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00B1;\n\tX0 = *([X19+18]);\n\tif (TEMP) goto L_014A;\n\tX2 = *([X24]);\n\tX1 = X21;\n\tX0 = System.Collections.Generic.Dictionary`2<System.String, BaseTenjin>::get_Item /* +19 sharing this address */(X0, X1, X2);\n\tX1 = X0;\n\tif (TEMP) goto L_014B;\n\tX8 = *([X20]);\n\tX9 = *([X8+130]);\n\tX2 = *([X8+138]);\n\tX0 = X20;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_008E;\nL_00B1:\n\tX21 = 0;\n\tgoto L_0141;\n\tX8 = *([X20+30]);\n\tX9 = *([X19+30]);\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\tC = X9 < 0;\n\tC = ~C;\n\tTEMP1 = X9 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 0;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX9 = TEMPCOND;\n\tX8 = X8 ^ X9;\n\tX21 = X8 ^ 1;\n\tgoto L_016A;\n\tX0 = *([X20+28]);\n\tX1 = *([X19+28]);\n\tX2 = 0;\n\tX0 = System.String::op_Equality(X0, X1, X2);\n\tgoto L_00D6;\n\tX0 = X20;\n\tX1 = X19;\n\tX0 = YMMJSONUtils.JObject::EqualNumber(X0, X1, X2);\nL_00D6:\n\tX21 = X0;\n\tgoto L_016A;\n\tX23 = *([X20+20]);\n\tif (TEMP) goto L_0147;\n\tX9 = *([X19+20]);\n\tif (TEMP) goto L_0147;\n\tX8 = *([X23+18]);\n\tX9 = *([X9+18]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_FFFFFFFF;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_FFFFFFFF;\n\tX22 = 0;\nL_00F8:\n\tC = X8 < X22;\n\tC = ~C;\n\tTEMP1 = X8 - X22;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X22;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_0106;\n\tX0 = 0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException(X0);\nL_0106:\n\tX24 = *([X19+20]);\n\tif (TEMP) goto L_0147;\n\tX8 = *([X23+10]);\n\tX9 = *([X24+18]);\n\tTEMPSHIFT = X22 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX21 = *([X8+20]);\n\tC = X9 < X22;\n\tC = ~C;\n\tTEMP1 = X9 - X22;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X22;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_011C;\n\tX0 = 0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException(X0);\nL_011C:\n\tTEMP = X21 == 0;\n\tif (TEMP) goto L_0147;\n\tX8 = *([X24+10]);\n\tX9 = *([X21]);\n\tX10 = X22;\n\tX0 = X21;\n\tTEMPSHIFT = X10 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX1 = *([X8+20]);\n\tX8 = *([X9+130]);\n\tX2 = *([X9+138]);\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX23 = *([X20+20]);\n\tif (TEMP) goto L_0147;\n\tX8 = *([X23+18]);\n\tX22 = X22 + 1;\n\tX21 = 0 | 1;\n\tC = X22 < X8;\n\tC = ~C;\n\tTEMP1 = X22 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X8;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_00F8;\n\tgoto L_016A;\n\tgoto L_016A;\nL_0140:\n\tX21 = 0 | 1;\nL_0141:\n\tX8 = 0x1ED9000;\n\tX8 = *([1ED9E40]);\n\tX0 = &stack[8];\n\tX1 = *([X8]);\n\tX0 = 0xDE9790(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_016A;\nL_0147:\n\tX0 = 0;\nL_0148:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0149:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_014A:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_014B:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0153;\n\tgoto L_0153;\n\tgoto L_0153;\n\tgoto L_0153;\n\tgoto L_0153;\n\tgoto L_0153;\nL_0153:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0175;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1ED9E40]);\n\tX0 = &stack[8];\n\tX1 = *([X8]);\n\tX0 = 0xDE9790(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0176;\nL_016A:\n\treturnVal1 = v160 & 1;\n\treturn returnVal1;\nL_0175:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0176:\n\tX0 = X19;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool Equals(object obj)
		{
			//IL_011b: Expected O, but got I
			if (this == obj)
			{
				goto IL_0133;
			}
			if (obj != null)
			{
				JObject jObject = obj as JObject;
				if (jObject != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+10]");
					int num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+10]");
					if ((IntPtr)(void*)null == (IntPtr)(void*)(int)Kind)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+10]");
						bool flag = 0L < 4L;
						bool flag2 = !flag;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+10]");
						int num2 = (int)(-4);
						bool flag3 = num2 == 0;
						bool flag4 = !flag3;
						if (flag2 && flag4)
						{
							goto IL_0133;
						}
						int num3 = 25407488 + 3328;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X9_v10 (System.Int32)+v95 @ X8_v9 (System.Int32)*4]");
						object obj2 = 0L + (long)num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v196 @ X8_v12 (should have been resolved before IL gen)");
					}
				}
			}
			int num4 = 0;
			goto IL_015a;
			IL_015a:
			return (byte)(num4 & 1) != 0;
			IL_0133:
			num4 = 1;
			goto IL_015a;
		}

		[Token(Token = "0x600010F")]
		[Address(RVA = "0x15BCA04", Offset = "0x15BCA04", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\t*([v4 @ X29_v1-4]) = 0;\n\tv9 = this.<Kind>k__BackingField;\n\tv11 = this.<Kind>k__BackingField < 4;\n\tv12 = ~v11;\n\tv13 = this.<Kind>k__BackingField - 4;\n\tv15 = v13 == 0;\n\tv20 = ~v15;\n\tv21 = v12 & v20;\n\tif (v21) goto L_0023;\n\tv23 = 0x183B000 + 0xD14;\n\tv25 = *([v23 @ X9_v2 (System.Int32)+v9 @ X8_v1 (YMMJSONUtils.JObjectKind)*4]) + v23;\n\t// 25 IndirectJump v25 @ X8_v3, this @ X0 (YMMJSONUtils.JObject), this @ X0 (YMMJSONUtils.JObject), methodInfo @ X1 (Il2CppMethodInfo), v27 @ X2, v28 @ X3, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tX0 = *([X0+18]);\n\tif (TEMP) goto L_0028;\nL_001D:\n\tX8 = *([X0]);\n\tX9 = *([X8+150]);\n\tX1 = *([X8+158]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_003F;\nL_0023:\n\tgoto L_003F;\n\tX0 = *([X0+20]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_001D;\nL_0028:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X0+28]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_001D;\n\tgoto L_0028;\n\tX8 = *([X0+67]);\n\tif (TEMP) goto L_0040;\n\tX8 = *([X0+38]);\n\tX0 = &stack[10];\n\tX1 = 0;\n\tstack[10] = X8;\n\tX0 = 0xA662F0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_003F;\n\tX8 = *([X0+30]);\n\tX0 = X29 - 4;\n\tX1 = 0;\n\t*([X29-4]) = X8;\n\tX0 = 0xE8F13C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_003F:\n\treturn 0;\nL_0040:\n\tX8 = *([X0+66]);\n\tif (TEMP) goto L_0049;\n\tX8 = *([X0+50]);\n\tX0 = &stack[8];\n\tX1 = 0;\n\tstack[8] = X8;\n\tX0 = 0xDC4018(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_003F;\nL_0049:\n\tX8 = *([X0+48]);\n\tX0 = &stack[0];\n\tX1 = 0;\n\tstack[0] = X8;\n\tX0 = 0x13CC984(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_003F;\n\treturn X0;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			//IL_009d: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			JObjectKind kind = Kind;
			bool flag = Kind < JObjectKind.Boolean;
			bool flag2 = !flag;
			int num = (int)(Kind - 4);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25407488 + 3348;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X9_v2 (System.Int32)+v9 @ X8_v1 (YMMJSONUtils.JObjectKind)*4]");
				object obj3 = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v25 @ X8_v3 (should have been resolved before IL gen)");
			}
			return 0;
		}

		[Token(Token = "0x6000110")]
		[Address(RVA = "0x15BC944", Offset = "0x15BC944", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv36 = o1.<MinFloat>k__BackingField != o2.<MinFloat>k__BackingField;\n\tif (v36) goto L_FFFFFFFF;\n\tv52 = o1.<MinInteger>k__BackingField != o2.<MinInteger>k__BackingField;\n\tif (v52) goto L_FFFFFFFF;\n\tv101 = o1.<IsNegative>k__BackingField == 0;\n\tv106 = ~v101;\n\tv77 = o2.<IsNegative>k__BackingField == 0;\n\tv62 = ~v77;\n\tv89 = v106 ^ v62;\n\tv110 = v89 == 0;\n\tv94 = ~v110;\n\tif (v94) goto L_FFFFFFFF;\n\tv179 = o1.<IsFractional>k__BackingField == 0;\n\tv184 = ~v179;\n\tv76 = o2.<IsFractional>k__BackingField == 0;\n\tv61 = ~v76;\n\tv57 = v184 ^ v61;\n\tv93 = v57 == 0;\n\tif (v93) goto L_0060;\nL_005F:\n\treturn returnVal2;\nL_0060:\n\tv188 = ~o1.<IsFractional>k__BackingField;\n\tif (v188) goto L_006E;\n\tv193 = o1.<DoubleValue>k__BackingField - o2.<DoubleValue>k__BackingField;\n\tv129 = v193 == 0;\n\tgoto L_FFFFFFFF;\nL_006E:\n\tv200 = ~o1.<IsNegative>k__BackingField;\n\tif (v200) goto L_FFFFFFFF;\n\tgoto L_0077;\nL_0077:\n\tv207 = v210 - v209;\n\tv129 = v207 == 0;\n\tgoto L_005F;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool EqualNumber(JObject o1, JObject o2)
		{
			//IL_01d6: Expected I4, but got I8
			//IL_01e3: Expected I4, but got I8
			//IL_01b7: Expected I4, but got I8
			//IL_01c4: Expected I4, but got I8
			if (o1.MinFloat == o2.MinFloat && o1.MinInteger == o2.MinInteger)
			{
				bool flag = !o1.IsNegative;
				bool flag2 = !flag;
				bool flag3 = !o2.IsNegative;
				bool flag4 = !flag3;
				if (!(flag2 ^ flag4))
				{
					bool flag5 = !o1.IsFractional;
					bool flag6 = !flag5;
					bool flag7 = !o2.IsFractional;
					bool flag8 = !flag7;
					if (!(flag6 ^ flag8))
					{
						bool result;
						if (o1.IsFractional)
						{
							double num = o1.DoubleValue - o2.DoubleValue;
							result = num == 0.0;
						}
						else
						{
							int num2;
							int num3;
							if (o1.IsNegative)
							{
								num2 = (int)o2.LongValue;
								num3 = (int)o1.LongValue;
							}
							else
							{
								num2 = (int)o2.ULongValue;
								num3 = (int)o1.ULongValue;
							}
							int num4 = num3 - num2;
							result = num4 == 0;
						}
						return result;
					}
				}
			}
			return false;
		}
	}
}
