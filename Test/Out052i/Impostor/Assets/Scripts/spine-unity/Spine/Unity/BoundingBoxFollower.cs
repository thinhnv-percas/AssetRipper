using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[HelpURL("http://esotericsoftware.com/spine-unity#BoundingBoxFollower")]
	[ExecuteAlways]
	[Token(Token = "0x2000077")]
	public class BoundingBoxFollower : MonoBehaviour
	{
		[Token(Token = "0x40002DE")]
		internal static bool DebugMessages = true;

		[Token(Token = "0x40002DF")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonRenderer skeletonRenderer;

		[SpineSlot(null, "skeletonRenderer", true, true, false)]
		[Token(Token = "0x40002E0")]
		[FieldOffset(Offset = "0x28")]
		public string slotName;

		[Token(Token = "0x40002E1")]
		[FieldOffset(Offset = "0x30")]
		public bool isTrigger;

		[Token(Token = "0x40002E2")]
		[FieldOffset(Offset = "0x31")]
		public bool clearStateOnDisable;

		[Token(Token = "0x40002E3")]
		[FieldOffset(Offset = "0x38")]
		private Slot slot;

		[Token(Token = "0x40002E4")]
		[FieldOffset(Offset = "0x40")]
		private BoundingBoxAttachment currentAttachment;

		[Token(Token = "0x40002E5")]
		[FieldOffset(Offset = "0x48")]
		private string currentAttachmentName;

		[Token(Token = "0x40002E6")]
		[FieldOffset(Offset = "0x50")]
		private PolygonCollider2D currentCollider;

		[Token(Token = "0x40002E7")]
		[FieldOffset(Offset = "0x58")]
		public readonly Dictionary<BoundingBoxAttachment, PolygonCollider2D> colliderTable;

		[Token(Token = "0x40002E8")]
		[FieldOffset(Offset = "0x60")]
		public readonly Dictionary<BoundingBoxAttachment, string> nameTable;

		[Token(Token = "0x17000180")]
		public Slot Slot
		{
			[Token(Token = "0x60004D7")]
			[Address(RVA = "0x15552B4", Offset = "0x15552B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.slot;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Slot;
			}
		}

		[Token(Token = "0x17000181")]
		public BoundingBoxAttachment CurrentAttachment
		{
			[Token(Token = "0x60004D8")]
			[Address(RVA = "0x15552BC", Offset = "0x15552BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.currentAttachment;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CurrentAttachment;
			}
		}

		[Token(Token = "0x17000182")]
		public string CurrentAttachmentName
		{
			[Token(Token = "0x60004D9")]
			[Address(RVA = "0x15552C4", Offset = "0x15552C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.currentAttachmentName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CurrentAttachmentName;
			}
		}

		[Token(Token = "0x17000183")]
		public PolygonCollider2D CurrentCollider
		{
			[Token(Token = "0x60004DA")]
			[Address(RVA = "0x15552CC", Offset = "0x15552CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.currentCollider;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CurrentCollider;
			}
		}

		[Token(Token = "0x17000184")]
		public bool IsTrigger
		{
			[Token(Token = "0x60004DB")]
			[Address(RVA = "0x15552D4", Offset = "0x15552D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isTrigger;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return isTrigger;
			}
		}

		[Token(Token = "0x60004DC")]
		[Address(RVA = "0x15552DC", Offset = "0x15552DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.BoundingBoxFollower::Initialize(this, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Initialize();
		}

		[Token(Token = "0x60004DD")]
		[Address(RVA = "0x15557C4", Offset = "0x15557C4", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv49 = UnityEngine.Object;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv58 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37BEF]) = v42;\nL_0020:\n\tgoto L_0025;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv56 = UnityEngine.Object::op_Inequality(this.skeletonRenderer, 0);\n\tv60 = v56 == 0;\n\tif (v60) goto L_004E;\n\tv113 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v113, this, Il2CppMethodInfo);\n\tv93 = this.skeletonRenderer == 0;\n\tif (v93) goto L_0050;\n\tSpine.Unity.SkeletonRenderer::remove_OnRebuild(this.skeletonRenderer, v113);\n\tv113 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v113, this, Il2CppMethodInfo);\n\tv77 = this.skeletonRenderer == 0;\n\tif (v77) goto L_0050;\n\tSpine.Unity.SkeletonRenderer::add_OnRebuild(this.skeletonRenderer, v113);\nL_004E:\n\tSpine.Unity.BoundingBoxFollower::Initialize(this, 0);\n\treturn;\nL_0050:\n\tthrow v113;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			if (skeletonRenderer != null)
			{
				SkeletonRenderer.SkeletonRendererDelegate skeletonRendererDelegate = HandleRebuild;
				if ((object)skeletonRenderer != null)
				{
					skeletonRenderer.OnRebuild -= skeletonRendererDelegate;
					skeletonRendererDelegate = HandleRebuild;
					if ((object)skeletonRenderer != null)
					{
						skeletonRenderer.OnRebuild += skeletonRendererDelegate;
						goto IL_00c1;
					}
				}
				throw skeletonRendererDelegate;
			}
			goto IL_00c1;
			IL_00c1:
			Initialize();
		}

		[Token(Token = "0x60004DE")]
		[Address(RVA = "0x15558C0", Offset = "0x15558C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.BoundingBoxFollower::Initialize(this, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleRebuild(SkeletonRenderer sr)
		{
			Initialize();
		}

		[Token(Token = "0x60004DF")]
		[Address(RVA = "0x15552E4", Offset = "0x15552E4", Length = "0x4E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0047;\n\tv26 = Spine.Unity.BoundingBoxFollower;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv65 = UnityEngine.Debug;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv224 = Il2CppMethodInfo;\n\tv225 = \"il2cpp_codegen_initialize_runtime_metadata\"(v224, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv353 = Il2CppMethodInfo;\n\tv354 = \"il2cpp_codegen_initialize_runtime_metadata\"(v353, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv358 = Il2CppMethodInfo;\n\tv359 = \"il2cpp_codegen_initialize_runtime_metadata\"(v358, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv365 = Il2CppMethodInfo;\n\tv366 = \"il2cpp_codegen_initialize_runtime_metadata\"(v365, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv385 = Il2CppMethodInfo;\n\tv386 = \"il2cpp_codegen_initialize_runtime_metadata\"(v385, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv393 = Il2CppMethodInfo;\n\tv394 = \"il2cpp_codegen_initialize_runtime_metadata\"(v393, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv401 = UnityEngine.Object;\n\tv402 = \"il2cpp_codegen_initialize_runtime_metadata\"(v401, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv411 = \"Slot '{0}' not found for BoundingBoxFollower on '{1}'. (Previous colliders were disposed.)\";\n\tv412 = \"il2cpp_codegen_initialize_runtime_metadata\"(v411, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv457 = \"Bounding Box Follower tried to rebuild as a prefab.\";\n\tv458 = \"il2cpp_codegen_initialize_runtime_metadata\"(v457, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv472 = \"] does not contain any Bounding Box Attachments!\";\n\tv473 = \"il2cpp_codegen_initialize_runtime_metadata\"(v472, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv485 = \"Bounding Box Follower not valid! Slot [\";\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v485, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37BF0]) = v45;\nL_0047:\n\tv212 = this.skeletonRenderer;\n\tgoto L_004F;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v46, overwrite, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004F:\n\tv63 = UnityEngine.Object::op_Equality(this.skeletonRenderer, 0);\n\tv68 = v63 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_015C;\n\tv73 = this.skeletonRenderer;\n\tv74 = this.skeletonRenderer == 0;\n\tif (v74) goto L_0169;\n\tv204 = *([v73 @ X0_v7 (Spine.Unity.SkeletonRenderer)]);\n\tv168 = *([v204 @ X8_v30 (Il2CppClass<Spine.Unity.SkeletonRenderer>)+1D0]);\n\tv227 = Spine.Unity.SkeletonRenderer::Initialize(this.skeletonRenderer, 0);\n\tv180 = System.String::IsNullOrEmpty(this.slotName);\n\tv356 = v180 == 0;\n\tv188 = ~v356;\n\tif (v188) goto L_015C;\n\tv361 = overwrite == 0;\n\tv362 = ~v361;\n\tif (v362) goto L_009E;\n\tv280 = this.colliderTable == 0;\n\tif (v280) goto L_0169;\n\tv368 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::get_Count(this.colliderTable);\n\tv240 = v368 < 1;\n\tif (v240) goto L_009E;\n\tv370 = this.slot == 0;\n\tif (v370) goto L_009E;\n\tv297 = this.skeletonRenderer;\n\tv281 = this.skeletonRenderer == 0;\n\tif (v281) goto L_0169;\n\tv449 = v297.skeleton;\n\tv271 = Spine.Slot::get_Skeleton(this.slot);\n\tv107 = v297.skeleton != v271;\n\tif (v107) goto L_009E;\n\tv298 = this.slot;\n\tv282 = this.slot == 0;\n\tif (v282) goto L_0169;\n\tv205 = v298.data;\n\tv283 = v298.data == 0;\n\tif (v283) goto L_0169;\n\tv173 = v205.name;\n\tv181 = System.String::op_Equality(this.slotName, v205.name);\n\tv505 = v181 == 0;\n\tv189 = ~v505;\n\tif (v189) goto L_015C;\nL_009E:\n\tthis.currentAttachmentName = 0;\n\tthis.slot = 0;\n\tv284 = this.colliderTable == 0;\n\tif (v284) goto L_0169;\n\tSystem.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::Clear(this.colliderTable);\n\tv285 = this.nameTable == 0;\n\tif (v285) goto L_0169;\n\tSystem.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, System.String>::Clear(this.nameTable);\n\tv206 = this.skeletonRenderer;\n\tv286 = this.skeletonRenderer == 0;\n\tif (v286) goto L_0169;\n\tv449 = v206.skeleton;\n\tv190 = v206.skeleton == 0;\n\tif (v190) goto L_015C;\n\tv478 = Spine.Skeleton::FindSlot(v206.skeleton, this.slotName);\n\tthis.slot = v478;\n\tv487 = Spine.Skeleton::FindSlotIndex(v206.skeleton, this.slotName);\n\tv492 = this.slot == 0;\n\tif (v492) goto L_00F5;\n\tv497 = UnityEngine.Component::GetComponents(this);\n\tv273 = UnityEngine.Component::get_gameObject(this);\n\tv287 = v273 == 0;\n\tif (v287) goto L_0169;\n\tv274 = UnityEngine.GameObject::get_activeInHierarchy(v273);\n\tv467 = v274 == 0;\n\tif (v467) goto L_011C;\n\tv302 = v449.data;\n\tv288 = v449.data == 0;\n\tif (v288) goto L_0169;\n\tv289 = v302.skins == 0;\n\tif (v289) goto L_0169;\n\tv547 = Spine.ExposedList`1<Spine.Skin>::GetEnumerator(v302.skins);\nL_00E4:\n\tv606 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v426 @ stack_-78_v7 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv448 = v606 == 0;\n\tif (v448) goto L_0111;\n\tSpine.Unity.BoundingBoxFollower::AddCollidersForSkin(this, v588, v487, v497, &v236 @ stack_-34_v4 (System.Int32));\n\tgoto L_00E4;\nL_00F5:\n\tgoto L_00FA;\n\tv507 = \"il2cpp_codegen_runtime_class_init\"(v499, v176, v169, v29, v30, v31, v32, v33, v102, v35, v36, v37, v38, v39, v40, v41);\n\tv508 = Spine.Unity.BoundingBoxFollower;\nL_00FA:\n\tv192 = ~v509.DebugMessages;\n\tif (v192) goto L_015C;\n\tv276 = UnityEngine.Component::get_gameObject(this);\n\tv290 = v276 == 0;\n\tif (v290) goto L_0169;\n\tv515 = UnityEngine.Object::get_name(v276);\n\tv179 = System.String::Format(\"Slot '{0}' not found for BoundingBoxFollower on '{1}'. (Previous colliders were disposed.)\", this.slotName, v515);\n\tgoto L_014E;\nL_0111:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v426 @ stack_-78_v7 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_0113:\n\tv455 = v449.skin == 0;\n\tif (v455) goto L_011C;\n\tSpine.Unity.BoundingBoxFollower::AddCollidersForSkin(this, v449.skin, v212, v215, &v236 @ stack_-34_v4 (System.Int32));\nL_011C:\n\tSpine.Unity.BoundingBoxFollower::DisposeExcessCollidersAfter(this, v236);\n\tgoto L_0128;\n\tv488 = \"il2cpp_codegen_runtime_class_init\"(v480, v177, v168, v80, v83, v31, v32, v33, v103, v35, v36, v37, v38, v39, v40, v41);\n\tv489 = Spine.Unity.BoundingBoxFollower;\nL_0128:\n\tv193 = ~v490.DebugMessages;\n\tif (v193) goto L_015C;\n\tv291 = this.colliderTable == 0;\n\tif (v291) goto L_0169;\n\tv183 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::get_Count(this.colliderTable);\n\tv510 = v183 == 0;\n\tv191 = ~v510;\n\tif (v191) goto L_015C;\n\tv278 = UnityEngine.Component::get_gameObject(this);\n\tv292 = v278 == 0;\n\tif (v292) goto L_0169;\n\tv517 = UnityEngine.GameObject::get_activeInHierarchy(v278);\n\tv527 = v517 == 0;\n\tif (v527) goto L_0163;\n\tv179 = System.String::Concat(\"Bounding Box Follower not valid! Slot [\", this.slotName, \"] does not contain any Bounding Box Attachments!\");\nL_014E:\n\tgoto L_0153;\n\tv590 = v578;\n\tv591 = \"il2cpp_codegen_runtime_class_init\"(v590, v568, v567, v549, v550, v31, v32, v33, v556, v35, v36, v37, v38, v39, v40, v41);\nL_0153:\n\tUnityEngine.Debug::LogWarning(v179);\nL_015C:\n\treturn;\nL_0163:\n\tgoto L_FFFFFFFF;\n\tv582 = \"il2cpp_codegen_runtime_class_init\"(v539, v516, v168, v80, v83, v31, v32, v33, v103\n// ... truncated")]
		public unsafe void Initialize(bool overwrite = false)
		{
			//IL_0081: Expected O, but got I4
			//IL_008a: Expected O, but got I4
			//IL_00a0: Expected I, but got O
			//IL_03bc: Expected O, but got I4
			//IL_03c5: Expected O, but got I4
			//IL_015d: Expected O, but got I4
			//IL_0166: Expected O, but got I4
			//IL_040d: Expected O, but got I
			//IL_0415: Expected O, but got I4
			//IL_041e: Expected O, but got I4
			//IL_0803: Expected I4, but got O
			//IL_0813: Expected O, but got I4
			//IL_0823: Expected I4, but got O
			//IL_0198: Expected O, but got I
			//IL_0470: Expected O, but got I
			//IL_0478: Expected O, but got I4
			//IL_0481: Expected O, but got I4
			//IL_0850: Expected O, but got I4
			//IL_01c5: Expected O, but got I
			//IL_020f: Expected O, but got I
			//IL_0217: Expected O, but got I4
			//IL_0220: Expected O, but got I4
			//IL_0272: Expected I4, but got O
			//IL_02bc: Expected O, but got I4
			//IL_0572: Expected O, but got I4
			//IL_0753: Expected O, but got I4
			//IL_030c: Expected O, but got I4
			//IL_05cd: Expected O, but got I4
			//IL_036f: Expected I4, but got O
			//IL_0632: Expected O, but got I4
			//IL_068a: Expected O, but got I4
			//IL_07b1: Expected O, but got I4
			//IL_06ef: Expected O, but got I4
			UnityEngine.Object obj = this.skeletonRenderer;
			if (this.skeletonRenderer == null)
			{
				return;
			}
			SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
			bool flag = (object)this.skeletonRenderer == null;
			ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
			int collidersCount = 0;
			int num = 0;
			string text = null;
			Skeleton skeleton = (Skeleton)overwrite;
			PolygonCollider2D[] array = (PolygonCollider2D[])27488256;
			bool flag4;
			if (!flag)
			{
				nint num2 = (nint)skeletonRenderer;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ X8_v30 (Il2CppClass<Spine.Unity.SkeletonRenderer>)+1D0]");
				num = 0;
				this.skeletonRenderer.Initialize(overwrite: false);
				if (string.IsNullOrEmpty(slotName))
				{
					return;
				}
				bool flag2 = !overwrite;
				bool flag3 = !flag2;
				text = null;
				flag4 = overwrite;
				if (!flag3)
				{
					bool flag5 = colliderTable == null;
					enumerator = default(ExposedList<object>.Enumerator);
					collidersCount = 0;
					text = null;
					skeleton = (Skeleton)overwrite;
					array = (PolygonCollider2D[])27488256;
					if (flag5)
					{
						goto IL_093e;
					}
					int count = colliderTable.Count;
					bool flag6 = count < 1;
					text = (string)0;
					flag4 = overwrite;
					if (!flag6)
					{
						bool flag7 = Slot == null;
						text = (string)0;
						flag4 = overwrite;
						if (!flag7)
						{
							SkeletonRenderer skeletonRenderer2 = this.skeletonRenderer;
							bool flag8 = (object)this.skeletonRenderer == null;
							enumerator = default(ExposedList<object>.Enumerator);
							collidersCount = 0;
							text = (string)0;
							skeleton = (Skeleton)overwrite;
							array = (PolygonCollider2D[])27488256;
							if (!flag8)
							{
								skeleton = skeletonRenderer2.skeleton;
								Skeleton skeleton2 = Slot.Skeleton;
								bool flag9 = skeletonRenderer2.skeleton != skeleton2;
								text = null;
								flag4 = (byte)(int)skeletonRenderer2.skeleton != 0;
								if (flag9)
								{
									goto IL_037d;
								}
								Slot slot = Slot;
								bool flag10 = Slot == null;
								enumerator = default(ExposedList<object>.Enumerator);
								collidersCount = 0;
								text = null;
								array = (PolygonCollider2D[])27488256;
								if (!flag10)
								{
									SlotData data = slot.Data;
									bool flag11 = slot.Data == null;
									enumerator = default(ExposedList<object>.Enumerator);
									collidersCount = 0;
									text = null;
									array = (PolygonCollider2D[])27488256;
									if (!flag11)
									{
										text = data.Name;
										bool flag12 = slotName == data.Name;
										bool flag13 = !flag12;
										bool flag14 = !flag13;
										num = 0;
										flag4 = (byte)(int)skeletonRenderer2.skeleton != 0;
										if (!flag14)
										{
											goto IL_037d;
										}
										return;
									}
								}
							}
							goto IL_093e;
						}
					}
				}
				goto IL_037d;
			}
			goto IL_093e;
			IL_07be:
			bool flag15 = skeleton.Skin == null;
			ExposedList<object>.Enumerator enumerator2;
			string text2 = (string)enumerator2;
			if (!flag15)
			{
				AddCollidersForSkin(skeleton.Skin, (int)obj, array, ref collidersCount);
				PolygonCollider2D[] array2 = array;
				object obj2 = collidersCount;
				text2 = (string)enumerator2;
				num = (int)obj;
			}
			goto IL_0828;
			IL_037d:
			currentAttachmentName = null;
			this.slot = null;
			bool flag16 = colliderTable == null;
			enumerator = default(ExposedList<object>.Enumerator);
			collidersCount = 0;
			text2 = null;
			skeleton = (Skeleton)flag4;
			array = (PolygonCollider2D[])27488256;
			string message;
			if (!flag16)
			{
				colliderTable.Clear();
				bool flag17 = nameTable == null;
				enumerator = default(ExposedList<object>.Enumerator);
				collidersCount = 0;
				text2 = null;
				text = (string)0;
				skeleton = (Skeleton)flag4;
				array = (PolygonCollider2D[])27488256;
				if (!flag17)
				{
					nameTable.Clear();
					SkeletonRenderer skeletonRenderer3 = this.skeletonRenderer;
					bool flag18 = (object)this.skeletonRenderer == null;
					enumerator = default(ExposedList<object>.Enumerator);
					collidersCount = 0;
					text2 = null;
					text = (string)0;
					skeleton = (Skeleton)flag4;
					array = (PolygonCollider2D[])27488256;
					if (!flag18)
					{
						skeleton = skeletonRenderer3.skeleton;
						if (skeletonRenderer3.skeleton == null)
						{
							return;
						}
						Slot slot2 = skeletonRenderer3.skeleton.FindSlot(slotName);
						this.slot = slot2;
						int num3 = skeletonRenderer3.skeleton.FindSlotIndex(slotName);
						if (Slot != null)
						{
							PolygonCollider2D[] components = GetComponents<PolygonCollider2D>();
							GameObject gameObject = base.gameObject;
							bool flag19 = (object)gameObject == null;
							enumerator = default(ExposedList<object>.Enumerator);
							collidersCount = 0;
							text2 = null;
							num = 0;
							text = null;
							obj = (UnityEngine.Object)num3;
							array = components;
							if (!flag19)
							{
								bool activeInHierarchy = gameObject.activeInHierarchy;
								bool flag20 = !activeInHierarchy;
								enumerator = default(ExposedList<object>.Enumerator);
								collidersCount = 0;
								text2 = null;
								num = 0;
								obj = (UnityEngine.Object)num3;
								array = components;
								if (flag20)
								{
									goto IL_0828;
								}
								SkeletonData data2 = skeleton.Data;
								bool flag21 = skeleton.Data == null;
								enumerator = default(ExposedList<object>.Enumerator);
								collidersCount = 0;
								text2 = null;
								num = 0;
								text = null;
								obj = (UnityEngine.Object)num3;
								array = components;
								if (!flag21)
								{
									bool flag22 = data2.Skins == null;
									enumerator = default(ExposedList<object>.Enumerator);
									collidersCount = 0;
									text2 = null;
									num = 0;
									text = null;
									obj = (UnityEngine.Object)num3;
									array = components;
									if (!flag22)
									{
										ExposedList<Skin>.Enumerator enumerator3 = data2.Skins.GetEnumerator();
										collidersCount = 0;
										num = 0;
										ExposedList<object>.Enumerator enumerator4 = default(ExposedList<object>.Enumerator);
										Skin skin = default(Skin);
										while (enumerator4.MoveNext())
										{
											AddCollidersForSkin(skin, num3, components, ref collidersCount);
											PolygonCollider2D[] array2 = components;
											object obj2 = collidersCount;
											num = num3;
										}
										enumerator4.Dispose();
										enumerator = enumerator4;
										enumerator2 = enumerator4;
										obj = (UnityEngine.Object)num3;
										array = components;
										goto IL_07be;
									}
								}
							}
						}
						else
						{
							if (!DebugMessages)
							{
								return;
							}
							GameObject gameObject2 = base.gameObject;
							bool flag23 = (object)gameObject2 == null;
							enumerator = default(ExposedList<object>.Enumerator);
							collidersCount = 0;
							text2 = null;
							num = 0;
							text = null;
							skeleton = (Skeleton)(object)slotName;
							array = (PolygonCollider2D[])27488256;
							if (!flag23)
							{
								string arg = gameObject2.name;
								message = $"Slot '{slotName}' not found for BoundingBoxFollower on '{arg}'. (Previous colliders were disposed.)";
								goto IL_0a51;
							}
						}
					}
				}
			}
			goto IL_093e;
			IL_0a51:
			Debug.LogWarning(message);
			return;
			IL_0828:
			DisposeExcessCollidersAfter(collidersCount);
			if (!DebugMessages)
			{
				return;
			}
			bool flag24 = colliderTable == null;
			text = (string)collidersCount;
			skeleton = (Skeleton)(object)typeof(BoundingBoxFollower);
			if (!flag24)
			{
				if (colliderTable.Count != 0)
				{
					return;
				}
				GameObject gameObject3 = base.gameObject;
				bool flag25 = (object)gameObject3 == null;
				text = null;
				skeleton = (Skeleton)(object)typeof(BoundingBoxFollower);
				if (!flag25)
				{
					message = ((!gameObject3.activeInHierarchy) ? "Bounding Box Follower tried to rebuild as a prefab." : ("Bounding Box Follower not valid! Slot [" + slotName + "] does not contain any Bounding Box Attachments!"));
					goto IL_0a51;
				}
			}
			goto IL_093e;
			IL_093e:
			NullReferenceException ex = new NullReferenceException();
			if ((nint)text == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj3 = default(object);
				bool flag26 = obj3 == null;
				enumerator2 = (ExposedList<object>.Enumerator)text2;
				if (!flag26)
				{
					throw new OutOfMemoryException();
				}
				goto IL_07be;
			}
			enumerator.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			((ExposedList<Skin>.Enumerator*)ex2)->Dispose();
		}

		[Token(Token = "0x60004E0")]
		[Address(RVA = "0x15558C8", Offset = "0x15558C8", Length = "0x480")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0048;\n\tv40 = Spine.BoundingBoxAttachment;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, skin, slotIndex, previousColliders, collidersCount, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv63 = Spine.Unity.BoundingBoxFollower;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, skin, slotIndex, previousColliders, collidersCount, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv202 = UnityEngine.Debug;\n\tv203 = \"il2cpp_codegen_initialize_runtime_metadata\"(v202, skin, slotIndex, previousColliders, collidersCount, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv251 = Il2CppMethodInfo;\n\tv252 = \"il2cpp_codegen_initialize_runtime_metadata\"(v251, skin, slotIndex, previousColliders, collidersCount, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv258 = Il2CppMethodInfo;\n\tv259 = \"il2cpp_codegen_initialize_runtime_metadata\"(v258, skin, slotIndex, previousColliders, collidersCount, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv262 = Il2CppMethodInfo;\n\tv263 = \"il2cpp_codegen_initialize_runtime_metadata\"(v262, skin, slotIndex, previousColliders, collidersCount, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv312 = Il2CppMethodInfo;\n\tv313 = \"il2cpp_codegen_initialize_runtime_metadata\"(v312, skin, slotIndex, previousColliders, collidersCount, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv318 = Il2CppMethodInfo;\n\tv319 = \"il2cpp_codegen_initialize_runtime_metadata\"(v318, skin, slotIndex, previousColliders, collidersCount, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv369 = Il2CppMethodInfo;\n\tv370 = \"il2cpp_codegen_initialize_runtime_metadata\"(v369, skin, slotIndex, previousColliders, collidersCount, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv381 = Il2CppMethodInfo;\n\tv382 = \"il2cpp_codegen_initialize_runtime_metadata\"(v381, skin, slotIndex, previousColliders, collidersCount, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv393 = Il2CppMethodInfo;\n\tv394 = \"il2cpp_codegen_initialize_runtime_metadata\"(v393, skin, slotIndex, previousColliders, collidersCount, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv400 = Il2CppMethodInfo;\n\tv401 = \"il2cpp_codegen_initialize_runtime_metadata\"(v400, skin, slotIndex, previousColliders, collidersCount, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv436 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>;\n\tv437 = \"il2cpp_codegen_initialize_runtime_metadata\"(v436, skin, slotIndex, previousColliders, collidersCount, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv460 = \"BoundingBoxFollower tried to follow a slot that contains non-boundingbox attachments: \";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v460, skin, slotIndex, previousColliders, collidersCount, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A37BF1]) = v56;\nL_0048:\n\tv61 = skin == 0;\n\tif (v61) goto L_012F;\n\tv70 = new System.Collections.Generic.List`1<Spine.Skin+SkinEntry>();\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>::.ctor(v70);\n\tSpine.Skin::GetAttachments(skin, slotIndex, v70);\n\tv260 = v70 == 0;\n\tif (v260) goto L_0137;\n\tv272 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>::GetEnumerator(v70);\nL_006E:\n\tv366 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::MoveNext(&v152 @ stack_-C0_v3 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\n\tv177 = v366 == 0;\n\tif (v177) goto L_0121;\n\tv387 = Spine.Skin::GetAttachment(skin, slotIndex, v383);\n\tv396 = v387 == 0;\n\tif (v396) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00A0;\n\tv451 = v451_asT == 0;\n\tif (v451) goto L_FFFFFFFF;\n\tgoto L_00A0;\nL_00A0:\n\tv455 = Spine.Unity.BoundingBoxFollower;\n\tv457 = *([v455 @ X0_v30 (Il2CppClass<Spine.Unity.BoundingBoxFollower>)+E0]) == 0;\n\tif (v457) goto L_00A9;\n\tv461 = v277 == 0;\n\tif (v461) goto L_00AC;\n\tgoto L_00C4;\nL_00A9:\n\tv468 = v277 == 0;\n\tv466 = ~v468;\n\tif (v466) goto L_00C4;\nL_00AC:\n\tv467 = v387 == 0;\n\tif (v467) goto L_00C4;\n\tv475 = ~v478.DebugMessages;\n\tif (v475) goto L_00C4;\n\tv485 = System.String::Concat(\"BoundingBoxFollower tried to follow a slot that contains non-boundingbox attachments: \", this.slotName);\n\tgoto L_00C3;\n\tv519 = \"il2cpp_codegen_runtime_class_init\"(v489, v482, v470, v344, collidersCount, methodInfo, v43, v44, v149, v146, v143, v48, v49, v50, v51, v52);\nL_00C3:\n\tUnityEngine.Debug::Log(v485);\nL_00C4:\n\tv358 = v277 == 0;\n\tif (v358) goto L_006E;\n\tv355 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::ContainsKey(this.colliderTable, v277);\n\tv492 = v355 == 0;\n\tv359 = ~v492;\n\tif (v359) goto L_006E;\n\tv628 = collidersCount->klass;\n\tv320 = *([collidersCount @ X4 (System.Int32&)]) >= previousColliders.Length;\n\tif (v320) goto L_00E7;\n\tgoto L_00F0;\nL_00E7:\n\tv571 = UnityEngine.Component::get_gameObject(this);\n\tv626 = UnityEngine.GameObject::AddComponent(v571);\n\tv628 = collidersCount->klass;\nL_00F0:\n\tv517 = v628 + 1;\n\t*([collidersCount @ X4 (System.Int32&)]) = v517;\n\tSpine.Unity.SkeletonUtility::SetColliderPointsLocal(v342, this.slot, v277, 1f);\n\tUnityEngine.Collider2D::set_isTrigger(v342, this.isTrigger);\n\tUnityEngine.Behaviour::set_enabled(v342, 0);\n\tUnityEngine.Object::set_hideFlags(v342, 8);\n\tUnityEngine.Collider2D::set_isTrigger(v342, this.isTrigger);\n\tSystem.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::Add(this.colliderTable, v277, v342);\n\tSystem.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, System.String>::Add(this.nameTable, v277, v383);\n\tgoto L_006E;\nL_0121:\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::Dispose(&v152 @ stack_-C0_v3 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\nL_012F:\n\treturn;\n\tv486 = new System.NullReferenceException();\n\tv518 = new System.NullReferenceException();\n\tv541 = new System.NullReferenceException();\n\tv568 = new System.NullReferenceException();\n\tv595 = new System.NullReferenceException();\n\tv617 = new System.NullReferenceException();\n\tv304 = new System.IndexOutOfRangeException();\nL_0137:\n\tv310 = new System.NullReferenceException();\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\n\tgoto L_0156;\nL_0156:\n\tv73 = v301 != 1;\n\tif (v73) goto L_0166;\n\tv373 = 0x1854E70(v310, v301, v169, v166, collidersCount, methodInfo, v43, v44, v150, v315, v316, v48, v49, v50, v51, v52);\n\tv389 = 0x1854E80(v373, v301, v169, v166, collidersCount, methodInfo, v43, v44, v150, v315, v316, v48, v49, v50, v51, v52);\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::Dispose(&v141 @ stack_-90_v3 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\n\tv178 = *([v373 @ X0_v17]) == 0;\n\tif (v178) goto L_012F;\n\tthrow System.OutOfMemoryException;\nL_0166:\n\tgoto L_016C;\n\tX19 = X0;\nL_016C:\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::Dispose(&v141 @ stack_-90_v3 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\n\tgoto L_0173;\n\tv431 = 0xBD3CD0(v310, Il2CppMethodInfo, v169, v166, collidersCount, methodInfo, v43, v44, v150, v315, v316, v48, v49, v50, v51, v52);\nL_0173:\n\tv434 = new System.OutOfMemoryException();\n\tv238 = 0x9DACB4(v434, Il2CppMethodInfo, v169, v166, collidersCount, methodInfo, v43, v44, v150, v315, v316, v48, v49, v50, v51, v52);\n\treturn;\n// 238 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void AddCollidersForSkin(Skin skin, int slotIndex, PolygonCollider2D[] previousColliders, ref int collidersCount)
		{
			//IL_03ac: Expected I, but got O
			//IL_01eb: Expected O, but got I4
			//IL_0251: Expected O, but got I4
			//IL_040b: Expected O, but got I
			if (skin == null)
			{
				return;
			}
			List<Skin.SkinEntry> list = new List<Skin.SkinEntry>();
			skin.GetAttachments(slotIndex, list);
			bool flag = list == null;
			List<Skin.SkinEntry>.Enumerator enumerator2 = default(List<Skin.SkinEntry>.Enumerator);
			List<Skin.SkinEntry>.Enumerator enumerator = enumerator2;
			if (!flag)
			{
				List<Skin.SkinEntry>.Enumerator enumerator3 = list.GetEnumerator();
				string value = default(string);
				while (enumerator2.MoveNext())
				{
					Attachment attachment = skin.GetAttachment(slotIndex, value);
					BoundingBoxAttachment boundingBoxAttachment;
					if (attachment == null)
					{
						boundingBoxAttachment = null;
					}
					else
					{
						BoundingBoxAttachment boundingBoxAttachment2 = attachment as BoundingBoxAttachment;
						boundingBoxAttachment = (BoundingBoxAttachment)((boundingBoxAttachment2 == null) ? null : attachment);
					}
					nint num = (nint)typeof(BoundingBoxFollower);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ X0_v30 (Il2CppClass<Spine.Unity.BoundingBoxFollower>)+E0]");
					if ((nint)0 != 0)
					{
						if (boundingBoxAttachment == null)
						{
							goto IL_0128;
						}
					}
					else if (boundingBoxAttachment == null)
					{
						goto IL_0128;
					}
					goto IL_0186;
					IL_0128:
					if (attachment != null && DebugMessages)
					{
						string message = "BoundingBoxFollower tried to follow a slot that contains non-boundingbox attachments: " + slotName;
						Debug.Log(message);
					}
					goto IL_0186;
					IL_0186:
					if (boundingBoxAttachment != null && !colliderTable.ContainsKey(boundingBoxAttachment))
					{
						object obj = collidersCount;
						PolygonCollider2D polygonCollider2D;
						if (collidersCount < previousColliders.Length)
						{
							polygonCollider2D = previousColliders[obj];
						}
						else
						{
							GameObject gameObject = base.gameObject;
							PolygonCollider2D polygonCollider2D2 = gameObject.AddComponent<PolygonCollider2D>();
							obj = collidersCount;
							polygonCollider2D = polygonCollider2D2;
						}
						object obj2 = (nint)obj + 1;
						ref int reference = ref *(int*)obj2;
						SkeletonUtility.SetColliderPointsLocal(polygonCollider2D, Slot, boundingBoxAttachment);
						polygonCollider2D.isTrigger = isTrigger;
						polygonCollider2D.enabled = false;
						polygonCollider2D.hideFlags = HideFlags.NotEditable;
						polygonCollider2D.isTrigger = isTrigger;
						colliderTable.Add(boundingBoxAttachment, polygonCollider2D);
						nameTable.Add(boundingBoxAttachment, value);
					}
				}
				enumerator2.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			int num2 = default(int);
			if (num2 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj3 = default(object);
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
		}

		[Token(Token = "0x60004E1")]
		[Address(RVA = "0x1555E38", Offset = "0x1555E38", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv42 = UnityEngine.Object;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv52 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A37BF2]) = v36;\nL_001A:\n\tv40 = ~this.clearStateOnDisable;\n\tif (v40) goto L_0023;\n\tSpine.Unity.BoundingBoxFollower::ClearState(this);\nL_0023:\n\tgoto L_0028;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0028:\n\tv58 = UnityEngine.Object::op_Inequality(this.skeletonRenderer, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_0047;\n\tv65 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v65, this, Il2CppMethodInfo);\n\tv86 = this.skeletonRenderer == 0;\n\tif (v86) goto L_0048;\n\tSpine.Unity.SkeletonRenderer::remove_OnRebuild(this.skeletonRenderer, v65);\n\treturn;\nL_0047:\n\treturn;\nL_0048:\n\tthrow v65;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (clearStateOnDisable)
			{
				ClearState();
			}
			if (skeletonRenderer != null)
			{
				SkeletonRenderer.SkeletonRendererDelegate skeletonRendererDelegate = HandleRebuild;
				if ((object)skeletonRenderer == null)
				{
					throw skeletonRendererDelegate;
				}
				skeletonRenderer.OnRebuild -= skeletonRendererDelegate;
			}
		}

		[Token(Token = "0x60004E2")]
		[Address(RVA = "0x1555F10", Offset = "0x1555F10", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv102 = Il2CppMethodInfo;\n\tv103 = \"il2cpp_codegen_initialize_runtime_metadata\"(v102, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv129 = Il2CppMethodInfo;\n\tv130 = \"il2cpp_codegen_initialize_runtime_metadata\"(v129, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv148 = Il2CppMethodInfo;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v148, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A37BF3]) = v36;\nL_001D:\n\tv37 = 0;\n\tv41 = this.colliderTable == 0;\n\tif (v41) goto L_0042;\n\tv48 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::get_Values(this.colliderTable);\n\tv104 = v48 == 0;\n\tif (v104) goto L_004C;\n\tv136 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+ValueCollection<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::GetEnumerator(v48);\nL_0034:\n\tv156 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v37 @ stack_-38_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv89 = v156 == 0;\n\tif (v89) goto L_0041;\n\tUnityEngine.Behaviour::set_enabled(0, 0);\n\tgoto L_0034;\nL_0041:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v37 @ stack_-38_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\nL_0042:\n\tthis.currentAttachment = 0;\n\tthis.currentAttachmentName = 0;\n\tthis.currentCollider = 0;\n\treturn;\n\tv141 = new System.NullReferenceException();\nL_004C:\n\tv146 = new System.NullReferenceException();\n\tgoto L_0059;\n\tgoto L_0059;\nL_0059:\n\tv51 = Il2CppMethodInfo != 1;\n\tif (v51) goto L_0069;\n\tv160 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+ValueCollection<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+Enumerator<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::MoveNext(v146);\n\tv167 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+ValueCollection<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+Enumerator<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::MoveNext(v160);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v37 @ stack_-38_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv90 = ~v160.m_value;\n\tif (v90) goto L_0042;\n\tthrow System.OutOfMemoryException;\nL_0069:\n\tgoto L_006F;\n\tX20 = X0;\nL_006F:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v37 @ stack_-38_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tgoto L_0076;\n\tv173 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+ValueCollection<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+Enumerator<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::Dispose(v146);\nL_0076:\n\tv176 = new System.OutOfMemoryException();\n\tv121 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+ValueCollection<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+Enumerator<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::Dispose(v176);\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void ClearState()
		{
			Dictionary<object, object>.ValueCollection.Enumerator enumerator = default(Dictionary<object, object>.ValueCollection.Enumerator);
			if (colliderTable != null)
			{
				Dictionary<BoundingBoxAttachment, PolygonCollider2D>.ValueCollection values = colliderTable.Values;
				if (values != null)
				{
					Dictionary<BoundingBoxAttachment, PolygonCollider2D>.ValueCollection.Enumerator enumerator2 = values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						((Behaviour)null).enabled = false;
					}
					enumerator.Dispose();
				}
				else
				{
					NullReferenceException ex = new NullReferenceException();
					if ((nint)0 != 1)
					{
						enumerator.Dispose();
						OutOfMemoryException ex2 = new OutOfMemoryException();
						((Dictionary<BoundingBoxAttachment, PolygonCollider2D>.ValueCollection.Enumerator*)ex2)->Dispose();
						return;
					}
					bool flag = ((Dictionary<BoundingBoxAttachment, PolygonCollider2D>.ValueCollection.Enumerator*)ex)->MoveNext();
					bool flag2 = (flag ? ((Dictionary<BoundingBoxAttachment, PolygonCollider2D>.ValueCollection.Enumerator*)1) : ((Dictionary<BoundingBoxAttachment, PolygonCollider2D>.ValueCollection.Enumerator*)null))->MoveNext();
					enumerator.Dispose();
					if (((bool*)(flag ? 1 : 0))->m_value)
					{
						throw new OutOfMemoryException();
					}
				}
			}
			currentAttachment = null;
			currentAttachmentName = null;
			currentCollider = null;
		}

		[Token(Token = "0x60004E3")]
		[Address(RVA = "0x1555D48", Offset = "0x1555D48", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, requiredCount, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv48 = UnityEngine.Object;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, requiredCount, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A37BF4]) = v43;\nL_001B:\n\tv46 = UnityEngine.Component::GetComponents(this);\n\tv52 = v46.Length == 0;\n\tif (v52) goto L_006B;\n\tv111 = v46.Length <= requiredCount;\n\tif (v111) goto L_006B;\nL_0044:\n\tgoto L_0049;\n\tv190 = \"il2cpp_codegen_runtime_class_init\"(v186, v56, v54, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0049:\n\tv194 = UnityEngine.Object::op_Inequality(v46[v98 @ X21_v6 (System.Int32)], 0);\n\tv196 = v194 == 0;\n\tif (v196) goto L_0057;\n\tgoto L_0055;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v197, v193, v113, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0055:\n\tUnityEngine.Object::Destroy(v46[v98 @ X21_v6 (System.Int32)]);\nL_0057:\n\tv98 = v98 + 1;\n\tv118 = v98 < v46.Length;\n\tif (v118) goto L_0044;\nL_006B:\n\treturn;\n\tv87 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DisposeExcessCollidersAfter(int requiredCount)
		{
			PolygonCollider2D[] components = GetComponents<PolygonCollider2D>();
			if (components.Length == 0 || components.Length <= requiredCount)
			{
				return;
			}
			int num = requiredCount;
			do
			{
				if (components[num] != null)
				{
					UnityEngine.Object.Destroy(components[num]);
				}
				num++;
			}
			while (num < components.Length);
		}

		[Token(Token = "0x60004E4")]
		[Address(RVA = "0x1556088", Offset = "0x1556088", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.slot;\n\tv2 = this.slot == 0;\n\tif (v2) goto L_0011;\n\tv9 = v0.attachment == this.currentAttachment;\n\tif (v9) goto L_0011;\n\tSpine.Unity.BoundingBoxFollower::MatchAttachment(this, v0.attachment);\n\treturn;\nL_0011:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdate()
		{
			Slot slot = Slot;
			if (Slot != null && slot.Attachment != CurrentAttachment)
			{
				MatchAttachment(slot.Attachment);
			}
		}

		[Token(Token = "0x60004E5")]
		[Address(RVA = "0x15560A8", Offset = "0x15560A8", Length = "0x2D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv24 = Spine.BoundingBoxAttachment;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv49 = Spine.Unity.BoundingBoxFollower;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv91 = UnityEngine.Debug;\n\tv92 = \"il2cpp_codegen_initialize_runtime_metadata\"(v91, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv131 = Il2CppMethodInfo;\n\tv132 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv143 = Il2CppMethodInfo;\n\tv144 = \"il2cpp_codegen_initialize_runtime_metadata\"(v143, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv164 = System.Object[];\n\tv165 = \"il2cpp_codegen_initialize_runtime_metadata\"(v164, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv174 = UnityEngine.Object;\n\tv175 = \"il2cpp_codegen_initialize_runtime_metadata\"(v174, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv182 = \"BoundingBoxFollower tried to match a non-boundingbox attachment. It will treat it as null.\";\n\tv183 = \"il2cpp_codegen_initialize_runtime_metadata\"(v182, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv196 = \"Collider for BoundingBoxAttachment named '{0}' was not initialized. It is possibly from a new skin. currentAttachmentName will be null. You may need to call BoundingBoxFollower.Initialize(overwrite: true);\";\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v196, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A37BF5]) = v43;\nL_0030:\n\tv47 = attachment == 0;\n\tif (v47) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_005B;\n\tv106 = v106_asT == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_005B;\nL_005B:\n\tgoto L_0062;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v126, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv135 = Spine.Unity.BoundingBoxFollower;\nL_0062:\n\tv140 = v123 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_007B;\n\tv145 = attachment == 0;\n\tif (v145) goto L_007B;\n\tv152 = ~v166.DebugMessages;\n\tif (v152) goto L_007B;\n\tgoto L_0075;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v176, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0075:\n\tUnityEngine.Debug::LogWarning(\"BoundingBoxFollower tried to match a non-boundingbox attachment. It will treat it as null.\");\nL_007B:\n\tgoto L_0080;\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v158, v146, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0080:\n\tv172 = UnityEngine.Object::op_Inequality(this.currentCollider, 0);\n\tv180 = v172 == 0;\n\tif (v180) goto L_008A;\n\tUnityEngine.Behaviour::set_enabled(this.currentCollider, 0);\nL_008A:\n\tv194 = v123 == 0;\n\tif (v194) goto L_00B5;\n\tv245 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::TryGetValue(this.colliderTable, v123, &v200 @ stack_-38_v6 (System.Object));\n\tgoto L_009F;\n\tv309 = \"il2cpp_codegen_runtime_class_init\"(v290, v244, v243, v198, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_009F:\n\tv312 = UnityEngine.Object::op_Inequality(v200, 0);\n\tv314 = v312 == 0;\n\tif (v314) goto L_00B9;\n\tthis.currentCollider = v200;\n\tUnityEngine.Behaviour::set_enabled(v200, 1);\n\tthis.currentAttachment = v123;\n\tv256 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, System.String>::get_Item(this.nameTable, v123);\n\tthis.currentAttachmentName = v256;\n\tgoto L_00F0;\nL_00B5:\n\tthis.currentAttachment = 0;\n\tthis.currentAttachmentName = 0;\n\tthis.currentCollider = 0;\n\tgoto L_00F0;\nL_00B9:\n\tthis.currentAttachmentName = 0;\n\tthis.currentCollider = 0;\n\tthis.currentAttachment = v123;\n\tgoto L_00C5;\n\tv319 = \"il2cpp_codegen_runtime_class_init\"(v315, v205, v202, v198, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv320 = Spine.Unity.BoundingBoxFollower;\nL_00C5:\n\tv260 = ~v321.DebugMessages;\n\tif (v260) goto L_00F0;\n\t// 203 NewArr v212 @ X0_v27 (System.Object[]), typeof(System.Object[]), 1\n\tv325 = v123.<Name>k__BackingField == 0;\n\tif (v325) goto L_00DB;\n\t// 213 IsInst v281 @ X0_v34, typeof(System.Object), v123.<Name>k__BackingField (System.String)\n\tv283 = v281 == 0;\n\tif (v283) goto L_00F3;\nL_00DB:\n\tv212[0] = v123.<Name>k__BackingField;\n\tgoto L_00E7;\n\tv332 = \"il2cpp_codegen_runtime_class_init\"(v329, v228, v202, v198, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00E7:\n\tUnityEngine.Debug::LogFormat(\"Collider for BoundingBoxAttachment named '{0}' was not initialized. It is possibly from a new skin. currentAttachmentName will be null. You may need to call BoundingBoxFollower.Initialize(overwrite: true);\", v212);\nL_00F0:\n\treturn;\n\tv223 = new System.NullReferenceException();\n\tv240 = new System.IndexOutOfRangeException();\nL_00F3:\n\tv289 = new System.ArrayTypeMismatchException();\n\tthrow v289;\n\treturn;\n// 158 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void MatchAttachment(Attachment attachment)
		{
			Attachment attachment2;
			if (attachment == null)
			{
				attachment2 = null;
			}
			else
			{
				BoundingBoxAttachment boundingBoxAttachment = attachment as BoundingBoxAttachment;
				attachment2 = ((boundingBoxAttachment == null) ? null : attachment);
			}
			if (attachment2 == null && attachment != null && DebugMessages)
			{
				Debug.LogWarning("BoundingBoxFollower tried to match a non-boundingbox attachment. It will treat it as null.");
			}
			if (CurrentCollider != null)
			{
				CurrentCollider.enabled = false;
			}
			if (attachment2 != null)
			{
				object value;
				bool flag = colliderTable.TryGetValue((BoundingBoxAttachment)attachment2, out *(PolygonCollider2D*)(&value));
				if ((UnityEngine.Object)value != null)
				{
					currentCollider = (PolygonCollider2D)value;
					((Behaviour)value).enabled = true;
					currentAttachment = (BoundingBoxAttachment)attachment2;
					string text = nameTable[(BoundingBoxAttachment)attachment2];
					currentAttachmentName = text;
					return;
				}
				currentAttachmentName = null;
				currentCollider = null;
				currentAttachment = (BoundingBoxAttachment)attachment2;
				if (!DebugMessages)
				{
					return;
				}
				object[] array = new object[1];
				if (attachment2.Name != null)
				{
					object obj = attachment2.Name as object;
					if (obj == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				array[0] = attachment2.Name;
				Debug.LogFormat("Collider for BoundingBoxAttachment named '{0}' was not initialized. It is possibly from a new skin. currentAttachmentName will be null. You may need to call BoundingBoxFollower.Initialize(overwrite: true);", array);
			}
			else
			{
				currentAttachment = null;
				currentAttachmentName = null;
				currentCollider = null;
			}
		}

		[Token(Token = "0x60004E6")]
		[Address(RVA = "0x1556378", Offset = "0x1556378", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv60 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv65 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, System.String>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37BF6]) = v50;\nL_0026:\n\tthis.clearStateOnDisable = 1;\n\tv53 = new System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>();\n\tSystem.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::.ctor(v53);\n\tthis.colliderTable = v53;\n\tv63 = new System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, System.String>::.ctor(v63);\n\tthis.nameTable = v63;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoundingBoxFollower()
		{
			clearStateOnDisable = true;
			Dictionary<BoundingBoxAttachment, PolygonCollider2D> dictionary = new Dictionary<BoundingBoxAttachment, PolygonCollider2D>();
			colliderTable = dictionary;
			Dictionary<BoundingBoxAttachment, string> dictionary2 = new Dictionary<BoundingBoxAttachment, string>();
			nameTable = dictionary2;
		}
	}
}
