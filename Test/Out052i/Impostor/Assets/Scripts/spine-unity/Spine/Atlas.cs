using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200002A")]
	public class Atlas : IEnumerable<AtlasRegion>, IEnumerable
	{
		[Token(Token = "0x40000EE")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<AtlasPage> pages;

		[Token(Token = "0x40000EF")]
		[FieldOffset(Offset = "0x18")]
		private List<AtlasRegion> regions;

		[Token(Token = "0x40000F0")]
		[FieldOffset(Offset = "0x20")]
		private TextureLoader textureLoader;

		[Token(Token = "0x17000059")]
		public List<AtlasRegion> Regions
		{
			[Token(Token = "0x600014B")]
			[Address(RVA = "0x152CCA0", Offset = "0x152CCA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.regions;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Regions;
			}
		}

		[Token(Token = "0x1700005A")]
		public List<AtlasPage> Pages
		{
			[Token(Token = "0x600014C")]
			[Address(RVA = "0x152CCA8", Offset = "0x152CCA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.pages;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Pages;
			}
		}

		[Token(Token = "0x6000149")]
		[Address(RVA = "0x152CB80", Offset = "0x152CB80", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv14 = System.Collections.Generic.List`1<Spine.AtlasRegion>+Enumerator<Spine.AtlasRegion>;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37B2B]) = v34;\nL_001C:\n\tv46 = System.Collections.Generic.List`1<Spine.AtlasRegion>::GetEnumerator(this.regions);\n\t// 35 Box returnVal2 @ X0_v6 (System.Collections.Generic.IEnumerator`1<Spine.AtlasRegion>), typeof(System.Collections.Generic.List`1<Spine.AtlasRegion>+Enumerator<Spine.AtlasRegion>), &v45 @ stack_-38_v1\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerator<AtlasRegion> GetEnumerator()
		{
			List<AtlasRegion>.Enumerator enumerator = Regions.GetEnumerator();
			object obj = default(object);
			return (List<AtlasRegion>.Enumerator)obj;
		}

		[Token(Token = "0x600014A")]
		[Address(RVA = "0x152CC10", Offset = "0x152CC10", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv14 = System.Collections.Generic.List`1<Spine.AtlasRegion>+Enumerator<Spine.AtlasRegion>;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37B2C]) = v34;\nL_001C:\n\tv46 = System.Collections.Generic.List`1<Spine.AtlasRegion>::GetEnumerator(this.regions);\n\t// 35 Box returnVal2 @ X0_v6 (System.Collections.IEnumerator), typeof(System.Collections.Generic.List`1<Spine.AtlasRegion>+Enumerator<Spine.AtlasRegion>), &v45 @ stack_-38_v1\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		IEnumerator IEnumerable.GetEnumerator()
		{
			List<AtlasRegion>.Enumerator enumerator = Regions.GetEnumerator();
			object obj = default(object);
			return (List<AtlasRegion>.Enumerator)obj;
		}

		[Token(Token = "0x600014D")]
		[Address(RVA = "0x152CCB0", Offset = "0x152CCB0", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, reader, dir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, reader, dir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv68 = System.Collections.Generic.List`1<Spine.AtlasRegion>;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, reader, dir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv73 = System.Collections.Generic.List`1<Spine.AtlasPage>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, reader, dir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A37B2D]) = v59;\nL_002C:\n\tv61 = new System.Collections.Generic.List`1<Spine.AtlasPage>();\n\tSystem.Collections.Generic.List`1<Spine.AtlasPage>::.ctor(v61);\n\tthis.pages = v61;\n\tv71 = new System.Collections.Generic.List`1<Spine.AtlasRegion>();\n\tSystem.Collections.Generic.List`1<Spine.AtlasRegion>::.ctor(v71);\n\tthis.regions = v71;\n\tSystem.Object::.ctor(this);\n\tSpine.Atlas::Load(this, reader, dir, textureLoader);\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Atlas(TextReader reader, string dir, TextureLoader textureLoader)
		{
			List<AtlasPage> list = new List<AtlasPage>();
			pages = list;
			List<AtlasRegion> list2 = new List<AtlasRegion>();
			regions = list2;
			Load(reader, dir, textureLoader);
		}

		[Token(Token = "0x600014E")]
		[Address(RVA = "0x152D90C", Offset = "0x152D90C", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, pages, regions, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, pages, regions, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv65 = System.Collections.Generic.List`1<Spine.AtlasRegion>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, pages, regions, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv70 = System.Collections.Generic.List`1<Spine.AtlasPage>;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, pages, regions, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A37B2E]) = v56;\nL_002A:\n\tv58 = new System.Collections.Generic.List`1<Spine.AtlasPage>();\n\tSystem.Collections.Generic.List`1<Spine.AtlasPage>::.ctor(v58);\n\tthis.pages = v58;\n\tv68 = new System.Collections.Generic.List`1<Spine.AtlasRegion>();\n\tSystem.Collections.Generic.List`1<Spine.AtlasRegion>::.ctor(v68);\n\tthis.regions = v68;\n\tSystem.Object::.ctor(this);\n\tthis.pages = pages;\n\tthis.regions = regions;\n\tthis.textureLoader = 0;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Atlas(List<AtlasPage> pages, List<AtlasRegion> regions)
		{
			List<AtlasPage> list = new List<AtlasPage>();
			this.pages = list;
			List<AtlasRegion> list2 = new List<AtlasRegion>();
			this.regions = list2;
			this.pages = pages;
			this.regions = regions;
			textureLoader = null;
		}

		[Token(Token = "0x600014F")]
		[Address(RVA = "0x152CD9C", Offset = "0x152CD9C", Length = "0xB70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005A;\n\tv42 = Spine.AtlasPage;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv62 = Spine.AtlasRegion;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv168 = System.Globalization.CultureInfo;\n\tv169 = \"il2cpp_codegen_initialize_runtime_metadata\"(v168, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv173 = System.Enum;\n\tv174 = \"il2cpp_codegen_initialize_runtime_metadata\"(v173, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv470 = Spine.Format;\n\tv471 = \"il2cpp_codegen_initialize_runtime_metadata\"(v470, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv590 = Spine.Format;\n\tv591 = \"il2cpp_codegen_initialize_runtime_metadata\"(v590, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv644 = System.Int32[];\n\tv645 = \"il2cpp_codegen_initialize_runtime_metadata\"(v644, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv650 = Il2CppMethodInfo;\n\tv651 = \"il2cpp_codegen_initialize_runtime_metadata\"(v650, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv656 = Il2CppMethodInfo;\n\tv657 = \"il2cpp_codegen_initialize_runtime_metadata\"(v656, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv663 = System.Math;\n\tv664 = \"il2cpp_codegen_initialize_runtime_metadata\"(v663, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv720 = System.IO.Path;\n\tv721 = \"il2cpp_codegen_initialize_runtime_metadata\"(v720, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv745 = System.String[];\n\tv746 = \"il2cpp_codegen_initialize_runtime_metadata\"(v745, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv748 = Spine.TextureFilter;\n\tv749 = \"il2cpp_codegen_initialize_runtime_metadata\"(v748, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv754 = Spine.TextureFilter;\n\tv755 = \"il2cpp_codegen_initialize_runtime_metadata\"(v754, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv763 = Spine.TextureLoader;\n\tv764 = \"il2cpp_codegen_initialize_runtime_metadata\"(v763, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv794 = System.Type;\n\tv795 = \"il2cpp_codegen_initialize_runtime_metadata\"(v794, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv809 = \"x\";\n\tv810 = \"il2cpp_codegen_initialize_runtime_metadata\"(v809, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv1074 = \"xy\";\n\tv1075 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1074, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv1082 = \"false\";\n\tv1083 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1082, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv1091 = \"y\";\n\tv1092 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1091, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv1102 = \"true\";\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1102, reader, imagesDir, textureLoader, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A37B2F]) = v59;\nL_005A:\n\tv60 = textureLoader == 0;\n\tif (v60) goto L_046A;\n\tthis.textureLoader = textureLoader;\n\t// 98 NewArr v69 @ X0_v20 (System.String[]), typeof(System.String[]), 4\n\tv180 = System.IO.TextReader::ReadLine(reader);\n\tv181 = v180 == 0;\n\tif (v181) goto L_0463;\nL_0076:\n\tv413 = System.String::Trim(v380);\n\tv653 = v413._stringLength == 0;\n\tif (v653) goto L_FFFFFFFF;\n\tv659 = v462 == 0;\n\tv660 = ~v659;\n\tif (v660) goto L_02FA;\n\tv414 = new Spine.AtlasRegion();\n\tSystem.Object::.ctor(v414);\n\tv414.page = v376;\n\tv414.name = v380;\n\tv751 = Spine.Atlas::ReadValue(reader);\n\tv760 = System.String::op_Equality(v751, \"true\");\n\tv766 = v760 == 0;\n\tif (v766) goto L_009D;\n\tgoto L_00A8;\nL_009D:\n\tv802 = System.String::op_Equality(v751, \"false\");\n\tv817 = v802 == 0;\n\tif (v817) goto L_00A5;\n\tgoto L_00A8;\nL_00A5:\n\tv813 = System.Int32::Parse(v751);\nL_00A8:\n\tv330 = v813 - 0x5A;\n\tv306 = v330 == 0;\n\tv414.degrees = v813;\n\tv414.rotate = v306;\n\tv415 = Spine.Atlas::ReadTuple(reader, v69);\n\tgoto L_00C2;\n\tv1103 = \"il2cpp_codegen_runtime_class_init\"(v1093, v400, v354, v200, methodInfo, v45, v46, v47, v226, v222, v50, v51, v52, v53, v54, v55);\nL_00C2:\n\tv1106 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv1019 = System.Int32::Parse(v69[0], v1106);\n\tv1123 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv1130 = System.Int32::Parse(v69[1], v1123);\n\tv1020 = Spine.Atlas::ReadTuple(reader, v69);\n\tv1136 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv1021 = System.Int32::Parse(v69[0], v1136);\n\tv1147 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv1154 = System.Int32::Parse(v69[1], v1147);\n\t// 259 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tif (v414.rotate) goto L_0115;\n\tgoto L_0115;\nL_0115:\n\tif (v414.rotate) goto L_011D;\n\tgoto L_011D;\nL_011D:\n\t// 285 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 288 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv227 = v1019 / v376.width;\n\tv414.u = v227;\n\tv414.x = v1019;\n\tv414.y = v1130;\n\tgoto L_0137;\n\tv1194 = \"il2cpp_codegen_runtime_class_init\"(v1187, v1152, v982, v200, methodInfo, v45, v46, v47, v227, v223, v50, v51, v52, v53, v54, v55);\nL_0137:\n\tv1205 = v1021 >= 0;\n\tif (v1205) goto L_FFFFFFFF;\n\tv1216 = -v1021;\n\tgoto L_0146;\nL_0146:\n\tv219 = v1154 >= 0;\n\tif (v219) goto L_FFFFFFFF;\n\tv388 = -v1154;\n\tgoto L_014E;\nL_014E:\n\tv414.width = v1216;\n\tv414.height = v388;\n\tv1256 = Spine.Atlas::ReadTuple(reader, v69);\n\tv247 = v1256 != 4;\n\tif (v247) goto L_0277;\n\t// 352 NewArr v1022 @ X0_v158 (System.Int32[]), typeof(System.Int32[]), 4\n\tgoto L_016D;\n\tv1352 = \"il2cpp_codegen_runtime_class_init\"(v1335, v1003, v982, v200, methodInfo, v45, v46, v47, v227, v223, v50, v51, v52, v53, v54, v55);\nL_016D:\n\tv1355 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv416 = System.Int32::Parse(v69[0], v1355);\n\tv1022[0] = v416;\n\tv1374 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv1023 = System.Int32::Parse(v69[1], v1374);\n\tv1022[1] = v1023;\n\tv1386 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv1024 = System.Int32::Parse(v69[2], v1386);\n\tv1022[2] = v1024;\n\tv1404 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv1025 = System.Int32::Parse(v69[3], v1404);\n\tv1022[3] = v1025;\n\tv414.splits = v1022;\n\tv1279 = Spine.Atlas::ReadTuple(reader, v69);\n\tv248 = v1279 != 4;\n\tif (v248) goto L_0277;\n\t// 497 NewArr v1026 @ X0_v180 (System.Int32[]), typeof(System.Int32[]), 4\n\tgoto L_01FE;\n\tv1430 = \"il2cpp_codegen_runtime_class_init\"(v1427, v1007, v985, v200, methodInfo, v45, v46, v47, v227, v223, v50, v51, v52, v53, v54, v55);\nL_01FE:\n\tv1433 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv417 = System.Int32::Parse(v69[0], v1433);\n\tv1026[0] = v417;\n\tv1438 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv1027 = System.Int32::Parse(v69[1], v1438);\n\tv1026[1] = v1027;\n\tv1445 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv1028 = System.Int32::Parse(v69[2], v1445);\n\tv1026[2] = v1028;\n\tv1452 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tv1029 = System.Int32::Parse(v69[3], v1452);\n\tv1026[3] = v1029;\n\tv414.pads = v1026;\n\tv1278 = Spine.Atlas::ReadTuple(reader, v69);\nL_0277:\n\t;\n// ... truncated")]
		private void Load(TextReader reader, string imagesDir, TextureLoader textureLoader)
		{
			//IL_08af: Expected I4, but got O
			//IL_08e4: Expected I4, but got O
			//IL_0940: Expected I4, but got O
			//IL_0975: Expected I4, but got O
			//IL_09bb: Expected I4, but got O
			//IL_09f0: Expected I4, but got O
			if (textureLoader != null)
			{
				this.textureLoader = textureLoader;
				string[] array = new string[4];
				string text = reader.ReadLine();
				if (text == null)
				{
					return;
				}
				AtlasPage atlasPage = null;
				string text2 = text;
				bool flag = true;
				object obj2 = default(object);
				object obj4 = default(object);
				object obj6 = default(object);
				while (true)
				{
					string text3 = text2.Trim();
					if (text3.Length != 0)
					{
						if (!flag)
						{
							AtlasRegion atlasRegion = new AtlasRegion();
							atlasRegion.page = atlasPage;
							atlasRegion.name = text2;
							string text4 = ReadValue(reader);
							int num = ((text4 == "true") ? 90 : ((!(text4 == "false")) ? int.Parse(text4) : 0));
							int num2 = num - 90;
							bool rotate = num2 == 0;
							atlasRegion.degrees = num;
							atlasRegion.rotate = rotate;
							int num3 = ReadTuple(reader, array);
							CultureInfo invariantCulture = CultureInfo.InvariantCulture;
							int num4 = int.Parse(array[0], invariantCulture);
							CultureInfo invariantCulture2 = CultureInfo.InvariantCulture;
							int y = int.Parse(array[1], invariantCulture2);
							int num5 = ReadTuple(reader, array);
							CultureInfo invariantCulture3 = CultureInfo.InvariantCulture;
							int num6 = int.Parse(array[0], invariantCulture3);
							CultureInfo invariantCulture4 = CultureInfo.InvariantCulture;
							int num7 = int.Parse(array[1], invariantCulture4);
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
							if (!atlasRegion.rotate)
							{
							}
							if (!atlasRegion.rotate)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
							int num8 = num4 / atlasPage.width;
							atlasRegion.u = num8;
							atlasRegion.x = num4;
							atlasRegion.y = y;
							int width = ((num6 >= 0) ? num6 : (-num6));
							int height = ((num7 >= 0) ? num7 : (-num7));
							atlasRegion.width = width;
							atlasRegion.height = height;
							int num9 = ReadTuple(reader, array);
							if (num9 == 4)
							{
								CultureInfo invariantCulture5 = CultureInfo.InvariantCulture;
								int num10 = int.Parse(array[0], invariantCulture5);
								CultureInfo invariantCulture6 = CultureInfo.InvariantCulture;
								int num11 = int.Parse(array[1], invariantCulture6);
								CultureInfo invariantCulture7 = CultureInfo.InvariantCulture;
								int num12 = int.Parse(array[2], invariantCulture7);
								CultureInfo invariantCulture8 = CultureInfo.InvariantCulture;
								int num13 = int.Parse(array[3], invariantCulture8);
								atlasRegion.splits = new int[4] { num10, num11, num12, num13 };
								int num14 = ReadTuple(reader, array);
								if (num14 == 4)
								{
									CultureInfo invariantCulture9 = CultureInfo.InvariantCulture;
									int num15 = int.Parse(array[0], invariantCulture9);
									CultureInfo invariantCulture10 = CultureInfo.InvariantCulture;
									int num16 = int.Parse(array[1], invariantCulture10);
									CultureInfo invariantCulture11 = CultureInfo.InvariantCulture;
									int num17 = int.Parse(array[2], invariantCulture11);
									CultureInfo invariantCulture12 = CultureInfo.InvariantCulture;
									int num18 = int.Parse(array[3], invariantCulture12);
									atlasRegion.pads = new int[4] { num15, num16, num17, num18 };
									int num19 = ReadTuple(reader, array);
								}
							}
							CultureInfo invariantCulture13 = CultureInfo.InvariantCulture;
							int originalWidth = int.Parse(array[0], invariantCulture13);
							atlasRegion.originalWidth = originalWidth;
							CultureInfo invariantCulture14 = CultureInfo.InvariantCulture;
							int originalHeight = int.Parse(array[1], invariantCulture14);
							atlasRegion.originalHeight = originalHeight;
							int num20 = ReadTuple(reader, array);
							CultureInfo invariantCulture15 = CultureInfo.InvariantCulture;
							int num21 = int.Parse(array[0], invariantCulture15);
							atlasRegion.offsetX = num21;
							CultureInfo invariantCulture16 = CultureInfo.InvariantCulture;
							int num22 = int.Parse(array[1], invariantCulture16);
							atlasRegion.offsetY = num22;
							string s = ReadValue(reader);
							CultureInfo invariantCulture17 = CultureInfo.InvariantCulture;
							int index = int.Parse(s, invariantCulture17);
							atlasRegion.index = index;
							List<AtlasRegion> list = Regions;
							AtlasRegion[] items = list._items;
							int version = list._version + 1;
							list._version = version;
							int count = list.Count;
							if (list.Count < items.Length)
							{
								int size = list.Count + 1;
								list._size = size;
								items[count] = atlasRegion;
							}
							else
							{
								list.Add(atlasRegion);
							}
							goto IL_0d21;
						}
						AtlasPage atlasPage2 = new AtlasPage();
						atlasPage2.name = text2;
						int num23 = ReadTuple(reader, array);
						if (num23 == 2)
						{
							CultureInfo invariantCulture18 = CultureInfo.InvariantCulture;
							int width2 = int.Parse(array[0], invariantCulture18);
							atlasPage2.width = width2;
							CultureInfo invariantCulture19 = CultureInfo.InvariantCulture;
							int height2 = int.Parse(array[1], invariantCulture19);
							atlasPage2.height = height2;
							int num24 = ReadTuple(reader, array);
						}
						Type typeFromHandle = typeof(Format);
						object obj = Enum.Parse(typeFromHandle, array[0], ignoreCase: false);
						if ((int)((obj is Format) ? obj : null) == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						atlasPage2.format = (Format)obj2;
						int num25 = ReadTuple(reader, array);
						Type typeFromHandle2 = typeof(TextureFilter);
						object obj3 = Enum.Parse(typeFromHandle2, array[0], ignoreCase: false);
						if ((int)((obj3 is TextureFilter) ? obj3 : null) == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						atlasPage2.minFilter = (TextureFilter)obj4;
						Type typeFromHandle3 = typeof(TextureFilter);
						object obj5 = Enum.Parse(typeFromHandle3, array[1], ignoreCase: false);
						if ((int)((obj5 is TextureFilter) ? obj5 : null) == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						atlasPage2.magFilter = (TextureFilter)obj6;
						string text5 = ReadValue(reader);
						atlasPage2.uWrap = TextureWrap.ClampToEdge;
						switch (text5)
						{
						case "x":
							atlasPage2.uWrap = TextureWrap.Repeat;
							break;
						case "y":
							atlasPage2.vWrap = TextureWrap.Repeat;
							break;
						case "xy":
							atlasPage2.uWrap = TextureWrap.Repeat;
							break;
						}
						string path = Path.Combine(imagesDir, text2);
						textureLoader.Load(atlasPage2, path);
						List<AtlasPage> list2 = Pages;
						AtlasPage[] items2 = list2._items;
						int version2 = list2._version + 1;
						list2._version = version2;
						int count2 = list2.Count;
						if (list2.Count < items2.Length)
						{
							int size2 = list2.Count + 1;
							list2._size = size2;
							items2[count2] = atlasPage2;
							atlasPage = atlasPage2;
						}
						else
						{
							list2.Add(atlasPage2);
							atlasPage = atlasPage2;
						}
					}
					else
					{
						atlasPage = null;
					}
					bool flag2 = atlasPage == null;
					flag = flag2;
					goto IL_0d21;
					IL_0d21:
					string text6 = reader.ReadLine();
					bool flag3 = text6 == null;
					bool flag4 = !flag3;
					text2 = text6;
					if (!flag4)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			ArgumentNullException ex = new ArgumentNullException("textureLoader", "textureLoader cannot be null.");
			throw ex;
		}

		[Token(Token = "0x6000150")]
		[Address(RVA = "0x152DB50", Offset = "0x152DB50", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = System.IO.TextReader::ReadLine(reader);\n\tv57 = System.String::IndexOf(v11, 0x3A);\n\tv69 = v57 + 1;\n\tv35 = v69 == 0;\n\tif (v35) goto L_0029;\n\tv47 = v57 + 1;\n\tv44 = System.String::Substring(v11, v47);\n\treturnVal1 = System.String::Trim(v44);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0029:\n\tv75 = System.String::Concat(\"Invalid line: \", v62);\n\tv81 = new System.Exception();\n\tSystem.Exception::.ctor(v81, v75);\n\tthrow v81;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string ReadValue(TextReader reader)
		{
			string text = reader.ReadLine();
			int num = text.IndexOf(':');
			if (num + 1 != 0)
			{
				int startIndex = num + 1;
				string text2 = text.Substring(startIndex);
				return text2.Trim();
			}
			string text3 = default(string);
			string message = "Invalid line: " + text3;
			Exception ex = new Exception(message);
			throw ex;
		}

		[Token(Token = "0x6000151")]
		[Address(RVA = "0x152D9F4", Offset = "0x152D9F4", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = System.IO.TextReader::ReadLine(reader);\n\tv117 = System.String::IndexOf(v21, 0x3A);\n\tv159 = v117 + 1;\n\tv161 = v159 == 0;\n\tif (v161) goto L_0078;\n\tv66 = v117 + 1;\nL_0022:\n\tv219 = System.String::IndexOf(v21, 0x2C, v66);\n\tv224 = v219 + 1;\n\tv81 = v224 == 0;\n\tif (v81) goto L_0051;\n\tv90 = v219 - v66;\n\tv93 = System.String::Substring(v21, v66, v90);\n\tv94 = System.String::Trim(v93);\n\ttuple[v69 @ X23_v5 (System.Int32)] = v94;\n\tv70 = v69 + 1;\n\tv67 = v219 + 1;\n\tv194 = v70 != 3;\n\tif (v194) goto L_0022;\nL_0051:\n\tv95 = System.String::Substring(v21, v67);\n\tv96 = System.String::Trim(v95);\n\tv277 = v70 + 1;\n\ttuple[v70 @ X23_v6 (System.Int32)] = v96;\n\treturn v277;\n\tv114 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0078:\n\tv193 = System.String::Concat(\"Invalid line: \", v178);\n\tv225 = new System.Exception();\n\tSystem.Exception::.ctor(v225, v193);\n\tthrow v225;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static int ReadTuple(TextReader reader, string[] tuple)
		{
			string text = reader.ReadLine();
			int num = text.IndexOf(':');
			if (num + 1 != 0)
			{
				int num2 = num + 1;
				int num3 = 0;
				int num6;
				int num7;
				bool flag2;
				do
				{
					int num4 = text.IndexOf(',', num2);
					int num5 = num4 + 1;
					bool flag = num5 == 0;
					num6 = num2;
					num7 = num3;
					if (flag)
					{
						break;
					}
					int length = num4 - num2;
					string text2 = text.Substring(num2, length);
					string text3 = text2.Trim();
					tuple[num3] = text3;
					num7 = num3 + 1;
					num6 = num4 + 1;
					flag2 = num7 != 3;
					num2 = num6;
					num3 = num7;
				}
				while (flag2);
				string text4 = text.Substring(num6);
				string text5 = text4.Trim();
				int result = num7 + 1;
				tuple[num7] = text5;
				return result;
			}
			string text6 = default(string);
			string message = "Invalid line: " + text6;
			Exception ex = new Exception(message);
			throw ex;
		}

		[Token(Token = "0x6000152")]
		[Address(RVA = "0x152DC08", Offset = "0x152DC08", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv44 = Il2CppMethodInfo;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37B30]) = v40;\nL_0016:\n\tv145 = this.regions;\n\tv56 = v145._size < 1;\n\tif (v56) goto L_004C;\nL_002C:\n\tv108 = System.Collections.Generic.List`1<Spine.AtlasRegion>::get_Item(v145, v114);\n\tv114 = v114 + 1;\n\tv90 = v145._size == v114;\n\tv65 = 1f - v108.v;\n\tv62 = 1f - v108.v2;\n\tv108.v = v65;\n\tv108.v2 = v62;\n\tif (v90) goto L_004C;\n\tv145 = this.regions;\n\tv150 = this.regions == 0;\n\tv110 = ~v150;\n\tif (v110) goto L_002C;\n\tthrow System.NullReferenceException;\nL_004C:\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FlipV()
		{
			List<AtlasRegion> list = Regions;
			if (list.Count < 1)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				AtlasRegion atlasRegion = list[num];
				num++;
				bool flag = list.Count == num;
				float v = 1f - atlasRegion.v;
				float v2 = 1f - atlasRegion.v2;
				atlasRegion.v = v;
				atlasRegion.v2 = v2;
				if (!flag)
				{
					list = Regions;
					if (Regions == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x6000153")]
		[Address(RVA = "0x152DCC0", Offset = "0x152DCC0", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, name, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv45 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, name, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A37B31]) = v41;\nL_0017:\n\tv142 = this.regions;\n\tv56 = v142._size - 1;\n\tv58 = v142._size < 1;\n\tif (v58) goto L_0050;\nL_002D:\n\tv103 = System.Collections.Generic.List`1<Spine.AtlasRegion>::get_Item(v142, v112);\n\tv129 = System.String::op_Equality(v103.name, name);\n\tv175 = v129 == 0;\n\tv131 = ~v175;\n\tif (v131) goto L_005D;\n\tv88 = v56 == v112;\n\tif (v88) goto L_0050;\n\tv142 = this.regions;\n\tv112 = v112 + 1;\n\tv177 = this.regions == 0;\n\tv108 = ~v177;\n\tif (v108) goto L_002D;\n\tgoto L_005F;\nL_0050:\n\treturn 0;\nL_005D:\n\treturnVal3 = System.Collections.Generic.List`1<Spine.AtlasRegion>::get_Item(this.regions, v112);\n\treturn returnVal3;\nL_005F:\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AtlasRegion FindRegion(string name)
		{
			List<AtlasRegion> list = Regions;
			int num = list.Count - 1;
			if (list.Count >= 1)
			{
				int num2 = 0;
				while (true)
				{
					AtlasRegion atlasRegion = list[num2];
					if (!(atlasRegion.name == name))
					{
						if (num == num2)
						{
							break;
						}
						list = Regions;
						num2++;
						if (Regions == null)
						{
							return (AtlasRegion)(object)new NullReferenceException();
						}
						continue;
					}
					return Regions[num2];
				}
			}
			return null;
		}

		[Token(Token = "0x6000154")]
		[Address(RVA = "0x152DD94", Offset = "0x152DD94", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv48 = Il2CppMethodInfo;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv155 = Spine.TextureLoader;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v155, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37B32]) = v44;\nL_001B:\n\tv58 = this.textureLoader;\n\tv46 = this.textureLoader == 0;\n\tif (v46) goto L_0082;\n\tv188 = this.pages;\n\tv88 = v188._size < 1;\n\tif (v88) goto L_0082;\nL_0035:\n\tv177 = System.Collections.Generic.List`1<Spine.AtlasPage>::get_Item(v188, v182);\n\tgoto L_0067;\n\tv193 = *([v190 @ X8_v6+B0]);\n\tv194 = v193 + 8;\n\tv196 = *([v223 @ X10_v8-8]);\n\tv238 = v196 == v191;\n\tif (v238) goto L_005E;\n\tv200 = v224 - 1;\n\tv198 = v223 + 0x10;\n\tv202 = v224 != 1;\n\tif (v202) goto L_FFFFFFFF;\n\tv219 = 1;\n\tv220 = v58;\n\tv221 = 0xB349B4(v220, v191, v219, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0067;\nL_005E:\n\tv244 = *([v223 @ X10_v8]);\n\tv245 = v244 + 1;\n\tv246 = v245 << 4;\n\tv247 = v190 + v246;\n\tv248 = v247 + 0x138;\nL_0067:\n\tSpine.TextureLoader::Unload(v58, v177.rendererObject);\n\tv182 = v182 + 1;\n\tv115 = v182 == v188._size;\n\tif (v115) goto L_0082;\n\tv188 = this.pages;\n\tv58 = this.textureLoader;\n\tv262 = this.pages == 0;\n\tv178 = ~v262;\n\tif (v178) goto L_0035;\n\tthrow System.NullReferenceException;\nL_0082:\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			TextureLoader textureLoader = this.textureLoader;
			if (this.textureLoader == null)
			{
				return;
			}
			List<AtlasPage> list = Pages;
			if (list.Count < 1)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				AtlasPage atlasPage = list[num];
				textureLoader.Unload(atlasPage.rendererObject);
				num++;
				if (num != list.Count)
				{
					list = Pages;
					textureLoader = this.textureLoader;
					if (Pages == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}
	}
}
