using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.SwitchSystem
{
	[Token(Token = "0x2000280")]
	public readonly struct LockHandle : IDisposable
	{
		[Token(Token = "0x40007F0")]
		[FieldOffset(Offset = "0x0")]
		internal readonly Action _release;

		[Token(Token = "0x6000B33")]
		[Address(RVA = "0x3EC4F6C", Offset = "0x3EC4F6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._release = release;\n\treturn;\n")]
		internal LockHandle(Action release)
		{
			_release = release;
		}

		[Token(Token = "0x6000B34")]
		[Address(RVA = "0x3EC4F74", Offset = "0x3EC4F74", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this._release == 0;\n\tif (v2) goto L_0007;\n\tSystem.Action::Invoke(this._release);\n\treturn;\nL_0007:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			if (_release != null)
			{
				_release();
			}
		}
	}
}
