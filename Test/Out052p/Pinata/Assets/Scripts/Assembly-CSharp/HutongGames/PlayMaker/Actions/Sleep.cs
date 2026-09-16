using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A2FC", Offset = "0x75A2FC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A2FC", Offset = "0x75A2FC")]
	[Token(Token = "0x20002B0")]
	public class Sleep : ComponentAction<Rigidbody>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BB3C4", Offset = "0x7BB3C4")]
		[Token(Token = "0x400178D")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x6000D5F")]
		[Address(RVA = "0x99BEE4", Offset = "0x99BEE4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
		}

		[Token(Token = "0x6000D60")]
		[Address(RVA = "0x99BEEC", Offset = "0x99BEEC", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.Sleep::DoSleep(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSleep();
			Finish();
		}

		[Token(Token = "0x6000D61")]
		[Address(RVA = "0x99BF14", Offset = "0x99BF14", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF2B80]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217AD]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.Sleep)+30]), this.gameObject);\n\tv59 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::UpdateCache(this, v43);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0036;\n\tv49 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tUnityEngine.Rigidbody::Sleep(v49);\n\treturn;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSleep()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.Sleep)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Rigidbody rigidbody = base.rigidbody;
				rigidbody.Sleep();
			}
		}

		[Token(Token = "0x6000D62")]
		[Address(RVA = "0x99BFB0", Offset = "0x99BFB0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F0EEF0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217AE]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Sleep()
		{
		}
	}
}
