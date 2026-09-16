using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A70C", Offset = "0x75A70C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75A70C", Offset = "0x75A70C")]
	[Token(Token = "0x20002BD")]
	public class GetNextOverlapArea2d : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BC6A4", Offset = "0x7BC6A4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC6A4", Offset = "0x7BC6A4")]
		[Token(Token = "0x40017D3")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault firstCornerGameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC704", Offset = "0x7BC704")]
		[Token(Token = "0x40017D4")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 firstCornerPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC73C", Offset = "0x7BC73C")]
		[Token(Token = "0x40017D5")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject secondCornerGameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC774", Offset = "0x7BC774")]
		[Token(Token = "0x40017D6")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector2 secondCornerPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC7AC", Offset = "0x7BC7AC")]
		[Token(Token = "0x40017D7")]
		[FieldOffset(Offset = "0x70")]
		public FsmInt minDepth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC7E4", Offset = "0x7BC7E4")]
		[Token(Token = "0x40017D8")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt maxDepth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC81C", Offset = "0x7BC81C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BC81C", Offset = "0x7BC81C")]
		[Token(Token = "0x40017D9")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool resetFlag;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BC86C", Offset = "0x7BC86C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BC86C", Offset = "0x7BC86C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC86C", Offset = "0x7BC86C")]
		[Token(Token = "0x40017DA")]
		[FieldOffset(Offset = "0x88")]
		public FsmInt[] layerMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC8E0", Offset = "0x7BC8E0")]
		[Token(Token = "0x40017DB")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool invertMask;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BC918", Offset = "0x7BC918")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC918", Offset = "0x7BC918")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BC918", Offset = "0x7BC918")]
		[Token(Token = "0x40017DC")]
		[FieldOffset(Offset = "0x98")]
		public FsmInt collidersCount;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BC98C", Offset = "0x7BC98C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC98C", Offset = "0x7BC98C")]
		[Token(Token = "0x40017DD")]
		[FieldOffset(Offset = "0xA0")]
		public FsmGameObject storeNextCollider;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC9EC", Offset = "0x7BC9EC")]
		[Token(Token = "0x40017DE")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent loopEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCA24", Offset = "0x7BCA24")]
		[Token(Token = "0x40017DF")]
		[FieldOffset(Offset = "0xB0")]
		public FsmEvent finishedEvent;

		[Token(Token = "0x40017E0")]
		[FieldOffset(Offset = "0xB8")]
		private Collider2D[] colliders;

		[Token(Token = "0x40017E1")]
		[FieldOffset(Offset = "0xC0")]
		private int colliderCount;

		[Token(Token = "0x40017E2")]
		[FieldOffset(Offset = "0xC4")]
		private int nextColliderIndex;

		[Token(Token = "0x6000DB7")]
		[Address(RVA = "0xA30D7C", Offset = "0xA30D7C", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EADFE8]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DF1]) = v42;\nL_0015:\n\tthis.firstCornerGameObject = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.firstCornerPosition = v46;\n\tthis.secondCornerGameObject = 0;\n\tv52 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.secondCornerPosition = v52;\n\tv62 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v62);\n\tv62.useVariable = 1;\n\tthis.minDepth = v62;\n\tv63 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v63);\n\tv63.useVariable = 1;\n\tthis.maxDepth = v63;\n\t// 69 NewArr v101 @ X0_v14 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v101;\n\tv85 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v85;\n\tthis.resetFlag = 0;\n\tthis.loopEvent = 0;\n\tthis.collidersCount = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			firstCornerGameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			firstCornerPosition = fsmVector;
			secondCornerGameObject = null;
			FsmVector2 fsmVector2 = new FsmVector2();
			fsmVector2.useVariable = true;
			secondCornerPosition = fsmVector2;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			minDepth = fsmInt;
			FsmInt fsmInt2 = new FsmInt();
			fsmInt2.useVariable = true;
			maxDepth = fsmInt2;
			FsmInt[] array = new FsmInt[0];
			layerMask = array;
			FsmBool fsmBool = false;
			invertMask = fsmBool;
			resetFlag = null;
			loopEvent = null;
			collidersCount = null;
		}

		[Token(Token = "0x6000DB8")]
		[Address(RVA = "0xA30EA0", Offset = "0xA30EA0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.colliders == 0;\n\tif (v11) goto L_0012;\n\tv18 = HutongGames.PlayMaker.FsmBool::get_Value(this.resetFlag);\n\tv20 = v18 == 0;\n\tif (v20) goto L_0022;\nL_0012:\n\tthis.nextColliderIndex = 0;\n\tv22 = HutongGames.PlayMaker.Actions.GetNextOverlapArea2d::GetOverlapAreaAll(this);\n\tthis.colliders = v22;\n\tv45 = this.collidersCount;\n\tthis.colliderCount = v22.Length;\n\tv45.value = v22.Length;\n\tv53 = this.resetFlag;\n\tv53.value = 0;\nL_0022:\n\tHutongGames.PlayMaker.Actions.GetNextOverlapArea2d::DoGetNextCollider(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (colliders == null || resetFlag.Value)
			{
				nextColliderIndex = 0;
				Collider2D[] array = (colliders = GetOverlapAreaAll());
				FsmInt fsmInt = collidersCount;
				colliderCount = array.Length;
				fsmInt.Value = array.Length;
				FsmBool fsmBool = resetFlag;
				fsmBool.value = false;
			}
			DoGetNextCollider();
			Finish();
		}

		[Token(Token = "0x6000DB9")]
		[Address(RVA = "0xA31234", Offset = "0xA31234", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.nextColliderIndex;\n\tv24 = this.nextColliderIndex >= this.colliderCount;\n\tif (v24) goto L_0048;\n\tv25 = this.colliders;\n\tv29 = this.nextColliderIndex < v25.Length;\n\tv30 = ~v29;\n\tif (v30) goto L_0061;\n\tv50 = UnityEngine.Component::get_gameObject(v25[v13 @ X8_v1 (System.Int32)]);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeNextCollider, v50);\n\tv110 = this.nextColliderIndex >= this.colliderCount;\n\tif (v110) goto L_004A;\n\tv164 = this.loopEvent;\n\tv158 = this.nextColliderIndex + 1;\n\tthis.nextColliderIndex = v158;\n\tv197 = this.loopEvent == 0;\n\tif (v197) goto L_005D;\n\tv166 = this.fsm;\n\tv214 = this.fsm == 0;\n\tv157 = ~v214;\n\tif (v157) goto L_0056;\n\tgoto L_005E;\nL_0048:\n\tv166 = this.fsm;\n\tgoto L_004C;\nL_004A:\n\tv166 = this.fsm;\n\tthis.colliders = 0;\nL_004C:\n\tthis.nextColliderIndex = 0;\n\tv164 = this.finishedEvent;\nL_0056:\n\tHutongGames.PlayMaker.Fsm::Event(v166, v164);\n\treturn;\nL_005D:\n\treturn;\nL_005E:\n\tthrow System.NullReferenceException;\n\tv85 = new System.NullReferenceException();\nL_0061:\n\tv152 = new System.IndexOutOfRangeException();\n\tthrow v152;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetNextCollider()
		{
			int num = nextColliderIndex;
			FsmEvent fsmEvent;
			Fsm fsm;
			if (nextColliderIndex < colliderCount)
			{
				Collider2D[] array = colliders;
				if (nextColliderIndex >= array.Length)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				GameObject gameObject = array[num].gameObject;
				storeNextCollider.Value = gameObject;
				if (nextColliderIndex < colliderCount)
				{
					fsmEvent = loopEvent;
					int num2 = nextColliderIndex + 1;
					nextColliderIndex = num2;
					if (loopEvent != null)
					{
						fsm = Fsm;
						if (Fsm == null)
						{
							throw new NullReferenceException();
						}
						goto IL_0179;
					}
					return;
				}
				fsm = Fsm;
				colliders = null;
			}
			else
			{
				fsm = Fsm;
			}
			nextColliderIndex = 0;
			fsmEvent = finishedEvent;
			goto IL_0179;
			IL_0179:
			fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000DBA")]
		[Address(RVA = "0xA30F28", Offset = "0xA30F28", Length = "0x30C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EE55A8]);\n\tv33 = *([v32 @ X8_v23]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021DF2]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.firstCornerGameObject);\n\tv153 = this.firstCornerPosition;\n\tv93 = v153.value.y;\n\tgoto L_0035;\n\tv188 = *([v185 @ X0_v9+E0]);\n\tv189 = v188 == 0;\n\tv190 = ~v189;\n\tif (v190) goto L_0035;\n\tv192 = \"il2cpp_codegen_runtime_class_init\"(v185, v55, v56, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0035:\n\tv172 = UnityEngine.Object::op_Inequality(v57, 0);\n\tv275 = v172 == 0;\n\tif (v275) goto L_0054;\n\tv117 = UnityEngine.GameObject::get_transform(v57);\n\tv83 = UnityEngine.Transform::get_position(v117);\n\tv118 = UnityEngine.GameObject::get_transform(v57);\n\tv96 = v153.value + v83;\n\tv278 = UnityEngine.Transform::get_position(v118);\n\tv93 = v93 + v278.y;\nL_0054:\n\tv173 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.secondCornerGameObject);\n\tv180 = this.secondCornerPosition;\n\tv70 = v180.value.y;\n\tgoto L_0068;\n\tv290 = *([v286 @ X0_v16+E0]);\n\tv291 = v290 == 0;\n\tv292 = ~v291;\n\tif (v292) goto L_0068;\n\tv294 = \"il2cpp_codegen_runtime_class_init\"(v286, v169, v100, v37, v38, v39, v40, v41, v84, v79, v74, v45, v46, v47, v48, v49);\nL_0068:\n\tv174 = UnityEngine.Object::op_Inequality(v173, 0);\n\tv298 = v174 == 0;\n\tif (v298) goto L_0087;\n\tv119 = UnityEngine.GameObject::get_transform(v173);\n\tv85 = UnityEngine.Transform::get_position(v119);\n\tv120 = UnityEngine.GameObject::get_transform(v173);\n\tv66 = v180.value + v85;\n\tv303 = UnityEngine.Transform::get_position(v120);\n\tv70 = v70 + v303.y;\nL_0087:\n\tv308 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.minDepth);\n\tv310 = v308 == 0;\n\tif (v310) goto L_00C5;\n\tv313 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxDepth);\n\tv315 = v313 == 0;\n\tif (v315) goto L_00C5;\n\tv325 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv333 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v325);\n\tgoto L_00BD;\n\tv343 = *([v266 @ X8_v18+E0]);\n\tv344 = v343 == 0;\n\tv345 = ~v344;\n\tif (v345) goto L_00BD;\n\tv351 = v266;\n\tv347 = \"il2cpp_codegen_runtime_class_init\"(v351, v331, v251, v37, v38, v39, v40, v41, v86, v81, v76, v45, v46, v47, v48, v49);\nL_00BD:\n\t// 189 MakeStruct v209 @ AGGA31134_0_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v96 @ V9_v4 (System.Single), v93 @ V8_v4 (System.Single)\n\t// 190 MakeStruct v206 @ AGGA31134_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v66 @ V11_v4 (System.Single), v70 @ V10_v5 (System.Single)\n\treturnVal2 = UnityEngine.Physics2D::OverlapAreaAll(v209, v206, v333);\n\treturn returnVal2;\nL_00C5:\n\tv317 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.minDepth);\n\tv320 = v317 == 0;\n\tif (v320) goto L_00D0;\n\tgoto L_00D6;\nL_00D0:\n\tv329 = HutongGames.PlayMaker.FsmInt::get_Value(this.minDepth);\nL_00D6:\n\tv334 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxDepth);\n\tv342 = v334 == 0;\n\tif (v342) goto L_00E1;\n\tgoto L_00E8;\nL_00E1:\n\tv355 = HutongGames.PlayMaker.FsmInt::get_Value(this.maxDepth);\nL_00E8:\n\tv359 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv362 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v359);\n\tgoto L_010F;\n\tv369 = *([v267 @ X8_v13+E0]);\n\tv370 = v369 == 0;\n\tv371 = ~v370;\n\tif (v371) goto L_010F;\n\tv375 = v267;\n\tv373 = \"il2cpp_codegen_runtime_class_init\"(v375, v360, v252, v37, v38, v39, v40, v41, v86, v81, v76, v45, v46, v47, v48, v49);\nL_010F:\n\t// 271 MakeStruct v200 @ AGGA31224_0_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v96 @ V9_v4 (System.Single), v93 @ V8_v4 (System.Single)\n\t// 272 MakeStruct v197 @ AGGA31224_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v66 @ V11_v4 (System.Single), v70 @ V10_v5 (System.Single)\n\treturnVal3 = UnityEngine.Physics2D::OverlapAreaAll(v200, v197, v362, v63, v59);\n\treturn returnVal3;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 192 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Collider2D[] GetOverlapAreaAll()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(firstCornerGameObject);
			FsmVector2 fsmVector = firstCornerPosition;
			float num = fsmVector.value.y;
			bool flag = ownerDefaultTarget != null;
			bool flag2 = !flag;
			float x = fsmVector.value.x;
			if (!flag2)
			{
				Transform transform = ownerDefaultTarget.transform;
				Vector3 position = transform.position;
				Transform transform2 = ownerDefaultTarget.transform;
				x = fsmVector.value.x + position.x;
				num += transform2.position.y;
			}
			GameObject value = secondCornerGameObject.Value;
			FsmVector2 fsmVector2 = secondCornerPosition;
			float num2 = fsmVector2.value.y;
			bool flag3 = value != null;
			bool flag4 = !flag3;
			float x2 = fsmVector2.value.x;
			if (!flag4)
			{
				Transform transform3 = value.transform;
				Vector3 position2 = transform3.position;
				Transform transform4 = value.transform;
				x2 = fsmVector2.value.x + position2.x;
				num2 += transform4.position.y;
			}
			if (minDepth.IsNone && maxDepth.IsNone)
			{
				bool value2 = invertMask.Value;
				int num3 = ActionHelpers.LayerArrayToLayerMask(layerMask, value2);
				Vector2 pointA = default(Vector2);
				pointA.x = x;
				pointA.y = num;
				Vector2 pointB = default(Vector2);
				pointB.x = x2;
				pointB.y = num2;
				return Physics2D.OverlapAreaAll(pointA, pointB, num3);
			}
			float num4;
			if (minDepth.IsNone)
			{
				num4 = float.NegativeInfinity;
			}
			else
			{
				int value3 = minDepth.Value;
				num4 = value3;
			}
			float num5;
			if (maxDepth.IsNone)
			{
				num5 = float.PositiveInfinity;
			}
			else
			{
				int value4 = maxDepth.Value;
				num5 = value4;
			}
			bool value5 = invertMask.Value;
			int num6 = ActionHelpers.LayerArrayToLayerMask(layerMask, value5);
			Vector2 pointA2 = default(Vector2);
			pointA2.x = x;
			pointA2.y = num;
			Vector2 pointB2 = default(Vector2);
			pointB2.x = x2;
			pointB2.y = num2;
			return Physics2D.OverlapAreaAll(pointA2, pointB2, num6, num4, num5);
		}

		[Token(Token = "0x6000DBB")]
		[Address(RVA = "0xA31310", Offset = "0xA31310", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetNextOverlapArea2d()
		{
		}
	}
}
