using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x74180C", Offset = "0x74180C")]
	[Token(Token = "0x200000D")]
	public class InlineEditorAttribute : Attribute
	{
		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x10")]
		public bool Expanded;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x11")]
		public bool DrawHeader;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x12")]
		public bool DrawGUI;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x13")]
		public bool DrawPreview;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x14")]
		public float PreviewWidth;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x18")]
		public float PreviewHeight;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x1C")]
		public bool IncrementInlineEditorDrawerDepth;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x20")]
		public InlineEditorObjectFieldModes ObjectFieldMode;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x24")]
		public bool DisableGUIForVCSLockedAssets;

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x167F150", Offset = "0x167F150", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv25 = *([1EFB4C0]);\n\tv26 = *([v25 @ X8_v14]);\n\tv27 = \"il2cpp_codegen_initialize_method\"(v26, inlineEditorMode, objectFieldMode, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202B572]) = v43;\nL_001C:\n\tthis.PreviewWidth = 100f;\n\tthis.IncrementInlineEditorDrawerDepth = 1;\n\tthis.DisableGUIForVCSLockedAssets = 1;\n\tSystem.Attribute::.ctor(this);\n\tv49 = inlineEditorMode < 5;\n\tv50 = ~v49;\n\tv51 = inlineEditorMode - 5;\n\tv53 = v51 == 0;\n\tthis.ObjectFieldMode = objectFieldMode;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_0055;\n\tv62 = 0x1866000 + 0x564;\n\tv64 = *([v62 @ X9_v3 (System.Int32)+inlineEditorMode @ X1 (Sirenix.OdinInspector.InlineEditorModes)*4]) + v62;\n\t// 50 IndirectJump v64 @ X8_v11, this @ X0 (Sirenix.OdinInspector.InlineEditorAttribute), this @ X0 (Sirenix.OdinInspector.InlineEditorAttribute), 0, objectFieldMode @ X2 (Sirenix.OdinInspector.InlineEditorObjectFieldModes), methodInfo @ X3 (Il2CppMethodInfo), v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tX8 = 0 | 1;\n\t*([X19+12]) = X8;\n\tgoto L_004A;\n\tX8 = 0x101;\n\t*([X19+12]) = X8;\n\tgoto L_004A;\n\tX8 = 0 | 1;\n\t*([X19+10]) = X8;\n\t*([X19+13]) = X8;\n\t*([X19+18]) = X9;\n\tgoto L_004A;\n\tX8 = 0x101;\n\t*([X19+11]) = X8;\n\tgoto L_004A;\n\tX8 = 0 | 1;\n\t*([X19+10]) = X8;\n\t*([X19+13]) = X8;\n\tgoto L_004A;\n\tX8 = 0x101;\n\tX9 = 0 | 1;\n\t*([X19+11]) = X8;\n\t*([X19+13]) = X9;\nL_004A:\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX22 = stack[0];\n\tX21 = stack[8];\n\t// 80 ShiftStack 48\n\treturn;\nL_0055:\n\tv68 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v68);\n\tthrow v68;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InlineEditorAttribute(InlineEditorModes inlineEditorMode = InlineEditorModes.GUIOnly, InlineEditorObjectFieldModes objectFieldMode = InlineEditorObjectFieldModes.Boxed)
		{
			//IL_002f: Expected O, but got I
			base._002Ector();
			PreviewWidth = 100f;
			IncrementInlineEditorDrawerDepth = true;
			DisableGUIForVCSLockedAssets = true;
			bool flag = inlineEditorMode < InlineEditorModes.FullEditor;
			bool flag2 = !flag;
			int num = (int)(inlineEditorMode - 5);
			bool flag3 = num == 0;
			ObjectFieldMode = objectFieldMode;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25583616 + 1380;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X9_v3 (System.Int32)+inlineEditorMode @ X1 (Sirenix.OdinInspector.InlineEditorModes)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v64 @ X8_v11 (should have been resolved before IL gen)");
			}
			NotImplementedException ex = new NotImplementedException();
			throw ex;
		}
	}
}
