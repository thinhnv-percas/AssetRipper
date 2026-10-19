using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.HeadlessMode
{
	[Token(Token = "0x2000401")]
	internal class HeadlessReconcileDriverInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000402")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000CB5")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000CB6")]
			public static Func<Instancer, HeadlessReconcileDriver> _003C_003E9__0_0;

			[Token(Token = "0x60010D4")]
			[Address(RVA = "0x3CB994C", Offset = "0x3CB994C", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60010D5")]
			[Address(RVA = "0x3CB99B0", Offset = "0x3CB99B0", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal HeadlessReconcileDriver _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				HeadlessReconcileDriver instance = new HeadlessReconcileDriver();
				return x.InjectInstance(instance);
			}
		}

		[Token(Token = "0x60010D2")]
		[Address(RVA = "0x3CB9824", Offset = "0x3CB9824", Length = "0x128")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 2944;
			Func<Instancer, HeadlessReconcileDriver> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer x)
				{
					HeadlessReconcileDriver instance = new HeadlessReconcileDriver();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x60010D3")]
		[Address(RVA = "0x3CB96F4", Offset = "0x3CB96F4", Length = "0x8")]
		public HeadlessReconcileDriverInstaller()
		{
		}
	}
}
