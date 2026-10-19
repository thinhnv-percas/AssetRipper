using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Attributes;
using SRDebugger;
using Unco.ContainerSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Installers;

namespace _game.Systems.Firebase
{
	[Token(Token = "0x2000779")]
	public class SRDebuggerFirebaseInstaller : SRDebuggerOptionInstallerSO
	{
		[Token(Token = "0x200077A")]
		private class SRDebuggerFirebaseService : SRDebuggerOptionServiceBase
		{
			[Serializable]
			[CompilerGenerated]
			[Token(Token = "0x200077B")]
			private sealed class _003C_003Ec
			{
				[Token(Token = "0x40018F6")]
				public static readonly _003C_003Ec _003C_003E9;

				[Token(Token = "0x40018F7")]
				public static Action _003C_003E9__2_3;

				[Token(Token = "0x6001F8F")]
				[Address(RVA = "0x3D921D8", Offset = "0x3D921D8", Length = "0x64")]
				static _003C_003Ec()
				{
					_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
					_003C_003E9 = _003C_003Ec2;
				}

				[Token(Token = "0x6001F90")]
				[Address(RVA = "0x3D9223C", Offset = "0x3D9223C", Length = "0x8")]
				public _003C_003Ec()
				{
				}

				internal void _003CSetupOptions_003Eb__2_3()
				{
					global::AssetRipperInjected.RecoveryStub.Missing("SRDebuggerFirebaseInstaller.SRDebuggerFirebaseService._003C_003Ec::_003CSetupOptions_003Eb__2_3");
				}
			}

			[Token(Token = "0x40018F5")]
			[FieldOffset(Offset = "0x18")]
			private FirebaseCrashlyticsService _crashlyticsService;

			[Inject(false)]
			[Token(Token = "0x6001F89")]
			[Address(RVA = "0x3D91BD8", Offset = "0x3D91BD8", Length = "0x28")]
			private void Inject(FirebaseCrashlyticsService crashlyticsService)
			{
				_crashlyticsService = crashlyticsService;
				SetupOptions();
			}

			[Token(Token = "0x6001F8A")]
			[Address(RVA = "0x3D91C00", Offset = "0x3D91C00", Length = "0x2B4")]
			private void SetupOptions()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SRDebuggerFirebaseInstaller.SRDebuggerFirebaseService::SetupOptions");
			}

			[Token(Token = "0x6001F8B")]
			[Address(RVA = "0x3D91EB4", Offset = "0x3D91EB4", Length = "0x88")]
			public SRDebuggerFirebaseService()
			{
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200077C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40018F8")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40018F9")]
			public static Func<Instancer, SRDebuggerFirebaseService> _003C_003E9__0_0;

			[Token(Token = "0x6001F92")]
			[Address(RVA = "0x3D923C4", Offset = "0x3D923C4", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001F93")]
			[Address(RVA = "0x3D92428", Offset = "0x3D92428", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal SRDebuggerFirebaseService _003CInstallSRDebuggerBindings_003Eb__0_0(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SRDebuggerFirebaseInstaller._003C_003Ec::_003CInstallSRDebuggerBindings_003Eb__0_0");
				return default;
			}
		}

		[Token(Token = "0x6001F87")]
		[Address(RVA = "0x3D91AA8", Offset = "0x3D91AA8", Length = "0x128")]
		protected override void InstallSRDebuggerBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SRDebuggerFirebaseInstaller::InstallSRDebuggerBindings");
		}

		[Token(Token = "0x6001F88")]
		[Address(RVA = "0x3D91BD0", Offset = "0x3D91BD0", Length = "0x8")]
		public SRDebuggerFirebaseInstaller()
		{
		}
	}
}
