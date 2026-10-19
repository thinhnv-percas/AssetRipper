using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.NestedScrollers
{
	[Token(Token = "0x2000043")]
	public class ScrollRectEx : ScrollRect
	{
		[Token(Token = "0x4000144")]
		[FieldOffset(Offset = "0x130")]
		private bool routeToParent;

		[Token(Token = "0x600016D")]
		[Address(RVA = "0x4C93494", Offset = "0x4C93494", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\nL_FFFFFFFF:\n\tv52 = this;\n\tgoto L_002A;\nL_FFFFFFFF:\n\tv52 = this;\n\tgoto L_002A;\n\tv253 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv52 = this;\nL_002A:\n\tv65 = UnityEngine.Component::get_transform(v52);\n\tv218 = UnityEngine.Transform::get_parent(v65);\n\tv255 = action == 0;\n\tif (v255) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv149 = v218;\n\tgoto L_003F;\nL_0037:\n\tv330 = UnityEngine.Transform::get_parent(v149);\nL_FFFFFFFF:\n\tv149 = v330;\nL_0044:\n\tv143 = UnityEngine.Object::op_Inequality(v149, 0);\n\tv373 = v143 == 0;\n\tif (v373) goto L_0104;\n\tv144 = UnityEngine.Component::GetComponents(v149);\n\tv398 = v144.Length < 1;\n\tif (v398) goto L_0037;\nL_FFFFFFFF:\n\tv179 = 0;\n\tgoto L_007C;\nL_FFFFFFFF:\n\tv488 = 0;\nL_007C:\n\tgoto L_0081;\n\tv486 = v144[v179 @ X27_v8 (System.Int32)] == 0;\n\tif (v486) goto L_00A9;\n\tv242 = 0x21C11D0(v144[v179 @ X27_v8 (System.Int32)], UnityEngine.EventSystems.IEventSystemHandler, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv245 = v242 == 0;\n\tif (v245) goto L_010B;\nL_FFFFFFFF:\n\tv171 = v242;\nL_FFFFFFFF:\n\tv175 = Il2CppClass<T>;\n\tgoto L_0098;\n\tv206 = 0x21C11D0(v171, v175, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv528 = v206 == 0;\n\tv209 = ~v528;\nL_FFFFFFFF:\n\tv488 = v206;\n\tif (v209) goto L_0066;\n\tgoto L_0108;\nL_00A9:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv171 = 0;\nL_FFFFFFFF:\n\tv175 = Il2CppClass<T>;\n\tgoto L_0098;\nL_FFFFFFFF:\n\tv150 = v218;\n\tgoto L_00B8;\nL_00B2:\n\tv357 = UnityEngine.Transform::get_parent(v150);\nL_FFFFFFFF:\n\tv150 = v357;\nL_00BD:\n\tv145 = UnityEngine.Object::op_Inequality(v150, 0);\n\tv374 = ~v145;\n\tif (v374) goto L_0104;\n\tv146 = UnityEngine.Component::GetComponents(v150);\n\tv410 = v146.Length < 1;\n\tif (v410) goto L_00B2;\nL_FFFFFFFF:\n\tv72 = 0;\n\tv72 = v72 + 1;\n\tv435 = v72 < v146.Length;\n\tif (v435) goto L_00DF;\n\tgoto L_00B2;\nL_0104:\n\treturn;\nL_0108:\n\tthrow System.InvalidCastException;\nL_010B:\n\tthrow System.InvalidCastException;\nL_003F:\n\tgoto L_0044;\nL_0081:\n\tv478 = 0x21C11D0(v144[v179 @ X27_v8 (System.Int32)], Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv484 = v478 == 0;\n\tif (v484) goto L_0067;\nL_0067:\n\tv179 = v179 + 1;\n\tv416 = v179 >= v144.Length;\n\tif (v416) goto L_0037;\nL_0098:\n\tv524 = v171 == 0;\n\tif (v524) goto L_FFFFFFFF;\nL_0066:\n\tSystem.Action`1<T>::Invoke(action, v488);\nL_00B8:\n\tgoto L_00BD;\nL_00E4:\n\tv147 = 0x21C11D0(v146[v72 @ X25_v8 (System.Int32)], Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_00DF:\n\tgoto L_00E4;\n")]
		private void DoForParents<T>(Action<T> action) where T : IEventSystemHandler
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScrollRectEx::DoForParents");
		}

		[Token(Token = "0x600016E")]
		[Address(RVA = "0x4029108", Offset = "0x4029108", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv55.eventData = eventData;\n\tv80 = new System.Action`1<UnityEngine.EventSystems.IInitializePotentialDragHandler>();\n\tSystem.Action`1<UnityEngine.EventSystems.IInitializePotentialDragHandler>::.ctor(v80, v55, Il2CppMethodInfo);\n\tEnhancedScrollerDemos.NestedScrollers.ScrollRectEx::DoForParents(this, v80);\n\tUnityEngine.UI.ScrollRect::OnInitializePotentialDrag(this, v55.eventData);\n\treturn;\nL_0025:\n\tv55 = new EnhancedScrollerDemos.NestedScrollers.ScrollRectEx+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v55);\n")]
		public override void OnInitializePotentialDrag(PointerEventData eventData)
		{
			Action<IInitializePotentialDragHandler> action = delegate(IInitializePotentialDragHandler parent)
			{
				parent.OnInitializePotentialDrag(eventData);
			};
			DoForParents(action);
			base.OnInitializePotentialDrag(eventData);
		}

		[Token(Token = "0x600016F")]
		[Address(RVA = "0x4029214", Offset = "0x4029214", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv47.eventData = eventData;\n\tv75 = this.routeToParent != 1;\n\tif (v75) goto L_005C;\n\tv79 = new System.Action`1<UnityEngine.EventSystems.IDragHandler>();\n\tSystem.Action`1<UnityEngine.EventSystems.IDragHandler>::.ctor(v79, v47, Il2CppMethodInfo);\n\tEnhancedScrollerDemos.NestedScrollers.ScrollRectEx::DoForParents(this, v79);\n\treturn;\nL_005C:\n\tUnityEngine.UI.ScrollRect::OnDrag(this, v47.eventData);\n\treturn;\nL_0021:\n\tv47 = new EnhancedScrollerDemos.NestedScrollers.ScrollRectEx+<>c__DisplayClass3_0();\n\tSystem.Object::.ctor(v47);\n")]
		public override void OnDrag(PointerEventData eventData)
		{
			if (routeToParent)
			{
				Action<IDragHandler> action = delegate(IDragHandler parent)
				{
					parent.OnDrag(eventData);
				};
				DoForParents(action);
			}
			else
			{
				base.OnDrag(eventData);
			}
		}

		[Token(Token = "0x6000170")]
		[Address(RVA = "0x4029328", Offset = "0x4029328", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv51.eventData = eventData;\n\tv127 = this.horizontal == 0;\n\tv128 = ~v127;\n\tif (v128) goto L_0057;\n\tv143 = v51.eventData;\n\tgoto L_0046;\nL_0046:\n\tv138 = UnityEngine.Mathf::Abs(v143.delta);\n\tv137 = UnityEngine.Mathf::Abs(v143.<delta>k__BackingField.y);\n\tv136 = v138 < v137;\n\tv135 = v138 == v137;\n\tv247 = v138 == v138;\n\tv132 = v137 == v137;\n\tv133 = v247 & v132;\n\tv131 = ~v133;\n\tv248 = v136 == v131;\n\tv129 = ~v135;\n\tv130 = v248 & v129;\n\tif (v130) goto L_0077;\nL_0057:\n\tv146 = this.vertical == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0093;\n\tv239 = v51.eventData;\n\tgoto L_0069;\nL_0069:\n\tv234 = UnityEngine.Mathf::Abs(v239.delta);\n\tv233 = UnityEngine.Mathf::Abs(v239.<delta>k__BackingField.y);\n\tv232 = v234 < v233;\n\tv226 = ~v232;\n\tif (v226) goto L_0093;\nL_0077:\n\tthis.routeToParent = 1;\n\tv257 = new System.Action`1<UnityEngine.EventSystems.IBeginDragHandler>();\n\tSystem.Action`1<UnityEngine.EventSystems.IBeginDragHandler>::.ctor(v257, v51, Il2CppMethodInfo);\n\tEnhancedScrollerDemos.NestedScrollers.ScrollRectEx::DoForParents(this, v257);\n\treturn;\nL_0093:\n\tthis.routeToParent = 0;\n\tUnityEngine.UI.ScrollRect::OnBeginDrag(this, v51.eventData);\n\treturn;\nL_0026:\n\tv51 = new EnhancedScrollerDemos.NestedScrollers.ScrollRectEx+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v51);\n")]
		public override void OnBeginDrag(PointerEventData eventData)
		{
			if (!horizontal)
			{
				PointerEventData pointerEventData = eventData;
				float num = Mathf.Abs(pointerEventData.delta.x);
				float num2 = Mathf.Abs(pointerEventData.delta.y);
				bool flag = num < num2;
				bool flag2 = num == num2;
				bool flag3 = num == num;
				bool flag4 = num2 == num2;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag2;
				if (flag7 && flag8)
				{
					goto IL_01af;
				}
			}
			if (!vertical)
			{
				PointerEventData pointerEventData2 = eventData;
				float num3 = Mathf.Abs(pointerEventData2.delta.x);
				float num4 = Mathf.Abs(pointerEventData2.delta.y);
				if (num3 < num4)
				{
					goto IL_01af;
				}
			}
			routeToParent = false;
			base.OnBeginDrag(eventData);
			return;
			IL_01af:
			routeToParent = true;
			Action<IBeginDragHandler> action = delegate(IBeginDragHandler parent)
			{
				parent.OnBeginDrag(eventData);
			};
			DoForParents(action);
		}

		[Token(Token = "0x6000171")]
		[Address(RVA = "0x40294E4", Offset = "0x40294E4", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv47.eventData = eventData;\n\tv75 = this.routeToParent != 1;\n\tif (v75) goto L_0056;\n\tv79 = new System.Action`1<UnityEngine.EventSystems.IEndDragHandler>();\n\tSystem.Action`1<UnityEngine.EventSystems.IEndDragHandler>::.ctor(v79, v47, Il2CppMethodInfo);\n\tEnhancedScrollerDemos.NestedScrollers.ScrollRectEx::DoForParents(this, v79);\n\tthis.routeToParent = 0;\n\treturn;\nL_0056:\n\tUnityEngine.UI.ScrollRect::OnEndDrag(this, v47.eventData);\n\tthis.routeToParent = 0;\n\treturn;\nL_0021:\n\tv47 = new EnhancedScrollerDemos.NestedScrollers.ScrollRectEx+<>c__DisplayClass5_0();\n\tSystem.Object::.ctor(v47);\n")]
		public override void OnEndDrag(PointerEventData eventData)
		{
			if (routeToParent)
			{
				Action<IEndDragHandler> action = delegate(IEndDragHandler parent)
				{
					parent.OnEndDrag(eventData);
				};
				DoForParents(action);
				routeToParent = false;
			}
			else
			{
				base.OnEndDrag(eventData);
				routeToParent = false;
			}
		}

		[Token(Token = "0x6000172")]
		[Address(RVA = "0x4029608", Offset = "0x4029608", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UI.ScrollRect::.ctor(this);\n\treturn;\n")]
		public ScrollRectEx()
		{
		}
	}
}
