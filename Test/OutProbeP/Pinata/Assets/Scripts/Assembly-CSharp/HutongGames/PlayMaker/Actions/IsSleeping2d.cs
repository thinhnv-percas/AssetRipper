using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75AA2C", Offset = "0x75AA2C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75AA2C", Offset = "0x75AA2C")]
	[Token(Token = "0x20002C7")]
	public class IsSleeping2d : ComponentAction<Rigidbody2D>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BDF18", Offset = "0x7BDF18")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BDF18", Offset = "0x7BDF18")]
		[Token(Token = "0x4001830")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BDFB0", Offset = "0x7BDFB0")]
		[Token(Token = "0x4001831")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent trueEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BDFE8", Offset = "0x7BDFE8")]
		[Token(Token = "0x4001832")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent falseEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BE020", Offset = "0x7BE020")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BE020", Offset = "0x7BE020")]
		[Token(Token = "0x4001833")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool store;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BE070", Offset = "0x7BE070")]
		[Token(Token = "0x4001834")]
		[FieldOffset(Offset = "0x80")]
		public bool everyFrame;

		[Token(Token = "0x6000DE8")]
		[Address(RVA = "0xA39610", Offset = "0xA39610", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.gameObject = 0;\n\tthis.falseEvent = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			falseEvent = null;
		}

		[Token(Token = "0x6000DE9")]
		[Address(RVA = "0xA39620", Offset = "0xA39620", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.IsSleeping2d::DoIsSleeping(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoIsSleeping();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000DEA")]
		[Address(RVA = "0xA39738", Offset = "0xA39738", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.IsSleeping2d::DoIsSleeping(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoIsSleeping();
		}

		[Token(Token = "0x6000DEB")]
		[Address(RVA = "0xA3965C", Offset = "0xA3965C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F09918]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E39]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.IsSleeping2d)+30]), this.gameObject);\n\tv59 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::UpdateCache(this, v43);\n\tv77 = v59 == 0;\n\tif (v77) goto L_0050;\n\tv49 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::get_rigidbody2d(this);\n\tv67 = UnityEngine.Rigidbody2D::IsSleeping(v49);\n\tv72 = this.store;\n\tv72.value = v67;\n\tv108 = this + 0x68;\n\tv105 = this + 0x70;\n\tv99 = v67 == 0;\n\tv90 = ~v99;\n\tv87 = ~v90;\n\tif (v87) goto L_FFFFFFFF;\n\tgoto L_0049;\nL_0049:\n\tHutongGames.PlayMaker.Fsm::Event(*([this @ X0 (HutongGames.PlayMaker.Actions.IsSleeping2d)+30]), *([v108 @ X9_v4]));\n\treturn;\nL_0050:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoIsSleeping()
		{
			//IL_001c: Expected O, but got I
			//IL_0099: Expected O, but got I
			//IL_00a5: Expected O, but got I
			//IL_0100: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.IsSleeping2d)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Rigidbody2D rigidbody2D = base.rigidbody2d;
				bool flag = rigidbody2D.IsSleeping();
				FsmBool fsmBool = store;
				fsmBool.value = flag;
				object fsmEvent = (long)(IntPtr)this + 104L;
				object obj = (long)(IntPtr)this + 112L;
				if (!flag)
				{
					fsmEvent = obj;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.IsSleeping2d)+30]");
				((Fsm)0).Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x6000DEC")]
		[Address(RVA = "0xA3973C", Offset = "0xA3973C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ECC638]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E3A]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IsSleeping2d()
		{
		}
	}
}
