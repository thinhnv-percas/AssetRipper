using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck
{
	[Token(Token = "0x20003F2")]
	public static class WinStuckVerdict
	{
		[Token(Token = "0x600109E")]
		[Address(RVA = "0x3CB5D4C", Offset = "0x3CB5D4C", Length = "0xBC")]
		public static string Compute(bool isSuppressed, int moldCount, bool isWon)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WinStuckVerdict::Compute");
			return default;
		}

		[Token(Token = "0x600109F")]
		[Address(RVA = "0x3CB5E08", Offset = "0x3CB5E08", Length = "0x4FC")]
		public static string FormatBoosters(IReadOnlyDictionary<string, int> usage)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WinStuckVerdict::FormatBoosters");
			return default;
		}

		[Token(Token = "0x60010A0")]
		[Address(RVA = "0x3CB6304", Offset = "0x3CB6304", Length = "0x98")]
		public static string FormatMoldState(int moldCount, int blockingCount)
		{
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			object arg2 = default(object);
			return $"molds={arg} blocking={arg2}";
		}
	}
}
