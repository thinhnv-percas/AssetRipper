using Cpp2ILInjected;
using Unco.TextViewSystem;
using Unco.UText.Runtime.Components;
using UnityEngine;

namespace Unco.UText.External.TextViewSystem
{
	[Token(Token = "0x20007C5")]
	public class UTextView : TextView
	{
		[SerializeField]
		[Token(Token = "0x4001A03")]
		[FieldOffset(Offset = "0x20")]
		private UTextGUI m_uText;

		[Token(Token = "0x60020D3")]
		[Address(RVA = "0x3DBD328", Offset = "0x3DBD328", Length = "0x64")]
		private void Reset()
		{
			UTextGUI component = GetComponent<UTextGUI>();
			m_uText = component;
		}

		[Token(Token = "0x60020D4")]
		[Address(RVA = "0x3DBD38C", Offset = "0x3DBD38C", Length = "0x68")]
		public override void SetText(string text)
		{
			UTextGUI uText = m_uText;
			if (!(uText.m_text == text))
			{
				uText.m_text = text;
				uText.MarkDirty();
			}
		}

		[Token(Token = "0x60020D5")]
		[Address(RVA = "0x3DBD3F4", Offset = "0x3DBD3F4", Length = "0x1C")]
		public override string GetText()
		{
			UTextGUI uText = m_uText;
			return uText.m_text;
		}

		[Token(Token = "0x60020D6")]
		[Address(RVA = "0x3DBD410", Offset = "0x3DBD410", Length = "0x24")]
		public override void SetColor(Color color)
		{
			UTextGUI uTextGUI = default(UTextGUI);
			Color color2 = default(Color);
			uTextGUI.color = color2;
		}

		[Token(Token = "0x60020D7")]
		[Address(RVA = "0x3DBD434", Offset = "0x3DBD434", Length = "0x24")]
		public override Color GetColor()
		{
			UTextGUI uText = m_uText;
			return uText.color;
		}

		[Token(Token = "0x60020D8")]
		[Address(RVA = "0x3DBD458", Offset = "0x3DBD458", Length = "0x8")]
		public UTextView()
		{
		}
	}
}
