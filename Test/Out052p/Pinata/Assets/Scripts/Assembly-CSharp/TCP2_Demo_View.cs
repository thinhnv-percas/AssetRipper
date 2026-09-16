using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000011")]
public class TCP2_Demo_View : MonoBehaviour
{
	[Attribute(Type = typeof(HeaderAttribute), RVA = "0x763EF0", Offset = "0x763EF0")]
	[Token(Token = "0x4000094")]
	[FieldOffset(Offset = "0x18")]
	public float OrbitStrg;

	[Token(Token = "0x4000095")]
	[FieldOffset(Offset = "0x1C")]
	public float OrbitClamp;

	[Attribute(Type = typeof(HeaderAttribute), RVA = "0x763F28", Offset = "0x763F28")]
	[Token(Token = "0x4000096")]
	[FieldOffset(Offset = "0x20")]
	public float PanStrg;

	[Token(Token = "0x4000097")]
	[FieldOffset(Offset = "0x24")]
	public float PanClamp;

	[Attribute(Type = typeof(HeaderAttribute), RVA = "0x763F60", Offset = "0x763F60")]
	[Token(Token = "0x4000098")]
	[FieldOffset(Offset = "0x28")]
	public float ZoomStrg;

	[Token(Token = "0x4000099")]
	[FieldOffset(Offset = "0x2C")]
	public float ZoomClamp;

	[Attribute(Type = typeof(HeaderAttribute), RVA = "0x763F98", Offset = "0x763F98")]
	[Token(Token = "0x400009A")]
	[FieldOffset(Offset = "0x30")]
	public float Decceleration;

	[Token(Token = "0x400009B")]
	[FieldOffset(Offset = "0x38")]
	public Transform CharacterTransform;

	[Token(Token = "0x400009C")]
	[FieldOffset(Offset = "0x40")]
	private Vector3 mouseDelta;

	[Token(Token = "0x400009D")]
	[FieldOffset(Offset = "0x4C")]
	private Vector3 orbitAcceleration;

	[Token(Token = "0x400009E")]
	[FieldOffset(Offset = "0x58")]
	private Vector3 panAcceleration;

	[Token(Token = "0x400009F")]
	[FieldOffset(Offset = "0x64")]
	private Vector3 moveAcceleration;

	[Token(Token = "0x40000A0")]
	[FieldOffset(Offset = "0x70")]
	private float zoomAcceleration;

	[Token(Token = "0x40000A1")]
	private const float XMax = 60f;

	[Token(Token = "0x40000A2")]
	private const float XMin = 300f;

	[Token(Token = "0x40000A3")]
	[FieldOffset(Offset = "0x74")]
	private Vector3 mResetCamPos;

	[Token(Token = "0x40000A4")]
	[FieldOffset(Offset = "0x80")]
	private Vector3 mResetCamRot;

	[Token(Token = "0x40000A5")]
	[FieldOffset(Offset = "0x8C")]
	private bool mMouseDown;

	[Token(Token = "0x6000081")]
	[Address(RVA = "0xB07D44", Offset = "0xB07D44", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Camera::get_main();\n\tv14 = UnityEngine.Component::get_transform(v11);\n\tv23 = UnityEngine.Transform::get_position(v14);\n\tthis.mResetCamPos = v23;\n\tthis.mResetCamPos.y = v23.y;\n\tthis.mResetCamPos.z = v23.z;\n\tv33 = UnityEngine.Camera::get_main();\n\tv34 = UnityEngine.Component::get_transform(v33);\n\tv54 = UnityEngine.Transform::get_eulerAngles(v34);\n\tthis.mResetCamRot = v54;\n\tthis.mResetCamRot.y = v54.y;\n\tthis.mResetCamRot.z = v54.z;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		Camera main = Camera.main;
		Transform transform = main.transform;
		Vector3 vector = (mResetCamPos = transform.position);
		mResetCamPos.y = vector.y;
		mResetCamPos.z = vector.z;
		Camera main2 = Camera.main;
		Transform transform2 = main2.transform;
		Vector3 vector2 = (mResetCamRot = transform2.eulerAngles);
		mResetCamRot.y = vector2.y;
		mResetCamRot.z = vector2.z;
	}

	[Token(Token = "0x6000082")]
	[Address(RVA = "0xB07DB4", Offset = "0xB07DB4", Length = "0x2C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Input::get_mousePosition();\n\tthis.mouseDelta = v11;\n\tthis.mouseDelta.y = v11.y;\n\tthis.mouseDelta.z = v11.z;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnEnable()
	{
		Vector3 vector = (mouseDelta = Input.mousePosition);
		mouseDelta.y = vector.y;
		mouseDelta.z = vector.z;
	}

	[Token(Token = "0x6000083")]
	[Address(RVA = "0xB07DE0", Offset = "0xB07DE0", Length = "0x7F8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = *([1EED840]);\n\tv37 = *([v36 @ X8_v53]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20224E8]) = v56;\nL_001F:\n\tv60 = UnityEngine.Input::get_mousePosition();\n\tgoto L_003C;\n\tv75 = *([v69 @ X0_v3+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tgoto L_003C;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v69, methodInfo, v40, v41, v42, v43, v44, v45, v60, v61, v62, v49, v50, v51, v52, v53);\nL_003C:\n\t// 60 MakeStruct v90 @ AGGB07E88_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.mouseDelta (UnityEngine.Vector3), this.mouseDelta.y (System.Single), this.mouseDelta.z (System.Single)\n\tv91 = UnityEngine.Vector3::op_Subtraction(v60, v90);\n\tthis.mouseDelta = v91;\n\tthis.mouseDelta.y = v91.y;\n\tthis.mouseDelta.z = v91.z;\n\tv97 = ~this.mMouseDown;\n\tif (v97) goto L_004A;\n\tv126 = UnityEngine.Input::GetMouseButtonUp(0);\n\tgoto L_0063;\nL_004A:\n\tv99 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv101 = v99 == 0;\n\tif (v101) goto L_0084;\n\tv108 = 0;\n\tv142 = 0x10CCF64(&v108 @ stack_-90_v4, 0, v40, v41, v42, v43, v44, v45, 0, 65f, 230f, 260f, this.mouseDelta.y, this.mouseDelta.z, v52, v53);\n\tv103 = 0;\n\tv121 = UnityEngine.Input::get_mousePosition();\n\tv126 = 0x10CD20C(&v103 @ stack_-80_v5, 0, v40, v41, v42, v43, v44, v45, v121, v121.y, v121.z, 260f, this.mouseDelta.y, this.mouseDelta.z, v52, v53);\nL_0063:\n\tv131 = ~v126;\n\tthis.mMouseDown = v131;\n\tv135 = v126 == 0;\n\tv136 = ~v135;\n\tif (v136) goto L_0087;\n\tgoto L_007B;\n\tv171 = *([v149 @ X0_v120+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_007B;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v149, v116, v40, v41, v42, v43, v44, v45, v120, v124, v122, v118, v86, v87, v52, v53);\nL_007B:\n\tv178 = this.mouseDelta * this.OrbitStrg;\n\tv179 = -v178;\n\tv180 = -this.OrbitClamp;\n\tv183 = UnityEngine.Mathf::Clamp(v179, v180, this.OrbitClamp);\n\tv188 = this.orbitAcceleration.y - v183;\n\tthis.orbitAcceleration.y = v188;\n\tgoto L_00AD;\nL_0084:\n\tthis.mMouseDown = 0;\nL_0087:\n\tv168 = UnityEngine.Input::GetMouseButton(2);\n\tv185 = v168 == 0;\n\tv186 = ~v185;\n\tif (v186) goto L_009C;\n\tv191 = UnityEngine.Input::GetMouseButton(1);\n\tv195 = v191 == 0;\n\tif (v195) goto L_00AD;\nL_009C:\n\tgoto L_00A2;\n\tv234 = *([v202 @ X0_v113+E0]);\n\tv235 = v234 == 0;\n\tv236 = ~v235;\n\tif (v236) goto L_00A2;\n\tv238 = \"il2cpp_codegen_runtime_class_init\"(v202, v192, v40, v41, v42, v43, v44, v45, v160, v162, v161, v159, v86, v87, v52, v53);\nL_00A2:\n\tv239 = this.mouseDelta.y * this.PanStrg;\n\tv240 = -v239;\n\tv222 = -this.PanClamp;\n\tv241 = UnityEngine.Mathf::Clamp(v240, v222, this.PanClamp);\n\tv214 = this.panAcceleration.y + v241;\n\tthis.panAcceleration.y = v214;\nL_00AD:\n\tv232 = UnityEngine.Input::GetKey(0x114);\n\tv243 = v232 == 0;\n\tif (v243) goto L_00B5;\n\tgoto L_00C5;\nL_00B5:\n\tv247 = UnityEngine.Input::GetKey(0x113);\n\tv262 = v247 == 0;\n\tv253 = ~v262;\n\tv250 = ~v253;\n\tif (v250) goto L_FFFFFFFF;\n\tgoto L_00C5;\nL_00C5:\n\tv276 = this.orbitAcceleration.y + v267;\n\tthis.orbitAcceleration.y = v276;\n\tv279 = UnityEngine.Input::GetKey(0x111);\n\tv282 = v279 == 0;\n\tif (v282) goto L_00D1;\n\tgoto L_00E0;\nL_00D1:\n\tv286 = UnityEngine.Input::GetKey(0x112);\n\tv296 = v286 == 0;\n\tv290 = ~v296;\n\tv288 = ~v290;\n\tif (v288) goto L_FFFFFFFF;\n\tgoto L_00E0;\nL_00E0:\n\tv308 = this.zoomAcceleration + v300;\n\tthis.zoomAcceleration = v308;\n\tv311 = UnityEngine.Input::GetKeyDown(0x72);\n\tv314 = v311 == 0;\n\tif (v314) goto L_00EB;\n\tTCP2_Demo_View::ResetView(this);\nL_00EB:\n\tv318 = UnityEngine.Camera::get_main();\n\tv321 = UnityEngine.Component::get_transform(v318);\n\tv619 = UnityEngine.Transform::get_localEulerAngles(v321);\n\tv633 = v619 >= 180f;\n\tif (v633) goto L_0122;\n\tv743 = v619 < 60f;\n\tif (v743) goto L_0122;\n\tv753 = this.orbitAcceleration.y <= 0;\n\tif (v753) goto L_0122;\n\tthis.orbitAcceleration.y = 0f;\nL_0122:\n\tv803 = this.orbitAcceleration.y;\n\tv768 = v619 < 300f;\n\tv769 = ~v768;\n\tv770 = v619 - 300f;\n\tv772 = v770 == 0;\n\tv777 = ~v772;\n\tv778 = v769 & v777;\n\tif (v778) goto L_0150;\n\tv793 = v619 <= 180f;\n\tif (v793) goto L_0150;\n\tv798 = this.orbitAcceleration.y >= 0;\n\tif (v798) goto L_0150;\n\tthis.orbitAcceleration.y = 0f;\nL_0150:\n\tgoto L_015A;\n\tv812 = *([v805 @ X0_v25+E0]);\n\tv813 = v812 == 0;\n\tv814 = ~v813;\n\tgoto L_015A;\n\tv816 = \"il2cpp_codegen_runtime_class_init\"(v805, v591, v40, v41, v42, v43, v44, v45, v619, v623, v766, v212, v86, v87, v52, v53);\nL_015A:\n\t// 346 MakeStruct v354 @ AGGB0810C_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.orbitAcceleration (UnityEngine.Vector3), v803 @ V8_v7 (System.Single), this.orbitAcceleration.z (System.Single)\n\tv822 = UnityEngine.Vector3::op_UnaryNegation(v354);\n\tv826 = UnityEngine.Time::get_deltaTime();\n\tv448 = UnityEngine.Vector3::op_Multiply(v822, v826);\n\tUnityEngine.Transform::Rotate(this.CharacterTransform, v448, 0);\n\tv511 = UnityEngine.Camera::get_main();\n\tv832 = UnityEngine.Component::get_transform(v511);\n\tv834 = UnityEngine.Time::get_deltaTime();\n\t// 388 MakeStruct v341 @ AGGB0818C_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.panAcceleration (UnityEngine.Vector3), this.panAcceleration.y (System.Single), this.panAcceleration.z (System.Single)\n\tv596 = UnityEngine.Vector3::op_Multiply(v341, v834);\n\tUnityEngine.Transform::Translate(v832, v596, 0);\n\tv843 = UnityEngine.Input::GetAxis(\"Mouse ScrollWheel\");\n\tv847 = v843 * this.ZoomStrg;\n\tv460 = this.zoomAcceleration + v847;\n\tthis.zoomAcceleration = v460;\n\tgoto L_01A6;\n\tv852 = *([v848 @ X0_v38+E0]);\n\tv853 = v852 == 0;\n\tv854 = ~v853;\n\tif (v854) goto L_01A6;\n\tv856 = \"il2cpp_codegen_runtime_class_init\"(v848, v424, v347, v41, v42, v43, v44, v45, v847, v844, v845, v445, v86, v87, v52, v53);\nL_01A6:\n\tv501 = -this.ZoomClamp;\n\tv449 = UnityEngine.Mathf::Clamp(v460, v501, this.ZoomClamp);\n\tthis.zoomAcceleration = v449;\n\tv512 = UnityEngine.Camera::get_main();\n\tv861 = UnityEngine.Component::get_transform(v512);\n\tv863 = UnityEngine.Vector3::get_forward();\n\tv868 = UnityEngine.Vector3::op_Multiply(v863, this.zoomAcceleration);\n\tv872 = UnityEngine.Time::get_deltaTime();\n\tv450 = UnityEngine.Vector3::op_Multiply(v868, v872);\n\tUnityEngine.Transform::Translate(v861, v450, 0);\n\tv513 = UnityEngine.Camera::get_main();\n\tv514 = UnityEngine.Component::get_transform(v513);\n\tv451 = UnityEngine.Transform::get_position(v514);\n\tv515 = UnityEngine.Camera::get_main();\n\tv516 = UnityEngine.Component::get_transform(v515);\n\tv896 = UnityEngine.Transform::get_position(v516);\n\tv900 = v896.z;\n\tv389 = v451.y <= 1.65f;\n\tif (v389) goto L_0213;\n\tv517 = UnityEngine.Camera::get_main();\n\tv903 = UnityEngine.Component::get_transform(v517);\n\tgoto L_022F;\nL_0213:\n\tv390 = v896.y >= 0.3f;\n\tif (v390) goto L_0232;\n\tv519 = UnityEngine.Camera::get_main();\n\tv520 = UnityEngine.Component::get_transform(v519);\n\tv896 = UnityEngine.Transform::get_position(v520);\n\tv900 = v896.z;\n\tv521 = UnityEngine.Camera::get_main();\n\tv903 = UnityEngine.Component::get_transform(v521);\nL_022F:\n\t// 559 MakeStruct v885 @ AGGB08354_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v896 @ V0_v31 (UnityEngine.Vector3), v901 @ V1_v25 (System.Single), v900 @ V2_v24 (System.Single)\n\tUnityEngine.Transform::set_position(v903, v885);\nL_0232:\n\tv523 = UnityEngine.Camera::get_main();\n\tv524 = UnityEngine.Component::get_transform(v523);\n\tv455 = UnityEngine.Transform::get_position(v524);\n\tv525 = UnityEngine.Camera::get_main();\n\tv526 = UnityEngine.Component::get_transform(v525);\n\tv935 = UnityEngine.Transform::get_position(v526);\n\tv945 = v935.y;\n\tv392 = v455.z >= -1.8f;\n\tif (v392) goto L_0272;\n\tv527 = UnityEngine.Camera::get_main();\n\tv947 = UnityEngine.Component::get_transform(v527);\n\tgoto L_028E;\nL_0272:\n\tv393 = v935.z <= -0.6f;\n\tif (v393) goto L_0297;\n\tv529 = UnityEngine.Camera::get_main();\n\tv530 = UnityEngine.Component::get_transform(v529);\n\tv935 = UnityEngine.Transform::get_position(v530);\n\tv945 = v935.y;\n\tv531 = UnityEngine.Camera::get_main();\n\tv947 = UnityEngine.Component::get_transform(v531);\nL_028E:\n\t// 654 MakeStruct v923 @ AGGB0843C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v935 @ V0_v35 (UnityEngine.Vector3), v945 @ V1_v29 (System.Single), v943 @ V2_v28 (System.Single)\n\tUnityEngine.T\n// ... truncated")]
	private void Update()
	{
		//IL_00e6: Expected O, but got I4
		//IL_00f9: Expected O, but got I4
		Vector3 mousePosition = Input.mousePosition;
		Vector3 vector = default(Vector3);
		vector.x = mouseDelta.x;
		vector.y = mouseDelta.y;
		vector.z = mouseDelta.z;
		Vector3 vector2 = (mouseDelta = mousePosition - vector);
		mouseDelta.y = vector2.y;
		mouseDelta.z = vector2.z;
		bool mouseButtonUp = default(bool);
		if (mMouseDown)
		{
			mouseButtonUp = Input.GetMouseButtonUp(0);
		}
		else
		{
			if (!Input.GetMouseButtonDown(0))
			{
				mMouseDown = false;
				goto IL_0bac;
			}
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			object obj2 = 0;
			Vector3 mousePosition2 = Input.mousePosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD20C (inside UnityEngine.Rect::MinMaxRect +0x270)");
		}
		bool flag = !mouseButtonUp;
		mMouseDown = flag;
		if (mouseButtonUp)
		{
			goto IL_0bac;
		}
		float num = mouseDelta.x * OrbitStrg;
		float value = 0f - num;
		float min = 0f - OrbitClamp;
		float num2 = Mathf.Clamp(value, min, OrbitClamp);
		float y = orbitAcceleration.y - num2;
		orbitAcceleration.y = y;
		goto IL_0be2;
		IL_07c6:
		Camera main = Camera.main;
		Transform transform = main.transform;
		Vector3 position = transform.position;
		Camera main2 = Camera.main;
		Transform transform2 = main2.transform;
		Vector3 position2 = transform2.position;
		float y2 = position2.y;
		Transform transform3;
		float z;
		if (position.z < -1.8f)
		{
			Camera main3 = Camera.main;
			transform3 = main3.transform;
			z = -1.8f;
		}
		else
		{
			if (!(position2.z > -0.6f))
			{
				goto IL_0916;
			}
			Camera main4 = Camera.main;
			Transform transform4 = main4.transform;
			position2 = transform4.position;
			y2 = position2.y;
			Camera main5 = Camera.main;
			transform3 = main5.transform;
			z = -0.6f;
		}
		Vector3 position3 = default(Vector3);
		position3.x = position2.x;
		position3.y = y2;
		position3.z = z;
		transform3.position = position3;
		goto IL_0916;
		IL_0be2:
		float num3 = (Input.GetKey(KeyCode.LeftArrow) ? 15f : ((!Input.GetKey(KeyCode.RightArrow)) ? 0f : (-15f)));
		float y3 = orbitAcceleration.y + num3;
		orbitAcceleration.y = y3;
		float num4 = (Input.GetKey(KeyCode.UpArrow) ? 1f : ((!Input.GetKey(KeyCode.DownArrow)) ? 0f : (-1f)));
		float num5 = zoomAcceleration + num4;
		zoomAcceleration = num5;
		if (Input.GetKeyDown(KeyCode.R))
		{
			ResetView();
		}
		Camera main6 = Camera.main;
		Transform transform5 = main6.transform;
		Vector3 localEulerAngles = transform5.localEulerAngles;
		if (localEulerAngles.x < 180f && !(localEulerAngles.x < 60f) && orbitAcceleration.y > 0f)
		{
			orbitAcceleration.y = 0f;
		}
		float y4 = orbitAcceleration.y;
		bool flag2 = localEulerAngles.x < 300f;
		bool flag3 = !flag2;
		float num6 = localEulerAngles.x - 300f;
		bool flag4 = num6 == 0f;
		bool flag5 = !flag4;
		if (!(flag3 && flag5) && localEulerAngles.x > 180f && orbitAcceleration.y < 0f)
		{
			orbitAcceleration.y = 0f;
			y4 = 0f;
		}
		Vector3 vector3 = default(Vector3);
		vector3.x = orbitAcceleration.x;
		vector3.y = y4;
		vector3.z = orbitAcceleration.z;
		Vector3 vector4 = -vector3;
		float deltaTime = Time.deltaTime;
		Vector3 eulers = vector4 * deltaTime;
		CharacterTransform.Rotate(eulers, default(Space));
		Camera main7 = Camera.main;
		Transform transform6 = main7.transform;
		float deltaTime2 = Time.deltaTime;
		Vector3 vector5 = default(Vector3);
		vector5.x = panAcceleration.x;
		vector5.y = panAcceleration.y;
		vector5.z = panAcceleration.z;
		Vector3 translation = vector5 * deltaTime2;
		transform6.Translate(translation, default(Space));
		float axis = Input.GetAxis("Mouse ScrollWheel");
		float num7 = axis * ZoomStrg;
		float value2 = (zoomAcceleration += num7);
		float min2 = 0f - ZoomClamp;
		float num8 = Mathf.Clamp(value2, min2, ZoomClamp);
		zoomAcceleration = num8;
		Camera main8 = Camera.main;
		Transform transform7 = main8.transform;
		Vector3 forward = Vector3.forward;
		Vector3 vector6 = forward * zoomAcceleration;
		float deltaTime3 = Time.deltaTime;
		Vector3 translation2 = vector6 * deltaTime3;
		transform7.Translate(translation2, default(Space));
		Camera main9 = Camera.main;
		Transform transform8 = main9.transform;
		Vector3 position4 = transform8.position;
		Camera main10 = Camera.main;
		Transform transform9 = main10.transform;
		Vector3 position5 = transform9.position;
		float z2 = position5.z;
		Transform transform10;
		float y5;
		if (position4.y > 1.65f)
		{
			Camera main11 = Camera.main;
			transform10 = main11.transform;
			y5 = 1.65f;
		}
		else
		{
			if (!(position5.y < 0.3f))
			{
				goto IL_07c6;
			}
			Camera main12 = Camera.main;
			Transform transform11 = main12.transform;
			position5 = transform11.position;
			z2 = position5.z;
			Camera main13 = Camera.main;
			transform10 = main13.transform;
			y5 = 0.3f;
		}
		Vector3 position6 = default(Vector3);
		position6.x = position5.x;
		position6.y = y5;
		position6.z = z2;
		transform10.position = position6;
		goto IL_07c6;
		IL_0916:
		Vector3 zero = Vector3.zero;
		float deltaTime4 = Time.deltaTime;
		float t = Decceleration * deltaTime4;
		Vector3 a = default(Vector3);
		a.x = orbitAcceleration.x;
		a.y = orbitAcceleration.y;
		a.z = orbitAcceleration.z;
		Vector3 vector7 = (orbitAcceleration = Vector3.Lerp(a, zero, t));
		orbitAcceleration.y = vector7.y;
		orbitAcceleration.z = vector7.z;
		Vector3 zero2 = Vector3.zero;
		float deltaTime5 = Time.deltaTime;
		float t2 = Decceleration * deltaTime5;
		Vector3 a2 = default(Vector3);
		a2.x = panAcceleration.x;
		a2.y = panAcceleration.y;
		a2.z = panAcceleration.z;
		Vector3 vector8 = (panAcceleration = Vector3.Lerp(a2, zero2, t2));
		panAcceleration.y = vector8.y;
		panAcceleration.z = vector8.z;
		float deltaTime6 = Time.deltaTime;
		float t3 = Decceleration * deltaTime6;
		float num9 = Mathf.Lerp(zoomAcceleration, 0f, t3);
		zoomAcceleration = num9;
		Vector3 zero3 = Vector3.zero;
		float deltaTime7 = Time.deltaTime;
		float t4 = Decceleration * deltaTime7;
		Vector3 a3 = default(Vector3);
		a3.x = moveAcceleration.x;
		a3.y = moveAcceleration.y;
		a3.z = moveAcceleration.z;
		Vector3 vector9 = (moveAcceleration = Vector3.Lerp(a3, zero3, t4));
		moveAcceleration.y = vector9.y;
		moveAcceleration.z = vector9.z;
		Vector3 vector10 = (mouseDelta = Input.mousePosition);
		mouseDelta.y = vector10.y;
		mouseDelta.z = vector10.z;
		return;
		IL_0bac:
		if (Input.GetMouseButton(2) || Input.GetMouseButton(1))
		{
			float num10 = mouseDelta.y * PanStrg;
			float value3 = 0f - num10;
			float min3 = 0f - PanClamp;
			float num11 = Mathf.Clamp(value3, min3, PanClamp);
			float y6 = panAcceleration.y + num11;
			panAcceleration.y = y6;
		}
		goto IL_0be2;
	}

	[Token(Token = "0x6000084")]
	[Address(RVA = "0xB085D8", Offset = "0xB085D8", Length = "0x6C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Camera::get_main();\n\tv14 = UnityEngine.Component::get_transform(v11);\n\t// 18 MakeStruct v17 @ AGGB0860C_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.mResetCamPos (UnityEngine.Vector3), this.mResetCamPos.y (System.Single), this.mResetCamPos.z (System.Single)\n\tUnityEngine.Transform::set_position(v14, v17);\n\tv36 = UnityEngine.Camera::get_main();\n\tv37 = UnityEngine.Component::get_transform(v36);\n\t// 36 MakeStruct v51 @ AGGB0863C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.mResetCamRot (UnityEngine.Vector3), this.mResetCamRot.y (System.Single), this.mResetCamRot.z (System.Single)\n\tUnityEngine.Transform::set_eulerAngles(v37, v51);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ResetView()
	{
		Camera main = Camera.main;
		Transform transform = main.transform;
		Vector3 position = default(Vector3);
		position.x = mResetCamPos.x;
		position.y = mResetCamPos.y;
		position.z = mResetCamPos.z;
		transform.position = position;
		Camera main2 = Camera.main;
		Transform transform2 = main2.transform;
		Vector3 eulerAngles = default(Vector3);
		eulerAngles.x = mResetCamRot.x;
		eulerAngles.y = mResetCamRot.y;
		eulerAngles.z = mResetCamRot.z;
		transform2.eulerAngles = eulerAngles;
	}

	[Token(Token = "0x6000085")]
	[Address(RVA = "0xB08644", Offset = "0xB08644", Length = "0x28")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ZoomStrg = 40f;\n\tthis.OrbitStrg = *([1819220]);\n\tthis.Decceleration = 8f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public TCP2_Demo_View()
	{
		//IL_0023: Expected F4, but got I
		base._002Ector();
		ZoomStrg = 40f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1819220]");
		OrbitStrg = 0f;
		Decceleration = 8f;
	}
}
