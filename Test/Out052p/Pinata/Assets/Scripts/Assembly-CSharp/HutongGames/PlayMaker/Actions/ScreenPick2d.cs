using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75AC5C", Offset = "0x75AC5C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75AC5C", Offset = "0x75AC5C")]
	[Token(Token = "0x20002CE")]
	public class ScreenPick2d : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF250", Offset = "0x7BF250")]
		[Token(Token = "0x400187B")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 screenVector;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF288", Offset = "0x7BF288")]
		[Token(Token = "0x400187C")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat screenX;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF2C0", Offset = "0x7BF2C0")]
		[Token(Token = "0x400187D")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat screenY;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF2F8", Offset = "0x7BF2F8")]
		[Token(Token = "0x400187E")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool normalized;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BF330", Offset = "0x7BF330")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF330", Offset = "0x7BF330")]
		[Token(Token = "0x400187F")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool storeDidPickObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BF380", Offset = "0x7BF380")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF380", Offset = "0x7BF380")]
		[Token(Token = "0x4001880")]
		[FieldOffset(Offset = "0x78")]
		public FsmGameObject storeGameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BF3D0", Offset = "0x7BF3D0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF3D0", Offset = "0x7BF3D0")]
		[Token(Token = "0x4001881")]
		[FieldOffset(Offset = "0x80")]
		public FsmVector3 storePoint;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BF420", Offset = "0x7BF420")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF420", Offset = "0x7BF420")]
		[Token(Token = "0x4001882")]
		[FieldOffset(Offset = "0x88")]
		public FsmInt[] layerMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF470", Offset = "0x7BF470")]
		[Token(Token = "0x4001883")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool invertMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF4A8", Offset = "0x7BF4A8")]
		[Token(Token = "0x4001884")]
		[FieldOffset(Offset = "0x98")]
		public bool everyFrame;

		[Token(Token = "0x6000E0C")]
		[Address(RVA = "0xB25B28", Offset = "0xB25B28", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F02938]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20225D9]) = v42;\nL_0018:\n\tv46 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.screenVector = v46;\n\tv54 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v54);\n\tv54.useVariable = 1;\n\tthis.screenX = v54;\n\tv61 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v61);\n\tv61.useVariable = 1;\n\tthis.screenY = v61;\n\tv93 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.storeGameObject = 0;\n\tthis.storePoint = 0;\n\tthis.normalized = v93;\n\tthis.storeDidPickObject = 0;\n\t// 65 NewArr v97 @ X0_v14 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v97;\n\tv79 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v79;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			screenVector = fsmVector;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			screenX = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			screenY = fsmFloat2;
			FsmBool fsmBool = false;
			storeGameObject = null;
			storePoint = null;
			normalized = fsmBool;
			storeDidPickObject = null;
			FsmInt[] array = new FsmInt[0];
			layerMask = array;
			FsmBool fsmBool2 = false;
			invertMask = fsmBool2;
			everyFrame = false;
		}

		[Token(Token = "0x6000E0D")]
		[Address(RVA = "0xB25C30", Offset = "0xB25C30", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ScreenPick2d::DoScreenPick(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoScreenPick();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E0E")]
		[Address(RVA = "0xB25FF8", Offset = "0xB25FF8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ScreenPick2d::DoScreenPick(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoScreenPick();
		}

		[Token(Token = "0x6000E0F")]
		[Address(RVA = "0xB25C6C", Offset = "0xB25C6C", Length = "0x38C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1EB2790]);\n\tv29 = *([v28 @ X8_v33]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20225DA]) = v48;\nL_001D:\n\tv54 = UnityEngine.Camera::get_main();\n\tgoto L_002F;\n\tv62 = *([v58 @ X8_v3+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_002F;\n\tv73 = v58;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v73, methodInfo, v32, v33, v34, v35, v36, v37, v49, v39, v40, v41, v42, v43, v44, v45);\nL_002F:\n\tv72 = UnityEngine.Object::op_Equality(v54, 0);\n\tv75 = v72 == 0;\n\tif (v75) goto L_0043;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"No MainCamera defined!\");\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tgoto L_013E;\nL_0043:\n\tgoto L_004A;\n\tv89 = *([v83 @ X0_v8+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_004A;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v83, v70, v71, v33, v34, v35, v36, v37, v49, v39, v40, v41, v42, v43, v44, v45);\nL_004A:\n\tv97 = UnityEngine.Vector3::get_zero();\n\tv207 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenVector);\n\tv366 = v207 == 0;\n\tv367 = ~v366;\n\tif (v367) goto L_0067;\n\tv405 = HutongGames.PlayMaker.FsmVector3::get_Value(this.screenVector);\nL_0067:\n\tv409 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenX);\n\tv411 = v409 == 0;\n\tv412 = ~v411;\n\tif (v412) goto L_0076;\n\tv414 = HutongGames.PlayMaker.FsmFloat::get_Value(this.screenX);\nL_0076:\n\tv418 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenY);\n\tv420 = v418 == 0;\n\tv421 = ~v420;\n\tif (v421) goto L_0085;\n\tv423 = HutongGames.PlayMaker.FsmFloat::get_Value(this.screenY);\nL_0085:\n\tv427 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv429 = v427 == 0;\n\tif (v429) goto L_0092;\n\tv431 = UnityEngine.Screen::get_width();\n\tv433 = v236 * v431;\n\tv436 = UnityEngine.Screen::get_height();\n\tv171 = v171 * v436;\nL_0092:\n\tv268 = UnityEngine.Camera::get_main();\n\tv285 = &v164 @ stack_-98;\n\t// 154 MakeStruct v166 @ AGGB25E30_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v236 @ V9_v7 (UnityEngine.Vector3), v171 @ V10_v8 (System.Single), v230 @ V8_v6 (System.Single)\n\tv440 = UnityEngine.Camera::ScreenPointToRay(v268, v166);\n\tv164 = *([v285 @ X8_v9]);\n\tv443 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv447 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v443);\n\tgoto L_00C4;\n\tv455 = *([v451 @ X8_v12+E0]);\n\tv456 = v455 == 0;\n\tv457 = ~v456;\n\tif (v457) goto L_00C4;\n\tv471 = v451;\n\tv460 = \"il2cpp_codegen_runtime_class_init\"(v471, v444, v446, v33, v34, v35, v36, v37, v249, v243, v240, v41, v42, v43, v44, v45);\nL_00C4:\n\tv470 = UnityEngine.Physics2D::GetRayIntersection(&v164 @ stack_-98, Infinityf, v447);\n\tv139 = v470.m_Centroid;\n\tv475 = 0x16415C8(&v139 @ stack_-C0_v4 (UnityEngine.Vector2), 0, 0, v33, v34, v35, v36, v37, v470.m_Normal, v470.m_Centroid, v230, v41, v42, v43, v44, v45);\n\tgoto L_00E6;\n\tv480 = *([v476 @ X8_v17+E0]);\n\tv481 = v480 == 0;\n\tv482 = ~v481;\n\tif (v482) goto L_00E6;\n\tv487 = v476;\n\tv484 = \"il2cpp_codegen_runtime_class_init\"(v487, v474, v469, v33, v34, v35, v36, v37, v250, v244, v240, v41, v42, v43, v44, v45);\nL_00E6:\n\tv385 = UnityEngine.Object::op_Inequality(v475, 0);\n\tv286 = this.storeDidPickObject;\n\tv286.value = v385;\n\tv489 = v385 == 0;\n\tif (v489) goto L_011F;\n\tv270 = 0x16415C8(&v139 @ stack_-C0_v4 (UnityEngine.Vector2), 0, 0, v33, v34, v35, v36, v37, v470.m_Normal, v470.m_Centroid, v230, v41, v42, v43, v44, v45);\n\tv386 = UnityEngine.Component::get_gameObject(v270);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeGameObject, v386);\n\tv192 = this.storePoint;\n\tv505 = 0x16415A8(&v139 @ stack_-C0_v4 (UnityEngine.Vector2), 0, 0, v33, v34, v35, v36, v37, v470.m_Normal, v470.m_Centroid, v230, v41, v42, v43, v44, v45);\n\tgoto L_0112;\n\tv512 = *([v508 @ X0_v55+E0]);\n\tv513 = v512 == 0;\n\tv514 = ~v513;\n\tif (v514) goto L_0112;\n\tv516 = \"il2cpp_codegen_runtime_class_init\"(v508, v381, v377, v33, v34, v35, v36, v37, v250, v244, v240, v41, v42, v43, v44, v45);\nL_0112:\n\t// 274 MakeStruct v368 @ AGGB25F80_0_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v470.m_Normal (UnityEngine.Vector2), v470.m_Centroid (UnityEngine.Vector2)\n\tv179 = UnityEngine.Vector2::op_Implicit(v368);\n\tv177 = v179.y;\n\tv175 = v179.z;\n\tv520 = this.storePoint == 0;\n\tv391 = ~v520;\n\tif (v391) goto L_0131;\n\tgoto L_0141;\nL_011F:\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeGameObject, 0);\n\tv192 = this.storePoint;\n\tgoto L_012C;\n\tv497 = *([v493 @ X0_v45+E0]);\n\tv498 = v497 == 0;\n\tv499 = ~v498;\n\tif (v499) goto L_012C;\n\tv501 = \"il2cpp_codegen_runtime_class_init\"(v493, v382, v378, v33, v34, v35, v36, v37, v250, v244, v240, v41, v42, v43, v44, v45);\nL_012C:\n\tv179 = UnityEngine.Vector3::get_zero();\n\tv177 = v179.y;\n\tv175 = v179.z;\nL_0131:\n\tv192.value = v179;\n\tv192.value.y = v177;\n\tv192.value.z = v175;\nL_013E:\n\treturn;\n\tthrow System.NullReferenceException;\nL_0141:\n\tthrow System.NullReferenceException;\n// 209 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void DoScreenPick()
		{
			//IL_013b: Expected O, but got F4
			//IL_0203: Expected O, but got F4
			//IL_0298: Expected O, but got Ref
			Camera main = Camera.main;
			if (main == null)
			{
				LogError("No MainCamera defined!");
				Finish();
				return;
			}
			Vector3 zero = Vector3.zero;
			bool isNone = screenVector.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			float z = zero.z;
			float num = zero.y;
			Vector3 vector = zero;
			if (!flag2)
			{
				Vector3 value = screenVector.Value;
				z = value.z;
				num = value.y;
				vector = value;
			}
			if (!screenX.IsNone)
			{
				float value2 = screenX.Value;
				vector = (Vector3)value2;
			}
			if (!screenY.IsNone)
			{
				float value3 = screenY.Value;
				num = value3;
			}
			if (normalized.Value)
			{
				int width = Screen.width;
				float num2 = vector.x * (float)width;
				int height = Screen.height;
				num *= (float)height;
				vector = (Vector3)num2;
			}
			Camera main2 = Camera.main;
			object obj2 = default(object);
			object obj = obj2;
			Vector3 pos = default(Vector3);
			pos.x = vector.x;
			pos.y = num;
			pos.z = z;
			Ray ray = main2.ScreenPointToRay(pos);
			obj2 = obj;
			bool value4 = invertMask.Value;
			int num3 = ActionHelpers.LayerArrayToLayerMask(layerMask, value4);
			RaycastHit2D rayIntersection = Physics2D.GetRayIntersection((Ray)(&obj2), float.PositiveInfinity, num3);
			Vector2 centroid = rayIntersection.m_Centroid;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415C8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0xA0)");
			UnityEngine.Object obj3 = default(UnityEngine.Object);
			bool flag3 = obj3 != null;
			FsmBool fsmBool = storeDidPickObject;
			fsmBool.value = flag3;
			FsmVector3 fsmVector;
			Vector3 value5;
			float y;
			float z2;
			if (flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415C8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0xA0)");
				Component component = default(Component);
				GameObject gameObject = component.gameObject;
				storeGameObject.Value = gameObject;
				fsmVector = storePoint;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415A8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x80)");
				Vector2 vector2 = default(Vector2);
				vector2.x = rayIntersection.m_Normal.x;
				vector2.y = rayIntersection.m_Centroid.x;
				value5 = vector2;
				y = value5.y;
				z2 = value5.z;
				if (storePoint == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				storeGameObject.Value = null;
				fsmVector = storePoint;
				value5 = Vector3.zero;
				y = value5.y;
				z2 = value5.z;
			}
			fsmVector.value = value5;
			fsmVector.value.y = y;
			fsmVector.value.z = z2;
		}

		[Token(Token = "0x6000E10")]
		[Address(RVA = "0xB25FFC", Offset = "0xB25FFC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ScreenPick2d()
		{
		}
	}
}
