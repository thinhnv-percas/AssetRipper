using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000010")]
public class TCP2_Demo_PBS_View : MonoBehaviour
{
	[Token(Token = "0x4000079")]
	[FieldOffset(Offset = "0x18")]
	public Transform Pivot;

	[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x763E10", Offset = "0x763E10")]
	[Token(Token = "0x400007A")]
	[FieldOffset(Offset = "0x20")]
	public float OrbitStrg;

	[Token(Token = "0x400007B")]
	[FieldOffset(Offset = "0x24")]
	public float OrbitClamp;

	[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x763E48", Offset = "0x763E48")]
	[Token(Token = "0x400007C")]
	[FieldOffset(Offset = "0x28")]
	public float PanStrg;

	[Token(Token = "0x400007D")]
	[FieldOffset(Offset = "0x2C")]
	public float PanClamp;

	[Token(Token = "0x400007E")]
	[FieldOffset(Offset = "0x30")]
	public float yMin;

	[Token(Token = "0x400007F")]
	[FieldOffset(Offset = "0x34")]
	public float yMax;

	[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x763E80", Offset = "0x763E80")]
	[Token(Token = "0x4000080")]
	[FieldOffset(Offset = "0x38")]
	public float ZoomStrg;

	[Token(Token = "0x4000081")]
	[FieldOffset(Offset = "0x3C")]
	public float ZoomClamp;

	[Token(Token = "0x4000082")]
	[FieldOffset(Offset = "0x40")]
	public float ZoomDistMin;

	[Token(Token = "0x4000083")]
	[FieldOffset(Offset = "0x44")]
	public float ZoomDistMax;

	[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x763EB8", Offset = "0x763EB8")]
	[Token(Token = "0x4000084")]
	[FieldOffset(Offset = "0x48")]
	public float Decceleration;

	[Token(Token = "0x4000085")]
	[FieldOffset(Offset = "0x4C")]
	public Rect ignoreMouseRect;

	[Token(Token = "0x4000086")]
	[FieldOffset(Offset = "0x5C")]
	private Vector3 mouseDelta;

	[Token(Token = "0x4000087")]
	[FieldOffset(Offset = "0x68")]
	private Vector3 orbitAcceleration;

	[Token(Token = "0x4000088")]
	[FieldOffset(Offset = "0x74")]
	private Vector3 panAcceleration;

	[Token(Token = "0x4000089")]
	[FieldOffset(Offset = "0x80")]
	private Vector3 moveAcceleration;

	[Token(Token = "0x400008A")]
	[FieldOffset(Offset = "0x8C")]
	private float zoomAcceleration;

	[Token(Token = "0x400008B")]
	private const float XMax = 60f;

	[Token(Token = "0x400008C")]
	private const float XMin = 300f;

	[Token(Token = "0x400008D")]
	[FieldOffset(Offset = "0x90")]
	private Vector3 mResetCamPos;

	[Token(Token = "0x400008E")]
	[FieldOffset(Offset = "0x9C")]
	private Vector3 mResetPivotPos;

	[Token(Token = "0x400008F")]
	[FieldOffset(Offset = "0xA8")]
	private Vector3 mResetCamRot;

	[Token(Token = "0x4000090")]
	[FieldOffset(Offset = "0xB4")]
	private Vector3 mResetPivotRot;

	[Token(Token = "0x4000091")]
	[FieldOffset(Offset = "0xC0")]
	private bool leftMouseHeld;

	[Token(Token = "0x4000092")]
	[FieldOffset(Offset = "0xC1")]
	private bool rightMouseHeld;

	[Token(Token = "0x4000093")]
	[FieldOffset(Offset = "0xC2")]
	private bool middleMouseHeld;

	[Token(Token = "0x600007C")]
	[Address(RVA = "0xB07364", Offset = "0xB07364", Length = "0x8C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Component::get_transform(this);\n\tv14 = UnityEngine.Transform::get_position(v11);\n\tthis.mResetCamPos = v14;\n\tthis.mResetCamPos.y = v14.y;\n\tthis.mResetCamPos.z = v14.z;\n\tv34 = UnityEngine.Component::get_transform(this);\n\tv27 = UnityEngine.Transform::get_eulerAngles(v34);\n\tthis.mResetCamRot = v27;\n\tthis.mResetCamRot.y = v27.y;\n\tthis.mResetCamRot.z = v27.z;\n\tv28 = UnityEngine.Transform::get_position(this.Pivot);\n\tthis.mResetPivotPos = v28;\n\tthis.mResetPivotPos.y = v28.y;\n\tthis.mResetPivotPos.z = v28.z;\n\tv61 = UnityEngine.Transform::get_eulerAngles(this.Pivot);\n\tthis.mResetPivotRot = v61;\n\tthis.mResetPivotRot.y = v61.y;\n\tthis.mResetPivotRot.z = v61.z;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		Transform transform = base.transform;
		Vector3 vector = (mResetCamPos = transform.position);
		mResetCamPos.y = vector.y;
		mResetCamPos.z = vector.z;
		Transform transform2 = base.transform;
		Vector3 vector2 = (mResetCamRot = transform2.eulerAngles);
		mResetCamRot.y = vector2.y;
		mResetCamRot.z = vector2.z;
		Vector3 vector3 = (mResetPivotPos = Pivot.position);
		mResetPivotPos.y = vector3.y;
		mResetPivotPos.z = vector3.z;
		Vector3 vector4 = (mResetPivotRot = Pivot.eulerAngles);
		mResetPivotRot.y = vector4.y;
		mResetPivotRot.z = vector4.z;
	}

	[Token(Token = "0x600007D")]
	[Address(RVA = "0xB073F0", Offset = "0xB073F0", Length = "0x2C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Input::get_mousePosition();\n\tthis.mouseDelta = v11;\n\tthis.mouseDelta.y = v11.y;\n\tthis.mouseDelta.z = v11.z;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnEnable()
	{
		Vector3 vector = (mouseDelta = Input.mousePosition);
		mouseDelta.y = vector.y;
		mouseDelta.z = vector.z;
	}

	[Token(Token = "0x600007E")]
	[Address(RVA = "0xB0741C", Offset = "0xB0741C", Length = "0x7FC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = *([1EF0608]);\n\tv37 = *([v36 @ X8_v64]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20224E6]) = v56;\nL_001F:\n\tv60 = UnityEngine.Input::get_mousePosition();\n\tgoto L_003C;\n\tv75 = *([v69 @ X0_v3+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tgoto L_003C;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v69, methodInfo, v40, v41, v42, v43, v44, v45, v60, v61, v62, v49, v50, v51, v52, v53);\nL_003C:\n\t// 60 MakeStruct v90 @ AGGB074C4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.mouseDelta (UnityEngine.Vector3), this.mouseDelta.y (System.Single), this.mouseDelta.z (System.Single)\n\tv91 = UnityEngine.Vector3::op_Subtraction(v60, v90);\n\tv95 = this + 0x4C;\n\tv96 = this.ignoreMouseRect;\n\tthis.mouseDelta = v91;\n\tthis.mouseDelta.y = v91.y;\n\tthis.mouseDelta.z = v91.z;\n\tv99 = UnityEngine.Screen::get_width();\n\tv103 = 0x10CD178(v95, 0, v40, v41, v42, v43, v44, v45, v91, v91.y, v91.z, this.ignoreMouseRect, this.mouseDelta.y, this.mouseDelta.z, v52, v53);\n\tv105 = v99 - v91;\n\tv108 = 0x10CCFBC(&v96 @ V3_v2 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, v105, v99, v91.z, this.ignoreMouseRect, this.mouseDelta.y, this.mouseDelta.z, v52, v53);\n\tv110 = UnityEngine.Input::get_mousePosition();\n\tv115 = 0x10CD20C(&v96 @ V3_v2 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, v110, v110.y, v110.z, this.ignoreMouseRect, this.mouseDelta.y, this.mouseDelta.z, v52, v53);\n\tv119 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv121 = v119 == 0;\n\tif (v121) goto L_0066;\n\tv122 = ~v115;\n\tv135 = v122 & 1;\n\tgoto L_0074;\nL_0066:\n\tv127 = UnityEngine.Input::GetMouseButtonUp(0);\n\tv139 = v127 == 0;\n\tv134 = ~v139;\n\tif (v134) goto L_0074;\n\tv131 = UnityEngine.Input::GetMouseButton(0);\n\tv151 = v131 == 0;\n\tv133 = ~v151;\n\tif (v133) goto L_0077;\nL_0074:\n\tthis.leftMouseHeld = v135;\nL_0077:\n\tv146 = UnityEngine.Input::GetMouseButtonDown(1);\n\tv149 = v146 == 0;\n\tif (v149) goto L_0081;\n\tv152 = ~v115;\n\tv164 = v152 & 1;\n\tgoto L_008E;\nL_0081:\n\tv157 = UnityEngine.Input::GetMouseButtonUp(1);\n\tv167 = v157 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_FFFFFFFF;\n\tv172 = UnityEngine.Input::GetMouseButton(1);\n\tv183 = v172 == 0;\n\tv174 = ~v183;\n\tif (v174) goto L_0091;\nL_008E:\n\tthis.rightMouseHeld = v164;\nL_0091:\n\tv178 = UnityEngine.Input::GetMouseButtonDown(2);\n\tv181 = v178 == 0;\n\tif (v181) goto L_009B;\n\tv184 = ~v115;\n\tv196 = v184 & 1;\n\tgoto L_00A8;\nL_009B:\n\tv189 = UnityEngine.Input::GetMouseButtonUp(2);\n\tv199 = v189 == 0;\n\tv200 = ~v199;\n\tif (v200) goto L_FFFFFFFF;\n\tv204 = UnityEngine.Input::GetMouseButton(2);\n\tv225 = v204 == 0;\n\tv206 = ~v225;\n\tif (v206) goto L_00AA;\nL_00A8:\n\tthis.middleMouseHeld = v196;\nL_00AA:\n\tv209 = ~this.leftMouseHeld;\n\tif (v209) goto L_00CB;\n\tgoto L_00BC;\n\tv226 = *([v217 @ X0_v105+E0]);\n\tv227 = v226 == 0;\n\tv228 = ~v227;\n\tif (v228) goto L_00BC;\n\tv230 = \"il2cpp_codegen_runtime_class_init\"(v217, v201, v40, v41, v42, v43, v44, v45, v110, v111, v112, v96, v86, v87, v52, v53);\nL_00BC:\n\tv233 = this.mouseDelta * this.OrbitStrg;\n\tv234 = -this.OrbitClamp;\n\tv237 = UnityEngine.Mathf::Clamp(v233, v234, this.OrbitClamp);\n\tv284 = this + 0x6C;\n\tv264 = this.orbitAcceleration.y;\n\tv257 = this.orbitAcceleration + v237;\n\tv268 = this.mouseDelta.y;\n\tv270 = this.OrbitStrg;\n\tv266 = this.OrbitClamp;\n\tthis.orbitAcceleration.x = v257;\n\tgoto L_00E3;\nL_00CB:\n\tv222 = ~this.middleMouseHeld;\n\tv223 = ~v222;\n\tif (v223) goto L_00D4;\n\tv239 = ~this.rightMouseHeld;\n\tif (v239) goto L_00ED;\nL_00D4:\n\tv284 = this + 0x78;\n\tv264 = this.panAcceleration.y;\n\tv268 = this.mouseDelta.y;\n\tv270 = this.PanStrg;\n\tv266 = this.PanClamp;\n\tgoto L_00E3;\n\tv288 = *([v247 @ X0_v103+E0]);\n\tv289 = v288 == 0;\n\tv290 = ~v289;\n\tif (v290) goto L_00E3;\n\tv295 = \"il2cpp_codegen_runtime_class_init\"(v247, v201, v40, v41, v42, v43, v44, v45, v110, v111, v112, v96, v86, v87, v52, v53);\nL_00E3:\n\tv296 = v268 * v270;\n\tv297 = -v296;\n\tv276 = -v266;\n\tv298 = UnityEngine.Mathf::Clamp(v297, v276, v266);\n\tv262 = v264 + v298;\n\t*([v284 @ X20_v14]) = v262;\nL_00ED:\n\tv287 = UnityEngine.Input::GetKeyDown(0x72);\n\tv300 = v287 == 0;\n\tif (v300) goto L_00F5;\n\tTCP2_Demo_PBS_View::ResetView(this);\nL_00F5:\n\tv305 = UnityEngine.Component::get_transform(this);\n\tv308 = UnityEngine.Transform::get_localEulerAngles(v305);\n\tv470 = v308 >= 180f;\n\tif (v470) goto L_0131;\n\tv594 = v308 < 60f;\n\tif (v594) goto L_0131;\n\tv596 = this.orbitAcceleration.y <= 0;\n\tif (v596) goto L_0131;\n\tthis.orbitAcceleration.y = 0f;\nL_0131:\n\tv626 = v308 <= 180f;\n\tif (v626) goto L_0150;\n\tv632 = v308 < 300f;\n\tv633 = ~v632;\n\tv634 = v308 - 300f;\n\tv636 = v634 == 0;\n\tv641 = ~v636;\n\tv642 = v633 & v641;\n\tif (v642) goto L_0150;\n\tv643 = this.orbitAcceleration.y >= 0;\n\tif (v643) goto L_0150;\n\tthis.orbitAcceleration.y = 0f;\nL_0150:\n\tv564 = UnityEngine.Component::get_transform(this);\n\tv378 = UnityEngine.Transform::get_position(this.Pivot);\n\tv429 = UnityEngine.Component::get_transform(this);\n\tv764 = UnityEngine.Transform::get_right(v429);\n\tv535 = UnityEngine.Time::get_deltaTime();\n\tv496 = this.orbitAcceleration.y * v535;\n\tUnityEngine.Transform::RotateAround(v564, v378, v764, v496);\n\tv566 = UnityEngine.Component::get_transform(this);\n\tv769 = UnityEngine.Transform::get_position(this.Pivot);\n\tgoto L_0194;\n\tv776 = *([v772 @ X0_v45+E0]);\n\tv777 = v776 == 0;\n\tv778 = ~v777;\n\tif (v778) goto L_0194;\n\tv780 = \"il2cpp_codegen_runtime_class_init\"(v772, v521, v40, v41, v42, v43, v44, v45, v769, v770, v771, v531, v528, v525, v496, v53);\nL_0194:\n\tv783 = UnityEngine.Vector3::get_up();\n\tv537 = UnityEngine.Time::get_deltaTime();\n\tv328 = this.orbitAcceleration * v537;\n\tUnityEngine.Transform::RotateAround(v566, v769, v783, v328);\n\tv431 = UnityEngine.Component::get_transform(this.Pivot);\n\tv785 = UnityEngine.Transform::get_position(v431);\n\tv790 = UnityEngine.Time::get_deltaTime();\n\tv793 = this.panAcceleration.y * v790;\n\tv387 = v785.y + v793;\n\tgoto L_01D0;\n\tv798 = *([v794 @ X0_v53+E0]);\n\tv799 = v798 == 0;\n\tv800 = ~v799;\n\tif (v800) goto L_01D0;\n\tv802 = \"il2cpp_codegen_runtime_class_init\"(v794, v362, v40, v41, v42, v43, v44, v45, v793, v786, v787, v375, v373, v371, v328, v53);\nL_01D0:\n\tv380 = UnityEngine.Mathf::Clamp(v387, this.yMin, this.yMax);\n\tv433 = UnityEngine.Component::get_transform(this.Pivot);\n\t// 477 MakeStruct v314 @ AGGB078F4_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v785 @ V0_v19 (UnityEngine.Vector3), v380 @ V0_v23 (System.Single), v785.z (System.Single)\n\tUnityEngine.Transform::set_position(v433, v314);\n\tv434 = UnityEngine.Component::get_transform(this);\n\tv382 = UnityEngine.Transform::get_position(v434);\n\tv435 = UnityEngine.Component::get_transform(this);\n\tv810 = v380 - v785.y;\n\tv811 = v810 + v382.y;\n\t// 501 MakeStruct v311 @ AGGB07940_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v382 @ V0_v25 (UnityEngine.Vector3), v811 @ V1_v22 (System.Single), v382.z (System.Single)\n\tUnityEngine.Transform::set_position(v435, v311);\n\tv818 = UnityEngine.Input::GetAxis(\"Mouse ScrollWheel\");\n\tv821 = v818 * this.ZoomStrg;\n\tv822 = this.zoomAcceleration + v821;\n\tv426 = -this.ZoomClamp;\n\tthis.zoomAcceleration = v822;\n\tv383 = UnityEngine.Mathf::Clamp(v822, v426, this.ZoomClamp);\n\tthis.zoomAcceleration = v383;\n\tv436 = UnityEngine.Component::get_transform(this);\n\tv384 = UnityEngine.Transform::get_position(v436);\n\tv825 = UnityEngine.Transform::get_position(this.Pivot);\n\tv833 = UnityEngine.Vector3::Distance(v384, v825);\n\tv845 = v833 < this.ZoomDistMin;\n\tif (v845) goto L_023F;\n\tv858 = this.zoomAcceleration > 0;\n\tif (v858) goto L_0259;\nL_023F:\n\tv871 = v833 < this.ZoomDistMax;\n\tv872 = ~v871;\n\tv873 = v833 - this.ZoomDistMax;\n\tv875 = v873 == 0;\n\tv880 = ~v875;\n\tv881 = v872 & v880;\n\tif (v881) goto L_028C;\n\tv882 = this.zoomAcceleration >= 0;\n\tif (v882) goto L_028C;\nL_0259:\n\tv895 = UnityEngine.Component::get_transform(this);\n\tgoto L_0267;\n\tv931 = *([v577 @ X8_v30+E0]);\n\tv932 = v931 == 0;\n\tv933 = ~v932;\n\tif (v933) goto L_0267;\n\tv947 = v577;\n\tv935 = \"il2cpp_codegen_runtime_class_init\"(v947, v522, v40, v41, v42, v43, v44, v45, v891, v893, v831, v828, v529, v526, v328, v53);\nL_0267:\n\tv938 = UnityEngine.Vector3::get_forward();\n\tv952 = UnityEngine.Vector3::op_Multip\n// ... truncated")]
	private void Update()
	{
		//IL_005e: Expected O, but got I
		//IL_0122: Expected I4, but got O
		//IL_01cb: Expected I4, but got O
		//IL_0261: Expected I4, but got O
		//IL_03e2: Expected O, but got I
		//IL_0466: Expected O, but got F4
		//IL_0339: Expected O, but got I
		Vector3 mousePosition = Input.mousePosition;
		Vector3 vector = default(Vector3);
		vector.x = mouseDelta.x;
		vector.y = mouseDelta.y;
		vector.z = mouseDelta.z;
		Vector3 vector2 = mousePosition - vector;
		object obj = (long)(IntPtr)this + 76L;
		Rect rect = ignoreMouseRect;
		mouseDelta = vector2;
		mouseDelta.y = vector2.y;
		mouseDelta.z = vector2.z;
		int width = Screen.width;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
		float num = (float)width - vector2.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
		Vector3 mousePosition2 = Input.mousePosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD20C (inside UnityEngine.Rect::MinMaxRect +0x270)");
		object obj2 = default(object);
		int num3;
		if (Input.GetMouseButtonDown(0))
		{
			int num2 = (int)(~obj2);
			num3 = num2 & 1;
		}
		else
		{
			bool mouseButtonUp = Input.GetMouseButtonUp(0);
			bool flag = !mouseButtonUp;
			bool flag2 = !flag;
			num3 = 0;
			if (!flag2)
			{
				bool mouseButton = Input.GetMouseButton(0);
				bool flag3 = !mouseButton;
				bool flag4 = !flag3;
				num3 = 0;
				if (flag4)
				{
					goto IL_0c6f;
				}
			}
		}
		leftMouseHeld = (byte)num3 != 0;
		goto IL_0c6f;
		IL_09d9:
		Vector3 zero = Vector3.zero;
		float deltaTime = Time.deltaTime;
		float t = Decceleration * deltaTime;
		Vector3 a = default(Vector3);
		a.x = orbitAcceleration.x;
		a.y = orbitAcceleration.y;
		a.z = orbitAcceleration.z;
		Vector3 vector3 = (orbitAcceleration = Vector3.Lerp(a, zero, t));
		orbitAcceleration.y = vector3.y;
		orbitAcceleration.z = vector3.z;
		Vector3 zero2 = Vector3.zero;
		float deltaTime2 = Time.deltaTime;
		float t2 = Decceleration * deltaTime2;
		Vector3 a2 = default(Vector3);
		a2.x = panAcceleration.x;
		a2.y = panAcceleration.y;
		a2.z = panAcceleration.z;
		Vector3 vector4 = (panAcceleration = Vector3.Lerp(a2, zero2, t2));
		panAcceleration.y = vector4.y;
		panAcceleration.z = vector4.z;
		float deltaTime3 = Time.deltaTime;
		float t3 = Decceleration * deltaTime3;
		float num4 = Mathf.Lerp(zoomAcceleration, 0f, t3);
		zoomAcceleration = num4;
		Vector3 zero3 = Vector3.zero;
		float deltaTime4 = Time.deltaTime;
		float t4 = Decceleration * deltaTime4;
		Vector3 a3 = default(Vector3);
		a3.x = moveAcceleration.x;
		a3.y = moveAcceleration.y;
		a3.z = moveAcceleration.z;
		Vector3 vector5 = (moveAcceleration = Vector3.Lerp(a3, zero3, t4));
		moveAcceleration.y = vector5.y;
		moveAcceleration.z = vector5.z;
		Vector3 vector6 = (mouseDelta = Input.mousePosition);
		mouseDelta.y = vector6.y;
		mouseDelta.z = vector6.z;
		return;
		IL_0ca9:
		int num6;
		if (Input.GetMouseButtonDown(2))
		{
			int num5 = (int)(~obj2);
			num6 = num5 & 1;
		}
		else
		{
			if (!Input.GetMouseButtonUp(2) && Input.GetMouseButton(2))
			{
				goto IL_0ce3;
			}
			num6 = 0;
		}
		middleMouseHeld = (byte)num6 != 0;
		goto IL_0ce3;
		IL_0cfe:
		if (Input.GetKeyDown(KeyCode.R))
		{
			ResetView();
		}
		Transform transform = base.transform;
		Vector3 localEulerAngles = transform.localEulerAngles;
		if (localEulerAngles.x < 180f && !(localEulerAngles.x < 60f) && orbitAcceleration.y > 0f)
		{
			orbitAcceleration.y = 0f;
		}
		if (localEulerAngles.x > 180f)
		{
			bool flag5 = localEulerAngles.x < 300f;
			bool flag6 = !flag5;
			float num7 = localEulerAngles.x - 300f;
			bool flag7 = num7 == 0f;
			bool flag8 = !flag7;
			if (!(flag6 && flag8) && orbitAcceleration.y < 0f)
			{
				orbitAcceleration.y = 0f;
			}
		}
		Transform transform2 = base.transform;
		Vector3 position = Pivot.position;
		Transform transform3 = base.transform;
		Vector3 right = transform3.right;
		float deltaTime5 = Time.deltaTime;
		float angle = orbitAcceleration.y * deltaTime5;
		transform2.RotateAround(position, right, angle);
		Transform transform4 = base.transform;
		Vector3 position2 = Pivot.position;
		Vector3 up = Vector3.up;
		float deltaTime6 = Time.deltaTime;
		float angle2 = orbitAcceleration.x * deltaTime6;
		transform4.RotateAround(position2, up, angle2);
		Transform transform5 = Pivot.transform;
		Vector3 position3 = transform5.position;
		float deltaTime7 = Time.deltaTime;
		float num8 = panAcceleration.y * deltaTime7;
		float value = position3.y + num8;
		float num9 = Mathf.Clamp(value, yMin, yMax);
		Transform transform6 = Pivot.transform;
		Vector3 position4 = default(Vector3);
		position4.x = position3.x;
		position4.y = num9;
		position4.z = position3.z;
		transform6.position = position4;
		Transform transform7 = base.transform;
		Vector3 position5 = transform7.position;
		Transform transform8 = base.transform;
		float num10 = num9 - position3.y;
		float y = num10 + position5.y;
		Vector3 position6 = default(Vector3);
		position6.x = position5.x;
		position6.y = y;
		position6.z = position5.z;
		transform8.position = position6;
		float axis = Input.GetAxis("Mouse ScrollWheel");
		float num11 = axis * ZoomStrg;
		float value2 = zoomAcceleration + num11;
		float min = 0f - ZoomClamp;
		zoomAcceleration = value2;
		float num12 = Mathf.Clamp(value2, min, ZoomClamp);
		zoomAcceleration = num12;
		Transform transform9 = base.transform;
		Vector3 position7 = transform9.position;
		Vector3 position8 = Pivot.position;
		float num13 = Vector3.Distance(position7, position8);
		if (num13 < ZoomDistMin || !(zoomAcceleration > 0f))
		{
			bool flag9 = num13 < ZoomDistMax;
			bool flag10 = !flag9;
			float num14 = num13 - ZoomDistMax;
			bool flag11 = num14 == 0f;
			bool flag12 = !flag11;
			if ((flag10 && flag12) || !(zoomAcceleration < 0f))
			{
				goto IL_09d9;
			}
		}
		Transform transform10 = base.transform;
		Vector3 forward = Vector3.forward;
		Vector3 vector7 = forward * zoomAcceleration;
		float deltaTime8 = Time.deltaTime;
		Vector3 translation = vector7 * deltaTime8;
		transform10.Translate(translation, Space.Self);
		goto IL_09d9;
		IL_0ce3:
		float y2;
		float y3;
		float num16;
		float num17;
		object obj3;
		if (leftMouseHeld)
		{
			float value3 = mouseDelta.x * OrbitStrg;
			float min2 = 0f - OrbitClamp;
			float num15 = Mathf.Clamp(value3, min2, OrbitClamp);
			obj3 = (long)(IntPtr)this + 108L;
			y2 = orbitAcceleration.y;
			float x = orbitAcceleration.x + num15;
			y3 = mouseDelta.y;
			num16 = OrbitStrg;
			num17 = OrbitClamp;
			orbitAcceleration.x = x;
		}
		else
		{
			if (!middleMouseHeld && !rightMouseHeld)
			{
				goto IL_0cfe;
			}
			obj3 = (long)(IntPtr)this + 120L;
			y2 = panAcceleration.y;
			y3 = mouseDelta.y;
			num16 = PanStrg;
			num17 = PanClamp;
		}
		float num18 = y3 * num16;
		float value4 = 0f - num18;
		float min3 = 0f - num17;
		float num19 = Mathf.Clamp(value4, min3, num17);
		float num20 = y2 + num19;
		obj3 = num20;
		goto IL_0cfe;
		IL_0c6f:
		int num22;
		if (Input.GetMouseButtonDown(1))
		{
			int num21 = (int)(~obj2);
			num22 = num21 & 1;
		}
		else
		{
			if (!Input.GetMouseButtonUp(1) && Input.GetMouseButton(1))
			{
				goto IL_0ca9;
			}
			num22 = 0;
		}
		rightMouseHeld = (byte)num22 != 0;
		goto IL_0ca9;
	}

	[Token(Token = "0x600007F")]
	[Address(RVA = "0xB07C18", Offset = "0xB07C18", Length = "0x104")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA4180]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224E7]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = UnityEngine.Vector3::get_zero();\n\tthis.moveAcceleration = v53;\n\tthis.moveAcceleration.y = v53.y;\n\tthis.moveAcceleration.z = v53.z;\n\tv57 = UnityEngine.Vector3::get_zero();\n\tthis.orbitAcceleration = v57;\n\tthis.orbitAcceleration.y = v57.y;\n\tthis.orbitAcceleration.z = v57.z;\n\tv61 = UnityEngine.Vector3::get_zero();\n\tthis.panAcceleration = v61;\n\tthis.panAcceleration.y = v61.y;\n\tthis.panAcceleration.z = v61.z;\n\tthis.zoomAcceleration = 0f;\n\tv66 = UnityEngine.Component::get_transform(this);\n\t// 62 MakeStruct v72 @ AGGB07CBC_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.mResetCamPos (UnityEngine.Vector3), this.mResetCamPos.y (System.Single), this.mResetCamPos.z (System.Single)\n\tUnityEngine.Transform::set_position(v66, v72);\n\tv95 = UnityEngine.Component::get_transform(this);\n\t// 73 MakeStruct v78 @ AGGB07CDC_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.mResetCamRot (UnityEngine.Vector3), this.mResetCamRot.y (System.Single), this.mResetCamRot.z (System.Single)\n\tUnityEngine.Transform::set_eulerAngles(v95, v78);\n\t// 82 MakeStruct v75 @ AGGB07CF4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.mResetPivotPos (UnityEngine.Vector3), this.mResetPivotPos.y (System.Single), this.mResetPivotPos.z (System.Single)\n\tUnityEngine.Transform::set_position(this.Pivot, v75);\n\t// 96 MakeStruct v105 @ AGGB07D14_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.mResetPivotRot (UnityEngine.Vector3), this.mResetPivotRot.y (System.Single), this.mResetPivotRot.z (System.Single)\n\tUnityEngine.Transform::set_eulerAngles(this.Pivot, v105);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ResetView()
	{
		Vector3 vector = (moveAcceleration = Vector3.zero);
		moveAcceleration.y = vector.y;
		moveAcceleration.z = vector.z;
		Vector3 vector2 = (orbitAcceleration = Vector3.zero);
		orbitAcceleration.y = vector2.y;
		orbitAcceleration.z = vector2.z;
		Vector3 vector3 = (panAcceleration = Vector3.zero);
		panAcceleration.y = vector3.y;
		panAcceleration.z = vector3.z;
		zoomAcceleration = 0f;
		Transform transform = base.transform;
		Vector3 position = default(Vector3);
		position.x = mResetCamPos.x;
		position.y = mResetCamPos.y;
		position.z = mResetCamPos.z;
		transform.position = position;
		Transform transform2 = base.transform;
		Vector3 eulerAngles = default(Vector3);
		eulerAngles.x = mResetCamRot.x;
		eulerAngles.y = mResetCamRot.y;
		eulerAngles.z = mResetCamRot.z;
		transform2.eulerAngles = eulerAngles;
		Vector3 position2 = default(Vector3);
		position2.x = mResetPivotPos.x;
		position2.y = mResetPivotPos.y;
		position2.z = mResetPivotPos.z;
		Pivot.position = position2;
		Vector3 eulerAngles2 = default(Vector3);
		eulerAngles2.x = mResetPivotRot.x;
		eulerAngles2.y = mResetPivotRot.y;
		eulerAngles2.z = mResetPivotRot.z;
		Pivot.eulerAngles = eulerAngles2;
	}

	[Token(Token = "0x6000080")]
	[Address(RVA = "0xB07D1C", Offset = "0xB07D1C", Length = "0x28")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.OrbitStrg = *([1819220]);\n\tthis.ZoomStrg = *([1819230]);\n\tthis.Decceleration = 8f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public TCP2_Demo_PBS_View()
	{
		//IL_0018: Expected F4, but got I
		//IL_002a: Expected F4, but got I
		base._002Ector();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1819220]");
		OrbitStrg = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1819230]");
		ZoomStrg = 0f;
		Decceleration = 8f;
	}
}
