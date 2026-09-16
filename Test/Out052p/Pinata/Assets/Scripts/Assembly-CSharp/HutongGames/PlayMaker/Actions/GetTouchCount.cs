using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755870", Offset = "0x755870")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755870", Offset = "0x755870")]
	[Token(Token = "0x20001CC")]
	public class GetTouchCount : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AEED0", Offset = "0x7AEED0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AEED0", Offset = "0x7AEED0")]
		[Token(Token = "0x40013B6")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt storeCount;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AEF30", Offset = "0x7AEF30")]
		[Token(Token = "0x40013B7")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6000993")]
		[Address(RVA = "0xA36958", Offset = "0xA36958", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storeCount = 0;\n\tthis.everyFrame = 0;\n\treturn;\n")]
		public override void Reset()
		{
			storeCount = null;
			everyFrame = false;
		}

		[Token(Token = "0x6000994")]
		[Address(RVA = "0xA36964", Offset = "0xA36964", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetTouchCount::DoGetTouchCount(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetTouchCount();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000995")]
		[Address(RVA = "0xA369D4", Offset = "0xA369D4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetTouchCount::DoGetTouchCount(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetTouchCount();
		}

		[Token(Token = "0x6000996")]
		[Address(RVA = "0xA369A0", Offset = "0xA369A0", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.storeCount;\n\tv11 = UnityEngine.Input::get_touchCount();\n\tv8.value = v11;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetTouchCount()
		{
			FsmInt fsmInt = storeCount;
			int touchCount = Input.touchCount;
			fsmInt.Value = touchCount;
		}

		[Token(Token = "0x6000997")]
		[Address(RVA = "0xA369D8", Offset = "0xA369D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetTouchCount()
		{
		}
	}
}
