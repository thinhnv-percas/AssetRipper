using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763648", Offset = "0x763648")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763648", Offset = "0x763648")]
	[Token(Token = "0x200044A")]
	public class Vector3Operator : FsmStateAction
	{
		[Token(Token = "0x20004A2")]
		public enum Vector3Operation
		{
			[Token(Token = "0x40021FC")]
			DotProduct = 0,
			[Token(Token = "0x40021FD")]
			CrossProduct = 1,
			[Token(Token = "0x40021FE")]
			Distance = 2,
			[Token(Token = "0x40021FF")]
			Angle = 3,
			[Token(Token = "0x4002200")]
			Project = 4,
			[Token(Token = "0x4002201")]
			Reflect = 5,
			[Token(Token = "0x4002202")]
			Add = 6,
			[Token(Token = "0x4002203")]
			Subtract = 7,
			[Token(Token = "0x4002204")]
			Multiply = 8,
			[Token(Token = "0x4002205")]
			Divide = 9,
			[Token(Token = "0x4002206")]
			Min = 10,
			[Token(Token = "0x4002207")]
			Max = 11
		}

		[RequiredField]
		[Token(Token = "0x4002029")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector1;

		[RequiredField]
		[Token(Token = "0x400202A")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 vector2;

		[Token(Token = "0x400202B")]
		[FieldOffset(Offset = "0x60")]
		public Vector3Operation operation;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DB080", Offset = "0x7DB080")]
		[Token(Token = "0x400202C")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 storeVector3Result;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7DB094", Offset = "0x7DB094")]
		[Token(Token = "0x400202D")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat storeFloatResult;

		[Token(Token = "0x400202E")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6001538")]
		[Address(RVA = "0x989654", Offset = "0x989654", Length = "0x18")]
		public override void Reset()
		{
			vector1 = null;
			vector2 = null;
			everyFrame = false;
			operation = Vector3Operation.Add;
			storeVector3Result = null;
			storeFloatResult = null;
		}

		[Token(Token = "0x6001539")]
		[Address(RVA = "0x98966C", Offset = "0x98966C", Length = "0x3C")]
		public override void OnEnter()
		{
			DoVector3Operator();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600153A")]
		[Address(RVA = "0x989AE8", Offset = "0x989AE8", Length = "0x4")]
		public override void OnUpdate()
		{
			DoVector3Operator();
		}

		[Token(Token = "0x600153B")]
		[Address(RVA = "0x9896A8", Offset = "0x9896A8", Length = "0x440")]
		private void DoVector3Operator()
		{
			//IL_00b7: Expected O, but got I
			Vector3 value = vector1.Value;
			Vector3 value2 = vector2.Value;
			Vector3Operation vector3Operation = operation;
			bool flag = operation < Vector3Operation.Max;
			bool flag2 = !flag;
			int num = (int)(operation - 11);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25260032 + 3784;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X9_v2 (System.Int32)+v133 @ X8_v3 (HutongGames.PlayMaker.Actions.Vector3Operator+Vector3Operation)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v132 @ X8_v5 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600153C")]
		[Address(RVA = "0x989AEC", Offset = "0x989AEC", Length = "0x10")]
		public Vector3Operator()
		{
			operation = Vector3Operation.Add;
		}
	}
}
