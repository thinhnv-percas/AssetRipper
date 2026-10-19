using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;

namespace _game.CoreGameKit.Tracking.Tools.AppOpen
{
	[Token(Token = "0x2000599")]
	public class AppOpenTimeCacheCollectorInstaller : InstallerSO
	{
		[Token(Token = "0x60017C1")]
		[Address(RVA = "0x3D30AB8", Offset = "0x3D30AB8", Length = "0x6C")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			AppOpenTimeCacheCollector instance = new AppOpenTimeCacheCollector();
			containerBuilder.AddSingleton(instance);
		}

		[Token(Token = "0x60017C2")]
		[Address(RVA = "0x3D30B24", Offset = "0x3D30B24", Length = "0x8")]
		public AppOpenTimeCacheCollectorInstaller()
		{
		}
	}
}
