using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200001C")]
	public class AdPlacement : AdLocation
	{
		[Token(Token = "0x40000D7")]
		private static Dictionary<string, AdPlacement> sCustomPlacements;

		[SerializeField]
		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x18")]
		protected string mName;

		[Token(Token = "0x40000D9")]
		public new static readonly AdPlacement Default;

		[Token(Token = "0x40000DA")]
		public new static readonly AdPlacement Startup;

		[Token(Token = "0x40000DB")]
		public new static readonly AdPlacement HomeScreen;

		[Token(Token = "0x40000DC")]
		public new static readonly AdPlacement MainMenu;

		[Token(Token = "0x40000DD")]
		public new static readonly AdPlacement GameScreen;

		[Token(Token = "0x40000DE")]
		public new static readonly AdPlacement Achievements;

		[Token(Token = "0x40000DF")]
		public new static readonly AdPlacement LevelStart;

		[Token(Token = "0x40000E0")]
		public new static readonly AdPlacement LevelComplete;

		[Token(Token = "0x40000E1")]
		public new static readonly AdPlacement TurnComplete;

		[Token(Token = "0x40000E2")]
		public new static readonly AdPlacement Quests;

		[Token(Token = "0x40000E3")]
		public new static readonly AdPlacement Pause;

		[Token(Token = "0x40000E4")]
		public new static readonly AdPlacement IAPStore;

		[Token(Token = "0x40000E5")]
		public new static readonly AdPlacement ItemStore;

		[Token(Token = "0x40000E6")]
		public new static readonly AdPlacement GameOver;

		[Token(Token = "0x40000E7")]
		public static readonly AdPlacement Leaderboard;

		[Token(Token = "0x40000E8")]
		public new static readonly AdPlacement Settings;

		[Token(Token = "0x40000E9")]
		public new static readonly AdPlacement Quit;

		[Token(Token = "0x17000018")]
		public string Name
		{
			[Token(Token = "0x600007D")]
			[Address(RVA = "0xA462A0", Offset = "0xA462A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0xA462A8", Offset = "0xA462A8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFD308]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EC1]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tSystem.Object::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected AdPlacement()
		{
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0xA46310", Offset = "0xA46310", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1F10718]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, isDefault, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021EC2]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0026;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, name, isDefault, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tEasyMobile.AdLocation::.ctor(this, name, 0);\n\tthis.mName = name;\n\tv62 = isDefault == 0;\n\tif (v62) goto L_0039;\n\treturn;\nL_0039:\n\tgoto L_0050;\n\tv101 = *([v71 @ X0_v5 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\t// 61 ConditionalJump @b19, v103 @ TEMP_v14\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v71, v59, v60, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv105 = EasyMobile.AdPlacement;\nL_0050:\n\tSystem.Collections.Generic.Dictionary`2<System.String, EasyMobile.AdPlacement>::set_Item(v96.sCustomPlacements, name, this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private AdPlacement(string name, bool isDefault = false)
			: base(name, addToMap: false)
		{
			mName = name;
			if (!isDefault)
			{
				sCustomPlacements.set_Item(name, this);
			}
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0xA463F0", Offset = "0xA463F0", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EE44A0]);\n\tv17 = *([v16 @ X8_v23]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EC3]) = v37;\nL_0015:\n\tv41 = new System.Collections.Generic.List`1<EasyMobile.AdPlacement>();\n\tSystem.Collections.Generic.List`1<EasyMobile.AdPlacement>::.ctor(v41);\n\tgoto L_0030;\n\tv52 = *([v48 @ X0_v4+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\t// 37 Jump @b9\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, v45, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0030:\n\tSystem.Collections.Generic.List`1<EasyMobile.AdPlacement>::Add(v41, v63.Default);\n\tv83 = System.Collections.Generic.Dictionary`2<System.String, EasyMobile.AdPlacement>::get_Values(v69.sCustomPlacements);\n\tSystem.Collections.Generic.List`1<EasyMobile.AdPlacement>::AddRange(v41, v83);\n\treturnVal2 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>::ToArray(v41);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AdPlacement[] GetAllPlacements()
		{
			List<AdPlacement> list = new List<AdPlacement>();
			list.Add(Default);
			Dictionary<string, AdPlacement>.ValueCollection values = sCustomPlacements.Values;
			list.AddRange(values);
			return list.ToArray();
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0xA464E4", Offset = "0xA464E4", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F03A28]);\n\tv17 = *([v16 @ X8_v19]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EC4]) = v37;\nL_0018:\n\tgoto L_0026;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\t// 28 Jump @b18\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = EasyMobile.AdPlacement;\nL_0026:\n\tv58 = System.Collections.Generic.Dictionary`2<System.String, EasyMobile.AdPlacement>::get_Values(v51.sCustomPlacements);\n\tv65 = new System.Collections.Generic.List`1<EasyMobile.AdPlacement>();\n\tSystem.Collections.Generic.List`1<EasyMobile.AdPlacement>::.ctor(v65, v58);\n\treturnVal2 = System.Collections.Generic.List`1<EasyMobile.AdPlacement>::ToArray(v65);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AdPlacement[] GetCustomPlacements()
		{
			//IL_001c: Expected I4, but got O
			Dictionary<string, AdPlacement>.ValueCollection values = sCustomPlacements.Values;
			List<AdPlacement> list = new List<AdPlacement>((int)values);
			return list.ToArray();
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0xA45D08", Offset = "0xA45D08", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ED5AD0]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EC5]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(name);\n\tv47 = v41 == 0;\n\tif (v47) goto L_002C;\n\tgoto L_0028;\n\tv52 = *([v44 @ X8_v3 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0028;\n\tv75 = v44;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v75, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv60 = EasyMobile.AdPlacement;\nL_0028:\n\tv93 = v61.Default;\n\tgoto L_0063;\nL_002C:\n\tgoto L_003C;\n\tv63 = *([v44 @ X8_v3 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\t// 48 ConditionalJump @b29, v65 @ TEMP_v21\n\tv101 = v44;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v101, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv71 = EasyMobile.AdPlacement;\nL_003C:\n\tv106 = System.Collections.Generic.Dictionary`2<System.String, EasyMobile.AdPlacement>::ContainsKey(v72.sCustomPlacements, name);\n\tv88 = v106 == 0;\n\tif (v88) goto L_0058;\n\tgoto L_0054;\n\tv131 = *([v91 @ X8_v10 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\t// 72 ConditionalJump @b30, v133 @ TEMP_v19\n\tv139 = v91;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v139, v104, v105, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv138 = EasyMobile.AdPlacement;\nL_0054:\n\tv86 = System.Collections.Generic.Dictionary`2<System.String, EasyMobile.AdPlacement>::get_Item(v114.sCustomPlacements, name);\n\tgoto L_0063;\nL_0058:\n\tv85 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v85, name, 0);\nL_0063:\n\treturn v93;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AdPlacement PlacementWithName(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				if (sCustomPlacements.ContainsKey(name))
				{
					return sCustomPlacements.get_Item(name);
				}
				return new AdPlacement(name);
			}
			return Default;
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0xA43DD8", Offset = "0xA43DD8", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EAEBF8]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EC6]) = v38;\nL_0015:\n\tv41 = EasyMobile.AdPlacement;\n\tv43 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+12F]) & 2;\n\tv44 = v43 == 0;\n\tif (v44) goto L_001D;\n\tv46 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]) == 0;\n\tif (v46) goto L_004A;\nL_001D:\n\tv49 = placement == 0;\n\tif (v49) goto L_FFFFFFFF;\nL_0024:\n\tv60 = EasyMobile.AdPlacement::Equals(placement, 0);\n\tv62 = v60 == 0;\n\tif (v62) goto L_0035;\nL_0030:\n\treturn *([v87 @ X8_v4 (System.String)]);\nL_0035:\n\tgoto L_0042;\n\tv94 = *([v73 @ X0_v9 (Il2CppClass<EasyMobile.AdPlacement>)+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_0042;\n\tv123 = \"il2cpp_codegen_runtime_class_init\"(v73, v57, v59, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv98 = EasyMobile.AdPlacement;\nL_0042:\n\tv84 = EasyMobile.AdPlacement::Equals(placement, v101.Default);\n\tv86 = v84 == 0;\n\tif (v86) goto L_004E;\n\tgoto L_0030;\nL_004A:\n\tv72 = placement == 0;\n\tv53 = ~v72;\n\tif (v53) goto L_0024;\n\tgoto L_FFFFFFFF;\nL_004E:\n\tv118 = placement->klass;\n\tv108 = placement->klass->vtable[3];\n\tv111 = placement->klass->vtable[3];\n\t// 87 IndirectJump v108 @ X2_v5, placement @ X0 (EasyMobile.AdPlacement), placement @ X0 (EasyMobile.AdPlacement), v111 @ X1_v5, v108 @ X2_v5, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn X0;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetPrintableName(AdPlacement placement)
		{
			//IL_0100: Expected I, but got O
			//IL_00c8: Expected I, but got O
			//IL_00d8: Expected O, but got I
			//IL_00e8: Expected O, but got I
			while (true)
			{
				IntPtr intPtr = (IntPtr)typeof(AdPlacement);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+12F]");
				if (0u != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						if ((object)placement != null)
						{
							goto IL_0047;
						}
						goto IL_0072;
					}
				}
				if ((object)placement != null)
				{
					goto IL_0047;
				}
				goto IL_0072;
				IL_0047:
				if (placement.Equals(null))
				{
					goto IL_0072;
				}
				if (!placement.Equals(Default))
				{
					IntPtr intPtr2 = (IntPtr)placement;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v14 (Il2CppClass<EasyMobile.AdPlacement>)+160]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v14 (Il2CppClass<EasyMobile.AdPlacement>)+168]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v108 @ X2_v5 (should have been resolved before IL gen)");
					continue;
				}
				break;
				IL_0072:
				return "null";
			}
			return "[Default]";
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0xA465B0", Offset = "0xA465B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return Name;
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0xA465B8", Offset = "0xA465B8", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EE1A28]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, obj, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EC7]) = v41;\nL_0017:\n\tv44 = EasyMobile.AdPlacement;\n\tv45 = obj == 0;\n\tif (v45) goto L_003D;\n\tgoto L_FFFFFFFF;\n\tgoto L_003D;\n\tv60 = v60_asT == 0;\n\tif (v60) goto L_FFFFFFFF;\n\tgoto L_003D;\nL_003D:\n\tv99 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+12F]) & 2;\n\tv100 = v99 == 0;\n\tif (v100) goto L_0043;\n\tv105 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]) == 0;\n\tif (v105) goto L_0067;\nL_0043:\n\tv108 = v92 == 0;\n\tif (v108) goto L_0055;\nL_004A:\n\tv119 = System.Object::Equals(v92, 0);\n\tv121 = v119 == 0;\n\tif (v121) goto L_0058;\nL_0055:\n\treturn 0;\nL_0058:\n\tv137 = System.String::IsNullOrEmpty(this.mName);\n\tv152 = v137 == 0;\n\tif (v152) goto L_0076;\n\treturnVal2 = System.String::IsNullOrEmpty(*([v92 @ X20_v2 (System.Object)+18]));\n\treturn returnVal2;\nL_0067:\n\tv134 = v92 == 0;\n\tv112 = ~v134;\n\tif (v112) goto L_004A;\n\tgoto L_0055;\nL_0076:\n\treturnVal3 = System.String::Equals(this.mName, *([v92 @ X20_v2 (System.Object)+18]));\n\treturn returnVal3;\n\treturnVal4 = new System.NullReferenceException();\n\treturn returnVal4;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			//IL_0169: Expected I, but got O
			//IL_0152: Expected O, but got I
			//IL_0105: Expected O, but got I
			IntPtr intPtr = (IntPtr)typeof(AdPlacement);
			bool flag = obj == null;
			object obj2 = obj;
			if (!flag)
			{
				AdPlacement adPlacement = obj as AdPlacement;
				obj2 = (((object)adPlacement == null) ? null : obj);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					if (obj2 != null)
					{
						goto IL_0097;
					}
					goto IL_00c2;
				}
			}
			if (obj2 != null)
			{
				goto IL_0097;
			}
			goto IL_00c2;
			IL_0097:
			if (obj2.Equals(null))
			{
				goto IL_00c2;
			}
			if (string.IsNullOrEmpty(Name))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X20_v2 (System.Object)+18]");
				return string.IsNullOrEmpty((string)0);
			}
			string text = Name;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X20_v2 (System.Object)+18]");
			return text.Equals((string)0);
			IL_00c2:
			return false;
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0xA466CC", Offset = "0xA466CC", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.mName;\n\tv3 = *([v0 @ X0_v1 (System.String)]);\n\tv4 = *([v3 @ X8_v1 (Il2CppClass<System.String>)+150]);\n\tv5 = *([v3 @ X8_v1 (Il2CppClass<System.String>)+158]);\n\t// 6 IndirectJump v4 @ X2_v1, v0 @ X0_v1 (System.String), v0 @ X0_v1 (System.String), v5 @ X1_v1, v4 @ X2_v1, v6 @ X3, v7 @ X4, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			//IL_0017: Expected I, but got O
			//IL_0027: Expected O, but got I
			//IL_0037: Expected O, but got I
			string text = Name;
			IntPtr intPtr = (IntPtr)text;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<System.String>)+150]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v1 (Il2CppClass<System.String>)+158]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
			return 0;
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0xA432B8", Offset = "0xA432B8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = placementA == 0;\n\tif (v0) goto L_000A;\n\tv2 = placementA->klass;\n\tv3 = placementA->klass->vtable[0];\n\tv4 = placementA->klass->vtable[0];\n\t// 5 IndirectJump v3 @ X3_v1, placementA @ X0 (EasyMobile.AdPlacement), placementA @ X0 (EasyMobile.AdPlacement), placementB @ X1 (EasyMobile.AdPlacement), v4 @ X2_v1, v3 @ X3_v1, v6 @ X4, v7 @ X5, v8 @ X6, v9 @ X7, v10 @ V0, v11 @ V1, v12 @ V2, v13 @ V3, v14 @ V4, v15 @ V5, v16 @ V6, v17 @ V7\nL_000A:\n\tv22 = placementB == 0;\n\treturn v22;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator ==(AdPlacement placementA, AdPlacement placementB)
		{
			//IL_0025: Expected I, but got O
			//IL_0035: Expected O, but got I
			//IL_0045: Expected O, but got I
			if ((object)placementA != null)
			{
				IntPtr intPtr = (IntPtr)placementA;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.AdPlacement>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.AdPlacement>)+138]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ X3_v1 (should have been resolved before IL gen)");
			}
			return (object)placementB == null;
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0xA43428", Offset = "0xA43428", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1ED80F8]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placementB, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EC8]) = v41;\nL_0017:\n\tv44 = EasyMobile.AdPlacement;\n\tv46 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+12F]) & 2;\n\tv47 = v46 == 0;\n\tif (v47) goto L_001F;\n\tv49 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]) == 0;\n\tif (v49) goto L_0029;\nL_001F:\n\tv52 = placementA == 0;\n\tif (v52) goto L_0030;\nL_0026:\n\tv98 = EasyMobile.AdPlacement::Equals(placementA, placementB);\n\tgoto L_003A;\nL_0029:\n\tv77 = placementA == 0;\n\tv56 = ~v77;\n\tif (v56) goto L_0026;\nL_0030:\n\tv71 = placementB == 0;\nL_003A:\n\tv105 = ~v98;\n\treturn v105;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator !=(AdPlacement placementA, AdPlacement placementB)
		{
			//IL_00af: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(AdPlacement);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v2 (Il2CppClass<EasyMobile.AdPlacement>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					if ((object)placementA != null)
					{
						goto IL_0047;
					}
					goto IL_0085;
				}
			}
			if ((object)placementA != null)
			{
				goto IL_0047;
			}
			goto IL_0085;
			IL_0047:
			bool flag = placementA.Equals(placementB);
			goto IL_00e2;
			IL_00e2:
			return !flag;
			IL_0085:
			bool flag2 = (object)placementB == null;
			flag = flag2;
			goto IL_00e2;
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0xA466EC", Offset = "0xA466EC", Length = "0x334")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF0318]);\n\tv19 = *([v18 @ X8_v62]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2021EC9]) = v39;\nL_0016:\n\tv43 = new System.Collections.Generic.Dictionary`2<System.String, EasyMobile.AdPlacement>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, EasyMobile.AdPlacement>::.ctor(v43);\n\tv52.sCustomPlacements = v43;\n\tv58 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v58, v56.Empty, 1);\n\tv63.Default = v58;\n\tv64 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v64, \"Startup\", 0);\n\tv71.Startup = v64;\n\tv72 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v72, \"Home_Screen\", 0);\n\tv79.HomeScreen = v72;\n\tv80 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v80, \"Main_Menu\", 0);\n\tv87.MainMenu = v80;\n\tv88 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v88, \"Game_Screen\", 0);\n\tv95.GameScreen = v88;\n\tv96 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v96, \"Achievements\", 0);\n\tv103.Achievements = v96;\n\tv104 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v104, \"Level_Start\", 0);\n\tv111.LevelStart = v104;\n\tv112 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v112, \"Level_Complete\", 0);\n\tv119.LevelComplete = v112;\n\tv120 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v120, \"Turn_Complete\", 0);\n\tv127.TurnComplete = v120;\n\tv128 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v128, \"Quests\", 0);\n\tv135.Quests = v128;\n\tv136 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v136, \"Pause\", 0);\n\tv143.Pause = v136;\n\tv144 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v144, \"IAP_Store\", 0);\n\tv151.IAPStore = v144;\n\tv152 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v152, \"Item_Store\", 0);\n\tv159.ItemStore = v152;\n\tv160 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v160, \"Game_Over\", 0);\n\tv167.GameOver = v160;\n\tv168 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v168, \"Leaderboard\", 0);\n\tv175.Leaderboard = v168;\n\tv176 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v176, \"Settings\", 0);\n\tv183.Settings = v176;\n\tv184 = new EasyMobile.AdPlacement();\n\tEasyMobile.AdPlacement::.ctor(v184, \"Quit\", 0);\n\tv191.Quit = v184;\n\treturn;\n// 153 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static AdPlacement()
		{
			Dictionary<string, AdPlacement> dictionary = new Dictionary<string, AdPlacement>();
			sCustomPlacements = dictionary;
			AdPlacement adPlacement = new AdPlacement(string.Empty, isDefault: true);
			Default = adPlacement;
			AdPlacement startup = new AdPlacement("Startup");
			Startup = startup;
			AdPlacement homeScreen = new AdPlacement("Home_Screen");
			HomeScreen = homeScreen;
			AdPlacement mainMenu = new AdPlacement("Main_Menu");
			MainMenu = mainMenu;
			AdPlacement gameScreen = new AdPlacement("Game_Screen");
			GameScreen = gameScreen;
			AdPlacement achievements = new AdPlacement("Achievements");
			Achievements = achievements;
			AdPlacement levelStart = new AdPlacement("Level_Start");
			LevelStart = levelStart;
			AdPlacement levelComplete = new AdPlacement("Level_Complete");
			LevelComplete = levelComplete;
			AdPlacement turnComplete = new AdPlacement("Turn_Complete");
			TurnComplete = turnComplete;
			AdPlacement quests = new AdPlacement("Quests");
			Quests = quests;
			AdPlacement pause = new AdPlacement("Pause");
			Pause = pause;
			AdPlacement iAPStore = new AdPlacement("IAP_Store");
			IAPStore = iAPStore;
			AdPlacement itemStore = new AdPlacement("Item_Store");
			ItemStore = itemStore;
			AdPlacement gameOver = new AdPlacement("Game_Over");
			GameOver = gameOver;
			AdPlacement leaderboard = new AdPlacement("Leaderboard");
			Leaderboard = leaderboard;
			AdPlacement settings = new AdPlacement("Settings");
			Settings = settings;
			AdPlacement quit = new AdPlacement("Quit");
			Quit = quit;
		}
	}
}
