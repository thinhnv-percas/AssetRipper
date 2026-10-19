using Cpp2ILInjected;

namespace Unco.ContainerSystem.Runtime
{
	[Token(Token = "0x200004F")]
	public interface IContainerInstaller
	{
		[Token(Token = "0x600012A")]
		void InstallBindings(ref ContainerInstanceBuilder containerBuilder);
	}
}
