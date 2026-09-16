using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000072")]
	internal class StoreConfiguration
	{
		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72D0E4", Offset = "0x72D0E4")]
		[Token(Token = "0x40001A0")]
		[FieldOffset(Offset = "0x10")]
		private AppStore _003CandroidStore_003Ek__BackingField;

		[Token(Token = "0x17000057")]
		public AppStore androidStore
		{
			[CompilerGenerated]
			[Token(Token = "0x60001F9")]
			[Address(RVA = "0x15AE340", Offset = "0x15AE340", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<androidStore>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return androidStore;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001FA")]
			[Address(RVA = "0x15AE348", Offset = "0x15AE348", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<androidStore>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CandroidStore_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60001FB")]
		[Address(RVA = "0x15AE350", Offset = "0x15AE350", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<androidStore>k__BackingField = store;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StoreConfiguration(AppStore store)
		{
			androidStore = store;
		}

		[Token(Token = "0x60001FC")]
		[Address(RVA = "0x15AE37C", Offset = "0x15AE37C", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = *([1EE4128]);\n\tv33 = *([v32 @ X8_v31]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20298AA]) = v52;\nL_001C:\n\tv55 = UnityEngine.Purchasing.MiniJson::JsonDecode(json);\n\tgoto L_FFFFFFFF;\n\tv177 = v177_asT == 0;\n\tif (v177) goto L_00E5;\n\tv229 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v55, \"androidStore\");\n\tv231 = v229 == 0;\n\tif (v231) goto L_0063;\n\tv207 = *([v229 @ X0_v15 (System.Object)]) != System.String;\n\tif (v207) goto L_00E8;\nL_0063:\n\tgoto L_006B;\n\tv359 = *([v298 @ X0_v16+E0]);\n\tv360 = v359 == 0;\n\tv361 = ~v360;\n\tif (v361) goto L_006B;\n\tv363 = \"il2cpp_codegen_runtime_class_init\"(v298, v294, v202, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_006B:\n\tv368 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.AppStore);\n\tgoto L_007D;\n\tv374 = *([v370 @ X8_v14+E0]);\n\tv375 = v374 == 0;\n\tv376 = ~v375;\n\tif (v376) goto L_007D;\n\tv385 = v370;\n\tv379 = \"il2cpp_codegen_runtime_class_init\"(v385, v367, v202, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_007D:\n\tv384 = System.Enum::IsDefined(v368, v229);\n\tv387 = v384 == 0;\n\tif (v387) goto L_FFFFFFFF;\n\tgoto L_008E;\n\tv394 = *([v388 @ X0_v27+E0]);\n\tv395 = v394 == 0;\n\tv396 = ~v395;\n\tif (v396) goto L_008E;\n\tv398 = \"il2cpp_codegen_runtime_class_init\"(v388, v382, v383, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_008E:\n\tv403 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.AppStore);\n\tv416 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v55, \"androidStore\");\n\tv418 = System.Enum;\n\tv420 = *([v418 @ X8_v20 (Il2CppClass<System.Enum>)+12F]) & 2;\n\tv421 = v420 == 0;\n\tif (v421) goto L_009D;\n\tv423 = *([v418 @ X8_v20 (Il2CppClass<System.Enum>)+E0]) == 0;\n\tif (v423) goto L_00E0;\nL_009D:\n\tv426 = v416 == 0;\n\tif (v426) goto L_00B0;\nL_00AA:\n\tv179 = *([v416 @ X0_v32 (System.String)]) != System.String;\n\tif (v179) goto L_00E5;\nL_00B0:\n\tv151 = System.Enum::Parse(v403, v416, 1);\n\tv254 = v254_asT == 0;\n\tif (v254) goto L_00E9;\n\tv406 = \"il2cpp_vm_object_unbox\"(v151, UnityEngine.Purchasing.AppStore, 1, 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv409 = *([v406 @ X0_v36]);\n\tgoto L_00CB;\nL_00CB:\n\tv413 = new UnityEngine.Purchasing.StoreConfiguration();\n\tSystem.Object::.ctor(v413);\n\tv413.<androidStore>k__BackingField = v409;\n\treturn v413;\nL_00E0:\n\tv435 = v416 == 0;\n\tv429 = ~v435;\n\tif (v429) goto L_00AA;\n\tgoto L_00B0;\nL_00E5:\n\tv150 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\nL_00E8:\n\tv238 = new System.InvalidCastException();\nL_00E9:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 166 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static StoreConfiguration Deserialize(string json)
		{
			//IL_010b: Expected I, but got O
			//IL_01d2: Expected I4, but got O
			//IL_0201: Expected I4, but got O
			object obj = MiniJson.JsonDecode(json);
			Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
			if (dictionary == null)
			{
				goto IL_0241;
			}
			object obj2 = ((Dictionary<string, object>)obj).get_Item("androidStore");
			Type typeFromHandle2;
			string text;
			int num;
			if (obj2 == null || (object)obj2.GetType() == typeof(string))
			{
				Type typeFromHandle = typeof(AppStore);
				if (Enum.IsDefined(typeFromHandle, obj2))
				{
					typeFromHandle2 = typeof(AppStore);
					text = (string)((Dictionary<string, object>)obj).get_Item("androidStore");
					IntPtr intPtr = (IntPtr)typeof(Enum);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ X8_v20 (Il2CppClass<System.Enum>)+12F]");
					if (0u != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ X8_v20 (Il2CppClass<System.Enum>)+E0]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							if (text != null)
							{
								goto IL_0180;
							}
							goto IL_01aa;
						}
					}
					if (text != null)
					{
						goto IL_0180;
					}
					goto IL_01aa;
				}
				num = 1;
				goto IL_0283;
			}
			InvalidCastException ex = new InvalidCastException();
			goto IL_0263;
			IL_0180:
			if ((object)text.GetType() == typeof(string))
			{
				goto IL_01aa;
			}
			goto IL_0241;
			IL_0283:
			StoreConfiguration storeConfiguration = null;
			storeConfiguration.androidStore = (AppStore)num;
			return storeConfiguration;
			IL_01aa:
			object obj3 = Enum.Parse(typeFromHandle2, text, ignoreCase: true);
			if ((int)((obj3 is AppStore) ? obj3 : null) == 0)
			{
				goto IL_0263;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			object obj4 = default(object);
			num = (int)obj4;
			goto IL_0283;
			IL_0263:
			return (StoreConfiguration)(object)new InvalidCastException();
			IL_0241:
			InvalidCastException ex2 = new InvalidCastException();
			throw new NullReferenceException();
		}
	}
}
