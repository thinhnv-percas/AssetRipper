using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.InitializationSystem.Runtime
{
	[Token(Token = "0x2000004")]
	public static class Extensions
	{
		[Token(Token = "0x6000003")]
		[Address(RVA = "0x81AF834", Offset = "0x81AF834", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv48 = 0x21C11D0(obj, Unco.InitializationSystem.Runtime.IInitializable, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv59 = v48 == 0;\n\tif (v59) goto L_0062;\n\tv63 = 0x21C11D0(obj, Unco.InitializationSystem.Runtime.IInitializable, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv66 = v63 == 0;\n\tif (v66) goto L_0062;\n\tv150 = *([v63 @ X0_v10]);\n\tv178 = *([v150 @ X8_v3+12E]);\n\tv137 = *([v150 @ X8_v3+12E]) == 0;\n\tif (v137) goto L_0051;\n\tv122 = *([v150 @ X8_v3+B0]) + 8;\n\tv122 = v122 + 0x10;\n\tv164 = v178 - 1;\n\tv154 = v178 != 1;\n\tv178 = v164;\n\tif (v154) goto L_002F;\nL_0051:\n\tUnco.InitializationSystem.Runtime.IInitializable::InitializeSystem(v63);\nL_0051:\n\treturn;\nL_0053:\n\tv74 = *([v122 @ X10_v4]) << 4;\n\tv181 = v150 + v74;\n\tv140 = v181 + 0x138;\n\tv83 = *([v140 @ X8_v6]);\n\tv130 = *([v140 @ X8_v6+8]);\n\t// 95 IndirectJump v83 @ X2_v3, v63 @ X0_v10, v63 @ X0_v10, v130 @ X1_v8, v83 @ X2_v3, v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_0062:\n\tv53 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\nL_002F:\n\tv106 = *([v122 @ X10_v4-8]) == Unco.InitializationSystem.Runtime.IInitializable;\n\tif (v106) goto L_0053;\n")]
		public static void InitSystem(this object obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Extensions::InitSystem");
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x81AF920", Offset = "0x81AF920", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv48 = 0x21C11D0(obj, Unco.InitializationSystem.Runtime.IInitializable, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv59 = v48 == 0;\n\tif (v59) goto L_0063;\n\tv63 = 0x21C11D0(obj, Unco.InitializationSystem.Runtime.IInitializable, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv66 = v63 == 0;\n\tif (v66) goto L_0063;\n\tv150 = *([v63 @ X0_v10]);\n\tv178 = *([v150 @ X8_v3+12E]);\n\tv137 = *([v150 @ X8_v3+12E]) == 0;\n\tif (v137) goto L_0051;\n\tv122 = *([v150 @ X8_v3+B0]) + 8;\n\tv122 = v122 + 0x10;\n\tv164 = v178 - 1;\n\tv154 = v178 != 1;\n\tv178 = v164;\n\tif (v154) goto L_002F;\nL_0051:\n\tUnco.InitializationSystem.Runtime.IInitializable::DeInitialize(v63);\nL_0051:\n\treturn;\nL_0053:\n\tv126 = *([v122 @ X10_v4]) + 1;\n\tv74 = v126 << 4;\n\tv182 = v150 + v74;\n\tv140 = v182 + 0x138;\n\tv83 = *([v140 @ X8_v6]);\n\tv130 = *([v140 @ X8_v6+8]);\n\t// 96 IndirectJump v83 @ X2_v3, v63 @ X0_v10, v63 @ X0_v10, v130 @ X1_v8, v83 @ X2_v3, v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_0063:\n\tv53 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\nL_002F:\n\tv106 = *([v122 @ X10_v4-8]) == Unco.InitializationSystem.Runtime.IInitializable;\n\tif (v106) goto L_0053;\n")]
		public static void DeInitSystem(this object obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Extensions::DeInitSystem");
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x81AFA10", Offset = "0x81AFA10", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001C;\nL_001C:\n\tUnco.InitializationSystem.Runtime.InitializationManager::Listen(obj);\n\treturn;\n")]
		public static void Listen(this object obj)
		{
			InitializationManager.Listen(obj);
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x81AFB40", Offset = "0x81AFB40", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0014;\nL_0014:\n\tv49 = obj == 0;\n\tif (v49) goto L_0040;\n\tv66 = 0x21C11D0(obj, Unco.InitializationSystem.Runtime.IInitializable, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv80 = v66 == 0;\n\tif (v80) goto L_0044;\n\tUnco.InitializationSystem.Runtime.InitializationManager::TrackProcess(v66);\n\treturn;\nL_0040:\n\tUnco.InitializationSystem.Runtime.InitializationManager::TrackProcess(0);\n\treturn;\nL_0044:\n\tthrow System.InvalidCastException;\n")]
		public static void TrackProcess(this object obj)
		{
			if (obj != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				IInitializable initializable = default(IInitializable);
				if (initializable == null)
				{
					throw new InvalidCastException();
				}
				InitializationManager.TrackProcess(initializable);
			}
			else
			{
				InitializationManager.TrackProcess(null);
			}
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x81AFE08", Offset = "0x81AFE08", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001C;\nL_001C:\n\tUnco.InitializationSystem.Runtime.InitializationManager::KillListener(obj);\n\treturn;\n")]
		public static void Kill(this object obj)
		{
			InitializationManager.KillListener(obj);
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x4975780", Offset = "0x4975780", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = 0x220C2B8(methodInfo, obj, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0017:\n\tv44 = System.Collections.Generic.List`1<T>::Contains(list, obj);\n\tv57 = v44 == 0;\n\tif (v57) goto L_0026;\n\treturn;\nL_0026:\n\t;\n\tgoto L_0053;\nL_0053:\n\tSystem.Collections.Generic.List`1<T>::Add(list, obj);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddIfNotContains<T>(this List<T> list, T obj)
		{
			if (!list.Contains(obj))
			{
				list.Add(obj);
			}
		}
	}
}
