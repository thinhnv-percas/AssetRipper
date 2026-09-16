using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758674", Offset = "0x758674")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758674", Offset = "0x758674")]
	[Token(Token = "0x2000259")]
	public class BoolNoneTrue : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B5310", Offset = "0x7B5310")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5310", Offset = "0x7B5310")]
		[Token(Token = "0x40015E9")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool[] boolVariables;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5370", Offset = "0x7B5370")]
		[Token(Token = "0x40015EA")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent sendEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B53A8", Offset = "0x7B53A8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B53A8", Offset = "0x7B53A8")]
		[Token(Token = "0x40015EB")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B53F8", Offset = "0x7B53F8")]
		[Token(Token = "0x40015EC")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000BB8")]
		[Address(RVA = "0xA8C300", Offset = "0xA8C300", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.sendEvent = 0;\n\tthis.storeResult = 0;\n\tthis.boolVariables = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			sendEvent = null;
			storeResult = null;
			boolVariables = null;
		}

		[Token(Token = "0x6000BB9")]
		[Address(RVA = "0xA8C310", Offset = "0xA8C310", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BoolNoneTrue::DoNoneTrue(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoNoneTrue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000BBA")]
		[Address(RVA = "0xA8C404", Offset = "0xA8C404", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BoolNoneTrue::DoNoneTrue(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoNoneTrue();
		}

		[Token(Token = "0x6000BBB")]
		[Address(RVA = "0xA8C34C", Offset = "0xA8C34C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv147 = this.boolVariables;\n\tv71 = v147.Length;\n\tv15 = v147.Length == 0;\n\tif (v15) goto L_0052;\n\tv104 = v147.Length < 1;\n\tif (v104) goto L_0045;\nL_001A:\n\tv227 = v31 < v71;\n\tv67 = ~v227;\n\tif (v67) goto L_0055;\n\tv24 = HutongGames.PlayMaker.FsmBool::get_Value(v147[v31 @ X20_v9 (System.Int32)]);\n\tv240 = v24 == 0;\n\tv237 = ~v240;\n\tif (v237) goto L_FFFFFFFF;\n\tv147 = this.boolVariables;\n\tv71 = v147.Length;\n\tv31 = v31 + 1;\n\tv156 = v31 < v147.Length;\n\tif (v156) goto L_001A;\nL_0045:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\tgoto L_0049;\nL_0049:\n\tv72 = this.storeResult;\n\tv72.value = v78;\nL_0052:\n\treturn;\n\tv80 = new System.NullReferenceException();\nL_0055:\n\tv148 = new System.IndexOutOfRangeException();\n\tthrow v148;\n\tthrow System.NullReferenceException;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoNoneTrue()
		{
			FsmBool[] array = boolVariables;
			int num = array.Length;
			if (array.Length == 0)
			{
				return;
			}
			if (array.Length < 1)
			{
				goto IL_00e8;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < num)
				{
					if (array[num2].Value)
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
					goto IL_00e8;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			int value = 0;
			goto IL_015d;
			IL_015d:
			FsmBool fsmBool = storeResult;
			fsmBool.value = (byte)value != 0;
			return;
			IL_00e8:
			Fsm.Event(sendEvent);
			value = 1;
			goto IL_015d;
		}

		[Token(Token = "0x6000BBC")]
		[Address(RVA = "0xA8C408", Offset = "0xA8C408", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoolNoneTrue()
		{
		}
	}
}
