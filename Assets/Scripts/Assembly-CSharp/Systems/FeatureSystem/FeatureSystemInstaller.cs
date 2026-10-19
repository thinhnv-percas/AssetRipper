using Systems.FeatureSystem.Core;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;

namespace Systems.FeatureSystem
{
	[Token(Token = "0x200002A")]
	public class FeatureSystemInstaller : InstallerSO
	{
		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x3C673B8", Offset = "0x3C673B8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn;\nL_0017:\n\tv45 = new Systems.FeatureSystem.Core.FeatureService();\n\tSystem.Object::.ctor(v45);\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v45);\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			FeatureService instance = new FeatureService();
			containerBuilder.AddSingleton(instance);
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x3C6742C", Offset = "0x3C6742C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public FeatureSystemInstaller()
		{
		}
	}
}
