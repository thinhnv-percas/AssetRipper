using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using _game.CoreGameKit.BaseLayer.Boosters;
using _game.CoreSystem.New.PlayMode;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.PlayMode.Installers
{
	[Token(Token = "0x200041B")]
	public class RetentionLayerBridgeInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200041C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000CEC")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000CED")]
			public static Func<Instancer, RetentionLayerBridge> _003C_003E9__0_0;

			[Token(Token = "0x4000CEE")]
			public static Func<Instancer, GameplaySoundController> _003C_003E9__0_1;

			[Token(Token = "0x4000CEF")]
			public static Func<Instancer, GameplayHapticController> _003C_003E9__0_2;

			[Token(Token = "0x4000CF0")]
			public static Func<Instancer, BaseLayerBoosterController> _003C_003E9__0_3;

			[Token(Token = "0x6001130")]
			[Address(RVA = "0x3CBE278", Offset = "0x3CBE278", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001131")]
			[Address(RVA = "0x3CBE2DC", Offset = "0x3CBE2DC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal RetentionLayerBridge _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				int num = 187502592 + 104;
				Il2CppRuntime.Boundary("MANAGED", "Method not found @4B00ED0 (UnityEngine.Object::FindFirstObjectByType, and 1 more at this address)");
				RetentionLayerBridge instance = default(RetentionLayerBridge);
				return instancer.InjectMono(instance);
			}

			internal GameplaySoundController _003CInstallBindings_003Eb__0_1(Instancer instancer)
			{
				GameplaySoundController instance = new GameplaySoundController();
				return instancer.InjectInstance(instance);
			}

			internal GameplayHapticController _003CInstallBindings_003Eb__0_2(Instancer instancer)
			{
				GameplayHapticController instance = new GameplayHapticController();
				return instancer.InjectInstance(instance);
			}

			internal BaseLayerBoosterController _003CInstallBindings_003Eb__0_3(Instancer instancer)
			{
				BaseLayerBoosterController instance = new BaseLayerBoosterController();
				return instancer.InjectInstance(instance);
			}
		}

		[Token(Token = "0x600112E")]
		[Address(RVA = "0x3CBDEE4", Offset = "0x3CBDEE4", Length = "0x38C")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 3296;
			Func<Instancer, RetentionLayerBridge> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer instancer)
				{
					int num5 = 187502592 + 104;
					Il2CppRuntime.Boundary("MANAGED", "Method not found @4B00ED0 (UnityEngine.Object::FindFirstObjectByType, and 1 more at this address)");
					RetentionLayerBridge instance = default(RetentionLayerBridge);
					return instancer.InjectMono(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num2 = 187441152 + 2880;
			Func<Instancer, GameplaySoundController> _003C_003E9__0_2 = _003C_003Ec._003C_003E9__0_1;
			if (_003C_003Ec._003C_003E9__0_1 == null)
			{
				_003C_003E9__0_2 = (_003C_003Ec._003C_003E9__0_1 = delegate(Instancer instancer)
				{
					GameplaySoundController instance = new GameplaySoundController();
					return instancer.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num3 = 187441152 + 2864;
			Func<Instancer, GameplayHapticController> _003C_003E9__0_3 = _003C_003Ec._003C_003E9__0_2;
			if (_003C_003Ec._003C_003E9__0_2 == null)
			{
				_003C_003E9__0_3 = (_003C_003Ec._003C_003E9__0_2 = delegate(Instancer instancer)
				{
					GameplayHapticController instance = new GameplayHapticController();
					return instancer.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
			int num4 = 187441152 + 2576;
			Func<Instancer, BaseLayerBoosterController> _003C_003E9__0_4 = _003C_003Ec._003C_003E9__0_3;
			if (_003C_003Ec._003C_003E9__0_3 == null)
			{
				_003C_003E9__0_4 = (_003C_003Ec._003C_003E9__0_3 = delegate(Instancer instancer)
				{
					BaseLayerBoosterController instance = new BaseLayerBoosterController();
					return instancer.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x600112F")]
		[Address(RVA = "0x3CBE270", Offset = "0x3CBE270", Length = "0x8")]
		public RetentionLayerBridgeInstaller()
		{
		}
	}
}
