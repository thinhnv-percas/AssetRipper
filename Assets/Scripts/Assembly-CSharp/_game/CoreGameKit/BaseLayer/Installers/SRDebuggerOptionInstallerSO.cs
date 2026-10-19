using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x20006BB")]
	public abstract class SRDebuggerOptionInstallerSO : InstallerSO
	{
		[Token(Token = "0x6001C7E")]
		[Address(RVA = "0x3D6EFF0", Offset = "0x3D6EFF0", Length = "0xC")]
		public sealed override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			InstallSRDebuggerBindings(ref containerBuilder);
		}

		[Token(Token = "0x6001C7F")]
		protected abstract void InstallSRDebuggerBindings(ref ContainerInstanceBuilder containerBuilder);

		[Token(Token = "0x6001C80")]
		[Address(RVA = "0x3D6D1A4", Offset = "0x3D6D1A4", Length = "0x8")]
		protected internal SRDebuggerOptionInstallerSO()
		{
		}
	}
}
