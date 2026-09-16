using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000058")]
	public class Polygon
	{
		[Token(Token = "0x1700011B")]
		public float[] Vertices
		{
			[CompilerGenerated]
			[Token(Token = "0x6000395")]
			[Address(RVA = "0x153E388", Offset = "0x153E388", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Vertices>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Vertices;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000396")]
			[Address(RVA = "0x153E390", Offset = "0x153E390", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Vertices>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Vertices = value;
			}
		}

		[Token(Token = "0x1700011C")]
		public int Count
		{
			[CompilerGenerated]
			[Token(Token = "0x6000397")]
			[Address(RVA = "0x153E398", Offset = "0x153E398", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Count>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Count;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000398")]
			[Address(RVA = "0x153E3A0", Offset = "0x153E3A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Count>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Count = value;
			}
		}

		[Token(Token = "0x6000399")]
		[Address(RVA = "0x153DBA8", Offset = "0x153DBA8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = System.Single[];\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37B93]) = v37;\nL_0015:\n\tSystem.Object::.ctor(this);\n\t// 24 NewArr v42 @ X0_v4 (System.Single[]), typeof(System.Single[]), 16\n\tthis.<Vertices>k__BackingField = v42;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Polygon()
		{
			float[] vertices = new float[16];
			Vertices = vertices;
		}
	}
}
