using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x7445DC", Offset = "0x7445DC")]
	[Token(Token = "0x2000039")]
	public class ObiList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		[CompilerGenerated]
		[Token(Token = "0x20000AF")]
		private sealed class _003CGetEnumerator_003Ed__2 : IEnumerator<T>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40002ED")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E1__state;

			[Token(Token = "0x40002EE")]
			[FieldOffset(Offset = "0x0")]
			private T _003C_003E2__current;

			[Token(Token = "0x40002EF")]
			[FieldOffset(Offset = "0x0")]
			public ObiList<T> _003C_003E4__this;

			[Token(Token = "0x40002F0")]
			[FieldOffset(Offset = "0x0")]
			private int _003Ci_003E5__2;

			[Token(Token = "0x170000D8")]
			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000553")]
				[Address(RVA = "0x10A78DC", Offset = "0x10A78DC", Length = "0x10")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x14;\n\treturnVal1 = 0x6D2410(v4, v0, 0x44, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18);\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_000c: Expected O, but got I
					object obj = (long)(IntPtr)this + 20L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
					T result = default(T);
					return result;
				}
			}

			[Token(Token = "0x170000D9")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000555")]
				[Address(RVA = "0x10A7950", Offset = "0x10A7950", Length = "0x5C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this + 0x14;\n\tv15 = 0x6D2410(&v13 @ stack_-68, v10, 0x44, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tgoto L_0016;\n\tv36 = v31;\n\tv37 = 0x8907BC(v36, v10, v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\nL_0016:\n\t// 22 Box returnVal1 @ X0_v5 (System.Object), typeof(Il2CppClass<T>), &v13 @ stack_-68\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_000c: Expected O, but got I
					//IL_0024: Expected I, but got O
					object obj = (long)(IntPtr)this + 20L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
					object obj2 = default(object);
					return (IntPtr)obj2;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000550")]
			[Address(RVA = "0x10A77E4", Offset = "0x10A77E4", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CGetEnumerator_003Ed__2(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000551")]
			[Address(RVA = "0x10A781C", Offset = "0x10A781C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000552")]
			[Address(RVA = "0x10A7820", Offset = "0x10A7820", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv55 = this.<>1__state;\n\tv11 = *([this @ X0 (Obi.ObiList`1<T>+<GetEnumerator>d__2<T>)+58]);\n\tv16 = this.<>1__state == 1;\n\tif (v16) goto L_001E;\n\tv21 = v55 == 0;\n\tv22 = ~v21;\n\tif (v22) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\t*([this @ X0 (Obi.ObiList`1<T>+<GetEnumerator>d__2<T>)+60]) = 0;\n\tv28 = v11 == 0;\n\tv29 = ~v28;\n\tif (v29) goto L_002D;\n\tgoto L_004E;\nL_001E:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv55 = *([this @ X0 (Obi.ObiList`1<T>+<GetEnumerator>d__2<T>)+60]) + 1;\n\t*([this @ X0 (Obi.ObiList`1<T>+<GetEnumerator>d__2<T>)+60]) = v55;\nL_002D:\n\tv32 = v55 >= *([v11 @ X8_v1+18]);\n\tif (v32) goto L_FFFFFFFF;\n\tv72 = *([v11 @ X8_v1+10]);\n\tv162 = v55 < *([v72 @ X8_v5+18]);\n\tv117 = ~v162;\n\tif (v117) goto L_004F;\n\tv101 = v55 * 0x44;\n\tv119 = v72 + v101;\n\tv96 = v119 + 0x20;\n\tv163 = this + 0x14;\n\tv164 = 0x6D1DA0(v163, v96, 0x44, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90);\n\tthis.<>1__state = 1;\n\tgoto L_004C;\nL_004C:\n\treturn returnVal1;\nL_004E:\n\tv75 = new System.NullReferenceException();\nL_004F:\n\tv139 = new System.IndexOutOfRangeException();\n\tthrow v139;\n\treturn returnVal2;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_001a: Expected O, but got I
				//IL_0101: Expected O, but got I
				//IL_0151: Expected O, but got I
				//IL_0160: Expected O, but got I
				//IL_016c: Expected O, but got I
				int num = _003C_003E1__state;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Obi.ObiList`1<T>+<GetEnumerator>d__2<T>)+58]");
				object obj = 0;
				if (_003C_003E1__state != 1)
				{
					if (num != 0)
					{
						goto IL_018f;
					}
					_003C_003E1__state = -1;
					_ = 0;
					if (obj == null)
					{
						NullReferenceException ex = new NullReferenceException();
						goto IL_01ab;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Obi.ObiList`1<T>+<GetEnumerator>d__2<T>)+60]");
					num = 1;
				}
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X8_v1+18]");
				if ((long)num2 >= 0L)
				{
					goto IL_018f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ X8_v1+10]");
				object obj2 = 0;
				int num3 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X8_v5+18]");
				if ((long)num3 < 0L)
				{
					int num4 = num * 68;
					object obj3 = (long)(IntPtr)obj2 + (long)num4;
					object obj4 = (long)(IntPtr)obj3 + 32L;
					object obj5 = (long)(IntPtr)this + 20L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1DA0 (native memmove)");
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_01ab;
				IL_018f:
				return false;
				IL_01ab:
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
				throw ex2;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000554")]
			[Address(RVA = "0x10A78EC", Offset = "0x10A78EC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EA3780]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2026B16]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}
		}

		[Token(Token = "0x40000CB")]
		[FieldOffset(Offset = "0x0")]
		private T[] data = null;

		[Token(Token = "0x40000CC")]
		[FieldOffset(Offset = "0x0")]
		private int count;

		[Token(Token = "0x1700004D")]
		public int Count
		{
			[Token(Token = "0x60002BD")]
			[Address(RVA = "0x10A949C", Offset = "0x10A949C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.count;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Count;
			}
		}

		[Token(Token = "0x1700004E")]
		public bool IsReadOnly
		{
			[Token(Token = "0x60002BE")]
			[Address(RVA = "0x10A823C", Offset = "0x10A823C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700004F")]
		public T Item
		{
			[Token(Token = "0x60002C2")]
			[Address(RVA = "0x10A8F4C", Offset = "0x10A8F4C", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.data;\n\tv10 = v6.Length < index;\n\tv12 = ~v10;\n\tv13 = v6.Length - index;\n\tv15 = v13 == 0;\n\tv20 = ~v12;\n\tv21 = v20 | v15;\n\tif (v21) goto L_0021;\n\tv39 = index << 7;\n\tv40 = v6 + v39;\n\tv41 = v40 + 0x20;\n\treturnVal1 = 0x6D2410(v44, v41, 0x80, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn returnVal1;\n\tv23 = new System.NullReferenceException();\nL_0021:\n\tv69 = new System.IndexOutOfRangeException();\n\tthrow v69;\n\treturn returnVal2;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_008a: Expected O, but got I
				//IL_0099: Expected O, but got I
				T[] array = Data;
				bool flag = array.Length < index;
				bool flag2 = !flag;
				int num = array.Length - index;
				bool flag3 = num == 0;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					int num2 = index << 7;
					object obj = (long)(IntPtr)array + (long)num2;
					object obj2 = (long)(IntPtr)obj + 32L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
					T result = default(T);
					return result;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			[Token(Token = "0x60002C3")]
			[Address(RVA = "0x10A8570", Offset = "0x10A8570", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.data;\n\tv22 = 0x6D2410(&v19 @ stack_-78, value, 0x44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv42 = 0x6D2410(&v38 @ stack_-C0, &v19 @ stack_-78, 0x44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv46 = v12.Length < index;\n\tv47 = ~v46;\n\tv48 = v12.Length - index;\n\tv50 = v48 == 0;\n\tv55 = ~v47;\n\tv56 = v55 | v50;\n\tif (v56) goto L_0031;\n\tv81 = index * 0x44;\n\tv82 = v12 + v81;\n\tv83 = v82 + 0x20;\n\tv86 = 0x6D2410(v83, &v38 @ stack_-C0, 0x44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn;\n\tv44 = new System.NullReferenceException();\nL_0031:\n\tv80 = new System.IndexOutOfRangeException();\n\tthrow v80;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_009e: Expected O, but got I
				//IL_00ad: Expected O, but got I
				T[] array = Data;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				bool flag = array.Length < index;
				bool flag2 = !flag;
				int num = array.Length - index;
				bool flag3 = num == 0;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					int num2 = index * 68;
					object obj = (long)(IntPtr)array + (long)num2;
					object obj2 = (long)(IntPtr)obj + 32L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
					return;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
		}

		[Token(Token = "0x17000050")]
		public T[] Data
		{
			[Token(Token = "0x60002C4")]
			[Address(RVA = "0x10A9718", Offset = "0x10A9718", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.data;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Data;
			}
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x747210", Offset = "0x747210")]
		[Token(Token = "0x60002B6")]
		[Address(RVA = "0x10A7CCC", Offset = "0x10A7CCC", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv23 = v18;\n\tv24 = 0x8907BC(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0014:\n\tv41 = new Il2CppClass<Obi.ObiList`1<T>+<GetEnumerator>d__2<T>>();\n\tv48 = Obi.ObiList`1<T>+<GetEnumerator>d__2<T>::.ctor(v41, 0);\n\t*([v41 @ X0_v3 (System.Collections.Generic.IEnumerator`1<T>)+58]) = this;\n\treturn v41;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerator<T> GetEnumerator()
		{
			//yield-return decompiler failed: Could not find currentField
			return new _003CGetEnumerator_003Ed__2(0);
		}

		[Token(Token = "0x60002B7")]
		[Address(RVA = "0x10A7D48", Offset = "0x10A7D48", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X2_v1, this @ X0 (Obi.ObiList`1<T>), this @ X0 (Obi.ObiList`1<T>), methodof(Obi.ObiList`1<T>::GetEnumerator), v6 @ X2_v1, v7 @ X3, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		IEnumerator IEnumerable.GetEnumerator()
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X2_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x60002B8")]
		[Address(RVA = "0x10A7D6C", Offset = "0x10A7D6C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = this.data;\n\tv23 = 0x6D2410(&v21 @ stack_-78, item, 0x44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv43 = 0x6D2410(&v40 @ stack_-C0, &v21 @ stack_-78, 0x44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = this.count < v16.Length;\n\tv48 = ~v47;\n\tif (v48) goto L_003A;\n\tv79 = this.count * 0x44;\n\tv80 = v16 + v79;\n\tv81 = v80 + 0x20;\n\tv84 = 0x6D2410(v81, &v40 @ stack_-C0, 0x44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv90 = this.count + 1;\n\tthis.count = v90;\n\tv95 = Obi.ObiList`1<T>::EnsureCapacity(this, v90);\n\treturn;\n\tv45 = new System.NullReferenceException();\nL_003A:\n\tv77 = new System.IndexOutOfRangeException();\n\tthrow v77;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Add(T item)
		{
			//IL_006c: Expected O, but got I
			//IL_007b: Expected O, but got I
			T[] array = Data;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
			if (Count < array.Length)
			{
				int num = Count * 68;
				object obj = (long)(IntPtr)array + (long)num;
				object obj2 = (long)(IntPtr)obj + 32L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				EnsureCapacity(count = Count + 1);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60002B9")]
		[Address(RVA = "0x10A9220", Offset = "0x10A9220", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.count = 0;\n\treturn;\n")]
		public void Clear()
		{
			count = 0;
		}

		[Token(Token = "0x60002BA")]
		[Address(RVA = "0x10A7E2C", Offset = "0x10A7E2C", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv41 = this.count < 1;\n\tif (v41) goto L_FFFFFFFF;\nL_001F:\n\tv45 = this.data;\n\tv155 = 0x6D2410(&v152 @ stack_-A8, item, 0x44, v156, v157, v158, v159, v160, v161, v162, v163, v164, v165, v166, v167, v168);\n\tgoto L_0032;\n\tv269 = v250;\n\tv270 = 0x8907BC(v269, v154, v153, v156, v157, v158, v159, v160, v161, v162, v163, v164, v165, v166, v167, v168);\nL_0032:\n\t// 50 Box v274 @ X0_v14, typeof(Il2CppClass<T>), &v152 @ stack_-A8\n\tgoto L_003F;\n\tv282 = v277;\n\tv283 = 0x8907BC(v282, v272, v153, v156, v157, v158, v159, v160, v161, v162, v163, v164, v165, v166, v167, v168);\nL_003F:\n\tv286 = v97 < v45.Length;\n\tv267 = ~v286;\n\tif (v267) goto L_008C;\n\tv287 = v97 * 0x44;\n\tv268 = v45 + v287;\n\tv57 = v268 + 0x20;\n\t// 78 Box v259 @ X0_v20, typeof(Il2CppClass<T>), v57 @ X22_v9\n\tv295 = *([v259 @ X0_v20]);\n\t*([v295 @ X8_v16+130])(v298, v259, v274, *([v295 @ X8_v16+138]), v156, v157, v158, v159, v160, v161, v162, v163, v164, v165, v166, v167, v168);\n\tv293 = \"il2cpp_vm_object_unbox\"(v259, v274, *([v295 @ X8_v16+138]), v156, v157, v158, v159, v160, v161, v162, v163, v164, v165, v166, v167, v168);\n\tv300 = v97 < v45.Length;\n\tv137 = ~v300;\n\tif (v137) goto L_008C;\n\tv63 = 0x6D2410(v57, v293, 0x44, v156, v157, v158, v159, v160, v161, v162, v163, v164, v165, v166, v167, v168);\n\tv302 = v298 & 1;\n\tv303 = v302 == 0;\n\tv54 = ~v303;\n\tif (v54) goto L_FFFFFFFF;\n\tv97 = v97 + 1;\n\tv68 = v97 < this.count;\n\tif (v68) goto L_001F;\n\tgoto L_008B;\nL_008B:\n\treturn returnVal1;\nL_008C:\n\tv294 = new System.IndexOutOfRangeException();\n\tthrow v294;\n\tv204 = new System.NullReferenceException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Contains(T item)
		{
			//IL_0045: Expected I, but got O
			//IL_0093: Expected O, but got I
			//IL_00a2: Expected O, but got I
			//IL_00ab: Expected I, but got O
			if (Count >= 1)
			{
				int num = 0;
				object obj2 = default(object);
				object obj7 = default(object);
				while (true)
				{
					T[] array = Data;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
					object obj = (IntPtr)obj2;
					if (num < array.Length)
					{
						int num2 = num * 68;
						object obj3 = (long)(IntPtr)array + (long)num2;
						object obj4 = (long)(IntPtr)obj3 + 32L;
						object obj5 = (IntPtr)obj4;
						object obj6 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v295 @ X8_v16+130] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						if (num < array.Length)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
							if ((int)((long)(IntPtr)obj7 & 1L) == 0)
							{
								num++;
								if (num >= Count)
								{
									break;
								}
								continue;
							}
							return true;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			return false;
		}

		[Token(Token = "0x60002BB")]
		[Address(RVA = "0x10A7F8C", Offset = "0x10A7F8C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EDD780]);\n\tv27 = *([v26 @ X8_v14]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, array, arrayIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026B19]) = v44;\nL_0017:\n\tv45 = array == 0;\n\tif (v45) goto L_0039;\n\tv48 = array.Length - arrayIndex;\n\tv59 = v48 < this.count;\n\tif (v59) goto L_0041;\n\tSystem.Array::Copy(this.data, 0, array, arrayIndex, this.count);\n\treturn;\nL_0039:\n\tv63 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v63);\n\tgoto L_004A;\nL_0041:\n\tv78 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v78);\nL_004A:\n\tthrow v115;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array != null)
			{
				int num = array.Length - arrayIndex;
				if (num >= Count)
				{
					Array.Copy(Data, 0, array, arrayIndex, Count);
					return;
				}
				ArgumentException ex = new ArgumentException();
			}
			else
			{
				ArgumentNullException ex2 = new ArgumentNullException();
			}
			object obj = default(object);
			throw obj;
		}

		[Token(Token = "0x60002BC")]
		[Address(RVA = "0x10A805C", Offset = "0x10A805C", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv182 = this.count;\n\tv41 = this.count < 1;\n\tif (v41) goto L_FFFFFFFF;\nL_0020:\n\tv110 = v99 & 1;\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_0073;\n\tv147 = this.data;\n\tv244 = 0x6D2410(&v241 @ stack_-A8, item, 0x44, v245, v246, v247, v248, v249, v250, v251, v252, v253, v254, v255, v256, v257);\n\tgoto L_0037;\n\tv375 = v332;\n\tv376 = 0x8907BC(v375, v243, v242, v245, v246, v247, v248, v249, v250, v251, v252, v253, v254, v255, v256, v257);\nL_0037:\n\t// 55 Box v380 @ X0_v25, typeof(Il2CppClass<T>), &v241 @ stack_-A8\n\tgoto L_0044;\n\tv404 = v388;\n\tv405 = 0x8907BC(v404, v378, v242, v245, v246, v247, v248, v249, v250, v251, v252, v253, v254, v255, v256, v257);\nL_0044:\n\tv406 = v98 < v147.Length;\n\tv350 = ~v406;\n\tif (v350) goto L_00C9;\n\tv408 = v98 * 0x44;\n\tv342 = v147 + v408;\n\tv154 = v342 + 0x20;\n\t// 83 Box v340 @ X0_v28, typeof(Il2CppClass<T>), v154 @ X22_v13\n\tv410 = *([v340 @ X0_v28]);\n\t*([v410 @ X8_v25+130])(v413, v340, v380, *([v410 @ X8_v25+138]), v245, v246, v247, v248, v249, v250, v251, v252, v253, v254, v255, v256, v257);\n\tv394 = \"il2cpp_vm_object_unbox\"(v340, v380, *([v410 @ X8_v25+138]), v245, v246, v247, v248, v249, v250, v251, v252, v253, v254, v255, v256, v257);\n\tv415 = v98 < v147.Length;\n\tv181 = ~v415;\n\tif (v181) goto L_00C9;\n\tv160 = 0x6D2410(v154, v394, 0x44, v245, v246, v247, v248, v249, v250, v251, v252, v253, v254, v255, v256, v257);\n\tv417 = v413 & 1;\n\tv162 = v417 == 0;\n\tif (v162) goto L_FFFFFFFF;\n\tv182 = this.count;\nL_0073:\n\tv184 = v182 - 1;\n\tv194 = v98 >= v184;\n\tif (v194) goto L_FFFFFFFF;\n\tv264 = this.data;\n\tv351 = v98 + 1;\n\tv352 = v351 < v264.Length;\n\tv353 = ~v352;\n\tif (v353) goto L_00C9;\n\tv381 = v351 * 0x44;\n\tv382 = v264 + v381;\n\tv383 = v382 + 0x20;\n\tv387 = 0x6D2410(&v385 @ stack_-F0, v383, 0x44, v245, v246, v247, v248, v249, v250, v251, v252, v253, v254, v255, v256, v257);\n\tv403 = v98 < v264.Length;\n\tv328 = ~v403;\n\tif (v328) goto L_00C9;\n\tv310 = v98 * 0x44;\n\tv312 = v264 + v310;\n\tv407 = v312 + 0x20;\n\tv308 = 0x6D2410(v407, &v385 @ stack_-F0, 0x44, v245, v246, v247, v248, v249, v250, v251, v252, v253, v254, v255, v256, v257);\n\tgoto L_00A7;\nL_00A7:\n\tv182 = this.count;\n\tv98 = v98 + 1;\n\tv69 = v98 < this.count;\n\tif (v69) goto L_0020;\n\tv59 = v99 == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tv125 = this.count - 1;\n\tthis.count = v125;\n\tgoto L_00C8;\nL_00C8:\n\treturn returnVal1;\nL_00C9:\n\tv397 = new System.IndexOutOfRangeException();\n\tthrow v397;\n\tv299 = new System.NullReferenceException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 140 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Remove(T item)
		{
			//IL_0067: Expected I, but got O
			//IL_01c2: Expected O, but got I
			//IL_01d1: Expected O, but got I
			//IL_00b5: Expected O, but got I
			//IL_00c4: Expected O, but got I
			//IL_00cd: Expected I, but got O
			//IL_0220: Expected O, but got I
			//IL_022f: Expected O, but got I
			int num = Count;
			if (Count >= 1)
			{
				int num2 = 0;
				int num3 = 0;
				object obj2 = default(object);
				object obj7 = default(object);
				do
				{
					if ((num3 & 1) == 0)
					{
						T[] array = Data;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
						object obj = (IntPtr)obj2;
						if (num2 < array.Length)
						{
							int num4 = num2 * 68;
							object obj3 = (long)(IntPtr)array + (long)num4;
							object obj4 = (long)(IntPtr)obj3 + 32L;
							object obj5 = (IntPtr)obj4;
							object obj6 = obj5;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v410 @ X8_v25+130] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							if (num2 < array.Length)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
								if ((uint)((ulong)(long)(IntPtr)obj7 & 1uL) != 0)
								{
									num = Count;
									goto IL_02bb;
								}
								num3 = 0;
								goto IL_02e8;
							}
						}
						goto IL_02ad;
					}
					goto IL_02bb;
					IL_02e8:
					num = Count;
					num2++;
					continue;
					IL_02bb:
					int num5 = num - 1;
					if (num2 >= num5)
					{
						goto IL_023e;
					}
					T[] array2 = Data;
					int num6 = num2 + 1;
					if (num6 < array2.Length)
					{
						int num7 = num6 * 68;
						object obj8 = (long)(IntPtr)array2 + (long)num7;
						object obj9 = (long)(IntPtr)obj8 + 32L;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
						if (num2 < array2.Length)
						{
							int num8 = num2 * 68;
							object obj10 = (long)(IntPtr)array2 + (long)num8;
							object obj11 = (long)(IntPtr)obj10 + 32L;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
							goto IL_023e;
						}
					}
					goto IL_02ad;
					IL_02ad:
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
					IL_023e:
					num3 = 1;
					goto IL_02e8;
				}
				while (num2 < Count);
				if (num3 != 0)
				{
					int num9 = Count - 1;
					count = num9;
					return true;
				}
			}
			return false;
		}

		[Token(Token = "0x60002BF")]
		[Address(RVA = "0x10A8244", Offset = "0x10A8244", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = 0x6D2410(&v17 @ stack_-78, item, 0x44, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv42 = 0x6D2410(&v36 @ stack_-C0, &v17 @ stack_-78, 0x44, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\treturnVal1 = System.Array::IndexOf(this.data, &v36 @ stack_-C0);\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int IndexOf(T item)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
			object value = default(object);
			return Array.IndexOf(Data, (T)value);
		}

		[Token(Token = "0x60002C0")]
		[Address(RVA = "0x10A82B0", Offset = "0x10A82B0", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv36 = *([1EF9948]);\n\tv37 = *([v36 @ X8_v24]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, index, item, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2026B1A]) = v53;\nL_001C:\n\tv54 = index & 0x80000000;\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_00AC;\n\tv68 = this.count < index;\n\tif (v68) goto L_00AC;\n\tv123 = this.count + 1;\n\tthis.count = v123;\n\tv129 = Obi.ObiList`1<T>::EnsureCapacity(this, v123);\n\tv179 = this.data;\n\tv213 = this.count - 1;\n\tv144 = v213 <= index;\n\tif (v144) goto L_007C;\nL_0049:\n\tv216 = v213 - 1;\n\tv217 = v216 < v211.Length;\n\tv218 = ~v217;\n\tif (v218) goto L_00A3;\n\tv303 = v216 * 0x44;\n\tv304 = v211 + v303;\n\tv305 = v304 + 0x20;\n\tv306 = &v21 @ stack_-10_v2 - 0x88;\n\tv308 = 0x6D2410(v306, v305, 0x44, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv324 = v213 < v211.Length;\n\tv318 = ~v324;\n\tif (v318) goto L_00A3;\n\tv178 = v213 * 0x44;\n\tv182 = v211 + v178;\n\tv326 = v182 + 0x20;\n\tv156 = &v21 @ stack_-10_v2 - 0x88;\n\tv176 = 0x6D2410(v326, v156, 0x44, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv179 = this.data;\n\tv213 = v213 + 1;\n\tv158 = v213 > index;\n\tif (v158) goto L_0049;\nL_007C:\n\tv189 = 0x6D2410(&v186 @ stack_-E0, item, 0x44, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv253 = 0x6D2410(&v249 @ stack_-128, &v186 @ stack_-E0, 0x44, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv322 = v179.Length < index;\n\tv284 = ~v322;\n\tv282 = v179.Length - index;\n\tv278 = v282 == 0;\n\tv323 = ~v284;\n\tv268 = v323 | v278;\n\tif (v268) goto L_00A3;\n\tv288 = index * 0x44;\n\tv298 = v179 + v288;\n\tv325 = v298 + 0x20;\n\tv286 = 0x6D2410(v325, &v249 @ stack_-128, 0x44, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\nL_00A3:\n\tv321 = new System.IndexOutOfRangeException();\n\tthrow v321;\n\tthrow System.NullReferenceException;\nL_00AC:\n\tv122 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v122);\n\tthrow v122;\n// 123 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Insert(int index, T item)
		{
			//IL_0295: Expected I4, but got I8
			//IL_0247: Expected O, but got I
			//IL_0256: Expected O, but got I
			//IL_00e0: Expected O, but got I
			//IL_00ef: Expected O, but got I
			//IL_00fe: Expected O, but got I
			//IL_014d: Expected O, but got I
			//IL_015c: Expected O, but got I
			//IL_016b: Expected O, but got I
			T[] array;
			if ((int)(index & 0x80000000L) == 0 && Count >= index)
			{
				EnsureCapacity(count = Count + 1);
				array = Data;
				int num = Count - 1;
				if (num <= index)
				{
					goto IL_01b3;
				}
				T[] array2 = array;
				object obj4 = default(object);
				while (true)
				{
					int num2 = num - 1;
					if (num2 >= array2.Length)
					{
						break;
					}
					int num3 = num2 * 68;
					object obj = (long)(IntPtr)array2 + (long)num3;
					object obj2 = (long)(IntPtr)obj + 32L;
					object obj3 = (long)(IntPtr)obj4 - 136L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
					if (num >= array2.Length)
					{
						break;
					}
					int num4 = num * 68;
					object obj5 = (long)(IntPtr)array2 + (long)num4;
					object obj6 = (long)(IntPtr)obj5 + 32L;
					object obj7 = (long)(IntPtr)obj4 - 136L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
					array = Data;
					num++;
					bool flag = num > index;
					array2 = Data;
					if (flag)
					{
						continue;
					}
					goto IL_01b3;
				}
				goto IL_0261;
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
			throw ex;
			IL_01b3:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
			bool flag2 = array.Length < index;
			bool flag3 = !flag2;
			int num5 = array.Length - index;
			bool flag4 = num5 == 0;
			bool flag5 = !flag3;
			if (!(flag5 || flag4))
			{
				int num6 = index * 68;
				object obj8 = (long)(IntPtr)array + (long)num6;
				object obj9 = (long)(IntPtr)obj8 + 32L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				return;
			}
			goto IL_0261;
			IL_0261:
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
		}

		[Token(Token = "0x60002C1")]
		[Address(RVA = "0x10A844C", Offset = "0x10A844C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv77 = this.count;\n\tv56 = this.count - 1;\n\tv35 = this.count <= index;\n\tif (v35) goto L_005D;\nL_0025:\n\tv114 = v103 >= v94;\n\tif (v114) goto L_004F;\n\tv129 = this.data;\n\tv157 = v103 + 1;\n\tv158 = v157 < v129.Length;\n\tv159 = ~v158;\n\tif (v159) goto L_0068;\n\tv219 = v157 * 0x44;\n\tv220 = v129 + v219;\n\tv221 = v220 + 0x20;\n\tv225 = 0x6D2410(&v223 @ stack_-88, v221, 0x44, v182, v183, v184, v185, v186, v187, v188, v189, v190, v191, v192, v193, v194);\n\tv230 = v103 < v129.Length;\n\tv214 = ~v230;\n\tif (v214) goto L_0068;\n\tv198 = v103 * 0x44;\n\tv231 = v129 + v198;\n\tv232 = v231 + 0x20;\n\tv196 = 0x6D2410(v232, &v223 @ stack_-88, 0x44, v182, v183, v184, v185, v186, v187, v188, v189, v190, v191, v192, v193, v194);\n\tv77 = this.count;\n\tgoto L_0059;\nL_004F:\n\tv103 = v103 + 1;\nL_0059:\n\tv56 = v77 - 1;\n\tv55 = v103 < v77;\n\tif (v55) goto L_0025;\nL_005D:\n\tthis.count = v56;\n\treturn;\nL_0068:\n\tv229 = new System.IndexOutOfRangeException();\n\tthrow v229;\n\tthrow System.NullReferenceException;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveAt(int index)
		{
			//IL_00b2: Expected O, but got I
			//IL_00c1: Expected O, but got I
			//IL_0110: Expected O, but got I
			//IL_011f: Expected O, but got I
			int num = Count;
			int num2 = Count - 1;
			if (Count > index)
			{
				int num3 = num2;
				int num4 = index;
				bool flag;
				do
				{
					if (num4 < num3)
					{
						T[] array = Data;
						int num5 = num4 + 1;
						if (num5 < array.Length)
						{
							int num6 = num5 * 68;
							object obj = (long)(IntPtr)array + (long)num6;
							object obj2 = (long)(IntPtr)obj + 32L;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
							if (num4 < array.Length)
							{
								int num7 = num4 * 68;
								object obj3 = (long)(IntPtr)array + (long)num7;
								object obj4 = (long)(IntPtr)obj3 + 32L;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
								num = Count;
								num4 = num5;
								goto IL_016c;
							}
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					num4++;
					goto IL_016c;
					IL_016c:
					num2 = num - 1;
					flag = num4 < num;
					num3 = num2;
				}
				while (flag);
			}
			count = num2;
		}

		[Token(Token = "0x60002C5")]
		[Address(RVA = "0x10A9720", Offset = "0x10A9720", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = Obi.ObiList`1<T>::EnsureCapacity(this, count);\n\tthis.count = count;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetCount(int count)
		{
			EnsureCapacity(count);
			this.count = count;
		}

		[Token(Token = "0x60002C6")]
		[Address(RVA = "0x10A8654", Offset = "0x10A8654", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = this.data;\n\tv17 = v2.Length <= capacity;\n\tif (v17) goto L_0014;\n\treturn;\nL_0014:\n\tv40 = capacity << 1;\n\tv42 = Il2CppMethodInfo;\n\tv43 = *([v42 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 24 IndirectJump v43 @ X3_v1, v0 @ X0_v1, v0 @ X0_v1, v40 @ X1_v1 (System.Int32), methodof(System.Array::Resize), v43 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void EnsureCapacity(int capacity)
		{
			//IL_000c: Expected O, but got I
			//IL_0059: Expected O, but got I
			object obj = (long)(IntPtr)this + 16L;
			T[] array = Data;
			if (array.Length <= capacity)
			{
				int num = capacity << 1;
				IntPtr intPtr = (IntPtr)0;
				object obj2 = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v43 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60002C7")]
		[Address(RVA = "0x10A97A8", Offset = "0x10A97A8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv20 = v15;\n\tv21 = 0x8907BC(v20, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0013:\n\t// 19 NewArr v39 @ X0_v3 (T[]), typeof(Il2CppClass<T[]>), 16\n\tthis.data = v39;\n\tSystem.Object::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiList()
		{
		}
	}
}
