using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LunarConsolePlugin
{
	[Token(Token = "0x2000008")]
	public class CVarList : IEnumerable<CVar>, IEnumerable
	{
		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<CVar> m_variables;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x18")]
		private readonly Dictionary<int, CVar> m_lookupById;

		[Token(Token = "0x17000012")]
		public int Count
		{
			[Token(Token = "0x6000037")]
			[Address(RVA = "0x13D57F8", Offset = "0x13D57F8", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFF170]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A60]) = v38;\nL_0013:\n\tv39 = this.m_variables;\n\treturn v39._size;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<CVar> variables = m_variables;
				return variables.Count;
			}
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x13D52DC", Offset = "0x13D52DC", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EEFAB8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A58]) = v38;\nL_0015:\n\tSystem.Object::.ctor(this);\n\tv44 = new System.Collections.Generic.List`1<LunarConsolePlugin.CVar>();\n\tSystem.Collections.Generic.List`1<LunarConsolePlugin.CVar>::.ctor(v44);\n\tthis.m_variables = v44;\n\tv52 = new System.Collections.Generic.Dictionary`2<System.Int32, LunarConsolePlugin.CVar>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, LunarConsolePlugin.CVar>::.ctor(v52);\n\tthis.m_lookupById = v52;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CVarList()
		{
			List<CVar> variables = new List<CVar>();
			m_variables = variables;
			m_lookupById = new Dictionary<int, CVar>();
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x13D5378", Offset = "0x13D5378", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1F0F210]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, variable, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A59]) = v41;\nL_001C:\n\tSystem.Collections.Generic.List`1<LunarConsolePlugin.CVar>::Add(this.m_variables, variable);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, LunarConsolePlugin.CVar>::Add(this.m_lookupById, variable.m_id, variable);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Add(CVar variable)
		{
			m_variables.Add(variable);
			m_lookupById.Add(variable.Id, variable);
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x13D540C", Offset = "0x13D540C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1ED5030]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A5A]) = v41;\nL_001E:\n\tv51 = System.Collections.Generic.Dictionary`2<System.Int32, LunarConsolePlugin.CVar>::TryGetValue(this.m_lookupById, id, &v48 @ stack_-28_v3 (LunarConsolePlugin.CVar));\n\tv68 = v51 == 0;\n\tif (v68) goto L_FFFFFFFF;\n\tv93 = System.Collections.Generic.Dictionary`2<System.Int32, LunarConsolePlugin.CVar>::Remove(this.m_lookupById, id);\n\tv99 = System.Collections.Generic.List`1<LunarConsolePlugin.CVar>::Remove(this.m_variables, v48);\n\tgoto L_003B;\nL_003B:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Remove(int id)
		{
			if (m_lookupById.TryGetValue(id, out var value))
			{
				bool flag = m_lookupById.Remove(id);
				bool flag2 = m_variables.Remove(value);
				return true;
			}
			return false;
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x13D54C8", Offset = "0x13D54C8", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1F0B498]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A5B]) = v41;\nL_001E:\n\tv51 = System.Collections.Generic.Dictionary`2<System.Int32, LunarConsolePlugin.CVar>::TryGetValue(this.m_lookupById, id, &v48 @ stack_-28_v2 (LunarConsolePlugin.CVar));\n\tv60 = v51 == 0;\n\tv63 = ~v60;\n\tv64 = ~v63;\n\tif (v64) goto L_FFFFFFFF;\n\tgoto L_0032;\nL_0032:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CVar Find(int id)
		{
			if (m_lookupById.TryGetValue(id, out var value))
			{
				return value;
			}
			return null;
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x13D5548", Offset = "0x13D5548", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EEA4C0]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, name, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A5C]) = v41;\nL_0017:\n\tv44 = 0;\n\tv46 = this.m_variables == 0;\n\tif (v46) goto L_003C;\n\tv51 = System.Collections.Generic.List`1<LunarConsolePlugin.CVar>::GetEnumerator(this.m_variables);\nL_0024:\n\tv76 = System.Collections.Generic.List`1<LunarConsolePlugin.CVar>+Enumerator<LunarConsolePlugin.CVar>::MoveNext(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<LunarConsolePlugin.CVar>+Enumerator<LunarConsolePlugin.CVar>));\n\tv88 = v76 == 0;\n\tif (v88) goto L_FFFFFFFF;\n\tv61 = 0;\n\tv71 = System.String::op_Equality(v61.m_name, name);\n\tv73 = v71 == 0;\n\tif (v73) goto L_0024;\n\tgoto L_0038;\nL_0038:\n\tv118 = System.Collections.Generic.List`1<LunarConsolePlugin.CVar>+Enumerator<LunarConsolePlugin.CVar>::Dispose(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<LunarConsolePlugin.CVar>+Enumerator<LunarConsolePlugin.CVar>));\n\tgoto L_005D;\n\tv57 = new System.NullReferenceException();\nL_003C:\n\tv65 = new System.NullReferenceException();\n\tgoto L_0048;\n\tgoto L_0048;\nL_0048:\n\tv86 = Il2CppMethodInfo != 1;\n\tif (v86) goto L_005E;\n\tv89 = 0x6D2BC0(v65, Il2CppMethodInfo, v52, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv93 = 0x6D2490(v89, Il2CppMethodInfo, v52, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv97 = System.Collections.Generic.List`1<LunarConsolePlugin.CVar>+Enumerator<LunarConsolePlugin.CVar>::Dispose(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<LunarConsolePlugin.CVar>+Enumerator<LunarConsolePlugin.CVar>));\n\tv122 = *([v89 @ X0_v11]) == 0;\n\tv99 = ~v122;\n\tif (v99) goto L_0062;\nL_005D:\n\treturn v171;\nL_005E:\n\tv90 = 0x6D2380(v65, Il2CppMethodInfo, v52, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0062:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CVar Find(string name)
		{
			//IL_004d: Expected I, but got O
			List<CVar>.Enumerator enumerator = default(List<CVar>.Enumerator);
			CVar result;
			if (m_variables != null)
			{
				List<CVar>.Enumerator enumerator2 = m_variables.GetEnumerator();
				while (true)
				{
					if (enumerator.MoveNext())
					{
						CVar cVar = null;
						bool flag = cVar.Name == name;
						bool flag2 = !flag;
						IntPtr intPtr = (IntPtr)null;
						if (!flag2)
						{
							result = null;
							break;
						}
						continue;
					}
					result = null;
					break;
				}
				enumerator.Dispose();
				goto IL_017c;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					result = null;
					goto IL_017c;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			return (CVar)(object)new TypeLoadException();
			IL_017c:
			return result;
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x13D5670", Offset = "0x13D5670", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F04FC0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A5D]) = v38;\nL_0019:\n\tSystem.Collections.Generic.List`1<LunarConsolePlugin.CVar>::Clear(this.m_variables);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, LunarConsolePlugin.CVar>::Clear(this.m_lookupById);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear()
		{
			m_variables.Clear();
			m_lookupById.Clear();
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x13D56E0", Offset = "0x13D56E0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EF0AB0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A5E]) = v38;\nL_001A:\n\tv46 = System.Collections.Generic.List`1<LunarConsolePlugin.CVar>::GetEnumerator(this.m_variables);\n\t// 35 Box returnVal2 @ X0_v6 (System.Collections.Generic.IEnumerator`1<LunarConsolePlugin.CVar>), typeof(System.Collections.Generic.List`1<LunarConsolePlugin.CVar>+Enumerator<LunarConsolePlugin.CVar>), &v45 @ stack_-38_v1\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerator<CVar> GetEnumerator()
		{
			List<CVar>.Enumerator enumerator = m_variables.GetEnumerator();
			object obj = default(object);
			return (List<CVar>.Enumerator)obj;
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x13D576C", Offset = "0x13D576C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EEEFF8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A5F]) = v38;\nL_001A:\n\tv46 = System.Collections.Generic.List`1<LunarConsolePlugin.CVar>::GetEnumerator(this.m_variables);\n\t// 35 Box returnVal2 @ X0_v6 (System.Collections.IEnumerator), typeof(System.Collections.Generic.List`1<LunarConsolePlugin.CVar>+Enumerator<LunarConsolePlugin.CVar>), &v45 @ stack_-38_v1\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		IEnumerator IEnumerable.GetEnumerator()
		{
			List<CVar>.Enumerator enumerator = m_variables.GetEnumerator();
			object obj = default(object);
			return (List<CVar>.Enumerator)obj;
		}
	}
}
