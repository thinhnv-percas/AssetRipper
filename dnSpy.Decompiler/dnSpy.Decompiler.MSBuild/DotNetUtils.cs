using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace dnSpy.Decompiler.MSBuild;

internal static class DotNetUtils
{
	private static bool IsType(TypeDef type, string typeFullName)
	{
		while (type != null)
		{
			ITypeDefOrRef baseType = type.BaseType;
			if (baseType == null)
			{
				break;
			}
			if (baseType.FullName == typeFullName)
			{
				return true;
			}
			type = baseType.ResolveTypeDef();
		}
		return false;
	}

	public static bool IsWinForm(TypeDef type)
	{
		return IsType(type, "System.Windows.Forms.Form");
	}

	public static bool IsSystemWindowsApplication(TypeDef type)
	{
		return IsType(type, "System.Windows.Application");
	}

	public static bool IsStartUpClass(TypeDef type)
	{
		return type.Module.EntryPoint != null && type.Module.EntryPoint.DeclaringType == type;
	}

	public static bool IsUnsafe(ModuleDef module)
	{
		return module.CustomAttributes.IsDefined("System.Security.UnverifiableCodeAttribute");
	}

	public static IEnumerable<FieldDef> GetFields(MethodDef method)
	{
		return GetDefs(method).OfType<FieldDef>();
	}

	public static IEnumerable<IMemberDef> GetDefs(MethodDef method)
	{
		CilBody body = method.Body;
		if (body == null)
		{
			yield break;
		}
		foreach (Instruction instr in body.Instructions)
		{
			IMemberDef memberDef;
			IMemberDef def = (memberDef = instr.Operand as IMemberDef);
			if (memberDef != null && def.DeclaringType == method.DeclaringType)
			{
				yield return def;
			}
		}
	}

	public static IEnumerable<IMemberDef> GetDefs(PropertyDef prop)
	{
		foreach (MethodDef g in prop.GetMethods)
		{
			foreach (IMemberDef def in GetDefs(g))
			{
				yield return def;
			}
		}
	}

	public static IEnumerable<IMemberDef> GetMethodsAndSelf(PropertyDef p)
	{
		yield return p;
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
}
