using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000025")]
	public class Pool<T> where T : class, new()
	{
		[Token(Token = "0x2000026")]
		public interface IPoolable
		{
			[Token(Token = "0x600013B")]
			void Reset();
		}

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x0")]
		public readonly int max;

		[Token(Token = "0x40000E6")]
		[FieldOffset(Offset = "0x0")]
		private readonly Stack<T> freeObjects;

		[Token(Token = "0x17000055")]
		public int Count
		{
			[Token(Token = "0x6000133")]
			[Address(RVA = "0x113C7F4", Offset = "0x113C7F4", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.freeObjects;\n\treturn v2._size;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Stack<T> stack = freeObjects;
				return stack.Count;
			}
		}

		[Token(Token = "0x17000056")]
		public int Peak
		{
			[CompilerGenerated]
			[Token(Token = "0x6000134")]
			[Address(RVA = "0x113C810", Offset = "0x113C810", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Peak>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Peak;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000135")]
			[Address(RVA = "0x113C818", Offset = "0x113C818", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Peak>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CPeak_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000136")]
		[Address(RVA = "0x113C820", Offset = "0x113C820", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tgoto L_0015;\n\tv26 = 0xB348B0(v21, v12, max, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0015:\n\tv40 = new Il2CppClass<System.Collections.Generic.Stack`1<T>>();\n\tSystem.Collections.Generic.Stack`1<T>::.ctor(v40, initialCapacity);\n\tthis.freeObjects = v40;\n\tthis.max = max;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Pool(int initialCapacity = 16, int max = int.MaxValue)
		{
			Stack<T> stack = new Stack<T>(initialCapacity);
			freeObjects = stack;
			this.max = max;
		}

		[Token(Token = "0x6000137")]
		[Address(RVA = "0x113C890", Offset = "0x113C890", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.freeObjects;\n\tv9 = v2._size == 0;\n\tif (v9) goto L_0012;\n\treturnVal2 = System.Collections.Generic.Stack`1<T>::Pop(v2);\n\treturn returnVal2;\nL_0012:\n\treturnVal3 = System.Activator::CreateInstance();\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T Obtain()
		{
			Stack<T> stack = freeObjects;
			if (stack.Count != 0)
			{
				return stack.Pop();
			}
			return (T)Activator.CreateInstance<object>();
		}

		[Token(Token = "0x6000138")]
		[Address(RVA = "0x113C8C8", Offset = "0x113C8C8", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv24 = System.Math;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, obj, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 1;\n\t*([1A35EDE]) = v41;\nL_0015:\n\tv42 = obj == 0;\n\tif (v42) goto L_004F;\n\tv43 = this.freeObjects;\n\tv99 = v43._size >= this.max;\n\tif (v99) goto L_0049;\n\tSystem.Collections.Generic.Stack`1<T>::Push(v43, obj);\n\tv103 = this.freeObjects;\n\tgoto L_003C;\n\tv172 = \"il2cpp_codegen_runtime_class_init\"(v142, v101, v100, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003C:\n\tv115 = System.Math::Max(this.<Peak>k__BackingField, v103._size);\n\tthis.<Peak>k__BackingField = v115;\nL_0049:\n\tSpine.Pool`1<T>::Reset(v115, obj);\n\treturn;\n\tthrow System.NullReferenceException;\nL_004F:\n\tv104 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v104, \"obj\", \"obj cannot be null\");\n\tthrow v104;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Free(T obj)
		{
			//IL_0034: Expected I4, but got O
			//IL_00d2: Expected O, but got I4
			if (obj != null)
			{
				Stack<T> stack = freeObjects;
				bool flag = stack.Count >= max;
				int num = (int)stack;
				if (!flag)
				{
					stack.Push(obj);
					Stack<T> stack2 = freeObjects;
					num = (Peak = Math.Max(Peak, stack2.Count));
				}
				((Pool<T>)num).Reset(obj);
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("obj", "obj cannot be null");
			throw ex;
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0x113C9E0", Offset = "0x113C9E0", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Collections.Generic.Stack`1<T>::Clear(this.freeObjects);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear()
		{
			freeObjects.Clear();
		}

		[Token(Token = "0x600013A")]
		[Address(RVA = "0x113CA04", Offset = "0x113CA04", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv17 = v12;\n\tv18 = 0xB348B0(v17, obj, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = v18;\nL_0013:\n\t// 19 IsInst v38 @ X0_v3, typeof(Spine.Pool`1<T>+IPoolable<T>), obj @ X1 (T)\n\tv39 = v38 == 0;\n\tif (v39) goto L_0048;\n\tgoto L_0022;\n\tv51 = v43;\n\tv52 = 0xB348B0(v51, v43, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv54 = v52;\nL_0022:\n\tv56 = *([v38 @ X0_v3]);\n\tv152 = *([v56 @ X8_v8+12E]);\n\tv58 = *([v56 @ X8_v8+12E]) == 0;\n\tif (v58) goto L_0042;\n\tv151 = *([v56 @ X8_v8+B0]) + 8;\nL_002D:\n\tv157 = *([v151 @ X10_v5-8]) == Il2CppClass<Spine.Pool`1<T>+IPoolable<T>>;\n\tif (v157) goto L_004A;\n\tv137 = v152 - 1;\n\tv151 = v151 + 0x10;\n\tv117 = v152 != 1;\n\tif (v117) goto L_002D;\nL_0042:\n\tv168 = 0xB349B4(v38, Il2CppClass<Spine.Pool`1<T>+IPoolable<T>>, 0, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_004D;\nL_0048:\n\treturn;\nL_004A:\n\tv164 = *([v151 @ X10_v5]) << 4;\n\tv165 = v56 + v164;\n\tv168 = v165 + 0x138;\nL_004D:\n\tv68 = *([v168 @ X0_v5]);\n\tv100 = *([v168 @ X0_v5+8]);\n\t// 84 IndirectJump v68 @ X2_v2, v38 @ X0_v3, v38 @ X0_v3, v100 @ X1_v4, v68 @ X2_v2, v19 @ X3, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void Reset(T obj)
		{
			//IL_00ed: Expected O, but got I
			//IL_014c: Expected O, but got I
			//IL_0020: Expected O, but got I
			//IL_0089: Expected I4, but got O
			//IL_0097: Expected O, but got I
			//IL_00a6: Expected O, but got I
			//IL_0034: Expected O, but got I
			//IL_0043: Expected O, but got I
			object obj2 = obj as IPoolable;
			if (obj2 == null)
			{
				return;
			}
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v8+12E]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v8+12E]");
			if ((nint)0 == 0)
			{
				goto IL_006b;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v8+B0]");
			object obj5 = (nint)0 + (nint)8;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X10_v5-8]");
				if ((nint)0 == 0)
				{
					break;
				}
				object obj6 = (nint)obj4 - 1;
				obj5 = (nint)obj5 + 16;
				bool flag = (nint)obj4 != 1;
				obj4 = obj6;
				if (flag)
				{
					continue;
				}
				goto IL_006b;
			}
			int num = obj5 << 4;
			object obj7 = (nint)obj3 + num;
			object obj8 = (nint)obj7 + 312;
			goto IL_0134;
			IL_0134:
			object obj9 = obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X0_v5+8]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v68 @ X2_v2 (should have been resolved before IL gen)");
			return;
			IL_006b:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B349B4");
			goto IL_0134;
		}
	}
}
