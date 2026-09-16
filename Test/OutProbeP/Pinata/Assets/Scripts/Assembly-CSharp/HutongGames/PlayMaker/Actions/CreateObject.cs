using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755DB0", Offset = "0x755DB0")]
	[Attribute(Type = typeof(ActionTarget), RVA = "0x755DB0", Offset = "0x755DB0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755DB0", Offset = "0x755DB0")]
	[Token(Token = "0x20001DB")]
	public class CreateObject : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B047C", Offset = "0x7B047C")]
		[Token(Token = "0x4001427")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B04C8", Offset = "0x7B04C8")]
		[Token(Token = "0x4001428")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject spawnPoint;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B0500", Offset = "0x7B0500")]
		[Token(Token = "0x4001429")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 position;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B0538", Offset = "0x7B0538")]
		[Token(Token = "0x400142A")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 rotation;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B0570", Offset = "0x7B0570")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B0570", Offset = "0x7B0570")]
		[Token(Token = "0x400142B")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject storeObject;

		[Token(Token = "0x60009DB")]
		[Address(RVA = "0xA93410", Offset = "0xA93410", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED8D78]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022207]) = v42;\nL_0015:\n\tthis.gameObject = 0;\n\tthis.spawnPoint = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.position = v46;\n\tv52 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.rotation = v52;\n\tthis.storeObject = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60009DC")]
		[Address(RVA = "0xA934B0", Offset = "0xA934B0", Length = "0x348")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv38 = *([1EBCE40]);\n\tv39 = *([v38 @ X8_v31]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2022208]) = v58;\nL_0021:\n\tv62 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tgoto L_0033;\n\tv255 = *([v194 @ X8_v5+E0]);\n\tv256 = v255 == 0;\n\tv257 = ~v256;\n\tif (v257) goto L_0033;\n\tv263 = v194;\n\tv259 = \"il2cpp_codegen_runtime_class_init\"(v263, v61, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0033:\n\tv262 = UnityEngine.Object::op_Inequality(v62, 0);\n\tv265 = v262 == 0;\n\tif (v265) goto L_012E;\n\tgoto L_0044;\n\tv348 = *([v331 @ X0_v14+E0]);\n\tv349 = v348 == 0;\n\tv350 = ~v349;\n\tif (v350) goto L_0044;\n\tv352 = \"il2cpp_codegen_runtime_class_init\"(v331, v142, v133, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0044:\n\tv355 = UnityEngine.Vector3::get_zero();\n\tv125 = UnityEngine.Vector3::get_zero();\n\tv360 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.spawnPoint);\n\tgoto L_0065;\n\tv364 = *([v187 @ X8_v9+E0]);\n\tv365 = v364 == 0;\n\tv366 = ~v365;\n\tif (v366) goto L_0065;\n\tv372 = v187;\n\tv368 = \"il2cpp_codegen_runtime_class_init\"(v372, v359, v133, v43, v44, v45, v46, v47, v125, v119, v113, v51, v52, v53, v54, v55);\nL_0065:\n\tv371 = UnityEngine.Object::op_Inequality(v360, 0);\n\tv374 = v371 == 0;\n\tif (v374) goto L_00C3;\n\tv158 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.spawnPoint);\n\tv159 = UnityEngine.GameObject::get_transform(v158);\n\tv126 = UnityEngine.Transform::get_position(v159);\n\tv434 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.position);\n\tv450 = v434 == 0;\n\tv451 = ~v450;\n\tif (v451) goto L_00AB;\n\tv499 = HutongGames.PlayMaker.FsmVector3::get_Value(this.position);\n\tgoto L_00A1;\n\tv507 = *([v502 @ X0_v55+E0]);\n\tv508 = v507 == 0;\n\tv509 = ~v508;\n\tif (v509) goto L_00A1;\n\tv511 = \"il2cpp_codegen_runtime_class_init\"(v502, v475, v134, v43, v44, v45, v46, v47, v499, v500, v501, v51, v52, v53, v54, v55);\nL_00A1:\n\tv474 = UnityEngine.Vector3::op_Addition(v126, v499);\nL_00AB:\n\tv394 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rotation);\n\tv396 = v394 == 0;\n\tif (v396) goto L_00DF;\n\tv163 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.spawnPoint);\n\tv164 = UnityEngine.GameObject::get_transform(v163);\n\tv419 = UnityEngine.Transform::get_eulerAngles(v164);\n\tv417 = v419.y;\n\tv415 = v419.z;\n\tgoto L_FFFFFFFF;\nL_00C3:\n\tv375 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.position);\n\tv377 = v375 == 0;\n\tv378 = ~v377;\n\tif (v378) goto L_00D6;\n\tv384 = HutongGames.PlayMaker.FsmVector3::get_Value(this.position);\nL_00D6:\n\tv389 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rotation);\n\tv391 = v389 == 0;\n\tv392 = ~v391;\n\tif (v392) goto L_00EB;\nL_00DF:\n\tv419 = HutongGames.PlayMaker.FsmVector3::get_Value(this.rotation);\n\tv417 = v419.y;\n\tv415 = v419.z;\nL_00EB:\n\tgoto L_00F5;\n\tv437 = *([v430 @ X0_v24+E0]);\n\tv438 = v437 == 0;\n\tv439 = ~v438;\n\tgoto L_00F5;\n\tv441 = \"il2cpp_codegen_runtime_class_init\"(v430, v420, v134, v43, v44, v45, v46, v47, v418, v416, v414, v403, v401, v399, v54, v55);\nL_00F5:\n\t// 245 MakeStruct v210 @ AGGA9374C_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v409 @ V11_v6 (UnityEngine.Vector3), v407 @ V12_v6 (System.Single), v405 @ V13_v6 (System.Single)\n\tv448 = UnityEngine.Quaternion::Euler(v210);\n\tgoto L_0113;\n\tv488 = *([v457 @ X0_v27+E0]);\n\tv489 = v488 == 0;\n\tv490 = ~v489;\n\tif (v490) goto L_0113;\n\tv492 = \"il2cpp_codegen_runtime_class_init\"(v457, v420, v134, v43, v44, v45, v46, v47, v448, v454, v455, v456, v401, v399, v54, v55);\nL_0113:\n\t// 275 MakeStruct v203 @ AGGA937A4_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v233 @ V8_v6 (UnityEngine.Vector3), v231 @ V9_v6 (System.Single), v229 @ V10_v6 (System.Single)\n\tv247 = UnityEngine.Object::Instantiate(v62, v203, v448);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeObject, v247);\nL_012E:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 214 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject value = gameObject.Value;
			if (!(value != null))
			{
				goto IL_03c0;
			}
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
					goto IL_03c7;
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
					goto IL_0328;
				}
			}
			vector4 = rotation.Value;
			y2 = vector4.y;
			z2 = vector4.z;
			goto IL_03c7;
			IL_0328:
			Vector3 euler = default(Vector3);
			euler.x = vector5.x;
			euler.y = y3;
			euler.z = z3;
			Quaternion quaternion = Quaternion.Euler(euler);
			Vector3 vector7 = default(Vector3);
			vector7.x = vector6.x;
			vector7.y = y4;
			vector7.z = z4;
			GameObject value7 = Object.Instantiate(value, vector7, quaternion);
			storeObject.Value = value7;
			goto IL_03c0;
			IL_03c7:
			z3 = z2;
			y3 = y2;
			vector5 = vector4;
			z4 = z;
			y4 = y;
			vector6 = vector2;
			goto IL_0328;
			IL_03c0:
			Finish();
		}

		[Token(Token = "0x60009DD")]
		[Address(RVA = "0xA937F8", Offset = "0xA937F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CreateObject()
		{
		}
	}
}
