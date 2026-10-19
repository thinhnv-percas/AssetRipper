using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Card
{
	[Token(Token = "0x20003A4")]
	public static class BudgetGuard
	{
		[Token(Token = "0x20003A5")]
		public readonly struct Verdict
		{
			[Token(Token = "0x4000B1F")]
			[FieldOffset(Offset = "0x0")]
			public readonly bool Breached;

			[Token(Token = "0x4000B20")]
			[FieldOffset(Offset = "0x8")]
			public readonly string Reason;

			[Token(Token = "0x4000B21")]
			public static readonly Verdict Ok = default(Verdict);

			[Token(Token = "0x6000F49")]
			[Address(RVA = "0x3C9A6C8", Offset = "0x3C9A6C8", Length = "0x10")]
			public Verdict(bool breached, string reason)
			{
				Breached = breached;
				Reason = reason;
			}
		}

		[Token(Token = "0x4000B1D")]
		public const long TokenBudget = 300000L;

		[Token(Token = "0x4000B1E")]
		public const double TimeBudgetMinutes = 45.0;

		[Token(Token = "0x6000F48")]
		[Address(RVA = "0x3C9A514", Offset = "0x3C9A514", Length = "0x1B4")]
		public static Verdict Evaluate(LevelCardPhase phase, long contextTokens, double elapsedSeconds)
		{
			//IL_0145: Expected I4, but got I8
			if (phase == LevelCardPhase.Generating && contextTokens >= 300001)
			{
				int num = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				int num2 = 300000;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				object arg2 = default(object);
				string text = $"auto-cancelled: token budget exceeded ({arg:n0} > {arg2:n0} tokens)";
			}
			else
			{
				bool flag = elapsedSeconds < 4.658155777863713E+18;
				bool flag2 = elapsedSeconds == 4.658155777863713E+18;
				bool flag3 = elapsedSeconds == elapsedSeconds;
				bool flag4 = !flag3;
				bool flag5 = flag == flag4;
				bool flag6 = !flag5;
				if (!(flag6 || flag2))
				{
					double num3 = elapsedSeconds / 4.633641066610819E+18;
					double num4 = num3;
					int num5 = 192761856 + 1336;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					int num2 = 0;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg3 = default(object);
					object arg4 = default(object);
					string text2 = $"auto-cancelled: time budget exceeded ({arg3:0.0} min > {arg4:0} min)";
				}
			}
			return Verdict.Ok;
		}
	}
}
