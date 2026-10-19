using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;

namespace HighlightPlus
{
	[Token(Token = "0x200003F")]
	public static class RenderingUtils
	{
		[Token(Token = "0x4000346")]
		private static Mesh _fullScreenMesh;

		[Token(Token = "0x4000347")]
		private static Matrix4x4 matrix4x4Identity;

		[Token(Token = "0x17000015")]
		private static Mesh fullscreenMesh
		{
			[Token(Token = "0x600013B")]
			[Address(RVA = "0x7732C38", Offset = "0x7732C38", Length = "0x5E0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tv45 = 0xB292000 + 0x5A0;\n\tgoto L_0017;\nL_0017:\n\tv53 = *([v45 @ X20_v16 (System.Int32)]);\n\tv55 = *([v53 @ X0_v89+E4]) == 0;\n\tif (v55) goto L_005F;\n\tv76 = UnityEngine.Object::op_Inequality(v51._fullScreenMesh, 0);\n\tv89 = ~v76;\n\tif (v89) goto L_006A;\nL_0025:\n\tgoto L_01F6;\nL_005F:\n\tv93 = UnityEngine.Object::op_Inequality(v51._fullScreenMesh, 0);\n\tv124 = ~v93;\n\tv102 = ~v124;\n\tif (v102) goto L_0025;\nL_006A:\n\tv123 = new UnityEngine.Mesh();\n\tUnityEngine.Mesh::.ctor(v123);\n\tgoto L_0076;\n\tv349 = v332._version + 1;\n\tv332._version = v349;\n\tv456 = v332._items;\n\tv521 = v332.Count < v456.Length;\n\tv431 = ~v521;\n\tif (v431) goto L_00AA;\n\tv533 = v332.Count + 1;\n\tv524 = v332.Count * 0xC;\n\tv525 = v456 + v524;\n\t*([v525 @ X12_v19+20]) = 0;\n\tv456[v519 @ X12_v3 (System.Int32)].z = 0f;\n\tv447 = v332._version + 2;\n\tv332.Count = v533;\n\tv332._version = v447;\n\tgoto L_00B5;\nL_00AA:\n\t// 170 MakeStruct v360 @ AGG7732E64_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), -1f, -1f, 0\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::AddWithResize(v332, v360);\n\tv456 = v332._items;\n\tv533 = v332.Count;\n\tv447 = v332._version + 1;\n\tv332._version = v447;\nL_00B5:\n\tv541 = v533 < v456.Length;\n\tv432 = ~v541;\n\tif (v432) goto L_00D2;\n\tv463 = v533 + 1;\n\tv544 = v533 * 0xC;\n\tv545 = v456 + v544;\n\t*([v545 @ X10_v26+20]) = 0;\n\tv456[v533 @ X10_v4 (System.Int32)].z = 0f;\n\tv554 = v447 + 1;\n\tv332.Count = v463;\n\tv332._version = v554;\n\tgoto L_00DD;\nL_00D2:\n\t// 210 MakeStruct v359 @ AGG7732ED0_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), -1f, 1f, 0\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::AddWithResize(v332, v359);\n\tv456 = v332._items;\n\tv463 = v332.Count;\n\tv554 = v332._version + 1;\n\tv332._version = v554;\nL_00DD:\n\tv561 = v463 < v456.Length;\n\tv433 = ~v561;\n\tif (v433) goto L_00FA;\n\tv449 = v463 + 1;\n\tv565 = v463 * 0xC;\n\tv566 = v456 + v565;\n\t*([v566 @ X11_v17+20]) = 0;\n\tv456[v463 @ X11_v6 (System.Int32)].z = 0f;\n\tv569 = v554 + 1;\n\tv332.Count = v449;\n\tv332._version = v569;\n\tgoto L_0105;\nL_00FA:\n\t// 250 MakeStruct v358 @ AGG7732F3C_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 1f, -1f, 0\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::AddWithResize(v332, v358);\n\tv456 = v332._items;\n\tv449 = v332.Count;\n\tv440 = v332._version + 1;\n\tv332._version = v440;\nL_0105:\n\tv580 = v449 < v456.Length;\n\tv434 = ~v580;\n\tif (v434) goto L_011F;\n\tv582 = v449 + 1;\n\tv332.Count = v582;\n\tv584 = v449 * 0xC;\n\tv585 = v456 + v584;\n\t*([v585 @ X8_v53+20]) = 0;\n\tv456[v449 @ X12_v6 (System.Int32)].z = 0f;\n\tgoto L_0126;\nL_011F:\n\t// 287 MakeStruct v594 @ AGG7732FA0_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 1f, 1f, 0\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::AddWithResize(v332, v594);\nL_0126:\n\tUnityEngine.Mesh::SetVertices(v329._fullScreenMesh, v332);\n\tv486 = new System.Collections.Generic.List`1<UnityEngine.Vector2>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::.ctor(v486);\n\tv605 = v486._version + 1;\n\tv486._version = v605;\n\tv202 = v486._items;\n\tv608 = v486.Count < v202.Length;\n\tv435 = ~v608;\n\tif (v435) goto L_0158;\n\tv619 = v486.Count + 1;\n\tv486.Count = v619;\n\tv610 = v486.Count << 3;\n\tv611 = v202 + v610;\n\t*([v611 @ X12_v14+20]) = 0;\n\tv451 = v486._version + 2;\n\tv486._version = v451;\n\tgoto L_0163;\nL_0158:\n\t// 344 MakeStruct v355 @ AGG7733050_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, 0\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::AddWithResize(v486, v355);\n\tv202 = v486._items;\n\tv619 = v486.Count;\n\tv451 = v486._version + 1;\n\tv486._version = v451;\nL_0163:\n\tv625 = v619 < v202.Length;\n\tv436 = ~v625;\n\tif (v436) goto L_017D;\n\tv636 = v619 + 1;\n\tv627 = v619 << 3;\n\tv628 = v202 + v627;\n\t*([v628 @ X11_v13+20]) = 0.0078125d;\n\tv205 = v451 + 1;\n\tv486.Count = v636;\n\tv486._version = v205;\n\tgoto L_0188;\nL_017D:\n\t// 381 MakeStruct v354 @ AGG77330B0_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, 1f\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::AddWithResize(v486, v354);\n\tv202 = v486._items;\n\tv636 = v486.Count;\n\tv205 = v486._version + 1;\n\tv486._version = v205;\nL_0188:\n\tv643 = v636 < v202.Length;\n\tv437 = ~v643;\n\tif (v437) goto L_01A2;\n\tv199 = v636 + 1;\n\tv646 = v636 << 3;\n\tv647 = v202 + v646;\n\t*([v647 @ X10_v16+20]) = 5.263544247E-315d;\n\tv650 = v205 + 1;\n\tv486.Count = v199;\n\tv486._version = v650;\n\tgoto L_01AD;\nL_01A2:\n\t// 418 MakeStruct v353 @ AGG7733110_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 1f, 0\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::AddWithResize(v486, v353);\n\tv202 = v486._items;\n\tv199 = v486.Count;\n\tv445 = v486._version + 1;\n\tv486._version = v445;\nL_01AD:\n\tv661 = v199 < v202.Length;\n\tv193 = ~v661;\n\tif (v193) goto L_01C4;\n\tv663 = v199 + 1;\n\tv486.Count = v663;\n\tv664 = v199 << 3;\n\tv665 = v202 + v664;\n\t*([v665 @ X8_v39+20]) = 0;\n\tgoto L_01CC;\nL_01C4:\n\t// 452 MakeStruct v673 @ AGG7733168_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 1f, 1f\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::AddWithResize(v486, v673);\nL_01CC:\n\tUnityEngine.Mesh::SetUVs(v599._fullScreenMesh, 0, v486);\n\t// 468 NewArr v491 @ X0_v27 (System.Int32[]), typeof(System.Int32[]), 6\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v491, Il2CppFieldInfo);\n\tUnityEngine.Mesh::SetIndices(v678._fullScreenMesh, v491, 0, 0, 0);\n\tUnityEngine.Mesh::UploadMeshData(v220._fullScreenMesh, 1);\nL_01F6:\n\treturn v224._fullScreenMesh;\nL_0076:\n\tv322._fullScreenMesh = v123;\n\tv332 = new System.Collections.Generic.List`1<UnityEngine.Vector3>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(v332);\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("RenderingUtils::get_fullscreenMesh");
				return default;
			}
		}

		[Token(Token = "0x600013C")]
		[Address(RVA = "0x7733218", Offset = "0x7733218", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv57 = destination.m_Type;\n\tUnityEngine.Rendering.CommandBuffer::SetRenderTarget(cmd, &v57 @ stack_-90_v1 (UnityEngine.Rendering.BuiltinRenderTextureType));\n\tgoto L_0047;\nL_0055:\n\tv170 = HighlightPlus.RenderingUtils::get_fullscreenMesh();\n\tv124 = v150.matrix4x4Identity;\n\tUnityEngine.Rendering.CommandBuffer::DrawMesh(cmd, v170, &v124 @ stack_-D0_v1 (UnityEngine.Matrix4x4), material, 0, passIndex);\n\treturn;\nL_0021:\n\tv57 = destination.m_Type;\n\tUnityEngine.Rendering.RenderTargetIdentifier::.ctor(destination, &v57 @ stack_-90_v1 (UnityEngine.Rendering.BuiltinRenderTextureType), 0, -1, -1);\nL_0047:\n\tv57 = source.m_Type;\n\tUnityEngine.Rendering.CommandBuffer::SetGlobalTexture(cmd, v91.MainTex, &v57 @ stack_-90_v1 (UnityEngine.Rendering.BuiltinRenderTextureType));\n\tgoto L_0055;\n")]
		public unsafe static void FullScreenBlit(CommandBuffer cmd, RenderTargetIdentifier source, RenderTargetIdentifier destination, Material material, int passIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RenderingUtils::FullScreenBlit");
		}

		[Token(Token = "0x600013D")]
		[Address(RVA = "0x773339C", Offset = "0x773339C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tgoto L_002A;\nL_002A:\n\tv59.matrix4x4Identity.m00 = v57.identity;\n\tv59.matrix4x4Identity.m03 = v57.identity.m03;\n\tv59.matrix4x4Identity.m02 = v57.identity.m02;\n\tv59.matrix4x4Identity.m01 = v57.identity.m01;\n\treturn;\n")]
		static RenderingUtils()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RenderingUtils::.cctor");
		}
	}
}
