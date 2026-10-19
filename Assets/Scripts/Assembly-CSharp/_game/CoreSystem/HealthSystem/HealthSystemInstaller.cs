using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004D2")]
	public class HealthSystemInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20004D3")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400102A")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400102B")]
			public static Func<Instancer, HealthController> _003C_003E9__0_0;

			[Token(Token = "0x600145C")]
			[Address(RVA = "0x3CF4C0C", Offset = "0x3CF4C0C", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600145D")]
			[Address(RVA = "0x3CF4C70", Offset = "0x3CF4C70", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal HealthController _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				HealthController instance = new HealthController();
				return instancer.InjectInstance(instance);
			}
		}

		[Token(Token = "0x600145A")]
		[Address(RVA = "0x3CF4ADC", Offset = "0x3CF4ADC", Length = "0x128")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 2952;
			Func<Instancer, HealthController> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer instancer)
				{
					HealthController instance = new HealthController();
					return instancer.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x600145B")]
		[Address(RVA = "0x3CF4C04", Offset = "0x3CF4C04", Length = "0x8")]
		public HealthSystemInstaller()
		{
		}
	}
}
