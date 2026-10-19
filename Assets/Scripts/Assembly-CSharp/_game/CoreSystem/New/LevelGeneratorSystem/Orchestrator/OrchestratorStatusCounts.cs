using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator
{
	[Token(Token = "0x2000366")]
	public struct OrchestratorStatusCounts
	{
		[Token(Token = "0x4000A24")]
		[FieldOffset(Offset = "0x0")]
		public int queued;

		[Token(Token = "0x4000A25")]
		[FieldOffset(Offset = "0x4")]
		public int generating;

		[Token(Token = "0x4000A26")]
		[FieldOffset(Offset = "0x8")]
		public int saved;

		[Token(Token = "0x4000A27")]
		[FieldOffset(Offset = "0xC")]
		public int failed;

		[Token(Token = "0x6000E0E")]
		[Address(RVA = "0x3F03128", Offset = "0x3F03128", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = chip > 1;\n\tif (v12) goto L_0020;\n\tv13 = chip == 0;\n\tif (v13) goto L_0035;\n\tv32 = chip != 1;\n\tif (v32) goto L_0037;\n\tv33 = v33 + 4;\n\tgoto L_0035;\nL_0020:\n\tv18 = chip == 2;\n\tif (v18) goto L_0033;\n\tv41 = chip != 3;\n\tif (v41) goto L_0037;\n\tv33 = v33 + 0xC;\n\tgoto L_0035;\nL_0033:\n\tv33 = v33 + 8;\nL_0035:\n\tv59 = v33.queued + 1;\n\tv33.queued = v59;\nL_0037:\n\treturn;\n")]
		public void Add(OrchestratorChip chip)
		{
			switch (chip)
			{
			case OrchestratorChip.Generating:
				System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 4);
				break;
			case OrchestratorChip.Failed:
				System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 12);
				break;
			case OrchestratorChip.Saved:
				System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8);
				break;
			case OrchestratorChip.Queued:
				break;
			default:
				return;
			}
			int num = queued + 1;
			queued = num;
		}

		[Token(Token = "0x6000E0F")]
		[Address(RVA = "0x3F03170", Offset = "0x3F03170", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\treturnVal1 = System.String::Format(\"{0} failed · {1} queued · {2} generating\", v54, v60, v66);\n\treturn returnVal1;\nL_0019:\n\tv49 = this.failed;\n\tv51 = 0xB7D5000 + 0x538;\n\tv54 = \"il2cpp_vm_object_box\"(*([v51 @ X23_v2 (System.Int32)+48]), &v49 @ stack_-44_v1 (System.Int32), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv57 = this.queued;\n\tv60 = \"il2cpp_vm_object_box\"(*([v51 @ X23_v2 (System.Int32)+48]), &v57 @ stack_-48_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv63 = this.generating;\n\tv66 = \"il2cpp_vm_object_box\"(*([v51 @ X23_v2 (System.Int32)+48]), &v63 @ stack_-4C_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
		public string ToDetailString()
		{
			int num = failed;
			int num2 = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			int num3 = queued;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			int num4 = generating;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			object arg2 = default(object);
			object arg3 = default(object);
			return $"{arg} failed · {arg2} queued · {arg3} generating";
		}
	}
}
