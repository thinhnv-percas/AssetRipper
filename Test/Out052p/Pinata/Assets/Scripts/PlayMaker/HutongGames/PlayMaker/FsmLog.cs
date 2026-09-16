using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x200006E")]
	public class FsmLog
	{
		[Token(Token = "0x40002A7")]
		public static int MaxSize;

		[Token(Token = "0x40002A8")]
		private static readonly List<FsmLog> Logs;

		[Token(Token = "0x40002A9")]
		private static readonly FsmLogEntry[] logEntryPool;

		[Token(Token = "0x40002AA")]
		private static int nextLogEntryPoolIndex;

		[CompilerGenerated]
		[Token(Token = "0x40002AE")]
		[FieldOffset(Offset = "0x10")]
		private Fsm _003CFsm_003Ek__BackingField;

		[Token(Token = "0x40002AF")]
		[FieldOffset(Offset = "0x18")]
		private List<FsmLogEntry> entries;

		[Token(Token = "0x17000176")]
		[field: Token(Token = "0x40002AB")]
		public static bool LoggingEnabled
		{
			[Token(Token = "0x60004DF")]
			[Address(RVA = "0xCAD3A8", Offset = "0xCAD3A8", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE27F8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235F1]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmLog;\nL_0024:\n\treturn v49.<LoggingEnabled>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004E0")]
			[Address(RVA = "0xCAD410", Offset = "0xCAD410", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE5E00]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235F2]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmLog;\nL_0022:\n\tv52.<LoggingEnabled>k__BackingField = value;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set;
		}

		[Token(Token = "0x17000177")]
		[field: Token(Token = "0x40002AC")]
		public static bool MirrorDebugLog
		{
			[Token(Token = "0x60004E1")]
			[Address(RVA = "0xCAD480", Offset = "0xCAD480", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDDA60]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235F3]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmLog;\nL_0024:\n\treturn v49.<MirrorDebugLog>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004E2")]
			[Address(RVA = "0xCAD4E8", Offset = "0xCAD4E8", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFE498]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235F4]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmLog;\nL_0022:\n\tv52.<MirrorDebugLog>k__BackingField = value;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set;
		}

		[Token(Token = "0x17000178")]
		[field: Token(Token = "0x40002AD")]
		public static bool EnableDebugFlow
		{
			[Token(Token = "0x60004E3")]
			[Address(RVA = "0xCAD558", Offset = "0xCAD558", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F109A0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235F5]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmLog;\nL_0024:\n\treturn v49.<EnableDebugFlow>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60004E4")]
			[Address(RVA = "0xCAD5C0", Offset = "0xCAD5C0", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB2DF8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235F6]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmLog;\nL_0022:\n\tv52.<EnableDebugFlow>k__BackingField = value;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set;
		}

		[Token(Token = "0x17000179")]
		public Fsm Fsm
		{
			[CompilerGenerated]
			[Token(Token = "0x60004E5")]
			[Address(RVA = "0xCAD630", Offset = "0xCAD630", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Fsm>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Fsm;
			}
			[CompilerGenerated]
			[Token(Token = "0x60004E6")]
			[Address(RVA = "0xCAD638", Offset = "0xCAD638", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Fsm>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CFsm_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700017A")]
		public List<FsmLogEntry> Entries
		{
			[Token(Token = "0x60004E7")]
			[Address(RVA = "0xCAD640", Offset = "0xCAD640", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.entries;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Entries;
			}
		}

		[Token(Token = "0x60004DE")]
		[Address(RVA = "0xCAD1F4", Offset = "0xCAD1F4", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EAC8F0]);\n\tv23 = *([v22 @ X8_v36]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([20235F0]) = v43;\nL_001A:\n\tv48.MaxSize = 0x2710;\n\tv52 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>::.ctor(v52);\n\tv59.Logs = v52;\n\tv60 = UnityEngine.Application::get_isEditor();\n\tgoto L_0036;\n\tv67 = *([1EBFBA0]);\n\tv68 = *([v67 @ X8_v33]);\n\tv69 = \"il2cpp_codegen_initialize_method\"(v68, v56, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv72 = 0 | 1;\n\t*([2023702]) = v72;\nL_0036:\n\tv74 = v60 ^ 1;\n\tgoto L_0042;\n\tv78 = *([v73 @ X0_v7 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tgoto L_0042;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v73, v56, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = HutongGames.PlayMaker.FsmLog;\nL_0042:\n\tv86 = v74 & 1;\n\tv85.<LoggingEnabled>k__BackingField = v86;\n\t// 73 NewArr v92 @ X0_v10 (HutongGames.PlayMaker.FsmLogEntry[]), typeof(HutongGames.PlayMaker.FsmLogEntry[]), v88.MaxSize (System.Int32)\n\tv95.logEntryPool = v92;\n\tv159 = v96.logEntryPool;\nL_005E:\n\tv103 = v160 >= v159.Length;\n\tif (v103) goto L_008C;\n\tv202 = new HutongGames.PlayMaker.FsmLogEntry();\n\tSystem.Object::.ctor(v202);\n\tv239 = v202 == 0;\n\tif (v239) goto L_006E;\n\t// 106 IsInst v243 @ X0_v23, typeof(HutongGames.PlayMaker.FsmLogEntry), v202 @ X0_v17 (HutongGames.PlayMaker.FsmLogEntry)\nL_006E:\n\tv248 = v160 < v159.Length;\n\tv130 = ~v248;\n\tif (v130) goto L_008D;\n\tv159[v160 @ X21_v6 (System.Int32)] = v202;\n\tv160 = v160 + 1;\n\tv159 = v144.logEntryPool;\n\tv251 = v144.logEntryPool == 0;\n\tv142 = ~v251;\n\tif (v142) goto L_005E;\n\tthrow System.NullReferenceException;\nL_008C:\n\treturn;\nL_008D:\n\tv252 = new System.IndexOutOfRangeException();\n\tgoto L_0092;\n\tv253 = new System.ArrayTypeMismatchException();\nL_0092:\n\tthrow v255;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static FsmLog()
		{
			MaxSize = 10000;
			List<FsmLog> logs = new List<FsmLog>();
			Logs = logs;
			bool isEditor = Application.isEditor;
			int num = (isEditor ? 1 : 0) ^ 1;
			int num2 = num & 1;
			LoggingEnabled = (byte)num2 != 0;
			FsmLogEntry[] array = new FsmLogEntry[MaxSize];
			logEntryPool = array;
			FsmLogEntry[] array2 = logEntryPool;
			int num3 = 0;
			while (true)
			{
				if (num3 < array2.Length)
				{
					FsmLogEntry fsmLogEntry = new FsmLogEntry();
					if (fsmLogEntry != null)
					{
						object obj = fsmLogEntry as FsmLogEntry;
					}
					if (num3 >= array2.Length)
					{
						break;
					}
					array2[num3] = fsmLogEntry;
					num3++;
					array2 = logEntryPool;
					if (logEntryPool == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60004E8")]
		[Address(RVA = "0xCAD648", Offset = "0xCAD648", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EF1528]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, fsm, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20235F7]) = v41;\nL_0018:\n\tv45 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLogEntry>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLogEntry>::.ctor(v45);\n\tthis.entries = v45;\n\tSystem.Object::.ctor(this);\n\tthis.<Fsm>k__BackingField = fsm;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmLog(Fsm fsm)
		{
			List<FsmLogEntry> list = new List<FsmLogEntry>();
			entries = list;
			Fsm = fsm;
		}

		[Token(Token = "0x60004E9")]
		[Address(RVA = "0xCAD6CC", Offset = "0xCAD6CC", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EA3668]);\n\tv23 = *([v22 @ X8_v31]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20235F8]) = v42;\nL_0017:\n\tv45 = 0;\n\tv46 = fsm == 0;\n\tif (v46) goto L_FFFFFFFF;\n\tgoto L_002F;\n\tv54 = *([v49 @ X0_v4 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\t// 36 ConditionalJump @b39, v56 @ TEMP_v27\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv58 = HutongGames.PlayMaker.FsmLog;\nL_002F:\n\tv132 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>::GetEnumerator(v61.Logs);\nL_0034:\n\tv227 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>::MoveNext(&v45 @ stack_-48_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>));\n\tv241 = v227 == 0;\n\tif (v241) goto L_0053;\n\tv119 = 0;\n\tgoto L_0056;\n\tv68 = v119.<Fsm>k__BackingField != fsm;\n\tif (v68) goto L_0034;\n\tv110 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>::Dispose(&v45 @ stack_-48_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>));\n\tgoto L_008F;\n\tgoto L_008F;\nL_0053:\n\tv246 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>::Dispose(&v45 @ stack_-48_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>));\n\tgoto L_006F;\nL_0056:\n\tv210 = new System.NullReferenceException();\n\tgoto L_0061;\nL_0061:\n\tv189 = Il2CppMethodInfo != 1;\n\tif (v189) goto L_0091;\n\tv259 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>::MoveNext(v210);\n\tv264 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>::MoveNext(v259);\n\tv235 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>::Dispose(&v45 @ stack_-48_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>));\n\tv276 = ~v259.m_value;\n\tv236 = ~v276;\n\tif (v236) goto L_0095;\nL_006F:\n\tv257 = new HutongGames.PlayMaker.FsmLog();\n\tHutongGames.PlayMaker.FsmLog::.ctor(v257, fsm);\n\tgoto L_0086;\n\tv265 = *([v260 @ X0_v21 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv266 = v265 == 0;\n\tv267 = ~v266;\n\t// 123 ConditionalJump @b41, v267 @ TEMP_v22\n\tv274 = \"il2cpp_codegen_runtime_class_init\"(v260, v144, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv269 = HutongGames.PlayMaker.FsmLog;\nL_0086:\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>::Add(v148.Logs, v257);\nL_008F:\n\treturn v117;\n\tv150 = new System.NullReferenceException();\nL_0091:\n\tv215 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>::MoveNext(v209);\nL_0095:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static FsmLog GetLog(Fsm fsm)
		{
			List<FsmLog>.Enumerator enumerator = default(List<FsmLog>.Enumerator);
			if (fsm != null)
			{
				List<FsmLog>.Enumerator enumerator2 = Logs.GetEnumerator();
				if (enumerator.MoveNext())
				{
					FsmLog fsmLog = null;
					NullReferenceException ex = new NullReferenceException();
					if ((IntPtr)0 == (IntPtr)1)
					{
						bool flag = ((List<FsmLog>.Enumerator*)ex)->MoveNext();
						bool flag2 = (flag ? ((List<FsmLog>.Enumerator*)1) : ((List<FsmLog>.Enumerator*)null))->MoveNext();
						enumerator.Dispose();
						if (!((bool*)(flag ? 1 : 0))->m_value)
						{
							goto IL_00f3;
						}
					}
					else
					{
						NullReferenceException ex2 = default(NullReferenceException);
						bool flag3 = ((List<FsmLog>.Enumerator*)ex2)->MoveNext();
					}
					return (FsmLog)(object)new TypeLoadException();
				}
				enumerator.Dispose();
				goto IL_00f3;
			}
			return null;
			IL_00f3:
			FsmLog fsmLog2 = new FsmLog(fsm);
			Logs.Add(fsmLog2);
			return fsmLog2;
		}

		[Token(Token = "0x60004EA")]
		[Address(RVA = "0xCAD874", Offset = "0xCAD874", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1ED2B78]);\n\tv15 = *([v14 @ X8_v19]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235F9]) = v35;\nL_0015:\n\tv40 = 0;\n\tgoto L_0023;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv49 = HutongGames.PlayMaker.FsmLog;\nL_0023:\n\tv54 = v52.Logs == 0;\n\tif (v54) goto L_003E;\n\tv60 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>::GetEnumerator(v52.Logs);\nL_002E:\n\tv77 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>::MoveNext(&v40 @ stack_-38_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>));\n\tv89 = v77 == 0;\n\tif (v89) goto L_003B;\n\tHutongGames.PlayMaker.FsmLog::Clear(0);\n\tgoto L_002E;\nL_003B:\n\tv96 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>::Dispose(&v40 @ stack_-38_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>));\n\tgoto L_005B;\n\tv64 = new System.NullReferenceException();\nL_003E:\n\tv70 = new System.NullReferenceException();\n\tgoto L_004A;\n\tgoto L_004A;\nL_004A:\n\tv87 = Il2CppMethodInfo != 1;\n\tif (v87) goto L_005C;\n\tv90 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>::MoveNext(v70);\n\tv98 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>::MoveNext(v90);\n\tv102 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>::Dispose(&v40 @ stack_-38_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>));\n\tv140 = ~v90.m_value;\n\tv104 = ~v140;\n\tif (v104) goto L_0060;\nL_005B:\n\treturn;\nL_005C:\n\tv91 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>+Enumerator<HutongGames.PlayMaker.FsmLog>::MoveNext(v70);\nL_0060:\n\tthrow System.TypeLoadException;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void ClearLogs()
		{
			List<FsmLog>.Enumerator enumerator = default(List<FsmLog>.Enumerator);
			if (Logs != null)
			{
				List<FsmLog>.Enumerator enumerator2 = Logs.GetEnumerator();
				while (enumerator.MoveNext())
				{
					((FsmLog)null).Clear();
				}
				enumerator.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				bool flag = ((List<FsmLog>.Enumerator*)ex)->MoveNext();
				bool flag2 = (flag ? ((List<FsmLog>.Enumerator*)1) : ((List<FsmLog>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (!((bool*)(flag ? 1 : 0))->m_value)
				{
					return;
				}
			}
			else
			{
				bool flag3 = ((List<FsmLog>.Enumerator*)ex)->MoveNext();
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60004EB")]
		[Address(RVA = "0xCAD9F4", Offset = "0xCAD9F4", Length = "0x398")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = *([1EF02F0]);\n\tv29 = *([v28 @ X8_v55]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, entry, sendToUnityLog, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20235FA]) = v46;\nL_001A:\n\tentry.<Log>k__BackingField = v44;\n\tv48 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tentry.<Time>k__BackingField = v48;\n\tv159 = UnityEngine.Time::get_frameCount();\n\tentry.<FrameCount>k__BackingField = v159;\n\tv197 = entry.<Event>k__BackingField == 0;\n\tif (v197) goto L_0082;\n\tv107 = HutongGames.PlayMaker.FsmEvent::get_IsCollisionEvent(entry.<Event>k__BackingField);\n\tv290 = v107 == 0;\n\tif (v290) goto L_003A;\n\tv139 = entry.<Log>k__BackingField;\n\tv108 = HutongGames.PlayMaker.Fsm::get_CollisionGO(v139.<Fsm>k__BackingField);\n\tv140 = entry.<Log>k__BackingField;\n\tentry.<GameObject>k__BackingField = v108;\n\tv141 = v140.<Fsm>k__BackingField;\n\tv205 = v141.<CollisionName>k__BackingField;\n\tgoto L_007A;\nL_003A:\n\tv109 = HutongGames.PlayMaker.FsmEvent::get_IsTriggerEvent(entry.<Event>k__BackingField);\n\tv297 = v109 == 0;\n\tif (v297) goto L_0050;\n\tv142 = entry.<Log>k__BackingField;\n\tv110 = HutongGames.PlayMaker.Fsm::get_TriggerGO(v142.<Fsm>k__BackingField);\n\tv143 = entry.<Log>k__BackingField;\n\tentry.<GameObject>k__BackingField = v110;\n\tv144 = v143.<Fsm>k__BackingField;\n\tv205 = v144.<TriggerName>k__BackingField;\n\tgoto L_007A;\nL_0050:\n\tv111 = HutongGames.PlayMaker.FsmEvent::get_IsCollision2DEvent(entry.<Event>k__BackingField);\n\tv311 = v111 == 0;\n\tif (v311) goto L_0066;\n\tv145 = entry.<Log>k__BackingField;\n\tv112 = HutongGames.PlayMaker.Fsm::get_Collision2dGO(v145.<Fsm>k__BackingField);\n\tv146 = entry.<Log>k__BackingField;\n\tentry.<GameObject>k__BackingField = v112;\n\tv147 = v146.<Fsm>k__BackingField;\n\tv205 = v147.<Collision2dName>k__BackingField;\n\tgoto L_007A;\nL_0066:\n\tv113 = HutongGames.PlayMaker.FsmEvent::get_IsTrigger2DEvent(entry.<Event>k__BackingField);\n\tv204 = v113 == 0;\n\tif (v204) goto L_0082;\n\tv148 = entry.<Log>k__BackingField;\n\tv114 = HutongGames.PlayMaker.Fsm::get_Trigger2dGO(v148.<Fsm>k__BackingField);\n\tv149 = entry.<Log>k__BackingField;\n\tentry.<GameObject>k__BackingField = v114;\n\tv150 = v149.<Fsm>k__BackingField;\n\tv205 = v150.<Trigger2dName>k__BackingField;\nL_007A:\n\tentry.<GameObjectName>k__BackingField = v205;\nL_0082:\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLogEntry>::Add(v44.entries, entry);\n\tv78 = entry.<LogType>k__BackingField == 1;\n\tif (v78) goto L_00C3;\n\tv53 = entry.<LogType>k__BackingField != 2;\n\tif (v53) goto L_00F1;\n\tv303 = HutongGames.PlayMaker.FsmLogEntry::get_Text(entry);\n\tv115 = HutongGames.PlayMaker.FsmLog::FormatUnityLogString(v44, v303);\n\tv151 = entry.<Log>k__BackingField;\n\tv353 = HutongGames.PlayMaker.Fsm::get_OwnerObject(v151.<Fsm>k__BackingField);\n\tgoto L_00C0;\n\tv379 = *([v275 @ X8_v35+E0]);\n\tv380 = v379 == 0;\n\tv381 = ~v380;\n\tif (v381) goto L_00C0;\n\tv386 = v275;\n\tv383 = \"il2cpp_codegen_runtime_class_init\"(v386, v352, v96, methodInfo, v32, v33, v34, v35, v48, v37, v38, v39, v40, v41, v42, v43);\nL_00C0:\n\tUnityEngine.Debug::LogError(v115, v353);\n\treturn;\nL_00C3:\n\tv300 = HutongGames.PlayMaker.FsmLogEntry::get_Text(entry);\n\tv116 = HutongGames.PlayMaker.FsmLog::FormatUnityLogString(v44, v300);\n\tv152 = entry.<Log>k__BackingField;\n\tv348 = HutongGames.PlayMaker.Fsm::get_OwnerObject(v152.<Fsm>k__BackingField);\n\tgoto L_00E9;\n\tv374 = *([v276 @ X8_v12+E0]);\n\tv375 = v374 == 0;\n\tv376 = ~v375;\n\tif (v376) goto L_00E9;\n\tv385 = v276;\n\tv378 = \"il2cpp_codegen_runtime_class_init\"(v385, v347, v96, methodInfo, v32, v33, v34, v35, v48, v37, v38, v39, v40, v41, v42, v43);\nL_00E9:\n\tUnityEngine.Debug::LogWarning(v116, v348);\n\treturn;\nL_00F1:\n\tgoto L_00FB;\n\tv313 = *([v305 @ X0_v20+E0]);\n\tv314 = v313 == 0;\n\tv315 = ~v314;\n\tif (v315) goto L_00FB;\n\tv317 = \"il2cpp_codegen_runtime_class_init\"(v305, v246, v96, methodInfo, v32, v33, v34, v35, v48, v37, v38, v39, v40, v41, v42, v43);\nL_00FB:\n\tgoto L_0106;\n\tv325 = *([1ED9E00]);\n\tv326 = *([v325 @ X8_v29]);\n\tv327 = \"il2cpp_codegen_initialize_method\"(v326, v246, v96, methodInfo, v32, v33, v34, v35, v48, v37, v38, v39, v40, v41, v42, v43);\n\tv330 = 0 | 1;\n\t*([2023703]) = v330;\nL_0106:\n\tgoto L_010F;\n\tv337 = *([v331 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv338 = v337 == 0;\n\tv339 = ~v338;\n\tgoto L_010F;\n\tv354 = \"il2cpp_codegen_runtime_class_init\"(v331, v246, v96, methodInfo, v32, v33, v34, v35, v48, v37, v38, v39, v40, v41, v42, v43);\n\tv340 = HutongGames.PlayMaker.FsmLog;\nL_010F:\n\tv345 = ~v343.<MirrorDebugLog>k__BackingField;\n\tv346 = ~v345;\n\tif (v346) goto L_011F;\n\tv356 = sendToUnityLog == 0;\n\tif (v356) goto L_0129;\nL_011F:\n\tv54 = entry.<LogType>k__BackingField != 4;\n\tif (v54) goto L_012B;\nL_0129:\n\treturn;\nL_012B:\n\tv373 = HutongGames.PlayMaker.FsmLogEntry::get_Text(entry);\n\tv117 = HutongGames.PlayMaker.FsmLog::FormatUnityLogString(v44, v373);\n\tv153 = entry.<Log>k__BackingField;\n\tv388 = HutongGames.PlayMaker.Fsm::get_OwnerObject(v153.<Fsm>k__BackingField);\n\tgoto L_0151;\n\tv395 = *([v278 @ X8_v26+E0]);\n\tv396 = v395 == 0;\n\tv397 = ~v396;\n\tif (v397) goto L_0151;\n\tv400 = v278;\n\tv399 = \"il2cpp_codegen_runtime_class_init\"(v400, v387, v96, methodInfo, v32, v33, v34, v35, v48, v37, v38, v39, v40, v41, v42, v43);\nL_0151:\n\tUnityEngine.Debug::Log(v117, v388);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 216 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddEntry(FsmLogEntry entry, bool sendToUnityLog = false)
		{
			entry.Log = this;
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			entry.Time = realtimeSinceStartup;
			int frameCount = Time.frameCount;
			entry.FrameCount = frameCount;
			if (entry.Event != null)
			{
				string gameObjectName;
				if (entry.Event.IsCollisionEvent)
				{
					FsmLog log = entry.Log;
					GameObject collisionGO = log.Fsm.CollisionGO;
					FsmLog log2 = entry.Log;
					entry.GameObject = collisionGO;
					Fsm fsm = log2.Fsm;
					gameObjectName = fsm.CollisionName;
				}
				else if (entry.Event.IsTriggerEvent)
				{
					FsmLog log3 = entry.Log;
					GameObject triggerGO = log3.Fsm.TriggerGO;
					FsmLog log4 = entry.Log;
					entry.GameObject = triggerGO;
					Fsm fsm2 = log4.Fsm;
					gameObjectName = fsm2.TriggerName;
				}
				else if (entry.Event.IsCollision2DEvent)
				{
					FsmLog log5 = entry.Log;
					GameObject collision2dGO = log5.Fsm.Collision2dGO;
					FsmLog log6 = entry.Log;
					entry.GameObject = collision2dGO;
					Fsm fsm3 = log6.Fsm;
					gameObjectName = fsm3.Collision2dName;
				}
				else
				{
					if (!entry.Event.IsTrigger2DEvent)
					{
						goto IL_02ba;
					}
					FsmLog log7 = entry.Log;
					GameObject trigger2dGO = log7.Fsm.Trigger2dGO;
					FsmLog log8 = entry.Log;
					entry.GameObject = trigger2dGO;
					Fsm fsm4 = log8.Fsm;
					gameObjectName = fsm4.Trigger2dName;
				}
				entry.GameObjectName = gameObjectName;
			}
			goto IL_02ba;
			IL_02ba:
			Entries.Add(entry);
			if (entry.LogType != FsmLogType.Warning)
			{
				if (entry.LogType == FsmLogType.Error)
				{
					string text = entry.Text;
					string message = FormatUnityLogString(text);
					FsmLog log9 = entry.Log;
					UnityEngine.Object ownerObject = log9.Fsm.OwnerObject;
					Debug.LogError(message, ownerObject);
				}
				else if ((MirrorDebugLog || sendToUnityLog) && entry.LogType != FsmLogType.Transition)
				{
					string text2 = entry.Text;
					string message2 = FormatUnityLogString(text2);
					FsmLog log10 = entry.Log;
					UnityEngine.Object ownerObject2 = log10.Fsm.OwnerObject;
					Debug.Log(message2, ownerObject2);
				}
			}
			else
			{
				string text3 = entry.Text;
				string message3 = FormatUnityLogString(text3);
				FsmLog log11 = entry.Log;
				UnityEngine.Object ownerObject3 = log11.Fsm.OwnerObject;
				Debug.LogWarning(message3, ownerObject3);
			}
		}

		[Token(Token = "0x60004EC")]
		[Address(RVA = "0xCAE120", Offset = "0xCAE120", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1ED0668]);\n\tv25 = *([v24 @ X8_v22]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, logType, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20235FB]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v46, logType, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = HutongGames.PlayMaker.FsmLog;\nL_0024:\n\tv58 = v57.logEntryPool;\n\tv61 = v57.nextLogEntryPoolIndex;\n\tv63 = v57.nextLogEntryPoolIndex < v58.Length;\n\tv64 = ~v63;\n\tif (v64) goto L_0083;\n\tv108 = v58[v61 @ X9_v4 (System.Int32)];\n\tv130 = v108.<Log>k__BackingField == 0;\n\tif (v130) goto L_004A;\n\tHutongGames.PlayMaker.FsmLog::RemoveEntry(v108.<Log>k__BackingField, v58[v61 @ X9_v4 (System.Int32)]);\n\tv108.<Log>k__BackingField = 0;\n\tv108.<Time>k__BackingField = 0f;\n\tv108.<FrameCount>k__BackingField = 0;\n\tv108.<Action>k__BackingField = 0;\n\tv108.<Transition>k__BackingField = 0;\n\tv108.<State>k__BackingField = 0;\n\tv108.<GameObjectIcon>k__BackingField = 0;\n\tv108.<Text2>k__BackingField = 0;\n\tv108.<FsmVariablesCopy>k__BackingField = 0;\n\tv108.<GameObject>k__BackingField = 0;\nL_004A:\n\tv108.<Log>k__BackingField = this;\n\tv108.<LogType>k__BackingField = logType;\n\tgoto L_0058;\n\tv142 = *([v137 @ X0_v10 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tgoto L_0058;\n\tv196 = \"il2cpp_codegen_runtime_class_init\"(v137, v75, methodInfo, v28, v29, v30, v31, v32, v73, v34, v35, v36, v37, v38, v39, v40);\n\tv145 = HutongGames.PlayMaker.FsmLog;\nL_0058:\n\tv150 = v148.nextLogEntryPoolIndex + 1;\n\tv148.nextLogEntryPoolIndex = v150;\n\tv98 = v106.logEntryPool;\n\tv157 = v106.nextLogEntryPoolIndex < v98.Length;\n\tif (v157) goto L_0080;\n\tgoto L_0077;\n\tv208 = *([v100 @ X0_v11 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv209 = v208 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_0077;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v100, v75, methodInfo, v28, v29, v30, v31, v32, v73, v34, v35, v36, v37, v38, v39, v40);\n\tv213 = HutongGames.PlayMaker.FsmLog;\n\tv212 = *([v213 @ X8_v16+B8]);\nL_0077:\n\tv207.nextLogEntryPoolIndex = 0;\nL_0080:\n\treturn v58[v61 @ X9_v4 (System.Int32)];\n\tv110 = new System.NullReferenceException();\nL_0083:\n\tv128 = new System.IndexOutOfRangeException();\n\tthrow v128;\n\treturn returnVal1;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmLogEntry NewFsmLogEntry(FsmLogType logType)
		{
			FsmLogEntry[] array = logEntryPool;
			int num = nextLogEntryPoolIndex;
			if (nextLogEntryPoolIndex < array.Length)
			{
				FsmLogEntry fsmLogEntry = array[num];
				if (fsmLogEntry.Log != null)
				{
					fsmLogEntry.Log.RemoveEntry(array[num]);
					fsmLogEntry.Log = null;
					fsmLogEntry.Time = 0f;
					fsmLogEntry.FrameCount = 0;
					fsmLogEntry.Action = null;
					fsmLogEntry.Transition = null;
					fsmLogEntry.State = null;
					fsmLogEntry.GameObjectIcon = null;
					fsmLogEntry.Text2 = null;
					fsmLogEntry.FsmVariablesCopy = null;
					fsmLogEntry.GameObject = null;
				}
				fsmLogEntry.Log = this;
				fsmLogEntry.LogType = logType;
				int num2 = nextLogEntryPoolIndex + 1;
				nextLogEntryPoolIndex = num2;
				FsmLogEntry[] array2 = logEntryPool;
				if (nextLogEntryPoolIndex >= array2.Length)
				{
					nextLogEntryPoolIndex = 0;
				}
				return array[num];
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60004ED")]
		[Address(RVA = "0xCAE278", Offset = "0xCAE278", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EA7CC0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, entry, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20235FC]) = v41;\nL_0016:\n\tv43 = this.entries == 0;\n\tif (v43) goto L_002A;\n\tv53 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLogEntry>::Remove(this.entries, entry);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RemoveEntry(FsmLogEntry entry)
		{
			if (Entries != null)
			{
				bool flag = Entries.Remove(entry);
			}
		}

		[Token(Token = "0x60004EE")]
		[Address(RVA = "0xCAE310", Offset = "0xCAE310", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EE4C00]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsmEvent, state, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20235FD]) = v44;\nL_0019:\n\tv47 = HutongGames.PlayMaker.FsmLog::NewFsmLogEntry(this, 3);\n\tv47.<State>k__BackingField = state;\n\tgoto L_002C;\n\tv64 = *([v52 @ X0_v6 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_002C;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v52, v45, state, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv68 = HutongGames.PlayMaker.Fsm;\nL_002C:\n\tv72 = v71.EventData;\n\tv47.<SentByState>k__BackingField = v72.SentByState;\n\tv77 = v76.EventData;\n\tv47.<Action>k__BackingField = v77.SentByAction;\n\tv47.<Event>k__BackingField = fsmEvent;\n\tHutongGames.PlayMaker.FsmLog::AddEntry(this, v47, 0);\n\treturn;\n\tv57 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LogEvent(FsmEvent fsmEvent, FsmState state)
		{
			FsmLogEntry fsmLogEntry = NewFsmLogEntry(FsmLogType.Event);
			fsmLogEntry.State = state;
			FsmEventData eventData = Fsm.EventData;
			fsmLogEntry.SentByState = eventData.SentByState;
			FsmEventData eventData2 = Fsm.EventData;
			fsmLogEntry.Action = eventData2.SentByAction;
			fsmLogEntry.Event = fsmEvent;
			AddEntry(fsmLogEntry);
		}

		[Token(Token = "0x60004EF")]
		[Address(RVA = "0xCAE3DC", Offset = "0xCAE3DC", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1F0C470]);\n\tv31 = *([v30 @ X8_v12]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, state, fsmEvent, eventTarget, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20235FE]) = v47;\nL_0019:\n\tv48 = state == 0;\n\tif (v48) goto L_002C;\n\tv49 = fsmEvent == 0;\n\tif (v49) goto L_002C;\n\tv62 = fsmEvent.isSystemEvent + 3;\n\tv63 = ~v62;\n\tv53 = v63 & 3;\n\tv51 = v53 == 0;\n\tif (v51) goto L_002F;\nL_002C:\n\treturn;\nL_002F:\n\tv93 = HutongGames.PlayMaker.FsmLog::NewFsmLogEntry(this, 8);\n\tv93.<State>k__BackingField = state;\n\tv93.<Event>k__BackingField = fsmEvent;\n\tv96 = new HutongGames.PlayMaker.FsmEventTarget();\n\tHutongGames.PlayMaker.FsmEventTarget::.ctor(v96, eventTarget);\n\tv93.<EventTarget>k__BackingField = v96;\n\tHutongGames.PlayMaker.FsmLog::AddEntry(this, v93, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LogSendEvent(FsmState state, FsmEvent fsmEvent, FsmEventTarget eventTarget)
		{
			//IL_0035: Expected O, but got I4
			//IL_003e: Expected I4, but got O
			if (state != null && fsmEvent != null)
			{
				object obj = (fsmEvent.IsSystemEvent ? 1 : 0) + 3;
				int num = (int)(~obj);
				if ((num & 3) == 0)
				{
					FsmLogEntry fsmLogEntry = NewFsmLogEntry(FsmLogType.SendEvent);
					fsmLogEntry.State = state;
					fsmLogEntry.Event = fsmEvent;
					FsmEventTarget eventTarget2 = new FsmEventTarget(eventTarget);
					fsmLogEntry.EventTarget = eventTarget2;
					AddEntry(fsmLogEntry);
				}
			}
		}

		[Token(Token = "0x60004F0")]
		[Address(RVA = "0xCAE4B4", Offset = "0xCAE4B4", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1ECD5B0]);\n\tv27 = *([v26 @ X8_v27]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, state, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20235FF]) = v45;\nL_0017:\n\tv46 = state == 0;\n\tif (v46) goto L_0091;\n\tv49 = HutongGames.PlayMaker.FsmLog::NewFsmLogEntry(this, 5);\n\tv49.<State>k__BackingField = state;\n\tv94 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv73 = v94 - state.<RealStartTime>k__BackingField;\n\tv49.<StateTime>k__BackingField = v73;\n\tgoto L_0034;\n\tv110 = *([v106 @ X0_v6+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_0034;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v106, v47, methodInfo, v30, v31, v32, v33, v34, v73, v70, v37, v38, v39, v40, v41, v42);\nL_0034:\n\tgoto L_003F;\n\tv121 = *([1F0CC30]);\n\tv122 = *([v121 @ X8_v22]);\n\tv123 = \"il2cpp_codegen_initialize_method\"(v122, v47, methodInfo, v30, v31, v32, v33, v34, v73, v70, v37, v38, v39, v40, v41, v42);\n\tv126 = 0 | 1;\n\t*([2023704]) = v126;\nL_003F:\n\tgoto L_0048;\n\tv131 = *([v127 @ X0_v9 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tgoto L_0048;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v127, v47, methodInfo, v30, v31, v32, v33, v34, v73, v70, v37, v38, v39, v40, v41, v42);\n\tv135 = HutongGames.PlayMaker.FsmLog;\nL_0048:\n\tv139 = ~v138.<EnableDebugFlow>k__BackingField;\n\tif (v139) goto L_0087;\n\tv99 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv153 = ~v99.EnableDebugFlow;\n\tif (v153) goto L_0087;\n\tgoto L_0060;\n\tv164 = *([v160 @ X0_v15 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv165 = v164 == 0;\n\tv166 = ~v165;\n\tif (v166) goto L_0060;\n\tv172 = \"il2cpp_codegen_runtime_class_init\"(v160, v47, methodInfo, v30, v31, v32, v33, v34, v73, v70, v37, v38, v39, v40, v41, v42);\n\tv167 = PlayMakerFSM;\nL_0060:\n\tv171 = ~v170.ApplicationIsQuitting;\n\tv154 = ~v171;\n\tif (v154) goto L_0087;\n\tv100 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv177 = new HutongGames.PlayMaker.FsmVariables();\n\tHutongGames.PlayMaker.FsmVariables::.ctor(v177, v100.variables);\n\tv49.<FsmVariablesCopy>k__BackingField = v177;\n\tv182 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv151 = new HutongGames.PlayMaker.FsmVariables();\n\tHutongGames.PlayMaker.FsmVariables::.ctor(v151, v182);\n\tv49.<GlobalVariablesCopy>k__BackingField = v151;\nL_0087:\n\tHutongGames.PlayMaker.FsmLog::AddEntry(this, v49, 0);\n\treturn;\nL_0091:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LogExitState(FsmState state)
		{
			if (state == null)
			{
				return;
			}
			FsmLogEntry fsmLogEntry = NewFsmLogEntry(FsmLogType.ExitState);
			fsmLogEntry.State = state;
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			float stateTime = realtimeSinceStartup - state.RealStartTime;
			fsmLogEntry.StateTime = stateTime;
			if (EnableDebugFlow)
			{
				Fsm fsm = state.Fsm;
				if (fsm.EnableDebugFlow && !PlayMakerFSM.ApplicationIsQuitting)
				{
					Fsm fsm2 = state.Fsm;
					FsmVariables fsmVariablesCopy = new FsmVariables(fsm2.Variables);
					fsmLogEntry.FsmVariablesCopy = fsmVariablesCopy;
					FsmVariables globalVariables = FsmVariables.GlobalVariables;
					FsmVariables globalVariablesCopy = new FsmVariables(globalVariables);
					fsmLogEntry.GlobalVariablesCopy = globalVariablesCopy;
				}
			}
			AddEntry(fsmLogEntry);
		}

		[Token(Token = "0x60004F1")]
		[Address(RVA = "0xCAE700", Offset = "0xCAE700", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F096D0]);\n\tv27 = *([v26 @ X8_v22]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, state, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2023600]) = v45;\nL_0017:\n\tv46 = state == 0;\n\tif (v46) goto L_007B;\n\tv49 = HutongGames.PlayMaker.FsmLog::NewFsmLogEntry(this, 6);\n\tv49.<State>k__BackingField = state;\n\tgoto L_0030;\n\tv102 = *([v90 @ X0_v6+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_0030;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v90, v47, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0030:\n\tgoto L_003B;\n\tv113 = *([1F0CC30]);\n\tv114 = *([v113 @ X8_v17]);\n\tv115 = \"il2cpp_codegen_initialize_method\"(v114, v47, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv118 = 0 | 1;\n\t*([2023704]) = v118;\nL_003B:\n\tgoto L_0044;\n\tv123 = *([v119 @ X0_v9 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tgoto L_0044;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v119, v47, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv127 = HutongGames.PlayMaker.FsmLog;\nL_0044:\n\tv131 = ~v130.<EnableDebugFlow>k__BackingField;\n\tif (v131) goto L_0071;\n\tv96 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv144 = ~v96.EnableDebugFlow;\n\tif (v144) goto L_0071;\n\tv97 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv152 = new HutongGames.PlayMaker.FsmVariables();\n\tHutongGames.PlayMaker.FsmVariables::.ctor(v152, v97.variables);\n\tv49.<FsmVariablesCopy>k__BackingField = v152;\n\tv157 = HutongGames.PlayMaker.FsmVariables::get_GlobalVariables();\n\tv143 = new HutongGames.PlayMaker.FsmVariables();\n\tHutongGames.PlayMaker.FsmVariables::.ctor(v143, v157);\n\tv49.<GlobalVariablesCopy>k__BackingField = v143;\nL_0071:\n\tHutongGames.PlayMaker.FsmLog::AddEntry(this, v49, 0);\n\treturn;\nL_007B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LogEnterState(FsmState state)
		{
			if (state == null)
			{
				return;
			}
			FsmLogEntry fsmLogEntry = NewFsmLogEntry(FsmLogType.EnterState);
			fsmLogEntry.State = state;
			if (EnableDebugFlow)
			{
				Fsm fsm = state.Fsm;
				if (fsm.EnableDebugFlow)
				{
					Fsm fsm2 = state.Fsm;
					FsmVariables fsmVariablesCopy = new FsmVariables(fsm2.Variables);
					fsmLogEntry.FsmVariablesCopy = fsmVariablesCopy;
					FsmVariables globalVariables = FsmVariables.GlobalVariables;
					FsmVariables globalVariablesCopy = new FsmVariables(globalVariables);
					fsmLogEntry.GlobalVariablesCopy = globalVariablesCopy;
				}
			}
			AddEntry(fsmLogEntry);
		}

		[Token(Token = "0x60004F2")]
		[Address(RVA = "0xCAE874", Offset = "0xCAE874", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = HutongGames.PlayMaker.FsmLog::NewFsmLogEntry(this, 4);\n\tv19.<State>k__BackingField = fromState;\n\tv19.<Transition>k__BackingField = transition;\n\tHutongGames.PlayMaker.FsmLog::AddEntry(this, v19, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LogTransition(FsmState fromState, FsmTransition transition)
		{
			FsmLogEntry fsmLogEntry = NewFsmLogEntry(FsmLogType.Transition);
			fsmLogEntry.State = fromState;
			fsmLogEntry.Transition = transition;
			AddEntry(fsmLogEntry);
		}

		[Token(Token = "0x60004F3")]
		[Address(RVA = "0xCAE8C8", Offset = "0xCAE8C8", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1ED8F40]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023601]) = v40;\nL_0016:\n\tv55 = HutongGames.PlayMaker.FsmLog::NewFsmLogEntry(this, 7);\n\tgoto L_0025;\n\tv51 = *([v47 @ X8_v5+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0025;\n\tv59 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v59, v41, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv58 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingState();\n\tv55.<State>k__BackingField = v58;\n\tv65 = HutongGames.PlayMaker.FsmLog::FormatUnityLogString(this, \"Breakpoint\");\n\tv74 = System.String::Concat(\"BREAK: \", v65);\n\tgoto L_0045;\n\tv103 = *([v78 @ X8_v13+E0]);\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tif (v105) goto L_0045;\n\tv110 = v78;\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v110, v70, v71, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tUnityEngine.Debug::Log(v74);\n\tHutongGames.PlayMaker.FsmLog::AddEntry(this, v55, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LogBreak()
		{
			FsmLogEntry fsmLogEntry = NewFsmLogEntry(FsmLogType.Break);
			FsmState executingState = FsmExecutionStack.ExecutingState;
			fsmLogEntry.State = executingState;
			string text = FormatUnityLogString("Breakpoint");
			string message = "BREAK: " + text;
			Debug.Log(message);
			AddEntry(fsmLogEntry);
		}

		[Token(Token = "0x60004F4")]
		[Address(RVA = "0xCAE9C8", Offset = "0xCAE9C8", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EB5E38]);\n\tv31 = *([v30 @ X8_v23]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, logType, text, sendToUnityLog, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023602]) = v47;\nL_001F:\n\tgoto L_0025;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0025;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, logType, text, sendToUnityLog, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0025:\n\tv61 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingAction();\n\tv62 = v61 == 0;\n\tif (v62) goto L_005F;\n\tv99 = HutongGames.PlayMaker.FsmLog::NewFsmLogEntry(this, logType);\n\tgoto L_0037;\n\tv95 = *([v77 @ X8_v16+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_0037;\n\tv127 = v77;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v127, v64, text, sendToUnityLog, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0037:\n\tv102 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingState();\n\tv99.<State>k__BackingField = v102;\n\tv161 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingAction();\n\tv99.<Action>k__BackingField = v161;\n\tv210 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingAction();\n\tv214 = System.Object::ToString(v210);\n\tv215 = HutongGames.PlayMaker.FsmUtility::StripNamespace(v214);\n\tv219 = System.String::Concat(v215, \" : \", text);\n\tv99.text = v219;\n\tHutongGames.PlayMaker.FsmLog::AddEntry(this, v99, sendToUnityLog);\n\treturn;\nL_005F:\n\tv72 = logType == 2;\n\tif (v72) goto L_0089;\n\tv86 = logType == 1;\n\tif (v86) goto L_009F;\n\tgoto L_0083;\n\tv129 = *([v103 @ X0_v13+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_0083;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v103, logType, text, sendToUnityLog, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0083:\n\tUnityEngine.Debug::Log(text);\n\treturn;\nL_0089:\n\tgoto L_0099;\n\tv111 = *([v91 @ X0_v5+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_0099;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v91, logType, text, sendToUnityLog, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0099:\n\tUnityEngine.Debug::LogError(text);\n\treturn;\nL_009F:\n\tgoto L_00AF;\n\tv145 = *([v107 @ X0_v9+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_00AF;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v107, logType, text, sendToUnityLog, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_00AF:\n\tUnityEngine.Debug::LogWarning(text);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LogAction(FsmLogType logType, string text, bool sendToUnityLog = false)
		{
			FsmStateAction executingAction = FsmExecutionStack.ExecutingAction;
			if (executingAction != null)
			{
				FsmLogEntry fsmLogEntry = NewFsmLogEntry(logType);
				FsmState executingState = FsmExecutionStack.ExecutingState;
				fsmLogEntry.State = executingState;
				FsmStateAction executingAction2 = FsmExecutionStack.ExecutingAction;
				fsmLogEntry.Action = executingAction2;
				FsmStateAction executingAction3 = FsmExecutionStack.ExecutingAction;
				string name = executingAction3.ToString();
				string text2 = FsmUtility.StripNamespace(name);
				string text3 = text2 + " : " + text;
				fsmLogEntry.Text = text3;
				AddEntry(fsmLogEntry, sendToUnityLog);
			}
			else
			{
				switch (logType)
				{
				default:
					Debug.Log(text);
					break;
				case FsmLogType.Error:
					Debug.LogError(text);
					break;
				case FsmLogType.Warning:
					Debug.LogWarning(text);
					break;
				}
			}
		}

		[Token(Token = "0x60004F5")]
		[Address(RVA = "0xCAEC0C", Offset = "0xCAEC0C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1ED4B00]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, logType, text, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023603]) = v44;\nL_0019:\n\tv59 = HutongGames.PlayMaker.FsmLog::NewFsmLogEntry(this, logType);\n\tgoto L_0028;\n\tv55 = *([v51 @ X8_v5+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0028;\n\tv63 = v51;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v63, v46, text, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0028:\n\tv62 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingState();\n\tv59.<State>k__BackingField = v62;\n\tv59.text = text;\n\tHutongGames.PlayMaker.FsmLog::AddEntry(this, v59, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Log(FsmLogType logType, string text)
		{
			FsmLogEntry fsmLogEntry = NewFsmLogEntry(logType);
			FsmState executingState = FsmExecutionStack.ExecutingState;
			fsmLogEntry.State = executingState;
			fsmLogEntry.Text = text;
			AddEntry(fsmLogEntry);
		}

		[Token(Token = "0x60004F6")]
		[Address(RVA = "0xCAECB4", Offset = "0xCAECB4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.FsmLog::NewFsmLogEntry(this, 9);\n\tv15.<State>k__BackingField = startState;\n\tHutongGames.PlayMaker.FsmLog::AddEntry(this, v15, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LogStart(FsmState startState)
		{
			FsmLogEntry fsmLogEntry = NewFsmLogEntry(FsmLogType.Start);
			fsmLogEntry.State = startState;
			AddEntry(fsmLogEntry);
		}

		[Token(Token = "0x60004F7")]
		[Address(RVA = "0xCAECF8", Offset = "0xCAECF8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = HutongGames.PlayMaker.FsmLog::NewFsmLogEntry(this, 0xA);\n\tHutongGames.PlayMaker.FsmLog::AddEntry(this, v11, 0);\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LogStop()
		{
			FsmLogEntry entry = NewFsmLogEntry(FsmLogType.Stop);
			AddEntry(entry);
		}

		[Token(Token = "0x60004F8")]
		[Address(RVA = "0xCAED28", Offset = "0xCAED28", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmLog::Log(this, 0, text);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Log(string text)
		{
			Log(default(FsmLogType), text);
		}

		[Token(Token = "0x60004F9")]
		[Address(RVA = "0xCAED38", Offset = "0xCAED38", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmLog::Log(this, 1, text);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LogWarning(string text)
		{
			Log(FsmLogType.Warning, text);
		}

		[Token(Token = "0x60004FA")]
		[Address(RVA = "0xCAED48", Offset = "0xCAED48", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmLog::Log(this, 2, text);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LogError(string text)
		{
			Log(FsmLogType.Error, text);
		}

		[Token(Token = "0x60004FB")]
		[Address(RVA = "0xCADFC8", Offset = "0xCADFC8", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1F09DD8]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, text, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023604]) = v41;\nL_001C:\n\tgoto L_0024;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0024;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, text, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0024:\n\tv70 = HutongGames.PlayMaker.Fsm::GetFullFsmLabel(this.<Fsm>k__BackingField);\n\tgoto L_0033;\n\tv66 = *([v62 @ X8_v7+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_0033;\n\tv74 = v62;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v74, v57, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0033:\n\tv73 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingState();\n\tv75 = v73 == 0;\n\tif (v75) goto L_004D;\n\tgoto L_0040;\n\tv98 = *([v76 @ X0_v24 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0040;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v76, v57, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0040:\n\tv104 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingStateName();\n\tv87 = System.String::Concat(v70, \" : \", v104);\nL_004D:\n\tgoto L_0053;\n\tv105 = *([v94 @ X0_v9 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tgoto L_0053;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v94, v84, v82, v80, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0053:\n\tv112 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingAction();\n\tv115 = v112 == 0;\n\tif (v115) goto L_0074;\n\tgoto L_0060;\n\tv144 = *([v116 @ X0_v15 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv145 = v144 == 0;\n\tv146 = ~v145;\n\tif (v146) goto L_0060;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v116, v84, v82, v80, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0060:\n\tv150 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingAction();\n\tv125 = System.String::Concat(v128, v150.name);\nL_0074:\n\treturnVal1 = System.String::Concat(v128, \" : \", text);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string FormatUnityLogString(string text)
		{
			string fullFsmLabel = Fsm.GetFullFsmLabel(Fsm);
			FsmState executingState = FsmExecutionStack.ExecutingState;
			bool flag = executingState == null;
			string text2 = fullFsmLabel;
			if (!flag)
			{
				string executingStateName = FsmExecutionStack.ExecutingStateName;
				string text3 = fullFsmLabel + " : " + executingStateName;
				text2 = text3;
			}
			FsmStateAction executingAction = FsmExecutionStack.ExecutingAction;
			if (executingAction != null)
			{
				FsmStateAction executingAction2 = FsmExecutionStack.ExecutingAction;
				string text4 = text2 + executingAction2.Name;
				text2 = text4;
			}
			return text2 + " : " + text;
		}

		[Token(Token = "0x60004FC")]
		[Address(RVA = "0xCAD994", Offset = "0xCAD994", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EDEFD8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023605]) = v38;\nL_0014:\n\tv40 = this.entries == 0;\n\tif (v40) goto L_0025;\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLogEntry>::Clear(this.entries);\n\treturn;\nL_0025:\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear()
		{
			if (Entries != null)
			{
				Entries.Clear();
			}
		}

		[Token(Token = "0x60004FD")]
		[Address(RVA = "0xCAED58", Offset = "0xCAED58", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE8348]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023606]) = v38;\nL_0019:\n\tgoto L_0028;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmLog>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b14\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmLog;\nL_0028:\n\tv60 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmLog>::Remove(v52.Logs, this);\n\tHutongGames.PlayMaker.FsmLog::Clear(this);\n\tthis.<Fsm>k__BackingField = 0;\n\tthis.entries = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDestroy()
		{
			bool flag = Logs.Remove(this);
			Clear();
			Fsm = null;
			entries = null;
		}
	}
}
