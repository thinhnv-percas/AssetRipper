using System;
using System.Collections.Generic;
using Systems.TutorialSystem.Scripts.Data;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.UncoButtonSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using _game.CoreGameKit.UiControllers;

namespace Systems.TutorialSystem.Scripts.UI
{
	[Token(Token = "0x2000016")]
	public class ClickUIController : UIController
	{
		[SerializeField]
		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x48")]
		private Image m_BgImage;

		[SerializeField]
		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x50")]
		private RectTransform m_ButtonTransform;

		[SerializeField]
		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x58")]
		private UncoButton m_Button;

		[Token(Token = "0x600006A")]
		[Address(RVA = "0x81E1180", Offset = "0x81E1180", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tv53 = Systems.TutorialSystem.Scripts.Data.RectData::ApplyData(rectData, this.m_ButtonTransform);\n\tv62 = new System.Action();\n\tSystem.Action::.ctor(v62, this, Il2CppMethodInfo);\n\tUnco.UncoButtonSystem.UncoButton::AddListener(this.m_Button, v62, 1, 1);\n\treturn;\n")]
		public void Initialize(RectData rectData)
		{
			RectTransform rectTransform = rectData.ApplyData(m_ButtonTransform);
			Action clickAction = ButtonClick;
			m_Button.AddListener(clickAction);
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0x81E1230", Offset = "0x81E1230", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = UnityEngine.UI.Graphic::set_raycastTarget(this.m_BgImage, 0);\n\tv32 = this.m_Button;\n\tv66 = UnityEngine.UI.Graphic::set_raycastTarget(v32.Image, 0);\n\tv68 = UnityEngine.Camera::get_main();\n\tv64 = UnityEngine.Component::get_transform(this.m_ButtonTransform);\n\tv39 = UnityEngine.Transform::get_position(v64);\n\tv82 = UnityEngine.Camera::WorldToScreenPoint(v68, v39);\n\t// 53 MakeStruct v70 @ AGG81E12C0_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v82 @ V0_v3 (UnityEngine.Vector3), v82.y (System.Single)\n\tSystems.TutorialSystem.Scripts.UI.ClickUIController::SimulateClick(v68, v70);\n\treturn;\n")]
		private void ButtonClick()
		{
			m_BgImage.raycastTarget = false;
			UncoButton button = m_Button;
			button.Image.raycastTarget = false;
			Camera main = Camera.main;
			Transform transform = m_ButtonTransform.transform;
			Vector3 position = transform.position;
			Vector3 vector = main.WorldToScreenPoint(position);
			Vector2 position2 = default(Vector2);
			position2.x = vector.x;
			position2.y = vector.y;
			((ClickUIController)(object)main).SimulateClick(position2);
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0x81E12C8", Offset = "0x81E12C8", Length = "0x3CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004B;\nL_004E:\n\tv81 = UnityEngine.EventSystems.EventSystem::get_current();\n\tv87 = new UnityEngine.EventSystems.PointerEventData();\n\tUnityEngine.EventSystems.PointerEventData::.ctor(v87, v81);\n\tv87.<position>k__BackingField.x = position;\n\tv87.<position>k__BackingField.y = position.y;\n\tv106 = new System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>();\n\tSystem.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>::.ctor(v106);\n\tv116 = UnityEngine.EventSystems.EventSystem::get_current();\n\tUnityEngine.EventSystems.EventSystem::RaycastAll(v116, v87, v106);\n\tv362 = System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>::GetEnumerator(v106);\n\tv130 = v362;\n\tv308 = v362.Current == 0;\n\tif (v308) goto L_0113;\n\tv546 = UnityEngine.GameObject::GetComponent(v362.Current);\n\tgoto L_00BA;\nL_00BA:\n\tv231 = UnityEngine.Object::op_Inequality(v546, 0);\n\tv554 = v231 == 0;\n\tv555 = ~v554;\n\tif (v555) goto L_00F9;\n\tv558 = UnityEngine.GameObject::GetComponentInParent(v362.Current);\n\tgoto L_00CC;\nL_00CC:\n\tv378 = UnityEngine.Object::op_Inequality(v558, 0);\n\tv382 = v378 == 0;\n\tif (v382) goto L_00A6;\n\tv309 = v558 == 0;\n\tif (v309) goto L_0115;\n\tgoto L_00DC;\nL_00DC:\n\tv379 = UnityEngine.Object::op_Inequality(v558.targetGraphic, 0);\n\tv383 = v379 == 0;\n\tif (v383) goto L_00A6;\n\tv310 = v558.targetGraphic == 0;\n\tif (v310) goto L_0117;\n\tv575 = UnityEngine.Component::get_gameObject(v558.targetGraphic);\n\tgoto L_00EF;\nL_00EF:\n\tv380 = UnityEngine.Object::op_Equality(v575, v362.Current);\n\tv384 = v380 == 0;\n\tif (v384) goto L_00A6;\n\tUnityEngine.Events.UnityEvent::Invoke(v558.onClick);\n\tgoto L_0102;\nL_00F9:\n\tv233 = v546 == 0;\n\tif (v233) goto L_011A;\n\tv311 = v546.onClick == 0;\n\tif (v311) goto L_011C;\n\tUnityEngine.Events.UnityEvent::Invoke(v546.onClick);\nL_0102:\n\tSystem.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>+Enumerator<UnityEngine.EventSystems.RaycastResult>::Dispose(&v130 @ stack_-D0_v5 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>+Enumerator<UnityEngine.EventSystems.RaycastResult>));\nL_0112:\n\treturn;\nL_0113:\n\tv302 = new System.NullReferenceException();\n\tv278 = &v130 @ stack_-D0_v5 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>+Enumerator<UnityEngine.EventSystems.RaycastResult>);\n\tv280 = 0;\n\tv228 = v362.Current;\n\tgoto L_011F;\nL_0115:\n\tv303 = new System.NullReferenceException();\n\tv278 = &v130 @ stack_-D0_v5 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>+Enumerator<UnityEngine.EventSystems.RaycastResult>);\n\tv280 = 0;\n\tv228 = Il2CppMethodInfo;\n\tv300 = v302;\n\tgoto L_011F;\nL_0117:\n\tv300 = new System.NullReferenceException();\n\tv278 = &v130 @ stack_-D0_v5 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>+Enumerator<UnityEngine.EventSystems.RaycastResult>);\n\tv280 = 0;\n\tv228 = 0;\n\tv300 = v303;\n\tgoto L_011F;\nL_011A:\n\tv242 = new System.NullReferenceException();\n\tv278 = &v130 @ stack_-D0_v5 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>+Enumerator<UnityEngine.EventSystems.RaycastResult>);\n\tv280 = 0;\n\tv228 = 0;\n\tgoto L_011F;\nL_011C:\n\tv305 = new System.NullReferenceException();\n\tv300 = v242;\n\tgoto L_011F;\nL_011F:\n\t// 287 Interrupt\n\tgoto L_013B;\nL_013B:\n\tv335 = v228 != 1;\n\tv348 = v300;\n\tif (v335) goto L_014B;\n\tv339 = 0x8BF5BC4(v300, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv364 = 0x8BF5BF4(v339, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>+Enumerator<UnityEngine.EventSystems.RaycastResult>::Dispose(v278);\n\tv347 = *([v339 @ X0_v16]) == 0;\n\tif (v347) goto L_0112;\n\tv345 = new System.OutOfMemoryException();\n\tv280 = *([v339 @ X0_v16]);\n\tv348 = v345;\n\treturn;\nL_004B:\n\tgoto L_004E;\nL_00A6:\n\tv387 = System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>+Enumerator<UnityEngine.EventSystems.RaycastResult>::MoveNext(&v130 @ stack_-D0_v5 (System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>+Enumerator<UnityEngine.EventSystems.RaycastResult>));\n\tv389 = v387 == 0;\n\tif (v389) goto L_0102;\nL_014B:\n\tv351 = 0x3968E90(&v280 @ stack_-130_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv366 = 0x8BF0368(v348, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv375 = 0x7C03E68(v366, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void SimulateClick(Vector2 position)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ClickUIController::SimulateClick");
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0x81E1694", Offset = "0x81E1694", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreGameKit.UiControllers.UIController::.ctor(this);\n\treturn;\n")]
		public ClickUIController()
		{
		}
	}
}
