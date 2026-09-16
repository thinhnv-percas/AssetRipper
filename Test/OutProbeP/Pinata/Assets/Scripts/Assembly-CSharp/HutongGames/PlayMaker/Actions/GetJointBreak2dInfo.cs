using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A61C", Offset = "0x75A61C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A61C", Offset = "0x75A61C")]
	[Token(Token = "0x20002BA")]
	public class GetJointBreak2dInfo : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BBFD0", Offset = "0x7BBFD0")]
		[Attribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7BBFD0", Offset = "0x7BBFD0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BBFD0", Offset = "0x7BBFD0")]
		[Token(Token = "0x40017BA")]
		[FieldOffset(Offset = "0x50")]
		public FsmObject brokenJoint;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BC06C", Offset = "0x7BC06C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BC06C", Offset = "0x7BC06C")]
		[Token(Token = "0x40017BB")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 reactionForce;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BC0BC", Offset = "0x7BC0BC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BC0BC", Offset = "0x7BC0BC")]
		[Token(Token = "0x40017BC")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat reactionForceMagnitude;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BC10C", Offset = "0x7BC10C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BC10C", Offset = "0x7BC10C")]
		[Token(Token = "0x40017BD")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat reactionTorque;

		[Token(Token = "0x6000DAA")]
		[Address(RVA = "0xA2EE1C", Offset = "0xA2EE1C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.reactionTorque = 0;\n\tthis.brokenJoint = 0;\n\tthis.reactionForce = 0;\n\treturn;\n")]
		public override void Reset()
		{
			reactionTorque = null;
			brokenJoint = null;
			reactionForce = null;
		}

		[Token(Token = "0x6000DAB")]
		[Address(RVA = "0xA2EE28", Offset = "0xA2EE28", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EA6C10]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DDE]) = v38;\nL_0014:\n\tv40 = this.fsm;\n\tgoto L_0027;\n\tv96 = *([v45 @ X0_v6+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0027;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tv72 = UnityEngine.Object::op_Equality(v40.<BrokenJoint2D>k__BackingField, 0);\n\tv122 = v72 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_0065;\n\tv88 = this.fsm;\n\tv69 = this.brokenJoint;\n\tv69.value = v88.<BrokenJoint2D>k__BackingField;\n\tv89 = this.fsm;\n\tv93 = this.reactionForce;\n\tv58 = UnityEngine.Joint2D::get_reactionForce(v89.<BrokenJoint2D>k__BackingField);\n\tv93.value = v58;\n\tv93.value.y = v58.y;\n\tv90 = this.fsm;\n\tv94 = this.reactionForceMagnitude;\n\tv58 = UnityEngine.Joint2D::get_reactionForce(v90.<BrokenJoint2D>k__BackingField);\n\tv74 = 0x1588E30(&v58 @ V0_v4 (UnityEngine.Vector2), 0, 0, v23, v24, v25, v26, v27, v58, v58.y, v30, v31, v32, v33, v34, v35);\n\tv94.value = v58;\n\tv91 = this.fsm;\n\tv86 = this.reactionTorque;\n\tv60 = UnityEngine.Joint2D::get_reactionTorque(v91.<BrokenJoint2D>k__BackingField);\n\tv86.value = v60;\nL_0065:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StoreInfo()
		{
			Fsm fsm = Fsm;
			if (!(fsm.BrokenJoint2D == null))
			{
				Fsm fsm2 = Fsm;
				FsmObject fsmObject = brokenJoint;
				fsmObject.Value = fsm2.BrokenJoint2D;
				Fsm fsm3 = Fsm;
				FsmVector2 fsmVector = reactionForce;
				Vector2 vector = (fsmVector.value = fsm3.BrokenJoint2D.reactionForce);
				fsmVector.value.y = vector.y;
				Fsm fsm4 = Fsm;
				FsmFloat fsmFloat = reactionForceMagnitude;
				vector = fsm4.BrokenJoint2D.reactionForce;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588E30 (inside UnityEngine.Vector2::Scale +0xC8)");
				fsmFloat.Value = vector.x;
				Fsm fsm5 = Fsm;
				FsmFloat fsmFloat2 = reactionTorque;
				float value = fsm5.BrokenJoint2D.reactionTorque;
				fsmFloat2.Value = value;
			}
		}

		[Token(Token = "0x6000DAC")]
		[Address(RVA = "0xA2EF50", Offset = "0xA2EF50", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetJointBreak2dInfo::StoreInfo(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			StoreInfo();
			Finish();
		}

		[Token(Token = "0x6000DAD")]
		[Address(RVA = "0xA2EF78", Offset = "0xA2EF78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetJointBreak2dInfo()
		{
		}
	}
}
