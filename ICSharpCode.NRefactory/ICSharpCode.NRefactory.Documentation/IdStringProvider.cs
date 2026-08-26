using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;

namespace ICSharpCode.NRefactory.Documentation;

public static class IdStringProvider
{
	public static string GetIdString(this IEntity entity)
	{
		StringBuilder stringBuilder = new StringBuilder();
		switch (entity.SymbolKind)
		{
		case SymbolKind.TypeDefinition:
			stringBuilder.Append("T:");
			AppendTypeName(stringBuilder, (ITypeDefinition)entity, explicitInterfaceImpl: false);
			return stringBuilder.ToString();
		case SymbolKind.Field:
			stringBuilder.Append("F:");
			break;
		case SymbolKind.Property:
		case SymbolKind.Indexer:
			stringBuilder.Append("P:");
			break;
		case SymbolKind.Event:
			stringBuilder.Append("E:");
			break;
		default:
			stringBuilder.Append("M:");
			break;
		}
		IMember member = (IMember)entity;
		if (member.DeclaringType != null)
		{
			AppendTypeName(stringBuilder, member.DeclaringType, explicitInterfaceImpl: false);
			stringBuilder.Append('.');
		}
		if (member.IsExplicitInterfaceImplementation && member.Name.IndexOf('.') < 0 && member.ImplementedInterfaceMembers.Count == 1)
		{
			AppendTypeName(stringBuilder, member.ImplementedInterfaceMembers[0].DeclaringType, explicitInterfaceImpl: true);
			stringBuilder.Append('#');
		}
		stringBuilder.Append(member.Name.Replace('.', '#'));
		if (member is IMethod method && method.TypeParameters.Count > 0)
		{
			stringBuilder.Append("``");
			stringBuilder.Append(method.TypeParameters.Count);
		}
		if (member is IParameterizedMember parameterizedMember && parameterizedMember.Parameters.Count > 0)
		{
			stringBuilder.Append('(');
			IList<IParameter> parameters = parameterizedMember.Parameters;
			for (int i = 0; i < parameters.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				AppendTypeName(stringBuilder, parameters[i].Type, explicitInterfaceImpl: false);
			}
			stringBuilder.Append(')');
		}
		if (member.SymbolKind == SymbolKind.Operator && (member.Name == "op_Implicit" || member.Name == "op_Explicit"))
		{
			stringBuilder.Append('~');
			AppendTypeName(stringBuilder, member.ReturnType, explicitInterfaceImpl: false);
		}
		return stringBuilder.ToString();
	}

	public static string GetTypeName(IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		StringBuilder stringBuilder = new StringBuilder();
		AppendTypeName(stringBuilder, type, explicitInterfaceImpl: false);
		return stringBuilder.ToString();
	}

	private static void AppendTypeName(StringBuilder b, IType type, bool explicitInterfaceImpl)
	{
		switch (type.Kind)
		{
		case TypeKind.Dynamic:
			b.Append(explicitInterfaceImpl ? "System#Object" : "System.Object");
			return;
		case TypeKind.TypeParameter:
		{
			ITypeParameter typeParameter = (ITypeParameter)type;
			if (explicitInterfaceImpl)
			{
				b.Append(typeParameter.Name);
				return;
			}
			b.Append('`');
			if (typeParameter.OwnerType == SymbolKind.Method)
			{
				b.Append('`');
			}
			b.Append(typeParameter.Index);
			return;
		}
		case TypeKind.Array:
		{
			ArrayType arrayType = (ArrayType)type;
			AppendTypeName(b, arrayType.ElementType, explicitInterfaceImpl);
			b.Append('[');
			if (arrayType.Dimensions > 1)
			{
				for (int i = 0; i < arrayType.Dimensions; i++)
				{
					if (i > 0)
					{
						b.Append(explicitInterfaceImpl ? '@' : ',');
					}
					if (!explicitInterfaceImpl)
					{
						b.Append("0:");
					}
				}
			}
			b.Append(']');
			return;
		}
		case TypeKind.Pointer:
			AppendTypeName(b, ((PointerType)type).ElementType, explicitInterfaceImpl);
			b.Append('*');
			return;
		case TypeKind.ByReference:
			AppendTypeName(b, ((ByReferenceType)type).ElementType, explicitInterfaceImpl);
			b.Append('@');
			return;
		}
		IType declaringType = type.DeclaringType;
		if (declaringType != null)
		{
			AppendTypeName(b, declaringType, explicitInterfaceImpl);
			b.Append(explicitInterfaceImpl ? '#' : '.');
			b.Append(type.Name);
			AppendTypeParameters(b, type, declaringType.TypeParameterCount, explicitInterfaceImpl);
		}
		else
		{
			if (explicitInterfaceImpl)
			{
				b.Append(type.FullName.Replace('.', '#'));
			}
			else
			{
				b.Append(type.FullName);
			}
			AppendTypeParameters(b, type, 0, explicitInterfaceImpl);
		}
	}

	private static void AppendTypeParameters(StringBuilder b, IType type, int outerTypeParameterCount, bool explicitInterfaceImpl)
	{
		int num = type.TypeParameterCount - outerTypeParameterCount;
		if (num <= 0)
		{
			return;
		}
		if (type is ParameterizedType parameterizedType)
		{
			b.Append('{');
			IList<IType> typeArguments = parameterizedType.TypeArguments;
			for (int i = outerTypeParameterCount; i < typeArguments.Count; i++)
			{
				if (i > outerTypeParameterCount)
				{
					b.Append(explicitInterfaceImpl ? '@' : ',');
				}
				AppendTypeName(b, typeArguments[i], explicitInterfaceImpl);
			}
			b.Append('}');
		}
		else
		{
			b.Append('`');
			b.Append(num);
		}
	}

	public static IMemberReference ParseMemberIdString(string memberIdString)
	{
		if (memberIdString == null)
		{
			throw new ArgumentNullException("memberIdString");
		}
		if (memberIdString.Length < 2 || memberIdString[1] != ':')
		{
			throw new ReflectionNameParseException(0, "Missing type tag");
		}
		char memberType = memberIdString[0];
		int num = memberIdString.IndexOf('(');
		if (num < 0)
		{
			num = memberIdString.LastIndexOf('~');
		}
		if (num < 0)
		{
			num = memberIdString.Length;
		}
		int num2 = memberIdString.LastIndexOf('.', num - 1);
		if (num2 < 0)
		{
			throw new ReflectionNameParseException(0, "Could not find '.' separating type name from member name");
		}
		string text = memberIdString.Substring(0, num2);
		int pos = 2;
		ITypeReference declaringTypeReference = ParseTypeName(text, ref pos);
		if (pos != text.Length)
		{
			throw new ReflectionNameParseException(pos, "Expected end of type name");
		}
		return new IdStringMemberReference(declaringTypeReference, memberType, memberIdString);
	}

	public static ITypeReference ParseTypeName(string typeName)
	{
		if (typeName == null)
		{
			throw new ArgumentNullException("typeName");
		}
		int pos = 0;
		if (typeName.StartsWith("T:", StringComparison.Ordinal))
		{
			pos = 2;
		}
		ITypeReference result = ParseTypeName(typeName, ref pos);
		if (pos < typeName.Length)
		{
			throw new ReflectionNameParseException(pos, "Expected end of type name");
		}
		return result;
	}

	private static bool IsIDStringSpecialCharacter(char c)
	{
		switch (c)
		{
		case '(':
		case ')':
		case '*':
		case ',':
		case ':':
		case '@':
		case '[':
		case ']':
		case '`':
		case '{':
		case '}':
			return true;
		default:
			return false;
		}
	}

	private static ITypeReference ParseTypeName(string typeName, ref int pos)
	{
		if (pos == typeName.Length)
		{
			throw new ReflectionNameParseException(pos, "Unexpected end");
		}
		ITypeReference typeReference;
		if (typeName[pos] == '`')
		{
			pos++;
			if (pos == typeName.Length)
			{
				throw new ReflectionNameParseException(pos, "Unexpected end");
			}
			if (typeName[pos] == '`')
			{
				pos++;
				int index = ReflectionHelper.ReadTypeParameterCount(typeName, ref pos);
				typeReference = TypeParameterReference.Create(SymbolKind.Method, index);
			}
			else
			{
				int index2 = ReflectionHelper.ReadTypeParameterCount(typeName, ref pos);
				typeReference = TypeParameterReference.Create(SymbolKind.TypeDefinition, index2);
			}
		}
		else
		{
			List<ITypeReference> list = new List<ITypeReference>();
			string typeName2 = ReadTypeName(typeName, ref pos, allowDottedName: true, out var typeParameterCount, list);
			typeReference = new GetPotentiallyNestedClassTypeReference(typeName2, typeParameterCount);
			while (pos < typeName.Length && typeName[pos] == '.')
			{
				pos++;
				string name = ReadTypeName(typeName, ref pos, allowDottedName: false, out typeParameterCount, list);
				typeReference = new NestedTypeReference(typeReference, name, typeParameterCount);
			}
			if (list.Count > 0)
			{
				typeReference = new ParameterizedTypeReference(typeReference, list);
			}
		}
		while (pos < typeName.Length)
		{
			switch (typeName[pos])
			{
			case '[':
			{
				int num = 1;
				do
				{
					pos++;
					if (pos == typeName.Length)
					{
						throw new ReflectionNameParseException(pos, "Unexpected end");
					}
					if (typeName[pos] == ',')
					{
						num++;
					}
				}
				while (typeName[pos] != ']');
				typeReference = new ArrayTypeReference(typeReference, num);
				break;
			}
			case '*':
				typeReference = new PointerTypeReference(typeReference);
				break;
			case '@':
				typeReference = new ByReferenceTypeReference(typeReference);
				break;
			default:
				return typeReference;
			}
			pos++;
		}
		return typeReference;
	}

	private static string ReadTypeName(string typeName, ref int pos, bool allowDottedName, out int typeParameterCount, List<ITypeReference> typeArguments)
	{
		int num = pos;
		while (pos < typeName.Length && !IsIDStringSpecialCharacter(typeName[pos]) && (allowDottedName || typeName[pos] != '.'))
		{
			pos++;
		}
		if (pos == num)
		{
			throw new ReflectionNameParseException(pos, "Expected type name");
		}
		string result = typeName.Substring(num, pos - num);
		typeParameterCount = 0;
		if (pos < typeName.Length && typeName[pos] == '`')
		{
			pos++;
			typeParameterCount = ReflectionHelper.ReadTypeParameterCount(typeName, ref pos);
		}
		else if (pos < typeName.Length && typeName[pos] == '{')
		{
			typeArguments = new List<ITypeReference>();
			do
			{
				pos++;
				typeArguments.Add(ParseTypeName(typeName, ref pos));
				typeParameterCount++;
				if (pos == typeName.Length)
				{
					throw new ReflectionNameParseException(pos, "Unexpected end");
				}
			}
			while (typeName[pos] == ',');
			if (typeName[pos] != '}')
			{
				throw new ReflectionNameParseException(pos, "Expected '}'");
			}
			pos++;
		}
		return result;
	}

	public static IEntity FindEntity(string idString, ITypeResolveContext context)
	{
		if (idString == null)
		{
			throw new ArgumentNullException("idString");
		}
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (idString.StartsWith("T:", StringComparison.Ordinal))
		{
			return ParseTypeName(idString.Substring(2)).Resolve(context).GetDefinition();
		}
		return ParseMemberIdString(idString).Resolve(context);
	}
}
