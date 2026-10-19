using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.SaveSystem.Runtime;

namespace _game.CoreGameKit.CoreSerivces
{
	[Token(Token = "0x2000609")]
	public class GameDataHandlerInstaller : InstallerSO
	{
		[Token(Token = "0x60019D8")]
		[Address(RVA = "0x3D4EC8C", Offset = "0x3D4EC8C", Length = "0x64")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			GameDataHandler gameDataHandler = new GameDataHandler();
			gameDataHandler.Init();
		}

		[Token(Token = "0x60019D9")]
		[Address(RVA = "0x3D4ECF0", Offset = "0x3D4ECF0", Length = "0x8")]
		public GameDataHandlerInstaller()
		{
		}
	}
}
