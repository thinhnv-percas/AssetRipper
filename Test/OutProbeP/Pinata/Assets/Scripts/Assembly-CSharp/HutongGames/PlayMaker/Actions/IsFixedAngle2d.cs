using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A98C", Offset = "0x75A98C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75A98C", Offset = "0x75A98C")]
	[Token(Token = "0x20002C5")]
	public class IsFixedAngle2d : ComponentAction<Rigidbody2D>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BDBF8", Offset = "0x7BDBF8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BDBF8", Offset = "0x7BDBF8")]
		[Token(Token = "0x4001826")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BDC90", Offset = "0x7BDC90")]
		[Token(Token = "0x4001827")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent trueEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BDCC8", Offset = "0x7BDCC8")]
		[Token(Token = "0x4001828")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent falseEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BDD00", Offset = "0x7BDD00")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BDD00", Offset = "0x7BDD00")]
		[Token(Token = "0x4001829")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool store;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BDD50", Offset = "0x7BDD50")]
		[Token(Token = "0x400182A")]
		[FieldOffset(Offset = "0x80")]
		public bool everyFrame;

		[Token(Token = "0x6000DDE")]
		[Address(RVA = "0xA39020", Offset = "0xA39020", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.gameObject = 0;\n\tthis.falseEvent = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			falseEvent = null;
		}

		[Token(Token = "0x6000DDF")]
		[Address(RVA = "0xA39030", Offset = "0xA39030", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.IsFixedAngle2d::DoIsFixedAngle(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoIsFixedAngle();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000DE0")]
		[Address(RVA = "0xA39148", Offset = "0xA39148", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.IsFixedAngle2d::DoIsFixedAngle(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoIsFixedAngle();
		}

		[Token(Token = "0x6000DE1")]
		[Address(RVA = "0xA3906C", Offset = "0xA3906C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC6C98]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E31]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.IsFixedAngle2d)+30]), this.gameObject);\n\tv69 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::UpdateCache(this, v43);\n\tv82 = v69 == 0;\n\tif (v82) goto L_0054;\n\tv56 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::get_rigidbody2d(this);\n\tv75 = UnityEngine.Rigidbody2D::get_constraints(v56);\n\tv49 = this.store;\n\tv63 = v75 & 4;\n\tv46 = v63 >> 2;\n\tv49.value = v46;\n\tv124 = this + 0x68;\n\tv122 = this + 0x70;\n\tv110 = v63 == 0;\n\tv95 = ~v110;\n\tv92 = ~v95;\n\tif (v92) goto L_FFFFFFFF;\n\tgoto L_004D;\nL_004D:\n\tHutongGames.PlayMaker.Fsm::Event(*([this @ X0 (HutongGames.PlayMaker.Actions.IsFixedAngle2d)+30]), *([v134 @ X8_v10]));\n\treturn;\nL_0054:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoIsFixedAngle()
		{
			//IL_001c: Expected O, but got I
			//IL_00b5: Expected O, but got I
			//IL_00c1: Expected O, but got I
			//IL_0124: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.IsFixedAngle2d)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Rigidbody2D rigidbody2D = base.rigidbody2d;
				RigidbodyConstraints2D constraints = rigidbody2D.constraints;
				FsmBool fsmBool = store;
				int num = (int)(constraints & RigidbodyConstraints2D.FreezeRotation);
				int value = num >> 2;
				fsmBool.value = (byte)value != 0;
				object obj = (long)(IntPtr)this + 104L;
				object obj2 = (long)(IntPtr)this + 112L;
				object fsmEvent = ((num == 0) ? obj2 : obj);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.IsFixedAngle2d)+30]");
				((Fsm)0).Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x6000DE2")]
		[Address(RVA = "0xA3914C", Offset = "0xA3914C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EC7998]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E32]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IsFixedAngle2d()
		{
		}
	}
}
