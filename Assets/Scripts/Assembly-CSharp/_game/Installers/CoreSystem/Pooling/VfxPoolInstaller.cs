using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.GameBootstrap.Core;
using UnityEngine;
using _game.CoreSystem.Pooling;

namespace _game.Installers.CoreSystem.Pooling
{
	[Token(Token = "0x200007F")]
	public class VfxPoolInstaller : InstallerSO
	{
		[SerializeField]
		[Token(Token = "0x4000143")]
		[FieldOffset(Offset = "0x18")]
		private VfxPoolPrewarmConfig m_prewarmConfig;

		[Token(Token = "0x600022E")]
		[Address(RVA = "0x3C75078", Offset = "0x3C75078", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.prewarm = this.m_prewarmConfig;\n\tv75 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.Pooling.IVfxPool>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, _game.CoreSystem.Pooling.IVfxPool>::.ctor(v75, v51, Il2CppMethodInfo);\n\tv92 = Unco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, v75);\n\treturn;\nL_0023:\n\tv51 = new _game.Installers.CoreSystem.Pooling.VfxPoolInstaller+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v51);\n")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VfxPoolInstaller::InstallBindings");
		}

		[Token(Token = "0x600022F")]
		[Address(RVA = "0x3C75168", Offset = "0x3C75168", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.GameBootstrap.Config.InstallerSO::.ctor(this);\n\treturn;\n")]
		public VfxPoolInstaller()
		{
		}
	}
}
