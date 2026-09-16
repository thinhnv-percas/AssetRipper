using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759C98", Offset = "0x759C98")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759C98", Offset = "0x759C98")]
	[Token(Token = "0x200029C")]
	public class Explosion : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B999C", Offset = "0x7B999C")]
		[Token(Token = "0x4001722")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 center;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B99E8", Offset = "0x7B99E8")]
		[Token(Token = "0x4001723")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat force;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9A34", Offset = "0x7B9A34")]
		[Token(Token = "0x4001724")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat radius;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9A80", Offset = "0x7B9A80")]
		[Token(Token = "0x4001725")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat upwardsModifier;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9AB8", Offset = "0x7B9AB8")]
		[Token(Token = "0x4001726")]
		[FieldOffset(Offset = "0x70")]
		public ForceMode forceMode;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B9AF0", Offset = "0x7B9AF0")]
		[Token(Token = "0x4001727")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt layer;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B9B04", Offset = "0x7B9B04")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9B04", Offset = "0x7B9B04")]
		[Token(Token = "0x4001728")]
		[FieldOffset(Offset = "0x80")]
		public FsmInt[] layerMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9B54", Offset = "0x7B9B54")]
		[Token(Token = "0x4001729")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool invertMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9B8C", Offset = "0x7B9B8C")]
		[Token(Token = "0x400172A")]
		[FieldOffset(Offset = "0x90")]
		public bool everyFrame;

		[Token(Token = "0x6000D02")]
		[Address(RVA = "0xB74D24", Offset = "0xB74D24", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.center = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.upwardsModifier = v12;\n\tthis.forceMode = 0;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			center = null;
			FsmFloat fsmFloat = 0f;
			upwardsModifier = fsmFloat;
			forceMode = default(ForceMode);
			everyFrame = false;
		}

		[Token(Token = "0x6000D03")]
		[Address(RVA = "0xB74D5C", Offset = "0xB74D5C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleFixedUpdate(this.fsm, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			Fsm.HandleFixedUpdate = true;
		}

		[Token(Token = "0x6000D04")]
		[Address(RVA = "0xB74D7C", Offset = "0xB74D7C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.Explosion::DoExplosion(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoExplosion();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D05")]
		[Address(RVA = "0xB74FBC", Offset = "0xB74FBC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.Explosion::DoExplosion(this);\n\treturn;\n")]
		public override void OnFixedUpdate()
		{
			DoExplosion();
		}

		[Token(Token = "0x6000D06")]
		[Address(RVA = "0xB74DB8", Offset = "0xB74DB8", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv38 = *([1ED9BE8]);\n\tv39 = *([v38 @ X8_v14]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2022920]) = v58;\nL_0021:\n\tv62 = HutongGames.PlayMaker.FsmVector3::get_Value(this.center);\n\tv231 = HutongGames.PlayMaker.FsmFloat::get_Value(this.radius);\n\tv167 = UnityEngine.Physics::OverlapSphere(v62, v231);\n\tv269 = v167.Length;\n\tv287 = v167.Length < 1;\n\tif (v287) goto L_00BF;\nL_0048:\n\tv411 = v92 < v269;\n\tv123 = ~v411;\n\tif (v123) goto L_00C3;\n\tv168 = UnityEngine.Component::get_gameObject(v167[v92 @ X23_v7 (System.Int32)]);\n\tv414 = UnityEngine.GameObject::GetComponent(v168);\n\tgoto L_006D;\n\tv418 = *([v183 @ X8_v10+E0]);\n\tv419 = v418 == 0;\n\tv420 = ~v419;\n\tif (v420) goto L_006D;\n\tv427 = v183;\n\tv422 = \"il2cpp_codegen_runtime_class_init\"(v427, v413, v77, v43, v44, v45, v46, v47, v154, v150, v145, v129, v67, v69, v54, v55);\nL_006D:\n\tv426 = UnityEngine.Object::op_Inequality(v414, 0);\n\tv429 = v426 == 0;\n\tif (v429) goto L_00A2;\n\tv432 = UnityEngine.Component::get_gameObject(v167[v92 @ X23_v7 (System.Int32)]);\n\tv442 = HutongGames.PlayMaker.Actions.Explosion::ShouldApplyForce(this, v432);\n\tv443 = v442 == 0;\n\tif (v443) goto L_00A2;\n\tv155 = HutongGames.PlayMaker.FsmFloat::get_Value(this.force);\n\tv156 = HutongGames.PlayMaker.FsmVector3::get_Value(this.center);\n\tv157 = HutongGames.PlayMaker.FsmFloat::get_Value(this.radius);\n\tv218 = HutongGames.PlayMaker.FsmFloat::get_Value(this.upwardsModifier);\n\tUnityEngine.Rigidbody::AddExplosionForce(v414, v155, v156, v157, v218, this.forceMode);\nL_00A2:\n\tv269 = v167.Length;\n\tv92 = v92 + 1;\n\tv380 = v92 < v167.Length;\n\tif (v380) goto L_0048;\nL_00BF:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv230 = new System.NullReferenceException();\nL_00C3:\n\tv271 = new System.IndexOutOfRangeException();\n\tthrow v271;\n\treturn;\n// 154 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoExplosion()
		{
			Vector3 value = center.Value;
			float value2 = radius.Value;
			Collider[] array = Physics.OverlapSphere(value, value2);
			int num = array.Length;
			if (array.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				GameObject gameObject = array[num2].gameObject;
				Rigidbody component = gameObject.GetComponent<Rigidbody>();
				if (component != null)
				{
					GameObject gameObject2 = array[num2].gameObject;
					if (ShouldApplyForce(gameObject2))
					{
						float value3 = force.Value;
						Vector3 value4 = center.Value;
						float value5 = radius.Value;
						float value6 = upwardsModifier.Value;
						component.AddExplosionForce(value3, value4, value5, value6, forceMode);
					}
				}
				num = array.Length;
				num2++;
				if (num2 >= array.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000D07")]
		[Address(RVA = "0xB74FC0", Offset = "0xB74FC0", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv37 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v18);\n\tv49 = UnityEngine.GameObject::get_layer(go);\n\tv87 = v49 & 0x1F;\n\tv84 = 1 << v87;\n\tv78 = v84 & v37;\n\tv66 = v78 < 0;\n\tv63 = v78 == 0;\n\tv88 = v66 == 0;\n\tv51 = ~v63;\n\tv54 = v88 & v51;\n\treturn v54;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool ShouldApplyForce(GameObject go)
		{
			bool value = invertMask.Value;
			int num = ActionHelpers.LayerArrayToLayerMask(layerMask, value);
			int num2 = go.layer;
			int num3 = num2 & 0x1F;
			int num4 = 1 << num3;
			int num5 = num4 & num;
			bool flag = num5 < 0;
			bool flag2 = num5 == 0;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag3 && flag4;
		}

		[Token(Token = "0x6000D08")]
		[Address(RVA = "0xB75038", Offset = "0xB75038", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Explosion()
		{
		}
	}
}
