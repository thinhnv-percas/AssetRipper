using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.TimeTaskSystem.Runtime;
using Unco.TimeTaskSystem.Runtime.UnityBindings;

namespace _game.CoreGameKit.MenuLayer
{
	[Token(Token = "0x20005DE")]
	public class MainUnscaledTimeTaskController : InstallerSO
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20005DF")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400144E")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400144F")]
			public static Func<Instancer, UnscaledTimeTaskController> _003C_003E9__0_0;

			[Token(Token = "0x600193A")]
			[Address(RVA = "0x3D464D8", Offset = "0x3D464D8", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600193B")]
			[Address(RVA = "0x3D4653C", Offset = "0x3D4653C", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal UnscaledTimeTaskController _003CInstallBindings_003Eb__0_0(Instancer instancer)
			{
				UnscaledTimeTaskController unscaledTimeTaskController = new UnscaledTimeTaskController();
				UnscaledTimeTaskController unscaledTimeTaskController2 = instancer.InjectInstance(unscaledTimeTaskController);
				return unscaledTimeTaskController;
			}
		}

		[Token(Token = "0x6001938")]
		[Address(RVA = "0x3D462C4", Offset = "0x3D462C4", Length = "0x20C")]
		public override void InstallBindings(ref ContainerInstanceBuilder builder)
		{
			Func<Instancer, UnscaledTimeTaskController> factory = _003C_003Ec._003C_003E9__0_0;
			if (_003C_003Ec._003C_003E9__0_0 == null)
			{
				factory = (_003C_003Ec._003C_003E9__0_0 = delegate(Instancer instancer)
				{
					UnscaledTimeTaskController unscaledTimeTaskController = new UnscaledTimeTaskController();
					UnscaledTimeTaskController unscaledTimeTaskController2 = instancer.InjectInstance(unscaledTimeTaskController);
					return unscaledTimeTaskController;
				});
			}
			Type[] array = new Type[2];
			Type typeFromHandle = typeof(UnscaledTimeTaskController);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_0108;
				}
			}
			array[0] = typeFromHandle;
			Type typeFromHandle2 = typeof(ITimeTaskController);
			if ((object)typeFromHandle2 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_0108;
				}
			}
			array[1] = typeFromHandle2;
			builder.AddSingleton(factory, array);
			return;
			IL_0108:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6001939")]
		[Address(RVA = "0x3D464D0", Offset = "0x3D464D0", Length = "0x8")]
		public MainUnscaledTimeTaskController()
		{
		}
	}
}
