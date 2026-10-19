using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.TextViewSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x200063E")]
	public class LevelTextComponentController : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4001586")]
		[FieldOffset(Offset = "0x20")]
		private TextView m_formattedTextView;

		[Inject(false)]
		[Token(Token = "0x6001AA4")]
		[Address(RVA = "0x3D55CDC", Offset = "0x3D55CDC", Length = "0x58")]
		private void Initialize(LevelContext levelContext)
		{
			string text = levelContext.Level.ToString();
			m_formattedTextView.SetText(text);
		}

		[Token(Token = "0x6001AA5")]
		[Address(RVA = "0x3D55D34", Offset = "0x3D55D34", Length = "0x8")]
		public LevelTextComponentController()
		{
		}
	}
}
