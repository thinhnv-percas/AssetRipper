using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace Unco.GameBootstrap.Config
{
	[Token(Token = "0x20007E4")]
	public class CompositeInstallerConfigSo : InstallerSO
	{
		[SerializeField]
		[Token(Token = "0x4001A62")]
		[FieldOffset(Offset = "0x18")]
		private InstallerSO[] _installers;

		[Token(Token = "0x600216A")]
		[Address(RVA = "0x3DC65F4", Offset = "0x3DC65F4", Length = "0xE8")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CompositeInstallerConfigSo::InstallBindings");
		}

		[Token(Token = "0x600216B")]
		[Address(RVA = "0x3DC66DC", Offset = "0x3DC66DC", Length = "0x8")]
		public CompositeInstallerConfigSo()
		{
		}
	}
}
