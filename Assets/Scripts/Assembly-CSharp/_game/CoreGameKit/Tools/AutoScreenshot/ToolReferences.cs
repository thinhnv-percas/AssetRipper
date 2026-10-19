using AlmostEngine.Screenshot;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tools.AutoScreenshot
{
	[Token(Token = "0x20005D3")]
	public class ToolReferences : MonoBehaviour
	{
		[Token(Token = "0x400143A")]
		[FieldOffset(Offset = "0x20")]
		public ScreenshotManager ScreenshotManager;

		[Token(Token = "0x600191D")]
		[Address(RVA = "0x3D451A0", Offset = "0x3D451A0", Length = "0x8")]
		public ToolReferences()
		{
		}
	}
}
