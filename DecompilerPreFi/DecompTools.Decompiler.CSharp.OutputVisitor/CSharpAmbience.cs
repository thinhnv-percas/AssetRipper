using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.Output;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.OutputVisitor;

public class CSharpAmbience : IAmbience
{
	public ConversionFlags ConversionFlags { get; set; }

	public string ConvertSymbol(ISymbol symbol)
	{
		if (symbol == null)
		{
			throw new ArgumentNullException("symbol");
		}
		StringWriter stringWriter = new StringWriter();
		ConvertSymbol(symbol, new TextWriterTokenWriter(stringWriter), FormattingOptionsFactory.CreateEmpty());
		return stringWriter.ToString();
	}

	public void ConvertSymbol(ISymbol symbol, TokenWriter writer, CSharpFormattingOptions formattingPolicy)
	{
		if (symbol == null)
		{
			throw new ArgumentNullException("symbol");
		}
		if (writer == null)
		{
			throw new ArgumentNullException("writer");
		}
		if (formattingPolicy == null)
		{
			throw new ArgumentNullException("formattingPolicy");
		}
		TypeSystemAstBuilder typeSystemAstBuilder = CreateAstBuilder();
		AstNode astNode = typeSystemAstBuilder.ConvertSymbol(symbol);
		if (astNode is EntityDeclaration entityDeclaration)
		{
			PrintModifiers(entityDeclaration.Modifiers, writer);
		}
		if ((ConversionFlags & ConversionFlags.ShowDefinitionKeyword) == ConversionFlags.ShowDefinitionKeyword)
		{
			if (astNode is TypeDeclaration)
			{
				switch (((TypeDeclaration)astNode).ClassType)
				{
				case ClassType.Class:
					writer.WriteKeyword(Roles.ClassKeyword, "class");
					break;
				case ClassType.Struct:
					writer.WriteKeyword(Roles.StructKeyword, "struct");
					break;
				case ClassType.Interface:
					writer.WriteKeyword(Roles.InterfaceKeyword, "interface");
					break;
				case ClassType.Enum:
					writer.WriteKeyword(Roles.EnumKeyword, "enum");
					break;
				default:
					throw new Exception("Invalid value for ClassType");
				}
				writer.Space();
			}
			else if (astNode is DelegateDeclaration)
			{
				writer.WriteKeyword(Roles.DelegateKeyword, "delegate");
				writer.Space();
			}
			else if (astNode is EventDeclaration)
			{
				writer.WriteKeyword(EventDeclaration.EventKeywordRole, "event");
				writer.Space();
			}
			else if (astNode is NamespaceDeclaration)
			{
				writer.WriteKeyword(Roles.NamespaceKeyword, "namespace");
				writer.Space();
			}
		}
		if ((ConversionFlags & ConversionFlags.PlaceReturnTypeAfterParameterList) != ConversionFlags.PlaceReturnTypeAfterParameterList && (ConversionFlags & ConversionFlags.ShowReturnType) == ConversionFlags.ShowReturnType)
		{
			AstType childByRole = astNode.GetChildByRole(Roles.Type);
			if (!childByRole.IsNull)
			{
				childByRole.AcceptVisitor(new CSharpOutputVisitor(writer, formattingPolicy));
				writer.Space();
			}
		}
		if (symbol is ITypeDefinition)
		{
			WriteTypeDeclarationName((ITypeDefinition)symbol, writer, formattingPolicy);
		}
		else if (symbol is IMember)
		{
			WriteMemberDeclarationName((IMember)symbol, writer, formattingPolicy);
		}
		else
		{
			writer.WriteIdentifier(Identifier.Create(symbol.Name));
		}
		if ((ConversionFlags & ConversionFlags.ShowParameterList) == ConversionFlags.ShowParameterList && HasParameters(symbol))
		{
			writer.WriteToken((symbol.SymbolKind == SymbolKind.Indexer) ? Roles.LBracket : Roles.LPar, (symbol.SymbolKind == SymbolKind.Indexer) ? "[" : "(");
			bool flag = true;
			foreach (ParameterDeclaration item in astNode.GetChildrenByRole(Roles.Parameter))
			{
				if ((ConversionFlags & ConversionFlags.ShowParameterModifiers) == 0)
				{
					item.ParameterModifier = ParameterModifier.None;
				}
				if ((ConversionFlags & ConversionFlags.ShowParameterDefaultValues) == 0)
				{
					item.DefaultExpression.Detach();
				}
				if (flag)
				{
					flag = false;
				}
				else
				{
					writer.WriteToken(Roles.Comma, ",");
					writer.Space();
				}
				item.AcceptVisitor(new CSharpOutputVisitor(writer, formattingPolicy));
			}
			writer.WriteToken((symbol.SymbolKind == SymbolKind.Indexer) ? Roles.RBracket : Roles.RPar, (symbol.SymbolKind == SymbolKind.Indexer) ? "]" : ")");
		}
		if ((ConversionFlags & ConversionFlags.PlaceReturnTypeAfterParameterList) == ConversionFlags.PlaceReturnTypeAfterParameterList && (ConversionFlags & ConversionFlags.ShowReturnType) == ConversionFlags.ShowReturnType)
		{
			AstType childByRole2 = astNode.GetChildByRole(Roles.Type);
			if (!childByRole2.IsNull)
			{
				writer.Space();
				writer.WriteToken(Roles.Colon, ":");
				writer.Space();
				childByRole2.AcceptVisitor(new CSharpOutputVisitor(writer, formattingPolicy));
			}
		}
		if ((ConversionFlags & ConversionFlags.ShowBody) != ConversionFlags.ShowBody || astNode is TypeDeclaration)
		{
			return;
		}
		if (symbol is IProperty property)
		{
			writer.Space();
			writer.WriteToken(Roles.LBrace, "{");
			writer.Space();
			if (property.CanGet)
			{
				writer.WriteKeyword(PropertyDeclaration.GetKeywordRole, "get");
				writer.WriteToken(Roles.Semicolon, ";");
				writer.Space();
			}
			if (property.CanSet)
			{
				writer.WriteKeyword(PropertyDeclaration.SetKeywordRole, "set");
				writer.WriteToken(Roles.Semicolon, ";");
				writer.Space();
			}
			writer.WriteToken(Roles.RBrace, "}");
		}
		else
		{
			writer.WriteToken(Roles.Semicolon, ";");
		}
	}

	private static bool HasParameters(ISymbol e)
	{
		switch (e.SymbolKind)
		{
		case SymbolKind.TypeDefinition:
			return ((ITypeDefinition)e).Kind == TypeKind.Delegate;
		case SymbolKind.Indexer:
		case SymbolKind.Method:
		case SymbolKind.Operator:
		case SymbolKind.Constructor:
		case SymbolKind.Destructor:
			return true;
		default:
			return false;
		}
	}

	private TypeSystemAstBuilder CreateAstBuilder()
	{
		TypeSystemAstBuilder typeSystemAstBuilder = new TypeSystemAstBuilder();
		typeSystemAstBuilder.AddTypeReferenceAnnotations = true;
		typeSystemAstBuilder.ShowTypeParametersForUnboundTypes = true;
		typeSystemAstBuilder.ShowModifiers = (ConversionFlags & ConversionFlags.ShowModifiers) == ConversionFlags.ShowModifiers;
		typeSystemAstBuilder.ShowAccessibility = (ConversionFlags & ConversionFlags.ShowAccessibility) == ConversionFlags.ShowAccessibility;
		typeSystemAstBuilder.AlwaysUseShortTypeNames = (ConversionFlags & ConversionFlags.UseFullyQualifiedTypeNames) != ConversionFlags.UseFullyQualifiedTypeNames;
		typeSystemAstBuilder.ShowParameterNames = (ConversionFlags & ConversionFlags.ShowParameterNames) == ConversionFlags.ShowParameterNames;
		return typeSystemAstBuilder;
	}

	private void WriteTypeDeclarationName(ITypeDefinition typeDef, TokenWriter writer, CSharpFormattingOptions formattingPolicy)
	{
		TypeSystemAstBuilder typeSystemAstBuilder = CreateAstBuilder();
		EntityDeclaration entityDeclaration = typeSystemAstBuilder.ConvertEntity(typeDef);
		if (typeDef.DeclaringTypeDefinition != null && ((ConversionFlags & ConversionFlags.ShowDeclaringType) == ConversionFlags.ShowDeclaringType || (ConversionFlags & ConversionFlags.UseFullyQualifiedEntityNames) == ConversionFlags.UseFullyQualifiedEntityNames))
		{
			WriteTypeDeclarationName(typeDef.DeclaringTypeDefinition, writer, formattingPolicy);
			writer.WriteToken(Roles.Dot, ".");
		}
		else if ((ConversionFlags & ConversionFlags.UseFullyQualifiedEntityNames) == ConversionFlags.UseFullyQualifiedEntityNames && !string.IsNullOrEmpty(typeDef.Namespace))
		{
			WriteQualifiedName(typeDef.Namespace, writer, formattingPolicy);
			writer.WriteToken(Roles.Dot, ".");
		}
		writer.WriteIdentifier(entityDeclaration.NameToken);
		WriteTypeParameters(entityDeclaration, writer, formattingPolicy);
	}

	private void WriteMemberDeclarationName(IMember member, TokenWriter writer, CSharpFormattingOptions formattingPolicy)
	{
		TypeSystemAstBuilder typeSystemAstBuilder = CreateAstBuilder();
		EntityDeclaration entityDeclaration = typeSystemAstBuilder.ConvertEntity(member);
		if ((ConversionFlags & ConversionFlags.ShowDeclaringType) == ConversionFlags.ShowDeclaringType && member.DeclaringType != null)
		{
			ConvertType(member.DeclaringType, writer, formattingPolicy);
			writer.WriteToken(Roles.Dot, ".");
		}
		switch (member.SymbolKind)
		{
		case SymbolKind.Indexer:
			writer.WriteKeyword(Roles.Identifier, "this");
			break;
		case SymbolKind.Constructor:
			WriteQualifiedName(member.DeclaringType.Name, writer, formattingPolicy);
			break;
		case SymbolKind.Destructor:
			writer.WriteToken(DestructorDeclaration.TildeRole, "~");
			WriteQualifiedName(member.DeclaringType.Name, writer, formattingPolicy);
			break;
		case SymbolKind.Operator:
		{
			string name = member.Name;
			if (!(name == "op_Implicit"))
			{
				if (name == "op_Explicit")
				{
					writer.WriteKeyword(OperatorDeclaration.ExplicitRole, "explicit");
					writer.Space();
					writer.WriteKeyword(OperatorDeclaration.OperatorKeywordRole, "operator");
					writer.Space();
					ConvertType(member.ReturnType, writer, formattingPolicy);
					break;
				}
				writer.WriteKeyword(OperatorDeclaration.OperatorKeywordRole, "operator");
				writer.Space();
				OperatorType? operatorType = OperatorDeclaration.GetOperatorType(member.Name);
				if (operatorType.HasValue)
				{
					writer.WriteToken(OperatorDeclaration.GetRole(operatorType.Value), OperatorDeclaration.GetToken(operatorType.Value));
				}
				else
				{
					writer.WriteIdentifier(entityDeclaration.NameToken);
				}
			}
			else
			{
				writer.WriteKeyword(OperatorDeclaration.ImplicitRole, "implicit");
				writer.Space();
				writer.WriteKeyword(OperatorDeclaration.OperatorKeywordRole, "operator");
				writer.Space();
				ConvertType(member.ReturnType, writer, formattingPolicy);
			}
			break;
		}
		default:
			writer.WriteIdentifier(Identifier.Create(member.Name));
			break;
		}
		WriteTypeParameters(entityDeclaration, writer, formattingPolicy);
	}

	private void WriteTypeParameters(EntityDeclaration node, TokenWriter writer, CSharpFormattingOptions formattingPolicy)
	{
		if ((ConversionFlags & ConversionFlags.ShowTypeParameterList) == ConversionFlags.ShowTypeParameterList)
		{
			CSharpOutputVisitor cSharpOutputVisitor = new CSharpOutputVisitor(writer, formattingPolicy);
			IEnumerable<TypeParameterDeclaration> enumerable = node.GetChildrenByRole(Roles.TypeParameter);
			if ((ConversionFlags & ConversionFlags.ShowTypeParameterVarianceModifier) == 0)
			{
				enumerable = Enumerable.Select<TypeParameterDeclaration, TypeParameterDeclaration>(enumerable, (Func<TypeParameterDeclaration, TypeParameterDeclaration>)RemoveVarianceModifier);
			}
			cSharpOutputVisitor.WriteTypeParameters(enumerable);
		}
		static TypeParameterDeclaration RemoveVarianceModifier(TypeParameterDeclaration decl)
		{
			decl.Variance = VarianceModifier.Invariant;
			return decl;
		}
	}

	private void PrintModifiers(Modifiers modifiers, TokenWriter writer)
	{
		foreach (Modifiers allModifier in CSharpModifierToken.AllModifiers)
		{
			if ((modifiers & allModifier) == allModifier)
			{
				writer.WriteKeyword(EntityDeclaration.ModifierRole, CSharpModifierToken.GetModifierName(allModifier));
				writer.Space();
			}
		}
	}

	private void WriteQualifiedName(string name, TokenWriter writer, CSharpFormattingOptions formattingPolicy)
	{
		AstType astType = AstType.Create(name);
		CSharpOutputVisitor visitor = new CSharpOutputVisitor(writer, formattingPolicy);
		astType.AcceptVisitor(visitor);
	}

	public string ConvertVariable(IVariable v)
	{
		TypeSystemAstBuilder typeSystemAstBuilder = CreateAstBuilder();
		AstNode astNode = typeSystemAstBuilder.ConvertVariable(v);
		return astNode.ToString().TrimEnd(';', '\r', '\n', '\u2028');
	}

	public string ConvertType(IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		TypeSystemAstBuilder typeSystemAstBuilder = CreateAstBuilder();
		typeSystemAstBuilder.AlwaysUseShortTypeNames = (ConversionFlags & ConversionFlags.UseFullyQualifiedEntityNames) != ConversionFlags.UseFullyQualifiedEntityNames;
		AstType astType = typeSystemAstBuilder.ConvertType(type);
		return astType.ToString();
	}

	public void ConvertType(IType type, TokenWriter writer, CSharpFormattingOptions formattingPolicy)
	{
		TypeSystemAstBuilder typeSystemAstBuilder = CreateAstBuilder();
		typeSystemAstBuilder.AlwaysUseShortTypeNames = (ConversionFlags & ConversionFlags.UseFullyQualifiedEntityNames) != ConversionFlags.UseFullyQualifiedEntityNames;
		AstType astType = typeSystemAstBuilder.ConvertType(type);
		astType.AcceptVisitor(new CSharpOutputVisitor(writer, formattingPolicy));
	}

	public string ConvertConstantValue(object constantValue)
	{
		return TextWriterTokenWriter.PrintPrimitiveValue(constantValue);
	}

	public string WrapComment(string comment)
	{
		return "// " + comment;
	}
}
