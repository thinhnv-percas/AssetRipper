using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker;
using UnityEngine;

namespace Doozy.PlayMaker.Actions
{
	[Token(Token = "0x200006C")]
	public static class DOTweenActionsUtils
	{
		[Token(Token = "0x60002BE")]
		[Address(RVA = "0x9FE9D0", Offset = "0x9FE9D0", Length = "0x26C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EF5960]);\n\tv25 = *([v24 @ X8_v41]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, message, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021C50]) = v43;\nL_001A:\n\t// 26 NewArr v48 @ X0_v3 (System.String[]), typeof(System.String[]), 8\n\tv54 = \"GameObject [\" == 0;\n\tif (v54) goto L_0029;\n\t// 37 IsInst v120 @ X0_v49, typeof(System.String), \"GameObject [\"\nL_0029:\n\tv127 = v48.Length == 0;\n\tif (v127) goto L_00FD;\n\tv48[0] = \"GameObject [\";\n\tv105 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv335 = HutongGames.PlayMaker.Fsm::get_GameObjectName(v105);\n\tv336 = v335 == 0;\n\tif (v336) goto L_003F;\n\t// 60 IsInst v274 @ X0_v48, typeof(System.String), v335 @ X0_v19 (System.String)\nL_003F:\n\tv248 = v48.Length;\n\tv339 = v48.Length < 1;\n\tv208 = ~v339;\n\tv201 = v48.Length - 1;\n\tv187 = v201 == 0;\n\tv340 = ~v208;\n\tv152 = v340 | v187;\n\tif (v152) goto L_00FD;\n\tv48[1] = v335;\n\tv343 = \"] -> FSM [\" == 0;\n\tif (v343) goto L_0058;\n\t// 84 IsInst v275 @ X0_v46, typeof(System.String), \"] -> FSM [\"\n\tv248 = v48.Length;\nL_0058:\n\tv345 = v248 < 2;\n\tv95 = ~v345;\n\tv91 = v248 - 2;\n\tv83 = v91 == 0;\n\tv346 = ~v95;\n\tv63 = v346 | v83;\n\tif (v63) goto L_00FD;\n\tv48[2] = \"] -> FSM [\";\n\tv106 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv348 = v106.name == 0;\n\tif (v348) goto L_0074;\n\t// 113 IsInst v276 @ X0_v45, typeof(System.String), v106.name (System.String)\nL_0074:\n\tv252 = v48.Length;\n\tv351 = v48.Length < 3;\n\tv209 = ~v351;\n\tv202 = v48.Length - 3;\n\tv188 = v202 == 0;\n\tv352 = ~v209;\n\tv153 = v352 | v188;\n\tif (v153) goto L_00FD;\n\tv48[3] = v106.name;\n\tv355 = \"] -> State [\" == 0;\n\tif (v355) goto L_008D;\n\t// 137 IsInst v277 @ X0_v43, typeof(System.String), \"] -> State [\"\n\tv252 = v48.Length;\nL_008D:\n\tv357 = v252 < 4;\n\tv210 = ~v357;\n\tv203 = v252 - 4;\n\tv189 = v203 == 0;\n\tv358 = ~v210;\n\tv154 = v358 | v189;\n\tif (v154) goto L_00FD;\n\tv48[4] = \"] -> State [\";\n\tv359 = state.name == 0;\n\tif (v359) goto L_00A5;\n\t// 161 IsInst v278 @ X0_v42, typeof(System.String), state.name (System.String)\n\tv252 = v48.Length;\nL_00A5:\n\tv362 = v252 < 5;\n\tv211 = ~v362;\n\tv204 = v252 - 5;\n\tv190 = v204 == 0;\n\tv363 = ~v211;\n\tv155 = v363 | v190;\n\tif (v155) goto L_00FD;\n\tv48[5] = state.name;\n\tv366 = \"]: \" == 0;\n\tif (v366) goto L_00BD;\n\t// 185 IsInst v279 @ X0_v40, typeof(System.String), \"]: \"\n\tv252 = v48.Length;\nL_00BD:\n\tv368 = v252 < 6;\n\tv212 = ~v368;\n\tv205 = v252 - 6;\n\tv191 = v205 == 0;\n\tv369 = ~v212;\n\tv156 = v369 | v191;\n\tif (v156) goto L_00FD;\n\tv48[6] = \"]: \";\n\tv370 = message == 0;\n\tif (v370) goto L_00D4;\n\t// 208 IsInst v280 @ X0_v39, typeof(System.String), message @ X1 (System.String)\n\tv252 = v48.Length;\nL_00D4:\n\tv373 = v252 < 7;\n\tv213 = ~v373;\n\tv206 = v252 - 7;\n\tv192 = v206 == 0;\n\tv374 = ~v213;\n\tv157 = v374 | v192;\n\tif (v157) goto L_00FD;\n\tv48[7] = message;\n\tv377 = System.String::Concat(v48);\n\tgoto L_00FB;\n\tv384 = *([v327 @ X8_v25+E0]);\n\tv385 = v384 == 0;\n\tv386 = ~v385;\n\tif (v386) goto L_00FB;\n\tv389 = v327;\n\tv388 = \"il2cpp_codegen_runtime_class_init\"(v389, v376, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00FB:\n\tUnityEngine.Debug::Log(v377);\n\treturn;\nL_00FD:\n\tv253 = new System.IndexOutOfRangeException();\n\tgoto L_0102;\n\tv298 = new System.ArrayTypeMismatchException();\nL_0102:\n\tthrow v333;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 147 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Debug(this FsmState state, string message)
		{
			//IL_00c5: Expected O, but got I4
			//IL_00f1: Expected O, but got I4
			//IL_0418: Expected O, but got I
			//IL_0173: Expected O, but got I4
			//IL_01e0: Expected O, but got I4
			//IL_020c: Expected O, but got I4
			//IL_0476: Expected O, but got I
			//IL_0293: Expected O, but got I4
			//IL_04d4: Expected O, but got I
			//IL_02ee: Expected O, but got I4
			//IL_0532: Expected O, but got I
			//IL_0345: Expected O, but got I4
			//IL_0590: Expected O, but got I
			//IL_0396: Expected O, but got I4
			string[] array = new string[8];
			if ("GameObject [" != null)
			{
				object obj = "GameObject [" as string;
			}
			if (array.Length != 0)
			{
				array[0] = "GameObject [";
				Fsm fsm = state.Fsm;
				string gameObjectName = fsm.GameObjectName;
				if (gameObjectName != null)
				{
					object obj2 = gameObjectName as string;
				}
				object obj3 = array.Length;
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj4 = array.Length - 1;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = gameObjectName;
					if ("] -> FSM [" != null)
					{
						object obj5 = "] -> FSM [" as string;
						obj3 = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj3 < 2L;
					bool flag6 = !flag5;
					object obj6 = (long)(IntPtr)obj3 - 2L;
					bool flag7 = obj6 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = "] -> FSM [";
						Fsm fsm2 = state.Fsm;
						if (fsm2.Name != null)
						{
							object obj7 = fsm2.Name as string;
						}
						object obj8 = array.Length;
						bool flag9 = array.Length < 3;
						bool flag10 = !flag9;
						object obj9 = array.Length - 3;
						bool flag11 = obj9 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = fsm2.Name;
							if ("] -> State [" != null)
							{
								object obj10 = "] -> State [" as string;
								obj8 = array.Length;
							}
							bool flag13 = (long)(IntPtr)obj8 < 4L;
							bool flag14 = !flag13;
							object obj11 = (long)(IntPtr)obj8 - 4L;
							bool flag15 = obj11 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = "] -> State [";
								if (state.Name != null)
								{
									object obj12 = state.Name as string;
									obj8 = array.Length;
								}
								bool flag17 = (long)(IntPtr)obj8 < 5L;
								bool flag18 = !flag17;
								object obj13 = (long)(IntPtr)obj8 - 5L;
								bool flag19 = obj13 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									array[5] = state.Name;
									if ("]: " != null)
									{
										object obj14 = "]: " as string;
										obj8 = array.Length;
									}
									bool flag21 = (long)(IntPtr)obj8 < 6L;
									bool flag22 = !flag21;
									object obj15 = (long)(IntPtr)obj8 - 6L;
									bool flag23 = obj15 == null;
									bool flag24 = !flag22;
									if (!(flag24 || flag23))
									{
										array[6] = "]: ";
										if (message != null)
										{
											object obj16 = message as string;
											obj8 = array.Length;
										}
										bool flag25 = (long)(IntPtr)obj8 < 7L;
										bool flag26 = !flag25;
										object obj17 = (long)(IntPtr)obj8 - 7L;
										bool flag27 = obj17 == null;
										bool flag28 = !flag26;
										if (!(flag28 || flag27))
										{
											array[7] = message;
											string message2 = string.Concat(array);
											UnityEngine.Debug.Log(message2);
											return;
										}
									}
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
