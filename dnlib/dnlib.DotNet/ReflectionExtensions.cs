using System;
using System.Reflection;

namespace dnlib.DotNet;

internal static class ReflectionExtensions
{
	public static bool IsSZArray(this Type self)
	{
		if (self == null || !self.IsArray)
		{
			return false;
		}
		PropertyInfo property = self.GetType().GetProperty("IsSzArray", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (property != null)
		{
			return (bool)property.GetValue(self, Array2.Empty<object>());
		}
		return (self.Name ?? string.Empty).EndsWith("[]");
	}

	public static ElementType GetElementType2(this Type a)
	{
		if (a == null)
		{
			return ElementType.End;
		}
		if (a.IsArray)
		{
			return a.IsSZArray() ? ElementType.SZArray : ElementType.Array;
		}
		if (a.IsByRef)
		{
			return ElementType.ByRef;
		}
		if (a.IsPointer)
		{
			return ElementType.Ptr;
		}
		if (a.IsGenericParameter)
		{
			return (a.DeclaringMethod == null) ? ElementType.Var : ElementType.MVar;
		}
		if (a.IsGenericType && !a.IsGenericTypeDefinition)
		{
			return ElementType.GenericInst;
		}
		if (a == typeof(void))
		{
			return ElementType.Void;
		}
		if (a == typeof(bool))
		{
			return ElementType.Boolean;
		}
		if (a == typeof(char))
		{
			return ElementType.Char;
		}
		if (a == typeof(sbyte))
		{
			return ElementType.I1;
		}
		if (a == typeof(byte))
		{
			return ElementType.U1;
		}
		if (a == typeof(short))
		{
			return ElementType.I2;
		}
		if (a == typeof(ushort))
		{
			return ElementType.U2;
		}
		if (a == typeof(int))
		{
			return ElementType.I4;
		}
		if (a == typeof(uint))
		{
			return ElementType.U4;
		}
		if (a == typeof(long))
		{
			return ElementType.I8;
		}
		if (a == typeof(ulong))
		{
			return ElementType.U8;
		}
		if (a == typeof(float))
		{
			return ElementType.R4;
		}
		if (a == typeof(double))
		{
			return ElementType.R8;
		}
		if (a == typeof(string))
		{
			return ElementType.String;
		}
		if (a == typeof(TypedReference))
		{
			return ElementType.TypedByRef;
		}
		if (a == typeof(IntPtr))
		{
			return ElementType.I;
		}
		if (a == typeof(UIntPtr))
		{
			return ElementType.U;
		}
		if (a == typeof(object))
		{
			return ElementType.Object;
		}
		return a.IsValueType ? ElementType.ValueType : ElementType.Class;
	}

	public static bool IsGenericButNotGenericMethodDefinition(this MethodBase mb)
	{
		return mb != null && !mb.IsGenericMethodDefinition && mb.IsGenericMethod;
	}

	internal static bool MustTreatTypeAsGenericInstType(this Type declaringType, Type t)
	{
		return declaringType != null && declaringType.IsGenericTypeDefinition && t == declaringType;
	}

	public static bool IsTypeDef(this Type type)
	{
		return type != null && !type.HasElementType && (!type.IsGenericType || type.IsGenericTypeDefinition);
	}
}
