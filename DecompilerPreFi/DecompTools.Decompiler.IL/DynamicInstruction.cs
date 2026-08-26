using System.Collections.Generic;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public abstract class DynamicInstruction : ILInstruction
{
	public CSharpBinderFlags BinderFlags { get; }

	public IType CallingContext { get; }

	public override InstructionFlags DirectFlags => InstructionFlags.SideEffect | InstructionFlags.MayThrow;

	protected DynamicInstruction(OpCode opCode, CSharpBinderFlags binderFlags, IType context)
		: base(opCode)
	{
		BinderFlags = binderFlags;
		CallingContext = context;
	}

	protected void WriteBinderFlags(ITextOutput output, ILAstWritingOptions options)
	{
		WriteBinderFlags(BinderFlags, output, options);
	}

	internal static void WriteBinderFlags(CSharpBinderFlags flags, ITextOutput output, ILAstWritingOptions options)
	{
		if ((flags & CSharpBinderFlags.BinaryOperationLogical) != CSharpBinderFlags.None)
		{
			output.Write(".logic");
		}
		if ((flags & CSharpBinderFlags.CheckedContext) != CSharpBinderFlags.None)
		{
			output.Write(".checked");
		}
		if ((flags & CSharpBinderFlags.ConvertArrayIndex) != CSharpBinderFlags.None)
		{
			output.Write(".arrayindex");
		}
		if ((flags & CSharpBinderFlags.ConvertExplicit) != CSharpBinderFlags.None)
		{
			output.Write(".explicit");
		}
		if ((flags & CSharpBinderFlags.InvokeSimpleName) != CSharpBinderFlags.None)
		{
			output.Write(".invokesimple");
		}
		if ((flags & CSharpBinderFlags.InvokeSpecialName) != CSharpBinderFlags.None)
		{
			output.Write(".invokespecial");
		}
		if ((flags & CSharpBinderFlags.ResultDiscarded) != CSharpBinderFlags.None)
		{
			output.Write(".discard");
		}
		if ((flags & CSharpBinderFlags.ResultIndexed) != CSharpBinderFlags.None)
		{
			output.Write(".resultindexed");
		}
		if ((flags & CSharpBinderFlags.ValueFromCompoundAssignment) != CSharpBinderFlags.None)
		{
			output.Write(".compound");
		}
	}

	public abstract CSharpArgumentInfo GetArgumentInfoOfChild(int index);

	internal static void WriteArgumentList(ITextOutput output, ILAstWritingOptions options, params (ILInstruction, CSharpArgumentInfo)[] arguments)
	{
		WriteArgumentList(output, options, (IEnumerable<(ILInstruction, CSharpArgumentInfo)>)arguments);
	}

	internal static void WriteArgumentList(ITextOutput output, ILAstWritingOptions options, IEnumerable<(ILInstruction, CSharpArgumentInfo)> arguments)
	{
		output.Write('(');
		int num = 0;
		foreach (var (iLInstruction, cSharpArgumentInfo) in arguments)
		{
			if (num > 0)
			{
				output.Write(", ");
			}
			output.Write("[flags: ");
			output.Write(cSharpArgumentInfo.Flags.ToString());
			output.Write(", name: " + cSharpArgumentInfo.Name + "] ");
			iLInstruction.WriteTo(output, options);
			num = checked(num + 1);
		}
		output.Write(')');
	}

	protected DynamicInstruction(OpCode opCode)
		: base(opCode)
	{
	}

	protected override InstructionFlags ComputeFlags()
	{
		return InstructionFlags.SideEffect | InstructionFlags.MayThrow;
	}
}
