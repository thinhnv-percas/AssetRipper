using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73E9F0", Offset = "0x73E9F0")]
	[Token(Token = "0x200002B")]
	public sealed class ActionTarget : Attribute
	{
		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x10")]
		private readonly Type objectType;

		[Token(Token = "0x40000D9")]
		[FieldOffset(Offset = "0x18")]
		private readonly string fieldName;

		[Token(Token = "0x40000DA")]
		[FieldOffset(Offset = "0x20")]
		private readonly bool allowPrefabs;

		[Token(Token = "0x1700002F")]
		public Type ObjectType
		{
			[Token(Token = "0x60000F2")]
			[Address(RVA = "0x9D7570", Offset = "0x9D7570", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.objectType;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ObjectType;
			}
		}

		[Token(Token = "0x17000030")]
		public string FieldName
		{
			[Token(Token = "0x60000F3")]
			[Address(RVA = "0x9D7578", Offset = "0x9D7578", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fieldName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FieldName;
			}
		}

		[Token(Token = "0x17000031")]
		public bool AllowPrefabs
		{
			[Token(Token = "0x60000F4")]
			[Address(RVA = "0x9D7580", Offset = "0x9D7580", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.allowPrefabs;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AllowPrefabs;
			}
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0x9D7588", Offset = "0x9D7588", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.objectType = objectType;\n\tthis.fieldName = fieldName;\n\tthis.allowPrefabs = allowPrefabs;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ActionTarget(Type objectType, string fieldName = "", bool allowPrefabs = false)
		{
			this.objectType = objectType;
			this.fieldName = fieldName;
			this.allowPrefabs = allowPrefabs;
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x9D75CC", Offset = "0x9D75CC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = this.objectType == actionTarget.objectType;\n\tif (v9) goto L_0013;\n\treturn 0;\nL_0013:\n\treturnVal3 = System.String::op_Equality(this.fieldName, actionTarget.fieldName);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsSameAs(ActionTarget actionTarget)
		{
			if ((object)ObjectType != actionTarget.ObjectType)
			{
				return false;
			}
			return FieldName == actionTarget.FieldName;
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0x9D7608", Offset = "0x9D7608", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EA8590]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021A14]) = v40;\nL_0018:\n\tv45 = this.objectType == 0;\n\tif (v45) goto L_FFFFFFFF;\n\tv49 = System.Type::get_FullName(this.objectType);\n\tgoto L_0023;\nL_0023:\n\tv60 = this + 0x18;\n\tv63 = System.String::IsNullOrEmpty(this.fieldName);\n\tv70 = v63 == 0;\n\tv75 = ~v70;\n\tv76 = ~v75;\n\tif (v76) goto L_FFFFFFFF;\n\tgoto L_0042;\nL_0042:\n\treturnVal1 = System.String::Concat(\"ActionTarget: \", v54, \" , \", *([v79 @ X8_v8 (System.String)]));\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_0075: Expected O, but got I
			string text;
			if ((object)ObjectType != null)
			{
				string fullName = ObjectType.FullName;
				text = fullName;
			}
			else
			{
				text = "null";
			}
			string text2 = (string)((long)(IntPtr)this + 24L);
			string text3 = ((!string.IsNullOrEmpty(FieldName)) ? text2 : "none");
			return "ActionTarget: " + text + " , " + text3;
		}
	}
}
