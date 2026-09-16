using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758CEC", Offset = "0x758CEC")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x758CEC", Offset = "0x758CEC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758CEC", Offset = "0x758CEC")]
	[Token(Token = "0x200026B")]
	public class GameObjectIsVisible : ComponentAction<Renderer>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B6A2C", Offset = "0x7B6A2C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6A2C", Offset = "0x7B6A2C")]
		[Token(Token = "0x4001648")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6AC4", Offset = "0x7B6AC4")]
		[Token(Token = "0x4001649")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent trueEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6AFC", Offset = "0x7B6AFC")]
		[Token(Token = "0x400164A")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent falseEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B6B34", Offset = "0x7B6B34")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6B34", Offset = "0x7B6B34")]
		[Token(Token = "0x400164B")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool storeResult;

		[Token(Token = "0x400164C")]
		[FieldOffset(Offset = "0x80")]
		public bool everyFrame;

		[Token(Token = "0x6000C11")]
		[Address(RVA = "0xB7D16C", Offset = "0xB7D16C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.gameObject = 0;\n\tthis.falseEvent = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			falseEvent = null;
		}

		[Token(Token = "0x6000C12")]
		[Address(RVA = "0xB7D17C", Offset = "0xB7D17C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GameObjectIsVisible::DoIsVisible(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoIsVisible();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C13")]
		[Address(RVA = "0xB7D294", Offset = "0xB7D294", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GameObjectIsVisible::DoIsVisible(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoIsVisible();
		}

		[Token(Token = "0x6000C14")]
		[Address(RVA = "0xB7D1B8", Offset = "0xB7D1B8", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED4A88]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202297D]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.GameObjectIsVisible)+30]), this.gameObject);\n\tv59 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::UpdateCache(this, v43);\n\tv77 = v59 == 0;\n\tif (v77) goto L_0050;\n\tv49 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv67 = UnityEngine.Renderer::get_isVisible(v49);\n\tv72 = this.storeResult;\n\tv72.value = v67;\n\tv108 = this + 0x68;\n\tv105 = this + 0x70;\n\tv99 = v67 == 0;\n\tv90 = ~v99;\n\tv87 = ~v90;\n\tif (v87) goto L_FFFFFFFF;\n\tgoto L_0049;\nL_0049:\n\tHutongGames.PlayMaker.Fsm::Event(*([this @ X0 (HutongGames.PlayMaker.Actions.GameObjectIsVisible)+30]), *([v108 @ X9_v4]));\n\treturn;\nL_0050:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoIsVisible()
		{
			//IL_001c: Expected O, but got I
			//IL_0099: Expected O, but got I
			//IL_00a5: Expected O, but got I
			//IL_0100: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.GameObjectIsVisible)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Renderer renderer = base.renderer;
				bool isVisible = renderer.isVisible;
				FsmBool fsmBool = storeResult;
				fsmBool.value = isVisible;
				object fsmEvent = (long)(IntPtr)this + 104L;
				object obj = (long)(IntPtr)this + 112L;
				if (!isVisible)
				{
					fsmEvent = obj;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.GameObjectIsVisible)+30]");
				((Fsm)0).Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x6000C15")]
		[Address(RVA = "0xB7D298", Offset = "0xB7D298", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EA97D0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202297E]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObjectIsVisible()
		{
		}
	}
}
