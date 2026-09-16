using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x2000079")]
	public class Vector3ArrayPlugin : ABSTweenPlugin<Vector3, Vector3[], Vector3ArrayOptions>
	{
		[Token(Token = "0x60002E8")]
		[Address(RVA = "0xC1E4C0", Offset = "0xC1E4C0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tt.startValue = 0;\n\tt.endValue = 0;\n\tt.changeValue = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			t.startValue = null;
			t.endValue = null;
			t.changeValue = null;
		}

		[Token(Token = "0x60002E9")]
		[Address(RVA = "0xC1E4DC", Offset = "0xC1E4DC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void SetFrom(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, bool isRelative)
		{
		}

		[Token(Token = "0x60002EA")]
		[Address(RVA = "0xC1E4E0", Offset = "0xC1E4E0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void SetFrom(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, Vector3[] fromValue, bool setImmediately, bool isRelative)
		{
		}

		[Token(Token = "0x60002EB")]
		[Address(RVA = "0xC1E4E4", Offset = "0xC1E4E4", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = UnityEngine.Vector3[];\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, t, methodInfo, v29, v30, v31, v32, v33, value, v0, v2, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35764]) = v42;\nL_001A:\n\tv44 = t.endValue;\n\t// 34 NewArr returnVal2 @ X0_v7 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v44.Length\n\tv162 = v44.Length < 1;\n\tif (v162) goto L_0073;\n\tv102 = v44.Length & 0xFFFFFFFF;\nL_0032:\n\tv233 = v110 == 0;\n\tif (v233) goto L_005C;\n\tv248 = t.endValue + v62;\n\tv237 = returnVal2 + v62;\n\t*([v237 @ X11_v9+C]) = *([v248 @ X11_v8]);\n\t*([v237 @ X11_v9+14]) = *([v248 @ X11_v8+8]);\n\tgoto L_005F;\nL_005C:\n\t*([returnVal2 @ X0_v7 (UnityEngine.Vector3[])+20]) = value;\n\t*([returnVal2 @ X0_v7 (UnityEngine.Vector3[])+24]) = value.y;\n\t*([returnVal2 @ X0_v7 (UnityEngine.Vector3[])+28]) = value.z;\nL_005F:\n\tv110 = v110 + 1;\n\tv62 = v62 + 0xC;\n\tv176 = v102 != v110;\n\tif (v176) goto L_0032;\nL_0073:\n\treturn returnVal2;\n\tv115 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Vector3[] ConvertToStartValue(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t, Vector3 value)
		{
			//IL_0059: Expected I4, but got I8
			//IL_0083: Expected O, but got I
			//IL_0091: Expected O, but got I
			Vector3[] endValue = t.endValue;
			Vector3[] array = new Vector3[endValue.Length];
			if (endValue.Length >= 1)
			{
				int num = (int)(endValue.Length & 0xFFFFFFFFL);
				int num2 = 20;
				int num3 = 0;
				do
				{
					if (num3 != 0)
					{
						object obj = (nint)t.endValue + num2;
						object obj2 = (nint)array + num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ X11_v8+8]");
						_ = 0;
					}
					else
					{
						_ = value.y;
						_ = value.z;
					}
					num3++;
					num2 += 12;
				}
				while (num != num3);
			}
			return array;
		}

		[Token(Token = "0x60002EC")]
		[Address(RVA = "0xC1E5E4", Offset = "0xC1E5E4", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = t.endValue;\n\tv126 = v4.Length < 1;\n\tif (v126) goto L_0074;\n\tv170 = v4.Length & 0xFFFFFFFF;\n\tv40 = v170 << 1;\n\tv171 = v170 + v40;\n\tv94 = v171 << 2;\nL_001A:\n\tv215 = v97 == 0;\n\tif (v215) goto L_005B;\n\tv248 = t.endValue + v97;\n\tv242 = t.startValue + v97;\n\t*([v242 @ X11_v10+20]) = *([v248 @ X11_v9+14]);\n\t*([v242 @ X11_v10+28]) = *([v248 @ X11_v9+1C]);\nL_005B:\n\tv186 = t.startValue + v97;\n\tv184 = t.endValue + v97;\n\tv97 = v97 + 0xC;\n\tv181 = *([v186 @ X11_v7+20]) + *([v184 @ X12_v8+20]);\n\tv179 = *([v186 @ X11_v7+28]) + *([v184 @ X12_v8+28]);\n\t*([v184 @ X12_v8+20]) = v181;\n\t*([v184 @ X12_v8+28]) = v179;\n\tv191 = v94 != v97;\n\tif (v191) goto L_001A;\nL_0074:\n\treturn;\n\tv103 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetRelativeEndValue(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			//IL_0045: Expected I4, but got I8
			//IL_00d4: Expected O, but got I
			//IL_00e7: Expected O, but got I
			//IL_0112: Expected O, but got I
			//IL_012f: Expected O, but got I
			//IL_008f: Expected O, but got I
			//IL_00a2: Expected O, but got I
			Vector3[] endValue = t.endValue;
			if (endValue.Length < 1)
			{
				return;
			}
			int num = (int)(endValue.Length & 0xFFFFFFFFL);
			int num2 = num << 1;
			int num3 = num + num2;
			int num4 = num3 << 2;
			int num5 = 0;
			do
			{
				if (num5 != 0)
				{
					object obj = (nint)t.endValue + num5;
					object obj2 = (nint)t.startValue + num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ X11_v9+14]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ X11_v9+1C]");
					_ = 0;
				}
				object obj3 = (nint)t.startValue + num5;
				object obj4 = (nint)t.endValue + num5;
				num5 += 12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ X11_v7+20]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X12_v8+20]");
				object obj5 = num6 + 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ X11_v7+28]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X12_v8+28]");
				object obj6 = num7 + 0;
			}
			while (num4 != num5);
		}

		[Token(Token = "0x60002ED")]
		[Address(RVA = "0xC1E6CC", Offset = "0xC1E6CC", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = UnityEngine.Vector3[];\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, t, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29);\n\tv33 = 1;\n\t*([1A35765]) = v33;\nL_0012:\n\tv35 = t.endValue;\n\t// 26 NewArr v127 @ X0_v7 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v35.Length\n\tt.changeValue = v127;\n\tv67 = v35.Length < 1;\n\tif (v67) goto L_0075;\n\tv65 = t.endValue;\n\tv59 = v35.Length & 0xFFFFFFFF;\nL_0054:\n\tv149 = v65 + v135;\n\tv55 = t.startValue + v135;\n\tv123 = v123 + 1;\n\tv50 = v127 + v135;\n\tv94 = v59 == v123;\n\tv47 = *([v149 @ X11_v5+20]) - *([v55 @ X12_v7+20]);\n\tv44 = *([v149 @ X11_v5+28]) - *([v55 @ X12_v7+28]);\n\t*([v50 @ X13_v7+20]) = v47;\n\t*([v50 @ X13_v7+28]) = v44;\n\tif (v94) goto L_0075;\n\tv65 = t.endValue;\n\tv127 = t.changeValue;\n\tv135 = v135 + 0xC;\n\tv235 = t.endValue == 0;\n\tv129 = ~v235;\n\tif (v129) goto L_0054;\n\tthrow System.NullReferenceException;\nL_0075:\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SetChangeValue(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			//IL_0078: Expected I4, but got I8
			//IL_009d: Expected O, but got I
			//IL_00b0: Expected O, but got I
			//IL_00cc: Expected O, but got I
			//IL_00f7: Expected O, but got I
			//IL_0114: Expected O, but got I
			Vector3[] endValue = t.endValue;
			Vector3[] array = (t.changeValue = new Vector3[endValue.Length]);
			if (endValue.Length < 1)
			{
				return;
			}
			Vector3[] endValue2 = t.endValue;
			int num = (int)(endValue.Length & 0xFFFFFFFFL);
			int num2 = 0;
			int num3 = 0;
			while (true)
			{
				object obj = (nint)endValue2 + num3;
				object obj2 = (nint)t.startValue + num3;
				num2++;
				object obj3 = (nint)array + num3;
				bool flag = num == num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X11_v5+20]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X12_v7+20]");
				object obj4 = num4 - 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X11_v5+28]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X12_v7+28]");
				object obj5 = num5 - 0;
				if (!flag)
				{
					endValue2 = t.endValue;
					array = t.changeValue;
					num3 += 12;
					if (t.endValue == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x60002EE")]
		[Address(RVA = "0xC1E7C4", Offset = "0xC1E7C4", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv42 = *([methodInfo @ X3 (Il2CppMethodInfo)+18]) < 1;\n\tif (v42) goto L_FFFFFFFF;\n\tv126 = *([methodInfo @ X3 (Il2CppMethodInfo)+18]) & 0xFFFFFFFF;\n\tv75 = v126 - 1;\n\tv73 = methodInfo + 0x28;\n\tv71 = changeValue + 0x20;\nL_002F:\n\tgoto L_003A;\n\tv306 = v81;\n\tv307 = \"il2cpp_codegen_initialize_runtime_metadata\"(v306, options, changeValue, methodInfo, v118, v119, v120, v121, v60, v57, v51, v54, v122, v123, v124, v125);\n\t*([1A35759]) = v65;\nL_003A:\n\tgoto L_0049;\n\tv312 = \"il2cpp_codegen_runtime_class_init\"(v309, options, changeValue, methodInfo, v118, v119, v120, v121, v60, v57, v51, v54, v122, v123, v124, v125);\nL_0049:\n\tv314 = *([v73 @ X24_v7-8]) * *([v73 @ X24_v7-8]);\n\tv191 = *([v73 @ X24_v7-4]) * *([v73 @ X24_v7-4]);\n\tv189 = *([v73 @ X24_v7]) * *([v73 @ X24_v7]);\n\tv315 = v314 + v191;\n\tv316 = v315 + v189;\n\tv317 = UnityEngine.Mathf::Sqrt(v316);\n\tv192 = v317 / *([v71 @ X25_v6+v77 @ X22_v7 (System.Int32)*4]);\n\tv243 = v75 == v77;\n\tv69 = v69 + v192;\n\t*([v71 @ X25_v6+v77 @ X22_v7 (System.Int32)*4]) = v192;\n\tif (v243) goto L_007D;\n\tv77 = v77 + 1;\n\tv73 = v73 + 0xC;\n\tv319 = v77 < *([methodInfo @ X3 (Il2CppMethodInfo)+18]);\n\tv212 = ~v319;\n\tv197 = ~v212;\n\tif (v197) goto L_002F;\n\tthrow System.IndexOutOfRangeException;\nL_007D:\n\treturn v69;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override float GetSpeedBasedDuration(Vector3ArrayOptions options, float unitsXSecond, Vector3[] changeValue)
		{
			//IL_003f: Expected I4, but got I8
			//IL_0061: Expected O, but got I
			//IL_0070: Expected O, but got I
			//IL_00a4: Expected O, but got I
			//IL_00c1: Expected O, but got I
			//IL_00dd: Expected O, but got I
			//IL_015d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ X3 (Il2CppMethodInfo)+18]");
			float num3;
			if ((nint)0 >= (nint)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ X3 (Il2CppMethodInfo)+18]");
				int num = 0;
				int num2 = num - 1;
				IntPtr intPtr = default(IntPtr);
				object obj = (nint)intPtr + 40;
				object obj2 = (nint)changeValue + 32;
				num3 = 0f;
				int num4 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X24_v7-8]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X24_v7-8]");
					object obj3 = num5 * 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X24_v7-4]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X24_v7-4]");
					object obj4 = num6 * 0;
					object obj5 = obj * obj;
					object obj6 = (nint)obj3 + (nint)obj4;
					float f = (float)obj6 + (float)obj5;
					float num7 = Mathf.Sqrt(f);
					float num8 = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X25_v6+v77 @ X22_v7 (System.Int32)*4]");
					float num9 = num8 / 0f;
					bool flag = num2 == num4;
					num3 += num9;
					if (flag)
					{
						break;
					}
					num4++;
					obj = (nint)obj + 12;
					int num10 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ X3 (Il2CppMethodInfo)+18]");
					if ((nint)num10 >= (nint)0)
					{
						throw new IndexOutOfRangeException();
					}
				}
			}
			else
			{
				num3 = 0f;
			}
			return num3;
		}

		[Token(Token = "0x60002EF")]
		[Address(RVA = "0xC1E8D4", Offset = "0xC1E8D4", Length = "0x800")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv48 = System.Math;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v52, v53, v54, v55, v56, v57);\n\tv61 = 1;\n\t*([1A35766]) = v61;\nL_0025:\n\tgoto L_002F;\n\tv67 = UnityEngine.Vector3;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, options, t, isRelative, getter, setter, startValue, changeValue, elapsed, duration, v52, v53, v54, v55, v56, v57);\n\tv71 = 1;\n\t*([1A35519]) = v71;\nL_002F:\n\tv75 = UnityEngine.Vector3;\n\tv76 = *([v75 @ X8_v9 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv339 = *([v76 @ X9_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tv89 = *([isRelative @ X3 (System.Boolean)+A8]) != 2;\n\tif (v89) goto L_0077;\n\tv415 = *([isRelative @ X3 (System.Boolean)+111]) & 1;\n\tv350 = *([isRelative @ X3 (System.Boolean)+10C]) - v415;\n\tv191 = v350 < 1;\n\tif (v191) goto L_0077;\n\tv664 = changeValue.Length - 1;\n\tv718 = v664 * 0xC;\n\tv424 = changeValue + v718;\n\tv438 = v664 * 0xC;\n\tv425 = usingInversePosition + v438;\n\tv978 = *([changeValue @ X7 (UnityEngine.Vector3[])+20]);\n\tv723 = *([v424 @ X11_v8+20]) + *([v425 @ X10_v23+20]);\n\tv420 = changeValue[v664 @ X10_v21].z + *([v425 @ X10_v23+28]);\n\tv422 = v723 - *([changeValue @ X7 (UnityEngine.Vector3[])+20]);\n\tv421 = v420 - *([changeValue @ X7 (UnityEngine.Vector3[])+28]);\n\tv619 = v422 * v725;\n\tv339 = v421 * v350;\nL_0077:\n\tv440 = *([isRelative @ X3 (System.Boolean)+E9]) == 0;\n\tif (v440) goto L_00DE;\n\tv351 = *([isRelative @ X3 (System.Boolean)+F0]);\n\tv535 = *([v351 @ X9_v21+A8]) != 2;\n\tif (v535) goto L_00DE;\n\tv655 = *([isRelative @ X3 (System.Boolean)+A8]) != 2;\n\tif (v655) goto L_FFFFFFFF;\n\tv726 = *([isRelative @ X3 (System.Boolean)+A4]);\n\tgoto L_0098;\nL_0098:\n\tv182 = *([v351 @ X9_v21+111]) & 1;\n\tv352 = *([v351 @ X9_v21+10C]) - v182;\n\tv399 = v352 * v726;\n\tv193 = v399 < 1;\n\tif (v193) goto L_00DE;\n\tv738 = changeValue.Length - 1;\n\tv744 = v738 * 0xC;\n\tv533 = changeValue + v744;\n\tv548 = v738 * 0xC;\n\tv546 = usingInversePosition + v548;\n\tv978 = *([changeValue @ X7 (UnityEngine.Vector3[])+20]);\n\tv749 = *([v533 @ X10_v18+20]) + *([v546 @ X9_v27+20]);\n\tv529 = changeValue[v738 @ X9_v25].z + *([v546 @ X9_v27+28]);\n\tv751 = v749 - *([changeValue @ X7 (UnityEngine.Vector3[])+20]);\n\tv752 = v529 - *([changeValue @ X7 (UnityEngine.Vector3[])+28]);\n\tv531 = v751 * v725;\n\tv530 = v752 * v399;\n\tv619 = v619 + v531;\n\tv339 = v339 + v530;\nL_00DE:\n\tv561 = t.sequencedEndPosition < 1;\n\tif (v561) goto L_FFFFFFFF;\n\tv657 = t.sequencedEndPosition & 0xFFFFFFFF;\n\tv658 = t + 0x20;\nL_00E5:\n\tv591 = t.onStart;\n\tv668 = v668 + *([v658 @ X10_v12+v692 @ X8_v64 (System.Int32)*4]);\n\tv703 = v668 >= elapsed;\n\tif (v703) goto L_0105;\n\tv692 = v692 + 1;\n\tv705 = v705 + *([v658 @ X10_v12+v692 @ X8_v64 (System.Int32)*4]);\n\tv675 = v657 != v692;\n\tif (v675) goto L_00E5;\n\tgoto L_010A;\n\tgoto L_010A;\nL_0105:\n\tv705 = elapsed - v705;\nL_010A:\n\tv979 = *([isRelative @ X3 (System.Boolean)+C4]);\n\tv984 = DG.Tweening.Core.Easing.EaseManager::Evaluate(*([isRelative @ X3 (System.Boolean)+B4]), *([isRelative @ X3 (System.Boolean)+B8]), v705, v591, *([isRelative @ X3 (System.Boolean)+C0]), *([isRelative @ X3 (System.Boolean)+C4]));\n\tv276 = options == 8;\n\tif (v276) goto L_018C;\n\tv278 = options == 4;\n\tif (v278) goto L_01E5;\n\tv194 = options != 2;\n\tif (v194) goto L_0257;\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::Invoke(setter, setter.method);\n\tv830 = v392 * 0xC;\n\tv356 = changeValue + v830;\n\tv832 = v392 * 0xC;\n\tv833 = usingInversePosition + v832;\n\tv835 = v619 + *([v356 @ X9_v19+20]);\n\tv836 = v984 * *([v833 @ X8_v56+20]);\n\tv340 = v835 + v836;\n\tv838 = options & 0x100000000;\n\tv839 = v838 == 0;\n\tif (v839) goto L_0318;\n\tgoto L_016B;\n\tv1006 = \"il2cpp_codegen_runtime_class_init\"(v909, v122, v100, isRelative, getter, setter, startValue, changeValue, v835, v836, v150, v141, v137, v346, v56, v57);\nL_016B:\n\tv928 = 0x1854ED0(&v810 @ stack_-48_v5 (System.Double), setter.method, 0, isRelative, getter, setter, startValue, changeValue, v340, v836, v984, v979, v978, v619, v56, v57);\n\tv1063 = v340 >= 0;\n\tif (v1063) goto L_02A1;\n\tv1126 = v340 != -0.5d;\n\tif (v1126) goto L_0307;\n\tgoto L_02A6;\nL_018C:\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::Invoke(setter, setter.method);\n\tv760 = v392 * 0xC;\n\tv761 = usingInversePosition + v760;\n\tv764 = v339 + changeValue[v392 @ X24_v4 (System.Int32)].z;\n\tv765 = v984 * *([v761 @ X8_v18+28]);\n\tv341 = v764 + v765;\n\tv767 = options & 0x100000000;\n\tv768 = v767 == 0;\n\tif (v768) goto L_0324;\n\tgoto L_01C4;\n\tv897 = \"il2cpp_codegen_runtime_class_init\"(v805, v123, v100, isRelative, getter, setter, startValue, changeValue, v764, v765, v151, v141, v137, v346, v56, v57);\nL_01C4:\n\tv824 = 0x1854ED0(&v810 @ stack_-48_v5 (System.Double), setter.method, 0, isRelative, getter, setter, startValue, changeValue, v341, v765, v984, *([isRelative @ X3 (System.Boolean)+C4]), v978, v619, v56, v57);\n\tv963 = v341 >= 0;\n\tif (v963) goto L_02BD;\n\tv1042 = v341 != -0.5d;\n\tif (v1042) goto L_030A;\n\tgoto L_02C2;\nL_01E5:\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector3>::Invoke(setter, setter.method);\n\tv793 = v392 * 0xC;\n\tv794 = usingInversePosition + v793;\n\tv798 = v796 + changeValue[v392 @ X24_v4 (System.Int32)].y;\n\tv799 = v984 * *([v794 @ X8_v30+24]);\n\tv342 = v798 + v799;\n\tv801 = options & 0x100000000;\n\tv802 = v801 == 0;\n\tif (v802) goto L_0330;\n\tgoto L_021F;\n\tv945 = \"il2cpp_codegen_runtime_class_init\"(v874, v124, v100, isRelative, getter, setter, startValue, changeValue, v798, v799, v152, v141, v137, v346, v56, v57);\nL_021F:\n\tv893 = 0x1854ED0(&v810 @ stack_-48_v5 (System.Double), setter.method, 0, isRelative, getter, setter, startValue, changeValue, v342, v799, v984, *([isRelative @ X3 (System.Boolean)+C4]), v978, v619, v56, v57);\n\tv1031 = v342 >= 0;\n\tif (v1031) goto L_02D9;\n\tv1096 = v342 != -0.5d;\n\tif (v1096) goto L_030D;\n\tgoto L_02DE;\nL_0257:\n\tv772 = v392 * 0xC;\n\tv773 = changeValue + v772;\n\tv998 = *([v773 @ X9_v16+20]);\n\tv774 = v392 << 1;\n\tv775 = v392 + v774;\n\tv776 = v775 << 2;\n\tv359 = usingInversePosition + v776;\n\tv103 = v775 << 2;\n\tv777 = changeValue + v103;\n\t// 612 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv781 = v339 + *([v777 @ X8_v41+28]);\n\tv782 = *([v359 @ X9_v17+20]) * v783;\n\tv979 = v984 * *([v359 @ X9_v17+28]);\n\tv784 = v619 + *([v773 @ X9_v16+20]);\n\tv984 = v784 + v782;\n\tv1004 = v781 + v979;\n\tv787 = options & 0x100000000;\n\tv788 = v787 == 0;\n\tif (v788) goto L_03C1;\n\tgoto L_027B;\n\tv932 = \"il2cpp_codegen_runtime_class_init\"(v843, v121, v100, isRelative, getter, setter, startValue, changeValue, v785, v781, v782, v143, v138, v347, v56, v57);\n\tv934 = v842;\nL_027B:\n\tv940 = 0x1854ED0(&v810 @ stack_-48_v5 (System.Double), *([isRelative @ X3 (System.Boolean)+B8]), 0, isRelative, getter, setter, startValue, changeValue, v984, v781, v782, v979, v619, *([v773 @ X9_v16+20]), v56, v57);\n\tv1020 = v984 >= 0;\n\tif (v1020) goto L_02F5;\n\tv1074 = v984 != -0.5d;\n\tif (v1074) goto L_0310;\n\tgoto L_02FA;\nL_02A1:\n\tv1137 = v340 != 0.5d;\n\tif (v1137) goto L_0313;\nL_02A6:\n\t;\n\tv1256 = v917 & 1;\n\tv1258 = v1256 == 0;\n\tv1261 = ~v1258;\n\tif (v1261) goto L_02B2;\n\tgoto L_02B2;\nL_02B2:\n\tgoto L_0318;\nL_02BD:\n\tv1053 = v341 != 0.5d;\n\tif (v1053) goto L_031F;\nL_02C2:\n\t;\n\tv1167 = v813 & 1;\n\tv1169 = v1167 == 0;\n\tv1172 = ~v1169;\n\tif (v1172) goto L_02CE;\n\tgoto L_02CE;\nL_02CE:\n\tgoto L_0324;\nL_02D9:\n\tv1107 = v342 != 0.5d;\n\tif (v1107) goto L_032B;\nL_02DE:\n\t;\n\tv1234 = v882 & 1;\n\tv1236 = v1234 == 0;\n\tv1239 = ~v1236;\n\tif (v1239) goto L_02EA;\n\tgoto L_02EA;\nL_02EA:\n\tgoto L_0330;\nL_02F5:\n\tv1085 = v984 != 0.5d;\n\tif (v1085) goto L_0336;\nL_02FA:\n\tv1202 = v1183 + v1182;\n\tv1195 = v1183 & 1;\n\tv1197 = v1195 == 0;\n\tv1200 = ~v1197;\n\tif (v1200) goto L_FFFFFFFF;\n\tgoto L_0306;\nL_0306:\n\tgoto L_033C;\nL_0307:\n\tv1176 = v340 + -0.5d;\n\tv917 = System.Math::Ceiling(v1176);\n\tgoto L_0318;\nL_030A:\n\tv1110 = v341 + -0.5d;\n\tv813 = System.Math::Ceiling(v1110);\n\tgoto L_0324;\nL_030D:\n\tv1148 = v342 + -0.5d;\n\tv882 = System.Math::Ceiling(v1148);\n\tgoto L_0330;\nL_0310:\n\tv1140 = v984 + -0.5d;\n\tv866 = System.Math::Ceiling(v1140);\n\tgoto L_033C;\nL_0313:\n\tv1180 = v340 + 0.5d;\n\tv917 = System.Math::Floor(v1180);\nL_0318:\n\tv569 = startValue.Length;\n\tv623 = *([startValue \n// ... truncated")]
		public override void EvaluateAndApply(Vector3ArrayOptions options, Tween t, bool isRelative, DOGetter<Vector3> getter, DOSetter<Vector3> setter, float elapsed, Vector3[] startValue, Vector3[] changeValue, float duration, bool usingInversePosition, int newCompletedSteps, UpdateNotice updateNotice)
		{
			//IL_0013: Expected I, but got O
			//IL_001c: Expected I, but got O
			//IL_002c: Expected F4, but got I
			//IL_008d: Expected O, but got I
			//IL_01b9: Expected O, but got I
			//IL_0ed7: Expected F4, but got I
			//IL_0f14: Expected F4, but got I
			//IL_0f14: Expected F4, but got I
			//IL_0f14: Expected O, but got I
			//IL_0376: Unknown result type (might be due to invalid IL or missing references)
			//IL_037b: Expected I4, but got Unknown
			//IL_038a: Expected O, but got I
			//IL_00c8: Expected O, but got I4
			//IL_05a6: Expected O, but got I
			//IL_0e8f: Expected F4, but got I
			//IL_00dc: Expected O, but got I
			//IL_00eb: Expected O, but got I
			//IL_00fa: Expected O, but got I
			//IL_0108: Expected O, but got I
			//IL_0118: Expected O, but got I
			//IL_0135: Expected O, but got I
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Expected O, but got Unknown
			//IL_05c8: Expected O, but got I4
			//IL_0618: Unknown result type (might be due to invalid IL or missing references)
			//IL_061d: Expected I4, but got Unknown
			//IL_0b4d: Expected O, but got I4
			//IL_0b5d: Expected O, but got I
			//IL_0b6d: Expected O, but got I
			//IL_06b1: Expected O, but got I
			//IL_06d3: Expected O, but got I4
			//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ef: Expected O, but got Unknown
			//IL_0722: Unknown result type (might be due to invalid IL or missing references)
			//IL_0727: Expected I4, but got Unknown
			//IL_0e54: Expected O, but got I
			//IL_0e62: Expected O, but got I
			//IL_0ba2: Expected O, but got I4
			//IL_0bb2: Expected O, but got I
			//IL_0bc2: Expected O, but got I
			//IL_0bd2: Expected F4, but got I
			//IL_07c5: Expected O, but got I
			//IL_07d5: Expected F4, but got I
			//IL_080b: Expected O, but got I4
			//IL_0827: Expected O, but got I
			//IL_085e: Expected O, but got I
			//IL_08b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_08bc: Expected I4, but got Unknown
			//IL_0dda: Expected O, but got I4
			//IL_0dea: Expected O, but got I
			//IL_0dfa: Expected O, but got I
			//IL_0487: Expected O, but got I
			//IL_0241: Expected O, but got I4
			//IL_04a8: Expected O, but got I
			//IL_04c3: Expected O, but got I4
			//IL_050d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0512: Expected I4, but got Unknown
			//IL_0255: Expected O, but got I
			//IL_0264: Expected O, but got I
			//IL_0273: Expected O, but got I
			//IL_0281: Expected O, but got I
			//IL_0291: Expected O, but got I
			//IL_02ae: Expected O, but got I
			//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d1: Expected O, but got Unknown
			//IL_0af8: Expected O, but got I4
			//IL_0b08: Expected O, but got I
			//IL_0b18: Expected O, but got I
			//IL_0f76: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f7b: Expected I4, but got Unknown
			//IL_10af: Unknown result type (might be due to invalid IL or missing references)
			//IL_10b4: Expected I4, but got Unknown
			//IL_0fad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fb2: Expected I4, but got Unknown
			//IL_101e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1023: Expected I4, but got Unknown
			//IL_0c95: Expected O, but got F8
			//IL_0f3f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f44: Expected I4, but got Unknown
			//IL_0c62: Expected O, but got F8
			nint num = (nint)typeof(Vector3);
			nint num2 = (nint)Vector3.zero;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X9_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			float num3 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+A8]");
			bool flag = (nint)0 != 2;
			float num4 = Vector3.zero.x;
			object obj9 = default(object);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+111]");
				int num5 = (int)((nint)0 & (nint)1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+10C]");
				object obj = -num5;
				bool flag2 = (nint)obj < 1;
				num4 = Vector3.zero.x;
				if (!flag2)
				{
					object obj2 = changeValue.Length - 1;
					object obj3 = (nint)obj2 * 12;
					object obj4 = (nint)changeValue + (nint)obj3;
					object obj5 = (nint)obj2 * 12;
					object obj6 = (usingInversePosition ? 1 : 0) + (nint)obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (UnityEngine.Vector3[])+20]");
					Vector3 vector = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ X11_v8+20]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ X10_v23+20]");
					object obj7 = num6 + 0;
					float z = changeValue[obj2].z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ X10_v23+28]");
					object obj8 = z + 0;
					float num7 = (float)obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (UnityEngine.Vector3[])+20]");
					float num8 = num7 - 0f;
					float num9 = (float)obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (UnityEngine.Vector3[])+28]");
					float num10 = num9 - 0f;
					num4 = num8 * (float)obj9;
					num3 = num10 * (float)obj;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+E9]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+F0]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ X9_v21+A8]");
				if ((nint)0 == 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+A8]");
					int num11;
					if ((nint)0 == 2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+A4]");
						num11 = 0;
					}
					else
					{
						num11 = 1;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ X9_v21+111]");
					int num12 = (int)((nint)0 & (nint)1);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ X9_v21+10C]");
					object obj11 = -num12;
					object obj12 = (nint)obj11 * num11;
					if ((nint)obj12 >= 1)
					{
						object obj13 = changeValue.Length - 1;
						object obj14 = (nint)obj13 * 12;
						object obj15 = (nint)changeValue + (nint)obj14;
						object obj16 = (nint)obj13 * 12;
						object obj17 = (usingInversePosition ? 1 : 0) + (nint)obj16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (UnityEngine.Vector3[])+20]");
						Vector3 vector = (Vector3)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ X10_v18+20]");
						nint num13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ X9_v27+20]");
						object obj18 = num13 + 0;
						float z2 = changeValue[obj13].z;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ X9_v27+28]");
						object obj19 = z2 + 0;
						float num14 = (float)obj18;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (UnityEngine.Vector3[])+20]");
						float num15 = num14 - 0f;
						float num16 = (float)obj19;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [changeValue @ X7 (UnityEngine.Vector3[])+28]");
						float num17 = num16 - 0f;
						float num18 = num15 * (float)obj9;
						float num19 = num17 * (float)obj12;
						num4 += num18;
						num3 += num19;
					}
				}
			}
			float num22;
			float num24;
			int num27;
			if (!(t.sequencedEndPosition < float.Epsilon))
			{
				int num20 = t.sequencedEndPosition & 0xFFFFFFFFL;
				object obj20 = (nint)t + 32;
				float num21 = 0f;
				num22 = 0f;
				int num23 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v658 @ X10_v12+v692 @ X8_v64 (System.Int32)*4]");
					num24 = 0f;
					float num25 = num21;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v658 @ X10_v12+v692 @ X8_v64 (System.Int32)*4]");
					num21 = num25 + 0f;
					if (num21 < elapsed)
					{
						num23++;
						float num26 = num22;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v658 @ X10_v12+v692 @ X8_v64 (System.Int32)*4]");
						num22 = num26 + 0f;
						if (num20 == num23)
						{
							num27 = 0;
							break;
						}
						continue;
					}
					num22 = elapsed - num22;
					num27 = num23;
					break;
				}
			}
			else
			{
				num24 = 0f;
				num22 = 0f;
				num27 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+C4]");
			float num28 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+B4]");
			nint num29 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+B8]");
			nint num30 = 0;
			float time = num22;
			float duration2 = num24;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+C0]");
			nint num31 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+C4]");
			float num32 = EaseManager.Evaluate((Ease)num29, (EaseFunction)num30, time, duration2, num31, 0f);
			double num41 = default(double);
			float num53 = default(float);
			object obj30 = default(object);
			if ((nint)options != 8)
			{
				if ((nint)options != 4)
				{
					if ((nint)options == 2)
					{
						setter((Vector3)(nint)setter.method);
						int num33 = num27 * 12;
						object obj21 = (nint)changeValue + num33;
						int num34 = num27 * 12;
						object obj22 = (usingInversePosition ? 1 : 0) + num34;
						float num35 = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ X9_v19+20]");
						float num36 = num35 + 0f;
						float num37 = num32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ X8_v56+20]");
						float num38 = num37 * 0f;
						float num39 = num36 + num38;
						if ((int)(options & 0x100000000L) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
							double num40;
							if (num39 < 0f)
							{
								if ((double)num39 != -0.5)
								{
									double a = (double)num39 + -0.5;
									num40 = Math.Ceiling(a);
									goto IL_0aee;
								}
								num40 = num41;
							}
							else
							{
								if ((double)num39 != 0.5)
								{
									double d = (double)num39 + 0.5;
									num40 = Math.Floor(d);
									goto IL_0aee;
								}
								num40 = num41;
							}
							if ((num40 & 1) != 0)
							{
							}
						}
						goto IL_0aee;
					}
					int num42 = num27 * 12;
					object obj23 = (nint)changeValue + num42;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ X9_v16+20]");
					float num43 = 0f;
					int num44 = num27 << 1;
					int num45 = num27 + num44;
					int num46 = num45 << 2;
					object obj24 = (usingInversePosition ? 1 : 0) + num46;
					int num47 = num45 << 2;
					object obj25 = (nint)changeValue + num47;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					float num48 = num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v777 @ X8_v41+28]");
					float num49 = num48 + 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ X9_v17+20]");
					object obj27 = default(object);
					object obj26 = 0 * (nint)obj27;
					float num50 = num32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ X9_v17+28]");
					num28 = num50 * 0f;
					float num51 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ X9_v16+20]");
					float num52 = num51 + 0f;
					num32 = num52 + (float)obj26;
					num53 = num49 + num28;
					if ((int)(options & 0x100000000L) != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
						double num56;
						double num57;
						double num55;
						if (num32 < 0f)
						{
							if ((double)num32 != -0.5)
							{
								double a2 = (double)num32 + -0.5;
								double num54 = Math.Ceiling(a2);
								num55 = -0.5;
								goto IL_0c0a;
							}
							num56 = -1.0;
							num57 = num41;
						}
						else
						{
							if ((double)num32 != 0.5)
							{
								double d2 = (double)num32 + 0.5;
								double num54 = Math.Floor(d2);
								num55 = 0.5;
								goto IL_0c0a;
							}
							num56 = 1.0;
							num57 = num41;
						}
						num55 = num57 + num56;
						if ((num57 & 1) == 0)
						{
							double num54 = num57;
						}
						else
						{
							double num54 = num55;
						}
						goto IL_0c0a;
					}
					goto IL_0dd0;
				}
				setter((Vector3)(nint)setter.method);
				int num58 = num27 * 12;
				object obj28 = (usingInversePosition ? 1 : 0) + num58;
				object obj29 = (nint)obj30 + changeValue[num27].y;
				float num59 = num32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ X8_v30+24]");
				float num60 = num59 * 0f;
				float num61 = (float)obj29 + num60;
				if ((int)(options & 0x100000000L) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
					double num62;
					if (num61 < 0f)
					{
						if ((double)num61 != -0.5)
						{
							double a3 = (double)num61 + -0.5;
							num62 = Math.Ceiling(a3);
							goto IL_0b98;
						}
						num62 = num41;
					}
					else
					{
						if ((double)num61 != 0.5)
						{
							double d3 = (double)num61 + 0.5;
							num62 = Math.Floor(d3);
							goto IL_0b98;
						}
						num62 = num41;
					}
					if ((num62 & 1) != 0)
					{
					}
				}
				goto IL_0b98;
			}
			setter((Vector3)(nint)setter.method);
			int num63 = num27 * 12;
			object obj31 = (usingInversePosition ? 1 : 0) + num63;
			float num64 = num3 + changeValue[num27].z;
			float num65 = num32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ X8_v18+28]");
			float num66 = num65 * 0f;
			float num67 = num64 + num66;
			if ((int)(options & 0x100000000L) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
				double num68;
				if (num67 < 0f)
				{
					if ((double)num67 != -0.5)
					{
						double a4 = (double)num67 + -0.5;
						num68 = Math.Ceiling(a4);
						goto IL_0b43;
					}
					num68 = num41;
				}
				else
				{
					if ((double)num67 != 0.5)
					{
						double d4 = (double)num67 + 0.5;
						num68 = Math.Floor(d4);
						goto IL_0b43;
					}
					num68 = num41;
				}
				if ((num68 & 1) != 0)
				{
				}
			}
			goto IL_0b43;
			IL_0c0a:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			object obj32 = default(object);
			if ((nint)obj30 < 0)
			{
				if ((double)obj30 != -0.5)
				{
					double a5 = (double)obj30 + -0.5;
					double num69 = Math.Ceiling(a5);
					goto IL_0ceb;
				}
				obj32 = num41;
			}
			else
			{
				if ((double)obj30 != 0.5)
				{
					double d5 = (double)obj30 + 0.5;
					double num70 = Math.Floor(d5);
					goto IL_0ceb;
				}
				obj32 = num41;
			}
			goto IL_1069;
			IL_105f:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v569 @ X2_v4 (should have been resolved before IL gen)");
			goto IL_1069;
			IL_0b98:
			object obj33 = startValue.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (UnityEngine.Vector3[])+40]");
			Vector3 vector2 = (Vector3)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (UnityEngine.Vector3[])+28]");
			Vector3 vector3 = (Vector3)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [isRelative @ X3 (System.Boolean)+C0]");
			num53 = 0f;
			goto IL_105f;
			IL_0aee:
			obj33 = startValue.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (UnityEngine.Vector3[])+40]");
			vector2 = (Vector3)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (UnityEngine.Vector3[])+28]");
			vector3 = (Vector3)0;
			goto IL_105f;
			IL_0ceb:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854ED0 (native modf)");
			double num72;
			if (num53 < 0f)
			{
				if ((double)num53 != -0.5)
				{
					double a6 = (double)num53 + -0.5;
					double num71 = Math.Ceiling(a6);
					goto IL_0dd0;
				}
				num72 = num41;
			}
			else
			{
				if ((double)num53 != 0.5)
				{
					double d6 = (double)num53 + 0.5;
					double num71 = Math.Floor(d6);
					goto IL_0dd0;
				}
				num72 = num41;
			}
			if ((num72 & 1) != 0)
			{
			}
			goto IL_0dd0;
			IL_0b43:
			obj33 = startValue.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (UnityEngine.Vector3[])+40]");
			vector2 = (Vector3)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (UnityEngine.Vector3[])+28]");
			vector3 = (Vector3)0;
			goto IL_105f;
			IL_1069:
			if ((int)((nint)obj32 & 1) != 0)
			{
			}
			goto IL_0ceb;
			IL_0dd0:
			obj33 = startValue.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (UnityEngine.Vector3[])+40]");
			vector2 = (Vector3)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [startValue @ X6 (UnityEngine.Vector3[])+28]");
			vector3 = (Vector3)0;
			goto IL_105f;
		}

		[Token(Token = "0x60002F0")]
		[Address(RVA = "0xC1F0D4", Offset = "0xC1F0D4", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35767]) = v37;\nL_001A:\n\tDG.Tweening.Plugins.Core.ABSTweenPlugin`3<UnityEngine.Vector3, System.Object, DG.Tweening.Plugins.Options.Vector3ArrayOptions>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector3ArrayPlugin()
		{
		}
	}
}
