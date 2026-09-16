using System;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Tayx.Graphy.Utils
{
	[Token(Token = "0x2000030")]
	public class G_Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		[Token(Token = "0x400014F")]
		private static T _instance;

		[Token(Token = "0x4000150")]
		private static object _lock;

		[Token(Token = "0x4000151")]
		private static bool _applicationIsQuitting;

		[Token(Token = "0x17000033")]
		public unsafe static T Instance
		{
			[Token(Token = "0x600015A")]
			[Address(RVA = "0x11CEC34", Offset = "0x11CEC34", Length = "0xAB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-10_v2;\n\tgoto L_001A;\n\tv32 = *([1EEF280]);\n\tv33 = *([v32 @ X8_v189]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2027B90]) = v52;\nL_001A:\n\tv53 = &v54 @ stack_-70;\n\t*([v22 @ X29_v1-44]) = 0;\n\tgoto L_0026;\n\tv61 = v56;\n\tv62 = 0x8907BC(v61, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0026:\n\tv65 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_002F;\n\tv70 = v65;\n\tv71 = 0x8907BC(v70, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv74 = *([v65 @ X19_v3 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]);\nL_002F:\n\tv75 = *([v65 @ X19_v3 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]) & 0x200;\n\tv76 = v75 == 0;\n\tif (v76) goto L_005F;\n\tgoto L_003B;\n\tv99 = v77;\n\tv100 = 0x8907BC(v99, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_003B:\n\tv93 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_0044;\n\tv116 = v93;\n\tv117 = 0x8907BC(v116, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0044:\n\tv118 = *([v93 @ X19_v21 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]) == 0;\n\tv87 = ~v118;\n\tif (v87) goto L_005F;\n\tgoto L_0055;\n\tv136 = v125;\n\tv137 = 0x8907BC(v136, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0055:\n\tgoto L_005F;\n\tv230 = v92;\n\tv231 = 0x8907BC(v230, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_005F:\n\tgoto L_0063;\n\tv107 = v94;\n\tv108 = 0x8907BC(v107, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0063:\n\tv111 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_006B;\n\tv119 = v111;\n\tv120 = 0x8907BC(v119, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_006B:\n\tv122 = *([v111 @ X19_v6 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+B8]);\n\tv124 = *([v122 @ X8_v11 (Il2CppStaticFields<Tayx.Graphy.Utils.G_Singleton`1<T>>)+10]) == 0;\n\tif (v124) goto L_0084;\nL_007E:\n\treturn v194;\nL_0084:\n\tgoto L_0088;\n\tv221 = v131;\n\tv222 = 0x8907BC(v221, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0088:\n\tv225 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_0091;\n\tv281 = v225;\n\tv282 = 0x8907BC(v281, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv285 = *([v225 @ X19_v10 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]);\nL_0091:\n\tv286 = *([v225 @ X19_v10 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]) & 0x200;\n\tv287 = v286 == 0;\n\tif (v287) goto L_00C1;\n\tgoto L_009D;\n\tv310 = v288;\n\tv311 = 0x8907BC(v310, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_009D:\n\tv304 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_00A6;\n\tv327 = v304;\n\tv328 = 0x8907BC(v327, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00A6:\n\tv329 = *([v304 @ X19_v16 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]) == 0;\n\tv298 = ~v329;\n\tif (v298) goto L_00C1;\n\tgoto L_00B7;\n\tv347 = v337;\n\tv348 = 0x8907BC(v347, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00B7:\n\tgoto L_00C1;\n\tv362 = v303;\n\tv363 = 0x8907BC(v362, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00C1:\n\tgoto L_00C5;\n\tv318 = v305;\n\tv319 = 0x8907BC(v318, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00C5:\n\tv322 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_00CD;\n\tv330 = v322;\n\tv331 = 0x8907BC(v330, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00CD:\n\tv333 = *([v322 @ X19_v13 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+B8]);\n\t*([v22 @ X29_v1-44]) = 0;\n\tv334 = &v23 @ stack_-10_v2 - 0x44;\n\tSystem.Threading.Monitor::Enter(*([v333 @ X8_v22 (Il2CppStaticFields<Tayx.Graphy.Utils.G_Singleton`1<T>>)+8]), v334);\n\tgoto L_00DD;\n\tv353 = v342;\n\tv354 = 0x8907BC(v353, v334, v336, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00DD:\n\tv357 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_00E6;\n\tv366 = v357;\n\tv367 = 0x8907BC(v366, v334, v336, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv370 = *([v357 @ X21_v4 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]);\nL_00E6:\n\tv371 = *([v357 @ X21_v4 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]) & 0x200;\n\tv372 = v371 == 0;\n\tif (v372) goto L_0116;\n\tgoto L_00F2;\n\tv395 = v373;\n\tv396 = 0x8907BC(v395, v334, v336, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00F2:\n\tv380 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_00FB;\n\tv412 = v380;\n\tv413 = 0x8907BC(v412, v334, v336, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00FB:\n\tv414 = *([v380 @ X21_v59 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]) == 0;\n\tv386 = ~v414;\n\tif (v386) goto L_0116;\n\tgoto L_010C;\n\tv441 = v425;\n\tv442 = 0x8907BC(v441, v334, v336, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_010C:\n\tgoto L_0116;\n\tv449 = v379;\n\tv450 = 0x8907BC(v449, v334, v336, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0116:\n\tgoto L_011F;\n\tv403 = v390;\n\tv404 = 0x8907BC(v403, v334, v336, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_011F:\n\tgoto L_012A;\n\tv415 = v407;\n\tv416 = 0x8907BC(v415, v334, v336, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_012A:\n\tgoto L_0133;\n\tv430 = *([v420 @ X0_v20+E0]);\n\tv431 = v430 == 0;\n\tv432 = ~v431;\n\tif (v432) goto L_0133;\n\tv434 = \"il2cpp_codegen_runtime_class_init\"(v420, v334, v336, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0133:\n\tv440 = UnityEngine.Object::op_Equality(v419._instance, 0);\n\tv448 = v440 == 0;\n\tif (v448) goto L_02FB;\n\tgoto L_0147;\n\tv519 = v453;\n\tv520 = 0x8907BC(v519, v438, v439, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0147:\n\tgoto L_014F;\n\tv538 = *([v524 @ X0_v96+E0]);\n\tv539 = v538 == 0;\n\tv540 = ~v539;\n\tif (v540) goto L_014F;\n\tv542 = \"il2cpp_codegen_runtime_class_init\"(v524, v438, v439, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_014F:\n\tv547 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_015D;\n\tv582 = *([v556 @ X0_v100+E0]);\n\tv583 = v582 == 0;\n\tv584 = ~v583;\n\tif (v584) goto L_015D;\n\tv586 = \"il2cpp_codegen_runtime_class_init\"(v556, v546, v439, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_015D:\n\tv591 = UnityEngine.Object::FindObjectOfType(v547);\n\tgoto L_0168;\n\tv654 = v610;\n\tv655 = 0x8907BC(v654, v590, v439, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0168:\n\tv658 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_0171;\n\tv681 = v658;\n\tv682 = 0x8907BC(v681, v590, v439, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv685 = *([v658 @ X22_v21 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]);\nL_0171:\n\tv686 = *([v658 @ X22_v21 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]) & 0x200;\n\tv687 = v686 == 0;\n\tif (v687) goto L_01A1;\n\tgoto L_017D;\n\tv723 = v697;\n\tv724 = 0x8907BC(v723, v590, v439, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_017D:\n\tv704 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_0186;\n\tv755 = v704;\n\tv756 = 0x8907BC(v755, v590, v439, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0186:\n\tv757 = *([v704 @ X22_v38 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]) == 0;\n\tv710 = ~v757;\n\tif (v710) goto L_01A1;\n\tgoto L_0197;\n\tv832 = v791;\n\tv833 = 0x8907BC(v832, v590, v439, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0197:\n\tgoto L_01A1;\n\tv869 = v703;\n\tv870 = 0x8907BC(v869, v590, v439, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_01A1:\n\tgoto L_01AA;\n\tv731 = v714;\n\tv732 = 0x8907BC(v731, v590, v439, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_01AA:\n\tgoto L_01B3;\n\tv758 = v735;\n\tv759 = 0x8907BC(v758, v590, v439, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v4\n// ... truncated")]
			get
			{
				//IL_0155: Expected O, but got I
				//IL_07cc: Expected O, but got I4
				//IL_07eb: Expected O, but got I
				//IL_04b2: Expected O, but got I4
				//IL_04de: Expected O, but got I4
				//IL_0a6b: Expected O, but got I
				//IL_0578: Expected O, but got I4
				//IL_05f4: Expected O, but got I4
				//IL_0620: Expected O, but got I4
				//IL_0ac9: Expected O, but got I
				//IL_06ba: Expected O, but got I4
				object obj2 = default(object);
				object obj = obj2;
				object obj4 = default(object);
				object obj3 = obj4;
				_ = 0;
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X19_v3 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ X19_v21 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X19_v6 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+B8]");
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X8_v11 (Il2CppStaticFields<Tayx.Graphy.Utils.G_Singleton`1<T>>)+10]");
				T result;
				if ((IntPtr)0 != (IntPtr)0)
				{
					result = null;
					goto IL_0b64;
				}
				IntPtr intPtr5 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ X19_v10 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr6 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ X19_v16 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr7 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ X19_v13 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+B8]");
				IntPtr intPtr8 = (IntPtr)0;
				_ = 0;
				ref bool lockTaken = ref *(bool*)((long)(IntPtr)obj2 - 68L);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ X8_v22 (Il2CppStaticFields<Tayx.Graphy.Utils.G_Singleton`1<T>>)+8]");
				Monitor.Enter(0, ref lockTaken);
				IntPtr intPtr9 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ X21_v4 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr10 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ X21_v59 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				if (_instance == null)
				{
					Type typeFromHandle = typeof(T);
					UnityEngine.Object obj5 = UnityEngine.Object.FindObjectOfType(typeFromHandle);
					IntPtr intPtr11 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v658 @ X22_v21 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr12 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v704 @ X22_v38 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					T val;
					if ((object)obj5 != null)
					{
						val = obj5 as T;
						if ((object)val == null)
						{
							throw new InvalidCastException();
						}
					}
					else
					{
						val = null;
					}
					_instance = val;
					Type typeFromHandle2 = typeof(T);
					UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeFromHandle2);
					if (array.Length >= 2)
					{
						IntPtr intPtr13 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1040 @ X21_v40 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]");
						if (0u != 0)
						{
							IntPtr intPtr14 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ X21_v44 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]");
							if ((IntPtr)0 != (IntPtr)0)
							{
							}
						}
						goto IL_07ba;
					}
					IntPtr intPtr15 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ X21_v47 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr16 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1095 @ X21_v55 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					if (_instance == null)
					{
						object[] array2 = new object[5];
						if ("[Singleton] An instance of " != null)
						{
							object obj6 = "[Singleton] An instance of " as object;
							if (obj6 == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						if (array2.Length == 0)
						{
							IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
							throw ex2;
						}
						array2[0] = "[Singleton] An instance of ";
						Type typeFromHandle3 = typeof(T);
						if ((object)typeFromHandle3 != null)
						{
							object obj7 = typeFromHandle3 as object;
							if (obj7 == null)
							{
								ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
								throw ex3;
							}
						}
						object obj8 = array2.Length;
						bool flag = array2.Length < 1;
						bool flag2 = !flag;
						object obj9 = array2.Length - 1;
						bool flag3 = obj9 == null;
						bool flag4 = !flag2;
						if (flag4 || flag3)
						{
							IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
							throw ex4;
						}
						array2[1] = typeFromHandle3;
						if (" is trying to be accessed, but it wasn't initialized first. Make sure to add an instance of " != null)
						{
							object obj10 = " is trying to be accessed, but it wasn't initialized first. Make sure to add an instance of " as object;
							if (obj10 == null)
							{
								ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
								throw ex5;
							}
							obj8 = array2.Length;
						}
						bool flag5 = (long)(IntPtr)obj8 < 2L;
						bool flag6 = !flag5;
						object obj11 = (long)(IntPtr)obj8 - 2L;
						bool flag7 = obj11 == null;
						bool flag8 = !flag6;
						if (flag8 || flag7)
						{
							IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
							throw ex6;
						}
						array2[2] = " is trying to be accessed, but it wasn't initialized first. Make sure to add an instance of ";
						Type typeFromHandle4 = typeof(T);
						if ((object)typeFromHandle4 != null)
						{
							object obj12 = typeFromHandle4 as object;
							if (obj12 == null)
							{
								ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
								throw ex7;
							}
						}
						object obj13 = array2.Length;
						bool flag9 = array2.Length < 3;
						bool flag10 = !flag9;
						object obj14 = array2.Length - 3;
						bool flag11 = obj14 == null;
						bool flag12 = !flag10;
						if (flag12 || flag11)
						{
							IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
							throw ex8;
						}
						array2[3] = typeFromHandle4;
						if (" in the scene before  trying to access it." != null)
						{
							object obj15 = " in the scene before  trying to access it." as object;
							if (obj15 == null)
							{
								ArrayTypeMismatchException ex9 = new ArrayTypeMismatchException();
								throw ex9;
							}
							obj13 = array2.Length;
						}
						bool flag13 = (long)(IntPtr)obj13 < 4L;
						bool flag14 = !flag13;
						object obj16 = (long)(IntPtr)obj13 - 4L;
						bool flag15 = obj16 == null;
						bool flag16 = !flag14;
						if (flag16 || flag15)
						{
							IndexOutOfRangeException ex10 = new IndexOutOfRangeException();
							throw ex10;
						}
						array2[4] = " in the scene before  trying to access it.";
						string message = string.Concat(array2);
						Debug.Log(message);
					}
				}
				IntPtr intPtr17 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ X21_v27 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr18 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v567 @ X21_v31 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				goto IL_07ba;
				IL_0882:
				TypeLoadException ex11 = new TypeLoadException();
				throw new NullReferenceException();
				IL_0b64:
				return result;
				IL_07ba:
				result = _instance;
				obj3 = 209;
				int num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-44]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ X8_v22 (Il2CppStaticFields<Tayx.Graphy.Utils.G_Singleton`1<T>>)+8]");
					Monitor.Exit(0);
				}
				if (true)
				{
					if (false)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X24_v1+v182 @ X22_v3 (System.Int32)*4]");
						if ((IntPtr)0 != (IntPtr)209)
						{
							goto IL_0882;
						}
					}
				}
				else if (false)
				{
					goto IL_0882;
				}
				goto IL_0b64;
			}
		}

		[Token(Token = "0x600015B")]
		[Address(RVA = "0x11CF6E4", Offset = "0x11CF6E4", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1F10C50]);\n\tv25 = *([v24 @ X8_v45]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2027B91]) = v43;\nL_0018:\n\tv46 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_0021;\n\tv51 = v46;\n\tv52 = 0x8907BC(v51, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv55 = *([v46 @ X21_v2 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]);\nL_0021:\n\tv56 = *([v46 @ X21_v2 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]) & 0x200;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0045;\n\tv60 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_002F;\n\tv83 = v60;\n\tv84 = 0x8907BC(v83, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_002F:\n\tv85 = *([v60 @ X21_v13 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]) == 0;\n\tv70 = ~v85;\n\tif (v70) goto L_0045;\n\tgoto L_0045;\n\tv112 = v75;\n\tv113 = 0x8907BC(v112, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0045:\n\tgoto L_0050;\n\tv86 = v78;\n\tv87 = 0x8907BC(v86, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0050:\n\tgoto L_0059;\n\tv101 = *([v92 @ X0_v5+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_0059;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v92, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0059:\n\tv111 = UnityEngine.Object::op_Inequality(v91._instance, 0);\n\tv118 = v111 == 0;\n\tif (v118) goto L_007E;\n\tv123 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0077;\n\tv180 = *([v138 @ X8_v33+E0]);\n\tv181 = v180 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_0077;\n\tv209 = v138;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v209, v122, v110, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0077:\n\tUnityEngine.Object::Destroy(v123);\n\treturn;\nL_007E:\n\tv129 = UnityEngine.Component::GetComponent(this);\n\tv133 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_008B;\n\tv143 = v133;\n\tv144 = UnityEngine.Component::GetComponent(v143, v127);\n\tv147 = *([v133 @ X21_v6 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]);\nL_008B:\n\tv148 = *([v133 @ X21_v6 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]) & 0x200;\n\tv149 = v148 == 0;\n\tif (v149) goto L_00AF;\n\tv187 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_0099;\n\tv210 = v187;\n\tv211 = UnityEngine.Component::GetComponent(v210, v127);\nL_0099:\n\tv212 = *([v187 @ X21_v9 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]) == 0;\n\tv197 = ~v212;\n\tif (v197) goto L_00AF;\n\tgoto L_00AF;\n\tv219 = v202;\n\tv220 = UnityEngine.Component::GetComponent(v219, v127);\nL_00AF:\n\tgoto L_00B3;\n\tv213 = v205;\n\tv214 = UnityEngine.Component::GetComponent(v213, v127);\nL_00B3:\n\tv173._instance = v129;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X21_v2 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X21_v13 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			if (_instance != null)
			{
				GameObject obj = base.gameObject;
				UnityEngine.Object.Destroy(obj);
				return;
			}
			T component = GetComponent<T>();
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ X21_v6 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ X21_v9 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			_instance = component;
		}

		[Token(Token = "0x600015C")]
		[Address(RVA = "0x11CF8F0", Offset = "0x11CF8F0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_0012;\n\tv19 = v14;\n\tv20 = 0x8907BC(v19, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = *([v14 @ X20_v1 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]);\nL_0012:\n\tv39 = *([v14 @ X20_v1 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]) & 0x200;\n\tv40 = v39 == 0;\n\tif (v40) goto L_0031;\n\tv43 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_0020;\n\tv66 = v43;\n\tv67 = 0x8907BC(v66, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv68 = *([v43 @ X20_v4 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]) == 0;\n\tv53 = ~v68;\n\tif (v53) goto L_0031;\n\tgoto L_0031;\n\tv82 = v55;\n\tv83 = 0x8907BC(v82, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0031:\n\tv61 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_0039;\n\tv69 = v61;\n\tv70 = 0x8907BC(v69, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0039:\n\tv72 = *([v61 @ X19_v2 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+B8]);\n\t*([v72 @ X8_v9 (Il2CppStaticFields<Tayx.Graphy.Utils.G_Singleton`1<T>>)+10]) = 1;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X20_v1 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X20_v4 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X19_v2 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+B8]");
			IntPtr intPtr4 = (IntPtr)0;
			_ = 1;
		}

		[Token(Token = "0x600015D")]
		[Address(RVA = "0x11CF9A0", Offset = "0x11CF9A0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_Singleton()
		{
		}

		[Token(Token = "0x600015E")]
		[Address(RVA = "0x11CF9B8", Offset = "0x11CF9B8", Length = "0x14E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EE9CC0]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2027B92]) = v40;\nL_0017:\n\tv44 = new System.Object();\n\tSystem.Object::.ctor(v44);\n\tgoto L_0024;\n\tv52 = v47;\n\tv53 = 0x8907BC(v52, v45, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv56 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_002C;\n\tv61 = v56;\n\tv62 = 0x8907BC(v61, v45, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002C:\n\tv64 = *([v56 @ X21_v2 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+B8]);\n\t*([v64 @ X8_v8 (Il2CppStaticFields<Tayx.Graphy.Utils.G_Singleton`1<T>>)+8]) = v44;\n\tgoto L_0037;\n\tv70 = v65;\n\tv71 = 0x8907BC(v70, v45, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0037:\n\tv74 = Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>;\n\tgoto L_003F;\n\tv79 = v74;\n\tv80 = 0x8907BC(v79, v45, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_003F:\n\tv82 = *([v74 @ X19_v3 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+B8]);\n\t*([v82 @ X8_v12 (Il2CppStaticFields<Tayx.Graphy.Utils.G_Singleton`1<T>>)+10]) = 0;\n\treturn;\n\tX8 = *([X1]);\n\tX9 = *([X1+8]);\n\tX10 = 0xFFFFFFFF;\n\t*([X0+10]) = X10;\n\t*([X0]) = X8;\n\t*([X0+8]) = X9;\n\treturn;\n\treturn;\n\tX8 = *([X0+10]);\n\tX9 = *([X0+8]);\n\tX10 = X8 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tX8 = TEMPCOND;\n\t*([X0+10]) = X10;\n\tX0 = X8;\n\treturn;\n\tX8 = 0xFFFFFFFF;\n\t*([X0+10]) = X8;\n\treturn;\n\tX8 = *([X0]);\n\tX9 = *([X0+10]);\n\tX0 = *([X8+X9*4]);\n\treturn;\n\t// 105 ShiftStack -48\n\tstack[0] = X21;\n\tstack[10] = X20;\n\tstack[18] = X19;\n\tstack[20] = X29;\n\tstack[28] = X30;\n\tX29 = &stack[20];\n\tX21 = X1;\n\tX19 = *([X21+18]);\n\tX20 = X0;\n\tX8 = *([X19+12E]);\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_007C;\n\tX0 = X19;\n\tX0 = 0x8907BC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X21+18]);\n\tX8 = *([X19+12E]);\nL_007C:\n\tX9 = *([X20]);\n\tX10 = *([X20+10]);\n\tX9 = *([X9+X10*4]);\n\tstack[C] = X9;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0086;\n\tX0 = X19;\n\tX0 = 0x8907BC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0086:\n\tX8 = *([X19+C0]);\n\tX19 = *([X8+18]);\n\tX8 = *([X19+12E]);\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_008F;\n\tX0 = X19;\n\tX0 = 0x8907BC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_008F:\n\tX1 = &stack[C];\n\tX0 = X19;\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 151 ShiftStack 48\n\treturn;\n\tX8 = *([X1]);\n\tX9 = *([X1+8]);\n\tX10 = 0xFFFFFFFF;\n\t*([X0+10]) = X10;\n\t*([X0]) = X8;\n\t*([X0+8]) = X9;\n\treturn;\n\treturn;\n\tX8 = *([X0+10]);\n\tX9 = *([X0+8]);\n\tX10 = X8 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tX8 = TEMPCOND;\n\t*([X0+10]) = X10;\n\tX0 = X8;\n\treturn;\n\tX8 = 0xFFFFFFFF;\n\t*([X0+10]) = X8;\n\treturn;\n\t// 182 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX9 = *([X0]);\n\tX10 = *([X0+10]);\n\tX11 = 0x58;\n\tX2 = 0x58;\n\tX0 = X8;\n\tTEMP = X10 * X11;\n\tX1 = X9 + TEMP;\n\tX0 = 0x6D2410(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[0];\n\tX30 = stack[8];\n\t// 196 ShiftStack 16\n\treturn;\n\t// 198 ShiftStack -144\n\tstack[60] = X22;\n\tstack[68] = X21;\n\tstack[70] = X20;\n\tstack[78] = X19;\n\tstack[80] = X29;\n\tstack[88] = X30;\n\tX29 = &stack[80];\n\tX21 = X1;\n\tX19 = *([X21+18]);\n\tX20 = X0;\n\tX22 = *([X19+12E]);\n\tTEMP = X22 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00DA;\n\tX0 = X19;\n\tX0 = 0x8907BC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X21+18]);\n\tX22 = *([X19+12E]);\nL_00DA:\n\tX8 = *([X20]);\n\tX9 = *([X20+10]);\n\tX10 = 0x58;\n\tX0 = &stack[8];\n\tX2 = 0x58;\n\tTEMP = X9 * X10;\n\tX1 = X8 + TEMP;\n\tX0 = 0x6D1DA0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X22 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00E8;\n\tX0 = X19;\n\tX0 = 0x8907BC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00E8:\n\tX8 = *([X19+C0]);\n\tX19 = *([X8+18]);\n\tX8 = *([X19+12E]);\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00F1;\n\tX0 = X19;\n\tX0 = 0x8907BC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00F1:\n\tX1 = &stack[8];\n\tX0 = X19;\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[80];\n\tX30 = stack[88];\n\tX20 = stack[70];\n\tX19 = stack[78];\n\tX22 = stack[60];\n\tX21 = stack[68];\n\t// 250 ShiftStack 144\n\treturn;\n\tX8 = *([X1]);\n\tX9 = *([X1+8]);\n\tX10 = 0xFFFFFFFF;\n\t*([X0+10]) = X10;\n\t*([X0]) = X8;\n\t*([X0+8]) = X9;\n\treturn;\n\treturn;\n\tX8 = *([X0+10]);\n\tX9 = *([X0+8]);\n\tX10 = X8 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tX8 = TEMPCOND;\n\t*([X0+10]) = X10;\n\tX0 = X8;\n\treturn;\n\tX8 = 0xFFFFFFFF;\n\t*([X0+10]) = X8;\n\treturn;\n\tX8 = *([X0]);\n\tX9 = *([X0+10]);\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tV0 = *([X8]);\n\tV1 = *([X8+4]);\n\tV2 = *([X8+8]);\n\tV3 = *([X8+C]);\n\treturn;\n\t// 290 ShiftStack -64\n\tstack[10] = X21;\n\tstack[20] = X20;\n\tstack[28] = X19;\n\tstack[30] = X29;\n\tstack[38] = X30;\n\tX29 = &stack[30];\n\tX21 = X1;\n\tX19 = *([X21+18]);\n\tX20 = X0;\n\tX8 = *([X19+12E]);\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0135;\n\tX0 = X19;\n\tX0 = 0x8907BC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X21+18]);\n\tX8 = *([X19+12E]);\nL_0135:\n\tX9 = *([X20]);\n\tX10 = *([X20+10]);\n\tV0 = *([X9+X10*16]);\n\tstack[0] = V0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_013F;\n\tX0 = X19;\n\tX0 = 0x8907BC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_013F:\n\tX8 = *([X19+C0]);\n\tX19 = *([X8+18]);\n\tX8 = *([X19+12E]);\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0148;\n\tX0 = X19;\n\tX0 = 0x8907BC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0148:\n\tX1 = &stack[0];\n\tX0 = X19;\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX21 = stack[10];\n\t// 336 ShiftStack 64\n\treturn;\n\tX8 = *([X1]);\n\tX9 = *([X1+8]);\n\tX10 = 0xFFFFFFFF;\n\t*([X0+10]) = X10;\n\t*([X0]) = X8;\n\t*([X0+8]) = X9;\n\treturn;\n\treturn;\n\tX8 = *([X0+10]);\n\tX9 = *([X0+8]);\n\tX10 = X8 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tX8 = TEMPCOND;\n\t*([X0+10]) = X10;\n\tX0 = X8;\n\treturn;\n\tX8 = 0xFFFFFFFF;\n\t*([X0+10]) = X8;\n\treturn;\n\tX8 = *([X0]);\n\tX9 = *([X0+10]);\n\tX10 = 0 | 0xC;\n\tTEMP = X9 * X10;\n\tX8 = X8 + TEMP;\n\tX0 = *([X8]);\n\tX1 = *([X8+8]);\n\treturn;\n\t// 375 ShiftStack -64\n\tstack[10] = X21;\n\tstack[20] = X20;\n\tstack[28] = X19;\n\tstack[30] = X29;\n\tstack[38] = X30;\n\tX29 = &stack[30];\n\tX21 = X1;\n\tX19 = *([X21+18]);\n\tX20 = X0;\n\tX8 = *([X19+12E]);\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_018A;\n\tX0 = X19;\n\tX0 = 0x8907BC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X21+18]);\n\tX8 = *([X19+12E]);\nL_018A:\n\tX9 = *([X20]);\n\tX10 = *([X20+10]);\n\tX11 = 0 | 0xC;\n\tTEMP = X10 * X11;\n\tX9 = X9 + TEMP;\n\tX10 = *([X9]);\n\tX9 = *([X9+8]);\n\tstack[0] = X10;\n\tstack[8] = X9;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0199;\n\tX0 = X19;\n\tX0 = 0x8907BC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0199:\n\tX8 = *([X19+C0]);\n\tX19 = *([X8+18]);\n\tX8 = *([X19+12E]);\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01A2;\n\tX0 = X19;\n\tX0 = 0x8907BC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01A2:\n\tX1 = &stack[0];\n\tX0 = X19;\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = \n// ... truncated")]
		static G_Singleton()
		{
			object obj = new object();
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X21_v2 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+B8]");
			IntPtr intPtr2 = (IntPtr)0;
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X19_v3 (Il2CppClass<Tayx.Graphy.Utils.G_Singleton`1<T>>)+B8]");
			IntPtr intPtr4 = (IntPtr)0;
			_ = 0;
		}
	}
}
