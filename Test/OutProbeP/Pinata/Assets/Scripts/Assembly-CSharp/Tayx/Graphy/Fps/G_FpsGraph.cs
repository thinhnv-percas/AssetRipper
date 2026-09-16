using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Tayx.Graphy.Graph;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Fps
{
	[Token(Token = "0x200003A")]
	public class G_FpsGraph : G_Graph
	{
		[SerializeField]
		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x18")]
		private Image m_imageGraph;

		[SerializeField]
		[Token(Token = "0x400017C")]
		[FieldOffset(Offset = "0x20")]
		private Shader ShaderFull;

		[SerializeField]
		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x28")]
		private Shader ShaderLight;

		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x30")]
		private GraphyManager m_graphyManager;

		[Token(Token = "0x400017F")]
		[FieldOffset(Offset = "0x38")]
		private G_FpsMonitor m_fpsMonitor;

		[Token(Token = "0x4000180")]
		[FieldOffset(Offset = "0x40")]
		private int m_resolution;

		[Token(Token = "0x4000181")]
		[FieldOffset(Offset = "0x48")]
		private G_GraphShader m_shaderGraph;

		[Token(Token = "0x4000182")]
		[FieldOffset(Offset = "0x50")]
		private int[] m_fpsArray;

		[Token(Token = "0x4000183")]
		[FieldOffset(Offset = "0x58")]
		private int m_highestFps;

		[Token(Token = "0x6000191")]
		[Address(RVA = "0xB12A2C", Offset = "0xB12A2C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Fps.G_FpsGraph::Init(this);\n\treturn;\n")]
		private void OnEnable()
		{
			Init();
		}

		[Token(Token = "0x6000192")]
		[Address(RVA = "0xB12AF0", Offset = "0xB12AF0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv2 = this->klass->vtable[4];\n\tv3 = this->klass->vtable[4];\n\t// 3 IndirectJump v2 @ X2_v1, this @ X0 (Tayx.Graphy.Fps.G_FpsGraph), this @ X0 (Tayx.Graphy.Fps.G_FpsGraph), v3 @ X1_v1, v2 @ X2_v1, v4 @ X3, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn;\n")]
		private void Update()
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Tayx.Graphy.Fps.G_FpsGraph>)+170]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Tayx.Graphy.Fps.G_FpsGraph>)+178]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000193")]
		[Address(RVA = "0xB12AFC", Offset = "0xB12AFC", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F08198]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022530]) = v44;\nL_0016:\n\tv45 = this.m_graphyManager;\n\tv48 = v45.m_graphyMode == 0;\n\tif (v48) goto L_0035;\n\tv73 = v45.m_graphyMode != 1;\n\tif (v73) goto L_0051;\n\tv71 = this + 0x48;\n\tv128 = this.m_shaderGraph;\n\tv128.ArrayMaxSize = 0x80;\n\tv129 = this.m_shaderGraph;\n\tv135 = v129.Image;\n\tv59 = this.ShaderLight;\n\tgoto L_0043;\nL_0035:\n\tv71 = this + 0x48;\n\tv130 = this.m_shaderGraph;\n\tv130.ArrayMaxSize = 0x200;\n\tv131 = this.m_shaderGraph;\n\tv135 = v131.Image;\n\tv59 = this.ShaderFull;\nL_0043:\n\tv118 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v118, v59);\n\tv168 = UnityEngine.UI.Image::set_material(v135, v118);\n\tgoto L_0055;\nL_0051:\n\tv71 = this + 0x48;\nL_0055:\n\tTayx.Graphy.G_GraphShader::InitializeShader(*([v71 @ X23_v3]));\n\tv133 = this.m_graphyManager;\n\tv184 = this->klass;\n\tthis.m_resolution = v133.m_fpsGraphResolution;\n\tv178 = this->klass->vtable[5];\n\tv180 = this->klass->vtable[5];\n\t// 103 IndirectJump v178 @ X2_v4, this @ X0 (Tayx.Graphy.Fps.G_FpsGraph), this @ X0 (Tayx.Graphy.Fps.G_FpsGraph), v180 @ X1_v4, v178 @ X2_v4, v29 @ X3, v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateParameters()
		{
			//IL_00ac: Expected O, but got I
			//IL_0112: Expected O, but got I
			//IL_0058: Expected O, but got I
			//IL_0134: Expected I, but got O
			//IL_0153: Expected O, but got I
			//IL_0163: Expected O, but got I
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
						obj = (long)(IntPtr)this + 72L;
						goto IL_0117;
					}
					obj = (long)(IntPtr)this + 72L;
					G_GraphShader shaderGraph = m_shaderGraph;
					shaderGraph.ArrayMaxSize = 128;
					G_GraphShader shaderGraph2 = m_shaderGraph;
					image = shaderGraph2.Image;
					shader = ShaderLight;
				}
				else
				{
					obj = (long)(IntPtr)this + 72L;
					G_GraphShader shaderGraph3 = m_shaderGraph;
					shaderGraph3.ArrayMaxSize = 512;
					G_GraphShader shaderGraph4 = m_shaderGraph;
					image = shaderGraph4.Image;
					shader = ShaderFull;
				}
				Material material = new Material(shader);
				image.material = material;
				goto IL_0117;
				IL_0117:
				((G_GraphShader)obj).InitializeShader();
				GraphyManager graphyManager2 = m_graphyManager;
				IntPtr intPtr = (IntPtr)this;
				m_resolution = graphyManager2.FpsGraphResolution;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X9_v4 (Il2CppClass<Tayx.Graphy.Fps.G_FpsGraph>)+180]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X9_v4 (Il2CppClass<Tayx.Graphy.Fps.G_FpsGraph>)+188]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v178 @ X2_v4 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000194")]
		[Address(RVA = "0xB12C24", Offset = "0xB12C24", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Time::get_unscaledDeltaTime();\n\tv75 = this.m_resolution;\n\tv106 = this.m_resolution - 1;\n\tv15 = v106 & 0x80000000;\n\tv16 = v15 == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_0089;\n\tv104 = this.m_fpsArray;\n\tv20 = 1f / v11;\nL_001D:\n\tv118 = v103 >= v106;\n\tif (v118) goto L_003E;\n\tv267 = v103 + 1;\n\tv268 = v267 < v104.Length;\n\tv269 = ~v268;\n\tif (v269) goto L_0116;\n\tv344 = v103 < v104.Length;\n\tv345 = ~v344;\n\tif (v345) goto L_0116;\n\tgoto L_004B;\nL_003E:\n\tv278 = v103 < v104.Length;\n\tv279 = ~v278;\n\tif (v279) goto L_0116;\nL_004B:\n\tv104[v103 @ X9_v17 (System.Int32)] = v253;\n\tv104 = this.m_fpsArray;\n\tv399 = v103 < v104.Length;\n\tv373 = ~v399;\n\tif (v373) goto L_0116;\n\tv75 = this.m_resolution;\n\tv62 = v103 + 1;\n\tv106 = this.m_resolution - 1;\n\tv405 = v74 - v104[v103 @ X9_v17 (System.Int32)];\n\tv406 = v405 < 0;\n\tv408 = v74 ^ v104[v103 @ X9_v17 (System.Int32)];\n\tv409 = v74 ^ v405;\n\tv410 = v408 & v409;\n\tv411 = v410 < 0;\n\tv412 = v406 == v411;\n\tv413 = ~v412;\n\tv24 = ~v413;\n\tif (v24) goto L_007D;\n\tgoto L_007D;\nL_007D:\n\tv27 = v62 <= v106;\n\tif (v27) goto L_001D;\nL_0089:\n\tv88 = this.m_highestFps - 1;\n\tv90 = this.m_highestFps < 1;\n\tif (v90) goto L_009F;\n\tv121 = this.m_highestFps - v144;\n\tv122 = v121 < 0;\n\tv123 = v121 == 0;\n\tv124 = this.m_highestFps ^ v144;\n\tv125 = this.m_highestFps ^ v121;\n\tv126 = v124 & v125;\n\tv127 = v126 < 0;\n\tv128 = v122 == v127;\n\tv129 = ~v123;\n\tv130 = v128 & v129;\n\tv131 = ~v130;\n\tif (v131) goto L_009F;\n\tgoto L_009F;\nL_009F:\n\tv263 = this.m_shaderGraph;\n\tthis.m_highestFps = v144;\n\tv151 = v75 - 1;\n\tv152 = v151 & 0x80000000;\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_00E3;\nL_00A9:\n\tv219 = this.m_fpsArray;\n\tv400 = v248 < v219.Length;\n\tv211 = ~v400;\n\tif (v211) goto L_0116;\n\tv216 = v261.Array;\n\tv449 = v248 < v216.Length;\n\tv212 = ~v449;\n\tif (v212) goto L_0116;\n\tv256 = v219[v248 @ X8_v13 (System.Int32)] / this.m_highestFps;\n\tv216[v248 @ X8_v13 (System.Int32)] = v256;\n\tv263 = this.m_shaderGraph;\n\tv248 = v248 + 1;\n\tv298 = this.m_resolution - 1;\n\tv289 = v248 <= v298;\n\tif (v289) goto L_00A9;\nL_00E3:\n\tTayx.Graphy.G_GraphShader::UpdatePoints(v263);\n\tv249 = this.m_fpsMonitor;\n\tv222 = this.m_shaderGraph;\n\tv258 = v249.m_avgFps / this.m_highestFps;\n\tv222.Average = v258;\n\tTayx.Graphy.G_GraphShader::UpdateAverage(this.m_shaderGraph);\n\tv223 = this.m_graphyManager;\n\tv250 = this.m_shaderGraph;\n\tv259 = v223.m_goodFpsThreshold / this.m_highestFps;\n\tv250.GoodThreshold = v259;\n\tv224 = this.m_graphyManager;\n\tv251 = this.m_shaderGraph;\n\tv328 = v224.m_cautionFpsThreshold / this.m_highestFps;\n\tv251.CautionThreshold = v328;\n\tTayx.Graphy.G_GraphShader::UpdateThresholds(this.m_shaderGraph);\n\treturn;\n\tv331 = new System.NullReferenceException();\nL_0116:\n\tv387 = new System.IndexOutOfRangeException();\n\tthrow v387;\n\treturn;\n// 182 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void UpdateGraph()
		{
			//IL_0035: Expected I4, but got I8
			//IL_035d: Expected I4, but got I8
			//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bc: Expected I4, but got Unknown
			//IL_014f: Expected I4, but got F4
			//IL_0108: Expected F4, but got I4
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			int resolution = m_resolution;
			int num = m_resolution - 1;
			int num2 = (int)(num & 0x80000000L);
			bool flag = num2 == 0;
			bool flag2 = !flag;
			int num3 = 0;
			if (flag2)
			{
				goto IL_025b;
			}
			int[] fpsArray = m_fpsArray;
			float num4 = 1f / unscaledDeltaTime;
			int num5 = 0;
			int num6 = 0;
			while (true)
			{
				float num8;
				if (num5 < num)
				{
					int num7 = num5 + 1;
					if (num7 >= fpsArray.Length || num5 >= fpsArray.Length)
					{
						break;
					}
					num8 = fpsArray[num7];
				}
				else
				{
					bool flag3 = num5 < fpsArray.Length;
					bool flag4 = !flag3;
					num8 = num4;
					if (flag4)
					{
						break;
					}
				}
				fpsArray[num5] = (int)num8;
				fpsArray = m_fpsArray;
				if (num5 >= fpsArray.Length)
				{
					break;
				}
				resolution = m_resolution;
				int num9 = num5 + 1;
				num = m_resolution - 1;
				int num10 = num6 - fpsArray[num5];
				bool flag5 = num10 < 0;
				int num11 = num6 ^ fpsArray[num5];
				int num12 = num6 ^ num10;
				int num13 = num11 & num12;
				bool flag6 = num13 < 0;
				if (flag5 != flag6)
				{
					num6 = fpsArray[num5];
				}
				bool flag7 = num9 <= num;
				num3 = num6;
				num5 = num9;
				if (flag7)
				{
					continue;
				}
				goto IL_025b;
			}
			goto IL_056b;
			IL_056b:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_0481:
			G_GraphShader shaderGraph;
			shaderGraph.UpdatePoints();
			G_FpsMonitor fpsMonitor = m_fpsMonitor;
			G_GraphShader shaderGraph2 = m_shaderGraph;
			int num14 = (int)(fpsMonitor.AverageFPS / m_highestFps);
			shaderGraph2.Average = num14;
			m_shaderGraph.UpdateAverage();
			GraphyManager graphyManager = m_graphyManager;
			G_GraphShader shaderGraph3 = m_shaderGraph;
			int num15 = graphyManager.GoodFPSThreshold / m_highestFps;
			shaderGraph3.GoodThreshold = num15;
			GraphyManager graphyManager2 = m_graphyManager;
			G_GraphShader shaderGraph4 = m_shaderGraph;
			int num16 = graphyManager2.CautionFPSThreshold / m_highestFps;
			shaderGraph4.CautionThreshold = num16;
			m_shaderGraph.UpdateThresholds();
			return;
			IL_025b:
			int num17 = m_highestFps - 1;
			if (m_highestFps >= 1)
			{
				int num18 = m_highestFps - num3;
				bool flag8 = num18 < 0;
				bool flag9 = num18 == 0;
				int num19 = m_highestFps ^ num3;
				int num20 = m_highestFps ^ num18;
				int num21 = num19 & num20;
				bool flag10 = num21 < 0;
				bool flag11 = flag8 == flag10;
				bool flag12 = !flag9;
				if (flag11 && flag12)
				{
					num3 = num17;
				}
			}
			shaderGraph = m_shaderGraph;
			m_highestFps = num3;
			int num22 = resolution - 1;
			if ((int)(num22 & 0x80000000L) != 0)
			{
				goto IL_0481;
			}
			int num23 = 0;
			G_GraphShader shaderGraph5 = m_shaderGraph;
			while (true)
			{
				int[] fpsArray2 = m_fpsArray;
				if (num23 >= fpsArray2.Length)
				{
					break;
				}
				float[] array = shaderGraph5.Array;
				if (num23 >= array.Length)
				{
					break;
				}
				int num24 = fpsArray2[num23] / m_highestFps;
				array[num23] = num24;
				shaderGraph = m_shaderGraph;
				num23++;
				int num25 = m_resolution - 1;
				bool flag13 = num23 <= num25;
				shaderGraph5 = m_shaderGraph;
				if (flag13)
				{
					continue;
				}
				goto IL_0481;
			}
			goto IL_056b;
		}

		[Token(Token = "0x6000195")]
		[Address(RVA = "0xB12E2C", Offset = "0xB12E2C", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EA8C50]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022531]) = v38;\nL_0014:\n\tv40 = this.m_shaderGraph;\n\t// 24 NewArr v44 @ X0_v3 (System.Single[]), typeof(System.Single[]), this.m_resolution (System.Int32)\n\tv40.Array = v44;\n\t// 32 NewArr v50 @ X0_v13 (System.Int32[]), typeof(System.Int32[]), this.m_resolution (System.Int32)\n\tv122 = this.m_shaderGraph;\n\tthis.m_fpsArray = v50;\n\tv139 = this.m_resolution < 1;\n\tif (v139) goto L_0053;\nL_0033:\n\tv121 = v120.Array;\n\tv213 = v103 < v121.Length;\n\tv160 = ~v213;\n\tif (v160) goto L_0086;\n\tv121[v103 @ X9_v11 (System.Int32)] = 0;\n\tv122 = this.m_shaderGraph;\n\tv103 = v103 + 1;\n\tv170 = v103 < this.m_resolution;\n\tif (v170) goto L_0033;\nL_0053:\n\tv104 = this.m_graphyManager;\n\tv122.GoodColor.r = v104.m_goodFpsColor;\n\tv122.GoodColor.g = v104.m_goodFpsColor.g;\n\tv122.GoodColor.a = v104.m_goodFpsColor.a;\n\tv123 = this.m_graphyManager;\n\tv106 = this.m_shaderGraph;\n\tv106.CautionColor.r = v123.m_cautionFpsColor;\n\tv106.CautionColor.g = v123.m_cautionFpsColor.g;\n\tv106.CautionColor.a = v123.m_cautionFpsColor.a;\n\tv124 = this.m_graphyManager;\n\tv107 = this.m_shaderGraph;\n\tv107.CriticalColor.r = v124.m_criticalFpsColor;\n\tv107.CriticalColor.g = v124.m_criticalFpsColor.g;\n\tv107.CriticalColor.a = v124.m_criticalFpsColor.a;\n\tTayx.Graphy.G_GraphShader::UpdateColors(this.m_shaderGraph);\n\tTayx.Graphy.G_GraphShader::UpdateArray(this.m_shaderGraph);\n\treturn;\n\tv126 = new System.NullReferenceException();\nL_0086:\n\tv166 = new System.IndexOutOfRangeException();\n\tthrow v166;\n\tthrow System.NullReferenceException;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void CreatePoints()
		{
			G_GraphShader shaderGraph = m_shaderGraph;
			float[] array = new float[m_resolution];
			shaderGraph.Array = array;
			int[] fpsArray = new int[m_resolution];
			G_GraphShader shaderGraph2 = m_shaderGraph;
			m_fpsArray = fpsArray;
			if (m_resolution >= 1)
			{
				int num = 0;
				G_GraphShader g_GraphShader = shaderGraph2;
				bool flag;
				do
				{
					float[] array2 = g_GraphShader.Array;
					if (num < array2.Length)
					{
						array2[num] = 0f;
						shaderGraph2 = m_shaderGraph;
						num++;
						flag = num < m_resolution;
						g_GraphShader = m_shaderGraph;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (flag);
			}
			GraphyManager graphyManager = m_graphyManager;
			shaderGraph2.GoodColor.r = graphyManager.m_goodFpsColor.r;
			shaderGraph2.GoodColor.g = graphyManager.m_goodFpsColor.g;
			shaderGraph2.GoodColor.a = graphyManager.m_goodFpsColor.a;
			GraphyManager graphyManager2 = m_graphyManager;
			G_GraphShader shaderGraph3 = m_shaderGraph;
			shaderGraph3.CautionColor.r = graphyManager2.m_cautionFpsColor.r;
			shaderGraph3.CautionColor.g = graphyManager2.m_cautionFpsColor.g;
			shaderGraph3.CautionColor.a = graphyManager2.m_cautionFpsColor.a;
			GraphyManager graphyManager3 = m_graphyManager;
			G_GraphShader shaderGraph4 = m_shaderGraph;
			shaderGraph4.CriticalColor.r = graphyManager3.m_criticalFpsColor.r;
			shaderGraph4.CriticalColor.g = graphyManager3.m_criticalFpsColor.g;
			shaderGraph4.CriticalColor.a = graphyManager3.m_criticalFpsColor.a;
			m_shaderGraph.UpdateColors();
			m_shaderGraph.UpdateArray();
		}

		[Token(Token = "0x6000196")]
		[Address(RVA = "0xB12A30", Offset = "0xB12A30", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EAB2F8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022532]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_transform(this);\n\tv44 = UnityEngine.Transform::get_root(v41);\n\tv65 = UnityEngine.Component::GetComponentInChildren(v44);\n\tthis.m_graphyManager = v65;\n\tv69 = UnityEngine.Component::GetComponent(this);\n\tthis.m_fpsMonitor = v69;\n\tv53 = new Tayx.Graphy.G_GraphShader();\n\tTayx.Graphy.G_GraphShader::.ctor(v53);\n\tv53.Image = this.m_imageGraph;\n\tthis.m_shaderGraph = v53;\n\tTayx.Graphy.Fps.G_FpsGraph::UpdateParameters(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Init()
		{
			Transform transform = base.transform;
			Transform root = transform.root;
			GraphyManager componentInChildren = root.GetComponentInChildren<GraphyManager>();
			m_graphyManager = componentInChildren;
			G_FpsMonitor component = GetComponent<G_FpsMonitor>();
			m_fpsMonitor = component;
			G_GraphShader g_GraphShader = new G_GraphShader();
			g_GraphShader.Image = m_imageGraph;
			m_shaderGraph = g_GraphShader;
			UpdateParameters();
		}

		[Token(Token = "0x6000197")]
		[Address(RVA = "0xB12F90", Offset = "0xB12F90", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_resolution = 0x96;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_FpsGraph()
		{
			m_resolution = 150;
		}
	}
}
