using dnlib.DotNet.Pdb;

namespace dnlib.DotNet.Emit;

public static class Extensions
{
	public static OpCode ToOpCode(this Code code)
	{
		int num = (int)code >> 8;
		int num2 = (byte)code;
		return num switch
		{
			0 => OpCodes.OneByteOpCodes[num2], 
			254 => OpCodes.TwoByteOpCodes[num2], 
			_ => code switch
			{
				Code.UNKNOWN1 => OpCodes.UNKNOWN1, 
				Code.UNKNOWN2 => OpCodes.UNKNOWN2, 
				_ => null, 
			}, 
		};
	}

	public static OpCode GetOpCode(this Instruction self)
	{
		return self?.OpCode ?? OpCodes.UNKNOWN1;
	}

	public static object GetOperand(this Instruction self)
	{
		return self?.Operand;
	}

	public static uint GetOffset(this Instruction self)
	{
		return self?.Offset ?? 0;
	}

	public static SequencePoint GetSequencePoint(this Instruction self)
	{
		return self?.SequencePoint;
	}

	public static IMDTokenProvider ResolveToken(this IInstructionOperandResolver self, uint token)
	{
		return self.ResolveToken(token, default(GenericParamContext));
	}
}
