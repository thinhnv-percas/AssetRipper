using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;

namespace _game.CoreGameKit.Tools.DebugMenu
{
	[CreateAssetMenu(menuName = "DebugMenu/Debug Menu Installer", fileName = "DebugMenuInstaller")]
	[Token(Token = "0x20005AF")]
	public class DebugMenuInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20005B0")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400138E")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400138F")]
			public static Func<Instancer, DebugMenuController> _003C_003E9__0_0;

			[Token(Token = "0x600184C")]
			[Address(RVA = "0x3D36C38", Offset = "0x3D36C38", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600184D")]
			[Address(RVA = "0x3D36C9C", Offset = "0x3D36C9C", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal DebugMenuController _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				GameObject gameObject = new GameObject("[DebugMenu]");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				DebugMenuController debugMenuController = gameObject.AddComponent<DebugMenuController>();
				DebugMenuOverlay debugMenuOverlay = gameObject.AddComponent<DebugMenuOverlay>();
				debugMenuOverlay._controller = debugMenuController;
				DebugMenuController debugMenuController2 = instancer.InjectInstance(debugMenuController);
				return debugMenuController;
			}
		}

		[Token(Token = "0x600184A")]
		[Address(RVA = "0x3D36B08", Offset = "0x3D36B08", Length = "0x128")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 2696;
			Func<Instancer, DebugMenuController> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer instancer)
				{
					GameObject gameObject = new GameObject("[DebugMenu]");
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
					DebugMenuController debugMenuController = gameObject.AddComponent<DebugMenuController>();
					DebugMenuOverlay debugMenuOverlay = gameObject.AddComponent<DebugMenuOverlay>();
					debugMenuOverlay._controller = debugMenuController;
					DebugMenuController debugMenuController2 = instancer.InjectInstance(debugMenuController);
					return debugMenuController;
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x600184B")]
		[Address(RVA = "0x3D36C30", Offset = "0x3D36C30", Length = "0x8")]
		public DebugMenuInstaller()
		{
		}
	}
}
