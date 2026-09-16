using System;
using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[ExecuteInEditMode]
[Token(Token = "0x2000014")]
public class TCP2_PlanarReflection : MonoBehaviour
{
	[Token(Token = "0x40000B1")]
	[FieldOffset(Offset = "0x18")]
	public bool m_DisablePixelLights;

	[Token(Token = "0x40000B2")]
	[FieldOffset(Offset = "0x1C")]
	public int m_TextureSize;

	[Token(Token = "0x40000B3")]
	[FieldOffset(Offset = "0x20")]
	public float m_ClipPlaneOffset;

	[Token(Token = "0x40000B4")]
	[FieldOffset(Offset = "0x24")]
	public LayerMask m_ReflectLayers;

	[Token(Token = "0x40000B5")]
	[FieldOffset(Offset = "0x28")]
	private Hashtable m_ReflectionCameras;

	[Token(Token = "0x40000B6")]
	[FieldOffset(Offset = "0x30")]
	private RenderTexture m_ReflectionTexture;

	[Token(Token = "0x40000B7")]
	[FieldOffset(Offset = "0x38")]
	private int m_OldReflectionTextureSize;

	[Token(Token = "0x40000B8")]
	private static bool s_InsideRendering;

	[Token(Token = "0x600008D")]
	[Address(RVA = "0xB092C8", Offset = "0xB092C8", Length = "0x5F4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv36 = &v37 @ stack_-10_v2;\n\tgoto L_0022;\n\tv46 = *([1F01B20]);\n\tv47 = *([v46 @ X8_v51]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv66 = 0 | 1;\n\t*([20224EB]) = v66;\nL_0022:\n\t*([v36 @ X29_v1-88]) = 0;\n\t*([v36 @ X29_v1-98]) = 0;\n\t*([v36 @ X29_v1-C0]) = 0;\n\t*([v36 @ X29_v1-B0]) = 0;\n\t*([v36 @ X29_v1-E0]) = 0;\n\t*([v36 @ X29_v1-D0]) = 0;\n\tv72 = UnityEngine.Component::GetComponent(this);\n\tv76 = UnityEngine.Behaviour::get_enabled(this);\n\tv78 = v76 == 0;\n\tif (v78) goto L_025D;\n\tgoto L_0043;\n\tv510 = *([v81 @ X0_v7+E0]);\n\tv511 = v510 == 0;\n\tv512 = ~v511;\n\tif (v512) goto L_0043;\n\tv514 = \"il2cpp_codegen_runtime_class_init\"(v81, v75, v50, v51, v52, v53, v54, v55, v69, v57, v58, v59, v60, v61, v62, v63);\nL_0043:\n\tv472 = UnityEngine.Object::op_Implicit(v72);\n\tv479 = v472 == 0;\n\tif (v479) goto L_025D;\n\tv799 = UnityEngine.Renderer::get_sharedMaterial(v72);\n\tgoto L_005A;\n\tv1172 = *([v487 @ X8_v11+E0]);\n\tv1173 = v1172 == 0;\n\tv1174 = ~v1173;\n\tif (v1174) goto L_005A;\n\tv1187 = v487;\n\tv1176 = \"il2cpp_codegen_runtime_class_init\"(v1187, v798, v50, v51, v52, v53, v54, v55, v69, v57, v58, v59, v60, v61, v62, v63);\nL_005A:\n\tv473 = UnityEngine.Object::op_Implicit(v799);\n\tv480 = v473 == 0;\n\tif (v480) goto L_025D;\n\tv474 = UnityEngine.Renderer::get_enabled(v72);\n\tv481 = v474 == 0;\n\tif (v481) goto L_025D;\n\tv1192 = UnityEngine.Camera::get_current();\n\tgoto L_0074;\n\tv1196 = *([v488 @ X8_v12+E0]);\n\tv1197 = v1196 == 0;\n\tv1198 = ~v1197;\n\tif (v1198) goto L_0074;\n\tv1203 = v488;\n\tv1200 = \"il2cpp_codegen_runtime_class_init\"(v1203, v468, v50, v51, v52, v53, v54, v55, v69, v57, v58, v59, v60, v61, v62, v63);\nL_0074:\n\tv475 = UnityEngine.Object::op_Implicit(v1192);\n\tv482 = v475 == 0;\n\tif (v482) goto L_025D;\n\tgoto L_0087;\n\tv1210 = *([v1206 @ X0_v30 (Il2CppClass<TCP2_PlanarReflection>)+E0]);\n\tv1211 = v1210 == 0;\n\tv1212 = ~v1211;\n\tif (v1212) goto L_0087;\n\tv1217 = \"il2cpp_codegen_runtime_class_init\"(v1206, v469, v50, v51, v52, v53, v54, v55, v69, v57, v58, v59, v60, v61, v62, v63);\n\tv1213 = TCP2_PlanarReflection;\nL_0087:\n\tv1216 = ~v489.s_InsideRendering;\n\tv483 = ~v1216;\n\tif (v483) goto L_025D;\n\tgoto L_0096;\n\tv1221 = *([v476 @ X0_v31 (Il2CppClass<TCP2_PlanarReflection>)+E0]);\n\tv1222 = v1221 == 0;\n\tv1223 = ~v1222;\n\tif (v1223) goto L_0096;\n\tv1226 = \"il2cpp_codegen_runtime_class_init\"(v476, v469, v50, v51, v52, v53, v54, v55, v69, v57, v58, v59, v60, v61, v62, v63);\n\tv1232 = TCP2_PlanarReflection;\n\tv1228 = *([v1232 @ X8_v45+B8]);\nL_0096:\n\tv1115 = &v37 @ stack_-10_v2 - 0x88;\n\tv1169.s_InsideRendering = 1;\n\tTCP2_PlanarReflection::CreateMirrorObjects(this, v1192, v1115);\n\tv1153 = UnityEngine.Component::get_transform(this);\n\tv1136 = UnityEngine.Transform::get_position(v1153);\n\tv1154 = UnityEngine.Component::get_transform(this);\n\tv1236 = UnityEngine.Transform::get_up(v1154);\n\tv1240 = UnityEngine.QualitySettings::get_pixelLightCount();\n\tv1242 = ~this.m_DisablePixelLights;\n\tif (v1242) goto L_00BF;\n\tUnityEngine.QualitySettings::set_pixelLightCount(0);\nL_00BF:\n\tTCP2_PlanarReflection::UpdateCameraModes(v1246, v1192, *([v36 @ X29_v1-88]));\n\tgoto L_00D7;\n\tv1254 = *([v1250 @ X0_v41+E0]);\n\tv1255 = v1254 == 0;\n\tv1256 = ~v1255;\n\tif (v1256) goto L_00D7;\n\tv1258 = \"il2cpp_codegen_runtime_class_init\"(v1250, v1247, v936, v51, v52, v53, v54, v55, v1236, v1237, v1238, v59, v60, v61, v62, v63);\nL_00D7:\n\tv1266 = UnityEngine.Vector3::Dot(v1236, v1136);\n\tv1268 = -v1266;\n\tv1269 = &v37 @ stack_-10_v2 - 0x98;\n\tv1271 = v1268 - this.m_ClipPlaneOffset;\n\tv1274 = 0x158BA74(v1269, 0, *([v36 @ X29_v1-88]), v51, v52, v53, v54, v55, v1236, v1236.y, v1236.z, v1271, v1136.y, v1136.z, v62, v63);\n\tgoto L_00ED;\n\tv1281 = *([v1277 @ X0_v46+E0]);\n\tv1282 = v1281 == 0;\n\tv1283 = ~v1282;\n\tif (v1283) goto L_00ED;\n\tv1285 = \"il2cpp_codegen_runtime_class_init\"(v1277, v973, v936, v51, v52, v53, v54, v55, v1272, v1273, v1270, v1271, v931, v929, v62, v63);\nL_00ED:\n\tv1288 = &v409 @ stack_-130;\n\tv1290 = UnityEngine.Matrix4x4::get_zero();\n\t*([v36 @ X29_v1-E0]) = *([v1288 @ X8_v26]);\n\t*([v36 @ X29_v1-D0]) = *([v1288 @ X8_v26+10]);\n\t*([v36 @ X29_v1-C0]) = *([v1288 @ X8_v26+20]);\n\t*([v36 @ X29_v1-B0]) = *([v1288 @ X8_v26+30]);\n\tgoto L_0116;\n\tv1299 = *([v1295 @ X0_v50+E0]);\n\tv1300 = v1299 == 0;\n\tv1301 = ~v1300;\n\tif (v1301) goto L_0116;\n\tv1303 = \"il2cpp_codegen_runtime_class_init\"(v1295, v973, v936, v51, v52, v53, v54, v55, v1291, v1294, v1293, v1292, v931, v929, v62, v63);\nL_0116:\n\tv978 = &v37 @ stack_-10_v2 - 0xE0;\n\t// 283 MakeStruct v356 @ AGGB095C4_1_v5 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), [v36 @ X29_v1-98], [v36 @ X29_v1-94], [v36 @ X29_v1-90], [v36 @ X29_v1-8C]\n\tTCP2_PlanarReflection::CalculateReflectionMatrix(v978, v356);\n\tv1155 = UnityEngine.Component::get_transform(v1192);\n\tv1307 = UnityEngine.Transform::get_position(v1155);\n\tv1310 = &v37 @ stack_-10_v2 - 0xE0;\n\tv1312 = 0x10C2764(v1310, 0, *([v36 @ X29_v1-88]), v51, v52, v53, v54, v55, v1307, v1307.y, v1307.z, *([v36 @ X29_v1-8C]), v1136.y, v1136.z, v62, v63);\n\tv1313 = &v348 @ stack_-170;\n\tv1316 = UnityEngine.Camera::get_worldToCameraMatrix(v1192);\n\tv348 = *([v1313 @ X8_v29]);\n\tv1271 = *([v36 @ X29_v1-E0]);\n\tv989 = &v276 @ stack_-1B0;\n\tv979 = UnityEngine.Matrix4x4::op_Multiply(&v348 @ stack_-170, &v1271 @ V3_v6 (System.Single));\n\tv276 = *([v989 @ X8_v30]);\n\tUnityEngine.Camera::set_worldToCameraMatrix(*([v36 @ X29_v1-88]), &v276 @ stack_-1B0);\n\tv1335 = TCP2_PlanarReflection::CameraSpacePlane(this, *([v36 @ X29_v1-88]), v1136, v1236, 1f);\n\tv1341 = UnityEngine.Camera::CalculateObliqueMatrix(v1192, v1335);\n\tv204 = v1341.m00;\n\tUnityEngine.Camera::set_projectionMatrix(*([v36 @ X29_v1-88]), &v204 @ stack_-2B0_v5 (System.Single));\n\tv1345 = this + 0x24;\n\tv1347 = 0x101CD5C(v1345, 0, 0, v51, v52, v53, v54, v55, v204, v1341.m01, v1341.m02, v1341.m03, v1236.y, v1236.z, 1f, v63);\n\tv1348 = v1347 & 0xFFFFFFEF;\n\tUnityEngine.Camera::set_cullingMask(*([v36 @ X29_v1-88]), v1348);\n\tUnityEngine.Camera::set_targetTexture(*([v36 @ X29_v1-88]), this.m_ReflectionTexture);\n\tUnityEngine.GL::set_invertCulling(1);\n\tv1156 = UnityEngine.Component::get_transform(*([v36 @ X29_v1-88]));\n\tUnityEngine.Transform::set_position(v1156, v1307);\n\tv1157 = UnityEngine.Component::get_transform(v1192);\n\tv1359 = UnityEngine.Transform::get_eulerAngles(v1157);\n\tv1364 = UnityEngine.Component::get_transform(*([v36 @ X29_v1-88]));\n\tv126 = 0;\n\tv980 = 0x1586898(&v126 @ stack_-340_v5, 0, 0, v51, v52, v53, v54, v55, 0, v1359.y, v1359.z, v1341.m03, v1236.y, v1236.z, 1f, v63);\n\t// 484 MakeStruct v123 @ AGGB0978C_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v1366 @ stack_-33C, 0\n\tUnityEngine.Transform::set_eulerAngles(v1364, v123);\n\tUnityEngine.Camera::Render(*([v36 @ X29_v1-88]));\n\tv1158 = UnityEngine.Component::get_transform(*([v36 @ X29_v1-88]));\n\tUnityEngine.Transform::set_position(v1158, v1307);\n\tUnityEngine.GL::set_invertCulling(0);\n\tv1159 = UnityEngine.Renderer::get_sharedMaterials(v72);\n\tv1185 = v1159.Length;\n\tv1387 = v1159.Length < 1;\n\tif (v1387) goto L_0237;\nL_020D:\n\tv1420 = v942 < v1185;\n\tv823 = ~v1420;\n\tif (v823) goto L_0260;\n\tv1436 = UnityEngine.Material::HasProperty(v1159[v942 @ X23_v9 (System.Int32)], \"_ReflectionTex\");\n\tv1407 = v1436 == 0;\n\tif (v1407) goto L_0228;\n\tUnityEngine.Material::SetTexture(v1159[v942 @ X23_v9 (System.Int32)], \"_ReflectionTex\", this.m_ReflectionTexture);\nL_0228:\n\tv1185 = v1159.Length;\n\tv942 = v942 + 1;\n\tv1391 = v942 < v1159.Length;\n\tif (v1391) goto L_020D;\nL_0237:\n\tv1411 = ~this.m_DisablePixelLights;\n\tif (v1411) goto L_0240;\n\tUnityEngine.QualitySettings::set_pixelLightCount(v1240);\nL_0240:\n\tgoto L_0248;\n\tv1428 = *([v1424 @ X0_v88 (Il2CppClass<TCP2_PlanarReflection>)+E0]);\n\tv1429 = v1428 == 0;\n\tv1430 = ~v1429;\n\tif (v1430) goto L_0248;\n\tv1437 = \"il2cpp_codegen_runtime_class_init\"(v1424, v465, v429, v86, v52, v53, v54, v55, v449, v447, v445, v427, v425, v423, v216, v63);\n\tv1431 = TCP2_PlanarReflection;\nL_0248:\n\tv485.s_InsideRendering = 0;\nL_025D:\n\treturn;\n\tv1171 = new System.NullReferenceException();\nL_0260:\n\tv1186 = new System.IndexOutOfRangeException();\n\tthrow v1186;\n\treturn;\n// 434 bookkeeping instructions omitted: flag re\n// ... truncated")]
	public unsafe void OnWillRenderObject()
	{
		//IL_0130: Expected O, but got I4
		//IL_016b: Expected O, but got I
		//IL_018a: Expected O, but got F4
		//IL_0199: Expected O, but got I
		//IL_0224: Expected F4, but got I
		//IL_0239: Expected F4, but got I
		//IL_024e: Expected F4, but got I
		//IL_0263: Expected F4, but got I
		//IL_02a3: Expected O, but got I
		//IL_02df: Expected F4, but got I
		//IL_02f4: Expected O, but got Ref
		//IL_02f4: Expected O, but got Ref
		//IL_031f: Expected O, but got Ref
		//IL_031f: Expected O, but got I
		//IL_033e: Expected O, but got I
		//IL_037a: Expected O, but got Ref
		//IL_037a: Expected O, but got I
		//IL_038b: Expected O, but got I
		//IL_03a8: Expected I4, but got I8
		//IL_03bd: Expected O, but got I
		//IL_03d9: Expected O, but got I
		//IL_03f9: Expected O, but got I
		//IL_043f: Expected O, but got I
		//IL_0451: Expected O, but got I4
		//IL_047b: Expected F4, but got O
		//IL_04a7: Expected O, but got I
		//IL_04bd: Expected O, but got I
		object obj2 = default(object);
		object obj = obj2;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Renderer component = GetComponent<Renderer>();
		if (!base.enabled || !component)
		{
			return;
		}
		Material sharedMaterial = component.sharedMaterial;
		if (!sharedMaterial || !component.enabled)
		{
			return;
		}
		Camera current = Camera.current;
		if (!current || s_InsideRendering)
		{
			return;
		}
		ref Camera reflectionCamera = ref *(Camera*)((long)(IntPtr)obj2 - 136L);
		s_InsideRendering = true;
		CreateMirrorObjects(current, out reflectionCamera);
		Transform transform = base.transform;
		Vector3 position = transform.position;
		Transform transform2 = base.transform;
		Vector3 up = transform2.up;
		int pixelLightCount = QualitySettings.pixelLightCount;
		bool flag = !m_DisablePixelLights;
		TCP2_PlanarReflection tCP2_PlanarReflection = (TCP2_PlanarReflection)pixelLightCount;
		if (!flag)
		{
			QualitySettings.pixelLightCount = 0;
			tCP2_PlanarReflection = null;
		}
		TCP2_PlanarReflection tCP2_PlanarReflection2 = tCP2_PlanarReflection;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
		tCP2_PlanarReflection2.UpdateCameraModes(current, (Camera)0);
		float num = Vector3.Dot(up, position);
		object obj3 = 0f - num;
		object obj4 = (long)(IntPtr)obj2 - 152L;
		float num2 = (float)obj3 - m_ClipPlaneOffset;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
		object obj6 = default(object);
		object obj5 = obj6;
		Matrix4x4 zero = Matrix4x4.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1288 @ X8_v26+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1288 @ X8_v26+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1288 @ X8_v26+30]");
		_ = 0;
		ref Matrix4x4 reflectionMat = ref *(Matrix4x4*)((long)(IntPtr)obj2 - 224L);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-98]");
		Vector4 plane = default(Vector4);
		plane.x = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-94]");
		plane.y = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-90]");
		plane.z = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-8C]");
		plane.w = 0f;
		CalculateReflectionMatrix(ref reflectionMat, plane);
		Transform transform3 = current.transform;
		Vector3 position2 = transform3.position;
		object obj7 = (long)(IntPtr)obj2 - 224L;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2764 (inside UnityEngine.Matrix4x4::op_Multiply +0x110)");
		object obj9 = default(object);
		object obj8 = obj9;
		Matrix4x4 worldToCameraMatrix = current.worldToCameraMatrix;
		obj9 = obj8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-E0]");
		num2 = 0f;
		object obj11 = default(object);
		object obj10 = obj11;
		Matrix4x4 matrix4x = (Matrix4x4)(&obj9) * (Matrix4x4)(&num2);
		obj11 = obj10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
		((Camera)0).worldToCameraMatrix = (Matrix4x4)(&obj11);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
		Vector4 clipPlane = CameraSpacePlane((Camera)0, position, up, 1f);
		float m = current.CalculateObliqueMatrix(clipPlane).m00;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
		((Camera)0).projectionMatrix = (Matrix4x4)(&m);
		object obj12 = (long)(IntPtr)this + 36L;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101CD5C (inside UnityEngine.LayerMask::op_Implicit +0x8)");
		object obj13 = default(object);
		int cullingMask = (int)((long)(IntPtr)obj13 & 0xFFFFFFEFL);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
		((Camera)0).cullingMask = cullingMask;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
		((Camera)0).targetTexture = m_ReflectionTexture;
		GL.invertCulling = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
		Transform transform4 = ((Component)0).transform;
		transform4.position = position2;
		Transform transform5 = current.transform;
		Vector3 eulerAngles = transform5.eulerAngles;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
		Transform transform6 = ((Component)0).transform;
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
		Vector3 eulerAngles2 = default(Vector3);
		eulerAngles2.x = 0f;
		object obj15 = default(object);
		eulerAngles2.y = (float)obj15;
		eulerAngles2.z = 0f;
		transform6.eulerAngles = eulerAngles2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
		((Camera)0).Render();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-88]");
		Transform transform7 = ((Component)0).transform;
		transform7.position = position2;
		GL.invertCulling = false;
		Material[] sharedMaterials = component.sharedMaterials;
		int num3 = sharedMaterials.Length;
		if (sharedMaterials.Length >= 1)
		{
			int num4 = 0;
			do
			{
				if (num4 < num3)
				{
					if (sharedMaterials[num4].HasProperty("_ReflectionTex"))
					{
						sharedMaterials[num4].SetTexture("_ReflectionTex", m_ReflectionTexture);
					}
					num3 = sharedMaterials.Length;
					num4++;
					continue;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			while (num4 < sharedMaterials.Length);
		}
		if (m_DisablePixelLights)
		{
			QualitySettings.pixelLightCount = pixelLightCount;
		}
		s_InsideRendering = false;
	}

	[Token(Token = "0x600008E")]
	[Address(RVA = "0xB0A57C", Offset = "0xB0A57C", Length = "0x33C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = *([1ED4AB8]);\n\tv29 = *([v28 @ X8_v44]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20224EC]) = v48;\nL_001F:\n\tgoto L_0027;\n\tv56 = *([v52 @ X0_v2+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tgoto L_0027;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0027:\n\tv65 = UnityEngine.Object::op_Implicit(this.m_ReflectionTexture);\n\tv67 = v65 == 0;\n\tif (v67) goto L_003A;\n\tgoto L_0038;\n\tv84 = *([v68 @ X0_v61+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_0038;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v68, v64, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0038:\n\tUnityEngine.Object::DestroyImmediate(this.m_ReflectionTexture);\n\tthis.m_ReflectionTexture = 0;\nL_003A:\n\tv82 = this.m_ReflectionCameras;\n\tv89 = *([v82 @ X0_v7 (System.Collections.Hashtable)]);\n\tv308 = *([v89 @ X8_v9 (Il2CppClass<System.Collections.Hashtable>)+298]);\n\tv92 = System.Collections.Hashtable::GetEnumerator(v82);\n\tv94 = v92 == 0;\n\tif (v94) goto L_00ED;\nL_004E:\n\tgoto L_0075;\n\tv314 = *([v275 @ X8_v19+B0]);\n\tv315 = 0;\n\tv316 = v314 + 8;\n\tv318 = *([v356 @ X11_v24-8]);\n\tv361 = v318 == v276;\n\tif (v361) goto L_006E;\n\tv338 = v355 + 1;\n\tv407 = v338 < v277;\n\tv336 = ~v407;\n\tv340 = v356 + 0x10;\n\tv320 = ~v336;\n\tif (v320) goto L_FFFFFFFF;\n\tv341 = v93;\n\tv342 = 0;\n\tv343 = 0x8909C4(v341, v276, v342, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0075;\nL_006E:\n\tv408 = *([v356 @ X11_v24]);\n\tv409 = v408 << 4;\n\tv410 = v275 + v409;\n\tv411 = v410 + 0x130;\nL_0075:\n\tv432 = System.Collections.IEnumerator::MoveNext(v92);\n\tv434 = v432 == 0;\n\tif (v434) goto L_FFFFFFFF;\n\tv437 = *([v92 @ X0_v15 (System.Collections.IEnumerator)]);\n\tv440 = *([v437 @ X8_v22 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v440) goto L_009B;\n\tv509 = *([v437 @ X8_v22 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0086:\n\tv514 = *([v509 @ X11_v19-8]) == System.Collections.IEnumerator;\n\tif (v514) goto L_009E;\n\tv508 = v508 + 1;\n\tv520 = v508 < *([v437 @ X8_v22 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv466 = ~v520;\n\tv509 = v509 + 0x10;\n\tv450 = ~v466;\n\tif (v450) goto L_0086;\nL_009B:\n\tv536 = 0x8909C4(v92, System.Collections.IEnumerator, 1, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_00A5;\nL_009E:\n\tv522 = *([v509 @ X11_v19]) + 1;\n\tv523 = v522 << 4;\n\tv524 = v437 + v523;\n\tv536 = v524 + 0x130;\nL_00A5:\n\t*([v536 @ X0_v35])(v541, v92, *([v536 @ X0_v35+8]), v283, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv584 = v584_asT == 0;\n\tif (v584) goto L_00E8;\n\tv632 = \"il2cpp_vm_object_unbox\"(v541, System.Collections.DictionaryEntry, v283, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv646 = *([v632 @ X0_v47+8]);\n\tv706 = *([v646 @ X0_v48 (UnityEngine.Component)]) != UnityEngine.Camera;\n\tif (v706) goto L_00EC;\n\tv246 = *([v646 @ X0_v48 (UnityEngine.Component)]) != UnityEngine.Camera;\n\tif (v246) goto L_00EA;\n\tv710 = UnityEngine.Component::get_gameObject(v646);\n\tgoto L_00E3;\n\tv715 = *([v711 @ X0_v50+E0]);\n\tv716 = v715 == 0;\n\tv717 = ~v716;\n\tif (v717) goto L_00E3;\n\tv719 = \"il2cpp_codegen_runtime_class_init\"(v711, v709, v173, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00E3:\n\tUnityEngine.Object::DestroyImmediate(v710);\n\tgoto L_004E;\n\tgoto L_0108;\nL_00E8:\n\tv597 = new System.InvalidCastException();\n\tv599 = new System.NullReferenceException();\nL_00EA:\n\tv651 = new System.InvalidCastException();\n\tv687 = new System.NullReferenceException();\nL_00EC:\n\tv204 = new System.InvalidCastException();\nL_00ED:\n\tv209 = new System.NullReferenceException();\n\tgoto L_00FE;\n\tgoto L_00FE;\n\tgoto L_00FE;\n\tgoto L_00FE;\n\tgoto L_00FE;\n\tgoto L_00FE;\n\tgoto L_00FE;\nL_00FE:\n\tv285 = v308 != 1;\n\tif (v285) goto L_0158;\n\tv366 = 0x6D2BC0(v209, v308, v283, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv101 = *([v366 @ X0_v29]);\n\tv436 = 0x6D2490(v366, v308, v283, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0108:\n\t// 264 IsInst v497 @ X0_v18 (System.IDisposable), typeof(System.IDisposable), v92 @ X0_v15 (System.Collections.IEnumerator)\n\tv519 = v497 == 0;\n\tif (v519) goto L_0138;\n\tgoto L_0137;\n\tv600 = *([v543 @ X8_v13+B0]);\n\tv601 = 0;\n\tv602 = v600 + 8;\n\tv604 = *([v663 @ X11_v10-8]);\n\tv668 = v604 == v544;\n\tif (v668) goto L_0130;\n\tv624 = v662 + 1;\n\tv688 = v624 < v545;\n\tv622 = ~v688;\n\tv626 = v663 + 0x10;\n\tv606 = ~v622;\n\tif (v606) goto L_FFFFFFFF;\n\tv627 = v158;\n\tv628 = 0;\n\tv629 = 0x8909C4(v627, v544, v628, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0137;\nL_0130:\n\tv689 = *([v663 @ X11_v10]);\n\tv690 = v689 << 4;\n\tv691 = v543 + v690;\n\tv692 = v691 + 0x130;\nL_0137:\n\tSystem.IDisposable::Dispose(v497);\nL_0138:\n\tv571 = v99 + 1;\n\tv123 = v571 == 0;\n\tv108 = ~v123;\n\tif (v108) goto L_0142;\n\tv630 = v101 == 0;\n\tv234 = ~v630;\n\tif (v234) goto L_0157;\nL_0142:\n\tv152 = this.m_ReflectionCameras;\n\tv402 = *([v152 @ X0_v20 (System.Collections.Hashtable)]);\n\tv376 = *([v402 @ X8_v12 (Il2CppClass<System.Collections.Hashtable>)+220]);\n\tv396 = *([v402 @ X8_v12 (Il2CppClass<System.Collections.Hashtable>)+228]);\n\t// 338 IndirectJump v376 @ X2_v7, v152 @ X0_v20 (System.Collections.Hashtable), v152 @ X0_v20 (System.Collections.Hashtable), v396 @ X1_v11, v376 @ X2_v7, v33 @ X3, v34 @ X4, v35 @ X5, v36 @ X6, v37 @ X7, v38 @ V0, v39 @ V1, v40 @ V2, v41 @ V3, v42 @ V4, v43 @ V5, v44 @ V6, v45 @ V7\n\tthrow System.NullReferenceException;\nL_0157:\n\tv240 = new System.TypeLoadException();\nL_0158:\n\tv313 = 0x6D2380(v209, v308, v283, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\treturn;\n// 197 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDisable()
	{
		//IL_0055: Expected I, but got O
		//IL_0323: Expected I4, but got O
		//IL_0097: Expected I, but got O
		//IL_00d2: Expected O, but got I
		//IL_0384: Expected I, but got O
		//IL_0394: Expected O, but got I
		//IL_03a4: Expected O, but got I
		//IL_03c5: Expected I, but got O
		//IL_029e: Expected I, but got O
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_017a: Expected O, but got I
		//IL_0189: Expected O, but got I
		//IL_01db: Expected O, but got I
		//IL_011e: Expected O, but got I
		//IL_020a: Expected I, but got O
		//IL_0242: Expected I, but got O
		if ((bool)m_ReflectionTexture)
		{
			UnityEngine.Object.DestroyImmediate(m_ReflectionTexture);
			m_ReflectionTexture = null;
		}
		Hashtable reflectionCameras = m_ReflectionCameras;
		IntPtr intPtr = (IntPtr)reflectionCameras;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X8_v9 (Il2CppClass<System.Collections.Hashtable>)+298]");
		IntPtr intPtr2 = (IntPtr)0;
		IEnumerator enumerator = reflectionCameras.GetEnumerator();
		if (enumerator == null)
		{
			goto IL_02e3;
		}
		object obj5 = default(object);
		int num4;
		while (enumerator.MoveNext())
		{
			IntPtr intPtr3 = (IntPtr)enumerator;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ X8_v22 (Il2CppClass<System.Collections.IEnumerator>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0137;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ X8_v22 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ X11_v19-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ X8_v22 (Il2CppClass<System.Collections.IEnumerator>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_0137;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr3 + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			num4 = 0;
			goto IL_0445;
			IL_02d5:
			InvalidCastException ex = new InvalidCastException();
			goto IL_02e3;
			IL_0137:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num4 = 1;
			goto IL_0445;
			IL_0445:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v536 @ X0_v35] (should have been resolved before IL gen)");
			DictionaryEntry dictionaryEntry = (DictionaryEntry)((obj5 is DictionaryEntry) ? obj5 : null);
			IntPtr intPtr4;
			if ((object)dictionaryEntry != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ X0_v47+8]");
				Component component = (Component)0;
				bool flag3 = (object)component.GetType() != typeof(Camera);
				intPtr2 = (IntPtr)typeof(Camera);
				if (flag3)
				{
					goto IL_02d5;
				}
				bool flag4 = (object)component.GetType() != typeof(Camera);
				intPtr4 = (IntPtr)typeof(Camera);
				if (!flag4)
				{
					GameObject obj6 = component.gameObject;
					UnityEngine.Object.DestroyImmediate(obj6);
					continue;
				}
			}
			else
			{
				InvalidCastException ex2 = new InvalidCastException();
				intPtr4 = (IntPtr)typeof(DictionaryEntry);
				NullReferenceException ex3 = new NullReferenceException();
			}
			InvalidCastException ex4 = new InvalidCastException();
			NullReferenceException ex5 = new NullReferenceException();
			intPtr2 = intPtr4;
			goto IL_02d5;
		}
		int num5 = 0;
		int num6 = 0;
		goto IL_0459;
		IL_03d2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
		return;
		IL_0459:
		(enumerator as IDisposable)?.Dispose();
		if (num5 + 1 != 0 || num6 == 0)
		{
			Hashtable reflectionCameras2 = m_ReflectionCameras;
			IntPtr intPtr5 = (IntPtr)reflectionCameras2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ X8_v12 (Il2CppClass<System.Collections.Hashtable>)+220]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ X8_v12 (Il2CppClass<System.Collections.Hashtable>)+228]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v376 @ X2_v7 (should have been resolved before IL gen)");
		}
		TypeLoadException ex6 = new TypeLoadException();
		num4 = 0;
		intPtr2 = (IntPtr)null;
		NullReferenceException ex7 = (NullReferenceException)(object)ex6;
		goto IL_03d2;
		IL_02e3:
		ex7 = new NullReferenceException();
		if (intPtr2 != (IntPtr)1)
		{
			goto IL_03d2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
		object obj9 = default(object);
		num6 = (int)obj9;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
		num5 = -1;
		goto IL_0459;
	}

	[Token(Token = "0x600008F")]
	[Address(RVA = "0xB09E10", Offset = "0xB09E10", Length = "0x2E0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EB3510]);\n\tv27 = *([v26 @ X8_v28]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, src, dest, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 0 | 1;\n\t*([20224ED]) = v45;\nL_001D:\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, src, dest, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tv62 = UnityEngine.Object::op_Equality(dest, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0037;\n\treturn;\nL_0037:\n\tv167 = UnityEngine.Camera::get_clearFlags(src);\n\tUnityEngine.Camera::set_clearFlags(dest, v167);\n\tv180 = UnityEngine.Camera::get_backgroundColor(src);\n\tUnityEngine.Camera::set_backgroundColor(dest, v180);\n\tv210 = UnityEngine.Camera::get_clearFlags(src);\n\tv83 = v210 != 1;\n\tif (v83) goto L_00DE;\n\tgoto L_0067;\n\tv244 = *([v223 @ X0_v30+E0]);\n\tv245 = v244 == 0;\n\tv246 = ~v245;\n\tif (v246) goto L_0067;\n\tv248 = \"il2cpp_codegen_runtime_class_init\"(v223, v209, v203, methodInfo, v30, v31, v32, v33, v180, v128, v125, v122, v38, v39, v40, v41);\nL_0067:\n\tv253 = System.Type::GetTypeFromHandle(UnityEngine.Skybox);\n\tv259 = UnityEngine.Component::GetComponent(src, v253);\n\tv263 = v259 == 0;\n\tif (v263) goto L_FFFFFFFF;\n\tv279 = *([v259 @ X0_v35 (UnityEngine.Component)]) != UnityEngine.Skybox;\n\tif (v279) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0085;\nL_0085:\n\tv300 = System.Type::GetTypeFromHandle(UnityEngine.Skybox);\n\tv305 = UnityEngine.Component::GetComponent(dest, v300);\n\tv309 = v305 == 0;\n\tif (v309) goto L_FFFFFFFF;\n\tv325 = *([v305 @ X0_v39 (UnityEngine.Component)]) != UnityEngine.Skybox;\n\tif (v325) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00A5;\nL_00A5:\n\tgoto L_00AD;\n\tv340 = *([v334 @ X0_v40+E0]);\n\tv341 = v340 == 0;\n\tv342 = ~v341;\n\tgoto L_00AD;\n\tv344 = \"il2cpp_codegen_runtime_class_init\"(v334, v303, v184, methodInfo, v30, v31, v32, v33, v180, v128, v125, v122, v38, v39, v40, v41);\nL_00AD:\n\tv190 = UnityEngine.Object::op_Implicit(v200);\n\tv350 = v190 == 0;\n\tif (v350) goto L_00DB;\n\tv355 = UnityEngine.Skybox::get_material(v200);\n\tgoto L_00C4;\n\tv359 = *([v198 @ X8_v16+E0]);\n\tv360 = v359 == 0;\n\tv361 = ~v360;\n\tif (v361) goto L_00C4;\n\tv366 = v198;\n\tv363 = \"il2cpp_codegen_runtime_class_init\"(v366, v354, v184, methodInfo, v30, v31, v32, v33, v180, v128, v125, v122, v38, v39, v40, v41);\nL_00C4:\n\tv191 = UnityEngine.Object::op_Implicit(v355);\n\tv352 = v191 == 0;\n\tif (v352) goto L_00DB;\n\tUnityEngine.Behaviour::set_enabled(v183, 1);\n\tv373 = UnityEngine.Skybox::get_material(v200);\n\tUnityEngine.Skybox::set_material(v183, v373);\n\tgoto L_00DE;\nL_00DB:\n\tUnityEngine.Behaviour::set_enabled(v183, 0);\nL_00DE:\n\tv243 = UnityEngine.Camera::get_farClipPlane(src);\n\tUnityEngine.Camera::set_farClipPlane(dest, v243);\n\tv262 = UnityEngine.Camera::get_nearClipPlane(src);\n\tUnityEngine.Camera::set_nearClipPlane(dest, v262);\n\tv283 = UnityEngine.Camera::get_orthographic(src);\n\tUnityEngine.Camera::set_orthographic(dest, v283);\n\tv308 = UnityEngine.Camera::get_fieldOfView(src);\n\tUnityEngine.Camera::set_fieldOfView(dest, v308);\n\tv329 = UnityEngine.Camera::get_aspect(src);\n\tUnityEngine.Camera::set_aspect(dest, v329);\n\tv131 = UnityEngine.Camera::get_orthographicSize(src);\n\tUnityEngine.Camera::set_orthographicSize(dest, v131);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 184 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void UpdateCameraModes(Camera src, Camera dest)
	{
		if (dest == null)
		{
			return;
		}
		CameraClearFlags clearFlags = src.clearFlags;
		dest.clearFlags = clearFlags;
		Color backgroundColor = src.backgroundColor;
		dest.backgroundColor = backgroundColor;
		CameraClearFlags clearFlags2 = src.clearFlags;
		if (clearFlags2 == CameraClearFlags.Skybox)
		{
			Type typeFromHandle = typeof(Skybox);
			Component component = src.GetComponent(typeFromHandle);
			UnityEngine.Object obj;
			if ((object)component != null)
			{
				Component component2 = (((object)component.GetType() != typeof(Skybox)) ? null : component);
				obj = component2;
			}
			else
			{
				obj = null;
			}
			Type typeFromHandle2 = typeof(Skybox);
			Component component3 = dest.GetComponent(typeFromHandle2);
			Behaviour behaviour;
			if ((object)component3 != null)
			{
				Component component4 = (((object)component3.GetType() != typeof(Skybox)) ? null : component3);
				behaviour = (Behaviour)component4;
			}
			else
			{
				behaviour = null;
			}
			if ((bool)obj)
			{
				Material material = ((Skybox)obj).material;
				if ((bool)material)
				{
					behaviour.enabled = true;
					Material material2 = ((Skybox)obj).material;
					((Skybox)behaviour).material = material2;
					goto IL_0228;
				}
			}
			behaviour.enabled = false;
		}
		goto IL_0228;
		IL_0228:
		float farClipPlane = src.farClipPlane;
		dest.farClipPlane = farClipPlane;
		float nearClipPlane = src.nearClipPlane;
		dest.nearClipPlane = nearClipPlane;
		bool orthographic = src.orthographic;
		dest.orthographic = orthographic;
		float fieldOfView = src.fieldOfView;
		dest.fieldOfView = fieldOfView;
		float aspect = src.aspect;
		dest.aspect = aspect;
		float orthographicSize = src.orthographicSize;
		dest.orthographicSize = orthographicSize;
	}

	[Token(Token = "0x6000090")]
	[Address(RVA = "0xB098BC", Offset = "0xB098BC", Length = "0x554")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1F00600]);\n\tv31 = *([v30 @ X8_v80]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, currentCamera, reflectionCamera, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20224EE]) = v48;\nL_0019:\n\t*([reflectionCamera @ X2 (UnityEngine.Camera&)]) = 0;\n\tgoto L_0029;\n\tv56 = *([v52 @ X0_v2+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tgoto L_0029;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v52, currentCamera, reflectionCamera, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0029:\n\tv65 = UnityEngine.Object::op_Implicit(this.m_ReflectionTexture);\n\tv67 = v65 == 0;\n\tif (v67) goto L_003E;\n\tv74 = this.m_OldReflectionTextureSize == this.m_TextureSize;\n\tif (v74) goto L_0089;\nL_003E:\n\tgoto L_0046;\n\tv135 = *([v98 @ X0_v84+E0]);\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_0046;\n\tv139 = \"il2cpp_codegen_runtime_class_init\"(v98, v64, reflectionCamera, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0046:\n\tv144 = UnityEngine.Object::op_Implicit(this.m_ReflectionTexture);\n\tv300 = v144 == 0;\n\tif (v300) goto L_005C;\n\tgoto L_0057;\n\tv433 = *([v406 @ X0_v100+E0]);\n\tv434 = v433 == 0;\n\tv435 = ~v434;\n\tif (v435) goto L_0057;\n\tv437 = \"il2cpp_codegen_runtime_class_init\"(v406, v143, reflectionCamera, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0057:\n\tUnityEngine.Object::DestroyImmediate(this.m_ReflectionTexture);\nL_005C:\n\tv423 = new UnityEngine.RenderTexture();\n\tUnityEngine.RenderTexture::.ctor(v423, this.m_TextureSize, this.m_TextureSize, 0x10);\n\tthis.m_ReflectionTexture = v423;\n\tv506 = UnityEngine.Object::GetInstanceID(this);\n\t// 109 Box v515 @ X0_v94 (System.Object), typeof(System.Int32), &v506 @ X0_v92 (System.Int32)\n\tv601 = System.String::Concat(\"__MirrorReflection\", v515);\n\tUnityEngine.Object::set_name(v423, v601);\n\tUnityEngine.RenderTexture::set_isPowerOfTwo(this.m_ReflectionTexture, 1);\n\tUnityEngine.Object::set_hideFlags(this.m_ReflectionTexture, 0x34);\n\tthis.m_OldReflectionTextureSize = this.m_TextureSize;\nL_0089:\n\tv133 = this.m_ReflectionCameras;\n\tv149 = System.Collections.Hashtable::get_Item(v133, currentCamera);\n\tv150 = v149 == 0;\n\tif (v150) goto L_FFFFFFFF;\n\tv314 = *([v149 @ X0_v10 (System.Object)]) != UnityEngine.Camera;\n\tif (v314) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00A8;\nL_00A8:\n\t*([reflectionCamera @ X2 (UnityEngine.Camera&)]) = v427;\n\tgoto L_00B5;\n\tv440 = *([v429 @ X0_v11+E0]);\n\tv441 = v440 == 0;\n\tv442 = ~v441;\n\tgoto L_00B5;\n\tv444 = \"il2cpp_codegen_runtime_class_init\"(v429, v146, v148, v110, v106, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00B5:\n\tv449 = UnityEngine.Object::op_Implicit(v427);\n\tv508 = v449 == 0;\n\tv509 = ~v508;\n\tif (v509) goto L_01D7;\n\t// 190 NewArr v267 @ X0_v17 (System.Object[]), typeof(System.Object[]), 4\n\tv605 = \"Mirror Refl Camera id\" == 0;\n\tif (v605) goto L_00CD;\n\t// 201 IsInst this @ X0 (TCP2_PlanarReflection), typeof(System.Object), \"Mirror Refl Camera id\"\nL_00CD:\n\tv389 = v267.Length == 0;\n\tif (v389) goto L_01DA;\n\tv267[0] = \"Mirror Refl Camera id\";\n\tv631 = UnityEngine.Object::GetInstanceID(this);\n\t// 218 Box this @ X0 (TCP2_PlanarReflection), typeof(System.Int32), &v631 @ X0_v23 (System.Int32)\n\tv658 = this == 0;\n\tif (v658) goto L_00E4;\n\t// 225 IsInst this @ X0 (TCP2_PlanarReflection), typeof(System.Object), this @ X0 (TCP2_PlanarReflection)\nL_00E4:\n\tv401 = v267.Length;\n\tv661 = v267.Length < 1;\n\tv370 = ~v661;\n\tv366 = v267.Length - 1;\n\tv358 = v366 == 0;\n\tv662 = ~v370;\n\tv325 = v662 | v358;\n\tif (v325) goto L_01DA;\n\tv267[1] = this;\n\tv665 = \" for \" == 0;\n\tif (v665) goto L_00FD;\n\t// 249 IsInst this @ X0 (TCP2_PlanarReflection), typeof(System.Object), \" for \"\n\tv401 = v267.Length;\nL_00FD:\n\tv667 = v401 < 2;\n\tv372 = ~v667;\n\tv368 = v401 - 2;\n\tv360 = v368 == 0;\n\tv668 = ~v372;\n\tv327 = v668 | v360;\n\tif (v327) goto L_01DA;\n\tv267[2] = \" for \";\n\tv671 = UnityEngine.Object::GetInstanceID(currentCamera);\n\t// 276 Box this @ X0 (TCP2_PlanarReflection), typeof(System.Int32), &v671 @ X0_v30 (System.Int32)\n\tv676 = this == 0;\n\tif (v676) goto L_011F;\n\t// 283 IsInst this @ X0 (TCP2_PlanarReflection), typeof(System.Object), this @ X0 (TCP2_PlanarReflection)\nL_011F:\n\tv679 = v267.Length < 3;\n\tv371 = ~v679;\n\tv367 = v267.Length - 3;\n\tv359 = v367 == 0;\n\tv680 = ~v371;\n\tv326 = v680 | v359;\n\tif (v326) goto L_01DA;\n\tv267[3] = this;\n\tv683 = System.String::Concat(v267);\n\t// 309 NewArr v689 @ X0_v37 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0149;\n\tv697 = *([v620 @ X8_v31+E0]);\n\tv698 = v697 == 0;\n\tv699 = ~v698;\n\tif (v699) goto L_0149;\n\tv704 = v620;\n\tv701 = \"il2cpp_codegen_runtime_class_init\"(v704, v686, v148, v110, v106, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0149:\n\tv612 = System.Type::GetTypeFromHandle(UnityEngine.Camera);\n\tv705 = v612 == 0;\n\tif (v705) goto L_0156;\n\t// 338 IsInst this @ X0 (TCP2_PlanarReflection), typeof(System.Type), v612 @ X0_v40 (System.Type)\nL_0156:\n\tv392 = v689.Length == 0;\n\tif (v392) goto L_01DA;\n\tv689[0] = v612;\n\tv713 = System.Type::GetTypeFromHandle(UnityEngine.Skybox);\n\tv714 = v713 == 0;\n\tif (v714) goto L_0168;\n\t// 356 IsInst this @ X0 (TCP2_PlanarReflection), typeof(System.Type), v713 @ X0_v43 (System.Type)\nL_0168:\n\tv717 = v689.Length < 1;\n\tv246 = ~v717;\n\tv242 = v689.Length - 1;\n\tv234 = v242 == 0;\n\tv718 = ~v246;\n\tv184 = v718 | v234;\n\tif (v184) goto L_01DA;\n\tv689[1] = v713;\n\tv613 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v613, v683, v689);\n\tv268 = UnityEngine.GameObject::GetComponent(v613);\n\t*([reflectionCamera @ X2 (UnityEngine.Camera&)]) = v268;\n\tUnityEngine.Behaviour::set_enabled(v268, 0);\n\tv724 = UnityEngine.Component::get_transform(*([reflectionCamera @ X2 (UnityEngine.Camera&)]));\n\tv270 = UnityEngine.Component::get_transform(this);\n\tv171 = UnityEngine.Transform::get_position(v270);\n\tUnityEngine.Transform::set_position(v724, v171);\n\tv728 = UnityEngine.Component::get_transform(*([reflectionCamera @ X2 (UnityEngine.Camera&)]));\n\tv272 = UnityEngine.Component::get_transform(this);\n\tv172 = UnityEngine.Transform::get_rotation(v272);\n\tUnityEngine.Transform::set_rotation(v728, v172);\n\tv274 = UnityEngine.Component::get_gameObject(*([reflectionCamera @ X2 (UnityEngine.Camera&)]));\n\tv733 = UnityEngine.GameObject::AddComponent(v274);\n\tUnityEngine.Object::set_hideFlags(v613, 0x3D);\n\tthis = System.Collections.Hashtable::set_Item(this.m_ReflectionCameras, currentCamera, *([reflectionCamera @ X2 (UnityEngine.Camera&)]));\nL_01D7:\n\treturn;\n\tv298 = new System.NullReferenceException();\nL_01DA:\n\tv405 = new System.IndexOutOfRangeException();\n\tgoto L_01DF;\n\tv494 = new System.ArrayTypeMismatchException();\nL_01DF:\n\tthrow v493;\n// 321 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe void CreateMirrorObjects(Camera currentCamera, out Camera reflectionCamera)
	{
		//IL_02ba: Expected O, but got I4
		//IL_02e6: Expected O, but got I4
		//IL_06fb: Expected O, but got I
		//IL_0365: Expected O, but got I4
		//IL_03f6: Expected O, but got I4
		//IL_053b: Expected O, but got I4
		reflectionCamera = null;
		ref Camera reference = ref *(Camera*)null;
		if (!m_ReflectionTexture || m_OldReflectionTextureSize != m_TextureSize)
		{
			if ((bool)m_ReflectionTexture)
			{
				UnityEngine.Object.DestroyImmediate(m_ReflectionTexture);
			}
			RenderTexture renderTexture = (m_ReflectionTexture = new RenderTexture(m_TextureSize, m_TextureSize, 16));
			int instanceID = GetInstanceID();
			object obj = instanceID;
			string text = "__MirrorReflection" + obj;
			renderTexture.name = text;
			m_ReflectionTexture.isPowerOfTwo = true;
			m_ReflectionTexture.hideFlags = HideFlags.DontSave;
			m_OldReflectionTextureSize = m_TextureSize;
		}
		Hashtable reflectionCameras = m_ReflectionCameras;
		object obj2 = reflectionCameras.get_Item((object)currentCamera);
		UnityEngine.Object obj4;
		if (obj2 != null)
		{
			object obj3 = (((object)obj2.GetType() != typeof(Camera)) ? null : obj2);
			obj4 = (UnityEngine.Object)obj3;
		}
		else
		{
			obj4 = null;
		}
		reference = ref *(Camera*)obj4;
		if ((bool)obj4)
		{
			return;
		}
		object[] array = new object[4];
		if ("Mirror Refl Camera id" != null)
		{
			TCP2_PlanarReflection tCP2_PlanarReflection = (TCP2_PlanarReflection)("Mirror Refl Camera id" as object);
		}
		if (array.Length != 0)
		{
			array[0] = "Mirror Refl Camera id";
			int instanceID2 = GetInstanceID();
			TCP2_PlanarReflection tCP2_PlanarReflection = (TCP2_PlanarReflection)(object)instanceID2;
			if ((object)this != null)
			{
				tCP2_PlanarReflection = (TCP2_PlanarReflection)(this as object);
			}
			object obj5 = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = !flag;
			object obj6 = array.Length - 1;
			bool flag3 = obj6 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = this;
				if (" for " != null)
				{
					tCP2_PlanarReflection = (TCP2_PlanarReflection)(" for " as object);
					obj5 = array.Length;
				}
				bool flag5 = (long)(IntPtr)obj5 < 2L;
				bool flag6 = !flag5;
				object obj7 = (long)(IntPtr)obj5 - 2L;
				bool flag7 = obj7 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					array[2] = " for ";
					int instanceID3 = currentCamera.GetInstanceID();
					tCP2_PlanarReflection = (TCP2_PlanarReflection)(object)instanceID3;
					if ((object)this != null)
					{
						tCP2_PlanarReflection = (TCP2_PlanarReflection)(this as object);
					}
					bool flag9 = array.Length < 3;
					bool flag10 = !flag9;
					object obj8 = array.Length - 3;
					bool flag11 = obj8 == null;
					bool flag12 = !flag10;
					if (!(flag12 || flag11))
					{
						array[3] = this;
						string text2 = string.Concat(array);
						Type[] array2 = new Type[2];
						Type typeFromHandle = typeof(Camera);
						if ((object)typeFromHandle != null)
						{
							tCP2_PlanarReflection = (TCP2_PlanarReflection)(object)(typeFromHandle as Type);
						}
						if (array2.Length != 0)
						{
							array2[0] = typeFromHandle;
							Type typeFromHandle2 = typeof(Skybox);
							if ((object)typeFromHandle2 != null)
							{
								tCP2_PlanarReflection = (TCP2_PlanarReflection)(object)(typeFromHandle2 as Type);
							}
							bool flag13 = array2.Length < 1;
							bool flag14 = !flag13;
							object obj9 = array2.Length - 1;
							bool flag15 = obj9 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array2[1] = typeFromHandle2;
								GameObject gameObject = new GameObject(text2, array2);
								Camera component = gameObject.GetComponent<Camera>();
								reference = ref *(Camera*)component;
								component.enabled = false;
								Transform transform = reflectionCamera.transform;
								Transform transform2 = base.transform;
								Vector3 position = transform2.position;
								transform.position = position;
								Transform transform3 = reflectionCamera.transform;
								Transform transform4 = base.transform;
								Quaternion rotation = transform4.rotation;
								transform3.rotation = rotation;
								GameObject gameObject2 = reflectionCamera.gameObject;
								FlareLayer flareLayer = gameObject2.AddComponent<FlareLayer>();
								gameObject.hideFlags = HideFlags.HideAndDontSave;
								m_ReflectionCameras.set_Item((object)currentCamera, (object)reflectionCamera);
								return;
							}
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000091")]
	[Address(RVA = "0xB0A8B8", Offset = "0xB0A8B8", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = a <= 0;\n\tif (v12) goto L_0011;\n\treturn 1f;\nL_0011:\n\tv16 = a >= 0;\n\tif (v16) goto L_FFFFFFFF;\n\tgoto L_0017;\nL_0017:\n\treturn returnVal2;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static float sgn(float a)
	{
		if (a > 0f)
		{
			return 1f;
		}
		if (a < 0f)
		{
			return -1f;
		}
		return 0f;
	}

	[Token(Token = "0x6000092")]
	[Address(RVA = "0xB0A394", Offset = "0xB0A394", Length = "0x1E8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = &v35 @ stack_-10_v2;\n\tgoto L_0037;\n\tv54 = *([1EB8440]);\n\tv55 = *([v54 @ X8_v11]);\n\tv56 = \"il2cpp_codegen_initialize_method\"(v55, cam, methodInfo, v58, v59, v60, v61, v62, pos, v0, v2, normal, v3, v5, sideSign, v63);\n\tv66 = 0 | 1;\n\t*([20224EF]) = v66;\nL_0037:\n\tgoto L_0043;\n\tv81 = *([v74 @ X0_v2+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tgoto L_0043;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v74, cam, methodInfo, v58, v59, v60, v61, v62, v69, v0, v2, normal, v3, v5, sideSign, v63);\nL_0043:\n\tv94 = UnityEngine.Vector3::op_Multiply(normal, this.m_ClipPlaneOffset);\n\treturnVal1 = UnityEngine.Vector3::op_Addition(pos, v94);\n\tv117 = UnityEngine.Camera::get_worldToCameraMatrix(cam);\n\tv120 = v117.m00;\n\tv149 = 0x10C2764(&v120 @ stack_-110_v1 (System.Single), 0, methodInfo, v58, v59, v60, v61, v62, returnVal1, returnVal1.y, returnVal1.z, v117.m00, v94.y, v94.z, sideSign, v63);\n\tv158 = 0x10C2868(&v120 @ stack_-110_v1 (System.Single), 0, methodInfo, v58, v59, v60, v61, v62, normal, normal.y, normal.z, v117.m00, v94.y, v94.z, sideSign, v63);\n\tv257 = 0x158A710(&normal @ V3 (UnityEngine.Vector3), 0, methodInfo, v58, v59, v60, v61, v62, normal, normal.y, normal.z, v117.m00, v94.y, v94.z, sideSign, v63);\n\tv260 = UnityEngine.Vector3::op_Multiply(normal, sideSign);\n\tv271 = UnityEngine.Vector3::Dot(returnVal1, v260);\n\tnormal = -v271;\n\tv273 = &v35 @ stack_-10_v2 - 0x70;\n\t*([v34 @ X29_v1-70]) = 0;\n\t*([v34 @ X29_v1-68]) = 0;\n\tv223 = 0x158BA74(v273, 0, methodInfo, v58, v59, v60, v61, v62, v260, v260.y, v260.z, normal, v260.y, v260.z, sideSign, v63);\n\treturn *([v34 @ X29_v1-70]);\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 157 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
	{
		//IL_00a8: Expected O, but got F4
		//IL_00b7: Expected O, but got I
		//IL_00da: Expected O, but got I
		object obj2 = default(object);
		object obj = obj2;
		Vector3 vector = normal * m_ClipPlaneOffset;
		Vector3 lhs = pos + vector;
		float m = cam.worldToCameraMatrix.m00;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2764 (inside UnityEngine.Matrix4x4::op_Multiply +0x110)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2868 (inside UnityEngine.Matrix4x4::op_Multiply +0x214)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158A710 (inside UnityEngine.Vector3::get_zero +0x15C)");
		Vector3 rhs = normal * sideSign;
		float num = Vector3.Dot(lhs, rhs);
		Vector3 vector2 = (Vector3)(0f - num);
		object obj3 = (long)(IntPtr)obj2 - 112L;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-70]");
		return (Vector4)0;
	}

	[Token(Token = "0x6000093")]
	[Address(RVA = "0xB0A0F0", Offset = "0xB0A0F0", Length = "0x2A4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv27 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 0, 0, v28, v29, v30, v31, v32, plane, plane.y, plane.z, plane.w, v33, v34, v35, v36);\n\tv41 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 0, 0, v28, v29, v30, v31, v32, plane, plane.y, plane.z, plane.w, v33, v34, v35, v36);\n\tv43 = plane * -2f;\n\tv44 = v43 * plane;\n\tv46 = v44 + 1f;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)]) = v46;\n\tv50 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 0, 0, v28, v29, v30, v31, v32, v46, v43, plane.z, plane.w, v33, v34, v35, v36);\n\tv55 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 1, 0, v28, v29, v30, v31, v32, v46, v43, plane.z, plane.w, v33, v34, v35, v36);\n\tv56 = v46 * -2f;\n\tv57 = v56 * v46;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+10]) = v57;\n\tv61 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 0, 0, v28, v29, v30, v31, v32, v57, v56, plane.z, plane.w, v33, v34, v35, v36);\n\tv66 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 2, 0, v28, v29, v30, v31, v32, v57, v56, plane.z, plane.w, v33, v34, v35, v36);\n\tv67 = v57 * -2f;\n\tv68 = v67 * v57;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+20]) = v68;\n\tv72 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 3, 0, v28, v29, v30, v31, v32, v68, v67, plane.z, plane.w, v33, v34, v35, v36);\n\tv77 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 0, 0, v28, v29, v30, v31, v32, v68, v67, plane.z, plane.w, v33, v34, v35, v36);\n\tv78 = v68 * -2f;\n\tv79 = v78 * v68;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+30]) = v79;\n\tv83 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 1, 0, v28, v29, v30, v31, v32, v79, v78, plane.z, plane.w, v33, v34, v35, v36);\n\tv88 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 0, 0, v28, v29, v30, v31, v32, v79, v78, plane.z, plane.w, v33, v34, v35, v36);\n\tv89 = v79 * -2f;\n\tv90 = v89 * v79;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+4]) = v90;\n\tv94 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 1, 0, v28, v29, v30, v31, v32, v90, v89, plane.z, plane.w, v33, v34, v35, v36);\n\tv99 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 1, 0, v28, v29, v30, v31, v32, v90, v89, plane.z, plane.w, v33, v34, v35, v36);\n\tv100 = v90 + v90;\n\tv101 = v100 * v90;\n\tv102 = 1f - v101;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+14]) = v102;\n\tv106 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 1, 0, v28, v29, v30, v31, v32, v102, v100, plane.z, plane.w, v33, v34, v35, v36);\n\tv111 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 2, 0, v28, v29, v30, v31, v32, v102, v100, plane.z, plane.w, v33, v34, v35, v36);\n\tv112 = v102 * -2f;\n\tv113 = v112 * v102;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+24]) = v113;\n\tv117 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 3, 0, v28, v29, v30, v31, v32, v113, v112, plane.z, plane.w, v33, v34, v35, v36);\n\tv122 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 1, 0, v28, v29, v30, v31, v32, v113, v112, plane.z, plane.w, v33, v34, v35, v36);\n\tv123 = v113 * -2f;\n\tv124 = v123 * v113;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+34]) = v124;\n\tv128 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 2, 0, v28, v29, v30, v31, v32, v124, v123, plane.z, plane.w, v33, v34, v35, v36);\n\tv133 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 0, 0, v28, v29, v30, v31, v32, v124, v123, plane.z, plane.w, v33, v34, v35, v36);\n\tv134 = v124 * -2f;\n\tv135 = v134 * v124;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+8]) = v135;\n\tv139 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 2, 0, v28, v29, v30, v31, v32, v135, v134, plane.z, plane.w, v33, v34, v35, v36);\n\tv144 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 1, 0, v28, v29, v30, v31, v32, v135, v134, plane.z, plane.w, v33, v34, v35, v36);\n\tv145 = v135 * -2f;\n\tv146 = v145 * v135;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+18]) = v146;\n\tv150 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 2, 0, v28, v29, v30, v31, v32, v146, v145, plane.z, plane.w, v33, v34, v35, v36);\n\tv155 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 2, 0, v28, v29, v30, v31, v32, v146, v145, plane.z, plane.w, v33, v34, v35, v36);\n\tv156 = v146 + v146;\n\tv157 = v156 * v146;\n\tv158 = 1f - v157;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+28]) = v158;\n\tv162 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 3, 0, v28, v29, v30, v31, v32, v158, v156, plane.z, plane.w, v33, v34, v35, v36);\n\tv167 = 0x158BA80(&plane @ V0 (UnityEngine.Vector4), 2, 0, v28, v29, v30, v31, v32, v158, v156, plane.z, plane.w, v33, v34, v35, v36);\n\tv168 = v158 * -2f;\n\tv170 = v168 * v158;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+C]) = 0;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+1C]) = 0;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+2C]) = 0;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+38]) = v170;\n\t*([reflectionMat @ X0 (UnityEngine.Matrix4x4&)+3C]) = 0x3F800000;\n\treturn;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
	{
		//IL_005a: Expected Ref, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		Vector4 vector = default(Vector4);
		float num = vector.x * -2f;
		float num2 = num * vector.x;
		float num3 = num2 + 1f;
		ref Matrix4x4 reference = ref *(Matrix4x4*)num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		float num4 = num3 * -2f;
		float num5 = num4 * num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		float num6 = num5 * -2f;
		float num7 = num6 * num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		float num8 = num7 * -2f;
		float num9 = num8 * num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		float num10 = num9 * -2f;
		float num11 = num10 * num9;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		float num12 = num11 + num11;
		float num13 = num12 * num11;
		float num14 = 1f - num13;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		float num15 = num14 * -2f;
		float num16 = num15 * num14;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		float num17 = num16 * -2f;
		float num18 = num17 * num16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		float num19 = num18 * -2f;
		float num20 = num19 * num18;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		float num21 = num20 * -2f;
		float num22 = num21 * num20;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		float num23 = num22 + num22;
		float num24 = num23 * num22;
		float num25 = 1f - num24;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
		float num26 = num25 * -2f;
		float num27 = num26 * num25;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1065353216;
	}

	[Token(Token = "0x6000094")]
	[Address(RVA = "0xB0A8D8", Offset = "0xB0A8D8", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F0FEC8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224F0]) = v38;\nL_0018:\n\tthis.m_TextureSize = 0x3D8F5C2900000400;\n\tv44 = UnityEngine.LayerMask::op_Implicit(0xFFFFFFFF);\n\tthis.m_ReflectLayers = v44;\n\tv48 = new System.Collections.Hashtable();\n\tSystem.Collections.Hashtable::.ctor(v48);\n\tthis.m_ReflectionCameras = v48;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public TCP2_PlanarReflection()
	{
		//IL_0025: Expected I4, but got I8
		base._002Ector();
		m_TextureSize = 1024;
		LayerMask reflectLayers = -1;
		m_ReflectLayers = reflectLayers;
		Hashtable reflectionCameras = new Hashtable();
		m_ReflectionCameras = reflectionCameras;
	}
}
