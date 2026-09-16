using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A0F8", Offset = "0x75A0F8")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x75A0F8", Offset = "0x75A0F8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A0F8", Offset = "0x75A0F8")]
	[Token(Token = "0x20002AA")]
	public class SetDrag : ComponentAction<Rigidbody>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BAFF4", Offset = "0x7BAFF4")]
		[Token(Token = "0x4001778")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7BB068", Offset = "0x7BB068")]
		[Token(Token = "0x4001779")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat drag;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BB0A8", Offset = "0x7BB0A8")]
		[Token(Token = "0x400177A")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000D44")]
		[Address(RVA = "0xB2CD70", Offset = "0xB2CD70", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.drag = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = 1f;
			drag = fsmFloat;
		}

		[Token(Token = "0x6000D45")]
		[Address(RVA = "0xB2CDA0", Offset = "0xB2CDA0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetDrag::DoSetDrag(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetDrag();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D46")]
		[Address(RVA = "0xB2CE9C", Offset = "0xB2CE9C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetDrag::DoSetDrag(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetDrag();
		}

		[Token(Token = "0x6000D47")]
		[Address(RVA = "0xB2CDDC", Offset = "0xB2CDDC", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE4988]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202262A]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetDrag)+30]), this.gameObject);\n\tv50 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::UpdateCache(this, v43);\n\tv70 = v50 == 0;\n\tif (v70) goto L_003E;\n\tv58 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tv52 = HutongGames.PlayMaker.FsmFloat::get_Value(this.drag);\n\tUnityEngine.Rigidbody::set_drag(v58, v52);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetDrag()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetDrag)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Rigidbody rigidbody = base.rigidbody;
				float value = drag.Value;
				rigidbody.drag = value;
			}
		}

		[Token(Token = "0x6000D48")]
		[Address(RVA = "0xB2CEA0", Offset = "0xB2CEA0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED4340]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202262B]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetDrag()
		{
		}
	}
}
