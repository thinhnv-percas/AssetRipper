using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins.Core
{
	[Token(Token = "0x2000040")]
	public static class PluginsManager
	{
		[Token(Token = "0x4000100")]
		private static ITweenPlugin _floatPlugin;

		[Token(Token = "0x4000101")]
		private static ITweenPlugin _doublePlugin;

		[Token(Token = "0x4000102")]
		private static ITweenPlugin _intPlugin;

		[Token(Token = "0x4000103")]
		private static ITweenPlugin _uintPlugin;

		[Token(Token = "0x4000104")]
		private static ITweenPlugin _longPlugin;

		[Token(Token = "0x4000105")]
		private static ITweenPlugin _ulongPlugin;

		[Token(Token = "0x4000106")]
		private static ITweenPlugin _vector2Plugin;

		[Token(Token = "0x4000107")]
		private static ITweenPlugin _vector3Plugin;

		[Token(Token = "0x4000108")]
		private static ITweenPlugin _vector4Plugin;

		[Token(Token = "0x4000109")]
		private static ITweenPlugin _quaternionPlugin;

		[Token(Token = "0x400010A")]
		private static ITweenPlugin _colorPlugin;

		[Token(Token = "0x400010B")]
		private static ITweenPlugin _rectPlugin;

		[Token(Token = "0x400010C")]
		private static ITweenPlugin _rectOffsetPlugin;

		[Token(Token = "0x400010D")]
		private static ITweenPlugin _stringPlugin;

		[Token(Token = "0x400010E")]
		private static ITweenPlugin _vector3ArrayPlugin;

		[Token(Token = "0x400010F")]
		private static ITweenPlugin _color2Plugin;

		[Token(Token = "0x4000110")]
		private const int _MaxCustomPlugins = 20;

		[Token(Token = "0x4000111")]
		private static Dictionary<Type, ITweenPlugin> _customPlugins;

		[Token(Token = "0x600023D")]
		[Address(RVA = "0x1368858", Offset = "0x1368858", Length = "0x978")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = *([1EB5300]);\n\tv27 = *([v26 @ X8_v211]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202885C]) = v46;\nL_001F:\n\tgoto L_0027;\n\tv55 = *([v50 @ X0_v2+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0027;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v50, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0027:\n\tv64 = System.Type::GetTypeFromHandle(Il2CppClass<T1>);\n\tv70 = System.Type::GetTypeFromHandle(Il2CppClass<T2>);\n\tv77 = System.Type::GetTypeFromHandle(UnityEngine.Vector3);\n\tv87 = v64 != v70;\n\tif (v87) goto L_0074;\n\tv97 = v64 != v77;\n\tif (v97) goto L_0074;\n\tv117 = v115._vector3Plugin == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_0060;\n\tv132 = new DG.Tweening.Plugins.Vector3Plugin();\n\tDG.Tweening.Plugins.Vector3Plugin::.ctor(v132);\n\tv134._vector3Plugin = v132;\nL_0060:\n\tv404 = v370._floatPlugin == 0;\n\tif (v404) goto L_FFFFFFFF;\n\tgoto L_006D;\n\tv481 = v436;\n\tv482 = 0x8907BC(v481, v320, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_006D:\n\t// 109 IsInst returnVal1 @ X0_v16 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>), typeof(DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>), v370._floatPlugin (DG.Tweening.Plugins.Core.ITweenPlugin)\n\tgoto L_02A0;\nL_0074:\n\tgoto L_007C;\n\tv119 = *([v107 @ X0_v19+E0]);\n\tv120 = v119 == 0;\n\tv121 = ~v120;\n\tif (v121) goto L_007C;\n\tv123 = \"il2cpp_codegen_runtime_class_init\"(v107, v74, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_007C:\n\tv128 = System.Type::GetTypeFromHandle(UnityEngine.Vector3);\n\tv152 = v64 != v128;\n\tif (v152) goto L_00A9;\n\tgoto L_0097;\n\tv465 = *([v406 @ X0_v142+E0]);\n\tv466 = v465 == 0;\n\tv467 = ~v466;\n\tif (v467) goto L_0097;\n\tv469 = \"il2cpp_codegen_runtime_class_init\"(v406, v127, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0097:\n\tv424 = System.Type::GetTypeFromHandle(UnityEngine.Vector3[]);\n\tv242 = v70 == v424;\n\tif (v242) goto L_026C;\nL_00A9:\n\tgoto L_00B1;\n\tv471 = *([v430 @ X0_v24+E0]);\n\tv472 = v471 == 0;\n\tv473 = ~v472;\n\tif (v473) goto L_00B1;\n\tv475 = \"il2cpp_codegen_runtime_class_init\"(v430, v421, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00B1:\n\tv480 = System.Type::GetTypeFromHandle(UnityEngine.Quaternion);\n\tv525 = v64 == v480;\n\tif (v525) goto L_022A;\n\tgoto L_00CB;\n\tv555 = *([v536 @ X0_v37+E0]);\n\tv556 = v555 == 0;\n\tv557 = ~v556;\n\tif (v557) goto L_00CB;\n\tv559 = \"il2cpp_codegen_runtime_class_init\"(v536, v479, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00CB:\n\tv564 = System.Type::GetTypeFromHandle(UnityEngine.Vector2);\n\tv241 = v64 == v564;\n\tif (v241) goto L_0257;\n\tgoto L_00E5;\n\tv595 = *([v578 @ X0_v44+E0]);\n\tv596 = v595 == 0;\n\tv597 = ~v596;\n\tif (v597) goto L_00E5;\n\tv599 = \"il2cpp_codegen_runtime_class_init\"(v578, v563, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00E5:\n\tv338 = System.Type::GetTypeFromHandle(System.Single);\n\tv238 = v64 == v338;\n\tif (v238) goto L_0281;\n\tgoto L_00FF;\n\tv634 = *([v623 @ X0_v50+E0]);\n\tv635 = v634 == 0;\n\tv636 = ~v635;\n\tif (v636) goto L_00FF;\n\tv638 = \"il2cpp_codegen_runtime_class_init\"(v623, v321, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00FF:\n\tv643 = System.Type::GetTypeFromHandle(UnityEngine.Color);\n\tv243 = v64 == v643;\n\tif (v243) goto L_02A6;\n\tgoto L_0119;\n\tv663 = *([v649 @ X0_v57+E0]);\n\tv664 = v663 == 0;\n\tv665 = ~v664;\n\tif (v665) goto L_0119;\n\tv667 = \"il2cpp_codegen_runtime_class_init\"(v649, v642, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0119:\n\tv672 = System.Type::GetTypeFromHandle(System.Int32);\n\tv244 = v64 == v672;\n\tif (v244) goto L_02BB;\n\tgoto L_0133;\n\tv696 = *([v684 @ X0_v64+E0]);\n\tv697 = v696 == 0;\n\tv698 = ~v697;\n\tif (v698) goto L_0133;\n\tv700 = \"il2cpp_codegen_runtime_class_init\"(v684, v671, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0133:\n\tv705 = System.Type::GetTypeFromHandle(UnityEngine.Vector4);\n\tv245 = v64 == v705;\n\tif (v245) goto L_02D0;\n\tgoto L_014D;\n\tv729 = *([v717 @ X0_v71+E0]);\n\tv730 = v729 == 0;\n\tv731 = ~v730;\n\tif (v731) goto L_014D;\n\tv733 = \"il2cpp_codegen_runtime_class_init\"(v717, v704, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_014D:\n\tv738 = System.Type::GetTypeFromHandle(UnityEngine.Rect);\n\tv246 = v64 == v738;\n\tif (v246) goto L_02E5;\n\tgoto L_0167;\n\tv762 = *([v750 @ X0_v78+E0]);\n\tv763 = v762 == 0;\n\tv764 = ~v763;\n\tif (v764) goto L_0167;\n\tv766 = \"il2cpp_codegen_runtime_class_init\"(v750, v737, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0167:\n\tv771 = System.Type::GetTypeFromHandle(UnityEngine.RectOffset);\n\tv247 = v64 == v771;\n\tif (v247) goto L_02FA;\n\tgoto L_0181;\n\tv795 = *([v783 @ X0_v85+E0]);\n\tv796 = v795 == 0;\n\tv797 = ~v796;\n\tif (v797) goto L_0181;\n\tv799 = \"il2cpp_codegen_runtime_class_init\"(v783, v770, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0181:\n\tv804 = System.Type::GetTypeFromHandle(System.UInt32);\n\tv248 = v64 == v804;\n\tif (v248) goto L_030F;\n\tgoto L_019B;\n\tv828 = *([v816 @ X0_v92+E0]);\n\tv829 = v828 == 0;\n\tv830 = ~v829;\n\tif (v830) goto L_019B;\n\tv832 = \"il2cpp_codegen_runtime_class_init\"(v816, v803, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_019B:\n\tv837 = System.Type::GetTypeFromHandle(System.String);\n\tv249 = v64 == v837;\n\tif (v249) goto L_0324;\n\tgoto L_01B5;\n\tv861 = *([v849 @ X0_v99+E0]);\n\tv862 = v861 == 0;\n\tv863 = ~v862;\n\tif (v863) goto L_01B5;\n\tv865 = \"il2cpp_codegen_runtime_class_init\"(v849, v836, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_01B5:\n\tv870 = System.Type::GetTypeFromHandle(DG.Tweening.Color2);\n\tv250 = v64 == v870;\n\tif (v250) goto L_0339;\n\tgoto L_01CF;\n\tv894 = *([v882 @ X0_v106+E0]);\n\tv895 = v894 == 0;\n\tv896 = ~v895;\n\tif (v896) goto L_01CF;\n\tv898 = \"il2cpp_codegen_runtime_class_init\"(v882, v869, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_01CF:\n\tv903 = System.Type::GetTypeFromHandle(System.Int64);\n\tv251 = v64 == v903;\n\tif (v251) goto L_034E;\n\tgoto L_01E9;\n\tv927 = *([v915 @ X0_v113+E0]);\n\tv928 = v927 == 0;\n\tv929 = ~v928;\n\tif (v929) goto L_01E9;\n\tv931 = \"il2cpp_codegen_runtime_class_init\"(v915, v902, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_01E9:\n\tv936 = System.Type::GetTypeFromHandle(System.UInt64);\n\tv252 = v64 == v936;\n\tif (v252) goto L_0363;\n\tgoto L_0203;\n\tv958 = *([v948 @ X0_v120+E0]);\n\tv959 = v958 == 0;\n\tv960 = ~v959;\n\tif (v960) goto L_0203;\n\tv962 = \"il2cpp_codegen_runtime_class_init\"(v948, v935, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0203:\n\tv964 = System.Type::GetTypeFromHandle(System.Double);\n\tv172 = v64 != v964;\n\tif (v172) goto L_02A0;\n\tv979 = v977._doublePlugin == 0;\n\tv356 = ~v979;\n\tif (v356) goto L_0224;\n\tv984 = new DG.Tweening.Plugins.DoublePlugin();\n\tDG.Tweening.Plugins.DoublePlugin::.ctor(v984);\n\tv985._doublePlugin = v984;\nL_0224:\n\tgoto L_0060;\nL_022A:\n\tgoto L_0232;\n\tv565 = *([v542 @ X0_v28+E0]);\n\tv566 = v565 == 0;\n\tv567 = ~v566;\n\tif (v567) goto L_0232;\n\tv569 = \"il2cpp_codegen_runtime_class_init\"(v542, v479, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0232:\n\tv573 = System.Type::GetTypeFromHandle(UnityEngine.Quaternion);\n\tv240 = v70 == v573;\n\tif (v240) goto L_0295;\n\tv593 = v591._quaternionPlugin == 0;\n\tv357 = ~v593;\n\tif (v357) goto L_0251;\n\tv615 = new DG.Tweening.Plugins.QuaternionPlugin();\n\tDG.Tweening.Plugins.QuaternionPlugin::.ctor(v615);\n\tv616._quaternionPlugin = v615;\nL_0251:\n\tgoto L_0060;\nL_0257:\n\tv588 = v586._vector2Plugin == 0;\n\tv358 = ~v588;\n\tif (v358) goto L_0266;\n\tv606 = new DG.Tweening.Plugins.Vector2Plugin();\n\tDG.Tweening.Plugins.Vector2Plugin::.ctor(v606);\n\tv607._vector2Plugin = v606;\nL_0266:\n\tgoto L_0060;\nL_026C:\n\tv534 = v532._vector3ArrayPlugin == 0;\n\tv359 = ~v534;\n\tif (v359) goto L_027B;\n\tv549 = new DG.Tweening.Plugins.Vector3ArrayPlugin();\n\tDG.Tweening.Plugins.Vector3ArrayPlugin::.ctor(v549);\n\tv550._vector3ArrayPlugin = v549;\nL_027B:\n\tgoto \n// ... truncated")]
		internal static ABSTweenPlugin<T1, T2, TPlugOptions> GetDefaultPlugin<T1, T2, TPlugOptions>() where TPlugOptions : struct, IPlugOptions
		{
			Type typeFromHandle = typeof(T1);
			Type typeFromHandle2 = typeof(T2);
			Type typeFromHandle3 = typeof(Vector3);
			ABSTweenPlugin<T1, T2, TPlugOptions> result;
			if ((object)typeFromHandle == typeFromHandle2 && (object)typeFromHandle == typeFromHandle3)
			{
				if (_vector3Plugin == null)
				{
					Vector3Plugin vector3Plugin = new Vector3Plugin();
					_vector3Plugin = vector3Plugin;
				}
			}
			else
			{
				Type typeFromHandle4 = typeof(Vector3);
				if ((object)typeFromHandle == typeFromHandle4)
				{
					Type typeFromHandle5 = typeof(Vector3[]);
					if ((object)typeFromHandle2 == typeFromHandle5)
					{
						if (_vector3ArrayPlugin == null)
						{
							Vector3ArrayPlugin vector3ArrayPlugin = new Vector3ArrayPlugin();
							_vector3ArrayPlugin = vector3ArrayPlugin;
						}
						goto IL_084b;
					}
				}
				Type typeFromHandle6 = typeof(Quaternion);
				if ((object)typeFromHandle != typeFromHandle6)
				{
					Type typeFromHandle7 = typeof(Vector2);
					if ((object)typeFromHandle != typeFromHandle7)
					{
						Type typeFromHandle8 = typeof(float);
						if ((object)typeFromHandle != typeFromHandle8)
						{
							Type typeFromHandle9 = typeof(Color);
							if ((object)typeFromHandle != typeFromHandle9)
							{
								Type typeFromHandle10 = typeof(int);
								if ((object)typeFromHandle != typeFromHandle10)
								{
									Type typeFromHandle11 = typeof(Vector4);
									if ((object)typeFromHandle != typeFromHandle11)
									{
										Type typeFromHandle12 = typeof(Rect);
										if ((object)typeFromHandle != typeFromHandle12)
										{
											Type typeFromHandle13 = typeof(RectOffset);
											if ((object)typeFromHandle != typeFromHandle13)
											{
												Type typeFromHandle14 = typeof(uint);
												if ((object)typeFromHandle != typeFromHandle14)
												{
													Type typeFromHandle15 = typeof(string);
													if ((object)typeFromHandle != typeFromHandle15)
													{
														Type typeFromHandle16 = typeof(Color2);
														if ((object)typeFromHandle != typeFromHandle16)
														{
															Type typeFromHandle17 = typeof(long);
															if ((object)typeFromHandle != typeFromHandle17)
															{
																Type typeFromHandle18 = typeof(ulong);
																if ((object)typeFromHandle != typeFromHandle18)
																{
																	Type typeFromHandle19 = typeof(double);
																	bool flag = (object)typeFromHandle != typeFromHandle19;
																	result = null;
																	if (flag)
																	{
																		goto IL_0832;
																	}
																	if (_doublePlugin == null)
																	{
																		DoublePlugin doublePlugin = new DoublePlugin();
																		_doublePlugin = doublePlugin;
																	}
																}
																else if (_ulongPlugin == null)
																{
																	UlongPlugin ulongPlugin = new UlongPlugin();
																	_ulongPlugin = ulongPlugin;
																}
															}
															else if (_longPlugin == null)
															{
																LongPlugin longPlugin = new LongPlugin();
																_longPlugin = longPlugin;
															}
														}
														else if (_color2Plugin == null)
														{
															Color2Plugin color2Plugin = new Color2Plugin();
															_color2Plugin = color2Plugin;
														}
													}
													else if (_stringPlugin == null)
													{
														StringPlugin stringPlugin = new StringPlugin();
														_stringPlugin = stringPlugin;
													}
												}
												else if (_uintPlugin == null)
												{
													UintPlugin uintPlugin = new UintPlugin();
													_uintPlugin = uintPlugin;
												}
											}
											else if (_rectOffsetPlugin == null)
											{
												RectOffsetPlugin rectOffsetPlugin = new RectOffsetPlugin();
												_rectOffsetPlugin = rectOffsetPlugin;
											}
										}
										else if (_rectPlugin == null)
										{
											RectPlugin rectPlugin = new RectPlugin();
											_rectPlugin = rectPlugin;
										}
									}
									else if (_vector4Plugin == null)
									{
										Vector4Plugin vector4Plugin = new Vector4Plugin();
										_vector4Plugin = vector4Plugin;
									}
								}
								else if (_intPlugin == null)
								{
									IntPlugin intPlugin = new IntPlugin();
									_intPlugin = intPlugin;
								}
							}
							else if (_colorPlugin == null)
							{
								ColorPlugin colorPlugin = new ColorPlugin();
								_colorPlugin = colorPlugin;
							}
						}
						else if (_floatPlugin == null)
						{
							FloatPlugin floatPlugin = new FloatPlugin();
							_floatPlugin = floatPlugin;
						}
					}
					else if (_vector2Plugin == null)
					{
						Vector2Plugin vector2Plugin = new Vector2Plugin();
						_vector2Plugin = vector2Plugin;
					}
				}
				else
				{
					Type typeFromHandle20 = typeof(Quaternion);
					if ((object)typeFromHandle2 == typeFromHandle20)
					{
						Debugger.LogError("Quaternion tweens require a Vector3 endValue");
						goto IL_0567;
					}
					if (_quaternionPlugin == null)
					{
						QuaternionPlugin quaternionPlugin = new QuaternionPlugin();
						_quaternionPlugin = quaternionPlugin;
					}
				}
			}
			goto IL_084b;
			IL_0567:
			result = null;
			goto IL_0832;
			IL_0832:
			return result;
			IL_084b:
			if (_floatPlugin == null)
			{
				goto IL_0567;
			}
			result = _floatPlugin as ABSTweenPlugin<T1, T2, TPlugOptions>;
			goto IL_0832;
		}

		[Token(Token = "0x600023E")]
		[Address(RVA = "0x13686F0", Offset = "0x13686F0", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EAC688]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202885B]) = v42;\nL_001E:\n\tgoto L_0026;\n\tv52 = *([v46 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0026:\n\tv61 = System.Type::GetTypeFromHandle(Il2CppClass<TPlugin>);\n\tv68 = v66._customPlugins == 0;\n\tif (v68) goto L_003D;\n\tv76 = System.Collections.Generic.Dictionary`2<System.Type, DG.Tweening.Plugins.Core.ITweenPlugin>::TryGetValue(v66._customPlugins, v61, &v72 @ stack_-38_v5 (DG.Tweening.Plugins.Core.ITweenPlugin));\n\tv82 = v76 == 0;\n\tif (v82) goto L_004A;\n\tgoto L_005F;\nL_003D:\n\tv80 = new System.Collections.Generic.Dictionary`2<System.Type, DG.Tweening.Plugins.Core.ITweenPlugin>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, DG.Tweening.Plugins.Core.ITweenPlugin>::.ctor(v80, 0x14);\n\tv97._customPlugins = v80;\nL_004A:\n\tv101 = System.Activator::CreateInstance();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, DG.Tweening.Plugins.Core.ITweenPlugin>::Add(v105._customPlugins, v61, v101);\nL_005F:\n\tgoto L_0064;\n\tv131 = v124;\n\tv132 = System.Collections.Generic.Dictionary`2<System.Type, DG.Tweening.Plugins.Core.ITweenPlugin>::Add(v131, v117, v113, v110);\nL_0064:\n\t// 100 IsInst returnVal2 @ X0_v14 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>), typeof(DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>), v101 @ X0_v8 (DG.Tweening.Plugins.Core.ITweenPlugin)\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ABSTweenPlugin<T1, T2, TPlugOptions> GetCustomPlugin<TPlugin, T1, T2, TPlugOptions>() where TPlugin : ITweenPlugin, new() where TPlugOptions : struct, IPlugOptions
		{
			Type typeFromHandle = typeof(TPlugin);
			if (_customPlugins != null)
			{
				if (_customPlugins.TryGetValue(typeFromHandle, out var _))
				{
					goto IL_00a7;
				}
			}
			else
			{
				Dictionary<Type, ITweenPlugin> customPlugins = new Dictionary<Type, ITweenPlugin>(20);
				_customPlugins = customPlugins;
			}
			ITweenPlugin tweenPlugin = new TPlugin();
			_customPlugins.Add(typeFromHandle, tweenPlugin);
			goto IL_00a7;
			IL_00a7:
			return tweenPlugin as ABSTweenPlugin<T1, T2, TPlugOptions>;
		}

		[Token(Token = "0x600023F")]
		[Address(RVA = "0x107B534", Offset = "0x107B534", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1ECFA90]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026A5A]) = v35;\nL_0015:\n\tv39._floatPlugin = 0;\n\tv41._intPlugin = 0;\n\tv42._uintPlugin = 0;\n\tv43._longPlugin = 0;\n\tv44._ulongPlugin = 0;\n\tv45._vector2Plugin = 0;\n\tv46._vector3Plugin = 0;\n\tv47._vector4Plugin = 0;\n\tv48._quaternionPlugin = 0;\n\tv49._colorPlugin = 0;\n\tv50._rectPlugin = 0;\n\tv51._rectOffsetPlugin = 0;\n\tv52._stringPlugin = 0;\n\tv53._vector3ArrayPlugin = 0;\n\tv54._color2Plugin = 0;\n\tv57 = v55._customPlugins == 0;\n\tif (v57) goto L_0044;\n\tSystem.Collections.Generic.Dictionary`2<System.Type, DG.Tweening.Plugins.Core.ITweenPlugin>::Clear(v55._customPlugins);\n\treturn;\nL_0044:\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void PurgeAll()
		{
			_floatPlugin = null;
			_intPlugin = null;
			_uintPlugin = null;
			_longPlugin = null;
			_ulongPlugin = null;
			_vector2Plugin = null;
			_vector3Plugin = null;
			_vector4Plugin = null;
			_quaternionPlugin = null;
			_colorPlugin = null;
			_rectPlugin = null;
			_rectOffsetPlugin = null;
			_stringPlugin = null;
			_vector3ArrayPlugin = null;
			_color2Plugin = null;
			if (_customPlugins != null)
			{
				_customPlugins.Clear();
			}
		}
	}
}
