using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000062")]
	public class FsmTexture : FsmObject
	{
		[Token(Token = "0x17000091")]
		public override Type ObjectType
		{
			[Token(Token = "0x600024C")]
			[Address(RVA = "0xCB6968", Offset = "0xCB6968", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EBBD48]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023665]) = v35;\nL_001A:\n\tgoto L_0026;\n\tv45 = *([v38 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0026:\n\treturnVal1 = System.Type::GetTypeFromHandle(UnityEngine.Texture);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return typeof(Texture);
			}
		}

		[Token(Token = "0x17000092")]
		public new Texture Value
		{
			[Token(Token = "0x600024D")]
			[Address(RVA = "0xCB1EB8", Offset = "0xCB1EB8", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EA9E20]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023666]) = v38;\nL_0014:\n\tv40 = HutongGames.PlayMaker.FsmObject::get_Value(this);\n\tv41 = v40 == 0;\n\tif (v41) goto L_0041;\n\tgoto L_FFFFFFFF;\n\tgoto L_0041;\n\tv59 = v59_asT == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_0041;\nL_0041:\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				UnityEngine.Object obj = base.Value;
				bool flag = (object)obj == null;
				Texture result = (Texture)obj;
				if (!flag)
				{
					Texture texture = obj as Texture;
					result = (Texture)(((object)texture == null) ? null : obj);
				}
				return result;
			}
			[Token(Token = "0x600024E")]
			[Address(RVA = "0xCB2B20", Offset = "0xCB2B20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = value;\n\treturn;\n")]
			set
			{
				((FsmObject)this).Value = value;
			}
		}

		[Token(Token = "0x17000093")]
		public override VariableType VariableType
		{
			[Token(Token = "0x6000253")]
			[Address(RVA = "0xCB6A3C", Offset = "0xCB6A3C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0xA;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return VariableType.Texture;
			}
		}

		[Token(Token = "0x600024F")]
		[Address(RVA = "0xCB2B80", Offset = "0xCB2B80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmTexture()
		{
		}

		[Token(Token = "0x6000250")]
		[Address(RVA = "0xCB69D8", Offset = "0xCB69D8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmObject::.ctor(this, name);\n\treturn;\n")]
		public FsmTexture(string name)
			: base(name)
		{
		}

		[Token(Token = "0x6000251")]
		[Address(RVA = "0xCB01EC", Offset = "0xCB01EC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmObject::.ctor(this, source);\n\treturn;\n")]
		public FsmTexture(FsmObject source)
			: base(source)
		{
		}

		[Token(Token = "0x6000252")]
		[Address(RVA = "0xCB69DC", Offset = "0xCB69DC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA61C8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023667]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmTexture();\n\tHutongGames.PlayMaker.FsmObject::.ctor(v42, this);\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override NamedVariable Clone()
		{
			return new FsmObject(this);
		}

		[Token(Token = "0x6000254")]
		[Address(RVA = "0xCB6A44", Offset = "0xCB6A44", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = variableType + 1;\n\tv3 = v0 == 0;\n\tv9 = variableType - 0xA;\n\tv11 = v9 == 0;\n\treturnVal1 = v3 | v11;\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool TestTypeConstraint(VariableType variableType, Type _objectType = null)
		{
			int num = (int)(variableType + 1);
			bool flag = num == 0;
			int num2 = (int)(variableType - 10);
			bool flag2 = num2 == 0;
			return flag || flag2;
		}
	}
}
