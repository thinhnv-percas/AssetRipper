using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x200004D")]
	public class FsmDebugUtility
	{
		[Token(Token = "0x6000165")]
		[Address(RVA = "0xCA4020", Offset = "0xCA4020", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1F0BC20]);\n\tv29 = *([v28 @ X8_v32]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, text, frameCount, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2023536]) = v46;\nL_001C:\n\tv50 = HutongGames.PlayMaker.Fsm::get_GameObject(fsm);\n\tgoto L_002E;\n\tv147 = *([v103 @ X8_v7+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_002E;\n\tv156 = v103;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v156, v49, frameCount, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_002E:\n\tv155 = UnityEngine.Object::op_Inequality(v50, 0);\n\tv158 = v155 == 0;\n\tif (v158) goto L_00B9;\n\t// 54 NewArr v135 @ X0_v14 (System.String[]), typeof(System.String[]), 5\n\tv226 = text == 0;\n\tif (v226) goto L_0042;\n\t// 63 IsInst v230 @ X0_v40, typeof(System.String), text @ X1 (System.String)\nL_0042:\n\tv289 = v135.Length;\n\tv237 = v135.Length == 0;\n\tif (v237) goto L_00BB;\n\tv135[0] = text;\n\tv240 = \" : \" == 0;\n\tif (v240) goto L_0051;\n\t// 77 IsInst v309 @ X0_v38, typeof(System.String), \" : \"\n\tv289 = v135.Length;\nL_0051:\n\tv327 = v289 < 1;\n\tv124 = ~v327;\n\tv122 = v289 - 1;\n\tv118 = v122 == 0;\n\tv328 = ~v124;\n\tv108 = v328 | v118;\n\tif (v108) goto L_00BB;\n\tv135[1] = \" : \";\n\tv136 = HutongGames.PlayMaker.Fsm::get_GameObject(fsm);\n\tv333 = UnityEngine.Object::get_name(v136);\n\tv334 = v333 == 0;\n\tif (v334) goto L_006F;\n\t// 108 IsInst v310 @ X0_v37, typeof(System.String), v333 @ X0_v26 (System.String)\nL_006F:\n\tv224 = v135.Length;\n\tv337 = v135.Length < 2;\n\tv266 = ~v337;\n\tv263 = v135.Length - 2;\n\tv257 = v263 == 0;\n\tv338 = ~v266;\n\tv242 = v338 | v257;\n\tif (v242) goto L_00BB;\n\tv135[2] = v333;\n\tv340 = \" : \" == 0;\n\tif (v340) goto L_0086;\n\t// 130 IsInst v311 @ X0_v35, typeof(System.String), \" : \"\n\tv224 = v135.Length;\nL_0086:\n\tv342 = v224 < 3;\n\tv267 = ~v342;\n\tv264 = v224 - 3;\n\tv258 = v264 == 0;\n\tv343 = ~v267;\n\tv243 = v343 | v258;\n\tif (v243) goto L_00BB;\n\tv135[3] = \" : \";\n\tv344 = fsm.name == 0;\n\tif (v344) goto L_009E;\n\t// 154 IsInst v312 @ X0_v34, typeof(System.String), fsm.name (System.String)\n\tv224 = v135.Length;\nL_009E:\n\tv347 = v224 < 4;\n\tv212 = ~v347;\n\tv211 = v224 - 4;\n\tv209 = v211 == 0;\n\tv348 = ~v212;\n\tv204 = v348 | v209;\n\tif (v204) goto L_00BB;\n\tv135[4] = fsm.name;\n\tv218 = System.String::Concat(v135);\nL_00B9:\n\tHutongGames.PlayMaker.FsmDebugUtility::Log(v222, frameCount);\n\treturn;\nL_00BB:\n\tv291 = new System.IndexOutOfRangeException();\n\tgoto L_00C0;\n\tv325 = new System.ArrayTypeMismatchException();\nL_00C0:\n\tthrow v330;\n\tthrow System.NullReferenceException;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Log(Fsm fsm, string text, bool frameCount = false)
		{
			//IL_0096: Expected O, but got I4
			//IL_02fb: Expected O, but got I
			//IL_0102: Expected O, but got I4
			//IL_0172: Expected O, but got I4
			//IL_019e: Expected O, but got I4
			//IL_0359: Expected O, but got I
			//IL_0220: Expected O, but got I4
			//IL_03b7: Expected O, but got I
			//IL_027b: Expected O, but got I4
			GameObject gameObject = fsm.GameObject;
			bool flag = gameObject != null;
			bool flag2 = !flag;
			string text2 = text;
			if (!flag2)
			{
				string[] array = new string[5];
				if (text != null)
				{
					object obj = text as string;
				}
				object obj2 = array.Length;
				if (array.Length != 0)
				{
					array[0] = text;
					if (" : " != null)
					{
						object obj3 = " : " as string;
						obj2 = array.Length;
					}
					bool flag3 = (long)(IntPtr)obj2 < 1L;
					bool flag4 = !flag3;
					object obj4 = (long)(IntPtr)obj2 - 1L;
					bool flag5 = obj4 == null;
					bool flag6 = !flag4;
					if (!(flag6 || flag5))
					{
						array[1] = " : ";
						GameObject gameObject2 = fsm.GameObject;
						string name = gameObject2.name;
						if (name != null)
						{
							object obj5 = name as string;
						}
						object obj6 = array.Length;
						bool flag7 = array.Length < 2;
						bool flag8 = !flag7;
						object obj7 = array.Length - 2;
						bool flag9 = obj7 == null;
						bool flag10 = !flag8;
						if (!(flag10 || flag9))
						{
							array[2] = name;
							if (" : " != null)
							{
								object obj8 = " : " as string;
								obj6 = array.Length;
							}
							bool flag11 = (long)(IntPtr)obj6 < 3L;
							bool flag12 = !flag11;
							object obj9 = (long)(IntPtr)obj6 - 3L;
							bool flag13 = obj9 == null;
							bool flag14 = !flag12;
							if (!(flag14 || flag13))
							{
								array[3] = " : ";
								if (fsm.Name != null)
								{
									object obj10 = fsm.Name as string;
									obj6 = array.Length;
								}
								bool flag15 = (long)(IntPtr)obj6 < 4L;
								bool flag16 = !flag15;
								object obj11 = (long)(IntPtr)obj6 - 4L;
								bool flag17 = obj11 == null;
								bool flag18 = !flag16;
								if (!(flag18 || flag17))
								{
									array[4] = fsm.Name;
									string text3 = string.Concat(array);
									text2 = text3;
									goto IL_02c4;
								}
							}
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				throw ex2;
			}
			goto IL_02c4;
			IL_02c4:
			Log(text2, frameCount);
		}

		[Token(Token = "0x6000166")]
		[Address(RVA = "0xCA420C", Offset = "0xCA420C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ECAB18]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, frameCount, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023537]) = v41;\nL_0016:\n\tv43 = frameCount == 0;\n\tif (v43) goto L_002E;\n\tv45 = UnityEngine.Time::get_frameCount();\n\t// 32 Box v72 @ X0_v10 (System.Object), typeof(System.Int32), &v45 @ X0_v8 (System.Int32)\n\ttext = System.String::Concat(v72, \" : \", text);\nL_002E:\n\tgoto L_0036;\n\tv73 = *([v63 @ X0_v3+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tgoto L_0036;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v63, v50, v48, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0036:\n\tUnityEngine.Debug::Log(v57);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Log(string text, bool frameCount = false)
		{
			bool flag = !frameCount;
			string message = text;
			if (!flag)
			{
				int frameCount2 = Time.frameCount;
				object obj = frameCount2;
				string text2 = string.Concat(obj, " : ", text);
				message = text;
			}
			Debug.Log(message);
		}

		[Token(Token = "0x6000167")]
		[Address(RVA = "0xCA42C8", Offset = "0xCA42C8", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1F08218]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, text, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023538]) = v41;\nL_0019:\n\tv45 = UnityEngine.Object::get_name(obj);\n\tv53 = System.String::Concat(v45, \" : \", text);\n\tHutongGames.PlayMaker.FsmDebugUtility::Log(v53, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Log(UnityEngine.Object obj, string text)
		{
			string name = obj.name;
			string text2 = name + " : " + text;
			Log(text2);
		}

		[Token(Token = "0x6000168")]
		[Address(RVA = "0xCA4348", Offset = "0xCA4348", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmDebugUtility()
		{
		}
	}
}
