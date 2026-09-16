using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A75C", Offset = "0x75A75C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75A75C", Offset = "0x75A75C")]
	[Token(Token = "0x20002BE")]
	public class GetNextOverlapCircle2d : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BCA5C", Offset = "0x7BCA5C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCA5C", Offset = "0x7BCA5C")]
		[Token(Token = "0x40017E3")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault fromGameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCABC", Offset = "0x7BCABC")]
		[Token(Token = "0x40017E4")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 fromPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCAF4", Offset = "0x7BCAF4")]
		[Token(Token = "0x40017E5")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat radius;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCB2C", Offset = "0x7BCB2C")]
		[Token(Token = "0x40017E6")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt minDepth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCB64", Offset = "0x7BCB64")]
		[Token(Token = "0x40017E7")]
		[FieldOffset(Offset = "0x70")]
		public FsmInt maxDepth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCB9C", Offset = "0x7BCB9C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BCB9C", Offset = "0x7BCB9C")]
		[Token(Token = "0x40017E8")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool resetFlag;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BCBEC", Offset = "0x7BCBEC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BCBEC", Offset = "0x7BCBEC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCBEC", Offset = "0x7BCBEC")]
		[Token(Token = "0x40017E9")]
		[FieldOffset(Offset = "0x80")]
		public FsmInt[] layerMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCC60", Offset = "0x7BCC60")]
		[Token(Token = "0x40017EA")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool invertMask;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BCC98", Offset = "0x7BCC98")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCC98", Offset = "0x7BCC98")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BCC98", Offset = "0x7BCC98")]
		[Token(Token = "0x40017EB")]
		[FieldOffset(Offset = "0x90")]
		public FsmInt collidersCount;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BCD0C", Offset = "0x7BCD0C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCD0C", Offset = "0x7BCD0C")]
		[Token(Token = "0x40017EC")]
		[FieldOffset(Offset = "0x98")]
		public FsmGameObject storeNextCollider;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCD6C", Offset = "0x7BCD6C")]
		[Token(Token = "0x40017ED")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent loopEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCDA4", Offset = "0x7BCDA4")]
		[Token(Token = "0x40017EE")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent finishedEvent;

		[Token(Token = "0x40017EF")]
		[FieldOffset(Offset = "0xB0")]
		private Collider2D[] colliders;

		[Token(Token = "0x40017F0")]
		[FieldOffset(Offset = "0xB8")]
		private int colliderCount;

		[Token(Token = "0x40017F1")]
		[FieldOffset(Offset = "0xBC")]
		private int nextColliderIndex;

		[Token(Token = "0x6000DBC")]
		[Address(RVA = "0xA31318", Offset = "0xA31318", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC2060]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DF3]) = v42;\nL_0015:\n\tthis.fromGameObject = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.fromPosition = v46;\n\tv53 = HutongGames.PlayMaker.FsmFloat::op_Implicit(10f);\n\tthis.radius = v53;\n\tv62 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v62);\n\tv62.useVariable = 1;\n\tthis.minDepth = v62;\n\tv63 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v63);\n\tv63.useVariable = 1;\n\tthis.maxDepth = v63;\n\t// 63 NewArr v100 @ X0_v14 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v100;\n\tv85 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v85;\n\tthis.resetFlag = 0;\n\tthis.collidersCount = 0;\n\tthis.loopEvent = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			fromGameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			fromPosition = fsmVector;
			FsmFloat fsmFloat = 10f;
			radius = fsmFloat;
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
			collidersCount = null;
			loopEvent = null;
		}

		[Token(Token = "0x6000DBD")]
		[Address(RVA = "0xA31428", Offset = "0xA31428", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.colliders == 0;\n\tif (v11) goto L_0012;\n\tv18 = HutongGames.PlayMaker.FsmBool::get_Value(this.resetFlag);\n\tv20 = v18 == 0;\n\tif (v20) goto L_0022;\nL_0012:\n\tthis.nextColliderIndex = 0;\n\tv22 = HutongGames.PlayMaker.Actions.GetNextOverlapCircle2d::GetOverlapCircleAll(this);\n\tthis.colliders = v22;\n\tv45 = this.collidersCount;\n\tthis.colliderCount = v22.Length;\n\tv45.value = v22.Length;\n\tv53 = this.resetFlag;\n\tv53.value = 0;\nL_0022:\n\tHutongGames.PlayMaker.Actions.GetNextOverlapCircle2d::DoGetNextCollider(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (colliders == null || resetFlag.Value)
			{
				nextColliderIndex = 0;
				Collider2D[] array = (colliders = GetOverlapCircleAll());
				FsmInt fsmInt = collidersCount;
				colliderCount = array.Length;
				fsmInt.Value = array.Length;
				FsmBool fsmBool = resetFlag;
				fsmBool.value = false;
			}
			DoGetNextCollider();
			Finish();
		}

		[Token(Token = "0x6000DBE")]
		[Address(RVA = "0xA31744", Offset = "0xA31744", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.nextColliderIndex;\n\tv24 = this.nextColliderIndex >= this.colliderCount;\n\tif (v24) goto L_0048;\n\tv25 = this.colliders;\n\tv30 = this.nextColliderIndex < v25.Length;\n\tv31 = ~v30;\n\tif (v31) goto L_0065;\n\tv45 = UnityEngine.Component::get_gameObject(v25[v13 @ X8_v1 (System.Int32)]);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeNextCollider, v45);\n\tv90 = this.nextColliderIndex >= this.colliderCount;\n\tif (v90) goto L_0056;\n\tv154 = this.loopEvent;\n\tv134 = this.nextColliderIndex + 1;\n\tthis.nextColliderIndex = v134;\n\tv184 = this.loopEvent == 0;\n\tif (v184) goto L_0062;\n\tv156 = this.fsm;\n\tv227 = this.fsm == 0;\n\tv123 = ~v227;\n\tif (v123) goto L_0054;\n\tgoto L_005C;\nL_0048:\n\tv156 = this.fsm;\n\tthis.nextColliderIndex = 0;\n\tthis.colliders = 0;\nL_004D:\n\tv154 = this.finishedEvent;\nL_0054:\n\tHutongGames.PlayMaker.Fsm::Event(v156, v154);\n\treturn;\nL_0056:\n\tv156 = this.fsm;\n\tthis.colliders = 0;\n\tthis.nextColliderIndex = 0;\n\tv226 = this.fsm == 0;\n\tv88 = ~v226;\n\tif (v88) goto L_004D;\nL_005C:\n\tthrow System.NullReferenceException;\nL_0062:\n\treturn;\n\tv64 = new System.NullReferenceException();\nL_0065:\n\tv152 = new System.IndexOutOfRangeException();\n\tthrow v152;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetNextCollider()
		{
			int num = nextColliderIndex;
			FsmEvent fsmEvent;
			Fsm fsm;
			if (nextColliderIndex < colliderCount)
			{
				Collider2D[] array = colliders;
				if (nextColliderIndex < array.Length)
				{
					GameObject gameObject = array[num].gameObject;
					storeNextCollider.Value = gameObject;
					if (nextColliderIndex < colliderCount)
					{
						fsmEvent = loopEvent;
						int num2 = nextColliderIndex + 1;
						nextColliderIndex = num2;
						if (loopEvent == null)
						{
							return;
						}
						fsm = Fsm;
						if (Fsm != null)
						{
							goto IL_01bb;
						}
					}
					else
					{
						fsm = Fsm;
						colliders = null;
						nextColliderIndex = 0;
						if (Fsm != null)
						{
							goto IL_0151;
						}
					}
					throw new NullReferenceException();
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			fsm = Fsm;
			nextColliderIndex = 0;
			colliders = null;
			goto IL_0151;
			IL_01bb:
			fsm.Event(fsmEvent);
			return;
			IL_0151:
			fsmEvent = finishedEvent;
			goto IL_01bb;
		}

		[Token(Token = "0x6000DBF")]
		[Address(RVA = "0xA314B0", Offset = "0xA314B0", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1F0B188]);\n\tv29 = *([v28 @ X8_v20]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2021DF4]) = v48;\nL_001D:\n\tv53 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.fromGameObject);\n\tv131 = this.fromPosition;\n\tv76 = v131.value.y;\n\tgoto L_0033;\n\tv158 = *([v155 @ X0_v9+E0]);\n\tv159 = v158 == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_0033;\n\tv162 = \"il2cpp_codegen_runtime_class_init\"(v155, v51, v52, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0033:\n\tv146 = UnityEngine.Object::op_Inequality(v53, 0);\n\tv230 = v146 == 0;\n\tif (v230) goto L_0052;\n\tv99 = UnityEngine.GameObject::get_transform(v53);\n\tv70 = UnityEngine.Transform::get_position(v99);\n\tv100 = UnityEngine.GameObject::get_transform(v53);\n\tv79 = v131.value + v70;\n\tv233 = UnityEngine.Transform::get_position(v100);\n\tv76 = v76 + v233.y;\nL_0052:\n\tv240 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.minDepth);\n\tv242 = v240 == 0;\n\tif (v242) goto L_0092;\n\tv245 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxDepth);\n\tv247 = v245 == 0;\n\tif (v247) goto L_0092;\n\tv72 = HutongGames.PlayMaker.FsmFloat::get_Value(this.radius);\n\tv263 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv268 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v263);\n\tgoto L_008B;\n\tv282 = *([v221 @ X8_v16+E0]);\n\tv283 = v282 == 0;\n\tv284 = ~v283;\n\tif (v284) goto L_008B;\n\tv288 = v221;\n\tv286 = \"il2cpp_codegen_runtime_class_init\"(v288, v266, v206, v33, v34, v35, v36, v37, v72, v68, v65, v41, v42, v43, v44, v45);\nL_008B:\n\t// 139 MakeStruct v173 @ AGGA31638_0_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v79 @ V9_v4 (System.Single), v76 @ V8_v4 (System.Single)\n\treturnVal2 = UnityEngine.Physics2D::OverlapCircleAll(v173, v72, v268);\n\treturn returnVal2;\nL_0092:\n\tv249 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.minDepth);\n\tv252 = v249 == 0;\n\tif (v252) goto L_009D;\n\tgoto L_00A3;\nL_009D:\n\tv258 = HutongGames.PlayMaker.FsmInt::get_Value(this.minDepth);\nL_00A3:\n\tv260 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxDepth);\n\tv265 = v260 == 0;\n\tif (v265) goto L_00AE;\n\tgoto L_00B4;\nL_00AE:\n\tv280 = HutongGames.PlayMaker.FsmInt::get_Value(this.maxDepth);\nL_00B4:\n\tv73 = HutongGames.PlayMaker.FsmFloat::get_Value(this.radius);\n\tv291 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv294 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v291);\n\tgoto L_00DF;\n\tv301 = *([v222 @ X8_v11+E0]);\n\tv302 = v301 == 0;\n\tv303 = ~v302;\n\tif (v303) goto L_00DF;\n\tv307 = v222;\n\tv305 = \"il2cpp_codegen_runtime_class_init\"(v307, v292, v207, v33, v34, v35, v36, v37, v73, v68, v65, v41, v42, v43, v44, v45);\nL_00DF:\n\t// 223 MakeStruct v167 @ AGGA31734_0_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v79 @ V9_v4 (System.Single), v76 @ V8_v4 (System.Single)\n\treturnVal3 = UnityEngine.Physics2D::OverlapCircleAll(v167, v73, v294, v62, v57);\n\treturn returnVal3;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 161 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Collider2D[] GetOverlapCircleAll()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(fromGameObject);
			FsmVector2 fsmVector = fromPosition;
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
			if (minDepth.IsNone && maxDepth.IsNone)
			{
				float value = radius.Value;
				bool value2 = invertMask.Value;
				int num2 = ActionHelpers.LayerArrayToLayerMask(layerMask, value2);
				Vector2 point = default(Vector2);
				point.x = x;
				point.y = num;
				return Physics2D.OverlapCircleAll(point, value, num2);
			}
			float num3;
			if (minDepth.IsNone)
			{
				num3 = float.NegativeInfinity;
			}
			else
			{
				int value3 = minDepth.Value;
				num3 = value3;
			}
			float num4;
			if (maxDepth.IsNone)
			{
				num4 = float.PositiveInfinity;
			}
			else
			{
				int value4 = maxDepth.Value;
				num4 = value4;
			}
			float value5 = radius.Value;
			bool value6 = invertMask.Value;
			int num5 = ActionHelpers.LayerArrayToLayerMask(layerMask, value6);
			Vector2 point2 = default(Vector2);
			point2.x = x;
			point2.y = num;
			return Physics2D.OverlapCircleAll(point2, value5, num5, num3, num4);
		}

		[Token(Token = "0x6000DC0")]
		[Address(RVA = "0xA31828", Offset = "0xA31828", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetNextOverlapCircle2d()
		{
		}
	}
}
