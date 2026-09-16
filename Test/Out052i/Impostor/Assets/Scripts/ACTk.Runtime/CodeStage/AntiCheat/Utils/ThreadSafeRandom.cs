using System;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace CodeStage.AntiCheat.Utils
{
	[Token(Token = "0x2000007")]
	internal class ThreadSafeRandom
	{
		[Token(Token = "0x4000007")]
		private static readonly Random Global;

		[ThreadStatic]
		[Token(Token = "0x4000008")]
		private static Random local;

		[Token(Token = "0x600001A")]
		[Address(RVA = "0xBD42D8", Offset = "0xBD42D8", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = System.Random;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, maxExclusive, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv53 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, maxExclusive, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A353E0]) = v47;\nL_001F:\n\tgoto L_0022;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v48, maxExclusive, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv56 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\nL_0022:\n\tv57 = 0xAD94B4(CodeStage.AntiCheat.Utils.ThreadSafeRandom, maxExclusive, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv108 = *([v57 @ X0_v4]);\n\tv59 = *([v57 @ X0_v4]) == 0;\n\tif (v59) goto L_002C;\n\tgoto L_0079;\nL_002C:\n\tgoto L_0030;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v61, maxExclusive, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv123 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\nL_0030:\n\tv212 = v124.Global;\n\tSystem.Threading.Monitor::Enter(v124.Global, &v66 @ stack_-44_v4 (System.Boolean));\n\tgoto L_003E;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v165, v127, v129, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv215 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\nL_003E:\n\tv217 = v216.Global;\n\tv219 = *([v217 @ X0_v14 (System.Random)]);\n\tv199 = *([v219 @ X8_v19 (Il2CppClass<System.Random>)+190]);\n\tv261 = System.Random::Next(v217);\nL_0049:\n\tv267 = ~v66;\n\tif (v267) goto L_004E;\n\tSystem.Threading.Monitor::Exit(v212);\nL_004E:\n\tv285 = v100 == 0;\n\tv252 = ~v285;\n\tif (v252) goto L_0085;\n\tv86 = v98 == 3;\n\tif (v86) goto L_0061;\n\tv289 = v98 == 0;\n\tv152 = ~v289;\n\tif (v152) goto L_0083;\nL_0061:\n\tv108 = new System.Random();\n\tSystem.Random::.ctor(v108, v102);\n\tgoto L_006D;\n\tv305 = \"il2cpp_codegen_runtime_class_init\"(v298, v104, v72, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv307 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\nL_006D:\n\tv308 = 0xAD94B4(CodeStage.AntiCheat.Utils.ThreadSafeRandom, v102, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\t*([v308 @ X0_v23]) = v108;\n\tv280 = 0xAD94B4(CodeStage.AntiCheat.Utils.ThreadSafeRandom, v102, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv111 = v108 == 0;\n\tif (v111) goto L_0087;\nL_0079:\n\treturnVal1 = System.Random::Next(v108, minInclusive, maxExclusive);\nL_0083:\n\treturn returnVal1;\nL_0085:\n\tv250 = new System.OutOfMemoryException();\n\tv255 = new System.NullReferenceException();\nL_0087:\n\tv282 = new System.NullReferenceException();\n\tgoto L_0094;\n\tgoto L_0094;\nL_0094:\n\tv173 = v199 != 1;\n\tif (v173) goto L_009E;\n\tv296 = 0x1854E70(v282, v199, v175, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv100 = *([v296 @ X0_v41]);\n\tv261 = 0x1854E80(v296, v199, v175, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0049;\nL_009E:\n\tgoto L_00A1;\n\tX23 = X0;\nL_00A1:\n\tv297 = ~v66;\n\tif (v297) goto L_00A8;\n\tSystem.Threading.Monitor::Exit(v212);\nL_00A8:\n\tgoto L_00AC;\n\tv310 = 0xBD3CD0(v282, v199, v175, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00AC:\n\tv313 = new System.OutOfMemoryException();\n\treturnVal2 = 0x9DACB4(v313, v199, v175, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal2;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Next(int minInclusive, int maxExclusive)
		{
			//IL_0017: Expected I, but got O
			//IL_003d: Expected O, but got I4
			//IL_028a: Expected O, but got I4
			//IL_00e2: Expected I4, but got O
			//IL_0259: Expected O, but got I4
			//IL_0164: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B4");
			object obj = default(object);
			Random random = (Random)obj;
			if (obj != null)
			{
				goto IL_01dc;
			}
			Random random2 = Global;
			bool lockTaken = default(bool);
			Monitor.Enter(Global, ref lockTaken);
			Random global = Global;
			nint num = (nint)global;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ X8_v19 (Il2CppClass<System.Random>)+190]");
			int num2 = 0;
			int num3 = global.Next();
			object obj2 = 0;
			int num4 = 3;
			int num5 = 0;
			int num6 = num3;
			int result;
			object obj4 = default(object);
			int result2 = default(int);
			while (true)
			{
				bool flag = !lockTaken;
				Random random3 = (Random)num3;
				if (!flag)
				{
					Monitor.Exit(random2);
					num2 = 0;
					random3 = random2;
				}
				if (num5 == 0)
				{
					if (num4 != 3)
					{
						bool flag2 = num4 == 0;
						bool flag3 = !flag2;
						result = (int)random3;
						if (flag3)
						{
							break;
						}
					}
					random = new Random(num6);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B4");
					object obj3 = random;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B4");
					bool flag4 = random == null;
					obj2 = 0;
					num2 = num6;
					random2 = random;
					if (!flag4)
					{
						goto IL_01dc;
					}
				}
				else
				{
					OutOfMemoryException ex = new OutOfMemoryException();
					NullReferenceException ex2 = new NullReferenceException();
				}
				NullReferenceException ex3 = new NullReferenceException();
				if (num2 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
					num5 = (int)obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
					num4 = 0;
					num6 = 0;
					continue;
				}
				if (lockTaken)
				{
					Monitor.Exit(random2);
					num2 = 0;
				}
				OutOfMemoryException ex4 = new OutOfMemoryException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
				return result2;
			}
			goto IL_0220;
			IL_0220:
			return result;
			IL_01dc:
			result = random.Next(minInclusive, maxExclusive);
			goto IL_0220;
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0xBD4ABC", Offset = "0xBD4ABC", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = System.Random;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, maxExclusive, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv53 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, maxExclusive, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A353E1]) = v47;\nL_001F:\n\tgoto L_0022;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v48, maxExclusive, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv56 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\nL_0022:\n\tv57 = 0xAD94B4(CodeStage.AntiCheat.Utils.ThreadSafeRandom, maxExclusive, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv59 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv115 = *([v57 @ X0_v4]);\n\tv62 = *([v59 @ X0_v5 (Il2CppClass<CodeStage.AntiCheat.Utils.ThreadSafeRandom>)+E0]) == 0;\n\tif (v62) goto L_002E;\n\tv63 = *([v57 @ X0_v4]) == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0077;\n\tgoto L_0038;\nL_002E:\n\tv121 = *([v57 @ X0_v4]) == 0;\n\tv112 = ~v121;\n\tif (v112) goto L_0077;\nL_0038:\n\tSystem.Threading.Monitor::Enter(v125.Global, &v104 @ stack_-44_v4 (System.Boolean));\n\tgoto L_0041;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v163, v128, v130, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv210 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\nL_0041:\n\tv212 = v211.Global;\n\tv213 = v211.Global == 0;\n\tif (v213) goto L_0084;\n\tv214 = *([v212 @ X0_v14 (System.Random)]);\n\tv194 = *([v214 @ X8_v18 (Il2CppClass<System.Random>)+190]);\n\tv251 = System.Random::Next(v211.Global);\nL_004C:\n\tv255 = ~v104;\n\tif (v255) goto L_0051;\n\tSystem.Threading.Monitor::Exit(v125.Global);\nL_0051:\n\tv258 = v96 == 0;\n\tv244 = ~v258;\n\tif (v244) goto L_0083;\n\tv82 = v94 == 3;\n\tif (v82) goto L_0064;\n\tv264 = v94 == 0;\n\tv151 = ~v264;\n\tif (v151) goto L_0081;\nL_0064:\n\tv269 = new System.Random();\n\tSystem.Random::.ctor(v269, v98);\n\tgoto L_0070;\n\tv282 = \"il2cpp_codegen_runtime_class_init\"(v275, v102, v100, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv284 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\nL_0070:\n\tv285 = 0xAD94B4(CodeStage.AntiCheat.Utils.ThreadSafeRandom, v98, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\t*([v285 @ X0_v23]) = v269;\n\tv109 = 0xAD94B4(CodeStage.AntiCheat.Utils.ThreadSafeRandom, v98, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0077:\n\treturnVal1 = CodeStage.AntiCheat.Utils.ThreadSafeRandom::NextLong(v115, minInclusive, maxExclusive);\nL_0081:\n\treturn returnVal1;\nL_0083:\n\tv242 = new System.OutOfMemoryException();\nL_0084:\n\tv246 = new System.NullReferenceException();\n\tgoto L_0091;\n\tgoto L_0091;\nL_0091:\n\tv168 = v194 != 1;\n\tif (v168) goto L_009B;\n\tv263 = 0x1854E70(v246, v194, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv96 = *([v263 @ X0_v40]);\n\tv251 = 0x1854E80(v263, v194, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_004C;\nL_009B:\n\tgoto L_009E;\n\tX23 = X0;\nL_009E:\n\tv270 = ~v104;\n\tif (v270) goto L_00A5;\n\tSystem.Threading.Monitor::Exit(v125.Global);\nL_00A5:\n\tgoto L_00A9;\n\tv278 = 0xBD3CD0(v246, v194, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00A9:\n\tv281 = new System.OutOfMemoryException();\n\treturnVal2 = 0x9DACB4(v281, v194, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal2;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long NextLong(long minInclusive, long maxExclusive)
		{
			//IL_02f0: Expected I, but got O
			//IL_0267: Expected O, but got I4
			//IL_0075: Expected I, but got O
			//IL_0085: Expected O, but got I
			//IL_02b1: Expected O, but got I4
			//IL_01cd: Expected I4, but got O
			//IL_00c5: Expected O, but got I4
			//IL_020b: Expected O, but got I4
			//IL_013a: Expected I8, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B4");
			nint num = (nint)typeof(ThreadSafeRandom);
			object obj = default(object);
			Random random = (Random)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v5 (Il2CppClass<CodeStage.AntiCheat.Utils.ThreadSafeRandom>)+E0]");
			if ((nint)0 != 0)
			{
				if (obj == null)
				{
					goto IL_005a;
				}
			}
			else if (obj == null)
			{
				goto IL_005a;
			}
			goto IL_0160;
			IL_018d:
			NullReferenceException ex = new NullReferenceException();
			int num2;
			int num3;
			int seed;
			object obj2;
			if ((nint)obj2 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				object obj3 = default(object);
				num2 = (int)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				num3 = 0;
				seed = 0;
				goto IL_029e;
			}
			bool lockTaken = default(bool);
			if (lockTaken)
			{
				Monitor.Exit(Global);
				obj2 = 0;
			}
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
			long result = default(long);
			return result;
			IL_017a:
			long result2;
			return result2;
			IL_005a:
			Monitor.Enter(Global, ref lockTaken);
			Random global = Global;
			bool flag = Global == null;
			obj2 = lockTaken;
			if (flag)
			{
				goto IL_018d;
			}
			nint num4 = (nint)global;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ X8_v18 (Il2CppClass<System.Random>)+190]");
			obj2 = 0;
			int num5 = Global.Next();
			num3 = 3;
			num2 = 0;
			seed = num5;
			goto IL_029e;
			IL_0160:
			result2 = NextLong(random, minInclusive, maxExclusive);
			goto IL_017a;
			IL_029e:
			bool flag2 = !lockTaken;
			Random random2 = (Random)num5;
			if (!flag2)
			{
				Monitor.Exit(Global);
				obj2 = 0;
				random2 = Global;
			}
			if (num2 == 0)
			{
				if (num3 != 3)
				{
					bool flag3 = num3 == 0;
					bool flag4 = !flag3;
					result2 = (long)random2;
					if (flag4)
					{
						goto IL_017a;
					}
				}
				Random random3 = new Random(seed);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B4");
				object obj4 = random3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B4");
				random = random3;
				goto IL_0160;
			}
			OutOfMemoryException ex3 = new OutOfMemoryException();
			goto IL_018d;
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0xBD4D0C", Offset = "0xBD4D0C", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = System.Random;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv50 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A353E2]) = v44;\nL_001D:\n\tgoto L_0020;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv53 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\nL_0020:\n\tv54 = 0xAD94B4(CodeStage.AntiCheat.Utils.ThreadSafeRandom, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv105 = *([v54 @ X0_v4]);\n\tv56 = *([v54 @ X0_v4]) == 0;\n\tif (v56) goto L_002A;\n\tgoto L_0076;\nL_002A:\n\tgoto L_002E;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv119 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\nL_002E:\n\tv204 = v120.Global;\n\tSystem.Threading.Monitor::Enter(v120.Global, &v63 @ stack_-34_v4 (System.Boolean));\n\tgoto L_003C;\n\tv205 = \"il2cpp_codegen_runtime_class_init\"(v159, v123, v125, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv207 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\nL_003C:\n\tv209 = v208.Global;\n\tv211 = *([v209 @ X0_v14 (System.Random)]);\n\tv192 = *([v211 @ X8_v19 (Il2CppClass<System.Random>)+190]);\n\tv214 = System.Random::Next(v209);\nL_0047:\n\tv259 = ~v63;\n\tif (v259) goto L_004C;\n\tSystem.Threading.Monitor::Exit(v204);\nL_004C:\n\tv277 = v97 == 0;\n\tv244 = ~v277;\n\tif (v244) goto L_0081;\n\tv83 = v95 == 3;\n\tif (v83) goto L_005F;\n\tv281 = v95 == 0;\n\tv147 = ~v281;\n\tif (v147) goto L_007F;\nL_005F:\n\tv105 = new System.Random();\n\tSystem.Random::.ctor(v105, v99);\n\tgoto L_006B;\n\tv297 = \"il2cpp_codegen_runtime_class_init\"(v290, v101, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv299 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\nL_006B:\n\tv300 = 0xAD94B4(CodeStage.AntiCheat.Utils.ThreadSafeRandom, v99, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\t*([v300 @ X0_v23]) = v105;\n\tv272 = 0xAD94B4(CodeStage.AntiCheat.Utils.ThreadSafeRandom, v99, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv108 = v105 == 0;\n\tif (v108) goto L_0083;\nL_0076:\n\tv116 = System.Random::NextBytes(v105, buffer);\nL_007F:\n\treturn;\nL_0081:\n\tv242 = new System.OutOfMemoryException();\n\tv247 = new System.NullReferenceException();\nL_0083:\n\tv274 = new System.NullReferenceException();\n\tgoto L_0090;\n\tgoto L_0090;\nL_0090:\n\tv166 = v192 != 1;\n\tif (v166) goto L_009A;\n\tv288 = 0x1854E70(v274, v192, v168, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv97 = *([v288 @ X0_v41]);\n\tv254 = 0x1854E80(v288, v192, v168, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0047;\nL_009A:\n\tgoto L_009D;\n\tX22 = X0;\nL_009D:\n\tv289 = ~v63;\n\tif (v289) goto L_00A4;\n\tSystem.Threading.Monitor::Exit(v204);\nL_00A4:\n\tgoto L_00A8;\n\tv302 = 0xBD3CD0(v274, v192, v168, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00A8:\n\tv305 = new System.OutOfMemoryException();\n\tv196 = 0x9DACB4(v305, v192, v168, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NextBytes(byte[] buffer)
		{
			//IL_0017: Expected I, but got O
			//IL_003d: Expected O, but got I4
			//IL_0239: Expected O, but got I4
			//IL_0154: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B4");
			object obj = default(object);
			Random random = (Random)obj;
			if (obj == null)
			{
				Random obj2 = Global;
				bool lockTaken = default(bool);
				Monitor.Enter(Global, ref lockTaken);
				Random global = Global;
				nint num = (nint)global;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ X8_v19 (Il2CppClass<System.Random>)+190]");
				int num2 = 0;
				int num3 = global.Next();
				object obj3 = 0;
				int num4 = 3;
				int num5 = 0;
				int num6 = num3;
				object obj5 = default(object);
				while (true)
				{
					if (lockTaken)
					{
						Monitor.Exit(obj2);
						num2 = 0;
					}
					if (num5 == 0)
					{
						if (num4 != 3 && num4 != 0)
						{
							return;
						}
						random = new Random(num6);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B4");
						object obj4 = random;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B4");
						bool flag = random == null;
						obj3 = 0;
						num2 = num6;
						obj2 = random;
						if (!flag)
						{
							break;
						}
					}
					else
					{
						OutOfMemoryException ex = new OutOfMemoryException();
						NullReferenceException ex2 = new NullReferenceException();
					}
					NullReferenceException ex3 = new NullReferenceException();
					if (num2 == 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
						num5 = (int)obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
						num4 = 0;
						num6 = 0;
						continue;
					}
					if (lockTaken)
					{
						Monitor.Exit(obj2);
						num2 = 0;
					}
					OutOfMemoryException ex4 = new OutOfMemoryException();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
					return;
				}
			}
			random.NextBytes(buffer);
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0xBD46B0", Offset = "0xBD46B0", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = System.Random;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv50 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A353E3]) = v44;\nL_001D:\n\tgoto L_0020;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv53 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\nL_0020:\n\tv54 = 0xAD94B4(CodeStage.AntiCheat.Utils.ThreadSafeRandom, methodInfo, v96, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv56 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv112 = *([v54 @ X0_v4]);\n\tv59 = *([v56 @ X0_v5 (Il2CppClass<CodeStage.AntiCheat.Utils.ThreadSafeRandom>)+E0]) == 0;\n\tif (v59) goto L_002C;\n\tv60 = *([v54 @ X0_v4]) == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0074;\n\tgoto L_0036;\nL_002C:\n\tv116 = *([v54 @ X0_v4]) == 0;\n\tv109 = ~v116;\n\tif (v109) goto L_0074;\nL_0036:\n\tSystem.Threading.Monitor::Enter(v120.Global, &v101 @ stack_-34_v4 (System.Boolean));\n\tgoto L_003F;\n\tv201 = \"il2cpp_codegen_runtime_class_init\"(v157, v123, v125, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv203 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\nL_003F:\n\tv205 = v204.Global;\n\tv206 = v204.Global == 0;\n\tif (v206) goto L_0080;\n\tv207 = *([v205 @ X0_v13 (System.Random)]);\n\tv188 = *([v207 @ X8_v18 (Il2CppClass<System.Random>)+190]);\n\tv210 = System.Random::Next(v204.Global);\nL_004A:\n\tv248 = ~v101;\n\tif (v248) goto L_004F;\n\tSystem.Threading.Monitor::Exit(v120.Global);\nL_004F:\n\tv251 = v93 == 0;\n\tv237 = ~v251;\n\tif (v237) goto L_007F;\n\tv79 = v91 == 3;\n\tif (v79) goto L_0062;\n\tv257 = v91 == 0;\n\tv146 = ~v257;\n\tif (v146) goto L_007D;\nL_0062:\n\tv262 = new System.Random();\n\tSystem.Random::.ctor(v262, v95);\n\tgoto L_006E;\n\tv275 = \"il2cpp_codegen_runtime_class_init\"(v268, v99, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv277 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\nL_006E:\n\tv278 = 0xAD94B4(CodeStage.AntiCheat.Utils.ThreadSafeRandom, v95, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\t*([v278 @ X0_v22]) = v262;\n\tv106 = 0xAD94B4(CodeStage.AntiCheat.Utils.ThreadSafeRandom, v95, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0074:\n\tCodeStage.AntiCheat.Utils.ThreadSafeRandom::NextChars(v112, buffer);\nL_007D:\n\treturn;\nL_007F:\n\tv235 = new System.OutOfMemoryException();\nL_0080:\n\tv239 = new System.NullReferenceException();\n\tgoto L_008D;\n\tgoto L_008D;\nL_008D:\n\tv162 = v188 != 1;\n\tif (v162) goto L_0097;\n\tv256 = 0x1854E70(v239, v188, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv93 = *([v256 @ X0_v39]);\n\tv245 = 0x1854E80(v256, v188, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_004A;\nL_0097:\n\tgoto L_009A;\n\tX22 = X0;\nL_009A:\n\tv263 = ~v101;\n\tif (v263) goto L_00A1;\n\tSystem.Threading.Monitor::Exit(v120.Global);\nL_00A1:\n\tgoto L_00A5;\n\tv271 = 0xBD3CD0(v239, v188, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00A5:\n\tv274 = new System.OutOfMemoryException();\n\tv193 = 0x9DACB4(v274, v188, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NextChars(char[] buffer)
		{
			//IL_02c7: Expected I, but got O
			//IL_0246: Expected O, but got I4
			//IL_0075: Expected I, but got O
			//IL_0085: Expected O, but got I
			//IL_01b0: Expected I4, but got O
			//IL_00c5: Expected O, but got I4
			//IL_01ee: Expected O, but got I4
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B4");
			nint num = (nint)typeof(ThreadSafeRandom);
			object obj = default(object);
			Random random = (Random)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X0_v5 (Il2CppClass<CodeStage.AntiCheat.Utils.ThreadSafeRandom>)+E0]");
			if ((nint)0 != 0)
			{
				if (obj == null)
				{
					goto IL_005a;
				}
			}
			else if (obj == null)
			{
				goto IL_005a;
			}
			goto IL_014f;
			IL_014f:
			NextChars(random, buffer);
			return;
			IL_027d:
			bool lockTaken = default(bool);
			object obj2;
			if (lockTaken)
			{
				Monitor.Exit(Global);
				obj2 = 0;
			}
			int num2;
			int num3;
			int seed;
			if (num2 == 0)
			{
				if (num3 == 3 || num3 == 0)
				{
					Random random2 = new Random(seed);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B4");
					object obj3 = random2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD94B4");
					random = random2;
					goto IL_014f;
				}
				return;
			}
			OutOfMemoryException ex = new OutOfMemoryException();
			goto IL_0170;
			IL_005a:
			Monitor.Enter(Global, ref lockTaken);
			Random global = Global;
			bool flag = Global == null;
			obj2 = lockTaken;
			if (flag)
			{
				goto IL_0170;
			}
			nint num4 = (nint)global;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ X8_v18 (Il2CppClass<System.Random>)+190]");
			obj2 = 0;
			int num5 = Global.Next();
			num3 = 3;
			num2 = 0;
			seed = num5;
			goto IL_027d;
			IL_0170:
			NullReferenceException ex2 = new NullReferenceException();
			if ((nint)obj2 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				object obj4 = default(object);
				num2 = (int)obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				num3 = 0;
				seed = 0;
				goto IL_027d;
			}
			if (lockTaken)
			{
				Monitor.Exit(Global);
				obj2 = 0;
			}
			OutOfMemoryException ex3 = new OutOfMemoryException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0xBD4F78", Offset = "0xBD4F78", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A353E4]) = v34;\nL_0015:\n\tgoto L_001D;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001D:\n\treturnVal1 = CodeStage.AntiCheat.Utils.ThreadSafeRandom::Next(1, 0x7FFFFFFF);\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Next()
		{
			return Next(1, int.MaxValue);
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0xBD4FCC", Offset = "0xBD4FCC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A353E5]) = v37;\nL_0017:\n\tgoto L_0020;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\treturnVal1 = CodeStage.AntiCheat.Utils.ThreadSafeRandom::Next(1, maxExclusive);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int Next(int maxExclusive)
		{
			return Next(1, maxExclusive);
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0xBD4CA4", Offset = "0xBD4CA4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = minInclusive >> 0x20;\n\tv20 = maxExclusive >> 0x20;\n\tv22 = System.Random::Next(random, v17, v20);\n\tv42 = System.Random::Next(random, minInclusive, maxExclusive);\n\tv44 = v22 & 0xFFFFFFFF;\n\tv45 = v44 << 0x20;\n\tv46 = v42 & 0xFFFFFFFF;\n\treturnVal1 = v46 | v45;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static long NextLong(Random random, long minInclusive, long maxExclusive)
		{
			//IL_002d: Expected I4, but got I8
			//IL_002d: Expected I4, but got I8
			//IL_0042: Expected I4, but got I8
			//IL_0042: Expected I4, but got I8
			//IL_0058: Expected I4, but got I8
			//IL_0078: Expected I4, but got I8
			//IL_0085: Expected I8, but got I4
			long num = minInclusive >> 32;
			long num2 = maxExclusive >> 32;
			int num3 = random.Next((int)num, (int)num2);
			int num4 = random.Next((int)minInclusive, (int)maxExclusive);
			int num5 = (int)(num3 & 0xFFFFFFFFL);
			int num6 = num5 << 32;
			int num7 = (int)(num4 & 0xFFFFFFFFL);
			return num7 | num6;
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0xBD4EF0", Offset = "0xBD4EF0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = buffer.Length < 1;\n\tif (v24) goto L_0053;\nL_001F:\n\tv98 = System.Random::Next(random);\n\tv196 = v98 + 0xFF;\n\tv186 = v98 < 0;\n\tv189 = v98 ^ v98;\n\tv190 = v98 & v189;\n\tv191 = v190 < 0;\n\tv192 = v186 == v191;\n\tv193 = ~v192;\n\tv92 = ~v193;\n\tif (v92) goto L_FFFFFFFF;\n\tgoto L_003D;\nL_003D:\n\tv197 = v196 & 0xFF00;\n\tv96 = v98 - v197;\n\tbuffer[v39 @ X21_v6 (System.Int32)] = v96;\n\tv39 = v39 + 1;\n\tv104 = v39 < buffer.Length;\n\tif (v104) goto L_001F;\nL_0053:\n\treturn;\n\tv75 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void NextChars(Random random, char[] buffer)
		{
			if (buffer.Length < 1)
			{
				return;
			}
			int num = 0;
			do
			{
				int num2 = random.Next();
				int num3 = num2 + 255;
				bool flag = num2 < 0;
				int num4 = num2 ^ num2;
				int num5 = num2 & num4;
				bool flag2 = num5 < 0;
				if (flag == flag2)
				{
					num3 = num2;
				}
				int num6 = num3 & 0xFF00;
				int num7 = num2 - num6;
				buffer[num] = (char)num7;
				num++;
			}
			while (num < buffer.Length);
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0xBD5024", Offset = "0xBD5024", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ThreadSafeRandom()
		{
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0xBD502C", Offset = "0xBD502C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = System.Random;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = CodeStage.AntiCheat.Utils.ThreadSafeRandom;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv39 = 1;\n\t*([1A353E6]) = v39;\nL_0018:\n\tv41 = new System.Random();\n\tSystem.Random::.ctor(v41);\n\tv47.Global = v41;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ThreadSafeRandom()
		{
			Random global = new Random();
			Global = global;
		}
	}
}
