using System;
using System.Linq.Expressions;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000CA")]
	internal static class ReflectionUtil
	{
		[Token(Token = "0x600075C")]
		[Address(RVA = "0xB50294", Offset = "0xB50294", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = System.Delegate::get_Method(method);\n\tv30 = *([v9 @ X0_v3 (System.Reflection.MethodInfo)]);\n\tv31 = *([v30 @ X8_v1 (Il2CppClass<System.Reflection.MethodInfo>)+1A0]);\n\tv32 = *([v30 @ X8_v1 (Il2CppClass<System.Reflection.MethodInfo>)+1A8]);\n\t// 16 IndirectJump v31 @ X2_v1, v9 @ X0_v3 (System.Reflection.MethodInfo), v9 @ X0_v3 (System.Reflection.MethodInfo), v32 @ X1_v3, v31 @ X2_v1, v17 @ X3, v18 @ X4, v19 @ X5, v20 @ X6, v21 @ X7, v22 @ V0, v23 @ V1, v24 @ V2, v25 @ V3, v26 @ V4, v27 @ V5, v28 @ V6, v29 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetMethodName(Delegate method)
		{
			//IL_001a: Expected I, but got O
			//IL_002a: Expected O, but got I
			//IL_003a: Expected O, but got I
			MethodInfo method2 = method.Method;
			IntPtr intPtr = (IntPtr)method2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X8_v1 (Il2CppClass<System.Reflection.MethodInfo>)+1A0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X8_v1 (Il2CppClass<System.Reflection.MethodInfo>)+1A8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v31 @ X2_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x600075D")]
		[Address(RVA = "0xAD93F4", Offset = "0xAD93F4", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1ED8DD0]);\n\tv33 = *([v32 @ X8_v38]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([20223DC]) = v51;\nL_001E:\n\t// 30 IsInst v56 @ X0_v3, typeof(System.Enum), inObj @ X0 (TIn)\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_0103;\n\tv59 = inObj == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tv128 = System.Activator::CreateInstance();\n\tv131 = System.Object::GetType(inObj);\n\tv228 = System.Object::GetType(v128);\n\tv377 = System.Type::GetProperties(v131);\n\tv371 = v377.Length;\n\tv404 = v377.Length < 1;\n\tif (v404) goto L_0096;\nL_0049:\n\tv439 = v254 < v371;\n\tv280 = ~v439;\n\tif (v280) goto L_00FB;\n\tv293 = System.Reflection.MemberInfo::get_Name(v377[v254 @ X26_v9 (System.Int32)]);\n\tv456 = System.Type::GetProperty(v228, v293);\n\tv294 = System.Reflection.PropertyInfo::op_Inequality(v456, 0);\n\tv460 = v294 == 0;\n\tif (v460) goto L_0083;\n\tv472 = System.Reflection.PropertyInfo::get_CanWrite(v456);\n\tv473 = v472 == 0;\n\tif (v473) goto L_0083;\n\tv489 = System.Reflection.PropertyInfo::GetValue(v377[v254 @ X26_v9 (System.Int32)], inObj, 0);\n\tv471 = System.Reflection.PropertyInfo::SetValue(v456, v128, v489, 0);\nL_0083:\n\tv371 = v377.Length;\n\tv254 = v254 + 1;\n\tv413 = v254 < v377.Length;\n\tif (v413) goto L_0049;\nL_0096:\n\tv198 = System.Type::GetFields(v131, 0x14);\n\tv372 = v198.Length;\n\tv163 = v198.Length < 1;\n\tif (v163) goto L_00F8;\nL_00A8:\n\tv453 = v237 < v372;\n\tv281 = ~v453;\n\tif (v281) goto L_00FB;\n\tv296 = System.Reflection.MemberInfo::get_Name(v198[v237 @ X25_v9 (System.Int32)]);\n\tv463 = System.Type::GetField(v228, v296);\n\tv297 = System.Reflection.FieldInfo::op_Inequality(v463, 0);\n\tv482 = v297 == 0;\n\tif (v482) goto L_00DC;\n\tv497 = System.Reflection.FieldInfo::get_IsPublic(v463);\n\tv498 = v497 == 0;\n\tif (v498) goto L_00DC;\n\tv508 = System.Reflection.FieldInfo::GetValue(v198[v237 @ X25_v9 (System.Int32)], inObj);\n\tSystem.Reflection.FieldInfo::SetValue(v463, v128, v508);\nL_00DC:\n\tv372 = v198.Length;\n\tv237 = v237 + 1;\n\tv164 = v237 < v198.Length;\n\tif (v164) goto L_00A8;\n\tgoto L_00F8;\nL_00F8:\n\treturn v203;\n\tv313 = new System.NullReferenceException();\nL_00FB:\n\tv374 = new System.IndexOutOfRangeException();\n\tthrow v374;\n\tthrow System.NullReferenceException;\nL_0103:\n\tv124 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v124, \"Input must be class not enum!\");\n\tthrow v124;\n// 207 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TOut CopyObjectData<TIn, TOut>(TIn inObj) where TOut : new()
		{
			object obj = inObj as Enum;
			TOut val;
			Type type;
			Type type2;
			TOut result;
			if (obj == null)
			{
				if (inObj != null)
				{
					val = new TOut();
					type = inObj.GetType();
					type2 = val.GetType();
					PropertyInfo[] properties = type.GetProperties();
					int num = properties.Length;
					if (properties.Length < 1)
					{
						goto IL_0150;
					}
					int num2 = 0;
					while (num2 < num)
					{
						string name = properties[num2].Name;
						PropertyInfo property = type2.GetProperty(name);
						if (property != null && property.CanWrite)
						{
							object value = properties[num2].GetValue(inObj, null);
							property.SetValue(val, value, null);
						}
						num = properties.Length;
						num2++;
						if (num2 < properties.Length)
						{
							continue;
						}
						goto IL_0150;
					}
					goto IL_02a9;
				}
				result = (TOut)null;
				goto IL_033b;
			}
			NotImplementedException ex = new NotImplementedException("Input must be class not enum!");
			throw ex;
			IL_0150:
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
			int num3 = fields.Length;
			bool flag = fields.Length < 1;
			result = val;
			if (!flag)
			{
				int num4 = 0;
				while (num4 < num3)
				{
					string name2 = fields[num4].Name;
					FieldInfo field = type2.GetField(name2);
					if (field != null && field.IsPublic)
					{
						object value2 = fields[num4].GetValue(inObj);
						field.SetValue(val, value2);
					}
					num3 = fields.Length;
					num4++;
					if (num4 < fields.Length)
					{
						continue;
					}
					goto IL_0292;
				}
				goto IL_02a9;
			}
			goto IL_033b;
			IL_02a9:
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
			IL_033b:
			return result;
			IL_0292:
			result = val;
			goto IL_033b;
		}

		[Token(Token = "0x600075E")]
		[Address(RVA = "0xBAE720", Offset = "0xBAE720", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0C0E8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022C27]) = v38;\nL_0019:\n\t// 25 IsInst returnVal1 @ X0_v6 (System.String), typeof(System.Linq.Expressions.MemberExpression), propertyExpression._body (System.Linq.Expressions.Expression)\n\tv46 = returnVal1 == 0;\n\tif (v46) goto L_002E;\n\tv50 = System.Linq.Expressions.MemberExpression::get_Member(returnVal1);\n\tv70 = *([v50 @ X0_v7 (System.Reflection.MemberInfo)]);\n\tv60 = *([v70 @ X8_v6 (Il2CppClass<System.Reflection.MemberInfo>)+1A0]);\n\tv64 = *([v70 @ X8_v6 (Il2CppClass<System.Reflection.MemberInfo>)+1A8]);\n\t// 40 IndirectJump v60 @ X2_v1, v50 @ X0_v7 (System.Reflection.MemberInfo), v50 @ X0_v7 (System.Reflection.MemberInfo), v64 @ X1_v4, v60 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\nL_002E:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetMemberNameFromExpression<T>(Expression<Func<T>> propertyExpression)
		{
			//IL_004e: Expected I, but got O
			//IL_005e: Expected O, but got I
			//IL_006e: Expected O, but got I
			string text = (string)(object)(propertyExpression._body as MemberExpression);
			if (text != null)
			{
				MemberInfo member = ((MemberExpression)(object)text).Member;
				IntPtr intPtr = (IntPtr)member;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X8_v6 (Il2CppClass<System.Reflection.MemberInfo>)+1A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X8_v6 (Il2CppClass<System.Reflection.MemberInfo>)+1A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v60 @ X2_v1 (should have been resolved before IL gen)");
			}
			return text;
		}
	}
}
