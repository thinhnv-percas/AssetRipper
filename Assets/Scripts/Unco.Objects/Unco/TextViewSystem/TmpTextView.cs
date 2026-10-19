using AssetRipperInjected;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace Unco.TextViewSystem
{
	[Token(Token = "0x200001D")]
	public class TmpTextView : TextView
	{
		[SerializeField]
		[Token(Token = "0x4000079")]
		[FieldOffset(Offset = "0x20")]
		private TMP_Text m_tmpText;

		[Token(Token = "0x600006C")]
		[Address(RVA = "0x81C29D8", Offset = "0x81C29D8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv46 = UnityEngine.Component::GetComponent(this);\n\tthis.m_tmpText = v46;\n\treturn;\n")]
		private void Reset()
		{
			TMP_Text component = GetComponent<TMP_Text>();
			m_tmpText = component;
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0x81C2A3C", Offset = "0x81C2A3C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTMPro.TMP_Text::SetText(this.m_tmpText, text);\n\treturn;\n")]
		public override void SetText(string text)
		{
			m_tmpText.SetText(text);
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x81C2A58", Offset = "0x81C2A58", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_tmpText;\n\tv0 = TMPro.TMP_Text::get_text(v0);\n\treturn v0;\n")]
		public override string GetText()
		{
			TMP_Text tmpText = m_tmpText;
			return tmpText.text;
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x81C2A7C", Offset = "0x81C2A7C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = TMPro.TMP_Text::set_color(v4, Color_arg);\n\treturn;\n")]
		public override void SetColor(Color color)
		{
			TMP_Text tMP_Text = default(TMP_Text);
			Color color2 = default(Color);
			tMP_Text.color = color2;
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x81C2AA0", Offset = "0x81C2AA0", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_tmpText;\n\tv0 = TMPro.TMP_Text::get_color(v0);\n\treturn v0;\n")]
		public override Color GetColor()
		{
			TMP_Text tmpText = m_tmpText;
			return tmpText.color;
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x81C2AC4", Offset = "0x81C2AC4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public TmpTextView()
		{
		}
	}
}
