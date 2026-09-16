using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000036")]
	public class BoundingBoxAttachment : VertexAttachment
	{
		[Token(Token = "0x6000170")]
		[Address(RVA = "0x152E39C", Offset = "0x152E39C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = Spine.VertexAttachment;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, name, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37B3B]) = v40;\nL_0019:\n\tgoto L_0024;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, name, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tSpine.VertexAttachment::.ctor(this, name);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoundingBoxAttachment(string name)
			: base(name)
		{
		}

		[Token(Token = "0x6000171")]
		[Address(RVA = "0x152E61C", Offset = "0x152E61C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Spine.BoundingBoxAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37B3C]) = v37;\nL_0015:\n\tv40 = new Spine.BoundingBoxAttachment();\n\tSpine.BoundingBoxAttachment::.ctor(v40, this.<Name>k__BackingField);\n\tSpine.VertexAttachment::CopyTo(this, v40);\n\treturn v40;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Attachment Copy()
		{
			BoundingBoxAttachment boundingBoxAttachment = new BoundingBoxAttachment(Name);
			CopyTo(boundingBoxAttachment);
			return boundingBoxAttachment;
		}
	}
}
