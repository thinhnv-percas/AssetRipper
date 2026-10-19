using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using _game.Systems.ElephantStorage;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Core
{
	[Token(Token = "0x200062A")]
	public class BoosterService : IBoosterService
	{
		[Token(Token = "0x4001549")]
		[FieldOffset(Offset = "0x10")]
		private readonly BoosterDatabase _database;

		[Token(Token = "0x400154A")]
		[FieldOffset(Offset = "0x18")]
		private BoosterSaveData _boosterData;

		[Token(Token = "0x400154B")]
		[FieldOffset(Offset = "0x20")]
		private EventBus _eventBus;

		[Token(Token = "0x400154C")]
		[FieldOffset(Offset = "0x28")]
		private IPlayerDataHandler _dataHandler;

		[CompilerGenerated]
		[Token(Token = "0x400154D")]
		[FieldOffset(Offset = "0x30")]
		private Action<string, int> _003COnCountChanged_003Ek__BackingField;

		[Token(Token = "0x1400001F")]
		public event Action<string, int> OnCountChanged
		{
			[CompilerGenerated]
			[Token(Token = "0x6001A5E")]
			[Address(RVA = "0x3D52F04", Offset = "0x3D52F04", Length = "0xB4")]
			add
			{
				global::AssetRipperInjected.RecoveryStub.Missing("BoosterService::add_OnCountChanged");
			}
			[CompilerGenerated]
			[Token(Token = "0x6001A5F")]
			[Address(RVA = "0x3D52FB8", Offset = "0x3D52FB8", Length = "0xB4")]
			remove
			{
				global::AssetRipperInjected.RecoveryStub.Missing("BoosterService::remove_OnCountChanged");
			}
		}

		[Token(Token = "0x6001A60")]
		[Address(RVA = "0x3D525A8", Offset = "0x3D525A8", Length = "0x34")]
		public BoosterService(BoosterDatabase database)
		{
			_database = database;
		}

		[Inject(false)]
		[Token(Token = "0x6001A61")]
		[Address(RVA = "0x3D5306C", Offset = "0x3D5306C", Length = "0x50")]
		private void Inject(EventBus eventBus, BoosterSaveData boosterData, IPlayerDataHandler dataHandler)
		{
			_eventBus = eventBus;
			_boosterData = boosterData;
			_dataHandler = dataHandler;
		}

		[Token(Token = "0x6001A62")]
		[Address(RVA = "0x3D530BC", Offset = "0x3D530BC", Length = "0x18")]
		public int GetCount(string boosterId)
		{
			return _boosterData.GetCount(boosterId);
		}

		[Token(Token = "0x6001A63")]
		[Address(RVA = "0x3D530D4", Offset = "0x3D530D4", Length = "0x28")]
		public bool HasBooster(string boosterId)
		{
			int count = _boosterData.GetCount(boosterId);
			bool flag = count < 0;
			bool flag2 = count == 0;
			int num = count ^ count;
			int num2 = count & num;
			bool flag3 = num2 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			return flag4 && flag5;
		}

		[Token(Token = "0x6001A64")]
		[Address(RVA = "0x3D530FC", Offset = "0x3D530FC", Length = "0x18")]
		public BoosterDefinition GetDefinition(string boosterId)
		{
			return _database.GetDefinition(boosterId);
		}

		[Token(Token = "0x6001A65")]
		[Address(RVA = "0x3D53114", Offset = "0x3D53114", Length = "0x68")]
		public bool IsUnlocked(string boosterId)
		{
			BoosterSaveData boosterData = _boosterData;
			string item = default(string);
			return boosterData.UnlockedIds.Contains(item);
		}

		[Token(Token = "0x6001A66")]
		[Address(RVA = "0x3D5317C", Offset = "0x3D5317C", Length = "0x224")]
		public unsafe void AddBoosters(string boosterId, int amount, string sourceType)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterService::AddBoosters");
		}

		[Token(Token = "0x6001A67")]
		[Address(RVA = "0x3D533A0", Offset = "0x3D533A0", Length = "0x174")]
		public bool UseBooster(string boosterId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterService::UseBooster");
			return default;
		}

		[Token(Token = "0x6001A68")]
		[Address(RVA = "0x3D53514", Offset = "0x3D53514", Length = "0x220")]
		public unsafe void ResetAll()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterService::ResetAll");
		}

		[Token(Token = "0x6001A69")]
		[Address(RVA = "0x3D53734", Offset = "0x3D53734", Length = "0xD8")]
		public void MarkUnlocked(string boosterId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoosterService::MarkUnlocked");
		}
	}
}
