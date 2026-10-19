using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.PlayMode
{
	[Token(Token = "0x20003E1")]
	public sealed class PathPlaybackOverlay : MonoBehaviour
	{
		[Token(Token = "0x4000C42")]
		[FieldOffset(Offset = "0x20")]
		public Action StepPressed;

		[Token(Token = "0x4000C43")]
		[FieldOffset(Offset = "0x28")]
		public Action AutoToggled;

		[Token(Token = "0x4000C44")]
		[FieldOffset(Offset = "0x30")]
		public Func<bool> IsAutoOn;

		[Token(Token = "0x4000C45")]
		[FieldOffset(Offset = "0x38")]
		public Func<string> StatusText;

		[Token(Token = "0x4000C46")]
		[FieldOffset(Offset = "0x40")]
		private GUIStyle _label;

		[Token(Token = "0x4000C47")]
		[FieldOffset(Offset = "0x48")]
		private GUIStyle _button;

		[Token(Token = "0x6001056")]
		[Address(RVA = "0x3CB1CC0", Offset = "0x3CB1CC0", Length = "0x5C8")]
		private void OnGUI()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PathPlaybackOverlay::OnGUI");
		}

		[Token(Token = "0x6001057")]
		[Address(RVA = "0x3CB2288", Offset = "0x3CB2288", Length = "0x8")]
		public PathPlaybackOverlay()
		{
		}
	}
}
