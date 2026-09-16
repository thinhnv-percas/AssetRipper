using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000039")]
	public static class MoPubSettingsExtension
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000116")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40004B6")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40004B7")]
			public static Func<KeyValuePair<string, string>, string> _003C_003E9__0_0;

			[Token(Token = "0x40004B8")]
			public static Func<KeyValuePair<string, string>, object> _003C_003E9__0_1;

			[Token(Token = "0x600095C")]
			[Address(RVA = "0xFCE3A4", Offset = "0xFCE3A4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EDF5C0]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2025667]) = v37;\nL_0015:\n\tv41 = new EasyMobile.MoPubSettingsExtension+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600095D")]
			[Address(RVA = "0xFCE408", Offset = "0xFCE408", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal string _003CStringStringDictToStringObjectDict_003Eb__0_0(KeyValuePair<string, string> item)
			{
				return (string)item;
			}

			internal object _003CStringStringDictToStringObjectDict_003Eb__0_1(KeyValuePair<string, string> item)
			{
				//IL_0025: Expected O, but got I
				//IL_000d: Expected O, but got I
				IntPtr intPtr = default(IntPtr);
				if (string.IsNullOrEmpty((string)(long)intPtr))
				{
					return (long)intPtr;
				}
				return null;
			}
		}

		[Token(Token = "0x600033C")]
		[Address(RVA = "0xFCE218", Offset = "0xFCE218", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F10B48]);\n\tv25 = *([v24 @ X8_v34]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2025666]) = v44;\nL_0016:\n\tv45 = dict == 0;\n\tif (v45) goto L_FFFFFFFF;\n\tgoto L_0026;\n\tv53 = *([v48 @ X0_v4 (Il2CppClass<EasyMobile.MoPubSettingsExtension+<>c>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0026;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv57 = EasyMobile.MoPubSettingsExtension+<>c;\nL_0026:\n\tv85 = v60.<>9__0_0;\n\tv62 = v60.<>9__0_0 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0049;\n\tgoto L_0039;\n\tv117 = *([v56 @ X0_v5 (Il2CppClass<EasyMobile.MoPubSettingsExtension+<>c>)+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_0039;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv163 = EasyMobile.MoPubSettingsExtension+<>c;\n\tv124 = *([v163 @ X8_v30+B8]);\nL_0039:\n\tv128 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, System.String>, System.String>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, System.String>, System.String>::.ctor(v128, v123.<>9, Il2CppMethodInfo);\n\tv112.<>9__0_0 = v128;\nL_0049:\n\tgoto L_0051;\n\tv129 = *([v107 @ X0_v6 (Il2CppClass<EasyMobile.MoPubSettingsExtension+<>c>)+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tgoto L_0051;\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v107, v103, v101, v99, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv133 = EasyMobile.MoPubSettingsExtension+<>c;\nL_0051:\n\tv67 = v136.<>9__0_1;\n\tv138 = v136.<>9__0_1 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_0077;\n\tgoto L_0064;\n\tv164 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.MoPubSettingsExtension+<>c>)+E0]);\n\tv165 = v164 == 0;\n\tv166 = ~v165;\n\tif (v166) goto L_0064;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v132, v103, v101, v99, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv178 = EasyMobile.MoPubSettingsExtension+<>c;\n\tv171 = *([v178 @ X8_v21+B8]);\nL_0064:\n\tv157 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, System.String>, System.Object>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, System.String>, System.Object>::.ctor(v157, v170.<>9, Il2CppMethodInfo);\n\tv160.<>9__0_1 = v157;\nL_0077:\n\treturnVal1 = System.Linq.Enumerable::ToDictionary(dict, v85, v67);\n\tgoto L_0082;\nL_0082:\n\treturn returnVal1;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Dictionary<string, object> StringStringDictToStringObjectDict(this Dictionary<string, string> dict)
		{
			if (dict == null)
			{
				return null;
			}
			Func<KeyValuePair<string, string>, string> keySelector = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				keySelector = (_003C_003Ec._003C_003E9__0_0 = (KeyValuePair<string, string> item) => (string)item);
			}
			Func<KeyValuePair<string, string>, object> elementSelector = _003C_003Ec._003C_003E9__0_1;
			if (_003C_003Ec._003C_003E9__0_1 == null)
			{
				elementSelector = (_003C_003Ec._003C_003E9__0_1 = delegate
				{
					//IL_0025: Expected O, but got I
					//IL_000d: Expected O, but got I
					IntPtr intPtr = default(IntPtr);
					return string.IsNullOrEmpty((string)(long)intPtr) ? ((object)(long)intPtr) : null;
				});
			}
			return dict.ToDictionary(keySelector, elementSelector);
		}
	}
}
