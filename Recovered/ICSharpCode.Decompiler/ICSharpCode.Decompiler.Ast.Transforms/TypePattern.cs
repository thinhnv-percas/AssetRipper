using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using Mono.Cecil;
using System;
using System.Linq;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	internal sealed class TypePattern : Pattern
	{
		private readonly string ns;

		private readonly string name;

		public TypePattern(Type type)
		{
			ns = type.Namespace;
			name = type.Name;
		}

		public override bool DoMatch(INode other, Match match)
		{
			ComposedType composedType = other as ComposedType;
			AstType astType;
			if (composedType != null && !composedType.HasNullableSpecifier && composedType.PointerRank == 0 && !composedType.ArraySpecifiers.Any())
			{
				astType = composedType.BaseType;
			}
			else
			{
				astType = (other as AstType);
				if (astType == null)
				{
					return false;
				}
			}
			TypeReference typeReference = astType.Annotation<TypeReference>();
			if (typeReference != null && typeReference.Namespace == ns)
			{
				return typeReference.Name == name;
			}
			return false;
		}

		public override string ToString()
		{
			return name;
		}
	}
}
