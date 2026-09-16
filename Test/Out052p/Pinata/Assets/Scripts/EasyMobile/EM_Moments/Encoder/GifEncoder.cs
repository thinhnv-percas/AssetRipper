using System;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EM_Moments.Encoder
{
	[Token(Token = "0x2000005")]
	public class GifEncoder
	{
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x10")]
		protected int m_Width;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x14")]
		protected int m_Height;

		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x18")]
		protected int m_Repeat;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x1C")]
		protected int m_FrameDelay;

		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x20")]
		protected bool m_HasStarted;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x28")]
		protected FileStream m_FileStream;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x30")]
		protected GifFrame m_CurrentFrame;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x38")]
		protected byte[] m_Pixels;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x40")]
		protected byte[] m_IndexedPixels;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x48")]
		protected int m_ColorDepth;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x50")]
		protected byte[] m_ColorTab;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x58")]
		protected bool[] m_UsedEntry;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x60")]
		protected int m_PaletteSize;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x64")]
		protected int m_DisposalCode;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x68")]
		protected bool m_ShouldCloseStream;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x69")]
		protected bool m_IsFirstFrame;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x6A")]
		protected bool m_IsSizeSet;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x6C")]
		protected int m_SampleInterval;

		[Token(Token = "0x600000D")]
		[Address(RVA = "0xA3EF64", Offset = "0xA3EF64", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEM_Moments.Encoder.GifEncoder::.ctor(this, 0xFFFFFFFF, 0xA);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GifEncoder()
			: this(-1, 10)
		{
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0xA3EF70", Offset = "0xA3EF70", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv25 = *([1EEA2A8]);\n\tv26 = *([v25 @ X8_v10]);\n\tv27 = \"il2cpp_codegen_initialize_method\"(v26, repeat, quality, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021E66]) = v43;\nL_0018:\n\tthis.m_Repeat = 0xFFFFFFFF;\n\t// 29 NewArr v49 @ X0_v3 (System.Boolean[]), typeof(System.Boolean[]), 256\n\tthis.m_UsedEntry = v49;\n\tthis.m_PaletteSize = 0xFFFFFFFF00000007;\n\tthis.m_IsFirstFrame = 1;\n\tthis.m_SampleInterval = 0xA;\n\tSystem.Object::.ctor(this);\n\tv55 = repeat & 0x80000000;\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_002F;\n\tthis.m_Repeat = repeat;\nL_002F:\n\tv60 = 0xA59754(this, 0, quality, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn;\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_003A;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_003A;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_003A:\n\tX1 = 0 | 1;\n\tX2 = 0x64;\n\tX0 = X20;\n\tX3 = 0;\n\tX0 = UnityEngine.Mathf::Clamp(X0, X1, X2, X3);\n\t*([X19+6C]) = X0;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX22 = stack[0];\n\tX21 = stack[8];\n\t// 70 ShiftStack 48\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GifEncoder(int repeat, int quality)
		{
			//IL_004c: Expected I4, but got I8
			//IL_0074: Expected I4, but got I8
			base._002Ector();
			m_Repeat = -1;
			bool[] usedEntry = new bool[256];
			m_UsedEntry = usedEntry;
			m_PaletteSize = 7;
			m_IsFirstFrame = true;
			m_SampleInterval = 10;
			if ((int)(repeat & 0x80000000L) == 0)
			{
				m_Repeat = repeat;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @A59754 (inside EasyMobile.GameServices::.cctor +0x84)");
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0xA3F040", Offset = "0xA3F040", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F01F80]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, ms, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021E67]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, ms, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tv57 = ms / 10f;\n\tv59 = UnityEngine.Mathf::RoundToInt(v57);\n\tthis.m_FrameDelay = v59;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetDelay(int ms)
		{
			float f = (float)ms / 10f;
			int frameDelay = Mathf.RoundToInt(f);
			m_FrameDelay = frameDelay;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0xA3F0C4", Offset = "0xA3F0C4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = *([1EE5B08]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, fps, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021E68]) = v41;\nL_0020:\n\tv53 = fps <= 0;\n\tif (v53) goto L_003A;\n\tgoto L_0031;\n\tv73 = *([v56 @ X0_v3+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0031;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v26, v27, v28, v29, v30, v31, fps, v32, v33, v34, v35, v36, v37, v38);\nL_0031:\n\tv61 = 100f / fps;\n\tv63 = UnityEngine.Mathf::RoundToInt(v61);\n\tthis.m_FrameDelay = v63;\nL_003A:\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFrameRate(float fps)
		{
			if (fps > 0f)
			{
				float f = 100f / fps;
				int frameDelay = Mathf.RoundToInt(f);
				m_FrameDelay = frameDelay;
			}
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0xA3F150", Offset = "0xA3F150", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC4A58]);\n\tv23 = *([v22 @ X8_v24]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, frame, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021E69]) = v41;\nL_0015:\n\tv42 = frame == 0;\n\tif (v42) goto L_004E;\n\tv44 = ~this.m_HasStarted;\n\tif (v44) goto L_0059;\n\tv50 = ~this.m_IsSizeSet;\n\tv51 = ~v50;\n\tif (v51) goto L_0025;\n\tthis.m_IsSizeSet = 1;\n\tthis.m_Width = frame.Width;\n\tthis.m_Height = frame.Height;\nL_0025:\n\tthis.m_CurrentFrame = frame;\n\tEM_Moments.Encoder.GifEncoder::GetImagePixels(this);\n\tEM_Moments.Encoder.GifEncoder::AnalyzePixels(this);\n\tv89 = ~this.m_IsFirstFrame;\n\tif (v89) goto L_0038;\n\tEM_Moments.Encoder.GifEncoder::WriteLSD(this);\n\tEM_Moments.Encoder.GifEncoder::WritePalette(this);\n\tv120 = this.m_Repeat & 0x80000000;\n\tv121 = v120 == 0;\n\tv95 = ~v121;\n\tif (v95) goto L_0038;\n\tEM_Moments.Encoder.GifEncoder::WriteNetscapeExt(this);\nL_0038:\n\tEM_Moments.Encoder.GifEncoder::WriteGraphicCtrlExt(this);\n\tEM_Moments.Encoder.GifEncoder::WriteImageDesc(this);\n\tv122 = ~this.m_IsFirstFrame;\n\tv108 = ~v122;\n\tif (v108) goto L_0042;\n\tEM_Moments.Encoder.GifEncoder::WritePalette(this);\nL_0042:\n\tEM_Moments.Encoder.GifEncoder::WritePixels(this);\n\tthis.m_IsFirstFrame = 0;\n\treturn;\nL_004E:\n\tv48 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v48, \"Can't add a null frame to the gif.\");\n\tgoto L_0065;\nL_0059:\n\tv55 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v55, \"Call Start() before adding frames to the gif.\");\nL_0065:\n\tthrow v80;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddFrame(GifFrame frame)
		{
			//IL_0099: Expected I4, but got I8
			if (frame != null)
			{
				if (m_HasStarted)
				{
					if (!m_IsSizeSet)
					{
						m_IsSizeSet = true;
						m_Width = frame.Width;
						m_Height = frame.Height;
					}
					m_CurrentFrame = frame;
					GetImagePixels();
					AnalyzePixels();
					if (m_IsFirstFrame)
					{
						WriteLSD();
						WritePalette();
						if ((int)(m_Repeat & 0x80000000L) == 0)
						{
							WriteNetscapeExt();
						}
					}
					WriteGraphicCtrlExt();
					WriteImageDesc();
					if (!m_IsFirstFrame)
					{
						WritePalette();
					}
					WritePixels();
					m_IsFirstFrame = false;
					return;
				}
				InvalidOperationException ex = new InvalidOperationException("Call Start() before adding frames to the gif.");
			}
			else
			{
				ArgumentNullException ex2 = new ArgumentNullException("Can't add a null frame to the gif.");
			}
			object obj = default(object);
			throw obj;
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0xA3FAE4", Offset = "0xA3FAE4", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F08070]);\n\tv23 = *([v22 @ X8_v21]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, os, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021E6A]) = v41;\nL_0015:\n\tv42 = os == 0;\n\tif (v42) goto L_002A;\n\tthis.m_ShouldCloseStream = 0;\n\tthis.m_FileStream = os;\n\tEM_Moments.Encoder.GifEncoder::WriteString(this, \"GIF89a\");\n\tthis.m_HasStarted = 1;\n\treturn;\nL_002A:\n\tv50 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v50, \"Stream is null.\");\n\tthrow v50;\n\tv115 = 0x6D2BC0(v111, 0, Il2CppMethodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv122 = *([v115 @ X0_v11]);\n\tv129 = *([v122 @ X20_v3]);\n\tv131 = \"il2cpp_vm_class_is_assignable_from\"(System.IO.IOException, v129, Il2CppMethodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv132 = v131 & 1;\n\tv120 = v132 == 0;\n\tif (v120) goto L_0057;\n\tv133 = 0x6D2490(v131, v129, Il2CppMethodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tthrow System.TypeLoadException;\nL_0057:\n\tv143 = 0x6D1E60(8, v136, v134, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv123 = *([v115 @ X0_v11]);\n\t*([v143 @ X0_v16]) = v123;\n\tv117 = 0x1E8A000 + 0x870;\n\tv147 = 0x6D2A00(v143, v117, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv119 = 0x6D2490(v147, v117, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv125 = 0x6D2380(v99, v93, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv95 = 0x846AA4(v125, v93, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Start(FileStream os)
		{
			if (os != null)
			{
				m_ShouldCloseStream = false;
				m_FileStream = os;
				WriteString("GIF89a");
				m_HasStarted = true;
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("Stream is null.");
			throw ex;
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0xA3FCBC", Offset = "0xA3FCBC", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB49C0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, file, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021E6B]) = v41;\nL_0018:\n\tv45 = new System.IO.FileStream();\n\tSystem.IO.FileStream::.ctor(v45, file, 4, 2, 0);\n\tthis.m_FileStream = v45;\n\tEM_Moments.Encoder.GifEncoder::Start(this, v45);\n\tthis.m_ShouldCloseStream = 1;\n\treturn;\n\tgoto L_0030;\n\tgoto L_0030;\nL_0030:\n\tX19 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0059;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX20 = *([X19]);\n\tX8 = *([1EFA0B0]);\n\tX1 = *([X20]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_004F;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F0F948]);\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = *([X8]);\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_004F:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0059:\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Start(string file)
		{
			Start(m_FileStream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write, default(FileShare)));
			m_ShouldCloseStream = true;
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0xA3FDDC", Offset = "0xA3FDDC", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EBE678]);\n\tv19 = *([v18 @ X8_v28]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E6C]) = v38;\nL_0014:\n\tv40 = ~this.m_HasStarted;\n\tif (v40) goto L_0042;\n\tv43 = this.m_FileStream;\n\tthis.m_HasStarted = 0;\n\tv49 = *([v43 @ X0_v28 (System.IO.FileStream)]);\n\tv186 = *([v49 @ X8_v20 (Il2CppClass<System.IO.FileStream>)+318]);\n\tv53 = System.IO.FileStream::WriteByte(v43, 0x3B);\n\tv54 = this.m_FileStream;\n\tv73 = *([v54 @ X0_v30 (System.IO.FileStream)]);\n\tv147 = *([v73 @ X8_v21 (Il2CppClass<System.IO.FileStream>)+248]);\n\tv76 = System.IO.FileStream::Flush(v54);\n\tv78 = ~this.m_ShouldCloseStream;\n\tif (v78) goto L_0034;\n\tv92 = this.m_FileStream == 0;\n\tif (v92) goto L_0051;\n\tv98 = System.IO.Stream::Close(this.m_FileStream);\nL_0034:\n\tthis.m_ColorTab = 0;\n\tthis.m_ShouldCloseStream = 0;\n\tthis.m_FileStream = 0;\n\tthis.m_Pixels = 0;\n\tthis.m_IsFirstFrame = 1;\n\treturn;\nL_0042:\n\tv48 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v48, \"Can't finish a non-started gif.\");\n\tthrow v48;\n\tv68 = new System.NullReferenceException();\n\tv88 = new System.NullReferenceException();\nL_0051:\n\tv116 = new System.NullReferenceException();\n\tgoto L_005E;\n\tgoto L_005E;\nL_005E:\n\tv121 = *([v73 @ X8_v21 (Il2CppClass<System.IO.FileStream>)+248]) != 1;\n\tif (v121) goto L_007E;\n\tv165 = 0x6D2BC0(v116, *([v73 @ X8_v21 (Il2CppClass<System.IO.FileStream>)+248]), *([v49 @ X8_v20 (Il2CppClass<System.IO.FileStream>)+318]), v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv173 = *([v165 @ X0_v9]);\n\tv181 = \"il2cpp_vm_class_is_assignable_from\"(System.IO.IOException, *([v173 @ X20_v4]), *([v49 @ X8_v20 (Il2CppClass<System.IO.FileStream>)+318]), v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv182 = v181 & 1;\n\tv170 = v182 == 0;\n\tif (v170) goto L_0074;\n\tv183 = 0x6D2490(v181, *([v173 @ X20_v4]), v186, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tthrow System.TypeLoadException;\nL_0074:\n\tv193 = 0x6D1E60(8, *([v173 @ X20_v4]), *([v49 @ X8_v20 (Il2CppClass<System.IO.FileStream>)+318]), v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\t*([v193 @ X0_v14]) = *([v165 @ X0_v9]);\n\tv147 = 0x1E8A000 + 0x870;\n\tv197 = 0x6D2A00(v193, v147, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv169 = 0x6D2490(v197, v147, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_007E:\n\tv175 = 0x6D2380(v156, v147, v186, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv152 = 0x846AA4(v175, v147, v186, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Finish()
		{
			//IL_0027: Expected I, but got O
			//IL_005c: Expected I, but got O
			//IL_01b9: Expected I, but got O
			if (m_HasStarted)
			{
				FileStream fileStream = m_FileStream;
				m_HasStarted = false;
				IntPtr intPtr = (IntPtr)fileStream;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v20 (Il2CppClass<System.IO.FileStream>)+318]");
				IntPtr intPtr2 = (IntPtr)0;
				fileStream.WriteByte(59);
				FileStream fileStream2 = m_FileStream;
				IntPtr intPtr3 = (IntPtr)fileStream2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X8_v21 (Il2CppClass<System.IO.FileStream>)+248]");
				IntPtr intPtr4 = (IntPtr)0;
				fileStream2.Flush();
				if (m_ShouldCloseStream)
				{
					if (m_FileStream == null)
					{
						NullReferenceException ex = new NullReferenceException();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X8_v21 (Il2CppClass<System.IO.FileStream>)+248]");
						bool flag = (IntPtr)0 != (IntPtr)1;
						NullReferenceException ex2 = ex;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
							object obj2 = default(object);
							object obj = obj2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
							object obj3 = default(object);
							if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
								intPtr2 = (IntPtr)0;
								throw new TypeLoadException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
							object obj4 = obj2;
							intPtr4 = (IntPtr)(32022528 + 2160);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
							intPtr2 = (IntPtr)null;
							NullReferenceException ex3 = default(NullReferenceException);
							ex2 = ex3;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
						return;
					}
					m_FileStream.Close();
				}
				m_ColorTab = null;
				m_ShouldCloseStream = false;
				m_FileStream = null;
				m_Pixels = null;
				m_IsFirstFrame = true;
				return;
			}
			InvalidOperationException ex4 = new InvalidOperationException("Can't finish a non-started gif.");
			throw ex4;
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0xA3F294", Offset = "0xA3F294", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Width = w;\n\tthis.m_Height = h;\n\tthis.m_IsSizeSet = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void SetSize(int w, int h)
		{
			m_Width = w;
			m_Height = h;
			m_IsSizeSet = true;
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0xA3F2A4", Offset = "0xA3F2A4", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAA5E0]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E6D]) = v38;\nL_0013:\n\tv39 = this.m_CurrentFrame;\n\tv45 = v39.Width * v39.Height;\n\tv47 = v45 << 1;\n\tv48 = v45 + v47;\n\t// 30 NewArr v49 @ X0_v9 (System.Byte[]), typeof(System.Byte[]), v48 @ X1_v4 (System.Int32)\n\tv134 = this.m_CurrentFrame;\n\tthis.m_Pixels = v49;\n\tv160 = v134.Height - 1;\n\tv189 = v160 & 0x80000000;\n\tv190 = v189 == 0;\n\tv191 = ~v190;\n\tif (v191) goto L_008E;\n\tv145 = v134.Data;\nL_0036:\n\tv52 = v55 >= v134.Width;\n\tif (v52) goto L_0085;\n\tv184 = v160 * v134.Width;\n\tv135 = v55 + v184;\n\tv278 = v135 < v145.Length;\n\tv121 = ~v278;\n\tif (v121) goto L_0091;\n\tv65 = this.m_Pixels;\n\tv279 = v148 < v65.Length;\n\tv122 = ~v279;\n\tif (v122) goto L_0091;\n\tv142 = v135 << 2;\n\tv280 = v145 + v142;\n\tv65[v148 @ X10_v8 (System.Int32)] = *([v280 @ X12_v8+20]);\n\tv66 = this.m_Pixels;\n\tv130 = v148 + 1;\n\tv282 = v130 < v66.Length;\n\tv123 = ~v282;\n\tif (v123) goto L_0091;\n\tv60 = *([v280 @ X12_v8+20]) >> 8;\n\tv66[v130 @ X14_v8 (System.Int32)] = v60;\n\tv67 = this.m_Pixels;\n\tv131 = v148 + 2;\n\tv284 = v131 < v67.Length;\n\tv124 = ~v284;\n\tif (v124) goto L_0091;\n\tv285 = *([v280 @ X12_v8+20]) >> 0x10;\n\tv67[v131 @ X14_v9 (System.Int32)] = v285;\n\tv134 = this.m_CurrentFrame;\n\tv148 = v148 + 3;\n\tv55 = v55 + 1;\n\tv286 = this.m_CurrentFrame == 0;\n\tv158 = ~v286;\n\tif (v158) goto L_0036;\n\tgoto L_0090;\nL_0085:\n\tv160 = v160 - 1;\n\tv277 = v160 & 0x80000000;\n\tv214 = v277 == 0;\n\tif (v214) goto L_FFFFFFFF;\nL_008E:\n\treturn;\nL_0090:\n\tv162 = new System.NullReferenceException();\nL_0091:\n\tv186 = new System.IndexOutOfRangeException();\n\tthrow v186;\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void GetImagePixels()
		{
			//IL_0082: Expected I4, but got I8
			//IL_02c9: Expected I4, but got I8
			//IL_0161: Expected O, but got I
			GifFrame currentFrame = m_CurrentFrame;
			int num = currentFrame.Width * currentFrame.Height;
			int num2 = num << 1;
			int num3 = num + num2;
			byte[] pixels = new byte[num3];
			GifFrame currentFrame2 = m_CurrentFrame;
			m_Pixels = pixels;
			int num4 = currentFrame2.Height - 1;
			if ((int)(num4 & 0x80000000L) != 0)
			{
				return;
			}
			Color32[] data = currentFrame2.Data;
			int num5 = 0;
			do
			{
				int num6 = 0;
				while (num6 < currentFrame2.Width)
				{
					int num7 = num4 * currentFrame2.Width;
					int num8 = num6 + num7;
					if (num8 < data.Length)
					{
						byte[] pixels2 = m_Pixels;
						if (num5 < pixels2.Length)
						{
							int num9 = num8 << 2;
							object obj = (long)(IntPtr)data + (long)num9;
							int num10 = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ X12_v8+20]");
							pixels2[num10] = 0;
							byte[] pixels3 = m_Pixels;
							int num11 = num5 + 1;
							if (num11 < pixels3.Length)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ X12_v8+20]");
								int num12 = 0;
								pixels3[num11] = (byte)num12;
								byte[] pixels4 = m_Pixels;
								int num13 = num5 + 2;
								if (num13 < pixels4.Length)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ X12_v8+20]");
									int num14 = 0;
									pixels4[num13] = (byte)num14;
									currentFrame2 = m_CurrentFrame;
									num5 += 3;
									num6++;
									if (m_CurrentFrame != null)
									{
										continue;
									}
									NullReferenceException ex = new NullReferenceException();
								}
							}
						}
					}
					IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
					throw ex2;
				}
				num4--;
			}
			while ((int)(num4 & 0x80000000L) == 0);
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0xA3F3EC", Offset = "0xA3F3EC", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EDD6A0]);\n\tv27 = *([v26 @ X8_v24]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021E6E]) = v46;\nL_0017:\n\tv47 = this.m_Pixels;\n\tv54 = v47.Length * 0x55555556;\n\tv56 = v54 >> 0x3F;\n\tv57 = v54 >> 0x20;\n\tv58 = v57 + v56;\n\t// 37 NewArr v60 @ X0_v6 (System.Byte[]), typeof(System.Byte[]), v58 @ X22_v2 (System.Int32)\n\tthis.m_IndexedPixels = v60;\n\tv157 = new EM_Moments.Encoder.NeuQuant();\n\tEM_Moments.Encoder.NeuQuant::.ctor(v157, this.m_Pixels, v47.Length, this.m_SampleInterval);\n\tv231 = EM_Moments.Encoder.NeuQuant::Process(v157);\n\tthis.m_ColorTab = v231;\n\tv242 = v47.Length < 3;\n\tif (v242) goto L_00A5;\nL_0047:\n\tv151 = this.m_Pixels;\n\tv267 = v169 < v151.Length;\n\tv268 = ~v267;\n\tif (v268) goto L_00B2;\n\tv276 = v169 + 1;\n\tv277 = v276 < v151.Length;\n\tv278 = ~v277;\n\tif (v278) goto L_00B2;\n\tv136 = v276 + 1;\n\tv298 = v136 < v151.Length;\n\tv120 = ~v298;\n\tif (v120) goto L_00B2;\n\tv70 = v169 + 1;\n\tv299 = v169 + 2;\n\tv159 = EM_Moments.Encoder.NeuQuant::Map(v157, v151[v169 @ X8_v14 (System.Int32)], v151[v70 @ X10_v6 (System.Int32)], v151[v299 @ X8_v16 (System.Int32)]);\n\tv170 = this.m_UsedEntry;\n\tv301 = v159 < v170.Length;\n\tv121 = ~v301;\n\tif (v121) goto L_00B2;\n\tv170[v159 @ X0_v17 (System.Int32)] = 1;\n\tv171 = this.m_IndexedPixels;\n\tv245 = v138 - 0x20;\n\tv303 = v245 < v171.Length;\n\tv293 = ~v303;\n\tif (v293) goto L_00B2;\n\t*([v171 @ X8_v19 (System.Byte[])+v138 @ X23_v6 (System.Int32)]) = v159;\n\tv304 = v138 - 0x1F;\n\tv138 = v138 + 1;\n\tv169 = v136 + 1;\n\tv246 = v304 < v58;\n\tif (v246) goto L_0047;\nL_00A5:\n\tthis.m_Pixels = 0;\n\tthis.m_ColorDepth = 8;\n\tthis.m_PaletteSize = 7;\n\treturn;\nL_00B2:\n\tv297 = new System.IndexOutOfRangeException();\n\tthrow v297;\n\tthrow System.NullReferenceException;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void AnalyzePixels()
		{
			byte[] pixels = m_Pixels;
			int num = pixels.Length * 1431655766;
			int num2 = num >> 63;
			int num3 = num >> 32;
			int num4 = num3 + num2;
			byte[] indexedPixels = new byte[num4];
			m_IndexedPixels = indexedPixels;
			NeuQuant neuQuant = new NeuQuant(m_Pixels, pixels.Length, m_SampleInterval);
			byte[] colorTab = neuQuant.Process();
			m_ColorTab = colorTab;
			if (pixels.Length >= 3)
			{
				int num5 = 32;
				int num6 = 0;
				while (true)
				{
					byte[] pixels2 = m_Pixels;
					if (num6 < pixels2.Length)
					{
						int num7 = num6 + 1;
						if (num7 < pixels2.Length)
						{
							int num8 = num7 + 1;
							if (num8 < pixels2.Length)
							{
								int num9 = num6 + 1;
								int num10 = num6 + 2;
								int num11 = neuQuant.Map(pixels2[num6], pixels2[num9], pixels2[num10]);
								bool[] usedEntry = m_UsedEntry;
								if (num11 < usedEntry.Length)
								{
									usedEntry[num11] = true;
									byte[] indexedPixels2 = m_IndexedPixels;
									int num12 = num5 - 32;
									if (num12 < indexedPixels2.Length)
									{
										int num13 = num5 - 31;
										num5++;
										num6 = num8 + 1;
										if (num13 >= num4)
										{
											break;
										}
										continue;
									}
								}
							}
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			m_Pixels = null;
			m_ColorDepth = 8;
			m_PaletteSize = 7;
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0xA3F824", Offset = "0xA3F824", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EFF930]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E6F]) = v38;\nL_001A:\n\tv45 = System.IO.FileStream::WriteByte(this.m_FileStream, 0x21);\n\tv70 = System.IO.FileStream::WriteByte(this.m_FileStream, 0xF9);\n\tv94 = System.IO.FileStream::WriteByte(this.m_FileStream, 4);\n\tv89 = this.m_FileStream;\n\tgoto L_003A;\n\tv101 = *([v97 @ X0_v13+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_003A;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v97, v93, v72, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003A:\n\tv80 = System.Convert::ToByte(0);\n\tv129 = System.IO.FileStream::WriteByte(v89, v80);\n\tEM_Moments.Encoder.GifEncoder::WriteShort(this, this.m_FrameDelay);\n\tv81 = System.Convert::ToByte(0);\n\tv135 = System.IO.FileStream::WriteByte(this.m_FileStream, v81);\n\tv60 = this.m_FileStream;\n\tv123 = *([v60 @ X0_v24 (System.IO.FileStream)]);\n\tv110 = *([v123 @ X8_v14 (Il2CppClass<System.IO.FileStream>)+310]);\n\tv114 = *([v123 @ X8_v14 (Il2CppClass<System.IO.FileStream>)+318]);\n\t// 94 IndirectJump v110 @ X3_v1, v60 @ X0_v24 (System.IO.FileStream), v60 @ X0_v24 (System.IO.FileStream), 0, v114 @ X2_v8, v110 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void WriteGraphicCtrlExt()
		{
			//IL_00b4: Expected I, but got O
			//IL_00c4: Expected O, but got I
			//IL_00d4: Expected O, but got I
			m_FileStream.WriteByte(33);
			m_FileStream.WriteByte(249);
			m_FileStream.WriteByte(4);
			FileStream fileStream = m_FileStream;
			byte value = Convert.ToByte(0);
			fileStream.WriteByte(value);
			WriteShort(m_FrameDelay);
			byte value2 = Convert.ToByte(0);
			m_FileStream.WriteByte(value2);
			FileStream fileStream2 = m_FileStream;
			IntPtr intPtr = (IntPtr)fileStream2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ X8_v14 (Il2CppClass<System.IO.FileStream>)+310]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ X8_v14 (Il2CppClass<System.IO.FileStream>)+318]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v110 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0xA3F960", Offset = "0xA3F960", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ECABC0]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E70]) = v38;\nL_0013:\n\tv39 = this.m_FileStream;\n\tv45 = System.IO.FileStream::WriteByte(v39, 0x2C);\n\tEM_Moments.Encoder.GifEncoder::WriteShort(this, 0);\n\tEM_Moments.Encoder.GifEncoder::WriteShort(this, 0);\n\tEM_Moments.Encoder.GifEncoder::WriteShort(this, this.m_Width);\n\tEM_Moments.Encoder.GifEncoder::WriteShort(this, this.m_Height);\n\tv69 = this.m_FileStream;\n\tv95 = ~this.m_IsFirstFrame;\n\tif (v95) goto L_0038;\n\tv90 = *([v69 @ X20_v3 (System.IO.FileStream)]);\n\tgoto L_0046;\nL_0038:\n\tgoto L_003E;\n\tv105 = *([v98 @ X0_v13+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_003E;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v98, v55, v44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003E:\n\tv111 = this.m_PaletteSize | 0x80;\n\tv59 = System.Convert::ToByte(v111);\n\tv90 = *([v69 @ X20_v3 (System.IO.FileStream)]);\nL_0046:\n\tv77 = *([v90 @ X8_v6 (Il2CppClass<System.IO.FileStream>)+310]);\n\tv79 = *([v90 @ X8_v6 (Il2CppClass<System.IO.FileStream>)+318]);\n\t// 77 IndirectJump v77 @ X3_v1, v84 @ X0_v12 (System.IO.FileStream), v84 @ X0_v12 (System.IO.FileStream), v82 @ X1_v7 (System.Byte), v79 @ X2_v3, v77 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void WriteImageDesc()
		{
			//IL_0079: Expected I, but got O
			//IL_00b6: Expected I, but got O
			//IL_00da: Expected O, but got I
			//IL_00ea: Expected O, but got I
			FileStream fileStream = m_FileStream;
			fileStream.WriteByte(44);
			WriteShort(0);
			WriteShort(0);
			WriteShort(m_Width);
			WriteShort(m_Height);
			FileStream fileStream2 = m_FileStream;
			if (m_IsFirstFrame)
			{
				IntPtr intPtr = (IntPtr)fileStream2;
				byte b = 0;
			}
			else
			{
				int value = m_PaletteSize | 0x80;
				byte b2 = Convert.ToByte(value);
				IntPtr intPtr = (IntPtr)fileStream2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X8_v6 (Il2CppClass<System.IO.FileStream>)+310]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X8_v6 (Il2CppClass<System.IO.FileStream>)+318]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v77 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0xA3F594", Offset = "0xA3F594", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EF4B60]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E71]) = v40;\nL_0016:\n\tEM_Moments.Encoder.GifEncoder::WriteShort(this, this.m_Width);\n\tEM_Moments.Encoder.GifEncoder::WriteShort(this, this.m_Height);\n\tgoto L_0028;\n\tv53 = *([v49 @ X0_v4+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0028;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0028:\n\tv60 = this.m_PaletteSize | 0xF0;\n\tv62 = System.Convert::ToByte(v60);\n\tv69 = System.IO.FileStream::WriteByte(this.m_FileStream, v62);\n\tv77 = System.IO.FileStream::WriteByte(this.m_FileStream, 0);\n\tv78 = this.m_FileStream;\n\tv88 = *([v78 @ X0_v15 (System.IO.FileStream)]);\n\tv94 = *([v88 @ X8_v10 (Il2CppClass<System.IO.FileStream>)+310]);\n\tv95 = *([v88 @ X8_v10 (Il2CppClass<System.IO.FileStream>)+318]);\n\t// 72 IndirectJump v94 @ X3_v1, v78 @ X0_v15 (System.IO.FileStream), v78 @ X0_v15 (System.IO.FileStream), 0, v95 @ X2_v4, v94 @ X3_v1, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void WriteLSD()
		{
			//IL_0062: Expected I, but got O
			//IL_0072: Expected O, but got I
			//IL_0082: Expected O, but got I
			while (true)
			{
				WriteShort(m_Width);
				WriteShort(m_Height);
				int value = m_PaletteSize | 0xF0;
				byte value2 = Convert.ToByte(value);
				m_FileStream.WriteByte(value2);
				m_FileStream.WriteByte(0);
				FileStream fileStream = m_FileStream;
				IntPtr intPtr = (IntPtr)fileStream;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v10 (Il2CppClass<System.IO.FileStream>)+310]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v10 (Il2CppClass<System.IO.FileStream>)+318]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v94 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0xA3F71C", Offset = "0xA3F71C", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F07388]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E72]) = v38;\nL_001A:\n\tv45 = System.IO.FileStream::WriteByte(this.m_FileStream, 0x21);\n\tv80 = System.IO.FileStream::WriteByte(this.m_FileStream, 0xFF);\n\tv65 = this.m_FileStream;\n\tv83 = System.IO.FileStream::WriteByte(v65, 0xB);\n\tEM_Moments.Encoder.GifEncoder::WriteString(this, \"NETSCAPE2.0\");\n\tv105 = System.IO.FileStream::WriteByte(this.m_FileStream, 3);\n\tv67 = this.m_FileStream;\n\tv107 = System.IO.FileStream::WriteByte(v67, 1);\n\tEM_Moments.Encoder.GifEncoder::WriteShort(this, this.m_Repeat);\n\tv68 = this.m_FileStream;\n\tv100 = *([v68 @ X0_v16 (System.IO.FileStream)]);\n\tv87 = *([v100 @ X8_v11 (Il2CppClass<System.IO.FileStream>)+310]);\n\tv91 = *([v100 @ X8_v11 (Il2CppClass<System.IO.FileStream>)+318]);\n\t// 79 IndirectJump v87 @ X3_v1, v68 @ X0_v16 (System.IO.FileStream), v68 @ X0_v16 (System.IO.FileStream), 0, v91 @ X2_v7, v87 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void WriteNetscapeExt()
		{
			//IL_00a9: Expected I, but got O
			//IL_00b9: Expected O, but got I
			//IL_00c9: Expected O, but got I
			m_FileStream.WriteByte(33);
			m_FileStream.WriteByte(byte.MaxValue);
			FileStream fileStream = m_FileStream;
			fileStream.WriteByte(11);
			WriteString("NETSCAPE2.0");
			m_FileStream.WriteByte(3);
			FileStream fileStream2 = m_FileStream;
			fileStream2.WriteByte(1);
			WriteShort(m_Repeat);
			FileStream fileStream3 = m_FileStream;
			IntPtr intPtr = (IntPtr)fileStream3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v11 (Il2CppClass<System.IO.FileStream>)+310]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v11 (Il2CppClass<System.IO.FileStream>)+318]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v87 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0xA3F680", Offset = "0xA3F680", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.m_ColorTab;\n\tv34 = System.IO.FileStream::Write(this.m_FileStream, this.m_ColorTab, 0, v14.Length);\n\tv32 = this.m_ColorTab;\n\tv80 = 0x300 - v32.Length;\n\tv108 = v80 < 1;\n\tif (v108) goto L_0042;\nL_002E:\n\tv137 = System.IO.FileStream::WriteByte(this.m_FileStream, 0);\n\tv51 = v51 + 1;\n\tv113 = v51 < v80;\n\tif (v113) goto L_002E;\nL_0042:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void WritePalette()
		{
			byte[] colorTab = m_ColorTab;
			m_FileStream.Write(m_ColorTab, 0, colorTab.Length);
			byte[] colorTab2 = m_ColorTab;
			int num = 768 - colorTab2.Length;
			if (num >= 1)
			{
				int num2 = 0;
				do
				{
					m_FileStream.WriteByte(0);
					num2++;
				}
				while (num2 < num);
			}
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0xA3FA60", Offset = "0xA3FA60", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1F0D0E8]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E73]) = v42;\nL_001A:\n\tv48 = new EM_Moments.Encoder.LzwEncoder();\n\tEM_Moments.Encoder.LzwEncoder::.ctor(v48, methodInfo, v26, this.m_IndexedPixels, this.m_ColorDepth);\n\tEM_Moments.Encoder.LzwEncoder::Encode(v48, this.m_FileStream);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void WritePixels()
		{
			IntPtr intPtr = default(IntPtr);
			int height = default(int);
			LzwEncoder lzwEncoder = new LzwEncoder((int)(long)intPtr, height, m_IndexedPixels, m_ColorDepth);
			lzwEncoder.Encode(m_FileStream);
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0xA40488", Offset = "0xA40488", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1F0D9F8]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021E74]) = v41;\nL_001C:\n\tgoto L_0022;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0022;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv56 = value & 0xFF;\n\tv58 = System.Convert::ToByte(v56);\n\tv65 = System.IO.FileStream::WriteByte(this.m_FileStream, v58);\n\tv66 = this.m_FileStream;\n\tv67 = value >> 8;\n\tv68 = v67 & 0xFF;\n\tv70 = System.Convert::ToByte(v68);\n\tv83 = *([v66 @ X20_v3 (System.IO.FileStream)]);\n\tv89 = *([v83 @ X8_v9 (Il2CppClass<System.IO.FileStream>)+310]);\n\tv90 = *([v83 @ X8_v9 (Il2CppClass<System.IO.FileStream>)+318]);\n\t// 63 IndirectJump v89 @ X3_v1, v66 @ X20_v3 (System.IO.FileStream), v66 @ X20_v3 (System.IO.FileStream), v70 @ X0_v13 (System.Byte), v90 @ X2_v3, v89 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void WriteShort(int value)
		{
			//IL_0074: Expected I, but got O
			//IL_0084: Expected O, but got I
			//IL_0094: Expected O, but got I
			while (true)
			{
				int value2 = value & 0xFF;
				byte value3 = Convert.ToByte(value2);
				m_FileStream.WriteByte(value3);
				FileStream fileStream = m_FileStream;
				int num = value >> 8;
				int value4 = num & 0xFF;
				byte b = Convert.ToByte(value4);
				IntPtr intPtr = (IntPtr)fileStream;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X8_v9 (Il2CppClass<System.IO.FileStream>)+310]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X8_v9 (Il2CppClass<System.IO.FileStream>)+318]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v89 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0xA3FC1C", Offset = "0xA3FC1C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = System.String::ToCharArray(s);\n\tv128 = v18.Length;\n\tv98 = v18.Length < 1;\n\tif (v98) goto L_0046;\nL_001E:\n\tv213 = v108 < v128;\n\tv126 = ~v213;\n\tif (v126) goto L_0048;\n\tv198 = System.IO.FileStream::WriteByte(this.m_FileStream, v18[v108 @ X21_v7 (System.Int32)]);\n\tv128 = v18.Length;\n\tv108 = v108 + 1;\n\tv187 = v108 < v18.Length;\n\tif (v187) goto L_001E;\nL_0046:\n\treturn;\n\tv135 = new System.NullReferenceException();\nL_0048:\n\tv204 = new System.IndexOutOfRangeException();\n\tthrow v204;\n\tthrow System.NullReferenceException;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void WriteString(string s)
		{
			char[] array = s.ToCharArray();
			int num = array.Length;
			if (array.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				m_FileStream.WriteByte((byte)array[num2]);
				num = array.Length;
				num2++;
				if (num2 >= array.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}
	}
}
