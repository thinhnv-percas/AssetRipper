using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x2000017")]
	public class CActionList : IEnumerable<CAction>, IEnumerable
	{
		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<CAction> m_actions;

		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x18")]
		private readonly Dictionary<int, CAction> m_actionLookupById;

		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x20")]
		private readonly Dictionary<string, CAction> m_actionLookupByName;

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x13DE3C4", Offset = "0x13DE3C4", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F0C678]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AA7]) = v38;\nL_0015:\n\tSystem.Object::.ctor(this);\n\tv44 = new System.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>();\n\tSystem.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>::.ctor(v44);\n\tthis.m_actions = v44;\n\tv52 = new System.Collections.Generic.Dictionary`2<System.Int32, LunarConsolePluginInternal.CAction>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, LunarConsolePluginInternal.CAction>::.ctor(v52);\n\tthis.m_actionLookupById = v52;\n\tv60 = new System.Collections.Generic.Dictionary`2<System.String, LunarConsolePluginInternal.CAction>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, LunarConsolePluginInternal.CAction>::.ctor(v60);\n\tthis.m_actionLookupByName = v60;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CActionList()
		{
			List<CAction> actions = new List<CAction>();
			m_actions = actions;
			m_actionLookupById = new Dictionary<int, CAction>();
			m_actionLookupByName = new Dictionary<string, CAction>();
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x13DE488", Offset = "0x13DE488", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EB7648]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, action, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AA8]) = v41;\nL_001C:\n\tSystem.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>::Add(this.m_actions, action);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, LunarConsolePluginInternal.CAction>::Add(this.m_actionLookupById, action.m_id, action);\n\tSystem.Collections.Generic.Dictionary`2<System.String, LunarConsolePluginInternal.CAction>::Add(this.m_actionLookupByName, action.m_name, action);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Add(CAction action)
		{
			m_actions.Add(action);
			m_actionLookupById.Add(action.Id, action);
			m_actionLookupByName.Add(action.Name, action);
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x13DE53C", Offset = "0x13DE53C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EBEB00]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AA9]) = v41;\nL_001E:\n\tv51 = System.Collections.Generic.Dictionary`2<System.Int32, LunarConsolePluginInternal.CAction>::TryGetValue(this.m_actionLookupById, id, &v48 @ stack_-28_v4 (LunarConsolePluginInternal.CAction));\n\tv73 = v51 == 0;\n\tif (v73) goto L_FFFFFFFF;\n\tv79 = System.Collections.Generic.Dictionary`2<System.Int32, LunarConsolePluginInternal.CAction>::Remove(this.m_actionLookupById, id);\n\tv115 = System.Collections.Generic.Dictionary`2<System.String, LunarConsolePluginInternal.CAction>::Remove(this.m_actionLookupByName, v48.m_name);\n\tv117 = System.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>::Remove(this.m_actions, v48);\n\tgoto L_0046;\nL_0046:\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Remove(int id)
		{
			if (m_actionLookupById.TryGetValue(id, out var value))
			{
				bool flag = m_actionLookupById.Remove(id);
				bool flag2 = m_actionLookupByName.Remove(value.Name);
				bool flag3 = m_actions.Remove(value);
				return true;
			}
			return false;
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x13DE624", Offset = "0x13DE624", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EFF580]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, name, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AAA]) = v41;\nL_001E:\n\tv51 = System.Collections.Generic.Dictionary`2<System.String, LunarConsolePluginInternal.CAction>::TryGetValue(this.m_actionLookupByName, name, &v48 @ stack_-28_v2 (LunarConsolePluginInternal.CAction));\n\tv60 = v51 == 0;\n\tv63 = ~v60;\n\tv64 = ~v63;\n\tif (v64) goto L_FFFFFFFF;\n\tgoto L_0032;\nL_0032:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CAction Find(string name)
		{
			if (m_actionLookupByName.TryGetValue(name, out var value))
			{
				return value;
			}
			return null;
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x13DE6A4", Offset = "0x13DE6A4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EF0C10]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AAB]) = v41;\nL_001E:\n\tv51 = System.Collections.Generic.Dictionary`2<System.Int32, LunarConsolePluginInternal.CAction>::TryGetValue(this.m_actionLookupById, id, &v48 @ stack_-28_v2 (LunarConsolePluginInternal.CAction));\n\tv60 = v51 == 0;\n\tv63 = ~v60;\n\tv64 = ~v63;\n\tif (v64) goto L_FFFFFFFF;\n\tgoto L_0032;\nL_0032:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CAction Find(int id)
		{
			if (m_actionLookupById.TryGetValue(id, out var value))
			{
				return value;
			}
			return null;
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x13DE724", Offset = "0x13DE724", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EABDC8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AAC]) = v38;\nL_0019:\n\tSystem.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>::Clear(this.m_actions);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, LunarConsolePluginInternal.CAction>::Clear(this.m_actionLookupById);\n\tSystem.Collections.Generic.Dictionary`2<System.String, LunarConsolePluginInternal.CAction>::Clear(this.m_actionLookupByName);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear()
		{
			m_actions.Clear();
			m_actionLookupById.Clear();
			m_actionLookupByName.Clear();
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x13DE7AC", Offset = "0x13DE7AC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EE9C70]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AAD]) = v38;\nL_001A:\n\tv46 = System.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>::GetEnumerator(this.m_actions);\n\t// 35 Box returnVal2 @ X0_v6 (System.Collections.Generic.IEnumerator`1<LunarConsolePluginInternal.CAction>), typeof(System.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>+Enumerator<LunarConsolePluginInternal.CAction>), &v45 @ stack_-38_v1\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerator<CAction> GetEnumerator()
		{
			List<CAction>.Enumerator enumerator = m_actions.GetEnumerator();
			object obj = default(object);
			return (List<CAction>.Enumerator)obj;
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0x13DE838", Offset = "0x13DE838", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EB5508]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AAE]) = v38;\nL_001A:\n\tv46 = System.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>::GetEnumerator(this.m_actions);\n\t// 35 Box returnVal2 @ X0_v6 (System.Collections.IEnumerator), typeof(System.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>+Enumerator<LunarConsolePluginInternal.CAction>), &v45 @ stack_-38_v1\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		IEnumerator IEnumerable.GetEnumerator()
		{
			List<CAction>.Enumerator enumerator = m_actions.GetEnumerator();
			object obj = default(object);
			return (List<CAction>.Enumerator)obj;
		}
	}
}
