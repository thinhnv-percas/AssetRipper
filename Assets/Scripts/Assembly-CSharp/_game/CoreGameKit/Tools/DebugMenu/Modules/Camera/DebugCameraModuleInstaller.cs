using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreSystem.CameraControl;

namespace _game.CoreGameKit.Tools.DebugMenu.Modules.Camera
{
	[CreateAssetMenu(menuName = "DebugMenu/Debug Camera Module Installer", fileName = "DebugCameraModuleInstaller")]
	[Token(Token = "0x20005C2")]
	public class DebugCameraModuleInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20005C3")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40013E7")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40013E8")]
			public static Func<Instancer, DebugCameraData> _003C_003E9__0_0;

			[Token(Token = "0x40013E9")]
			public static Func<Instancer, DebugCameraPathPlayer> _003C_003E9__0_1;

			[Token(Token = "0x40013EA")]
			public static Func<Instancer, DebugCameraModule> _003C_003E9__0_2;

			[Token(Token = "0x40013EB")]
			public static Func<Instancer, DebugCameraKeyListener> _003C_003E9__0_3;

			[Token(Token = "0x60018B6")]
			[Address(RVA = "0x3D3FD88", Offset = "0x3D3FD88", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60018B7")]
			[Address(RVA = "0x3D3FDEC", Offset = "0x3D3FDEC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal DebugCameraData _003CInstallBindings_003Eb__0_0(Instancer _)
			{
				DebugCameraData fallback = new DebugCameraData();
				return DebugMenuPersistence.Load("camera", fallback);
			}

			internal DebugCameraPathPlayer _003CInstallBindings_003Eb__0_1(Instancer instancer)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModuleInstaller._003C_003Ec::_003CInstallBindings_003Eb__0_1");
				return default;
			}

			internal DebugCameraModule _003CInstallBindings_003Eb__0_2(Instancer instancer)
			{
				bool flag = instancer.TryResolve<ICameraControlService>(out var result);
				bool flag2 = instancer.TryResolve<DebugCameraData>(out var result2);
				bool flag3 = instancer.TryResolve<DebugCameraPathPlayer>(out var result3);
				return new DebugCameraModule(result, result2, result3);
			}

			internal DebugCameraKeyListener _003CInstallBindings_003Eb__0_3(Instancer instancer)
			{
				bool flag = instancer.TryResolve<DebugCameraData>(out var result);
				bool flag2 = instancer.TryResolve<DebugCameraPathPlayer>(out var result2);
				GameObject gameObject = new GameObject("[DebugCameraKeyListener]");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				DebugCameraKeyListener debugCameraKeyListener = gameObject.AddComponent<DebugCameraKeyListener>();
				debugCameraKeyListener._data = result;
				debugCameraKeyListener._player = result2;
				return debugCameraKeyListener;
			}
		}

		[Token(Token = "0x60018B4")]
		[Address(RVA = "0x3D3F904", Offset = "0x3D3F904", Length = "0x47C")]
		public unsafe override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModuleInstaller::InstallBindings");
		}

		[Token(Token = "0x60018B5")]
		[Address(RVA = "0x3D3FD80", Offset = "0x3D3FD80", Length = "0x8")]
		public DebugCameraModuleInstaller()
		{
		}
	}
}
