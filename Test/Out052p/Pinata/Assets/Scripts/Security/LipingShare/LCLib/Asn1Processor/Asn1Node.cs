using System;
using System.Collections;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LipingShare.LCLib.Asn1Processor
{
	[Token(Token = "0x200001F")]
	internal class Asn1Node
	{
		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0x10")]
		private byte tag;

		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x18")]
		private long dataOffset;

		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0x20")]
		private long dataLength;

		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x28")]
		private long lengthFieldBytes;

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x30")]
		private byte[] data;

		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x38")]
		internal ArrayList childNodeList;

		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x40")]
		private byte unusedBits;

		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x48")]
		private long deepness;

		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x50")]
		private string path;

		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x58")]
		private Asn1Node parentNode;

		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x60")]
		private bool requireRecalculatePar;

		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x61")]
		private bool isIndefiniteLength;

		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x62")]
		private bool parseEncapsulatedData;

		[Token(Token = "0x17000031")]
		public byte Tag
		{
			[Token(Token = "0x6000091")]
			[Address(RVA = "0x15CEBD4", Offset = "0x15CEBD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.tag;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Tag;
			}
		}

		[Token(Token = "0x17000032")]
		public byte MaskedTag
		{
			[Token(Token = "0x6000092")]
			[Address(RVA = "0x15CEBDC", Offset = "0x15CEBDC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.tag & 0x1F;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return (byte)(Tag & 0x1F);
			}
		}

		[Token(Token = "0x17000033")]
		public long ChildNodeCount
		{
			[Token(Token = "0x6000097")]
			[Address(RVA = "0x15CEEF0", Offset = "0x15CEEF0", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = System.Collections.ArrayList::get_Count(this.childNodeList);\n\treturn v12;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000f: Expected I8, but got I4
				return childNodeList.Count;
			}
		}

		[Token(Token = "0x17000034")]
		public string TagName
		{
			[Token(Token = "0x6000099")]
			[Address(RVA = "0x15CF270", Offset = "0x15CF270", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EA9DE8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029A02]) = v38;\nL_001A:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\treturnVal1 = LipingShare.LCLib.Asn1Processor.Asn1Util::GetTagName(this.tag);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Asn1Util.GetTagName(Tag);
			}
		}

		[Token(Token = "0x17000035")]
		public Asn1Node ParentNode
		{
			[Token(Token = "0x600009A")]
			[Address(RVA = "0x15CF558", Offset = "0x15CF558", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.parentNode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ParentNode;
			}
		}

		[Token(Token = "0x17000036")]
		public long DataLength
		{
			[Token(Token = "0x600009D")]
			[Address(RVA = "0x15D0D3C", Offset = "0x15D0D3C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.dataLength;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DataLength;
			}
		}

		[Token(Token = "0x17000037")]
		public byte[] Data
		{
			[Token(Token = "0x600009E")]
			[Address(RVA = "0x15D0D44", Offset = "0x15D0D44", Length = "0x17C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB1D60]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029A05]) = v42;\nL_0018:\n\tv46 = new System.IO.MemoryStream();\n\tSystem.IO.MemoryStream::.ctor(v46);\n\tv54 = System.Collections.ArrayList::get_Count(this.childNodeList);\n\tv56 = v54 == 0;\n\tif (v56) goto L_0049;\n\tv110 = v54 < 1;\n\tif (v110) goto L_005C;\nL_0035:\n\tv95 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(this, v61);\n\tv160 = LipingShare.LCLib.Asn1Processor.Asn1Node::SaveData(v95, v46);\n\tv61 = v61 + 1;\n\tv150 = v54 > v61;\n\tif (v150) goto L_0035;\n\tgoto L_005C;\nL_0049:\n\tv111 = this.data;\n\tv112 = this.data == 0;\n\tif (v112) goto L_005C;\n\tv187 = System.IO.MemoryStream::Write(v46, this.data, 0, v111.Length);\n\tgoto L_005C;\nL_005C:\n\tv195 = System.IO.MemoryStream::get_Length(v46);\n\t// 98 NewArr v201 @ X0_v15 (System.Byte[]), typeof(System.Byte[]), v195 @ X0_v13 (System.Int64)\n\tv246 = System.IO.MemoryStream::set_Position(v46, 0);\n\tv251 = System.IO.MemoryStream::get_Length(v46);\n\tv256 = System.IO.MemoryStream::Read(v46, v201, 0, v251);\n\tv258 = System.IO.Stream::Close(v46);\n\treturn v201;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_010d: Expected I8, but got I4
				//IL_0130: Expected I4, but got I8
				MemoryStream memoryStream = new MemoryStream();
				int count = childNodeList.Count;
				if (count != 0)
				{
					if (count >= 1)
					{
						int num = 0;
						do
						{
							Asn1Node childNode = GetChildNode(num);
							bool flag = childNode.SaveData(memoryStream);
							num++;
						}
						while (count > num);
					}
				}
				else
				{
					byte[] array = data;
					if (data != null)
					{
						memoryStream.Write(data, 0, array.Length);
					}
				}
				long length = memoryStream.Length;
				byte[] array2 = new byte[length];
				memoryStream.Position = 0L;
				long length2 = memoryStream.Length;
				int num2 = memoryStream.Read(array2, 0, (int)length2);
				memoryStream.Close();
				return array2;
			}
		}

		[Token(Token = "0x17000038")]
		public long Deepness
		{
			[Token(Token = "0x600009F")]
			[Address(RVA = "0x15CE06C", Offset = "0x15CE06C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.deepness;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Deepness;
			}
		}

		[Token(Token = "0x17000039")]
		protected bool RequireRecalculatePar
		{
			[Token(Token = "0x60000A0")]
			[Address(RVA = "0x15CEC60", Offset = "0x15CEC60", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.requireRecalculatePar = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				requireRecalculatePar = value;
			}
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x15CDF34", Offset = "0x15CDF34", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EF2DD8]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, parentNode, dataOffset, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20299F9]) = v44;\nL_001D:\n\tthis.requireRecalculatePar = 1;\n\tthis.parseEncapsulatedData = 1;\n\tthis.path = \"\";\n\tSystem.Object::.ctor(this);\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::Init(this);\n\tthis.parentNode = parentNode;\n\tthis.dataOffset = dataOffset;\n\tv54 = parentNode.deepness + 1;\n\tthis.deepness = v54;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Asn1Node(Asn1Node parentNode, long dataOffset)
		{
			requireRecalculatePar = true;
			isIndefiniteLength = false;
			parseEncapsulatedData = true;
			path = "";
			Init();
			this.parentNode = parentNode;
			this.dataOffset = dataOffset;
			long num = parentNode.Deepness + 1;
			deepness = num;
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x15CDFD4", Offset = "0x15CDFD4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EBC0A8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20299FA]) = v38;\nL_0016:\n\tv42 = new System.Collections.ArrayList();\n\tSystem.Collections.ArrayList::.ctor(v42);\n\tthis.data = 0;\n\tthis.childNodeList = v42;\n\tthis.unusedBits = 0;\n\tthis.dataLength = 0;\n\tthis.lengthFieldBytes = 0;\n\tthis.tag = 0x30;\n\tv51 = System.Collections.ArrayList::Clear(v42);\n\tthis.deepness = 0;\n\tthis.parentNode = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Init()
		{
			//IL_0052: Expected I8, but got I4
			//IL_005d: Expected I8, but got I4
			//IL_0019: Expected I8, but got I4
			ArrayList arrayList = new ArrayList();
			data = null;
			childNodeList = arrayList;
			unusedBits = 0;
			dataLength = 0L;
			lengthFieldBytes = 0L;
			tag = 48;
			arrayList.Clear();
			deepness = 0L;
			parentNode = null;
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x15CE074", Offset = "0x15CE074", Length = "0x240")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1EFE900]);\n\tv35 = *([v34 @ X8_v36]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, startNode, baseLine, lStr, lineLen, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20299FB]) = v50;\nL_0020:\n\tv56 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetIndentStr(this, startNode);\n\tgoto L_0031;\n\tv65 = *([v61 @ X8_v7+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0031;\n\tv74 = v61;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v74, v54, baseLine, lStr, lineLen, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0031:\n\tv73 = LipingShare.LCLib.Asn1Processor.Asn1Util::ToHexString(this.data);\n\tv88 = v73.m_stringLength < 1;\n\tif (v88) goto L_00C4;\n\tv200 = baseLine.m_stringLength + v73.m_stringLength;\n\tv93 = v200 >= lineLen;\n\tif (v93) goto L_00CC;\n\t// 85 NewArr v121 @ X0_v24 (System.String[]), typeof(System.String[]), 5\n\tv337 = \"\" == 0;\n\tif (v337) goto L_0062;\n\t// 94 IsInst v179 @ X0_v41, typeof(System.String), \"\"\nL_0062:\n\tv345 = v121.Length == 0;\n\tif (v345) goto L_00E1;\n\tv121[0] = \"\";\n\t// 104 IsInst v180 @ X0_v29, typeof(System.String), baseLine @ X2 (System.String)\n\tv355 = v121.Length;\n\tv357 = v121.Length < 1;\n\tv173 = ~v357;\n\tv169 = v121.Length - 1;\n\tv161 = v169 == 0;\n\tv358 = ~v173;\n\tv141 = v358 | v161;\n\tif (v141) goto L_00E1;\n\tv121[1] = baseLine;\n\tv361 = \"'\" == 0;\n\tif (v361) goto L_0084;\n\t// 128 IsInst v181 @ X0_v39, typeof(System.String), \"'\"\n\tv355 = v121.Length;\nL_0084:\n\tv363 = v355 < 2;\n\tv174 = ~v363;\n\tv170 = v355 - 2;\n\tv162 = v170 == 0;\n\tv364 = ~v174;\n\tv142 = v364 | v162;\n\tif (v142) goto L_00E1;\n\tv121[2] = \"'\";\n\t// 149 IsInst v182 @ X0_v33, typeof(System.String), v73 @ X0_v6 (System.String)\n\tv356 = v121.Length;\n\tv366 = v121.Length < 3;\n\tv175 = ~v366;\n\tv171 = v121.Length - 3;\n\tv163 = v171 == 0;\n\tv367 = ~v175;\n\tv143 = v367 | v163;\n\tif (v143) goto L_00E1;\n\tv121[3] = v73;\n\tv369 = \"'\" == 0;\n\tif (v369) goto L_00AF;\n\t// 171 IsInst v183 @ X0_v38, typeof(System.String), \"'\"\n\tv356 = v121.Length;\nL_00AF:\n\tv371 = v356 < 4;\n\tv284 = ~v371;\n\tv282 = v356 - 4;\n\tv278 = v282 == 0;\n\tv372 = ~v284;\n\tv268 = v372 | v278;\n\tif (v268) goto L_00E1;\n\tv121[4] = \"'\";\n\tv286 = System.String::Concat(v121);\n\tgoto L_00DF;\nL_00C4:\n\tv286 = System.String::Concat(\"\", baseLine);\n\tgoto L_00DF;\nL_00CC:\n\tv311 = LipingShare.LCLib.Asn1Processor.Asn1Node::FormatLineHexString(v73, lStr, v56.m_stringLength, lineLen, v73);\n\tv286 = System.String::Concat(\"\", baseLine, v311);\nL_00DF:\n\treturnVal2 = System.String::Concat(v286, \"\\r\\n\");\n\treturn returnVal2;\nL_00E1:\n\tv252 = new System.IndexOutOfRangeException();\n\tgoto L_00E7;\n\tv128 = new System.NullReferenceException();\n\tv199 = new System.ArrayTypeMismatchException();\nL_00E7:\n\tthrow v251;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 149 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string GetHexPrintingStr(Asn1Node startNode, string baseLine, string lStr, int lineLen)
		{
			//IL_0103: Expected O, but got I4
			//IL_012f: Expected O, but got I4
			//IL_0377: Expected O, but got I
			//IL_01b1: Expected O, but got I4
			//IL_01e5: Expected O, but got I4
			//IL_0211: Expected O, but got I4
			//IL_03d5: Expected O, but got I
			//IL_0293: Expected O, but got I4
			string indentStr = GetIndentStr(startNode);
			string text = Asn1Util.ToHexString(data);
			string text2;
			if (text.Length >= 1)
			{
				int num = baseLine.Length + text.Length;
				if (num < lineLen)
				{
					string[] array = new string[5];
					if ("" != null)
					{
						object obj = "" as string;
					}
					if (array.Length != 0)
					{
						array[0] = "";
						object obj2 = baseLine as string;
						object obj3 = array.Length;
						bool flag = array.Length < 1;
						bool flag2 = !flag;
						object obj4 = array.Length - 1;
						bool flag3 = obj4 == null;
						bool flag4 = !flag2;
						if (!(flag4 || flag3))
						{
							array[1] = baseLine;
							if ("'" != null)
							{
								object obj5 = "'" as string;
								obj3 = array.Length;
							}
							bool flag5 = (long)(IntPtr)obj3 < 2L;
							bool flag6 = !flag5;
							object obj6 = (long)(IntPtr)obj3 - 2L;
							bool flag7 = obj6 == null;
							bool flag8 = !flag6;
							if (!(flag8 || flag7))
							{
								array[2] = "'";
								object obj7 = text as string;
								object obj8 = array.Length;
								bool flag9 = array.Length < 3;
								bool flag10 = !flag9;
								object obj9 = array.Length - 3;
								bool flag11 = obj9 == null;
								bool flag12 = !flag10;
								if (!(flag12 || flag11))
								{
									array[3] = text;
									if ("'" != null)
									{
										object obj10 = "'" as string;
										obj8 = array.Length;
									}
									bool flag13 = (long)(IntPtr)obj8 < 4L;
									bool flag14 = !flag13;
									object obj11 = (long)(IntPtr)obj8 - 4L;
									bool flag15 = obj11 == null;
									bool flag16 = !flag14;
									if (!(flag16 || flag15))
									{
										array[4] = "'";
										text2 = string.Concat(array);
										goto IL_0311;
									}
								}
							}
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					throw ex2;
				}
				string text3 = ((Asn1Node)(object)text).FormatLineHexString(lStr, indentStr.Length, lineLen, text);
				text2 = "" + baseLine + text3;
			}
			else
			{
				text2 = "" + baseLine;
			}
			goto IL_0311;
			IL_0311:
			return text2 + "\r\n";
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x15CE774", Offset = "0x15CE774", Length = "0x330")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv40 = *([1F0DE10]);\n\tv41 = *([v40 @ X8_v58]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, lStr, indent, lineLen, msg, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv57 = 0 | 1;\n\t*([20299FC]) = v57;\nL_0021:\n\tv140 = msg.m_stringLength;\n\tv73 = msg.m_stringLength < 1;\n\tif (v73) goto L_015D;\n\tv143 = v213 + 3;\n\tv144 = v213 + 3;\n\tv146 = v212 - v143;\n\tv147 = v144 - v212;\nL_0041:\n\t// 65 NewArr v236 @ X0_v9 (System.String[]), typeof(System.String[]), 7\n\tv269 = v219 == 0;\n\tif (v269) goto L_004D;\n\t// 74 IsInst v293 @ X0_v59, typeof(System.String), v219 @ X25_v5 (System.String)\nL_004D:\n\tv426 = v236.Length;\n\tv300 = v236.Length == 0;\n\tif (v300) goto L_015E;\n\tv236[0] = v219;\n\tv302 = \"\\r\\n\" == 0;\n\tif (v302) goto L_005A;\n\t// 86 IsInst v474 @ X0_v57, typeof(System.String), \"\r\n\"\n\tv426 = v236.Length;\nL_005A:\n\tv502 = v426 < 1;\n\tv399 = ~v502;\n\tv390 = v426 - 1;\n\tv372 = v390 == 0;\n\tv503 = ~v399;\n\tv323 = v503 | v372;\n\tif (v323) goto L_015E;\n\tv236[1] = \"\\r\\n\";\n\tv507 = lStr == 0;\n\tif (v507) goto L_0071;\n\t// 109 IsInst v475 @ X0_v56, typeof(System.String), lStr @ X1 (System.String)\n\tv426 = v236.Length;\nL_0071:\n\tv510 = v426 < 2;\n\tv400 = ~v510;\n\tv391 = v426 - 2;\n\tv373 = v391 == 0;\n\tv511 = ~v400;\n\tv324 = v511 | v373;\n\tif (v324) goto L_015E;\n\tv236[2] = lStr;\n\tv156 = v216 + v146;\n\tv446 = v156 <= v140;\n\tif (v446) goto L_00D1;\n\tgoto L_009B;\n\tv523 = *([v514 @ X0_v22+E0]);\n\tv524 = v523 == 0;\n\tv525 = ~v524;\n\tif (v525) goto L_009B;\n\tv527 = \"il2cpp_codegen_runtime_class_init\"(v514, v311, v213, v212, msg, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_009B:\n\tv532 = LipingShare.LCLib.Asn1Processor.Asn1Util::GenStr(v143, 0x20);\n\tv543 = v532 == 0;\n\tif (v543) goto L_00A5;\n\t// 162 IsInst v476 @ X0_v53, typeof(System.String), v532 @ X0_v46 (System.String)\nL_00A5:\n\tv427 = v236.Length;\n\tv547 = v236.Length < 3;\n\tv396 = ~v547;\n\tv387 = v236.Length - 3;\n\tv369 = v387 == 0;\n\tv548 = ~v396;\n\tv320 = v548 | v369;\n\tif (v320) goto L_015E;\n\tv236[3] = v532;\n\tv554 = \"'\" == 0;\n\tif (v554) goto L_00BC;\n\t// 184 IsInst v477 @ X0_v51, typeof(System.String), \"'\"\n\tv427 = v236.Length;\nL_00BC:\n\tv558 = v427 < 4;\n\tv401 = ~v558;\n\tv392 = v427 - 4;\n\tv374 = v392 == 0;\n\tv559 = ~v401;\n\tv325 = v559 | v374;\n\tif (v325) goto L_015E;\n\tv236[4] = \"'\";\n\tv213 = v85 + msg.m_stringLength;\n\tgoto L_010C;\nL_00D1:\n\tgoto L_00D9;\n\tv533 = *([v514 @ X0_v22+E0]);\n\tv534 = v533 == 0;\n\tv535 = ~v534;\n\tif (v535) goto L_00D9;\n\tv537 = \"il2cpp_codegen_runtime_class_init\"(v514, v311, v213, v212, msg, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_00D9:\n\tv542 = LipingShare.LCLib.Asn1Processor.Asn1Util::GenStr(v143, 0x20);\n\tv544 = v542 == 0;\n\tif (v544) goto L_00E3;\n\t// 224 IsInst v478 @ X0_v42, typeof(System.String), v542 @ X0_v35 (System.String)\nL_00E3:\n\tv428 = v236.Length;\n\tv551 = v236.Length < 3;\n\tv397 = ~v551;\n\tv388 = v236.Length - 3;\n\tv370 = v388 == 0;\n\tv552 = ~v397;\n\tv321 = v552 | v370;\n\tif (v321) goto L_015E;\n\tv236[3] = v542;\n\tv556 = \"'\" == 0;\n\tif (v556) goto L_00FA;\n\t// 246 IsInst v479 @ X0_v40, typeof(System.String), \"'\"\n\tv428 = v236.Length;\nL_00FA:\n\tv561 = v428 < 4;\n\tv402 = ~v561;\n\tv393 = v428 - 4;\n\tv375 = v393 == 0;\n\tv562 = ~v402;\n\tv326 = v562 | v375;\n\tif (v326) goto L_015E;\n\tv236[4] = \"'\";\nL_010C:\n\tv576 = System.String::Substring(v573, v572, v213);\n\tv577 = v576 == 0;\n\tif (v577) goto L_0116;\n\t// 275 IsInst v480 @ X0_v32, typeof(System.String), v576 @ X0_v24 (System.String)\nL_0116:\n\tv429 = v236.Length;\n\tv580 = v236.Length < 5;\n\tv398 = ~v580;\n\tv389 = v236.Length - 5;\n\tv371 = v389 == 0;\n\tv581 = ~v398;\n\tv322 = v581 | v371;\n\tif (v322) goto L_015E;\n\tv236[5] = v576;\n\tv583 = \"'\" == 0;\n\tif (v583) goto L_012D;\n\t// 297 IsInst v481 @ X0_v30, typeof(System.String), \"'\"\n\tv429 = v236.Length;\nL_012D:\n\tv585 = v429 < 6;\n\tv403 = ~v585;\n\tv394 = v429 - 6;\n\tv376 = v394 == 0;\n\tv586 = ~v403;\n\tv327 = v586 | v376;\n\tif (v327) goto L_015E;\n\tv236[6] = \"'\";\n\tv190 = System.String::Concat(v236);\n\tv140 = msg.m_stringLength;\n\tv85 = v85 + v147;\n\tv170 = v156 < msg.m_stringLength;\n\tif (v170) goto L_0041;\nL_015D:\n\treturn v171;\nL_015E:\n\tv430 = new System.IndexOutOfRangeException();\n\tgoto L_0163;\n\tv500 = new System.ArrayTypeMismatchException();\nL_0163:\n\tthrow v506;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 210 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string FormatLineString(string lStr, int indent, int lineLen, string msg)
		{
			//IL_00cc: Expected O, but got I4
			//IL_05bf: Expected O, but got I
			//IL_0138: Expected O, but got I4
			//IL_061d: Expected O, but got I
			//IL_0189: Expected O, but got I4
			//IL_0359: Expected O, but got I4
			//IL_0385: Expected O, but got I4
			//IL_021c: Expected O, but got I4
			//IL_0248: Expected O, but got I4
			//IL_070b: Expected O, but got I
			//IL_067b: Expected O, but got I
			//IL_0407: Expected O, but got I4
			//IL_02ca: Expected O, but got I4
			//IL_0458: Expected O, but got I4
			//IL_0484: Expected O, but got I4
			//IL_0769: Expected O, but got I
			//IL_0506: Expected O, but got I4
			int length = msg.Length;
			bool flag = msg.Length < 1;
			string result = "";
			if (!flag)
			{
				int num2 = default(int);
				int num = num2 + 3;
				int num3 = num2 + 3;
				int num5 = default(int);
				int num4 = num5 - num;
				int num6 = num3 - num5;
				int num7 = 0;
				int num8 = 0;
				string text = "";
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				while (true)
				{
					string[] array = new string[7];
					if (text != null)
					{
						object obj = text as string;
					}
					object obj2 = array.Length;
					int num9;
					int startIndex;
					string text3;
					if (array.Length != 0)
					{
						array[0] = text;
						if ("\r\n" != null)
						{
							object obj3 = "\r\n" as string;
							obj2 = array.Length;
						}
						bool flag2 = (long)(IntPtr)obj2 < 1L;
						bool flag3 = !flag2;
						object obj4 = (long)(IntPtr)obj2 - 1L;
						bool flag4 = obj4 == null;
						bool flag5 = !flag3;
						if (!(flag5 || flag4))
						{
							array[1] = "\r\n";
							if (lStr != null)
							{
								object obj5 = lStr as string;
								obj2 = array.Length;
							}
							bool flag6 = (long)(IntPtr)obj2 < 2L;
							bool flag7 = !flag6;
							object obj6 = (long)(IntPtr)obj2 - 2L;
							bool flag8 = obj6 == null;
							bool flag9 = !flag7;
							if (!(flag9 || flag8))
							{
								array[2] = lStr;
								num9 = num7 + num4;
								if (num9 > length)
								{
									string text2 = Asn1Util.GenStr(num, ' ');
									if (text2 != null)
									{
										object obj7 = text2 as string;
									}
									object obj8 = array.Length;
									bool flag10 = array.Length < 3;
									bool flag11 = !flag10;
									object obj9 = array.Length - 3;
									bool flag12 = obj9 == null;
									bool flag13 = !flag11;
									if (!(flag13 || flag12))
									{
										array[3] = text2;
										if ("'" != null)
										{
											object obj10 = "'" as string;
											obj8 = array.Length;
										}
										bool flag14 = (long)(IntPtr)obj8 < 4L;
										bool flag15 = !flag14;
										object obj11 = (long)(IntPtr)obj8 - 4L;
										bool flag16 = obj11 == null;
										bool flag17 = !flag15;
										if (!(flag17 || flag16))
										{
											array[4] = "'";
											num2 = num8 + msg.Length;
											startIndex = num7;
											text3 = msg;
											goto IL_06b0;
										}
									}
								}
								else
								{
									string text4 = Asn1Util.GenStr(num, ' ');
									if (text4 != null)
									{
										object obj12 = text4 as string;
									}
									object obj13 = array.Length;
									bool flag18 = array.Length < 3;
									bool flag19 = !flag18;
									object obj14 = array.Length - 3;
									bool flag20 = obj14 == null;
									bool flag21 = !flag19;
									if (!(flag21 || flag20))
									{
										array[3] = text4;
										if ("'" != null)
										{
											object obj15 = "'" as string;
											obj13 = array.Length;
										}
										bool flag22 = (long)(IntPtr)obj13 < 4L;
										bool flag23 = !flag22;
										object obj16 = (long)(IntPtr)obj13 - 4L;
										bool flag24 = obj16 == null;
										bool flag25 = !flag23;
										if (!(flag25 || flag24))
										{
											array[4] = "'";
											num2 = num4;
											startIndex = num7;
											text3 = msg;
											goto IL_06b0;
										}
									}
								}
							}
						}
					}
					goto IL_0583;
					IL_06b0:
					string text5 = text3.Substring(startIndex, num2);
					if (text5 != null)
					{
						object obj17 = text5 as string;
					}
					object obj18 = array.Length;
					bool flag26 = array.Length < 5;
					bool flag27 = !flag26;
					object obj19 = array.Length - 5;
					bool flag28 = obj19 == null;
					bool flag29 = !flag27;
					if (!(flag29 || flag28))
					{
						array[5] = text5;
						if ("'" != null)
						{
							object obj20 = "'" as string;
							obj18 = array.Length;
						}
						bool flag30 = (long)(IntPtr)obj18 < 6L;
						bool flag31 = !flag30;
						object obj21 = (long)(IntPtr)obj18 - 6L;
						bool flag32 = obj21 == null;
						bool flag33 = !flag31;
						if (!(flag33 || flag32))
						{
							array[6] = "'";
							string text6 = string.Concat(array);
							length = msg.Length;
							num8 += num6;
							bool flag34 = num9 < msg.Length;
							result = text6;
							num7 = num9;
							text = text6;
							if (!flag34)
							{
								break;
							}
							continue;
						}
					}
					goto IL_0583;
					IL_0583:
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex2;
				}
			}
			return result;
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x15CE4DC", Offset = "0x15CE4DC", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv40 = *([1ED8268]);\n\tv41 = *([v40 @ X8_v46]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, lStr, indent, lineLen, msg, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv57 = 0 | 1;\n\t*([20299FD]) = v57;\nL_0021:\n\tv125 = msg.m_stringLength;\n\tv73 = msg.m_stringLength < 1;\n\tif (v73) goto L_0114;\n\tv141 = v207 + 3;\n\tv142 = v207 + 3;\n\tv131 = v206 - v141;\n\tv145 = v142 - v206;\nL_003E:\n\t// 62 NewArr v230 @ X0_v9 (System.String[]), typeof(System.String[]), 5\n\tv262 = v213 == 0;\n\tif (v262) goto L_004A;\n\t// 71 IsInst v286 @ X0_v50, typeof(System.String), v213 @ X25_v5 (System.String)\nL_004A:\n\tv382 = v230.Length;\n\tv293 = v230.Length == 0;\n\tif (v293) goto L_0115;\n\tv230[0] = v213;\n\tv295 = \"\\r\\n\" == 0;\n\tif (v295) goto L_0057;\n\t// 83 IsInst v424 @ X0_v48, typeof(System.String), \"\r\n\"\n\tv382 = v230.Length;\nL_0057:\n\tv443 = v382 < 1;\n\tv364 = ~v443;\n\tv358 = v382 - 1;\n\tv346 = v358 == 0;\n\tv444 = ~v364;\n\tv312 = v444 | v346;\n\tif (v312) goto L_0115;\n\tv230[1] = \"\\r\\n\";\n\tv448 = lStr == 0;\n\tif (v448) goto L_006E;\n\t// 106 IsInst v425 @ X0_v47, typeof(System.String), lStr @ X1 (System.String)\n\tv382 = v230.Length;\nL_006E:\n\tv451 = v382 < 2;\n\tv365 = ~v451;\n\tv359 = v382 - 2;\n\tv347 = v359 == 0;\n\tv452 = ~v365;\n\tv313 = v452 | v347;\n\tif (v313) goto L_0115;\n\tv230[2] = lStr;\n\tv151 = v210 + v131;\n\tv396 = v151 <= v125;\n\tif (v396) goto L_00B6;\n\tgoto L_0097;\n\tv464 = *([v456 @ X0_v22+E0]);\n\tv465 = v464 == 0;\n\tv466 = ~v465;\n\tif (v466) goto L_0097;\n\tv468 = \"il2cpp_codegen_runtime_class_init\"(v456, v304, v207, v206, msg, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0097:\n\tv473 = LipingShare.LCLib.Asn1Processor.Asn1Util::GenStr(v141, 0x20);\n\tv484 = v473 == 0;\n\tif (v484) goto L_00A2;\n\t// 158 IsInst v426 @ X0_v44, typeof(System.String), v473 @ X0_v40 (System.String)\nL_00A2:\n\tv488 = v230.Length < 3;\n\tv361 = ~v488;\n\tv355 = v230.Length - 3;\n\tv343 = v355 == 0;\n\tv489 = ~v361;\n\tv309 = v489 | v343;\n\tif (v309) goto L_0115;\n\tv230[3] = v473;\n\tv207 = v91 + msg.m_stringLength;\n\tgoto L_00DA;\nL_00B6:\n\tgoto L_00BE;\n\tv474 = *([v456 @ X0_v22+E0]);\n\tv475 = v474 == 0;\n\tv476 = ~v475;\n\tif (v476) goto L_00BE;\n\tv478 = \"il2cpp_codegen_runtime_class_init\"(v456, v304, v207, v206, msg, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_00BE:\n\tv483 = LipingShare.LCLib.Asn1Processor.Asn1Util::GenStr(v141, 0x20);\n\tv485 = v483 == 0;\n\tif (v485) goto L_00C9;\n\t// 197 IsInst v427 @ X0_v36, typeof(System.String), v483 @ X0_v32 (System.String)\nL_00C9:\n\tv492 = v230.Length < 3;\n\tv362 = ~v492;\n\tv356 = v230.Length - 3;\n\tv344 = v356 == 0;\n\tv493 = ~v362;\n\tv310 = v493 | v344;\n\tif (v310) goto L_0115;\n\tv230[3] = v483;\nL_00DA:\n\tv505 = System.String::Substring(v502, v501, v207);\n\tv506 = v505 == 0;\n\tif (v506) goto L_00E5;\n\t// 225 IsInst v428 @ X0_v29, typeof(System.String), v505 @ X0_v24 (System.String)\nL_00E5:\n\tv509 = v230.Length < 4;\n\tv363 = ~v509;\n\tv357 = v230.Length - 4;\n\tv345 = v357 == 0;\n\tv510 = ~v363;\n\tv311 = v510 | v345;\n\tif (v311) goto L_0115;\n\tv230[4] = v505;\n\tv185 = System.String::Concat(v230);\n\tv125 = msg.m_stringLength;\n\tv91 = v91 + v145;\n\tv163 = v151 < msg.m_stringLength;\n\tif (v163) goto L_003E;\nL_0114:\n\treturn v164;\nL_0115:\n\tv383 = new System.IndexOutOfRangeException();\n\tgoto L_011A;\n\tv441 = new System.ArrayTypeMismatchException();\nL_011A:\n\tthrow v447;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 176 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string FormatLineHexString(string lStr, int indent, int lineLen, string msg)
		{
			//IL_00cc: Expected O, but got I4
			//IL_04a8: Expected O, but got I
			//IL_0138: Expected O, but got I4
			//IL_0506: Expected O, but got I
			//IL_0189: Expected O, but got I4
			//IL_031e: Expected O, but got I4
			//IL_023e: Expected O, but got I4
			//IL_03c0: Expected O, but got I4
			int length = msg.Length;
			bool flag = msg.Length < 1;
			string result = "";
			if (!flag)
			{
				int num2 = default(int);
				int num = num2 + 3;
				int num3 = num2 + 3;
				int num5 = default(int);
				int num4 = num5 - num;
				int num6 = num3 - num5;
				int num7 = 0;
				int num8 = 0;
				string text = "";
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				while (true)
				{
					string[] array = new string[5];
					if (text != null)
					{
						object obj = text as string;
					}
					object obj2 = array.Length;
					if (array.Length != 0)
					{
						array[0] = text;
						if ("\r\n" != null)
						{
							object obj3 = "\r\n" as string;
							obj2 = array.Length;
						}
						bool flag2 = (long)(IntPtr)obj2 < 1L;
						bool flag3 = !flag2;
						object obj4 = (long)(IntPtr)obj2 - 1L;
						bool flag4 = obj4 == null;
						bool flag5 = !flag3;
						if (!(flag5 || flag4))
						{
							array[1] = "\r\n";
							if (lStr != null)
							{
								object obj5 = lStr as string;
								obj2 = array.Length;
							}
							bool flag6 = (long)(IntPtr)obj2 < 2L;
							bool flag7 = !flag6;
							object obj6 = (long)(IntPtr)obj2 - 2L;
							bool flag8 = obj6 == null;
							bool flag9 = !flag7;
							if (!(flag9 || flag8))
							{
								array[2] = lStr;
								int num9 = num7 + num4;
								int startIndex;
								string text3;
								if (num9 > length)
								{
									string text2 = Asn1Util.GenStr(num, ' ');
									if (text2 != null)
									{
										object obj7 = text2 as string;
									}
									bool flag10 = array.Length < 3;
									bool flag11 = !flag10;
									object obj8 = array.Length - 3;
									bool flag12 = obj8 == null;
									bool flag13 = !flag11;
									if (flag13 || flag12)
									{
										goto IL_046c;
									}
									array[3] = text2;
									num2 = num8 + msg.Length;
									startIndex = num7;
									text3 = msg;
								}
								else
								{
									string text4 = Asn1Util.GenStr(num, ' ');
									if (text4 != null)
									{
										object obj9 = text4 as string;
									}
									bool flag14 = array.Length < 3;
									bool flag15 = !flag14;
									object obj10 = array.Length - 3;
									bool flag16 = obj10 == null;
									bool flag17 = !flag15;
									if (flag17 || flag16)
									{
										goto IL_046c;
									}
									array[3] = text4;
									num2 = num4;
									startIndex = num7;
									text3 = msg;
								}
								string text5 = text3.Substring(startIndex, num2);
								if (text5 != null)
								{
									object obj11 = text5 as string;
								}
								bool flag18 = array.Length < 4;
								bool flag19 = !flag18;
								object obj12 = array.Length - 4;
								bool flag20 = obj12 == null;
								bool flag21 = !flag19;
								if (!(flag21 || flag20))
								{
									array[4] = text5;
									string text6 = string.Concat(array);
									length = msg.Length;
									num8 += num6;
									bool flag22 = num9 < msg.Length;
									result = text6;
									num7 = num9;
									text = text6;
									if (!flag22)
									{
										break;
									}
									continue;
								}
							}
						}
					}
					goto IL_046c;
					IL_046c:
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex2;
				}
			}
			return result;
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x15CEB60", Offset = "0x15CEB60", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF0250]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20299FE]) = v38;\nL_0019:\n\tthis.requireRecalculatePar = 1;\n\tthis.parseEncapsulatedData = 1;\n\tthis.path = \"\";\n\tSystem.Object::.ctor(this);\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::Init(this);\n\tthis.dataOffset = 0;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Asn1Node()
		{
			//IL_0048: Expected I8, but got I4
			base._002Ector();
			requireRecalculatePar = true;
			isIndefiniteLength = false;
			parseEncapsulatedData = true;
			path = "";
			Init();
			dataOffset = 0L;
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x15CEBE8", Offset = "0x15CEBE8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.requireRecalculatePar = 0;\n\tv12 = LipingShare.LCLib.Asn1Processor.Asn1Node::InternalLoadData(this, xdata);\n\tthis.requireRecalculatePar = 1;\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::RecalculateTreePar(this);\nL_0014:\n\treturn v12;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_002D;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\tX0 = X19;\n\t*([X19+60]) = X8;\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::RecalculateTreePar(X0, X1);\n\tif (TEMP) goto L_0014;\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_002D:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool LoadData(Stream xdata)
		{
			requireRecalculatePar = false;
			bool result = InternalLoadData(xdata);
			requireRecalculatePar = true;
			RecalculateTreePar();
			return result;
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0x15CEDAC", Offset = "0x15CEDAC", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F04078]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, xdata, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20299FF]) = v43;\nL_001C:\n\tv49 = System.Collections.ArrayList::get_Count(this.childNodeList);\n\tv104 = System.IO.Stream::WriteByte(xdata, this.tag);\n\tgoto L_0035;\n\tv132 = *([v108 @ X0_v11+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0035;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v108, v100, v103, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0035:\n\tv141 = LipingShare.LCLib.Asn1Processor.Asn1Util::DERLengthEncode(xdata, this.dataLength);\n\tv152 = this.tag != 3;\n\tif (v152) goto L_0048;\n\tv206 = System.IO.Stream::WriteByte(xdata, this.unusedBits);\nL_0048:\n\tv209 = v49 == 0;\n\tif (v209) goto L_006D;\n\tv220 = v49 < 1;\n\tif (v220) goto L_007F;\nL_0059:\n\tv92 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(this, v83);\n\tv243 = LipingShare.LCLib.Asn1Processor.Asn1Node::SaveData(v92, xdata);\n\tv83 = v83 + 1;\n\tv227 = v49 > v83;\n\tif (v227) goto L_0059;\n\tgoto L_007F;\nL_006D:\n\tv221 = this.data;\n\tv222 = this.data == 0;\n\tif (v222) goto L_007F;\n\tv242 = System.IO.Stream::Write(xdata, this.data, 0, v221.Length);\nL_007F:\n\treturn 1;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool SaveData(Stream xdata)
		{
			int count = childNodeList.Count;
			xdata.WriteByte(Tag);
			int num = Asn1Util.DERLengthEncode(xdata, (ulong)DataLength);
			if (Tag == 3)
			{
				xdata.WriteByte(unusedBits);
			}
			if (count != 0)
			{
				if (count >= 1)
				{
					int num2 = 0;
					do
					{
						Asn1Node childNode = GetChildNode(num2);
						bool flag = childNode.SaveData(xdata);
						num2++;
					}
					while (count > num2);
				}
			}
			else
			{
				byte[] array = data;
				if (data != null)
				{
					xdata.Write(data, 0, array.Length);
				}
			}
			return true;
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x15CF138", Offset = "0x15CF138", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ED6318]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029A00]) = v40;\nL_0014:\n\tv117 = this.childNodeList;\n\tthis.data = 0;\nL_001E:\n\tv103 = System.Collections.ArrayList::get_Count(v117);\n\tv148 = this.childNodeList;\n\tv126 = v112 >= v103;\n\tif (v126) goto L_005E;\n\tv164 = System.Collections.ArrayList::get_Item(v148, v112);\n\tv203 = *([v164 @ X0_v13 (LipingShare.LCLib.Asn1Processor.Asn1Node)]);\n\tv51 = LipingShare.LCLib.Asn1Processor.Asn1Node;\n\tgoto L_0045;\nL_0045:\n\tv47 = *([v51 @ X1_v8 (Il2CppClass<LipingShare.LCLib.Asn1Processor.Asn1Node>)+128]) << 3;\n\tv228 = *([v203 @ X8_v9 (Il2CppClass<LipingShare.LCLib.Asn1Processor.Asn1Node>)+C8]) + v47;\n\tv148 = *([v228 @ X8_v12-8]);\n\tv61 = v61_asT == 0;\n\tif (v61) goto L_0068;\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::ClearAll(v164);\n\tv117 = this.childNodeList;\n\tv112 = v112 + 1;\n\tv230 = this.childNodeList == 0;\n\tv105 = ~v230;\n\tif (v105) goto L_001E;\n\tthrow System.NullReferenceException;\nL_005E:\n\tv153 = System.Collections.ArrayList::Clear(v148);\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::RecalculateTreePar(this);\n\treturn;\nL_0068:\n\tv225 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClearAll()
		{
			//IL_0051: Expected I, but got O
			//IL_005f: Expected I, but got O
			//IL_0090: Expected O, but got I
			//IL_00a0: Expected O, but got I
			ArrayList arrayList = childNodeList;
			data = null;
			int num = 0;
			while (true)
			{
				int count = arrayList.Count;
				ArrayList arrayList2 = childNodeList;
				if (num < count)
				{
					Asn1Node asn1Node = (Asn1Node)arrayList2.get_Item(num);
					IntPtr intPtr = (IntPtr)asn1Node;
					IntPtr intPtr2 = (IntPtr)typeof(Asn1Node);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X1_v8 (Il2CppClass<LipingShare.LCLib.Asn1Processor.Asn1Node>)+128]");
					int num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ X8_v9 (Il2CppClass<LipingShare.LCLib.Asn1Processor.Asn1Node>)+C8]");
					object obj = 0L + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X8_v12-8]");
					arrayList2 = (ArrayList)0;
					Asn1Node asn1Node2 = asn1Node as Asn1Node;
					if (asn1Node2 == null)
					{
						break;
					}
					asn1Node.ClearAll();
					arrayList = childNodeList;
					num++;
					if (childNodeList == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				arrayList2.Clear();
				RecalculateTreePar();
				return;
			}
			InvalidCastException ex = new InvalidCastException();
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x15CF234", Offset = "0x15CF234", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = System.Collections.ArrayList::Add(this.childNodeList, xdata);\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::RecalculateTreePar(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddChild(Asn1Node xdata)
		{
			int num = childNodeList.Add(xdata);
			RecalculateTreePar();
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x15CF06C", Offset = "0x15CF06C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC5A08]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029A01]) = v41;\nL_001B:\n\tv47 = System.Collections.ArrayList::get_Count(this.childNodeList);\n\tv59 = v47 <= index;\n\tif (v59) goto L_FFFFFFFF;\n\tv127 = System.Collections.ArrayList::get_Item(this.childNodeList, index);\n\tv120 = v127 == 0;\n\tif (v120) goto L_005A;\n\tgoto L_FFFFFFFF;\n\tv142 = v142_asT != 0;\n\tif (v142) goto L_005A;\n\tthrow System.InvalidCastException;\nL_005A:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Asn1Node GetChildNode(int index)
		{
			int count = childNodeList.Count;
			Asn1Node result;
			if (count > index)
			{
				object obj = childNodeList.get_Item(index);
				bool flag = obj == null;
				result = (Asn1Node)obj;
				if (!flag)
				{
					Asn1Node asn1Node = obj as Asn1Node;
					bool flag2 = asn1Node != null;
					result = (Asn1Node)obj;
					if (!flag2)
					{
						throw new InvalidCastException();
					}
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x15CF560", Offset = "0x15CF560", Length = "0xFC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv36 = *([1EAAC00]);\n\tv37 = *([v36 @ X8_v79]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, startNode, lineLen, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2029A03]) = v54;\nL_001E:\n\tv57 = v52.tag;\n\tv59 = v52.tag - 2;\n\tv61 = v59 < 0x1C;\n\tv62 = ~v61;\n\tv63 = v59 - 0x1C;\n\tv65 = v63 == 0;\n\tv70 = ~v65;\n\tv71 = v62 & v70;\n\tif (v71) goto L_032F;\n\tv73 = 0x183F000 + 0x33C;\n\tv75 = *([v73 @ X10_v2 (System.Int32)+v59 @ X9_v1 (System.Int32)*4]) + v73;\n\t// 50 IndirectJump v75 @ X9_v17, v52 @ X0_v1 (LipingShare.LCLib.Asn1Processor.Asn1Node), v52 @ X0_v1 (LipingShare.LCLib.Asn1Processor.Asn1Node), startNode @ X1 (LipingShare.LCLib.Asn1Processor.Asn1Node), lineLen @ X2 (System.Int32), methodInfo @ X3 (Il2CppMethodInfo), v40 @ X4 (System.Int32), v41 @ X5, v42 @ X6, v43 @ X7, v44 @ V0, v45 @ V1, v46 @ V2, v47 @ V3, v48 @ V4, v49 @ V5, v50 @ V6, v51 @ V7\n\tX8 = *([1EFE3C0]);\n\tX1 = 5;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X21+18]);\n\tX25 = *([1F0B2D0]);\n\tX23 = X0;\n\tX1 = &stack[18];\n\tstack[18] = X8;\n\tX0 = *([X25]);\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX24 = X0;\n\t// 66 ConditionalJump @b311, TEMP\n\tif (TEMP) goto L_004B;\n\tX8 = *([X23]);\n\tX0 = X24;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\nL_004B:\n\tX8 = *([X23+18]);\n\tif (TEMP) goto L_0634;\n\t*([X23+20]) = X24;\n\tX8 = *([X21+20]);\n\tX0 = *([X25]);\n\tX1 = &stack[10];\n\tstack[10] = X8;\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX24 = X0;\n\tif (TEMP) goto L_005D;\n\tX8 = *([X23]);\n\tX0 = X24;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\nL_005D:\n\tX8 = *([X23+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0634;\n\t*([X23+28]) = X24;\n\tX8 = *([X21+28]);\n\tX0 = *([X25]);\n\tX1 = &stack[8];\n\tstack[8] = X8;\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX24 = X0;\n\tif (TEMP) goto L_0079;\n\tX8 = *([X23]);\n\tX0 = X24;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\nL_0079:\n\tX8 = *([X23+18]);\n\tC = X8 < 2;\n\tC = ~C;\n\tTEMP1 = X8 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 2;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0634;\n\tX0 = X21;\n\tX1 = X20;\n\t*([X23+30]) = X24;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetIndentStr(X0, X1, X2);\n\tX24 = X0;\n\tif (TEMP) goto L_0093;\n\tX8 = *([X23]);\n\tX0 = X24;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\nL_0093:\n\tX8 = *([X23+18]);\n\tC = X8 < 3;\n\tC = ~C;\n\tTEMP1 = X8 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 3;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0634;\n\tX0 = X21;\n\t*([X23+38]) = X24;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_TagName(X0, X1);\n\tX24 = X0;\n\tif (TEMP) goto L_00AC;\n\tX8 = *([X23]);\n\tX0 = X24;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\nL_00AC:\n\tX8 = *([X23+18]);\n\tC = X8 < 4;\n\tC = ~C;\n\tTEMP1 = X8 - 4;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 4;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0634;\n\t*([X23+40]) = X24;\n\tX8 = *([1EDBD60]);\n\tX1 = X23;\n\tX2 = 0;\n\tX0 = *([X8]);\n\tX0 = System.String::Format(X0, X1, X2);\n\tX8 = *([X21+10]);\n\tX23 = X0;\n\tC = X8 < 0xC;\n\tC = ~C;\n\tTEMP1 = X8 - 0xC;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0xC;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00DD;\n\tX8 = *([1EBCCC0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX24 = X0;\n\tSystem.Text.UTF8Encoding::.ctor(X0, X1);\n\t// 213 ConditionalJump @b311, TEMP\n\tX8 = *([X24]);\n\tX1 = *([X21+30]);\n\tX0 = X24;\n\tX9 = *([X8+350]);\n\tX2 = *([X8+358]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00EC;\nL_00DD:\n\tX8 = 0x1EA6000;\n\tX8 = *([1EA6770]);\n\tX24 = *([X21+30]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00EA;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00EA;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00EA:\n\tX0 = X24;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Util::BytesToString(X0, X1);\nL_00EC:\n\tX24 = X0;\n\t// 238 ConditionalJump @b311, TEMP\n\t// 240 ConditionalJump @b311, TEMP\n\tX8 = *([X23+10]);\n\tX9 = *([X24+10]);\n\tX8 = X9 + X8;\n\tC = X8 < X19;\n\tC = ~C;\n\tTEMP1 = X8 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X19;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tif (TEMPCOND) goto L_0171;\n\tX8 = *([1ED7A60]);\n\tX1 = 5;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX25 = X0;\n\tif (TEMP) goto L_063B;\n\tif (TEMP) goto L_010F;\n\tX8 = *([X25]);\n\tX0 = X22;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\nL_010F:\n\tX8 = *([X25+18]);\n\tif (TEMP) goto L_0634;\n\tX8 = *([X25]);\n\t*([X25+20]) = X22;\n\tX0 = X23;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X25+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0634;\n\t*([X25+28]) = X23;\n\tX22 = *([1EF2430]);\n\tX0 = *([X22]);\n\tif (TEMP) goto L_0132;\n\tX8 = *([X25]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X25+18]);\nL_0132:\n\tC = X8 < 2;\n\tC = ~C;\n\tTEMP1 = X8 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 2;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0634;\n\tX8 = *([X22]);\n\tX9 = *([X25]);\n\tX0 = X24;\n\t*([X25+30]) = X8;\n\tX1 = *([X9+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X25+18]);\n\tC = X8 < 3;\n\tC = ~C;\n\tTEMP1 = X8 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 3;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0634;\n\t*([X25+38]) = X24;\n\tX22 = *([1EAB950]);\n\tX0 = *([X22]);\n\tif (TEMP) goto L_015F;\n\tX8 = *([X25]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X25+18]);\nL_015F:\n\tC = X8 < 4;\n\tC = ~C;\n\tTEMP1 = X8 - 4;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 4;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0634;\n\tX8 = *([X22]);\n\tX0 = X25;\n\t*([X25+40]) = X8;\nL_016F:\n\tv684 = System.String::Concat(v298);\n\tgoto L_0606;\nL_0171:\n\tX0 = X21;\n\tX1 = X20;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetIndentStr(X0, X1, X2);\n\tif (TEMP) goto L_063B;\n\tX2 = *([X0+10]);\n\tX8 = *([1EF3B90]);\n\tX3 = X19;\n\tX4 = X24;\n\tX1 = *([X8]);\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::FormatLineString(X0, X1, X2, X3, X4, X5);\n\tX8 = *([1F0C6A8]);\n\tX2 = X0;\n\tX0 = X22;\n\tX1 = X23;\nL_0184:\n\tv684 = System.String::Concat(\"\", v646, v718, \"\\r\\n\");\n\tgoto L_0606;\n\tX8 = *([X21+30]);\n\tif (TEMP) goto L_0566;\n\tX8 = *([X21+20]);\n\tX9 = *([1EFE3C0]);\n\tC = X8 < 7;\n\tC = ~C;\n\tTEMP1 = X8 - 7;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 7;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX0 = *([X9]);\n\tTEMPCOND = N == V;\n\tTEMPCOND2 = ~Z;\n\tTEMPCOND = TEMPCOND & TEMPCOND2;\n\tif (TEMPCOND) goto L_0569;\n\tX1 = 0 | 6;\n\tX0 = 0x8D8214(X0, X1,\n// ... truncated")]
		public string GetText(Asn1Node startNode, int lineLen)
		{
			//IL_0029: Expected O, but got I
			//IL_077f: Expected O, but got I4
			//IL_0173: Expected O, but got I4
			//IL_0842: Expected O, but got I4
			//IL_0236: Expected O, but got I4
			//IL_08fe: Expected O, but got I4
			//IL_02f2: Expected O, but got I4
			//IL_09aa: Expected O, but got I4
			//IL_03a8: Expected O, but got I4
			//IL_0a3e: Expected I, but got O
			//IL_0a64: Expected I4, but got I8
			//IL_0c95: Expected I, but got O
			//IL_0518: Expected O, but got I4
			//IL_0bc8: Expected O, but got I4
			//IL_05fa: Expected O, but got I4
			//IL_0c25: Expected O, but got I4
			byte b = Tag;
			int num = Tag - 2;
			bool flag = num < 28;
			bool flag2 = !flag;
			int num2 = num - 28;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25423872 + 828;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X10_v2 (System.Int32)+v59 @ X9_v1 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v75 @ X9_v17 (should have been resolved before IL gen)");
			}
			int num4 = Tag & 0x1F;
			object[] array = new object[5];
			long num5 = dataOffset;
			string text4;
			if (num4 == 6)
			{
				object obj2 = num5;
				if (obj2 != null)
				{
					object obj3 = obj2 as object;
				}
				b = (byte)array.Length;
				if (array.Length != 0)
				{
					array[0] = obj2;
					long num6 = DataLength;
					object obj4 = num6;
					if (obj4 != null)
					{
						object obj5 = obj4 as object;
					}
					b = (byte)array.Length;
					bool flag5 = array.Length < 1;
					bool flag6 = !flag5;
					object obj6 = array.Length - 1;
					bool flag7 = obj6 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[1] = obj4;
						long num7 = lengthFieldBytes;
						object obj7 = num7;
						if (obj7 != null)
						{
							object obj8 = obj7 as object;
						}
						b = (byte)array.Length;
						bool flag9 = array.Length < 2;
						bool flag10 = !flag9;
						object obj9 = array.Length - 2;
						bool flag11 = obj9 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[2] = obj7;
							string indentStr = GetIndentStr(startNode);
							if (indentStr != null)
							{
								object obj10 = indentStr as object;
							}
							b = (byte)array.Length;
							bool flag13 = array.Length < 3;
							bool flag14 = !flag13;
							object obj11 = array.Length - 3;
							bool flag15 = obj11 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[3] = indentStr;
								string tagName = TagName;
								if (tagName != null)
								{
									object obj12 = tagName as object;
								}
								b = (byte)array.Length;
								bool flag17 = array.Length < 4;
								bool flag18 = !flag17;
								object obj13 = array.Length - 4;
								bool flag19 = obj13 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									array[4] = tagName;
									string text = string.Format("{0,6}|{1,6}|{2,7}|{3} {4} : ", array);
									string text2 = Asn1Util.BytesToString(data);
									int num8 = text2.Length + text.Length;
									if (num8 >= lineLen)
									{
										string indentStr2 = GetIndentStr(startNode);
										string text3 = ((Asn1Node)(object)indentStr2).FormatLineString("      |      |       | ", indentStr2.Length, lineLen, text2);
										text4 = "" + text + text3 + "\r\n";
										IntPtr intPtr = (IntPtr)"\r\n";
										goto IL_0a43;
									}
									string[] array2 = new string[5];
									if ("" != null)
									{
										object obj14 = "" as string;
									}
									b = (byte)array2.Length;
									if (array2.Length != 0)
									{
										array2[0] = "";
										object obj15 = text as string;
										b = (byte)array2.Length;
										bool flag21 = array2.Length < 1;
										bool flag22 = !flag21;
										object obj16 = array2.Length - 1;
										bool flag23 = obj16 == null;
										bool flag24 = !flag22;
										if (!(flag24 || flag23))
										{
											array2[1] = text;
											if ("'" != null)
											{
												object obj17 = "'" as string;
												b = (byte)array2.Length;
											}
											bool flag25 = b < 2;
											bool flag26 = !flag25;
											object obj18 = b - 2;
											bool flag27 = obj18 == null;
											bool flag28 = !flag26;
											if (!(flag28 || flag27))
											{
												array2[2] = "'";
												object obj19 = text2 as string;
												b = (byte)array2.Length;
												bool flag29 = array2.Length < 3;
												bool flag30 = !flag29;
												object obj20 = array2.Length - 3;
												bool flag31 = obj20 == null;
												bool flag32 = !flag30;
												if (!(flag32 || flag31))
												{
													array2[3] = text2;
													if ("'\r\n" != null)
													{
														object obj21 = "'\r\n" as string;
														b = (byte)array2.Length;
													}
													bool flag33 = b < 4;
													bool flag34 = !flag33;
													object obj22 = b - 4;
													bool flag35 = obj22 == null;
													bool flag36 = !flag34;
													if (!(flag36 || flag35))
													{
														array2[4] = "'\r\n";
														text4 = string.Concat(array2);
														goto IL_0a43;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				object obj23 = num5;
				if (obj23 != null)
				{
					object obj24 = obj23 as object;
				}
				b = (byte)array.Length;
				if (array.Length != 0)
				{
					array[0] = obj23;
					long num9 = DataLength;
					object obj25 = num9;
					if (obj25 != null)
					{
						object obj26 = obj25 as object;
					}
					b = (byte)array.Length;
					bool flag37 = array.Length < 1;
					bool flag38 = !flag37;
					object obj27 = array.Length - 1;
					bool flag39 = obj27 == null;
					bool flag40 = !flag38;
					if (!(flag40 || flag39))
					{
						array[1] = obj25;
						long num10 = lengthFieldBytes;
						object obj28 = num10;
						if (obj28 != null)
						{
							object obj29 = obj28 as object;
						}
						b = (byte)array.Length;
						bool flag41 = array.Length < 2;
						bool flag42 = !flag41;
						object obj30 = array.Length - 2;
						bool flag43 = obj30 == null;
						bool flag44 = !flag42;
						if (!(flag44 || flag43))
						{
							array[2] = obj28;
							string indentStr3 = GetIndentStr(startNode);
							if (indentStr3 != null)
							{
								object obj31 = indentStr3 as object;
							}
							b = (byte)array.Length;
							bool flag45 = array.Length < 3;
							bool flag46 = !flag45;
							object obj32 = array.Length - 3;
							bool flag47 = obj32 == null;
							bool flag48 = !flag46;
							if (!(flag48 || flag47))
							{
								array[3] = indentStr3;
								string tagName2 = TagName;
								if (tagName2 != null)
								{
									object obj33 = tagName2 as object;
								}
								bool flag49 = array.Length < 4;
								bool flag50 = !flag49;
								object obj34 = array.Length - 4;
								bool flag51 = obj34 == null;
								bool flag52 = !flag50;
								if (!(flag52 || flag51))
								{
									array[4] = tagName2;
									string baseLine = string.Format("{0,6}|{1,6}|{2,7}|{3} {4} : ", array);
									string hexPrintingStr = GetHexPrintingStr(startNode, baseLine, "      |      |       | ", lineLen);
									text4 = "" + hexPrintingStr;
									IntPtr intPtr = (IntPtr)"      |      |       | ";
									goto IL_0a43;
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_0a43:
			int count = childNodeList.Count;
			int num11 = (int)(count & 0x80000000L);
			bool flag53 = num11 == 0;
			bool flag54 = !flag53;
			string result = text4;
			if (!flag54)
			{
				string listStr = GetListStr(startNode, lineLen);
				string text5 = text4 + listStr;
				result = text5;
			}
			return result;
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x15D0930", Offset = "0x15D0930", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EDB4F0]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pureHexMode, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029A04]) = v41;\nL_0016:\n\tv43 = pureHexMode == 0;\n\tif (v43) goto L_0032;\n\tv98 = v39.data;\n\tgoto L_0026;\nL_0023:\n\tgoto L_0026;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v94, pureHexMode, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tv121 = LipingShare.LCLib.Asn1Processor.Asn1Util::ToHexString(v98);\n\treturnVal1 = LipingShare.LCLib.Asn1Processor.Asn1Util::FormatString(v121, 0x20, 2);\n\treturn returnVal1;\nL_0032:\n\tv52 = v39.tag - 2;\n\tv53 = v52 < 0x1C;\n\tv54 = ~v53;\n\tv55 = v52 - 0x1C;\n\tv57 = v55 == 0;\n\tv62 = ~v57;\n\tv63 = v54 & v62;\n\tif (v63) goto L_005D;\n\tv123 = 0x183F000 + 0x3B0;\n\tv125 = *([v123 @ X10_v2 (System.Int32)+v52 @ X9_v1 (System.Int32)*4]) + v123;\n\t// 67 IndirectJump v125 @ X9_v6, v39 @ X0_v1 (LipingShare.LCLib.Asn1Processor.Asn1Node), v39 @ X0_v1 (LipingShare.LCLib.Asn1Processor.Asn1Node), pureHexMode @ X1 (System.Boolean), methodInfo @ X2 (Il2CppMethodInfo), v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tX8 = *([1EA6770]);\n\tX19 = *([X19+30]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0058;\n\tgoto L_0058;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v95, pureHexMode, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0058:\n\treturnVal2 = LipingShare.LCLib.Asn1Processor.Asn1Util::BytesToString(v39.data);\n\treturn returnVal2;\nL_005D:\n\tv101 = v39.tag & 0x1F;\n\tv95 = LipingShare.LCLib.Asn1Processor.Asn1Util;\n\tv66 = v101 != 6;\n\tif (v66) goto L_00A4;\n\tgoto L_0058;\n\tgoto L_0058;\n\tX8 = *([1F105B0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tSystem.Object::.ctor(X0, X1);\n\tgoto L_008D;\n\tX8 = *([1EBCCC0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tSystem.Text.UTF8Encoding::.ctor(X0, X1);\n\tif (TEMP) goto L_00A9;\n\tX8 = *([X20]);\n\tX1 = *([X19+30]);\n\tX0 = X20;\n\tX3 = *([X8+350]);\n\tX2 = *([X8+358]);\n\tgoto L_009D;\n\tX8 = *([1EA32F8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tLipingShare.LCLib.Asn1Processor.RelativeOid::.ctor(X0, X1);\nL_008D:\n\tX8 = 0x1F0B000;\n\tX21 = *([X19+30]);\n\tX8 = *([1F0BAB8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX2 = 0;\n\tX19 = X0;\n\tSystem.IO.MemoryStream::.ctor(X0, X1, X2);\n\tif (TEMP) goto L_00A9;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX1 = X19;\n\tX3 = *([X8+170]);\n\tX2 = *([X8+178]);\nL_009D:\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 162 ShiftStack 48\n\t// 163 IndirectJump X3, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\nL_00A4:\n\tv170 = *([v95 @ X0_v2 (Il2CppClass<LipingShare.LCLib.Asn1Processor.Asn1Util>)+12E]) & 0x200;\n\tv171 = v170 == 0;\n\tv97 = ~v171;\n\tif (v97) goto L_0023;\n\tgoto L_0026;\nL_00A9:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetDataStr(bool pureHexMode)
		{
			//IL_0114: Expected I, but got O
			//IL_00d8: Expected O, but got I
			byte[] bytes = default(byte[]);
			if (pureHexMode)
			{
				bytes = data;
				goto IL_0019;
			}
			int num = Tag - 2;
			bool flag = num < 28;
			bool flag2 = !flag;
			int num2 = num - 28;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25423872 + 944;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ X10_v2 (System.Int32)+v52 @ X9_v1 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v125 @ X9_v6 (should have been resolved before IL gen)");
			}
			else
			{
				int num4 = Tag & 0x1F;
				IntPtr intPtr = (IntPtr)typeof(Asn1Util);
				if (num4 != 6)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ X0_v2 (Il2CppClass<LipingShare.LCLib.Asn1Processor.Asn1Util>)+12E]");
					if (0 == 0)
					{
						bytes = data;
					}
					goto IL_0019;
				}
			}
			return Asn1Util.BytesToString(data);
			IL_0019:
			string inStr = Asn1Util.ToHexString(bytes);
			return Asn1Util.FormatString(inStr, 32, 2);
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x15CED4C", Offset = "0x15CED4C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this.requireRecalculatePar;\n\tif (v13) goto L_0024;\nL_000C:\n\tv24 = v24.parentNode;\n\tv27 = v24.parentNode == 0;\n\tv23 = ~v27;\n\tif (v23) goto L_000C;\n\tv48 = LipingShare.LCLib.Asn1Processor.Asn1Node::ResetBranchDataLength(v24.parentNode);\n\tv24.dataOffset = 0;\n\tv24.deepness = 0;\n\tv34 = v24.lengthFieldBytes + 1;\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::ResetChildNodePar(this, v24.parentNode, v34);\n\treturn;\nL_0024:\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void RecalculateTreePar()
		{
			//IL_004d: Expected I8, but got I4
			//IL_005b: Expected I8, but got I4
			if (requireRecalculatePar)
			{
				Asn1Node asn1Node = this;
				Asn1Node asn1Node2 = default(Asn1Node);
				asn1Node = asn1Node2;
				do
				{
					asn1Node = asn1Node.ParentNode;
				}
				while (asn1Node.ParentNode != null);
				long num = ResetBranchDataLength(asn1Node.ParentNode);
				asn1Node.dataOffset = 0L;
				asn1Node.deepness = 0L;
				long subOffset = asn1Node.lengthFieldBytes + 1;
				ResetChildNodePar(asn1Node.ParentNode, subOffset);
			}
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x15D0EC0", Offset = "0x15D0EC0", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = node.childNodeList;\n\tv38 = System.Collections.ArrayList::get_Count(v15);\n\tv49 = v38 < 1;\n\tif (v49) goto L_0040;\n\tv171 = node.childNodeList;\nL_0022:\n\t;\n\tv175 = System.Collections.ArrayList::get_Count(v171);\n\tv139 = v175 <= v157;\n\tif (v139) goto L_0047;\n\tv196 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(node, v157);\n\tv200 = LipingShare.LCLib.Asn1Processor.Asn1Node::ResetBranchDataLength(v196);\n\tv171 = node.childNodeList;\n\tv180 = v200 + v180;\n\tv137 = v157 + 1;\n\tv202 = node.childNodeList == 0;\n\tv153 = ~v202;\n\tif (v153) goto L_0022;\n\tthrow System.NullReferenceException;\nL_0040:\n\tv84 = node.data;\n\tv85 = node.data == 0;\n\tif (v85) goto L_FFFFFFFF;\n\tv180 = v84.Length;\n\tgoto L_0047;\nL_0047:\n\tnode.dataLength = v180;\n\tv93 = node.tag != 3;\n\tif (v93) goto L_0056;\n\tv197 = v180 + 1;\n\tnode.dataLength = v197;\nL_0056:\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::ResetDataLengthFieldWidth(node);\n\tv125 = node.dataLength + node.lengthFieldBytes;\n\treturnVal2 = v125 + 1;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected static long ResetBranchDataLength(Asn1Node node)
		{
			//IL_0135: Expected I8, but got I4
			//IL_0127: Expected I8, but got I4
			//IL_0062: Expected I8, but got I4
			ArrayList arrayList = node.childNodeList;
			int count = arrayList.Count;
			long num2;
			if (count >= 1)
			{
				ArrayList arrayList2 = node.childNodeList;
				int num = 0;
				num2 = 0L;
				while (true)
				{
					int count2 = arrayList2.Count;
					if (count2 <= num)
					{
						break;
					}
					Asn1Node childNode = node.GetChildNode(num);
					long num3 = ResetBranchDataLength(childNode);
					arrayList2 = node.childNodeList;
					num2 = num3 + num2;
					int num4 = num + 1;
					bool flag = node.childNodeList == null;
					bool flag2 = !flag;
					num = num4;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
				}
			}
			else
			{
				byte[] array = node.data;
				num2 = ((node.data == null) ? 0 : array.Length);
			}
			node.dataLength = num2;
			if (node.Tag == 3)
			{
				long num5 = num2 + 1;
				node.dataLength = num5;
			}
			ResetDataLengthFieldWidth(node);
			long num6 = node.DataLength + node.lengthFieldBytes;
			return num6 + 1;
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x15D10D4", Offset = "0x15D10D4", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EFE428]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029A06]) = v40;\nL_0017:\n\tv44 = new System.IO.MemoryStream();\n\tSystem.IO.MemoryStream::.ctor(v44);\n\tgoto L_002C;\n\tv66 = *([v51 @ X0_v7+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_002C;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v51, v45, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002C:\n\tv59 = LipingShare.LCLib.Asn1Processor.Asn1Util::DERLengthEncode(v44, node.dataLength);\n\tv98 = System.IO.MemoryStream::get_Length(v44);\n\tnode.lengthFieldBytes = v98;\n\tv90 = *([v44 @ X0_v3 (System.IO.MemoryStream)]);\n\tv74 = *([v90 @ X8_v11 (Il2CppClass<System.IO.MemoryStream>)+220]);\n\tv83 = *([v90 @ X8_v11 (Il2CppClass<System.IO.MemoryStream>)+228]);\n\t// 63 IndirectJump v74 @ X2_v1, v44 @ X0_v3 (System.IO.MemoryStream), v44 @ X0_v3 (System.IO.MemoryStream), v83 @ X1_v5, v74 @ X2_v1, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected static void ResetDataLengthFieldWidth(Asn1Node node)
		{
			//IL_0047: Expected I, but got O
			//IL_0057: Expected O, but got I
			//IL_0067: Expected O, but got I
			while (true)
			{
				MemoryStream memoryStream = new MemoryStream();
				int num = Asn1Util.DERLengthEncode(memoryStream, (ulong)node.DataLength);
				long length = memoryStream.Length;
				node.lengthFieldBytes = length;
				IntPtr intPtr = (IntPtr)memoryStream;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X8_v11 (Il2CppClass<System.IO.MemoryStream>)+220]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X8_v11 (Il2CppClass<System.IO.MemoryStream>)+228]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v74 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x15D0FA0", Offset = "0x15D0FA0", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EB9118]);\n\tv33 = *([v32 @ X8_v15]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, xNode, subOffset, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2029A07]) = v50;\nL_001F:\n\tv210 = xNode.childNodeList;\n\tv72 = xNode.tag != 3;\n\tif (v72) goto L_FFFFFFFF;\n\tv136 = v132 + 1;\n\tgoto L_0037;\nL_0037:\n\tv183 = System.Collections.ArrayList::get_Count(v210);\n\tv58 = v183 <= v139;\n\tif (v58) goto L_0076;\n\tv152 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(xNode, v150);\n\tv152.parentNode = xNode;\n\tv152.dataOffset = v136;\n\tv220 = xNode.deepness + 1;\n\tv152.deepness = v220;\n\tv222 = 0xDC3560(&v150 @ stack_-44_v6 (System.Int32), 0, v113, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv226 = System.String::Concat(xNode.path, \"/\", v222);\n\tv152.path = v226;\n\tv229 = v136 + v152.lengthFieldBytes;\n\tv113 = v229 + 1;\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::ResetChildNodePar(this, v152, v113);\n\tv139 = v150 + 1;\n\tv210 = xNode.childNodeList;\n\tv136 = v152.dataLength + v113;\n\tv230 = xNode.childNodeList == 0;\n\tv107 = ~v230;\n\tif (v107) goto L_0037;\n\tthrow System.NullReferenceException;\nL_0076:\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void ResetChildNodePar(Asn1Node xNode, long subOffset)
		{
			ArrayList arrayList = xNode.childNodeList;
			long num;
			long num2 = default(long);
			int num3;
			int num4;
			if (xNode.Tag == 3)
			{
				num = num2 + 1;
				num3 = 0;
				num4 = 0;
			}
			else
			{
				num = num2;
				num3 = 0;
				num4 = 0;
			}
			string text2 = default(string);
			bool flag2;
			do
			{
				int count = arrayList.Count;
				if (count > num3)
				{
					Asn1Node childNode = xNode.GetChildNode(num4);
					childNode.parentNode = xNode;
					childNode.dataOffset = num;
					long num5 = xNode.Deepness + 1;
					childNode.deepness = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
					string text = xNode.path + "/" + text2;
					childNode.path = text;
					long num6 = num + childNode.lengthFieldBytes;
					long num7 = num6 + 1;
					ResetChildNodePar(childNode, num7);
					num3 = num4 + 1;
					arrayList = xNode.childNodeList;
					num = childNode.DataLength + num7;
					bool flag = xNode.childNodeList == null;
					flag2 = !flag;
					num4 = num3;
					continue;
				}
				return;
			}
			while (flag2);
			throw new NullReferenceException();
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x15D0814", Offset = "0x15D0814", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EEB718]);\n\tv31 = *([v30 @ X8_v18]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, startNode, lineLen, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2029A08]) = v48;\nL_0019:\n\tv125 = this.childNodeList;\nL_0025:\n\tv132 = System.Collections.ArrayList::get_Count(v125);\n\tv142 = v128 >= v132;\n\tif (v142) goto L_0072;\n\tv220 = System.Collections.ArrayList::get_Item(this.childNodeList, v128);\n\tgoto L_FFFFFFFF;\n\tv61 = v61_asT == 0;\n\tif (v61) goto L_0074;\n\tv247 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetText(v220, startNode, lineLen);\n\tv249 = System.String::Concat(v157, v247);\n\tv125 = this.childNodeList;\n\tv128 = v128 + 1;\n\tv250 = this.childNodeList == 0;\n\tv103 = ~v250;\n\tif (v103) goto L_0025;\n\tthrow System.NullReferenceException;\nL_0072:\n\treturn v157;\n\tv228 = new System.NullReferenceException();\nL_0074:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected string GetListStr(Asn1Node startNode, int lineLen)
		{
			ArrayList arrayList = childNodeList;
			string text = "";
			int num = 0;
			while (true)
			{
				int count = arrayList.Count;
				if (num < count)
				{
					Asn1Node asn1Node = (Asn1Node)childNodeList.get_Item(num);
					Asn1Node asn1Node2 = asn1Node as Asn1Node;
					if (asn1Node2 == null)
					{
						break;
					}
					string text2 = asn1Node.GetText(startNode, lineLen);
					string text3 = text + text2;
					arrayList = childNodeList;
					num++;
					bool flag = childNodeList == null;
					bool flag2 = !flag;
					text = text3;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return text;
			}
			return (string)(object)new InvalidCastException();
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x15CE2B4", Offset = "0x15CE2B4", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EADDB8]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, startNode, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2029A09]) = v43;\nL_0019:\n\tv47 = startNode == 0;\n\tif (v47) goto L_001D;\nL_001D:\n\tv51 = this.deepness - v49;\n\tv62 = v51 < 1;\n\tif (v62) goto L_0046;\nL_002F:\n\treturnVal1 = System.String::Concat(v112, \"   \");\n\tv114 = v114 + 1;\n\tv92 = this.deepness - v49;\n\tv71 = v114 < v92;\n\tif (v71) goto L_002F;\nL_0046:\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected string GetIndentStr(Asn1Node startNode)
		{
			//IL_00bc: Expected O, but got I8
			//IL_0012: Expected O, but got I8
			//IL_0088: Expected I4, but got I8
			bool flag = startNode == null;
			Asn1Node asn1Node = startNode;
			if (!flag)
			{
				asn1Node = (Asn1Node)startNode.Deepness;
			}
			object obj = Deepness - (long)(IntPtr)asn1Node;
			bool flag2 = (long)(IntPtr)obj < 1L;
			string text = "";
			if (!flag2)
			{
				string text2 = "";
				int num = 0;
				bool flag3;
				do
				{
					text = text2 + "   ";
					num++;
					int num2 = (int)(Deepness - (long)(IntPtr)asn1Node);
					flag3 = num < num2;
					text2 = text;
				}
				while (flag3);
			}
			return text;
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x15D119C", Offset = "0x15D119C", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EB3640]);\n\tv29 = *([v28 @ X8_v31]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, xdata, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2029A0A]) = v47;\nL_001E:\n\tv53 = System.IO.Stream::get_Length(xdata);\n\tv59 = System.IO.Stream::get_Position(xdata);\n\tv65 = System.IO.Stream::ReadByte(xdata);\n\tthis.tag = v65;\n\tv70 = System.IO.Stream::get_Position(xdata);\n\tv74 = this + 0x61;\n\tgoto L_0041;\n\tv81 = *([v75 @ X0_v12+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0041;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v75, v69, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0041:\n\tv90 = LipingShare.LCLib.Asn1Processor.Asn1Util::DerLengthDecode(xdata, v74);\n\tthis.dataLength = v90;\n\tv91 = v90 & 0x8000000000000000;\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_FFFFFFFF;\n\tv162 = v53 - v59;\n\tv165 = System.IO.Stream::get_Position(xdata);\n\tv167 = v165 - v70;\n\tthis.lengthFieldBytes = v167;\n\tv168 = v167 + this.dataLength;\n\tv169 = v168 + 1;\n\tv179 = v162 >= v169;\n\tif (v179) goto L_0068;\nL_0067:\n\treturn returnVal2;\nL_0068:\n\tv209 = this.parentNode;\n\tv210 = this.parentNode == 0;\n\tif (v210) goto L_0070;\n\tv243 = v209.tag & 0x20;\n\tv244 = v243 == 0;\n\tv245 = ~v244;\n\tif (v245) goto L_0080;\nL_0070:\n\tv206 = this.tag;\n\tv234 = this.tag & 0x1F;\n\tv238 = v234 == 0;\n\tif (v238) goto L_0067;\n\tv225 = v234 == 0x1F;\n\tif (v225) goto L_0067;\n\tgoto L_008A;\nL_0080:\n\tv206 = this.tag;\nL_008A:\n\tv267 = v206 != 3;\n\tif (v267) goto L_00B3;\n\tv181 = this.dataLength < 1;\n\tif (v181) goto L_FFFFFFFF;\n\tv278 = System.IO.Stream::ReadByte(xdata);\n\tthis.unusedBits = v278;\n\tv282 = this.dataLength - 1;\n\t// 163 NewArr v284 @ X0_v31 (System.Byte[]), typeof(System.Byte[]), v282 @ X1_v13 (System.Int64)\n\tthis.data = v284;\n\tv301 = this.dataLength - 1;\n\tv303 = System.IO.Stream::Read(xdata, v284, 0, v301);\n\tgoto L_FFFFFFFF;\nL_00B3:\n\t// 179 NewArr v273 @ X0_v25 (System.Byte[]), typeof(System.Byte[]), this.dataLength (System.Int64)\n\tthis.data = v273;\n\tv293 = System.IO.Stream::Read(xdata, v273, 0, this.dataLength);\n\tgoto L_0067;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe bool GeneralDecode(Stream xdata)
		{
			//IL_02bf: Expected I4, but got I8
			//IL_026f: Expected I4, but got I8
			long length = xdata.Length;
			long position = xdata.Position;
			int num = xdata.ReadByte();
			tag = (byte)num;
			long position2 = xdata.Position;
			long num2 = (dataLength = Asn1Util.DerLengthDecode(xdata, ref *(bool*)((long)(IntPtr)this + 97L))) & long.MinValue;
			byte b;
			bool result;
			if (num2 == 0)
			{
				long num3 = length - position;
				long position3 = xdata.Position;
				long num4 = (lengthFieldBytes = position3 - position2) + DataLength;
				long num5 = num4 + 1;
				if (num3 >= num5)
				{
					Asn1Node asn1Node = ParentNode;
					if (ParentNode == null || (asn1Node.Tag & 0x20) == 0)
					{
						b = Tag;
						int num6 = Tag & 0x1F;
						bool flag = num6 == 0;
						result = false;
						if (!flag)
						{
							bool flag2 = num6 == 31;
							result = false;
							if (!flag2)
							{
								goto IL_02cd;
							}
						}
						goto IL_02c8;
					}
					b = Tag;
					goto IL_02cd;
				}
			}
			goto IL_0116;
			IL_0116:
			result = false;
			goto IL_02c8;
			IL_02c8:
			return result;
			IL_02cd:
			if (b == 3)
			{
				if (DataLength < 1)
				{
					goto IL_0116;
				}
				int num7 = xdata.ReadByte();
				unusedBits = (byte)num7;
				long num8 = DataLength - 1;
				byte[] buffer = (data = new byte[num8]);
				int count = (int)(DataLength - 1);
				int num9 = xdata.Read(buffer, 0, count);
			}
			else
			{
				int num10 = xdata.Read(data = new byte[DataLength], 0, (int)DataLength);
			}
			result = true;
			goto IL_02c8;
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x15D1450", Offset = "0x15D1450", Length = "0x3AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1ED6AA8]);\n\tv33 = *([v32 @ X8_v48]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, xdata, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2029A0B]) = v51;\nL_0020:\n\tv57 = System.IO.Stream::get_Position(xdata);\n\tv63 = System.IO.Stream::get_Length(xdata);\n\tv69 = System.IO.Stream::get_Position(xdata);\n\tv75 = System.IO.Stream::ReadByte(xdata);\n\tthis.tag = v75;\n\tv80 = System.IO.Stream::get_Position(xdata);\n\tgoto L_0046;\n\tv90 = *([v84 @ X0_v35+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_0046;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v84, v78, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0046:\n\tv97 = this + 0x61;\n\tv99 = LipingShare.LCLib.Asn1Processor.Asn1Util::DerLengthDecode(xdata, v97);\n\tthis.dataLength = v99;\n\tv162 = v99 & 0x8000000000000000;\n\tv163 = v162 == 0;\n\tv164 = ~v163;\n\tif (v164) goto L_0135;\n\tv210 = v63 - v69;\n\tv221 = v210 < v99;\n\tif (v221) goto L_0135;\n\tv318 = System.IO.Stream::get_Position(xdata);\n\tv108 = v318 - v80;\n\tthis.lengthFieldBytes = v108;\n\tv321 = v108 + this.dataOffset;\n\tv145 = v321 + 1;\n\tv332 = this.tag != 3;\n\tif (v332) goto L_FFFFFFFF;\n\tv341 = System.IO.Stream::ReadByte(xdata);\n\tthis.unusedBits = v341;\n\tv145 = v145 + 1;\n\tv344 = this.dataLength - 1;\n\tthis.dataLength = v344;\n\tgoto L_008A;\nL_008A:\n\tv404 = v388 <= 0;\n\tif (v404) goto L_FFFFFFFF;\n\tv466 = new System.IO.MemoryStream();\n\tSystem.IO.MemoryStream::.ctor(v466, v388);\n\t// 153 NewArr v482 @ X0_v47 (System.Byte[]), typeof(System.Byte[]), this.dataLength (System.Int64)\n\tv202 = System.IO.Stream::Read(xdata, v482, 0, this.dataLength);\n\tv173 = this.tag != 3;\n\tif (v173) goto L_00B4;\n\tv488 = this.dataLength + 1;\n\tthis.dataLength = v488;\nL_00B4:\n\tv311 = v466 == 0;\n\tif (v311) goto L_010B;\n\tv489 = *([v466 @ X0_v44 (System.IO.MemoryStream)]);\n\tv227 = v482.Length;\n\tv224 = *([v489 @ X8_v32 (Il2CppClass<System.IO.MemoryStream>)+308]);\n\tv494 = System.IO.MemoryStream::Write(v466, v482, 0, v482.Length);\n\tv500 = System.IO.MemoryStream::set_Position(v466, 0);\n\tgoto L_00EC;\nL_00C8:\n\tv531 = new LipingShare.LCLib.Asn1Processor.Asn1Node();\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::.ctor(v531, this, v145);\n\tv531.parseEncapsulatedData = this.parseEncapsulatedData;\n\tv535 = System.IO.MemoryStream::get_Position(v466);\n\tv472 = LipingShare.LCLib.Asn1Processor.Asn1Node::InternalLoadData(v531, v466);\n\tv473 = v472 == 0;\n\tif (v473) goto L_FFFFFFFF;\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::AddChild(this, v531);\n\tv518 = System.IO.MemoryStream::get_Position(v466);\n\tv520 = v145 - v535;\n\tv145 = v520 + v518;\nL_00EC:\n\tv525 = System.IO.MemoryStream::get_Position(v466);\n\tv527 = System.IO.MemoryStream::get_Length(v466);\n\tv111 = v525 < v527;\n\tif (v111) goto L_00C8;\n\tgoto L_014B;\n\tgoto L_0135;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_010B:\n\tv313 = new System.NullReferenceException();\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\n\tgoto L_012A;\nL_012A:\n\tv234 = v447 != 1;\n\tif (v234) goto L_0150;\n\tv461 = 0x6D2BC0(v313, v447, v415, v226, v223, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv263 = *([v461 @ X0_v15]);\n\tv282 = 0x6D2490(v461, v447, v415, v226, v223, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0135:\n\tv297 = System.IO.Stream::set_Position(xdata, v290);\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::ClearAll(this);\n\tv334 = v260 & 1;\n\tv335 = v334 == 0;\n\tv336 = ~v335;\n\tif (v336) goto L_014B;\n\tv346 = v263 == 0;\n\tv347 = ~v346;\n\tif (v347) goto L_014F;\nL_014B:\n\treturn returnVal1;\nL_014F:\n\tv408 = new System.TypeLoadException();\nL_0150:\n\treturnVal2 = 0x6D2380(v408, 0, 0, v227, v224, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\treturn returnVal2;\n// 219 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe bool ListDecode(Stream xdata)
		{
			//IL_01cc: Expected I4, but got I8
			//IL_01bd: Expected I4, but got I8
			//IL_020d: Expected I4, but got I8
			//IL_0277: Expected I, but got O
			//IL_0291: Expected O, but got I
			//IL_02b7: Expected I8, but got I4
			//IL_03d5: Expected I4, but got O
			long position = xdata.Position;
			long length = xdata.Length;
			long position2 = xdata.Position;
			int num = xdata.ReadByte();
			tag = (byte)num;
			long position3 = xdata.Position;
			long num2 = (dataLength = Asn1Util.DerLengthDecode(xdata, ref *(bool*)((long)(IntPtr)this + 97L)));
			long num3 = num2 & long.MinValue;
			bool flag = num3 == 0;
			bool flag2 = !flag;
			int num4 = 1;
			int num5 = 0;
			long position4 = position;
			bool result;
			if (!flag2)
			{
				long num6 = length - position2;
				bool flag3 = num6 < num2;
				num4 = 1;
				num5 = 0;
				position4 = position;
				if (!flag3)
				{
					long position5 = xdata.Position;
					long num7 = (lengthFieldBytes = position5 - position3) + dataOffset;
					long num8 = num7 + 1;
					int num10;
					if (Tag == 3)
					{
						int num9 = xdata.ReadByte();
						unusedBits = (byte)num9;
						num8++;
						num10 = (int)(dataLength = DataLength - 1);
					}
					else
					{
						num10 = (int)DataLength;
					}
					if (num10 <= 0)
					{
						goto IL_035e;
					}
					MemoryStream memoryStream = new MemoryStream(num10);
					byte[] array = new byte[DataLength];
					int num11 = xdata.Read(array, 0, (int)DataLength);
					if (Tag == 3)
					{
						long num12 = DataLength + 1;
						dataLength = num12;
					}
					object obj;
					int num13;
					if (memoryStream != null)
					{
						IntPtr intPtr = (IntPtr)memoryStream;
						num13 = array.Length;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ X8_v32 (Il2CppClass<System.IO.MemoryStream>)+308]");
						obj = 0;
						memoryStream.Write(array, 0, array.Length);
						memoryStream.Position = 0L;
						while (true)
						{
							long position6 = memoryStream.Position;
							long length2 = memoryStream.Length;
							if (position6 < length2)
							{
								Asn1Node asn1Node = new Asn1Node(this, num8);
								asn1Node.parseEncapsulatedData = parseEncapsulatedData;
								long position7 = memoryStream.Position;
								if (asn1Node.InternalLoadData(memoryStream))
								{
									AddChild(asn1Node);
									long position8 = memoryStream.Position;
									long num14 = num8 - position7;
									num8 = num14 + position8;
									continue;
								}
								goto IL_035e;
							}
							break;
						}
						result = true;
						goto IL_043b;
					}
					NullReferenceException ex = new NullReferenceException();
					byte[] array2 = default(byte[]);
					bool flag4 = (IntPtr)array2 != (IntPtr)1;
					object obj2 = default(object);
					obj = obj2;
					int num15 = default(int);
					num13 = num15;
					TypeLoadException ex2 = (TypeLoadException)(object)ex;
					if (flag4)
					{
						goto IL_044e;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj3 = default(object);
					num5 = (int)obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					obj = obj2;
					num13 = num15;
					num4 = 0;
					long num16 = default(long);
					position4 = num16;
				}
			}
			goto IL_045d;
			IL_045d:
			xdata.Position = position4;
			ClearAll();
			int num17 = num4 & 1;
			bool flag5 = num17 == 0;
			bool flag6 = !flag5;
			result = false;
			if (!flag6)
			{
				bool flag7 = num5 == 0;
				bool flag8 = !flag7;
				result = false;
				if (flag8)
				{
					TypeLoadException ex2 = new TypeLoadException();
					goto IL_044e;
				}
			}
			goto IL_043b;
			IL_044e:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			bool result2 = default(bool);
			return result2;
			IL_035e:
			num4 = 1;
			num5 = 0;
			position4 = position;
			goto IL_045d;
			IL_043b:
			return result;
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x15CEC6C", Offset = "0x15CEC6C", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tLipingShare.LCLib.Asn1Processor.Asn1Node::ClearAll(this);\n\tv23 = System.IO.Stream::get_Position(xdata);\n\tv43 = System.IO.Stream::ReadByte(xdata);\n\tv50 = System.IO.Stream::set_Position(xdata, v23);\n\tv51 = v43 & 0x20;\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_003C;\n\tv57 = ~this.parseEncapsulatedData;\n\tif (v57) goto L_005D;\n\tv105 = v43 & 0x1F;\n\tv106 = v105 < 0x1C;\n\tv90 = ~v106;\n\tv86 = v105 - 0x1C;\n\tv78 = v86 == 0;\n\tv107 = ~v78;\n\tv59 = v90 & v107;\n\tif (v59) goto L_0049;\n\tv164 = 1 << v105;\n\tv97 = v164 & 0x1B7B1118;\n\tv100 = v97 == 0;\n\tif (v100) goto L_0049;\nL_003C:\n\tv104 = LipingShare.LCLib.Asn1Processor.Asn1Node::ListDecode(this, xdata);\n\tv122 = v104 == 0;\n\tif (v122) goto L_005D;\n\treturn 1;\nL_0049:\n\tv98 = v43 & 0x1F;\n\tv80 = v98 == 0x1A;\n\tif (v80) goto L_003C;\nL_005D:\n\treturnVal2 = LipingShare.LCLib.Asn1Processor.Asn1Node::GeneralDecode(this, xdata);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected bool InternalLoadData(Stream xdata)
		{
			ClearAll();
			long position = xdata.Position;
			int num = xdata.ReadByte();
			xdata.Position = position;
			if ((num & 0x20) != 0)
			{
				goto IL_0128;
			}
			if (parseEncapsulatedData)
			{
				int num2 = num & 0x1F;
				bool flag = num2 < 28;
				bool flag2 = !flag;
				int num3 = num2 - 28;
				bool flag3 = num3 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num4 = 1 << num2;
					if ((num4 & 0x1B7B1118) != 0)
					{
						goto IL_0128;
					}
				}
				int num5 = num & 0x1F;
				if (num5 == 26)
				{
					goto IL_0128;
				}
			}
			goto IL_0184;
			IL_0184:
			return GeneralDecode(xdata);
			IL_0128:
			if (ListDecode(xdata))
			{
				return true;
			}
			goto IL_0184;
		}
	}
}
