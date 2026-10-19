using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.ContainerSystem.Runtime
{
	[Token(Token = "0x200004D")]
	internal class ContainerManagerInstaller : IContainerInstaller
	{
		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0x10")]
		internal readonly ContainerManager Manager;

		[Token(Token = "0x6000122")]
		[Address(RVA = "0x3F3B48C", Offset = "0x3F3B48C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Manager = manager;\n\treturn;\n")]
		internal ContainerManagerInstaller(ContainerManager manager)
		{
			Manager = manager;
		}

		[Token(Token = "0x6000123")]
		[Address(RVA = "0x3F3C144", Offset = "0x3F3C144", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.Manager);\n\treturn;\n")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			containerBuilder.AddSingleton(Manager);
		}
	}
}
