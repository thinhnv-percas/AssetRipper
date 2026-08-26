using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using ICSharpCode.Decompiler.Ast;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.VB.Ast;
using ICSharpCode.NRefactory.VB.Visitors;

namespace dnSpy.Decompiler.ILSpy.Core.VisualBasic;

internal sealed class ILSpyEnvironmentProvider : IEnvironmentProvider
{
	private readonly StringBuilder sb;

	public string RootNamespace => "";

	public ILSpyEnvironmentProvider(StringBuilder sb = null)
	{
		this.sb = sb ?? new StringBuilder();
	}

	public string GetTypeNameForAttribute(ICSharpCode.NRefactory.CSharp.Attribute attribute)
	{
		IMemberRef memberRef = attribute.Type.Annotations.OfType<IMemberRef>().FirstOrDefault();
		if (memberRef != null)
		{
			return memberRef.FullName;
		}
		return string.Empty;
	}

	public ICSharpCode.NRefactory.TypeSystem.IType ResolveType(ICSharpCode.NRefactory.VB.Ast.AstType type, ICSharpCode.NRefactory.VB.Ast.TypeDeclaration entity = null)
	{
		return SpecialType.UnknownType;
	}

	public TypeKind GetTypeKindForAstType(ICSharpCode.NRefactory.CSharp.AstType type)
	{
		ITypeDefOrRef typeDefOrRef = type.Annotation<ITypeDefOrRef>();
		if (typeDefOrRef == null)
		{
			return TypeKind.Unknown;
		}
		TypeDef typeDef = typeDefOrRef.ResolveTypeDef();
		if (typeDef == null)
		{
			return TypeKind.Unknown;
		}
		if (typeDef.IsClass)
		{
			return TypeKind.Class;
		}
		if (typeDef.IsInterface)
		{
			return TypeKind.Interface;
		}
		if (typeDef.IsEnum)
		{
			return TypeKind.Enum;
		}
		if (typeDef.IsValueType)
		{
			return TypeKind.Struct;
		}
		return TypeKind.Unknown;
	}

	public TypeCode ResolveExpression(ICSharpCode.NRefactory.CSharp.Expression expression)
	{
		TypeInformation typeInformation = expression.Annotations.OfType<TypeInformation>().FirstOrDefault();
		if (typeInformation == null || typeInformation.InferredType == null)
		{
			return TypeCode.Object;
		}
		TypeDef typeDef = typeInformation.InferredType.ScopeType.ResolveTypeDef();
		if (typeDef == null)
		{
			return TypeCode.Object;
		}
		string fullName = typeDef.FullName;
		if (fullName == "System.String")
		{
			return TypeCode.String;
		}
		return TypeCode.Object;
	}

	public bool? IsReferenceType(ICSharpCode.NRefactory.CSharp.Expression expression)
	{
		if (expression is NullReferenceExpression)
		{
			return true;
		}
		TypeInformation typeInformation = expression.Annotations.OfType<TypeInformation>().FirstOrDefault();
		if (typeInformation == null || typeInformation.InferredType == null)
		{
			return null;
		}
		TypeDef typeDef = typeInformation.InferredType.ScopeType.ResolveTypeDef();
		if (typeDef == null)
		{
			return null;
		}
		return !typeDef.IsValueType;
	}

	public IEnumerable<InterfaceMemberSpecifier> CreateMemberSpecifiersForInterfaces(IEnumerable<ICSharpCode.NRefactory.VB.Ast.AstType> interfaces)
	{
		foreach (ICSharpCode.NRefactory.VB.Ast.AstType type in interfaces)
		{
			TypeDef def = type.Annotation<ITypeDefOrRef>().ResolveTypeDef();
			if (def == null)
			{
				continue;
			}
			foreach (MethodDef item in def.Methods.Where((MethodDef m) => !m.Name.StartsWith("get_") && !m.Name.StartsWith("set_")))
			{
				yield return InterfaceMemberSpecifier.CreateWithColor((ICSharpCode.NRefactory.VB.Ast.AstType)type.Clone(), item.Name, VisualBasicMetadataTextColorProvider.Instance.GetColor(item));
			}
			foreach (PropertyDef property in def.Properties)
			{
				yield return InterfaceMemberSpecifier.CreateWithColor((ICSharpCode.NRefactory.VB.Ast.AstType)type.Clone(), property.Name, VisualBasicMetadataTextColorProvider.Instance.GetColor(property));
			}
		}
	}

	public bool HasEvent(ICSharpCode.NRefactory.VB.Ast.Expression expression)
	{
		return expression.Annotation<EventDef>() != null;
	}

	public bool IsMethodGroup(ICSharpCode.NRefactory.CSharp.Expression expression)
	{
		MethodDef methodDef = expression.Annotation<MethodDef>();
		if (methodDef == null)
		{
			return false;
		}
		if (expression.Annotation<PropertyDef>() == null)
		{
			return expression.Annotation<EventDef>() == null;
		}
		return false;
	}

	public ICSharpCode.NRefactory.CSharp.ParameterDeclaration[] GetParametersForProperty(ICSharpCode.NRefactory.CSharp.PropertyDeclaration property)
	{
		PropertyDef propertyDef = property.Annotation<PropertyDef>();
		if (propertyDef == null)
		{
			return new ICSharpCode.NRefactory.CSharp.ParameterDeclaration[0];
		}
		sb.Clear();
		MethodDef getMethod = propertyDef.GetMethod;
		if (getMethod != null)
		{
			return (from p in getMethod.Parameters
				where p.IsNormalMethodParameter
				select new ICSharpCode.NRefactory.CSharp.ParameterDeclaration(AstBuilder.ConvertType(p.Type, sb), p.Name, GetModifiers(p))).ToArray();
		}
		MethodDef setMethod = propertyDef.SetMethod;
		if (setMethod != null)
		{
			Parameter[] array = setMethod.Parameters.Where((Parameter p) => p.IsNormalMethodParameter).ToArray();
			if (array.Length > 1)
			{
				return (from p in array.Take(array.Length - 1)
					select new ICSharpCode.NRefactory.CSharp.ParameterDeclaration(AstBuilder.ConvertType(p.Type, sb), p.Name, GetModifiers(p))).ToArray();
			}
		}
		return new ICSharpCode.NRefactory.CSharp.ParameterDeclaration[0];
	}

	private ParameterModifier GetModifiers(Parameter p)
	{
		ParamDef paramDef = p.ParamDef;
		if (paramDef != null)
		{
			if (paramDef.IsOut && paramDef.IsIn)
			{
				return ParameterModifier.Ref;
			}
			if (paramDef.IsOut)
			{
				return ParameterModifier.Out;
			}
		}
		return ParameterModifier.None;
	}
}
