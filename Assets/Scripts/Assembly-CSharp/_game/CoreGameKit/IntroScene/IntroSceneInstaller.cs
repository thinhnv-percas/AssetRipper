using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using UnityEngine;

namespace _game.CoreGameKit.IntroScene
{
	[Token(Token = "0x20005F3")]
	public class IntroSceneInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20005F4")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001486")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001487")]
			public static Func<Instancer, IntroUiMono> _003C_003E9__0_0;

			[Token(Token = "0x600197B")]
			[Address(RVA = "0x3D48E70", Offset = "0x3D48E70", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600197C")]
			[Address(RVA = "0x3D48ED4", Offset = "0x3D48ED4", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal IntroUiMono _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				IntroUiMono introUiMono = UnityEngine.Object.FindObjectOfType<IntroUiMono>();
				if (introUiMono == null)
				{
					Debug.LogError("IntroSceneInstaller: IntroUiMono not found in the scene.");
					return null;
				}
				return x.InjectMono(introUiMono);
			}
		}

		[Token(Token = "0x6001979")]
		[Address(RVA = "0x3D48D40", Offset = "0x3D48D40", Length = "0x128")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 3048;
			Func<Instancer, IntroUiMono> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer x)
				{
					IntroUiMono introUiMono = UnityEngine.Object.FindObjectOfType<IntroUiMono>();
					if (introUiMono == null)
					{
						Debug.LogError("IntroSceneInstaller: IntroUiMono not found in the scene.");
						return (IntroUiMono)null;
					}
					return x.InjectMono(introUiMono);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x600197A")]
		[Address(RVA = "0x3D48E68", Offset = "0x3D48E68", Length = "0x8")]
		public IntroSceneInstaller()
		{
		}
	}
}
