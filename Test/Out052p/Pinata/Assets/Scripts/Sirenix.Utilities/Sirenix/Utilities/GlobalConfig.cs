using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Sirenix.Utilities
{
	[Token(Token = "0x2000006")]
	public abstract class GlobalConfig<T> : ScriptableObject where T : GlobalConfig<T>, new()
	{
		[Token(Token = "0x4000011")]
		private static GlobalConfigAttribute configAttribute;

		[Token(Token = "0x4000012")]
		private static T instance;

		[Token(Token = "0x17000001")]
		private static GlobalConfigAttribute ConfigAttribute
		{
			[Token(Token = "0x600000D")]
			[Address(RVA = "0x11E7090", Offset = "0x11E7090", Length = "0x278")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EB8950]);\n\tv25 = *([v24 @ X8_v42]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2027C07]) = v44;\nL_001B:\n\tgoto L_0024;\n\tv50 = v45;\n\tv51 = 0x8907BC(v50, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0024:\n\tgoto L_0029;\n\tv59 = v54;\n\tv60 = 0x8907BC(v59, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0029:\n\tv64 = v62.configAttribute == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_00CA;\n\tgoto L_003C;\n\tv104 = v66;\n\tv105 = 0x8907BC(v104, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_003C:\n\tgoto L_0044;\n\tv123 = *([v109 @ X0_v13+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_0044;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v109, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0044:\n\tv132 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_0057;\n\tv151 = *([v147 @ X8_v16+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tif (v153) goto L_0057;\n\tv161 = v147;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v161, v131, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0057:\n\tv160 = Sirenix.Utilities.TypeExtensions::GetCustomAttribute(v132);\n\tgoto L_0067;\n\tv168 = v162;\n\tv169 = Sirenix.Utilities.TypeExtensions::GetCustomAttribute(v168, v80);\nL_0067:\n\tgoto L_006B;\n\tv176 = v75;\n\tv177 = Sirenix.Utilities.TypeExtensions::GetCustomAttribute(v176, v80);\nL_006B:\n\tv179.configAttribute = v160;\n\tgoto L_007A;\n\tv185 = v180;\n\tv186 = Sirenix.Utilities.TypeExtensions::GetCustomAttribute(v185, v80);\nL_007A:\n\tgoto L_007F;\n\tv193 = v98;\n\tv194 = Sirenix.Utilities.TypeExtensions::GetCustomAttribute(v193, v80);\nL_007F:\n\tv196 = v195.configAttribute == 0;\n\tv92 = ~v196;\n\tif (v92) goto L_00CA;\n\tgoto L_0090;\n\tv202 = v197;\n\tv203 = Sirenix.Utilities.TypeExtensions::GetCustomAttribute(v202, v80);\nL_0090:\n\tgoto L_0098;\n\tv211 = *([v205 @ X0_v25+E0]);\n\tv212 = v211 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_0098;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v205, v80, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0098:\n\tv220 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_00A7;\n\tv226 = *([v221 @ X8_v31+E0]);\n\tv227 = v226 == 0;\n\tv228 = ~v227;\n\tif (v228) goto L_00A7;\n\tv235 = v221;\n\tv230 = \"il2cpp_codegen_runtime_class_init\"(v235, v219, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00A7:\n\tv234 = Sirenix.Utilities.TypeExtensions::GetNiceName(v220);\n\tv241 = new Sirenix.Utilities.GlobalConfigAttribute();\n\tSirenix.Utilities.GlobalConfigAttribute::.ctor(v241, v234);\n\tgoto L_00C0;\n\tv247 = v242;\n\tv248 = 0x8907BC(v247, v79, v72, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00C0:\n\tgoto L_00C4;\n\tv254 = v74;\n\tv255 = 0x8907BC(v254, v79, v72, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00C4:\n\tv94.configAttribute = v241;\nL_00CA:\n\tgoto L_00D3;\n\tv114 = v99;\n\tv115 = 0x8907BC(v114, v78, v71, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00D3:\n\tgoto L_00E0;\n\tv133 = v118;\n\tv134 = 0x8907BC(v133, v78, v71, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00E0:\n\treturn v136.configAttribute;\n// 142 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (configAttribute == null)
				{
					Type typeFromHandle = typeof(T);
					GlobalConfigAttribute customAttribute = typeFromHandle.GetCustomAttribute<GlobalConfigAttribute>();
					configAttribute = customAttribute;
					if (configAttribute == null)
					{
						Type typeFromHandle2 = typeof(T);
						string niceName = typeFromHandle2.GetNiceName();
						GlobalConfigAttribute globalConfigAttribute = new GlobalConfigAttribute(niceName);
						configAttribute = globalConfigAttribute;
					}
				}
				return configAttribute;
			}
		}

		[Token(Token = "0x17000002")]
		public static bool HasInstanceLoaded
		{
			[Token(Token = "0x600000E")]
			[Address(RVA = "0x11E7308", Offset = "0x11E7308", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF8760]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2027C08]) = v38;\nL_0018:\n\tgoto L_001C;\n\tv44 = v39;\n\tv45 = 0x8907BC(v44, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001C:\n\tv48 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>;\n\tgoto L_0027;\n\tv53 = v48;\n\tv54 = 0x8907BC(v53, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tv59 = *([v48 @ X19_v3 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]);\n\tgoto L_003A;\n\tv64 = *([v58 @ X0_v4+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_003A;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v58, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003A:\n\treturnVal1 = UnityEngine.Object::op_Inequality(*([v59 @ X8_v8 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]), 0);\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0037: Expected O, but got I
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X19_v3 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]");
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X8_v8 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]");
				return (UnityEngine.Object)0 != null;
			}
		}

		[Token(Token = "0x17000003")]
		public static T Instance
		{
			[Token(Token = "0x600000F")]
			[Address(RVA = "0x11E73A8", Offset = "0x11E73A8", Length = "0x384")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EDFC48]);\n\tv23 = *([v22 @ X8_v58]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2027C09]) = v42;\nL_001A:\n\tgoto L_001E;\n\tv48 = v43;\n\tv49 = 0x8907BC(v48, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_001E:\n\tv52 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>;\n\tgoto L_0028;\n\tv57 = v52;\n\tv58 = 0x8907BC(v57, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0028:\n\tv62 = *([v52 @ X20_v3 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]);\n\tgoto L_0037;\n\tv68 = *([v63 @ X0_v4+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0037;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v63, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0037:\n\tv78 = UnityEngine.Object::op_Equality(*([v62 @ X8_v6 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]), 0);\n\tv80 = v78 == 0;\n\tif (v80) goto L_0126;\n\tv81 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1>;\n\tgoto L_0049;\n\tv116 = v81;\n\tv117 = 0x8907BC(v116, v76, v77, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv122 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1>;\n\tv120 = *([v122 @ X20_v25 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]);\nL_0049:\n\tv126 = *([v81 @ X21_v3 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]) & 1;\n\tv127 = v126 == 0;\n\tv128 = ~v127;\n\tif (v128) goto L_0051;\n\tv139 = 0x8907BC(Il2CppClass<Sirenix.Utilities.GlobalConfig`1>, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0051:\n\tv143 = Sirenix.Utilities.GlobalConfig`1<T>::get_ConfigAttribute();\n\tgoto L_005E;\n\tv182 = v156;\n\tv183 = 0x8907BC(v182, v76, v77, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005E:\n\tv186 = ~v143.<UseAsset>k__BackingField;\n\tif (v186) goto L_00C4;\n\tgoto L_006C;\n\tv204 = v190;\n\tv205 = 0x8907BC(v204, v76, v77, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_006C:\n\tv209 = Sirenix.Utilities.GlobalConfig`1<T>::LoadInstanceIfAssetExists();\n\tgoto L_0076;\n\tv227 = v210;\n\tv228 = 0x8907BC(v227, v76, v77, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0076:\n\tv231 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>;\n\tgoto L_007F;\n\tv245 = v231;\n\tv246 = 0x8907BC(v245, v76, v77, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_007F:\n\tv249 = *([v231 @ X20_v18 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]);\n\tv110 = *([v249 @ X8_v42 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]);\n\tgoto L_008D;\n\tv263 = *([v248 @ X0_v61+E0]);\n\tv264 = v263 == 0;\n\tv265 = ~v264;\n\tif (v265) goto L_008D;\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v248, v76, v77, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_008D:\n\tv271 = UnityEngine.Object::op_Equality(*([v249 @ X8_v42 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]), 0);\n\tv282 = v271 == 0;\n\tif (v282) goto L_00AE;\n\tv292 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1>;\n\tgoto L_009F;\n\tv324 = v292;\n\tv325 = 0x8907BC(v324, v95, v92, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv330 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1>;\n\tv328 = *([v330 @ X20_v24 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]);\nL_009F:\n\tv332 = *([v292 @ X21_v17 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]) & 1;\n\tv333 = v332 == 0;\n\tv304 = ~v333;\n\tif (v304) goto L_00A7;\n\tv352 = 0x8907BC(Il2CppClass<Sirenix.Utilities.GlobalConfig`1>, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00A7:\n\tv302 = UnityEngine.ScriptableObject::CreateInstance();\nL_00AE:\n\tgoto L_00B2;\n\tv334 = v308;\n\tv335 = 0x8907BC(v334, v95, v92, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00B2:\n\tv89 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>;\n\tgoto L_00BA;\n\tv355 = v89;\n\tv356 = 0x8907BC(v355, v95, v92, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00BA:\n\tv107 = *([v89 @ X21_v16 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]);\n\t*([v107 @ X8_v48 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]) = v110;\n\tgoto L_0126;\nL_00C4:\n\tgoto L_00C9;\n\tv215 = v197;\n\tv216 = 0x8907BC(v215, v76, v77, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00C9:\n\tv220 = UnityEngine.ScriptableObject::CreateInstance();\n\tgoto L_00D4;\n\tv236 = v221;\n\tv237 = 0x8907BC(v236, v76, v77, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00D4:\n\tv240 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>;\n\tgoto L_00DC;\n\tv254 = v240;\n\tv255 = 0x8907BC(v254, v76, v77, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00DC:\n\tv257 = *([v240 @ X21_v9 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]);\n\t*([v257 @ X8_v24 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]) = v220;\n\tgoto L_00E7;\n\tv272 = v258;\n\tv273 = 0x8907BC(v272, v76, v77, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00E7:\n\tv276 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>;\n\tgoto L_00F0;\n\tv283 = v276;\n\tv284 = 0x8907BC(v283, v76, v77, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00F0:\n\tv287 = *([v276 @ X20_v14 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]);\n\tgoto L_0101;\n\tv313 = v286;\n\tv314 = 0x8907BC(v313, v76, v77, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0101:\n\tgoto L_0109;\n\tv341 = *([v318 @ X0_v33+E0]);\n\tv342 = v341 == 0;\n\tv343 = ~v342;\n\tif (v343) goto L_0109;\n\tv345 = \"il2cpp_codegen_runtime_class_init\"(v318, v76, v77, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0109:\n\tv350 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_011A;\n\tv362 = *([v106 @ X8_v35+E0]);\n\tv363 = v362 == 0;\n\tv364 = ~v363;\n\tif (v364) goto L_011A;\n\tv370 = v106;\n\tv366 = \"il2cpp_codegen_runtime_class_init\"(v370, v349, v77, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_011A:\n\tv188 = Sirenix.Utilities.TypeExtensions::GetNiceName(v350);\n\tUnityEngine.Object::set_name(*([v287 @ X8_v28 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]), v188);\nL_0126:\n\tgoto L_012A;\n\tv129 = v111;\n\tv130 = 0x8907BC(v129, v93, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_012A:\n\tv133 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>;\n\tgoto L_0132;\n\tv145 = v133;\n\tv146 = 0x8907BC(v145, v93, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0132:\n\tv148 = *([v133 @ X19_v3 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]);\n\treturn *([v148 @ X8_v12 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]);\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 184 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0037: Expected O, but got I
				//IL_0233: Expected O, but got I
				//IL_00dd: Expected O, but got I
				//IL_00f4: Expected O, but got I
				//IL_0201: Expected O, but got I
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X20_v3 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]");
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v6 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]");
				if ((UnityEngine.Object)0 == null)
				{
					IntPtr intPtr3 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X21_v3 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]");
					if (0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
					}
					GlobalConfigAttribute globalConfigAttribute = ConfigAttribute;
					if (globalConfigAttribute.UseAsset)
					{
						LoadInstanceIfAssetExists();
						IntPtr intPtr4 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X20_v18 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]");
						IntPtr intPtr5 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ X8_v42 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]");
						UnityEngine.Object obj = (UnityEngine.Object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ X8_v42 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]");
						if ((UnityEngine.Object)0 == null)
						{
							IntPtr intPtr6 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ X21_v17 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]");
							if (0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
							}
							T val = ScriptableObject.CreateInstance<T>();
							obj = val;
						}
						IntPtr intPtr7 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X21_v16 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]");
						IntPtr intPtr8 = (IntPtr)0;
					}
					else
					{
						T val2 = ScriptableObject.CreateInstance<T>();
						IntPtr intPtr9 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ X21_v9 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]");
						IntPtr intPtr10 = (IntPtr)0;
						IntPtr intPtr11 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ X20_v14 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]");
						IntPtr intPtr12 = (IntPtr)0;
						Type typeFromHandle = typeof(T);
						string niceName = typeFromHandle.GetNiceName();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ X8_v28 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]");
						((UnityEngine.Object)0).name = niceName;
					}
				}
				IntPtr intPtr13 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ X19_v3 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]");
				IntPtr intPtr14 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ X8_v12 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]");
				return (T)0;
			}
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x11E772C", Offset = "0x11E772C", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EAB778]);\n\tv23 = *([v22 @ X8_v32]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2027C0A]) = v42;\nL_0015:\n\tv43 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1>;\n\tgoto L_0023;\n\tv49 = v43;\n\tv50 = 0x8907BC(v49, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv55 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1>;\n\tv53 = *([v55 @ X20_v15 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]);\nL_0023:\n\tv59 = *([v43 @ X21_v1 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]) & 1;\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_002B;\n\tv63 = 0x8907BC(Il2CppClass<Sirenix.Utilities.GlobalConfig`1>, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002B:\n\tv67 = Sirenix.Utilities.GlobalConfig`1<T>::get_ConfigAttribute();\n\tv70 = Sirenix.Utilities.GlobalConfigAttribute::get_IsInResourcesFolder(v67);\n\tv89 = v70 == 0;\n\tif (v89) goto L_00B0;\n\tgoto L_0043;\n\tv133 = v90;\n\tv134 = 0x8907BC(v133, v69, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0043:\n\tgoto L_004B;\n\tv144 = *([v138 @ X0_v11+E0]);\n\tv145 = v144 == 0;\n\tv146 = ~v145;\n\tif (v146) goto L_004B;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v138, v69, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004B:\n\tv153 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_005C;\n\tv161 = *([v157 @ X8_v15+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_005C;\n\tv170 = v157;\n\tv166 = \"il2cpp_codegen_runtime_class_init\"(v170, v152, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005C:\n\tv169 = Sirenix.Utilities.TypeExtensions::GetNiceName(v153);\n\tv171 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1>;\n\tgoto L_006C;\n\tv177 = v171;\n\tv178 = 0x8907BC(v177, v78, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv179 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1>;\n\tv182 = *([v179 @ X21_v11 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]);\nL_006C:\n\tv184 = *([v171 @ X22_v4 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]) & 1;\n\tv185 = v184 == 0;\n\tv186 = ~v185;\n\tif (v186) goto L_0074;\n\tv188 = 0x8907BC(Il2CppClass<Sirenix.Utilities.GlobalConfig`1>, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0074:\n\tv80 = Sirenix.Utilities.GlobalConfig`1<T>::get_ConfigAttribute();\n\tv192 = Sirenix.Utilities.GlobalConfigAttribute::get_ResourcesPath(v80);\n\tv194 = System.String::Concat(v192, v169);\n\tv195 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1>;\n\tgoto L_008B;\n\tv202 = v195;\n\tv203 = 0x8907BC(v202, v193, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv204 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1>;\n\tv207 = *([v204 @ X21_v10 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]);\nL_008B:\n\tv209 = *([v195 @ X22_v6 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]) & 1;\n\tv210 = v209 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_0094;\n\tv213 = 0x8907BC(Il2CppClass<Sirenix.Utilities.GlobalConfig`1>, v169, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0094:\n\tv217 = UnityEngine.Resources::Load(v194);\n\tgoto L_009F;\n\tv223 = v218;\n\tv224 = UnityEngine.Resources::Load(v223, v104);\nL_009F:\n\tv114 = Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>;\n\tgoto L_00A7;\n\tv230 = v114;\n\tv231 = UnityEngine.Resources::Load(v230, v104);\nL_00A7:\n\tv112 = *([v114 @ X20_v13 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]);\n\t*([v112 @ X8_v25 (Il2CppStaticFields<Sirenix.Utilities.GlobalConfig`1<T>>)+8]) = v217;\nL_00B0:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LoadInstanceIfAssetExists()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X21_v1 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]");
			if (0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
			}
			GlobalConfigAttribute globalConfigAttribute = ConfigAttribute;
			if (globalConfigAttribute.IsInResourcesFolder)
			{
				Type typeFromHandle = typeof(T);
				string niceName = typeFromHandle.GetNiceName();
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X22_v4 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]");
				if (0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
				}
				GlobalConfigAttribute globalConfigAttribute2 = ConfigAttribute;
				string resourcesPath = globalConfigAttribute2.ResourcesPath;
				string path = resourcesPath + niceName;
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ X22_v6 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1>)+12E]");
				if (0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
				}
				T val = Resources.Load<T>(path);
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X20_v13 (Il2CppClass<Sirenix.Utilities.GlobalConfig`1<T>>)+B8]");
				IntPtr intPtr5 = (IntPtr)0;
			}
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x11E792C", Offset = "0x11E792C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF8A80]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2027C0B]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tUnityEngine.Debug::Log(\"Downloading, installing and launching the Unity Editor so we can open this config window in the editor, please stand by until pigs can fly and hell has frozen over...\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OpenInEditor()
		{
			Debug.Log("Downloading, installing and launching the Unity Editor so we can open this config window in the editor, please stand by until pigs can fly and hell has frozen over...");
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x11E7998", Offset = "0x11E7998", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void OnConfigAutoCreated()
		{
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x11E799C", Offset = "0x11E799C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GlobalConfig()
		{
		}
	}
}
