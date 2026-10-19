using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Installers.Unco.ContainerSystem.Runtime;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x20006BD")]
	public class UpdaterInstallerSo : InstallerSO
	{
		[SerializeReference]
		[Token(Token = "0x40016C7")]
		[FieldOffset(Offset = "0x18")]
		private UpdaterInstaller m_updaterInstaller;

		[Token(Token = "0x6001C86")]
		[Address(RVA = "0x3D6F3D4", Offset = "0x3D6F3D4", Length = "0x9C")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UpdaterInstallerSo::InstallBindings");
		}

		[Token(Token = "0x6001C87")]
		[Address(RVA = "0x3D6F470", Offset = "0x3D6F470", Length = "0x8")]
		public UpdaterInstallerSo()
		{
		}
	}
}
