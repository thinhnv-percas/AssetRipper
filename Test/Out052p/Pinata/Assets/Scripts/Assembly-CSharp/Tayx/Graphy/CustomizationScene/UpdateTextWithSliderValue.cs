using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Tayx.Graphy.CustomizationScene
{
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74CB50", Offset = "0x74CB50")]
	[Token(Token = "0x2000047")]
	public class UpdateTextWithSliderValue : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400020F")]
		[FieldOffset(Offset = "0x18")]
		private Slider m_slider;

		[Token(Token = "0x4000210")]
		[FieldOffset(Offset = "0x20")]
		private Text m_text;

		[Token(Token = "0x600021F")]
		[Address(RVA = "0xB12914", Offset = "0xB12914", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1F065F0]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202252F]) = v40;\nL_0018:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tv46 = this.m_slider;\n\tthis.m_text = v45;\n\tv52 = new UnityEngine.Events.UnityAction`1<System.Single>();\n\tUnityEngine.Events.UnityAction`1<System.Single>::.ctor(v52, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Single>::AddListener(v46.m_OnValueChanged, v52);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Text component = GetComponent<Text>();
			Slider slider = m_slider;
			m_text = component;
			UnityAction<float> call = UpdateText;
			slider.onValueChanged.AddListener(call);
		}

		[Token(Token = "0x6000220")]
		[Address(RVA = "0xB129D4", Offset = "0xB129D4", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = &v7 @ stack_-10_v2;\n\t*([v6 @ X29_v1-4]) = value;\n\tv11 = &v7 @ stack_-10_v2 - 4;\n\tv13 = 0xBCCEC8(v11, 0, v14, v15, v16, v17, v18, v19, value, v20, v21, v22, v23, v24, v25, v26);\n\tv33 = UnityEngine.UI.Text::set_text(this.m_text, v13);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateText(float value)
		{
			//IL_001c: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			object obj3 = (long)(IntPtr)obj2 - 4L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCEC8 (inside System.Single::IsNaN +0x2B0)");
			string text = default(string);
			m_text.text = text;
		}

		[Token(Token = "0x6000221")]
		[Address(RVA = "0xB12A24", Offset = "0xB12A24", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UpdateTextWithSliderValue()
		{
		}
	}
}
