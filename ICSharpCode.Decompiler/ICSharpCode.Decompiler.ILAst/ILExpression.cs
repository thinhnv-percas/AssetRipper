using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.Decompiler.Disassembler;

namespace ICSharpCode.Decompiler.ILAst;

public class ILExpression : ILNode
{
	public ILCode Code { get; set; }

	public object Operand { get; set; }

	public List<ILExpression> Arguments { get; }

	public ILExpressionPrefix[] Prefixes { get; set; }

	public TypeSig ExpectedType { get; set; }

	public TypeSig InferredType { get; set; }

	public override bool SafeToAddToEndILSpans => true;

	public ILExpression(ILCode code, object operand, List<ILExpression> args)
	{
		if (operand is ILExpression)
		{
			throw new ArgumentException("operand");
		}
		Code = code;
		Operand = operand;
		Arguments = new List<ILExpression>(args);
	}

	public ILExpression(ILCode code, object operand)
	{
		if (operand is ILExpression)
		{
			throw new ArgumentException("operand");
		}
		Code = code;
		Operand = operand;
		Arguments = new List<ILExpression>();
	}

	public ILExpression(ILCode code, object operand, ILExpression arg1)
	{
		if (operand is ILExpression)
		{
			throw new ArgumentException("operand");
		}
		Code = code;
		Operand = operand;
		Arguments = new List<ILExpression> { arg1 };
	}

	public ILExpression(ILCode code, object operand, ILExpression arg1, ILExpression arg2)
	{
		if (operand is ILExpression)
		{
			throw new ArgumentException("operand");
		}
		Code = code;
		Operand = operand;
		Arguments = new List<ILExpression> { arg1, arg2 };
	}

	public ILExpression(ILCode code, object operand, ILExpression arg1, ILExpression arg2, ILExpression arg3)
	{
		if (operand is ILExpression)
		{
			throw new ArgumentException("operand");
		}
		Code = code;
		Operand = operand;
		Arguments = new List<ILExpression> { arg1, arg2, arg3 };
	}

	public ILExpression(ILCode code, object operand, ILExpression[] args)
	{
		if (operand is ILExpression)
		{
			throw new ArgumentException("operand");
		}
		Code = code;
		Operand = operand;
		Arguments = new List<ILExpression>(args);
	}

	public ILExpressionPrefix GetPrefix(ILCode code)
	{
		ILExpressionPrefix[] prefixes = Prefixes;
		if (prefixes != null)
		{
			ILExpressionPrefix[] array = prefixes;
			foreach (ILExpressionPrefix iLExpressionPrefix in array)
			{
				if (iLExpressionPrefix.Code == code)
				{
					return iLExpressionPrefix;
				}
			}
		}
		return null;
	}

	internal override ILNode GetNext(ref int index)
	{
		if (index < Arguments.Count)
		{
			return Arguments[index++];
		}
		return null;
	}

	public bool IsBranch()
	{
		if (!(Operand is ILLabel))
		{
			return Operand is ILLabel[];
		}
		return true;
	}

	public IEnumerable<ILLabel> GetBranchTargets()
	{
		if (Operand is ILLabel)
		{
			return new ILLabel[1] { (ILLabel)Operand };
		}
		if (Operand is ILLabel[])
		{
			return (ILLabel[])Operand;
		}
		return Array.Empty<ILLabel>();
	}

	private void WriteExpectedType(IDecompilerOutput output)
	{
		int nextPosition = output.NextPosition;
		output.Write("[", BoxedTextColor.Punctuation);
		output.Write("exp", BoxedTextColor.Keyword);
		output.Write(":", BoxedTextColor.Punctuation);
		ExpectedType.WriteTo(output, ILNameSyntax.ShortTypeName);
		output.Write("]", BoxedTextColor.Punctuation);
		output.AddBracePair(new TextSpan(nextPosition, 1), new TextSpan(output.Length - 1, 1), CodeBracesRangeFlags.BraceKind_SquareBrackets);
	}

	public override void WriteTo(IDecompilerOutput output, MethodDebugInfoBuilder builder)
	{
		int nextPosition = output.NextPosition;
		if (Operand is ILVariable && ((ILVariable)Operand).GeneratedByDecompiler)
		{
			ILVariable iLVariable = (ILVariable)Operand;
			object textReferenceObject = iLVariable.GetTextReferenceObject();
			if (Code == ILCode.Stloc && InferredType == null)
			{
				output.Write(((ILVariable)Operand).Name, textReferenceObject, DecompilerReferenceFlags.Local, ((ILVariable)Operand).IsParameter ? BoxedTextColor.Parameter : BoxedTextColor.Local);
				output.Write(" ", BoxedTextColor.Text);
				output.Write("=", BoxedTextColor.Operator);
				output.Write(" ", BoxedTextColor.Text);
				Arguments.First().WriteTo(output, null);
				UpdateDebugInfo(builder, nextPosition, output.NextPosition, GetSelfAndChildrenRecursiveILSpans());
				return;
			}
			if (Code == ILCode.Ldloc)
			{
				output.Write(((ILVariable)Operand).Name, textReferenceObject, DecompilerReferenceFlags.Local, ((ILVariable)Operand).IsParameter ? BoxedTextColor.Parameter : BoxedTextColor.Local);
				if (InferredType != null)
				{
					output.Write(":", BoxedTextColor.Punctuation);
					InferredType.WriteTo(output, ILNameSyntax.ShortTypeName);
					if (ExpectedType != null && ExpectedType.FullName != InferredType.FullName)
					{
						WriteExpectedType(output);
					}
				}
				UpdateDebugInfo(builder, nextPosition, output.NextPosition, GetSelfAndChildrenRecursiveILSpans());
				return;
			}
		}
		if (Prefixes != null)
		{
			ILExpressionPrefix[] prefixes = Prefixes;
			foreach (ILExpressionPrefix iLExpressionPrefix in prefixes)
			{
				string text = iLExpressionPrefix.Code.GetName() + ".";
				output.Write(text, text, DecompilerReferenceFlags.Local, BoxedTextColor.OpCode);
				output.Write(" ", BoxedTextColor.Text);
			}
		}
		string name = Code.GetName();
		output.Write(name, name, DecompilerReferenceFlags.Local, BoxedTextColor.OpCode);
		if (InferredType != null)
		{
			output.Write(":", BoxedTextColor.Punctuation);
			InferredType.WriteTo(output, ILNameSyntax.ShortTypeName);
			if (ExpectedType != null && ExpectedType.FullName != InferredType.FullName)
			{
				WriteExpectedType(output);
			}
		}
		else if (ExpectedType != null)
		{
			WriteExpectedType(output);
		}
		int nextPosition2 = output.NextPosition;
		output.Write("(", BoxedTextColor.Punctuation);
		bool flag = true;
		if (Operand != null)
		{
			if (Operand is ILLabel)
			{
				ILLabel iLLabel = (ILLabel)Operand;
				output.Write(iLLabel.Name, iLLabel.Reference, DecompilerReferenceFlags.Local, BoxedTextColor.Label);
			}
			else if (Operand is ILLabel[])
			{
				ILLabel[] array = (ILLabel[])Operand;
				for (int j = 0; j < array.Length; j++)
				{
					if (j > 0)
					{
						output.Write(",", BoxedTextColor.Punctuation);
						output.Write(" ", BoxedTextColor.Text);
					}
					output.Write(array[j].Name, array[j].Reference, DecompilerReferenceFlags.Local, BoxedTextColor.Label);
				}
			}
			else if ((Operand as IMethod)?.MethodSig != null)
			{
				IMethod method = (IMethod)Operand;
				if (method.DeclaringType != null)
				{
					method.DeclaringType.WriteTo(output, ILNameSyntax.ShortTypeName);
					output.Write("::", BoxedTextColor.Operator);
				}
				output.Write(method.Name, method, DecompilerReferenceFlags.None, CSharpMetadataTextColorProvider.Instance.GetColor(method));
			}
			else if (Operand is IField)
			{
				IField field = (IField)Operand;
				field.DeclaringType.WriteTo(output, ILNameSyntax.ShortTypeName);
				output.Write("::", BoxedTextColor.Operator);
				output.Write(field.Name, field, DecompilerReferenceFlags.None, CSharpMetadataTextColorProvider.Instance.GetColor(field));
			}
			else if (Operand is ILVariable)
			{
				ILVariable iLVariable2 = (ILVariable)Operand;
				object textReferenceObject2 = iLVariable2.GetTextReferenceObject();
				output.Write(iLVariable2.Name, textReferenceObject2, DecompilerReferenceFlags.Local, iLVariable2.IsParameter ? BoxedTextColor.Parameter : BoxedTextColor.Local);
			}
			else
			{
				DisassemblerHelpers.WriteOperand(output, Operand);
			}
			flag = false;
		}
		foreach (ILExpression argument in Arguments)
		{
			if (!flag)
			{
				output.Write(",", BoxedTextColor.Punctuation);
				output.Write(" ", BoxedTextColor.Text);
			}
			argument.WriteTo(output, null);
			flag = false;
		}
		output.Write(")", BoxedTextColor.Punctuation);
		output.AddBracePair(new TextSpan(nextPosition2, 1), new TextSpan(output.Length - 1, 1), CodeBracesRangeFlags.BraceKind_Parentheses);
		UpdateDebugInfo(builder, nextPosition, output.NextPosition, GetSelfAndChildrenRecursiveILSpans());
	}
}
