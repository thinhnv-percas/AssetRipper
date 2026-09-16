using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x200006A")]
	public class RegionlessAttachmentLoader : AttachmentLoader
	{
		[Token(Token = "0x40002A4")]
		private static AtlasRegion emptyRegion;

		[Token(Token = "0x17000174")]
		private static AtlasRegion EmptyRegion
		{
			[Token(Token = "0x6000490")]
			[Address(RVA = "0x15515E4", Offset = "0x15515E4", Length = "0x184")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv20 = Spine.AtlasPage;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv48 = Spine.AtlasRegion;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv79 = UnityEngine.Material;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv102 = Spine.Unity.RegionlessAttachmentLoader;\n\tv103 = \"il2cpp_codegen_initialize_runtime_metadata\"(v102, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv106 = \"Spine/Special/HiddenPass\";\n\tv107 = \"il2cpp_codegen_initialize_runtime_metadata\"(v106, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv123 = \"Empty AtlasPage\";\n\tv124 = \"il2cpp_codegen_initialize_runtime_metadata\"(v123, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv126 = \"Empty AtlasRegion\";\n\tv127 = \"il2cpp_codegen_initialize_runtime_metadata\"(v126, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv129 = \"NoRender Material\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v129, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv41 = 1;\n\t*([1A37BCD]) = v41;\nL_002B:\n\treturnVal1 = v43.emptyRegion;\n\tv45 = v43.emptyRegion == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_006F;\n\tv53 = new Spine.AtlasRegion();\n\tSpine.AtlasRegion::.ctor(v53);\n\tv104 = v53 == 0;\n\tif (v104) goto L_0070;\n\tv53.name = \"Empty AtlasRegion\";\n\tv114 = new Spine.AtlasPage();\n\tSpine.AtlasPage::.ctor(v114);\n\tv120 = v114 == 0;\n\tif (v120) goto L_0070;\n\tv114.name = \"Empty AtlasPage\";\n\tv137 = UnityEngine.Shader::Find(\"Spine/Special/HiddenPass\");\n\tv119 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v119, v137);\n\tv67 = v119 == 0;\n\tif (v67) goto L_0070;\n\tUnityEngine.Object::set_name(v119, \"NoRender Material\");\n\tv114.rendererObject = v119;\n\tv53.page = v114;\n\tv145.emptyRegion = v53;\n\treturnVal1 = v69.emptyRegion;\nL_006F:\n\treturn returnVal1;\nL_0070:\n\tthrow v119;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				AtlasRegion result = emptyRegion;
				if (emptyRegion == null)
				{
					AtlasRegion atlasRegion = new AtlasRegion();
					bool flag = atlasRegion == null;
					Material material = (Material)(object)atlasRegion;
					if (!flag)
					{
						atlasRegion.name = "Empty AtlasRegion";
						AtlasPage atlasPage = new AtlasPage();
						bool flag2 = atlasPage == null;
						material = (Material)(object)atlasPage;
						if (!flag2)
						{
							atlasPage.name = "Empty AtlasPage";
							Shader shader = Shader.Find("Spine/Special/HiddenPass");
							material = new Material(shader);
							if ((object)material != null)
							{
								material.name = "NoRender Material";
								atlasPage.rendererObject = material;
								atlasRegion.page = atlasPage;
								emptyRegion = atlasRegion;
								result = emptyRegion;
								goto IL_013d;
							}
						}
					}
					throw material;
				}
				goto IL_013d;
				IL_013d:
				return result;
			}
		}

		[Token(Token = "0x6000491")]
		[Address(RVA = "0x1551768", Offset = "0x1551768", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.RegionAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skin, name, path, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37BCE]) = v37;\nL_0014:\n\tv39 = new Spine.RegionAttachment();\n\tSpine.RegionAttachment::.ctor(v39, name);\n\tv43 = Spine.Unity.RegionlessAttachmentLoader::get_EmptyRegion();\n\tv39.<RendererObject>k__BackingField = v43;\n\treturn v39;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RegionAttachment NewRegionAttachment(Skin skin, string name, string path)
		{
			RegionAttachment regionAttachment = new RegionAttachment(name);
			AtlasRegion rendererObject = EmptyRegion;
			regionAttachment.RendererObject = rendererObject;
			return regionAttachment;
		}

		[Token(Token = "0x6000492")]
		[Address(RVA = "0x15517D4", Offset = "0x15517D4", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.MeshAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skin, name, path, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37BCF]) = v37;\nL_0014:\n\tv39 = new Spine.MeshAttachment();\n\tSpine.MeshAttachment::.ctor(v39, name);\n\tv43 = Spine.Unity.RegionlessAttachmentLoader::get_EmptyRegion();\n\tv39.<RendererObject>k__BackingField = v43;\n\treturn v39;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MeshAttachment NewMeshAttachment(Skin skin, string name, string path)
		{
			MeshAttachment meshAttachment = new MeshAttachment(name);
			AtlasRegion rendererObject = EmptyRegion;
			meshAttachment.RendererObject = rendererObject;
			return meshAttachment;
		}

		[Token(Token = "0x6000493")]
		[Address(RVA = "0x1551840", Offset = "0x1551840", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.BoundingBoxAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skin, name, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37BD0]) = v37;\nL_0014:\n\tv39 = new Spine.BoundingBoxAttachment();\n\tSpine.BoundingBoxAttachment::.ctor(v39, name);\n\treturn v39;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoundingBoxAttachment NewBoundingBoxAttachment(Skin skin, string name)
		{
			return new BoundingBoxAttachment(name);
		}

		[Token(Token = "0x6000494")]
		[Address(RVA = "0x155189C", Offset = "0x155189C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.PathAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skin, name, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37BD1]) = v37;\nL_0014:\n\tv39 = new Spine.PathAttachment();\n\tSpine.PathAttachment::.ctor(v39, name);\n\treturn v39;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PathAttachment NewPathAttachment(Skin skin, string name)
		{
			return new PathAttachment(name);
		}

		[Token(Token = "0x6000495")]
		[Address(RVA = "0x15518F8", Offset = "0x15518F8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.PointAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skin, name, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37BD2]) = v37;\nL_0014:\n\tv39 = new Spine.PointAttachment();\n\tSpine.PointAttachment::.ctor(v39, name);\n\treturn v39;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PointAttachment NewPointAttachment(Skin skin, string name)
		{
			return new PointAttachment(name);
		}

		[Token(Token = "0x6000496")]
		[Address(RVA = "0x1551954", Offset = "0x1551954", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.ClippingAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skin, name, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37BD3]) = v37;\nL_0014:\n\tv39 = new Spine.ClippingAttachment();\n\tSpine.ClippingAttachment::.ctor(v39, name);\n\treturn v39;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ClippingAttachment NewClippingAttachment(Skin skin, string name)
		{
			return new ClippingAttachment(name);
		}

		[Token(Token = "0x6000497")]
		[Address(RVA = "0x15519B0", Offset = "0x15519B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RegionlessAttachmentLoader()
		{
		}
	}
}
