using Systems.FlowSystem.Scripts.Core;
using Systems.TutorialSystem.Scripts;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreGameKit.CoreSerivces
{
	[Token(Token = "0x2000608")]
	public class FlowTutorialsInstaller : InstallerSO
	{
		[SerializeField]
		[Token(Token = "0x40014DE")]
		[FieldOffset(Offset = "0x18")]
		private FlowDatabase m_flowDatabase;

		[Token(Token = "0x60019D6")]
		[Address(RVA = "0x3D4EB8C", Offset = "0x3D4EB8C", Length = "0xF8")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			containerBuilder.AddSingleton(m_flowDatabase);
			FlowManager instance = new FlowManager();
			containerBuilder.AddSingleton(instance);
			TutorialManager instance2 = new TutorialManager();
			containerBuilder.AddSingleton(instance2);
			TempTopGridVisualHolder instance3 = new TempTopGridVisualHolder();
			containerBuilder.AddSingleton(instance3);
		}

		[Token(Token = "0x60019D7")]
		[Address(RVA = "0x3D4EC84", Offset = "0x3D4EC84", Length = "0x8")]
		public FlowTutorialsInstaller()
		{
		}
	}
}
