using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	[RequireComponent(typeof(CanvasRenderer))]
	[Token(Token = "0x2000078")]
	public class TMP_SelectionCaret : MaskableGraphic
	{
		[Token(Token = "0x60003CA")]
		[Address(RVA = "0x16081B4", Offset = "0x16081B4", Length = "0xD0")]
		public override void Cull(Rect clipRect, bool validRect)
		{
		}

		[Token(Token = "0x60003CB")]
		[Address(RVA = "0x1608284", Offset = "0x1608284", Length = "0x4")]
		protected override void UpdateGeometry()
		{
		}

		[Token(Token = "0x60003CC")]
		[Address(RVA = "0x1608288", Offset = "0x1608288", Length = "0x8")]
		public TMP_SelectionCaret()
		{
		}
	}
}
