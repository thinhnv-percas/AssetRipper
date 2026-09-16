using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758114", Offset = "0x758114")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758114", Offset = "0x758114")]
	[Token(Token = "0x2000248")]
	public class ScreenPick : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4500", Offset = "0x7B4500")]
		[Token(Token = "0x40015A7")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 screenVector;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4538", Offset = "0x7B4538")]
		[Token(Token = "0x40015A8")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat screenX;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4570", Offset = "0x7B4570")]
		[Token(Token = "0x40015A9")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat screenY;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B45A8", Offset = "0x7B45A8")]
		[Token(Token = "0x40015AA")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool normalized;

		[RequiredField]
		[Token(Token = "0x40015AB")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat rayDistance;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B45F0", Offset = "0x7B45F0")]
		[Token(Token = "0x40015AC")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool storeDidPickObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B4604", Offset = "0x7B4604")]
		[Token(Token = "0x40015AD")]
		[FieldOffset(Offset = "0x80")]
		public FsmGameObject storeGameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B4618", Offset = "0x7B4618")]
		[Token(Token = "0x40015AE")]
		[FieldOffset(Offset = "0x88")]
		public FsmVector3 storePoint;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B462C", Offset = "0x7B462C")]
		[Token(Token = "0x40015AF")]
		[FieldOffset(Offset = "0x90")]
		public FsmVector3 storeNormal;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B4640", Offset = "0x7B4640")]
		[Token(Token = "0x40015B0")]
		[FieldOffset(Offset = "0x98")]
		public FsmFloat storeDistance;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B4654", Offset = "0x7B4654")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4654", Offset = "0x7B4654")]
		[Token(Token = "0x40015B1")]
		[FieldOffset(Offset = "0xA0")]
		public FsmInt[] layerMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B46A4", Offset = "0x7B46A4")]
		[Token(Token = "0x40015B2")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool invertMask;

		[Token(Token = "0x40015B3")]
		[FieldOffset(Offset = "0xB0")]
		public bool everyFrame;

		[Token(Token = "0x6000B71")]
		[Address(RVA = "0xB255F8", Offset = "0xB255F8", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EBE828]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20225D7]) = v42;\nL_0018:\n\tv46 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.screenVector = v46;\n\tv54 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v54);\n\tv54.useVariable = 1;\n\tthis.screenX = v54;\n\tv61 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v61);\n\tv61.useVariable = 1;\n\tthis.screenY = v61;\n\tv95 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.normalized = v95;\n\tv99 = HutongGames.PlayMaker.FsmFloat::op_Implicit(100f);\n\tthis.rayDistance = v99;\n\tthis.storeDistance = 0;\n\tthis.storePoint = 0;\n\tthis.storeDidPickObject = 0;\n\t// 71 NewArr v103 @ X0_v16 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v103;\n\tv81 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v81;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			normalized = fsmBool;
			FsmFloat fsmFloat3 = 100f;
			rayDistance = fsmFloat3;
			storeDistance = null;
			storePoint = null;
			storeDidPickObject = null;
			FsmInt[] array = new FsmInt[0];
			layerMask = array;
			FsmBool fsmBool2 = false;
			invertMask = fsmBool2;
			everyFrame = false;
		}

		[Token(Token = "0x6000B72")]
		[Address(RVA = "0xB25720", Offset = "0xB25720", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ScreenPick::DoScreenPick(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoScreenPick();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000B73")]
		[Address(RVA = "0xB25AEC", Offset = "0xB25AEC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ScreenPick::DoScreenPick(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoScreenPick();
		}

		[Token(Token = "0x6000B74")]
		[Address(RVA = "0xB2575C", Offset = "0xB2575C", Length = "0x390")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EF5978]);\n\tv29 = *([v28 @ X8_v23]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20225D8]) = v48;\nL_001C:\n\tv53 = 0;\n\tv55 = UnityEngine.Camera::get_main();\n\tgoto L_0030;\n\tv63 = *([v59 @ X8_v3+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0030;\n\tv74 = v59;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v32, v33, v34, v35, v36, v37, v49, v39, v40, v41, v42, v43, v44, v45);\nL_0030:\n\tv73 = UnityEngine.Object::op_Equality(v55, 0);\n\tv76 = v73 == 0;\n\tif (v76) goto L_0044;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"No MainCamera defined!\");\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tgoto L_0131;\nL_0044:\n\tgoto L_004B;\n\tv90 = *([v84 @ X0_v8+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_004B;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v84, v71, v72, v33, v34, v35, v36, v37, v49, v39, v40, v41, v42, v43, v44, v45);\nL_004B:\n\tv98 = UnityEngine.Vector3::get_zero();\n\tv174 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenVector);\n\tv301 = v174 == 0;\n\tv302 = ~v301;\n\tif (v302) goto L_0068;\n\tv347 = HutongGames.PlayMaker.FsmVector3::get_Value(this.screenVector);\nL_0068:\n\tv351 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenX);\n\tv353 = v351 == 0;\n\tv354 = ~v353;\n\tif (v354) goto L_0077;\n\tv356 = HutongGames.PlayMaker.FsmFloat::get_Value(this.screenX);\nL_0077:\n\tv360 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenY);\n\tv362 = v360 == 0;\n\tv363 = ~v362;\n\tif (v363) goto L_0086;\n\tv365 = HutongGames.PlayMaker.FsmFloat::get_Value(this.screenY);\nL_0086:\n\tv369 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv371 = v369 == 0;\n\tif (v371) goto L_0093;\n\tv373 = UnityEngine.Screen::get_width();\n\tv375 = v192 * v373;\n\tv378 = UnityEngine.Screen::get_height();\n\tv138 = v138 * v378;\nL_0093:\n\tv224 = UnityEngine.Camera::get_main();\n\t// 155 MakeStruct v133 @ AGGB25924_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v192 @ V9_v7 (UnityEngine.Vector3), v138 @ V10_v8 (System.Single), v186 @ V8_v6 (System.Single)\n\tv382 = UnityEngine.Camera::ScreenPointToRay(v224, v133);\n\tv130 = v382.m_Origin;\n\tv204 = HutongGames.PlayMaker.FsmFloat::get_Value(this.rayDistance);\n\tv385 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv389 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v385);\n\tv395 = UnityEngine.Physics::Raycast(&v130 @ stack_-98_v4 (UnityEngine.Vector3), &v53 @ stack_-80_v1 (UnityEngine.RaycastHit), v204, v389);\n\tv398 = 0x164C7C8(&v53 @ stack_-80_v1 (UnityEngine.RaycastHit), 0, v389, 0, v34, v35, v36, v37, v204, v138, v186, v41, v42, v43, v44, v45);\n\tgoto L_00CF;\n\tv403 = *([v399 @ X8_v11+E0]);\n\tv404 = v403 == 0;\n\tv405 = ~v404;\n\tif (v405) goto L_00CF;\n\tv410 = v399;\n\tv407 = \"il2cpp_codegen_runtime_class_init\"(v410, v397, v392, v110, v34, v35, v36, v37, v205, v198, v195, v41, v42, v43, v44, v45);\nL_00CF:\n\tv319 = UnityEngine.Object::op_Inequality(v398, 0);\n\tv244 = this.storeDidPickObject;\n\tv244.value = v319;\n\tv412 = v319 == 0;\n\tif (v412) goto L_0103;\n\tv227 = 0x164C7C8(&v53 @ stack_-80_v1 (UnityEngine.RaycastHit), 0, 0, 0, v34, v35, v36, v37, v204, v138, v186, v41, v42, v43, v44, v45);\n\tv320 = UnityEngine.Component::get_gameObject(v227);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeGameObject, v320);\n\tv338 = this.storeDistance;\n\tv321 = 0x164C890(&v53 @ stack_-80_v1 (UnityEngine.RaycastHit), 0, 0, 0, v34, v35, v36, v37, v204, v138, v186, v41, v42, v43, v44, v45);\n\tv338.value = v204;\n\tv339 = this.storePoint;\n\tv322 = 0x164C878(&v53 @ stack_-80_v1 (UnityEngine.RaycastHit), 0, 0, 0, v34, v35, v36, v37, v204, v138, v186, v41, v42, v43, v44, v45);\n\tv339.value = v204;\n\tv339.value.y = v138;\n\tv339.value.z = v186;\n\tv159 = this.storeNormal;\n\tv323 = 0x164C884(&v53 @ stack_-80_v1 (UnityEngine.RaycastHit), 0, 0, 0, v34, v35, v36, v37, v204, v138, v186, v41, v42, v43, v44, v45);\n\tv434 = this.storeNormal == 0;\n\tv330 = ~v434;\n\tif (v330) goto L_0124;\n\tgoto L_0134;\nL_0103:\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeGameObject, 0);\n\tv419 = HutongGames.PlayMaker.FsmFloat::op_Implicit(Infinityf);\n\tthis.storeDistance = v419;\n\tv340 = this.storePoint;\n\tgoto L_0115;\n\tv425 = *([v420 @ X0_v47+E0]);\n\tv426 = v425 == 0;\n\tv427 = ~v426;\n\tif (v427) goto L_0115;\n\tv429 = \"il2cpp_codegen_runtime_class_init\"(v420, v316, v310, v110, v34, v35, v36, v37, v417, v198, v195, v41, v42, v43, v44, v45);\nL_0115:\n\tv307 = UnityEngine.Vector3::get_zero();\n\tv340.value = v307;\n\tv340.value.y = v307.y;\n\tv340.value.z = v307.z;\n\tv159 = this.storeNormal;\n\tv146 = UnityEngine.Vector3::get_zero();\n\tv144 = v146.y;\n\tv142 = v146.z;\nL_0124:\n\tv159.value = v146;\n\tv159.value.y = v144;\n\tv159.value.z = v142;\nL_0131:\n\treturn;\n\tthrow System.NullReferenceException;\nL_0134:\n\tthrow System.NullReferenceException;\n// 198 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void DoScreenPick()
		{
			//IL_013b: Expected O, but got F4
			//IL_0203: Expected O, but got F4
			//IL_02a7: Expected O, but got Ref
			//IL_0382: Expected O, but got F4
			//IL_03ee: Expected O, but got F4
			RaycastHit hitInfo = default(RaycastHit);
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
			Vector3 pos = default(Vector3);
			pos.x = vector.x;
			pos.y = num;
			pos.z = z;
			Vector3 origin = main2.ScreenPointToRay(pos).m_Origin;
			float value4 = rayDistance.Value;
			bool value5 = invertMask.Value;
			int num3 = ActionHelpers.LayerArrayToLayerMask(layerMask, value5);
			bool flag3 = Physics.Raycast((Ray)(&origin), out hitInfo, value4, num3);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C7C8 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x150)");
			UnityEngine.Object obj = default(UnityEngine.Object);
			bool flag4 = obj != null;
			FsmBool fsmBool = storeDidPickObject;
			fsmBool.value = flag4;
			FsmVector3 fsmVector2;
			float z2;
			float y;
			Vector3 value6;
			if (flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C7C8 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x150)");
				Component component = default(Component);
				GameObject gameObject = component.gameObject;
				storeGameObject.Value = gameObject;
				FsmFloat fsmFloat = storeDistance;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C890 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x218)");
				fsmFloat.Value = value4;
				FsmVector3 fsmVector = storePoint;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C878 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x200)");
				fsmVector.value = (Vector3)value4;
				fsmVector.value.y = num;
				fsmVector.value.z = z;
				fsmVector2 = storeNormal;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C884 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x20C)");
				bool flag5 = storeNormal == null;
				bool flag6 = !flag5;
				z2 = z;
				y = num;
				value6 = (Vector3)value4;
				if (!flag6)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				storeGameObject.Value = null;
				FsmFloat fsmFloat2 = float.PositiveInfinity;
				storeDistance = fsmFloat2;
				FsmVector3 fsmVector3 = storePoint;
				Vector3 vector2 = (fsmVector3.value = Vector3.zero);
				fsmVector3.value.y = vector2.y;
				fsmVector3.value.z = vector2.z;
				fsmVector2 = storeNormal;
				value6 = Vector3.zero;
				y = value6.y;
				z2 = value6.z;
			}
			fsmVector2.value = value6;
			fsmVector2.value.y = y;
			fsmVector2.value.z = z2;
		}

		[Token(Token = "0x6000B75")]
		[Address(RVA = "0xB25AF0", Offset = "0xB25AF0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmFloat::op_Implicit(100f);\n\tthis.rayDistance = v13;\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ScreenPick()
		{
			FsmFloat fsmFloat = 100f;
			rayDistance = fsmFloat;
		}
	}
}
