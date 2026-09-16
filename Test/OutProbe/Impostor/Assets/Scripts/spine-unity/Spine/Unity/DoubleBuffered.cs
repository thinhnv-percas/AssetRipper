using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine.Unity
{
	[Token(Token = "0x20000A7")]
	public class DoubleBuffered<T> where T : new()
	{
		[Token(Token = "0x40003EB")]
		[FieldOffset(Offset = "0x0")]
		private readonly T a;

		[Token(Token = "0x40003EC")]
		[FieldOffset(Offset = "0x0")]
		private readonly T b;

		[Token(Token = "0x40003ED")]
		[FieldOffset(Offset = "0x0")]
		private bool usingA;

		[Token(Token = "0x600066D")]
		[Address(RVA = "0xE6CF08", Offset = "0xE6CF08", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tif (this.usingA) goto L_FFFFFFFF;\n\tgoto L_0013;\nL_0013:\n\treturn *([this @ X0 (Spine.Unity.DoubleBuffered`1<T>)+v16 @ X8_v3 (System.Int32)]);\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T GetCurrent()
		{
			//IL_0039: Expected O, but got I
			if (!usingA)
			{
				int num = 24;
			}
			else
			{
				int num = 16;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.Unity.DoubleBuffered`1<T>)+v16 @ X8_v3 (System.Int32)]");
			return (T)0;
		}

		[Token(Token = "0x600066E")]
		[Address(RVA = "0xE6CF24", Offset = "0xE6CF24", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.usingA ^ 1;\n\tthis.usingA = v4;\n\tif (this.usingA) goto L_FFFFFFFF;\n\tgoto L_0015;\nL_0015:\n\treturn *([this @ X0 (Spine.Unity.DoubleBuffered`1<T>)+v17 @ X8_v2 (System.Int32)]);\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public T GetNext()
		{
			//IL_0053: Expected O, but got I
			int num = (usingA ? 1 : 0) ^ 1;
			usingA = (byte)num != 0;
			if (!usingA)
			{
				int num2 = 16;
			}
			else
			{
				int num2 = 24;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.Unity.DoubleBuffered`1<T>)+v17 @ X8_v2 (System.Int32)]");
			return (T)0;
		}

		[Token(Token = "0x600066F")]
		[Address(RVA = "0xE6CF48", Offset = "0xE6CF48", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = System.Activator::CreateInstance();\n\tthis.a = v14;\n\tv18 = System.Activator::CreateInstance();\n\tthis.b = v18;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DoubleBuffered()
		{
			object obj = Activator.CreateInstance<object>();
			a = (T)obj;
			object obj2 = Activator.CreateInstance<object>();
			b = (T)obj2;
		}
	}
}
