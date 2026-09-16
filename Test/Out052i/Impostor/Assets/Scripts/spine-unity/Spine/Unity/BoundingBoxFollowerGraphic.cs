using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[ExecuteAlways]
	[HelpURL("http://esotericsoftware.com/spine-unity#BoundingBoxFollowerGraphic")]
	[Token(Token = "0x2000078")]
	public class BoundingBoxFollowerGraphic : MonoBehaviour
	{
		[Token(Token = "0x40002E9")]
		internal static bool DebugMessages = true;

		[Token(Token = "0x40002EA")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonGraphic skeletonGraphic;

		[SpineSlot(null, "skeletonGraphic", true, true, false)]
		[Token(Token = "0x40002EB")]
		[FieldOffset(Offset = "0x28")]
		public string slotName;

		[Token(Token = "0x40002EC")]
		[FieldOffset(Offset = "0x30")]
		public bool isTrigger;

		[Token(Token = "0x40002ED")]
		[FieldOffset(Offset = "0x31")]
		public bool clearStateOnDisable;

		[Token(Token = "0x40002EE")]
		[FieldOffset(Offset = "0x38")]
		private Slot slot;

		[Token(Token = "0x40002EF")]
		[FieldOffset(Offset = "0x40")]
		private BoundingBoxAttachment currentAttachment;

		[Token(Token = "0x40002F0")]
		[FieldOffset(Offset = "0x48")]
		private string currentAttachmentName;

		[Token(Token = "0x40002F1")]
		[FieldOffset(Offset = "0x50")]
		private PolygonCollider2D currentCollider;

		[Token(Token = "0x40002F2")]
		[FieldOffset(Offset = "0x58")]
		public readonly Dictionary<BoundingBoxAttachment, PolygonCollider2D> colliderTable;

		[Token(Token = "0x40002F3")]
		[FieldOffset(Offset = "0x60")]
		public readonly Dictionary<BoundingBoxAttachment, string> nameTable;

		[Token(Token = "0x17000185")]
		public Slot Slot
		{
			[Token(Token = "0x60004E8")]
			[Address(RVA = "0x1556490", Offset = "0x1556490", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.slot;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Slot;
			}
		}

		[Token(Token = "0x17000186")]
		public BoundingBoxAttachment CurrentAttachment
		{
			[Token(Token = "0x60004E9")]
			[Address(RVA = "0x1556498", Offset = "0x1556498", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.currentAttachment;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CurrentAttachment;
			}
		}

		[Token(Token = "0x17000187")]
		public string CurrentAttachmentName
		{
			[Token(Token = "0x60004EA")]
			[Address(RVA = "0x15564A0", Offset = "0x15564A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.currentAttachmentName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CurrentAttachmentName;
			}
		}

		[Token(Token = "0x17000188")]
		public PolygonCollider2D CurrentCollider
		{
			[Token(Token = "0x60004EB")]
			[Address(RVA = "0x15564A8", Offset = "0x15564A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.currentCollider;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CurrentCollider;
			}
		}

		[Token(Token = "0x17000189")]
		public bool IsTrigger
		{
			[Token(Token = "0x60004EC")]
			[Address(RVA = "0x15564B0", Offset = "0x15564B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isTrigger;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return isTrigger;
			}
		}

		[Token(Token = "0x60004ED")]
		[Address(RVA = "0x15564B8", Offset = "0x15564B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.BoundingBoxFollowerGraphic::Initialize(this, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Initialize();
		}

		[Token(Token = "0x60004EE")]
		[Address(RVA = "0x1556A50", Offset = "0x1556A50", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv49 = UnityEngine.Object;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv58 = Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37BF8]) = v42;\nL_0020:\n\tgoto L_0025;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv56 = UnityEngine.Object::op_Inequality(this.skeletonGraphic, 0);\n\tv60 = v56 == 0;\n\tif (v60) goto L_004E;\n\tv113 = new Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonGraphic+SkeletonRendererDelegate::.ctor(v113, this, Il2CppMethodInfo);\n\tv93 = this.skeletonGraphic == 0;\n\tif (v93) goto L_0050;\n\tSpine.Unity.SkeletonGraphic::remove_OnRebuild(this.skeletonGraphic, v113);\n\tv113 = new Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonGraphic+SkeletonRendererDelegate::.ctor(v113, this, Il2CppMethodInfo);\n\tv77 = this.skeletonGraphic == 0;\n\tif (v77) goto L_0050;\n\tSpine.Unity.SkeletonGraphic::add_OnRebuild(this.skeletonGraphic, v113);\nL_004E:\n\tSpine.Unity.BoundingBoxFollowerGraphic::Initialize(this, 0);\n\treturn;\nL_0050:\n\tthrow v113;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			if (skeletonGraphic != null)
			{
				SkeletonGraphic.SkeletonRendererDelegate skeletonRendererDelegate = HandleRebuild;
				if ((object)skeletonGraphic != null)
				{
					skeletonGraphic.OnRebuild -= skeletonRendererDelegate;
					skeletonRendererDelegate = HandleRebuild;
					if ((object)skeletonGraphic != null)
					{
						skeletonGraphic.OnRebuild += skeletonRendererDelegate;
						goto IL_00c1;
					}
				}
				throw skeletonRendererDelegate;
			}
			goto IL_00c1;
			IL_00c1:
			Initialize();
		}

		[Token(Token = "0x60004EF")]
		[Address(RVA = "0x1556D8C", Offset = "0x1556D8C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.BoundingBoxFollowerGraphic::Initialize(this, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleRebuild(SkeletonGraphic sr)
		{
			Initialize();
		}

		[Token(Token = "0x60004F0")]
		[Address(RVA = "0x15564C0", Offset = "0x15564C0", Length = "0x590")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004B;\n\tv28 = Spine.Unity.BoundingBoxFollowerGraphic;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv73 = UnityEngine.Debug;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv227 = Il2CppMethodInfo;\n\tv228 = \"il2cpp_codegen_initialize_runtime_metadata\"(v227, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv374 = Il2CppMethodInfo;\n\tv375 = \"il2cpp_codegen_initialize_runtime_metadata\"(v374, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv378 = Il2CppMethodInfo;\n\tv379 = \"il2cpp_codegen_initialize_runtime_metadata\"(v378, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv384 = Il2CppMethodInfo;\n\tv385 = \"il2cpp_codegen_initialize_runtime_metadata\"(v384, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv402 = Il2CppMethodInfo;\n\tv403 = \"il2cpp_codegen_initialize_runtime_metadata\"(v402, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv413 = Il2CppMethodInfo;\n\tv414 = \"il2cpp_codegen_initialize_runtime_metadata\"(v413, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv421 = Il2CppMethodInfo;\n\tv422 = \"il2cpp_codegen_initialize_runtime_metadata\"(v421, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv431 = UnityEngine.Object;\n\tv432 = \"il2cpp_codegen_initialize_runtime_metadata\"(v431, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv480 = \"Slot '{0}' not found for BoundingBoxFollowerGraphic on '{1}'. (Previous colliders were disposed.)\";\n\tv481 = \"il2cpp_codegen_initialize_runtime_metadata\"(v480, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv497 = \"Bounding Box Follower tried to rebuild as a prefab.\";\n\tv498 = \"il2cpp_codegen_initialize_runtime_metadata\"(v497, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv505 = \"] does not contain any Bounding Box Attachments!\";\n\tv506 = \"il2cpp_codegen_initialize_runtime_metadata\"(v505, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv516 = \"Bounding Box Follower not valid! Slot [\";\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v516, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A37BF9]) = v47;\nL_004B:\n\tv217 = this.skeletonGraphic;\n\tgoto L_0053;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v48, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0053:\n\tv65 = UnityEngine.Object::op_Equality(this.skeletonGraphic, 0);\n\tv70 = v65 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0192;\n\tv76 = this.skeletonGraphic == 0;\n\tif (v76) goto L_019F;\n\tSpine.Unity.SkeletonGraphic::Initialize(this.skeletonGraphic, 0);\n\tv183 = System.String::IsNullOrEmpty(this.slotName);\n\tv381 = v183 == 0;\n\tv191 = ~v381;\n\tif (v191) goto L_0192;\n\tv387 = overwrite == 0;\n\tv388 = ~v387;\n\tif (v388) goto L_009F;\n\tv296 = this.colliderTable == 0;\n\tif (v296) goto L_019F;\n\tv405 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::get_Count(this.colliderTable);\n\tv249 = v405 < 1;\n\tif (v249) goto L_009F;\n\tv407 = this.slot == 0;\n\tif (v407) goto L_009F;\n\tv316 = this.skeletonGraphic;\n\tv297 = this.skeletonGraphic == 0;\n\tif (v297) goto L_019F;\n\tv472 = v316.skeleton;\n\tv284 = Spine.Slot::get_Skeleton(this.slot);\n\tv116 = v316.skeleton != v284;\n\tif (v116) goto L_009F;\n\tv317 = this.slot;\n\tv298 = this.slot == 0;\n\tif (v298) goto L_019F;\n\tv207 = v317.data;\n\tv299 = v317.data == 0;\n\tif (v299) goto L_019F;\n\tv176 = v207.name;\n\tv184 = System.String::op_Equality(this.slotName, v207.name);\n\tv534 = v184 == 0;\n\tv192 = ~v534;\n\tif (v192) goto L_0192;\nL_009F:\n\tthis.currentAttachmentName = 0;\n\tthis.slot = 0;\n\tv300 = this.colliderTable == 0;\n\tif (v300) goto L_019F;\n\tSystem.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::Clear(this.colliderTable);\n\tv301 = this.nameTable == 0;\n\tif (v301) goto L_019F;\n\tSystem.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, System.String>::Clear(this.nameTable);\n\tv208 = this.skeletonGraphic;\n\tv302 = this.skeletonGraphic == 0;\n\tif (v302) goto L_019F;\n\tv472 = v208.skeleton;\n\tv193 = v208.skeleton == 0;\n\tif (v193) goto L_0192;\n\tv511 = Spine.Skeleton::FindSlot(v208.skeleton, this.slotName);\n\tthis.slot = v511;\n\tv518 = Spine.Skeleton::FindSlotIndex(v208.skeleton, this.slotName);\n\tv520 = this.slot == 0;\n\tif (v520) goto L_0108;\n\tv526 = UnityEngine.Component::GetComponents(this);\n\tv286 = UnityEngine.Component::get_gameObject(this);\n\tv303 = v286 == 0;\n\tif (v303) goto L_019F;\n\tv490 = UnityEngine.GameObject::get_activeInHierarchy(v286);\n\tv492 = v490 == 0;\n\tif (v492) goto L_0151;\n\tv304 = this.skeletonGraphic == 0;\n\tif (v304) goto L_019F;\n\tv572 = UnityEngine.UI.Graphic::get_canvas(this.skeletonGraphic);\n\tgoto L_00E2;\n\tv620 = v321;\n\tv621 = \"il2cpp_codegen_runtime_class_init\"(v620, v571, v172, v31, v32, v33, v34, v35, v111, v37, v38, v39, v40, v41, v42, v43);\nL_00E2:\n\tv624 = UnityEngine.Object::op_Equality(v572, 0);\n\tv626 = v624 == 0;\n\tif (v626) goto L_00F2;\n\tv305 = this.skeletonGraphic == 0;\n\tif (v305) goto L_019F;\n\tv631 = UnityEngine.Component::GetComponentInParent(this.skeletonGraphic);\nL_00F2:\n\tgoto L_00F7;\n\tv639 = \"il2cpp_codegen_runtime_class_init\"(v635, v628, v267, v31, v32, v33, v34, v35, v111, v37, v38, v39, v40, v41, v42, v43);\nL_00F7:\n\tv289 = UnityEngine.Object::op_Inequality(v241, 0);\n\tv643 = v289 == 0;\n\tif (v643) goto L_FFFFFFFF;\n\tv306 = v241 == 0;\n\tif (v306) goto L_019F;\n\tv112 = UnityEngine.Canvas::get_referencePixelsPerUnit(v241);\n\tgoto L_0122;\nL_0108:\n\tgoto L_010D;\n\tv536 = \"il2cpp_codegen_runtime_class_init\"(v528, v179, v172, v31, v32, v33, v34, v35, v111, v37, v38, v39, v40, v41, v42, v43);\n\tv537 = Spine.Unity.BoundingBoxFollowerGraphic;\nL_010D:\n\tv195 = ~v538.DebugMessages;\n\tif (v195) goto L_0192;\n\tv290 = UnityEngine.Component::get_gameObject(this);\n\tv307 = v290 == 0;\n\tif (v307) goto L_019F;\n\tv545 = UnityEngine.Object::get_name(v290);\n\tv182 = System.String::Format(\"Slot '{0}' not found for BoundingBoxFollowerGraphic on '{1}'. (Previous colliders were disposed.)\", this.slotName, v545);\n\tgoto L_0183;\nL_0122:\n\tv323 = v472.data;\n\tv311 = v472.data == 0;\n\tif (v311) goto L_019F;\n\tv308 = v323.skins == 0;\n\tif (v308) goto L_019F;\n\tv656 = Spine.ExposedList`1<Spine.Skin>::GetEnumerator(v323.skins);\nL_0135:\n\tv673 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v443 @ stack_-78_v7 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv471 = v673 == 0;\n\tif (v471) goto L_0145;\n\tSpine.Unity.BoundingBoxFollowerGraphic::AddCollidersForSkin(this, v659, v518, v526, v95, &v244 @ stack_-44_v4 (System.Int32));\n\tgoto L_0135;\nL_0145:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v443 @ stack_-78_v7 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_0147:\n\tv478 = v472.skin == 0;\n\tif (v478) goto L_0151;\n\tSpine.Unity.BoundingBoxFollowerGraphic::AddCollidersForSkin(this, v472.skin, v217, v105, v95, &v244 @ stack_-44_v4 (System.Int32));\nL_0151:\n\tSpine.Unity.BoundingBoxFollowerGraphic::DisposeExcessCollidersAfter(this, v244);\n\tgoto L_015D;\n\tv512 = \"il2cpp_codegen_runtime_class_init\"(v500, v180, v171, v92, v79, v33, v34, v35, v112, v37, v38, v39, v40, v41, v42, v43);\n\tv513 = Spine.Unity.BoundingBoxFollowerGraphic;\nL_015D:\n\tv196 = ~v514.DebugMessages;\n\tif \n// ... truncated")]
		public unsafe void Initialize(bool overwrite = false)
		{
			//IL_0077: Expected O, but got I4
			//IL_03be: Expected O, but got I4
			//IL_0149: Expected O, but got I4
			//IL_0968: Expected I4, but got O
			//IL_0970: Expected O, but got I4
			//IL_0988: Expected I4, but got O
			//IL_040a: Expected O, but got I
			//IL_0412: Expected O, but got I4
			//IL_0184: Expected O, but got I
			//IL_09b5: Expected O, but got I4
			//IL_0468: Expected O, but got I
			//IL_0470: Expected O, but got I4
			//IL_01ba: Expected O, but got I
			//IL_020d: Expected O, but got I
			//IL_0215: Expected O, but got I4
			//IL_0270: Expected I4, but got O
			//IL_056d: Expected O, but got I4
			//IL_05cc: Expected O, but got I4
			//IL_036d: Expected I4, but got O
			//IL_0625: Expected O, but got I4
			//IL_06c5: Expected O, but got I4
			//IL_0baa: Expected O, but got I4
			//IL_0763: Expected O, but got I4
			//IL_0883: Expected O, but got I4
			//IL_08b4: Expected F4, but got O
			//IL_0922: Expected O, but got I4
			//IL_08e4: Expected O, but got I4
			UnityEngine.Object obj = this.skeletonGraphic;
			if (this.skeletonGraphic == null)
			{
				return;
			}
			bool flag = (object)this.skeletonGraphic == null;
			ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
			int collidersCount = 0;
			int num = 0;
			string text = null;
			Skeleton skeleton = (Skeleton)overwrite;
			bool flag4;
			if (!flag)
			{
				this.skeletonGraphic.Initialize(overwrite: false);
				if (string.IsNullOrEmpty(slotName))
				{
					return;
				}
				bool flag2 = !overwrite;
				bool flag3 = !flag2;
				num = 0;
				text = null;
				flag4 = overwrite;
				if (!flag3)
				{
					bool flag5 = colliderTable == null;
					enumerator = default(ExposedList<object>.Enumerator);
					collidersCount = 0;
					num = 0;
					text = null;
					skeleton = (Skeleton)overwrite;
					if (flag5)
					{
						goto IL_0aa3;
					}
					int count = colliderTable.Count;
					bool flag6 = count < 1;
					num = 0;
					text = (string)0;
					flag4 = overwrite;
					if (!flag6)
					{
						bool flag7 = Slot == null;
						num = 0;
						text = (string)0;
						flag4 = overwrite;
						if (!flag7)
						{
							SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
							bool flag8 = (object)this.skeletonGraphic == null;
							enumerator = default(ExposedList<object>.Enumerator);
							collidersCount = 0;
							num = 0;
							text = (string)0;
							skeleton = (Skeleton)overwrite;
							if (!flag8)
							{
								skeleton = skeletonGraphic.Skeleton;
								Skeleton skeleton2 = Slot.Skeleton;
								bool flag9 = skeletonGraphic.Skeleton != skeleton2;
								num = 0;
								text = null;
								flag4 = (byte)(int)skeletonGraphic.Skeleton != 0;
								if (flag9)
								{
									goto IL_037b;
								}
								Slot slot = Slot;
								bool flag10 = Slot == null;
								enumerator = default(ExposedList<object>.Enumerator);
								collidersCount = 0;
								num = 0;
								text = null;
								if (!flag10)
								{
									SlotData data = slot.Data;
									bool flag11 = slot.Data == null;
									enumerator = default(ExposedList<object>.Enumerator);
									collidersCount = 0;
									num = 0;
									text = null;
									if (!flag11)
									{
										text = data.Name;
										bool flag12 = slotName == data.Name;
										bool flag13 = !flag12;
										bool flag14 = !flag13;
										num = 0;
										flag4 = (byte)(int)skeletonGraphic.Skeleton != 0;
										if (!flag14)
										{
											goto IL_037b;
										}
										return;
									}
								}
							}
							goto IL_0aa3;
						}
					}
				}
				goto IL_037b;
			}
			goto IL_0aa3;
			IL_0c16:
			string message;
			Debug.LogWarning(message);
			return;
			IL_037b:
			currentAttachmentName = null;
			this.slot = null;
			bool flag15 = colliderTable == null;
			enumerator = default(ExposedList<object>.Enumerator);
			collidersCount = 0;
			float num2 = 0f;
			skeleton = (Skeleton)flag4;
			PolygonCollider2D[] array = default(PolygonCollider2D[]);
			float num4 = default(float);
			if (!flag15)
			{
				colliderTable.Clear();
				bool flag16 = nameTable == null;
				enumerator = default(ExposedList<object>.Enumerator);
				collidersCount = 0;
				num2 = 0f;
				text = (string)0;
				skeleton = (Skeleton)flag4;
				if (!flag16)
				{
					nameTable.Clear();
					SkeletonGraphic skeletonGraphic2 = this.skeletonGraphic;
					bool flag17 = (object)this.skeletonGraphic == null;
					enumerator = default(ExposedList<object>.Enumerator);
					collidersCount = 0;
					num2 = 0f;
					text = (string)0;
					skeleton = (Skeleton)flag4;
					if (!flag17)
					{
						skeleton = skeletonGraphic2.Skeleton;
						if (skeletonGraphic2.Skeleton == null)
						{
							return;
						}
						Slot slot2 = skeletonGraphic2.Skeleton.FindSlot(slotName);
						this.slot = slot2;
						int num3 = skeletonGraphic2.Skeleton.FindSlotIndex(slotName);
						if (Slot != null)
						{
							PolygonCollider2D[] components = GetComponents<PolygonCollider2D>();
							GameObject gameObject = base.gameObject;
							bool flag18 = (object)gameObject == null;
							enumerator = default(ExposedList<object>.Enumerator);
							array = components;
							collidersCount = 0;
							num2 = 0f;
							num = 0;
							text = null;
							obj = (UnityEngine.Object)num3;
							if (!flag18)
							{
								bool activeInHierarchy = gameObject.activeInHierarchy;
								bool flag19 = !activeInHierarchy;
								enumerator = default(ExposedList<object>.Enumerator);
								array = components;
								collidersCount = 0;
								num2 = 0f;
								num = 0;
								obj = (UnityEngine.Object)num3;
								if (flag19)
								{
									goto IL_098d;
								}
								bool flag20 = (object)this.skeletonGraphic == null;
								enumerator = default(ExposedList<object>.Enumerator);
								array = components;
								collidersCount = 0;
								num2 = 0f;
								num = 0;
								text = null;
								obj = (UnityEngine.Object)num3;
								if (!flag20)
								{
									Canvas canvas = this.skeletonGraphic.canvas;
									bool flag21 = canvas == null;
									bool flag22 = !flag21;
									Canvas canvas2 = canvas;
									if (!flag22)
									{
										bool flag23 = (object)this.skeletonGraphic == null;
										enumerator = default(ExposedList<object>.Enumerator);
										array = components;
										collidersCount = 0;
										num2 = 0f;
										num = 0;
										text = null;
										obj = (UnityEngine.Object)num3;
										if (flag23)
										{
											goto IL_0aa3;
										}
										Canvas componentInParent = this.skeletonGraphic.GetComponentInParent<Canvas>();
										canvas2 = componentInParent;
									}
									UnityEngine.Object obj2;
									if (canvas2 != null)
									{
										bool flag24 = (object)canvas2 == null;
										enumerator = default(ExposedList<object>.Enumerator);
										array = components;
										collidersCount = 0;
										num2 = 0f;
										num = 0;
										text = null;
										obj = (UnityEngine.Object)num3;
										if (flag24)
										{
											goto IL_0aa3;
										}
										num2 = canvas2.referencePixelsPerUnit;
										num4 = num2;
										obj2 = null;
									}
									else
									{
										num4 = 100f;
										num2 = 0f;
										obj2 = null;
									}
									SkeletonData data2 = skeleton.Data;
									bool flag25 = skeleton.Data == null;
									enumerator = default(ExposedList<object>.Enumerator);
									array = components;
									collidersCount = 0;
									num = 0;
									text = (string)(object)obj2;
									obj = (UnityEngine.Object)num3;
									if (!flag25)
									{
										bool flag26 = data2.Skins == null;
										enumerator = default(ExposedList<object>.Enumerator);
										array = components;
										collidersCount = 0;
										num = 0;
										text = (string)(object)obj2;
										obj = (UnityEngine.Object)num3;
										if (!flag26)
										{
											ExposedList<Skin>.Enumerator enumerator2 = data2.Skins.GetEnumerator();
											collidersCount = 0;
											ExposedList<object>.Enumerator enumerator3 = default(ExposedList<object>.Enumerator);
											num2 = (float)enumerator3;
											num = 0;
											Skin skin = default(Skin);
											while (enumerator3.MoveNext())
											{
												AddCollidersForSkin(skin, num3, components, num4, ref collidersCount);
												object obj3 = collidersCount;
												PolygonCollider2D[] array2 = components;
												num2 = num4;
												num = num3;
											}
											enumerator3.Dispose();
											enumerator = enumerator3;
											array = components;
											obj = (UnityEngine.Object)num3;
											goto IL_0927;
										}
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
							bool flag27 = (object)gameObject2 == null;
							enumerator = default(ExposedList<object>.Enumerator);
							collidersCount = 0;
							num2 = 0f;
							num = 0;
							text = null;
							skeleton = (Skeleton)(object)slotName;
							if (!flag27)
							{
								string arg = gameObject2.name;
								message = $"Slot '{slotName}' not found for BoundingBoxFollowerGraphic on '{arg}'. (Previous colliders were disposed.)";
								goto IL_0c16;
							}
						}
					}
				}
			}
			goto IL_0aa3;
			IL_0927:
			if (skeleton.Skin != null)
			{
				AddCollidersForSkin(skeleton.Skin, (int)obj, array, num4, ref collidersCount);
				object obj3 = collidersCount;
				PolygonCollider2D[] array2 = array;
				num2 = num4;
				num = (int)obj;
			}
			goto IL_098d;
			IL_098d:
			DisposeExcessCollidersAfter(collidersCount);
			if (!DebugMessages)
			{
				return;
			}
			bool flag28 = colliderTable == null;
			text = (string)collidersCount;
			skeleton = (Skeleton)(object)typeof(BoundingBoxFollowerGraphic);
			if (!flag28)
			{
				if (colliderTable.Count != 0)
				{
					return;
				}
				GameObject gameObject3 = base.gameObject;
				bool flag29 = (object)gameObject3 == null;
				text = null;
				skeleton = (Skeleton)(object)typeof(BoundingBoxFollowerGraphic);
				if (!flag29)
				{
					message = ((!gameObject3.activeInHierarchy) ? "Bounding Box Follower tried to rebuild as a prefab." : ("Bounding Box Follower not valid! Slot [" + slotName + "] does not contain any Bounding Box Attachments!"));
					goto IL_0c16;
				}
			}
			goto IL_0aa3;
			IL_0aa3:
			NullReferenceException ex = new NullReferenceException();
			if ((nint)text == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj4 = default(object);
				if (obj4 != null)
				{
					throw new OutOfMemoryException();
				}
				goto IL_0927;
			}
			enumerator.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			((ExposedList<Skin>.Enumerator*)ex2)->Dispose();
		}

		[Token(Token = "0x60004F1")]
		[Address(RVA = "0x1557138", Offset = "0x1557138", Length = "0x48C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004A;\n\tv44 = Spine.BoundingBoxAttachment;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, skin, slotIndex, previousColliders, collidersCount, methodInfo, v47, v48, scale, v49, v50, v51, v52, v53, v54, v55);\n\tv66 = Spine.Unity.BoundingBoxFollowerGraphic;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, skin, slotIndex, previousColliders, collidersCount, methodInfo, v47, v48, scale, v49, v50, v51, v52, v53, v54, v55);\n\tv206 = UnityEngine.Debug;\n\tv207 = \"il2cpp_codegen_initialize_runtime_metadata\"(v206, skin, slotIndex, previousColliders, collidersCount, methodInfo, v47, v48, scale, v49, v50, v51, v52, v53, v54, v55);\n\tv256 = Il2CppMethodInfo;\n\tv257 = \"il2cpp_codegen_initialize_runtime_metadata\"(v256, skin, slotIndex, previousColliders, collidersCount, methodInfo, v47, v48, scale, v49, v50, v51, v52, v53, v54, v55);\n\tv263 = Il2CppMethodInfo;\n\tv264 = \"il2cpp_codegen_initialize_runtime_metadata\"(v263, skin, slotIndex, previousColliders, collidersCount, methodInfo, v47, v48, scale, v49, v50, v51, v52, v53, v54, v55);\n\tv267 = Il2CppMethodInfo;\n\tv268 = \"il2cpp_codegen_initialize_runtime_metadata\"(v267, skin, slotIndex, previousColliders, collidersCount, methodInfo, v47, v48, scale, v49, v50, v51, v52, v53, v54, v55);\n\tv317 = Il2CppMethodInfo;\n\tv318 = \"il2cpp_codegen_initialize_runtime_metadata\"(v317, skin, slotIndex, previousColliders, collidersCount, methodInfo, v47, v48, scale, v49, v50, v51, v52, v53, v54, v55);\n\tv323 = Il2CppMethodInfo;\n\tv324 = \"il2cpp_codegen_initialize_runtime_metadata\"(v323, skin, slotIndex, previousColliders, collidersCount, methodInfo, v47, v48, scale, v49, v50, v51, v52, v53, v54, v55);\n\tv374 = Il2CppMethodInfo;\n\tv375 = \"il2cpp_codegen_initialize_runtime_metadata\"(v374, skin, slotIndex, previousColliders, collidersCount, methodInfo, v47, v48, scale, v49, v50, v51, v52, v53, v54, v55);\n\tv386 = Il2CppMethodInfo;\n\tv387 = \"il2cpp_codegen_initialize_runtime_metadata\"(v386, skin, slotIndex, previousColliders, collidersCount, methodInfo, v47, v48, scale, v49, v50, v51, v52, v53, v54, v55);\n\tv398 = Il2CppMethodInfo;\n\tv399 = \"il2cpp_codegen_initialize_runtime_metadata\"(v398, skin, slotIndex, previousColliders, collidersCount, methodInfo, v47, v48, scale, v49, v50, v51, v52, v53, v54, v55);\n\tv405 = Il2CppMethodInfo;\n\tv406 = \"il2cpp_codegen_initialize_runtime_metadata\"(v405, skin, slotIndex, previousColliders, collidersCount, methodInfo, v47, v48, scale, v49, v50, v51, v52, v53, v54, v55);\n\tv441 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>;\n\tv442 = \"il2cpp_codegen_initialize_runtime_metadata\"(v441, skin, slotIndex, previousColliders, collidersCount, methodInfo, v47, v48, scale, v49, v50, v51, v52, v53, v54, v55);\n\tv465 = \"BoundingBoxFollowerGraphic tried to follow a slot that contains non-boundingbox attachments: \";\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v465, skin, slotIndex, previousColliders, collidersCount, methodInfo, v47, v48, scale, v49, v50, v51, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A37BFA]) = v59;\nL_004A:\n\tv64 = skin == 0;\n\tif (v64) goto L_0132;\n\tv73 = new System.Collections.Generic.List`1<Spine.Skin+SkinEntry>();\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>::.ctor(v73);\n\tSpine.Skin::GetAttachments(skin, slotIndex, v73);\n\tv265 = v73 == 0;\n\tif (v265) goto L_013A;\n\tv277 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>::GetEnumerator(v73);\nL_0070:\n\tv371 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::MoveNext(&v155 @ stack_-D0_v3 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\n\tv180 = v371 == 0;\n\tif (v180) goto L_0123;\n\tv392 = Spine.Skin::GetAttachment(skin, slotIndex, v388);\n\tv401 = v392 == 0;\n\tif (v401) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00A2;\n\tv456 = v456_asT == 0;\n\tif (v456) goto L_FFFFFFFF;\n\tgoto L_00A2;\nL_00A2:\n\tv460 = Spine.Unity.BoundingBoxFollowerGraphic;\n\tv462 = *([v460 @ X0_v30 (Il2CppClass<Spine.Unity.BoundingBoxFollowerGraphic>)+E0]) == 0;\n\tif (v462) goto L_00AB;\n\tv466 = v282 == 0;\n\tif (v466) goto L_00AE;\n\tgoto L_00C6;\nL_00AB:\n\tv473 = v282 == 0;\n\tv471 = ~v473;\n\tif (v471) goto L_00C6;\nL_00AE:\n\tv472 = v392 == 0;\n\tif (v472) goto L_00C6;\n\tv480 = ~v483.DebugMessages;\n\tif (v480) goto L_00C6;\n\tv490 = System.String::Concat(\"BoundingBoxFollowerGraphic tried to follow a slot that contains non-boundingbox attachments: \", this.slotName);\n\tgoto L_00C5;\n\tv524 = \"il2cpp_codegen_runtime_class_init\"(v494, v487, v475, v349, collidersCount, methodInfo, v47, v48, v152, v149, v146, v51, v52, v53, v54, v55);\nL_00C5:\n\tUnityEngine.Debug::Log(v490);\nL_00C6:\n\tv363 = v282 == 0;\n\tif (v363) goto L_0070;\n\tv360 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::ContainsKey(this.colliderTable, v282);\n\tv497 = v360 == 0;\n\tv364 = ~v497;\n\tif (v364) goto L_0070;\n\tv633 = collidersCount->klass;\n\tv325 = *([collidersCount @ X4 (System.Int32&)]) >= previousColliders.Length;\n\tif (v325) goto L_00E9;\n\tgoto L_00F2;\nL_00E9:\n\tv576 = UnityEngine.Component::get_gameObject(this);\n\tv631 = UnityEngine.GameObject::AddComponent(v576);\n\tv633 = collidersCount->klass;\nL_00F2:\n\tv522 = v633 + 1;\n\t*([collidersCount @ X4 (System.Int32&)]) = v522;\n\tSpine.Unity.SkeletonUtility::SetColliderPointsLocal(v347, this.slot, v282, scale);\n\tUnityEngine.Collider2D::set_isTrigger(v347, this.isTrigger);\n\tUnityEngine.Behaviour::set_enabled(v347, 0);\n\tUnityEngine.Object::set_hideFlags(v347, 8);\n\tUnityEngine.Collider2D::set_isTrigger(v347, this.isTrigger);\n\tSystem.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::Add(this.colliderTable, v282, v347);\n\tSystem.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, System.String>::Add(this.nameTable, v282, v388);\n\tgoto L_0070;\nL_0123:\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::Dispose(&v155 @ stack_-D0_v3 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\nL_0132:\n\treturn;\n\tv491 = new System.NullReferenceException();\n\tv523 = new System.NullReferenceException();\n\tv546 = new System.NullReferenceException();\n\tv573 = new System.NullReferenceException();\n\tv600 = new System.NullReferenceException();\n\tv622 = new System.NullReferenceException();\n\tv309 = new System.IndexOutOfRangeException();\nL_013A:\n\tv315 = new System.NullReferenceException();\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\n\tgoto L_0159;\nL_0159:\n\tv76 = v306 != 1;\n\tif (v76) goto L_0169;\n\tv378 = 0x1854E70(v315, v306, v172, v169, collidersCount, methodInfo, v47, v48, v153, v320, v321, v51, v52, v53, v54, v55);\n\tv394 = 0x1854E80(v378, v306, v172, v169, collidersCount, methodInfo, v47, v48, v153, v320, v321, v51, v52, v53, v54, v55);\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::Dispose(&v144 @ stack_-A0_v3 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\n\tv181 = *([v378 @ X0_v17]) == 0;\n\tif (v181) goto L_0132;\n\tthrow System.OutOfMemoryException;\nL_0169:\n\tgoto L_016F;\n\tX19 = X0;\nL_016F:\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::Dispose(&v144 @ stack_-A0_v3 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\n\tgoto L_0176;\n\tv436 = 0xBD3CD0(v315, Il2CppMethodInfo, v172, v169, collidersCount, methodInfo, v47, v48, v153, v320, v321, v51, v52, v53, v54, v55);\nL_0176:\n\tv439 = new System.OutOfMemoryException();\n\tv242 = 0x9DACB4(v439, Il2CppMethodInfo, v172, v169, collidersCount, methodInfo, v47, v48, v153, v320, v321, v51, v52, v53, v54, v55);\n\treturn;\n// 241 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void AddCollidersForSkin(Skin skin, int slotIndex, PolygonCollider2D[] previousColliders, float scale, ref int collidersCount)
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
					nint num = (nint)typeof(BoundingBoxFollowerGraphic);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ X0_v30 (Il2CppClass<Spine.Unity.BoundingBoxFollowerGraphic>)+E0]");
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
						string message = "BoundingBoxFollowerGraphic tried to follow a slot that contains non-boundingbox attachments: " + slotName;
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
						SkeletonUtility.SetColliderPointsLocal(polygonCollider2D, Slot, boundingBoxAttachment, scale);
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

		[Token(Token = "0x60004F2")]
		[Address(RVA = "0x15576B4", Offset = "0x15576B4", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv42 = UnityEngine.Object;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv52 = Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A37BFB]) = v36;\nL_001A:\n\tv40 = ~this.clearStateOnDisable;\n\tif (v40) goto L_0023;\n\tSpine.Unity.BoundingBoxFollowerGraphic::ClearState(this);\nL_0023:\n\tgoto L_0028;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0028:\n\tv58 = UnityEngine.Object::op_Inequality(this.skeletonGraphic, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_0047;\n\tv65 = new Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonGraphic+SkeletonRendererDelegate::.ctor(v65, this, Il2CppMethodInfo);\n\tv86 = this.skeletonGraphic == 0;\n\tif (v86) goto L_0048;\n\tSpine.Unity.SkeletonGraphic::remove_OnRebuild(this.skeletonGraphic, v65);\n\treturn;\nL_0047:\n\treturn;\nL_0048:\n\tthrow v65;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (clearStateOnDisable)
			{
				ClearState();
			}
			if (skeletonGraphic != null)
			{
				SkeletonGraphic.SkeletonRendererDelegate skeletonRendererDelegate = HandleRebuild;
				if ((object)skeletonGraphic == null)
				{
					throw skeletonRendererDelegate;
				}
				skeletonGraphic.OnRebuild -= skeletonRendererDelegate;
			}
		}

		[Token(Token = "0x60004F3")]
		[Address(RVA = "0x155778C", Offset = "0x155778C", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv102 = Il2CppMethodInfo;\n\tv103 = \"il2cpp_codegen_initialize_runtime_metadata\"(v102, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv129 = Il2CppMethodInfo;\n\tv130 = \"il2cpp_codegen_initialize_runtime_metadata\"(v129, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv148 = Il2CppMethodInfo;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v148, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A37BFC]) = v36;\nL_001D:\n\tv37 = 0;\n\tv41 = this.colliderTable == 0;\n\tif (v41) goto L_0042;\n\tv48 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::get_Values(this.colliderTable);\n\tv104 = v48 == 0;\n\tif (v104) goto L_004C;\n\tv136 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+ValueCollection<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::GetEnumerator(v48);\nL_0034:\n\tv156 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v37 @ stack_-38_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv89 = v156 == 0;\n\tif (v89) goto L_0041;\n\tUnityEngine.Behaviour::set_enabled(0, 0);\n\tgoto L_0034;\nL_0041:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v37 @ stack_-38_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\nL_0042:\n\tthis.currentAttachment = 0;\n\tthis.currentAttachmentName = 0;\n\tthis.currentCollider = 0;\n\treturn;\n\tv141 = new System.NullReferenceException();\nL_004C:\n\tv146 = new System.NullReferenceException();\n\tgoto L_0059;\n\tgoto L_0059;\nL_0059:\n\tv51 = Il2CppMethodInfo != 1;\n\tif (v51) goto L_0069;\n\tv160 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+ValueCollection<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+Enumerator<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::MoveNext(v146);\n\tv167 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+ValueCollection<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+Enumerator<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::MoveNext(v160);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v37 @ stack_-38_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv90 = ~v160.m_value;\n\tif (v90) goto L_0042;\n\tthrow System.OutOfMemoryException;\nL_0069:\n\tgoto L_006F;\n\tX20 = X0;\nL_006F:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v37 @ stack_-38_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tgoto L_0076;\n\tv173 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+ValueCollection<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+Enumerator<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::Dispose(v146);\nL_0076:\n\tv176 = new System.OutOfMemoryException();\n\tv121 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+ValueCollection<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>+Enumerator<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::Dispose(v176);\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60004F4")]
		[Address(RVA = "0x15575C4", Offset = "0x15575C4", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, requiredCount, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv48 = UnityEngine.Object;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, requiredCount, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A37BFD]) = v43;\nL_001B:\n\tv46 = UnityEngine.Component::GetComponents(this);\n\tv52 = v46.Length == 0;\n\tif (v52) goto L_006B;\n\tv111 = v46.Length <= requiredCount;\n\tif (v111) goto L_006B;\nL_0044:\n\tgoto L_0049;\n\tv190 = \"il2cpp_codegen_runtime_class_init\"(v186, v56, v54, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0049:\n\tv194 = UnityEngine.Object::op_Inequality(v46[v98 @ X21_v6 (System.Int32)], 0);\n\tv196 = v194 == 0;\n\tif (v196) goto L_0057;\n\tgoto L_0055;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v197, v193, v113, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0055:\n\tUnityEngine.Object::Destroy(v46[v98 @ X21_v6 (System.Int32)]);\nL_0057:\n\tv98 = v98 + 1;\n\tv118 = v98 < v46.Length;\n\tif (v118) goto L_0044;\nL_006B:\n\treturn;\n\tv87 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60004F5")]
		[Address(RVA = "0x1557904", Offset = "0x1557904", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.slot;\n\tv2 = this.slot == 0;\n\tif (v2) goto L_0011;\n\tv9 = v0.attachment == this.currentAttachment;\n\tif (v9) goto L_0011;\n\tSpine.Unity.BoundingBoxFollowerGraphic::MatchAttachment(this, v0.attachment);\n\treturn;\nL_0011:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdate()
		{
			Slot slot = Slot;
			if (Slot != null && slot.Attachment != CurrentAttachment)
			{
				MatchAttachment(slot.Attachment);
			}
		}

		[Token(Token = "0x60004F6")]
		[Address(RVA = "0x1557924", Offset = "0x1557924", Length = "0x2D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv24 = Spine.BoundingBoxAttachment;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv49 = Spine.Unity.BoundingBoxFollowerGraphic;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv91 = UnityEngine.Debug;\n\tv92 = \"il2cpp_codegen_initialize_runtime_metadata\"(v91, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv131 = Il2CppMethodInfo;\n\tv132 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv143 = Il2CppMethodInfo;\n\tv144 = \"il2cpp_codegen_initialize_runtime_metadata\"(v143, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv164 = System.Object[];\n\tv165 = \"il2cpp_codegen_initialize_runtime_metadata\"(v164, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv174 = UnityEngine.Object;\n\tv175 = \"il2cpp_codegen_initialize_runtime_metadata\"(v174, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv182 = \"Collider for BoundingBoxAttachment named '{0}' was not initialized. It is possibly from a new skin. currentAttachmentName will be null. You may need to call BoundingBoxFollowerGraphic.Initialize(overwrite: true);\";\n\tv183 = \"il2cpp_codegen_initialize_runtime_metadata\"(v182, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv196 = \"BoundingBoxFollowerGraphic tried to match a non-boundingbox attachment. It will treat it as null.\";\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v196, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A37BFE]) = v43;\nL_0030:\n\tv47 = attachment == 0;\n\tif (v47) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_005B;\n\tv106 = v106_asT == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_005B;\nL_005B:\n\tgoto L_0062;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v126, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv135 = Spine.Unity.BoundingBoxFollowerGraphic;\nL_0062:\n\tv140 = v123 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_007B;\n\tv145 = attachment == 0;\n\tif (v145) goto L_007B;\n\tv152 = ~v166.DebugMessages;\n\tif (v152) goto L_007B;\n\tgoto L_0075;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v176, attachment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0075:\n\tUnityEngine.Debug::LogWarning(\"BoundingBoxFollowerGraphic tried to match a non-boundingbox attachment. It will treat it as null.\");\nL_007B:\n\tgoto L_0080;\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v158, v146, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0080:\n\tv172 = UnityEngine.Object::op_Inequality(this.currentCollider, 0);\n\tv180 = v172 == 0;\n\tif (v180) goto L_008A;\n\tUnityEngine.Behaviour::set_enabled(this.currentCollider, 0);\nL_008A:\n\tv194 = v123 == 0;\n\tif (v194) goto L_00B5;\n\tv245 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::TryGetValue(this.colliderTable, v123, &v200 @ stack_-38_v6 (System.Object));\n\tgoto L_009F;\n\tv309 = \"il2cpp_codegen_runtime_class_init\"(v290, v244, v243, v198, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_009F:\n\tv312 = UnityEngine.Object::op_Inequality(v200, 0);\n\tv314 = v312 == 0;\n\tif (v314) goto L_00B9;\n\tthis.currentCollider = v200;\n\tUnityEngine.Behaviour::set_enabled(v200, 1);\n\tthis.currentAttachment = v123;\n\tv256 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, System.String>::get_Item(this.nameTable, v123);\n\tthis.currentAttachmentName = v256;\n\tgoto L_00F0;\nL_00B5:\n\tthis.currentAttachment = 0;\n\tthis.currentAttachmentName = 0;\n\tthis.currentCollider = 0;\n\tgoto L_00F0;\nL_00B9:\n\tthis.currentAttachmentName = 0;\n\tthis.currentCollider = 0;\n\tthis.currentAttachment = v123;\n\tgoto L_00C5;\n\tv319 = \"il2cpp_codegen_runtime_class_init\"(v315, v205, v202, v198, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv320 = Spine.Unity.BoundingBoxFollowerGraphic;\nL_00C5:\n\tv260 = ~v321.DebugMessages;\n\tif (v260) goto L_00F0;\n\t// 203 NewArr v212 @ X0_v27 (System.Object[]), typeof(System.Object[]), 1\n\tv325 = v123.<Name>k__BackingField == 0;\n\tif (v325) goto L_00DB;\n\t// 213 IsInst v281 @ X0_v34, typeof(System.Object), v123.<Name>k__BackingField (System.String)\n\tv283 = v281 == 0;\n\tif (v283) goto L_00F3;\nL_00DB:\n\tv212[0] = v123.<Name>k__BackingField;\n\tgoto L_00E7;\n\tv332 = \"il2cpp_codegen_runtime_class_init\"(v329, v228, v202, v198, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00E7:\n\tUnityEngine.Debug::LogFormat(\"Collider for BoundingBoxAttachment named '{0}' was not initialized. It is possibly from a new skin. currentAttachmentName will be null. You may need to call BoundingBoxFollowerGraphic.Initialize(overwrite: true);\", v212);\nL_00F0:\n\treturn;\n\tv223 = new System.NullReferenceException();\n\tv240 = new System.IndexOutOfRangeException();\nL_00F3:\n\tv289 = new System.ArrayTypeMismatchException();\n\tthrow v289;\n\treturn;\n// 158 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				Debug.LogWarning("BoundingBoxFollowerGraphic tried to match a non-boundingbox attachment. It will treat it as null.");
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
				Debug.LogFormat("Collider for BoundingBoxAttachment named '{0}' was not initialized. It is possibly from a new skin. currentAttachmentName will be null. You may need to call BoundingBoxFollowerGraphic.Initialize(overwrite: true);", array);
			}
			else
			{
				currentAttachment = null;
				currentAttachmentName = null;
				currentCollider = null;
			}
		}

		[Token(Token = "0x60004F7")]
		[Address(RVA = "0x1557BF4", Offset = "0x1557BF4", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv60 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv65 = System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, System.String>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37BFF]) = v50;\nL_0026:\n\tthis.clearStateOnDisable = 1;\n\tv53 = new System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>();\n\tSystem.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>::.ctor(v53);\n\tthis.colliderTable = v53;\n\tv63 = new System.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<Spine.BoundingBoxAttachment, System.String>::.ctor(v63);\n\tthis.nameTable = v63;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoundingBoxFollowerGraphic()
		{
			clearStateOnDisable = true;
			Dictionary<BoundingBoxAttachment, PolygonCollider2D> dictionary = new Dictionary<BoundingBoxAttachment, PolygonCollider2D>();
			colliderTable = dictionary;
			Dictionary<BoundingBoxAttachment, string> dictionary2 = new Dictionary<BoundingBoxAttachment, string>();
			nameTable = dictionary2;
		}
	}
}
