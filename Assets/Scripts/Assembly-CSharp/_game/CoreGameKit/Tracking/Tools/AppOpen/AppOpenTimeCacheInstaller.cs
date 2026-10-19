using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;

namespace _game.CoreGameKit.Tracking.Tools.AppOpen
{
	[Token(Token = "0x200059A")]
	public class AppOpenTimeCacheInstaller : InstallerSO
	{
		[Token(Token = "0x60017C3")]
		[Address(RVA = "0x3D30B2C", Offset = "0x3D30B2C", Length = "0x6C")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			AppOpenTimeCache instance = new AppOpenTimeCache();
			containerBuilder.AddSingleton(instance);
		}

		[Token(Token = "0x60017C4")]
		[Address(RVA = "0x3D30B98", Offset = "0x3D30B98", Length = "0x8")]
		public AppOpenTimeCacheInstaller()
		{
		}
	}
}
