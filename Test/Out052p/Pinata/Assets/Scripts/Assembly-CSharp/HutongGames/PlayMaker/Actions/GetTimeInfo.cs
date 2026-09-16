using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FB9C", Offset = "0x75FB9C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FB9C", Offset = "0x75FB9C")]
	[Token(Token = "0x2000392")]
	public class GetTimeInfo : FsmStateAction
	{
		[Token(Token = "0x200049D")]
		public enum TimeInfo
		{
			[Token(Token = "0x40021D2")]
			DeltaTime = 0,
			[Token(Token = "0x40021D3")]
			TimeScale = 1,
			[Token(Token = "0x40021D4")]
			SmoothDeltaTime = 2,
			[Token(Token = "0x40021D5")]
			TimeInCurrentState = 3,
			[Token(Token = "0x40021D6")]
			TimeSinceStartup = 4,
			[Token(Token = "0x40021D7")]
			TimeSinceLevelLoad = 5,
			[Token(Token = "0x40021D8")]
			RealTimeSinceStartup = 6,
			[Token(Token = "0x40021D9")]
			RealTimeInCurrentState = 7
		}

		[Token(Token = "0x4001C8E")]
		[FieldOffset(Offset = "0x4C")]
		public TimeInfo getInfo;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CD16C", Offset = "0x7CD16C")]
		[Token(Token = "0x4001C8F")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat storeValue;

		[Token(Token = "0x4001C90")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x60011C0")]
		[Address(RVA = "0xA367F4", Offset = "0xA367F4", Length = "0x14")]
		public override void Reset()
		{
			storeValue = null;
			getInfo = TimeInfo.TimeSinceLevelLoad;
			everyFrame = false;
		}

		[Token(Token = "0x60011C1")]
		[Address(RVA = "0xA36808", Offset = "0xA36808", Length = "0x3C")]
		public override void OnEnter()
		{
			DoGetTimeInfo();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60011C2")]
		[Address(RVA = "0xA3694C", Offset = "0xA3694C", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetTimeInfo();
		}

		[Token(Token = "0x60011C3")]
		[Address(RVA = "0xA36844", Offset = "0xA36844", Length = "0x108")]
		private void DoGetTimeInfo()
		{
			//IL_008f: Expected O, but got I
			TimeInfo timeInfo = getInfo;
			bool flag = getInfo < TimeInfo.RealTimeInCurrentState;
			bool flag2 = !flag;
			int num = (int)(getInfo - 7);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25264128 + 2136;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X9_v2 (System.Int32)+v12 @ X8_v1 (HutongGames.PlayMaker.Actions.GetTimeInfo+TimeInfo)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v27 @ X8_v3 (should have been resolved before IL gen)");
			}
			FsmFloat fsmFloat = storeValue;
			fsmFloat.Value = 0f;
		}

		[Token(Token = "0x60011C4")]
		[Address(RVA = "0xA36950", Offset = "0xA36950", Length = "0x8")]
		public GetTimeInfo()
		{
		}
	}
}
