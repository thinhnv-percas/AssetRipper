using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758584", Offset = "0x758584")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758584", Offset = "0x758584")]
	[Token(Token = "0x2000256")]
	public class BoolAllTrue : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B4FD8", Offset = "0x7B4FD8")]
		[Readonly]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B4FD8", Offset = "0x7B4FD8")]
		[Token(Token = "0x40015DD")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool[] boolVariables;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5048", Offset = "0x7B5048")]
		[Token(Token = "0x40015DE")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent sendEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B5080", Offset = "0x7B5080")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5080", Offset = "0x7B5080")]
		[Token(Token = "0x40015DF")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B50D0", Offset = "0x7B50D0")]
		[Token(Token = "0x40015E0")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000BAA")]
		[Address(RVA = "0xA8BF90", Offset = "0xA8BF90", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.sendEvent = 0;\n\tthis.storeResult = 0;\n\tthis.boolVariables = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			sendEvent = null;
			storeResult = null;
			boolVariables = null;
		}

		[Token(Token = "0x6000BAB")]
		[Address(RVA = "0xA8BFA0", Offset = "0xA8BFA0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BoolAllTrue::DoAllTrue(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoAllTrue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000BAC")]
		[Address(RVA = "0xA8C094", Offset = "0xA8C094", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BoolAllTrue::DoAllTrue(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoAllTrue();
		}

		[Token(Token = "0x6000BAD")]
		[Address(RVA = "0xA8BFDC", Offset = "0xA8BFDC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv147 = this.boolVariables;\n\tv71 = v147.Length;\n\tv15 = v147.Length == 0;\n\tif (v15) goto L_0051;\n\tv104 = v147.Length < 1;\n\tif (v104) goto L_0044;\nL_001A:\n\tv227 = v31 < v71;\n\tv67 = ~v227;\n\tif (v67) goto L_0054;\n\tv24 = HutongGames.PlayMaker.FsmBool::get_Value(v147[v31 @ X20_v9 (System.Int32)]);\n\tv237 = v24 == 0;\n\tif (v237) goto L_FFFFFFFF;\n\tv147 = this.boolVariables;\n\tv71 = v147.Length;\n\tv31 = v31 + 1;\n\tv156 = v31 < v147.Length;\n\tif (v156) goto L_001A;\nL_0044:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\tgoto L_0048;\nL_0048:\n\tv72 = this.storeResult;\n\tv72.value = v78;\nL_0051:\n\treturn;\n\tv80 = new System.NullReferenceException();\nL_0054:\n\tv148 = new System.IndexOutOfRangeException();\n\tthrow v148;\n\tthrow System.NullReferenceException;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAllTrue()
		{
			FsmBool[] array = boolVariables;
			int num = array.Length;
			if (array.Length == 0)
			{
				return;
			}
			if (array.Length < 1)
			{
				goto IL_00dd;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < num)
				{
					if (!array[num2].Value)
					{
						break;
					}
					array = boolVariables;
					num = array.Length;
					num2++;
					if (num2 < array.Length)
					{
						continue;
					}
					goto IL_00dd;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			int value = 0;
			goto IL_0152;
			IL_0152:
			FsmBool fsmBool = storeResult;
			fsmBool.value = (byte)value != 0;
			return;
			IL_00dd:
			Fsm.Event(sendEvent);
			value = 1;
			goto IL_0152;
		}

		[Token(Token = "0x6000BAE")]
		[Address(RVA = "0xA8C098", Offset = "0xA8C098", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoolAllTrue()
		{
		}
	}
}
