using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;

namespace _game.CoreSystem
{
	[Token(Token = "0x2000086")]
	public class GenericInstaller<T> : IContainerInstaller
	{
		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0x0")]
		private T _obj;

		[Token(Token = "0x6000252")]
		[Address(RVA = "0x536BAA4", Offset = "0x536BAA4", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._obj = level;\n\treturn;\n")]
		public GenericInstaller(T level)
		{
			_obj = level;
		}

		[Token(Token = "0x6000253")]
		[Address(RVA = "0x536BAD8", Offset = "0x536BAD8", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_002C:\n\tv68 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv71 = v68 == 0;\n\tif (v71) goto L_003D;\n\tv76 = 0x21C11D0(v68, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv80 = v76 == 0;\n\tif (v80) goto L_0051;\nL_003D:\n\tv53[0] = v68;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(containerBuilder, this._obj, v53);\n\treturn;\nL_0051:\n\tv99 = new System.ArrayTypeMismatchException();\n\tthrow v99;\nL_001D:\n\t// 29 NewArr v53 @ X0_v3 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_002C;\n")]
		public void InstallBindings(ref ContainerInstanceBuilder containerBuilder)
		{
			Type[] array = new Type[1];
			Type typeFromHandle = typeof(T);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = typeFromHandle;
			containerBuilder.AddSingleton(_obj, array);
		}

		[Token(Token = "0x6000254")]
		[Address(RVA = "0x536BBD4", Offset = "0x536BBD4", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = Il2CppClass<_game.CoreSystem.GenericInstaller`1>;\n\tv21 = *([v18 @ X0_v1 (Il2CppClass<_game.CoreSystem.GenericInstaller`1>)+135]) & 1;\n\tv22 = v21 == 0;\n\tif (v22) goto L_0032;\n\tv24 = Il2CppClass<_game.CoreSystem.GenericInstaller`1<T>>;\n\tv27 = *([v24 @ X0_v19 (Il2CppClass<_game.CoreSystem.GenericInstaller`1<T>>)+135]) & 1;\n\tv28 = v27 == 0;\nL_FFFFFFFF:\n\tv48 = Il2CppClass<_game.CoreSystem.GenericInstaller`1<T>>;\nL_FFFFFFFF:\n\tv53 = Il2CppClass<_game.CoreSystem.GenericInstaller`1<T>>;\n\tif (v28) goto L_003B;\nL_0017:\n\tv50 = new v48();\nL_FFFFFFFF:\n\tv76 = v50;\n\tgoto L_0023;\nL_0023:\n\tSystem.Object::.ctor(v76);\n\tv76._obj = obj;\n\treturn v76;\nL_0032:\n\tv29 = 0x220C238(Il2CppClass<_game.CoreSystem.GenericInstaller`1>, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv55 = *([v29 @ X0_v6+C0]);\n\tv48 = *([v55 @ X8_v6+8]);\n\tv57 = *([v48 @ X0_v16 (Il2CppClass<_game.CoreSystem.GenericInstaller`1<T>>)+135]) & 1;\n\tv58 = v57 == 0;\n\tv45 = ~v58;\nL_FFFFFFFF:\n\tv53 = v48;\n\tif (v45) goto L_0017;\nL_003B:\n\tv54 = 0x220C238(v53, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv66 = new v54();\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv76 = v66;\n\tgoto L_0023;\n")]
		public static GenericInstaller<T> New(T obj)
		{
			//IL_00c6: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X0_v1 (Il2CppClass<_game.CoreSystem.GenericInstaller`1>)+135]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X0_v19 (Il2CppClass<_game.CoreSystem.GenericInstaller`1<T>>)+135]");
				int num3 = (int)((nint)0 & (nint)1);
				bool flag = num3 == 0;
				nint num4 = 0;
				nint num5 = 0;
				if (!flag)
				{
					goto IL_007e;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ X0_v6+C0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v6+8]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X0_v16 (Il2CppClass<_game.CoreSystem.GenericInstaller`1<T>>)+135]");
				int num6 = (int)((nint)0 & (nint)1);
				bool flag2 = num6 == 0;
				bool flag3 = !flag2;
				nint num5 = num4;
				if (flag3)
				{
					goto IL_007e;
				}
			}
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			GenericInstaller<T> genericInstaller = null;
			GenericInstaller<T> genericInstaller2 = genericInstaller;
			goto IL_0090;
			IL_0090:
			genericInstaller2._obj = obj;
			return genericInstaller2;
			IL_007e:
			GenericInstaller<T> genericInstaller3 = null;
			genericInstaller2 = genericInstaller3;
			goto IL_0090;
		}
	}
}
