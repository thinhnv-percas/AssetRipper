using System;
using Cpp2ILInjected;
using Morpeh;
using UnityEngine;
using UnityEngine.UI;

namespace GBG.Pinata.ECS.UI.Components
{
	[Serializable]
	[Token(Token = "0x2000046")]
	public struct ProgressIndicatorComponent : IComponent
	{
		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0x0")]
		public Image ProgressImage;

		[Token(Token = "0x40000D1")]
		[FieldOffset(Offset = "0x8")]
		public Image BackgroundProgressBar;

		[Token(Token = "0x40000D2")]
		[FieldOffset(Offset = "0x10")]
		public Sprite StartedBar;

		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0x18")]
		public Sprite FinishedBar;
	}
}
