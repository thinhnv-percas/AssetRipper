using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler.XmlDoc;

public sealed class XmlDocKeyProvider
{
	public static StringBuilder GetKey(IMemberRef member, StringBuilder b)
	{
		if (member == null)
		{
			return null;
		}
		b.Clear();
		if (member is ITypeDefOrRef)
		{
			b.Append("T:");
			AppendTypeName(b, ((ITypeDefOrRef)member).ToTypeSig());
		}
		else
		{
			if (member.IsField)
			{
				b.Append("F:");
			}
			else if (member.IsPropertyDef)
			{
				b.Append("P:");
			}
			else if (member.IsEventDef)
			{
				b.Append("E:");
			}
			else if (member.IsMethod)
			{
				b.Append("M:");
			}
			AppendTypeName(b, member.DeclaringType.ToTypeSig());
			b.Append('.');
			b.Append(member.Name.Replace('.', '#'));
			TypeSig typeSig = null;
			IList<Parameter> list;
			if (member.IsPropertyDef)
			{
				list = GetParameters((PropertyDef)member).ToList();
			}
			else if (member.IsMethod)
			{
				IMethod method = (IMethod)member;
				if (method.NumberOfGenericParameters > 0)
				{
					b.Append("``");
					b.Append(method.NumberOfGenericParameters);
				}
				list = method.GetParameters();
				if (method.Name == "op_Implicit" || method.Name == "op_Explicit")
				{
					typeSig = method.MethodSig.GetRetType();
				}
			}
			else
			{
				list = null;
			}
			if (list != null && list.Any((Parameter a) => a.IsNormalMethodParameter))
			{
				b.Append('(');
				for (int num = 0; num < list.Count; num++)
				{
					Parameter parameter = list[num];
					if (parameter.IsNormalMethodParameter)
					{
						if (parameter.MethodSigIndex > 0)
						{
							b.Append(',');
						}
						AppendTypeName(b, parameter.Type);
					}
				}
				b.Append(')');
			}
			if (typeSig != null)
			{
				b.Append('~');
				AppendTypeName(b, typeSig);
			}
		}
		return b;
	}

	private static IEnumerable<Parameter> GetParameters(PropertyDef property)
	{
		if (property == null)
		{
			yield break;
		}
		if (property.GetMethod != null)
		{
			foreach (Parameter parameter in property.GetMethod.Parameters)
			{
				yield return parameter;
			}
			yield break;
		}
		if (property.SetMethod != null)
		{
			int last = property.SetMethod.Parameters.Count - 1;
			foreach (Parameter param in property.SetMethod.Parameters)
			{
				if (param.Index != last)
				{
					yield return param;
				}
			}
			yield break;
		}
		int i = 0;
		foreach (TypeSig param2 in property.PropertySig.GetParams())
		{
			yield return new Parameter(i, i, param2);
			i++;
		}
	}

	private static void AppendTypeName(StringBuilder b, TypeSig type)
	{
		type = type.RemovePinnedAndModifiers();
		if (type == null)
		{
			return;
		}
		if (type is GenericInstSig genericInstSig)
		{
			AppendTypeNameWithArguments(b, (genericInstSig.GenericType == null) ? null : genericInstSig.GenericType.TypeDefOrRef, genericInstSig.GenericArguments);
		}
		else if (type is ArraySigBase arraySigBase)
		{
			AppendTypeName(b, arraySigBase.Next);
			b.Append('[');
			IList<int> lowerBounds = arraySigBase.GetLowerBounds();
			IList<uint> sizes = arraySigBase.GetSizes();
			for (int i = 0; i < arraySigBase.Rank; i++)
			{
				if (i > 0)
				{
					b.Append(',');
				}
				if (i < lowerBounds.Count && i < sizes.Count)
				{
					b.Append(lowerBounds[i]);
					b.Append(':');
					b.Append(sizes[i] + lowerBounds[i] - 1);
				}
			}
			b.Append(']');
		}
		else if (type is ByRefSig byRefSig)
		{
			AppendTypeName(b, byRefSig.Next);
			b.Append('@');
		}
		else if (type is PtrSig ptrSig)
		{
			AppendTypeName(b, ptrSig.Next);
			b.Append('*');
		}
		else if (type is GenericSig genericSig)
		{
			b.Append('`');
			if (genericSig.IsMethodVar)
			{
				b.Append('`');
			}
			b.Append(genericSig.Number);
		}
		else
		{
			ITypeDefOrRef typeDefOrRef = type.ToTypeDefOrRef();
			if (typeDefOrRef.DeclaringType != null)
			{
				AppendTypeName(b, typeDefOrRef.DeclaringType.ToTypeSig());
				b.Append('.');
				b.Append(typeDefOrRef.Name);
			}
			else
			{
				FullNameFactory.FullNameSB(type, isReflection: false, null, null, null, b);
			}
		}
	}

	private static int AppendTypeNameWithArguments(StringBuilder b, ITypeDefOrRef type, IList<TypeSig> genericArguments)
	{
		if (type == null)
		{
			return 0;
		}
		int num = 0;
		if (type.DeclaringType != null)
		{
			ITypeDefOrRef declaringType = type.DeclaringType;
			num = AppendTypeNameWithArguments(b, declaringType, genericArguments);
			b.Append('.');
		}
		else
		{
			int length = b.Length;
			FullNameFactory.NamespaceSB(type, isReflection: true, b);
			if (length != b.Length)
			{
				b.Append('.');
			}
		}
		b.Append(SplitTypeParameterCountFromReflectionName(type.Name, out var typeParameterCount));
		if (typeParameterCount > 0)
		{
			int num2 = num + typeParameterCount;
			b.Append('{');
			for (int i = num; i < num2 && i < genericArguments.Count; i++)
			{
				if (i > num)
				{
					b.Append(',');
				}
				AppendTypeName(b, genericArguments[i]);
			}
			b.Append('}');
		}
		return num + typeParameterCount;
	}

	public static string SplitTypeParameterCountFromReflectionName(string reflectionName, out int typeParameterCount)
	{
		int num = reflectionName.LastIndexOf('`');
		if (num < 0)
		{
			typeParameterCount = 0;
			return reflectionName;
		}
		string s = reflectionName.Substring(num + 1);
		if (int.TryParse(s, out typeParameterCount))
		{
			return reflectionName.Substring(0, num);
		}
		return reflectionName;
	}

	public static IMemberRef FindMemberByKey(ModuleDef module, string key)
	{
		if (module == null)
		{
			throw new ArgumentNullException("module");
		}
		if (key == null || key.Length < 2 || key[1] != ':')
		{
			return null;
		}
		return key[0] switch
		{
			'T' => FindType(module, key.Substring(2)), 
			'F' => FindMember(module, key, (TypeDef type) => type.Fields), 
			'P' => FindMember(module, key, (TypeDef type) => type.Properties), 
			'E' => FindMember(module, key, (TypeDef type) => type.Events), 
			'M' => FindMember(module, key, (TypeDef type) => type.Methods), 
			_ => null, 
		};
	}

	private static IMemberRef FindMember(ModuleDef module, string key, Func<TypeDef, IEnumerable<IMemberRef>> memberSelector)
	{
		int num = key.IndexOf('(');
		int num2 = ((num <= 0) ? key.LastIndexOf('.') : key.LastIndexOf('.', num - 1, num));
		if (num2 < 0)
		{
			return null;
		}
		TypeDef typeDef = FindType(module, key.Substring(2, num2 - 2));
		if (typeDef == null)
		{
			return null;
		}
		string text = ((num <= 0) ? key.Substring(num2 + 1) : key.Substring(num2 + 1, num - (num2 + 1)));
		IMemberRef result = null;
		StringBuilder b = new StringBuilder();
		foreach (IMemberRef item in memberSelector(typeDef))
		{
			StringBuilder key2 = GetKey(item, b);
			if (key2.CheckEquals(key))
			{
				return item;
			}
			if (text == item.Name.Replace('.', '#'))
			{
				result = item;
			}
		}
		return result;
	}

	private static TypeDef FindType(ModuleDef module, string name)
	{
		int num = name.LastIndexOf('.');
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}
		TypeDef typeDef = module.Find(name, isReflectionName: true);
		if (typeDef == null && num > 0)
		{
			typeDef = FindType(module, name.Substring(0, num));
			if (typeDef != null)
			{
				foreach (TypeDef nestedType in typeDef.NestedTypes)
				{
					if (nestedType.Name == name)
					{
						return nestedType;
					}
				}
				return null;
			}
		}
		return typeDef;
	}
}
