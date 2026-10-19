using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Reflex.Extensions
{
	[Token(Token = "0x2000023")]
	internal static class EnumerableExtensions
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000024")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000036")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000037")]
			public static Func<Type, Func<IEnumerable, object>> _003C_003E9__2_0;

			[Token(Token = "0x6000064")]
			[Address(RVA = "0x3F33D24", Offset = "0x3F33D24", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Reflex.Extensions.EnumerableExtensions+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000065")]
			[Address(RVA = "0x3F33D88", Offset = "0x3F33D88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal Func<IEnumerable, object> _003CCastDynamic_003Eb__2_0(Type t)
			{
				int num = 187211776 + 2744;
				Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:SzArrayNew", "Unknown call target operand: \"SzArrayNew\"");
				Type[] array = default(Type[]);
				if (array != null)
				{
					if ((object)t != null)
					{
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
						object obj = default(object);
						if (obj == null)
						{
							goto IL_00ed;
						}
					}
					array[0] = t;
					MethodInfo methodInfo = _enumerableCastMethodInfo.MakeGenericMethod(array);
					return methodInfo.CreateDelegate<Func<IEnumerable, object>>();
				}
				NullReferenceException ex = new NullReferenceException();
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
				goto IL_00ed;
				IL_00ed:
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000025")]
		private sealed class _003CReversed_003Ed__3<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000038")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000039")]
			[FieldOffset(Offset = "0x0")]
			private T _003C_003E2__current;

			[Token(Token = "0x400003A")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003El__initialThreadId;

			[Token(Token = "0x400003B")]
			[FieldOffset(Offset = "0x0")]
			private IList<T> items;

			[Token(Token = "0x400003C")]
			[FieldOffset(Offset = "0x0")]
			public IList<T> _003C_003E3__items;

			[Token(Token = "0x400003D")]
			[FieldOffset(Offset = "0x0")]
			private int _003Ci_003E5__2;

			[Token(Token = "0x17000011")]
			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600006A")]
				[Address(RVA = "0x50142FC", Offset = "0x50142FC", Length = "0x48")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = Il2CppClass<T>;\n\tv17 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv19 = *([v17 @ X8_v3 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0x20;\n\tv20 = 0x21C1054(this, v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturnVal1 = 0x8BF6A34(il2cppRetVal, v20, *([v15 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n")]
				get
				{
					//IL_0022: Expected O, but got I
					nint num = 0;
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v3 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]");
					object obj = (nint)0 + (nint)32;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A34");
					T result = default(T);
					return result;
				}
			}

			[Token(Token = "0x17000012")]
			unsafe object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600006C")]
				[Address(RVA = "0x501437C", Offset = "0x501437C", Length = "0xB0")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = *([A4731E0]);\n\tv22 = Il2CppClass<T>;\n\tv26 = *([v22 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv27 = v26 & 0x1FFFFFFF0;\n\t// 21 StackAlloc v28 @ X21_v1 (System.Byte*), v27 @ X10_v2 (System.Int32)\n\tv30 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv32 = *([v30 @ X8_v6 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0x20;\n\tv33 = 0x21C1054(this, v32, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 0x8BF6A1C(v28, v33, *([v22 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t// 35 Box returnVal1 @ X0_v5 (System.Object), typeof(Il2CppClass<T>), v28 @ X21_v1 (System.Byte*)\n\tv60 = *([A4731E0]);\n\tv71 = *([v60 @ X9_v4]) != *([v17 @ X8_v2]);\n\tif (v71) goto L_003C;\n\treturn returnVal1;\nL_003C:\n\treturnVal2 = 0x8BF5CF0(returnVal1, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\n")]
				get
				{
					//IL_0010: Expected O, but got I
					//IL_002c: Expected O, but got I
					//IL_003f: Expected I4, but got I8
					//IL_0066: Expected O, but got I
					//IL_00a6: Expected O, but got I
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
					object obj = 0;
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X9_v1 (Il2CppClass<T>)+FC]");
					object obj2 = (nint)0 + (nint)15;
					int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
					byte* ptr = stackalloc byte[(int)(uint)num2];
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X8_v6 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]");
					object obj3 = (nint)0 + (nint)32;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
					object result = (nint)ptr;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
					object obj4 = 0;
					if (obj4 == obj)
					{
						return result;
					}
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
					object result2 = default(object);
					return result2;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000067")]
			[Address(RVA = "0x5013EA0", Offset = "0x5013EA0", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv23 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv24 = *([v23 @ X8_v3 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]);\n\tv27 = 0x815C(*([v23 @ X8_v3 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv43 = 0x21C1054(this, *([v23 @ X8_v3 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v43 @ X0_v4]) = <>1__state;\n\tv47 = 0x21C0FD4(*([v24 @ X22_v1+8]), v43, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv49 = System.Environment::get_CurrentManagedThreadId();\n\tv53 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv54 = *([v53 @ X8_v6 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]);\n\tv55 = *([v53 @ X8_v6 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0x40;\n\tv57 = 0x815C(v55, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv58 = *([v53 @ X8_v6 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0x40;\n\tv60 = 0x21C1054(this, v58, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v60 @ X0_v12]) = v49;\n\tv70 = 0x21C0FD4(*([v54 @ X19_v2+48]), v60, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			public _003CReversed_003Ed__3(int _003C_003E1__state)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]");
				object obj = 0;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
				object obj2 = _003C_003E1__state;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]");
				object obj4 = (nint)0 + (nint)64;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]");
				object obj5 = (nint)0 + (nint)64;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
				object obj6 = currentManagedThreadId;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			}

			[DebuggerHidden]
			[Token(Token = "0x6000068")]
			[Address(RVA = "0x5013F54", Offset = "0x5013F54", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000069")]
			[Address(RVA = "0x5013F58", Offset = "0x5013F58", Length = "0x3A4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = *([A4731E0]);\n\tv28 = Il2CppClass<T>;\n\tv32 = *([v28 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv33 = v32 & 0x1FFFFFFF0;\n\t// 24 StackAlloc v34 @ X22_v1 (System.Byte*), v33 @ X10_v2 (System.Int32)\n\tv36 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv229 = 0x21C1054(this, *([v36 @ X8_v6 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv58 = *([v229 @ X0_v34]) == 1;\n\tif (v58) goto L_0075;\n\tv63 = *([v229 @ X0_v34]) == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_00F4;\n\tv74 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv75 = *([v74 @ X8_v57 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]);\n\tv78 = 0x815C(*([v74 @ X8_v57 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv142 = 0x21C1054(this, *([v74 @ X8_v57 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v142 @ X0_v51]) = -1;\n\tv246 = 0x21C0FD4(*([v75 @ X23_v10+8]), v142, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv324 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv311 = *([v324 @ X8_v61 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0x60;\n\tv309 = 0x21C1054(this, v311, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0054;\nL_0075:\n\tv67 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv68 = *([v67 @ X8_v49 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]);\n\tv71 = 0x815C(*([v67 @ X8_v49 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv139 = 0x21C1054(this, *([v67 @ X8_v49 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v139 @ X0_v42]) = -1;\n\tv241 = 0x21C0FD4(*([v68 @ X23_v9+8]), v139, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv317 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv319 = *([v317 @ X8_v53 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0xA0;\n\tv321 = 0x21C1054(this, v319, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv344 = *([v321 @ X0_v46]);\n\tgoto L_0096;\n\tv410 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv115 = *([v410 @ X8_v14 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0xA0;\n\tv229 = 0x21C1054(this, v115, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv434 = *([v229 @ X0_v34]) & 0x80000000;\n\tv435 = v434 == 0;\n\tv95 = ~v435;\n\tif (v95) goto L_00F4;\n\tv446 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv448 = *([v446 @ X8_v19 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0x60;\n\tv450 = 0x21C1054(this, v448, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv167 = *([v450 @ X0_v12]);\n\tv453 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv312 = *([v453 @ X8_v23 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0xA0;\n\tv310 = 0x21C1054(this, v312, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00CE;\n\tv509 = *([v468 @ X8_v29+B0]) + 8;\n\tv509 = v509 + 0x10;\n\tv495 = v510 - 1;\n\tv475 = v510 != 1;\n\tv510 = v495;\n\tif (v475) goto L_00D5;\nL_00EF:\n\tv534 = 0x220C5E0(v167, Il2CppClass<System.Collections.Generic.IList`1<T>>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0112;\nL_00F4:\n\tv125 = *([A4731E0]);\n\tv136 = *([v125 @ X9_v18]) != *([v23 @ X8_v2]);\n\tv196 = 0;\n\tif (v136) goto L_0142;\nL_010C:\n\treturn v196;\nL_010E:\n\tv522 = *([v509 @ X10_v8]) << 4;\n\tv523 = v468 + v522;\n\tv534 = v523 + 0x138;\n\t*([v560 @ X0_v24]) = 1;\n\tv229 = 0x21C0FD4(*([v199 @ X20_v2+8]), v560, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv563 = *([A4731E0]);\n\tv179 = *([v563 @ X9_v7]) == *([v23 @ X8_v2]);\n\tv196 = 1;\n\tif (v179) goto L_010C;\nL_0142:\n\tv236 = 0x8BF5CF0(v229, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_0054:\n\tgoto L_0093;\nL_0093:\n\tv344 = System.Collections.Generic.ICollection`1<T>::get_Count(*([v309 @ X0_v55]));\nL_0096:\n\tv354 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv93 = *([v354 @ X8_v11 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]);\n\tv83 = v344 - 1;\n\tv355 = *([v354 @ X8_v11 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0xA0;\n\tv357 = 0x815C(v355, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv366 = *([v354 @ X8_v11 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0xA0;\n\tv368 = 0x21C1054(this, v366, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v368 @ X0_v6]) = v83;\n\tv378 = 0x21C0FD4(*([v93 @ X23_v2+A8]), v368, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_00CE:\n\tv155 = *([v310 @ X0_v14]);\n\tv468 = *([v167 @ X23_v3]);\n\tv510 = *([v468 @ X8_v29+12E]);\n\tv169 = *([v468 @ X8_v29+12E]) == 0;\n\tif (v169) goto L_00EF;\nL_00D5:\n\t;\n\tv515 = *([v509 @ X10_v8-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v515) goto L_010E;\nL_0112:\n\tv152 = &v155 @ stack_-5C_v1;\n\tv149 = v34;\n\tv538 = *([v534 @ X0_v16+8]);\n\t*([v538 @ X1_v11+10])(v543, *([v538 @ X1_v11+8]), *([v534 @ X0_v16+8]), v167, &v152 @ stack_-58_v1, v34, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv54\n// ... truncated")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("EnumerableExtensions._003CReversed_003Ed__3::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600006B")]
			[Address(RVA = "0x5014344", Offset = "0x5014344", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0xB292000 + 0x4A0;\n\tv28 = new v12();\n\tSystem.NotSupportedException::.ctor(v28);\n\tthrow v28;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x600006D")]
			[Address(RVA = "0x501442C", Offset = "0x501442C", Length = "0x160")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv22 = 0x21C1054(this, *([v20 @ X8_v3 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]), v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv48 = *([v22 @ X0_v1]) != -2;\n\tif (v48) goto L_004A;\n\tv51 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv53 = *([v51 @ X8_v24 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0x40;\n\tv55 = 0x21C1054(this, v53, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv77 = System.Environment::get_CurrentManagedThreadId();\n\tv59 = *([v55 @ X0_v21]) != v77;\n\tif (v59) goto L_004A;\n\tv102 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv103 = *([v102 @ X8_v28 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]);\n\tv106 = 0x815C(*([v102 @ X8_v28 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv135 = 0x21C1054(this, *([v102 @ X8_v28 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv135.m_value = 0;\n\tv122 = Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>::.ctor(*([v103 @ X21_v7+8]), v135);\n\tv109 = this;\n\tgoto L_0056;\nL_004A:\n\tgoto L_004C;\nL_004C:\n\tv91 = new Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>();\n\tv99 = Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>::.ctor(v91, 0);\n\tv109 = v91;\n\tv141 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv142 = *([v141 @ X8_v12 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]);\n\tv143 = *([v141 @ X8_v12 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0x60;\n\tv145 = 0x815C(v143, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv147 = *([v141 @ X8_v12 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0x60;\n\tv149 = 0x21C1054(v109, v147, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v149 @ X0_v9]) = *([v132 @ X0_v4]);\n\tv153 = 0x21C0FD4(*([v142 @ X19_v2+68]), v149, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v109;\nL_0056:\n\tv128 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv130 = *([v128 @ X8_v8 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0x80;\n\tv132 = 0x21C1054(this, v130, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("EnumerableExtensions._003CReversed_003Ed__3::GetEnumerator");
				return default;
			}

			[DebuggerHidden]
			[Token(Token = "0x600006E")]
			[Address(RVA = "0x501458C", Offset = "0x501458C", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>::System.Collections.Generic.IEnumerable<T>.GetEnumerator(this);\n\treturn this;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				((IEnumerable<T>)this).GetEnumerator();
				return this;
			}
		}

		[Token(Token = "0x4000034")]
		private static readonly ConcurrentDictionary<Type, Func<IEnumerable, object>> _enumerableCastDelegates;

		[Token(Token = "0x4000035")]
		private static readonly MethodInfo _enumerableCastMethodInfo;

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x3F33A74", Offset = "0x3F33A74", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv108 = 0xB298000 + 0xC88;\n\tgoto L_001A;\nL_001A:\n\tv135 = v58._enumerableCastDelegates;\n\tv71 = *([v108 @ X24_v4 (System.Int32)]);\n\tv62 = *([v71 @ X0_v39+E4]) == 0;\n\tv110 = v58._enumerableCastDelegates;\n\tif (v62) goto L_0049;\n\tv149 = *([v71 @ X0_v39+B8]);\n\tv138 = *([v149 @ X8_v8+8]);\n\tv82 = *([v149 @ X8_v8+8]) == 0;\n\tv110 = v135;\n\tif (v82) goto L_0052;\nL_0023:\n\tv105 = v135 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_0070;\n\tgoto L_0082;\nL_0049:\n\tv96 = *([v108 @ X24_v4 (System.Int32)]);\n\tv149 = *([v96 @ X0_v17+B8]);\n\tv138 = *([v149 @ X8_v8+8]);\n\tv116 = *([v149 @ X8_v8+8]) == 0;\n\tv99 = ~v116;\n\tv135 = v135;\n\tv108 = v108;\n\tif (v99) goto L_0023;\nL_0052:\n\tgoto L_005A;\n\tv135 = v110;\n\tv138 = v154;\nL_0070:\n\tv146 = System.Collections.Concurrent.ConcurrentDictionary`2<System.Type, System.Func`2<System.Collections.IEnumerable, System.Object>>::GetOrAdd(v135, target, v138);\n\tv181 = System.Func`2<System.Collections.IEnumerable, System.Object>::Invoke(v146, source);\n\treturn v146.method_code;\nL_0082:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_005A:\n\tv154 = new System.Func`2<System.Type, System.Func`2<System.Collections.IEnumerable, System.Object>>();\n\tSystem.Func`2<System.Type, System.Func`2<System.Collections.IEnumerable, System.Object>>::.ctor(v154, *([v149 @ X8_v8]), Il2CppMethodInfo);\n\tv137 = *([v108 @ X24_v4 (System.Int32)]);\n\tv192 = *([v137 @ X8_v13+B8]) + 8;\n\t*([v192 @ X0_v12]) = v154;\n")]
		public static object CastDynamic(this IEnumerable source, Type target)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnumerableExtensions::CastDynamic");
			return default;
		}

		[IteratorStateMachine(typeof(_003CReversed_003Ed__3<>))]
		[Token(Token = "0x6000062")]
		[Address(RVA = "0x495AB78", Offset = "0x495AB78", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv49 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tgoto L_0015;\nL_0015:\n\tv52 = new v49();\n\tv61 = Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>::.ctor(v52, -2);\n\tv64 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tv65 = *([v64 @ X8_v9 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]);\n\tv66 = *([v64 @ X8_v9 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0x80;\n\tv68 = 0x815C(v66, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv70 = *([v64 @ X8_v9 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]) + 0x80;\n\tv72 = 0x21C1054(v52, v70, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v72 @ X0_v11]) = items;\n\tv76 = 0x21C0FD4(*([v65 @ X20_v2+88]), v72, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v52;\n\tv27 = 0x220C2B8(methodInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv49 = Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>;\n\tgoto L_0015;\n")]
		public static IEnumerable<T> Reversed<T>(this IList<T> items)
		{
			//IL_003a: Expected O, but got I
			//IL_0050: Expected O, but got I
			//IL_0075: Expected O, but got I
			nint num = 0;
			IEnumerable<T> result = new _003CReversed_003Ed__3<T>(-2);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X8_v9 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X8_v9 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]");
			object obj2 = (nint)0 + (nint)128;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X8_v9 (Il2CppClass<Reflex.Extensions.EnumerableExtensions+<Reversed>d__3`1<T>>)+80]");
			object obj3 = (nint)0 + (nint)128;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			return result;
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x3F33C10", Offset = "0x3F33C10", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tgoto L_003E;\nL_003E:\n\tv84 = System.Type::GetTypeFromHandle(System.Linq.Enumerable);\n\tv90 = System.Type::GetMethod(v84, \"Cast\");\n\tv94._enumerableCastMethodInfo = v90;\n\treturn;\nL_002A:\n\tv55 = new System.Collections.Concurrent.ConcurrentDictionary`2<System.Type, System.Func`2<System.Collections.IEnumerable, System.Object>>();\n\tSystem.Collections.Concurrent.ConcurrentDictionary`2<System.Type, System.Func`2<System.Collections.IEnumerable, System.Object>>::.ctor(v55);\n\tv65._enumerableCastDelegates = v55;\n")]
		static EnumerableExtensions()
		{
			ConcurrentDictionary<Type, Func<IEnumerable, object>> enumerableCastDelegates = new ConcurrentDictionary<Type, Func<IEnumerable, object>>();
			_enumerableCastDelegates = enumerableCastDelegates;
			Type typeFromHandle = typeof(Enumerable);
			MethodInfo method = typeFromHandle.GetMethod("Cast");
			_enumerableCastMethodInfo = method;
		}
	}
}
