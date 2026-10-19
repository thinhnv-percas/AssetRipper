using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.Installers.HeadlessMode
{
	[Token(Token = "0x2000195")]
	public class SandCubeInstaller_Headless : InstallerSO
	{
		[SerializeField]
		[Token(Token = "0x4000522")]
		[FieldOffset(Offset = "0x18")]
		private SandCubeConfig m_config;

		[Token(Token = "0x6000790")]
		[Address(RVA = "0x3E6B3CC", Offset = "0x3E6B3CC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_config);\n\treturn;\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			containerBuilder.AddSingleton(m_config);
		}

		[Token(Token = "0x6000791")]
		[Address(RVA = "0x3E6B3E0", Offset = "0x3E6B3E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public SandCubeInstaller_Headless()
		{
		}
	}
}
