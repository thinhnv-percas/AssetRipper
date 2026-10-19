using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.MoldSystem
{
	[Token(Token = "0x200049A")]
	public struct MoldMaterialSet
	{
		[Token(Token = "0x4000F38")]
		[FieldOffset(Offset = "0x0")]
		public Material moldMaterial;

		[Token(Token = "0x4000F39")]
		[FieldOffset(Offset = "0x8")]
		public Material moldInsideMaterial;
	}
}
