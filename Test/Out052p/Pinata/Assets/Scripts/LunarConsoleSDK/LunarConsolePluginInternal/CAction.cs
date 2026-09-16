using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x2000016")]
	public class CAction : IComparable<CAction>
	{
		[Token(Token = "0x4000041")]
		private static readonly string[] kEmptyArgs;

		[Token(Token = "0x4000042")]
		private static int s_nextActionId;

		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x10")]
		private readonly int m_id;

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x18")]
		private readonly string m_name;

		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x20")]
		private Delegate m_actionDelegate;

		[Token(Token = "0x17000018")]
		public int Id
		{
			[Token(Token = "0x6000088")]
			[Address(RVA = "0x13DDE94", Offset = "0x13DDE94", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_id;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Id;
			}
		}

		[Token(Token = "0x17000019")]
		public string Name
		{
			[Token(Token = "0x6000089")]
			[Address(RVA = "0x13DDE9C", Offset = "0x13DDE9C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
		}

		[Token(Token = "0x1700001A")]
		public Delegate ActionDelegate
		{
			[Token(Token = "0x600008A")]
			[Address(RVA = "0x13DDEA4", Offset = "0x13DDEA4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_actionDelegate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ActionDelegate;
			}
			[Token(Token = "0x600008B")]
			[Address(RVA = "0x13DDEAC", Offset = "0x13DDEAC", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F0ACF8]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AA5]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_0022;\n\tthis.m_actionDelegate = value;\n\treturn;\nL_0022:\n\tv51 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v51, \"actionDelegate\");\n\tthrow v51;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (value != null)
				{
					m_actionDelegate = value;
					return;
				}
				ArgumentNullException ex = new ArgumentNullException("actionDelegate");
				throw ex;
			}
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x13DDB54", Offset = "0x13DDB54", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EC15A8]);\n\tv27 = *([v26 @ X8_v26]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, actionDelegate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2028AA1]) = v44;\nL_0019:\n\tSystem.Object::.ctor(this);\n\tv47 = name == 0;\n\tif (v47) goto L_0040;\n\tv49 = name.m_stringLength == 0;\n\tif (v49) goto L_0047;\n\tv54 = actionDelegate == 0;\n\tif (v54) goto L_0052;\n\tgoto L_0030;\n\tv83 = *([v63 @ X0_v13 (Il2CppClass<LunarConsolePluginInternal.CAction>)+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0030;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v63, v46, actionDelegate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv87 = LunarConsolePluginInternal.CAction;\nL_0030:\n\tv92 = v90.s_nextActionId + 1;\n\tv90.s_nextActionId = v92;\n\tthis.m_id = v90.s_nextActionId;\n\tthis.m_name = name;\n\tthis.m_actionDelegate = actionDelegate;\n\treturn;\nL_0040:\n\tv76 = new System.ArgumentNullException();\n\tgoto L_0058;\nL_0047:\n\tv58 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v58, \"Action name is empty\");\n\tgoto L_005E;\nL_0052:\n\tv76 = new System.ArgumentNullException();\nL_0058:\n\tSystem.ArgumentNullException::.ctor(v76, *([v78 @ X8_v3 (System.String)]));\nL_005E:\n\tthrow v104;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CAction(string name, Delegate actionDelegate)
		{
			if (name != null)
			{
				if (name.Length != 0)
				{
					if (actionDelegate != null)
					{
						int num = s_nextActionId + 1;
						s_nextActionId = num;
						m_id = s_nextActionId;
						m_name = name;
						m_actionDelegate = actionDelegate;
						return;
					}
					ArgumentNullException ex = new ArgumentNullException();
					string text = "actionDelegate";
				}
				else
				{
					ArgumentException ex2 = new ArgumentException("Action name is empty");
				}
			}
			else
			{
				string text = default(string);
				ArgumentNullException ex = new ArgumentNullException(text);
				text = "name";
			}
			object obj = default(object);
			throw obj;
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x13DA15C", Offset = "0x13DA15C", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EC48D8]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028AA2]) = v40;\nL_001B:\n\tgoto L_002A;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.CAction>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_002A;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = LunarConsolePluginInternal.CAction;\nL_002A:\n\tgoto L_0033;\n\tv64 = *([v58 @ X8_v7+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_0033;\n\tv74 = v58;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv73 = LunarConsolePluginInternal.ReflectionUtils::Invoke(this.m_actionDelegate, v57.kEmptyArgs);\nL_0034:\n\t;\n\treturn v73;\n\tgoto L_003D;\nL_003D:\n\tX20 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_009F;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX8 = *([1EA8FC8]);\n\tX1 = *([X20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_005A;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0093;\n\tX20 = *([X20+28]);\n\tgoto L_0064;\nL_005A:\n\tX9 = 0x1EDD000;\n\tX8 = *([X21]);\n\tX9 = *([1EDD7C0]);\n\tX1 = *([X8]);\n\tX0 = *([X9]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0095;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0064:\n\tX8 = 0x1EFE000;\n\tX8 = *([1EFE3C0]);\n\tX1 = 0 | 1;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tif (TEMP) goto L_0094;\n\tX19 = *([X19+18]);\n\tif (TEMP) goto L_0075;\n\tX8 = *([X21]);\n\tX0 = X19;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_008F;\nL_0075:\n\tX8 = *([X21+18]);\n\tif (TEMP) goto L_008D;\n\t*([X21+20]) = X19;\n\tX8 = *([1EB5228]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0085;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0085;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0085:\n\tX8 = 0x1EE5000;\n\tX8 = *([1EE5BF8]);\n\tX0 = X20;\n\tX2 = X21;\n\tX1 = *([X8]);\n\tLunarConsolePluginInternal.Log::e(X0, X1, X2, X3);\n\tX0 = 0;\n\tgoto L_0034;\nL_008D:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0090;\nL_008F:\n\tX0 = 0x8D82D8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0090:\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0093:\n\tX0 = 0;\nL_0094:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0095:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009F:\n\tX0 = X20;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Execute()
		{
			return ReflectionUtils.Invoke(ActionDelegate, kEmptyArgs);
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x13DDD58", Offset = "0x13DDD58", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EE4D58]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, prefix, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AA3]) = v41;\nL_0018:\n\tv45 = LunarConsolePluginInternal.StringUtils;\n\tv47 = *([v45 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+12F]) & 2;\n\tv48 = v47 == 0;\n\tif (v48) goto L_0020;\n\tv50 = *([v45 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]) == 0;\n\tif (v50) goto L_0031;\nL_0020:\n\tv53 = prefix == 0;\n\tif (v53) goto L_003B;\nL_0022:\n\tv59 = this.m_name == 0;\n\tif (v59) goto L_003B;\n\treturnVal2 = System.String::StartsWith(this.m_name, prefix, 5);\n\treturn returnVal2;\nL_0031:\n\tv69 = prefix == 0;\n\tv57 = ~v69;\n\tif (v57) goto L_0022;\nL_003B:\n\treturn 0;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal bool StartsWith(string prefix)
		{
			//IL_00bf: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(StringUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					if (prefix != null)
					{
						goto IL_0047;
					}
					goto IL_00ab;
				}
			}
			if (prefix != null)
			{
				goto IL_0047;
			}
			goto IL_00ab;
			IL_0047:
			if (Name != null)
			{
				return Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase);
			}
			goto IL_00ab;
			IL_00ab:
			return false;
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x13DDE14", Offset = "0x13DDE14", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.String::CompareTo(this.m_name, other.m_name);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(CAction other)
		{
			return Name.CompareTo(other.Name);
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x13DDE40", Offset = "0x13DDE40", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EA67B8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AA4]) = v38;\nL_001E:\n\treturnVal1 = System.String::Format(\"{0} ({1})\", this.m_name, this.m_actionDelegate);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return $"{Name} ({ActionDelegate})";
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x13DDF40", Offset = "0x13DDF40", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1F008D0]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2028AA6]) = v35;\nL_0015:\n\t// 21 NewArr v40 @ X0_v3 (System.String[]), typeof(System.String[]), 0\n\tv44.kEmptyArgs = v40;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static CAction()
		{
			string[] array = new string[0];
			kEmptyArgs = array;
		}
	}
}
