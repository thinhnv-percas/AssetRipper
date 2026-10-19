using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Attributes;
using SRDebugger;
using Unco.ContainerSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Services.Interface;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x200069B")]
	public class BaseLayerSRDebuggerInstaller : SRDebuggerOptionInstallerSO
	{
		[Token(Token = "0x200069C")]
		private class BaseLayerSRDebuggerService : SRDebuggerOptionServiceBase
		{
			[Serializable]
			[CompilerGenerated]
			[Token(Token = "0x200069D")]
			private sealed class _003C_003Ec
			{
				[Token(Token = "0x400168B")]
				public static readonly _003C_003Ec _003C_003E9;

				[Token(Token = "0x400168C")]
				public static Action _003C_003E9__3_2;

				[Token(Token = "0x6001C09")]
				[Address(RVA = "0x3D67164", Offset = "0x3D67164", Length = "0x64")]
				static _003C_003Ec()
				{
					_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
					_003C_003E9 = _003C_003Ec2;
				}

				[Token(Token = "0x6001C0A")]
				[Address(RVA = "0x3D671C8", Offset = "0x3D671C8", Length = "0x8")]
				public _003C_003Ec()
				{
				}

				internal void _003CSetupOptions_003Eb__3_2()
				{
				}
			}

			[Token(Token = "0x4001689")]
			[FieldOffset(Offset = "0x18")]
			private IBaseLayerWinService _winService;

			[Token(Token = "0x400168A")]
			[FieldOffset(Offset = "0x20")]
			private IBaseLayerFailService _failService;

			[Inject(false)]
			[Token(Token = "0x6001C04")]
			[Address(RVA = "0x3D66C4C", Offset = "0x3D66C4C", Length = "0x3C")]
			private void Inject(IBaseLayerWinService winService, IBaseLayerFailService failService)
			{
				_winService = winService;
				_failService = failService;
				SetupOptions();
			}

			[Token(Token = "0x6001C05")]
			[Address(RVA = "0x3D66C88", Offset = "0x3D66C88", Length = "0x244")]
			private void SetupOptions()
			{
				Action callback = delegate
				{
					_winService.Win();
					Debug.Log("[SRDebugger] Win triggered");
				};
				OptionDefinition option = OptionDefinition.FromMethod("Trigger Win", callback, "2. BaseLayer", 10);
				AddOption(option);
				Action callback2 = delegate
				{
					_failService.Fail();
					Debug.Log("[SRDebugger] Lose triggered");
				};
				OptionDefinition option2 = OptionDefinition.FromMethod("Trigger Lose", callback2, "2. BaseLayer", 11);
				AddOption(option2);
				Action callback3 = _003C_003Ec._003C_003E9__3_2;
				bool flag = _003C_003Ec._003C_003E9__3_2 == null;
				bool flag2 = !flag;
				string name = "God Mode";
				if (!flag2)
				{
					name = "God Mode";
					callback3 = (_003C_003Ec._003C_003E9__3_2 = delegate
					{
					});
				}
				OptionDefinition option3 = OptionDefinition.FromMethod(name, callback3, "2. BaseLayer", 14);
				AddOption(option3);
			}

			[Token(Token = "0x6001C06")]
			[Address(RVA = "0x3D66ECC", Offset = "0x3D66ECC", Length = "0x88")]
			public BaseLayerSRDebuggerService()
			{
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200069E")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400168D")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400168E")]
			public static Func<Instancer, BaseLayerSRDebuggerService> _003C_003E9__0_0;

			[Token(Token = "0x6001C0C")]
			[Address(RVA = "0x3D671D4", Offset = "0x3D671D4", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001C0D")]
			[Address(RVA = "0x3D67238", Offset = "0x3D67238", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal BaseLayerSRDebuggerService _003CInstallSRDebuggerBindings_003Eb__0_0(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerSRDebuggerInstaller._003C_003Ec::_003CInstallSRDebuggerBindings_003Eb__0_0");
				return default;
			}
		}

		[Token(Token = "0x6001C02")]
		[Address(RVA = "0x3D66B1C", Offset = "0x3D66B1C", Length = "0x128")]
		protected override void InstallSRDebuggerBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerSRDebuggerInstaller::InstallSRDebuggerBindings");
		}

		[Token(Token = "0x6001C03")]
		[Address(RVA = "0x3D66C44", Offset = "0x3D66C44", Length = "0x8")]
		public BaseLayerSRDebuggerInstaller()
		{
		}
	}
}
