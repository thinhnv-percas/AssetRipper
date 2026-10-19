using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.PostProcess
{
	[Token(Token = "0x200033A")]
	public sealed class WallDrainageRepairResult
	{
		[Token(Token = "0x4000998")]
		[FieldOffset(Offset = "0x10")]
		public readonly List<GridCoord> Adds;

		[Token(Token = "0x4000999")]
		[FieldOffset(Offset = "0x18")]
		public readonly List<GridCoord> Removes;

		[Token(Token = "0x400099A")]
		[FieldOffset(Offset = "0x20")]
		public readonly int Unresolved;

		[Token(Token = "0x17000105")]
		public int MoveCount
		{
			[Token(Token = "0x6000DBB")]
			[Address(RVA = "0x3EF9A44", Offset = "0x3EF9A44", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv40 = this.Removes;\n\treturnVal1 = v40.Count + v38.Count;\n\treturn returnVal1;\nL_0012:\n\tv38 = this.Adds;\n")]
			get
			{
				List<GridCoord> adds = Adds;
				List<GridCoord> removes = Removes;
				return removes.Count + adds.Count;
			}
		}

		[Token(Token = "0x17000106")]
		public bool Solved
		{
			[Token(Token = "0x6000DBC")]
			[Address(RVA = "0x3EF9780", Offset = "0x3EF9780", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.Unresolved == 0;\n\treturn v6;\n")]
			get
			{
				return Unresolved == 0;
			}
		}

		[Token(Token = "0x6000DBA")]
		[Address(RVA = "0x3EF99E8", Offset = "0x3EF99E8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Adds = adds;\n\tthis.Removes = removes;\n\tthis.Unresolved = unresolved;\n\treturn;\n")]
		public WallDrainageRepairResult(List<GridCoord> adds, List<GridCoord> removes, int unresolved)
		{
			Adds = adds;
			Removes = removes;
			Unresolved = unresolved;
		}

		[Token(Token = "0x6000DBD")]
		[Address(RVA = "0x3EF9AA0", Offset = "0x3EF9AA0", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv52 = v47.Count;\n\tv54 = 0xB7D5000 + 0x538;\n\tv57 = \"il2cpp_vm_object_box\"(*([v54 @ X22_v3 (System.Int32)+48]), &v52 @ stack_-44_v2 (System.Int32), v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv66 = this.Removes;\n\tv72 = v66.Count;\n\tv75 = \"il2cpp_vm_object_box\"(*([v54 @ X22_v3 (System.Int32)+48]), &v72 @ stack_-48_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv87 = this.Unresolved;\n\tv114 = \"il2cpp_vm_object_box\"(*([v54 @ X22_v3 (System.Int32)+48]), &v87 @ stack_-4C_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = System.String::Format(\"added={0} removed={1} unresolved={2}\", v57, v75, v114);\n\treturn returnVal2;\nL_0019:\n\tv47 = this.Adds;\n")]
		public override string ToString()
		{
			List<GridCoord> adds = Adds;
			int count = adds.Count;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			List<GridCoord> removes = Removes;
			int count2 = removes.Count;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			int unresolved = Unresolved;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			object arg2 = default(object);
			object arg3 = default(object);
			return $"added={arg} removed={arg2} unresolved={arg3}";
		}
	}
}
