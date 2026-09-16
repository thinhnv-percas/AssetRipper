using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000037")]
	public class ClippingAttachment : VertexAttachment
	{
		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0x40")]
		internal SlotData endSlot;

		[Token(Token = "0x1700005D")]
		public SlotData EndSlot
		{
			[Token(Token = "0x6000172")]
			[Address(RVA = "0x152E688", Offset = "0x152E688", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.endSlot;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EndSlot;
			}
			[Token(Token = "0x6000173")]
			[Address(RVA = "0x152E690", Offset = "0x152E690", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.endSlot = value;\n\treturn;\n")]
			set
			{
				EndSlot = value;
			}
		}

		[Token(Token = "0x6000174")]
		[Address(RVA = "0x152E514", Offset = "0x152E514", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = Spine.VertexAttachment;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, name, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37B3D]) = v40;\nL_0019:\n\tgoto L_0024;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, name, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tSpine.VertexAttachment::.ctor(this, name);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ClippingAttachment(string name)
			: base(name)
		{
		}

		[Token(Token = "0x6000175")]
		[Address(RVA = "0x152E698", Offset = "0x152E698", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Spine.ClippingAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37B3E]) = v37;\nL_0015:\n\tv40 = new Spine.ClippingAttachment();\n\tSpine.ClippingAttachment::.ctor(v40, this.<Name>k__BackingField);\n\tSpine.VertexAttachment::CopyTo(this, v40);\n\tv40.endSlot = this.endSlot;\n\treturn v40;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Attachment Copy()
		{
			ClippingAttachment clippingAttachment = new ClippingAttachment(Name);
			CopyTo(clippingAttachment);
			clippingAttachment.EndSlot = EndSlot;
			return clippingAttachment;
		}
	}
}
