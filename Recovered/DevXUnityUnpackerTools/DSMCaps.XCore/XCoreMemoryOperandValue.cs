using System.Runtime.CompilerServices;

namespace DSMCaps.XCore
{
	public sealed class XCoreMemoryOperandValue
	{
		[CompilerGenerated]
		internal readonly XCoreRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020;

		[CompilerGenerated]
		internal readonly int _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A;

		[CompilerGenerated]
		internal readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A;

		[CompilerGenerated]
		internal readonly XCoreRegister _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A;

		internal XCoreRegister _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A
		{
			get;
		}

		internal int _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020
		{
			get;
		}

		internal int _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A
		{
			get;
		}

		internal XCoreRegister _0020_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A
		{
			get;
		}

		internal XCoreMemoryOperandValue(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A nativeMemoryOperandValue)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020 = XCoreRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, (XCoreRegisterId)nativeMemoryOperandValue.Base);
			_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A = nativeMemoryOperandValue.Direct;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A = nativeMemoryOperandValue.Displacement;
			_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A = XCoreRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, (XCoreRegisterId)nativeMemoryOperandValue.Index);
		}
	}
}
