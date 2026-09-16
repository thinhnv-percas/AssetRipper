using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[DebuggerDisplay("Count={Count}")]
	[Token(Token = "0x2000044")]
	public class ExposedList<T> : IEnumerable<T>, IEnumerable
	{
		[Token(Token = "0x2000045")]
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40001BA")]
			[FieldOffset(Offset = "0x0")]
			internal ExposedList<T> l;

			[Token(Token = "0x40001BB")]
			[FieldOffset(Offset = "0x0")]
			private int next;

			[Token(Token = "0x40001BC")]
			[FieldOffset(Offset = "0x0")]
			private int ver;

			[Token(Token = "0x40001BD")]
			[FieldOffset(Offset = "0x0")]
			private T current;

			[Token(Token = "0x170000D6")]
			public T Current
			{
				[Token(Token = "0x60002BC")]
				[Address(RVA = "0xE934A8", Offset = "0xE934A8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.l;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return (T)l;
				}
			}

			[Token(Token = "0x170000D7")]
			object IEnumerator.Current
			{
				[Token(Token = "0x60002BE")]
				[Address(RVA = "0xE934EC", Offset = "0xE934EC", Length = "0xA0")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv15 = v6;\n\tv16 = 0xB348B0(v15, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = v16;\nL_0012:\n\tSpine.ExposedList`1<T>+Enumerator<T>::VerifyState(this);\n\tv50 = this->monitor;\n\tv49 = *([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]) <= 0;\n\tif (v49) goto L_0036;\n\tv50 = this.l;\n\tgoto L_002D;\n\tv60 = Spine.ExposedList`1<T>+Enumerator<T>::VerifyState(v52, v36);\nL_002D:\n\t// 45 Box returnVal1 @ X0_v12 (System.Object), typeof(Il2CppClass<T>), &v50 @ X8_v5 (Spine.ExposedList`1<T>)\n\treturn returnVal1;\nL_0036:\n\tv66 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v66);\n\tthrow v66;\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_0050: Expected O, but got I
					//IL_001d: Expected I, but got O
					VerifyState();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]");
					ExposedList<T> exposedList = (ExposedList<T>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]");
					if ((nint)0 > (nint)0)
					{
						exposedList = l;
						return (IntPtr)exposedList;
					}
					InvalidOperationException ex = new InvalidOperationException();
					throw ex;
				}
			}

			[Token(Token = "0x60002B8")]
			[Address(RVA = "0xE932EC", Offset = "0xE932EC", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]) = 0;\n\tthis.l = 0;\n\t*([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)]) = l;\n\t*([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+C]) = l.version;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal Enumerator(ExposedList<T> l)
			{
				_ = 0;
				this.l = null;
				_ = l.version;
			}

			[Token(Token = "0x60002B9")]
			[Address(RVA = "0xE93310", Offset = "0xE93310", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)]) = 0;\n\treturn;\n")]
			public void Dispose()
			{
				//IL_0009: Expected O, but got I4
				Enumerator enumerator = (Enumerator)0;
			}

			[Token(Token = "0x60002BA")]
			[Address(RVA = "0xE93318", Offset = "0xE93318", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this->klass;\n\tv10 = *([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)]) == 0;\n\tif (v10) goto L_001C;\n\tv22 = *([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+C]) != *([v8 @ X8_v1+1C]);\n\tif (v22) goto L_003E;\n\treturn;\nL_001C:\n\tv24 = this->klass;\n\tv30 = 0x9E5D78(Il2CppClass<Spine.ExposedList`1+Enumerator>, methodInfo, v31, v32, v33, v34, v35, v36, *([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)]), v37, v38, v39, v40, v41, v42, v43);\n\tv53 = *([v30 @ X0_v4+C0]);\n\tv56 = \"il2cpp_vm_object_box\"(*([v53 @ X8_v4]), &v24 @ V0_v2, v31, v32, v33, v34, v35, v36, *([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)]), v37, v38, v39, v40, v41, v42, v43);\n\tv102 = System.Object::GetType(v56);\n\tv108 = 0x9DE264(v102, 0, v31, v32, v33, v34, v35, v36, *([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)]), v37, v38, v39, v40, v41, v42, v43);\n\tv116 = System.Type::get_FullName(v102);\n\tv122 = new System.ObjectDisposedException();\n\tSystem.ObjectDisposedException::.ctor(v122, v116);\n\tgoto L_0049;\nL_003E:\n\tv100 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v100, \"Collection was modified; enumeration operation may not execute.\");\nL_0049:\n\tthrow v100;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void VerifyState()
			{
				//IL_0005: Expected O, but got Ref
				//IL_0054: Expected O, but got Ref
				//IL_006e: Expected O, but got I
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
				InvalidOperationException ex = default(InvalidOperationException);
				if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+C]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ X8_v1+1C]");
					if (num == 0)
					{
						return;
					}
					ex = new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
				}
				else
				{
					object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9E5D78");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X0_v4+C0]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object obj4 = default(object);
					Type type = obj4.GetType();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DE264");
					string fullName = type.FullName;
					ObjectDisposedException ex2 = new ObjectDisposedException(fullName);
				}
				throw ex;
			}

			[Token(Token = "0x60002BB")]
			[Address(RVA = "0xE93408", Offset = "0xE93408", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv12 = v4;\n\tv13 = 0xB348B0(v12, methodInfo, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tv30 = v13;\nL_0010:\n\tSpine.ExposedList`1<T>+Enumerator<T>::VerifyState(this);\n\tv35 = *([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]) & 0x80000000;\n\tv36 = v35 == 0;\n\tv37 = ~v36;\n\tif (v37) goto L_FFFFFFFF;\n\tv38 = this->klass;\n\tv51 = *([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]) >= *([v38 @ X9_v3+18]);\n\tif (v51) goto L_003E;\n\tv72 = *([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]) + 1;\n\t*([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]) = v72;\n\tv138 = *([v38 @ X9_v3+10]) + *([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]);\n\tthis.l = *([v138 @ X8_v7+20]);\n\tgoto L_0042;\n\tgoto L_0042;\nL_003E:\n\t*([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]) = 0xFFFFFFFF;\nL_0042:\n\treturn returnVal1;\n\tv77 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe bool MoveNext()
			{
				//IL_00e1: Expected I4, but got I8
				//IL_000a: Expected O, but got Ref
				//IL_0054: Expected O, but got I
				//IL_007b: Expected O, but got I
				//IL_008d: Expected O, but got I
				VerifyState();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]");
				if (0 == 0)
				{
					object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v3+18]");
					if (num < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]");
						object obj2 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X9_v3+10]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]");
						object obj3 = num2 + 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ X8_v7+20]");
						l = (ExposedList<T>)0;
						return true;
					}
					_ = 4294967295L;
					return false;
				}
				return false;
			}

			[Token(Token = "0x60002BD")]
			[Address(RVA = "0xE934B0", Offset = "0xE934B0", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv12 = v4;\n\tv13 = 0xB348B0(v12, methodInfo, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tv30 = v13;\nL_0010:\n\tSpine.ExposedList`1<T>+Enumerator<T>::VerifyState(this);\n\t*([this @ X0 (Spine.ExposedList`1<T>+Enumerator<T>)+8]) = 0;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				VerifyState();
				_ = 0;
			}
		}

		[Token(Token = "0x40001B5")]
		[FieldOffset(Offset = "0x0")]
		public T[] Items;

		[Token(Token = "0x40001B6")]
		[FieldOffset(Offset = "0x0")]
		public int Count;

		[Token(Token = "0x40001B7")]
		private const int DefaultCapacity = 4;

		[Token(Token = "0x40001B8")]
		private static readonly T[] EmptyArray;

		[Token(Token = "0x40001B9")]
		[FieldOffset(Offset = "0x0")]
		private int version;

		[Token(Token = "0x170000D5")]
		public unsafe int Capacity
		{
			[Token(Token = "0x60002B3")]
			[Address(RVA = "0xF44454", Offset = "0xF44454", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Items;\n\treturn v2.Length;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				T[] items = Items;
				return items.Length;
			}
			[Token(Token = "0x60002B4")]
			[Address(RVA = "0xF44470", Offset = "0xF44470", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.Count < value;\n\tv10 = ~v8;\n\tv11 = this.Count - value;\n\tv13 = v11 == 0;\n\tv18 = ~v13;\n\tv19 = v10 & v18;\n\tif (v19) goto L_001F;\n\tv24 = this + 0x10;\n\tSystem.Array::Resize(v24, value);\n\treturn;\nL_001F:\n\tv45 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v45);\n\tthrow v45;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				bool flag = Count < value;
				bool flag2 = !flag;
				int num = Count - value;
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					Array.Resize(ref *(bool[]*)((nint)this + 16), value);
					return;
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				throw ex;
			}
		}

		[Token(Token = "0x6000271")]
		[Address(RVA = "0xF41BD0", Offset = "0xF41BD0", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tgoto L_0014;\n\tv18 = 0xB348B0(v13, v8, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0014:\n\tgoto L_001D;\n\tv37 = \"il2cpp_codegen_runtime_class_init\"(v33, v8, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_001D:\n\tgoto L_0021;\n\tv46 = 0xB348B0(v41, v8, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0021:\n\tthis.Items = v48.EmptyArray;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ExposedList()
		{
			Items = EmptyArray;
		}

		[Token(Token = "0x6000272")]
		[Address(RVA = "0xF41C3C", Offset = "0xF41C3C", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tSpine.ExposedList`1<T>::CheckCollection(this, collection);\n\tgoto L_001C;\n\tv28 = v23;\n\tv29 = Spine.ExposedList`1<T>::CheckCollection(v28, v23, v20);\n\tv45 = v29;\nL_001C:\n\t// 28 IsInst v47 @ X0_v3 (System.Collections.Generic.ICollection`1<T>), typeof(System.Collections.Generic.ICollection`1<T>), collection @ X1 (System.Collections.Generic.IEnumerable`1<T>)\n\tv48 = v47 == 0;\n\tif (v48) goto L_0054;\n\tgoto L_002B;\n\tv64 = v52;\n\tv65 = Spine.ExposedList`1<T>::CheckCollection(v64, v52, v20);\n\tv68 = v65;\nL_002B:\n\tv69 = *([v47 @ X0_v3 (System.Collections.Generic.ICollection`1<T>)]);\n\tv128 = *([v69 @ X8_v18 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]);\n\tv71 = *([v69 @ X8_v18 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]) == 0;\n\tif (v71) goto L_004B;\n\tv137 = *([v69 @ X8_v18 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+B0]) + 8;\nL_0036:\n\tv142 = *([v137 @ X10_v5-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v142) goto L_0075;\n\tv86 = v128 - 1;\n\tv137 = v137 + 0x10;\n\tv83 = v128 != 1;\n\tif (v83) goto L_0036;\nL_004B:\n\tv180 = Spine.ExposedList`1<T>::CheckCollection(v47, Il2CppClass<System.Collections.Generic.ICollection`1<T>>);\n\tgoto L_007B;\nL_0054:\n\tgoto L_0059;\n\tv72 = Spine.ExposedList`1<T>::CheckCollection(v59, v44, v20);\nL_0059:\n\tgoto L_0062;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v73, v44, v20, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0062:\n\tgoto L_006C;\n\tv147 = Spine.ExposedList`1<T>::CheckCollection(v121, v44, v20);\n\tv195 = Il2CppClass<Spine.ExposedList`1>;\n\tv150 = Il2CppRgctx<Spine.ExposedList`1>;\nL_006C:\n\tthis.Items = v151.EmptyArray;\n\tSpine.ExposedList`1<T>::AddEnumerable(this, collection);\n\treturn;\nL_0075:\n\tv163 = *([v137 @ X10_v5]) << 4;\n\tv164 = v69 + v163;\n\tv180 = v164 + 0x138;\nL_007B:\n\t*([v180 @ X0_v14])(v186, v47, *([v180 @ X0_v14+8]), v181, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_008A;\n\tv196 = v190;\n\tv197 = Spine.ExposedList`1<T>::CheckCollection(v196, v184, v181);\n\tv200 = v197;\nL_008A:\n\t// 138 NewArr v203 @ X0_v19 (T[]), typeof(Il2CppClass<T[]>), v186 @ X0_v16\n\tthis.Items = v203;\n\tSpine.ExposedList`1<T>::AddCollection(this, v47);\n\treturn;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ExposedList(IEnumerable<T> collection)
		{
			//IL_010c: Expected I, but got O
			//IL_011c: Expected O, but got I
			//IL_008b: Expected O, but got I
			//IL_0090: Expected I, but got O
			//IL_0035: Expected O, but got I
			//IL_00b2: Expected I4, but got O
			//IL_00c0: Expected O, but got I
			//IL_00cf: Expected O, but got I
			//IL_0049: Expected O, but got I
			//IL_0058: Expected O, but got I
			base._002Ector();
			CheckCollection(collection);
			ICollection<T> collection2 = collection as ICollection<T>;
			nint num3;
			if (collection2 != null)
			{
				nint num = (nint)collection2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v18 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v18 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]");
				if ((nint)0 == 0)
				{
					goto IL_0080;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v18 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+B0]");
				object obj2 = (nint)0 + (nint)8;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X10_v5-8]");
					if ((nint)0 == 0)
					{
						break;
					}
					object obj3 = (nint)obj - 1;
					obj2 = (nint)obj2 + 16;
					bool flag = (nint)obj != 1;
					obj = obj3;
					if (flag)
					{
						continue;
					}
					goto IL_0080;
				}
				int num2 = obj2 << 4;
				object obj4 = num + num2;
				object obj5 = (nint)obj4 + 312;
				num3 = 0;
				goto IL_0163;
			}
			Items = EmptyArray;
			AddEnumerable(collection);
			return;
			IL_0163:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v180 @ X0_v14] (should have been resolved before IL gen)");
			T[] items = null;
			Items = items;
			AddCollection(collection2);
			return;
			IL_0080:
			((ExposedList<T>)collection2).CheckCollection((IEnumerable<T>)0);
			num3 = unchecked((nint)null);
			goto IL_0163;
		}

		[Token(Token = "0x6000273")]
		[Address(RVA = "0xF41DD8", Offset = "0xF41DD8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv15 = capacity & 0x80000000;\n\tv16 = v15 == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_0023;\n\tgoto L_0018;\n\tv41 = 0xB348B0(v20, v10, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0018:\n\t// 24 NewArr v44 @ X0_v13 (T[]), typeof(Il2CppClass<T[]>), capacity @ X1 (System.Int32)\n\tthis.Items = v44;\n\treturn;\nL_0023:\n\tv45 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v45, \"capacity\");\n\tthrow v45;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ExposedList(int capacity)
		{
			//IL_0018: Expected I4, but got I8
			base._002Ector();
			if ((int)(capacity & 0x80000000L) == 0)
			{
				T[] items = null;
				Items = items;
				return;
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("capacity");
			throw ex;
		}

		[Token(Token = "0x6000274")]
		[Address(RVA = "0xF41E64", Offset = "0xF41E64", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Items = data;\n\tthis.Count = size;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal ExposedList(T[] data, int size)
		{
			Items = data;
			Count = size;
		}

		[Token(Token = "0x6000275")]
		[Address(RVA = "0xF41E94", Offset = "0xF41E94", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv114 = this.Items;\n\tv112 = this.Count;\n\tv23 = this.Count != v114.Length;\n\tif (v23) goto L_0024;\n\tSpine.ExposedList`1<T>::GrowIfNeeded(this, 1);\n\tv52 = this.Count + 1;\n\tthis.Count = v52;\n\tv96 = this.Items == 0;\n\tv58 = ~v96;\n\tif (v58) goto L_0031;\n\tv61 = new System.NullReferenceException();\nL_0024:\n\tv95 = v112 + 1;\n\tv110.Count = v95;\nL_0031:\n\tv125 = v109 & 1;\n\tv126 = v114 + v112;\n\t*([v126 @ X8_v3+20]) = v125;\n\tv128 = v110.version + 1;\n\tv110.version = v128;\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Add(T item)
		{
			//IL_0125: Expected O, but got I
			T[] items = Items;
			int count = Count;
			bool flag = Count != items.Length;
			T val = item;
			ExposedList<T> exposedList = this;
			if (!flag)
			{
				GrowIfNeeded(1);
				int count2 = Count + 1;
				Count = count2;
				bool flag2 = Items == null;
				bool flag3 = !flag2;
				val = item;
				exposedList = this;
				count = Count;
				items = Items;
				if (flag3)
				{
					goto IL_0108;
				}
				NullReferenceException ex = new NullReferenceException();
				val = item;
				exposedList = this;
				count = Count;
				items = Items;
			}
			int count3 = count + 1;
			exposedList.Count = count3;
			goto IL_0108;
			IL_0108:
			int num = (int)((nint)val & 1);
			object obj = (nint)items + count;
			int num2 = exposedList.version + 1;
			exposedList.version = num2;
		}

		[Token(Token = "0x6000276")]
		[Address(RVA = "0xF41F28", Offset = "0xF41F28", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv22 = System.Math;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, addedCount, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A35BCC]) = v39;\nL_0014:\n\tv40 = this.Items;\n\tv44 = this.Count + addedCount;\n\tv56 = v44 <= v40.Length;\n\tif (v56) goto L_0049;\n\tgoto L_002F;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v60, addedCount, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_002F:\n\tv71 = v40.Length << 1;\n\tv74 = System.Math::Max(v71, 4);\n\tv116 = System.Math::Max(v74, v44);\n\tSpine.ExposedList`1<T>::set_Capacity(this, v116);\n\treturn;\nL_0049:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void GrowIfNeeded(int addedCount)
		{
			T[] items = Items;
			int num = Count + addedCount;
			if (num > items.Length)
			{
				int val = items.Length << 1;
				int val2 = Math.Max(val, 4);
				int capacity = Math.Max(val2, num);
				Capacity = capacity;
			}
		}

		[Token(Token = "0x6000277")]
		[Address(RVA = "0xF41FE8", Offset = "0xF41FE8", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this + 0x10;\n\tv9 = *([v8 @ X0_v1 (System.Boolean[]&)]);\n\tv23 = v9.Length >= newSize;\n\tif (v23) goto L_001E;\n\tSystem.Array::Resize(v8, newSize);\n\tgoto L_003E;\nL_001E:\n\tv85 = v9.Length <= newSize;\n\tif (v85) goto L_003E;\n\tv86 = v9 + newSize;\n\tv61 = v86 + 0x20;\n\tv28 = v9.Length - newSize;\nL_002F:\n\t*([v61 @ X9_v6]) = 0;\n\tv61 = v61 + 1;\n\tv94 = v28 - 1;\n\tv98 = v28 != 1;\n\tif (v98) goto L_002F;\nL_003E:\n\tthis.Count = newSize;\n\treturn this;\n\tv63 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe ExposedList<T> Resize(int newSize)
		{
			//IL_007c: Expected O, but got I
			//IL_008b: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			//IL_00b7: Expected O, but got I
			ref bool[] reference = ref *(bool[]*)((nint)this + 16);
			bool[] array = reference;
			if (array.Length < newSize)
			{
				Array.Resize(ref reference, newSize);
			}
			else if (array.Length > newSize)
			{
				object obj = (nint)array + newSize;
				object obj2 = (nint)obj + 32;
				int num = array.Length - newSize;
				bool flag;
				do
				{
					obj2 = 0;
					obj2 = (nint)obj2 + 1;
					int num2 = num - 1;
					flag = num != 1;
					num = num2;
				}
				while (flag);
			}
			Count = newSize;
			return this;
		}

		[Token(Token = "0x6000278")]
		[Address(RVA = "0xF42070", Offset = "0xF42070", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.Items;\n\tv16 = v2.Length >= v55;\n\tif (v16) goto L_003C;\n\tv33 = v2.Length << 1;\n\tv45 = v2.Length != 0;\n\tif (v45) goto L_FFFFFFFF;\n\tgoto L_0026;\nL_0026:\n\tv85 = v91 - v55;\n\tv82 = v85 < 0;\n\tv76 = v91 ^ v55;\n\tv73 = v91 ^ v85;\n\tv70 = v76 & v73;\n\tv67 = v70 < 0;\n\tv93 = v82 == v67;\n\tv64 = ~v93;\n\tv57 = ~v64;\n\tif (v57) goto L_0038;\n\tgoto L_0038;\nL_0038:\n\tSpine.ExposedList`1<T>::set_Capacity(this, v91);\n\treturn;\nL_003C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void EnsureCapacity(int min)
		{
			T[] items = Items;
			int num = default(int);
			if (items.Length < num)
			{
				int num2 = items.Length << 1;
				int num3 = ((items.Length != 0) ? num2 : 4);
				int num4 = num3 - num;
				bool flag = num4 < 0;
				int num5 = num3 ^ num;
				int num6 = num3 ^ num4;
				int num7 = num5 & num6;
				bool flag2 = num7 < 0;
				if (flag != flag2)
				{
				}
				Capacity = num3;
			}
		}

		[Token(Token = "0x6000279")]
		[Address(RVA = "0xF420C0", Offset = "0xF420C0", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = index & 0x80000000;\n\tv8 = v6 == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_0023;\n\tv10 = count & 0x80000000;\n\tv12 = v10 == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_002C;\n\tv33 = count + index;\n\tv34 = v33 < this.Count;\n\tv35 = ~v34;\n\tv36 = v33 - this.Count;\n\tv38 = v36 == 0;\n\tv43 = ~v38;\n\tv44 = v35 & v43;\n\tif (v44) goto L_003A;\n\treturn;\nL_0023:\n\tv49 = new System.ArgumentOutOfRangeException();\n\tgoto L_0034;\nL_002C:\n\tv57 = new System.ArgumentOutOfRangeException();\nL_0034:\n\tSystem.ArgumentOutOfRangeException::.ctor(v102, v100);\n\tgoto L_0045;\nL_003A:\n\tv96 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v96, \"index and count exceed length of list\");\nL_0045:\n\tthrow v102;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CheckRange(int index, int count)
		{
			//IL_0012: Expected I4, but got I8
			//IL_004c: Expected I4, but got I8
			ArgumentOutOfRangeException ex3 = default(ArgumentOutOfRangeException);
			if ((int)(index & 0x80000000L) == 0)
			{
				if ((int)(count & 0x80000000L) == 0)
				{
					int num = count + index;
					bool flag = num < Count;
					bool flag2 = !flag;
					int num2 = num - Count;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						return;
					}
					ArgumentException ex = new ArgumentException("index and count exceed length of list");
				}
				else
				{
					ArgumentOutOfRangeException ex2 = new ArgumentOutOfRangeException();
					string text = "count";
					ex3 = ex2;
				}
			}
			else
			{
				ArgumentOutOfRangeException ex4 = new ArgumentOutOfRangeException();
				string text = "index";
				ex3 = ex4;
			}
			throw ex3;
		}

		[Token(Token = "0x600027A")]
		[Address(RVA = "0xF42188", Offset = "0xF42188", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv40 = v21;\n\tv41 = 0xB348B0(v40, v21, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv44 = v41;\nL_0017:\n\tv45 = collection->klass;\n\tv143 = collection->klass->interface_offsets_count;\n\tv47 = *([v45 @ X8_v4 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]) == 0;\n\tif (v47) goto L_0038;\n\tv152 = *([v45 @ X8_v4 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+B0]) + 8;\nL_0022:\n\tv157 = *([v152 @ X10_v12-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v157) goto L_003A;\n\tv57 = v143 - 1;\n\tv152 = v152 + 0x10;\n\tv54 = v143 != 1;\n\tif (v54) goto L_0022;\nL_0038:\n\tgoto L_0040;\nL_003A:\n\t;\nL_0040:\n\tv186 = System.Collections.Generic.ICollection`1<T>::get_Count(collection);\n\tv187 = v186 == 0;\n\tif (v187) goto L_008E;\n\tSpine.ExposedList`1<T>::GrowIfNeeded(this, v186);\n\tgoto L_0057;\n\tv225 = v220;\n\tv226 = Spine.ExposedList`1<T>::GrowIfNeeded(v225, v220, v193);\n\tv229 = v226;\nL_0057:\n\tv230 = collection->klass;\n\tv263 = collection->klass->interface_offsets_count;\n\tv217 = *([v230 @ X8_v13 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]) == 0;\n\tif (v217) goto L_0078;\n\tv272 = *([v230 @ X8_v13 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+B0]) + 8;\nL_0062:\n\tv277 = *([v272 @ X10_v7-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v277) goto L_007A;\n\tv239 = v263 - 1;\n\tv272 = v272 + 0x10;\n\tv237 = v263 != 1;\n\tif (v237) goto L_0062;\nL_0078:\n\tgoto L_0083;\nL_007A:\n\t;\nL_0083:\n\tv212 = System.Collections.Generic.ICollection`1<T>::CopyTo(collection, this.Items, this.Count);\n\tv216 = this.Count + v186;\n\tthis.Count = v216;\nL_008E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddCollection(ICollection<T> collection)
		{
			//IL_00f9: Expected I, but got O
			//IL_0109: Expected O, but got I
			//IL_001b: Expected O, but got I
			//IL_0182: Expected I, but got O
			//IL_0192: Expected O, but got I
			//IL_002f: Expected O, but got I
			//IL_003e: Expected O, but got I
			//IL_0098: Expected O, but got I
			//IL_00ac: Expected O, but got I
			//IL_00bb: Expected O, but got I
			nint num = (nint)collection;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v4 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v4 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v4 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+B0]");
				object obj2 = (nint)0 + (nint)8;
				bool flag;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X10_v12-8]");
					if ((nint)0 != 0)
					{
						object obj3 = (nint)obj - 1;
						obj2 = (nint)obj2 + 16;
						flag = (nint)obj != 1;
						obj = obj3;
						continue;
					}
					break;
				}
				while (flag);
			}
			int count = collection.Count;
			if (count == 0)
			{
				return;
			}
			GrowIfNeeded(count);
			nint num2 = (nint)collection;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ X8_v13 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ X8_v13 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ X8_v13 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+B0]");
				object obj5 = (nint)0 + (nint)8;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ X10_v7-8]");
					if ((nint)0 != 0)
					{
						object obj6 = (nint)obj4 - 1;
						obj5 = (nint)obj5 + 16;
						flag2 = (nint)obj4 != 1;
						obj4 = obj6;
						continue;
					}
					break;
				}
				while (flag2);
			}
			collection.CopyTo(Items, Count);
			int count2 = Count + count;
			Count = count2;
		}

		[Token(Token = "0x600027B")]
		[Address(RVA = "0xF422E0", Offset = "0xF422E0", Length = "0x2F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv24 = System.IDisposable;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, enumerable, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv45 = System.Collections.IEnumerator;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, enumerable, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35BCD]) = v42;\nL_0021:\n\tgoto L_0025;\n\tv54 = v48;\n\tv55 = 0xB348B0(v54, v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv57 = v55;\nL_0025:\n\tv59 = enumerable->klass;\n\tv195 = enumerable->klass->interface_offsets_count;\n\tv61 = *([v59 @ X8_v19 (Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>)+12E]) == 0;\n\tif (v61) goto L_0046;\n\tv204 = *([v59 @ X8_v19 (Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>)+B0]) + 8;\nL_0030:\n\tv209 = *([v204 @ X10_v35-8]) == Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>;\n\tif (v209) goto L_0048;\n\tv123 = v195 - 1;\n\tv204 = v204 + 0x10;\n\tv121 = v195 != 1;\n\tif (v121) goto L_0030;\nL_0046:\n\tgoto L_0050;\nL_0048:\n\t;\nL_0050:\n\tv106 = System.Collections.Generic.IEnumerable`1<T>::GetEnumerator(enumerable);\nL_005A:\n\tgoto L_0080;\n\tv282 = *([v275 @ X8_v23+B0]);\n\tv283 = v282 + 8;\n\tv285 = *([v363 @ X10_v30-8]);\n\tv368 = v285 == v276;\n\tif (v368) goto L_0079;\n\tv289 = v354 - 1;\n\tv307 = v363 + 0x10;\n\tv287 = v354 != 1;\n\tif (v287) goto L_FFFFFFFF;\n\tv308 = v110;\n\tv309 = 0;\n\tv310 = 0xB349B4(v308, v276, v309, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0080;\nL_0079:\n\tv446 = *([v363 @ X10_v30]);\n\tv447 = v446 << 4;\n\tv448 = v275 + v447;\n\tv449 = v448 + 0x138;\nL_0080:\n\tv404 = System.Collections.IEnumerator::MoveNext(v106);\n\tv406 = v404 == 0;\n\tif (v406) goto L_FFFFFFFF;\n\tgoto L_008F;\n\tv549 = v501;\n\tv550 = 0xB348B0(v549, v501, v378, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv552 = v550;\nL_008F:\n\tv554 = *([v106 @ X0_v35 (System.Collections.IEnumerator)]);\n\tv640 = *([v554 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+12E]);\n\tv272 = *([v554 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+12E]) == 0;\n\tif (v272) goto L_FFFFFFFF;\n\tv649 = *([v554 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_009A:\n\tv654 = *([v649 @ X10_v25-8]) == Il2CppClass<System.Collections.Generic.IEnumerator`1<T>>;\n\tif (v654) goto L_00B2;\n\tv608 = v640 - 1;\n\tv649 = v649 + 0x10;\n\tv606 = v640 != 1;\n\tif (v606) goto L_009A;\n\tgoto L_00B8;\nL_00B2:\n\t;\nL_00B8:\n\tv670 = System.Collections.Generic.IEnumerator`1<T>::get_Current(v106);\n\tv268 = v670 & 1;\n\tSpine.ExposedList`1<T>::Add(this, v268);\n\tgoto L_005A;\nL_00C1:\n\tv410 = v184 == 0;\n\tif (v410) goto L_00EE;\n\tv454 = *([v184 @ X19_v2 (System.Collections.IEnumerator)]);\n\tv558 = *([v454 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+12E]);\n\tv457 = *([v454 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+12E]) == 0;\n\tif (v457) goto L_00E4;\n\tv567 = *([v454 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_00CF:\n\tv572 = *([v567 @ X10_v7-8]) == *([v190 @ X22_v2 (Il2CppClass<System.IDisposable>)]);\n\tif (v572) goto L_00E7;\n\tv513 = v558 - 1;\n\tv567 = v567 + 0x10;\n\tv511 = v558 != 1;\n\tif (v511) goto L_00CF;\nL_00E4:\n\t;\n\tgoto L_00ED;\nL_00E7:\n\t;\nL_00ED:\n\tv473 = System.IDisposable::Dispose(v184);\nL_00EE:\n\tv476 = v186 == 0;\n\tv180 = ~v476;\n\tif (v180) goto L_00FC;\n\treturn;\n\tv53 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00FC:\n\tv192 = new System.OutOfMemoryException();\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\nL_010A:\n\tv233 = v343 != 1;\n\tif (v233) goto L_0112;\n\tv237 = 0x1854E70(v192, v343, v319, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv186 = *([v237 @ X0_v27]);\n\tv280 = 0x1854E80(v237, v343, v319, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_00C1;\nL_0112:\n\tgoto L_0114;\n\tX21 = X0;\nL_0114:\n\tv281 = v183 == 0;\n\tif (v281) goto L_0143;\n\tv311 = *([v183 @ X19_v4 (System.Collections.IEnumerator)]);\n\tv479 = *([v311 @ X8_v11 (Il2CppClass<System.Collections.IEnumerator>)+12E]);\n\tv314 = *([v311 @ X8_v11 (Il2CppClass<System.Collections.IEnumerator>)+12E]) == 0;\n\tif (v314) goto L_0137;\n\tv488 = *([v311 @ X8_v11 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0122:\n\tv493 = *([v488 @ X10_v15-8]) == *([v189 @ X22_v4 (Il2CppClass<System.IDisposable>)]);\n\tif (v493) goto L_013A;\n\tv418 = v479 - 1;\n\tv488 = v488 + 0x10;\n\tv416 = v479 != 1;\n\tif (v416) goto L_0122;\nL_0137:\n\t;\n\tgoto L_0140;\nL_013A:\n\tv543 = *([v488 @ X10_v15]) << 4;\n\tv544 = v311 + v543;\n\tv546 = v544 + 0x138;\nL_0140:\n\tv346 = System.IDisposable::Dispose(v183);\nL_0143:\n\tgoto L_0147;\n\tv441 = 0xBD3CD0(v192, *([v546 @ X0_v20+8]), 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0147:\n\tv444 = new System.OutOfMemoryException();\n\tv498 = 0x9DACB4(v444, *([v546 @ X0_v20+8]), 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 204 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddEnumerable(IEnumerable<T> enumerable)
		{
			//IL_032e: Expected I, but got O
			//IL_033e: Expected O, but got I
			//IL_0020: Expected O, but got I
			//IL_010d: Expected I, but got O
			//IL_0034: Expected O, but got I
			//IL_0043: Expected O, but got I
			//IL_03c9: Expected I, but got O
			//IL_03d9: Expected O, but got I
			//IL_011a: Expected I, but got O
			//IL_012a: Expected O, but got I
			//IL_0446: Expected O, but got I4
			//IL_0093: Expected O, but got I
			//IL_0165: Expected O, but got I
			//IL_0200: Expected I4, but got O
			//IL_00a7: Expected O, but got I
			//IL_00b6: Expected O, but got I
			//IL_0232: Expected I, but got O
			//IL_0242: Expected O, but got I
			//IL_0179: Expected O, but got I
			//IL_0188: Expected O, but got I
			//IL_027d: Expected O, but got I
			//IL_02dc: Expected I4, but got O
			//IL_02ea: Expected O, but got I
			//IL_02f9: Expected O, but got I
			//IL_0291: Expected O, but got I
			//IL_02a0: Expected O, but got I
			nint num = (nint)enumerable;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X8_v19 (Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>)+12E]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X8_v19 (Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>)+12E]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X8_v19 (Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>)+B0]");
				object obj2 = (nint)0 + (nint)8;
				bool flag;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ X10_v35-8]");
					if ((nint)0 != 0)
					{
						object obj3 = (nint)obj - 1;
						obj2 = (nint)obj2 + 16;
						flag = (nint)obj != 1;
						obj = obj3;
						continue;
					}
					break;
				}
				while (flag);
			}
			IEnumerator enumerator = enumerable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				nint num2 = (nint)enumerator;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj5 = (nint)0 + (nint)8;
					bool flag2;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v649 @ X10_v25-8]");
						if ((nint)0 != 0)
						{
							object obj6 = (nint)obj4 - 1;
							obj5 = (nint)obj5 + 16;
							flag2 = (nint)obj4 != 1;
							obj4 = obj6;
							continue;
						}
						break;
					}
					while (flag2);
				}
				object current = ((IEnumerator<T>)enumerator).Current;
				int num3 = (int)((nint)current & 1);
				Add((T)num3);
			}
			IEnumerator enumerator2 = enumerator;
			int num4 = 0;
			nint num5 = (nint)typeof(IDisposable);
			int num7 = default(int);
			object obj10 = default(object);
			IEnumerator enumerator3 = default(IEnumerator);
			IntPtr intPtr = default(IntPtr);
			while (true)
			{
				if (enumerator2 != null)
				{
					nint num6 = (nint)enumerator2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						object obj8 = (nint)0 + (nint)8;
						bool flag3;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v567 @ X10_v7-8]");
							if (0 != num5)
							{
								object obj9 = (nint)obj7 - 1;
								obj8 = (nint)obj8 + 16;
								flag3 = (nint)obj7 != 1;
								obj7 = obj9;
								continue;
							}
							break;
						}
						while (flag3);
					}
					((IDisposable)enumerator2).Dispose();
				}
				if (num4 == 0)
				{
					return;
				}
				OutOfMemoryException ex = new OutOfMemoryException();
				if (num7 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
					num4 = (int)obj10;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
					enumerator2 = enumerator3;
					num5 = intPtr;
					continue;
				}
				break;
			}
			if (enumerator3 != null)
			{
				nint num8 = (nint)enumerator3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X8_v11 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X8_v11 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X8_v11 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj12 = (nint)0 + (nint)8;
					bool flag4;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ X10_v15-8]");
						if ((IntPtr)0 != intPtr)
						{
							object obj13 = (nint)obj11 - 1;
							obj12 = (nint)obj12 + 16;
							flag4 = (nint)obj11 != 1;
							obj11 = obj13;
							continue;
						}
						int num9 = obj12 << 4;
						object obj14 = num8 + num9;
						object obj15 = (nint)obj14 + 312;
						break;
					}
					while (flag4);
				}
				((IDisposable)enumerator3).Dispose();
			}
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
		}

		[Token(Token = "0x600027C")]
		[Address(RVA = "0xF425D0", Offset = "0xF425D0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.ExposedList`1<T>::CheckCollection(this, list);\n\tv21 = list.Count == 0;\n\tif (v21) goto L_002B;\n\tSpine.ExposedList`1<T>::GrowIfNeeded(this, list.Count);\n\tSystem.Array::Copy(list.Items, 0, this.Items, this.Count, list.Count);\n\tv57 = this.Count + list.Count;\n\tv42 = this.version + 1;\n\tthis.Count = v57;\n\tthis.version = v42;\nL_002B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddRange(ExposedList<T> list)
		{
			CheckCollection(list);
			if (list.Count != 0)
			{
				GrowIfNeeded(list.Count);
				Array.Copy(list.Items, 0, Items, Count, list.Count);
				int count = Count + list.Count;
				int num = version + 1;
				Count = count;
				version = num;
			}
		}

		[Token(Token = "0x600027D")]
		[Address(RVA = "0xF4265C", Offset = "0xF4265C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.ExposedList`1<T>::CheckCollection(this, collection);\n\tgoto L_0018;\n\tv24 = v19;\n\tv25 = Spine.ExposedList`1<T>::CheckCollection(v24, v19, v16);\n\tv41 = v25;\nL_0018:\n\t// 24 IsInst v43 @ X0_v3 (System.Collections.Generic.ICollection`1<T>), typeof(System.Collections.Generic.ICollection`1<T>), collection @ X1 (System.Collections.Generic.IEnumerable`1<T>)\n\tv46 = v43 == 0;\n\tif (v46) goto L_0025;\n\tSpine.ExposedList`1<T>::AddCollection(this, v43);\n\tgoto L_0027;\nL_0025:\n\tSpine.ExposedList`1<T>::AddEnumerable(this, collection);\nL_0027:\n\tv57 = this.version + 1;\n\tthis.version = v57;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddRange(IEnumerable<T> collection)
		{
			CheckCollection(collection);
			ICollection<T> collection2 = collection as ICollection<T>;
			if (collection2 != null)
			{
				AddCollection(collection2);
			}
			else
			{
				AddEnumerable(collection);
			}
			int num = version + 1;
			version = num;
		}

		[Token(Token = "0x600027E")]
		[Address(RVA = "0xF426F0", Offset = "0xF426F0", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = item & 1;\n\treturnVal1 = System.Array::BinarySearch(this.Items, 0, this.Count, v4);\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int BinarySearch(T item)
		{
			//IL_0029: Expected O, but got I4
			int num = (int)((nint)item & 1);
			return Array.BinarySearch(Items, 0, Count, (T)num);
		}

		[Token(Token = "0x600027F")]
		[Address(RVA = "0xF42714", Offset = "0xF42714", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = item & 1;\n\treturnVal1 = System.Array::BinarySearch(this.Items, 0, this.Count, v4, comparer);\n\treturn returnVal1;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int BinarySearch(T item, IComparer<T> comparer)
		{
			bool value = (byte)((nint)item & 1) != 0;
			return Array.BinarySearch((bool[])(object)Items, 0, Count, value, (IComparer<bool>)comparer);
		}

		[Token(Token = "0x6000280")]
		[Address(RVA = "0xF42740", Offset = "0xF42740", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.ExposedList`1<T>::CheckRange(this, index, count);\n\tv31 = item & 1;\n\treturnVal1 = System.Array::BinarySearch(this.Items, index, count, v31, comparer);\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
		{
			CheckRange(index, count);
			bool value = (byte)((nint)item & 1) != 0;
			return Array.BinarySearch((bool[])(object)Items, index, count, value, (IComparer<bool>)comparer);
		}

		[Token(Token = "0x6000281")]
		[Address(RVA = "0xF427AC", Offset = "0xF427AC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = clearArray == 0;\n\tif (v8) goto L_000F;\n\tv9 = this.Items;\n\tSystem.Array::Clear(this.Items, 0, *([v9 @ X0_v2 (System.Array)+18]));\nL_000F:\n\tv22 = this.version + 1;\n\tthis.Count = 0;\n\tthis.version = v22;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear(bool clearArray = true)
		{
			if (clearArray)
			{
				Array items = Items;
				T[] items2 = Items;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X0_v2 (System.Array)+18]");
				Array.Clear(items2, 0, 0);
			}
			int num = version + 1;
			Count = 0;
			version = num;
		}

		[Token(Token = "0x6000282")]
		[Address(RVA = "0xF427E8", Offset = "0xF427E8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = item & 1;\n\tv13 = System.Array::IndexOf(this.Items, v6, 0, this.Count);\n\tv14 = v13 + 1;\n\tv16 = v14 == 0;\n\tv19 = ~v16;\n\treturn v19;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Contains(T item)
		{
			bool value = (byte)((nint)item & 1) != 0;
			int num = Array.IndexOf((bool[])(object)Items, value, 0, Count);
			int num2 = num + 1;
			bool flag = num2 == 0;
			return !flag;
		}

		[Token(Token = "0x6000283")]
		[Address(RVA = "0xC396E0", Offset = "0xC396E0", Length = "0x240")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-60_v2;\n\t*([v24 @ X29_v1-8]) = *([v27 @ SYSREG+28]);\n\tgoto L_001D;\n\tv39 = 0xB3490C(methodInfo, converter, methodInfo, v211, v209, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_001D:\n\tv57 = Il2CppClass<TOutput>;\n\tv60 = Il2CppClass<T>;\n\t*([v24 @ X29_v1-20]) = *([v57 @ X10_v1 (Il2CppClass<TOutput>)+FC]);\n\tv61 = *([v57 @ X10_v1 (Il2CppClass<TOutput>)+FC]) + 0xF;\n\tv62 = v61 & 0x1FFFFFFF0;\n\tv66 = &v65 @ stack_-90_v1 - v62;\n\tv68 = *([v60 @ X9_v3 (Il2CppClass<T>)+FC]) + 0xF;\n\tv71 = v68 & 0x1FFFFFFF0;\n\tv72 = &v65 @ stack_-90_v1 - v71;\n\tv74 = converter == 0;\n\tif (v74) goto L_00D9;\n\t*([v24 @ X29_v1-28]) = v27;\n\tgoto L_0039;\n\tv137 = 0xB348B0(v75, converter, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0039:\n\tv139 = new Il2CppClass<Spine.ExposedList`1<TOutput>>();\n\tv315 = Spine.ExposedList`1<TOutput>::.ctor(v139, this.Count);\n\tv199 = this.Count;\n\tv157 = this.Count < 1;\n\tif (v157) goto L_00B5;\nL_0050:\n\tv256 = this.Items;\n\tv351 = *([v256 @ X8_v15 (T[])]);\n\tv168 = v139.Items;\n\tv355 = v247 * *([v351 @ X9_v14 (Il2CppClass<T[]>)+104]);\n\tv356 = v256 + v355;\n\tv357 = v356 + 0x20;\n\tv358 = 0x1854F10(v72, v357, *([v60 @ X9_v3 (Il2CppClass<T>)+FC]), v211, v66, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_0073;\n\tv386 = *([v72 @ X25_v1]);\nL_0073:\n\tv211 = &v25 @ stack_-60_v2 - 0x18;\n\tv246 = Il2CppMethodInfo;\n\t*([v24 @ X29_v1-18]) = v72;\n\t*([v24 @ X29_v1-10]) = v66;\n\t*([v246 @ X1_v11 (Il2CppMethodInfo)+10])(v251, *([v246 @ X1_v11 (Il2CppMethodInfo)]), Il2CppMethodInfo, converter, v211, v66, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv390 = *([v168 @ X28_v8 (TOutput[])]);\n\tv392 = v247 * *([v390 @ X8_v24 (Il2CppClass<TOutput[]>)+104]);\n\tv393 = v168 + v392;\n\tv394 = v393 + 0x20;\n\tv395 = Spine.ExposedList`1<TOutput>::.ctor(v394, v66);\n\tgoto L_00A5;\n\tv400 = Spine.ExposedList`1<TOutput>::.ctor(v397, v192, v190);\nL_00A5:\n\tv199 = this.Count;\n\tv247 = v247 + 1;\n\tv172 = v247 < this.Count;\n\tif (v172) goto L_0050;\nL_00B5:\n\tv139.Count = v199;\n\tv260 = *([v24 @ X29_v1-28]);\n\tv272 = *([v260 @ X8_v12+28]) != *([v24 @ X29_v1-8]);\n\tif (v272) goto L_00E5;\n\treturn v139;\n\tv249 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\nL_00D9:\n\tv140 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v140, \"converter\");\n\tthrow v140;\nL_00E5:\n\treturnVal2 = Spine.ExposedList`1<TOutput>::.ctor(v315, v191);\n\treturn returnVal2;\n// 171 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ExposedList<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
		{
			//IL_0207: Expected O, but got I
			//IL_021a: Expected I4, but got I8
			//IL_023e: Expected O, but got I
			//IL_0251: Expected I4, but got I8
			//IL_025f: Expected O, but got I
			//IL_0180: Expected O, but got I
			//IL_008d: Expected I, but got O
			//IL_00b0: Expected O, but got I
			//IL_00bf: Expected O, but got I
			//IL_00ce: Expected O, but got I
			//IL_028b: Expected O, but got I
			//IL_00e5: Expected I, but got O
			//IL_00fc: Expected O, but got I
			//IL_010b: Expected O, but got I
			//IL_011a: Expected O, but got I
			//IL_0155: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X10_v1 (Il2CppClass<TOutput>)+FC]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X10_v1 (Il2CppClass<TOutput>)+FC]");
			object obj3 = (nint)0 + (nint)15;
			int num3 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			object obj4 = default(object);
			int num4 = (int)((nint)obj4 - num3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X9_v3 (Il2CppClass<T>)+FC]");
			object obj5 = (nint)0 + (nint)15;
			int num5 = (int)((nint)obj5 & 0x1FFFFFFF0L);
			object obj6 = (nint)obj4 - num5;
			if (converter != null)
			{
				ExposedList<TOutput> exposedList = new ExposedList<TOutput>(Count);
				int count = Count;
				bool flag = Count < 1;
				int count2 = Count;
				if (!flag)
				{
					int num6 = 0;
					bool flag2;
					do
					{
						T[] items = Items;
						nint num7 = (nint)items;
						TOutput[] items2 = exposedList.Items;
						int num8 = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ X9_v14 (Il2CppClass<T[]>)+104]");
						object obj7 = (nint)num8 * (nint)0;
						object obj8 = (nint)items + (nint)obj7;
						object obj9 = (nint)obj8 + 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
						object obj10 = (nint)obj2 - 24;
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ X1_v11 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
						nint num10 = (nint)items2;
						int num11 = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ X8_v24 (Il2CppClass<TOutput[]>)+104]");
						object obj11 = (nint)num11 * (nint)0;
						object obj12 = (nint)items2 + (nint)obj11;
						ExposedList<TOutput> exposedList2 = (ExposedList<TOutput>)((nint)obj12 + 32);
						count = Count;
						num6++;
						flag2 = num6 < Count;
						count2 = num4;
						ExposedList<TOutput> exposedList3 = (ExposedList<TOutput>)0;
					}
					while (flag2);
				}
				exposedList.Count = count;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-28]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ X8_v12+28]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-8]");
				if (num12 == 0)
				{
					return exposedList;
				}
				ExposedList<TOutput> result = default(ExposedList<TOutput>);
				return result;
			}
			ArgumentNullException ex = new ArgumentNullException("converter");
			throw ex;
		}

		[Token(Token = "0x6000284")]
		[Address(RVA = "0xF42820", Offset = "0xF42820", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Array::Copy(this.Items, 0, array, 0, this.Count);\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CopyTo(T[] array)
		{
			Array.Copy(Items, 0, array, 0, Count);
		}

		[Token(Token = "0x6000285")]
		[Address(RVA = "0xF42840", Offset = "0xF42840", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Array::Copy(this.Items, 0, array, arrayIndex, this.Count);\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CopyTo(T[] array, int arrayIndex)
		{
			Array.Copy(Items, 0, array, arrayIndex, Count);
		}

		[Token(Token = "0x6000286")]
		[Address(RVA = "0xF42860", Offset = "0xF42860", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.ExposedList`1<T>::CheckRange(this, index, count);\n\tSystem.Array::Copy(this.Items, index, array, arrayIndex, count);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
			CheckRange(index, count);
			Array.Copy(Items, index, array, arrayIndex, count);
		}

		[Token(Token = "0x6000287")]
		[Address(RVA = "0xF428BC", Offset = "0xF428BC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv21 = v16;\n\tv22 = 0xB348B0(v21, match, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0016:\n\tgoto L_001D;\n\tv42 = v37;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v42, match, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001D:\n\tSpine.ExposedList`1<T>::CheckMatch(match);\n\tv56 = Spine.ExposedList`1<T>::GetIndex(this, 0, this.Count, match);\n\tv59 = v56 + 1;\n\tv61 = v59 == 0;\n\tv64 = ~v61;\n\treturn v64;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Exists(Predicate<T> match)
		{
			CheckMatch(match);
			int index = GetIndex(0, Count, match);
			int num = index + 1;
			bool flag = num == 0;
			return !flag;
		}

		[Token(Token = "0x6000288")]
		[Address(RVA = "0xF42948", Offset = "0xF42948", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv21 = v16;\n\tv22 = 0xB348B0(v21, match, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0016:\n\tgoto L_001D;\n\tv42 = v37;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v42, match, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001D:\n\tSpine.ExposedList`1<T>::CheckMatch(match);\n\tv56 = Spine.ExposedList`1<T>::GetIndex(this, 0, this.Count, match);\n\tv57 = v56 + 1;\n\tv59 = v57 == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tv109 = this.Items + v56;\n\tv96 = *([v109 @ X8_v11+20]) == 0;\n\tv78 = ~v96;\n\tgoto L_004E;\nL_004E:\n\treturn returnVal1;\n\tv75 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T Find(Predicate<T> match)
		{
			//IL_0067: Expected O, but got I
			//IL_0091: Expected O, but got I4
			CheckMatch(match);
			int index = GetIndex(0, Count, match);
			if (index + 1 != 0)
			{
				object obj = (nint)Items + index;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X8_v11+20]");
				bool flag = (nint)0 == 0;
				bool flag2 = !flag;
				return (T)flag2;
			}
			return (T)null;
		}

		[Token(Token = "0x6000289")]
		[Address(RVA = "0xF42A08", Offset = "0xF42A08", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = match == 0;\n\tif (v0) goto L_000B;\n\treturn;\nL_000B:\n\tv42 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v42, \"match\");\n\tthrow v42;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void CheckMatch(Predicate<T> match)
		{
			if (match != null)
			{
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("match");
			throw ex;
		}

		[Token(Token = "0x600028A")]
		[Address(RVA = "0xF42A58", Offset = "0xF42A58", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv21 = v16;\n\tv22 = 0xB348B0(v21, match, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0016:\n\tgoto L_001D;\n\tv42 = v37;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v42, match, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001D:\n\tSpine.ExposedList`1<T>::CheckMatch(match);\n\treturnVal1 = Spine.ExposedList`1<T>::FindAllList(this, match);\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ExposedList<T> FindAll(Predicate<T> match)
		{
			CheckMatch(match);
			return FindAll(match);
		}

		[Token(Token = "0x600028B")]
		[Address(RVA = "0xF42AD0", Offset = "0xF42AD0", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv27 = v22;\n\tv28 = 0xB348B0(v27, match, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = v28;\nL_0017:\n\tv46 = new Il2CppClass<Spine.ExposedList`1<T>>();\n\tSpine.ExposedList`1<T>::.ctor(v46);\n\tv62 = this.Count < 1;\n\tif (v62) goto L_0072;\nL_002B:\n\tv123 = this.Items;\n\tv194 = System.Predicate`1<T>::Invoke(match, *([v123 @ X8_v10 (T[])+v108 @ X23_v4 (System.Int32)]));\n\tv207 = v194 & 1;\n\tv208 = v207 == 0;\n\tif (v208) goto L_005B;\n\tv202 = this.Items;\n\tSpine.ExposedList`1<T>::Add(v46, *([v202 @ X8_v16 (T[])+v108 @ X23_v4 (System.Int32)]));\nL_005B:\n\tv95 = v108 - 0x1F;\n\tv108 = v108 + 1;\n\tv71 = v95 < this.Count;\n\tif (v71) goto L_002B;\nL_0072:\n\treturn v46;\n\tv203 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ExposedList<T> FindAllList(Predicate<T> match)
		{
			//IL_0028: Expected O, but got I
			//IL_002c: Expected O, but got I4
			//IL_007c: Expected O, but got I
			ExposedList<T> exposedList = new ExposedList<T>();
			if (Count >= 1)
			{
				int num = 32;
				int num2;
				do
				{
					T[] items = Items;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ X8_v10 (T[])+v108 @ X23_v4 (System.Int32)]");
					object obj = match((T)0);
					if ((int)((nint)obj & 1) != 0)
					{
						T[] items2 = Items;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ X8_v16 (T[])+v108 @ X23_v4 (System.Int32)]");
						exposedList.Add((T)0);
					}
					num2 = num - 31;
					num++;
				}
				while (num2 < Count);
			}
			return exposedList;
		}

		[Token(Token = "0x600028C")]
		[Address(RVA = "0xF42BD0", Offset = "0xF42BD0", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv21 = v16;\n\tv22 = 0xB348B0(v21, match, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0016:\n\tgoto L_001D;\n\tv42 = v37;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v42, match, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001D:\n\tSpine.ExposedList`1<T>::CheckMatch(match);\n\treturnVal1 = Spine.ExposedList`1<T>::GetIndex(this, 0, this.Count, match);\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int FindIndex(Predicate<T> match)
		{
			CheckMatch(match);
			return GetIndex(0, Count, match);
		}

		[Token(Token = "0x600028D")]
		[Address(RVA = "0xF42C50", Offset = "0xF42C50", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv25 = v20;\n\tv26 = 0xB348B0(v25, startIndex, match, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0018:\n\tgoto L_001F;\n\tv45 = v40;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v45, startIndex, match, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_001F:\n\tSpine.ExposedList`1<T>::CheckMatch(match);\n\tSpine.ExposedList`1<T>::CheckIndex(this, startIndex);\n\tv62 = this.Count - startIndex;\n\treturnVal1 = Spine.ExposedList`1<T>::GetIndex(this, startIndex, v62, match);\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int FindIndex(int startIndex, Predicate<T> match)
		{
			CheckMatch(match);
			CheckIndex(startIndex);
			int count = Count - startIndex;
			return GetIndex(startIndex, count, match);
		}

		[Token(Token = "0x600028E")]
		[Address(RVA = "0xF42CF8", Offset = "0xF42CF8", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv29 = v24;\n\tv30 = 0xB348B0(v29, startIndex, count, match, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_001A:\n\tgoto L_0021;\n\tv48 = v43;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v48, startIndex, count, match, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0021:\n\tSpine.ExposedList`1<T>::CheckMatch(match);\n\tSpine.ExposedList`1<T>::CheckRange(this, startIndex, count);\n\treturnVal1 = Spine.ExposedList`1<T>::GetIndex(this, startIndex, count, match);\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			CheckMatch(match);
			CheckRange(startIndex, count);
			return GetIndex(startIndex, count, match);
		}

		[Token(Token = "0x600028F")]
		[Address(RVA = "0xF42DA4", Offset = "0xF42DA4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = count + startIndex;\n\tv24 = v10 <= startIndex;\n\tif (v24) goto L_FFFFFFFF;\nL_0028:\n\tv67 = this.Items + v93;\n\tv36 = System.Predicate`1<T>::Invoke(match, *([v67 @ X8_v6+20]));\n\tv179 = v36 & 1;\n\tv180 = v179 == 0;\n\tv38 = ~v180;\n\tif (v38) goto L_0046;\n\tv93 = v93 + 1;\n\tv49 = v10 != v93;\n\tif (v49) goto L_0028;\nL_0046:\n\treturn v93;\n\tv133 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private int GetIndex(int startIndex, int count, Predicate<T> match)
		{
			//IL_0049: Expected O, but got I
			//IL_005e: Expected O, but got I
			//IL_0062: Expected O, but got I4
			int num = count + startIndex;
			if (num <= startIndex)
			{
				goto IL_00c6;
			}
			int num2 = startIndex;
			while (true)
			{
				object obj = (nint)Items + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X8_v6+20]");
				object obj2 = match((T)0);
				if ((int)((nint)obj2 & 1) != 0)
				{
					break;
				}
				num2++;
				if (num != num2)
				{
					continue;
				}
				goto IL_00c6;
			}
			goto IL_00d4;
			IL_00d4:
			return num2;
			IL_00c6:
			num2 = -1;
			goto IL_00d4;
		}

		[Token(Token = "0x6000290")]
		[Address(RVA = "0xF42E2C", Offset = "0xF42E2C", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv21 = v16;\n\tv22 = 0xB348B0(v21, match, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0016:\n\tgoto L_001D;\n\tv42 = v37;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v42, match, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001D:\n\tSpine.ExposedList`1<T>::CheckMatch(match);\n\tv56 = Spine.ExposedList`1<T>::GetLastIndex(this, 0, this.Count, match);\n\tv57 = v56 + 1;\n\tv59 = v57 == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tv109 = this.Items + v56;\n\tv96 = *([v109 @ X8_v11+20]) == 0;\n\tv78 = ~v96;\n\tgoto L_004E;\nL_004E:\n\treturn returnVal1;\n\tv75 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T FindLast(Predicate<T> match)
		{
			//IL_0067: Expected O, but got I
			//IL_0091: Expected O, but got I4
			CheckMatch(match);
			int lastIndex = GetLastIndex(0, Count, match);
			if (lastIndex + 1 != 0)
			{
				object obj = (nint)Items + lastIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X8_v11+20]");
				bool flag = (nint)0 == 0;
				bool flag2 = !flag;
				return (T)flag2;
			}
			return (T)null;
		}

		[Token(Token = "0x6000291")]
		[Address(RVA = "0xF42EEC", Offset = "0xF42EEC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv21 = v16;\n\tv22 = 0xB348B0(v21, match, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0016:\n\tgoto L_001D;\n\tv42 = v37;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v42, match, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001D:\n\tSpine.ExposedList`1<T>::CheckMatch(match);\n\treturnVal1 = Spine.ExposedList`1<T>::GetLastIndex(this, 0, this.Count, match);\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int FindLastIndex(Predicate<T> match)
		{
			CheckMatch(match);
			return GetLastIndex(0, Count, match);
		}

		[Token(Token = "0x6000292")]
		[Address(RVA = "0xF42F6C", Offset = "0xF42F6C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv25 = v20;\n\tv26 = 0xB348B0(v25, startIndex, match, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0018:\n\tgoto L_001F;\n\tv45 = v40;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v45, startIndex, match, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_001F:\n\tSpine.ExposedList`1<T>::CheckMatch(match);\n\tSpine.ExposedList`1<T>::CheckIndex(this, startIndex);\n\tv58 = startIndex + 1;\n\treturnVal1 = Spine.ExposedList`1<T>::GetLastIndex(this, 0, v58, match);\n\treturn returnVal1;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int FindLastIndex(int startIndex, Predicate<T> match)
		{
			CheckMatch(match);
			CheckIndex(startIndex);
			int count = startIndex + 1;
			return GetLastIndex(0, count, match);
		}

		[Token(Token = "0x6000293")]
		[Address(RVA = "0xF43010", Offset = "0xF43010", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv29 = v24;\n\tv30 = 0xB348B0(v29, startIndex, count, match, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_001A:\n\tgoto L_0021;\n\tv48 = v43;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v48, startIndex, count, match, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0021:\n\tSpine.ExposedList`1<T>::CheckMatch(match);\n\tv60 = startIndex - count;\n\tv61 = v60 + 1;\n\tSpine.ExposedList`1<T>::CheckRange(this, v61, count);\n\treturnVal1 = Spine.ExposedList`1<T>::GetLastIndex(this, v61, count, match);\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int FindLastIndex(int startIndex, int count, Predicate<T> match)
		{
			CheckMatch(match);
			int num = startIndex - count;
			int num2 = num + 1;
			CheckRange(num2, count);
			return GetLastIndex(num2, count, match);
		}

		[Token(Token = "0x6000294")]
		[Address(RVA = "0xF430C4", Offset = "0xF430C4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv106 = count + startIndex;\nL_000A:\n\tv61 = v59 == 0;\n\tif (v61) goto L_FFFFFFFF;\n\tv106 = v106 - 1;\n\tv56 = this.Items + v106;\n\tv23 = System.Predicate`1<T>::Invoke(match, *([v56 @ X8_v4+20]));\n\tv59 = v59 - 1;\n\tv147 = v23 & 1;\n\tv53 = v147 == 0;\n\tif (v53) goto L_000A;\n\tgoto L_0030;\nL_0030:\n\treturn v106;\n\tv79 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private int GetLastIndex(int startIndex, int count, Predicate<T> match)
		{
			//IL_003d: Expected O, but got I
			//IL_0052: Expected O, but got I
			//IL_0056: Expected O, but got I4
			int num = count + startIndex;
			int num2 = count;
			object obj2;
			do
			{
				if (num2 != 0)
				{
					num--;
					object obj = (nint)Items + num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v4+20]");
					obj2 = match((T)0);
					num2--;
					continue;
				}
				num = -1;
				break;
			}
			while ((int)((nint)obj2 & 1) == 0);
			return num;
		}

		[Token(Token = "0x6000295")]
		[Address(RVA = "0xF43144", Offset = "0xF43144", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = action == 0;\n\tif (v8) goto L_0046;\n\tv23 = this.Count < 1;\n\tif (v23) goto L_003F;\nL_0017:\n\tv70 = this.Items;\n\tSystem.Action`1<T>::Invoke(action, *([v70 @ X8_v5 (T[])+v38 @ X21_v5 (System.Int32)]));\n\tv101 = v38 - 0x1F;\n\tv38 = v38 + 1;\n\tv106 = v101 < this.Count;\n\tif (v106) goto L_0017;\nL_003F:\n\treturn;\n\tv181 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0046:\n\tv130 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v130, \"action\");\n\tthrow v130;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ForEach(Action<T> action)
		{
			//IL_005f: Expected O, but got I
			if (action != null)
			{
				if (Count >= 1)
				{
					int num = 32;
					int num2;
					do
					{
						T[] items = Items;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X8_v5 (T[])+v38 @ X21_v5 (System.Int32)]");
						action((T)0);
						num2 = num - 31;
						num++;
					}
					while (num2 < Count);
				}
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("action");
			throw ex;
		}

		[Token(Token = "0x6000296")]
		[Address(RVA = "0xF431FC", Offset = "0xF431FC", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([v0 @ X8 (Spine.ExposedList`1<T>+Enumerator<T>)]) = 0;\n\t*([v0 @ X8 (Spine.ExposedList`1<T>+Enumerator<T>)+8]) = 0;\n\tv0.l = 0;\n\tSpine.ExposedList`1<T>+Enumerator<T>::.ctor(v0, this);\n\treturn v0;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe Enumerator GetEnumerator()
		{
			//IL_0009: Expected O, but got I4
			//IL_0014: Expected native int or pointer, but got O
			//IL_001e: Expected native int or pointer, but got O
			Enumerator enumerator = (Enumerator)0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write(&((Enumerator*)(nint)enumerator)->l, null);
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)enumerator, new Enumerator(this));
			return enumerator;
		}

		[Token(Token = "0x6000297")]
		[Address(RVA = "0xF4321C", Offset = "0xF4321C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.ExposedList`1<T>::CheckRange(this, index, count);\n\tgoto L_0018;\n\tv28 = Spine.ExposedList`1<T>::CheckRange(v23, index, count, v20);\nL_0018:\n\t// 24 NewArr v43 @ X0_v3 (Il2CppClass<T[]>), typeof(Il2CppClass<T[]>), count @ X2 (System.Int32)\n\tSystem.Array::Copy(this.Items, index, v43, 0, count);\n\tgoto L_002B;\n\tv59 = 0xB348B0(v54, v46, v47, v49, v50, v51, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_002B:\n\tv61 = new Il2CppClass<Spine.ExposedList`1<T>>();\n\tSystem.Object::.ctor(v61);\n\t*([v61 @ X0_v7 (System.Object)+10]) = v43;\n\t*([v61 @ X0_v7 (System.Object)+18]) = count;\n\treturn v61;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ExposedList<T> GetRange(int index, int count)
		{
			//IL_0018: Expected I, but got O
			//IL_0034: Expected O, but got I
			CheckRange(index, count);
			nint num = unchecked((nint)null);
			Array.Copy(Items, index, (Array)num, 0, count);
			return null;
		}

		[Token(Token = "0x6000298")]
		[Address(RVA = "0xF432D0", Offset = "0xF432D0", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = item & 1;\n\treturnVal1 = System.Array::IndexOf(this.Items, v4, 0, this.Count);\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int IndexOf(T item)
		{
			bool value = (byte)((nint)item & 1) != 0;
			return Array.IndexOf((bool[])(object)Items, value, 0, Count);
		}

		[Token(Token = "0x6000299")]
		[Address(RVA = "0xF432F4", Offset = "0xF432F4", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.ExposedList`1<T>::CheckIndex(this, index);\n\tv25 = item & 1;\n\tv27 = this.Count - index;\n\treturnVal1 = System.Array::IndexOf(this.Items, v25, index, v27);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int IndexOf(T item, int index)
		{
			CheckIndex(index);
			bool value = (byte)((nint)item & 1) != 0;
			int count = Count - index;
			return Array.IndexOf((bool[])(object)Items, value, index, count);
		}

		[Token(Token = "0x600029A")]
		[Address(RVA = "0xF43354", Offset = "0xF43354", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = index & 0x80000000;\n\tv8 = v6 == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_0029;\n\tv10 = count & 0x80000000;\n\tv12 = v10 == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_0032;\n\tv33 = count + index;\n\tv34 = v33 < this.Count;\n\tv35 = ~v34;\n\tv36 = v33 - this.Count;\n\tv38 = v36 == 0;\n\tv43 = ~v38;\n\tv44 = v35 & v43;\n\tif (v44) goto L_003B;\n\tv54 = item & 1;\n\treturnVal1 = System.Array::IndexOf(this.Items, v54, index, count);\n\treturn returnVal1;\nL_0029:\n\tv49 = new System.ArgumentOutOfRangeException();\n\tgoto L_0043;\nL_0032:\n\tv63 = new System.ArgumentOutOfRangeException();\n\tgoto L_0043;\nL_003B:\n\tv67 = new System.ArgumentOutOfRangeException();\nL_0043:\n\tSystem.ArgumentOutOfRangeException::.ctor(v72, v74);\n\tthrow v72;\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int IndexOf(T item, int index, int count)
		{
			//IL_0012: Expected I4, but got I8
			//IL_004c: Expected I4, but got I8
			ArgumentOutOfRangeException ex2;
			if ((int)(index & 0x80000000L) == 0)
			{
				if ((int)(count & 0x80000000L) == 0)
				{
					int num = count + index;
					bool flag = num < Count;
					bool flag2 = !flag;
					int num2 = num - Count;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						bool value = (byte)((nint)item & 1) != 0;
						return Array.IndexOf((bool[])(object)Items, value, index, count);
					}
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
					ex2 = ex;
					string text = "index and count exceed length of list";
				}
				else
				{
					ArgumentOutOfRangeException ex3 = new ArgumentOutOfRangeException();
					ex2 = ex3;
					string text = "count";
				}
			}
			else
			{
				ArgumentOutOfRangeException ex4 = new ArgumentOutOfRangeException();
				ex2 = ex4;
				string text = "index";
			}
			throw ex2;
		}

		[Token(Token = "0x600029B")]
		[Address(RVA = "0xF4341C", Offset = "0xF4341C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv50 = this.Count;\n\tv19 = delta < 0;\n\tif (v19) goto L_FFFFFFFF;\n\tgoto L_0015;\nL_0015:\n\tv23 = start - v22;\n\tv36 = v50 - v23;\n\tv39 = v50 <= v23;\n\tif (v39) goto L_002C;\n\tv41 = v23 + delta;\n\tSystem.Array::Copy(this.Items, v23, this.Items, v41, v36);\n\tv50 = this.Count;\nL_002C:\n\tv52 = v50 + delta;\n\tthis.Count = v52;\n\tv53 = delta & 0x80000000;\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0038;\n\treturn;\nL_0038:\n\tv60 = 0 - delta;\n\tSystem.Array::Clear(this.Items, v52, v60);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Shift(int start, int delta)
		{
			//IL_0100: Expected I4, but got I8
			int count = Count;
			int num = ((delta < 0) ? delta : 0);
			int num2 = start - num;
			int length = count - num2;
			if (count > num2)
			{
				int destinationIndex = num2 + delta;
				Array.Copy(Items, num2, Items, destinationIndex, length);
				count = Count;
			}
			int index = (Count = count + delta);
			if ((int)(delta & 0x80000000L) != 0)
			{
				int length2 = -delta;
				Array.Clear(Items, index, length2);
			}
		}

		[Token(Token = "0x600029C")]
		[Address(RVA = "0xF4348C", Offset = "0xF4348C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = index & 0x80000000;\n\tv8 = v6 == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_001D;\n\tv12 = this.Count < index;\n\tv13 = ~v12;\n\tv21 = ~v13;\n\tif (v21) goto L_001D;\n\treturn;\nL_001D:\n\tv63 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v63, \"index\");\n\tthrow v63;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CheckIndex(int index)
		{
			//IL_0012: Expected I4, but got I8
			if ((int)(index & 0x80000000L) == 0 && Count >= index)
			{
				return;
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("index");
			throw ex;
		}

		[Token(Token = "0x600029D")]
		[Address(RVA = "0xF434F0", Offset = "0xF434F0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.ExposedList`1<T>::CheckIndex(this, index);\n\tv21 = this.Items;\n\tv34 = this.Count != v21.Length;\n\tif (v34) goto L_0027;\n\tSpine.ExposedList`1<T>::GrowIfNeeded(this, 1);\nL_0027:\n\tSpine.ExposedList`1::Shift /* +1 sharing this address */(this, index, 1, methodInfo);\n\tv129 = item & 1;\n\tv142 = this.Items + index;\n\t*([v142 @ X8_v9+20]) = v129;\n\tv141 = this.version + 1;\n\tthis.version = v141;\n\treturn;\n\tv65 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Insert(int index, T item)
		{
			//IL_007a: Expected O, but got I
			CheckIndex(index);
			T[] items = Items;
			if (Count == items.Length)
			{
				GrowIfNeeded(1);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F4741C (Spine.ExposedList`1::Shift, and 1 more at this address)");
			int num = (int)((nint)item & 1);
			object obj = (nint)Items + index;
			int num2 = version + 1;
			version = num2;
		}

		[Token(Token = "0x600029E")]
		[Address(RVA = "0xF435A0", Offset = "0xF435A0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = collection == 0;\n\tif (v0) goto L_000B;\n\treturn;\nL_000B:\n\tv42 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v42, \"collection\");\n\tthrow v42;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CheckCollection(IEnumerable<T> collection)
		{
			if (collection != null)
			{
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("collection");
			throw ex;
		}

		[Token(Token = "0x600029F")]
		[Address(RVA = "0xF435F0", Offset = "0xF435F0", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.ExposedList`1<T>::CheckCollection(this, collection);\n\tSpine.ExposedList`1<T>::CheckIndex(this, index);\n\tv31 = this == collection;\n\tif (v31) goto L_003E;\n\tgoto L_002B;\n\tv51 = v38;\n\tv52 = 0xB348B0(v51, v38, v26, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv67 = v52;\nL_002B:\n\t// 43 IsInst v69 @ X0_v14 (System.Collections.Generic.ICollection`1<T>), typeof(System.Collections.Generic.ICollection`1<T>), collection @ X2 (System.Collections.Generic.IEnumerable`1<T>)\n\tv76 = v69 == 0;\n\tif (v76) goto L_0063;\n\tSpine.ExposedList`1<T>::InsertCollection(this, index, v69);\n\tgoto L_0067;\nL_003E:\n\tgoto L_0041;\n\tv70 = 0xB348B0(v46, v24, v26, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\nL_0041:\n\t// 65 NewArr v73 @ X0_v5 (Il2CppClass<T[]>), typeof(Il2CppClass<T[]>), this.Count (System.Int32)\n\tSystem.Array::Copy(this.Items, 0, v73, 0, this.Count);\n\tSpine.ExposedList`1<T>::GrowIfNeeded(this, this.Count);\n\tSpine.ExposedList`1::Shift /* +1 sharing this address */(this, index, *([v73 @ X0_v5 (Il2CppClass<T[]>)+18]), 0);\n\tSystem.Array::Copy(v73, 0, this.Items, index, *([v73 @ X0_v5 (Il2CppClass<T[]>)+18]));\n\tgoto L_0067;\nL_0063:\n\tSpine.ExposedList`1<T>::InsertEnumeration(this, index, collection);\nL_0067:\n\tv117 = this.version + 1;\n\tthis.version = v117;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void InsertRange(int index, IEnumerable<T> collection)
		{
			//IL_0054: Expected I, but got O
			//IL_0073: Expected O, but got I
			//IL_00b7: Expected O, but got I
			CheckCollection(collection);
			CheckIndex(index);
			if (this == collection)
			{
				nint num = unchecked((nint)null);
				Array.Copy(Items, 0, (Array)num, 0, Count);
				GrowIfNeeded(Count);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F4741C (Spine.ExposedList`1::Shift, and 1 more at this address)");
				T[] items = Items;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X0_v5 (Il2CppClass<T[]>)+18]");
				Array.Copy((Array)num, 0, items, index, 0);
			}
			else
			{
				ICollection<T> collection2 = collection as ICollection<T>;
				if (collection2 != null)
				{
					InsertCollection(index, collection2);
				}
				else
				{
					InsertEnumeration(index, collection);
				}
			}
			int num2 = version + 1;
			version = num2;
		}

		[Token(Token = "0x60002A0")]
		[Address(RVA = "0xF43754", Offset = "0xF43754", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv41 = v23;\n\tv42 = 0xB348B0(v41, v23, collection, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv45 = v42;\nL_0018:\n\tv46 = collection->klass;\n\tv146 = collection->klass->interface_offsets_count;\n\tv48 = *([v46 @ X8_v4 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]) == 0;\n\tif (v48) goto L_FFFFFFFF;\n\tv155 = *([v46 @ X8_v4 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+B0]) + 8;\nL_0023:\n\tv160 = *([v155 @ X10_v11-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v160) goto L_003B;\n\tv58 = v146 - 1;\n\tv155 = v155 + 0x10;\n\tv55 = v146 != 1;\n\tif (v55) goto L_0023;\n\tgoto L_0041;\nL_003B:\n\t;\nL_0041:\n\tv189 = System.Collections.Generic.ICollection`1<T>::get_Count(collection);\n\tSpine.ExposedList`1<T>::GrowIfNeeded(this, v189);\n\tSpine.ExposedList`1::Shift /* +1 sharing this address */(this, index, v189, methodInfo);\n\tv200 = this.Items;\n\tgoto L_0059;\n\tv207 = v202;\n\tv208 = 0xB348B0(v207, v202, v198, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv211 = v208;\nL_0059:\n\tv212 = collection->klass;\n\tv245 = collection->klass->interface_offsets_count;\n\tv143 = *([v212 @ X8_v12 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]) == 0;\n\tif (v143) goto L_0079;\n\tv254 = *([v212 @ X8_v12 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+B0]) + 8;\nL_0064:\n\tv259 = *([v254 @ X10_v6-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v259) goto L_007C;\n\tv221 = v245 - 1;\n\tv254 = v254 + 0x10;\n\tv219 = v245 != 1;\n\tif (v219) goto L_0064;\nL_0079:\n\tv271 = 0xB349B4(collection, Il2CppClass<System.Collections.Generic.ICollection`1<T>>, 5, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0080;\nL_007C:\n\tv266 = *([v254 @ X10_v6]) + 5;\n\tv267 = v266 << 4;\n\tv268 = v212 + v267;\n\tv271 = v268 + 0x138;\nL_0080:\n\tv94 = *([v271 @ X0_v9]);\n\tv92 = *([v271 @ X0_v9+8]);\n\t// 140 IndirectJump v94 @ X4_v1, collection @ X2 (System.Collections.Generic.ICollection`1<T>), collection @ X2 (System.Collections.Generic.ICollection`1<T>), v200 @ X21_v2 (T[]), index @ X1 (System.Int32), v92 @ X3_v1, v94 @ X4_v1, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InsertCollection(int index, ICollection<T> collection)
		{
			//IL_012c: Expected I, but got O
			//IL_013c: Expected O, but got I
			//IL_001b: Expected O, but got I
			//IL_01bb: Expected I, but got O
			//IL_01cb: Expected O, but got I
			//IL_022a: Expected O, but got I
			//IL_008b: Expected O, but got I
			//IL_002f: Expected O, but got I
			//IL_003e: Expected O, but got I
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_0110: Expected O, but got I
			//IL_011f: Expected O, but got I
			//IL_009f: Expected O, but got I
			//IL_00ae: Expected O, but got I
			nint num = (nint)collection;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v4 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v4 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v4 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+B0]");
				object obj2 = (nint)0 + (nint)8;
				bool flag;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X10_v11-8]");
					if ((nint)0 != 0)
					{
						object obj3 = (nint)obj - 1;
						obj2 = (nint)obj2 + 16;
						flag = (nint)obj != 1;
						obj = obj3;
						continue;
					}
					break;
				}
				while (flag);
			}
			int count = collection.Count;
			GrowIfNeeded(count);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F4741C (Spine.ExposedList`1::Shift, and 1 more at this address)");
			T[] items = Items;
			nint num2 = (nint)collection;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ X8_v12 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ X8_v12 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]");
			if ((nint)0 == 0)
			{
				goto IL_00d6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ X8_v12 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+B0]");
			object obj5 = (nint)0 + (nint)8;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ X10_v6-8]");
				if ((nint)0 == 0)
				{
					break;
				}
				object obj6 = (nint)obj4 - 1;
				obj5 = (nint)obj5 + 16;
				bool flag2 = (nint)obj4 != 1;
				obj4 = obj6;
				if (flag2)
				{
					continue;
				}
				goto IL_00d6;
			}
			object obj7 = obj5 + 5;
			int num3 = (int)((nint)obj7 << 4);
			object obj8 = num2 + num3;
			object obj9 = (nint)obj8 + 312;
			goto IL_0212;
			IL_00d6:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B349B4");
			goto IL_0212;
			IL_0212:
			object obj10 = obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ X0_v9+8]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v94 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60002A1")]
		[Address(RVA = "0xF438A8", Offset = "0xF438A8", Length = "0x308")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv30 = System.IDisposable;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, index, enumerable, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv50 = System.Collections.IEnumerator;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, index, enumerable, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A35BCE]) = v47;\nL_0024:\n\tgoto L_0028;\n\tv59 = v53;\n\tv60 = 0xB348B0(v59, v53, enumerable, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv62 = v60;\nL_0028:\n\tv64 = enumerable->klass;\n\tv206 = enumerable->klass->interface_offsets_count;\n\tv66 = *([v64 @ X8_v19 (Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>)+12E]) == 0;\n\tif (v66) goto L_FFFFFFFF;\n\tv215 = *([v64 @ X8_v19 (Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>)+B0]) + 8;\nL_0033:\n\tv220 = *([v215 @ X10_v35-8]) == Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>;\n\tif (v220) goto L_004B;\n\tv128 = v206 - 1;\n\tv215 = v215 + 0x10;\n\tv126 = v206 != 1;\n\tif (v126) goto L_0033;\n\tgoto L_0053;\nL_004B:\n\t;\nL_0053:\n\tv111 = System.Collections.Generic.IEnumerable`1<T>::GetEnumerator(enumerable);\nL_005D:\n\tgoto L_0083;\n\tv299 = *([v292 @ X8_v23+B0]);\n\tv300 = v299 + 8;\n\tv302 = *([v380 @ X10_v30-8]);\n\tv385 = v302 == v293;\n\tif (v385) goto L_007C;\n\tv306 = v371 - 1;\n\tv324 = v380 + 0x10;\n\tv304 = v371 != 1;\n\tif (v304) goto L_FFFFFFFF;\n\tv325 = v115;\n\tv326 = 0;\n\tv327 = 0xB349B4(v325, v293, v326, v250, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0083;\nL_007C:\n\tv463 = *([v380 @ X10_v30]);\n\tv464 = v463 << 4;\n\tv465 = v292 + v464;\n\tv466 = v465 + 0x138;\nL_0083:\n\tv421 = System.Collections.IEnumerator::MoveNext(v111);\n\tv423 = v421 == 0;\n\tif (v423) goto L_FFFFFFFF;\n\tgoto L_0092;\n\tv568 = v518;\n\tv569 = 0xB348B0(v568, v518, v395, v250, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv571 = v569;\nL_0092:\n\tv573 = *([v111 @ X0_v35 (System.Collections.IEnumerator)]);\n\tv662 = *([v573 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+12E]);\n\tv287 = *([v573 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+12E]) == 0;\n\tif (v287) goto L_FFFFFFFF;\n\tv671 = *([v573 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_009D:\n\tv676 = *([v671 @ X10_v25-8]) == Il2CppClass<System.Collections.Generic.IEnumerator`1<T>>;\n\tif (v676) goto L_00B5;\n\tv630 = v662 - 1;\n\tv671 = v671 + 0x10;\n\tv628 = v662 != 1;\n\tif (v628) goto L_009D;\n\tgoto L_00BB;\nL_00B5:\n\t;\nL_00BB:\n\tv692 = System.Collections.Generic.IEnumerator`1<T>::get_Current(v111);\n\tv255 = v288 + 1;\n\tv259 = v692 & 1;\n\tSpine.ExposedList`1<T>::Insert(this, v288, v259);\n\tgoto L_005D;\nL_00C7:\n\tv427 = v195 == 0;\n\tif (v427) goto L_00F4;\n\tv471 = *([v195 @ X19_v2 (System.Collections.IEnumerator)]);\n\tv577 = *([v471 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+12E]);\n\tv474 = *([v471 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+12E]) == 0;\n\tif (v474) goto L_00EA;\n\tv586 = *([v471 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_00D5:\n\tv591 = *([v586 @ X10_v7-8]) == *([v201 @ X23_v2 (Il2CppClass<System.IDisposable>)]);\n\tif (v591) goto L_00ED;\n\tv530 = v577 - 1;\n\tv586 = v586 + 0x10;\n\tv528 = v577 != 1;\n\tif (v528) goto L_00D5;\nL_00EA:\n\t;\n\tgoto L_00F3;\nL_00ED:\n\t;\nL_00F3:\n\tv490 = System.IDisposable::Dispose(v195);\nL_00F4:\n\tv493 = v197 == 0;\n\tv189 = ~v493;\n\tif (v189) goto L_0104;\n\treturn;\n\tv58 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0104:\n\tv203 = new System.OutOfMemoryException();\n\tgoto L_0112;\n\tgoto L_0112;\n\tgoto L_0112;\nL_0112:\n\tv244 = v360 != 1;\n\tif (v244) goto L_011A;\n\tv248 = 0x1854E70(v203, v360, v336, v150, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv197 = *([v248 @ X0_v27]);\n\tv297 = 0x1854E80(v248, v360, v336, v150, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00C7;\nL_011A:\n\tgoto L_011C;\n\tX21 = X0;\nL_011C:\n\tv298 = v194 == 0;\n\tif (v298) goto L_014B;\n\tv328 = *([v194 @ X19_v4 (System.Collections.IEnumerator)]);\n\tv496 = *([v328 @ X8_v11 (Il2CppClass<System.Collections.IEnumerator>)+12E]);\n\tv331 = *([v328 @ X8_v11 (Il2CppClass<System.Collections.IEnumerator>)+12E]) == 0;\n\tif (v331) goto L_013F;\n\tv505 = *([v328 @ X8_v11 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_012A:\n\tv510 = *([v505 @ X10_v15-8]) == *([v200 @ X23_v4 (Il2CppClass<System.IDisposable>)]);\n\tif (v510) goto L_0142;\n\tv435 = v496 - 1;\n\tv505 = v505 + 0x10;\n\tv433 = v496 != 1;\n\tif (v433) goto L_012A;\nL_013F:\n\t;\n\tgoto L_0148;\nL_0142:\n\tv562 = *([v505 @ X10_v15]) << 4;\n\tv563 = v328 + v562;\n\tv565 = v563 + 0x138;\nL_0148:\n\tv363 = System.IDisposable::Dispose(v194);\nL_014B:\n\tgoto L_014F;\n\tv458 = 0xBD3CD0(v203, *([v565 @ X0_v20+8]), 0, v150, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_014F:\n\tv461 = new System.OutOfMemoryException();\n\tv515 = 0x9DACB4(v461, *([v565 @ X0_v20+8]), 0, v150, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn;\n// 211 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InsertEnumeration(int index, IEnumerable<T> enumerable)
		{
			//IL_033f: Expected I, but got O
			//IL_034f: Expected O, but got I
			//IL_0020: Expected O, but got I
			//IL_0034: Expected O, but got I
			//IL_0043: Expected O, but got I
			//IL_011d: Expected I, but got O
			//IL_03da: Expected I, but got O
			//IL_03ea: Expected O, but got I
			//IL_012a: Expected I, but got O
			//IL_013a: Expected O, but got I
			//IL_0469: Expected O, but got I4
			//IL_00a3: Expected O, but got I
			//IL_0175: Expected O, but got I
			//IL_0210: Expected I4, but got O
			//IL_00b7: Expected O, but got I
			//IL_00c6: Expected O, but got I
			//IL_0243: Expected I, but got O
			//IL_0253: Expected O, but got I
			//IL_0189: Expected O, but got I
			//IL_0198: Expected O, but got I
			//IL_028e: Expected O, but got I
			//IL_02ed: Expected I4, but got O
			//IL_02fb: Expected O, but got I
			//IL_030a: Expected O, but got I
			//IL_02a2: Expected O, but got I
			//IL_02b1: Expected O, but got I
			nint num = (nint)enumerable;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X8_v19 (Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>)+12E]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X8_v19 (Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>)+12E]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X8_v19 (Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>)+B0]");
				object obj2 = (nint)0 + (nint)8;
				bool flag;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ X10_v35-8]");
					if ((nint)0 != 0)
					{
						object obj3 = (nint)obj - 1;
						obj2 = (nint)obj2 + 16;
						flag = (nint)obj != 1;
						obj = obj3;
						continue;
					}
					break;
				}
				while (flag);
			}
			IEnumerator enumerator = enumerable.GetEnumerator();
			int num2 = index;
			while (enumerator.MoveNext())
			{
				nint num3 = (nint)enumerator;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj5 = (nint)0 + (nint)8;
					bool flag2;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v671 @ X10_v25-8]");
						if ((nint)0 != 0)
						{
							object obj6 = (nint)obj4 - 1;
							obj5 = (nint)obj5 + 16;
							flag2 = (nint)obj4 != 1;
							obj4 = obj6;
							continue;
						}
						break;
					}
					while (flag2);
				}
				object current = ((IEnumerator<T>)enumerator).Current;
				int num4 = num2 + 1;
				int num5 = (int)((nint)current & 1);
				Insert(num2, (T)num5);
				num2 = num4;
			}
			IEnumerator enumerator2 = enumerator;
			int num6 = 0;
			nint num7 = (nint)typeof(IDisposable);
			int num9 = default(int);
			object obj10 = default(object);
			IEnumerator enumerator3 = default(IEnumerator);
			IntPtr intPtr = default(IntPtr);
			while (true)
			{
				if (enumerator2 != null)
				{
					nint num8 = (nint)enumerator2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						object obj8 = (nint)0 + (nint)8;
						bool flag3;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ X10_v7-8]");
							if (0 != num7)
							{
								object obj9 = (nint)obj7 - 1;
								obj8 = (nint)obj8 + 16;
								flag3 = (nint)obj7 != 1;
								obj7 = obj9;
								continue;
							}
							break;
						}
						while (flag3);
					}
					((IDisposable)enumerator2).Dispose();
				}
				if (num6 == 0)
				{
					return;
				}
				OutOfMemoryException ex = new OutOfMemoryException();
				if (num9 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
					num6 = (int)obj10;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
					enumerator2 = enumerator3;
					num7 = intPtr;
					continue;
				}
				break;
			}
			if (enumerator3 != null)
			{
				nint num10 = (nint)enumerator3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X8_v11 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X8_v11 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X8_v11 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj12 = (nint)0 + (nint)8;
					bool flag4;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ X10_v15-8]");
						if ((IntPtr)0 != intPtr)
						{
							object obj13 = (nint)obj11 - 1;
							obj12 = (nint)obj12 + 16;
							flag4 = (nint)obj11 != 1;
							obj11 = obj13;
							continue;
						}
						int num11 = obj12 << 4;
						object obj14 = num10 + num11;
						object obj15 = (nint)obj14 + 312;
						break;
					}
					while (flag4);
				}
				((IDisposable)enumerator3).Dispose();
			}
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
		}

		[Token(Token = "0x60002A2")]
		[Address(RVA = "0xF43BB0", Offset = "0xF43BB0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = item & 1;\n\tv8 = this.Count - 1;\n\treturnVal1 = System.Array::LastIndexOf(this.Items, v5, v8, this.Count);\n\treturn returnVal1;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int LastIndexOf(T item)
		{
			//IL_0038: Expected O, but got I4
			int num = (int)((nint)item & 1);
			int startIndex = Count - 1;
			return Array.LastIndexOf(Items, (T)num, startIndex, Count);
		}

		[Token(Token = "0x60002A3")]
		[Address(RVA = "0xF43BD0", Offset = "0xF43BD0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.ExposedList`1<T>::CheckIndex(this, index);\n\tv24 = index + 1;\n\tv25 = item & 1;\n\treturnVal1 = System.Array::LastIndexOf(this.Items, v25, index, v24);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int LastIndexOf(T item, int index)
		{
			//IL_003e: Expected O, but got I4
			CheckIndex(index);
			int count = index + 1;
			int num = (int)((nint)item & 1);
			return Array.LastIndexOf(Items, (T)num, index, count);
		}

		[Token(Token = "0x60002A4")]
		[Address(RVA = "0xF43C2C", Offset = "0xF43C2C", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = index & 0x80000000;\n\tv12 = v10 == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_0028;\n\tv14 = count & 0x80000000;\n\tv16 = v14 == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_003C;\n\tv36 = index - count;\n\tv37 = v36 + 1;\n\tv38 = v37 < 0;\n\tif (v38) goto L_0050;\n\tv58 = item & 1;\n\treturnVal1 = System.Array::LastIndexOf(this.Items, v58, index, count);\n\treturn returnVal1;\nL_0028:\n\t// 40 Box v48 @ X0_v9 (System.Object), typeof(System.Int32), &index @ X2 (System.Int32)\n\tv78 = new System.ArgumentOutOfRangeException();\n\tgoto L_0063;\nL_003C:\n\t// 60 Box v67 @ X0_v22 (System.Object), typeof(System.Int32), &count @ X3 (System.Int32)\n\tv123 = new System.ArgumentOutOfRangeException();\n\tgoto L_0063;\nL_0050:\n\t// 80 Box v73 @ X0_v35 (System.Object), typeof(System.Int32), &count @ X3 (System.Int32)\n\tv128 = new System.ArgumentOutOfRangeException();\nL_0063:\n\tSystem.ArgumentOutOfRangeException::.ctor(v98, v100, v104, v145);\n\tthrow v98;\n\treturn returnVal2;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int LastIndexOf(T item, int index, int count)
		{
			//IL_0012: Expected I4, but got I8
			//IL_004c: Expected I4, but got I8
			//IL_00d2: Expected O, but got I4
			ArgumentOutOfRangeException ex2;
			if ((int)(index & 0x80000000L) == 0)
			{
				if ((int)(count & 0x80000000L) == 0)
				{
					int num = index - count;
					int num2 = num + 1;
					if (num2 >= 0)
					{
						int num3 = (int)((nint)item & 1);
						return Array.LastIndexOf(Items, (T)num3, index, count);
					}
					object obj = count;
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
					ex2 = ex;
					string text = "count";
					object obj2 = obj;
					string text2 = "count is too large";
				}
				else
				{
					object obj3 = count;
					ArgumentOutOfRangeException ex3 = new ArgumentOutOfRangeException();
					ex2 = ex3;
					string text = "count";
					object obj2 = obj3;
					string text2 = "count is negative";
				}
			}
			else
			{
				object obj4 = index;
				ArgumentOutOfRangeException ex4 = new ArgumentOutOfRangeException();
				ex2 = ex4;
				string text = "index";
				object obj2 = obj4;
				string text2 = "index is negative";
			}
			throw ex2;
		}

		[Token(Token = "0x60002A5")]
		[Address(RVA = "0xF43D8C", Offset = "0xF43D8C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = item & 1;\n\tv23 = System.Array::IndexOf(this.Items, v16, 0, this.Count);\n\tv25 = v23 + 1;\n\tv27 = v25 == 0;\n\tif (v27) goto L_0021;\n\tSpine.ExposedList`1<T>::RemoveAt(this, v23);\nL_0021:\n\tv41 = v23 + 1;\n\tv43 = v41 == 0;\n\tv46 = ~v43;\n\treturn v46;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Remove(T item)
		{
			bool value = (byte)((nint)item & 1) != 0;
			int num = Array.IndexOf((bool[])(object)Items, value, 0, Count);
			if (num + 1 != 0)
			{
				RemoveAt(num);
			}
			int num2 = num + 1;
			bool flag = num2 == 0;
			return !flag;
		}

		[Token(Token = "0x60002A6")]
		[Address(RVA = "0xF43E00", Offset = "0xF43E00", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv25 = v20;\n\tv26 = 0xB348B0(v25, match, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0018:\n\tgoto L_001F;\n\tv46 = v41;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v46, match, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_001F:\n\tSpine.ExposedList`1<T>::CheckMatch(match);\n\tv124 = this.Count;\n\tv64 = this.Count < 1;\n\tif (v64) goto L_FFFFFFFF;\nL_003E:\n\tv326 = this.Items + v284;\n\tv90 = System.Predicate`1<T>::Invoke(match, *([v326 @ X8_v23+20]));\n\tv328 = v90 & 1;\n\tv329 = v328 == 0;\n\tv92 = ~v329;\n\tif (v92) goto L_0059;\n\tv124 = this.Count;\n\tv284 = v284 + 1;\n\tv70 = v284 < this.Count;\n\tif (v70) goto L_003E;\n\tgoto L_0063;\n\tgoto L_0063;\nL_0059:\n\tv124 = this.Count;\nL_0063:\n\tv135 = v284 != v124;\n\tif (v135) goto L_0068;\n\tgoto L_00D8;\nL_0068:\n\tv252 = v284 + 1;\n\tv206 = this.version + 1;\n\tthis.version = v206;\n\tv207 = v252 >= v124;\n\tif (v207) goto L_00BD;\n\tv142 = v252 + 0x20;\nL_0078:\n\tv191 = this.Items;\n\tv179 = System.Predicate`1<T>::Invoke(match, *([v191 @ X8_v13 (T[])+v142 @ X23_v5 (System.Int32)]));\n\tv364 = v179 & 1;\n\tv365 = v364 == 0;\n\tv366 = ~v365;\n\tif (v366) goto L_00AF;\n\tv192 = this.Items;\n\tv367 = v322 + 1;\n\tv379 = this.Items + v322;\n\t*([v379 @ X8_v18+20]) = *([v192 @ X8_v17 (T[])+v142 @ X23_v5 (System.Int32)]);\nL_00AF:\n\tv252 = v144 + 1;\n\tv142 = v142 + 1;\n\tv301 = v252 < this.Count;\n\tif (v301) goto L_0078;\nL_00BD:\n\tv281 = v252 - v284;\n\tv256 = v281 < 1;\n\tif (v256) goto L_00CF;\n\tSystem.Array::Clear(this.Items, v284, v281);\nL_00CF:\n\tthis.Count = v284;\nL_00D8:\n\treturn v281;\n\tv193 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 165 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int RemoveAll(Predicate<T> match)
		{
			//IL_0055: Expected O, but got I
			//IL_006a: Expected O, but got I
			//IL_006e: Expected O, but got I4
			//IL_018a: Expected O, but got I
			//IL_018e: Expected O, but got I4
			//IL_01f2: Expected O, but got I
			CheckMatch(match);
			int count = Count;
			int num;
			if (Count >= 1)
			{
				num = 0;
				do
				{
					object obj = (nint)Items + num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ X8_v23+20]");
					object obj2 = match((T)0);
					if ((int)((nint)obj2 & 1) == 0)
					{
						count = Count;
						num++;
						continue;
					}
					count = Count;
					break;
				}
				while (num < Count);
			}
			else
			{
				num = 0;
			}
			int num2;
			if (num == count)
			{
				num2 = 0;
			}
			else
			{
				int num3 = num + 1;
				int num4 = version + 1;
				version = num4;
				if (num3 < count)
				{
					int num5 = num3 + 32;
					int num6 = num3;
					int num7 = num;
					bool flag;
					do
					{
						T[] items = Items;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X8_v13 (T[])+v142 @ X23_v5 (System.Int32)]");
						object obj3 = match((T)0);
						if ((int)((nint)obj3 & 1) == 0)
						{
							T[] items2 = Items;
							int num8 = num7 + 1;
							object obj4 = (nint)Items + num7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ X8_v17 (T[])+v142 @ X23_v5 (System.Int32)]");
							_ = 0;
							num7 = num8;
						}
						num3 = num6 + 1;
						num5++;
						flag = num3 < Count;
						num = num7;
						num6 = num3;
					}
					while (flag);
				}
				num2 = num3 - num;
				if (num2 >= 1)
				{
					Array.Clear(Items, num, num2);
				}
				Count = num;
			}
			return num2;
		}

		[Token(Token = "0x60002A7")]
		[Address(RVA = "0xF43FA4", Offset = "0xF43FA4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = index & 0x80000000;\n\tv8 = v6 == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_002A;\n\tv13 = this.Count < index;\n\tv14 = ~v13;\n\tv15 = this.Count - index;\n\tv17 = v15 == 0;\n\tv22 = ~v14;\n\tv23 = v22 | v17;\n\tif (v23) goto L_002A;\n\tSpine.ExposedList`1::Shift /* +1 sharing this address */(this, index, 0xFFFFFFFF, v50);\n\tSystem.Array::Clear(this.Items, this.Count, 1);\n\tv75 = this.version + 1;\n\tthis.version = v75;\n\treturn;\nL_002A:\n\tv65 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v65, \"index\");\n\tthrow v65;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveAt(int index)
		{
			//IL_0012: Expected I4, but got I8
			if ((int)(index & 0x80000000L) == 0)
			{
				bool flag = Count < index;
				bool flag2 = !flag;
				int num = Count - index;
				bool flag3 = num == 0;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F4741C (Spine.ExposedList`1::Shift, and 1 more at this address)");
					Array.Clear(Items, Count, 1);
					int num2 = version + 1;
					version = num2;
					return;
				}
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("index");
			throw ex;
		}

		[Token(Token = "0x60002A8")]
		[Address(RVA = "0xF44038", Offset = "0xF44038", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.Count == 0;\n\tif (v8) goto L_0027;\n\tv32 = this.Count - 1;\n\tv58 = this.Items + v32;\n\t*([v58 @ X9_v4+20]) = 0;\n\tv63 = this.version + 1;\n\tthis.Count = v32;\n\tthis.version = v63;\n\treturn *([v58 @ X9_v4+20]);\nL_0027:\n\tv57 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v57, \"List is empty. Nothing to pop.\");\n\tthrow v57;\n\tv56 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T Pop()
		{
			//IL_0044: Expected O, but got I
			//IL_007b: Expected O, but got I
			if (Count != 0)
			{
				int num = Count - 1;
				object obj = (nint)Items + num;
				_ = 0;
				int num2 = version + 1;
				Count = num;
				version = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X9_v4+20]");
				return (T)0;
			}
			InvalidOperationException ex = new InvalidOperationException("List is empty. Nothing to pop.");
			throw ex;
		}

		[Token(Token = "0x60002A9")]
		[Address(RVA = "0xF440D0", Offset = "0xF440D0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.ExposedList`1<T>::CheckRange(this, index, count);\n\tv28 = count < 1;\n\tif (v28) goto L_0029;\n\tv29 = 0 - count;\n\tSpine.ExposedList`1::Shift /* +1 sharing this address */(this, index, v29, Il2CppMethodInfo);\n\tSystem.Array::Clear(this.Items, this.Count, count);\n\tv41 = this.version + 1;\n\tthis.version = v41;\nL_0029:\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveRange(int index, int count)
		{
			CheckRange(index, count);
			if (count >= 1)
			{
				int num = -count;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F4741C (Spine.ExposedList`1::Shift, and 1 more at this address)");
				Array.Clear(Items, Count, count);
				int num2 = version + 1;
				version = num2;
			}
		}

		[Token(Token = "0x60002AA")]
		[Address(RVA = "0xF44138", Offset = "0xF44138", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Array::Reverse(this.Items, 0, this.Count);\n\tv14 = this.version + 1;\n\tthis.version = v14;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reverse()
		{
			Array.Reverse((bool[])(object)Items, 0, Count);
			int num = version + 1;
			version = num;
		}

		[Token(Token = "0x60002AB")]
		[Address(RVA = "0xF44170", Offset = "0xF44170", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.ExposedList`1<T>::CheckRange(this, index, count);\n\tSystem.Array::Reverse(this.Items, index, count);\n\tv30 = this.version + 1;\n\tthis.version = v30;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reverse(int index, int count)
		{
			CheckRange(index, count);
			Array.Reverse((bool[])(object)Items, index, count);
			int num = version + 1;
			version = num;
		}

		[Token(Token = "0x60002AC")]
		[Address(RVA = "0xF441D4", Offset = "0xF441D4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = System.Collections.Generic.Comparer`1<System.Boolean>::get_Default();\n\tSystem.Array::Sort(this.Items, 0, this.Count, v19);\n\tv30 = this.version + 1;\n\tthis.version = v30;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Sort()
		{
			Comparer<bool> comparer = Comparer<bool>.Default;
			Array.Sort((bool[])(object)Items, 0, Count, comparer);
			int num = version + 1;
			version = num;
		}

		[Token(Token = "0x60002AD")]
		[Address(RVA = "0xF4423C", Offset = "0xF4423C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Array::Sort(this.Items, 0, this.Count, comparer);\n\tv16 = this.version + 1;\n\tthis.version = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Sort(IComparer<T> comparer)
		{
			Array.Sort((bool[])(object)Items, 0, Count, (IComparer<bool>)comparer);
			int num = version + 1;
			version = num;
		}

		[Token(Token = "0x60002AE")]
		[Address(RVA = "0xF44278", Offset = "0xF44278", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Array::Sort(this.Items, comparison);\n\tv13 = this.version + 1;\n\tthis.version = v13;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Sort(Comparison<T> comparison)
		{
			Array.Sort(Items, comparison);
			int num = version + 1;
			version = num;
		}

		[Token(Token = "0x60002AF")]
		[Address(RVA = "0xF442A8", Offset = "0xF442A8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.ExposedList`1<T>::CheckRange(this, index, count);\n\tSystem.Array::Sort(this.Items, index, count, comparer);\n\tv37 = this.version + 1;\n\tthis.version = v37;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Sort(int index, int count, IComparer<T> comparer)
		{
			CheckRange(index, count);
			Array.Sort((bool[])(object)Items, index, count, (IComparer<bool>)comparer);
			int num = version + 1;
			version = num;
		}

		[Token(Token = "0x60002B0")]
		[Address(RVA = "0xF44314", Offset = "0xF44314", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv17 = 0xB348B0(v12, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0010:\n\t// 16 NewArr v34 @ X0_v3 (Il2CppClass<T[]>), typeof(Il2CppClass<T[]>), this.Count (System.Int32)\n\tSystem.Array::Copy(this.Items, v34, this.Count);\n\treturn v34;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T[] ToArray()
		{
			//IL_000a: Expected I, but got O
			//IL_001f: Expected O, but got I
			//IL_0029: Expected O, but got I
			nint num = unchecked((nint)null);
			Array.Copy(Items, (Array)num, Count);
			return (T[])num;
		}

		[Token(Token = "0x60002B1")]
		[Address(RVA = "0xF44370", Offset = "0xF44370", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.ExposedList`1<T>::set_Capacity(this, this.Count);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void TrimExcess()
		{
			Capacity = Count;
		}

		[Token(Token = "0x60002B2")]
		[Address(RVA = "0xF44384", Offset = "0xF44384", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv21 = v16;\n\tv22 = 0xB348B0(v21, match, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0016:\n\tgoto L_001D;\n\tv42 = v37;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v42, match, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001D:\n\tSpine.ExposedList`1<T>::CheckMatch(match);\n\tv60 = this.Count < 1;\n\tif (v60) goto L_FFFFFFFF;\nL_002C:\n\tv98 = this.Items;\n\tv120 = System.Predicate`1<T>::Invoke(match, *([v98 @ X8_v10 (T[])+v94 @ X21_v5 (System.Int32)]));\n\tv180 = v120 & 1;\n\tv91 = v180 == 0;\n\tif (v91) goto L_0058;\n\tv93 = v94 - 0x1F;\n\tv94 = v94 + 1;\n\tv69 = v93 < this.Count;\n\tif (v69) goto L_002C;\n\tgoto L_0058;\nL_0058:\n\treturnVal1 = v120 & 1;\n\treturn returnVal1;\n\tv145 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrueForAll(Predicate<T> match)
		{
			//IL_0050: Expected O, but got I
			CheckMatch(match);
			int num2;
			if (Count >= 1)
			{
				int num = 32;
				int num3;
				do
				{
					T[] items = Items;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ X8_v10 (T[])+v94 @ X21_v5 (System.Int32)]");
					num2 = (match((T)0) ? 1 : 0);
					if ((num2 & 1) == 0)
					{
						break;
					}
					num3 = num - 31;
					num++;
				}
				while (num3 < Count);
			}
			else
			{
				num2 = 1;
			}
			return (byte)(num2 & 1) != 0;
		}

		[Token(Token = "0x60002B5")]
		[Address(RVA = "0xF444CC", Offset = "0xF444CC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0;\n\tSpine.ExposedList`1<T>+Enumerator<T>::.ctor(&v10 @ stack_-50_v1 (Spine.ExposedList`1<T>+Enumerator<T>), this);\n\tv10 = 0;\n\t// 26 Box returnVal1 @ X0_v3 (System.Collections.Generic.IEnumerator`1<T>), typeof(Il2CppClass<Spine.ExposedList`1<T>+Enumerator<T>>), &v10 @ stack_-50_v1 (Spine.ExposedList`1<T>+Enumerator<T>)\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//IL_0027: Expected I, but got O
			Enumerator enumerator = default(Enumerator);
			enumerator = new Enumerator(this);
			return (IEnumerator<T>)(object)(IntPtr)default(Enumerator);
		}

		[Token(Token = "0x60002B6")]
		[Address(RVA = "0xF4453C", Offset = "0xF4453C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0;\n\tSpine.ExposedList`1<T>+Enumerator<T>::.ctor(&v10 @ stack_-50_v1 (Spine.ExposedList`1<T>+Enumerator<T>), this);\n\tv10 = 0;\n\t// 26 Box returnVal1 @ X0_v3 (System.Collections.IEnumerator), typeof(Il2CppClass<Spine.ExposedList`1<T>+Enumerator<T>>), &v10 @ stack_-50_v1 (Spine.ExposedList`1<T>+Enumerator<T>)\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		IEnumerator IEnumerable.GetEnumerator()
		{
			//IL_0027: Expected I, but got O
			Enumerator enumerator = default(Enumerator);
			enumerator = new Enumerator(this);
			return (IEnumerator)(object)(IntPtr)default(Enumerator);
		}

		[Token(Token = "0x60002B7")]
		[Address(RVA = "0xF445AC", Offset = "0xF445AC", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv13 = 0xB348B0(v8, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\nL_0012:\n\tgoto L_0015;\n\tv36 = 0xB348B0(v31, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\nL_0015:\n\t// 21 NewArr v39 @ X0_v5 (T[]), typeof(Il2CppClass<T[]>), 0\n\tgoto L_0026;\n\tv46 = v40;\n\tv47 = 0xB348B0(v46, v38, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv49 = v47;\nL_0026:\n\tgoto L_0029;\n\tv57 = 0xB348B0(v52, v38, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\nL_0029:\n\tv59.EmptyArray = v39;\n\tgoto L_0032;\n\tv65 = 0xB348B0(v60, v38, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\nL_0032:\n\tv68 = Il2CppClass<Spine.ExposedList`1<T>>;\n\tv70 = *([v68 @ X0_v11 (Il2CppClass<Spine.ExposedList`1<T>>)+135]) & 1;\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0042;\n\tv76 = 0xB348B0(Il2CppClass<Spine.ExposedList`1<T>>, 0, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\treturn;\nL_0042:\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ExposedList()
		{
			T[] emptyArray = null;
			EmptyArray = emptyArray;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X0_v11 (Il2CppClass<Spine.ExposedList`1<T>>)+135]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B348B0");
			}
		}
	}
}
