using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Reflex.Generics
{
	[Token(Token = "0x2000021")]
	internal sealed class DisposableCollection : IDisposable
	{
		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x10")]
		internal readonly Stack<IDisposable> _stack;

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x3F3397C", Offset = "0x3F3397C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tSystem.Collections.Generic.Stack`1<System.IDisposable>::Push(this._stack, v40);\n\treturn;\n")]
		public void Add(IDisposable disposable)
		{
			IDisposable item = default(IDisposable);
			_stack.Push(item);
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x3F30ED0", Offset = "0x3F30ED0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Collections.Generic.Stack`1<System.IDisposable>::Push(this._stack, v48);\n\treturn;\nL_0036:\n\treturn;\nL_001C:\n\tv48 = 0x21C11D0(obj, System.IDisposable, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv51 = v48 == 0;\n\tif (v51) goto L_0036;\n")]
		public void TryAdd(object obj)
		{
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
			IDisposable disposable = default(IDisposable);
			if (disposable != null)
			{
				_stack.Push(disposable);
			}
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x3F314BC", Offset = "0x3F314BC", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tgoto L_002C;\nL_0026:\n\tv208 = System.IDisposable::Dispose(v117);\n\tv145 = this._stack;\nL_002C:\n\tv130 = System.Collections.Generic.Stack`1<System.IDisposable>::TryPop(v145, &v117 @ stack_-38_v5 (System.IDisposable));\n\tv168 = ~v130;\n\tif (v168) goto L_0066;\n\tv178 = *([v117 @ stack_-38_v5 (System.IDisposable)]);\n\tv205 = *([v178 @ X8_v6 (Il2CppClass<System.IDisposable>)+12E]);\n\tv180 = *([v178 @ X8_v6 (Il2CppClass<System.IDisposable>)+12E]) == 0;\n\tif (v180) goto L_0026;\n\tv107 = *([v178 @ X8_v6 (Il2CppClass<System.IDisposable>)+B0]) + 8;\n\tv107 = v107 + 0x10;\n\tv193 = v205 - 1;\n\tv183 = v205 != 1;\n\tv205 = v193;\n\tif (v183) goto L_003E;\n\tgoto L_0026;\nL_0053:\n\tv58 = *([v107 @ X10_v6]) << 4;\n\tv210 = v178 + v58;\n\tv211 = v210 + 0x138;\n\t*([v211 @ X0_v8])(v213, v117, *([v211 @ X0_v8+8]), Il2CppMethodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv145 = this._stack;\n\tv214 = this._stack == 0;\n\tv132 = ~v214;\n\tif (v132) goto L_002C;\n\tthrow System.NullReferenceException;\nL_0066:\n\treturn;\nL_0018:\n\tv145 = this._stack;\nL_003E:\n\tv87 = *([v107 @ X10_v6-8]) == System.IDisposable;\n\tif (v87) goto L_0053;\n")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DisposableCollection::Dispose");
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x3F31410", Offset = "0x3F31410", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.Stack`1<System.IDisposable>();\n\tSystem.Collections.Generic.Stack`1<System.IDisposable>::.ctor(v48);\n\tthis._stack = v48;\n")]
		public DisposableCollection()
		{
			Stack<IDisposable> stack = new Stack<IDisposable>();
			_stack = stack;
		}
	}
}
