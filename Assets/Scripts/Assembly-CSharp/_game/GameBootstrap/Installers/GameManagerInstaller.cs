using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.CommonManagers;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace _game.GameBootstrap.Installers
{
	[Serializable]
	[Token(Token = "0x200078B")]
	public class GameManagerInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200078C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001913")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001914")]
			public static Func<Instancer, GameManager> _003C_003E9__0_0;

			[Token(Token = "0x6001FDC")]
			[Address(RVA = "0x3D94838", Offset = "0x3D94838", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001FDD")]
			[Address(RVA = "0x3D9489C", Offset = "0x3D9489C", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal GameManager _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				GameManager gameManager = instancer.AddComponent<GameManager>();
				if (!(gameManager == null))
				{
					return gameManager;
				}
				GameObject gameObject = new GameObject("GameManager");
				GameManager gameManager2 = gameObject.AddComponent<GameManager>();
				GameManager gameManager3 = instancer.InjectMono(gameManager2);
				return gameManager2;
			}
		}

		[Token(Token = "0x6001FDA")]
		[Address(RVA = "0x3D94708", Offset = "0x3D94708", Length = "0x128")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 2824;
			Func<Instancer, GameManager> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer instancer)
				{
					GameManager gameManager = instancer.AddComponent<GameManager>();
					if (!(gameManager == null))
					{
						return gameManager;
					}
					GameObject gameObject = new GameObject("GameManager");
					GameManager gameManager2 = gameObject.AddComponent<GameManager>();
					GameManager gameManager3 = instancer.InjectMono(gameManager2);
					return gameManager2;
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x6001FDB")]
		[Address(RVA = "0x3D94830", Offset = "0x3D94830", Length = "0x8")]
		public GameManagerInstaller()
		{
		}
	}
}
