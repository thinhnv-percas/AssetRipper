using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.MiniJSON;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200005A")]
	internal class PurchasingEvent
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200005B")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000117")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000118")]
			public static Func<KeyValuePair<string, object>, string> _003C_003E9__2_0;

			[Token(Token = "0x4000119")]
			public static Func<KeyValuePair<string, object>, object> _003C_003E9__2_1;

			[Token(Token = "0x6000155")]
			[Address(RVA = "0xC6E278", Offset = "0xC6E278", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1ED6A08]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20233AD]) = v37;\nL_0015:\n\tv41 = new UnityEngine.Purchasing.PurchasingEvent+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000156")]
			[Address(RVA = "0xC6E2DC", Offset = "0xC6E2DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal string _003CFlatJSON_003Eb__2_0(KeyValuePair<string, object> s)
			{
				return (string)s;
			}

			internal object _003CFlatJSON_003Eb__2_1(KeyValuePair<string, object> s)
			{
				//IL_000a: Expected O, but got I
				IntPtr intPtr = default(IntPtr);
				return (long)intPtr;
			}
		}

		[Token(Token = "0x4000116")]
		[FieldOffset(Offset = "0x10")]
		internal Dictionary<string, object> EventDict;

		[Token(Token = "0x6000153")]
		[Address(RVA = "0xC64520", Offset = "0xC64520", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.EventDict = eventDict;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PurchasingEvent(Dictionary<string, object> eventDict)
		{
			EventDict = eventDict;
		}

		[Token(Token = "0x6000154")]
		[Address(RVA = "0xC6454C", Offset = "0xC6454C", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1F0C2C8]);\n\tv27 = *([v26 @ X8_v35]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, profileDict, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20233AC]) = v45;\nL_001C:\n\tv51 = System.Linq.Enumerable::Concat(profileDict, this.EventDict);\n\tgoto L_002D;\n\tv59 = *([v55 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.PurchasingEvent+<>c>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_002D;\n\tv72 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v72, v47, v50, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv67 = UnityEngine.Purchasing.PurchasingEvent+<>c;\nL_002D:\n\tv91 = v68.<>9__2_0;\n\tv70 = v68.<>9__2_0 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0051;\n\tgoto L_0041;\n\tv100 = *([v66 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.PurchasingEvent+<>c>)+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_0041;\n\tv125 = v66;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v125, v47, v50, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv108 = UnityEngine.Purchasing.PurchasingEvent+<>c;\n\tv104 = *([v108 @ X8_v32+B8]);\nL_0041:\n\tv88 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, System.Object>, System.String>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, System.Object>, System.String>::.ctor(v88, v103.<>9, Il2CppMethodInfo);\n\tv86.<>9__2_0 = v88;\nL_0051:\n\tgoto L_005A;\n\tv112 = *([v93 @ X8_v7 (Il2CppClass<UnityEngine.Purchasing.PurchasingEvent+<>c>)+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tgoto L_005A;\n\tv130 = v93;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v130, v80, v78, v76, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv120 = UnityEngine.Purchasing.PurchasingEvent+<>c;\nL_005A:\n\tv152 = v121.<>9__2_1;\n\tv123 = v121.<>9__2_1 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_0081;\n\tgoto L_006E;\n\tv161 = *([v119 @ X8_v8 (Il2CppClass<UnityEngine.Purchasing.PurchasingEvent+<>c>)+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_006E;\n\tv175 = v119;\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v175, v80, v78, v76, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv169 = UnityEngine.Purchasing.PurchasingEvent+<>c;\n\tv165 = *([v169 @ X8_v24+B8]);\nL_006E:\n\tv147 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, System.Object>, System.Object>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, System.Object>, System.Object>::.ctor(v147, v164.<>9, Il2CppMethodInfo);\n\tv151.<>9__2_1 = v147;\nL_0081:\n\tv160 = System.Linq.Enumerable::ToDictionary(v51, v91, v152);\n\treturnVal1 = UnityEngine.Purchasing.MiniJSON.Json::Serialize(v160);\n\tv179 = returnVal1 == 0;\n\tv180 = ~v179;\n\tif (v180) goto L_0094;\n\treturnVal1 = v185.Empty;\nL_0094:\n\treturn returnVal1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string FlatJSON(Dictionary<string, object> profileDict)
		{
			IEnumerable<KeyValuePair<string, object>> source = profileDict.Concat(EventDict);
			Func<KeyValuePair<string, object>, string> keySelector = _003C_003Ec._003C_003E9__2_0;
			if (_003C_003Ec._003C_003E9__2_0 == null)
			{
				keySelector = (_003C_003Ec._003C_003E9__2_0 = (KeyValuePair<string, object> s) => (string)s);
			}
			Func<KeyValuePair<string, object>, object> elementSelector = _003C_003Ec._003C_003E9__2_1;
			if (_003C_003Ec._003C_003E9__2_1 == null)
			{
				elementSelector = (_003C_003Ec._003C_003E9__2_1 = delegate
				{
					//IL_000a: Expected O, but got I
					IntPtr intPtr = default(IntPtr);
					return (long)intPtr;
				});
			}
			Dictionary<string, object> obj = source.ToDictionary(keySelector, elementSelector);
			string text = Json.Serialize(obj);
			if (text == null)
			{
				text = string.Empty;
			}
			return text;
		}
	}
}
