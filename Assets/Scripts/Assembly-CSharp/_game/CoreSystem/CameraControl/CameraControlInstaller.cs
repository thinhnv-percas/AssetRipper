using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using Unco.EventBusSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;

namespace _game.CoreSystem.CameraControl
{
	[CreateAssetMenu(menuName = "SandFlow/Camera/Camera Control Installer", fileName = "CameraControlInstaller")]
	[Token(Token = "0x2000518")]
	public class CameraControlInstaller : InstallerSO
	{
		[Token(Token = "0x2000519")]
		private class CameraFlowRunnerFactory
		{
			[Inject(false)]
			[Token(Token = "0x4001137")]
			[FieldOffset(Offset = "0x10")]
			private ICameraControlService _cameraService;

			[Inject(false)]
			[Token(Token = "0x4001138")]
			[FieldOffset(Offset = "0x18")]
			private EventBus _eventBus;

			[Token(Token = "0x170001E6")]
			public ICameraControlService CameraService
			{
				[Token(Token = "0x600154C")]
				[Address(RVA = "0x3D0F658", Offset = "0x3D0F658", Length = "0x8")]
				get
				{
					return _cameraService;
				}
			}

			[Token(Token = "0x600154D")]
			[Address(RVA = "0x3D0F660", Offset = "0x3D0F660", Length = "0xBC")]
			public CameraFlowRunner Create()
			{
				CameraFlowRunner result = new CameraFlowRunner(CameraService, _eventBus, (MonoBehaviour)CameraService);
				if (CameraService != null)
				{
					MonoBehaviour monoBehaviour = CameraService as MonoBehaviour;
					if ((object)monoBehaviour == null)
					{
						return (CameraFlowRunner)(object)new InvalidCastException();
					}
				}
				return result;
			}

			[Token(Token = "0x600154E")]
			[Address(RVA = "0x3D0F848", Offset = "0x3D0F848", Length = "0x8")]
			public CameraFlowRunnerFactory()
			{
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200051A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001139")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400113A")]
			public static Func<Instancer, CameraControlService> _003C_003E9__0_0;

			[Token(Token = "0x400113B")]
			public static Func<Instancer, CameraFlowRunner> _003C_003E9__0_1;

			[Token(Token = "0x600154F")]
			[Address(RVA = "0x3D0F850", Offset = "0x3D0F850", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001550")]
			[Address(RVA = "0x3D0F8B4", Offset = "0x3D0F8B4", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal CameraControlService _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				GameObject gameObject = new GameObject("[CameraControlService]");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				CameraControlService cameraControlService = gameObject.AddComponent<CameraControlService>();
				Camera main = Camera.main;
				if (main != null)
				{
					cameraControlService.SetCamera(main);
				}
				return cameraControlService;
			}

			internal CameraFlowRunner _003CInstallBindings_003Eb__0_1(Instancer instancer)
			{
				CameraFlowRunnerFactory cameraFlowRunnerFactory = new CameraFlowRunnerFactory();
				CameraFlowRunnerFactory cameraFlowRunnerFactory2 = instancer.InjectInstance(cameraFlowRunnerFactory);
				CameraFlowRunner result = cameraFlowRunnerFactory.Create();
				if (cameraFlowRunnerFactory.CameraService == null || !(cameraFlowRunnerFactory.CameraService is CameraControlService))
				{
					return result;
				}
				return result;
			}
		}

		[Token(Token = "0x600154A")]
		[Address(RVA = "0x3D0F3D0", Offset = "0x3D0F3D0", Length = "0x280")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			Func<Instancer, CameraControlService> factory = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				factory = (_003C_003Ec._003C_003E9__0_0 = delegate
				{
					GameObject gameObject = new GameObject("[CameraControlService]");
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
					CameraControlService cameraControlService = gameObject.AddComponent<CameraControlService>();
					Camera main = Camera.main;
					if (main != null)
					{
						cameraControlService.SetCamera(main);
					}
					return cameraControlService;
				});
			}
			Type[] array = new Type[1];
			Type typeFromHandle = typeof(ICameraControlService);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = typeFromHandle;
			containerBuilder.AddSingleton(factory, array);
			int num = 187441152 + 2592;
			Func<Instancer, CameraFlowRunner> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_1;
			if (_003C_003Ec._003C_003E9__0_1 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_1 = delegate(Instancer instancer)
				{
					CameraFlowRunnerFactory cameraFlowRunnerFactory = new CameraFlowRunnerFactory();
					CameraFlowRunnerFactory cameraFlowRunnerFactory2 = instancer.InjectInstance(cameraFlowRunnerFactory);
					CameraFlowRunner cameraFlowRunner = cameraFlowRunnerFactory.Create();
					return (cameraFlowRunnerFactory.CameraService == null || !(cameraFlowRunnerFactory.CameraService is CameraControlService)) ? cameraFlowRunner : cameraFlowRunner;
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x600154B")]
		[Address(RVA = "0x3D0F650", Offset = "0x3D0F650", Length = "0x8")]
		public CameraControlInstaller()
		{
		}
	}
}
