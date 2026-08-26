using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp.Transforms;

public class FixNameCollisions : IAstTransform
{
	public void Run(AstNode rootNode, TransformContext context)
	{
		Dictionary<ISymbol, string> dictionary = new Dictionary<ISymbol, string>();
		foreach (TypeDeclaration item in Enumerable.OfType<TypeDeclaration>((IEnumerable)rootNode.DescendantsAndSelf))
		{
			HashSet<string> val = Enumerable.Select<EntityDeclaration, string>((IEnumerable<EntityDeclaration>)item.Members, (Func<EntityDeclaration, string>)delegate(EntityDeclaration m)
			{
				AstType childByRole = m.GetChildByRole(EntityDeclaration.PrivateImplementationTypeRole);
				return childByRole.IsNull ? m.Name : string.Concat(childByRole, ".", m.Name);
			}).ToHashSet();
			foreach (FieldDeclaration item2 in Enumerable.OfType<FieldDeclaration>((IEnumerable)item.Members))
			{
				if (item2.Variables.Count != 1)
				{
					continue;
				}
				string name = Enumerable.Single<VariableInitializer>((IEnumerable<VariableInitializer>)item2.Variables).Name;
				ISymbol symbol = item2.GetSymbol();
				if (val.Contains(name) && ((IField)symbol).Accessibility == Accessibility.Private)
				{
					string text = PickNewName((ISet<string>)val, name);
					if (symbol != null)
					{
						Enumerable.Single<VariableInitializer>((IEnumerable<VariableInitializer>)item2.Variables).Name = text;
						dictionary[symbol] = text;
					}
				}
			}
		}
		foreach (AstNode item3 in rootNode.DescendantsAndSelf)
		{
			if (item3 is IdentifierExpression || item3 is MemberReferenceExpression)
			{
				ISymbol symbol2 = item3.GetSymbol();
				if (symbol2 != null && dictionary.TryGetValue(symbol2, out var value))
				{
					item3.GetChildByRole(Roles.Identifier).Name = value;
				}
			}
		}
	}

	private string PickNewName(ISet<string> memberNames, string name)
	{
		if (!memberNames.Contains("m_" + name))
		{
			return "m_" + name;
		}
		int num = 2;
		string text;
		while (true)
		{
			text = name + num;
			if (!memberNames.Contains(text))
			{
				break;
			}
			num = checked(num + 1);
		}
		return text;
	}
}
