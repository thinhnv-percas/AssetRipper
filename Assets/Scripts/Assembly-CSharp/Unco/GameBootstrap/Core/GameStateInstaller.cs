using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;

namespace Unco.GameBootstrap.Core
{
	[Token(Token = "0x20007D0")]
	public class GameStateInstaller : InstallerSO
	{
		[Token(Token = "0x6002103")]
		[Address(RVA = "0x3DC0C40", Offset = "0x3DC0C40", Length = "0x74")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			GameStateController gameStateController = new GameStateController();
			gameStateController._currentLayer = GameplayLayer.None;
			containerBuilder.AddSingleton(gameStateController);
		}

		[Token(Token = "0x6002104")]
		[Address(RVA = "0x3DC0CB4", Offset = "0x3DC0CB4", Length = "0x8")]
		public GameStateInstaller()
		{
		}
	}
}
