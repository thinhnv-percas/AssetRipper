using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763058", Offset = "0x763058")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763058", Offset = "0x763058")]
	[Token(Token = "0x2000437")]
	public class Vector2Operator : FsmStateAction
	{
		[Token(Token = "0x20004A1")]
		public enum Vector2Operation
		{
			[Token(Token = "0x40021F2")]
			DotProduct = 0,
			[Token(Token = "0x40021F3")]
			Distance = 1,
			[Token(Token = "0x40021F4")]
			Angle = 2,
			[Token(Token = "0x40021F5")]
			Add = 3,
			[Token(Token = "0x40021F6")]
			Subtract = 4,
			[Token(Token = "0x40021F7")]
			Multiply = 5,
			[Token(Token = "0x40021F8")]
			Divide = 6,
			[Token(Token = "0x40021F9")]
			Min = 7,
			[Token(Token = "0x40021FA")]
			Max = 8
		}

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DA564", Offset = "0x7DA564")]
		[Token(Token = "0x4001FDE")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector1;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DA5B0", Offset = "0x7DA5B0")]
		[Token(Token = "0x4001FDF")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 vector2;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DA5FC", Offset = "0x7DA5FC")]
		[Token(Token = "0x4001FE0")]
		[FieldOffset(Offset = "0x60")]
		public Vector2Operation operation;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7DA634", Offset = "0x7DA634")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DA634", Offset = "0x7DA634")]
		[Token(Token = "0x4001FE1")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector2 storeVector2Result;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7DA684", Offset = "0x7DA684")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DA684", Offset = "0x7DA684")]
		[Token(Token = "0x4001FE2")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat storeFloatResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DA6D4", Offset = "0x7DA6D4")]
		[Token(Token = "0x4001FE3")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x60014E5")]
		[Address(RVA = "0x987964", Offset = "0x987964", Length = "0x18")]
		public override void Reset()
		{
			vector1 = null;
			vector2 = null;
			everyFrame = false;
			operation = Vector2Operation.Add;
			storeVector2Result = null;
			storeFloatResult = null;
		}

		[Token(Token = "0x60014E6")]
		[Address(RVA = "0x98797C", Offset = "0x98797C", Length = "0x3C")]
		public override void OnEnter()
		{
			DoVector2Operator();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60014E7")]
		[Address(RVA = "0x987CA0", Offset = "0x987CA0", Length = "0x4")]
		public override void OnUpdate()
		{
			DoVector2Operator();
		}

		[Token(Token = "0x60014E8")]
		[Address(RVA = "0x9879B8", Offset = "0x9879B8", Length = "0x2E8")]
		private void DoVector2Operator()
		{
			//IL_00b3: Expected O, but got I
			if (vector1 != null && vector2 != null)
			{
				Vector2Operation vector2Operation = operation;
				bool flag = operation < Vector2Operation.Max;
				bool flag2 = !flag;
				int num = (int)(operation - 8);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					return;
				}
				int num2 = 25260032 + 3748;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ X9_v3 (System.Int32)+v75 @ X10_v2 (HutongGames.PlayMaker.Actions.Vector2Operator+Vector2Operation)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v100 @ X8_v11 (should have been resolved before IL gen)");
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60014E9")]
		[Address(RVA = "0x987CA4", Offset = "0x987CA4", Length = "0x10")]
		public Vector2Operator()
		{
			operation = Vector2Operation.Add;
		}
	}
}
