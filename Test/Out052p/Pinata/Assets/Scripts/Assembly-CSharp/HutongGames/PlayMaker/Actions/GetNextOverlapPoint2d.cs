using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A7AC", Offset = "0x75A7AC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75A7AC", Offset = "0x75A7AC")]
	[Token(Token = "0x20002BF")]
	public class GetNextOverlapPoint2d : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BCDDC", Offset = "0x7BCDDC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCDDC", Offset = "0x7BCDDC")]
		[Token(Token = "0x40017F2")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCE3C", Offset = "0x7BCE3C")]
		[Token(Token = "0x40017F3")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 position;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCE74", Offset = "0x7BCE74")]
		[Token(Token = "0x40017F4")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt minDepth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCEAC", Offset = "0x7BCEAC")]
		[Token(Token = "0x40017F5")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt maxDepth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCEE4", Offset = "0x7BCEE4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BCEE4", Offset = "0x7BCEE4")]
		[Token(Token = "0x40017F6")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetFlag;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BCF34", Offset = "0x7BCF34")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BCF34", Offset = "0x7BCF34")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCF34", Offset = "0x7BCF34")]
		[Token(Token = "0x40017F7")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt[] layerMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCFA8", Offset = "0x7BCFA8")]
		[Token(Token = "0x40017F8")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool invertMask;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BCFE0", Offset = "0x7BCFE0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BCFE0", Offset = "0x7BCFE0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BCFE0", Offset = "0x7BCFE0")]
		[Token(Token = "0x40017F9")]
		[FieldOffset(Offset = "0x88")]
		public FsmInt collidersCount;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BD054", Offset = "0x7BD054")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD054", Offset = "0x7BD054")]
		[Token(Token = "0x40017FA")]
		[FieldOffset(Offset = "0x90")]
		public FsmGameObject storeNextCollider;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD0B4", Offset = "0x7BD0B4")]
		[Token(Token = "0x40017FB")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent loopEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD0EC", Offset = "0x7BD0EC")]
		[Token(Token = "0x40017FC")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishedEvent;

		[Token(Token = "0x40017FD")]
		[FieldOffset(Offset = "0xA8")]
		private Collider2D[] colliders;

		[Token(Token = "0x40017FE")]
		[FieldOffset(Offset = "0xB0")]
		private int colliderCount;

		[Token(Token = "0x40017FF")]
		[FieldOffset(Offset = "0xB4")]
		private int nextColliderIndex;

		[Token(Token = "0x6000DC1")]
		[Address(RVA = "0xA31830", Offset = "0xA31830", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECD970]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DF5]) = v42;\nL_0015:\n\tthis.gameObject = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.position = v46;\n\tv54 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v54);\n\tv54.useVariable = 1;\n\tthis.minDepth = v54;\n\tv61 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v61);\n\tv61.useVariable = 1;\n\tthis.maxDepth = v61;\n\t// 59 NewArr v96 @ X0_v12 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v96;\n\tv81 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v81;\n\tthis.resetFlag = 0;\n\tthis.loopEvent = 0;\n\tthis.collidersCount = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			position = fsmVector;
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

		[Token(Token = "0x6000DC2")]
		[Address(RVA = "0xA31934", Offset = "0xA31934", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.colliders == 0;\n\tif (v11) goto L_0012;\n\tv18 = HutongGames.PlayMaker.FsmBool::get_Value(this.resetFlag);\n\tv20 = v18 == 0;\n\tif (v20) goto L_0022;\nL_0012:\n\tthis.nextColliderIndex = 0;\n\tv22 = HutongGames.PlayMaker.Actions.GetNextOverlapPoint2d::GetOverlapPointAll(this);\n\tthis.colliders = v22;\n\tv45 = this.collidersCount;\n\tthis.colliderCount = v22.Length;\n\tv45.value = v22.Length;\n\tv53 = this.resetFlag;\n\tv53.value = 0;\nL_0022:\n\tHutongGames.PlayMaker.Actions.GetNextOverlapPoint2d::DoGetNextCollider(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (colliders == null || resetFlag.Value)
			{
				nextColliderIndex = 0;
				Collider2D[] array = (colliders = GetOverlapPointAll());
				FsmInt fsmInt = collidersCount;
				colliderCount = array.Length;
				fsmInt.Value = array.Length;
				FsmBool fsmBool = resetFlag;
				fsmBool.value = false;
			}
			DoGetNextCollider();
			Finish();
		}

		[Token(Token = "0x6000DC3")]
		[Address(RVA = "0xA31C14", Offset = "0xA31C14", Length = "0xDC")]
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
				GameObject value = array[num].gameObject;
				storeNextCollider.Value = value;
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

		[Token(Token = "0x6000DC4")]
		[Address(RVA = "0xA319BC", Offset = "0xA319BC", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EA6200]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021DF6]) = v46;\nL_001C:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv118 = this.position;\n\tv69 = v118.value.y;\n\tgoto L_0032;\n\tv144 = *([v141 @ X0_v9+E0]);\n\tv145 = v144 == 0;\n\tv146 = ~v145;\n\tif (v146) goto L_0032;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v141, v49, v50, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\tv132 = UnityEngine.Object::op_Inequality(v51, 0);\n\tv210 = v132 == 0;\n\tif (v210) goto L_0051;\n\tv90 = UnityEngine.GameObject::get_transform(v51);\n\tv65 = UnityEngine.Transform::get_position(v90);\n\tv91 = UnityEngine.GameObject::get_transform(v51);\n\tv72 = v118.value + v65;\n\tv213 = UnityEngine.Transform::get_position(v91);\n\tv69 = v69 + v213.y;\nL_0051:\n\tv220 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.minDepth);\n\tv222 = v220 == 0;\n\tif (v222) goto L_0089;\n\tv225 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxDepth);\n\tv227 = v225 == 0;\n\tif (v227) goto L_0089;\n\tv237 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv245 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v237);\n\tgoto L_0082;\n\tv255 = *([v201 @ X8_v16+E0]);\n\tv256 = v255 == 0;\n\tv257 = ~v256;\n\tif (v257) goto L_0082;\n\tv263 = v201;\n\tv259 = \"il2cpp_codegen_runtime_class_init\"(v263, v243, v186, v31, v32, v33, v34, v35, v66, v63, v60, v39, v40, v41, v42, v43);\nL_0082:\n\t// 130 MakeStruct v157 @ AGGA31B24_0_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v72 @ V9_v4 (System.Single), v69 @ V8_v4 (System.Single)\n\treturnVal2 = UnityEngine.Physics2D::OverlapPointAll(v157, v245);\n\treturn returnVal2;\nL_0089:\n\tv229 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.minDepth);\n\tv232 = v229 == 0;\n\tif (v232) goto L_0094;\n\tgoto L_009A;\nL_0094:\n\tv241 = HutongGames.PlayMaker.FsmInt::get_Value(this.minDepth);\nL_009A:\n\tv246 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxDepth);\n\tv254 = v246 == 0;\n\tif (v254) goto L_00A5;\n\tgoto L_00AC;\nL_00A5:\n\tv267 = HutongGames.PlayMaker.FsmInt::get_Value(this.maxDepth);\nL_00AC:\n\tv271 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv274 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v271);\n\tgoto L_00CE;\n\tv281 = *([v202 @ X8_v11+E0]);\n\tv282 = v281 == 0;\n\tv283 = ~v282;\n\tif (v283) goto L_00CE;\n\tv287 = v202;\n\tv285 = \"il2cpp_codegen_runtime_class_init\"(v287, v272, v187, v31, v32, v33, v34, v35, v66, v63, v60, v39, v40, v41, v42, v43);\nL_00CE:\n\t// 206 MakeStruct v153 @ AGGA31C04_0_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v72 @ V9_v4 (System.Single), v69 @ V8_v4 (System.Single)\n\treturnVal3 = UnityEngine.Physics2D::OverlapPointAll(v153, v274, v57, v53);\n\treturn returnVal3;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 146 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Collider2D[] GetOverlapPointAll()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			FsmVector2 fsmVector = position;
			float num = fsmVector.value.y;
			bool flag = ownerDefaultTarget != null;
			bool flag2 = !flag;
			float x = fsmVector.value.x;
			if (!flag2)
			{
				Transform transform = ownerDefaultTarget.transform;
				Vector3 vector = transform.position;
				Transform transform2 = ownerDefaultTarget.transform;
				x = fsmVector.value.x + vector.x;
				num += transform2.position.y;
			}
			if (minDepth.IsNone && maxDepth.IsNone)
			{
				bool value = invertMask.Value;
				int num2 = ActionHelpers.LayerArrayToLayerMask(layerMask, value);
				Vector2 point = default(Vector2);
				point.x = x;
				point.y = num;
				return Physics2D.OverlapPointAll(point, num2);
			}
			float num3;
			if (minDepth.IsNone)
			{
				num3 = float.NegativeInfinity;
			}
			else
			{
				int value2 = minDepth.Value;
				num3 = value2;
			}
			float num4;
			if (maxDepth.IsNone)
			{
				num4 = float.PositiveInfinity;
			}
			else
			{
				int value3 = maxDepth.Value;
				num4 = value3;
			}
			bool value4 = invertMask.Value;
			int num5 = ActionHelpers.LayerArrayToLayerMask(layerMask, value4);
			Vector2 point2 = default(Vector2);
			point2.x = x;
			point2.y = num;
			return Physics2D.OverlapPointAll(point2, num5, num3, num4);
		}

		[Token(Token = "0x6000DC5")]
		[Address(RVA = "0xA31CF0", Offset = "0xA31CF0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetNextOverlapPoint2d()
		{
		}
	}
}
