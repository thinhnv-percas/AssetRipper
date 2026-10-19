using Cpp2ILInjected;
using TMPro;
using Unco.Objects;
using UnityEngine;

namespace _game.Systems.RewardSystem.UnityBindings
{
	[Token(Token = "0x200073B")]
	public class FormattableText : MonoBehaviour
	{
		[SerializeField]
		[TextArea]
		[Token(Token = "0x4001830")]
		[FieldOffset(Offset = "0x20")]
		private string m_format;

		[SerializeField]
		[Token(Token = "0x4001831")]
		[FieldOffset(Offset = "0x28")]
		private TMP_Text m_text;

		[Token(Token = "0x170002E8")]
		public TMP_Text TMP
		{
			[Token(Token = "0x6001E76")]
			[Address(RVA = "0x3D851CC", Offset = "0x3D851CC", Length = "0x8")]
			get
			{
				return m_text;
			}
		}

		[Token(Token = "0x6001E77")]
		[Address(RVA = "0x3D851D4", Offset = "0x3D851D4", Length = "0x64")]
		private void Reset()
		{
			UncoTMP component = GetComponent<UncoTMP>();
			m_text = component;
		}

		[Token(Token = "0x6001E78")]
		[Address(RVA = "0x3D85238", Offset = "0x3D85238", Length = "0x38")]
		public void SetText(params object[] args)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FormattableText::SetText");
		}

		[Token(Token = "0x6001E79")]
		[Address(RVA = "0x3D85270", Offset = "0x3D85270", Length = "0x40")]
		public void SetTextWithFormat(string format, params object[] args)
		{
			string text = string.Format(format, args);
			TMP.SetText(text);
		}

		[Token(Token = "0x6001E7A")]
		[Address(RVA = "0x3D852B0", Offset = "0x3D852B0", Length = "0x8")]
		public FormattableText()
		{
		}
	}
}
