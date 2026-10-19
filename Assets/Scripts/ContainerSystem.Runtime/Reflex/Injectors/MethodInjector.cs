using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Caching;
using Reflex.Core;
using Reflex.Pooling;

namespace Reflex.Injectors
{
	[Token(Token = "0x200001E")]
	internal static class MethodInjector
	{
		[ThreadStatic]
		[Token(Token = "0x4000031")]
		private static SizeSpecificArrayPool<object> _arrayPool;

		[Token(Token = "0x17000010")]
		private static SizeSpecificArrayPool<object> ArrayPool
		{
			[Token(Token = "0x6000054")]
			[Address(RVA = "0x3F33654", Offset = "0x3F33654", Length = "0xCC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = *([B78EB0E]) & 1;\n\tv15 = v14 == 0;\n\tif (v15) goto L_0022;\n\tv17 = 0x21C104C(Reflex.Injectors.MethodInjector, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\treturnVal1 = *([v17 @ X0_v24]);\n\tv37 = *([v17 @ X0_v24]) == 0;\n\tif (v37) goto L_002C;\nL_0017:\n\treturn returnVal1;\nL_0022:\n\t*([B78EB0E]) = 1;\n\tv82 = 0x21C104C(Reflex.Injectors.MethodInjector, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = *([v82 @ X0_v20]);\n\tv85 = *([v82 @ X0_v20]) == 0;\n\tv44 = ~v85;\n\tif (v44) goto L_0017;\nL_002C:\n\tv57 = new Reflex.Pooling.SizeSpecificArrayPool`1<System.Object>();\n\tReflex.Pooling.SizeSpecificArrayPool`1<System.Object>::.ctor(v57, 0x10);\n\tv84 = 0x21C104C(Reflex.Injectors.MethodInjector, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v84 @ X0_v5]) = v57;\n\tv87 = 0x21C104C(Reflex.Injectors.MethodInjector, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v57;\n")]
			get
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EB0E]");
				SizeSpecificArrayPool<object> result;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C104C");
					object obj = default(object);
					result = (SizeSpecificArrayPool<object>)obj;
					if (obj != null)
					{
						goto IL_0067;
					}
				}
				else
				{
					_ = 1;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C104C");
					object obj2 = default(object);
					result = (SizeSpecificArrayPool<object>)obj2;
					if (obj2 != null)
					{
						goto IL_0067;
					}
				}
				SizeSpecificArrayPool<object> sizeSpecificArrayPool = new SizeSpecificArrayPool<object>(16);
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C104C");
				object obj3 = sizeSpecificArrayPool;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C104C");
				return sizeSpecificArrayPool;
				IL_0067:
				return result;
			}
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x3F324B8", Offset = "0x3F324B8", Length = "0x314")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv61 = v53.Parameters;\n\tv119 = Reflex.Injectors.MethodInjector::get_ArrayPool();\n\tv217 = Reflex.Pooling.SizeSpecificArrayPool`1<System.Object>::Rent(v119, v61.Length);\n\tv230 = v61.Length < 1;\n\tv301 = v61.Length;\n\tif (v230) goto L_0080;\n\tv333 = container == 0;\n\tif (v333) goto L_00AF;\n\tv247 = 0x20;\n\tv251 = 0;\n\tv306 = v61.Length;\n\tv399 = *([v61 @ X24_v7 (System.Reflection.ParameterInfo[])+v247 @ X26_v11 (System.Int32)]) == 0;\n\tif (v399) goto L_00B8;\n\tv406 = System.Reflection.ParameterInfo::get_ParameterType(*([v61 @ X24_v7 (System.Reflection.ParameterInfo[])+v247 @ X26_v11 (System.Int32)]));\n\tv408 = Reflex.Core.Container::Resolve(container, v406);\n\tv318 = v199 == 0;\n\tif (v318) goto L_00A1;\n\tv453 = v408 == 0;\n\tv303 = v406;\n\tif (v453) goto L_0064;\n\tv457 = 0x21C11D0(v408, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv320 = v457 == 0;\n\tv303 = System.Object;\n\tif (v320) goto L_00A5;\nL_0064:\n\tv460 = v251 < v199.Length;\n\tv295 = ~v460;\n\tif (v295) goto L_00A3;\n\t*([v199 @ stack_-68_v7 (System.Object[])+v247 @ X26_v11 (System.Int32)]) = v408;\n\tv251 = v251 + 1;\n\tv247 = v247 + 8;\n\tv336 = v61.Length != v251;\n\tv301 = v408;\n\tv306 = v408;\n\tif (v336) goto L_0043;\nL_0080:\n\tv208 = v53.MethodInfo == 0;\n\tv105 = &v199 @ stack_-68_v7 (System.Object[]);\n\tv196 = 0;\n\tif (v208) goto L_00AC;\n\tv402 = System.Reflection.MethodBase::Invoke(v53.MethodInfo, instance, v199);\n\tv105 = &v199 @ stack_-68_v7 (System.Object[]);\n\tv130 = 0;\n\tReflex.Pooling.SizeSpecificArrayPool`1<System.Object>::Return(v120, *([v105 @ stack_-80_v1]));\n\tv454 = v130 == 0;\n\tv158 = ~v454;\n\tif (v158) goto L_00AB;\n\treturn;\nL_00A1:\n\tv213 = new System.NullReferenceException();\n\tv105 = &v199 @ stack_-68_v7 (System.Object[]);\n\tv196 = 0;\n\tv301 = v406;\n\tgoto L_010D;\nL_00A3:\n\tv312 = new System.IndexOutOfRangeException();\n\tv105 = &v199 @ stack_-68_v7 (System.Object[]);\n\tv196 = 0;\n\tv301 = v303;\n\tv213 = v312;\n\tgoto L_010D;\nL_00A5:\n\tv462 = new System.ArrayTypeMismatchException();\n\tthrow v462;\nL_00AB:\n\tv164 = new System.OutOfMemoryException();\n\tv105 = v148;\n\tv301 = v151;\nL_00AC:\n\tv213 = new System.NullReferenceException();\n\tgoto L_010D;\nL_00AF:\n\tv363 = v61.Length == 0;\n\tv364 = ~v363;\n\tv306 = v61.Length;\n\tif (v364) goto L_00B4;\nL_00B2:\n\tv314 = new System.IndexOutOfRangeException();\n\tv105 = &v199 @ stack_-68_v7 (System.Object[]);\n\tv196 = 0;\n\tv301 = v306;\n\tv213 = v314;\n\tgoto L_010D;\nL_00B4:\n\tv390 = v61[0];\n\tv391 = v61[0] == 0;\n\tv323 = ~v391;\n\tv306 = v61.Length;\n\tif (v323) goto L_00BA;\nL_00B8:\n\tv213 = new System.NullReferenceException();\n\tv105 = &v199 @ stack_-68_v7 (System.Object[]);\n\tv196 = 0;\n\tv301 = v306;\n\tgoto L_010D;\nL_00BA:\n\tv330 = *([v390 @ X0_v28 (System.Reflection.ParameterInfo)]);\n\tv301 = *([v330 @ X8_v18 (Il2CppClass<System.Reflection.ParameterInfo>)+1F0]);\n\tv401 = System.Reflection.ParameterInfo::get_ParameterType(v61[0]);\n\tv213 = new System.NullReferenceException();\n\tv105 = &v199 @ stack_-68_v7 (System.Object[]);\n\tv196 = 0;\n\tgoto L_010D;\nL_00DB:\n\tv359 = v301 != 1;\n\tif (v359) goto L_0118;\n\tv369 = 0x8BF5BC4(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv130 = *([v369 @ X0_v10]);\n\tv402 = 0x8BF5BF4(v369, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0087;\nL_010D:\n\t// 269 Interrupt\n\tgoto L_00DB;\nL_0118:\n\tv372 = 0x3192A54(&v196 @ stack_-88_v4 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv397 = 0x8BF0368(v213, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv404 = 0xA1B8(v397, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0043:\n\tv388 = v251 < v61.Length;\n\tv294 = ~v388;\n\tif (v294) goto L_00B2;\nL_0087:\n\tv120 = Reflex.Injectors.MethodInjector::get_ArrayPool();\n")]
		internal static void Inject(InjectableMethodInfo method, object instance, Container container)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MethodInjector::Inject");
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x3F327CC", Offset = "0x3F327CC", Length = "0x33C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv62 = v53.Parameters;\n\tv122 = Reflex.Injectors.MethodInjector::get_ArrayPool();\n\tv224 = Reflex.Pooling.SizeSpecificArrayPool`1<System.Object>::Rent(v122, v62.Length);\n\tv183 = v62.Length < 1;\n\tv308 = v62.Length;\n\tif (v183) goto L_0086;\n\tv344 = container == 0;\n\tif (v344) goto L_00B5;\n\tv257 = 0x20;\n\tv261 = 0;\n\tv313 = v62.Length;\n\tgoto L_0051;\nL_0044:\n\tv261 = v261 + 1;\n\tv257 = v257 + 8;\n\tv353 = v62.Length == v261;\n\tv313 = v357;\n\tv308 = v357;\n\tif (v353) goto L_0086;\nL_0051:\n\tv404 = v261 < v62.Length;\n\tv301 = ~v404;\n\tif (v301) goto L_00B8;\n\tv415 = *([v62 @ X24_v7 (System.Reflection.ParameterInfo[])+v257 @ X26_v11 (System.Int32)]) == 0;\n\tif (v415) goto L_00BE;\n\tv422 = System.Reflection.ParameterInfo::get_ParameterType(*([v62 @ X24_v7 (System.Reflection.ParameterInfo[])+v257 @ X26_v11 (System.Int32)]));\n\tv424 = Reflex.Core.Container::TryResolve(container, v422, &v248 @ stack_-70_v11 (System.Object));\n\tv426 = v424 == 0;\n\tv357 = v422;\n\tif (v426) goto L_0044;\n\tv328 = v205 == 0;\n\tif (v328) goto L_00A7;\n\tv484 = v248 == 0;\n\tv310 = v422;\n\tif (v484) goto L_0076;\n\tv487 = 0x21C11D0(v248, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv330 = v487 == 0;\n\tv310 = System.Object;\n\tif (v330) goto L_00AB;\nL_0076:\n\tv490 = v261 < v205.Length;\n\tv302 = ~v490;\n\tif (v302) goto L_00A9;\n\t*([v205 @ stack_-68_v7 (System.Object[])+v257 @ X26_v11 (System.Int32)]) = v248;\n\tv357 = v248;\n\tgoto L_0044;\nL_0086:\n\tv214 = v53.MethodInfo == 0;\n\tv108 = &v205 @ stack_-68_v7 (System.Object[]);\n\tv202 = 0;\n\tif (v214) goto L_00B2;\n\tv418 = System.Reflection.MethodBase::Invoke(v53.MethodInfo, instance, v205);\n\tv108 = &v205 @ stack_-68_v7 (System.Object[]);\n\tv133 = 0;\n\tReflex.Pooling.SizeSpecificArrayPool`1<System.Object>::Return(v123, *([v108 @ stack_-88_v1]));\n\tv483 = v133 == 0;\n\tv162 = ~v483;\n\tif (v162) goto L_00B1;\n\treturn;\nL_00A7:\n\tv219 = new System.NullReferenceException();\n\tv108 = &v205 @ stack_-68_v7 (System.Object[]);\n\tv202 = 0;\n\tv308 = v422;\n\tgoto L_0117;\nL_00A9:\n\tv322 = new System.IndexOutOfRangeException();\n\tv108 = &v205 @ stack_-68_v7 (System.Object[]);\n\tv202 = 0;\n\tv308 = v310;\n\tv219 = v322;\n\tgoto L_0117;\nL_00AB:\n\tv492 = new System.ArrayTypeMismatchException();\n\tthrow v492;\nL_00B1:\n\tv168 = new System.OutOfMemoryException();\n\tv108 = v152;\n\tv308 = v155;\nL_00B2:\n\tv219 = new System.NullReferenceException();\n\tgoto L_0117;\nL_00B5:\n\tv377 = v62.Length == 0;\n\tv378 = ~v377;\n\tv313 = v62.Length;\n\tif (v378) goto L_00BA;\nL_00B8:\n\tv324 = new System.IndexOutOfRangeException();\n\tv108 = &v205 @ stack_-68_v7 (System.Object[]);\n\tv202 = 0;\n\tv308 = v313;\n\tv219 = v324;\n\tgoto L_0117;\nL_00BA:\n\tv406 = v62[0];\n\tv407 = v62[0] == 0;\n\tv333 = ~v407;\n\tv313 = v62.Length;\n\tif (v333) goto L_00C0;\nL_00BE:\n\tv219 = new System.NullReferenceException();\n\tv108 = &v205 @ stack_-68_v7 (System.Object[]);\n\tv202 = 0;\n\tv308 = v313;\n\tgoto L_0117;\nL_00C0:\n\tv340 = *([v406 @ X0_v29 (System.Reflection.ParameterInfo)]);\n\tv308 = *([v340 @ X8_v18 (Il2CppClass<System.Reflection.ParameterInfo>)+1F0]);\n\tv417 = System.Reflection.ParameterInfo::get_ParameterType(v62[0]);\n\tv219 = new System.NullReferenceException();\n\tv108 = &v205 @ stack_-68_v7 (System.Object[]);\n\tv202 = 0;\n\tgoto L_0117;\nL_00E3:\n\tv373 = v308 != 1;\n\tif (v373) goto L_0123;\n\tv384 = 0x8BF5BC4(v219, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv133 = *([v384 @ X0_v11]);\n\tv418 = 0x8BF5BF4(v384, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_008D;\nL_0117:\n\t// 279 Interrupt\n\tgoto L_00E3;\n\treturn;\nL_0123:\n\tv386 = 0x3192A54(&v202 @ stack_-90_v4 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv413 = 0x8BF0368(v219, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv420 = 0xA1B8(v413, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_008D:\n\tv123 = Reflex.Injectors.MethodInjector::get_ArrayPool();\n")]
		public static void TryInject(InjectableMethodInfo optionalMethod, object instance, Container container)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MethodInjector::TryInject");
		}
	}
}
