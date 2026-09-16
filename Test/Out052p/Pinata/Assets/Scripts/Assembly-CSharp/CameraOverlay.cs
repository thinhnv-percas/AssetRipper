using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[ExecuteInEditMode]
[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74C7D0", Offset = "0x74C7D0")]
[Token(Token = "0x2000017")]
public class CameraOverlay : MonoBehaviour
{
	[Token(Token = "0x40000BE")]
	[FieldOffset(Offset = "0x18")]
	private List<Transform> quads;

	[Token(Token = "0x600009A")]
	[Address(RVA = "0x9FD020", Offset = "0x9FD020", Length = "0x20C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = *([1EBBA98]);\n\tv33 = *([v32 @ X8_v29]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021C3F]) = v52;\nL_001C:\n\tv55 = UnityEngine.Component::get_gameObject(this);\n\tv60 = UnityEngine.GameObject::GetComponentsInChildren(v55);\n\tv276 = v60.Length;\n\tv123 = v60.Length == 0;\n\tif (v123) goto L_0080;\n\tv204 = v60.Length < 1;\n\tif (v204) goto L_0080;\nL_003E:\n\tv277 = v74 < v276;\n\tv108 = ~v277;\n\tif (v108) goto L_00C6;\n\tv293 = UnityEngine.Component::get_transform(this);\n\tgoto L_005D;\n\tv312 = *([v302 @ X8_v25+E0]);\n\tv313 = v312 == 0;\n\tv314 = ~v313;\n\tif (v314) goto L_005D;\n\tv328 = v302;\n\tv316 = \"il2cpp_codegen_runtime_class_init\"(v328, v292, v260, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_005D:\n\tv321 = UnityEngine.Object::op_Inequality(v60[v74 @ X23_v6 (System.Int32)], v293);\n\tv330 = v321 == 0;\n\tif (v330) goto L_0071;\n\tv335 = this.quads;\n\tv332 = this.quads == 0;\n\tv333 = ~v332;\n\tif (v333) goto L_0070;\n\tv325 = new System.Collections.Generic.List`1<UnityEngine.Transform>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::.ctor(v325);\n\tthis.quads = v325;\nL_0070:\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::Add(v335, v60[v74 @ X23_v6 (System.Int32)]);\nL_0071:\n\tv276 = v60.Length;\n\tv74 = v74 + 1;\n\tv219 = v74 < v60.Length;\n\tif (v219) goto L_003E;\nL_0080:\n\tv237 = this.quads == 0;\n\tif (v237) goto L_00AE;\n\tv247 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0097;\n\tv295 = *([v186 @ X8_v21+E0]);\n\tv296 = v295 == 0;\n\tv297 = ~v296;\n\tif (v297) goto L_0097;\n\tv310 = v186;\n\tv299 = \"il2cpp_codegen_runtime_class_init\"(v310, v246, v128, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0097:\n\tv177 = UnityEngine.Object::op_Implicit(v247);\n\tv180 = v177 == 0;\n\tif (v180) goto L_00AE;\n\treturn;\nL_00AE:\n\tgoto L_00C4;\n\tv283 = *([v256 @ X0_v9+E0]);\n\tv284 = v283 == 0;\n\tv285 = ~v284;\n\tif (v285) goto L_00C4;\n\tv287 = \"il2cpp_codegen_runtime_class_init\"(v256, v248, v128, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00C4:\n\tUnityEngine.Debug::Log(\"This script must be attached to Camera. Camera must have at least one Quad Transform as a child\");\n\treturn;\nL_00C6:\n\tv294 = new System.IndexOutOfRangeException();\n\tthrow v294;\n\tv113 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Start()
	{
		GameObject gameObject = base.gameObject;
		Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>();
		int num = componentsInChildren.Length;
		if (componentsInChildren.Length != 0 && componentsInChildren.Length >= 1)
		{
			int num2 = 0;
			do
			{
				if (num2 < num)
				{
					Transform transform = base.transform;
					if (componentsInChildren[num2] != transform)
					{
						List<Transform> list = quads;
						if (quads == null)
						{
							list = (quads = new List<Transform>());
						}
						list.Add(componentsInChildren[num2]);
					}
					num = componentsInChildren.Length;
					num2++;
					continue;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			while (num2 < componentsInChildren.Length);
		}
		if (quads != null)
		{
			Camera component = GetComponent<Camera>();
			if ((bool)component)
			{
				return;
			}
		}
		Debug.Log("This script must be attached to Camera. Camera must have at least one Quad Transform as a child");
	}

	[Token(Token = "0x600009B")]
	[Address(RVA = "0x9FD22C", Offset = "0x9FD22C", Length = "0x5E0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv42 = *([1EB4F60]);\n\tv43 = *([v42 @ X8_v48]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([2021C40]) = v62;\nL_0028:\n\tv72 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0039;\n\tv80 = *([v76 @ X8_v5+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tgoto L_0039;\n\tv90 = v76;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v90, v71, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\nL_0039:\n\tv89 = UnityEngine.Object::op_Implicit(v72);\n\tv92 = v89 == 0;\n\tif (v92) goto L_01E3;\n\tv94 = this.quads == 0;\n\tif (v94) goto L_01E3;\n\tv227 = UnityEngine.Component::GetComponent(this);\n\tv328 = UnityEngine.Camera::get_orthographic(v227);\n\tv396 = v328 == 0;\n\tif (v396) goto L_00AB;\n\tv492 = UnityEngine.Screen::get_width();\n\tv578 = UnityEngine.Screen::get_height();\n\tv382 = UnityEngine.Component::GetComponent(this);\n\tv366 = v492 / v578;\n\tv797 = UnityEngine.Camera::get_orthographicSize(v382);\n\tv369 = v797 + v797;\n\tv372 = v366 * v369;\n\tv857 = 0x1586898(&v363 @ stack_-90_v18, 0, v46, v47, v48, v49, v50, v51, v372, v369, 0, v55, v56, v57, v58, v59);\n\tv984 = System.Collections.Generic.List`1<UnityEngine.Transform>::GetEnumerator(this.quads);\nL_0071:\n\tv866 = System.Collections.Generic.List`1<UnityEngine.Transform>+Enumerator<UnityEngine.Transform>::MoveNext(&v583 @ stack_-C8_v17 (System.Collections.Generic.List`1<UnityEngine.Transform>+Enumerator<UnityEngine.Transform>));\n\tv867 = v866 == 0;\n\tif (v867) goto L_0187;\n\tv1170 = 0x1586898(&v583 @ stack_-C8_v17 (System.Collections.Generic.List`1<UnityEngine.Transform>+Enumerator<UnityEngine.Transform>), 0, v46, v47, v48, v49, v50, v51, v363, v1167, 1f, v55, v56, v57, v58, v59);\n\tv1110 = v638 == 0;\n\tif (v1110) goto L_0089;\n\t// 133 MakeStruct v1101 @ AGG9FD3CC_1_v18 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v583 @ stack_-C8_v17 (System.Collections.Generic.List`1<UnityEngine.Transform>+Enumerator<UnityEngine.Transform>), v1179 @ stack_-C4 (System.Single), 0\n\tUnityEngine.Transform::set_localScale(v638, v1101);\n\tgoto L_0071;\nL_0089:\n\tv1181 = new System.NullReferenceException();\n\tgoto L_0097;\n\tgoto L_0097;\nL_0097:\n\tgoto L_01E5;\n\tv1193 = 0x6D2BC0(v1181, 0, v1181, v47, v48, v49, v50, v51, v363, v1167, 1f, v55, v56, v57, v58, v59);\n\tv1198 = 0x6D2490(v1193, 0, v1181, v47, v48, v49, v50, v51, v363, v1167, 1f, v55, v56, v57, v58, v59);\n\tv515 = System.Collections.Generic.List`1<UnityEngine.Transform>+Enumerator<UnityEngine.Transform>::Dispose(&v583 @ stack_-C8_v17 (System.Collections.Generic.List`1<UnityEngine.Transform>+Enumerator<UnityEngine.Transform>));\n\tv1204 = *([v1193 @ X0_v107]) == 0;\n\tv517 = ~v1204;\n\tif (v517) goto L_0196;\nL_00AB:\n\tv584 = System.Collections.Generic.List`1<UnityEngine.Transform>::GetEnumerator(this.quads);\nL_00BC:\n\tv482 = System.Collections.Generic.List`1<UnityEngine.Transform>+Enumerator<UnityEngine.Transform>::MoveNext(&v583 @ stack_-C8_v17 (System.Collections.Generic.List`1<UnityEngine.Transform>+Enumerator<UnityEngine.Transform>));\n\tv799 = v482 == 0;\n\tif (v799) goto L_0187;\n\tv565 = UnityEngine.Transform::get_position(v638);\n\tv837 = v565.z;\n\tv571 = UnityEngine.Component::GetComponent(this);\n\tv630 = UnityEngine.Component::get_transform(v571);\n\tv1172 = UnityEngine.Transform::get_position(v630);\n\tgoto L_00EE;\n\tv1182 = *([v1175 @ X0_v51+E0]);\n\tv1183 = v1182 == 0;\n\tv1184 = ~v1183;\n\tif (v1184) goto L_00EE;\n\tv1186 = \"il2cpp_codegen_runtime_class_init\"(v1175, v1171, v456, v47, v48, v49, v50, v51, v1172, v1173, v1174, v416, v414, v412, v58, v59);\nL_00EE:\n\tv694 = UnityEngine.Vector3::Distance(v565, v1172);\n\tv700 = UnityEngine.Component::GetComponent(this);\n\tv1197 = UnityEngine.Component::get_transform(v700);\n\tUnityEngine.Transform::LookAt(v638, v1197);\n\tv788 = UnityEngine.Component::GetComponent(this);\n\tv967 = UnityEngine.Camera::get_nearClipPlane(v788);\n\tv719 = v694 >= v967;\n\tif (v719) goto L_0156;\n\tv973 = UnityEngine.Component::GetComponent(this);\n\tv1224 = UnityEngine.Camera::get_nearClipPlane(v973);\n\tv1230 = UnityEngine.Transform::get_forward(v638);\n\tgoto L_0127;\n\tv1252 = *([v1240 @ X0_v75+E0]);\n\tv1253 = v1252 == 0;\n\tv1254 = ~v1253;\n\tif (v1254) goto L_0127;\n\tv1256 = \"il2cpp_codegen_runtime_class_init\"(v1240, v1229, v728, v47, v48, v49, v50, v51, v1230, v1236, v1237, v657, v655, v653, v58, v59);\nL_0127:\n\tv1258 = v1224 * 1.1f;\n\tv1262 = UnityEngine.Vector3::op_Multiply(v1258, v1230);\n\tUnityEngine.Transform::Translate(v638, v1262);\n\tv1035 = UnityEngine.Transform::get_position(v638);\n\tv837 = v1035.z;\n\tv1041 = UnityEngine.Component::GetComponent(this);\n\tv1095 = UnityEngine.Component::get_transform(v1041);\n\tv1281 = UnityEngine.Transform::get_position(v1095);\n\tv1216 = UnityEngine.Vector3::Distance(v1035, v1281);\nL_0156:\n\tv849 = UnityEngine.Component::GetComponent(this);\n\tv1226 = UnityEngine.Camera::get_fieldOfView(v849);\n\tgoto L_0166;\n\tv1244 = *([v1232 @ X0_v63 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv1245 = v1244 == 0;\n\tv1246 = ~v1245;\n\tif (v1246) goto L_0166;\n\tv1248 = \"il2cpp_codegen_runtime_class_init\"(v1232, v1225, v728, v47, v48, v49, v50, v51, v1226, v841, v837, v714, v713, v712, v58, v59);\nL_0166:\n\tv1250 = v1226 * 0.017453292f;\n\tv914 = v1250 * 0.5f;\n\tv1251 = 0x6D25B0(UnityEngine.Mathf, 0, 0, v47, v48, v49, v50, v51, v914, 0.5f, v837, v714, v713, v712, v58, v59);\n\tv920 = UnityEngine.Component::GetComponent(this);\n\tv1271 = UnityEngine.Camera::get_aspect(v920);\n\tv1273 = v718 * v914;\n\tv1274 = v1273 + v1273;\n\tv1275 = v1274 * v1271;\n\tv1280 = 0x1586898(&v583 @ stack_-C8_v17 (System.Collections.Generic.List`1<UnityEngine.Transform>+Enumerator<UnityEngine.Transform>), 0, 0, v47, v48, v49, v50, v51, v1275, v1274, 1f, v714, v713, v712, v58, v59);\n\t// 384 MakeStruct v707 @ AGG9FD6B4_1_v16 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v583 @ stack_-C8_v17 (System.Collections.Generic.List`1<UnityEngine.Transform>+Enumerator<UnityEngine.Transform>), v1179 @ stack_-C4 (System.Single), 0\n\tUnityEngine.Transform::set_localScale(v638, v707);\n\tgoto L_00BC;\nL_0187:\n\tv202 = System.Collections.Generic.List`1<UnityEngine.Transform>+Enumerator<UnityEngine.Transform>::Dispose(&v179 @ stack_-B0_v16 (System.Collections.Generic.List`1<UnityEngine.Transform>+Enumerator<UnityEngine.Transform>));\n\tgoto L_01E3;\n\tthrow System.NullReferenceException;\n\tv490 = new System.NullReferenceException();\n\tv576 = new System.NullReferenceException();\n\tv635 = new System.NullReferenceException();\n\tv706 = new System.NullReferenceException();\n\tv793 = new System.NullReferenceException();\n\tv855 = new System.NullReferenceException();\n\tv924 = new System.NullReferenceException();\n\tv978 = new System.NullReferenceException();\n\tv1047 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0196:\n\tgoto L_01E9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\n\tgoto L_01B9;\nL_01B9:\n\tX8 = X1;\n\tX2 = X0;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01E5;\n\tX0 = X2;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EBC9F8]);\n\tX0 = &stack[20];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01E6;\nL_01E3:\n\treturn;\nL_01E5:\n\tv1195 = 0x6D2380(v1181, 0, v1181, v47, v48, v49, v50, v51, v363, v1167, 1f, v55, v56, v57, v58, v59);\nL_01E6:\n\t;\nL_01E9:\n\tthrow System.TypeLoadException;\n// 305 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		//IL_013d: Expected F4, but got O
		//IL_0462: Expected F4, but got O
		Camera component = GetComponent<Camera>();
		if (!component || quads == null)
		{
			return;
		}
		Camera component2 = GetComponent<Camera>();
		List<Transform>.Enumerator enumerator2 = default(List<Transform>.Enumerator);
		List<Transform>.Enumerator enumerator3;
		Transform transform = default(Transform);
		float y = default(float);
		if (component2.orthographic)
		{
			int width = Screen.width;
			int height = Screen.height;
			Camera component3 = GetComponent<Camera>();
			int num = width / height;
			float orthographicSize = component3.orthographicSize;
			float num2 = orthographicSize + orthographicSize;
			float num3 = (float)num * num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			List<Transform>.Enumerator enumerator = quads.GetEnumerator();
			Vector3 localScale = default(Vector3);
			while (true)
			{
				bool flag = enumerator2.MoveNext();
				bool flag2 = !flag;
				enumerator3 = enumerator2;
				if (flag2)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				if ((object)transform != null)
				{
					localScale.x = (float)enumerator2;
					localScale.y = y;
					localScale.z = 0f;
					transform.localScale = localScale;
					continue;
				}
				NullReferenceException ex = new NullReferenceException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				throw new TypeLoadException();
			}
		}
		else
		{
			List<Transform>.Enumerator enumerator4 = quads.GetEnumerator();
			Vector3 localScale2 = default(Vector3);
			while (true)
			{
				bool flag3 = enumerator2.MoveNext();
				bool flag4 = !flag3;
				enumerator3 = enumerator2;
				if (flag4)
				{
					break;
				}
				Vector3 position = transform.position;
				float z = position.z;
				Camera component4 = GetComponent<Camera>();
				Transform transform2 = component4.transform;
				Vector3 position2 = transform2.position;
				float num4 = Vector3.Distance(position, position2);
				Camera component5 = GetComponent<Camera>();
				Transform target = component5.transform;
				transform.LookAt(target);
				Camera component6 = GetComponent<Camera>();
				float nearClipPlane = component6.nearClipPlane;
				bool flag5 = !(num4 < nearClipPlane);
				float z2 = position2.z;
				float y2 = position2.y;
				Vector3 vector = position2;
				float num5 = num4;
				if (!flag5)
				{
					Camera component7 = GetComponent<Camera>();
					float nearClipPlane2 = component7.nearClipPlane;
					Vector3 forward = transform.forward;
					float num6 = nearClipPlane2 * 1.1f;
					Vector3 translation = num6 * forward;
					transform.Translate(translation);
					Vector3 position3 = transform.position;
					z = position3.z;
					Camera component8 = GetComponent<Camera>();
					Transform transform3 = component8.transform;
					Vector3 position4 = transform3.position;
					float num7 = Vector3.Distance(position3, position4);
					z2 = position4.z;
					y2 = position4.y;
					vector = position4;
					num5 = num7;
				}
				Camera component9 = GetComponent<Camera>();
				float fieldOfView = component9.fieldOfView;
				float num8 = fieldOfView * ((float)Math.PI / 180f);
				float num9 = num8 * 0.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D25B0 (native tanf)");
				Camera component10 = GetComponent<Camera>();
				float aspect = component10.aspect;
				float num10 = num5 * num9;
				float num11 = num10 + num10;
				float num12 = num11 * aspect;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				localScale2.x = (float)enumerator2;
				localScale2.y = y;
				localScale2.z = 0f;
				transform.localScale = localScale2;
			}
		}
		enumerator3.Dispose();
	}

	[Token(Token = "0x600009C")]
	[Address(RVA = "0x9FD80C", Offset = "0x9FD80C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public CameraOverlay()
	{
	}
}
