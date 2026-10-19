using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Attributes;
using SRDebugger;
using SRDebugger.Services;
using Unco.ContainerSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Installers;

namespace _game.CoreGameKit.Tools.DebugMenu.SRDebuggerIntegration
{
	[CreateAssetMenu(menuName = "DebugMenu/Debug Menu SRDebugger Installer", fileName = "DebugMenuSRDebuggerInstaller")]
	[Token(Token = "0x20005B7")]
	public class DebugMenuSRDebuggerInstaller : SRDebuggerOptionInstallerSO
	{
		[Token(Token = "0x20005B8")]
		private class DebugMenuSRDebuggerService : SRDebuggerOptionServiceBase
		{
			[Token(Token = "0x40013BF")]
			[FieldOffset(Offset = "0x18")]
			private DebugMenuController _controller;

			[Inject(false)]
			[Token(Token = "0x600187B")]
			[Address(RVA = "0x3D3882C", Offset = "0x3D3882C", Length = "0x28")]
			private void Inject(DebugMenuController controller)
			{
				_controller = controller;
				SetupOptions();
			}

			[Token(Token = "0x600187C")]
			[Address(RVA = "0x3D38854", Offset = "0x3D38854", Length = "0xD4")]
			private void SetupOptions()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("DebugMenuSRDebuggerInstaller.DebugMenuSRDebuggerService::SetupOptions");
			}

			[Token(Token = "0x600187D")]
			[Address(RVA = "0x3D38928", Offset = "0x3D38928", Length = "0x88")]
			public DebugMenuSRDebuggerService()
			{
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20005B9")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40013C0")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40013C1")]
			public static Func<Instancer, DebugMenuSRDebuggerService> _003C_003E9__0_0;

			[Token(Token = "0x600187F")]
			[Address(RVA = "0x3D38B60", Offset = "0x3D38B60", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001880")]
			[Address(RVA = "0x3D38BC4", Offset = "0x3D38BC4", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal DebugMenuSRDebuggerService _003CInstallSRDebuggerBindings_003Eb__0_0(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("DebugMenuSRDebuggerInstaller._003C_003Ec::_003CInstallSRDebuggerBindings_003Eb__0_0");
				return default;
			}
		}

		[Token(Token = "0x6001879")]
		[Address(RVA = "0x3D386FC", Offset = "0x3D386FC", Length = "0x128")]
		protected override void InstallSRDebuggerBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugMenuSRDebuggerInstaller::InstallSRDebuggerBindings");
		}

		[Token(Token = "0x600187A")]
		[Address(RVA = "0x3D38824", Offset = "0x3D38824", Length = "0x8")]
		public DebugMenuSRDebuggerInstaller()
		{
		}
	}
}
