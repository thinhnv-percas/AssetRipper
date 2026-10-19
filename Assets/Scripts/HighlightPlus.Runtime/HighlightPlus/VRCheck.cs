using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.XR;

namespace HighlightPlus
{
	[Token(Token = "0x2000041")]
	internal static class VRCheck
	{
		[Token(Token = "0x40003B3")]
		public static bool isActive;

		[Token(Token = "0x40003B4")]
		public static bool isVrRunning;

		[Token(Token = "0x40003B5")]
		private static readonly List<XRDisplaySubsystemDescriptor> displaysDescs;

		[Token(Token = "0x40003B6")]
		private static readonly List<XRDisplaySubsystem> displays;

		[Token(Token = "0x600013F")]
		[Address(RVA = "0x7734304", Offset = "0x7734304", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tgoto L_0014;\nL_0014:\n\tv118 = v47.displaysDescs;\n\tv49 = v47.displaysDescs == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_0039;\n\tgoto L_0075;\nL_0039:\n\t;\n\tSystem.Collections.Generic.List`1<UnityEngine.XR.XRDisplaySubsystemDescriptor>::Clear(v118);\n\tv81 = v118.Count < 1;\n\tif (v81) goto L_0055;\n\tv118 = v126.displaysDescs;\nL_0059:\n\tUnityEngine.SubsystemManager::GetSubsystemDescriptors(v118);\n\tv116 = v184.displaysDescs;\n\tv164 = v116.Count < 0;\n\tv162 = v116.Count == 0;\n\tv158 = v116.Count ^ v116.Count;\n\tv156 = v116.Count & v158;\n\tv154 = v156 < 0;\n\tv188 = v164 == v154;\n\tv147 = ~v162;\n\tv152 = v188 & v147;\n\treturn v152;\nL_0075:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0055:\n\tgoto L_0059;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool IsActive()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VRCheck::IsActive");
			return default;
		}

		[Token(Token = "0x6000140")]
		[Address(RVA = "0x7734434", Offset = "0x7734434", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv50 = 0;\n\tgoto L_0017;\nL_0017:\n\tv162 = v56.displays;\n\tv58 = v56.displays == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0048;\nL_FFFFFFFF:\n\tv105 = 0;\n\tgoto L_009D;\nL_0048:\n\t;\n\tSystem.Collections.Generic.List`1<UnityEngine.XR.XRDisplaySubsystem>::Clear(v162);\n\tv96 = v162.Count < 1;\n\tif (v96) goto L_0064;\n\tv162 = v170.displays;\nL_0068:\n\tUnityEngine.SubsystemManager::GetSubsystems(v162);\n\tv154 = v159.displays == 0;\nL_FFFFFFFF:\n\t;\n\tif (v154) goto L_009D;\n\tv222 = System.Collections.Generic.List`1<UnityEngine.XR.XRDisplaySubsystem>::GetEnumerator(v159.displays);\n\tv151 = v222._list;\n\tv238 = UnityEngine.IntegratedSubsystem::get_running(v222.Current);\n\tv240 = v238 == 0;\n\tif (v240) goto L_0082;\nL_0091:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v151 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.XR.XRDisplaySubsystem>));\nL_FFFFFFFF:\n\tv278 = v243;\nL_009A:\n\treturn v278;\nL_00AA:\n\tv197 = Il2CppMethodInfo != 1;\nL_FFFFFFFF:\n\tv212 = v163;\n\tif (v197) goto L_00BA;\n\tv203 = 0x8BF5BC4(v163, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv278 = *([v203 @ X0_v10]);\n\tv227 = 0x8BF5BF4(v203, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v50 @ stack_-48_v7 (System.Int32));\n\tv211 = ~*([v203 @ X0_v10]);\n\tif (v211) goto L_009A;\n\tv209 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv105 = *([v203 @ X0_v10]);\nL_FFFFFFFF:\n\tv212 = v209;\n\treturn returnVal1;\nL_009D:\n\tv163 = new System.NullReferenceException();\n\tgoto L_00AA;\nL_0064:\n\tgoto L_0068;\nL_0082:\n\tv243 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v151 @ stack_-48_v4 (System.Collections.Generic.List`1<UnityEngine.XR.XRDisplaySubsystem>));\n\tv247 = v243 == 0;\n\tif (v247) goto L_0091;\nL_00BA:\n\tv215 = 0x359B514(&v105 @ stack_-58_v1 (System.Boolean), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv229 = 0x8BF0368(v212, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0xA1B8(v229, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static bool IsVrRunning()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VRCheck::IsVrRunning");
			return default;
		}

		[Token(Token = "0x6000141")]
		[Address(RVA = "0x772CDAC", Offset = "0x772CDAC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0019:\n\tv45 = HighlightPlus.VRCheck::IsActive();\n\tv47.isActive = v45;\n\tv48 = HighlightPlus.VRCheck::IsVrRunning();\n\tv50.isVrRunning = v48;\n\treturn;\nL_0017:\n\tgoto L_0019;\n")]
		public static void Init()
		{
			bool flag = IsActive();
			isActive = flag;
			bool flag2 = IsVrRunning();
			isVrRunning = flag2;
		}

		[Token(Token = "0x6000142")]
		[Address(RVA = "0x7734658", Offset = "0x7734658", Length = "0x2D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv75 = new System.Collections.Generic.List`1<UnityEngine.XR.XRDisplaySubsystem>();\n\tSystem.Collections.Generic.List`1<UnityEngine.XR.XRDisplaySubsystem>::.ctor(v75);\n\tv81.displays = v75;\n\treturn;\nL_002C:\n\tv57 = new System.Collections.Generic.List`1<UnityEngine.XR.XRDisplaySubsystemDescriptor>();\n\tSystem.Collections.Generic.List`1<UnityEngine.XR.XRDisplaySubsystemDescriptor>::.ctor(v57);\n\tv67.displaysDescs = v57;\n")]
		static VRCheck()
		{
			List<XRDisplaySubsystemDescriptor> list = new List<XRDisplaySubsystemDescriptor>();
			displaysDescs = list;
			List<XRDisplaySubsystem> list2 = new List<XRDisplaySubsystem>();
			displays = list2;
		}
	}
}
