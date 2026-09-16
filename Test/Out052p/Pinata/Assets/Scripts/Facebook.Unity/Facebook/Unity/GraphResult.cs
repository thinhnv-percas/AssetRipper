using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Facebook.MiniJSON;
using UnityEngine;

namespace Facebook.Unity
{
	[Token(Token = "0x2000025")]
	internal class GraphResult : ResultBase, IGraphResult, IResult
	{
		[CompilerGenerated]
		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x48")]
		private IList<object> _003CResultList_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x50")]
		private Texture2D _003CTexture_003Ek__BackingField;

		[Token(Token = "0x1700003B")]
		private IList<object> ResultList
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F7")]
			[Address(RVA = "0xD304D4", Offset = "0xD304D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ResultList>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003CResultList_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700003C")]
		public Texture2D Texture
		{
			[CompilerGenerated]
			[Token(Token = "0x60000F8")]
			[Address(RVA = "0xD304DC", Offset = "0xD304DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Texture>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Texture;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000F9")]
			[Address(RVA = "0xD304E4", Offset = "0xD304E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Texture>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTexture_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0xD1D584", Offset = "0xD1D584", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EDA018]);\n\tv25 = *([v24 @ X8_v9]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, result, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023C4B]) = v43;\nL_001A:\n\tv47 = UnityEngine.WWW::get_text(result);\n\tv55 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v55, v47);\n\tv89 = UnityEngine.WWW::get_error(result);\n\tSystem.Object::.ctor(this);\n\tFacebook.Unity.ResultBase::Init(this, v55, v89, 0, 0);\n\tv97 = Facebook.Unity.ResultBase::get_RawResult(this);\n\tFacebook.Unity.GraphResult::Init(this, v97);\n\tv102 = UnityEngine.WWW::get_error(result);\n\tv103 = v102 == 0;\n\tv76 = ~v103;\n\tif (v76) goto L_004A;\n\tv106 = UnityEngine.WWW::get_texture(result);\n\tthis.<Texture>k__BackingField = v106;\nL_004A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal GraphResult(WWW result)
		{
			string text = result.text;
			ResultContainer result2 = new ResultContainer(text);
			string error = result.error;
			Init(result2, error, cancelled: false, null);
			string rawResult = base.RawResult;
			Init(rawResult);
			string error2 = result.error;
			if (error2 == null)
			{
				Texture2D texture = result.texture;
				Texture = texture;
			}
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0xD303D0", Offset = "0xD303D0", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EB8058]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, rawResult, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C4C]) = v41;\nL_0017:\n\tv44 = System.String::IsNullOrEmpty(rawResult);\n\tv46 = v44 == 0;\n\tif (v46) goto L_0022;\nL_0021:\n\treturn;\nL_0022:\n\t;\n\tv69 = Facebook.Unity.ResultBase::get_RawResult(this);\n\tgoto L_0035;\n\tv101 = *([v73 @ X8_v6+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_0035;\n\tv108 = v73;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v108, v68, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0035:\n\tv107 = v69 == 0;\n\tif (v107) goto L_003E;\n\tv110 = Facebook.MiniJSON.Json+Parser::Parse(v69);\nL_003E:\n\t// 62 IsInst v117 @ X0_v9, typeof(System.Collections.Generic.IDictionary`2<System.String, System.Object>), v57 @ X20_v3\n\tv90 = v117 == 0;\n\tif (v90) goto L_0052;\n\tv84 = this->klass;\n\tv80 = this->klass->vtable[12];\n\tv78 = this->klass->vtable[12];\n\t// 77 IndirectJump v80 @ X3_v1, this @ X0 (Facebook.Unity.GraphResult), this @ X0 (Facebook.Unity.GraphResult), v117 @ X0_v9, v78 @ X2_v1, v80 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_0052:\n\t// 82 IsInst v53 @ X0_v11 (System.Collections.Generic.IList`1<System.Object>), typeof(System.Collections.Generic.IList`1<System.Object>), v57 @ X20_v3\n\tv55 = v53 == 0;\n\tif (v55) goto L_0021;\n\tthis.<ResultList>k__BackingField = v53;\n\tgoto L_0021;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Init(string rawResult)
		{
			//IL_005a: Expected I, but got O
			//IL_006a: Expected O, but got I
			//IL_007a: Expected O, but got I
			if (!string.IsNullOrEmpty(rawResult))
			{
				string rawResult2 = base.RawResult;
				bool flag = rawResult2 == null;
				object obj = rawResult2;
				if (!flag)
				{
					object obj2 = Json.Parser.Parse(rawResult2);
					obj = obj2;
				}
				object obj3 = obj as IDictionary<string, object>;
				if (obj3 != null)
				{
					IntPtr intPtr = (IntPtr)this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X9_v4 (Il2CppClass<Facebook.Unity.GraphResult>)+1F0]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X9_v4 (Il2CppClass<Facebook.Unity.GraphResult>)+1F8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v80 @ X3_v1 (should have been resolved before IL gen)");
				}
				IList<object> list = obj as IList<object>;
				if (list != null)
				{
					_003CResultList_003Ek__BackingField = list;
				}
			}
		}
	}
}
