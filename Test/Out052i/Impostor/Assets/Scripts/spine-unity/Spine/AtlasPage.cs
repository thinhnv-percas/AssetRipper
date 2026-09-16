using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200002E")]
	public class AtlasPage
	{
		[Token(Token = "0x4000105")]
		[FieldOffset(Offset = "0x10")]
		public string name;

		[Token(Token = "0x4000106")]
		[FieldOffset(Offset = "0x18")]
		public Format format;

		[Token(Token = "0x4000107")]
		[FieldOffset(Offset = "0x1C")]
		public TextureFilter minFilter;

		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0x20")]
		public TextureFilter magFilter;

		[Token(Token = "0x4000109")]
		[FieldOffset(Offset = "0x24")]
		public TextureWrap uWrap;

		[Token(Token = "0x400010A")]
		[FieldOffset(Offset = "0x28")]
		public TextureWrap vWrap;

		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x30")]
		public object rendererObject;

		[Token(Token = "0x400010C")]
		[FieldOffset(Offset = "0x38")]
		public int width;

		[Token(Token = "0x400010D")]
		[FieldOffset(Offset = "0x3C")]
		public int height;

		[Token(Token = "0x6000155")]
		[Address(RVA = "0x152DEB8", Offset = "0x152DEB8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = Spine.AtlasPage;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37B33]) = v33;\nL_0012:\n\tv36 = System.Object::MemberwiseClone(this);\n\tv37 = v36 == 0;\n\tif (v37) goto L_003E;\n\tgoto L_FFFFFFFF;\n\tgoto L_003E;\n\tv55 = v55_asT == 0;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_003E;\nL_003E:\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AtlasPage Clone()
		{
			object obj = MemberwiseClone();
			bool flag = obj == null;
			AtlasPage result = (AtlasPage)obj;
			if (!flag)
			{
				AtlasPage atlasPage = obj as AtlasPage;
				result = (AtlasPage)((atlasPage == null) ? null : obj);
			}
			return result;
		}

		[Token(Token = "0x6000156")]
		[Address(RVA = "0x152D9EC", Offset = "0x152D9EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AtlasPage()
		{
		}
	}
}
