using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.CoreSystem.New.Shared.EditMode;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.HeadlessMode
{
	[Token(Token = "0x2000407")]
	public class HeadlessContainerInstaller : IContainerInstaller
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000408")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000CBB")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000CBC")]
			public static Func<Instancer, EditorHistory> _003C_003E9__0_0;

			[Token(Token = "0x60010E3")]
			[Address(RVA = "0x3CBA094", Offset = "0x3CBA094", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60010E4")]
			[Address(RVA = "0x3CBA0F8", Offset = "0x3CBA0F8", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal EditorHistory _003CInstallBindings_003Eb__0_0(Instancer x)
			{
				EditorHistory instance = new EditorHistory();
				return x.InjectInstance(instance);
			}
		}

		[Token(Token = "0x60010E1")]
		[Address(RVA = "0x3CB9F6C", Offset = "0x3CB9F6C", Length = "0x128")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			int num = 187441152 + 2712;
			Func<Instancer, EditorHistory> _003C_003E9__0_ = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				_003C_003E9__0_ = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer x)
				{
					EditorHistory instance = new EditorHistory();
					return x.InjectInstance(instance);
				});
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7CEBC (inside _game.CoreSystem.SandPhysics.SpawnUtility::ClosestPointOnSegment +0x88)");
		}

		[Token(Token = "0x60010E2")]
		[Address(RVA = "0x3CB96E4", Offset = "0x3CB96E4", Length = "0x8")]
		public HeadlessContainerInstaller()
		{
		}
	}
}
