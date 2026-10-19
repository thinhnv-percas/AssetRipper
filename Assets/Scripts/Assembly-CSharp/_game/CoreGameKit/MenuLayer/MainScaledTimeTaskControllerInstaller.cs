using System;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Config;
using Unco.TimeTaskSystem.Runtime;
using Unco.TimeTaskSystem.Runtime.UnityBindings;

namespace _game.CoreGameKit.MenuLayer
{
	[Token(Token = "0x20005DD")]
	public class MainScaledTimeTaskControllerInstaller : InstallerSO
	{
		[Token(Token = "0x6001936")]
		[Address(RVA = "0x3D4613C", Offset = "0x3D4613C", Length = "0x180")]
		public override void InstallBindings(ref ContainerInstanceBuilder builder)
		{
			ScaledTimeTaskController instance = new ScaledTimeTaskController();
			Type[] array = new Type[2];
			Type typeFromHandle = typeof(ITimeTaskController);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_00f5;
				}
			}
			array[0] = typeFromHandle;
			Type typeFromHandle2 = typeof(ScaledTimeTaskController);
			if ((object)typeFromHandle2 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_00f5;
				}
			}
			array[1] = typeFromHandle2;
			builder.AddSingleton(instance, array);
			return;
			IL_00f5:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6001937")]
		[Address(RVA = "0x3D462BC", Offset = "0x3D462BC", Length = "0x8")]
		public MainScaledTimeTaskControllerInstaller()
		{
		}
	}
}
