using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.NRefactory.CSharp;

namespace dnSpy.Decompiler.ILSpy.Core.CSharp;

internal sealed class DecompilePartialTransform : IAstTransform
{
	private readonly TypeDef type;

	private readonly HashSet<IMemberDef> definitions;

	private readonly bool showDefinitions;

	private readonly bool addPartialKeyword;

	private readonly HashSet<ITypeDefOrRef> ifacesToRemove;

	public DecompilePartialTransform(TypeDef type, HashSet<IMemberDef> definitions, bool showDefinitions, bool addPartialKeyword, IEnumerable<ITypeDefOrRef> ifacesToRemove)
	{
		this.type = type;
		this.definitions = definitions;
		this.showDefinitions = showDefinitions;
		this.addPartialKeyword = addPartialKeyword;
		this.ifacesToRemove = new HashSet<ITypeDefOrRef>(ifacesToRemove, TypeEqualityComparer.Instance);
	}

	public void Run(AstNode compilationUnit)
	{
		foreach (EntityDeclaration item in compilationUnit.Descendants.OfType<EntityDeclaration>())
		{
			IMemberDef memberDef = item.Annotation<IMemberDef>();
			if (memberDef == null)
			{
				continue;
			}
			if (memberDef == type)
			{
				if (!(item is TypeDeclaration typeDeclaration))
				{
					continue;
				}
				if (addPartialKeyword)
				{
					if (typeDeclaration.ClassType != ClassType.Enum)
					{
						typeDeclaration.Modifiers |= Modifiers.Partial;
					}
					Comment[] array = item.GetChildrenByRole(Roles.Comment).Reverse().ToArray();
					Comment[] array2 = array;
					foreach (Comment comment in array2)
					{
						comment.Remove();
						item.InsertChildAfter(null, comment, Roles.Comment);
					}
				}
				foreach (AstType baseType in typeDeclaration.BaseTypes)
				{
					ITypeDefOrRef typeDefOrRef = baseType.Annotation<ITypeDefOrRef>();
					if (typeDefOrRef != null && ifacesToRemove.Contains(typeDefOrRef))
					{
						baseType.Remove();
					}
				}
			}
			else if (showDefinitions)
			{
				if (!definitions.Contains(memberDef))
				{
					item.Remove();
				}
			}
			else if (definitions.Contains(memberDef))
			{
				item.Remove();
			}
		}
	}
}
