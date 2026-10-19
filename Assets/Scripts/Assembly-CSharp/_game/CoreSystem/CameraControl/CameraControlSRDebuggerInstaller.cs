using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using SRDebugger;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Installers;

namespace _game.CoreSystem.CameraControl
{
	[CreateAssetMenu(menuName = "SandFlow/Camera/SRDebugger Installer", fileName = "CameraControlSRDebuggerInstaller")]
	[Token(Token = "0x200051B")]
	public class CameraControlSRDebuggerInstaller : InstallerSO
	{
		[Token(Token = "0x200051C")]
		private class CameraControlSRDebuggerService : SRDebuggerOptionServiceBase
		{
			[Token(Token = "0x400113D")]
			[FieldOffset(Offset = "0x18")]
			private ICameraControlService _cameraService;

			[Token(Token = "0x400113E")]
			[FieldOffset(Offset = "0x20")]
			internal readonly CameraPathLibrary _library;

			[Token(Token = "0x6001555")]
			[Address(RVA = "0x3D0FD0C", Offset = "0x3D0FD0C", Length = "0x78")]
			public CameraControlSRDebuggerService(CameraPathLibrary library)
			{
				_library = library;
			}

			[Inject(false)]
			[Token(Token = "0x6001556")]
			[Address(RVA = "0x3D0FD84", Offset = "0x3D0FD84", Length = "0x28")]
			private void Inject(ICameraControlService cameraService)
			{
				_cameraService = cameraService;
				SetupOptions();
			}

			[Token(Token = "0x6001557")]
			[Address(RVA = "0x3D0FDAC", Offset = "0x3D0FDAC", Length = "0x42C")]
			private void SetupOptions()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CameraControlSRDebuggerInstaller.CameraControlSRDebuggerService::SetupOptions");
			}
		}

		[SerializeField]
		[Token(Token = "0x400113C")]
		[FieldOffset(Offset = "0x18")]
		private CameraPathLibrary _pathLibrary;

		[Token(Token = "0x6001553")]
		[Address(RVA = "0x3D0FC14", Offset = "0x3D0FC14", Length = "0xE8")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraControlSRDebuggerInstaller::InstallBindings");
		}

		[Token(Token = "0x6001554")]
		[Address(RVA = "0x3D0FD04", Offset = "0x3D0FD04", Length = "0x8")]
		public CameraControlSRDebuggerInstaller()
		{
		}
	}
}
