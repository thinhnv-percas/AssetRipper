using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x74C714", Offset = "0x74C714")]
[Token(Token = "0x2000006")]
public class DynamicBonePlaneCollider : DynamicBoneColliderBase
{
	[Token(Token = "0x6000026")]
	[Address(RVA = "0xA0333C", Offset = "0xA0333C", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	private void OnValidate()
	{
	}

	[Token(Token = "0x6000027")]
	[Address(RVA = "0xA03340", Offset = "0xA03340", Length = "0x200")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv36 = *([1EE0068]);\n\tv37 = *([v36 @ X8_v14]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, particlePosition, methodInfo, v40, v41, v42, v43, v44, particleRadius, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2021C6F]) = v55;\nL_001E:\n\tv58 = 0;\n\tgoto L_002B;\n\tv64 = *([v60 @ X0_v2+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_002B;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, particlePosition, methodInfo, v40, v41, v42, v43, v44, particleRadius, v46, v47, v48, v49, v50, v51, v52);\nL_002B:\n\tv72 = UnityEngine.Vector3::get_up();\n\tv79 = this.m_Direction == 0;\n\tif (v79) goto L_0055;\n\tv84 = this.m_Direction == 1;\n\tif (v84) goto L_005F;\n\tv101 = this.m_Direction != 2;\n\tif (v101) goto L_006B;\n\tv108 = UnityEngine.Component::get_transform(this);\n\tv140 = UnityEngine.Transform::get_forward(v108);\n\tv138 = v140.y;\n\tv136 = v140.z;\n\tgoto L_FFFFFFFF;\nL_0055:\n\tv91 = UnityEngine.Component::get_transform(this);\n\tv140 = UnityEngine.Transform::get_right(v91);\n\tv138 = v140.y;\n\tv136 = v140.z;\n\tgoto L_FFFFFFFF;\nL_005F:\n\tv104 = UnityEngine.Component::get_transform(this);\n\tv140 = UnityEngine.Transform::get_up(v104);\n\tv138 = v140.y;\n\tv136 = v140.z;\nL_006B:\n\tv147 = UnityEngine.Component::get_transform(this);\n\t// 114 MakeStruct v191 @ AGGA03458_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_Center (UnityEngine.Vector3), this.m_Center.y (System.Single), this.m_Center.z (System.Single)\n\tv192 = UnityEngine.Transform::TransformPoint(v147, v191);\n\tv280 = 0x10C8784(&v58 @ stack_-70_v1, 0, methodInfo, v40, v41, v42, v43, v44, v133, v131, v129, v192, v192.y, v192.z, v51, v52);\n\tv285 = 0x10C892C(&v58 @ stack_-70_v1, 0, methodInfo, v40, v41, v42, v43, v44, *([particlePosition @ X1 (UnityEngine.Vector3&)]), *([particlePosition @ X1 (UnityEngine.Vector3&)+4]), *([particlePosition @ X1 (UnityEngine.Vector3&)+8]), v192, v192.y, v192.z, v51, v52);\n\tv239 = *([particlePosition @ X1 (UnityEngine.Vector3&)]) < 0;\n\tv289 = this.m_Bound == 0;\n\tif (v289) goto L_00BD;\n\tv292 = *([particlePosition @ X1 (UnityEngine.Vector3&)]) <= 0;\n\tif (v292) goto L_FFFFFFFF;\nL_009D:\n\tgoto L_00A8;\n\tv303 = *([v294 @ X0_v15+E0]);\n\tv304 = v303 == 0;\n\tv305 = ~v304;\n\tif (v305) goto L_00A8;\n\tv307 = \"il2cpp_codegen_runtime_class_init\"(v294, v225, methodInfo, v40, v41, v42, v43, v44, v281, v282, v283, v272, v273, v274, v51, v52);\nL_00A8:\n\t// 168 MakeStruct v315 @ AGGA034DC_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v133 @ V8_v3 (UnityEngine.Vector3), v131 @ V9_v3 (System.Single), v129 @ V10_v3 (System.Single)\n\tv316 = UnityEngine.Vector3::op_Multiply(v315, *([particlePosition @ X1 (UnityEngine.Vector3&)]));\n\t// 179 MakeStruct v318 @ AGGA034FC_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [particlePosition @ X1 (UnityEngine.Vector3&)], [particlePosition @ X1 (UnityEngine.Vector3&)+4], [particlePosition @ X1 (UnityEngine.Vector3&)+8]\n\tv327 = UnityEngine.Vector3::op_Subtraction(v318, v316);\n\t*([particlePosition @ X1 (UnityEngine.Vector3&)]) = v327;\n\t*([particlePosition @ X1 (UnityEngine.Vector3&)+4]) = v327.y;\n\t*([particlePosition @ X1 (UnityEngine.Vector3&)+8]) = v327.z;\n\tgoto L_00CC;\nL_00BD:\n\tif (v239) goto L_009D;\nL_00CC:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe override bool Collide(ref Vector3 particlePosition, float particleRadius)
	{
		//IL_02f1: Expected O, but got I4
		//IL_024c: Expected F4, but got O
		//IL_0262: Expected F4, but got O
		//IL_0277: Expected F4, but got I
		//IL_028c: Expected F4, but got I
		object obj = 0;
		Vector3 up = Vector3.up;
		float z;
		float y;
		Vector3 vector;
		Vector3 vector2;
		float y2;
		float z2;
		if (m_Direction != Direction.X)
		{
			if (m_Direction != Direction.Y)
			{
				bool flag = m_Direction != Direction.Z;
				z = up.z;
				y = up.y;
				vector = up;
				if (flag)
				{
					goto IL_02f6;
				}
				Transform transform = base.transform;
				vector2 = transform.forward;
				y2 = vector2.y;
				z2 = vector2.z;
			}
			else
			{
				Transform transform2 = base.transform;
				vector2 = transform2.up;
				y2 = vector2.y;
				z2 = vector2.z;
			}
		}
		else
		{
			Transform transform3 = base.transform;
			vector2 = transform3.right;
			y2 = vector2.y;
			z2 = vector2.z;
		}
		z = z2;
		y = y2;
		vector = vector2;
		goto IL_02f6;
		IL_020e:
		Vector3 vector3 = default(Vector3);
		vector3.x = vector.x;
		vector3.y = y;
		vector3.z = z;
		Vector3 vector4 = vector3 * (float)particlePosition;
		Vector3 vector5 = default(Vector3);
		vector5.x = (float)particlePosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X1 (UnityEngine.Vector3&)+4]");
		vector5.y = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particlePosition @ X1 (UnityEngine.Vector3&)+8]");
		vector5.z = 0f;
		Vector3 vector6 = vector5 - vector4;
		ref Vector3 reference = ref *(Vector3*)vector6;
		_ = vector6.y;
		_ = vector6.z;
		return true;
		IL_02f6:
		Transform transform4 = base.transform;
		Vector3 position = default(Vector3);
		position.x = m_Center.x;
		position.y = m_Center.y;
		position.z = m_Center.z;
		Vector3 vector7 = transform4.TransformPoint(position);
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C8784 (inside UnityEngine.Object::.cctor +0x54)");
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C892C (inside UnityEngine.Object::.cctor +0x1FC)");
		bool flag2 = (long)(IntPtr)particlePosition < 0L;
		if (m_Bound != Bound.Outside)
		{
			if ((long)(IntPtr)particlePosition > 0L)
			{
				goto IL_020e;
			}
		}
		else if (flag2)
		{
			goto IL_020e;
		}
		return false;
	}

	[Token(Token = "0x6000028")]
	[Address(RVA = "0xA03540", Offset = "0xA03540", Length = "0x1D0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1EEEFC0]);\n\tv31 = *([v30 @ X8_v13]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021C70]) = v50;\nL_001B:\n\tv53 = UnityEngine.Behaviour::get_enabled(this);\n\tv55 = v53 == 0;\n\tif (v55) goto L_0033;\n\tv57 = this.m_Bound == 0;\n\tif (v57) goto L_0035;\n\tv186 = UnityEngine.Color::get_magenta();\n\tv185 = v186.g;\n\tv184 = v186.b;\n\tv152 = v186.a;\n\tgoto L_003A;\nL_0033:\n\treturn;\nL_0035:\n\tv186 = UnityEngine.Color::get_yellow();\n\tv185 = v186.g;\n\tv184 = v186.b;\n\tv152 = v186.a;\nL_003A:\n\t// 58 MakeStruct v74 @ AGGA035C8_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v186 @ V0_v1 (UnityEngine.Color), v185 @ V1_v1 (System.Single), v184 @ V2_v1 (System.Single), v152 @ V3_v1 (System.Single)\n\tUnityEngine.Gizmos::set_color(v74);\n\tgoto L_0049;\n\tv194 = *([v190 @ X0_v6+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\tgoto L_0049;\n\tv198 = \"il2cpp_codegen_runtime_class_init\"(v190, v52, v34, v35, v36, v37, v38, v39, v186, v185, v184, v152, v44, v45, v46, v47);\nL_0049:\n\tv202 = UnityEngine.Vector3::get_up();\n\tv208 = this.m_Direction == 0;\n\tif (v208) goto L_0073;\n\tv213 = this.m_Direction == 1;\n\tif (v213) goto L_007D;\n\tv230 = this.m_Direction != 2;\n\tif (v230) goto L_0089;\n\tv237 = UnityEngine.Component::get_transform(this);\n\tv260 = UnityEngine.Transform::get_forward(v237);\n\tv258 = v260.y;\n\tv256 = v260.z;\n\tgoto L_FFFFFFFF;\nL_0073:\n\tv220 = UnityEngine.Component::get_transform(this);\n\tv260 = UnityEngine.Transform::get_right(v220);\n\tv258 = v260.y;\n\tv256 = v260.z;\n\tgoto L_FFFFFFFF;\nL_007D:\n\tv233 = UnityEngine.Component::get_transform(this);\n\tv260 = UnityEngine.Transform::get_up(v233);\n\tv258 = v260.y;\n\tv256 = v260.z;\nL_0089:\n\tv267 = UnityEngine.Component::get_transform(this);\n\t// 144 MakeStruct v93 @ AGGA03690_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_Center (UnityEngine.Vector3), this.m_Center.y (System.Single), this.m_Center.z (System.Single)\n\tv283 = UnityEngine.Transform::TransformPoint(v267, v93);\n\tgoto L_00A9;\n\tv297 = *([v290 @ X0_v13+E0]);\n\tv298 = v297 == 0;\n\tv299 = ~v298;\n\tif (v299) goto L_00A9;\n\tv301 = \"il2cpp_codegen_runtime_class_init\"(v290, v95, v34, v35, v36, v37, v38, v39, v283, v288, v289, v152, v44, v45, v46, v47);\nL_00A9:\n\t// 169 MakeStruct v83 @ AGGA036D4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v251 @ V8_v4 (UnityEngine.Vector3), v253 @ V9_v4 (System.Single), v249 @ V10_v4 (System.Single)\n\tv309 = UnityEngine.Vector3::op_Addition(v283, v83);\n\tUnityEngine.Gizmos::DrawLine(v283, v309);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 132 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDrawGizmosSelected()
	{
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
		Vector3 up = Vector3.up;
		float z;
		Vector3 vector;
		float y;
		Vector3 vector2;
		float y2;
		float z2;
		if (m_Direction != Direction.X)
		{
			if (m_Direction != Direction.Y)
			{
				bool flag = m_Direction != Direction.Z;
				z = up.z;
				vector = up;
				y = up.y;
				if (flag)
				{
					goto IL_02db;
				}
				Transform transform = base.transform;
				vector2 = transform.forward;
				y2 = vector2.y;
				z2 = vector2.z;
			}
			else
			{
				Transform transform2 = base.transform;
				vector2 = transform2.up;
				y2 = vector2.y;
				z2 = vector2.z;
			}
		}
		else
		{
			Transform transform3 = base.transform;
			vector2 = transform3.right;
			y2 = vector2.y;
			z2 = vector2.z;
		}
		z = z2;
		vector = vector2;
		y = y2;
		goto IL_02db;
		IL_02db:
		Transform transform4 = base.transform;
		Vector3 position = default(Vector3);
		position.x = m_Center.x;
		position.y = m_Center.y;
		position.z = m_Center.z;
		Vector3 vector3 = transform4.TransformPoint(position);
		Vector3 vector4 = default(Vector3);
		vector4.x = vector.x;
		vector4.y = y;
		vector4.z = z;
		Vector3 to = vector3 + vector4;
		Gizmos.DrawLine(vector3, to);
	}

	[Token(Token = "0x6000029")]
	[Address(RVA = "0xA03710", Offset = "0xA03710", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDynamicBoneColliderBase::.ctor(this);\n\treturn;\n")]
	public DynamicBonePlaneCollider()
	{
	}
}
