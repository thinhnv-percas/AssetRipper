using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759FB8", Offset = "0x759FB8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759FB8", Offset = "0x759FB8")]
	[Token(Token = "0x20002A6")]
	public class IsKinematic : ComponentAction<Rigidbody>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BA578", Offset = "0x7BA578")]
		[Token(Token = "0x400174B")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x400174C")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent trueEvent;

		[Token(Token = "0x400174D")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent falseEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BA5EC", Offset = "0x7BA5EC")]
		[Token(Token = "0x400174E")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool store;

		[Token(Token = "0x400174F")]
		[FieldOffset(Offset = "0x80")]
		public bool everyFrame;

		[Token(Token = "0x6000D30")]
		[Address(RVA = "0xA3919C", Offset = "0xA3919C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.gameObject = 0;\n\tthis.falseEvent = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			falseEvent = null;
		}

		[Token(Token = "0x6000D31")]
		[Address(RVA = "0xA391AC", Offset = "0xA391AC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.IsKinematic::DoIsKinematic(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoIsKinematic();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D32")]
		[Address(RVA = "0xA392C4", Offset = "0xA392C4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.IsKinematic::DoIsKinematic(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoIsKinematic();
		}

		[Token(Token = "0x6000D33")]
		[Address(RVA = "0xA391E8", Offset = "0xA391E8", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED5498]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E33]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.IsKinematic)+30]), this.gameObject);\n\tv59 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::UpdateCache(this, v43);\n\tv77 = v59 == 0;\n\tif (v77) goto L_0050;\n\tv49 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tv67 = UnityEngine.Rigidbody::get_isKinematic(v49);\n\tv72 = this.store;\n\tv72.value = v67;\n\tv108 = this + 0x68;\n\tv105 = this + 0x70;\n\tv99 = v67 == 0;\n\tv90 = ~v99;\n\tv87 = ~v90;\n\tif (v87) goto L_FFFFFFFF;\n\tgoto L_0049;\nL_0049:\n\tHutongGames.PlayMaker.Fsm::Event(*([this @ X0 (HutongGames.PlayMaker.Actions.IsKinematic)+30]), *([v108 @ X9_v4]));\n\treturn;\nL_0050:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoIsKinematic()
		{
			//IL_001c: Expected O, but got I
			//IL_0099: Expected O, but got I
			//IL_00a5: Expected O, but got I
			//IL_0100: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.IsKinematic)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Rigidbody rigidbody = base.rigidbody;
				bool isKinematic = rigidbody.isKinematic;
				FsmBool fsmBool = store;
				fsmBool.value = isKinematic;
				object fsmEvent = (long)(IntPtr)this + 104L;
				object obj = (long)(IntPtr)this + 112L;
				if (!isKinematic)
				{
					fsmEvent = obj;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.IsKinematic)+30]");
				((Fsm)0).Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x6000D34")]
		[Address(RVA = "0xA392C8", Offset = "0xA392C8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EE0838]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E34]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IsKinematic()
		{
		}
	}
}
