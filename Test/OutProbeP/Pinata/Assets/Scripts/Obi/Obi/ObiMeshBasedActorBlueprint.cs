using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000019")]
	public abstract class ObiMeshBasedActorBlueprint : ObiActorBlueprint
	{
		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x100")]
		public Mesh inputMesh;

		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x108")]
		public Vector3 scale;

		[Token(Token = "0x60001E2")]
		[Address(RVA = "0xE47368", Offset = "0xE47368", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEE890]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024764]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = UnityEngine.Vector3::get_one();\n\tthis.scale.x = v53;\n\tthis.scale.y = v53.y;\n\tthis.scale.z = v53.z;\n\tObi.ObiActorBlueprint::.ctor(this);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected ObiMeshBasedActorBlueprint()
		{
			Vector3 one = Vector3.one;
			scale.x = one.x;
			scale.y = one.y;
			scale.z = one.z;
		}
	}
}
