using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.PostProcess
{
	[Token(Token = "0x2000347")]
	public sealed class WallTrapRepairPlan
	{
		[Token(Token = "0x40009AE")]
		[FieldOffset(Offset = "0x10")]
		public readonly List<GridCoord> Adds;

		[Token(Token = "0x40009AF")]
		[FieldOffset(Offset = "0x18")]
		public readonly List<GridCoord> Removes;

		[Token(Token = "0x40009B0")]
		[FieldOffset(Offset = "0x20")]
		public readonly List<GridCoord> Unresolved;

		[Token(Token = "0x6000DDC")]
		[Address(RVA = "0x3EFE258", Offset = "0x3EFE258", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Adds = adds;\n\tthis.Removes = removes;\n\tthis.Unresolved = unresolved;\n\treturn;\n")]
		public WallTrapRepairPlan(List<GridCoord> adds, List<GridCoord> removes, List<GridCoord> unresolved)
		{
			Adds = adds;
			Removes = removes;
			Unresolved = unresolved;
		}

		[Token(Token = "0x6000DDD")]
		[Address(RVA = "0x3EFE2BC", Offset = "0x3EFE2BC", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv48 = v43.Count;\n\tv50 = 0xB7D5000 + 0x538;\n\tv53 = \"il2cpp_vm_object_box\"(*([v50 @ X22_v3 (System.Int32)+48]), &v48 @ stack_-34_v2 (System.Int32), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv68 = this.Removes;\n\tv56 = v68.Count;\n\tv63 = \"il2cpp_vm_object_box\"(*([v50 @ X22_v3 (System.Int32)+48]), &v56 @ stack_-38_v2 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv69 = this.Unresolved;\n\tv84 = v69.Count;\n\tv110 = \"il2cpp_vm_object_box\"(*([v50 @ X22_v3 (System.Int32)+48]), &v84 @ stack_-3C_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = System.String::Format(\"added={0} removed={1} unresolved={2}\", v53, v63, v110);\n\treturn returnVal2;\nL_0017:\n\tv43 = this.Adds;\n")]
		public override string ToString()
		{
			List<GridCoord> adds = Adds;
			int count = adds.Count;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			List<GridCoord> removes = Removes;
			int count2 = removes.Count;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			List<GridCoord> unresolved = Unresolved;
			int count3 = unresolved.Count;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			object arg2 = default(object);
			object arg3 = default(object);
			return $"added={arg} removed={arg2} unresolved={arg3}";
		}
	}
}
