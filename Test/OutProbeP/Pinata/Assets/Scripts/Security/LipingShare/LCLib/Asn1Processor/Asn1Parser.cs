using System;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LipingShare.LCLib.Asn1Processor
{
	[Token(Token = "0x2000020")]
	internal class Asn1Parser
	{
		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x10")]
		private byte[] rawData;

		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x18")]
		private Asn1Node rootNode;

		[Token(Token = "0x1700003A")]
		public Asn1Node RootNode
		{
			[Token(Token = "0x60000AC")]
			[Address(RVA = "0x15D1980", Offset = "0x15D1980", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rootNode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RootNode;
			}
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x15D17FC", Offset = "0x15D17FC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDFA48]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029A0C]) = v38;\nL_0016:\n\tv42 = new LipingShare.LCLib.Asn1Processor.Asn1Node();\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::.ctor(v42);\n\tthis.rootNode = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Asn1Parser()
		{
			Asn1Node asn1Node = new Asn1Node();
			rootNode = asn1Node;
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x15D1860", Offset = "0x15D1860", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1F025C0]);\n\tv23 = *([v22 @ X8_v21]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, stream, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029A0D]) = v41;\nL_0017:\n\t;\n\tv48 = System.IO.Stream::set_Position(stream, 0);\n\tv66 = LipingShare.LCLib.Asn1Processor.Asn1Node::LoadData(this.rootNode, stream);\n\tv75 = v66 == 0;\n\tif (v75) goto L_004C;\n\tv90 = System.IO.Stream::get_Length(stream);\n\t// 47 NewArr v96 @ X0_v18 (System.Byte[]), typeof(System.Byte[]), v90 @ X0_v16 (System.Int64)\n\tthis.rawData = v96;\n\tv59 = System.IO.Stream::set_Position(stream, 0);\n\tv57 = this.rawData;\n\tv110 = stream->klass;\n\tv111 = v57.Length;\n\tv115 = stream->klass->vtable[27];\n\tv116 = stream->klass->vtable[27];\n\t// 70 IndirectJump v115 @ X5_v1, stream @ X1 (System.IO.Stream), stream @ X1 (System.IO.Stream), v57 @ X1_v11 (System.Byte[]), 0, v111 @ X3_v1, v116 @ X4_v1, v115 @ X5_v1, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\nL_004C:\n\tv85 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v85, \"Failed to load data.\");\n\tthrow v85;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadData(Stream stream)
		{
			//IL_0014: Expected I8, but got I4
			//IL_007b: Expected I8, but got I4
			//IL_0092: Expected I, but got O
			//IL_009c: Expected O, but got I4
			//IL_00ac: Expected O, but got I
			//IL_00bc: Expected O, but got I
			stream.Position = 0L;
			if (RootNode.LoadData(stream))
			{
				long length = stream.Length;
				byte[] array = new byte[length];
				rawData = array;
				stream.Position = 0L;
				byte[] array2 = rawData;
				IntPtr intPtr = (IntPtr)stream;
				object obj = array2.Length;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X8_v18 (Il2CppClass<System.IO.Stream>)+2E0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X8_v18 (Il2CppClass<System.IO.Stream>)+2E8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v115 @ X5_v1 (should have been resolved before IL gen)");
			}
			ArgumentException ex = new ArgumentException("Failed to load data.");
			throw ex;
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x15D1988", Offset = "0x15D1988", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB45C0]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029A0E]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (System.Object[]), typeof(System.Object[]), 0\n\tv50 = System.String::Format(\"Offset| Len  |LenByte|\\r\\n\", v43);\n\tgoto L_002D;\n\tv58 = *([v54 @ X8_v10+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tgoto L_002D;\n\tv68 = v54;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v68, v46, v47, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tv65 = lineLen + 0xA;\n\tv67 = LipingShare.LCLib.Asn1Processor.Asn1Util::GenStr(v65, 0x3D);\n\treturnVal1 = System.String::Concat(v50, \"======+======+=======+\", v67, \"\\r\\n\");\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetNodeTextHeader(int lineLen)
		{
			object[] args = new object[0];
			string text = string.Format("Offset| Len  |LenByte|\r\n", args);
			int len = lineLen + 10;
			string text2 = Asn1Util.GenStr(len, '=');
			return text + "======+======+=======+" + text2 + "\r\n";
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x15D1A50", Offset = "0x15D1A50", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = LipingShare.LCLib.Asn1Processor.Asn1Parser::GetNodeText(this.rootNode, 0x64);\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return GetNodeText(RootNode, 100);
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x15D1A5C", Offset = "0x15D1A5C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = LipingShare.LCLib.Asn1Processor.Asn1Parser::GetNodeTextHeader(lineLen);\n\tv23 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetText(node, node, lineLen);\n\treturnVal2 = System.String::Concat(v17, v23);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetNodeText(Asn1Node node, int lineLen)
		{
			string nodeTextHeader = GetNodeTextHeader(lineLen);
			string text = node.GetText(node, lineLen);
			return nodeTextHeader + text;
		}
	}
}
