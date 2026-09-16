using System;
using System.Collections.Generic;
using System.Globalization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spine.Unity.Examples
{
	[RequireComponent(typeof(SkeletonRenderer))]
	[Token(Token = "0x200004B")]
	public class SkeletonGhost : MonoBehaviour
	{
		[Token(Token = "0x4000181")]
		private const HideFlags GhostHideFlags = HideFlags.HideInHierarchy;

		[Token(Token = "0x4000182")]
		private const string GhostingShaderName = "Spine/Special/SkeletonGhost";

		[Header("Animation")]
		[Token(Token = "0x4000183")]
		[FieldOffset(Offset = "0x20")]
		public bool ghostingEnabled;

		[FormerlySerializedAs("spawnRate")]
		[Tooltip("The time between invididual ghost pieces being spawned.")]
		[Token(Token = "0x4000184")]
		[FieldOffset(Offset = "0x24")]
		public float spawnInterval;

		[Tooltip("Maximum number of ghosts that can exist at a time. If the fade speed is not fast enough, the oldest ghost will immediately disappear to enforce the maximum number.")]
		[Token(Token = "0x4000185")]
		[FieldOffset(Offset = "0x28")]
		public int maximumGhosts;

		[Token(Token = "0x4000186")]
		[FieldOffset(Offset = "0x2C")]
		public float fadeSpeed;

		[Header("Rendering")]
		[Token(Token = "0x4000187")]
		[FieldOffset(Offset = "0x30")]
		public Shader ghostShader;

		[Token(Token = "0x4000188")]
		[FieldOffset(Offset = "0x38")]
		public Color32 color;

		[Tooltip("Remember to set color alpha to 0 if Additive is true")]
		[Token(Token = "0x4000189")]
		[FieldOffset(Offset = "0x3C")]
		public bool additive;

		[Tooltip("0 is Color and Alpha, 1 is Alpha only.")]
		[Range(0f, 1f)]
		[Token(Token = "0x400018A")]
		[FieldOffset(Offset = "0x40")]
		public float textureFade;

		[Header("Sorting")]
		[Token(Token = "0x400018B")]
		[FieldOffset(Offset = "0x44")]
		public bool sortWithDistanceOnly;

		[Token(Token = "0x400018C")]
		[FieldOffset(Offset = "0x48")]
		public float zOffset;

		[Token(Token = "0x400018D")]
		[FieldOffset(Offset = "0x4C")]
		private float nextSpawnTime;

		[Token(Token = "0x400018E")]
		[FieldOffset(Offset = "0x50")]
		private SkeletonGhostRenderer[] pool;

		[Token(Token = "0x400018F")]
		[FieldOffset(Offset = "0x58")]
		private int poolIndex;

		[Token(Token = "0x4000190")]
		[FieldOffset(Offset = "0x60")]
		private SkeletonRenderer skeletonRenderer;

		[Token(Token = "0x4000191")]
		[FieldOffset(Offset = "0x68")]
		private MeshRenderer meshRenderer;

		[Token(Token = "0x4000192")]
		[FieldOffset(Offset = "0x70")]
		private MeshFilter meshFilter;

		[Token(Token = "0x4000193")]
		[FieldOffset(Offset = "0x78")]
		private readonly Dictionary<Material, Material> materialTable;

		[Token(Token = "0x6000133")]
		[Address(RVA = "0x1515574", Offset = "0x1515574", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.Examples.SkeletonGhost::Initialize(this, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Initialize(overwrite: false);
		}

		[Token(Token = "0x6000134")]
		[Address(RVA = "0x151557C", Offset = "0x151557C", Length = "0x414")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0045;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv70 = Il2CppMethodInfo;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv160 = Il2CppMethodInfo;\n\tv161 = \"il2cpp_codegen_initialize_runtime_metadata\"(v160, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv260 = UnityEngine.GameObject;\n\tv261 = \"il2cpp_codegen_initialize_runtime_metadata\"(v260, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv276 = Spine.Unity.IAnimationStateComponent;\n\tv277 = \"il2cpp_codegen_initialize_runtime_metadata\"(v276, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv284 = UnityEngine.Object;\n\tv285 = \"il2cpp_codegen_initialize_runtime_metadata\"(v284, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv292 = Spine.Unity.Examples.SkeletonGhostRenderer[];\n\tv293 = \"il2cpp_codegen_initialize_runtime_metadata\"(v292, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv297 = Spine.Unity.Examples.SkeletonGhostRenderer;\n\tv298 = \"il2cpp_codegen_initialize_runtime_metadata\"(v297, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv305 = Il2CppMethodInfo;\n\tv306 = \"il2cpp_codegen_initialize_runtime_metadata\"(v305, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv320 = Spine.AnimationState+TrackEntryEventDelegate;\n\tv321 = \"il2cpp_codegen_initialize_runtime_metadata\"(v320, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv363 = System.Type[];\n\tv364 = \"il2cpp_codegen_initialize_runtime_metadata\"(v363, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv390 = System.Type;\n\tv391 = \"il2cpp_codegen_initialize_runtime_metadata\"(v390, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv399 = \"Spine/Special/SkeletonGhost\";\n\tv400 = \"il2cpp_codegen_initialize_runtime_metadata\"(v399, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv484 = \" Ghost\";\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v484, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A37A61]) = v53;\nL_0045:\n\tv55 = this.pool == 0;\n\tif (v55) goto L_0051;\n\tv60 = overwrite == 0;\n\tif (v60) goto L_0135;\nL_0051:\n\tgoto L_0056;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v65, overwrite, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0056:\n\tv158 = UnityEngine.Object::op_Equality(this.ghostShader, 0);\n\tv258 = v158 == 0;\n\tif (v258) goto L_0064;\n\tv266 = UnityEngine.Shader::Find(\"Spine/Special/SkeletonGhost\");\n\tthis.ghostShader = v266;\nL_0064:\n\tv274 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonRenderer = v274;\n\tv282 = UnityEngine.Component::GetComponent(this);\n\tthis.meshFilter = v282;\n\tv290 = UnityEngine.Component::GetComponent(this);\n\tthis.meshRenderer = v290;\n\tv295 = UnityEngine.Time::get_time();\n\tv126 = v295 + this.spawnInterval;\n\tthis.nextSpawnTime = v126;\n\t// 123 NewArr v303 @ X0_v16 (Spine.Unity.Examples.SkeletonGhostRenderer[]), typeof(Spine.Unity.Examples.SkeletonGhostRenderer[]), this.maximumGhosts (System.Int32)\n\tthis.pool = v303;\n\tv318 = this.maximumGhosts < 1;\n\tif (v318) goto L_0101;\nL_0099:\n\tv388 = UnityEngine.Component::get_gameObject(this);\n\tv402 = UnityEngine.Object::get_name(v388);\n\tv486 = System.String::Concat(v402, \" Ghost\");\n\t// 165 NewArr v556 @ X0_v42 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_00B1;\n\tv587 = v448;\n\tv588 = \"il2cpp_codegen_runtime_class_init\"(v587, v554, v427, v366, v38, v39, v40, v41, v126, v124, v44, v45, v46, v47, v48, v49);\nL_00B1:\n\tv436 = System.Type::GetTypeFromHandle(Spine.Unity.Examples.SkeletonGhostRenderer);\n\tv591 = v436 == 0;\n\tif (v591) goto L_00C0;\n\t// 186 IsInst v561 @ X0_v57, typeof(System.Type), v436 @ X0_v45 (System.Type)\n\tv563 = v561 == 0;\n\tif (v563) goto L_0161;\nL_00C0:\n\tv556[0] = v436;\n\tv437 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v437, v486, v556);\n\tv338 = this.pool;\n\tv438 = UnityEngine.GameObject::GetComponent(v437);\n\tv597 = v438 == 0;\n\tif (v597) goto L_00E9;\n\t// 214 IsInst v562 @ X0_v55, typeof(Spine.Unity.Examples.SkeletonGhostRenderer), v438 @ X0_v50 (Spine.Unity.Examples.SkeletonGhostRenderer)\n\tv564 = v562 == 0;\n\tif (v564) goto L_0161;\nL_00E9:\n\tv338[v369 @ X23_v9 (System.Int32)] = v438;\n\tUnityEngine.GameObject::SetActive(v437, 0);\n\tUnityEngine.Object::set_hideFlags(v437, 1);\n\tv369 = v369 + 1;\n\tv340 = v369 < this.maximumGhosts;\n\tif (v340) goto L_0099;\nL_0101:\n\t// 257 IsInst v132 @ X0_v26 (Spine.Unity.IAnimationStateComponent), typeof(Spine.Unity.IAnimationStateComponent), this.skeletonRenderer (Spine.Unity.SkeletonRenderer)\n\tv134 = v132 == 0;\n\tif (v134) goto L_0135;\n\tgoto L_013D;\n\tv454 = *([v393 @ X8_v22+B0]);\n\tv455 = v454 + 8;\n\tv457 = *([v533 @ X10_v8-8]);\n\tv548 = v457 == v394;\n\tif (v548) goto L_0136;\n\tv461 = v534 - 1;\n\tv459 = v533 + 0x10;\n\tv463 = v534 != 1;\n\tif (v463) goto L_FFFFFFFF;\n\tv480 = v395;\n\tv481 = 0;\n\tv482 = 0xB349B4(v480, v394, v481, v76, v38, v39, v40, v41, v126, v124, v44, v45, v46, v47, v48, v49);\n\tgoto L_013D;\nL_0135:\n\treturn;\nL_0136:\n\tv569 = *([v533 @ X10_v8]);\n\tv570 = v569 << 4;\n\tv571 = v393 + v570;\n\tv572 = v571 + 0x138;\nL_013D:\n\tv579 = Spine.Unity.IAnimationStateComponent::get_AnimationState(v132);\n\tv439 = new Spine.AnimationState+TrackEntryEventDelegate();\n\tSpine.AnimationState+TrackEntryEventDelegate::.ctor(v439, this, Il2CppMethodInfo);\n\tSpine.AnimationState::add_Event(v579, v439);\n\treturn;\n\tv453 = new System.NullReferenceException();\n\tv531 = new System.IndexOutOfRangeException();\nL_0161:\n\tv567 = new System.ArrayTypeMismatchException();\n\tthrow v567;\n\treturn;\n// 239 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(bool overwrite)
		{
			if (pool != null && !overwrite)
			{
				return;
			}
			if (ghostShader == null)
			{
				Shader shader = Shader.Find("Spine/Special/SkeletonGhost");
				ghostShader = shader;
			}
			SkeletonRenderer component = GetComponent<SkeletonRenderer>();
			skeletonRenderer = component;
			MeshFilter component2 = GetComponent<MeshFilter>();
			meshFilter = component2;
			MeshRenderer component3 = GetComponent<MeshRenderer>();
			meshRenderer = component3;
			float time = Time.time;
			float num = time + spawnInterval;
			nextSpawnTime = num;
			SkeletonGhostRenderer[] array = new SkeletonGhostRenderer[maximumGhosts];
			pool = array;
			if (maximumGhosts >= 1)
			{
				int num2 = 0;
				do
				{
					GameObject gameObject = base.gameObject;
					string text = gameObject.name;
					string text2 = text + " Ghost";
					Type[] array2 = new Type[1];
					Type typeFromHandle = typeof(SkeletonGhostRenderer);
					if ((object)typeFromHandle != null)
					{
						object obj = typeFromHandle as Type;
						if (obj == null)
						{
							goto IL_02a5;
						}
					}
					array2[0] = typeFromHandle;
					GameObject gameObject2 = new GameObject(text2, array2);
					SkeletonGhostRenderer[] array3 = pool;
					SkeletonGhostRenderer component4 = gameObject2.GetComponent<SkeletonGhostRenderer>();
					if ((object)component4 != null)
					{
						object obj2 = component4 as SkeletonGhostRenderer;
						if (obj2 == null)
						{
							goto IL_02a5;
						}
					}
					array3[num2] = component4;
					gameObject2.SetActive(value: false);
					gameObject2.hideFlags = HideFlags.HideInHierarchy;
					num2++;
					continue;
					IL_02a5:
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
				while (num2 < maximumGhosts);
			}
			IAnimationStateComponent animationStateComponent = skeletonRenderer as IAnimationStateComponent;
			if (animationStateComponent != null)
			{
				AnimationState animationState = animationStateComponent.AnimationState;
				AnimationState.TrackEntryEventDelegate value = OnEvent;
				animationState.Event += value;
			}
		}

		[Token(Token = "0x6000135")]
		[Address(RVA = "0x1515990", Offset = "0x1515990", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = \"Ghosting\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, trackEntry, e, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37A62]) = v36;\nL_0014:\n\tv38 = e.data;\n\tv51 = System.String::Equals(v38.name, \"Ghosting\", 4);\n\tv103 = v51 == 0;\n\tif (v103) goto L_0050;\n\tv108 = e.intValue < 0;\n\tv109 = e.intValue == 0;\n\tv111 = e.intValue ^ e.intValue;\n\tv112 = e.intValue & v111;\n\tv113 = v112 < 0;\n\tv114 = v108 == v113;\n\tv115 = ~v109;\n\tv116 = v114 & v115;\n\tthis.ghostingEnabled = v116;\n\tv130 = e.floatValue <= 0;\n\tif (v130) goto L_0043;\n\tthis.spawnInterval = e.floatValue;\nL_0043:\n\tv133 = System.String::IsNullOrEmpty(e.stringValue);\n\tv137 = v133 == 0;\n\tv134 = ~v137;\n\tif (v134) goto L_0050;\n\tv132 = Spine.Unity.Examples.SkeletonGhost::HexToColor(e.stringValue);\n\tthis.color = v132;\nL_0050:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEvent(TrackEntry trackEntry, Event e)
		{
			EventData data = e.Data;
			if (data.Name.Equals("Ghosting", StringComparison.Ordinal))
			{
				bool flag = e.Int < 0;
				bool flag2 = e.Int == 0;
				int num = e.Int ^ e.Int;
				int num2 = e.Int & num;
				bool flag3 = num2 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				bool flag6 = flag4 && flag5;
				ghostingEnabled = flag6;
				if (e.Float > 0f)
				{
					spawnInterval = e.Float;
				}
				if (!string.IsNullOrEmpty(e.String))
				{
					Color32 color = HexToColor(e.String);
					this.color = color;
				}
			}
		}

		[Token(Token = "0x6000136")]
		[Address(RVA = "0x1515BAC", Offset = "0x1515BAC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = val < 0;\n\tv5 = val == 0;\n\tv7 = val ^ val;\n\tv8 = val & v7;\n\tv9 = v8 < 0;\n\tv10 = v4 == v9;\n\tv11 = ~v5;\n\tv12 = v10 & v11;\n\tthis.ghostingEnabled = v12;\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Ghosting(float val)
		{
			//IL_002f: Expected O, but got F4
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected I4, but got Unknown
			bool flag = val < 0f;
			bool flag2 = val == 0f;
			object obj = val ^ val;
			int num = val & (nint)obj;
			bool flag3 = num < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			bool flag6 = flag4 && flag5;
			ghostingEnabled = flag6;
		}

		[Token(Token = "0x6000137")]
		[Address(RVA = "0x1515BBC", Offset = "0x1515BBC", Length = "0x408")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv185 = Il2CppMethodInfo;\n\tv186 = \"il2cpp_codegen_initialize_runtime_metadata\"(v185, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv274 = UnityEngine.Material;\n\tv275 = \"il2cpp_codegen_initialize_runtime_metadata\"(v274, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv279 = \"_TextureFade\";\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v279, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A37A63]) = v54;\nL_0027:\n\tv56 = ~this.ghostingEnabled;\n\tif (v56) goto L_0183;\n\tv61 = UnityEngine.Time::get_time();\n\tv124 = v61 < this.nextSpawnTime;\n\tif (v124) goto L_0183;\n\tv276 = this.pool;\n\tv280 = this.poolIndex;\n\tv422 = UnityEngine.Component::get_gameObject(v276[v280 @ X9_v5 (System.Int32)]);\n\tv423 = UnityEngine.Renderer::get_sharedMaterials(this.meshRenderer);\n\tv553 = v423.Length < 1;\n\tif (v553) goto L_00DD;\nL_0082:\n\tv585 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::ContainsKey(this.materialTable, v423[v331 @ X24_v9 (System.Int32)]);\n\tv587 = v585 == 0;\n\tif (v587) goto L_0092;\n\tv591 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::get_Item(this.materialTable, v423[v331 @ X24_v9 (System.Int32)]);\n\tv594 = v591 == 0;\n\tv595 = ~v594;\n\tif (v595) goto L_00BD;\n\tgoto L_00CB;\nL_0092:\n\tv426 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v426, v423[v331 @ X24_v9 (System.Int32)]);\n\tUnityEngine.Material::set_shader(v426, this.ghostShader);\n\t// 163 MakeStruct v303 @ AGG1519D5C_1_v9 (UnityEngine.Color), typeof(UnityEngine.Color), 1f, 1f, 1f, 1f\n\tUnityEngine.Material::set_color(v426, v303);\n\tv618 = UnityEngine.Material::HasProperty(v426, \"_TextureFade\");\n\tv621 = v618 == 0;\n\tif (v621) goto L_00B7;\n\tUnityEngine.Material::SetFloat(v426, \"_TextureFade\", this.textureFade);\nL_00B7:\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::Add(this.materialTable, v423[v331 @ X24_v9 (System.Int32)], v426);\n\tv602 = v426 == 0;\n\tif (v602) goto L_00CB;\nL_00BD:\n\t// 189 IsInst v537 @ X0_v47, typeof(UnityEngine.Material), v530 @ X22_v10 (UnityEngine.Material)\n\tv538 = v537 == 0;\n\tif (v538) goto L_0186;\nL_00CB:\n\tv423[v331 @ X24_v9 (System.Int32)] = v478;\n\tv331 = v331 + 1;\n\tv562 = v331 < v423.Length;\n\tif (v562) goto L_0082;\nL_00DD:\n\tv583 = UnityEngine.GameObject::get_transform(v422);\n\tv429 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::set_parent(v583, v429);\n\tv456 = this.pool;\n\tv364 = this.poolIndex;\n\tv432 = UnityEngine.MeshFilter::get_sharedMesh(this.meshFilter);\n\tv433 = UnityEngine.Renderer::get_sortingLayerID(this.meshRenderer);\n\tv434 = UnityEngine.Renderer::get_sortingOrder(this.meshRenderer);\n\tv394 = this.additive == 0;\n\tv629 = this.sortWithDistanceOnly + v434;\n\tv369 = ~v394;\n\tv74 = v629 - 1;\n\tSpine.Unity.Examples.SkeletonGhostRenderer::Initialize(v456[v364 @ X9_v6 (System.Int32)], v432, v423, this.color, v369, this.fadeSpeed, v433, v74);\n\t// 300 MakeStruct v69 @ AGG1519EBC_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, this.zOffset (System.Single)\n\tUnityEngine.Transform::set_localPosition(v583, v69);\n\tgoto L_0143;\n\tv644 = UnityEngine.Quaternion;\n\tv645 = \"il2cpp_codegen_initialize_runtime_metadata\"(v644, v638, v632, v80, v76, v72, v74, v42, v635, v636, v634, v307, v47, v48, v49, v50);\n\tv648 = 1;\n\t*([1A3551A]) = v648;\nL_0143:\n\tUnityEngine.Transform::set_localRotation(v583, v654.identityQuaternion);\n\tgoto L_0158;\n\tv662 = UnityEngine.Vector3;\n\tv663 = \"il2cpp_codegen_initialize_runtime_metadata\"(v662, v652, v632, v80, v76, v72, v74, v42, v655, v656, v657, v85, v47, v48, v49, v50);\n\tv666 = 1;\n\t*([1A35658]) = v666;\nL_0158:\n\tUnityEngine.Transform::set_localScale(v583, v672.oneVector);\n\tUnityEngine.Transform::set_parent(v583, 0);\n\tv365 = this.pool;\n\tv168 = this.poolIndex + 1;\n\tthis.poolIndex = v168;\n\tv123 = v168 != v365.Length;\n\tif (v123) goto L_0171;\n\tthis.poolIndex = 0;\nL_0171:\n\tv675 = UnityEngine.Time::get_time();\n\tv162 = v675 + this.spawnInterval;\n\tthis.nextSpawnTime = v162;\nL_0183:\n\treturn;\n\tv461 = new System.NullReferenceException();\n\tv525 = new System.IndexOutOfRangeException();\nL_0186:\n\tv540 = new System.ArrayTypeMismatchException();\n\tthrow v540;\n\treturn;\n// 300 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_0352: Expected O, but got I4
			if (!ghostingEnabled)
			{
				return;
			}
			float time = Time.time;
			if (time < nextSpawnTime)
			{
				return;
			}
			SkeletonGhostRenderer[] array = pool;
			int num = poolIndex;
			GameObject gameObject = array[num].gameObject;
			Material[] sharedMaterials = meshRenderer.sharedMaterials;
			if (sharedMaterials.Length >= 1)
			{
				int num2 = 0;
				Color color = default(Color);
				do
				{
					Material material2;
					Material material3;
					if (materialTable.ContainsKey(sharedMaterials[num2]))
					{
						Material material = materialTable[sharedMaterials[num2]];
						bool flag = (object)material == null;
						bool flag2 = !flag;
						material2 = material;
						if (flag2)
						{
							goto IL_0240;
						}
						material3 = material;
					}
					else
					{
						Material material4 = new Material(sharedMaterials[num2]);
						material4.shader = ghostShader;
						color.r = 1f;
						color.g = 1f;
						color.b = 1f;
						color.a = 1f;
						material4.color = color;
						if (material4.HasProperty("_TextureFade"))
						{
							material4.SetFloat("_TextureFade", textureFade);
						}
						materialTable.Add(sharedMaterials[num2], material4);
						bool flag3 = (object)material4 == null;
						material2 = material4;
						material3 = material4;
						if (!flag3)
						{
							goto IL_0240;
						}
					}
					goto IL_0272;
					IL_0272:
					sharedMaterials[num2] = material3;
					num2++;
					continue;
					IL_0240:
					object obj = material2 as Material;
					bool flag4 = obj == null;
					material3 = material2;
					if (!flag4)
					{
						goto IL_0272;
					}
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
				while (num2 < sharedMaterials.Length);
			}
			Transform transform = gameObject.transform;
			Transform parent = base.transform;
			transform.parent = parent;
			SkeletonGhostRenderer[] array2 = pool;
			int num3 = poolIndex;
			Mesh sharedMesh = meshFilter.sharedMesh;
			int sortingLayerID = meshRenderer.sortingLayerID;
			int sortingOrder = meshRenderer.sortingOrder;
			bool flag5 = !additive;
			object obj2 = (sortWithDistanceOnly ? 1 : 0) + sortingOrder;
			bool flag6 = !flag5;
			int sortingOrder2 = (int)((nint)obj2 - 1);
			array2[num3].Initialize(sharedMesh, sharedMaterials, this.color, flag6, fadeSpeed, sortingLayerID, sortingOrder2);
			Vector3 localPosition = default(Vector3);
			localPosition.x = 0f;
			localPosition.y = 0f;
			localPosition.z = zOffset;
			transform.localPosition = localPosition;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
			transform.parent = null;
			SkeletonGhostRenderer[] array3 = pool;
			if (++poolIndex == array3.Length)
			{
				poolIndex = 0;
			}
			float time2 = Time.time;
			float num4 = time2 + spawnInterval;
			nextSpawnTime = num4;
		}

		[Token(Token = "0x6000138")]
		[Address(RVA = "0x1516178", Offset = "0x1516178", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv130 = Il2CppMethodInfo;\n\tv131 = \"il2cpp_codegen_initialize_runtime_metadata\"(v130, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv167 = Il2CppMethodInfo;\n\tv168 = \"il2cpp_codegen_initialize_runtime_metadata\"(v167, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv188 = UnityEngine.Object;\n\tv189 = \"il2cpp_codegen_initialize_runtime_metadata\"(v188, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv219 = Il2CppMethodInfo;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v219, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37A64]) = v40;\nL_0022:\n\tv41 = 0;\n\tv183 = this.pool;\n\tv47 = this.pool == 0;\n\tif (v47) goto L_007D;\n\tv62 = this.maximumGhosts < 1;\n\tif (v62) goto L_007D;\nL_0039:\n\tv65 = v74 - 4;\n\tv186 = v65 < v183.Length;\n\tv153 = ~v186;\n\tif (v153) goto L_00A5;\n\tgoto L_004E;\n\tv220 = \"il2cpp_codegen_runtime_class_init\"(v190, v171, v170, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_004E:\n\tv158 = UnityEngine.Object::op_Inequality(*([v183 @ X8_v14 (Spine.Unity.Examples.SkeletonGhostRenderer[])+v74 @ X22_v8 (System.Int32)*8]), 0);\n\tv237 = v158 == 0;\n\tif (v237) goto L_0065;\n\tv165 = this.pool;\n\tv277 = v65 < v165.Length;\n\tv154 = ~v277;\n\tif (v154) goto L_00A5;\n\tSpine.Unity.Examples.SkeletonGhostRenderer::Cleanup(*([v165 @ X8_v19 (Spine.Unity.Examples.SkeletonGhostRenderer[])+v74 @ X22_v8 (System.Int32)*8]));\nL_0065:\n\tv113 = v74 - 3;\n\tv77 = v113 >= this.maximumGhosts;\n\tif (v77) goto L_007D;\n\tv183 = this.pool;\n\tv74 = v74 + 1;\n\tv278 = this.pool == 0;\n\tv160 = ~v278;\n\tif (v160) goto L_0039;\n\tthrow System.NullReferenceException;\nL_007D:\n\tv136 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::get_Values(this.materialTable);\n\tv217 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>+ValueCollection<UnityEngine.Material, UnityEngine.Material>::GetEnumerator(v136);\nL_008B:\n\tv235 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v41 @ stack_-48_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv250 = v235 == 0;\n\tif (v250) goto L_009C;\n\tgoto L_0098;\n\tv282 = \"il2cpp_codegen_runtime_class_init\"(v273, v233, v66, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0098:\n\tUnityEngine.Object::Destroy(0);\n\tgoto L_008B;\nL_009C:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v41 @ stack_-48_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\nL_00A4:\n\treturn;\nL_00A5:\n\tv208 = new System.IndexOutOfRangeException();\n\tgoto L_00B1;\nL_00B1:\n\tv248 = v194 != 1;\n\tif (v248) goto L_00BF;\n\tv263 = 0x1854E70(v208, v194, v193, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv279 = 0x1854E80(v263, v194, v193, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v41 @ stack_-48_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv269 = *([v263 @ X0_v29]) == 0;\n\tif (v269) goto L_00A4;\n\tthrow System.OutOfMemoryException;\nL_00BF:\n\tgoto L_00C3;\n\tX20 = X0;\nL_00C3:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v41 @ stack_-48_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tgoto L_00CA;\n\tv335 = 0xBD3CD0(v208, *([v74 @ X22_v8 (System.Int32)]), v193, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_00CA:\n\tv338 = new System.OutOfMemoryException();\n\tv329 = 0x9DACB4(v338, *([v74 @ X22_v8 (System.Int32)]), v193, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\treturn;\n// 132 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			//IL_002c: Expected O, but got I
			//IL_0051: Expected O, but got I
			//IL_013a: Expected O, but got I4
			//IL_00a5: Expected O, but got I4
			//IL_00c9: Expected O, but got I
			Dictionary<object, object>.ValueCollection.Enumerator enumerator = default(Dictionary<object, object>.ValueCollection.Enumerator);
			SkeletonGhostRenderer[] array = pool;
			if (pool != null && maximumGhosts >= 1)
			{
				IntPtr intPtr = default(IntPtr);
				UnityEngine.Object obj = (UnityEngine.Object)(nint)intPtr;
				int num = 4;
				object obj3 = default(object);
				while (true)
				{
					int num2 = num - 4;
					if (num2 < array.Length)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X8_v14 (Spine.Unity.Examples.SkeletonGhostRenderer[])+v74 @ X22_v8 (System.Int32)*8]");
						object obj2;
						if ((UnityEngine.Object)0 != null)
						{
							SkeletonGhostRenderer[] array2 = pool;
							bool flag = num2 < array2.Length;
							bool flag2 = !flag;
							obj2 = 0;
							obj = null;
							if (flag2)
							{
								goto IL_01c2;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X8_v19 (Spine.Unity.Examples.SkeletonGhostRenderer[])+v74 @ X22_v8 (System.Int32)*8]");
							((SkeletonGhostRenderer)0).Cleanup();
						}
						int num3 = num - 3;
						if (num3 >= maximumGhosts)
						{
							break;
						}
						array = pool;
						num++;
						bool flag3 = pool == null;
						bool flag4 = !flag3;
						obj2 = 0;
						obj = null;
						if (!flag4)
						{
							throw new NullReferenceException();
						}
						continue;
					}
					goto IL_01c2;
					IL_01c2:
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					if ((nint)obj == 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
						enumerator.Dispose();
						if (obj3 != null)
						{
							throw new OutOfMemoryException();
						}
					}
					else
					{
						enumerator.Dispose();
						OutOfMemoryException ex2 = new OutOfMemoryException();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
					}
					return;
				}
			}
			Dictionary<Material, Material>.ValueCollection values = materialTable.Values;
			Dictionary<Material, Material>.ValueCollection.Enumerator enumerator2 = values.GetEnumerator();
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null);
			}
			enumerator.Dispose();
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0x1515A3C", Offset = "0x1515A3C", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv18 = \"#\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv41 = \"\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A65]) = v38;\nL_0023:\n\tv54 = hex._stringLength <= 5;\n\tif (v54) goto L_0065;\n\tv83 = System.String::Replace(hex, \"#\", \"\");\n\tv156 = System.String::Substring(v83, 0, 2);\n\tv200 = System.Byte::Parse(v156, 0x203);\n\tv205 = System.String::Substring(v83, 2, 2);\n\tv208 = System.Byte::Parse(v205, 0x203);\n\tv212 = System.String::Substring(v83, 4, 2);\n\tv213 = System.Byte::Parse(v212, 0x203);\n\tv167 = v83._stringLength != 8;\n\tif (v167) goto L_FFFFFFFF;\n\tv218 = System.String::Substring(v83, 6, 2);\n\tv178 = System.Byte::Parse(v218, 0x203);\n\tgoto L_006C;\nL_0065:\n\tv97 = 0xBF7EB8(0, methodInfo, v21, v22, v23, v24, v25, v26, 1f, 0, 1f, 1f, v31, v32, v33, v34);\n\tv184 = v97 >> 8;\n\tv157 = v97 >> 0x10;\n\tv101 = v97 >> 0x18;\n\tgoto L_006C;\nL_006C:\n\tv186 = v101 & 0xFF;\n\tv123 = v157 & 0xFF;\n\tv187 = v186 << 0x18;\n\tv188 = v123 & 0xFF;\n\tv189 = v188 << 0x10;\n\tv190 = v187 & 0xFFFFFFFFFF00FFFF;\n\tv191 = v190 | v189;\n\tv149 = v184 & 0xFF;\n\tv192 = v149 & 0xFF;\n\tv193 = v192 << 8;\n\tv194 = v191 & 0xFFFFFFFFFFFF00FF;\n\tv195 = v194 | v193;\n\tv145 = v180 & 0xFF;\n\tv197 = v195 & 0xFFFFFFFFFFFFFF00;\n\treturnVal2 = v197 | v145;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Color32 HexToColor(string hex)
		{
			//IL_027e: Expected O, but got I4
			int num;
			int num2;
			byte b5;
			int num3;
			if (hex.Length > 5)
			{
				string text = hex.Replace("#", "");
				string s = text.Substring(0, 2);
				byte b = byte.Parse(s, NumberStyles.HexNumber);
				string s2 = text.Substring(2, 2);
				byte b2 = byte.Parse(s2, NumberStyles.HexNumber);
				string s3 = text.Substring(4, 2);
				byte b3 = byte.Parse(s3, NumberStyles.HexNumber);
				if (text.Length == 8)
				{
					string s4 = text.Substring(6, 2);
					byte b4 = byte.Parse(s4, NumberStyles.HexNumber);
					num = b3;
					num2 = b4;
					b5 = b;
					num3 = b2;
				}
				else
				{
					num = b3;
					num2 = 255;
					b5 = b;
					num3 = b2;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BF7EB8 (inside CodeStage.AntiCheat.Common.ContainerHolder::.ctor +0x8)");
				byte b6 = default(byte);
				num3 = b6 >> 8;
				num = b6 >> 16;
				num2 = b6 >> 24;
				b5 = b6;
			}
			int num4 = num2 & 0xFF;
			int num5 = num & 0xFF;
			int num6 = num4 << 24;
			int num7 = num5 & 0xFF;
			int num8 = num7 << 16;
			int num9 = num6 & -16711681;
			int num10 = num9 | num8;
			int num11 = num3 & 0xFF;
			int num12 = num11 & 0xFF;
			int num13 = num12 << 8;
			int num14 = num10 & -65281;
			int num15 = num14 | num13;
			int num16 = b5 & 0xFF;
			int num17 = num15 & -256;
			return (Color32)(num17 | num16);
		}

		[Token(Token = "0x600013A")]
		[Address(RVA = "0x1516490", Offset = "0x1516490", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv53 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37A66]) = v42;\nL_0020:\n\tthis.ghostingEnabled = 1;\n\tthis.spawnInterval = 0.033333335f;\n\tthis.fadeSpeed = 10f;\n\tthis.color = 0xFFFFFF;\n\tthis.additive = 1;\n\tthis.textureFade = 1f;\n\tv51 = new System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::.ctor(v51);\n\tthis.materialTable = v51;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonGhost()
		{
			//IL_0038: Expected O, but got I4
			base._002Ector();
			ghostingEnabled = true;
			spawnInterval = 1f / 30f;
			fadeSpeed = 10f;
			color = (Color32)16777215;
			additive = true;
			textureFade = 1f;
			Dictionary<Material, Material> dictionary = new Dictionary<Material, Material>();
			materialTable = dictionary;
		}
	}
}
