using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.TimeTaskSystem.Runtime.UnityBindings;

namespace Unco.TimeTaskSystem.Runtime.PackageBindings
{
	[Serializable]
	[Token(Token = "0x200000F")]
	public class ScaledTimeTaskControllerInstaller : IContainerInstaller
	{
		[Token(Token = "0x6000058")]
		[Address(RVA = "0x8196148", Offset = "0x8196148", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tgoto L_0039;\nL_0039:\n\tv80 = System.Type::GetTypeFromHandle(Unco.TimeTaskSystem.Runtime.UnityBindings.ScaledTimeTaskController);\n\tv83 = v80 == 0;\n\tif (v83) goto L_004C;\n\tv112 = 0x21C11D0(v80, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv116 = v112 == 0;\n\tif (v116) goto L_0077;\nL_004C:\n\tv65[0] = v80;\n\tv185 = System.Type::GetTypeFromHandle(Unco.TimeTaskSystem.Runtime.ITimeTaskController);\n\tv186 = v185 == 0;\n\tif (v186) goto L_0064;\n\tv179 = 0x21C11D0(v185, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv180 = v179 == 0;\n\tif (v180) goto L_0077;\nL_0064:\n\tv65[1] = v185;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(builder, v54, v65);\n\treturn;\nL_0077:\n\tv182 = new System.ArrayTypeMismatchException();\n\tthrow v182;\nL_0026:\n\tv54 = new Unco.TimeTaskSystem.Runtime.UnityBindings.ScaledTimeTaskController();\n\tUnco.TimeTaskSystem.Runtime.UnityBindings.ScaledTimeTaskController::.ctor(v54, 0x100);\n\t// 44 NewArr v65 @ X0_v5 (System.Type[]), typeof(System.Type[]), 2\n")]
		public void InstallBindings(ref ContainerInstanceBuilder builder)
		{
			ScaledTimeTaskController instance = new ScaledTimeTaskController();
			Type[] array = new Type[2];
			Type typeFromHandle = typeof(ScaledTimeTaskController);
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
			Type typeFromHandle2 = typeof(ITimeTaskController);
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

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x81962C4", Offset = "0x81962C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ScaledTimeTaskControllerInstaller()
		{
		}
	}
}
