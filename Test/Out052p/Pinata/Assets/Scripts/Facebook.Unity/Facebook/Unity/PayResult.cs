using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x2000032")]
	internal class PayResult : ResultBase, IPayResult, IResult
	{
		[Token(Token = "0x17000044")]
		public long ErrorCode
		{
			[Token(Token = "0x6000107")]
			[Address(RVA = "0xD33EA8", Offset = "0xD33EA8", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE8B58]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C92]) = v38;\nL_0019:\n\treturn this.<CanvasErrorCode>k__BackingField;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000c: Expected I8, but got O
				return (long)CanvasErrorCode;
			}
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0xD20708", Offset = "0xD20708", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EDCEA0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C91]) = v41;\nL_0017:\n\tFacebook.Unity.ResultBase::.ctor(this, resultContainer);\n\tv44 = this.<CanvasErrorCode>k__BackingField;\n\tv46 = *([this @ X0 (Facebook.Unity.PayResult)+40]) & 0xFF;\n\tv49 = v46 == 0;\n\tif (v49) goto L_003F;\n\tv56 = 0x115C6B0(&v44 @ X8_v3 (System.Nullable`1<System.Int64>), Il2CppMethodInfo, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv60 = v56 != 0x151A62;\n\tif (v60) goto L_003F;\n\tv94 = Facebook.Unity.ResultBase::set_Cancelled(this, 1);\nL_003F:\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal PayResult(ResultContainer resultContainer)
			: base(resultContainer)
		{
			long? num = CanvasErrorCode;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Facebook.Unity.PayResult)+40]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115C6B0 (inside System.Nullable`1<System.Int32Enum>::Unbox +0xC0)");
				int num2 = default(int);
				if (num2 == 1383010)
				{
					base.Cancelled = true;
				}
			}
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0xD33EEC", Offset = "0xD33EEC", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EB7490]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C93]) = v44;\nL_0018:\n\tv47 = Facebook.Unity.ResultBase::ToString(this);\n\tv51 = System.Object::GetType(this);\n\tv56 = System.Reflection.MemberInfo::get_Name(v51);\n\tv62 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v62);\n\tgoto L_003A;\n\tv93 = *([1EE8B58]);\n\tv94 = *([v93 @ X8_v16]);\n\tv95 = \"il2cpp_codegen_initialize_method\"(v94, v67, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv98 = 0 | 1;\n\t*([2023C92]) = v98;\nL_003A:\n\tv85 = this.<CanvasErrorCode>k__BackingField;\n\tv81 = 0xDC4024(&v85 @ X8_v12 (System.Nullable`1<System.Int64>), 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v62, \"ErrorCode\", v81);\n\treturnVal2 = Facebook.Unity.Utilities::FormatToString(v47, v56, v62);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			string baseString = base.ToString();
			Type type = GetType();
			string name = type.Name;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			long? num = CanvasErrorCode;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC4024 (inside System.Int32::TryParse +0x8C8)");
			string value = default(string);
			dictionary.Add("ErrorCode", value);
			return Utilities.FormatToString(baseString, name, dictionary);
		}
	}
}
