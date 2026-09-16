using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000031")]
	public class AtlasAttachmentLoader : AttachmentLoader
	{
		[Token(Token = "0x4000121")]
		[FieldOffset(Offset = "0x10")]
		private Atlas[] atlasArray;

		[Token(Token = "0x600015B")]
		[Address(RVA = "0x152DFC0", Offset = "0x152DFC0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv11 = atlasArray == 0;\n\tif (v11) goto L_0013;\n\tthis.atlasArray = atlasArray;\n\treturn;\nL_0013:\n\tv42 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v42, \"atlas array cannot be null.\");\n\tthrow v42;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AtlasAttachmentLoader(params Atlas[] atlasArray)
		{
			if (atlasArray != null)
			{
				this.atlasArray = atlasArray;
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("atlas array cannot be null.");
			throw ex;
		}

		[Token(Token = "0x600015C")]
		[Address(RVA = "0x152E034", Offset = "0x152E034", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Spine.RegionAttachment;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, skin, name, path, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37B35]) = v39;\nL_0016:\n\tv42 = Spine.AtlasAttachmentLoader::FindRegion(this, path);\n\tv43 = v42 == 0;\n\tif (v43) goto L_0043;\n\tv48 = new Spine.RegionAttachment();\n\tSpine.RegionAttachment::.ctor(v48, name);\n\tv48.<RendererObject>k__BackingField = v42;\n\tSpine.RegionAttachment::SetUVs(v48, v42.u, v42.v, v42.u2, v42.v2, v42.rotate);\n\tv48.regionOffsetX = v42.offsetX;\n\t// 49 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv48.regionWidth = v42.width;\n\t// 54 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv48.regionOriginalWidth = v42.originalWidth;\n\treturn v48;\nL_0043:\n\tv58 = System.String::Format(\"Region not found in atlas: {0} (region attachment: {1})\", path, name);\n\tv85 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v85, v58);\n\tthrow v85;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RegionAttachment NewRegionAttachment(Skin skin, string name, string path)
		{
			//IL_0089: Expected F4, but got I4
			//IL_00a5: Expected F4, but got I4
			AtlasRegion atlasRegion = FindRegion(path);
			if (atlasRegion != null)
			{
				RegionAttachment regionAttachment = new RegionAttachment(name);
				regionAttachment.RendererObject = atlasRegion;
				regionAttachment.SetUVs(atlasRegion.u, atlasRegion.v, atlasRegion.u2, atlasRegion.v2, atlasRegion.rotate);
				regionAttachment.RegionOffsetX = atlasRegion.offsetX;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				regionAttachment.RegionWidth = atlasRegion.width;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				regionAttachment.RegionOriginalWidth = atlasRegion.originalWidth;
				return regionAttachment;
			}
			string message = $"Region not found in atlas: {path} (region attachment: {name})";
			ArgumentException ex = new ArgumentException(message);
			throw ex;
		}

		[Token(Token = "0x600015D")]
		[Address(RVA = "0x152E1BC", Offset = "0x152E1BC", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Spine.MeshAttachment;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, skin, name, path, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37B36]) = v39;\nL_0016:\n\tv42 = Spine.AtlasAttachmentLoader::FindRegion(this, path);\n\tv43 = v42 == 0;\n\tif (v43) goto L_0040;\n\tv48 = new Spine.MeshAttachment();\n\tSpine.MeshAttachment::.ctor(v48, name);\n\tv48.<RendererObject>k__BackingField = v42;\n\tv48.<RegionU>k__BackingField = v42.u;\n\tv48.<RegionRotate>k__BackingField = v42.rotate;\n\tv48.<RegionDegrees>k__BackingField = v42.degrees;\n\tv48.regionOffsetX = v42.offsetX;\n\t// 46 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv48.regionWidth = v42.width;\n\t// 51 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv48.regionOriginalWidth = v42.originalWidth;\n\treturn v48;\nL_0040:\n\tv57 = System.String::Format(\"Region not found in atlas: {0} (region attachment: {1})\", path, name);\n\tv89 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v89, v57);\n\tthrow v89;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MeshAttachment NewMeshAttachment(Skin skin, string name, string path)
		{
			//IL_0089: Expected F4, but got I4
			//IL_00a5: Expected F4, but got I4
			AtlasRegion atlasRegion = FindRegion(path);
			if (atlasRegion != null)
			{
				MeshAttachment meshAttachment = new MeshAttachment(name);
				meshAttachment.RendererObject = atlasRegion;
				meshAttachment.RegionU = atlasRegion.u;
				meshAttachment.RegionRotate = atlasRegion.rotate;
				meshAttachment.RegionDegrees = atlasRegion.degrees;
				meshAttachment.RegionOffsetX = atlasRegion.offsetX;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				meshAttachment.RegionWidth = atlasRegion.width;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				meshAttachment.RegionOriginalWidth = atlasRegion.originalWidth;
				return meshAttachment;
			}
			string message = $"Region not found in atlas: {path} (region attachment: {name})";
			ArgumentException ex = new ArgumentException(message);
			throw ex;
		}

		[Token(Token = "0x600015E")]
		[Address(RVA = "0x152E344", Offset = "0x152E344", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.BoundingBoxAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skin, name, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37B37]) = v37;\nL_0014:\n\tv39 = new Spine.BoundingBoxAttachment();\n\tSpine.BoundingBoxAttachment::.ctor(v39, name);\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoundingBoxAttachment NewBoundingBoxAttachment(Skin skin, string name)
		{
			return new BoundingBoxAttachment(name);
		}

		[Token(Token = "0x600015F")]
		[Address(RVA = "0x152E404", Offset = "0x152E404", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.PathAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skin, name, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37B38]) = v37;\nL_0014:\n\tv39 = new Spine.PathAttachment();\n\tSpine.PathAttachment::.ctor(v39, name);\n\treturn v39;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PathAttachment NewPathAttachment(Skin skin, string name)
		{
			return new PathAttachment(name);
		}

		[Token(Token = "0x6000160")]
		[Address(RVA = "0x152E460", Offset = "0x152E460", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.PointAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skin, name, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37B39]) = v37;\nL_0014:\n\tv39 = new Spine.PointAttachment();\n\tSpine.PointAttachment::.ctor(v39, name);\n\treturn v39;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PointAttachment NewPointAttachment(Skin skin, string name)
		{
			return new PointAttachment(name);
		}

		[Token(Token = "0x6000161")]
		[Address(RVA = "0x152E4BC", Offset = "0x152E4BC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.ClippingAttachment;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skin, name, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37B3A]) = v37;\nL_0014:\n\tv39 = new Spine.ClippingAttachment();\n\tSpine.ClippingAttachment::.ctor(v39, name);\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ClippingAttachment NewClippingAttachment(Skin skin, string name)
		{
			return new ClippingAttachment(name);
		}

		[Token(Token = "0x6000162")]
		[Address(RVA = "0x152E150", Offset = "0x152E150", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv93 = this.atlasArray;\nL_0015:\n\tv16 = v56 >= v93.Length;\n\tif (v16) goto L_FFFFFFFF;\n\treturnVal1 = Spine.Atlas::FindRegion(v93[v56 @ X21_v6 (System.Int32)], name);\n\tv166 = returnVal1 == 0;\n\tv140 = ~v166;\n\tif (v140) goto L_0037;\n\tv93 = this.atlasArray;\n\tv56 = v56 + 1;\n\tv167 = this.atlasArray == 0;\n\tv60 = ~v167;\n\tif (v60) goto L_0015;\n\tthrow System.NullReferenceException;\nL_0037:\n\treturn returnVal1;\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AtlasRegion FindRegion(string name)
		{
			Atlas[] array = atlasArray;
			int num = 0;
			AtlasRegion atlasRegion;
			while (true)
			{
				if (num < array.Length)
				{
					atlasRegion = array[num].FindRegion(name);
					if (atlasRegion != null)
					{
						break;
					}
					array = atlasArray;
					num++;
					if (atlasArray == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				atlasRegion = null;
				break;
			}
			return atlasRegion;
		}
	}
}
