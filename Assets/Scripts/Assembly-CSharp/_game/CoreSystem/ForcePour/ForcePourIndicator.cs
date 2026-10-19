using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.CoreSystem.ForcePour
{
	[Token(Token = "0x2000505")]
	public class ForcePourIndicator : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x40010CC")]
		[FieldOffset(Offset = "0x20")]
		private Transform m_animTarget;

		[SerializeField]
		[Token(Token = "0x40010CD")]
		[FieldOffset(Offset = "0x28")]
		private ShakeSettings m_punchSettings;

		[Token(Token = "0x60014FE")]
		[Address(RVA = "0x3D0ADA4", Offset = "0x3D0ADA4", Length = "0x44")]
		private void Start()
		{
			ShakeSettings punchSettings = m_punchSettings;
			Tween tween = Tween.PunchLocalPosition(m_animTarget, punchSettings);
		}

		[Token(Token = "0x60014FF")]
		[Address(RVA = "0x3D0ADE8", Offset = "0x3D0ADE8", Length = "0x8")]
		public ForcePourIndicator()
		{
		}
	}
}
