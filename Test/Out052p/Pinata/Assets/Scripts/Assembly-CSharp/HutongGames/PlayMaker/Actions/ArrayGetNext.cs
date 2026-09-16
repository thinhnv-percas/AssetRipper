using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753B94", Offset = "0x753B94")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x753B94", Offset = "0x753B94")]
	[Token(Token = "0x2000177")]
	public class ArrayGetNext : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A9A9C", Offset = "0x7A9A9C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9A9C", Offset = "0x7A9A9C")]
		[Token(Token = "0x4001259")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9AFC", Offset = "0x7A9AFC")]
		[Token(Token = "0x400125A")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt startIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9B34", Offset = "0x7A9B34")]
		[Token(Token = "0x400125B")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt endIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9B6C", Offset = "0x7A9B6C")]
		[Token(Token = "0x400125C")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent loopEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9BA4", Offset = "0x7A9BA4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A9BA4", Offset = "0x7A9BA4")]
		[Token(Token = "0x400125D")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetFlag;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9BF4", Offset = "0x7A9BF4")]
		[Token(Token = "0x400125E")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent finishedEvent;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A9C2C", Offset = "0x7A9C2C")]
		[AttributeAttribute(Type = typeof(MatchElementTypeAttribute), RVA = "0x7A9C2C", Offset = "0x7A9C2C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A9C2C", Offset = "0x7A9C2C")]
		[Token(Token = "0x400125F")]
		[FieldOffset(Offset = "0x80")]
		public FsmVar result;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A9CA0", Offset = "0x7A9CA0")]
		[Token(Token = "0x4001260")]
		[FieldOffset(Offset = "0x88")]
		public FsmInt currentIndex;

		[Token(Token = "0x4001261")]
		[FieldOffset(Offset = "0x90")]
		private int nextItemIndex;

		[Token(Token = "0x600082C")]
		[Address(RVA = "0xA896BC", Offset = "0xA896BC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.resetFlag = 0;\n\tthis.result = 0;\n\tthis.array = 0;\n\tthis.endIndex = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			resetFlag = null;
			result = null;
			array = null;
			endIndex = null;
		}

		[Token(Token = "0x600082D")]
		[Address(RVA = "0xA896CC", Offset = "0xA896CC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.nextItemIndex == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_0025;\n\tv48 = HutongGames.PlayMaker.FsmInt::get_Value(this.startIndex);\n\tv16 = v48 < 1;\n\tif (v16) goto L_0025;\n\tv47 = HutongGames.PlayMaker.FsmInt::get_Value(this.startIndex);\n\tthis.nextItemIndex = v47;\nL_0025:\n\tv84 = HutongGames.PlayMaker.FsmBool::get_Value(this.resetFlag);\n\tv107 = v84 == 0;\n\tif (v107) goto L_0034;\n\tv99 = HutongGames.PlayMaker.FsmInt::get_Value(this.startIndex);\n\tv103 = this.resetFlag;\n\tthis.nextItemIndex = v99;\n\tv103.value = 0;\nL_0034:\n\tHutongGames.PlayMaker.Actions.ArrayGetNext::DoGetNextItem(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (nextItemIndex == 0)
			{
				int value = startIndex.Value;
				if (value >= 1)
				{
					int value2 = startIndex.Value;
					nextItemIndex = value2;
				}
			}
			if (resetFlag.Value)
			{
				int value3 = startIndex.Value;
				FsmBool fsmBool = resetFlag;
				nextItemIndex = value3;
				fsmBool.value = false;
			}
			DoGetNextItem();
			Finish();
		}

		[Token(Token = "0x600082E")]
		[Address(RVA = "0xA8976C", Offset = "0xA8976C", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv39 = this.nextItemIndex >= v16;\n\tif (v39) goto L_0068;\n\tv230 = HutongGames.PlayMaker.FsmArray::Get(this.array, this.nextItemIndex);\n\tHutongGames.PlayMaker.FsmVar::SetValue(this.result, v230);\n\tv181 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv40 = this.nextItemIndex >= v181;\n\tif (v40) goto L_0068;\n\tv251 = HutongGames.PlayMaker.FsmInt::get_Value(this.endIndex);\n\tv41 = v251 < 1;\n\tif (v41) goto L_0059;\n\tv255 = HutongGames.PlayMaker.FsmInt::get_Value(this.endIndex);\n\tv45 = this.nextItemIndex >= v255;\n\tif (v45) goto L_007F;\nL_0059:\n\tv24 = this.currentIndex;\n\tv20 = this.nextItemIndex + 1;\n\tthis.nextItemIndex = v20;\n\tv24.value = this.nextItemIndex;\n\tv212 = this.loopEvent;\n\tv218 = this.loopEvent == 0;\n\tif (v218) goto L_008E;\n\tv220 = this.fsm;\n\tv257 = this.fsm == 0;\n\tv150 = ~v257;\n\tif (v150) goto L_007C;\n\tgoto L_0090;\nL_0068:\n\tthis.nextItemIndex = 0;\n\tv231 = this.currentIndex;\n\tv233 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv244 = v233 - 1;\n\tv231.value = v244;\nL_0072:\n\tv220 = this.fsm;\n\tv212 = this.finishedEvent;\nL_007C:\n\tHutongGames.PlayMaker.Fsm::Event(v220, v212);\n\treturn;\nL_007F:\n\tthis.nextItemIndex = 0;\n\tv239 = this.currentIndex;\n\tv243 = HutongGames.PlayMaker.FsmInt::get_Value(this.endIndex);\n\tv239.value = v243;\n\tgoto L_0072;\nL_008E:\n\treturn;\nL_0090:\n\tthrow System.NullReferenceException;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetNextItem()
		{
			int length = array.Length;
			FsmEvent fsmEvent;
			Fsm fsm;
			if (nextItemIndex < length)
			{
				object value = array.Get(nextItemIndex);
				result.SetValue(value);
				int length2 = array.Length;
				if (nextItemIndex < length2)
				{
					int value2 = endIndex.Value;
					if (value2 >= 1)
					{
						int value3 = endIndex.Value;
						if (nextItemIndex >= value3)
						{
							nextItemIndex = 0;
							FsmInt fsmInt = currentIndex;
							int value4 = endIndex.Value;
							fsmInt.Value = value4;
							goto IL_0236;
						}
					}
					FsmInt fsmInt2 = currentIndex;
					int num = nextItemIndex + 1;
					nextItemIndex = num;
					fsmInt2.Value = nextItemIndex;
					fsmEvent = loopEvent;
					if (loopEvent != null)
					{
						fsm = Fsm;
						if (Fsm == null)
						{
							throw new NullReferenceException();
						}
						goto IL_0228;
					}
					return;
				}
			}
			nextItemIndex = 0;
			FsmInt fsmInt3 = currentIndex;
			int length3 = array.Length;
			int value5 = length3 - 1;
			fsmInt3.Value = value5;
			goto IL_0236;
			IL_0236:
			fsm = Fsm;
			fsmEvent = finishedEvent;
			goto IL_0228;
			IL_0228:
			fsm.Event(fsmEvent);
		}

		[Token(Token = "0x600082F")]
		[Address(RVA = "0xA898B8", Offset = "0xA898B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayGetNext()
		{
		}
	}
}
