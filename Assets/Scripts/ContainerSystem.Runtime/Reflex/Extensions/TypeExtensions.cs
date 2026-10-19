using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Reflex.Extensions
{
	[Token(Token = "0x200002A")]
	internal static class TypeExtensions
	{
		[Token(Token = "0x6000074")]
		[Address(RVA = "0x3F3402C", Offset = "0x3F3402C", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv51 = System.Type::get_IsGenericType(type);\n\tv52 = ~v51;\n\tif (v52) goto L_FFFFFFFF;\n\tv58 = System.Type::GetGenericTypeDefinition(type);\n\tgoto L_0034;\nL_0034:\n\tv87 = System.Type::GetTypeFromHandle(System.Collections.Generic.IEnumerable`1);\n\tv76 = System.Type::op_Equality(v58, v87);\n\tv78 = ~v76;\n\tif (v78) goto L_FFFFFFFF;\n\tv128 = System.Type::get_GenericTypeArguments(type);\n\tv95 = System.Linq.Enumerable::Single(v128);\nL_FFFFFFFF:\n\tv90 = v95;\nL_FFFFFFFF:\n\tv100 = 1;\n\tgoto L_0049;\nL_FFFFFFFF:\n\tv90 = 0;\nL_FFFFFFFF:\n\tv100 = 0;\nL_0049:\n\t*([elementType @ X1 (System.Type&)]) = v90;\n\treturn v100;\n")]
		internal static bool IsEnumerable(this Type type, out Type elementType)
		{
			elementType = null;
			Type type3;
			bool result;
			if (type.IsGenericType)
			{
				Type genericTypeDefinition = type.GetGenericTypeDefinition();
				Type typeFromHandle = typeof(IEnumerable<>);
				if (genericTypeDefinition == typeFromHandle)
				{
					IEnumerable<Type> genericTypeArguments = type.GenericTypeArguments;
					Type type2 = genericTypeArguments.Single();
					type3 = type2;
					result = true;
					goto IL_00c7;
				}
			}
			type3 = null;
			result = false;
			goto IL_00c7;
			IL_00c7:
			elementType = type3;
			return result;
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x3F34144", Offset = "0x3F34144", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\nL_002C:\n\tv51 = System.Type::get_IsGenericType(type);\n\treturnVal1 = System.Reflection.MemberInfo::get_Name(type);\n\tv58 = ~v51;\n\tif (v58) goto L_0076;\n\tv83 = System.String::Split(returnVal1, 0x60, 0);\n\tv117 = System.Linq.Enumerable::First(v83);\n\tv125 = System.Type::get_GenericTypeArguments(type);\n\tv130 = new System.Func`2<System.Type, System.String>();\n\tSystem.Func`2<System.Type, System.String>::.ctor(v130, 0, Il2CppMethodInfo);\n\tv144 = System.Linq.Enumerable::Select(v125, v130);\n\tv150 = System.String::Join(\", \", v144);\n\treturnVal3 = System.String::Concat(v117, \"<\", v150, \">\");\n\treturn returnVal3;\nL_0076:\n\treturn returnVal1;\n")]
		internal static string GetName(this Type type)
		{
			bool isGenericType = type.IsGenericType;
			string name = type.Name;
			if (isGenericType)
			{
				string[] source = name.Split('`');
				object obj = ((IEnumerable<object>)source).First();
				Type[] genericTypeArguments = type.GenericTypeArguments;
				Func<Type, string> selector = GetName;
				IEnumerable<object> values = genericTypeArguments.Select((Func<object, object>)selector);
				string text = string.Join(", ", (IEnumerable<string>)values);
				return (string)obj + "<" + text + ">";
			}
			return name;
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x3F342D4", Offset = "0x3F342D4", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\nL_002C:\n\tv51 = System.Type::get_IsGenericType(type);\n\treturnVal1 = System.Type::get_FullName(type);\n\tv58 = ~v51;\n\tif (v58) goto L_0076;\n\tv83 = System.String::Split(returnVal1, 0x60, 0);\n\tv117 = System.Linq.Enumerable::First(v83);\n\tv125 = System.Type::get_GenericTypeArguments(type);\n\tv130 = new System.Func`2<System.Type, System.String>();\n\tSystem.Func`2<System.Type, System.String>::.ctor(v130, 0, Il2CppMethodInfo);\n\tv144 = System.Linq.Enumerable::Select(v125, v130);\n\tv150 = System.String::Join(\", \", v144);\n\treturnVal3 = System.String::Concat(v117, \"<\", v150, \">\");\n\treturn returnVal3;\nL_0076:\n\treturn returnVal1;\n")]
		internal static string GetFullName(this Type type)
		{
			bool isGenericType = type.IsGenericType;
			string fullName = type.FullName;
			if (isGenericType)
			{
				string[] source = fullName.Split('`');
				object obj = ((IEnumerable<object>)source).First();
				Type[] genericTypeArguments = type.GenericTypeArguments;
				Func<Type, string> selector = GetFullName;
				IEnumerable<object> values = genericTypeArguments.Select((Func<object, object>)selector);
				string text = string.Join(", ", (IEnumerable<string>)values);
				return (string)obj + "<" + text + ">";
			}
			return fullName;
		}
	}
}
