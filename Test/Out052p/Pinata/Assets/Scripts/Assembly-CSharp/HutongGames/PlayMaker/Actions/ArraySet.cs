using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753D24", Offset = "0x753D24")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753D24", Offset = "0x753D24")]
	[Token(Token = "0x200017C")]
	public class ArraySet : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AA060", Offset = "0x7AA060")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AA060", Offset = "0x7AA060")]
		[Token(Token = "0x4001270")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AA0C0", Offset = "0x7AA0C0")]
		[Token(Token = "0x4001271")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt index;

		[RequiredField]
		[Attribute(Type = typeof(MatchElementTypeAttribute), RVA = "0x7AA0F8", Offset = "0x7AA0F8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AA0F8", Offset = "0x7AA0F8")]
		[Token(Token = "0x4001272")]
		[FieldOffset(Offset = "0x60")]
		public FsmVar value;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AA168", Offset = "0x7AA168")]
		[Token(Token = "0x4001273")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7AA1A0", Offset = "0x7AA1A0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AA1A0", Offset = "0x7AA1A0")]
		[Token(Token = "0x4001274")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent indexOutOfRange;

		[Token(Token = "0x600083E")]
		[Address(RVA = "0xA89D18", Offset = "0xA89D18", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.indexOutOfRange = 0;\n\tthis.index = 0;\n\tthis.value = 0;\n\tthis.everyFrame = 0;\n\tthis.array = 0;\n\treturn;\n")]
		public override void Reset()
		{
			indexOutOfRange = null;
			index = null;
			value = null;
			everyFrame = false;
			array = null;
		}

		[Token(Token = "0x600083F")]
		[Address(RVA = "0xA89D2C", Offset = "0xA89D2C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ArraySet::DoGetValue(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000840")]
		[Address(RVA = "0xA89E60", Offset = "0xA89E60", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ArraySet::DoGetValue(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetValue();
		}

		[Token(Token = "0x6000841")]
		[Address(RVA = "0xA89D68", Offset = "0xA89D68", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.array);\n\tv93 = v15 == 0;\n\tif (v93) goto L_0019;\n\treturn;\nL_0019:\n\tv161 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv162 = v161 & 0x80000000;\n\tv163 = v162 == 0;\n\tv164 = ~v163;\n\tif (v164) goto L_005E;\n\tv118 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv167 = HutongGames.PlayMaker.FsmArray::get_Length(this.array);\n\tv18 = v118 >= v167;\n\tif (v18) goto L_005E;\n\tHutongGames.PlayMaker.FsmVar::UpdateValue(this.value);\n\tv119 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv120 = HutongGames.PlayMaker.FsmVar::GetValue(this.value);\n\tHutongGames.PlayMaker.FsmArray::Set(this.array, v119, v120);\n\treturn;\nL_005E:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.indexOutOfRange);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetValue()
		{
			//IL_004e: Expected I4, but got I8
			if (array.IsNone)
			{
				return;
			}
			int num = index.Value;
			if ((int)(num & 0x80000000L) == 0)
			{
				int num2 = index.Value;
				int length = array.Length;
				if (num2 < length)
				{
					value.UpdateValue();
					int num3 = index.Value;
					object obj = value.GetValue();
					array.Set(num3, obj);
					return;
				}
			}
			Fsm.Event(indexOutOfRange);
		}

		[Token(Token = "0x6000842")]
		[Address(RVA = "0xA89E64", Offset = "0xA89E64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArraySet()
		{
		}
	}
}
