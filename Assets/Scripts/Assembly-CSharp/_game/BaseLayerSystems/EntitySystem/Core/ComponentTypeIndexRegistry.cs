using System;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.BaseLayerSystems.EntitySystem.Core
{
	[Token(Token = "0x2000071")]
	internal static class ComponentTypeIndexRegistry
	{
		[Token(Token = "0x4000112")]
		private static readonly object _lock;

		[Token(Token = "0x4000113")]
		private static int _nextId;

		[Token(Token = "0x17000045")]
		public unsafe static int Count
		{
			[Token(Token = "0x60001AC")]
			[Address(RVA = "0x3C6EFB0", Offset = "0x3C6EFB0", Length = "0x128")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_003D:\n\tv111 = &v48 @ stack_-28_v1 (System.Object);\n\tSystem.Threading.Monitor::Exit(*([v111 @ X8_v15]));\n\tv100 = 0;\n\tv126 = v105;\n\tv128 = v109;\nL_0041:\n\tv129 = v126 == 0;\n\tv104 = ~v129;\n\tif (v104) goto L_004C;\n\treturn v128;\nL_004C:\n\tv136 = new System.OutOfMemoryException();\n\tv82 = v100 != 1;\n\tif (v82) goto L_006E;\n\tv163 = 0x8BF5BC4(v136, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv105 = *([v163 @ X0_v16]);\n\tv102 = 0x8BF5BF4(v163, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv168 = &v49 @ stack_-29_v1 (System.Boolean);\n\tv92 = *([v168 @ X8_v12]) == 1;\n\tv79 = *([v163 @ X0_v16]);\n\tv109 = 0;\n\tif (v92) goto L_003D;\n\tv79 = *([v163 @ X0_v16]);\n\tv126 = *([v163 @ X0_v16]);\n\tv128 = 0;\n\tgoto L_0041;\n\treturn returnVal2;\nL_0017:\n\tgoto L_001C;\nL_002F:\n\tv109 = v65._nextId;\n\tv78 = v49.m_value != 1;\n\tv79 = 0;\n\tv105 = 0;\n\tv79 = 0;\n\tv100 = &v49 @ stack_-29_v1 (System.Boolean);\n\tv126 = 0;\n\tv128 = v65._nextId;\n\tif (v78) goto L_0041;\nL_006E:\n\tv165 = 0x3173B6C(&v79 @ stack_-48_v4 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv167 = 0x8BF0368(v136, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v167, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001C:\n\tv48 = v46._lock;\n\tv49 = 0;\n\tSystem.Threading.Monitor::Enter(v46._lock, &v49 @ stack_-29_v1 (System.Boolean));\n\tgoto L_002F;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ComponentTypeIndexRegistry::get_Count");
				return default;
			}
		}

		[Token(Token = "0x60001AD")]
		[Address(RVA = "0x3C6F0D8", Offset = "0x3C6F0D8", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_003F:\n\tv112 = &v48 @ stack_-28_v1 (System.Object);\n\tSystem.Threading.Monitor::Exit(*([v112 @ X8_v15]));\n\tv101 = 0;\n\tv127 = v106;\n\tv129 = v110;\nL_0043:\n\tv130 = v127 == 0;\n\tv105 = ~v130;\n\tif (v105) goto L_004E;\n\treturn v129;\nL_004E:\n\tv137 = new System.OutOfMemoryException();\n\tv83 = v101 != 1;\n\tif (v83) goto L_0070;\n\tv164 = 0x8BF5BC4(v137, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv106 = *([v164 @ X0_v16]);\n\tv103 = 0x8BF5BF4(v164, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv169 = &v49 @ stack_-29_v1 (System.Boolean);\n\tv93 = *([v169 @ X8_v12]) == 1;\n\tv80 = *([v164 @ X0_v16]);\n\tv110 = 0;\n\tif (v93) goto L_003F;\n\tv80 = *([v164 @ X0_v16]);\n\tv127 = *([v164 @ X0_v16]);\n\tv129 = 0;\n\tgoto L_0043;\n\treturn returnVal2;\nL_0017:\n\tgoto L_001C;\nL_002F:\n\tv110 = v65._nextId;\n\tv67 = v65._nextId + 1;\n\tv65._nextId = v67;\n\tv79 = v49.m_value != 1;\n\tv80 = 0;\n\tv106 = 0;\n\tv80 = 0;\n\tv101 = &v49 @ stack_-29_v1 (System.Boolean);\n\tv127 = 0;\n\tv129 = v65._nextId;\n\tif (v79) goto L_0043;\nL_0070:\n\tv166 = 0x3173B6C(&v80 @ stack_-48_v4 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv168 = 0x8BF0368(v137, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v168, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001C:\n\tv48 = v46._lock;\n\tv49 = 0;\n\tSystem.Threading.Monitor::Enter(v46._lock, &v49 @ stack_-29_v1 (System.Boolean));\n\tgoto L_002F;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static int Allocate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentTypeIndexRegistry::Allocate");
			return default;
		}

		[Token(Token = "0x60001AE")]
		[Address(RVA = "0x3C6F208", Offset = "0x3C6F208", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\treturn;\nL_001B:\n\tv47 = new System.Object();\n\tSystem.Object::.ctor(v47);\n\tv53._lock = v47;\n")]
		static ComponentTypeIndexRegistry()
		{
			object obj = new object();
			_lock = obj;
		}
	}
}
