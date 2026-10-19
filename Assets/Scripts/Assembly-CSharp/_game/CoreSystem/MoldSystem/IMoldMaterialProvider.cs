using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.MoldSystem
{
	[Token(Token = "0x200049B")]
	public interface IMoldMaterialProvider
	{
		[Token(Token = "0x170001A7")]
		Material HiddenMoldMaterial
		{
			[Token(Token = "0x6001326")]
			get;
		}

		[Token(Token = "0x6001324")]
		MoldMaterialSet GetMoldMaterials(GameColor color);

		[Token(Token = "0x6001325")]
		Color GetFillColor(GameColor color);
	}
}
