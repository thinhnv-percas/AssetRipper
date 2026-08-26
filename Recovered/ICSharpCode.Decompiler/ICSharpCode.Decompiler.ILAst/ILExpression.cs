using ICSharpCode.Decompiler.Disassembler;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.ILAst
{
	public class ILExpression : ILNode
	{
		public static readonly object AnyOperand = new object();

		public ILCode Code
		{
			get;
			set;
		}

		public object Operand
		{
			get;
			set;
		}

		public List<ILExpression> Arguments
		{
			get;
			set;
		}

		public ILExpressionPrefix[] Prefixes
		{
			get;
			set;
		}

		public List<ILRange> ILRanges
		{
			get;
			set;
		}

		public TypeReference ExpectedType
		{
			get;
			set;
		}

		public TypeReference InferredType
		{
			get;
			set;
		}

		public ILExpression(ILCode code, object operand, List<ILExpression> args)
		{
			if (operand is ILExpression)
			{
				throw new ArgumentException("operand");
			}
			Code = code;
			Operand = operand;
			Arguments = new List<ILExpression>(args);
			ILRanges = new List<ILRange>(1);
		}

		public ILExpression(ILCode code, object operand, params ILExpression[] args)
		{
			if (operand is ILExpression)
			{
				throw new ArgumentException("operand");
			}
			Code = code;
			Operand = operand;
			Arguments = new List<ILExpression>(args);
			ILRanges = new List<ILRange>(1);
		}

		public void AddPrefix(ILExpressionPrefix prefix)
		{
			ILExpressionPrefix[] array = Prefixes;
			if (array == null)
			{
				array = new ILExpressionPrefix[1];
			}
			else
			{
				Array.Resize(ref array, array.Length + 1);
			}
			array[array.Length - 1] = prefix;
			Prefixes = array;
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

		public override IEnumerable<ILNode> GetChildren()
		{
			return Arguments;
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
				return new ILLabel[1]
				{
					(ILLabel)Operand
				};
			}
			if (Operand is ILLabel[])
			{
				return (ILLabel[])Operand;
			}
			return new ILLabel[0];
		}

		public override void WriteTo(ITextOutput output)
		{
			if (Operand is ILVariable && ((ILVariable)Operand).IsGenerated)
			{
				if (Code == ILCode.Stloc && InferredType == null)
				{
					output.Write(((ILVariable)Operand).Name);
					output.Write(" = ");
					Arguments.First().WriteTo(output);
					return;
				}
				if (Code == ILCode.Ldloc)
				{
					output.Write(((ILVariable)Operand).Name);
					if (InferredType != null)
					{
						output.Write(':');
						InferredType.WriteTo(output, ILNameSyntax.ShortTypeName);
						if (ExpectedType != null && ExpectedType.FullName != InferredType.FullName)
						{
							output.Write("[exp:");
							ExpectedType.WriteTo(output, ILNameSyntax.ShortTypeName);
							output.Write(']');
						}
					}
					return;
				}
			}
			if (Prefixes != null)
			{
				ILExpressionPrefix[] prefixes = Prefixes;
				foreach (ILExpressionPrefix iLExpressionPrefix in prefixes)
				{
					output.Write(iLExpressionPrefix.Code.GetName());
					output.Write(". ");
				}
			}
			output.Write(Code.GetName());
			if (InferredType != null)
			{
				output.Write(':');
				InferredType.WriteTo(output, ILNameSyntax.ShortTypeName);
				if (ExpectedType != null && ExpectedType.FullName != InferredType.FullName)
				{
					output.Write("[exp:");
					ExpectedType.WriteTo(output, ILNameSyntax.ShortTypeName);
					output.Write(']');
				}
			}
			else if (ExpectedType != null)
			{
				output.Write("[exp:");
				ExpectedType.WriteTo(output, ILNameSyntax.ShortTypeName);
				output.Write(']');
			}
			output.Write('(');
			bool flag = true;
			if (Operand != null)
			{
				if (Operand is ILLabel)
				{
					output.WriteReference(((ILLabel)Operand).Name, Operand);
				}
				else if (Operand is ILLabel[])
				{
					ILLabel[] array = (ILLabel[])Operand;
					for (int j = 0; j < array.Length; j++)
					{
						if (j > 0)
						{
							output.Write(", ");
						}
						output.WriteReference(array[j].Name, array[j]);
					}
				}
				else if (Operand is MethodReference)
				{
					MethodReference methodReference = (MethodReference)Operand;
					if (methodReference.DeclaringType != null)
					{
						methodReference.DeclaringType.WriteTo(output, ILNameSyntax.ShortTypeName);
						output.Write("::");
					}
					output.WriteReference(methodReference.Name, methodReference);
				}
				else if (Operand is FieldReference)
				{
					FieldReference fieldReference = (FieldReference)Operand;
					fieldReference.DeclaringType.WriteTo(output, ILNameSyntax.ShortTypeName);
					output.Write("::");
					output.WriteReference(fieldReference.Name, fieldReference);
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
					output.Write(", ");
				}
				argument.WriteTo(output);
				flag = false;
			}
			output.Write(')');
		}
	}
}
