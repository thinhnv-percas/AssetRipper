using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Rendering;
using _game.CoreSystem.SandPhysics.Components;

namespace _game.CoreSystem.SandPhysics.Services
{
	[Token(Token = "0x200010A")]
	public class SandPrototypeEntityFactory
	{
		[Token(Token = "0x4000372")]
		private static readonly int s_baseMapId;

		[Token(Token = "0x4000373")]
		private static readonly int s_mainTexId;

		[Token(Token = "0x4000374")]
		private static Mesh s_quadMesh;

		[Token(Token = "0x60005AE")]
		[Address(RVA = "0x3DAC5AC", Offset = "0x3DAC5AC", Length = "0x644")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = *([A4731E0]);\n\tgoto L_0082;\nL_0093:\n\tv112 = Unity.Entities.EntityManager::CreateEntity(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager));\n\tv122 = Unity.Entities.EntityManager::AddComponentData(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, 0);\n\tv131 = Unity.Entities.EntityManager::AddComponentData(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, 0);\n\tUnity.Entities.EntityManager::SetComponentEnabled(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, 0);\n\tv148 = Unity.Entities.EntityManager::AddComponentData(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, 0);\n\tUnity.Entities.EntityManager::SetComponentEnabled(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, 0);\n\tv166 = Unity.Entities.EntityManager::AddComponentData(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, Il2CppMethodInfo);\n\tv176 = Unity.Entities.EntityManager::AddComponentData(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, Il2CppMethodInfo);\n\tv185 = Unity.Entities.EntityManager::AddComponentData(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, 0);\n\tv196 = Unity.Entities.EntityManager::AddComponentData(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, resolvedParams.ParticleRadius);\n\tv207 = Unity.Entities.EntityManager::AddComponentData(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, 0xFFFF00);\n\tv241 = *([9308120]);\n\tv222 = Unity.Entities.EntityManager::AddComponentData(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, &v241 @ stack_-C0_v2 (System.Int32));\n\tv233 = Unity.Entities.EntityManager::AddComponentData(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, 0);\n\tv241 = 0;\n\tv249 = Unity.Entities.EntityManager::AddComponentData(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, &v241 @ stack_-C0_v2 (System.Int32));\n\tv263 = Unity.Entities.EntityManager::AddComponentData(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, Il2CppMethodInfo);\n\tgoto L_00FF;\nL_00FF:\n\tv280 = &v281 @ stack_-170;\n\tv284 = Unity.Transforms.LocalTransform::FromScale(v31);\n\tv241 = *([v280 @ X8_v24]);\n\tv305 = Unity.Entities.EntityManager::AddComponentData(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, &v241 @ stack_-C0_v2 (System.Int32));\n\tv324 = v312.identity;\n\tv332 = Unity.Entities.EntityManager::AddComponentData(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, &v324 @ stack_-C0_v4 (Unity.Mathematics.float4x4));\n\tgoto L_0133;\nL_0133:\n\tv347 = _game.CoreSystem.SandPhysics.Services.SandPrototypeEntityFactory::GetOrCreateQuadMesh();\n\tv353 = _game.CoreSystem.SandPhysics.Services.SandPrototypeEntityFactory::ResolveMaterial(assets);\n\tUnity.Rendering.RenderMeshDescription::.ctor(&v91 @ stack_-120_v1 (Unity.Rendering.RenderMeshDescription), 0, 0, 0, 0, -1, 0, 0);\n\t// 324 NewArr v371 @ X0_v47 (UnityEngine.Material[]), typeof(UnityEngine.Material[]), 1\n\tv374 = v353 == 0;\n\tif (v374) goto L_0157;\n\tv390 = 0x21C11D0(v353, UnityEngine.Material, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv394 = v390 == 0;\n\tif (v394) goto L_01DF;\nL_0157:\n\tv371[0] = v353;\n\t// 348 NewArr v379 @ X0_v62 (UnityEngine.Mesh[]), typeof(UnityEngine.Mesh[]), 1\n\tv379[0] = v347;\n\tUnity.Rendering.RenderMeshArray::.ctor(&v679 @ stack_-150_v4 (Unity.Rendering.RenderMeshArray), v371, v379, 0);\n\tv691 = Unity.Rendering.MaterialMeshInfo::FromRenderMeshArrayIndices(0, 0, 0);\n\tgoto L_0196;\n\tv490 = v716;\n\tUnity.Entities.EntityManager::SetName(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112, &v490 @ stack_-100_v4 (Unity.Collections.FixedString64Bytes));\n\tv720 = *([A4731E0]);\n\tv415 = *([v720 @ X9_v7]) != *([v37 @ X8_v2]);\n\tif (v415) goto L_01DE;\n\treturn v112;\nL_01DE:\n\tv537 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_01DF:\n\tv591 = new System.ArrayTypeMismatchException();\n\tthrow v591;\nL_0082:\n\tv91 = 0;\n\tgoto L_0093;\nL_0196:\n\tUnity.Rendering.RenderMeshUtility::AddComponents(v112, v110, &v91 @ stack_-120_v1 (Unity.Rendering.RenderMeshDescription), &v241 @ stack_-C0_v2 (System.Int32), v691);\n\tv712 = Unity.Entities.EntityManager::AddComponent(&v110 @ stack_-108_v2 (Unity.Entities.EntityManager), v112);\n\tv716 = Unity.Collections.FixedString64Bytes::op_Implicit(\"SandParticlePrototype\");\n")]
		public unsafe Entity CreatePrototype(EntityManager em, SandRenderingAssetsSO assets, SandParticleParams resolvedParams)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandPrototypeEntityFactory::CreatePrototype");
			return default;
		}

		[Token(Token = "0x60005AF")]
		[Address(RVA = "0x3DACBF0", Offset = "0x3DACBF0", Length = "0x32C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tv45 = 0xB292000 + 0x5A0;\n\tgoto L_0017;\nL_0017:\n\tv53 = *([v45 @ X20_v12 (System.Int32)]);\n\tv55 = *([v53 @ X0_v69+E4]) == 0;\n\tif (v55) goto L_0056;\n\tv76 = UnityEngine.Object::op_Inequality(v51.s_quadMesh, 0);\n\tv89 = ~v76;\n\tif (v89) goto L_005D;\nL_0025:\n\tgoto L_011E;\nL_0056:\n\tv93 = UnityEngine.Object::op_Inequality(v51.s_quadMesh, 0);\n\tv120 = ~v93;\n\tv102 = ~v120;\n\tif (v102) goto L_0025;\nL_005D:\n\tv119 = new UnityEngine.Mesh();\n\tUnityEngine.Mesh::.ctor(v119);\n\tUnityEngine.Object::set_name(v119, \"SandParticleQuad\");\n\tgoto L_0072;\n\t*([v268 @ X0_v15 (UnityEngine.Vector3[])+20]) = 0xBF;\n\t*([v268 @ X0_v15 (UnityEngine.Vector3[])+28]) = 0;\n\t*([v268 @ X0_v15 (UnityEngine.Vector3[])+2C]) = 0xFFFFFFFFFFFFFFC1;\n\t*([v268 @ X0_v15 (UnityEngine.Vector3[])+34]) = 0;\n\t*([v268 @ X0_v15 (UnityEngine.Vector3[])+38]) = 0xFFFFFFFFFFFFFF41;\n\t*([v268 @ X0_v15 (UnityEngine.Vector3[])+40]) = 0;\n\t*([v268 @ X0_v15 (UnityEngine.Vector3[])+44]) = 0x3F;\n\t*([v268 @ X0_v15 (UnityEngine.Vector3[])+4C]) = 0;\n\tUnityEngine.Mesh::set_vertices(v307.s_quadMesh, v268);\n\t// 189 NewArr v269 @ X0_v20 (UnityEngine.Vector2[]), typeof(UnityEngine.Vector2[]), 4\n\t*([v269 @ X0_v20 (UnityEngine.Vector2[])+20]) = 0;\n\t*([v269 @ X0_v20 (UnityEngine.Vector2[])+28]) = 5.263544247E-315d;\n\t*([v269 @ X0_v20 (UnityEngine.Vector2[])+30]) = 0.0078125d;\n\t*([v269 @ X0_v20 (UnityEngine.Vector2[])+38]) = 0;\n\tUnityEngine.Mesh::set_uv(v359.s_quadMesh, v269);\n\t// 249 NewArr v270 @ X0_v23 (System.Int32[]), typeof(System.Int32[]), 6\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v270, Il2CppFieldInfo);\n\tUnityEngine.Mesh::set_triangles(v369.s_quadMesh, v270);\n\tUnityEngine.Mesh::RecalculateNormals(v285.s_quadMesh);\n\tUnityEngine.Mesh::RecalculateBounds(v168.s_quadMesh);\nL_011E:\n\treturn v172.s_quadMesh;\nL_0072:\n\tv302.s_quadMesh = v119;\n\t// 124 NewArr v268 @ X0_v15 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), 4\n")]
		private static Mesh GetOrCreateQuadMesh()
		{
			//IL_0021: Expected O, but got I4
			int num = 187244544 + 1440;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v69+E4]");
			if ((nint)0 != 0)
			{
				if (!(s_quadMesh != null))
				{
					goto IL_00ab;
				}
			}
			else if (!(s_quadMesh != null))
			{
				goto IL_00ab;
			}
			goto IL_01cb;
			IL_01cb:
			return s_quadMesh;
			IL_00ab:
			Mesh mesh = new Mesh();
			mesh.name = "SandParticleQuad";
			s_quadMesh = mesh;
			Vector3[] vertices = new Vector3[4];
			_ = 191;
			_ = 0;
			_ = -63;
			_ = 0;
			_ = -191;
			_ = 0;
			_ = 63;
			_ = 0;
			s_quadMesh.vertices = vertices;
			Vector2[] uv = new Vector2[4];
			_ = 0;
			_ = 5.263544247E-315;
			_ = 1.0 / 128.0;
			_ = 0;
			s_quadMesh.uv = uv;
			int[] triangles = new int[6] { 0, 2, 1, 2, 3, 1 };
			s_quadMesh.triangles = triangles;
			s_quadMesh.RecalculateNormals();
			s_quadMesh.RecalculateBounds();
			goto IL_01cb;
		}

		[Token(Token = "0x60005B0")]
		[Address(RVA = "0x3DACF1C", Offset = "0x3DACF1C", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0017;\nL_0017:\n\tv52 = UnityEngine.Object::op_Inequality(assets, 0);\n\tv61 = ~v52;\n\tv62 = ~v61;\nL_FFFFFFFF:\n\tv142 = 0;\n\tif (v62) goto L_FFFFFFFF;\n\tgoto L_0023;\nL_0023:\n\tv104 = UnityEngine.Object::op_Inequality(v142, 0);\n\tv137 = v104 == 0;\n\tif (v137) goto L_0060;\n\tv152 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v152, v142);\nL_FFFFFFFF:\n\tv132 = v152;\n\tgoto L_006F;\nL_FFFFFFFF:\n\tv142 = assets.ParticleMaterial;\n\tgoto L_0023;\nL_0060:\n\tv163 = UnityEngine.Shader::Find(\"Universal Render Pipeline/Unlit\");\n\tv212 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v212, v163);\nL_FFFFFFFF:\n\tv132 = v212;\nL_006F:\n\tUnityEngine.Material::set_enableInstancing(v132, 1);\n\tgoto L_0077;\nL_0077:\n\tv225 = UnityEngine.Object::op_Inequality(assets, 0);\n\tv228 = ~v225;\n\tv229 = ~v228;\nL_FFFFFFFF:\n\tv274 = 0;\n\tif (v229) goto L_FFFFFFFF;\n\tgoto L_0083;\nL_0083:\n\tv258 = UnityEngine.Object::op_Inequality(v274, 0);\n\tv267 = ~v258;\n\tv268 = ~v267;\n\tif (v268) goto L_00AD;\nL_008F:\n\treturn v132;\nL_FFFFFFFF:\n\tv274 = assets.ParticleTexture;\n\tgoto L_0083;\nL_00AD:\n\tgoto L_00B4;\n\tgoto L_00C0;\nL_00C3:\n\tgoto L_00CA;\n\tgoto L_00DA;\nL_00B4:\n\tv301 = UnityEngine.Material::HasProperty(v132, v297.s_baseMapId);\n\tv304 = ~v301;\n\tif (v304) goto L_00C3;\nL_00C0:\n\tgoto L_00DA;\nL_00CA:\n\tv278 = UnityEngine.Material::HasProperty(v132, v281.s_mainTexId);\n\tv280 = ~v278;\n\tif (v280) goto L_008F;\nL_00DA:\n\tUnityEngine.Material::SetTexture(v132, v195.s_baseMapId, v274);\n\treturn v132;\n")]
		private static Material ResolveMaterial(SandRenderingAssetsSO assets)
		{
			bool flag = assets != null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			UnityEngine.Object obj = null;
			if (flag3)
			{
				obj = assets.ParticleMaterial;
			}
			Material material2;
			if (obj != null)
			{
				Material material = new Material((Material)obj);
				material2 = material;
			}
			else
			{
				Shader shader = Shader.Find("Universal Render Pipeline/Unlit");
				Material material3 = new Material(shader);
				material2 = material3;
			}
			material2.enableInstancing = true;
			bool flag4 = assets != null;
			bool flag5 = !flag4;
			bool flag6 = !flag5;
			UnityEngine.Object obj2 = null;
			if (flag6)
			{
				obj2 = assets.ParticleTexture;
			}
			if (!(obj2 != null) || (!material2.HasProperty(s_baseMapId) && !material2.HasProperty(s_mainTexId)))
			{
				return material2;
			}
			material2.SetTexture(s_baseMapId, (Texture)obj2);
			return material2;
		}

		[Token(Token = "0x60005B1")]
		[Address(RVA = "0x3DAD1E4", Offset = "0x3DAD1E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandPrototypeEntityFactory()
		{
		}

		[Token(Token = "0x60005B2")]
		[Address(RVA = "0x3DAD1EC", Offset = "0x3DAD1EC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv50 = UnityEngine.Shader::PropertyToID(\"_BaseMap\");\n\tv55.s_baseMapId = v50;\n\tv58 = UnityEngine.Shader::PropertyToID(\"_MainTex\");\n\tv62.s_mainTexId = v58;\n\treturn;\n")]
		static SandPrototypeEntityFactory()
		{
			int num = Shader.PropertyToID("_BaseMap");
			s_baseMapId = num;
			int num2 = Shader.PropertyToID("_MainTex");
			s_mainTexId = num2;
		}
	}
}
