using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x7444C4", Offset = "0x7444C4")]
	[Token(Token = "0x2000034")]
	public abstract class ObiNativeList<T> : IDisposable where T : struct
	{
		[Token(Token = "0x40000BD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private IntPtr m_RawPtr;

		[Token(Token = "0x40000BE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		protected internal IntPtr m_AlignedPtr;

		[Token(Token = "0x40000BF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		protected int m_TypeSize;

		[Token(Token = "0x40000C0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		protected int m_Alignment;

		[Token(Token = "0x40000C1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		protected int m_Capacity;

		[Token(Token = "0x40000C2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		protected int m_Count;

		[Token(Token = "0x17000046")]
		public int count
		{
			[Token(Token = "0x6000286")]
			[Address(RVA = "0x10A9850", Offset = "0x10A9850", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Count;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return count;
			}
			[Token(Token = "0x6000285")]
			[Address(RVA = "0x10A9804", Offset = "0x10A9804", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = this.m_Count == value;\n\tif (v19) goto L_0020;\n\tv31 = Obi.ObiNativeList`1<T>::EnsureCapacity(this, this.m_Count);\n\tthis.m_Count = value;\nL_0020:\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (count != value)
				{
					EnsureCapacity(count);
					m_Count = value;
				}
			}
		}

		[Token(Token = "0x17000047")]
		public int capacity
		{
			[Token(Token = "0x6000288")]
			[Address(RVA = "0x10A9880", Offset = "0x10A9880", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Capacity;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return capacity;
			}
			[Token(Token = "0x6000287")]
			[Address(RVA = "0x10A9858", Offset = "0x10A9858", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.m_Capacity != value;\n\tif (v12) goto L_0010;\n\treturn;\nL_0010:\n\tv17 = Il2CppMethodInfo;\n\tv18 = *([v17 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 18 IndirectJump v18 @ X4_v1, this @ X0 (Obi.ObiNativeList`1<T>), this @ X0 (Obi.ObiNativeList`1<T>), value @ X1 (System.Int32), 16, methodof(Obi.ObiNativeList`1<T>::ChangeCapacity), v18 @ X4_v1, v19 @ X5, v20 @ X6, v21 @ X7, v22 @ V0, v23 @ V1, v24 @ V2, v25 @ V3, v26 @ V4, v27 @ V5, v28 @ V6, v29 @ V7\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0030: Expected O, but got I
				if (capacity != value)
				{
					IntPtr intPtr = (IntPtr)0;
					object obj = (long)intPtr;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v18 @ X4_v1 (should have been resolved before IL gen)");
				}
			}
		}

		[Token(Token = "0x17000048")]
		public abstract T Item
		{
			[Token(Token = "0x6000289")]
			get;
			[Token(Token = "0x600028A")]
			set;
		}

		[Token(Token = "0x600028B")]
		[Address(RVA = "0x10A9888", Offset = "0x10A9888", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1ED3BB0]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, capacity, alignment, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026B1F]) = v44;\nL_0017:\n\tthis.m_RawPtr = 0;\n\tthis.m_AlignedPtr = 0;\n\tSystem.Object::.ctor(this);\n\tthis.m_Alignment = 0x10;\n\tv60 = Il2CppMethodInfo;\n\tv61 = *([v60 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 46 IndirectJump v61 @ X4_v1, this @ X0 (Obi.ObiNativeList`1<T>), this @ X0 (Obi.ObiNativeList`1<T>), capacity @ X1 (System.Int32), 16, methodof(Obi.ObiNativeList`1<T>::ChangeCapacity), v61 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiNativeList(int capacity = 8, int alignment = 16)
		{
			//IL_0024: Expected O, but got I
			while (true)
			{
				m_RawPtr = (IntPtr)0;
				m_AlignedPtr = (IntPtr)0;
				base._002Ector();
				m_Alignment = 16;
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v61 @ X4_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600028C")]
		[Address(RVA = "0x10A9918", Offset = "0x10A9918", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this == 0;\n\tif (v12) goto L_0019;\n\tv20 = Obi.ObiNativeList`1<T>::Dispose(this, 0);\n\tSystem.Object::Finalize(this);\n\treturn;\nL_0019:\n\tv40 = new System.NullReferenceException();\n\tv51 = methodInfo != 1;\n\tif (v51) goto L_0036;\n\tv92 = 0x6D2BC0(v40, methodInfo, v41, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv95 = 0x6D2490(v92, methodInfo, v41, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tSystem.Object::Finalize(this);\n\tv105 = *([v92 @ X0_v9]) == 0;\n\tv86 = ~v105;\n\tif (v86) goto L_003C;\n\treturn;\nL_0036:\n\tv93 = 0x6D2380(v40, methodInfo, v41, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tthrow System.NullReferenceException;\nL_003C:\n\tthrow System.TypeLoadException;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		~ObiNativeList()
		{
			if (this != null)
			{
				Dispose(disposing: false);
				base.Finalize();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr = default(IntPtr);
			if (intPtr == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				base.Finalize();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
				throw new TypeLoadException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			throw new NullReferenceException();
		}

		[Token(Token = "0x600028D")]
		[Address(RVA = "0x10A99B0", Offset = "0x10A99B0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB9138]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, disposing, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026B20]) = v38;\nL_0016:\n\tv42 = System.IntPtr::op_Inequality(this.m_RawPtr, 0);\n\tv44 = v42 == 0;\n\tif (v44) goto L_0030;\n\tgoto L_0029;\n\tv65 = *([v48 @ X0_v5+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0029;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v48, v40, v41, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0029:\n\tSystem.Runtime.InteropServices.Marshal::FreeHGlobal(this.m_RawPtr);\n\tthis.m_RawPtr = 0;\nL_0030:\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void Dispose(bool disposing)
		{
			if (m_RawPtr != (IntPtr)0)
			{
				Marshal.FreeHGlobal(m_RawPtr);
				m_RawPtr = (IntPtr)0;
			}
		}

		[Token(Token = "0x600028E")]
		[Address(RVA = "0x10A9A38", Offset = "0x10A9A38", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = Il2CppMethodInfo;\n\tv7 = *([v6 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 7 IndirectJump v7 @ X3_v1, this @ X0 (Obi.ObiNativeList`1<T>), this @ X0 (Obi.ObiNativeList`1<T>), 1, methodof(Obi.ObiNativeList`1<T>::Dispose), v7 @ X3_v1, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v7 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600028F")]
		[Address(RVA = "0x10A9A60", Offset = "0x10A9A60", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Count = 0;\n\treturn;\n")]
		public void Clear()
		{
			m_Count = 0;
		}

		[Token(Token = "0x6000290")]
		[Address(RVA = "0x10A9A68", Offset = "0x10A9A68", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = *([1ECFEC0]);\n\tv35 = *([v34 @ X8_v25]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, newCapacity, byteAlignment, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2026B21]) = v51;\nL_0022:\n\tgoto L_002D;\n\tv59 = *([v55 @ X0_v2+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_002D;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, newCapacity, byteAlignment, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_002D:\n\tv71 = System.Runtime.InteropServices.Marshal::SizeOf(0);\n\tthis.m_TypeSize = v71;\n\tv72 = v71 * newCapacity;\n\tv73 = byteAlignment + v72;\n\tv75 = System.Runtime.InteropServices.Marshal::AllocHGlobal(v73);\n\tv78 = System.IntPtr::op_Explicit(v75);\n\tv79 = v78 + byteAlignment;\n\tv80 = 0 - byteAlignment;\n\tv81 = v79 - 1;\n\tv83 = v81 & v80;\n\tv87 = 0xDC4BF8(&v85 @ stack_-48_v2 (System.Void*), v83, 0, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv91 = System.IntPtr::op_Inequality(this.m_AlignedPtr, 0);\n\tv93 = v91 == 0;\n\tif (v93) goto L_006F;\n\tgoto L_0057;\n\tv134 = *([v99 @ X0_v16+E0]);\n\tv135 = v134 == 0;\n\tv136 = ~v135;\n\tif (v136) goto L_0057;\n\tv138 = \"il2cpp_codegen_runtime_class_init\"(v99, v89, v90, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0057:\n\tv144 = UnityEngine.Mathf::Min(newCapacity, this.m_Capacity);\n\tv147 = this.m_TypeSize * v144;\n\tUnity.Collections.LowLevel.Unsafe.UnsafeUtility::MemCpy(v85, this.m_AlignedPtr, v147);\n\tgoto L_006C;\n\tv153 = *([v149 @ X0_v21+E0]);\n\tv154 = v153 == 0;\n\tv155 = ~v154;\n\tif (v155) goto L_006C;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v149, v146, v107, v104, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_006C:\n\tSystem.Runtime.InteropServices.Marshal::FreeHGlobal(this.m_RawPtr);\nL_006F:\n\tthis.m_Capacity = newCapacity;\n\tthis.m_RawPtr = v75;\n\tthis.m_AlignedPtr = v85;\n\tv124 = Obi.ObiNativeList`1::CapacityChanged(this);\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe void ChangeCapacity(int newCapacity, int byteAlignment = 16)
		{
			//IL_00ef: Expected I8, but got I4
			int num = (m_TypeSize = Marshal.SizeOf((T)null)) * newCapacity;
			int cb = byteAlignment + num;
			IntPtr intPtr = Marshal.AllocHGlobal(cb);
			long num2 = (long)intPtr;
			long num3 = num2 + byteAlignment;
			int num4 = -byteAlignment;
			long num5 = num3 - 1;
			long num6 = num5 & num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC4BF8 (inside System.Int64::TryParse +0x72C)");
			void* ptr = default(void*);
			if (m_AlignedPtr != (IntPtr)0)
			{
				int num7 = Mathf.Min(newCapacity, capacity);
				long size = m_TypeSize * num7;
				UnsafeUtility.MemCpy(ptr, (void*)m_AlignedPtr, size);
				Marshal.FreeHGlobal(m_RawPtr);
			}
			m_Capacity = newCapacity;
			m_RawPtr = intPtr;
			m_AlignedPtr = (IntPtr)ptr;
			CapacityChanged();
		}

		[Token(Token = "0x6000291")]
		[Address(RVA = "0x10A9BF4", Offset = "0x10A9BF4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void CapacityChanged()
		{
		}

		[Token(Token = "0x6000292")]
		[Address(RVA = "0x10A9BF8", Offset = "0x10A9BF8", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1ECBDC0]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, other, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026B22]) = v44;\nL_0017:\n\tv45 = other == 0;\n\tif (v45) goto L_0041;\n\tv58 = this.m_Count < other.m_Count;\n\tif (v58) goto L_0049;\n\tv70 = Obi.ObiNativeList`1<T>::get_count(other);\n\tv77 = this.m_TypeSize * v70;\n\tUnity.Collections.LowLevel.Unsafe.UnsafeUtility::MemCpy(this.m_AlignedPtr, other.m_AlignedPtr, v77);\n\treturn;\nL_0041:\n\tv62 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v62);\n\tgoto L_0052;\nL_0049:\n\tv86 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v86);\nL_0052:\n\tthrow v120;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void CopyFrom(ObiNativeList<T> other)
		{
			//IL_0044: Expected I8, but got I4
			if (other != null)
			{
				if (count >= other.count)
				{
					int num = other.count;
					long size = m_TypeSize * num;
					UnsafeUtility.MemCpy((void*)m_AlignedPtr, (void*)other.m_AlignedPtr, size);
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

		[Token(Token = "0x6000293")]
		[Address(RVA = "0x10A9CE8", Offset = "0x10A9CE8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = this->klass;\n\t*([v17 @ X9_v1 (Il2CppClass<Obi.ObiNativeList`1<T>>)+190])(v23, this, this.m_Count, item, *([v17 @ X9_v1 (Il2CppClass<Obi.ObiNativeList`1<T>>)+198]), v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = this.m_Count + 1;\n\tthis.m_Count = v38;\n\tv43 = Il2CppMethodInfo;\n\tv44 = *([v43 @ X2_v2 (Il2CppMethodInfo)]);\n\t// 31 IndirectJump v44 @ X3_v2, this @ X0 (Obi.ObiNativeList`1<T>), this @ X0 (Obi.ObiNativeList`1<T>), v38 @ X1_v2 (System.Int32), methodof(Obi.ObiNativeList`1<T>::EnsureCapacity), v44 @ X3_v2, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Add(T item)
		{
			//IL_0005: Expected I, but got O
			//IL_0037: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v17 @ X9_v1 (Il2CppClass<Obi.ObiNativeList`1<T>>)+190] (should have been resolved before IL gen)");
			int num = count + 1;
			m_Count = num;
			IntPtr intPtr2 = (IntPtr)0;
			object obj = (long)intPtr2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v44 @ X3_v2 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000294")]
		[Address(RVA = "0x10A9D4C", Offset = "0x10A9D4C", Length = "0x41C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = *([1EC8AF0]);\n\tv29 = *([v28 @ X8_v57]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, enumerable, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2026B23]) = v46;\nL_001F:\n\tgoto L_0024;\n\tv54 = v49;\n\tv55 = 0x8907BC(v54, enumerable, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0024:\n\t// 36 IsInst v59 @ X0_v4 (System.Collections.IEnumerator), typeof(System.Collections.Generic.ICollection`1<T>), enumerable @ X1 (System.Collections.Generic.IEnumerable`1<T>)\n\tv61 = v59 == 0;\n\tif (v61) goto L_0161;\n\tgoto L_0032;\n\tv171 = v64;\n\tv172 = 0x8907BC(v171, v58, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\tv174 = *([v59 @ X0_v4 (System.Collections.IEnumerator)]);\n\tv176 = *([v174 @ X8_v17 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v176) goto L_FFFFFFFF;\n\tv229 = *([v174 @ X8_v17 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_003E:\n\tv234 = *([v229 @ X11_v42-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v234) goto L_0057;\n\tv228 = v228 + 1;\n\tv289 = v228 < *([v174 @ X8_v17 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv199 = ~v289;\n\tv229 = v229 + 0x10;\n\tv183 = ~v199;\n\tif (v183) goto L_003E;\n\tgoto L_005B;\nL_0057:\n\tv291 = *([v229 @ X11_v42]) << 4;\n\tv292 = v174 + v291;\n\tv310 = v292 + 0x130;\nL_005B:\n\tv149 = *([v310 @ X0_v23+8]);\n\tv315 = System.Collections.Generic.ICollection`1<T>::get_Count(v59);\n\tv326 = v315 < 1;\n\tif (v326) goto L_00AA;\n\tgoto L_0075;\n\tv379 = v168;\n\tv380 = 0x8907BC(v379, v313, v296, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0075:\n\tv382 = *([v59 @ X0_v4 (System.Collections.IEnumerator)]);\n\tv384 = *([v382 @ X8_v47 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v384) goto L_FFFFFFFF;\n\tv548 = *([v382 @ X8_v47 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0081:\n\tv553 = *([v548 @ X11_v37-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v553) goto L_009A;\n\tv547 = v547 + 1;\n\tv611 = v547 < *([v382 @ X8_v47 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv491 = ~v611;\n\tv548 = v548 + 0x10;\n\tv475 = ~v491;\n\tif (v475) goto L_0081;\n\tgoto L_00A0;\nL_009A:\n\t;\nL_00A0:\n\tv154 = System.Collections.Generic.ICollection`1<T>::get_Count(v59);\n\tv158 = this == 0;\n\tif (v158) goto L_0161;\n\tv149 = v154 + this.m_Count;\n\tv337 = Obi.ObiNativeList`1<T>::EnsureCapacity(this, v149);\nL_00AA:\n\tv157 = v59 == 0;\n\tif (v157) goto L_0161;\n\tgoto L_00B6;\n\tv500 = v387;\n\tv501 = 0x8907BC(v500, v149, v85, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00B6:\n\tv503 = *([v59 @ X0_v4 (System.Collections.IEnumerator)]);\n\tv505 = *([v503 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v505) goto L_00D9;\n\tv631 = *([v503 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_00C2:\n\tv636 = *([v631 @ X11_v31-8]) == Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>;\n\tif (v636) goto L_00DB;\n\tv630 = v630 + 1;\n\tv652 = v630 < *([v503 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv580 = ~v652;\n\tv631 = v631 + 0x10;\n\tv564 = ~v580;\n\tif (v564) goto L_00C2;\nL_00D9:\n\tgoto L_00E1;\nL_00DB:\n\t;\nL_00E1:\n\tv678 = System.Collections.Generic.IEnumerable`1<T>::GetEnumerator(v59);\nL_00EB:\n\tgoto L_0112;\n\tv726 = *([v720 @ X8_v29+B0]);\n\tv727 = 0;\n\tv728 = v726 + 8;\n\tv730 = *([v772 @ X11_v26-8]);\n\tv777 = v730 == v721;\n\tif (v777) goto L_010B;\n\tv750 = v771 + 1;\n\tv782 = v750 < v722;\n\tv748 = ~v782;\n\tv752 = v772 + 0x10;\n\tv732 = ~v748;\n\tif (v732) goto L_FFFFFFFF;\n\tv753 = v160;\n\tv754 = 0;\n\tv755 = 0x8909C4(v753, v721, v754, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0112;\nL_010B:\n\tv783 = *([v772 @ X11_v26]);\n\tv784 = v783 << 4;\n\tv785 = v720 + v784;\n\tv786 = v785 + 0x130;\nL_0112:\n\tv426 = System.Collections.IEnumerator::MoveNext(v678);\n\tv791 = v426 == 0;\n\tif (v791) goto L_0158;\n\tgoto L_0120;\n\tv799 = v718;\n\tv800 = 0x8907BC(v799, v424, v398, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0120:\n\tv802 = *([v678 @ X0_v30 (System.Collections.IEnumerator)]);\n\tv804 = *([v802 @ X8_v35 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v804) goto L_FFFFFFFF;\n\tv847 = *([v802 @ X8_v35 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_012C:\n\tv852 = *([v847 @ X11_v21-8]) == Il2CppClass<System.Collections.Generic.IEnumerator`1<T>>;\n\tif (v852) goto L_0145;\n\tv846 = v846 + 1;\n\tv857 = v846 < *([v802 @ X8_v35 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv827 = ~v857;\n\tv847 = v847 + 0x10;\n\tv811 = ~v827;\n\tif (v811) goto L_012C;\n\tgoto L_014B;\nL_0145:\n\t;\nL_014B:\n\tv758 = System.Collections.Generic.IEnumerator`1<T>::get_Current(v678);\n\tv713 = Obi.ObiNativeList`1<T>::Add(this, v758);\n\tgoto L_00EB;\nL_0158:\n\tv798 = v678 == 0;\n\tv428 = ~v798;\n\tif (v428) goto L_017D;\n\tgoto L_01A5;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0161:\n\tv170 = new System.NullReferenceException();\n\tgoto L_016F;\n\tgoto L_016F;\n\tgoto L_016F;\n\tgoto L_016F;\nL_016F:\n\tv217 = v272 != 1;\n\tif (v217) goto L_01BC;\n\tv239 = 0x6D2BC0(v170, v272, v246, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv432 = *([v239 @ X0_v20]);\n\tv328 = 0x6D2490(v239, v272, v246, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv341 = v159 == 0;\n\tif (v341) goto L_01A5;\nL_017D:\n\tgoto L_01A4;\n\tv506 = *([v439 @ X8_v9+B0]);\n\tv507 = 0;\n\tv508 = v506 + 8;\n\tv510 = *([v600 @ X11_v8-8]);\n\tv605 = v510 == v442;\n\tif (v605) goto L_019D;\n\tv530 = v599 + 1;\n\tv641 = v530 < v441;\n\tv528 = ~v641;\n\tv532 = v600 + 0x10;\n\tv512 = ~v528;\n\tif (v512) goto L_FFFFFFFF;\n\tv533 = v431;\n\tv534 = 0;\n\tv535 = 0x8909C4(v533, v442, v534, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_01A4;\nL_019D:\n\tv642 = *([v600 @ X11_v8]);\n\tv643 = v642 << 4;\n\tv644 = v439 + v643;\n\tv645 = v644 + 0x130;\nL_01A4:\n\tSystem.IDisposable::Dispose(v431);\nL_01A5:\n\tv468 = v279 + 1;\n\tv259 = v468 == 0;\n\tv249 = ~v259;\n\tif (v249) goto L_01B7;\n\tv536 = v283 == 0;\n\tv277 = ~v536;\n\tif (v277) goto L_01BB;\nL_01B7:\n\treturn;\nL_01BB:\n\tv275 = new System.TypeLoadException();\nL_01BC:\n\tv288 = 0x6D2380(v170, v272, v246, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn;\n// 274 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddRange(IEnumerable<T> enumerable)
		{
			//IL_0044: Expected I, but got O
			//IL_0428: Expected I4, but got O
			//IL_00e9: Expected I, but got O
			//IL_0468: Expected I4, but got O
			//IL_0513: Expected O, but got I4
			//IL_007f: Expected O, but got I
			//IL_00fc: Expected I4, but got O
			//IL_010a: Expected O, but got I
			//IL_0119: Expected O, but got I
			//IL_0133: Expected I, but got O
			//IL_00cb: Expected O, but got I
			//IL_04b2: Expected I, but got O
			//IL_04b7: Expected I, but got O
			//IL_0213: Expected I, but got O
			//IL_055f: Expected O, but got I4
			//IL_016e: Expected O, but got I
			//IL_024e: Expected O, but got I
			//IL_01ba: Expected O, but got I
			//IL_029a: Expected O, but got I
			//IL_02d2: Expected I, but got O
			//IL_030d: Expected O, but got I
			//IL_0359: Expected O, but got I
			IEnumerator enumerator = (IEnumerator)(enumerable as ICollection<T>);
			bool flag = enumerator == null;
			IEnumerator enumerator3 = default(IEnumerator);
			IEnumerator enumerator2 = enumerator3;
			if (flag)
			{
				goto IL_03e8;
			}
			IntPtr intPtr = (IntPtr)enumerator;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X8_v17 (Il2CppClass<System.Collections.IEnumerator>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00e4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X8_v17 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ X11_v42-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X8_v17 (Il2CppClass<System.Collections.IEnumerator>)+126]");
				bool flag2 = (long)num2 < 0L;
				bool flag3 = !flag2;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag3)
				{
					continue;
				}
				goto IL_00e4;
			}
			int num3 = obj << 4;
			object obj2 = (long)intPtr + (long)num3;
			object obj3 = (long)(IntPtr)obj2 + 304L;
			IntPtr intPtr3 = default(IntPtr);
			IntPtr intPtr2 = intPtr3;
			goto IL_04f6;
			IL_04f6:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ X0_v23+8]");
			int num4 = 0;
			object obj4 = ((ICollection<T>)enumerator).Count;
			IntPtr intPtr5 = default(IntPtr);
			if ((long)(IntPtr)obj4 >= 1L)
			{
				IntPtr intPtr4 = (IntPtr)enumerator;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ X8_v47 (Il2CppClass<System.Collections.IEnumerator>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ X8_v47 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj5 = 0L + 8L;
					int num5 = 0;
					bool flag5;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ X11_v37-8]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							num5++;
							int num6 = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ X8_v47 (Il2CppClass<System.Collections.IEnumerator>)+126]");
							bool flag4 = (long)num6 < 0L;
							flag5 = !flag4;
							obj5 = (long)(IntPtr)obj5 + 16L;
							continue;
						}
						break;
					}
					while (!flag5);
				}
				object obj6 = ((ICollection<T>)enumerator).Count;
				bool flag6 = this == null;
				intPtr5 = (IntPtr)num4;
				enumerator2 = enumerator;
				if (flag6)
				{
					goto IL_03e8;
				}
				num4 = (int)((long)(IntPtr)obj6 + (long)count);
				EnsureCapacity(num4);
				intPtr2 = (IntPtr)0;
			}
			bool flag7 = enumerator == null;
			intPtr2 = intPtr3;
			intPtr5 = (IntPtr)0;
			enumerator2 = enumerator;
			if (flag7)
			{
				goto IL_03e8;
			}
			IntPtr intPtr6 = (IntPtr)enumerator;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
				object obj7 = 0L + 8L;
				int num7 = 0;
				bool flag9;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v631 @ X11_v31-8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						num7++;
						int num8 = num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ X8_v24 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						bool flag8 = (long)num8 < 0L;
						flag9 = !flag8;
						obj7 = (long)(IntPtr)obj7 + 16L;
						continue;
					}
					break;
				}
				while (!flag9);
			}
			enumerator3 = ((IEnumerable<T>)enumerator).GetEnumerator();
			while (enumerator3.MoveNext())
			{
				IntPtr intPtr7 = (IntPtr)enumerator3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v802 @ X8_v35 (Il2CppClass<System.Collections.IEnumerator>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v802 @ X8_v35 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj8 = 0L + 8L;
					int num9 = 0;
					bool flag11;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v847 @ X11_v21-8]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							num9++;
							int num10 = num9;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v802 @ X8_v35 (Il2CppClass<System.Collections.IEnumerator>)+126]");
							bool flag10 = (long)num10 < 0L;
							flag11 = !flag10;
							obj8 = (long)(IntPtr)obj8 + 16L;
							continue;
						}
						break;
					}
					while (!flag11);
				}
				T current = ((IEnumerator<T>)enumerator3).Current;
				Add(current);
			}
			bool flag12 = enumerator3 == null;
			bool flag13 = !flag12;
			int num11 = 0;
			IDisposable disposable = (IDisposable)enumerator3;
			int num12 = 0;
			int num13;
			int num14;
			if (!flag13)
			{
				num13 = 0;
				num14 = 0;
				goto IL_061b;
			}
			goto IL_0651;
			IL_0651:
			disposable.Dispose();
			num13 = num11;
			num14 = num12;
			goto IL_061b;
			IL_061b:
			if (num13 + 1 != 0 || num14 == 0)
			{
				return;
			}
			TypeLoadException ex = new TypeLoadException();
			intPtr2 = (IntPtr)null;
			intPtr5 = (IntPtr)null;
			NullReferenceException ex2 = (NullReferenceException)(object)ex;
			goto IL_04c4;
			IL_03e8:
			ex2 = new NullReferenceException();
			if (intPtr5 != (IntPtr)1)
			{
				goto IL_04c4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj9 = default(object);
			num12 = (int)obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
			bool flag14 = enumerator2 == null;
			num11 = -1;
			disposable = (IDisposable)enumerator2;
			num13 = -1;
			num14 = (int)obj9;
			if (flag14)
			{
				goto IL_061b;
			}
			goto IL_0651;
			IL_04c4:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_00e4:
			intPtr2 = (IntPtr)null;
			goto IL_04f6;
		}

		[Token(Token = "0x6000295")]
		[Address(RVA = "0x10AA168", Offset = "0x10AA168", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = Obi.ObiNativeList`1<T>::EnsureCapacity(this, newCount);\n\tthis.m_Count = newCount;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ResizeUninitialized(int newCount)
		{
			EnsureCapacity(newCount);
			m_Count = newCount;
		}

		[Token(Token = "0x6000296")]
		[Address(RVA = "0x10AA1B0", Offset = "0x10AA1B0", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv30 = *([1ED5A68]);\n\tv31 = *([v30 @ X8_v17]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, newCount, value, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026B24]) = v47;\nL_0025:\n\tv60 = this.m_Capacity <= newCount;\n\tif (v60) goto L_003E;\n\tv64 = System.IntPtr::op_Equality(this.m_AlignedPtr, 0);\n\tv79 = Obi.ObiNativeList`1<T>::ResizeUninitialized(this, newCount);\n\tv81 = v64 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_003F;\n\tgoto L_005F;\nL_003E:\n\tv71 = Obi.ObiNativeList`1<T>::ResizeUninitialized(this, newCount);\nL_003F:\n\tv122 = this.m_Capacity;\n\tv120 = this.m_Count;\n\tgoto L_0055;\nL_0042:\n\tv151 = this->klass;\n\t*([v151 @ X8_v7 (Il2CppClass<Obi.ObiNativeList`1<T>>)+190])(v119, this, v120, value, *([v151 @ X8_v7 (Il2CppClass<Obi.ObiNativeList`1<T>>)+198]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv122 = this.m_Capacity;\n\tv120 = v120 + 1;\nL_0055:\n\tv92 = v120 < v122;\n\tif (v92) goto L_0042;\nL_005F:\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ResizeInitialized(int newCount, T value = default(T))
		{
			//IL_0064: Expected I, but got O
			if (capacity > newCount)
			{
				bool flag = m_AlignedPtr == (IntPtr)0;
				ResizeUninitialized(newCount);
				if (!flag)
				{
					return;
				}
			}
			else
			{
				ResizeUninitialized(newCount);
			}
			int num = capacity;
			for (int i = count; i < num; i++)
			{
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v151 @ X8_v7 (Il2CppClass<Obi.ObiNativeList`1<T>>)+190] (should have been resolved before IL gen)");
				num = capacity;
			}
		}

		[Token(Token = "0x6000297")]
		[Address(RVA = "0x10AA29C", Offset = "0x10AA29C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv26 = *([1EDA950]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, min, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026B25]) = v44;\nL_0023:\n\tv57 = this.m_Capacity <= min;\n\tif (v57) goto L_002D;\n\tv61 = System.IntPtr::op_Equality(this.m_AlignedPtr, 0);\n\tv66 = v61 == 0;\n\tif (v66) goto L_0042;\nL_002D:\n\tv68 = min << 1;\n\tv76 = Il2CppMethodInfo;\n\tv77 = *([v76 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 58 IndirectJump v77 @ X4_v1, this @ X0 (Obi.ObiNativeList`1<T>), this @ X0 (Obi.ObiNativeList`1<T>), v68 @ X1_v2 (System.Int32), 16, methodof(Obi.ObiNativeList`1<T>::ChangeCapacity), v77 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\nL_0042:\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void EnsureCapacity(int min)
		{
			//IL_0052: Expected O, but got I
			if (capacity <= min || m_AlignedPtr == (IntPtr)0)
			{
				int num = min << 1;
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v77 @ X4_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000298")]
		[Address(RVA = "0x10AA338", Offset = "0x10AA338", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EF7D80]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2026B26]) = v40;\nL_0018:\n\tv45 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v45);\n\tv45 = System.Text.StringBuilder::Append(v45, 0x5B);\n\tv66 = this.m_Count < 1;\n\tif (v66) goto L_0060;\nL_0030:\n\tv159 = this->klass;\n\t*([v159 @ X8_v9 (Il2CppClass<Obi.ObiNativeList`1<T>>)+180])(v45, this, v145, *([v159 @ X8_v9 (Il2CppClass<Obi.ObiNativeList`1<T>>)+188]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv167 = 0xDC3560(&v45 @ X0_v3 (System.Text.StringBuilder), 0, *([v159 @ X8_v9 (Il2CppClass<Obi.ObiNativeList`1<T>>)+188]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv45 = System.Text.StringBuilder::Append(v45, v167);\n\tv100 = this.m_Count;\n\tv71 = this.m_Count - 1;\n\tv183 = v145 >= v71;\n\tif (v183) goto L_0050;\n\tv45 = System.Text.StringBuilder::Append(v45, 0x2C);\n\tv100 = this.m_Count;\nL_0050:\n\tv145 = v145 + 1;\n\tv76 = v145 < v100;\n\tif (v76) goto L_0030;\nL_0060:\n\tv45 = System.Text.StringBuilder::Append(v45, 0x5D);\n\treturnVal2 = System.Text.StringBuilder::ToString(v45);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_00c7: Expected I, but got O
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder = stringBuilder.Append('[');
			if (count >= 1)
			{
				int num = 0;
				string value = default(string);
				int num2;
				do
				{
					IntPtr intPtr = (IntPtr)this;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v159 @ X8_v9 (Il2CppClass<Obi.ObiNativeList`1<T>>)+180] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
					stringBuilder = stringBuilder.Append(value);
					num2 = count;
					int num3 = count - 1;
					if (num < num3)
					{
						stringBuilder = stringBuilder.Append(',');
						num2 = count;
					}
					num++;
				}
				while (num < num2);
			}
			stringBuilder = stringBuilder.Append(']');
			return stringBuilder.ToString();
		}

		[Token(Token = "0x6000299")]
		[Address(RVA = "0x10AA450", Offset = "0x10AA450", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_AlignedPtr;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IntPtr GetIntPtr()
		{
			return m_AlignedPtr;
		}

		[Token(Token = "0x600029A")]
		[Address(RVA = "0x10AA458", Offset = "0x10AA458", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = index1 & 0x80000000;\n\tv23 = v22 == 0;\n\tv24 = ~v23;\n\tif (v24) goto L_0065;\n\tv66 = Obi.ObiNativeList`1<T>::get_count(this);\n\tv95 = index2 & 0x80000000;\n\tv96 = v95 == 0;\n\tv73 = ~v96;\n\tif (v73) goto L_0065;\n\tv28 = v66 <= index1;\n\tif (v28) goto L_0065;\n\tv67 = Obi.ObiNativeList`1<T>::get_count(this);\n\tv29 = v67 <= index2;\n\tif (v29) goto L_0065;\n\tv145 = this->klass;\n\t*([v145 @ X8_v8 (Il2CppClass<Obi.ObiNativeList`1<T>>)+180])(v150, this, index1, *([v145 @ X8_v8 (Il2CppClass<Obi.ObiNativeList`1<T>>)+188]), methodInfo, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94);\n\tv151 = this->klass;\n\t*([v151 @ X8_v9 (Il2CppClass<Obi.ObiNativeList`1<T>>)+180])(v157, this, index2, *([v151 @ X8_v9 (Il2CppClass<Obi.ObiNativeList`1<T>>)+188]), methodInfo, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94);\n\tv158 = this->klass;\n\t*([v158 @ X8_v10 (Il2CppClass<Obi.ObiNativeList`1<T>>)+190])(v163, this, index1, v157, *([v158 @ X8_v10 (Il2CppClass<Obi.ObiNativeList`1<T>>)+198]), v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94);\n\tv124 = this->klass;\n\tv100 = this->klass->vtable[6];\n\tv104 = this->klass->vtable[6];\n\t// 93 IndirectJump v100 @ X4_v1, this @ X0 (Obi.ObiNativeList`1<T>), this @ X0 (Obi.ObiNativeList`1<T>), index2 @ X2 (System.Int32), v150 @ X0_v9, v104 @ X3_v2, v100 @ X4_v1, v84 @ X5, v85 @ X6, v86 @ X7, v87 @ V0, v88 @ V1, v89 @ V2, v90 @ V3, v91 @ V4, v92 @ V5, v93 @ V6, v94 @ V7\nL_0065:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Swap(int index1, int index2)
		{
			//IL_0012: Expected I4, but got I8
			//IL_0056: Expected I4, but got I8
			//IL_00cb: Expected I, but got O
			//IL_00da: Expected I, but got O
			//IL_00e9: Expected I, but got O
			//IL_00f8: Expected I, but got O
			//IL_0108: Expected O, but got I
			//IL_0118: Expected O, but got I
			if ((int)(index1 & 0x80000000L) != 0)
			{
				return;
			}
			int num = count;
			if ((int)(index2 & 0x80000000L) == 0 && num > index1)
			{
				int num2 = count;
				if (num2 > index2)
				{
					IntPtr intPtr = (IntPtr)this;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v145 @ X8_v8 (Il2CppClass<Obi.ObiNativeList`1<T>>)+180] (should have been resolved before IL gen)");
					IntPtr intPtr2 = (IntPtr)this;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v151 @ X8_v9 (Il2CppClass<Obi.ObiNativeList`1<T>>)+180] (should have been resolved before IL gen)");
					IntPtr intPtr3 = (IntPtr)this;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v158 @ X8_v10 (Il2CppClass<Obi.ObiNativeList`1<T>>)+190] (should have been resolved before IL gen)");
					IntPtr intPtr4 = (IntPtr)this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ X8_v11 (Il2CppClass<Obi.ObiNativeList`1<T>>)+190]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ X8_v11 (Il2CppClass<Obi.ObiNativeList`1<T>>)+198]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v100 @ X4_v1 (should have been resolved before IL gen)");
				}
			}
		}
	}
}
