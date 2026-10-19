using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts
{
	[Serializable]
	[Token(Token = "0x2000189")]
	public struct JellyMaterialPair
	{
		[Token(Token = "0x40004DB")]
		[FieldOffset(Offset = "0x0")]
		public GameColor gameColor;

		[Token(Token = "0x40004DC")]
		[FieldOffset(Offset = "0x8")]
		public Material jellyMaterial;

		[Token(Token = "0x40004DD")]
		[FieldOffset(Offset = "0x10")]
		public Material bottomMaterial;

		[Token(Token = "0x40004DE")]
		[FieldOffset(Offset = "0x18")]
		public Material boxMaterial;
	}
}
