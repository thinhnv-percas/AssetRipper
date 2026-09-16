using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Tayx.Graphy.Graph;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Ram
{
	[Token(Token = "0x2000035")]
	public class G_RamGraph : G_Graph
	{
		[SerializeField]
		[Token(Token = "0x4000158")]
		[FieldOffset(Offset = "0x18")]
		private Image m_imageAllocated;

		[SerializeField]
		[Token(Token = "0x4000159")]
		[FieldOffset(Offset = "0x20")]
		private Image m_imageReserved;

		[SerializeField]
		[Token(Token = "0x400015A")]
		[FieldOffset(Offset = "0x28")]
		private Image m_imageMono;

		[SerializeField]
		[Token(Token = "0x400015B")]
		[FieldOffset(Offset = "0x30")]
		private Shader ShaderFull;

		[SerializeField]
		[Token(Token = "0x400015C")]
		[FieldOffset(Offset = "0x38")]
		private Shader ShaderLight;

		[Token(Token = "0x400015D")]
		[FieldOffset(Offset = "0x40")]
		private GraphyManager m_graphyManager;

		[Token(Token = "0x400015E")]
		[FieldOffset(Offset = "0x48")]
		private G_RamMonitor m_ramMonitor;

		[Token(Token = "0x400015F")]
		[FieldOffset(Offset = "0x50")]
		private int m_resolution;

		[Token(Token = "0x4000160")]
		[FieldOffset(Offset = "0x58")]
		private G_GraphShader m_shaderGraphAllocated;

		[Token(Token = "0x4000161")]
		[FieldOffset(Offset = "0x60")]
		private G_GraphShader m_shaderGraphReserved;

		[Token(Token = "0x4000162")]
		[FieldOffset(Offset = "0x68")]
		private G_GraphShader m_shaderGraphMono;

		[Token(Token = "0x4000163")]
		[FieldOffset(Offset = "0x70")]
		private float[] m_allocatedArray;

		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0x78")]
		private float[] m_reservedArray;

		[Token(Token = "0x4000165")]
		[FieldOffset(Offset = "0x80")]
		private float[] m_monoArray;

		[Token(Token = "0x4000166")]
		[FieldOffset(Offset = "0x88")]
		private float m_highestMemory;

		[Token(Token = "0x6000173")]
		[Address(RVA = "0xB16E70", Offset = "0xB16E70", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Ram.G_RamGraph::Init(this);\n\treturn;\n")]
		private void OnEnable()
		{
			Init();
		}

		[Token(Token = "0x6000174")]
		[Address(RVA = "0xB16F88", Offset = "0xB16F88", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv2 = this->klass->vtable[4];\n\tv3 = this->klass->vtable[4];\n\t// 3 IndirectJump v2 @ X2_v1, this @ X0 (Tayx.Graphy.Ram.G_RamGraph), this @ X0 (Tayx.Graphy.Ram.G_RamGraph), v3 @ X1_v1, v2 @ X2_v1, v4 @ X3, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn;\n")]
		private void Update()
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Tayx.Graphy.Ram.G_RamGraph>)+170]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Tayx.Graphy.Ram.G_RamGraph>)+178]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000175")]
		[Address(RVA = "0xB16F94", Offset = "0xB16F94", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F02558]);\n\tv25 = *([v24 @ X8_v33]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022554]) = v44;\nL_0017:\n\tv46 = this.m_shaderGraphAllocated == 0;\n\tif (v46) goto L_0021;\n\tv48 = this.m_shaderGraphReserved == 0;\n\tif (v48) goto L_0021;\n\tv54 = this.m_shaderGraphMono == 0;\n\tv50 = ~v54;\n\tif (v50) goto L_0022;\nL_0021:\n\tTayx.Graphy.Ram.G_RamGraph::Init(this);\nL_0022:\n\tv58 = this.m_graphyManager;\n\tv65 = v58.m_graphyMode == 1;\n\tif (v65) goto L_006F;\n\tv192 = v58.m_graphyMode == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_00BB;\n\tv113 = this.m_shaderGraphAllocated;\n\tv113.ArrayMaxSize = 0x200;\n\tv114 = this.m_shaderGraphReserved;\n\tv114.ArrayMaxSize = 0x200;\n\tv173 = this.m_shaderGraphMono;\n\tv173.ArrayMaxSize = 0x200;\n\tv174 = this.m_shaderGraphAllocated;\n\tv142 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v142, this.ShaderFull);\n\tv143 = UnityEngine.UI.Image::set_material(v174.Image, v142);\n\tv175 = this.m_shaderGraphReserved;\n\tv144 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v144, this.ShaderFull);\n\tv145 = UnityEngine.UI.Image::set_material(v175.Image, v144);\n\tv176 = this.m_shaderGraphMono;\n\tv189 = v176.Image;\n\tv104 = this.ShaderFull;\n\tgoto L_00AB;\nL_006F:\n\tv118 = this.m_shaderGraphAllocated;\n\tv118.ArrayMaxSize = 0x80;\n\tv119 = this.m_shaderGraphReserved;\n\tv119.ArrayMaxSize = 0x80;\n\tv178 = this.m_shaderGraphMono;\n\tv178.ArrayMaxSize = 0x80;\n\tv179 = this.m_shaderGraphAllocated;\n\tv146 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v146, this.ShaderLight);\n\tv147 = UnityEngine.UI.Image::set_material(v179.Image, v146);\n\tv180 = this.m_shaderGraphReserved;\n\tv148 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v148, this.ShaderLight);\n\tv149 = UnityEngine.UI.Image::set_material(v180.Image, v148);\n\tv181 = this.m_shaderGraphMono;\n\tv189 = v181.Image;\n\tv104 = this.ShaderLight;\nL_00AB:\n\tv150 = new *([v109 @ X23_v3 (Il2CppClass<UnityEngine.Material>)])();\n\tUnityEngine.Material::.ctor(v150, v104);\n\tv223 = UnityEngine.UI.Image::set_material(v189, v150);\nL_00BB:\n\tTayx.Graphy.G_GraphShader::InitializeShader(this.m_shaderGraphAllocated);\n\tTayx.Graphy.G_GraphShader::InitializeShader(this.m_shaderGraphReserved);\n\tTayx.Graphy.G_GraphShader::InitializeShader(this.m_shaderGraphMono);\n\tv183 = this.m_graphyManager;\n\tv239 = this->klass;\n\tthis.m_resolution = v183.m_ramGraphResolution;\n\tv231 = this->klass->vtable[5];\n\tv233 = this->klass->vtable[5];\n\t// 213 IndirectJump v231 @ X2_v7, this @ X0 (Tayx.Graphy.Ram.G_RamGraph), this @ X0 (Tayx.Graphy.Ram.G_RamGraph), v233 @ X1_v7, v231 @ X2_v7, v29 @ X3, v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 148 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateParameters()
		{
			//IL_0300: Expected I, but got O
			//IL_031f: Expected O, but got I
			//IL_032f: Expected O, but got I
			//IL_02aa: Expected I, but got O
			//IL_01ae: Expected I, but got O
			while (true)
			{
				if (m_shaderGraphAllocated == null || m_shaderGraphReserved == null || m_shaderGraphMono == null)
				{
					Init();
				}
				GraphyManager graphyManager = m_graphyManager;
				Image image;
				Shader shader;
				if (graphyManager.GraphyMode != GraphyManager.Mode.LIGHT)
				{
					if (graphyManager.GraphyMode != GraphyManager.Mode.FULL)
					{
						goto IL_02c1;
					}
					G_GraphShader shaderGraphAllocated = m_shaderGraphAllocated;
					shaderGraphAllocated.ArrayMaxSize = 512;
					G_GraphShader shaderGraphReserved = m_shaderGraphReserved;
					shaderGraphReserved.ArrayMaxSize = 512;
					G_GraphShader shaderGraphMono = m_shaderGraphMono;
					shaderGraphMono.ArrayMaxSize = 512;
					G_GraphShader shaderGraphAllocated2 = m_shaderGraphAllocated;
					Material material = new Material(ShaderFull);
					shaderGraphAllocated2.Image.material = material;
					G_GraphShader shaderGraphReserved2 = m_shaderGraphReserved;
					Material material2 = new Material(ShaderFull);
					shaderGraphReserved2.Image.material = material2;
					G_GraphShader shaderGraphMono2 = m_shaderGraphMono;
					image = shaderGraphMono2.Image;
					shader = ShaderFull;
					IntPtr intPtr = (IntPtr)typeof(Material);
				}
				else
				{
					G_GraphShader shaderGraphAllocated3 = m_shaderGraphAllocated;
					shaderGraphAllocated3.ArrayMaxSize = 128;
					G_GraphShader shaderGraphReserved3 = m_shaderGraphReserved;
					shaderGraphReserved3.ArrayMaxSize = 128;
					G_GraphShader shaderGraphMono3 = m_shaderGraphMono;
					shaderGraphMono3.ArrayMaxSize = 128;
					G_GraphShader shaderGraphAllocated4 = m_shaderGraphAllocated;
					Material material3 = new Material(ShaderLight);
					shaderGraphAllocated4.Image.material = material3;
					G_GraphShader shaderGraphReserved4 = m_shaderGraphReserved;
					Material material4 = new Material(ShaderLight);
					shaderGraphReserved4.Image.material = material4;
					G_GraphShader shaderGraphMono4 = m_shaderGraphMono;
					image = shaderGraphMono4.Image;
					shader = ShaderLight;
					IntPtr intPtr = (IntPtr)typeof(Material);
				}
				Material material5 = new Material(shader);
				image.material = material5;
				goto IL_02c1;
				IL_02c1:
				m_shaderGraphAllocated.InitializeShader();
				m_shaderGraphReserved.InitializeShader();
				m_shaderGraphMono.InitializeShader();
				GraphyManager graphyManager2 = m_graphyManager;
				IntPtr intPtr2 = (IntPtr)this;
				m_resolution = graphyManager2.RamGraphResolution;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ X9_v6 (Il2CppClass<Tayx.Graphy.Ram.G_RamGraph>)+180]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ X9_v6 (Il2CppClass<Tayx.Graphy.Ram.G_RamGraph>)+188]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v231 @ X2_v7 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000176")]
		[Address(RVA = "0xB17234", Offset = "0xB17234", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.m_ramMonitor;\n\tv229 = this.m_resolution;\n\tthis.m_highestMemory = 0f;\n\tv203 = this.m_resolution - 1;\n\tv17 = v203 & 0x80000000;\n\tv18 = v17 == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_00D8;\nL_0014:\n\tv55 = this.m_allocatedArray;\n\tv26 = v256 >= v203;\n\tif (v26) goto L_0078;\n\tv369 = v256 + 1;\n\tv453 = v369 < v55.Length;\n\tv355 = ~v453;\n\tif (v355) goto L_0177;\n\tv457 = v256 < v55.Length;\n\tv188 = ~v457;\n\tif (v188) goto L_0177;\n\tv55[v256 @ X10_v17 (System.Int32)] = v55[v369 @ X11_v22 (System.Int32)];\n\tv204 = this.m_reservedArray;\n\tv492 = v369 < v204.Length;\n\tv356 = ~v492;\n\tif (v356) goto L_0177;\n\tv495 = v256 < v204.Length;\n\tv189 = ~v495;\n\tif (v189) goto L_0177;\n\tv204[v256 @ X10_v17 (System.Int32)] = v204[v369 @ X11_v22 (System.Int32)];\n\tv205 = this.m_monoArray;\n\tv505 = v369 < v205.Length;\n\tv357 = ~v505;\n\tif (v357) goto L_0177;\n\tv513 = v256 < v205.Length;\n\tv358 = ~v513;\n\tif (v358) goto L_0177;\n\tv508 = v205 + 0x20;\n\tv506 = v256 << 2;\n\tv509 = v508 + v506;\n\tgoto L_00A9;\nL_0078:\n\tv454 = v256 < v55.Length;\n\tv190 = ~v454;\n\tif (v190) goto L_0177;\n\tv55[v256 @ X10_v17 (System.Int32)] = v10.m_allocatedRam;\n\tv57 = this.m_reservedArray;\n\tv491 = v256 < v57.Length;\n\tv191 = ~v491;\n\tif (v191) goto L_0177;\n\tv57[v256 @ X10_v17 (System.Int32)] = v10.m_reservedRam;\n\tv58 = this.m_monoArray;\n\tv496 = v256 < v58.Length;\n\tv359 = ~v496;\n\tif (v359) goto L_0177;\n\tv501 = v256 << 2;\n\tv502 = v58 + v501;\n\tv509 = v502 + 0x20;\nL_00A9:\n\t*([v509 @ X11_v14]) = v52;\n\tv236 = this.m_reservedArray;\n\tv514 = v256 < v236.Length;\n\tv360 = ~v514;\n\tif (v360) goto L_0177;\n\tv525 = this.m_highestMemory >= v236[v256 @ X10_v17 (System.Int32)];\n\tif (v525) goto L_00C8;\n\tthis.m_highestMemory = v236[v256 @ X10_v17 (System.Int32)];\nL_00C8:\n\tv229 = this.m_resolution;\n\tv256 = v256 + 1;\n\tv203 = this.m_resolution - 1;\n\tv279 = v256 <= v203;\n\tif (v279) goto L_0014;\nL_00D8:\n\tv394 = this.m_shaderGraphAllocated;\n\tv386 = v229 - 1;\n\tv387 = v386 & 0x80000000;\n\tv388 = v387 == 0;\n\tv389 = ~v388;\n\tif (v389) goto L_0167;\nL_00E1:\n\tv258 = this.m_allocatedArray;\n\tv459 = v223 < v258.Length;\n\tv194 = ~v459;\n\tif (v194) goto L_0177;\n\tv231 = v22.Array;\n\tv494 = v223 < v231.Length;\n\tv195 = ~v494;\n\tif (v195) goto L_0177;\n\tv212 = v258[v223 @ X8_v8 (System.Int32)] / this.m_highestMemory;\n\tv231[v223 @ X8_v8 (System.Int32)] = v212;\n\tv232 = this.m_shaderGraphReserved;\n\tv260 = this.m_reservedArray;\n\tv512 = v223 < v260.Length;\n\tv196 = ~v512;\n\tif (v196) goto L_0177;\n\tv233 = v232.Array;\n\tv526 = v223 < v233.Length;\n\tv197 = ~v526;\n\tif (v197) goto L_0177;\n\tv213 = v260[v223 @ X8_v8 (System.Int32)] / this.m_highestMemory;\n\tv233[v223 @ X8_v8 (System.Int32)] = v213;\n\tv234 = this.m_shaderGraphMono;\n\tv262 = this.m_monoArray;\n\tv533 = v223 < v262.Length;\n\tv198 = ~v533;\n\tif (v198) goto L_0177;\n\tv235 = v234.Array;\n\tv534 = v223 < v235.Length;\n\tv199 = ~v534;\n\tif (v199) goto L_0177;\n\tv214 = v262[v223 @ X8_v8 (System.Int32)] / this.m_highestMemory;\n\tv235[v223 @ X8_v8 (System.Int32)] = v214;\n\tv394 = this.m_shaderGraphAllocated;\n\tv223 = v223 + 1;\n\tv418 = this.m_resolution - 1;\n\tv396 = v223 <= v418;\n\tif (v396) goto L_00E1;\nL_0167:\n\tTayx.Graphy.G_GraphShader::UpdatePoints(v394);\n\tTayx.Graphy.G_GraphShader::UpdatePoints(this.m_shaderGraphReserved);\n\tTayx.Graphy.G_GraphShader::UpdatePoints(this.m_shaderGraphMono);\n\treturn;\n\tv265 = new System.NullReferenceException();\nL_0177:\n\tv373 = new System.IndexOutOfRangeException();\n\tthrow v373;\n\tthrow System.NullReferenceException;\n// 263 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void UpdateGraph()
		{
			//IL_0046: Expected I4, but got I8
			//IL_03b1: Expected I4, but got I8
			//IL_02f4: Expected O, but got I
			//IL_0303: Expected O, but got I
			//IL_0670: Expected O, but got F4
			//IL_01e1: Expected O, but got I
			//IL_01fd: Expected O, but got I
			G_RamMonitor ramMonitor = m_ramMonitor;
			int resolution = m_resolution;
			m_highestMemory = 0f;
			int num = m_resolution - 1;
			if ((int)(num & 0x80000000L) != 0)
			{
				goto IL_0382;
			}
			int num2 = 0;
			while (true)
			{
				float[] allocatedArray = m_allocatedArray;
				float num5;
				object obj2;
				if (num2 < num)
				{
					int num3 = num2 + 1;
					if (num3 >= allocatedArray.Length || num2 >= allocatedArray.Length)
					{
						break;
					}
					allocatedArray[num2] = allocatedArray[num3];
					float[] reservedArray = m_reservedArray;
					if (num3 >= reservedArray.Length || num2 >= reservedArray.Length)
					{
						break;
					}
					reservedArray[num2] = reservedArray[num3];
					float[] monoArray = m_monoArray;
					if (num3 >= monoArray.Length || num2 >= monoArray.Length)
					{
						break;
					}
					object obj = (long)(IntPtr)monoArray + 32L;
					int num4 = num2 << 2;
					obj2 = (long)(IntPtr)obj + (long)num4;
					num5 = monoArray[num3];
				}
				else
				{
					if (num2 >= allocatedArray.Length)
					{
						break;
					}
					allocatedArray[num2] = ramMonitor.AllocatedRam;
					float[] reservedArray2 = m_reservedArray;
					if (num2 >= reservedArray2.Length)
					{
						break;
					}
					reservedArray2[num2] = ramMonitor.ReservedRam;
					float[] monoArray2 = m_monoArray;
					if (num2 >= monoArray2.Length)
					{
						break;
					}
					int num6 = num2 << 2;
					object obj3 = (long)(IntPtr)monoArray2 + (long)num6;
					obj2 = (long)(IntPtr)obj3 + 32L;
					num5 = ramMonitor.MonoRam;
				}
				obj2 = num5;
				float[] reservedArray3 = m_reservedArray;
				if (num2 >= reservedArray3.Length)
				{
					break;
				}
				if (m_highestMemory < reservedArray3[num2])
				{
					m_highestMemory = reservedArray3[num2];
				}
				resolution = m_resolution;
				num2++;
				num = m_resolution - 1;
				if (num2 <= num)
				{
					continue;
				}
				goto IL_0382;
			}
			goto IL_065a;
			IL_0382:
			G_GraphShader shaderGraphAllocated = m_shaderGraphAllocated;
			int num7 = resolution - 1;
			if ((int)(num7 & 0x80000000L) != 0)
			{
				goto IL_0630;
			}
			G_GraphShader shaderGraphAllocated2 = m_shaderGraphAllocated;
			int num8 = 0;
			while (true)
			{
				float[] allocatedArray2 = m_allocatedArray;
				if (num8 >= allocatedArray2.Length)
				{
					break;
				}
				float[] array = shaderGraphAllocated2.Array;
				if (num8 >= array.Length)
				{
					break;
				}
				float num9 = allocatedArray2[num8] / m_highestMemory;
				array[num8] = num9;
				G_GraphShader shaderGraphReserved = m_shaderGraphReserved;
				float[] reservedArray4 = m_reservedArray;
				if (num8 >= reservedArray4.Length)
				{
					break;
				}
				float[] array2 = shaderGraphReserved.Array;
				if (num8 >= array2.Length)
				{
					break;
				}
				float num10 = reservedArray4[num8] / m_highestMemory;
				array2[num8] = num10;
				G_GraphShader shaderGraphMono = m_shaderGraphMono;
				float[] monoArray3 = m_monoArray;
				if (num8 >= monoArray3.Length)
				{
					break;
				}
				float[] array3 = shaderGraphMono.Array;
				if (num8 >= array3.Length)
				{
					break;
				}
				float num11 = monoArray3[num8] / m_highestMemory;
				array3[num8] = num11;
				shaderGraphAllocated = m_shaderGraphAllocated;
				num8++;
				int num12 = m_resolution - 1;
				bool flag = num8 <= num12;
				shaderGraphAllocated2 = m_shaderGraphAllocated;
				if (flag)
				{
					continue;
				}
				goto IL_0630;
			}
			goto IL_065a;
			IL_065a:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_0630:
			shaderGraphAllocated.UpdatePoints();
			m_shaderGraphReserved.UpdatePoints();
			m_shaderGraphMono.UpdatePoints();
		}

		[Token(Token = "0x6000177")]
		[Address(RVA = "0xB174D8", Offset = "0xB174D8", Length = "0x3D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EF39E8]);\n\tv21 = *([v20 @ X8_v40]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022555]) = v40;\nL_0015:\n\tv42 = this.m_shaderGraphAllocated;\n\t// 25 NewArr v46 @ X0_v3 (System.Single[]), typeof(System.Single[]), this.m_resolution (System.Int32)\n\tv42.Array = v46;\n\tv50 = this.m_shaderGraphReserved;\n\t// 32 NewArr v51 @ X0_v13 (System.Single[]), typeof(System.Single[]), this.m_resolution (System.Int32)\n\tv50.Array = v51;\n\tv156 = this.m_shaderGraphMono;\n\t// 39 NewArr v161 @ X0_v15 (System.Single[]), typeof(System.Single[]), this.m_resolution (System.Int32)\n\tv156.Array = v161;\n\t// 45 NewArr v303 @ X0_v17 (System.Single[]), typeof(System.Single[]), this.m_resolution (System.Int32)\n\tthis.m_allocatedArray = v303;\n\t// 49 NewArr v306 @ X0_v19 (System.Single[]), typeof(System.Single[]), this.m_resolution (System.Int32)\n\tthis.m_reservedArray = v306;\n\t// 53 NewArr v162 @ X0_v21 (System.Single[]), typeof(System.Single[]), this.m_resolution (System.Int32)\n\tv146 = this.m_shaderGraphAllocated;\n\tthis.m_monoArray = v162;\n\tv348 = this.m_resolution < 1;\n\tif (v348) goto L_0091;\nL_0048:\n\tv75 = v144.Array;\n\tv367 = v206 < v75.Length;\n\tv139 = ~v367;\n\tif (v139) goto L_0159;\n\tv75[v206 @ X8_v36 (System.Int32)] = 0;\n\tv76 = this.m_shaderGraphReserved;\n\tv77 = v76.Array;\n\tv370 = v206 < v77.Length;\n\tv140 = ~v370;\n\tif (v140) goto L_0159;\n\tv77[v206 @ X8_v36 (System.Int32)] = 0;\n\tv78 = this.m_shaderGraphMono;\n\tv79 = v78.Array;\n\tv372 = v206 < v79.Length;\n\tv247 = ~v372;\n\tif (v247) goto L_0159;\n\tv79[v206 @ X8_v36 (System.Int32)] = 0;\n\tv146 = this.m_shaderGraphAllocated;\n\tv206 = v206 + 1;\n\tv352 = v206 < this.m_resolution;\n\tif (v352) goto L_0048;\nL_0091:\n\tv207 = this.m_graphyManager;\n\tv146.GoodColor.r = v207.m_allocatedRamColor;\n\tv146.GoodColor.g = v207.m_allocatedRamColor.g;\n\tv146.GoodColor.a = v207.m_allocatedRamColor.a;\n\tv208 = this.m_graphyManager;\n\tv147 = this.m_shaderGraphAllocated;\n\tv147.CautionColor.r = v208.m_allocatedRamColor;\n\tv147.CautionColor.g = v208.m_allocatedRamColor.g;\n\tv147.CautionColor.a = v208.m_allocatedRamColor.a;\n\tv209 = this.m_graphyManager;\n\tv148 = this.m_shaderGraphAllocated;\n\tv148.CriticalColor.r = v209.m_allocatedRamColor;\n\tv148.CriticalColor.g = v209.m_allocatedRamColor.g;\n\tv148.CriticalColor.a = v209.m_allocatedRamColor.a;\n\tTayx.Graphy.G_GraphShader::UpdateColors(this.m_shaderGraphAllocated);\n\tv210 = this.m_graphyManager;\n\tv149 = this.m_shaderGraphReserved;\n\tv149.GoodColor.r = v210.m_reservedRamColor;\n\tv149.GoodColor.g = v210.m_reservedRamColor.g;\n\tv149.GoodColor.a = v210.m_reservedRamColor.a;\n\tv211 = this.m_graphyManager;\n\tv150 = this.m_shaderGraphReserved;\n\tv150.CautionColor.r = v211.m_reservedRamColor;\n\tv150.CautionColor.g = v211.m_reservedRamColor.g;\n\tv150.CautionColor.a = v211.m_reservedRamColor.a;\n\tv212 = this.m_graphyManager;\n\tv151 = this.m_shaderGraphReserved;\n\tv151.CriticalColor.r = v212.m_reservedRamColor;\n\tv151.CriticalColor.g = v212.m_reservedRamColor.g;\n\tv151.CriticalColor.a = v212.m_reservedRamColor.a;\n\tTayx.Graphy.G_GraphShader::UpdateColors(this.m_shaderGraphReserved);\n\tv213 = this.m_graphyManager;\n\tv152 = this.m_shaderGraphMono;\n\tv152.GoodColor.r = v213.m_monoRamColor;\n\tv152.GoodColor.g = v213.m_monoRamColor.g;\n\tv152.GoodColor.a = v213.m_monoRamColor.a;\n\tv214 = this.m_graphyManager;\n\tv153 = this.m_shaderGraphMono;\n\tv153.CautionColor.r = v214.m_monoRamColor;\n\tv153.CautionColor.g = v214.m_monoRamColor.g;\n\tv153.CautionColor.a = v214.m_monoRamColor.a;\n\tv215 = this.m_graphyManager;\n\tv154 = this.m_shaderGraphMono;\n\tv154.CriticalColor.r = v215.m_monoRamColor;\n\tv154.CriticalColor.g = v215.m_monoRamColor.g;\n\tv154.CriticalColor.a = v215.m_monoRamColor.a;\n\tTayx.Graphy.G_GraphShader::UpdateColors(this.m_shaderGraphMono);\n\tv216 = this.m_shaderGraphAllocated;\n\tv216.GoodThreshold = 0f;\n\tv217 = this.m_shaderGraphAllocated;\n\tv217.CautionThreshold = 0f;\n\tTayx.Graphy.G_GraphShader::UpdateThresholds(this.m_shaderGraphAllocated);\n\tv218 = this.m_shaderGraphReserved;\n\tv218.GoodThreshold = 0f;\n\tv219 = this.m_shaderGraphReserved;\n\tv219.CautionThreshold = 0f;\n\tTayx.Graphy.G_GraphShader::UpdateThresholds(this.m_shaderGraphReserved);\n\tv220 = this.m_shaderGraphMono;\n\tv220.GoodThreshold = 0f;\n\tv221 = this.m_shaderGraphMono;\n\tv221.CautionThreshold = 0f;\n\tTayx.Graphy.G_GraphShader::UpdateThresholds(this.m_shaderGraphMono);\n\tTayx.Graphy.G_GraphShader::UpdateArray(this.m_shaderGraphAllocated);\n\tTayx.Graphy.G_GraphShader::UpdateArray(this.m_shaderGraphReserved);\n\tTayx.Graphy.G_GraphShader::UpdateArray(this.m_shaderGraphMono);\n\tv222 = this.m_shaderGraphAllocated;\n\tv222.Average = 0f;\n\tv223 = this.m_shaderGraphReserved;\n\tv223.Average = 0f;\n\tv224 = this.m_shaderGraphMono;\n\tv224.Average = 0f;\n\tTayx.Graphy.G_GraphShader::UpdateAverage(this.m_shaderGraphAllocated);\n\tTayx.Graphy.G_GraphShader::UpdateAverage(this.m_shaderGraphReserved);\n\tTayx.Graphy.G_GraphShader::UpdateAverage(this.m_shaderGraphMono);\n\treturn;\n\tv226 = new System.NullReferenceException();\nL_0159:\n\tv255 = new System.IndexOutOfRangeException();\n\tthrow v255;\n\tthrow System.NullReferenceException;\n// 227 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void CreatePoints()
		{
			G_GraphShader shaderGraphAllocated = m_shaderGraphAllocated;
			float[] array = new float[m_resolution];
			shaderGraphAllocated.Array = array;
			G_GraphShader shaderGraphReserved = m_shaderGraphReserved;
			float[] array2 = new float[m_resolution];
			shaderGraphReserved.Array = array2;
			G_GraphShader shaderGraphMono = m_shaderGraphMono;
			float[] array3 = new float[m_resolution];
			shaderGraphMono.Array = array3;
			float[] allocatedArray = new float[m_resolution];
			m_allocatedArray = allocatedArray;
			float[] reservedArray = new float[m_resolution];
			m_reservedArray = reservedArray;
			float[] monoArray = new float[m_resolution];
			G_GraphShader shaderGraphAllocated2 = m_shaderGraphAllocated;
			m_monoArray = monoArray;
			if (m_resolution >= 1)
			{
				G_GraphShader g_GraphShader = shaderGraphAllocated2;
				int num = 0;
				while (true)
				{
					float[] array4 = g_GraphShader.Array;
					if (num < array4.Length)
					{
						array4[num] = 0f;
						G_GraphShader shaderGraphReserved2 = m_shaderGraphReserved;
						float[] array5 = shaderGraphReserved2.Array;
						if (num < array5.Length)
						{
							array5[num] = 0f;
							G_GraphShader shaderGraphMono2 = m_shaderGraphMono;
							float[] array6 = shaderGraphMono2.Array;
							if (num < array6.Length)
							{
								array6[num] = 0f;
								shaderGraphAllocated2 = m_shaderGraphAllocated;
								num++;
								bool flag = num < m_resolution;
								g_GraphShader = m_shaderGraphAllocated;
								if (!flag)
								{
									break;
								}
								continue;
							}
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			GraphyManager graphyManager = m_graphyManager;
			shaderGraphAllocated2.GoodColor.r = graphyManager.m_allocatedRamColor.r;
			shaderGraphAllocated2.GoodColor.g = graphyManager.m_allocatedRamColor.g;
			shaderGraphAllocated2.GoodColor.a = graphyManager.m_allocatedRamColor.a;
			GraphyManager graphyManager2 = m_graphyManager;
			G_GraphShader shaderGraphAllocated3 = m_shaderGraphAllocated;
			shaderGraphAllocated3.CautionColor.r = graphyManager2.m_allocatedRamColor.r;
			shaderGraphAllocated3.CautionColor.g = graphyManager2.m_allocatedRamColor.g;
			shaderGraphAllocated3.CautionColor.a = graphyManager2.m_allocatedRamColor.a;
			GraphyManager graphyManager3 = m_graphyManager;
			G_GraphShader shaderGraphAllocated4 = m_shaderGraphAllocated;
			shaderGraphAllocated4.CriticalColor.r = graphyManager3.m_allocatedRamColor.r;
			shaderGraphAllocated4.CriticalColor.g = graphyManager3.m_allocatedRamColor.g;
			shaderGraphAllocated4.CriticalColor.a = graphyManager3.m_allocatedRamColor.a;
			m_shaderGraphAllocated.UpdateColors();
			GraphyManager graphyManager4 = m_graphyManager;
			G_GraphShader shaderGraphReserved3 = m_shaderGraphReserved;
			shaderGraphReserved3.GoodColor.r = graphyManager4.m_reservedRamColor.r;
			shaderGraphReserved3.GoodColor.g = graphyManager4.m_reservedRamColor.g;
			shaderGraphReserved3.GoodColor.a = graphyManager4.m_reservedRamColor.a;
			GraphyManager graphyManager5 = m_graphyManager;
			G_GraphShader shaderGraphReserved4 = m_shaderGraphReserved;
			shaderGraphReserved4.CautionColor.r = graphyManager5.m_reservedRamColor.r;
			shaderGraphReserved4.CautionColor.g = graphyManager5.m_reservedRamColor.g;
			shaderGraphReserved4.CautionColor.a = graphyManager5.m_reservedRamColor.a;
			GraphyManager graphyManager6 = m_graphyManager;
			G_GraphShader shaderGraphReserved5 = m_shaderGraphReserved;
			shaderGraphReserved5.CriticalColor.r = graphyManager6.m_reservedRamColor.r;
			shaderGraphReserved5.CriticalColor.g = graphyManager6.m_reservedRamColor.g;
			shaderGraphReserved5.CriticalColor.a = graphyManager6.m_reservedRamColor.a;
			m_shaderGraphReserved.UpdateColors();
			GraphyManager graphyManager7 = m_graphyManager;
			G_GraphShader shaderGraphMono3 = m_shaderGraphMono;
			shaderGraphMono3.GoodColor.r = graphyManager7.m_monoRamColor.r;
			shaderGraphMono3.GoodColor.g = graphyManager7.m_monoRamColor.g;
			shaderGraphMono3.GoodColor.a = graphyManager7.m_monoRamColor.a;
			GraphyManager graphyManager8 = m_graphyManager;
			G_GraphShader shaderGraphMono4 = m_shaderGraphMono;
			shaderGraphMono4.CautionColor.r = graphyManager8.m_monoRamColor.r;
			shaderGraphMono4.CautionColor.g = graphyManager8.m_monoRamColor.g;
			shaderGraphMono4.CautionColor.a = graphyManager8.m_monoRamColor.a;
			GraphyManager graphyManager9 = m_graphyManager;
			G_GraphShader shaderGraphMono5 = m_shaderGraphMono;
			shaderGraphMono5.CriticalColor.r = graphyManager9.m_monoRamColor.r;
			shaderGraphMono5.CriticalColor.g = graphyManager9.m_monoRamColor.g;
			shaderGraphMono5.CriticalColor.a = graphyManager9.m_monoRamColor.a;
			m_shaderGraphMono.UpdateColors();
			G_GraphShader shaderGraphAllocated5 = m_shaderGraphAllocated;
			shaderGraphAllocated5.GoodThreshold = 0f;
			G_GraphShader shaderGraphAllocated6 = m_shaderGraphAllocated;
			shaderGraphAllocated6.CautionThreshold = 0f;
			m_shaderGraphAllocated.UpdateThresholds();
			G_GraphShader shaderGraphReserved6 = m_shaderGraphReserved;
			shaderGraphReserved6.GoodThreshold = 0f;
			G_GraphShader shaderGraphReserved7 = m_shaderGraphReserved;
			shaderGraphReserved7.CautionThreshold = 0f;
			m_shaderGraphReserved.UpdateThresholds();
			G_GraphShader shaderGraphMono6 = m_shaderGraphMono;
			shaderGraphMono6.GoodThreshold = 0f;
			G_GraphShader shaderGraphMono7 = m_shaderGraphMono;
			shaderGraphMono7.CautionThreshold = 0f;
			m_shaderGraphMono.UpdateThresholds();
			m_shaderGraphAllocated.UpdateArray();
			m_shaderGraphReserved.UpdateArray();
			m_shaderGraphMono.UpdateArray();
			G_GraphShader shaderGraphAllocated7 = m_shaderGraphAllocated;
			shaderGraphAllocated7.Average = 0f;
			G_GraphShader shaderGraphReserved8 = m_shaderGraphReserved;
			shaderGraphReserved8.Average = 0f;
			G_GraphShader shaderGraphMono8 = m_shaderGraphMono;
			shaderGraphMono8.Average = 0f;
			m_shaderGraphAllocated.UpdateAverage();
			m_shaderGraphReserved.UpdateAverage();
			m_shaderGraphMono.UpdateAverage();
		}

		[Token(Token = "0x6000178")]
		[Address(RVA = "0xB16E74", Offset = "0xB16E74", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1ED9240]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022556]) = v40;\nL_0016:\n\tv43 = UnityEngine.Component::get_transform(this);\n\tv46 = UnityEngine.Transform::get_root(v43);\n\tv67 = UnityEngine.Component::GetComponentInChildren(v46);\n\tthis.m_graphyManager = v67;\n\tv90 = UnityEngine.Component::GetComponent(this);\n\tthis.m_ramMonitor = v90;\n\tv93 = new Tayx.Graphy.G_GraphShader();\n\tTayx.Graphy.G_GraphShader::.ctor(v93);\n\tthis.m_shaderGraphAllocated = v93;\n\tv96 = new Tayx.Graphy.G_GraphShader();\n\tTayx.Graphy.G_GraphShader::.ctor(v96);\n\tthis.m_shaderGraphReserved = v96;\n\tv99 = new Tayx.Graphy.G_GraphShader();\n\tTayx.Graphy.G_GraphShader::.ctor(v99);\n\tv100 = this.m_shaderGraphAllocated;\n\tthis.m_shaderGraphMono = v99;\n\tv100.Image = this.m_imageAllocated;\n\tv103 = this.m_shaderGraphReserved;\n\tv103.Image = this.m_imageReserved;\n\tv82 = this.m_shaderGraphMono;\n\tv82.Image = this.m_imageMono;\n\tTayx.Graphy.Ram.G_RamGraph::UpdateParameters(this);\n\treturn;\n\tv55 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Init()
		{
			Transform transform = base.transform;
			Transform root = transform.root;
			GraphyManager componentInChildren = root.GetComponentInChildren<GraphyManager>();
			m_graphyManager = componentInChildren;
			G_RamMonitor component = GetComponent<G_RamMonitor>();
			m_ramMonitor = component;
			G_GraphShader shaderGraphAllocated = new G_GraphShader();
			m_shaderGraphAllocated = shaderGraphAllocated;
			G_GraphShader shaderGraphReserved = new G_GraphShader();
			m_shaderGraphReserved = shaderGraphReserved;
			G_GraphShader shaderGraphMono = new G_GraphShader();
			G_GraphShader shaderGraphAllocated2 = m_shaderGraphAllocated;
			m_shaderGraphMono = shaderGraphMono;
			shaderGraphAllocated2.Image = m_imageAllocated;
			G_GraphShader shaderGraphReserved2 = m_shaderGraphReserved;
			shaderGraphReserved2.Image = m_imageReserved;
			G_GraphShader shaderGraphMono2 = m_shaderGraphMono;
			shaderGraphMono2.Image = m_imageMono;
			UpdateParameters();
		}

		[Token(Token = "0x6000179")]
		[Address(RVA = "0xB178AC", Offset = "0xB178AC", Length = "0x1010")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_resolution = 0x96;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n\tHutongGames.PlayMaker.Actions.MoveTowards::Reset(X0, X1);\n\treturn;\n\tX9 = *([X9+3A8]);\n\tX0 = 0xB04004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0xB01004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1021 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_RamGraph()
		{
			m_resolution = 150;
		}
	}
}
