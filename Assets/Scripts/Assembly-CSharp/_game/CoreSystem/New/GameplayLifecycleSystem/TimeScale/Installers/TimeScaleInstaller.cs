using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.TimeScale.Installers
{
	[Token(Token = "0x20003F6")]
	public class TimeScaleInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20003F7")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000C94")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000C95")]
			public static Func<Instancer, TimeScaleBridge> _003C_003E9__0_0;

			[Token(Token = "0x60010B0")]
			[Address(RVA = "0x3CB7244", Offset = "0x3CB7244", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60010B1")]
			[Address(RVA = "0x3CB72A8", Offset = "0x3CB72A8", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal TimeScaleBridge _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				TimeScaleBridge instance = new TimeScaleBridge();
				return x.InjectInstance(instance);
			}
		}

		[Token(Token = "0x60010AE")]
		[Address(RVA = "0x3CB711C", Offset = "0x3CB711C", Length = "0x128")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 3440;
			Func<Instancer, TimeScaleBridge> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer x)
				{
					TimeScaleBridge instance = new TimeScaleBridge();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x60010AF")]
		[Address(RVA = "0x3CB11C0", Offset = "0x3CB11C0", Length = "0x8")]
		public TimeScaleInstaller()
		{
		}
	}
}
