using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755D60", Offset = "0x755D60")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755D60", Offset = "0x755D60")]
	[Token(Token = "0x20001DA")]
	public class CreateEmptyObject : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B034C", Offset = "0x7B034C")]
		[Token(Token = "0x4001422")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B0384", Offset = "0x7B0384")]
		[Token(Token = "0x4001423")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject spawnPoint;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B03BC", Offset = "0x7B03BC")]
		[Token(Token = "0x4001424")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 position;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B03F4", Offset = "0x7B03F4")]
		[Token(Token = "0x4001425")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 rotation;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B042C", Offset = "0x7B042C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B042C", Offset = "0x7B042C")]
		[Token(Token = "0x4001426")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject storeObject;

		[Token(Token = "0x60009D8")]
		[Address(RVA = "0xA92FC8", Offset = "0xA92FC8", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EEEFE0]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022205]) = v42;\nL_0015:\n\tthis.gameObject = 0;\n\tthis.spawnPoint = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.position = v46;\n\tv52 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.rotation = v52;\n\tthis.storeObject = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			spawnPoint = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			position = fsmVector;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			rotation = fsmVector2;
			storeObject = null;
		}

		[Token(Token = "0x60009D9")]
		[Address(RVA = "0xA93068", Offset = "0xA93068", Length = "0x3A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1EDFA38]);\n\tv37 = *([v36 @ X8_v33]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2022206]) = v56;\nL_0020:\n\tv60 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tgoto L_0030;\n\tv268 = *([v216 @ X8_v5+E0]);\n\tv269 = v268 == 0;\n\tv270 = ~v269;\n\tif (v270) goto L_0030;\n\tv276 = v216;\n\tv272 = \"il2cpp_codegen_runtime_class_init\"(v276, v59, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0030:\n\tv275 = UnityEngine.Vector3::get_zero();\n\tv147 = UnityEngine.Vector3::get_zero();\n\tv332 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.spawnPoint);\n\tgoto L_0053;\n\tv337 = *([v217 @ X8_v6+E0]);\n\tv338 = v337 == 0;\n\tv339 = ~v338;\n\tif (v339) goto L_0053;\n\tv345 = v217;\n\tv341 = \"il2cpp_codegen_runtime_class_init\"(v345, v331, v40, v41, v42, v43, v44, v45, v147, v139, v131, v49, v50, v51, v52, v53);\nL_0053:\n\tv344 = UnityEngine.Object::op_Inequality(v332, 0);\n\tv347 = v344 == 0;\n\tif (v347) goto L_00B1;\n\tv180 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.spawnPoint);\n\tv181 = UnityEngine.GameObject::get_transform(v180);\n\tv148 = UnityEngine.Transform::get_position(v181);\n\tv390 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.position);\n\tv396 = v390 == 0;\n\tv397 = ~v396;\n\tif (v397) goto L_0099;\n\tv441 = HutongGames.PlayMaker.FsmVector3::get_Value(this.position);\n\tgoto L_008F;\n\tv459 = *([v446 @ X0_v67+E0]);\n\tv460 = v459 == 0;\n\tv461 = ~v460;\n\tif (v461) goto L_008F;\n\tv463 = \"il2cpp_codegen_runtime_class_init\"(v446, v418, v87, v41, v42, v43, v44, v45, v441, v444, v445, v49, v50, v51, v52, v53);\nL_008F:\n\tv417 = UnityEngine.Vector3::op_Addition(v148, v441);\nL_0099:\n\tv367 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rotation);\n\tv369 = v367 == 0;\n\tif (v369) goto L_00CD;\n\tv185 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.spawnPoint);\n\tv186 = UnityEngine.GameObject::get_transform(v185);\n\tv383 = UnityEngine.Transform::get_eulerAngles(v186);\n\tv382 = v383.y;\n\tv381 = v383.z;\n\tgoto L_FFFFFFFF;\nL_00B1:\n\tv348 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.position);\n\tv350 = v348 == 0;\n\tv351 = ~v350;\n\tif (v351) goto L_00C4;\n\tv357 = HutongGames.PlayMaker.FsmVector3::get_Value(this.position);\nL_00C4:\n\tv362 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rotation);\n\tv364 = v362 == 0;\n\tv365 = ~v364;\n\tif (v365) goto L_00D7;\nL_00CD:\n\tv383 = HutongGames.PlayMaker.FsmVector3::get_Value(this.rotation);\n\tv382 = v383.y;\n\tv381 = v383.z;\nL_00D7:\n\tv394 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.storeObject);\n\tgoto L_00E5;\n\tv431 = *([v400 @ X0_v20+E0]);\n\tv432 = v431 == 0;\n\tv433 = ~v432;\n\tif (v433) goto L_00E5;\n\tv435 = \"il2cpp_codegen_runtime_class_init\"(v400, v393, v87, v41, v42, v43, v44, v45, v151, v143, v135, v85, v81, v77, v52, v53);\nL_00E5:\n\tv440 = UnityEngine.Object::op_Inequality(v60, 0);\n\tv443 = v440 == 0;\n\tif (v443) goto L_0101;\n\tgoto L_00F7;\n\tv467 = *([v451 @ X0_v39+E0]);\n\tv468 = v467 == 0;\n\tv469 = ~v468;\n\tif (v469) goto L_00F7;\n\tv471 = \"il2cpp_codegen_runtime_class_init\"(v451, v439, v239, v41, v42, v43, v44, v45, v151, v143, v135, v85, v81, v77, v52, v53);\nL_00F7:\n\tv257 = UnityEngine.Object::Instantiate(v60);\n\tgoto L_010D;\nL_0101:\n\tv458 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v458, \"EmptyObjectFromNull\");\n\tv481 = this.storeObject;\nL_010D:\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(v481, v226);\n\tgoto L_011B;\n\tv490 = *([v486 @ X0_v25+E0]);\n\tv491 = v490 == 0;\n\tv492 = ~v491;\n\tif (v492) goto L_011B;\n\tv494 = \"il2cpp_codegen_runtime_class_init\"(v486, v484, v485, v41, v42, v43, v44, v45, v151, v143, v135, v85, v81, v77, v52, v53);\nL_011B:\n\tv258 = UnityEngine.Object::op_Inequality(v226, 0);\n\tv498 = v258 == 0;\n\tif (v498) goto L_0147;\n\tv191 = UnityEngine.GameObject::get_transform(v226);\n\t// 298 MakeStruct v63 @ AGGA933AC_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v128 @ V8_v4 (UnityEngine.Vector3), v121 @ V9_v4 (System.Single), v114 @ V10_v4 (System.Single)\n\tUnityEngine.Transform::set_position(v191, v63);\n\tv192 = UnityEngine.GameObject::get_transform(v226);\n\t// 309 MakeStruct v499 @ AGGA933D0_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v108 @ V11_v4 (UnityEngine.Vector3), v103 @ V12_v4 (System.Single), v98 @ V13_v4 (System.Single)\n\tUnityEngine.Transform::set_eulerAngles(v192, v499);\nL_0147:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 228 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject value = this.gameObject.Value;
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			GameObject value2 = spawnPoint.Value;
			float z;
			float y;
			Vector3 vector2;
			Vector3 vector4;
			float y2;
			float z2;
			float z3;
			float y3;
			Vector3 vector5;
			float z4;
			float y4;
			Vector3 vector6;
			if (value2 != null)
			{
				GameObject value3 = spawnPoint.Value;
				Transform transform = value3.transform;
				Vector3 vector = transform.position;
				bool isNone = position.IsNone;
				bool flag = !isNone;
				bool flag2 = !flag;
				z = vector.z;
				y = vector.y;
				vector2 = vector;
				if (!flag2)
				{
					Vector3 value4 = position.Value;
					Vector3 vector3 = vector + value4;
					z = vector3.z;
					y = vector3.y;
					vector2 = vector3;
				}
				if (rotation.IsNone)
				{
					GameObject value5 = spawnPoint.Value;
					Transform transform2 = value5.transform;
					vector4 = transform2.eulerAngles;
					y2 = vector4.y;
					z2 = vector4.z;
					goto IL_046f;
				}
			}
			else
			{
				bool isNone2 = position.IsNone;
				bool flag3 = !isNone2;
				bool flag4 = !flag3;
				z = zero.z;
				y = zero.y;
				vector2 = zero;
				if (!flag4)
				{
					Vector3 value6 = position.Value;
					z = value6.z;
					y = value6.y;
					vector2 = value6;
				}
				bool isNone3 = rotation.IsNone;
				bool flag5 = !isNone3;
				bool flag6 = !flag5;
				z3 = zero2.z;
				y3 = zero2.y;
				vector5 = zero2;
				z4 = z;
				y4 = y;
				vector6 = vector2;
				if (flag6)
				{
					goto IL_02f8;
				}
			}
			vector4 = rotation.Value;
			y2 = vector4.y;
			z2 = vector4.z;
			goto IL_046f;
			IL_046f:
			z3 = z2;
			y3 = y2;
			vector5 = vector4;
			z4 = z;
			y4 = y;
			vector6 = vector2;
			goto IL_02f8;
			IL_02f8:
			GameObject value7 = storeObject.Value;
			FsmGameObject fsmGameObject;
			GameObject gameObject2;
			if (value != null)
			{
				GameObject gameObject = Object.Instantiate(value);
				fsmGameObject = storeObject;
				gameObject2 = gameObject;
			}
			else
			{
				GameObject gameObject3 = new GameObject("EmptyObjectFromNull");
				fsmGameObject = storeObject;
				gameObject2 = gameObject3;
			}
			fsmGameObject.Value = gameObject2;
			if (gameObject2 != null)
			{
				Transform transform3 = gameObject2.transform;
				Vector3 vector7 = default(Vector3);
				vector7.x = vector6.x;
				vector7.y = y4;
				vector7.z = z4;
				transform3.position = vector7;
				Transform transform4 = gameObject2.transform;
				Vector3 eulerAngles = default(Vector3);
				eulerAngles.x = vector5.x;
				eulerAngles.y = y3;
				eulerAngles.z = z3;
				transform4.eulerAngles = eulerAngles;
			}
			Finish();
		}

		[Token(Token = "0x60009DA")]
		[Address(RVA = "0xA93408", Offset = "0xA93408", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CreateEmptyObject()
		{
		}
	}
}
