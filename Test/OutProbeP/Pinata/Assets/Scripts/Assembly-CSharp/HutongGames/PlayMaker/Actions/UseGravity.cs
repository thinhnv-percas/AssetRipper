using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A39C", Offset = "0x75A39C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A39C", Offset = "0x75A39C")]
	[Token(Token = "0x20002B2")]
	public class UseGravity : ComponentAction<Rigidbody>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BB580", Offset = "0x7BB580")]
		[Token(Token = "0x4001794")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Token(Token = "0x4001795")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool useGravity;

		[Token(Token = "0x6000D74")]
		[Address(RVA = "0x986680", Offset = "0x986680", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.useGravity = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmBool fsmBool = true;
			useGravity = fsmBool;
		}

		[Token(Token = "0x6000D75")]
		[Address(RVA = "0x9866B0", Offset = "0x9866B0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.UseGravity::DoUseGravity(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoUseGravity();
			Finish();
		}

		[Token(Token = "0x6000D76")]
		[Address(RVA = "0x9866D8", Offset = "0x9866D8", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAF030]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021699]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.UseGravity)+30]), this.gameObject);\n\tv50 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::UpdateCache(this, v43);\n\tv68 = v50 == 0;\n\tif (v68) goto L_003F;\n\tv56 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tv57 = HutongGames.PlayMaker.FsmBool::get_Value(this.useGravity);\n\tUnityEngine.Rigidbody::set_useGravity(v56, v57);\n\treturn;\nL_003F:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoUseGravity()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UseGravity)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Rigidbody rigidbody = base.rigidbody;
				bool value = useGravity.Value;
				rigidbody.useGravity = value;
			}
		}

		[Token(Token = "0x6000D77")]
		[Address(RVA = "0x98679C", Offset = "0x98679C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EEDB90]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202169A]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UseGravity()
		{
		}
	}
}
