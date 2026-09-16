using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75AFA0", Offset = "0x75AFA0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75AFA0", Offset = "0x75AFA0")]
	[Token(Token = "0x20002D8")]
	public class Sleep2d : ComponentAction<Rigidbody2D>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C0118", Offset = "0x7C0118")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C0118", Offset = "0x7C0118")]
		[Token(Token = "0x40018B0")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x6000E3B")]
		[Address(RVA = "0x99C000", Offset = "0x99C000", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
		}

		[Token(Token = "0x6000E3C")]
		[Address(RVA = "0x99C008", Offset = "0x99C008", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.Sleep2d::DoSleep(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSleep();
			Finish();
		}

		[Token(Token = "0x6000E3D")]
		[Address(RVA = "0x99C030", Offset = "0x99C030", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAC8D0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217AF]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.Sleep2d)+30]), this.gameObject);\n\tv59 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::UpdateCache(this, v43);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0036;\n\tv49 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::get_rigidbody2d(this);\n\tUnityEngine.Rigidbody2D::Sleep(v49);\n\treturn;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSleep()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.Sleep2d)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Rigidbody2D rigidbody2D = base.rigidbody2d;
				rigidbody2D.Sleep();
			}
		}

		[Token(Token = "0x6000E3E")]
		[Address(RVA = "0x99C0CC", Offset = "0x99C0CC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F08A48]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217B0]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Sleep2d()
		{
		}
	}
}
