using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Tayx.Graphy.Utils.NumString;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Fps
{
	[Token(Token = "0x200003D")]
	public class G_FpsText : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400019E")]
		[FieldOffset(Offset = "0x18")]
		private Text m_fpsText;

		[SerializeField]
		[Token(Token = "0x400019F")]
		[FieldOffset(Offset = "0x20")]
		private Text m_msText;

		[SerializeField]
		[Token(Token = "0x40001A0")]
		[FieldOffset(Offset = "0x28")]
		private Text m_avgFpsText;

		[SerializeField]
		[Token(Token = "0x40001A1")]
		[FieldOffset(Offset = "0x30")]
		private Text m_minFpsText;

		[SerializeField]
		[Token(Token = "0x40001A2")]
		[FieldOffset(Offset = "0x38")]
		private Text m_maxFpsText;

		[Token(Token = "0x40001A3")]
		[FieldOffset(Offset = "0x40")]
		internal GraphyManager m_graphyManager;

		[Token(Token = "0x40001A4")]
		[FieldOffset(Offset = "0x48")]
		private G_FpsMonitor m_fpsMonitor;

		[Token(Token = "0x40001A5")]
		[FieldOffset(Offset = "0x50")]
		internal int m_updateRate;

		[Token(Token = "0x40001A6")]
		[FieldOffset(Offset = "0x54")]
		private int m_frameCount;

		[Token(Token = "0x40001A7")]
		[FieldOffset(Offset = "0x58")]
		private float m_deltaTime;

		[Token(Token = "0x40001A8")]
		[FieldOffset(Offset = "0x5C")]
		private float m_fps;

		[Token(Token = "0x40001A9")]
		private const int m_minFps = 0;

		[Token(Token = "0x40001AA")]
		private const int m_maxFps = 10000;

		[Token(Token = "0x40001AB")]
		private const string m_msStringFormat = "0.0";

		[Token(Token = "0x60001AD")]
		[Address(RVA = "0xB13F1C", Offset = "0xB13F1C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Fps.G_FpsText::Init(this);\n\treturn;\n")]
		private void Awake()
		{
			Init();
		}

		[Token(Token = "0x60001AE")]
		[Address(RVA = "0xB1406C", Offset = "0xB1406C", Length = "0x28C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EDDD80]);\n\tv23 = *([v22 @ X8_v36]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202253A]) = v42;\nL_0017:\n\tv45 = UnityEngine.Time::get_unscaledDeltaTime();\n\tv49 = this.m_deltaTime + v45;\n\tv51 = 1f / this.m_updateRate;\n\tv52 = this.m_frameCount + 1;\n\tthis.m_deltaTime = v49;\n\tthis.m_frameCount = v52;\n\tv64 = v49 <= v51;\n\tif (v64) goto L_00CB;\n\tv66 = v52 / v49;\n\tthis.m_fps = v66;\n\tgoto L_0040;\n\tv103 = *([v70 @ X0_v4+E0]);\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tif (v105) goto L_0040;\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v70, methodInfo, v26, v27, v28, v29, v30, v31, v49, v65, v48, v35, v36, v37, v38, v39);\nL_0040:\n\tv112 = UnityEngine.Mathf::RoundToInt(v66);\n\tgoto L_0051;\n\tv145 = *([v141 @ X8_v12+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0051;\n\tv155 = v141;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v155, methodInfo, v26, v27, v28, v29, v30, v31, v110, v65, v48, v35, v36, v37, v38, v39);\nL_0051:\n\tv154 = Tayx.Graphy.Utils.NumString.G_IntString::ToStringNonAlloc(v112);\n\tv162 = UnityEngine.UI.Text::set_text(this.m_fpsText, v154);\n\tgoto L_006E;\n\tv217 = *([v166 @ X0_v16+E0]);\n\tv218 = v217 == 0;\n\tv219 = ~v218;\n\tif (v219) goto L_006E;\n\tv221 = \"il2cpp_codegen_runtime_class_init\"(v166, v156, v161, v27, v28, v29, v30, v31, v110, v65, v48, v35, v36, v37, v38, v39);\nL_006E:\n\tv88 = this.m_deltaTime / this.m_frameCount;\n\tv182 = v88 * 1000f;\n\tv189 = Tayx.Graphy.Utils.NumString.G_FloatString::ToStringNonAlloc(v182, \"0.0\");\n\tv190 = UnityEngine.UI.Text::set_text(this.m_msText, v189);\n\tv209 = this.m_fpsMonitor;\n\tv214 = this.m_minFpsText;\n\tv233 = Tayx.Graphy.Utils.NumString.G_FloatString::ToInt(v209.m_minFps);\n\tv191 = Tayx.Graphy.Utils.NumString.G_IntString::ToStringNonAlloc(v233);\n\tv192 = UnityEngine.UI.Text::set_text(v214, v191);\n\tv210 = this.m_fpsMonitor;\n\tTayx.Graphy.Fps.G_FpsText::SetFpsRelatedTextColor(this, this.m_minFpsText, v210.m_minFps);\n\tv211 = this.m_fpsMonitor;\n\tv215 = this.m_maxFpsText;\n\tv238 = Tayx.Graphy.Utils.NumString.G_FloatString::ToInt(v211.m_maxFps);\n\tv194 = Tayx.Graphy.Utils.NumString.G_IntString::ToStringNonAlloc(v238);\n\tv195 = UnityEngine.UI.Text::set_text(v215, v194);\n\tv212 = this.m_fpsMonitor;\n\tTayx.Graphy.Fps.G_FpsText::SetFpsRelatedTextColor(this, this.m_maxFpsText, v212.m_maxFps);\n\tv213 = this.m_fpsMonitor;\n\tv96 = this.m_avgFpsText;\n\tv243 = Tayx.Graphy.Utils.NumString.G_FloatString::ToInt(v213.m_avgFps);\n\tv197 = Tayx.Graphy.Utils.NumString.G_IntString::ToStringNonAlloc(v243);\n\tv198 = UnityEngine.UI.Text::set_text(v96, v197);\n\tv94 = this.m_fpsMonitor;\n\tTayx.Graphy.Fps.G_FpsText::SetFpsRelatedTextColor(this, this.m_avgFpsText, v94.m_avgFps);\n\tthis.m_frameCount = 0;\nL_00CB:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 140 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			float num = m_deltaTime + unscaledDeltaTime;
			float num2 = 1f / (float)m_updateRate;
			int num3 = m_frameCount + 1;
			m_deltaTime = num;
			m_frameCount = num3;
			if (num > num2)
			{
				int value = Mathf.RoundToInt(m_fps = (float)num3 / num);
				string text = value.ToStringNonAlloc();
				m_fpsText.text = text;
				float num4 = m_deltaTime / (float)m_frameCount;
				float value2 = num4 * 1000f;
				string text2 = value2.ToStringNonAlloc("0.0");
				m_msText.text = text2;
				G_FpsMonitor fpsMonitor = m_fpsMonitor;
				Text minFpsText = m_minFpsText;
				int value3 = fpsMonitor.MinFPS.ToInt();
				string text3 = value3.ToStringNonAlloc();
				minFpsText.text = text3;
				G_FpsMonitor fpsMonitor2 = m_fpsMonitor;
				SetFpsRelatedTextColor(m_minFpsText, fpsMonitor2.MinFPS);
				G_FpsMonitor fpsMonitor3 = m_fpsMonitor;
				Text maxFpsText = m_maxFpsText;
				int value4 = fpsMonitor3.MaxFPS.ToInt();
				string text4 = value4.ToStringNonAlloc();
				maxFpsText.text = text4;
				G_FpsMonitor fpsMonitor4 = m_fpsMonitor;
				SetFpsRelatedTextColor(m_maxFpsText, fpsMonitor4.MaxFPS);
				G_FpsMonitor fpsMonitor5 = m_fpsMonitor;
				Text avgFpsText = m_avgFpsText;
				int value5 = fpsMonitor5.AverageFPS.ToInt();
				string text5 = value5.ToStringNonAlloc();
				avgFpsText.text = text5;
				G_FpsMonitor fpsMonitor6 = m_fpsMonitor;
				SetFpsRelatedTextColor(m_avgFpsText, fpsMonitor6.AverageFPS);
				m_frameCount = 0;
			}
		}

		[Token(Token = "0x60001AF")]
		[Address(RVA = "0xB139CC", Offset = "0xB139CC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_graphyManager;\n\tthis.m_updateRate = v0.m_fpsTextUpdateRate;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateParameters()
		{
			GraphyManager graphyManager = m_graphyManager;
			m_updateRate = graphyManager.FpsTextUpdateRate;
		}

		[Token(Token = "0x60001B0")]
		[Address(RVA = "0xB142F8", Offset = "0xB142F8", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.m_graphyManager;\n\tv21 = v6.m_goodFpsThreshold >= fps;\n\tif (v21) goto L_0027;\n\tv93 = text->klass;\n\tv91 = v6.m_goodFpsColor;\n\tv114 = v6.m_goodFpsColor.g;\n\tv89 = v6.m_goodFpsColor.b;\n\tv87 = v6.m_goodFpsColor.a;\n\tgoto L_0038;\nL_0027:\n\tv24 = v6.m_cautionFpsThreshold >= fps;\n\tif (v24) goto L_0033;\n\tv93 = text->klass;\n\tv91 = v6.m_cautionFpsColor;\n\tv114 = v6.m_cautionFpsColor.g;\n\tv89 = v6.m_cautionFpsColor.b;\n\tv87 = v6.m_cautionFpsColor.a;\n\tgoto L_0038;\nL_0033:\n\tv93 = text->klass;\n\tv91 = v6.m_criticalFpsColor;\n\tv114 = v6.m_criticalFpsColor.g;\n\tv89 = v6.m_criticalFpsColor.b;\n\tv87 = v6.m_criticalFpsColor.a;\nL_0038:\n\tv118 = text->klass->vtable[23];\n\tv83 = text->klass->vtable[23];\n\t// 63 IndirectJump v83 @ X2_v1, text @ X1 (UnityEngine.UI.Text), text @ X1 (UnityEngine.UI.Text), v118 @ X8_v2, v83 @ X2_v1, v60 @ X3, v61 @ X4, v62 @ X5, v63 @ X6, v64 @ X7, v91 @ V0_v1 (UnityEngine.Color), v114 @ V1_v4 (System.Single), v89 @ V2_v1 (System.Single), v87 @ V3_v1 (System.Single), v67 @ V4, v68 @ V5, v69 @ V6, v70 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetFpsRelatedTextColor(Text text, float fps)
		{
			//IL_0103: Expected I, but got O
			//IL_003d: Expected I, but got O
			//IL_015b: Expected O, but got I
			//IL_016b: Expected O, but got I
			//IL_00b3: Expected I, but got O
			GraphyManager graphyManager = m_graphyManager;
			if ((float)graphyManager.GoodFPSThreshold < fps)
			{
				IntPtr intPtr = (IntPtr)text;
				Color goodFpsColor = graphyManager.m_goodFpsColor;
				float g = graphyManager.m_goodFpsColor.g;
				float b = graphyManager.m_goodFpsColor.b;
				float a = graphyManager.m_goodFpsColor.a;
			}
			else if ((float)graphyManager.CautionFPSThreshold < fps)
			{
				IntPtr intPtr = (IntPtr)text;
				Color goodFpsColor = graphyManager.m_cautionFpsColor;
				float g = graphyManager.m_cautionFpsColor.g;
				float b = graphyManager.m_cautionFpsColor.b;
				float a = graphyManager.m_cautionFpsColor.a;
			}
			else
			{
				IntPtr intPtr = (IntPtr)text;
				Color goodFpsColor = graphyManager.m_criticalFpsColor;
				float g = graphyManager.m_criticalFpsColor.g;
				float b = graphyManager.m_criticalFpsColor.b;
				float a = graphyManager.m_criticalFpsColor.a;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ X9_v1 (Il2CppClass<UnityEngine.UI.Text>)+2A8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ X9_v1 (Il2CppClass<UnityEngine.UI.Text>)+2A0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v83 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001B1")]
		[Address(RVA = "0xB13F20", Offset = "0xB13F20", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F09010]);\n\tv19 = *([v18 @ X8_v27]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202253B]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = Tayx.Graphy.Utils.NumString.G_IntString::get_Inited();\n\tv55 = v53 == 0;\n\tif (v55) goto L_005B;\n\tgoto L_002F;\n\tv113 = *([v56 @ X0_v24+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_002F;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv102 = Tayx.Graphy.Utils.NumString.G_IntString::get_MinValue();\n\tv67 = v102 > 0;\n\tif (v67) goto L_005B;\n\tgoto L_0048;\n\tv154 = *([v149 @ X0_v28+E0]);\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_0048;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v149, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0048:\n\tv101 = Tayx.Graphy.Utils.NumString.G_IntString::get_MaxValue();\n\tv65 = v101 > 0x270F;\n\tif (v65) goto L_0067;\nL_005B:\n\tgoto L_0064;\n\tv119 = *([v109 @ X0_v20+E0]);\n\tv120 = v119 == 0;\n\tv121 = ~v120;\n\tif (v121) goto L_0064;\n\tv123 = \"il2cpp_codegen_runtime_class_init\"(v109, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0064:\n\tTayx.Graphy.Utils.NumString.G_IntString::Init(0, 0x2710);\nL_0067:\n\tv148 = UnityEngine.Component::get_transform(this);\n\tv162 = UnityEngine.Transform::get_root(v148);\n\tv183 = UnityEngine.Component::GetComponentInChildren(v162);\n\tthis.m_graphyManager = v183;\n\tv173 = UnityEngine.Component::GetComponent(this);\n\tv177 = this.m_graphyManager;\n\tthis.m_fpsMonitor = v173;\n\tthis.m_updateRate = v177.m_fpsTextUpdateRate;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Init()
		{
			if (G_IntString.Inited)
			{
				int minValue = G_IntString.MinValue;
				if (minValue <= 0)
				{
					int maxValue = G_IntString.MaxValue;
					if (maxValue > 9999)
					{
						goto IL_009a;
					}
				}
			}
			G_IntString.Init(0, 10000);
			goto IL_009a;
			IL_009a:
			Transform transform = base.transform;
			Transform root = transform.root;
			GraphyManager componentInChildren = root.GetComponentInChildren<GraphyManager>();
			m_graphyManager = componentInChildren;
			G_FpsMonitor component = GetComponent<G_FpsMonitor>();
			GraphyManager graphyManager = m_graphyManager;
			m_fpsMonitor = component;
			m_updateRate = graphyManager.FpsTextUpdateRate;
		}

		[Token(Token = "0x60001B2")]
		[Address(RVA = "0xB14380", Offset = "0xB14380", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_updateRate = 4;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_FpsText()
		{
			m_updateRate = 4;
		}
	}
}
