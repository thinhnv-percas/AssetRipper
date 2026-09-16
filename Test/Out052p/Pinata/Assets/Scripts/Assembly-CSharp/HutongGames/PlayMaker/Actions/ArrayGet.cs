using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753B44", Offset = "0x753B44")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753B44", Offset = "0x753B44")]
	[Token(Token = "0x2000176")]
	public class ArrayGet : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A98E8", Offset = "0x7A98E8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A98E8", Offset = "0x7A98E8")]
		[Token(Token = "0x4001254")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9948", Offset = "0x7A9948")]
		[Token(Token = "0x4001255")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt index;

		[RequiredField]
		[Attribute(Type = typeof(MatchElementTypeAttribute), RVA = "0x7A9980", Offset = "0x7A9980")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A9980", Offset = "0x7A9980")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9980", Offset = "0x7A9980")]
		[Token(Token = "0x4001256")]
		[FieldOffset(Offset = "0x60")]
		public FsmVar storeValue;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9A04", Offset = "0x7A9A04")]
		[Token(Token = "0x4001257")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A9A3C", Offset = "0x7A9A3C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A9A3C", Offset = "0x7A9A3C")]
		[Token(Token = "0x4001258")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent indexOutOfRange;

		[Token(Token = "0x6000827")]
		[Address(RVA = "0xA89568", Offset = "0xA89568", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.indexOutOfRange = 0;\n\tthis.index = 0;\n\tthis.storeValue = 0;\n\tthis.everyFrame = 0;\n\tthis.array = 0;\n\treturn;\n")]
		public override void Reset()
		{
			indexOutOfRange = null;
			index = null;
			storeValue = null;
			everyFrame = false;
			array = null;
		}

		[Token(Token = "0x6000828")]
		[Address(RVA = "0xA8957C", Offset = "0xA8957C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ArrayGet::DoGetValue(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000829")]
		[Address(RVA = "0xA896B0", Offset = "0xA896B0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ArrayGet::DoGetValue(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetValue();
		}

		[Token(Token = "0x600082A")]
		[Address(RVA = "0xA895B8", Offset = "0xA895B8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.array);\n\tv93 = v15 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_001D;\n\tv129 = HutongGames.PlayMaker.FsmVar::get_IsNone(this.storeValue);\n\tv127 = v129 == 0;\n\tif (v127) goto L_0022;\nL_001D:\n\treturn;\nL_0022:\n\tv165 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv166 = v165 & 0x80000000;\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tif (v168) goto L_0061;\n\tv118 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv171 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv18 = v118 >= v171;\n\tif (v18) goto L_0061;\n\tv119 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv120 = HutongGames.PlayMaker.FsmArray::Get(this.array, v119);\n\tHutongGames.PlayMaker.FsmVar::SetValue(this.storeValue, v120);\n\treturn;\nL_0061:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.indexOutOfRange);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetValue()
		{
			//IL_0085: Expected I4, but got I8
			if (array.IsNone || storeValue.IsNone)
			{
				return;
			}
			int value = index.Value;
			if ((int)(value & 0x80000000L) == 0)
			{
				int value2 = index.Value;
				int length = array.Length;
				if (value2 < length)
				{
					int value3 = index.Value;
					object value4 = array.Get(value3);
					storeValue.SetValue(value4);
					return;
				}
			}
			Fsm.Event(indexOutOfRange);
		}

		[Token(Token = "0x600082B")]
		[Address(RVA = "0xA896B4", Offset = "0xA896B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayGet()
		{
		}
	}
}
