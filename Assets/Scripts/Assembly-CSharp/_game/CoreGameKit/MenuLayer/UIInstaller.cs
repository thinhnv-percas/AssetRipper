using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Core;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using Utils.UncoInput;
using _game.CoreGameKit.IntroScene;
using _game.CoreGameKit.UiControllers;
using _game.CoreGameKit.UiControllers.ScriptableObjects;

namespace _game.CoreGameKit.MenuLayer
{
	[Token(Token = "0x20005E6")]
	public class UIInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20005E7")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001459")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400145A")]
			public static Func<Instancer, UiManager> _003C_003E9__4_3;

			[Token(Token = "0x6001950")]
			[Address(RVA = "0x3D46EA0", Offset = "0x3D46EA0", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001951")]
			[Address(RVA = "0x3D46F04", Offset = "0x3D46F04", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal UiManager _003CInstallBindings_003Eb__4_3(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("UIInstaller._003C_003Ec::_003CInstallBindings_003Eb__4_3");
				return default;
			}
		}

		[SerializeField]
		[Token(Token = "0x4001455")]
		[FieldOffset(Offset = "0x18")]
		private OverlayUiFactory m_overlayUiFactory;

		[SerializeField]
		[Token(Token = "0x4001456")]
		[FieldOffset(Offset = "0x20")]
		private CameraUiFactory m_cameraUiFactory;

		[SerializeField]
		[Token(Token = "0x4001457")]
		[FieldOffset(Offset = "0x28")]
		private BaseUIConfig m_baseUIConfig;

		[SerializeField]
		[Token(Token = "0x4001458")]
		[FieldOffset(Offset = "0x30")]
		private UncoStandaloneInputModule m_standaloneInputModule;

		[Token(Token = "0x600194A")]
		[Address(RVA = "0x3D46968", Offset = "0x3D46968", Length = "0x384")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIInstaller::InstallBindings");
		}

		[Token(Token = "0x600194B")]
		[Address(RVA = "0x3D46CF4", Offset = "0x3D46CF4", Length = "0x8")]
		public UIInstaller()
		{
		}
	}
}
