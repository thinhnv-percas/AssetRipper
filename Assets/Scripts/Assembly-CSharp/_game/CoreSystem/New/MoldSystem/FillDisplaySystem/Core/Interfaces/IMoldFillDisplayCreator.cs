using Cpp2ILInjected;
using TMPro;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core.Interfaces
{
	[Token(Token = "0x20002D7")]
	public interface IMoldFillDisplayCreator
	{
		[Token(Token = "0x6000C85")]
		void CreateAll();

		[Token(Token = "0x6000C86")]
		TextMeshPro CreateForMold(Entity entity);
	}
}
