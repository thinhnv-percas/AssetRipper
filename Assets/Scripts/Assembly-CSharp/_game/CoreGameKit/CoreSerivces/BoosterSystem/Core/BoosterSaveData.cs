using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Core
{
	[Serializable]
	[Token(Token = "0x2000626")]
	public class BoosterSaveData
	{
		[Token(Token = "0x400153F")]
		[FieldOffset(Offset = "0x10")]
		public List<BoosterCountEntry> Counts;

		[Token(Token = "0x4001540")]
		[FieldOffset(Offset = "0x18")]
		public List<string> UnlockedIds;

		[Token(Token = "0x6001A56")]
		[Address(RVA = "0x3D528C4", Offset = "0x3D528C4", Length = "0x15C")]
		public unsafe int GetCount(string boosterId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterSaveData::GetCount");
			return default;
		}

		[Token(Token = "0x6001A57")]
		[Address(RVA = "0x3D52A20", Offset = "0x3D52A20", Length = "0x230")]
		public unsafe void SetCount(string boosterId, int count)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterSaveData::SetCount");
		}

		[Token(Token = "0x6001A58")]
		[Address(RVA = "0x3D52C58", Offset = "0x3D52C58", Length = "0x64")]
		public bool IsUnlocked(string boosterId)
		{
			string item = default(string);
			return UnlockedIds.Contains(item);
		}

		[Token(Token = "0x6001A59")]
		[Address(RVA = "0x3D52CBC", Offset = "0x3D52CBC", Length = "0xF4")]
		public void MarkUnlocked(string boosterId)
		{
			if (!UnlockedIds.Contains(boosterId))
			{
				List<string> unlockedIds = UnlockedIds;
				unlockedIds.Add(boosterId);
			}
		}

		[Token(Token = "0x6001A5A")]
		[Address(RVA = "0x3D52DB0", Offset = "0x3D52DB0", Length = "0xE0")]
		public BoosterSaveData()
		{
			List<BoosterCountEntry> counts = new List<BoosterCountEntry>();
			Counts = counts;
			List<string> unlockedIds = new List<string>();
			UnlockedIds = unlockedIds;
		}
	}
}
