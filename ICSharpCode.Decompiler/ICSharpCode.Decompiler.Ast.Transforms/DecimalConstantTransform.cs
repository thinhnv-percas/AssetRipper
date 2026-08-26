using System;
using System.Linq;
using dnlib.DotNet;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.Decompiler.Ast.Transforms;

public class DecimalConstantTransform : DepthFirstAstVisitor<object, object>, IAstTransformPoolObject, IAstTransform
{
	private static readonly PrimitiveType decimalType = new PrimitiveType("decimal");

	private static readonly UTF8String systemRuntimeCompilerServicesString = new UTF8String("System.Runtime.CompilerServices");

	private static readonly UTF8String decimalConstantAttributeString = new UTF8String("DecimalConstantAttribute");

	public void Reset(DecompilerContext context)
	{
	}

	public override object VisitFieldDeclaration(FieldDeclaration fieldDeclaration, object data)
	{
		if ((fieldDeclaration.Modifiers & (Modifiers.Static | Modifiers.Readonly)) == (Modifiers.Static | Modifiers.Readonly) && decimalType.IsMatch(fieldDeclaration.ReturnType))
		{
			foreach (AttributeSection attribute in fieldDeclaration.Attributes)
			{
				foreach (ICSharpCode.NRefactory.CSharp.Attribute attribute2 in attribute.Attributes)
				{
					ITypeDefOrRef typeDefOrRef = attribute2.Type.Annotation<ITypeDefOrRef>();
					if (typeDefOrRef != null && typeDefOrRef.Compare(systemRuntimeCompilerServicesString, decimalConstantAttributeString))
					{
						attribute2.Remove();
						if (attribute.Attributes.Count == 0)
						{
							attribute.Remove();
						}
						fieldDeclaration.Modifiers = (fieldDeclaration.Modifiers & ~(Modifiers.Static | Modifiers.Readonly)) | Modifiers.Const;
						Comment[] array = fieldDeclaration.GetChildrenByRole(Roles.Comment).ToArray();
						Array.Reverse(array);
						Comment[] array2 = array;
						foreach (Comment comment in array2)
						{
							comment.Remove();
							fieldDeclaration.InsertChildAfter(null, comment, Roles.Comment);
						}
						return null;
					}
				}
			}
		}
		return null;
	}

	public override object VisitParameterDeclaration(ParameterDeclaration parameterDeclaration, object data)
	{
		foreach (AttributeSection attribute in parameterDeclaration.Attributes)
		{
			foreach (ICSharpCode.NRefactory.CSharp.Attribute attribute2 in attribute.Attributes)
			{
				ITypeDefOrRef typeDefOrRef = attribute2.Type.Annotation<ITypeDefOrRef>();
				if (typeDefOrRef != null && typeDefOrRef.Compare(systemRuntimeCompilerServicesString, decimalConstantAttributeString))
				{
					attribute2.Remove();
					if (attribute.Attributes.Count == 0)
					{
						attribute.Remove();
					}
					return null;
				}
			}
		}
		return null;
	}

	public void Run(AstNode compilationUnit)
	{
		compilationUnit.AcceptVisitor(this, null);
	}
}
