using AssetRipperInjected;
using Cpp2ILInjected;
using Tayx.Graphy.Utils.NumString;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Ram
{
	[Token(Token = "0x2000038")]
	public class G_RamText : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000173")]
		[FieldOffset(Offset = "0x18")]
		private Text m_allocatedSystemMemorySizeText;

		[SerializeField]
		[Token(Token = "0x4000174")]
		[FieldOffset(Offset = "0x20")]
		private Text m_reservedSystemMemorySizeText;

		[SerializeField]
		[Token(Token = "0x4000175")]
		[FieldOffset(Offset = "0x28")]
		private Text m_monoSystemMemorySizeText;

		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x30")]
		private GraphyManager m_graphyManager;

		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x38")]
		private G_RamMonitor m_ramMonitor;

		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x40")]
		private float m_updateRate;

		[Token(Token = "0x4000179")]
		[FieldOffset(Offset = "0x44")]
		private float m_deltaTime;

		[Token(Token = "0x400017A")]
		[FieldOffset(Offset = "0x48")]
		private readonly string m_memoryStringFormat;

		[Token(Token = "0x6000189")]
		[Address(RVA = "0x164365C", Offset = "0x164365C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Ram.G_RamText::Init(this);\n\treturn;\n")]
		private void Awake()
		{
			Init();
		}

		[Token(Token = "0x600018A")]
		[Address(RVA = "0x16437A0", Offset = "0x16437A0", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EDD8E0]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202AB0D]) = v42;\nL_0017:\n\tv45 = UnityEngine.Time::get_unscaledDeltaTime();\n\tv48 = this.m_deltaTime + v45;\n\tthis.m_deltaTime = v48;\n\tv49 = 1f / this.m_updateRate;\n\tv61 = v48 <= v49;\n\tif (v61) goto L_006D;\n\tv62 = this.m_ramMonitor;\n\tgoto L_003E;\n\tv144 = *([v94 @ X0_v7+E0]);\n\tv145 = v144 == 0;\n\tv146 = ~v145;\n\tif (v146) goto L_003E;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v94, methodInfo, v26, v27, v28, v29, v30, v31, v48, v49, v47, v35, v36, v37, v38, v39);\nL_003E:\n\tv113 = Tayx.Graphy.Utils.NumString.G_FloatString::ToStringNonAlloc(v62.m_allocatedRam, this.m_memoryStringFormat);\n\tv114 = UnityEngine.UI.Text::set_text(this.m_allocatedSystemMemorySizeText, v113);\n\tv125 = this.m_ramMonitor;\n\tv115 = Tayx.Graphy.Utils.NumString.G_FloatString::ToStringNonAlloc(v125.m_reservedRam, this.m_memoryStringFormat);\n\tv116 = UnityEngine.UI.Text::set_text(this.m_reservedSystemMemorySizeText, v115);\n\tv126 = this.m_ramMonitor;\n\tv117 = Tayx.Graphy.Utils.NumString.G_FloatString::ToStringNonAlloc(v126.m_monoRam, this.m_memoryStringFormat);\n\tv78 = UnityEngine.UI.Text::set_text(this.m_monoSystemMemorySizeText, v117);\n\tthis.m_deltaTime = 0f;\nL_006D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			float num = (m_deltaTime += unscaledDeltaTime);
			float num2 = 1f / m_updateRate;
			if (num > num2)
			{
				G_RamMonitor ramMonitor = m_ramMonitor;
				string text = ramMonitor.AllocatedRam.ToStringNonAlloc(m_memoryStringFormat);
				m_allocatedSystemMemorySizeText.text = text;
				G_RamMonitor ramMonitor2 = m_ramMonitor;
				string text2 = ramMonitor2.ReservedRam.ToStringNonAlloc(m_memoryStringFormat);
				m_reservedSystemMemorySizeText.text = text2;
				G_RamMonitor ramMonitor3 = m_ramMonitor;
				string text3 = ramMonitor3.MonoRam.ToStringNonAlloc(m_memoryStringFormat);
				m_monoSystemMemorySizeText.text = text3;
				m_deltaTime = 0f;
			}
		}

		[Token(Token = "0x600018B")]
		[Address(RVA = "0x164333C", Offset = "0x164333C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.m_graphyManager;\n\tv45 = UnityEngine.UI.Graphic::set_color(this.m_allocatedSystemMemorySizeText, Color_arg);\n\tv53 = this.m_graphyManager;\n\tv46 = UnityEngine.UI.Graphic::set_color(this.m_reservedSystemMemorySizeText, Color_arg);\n\tv54 = this.m_graphyManager;\n\tv47 = UnityEngine.UI.Graphic::set_color(this.m_monoSystemMemorySizeText, Color_arg);\n\tv55 = this.m_graphyManager;\n\tthis.m_updateRate = v55.m_ramTextUpdateRate;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateParameters()
		{
			//IL_018c: Expected F4, but got I4
			GraphyManager graphyManager = m_graphyManager;
			Color color = default(Color);
			color.r = graphyManager.m_allocatedRamColor.r;
			color.g = graphyManager.m_allocatedRamColor.g;
			color.b = graphyManager.m_allocatedRamColor.b;
			color.a = graphyManager.m_allocatedRamColor.a;
			m_allocatedSystemMemorySizeText.color = color;
			GraphyManager graphyManager2 = m_graphyManager;
			Color color2 = default(Color);
			color2.r = graphyManager2.m_reservedRamColor.r;
			color2.g = graphyManager2.m_reservedRamColor.g;
			color2.b = graphyManager2.m_reservedRamColor.b;
			color2.a = graphyManager2.m_reservedRamColor.a;
			m_reservedSystemMemorySizeText.color = color2;
			GraphyManager graphyManager3 = m_graphyManager;
			Color color3 = default(Color);
			color3.r = graphyManager3.m_monoRamColor.r;
			color3.g = graphyManager3.m_monoRamColor.g;
			color3.b = graphyManager3.m_monoRamColor.b;
			color3.a = graphyManager3.m_monoRamColor.a;
			m_monoSystemMemorySizeText.color = color3;
			GraphyManager graphyManager4 = m_graphyManager;
			m_updateRate = graphyManager4.RamTextUpdateRate;
		}

		[Token(Token = "0x600018C")]
		[Address(RVA = "0x1643660", Offset = "0x1643660", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB1AC8]);\n\tv19 = *([v18 @ X8_v26]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AB0E]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = Tayx.Graphy.Utils.NumString.G_FloatString::get_Inited();\n\tv54 = v52 == 0;\n\tif (v54) goto L_0059;\n\tgoto L_002D;\n\tv117 = *([v55 @ X0_v21 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_002D;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tv103 = Tayx.Graphy.Utils.NumString.G_FloatString::get_MinValue();\n\tv65 = v103 > -1000f;\n\tif (v65) goto L_0059;\n\tgoto L_0047;\n\tv161 = *([v156 @ X0_v23 (Il2CppClass<Tayx.Graphy.Utils.NumString.G_FloatString>)+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_0047;\n\tv164 = \"il2cpp_codegen_runtime_class_init\"(v156, methodInfo, v22, v23, v24, v25, v26, v27, v103, v100, v30, v31, v32, v33, v34, v35);\nL_0047:\n\tv102 = Tayx.Graphy.Utils.NumString.G_FloatString::get_MaxValue();\n\tv63 = v102 >= 16384f;\n\tif (v63) goto L_0067;\nL_0059:\n\tgoto L_0064;\n\tv122 = *([v113 @ X0_v17+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_0064;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v113, methodInfo, v22, v23, v24, v25, v26, v27, v101, v98, v30, v31, v32, v33, v34, v35);\nL_0064:\n\tTayx.Graphy.Utils.NumString.G_FloatString::Init(-1001f, 16386f, 1);\nL_0067:\n\tv155 = UnityEngine.Component::get_transform(this);\n\tv167 = UnityEngine.Transform::get_root(v155);\n\tv177 = UnityEngine.Component::GetComponentInChildren(v167);\n\tthis.m_graphyManager = v177;\n\tv195 = UnityEngine.Component::GetComponent(this);\n\tthis.m_ramMonitor = v195;\n\tTayx.Graphy.Ram.G_RamText::UpdateParameters(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			G_RamMonitor component = GetComponent<G_RamMonitor>();
			m_ramMonitor = component;
			UpdateParameters();
		}

		[Token(Token = "0x600018D")]
		[Address(RVA = "0x1643F38", Offset = "0x1643F38", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE7958]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AB0F]) = v38;\nL_0014:\n\tthis.m_updateRate = 4f;\n\tthis.m_memoryStringFormat = \"0.0\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_RamText()
		{
			m_updateRate = 4f;
			m_memoryStringFormat = "0.0";
		}
	}
}
