using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.ContainerSystem.Runtime
{
	[Token(Token = "0x2000042")]
	public class AsyncInitHandle
	{
		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0x10")]
		internal readonly Action _onComplete;

		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x18")]
		internal bool _completed;

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x3F38FC8", Offset = "0x3F38FC8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._onComplete = onComplete;\n\treturn;\n")]
		internal AsyncInitHandle(Action onComplete)
		{
			_onComplete = onComplete;
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x3F39318", Offset = "0x3F39318", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this._completed == 0;\n\tv4 = ~v3;\n\tif (v4) goto L_000E;\n\tthis._completed = 1;\n\tv7 = this._onComplete == 0;\n\tif (v7) goto L_000E;\n\tSystem.Action::Invoke(this._onComplete);\n\treturn;\nL_000E:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Complete()
		{
			if (!_completed)
			{
				_completed = true;
				if (_onComplete != null)
				{
					_onComplete();
				}
			}
		}
	}
}
