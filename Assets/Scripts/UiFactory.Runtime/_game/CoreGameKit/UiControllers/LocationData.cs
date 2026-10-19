using System;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreGameKit.UiControllers.ScriptableObjects;

namespace _game.CoreGameKit.UiControllers
{
	[Serializable]
	[Token(Token = "0x200001B")]
	public struct LocationData
	{
		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x0")]
		public UILocation UILocation;

		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x8")]
		public RectTransform Root;

		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x10")]
		public Canvas Canvas;
	}
}
