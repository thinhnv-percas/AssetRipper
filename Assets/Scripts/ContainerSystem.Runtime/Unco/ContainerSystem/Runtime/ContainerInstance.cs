using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Core;

namespace Unco.ContainerSystem.Runtime
{
	[Token(Token = "0x2000047")]
	public readonly ref struct ContainerInstance
	{
		[Token(Token = "0x4000079")]
		[FieldOffset(Offset = "0x0")]
		internal readonly Container Container;

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0x3F3A868", Offset = "0x3F3A868", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Container = container;\n\treturn;\n")]
		internal ContainerInstance(Container container)
		{
			Container = container;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000FD")]
		[Address(RVA = "0x48668A8", Offset = "0x48668A8", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\n\tv18 = 0x220C2B8(methodInfo, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_000E:\n\tv34 = this.Container;\n\tv34 = Reflex.Core.Container::HasBinding(v34);\n\treturn v34;\n")]
		public bool HasBinding<T>()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerInstance::HasBinding");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000FE")]
		[Address(RVA = "0x48668F0", Offset = "0x48668F0", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = 0x220C2B8(methodInfo, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0018:\n\treturnVal1 = Reflex.Core.Container::Resolve(this.Container);\n\treturn returnVal1;\n")]
		public T Resolve<T>()
		{
			return Container.Resolve<T>();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60000FF")]
		[Address(RVA = "0x4866AC4", Offset = "0x4866AC4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv24 = 0x220C2B8(methodInfo, v38, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001E:\n\treturnVal1 = Reflex.Core.Container::TryResolve(this.Container, v38);\n\treturn returnVal1;\n")]
		public bool TryResolve<T>(out T result)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerInstance::TryResolve");
			result = default;
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000100")]
		[Address(RVA = "0x48669FC", Offset = "0x48669FC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = *([A4731E0]);\n\tgoto L_0017;\n\tv28 = 0x220C2B8(methodInfo, il2cppRetVal, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv56 = Il2CppMethodInfo;\n\tv58 = v52;\n\t*([v56 @ X1_v2 (Il2CppMethodInfo)+10])(v62, *([v56 @ X1_v2 (Il2CppMethodInfo)]), Il2CppMethodInfo, this.Container, &v58 @ stack_-40_v2 (System.Byte*), v52, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturnVal1 = 0x8BF6A1C(il2cppRetVal, v52, *([v46 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv70 = *([A4731E0]);\n\tv81 = *([v70 @ X9_v5]) != *([v19 @ X8_v2]);\n\tif (v81) goto L_0045;\n\treturn returnVal1;\nL_0045:\n\treturnVal2 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_0017:\n\tv46 = Il2CppClass<T>;\n\tv50 = *([v46 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv51 = v50 & 0x1FFFFFFF0;\n\t// 28 StackAlloc v52 @ X22_v1 (System.Byte*), v51 @ X10_v2 (System.Int32)\n")]
		public unsafe T Single<T>()
		{
			//IL_0010: Expected O, but got I
			//IL_00b4: Expected O, but got I
			//IL_00c7: Expected I4, but got I8
			//IL_0060: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X9_v1 (Il2CppClass<T>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num2];
			nint num3 = 0;
			byte* ptr2 = ptr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v56 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj3 = 0;
			T result = default(T);
			if (obj3 == obj)
			{
				return result;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			T result2 = default(T);
			return result2;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000101")]
		[Address(RVA = "0x4866860", Offset = "0x4866860", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\n\tv18 = 0x220C2B8(methodInfo, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_000E:\n\tv34 = this.Container;\n\tv34 = Reflex.Core.Container::All(v34);\n\treturn v34;\n")]
		public IEnumerable<T> All<T>()
		{
			Container container = Container;
			return container.All<T>();
		}
	}
}
