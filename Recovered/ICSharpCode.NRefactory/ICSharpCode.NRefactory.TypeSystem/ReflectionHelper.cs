using ICSharpCode.NRefactory.TypeSystem.Implementation;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public static class ReflectionHelper
	{
		public sealed class Null
		{
		}

		public sealed class Dynamic
		{
		}

		public sealed class UnboundTypeArgument
		{
		}

		public static IType FindType(this ICompilation compilation, Type type)
		{
			return type.ToTypeReference().Resolve(compilation.TypeResolveContext);
		}

		public static ITypeReference ToTypeReference(this Type type)
		{
			if (type == null)
			{
				return SpecialType.UnknownType;
			}
			if (type.IsGenericType && !type.IsGenericTypeDefinition)
			{
				ITypeReference typeReference = type.GetGenericTypeDefinition().ToTypeReference();
				Type[] genericArguments = type.GetGenericArguments();
				ITypeReference[] array = new ITypeReference[genericArguments.Length];
				bool flag = true;
				for (int i = 0; i < genericArguments.Length; i++)
				{
					array[i] = genericArguments[i].ToTypeReference();
					flag &= array[i].Equals(SpecialType.UnboundTypeArgument);
				}
				if (flag)
				{
					return typeReference;
				}
				return new ParameterizedTypeReference(typeReference, array);
			}
			if (type.IsArray)
			{
				return new ArrayTypeReference(type.GetElementType().ToTypeReference(), type.GetArrayRank());
			}
			if (type.IsPointer)
			{
				return new PointerTypeReference(type.GetElementType().ToTypeReference());
			}
			if (type.IsByRef)
			{
				return new ByReferenceTypeReference(type.GetElementType().ToTypeReference());
			}
			if (type.IsGenericParameter)
			{
				if (type.DeclaringMethod != null)
				{
					return TypeParameterReference.Create(SymbolKind.Method, type.GenericParameterPosition);
				}
				return TypeParameterReference.Create(SymbolKind.TypeDefinition, type.GenericParameterPosition);
			}
			if (type.DeclaringType != null)
			{
				if (type == typeof(Dynamic))
				{
					return SpecialType.Dynamic;
				}
				if (type == typeof(Null))
				{
					return SpecialType.NullType;
				}
				if (type == typeof(UnboundTypeArgument))
				{
					return SpecialType.UnboundTypeArgument;
				}
				ITypeReference declaringTypeRef = type.DeclaringType.ToTypeReference();
				int typeParameterCount;
				string name = SplitTypeParameterCountFromReflectionName(type.Name, out typeParameterCount);
				return new NestedTypeReference(declaringTypeRef, name, typeParameterCount);
			}
			int typeParameterCount2;
			return new GetClassTypeReference(new DefaultAssemblyReference(type.Assembly.FullName), name: SplitTypeParameterCountFromReflectionName(type.Name, out typeParameterCount2), namespaceName: type.Namespace, typeParameterCount: typeParameterCount2);
		}

		public static string SplitTypeParameterCountFromReflectionName(string reflectionName)
		{
			int num = reflectionName.LastIndexOf('`');
			if (num < 0)
			{
				return reflectionName;
			}
			return reflectionName.Substring(0, num);
		}

		public static string SplitTypeParameterCountFromReflectionName(string reflectionName, out int typeParameterCount)
		{
			int num = reflectionName.LastIndexOf('`');
			if (num < 0)
			{
				typeParameterCount = 0;
				return reflectionName;
			}
			if (int.TryParse(reflectionName.Substring(num + 1), out typeParameterCount))
			{
				return reflectionName.Substring(0, num);
			}
			return reflectionName;
		}

		public static IType FindType(this ICompilation compilation, TypeCode typeCode)
		{
			return compilation.FindType((KnownTypeCode)typeCode);
		}

		public static ITypeReference ToTypeReference(this TypeCode typeCode)
		{
			return KnownTypeReference.Get((KnownTypeCode)typeCode);
		}

		public static TypeCode GetTypeCode(IType type)
		{
			ITypeDefinition typeDefinition = type as ITypeDefinition;
			if (typeDefinition != null)
			{
				KnownTypeCode knownTypeCode = typeDefinition.KnownTypeCode;
				if (knownTypeCode <= KnownTypeCode.String && knownTypeCode != KnownTypeCode.Void)
				{
					return (TypeCode)knownTypeCode;
				}
				return TypeCode.Empty;
			}
			return TypeCode.Empty;
		}

		public static ITypeReference ParseReflectionName(string reflectionTypeName)
		{
			if (reflectionTypeName == null)
			{
				throw new ArgumentNullException("reflectionTypeName");
			}
			int pos = 0;
			ITypeReference result = ParseReflectionName(reflectionTypeName, ref pos);
			if (pos < reflectionTypeName.Length)
			{
				throw new ReflectionNameParseException(pos, "Expected end of type name");
			}
			return result;
		}

		private static bool IsReflectionNameSpecialCharacter(char c)
		{
			switch (c)
			{
			case '&':
			case '*':
			case '+':
			case ',':
			case '[':
			case ']':
			case '`':
				return true;
			default:
				return false;
			}
		}

		private static ITypeReference ParseReflectionName(string reflectionTypeName, ref int pos)
		{
			if (pos == reflectionTypeName.Length)
			{
				throw new ReflectionNameParseException(pos, "Unexpected end");
			}
			ITypeReference typeReference;
			if (reflectionTypeName[pos] == '`')
			{
				pos++;
				if (pos == reflectionTypeName.Length)
				{
					throw new ReflectionNameParseException(pos, "Unexpected end");
				}
				if (reflectionTypeName[pos] == '`')
				{
					pos++;
					int index = ReadTypeParameterCount(reflectionTypeName, ref pos);
					typeReference = TypeParameterReference.Create(SymbolKind.Method, index);
				}
				else
				{
					int index2 = ReadTypeParameterCount(reflectionTypeName, ref pos);
					typeReference = TypeParameterReference.Create(SymbolKind.TypeDefinition, index2);
				}
			}
			else
			{
				int tpc;
				string typeName = ReadTypeName(reflectionTypeName, ref pos, out tpc);
				typeReference = CreateGetClassTypeReference(SkipAheadAndReadAssemblyName(reflectionTypeName, pos), typeName, tpc);
			}
			while (pos < reflectionTypeName.Length)
			{
				switch (reflectionTypeName[pos++])
				{
				case '+':
				{
					int tpc2;
					string name = ReadTypeName(reflectionTypeName, ref pos, out tpc2);
					typeReference = new NestedTypeReference(typeReference, name, tpc2);
					break;
				}
				case '*':
					typeReference = new PointerTypeReference(typeReference);
					break;
				case '&':
					typeReference = new ByReferenceTypeReference(typeReference);
					break;
				case '[':
					if (pos == reflectionTypeName.Length)
					{
						throw new ReflectionNameParseException(pos, "Unexpected end");
					}
					if (reflectionTypeName[pos] == '[')
					{
						List<ITypeReference> list = new List<ITypeReference>();
						pos++;
						list.Add(ParseReflectionName(reflectionTypeName, ref pos));
						if (pos >= reflectionTypeName.Length || reflectionTypeName[pos] != ']')
						{
							throw new ReflectionNameParseException(pos, "Expected end of type argument");
						}
						pos++;
						while (pos < reflectionTypeName.Length && reflectionTypeName[pos] == ',')
						{
							pos++;
							if (pos < reflectionTypeName.Length && reflectionTypeName[pos] == '[')
							{
								pos++;
								list.Add(ParseReflectionName(reflectionTypeName, ref pos));
								if (pos < reflectionTypeName.Length && reflectionTypeName[pos] == ']')
								{
									pos++;
									continue;
								}
								throw new ReflectionNameParseException(pos, "Expected end of type argument");
							}
							throw new ReflectionNameParseException(pos, "Expected another type argument");
						}
						if (pos >= reflectionTypeName.Length || reflectionTypeName[pos] != ']')
						{
							throw new ReflectionNameParseException(pos, "Expected end of generic type");
						}
						pos++;
						typeReference = new ParameterizedTypeReference(typeReference, list);
					}
					else
					{
						int num = 1;
						while (pos < reflectionTypeName.Length && reflectionTypeName[pos] == ',')
						{
							num++;
							pos++;
						}
						if (pos >= reflectionTypeName.Length || reflectionTypeName[pos] != ']')
						{
							throw new ReflectionNameParseException(pos, "Invalid array modifier");
						}
						pos++;
						typeReference = new ArrayTypeReference(typeReference, num);
					}
					break;
				case ',':
					while (pos < reflectionTypeName.Length && reflectionTypeName[pos] != ']')
					{
						pos++;
					}
					break;
				default:
					pos--;
					if (reflectionTypeName[pos] == ']')
					{
						return typeReference;
					}
					throw new ReflectionNameParseException(pos, "Unexpected character: '" + reflectionTypeName[pos].ToString() + "'");
				}
			}
			return typeReference;
		}

		private static ITypeReference CreateGetClassTypeReference(string assemblyName, string typeName, int tpc)
		{
			IAssemblyReference assembly = (assemblyName == null) ? null : new DefaultAssemblyReference(assemblyName);
			int num = typeName.LastIndexOf('.');
			if (num < 0)
			{
				return new GetClassTypeReference(assembly, string.Empty, typeName, tpc);
			}
			return new GetClassTypeReference(assembly, typeName.Substring(0, num), typeName.Substring(num + 1), tpc);
		}

		private static string SkipAheadAndReadAssemblyName(string reflectionTypeName, int pos)
		{
			int num = 0;
			while (pos < reflectionTypeName.Length)
			{
				switch (reflectionTypeName[pos++])
				{
				case '[':
					num++;
					break;
				case ']':
					if (num == 0)
					{
						return null;
					}
					num--;
					break;
				case ',':
					if (num == 0)
					{
						while (pos < reflectionTypeName.Length && reflectionTypeName[pos] == ' ')
						{
							pos++;
						}
						int i;
						for (i = pos; i < reflectionTypeName.Length && reflectionTypeName[i] != ']'; i++)
						{
						}
						return reflectionTypeName.Substring(pos, i - pos);
					}
					break;
				}
			}
			return null;
		}

		private static string ReadTypeName(string reflectionTypeName, ref int pos, out int tpc)
		{
			int num = pos;
			while (pos < reflectionTypeName.Length && !IsReflectionNameSpecialCharacter(reflectionTypeName[pos]))
			{
				pos++;
			}
			if (pos == num)
			{
				throw new ReflectionNameParseException(pos, "Expected type name");
			}
			string result = reflectionTypeName.Substring(num, pos - num);
			if (pos < reflectionTypeName.Length && reflectionTypeName[pos] == '`')
			{
				pos++;
				tpc = ReadTypeParameterCount(reflectionTypeName, ref pos);
				return result;
			}
			tpc = 0;
			return result;
		}

		internal static int ReadTypeParameterCount(string reflectionTypeName, ref int pos)
		{
			int num = pos;
			while (pos < reflectionTypeName.Length)
			{
				char c = reflectionTypeName[pos];
				if (c < '0' || c > '9')
				{
					break;
				}
				pos++;
			}
			if (!int.TryParse(reflectionTypeName.Substring(num, pos - num), out int result))
			{
				throw new ReflectionNameParseException(pos, "Expected type parameter count");
			}
			return result;
		}
	}
}
