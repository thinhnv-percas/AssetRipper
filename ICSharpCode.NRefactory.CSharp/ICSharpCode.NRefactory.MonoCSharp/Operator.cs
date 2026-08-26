namespace ICSharpCode.NRefactory.MonoCSharp;

internal static class Operator
{
	public enum OpType : byte
	{
		LogicalNot,
		OnesComplement,
		Increment,
		Decrement,
		True,
		False,
		Addition,
		Subtraction,
		UnaryPlus,
		UnaryNegation,
		Multiply,
		Division,
		Modulus,
		BitwiseAnd,
		BitwiseOr,
		ExclusiveOr,
		LeftShift,
		RightShift,
		Equality,
		Inequality,
		GreaterThan,
		LessThan,
		GreaterThanOrEqual,
		LessThanOrEqual,
		Implicit,
		Explicit,
		Is,
		TOP
	}

	private static readonly string[][] names;

	static Operator()
	{
		names = new string[27][];
		names[0] = new string[2] { "!", "op_LogicalNot" };
		names[1] = new string[2] { "~", "op_OnesComplement" };
		names[2] = new string[2] { "++", "op_Increment" };
		names[3] = new string[2] { "--", "op_Decrement" };
		names[4] = new string[2] { "true", "op_True" };
		names[5] = new string[2] { "false", "op_False" };
		names[6] = new string[2] { "+", "op_Addition" };
		names[7] = new string[2] { "-", "op_Subtraction" };
		names[8] = new string[2] { "+", "op_UnaryPlus" };
		names[9] = new string[2] { "-", "op_UnaryNegation" };
		names[10] = new string[2] { "*", "op_Multiply" };
		names[11] = new string[2] { "/", "op_Division" };
		names[12] = new string[2] { "%", "op_Modulus" };
		names[13] = new string[2] { "&", "op_BitwiseAnd" };
		names[14] = new string[2] { "|", "op_BitwiseOr" };
		names[15] = new string[2] { "^", "op_ExclusiveOr" };
		names[16] = new string[2] { "<<", "op_LeftShift" };
		names[17] = new string[2] { ">>", "op_RightShift" };
		names[18] = new string[2] { "==", "op_Equality" };
		names[19] = new string[2] { "!=", "op_Inequality" };
		names[20] = new string[2] { ">", "op_GreaterThan" };
		names[21] = new string[2] { "<", "op_LessThan" };
		names[22] = new string[2] { ">=", "op_GreaterThanOrEqual" };
		names[23] = new string[2] { "<=", "op_LessThanOrEqual" };
		names[24] = new string[2] { "implicit", "op_Implicit" };
		names[25] = new string[2] { "explicit", "op_Explicit" };
		names[26] = new string[2] { "is", "op_Is" };
	}

	public static string GetName(OpType ot)
	{
		return names[(uint)ot][0];
	}

	public static string GetName(string metadata_name)
	{
		for (int i = 0; i < names.Length; i++)
		{
			if (names[i][1] == metadata_name)
			{
				return names[i][0];
			}
		}
		return null;
	}

	public static string GetMetadataName(OpType ot)
	{
		return names[(uint)ot][1];
	}

	public static string GetMetadataName(string name)
	{
		for (int i = 0; i < names.Length; i++)
		{
			if (names[i][0] == name)
			{
				return names[i][1];
			}
		}
		return null;
	}

	public static OpType? GetType(string metadata_name)
	{
		for (int i = 0; i < names.Length; i++)
		{
			if (names[i][1] == metadata_name)
			{
				return (OpType)i;
			}
		}
		return null;
	}
}
