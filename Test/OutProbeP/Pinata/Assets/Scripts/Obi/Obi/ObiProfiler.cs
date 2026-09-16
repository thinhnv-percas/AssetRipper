using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[DisallowMultipleComponent]
	[Token(Token = "0x2000059")]
	public class ObiProfiler : MonoBehaviour
	{
		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x746264", Offset = "0x746264")]
		[Token(Token = "0x4000198")]
		[FieldOffset(Offset = "0x18")]
		public GUISkin skin;

		[Token(Token = "0x4000199")]
		[FieldOffset(Offset = "0x20")]
		public Color threadColor;

		[Token(Token = "0x400019A")]
		[FieldOffset(Offset = "0x30")]
		public Color taskColor;

		[Token(Token = "0x400019B")]
		[FieldOffset(Offset = "0x40")]
		public Color parallelTaskColor;

		[Token(Token = "0x400019C")]
		[FieldOffset(Offset = "0x50")]
		public Color renderTaskColor;

		[Token(Token = "0x400019D")]
		[FieldOffset(Offset = "0x60")]
		public Color defaultTaskColor;

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x74629C", Offset = "0x74629C")]
		[Token(Token = "0x400019E")]
		[FieldOffset(Offset = "0x70")]
		public bool showPercentages;

		[Token(Token = "0x400019F")]
		[FieldOffset(Offset = "0x74")]
		public int profileThrottle;

		[Token(Token = "0x40001A0")]
		[FieldOffset(Offset = "0x78")]
		private Oni.ProfileInfo[] info;

		[Token(Token = "0x40001A1")]
		[FieldOffset(Offset = "0x80")]
		private double frameStart;

		[Token(Token = "0x40001A2")]
		[FieldOffset(Offset = "0x88")]
		private double frameEnd;

		[Token(Token = "0x40001A3")]
		[FieldOffset(Offset = "0x90")]
		private int frameCounter;

		[Token(Token = "0x40001A4")]
		[FieldOffset(Offset = "0x94")]
		private int yPos;

		[Token(Token = "0x40001A5")]
		[FieldOffset(Offset = "0x98")]
		private bool profiling;

		[Token(Token = "0x40001A6")]
		[FieldOffset(Offset = "0x9C")]
		private float zoom;

		[Token(Token = "0x40001A7")]
		[FieldOffset(Offset = "0xA0")]
		private Vector2 scrollPosition;

		[Token(Token = "0x40001A8")]
		private static ObiProfiler _instance;

		[Token(Token = "0x60003B7")]
		[Address(RVA = "0xC3188C", Offset = "0xC3188C", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = *([1ECFAB8]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202318B]) = v42;\nL_0020:\n\tgoto L_0029;\n\tv54 = *([v49 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0029:\n\tv64 = UnityEngine.Object::op_Inequality(v48._instance, 0);\n\tv66 = v64 == 0;\n\tif (v66) goto L_0058;\n\tgoto L_003D;\n\tv94 = *([v68 @ X0_v7+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_003D;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v68, v62, v63, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003D:\n\tv80 = UnityEngine.Object::op_Inequality(v69._instance, this);\n\tv82 = v80 == 0;\n\tif (v82) goto L_0058;\n\tgoto L_0054;\n\tv128 = *([v124 @ X0_v11+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0054;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v78, v76, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0054:\n\tUnityEngine.Object::DestroyImmediate(this);\n\treturn;\nL_0058:\n\tv87._instance = this;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			if (_instance != null && _instance != this)
			{
				UnityEngine.Object.DestroyImmediate(this);
			}
			else
			{
				_instance = this;
			}
		}

		[Token(Token = "0x60003B8")]
		[Address(RVA = "0xC31990", Offset = "0xC31990", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ECF298]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202318C]) = v35;\nL_0017:\n\tv41._instance = 0;\n\tOni::EnableProfiler(0);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDestroy()
		{
			_instance = null;
			Oni.EnableProfiler(cooked: false);
		}

		[Token(Token = "0x60003B9")]
		[Address(RVA = "0xC319E8", Offset = "0xC319E8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv16 = *([1EE9638]);\n\tv17 = *([v16 @ X8_v14]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202318D]) = v37;\nL_001D:\n\tgoto L_0026;\n\tv49 = *([v44 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0026;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0026:\n\tv59 = UnityEngine.Object::op_Inequality(v43._instance, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0040;\n\tv64 = v63._instance;\n\tv67 = ~v64.profiling;\n\tif (v67) goto L_0040;\n\tOni::EnableProfiler(1);\n\treturn;\nL_0040:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			if (_instance != null)
			{
				ObiProfiler instance = _instance;
				if (instance.profiling)
				{
					Oni.EnableProfiler(cooked: true);
				}
			}
		}

		[Token(Token = "0x60003BA")]
		[Address(RVA = "0xC31AA0", Offset = "0xC31AA0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv14 = *([1EC6F18]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202318E]) = v35;\nL_001C:\n\tgoto L_0025;\n\tv47 = *([v42 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0025;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tv57 = UnityEngine.Object::op_Inequality(v41._instance, 0);\n\tv59 = v57 == 0;\n\tif (v59) goto L_0035;\n\tOni::EnableProfiler(0);\n\treturn;\nL_0035:\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (_instance != null)
			{
				Oni.EnableProfiler(cooked: false);
			}
		}

		[Token(Token = "0x60003BB")]
		[Address(RVA = "0xC31B38", Offset = "0xC31B38", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv16 = *([1EB3AF8]);\n\tv17 = *([v16 @ X8_v13]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202318F]) = v37;\nL_001D:\n\tgoto L_0026;\n\tv49 = *([v44 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0026;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v44, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0026:\n\tv59 = UnityEngine.Object::op_Inequality(v43._instance, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0048;\n\tv64 = v63._instance;\n\tv64.profiling = 1;\n\tv73 = UnityEngine.Behaviour::get_isActiveAndEnabled(v77._instance);\n\tv75 = v73 == 0;\n\tif (v75) goto L_0048;\n\tOni::EnableProfiler(1);\n\treturn;\nL_0048:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void EnableProfiler()
		{
			if (_instance != null)
			{
				ObiProfiler instance = _instance;
				instance.profiling = true;
				if (_instance.isActiveAndEnabled)
				{
					Oni.EnableProfiler(cooked: true);
				}
			}
		}

		[Token(Token = "0x60003BC")]
		[Address(RVA = "0xC31C08", Offset = "0xC31C08", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv16 = *([1F0F1A8]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023190]) = v37;\nL_001D:\n\tgoto L_0026;\n\tv49 = *([v44 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0026;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v44, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0026:\n\tv59 = UnityEngine.Object::op_Inequality(v43._instance, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_003E;\n\tv64 = v63._instance;\n\tv64.profiling = 0;\n\tOni::EnableProfiler(0);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DisableProfiler()
		{
			if (_instance != null)
			{
				ObiProfiler instance = _instance;
				instance.profiling = false;
				Oni.EnableProfiler(cooked: false);
			}
		}

		[Token(Token = "0x60003BD")]
		[Address(RVA = "0xC31CBC", Offset = "0xC31CBC", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = *([1EA7BD8]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, type, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023191]) = v41;\nL_0020:\n\tgoto L_0029;\n\tv53 = *([v48 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0029;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v48, type, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\tv63 = UnityEngine.Object::op_Inequality(v47._instance, 0);\n\tv65 = v63 == 0;\n\tif (v65) goto L_003E;\n\tOni::BeginSample(name, type);\n\treturn;\nL_003E:\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void BeginSample(string name, byte type)
		{
			if (_instance != null)
			{
				Oni.BeginSample(name, type);
			}
		}

		[Token(Token = "0x60003BE")]
		[Address(RVA = "0xC31D6C", Offset = "0xC31D6C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv14 = *([1EF27A0]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023192]) = v35;\nL_001C:\n\tgoto L_0025;\n\tv47 = *([v42 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0025;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v42, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0025:\n\tv57 = UnityEngine.Object::op_Inequality(v41._instance, 0);\n\tv59 = v57 == 0;\n\tif (v59) goto L_0034;\n\tOni::EndSample();\n\treturn;\nL_0034:\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void EndSample()
		{
			if (_instance != null)
			{
				Oni.EndSample();
			}
		}

		[Token(Token = "0x60003BF")]
		[Address(RVA = "0xC31E00", Offset = "0xC31E00", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1EE38B0]);\n\tv29 = *([v28 @ X8_v21]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2023193]) = v48;\nL_0019:\n\tv50 = this.frameCounter - 1;\n\tthis.frameCounter = v50;\n\tv62 = v50 > 0;\n\tif (v62) goto L_008B;\n\tv64 = Oni::GetProfilingInfoCount();\n\t// 48 NewArr v119 @ X0_v7 (ProfileInfo[]), typeof(ProfileInfo[]), v64 @ X0_v5 (System.Int32)\n\tthis.info = v119;\n\tOni::GetProfilingInfo(v119, v64);\n\tv127 = this.info;\n\tthis.frameCounter = this.profileThrottle;\n\tthis.frameStart = *([181A1D0]);\n\tv217 = v127.Length;\n\tv82 = v127.Length < 1;\n\tif (v82) goto L_008B;\nL_004D:\n\tv230 = v201 < v217;\n\tv210 = ~v230;\n\tif (v210) goto L_008D;\n\tv74 = v201 << 5;\n\tv233 = v127 + v74;\n\tgoto L_006A;\n\tv238 = *([v231 @ X0_v14+E0]);\n\tv239 = v238 == 0;\n\tv240 = ~v239;\n\tif (v240) goto L_006A;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v231, v116, v114, v33, v34, v35, v36, v37, v211, v196, v40, v41, v42, v43, v44, v45);\nL_006A:\n\tv247 = System.Math::Min(this.frameStart, *([v233 @ X8_v14+20]));\n\tthis.frameStart = v247;\n\tv108 = System.Math::Max(this.frameEnd, v127[v201 @ X21_v5 (System.Int32)].end);\n\tthis.frameEnd = v108;\n\tv217 = v127.Length;\n\tv201 = v201 + 1;\n\tv81 = v201 < v127.Length;\n\tif (v81) goto L_004D;\nL_008B:\n\tOni::ClearProfiler();\n\treturn;\nL_008D:\n\tv237 = new System.IndexOutOfRangeException();\n\tthrow v237;\n\tthrow System.NullReferenceException;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateProfilerInfo()
		{
			//IL_005f: Expected F8, but got I
			//IL_00b7: Expected O, but got I
			//IL_00d3: Expected F8, but got I
			if (--frameCounter <= 0)
			{
				int profilingInfoCount = Oni.GetProfilingInfoCount();
				Oni.GetProfilingInfo(info = new Oni.ProfileInfo[profilingInfoCount], profilingInfoCount);
				Oni.ProfileInfo[] array = info;
				frameCounter = profileThrottle;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [181A1D0]");
				frameStart = 0.0;
				int num = array.Length;
				if (array.Length >= 1)
				{
					int num2 = 0;
					do
					{
						if (num2 < num)
						{
							int num3 = num2 << 5;
							object obj = (long)(IntPtr)array + (long)num3;
							double val = frameStart;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ X8_v14+20]");
							double num4 = Math.Min(val, 0.0);
							frameStart = num4;
							double num5 = Math.Max(frameEnd, array[num2].end);
							frameEnd = num5;
							num = array.Length;
							num2++;
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (num2 < array.Length);
				}
			}
			Oni.ClearProfiler();
		}

		[Token(Token = "0x60003C0")]
		[Address(RVA = "0xC31F5C", Offset = "0xC31F5C", Length = "0x81C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv40 = &v41 @ stack_-10_v2;\n\tgoto L_0024;\n\tv50 = *([1EFAF38]);\n\tv51 = *([v50 @ X8_v108]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv70 = 0 | 1;\n\t*([2023194]) = v70;\nL_0024:\n\t*([v40 @ X29_v1-A0]) = 0;\n\t*([v40 @ X29_v1-98]) = 0;\n\t*([v40 @ X29_v1-A8]) = 0;\n\tv72 = UnityEngine.Event::get_current();\n\tv75 = UnityEngine.Event::get_type(v72);\n\tv301 = v75 != 8;\n\tif (v301) goto L_0039;\n\tObi.ObiProfiler::UpdateProfilerInfo(this);\nL_0039:\n\t;\n\tv411 = this.info == 0;\n\tif (v411) goto L_02CD;\n\tgoto L_004B;\n\tv654 = *([v414 @ X0_v12+E0]);\n\tv655 = v654 == 0;\n\tv656 = ~v655;\n\tif (v656) goto L_004B;\n\tv658 = \"il2cpp_codegen_runtime_class_init\"(v414, v74, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\nL_004B:\n\tUnityEngine.GUI::set_skin(this.skin);\n\tv664 = UnityEngine.Screen::get_width();\n\tv670 = v664 / this.zoom;\n\tv241 = this.frameEnd - this.frameStart;\n\tv671 = UnityEngine.Screen::get_width();\n\tv374 = 0;\n\tv678 = 0x10CCF64(&v374 @ stack_-C8_v4, 0, v54, v82, v80, v57, v58, v59, 0, 0, v671, 20f, v64, v65, v66, v67);\n\tgoto L_0070;\n\tv685 = *([v681 @ X0_v21+E0]);\n\tv686 = v685 == 0;\n\tv687 = ~v686;\n\tif (v687) goto L_0070;\n\tv689 = \"il2cpp_codegen_runtime_class_init\"(v681, v677, v54, v55, v56, v57, v58, v59, v675, v676, v672, v673, v64, v65, v66, v67);\nL_0070:\n\tv696 = UnityEngine.GUIStyle::op_Implicit(\"Box\");\n\t// 123 MakeStruct v228 @ AGGC320B4_0_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v700 @ stack_-C4, 0, v703 @ stack_-BC\n\tUnityEngine.GUI::BeginGroup(v228, \"\", v696);\n\tv359 = 0;\n\tv716 = 0x10CCF64(&v359 @ stack_-D8_v4, 0, 0, v82, v80, v57, v58, v59, 5f, 0, 50f, 20f, v64, v65, v66, v67);\n\t// 146 MakeStruct v213 @ AGGC32100_0_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v720 @ stack_-D4, 0, v723 @ stack_-CC\n\tUnityEngine.GUI::Label(v213, \"Zoom:\");\n\tv352 = 0;\n\tv735 = 0x10CCF64(&v352 @ stack_-E8_v4, 0, 0, v82, v80, v57, v58, v59, 50f, 5f, 100f, 20f, v64, v65, v66, v67);\n\t// 168 MakeStruct v196 @ AGGC32148_0_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v740 @ stack_-E4, 0, v743 @ stack_-DC\n\tv746 = UnityEngine.GUI::HorizontalSlider(v196, this.zoom, 0.005f, 1f);\n\tthis.zoom = v746;\n\tv748 = UnityEngine.Screen::get_width();\n\tv749 = v748 - 0x64;\n\tv193 = 0;\n\tv756 = 0x10CCF64(&v193 @ stack_-F8_v4, 0, 0, v82, v80, v57, v58, v59, v749, 0, 100f, 20f, this.zoom, 0.005f, 1f, v67);\n\tv761 = &v41 @ stack_-10_v2 - 0x98;\n\tv762 = v241 / 1000d;\n\t*([v40 @ X29_v1-98]) = v762;\n\tv765 = 0xA6632C(v761, \"0.###\", 0, v82, v80, v57, v58, v59, v762, 0, 100f, 20f, this.zoom, 0.005f, 1f, v67);\n\tv770 = System.String::Concat(v765, \" ms/frame\");\n\t// 204 MakeStruct v184 @ AGGC321C8_0_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v773 @ stack_-F4, 0, v776 @ stack_-EC\n\tUnityEngine.GUI::Label(v184, v770);\n\tUnityEngine.GUI::EndGroup();\n\tv780 = UnityEngine.Screen::get_width();\n\tv782 = UnityEngine.Screen::get_height();\n\tv783 = v782 - 0x14;\n\tv181 = 0;\n\tv790 = 0x10CCF64(&v181 @ stack_-108_v4, 0, 0, v82, v80, v57, v58, v59, 0, 20f, v780, v783, this.zoom, 0.005f, 1f, v67);\n\tv793 = this.yPos + 0x1E;\n\tv173 = 0;\n\tv799 = 0x10CCF64(&v173 @ stack_-118_v4 (UnityEngine.Rect), 0, 0, v82, v80, v57, v58, v59, 0, 0, v670, v793, this.zoom, 0.005f, 1f, v67);\n\t// 250 MakeStruct v158 @ AGGC32268_0_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v805 @ stack_-104, 0, v808 @ stack_-FC\n\t// 251 MakeStruct v155 @ AGGC32268_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.scrollPosition (UnityEngine.Vector2), this.scrollPosition.y (System.Single)\n\tv814 = UnityEngine.GUI::BeginScrollView(v158, v155, 0);\n\tthis.scrollPosition = v814;\n\tthis.scrollPosition.y = v814.y;\n\t// 263 MakeStruct v152 @ AGGC32284_0_v4 (UnityEngine.Color), typeof(UnityEngine.Color), this.threadColor (UnityEngine.Color), this.threadColor.g (System.Single), this.threadColor.b (System.Single), this.threadColor.a (System.Single)\n\tUnityEngine.GUI::set_color(v152);\n\tv149 = 0;\n\tv828 = 0x10CCF64(&v149 @ stack_-128_v4, 0, 0, v82, v80, v57, v58, v59, 5f, 0, 200f, 20f, this.threadColor, this.threadColor.g, 1f, v67);\n\t// 284 MakeStruct v140 @ AGGC322C8_0_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v832 @ stack_-124, 0, v835 @ stack_-11C\n\tUnityEngine.GUI::Label(v140, \"Thread 1\");\n\tv137 = 0;\n\tv846 = 0x10CCF64(&v137 @ stack_-138_v4, 0, 0, v82, v80, v57, v58, v59, 0, 0, v670, 40f, this.threadColor, this.threadColor.g, 1f, v67);\n\tv851 = UnityEngine.GUIStyle::op_Implicit(\"Thread\");\n\t// 311 MakeStruct v125 @ AGGC32324_0_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v853 @ stack_-134, 0, v854 @ stack_-12C\n\tUnityEngine.GUI::Box(v125, \"\", v851);\n\tv123 = this.info;\n\tthis.yPos = 0x19;\n\tv120 = v123.Length;\n\tv866 = v123.Length < 1;\n\tif (v866) goto L_02B0;\nL_0152:\n\tv935 = v115 < v120;\n\tv279 = ~v935;\n\tif (v279) goto L_02CE;\n\tv883 = v115 << 5;\n\tv942 = v123 + v883;\n\tv882 = v123[v115 @ X27_v7 (System.Int32)].info >> 0x10;\n\tv954 = v123[v115 @ X27_v7 (System.Int32)].info >> 8;\n\tv895 = v954 & 0xFF;\n\tv955 = v112 != v123[v115 @ X27_v7 (System.Int32)].info;\n\tif (v955) goto L_0183;\n\tv961 = v288 == v895;\n\tif (v961) goto L_01E1;\n\tv1029 = this.yPos + 0x15;\n\tgoto L_01E0;\nL_0183:\n\tv971 = this.yPos + 0x15;\n\tthis.yPos = v971;\n\tgoto L_0194;\n\tv1040 = *([v972 @ X0_v97+E0]);\n\tv1041 = v1040 == 0;\n\tv1042 = ~v1041;\n\tif (v1042) goto L_0194;\n\tv1044 = \"il2cpp_codegen_runtime_class_init\"(v972, v933, v924, v82, v80, v57, v58, v59, v251, v249, v247, v245, v203, v201, v199, v67);\nL_0194:\n\t// 404 MakeStruct v1052 @ AGGC323E0_0_v8 (UnityEngine.Color), typeof(UnityEngine.Color), this.threadColor (UnityEngine.Color), this.threadColor.g (System.Single), this.threadColor.b (System.Single), this.threadColor.a (System.Single)\n\tUnityEngine.GUI::set_color(v1052);\n\tv1091 = this.yPos + 5;\n\tv374 = 0;\n\tv1095 = 0x10CCF64(&v374 @ stack_-C8_v4, 0, v924, *([v874 @ X24_v7 (System.String)]), 0, v57, v58, v59, 5f, v1091, 200f, 20f, this.threadColor, this.threadColor.g, 1f, v67);\n\tv1143 = v882 + 1;\n\t// 423 Box v1144 @ X0_v103 (System.Object), typeof(System.UInt32), &v1143 @ X8_v83 (System.Int32)\n\tv1172 = System.String::Concat(\"Thread \", v1144);\n\t// 436 MakeStruct v1054 @ AGGC32450_0_v8 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v700 @ stack_-C4, 0, v703 @ stack_-BC\n\tUnityEngine.GUI::Label(v1054, v1172);\n\tv1196 = this.yPos + 5;\n\tv359 = 0;\n\tv1200 = 0x10CCF64(&v359 @ stack_-D8_v4, 0, 0, *([v874 @ X24_v7 (System.String)]), 0, v57, v58, v59, 0, v1196, v670, 40f, this.threadColor, this.threadColor.g, 1f, v67);\n\tgoto L_01D1;\n\tv1233 = *([v1214 @ X0_v108+E0]);\n\tv1234 = v1233 == 0;\n\tv1235 = ~v1234;\n\tif (v1235) goto L_01D1;\n\tv1237 = \"il2cpp_codegen_runtime_class_init\"(v1214, v1199, v1169, v82, v80, v57, v58, v59, v1198, v1197, v1193, v1194, v203, v201, v199, v67);\nL_01D1:\n\tv1243 = UnityEngine.GUIStyle::op_Implicit(\"Thread\");\n\t// 476 MakeStruct v1053 @ AGGC324D0_0_v8 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v720 @ stack_-D4, 0, v723 @ stack_-CC\n\tUnityEngine.GUI::Box(v1053, \"\", v1243);\n\tv1029 = this.yPos + 0x1E;\nL_01E0:\n\tthis.yPos = v1029;\nL_01E1:\n\tv1030 = v123[v115 @ X27_v7 (System.Int32)].info & 0xFF;\n\tv1035 = v1030 == 3;\n\tif (v1035) goto L_0204;\n\tv1073 = v1030 == 2;\n\tif (v1073) goto L_020F;\n\tv1096 = v1030 == 0;\n\tv1097 = ~v1096;\n\tif (v1097) goto L_FFFFFFFF;\n\tv1129 = UnityEngine.GUI;\n\tv1145 = *([v1129 @ X0_v96 (Il2CppClass<UnityEngine.GUI>)+12F]) & 2;\n\tv1146 = v1145 == 0;\n\tv1132 = ~v1146;\n\tif (v1132) goto L_0226;\n\tgoto L_022D;\nL_0204:\n\tv1078 = UnityEngine.GUI;\n\tv1084 = *([v1078 @ X0_v93 (Il2CppClass<UnityEngine.GUI>)+12F]) & 2;\n\tv1085 = v1084 == 0;\n\tv1086 = ~v1085;\n\tif (v1086) goto L_0226;\n\tgoto L_022D;\nL_020F:\n\tv1098 = UnityEngine.GUI;\n\tv1104 = *([v1098 @ X0_v94 (Il2CppClass<UnityEngine.GUI>)+12F]) & 2;\n\tv1105 = v1104 == 0;\n\tv1106 = ~v1105;\n\tif (v1106) goto L_0226;\n\tgoto L_022D;\n\tgoto L_022D;\nL_0226:\n\tgoto L_022D;\n\tv1158 = \"il2cpp_codegen_runtime_class_init\"(v1127, v1022, v992, v82, v80, v57, v58, v59, v1004, v1002, v1000, v998, v203, v201, v199, v67);\nL_022D:\n\t// 557 MakeStruct v876 @ AGGC32574_0_v6 (UnityEngine.Color), typeof(UnityEngine.Color), v1148 @ V12_v10 (UnityEngine.Color), v881 @ V15_v9 (Syst\n// ... truncated")]
		public void OnGUI()
		{
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Expected I4, but got Unknown
			//IL_00b7: Expected O, but got I4
			//IL_00f9: Expected F4, but got O
			//IL_0114: Expected F4, but got O
			//IL_0134: Expected O, but got I4
			//IL_015e: Expected F4, but got O
			//IL_0179: Expected F4, but got O
			//IL_0195: Expected O, but got I4
			//IL_01bf: Expected F4, but got O
			//IL_01da: Expected F4, but got O
			//IL_0226: Expected O, but got I4
			//IL_0249: Expected O, but got I
			//IL_02a3: Expected F4, but got O
			//IL_02be: Expected F4, but got O
			//IL_0303: Expected O, but got I4
			//IL_035b: Expected F4, but got O
			//IL_0376: Expected F4, but got O
			//IL_0442: Expected O, but got I4
			//IL_046c: Expected F4, but got O
			//IL_0487: Expected F4, but got O
			//IL_04a3: Expected O, but got I4
			//IL_04e0: Expected F4, but got O
			//IL_04fb: Expected F4, but got O
			//IL_056b: Expected O, but got I4
			//IL_0595: Expected O, but got I
			//IL_06ca: Expected O, but got I4
			//IL_072b: Expected F4, but got O
			//IL_0746: Expected F4, but got O
			//IL_076c: Expected O, but got I4
			//IL_0907: Expected I, but got O
			//IL_07ae: Expected F4, but got O
			//IL_07c9: Expected F4, but got O
			//IL_09c7: Expected I, but got O
			//IL_0c71: Expected O, but got I
			//IL_0e2a: Expected I4, but got F8
			//IL_0e43: Expected O, but got I4
			//IL_0c3e: Expected O, but got I
			//IL_0848: Expected I, but got O
			//IL_0ce1: Expected F4, but got O
			//IL_0cfc: Expected F4, but got O
			//IL_0d46: Expected O, but got I4
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			Event current = Event.current;
			EventType type = current.type;
			if (type == EventType.Layout)
			{
				UpdateProfilerInfo();
			}
			if (info == null)
			{
				return;
			}
			GUI.skin = skin;
			int width = Screen.width;
			int num = (int)(width / zoom);
			double num2 = frameEnd - frameStart;
			int width2 = Screen.width;
			object obj3 = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			GUIStyle style = "Box";
			Rect position = default(Rect);
			position.x = 0f;
			object obj4 = default(object);
			position.y = (float)obj4;
			position.width = 0f;
			object obj5 = default(object);
			position.height = (float)obj5;
			GUI.BeginGroup(position, "", style);
			object obj6 = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			Rect position2 = default(Rect);
			position2.x = 0f;
			object obj7 = default(object);
			position2.y = (float)obj7;
			position2.width = 0f;
			object obj8 = default(object);
			position2.height = (float)obj8;
			GUI.Label(position2, "Zoom:");
			object obj9 = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			Rect position3 = default(Rect);
			position3.x = 0f;
			object obj10 = default(object);
			position3.y = (float)obj10;
			position3.width = 0f;
			object obj11 = default(object);
			position3.height = (float)obj11;
			float num3 = GUI.HorizontalSlider(position3, zoom, 0.005f, 1f);
			zoom = num3;
			int width3 = Screen.width;
			int num4 = width3 - 100;
			object obj12 = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			object obj13 = (long)(IntPtr)obj2 - 152L;
			double num5 = num2 / 1000.0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @A6632C (inside System.Double::IsNaN +0x448)");
			string text2 = default(string);
			string text = text2 + " ms/frame";
			Rect position4 = default(Rect);
			position4.x = 0f;
			object obj14 = default(object);
			position4.y = (float)obj14;
			position4.width = 0f;
			object obj15 = default(object);
			position4.height = (float)obj15;
			GUI.Label(position4, text);
			GUI.EndGroup();
			int width4 = Screen.width;
			int height = Screen.height;
			int num6 = height - 20;
			object obj16 = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			int num7 = yPos + 30;
			Rect rect = default(Rect);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			Rect position5 = default(Rect);
			position5.x = 0f;
			object obj17 = default(object);
			position5.y = (float)obj17;
			position5.width = 0f;
			object obj18 = default(object);
			position5.height = (float)obj18;
			Vector2 vector = default(Vector2);
			vector.x = scrollPosition.x;
			vector.y = scrollPosition.y;
			Vector2 vector2 = (scrollPosition = GUI.BeginScrollView(position5, vector, default(Rect)));
			scrollPosition.y = vector2.y;
			Color color = default(Color);
			color.r = threadColor.r;
			color.g = threadColor.g;
			color.b = threadColor.b;
			color.a = threadColor.a;
			GUI.color = color;
			object obj19 = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			Rect position6 = default(Rect);
			position6.x = 0f;
			object obj20 = default(object);
			position6.y = (float)obj20;
			position6.width = 0f;
			object obj21 = default(object);
			position6.height = (float)obj21;
			GUI.Label(position6, "Thread 1");
			object obj22 = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			GUIStyle style2 = "Thread";
			Rect position7 = default(Rect);
			position7.x = 0f;
			object obj23 = default(object);
			position7.y = (float)obj23;
			position7.width = 0f;
			object obj24 = default(object);
			position7.height = (float)obj24;
			GUI.Box(position7, "", style2);
			Oni.ProfileInfo[] array = info;
			yPos = 25;
			int num8 = array.Length;
			if (array.Length >= 1)
			{
				int num9 = 0;
				int num10 = 0;
				object obj25 = 0;
				int num11 = 0;
				Color color2 = default(Color);
				Rect position8 = default(Rect);
				Rect position9 = default(Rect);
				Color color4 = default(Color);
				string text8 = default(string);
				Rect position10 = default(Rect);
				bool flag7;
				do
				{
					int num13;
					int num15;
					if (num10 < num8)
					{
						int num12 = num10 << 5;
						object obj26 = (long)(IntPtr)array + (long)num12;
						num13 = (int)array[num10].info >> 16;
						int num14 = (int)array[num10].info >> 8;
						num15 = num14 & 0xFF;
						int num16;
						if (num9 == (int)array[num10].info)
						{
							if (num11 == num15)
							{
								goto IL_0d9a;
							}
							num16 = yPos + 21;
						}
						else
						{
							int num17 = yPos + 21;
							yPos = num17;
							color2.r = threadColor.r;
							color2.g = threadColor.g;
							color2.b = threadColor.b;
							color2.a = threadColor.a;
							GUI.color = color2;
							int num18 = yPos + 5;
							obj3 = 0;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
							int num19 = num13 + 1;
							object obj27 = (uint)num19;
							string text3 = "Thread " + obj27;
							position8.x = 0f;
							position8.y = (float)obj4;
							position8.width = 0f;
							position8.height = (float)obj5;
							GUI.Label(position8, text3);
							int num20 = yPos + 5;
							obj6 = 0;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
							GUIStyle style3 = "Thread";
							position9.x = 0f;
							position9.y = (float)obj7;
							position9.width = 0f;
							position9.height = (float)obj8;
							GUI.Box(position9, "", style3);
							num16 = yPos + 30;
						}
						yPos = num16;
						goto IL_0d9a;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
					IL_0d9a:
					float b;
					float g;
					Color color3;
					float a;
					switch ((int)(array[num10].info & 0xFF))
					{
					case 0:
					{
						IntPtr intPtr2 = (IntPtr)typeof(GUI);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1129 @ X0_v96 (Il2CppClass<UnityEngine.GUI>)+12F]");
						int num22 = 0;
						bool flag3 = num22 == 0;
						bool flag4 = !flag3;
						b = defaultTaskColor.b;
						g = defaultTaskColor.g;
						color3 = defaultTaskColor;
						a = defaultTaskColor.a;
						if (!flag4)
						{
							b = taskColor.b;
							g = taskColor.g;
							color3 = taskColor;
							a = taskColor.a;
						}
						break;
					}
					case 3:
					{
						IntPtr intPtr3 = (IntPtr)typeof(GUI);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1078 @ X0_v93 (Il2CppClass<UnityEngine.GUI>)+12F]");
						int num23 = 0;
						bool flag5 = num23 == 0;
						bool flag6 = !flag5;
						b = taskColor.b;
						g = taskColor.g;
						color3 = taskColor;
						a = taskColor.a;
						if (!flag6)
						{
							b = renderTaskColor.b;
							g = renderTaskColor.g;
							color3 = renderTaskColor;
							a = renderTaskColor.a;
						}
						break;
					}
					case 2:
					{
						IntPtr intPtr = (IntPtr)typeof(GUI);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1098 @ X0_v94 (Il2CppClass<UnityEngine.GUI>)+12F]");
						int num21 = 0;
						bool flag = num21 == 0;
						bool flag2 = !flag;
						b = renderTaskColor.b;
						g = renderTaskColor.g;
						color3 = renderTaskColor;
						a = renderTaskColor.a;
						if (!flag2)
						{
							b = parallelTaskColor.b;
							g = parallelTaskColor.g;
							color3 = parallelTaskColor;
							a = parallelTaskColor.a;
						}
						break;
					}
					default:
						b = defaultTaskColor.b;
						g = defaultTaskColor.g;
						color3 = defaultTaskColor;
						a = defaultTaskColor.a;
						break;
					}
					color4.r = color3.r;
					color4.g = g;
					color4.b = b;
					color4.a = a;
					GUI.color = color4;
					int width5 = Screen.width;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ X10_v8+20]");
					double num24 = 0.0 - frameStart;
					int num25 = width5 - 10;
					double num26 = num24 / num2;
					double num27 = num26 * (double)num25;
					double num28 = num27 / (double)zoom;
					int width6 = Screen.width;
					double num29 = array[num10].end - frameStart;
					int num30 = width6 - 10;
					double num31 = num29 / num2;
					double num32 = num31 * (double)num30;
					double num33 = num32 / (double)zoom;
					double num34 = array[num10].end;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ X10_v8+20]");
					double num35 = num34 - 0.0;
					string text4;
					if (showPercentages)
					{
						double num36 = num35 / num2;
						double num37 = num36 * 100.0;
						object obj28 = (long)(IntPtr)obj2 - 160L;
						text4 = "%)";
						double num38 = 100.0;
						string text5 = "0.#";
					}
					else
					{
						object obj28 = (long)(IntPtr)obj2 - 168L;
						double num37 = num35 / 1000.0;
						text4 = "ms)";
						double num38 = 1000.0;
						string text5 = "0.###";
					}
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @A6632C (inside System.Double::IsNaN +0x448)");
					string text6 = text4;
					string text7 = array[num10].name + " (" + text8 + text4;
					int num39 = (int)(~num28);
					double num40 = (double)num39 + num33;
					obj3 = 0;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
					GUIStyle style4 = "Task";
					position10.x = 0f;
					position10.y = (float)obj4;
					position10.width = 0f;
					position10.height = (float)obj5;
					GUI.Box(position10, text7, style4);
					num8 = array.Length;
					num10++;
					flag7 = num10 < array.Length;
					num9 = num13;
					obj25 = 0;
					num11 = num15;
				}
				while (flag7);
			}
			GUI.EndScrollView();
		}

		[Token(Token = "0x60003C1")]
		[Address(RVA = "0xC32778", Offset = "0xC32778", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EEA428]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023195]) = v42;\nL_0016:\n\tv44 = UnityEngine.Color::get_white();\n\tthis.threadColor = v44;\n\tthis.threadColor.g = v44.g;\n\tthis.threadColor.b = v44.b;\n\tthis.threadColor.a = v44.a;\n\tv54 = 0;\n\tv59 = 0x10105A8(&v54 @ stack_-40_v1 (System.Single), 0, v26, v27, v28, v29, v30, v31, 0.1f, 1f, 0.2f, v44.a, v36, v37, v38, v39);\n\tthis.taskColor.r = 0f;\n\tthis.taskColor.g = v62;\n\tthis.taskColor.a = v64;\n\tv66 = 0;\n\tv73 = 0x10105A8(&v66 @ stack_-50_v1 (System.Single), 0, v26, v27, v28, v29, v30, v31, 1f, 0.8f, 0.2f, v44.a, v36, v37, v38, v39);\n\tthis.parallelTaskColor.r = 0f;\n\tthis.parallelTaskColor.g = v76;\n\tthis.parallelTaskColor.a = v78;\n\tv80 = 0;\n\tv87 = 0x10105A8(&v80 @ stack_-60_v1 (System.Single), 0, v26, v27, v28, v29, v30, v31, 0.2f, 0.7f, 1f, v44.a, v36, v37, v38, v39);\n\tthis.renderTaskColor.r = 0f;\n\tthis.renderTaskColor.g = v90;\n\tthis.renderTaskColor.a = v92;\n\tv95 = 0;\n\tv100 = 0x10105A8(&v95 @ stack_-70_v1 (System.Single), 0, v26, v27, v28, v29, v30, v31, 1f, 0.5f, 0.2f, v44.a, v36, v37, v38, v39);\n\tthis.profileThrottle = 0x1E;\n\tthis.yPos = 0x19;\n\tthis.zoom = 1f;\n\tthis.defaultTaskColor.r = 0f;\n\tthis.defaultTaskColor.g = v103;\n\tthis.defaultTaskColor.a = v105;\n\tgoto L_006F;\n\tv115 = *([v111 @ X0_v11+E0]);\n\tv116 = v115 == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_006F;\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v111, v98, v26, v27, v28, v29, v30, v31, v96, v93, v97, v47, v36, v37, v38, v39);\nL_006F:\n\tv123 = UnityEngine.Vector2::get_zero();\n\tthis.scrollPosition = v123;\n\tthis.scrollPosition.y = v123.y;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiProfiler()
		{
			//IL_01a3: Expected F4, but got O
			//IL_002a: Expected F4, but got O
			//IL_0070: Expected F4, but got O
			//IL_00dc: Expected F4, but got O
			base._002Ector();
			Color color = (threadColor = Color.white);
			threadColor.g = color.g;
			threadColor.b = color.b;
			threadColor.a = color.a;
			float num = 0f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
			taskColor.r = 0f;
			object obj = default(object);
			taskColor.g = (float)obj;
			float a = default(float);
			taskColor.a = a;
			float num2 = 0f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
			parallelTaskColor.r = 0f;
			object obj2 = default(object);
			parallelTaskColor.g = (float)obj2;
			float a2 = default(float);
			parallelTaskColor.a = a2;
			float num3 = 0f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
			renderTaskColor.r = 0f;
			object obj3 = default(object);
			renderTaskColor.g = (float)obj3;
			float a3 = default(float);
			renderTaskColor.a = a3;
			float num4 = 0f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
			profileThrottle = 30;
			yPos = 25;
			zoom = 1f;
			defaultTaskColor.r = 0f;
			object obj4 = default(object);
			defaultTaskColor.g = (float)obj4;
			float a4 = default(float);
			defaultTaskColor.a = a4;
			Vector2 vector = (scrollPosition = Vector2.zero);
			scrollPosition.y = vector.y;
		}
	}
}
