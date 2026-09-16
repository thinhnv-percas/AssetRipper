using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755230", Offset = "0x755230")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755230", Offset = "0x755230")]
	[Token(Token = "0x20001B8")]
	public class DebugDrawShape : FsmStateAction
	{
		[Token(Token = "0x2000486")]
		public enum ShapeType
		{
			[Token(Token = "0x4002162")]
			Sphere = 0,
			[Token(Token = "0x4002163")]
			Cube = 1,
			[Token(Token = "0x4002164")]
			WireSphere = 2,
			[Token(Token = "0x4002165")]
			WireCube = 3
		}

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE1B4", Offset = "0x7AE1B4")]
		[Token(Token = "0x4001375")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE200", Offset = "0x7AE200")]
		[Token(Token = "0x4001376")]
		[FieldOffset(Offset = "0x58")]
		public ShapeType shape;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE238", Offset = "0x7AE238")]
		[Token(Token = "0x4001377")]
		[FieldOffset(Offset = "0x60")]
		public FsmColor color;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE270", Offset = "0x7AE270")]
		[Token(Token = "0x4001378")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat radius;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE2A8", Offset = "0x7AE2A8")]
		[Token(Token = "0x4001379")]
		[FieldOffset(Offset = "0x70")]
		public FsmVector3 size;

		[Token(Token = "0x6000950")]
		[Address(RVA = "0xA85710", Offset = "0xA85710", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.shape = 0;\n\tv13 = UnityEngine.Color::get_grey();\n\tv19 = HutongGames.PlayMaker.FsmColor::op_Implicit(v13);\n\tthis.color = v19;\n\tv23 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.radius = v23;\n\tv25 = 0;\n\tv31 = 0x1586898(&v25 @ stack_-30_v1, 0, v32, v33, v34, v35, v36, v37, 1f, 1f, 1f, v13.a, v38, v39, v40, v41);\n\t// 35 MakeStruct v47 @ AGGA85784_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v44 @ stack_-2C, 0\n\tv48 = HutongGames.PlayMaker.FsmVector3::op_Implicit(v47);\n\tthis.size = v48;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0061: Expected O, but got I4
			//IL_008b: Expected F4, but got O
			gameObject = null;
			shape = default(ShapeType);
			Color grey = Color.grey;
			FsmColor fsmColor = grey;
			color = fsmColor;
			FsmFloat fsmFloat = 1f;
			radius = fsmFloat;
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 vector = default(Vector3);
			vector.x = 0f;
			object obj2 = default(object);
			vector.y = (float)obj2;
			vector.z = 0f;
			FsmVector3 fsmVector = vector;
			size = fsmVector;
		}

		[Token(Token = "0x6000951")]
		[Address(RVA = "0xA857A0", Offset = "0xA857A0", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EE16F0]);\n\tv25 = *([v24 @ X8_v14]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202218F]) = v44;\nL_001B:\n\tv49 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv74 = UnityEngine.GameObject::get_transform(v49);\n\tgoto L_0031;\n\tv159 = *([v77 @ X8_v6+E0]);\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_0031;\n\tv166 = v77;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v166, v73, v48, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0031:\n\tv64 = UnityEngine.Object::op_Equality(v74, 0);\n\tv168 = v64 == 0;\n\tif (v168) goto L_003E;\nL_003D:\n\treturn;\nL_003E:\n\tv68 = this.color;\n\t// 70 MakeStruct v119 @ AGGA85860_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v68.value (UnityEngine.Color), v68.value.g (System.Single), v68.value.b (System.Single), v68.value.a (System.Single)\n\tUnityEngine.Gizmos::set_color(v119);\n\tv169 = this.shape;\n\tv170 = this.shape < 3;\n\tv115 = ~v170;\n\tv111 = this.shape - 3;\n\tv103 = v111 == 0;\n\tv171 = ~v103;\n\tv83 = v115 & v171;\n\tif (v83) goto L_003D;\n\tv142 = 0x1818000 + 0xDD4;\n\tv154 = *([v142 @ X9_v5 (System.Int32)+v169 @ X8_v8 (HutongGames.PlayMaker.Actions.DebugDrawShape+ShapeType)*4]) + v142;\n\t// 89 IndirectJump v154 @ X8_v10, 0, 0, 0, 0, v29 @ X3, v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v68.value (UnityEngine.Color), v68.value.g (System.Single), v68.value.b (System.Single), v68.value.a (System.Single), v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX1 = 0;\n\tV0 = UnityEngine.Transform::get_position(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = *([X19+68]);\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tV3 = V0;\n\tV0 = V8;\n\tV1 = V9;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tV9 = stack[10];\n\tV8 = stack[18];\n\tV2 = V10;\n\tX0 = 0;\n\tV10 = stack[0];\n\t// 117 ShiftStack 64\n\t// 118 MakeStruct AGGA858D4_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tUnityEngine.Gizmos::DrawSphere(AGGA858D4_0, V3, X0);\n\treturn;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX1 = 0;\n\tV0 = UnityEngine.Transform::get_position(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = *([X19+70]);\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmVector3::get_Value(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = V0;\n\tV4 = V1;\n\tV0 = V8;\n\tV1 = V9;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tV9 = stack[10];\n\tV8 = stack[18];\n\tV5 = V2;\n\tV2 = V10;\n\tX0 = 0;\n\tV10 = stack[0];\n\t// 152 ShiftStack 64\n\t// 153 MakeStruct AGGA85930_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\t// 154 MakeStruct AGGA85930_1, typeof(UnityEngine.Vector3), V3, V4, V5\n\tUnityEngine.Gizmos::DrawCube(AGGA85930_0, AGGA85930_1, X0);\n\treturn;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX1 = 0;\n\tV0 = UnityEngine.Transform::get_position(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = *([X19+68]);\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tV3 = V0;\n\tV0 = V8;\n\tV1 = V9;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tV9 = stack[10];\n\tV8 = stack[18];\n\tV2 = V10;\n\tX0 = 0;\n\tV10 = stack[0];\n\t// 184 ShiftStack 64\n\t// 185 MakeStruct AGGA85984_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tUnityEngine.Gizmos::DrawWireSphere(AGGA85984_0, V3, X0);\n\treturn;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X20;\n\tX1 = 0;\n\tV0 = UnityEngine.Transform::get_position(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = *([X19+70]);\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmVector3::get_Value(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = V0;\n\tV4 = V1;\n\tV0 = V8;\n\tV1 = V9;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tV9 = stack[10];\n\tV8 = stack[18];\n\tV5 = V2;\n\tV2 = V10;\n\tX0 = 0;\n\tV10 = stack[0];\n\t// 219 ShiftStack 64\n\t// 220 MakeStruct AGGA859E0_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\t// 221 MakeStruct AGGA859E0_1, typeof(UnityEngine.Vector3), V3, V4, V5\n\tUnityEngine.Gizmos::DrawWireCube(AGGA859E0_0, AGGA859E0_1, X0);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnDrawActionGizmos()
		{
			//IL_0160: Expected O, but got I
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Transform transform = ownerDefaultTarget.transform;
			if (!(transform == null))
			{
				FsmColor fsmColor = this.color;
				Color color = default(Color);
				color.r = fsmColor.value.r;
				color.g = fsmColor.value.g;
				color.b = fsmColor.value.b;
				color.a = fsmColor.value.a;
				Gizmos.color = color;
				ShapeType shapeType = shape;
				bool flag = shape < ShapeType.WireCube;
				bool flag2 = !flag;
				int num = (int)(shape - 3);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num2 = 25264128 + 3540;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X9_v5 (System.Int32)+v169 @ X8_v8 (HutongGames.PlayMaker.Actions.DebugDrawShape+ShapeType)*4]");
					object obj = 0L + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v154 @ X8_v10 (should have been resolved before IL gen)");
				}
			}
		}

		[Token(Token = "0x6000952")]
		[Address(RVA = "0xA859F0", Offset = "0xA859F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DebugDrawShape()
		{
		}
	}
}
