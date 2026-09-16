using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000039")]
	public class PathAttachment : VertexAttachment
	{
		[Token(Token = "0x4000146")]
		[FieldOffset(Offset = "0x40")]
		internal float[] lengths;

		[Token(Token = "0x4000147")]
		[FieldOffset(Offset = "0x48")]
		internal bool closed;

		[Token(Token = "0x4000148")]
		[FieldOffset(Offset = "0x49")]
		internal bool constantSpeed;

		[Token(Token = "0x17000078")]
		public float[] Lengths
		{
			[Token(Token = "0x60001AE")]
			[Address(RVA = "0x152EF54", Offset = "0x152EF54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.lengths;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Lengths;
			}
			[Token(Token = "0x60001AF")]
			[Address(RVA = "0x152EF5C", Offset = "0x152EF5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.lengths = value;\n\treturn;\n")]
			set
			{
				Lengths = value;
			}
		}

		[Token(Token = "0x17000079")]
		public bool Closed
		{
			[Token(Token = "0x60001B0")]
			[Address(RVA = "0x152EF64", Offset = "0x152EF64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.closed;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Closed;
			}
			[Token(Token = "0x60001B1")]
			[Address(RVA = "0x152EF6C", Offset = "0x152EF6C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.closed = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				closed = value;
			}
		}

		[Token(Token = "0x1700007A")]
		public bool ConstantSpeed
		{
			[Token(Token = "0x60001B2")]
			[Address(RVA = "0x152EF78", Offset = "0x152EF78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.constantSpeed;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ConstantSpeed;
			}
			[Token(Token = "0x60001B3")]
			[Address(RVA = "0x152EF80", Offset = "0x152EF80", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.constantSpeed = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				constantSpeed = value;
			}
		}

		[Token(Token = "0x60001B4")]
		[Address(RVA = "0x152EF8C", Offset = "0x152EF8C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = Spine.VertexAttachment;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, name, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37B43]) = v40;\nL_0019:\n\tgoto L_0023;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, name, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\tSpine.VertexAttachment::.ctor(this, name);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PathAttachment(string name)
			: base(name)
		{
		}

		[Token(Token = "0x60001B5")]
		[Address(RVA = "0x152F128", Offset = "0x152F128", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = Spine.PathAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = System.Single[];\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37B44]) = v38;\nL_0018:\n\tv41 = new Spine.PathAttachment();\n\tSpine.PathAttachment::.ctor(v41, this.<Name>k__BackingField);\n\tSpine.VertexAttachment::CopyTo(this, v41);\n\tv48 = this.lengths;\n\t// 38 NewArr v54 @ X0_v8 (System.Single[]), typeof(System.Single[]), v48.Length\n\tv41.lengths = v54;\n\tv61 = this.lengths;\n\tSystem.Array::Copy(this.lengths, 0, v54, 0, *([v61 @ X0_v9 (System.Array)+18]));\n\tv41.closed = this.closed;\n\tv41.constantSpeed = this.constantSpeed;\n\treturn v41;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override Attachment Copy()
		{
			PathAttachment pathAttachment = new PathAttachment(Name);
			CopyTo(pathAttachment);
			float[] array = Lengths;
			float[] destinationArray = (pathAttachment.Lengths = new float[array.Length]);
			Array array3 = Lengths;
			float[] sourceArray = Lengths;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X0_v9 (System.Array)+18]");
			Array.Copy(sourceArray, 0, destinationArray, 0, 0);
			pathAttachment.closed = Closed;
			pathAttachment.constantSpeed = ConstantSpeed;
			return pathAttachment;
		}
	}
}
