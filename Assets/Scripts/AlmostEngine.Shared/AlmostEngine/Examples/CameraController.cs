using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Examples
{
	[Token(Token = "0x200000F")]
	public class CameraController : MonoBehaviour
	{
		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x20")]
		public bool m_MouseLookOnClickOnly;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x24")]
		public float m_RotationCoeff;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x28")]
		public float m_TranslationCoeff;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x2C")]
		public float m_TranslationMouseCoeff;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x30")]
		public float m_TranslationMouseScrollCoeff;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x38")]
		private Transform m_Character;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x40")]
		public Transform m_Head;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x48")]
		private Vector3 m_PreviousMousePosition;

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x3C45FC4", Offset = "0x3C45FC4", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_002B:\n\tv63 = UnityEngine.Object::op_Equality(this.m_Head, 0);\n\tv65 = ~v63;\n\tv66 = ~v65;\n\tif (v66) goto L_003B;\n\tgoto L_0045;\nL_003B:\n\tv80 = UnityEngine.Component::GetComponentInChildren(this);\n\tv100 = UnityEngine.Component::get_transform(v80);\n\tthis.m_Head = v100;\nL_0045:\n\tv90 = UnityEngine.Input::get_mousePosition();\n\tthis.m_PreviousMousePosition.x = v90;\n\tthis.m_PreviousMousePosition.y = v90.y;\n\tthis.m_PreviousMousePosition.z = v90.z;\n\treturn;\nL_001B:\n\tv47 = UnityEngine.Component::get_transform(this);\n\tthis.m_Character = v47;\n\tgoto L_002B;\n")]
		private void Start()
		{
			Transform character = base.transform;
			m_Character = character;
			if (m_Head == null)
			{
				Camera componentInChildren = GetComponentInChildren<Camera>();
				Transform head = componentInChildren.transform;
				m_Head = head;
			}
			Vector3 mousePosition = Input.mousePosition;
			m_PreviousMousePosition.x = mousePosition.x;
			m_PreviousMousePosition.y = mousePosition.y;
			m_PreviousMousePosition.z = mousePosition.z;
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x3C460C0", Offset = "0x3C460C0", Length = "0x634")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv84 = UnityEngine.Time::get_deltaTime();\n\tv90 = UnityEngine.Component::get_transform(this.m_Character);\n\tv257 = UnityEngine.Transform::get_position(v90);\n\tv276 = UnityEngine.Component::get_transform(this.m_Head);\n\tv258 = UnityEngine.Transform::get_forward(v276);\n\tv278 = UnityEngine.Component::get_transform(this.m_Head);\n\tv416 = v65 * v71;\n\tv417 = v416 * this.m_TranslationCoeff;\n\tv418 = v79 * v84;\n\tv210 = v418 * this.m_TranslationCoeff;\n\tv243 = v417 * v258;\n\tv420 = v417 * v258.y;\n\tv251 = v417 * v258.z;\n\tv422 = UnityEngine.Transform::get_right(v278);\n\tv425 = v210 * v422;\n\tv426 = v210 * v422.y;\n\tv427 = v210 * v422.z;\n\tv428 = v243 + v425;\n\tv429 = v420 + v426;\n\tv430 = v251 + v427;\n\tv432 = v257 + v428;\n\tv433 = v257.y + v429;\n\tv434 = v257.z + v430;\n\t// 124 MakeStruct v150 @ AGG3C4624C_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v432 @ V0_v13 (System.Single), v433 @ V1_v8 (System.Single), v434 @ V2_v8 (System.Single)\n\tUnityEngine.Transform::set_position(v90, v150);\n\tv438 = UnityEngine.Input::get_mousePosition();\n\tv441 = UnityEngine.Input::GetMouseButton(1);\n\tv443 = UnityEngine.Input::GetMouseButton(2);\n\tv444 = ~v443;\n\tif (v444) goto L_00E1;\n\tv446 = UnityEngine.Time::get_deltaTime();\n\tv259 = UnityEngine.Time::get_deltaTime();\n\tv280 = UnityEngine.Component::get_transform(this.m_Character);\n\tv260 = UnityEngine.Transform::get_position(v280);\n\tv282 = UnityEngine.Component::get_transform(this.m_Head);\n\tv261 = UnityEngine.Transform::get_up(v282);\n\tv284 = UnityEngine.Component::get_transform(this.m_Head);\n\tv526 = v438.y - this.m_PreviousMousePosition.y;\n\tv527 = v526 * this.m_TranslationMouseCoeff;\n\tv528 = -v527;\n\tv529 = v528 * v446;\n\tv530 = v438 - this.m_PreviousMousePosition;\n\tv531 = v530 * this.m_TranslationMouseCoeff;\n\tv532 = -v531;\n\tv456 = v532 * v259;\n\tv461 = v529 * v261;\n\tv454 = v529 * v261.y;\n\tv458 = v529 * v261.z;\n\tv535 = UnityEngine.Transform::get_right(v284);\n\tv540 = v456 * v535;\n\tv541 = v456 * v535.y;\n\tv542 = v456 * v535.z;\n\tv543 = v461 + v540;\n\tv544 = v454 + v541;\n\tv545 = v458 + v542;\n\tv460 = v260 + v543;\n\tv452 = v260.y + v544;\n\tv450 = v260.z + v545;\n\t// 222 MakeStruct v447 @ AGG3C4637C_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v460 @ V0_v65 (System.Single), v452 @ V1_v48 (System.Single), v450 @ V2_v33 (System.Single)\n\tUnityEngine.Transform::set_position(v280, v447);\nL_00E1:\n\tv466 = UnityEngine.Input::get_mouseScrollDelta();\n\tv262 = UnityEngine.Time::get_deltaTime();\n\tv286 = UnityEngine.Component::get_transform(this.m_Character);\n\tv263 = UnityEngine.Transform::get_position(v286);\n\tv288 = UnityEngine.Component::get_transform(this.m_Head);\n\tv469 = v466.y * this.m_TranslationMouseScrollCoeff;\n\tv254 = v469 * v262;\n\tv471 = UnityEngine.Transform::get_forward(v288);\n\tv474 = v254 * v471;\n\tv475 = v254 * v471.y;\n\tv476 = v254 * v471.z;\n\tv477 = v263 + v474;\n\tv206 = v263.y + v475;\n\tv196 = v263.z + v476;\n\t// 268 MakeStruct v132 @ AGG3C4640C_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v477 @ V0_v22 (System.Single), v206 @ V1_v15 (System.Single), v196 @ V2_v14 (System.Single)\n\tUnityEngine.Transform::set_position(v286, v132);\n\tv481 = this.m_MouseLookOnClickOnly ^ 1;\n\tv482 = v481 | v441;\n\tv483 = v482 == 0;\n\tif (v483) goto L_01F2;\n\tv489 = UnityEngine.Input::GetAxis(\"Mouse X\");\n\tv537 = UnityEngine.Time::get_deltaTime();\n\tv549 = UnityEngine.Input::GetAxis(\"Mouse Y\");\n\tv264 = UnityEngine.Time::get_deltaTime();\n\tv551 = v549 * v264;\n\tv552 = -v551;\n\tv553 = v552 * this.m_RotationCoeff;\n\tv556 = UnityEngine.Transform::get_localRotation(this.m_Head);\n\tgoto L_014B;\nL_FFFFFFFF:\n\tv626 = 0x42A00000;\n\tgoto L_018A;\nL_FFFFFFFF:\n\tv626 = v611;\nL_FFFFFFFF:\n\tv265 = 0xFFFFFFFFBF32B8C2;\n\tgoto L_019E;\nL_FFFFFFFF:\n\tv265 = v630;\n\tv640 = v489 * v537;\n\tv515 = v640 * this.m_RotationCoeff;\n\tv644 = UnityEngine.Transform::get_localRotation(this.m_Character);\n\tgoto L_01C8;\nL_01F2:\n\tthis.m_PreviousMousePosition.x = v438;\n\tthis.m_PreviousMousePosition.y = v438.y;\n\tthis.m_PreviousMousePosition.z = v438.z;\n\treturn;\nL_002B:\n\tv65 = UnityEngine.Input::GetAxis(\"Vertical\");\n\tv71 = UnityEngine.Time::get_deltaTime();\n\tv79 = UnityEngine.Input::GetAxis(\"Horizontal\");\nL_014B:\n\t// 331 MakeStruct v93 @ AGG3C464DC_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v572.right (UnityEngine.Vector3), v572.right.y (System.Single), v572.right.z (System.Single)\n\tv578 = UnityEngine.Quaternion::AngleAxis(v553, v93);\n\tv582 = v556.w * v578;\n\tv583 = v556 * v578.w;\n\tv584 = v582 + v583;\n\tv585 = v556.y * v578.z;\n\tv586 = v585 + v584;\n\tv587 = v556.z * v578.y;\n\tv154 = v586 - v587;\n\tv588 = v556.w * v578.y;\n\tv589 = v556.y * v578.w;\n\tv590 = v588 + v589;\n\tv591 = v556.z * v578;\n\tv592 = v591 + v590;\n\tv593 = v556 * v578.z;\n\tv129 = v592 - v593;\n\tv594 = v556.w * v578.z;\n\tv595 = v556.z * v578.w;\n\tv596 = v594 + v595;\n\tv597 = v556 * v578.y;\n\tv127 = v597 + v596;\n\tv125 = v556.y * v578;\n\tv598 = v556.w * v578.w;\n\tv599 = v556 * v578;\n\tv600 = v598 - v599;\n\tv601 = v556.y * v578.y;\n\tv602 = v600 - v601;\n\tv603 = v556.z * v578.z;\n\tv604 = v602 - v603;\n\tv605 = v154 / v604;\n\tv606 = v127 - v125;\n\tv273 = v129 / v604;\n\tv255 = v606 / v604;\n\tv607 = 0x8BF5EA0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v605, v604, v606, v598, v154, v129, v127, v125);\n\tv611 = v605 * 0x42E52EE1;\n\tv614 = v611 < 0x42A00000;\n\tv615 = v611 == 0x42A00000;\n\tv618 = v611 == v611;\n\tv621 = ~v618;\n\tv622 = v614 == v621;\n\tv102 = ~v615;\n\tv105 = v622 & v102;\n\tv623 = ~v105;\n\tif (v623) goto L_FFFFFFFF;\nL_018A:\n\tv630 = v626 * 0x3C0EFA35;\n\tv123 = v611 < 0xFFFFFFFFC2A00000;\n\tv99 = ~v123;\n\tif (v99) goto L_FFFFFFFF;\nL_019E:\n\tv639 = 0x8BF7F04(v607, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v265, v630, 0xFFFFFFFFC2A00000, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t// 420 MakeStruct v96 @ AGG3C465C4_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v265 @ V0_v42, v273 @ V8_v11 (System.Single), v255 @ V9_v10 (System.Single), 1f\n\tUnityEngine.Transform::set_localRotation(this.m_Head, v96);\nL_01C8:\n\t// 456 MakeStruct v490 @ AGG3C46630_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v521.upVector (UnityEngine.Vector3), v521.upVector.y (System.Single), v521.upVector.z (System.Single)\n\tv663 = UnityEngine.Quaternion::AngleAxis(v515, v490);\n\tv667 = v644.w * v663;\n\tv668 = v644 * v663.w;\n\tv669 = v667 + v668;\n\tv670 = v644.y * v663.z;\n\tv671 = v670 + v669;\n\tv672 = v644.z * v663.y;\n\tv495 = v671 - v672;\n\tv673 = v644.w * v663.y;\n\tv674 = v644.y * v663.w;\n\tv675 = v673 + v674;\n\tv676 = v644.z * v663;\n\tv677 = v676 + v675;\n\tv678 = v644 * v663.z;\n\tv494 = v677 - v678;\n\tv679 = v644.w * v663.z;\n\tv680 = v644.z * v663.w;\n\tv681 = v679 + v680;\n\tv682 = v644 * v663.y;\n\tv683 = v682 + v681;\n\tv492 = v644.y * v663;\n\tv493 = v683 - v492;\n\tv684 = v644.w * v663.w;\n\tv685 = v644 * v663;\n\tv686 = v684 - v685;\n\tv687 = v644.y * v663.y;\n\tv688 = v686 - v687;\n\tv689 = v644.z * v663.z;\n\tv496 = v688 - v689;\n\t// 494 MakeStruct v491 @ AGG3C466B8_1_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v495 @ V4_v12 (System.Single), v494 @ V5_v16 (System.Single), v493 @ V6_v15 (System.Single), v496 @ V3_v15 (System.Single)\n\tUnityEngine.Transform::set_localRotation(this.m_Character, v491);\n")]
		private void Update()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraController::Update");
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x3C466F4", Offset = "0x3C466F4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = q / q.w;\n\tv17 = 0x8BF5EA0(this, methodInfo, v20, v21, v22, v23, v24, v25, v14, q.y, q.z, q.w, v26, v27, v28, v29);\n\tv33 = v14 * 0x42E52EE1;\n\tv36 = v33 < 0x42A00000;\n\tv37 = v33 == 0x42A00000;\n\tv40 = v33 == v33;\n\tv43 = ~v40;\n\tv44 = v36 == v43;\n\tv45 = ~v37;\n\tv46 = v44 & v45;\n\tv47 = ~v46;\n\tif (v47) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv50 = 0x42A00000;\n\tgoto L_0027;\nL_FFFFFFFF:\n\tv50 = v33;\nL_FFFFFFFF:\n\treturnVal1 = 0xFFFFFFFFBF32B8C2;\n\tgoto L_003B;\nL_FFFFFFFF:\n\treturnVal1 = v54;\nL_0027:\n\tv54 = v50 * 0x3C0EFA35;\n\tv57 = v33 < 0xFFFFFFFFC2A00000;\n\tv68 = ~v57;\n\tif (v68) goto L_FFFFFFFF;\nL_003B:\n\tv72 = 0x8BF7F04(v17, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, returnVal1, v54, 0xFFFFFFFFC2A00000, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n")]
		private Quaternion ClampRotationAroundXAxis(Quaternion q)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraController::ClampRotationAroundXAxis");
			return default;
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x3C46778", Offset = "0x3C46778", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_MouseLookOnClickOnly = 1;\n\tthis.m_RotationCoeff = *([9307D20]);\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CameraController()
		{
			m_MouseLookOnClickOnly = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [9307D20]");
			m_RotationCoeff = 0f;
		}
	}
}
