using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;

namespace _game.Systems.Firebase
{
	[Token(Token = "0x2000777")]
	public class FirebaseInstaller : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000778")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40018F3")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40018F4")]
			public static Func<Instancer, FirebaseCrashlyticsService> _003C_003E9__0_0;

			[Token(Token = "0x6001F84")]
			[Address(RVA = "0x3D919B4", Offset = "0x3D919B4", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001F85")]
			[Address(RVA = "0x3D91A18", Offset = "0x3D91A18", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal FirebaseCrashlyticsService _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				FirebaseCrashlyticsService instance = new FirebaseCrashlyticsService();
				return instancer.InjectInstance(instance);
			}
		}

		[Token(Token = "0x6001F82")]
		[Address(RVA = "0x3D91884", Offset = "0x3D91884", Length = "0x128")]
		public override void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 2768;
			Func<Instancer, FirebaseCrashlyticsService> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer instancer)
				{
					FirebaseCrashlyticsService instance = new FirebaseCrashlyticsService();
					return instancer.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x6001F83")]
		[Address(RVA = "0x3D919AC", Offset = "0x3D919AC", Length = "0x8")]
		public FirebaseInstaller()
		{
		}
	}
}
