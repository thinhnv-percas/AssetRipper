using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x2000035")]
	internal class ShareResult : ResultBase, IShareResult, IResult
	{
		[CompilerGenerated]
		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x48")]
		private string _003CPostId_003Ek__BackingField;

		[Token(Token = "0x1700004D")]
		public string PostId
		{
			[CompilerGenerated]
			[Token(Token = "0x6000124")]
			[Address(RVA = "0xD34778", Offset = "0xD34778", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<PostId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PostId;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000125")]
			[Address(RVA = "0xD34780", Offset = "0xD34780", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<PostId>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CPostId_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700004E")]
		internal static string PostIDKey
		{
			[Token(Token = "0x6000126")]
			[Address(RVA = "0xD3471C", Offset = "0xD3471C", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = *([1EC4C60]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023C9C]) = v35;\nL_0011:\n\tv36 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv43 = v36 - 3;\n\tv45 = v43 == 0;\n\tv52 = ~v45;\n\tv53 = ~v52;\n\tif (v53) goto L_FFFFFFFF;\n\tgoto L_002B;\nL_002B:\n\treturn *([v56 @ X8_v5 (System.String)]);\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FacebookUnityPlatform currentPlatform = Constants.CurrentPlatform;
				if (currentPlatform - 3 != FacebookUnityPlatform.Unknown)
				{
					return "id";
				}
				return "post_id";
			}
		}

		[Token(Token = "0x6000123")]
		[Address(RVA = "0xD208A8", Offset = "0xD208A8", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EDA620]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C9B]) = v41;\nL_0018:\n\tFacebook.Unity.ResultBase::.ctor(this, resultContainer);\n\tv49 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv50 = v49 == 0;\n\tif (v50) goto L_0048;\n\tv55 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv57 = Facebook.Unity.ShareResult::get_PostIDKey();\n\tv96 = Facebook.Unity.Utilities::TryGetValue(v55, v57, &v93 @ stack_-28_v3 (System.String));\n\tv98 = v96 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_0041;\n\tv103 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv75 = Facebook.Unity.Utilities::TryGetValue(v103, \"postId\", &v93 @ stack_-28_v3 (System.String));\n\tv78 = v75 == 0;\n\tif (v78) goto L_0048;\nL_0041:\n\tthis.<PostId>k__BackingField = v93;\nL_0048:\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal ShareResult(ResultContainer resultContainer)
			: base(resultContainer)
		{
			IDictionary<string, object> resultDictionary = base.ResultDictionary;
			if (resultDictionary != null && (base.ResultDictionary.TryGetValue<string>(PostIDKey, out var value) || base.ResultDictionary.TryGetValue<string>("postId", out value)))
			{
				PostId = value;
			}
		}

		[Token(Token = "0x6000127")]
		[Address(RVA = "0xD34788", Offset = "0xD34788", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EDBB68]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023C9D]) = v42;\nL_0016:\n\tv44 = Facebook.Unity.ResultBase::ToString(this);\n\tv48 = System.Object::GetType(this);\n\tv53 = System.Reflection.MemberInfo::get_Name(v48);\n\tv59 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v59);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v59, \"PostId\", this.<PostId>k__BackingField);\n\treturnVal2 = Facebook.Unity.Utilities::FormatToString(v44, v53, v59);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			string baseString = base.ToString();
			Type type = GetType();
			string name = type.Name;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("PostId", PostId);
			return Utilities.FormatToString(baseString, name, dictionary);
		}
	}
}
