using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins.Core
{
	[Token(Token = "0x2000098")]
	internal static class PluginsManager
	{
		[Token(Token = "0x4000194")]
		private static ITweenPlugin _floatPlugin;

		[Token(Token = "0x4000195")]
		private static ITweenPlugin _doublePlugin;

		[Token(Token = "0x4000196")]
		private static ITweenPlugin _intPlugin;

		[Token(Token = "0x4000197")]
		private static ITweenPlugin _uintPlugin;

		[Token(Token = "0x4000198")]
		private static ITweenPlugin _longPlugin;

		[Token(Token = "0x4000199")]
		private static ITweenPlugin _ulongPlugin;

		[Token(Token = "0x400019A")]
		private static ITweenPlugin _vector2Plugin;

		[Token(Token = "0x400019B")]
		private static ITweenPlugin _vector3Plugin;

		[Token(Token = "0x400019C")]
		private static ITweenPlugin _vector4Plugin;

		[Token(Token = "0x400019D")]
		private static ITweenPlugin _quaternionPlugin;

		[Token(Token = "0x400019E")]
		private static ITweenPlugin _colorPlugin;

		[Token(Token = "0x400019F")]
		private static ITweenPlugin _rectPlugin;

		[Token(Token = "0x40001A0")]
		private static ITweenPlugin _rectOffsetPlugin;

		[Token(Token = "0x40001A1")]
		private static ITweenPlugin _stringPlugin;

		[Token(Token = "0x40001A2")]
		private static ITweenPlugin _vector3ArrayPlugin;

		[Token(Token = "0x40001A3")]
		private static ITweenPlugin _color2Plugin;

		[Token(Token = "0x40001A4")]
		private const int _MaxCustomPlugins = 20;

		[Token(Token = "0x40001A5")]
		private static Dictionary<Type, ITweenPlugin> _customPlugins;

		[Token(Token = "0x6000386")]
		[Address(RVA = "0xC86C4C", Offset = "0xC86C4C", Length = "0xA60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0084;\n\tgoto L_0084;\n\tv38 = 0xB3490C(methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0084:\n\tgoto L_0088;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v48, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0088:\n\tv59 = System.Type::GetTypeFromHandle(Il2CppClass<T1>);\n\tv68 = System.Type::GetTypeFromHandle(Il2CppClass<T2>);\n\tv78 = System.Type::GetTypeFromHandle(UnityEngine.Vector3);\n\tv91 = v59 != v68;\n\tif (v91) goto L_00DE;\n\tv104 = v59 != v78;\n\tif (v104) goto L_00DE;\n\tv127 = v125._vector3Plugin == 0;\n\tv128 = ~v127;\n\tif (v128) goto L_00C0;\n\tv140 = new DG.Tweening.Plugins.Vector3Plugin();\n\tDG.Tweening.Plugins.Vector3Plugin::.ctor(v140);\n\tv147._vector3Plugin = v140;\nL_00C0:\n\tv413 = v395._floatPlugin == 0;\n\tif (v413) goto L_FFFFFFFF;\n\tgoto L_00D6;\n\tv502 = 0xB348B0(v446, v345, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_00D6:\n\tgoto L_FFFFFFFF;\n\tgoto L_0269;\nL_00DE:\n\tgoto L_00E2;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v114, v75, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_00E2:\n\tv133 = System.Type::GetTypeFromHandle(UnityEngine.Vector3);\n\tv158 = v59 != v133;\n\tif (v158) goto L_010B;\n\tgoto L_00F9;\n\tv491 = \"il2cpp_codegen_runtime_class_init\"(v415, v132, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_00F9:\n\tv433 = System.Type::GetTypeFromHandle(UnityEngine.Vector3[]);\n\tv251 = v68 == v433;\n\tif (v251) goto L_02AB;\nL_010B:\n\tgoto L_010F;\n\tv494 = \"il2cpp_codegen_runtime_class_init\"(v437, v430, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_010F:\n\tv498 = System.Type::GetTypeFromHandle(UnityEngine.Quaternion);\n\tv559 = v59 == v498;\n\tif (v559) goto L_026F;\n\tgoto L_0125;\n\tv595 = \"il2cpp_codegen_runtime_class_init\"(v575, v497, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0125:\n\tv599 = System.Type::GetTypeFromHandle(UnityEngine.Vector2);\n\tv250 = v59 == v599;\n\tif (v250) goto L_0297;\n\tgoto L_013B;\n\tv633 = \"il2cpp_codegen_runtime_class_init\"(v615, v598, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_013B:\n\tv363 = System.Type::GetTypeFromHandle(System.Single);\n\tv247 = v59 == v363;\n\tif (v247) goto L_02BF;\n\tgoto L_0151;\n\tv674 = \"il2cpp_codegen_runtime_class_init\"(v660, v346, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0151:\n\tv678 = System.Type::GetTypeFromHandle(UnityEngine.Color);\n\tv252 = v59 == v678;\n\tif (v252) goto L_02DB;\n\tgoto L_0167;\n\tv706 = \"il2cpp_codegen_runtime_class_init\"(v690, v677, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0167:\n\tv710 = System.Type::GetTypeFromHandle(System.Int32);\n\tv253 = v59 == v710;\n\tif (v253) goto L_02EF;\n\tgoto L_017D;\n\tv741 = \"il2cpp_codegen_runtime_class_init\"(v727, v709, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_017D:\n\tv745 = System.Type::GetTypeFromHandle(UnityEngine.Vector4);\n\tv254 = v59 == v745;\n\tif (v254) goto L_0303;\n\tgoto L_0193;\n\tv776 = \"il2cpp_codegen_runtime_class_init\"(v762, v744, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0193:\n\tv780 = System.Type::GetTypeFromHandle(UnityEngine.Rect);\n\tv255 = v59 == v780;\n\tif (v255) goto L_0317;\n\tgoto L_01A9;\n\tv811 = \"il2cpp_codegen_runtime_class_init\"(v797, v779, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_01A9:\n\tv815 = System.Type::GetTypeFromHandle(UnityEngine.RectOffset);\n\tv256 = v59 == v815;\n\tif (v256) goto L_032B;\n\tgoto L_01BF;\n\tv846 = \"il2cpp_codegen_runtime_class_init\"(v832, v814, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_01BF:\n\tv850 = System.Type::GetTypeFromHandle(System.UInt32);\n\tv257 = v59 == v850;\n\tif (v257) goto L_033F;\n\tgoto L_01D5;\n\tv876 = \"il2cpp_codegen_runtime_class_init\"(v864, v849, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_01D5:\n\tv880 = System.Type::GetTypeFromHandle(System.String);\n\tv258 = v59 == v880;\n\tif (v258) goto L_0353;\n\tgoto L_01EB;\n\tv902 = \"il2cpp_codegen_runtime_class_init\"(v891, v879, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_01EB:\n\tv906 = System.Type::GetTypeFromHandle(DG.Tweening.Color2);\n\tv259 = v59 == v906;\n\tif (v259) goto L_0367;\n\tgoto L_0201;\n\tv928 = \"il2cpp_codegen_runtime_class_init\"(v917, v905, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0201:\n\tv932 = System.Type::GetTypeFromHandle(System.Int64);\n\tv260 = v59 == v932;\n\tif (v260) goto L_037B;\n\tgoto L_0217;\n\tv954 = \"il2cpp_codegen_runtime_class_init\"(v943, v931, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0217:\n\tv958 = System.Type::GetTypeFromHandle(System.UInt64);\n\tv261 = v59 == v958;\n\tif (v261) goto L_038F;\n\tgoto L_022D;\n\tv976 = \"il2cpp_codegen_runtime_class_init\"(v969, v957, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_022D:\n\tv979 = System.Type::GetTypeFromHandle(System.Double);\n\tv181 = v59 != v979;\n\tif (v181) goto L_0269;\n\tv992 = v991._doublePlugin == 0;\n\tv381 = ~v992;\n\tif (v381) goto L_024D;\n\tv997 = new DG.Tweening.Plugins.DoublePlugin();\n\tDG.Tweening.Plugins.DoublePlugin::.ctor(v997);\n\tv1001._doublePlugin = v997;\nL_024D:\n\tgoto L_00C0;\n\tv507 = v507_asT == 0;\n\tif (v507) goto L_FFFFFFFF;\n\tgoto L_0269;\nL_0269:\n\treturn returnVal1;\nL_026F:\n\tgoto L_0273;\n\tv600 = \"il2cpp_codegen_runtime_class_init\"(v581, v497, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0273:\n\tv604 = System.Type::GetTypeFromHandle(UnityEngine.Quaternion);\n\tv249 = v68 == v604;\n\tif (v249) goto L_02D4;\n\tv628 = v627._quaternionPlugin == 0;\n\tv382 = ~v628;\n\tif (v382) goto L_0291;\n\tv647 = new DG.Tweening.Plugins.QuaternionPlugin();\n\tDG.Tweening.Plugins.QuaternionPlugin::.ctor(v647);\n\tv651._quaternionPlugin = v647;\nL_0291:\n\tgoto L_00C0;\nL_0297:\n\tv624 = v623._vector2Plugin == 0;\n\tv383 = ~v624;\n\tif (v383) goto L_02A5;\n\tv639 = new DG.Tweening.Plugins.Vector2Plugin();\n\tDG.Tweening.Plugins.Vector2Plugin::.ctor(v639);\n\tv643._vector2Plugin = v639;\nL_02A5:\n\tgoto L_00C0;\nL_02AB:\n\tv573 = v572._vector3ArrayPlugin == 0;\n\tv384 = ~v573;\n\tif (v384) goto L_02B9;\n\tv590 = new DG.Tweening.Plugins.Vector3ArrayPlugin();\n\tDG.Tweening.Plugins.Vector3ArrayPlugin::.ctor(v590);\n\tv594._vector3ArrayPlugin = v590;\nL_02B9:\n\tgoto L_00C0;\nL_02BF:\n\tv668 = v396._floatPlugin == 0;\n\tv380 = ~v668;\n\tif (v380) goto L_00C0;\n\tv364 = new DG.Tweening.Plugins.FloatPlugin();\n\tDG.Tweening.Plugins.FloatPlugin::.ctor(v364);\n\tv701._floatPlugin = v364;\n\tgoto L_00C0;\nL_02D4:\n\tDG.Tweening.Core.Debugger::LogError(\"Quaternion tweens require a Vector3 endValue\", 0);\n\tgoto L_FFFFFFFF;\nL_02DB:\n\tv699 = v698._colorPlugin == 0;\n\tv385 = ~v699;\n\tif (v385) goto L_02E9;\n\tv714 = new DG.Tweening.Plugins.ColorPlugin();\n\tDG.Tweening.Plugins.ColorPlugin::.ctor(v714);\n\tv718._colorPlugin = v714;\nL_02E9:\n\tgoto L_00C0;\nL_02EF:\n\tv736 = v735._intPlugin == 0;\n\tv386 = ~v736;\n\tif (v386) goto L_02FD;\n\tv749 = new DG.Tweening.Plugins.IntPlugin();\n\tDG.Tweening.Plugins.IntPlugin::.ctor(v749);\n\tv753._intPlugin = v749;\nL_02FD:\n\tgoto L_00C0;\nL_0303:\n\tv771 = v770._vector4Plugin == 0;\n\tv387 = ~v771;\n\tif (v387) goto L_0311;\n\tv784 = new DG.Tweening.Plugins.Vector4Plugin();\n\tDG.Tweening.Plugins.Vector4Plugin::.ctor(v784);\n\tv788._vector4Plugin = v784;\nL_0311:\n\tgoto L_00C0;\nL_0317:\n\tv806 = v805._rectPlugin == 0;\n\tv388 = ~v806;\n\tif (v388) goto L_0325;\n\tv819 = new DG.Tweening.Plugins.RectPlugin();\n\tDG.Tweening.Plugins.RectPlugin::.ctor(v819);\n\tv823._rectPlugin = v819;\nL_0325:\n\tgoto L_00C0;\nL_032B:\n\tv841 = v840._rectOffsetPlugin == 0;\n\tv389 = ~v841;\n\tif (v389) goto L_0339;\n\tv854 = new DG.Tweening.Plugins.RectOffsetPlugin();\n\tDG.Tweening.Plugins.RectOffsetPlugin::.ctor(v854);\n\tv858._rectOffsetPlugin = v854;\nL_0339:\n\tgoto L_00C0;\nL_033F:\n\tv873 = v872._uintPlugin == 0;\n\tv390 = ~v873;\n\tif (v390) goto L_034D;\n\tv884 = new DG.Tweening.Plugins.UintPlugin();\n\tDG.Tweening.Plugins.UintPlugin::.ctor(v884);\n\tv888._uintPlugin = v884;\nL_034D:\n\tgoto L_00C0;\nL_0353:\n\tv900 = v899._stringPlugin == 0;\n\tv391 = ~v900;\n\tif (v391) goto L_0361;\n\tv910 = new DG.Tweening.Plugins.StringPlugin();\n\t\n// ... truncated")]
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
						goto IL_089a;
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
																		goto IL_0881;
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
						goto IL_00db;
					}
					if (_quaternionPlugin == null)
					{
						QuaternionPlugin quaternionPlugin = new QuaternionPlugin();
						_quaternionPlugin = quaternionPlugin;
					}
				}
			}
			goto IL_089a;
			IL_00db:
			result = null;
			goto IL_0881;
			IL_0881:
			return result;
			IL_089a:
			if (_floatPlugin == null)
			{
				goto IL_00db;
			}
			ABSTweenPlugin<T1, T2, TPlugOptions> aBSTweenPlugin = _floatPlugin as ABSTweenPlugin<T1, T2, TPlugOptions>;
			result = (ABSTweenPlugin<T1, T2, TPlugOptions>)((aBSTweenPlugin == null) ? null : _floatPlugin);
			goto IL_0881;
		}

		[Token(Token = "0x6000387")]
		[Address(RVA = "0xC866D0", Offset = "0xC866D0", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tgoto L_002C;\n\tv34 = 0xB3490C(methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_002C:\n\tgoto L_0030;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v45, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0030:\n\tv56 = System.Type::GetTypeFromHandle(Il2CppClass<TPlugin>);\n\tv66 = v64._customPlugins == 0;\n\tif (v66) goto L_0047;\n\tv77 = System.Collections.Generic.Dictionary`2<System.Type, DG.Tweening.Plugins.Core.ITweenPlugin>::TryGetValue(v64._customPlugins, v56, &v73 @ stack_-28_v5 (System.Object));\n\tv86 = v77 == 0;\n\tif (v86) goto L_0053;\n\tgoto L_0067;\nL_0047:\n\tv81 = new System.Collections.Generic.Dictionary`2<System.Type, DG.Tweening.Plugins.Core.ITweenPlugin>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, DG.Tweening.Plugins.Core.ITweenPlugin>::.ctor(v81, 0x14);\n\tv103._customPlugins = v81;\nL_0053:\n\tv106 = System.Activator::CreateInstance();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, DG.Tweening.Plugins.Core.ITweenPlugin>::Add(v133._customPlugins, v56, v106);\nL_0067:\n\tgoto L_0069;\n\tv135 = System.Collections.Generic.Dictionary`2<System.Type, DG.Tweening.Plugins.Core.ITweenPlugin>::Add(v127, v117, v114, v110);\nL_0069:\n\tv137 = v106 == 0;\n\tif (v137) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0093;\n\tv186 = v186_asT == 0;\n\tif (v186) goto L_FFFFFFFF;\n\tgoto L_0093;\nL_0093:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ABSTweenPlugin<T1, T2, TPlugOptions> GetCustomPlugin<TPlugin, T1, T2, TPlugOptions>() where TPlugin : ITweenPlugin, new() where TPlugOptions : struct, IPlugOptions
		{
			Type typeFromHandle = typeof(TPlugin);
			if (_customPlugins != null)
			{
				object value;
				if (_customPlugins.TryGetValue(typeFromHandle, out *(ITweenPlugin*)(&value)))
				{
					goto IL_00c0;
				}
			}
			else
			{
				Dictionary<Type, ITweenPlugin> customPlugins = new Dictionary<Type, ITweenPlugin>(20);
				_customPlugins = customPlugins;
			}
			object obj = Activator.CreateInstance<object>();
			_customPlugins.Add(typeFromHandle, (ITweenPlugin)obj);
			goto IL_00c0;
			IL_00c0:
			if (obj == null)
			{
				return null;
			}
			ABSTweenPlugin<T1, T2, TPlugOptions> aBSTweenPlugin = obj as ABSTweenPlugin<T1, T2, TPlugOptions>;
			if (aBSTweenPlugin != null)
			{
				return (ABSTweenPlugin<T1, T2, TPlugOptions>)obj;
			}
			return null;
		}

		[Token(Token = "0x6000388")]
		[Address(RVA = "0xC285F0", Offset = "0xC285F0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv44 = DG.Tweening.Plugins.Core.PluginsManager;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3579F]) = v35;\nL_0017:\n\tv38._floatPlugin = 0;\n\tv40._rectOffsetPlugin = 0;\n\tv40._vector3ArrayPlugin = 0;\n\tv40._vector4Plugin = 0;\n\tv40._colorPlugin = 0;\n\tv40._longPlugin = 0;\n\tv40._vector2Plugin = 0;\n\tv40._intPlugin = 0;\n\tv42 = v40._customPlugins == 0;\n\tif (v42) goto L_0031;\n\tSystem.Collections.Generic.Dictionary`2<System.Type, DG.Tweening.Plugins.Core.ITweenPlugin>::Clear(v40._customPlugins);\n\treturn;\nL_0031:\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void PurgeAll()
		{
			_floatPlugin = null;
			_rectOffsetPlugin = null;
			_vector3ArrayPlugin = null;
			_vector4Plugin = null;
			_colorPlugin = null;
			_longPlugin = null;
			_vector2Plugin = null;
			_intPlugin = null;
			if (_customPlugins != null)
			{
				_customPlugins.Clear();
			}
		}
	}
}
