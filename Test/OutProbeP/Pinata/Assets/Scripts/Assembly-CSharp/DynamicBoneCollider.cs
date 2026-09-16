using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x74C6DC", Offset = "0x74C6DC")]
[Token(Token = "0x2000004")]
public class DynamicBoneCollider : DynamicBoneColliderBase
{
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763CA8", Offset = "0x763CA8")]
	[Token(Token = "0x4000025")]
	[FieldOffset(Offset = "0x2C")]
	public float m_Radius;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763CE0", Offset = "0x763CE0")]
	[Token(Token = "0x4000026")]
	[FieldOffset(Offset = "0x30")]
	public float m_Height;

	[Token(Token = "0x600001C")]
	[Address(RVA = "0xA01CFC", Offset = "0xA01CFC", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1F0E408]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021C65]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Mathf::Max(this.m_Radius, 0f);\n\tthis.m_Radius = v58;\n\tv63 = UnityEngine.Mathf::Max(this.m_Height, 0f);\n\tthis.m_Height = v63;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnValidate()
	{
		float radius = Mathf.Max(m_Radius, 0f);
		m_Radius = radius;
		float height = Mathf.Max(m_Height, 0f);
		m_Height = height;
	}

	[Token(Token = "0x600001D")]
	[Address(RVA = "0xA01D94", Offset = "0xA01D94", Length = "0x214")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1EF80B8]);\n\tv35 = *([v34 @ X8_v18]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, particlePosition, methodInfo, v38, v39, v40, v41, v42, particleRadius, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021C66]) = v52;\nL_0020:\n\tv58 = UnityEngine.Component::get_transform(this);\n\tv61 = UnityEngine.Transform::get_lossyScale(v58);\n\tgoto L_0037;\n\tv159 = *([v155 @ X0_v6+E0]);\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_0037;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v155, v60, methodInfo, v38, v39, v40, v41, v42, v61, v150, v151, v45, v46, v47, v48, v49);\nL_0037:\n\tv121 = UnityEngine.Mathf::Abs(v61);\n\tv119 = this.m_Radius * v121;\n\tv259 = this.m_Height * 0.5f;\n\tv128 = v259 - this.m_Radius;\n\tv260 = v128 < 0;\n\tv114 = ~v260;\n\tv102 = v128 == 0;\n\tv261 = ~v114;\n\tv83 = v261 | v102;\n\tif (v83) goto L_006B;\n\tv79 = this.m_Center;\n\tv76 = this.m_Center.y;\n\tv300 = this.m_Center.z;\n\tv273 = this.m_Direction == 2;\n\tif (v273) goto L_0086;\n\tv283 = this.m_Direction == 1;\n\tif (v283) goto L_0089;\n\tv291 = this.m_Direction == 0;\n\tv292 = ~v291;\n\tif (v292) goto L_0091;\n\tv303 = this.m_Center - v128;\n\tgoto L_008C;\nL_006B:\n\tv136 = UnityEngine.Component::get_transform(this);\n\t// 114 MakeStruct v321 @ AGGA01EA0_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_Center (UnityEngine.Vector3), this.m_Center.y (System.Single), this.m_Center.z (System.Single)\n\tv322 = UnityEngine.Transform::TransformPoint(v136, v321);\n\tv335 = this.m_Bound == 0;\n\tif (v335) goto L_0084;\n\tv362 = DynamicBoneCollider::InsideSphere(particlePosition, particleRadius, v322, v119);\n\tgoto L_00CA;\nL_0084:\n\tv362 = DynamicBoneCollider::OutsideSphere(particlePosition, particleRadius, v322, v119);\n\tgoto L_00CA;\nL_0086:\n\tv300 = v300 - v128;\n\tgoto L_008C;\nL_0089:\n\tv76 = v76 - v128;\nL_008C:\n\tv316 = v128 + *([v313 @ X8_v10]);\n\t*([v313 @ X8_v10]) = v316;\nL_0091:\n\tv137 = UnityEngine.Component::get_transform(this);\n\t// 152 MakeStruct v64 @ AGGA01F1C_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v79 @ V10_v7 (UnityEngine.Vector3), v76 @ V11_v6 (System.Single), v300 @ V12_v5 (System.Single)\n\tv130 = UnityEngine.Transform::TransformPoint(v137, v64);\n\tv138 = UnityEngine.Component::get_transform(this);\n\t// 168 MakeStruct v351 @ AGGA01F48_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v297 @ stack_-54_v4 (UnityEngine.Vector3), v299 @ stack_-58_v5 (System.Single), v290 @ stack_-5C_v7 (System.Single)\n\tv370 = UnityEngine.Transform::TransformPoint(v138, v351);\n\tv365 = this.m_Bound == 0;\n\tif (v365) goto L_00BD;\n\tv362 = DynamicBoneCollider::InsideCapsule(particlePosition, particleRadius, v130, v370, v119);\n\tgoto L_00CA;\nL_00BD:\n\tv362 = DynamicBoneCollider::OutsideCapsule(particlePosition, particleRadius, v130, v370, v119);\nL_00CA:\n\treturn v362;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override bool Collide(ref Vector3 particlePosition, float particleRadius)
	{
		//IL_027c: Expected O, but got F4
		//IL_03d5: Expected O, but got F4
		//IL_02aa: Expected O, but got F4
		//IL_0188: Expected O, but got F4
		Transform transform = base.transform;
		float num = Mathf.Abs(transform.lossyScale.x);
		float num2 = m_Radius * num;
		float num3 = m_Height * 0.5f;
		float num4 = num3 - m_Radius;
		bool flag = num4 < 0f;
		bool flag2 = !flag;
		bool flag3 = num4 == 0f;
		bool flag4 = !flag2;
		Vector3 vector;
		float num5;
		float num6;
		float num7 = default(float);
		Vector3 center;
		float num8 = default(float);
		if (!(flag4 || flag3))
		{
			vector = m_Center;
			num5 = m_Center.y;
			num6 = m_Center.z;
			object obj;
			if (m_Direction != Direction.Z)
			{
				if (m_Direction != Direction.Y)
				{
					bool flag5 = m_Direction == Direction.X;
					bool flag6 = !flag5;
					num7 = num6;
					center = m_Center;
					num8 = num5;
					if (flag6)
					{
						goto IL_03af;
					}
					float num9 = m_Center.x - num4;
					num7 = num6;
					num8 = num5;
					vector = (Vector3)num9;
					obj = center;
				}
				else
				{
					num5 -= num4;
					num7 = num6;
					center = m_Center;
					obj = num8;
				}
			}
			else
			{
				num6 -= num4;
				center = m_Center;
				num8 = m_Center.y;
				obj = num7;
			}
			float num10 = num4 + (float)obj;
			obj = num10;
			goto IL_03af;
		}
		Transform transform2 = base.transform;
		Vector3 position = default(Vector3);
		position.x = m_Center.x;
		position.y = m_Center.y;
		position.z = m_Center.z;
		Vector3 sphereCenter = transform2.TransformPoint(position);
		if (m_Bound != Bound.Outside)
		{
			return InsideSphere(ref particlePosition, particleRadius, sphereCenter, num2);
		}
		return OutsideSphere(ref particlePosition, particleRadius, sphereCenter, num2);
		IL_03af:
		Transform transform3 = base.transform;
		Vector3 position2 = default(Vector3);
		position2.x = vector.x;
		position2.y = num5;
		position2.z = num6;
		Vector3 capsuleP = transform3.TransformPoint(position2);
		Transform transform4 = base.transform;
		Vector3 position3 = default(Vector3);
		position3.x = center.x;
		position3.y = num8;
		position3.z = num7;
		Vector3 capsuleP2 = transform4.TransformPoint(position3);
		if (m_Bound != Bound.Outside)
		{
			return InsideCapsule(ref particlePosition, particleRadius, capsuleP, capsuleP2, num2);
		}
		return OutsideCapsule(ref particlePosition, particleRadius, capsuleP, capsuleP2, num2);
	}

	[Token(Token = "0x600001E")]
	[Address(RVA = "0xA01FA8", Offset = "0xA01FA8", Length = "0x19C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv44 = *([1F07B70]);\n\tv45 = *([v44 @ X8_v16]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, methodInfo, v48, v49, v50, v51, v52, v53, particleRadius, sphereCenter, v0, v2, sphereRadius, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2021C67]) = v59;\nL_002D:\n\tgoto L_003A;\n\tv71 = *([v67 @ X0_v2+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tgoto L_003A;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v48, v49, v50, v51, v52, v53, particleRadius, sphereCenter, v0, v2, sphereRadius, v54, v55, v56);\nL_003A:\n\t// 58 MakeStruct v85 @ AGGA02050_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [particlePosition @ X0 (UnityEngine.Vector3&)], [particlePosition @ X0 (UnityEngine.Vector3&)+4], [particlePosition @ X0 (UnityEngine.Vector3&)+8]\n\tv87 = UnityEngine.Vector3::op_Subtraction(v85, sphereCenter);\n\tv95 = 0x158AB88(&v87 @ V0_v2 (UnityEngine.Vector3), 0, v48, v49, v50, v51, v52, v53, v87, v87.y, v87.z, sphereCenter, sphereCenter.y, sphereCenter.z, v55, v56);\n\tv109 = v87 <= 0;\n\tif (v109) goto L_00AF;\n\tv110 = particleRadius + sphereRadius;\n\tv111 = v110 * v110;\n\tv121 = v87 >= v111;\n\tif (v121) goto L_00AF;\n\tgoto L_006D;\n\tv194 = *([v190 @ X0_v9 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\tif (v196) goto L_006D;\n\tv198 = \"il2cpp_codegen_runtime_class_init\"(v190, v92, v48, v49, v50, v51, v52, v53, v111, v88, v89, v81, v82, v83, v55, v56);\nL_006D:\n\tv169 = UnityEngine.Mathf::Sqrt(v87);\n\tv149 = v169 - v169;\n\tv143 = v169 ^ v169;\n\tv141 = v169 ^ v149;\n\tv139 = v143 & v141;\n\tv137 = v139 < 0;\n\tv135 = ~v137;\n\tif (v135) goto L_0083;\n\tv204 = 0x6D2F50(UnityEngine.Mathf, 0, v48, v49, v50, v51, v52, v53, v87, v87.y, v87.z, sphereCenter, sphereCenter.y, sphereCenter.z, v55, v56);\nL_0083:\n\tgoto L_0089;\n\tv212 = *([v208 @ X0_v12+E0]);\n\tv213 = v212 == 0;\n\tv214 = ~v213;\n\tgoto L_0089;\n\tv216 = \"il2cpp_codegen_runtime_class_init\"(v208, v92, v48, v49, v50, v51, v52, v53, v205, v88, v89, v81, v82, v83, v55, v56);\nL_0089:\n\tv217 = v110 / v169;\n\tv87 = UnityEngine.Vector3::op_Multiply(v87, v217);\n\tv87 = UnityEngine.Vector3::op_Addition(sphereCenter, v87);\n\t*([particlePosition @ X0 (UnityEngine.Vector3&)]) = v87;\n\t*([particlePosition @ X0 (UnityEngine.Vector3&)+4]) = v87.y;\n\t*([particlePosition @ X0 (UnityEngine.Vector3&)+8]) = v87.z;\nL_00AF:\n\treturn returnVal1;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe static bool OutsideSphere(ref Vector3 particlePosition, float particleRadius, Vector3 sphereCenter, float sphereRadius)
	{
		//IL_0017: Expected F4, but got O
		//IL_002c: Expected F4, but got I
		//IL_0041: Expected F4, but got I
		//IL_0116: Expected O, but got F4
		//IL_0123: Expected O, but got F4
		Vector3 vector = default(Vector3);
		vector.x = (float)particlePosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+4]");
		vector.y = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+8]");
		vector.z = 0f;
		Vector3 vector2 = vector - sphereCenter;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
		bool flag = !(vector2.x > 0f);
		bool result = false;
		if (!flag)
		{
			float num = particleRadius + sphereRadius;
			float num2 = num * num;
			bool flag2 = !(vector2.x < num2);
			result = false;
			if (!flag2)
			{
				float num3 = Mathf.Sqrt(vector2.x);
				float num4 = num3 - num3;
				object obj = num3 ^ num3;
				object obj2 = num3 ^ num4;
				int num5 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
				if (num5 < 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
					num3 = vector2.x;
				}
				float num6 = num / num3;
				vector2 *= num6;
				vector2 = sphereCenter + vector2;
				ref Vector3 reference = ref *(Vector3*)vector2;
				_ = vector2.y;
				_ = vector2.z;
				result = true;
			}
		}
		return result;
	}

	[Token(Token = "0x600001F")]
	[Address(RVA = "0xA02144", Offset = "0xA02144", Length = "0x1B0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv44 = *([1EC3B48]);\n\tv45 = v34;\n\tv46 = *([v44 @ X8_v16]);\n\tv47 = \"il2cpp_codegen_initialize_method\"(v46, methodInfo, v49, v50, v51, v52, v53, v54, particleRadius, sphereCenter, v0, v2, v34, v55, v56, v57);\n\tv61 = v45;\n\tv63 = 0 | 1;\n\t*([2021C68]) = v63;\nL_002C:\n\tv72 = sphereRadius - particleRadius;\n\tv73 = v72 * v72;\n\tgoto L_0041;\n\tv77 = *([v71 @ X0_v2+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tgoto L_0041;\n\tv86 = v60;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v71, methodInfo, v49, v50, v51, v52, v53, v54, particleRadius, sphereCenter, v0, v2, v60, v55, v56, v57);\n\tv84 = v86;\nL_0041:\n\t// 65 MakeStruct v96 @ AGGA02208_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [particlePosition @ X0 (UnityEngine.Vector3&)], [particlePosition @ X0 (UnityEngine.Vector3&)+4], [particlePosition @ X0 (UnityEngine.Vector3&)+8]\n\t// 66 MakeStruct v97 @ AGGA02208_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), sphereCenter @ V1 (UnityEngine.Vector3), sphereCenter.y (System.Single), sphereCenter.z (System.Single)\n\tv98 = UnityEngine.Vector3::op_Subtraction(v96, v97);\n\tv106 = 0x158AB88(&v98 @ V0_v2 (UnityEngine.Vector3), 0, v49, v50, v51, v52, v53, v54, v98, v98.y, v98.z, sphereCenter, sphereCenter.y, sphereCenter.z, v56, v57);\n\tv119 = v98 <= v73;\n\tif (v119) goto L_FFFFFFFF;\n\tgoto L_0067;\n\tv128 = *([v123 @ X0_v9 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0067;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v123, v103, v49, v50, v51, v52, v53, v54, v98, v99, v100, v92, v83, v93, v56, v57);\nL_0067:\n\tv178 = UnityEngine.Mathf::Sqrt(v98);\n\tv168 = v178 - v178;\n\tv162 = v178 ^ v178;\n\tv160 = v178 ^ v168;\n\tv158 = v162 & v160;\n\tv156 = v158 < 0;\n\tv154 = ~v156;\n\tif (v154) goto L_007D;\n\tv204 = 0x6D2F50(UnityEngine.Mathf, 0, v49, v50, v51, v52, v53, v54, v98, v98.y, v98.z, sphereCenter, sphereCenter.y, sphereCenter.z, v56, v57);\nL_007D:\n\tgoto L_0083;\n\tv212 = *([v208 @ X0_v12+E0]);\n\tv213 = v212 == 0;\n\tv214 = ~v213;\n\tgoto L_0083;\n\tv216 = \"il2cpp_codegen_runtime_class_init\"(v208, v103, v49, v50, v51, v52, v53, v54, v205, v99, v100, v92, v83, v93, v56, v57);\nL_0083:\n\tv217 = v72 / v178;\n\tv222 = UnityEngine.Vector3::op_Multiply(v98, v217);\n\t// 147 MakeStruct v145 @ AGGA022BC_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), sphereCenter @ V1 (UnityEngine.Vector3), sphereCenter.y (System.Single), sphereCenter.z (System.Single)\n\tv152 = UnityEngine.Vector3::op_Addition(v145, v222);\n\t*([particlePosition @ X0 (UnityEngine.Vector3&)]) = v152;\n\t*([particlePosition @ X0 (UnityEngine.Vector3&)+4]) = v152.y;\n\t*([particlePosition @ X0 (UnityEngine.Vector3&)+8]) = v152.z;\n\tgoto L_00AB;\nL_00AB:\n\treturn returnVal1;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe static bool InsideSphere(ref Vector3 particlePosition, float particleRadius, Vector3 sphereCenter, float sphereRadius)
	{
		//IL_0176: Expected F4, but got O
		//IL_018b: Expected F4, but got I
		//IL_01a0: Expected F4, but got I
		//IL_0038: Expected O, but got F4
		//IL_0045: Expected O, but got F4
		float num = sphereRadius - particleRadius;
		float num2 = num * num;
		Vector3 vector = default(Vector3);
		vector.x = (float)particlePosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+4]");
		vector.y = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+8]");
		vector.z = 0f;
		Vector3 vector2 = default(Vector3);
		Vector3 vector3 = default(Vector3);
		vector2.x = vector3.x;
		vector2.y = sphereCenter.y;
		vector2.z = sphereCenter.z;
		Vector3 vector4 = vector - vector2;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
		if (vector4.x > num2)
		{
			float num3 = Mathf.Sqrt(vector4.x);
			float num4 = num3 - num3;
			object obj = num3 ^ num3;
			object obj2 = num3 ^ num4;
			int num5 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			if (num5 < 0)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
				num3 = vector4.x;
			}
			float num6 = num / num3;
			Vector3 vector5 = vector4 * num6;
			Vector3 vector6 = default(Vector3);
			vector6.x = vector3.x;
			vector6.y = sphereCenter.y;
			vector6.z = sphereCenter.z;
			Vector3 vector7 = vector6 + vector5;
			ref Vector3 reference = ref *(Vector3*)vector7;
			_ = vector7.y;
			_ = vector7.z;
			return true;
		}
		return false;
	}

	[Token(Token = "0x6000020")]
	[Address(RVA = "0xA022F4", Offset = "0xA022F4", Length = "0x454")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv50 = *([1F09BD8]);\n\tv51 = *([v50 @ X8_v40]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, methodInfo, v54, v55, v56, v57, v58, v59, particleRadius, capsuleP0, v0, v2, capsuleP1, v3, v5, capsuleRadius);\n\tv62 = 0 | 1;\n\t*([2021C69]) = v62;\nL_002E:\n\tv70 = particleRadius + capsuleRadius;\n\tgoto L_0039;\n\tv74 = *([v69 @ X0_v2+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_0039;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v69, methodInfo, v54, v55, v56, v57, v58, v59, particleRadius, capsuleP0, v0, v2, capsuleP1, v3, v5, capsuleRadius);\nL_0039:\n\tparticleRadius = v70 * v70;\n\tv93 = UnityEngine.Vector3::op_Subtraction(capsuleP1, capsuleP0);\n\tparticleRadius = particlePosition->klass;\n\t// 84 MakeStruct v109 @ AGGA023E4_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [particlePosition @ X0 (UnityEngine.Vector3&)], [particlePosition @ X0 (UnityEngine.Vector3&)+4], [particlePosition @ X0 (UnityEngine.Vector3&)+8]\n\tv111 = UnityEngine.Vector3::op_Subtraction(v109, capsuleP0);\n\tparticleRadius = UnityEngine.Vector3::Dot(v111, v93);\n\tv125 = particleRadius < 0;\n\tv126 = ~v125;\n\tv129 = particleRadius == 0;\n\tv134 = ~v126;\n\tv135 = v134 | v129;\n\tif (v135) goto L_0110;\n\tv139 = 0x158AB88(&v137 @ stack_-70_v6, 0, v54, v55, v56, v57, v58, v59, particleRadius, v111.y, v111.z, v93, v93.y, v93.z, capsuleP1.z, capsuleRadius);\n\tv153 = particleRadius >= particleRadius;\n\tif (v153) goto L_016C;\n\tv179 = particleRadius <= 0;\n\tif (v179) goto L_FFFFFFFF;\n\tv341 = particleRadius / particleRadius;\n\tgoto L_00A1;\n\tv400 = *([v380 @ X0_v43+E0]);\n\tv401 = v400 == 0;\n\tv402 = ~v401;\n\tif (v402) goto L_00A1;\n\tv404 = \"il2cpp_codegen_runtime_class_init\"(v380, v138, v54, v55, v56, v57, v58, v59, v123, v112, v113, v114, v115, v116, v5, capsuleRadius);\nL_00A1:\n\t// 161 MakeStruct v231 @ AGGA0246C_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v137 @ stack_-70_v6, v93.y (System.Single), v93.z (System.Single)\n\tv410 = UnityEngine.Vector3::op_Multiply(v231, v341);\n\tv317 = UnityEngine.Vector3::op_Subtraction(v111, v410);\n\tv441 = 0x158AB88(&v317 @ V0_v29 (UnityEngine.Vector3), 0, v54, v55, v56, v57, v58, v59, v317, v317.y, v317.z, v410, v410.y, v410.z, capsuleP1.z, capsuleRadius);\n\tv238 = v317 <= 0;\n\tif (v238) goto L_01F0;\n\tv239 = v317 >= particleRadius;\n\tif (v239) goto L_01F0;\n\tgoto L_00DE;\n\tv576 = *([v499 @ X0_v50 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv577 = v576 == 0;\n\tv578 = ~v577;\n\tif (v578) goto L_00DE;\n\tv580 = \"il2cpp_codegen_runtime_class_init\"(v499, v234, v54, v55, v56, v57, v58, v59, v318, v313, v365, v361, v309, v357, v5, capsuleRadius);\nL_00DE:\n\tv562 = UnityEngine.Mathf::Sqrt(v317);\n\tv535 = v562 - v562;\n\tv529 = v562 ^ v562;\n\tv527 = v562 ^ v535;\n\tv525 = v529 & v527;\n\tv523 = v525 < 0;\n\tv521 = ~v523;\n\tif (v521) goto L_00F0;\n\tv624 = 0x6D2F50(UnityEngine.Mathf, 0, v54, v55, v56, v57, v58, v59, v317, v317.y, v317.z, v410, v410.y, v410.z, capsuleP1.z, capsuleRadius);\nL_00F0:\n\tv559 = particlePosition->monitor;\n\tgoto L_0101;\n\tv634 = *([v628 @ X0_v53+E0]);\n\tv635 = v634 == 0;\n\tv636 = ~v635;\n\tgoto L_0101;\n\tv638 = \"il2cpp_codegen_runtime_class_init\"(v628, v234, v54, v55, v56, v57, v58, v59, v625, v313, v365, v361, v309, v357, v5, capsuleRadius);\nL_0101:\n\tparticleRadius = v70 - v562;\n\tv643 = particleRadius / v562;\n\tv645 = UnityEngine.Vector3::op_Multiply(v317, v643);\n\tgoto L_FFFFFFFF;\nL_0110:\n\tv143 = 0x158AB88(&v141 @ stack_-80_v6, 0, v54, v55, v56, v57, v58, v59, particleRadius, v111.y, v111.z, v93, v93.y, v93.z, capsuleP1.z, capsuleRadius);\n\tv167 = particleRadius <= 0;\n\tif (v167) goto L_01F0;\n\tv197 = particleRadius >= particleRadius;\n\tif (v197) goto L_01F0;\n\tgoto L_0138;\n\tv413 = *([v396 @ X0_v15 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv414 = v413 == 0;\n\tv415 = ~v414;\n\tif (v415) goto L_0138;\n\tv417 = \"il2cpp_codegen_runtime_class_init\"(v396, v142, v54, v55, v56, v57, v58, v59, v187, v112, v113, v114, v115, v116, v5, capsuleRadius);\nL_0138:\n\tv447 = UnityEngine.Mathf::Sqrt(particleRadius);\n\tv432 = v447 - v447;\n\tv435 = v447 ^ v447;\n\tv436 = v447 ^ v432;\n\tv437 = v435 & v436;\n\tv438 = v437 < 0;\n\tv439 = ~v438;\n\tif (v439) goto L_014E;\n\tv444 = 0x6D2F50(UnityEngine.Mathf, 0, v54, v55, v56, v57, v58, v59, particleRadius, v111.y, v111.z, v93, v93.y, v93.z, capsuleP1.z, capsuleRadius);\nL_014E:\n\tgoto L_0158;\n\tv465 = *([v449 @ X0_v18+E0]);\n\tv466 = v465 == 0;\n\tv467 = ~v466;\n\tgoto L_0158;\n\tv469 = \"il2cpp_codegen_runtime_class_init\"(v449, v142, v54, v55, v56, v57, v58, v59, v445, v112, v113, v114, v115, v116, v5, capsuleRadius);\nL_0158:\n\tv476 = v70 / v447;\n\t// 346 MakeStruct v478 @ AGGA025F0_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v141 @ stack_-80_v6, v111.y (System.Single), v111.z (System.Single)\n\tv479 = UnityEngine.Vector3::op_Multiply(v478, v476);\n\tgoto L_01D8;\nL_016C:\n\tgoto L_0179;\n\tv385 = *([v180 @ X0_v26+E0]);\n\tv386 = v385 == 0;\n\tv387 = ~v386;\n\tif (v387) goto L_0179;\n\tv389 = \"il2cpp_codegen_runtime_class_init\"(v180, v138, v54, v55, v56, v57, v58, v59, v123, v112, v113, v114, v115, v116, v5, capsuleRadius);\nL_0179:\n\t// 377 MakeStruct v213 @ AGGA0264C_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [particlePosition @ X0 (UnityEngine.Vector3&)], [particlePosition @ X0 (UnityEngine.Vector3&)+4], [particlePosition @ X0 (UnityEngine.Vector3&)+8]\n\tv319 = UnityEngine.Vector3::op_Subtraction(v213, capsuleP1);\n\tv412 = 0x158AB88(&v319 @ V0_v19 (UnityEngine.Vector3), 0, v54, v55, v56, v57, v58, v59, v319, v319.y, v319.z, capsuleP1, capsuleP1.y, capsuleP1.z, capsuleP1.z, capsuleRadius);\n\tv240 = v319 <= 0;\n\tif (v240) goto L_01F0;\n\tv241 = v319 >= particleRadius;\n\tif (v241) goto L_01F0;\n\tgoto L_01AC;\n\tv481 = *([v461 @ X0_v32 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv482 = v481 == 0;\n\tv483 = ~v482;\n\tif (v483) goto L_01AC;\n\tv485 = \"il2cpp_codegen_runtime_class_init\"(v461, v235, v54, v55, v56, v57, v58, v59, v320, v314, v366, v362, v310, v358, v5, capsuleRadius);\nL_01AC:\n\tv588 = UnityEngine.Mathf::Sqrt(v319);\n\tv505 = v588 - v588;\n\tv508 = v588 ^ v588;\n\tv509 = v588 ^ v505;\n\tv510 = v508 & v509;\n\tv511 = v510 < 0;\n\tv512 = ~v511;\n\tif (v512) goto L_01C2;\n\tv585 = 0x6D2F50(UnityEngine.Mathf, 0, v54, v55, v56, v57, v58, v59, v319, v319.y, v319.z, capsuleP1, capsuleP1.y, capsuleP1.z, capsuleP1.z, capsuleRadius);\nL_01C2:\n\tgoto L_01C8;\n\tv613 = *([v590 @ X0_v35+E0]);\n\tv614 = v613 == 0;\n\tv615 = ~v614;\n\tgoto L_01C8;\n\tv617 = \"il2cpp_codegen_runtime_class_init\"(v590, v235, v54, v55, v56, v57, v58, v59, v586, v314, v366, v362, v310, v358, v5, capsuleRadius);\nL_01C8:\n\tv618 = v70 / v588;\n\tv622 = UnityEngine.Vector3::op_Multiply(v319, v618);\nL_01D8:\n\t// 472 MakeStruct v203 @ AGGA02710_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v601 @ V0_v7 (UnityEngine.Vector3), v599 @ V1_v5 (System.Single), v609 @ V2_v6 (System.Single)\n\t// 473 MakeStruct v200 @ AGGA02710_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v363 @ V3_v5 (UnityEngine.Vector3), v311 @ V4_v4 (System.Single), v359 @ V5_v5 (System.Single)\n\tv321 = UnityEngine.Vector3::op_Addition(v203, v200);\n\t*([particlePosition @ X0 (UnityEngine.Vector3&)]) = v321;\n\t*([particlePosition @ X0 (UnityEngine.Vector3&)+4]) = v321.y;\n\t*([particlePosition @ X0 (UnityEngine.Vector3&)+8]) = v321.z;\n\tgoto L_01F0;\nL_01F0:\n\treturn returnVal1;\n// 352 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe static bool OutsideCapsule(ref Vector3 particlePosition, float particleRadius, Vector3 capsuleP0, Vector3 capsuleP1, float capsuleRadius)
	{
		//IL_0032: Expected F4, but got O
		//IL_0044: Expected F4, but got O
		//IL_0059: Expected F4, but got I
		//IL_006e: Expected F4, but got I
		//IL_04c2: Expected F4, but got O
		//IL_04d7: Expected F4, but got I
		//IL_04ec: Expected F4, but got I
		//IL_03b1: Expected O, but got F4
		//IL_03be: Expected O, but got F4
		//IL_015b: Expected F4, but got O
		//IL_042d: Expected F4, but got O
		//IL_05a3: Expected O, but got F4
		//IL_05b0: Expected O, but got F4
		//IL_0247: Expected O, but got F4
		//IL_0254: Expected O, but got F4
		//IL_06a8: Expected F4, but got I
		//IL_02f8: Expected F4, but got I
		float num = particleRadius + capsuleRadius;
		float num2 = num * num;
		Vector3 rhs = capsuleP1 - capsuleP0;
		num2 = (float)particlePosition;
		Vector3 vector = default(Vector3);
		vector.x = (float)particlePosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+4]");
		vector.y = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+8]");
		vector.z = 0f;
		Vector3 vector2 = vector - capsuleP0;
		num2 = Vector3.Dot(vector2, rhs);
		bool flag = particleRadius < 0f;
		bool flag2 = !flag;
		bool flag3 = particleRadius == 0f;
		bool flag4 = !flag2;
		bool result;
		float num7;
		float y;
		float y2;
		Vector3 vector7;
		float z;
		Vector3 vector8;
		float z2;
		if (!(flag4 || flag3))
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
			if (particleRadius < particleRadius)
			{
				if (particleRadius > 0f)
				{
					float num3 = particleRadius / particleRadius;
					Vector3 vector3 = default(Vector3);
					object obj = default(object);
					vector3.x = (float)obj;
					vector3.y = rhs.y;
					vector3.z = rhs.z;
					Vector3 vector4 = vector3 * num3;
					Vector3 vector5 = vector2 - vector4;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
					bool flag5 = !(vector5.x > 0f);
					result = false;
					if (!flag5)
					{
						bool flag6 = !(vector5.x < particleRadius);
						result = false;
						if (!flag6)
						{
							float num4 = Mathf.Sqrt(vector5.x);
							float num5 = num4 - num4;
							object obj2 = num4 ^ num4;
							object obj3 = num4 ^ num5;
							int num6 = (int)((long)(IntPtr)obj2 & (long)(IntPtr)obj3);
							if (num6 < 0)
							{
								Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
								num4 = vector5.x;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+8]");
							num7 = 0f;
							num2 = num - num4;
							float num8 = particleRadius / num4;
							Vector3 vector6 = vector5 * num8;
							y = vector6.y;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+4]");
							y2 = 0f;
							vector7 = particlePosition;
							z = vector6.z;
							vector8 = vector6;
							goto IL_06ad;
						}
					}
				}
				else
				{
					result = false;
				}
			}
			else
			{
				Vector3 vector9 = default(Vector3);
				vector9.x = (float)particlePosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+4]");
				vector9.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+8]");
				vector9.z = 0f;
				Vector3 vector10 = vector9 - capsuleP1;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
				bool flag7 = !(vector10.x > 0f);
				result = false;
				if (!flag7)
				{
					bool flag8 = !(vector10.x < particleRadius);
					result = false;
					if (!flag8)
					{
						float num9 = Mathf.Sqrt(vector10.x);
						float num10 = num9 - num9;
						object obj4 = num9 ^ num9;
						object obj5 = num9 ^ num10;
						int num11 = (int)((long)(IntPtr)obj4 & (long)(IntPtr)obj5);
						if (num11 < 0)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
							num9 = vector10.x;
						}
						float num12 = num / num9;
						Vector3 vector11 = vector10 * num12;
						y = vector11.y;
						y2 = capsuleP1.y;
						vector7 = capsuleP1;
						z = vector11.z;
						vector8 = vector11;
						z2 = capsuleP1.z;
						goto IL_06c4;
					}
				}
			}
		}
		else
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
			bool flag9 = !(particleRadius > 0f);
			result = false;
			if (!flag9)
			{
				bool flag10 = !(particleRadius < particleRadius);
				result = false;
				if (!flag10)
				{
					float num13 = Mathf.Sqrt(particleRadius);
					float num14 = num13 - num13;
					object obj6 = num13 ^ num13;
					object obj7 = num13 ^ num14;
					int num15 = (int)((long)(IntPtr)obj6 & (long)(IntPtr)obj7);
					if (num15 < 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
						num13 = particleRadius;
					}
					float num16 = num / num13;
					Vector3 vector12 = default(Vector3);
					object obj8 = default(object);
					vector12.x = (float)obj8;
					vector12.y = vector2.y;
					vector12.z = vector2.z;
					Vector3 vector13 = vector12 * num16;
					y = vector13.y;
					y2 = capsuleP0.y;
					vector7 = capsuleP0;
					num7 = capsuleP0.z;
					z = vector13.z;
					vector8 = vector13;
					goto IL_06ad;
				}
			}
		}
		goto IL_0693;
		IL_06c4:
		Vector3 vector14 = default(Vector3);
		vector14.x = vector7.x;
		vector14.y = y2;
		vector14.z = z2;
		Vector3 vector15 = default(Vector3);
		vector15.x = vector8.x;
		vector15.y = y;
		vector15.z = z;
		Vector3 vector16 = vector14 + vector15;
		ref Vector3 reference = ref *(Vector3*)vector16;
		_ = vector16.y;
		_ = vector16.z;
		result = true;
		goto IL_0693;
		IL_0693:
		return result;
		IL_06ad:
		z2 = num7;
		goto IL_06c4;
	}

	[Token(Token = "0x6000021")]
	[Address(RVA = "0xA02748", Offset = "0xA02748", Length = "0x41C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv50 = *([1EC63F8]);\n\tv51 = *([v50 @ X8_v41]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, methodInfo, v54, v55, v56, v57, v58, v59, particleRadius, capsuleP0, v0, v2, capsuleP1, v3, v5, capsuleRadius);\n\tv62 = 0 | 1;\n\t*([2021C6A]) = v62;\nL_002E:\n\tv70 = capsuleRadius - particleRadius;\n\tgoto L_0040;\n\tv74 = *([v69 @ X0_v2+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_0040;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v69, methodInfo, v54, v55, v56, v57, v58, v59, particleRadius, capsuleP0, v0, v2, capsuleP1, v3, v5, capsuleRadius);\nL_0040:\n\tv89 = v70 * v70;\n\tv92 = UnityEngine.Vector3::op_Subtraction(capsuleP1, capsuleP0);\n\tparticleRadius = particlePosition->klass;\n\t// 83 MakeStruct v108 @ AGGA02830_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [particlePosition @ X0 (UnityEngine.Vector3&)], [particlePosition @ X0 (UnityEngine.Vector3&)+4], [particlePosition @ X0 (UnityEngine.Vector3&)+8]\n\tv110 = UnityEngine.Vector3::op_Subtraction(v108, capsuleP0);\n\tparticleRadius = UnityEngine.Vector3::Dot(v110, v92);\n\tv124 = particleRadius < 0;\n\tv125 = ~v124;\n\tv128 = particleRadius == 0;\n\tv133 = ~v125;\n\tv134 = v133 | v128;\n\tif (v134) goto L_0104;\n\tv139 = 0x158AB88(&v136 @ stack_-70_v7, 0, v54, v55, v56, v57, v58, v59, particleRadius, v110.y, v110.z, v92, v92.y, v92.z, capsuleP1.z, capsuleRadius);\n\tv153 = particleRadius >= particleRadius;\n\tif (v153) goto L_0153;\n\tv178 = particleRadius <= 0;\n\tif (v178) goto L_FFFFFFFF;\n\tv274 = particleRadius / particleRadius;\n\tgoto L_00A2;\n\tv415 = *([v292 @ X0_v42+E0]);\n\tv416 = v415 == 0;\n\tv417 = ~v416;\n\tif (v417) goto L_00A2;\n\tv419 = \"il2cpp_codegen_runtime_class_init\"(v292, v137, v54, v55, v56, v57, v58, v59, v122, v291, v112, v113, v114, v115, v5, capsuleRadius);\nL_00A2:\n\t// 162 MakeStruct v206 @ AGGA028C0_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v136 @ stack_-70_v7, v92.y (System.Single), v92.z (System.Single)\n\tv425 = UnityEngine.Vector3::op_Multiply(v206, v274);\n\tv255 = UnityEngine.Vector3::op_Subtraction(v110, v425);\n\tv261 = 0x158AB88(&v255 @ V0_v28 (UnityEngine.Vector3), 0, v54, v55, v56, v57, v58, v59, v255, v255.y, v255.z, v425, v425.y, v425.z, capsuleP1.z, capsuleRadius);\n\tv211 = v255 <= v89;\n\tif (v211) goto L_FFFFFFFF;\n\tgoto L_00D2;\n\tv579 = *([v501 @ X0_v48 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv580 = v579 == 0;\n\tv581 = ~v580;\n\tif (v581) goto L_00D2;\n\tv583 = \"il2cpp_codegen_runtime_class_init\"(v501, v208, v54, v55, v56, v57, v58, v59, v255, v258, v288, v285, v252, v282, v5, capsuleRadius);\nL_00D2:\n\tv567 = UnityEngine.Mathf::Sqrt(v255);\n\tv537 = v567 - v567;\n\tv531 = v567 ^ v567;\n\tv529 = v567 ^ v537;\n\tv527 = v531 & v529;\n\tv525 = v527 < 0;\n\tv523 = ~v525;\n\tif (v523) goto L_00E4;\n\tv628 = 0x6D2F50(UnityEngine.Mathf, 0, v54, v55, v56, v57, v58, v59, v255, v255.y, v255.z, v425, v425.y, v425.z, capsuleP1.z, capsuleRadius);\nL_00E4:\n\tv564 = particlePosition->monitor;\n\tgoto L_00F5;\n\tv638 = *([v632 @ X0_v51+E0]);\n\tv639 = v638 == 0;\n\tv640 = ~v639;\n\tgoto L_00F5;\n\tv642 = \"il2cpp_codegen_runtime_class_init\"(v632, v208, v54, v55, v56, v57, v58, v59, v629, v258, v288, v285, v252, v282, v5, capsuleRadius);\nL_00F5:\n\tparticleRadius = v70 - v567;\n\tv647 = particleRadius / v567;\n\tv649 = UnityEngine.Vector3::op_Multiply(v255, v647);\n\tgoto L_FFFFFFFF;\nL_0104:\n\tv143 = 0x158AB88(&v141 @ stack_-80_v7, 0, v54, v55, v56, v57, v58, v59, particleRadius, v110.y, v110.z, v92, v92.y, v92.z, capsuleP1.z, capsuleRadius);\n\tv166 = particleRadius <= v89;\n\tif (v166) goto L_FFFFFFFF;\n\tgoto L_011F;\n\tv306 = *([v188 @ X0_v16 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv307 = v306 == 0;\n\tv308 = ~v307;\n\tif (v308) goto L_011F;\n\tv310 = \"il2cpp_codegen_runtime_class_init\"(v188, v142, v54, v55, v56, v57, v58, v59, v122, v111, v112, v113, v114, v115, v5, capsuleRadius);\nL_011F:\n\tv448 = UnityEngine.Mathf::Sqrt(particleRadius);\n\tv429 = v448 - v448;\n\tv432 = v448 ^ v448;\n\tv433 = v448 ^ v429;\n\tv434 = v432 & v433;\n\tv435 = v434 < 0;\n\tv436 = ~v435;\n\tif (v436) goto L_0135;\n\tv447 = 0x6D2F50(UnityEngine.Mathf, 0, v54, v55, v56, v57, v58, v59, particleRadius, v110.y, v110.z, v92, v92.y, v92.z, capsuleP1.z, capsuleRadius);\nL_0135:\n\tgoto L_013F;\n\tv466 = *([v452 @ X0_v19+E0]);\n\tv467 = v466 == 0;\n\tv468 = ~v467;\n\tgoto L_013F;\n\tv470 = \"il2cpp_codegen_runtime_class_init\"(v452, v142, v54, v55, v56, v57, v58, v59, v450, v111, v112, v113, v114, v115, v5, capsuleRadius);\nL_013F:\n\tv477 = v70 / v448;\n\t// 321 MakeStruct v479 @ AGGA02A24_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v141 @ stack_-80_v7, v110.y (System.Single), v110.z (System.Single)\n\tv480 = UnityEngine.Vector3::op_Multiply(v479, v477);\n\tgoto L_01B2;\nL_0153:\n\tgoto L_0160;\n\tv297 = *([v179 @ X0_v27+E0]);\n\tv298 = v297 == 0;\n\tv299 = ~v298;\n\tif (v299) goto L_0160;\n\tv301 = \"il2cpp_codegen_runtime_class_init\"(v179, v137, v54, v55, v56, v57, v58, v59, v122, v111, v112, v113, v114, v115, v5, capsuleRadius);\nL_0160:\n\t// 352 MakeStruct v197 @ AGGA02A7C_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [particlePosition @ X0 (UnityEngine.Vector3&)], [particlePosition @ X0 (UnityEngine.Vector3&)+4], [particlePosition @ X0 (UnityEngine.Vector3&)+8]\n\tv256 = UnityEngine.Vector3::op_Subtraction(v197, capsuleP1);\n\tv262 = 0x158AB88(&v256 @ V0_v18 (UnityEngine.Vector3), 0, v54, v55, v56, v57, v58, v59, v256, v256.y, v256.z, capsuleP1, capsuleP1.y, capsuleP1.z, capsuleP1.z, capsuleRadius);\n\tv212 = v256 <= v89;\n\tif (v212) goto L_FFFFFFFF;\n\tgoto L_0185;\n\tv484 = *([v462 @ X0_v32 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv485 = v484 == 0;\n\tv486 = ~v485;\n\tif (v486) goto L_0185;\n\tv488 = \"il2cpp_codegen_runtime_class_init\"(v462, v209, v54, v55, v56, v57, v58, v59, v256, v259, v289, v286, v253, v283, v5, capsuleRadius);\nL_0185:\n\tv591 = UnityEngine.Mathf::Sqrt(v256);\n\tv507 = v591 - v591;\n\tv510 = v591 ^ v591;\n\tv511 = v591 ^ v507;\n\tv512 = v510 & v511;\n\tv513 = v512 < 0;\n\tv514 = ~v513;\n\tif (v514) goto L_019B;\n\tv588 = 0x6D2F50(UnityEngine.Mathf, 0, v54, v55, v56, v57, v58, v59, v256, v256.y, v256.z, capsuleP1, capsuleP1.y, capsuleP1.z, capsuleP1.z, capsuleRadius);\nL_019B:\n\tgoto L_01A5;\n\tv616 = *([v593 @ X0_v35+E0]);\n\tv617 = v616 == 0;\n\tv618 = ~v617;\n\tgoto L_01A5;\n\tv620 = \"il2cpp_codegen_runtime_class_init\"(v593, v209, v54, v55, v56, v57, v58, v59, v589, v259, v289, v286, v253, v283, v5, capsuleRadius);\nL_01A5:\n\tv624 = v70 / v591;\n\tv626 = UnityEngine.Vector3::op_Multiply(v256, v624);\nL_01B2:\n\t// 434 MakeStruct v319 @ AGGA02B2C_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v602 @ V0_v6 (UnityEngine.Vector3), v604 @ V1_v5 (System.Single), v612 @ V2_v6 (System.Single)\n\t// 435 MakeStruct v316 @ AGGA02B2C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v400 @ V3_v5 (UnityEngine.Vector3), v372 @ V4_v4 (System.Single), v398 @ V5_v5 (System.Single)\n\tv374 = UnityEngine.Vector3::op_Addition(v319, v316);\n\t*([particlePosition @ X0 (UnityEngine.Vector3&)]) = v374;\n\t*([particlePosition @ X0 (UnityEngine.Vector3&)+4]) = v374.y;\n\t*([particlePosition @ X0 (UnityEngine.Vector3&)+8]) = v374.z;\n\tgoto L_01CA;\nL_01CA:\n\treturn returnVal1;\n// 320 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe static bool InsideCapsule(ref Vector3 particlePosition, float particleRadius, Vector3 capsuleP0, Vector3 capsuleP1, float capsuleRadius)
	{
		//IL_0032: Expected F4, but got O
		//IL_0044: Expected F4, but got O
		//IL_0059: Expected F4, but got I
		//IL_006e: Expected F4, but got I
		//IL_0344: Expected O, but got F4
		//IL_0351: Expected O, but got F4
		//IL_0455: Expected F4, but got O
		//IL_046a: Expected F4, but got I
		//IL_047f: Expected F4, but got I
		//IL_03c0: Expected F4, but got O
		//IL_015b: Expected F4, but got O
		//IL_04fd: Expected O, but got F4
		//IL_050a: Expected O, but got F4
		//IL_020e: Expected O, but got F4
		//IL_021b: Expected O, but got F4
		//IL_05fd: Expected F4, but got I
		//IL_02cc: Expected F4, but got I
		float num = capsuleRadius - particleRadius;
		float num2 = num * num;
		Vector3 rhs = capsuleP1 - capsuleP0;
		float num3 = (float)particlePosition;
		Vector3 vector = default(Vector3);
		vector.x = (float)particlePosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+4]");
		vector.y = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+8]");
		vector.z = 0f;
		Vector3 vector2 = vector - capsuleP0;
		num3 = Vector3.Dot(vector2, rhs);
		bool flag = particleRadius < 0f;
		bool flag2 = !flag;
		bool flag3 = particleRadius == 0f;
		bool flag4 = !flag2;
		float num8;
		float y;
		Vector3 vector7;
		float y2;
		float z;
		Vector3 vector8;
		float z2;
		if (!(flag4 || flag3))
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
			if (particleRadius < particleRadius)
			{
				if (particleRadius > 0f)
				{
					float num4 = particleRadius / particleRadius;
					Vector3 vector3 = default(Vector3);
					object obj = default(object);
					vector3.x = (float)obj;
					vector3.y = rhs.y;
					vector3.z = rhs.z;
					Vector3 vector4 = vector3 * num4;
					Vector3 vector5 = vector2 - vector4;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
					if (vector5.x > num2)
					{
						float num5 = Mathf.Sqrt(vector5.x);
						float num6 = num5 - num5;
						object obj2 = num5 ^ num5;
						object obj3 = num5 ^ num6;
						int num7 = (int)((long)(IntPtr)obj2 & (long)(IntPtr)obj3);
						if (num7 < 0)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
							num5 = vector5.x;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+8]");
						num8 = 0f;
						num3 = num - num5;
						float num9 = particleRadius / num5;
						Vector3 vector6 = vector5 * num9;
						y = vector6.y;
						vector7 = particlePosition;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+4]");
						y2 = 0f;
						z = vector6.z;
						vector8 = vector6;
						goto IL_0602;
					}
				}
			}
			else
			{
				Vector3 vector9 = default(Vector3);
				vector9.x = (float)particlePosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+4]");
				vector9.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X0 (UnityEngine.Vector3&)+8]");
				vector9.z = 0f;
				Vector3 vector10 = vector9 - capsuleP1;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
				if (vector10.x > num2)
				{
					float num10 = Mathf.Sqrt(vector10.x);
					float num11 = num10 - num10;
					object obj4 = num10 ^ num10;
					object obj5 = num10 ^ num11;
					int num12 = (int)((long)(IntPtr)obj4 & (long)(IntPtr)obj5);
					if (num12 < 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
						num10 = vector10.x;
					}
					float num13 = num / num10;
					Vector3 vector11 = vector10 * num13;
					y = vector11.y;
					vector7 = capsuleP1;
					y2 = capsuleP1.y;
					z = vector11.z;
					vector8 = vector11;
					z2 = capsuleP1.z;
					goto IL_061e;
				}
			}
		}
		else
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
			if (particleRadius > num2)
			{
				float num14 = Mathf.Sqrt(particleRadius);
				float num15 = num14 - num14;
				object obj6 = num14 ^ num14;
				object obj7 = num14 ^ num15;
				int num16 = (int)((long)(IntPtr)obj6 & (long)(IntPtr)obj7);
				if (num16 < 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
					num14 = particleRadius;
				}
				float num17 = num / num14;
				Vector3 vector12 = default(Vector3);
				object obj8 = default(object);
				vector12.x = (float)obj8;
				vector12.y = vector2.y;
				vector12.z = vector2.z;
				Vector3 vector13 = vector12 * num17;
				y = vector13.y;
				vector7 = capsuleP0;
				y2 = capsuleP0.y;
				num8 = capsuleP0.z;
				z = vector13.z;
				vector8 = vector13;
				goto IL_0602;
			}
		}
		return false;
		IL_0602:
		z2 = num8;
		goto IL_061e;
		IL_061e:
		Vector3 vector14 = default(Vector3);
		vector14.x = vector7.x;
		vector14.y = y2;
		vector14.z = z2;
		Vector3 vector15 = default(Vector3);
		vector15.x = vector8.x;
		vector15.y = y;
		vector15.z = z;
		Vector3 vector16 = vector14 + vector15;
		ref Vector3 reference = ref *(Vector3*)vector16;
		_ = vector16.y;
		_ = vector16.z;
		return true;
	}

	[Token(Token = "0x6000022")]
	[Address(RVA = "0xA02B64", Offset = "0xA02B64", Length = "0x1C4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EAC080]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021C6B]) = v46;\nL_001B:\n\tv51 = UnityEngine.Behaviour::get_enabled(this);\n\tv53 = v51 == 0;\n\tif (v53) goto L_00B7;\n\tv55 = this.m_Bound == 0;\n\tif (v55) goto L_0029;\n\tv209 = UnityEngine.Color::get_magenta();\n\tv208 = v209.g;\n\tv207 = v209.b;\n\tv206 = v209.a;\n\tgoto L_002E;\nL_0029:\n\tv209 = UnityEngine.Color::get_yellow();\n\tv208 = v209.g;\n\tv207 = v209.b;\n\tv206 = v209.a;\nL_002E:\n\t// 46 MakeStruct v60 @ AGGA02BDC_0_v2 (UnityEngine.Color), typeof(UnityEngine.Color), v209 @ V0_v2 (UnityEngine.Color), v208 @ V1_v2 (System.Single), v207 @ V2_v2 (System.Single), v206 @ V3_v2 (System.Single)\n\tUnityEngine.Gizmos::set_color(v60);\n\tv215 = UnityEngine.Component::get_transform(this);\n\tv218 = UnityEngine.Transform::get_lossyScale(v215);\n\tgoto L_004A;\n\tv274 = *([v270 @ X0_v11+E0]);\n\tv275 = v274 == 0;\n\tv276 = ~v275;\n\tif (v276) goto L_004A;\n\tv278 = \"il2cpp_codegen_runtime_class_init\"(v270, v217, v30, v31, v32, v33, v34, v35, v218, v265, v266, v206, v40, v41, v42, v43);\nL_004A:\n\tv248 = UnityEngine.Mathf::Abs(v218);\n\tv110 = this.m_Radius * v248;\n\tv281 = this.m_Height * 0.5f;\n\tv253 = v281 - this.m_Radius;\n\tv282 = v253 < 0;\n\tv240 = ~v282;\n\tv234 = v253 == 0;\n\tv283 = ~v240;\n\tv83 = v283 | v234;\n\tif (v83) goto L_007D;\n\tv245 = this.m_Center;\n\tv225 = this.m_Center.y;\n\tv322 = this.m_Center.z;\n\tv295 = this.m_Direction == 2;\n\tif (v295) goto L_0084;\n\tv305 = this.m_Direction == 1;\n\tif (v305) goto L_0087;\n\tv313 = this.m_Direction == 0;\n\tv314 = ~v313;\n\tif (v314) goto L_008E;\n\tv333 = this.m_Center - v253;\n\tgoto L_008A;\nL_007D:\n\tv352 = UnityEngine.Component::get_transform(this);\n\tv350 = this.m_Center;\n\tv348 = this.m_Center.y;\n\tv346 = this.m_Center.z;\n\tgoto L_00A6;\nL_0084:\n\tv322 = v322 - v253;\n\tgoto L_008A;\nL_0087:\n\tv225 = v225 - v253;\nL_008A:\n\tv338 = v253 + *([v335 @ X8_v12]);\n\t*([v335 @ X8_v12]) = v338;\nL_008E:\n\tv258 = UnityEngine.Component::get_transform(this);\n\t// 149 MakeStruct v220 @ AGGA02CD0_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v245 @ V9_v8 (UnityEngine.Vector3), v225 @ V10_v7 (System.Single), v322 @ V11_v6 (System.Single)\n\tv255 = UnityEngine.Transform::TransformPoint(v258, v220);\n\tUnityEngine.Gizmos::DrawWireSphere(v255, v110);\n\tv352 = UnityEngine.Component::get_transform(this);\nL_00A6:\n\t// 166 MakeStruct v57 @ AGGA02CFC_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v350 @ V0_v8 (UnityEngine.Vector3), v348 @ V1_v6 (System.Single), v346 @ V2_v6 (System.Single)\n\tv122 = UnityEngine.Transform::TransformPoint(v352, v57);\n\tUnityEngine.Gizmos::DrawWireSphere(v122, v110);\nL_00B7:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDrawGizmosSelected()
	{
		//IL_028a: Expected O, but got F4
		//IL_03d7: Expected O, but got F4
		//IL_02b8: Expected O, but got F4
		//IL_0211: Expected O, but got F4
		if (!base.enabled)
		{
			return;
		}
		Color color;
		float g;
		float b;
		float a;
		if (m_Bound != Bound.Outside)
		{
			color = Color.magenta;
			g = color.g;
			b = color.b;
			a = color.a;
		}
		else
		{
			color = Color.yellow;
			g = color.g;
			b = color.b;
			a = color.a;
		}
		Color color2 = default(Color);
		color2.r = color.r;
		color2.g = g;
		color2.b = b;
		color2.a = a;
		Gizmos.color = color2;
		Transform transform = base.transform;
		float num = Mathf.Abs(transform.lossyScale.x);
		float radius = m_Radius * num;
		float num2 = m_Height * 0.5f;
		float num3 = num2 - m_Radius;
		bool flag = num3 < 0f;
		bool flag2 = !flag;
		bool flag3 = num3 == 0f;
		bool flag4 = !flag2;
		Vector3 vector;
		float num4;
		float num5;
		float num6 = default(float);
		Vector3 center;
		float num7 = default(float);
		if (!(flag4 || flag3))
		{
			vector = m_Center;
			num4 = m_Center.y;
			num5 = m_Center.z;
			object obj;
			if (m_Direction != Direction.Z)
			{
				if (m_Direction != Direction.Y)
				{
					bool flag5 = m_Direction == Direction.X;
					bool flag6 = !flag5;
					num6 = num5;
					center = m_Center;
					num7 = num4;
					if (flag6)
					{
						goto IL_03b1;
					}
					float num8 = m_Center.x - num3;
					num6 = num5;
					num7 = num4;
					vector = (Vector3)num8;
					obj = center;
				}
				else
				{
					num4 -= num3;
					num6 = num5;
					center = m_Center;
					obj = num7;
				}
			}
			else
			{
				num5 -= num3;
				center = m_Center;
				num7 = m_Center.y;
				obj = num6;
			}
			float num9 = num3 + (float)obj;
			obj = num9;
			goto IL_03b1;
		}
		Transform transform2 = base.transform;
		Vector3 vector2 = m_Center;
		float y = m_Center.y;
		float z = m_Center.z;
		goto IL_03dc;
		IL_03b1:
		Transform transform3 = base.transform;
		Vector3 position = default(Vector3);
		position.x = vector.x;
		position.y = num4;
		position.z = num5;
		Vector3 center2 = transform3.TransformPoint(position);
		Gizmos.DrawWireSphere(center2, radius);
		transform2 = base.transform;
		z = num6;
		y = num7;
		vector2 = center;
		goto IL_03dc;
		IL_03dc:
		Vector3 position2 = default(Vector3);
		position2.x = vector2.x;
		position2.y = y;
		position2.z = z;
		Vector3 center3 = transform2.TransformPoint(position2);
		Gizmos.DrawWireSphere(center3, radius);
	}

	[Token(Token = "0x6000023")]
	[Address(RVA = "0xA02D28", Offset = "0xA02D28", Length = "0xC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Radius = 0.5f;\n\tDynamicBoneColliderBase::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public DynamicBoneCollider()
	{
		m_Radius = 0.5f;
	}
}
