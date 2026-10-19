using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace E7.NotchSolution
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RectTransform))]
	[HelpURL("https://exceed7.com/notch-solution/components/ui-behaviour/safe-padding.html")]
	[Token(Token = "0x2000018")]
	public class SafePadding : NotchSolutionUIBehaviourBase
	{
		[SerializeField]
		[Token(Token = "0x4000081")]
		[FieldOffset(Offset = "0x50")]
		private SupportedOrientations orientationType;

		[SerializeField]
		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0x58")]
		private PerEdgeEvaluationModes portraitOrDefaultPaddings;

		[SerializeField]
		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0x60")]
		private PerEdgeEvaluationModes landscapePaddings;

		[Tooltip("Scale down the resulting value read from an edge to be less than an actual value.")]
		[SerializeField]
		[Range(0f, 1f)]
		[Token(Token = "0x4000084")]
		[FieldOffset(Offset = "0x68")]
		private float influence;

		[Tooltip("The value read from all edges are applied to the opposite side of a RectTransform instead. Useful when you have rotated or negatively scaled RectTransform.")]
		[SerializeField]
		[Token(Token = "0x4000085")]
		[FieldOffset(Offset = "0x6C")]
		private bool flipPadding;

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x3F467C8", Offset = "0x3F467C8", Length = "0x4AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tgoto L_0033;\nL_0033:\n\tv83 = UnityEngine.Screen::get_width();\n\tv112 = UnityEngine.Screen::get_height();\n\tv108 = v83 - v112;\n\tv106 = v108 < 0;\n\tv104 = v108 == 0;\n\tv102 = v83 ^ v112;\n\tv100 = v83 ^ v108;\n\tv98 = v102 & v100;\n\tv96 = v98 < 0;\n\tv126 = v106 == v96;\n\tv89 = ~v104;\n\tv91 = v126 & v89;\n\tv86 = ~v91;\n\tif (v86) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv114 = 0x60;\n\tgoto L_004B;\nL_FFFFFFFF:\n\tv114 = 0x58;\nL_FFFFFFFF:\n\tv114 = 0x58;\n\tv133 = *([v118 @ X20_v3+10]) < 3;\n\tv134 = ~v133;\n\tv142 = ~v134;\n\tv144 = v142 << 8;\n\tv147 = *([v118 @ X20_v3+1C]) < 3;\n\tv148 = ~v147;\n\tv156 = ~v148;\n\tv158 = *([v118 @ X20_v3+14]) < 3;\n\tv159 = ~v158;\n\tv167 = ~v159;\n\tv169 = v144 | v156;\n\tv170 = *([v118 @ X20_v3+18]) < 3;\n\tv171 = ~v170;\n\tv179 = ~v171;\n\tv181 = v169 | v167;\n\tv182 = v142 & v156;\n\tv184 = ~v182;\n\tv188 = ~v184;\n\tv189 = ~v188;\n\tif (v189) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv371 = 0x1002;\n\tgoto L_0096;\nL_FFFFFFFF:\n\tv371 = 0;\nL_FFFFFFFF:\n\tv309 = 0x2004;\n\tgoto L_00A3;\nL_FFFFFFFF:\n\tv309 = 0;\nL_00C3:\n\t// 195 MakeStruct v245 @ AGG3F4693C_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v466.zero (UnityEngine.Vector2), v466.zero.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMin(v347, v245);\n\tv348 = E7.NotchSolution.NotchSolutionUIBehaviourBase::get_rectTransform(this);\n\tgoto L_00DC;\nL_00DC:\n\t// 220 MakeStruct v240 @ AGG3F46988_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v481.one (UnityEngine.Vector2), v481.one.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMax(v348, v240);\n\tv485 = E7.NotchSolution.NotchSolutionUIBehaviourBase::GetCanvasRect(this);\n\tgoto L_00F4;\nL_00FC:\n\tv270 = E7.NotchSolution.NotchSolutionUtility::get_ScreenSafeAreaRelative();\n\tv516 = v270.y + v270.height;\n\tv232 = 1f - v516;\n\tv517 = v270 + v270.width;\n\tv235 = 1f - v517;\n\tv308 = v270 & 0x7FFFFFFF;\n\tv518 = v308 < 0x7F800000;\n\tv519 = ~v518;\n\tv520 = v308 - 0x7F800000;\n\tv522 = v520 == 0;\n\tv527 = ~v522;\n\tv528 = v519 & v527;\n\tv529 = ~v528;\n\tif (v529) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv217 = 0;\n\tgoto L_011D;\nL_FFFFFFFF:\n\tv217 = v270;\nL_FFFFFFFF:\n\tv214 = 0;\n\tgoto L_012F;\nL_FFFFFFFF:\n\tv214 = v270.y;\nL_FFFFFFFF:\n\tv210 = 0;\n\tgoto L_0141;\nL_FFFFFFFF:\n\tv210 = v232;\nL_FFFFFFFF:\n\tv206 = 0;\n\tgoto L_0154;\nL_FFFFFFFF:\n\tv206 = v235;\n\tv567 = UnityEngine.RectTransform::get_rect(v339);\n\tv576 = *([v118 @ X20_v3+10]) == 1;\n\tif (v576) goto L_01AF;\n\tv581 = *([v118 @ X20_v3+10]) == 0;\n\tv582 = ~v581;\nL_FFFFFFFF:\n\tv870 = 0;\n\tif (v582) goto L_016B;\n\tv870 = v485.width * v217;\nL_0177:\n\tv637 = v634 == 0;\n\tv638 = ~v637;\nL_FFFFFFFF:\n\tv756 = 0;\n\tif (v638) goto L_017B;\n\tv756 = v485.width * v206;\nL_0187:\n\tv708 = v705 == 0;\n\tv709 = ~v708;\nL_FFFFFFFF:\n\tv873 = 0;\n\tif (v709) goto L_018B;\n\tv873 = v485.height * v214;\nL_0197:\n\tv781 = v778 == 0;\n\tv782 = ~v781;\nL_FFFFFFFF:\n\tv814 = 0;\n\tif (v782) goto L_019B;\n\tv814 = v485.height * v210;\nL_FFFFFFFF:\n\tv207 = v833;\nL_FFFFFFFF:\n\tv211 = 0;\nL_FFFFFFFF:\n\tv218 = 0;\nL_FFFFFFFF:\n\tv222 = v831;\n\tgoto L_022C;\nL_01AF:\n\tv583 = v206 < v217;\n\tv584 = v206 == v217;\n\tv587 = v206 == v206;\n\tv588 = v217 == v217;\n\tv589 = v587 & v588;\n\tv590 = ~v589;\n\tv591 = v583 == v590;\n\tv592 = ~v584;\n\tv593 = v591 & v592;\n\tv594 = ~v593;\n\tif (v594) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv612 = v206;\n\tgoto L_01C0;\nL_FFFFFFFF:\n\tv612 = v217;\nL_01CD:\n\tv654 = v217 < v206;\n\tv655 = v217 == v206;\n\tv658 = v217 == v217;\n\tv659 = v206 == v206;\n\tv660 = v658 & v659;\n\tv661 = ~v660;\n\tv662 = v654 == v661;\n\tv663 = ~v655;\n\tv664 = v662 & v663;\n\tv665 = ~v664;\n\tif (v665) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv737 = v217;\n\tgoto L_01DE;\nL_FFFFFFFF:\n\tv737 = v206;\nL_01EB:\n\tv725 = v210 < v214;\n\tv726 = v210 == v214;\n\tv729 = v210 == v210;\n\tv730 = v214 == v214;\n\tv731 = v729 & v730;\n\tv732 = ~v731;\n\tv733 = v725 == v732;\n\tv734 = ~v726;\n\tv735 = v733 & v734;\n\tv736 = ~v735;\n\tif (v736) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv811 = v210;\n\tgoto L_01FC;\nL_FFFFFFFF:\n\tv811 = v214;\nL_0209:\n\tv799 = v214 < v210;\n\tv800 = v214 == v210;\n\tv803 = v214 == v214;\n\tv804 = v210 == v210;\n\tv805 = v803 & v804;\n\tv806 = ~v805;\n\tv807 = v799 == v806;\n\tv808 = ~v800;\n\tv809 = v807 & v808;\n\tv810 = ~v809;\n\tif (v810) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv890 = v214;\n\tgoto L_021A;\nL_FFFFFFFF:\n\tv890 = v210;\nL_0229:\n\tv207 = v870 * v871;\n\tv222 = v871 * v873;\n\tv272 = UnityEngine.RectTransform::get_sizeDelta(v340);\n\tv341 = E7.NotchSolution.NotchSolutionUIBehaviourBase::get_rectTransform(this);\n\tv215 = v222 + v211;\n\tv262 = -v215;\n\tv212 = v207 + v218;\n\tv273 = -v212;\n\t// 571 MakeStruct v204 @ AGG3F46B80_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v273 @ V0_v9, v262 @ V1_v9\n\tUnityEngine.RectTransform::set_sizeDelta(v341, v204);\n\tv342 = E7.NotchSolution.NotchSolutionUIBehaviourBase::get_rectTransform(this);\n\tv274 = UnityEngine.RectTransform::get_pivot(v342);\n\tv343 = E7.NotchSolution.NotchSolutionUIBehaviourBase::get_rectTransform(this);\n\tv275 = UnityEngine.RectTransform::get_pivot(v343);\n\tv344 = E7.NotchSolution.NotchSolutionUIBehaviourBase::get_rectTransform(this);\n\tv276 = UnityEngine.RectTransform::get_pivot(v344);\n\tv345 = E7.NotchSolution.NotchSolutionUIBehaviourBase::get_rectTransform(this);\n\tv277 = UnityEngine.RectTransform::get_pivot(v345);\n\tv900 = E7.NotchSolution.NotchSolutionUIBehaviourBase::get_rectTransform(this);\n\tv346 = E7.NotchSolution.NotchSolutionUIBehaviourBase::get_rectTransform(this);\n\tv278 = UnityEngine.RectTransform::get_anchoredPosition3D(v346);\n\tv902 = v485.height - v215;\n\tv903 = v902 * v277.y;\n\tv906 = v222 + v903;\n\tv907 = v485.height * v275.y;\n\tv413 = v906 - v907;\n\tv908 = v485.width - v212;\n\tv909 = v908 * v276;\n\tv910 = v207 + v909;\n\tv404 = v485.width * v274;\n\tv415 = v910 - v404;\n\t// 652 MakeStruct v377 @ AGG3F46C6C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v415 @ V0_v21 (System.Single), v413 @ V1_v17 (System.Single), v278.z (System.Single)\n\tUnityEngine.RectTransform::set_anchoredPosition3D(v900, v377);\n\treturn;\nL_002A:\n\tv74 = this.orientationType != 1;\n\tif (v74) goto L_FFFFFFFF;\nL_004B:\n\tgoto L_004D;\nL_0096:\n\tv372 = v167 & v179;\n\tv326 = ~v372;\n\tv306 = ~v326;\n\tv300 = ~v306;\n\tif (v300) goto L_FFFFFFFF;\nL_00A3:\n\tv448 = v181 | v371;\n\tv449 = v448 | v179;\n\tv193 = v449 | v309;\n\tUnityEngine.DrivenRectTransformTracker::Add(&this.m_Tracker (UnityEngine.DrivenRectTransformTracker), this, v123, v193);\n\tv347 = E7.NotchSolution.NotchSolutionUIBehaviourBase::get_rectTransform(this);\n\tgoto L_00C3;\nL_00F4:\n\tgoto L_00FC;\nL_011D:\n\tv532 = v270.y & 0x7FFFFFFF;\n\tv533 = v532 < 0x7F800000;\n\tv534 = ~v533;\n\tv535 = v532 - 0x7F800000;\n\tv537 = v535 == 0;\n\tv542 = ~v537;\n\tv543 = v534 & v542;\n\tv544 = ~v543;\n\tif (v544) goto L_FFFFFFFF;\nL_012F:\n\tv547 = v232 & 0x7FFFFFFF;\n\tv548 = v547 < 0x7F800000;\n\tv549 = ~v548;\n\tv550 = v547 - 0x7F800000;\n\tv552 = v550 == 0;\n\tv557 = ~v552;\n\tv558 = v549 & v557;\n\tv559 = ~v558;\n\tif (v559) goto L_FFFFFFFF;\nL_0141:\n\tv362 = v235 & 0x7FFFFFFF;\n\tv562 = v362 < 0x7F800000;\n\tv335 = ~v562;\n\tv332 = v362 - 0x7F800000;\n\tv324 = v332 == 0;\n\tv563 = ~v324;\n\tv304 = v335 & v563;\n\tv298 = ~v304;\n\tif (v298) goto L_FFFFFFFF;\nL_0154:\n\tv339 = E7.NotchSolution.NotchSolutionUIBehaviourBase::get_rectTransform(this);\nL_016B:\n\tv634 = this->klass->namespaze+0x4;\n\tv602 = *([v118 @ X20_v3+1C]) == 1;\nL_FFFFFFFF:\n\tv783 = v870;\n\tif (v602) goto L_01CD;\nL_017B:\n\tv705 = this->klass->name+0x4;\n\tv674 = *([v118 @ X20_v3+14]) == 1;\nL_FFFFFFFF:\n\tv783 = v870;\nL_FFFFFFFF:\n\tv785 = v756;\n\tif (v674) goto L_01EB;\nL_018B:\n\tv778 = this->klass->namespaze;\n\tv746 = *([v118 @ X20_v3+18]) == 1;\nL_FFFFFFFF:\n\tv783 = v870;\nL_FFFFFFFF:\n\tv784 = v873;\nL_FFFFFFFF:\n\tv785 = v756;\n\tif (v746) goto L_0209;\nL_019B:\n\tv871 = this.influence;\n\tv831 = this.influence * v814;\n\tv833 = this.influence * v756;\n\tv828 = this.flipPadding != 1;\nL_FFFFFFFF:\n\tv211 = v831;\nL_FFFFFFFF:\n\tv218 = v833;\n\tif (v828) goto L_0229;\nL_022C:\n\tv340 = E7.NotchSolution.NotchSolutionUIBehaviourBase::get_rectTransform(this);\nL_01C0:\n\tv870 = v485.width * v612;\n\tv634 = this->klass->namespaze+0x4;\n\tv616 = *([v118 @ X20_v3+1C]) != 1;\nL_FFFFFFFF:\n\tv783 = v870;\n\tif (v616) goto L_0177;\nL_01DE:\n\tv756 = v485.width * v737;\n\tv705 = this->klass->name+0x4;\n\tv687 = *([v118 @ X20_v3+14]) != 1;\nL_FFFFFFFF:\n\tv870 = v783;\nL_FFFFFFFF:\n\tv785 = v756;\n\tif (v687) goto L_0187;\nL_01FC:\n\tv873 = v485.height * v811;\n// ... truncated")]
		protected override void UpdateRect()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SafePadding::UpdateRect");
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x3F46C80", Offset = "0x3F46C80", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.influence = 1f;\n\tE7.NotchSolution.NotchSolutionUIBehaviourBase::.ctor(this);\n\treturn;\n")]
		public SafePadding()
		{
			influence = 1f;
		}
	}
}
