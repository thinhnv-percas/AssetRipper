using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7606B0", Offset = "0x7606B0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7606B0", Offset = "0x7606B0")]
	[Token(Token = "0x20003B5")]
	public class UiCanvasForceUpdateCanvases : FsmStateAction
	{
		[Token(Token = "0x6001281")]
		[Address(RVA = "0x9A344C", Offset = "0x9A344C", Length = "0x2C")]
		public override void OnEnter()
		{
			Canvas.ForceUpdateCanvases();
			Finish();
		}

		[Token(Token = "0x6001282")]
		[Address(RVA = "0x9A3478", Offset = "0x9A3478", Length = "0x8")]
		public UiCanvasForceUpdateCanvases()
		{
		}
	}
}
