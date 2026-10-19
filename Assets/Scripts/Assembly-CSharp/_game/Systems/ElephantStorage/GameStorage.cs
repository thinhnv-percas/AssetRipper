using System;
using System.Collections.Generic;
using Systems.FlowSystem.Scripts.Core;
using Systems.TutorialSystem.Scripts;
using Cpp2ILInjected;
using ElephantSDK;
using Unco.AdSystem;
using Unco.RealTimeSystem.Runtime;
using Unco.ResourceSystem;
using Unco.SettingsSystem.Core;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Data;

namespace _game.Systems.ElephantStorage
{
	[Serializable]
	[Token(Token = "0x2000783")]
	public class GameStorage : IElephantStorage
	{
		[Token(Token = "0x170002FF")]
		[field: Token(Token = "0x40018FC")]
		[field: FieldOffset(Offset = "0x10")]
		public HealthStorageData Health
		{
			[Token(Token = "0x6001FAA")]
			[Address(RVA = "0x3D93CBC", Offset = "0x3D93CBC", Length = "0x8")]
			get;
			[Token(Token = "0x6001FAB")]
			[Address(RVA = "0x3D93CC4", Offset = "0x3D93CC4", Length = "0x8")]
			set;
		} = new HealthStorageData
		{
			PendingHealthTime = ""
		};

		[Token(Token = "0x17000300")]
		[field: Token(Token = "0x40018FD")]
		[field: FieldOffset(Offset = "0x18")]
		public BoosterSaveData Boosters
		{
			[Token(Token = "0x6001FAC")]
			[Address(RVA = "0x3D93CCC", Offset = "0x3D93CCC", Length = "0x8")]
			get;
			[Token(Token = "0x6001FAD")]
			[Address(RVA = "0x3D93CD4", Offset = "0x3D93CD4", Length = "0x8")]
			set;
		} = new BoosterSaveData();

		[Token(Token = "0x17000301")]
		[field: Token(Token = "0x40018FE")]
		[field: FieldOffset(Offset = "0x20")]
		public LevelProgressPref Progress
		{
			[Token(Token = "0x6001FAE")]
			[Address(RVA = "0x3D93CDC", Offset = "0x3D93CDC", Length = "0x8")]
			get;
			[Token(Token = "0x6001FAF")]
			[Address(RVA = "0x3D93CE4", Offset = "0x3D93CE4", Length = "0x8")]
			set;
		} = new LevelProgressPref();

		[Token(Token = "0x17000302")]
		[field: Token(Token = "0x40018FF")]
		[field: FieldOffset(Offset = "0x28")]
		public ResourceStorageData Resources
		{
			[Token(Token = "0x6001FB0")]
			[Address(RVA = "0x3D93CEC", Offset = "0x3D93CEC", Length = "0x8")]
			get;
			[Token(Token = "0x6001FB1")]
			[Address(RVA = "0x3D93CF4", Offset = "0x3D93CF4", Length = "0x8")]
			set;
		} = new ResourceStorageData();

		[Token(Token = "0x17000303")]
		[field: Token(Token = "0x4001900")]
		[field: FieldOffset(Offset = "0x30")]
		public MonetizationStorageData Monetization
		{
			[Token(Token = "0x6001FB2")]
			[Address(RVA = "0x3D93CFC", Offset = "0x3D93CFC", Length = "0x8")]
			get;
			[Token(Token = "0x6001FB3")]
			[Address(RVA = "0x3D93D04", Offset = "0x3D93D04", Length = "0x8")]
			set;
		} = new MonetizationStorageData();

		[Token(Token = "0x17000304")]
		[field: Token(Token = "0x4001901")]
		[field: FieldOffset(Offset = "0x38")]
		public SettingsStorageData Settings
		{
			[Token(Token = "0x6001FB4")]
			[Address(RVA = "0x3D93D0C", Offset = "0x3D93D0C", Length = "0x8")]
			get;
			[Token(Token = "0x6001FB5")]
			[Address(RVA = "0x3D93D14", Offset = "0x3D93D14", Length = "0x8")]
			set;
		} = new SettingsStorageData();

		[Token(Token = "0x17000305")]
		[field: Token(Token = "0x4001902")]
		[field: FieldOffset(Offset = "0x40")]
		public TutorialStorageData Tutorials
		{
			[Token(Token = "0x6001FB6")]
			[Address(RVA = "0x3D93D1C", Offset = "0x3D93D1C", Length = "0x8")]
			get;
			[Token(Token = "0x6001FB7")]
			[Address(RVA = "0x3D93D24", Offset = "0x3D93D24", Length = "0x8")]
			set;
		} = new TutorialStorageData();

		[Token(Token = "0x17000306")]
		[field: Token(Token = "0x4001903")]
		[field: FieldOffset(Offset = "0x48")]
		public FlowStorageData Flows
		{
			[Token(Token = "0x6001FB8")]
			[Address(RVA = "0x3D93D2C", Offset = "0x3D93D2C", Length = "0x8")]
			get;
			[Token(Token = "0x6001FB9")]
			[Address(RVA = "0x3D93D34", Offset = "0x3D93D34", Length = "0x8")]
			set;
		} = new FlowStorageData();

		[Token(Token = "0x17000307")]
		[field: Token(Token = "0x4001904")]
		[field: FieldOffset(Offset = "0x50")]
		public ShopStorageData Shop
		{
			[Token(Token = "0x6001FBA")]
			[Address(RVA = "0x3D93D3C", Offset = "0x3D93D3C", Length = "0x8")]
			get;
			[Token(Token = "0x6001FBB")]
			[Address(RVA = "0x3D93D44", Offset = "0x3D93D44", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000308")]
		[field: Token(Token = "0x4001905")]
		[field: FieldOffset(Offset = "0x58")]
		public RealTimeStorageData RealTime
		{
			[Token(Token = "0x6001FBC")]
			[Address(RVA = "0x3D93D4C", Offset = "0x3D93D4C", Length = "0x8")]
			get;
			[Token(Token = "0x6001FBD")]
			[Address(RVA = "0x3D93D54", Offset = "0x3D93D54", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000309")]
		[field: Token(Token = "0x4001906")]
		[field: FieldOffset(Offset = "0x60")]
		public bool MigrationDone
		{
			[Token(Token = "0x6001FBE")]
			[Address(RVA = "0x3D93D5C", Offset = "0x3D93D5C", Length = "0x8")]
			get;
			[Token(Token = "0x6001FBF")]
			[Address(RVA = "0x3D93D64", Offset = "0x3D93D64", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6001FC0")]
		[Address(RVA = "0x3D93D6C", Offset = "0x3D93D6C", Length = "0x38C")]
		public GameStorage()
		{
			ShopStorageData shopStorageData = new ShopStorageData();
			List<string> _003CPurchaseHistory_003Ek__BackingField = new List<string>();
			shopStorageData.PurchaseHistory = _003CPurchaseHistory_003Ek__BackingField;
			Shop = shopStorageData;
			RealTimeStorageData realTimeStorageData = new RealTimeStorageData();
			List<RealTimerPref> _003CTimers_003Ek__BackingField = new List<RealTimerPref>();
			realTimeStorageData.Timers = _003CTimers_003Ek__BackingField;
			RealTime = realTimeStorageData;
		}
	}
}
