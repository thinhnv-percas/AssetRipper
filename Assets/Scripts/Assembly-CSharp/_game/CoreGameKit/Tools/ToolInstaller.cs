using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;

namespace _game.CoreGameKit.Tools
{
	[Token(Token = "0x20005A5")]
	public class ToolInstaller : InstallerSO
	{
		[Token(Token = "0x60017FF")]
		[Address(RVA = "0x3D30DF8", Offset = "0x3D30DF8", Length = "0x4")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
		}

		[Token(Token = "0x6001800")]
		[Address(RVA = "0x3D30DFC", Offset = "0x3D30DFC", Length = "0x8")]
		public ToolInstaller()
		{
		}
	}
}
