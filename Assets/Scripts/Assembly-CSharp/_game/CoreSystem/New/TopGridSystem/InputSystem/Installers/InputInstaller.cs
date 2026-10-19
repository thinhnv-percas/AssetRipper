using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.InputSystem.Installers
{
	[Token(Token = "0x200024B")]
	public class InputInstaller : InstallerSO
	{
		[SerializeField]
		[Token(Token = "0x4000709")]
		[FieldOffset(Offset = "0x18")]
		private GameplayInputController m_controller;

		[Token(Token = "0x60009FA")]
		[Address(RVA = "0x3E9E558", Offset = "0x3E9E558", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\treturn;\nL_0024:\n\tv55 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.InputSystem.GameplayInputController>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.New.TopGridSystem.InputSystem.GameplayInputController>::.ctor(v55, this, Il2CppMethodInfo);\n\tv76 = Unco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v55);\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			Func<Instancer, GameplayInputController> factory = (Instancer x) => x.Instantiate(m_controller, useContextAsParent: false);
			containerBuilder.AddSingleton(factory);
		}

		[Token(Token = "0x60009FB")]
		[Address(RVA = "0x3E9E600", Offset = "0x3E9E600", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public InputInstaller()
		{
		}
	}
}
