using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.PE;

namespace dnSpy.Contracts.Decompiler;

public static class Extensions
{
	public static bool IsDefined(this IHasCustomAttribute provider, UTF8String @namespace, UTF8String name)
	{
		if (provider == null || provider.CustomAttributes.Count == 0)
		{
			return false;
		}
		foreach (CustomAttribute customAttribute in provider.CustomAttributes)
		{
			if (customAttribute.AttributeType is TypeRef typeRef)
			{
				if (typeRef.Namespace == @namespace && typeRef.Name == name)
				{
					return true;
				}
			}
			else if (customAttribute.AttributeType is TypeDef typeDef && typeDef.Namespace == @namespace && typeDef.Name == name)
			{
				return true;
			}
		}
		return false;
	}

	public static bool GetRVA(this IMemberDef member, out uint rva, out long fileOffset)
	{
		rva = 0u;
		fileOffset = 0L;
		if (member is MethodDef)
		{
			rva = (uint)(member as MethodDef).RVA;
		}
		else if (member is FieldDef)
		{
			rva = (uint)(member as FieldDef).RVA;
		}
		if (rva == 0)
		{
			return false;
		}
		uint? num = member.Module.ToFileOffset(rva);
		if (!num.HasValue)
		{
			return false;
		}
		fileOffset = num.Value;
		return true;
	}

	public static uint? ToFileOffset(this ModuleDef module, uint rva)
	{
		if (!(module is ModuleDefMD moduleDefMD))
		{
			return null;
		}
		return (uint)moduleDefMD.Metadata.PEImage.ToFileOffset((RVA)rva);
	}

	public static int GetCodeSize(this CilBody body)
	{
		if (body == null || body.Instructions.Count == 0)
		{
			return 0;
		}
		Instruction instruction = body.Instructions[body.Instructions.Count - 1];
		return (int)instruction.Offset + instruction.GetSize();
	}

	public static IList<Parameter> GetParameters(this IMethod method)
	{
		if (method == null || method.MethodSig == null)
		{
			return new List<Parameter>();
		}
		if (method is MethodDef methodDef)
		{
			return methodDef.Parameters;
		}
		List<Parameter> list = new List<Parameter>();
		int num = 0;
		int num2 = 0;
		if (method.MethodSig.HasThis)
		{
			list.Add(new Parameter(num++, -2, method.DeclaringType.ToTypeSig()));
		}
		foreach (TypeSig item in method.MethodSig.GetParams())
		{
			list.Add(new Parameter(num++, num2++, item));
		}
		return list;
	}

	private static IEnumerable<MethodDef> GetAllMethods(this PropertyDef p)
	{
		foreach (MethodDef getMethod in p.GetMethods)
		{
			yield return getMethod;
		}
		foreach (MethodDef setMethod in p.SetMethods)
		{
			yield return setMethod;
		}
		foreach (MethodDef otherMethod in p.OtherMethods)
		{
			yield return otherMethod;
		}
	}

	private static IEnumerable<MethodDef> GetAllMethods(this EventDef e)
	{
		if (e.AddMethod != null)
		{
			yield return e.AddMethod;
		}
		if (e.InvokeMethod != null)
		{
			yield return e.InvokeMethod;
		}
		if (e.RemoveMethod != null)
		{
			yield return e.RemoveMethod;
		}
		foreach (MethodDef otherMethod in e.OtherMethods)
		{
			yield return otherMethod;
		}
	}

	public static HashSet<MethodDef> GetPropertyAndEventMethods(this TypeDef type)
	{
		HashSet<MethodDef> hashSet = new HashSet<MethodDef>();
		foreach (PropertyDef property in type.Properties)
		{
			foreach (MethodDef allMethod in property.GetAllMethods())
			{
				hashSet.Add(allMethod);
			}
		}
		foreach (EventDef @event in type.Events)
		{
			foreach (MethodDef allMethod2 in @event.GetAllMethods())
			{
				hashSet.Add(allMethod2);
			}
		}
		hashSet.Remove(null);
		return hashSet;
	}

	public static bool IsIndexer(this PropertyDef property)
	{
		if (property == null || property.PropertySig.GetParamCount() == 0)
		{
			return false;
		}
		MethodDef methodDef = property.GetMethod ?? property.SetMethod;
		PropertyDef propertyDef = property;
		if (methodDef != null && methodDef.HasOverrides)
		{
			MethodDef methodDef2 = methodDef.Overrides.First().MethodDeclaration.ResolveMethodDef();
			if (methodDef2 == null)
			{
				return false;
			}
			foreach (PropertyDef property2 in methodDef2.DeclaringType.Properties)
			{
				if (property2.GetMethod == methodDef2 || property2.SetMethod == methodDef2)
				{
					propertyDef = property2;
					break;
				}
			}
		}
		string defaultMemberName = GetDefaultMemberName(propertyDef.DeclaringType);
		if (defaultMemberName == propertyDef.Name)
		{
			return true;
		}
		return false;
	}

	private static string GetDefaultMemberName(TypeDef type)
	{
		if (type == null)
		{
			return null;
		}
		foreach (CustomAttribute item in type.CustomAttributes.FindAll("System.Reflection.DefaultMemberAttribute"))
		{
			if (item.Constructor != null && item.Constructor.FullName == "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)" && item.ConstructorArguments.Count == 1 && item.ConstructorArguments[0].Value is UTF8String)
			{
				return (UTF8String)item.ConstructorArguments[0].Value;
			}
		}
		return null;
	}

	public static TypeDef Resolve(this IType type)
	{
		return type?.ScopeType.ResolveTypeDef();
	}

	public static bool CanSortFields(this TypeDef type)
	{
		return type.IsAutoLayout;
	}

	public static bool CanSortMethods(this TypeDef type)
	{
		return !type.IsInterface || !type.IsImport;
	}

	public static IEnumerable<IMemberDef> GetNonSortedMethodsPropertiesEvents(this TypeDef type)
	{
		HashSet<MethodDef> hashSet = new HashSet<MethodDef>();
		List<(IMemberDef, List<MethodDef>)> list = new List<(IMemberDef, List<MethodDef>)>();
		foreach (PropertyDef property in type.Properties)
		{
			List<MethodDef> list2 = new List<MethodDef>(property.GetAllMethods());
			foreach (MethodDef item in list2)
			{
				hashSet.Add(item);
			}
			list2.Sort((MethodDef a, MethodDef b) => a.MDToken.Raw.CompareTo(b.MDToken.Raw));
			list.Add((property, list2));
		}
		foreach (EventDef @event in type.Events)
		{
			List<MethodDef> list3 = new List<MethodDef>(@event.GetAllMethods());
			foreach (MethodDef item2 in list3)
			{
				hashSet.Add(item2);
			}
			list3.Sort((MethodDef a, MethodDef b) => a.MDToken.Raw.CompareTo(b.MDToken.Raw));
			list.Add((@event, list3));
		}
		foreach (MethodDef method in type.Methods)
		{
			if (!hashSet.Contains(method))
			{
				list.Add((method, new List<MethodDef> { method }));
			}
		}
		list.Sort(((IMemberDef def, List<MethodDef> list) a, (IMemberDef def, List<MethodDef> list) b) => (a.list.Count == 0 || b.list.Count == 0) ? b.list.Count.CompareTo(a.list.Count) : a.list[0].MDToken.Raw.CompareTo(b.list[0].MDToken.Raw));
		return list.Select<(IMemberDef, List<MethodDef>), IMemberDef>(((IMemberDef def, List<MethodDef> list) a) => a.def);
	}
}
