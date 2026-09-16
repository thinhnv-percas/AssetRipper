using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Serializable]
	[Token(Token = "0x2000064")]
	public class LocalizedProductDescription
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000065")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000151")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000152")]
			public static MatchEvaluator _003C_003E9__11_0;

			[Token(Token = "0x6000176")]
			[Address(RVA = "0xC64EF0", Offset = "0xC64EF0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1F04348]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202335E]) = v37;\nL_0015:\n\tv41 = new UnityEngine.Purchasing.LocalizedProductDescription+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000177")]
			[Address(RVA = "0xC64F54", Offset = "0xC64F54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal string _003CDecodeNonLatinCharacters_003Eb__11_0(Match m)
			{
				GroupCollection groups = m.Groups;
				Group obj = groups.get_Item("Value");
				string value = obj.Value;
				int num = int.Parse(value, NumberStyles.HexNumber);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F91044 (inside System.Char::GetLatin1UnicodeCategory +0x228)");
				string result = default(string);
				return result;
			}
		}

		[Token(Token = "0x400014E")]
		[FieldOffset(Offset = "0x10")]
		public TranslationLocale googleLocale;

		[SerializeField]
		[Token(Token = "0x400014F")]
		[FieldOffset(Offset = "0x18")]
		internal string title;

		[SerializeField]
		[Token(Token = "0x4000150")]
		[FieldOffset(Offset = "0x20")]
		internal string description;

		[Token(Token = "0x1700002B")]
		public string Title
		{
			[Token(Token = "0x6000172")]
			[Address(RVA = "0xC60424", Offset = "0xC60424", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Purchasing.LocalizedProductDescription::DecodeNonLatinCharacters(this.title);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DecodeNonLatinCharacters(title);
			}
		}

		[Token(Token = "0x1700002C")]
		public string Description
		{
			[Token(Token = "0x6000173")]
			[Address(RVA = "0xC6042C", Offset = "0xC6042C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Purchasing.LocalizedProductDescription::DecodeNonLatinCharacters(this.description);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DecodeNonLatinCharacters(description);
			}
		}

		[Token(Token = "0x6000174")]
		[Address(RVA = "0xC64DB0", Offset = "0xC64DB0", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EACBB8]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202335D]) = v44;\nL_0016:\n\tv45 = s == 0;\n\tif (v45) goto L_006A;\n\tgoto L_0027;\n\tv60 = *([v48 @ X0_v3 (Il2CppClass<UnityEngine.Purchasing.LocalizedProductDescription+<>c>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_0027;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv64 = UnityEngine.Purchasing.LocalizedProductDescription+<>c;\nL_0027:\n\tv111 = v67.<>9__11_0;\n\tv72 = v67.<>9__11_0 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_004D;\n\tgoto L_003C;\n\tv130 = *([v63 @ X0_v4 (Il2CppClass<UnityEngine.Purchasing.LocalizedProductDescription+<>c>)+E0]);\n\tv131 = v130 == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_003C;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v63, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv148 = UnityEngine.Purchasing.LocalizedProductDescription+<>c;\n\tv136 = *([v148 @ X8_v19+B8]);\nL_003C:\n\tv119 = new System.Text.RegularExpressions.MatchEvaluator();\n\tSystem.Text.RegularExpressions.MatchEvaluator::.ctor(v119, v135.<>9, Il2CppMethodInfo);\n\tv123.<>9__11_0 = v119;\nL_004D:\n\tgoto L_005F;\n\tv140 = *([v126 @ X0_v6+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tgoto L_005F;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v126, v115, v109, v113, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_005F:\n\treturnVal2 = System.Text.RegularExpressions.Regex::Replace(s, \"\\\\\\\\u(?<Value>[a-zA-Z0-9]{4})\", v111);\n\treturn returnVal2;\nL_006A:\n\treturn 0;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static string DecodeNonLatinCharacters(string s)
		{
			if (s != null)
			{
				MatchEvaluator evaluator = _003C_003Ec._003C_003E9__11_0;
				if (_003C_003Ec._003C_003E9__11_0 == null)
				{
					evaluator = (_003C_003Ec._003C_003E9__11_0 = delegate(Match m)
					{
						GroupCollection groups = m.Groups;
						Group obj = groups.get_Item("Value");
						string value = obj.Value;
						int num = int.Parse(value, NumberStyles.HexNumber);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F91044 (inside System.Char::GetLatin1UnicodeCategory +0x228)");
						string result = default(string);
						return result;
					});
				}
				return Regex.Replace(s, "\\\\u(?<Value>[a-zA-Z0-9]{4})", evaluator);
			}
			return null;
		}

		[Token(Token = "0x6000175")]
		[Address(RVA = "0xC64EE0", Offset = "0xC64EE0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.googleLocale = 4;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LocalizedProductDescription()
		{
			googleLocale = TranslationLocale.en_US;
		}
	}
}
