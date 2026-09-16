using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A8EC", Offset = "0x75A8EC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75A8EC", Offset = "0x75A8EC")]
	[Token(Token = "0x20002C3")]
	public class GetTrigger2dInfo : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BD910", Offset = "0x7BD910")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD910", Offset = "0x7BD910")]
		[Token(Token = "0x400181D")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObjectHit;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BD960", Offset = "0x7BD960")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD960", Offset = "0x7BD960")]
		[Token(Token = "0x400181E")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt shapeCount;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BD9B0", Offset = "0x7BD9B0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD9B0", Offset = "0x7BD9B0")]
		[Token(Token = "0x400181F")]
		[FieldOffset(Offset = "0x60")]
		public FsmString physics2dMaterialName;

		[Token(Token = "0x6000DD5")]
		[Address(RVA = "0xA36F28", Offset = "0xA36F28", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.shapeCount = 0;\n\tthis.physics2dMaterialName = 0;\n\tthis.gameObjectHit = 0;\n\treturn;\n")]
		public override void Reset()
		{
			shapeCount = null;
			physics2dMaterialName = null;
			gameObjectHit = null;
		}

		[Token(Token = "0x6000DD6")]
		[Address(RVA = "0xA36F34", Offset = "0xA36F34", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE8EA8]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E1D]) = v42;\nL_0015:\n\tv43 = this.fsm;\n\tgoto L_0028;\n\tv96 = *([v48 @ X0_v6+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0028;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0028:\n\tv69 = UnityEngine.Object::op_Equality(v43.<TriggerCollider2D>k__BackingField, 0);\n\tv126 = v69 == 0;\n\tv127 = ~v126;\n\tif (v127) goto L_0081;\n\tv86 = this.fsm;\n\tv70 = UnityEngine.Component::get_gameObject(v86.<TriggerCollider2D>k__BackingField);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.gameObjectHit, v70);\n\tv87 = this.fsm;\n\tv93 = this.shapeCount;\n\tv72 = UnityEngine.Collider2D::get_shapeCount(v87.<TriggerCollider2D>k__BackingField);\n\tv93.value = v72;\n\tv88 = this.fsm;\n\tv53 = this.physics2dMaterialName;\n\tv160 = UnityEngine.Collider2D::get_sharedMaterial(v88.<TriggerCollider2D>k__BackingField);\n\tgoto L_0060;\n\tv165 = *([v161 @ X8_v11+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tif (v167) goto L_0060;\n\tv172 = v161;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v172, v159, v56, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0060:\n\tv73 = UnityEngine.Object::op_Inequality(v160, 0);\n\tv174 = v73 == 0;\n\tif (v174) goto L_FFFFFFFF;\n\tv89 = this.fsm;\n\tv115 = UnityEngine.Collider2D::get_sharedMaterial(v89.<TriggerCollider2D>k__BackingField);\n\tv134 = UnityEngine.Object::get_name(v115);\n\tv176 = v53 == 0;\n\tv83 = ~v176;\n\tif (v83) goto L_0079;\n\tgoto L_0083;\nL_0079:\n\tv53.value = v134;\nL_0081:\n\treturn;\nL_0083:\n\tthrow System.NullReferenceException;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StoreTriggerInfo()
		{
			Fsm fsm = Fsm;
			if (fsm.TriggerCollider2D == null)
			{
				return;
			}
			Fsm fsm2 = Fsm;
			GameObject gameObject = fsm2.TriggerCollider2D.gameObject;
			gameObjectHit.Value = gameObject;
			Fsm fsm3 = Fsm;
			FsmInt fsmInt = shapeCount;
			int value = fsm3.TriggerCollider2D.shapeCount;
			fsmInt.Value = value;
			Fsm fsm4 = Fsm;
			FsmString fsmString = physics2dMaterialName;
			PhysicsMaterial2D sharedMaterial = fsm4.TriggerCollider2D.sharedMaterial;
			string value2;
			if (sharedMaterial != null)
			{
				Fsm fsm5 = Fsm;
				PhysicsMaterial2D sharedMaterial2 = fsm5.TriggerCollider2D.sharedMaterial;
				value2 = sharedMaterial2.name;
				if (fsmString == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				value2 = "";
			}
			fsmString.Value = value2;
		}

		[Token(Token = "0x6000DD7")]
		[Address(RVA = "0xA370A8", Offset = "0xA370A8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetTrigger2dInfo::StoreTriggerInfo(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			StoreTriggerInfo();
			Finish();
		}

		[Token(Token = "0x6000DD8")]
		[Address(RVA = "0xA370D0", Offset = "0xA370D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetTrigger2dInfo()
		{
		}
	}
}
