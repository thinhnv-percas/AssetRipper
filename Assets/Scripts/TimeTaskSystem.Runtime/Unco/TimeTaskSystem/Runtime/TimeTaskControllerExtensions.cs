using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.TimeTaskSystem.Runtime
{
	[Token(Token = "0x200000A")]
	public static class TimeTaskControllerExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600002B")]
		[Address(RVA = "0x8194904", Offset = "0x8194904", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tgoto L_0057;\nL_0057:\n\tinterfaceTailCallResult = Unco.TimeTaskSystem.Runtime.ITimeTaskController::CreateTimer(timeTaskController, duration, 0, 0, loop, elapsed, 0f);\n\treturn interfaceTailCallResult;\n")]
		public static TimerHandle CreateCounterTimer(this ITimeTaskController timeTaskController, float duration, float elapsed = 0f, bool loop = false)
		{
			return timeTaskController.CreateTimer(duration, countDown: false, hasInterval: false, loop, elapsed);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600002C")]
		[Address(RVA = "0x81949DC", Offset = "0x81949DC", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tgoto L_0057;\nL_0057:\n\tinterfaceTailCallResult = Unco.TimeTaskSystem.Runtime.ITimeTaskController::CreateTimer(timeTaskController, duration, 1, 0, loop, elapsed, 0f);\n\treturn interfaceTailCallResult;\n")]
		public static TimerHandle CreateCooldownTimer(this ITimeTaskController timeTaskController, float duration, float elapsed = 0f, bool loop = false)
		{
			return timeTaskController.CreateTimer(duration, countDown: true, hasInterval: false, loop, elapsed);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600002D")]
		[Address(RVA = "0x8194AB4", Offset = "0x8194AB4", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tgoto L_005C;\nL_005C:\n\tinterfaceTailCallResult = Unco.TimeTaskSystem.Runtime.ITimeTaskController::CreateTimer(timeTaskController, duration, 0, 1, loop, elapsed, updateInterval);\n\treturn interfaceTailCallResult;\n")]
		public static TimerHandle CreateIntervalCounterTimer(this ITimeTaskController timeTaskController, float duration, float updateInterval, float elapsed = 0f, bool loop = false)
		{
			return timeTaskController.CreateTimer(duration, countDown: false, hasInterval: true, loop, elapsed, updateInterval);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600002E")]
		[Address(RVA = "0x8194B98", Offset = "0x8194B98", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tgoto L_005C;\nL_005C:\n\tinterfaceTailCallResult = Unco.TimeTaskSystem.Runtime.ITimeTaskController::CreateTimer(timeTaskController, duration, 1, 1, loop, elapsed, updateInterval);\n\treturn interfaceTailCallResult;\n")]
		public static TimerHandle CreateIntervalCountdownTimer(this ITimeTaskController timeTaskController, float duration, float updateInterval, float elapsed = 0f, bool loop = false)
		{
			return timeTaskController.CreateTimer(duration, countDown: true, hasInterval: true, loop, elapsed, updateInterval);
		}
	}
}
