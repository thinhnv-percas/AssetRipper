using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Tayx.Graphy.Utils.NumString;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Audio
{
	[Token(Token = "0x2000041")]
	public class G_AudioText : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x40001CB")]
		[FieldOffset(Offset = "0x18")]
		private Text m_DBText;

		[Token(Token = "0x40001CC")]
		[FieldOffset(Offset = "0x20")]
		internal GraphyManager m_graphyManager;

		[Token(Token = "0x40001CD")]
		[FieldOffset(Offset = "0x28")]
		private G_AudioMonitor m_audioMonitor;

		[Token(Token = "0x40001CE")]
		[FieldOffset(Offset = "0x30")]
		internal int m_updateRate;

		[Token(Token = "0x40001CF")]
		[FieldOffset(Offset = "0x34")]
		private float m_deltaTimeOffset;

		[Token(Token = "0x60001D2")]
		[Address(RVA = "0xB0E9DC", Offset = "0xB0E9DC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Audio.G_AudioText::Init(this);\n\treturn;\n")]
		private void Awake()
		{
			Init();
		}

		[Token(Token = "0x60001D3")]
		[Address(RVA = "0xB0EB44", Offset = "0xB0EB44", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EF5448]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202250A]) = v40;\nL_0017:\n\tv43 = Tayx.Graphy.Audio.G_AudioMonitor::get_SpectrumDataAvailable(this.m_audioMonitor);\n\tv46 = v43 == 0;\n\tif (v46) goto L_006D;\n\tv88 = 1f / this.m_updateRate;\n\tv56 = this.m_deltaTimeOffset <= v88;\n\tif (v56) goto L_0064;\n\tv98 = this.m_audioMonitor;\n\tthis.m_deltaTimeOffset = 0f;\n\tv96 = this.m_DBText;\n\tgoto L_0044;\n\tv167 = *([v164 @ X0_v10+E0]);\n\tv168 = v167 == 0;\n\tv169 = ~v168;\n\tif (v169) goto L_0044;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v164, methodInfo, v24, v25, v26, v27, v28, v29, v88, v82, v32, v33, v34, v35, v36, v37);\nL_0044:\n\tv177 = UnityEngine.Mathf::Clamp(v98.m_maxDB, -80f, 0f);\n\tgoto L_0054;\n\tv184 = *([v180 @ X0_v13+E0]);\n\tv185 = v184 == 0;\n\tv186 = ~v185;\n\tif (v186) goto L_0054;\n\tv188 = \"il2cpp_codegen_runtime_class_init\"(v180, methodInfo, v24, v25, v26, v27, v28, v29, v177, v83, v50, v33, v34, v35, v36, v37);\nL_0054:\n\tv91 = Tayx.Graphy.Utils.NumString.G_FloatString::ToStringNonAlloc(v177);\n\tv156 = *([v96 @ X19_v4 (UnityEngine.UI.Text)]);\n\tv131 = *([v156 @ X8_v11 (Il2CppClass<UnityEngine.UI.Text>)+5C0]);\n\tv129 = *([v156 @ X8_v11 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\t// 98 IndirectJump v131 @ X3_v1, v96 @ X19_v4 (UnityEngine.UI.Text), v96 @ X19_v4 (UnityEngine.UI.Text), v91 @ X0_v16 (System.String), v129 @ X2_v1, v131 @ X3_v1, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v177 @ V0_v9 (System.Single), -80f, 0, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\nL_0064:\n\tv127 = UnityEngine.Time::get_deltaTime();\n\tv119 = this.m_deltaTimeOffset + v127;\n\tthis.m_deltaTimeOffset = v119;\nL_006D:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_00ca: Expected I, but got O
			//IL_00da: Expected O, but got I
			//IL_00ea: Expected O, but got I
			if (m_audioMonitor.SpectrumDataAvailable)
			{
				float num = 1f / (float)m_updateRate;
				if (m_deltaTimeOffset > num)
				{
					G_AudioMonitor audioMonitor = m_audioMonitor;
					m_deltaTimeOffset = 0f;
					Text dBText = m_DBText;
					float value = Mathf.Clamp(audioMonitor.MaxDB, -80f, 0f);
					string text = value.ToStringNonAlloc();
					IntPtr intPtr = (IntPtr)dBText;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X8_v11 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X8_v11 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v131 @ X3_v1 (should have been resolved before IL gen)");
				}
				float deltaTime = Time.deltaTime;
				float deltaTimeOffset = m_deltaTimeOffset + deltaTime;
				m_deltaTimeOffset = deltaTimeOffset;
			}
		}

		[Token(Token = "0x60001D4")]
		[Address(RVA = "0xB0E300", Offset = "0xB0E300", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_graphyManager;\n\tthis.m_updateRate = v0.m_audioTextUpdateRate;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateParameters()
		{
			GraphyManager graphyManager = m_graphyManager;
			m_updateRate = graphyManager.AudioTextUpdateRate;
		}

		[Token(Token = "0x60001D5")]
		[Address(RVA = "0xB0E9E0", Offset = "0xB0E9E0", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBDA38]);\n\tv19 = *([v18 @ X8_v29]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202250B]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = Tayx.Graphy.Utils.NumString.G_FloatString::get_Inited();\n\tv55 = v53 == 0;\n\tif (v55) goto L_005C;\n\tgoto L_002F;\n\tv118 = *([v56 @ X0_v24+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_002F;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv104 = Tayx.Graphy.Utils.NumString.G_FloatString::get_MinValue();\n\tv66 = v104 > -1000f;\n\tif (v66) goto L_005C;\n\tgoto L_004A;\n\tv165 = *([v160 @ X0_v27+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tif (v167) goto L_004A;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v160, methodInfo, v22, v23, v24, v25, v26, v27, v104, v101, v30, v31, v32, v33, v34, v35);\nL_004A:\n\tv103 = Tayx.Graphy.Utils.NumString.G_FloatString::get_MaxValue();\n\tv64 = v103 >= 16384f;\n\tif (v64) goto L_006B;\nL_005C:\n\tgoto L_0068;\n\tv124 = *([v114 @ X0_v20+E0]);\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_0068;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v114, methodInfo, v22, v23, v24, v25, v26, v27, v102, v99, v30, v31, v32, v33, v34, v35);\nL_0068:\n\tTayx.Graphy.Utils.NumString.G_FloatString::Init(-1001f, 16386f, 1);\nL_006B:\n\tv159 = UnityEngine.Component::get_transform(this);\n\tv172 = UnityEngine.Transform::get_root(v159);\n\tv192 = UnityEngine.Component::GetComponentInChildren(v172);\n\tthis.m_graphyManager = v192;\n\tv182 = UnityEngine.Component::GetComponent(this);\n\tv186 = this.m_graphyManager;\n\tthis.m_audioMonitor = v182;\n\tthis.m_updateRate = v186.m_audioTextUpdateRate;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Init()
		{
			if (G_FloatString.Inited)
			{
				float minValue = G_FloatString.MinValue;
				if (!(minValue > -1000f))
				{
					float maxValue = G_FloatString.MaxValue;
					if (!(maxValue < 16384f))
					{
						goto IL_00a6;
					}
				}
			}
			G_FloatString.Init(-1001f, 16386f);
			goto IL_00a6;
			IL_00a6:
			Transform transform = base.transform;
			Transform root = transform.root;
			GraphyManager componentInChildren = root.GetComponentInChildren<GraphyManager>();
			m_graphyManager = componentInChildren;
			G_AudioMonitor component = GetComponent<G_AudioMonitor>();
			GraphyManager graphyManager = m_graphyManager;
			m_audioMonitor = component;
			m_updateRate = graphyManager.AudioTextUpdateRate;
		}

		[Token(Token = "0x60001D6")]
		[Address(RVA = "0xB0EC74", Offset = "0xB0EC74", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_updateRate = 4;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_AudioText()
		{
			m_updateRate = 4;
		}
	}
}
