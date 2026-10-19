using Systems.WinStreakBonusSystem.Core;
using Systems.WinStreakBonusSystem.Data;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;

namespace Systems.WinStreakBonusSystem
{
	[Token(Token = "0x200001F")]
	public class WinStreakBonusSystemInstaller : InstallerSO
	{
		[SerializeField]
		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x18")]
		private WinStreakBonusDatabase m_winStreakBonusDatabase;

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x3C66114", Offset = "0x3C66114", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v49);\n\treturn;\nL_001A:\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this.m_winStreakBonusDatabase);\n\tv49 = new Systems.WinStreakBonusSystem.Core.WinStreakBonusService();\n\tSystem.Object::.ctor(v49);\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			containerBuilder.AddSingleton(m_winStreakBonusDatabase);
			WinStreakBonusService instance = new WinStreakBonusService();
			containerBuilder.AddSingleton(instance);
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x3C6619C", Offset = "0x3C6619C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public WinStreakBonusSystemInstaller()
		{
		}
	}
}
