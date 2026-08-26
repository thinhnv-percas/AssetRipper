using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ICSharpCode.Decompiler.ILAst;

internal sealed class AutoPropertyInfo
{
	private readonly Dictionary<FieldDef, PropertyDef> toProp;

	private TypeDef type;

	private IMemberRefParent memberRefClass;

	public TypeDef Type => type;

	public AutoPropertyInfo()
	{
		toProp = new Dictionary<FieldDef, PropertyDef>();
	}

	public void Initialize(TypeDef type)
	{
		this.type = type;
		foreach (PropertyDef property in type.Properties)
		{
			FieldDef fieldDef = null;
			MethodDef getMethod = property.GetMethod;
			if (getMethod != null)
			{
				FieldDef getterBackingField = GetGetterBackingField(getMethod);
				if (getterBackingField == null || (fieldDef != null && fieldDef != getterBackingField))
				{
					continue;
				}
				fieldDef = getterBackingField;
			}
			MethodDef setMethod = property.SetMethod;
			if (setMethod != null)
			{
				FieldDef setterBackingField = GetSetterBackingField(setMethod);
				if (setterBackingField == null || (fieldDef != null && fieldDef != setterBackingField))
				{
					continue;
				}
				fieldDef = setterBackingField;
			}
			if (fieldDef != null && fieldDef.IsCompilerGenerated())
			{
				toProp[fieldDef] = property;
			}
		}
	}

	private static FieldDef GetGetterBackingField(MethodDef getter)
	{
		CilBody body = getter.Body;
		if (body == null)
		{
			return null;
		}
		int index = 0;
		IList<Instruction> instructions = body.Instructions;
		IField field;
		if (getter.IsStatic)
		{
			if (instructions.Count == 2)
			{
				if (instructions[index].OpCode.Code != Code.Ldsfld)
				{
					return null;
				}
				field = instructions[index++].Operand as IField;
			}
			else
			{
				if (instructions.Count != 5)
				{
					return null;
				}
				if (instructions[index].OpCode.Code != Code.Ldsfld)
				{
					return null;
				}
				field = instructions[index++].Operand as IField;
				if (instructions[index++].OpCode.Code != Code.Stloc_0)
				{
					return null;
				}
				Instruction instruction = instructions[index];
				if (instructions[index].OpCode.Code != Code.Br && instructions[index].OpCode.Code != Code.Br_S)
				{
					return null;
				}
				if (instruction != instructions[index++])
				{
					return null;
				}
				if (instructions[index++].OpCode.Code != Code.Ldloc_0)
				{
					return null;
				}
			}
		}
		else if (instructions.Count == 3)
		{
			if (instructions[index++].OpCode.Code != Code.Ldarg_0)
			{
				return null;
			}
			if (instructions[index].OpCode.Code != Code.Ldfld)
			{
				return null;
			}
			field = instructions[index++].Operand as IField;
		}
		else
		{
			if (instructions.Count != 6)
			{
				return null;
			}
			if (instructions[index++].OpCode.Code != Code.Ldarg_0)
			{
				return null;
			}
			if (instructions[index].OpCode.Code != Code.Ldfld)
			{
				return null;
			}
			field = instructions[index++].Operand as IField;
			if (instructions[index++].OpCode.Code != Code.Stloc_0)
			{
				return null;
			}
			Instruction instruction2 = instructions[index];
			if (instructions[index].OpCode.Code != Code.Br && instructions[index].OpCode.Code != Code.Br_S)
			{
				return null;
			}
			if (instruction2 != instructions[index++])
			{
				return null;
			}
			if (instructions[index++].OpCode.Code != Code.Ldloc_0)
			{
				return null;
			}
		}
		FieldDef fieldDef = field.ResolveFieldWithinSameModule();
		if (fieldDef?.DeclaringType != getter.DeclaringType)
		{
			return null;
		}
		if (instructions[index++].OpCode.Code != Code.Ret)
		{
			return null;
		}
		return fieldDef;
	}

	private static FieldDef GetSetterBackingField(MethodDef getter)
	{
		CilBody body = getter.Body;
		if (body == null)
		{
			return null;
		}
		int index = 0;
		IList<Instruction> instructions = body.Instructions;
		if (getter.IsStatic)
		{
			if (instructions.Count != 3)
			{
				return null;
			}
			if (instructions[index++].OpCode.Code != Code.Ldarg_0)
			{
				return null;
			}
			if (instructions[index].OpCode.Code != Code.Stsfld)
			{
				return null;
			}
		}
		else
		{
			if (instructions.Count != 4)
			{
				return null;
			}
			if (instructions[index++].OpCode.Code != Code.Ldarg_0)
			{
				return null;
			}
			if (instructions[index++].OpCode.Code != Code.Ldarg_1)
			{
				return null;
			}
			if (instructions[index].OpCode.Code != Code.Stfld)
			{
				return null;
			}
		}
		FieldDef fieldDef = (instructions[index++].Operand as IField).ResolveFieldWithinSameModule();
		if (fieldDef?.DeclaringType != getter.DeclaringType)
		{
			return null;
		}
		if (instructions[index++].OpCode.Code != Code.Ret)
		{
			return null;
		}
		return fieldDef;
	}

	public IMethod TryGetGetter(FieldDef field)
	{
		if (field?.DeclaringType != type)
		{
			return null;
		}
		if (!toProp.TryGetValue(field, out var value))
		{
			return null;
		}
		return CreateMethodRef(value.GetMethod);
	}

	public IMethod TryGetSetter(FieldDef field)
	{
		if (field?.DeclaringType != type)
		{
			return null;
		}
		if (!toProp.TryGetValue(field, out var value))
		{
			return null;
		}
		return CreateMethodRef(value.SetMethod);
	}

	private IMethod CreateMethodRef(MethodDef method)
	{
		if (method == null)
		{
			return null;
		}
		if (!type.HasGenericParameters)
		{
			return method;
		}
		if (memberRefClass == null)
		{
			GenericInstSig genericInstSig = new GenericInstSig(type.IsValueType ? ((ClassOrValueTypeSig)new ValueTypeSig(type)) : ((ClassOrValueTypeSig)new ClassSig(type)));
			for (int i = 0; i < type.GenericParameters.Count; i++)
			{
				genericInstSig.GenericArguments.Add(new GenericVar(i, type));
			}
			memberRefClass = new TypeSpecUser(genericInstSig);
		}
		return new MemberRefUser(type.Module, method.Name, method.MethodSig, memberRefClass);
	}

	public void Reset()
	{
		toProp.Clear();
		type = null;
		memberRefClass = null;
	}
}
