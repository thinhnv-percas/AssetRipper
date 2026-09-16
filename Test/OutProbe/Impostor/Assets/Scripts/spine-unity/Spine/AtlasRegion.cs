using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200002F")]
	public class AtlasRegion
	{
		[Token(Token = "0x400010E")]
		[FieldOffset(Offset = "0x10")]
		public AtlasPage page;

		[Token(Token = "0x400010F")]
		[FieldOffset(Offset = "0x18")]
		public string name;

		[Token(Token = "0x4000110")]
		[FieldOffset(Offset = "0x20")]
		public int x;

		[Token(Token = "0x4000111")]
		[FieldOffset(Offset = "0x24")]
		public int y;

		[Token(Token = "0x4000112")]
		[FieldOffset(Offset = "0x28")]
		public int width;

		[Token(Token = "0x4000113")]
		[FieldOffset(Offset = "0x2C")]
		public int height;

		[Token(Token = "0x4000114")]
		[FieldOffset(Offset = "0x30")]
		public float u;

		[Token(Token = "0x4000115")]
		[FieldOffset(Offset = "0x34")]
		public float v;

		[Token(Token = "0x4000116")]
		[FieldOffset(Offset = "0x38")]
		public float u2;

		[Token(Token = "0x4000117")]
		[FieldOffset(Offset = "0x3C")]
		public float v2;

		[Token(Token = "0x4000118")]
		[FieldOffset(Offset = "0x40")]
		public float offsetX;

		[Token(Token = "0x4000119")]
		[FieldOffset(Offset = "0x44")]
		public float offsetY;

		[Token(Token = "0x400011A")]
		[FieldOffset(Offset = "0x48")]
		public int originalWidth;

		[Token(Token = "0x400011B")]
		[FieldOffset(Offset = "0x4C")]
		public int originalHeight;

		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0x50")]
		public int index;

		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0x54")]
		public bool rotate;

		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0x58")]
		public int degrees;

		[Token(Token = "0x400011F")]
		[FieldOffset(Offset = "0x60")]
		public int[] splits;

		[Token(Token = "0x4000120")]
		[FieldOffset(Offset = "0x68")]
		public int[] pads;

		[Token(Token = "0x6000157")]
		[Address(RVA = "0x152DF3C", Offset = "0x152DF3C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = Spine.AtlasRegion;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37B34]) = v33;\nL_0012:\n\tv36 = System.Object::MemberwiseClone(this);\n\tv37 = v36 == 0;\n\tif (v37) goto L_003E;\n\tgoto L_FFFFFFFF;\n\tgoto L_003E;\n\tv55 = v55_asT == 0;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_003E;\nL_003E:\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AtlasRegion Clone()
		{
			object obj = MemberwiseClone();
			bool flag = obj == null;
			AtlasRegion result = (AtlasRegion)obj;
			if (!flag)
			{
				AtlasRegion atlasRegion = obj as AtlasRegion;
				result = (AtlasRegion)((atlasRegion == null) ? null : obj);
			}
			return result;
		}

		[Token(Token = "0x6000158")]
		[Address(RVA = "0x152DC00", Offset = "0x152DC00", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AtlasRegion()
		{
		}
	}
}
