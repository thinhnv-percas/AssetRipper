using AssetRipperInjected;
using Cpp2ILInjected;
using TMPro;
using Unco.Objects;
using UnityEngine;

namespace Unco.RewardSystem.UnityBindings
{
	[Token(Token = "0x2000025")]
	public class FormattableText : MonoBehaviour
	{
		[SerializeField]
		[TextArea]
		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x20")]
		private string m_format;

		[SerializeField]
		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x28")]
		private TMP_Text m_text;

		[Token(Token = "0x1700000D")]
		public TMP_Text TMP
		{
			[Token(Token = "0x600008E")]
			[Address(RVA = "0x81D980C", Offset = "0x81D980C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.TMP;\n")]
			get
			{
				return m_text;
			}
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x81D9814", Offset = "0x81D9814", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv46 = UnityEngine.Component::GetComponent(this);\n\tthis.TMP = v46;\n\treturn;\n")]
		private void Reset()
		{
			UncoTMP component = GetComponent<UncoTMP>();
			m_text = component;
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x81D9878", Offset = "0x81D9878", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.m_format;\n\tv14 = System.String::Format(this.m_format, args);\n\tTMPro.TMP_Text::SetText(*([v10 @ X0_v1 (System.String)+28]), v14);\n\treturn;\n")]
		public void SetText(params object[] args)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FormattableText::SetText");
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x81D98B0", Offset = "0x81D98B0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = System.String::Format(format, args);\n\tTMPro.TMP_Text::SetText(this.TMP, v17);\n\treturn;\n")]
		public void SetTextWithFormat(string format, params object[] args)
		{
			string text = string.Format(format, args);
			TMP.SetText(text);
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x81D98F0", Offset = "0x81D98F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public FormattableText()
		{
		}
	}
}
