using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75AD4C", Offset = "0x75AD4C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75AD4C", Offset = "0x75AD4C")]
	[Token(Token = "0x20002D1")]
	public class SetGravity2dScale : ComponentAction<Rigidbody2D>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BF6DC", Offset = "0x7BF6DC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BF6DC", Offset = "0x7BF6DC")]
		[Token(Token = "0x400188C")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BF774", Offset = "0x7BF774")]
		[Token(Token = "0x400188D")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat gravityScale;

		[Token(Token = "0x6000E1A")]
		[Address(RVA = "0x995138", Offset = "0x995138", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.gravityScale = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = 1f;
			gravityScale = fsmFloat;
		}

		[Token(Token = "0x6000E1B")]
		[Address(RVA = "0x995168", Offset = "0x995168", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetGravity2dScale::DoSetGravityScale(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetGravityScale();
			Finish();
		}

		[Token(Token = "0x6000E1C")]
		[Address(RVA = "0x995190", Offset = "0x995190", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAB0B8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021755]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetGravity2dScale)+30]), this.gameObject);\n\tv50 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::UpdateCache(this, v43);\n\tv70 = v50 == 0;\n\tif (v70) goto L_003E;\n\tv58 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::get_rigidbody2d(this);\n\tv52 = HutongGames.PlayMaker.FsmFloat::get_Value(this.gravityScale);\n\tUnityEngine.Rigidbody2D::set_gravityScale(v58, v52);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetGravityScale()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetGravity2dScale)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Rigidbody2D rigidbody2D = base.rigidbody2d;
				float value = gravityScale.Value;
				rigidbody2D.gravityScale = value;
			}
		}

		[Token(Token = "0x6000E1D")]
		[Address(RVA = "0x995250", Offset = "0x995250", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EF7398]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021756]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetGravity2dScale()
		{
		}
	}
}
