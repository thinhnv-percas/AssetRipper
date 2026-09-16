using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7585D4", Offset = "0x7585D4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7585D4", Offset = "0x7585D4")]
	[Token(Token = "0x2000257")]
	public class BoolAnyTrue : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B5108", Offset = "0x7B5108")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5108", Offset = "0x7B5108")]
		[Token(Token = "0x40015E1")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool[] boolVariables;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5168", Offset = "0x7B5168")]
		[Token(Token = "0x40015E2")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent sendEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B51A0", Offset = "0x7B51A0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B51A0", Offset = "0x7B51A0")]
		[Token(Token = "0x40015E3")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B51F0", Offset = "0x7B51F0")]
		[Token(Token = "0x40015E4")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000BAF")]
		[Address(RVA = "0xA8C0A0", Offset = "0xA8C0A0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.sendEvent = 0;\n\tthis.storeResult = 0;\n\tthis.boolVariables = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			sendEvent = null;
			storeResult = null;
			boolVariables = null;
		}

		[Token(Token = "0x6000BB0")]
		[Address(RVA = "0xA8C0B0", Offset = "0xA8C0B0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BoolAnyTrue::DoAnyTrue(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoAnyTrue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000BB1")]
		[Address(RVA = "0xA8C1A4", Offset = "0xA8C1A4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BoolAnyTrue::DoAnyTrue(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoAnyTrue();
		}

		[Token(Token = "0x6000BB2")]
		[Address(RVA = "0xA8C0EC", Offset = "0xA8C0EC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.boolVariables;\n\tv15 = v12.Length == 0;\n\tif (v15) goto L_0044;\n\tv80 = this.storeResult;\n\tv80.value = 0;\n\tv121 = this.boolVariables;\nL_0016:\n\tv188 = v117 < v121.Length;\n\tv49 = ~v188;\n\tv17 = v117 >= v121.Length;\n\tif (v17) goto L_0044;\n\tif (v49) goto L_0045;\n\tv64 = HutongGames.PlayMaker.FsmBool::get_Value(v121[v117 @ X20_v7 (System.Int32)]);\n\tv191 = v64 == 0;\n\tv130 = ~v191;\n\tif (v130) goto L_0039;\n\tv121 = this.boolVariables;\n\tv117 = v117 + 1;\n\tv192 = this.boolVariables == 0;\n\tv74 = ~v192;\n\tif (v74) goto L_0016;\n\tthrow System.NullReferenceException;\nL_0039:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\tv82 = this.storeResult;\n\tv82.value = 1;\nL_0044:\n\treturn;\nL_0045:\n\tv189 = new System.IndexOutOfRangeException();\n\tthrow v189;\n\tthrow System.NullReferenceException;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAnyTrue()
		{
			FsmBool[] array = boolVariables;
			if (array.Length == 0)
			{
				return;
			}
			FsmBool fsmBool = storeResult;
			fsmBool.value = false;
			FsmBool[] array2 = boolVariables;
			int num = 0;
			while (true)
			{
				bool flag = num < array2.Length;
				bool flag2 = !flag;
				if (num < array2.Length)
				{
					if (!flag2)
					{
						if (!array2[num].Value)
						{
							array2 = boolVariables;
							num++;
							if (boolVariables == null)
							{
								throw new NullReferenceException();
							}
							continue;
						}
						Fsm.Event(sendEvent);
						FsmBool fsmBool2 = storeResult;
						fsmBool2.value = true;
						break;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				break;
			}
		}

		[Token(Token = "0x6000BB3")]
		[Address(RVA = "0xA8C1A8", Offset = "0xA8C1A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoolAnyTrue()
		{
		}
	}
}
