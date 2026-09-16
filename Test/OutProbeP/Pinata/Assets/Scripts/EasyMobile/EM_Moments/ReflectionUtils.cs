using System;
using System.Linq.Expressions;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EM_Moments
{
	[Token(Token = "0x2000003")]
	public class ReflectionUtils<T> where T : class, new()
	{
		[Token(Token = "0x4000002")]
		[FieldOffset(Offset = "0x0")]
		private readonly T _Instance;

		[Token(Token = "0x6000002")]
		[Address(RVA = "0xD8C8E8", Offset = "0xD8C8E8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._Instance = instance;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ReflectionUtils(T instance)
		{
			_Instance = instance;
		}

		[Token(Token = "0x6000003")]
		[Address(RVA = "0xBAE4F8", Offset = "0xBAE4F8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFDCE8]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, fieldAccess, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2022C24]) = v38;\nL_0019:\n\t// 25 IsInst v44 @ X0_v11 (System.Linq.Expressions.MemberExpression), typeof(System.Linq.Expressions.MemberExpression), fieldAccess._body (System.Linq.Expressions.Expression)\n\tv46 = v44 == 0;\n\tif (v46) goto L_002E;\n\tv50 = System.Linq.Expressions.MemberExpression::get_Member(v44);\n\tv68 = *([v50 @ X0_v12 (System.Reflection.MemberInfo)]);\n\tv71 = *([v68 @ X8_v13 (Il2CppClass<System.Reflection.MemberInfo>)+1A0]);\n\tv72 = *([v68 @ X8_v13 (Il2CppClass<System.Reflection.MemberInfo>)+1A8]);\n\t// 40 IndirectJump v71 @ X2_v3, v50 @ X0_v12 (System.Reflection.MemberInfo), v50 @ X0_v12 (System.Reflection.MemberInfo), v72 @ X1_v7, v71 @ X2_v3, v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tthrow System.NullReferenceException;\nL_002E:\n\tv62 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v62, \"Member expression expected\");\n\tthrow v62;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetFieldName<U>(Expression<Func<T, U>> fieldAccess)
		{
			//IL_004e: Expected I, but got O
			//IL_005e: Expected O, but got I
			//IL_006e: Expected O, but got I
			MemberExpression memberExpression = fieldAccess._body as MemberExpression;
			if (memberExpression != null)
			{
				MemberInfo member = memberExpression.Member;
				IntPtr intPtr = (IntPtr)member;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X8_v13 (Il2CppClass<System.Reflection.MemberInfo>)+1A0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X8_v13 (Il2CppClass<System.Reflection.MemberInfo>)+1A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v71 @ X2_v3 (should have been resolved before IL gen)");
			}
			InvalidOperationException ex = new InvalidOperationException("Member expression expected");
			throw ex;
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0xD8C920", Offset = "0xD8C920", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EE8520]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, fieldName, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([20240A5]) = v41;\nL_001E:\n\tgoto L_0026;\n\tv51 = *([v46 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0026;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v46, fieldName, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0026:\n\tv60 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv62 = *([v60 @ X0_v5 (System.Type)]);\n\tv68 = *([v62 @ X8_v6 (Il2CppClass<System.Type>)+3D0]);\n\tv69 = *([v62 @ X8_v6 (Il2CppClass<System.Type>)+3D8]);\n\t// 52 IndirectJump v68 @ X4_v1, v60 @ X0_v5 (System.Type), v60 @ X0_v5 (System.Type), fieldName @ X1 (System.String), 36, v69 @ X3_v1, v68 @ X4_v1, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FieldInfo GetField(string fieldName)
		{
			//IL_0020: Expected I, but got O
			//IL_0030: Expected O, but got I
			//IL_0040: Expected O, but got I
			while (true)
			{
				Type typeFromHandle = typeof(T);
				IntPtr intPtr = (IntPtr)typeFromHandle;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v6 (Il2CppClass<System.Type>)+3D0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v6 (Il2CppClass<System.Type>)+3D8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v68 @ X4_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x1356D3C", Offset = "0x1356D3C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = *([1ED0CD0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, field, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2028812]) = v41;\nL_001D:\n\tgoto L_0025;\n\tv50 = *([v44 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v44, field, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv59 = System.Type::GetTypeFromHandle(Il2CppClass<A>);\n\tv63 = System.Attribute::GetCustomAttribute(field, v59);\n\tgoto L_0034;\n\tv71 = v66;\n\tv72 = 0x8907BC(v71, v60, v62, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0034:\n\tv74 = v63 == 0;\n\tif (v74) goto L_FFFFFFFF;\n\t// 56 IsInst returnVal1 @ X0_v9 (A), typeof(A), v63 @ X0_v7 (System.Attribute)\n\tv85 = returnVal1 == 0;\n\tv83 = ~v85;\n\tif (v83) goto L_0046;\n\tthrow System.InvalidCastException;\nL_0046:\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public A GetAttribute<A>(FieldInfo field) where A : Attribute
		{
			Type typeFromHandle = typeof(A);
			Attribute customAttribute = Attribute.GetCustomAttribute(field, typeFromHandle);
			A val;
			if (customAttribute != null)
			{
				val = customAttribute as A;
				if (val == null)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				val = null;
			}
			return val;
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0xBB2218", Offset = "0xBB2218", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv32 = *([1EC4300]);\n\tv33 = *([v32 @ X8_v20]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, fieldAccess, methodInfo, v35, v36, v37, v38, v39, value, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2022C49]) = v49;\nL_0021:\n\tv56 = EM_Moments.ReflectionUtils`1<T>::GetFieldName(this, fieldAccess);\n\tv63 = EM_Moments.ReflectionUtils`1<T>::GetField(this, v56);\n\tv72 = EM_Moments.ReflectionUtils`1<T>::GetAttribute(this, v63);\n\tgoto L_0045;\n\tv118 = *([v102 @ X0_v12+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_0045;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v102, v69, v70, v35, v36, v37, v38, v39, value, v40, v41, v42, v43, v44, v45, v46);\nL_0045:\n\tvalue = UnityEngine.Mathf::Max(value, v72.min);\n\t// 75 Box v92 @ X0_v16 (System.Object), typeof(System.Single), &value @ V0 (System.Single)\n\tSystem.Reflection.FieldInfo::SetValue(v63, this._Instance, v92);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ConstrainMin<U>(Expression<Func<T, U>> fieldAccess, float value)
		{
			string fieldName = GetFieldName(fieldAccess);
			FieldInfo field = GetField(fieldName);
			MinAttribute attribute = GetAttribute<MinAttribute>(field);
			float num = Mathf.Max(value, attribute.min);
			object value2 = value;
			field.SetValue(_Instance, value2);
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0xBB1F98", Offset = "0xBB1F98", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv32 = *([1ECBBF0]);\n\tv33 = *([v32 @ X8_v21]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, fieldAccess, value, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2022C47]) = v49;\nL_0021:\n\tv56 = EM_Moments.ReflectionUtils`1<T>::GetFieldName(this, fieldAccess);\n\tv63 = EM_Moments.ReflectionUtils`1<T>::GetField(this, v56);\n\tv72 = EM_Moments.ReflectionUtils`1<T>::GetAttribute(this, v63);\n\tgoto L_0045;\n\tv118 = *([v102 @ X0_v12+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_0045;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v102, v69, v70, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0045:\n\tv81 = UnityEngine.Mathf::Max(value, v72.min);\n\t// 76 Box v92 @ X0_v16 (System.Object), typeof(System.Int32), &v81 @ V0_v4 (System.Single)\n\tSystem.Reflection.FieldInfo::SetValue(v63, this._Instance, v92);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ConstrainMin<U>(Expression<Func<T, U>> fieldAccess, int value)
		{
			//IL_0059: Expected I4, but got F4
			string fieldName = GetFieldName(fieldAccess);
			FieldInfo field = GetField(fieldName);
			MinAttribute attribute = GetAttribute<MinAttribute>(field);
			float num = Mathf.Max(value, attribute.min);
			object value2 = (int)num;
			field.SetValue(_Instance, value2);
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0xBB26FC", Offset = "0xBB26FC", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = *([1ECCEF8]);\n\tv35 = *([v34 @ X8_v20]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, fieldAccess, methodInfo, v37, v38, v39, v40, v41, value, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2022C4D]) = v51;\nL_0022:\n\tv58 = EM_Moments.ReflectionUtils`1<T>::GetFieldName(this, fieldAccess);\n\tv65 = EM_Moments.ReflectionUtils`1<T>::GetField(this, v58);\n\tv73 = EM_Moments.ReflectionUtils`1<T>::GetAttribute(this, v65);\n\tgoto L_0048;\n\tv126 = *([v107 @ X8_v15+E0]);\n\tv127 = v126 == 0;\n\tv128 = ~v127;\n\tif (v128) goto L_0048;\n\tv134 = v107;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v134, v69, v71, v37, v38, v39, v40, v41, value, v42, v43, v44, v45, v46, v47, v48);\nL_0048:\n\tvalue = UnityEngine.Mathf::Clamp(value, v73.min, v73.max);\n\t// 78 Box v96 @ X0_v15 (System.Object), typeof(System.Single), &value @ V0 (System.Single)\n\tSystem.Reflection.FieldInfo::SetValue(v65, this._Instance, v96);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ConstrainRange<U>(Expression<Func<T, U>> fieldAccess, float value)
		{
			string fieldName = GetFieldName(fieldAccess);
			FieldInfo field = GetField(fieldName);
			RangeAttribute attribute = GetAttribute<RangeAttribute>(field);
			float num = Mathf.Clamp(value, attribute.min, attribute.max);
			object value2 = value;
			field.SetValue(_Instance, value2);
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0xBB234C", Offset = "0xBB234C", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = *([1EB6B20]);\n\tv35 = *([v34 @ X8_v21]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, fieldAccess, value, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2022C4A]) = v51;\nL_0022:\n\tv58 = EM_Moments.ReflectionUtils`1<T>::GetFieldName(this, fieldAccess);\n\tv65 = EM_Moments.ReflectionUtils`1<T>::GetField(this, v58);\n\tv73 = EM_Moments.ReflectionUtils`1<T>::GetAttribute(this, v65);\n\tgoto L_0048;\n\tv126 = *([v107 @ X8_v15+E0]);\n\tv127 = v126 == 0;\n\tv128 = ~v127;\n\tif (v128) goto L_0048;\n\tv134 = v107;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v134, v69, v71, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0048:\n\tv83 = UnityEngine.Mathf::Clamp(value, v73.min, v73.max);\n\t// 79 Box v96 @ X0_v15 (System.Object), typeof(System.Int32), &v83 @ V0_v4 (System.Single)\n\tSystem.Reflection.FieldInfo::SetValue(v65, this._Instance, v96);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ConstrainRange<U>(Expression<Func<T, U>> fieldAccess, int value)
		{
			//IL_0062: Expected I4, but got F4
			string fieldName = GetFieldName(fieldAccess);
			FieldInfo field = GetField(fieldName);
			RangeAttribute attribute = GetAttribute<RangeAttribute>(field);
			float num = Mathf.Clamp(value, attribute.min, attribute.max);
			object value2 = (int)num;
			field.SetValue(_Instance, value2);
		}
	}
}
