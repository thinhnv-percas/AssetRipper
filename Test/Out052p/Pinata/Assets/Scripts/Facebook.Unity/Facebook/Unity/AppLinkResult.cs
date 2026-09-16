using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x2000023")]
	internal class AppLinkResult : ResultBase, IAppLinkResult, IResult
	{
		[CompilerGenerated]
		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x48")]
		private string _003CUrl_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x50")]
		private string _003CTargetUrl_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x58")]
		private string _003CRef_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x60")]
		private IDictionary<string, object> _003CExtras_003Ek__BackingField;

		[Token(Token = "0x17000035")]
		public string Url
		{
			[CompilerGenerated]
			[Token(Token = "0x60000E7")]
			[Address(RVA = "0xD1C1A4", Offset = "0xD1C1A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Url>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Url;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000E8")]
			[Address(RVA = "0xD1C1AC", Offset = "0xD1C1AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Url>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CUrl_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000036")]
		public string TargetUrl
		{
			[CompilerGenerated]
			[Token(Token = "0x60000E9")]
			[Address(RVA = "0xD1C1B4", Offset = "0xD1C1B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TargetUrl>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TargetUrl;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000EA")]
			[Address(RVA = "0xD1C1BC", Offset = "0xD1C1BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TargetUrl>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTargetUrl_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000037")]
		public string Ref
		{
			[CompilerGenerated]
			[Token(Token = "0x60000EB")]
			[Address(RVA = "0xD1C1C4", Offset = "0xD1C1C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Ref>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Ref;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000EC")]
			[Address(RVA = "0xD1C1CC", Offset = "0xD1C1CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Ref>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CRef_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000038")]
		public IDictionary<string, object> Extras
		{
			[CompilerGenerated]
			[Token(Token = "0x60000ED")]
			[Address(RVA = "0xD1C1D4", Offset = "0xD1C1D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Extras>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Extras;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000EE")]
			[Address(RVA = "0xD1C1DC", Offset = "0xD1C1DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Extras>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CExtras_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0xD1C044", Offset = "0xD1C044", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-10_v2;\n\tgoto L_0017;\n\tv22 = *([1EBFEF8]);\n\tv23 = *([v22 @ X8_v25]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B56]) = v41;\nL_0017:\n\t*([v10 @ X29_v1-18]) = 0;\n\tFacebook.Unity.ResultBase::.ctor(this, resultContainer);\n\tv51 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv52 = v51 == 0;\n\tif (v52) goto L_006D;\n\tv57 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv62 = &v11 @ stack_-10_v2 - 0x18;\n\tv65 = Facebook.Unity.Utilities::TryGetValue(v57, \"url\", v62);\n\tv94 = v65 == 0;\n\tif (v94) goto L_0039;\n\tthis.<Url>k__BackingField = *([v10 @ X29_v1-18]);\nL_0039:\n\tv101 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv107 = Facebook.Unity.Utilities::TryGetValue(v101, \"target_url\", &v69 @ stack_-38_v3 (System.String));\n\tv109 = v107 == 0;\n\tif (v109) goto L_0049;\n\tthis.<TargetUrl>k__BackingField = v69;\nL_0049:\n\tv116 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv122 = Facebook.Unity.Utilities::TryGetValue(v116, \"ref\", &v71 @ stack_-40_v3 (System.String));\n\tv124 = v122 == 0;\n\tif (v124) goto L_0059;\n\tthis.<Ref>k__BackingField = v71;\nL_0059:\n\tv131 = Facebook.Unity.ResultBase::get_ResultDictionary(this);\n\tv81 = Facebook.Unity.Utilities::TryGetValue(v131, \"extras\", &v67 @ stack_-48_v3 (System.Collections.Generic.IDictionary`2<System.String, System.Object>));\n\tv83 = v81 == 0;\n\tif (v83) goto L_006D;\n\tthis.<Extras>k__BackingField = v67;\nL_006D:\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe AppLinkResult(ResultContainer resultContainer)
		{
			//IL_006b: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			base._002Ector(resultContainer);
			IDictionary<string, object> resultDictionary = base.ResultDictionary;
			if (resultDictionary != null)
			{
				if (base.ResultDictionary.TryGetValue<string>("url", out *(string*)((long)(IntPtr)obj2 - 24L)))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-18]");
					Url = (string)0;
				}
				IDictionary<string, object> resultDictionary2 = base.ResultDictionary;
				if (resultDictionary2.TryGetValue<string>("target_url", out var value))
				{
					TargetUrl = value;
				}
				IDictionary<string, object> resultDictionary3 = base.ResultDictionary;
				if (resultDictionary3.TryGetValue<string>("ref", out var value2))
				{
					Ref = value2;
				}
				IDictionary<string, object> resultDictionary4 = base.ResultDictionary;
				if (resultDictionary4.TryGetValue<IDictionary<string, object>>("extras", out var value3))
				{
					Extras = value3;
				}
			}
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0xD1C1E4", Offset = "0xD1C1E4", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F01588]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023B57]) = v44;\nL_0017:\n\tv46 = Facebook.Unity.ResultBase::ToString(this);\n\tv50 = System.Object::GetType(this);\n\tv55 = System.Reflection.MemberInfo::get_Name(v50);\n\tv61 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v61);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v61, \"Url\", this.<Url>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v61, \"TargetUrl\", this.<TargetUrl>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v61, \"Ref\", this.<Ref>k__BackingField);\n\tv125 = Facebook.Unity.Utilities::ToJson(this.<Extras>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v61, \"Extras\", v125);\n\treturnVal2 = Facebook.Unity.Utilities::FormatToString(v46, v55, v61);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			string baseString = base.ToString();
			Type type = GetType();
			string name = type.Name;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("Url", Url);
			dictionary.Add("TargetUrl", TargetUrl);
			dictionary.Add("Ref", Ref);
			string value = Extras.ToJson();
			dictionary.Add("Extras", value);
			return Utilities.FormatToString(baseString, name, dictionary);
		}
	}
}
