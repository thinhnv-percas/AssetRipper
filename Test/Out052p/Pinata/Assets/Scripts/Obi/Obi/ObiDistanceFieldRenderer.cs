using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x74464C", Offset = "0x74464C")]
	[ExecuteInEditMode]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74464C", Offset = "0x74464C")]
	[Token(Token = "0x200003D")]
	public class ObiDistanceFieldRenderer : MonoBehaviour
	{
		[Token(Token = "0x20000B1")]
		public enum Axis
		{
			[Token(Token = "0x40002F6")]
			X = 0,
			[Token(Token = "0x40002F7")]
			Y = 1,
			[Token(Token = "0x40002F8")]
			Z = 2
		}

		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x18")]
		public Axis axis;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x745D90", Offset = "0x745D90")]
		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x1C")]
		public float slice;

		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x20")]
		public float maxDistance;

		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x28")]
		private ObiCollider unityCollider;

		[Token(Token = "0x40000D9")]
		[FieldOffset(Offset = "0x30")]
		private Material material;

		[Token(Token = "0x40000DA")]
		[FieldOffset(Offset = "0x38")]
		private Mesh planeMesh;

		[Token(Token = "0x40000DB")]
		[FieldOffset(Offset = "0x40")]
		private Texture2D cutawayTexture;

		[Token(Token = "0x40000DC")]
		[FieldOffset(Offset = "0x48")]
		private float sampleSize;

		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x4C")]
		private int sampleCount;

		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x50")]
		private Color boundsColor;

		[Token(Token = "0x60002D9")]
		[Address(RVA = "0xE447F4", Offset = "0xE447F4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ECF490]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024745]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.unityCollider = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Awake()
		{
			ObiCollider component = GetComponent<ObiCollider>();
			unityCollider = component;
		}

		[Token(Token = "0x60002DA")]
		[Address(RVA = "0xE4484C", Offset = "0xE4484C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE6B00]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024746]) = v38;\nL_0019:\n\tv45 = UnityEngine.Resources::Load(\"ObiMaterials/DistanceFieldRendering\");\n\tgoto L_002C;\n\tv53 = *([v49 @ X8_v7+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_002C;\n\tv65 = v49;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v65, v44, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002C:\n\tv64 = UnityEngine.Object::Instantiate(v45);\n\tthis.material = v64;\n\tUnityEngine.Object::set_hideFlags(v64, 0x3D);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnEnable()
		{
			Material original = Resources.Load<Material>("ObiMaterials/DistanceFieldRendering");
			(material = UnityEngine.Object.Instantiate(original)).hideFlags = HideFlags.HideAndDontSave;
		}

		[Token(Token = "0x60002DB")]
		[Address(RVA = "0xE448F8", Offset = "0xE448F8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiDistanceFieldRenderer::Cleanup(this);\n\treturn;\n")]
		public void OnDisable()
		{
			Cleanup();
		}

		[Token(Token = "0x60002DC")]
		[Address(RVA = "0xE448FC", Offset = "0xE448FC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EC9258]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024747]) = v38;\nL_001A:\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tUnityEngine.Object::DestroyImmediate(this.cutawayTexture);\n\tUnityEngine.Object::DestroyImmediate(this.planeMesh);\n\tUnityEngine.Object::DestroyImmediate(this.material);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Cleanup()
		{
			UnityEngine.Object.DestroyImmediate(cutawayTexture);
			UnityEngine.Object.DestroyImmediate(planeMesh);
			UnityEngine.Object.DestroyImmediate(material);
		}

		[Token(Token = "0x60002DD")]
		[Address(RVA = "0xE44980", Offset = "0xE44980", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EC2F38]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2024748]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this.cutawayTexture, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_0054;\n\tv65 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v65, this.sampleCount, this.sampleCount, 0xF, 0);\n\tthis.cutawayTexture = v65;\n\tUnityEngine.Texture::set_wrapMode(v65, 1);\n\tUnityEngine.Object::set_hideFlags(this.cutawayTexture, 0x3D);\n\treturn;\nL_0054:\n\tv82 = UnityEngine.Texture2D::Resize(this.cutawayTexture, this.sampleCount, this.sampleCount);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ResizeTexture()
		{
			if (cutawayTexture == null)
			{
				(cutawayTexture = new Texture2D(sampleCount, sampleCount, TextureFormat.RHalf, mipChain: false)).wrapMode = TextureWrapMode.Clamp;
				cutawayTexture.hideFlags = HideFlags.HideAndDontSave;
			}
			else
			{
				bool flag = cutawayTexture.Resize(sampleCount, sampleCount);
			}
		}

		[Token(Token = "0x60002DE")]
		[Address(RVA = "0xE44A84", Offset = "0xE44A84", Length = "0x48C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = &v19 @ stack_-10_v2;\n\tgoto L_0019;\n\tv30 = *([1ED0FF8]);\n\tv31 = *([v30 @ X8_v46]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, field, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2024749]) = v49;\nL_0019:\n\t*([v18 @ X29_v1-58]) = 0;\n\t*([v18 @ X29_v1-50]) = 0;\n\t*([v18 @ X29_v1-60]) = 0;\n\tgoto L_002D;\n\tv58 = *([v54 @ X0_v2+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tgoto L_002D;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v54, field, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_002D:\n\tv68 = UnityEngine.Object::op_Inequality(field, 0);\n\tv70 = v68 == 0;\n\tif (v70) goto L_01C3;\n\tgoto L_003F;\n\tv205 = *([v71 @ X0_v7+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tif (v207) goto L_003F;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v71, v66, v67, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_003F:\n\tv183 = UnityEngine.Object::op_Equality(this.planeMesh, 0);\n\tv186 = v183 == 0;\n\tif (v186) goto L_01C3;\n\tv305 = &v19 @ stack_-10_v2 - 0x60;\n\t*([v18 @ X29_v1-50]) = field.bounds.m_Extents.y;\n\t*([v18 @ X29_v1-60]) = field.bounds;\n\tv308 = 0x100E390(v305, 0, 0, v34, v35, v36, v37, v38, field.bounds, v40, v41, v42, v43, v44, v45, v46);\n\tthrow System.TypeLoadException;\n\tv368 = this.sampleSize;\n\tv366 = this.sampleCount;\n\tv423 = new UnityEngine.Mesh();\n\tUnityEngine.Mesh::.ctor(v423, 0);\n\tthis.planeMesh = v423;\n\tv428 = \"SzArrayNew\"(UnityEngine.Vector3[], 4, 0, v34, v35, v36, v37, v38, v307, v40, v41, v42, v43, v44, v45, v46);\n\tv149 = 0;\n\tv389 = 0x1586898(&v149 @ stack_-90_v3, 0, 0, v34, v35, v36, v37, v38, -0.5f, -0.5f, 0, v42, v43, v44, v45, v46);\n\tv430 = *([v428 @ X0_v21 (UnityEngine.Vector3[])+18]);\n\tv431 = v430 == 0;\n\tif (v431) goto L_01C4;\n\t*([v428 @ X0_v21 (UnityEngine.Vector3[])+20]) = 0;\n\t*([v428 @ X0_v21 (UnityEngine.Vector3[])+28]) = 0;\n\tv140 = 0;\n\tv439 = 0x1586898(&v140 @ stack_-A0_v4, 0, 0, v34, v35, v36, v37, v38, 0.5f, -0.5f, 0, v42, v43, v44, v45, v46);\n\tv526 = *([v428 @ X0_v21 (UnityEngine.Vector3[])+18]);\n\tv537 = v526 < 1;\n\tv489 = ~v537;\n\tv483 = v526 - 1;\n\tv471 = v483 == 0;\n\tv538 = ~v489;\n\tv441 = v538 | v471;\n\tif (v441) goto L_01C4;\n\t*([v428 @ X0_v21 (UnityEngine.Vector3[])+2C]) = 0;\n\t*([v428 @ X0_v21 (UnityEngine.Vector3[])+34]) = 0;\n\tv107 = 0;\n\tv519 = 0x1586898(&v107 @ stack_-B0_v4, 0, 0, v34, v35, v36, v37, v38, -0.5f, 0.5f, 0, v42, v43, v44, v45, v46);\n\tv527 = *([v428 @ X0_v21 (UnityEngine.Vector3[])+18]);\n\tv541 = v527 < 2;\n\tv490 = ~v541;\n\tv484 = v527 - 2;\n\tv472 = v484 == 0;\n\tv542 = ~v490;\n\tv442 = v542 | v472;\n\tif (v442) goto L_01C4;\n\t*([v428 @ X0_v21 (UnityEngine.Vector3[])+38]) = 0;\n\t*([v428 @ X0_v21 (UnityEngine.Vector3[])+3C]) = v544;\n\t*([v428 @ X0_v21 (UnityEngine.Vector3[])+40]) = 0;\n\tv98 = 0;\n\tv390 = 0x1586898(&v98 @ stack_-C0_v4, 0, 0, v34, v35, v36, v37, v38, 0.5f, 0.5f, 0, v42, v43, v44, v45, v46);\n\tv528 = *([v428 @ X0_v21 (UnityEngine.Vector3[])+18]);\n\tv546 = v528 < 3;\n\tv346 = ~v546;\n\tv343 = v528 - 3;\n\tv337 = v343 == 0;\n\tv547 = ~v346;\n\tv322 = v547 | v337;\n\tif (v322) goto L_01C4;\n\t*([v428 @ X0_v21 (UnityEngine.Vector3[])+44]) = 0;\n\t*([v428 @ X0_v21 (UnityEngine.Vector3[])+48]) = v548;\n\t*([v428 @ X0_v21 (UnityEngine.Vector3[])+4C]) = 0;\n\tv550 = v368 * v366;\n\tv551 = v307 / v550;\n\tv552 = 1f - v551;\n\tv161 = v552 * 0.5f;\n\tUnityEngine.Mesh::set_vertices(v423, v428, 0);\n\tv405 = this.planeMesh;\n\tv559 = \"SzArrayNew\"(UnityEngine.Vector2[], 4, 0, v34, v35, v36, v37, v38, v552, 0.5f, 0, v42, v43, v44, v45, v46);\n\tv560 = &v19 @ stack_-10_v2 - 0x38;\n\t*([v18 @ X29_v1-38]) = 0;\n\tv391 = 0x1588A6C(v560, 0, 0, v34, v35, v36, v37, v38, v161, v161, 0, v42, v43, v44, v45, v46);\n\tv529 = *([v559 @ X0_v35 (UnityEngine.Vector2[])+18]);\n\tv524 = v529 == 0;\n\tif (v524) goto L_01C4;\n\tv561 = *([v18 @ X29_v1-38]);\n\tv497 = *([v18 @ X29_v1-34]);\n\tv165 = 1f - v161;\n\t*([v559 @ X0_v35 (UnityEngine.Vector2[])+20]) = v561;\n\t*([v559 @ X0_v35 (UnityEngine.Vector2[])+24]) = v497;\n\tv95 = 0;\n\tv520 = 0x1588A6C(&v95 @ stack_-C8_v4, 0, 0, v34, v35, v36, v37, v38, v165, v161, 0, v42, v43, v44, v45, v46);\n\tv530 = *([v559 @ X0_v35 (UnityEngine.Vector2[])+18]);\n\tv563 = v530 < 1;\n\tv491 = ~v563;\n\tv485 = v530 - 1;\n\tv473 = v485 == 0;\n\tv564 = ~v491;\n\tv443 = v564 | v473;\n\tif (v443) goto L_01C4;\n\t*([v559 @ X0_v35 (UnityEngine.Vector2[])+28]) = 0;\n\t*([v559 @ X0_v35 (UnityEngine.Vector2[])+2C]) = v566;\n\tv92 = 0;\n\tv521 = 0x1588A6C(&v92 @ stack_-D0_v4, 0, 0, v34, v35, v36, v37, v38, v161, v165, 0, v42, v43, v44, v45, v46);\n\tv531 = *([v559 @ X0_v35 (UnityEngine.Vector2[])+18]);\n\tv568 = v531 < 2;\n\tv492 = ~v568;\n\tv486 = v531 - 2;\n\tv474 = v486 == 0;\n\tv569 = ~v492;\n\tv444 = v569 | v474;\n\tif (v444) goto L_01C4;\n\t*([v559 @ X0_v35 (UnityEngine.Vector2[])+30]) = 0;\n\t*([v559 @ X0_v35 (UnityEngine.Vector2[])+34]) = v571;\n\tv89 = 0;\n\tv392 = 0x1588A6C(&v89 @ stack_-D8_v4, 0, 0, v34, v35, v36, v37, v38, v165, v165, 0, v42, v43, v44, v45, v46);\n\tv532 = *([v559 @ X0_v35 (UnityEngine.Vector2[])+18]);\n\tv573 = v532 < 3;\n\tv347 = ~v573;\n\tv344 = v532 - 3;\n\tv338 = v344 == 0;\n\tv574 = ~v347;\n\tv323 = v574 | v338;\n\tif (v323) goto L_01C4;\n\t*([v559 @ X0_v35 (UnityEngine.Vector2[])+38]) = 0;\n\t*([v559 @ X0_v35 (UnityEngine.Vector2[])+3C]) = v575;\n\tUnityEngine.Mesh::set_uv(v405, v559, 0);\n\tv406 = this.planeMesh;\n\tv579 = \"SzArrayNew\"(UnityEngine.Vector3[], 4, 0, v34, v35, v36, v37, v38, v165, v165, 0, v42, v43, v44, v45, v46);\n\tgoto L_0146;\n\tv585 = *([v412 @ X8_v33+E0]);\n\tv586 = v585 == 0;\n\tv587 = ~v586;\n\tif (v587) goto L_0146;\n\tv593 = v412;\n\tv589 = \"il2cpp_codegen_runtime_class_init\"(v593, v385, v378, v34, v35, v36, v37, v38, v373, v357, v361, v42, v43, v44, v45, v46);\nL_0146:\n\tv592 = UnityEngine.Vector3::get_forward(0);\n\tv86 = v592;\n\tv374 = UnityEngine.Vector3::op_UnaryNegation(v86, 0);\n\tv358 = v374.y;\n\tv362 = v374.z;\n\tv533 = *([v579 @ X0_v46 (UnityEngine.Vector3[])+18]);\n\tv525 = v533 == 0;\n\tif (v525) goto L_01C4;\n\t*([v579 @ X0_v46 (UnityEngine.Vector3[])+20]) = v374;\n\t*([v579 @ X0_v46 (UnityEngine.Vector3[])+24]) = v358;\n\t*([v579 @ X0_v46 (UnityEngine.Vector3[])+28]) = v362;\n\tv597 = UnityEngine.Vector3::get_forward(0);\n\tv83 = v597;\n\tv511 = UnityEngine.Vector3::op_UnaryNegation(v83, 0);\n\tv503 = v511.y;\n\tv506 = v511.z;\n\tv534 = *([v579 @ X0_v46 (UnityEngine.Vector3[])+18]);\n\tv600 = v534 < 1;\n\tv493 = ~v600;\n\tv487 = v534 - 1;\n\tv475 = v487 == 0;\n\tv601 = ~v493;\n\tv445 = v601 | v475;\n\tif (v445) goto L_01C4;\n\t*([v579 @ X0_v46 (UnityEngine.Vector3[])+2C]) = v511;\n\t*([v579 @ X0_v46 (UnityEngine.Vector3[])+30]) = v503;\n\t*([v579 @ X0_v46 (UnityEngine.Vector3[])+34]) = v506;\n\tv603 = UnityEngine.Vector3::get_forward(0);\n\tv80 = v603;\n\tv512 = UnityEngine.Vector3::op_UnaryNegation(v80, 0);\n\tv504 = v512.y;\n\tv507 = v512.z;\n\tv535 = *([v579 @ X0_v46 (UnityEngine.Vector3[])+18]);\n\tv606 = v535 < 2;\n\tv494 = ~v606;\n\tv488 = v535 - 2;\n\tv476 = v488 == 0;\n\tv607 = ~v494;\n\tv446 = v607 | v476;\n\tif (v446) goto L_01C4;\n\t*([v579 @ X0_v46 (UnityEngine.Vector3[])+38]) = v512;\n\t*([v579 @ X0_v46 (UnityEngine.Vector3[])+3C]) = v504;\n\t*([v579 @ X0_v46 (UnityEngine.Vector3[])+40]) = v507;\n\tv609 = UnityEngine.Vector3::get_forward(0);\n\tv77 = v609;\n\tv174 = UnityEngine.Vector3::op_UnaryNegation(v77, 0);\n\tv155 = v174.y;\n\tv157 = v174.z;\n\tv413 = *([v579 @ X0_v46 (UnityEngine.Vector3[])+18]);\n\tv612 = v413 < 3;\n\tv137 = ~v612;\n\tv134 = v413 - 3;\n\tv128 = v134 == 0;\n\tv613 = ~v137;\n\tv113 = v613 | v128;\n\tif (v113) goto L_01C4;\n\t*([v579 @ X0_v46 (UnityEngine.Vector3[])+44]) = v174;\n\t*([v579 @ X0_v46 (UnityEngine.Vector3[])+48]) = v155;\n\t*([v579 @ X0_v46 (UnityEngine.Vector3[])+4C]) = v157;\n\tUnityEngine.Mesh::set_normals(v406, v579, 0);\n\tv188 = this.planeMesh;\n\tv395 = \"SzArrayNew\"(System.Int32[], 6, 0, v34, v35, v36, v37, v38, v174, v155, v157, v42, v43, v44, v45, v46);\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v395, Il2CppFieldInfo, 0);\n\tUnityEngine.Mesh::set_triangles(v188, v395, 0);\nL_01C3:\n\treturn;\nL_01C4:\n\tv536 = new System.IndexOutOfRangeException();\n\tthrow v536;\n\tthrow System.NullReferenceException;\n// 243 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CreatePlaneMesh(ObiDistanceField field)
		{
			//IL_0079: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			if (field != null && planeMesh == null)
			{
				object obj3 = (long)(IntPtr)obj2 - 96L;
				_ = field.bounds.m_Extents.y;
				_ = field.bounds;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E390 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x2C8)");
				throw new TypeLoadException();
			}
		}

		[Token(Token = "0x60002DF")]
		[Address(RVA = "0xE44F10", Offset = "0xE44F10", Length = "0x3DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv50 = *([1EDFA80]);\n\tv51 = *([v50 @ X8_v39]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, field, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv69 = 0 | 1;\n\t*([202474A]) = v69;\nL_0030:\n\tgoto L_0039;\n\tv83 = *([v79 @ X0_v2+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tgoto L_0039;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v79, field, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\nL_0039:\n\tv93 = UnityEngine.Object::op_Equality(field, 0);\n\tv95 = v93 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_0179;\n\tv243 = field.bounds;\n\tthis.sampleSize = field.minNodeSize;\n\tv245 = 0x100E390(&v243 @ V0_v4 (UnityEngine.Bounds), 0, 0, v54, v55, v56, v57, v58, field.bounds, v60, v61, v62, v63, v64, v65, v66);\n\tthrow System.TypeLoadException;\n\tv454 = this.sampleSize;\n\tv457 = v243 / v454;\n\tv459 = v457 + 1;\n\tthis.sampleCount = v459;\n\tObi.ObiDistanceFieldRenderer::CreatePlaneMesh(this, field, 0);\n\tObi.ObiDistanceFieldRenderer::ResizeTexture(this, field);\n\tv461 = this.slice;\n\t*([v38 @ X29_v1-44]) = v461;\n\tv464 = this.sampleSize;\n\tv465 = this.sampleCount;\n\tv466 = 0x100E244(&v243 @ V0_v4 (UnityEngine.Bounds), 0, 0, v54, v55, v56, v57, v58, v461, v454, v61, v62, v63, v64, v65, v66);\n\tv472 = 0x100E250(&v243 @ V0_v4 (UnityEngine.Bounds), 0, 0, v54, v55, v56, v57, v58, v461, v454, v61, v62, v63, v64, v65, v66);\n\tgoto L_007D;\n\tv481 = *([v477 @ X0_v21+E0]);\n\tv482 = v481 == 0;\n\tv483 = ~v482;\n\tif (v483) goto L_007D;\n\tv485 = \"il2cpp_codegen_runtime_class_init\"(v477, v468, v450, v54, v55, v56, v57, v58, v461, v454, v61, v62, v63, v64, v65, v66);\nL_007D:\n\t// 125 MakeStruct v166 @ AGGE45098_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v461 @ V0_v6 (System.Single), v454 @ V1_v4 (System.Single), v61 @ V2 (System.Single)\n\t// 126 MakeStruct v163 @ AGGE45098_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v461 @ V0_v6 (System.Single), v454 @ V1_v4 (System.Single), v61 @ V2 (System.Single)\n\tv495 = UnityEngine.Vector3::op_Subtraction(v166, v163, 0);\n\tv498 = this.sampleCount;\n\tv510 = v498 <= 0;\n\tif (v510) goto L_015F;\n\tv513 = *([v38 @ X29_v1-44]);\n\tv271 = this + 0x40;\n\tv516 = v513 * v465;\n\tv309 = v516 * v464;\nL_00A7:\n\tv601 = v588 < 1;\n\tif (v601) goto L_0151;\nL_00AF:\n\tgoto L_00B6;\n\tv670 = *([v666 @ X0_v29+E0]);\n\tv671 = v670 == 0;\n\tv672 = ~v671;\n\tgoto L_00B6;\n\tv674 = \"il2cpp_codegen_runtime_class_init\"(v666, v662, v328, v249, v55, v56, v57, v58, v661, v660, v656, v655, v654, v653, v65, v66);\nL_00B6:\n\tv678 = UnityEngine.Vector3::get_zero(0);\n\tv679 = v678.y;\n\tv680 = v678.z;\n\tv682 = this.axis;\n\tv687 = v682 == 2;\n\tif (v687) goto L_00DB;\n\tv696 = v682 == 1;\n\tif (v696) goto L_00E2;\n\tv708 = v682 == 0;\n\tv709 = ~v708;\n\tif (v709) goto L_00F1;\n\tv738 = this.sampleSize;\n\tv730 = v738 * v269;\n\tv728 = v738 * v338;\n\tgoto L_00E9;\nL_00DB:\n\tv701 = this.sampleSize;\n\tv705 = v701 * v338;\n\tv706 = v701 * v269;\n\tgoto L_00E9;\nL_00E2:\n\tv710 = this.sampleSize;\n\tv714 = v710 * v338;\n\tv715 = v710 * v269;\nL_00E9:\n\tv737 = 0x1586898(v733, 0, v328, v249, v55, v56, v57, v58, v731, v729, v727, v655, v654, v653, v65, v66);\nL_00F1:\n\tgoto L_00FE;\n\tv753 = *([v746 @ X0_v35+E0]);\n\tv754 = v753 == 0;\n\tv755 = ~v754;\n\tif (v755) goto L_00FE;\n\tv757 = \"il2cpp_codegen_runtime_class_init\"(v746, v743, v328, v249, v55, v56, v57, v58, v742, v741, v740, v655, v654, v653, v65, v66);\nL_00FE:\n\tv261 = v495;\n\t// 255 MakeStruct v259 @ AGGE451C0_1_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v267 @ stack_-E0_v11 (UnityEngine.Vector3), v679 @ V1_v12 (System.Single), v680 @ V2_v10 (System.Single)\n\tv766 = UnityEngine.Vector3::op_Addition(v261, v259, 0);\n\tgoto L_0114;\n\tv775 = *([v769 @ X0_v38+E0]);\n\tv776 = v775 == 0;\n\tv777 = ~v776;\n\tif (v777) goto L_0114;\n\tv779 = \"il2cpp_codegen_runtime_class_init\"(v769, v743, v328, v249, v55, v56, v57, v58, v766, v767, v768, v763, v764, v297, v65, v66);\nL_0114:\n\tv257 = v766;\n\tv786 = UnityEngine.Vector4::op_Implicit(v257, 0);\n\tv787 = v786.y;\n\tv788 = v786.z;\n\tv790 = field.oniDistanceField;\n\tv792 = Oni::SampleDistanceField(v790, v786, v787, v788, 0);\n\tv305 = this.maxDistance;\n\tgoto L_0128;\n\tv797 = *([v793 @ X0_v42+E0]);\n\tv798 = v797 == 0;\n\tv799 = ~v798;\n\tif (v799) goto L_0128;\n\tv801 = \"il2cpp_codegen_runtime_class_init\"(v793, v791, v328, v249, v55, v56, v57, v58, v792, v787, v788, v789, v764, v297, v65, v66);\nL_0128:\n\tv803 = -v305;\n\tv325 = Obi.ObiUtils::Remap(v792, v803, v305, 0, 1f, 0);\n\tv255 = this.cutawayTexture;\n\tv253 = 0;\n\tv332 = 0x10105A8(&v253 @ stack_-F0_v8, 0, v328, v249, v55, v56, v57, v58, v325, 0, 0, 0, 1f, v680, v65, v66);\n\t// 321 MakeStruct v605 @ AGGE4527C_3_v8 (UnityEngine.Color), typeof(UnityEngine.Color), 0, v808 @ stack_-EC, 0, v809 @ stack_-E4 (System.Single)\n\tUnityEngine.Texture2D::SetPixel(v255, v338, v269, v605, 0);\n\tv633 = this.sampleCount;\n\tv607 = v269 + 1;\n\tv609 = v607 < v633;\n\tif (v609) goto L_00AF;\nL_0151:\n\tv590 = v338 + 1;\n\tv543 = v590 < v589;\n\tif (v543) goto L_00A7;\n\tgoto L_0160;\nL_015F:\n\tv517 = this + 0x40;\nL_0160:\n\tv214 = *([v130 @ X25_v5]);\n\tUnityEngine.Texture2D::Apply(v214, 0);\nL_0179:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 253 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RefreshCutawayTexture(ObiDistanceField field)
		{
			if (!(field == null))
			{
				Bounds bounds = field.bounds;
				sampleSize = field.EffectiveSampleSize;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E390 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x2C8)");
				throw new TypeLoadException();
			}
		}

		[Token(Token = "0x60002E0")]
		[Address(RVA = "0xE452EC", Offset = "0xE452EC", Length = "0x424")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = &v35 @ stack_-10_v2;\n\tgoto L_0023;\n\tv48 = *([1EF7E28]);\n\tv49 = *([v48 @ X8_v47]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, field, matrix, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv66 = 0 | 1;\n\t*([202474B]) = v66;\nL_0023:\n\t*([v34 @ X29_v1-88]) = 0;\n\t*([v34 @ X29_v1-90]) = 0;\n\t*([v34 @ X29_v1-A8]) = 0;\n\t*([v34 @ X29_v1-A0]) = 0;\n\t*([v34 @ X29_v1-B0]) = 0;\n\t*([v34 @ X29_v1-B8]) = 0;\n\t*([v34 @ X29_v1-C0]) = 0;\n\tgoto L_0039;\n\tv73 = *([v69 @ X0_v2+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tgoto L_0039;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v69, field, matrix, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\nL_0039:\n\tv83 = UnityEngine.Object::op_Equality(field, 0);\n\tv85 = v83 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_0180;\n\tObi.ObiDistanceFieldRenderer::RefreshCutawayTexture(this, field);\n\tUnityEngine.Material::set_mainTexture(this.material, this.cutawayTexture);\n\tv414 = UnityEngine.Material::SetPass(this.material, 0);\n\tgoto L_005A;\n\tv420 = *([v416 @ X0_v16+E0]);\n\tv421 = v420 == 0;\n\tv422 = ~v421;\n\tif (v422) goto L_005A;\n\tv424 = \"il2cpp_codegen_runtime_class_init\"(v416, v408, v407, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\nL_005A:\n\tv428 = UnityEngine.Quaternion::get_identity();\n\tgoto L_006F;\n\tv436 = *([v432 @ X0_v19+E0]);\n\tv437 = v436 == 0;\n\tv438 = ~v437;\n\tif (v438) goto L_006F;\n\tv440 = \"il2cpp_codegen_runtime_class_init\"(v432, v408, v407, methodInfo, v52, v53, v54, v55, v428, v429, v430, v403, v60, v61, v62, v63);\nL_006F:\n\tv406 = UnityEngine.Vector3::get_zero();\n\t*([v34 @ X29_v1-90]) = v406;\n\t*([v34 @ X29_v1-8C]) = v406.y;\n\t*([v34 @ X29_v1-88]) = v406.z;\n\tv443 = &v35 @ stack_-10_v2 - 0xB0;\n\t*([v34 @ X29_v1-A0]) = field.bounds.m_Extents.y;\n\t*([v34 @ X29_v1-B0]) = field.bounds;\n\tv446 = 0x100E390(v443, 0, 0, methodInfo, v52, v53, v54, v55, field.bounds, v406.y, v406.z, v428.w, v60, v61, v62, v63);\n\t*([v34 @ X29_v1-C0]) = field.bounds;\n\t*([v34 @ X29_v1-BC]) = v406.y;\n\t*([v34 @ X29_v1-B8]) = v406.z;\n\tthrow System.TypeLoadException;\n\tthrow System.TypeLoadException;\n\tv466 = v455 != 1;\n\tif (v466) goto L_00C0;\n\tgoto L_FFFFFFFF;\n\tv486 = *([v471 @ X0_v58+E0]);\n\tv487 = v486 == 0;\n\tv488 = ~v487;\n\tif (v488) goto L_FFFFFFFF;\n\tv490 = \"il2cpp_codegen_runtime_class_init\"(v471, v452, v453, methodInfo, v52, v53, v54, v55, v445, v405, v404, v403, v60, v61, v62, v63);\n\tgoto L_00B6;\n\tgoto L_FFFFFFFF;\n\tv476 = *([v467 @ X0_v55+E0]);\n\tv477 = v476 == 0;\n\tv478 = ~v477;\n\tif (v478) goto L_FFFFFFFF;\n\tv480 = \"il2cpp_codegen_runtime_class_init\"(v467, v452, v453, methodInfo, v52, v53, v54, v55, v445, v405, v404, v403, v60, v61, v62, v63);\nL_00B6:\n\tv514 = UnityEngine.Quaternion::Euler(v527, v526, 0, 0);\n\tv512 = v514.y;\n\tv510 = v514.z;\n\tv508 = v514.w;\n\t*([v34 @ X29_v1-38]) = v512;\n\t*([v34 @ X29_v1-34]) = v514;\n\tgoto L_00C2;\nL_00C0:\n\t*([v34 @ X29_v1-38]) = v429;\n\t*([v34 @ X29_v1-34]) = v428;\nL_00C2:\n\tv521 = field.bounds.m_Extents.y;\n\tv522 = &v35 @ stack_-10_v2 - 0xB0;\n\t*([v34 @ X29_v1-A0]) = v521;\n\tv524 = field.bounds;\n\t*([v34 @ X29_v1-B0]) = v524;\n\tv525 = 0x100E244(v522, 0, 0, methodInfo, v52, v53, v54, v55, v524, v511, v509, v507, v60, v61, v62, v63);\n\tv531 = *([v34 @ X29_v1-90]);\n\tv532 = *([v34 @ X29_v1-8C]);\n\tv533 = *([v34 @ X29_v1-88]);\n\tv247 = this.slice;\n\tgoto L_00DB;\n\tv540 = *([v530 @ X0_v31+E0]);\n\tv541 = v540 == 0;\n\tv542 = ~v541;\n\tgoto L_00DB;\n\tv544 = \"il2cpp_codegen_runtime_class_init\"(v530, v523, v453, methodInfo, v52, v53, v54, v55, v524, v511, v509, v507, v60, v61, v62, v63);\nL_00DB:\n\tv548 = v247 + -0.5f;\n\t// 224 MakeStruct v204 @ AGGE45564_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v531 @ V9_v5, v532 @ V15_v3, v533 @ V8_v5\n\tv553 = UnityEngine.Vector3::op_Multiply(v204, v548, 0);\n\tv554 = v553.y;\n\tv555 = v553.z;\n\t// 235 MakeStruct v197 @ AGGE45584_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v524 @ V0_v7 (UnityEngine.Bounds), v511 @ V1_v5 (System.Single), v509 @ V2_v5 (System.Single)\n\tv194 = v553;\n\tv563 = UnityEngine.Vector3::op_Addition(v197, v194, 0);\n\tv567 = UnityEngine.Vector3::get_one(0);\n\tv568 = v567.y;\n\tv569 = v567.z;\n\tv570 = field.bounds.m_Extents.y;\n\tv572 = &v35 @ stack_-10_v2 - 0xB0;\n\t*([v34 @ X29_v1-A0]) = v570;\n\tv574 = field.bounds;\n\t*([v34 @ X29_v1-B0]) = v574;\n\tv577 = 0x100E390(v572, 0, 0, methodInfo, v52, v53, v54, v55, v574, v568, v569, v553, v554, v555, v62, v63);\n\t*([v34 @ X29_v1-C0]) = v574;\n\t*([v34 @ X29_v1-BC]) = v568;\n\t*([v34 @ X29_v1-B8]) = v569;\n\tthrow System.TypeLoadException;\n\tgoto L_0120;\n\tv596 = *([v592 @ X0_v41+E0]);\n\tv597 = v596 == 0;\n\tv598 = ~v597;\n\tif (v598) goto L_0120;\n\tv600 = \"il2cpp_codegen_runtime_class_init\"(v592, v579, v580, methodInfo, v52, v53, v54, v55, v587, v588, v589, v582, v557, v558, v62, v63);\nL_0120:\n\tv202 = *([v34 @ X29_v1-38]);\n\tv603 = *([v34 @ X29_v1-34]);\n\tv177 = v563;\n\t// 301 MakeStruct v174 @ AGGE45648_1_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v603 @ V3_v8, v202 @ V4_v3, v215 @ stack_-214_v2 (System.Single), v245 @ V11_v5 (System.Single)\n\tv609 = UnityEngine.Matrix4x4::TRS(v177, v174, v587, 0);\n\tv273 = this.planeMesh;\n\tv619 = matrix.m00;\n\tv620 = *([v34 @ X29_v1-100]);\n\tv622 = UnityEngine.Matrix4x4::op_Multiply(&v619 @ V0_v21 (System.Single), &v620 @ V1_v15, 0);\n\tv147 = v622.m00;\n\tgoto L_016C;\n\tv629 = *([v625 @ X0_v47+E0]);\n\tv630 = v629 == 0;\n\tv631 = ~v630;\n\tif (v631) goto L_016C;\n\tv633 = \"il2cpp_codegen_runtime_class_init\"(v625, v616, v617, methodInfo, v52, v53, v54, v55, v619, v620, v611, v621, v202, v200, v189, v63);\nL_016C:\n\tUnityEngine.Graphics::DrawMeshNow(v273, &v147 @ stack_-150_v2 (System.Single), 0);\nL_0180:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 248 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DrawCutawayPlane(ObiDistanceField field, Matrix4x4 matrix)
		{
			//IL_00c5: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			if (!(field == null))
			{
				RefreshCutawayTexture(field);
				material.mainTexture = cutawayTexture;
				bool flag = material.SetPass(0);
				Quaternion identity = Quaternion.identity;
				Vector3 zero = Vector3.zero;
				_ = zero.y;
				_ = zero.z;
				object obj3 = (long)(IntPtr)obj2 - 176L;
				_ = field.bounds.m_Extents.y;
				_ = field.bounds;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E390 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x2C8)");
				_ = field.bounds;
				_ = zero.y;
				_ = zero.z;
				throw new TypeLoadException();
			}
		}

		[Token(Token = "0x60002E1")]
		[Address(RVA = "0xE45710", Offset = "0xE45710", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = &v17 @ stack_-10_v2;\n\tgoto L_0019;\n\tv26 = *([1EDE2C0]);\n\tv27 = *([v26 @ X8_v26]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202474C]) = v46;\nL_0019:\n\t*([v16 @ X29_v1-48]) = 0;\n\t*([v16 @ X29_v1-40]) = 0;\n\t*([v16 @ X29_v1-50]) = 0;\n\tgoto L_002A;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002A;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_002A:\n\tv64 = UnityEngine.Object::op_Inequality(this.unityCollider, 0);\n\tv66 = v64 == 0;\n\tif (v66) goto L_00BD;\n\tv67 = this.unityCollider;\n\tgoto L_003F;\n\tv333 = *([v194 @ X0_v11+E0]);\n\tv334 = v333 == 0;\n\tv335 = ~v334;\n\tif (v335) goto L_003F;\n\tv337 = \"il2cpp_codegen_runtime_class_init\"(v194, v62, v63, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_003F:\n\tv170 = UnityEngine.Object::op_Inequality(v67.distanceField, 0);\n\tv174 = v170 == 0;\n\tif (v174) goto L_00BD;\n\tv247 = this.unityCollider;\n\tv248 = v247.distanceField;\n\tv175 = v248.nodes == 0;\n\tif (v175) goto L_00BD;\n\tgoto L_005A;\n\tv349 = *([v345 @ X0_v15+E0]);\n\tv350 = v349 == 0;\n\tv351 = ~v350;\n\tif (v351) goto L_005A;\n\tv353 = \"il2cpp_codegen_runtime_class_init\"(v345, v166, v162, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_005A:\n\tv171 = UnityEngine.Object::op_Inequality(this.material, 0);\n\tv176 = v171 == 0;\n\tif (v176) goto L_00BD;\n\tv249 = this.unityCollider;\n\tv342 = UnityEngine.Component::get_transform(this);\n\tv360 = UnityEngine.Transform::get_localToWorldMatrix(v342);\n\tv154 = v360.m00;\n\tObi.ObiDistanceFieldRenderer::DrawCutawayPlane(this, v249.distanceField, &v154 @ stack_-A0_v4 (System.Single));\n\t// 139 MakeStruct v86 @ AGGE45868_0_v4 (UnityEngine.Color), typeof(UnityEngine.Color), this.boundsColor (UnityEngine.Color), this.boundsColor.g (System.Single), this.boundsColor.b (System.Single), this.boundsColor.a (System.Single)\n\tUnityEngine.Gizmos::set_color(v86);\n\tv250 = this.unityCollider;\n\tv251 = v250.distanceField;\n\tv366 = &v17 @ stack_-10_v2 - 0x50;\n\t*([v16 @ X29_v1-40]) = v251.bounds.m_Extents.y;\n\t*([v16 @ X29_v1-50]) = v251.bounds;\n\tv238 = 0x100E244(v366, 0, &v154 @ stack_-A0_v4 (System.Single), v31, v32, v33, v34, v35, v251.bounds, this.boundsColor.g, this.boundsColor.b, this.boundsColor.a, v40, v41, v42, v43);\n\tv252 = this.unityCollider;\n\tv178 = v252.distanceField;\n\tv367 = &v17 @ stack_-10_v2 - 0x50;\n\t*([v16 @ X29_v1-40]) = v178.bounds.m_Extents.y;\n\t*([v16 @ X29_v1-50]) = v178.bounds;\n\tv369 = 0x100E390(v367, 0, &v154 @ stack_-A0_v4 (System.Single), v31, v32, v33, v34, v35, v178.bounds, this.boundsColor.g, this.boundsColor.b, this.boundsColor.a, v40, v41, v42, v43);\n\t// 177 MakeStruct v73 @ AGGE458EC_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v251.bounds (UnityEngine.Bounds), this.boundsColor.g (System.Single), this.boundsColor.b (System.Single)\n\t// 178 MakeStruct v70 @ AGGE458EC_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v178.bounds (UnityEngine.Bounds), this.boundsColor.g (System.Single), this.boundsColor.b (System.Single)\n\tUnityEngine.Gizmos::DrawWireCube(v73, v70);\nL_00BD:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 126 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnDrawGizmos()
		{
			//IL_013e: Expected O, but got Ref
			//IL_01cc: Expected O, but got I
			//IL_0224: Expected O, but got I
			//IL_025e: Expected F4, but got O
			//IL_0298: Expected F4, but got O
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			if (!(unityCollider != null))
			{
				return;
			}
			ObiCollider obiCollider = unityCollider;
			if (obiCollider.distanceField != null)
			{
				ObiCollider obiCollider2 = unityCollider;
				ObiDistanceField distanceField = obiCollider2.distanceField;
				if (distanceField.nodes != null && material != null)
				{
					ObiCollider obiCollider3 = unityCollider;
					Transform transform = base.transform;
					float m = transform.localToWorldMatrix.m00;
					DrawCutawayPlane(obiCollider3.distanceField, (Matrix4x4)(&m));
					Color color = default(Color);
					color.r = boundsColor.r;
					color.g = boundsColor.g;
					color.b = boundsColor.b;
					color.a = boundsColor.a;
					Gizmos.color = color;
					ObiCollider obiCollider4 = unityCollider;
					ObiDistanceField distanceField2 = obiCollider4.distanceField;
					object obj3 = (long)(IntPtr)obj2 - 80L;
					_ = distanceField2.bounds.m_Extents.y;
					_ = distanceField2.bounds;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E244 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x17C)");
					ObiCollider obiCollider5 = unityCollider;
					ObiDistanceField distanceField3 = obiCollider5.distanceField;
					object obj4 = (long)(IntPtr)obj2 - 80L;
					_ = distanceField3.bounds.m_Extents.y;
					_ = distanceField3.bounds;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E390 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x2C8)");
					Vector3 center = default(Vector3);
					center.x = (float)distanceField2.bounds;
					center.y = boundsColor.g;
					center.z = boundsColor.b;
					Vector3 size = default(Vector3);
					size.x = (float)distanceField3.bounds;
					size.y = boundsColor.g;
					size.z = boundsColor.b;
					Gizmos.DrawWireCube(center, size);
				}
			}
		}

		[Token(Token = "0x60002E2")]
		[Address(RVA = "0xE45914", Offset = "0xE45914", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.slice = 1f;\n\tv16 = 0;\n\tv20 = 0x101059C(&v16 @ stack_-30_v1 (System.Single), 0, v21, v22, v23, v24, v25, v26, 1f, 1f, 1f, 0.5f, v27, v28, v29, v30);\n\tthis.boundsColor.r = 0f;\n\tthis.boundsColor.g = v33;\n\tthis.boundsColor.a = v35;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiDistanceFieldRenderer()
		{
			//IL_0043: Expected F4, but got O
			base._002Ector();
			slice = 1f;
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			boundsColor.r = 0f;
			object obj = default(object);
			boundsColor.g = (float)obj;
			float a = default(float);
			boundsColor.a = a;
		}
	}
}
