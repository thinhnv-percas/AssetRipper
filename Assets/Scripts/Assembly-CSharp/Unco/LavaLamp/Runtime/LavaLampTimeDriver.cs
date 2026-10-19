using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace Unco.LavaLamp.Runtime
{
	[Token(Token = "0x20007F9")]
	public static class LavaLampTimeDriver
	{
		[Token(Token = "0x4001A8C")]
		private static readonly int s_unscaledTimeId;

		[Token(Token = "0x4001A8D")]
		private static bool s_injected;

		[Token(Token = "0x60021C1")]
		[Address(RVA = "0x3DC9550", Offset = "0x3DC9550", Length = "0x6C")]
		private static void Tick()
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			Shader.SetGlobalFloat(s_unscaledTimeId, realtimeSinceStartup);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		[Token(Token = "0x60021C2")]
		[Address(RVA = "0x3DC95BC", Offset = "0x3DC95BC", Length = "0xF4")]
		private static void RegisterRuntime()
		{
			InjectIntoPlayerLoop();
			Action value = RemoveFromPlayerLoop;
			Application.quitting -= value;
			Action value2 = RemoveFromPlayerLoop;
			Application.quitting += value2;
		}

		[Token(Token = "0x60021C3")]
		[Address(RVA = "0x3DC96B0", Offset = "0x3DC96B0", Length = "0x38C")]
		private unsafe static void InjectIntoPlayerLoop()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LavaLampTimeDriver::InjectIntoPlayerLoop");
		}

		[Token(Token = "0x60021C4")]
		[Address(RVA = "0x3DC9A3C", Offset = "0x3DC9A3C", Length = "0x2F4")]
		private unsafe static void RemoveFromPlayerLoop()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LavaLampTimeDriver::RemoveFromPlayerLoop");
		}

		[Token(Token = "0x60021C5")]
		[Address(RVA = "0x3DC9D30", Offset = "0x3DC9D30", Length = "0x74")]
		static LavaLampTimeDriver()
		{
			int num = Shader.PropertyToID("_LavaLampUnscaledTime");
			s_unscaledTimeId = num;
		}
	}
}
