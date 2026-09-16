using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Tayx.Graphy.Graph;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Audio
{
	[Token(Token = "0x200003E")]
	public class G_AudioGraph : G_Graph
	{
		[SerializeField]
		[Token(Token = "0x40001AC")]
		[FieldOffset(Offset = "0x18")]
		private Image m_imageGraph;

		[SerializeField]
		[Token(Token = "0x40001AD")]
		[FieldOffset(Offset = "0x20")]
		private Image m_imageGraphHighestValues;

		[SerializeField]
		[Token(Token = "0x40001AE")]
		[FieldOffset(Offset = "0x28")]
		private Shader ShaderFull;

		[SerializeField]
		[Token(Token = "0x40001AF")]
		[FieldOffset(Offset = "0x30")]
		private Shader ShaderLight;

		[Token(Token = "0x40001B0")]
		[FieldOffset(Offset = "0x38")]
		private GraphyManager m_graphyManager;

		[Token(Token = "0x40001B1")]
		[FieldOffset(Offset = "0x40")]
		private G_AudioMonitor m_audioMonitor;

		[Token(Token = "0x40001B2")]
		[FieldOffset(Offset = "0x48")]
		private int m_resolution;

		[Token(Token = "0x40001B3")]
		[FieldOffset(Offset = "0x50")]
		private G_GraphShader m_shaderGraph;

		[Token(Token = "0x40001B4")]
		[FieldOffset(Offset = "0x58")]
		private G_GraphShader m_shaderGraphHighestValues;

		[Token(Token = "0x40001B5")]
		[FieldOffset(Offset = "0x60")]
		private float[] m_graphArray;

		[Token(Token = "0x40001B6")]
		[FieldOffset(Offset = "0x68")]
		private float[] m_graphArrayHighestValue;

		[Token(Token = "0x60001B3")]
		[Address(RVA = "0xB0C870", Offset = "0xB0C870", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Audio.G_AudioGraph::Init(this);\n\treturn;\n")]
		private void OnEnable()
		{
			Init();
		}

		[Token(Token = "0x60001B4")]
		[Address(RVA = "0xB0C95C", Offset = "0xB0C95C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = Tayx.Graphy.Audio.G_AudioMonitor::get_SpectrumDataAvailable(this.m_audioMonitor);\n\tv30 = v12 == 0;\n\tif (v30) goto L_001A;\n\tv31 = this->klass;\n\tv35 = this->klass->vtable[4];\n\tv36 = this->klass->vtable[4];\n\t// 21 IndirectJump v35 @ X2_v1, this @ X0 (Tayx.Graphy.Audio.G_AudioGraph), this @ X0 (Tayx.Graphy.Audio.G_AudioGraph), v36 @ X1_v1, v35 @ X2_v1, v16 @ X3, v17 @ X4, v18 @ X5, v19 @ X6, v20 @ X7, v21 @ V0, v22 @ V1, v23 @ V2, v24 @ V3, v25 @ V4, v26 @ V5, v27 @ V6, v28 @ V7\nL_001A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_0031: Expected I, but got O
			//IL_0041: Expected O, but got I
			//IL_0051: Expected O, but got I
			if (m_audioMonitor.SpectrumDataAvailable)
			{
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X8_v1 (Il2CppClass<Tayx.Graphy.Audio.G_AudioGraph>)+170]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ X8_v1 (Il2CppClass<Tayx.Graphy.Audio.G_AudioGraph>)+178]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v35 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60001B5")]
		[Address(RVA = "0xB0CA14", Offset = "0xB0CA14", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EE34F8]);\n\tv27 = *([v26 @ X8_v24]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20224FA]) = v46;\nL_0017:\n\tv47 = this.m_graphyManager;\n\tv50 = v47.m_graphyMode == 0;\n\tif (v50) goto L_0050;\n\tv96 = v47.m_graphyMode != 1;\n\tif (v96) goto L_0084;\n\tv94 = this + 0x50;\n\tv161 = this.m_shaderGraph;\n\tv161.ArrayMaxSize = 0x80;\n\tv162 = this.m_shaderGraph;\n\tv141 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v141, this.ShaderLight);\n\tv142 = UnityEngine.UI.Image::set_material(v162.Image, v141);\n\tv163 = this.m_shaderGraphHighestValues;\n\tv163.ArrayMaxSize = 0x80;\n\tv164 = this.m_shaderGraphHighestValues;\n\tv174 = v164.Image;\n\tv73 = this.ShaderLight;\n\tgoto L_0076;\nL_0050:\n\tv94 = this + 0x50;\n\tv165 = this.m_shaderGraph;\n\tv165.ArrayMaxSize = 0x200;\n\tv166 = this.m_shaderGraph;\n\tv143 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v143, this.ShaderFull);\n\tv144 = UnityEngine.UI.Image::set_material(v166.Image, v143);\n\tv167 = this.m_shaderGraphHighestValues;\n\tv167.ArrayMaxSize = 0x200;\n\tv168 = this.m_shaderGraphHighestValues;\n\tv174 = v168.Image;\n\tv73 = this.ShaderFull;\nL_0076:\n\tv145 = new *([v78 @ X24_v5 (Il2CppClass<UnityEngine.Material>)])();\n\tUnityEngine.Material::.ctor(v145, v73);\n\tv210 = UnityEngine.UI.Image::set_material(v174, v145);\n\tgoto L_0088;\nL_0084:\n\tv94 = this + 0x50;\nL_0088:\n\tTayx.Graphy.G_GraphShader::InitializeShader(*([v94 @ X23_v3]));\n\tTayx.Graphy.G_GraphShader::InitializeShader(this.m_shaderGraphHighestValues);\n\tv170 = this.m_graphyManager;\n\tv228 = this->klass;\n\tthis.m_resolution = v170.m_audioGraphResolution;\n\tv220 = this->klass->vtable[5];\n\tv222 = this->klass->vtable[5];\n\t// 159 IndirectJump v220 @ X2_v4, this @ X0 (Tayx.Graphy.Audio.G_AudioGraph), this @ X0 (Tayx.Graphy.Audio.G_AudioGraph), v222 @ X1_v4, v220 @ X2_v4, v31 @ X3, v32 @ X4, v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateParameters()
		{
			//IL_010d: Expected O, but got I
			//IL_01d4: Expected O, but got I
			//IL_0058: Expected O, but got I
			//IL_01b1: Expected I, but got O
			//IL_0206: Expected I, but got O
			//IL_0225: Expected O, but got I
			//IL_0235: Expected O, but got I
			//IL_00fc: Expected I, but got O
			while (true)
			{
				GraphyManager graphyManager = m_graphyManager;
				object obj;
				Image image;
				Shader shader;
				if (graphyManager.GraphyMode != GraphyManager.Mode.FULL)
				{
					if (graphyManager.GraphyMode != GraphyManager.Mode.LIGHT)
					{
						obj = (long)(IntPtr)this + 80L;
						goto IL_01d9;
					}
					obj = (long)(IntPtr)this + 80L;
					G_GraphShader shaderGraph = m_shaderGraph;
					shaderGraph.ArrayMaxSize = 128;
					G_GraphShader shaderGraph2 = m_shaderGraph;
					Material material = new Material(ShaderLight);
					shaderGraph2.Image.material = material;
					G_GraphShader shaderGraphHighestValues = m_shaderGraphHighestValues;
					shaderGraphHighestValues.ArrayMaxSize = 128;
					G_GraphShader shaderGraphHighestValues2 = m_shaderGraphHighestValues;
					image = shaderGraphHighestValues2.Image;
					shader = ShaderLight;
					IntPtr intPtr = (IntPtr)typeof(Material);
				}
				else
				{
					obj = (long)(IntPtr)this + 80L;
					G_GraphShader shaderGraph3 = m_shaderGraph;
					shaderGraph3.ArrayMaxSize = 512;
					G_GraphShader shaderGraph4 = m_shaderGraph;
					Material material2 = new Material(ShaderFull);
					shaderGraph4.Image.material = material2;
					G_GraphShader shaderGraphHighestValues3 = m_shaderGraphHighestValues;
					shaderGraphHighestValues3.ArrayMaxSize = 512;
					G_GraphShader shaderGraphHighestValues4 = m_shaderGraphHighestValues;
					image = shaderGraphHighestValues4.Image;
					shader = ShaderFull;
					IntPtr intPtr = (IntPtr)typeof(Material);
				}
				Material material3 = new Material(shader);
				image.material = material3;
				goto IL_01d9;
				IL_01d9:
				((G_GraphShader)obj).InitializeShader();
				m_shaderGraphHighestValues.InitializeShader();
				GraphyManager graphyManager2 = m_graphyManager;
				IntPtr intPtr2 = (IntPtr)this;
				m_resolution = graphyManager2.AudioGraphResolution;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X9_v4 (Il2CppClass<Tayx.Graphy.Audio.G_AudioGraph>)+180]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X9_v4 (Il2CppClass<Tayx.Graphy.Audio.G_AudioGraph>)+188]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v220 @ X2_v4 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60001B6")]
		[Address(RVA = "0xB0CD2C", Offset = "0xB0CD2C", Length = "0x51C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv40 = *([1EEDBF8]);\n\tv41 = *([v40 @ X8_v73]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv60 = 0 | 1;\n\t*([20224FB]) = v60;\nL_001E:\n\tv61 = this.m_audioMonitor;\n\tv63 = v61.m_spectrum;\n\tgoto L_0035;\n\tv514 = *([v510 @ X0_v5+E0]);\n\tv515 = v514 == 0;\n\tv516 = ~v515;\n\tif (v516) goto L_0035;\n\tv518 = \"il2cpp_codegen_runtime_class_init\"(v510, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\nL_0035:\n\tv525 = v63.Length / this.m_resolution;\n\tv453 = UnityEngine.Mathf::FloorToInt(v525);\n\tv494 = this.m_resolution;\n\tv595 = this.m_resolution - 1;\n\tv596 = v595 & 0x80000000;\n\tv597 = v596 == 0;\n\tv598 = ~v597;\n\tif (v598) goto L_011B;\nL_0054:\n\tv104 = v453 < 1;\n\tif (v104) goto L_FFFFFFFF;\n\tv397 = this.m_audioMonitor;\n\tv398 = v397.m_spectrum;\n\tv337 = v634 << 0x20;\nL_0060:\n\tv693 = v634 + v490;\n\tv750 = v693 < v398.Length;\n\tv751 = ~v750;\n\tif (v751) goto L_028F;\n\tv676 = v337 >> 0x1E;\n\tv694 = v398 + v676;\n\tv490 = v490 + 1;\n\tv337 = v337 + 0x100000000;\n\tv433 = v433 + *([v694 @ X11_v28+20]);\n\tv674 = v490 < v453;\n\tif (v674) goto L_0060;\n\tgoto L_0088;\nL_0088:\n\tv86 = v378 - 1;\n\tv72 = v378 + 1;\n\tv106 = v378 <= 1;\n\tif (v106) goto L_00F4;\n\tv713 = v72 * 0x55555556;\n\tv399 = v713 >> 0x3F;\n\tv714 = v713 >> 0x20;\n\tv715 = v714 + v399;\n\tv119 = v715 << 1;\n\tv716 = v715 + v119;\n\tv719 = v72 != v716;\n\tif (v719) goto L_00F4;\n\tv867 = v433 / v453;\n\tv434 = Tayx.Graphy.Audio.G_AudioMonitor::lin2dB(v453, v867);\n\tv400 = this.m_graphArray;\n\tv921 = v86 < v400.Length;\n\tv823 = ~v921;\n\tif (v823) goto L_028F;\n\tv842 = v378 - 2;\n\tv942 = v842 < v400.Length;\n\tv824 = ~v942;\n\tif (v824) goto L_028F;\n\tv962 = v378 < v400.Length;\n\tv288 = ~v962;\n\tif (v288) goto L_028F;\n\tv967 = v434 + 160f;\n\tv968 = v967 / 160f;\n\tv969 = v968 + v400[v86 @ X27_v11 (System.Int32)];\n\tv970 = v969 + v400[v842 @ X8_v63 (System.Int32)];\n\tv435 = v970 / 3f;\n\tv400[v378 @ X25_v10 (System.Int32)] = v435;\n\tv401 = this.m_graphArray;\n\tv975 = v86 < v401.Length;\n\tv289 = ~v975;\n\tif (v289) goto L_028F;\n\tv401[v86 @ X27_v11 (System.Int32)] = v435;\n\tv402 = this.m_graphArray;\n\tv1005 = v842 < v402.Length;\n\tv825 = ~v1005;\n\tif (v825) goto L_028F;\n\tv943 = v842 << 2;\n\tv1007 = v402 + v943;\n\tv954 = v1007 + 0x20;\n\tgoto L_0109;\nL_00F4:\n\tv87 = this.m_graphArray;\n\tv759 = v433 / v453;\n\tv436 = Tayx.Graphy.Audio.G_AudioMonitor::lin2dB(v453, v759);\n\tv882 = v378 < v87.Length;\n\tv826 = ~v882;\n\tif (v826) goto L_028F;\n\tv922 = v436 + 160f;\n\tv923 = v378 << 2;\n\tv924 = v87 + v923;\n\tv620 = v922 / 160f;\n\tv954 = v924 + 0x20;\nL_0109:\n\t*([v954 @ X8_v50]) = v620;\n\tv494 = this.m_resolution;\n\tv956 = this.m_resolution - 1;\n\tv634 = v634 + v453;\n\tv605 = v72 <= v956;\n\tif (v605) goto L_0054;\nL_011B:\n\tv457 = this.m_shaderGraph;\n\tv638 = v494 - 1;\n\tv639 = v638 & 0x80000000;\n\tv640 = v639 == 0;\n\tv641 = ~v640;\n\tif (v641) goto L_015A;\nL_0124:\n\tv405 = this.m_graphArray;\n\tv723 = v495 < v405.Length;\n\tv292 = ~v723;\n\tif (v292) goto L_028F;\n\tv342 = v455.Array;\n\tv868 = v495 < v342.Length;\n\tv293 = ~v868;\n\tif (v293) goto L_028F;\n\tv342[v495 @ X8_v45 (System.Int32)] = v405[v495 @ X8_v45 (System.Int32)];\n\tv457 = this.m_shaderGraph;\n\tv495 = v495 + 1;\n\tv666 = this.m_resolution - 1;\n\tv645 = v495 <= v666;\n\tif (v645) goto L_0124;\nL_015A:\n\tTayx.Graphy.G_GraphShader::UpdatePoints(v457);\n\tv501 = this.m_resolution;\n\tv708 = this.m_resolution - 1;\n\tv709 = v708 & 0x80000000;\n\tv710 = v709 == 0;\n\tv711 = ~v710;\n\tif (v711) goto L_023E;\nL_0177:\n\tv109 = v453 < 1;\n\tif (v109) goto L_FFFFFFFF;\n\tv407 = this.m_audioMonitor;\n\tv408 = v407.m_spectrumHighestValues;\n\tv345 = v857 << 0x20;\nL_0183:\n\tv832 = v857 + v497;\n\tv960 = v832 < v408.Length;\n\tv827 = ~v960;\n\tif (v827) goto L_028F;\n\tv891 = v345 >> 0x1E;\n\tv908 = v408 + v891;\n\tv497 = v497 + 1;\n\tv345 = v345 + 0x100000000;\n\tv440 = v440 + *([v908 @ X11_v17+20]);\n\tv889 = v497 < v453;\n\tif (v889) goto L_0183;\n\tgoto L_01AB;\nL_01AB:\n\tv90 = v380 - 1;\n\tv75 = v380 + 1;\n\tv111 = v380 <= 1;\n\tif (v111) goto L_0217;\n\tv932 = v75 * 0x55555556;\n\tv409 = v932 >> 0x3F;\n\tv933 = v932 >> 0x20;\n\tv934 = v933 + v409;\n\tv128 = v934 << 1;\n\tv935 = v934 + v128;\n\tv938 = v75 != v935;\n\tif (v938) goto L_0217;\n\tv965 = v440 / v453;\n\tv441 = Tayx.Graphy.Audio.G_AudioMonitor::lin2dB(v457, v965);\n\tv410 = this.m_graphArrayHighestValue;\n\tv976 = v90 < v410.Length;\n\tv828 = ~v976;\n\tif (v828) goto L_028F;\n\tv844 = v380 - 2;\n\tv987 = v844 < v410.Length;\n\tv829 = ~v987;\n\tif (v829) goto L_028F;\n\tv1006 = v380 < v410.Length;\n\tv297 = ~v1006;\n\tif (v297) goto L_028F;\n\tv1008 = v441 + 160f;\n\tv1009 = v1008 / 160f;\n\tv1010 = v1009 + v410[v90 @ X27_v7 (System.Int32)];\n\tv1011 = v1010 + v410[v844 @ X8_v37 (System.Int32)];\n\tv442 = v1011 / 3f;\n\tv410[v380 @ X25_v7 (System.Int32)] = v442;\n\tv411 = this.m_graphArrayHighestValue;\n\tv1013 = v90 < v411.Length;\n\tv298 = ~v1013;\n\tif (v298) goto L_028F;\n\tv411[v90 @ X27_v7 (System.Int32)] = v442;\n\tv412 = this.m_graphArrayHighestValue;\n\tv1015 = v844 < v412.Length;\n\tv830 = ~v1015;\n\tif (v830) goto L_028F;\n\tv988 = v844 << 2;\n\tv1016 = v412 + v988;\n\tv999 = v1016 + 0x20;\n\tgoto L_022C;\nL_0217:\n\tv91 = this.m_graphArrayHighestValue;\n\tv961 = v440 / v453;\n\tv443 = Tayx.Graphy.Audio.G_AudioMonitor::lin2dB(v457, v961);\n\tv972 = v380 < v91.Length;\n\tv831 = ~v972;\n\tif (v831) goto L_028F;\n\tv977 = v443 + 160f;\n\tv978 = v380 << 2;\n\tv979 = v91 + v978;\n\tv745 = v977 / 160f;\n\tv999 = v979 + 0x20;\nL_022C:\n\t*([v999 @ X8_v24]) = v745;\n\tv501 = this.m_resolution;\n\tv1001 = this.m_resolution - 1;\n\tv857 = v857 + v453;\n\tv730 = v75 <= v1001;\n\tif (v730) goto L_0177;\nL_023E:\n\tv583 = this.m_shaderGraphHighestValues;\n\tv861 = v501 - 1;\n\tv862 = v861 & 0x80000000;\n\tv863 = v862 == 0;\n\tv864 = ~v863;\n\tif (v864) goto L_028D;\nL_0247:\n\tv415 = this.m_graphArrayHighestValue;\n\tv941 = v502 < v415.Length;\n\tv301 = ~v941;\n\tif (v301) goto L_028F;\n\tv350 = v459.Array;\n\tv966 = v502 < v350.Length;\n\tv302 = ~v966;\n\tif (v302) goto L_028F;\n\tv350[v502 @ X8_v19 (System.Int32)] = v415[v502 @ X8_v19 (System.Int32)];\n\tv583 = this.m_shaderGraphHighestValues;\n\tv502 = v502 + 1;\n\tv880 = this.m_resolution - 1;\n\tv871 = v502 <= v880;\n\tif (v871) goto L_0247;\nL_028D:\n\tTayx.Graphy.G_GraphShader::UpdatePoints(v583);\n\treturn;\nL_028F:\n\tv846 = new System.IndexOutOfRangeException();\n\tthrow v846;\n\tthrow System.NullReferenceException;\n// 432 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void UpdateGraph()
		{
			//IL_0068: Expected I4, but got I8
			//IL_04cd: Expected I4, but got I8
			//IL_0616: Expected I4, but got I8
			//IL_0a7b: Expected I4, but got I8
			//IL_041c: Expected O, but got I4
			//IL_047a: Expected O, but got I
			//IL_0499: Expected O, but got I
			//IL_022d: Expected O, but got I4
			//IL_013a: Expected O, but got I
			//IL_015a: Expected I4, but got I8
			//IL_0bfa: Expected O, but got F4
			//IL_0a28: Expected O, but got I
			//IL_0a47: Expected O, but got I
			//IL_06e8: Expected O, but got I
			//IL_0708: Expected I4, but got I8
			//IL_0c9b: Expected O, but got F4
			//IL_03d7: Expected O, but got I
			//IL_03e6: Expected O, but got I
			//IL_0985: Expected O, but got I
			//IL_0994: Expected O, but got I
			G_AudioMonitor audioMonitor = m_audioMonitor;
			float[] spectrum = audioMonitor.Spectrum;
			float f = (float)spectrum.Length / (float)m_resolution;
			int num = Mathf.FloorToInt(f);
			int resolution = m_resolution;
			int num2 = m_resolution - 1;
			if ((int)(num2 & 0x80000000L) != 0)
			{
				goto IL_049e;
			}
			int num3 = 0;
			int num4 = 0;
			while (true)
			{
				int num6;
				if (num >= 1)
				{
					G_AudioMonitor audioMonitor2 = m_audioMonitor;
					float[] spectrum2 = audioMonitor2.Spectrum;
					int num5 = num4 << 32;
					num6 = 0;
					int num7 = 0;
					while (true)
					{
						int num8 = num4 + num7;
						if (num8 >= spectrum2.Length)
						{
							break;
						}
						int num9 = num5 >> 30;
						object obj = (long)(IntPtr)spectrum2 + (long)num9;
						num7++;
						num5 = (int)(num5 + 4294967296L);
						int num10 = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ X11_v28+20]");
						num6 = (int)((long)num10 + 0L);
						if (num7 < num)
						{
							continue;
						}
						goto IL_0bb6;
					}
					break;
				}
				num6 = 0;
				goto IL_0bb6;
				IL_0bb6:
				int num11 = num3 - 1;
				int num12 = num3 + 1;
				float num27;
				object obj3;
				if (num3 > 1)
				{
					int num13 = num12 * 1431655766;
					int num14 = num13 >> 63;
					int num15 = num13 >> 32;
					int num16 = num15 + num14;
					int num17 = num16 << 1;
					int num18 = num16 + num17;
					if (num12 == num18)
					{
						float linear = (float)num6 / (float)num;
						float num19 = ((G_AudioMonitor)num).lin2dB(linear);
						float[] graphArray = m_graphArray;
						if (num11 >= graphArray.Length)
						{
							break;
						}
						int num20 = num3 - 2;
						if (num20 >= graphArray.Length || num3 >= graphArray.Length)
						{
							break;
						}
						float num21 = num19 + 160f;
						float num22 = num21 / 160f;
						float num23 = num22 + graphArray[num11];
						float num24 = num23 + graphArray[num20];
						float num25 = (graphArray[num3] = num24 / 3f);
						float[] graphArray2 = m_graphArray;
						if (num11 >= graphArray2.Length)
						{
							break;
						}
						graphArray2[num11] = num25;
						float[] graphArray3 = m_graphArray;
						if (num20 >= graphArray3.Length)
						{
							break;
						}
						int num26 = num20 << 2;
						object obj2 = (long)(IntPtr)graphArray3 + (long)num26;
						obj3 = (long)(IntPtr)obj2 + 32L;
						num27 = -1f;
						goto IL_0bf2;
					}
				}
				float[] graphArray4 = m_graphArray;
				float linear2 = (float)num6 / (float)num;
				float num28 = ((G_AudioMonitor)num).lin2dB(linear2);
				if (num3 >= graphArray4.Length)
				{
					break;
				}
				float num29 = num28 + 160f;
				int num30 = num3 << 2;
				object obj4 = (long)(IntPtr)graphArray4 + (long)num30;
				num27 = num29 / 160f;
				obj3 = (long)(IntPtr)obj4 + 32L;
				goto IL_0bf2;
				IL_0bf2:
				obj3 = num27;
				resolution = m_resolution;
				int num31 = m_resolution - 1;
				num4 += num;
				bool flag = num12 <= num31;
				num3 = num12;
				if (flag)
				{
					continue;
				}
				goto IL_049e;
			}
			goto IL_0b99;
			IL_05e1:
			G_GraphShader shaderGraph;
			shaderGraph.UpdatePoints();
			int resolution2 = m_resolution;
			int num32 = m_resolution - 1;
			if ((int)(num32 & 0x80000000L) != 0)
			{
				goto IL_0a4c;
			}
			int num33 = 0;
			int num34 = 0;
			while (true)
			{
				int num36;
				if (num >= 1)
				{
					G_AudioMonitor audioMonitor3 = m_audioMonitor;
					float[] spectrumHighestValues = audioMonitor3.SpectrumHighestValues;
					int num35 = num34 << 32;
					num36 = 0;
					int num37 = 0;
					while (true)
					{
						int num38 = num34 + num37;
						if (num38 >= spectrumHighestValues.Length)
						{
							break;
						}
						int num39 = num35 >> 30;
						object obj5 = (long)(IntPtr)spectrumHighestValues + (long)num39;
						num37++;
						num35 = (int)(num35 + 4294967296L);
						int num40 = num36;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v908 @ X11_v17+20]");
						num36 = (int)((long)num40 + 0L);
						if (num37 < num)
						{
							continue;
						}
						goto IL_0c57;
					}
					break;
				}
				num36 = 0;
				goto IL_0c57;
				IL_0c57:
				int num41 = num33 - 1;
				int num42 = num33 + 1;
				float num57;
				object obj7;
				if (num33 > 1)
				{
					int num43 = num42 * 1431655766;
					int num44 = num43 >> 63;
					int num45 = num43 >> 32;
					int num46 = num45 + num44;
					int num47 = num46 << 1;
					int num48 = num46 + num47;
					if (num42 == num48)
					{
						float linear3 = (float)num36 / (float)num;
						float num49 = ((G_AudioMonitor)(object)shaderGraph).lin2dB(linear3);
						float[] graphArrayHighestValue = m_graphArrayHighestValue;
						if (num41 >= graphArrayHighestValue.Length)
						{
							break;
						}
						int num50 = num33 - 2;
						if (num50 >= graphArrayHighestValue.Length || num33 >= graphArrayHighestValue.Length)
						{
							break;
						}
						float num51 = num49 + 160f;
						float num52 = num51 / 160f;
						float num53 = num52 + graphArrayHighestValue[num41];
						float num54 = num53 + graphArrayHighestValue[num50];
						float num55 = (graphArrayHighestValue[num33] = num54 / 3f);
						float[] graphArrayHighestValue2 = m_graphArrayHighestValue;
						if (num41 >= graphArrayHighestValue2.Length)
						{
							break;
						}
						graphArrayHighestValue2[num41] = num55;
						float[] graphArrayHighestValue3 = m_graphArrayHighestValue;
						if (num50 >= graphArrayHighestValue3.Length)
						{
							break;
						}
						int num56 = num50 << 2;
						object obj6 = (long)(IntPtr)graphArrayHighestValue3 + (long)num56;
						obj7 = (long)(IntPtr)obj6 + 32L;
						num57 = -1f;
						goto IL_0c93;
					}
				}
				float[] graphArrayHighestValue4 = m_graphArrayHighestValue;
				float linear4 = (float)num36 / (float)num;
				float num58 = ((G_AudioMonitor)(object)shaderGraph).lin2dB(linear4);
				if (num33 >= graphArrayHighestValue4.Length)
				{
					break;
				}
				float num59 = num58 + 160f;
				int num60 = num33 << 2;
				object obj8 = (long)(IntPtr)graphArrayHighestValue4 + (long)num60;
				num57 = num59 / 160f;
				obj7 = (long)(IntPtr)obj8 + 32L;
				goto IL_0c93;
				IL_0c93:
				obj7 = num57;
				resolution2 = m_resolution;
				int num61 = m_resolution - 1;
				num34 += num;
				bool flag2 = num42 <= num61;
				num33 = num42;
				if (flag2)
				{
					continue;
				}
				goto IL_0a4c;
			}
			goto IL_0b99;
			IL_049e:
			shaderGraph = m_shaderGraph;
			int num62 = resolution - 1;
			if ((int)(num62 & 0x80000000L) != 0)
			{
				goto IL_05e1;
			}
			G_GraphShader shaderGraph2 = m_shaderGraph;
			int num63 = 0;
			while (true)
			{
				float[] graphArray5 = m_graphArray;
				if (num63 >= graphArray5.Length)
				{
					break;
				}
				float[] array = shaderGraph2.Array;
				if (num63 >= array.Length)
				{
					break;
				}
				array[num63] = graphArray5[num63];
				shaderGraph = m_shaderGraph;
				num63++;
				int num64 = m_resolution - 1;
				bool flag3 = num63 <= num64;
				shaderGraph2 = m_shaderGraph;
				if (flag3)
				{
					continue;
				}
				goto IL_05e1;
			}
			goto IL_0b99;
			IL_0b99:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_0b8f:
			G_GraphShader shaderGraphHighestValues;
			shaderGraphHighestValues.UpdatePoints();
			return;
			IL_0a4c:
			shaderGraphHighestValues = m_shaderGraphHighestValues;
			int num65 = resolution2 - 1;
			if ((int)(num65 & 0x80000000L) != 0)
			{
				goto IL_0b8f;
			}
			G_GraphShader shaderGraphHighestValues2 = m_shaderGraphHighestValues;
			int num66 = 0;
			while (true)
			{
				float[] graphArrayHighestValue5 = m_graphArrayHighestValue;
				if (num66 >= graphArrayHighestValue5.Length)
				{
					break;
				}
				float[] array2 = shaderGraphHighestValues2.Array;
				if (num66 >= array2.Length)
				{
					break;
				}
				array2[num66] = graphArrayHighestValue5[num66];
				shaderGraphHighestValues = m_shaderGraphHighestValues;
				num66++;
				int num67 = m_resolution - 1;
				bool flag4 = num66 <= num67;
				shaderGraphHighestValues2 = m_shaderGraphHighestValues;
				if (flag4)
				{
					continue;
				}
				goto IL_0b8f;
			}
			goto IL_0b99;
		}

		[Token(Token = "0x60001B7")]
		[Address(RVA = "0xB0D32C", Offset = "0xB0D32C", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1ECAD30]);\n\tv21 = *([v20 @ X8_v31]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20224FC]) = v40;\nL_0015:\n\tv42 = this.m_shaderGraph;\n\t// 25 NewArr v46 @ X0_v3 (System.Single[]), typeof(System.Single[]), this.m_resolution (System.Int32)\n\tv42.Array = v46;\n\tv50 = this.m_shaderGraphHighestValues;\n\t// 32 NewArr v51 @ X0_v13 (System.Single[]), typeof(System.Single[]), this.m_resolution (System.Int32)\n\tv50.Array = v51;\n\t// 38 NewArr v215 @ X0_v15 (System.Single[]), typeof(System.Single[]), this.m_resolution (System.Int32)\n\tthis.m_graphArray = v215;\n\t// 42 NewArr v138 @ X0_v17 (System.Single[]), typeof(System.Single[]), this.m_resolution (System.Int32)\n\tv128 = this.m_shaderGraph;\n\tthis.m_graphArrayHighestValue = v138;\n\tv265 = this.m_resolution < 1;\n\tif (v265) goto L_0072;\nL_003D:\n\tv70 = v126.Array;\n\tv312 = v169 < v70.Length;\n\tv122 = ~v312;\n\tif (v122) goto L_00FA;\n\tv70[v169 @ X8_v27 (System.Int32)] = 0;\n\tv71 = this.m_shaderGraphHighestValues;\n\tv72 = v71.Array;\n\tv315 = v169 < v72.Length;\n\tv204 = ~v315;\n\tif (v204) goto L_00FA;\n\tv72[v169 @ X8_v27 (System.Int32)] = 0;\n\tv128 = this.m_shaderGraph;\n\tv169 = v169 + 1;\n\tv269 = v169 < this.m_resolution;\n\tif (v269) goto L_003D;\nL_0072:\n\tv170 = this.m_graphyManager;\n\tv128.GoodColor.r = v170.m_audioGraphColor;\n\tv128.GoodColor.g = v170.m_audioGraphColor.g;\n\tv128.GoodColor.a = v170.m_audioGraphColor.a;\n\tv171 = this.m_graphyManager;\n\tv129 = this.m_shaderGraph;\n\tv129.CautionColor.r = v171.m_audioGraphColor;\n\tv129.CautionColor.g = v171.m_audioGraphColor.g;\n\tv129.CautionColor.a = v171.m_audioGraphColor.a;\n\tv172 = this.m_graphyManager;\n\tv130 = this.m_shaderGraph;\n\tv130.CriticalColor.r = v172.m_audioGraphColor;\n\tv130.CriticalColor.g = v172.m_audioGraphColor.g;\n\tv130.CriticalColor.a = v172.m_audioGraphColor.a;\n\tTayx.Graphy.G_GraphShader::UpdateColors(this.m_shaderGraph);\n\tv173 = this.m_graphyManager;\n\tv131 = this.m_shaderGraphHighestValues;\n\tv131.GoodColor.r = v173.m_audioGraphColor;\n\tv131.GoodColor.g = v173.m_audioGraphColor.g;\n\tv131.GoodColor.a = v173.m_audioGraphColor.a;\n\tv174 = this.m_graphyManager;\n\tv132 = this.m_shaderGraphHighestValues;\n\tv132.CautionColor.r = v174.m_audioGraphColor;\n\tv132.CautionColor.g = v174.m_audioGraphColor.g;\n\tv132.CautionColor.a = v174.m_audioGraphColor.a;\n\tv175 = this.m_graphyManager;\n\tv133 = this.m_shaderGraphHighestValues;\n\tv133.CriticalColor.r = v175.m_audioGraphColor;\n\tv133.CriticalColor.g = v175.m_audioGraphColor.g;\n\tv133.CriticalColor.a = v175.m_audioGraphColor.a;\n\tTayx.Graphy.G_GraphShader::UpdateColors(this.m_shaderGraphHighestValues);\n\tv176 = this.m_shaderGraph;\n\tv176.GoodThreshold = 0f;\n\tv177 = this.m_shaderGraph;\n\tv177.CautionThreshold = 0f;\n\tTayx.Graphy.G_GraphShader::UpdateThresholds(this.m_shaderGraph);\n\tv178 = this.m_shaderGraphHighestValues;\n\tv178.GoodThreshold = 0f;\n\tv179 = this.m_shaderGraphHighestValues;\n\tv179.CautionThreshold = 0f;\n\tTayx.Graphy.G_GraphShader::UpdateThresholds(this.m_shaderGraphHighestValues);\n\tTayx.Graphy.G_GraphShader::UpdateArray(this.m_shaderGraph);\n\tTayx.Graphy.G_GraphShader::UpdateArray(this.m_shaderGraphHighestValues);\n\tv180 = this.m_shaderGraph;\n\tv180.Average = 0f;\n\tTayx.Graphy.G_GraphShader::UpdateAverage(this.m_shaderGraph);\n\tv181 = this.m_shaderGraphHighestValues;\n\tv181.Average = 0f;\n\tTayx.Graphy.G_GraphShader::UpdateAverage(this.m_shaderGraphHighestValues);\n\treturn;\n\tv183 = new System.NullReferenceException();\nL_00FA:\n\tv212 = new System.IndexOutOfRangeException();\n\tthrow v212;\n\tthrow System.NullReferenceException;\n// 168 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void CreatePoints()
		{
			G_GraphShader shaderGraph = m_shaderGraph;
			float[] array = new float[m_resolution];
			shaderGraph.Array = array;
			G_GraphShader shaderGraphHighestValues = m_shaderGraphHighestValues;
			float[] array2 = new float[m_resolution];
			shaderGraphHighestValues.Array = array2;
			float[] graphArray = new float[m_resolution];
			m_graphArray = graphArray;
			float[] graphArrayHighestValue = new float[m_resolution];
			G_GraphShader shaderGraph2 = m_shaderGraph;
			m_graphArrayHighestValue = graphArrayHighestValue;
			if (m_resolution >= 1)
			{
				G_GraphShader g_GraphShader = shaderGraph2;
				int num = 0;
				while (true)
				{
					float[] array3 = g_GraphShader.Array;
					if (num < array3.Length)
					{
						array3[num] = 0f;
						G_GraphShader shaderGraphHighestValues2 = m_shaderGraphHighestValues;
						float[] array4 = shaderGraphHighestValues2.Array;
						if (num < array4.Length)
						{
							array4[num] = 0f;
							shaderGraph2 = m_shaderGraph;
							num++;
							bool flag = num < m_resolution;
							g_GraphShader = m_shaderGraph;
							if (!flag)
							{
								break;
							}
							continue;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			GraphyManager graphyManager = m_graphyManager;
			shaderGraph2.GoodColor.r = graphyManager.m_audioGraphColor.r;
			shaderGraph2.GoodColor.g = graphyManager.m_audioGraphColor.g;
			shaderGraph2.GoodColor.a = graphyManager.m_audioGraphColor.a;
			GraphyManager graphyManager2 = m_graphyManager;
			G_GraphShader shaderGraph3 = m_shaderGraph;
			shaderGraph3.CautionColor.r = graphyManager2.m_audioGraphColor.r;
			shaderGraph3.CautionColor.g = graphyManager2.m_audioGraphColor.g;
			shaderGraph3.CautionColor.a = graphyManager2.m_audioGraphColor.a;
			GraphyManager graphyManager3 = m_graphyManager;
			G_GraphShader shaderGraph4 = m_shaderGraph;
			shaderGraph4.CriticalColor.r = graphyManager3.m_audioGraphColor.r;
			shaderGraph4.CriticalColor.g = graphyManager3.m_audioGraphColor.g;
			shaderGraph4.CriticalColor.a = graphyManager3.m_audioGraphColor.a;
			m_shaderGraph.UpdateColors();
			GraphyManager graphyManager4 = m_graphyManager;
			G_GraphShader shaderGraphHighestValues3 = m_shaderGraphHighestValues;
			shaderGraphHighestValues3.GoodColor.r = graphyManager4.m_audioGraphColor.r;
			shaderGraphHighestValues3.GoodColor.g = graphyManager4.m_audioGraphColor.g;
			shaderGraphHighestValues3.GoodColor.a = graphyManager4.m_audioGraphColor.a;
			GraphyManager graphyManager5 = m_graphyManager;
			G_GraphShader shaderGraphHighestValues4 = m_shaderGraphHighestValues;
			shaderGraphHighestValues4.CautionColor.r = graphyManager5.m_audioGraphColor.r;
			shaderGraphHighestValues4.CautionColor.g = graphyManager5.m_audioGraphColor.g;
			shaderGraphHighestValues4.CautionColor.a = graphyManager5.m_audioGraphColor.a;
			GraphyManager graphyManager6 = m_graphyManager;
			G_GraphShader shaderGraphHighestValues5 = m_shaderGraphHighestValues;
			shaderGraphHighestValues5.CriticalColor.r = graphyManager6.m_audioGraphColor.r;
			shaderGraphHighestValues5.CriticalColor.g = graphyManager6.m_audioGraphColor.g;
			shaderGraphHighestValues5.CriticalColor.a = graphyManager6.m_audioGraphColor.a;
			m_shaderGraphHighestValues.UpdateColors();
			G_GraphShader shaderGraph5 = m_shaderGraph;
			shaderGraph5.GoodThreshold = 0f;
			G_GraphShader shaderGraph6 = m_shaderGraph;
			shaderGraph6.CautionThreshold = 0f;
			m_shaderGraph.UpdateThresholds();
			G_GraphShader shaderGraphHighestValues6 = m_shaderGraphHighestValues;
			shaderGraphHighestValues6.GoodThreshold = 0f;
			G_GraphShader shaderGraphHighestValues7 = m_shaderGraphHighestValues;
			shaderGraphHighestValues7.CautionThreshold = 0f;
			m_shaderGraphHighestValues.UpdateThresholds();
			m_shaderGraph.UpdateArray();
			m_shaderGraphHighestValues.UpdateArray();
			G_GraphShader shaderGraph7 = m_shaderGraph;
			shaderGraph7.Average = 0f;
			m_shaderGraph.UpdateAverage();
			G_GraphShader shaderGraphHighestValues8 = m_shaderGraphHighestValues;
			shaderGraphHighestValues8.Average = 0f;
			m_shaderGraphHighestValues.UpdateAverage();
		}

		[Token(Token = "0x60001B8")]
		[Address(RVA = "0xB0C874", Offset = "0xB0C874", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1F0E5A8]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20224FD]) = v40;\nL_0016:\n\tv43 = UnityEngine.Component::get_transform(this);\n\tv46 = UnityEngine.Transform::get_root(v43);\n\tv73 = UnityEngine.Component::GetComponentInChildren(v46);\n\tthis.m_graphyManager = v73;\n\tv76 = UnityEngine.Component::GetComponent(this);\n\tthis.m_audioMonitor = v76;\n\tv57 = new Tayx.Graphy.G_GraphShader();\n\tTayx.Graphy.G_GraphShader::.ctor(v57);\n\tv57.Image = this.m_imageGraph;\n\tthis.m_shaderGraph = v57;\n\tv58 = new Tayx.Graphy.G_GraphShader();\n\tTayx.Graphy.G_GraphShader::.ctor(v58);\n\tv58.Image = this.m_imageGraphHighestValues;\n\tthis.m_shaderGraphHighestValues = v58;\n\tTayx.Graphy.Audio.G_AudioGraph::UpdateParameters(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Init()
		{
			Transform transform = base.transform;
			Transform root = transform.root;
			GraphyManager componentInChildren = root.GetComponentInChildren<GraphyManager>();
			m_graphyManager = componentInChildren;
			G_AudioMonitor component = GetComponent<G_AudioMonitor>();
			m_audioMonitor = component;
			G_GraphShader g_GraphShader = new G_GraphShader();
			g_GraphShader.Image = m_imageGraph;
			m_shaderGraph = g_GraphShader;
			G_GraphShader g_GraphShader2 = new G_GraphShader();
			g_GraphShader2.Image = m_imageGraphHighestValues;
			m_shaderGraphHighestValues = g_GraphShader2;
			UpdateParameters();
		}

		[Token(Token = "0x60001B9")]
		[Address(RVA = "0xB0D848", Offset = "0xB0D848", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_resolution = 0x28;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_AudioGraph()
		{
			m_resolution = 40;
		}
	}
}
