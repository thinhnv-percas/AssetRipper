using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000007")]
public class ParticleEffectsLibrary : MonoBehaviour
{
	[Token(Token = "0x400002A")]
	public static ParticleEffectsLibrary GlobalAccess;

	[Token(Token = "0x400002B")]
	[FieldOffset(Offset = "0x18")]
	public int TotalEffects;

	[Token(Token = "0x400002C")]
	[FieldOffset(Offset = "0x1C")]
	public int CurrentParticleEffectIndex;

	[Token(Token = "0x400002D")]
	[FieldOffset(Offset = "0x20")]
	public int CurrentParticleEffectNum;

	[Token(Token = "0x400002E")]
	[FieldOffset(Offset = "0x28")]
	public Vector3[] ParticleEffectSpawnOffsets;

	[Token(Token = "0x400002F")]
	[FieldOffset(Offset = "0x30")]
	public float[] ParticleEffectLifetimes;

	[Token(Token = "0x4000030")]
	[FieldOffset(Offset = "0x38")]
	public GameObject[] ParticleEffectPrefabs;

	[Token(Token = "0x4000031")]
	[FieldOffset(Offset = "0x40")]
	private string effectNameString;

	[Token(Token = "0x4000032")]
	[FieldOffset(Offset = "0x48")]
	private List<Transform> currentActivePEList;

	[Token(Token = "0x4000033")]
	[FieldOffset(Offset = "0x50")]
	private Vector3 spawnPosition;

	[Token(Token = "0x600002A")]
	[Address(RVA = "0xAFECB8", Offset = "0xAFECB8", Length = "0x2EC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EC7C50]);\n\tv25 = *([v24 @ X8_v62]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20224A1]) = v44;\nL_001A:\n\tv48.GlobalAccess = this;\n\tv52 = new System.Collections.Generic.List`1<UnityEngine.Transform>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::.ctor(v52);\n\tv173 = this.ParticleEffectPrefabs;\n\tthis.currentActivePEList = v52;\n\tv62 = this + 0x20;\n\tthis.CurrentParticleEffectNum = 1;\n\tv64 = v62 + -8;\n\t*([v64 @ X20_v8]) = v173.Length;\n\tv65 = this.ParticleEffectSpawnOffsets;\n\tv96 = v173.Length == v65.Length;\n\tif (v96) goto L_0058;\n\tgoto L_004E;\n\tv263 = *([v166 @ X0_v48+E0]);\n\tv264 = v263 == 0;\n\tv265 = ~v264;\n\tif (v265) goto L_004E;\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v166, v56, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004E:\n\tUnityEngine.Debug::LogError(\"ParticleEffectsLibrary-ParticleEffectSpawnOffset: Not all arrays match length, double check counts.\");\n\tv173 = this.ParticleEffectPrefabs;\nL_0058:\n\tv97 = *([v64 @ X20_v8]) == v173.Length;\n\tif (v97) goto L_0073;\n\tgoto L_006E;\n\tv329 = *([v274 @ X0_v44+E0]);\n\tv330 = v329 == 0;\n\tv331 = ~v330;\n\tif (v331) goto L_006E;\n\tv333 = \"il2cpp_codegen_runtime_class_init\"(v274, v170, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_006E:\n\tUnityEngine.Debug::LogError(\"ParticleEffectsLibrary-ParticleEffectPrefabs: Not all arrays match length, double check counts.\");\nL_0073:\n\t// 115 NewArr v129 @ X0_v15 (System.String[]), typeof(System.String[]), 6\n\tv137 = this.ParticleEffectPrefabs;\n\tv122 = this.CurrentParticleEffectIndex;\n\tv336 = this.CurrentParticleEffectIndex < v137.Length;\n\tv113 = ~v336;\n\tif (v113) goto L_0126;\n\tv130 = UnityEngine.Object::get_name(v137[v122 @ X9_v7 (System.Int32)]);\n\tv405 = v130 == 0;\n\tif (v405) goto L_0096;\n\t// 147 IsInst v239 @ X0_v43, typeof(System.String), v130 @ X0_v19 (System.String)\nL_0096:\n\tv402 = v129.Length;\n\tv394 = v129.Length == 0;\n\tif (v394) goto L_0126;\n\tv129[0] = v130;\n\tv411 = \" (\" == 0;\n\tif (v411) goto L_00A5;\n\t// 161 IsInst v240 @ X0_v41, typeof(System.String), \" (\"\n\tv402 = v129.Length;\nL_00A5:\n\tv413 = v402 < 1;\n\tv222 = ~v413;\n\tv217 = v402 - 1;\n\tv207 = v217 == 0;\n\tv414 = ~v222;\n\tv178 = v414 | v207;\n\tif (v178) goto L_0126;\n\tv129[1] = \" (\";\n\tv418 = 0xDC3560(v62, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv419 = v418 == 0;\n\tif (v419) goto L_00BF;\n\t// 188 IsInst v241 @ X0_v40, typeof(System.String), v418 @ X0_v24\nL_00BF:\n\tv403 = v129.Length;\n\tv422 = v129.Length < 2;\n\tv223 = ~v422;\n\tv218 = v129.Length - 2;\n\tv208 = v218 == 0;\n\tv423 = ~v223;\n\tv179 = v423 | v208;\n\tif (v179) goto L_0126;\n\tv129[2] = v418;\n\tv426 = \" of \" == 0;\n\tif (v426) goto L_00D8;\n\t// 212 IsInst v242 @ X0_v38, typeof(System.String), \" of \"\n\tv403 = v129.Length;\nL_00D8:\n\tv428 = v403 < 3;\n\tv224 = ~v428;\n\tv219 = v403 - 3;\n\tv209 = v219 == 0;\n\tv429 = ~v224;\n\tv180 = v429 | v209;\n\tif (v180) goto L_0126;\n\tv129[3] = \" of \";\n\tv433 = 0xDC3560(v64, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv434 = v433 == 0;\n\tif (v434) goto L_00F2;\n\t// 239 IsInst v243 @ X0_v37, typeof(System.String), v433 @ X0_v29\nL_00F2:\n\tv404 = v129.Length;\n\tv437 = v129.Length < 4;\n\tv225 = ~v437;\n\tv220 = v129.Length - 4;\n\tv210 = v220 == 0;\n\tv438 = ~v225;\n\tv181 = v438 | v210;\n\tif (v181) goto L_0126;\n\tv129[4] = v433;\n\tv441 = \")\" == 0;\n\tif (v441) goto L_010B;\n\t// 263 IsInst v244 @ X0_v35, typeof(System.String), \")\"\n\tv404 = v129.Length;\nL_010B:\n\tv443 = v404 < 5;\n\tv362 = ~v443;\n\tv360 = v404 - 5;\n\tv356 = v360 == 0;\n\tv444 = ~v362;\n\tv341 = v444 | v356;\n\tif (v341) goto L_0126;\n\tv129[5] = \")\";\n\tv370 = System.String::Concat(v129);\n\tthis.effectNameString = v370;\n\treturn;\nL_0126:\n\tv319 = new System.IndexOutOfRangeException();\n\tgoto L_012D;\n\tv163 = new System.NullReferenceException();\n\tv262 = new System.ArrayTypeMismatchException();\nL_012D:\n\tthrow v318;\n// 184 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		//IL_0011: Expected O, but got I
		//IL_002b: Expected O, but got I
		//IL_0035: Expected O, but got I4
		//IL_015a: Expected O, but got I4
		//IL_046d: Expected O, but got I
		//IL_01c6: Expected O, but got I4
		//IL_0221: Expected O, but got I4
		//IL_024d: Expected O, but got I4
		//IL_04cb: Expected O, but got I
		//IL_02cf: Expected O, but got I4
		//IL_032a: Expected O, but got I4
		//IL_0356: Expected O, but got I4
		//IL_0529: Expected O, but got I
		//IL_03d8: Expected O, but got I4
		GlobalAccess = this;
		List<Transform> list = new List<Transform>();
		GameObject[] particleEffectPrefabs = ParticleEffectPrefabs;
		currentActivePEList = list;
		object obj = (long)(IntPtr)this + 32L;
		CurrentParticleEffectNum = 1;
		object obj2 = (long)(IntPtr)obj + -8L;
		obj2 = particleEffectPrefabs.Length;
		Vector3[] particleEffectSpawnOffsets = ParticleEffectSpawnOffsets;
		if (particleEffectPrefabs.Length != particleEffectSpawnOffsets.Length)
		{
			Debug.LogError("ParticleEffectsLibrary-ParticleEffectSpawnOffset: Not all arrays match length, double check counts.");
			particleEffectPrefabs = ParticleEffectPrefabs;
		}
		if ((IntPtr)obj2 != (IntPtr)particleEffectPrefabs.Length)
		{
			Debug.LogError("ParticleEffectsLibrary-ParticleEffectPrefabs: Not all arrays match length, double check counts.");
		}
		string[] array = new string[6];
		GameObject[] particleEffectPrefabs2 = ParticleEffectPrefabs;
		int currentParticleEffectIndex = CurrentParticleEffectIndex;
		if (CurrentParticleEffectIndex < particleEffectPrefabs2.Length)
		{
			string text = particleEffectPrefabs2[currentParticleEffectIndex].name;
			if (text != null)
			{
				object obj3 = text as string;
			}
			object obj4 = array.Length;
			if (array.Length != 0)
			{
				array[0] = text;
				if (" (" != null)
				{
					object obj5 = " (" as string;
					obj4 = array.Length;
				}
				bool flag = (long)(IntPtr)obj4 < 1L;
				bool flag2 = !flag;
				object obj6 = (long)(IntPtr)obj4 - 1L;
				bool flag3 = obj6 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = " (";
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
					object obj7 = default(object);
					if (obj7 != null)
					{
						object obj8 = obj7 as string;
					}
					object obj9 = array.Length;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj10 = array.Length - 2;
					bool flag7 = obj10 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = (string)obj7;
						if (" of " != null)
						{
							object obj11 = " of " as string;
							obj9 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj9 < 3L;
						bool flag10 = !flag9;
						object obj12 = (long)(IntPtr)obj9 - 3L;
						bool flag11 = obj12 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = " of ";
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
							object obj13 = default(object);
							if (obj13 != null)
							{
								object obj14 = obj13 as string;
							}
							object obj15 = array.Length;
							bool flag13 = array.Length < 4;
							bool flag14 = !flag13;
							object obj16 = array.Length - 4;
							bool flag15 = obj16 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = (string)obj13;
								if (")" != null)
								{
									object obj17 = ")" as string;
									obj15 = array.Length;
								}
								bool flag17 = (long)(IntPtr)obj15 < 5L;
								bool flag18 = !flag17;
								object obj18 = (long)(IntPtr)obj15 - 5L;
								bool flag19 = obj18 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									array[5] = ")";
									string text2 = string.Concat(array);
									effectNameString = text2;
									return;
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

	[Token(Token = "0x600002B")]
	[Address(RVA = "0xAFEFA4", Offset = "0xAFEFA4", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	private void Start()
	{
	}

	[Token(Token = "0x600002C")]
	[Address(RVA = "0xAFEFA8", Offset = "0xAFEFA8", Length = "0x1EC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EFAAA8]);\n\tv21 = *([v20 @ X8_v35]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20224A2]) = v40;\nL_0018:\n\t// 24 NewArr v45 @ X0_v3 (System.String[]), typeof(System.String[]), 6\n\tv46 = this.ParticleEffectPrefabs;\n\tv49 = this.CurrentParticleEffectIndex;\n\tv51 = this.CurrentParticleEffectIndex < v46.Length;\n\tv52 = ~v51;\n\tif (v52) goto L_00C8;\n\tv105 = UnityEngine.Object::get_name(v46[v49 @ X9_v3 (System.Int32)]);\n\tv275 = v105 == 0;\n\tif (v275) goto L_003B;\n\t// 56 IsInst v279 @ X0_v39, typeof(System.String), v105 @ X0_v13 (System.String)\nL_003B:\n\tv204 = v45.Length;\n\tv191 = v45.Length == 0;\n\tif (v191) goto L_00C8;\n\tv45[0] = v105;\n\tv285 = \" (\" == 0;\n\tif (v285) goto L_004A;\n\t// 70 IsInst v292 @ X0_v37, typeof(System.String), \" (\"\n\tv204 = v45.Length;\nL_004A:\n\tv308 = v204 < 1;\n\tv180 = ~v308;\n\tv174 = v204 - 1;\n\tv162 = v174 == 0;\n\tv309 = ~v180;\n\tv120 = v309 | v162;\n\tif (v120) goto L_00C8;\n\tv311 = this + 0x20;\n\tv45[1] = \" (\";\n\tv313 = 0xDC3560(v311, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv314 = v313 == 0;\n\tif (v314) goto L_0064;\n\t// 97 IsInst v293 @ X0_v36, typeof(System.String), v313 @ X0_v20\nL_0064:\n\tv205 = v45.Length;\n\tv317 = v45.Length < 2;\n\tv178 = ~v317;\n\tv172 = v45.Length - 2;\n\tv160 = v172 == 0;\n\tv318 = ~v178;\n\tv118 = v318 | v160;\n\tif (v118) goto L_00C8;\n\tv45[2] = v313;\n\tv321 = \" of \" == 0;\n\tif (v321) goto L_007D;\n\t// 121 IsInst v294 @ X0_v34, typeof(System.String), \" of \"\n\tv205 = v45.Length;\nL_007D:\n\tv323 = v205 < 3;\n\tv181 = ~v323;\n\tv175 = v205 - 3;\n\tv163 = v175 == 0;\n\tv324 = ~v181;\n\tv121 = v324 | v163;\n\tif (v121) goto L_00C8;\n\tv326 = this + 0x18;\n\tv45[3] = \" of \";\n\tv328 = 0xDC3560(v326, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv329 = v328 == 0;\n\tif (v329) goto L_0097;\n\t// 148 IsInst v295 @ X0_v33, typeof(System.String), v328 @ X0_v25\nL_0097:\n\tv206 = v45.Length;\n\tv332 = v45.Length < 4;\n\tv179 = ~v332;\n\tv173 = v45.Length - 4;\n\tv161 = v173 == 0;\n\tv333 = ~v179;\n\tv119 = v333 | v161;\n\tif (v119) goto L_00C8;\n\tv45[4] = v328;\n\tv336 = \")\" == 0;\n\tif (v336) goto L_00B0;\n\t// 172 IsInst v296 @ X0_v31, typeof(System.String), \")\"\n\tv206 = v45.Length;\nL_00B0:\n\tv338 = v206 < 5;\n\tv182 = ~v338;\n\tv176 = v206 - 5;\n\tv164 = v176 == 0;\n\tv339 = ~v182;\n\tv122 = v339 | v164;\n\tif (v122) goto L_00C8;\n\tv45[5] = \")\";\n\treturnVal2 = System.String::Concat(v45);\n\treturn returnVal2;\nL_00C8:\n\tv207 = new System.IndexOutOfRangeException();\n\tgoto L_00CD;\n\tv241 = new System.ArrayTypeMismatchException();\nL_00CD:\n\tthrow v240;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public string GetCurrentPENameString()
	{
		//IL_008e: Expected O, but got I4
		//IL_03a7: Expected O, but got I
		//IL_010b: Expected O, but got I
		//IL_00fa: Expected O, but got I4
		//IL_0161: Expected O, but got I4
		//IL_018d: Expected O, but got I4
		//IL_0405: Expected O, but got I
		//IL_0220: Expected O, but got I
		//IL_020f: Expected O, but got I4
		//IL_0276: Expected O, but got I4
		//IL_02a2: Expected O, but got I4
		//IL_0463: Expected O, but got I
		//IL_0324: Expected O, but got I4
		string[] array = new string[6];
		GameObject[] particleEffectPrefabs = ParticleEffectPrefabs;
		int currentParticleEffectIndex = CurrentParticleEffectIndex;
		if (CurrentParticleEffectIndex < particleEffectPrefabs.Length)
		{
			string text = particleEffectPrefabs[currentParticleEffectIndex].name;
			if (text != null)
			{
				object obj = text as string;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = text;
				if (" (" != null)
				{
					object obj3 = " (" as string;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					object obj5 = (long)(IntPtr)this + 32L;
					array[1] = " (";
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
					object obj6 = default(object);
					if (obj6 != null)
					{
						object obj7 = obj6 as string;
					}
					object obj8 = array.Length;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj9 = array.Length - 2;
					bool flag7 = obj9 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = (string)obj6;
						if (" of " != null)
						{
							object obj10 = " of " as string;
							obj8 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj8 < 3L;
						bool flag10 = !flag9;
						object obj11 = (long)(IntPtr)obj8 - 3L;
						bool flag11 = obj11 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							object obj12 = (long)(IntPtr)this + 24L;
							array[3] = " of ";
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
							object obj13 = default(object);
							if (obj13 != null)
							{
								object obj14 = obj13 as string;
							}
							object obj15 = array.Length;
							bool flag13 = array.Length < 4;
							bool flag14 = !flag13;
							object obj16 = array.Length - 4;
							bool flag15 = obj16 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = (string)obj13;
								if (")" != null)
								{
									object obj17 = ")" as string;
									obj15 = array.Length;
								}
								bool flag17 = (long)(IntPtr)obj15 < 5L;
								bool flag18 = !flag17;
								object obj18 = (long)(IntPtr)obj15 - 5L;
								bool flag19 = obj18 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									array[5] = ")";
									return string.Concat(array);
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

	[Token(Token = "0x600002D")]
	[Address(RVA = "0xAFF194", Offset = "0xAFF194", Length = "0x340")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EA5CA0]);\n\tv25 = *([v24 @ X8_v52]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20224A3]) = v44;\nL_0016:\n\tv45 = this.ParticleEffectLifetimes;\n\tv47 = this.CurrentParticleEffectIndex;\n\tv49 = this.CurrentParticleEffectIndex < v45.Length;\n\tv50 = ~v49;\n\tif (v50) goto L_0177;\n\tv81 = v45[v47 @ X8_v7 (System.Int32)] != 0;\n\tif (v81) goto L_00B6;\n\tv431 = this.currentActivePEList;\n\tv418 = v431._size;\n\tv328 = v431._size < 1;\n\tif (v328) goto L_00B6;\nL_0047:\n\tv432 = v418 < v74;\n\tv152 = ~v432;\n\tv145 = v418 - v74;\n\tv131 = v145 == 0;\n\tv433 = ~v131;\n\tv82 = v152 & v433;\n\tif (v82) goto L_0055;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0055:\n\tv473 = v431._items;\n\tgoto L_0066;\n\tv479 = *([v474 @ X0_v43+E0]);\n\tv480 = v479 == 0;\n\tv481 = ~v480;\n\tif (v481) goto L_0066;\n\tv483 = \"il2cpp_codegen_runtime_class_init\"(v474, v416, v415, v29, v30, v31, v32, v33, v87, v35, v36, v37, v38, v39, v40, v41);\nL_0066:\n\tv162 = UnityEngine.Object::op_Inequality(v473[v74 @ X21_v17 (System.Int32)], 0);\n\tv487 = v162 == 0;\n\tif (v487) goto L_0094;\n\tv179 = this.currentActivePEList;\n\tv498 = v179._size < v74;\n\tv315 = ~v498;\n\tv314 = v179._size - v74;\n\tv312 = v314 == 0;\n\tv499 = ~v312;\n\tv306 = v315 & v499;\n\tif (v306) goto L_007D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_007D:\n\tv511 = v179._items;\n\tv518 = UnityEngine.Component::get_gameObject(v511[v74 @ X21_v17 (System.Int32)]);\n\tgoto L_0093;\n\tv550 = *([v493 @ X8_v48+E0]);\n\tv551 = v550 == 0;\n\tv552 = ~v551;\n\tif (v552) goto L_0093;\n\tv556 = v493;\n\tv554 = \"il2cpp_codegen_runtime_class_init\"(v556, v517, v66, v29, v30, v31, v32, v33, v87, v35, v36, v37, v38, v39, v40, v41);\nL_0093:\n\tUnityEngine.Object::Destroy(v518);\nL_0094:\n\tv431 = this.currentActivePEList;\n\tv418 = v431._size;\n\tv74 = v74 + 1;\n\tv327 = v74 < v431._size;\n\tif (v327) goto L_0047;\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::Clear(v431);\n\tv367 = this.CurrentParticleEffectIndex;\nL_00B6:\n\tv84 = v367 > 0;\n\tif (v84) goto L_00BA;\n\tv367 = this.TotalEffects;\nL_00BA:\n\tv92 = v367 - 1;\n\tv75 = this + 0x20;\n\tthis.CurrentParticleEffectNum = v367;\n\tthis.CurrentParticleEffectIndex = v92;\n\t// 194 NewArr v164 @ X0_v12 (System.String[]), typeof(System.String[]), 6\n\tv175 = this.ParticleEffectPrefabs;\n\tv93 = this.CurrentParticleEffectIndex;\n\tv434 = this.CurrentParticleEffectIndex < v175.Length;\n\tv155 = ~v434;\n\tif (v155) goto L_0177;\n\tv165 = UnityEngine.Object::get_name(v175[v93 @ X9_v9 (System.Int32)]);\n\tv496 = v165 == 0;\n\tif (v496) goto L_00E5;\n\t// 226 IsInst v505 @ X0_v40, typeof(System.String), v165 @ X0_v14 (System.String)\nL_00E5:\n\tv299 = v164.Length;\n\tv288 = v164.Length == 0;\n\tif (v288) goto L_0177;\n\tv164[0] = v165;\n\tv516 = \" (\" == 0;\n\tif (v516) goto L_00F4;\n\t// 240 IsInst v525 @ X0_v38, typeof(System.String), \" (\"\n\tv299 = v164.Length;\nL_00F4:\n\tv541 = v299 < 1;\n\tv273 = ~v541;\n\tv266 = v299 - 1;\n\tv252 = v266 == 0;\n\tv542 = ~v273;\n\tv211 = v542 | v252;\n\tif (v211) goto L_0177;\n\tv164[1] = \" (\";\n\tv549 = 0xDC3560(v75, 0, 0, v29, v30, v31, v32, v33, v45[v47 @ X8_v7 (System.Int32)], v35, v36, v37, v38, v39, v40, v41);\n\tv555 = v549 == 0;\n\tif (v555) goto L_010E;\n\t// 267 IsInst v526 @ X0_v37, typeof(System.String), v549 @ X0_v21\nL_010E:\n\tv300 = v164.Length;\n\tv559 = v164.Length < 2;\n\tv271 = ~v559;\n\tv264 = v164.Length - 2;\n\tv250 = v264 == 0;\n\tv560 = ~v271;\n\tv209 = v560 | v250;\n\tif (v209) goto L_0177;\n\tv164[2] = v549;\n\tv563 = \" of \" == 0;\n\tif (v563) goto L_0127;\n\t// 291 IsInst v527 @ X0_v35, typeof(System.String), \" of \"\n\tv300 = v164.Length;\nL_0127:\n\tv565 = v300 < 3;\n\tv274 = ~v565;\n\tv267 = v300 - 3;\n\tv253 = v267 == 0;\n\tv566 = ~v274;\n\tv212 = v566 | v253;\n\tif (v212) goto L_0177;\n\tv568 = this + 0x18;\n\tv164[3] = \" of \";\n\tv570 = 0xDC3560(v568, 0, 0, v29, v30, v31, v32, v33, v45[v47 @ X8_v7 (System.Int32)], v35, v36, v37, v38, v39, v40, v41);\n\tv571 = v570 == 0;\n\tif (v571) goto L_0141;\n\t// 318 IsInst v528 @ X0_v34, typeof(System.String), v570 @ X0_v26\nL_0141:\n\tv301 = v164.Length;\n\tv574 = v164.Length < 4;\n\tv272 = ~v574;\n\tv265 = v164.Length - 4;\n\tv251 = v265 == 0;\n\tv575 = ~v272;\n\tv210 = v575 | v251;\n\tif (v210) goto L_0177;\n\tv164[4] = v570;\n\tv578 = \")\" == 0;\n\tif (v578) goto L_015A;\n\t// 342 IsInst v529 @ X0_v32, typeof(System.String), \")\"\n\tv301 = v164.Length;\nL_015A:\n\tv580 = v301 < 5;\n\tv275 = ~v580;\n\tv268 = v301 - 5;\n\tv254 = v268 == 0;\n\tv581 = ~v275;\n\tv213 = v581 | v254;\n\tif (v213) goto L_0177;\n\tv164[5] = \")\";\n\tv461 = System.String::Concat(v164);\n\tthis.effectNameString = v461;\n\treturn;\n\tv279 = new System.NullReferenceException();\nL_0177:\n\tv304 = new System.IndexOutOfRangeException();\n\tgoto L_017C;\n\tv404 = new System.ArrayTypeMismatchException();\nL_017C:\n\tthrow v403;\n// 229 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void PreviousParticleEffect()
	{
		//IL_0753: Expected O, but got I
		//IL_02cb: Expected O, but got I4
		//IL_0648: Expected O, but got I
		//IL_0337: Expected O, but got I4
		//IL_0392: Expected O, but got I4
		//IL_03be: Expected O, but got I4
		//IL_06a6: Expected O, but got I
		//IL_0451: Expected O, but got I
		//IL_0440: Expected O, but got I4
		//IL_04a7: Expected O, but got I4
		//IL_04d3: Expected O, but got I4
		//IL_0704: Expected O, but got I
		//IL_0555: Expected O, but got I4
		float[] particleEffectLifetimes = ParticleEffectLifetimes;
		int currentParticleEffectIndex = CurrentParticleEffectIndex;
		if (CurrentParticleEffectIndex < particleEffectLifetimes.Length)
		{
			bool flag = particleEffectLifetimes[currentParticleEffectIndex] != 0f;
			int num = CurrentParticleEffectIndex;
			if (!flag)
			{
				List<Transform> list = currentActivePEList;
				int count = list.Count;
				bool flag2 = list.Count < 1;
				num = CurrentParticleEffectIndex;
				if (!flag2)
				{
					int num2 = 0;
					do
					{
						bool flag3 = count < num2;
						bool flag4 = !flag3;
						int num3 = count - num2;
						bool flag5 = num3 == 0;
						bool flag6 = !flag5;
						if (!(flag4 && flag6))
						{
							throw new ArgumentOutOfRangeException();
						}
						Transform[] items = list._items;
						if (items[num2] != null)
						{
							List<Transform> list2 = currentActivePEList;
							bool flag7 = list2.Count < num2;
							bool flag8 = !flag7;
							int num4 = list2.Count - num2;
							bool flag9 = num4 == 0;
							bool flag10 = !flag9;
							if (!(flag8 && flag10))
							{
								throw new ArgumentOutOfRangeException();
							}
							Transform[] items2 = list2._items;
							GameObject obj = items2[num2].gameObject;
							UnityEngine.Object.Destroy(obj);
						}
						list = currentActivePEList;
						count = list.Count;
						num2++;
					}
					while (num2 < list.Count);
					list.Clear();
					num = CurrentParticleEffectIndex;
				}
			}
			if (num <= 0)
			{
				num = TotalEffects;
			}
			int currentParticleEffectIndex2 = num - 1;
			object obj2 = (long)(IntPtr)this + 32L;
			CurrentParticleEffectNum = num;
			CurrentParticleEffectIndex = currentParticleEffectIndex2;
			string[] array = new string[6];
			GameObject[] particleEffectPrefabs = ParticleEffectPrefabs;
			int currentParticleEffectIndex3 = CurrentParticleEffectIndex;
			if (CurrentParticleEffectIndex < particleEffectPrefabs.Length)
			{
				string text = particleEffectPrefabs[currentParticleEffectIndex3].name;
				if (text != null)
				{
					object obj3 = text as string;
				}
				object obj4 = array.Length;
				if (array.Length != 0)
				{
					array[0] = text;
					if (" (" != null)
					{
						object obj5 = " (" as string;
						obj4 = array.Length;
					}
					bool flag11 = (long)(IntPtr)obj4 < 1L;
					bool flag12 = !flag11;
					object obj6 = (long)(IntPtr)obj4 - 1L;
					bool flag13 = obj6 == null;
					bool flag14 = !flag12;
					if (!(flag14 || flag13))
					{
						array[1] = " (";
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						object obj7 = default(object);
						if (obj7 != null)
						{
							object obj8 = obj7 as string;
						}
						object obj9 = array.Length;
						bool flag15 = array.Length < 2;
						bool flag16 = !flag15;
						object obj10 = array.Length - 2;
						bool flag17 = obj10 == null;
						bool flag18 = !flag16;
						if (!(flag18 || flag17))
						{
							array[2] = (string)obj7;
							if (" of " != null)
							{
								object obj11 = " of " as string;
								obj9 = array.Length;
							}
							bool flag19 = (long)(IntPtr)obj9 < 3L;
							bool flag20 = !flag19;
							object obj12 = (long)(IntPtr)obj9 - 3L;
							bool flag21 = obj12 == null;
							bool flag22 = !flag20;
							if (!(flag22 || flag21))
							{
								object obj13 = (long)(IntPtr)this + 24L;
								array[3] = " of ";
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
								object obj14 = default(object);
								if (obj14 != null)
								{
									object obj15 = obj14 as string;
								}
								object obj16 = array.Length;
								bool flag23 = array.Length < 4;
								bool flag24 = !flag23;
								object obj17 = array.Length - 4;
								bool flag25 = obj17 == null;
								bool flag26 = !flag24;
								if (!(flag26 || flag25))
								{
									array[4] = (string)obj14;
									if (")" != null)
									{
										object obj18 = ")" as string;
										obj16 = array.Length;
									}
									bool flag27 = (long)(IntPtr)obj16 < 5L;
									bool flag28 = !flag27;
									object obj19 = (long)(IntPtr)obj16 - 5L;
									bool flag29 = obj19 == null;
									bool flag30 = !flag28;
									if (!(flag30 || flag29))
									{
										array[5] = ")";
										string text2 = string.Concat(array);
										effectNameString = text2;
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

	[Token(Token = "0x600002E")]
	[Address(RVA = "0xAFF4D4", Offset = "0xAFF4D4", Length = "0x340")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1ED7AA8]);\n\tv25 = *([v24 @ X8_v53]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20224A4]) = v44;\nL_0016:\n\tv45 = this.ParticleEffectLifetimes;\n\tv47 = this.CurrentParticleEffectIndex;\n\tv49 = this.CurrentParticleEffectIndex < v45.Length;\n\tv50 = ~v49;\n\tif (v50) goto L_017B;\n\tv81 = v45[v47 @ X8_v7 (System.Int32)] != 0;\n\tif (v81) goto L_00AC;\n\tv433 = this.currentActivePEList;\n\tv420 = v433._size;\n\tv328 = v433._size < 1;\n\tif (v328) goto L_00AC;\nL_0047:\n\tv434 = v420 < v74;\n\tv152 = ~v434;\n\tv145 = v420 - v74;\n\tv131 = v145 == 0;\n\tv435 = ~v131;\n\tv82 = v152 & v435;\n\tif (v82) goto L_0055;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0055:\n\tv474 = v433._items;\n\tgoto L_0066;\n\tv481 = *([v475 @ X0_v43+E0]);\n\tv482 = v481 == 0;\n\tv483 = ~v482;\n\tif (v483) goto L_0066;\n\tv485 = \"il2cpp_codegen_runtime_class_init\"(v475, v418, v417, v29, v30, v31, v32, v33, v87, v35, v36, v37, v38, v39, v40, v41);\nL_0066:\n\tv162 = UnityEngine.Object::op_Inequality(v474[v74 @ X21_v14 (System.Int32)], 0);\n\tv489 = v162 == 0;\n\tif (v489) goto L_0094;\n\tv179 = this.currentActivePEList;\n\tv499 = v179._size < v74;\n\tv315 = ~v499;\n\tv314 = v179._size - v74;\n\tv312 = v314 == 0;\n\tv500 = ~v312;\n\tv306 = v315 & v500;\n\tif (v306) goto L_007D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_007D:\n\tv506 = v179._items;\n\tv517 = UnityEngine.Component::get_gameObject(v506[v74 @ X21_v14 (System.Int32)]);\n\tgoto L_0093;\n\tv548 = *([v495 @ X8_v49+E0]);\n\tv549 = v548 == 0;\n\tv550 = ~v549;\n\tif (v550) goto L_0093;\n\tv557 = v495;\n\tv552 = \"il2cpp_codegen_runtime_class_init\"(v557, v516, v66, v29, v30, v31, v32, v33, v87, v35, v36, v37, v38, v39, v40, v41);\nL_0093:\n\tUnityEngine.Object::Destroy(v517);\nL_0094:\n\tv433 = this.currentActivePEList;\n\tv420 = v433._size;\n\tv74 = v74 + 1;\n\tv327 = v74 < v433._size;\n\tif (v327) goto L_0047;\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::Clear(v433);\n\tv359 = this.CurrentParticleEffectIndex;\nL_00AC:\n\tv75 = this + 0x18;\n\tv364 = this.TotalEffects - 1;\n\tv60 = v359 < v364;\n\tif (v60) goto L_00BE;\n\tgoto L_00C0;\nL_00BE:\n\tv413 = v359 + 1;\nL_00C0:\n\tv92 = v413 + 1;\n\tthis.CurrentParticleEffectIndex = v413;\n\tthis.CurrentParticleEffectNum = v92;\n\t// 198 NewArr v164 @ X0_v12 (System.String[]), typeof(System.String[]), 6\n\tv175 = this.ParticleEffectPrefabs;\n\tv93 = this.CurrentParticleEffectIndex;\n\tv480 = this.CurrentParticleEffectIndex < v175.Length;\n\tv155 = ~v480;\n\tif (v155) goto L_017B;\n\tv165 = UnityEngine.Object::get_name(v175[v93 @ X9_v11 (System.Int32)]);\n\tv503 = v165 == 0;\n\tif (v503) goto L_00E9;\n\t// 230 IsInst v512 @ X0_v40, typeof(System.String), v165 @ X0_v14 (System.String)\nL_00E9:\n\tv299 = v164.Length;\n\tv288 = v164.Length == 0;\n\tif (v288) goto L_017B;\n\tv164[0] = v165;\n\tv520 = \" (\" == 0;\n\tif (v520) goto L_00F8;\n\t// 244 IsInst v530 @ X0_v38, typeof(System.String), \" (\"\n\tv299 = v164.Length;\nL_00F8:\n\tv546 = v299 < 1;\n\tv273 = ~v546;\n\tv266 = v299 - 1;\n\tv252 = v266 == 0;\n\tv547 = ~v273;\n\tv211 = v547 | v252;\n\tif (v211) goto L_017B;\n\tv554 = v75 + 8;\n\tv164[1] = \" (\";\n\tv556 = 0xDC3560(v554, 0, 0, v29, v30, v31, v32, v33, v45[v47 @ X8_v7 (System.Int32)], v35, v36, v37, v38, v39, v40, v41);\n\tv558 = v556 == 0;\n\tif (v558) goto L_0112;\n\t// 271 IsInst v531 @ X0_v37, typeof(System.String), v556 @ X0_v21\nL_0112:\n\tv300 = v164.Length;\n\tv561 = v164.Length < 2;\n\tv271 = ~v561;\n\tv264 = v164.Length - 2;\n\tv250 = v264 == 0;\n\tv562 = ~v271;\n\tv209 = v562 | v250;\n\tif (v209) goto L_017B;\n\tv164[2] = v556;\n\tv565 = \" of \" == 0;\n\tif (v565) goto L_012B;\n\t// 295 IsInst v532 @ X0_v35, typeof(System.String), \" of \"\n\tv300 = v164.Length;\nL_012B:\n\tv567 = v300 < 3;\n\tv274 = ~v567;\n\tv267 = v300 - 3;\n\tv253 = v267 == 0;\n\tv568 = ~v274;\n\tv212 = v568 | v253;\n\tif (v212) goto L_017B;\n\tv164[3] = \" of \";\n\tv572 = 0xDC3560(v75, 0, 0, v29, v30, v31, v32, v33, v45[v47 @ X8_v7 (System.Int32)], v35, v36, v37, v38, v39, v40, v41);\n\tv573 = v572 == 0;\n\tif (v573) goto L_0145;\n\t// 322 IsInst v533 @ X0_v34, typeof(System.String), v572 @ X0_v26\nL_0145:\n\tv301 = v164.Length;\n\tv576 = v164.Length < 4;\n\tv272 = ~v576;\n\tv265 = v164.Length - 4;\n\tv251 = v265 == 0;\n\tv577 = ~v272;\n\tv210 = v577 | v251;\n\tif (v210) goto L_017B;\n\tv164[4] = v572;\n\tv580 = \")\" == 0;\n\tif (v580) goto L_015E;\n\t// 346 IsInst v534 @ X0_v32, typeof(System.String), \")\"\n\tv301 = v164.Length;\nL_015E:\n\tv582 = v301 < 5;\n\tv275 = ~v582;\n\tv268 = v301 - 5;\n\tv254 = v268 == 0;\n\tv583 = ~v275;\n\tv213 = v583 | v254;\n\tif (v213) goto L_017B;\n\tv164[5] = \")\";\n\tv462 = System.String::Concat(v164);\n\tthis.effectNameString = v462;\n\treturn;\n\tv279 = new System.NullReferenceException();\nL_017B:\n\tv304 = new System.IndexOutOfRangeException();\n\tgoto L_0180;\n\tv402 = new System.ArrayTypeMismatchException();\nL_0180:\n\tthrow v401;\n// 231 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void NextParticleEffect()
	{
		//IL_05c8: Expected O, but got I
		//IL_02dd: Expected O, but got I4
		//IL_06b7: Expected O, but got I
		//IL_035d: Expected O, but got I
		//IL_0349: Expected O, but got I4
		//IL_03b3: Expected O, but got I4
		//IL_03df: Expected O, but got I4
		//IL_0715: Expected O, but got I
		//IL_0461: Expected O, but got I4
		//IL_04bc: Expected O, but got I4
		//IL_04e8: Expected O, but got I4
		//IL_0773: Expected O, but got I
		//IL_056a: Expected O, but got I4
		float[] particleEffectLifetimes = ParticleEffectLifetimes;
		int currentParticleEffectIndex = CurrentParticleEffectIndex;
		if (CurrentParticleEffectIndex < particleEffectLifetimes.Length)
		{
			bool flag = particleEffectLifetimes[currentParticleEffectIndex] != 0f;
			int currentParticleEffectIndex2 = CurrentParticleEffectIndex;
			if (!flag)
			{
				List<Transform> list = currentActivePEList;
				int count = list.Count;
				bool flag2 = list.Count < 1;
				currentParticleEffectIndex2 = CurrentParticleEffectIndex;
				if (!flag2)
				{
					int num = 0;
					do
					{
						bool flag3 = count < num;
						bool flag4 = !flag3;
						int num2 = count - num;
						bool flag5 = num2 == 0;
						bool flag6 = !flag5;
						if (!(flag4 && flag6))
						{
							throw new ArgumentOutOfRangeException();
						}
						Transform[] items = list._items;
						if (items[num] != null)
						{
							List<Transform> list2 = currentActivePEList;
							bool flag7 = list2.Count < num;
							bool flag8 = !flag7;
							int num3 = list2.Count - num;
							bool flag9 = num3 == 0;
							bool flag10 = !flag9;
							if (!(flag8 && flag10))
							{
								throw new ArgumentOutOfRangeException();
							}
							Transform[] items2 = list2._items;
							GameObject obj = items2[num].gameObject;
							UnityEngine.Object.Destroy(obj);
						}
						list = currentActivePEList;
						count = list.Count;
						num++;
					}
					while (num < list.Count);
					list.Clear();
					currentParticleEffectIndex2 = CurrentParticleEffectIndex;
				}
			}
			object obj2 = (long)(IntPtr)this + 24L;
			int num4 = TotalEffects - 1;
			int num5 = ((currentParticleEffectIndex2 < num4) ? (currentParticleEffectIndex2 + 1) : 0);
			int currentParticleEffectNum = num5 + 1;
			CurrentParticleEffectIndex = num5;
			CurrentParticleEffectNum = currentParticleEffectNum;
			string[] array = new string[6];
			GameObject[] particleEffectPrefabs = ParticleEffectPrefabs;
			int currentParticleEffectIndex3 = CurrentParticleEffectIndex;
			if (CurrentParticleEffectIndex < particleEffectPrefabs.Length)
			{
				string text = particleEffectPrefabs[currentParticleEffectIndex3].name;
				if (text != null)
				{
					object obj3 = text as string;
				}
				object obj4 = array.Length;
				if (array.Length != 0)
				{
					array[0] = text;
					if (" (" != null)
					{
						object obj5 = " (" as string;
						obj4 = array.Length;
					}
					bool flag11 = (long)(IntPtr)obj4 < 1L;
					bool flag12 = !flag11;
					object obj6 = (long)(IntPtr)obj4 - 1L;
					bool flag13 = obj6 == null;
					bool flag14 = !flag12;
					if (!(flag14 || flag13))
					{
						object obj7 = (long)(IntPtr)obj2 + 8L;
						array[1] = " (";
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						object obj8 = default(object);
						if (obj8 != null)
						{
							object obj9 = obj8 as string;
						}
						object obj10 = array.Length;
						bool flag15 = array.Length < 2;
						bool flag16 = !flag15;
						object obj11 = array.Length - 2;
						bool flag17 = obj11 == null;
						bool flag18 = !flag16;
						if (!(flag18 || flag17))
						{
							array[2] = (string)obj8;
							if (" of " != null)
							{
								object obj12 = " of " as string;
								obj10 = array.Length;
							}
							bool flag19 = (long)(IntPtr)obj10 < 3L;
							bool flag20 = !flag19;
							object obj13 = (long)(IntPtr)obj10 - 3L;
							bool flag21 = obj13 == null;
							bool flag22 = !flag20;
							if (!(flag22 || flag21))
							{
								array[3] = " of ";
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
								object obj14 = default(object);
								if (obj14 != null)
								{
									object obj15 = obj14 as string;
								}
								object obj16 = array.Length;
								bool flag23 = array.Length < 4;
								bool flag24 = !flag23;
								object obj17 = array.Length - 4;
								bool flag25 = obj17 == null;
								bool flag26 = !flag24;
								if (!(flag26 || flag25))
								{
									array[4] = (string)obj14;
									if (")" != null)
									{
										object obj18 = ")" as string;
										obj16 = array.Length;
									}
									bool flag27 = (long)(IntPtr)obj16 < 5L;
									bool flag28 = !flag27;
									object obj19 = (long)(IntPtr)obj16 - 5L;
									bool flag29 = obj19 == null;
									bool flag30 = !flag28;
									if (!(flag30 || flag29))
									{
										array[5] = ")";
										string text2 = string.Concat(array);
										effectNameString = text2;
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

	[Token(Token = "0x600002F")]
	[Address(RVA = "0xAFF814", Offset = "0xAFF814", Length = "0x2E0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv42 = *([1F03110]);\n\tv43 = *([v42 @ X8_v33]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, methodInfo, v46, v47, v48, v49, v50, v51, positionInWorldToSpawn, v0, v2, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([20224A5]) = v59;\nL_0021:\n\tv60 = this.ParticleEffectSpawnOffsets;\n\tv64 = this.CurrentParticleEffectIndex < v60.Length;\n\tv65 = ~v64;\n\tif (v65) goto L_012E;\n\tv233 = this.CurrentParticleEffectIndex * 0xC;\n\tv234 = v60 + v233;\n\tgoto L_004A;\n\tv297 = *([v235 @ X0_v10+E0]);\n\tv298 = v297 == 0;\n\tv299 = ~v298;\n\tif (v299) goto L_004A;\n\tv301 = \"il2cpp_codegen_runtime_class_init\"(v235, methodInfo, v46, v47, v48, v49, v50, v51, positionInWorldToSpawn, v0, v2, v52, v53, v54, v55, v56);\nL_004A:\n\t// 74 MakeStruct v107 @ AGGAFF8CC_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v234 @ X8_v7+20], v60[this.CurrentParticleEffectIndex (System.Int32)].y (System.Single), v60[this.CurrentParticleEffectIndex (System.Int32)].z (System.Single)\n\tv122 = UnityEngine.Vector3::op_Addition(positionInWorldToSpawn, v107);\n\tv213 = this.ParticleEffectPrefabs;\n\tthis.spawnPosition = v122;\n\tthis.spawnPosition.y = v122.y;\n\tthis.spawnPosition.z = v122.z;\n\tv185 = this.CurrentParticleEffectIndex;\n\tv353 = this.CurrentParticleEffectIndex < v213.Length;\n\tv173 = ~v353;\n\tif (v173) goto L_012E;\n\tv342 = UnityEngine.GameObject::get_transform(v213[v185 @ X9_v6 (System.Int32)]);\n\tv440 = UnityEngine.Transform::get_rotation(v342);\n\tgoto L_008F;\n\tv449 = *([v445 @ X0_v15+E0]);\n\tv450 = v449 == 0;\n\tv451 = ~v450;\n\tif (v451) goto L_008F;\n\tv453 = \"il2cpp_codegen_runtime_class_init\"(v445, v439, v46, v47, v48, v49, v50, v51, v440, v441, v442, v443, v116, v113, v55, v56);\nL_008F:\n\tv191 = UnityEngine.Object::Instantiate(v213[v185 @ X9_v6 (System.Int32)], v122, v440);\n\tv215 = this.ParticleEffectPrefabs;\n\tv285 = this.CurrentParticleEffectIndex;\n\tv459 = this.CurrentParticleEffectIndex < v215.Length;\n\tv174 = ~v459;\n\tif (v174) goto L_012E;\n\tv192 = System.String::Concat(\"PE_\", v215[v285 @ X9_v7 (System.Int32)]);\n\tUnityEngine.Object::set_name(v191, v192);\n\tv217 = this.ParticleEffectLifetimes;\n\tv187 = this.CurrentParticleEffectIndex;\n\tv463 = this.CurrentParticleEffectIndex < v217.Length;\n\tv280 = ~v463;\n\tif (v280) goto L_012E;\n\tv78 = v217[v187 @ X9_v10 (System.Int32)] != 0;\n\tif (v78) goto L_00DA;\n\tv194 = UnityEngine.GameObject::get_transform(v191);\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::Add(this.currentActivePEList, v194);\nL_00DA:\n\tv195 = UnityEngine.GameObject::get_transform(v191);\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::Add(this.currentActivePEList, v195);\n\tv220 = this.ParticleEffectLifetimes;\n\tv286 = this.CurrentParticleEffectIndex;\n\tv479 = this.CurrentParticleEffectIndex < v220.Length;\n\tv281 = ~v479;\n\tif (v281) goto L_012E;\n\tv361 = v220[v286 @ X9_v11 (System.Int32)] != 0;\n\tif (v361) goto L_0113;\n\treturn;\nL_0113:\n\tgoto L_012A;\n\tv486 = *([v482 @ X0_v26+E0]);\n\tv487 = v486 == 0;\n\tv488 = ~v487;\n\tif (v488) goto L_012A;\n\tv490 = \"il2cpp_codegen_runtime_class_init\"(v482, v100, v83, v47, v48, v49, v50, v51, v124, v229, v226, v120, v117, v114, v91, v56);\nL_012A:\n\tUnityEngine.Object::Destroy(v191, v220[v286 @ X9_v11 (System.Int32)]);\n\treturn;\n\tv231 = new System.NullReferenceException();\nL_012E:\n\tv296 = new System.IndexOutOfRangeException();\n\tthrow v296;\n\tthrow System.NullReferenceException;\n// 233 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SpawnParticleEffect(Vector3 positionInWorldToSpawn)
	{
		//IL_004e: Expected O, but got I
		//IL_0068: Expected F4, but got I
		Vector3[] particleEffectSpawnOffsets = ParticleEffectSpawnOffsets;
		if (CurrentParticleEffectIndex < particleEffectSpawnOffsets.Length)
		{
			int num = CurrentParticleEffectIndex * 12;
			object obj = (long)(IntPtr)particleEffectSpawnOffsets + (long)num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ X8_v7+20]");
			Vector3 vector = default(Vector3);
			vector.x = 0f;
			vector.y = particleEffectSpawnOffsets[CurrentParticleEffectIndex].y;
			vector.z = particleEffectSpawnOffsets[CurrentParticleEffectIndex].z;
			Vector3 position = positionInWorldToSpawn + vector;
			GameObject[] particleEffectPrefabs = ParticleEffectPrefabs;
			spawnPosition = position;
			spawnPosition.y = position.y;
			spawnPosition.z = position.z;
			int currentParticleEffectIndex = CurrentParticleEffectIndex;
			if (CurrentParticleEffectIndex < particleEffectPrefabs.Length)
			{
				Transform transform = particleEffectPrefabs[currentParticleEffectIndex].transform;
				Quaternion rotation = transform.rotation;
				GameObject gameObject = UnityEngine.Object.Instantiate(particleEffectPrefabs[currentParticleEffectIndex], position, rotation);
				GameObject[] particleEffectPrefabs2 = ParticleEffectPrefabs;
				int currentParticleEffectIndex2 = CurrentParticleEffectIndex;
				if (CurrentParticleEffectIndex < particleEffectPrefabs2.Length)
				{
					string text = "PE_" + particleEffectPrefabs2[currentParticleEffectIndex2];
					gameObject.name = text;
					float[] particleEffectLifetimes = ParticleEffectLifetimes;
					int currentParticleEffectIndex3 = CurrentParticleEffectIndex;
					if (CurrentParticleEffectIndex < particleEffectLifetimes.Length)
					{
						if (particleEffectLifetimes[currentParticleEffectIndex3] == 0f)
						{
							Transform item = gameObject.transform;
							currentActivePEList.Add(item);
						}
						Transform item2 = gameObject.transform;
						currentActivePEList.Add(item2);
						float[] particleEffectLifetimes2 = ParticleEffectLifetimes;
						int currentParticleEffectIndex4 = CurrentParticleEffectIndex;
						if (CurrentParticleEffectIndex < particleEffectLifetimes2.Length)
						{
							if (particleEffectLifetimes2[currentParticleEffectIndex4] != 0f)
							{
								UnityEngine.Object.Destroy(gameObject, particleEffectLifetimes2[currentParticleEffectIndex4]);
							}
							return;
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x6000030")]
	[Address(RVA = "0xAFFAF4", Offset = "0xAFFAF4", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F01748]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224A6]) = v38;\nL_0016:\n\tthis.effectNameString = \"\";\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0024:\n\tv56 = UnityEngine.Vector3::get_zero();\n\tthis.spawnPosition = v56;\n\tthis.spawnPosition.y = v56.y;\n\tthis.spawnPosition.z = v56.z;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ParticleEffectsLibrary()
	{
		effectNameString = "";
		Vector3 vector = (spawnPosition = Vector3.zero);
		spawnPosition.y = vector.y;
		spawnPosition.z = vector.z;
	}
}
