using System;
using Cpp2ILInjected;

namespace _game.Scripts.Notifications
{
	[Token(Token = "0x2000012")]
	public interface IGameNotification
	{
		[Token(Token = "0x2000013")]
		public enum GameNotificationType
		{
			[Token(Token = "0x4000044")]
			Default = 0,
			[Token(Token = "0x4000045")]
			Test = 1,
			[Token(Token = "0x4000046")]
			ShopDailyRefresh = 2,
			[Token(Token = "0x4000047")]
			ShopDailyFree = 3,
			[Token(Token = "0x4000048")]
			NextFight = 4,
			[Token(Token = "0x4000049")]
			BossFight = 5,
			[Token(Token = "0x400004A")]
			Training = 6,
			[Token(Token = "0x400004B")]
			PiggyBank1 = 7,
			[Token(Token = "0x400004C")]
			PiggyBank2 = 8,
			[Token(Token = "0x400004D")]
			BagUnlock1 = 9,
			[Token(Token = "0x400004E")]
			BagUnlock2 = 10,
			[Token(Token = "0x400004F")]
			BagUnlock3 = 11,
			[Token(Token = "0x4000050")]
			DailyFreeOffer1 = 12,
			[Token(Token = "0x4000051")]
			DailyFreeOffer2 = 13,
			[Token(Token = "0x4000052")]
			DailyFreeOffer3 = 14,
			[Token(Token = "0x4000053")]
			FightFreeOffer1 = 15,
			[Token(Token = "0x4000054")]
			FightFreeOffer2 = 16,
			[Token(Token = "0x4000055")]
			FightFreeOffer3 = 17,
			[Token(Token = "0x4000056")]
			MissionPass1 = 18,
			[Token(Token = "0x4000057")]
			MissionPass2 = 19,
			[Token(Token = "0x4000058")]
			MissionPass3 = 20,
			[Token(Token = "0x4000059")]
			SlapBagStack = 21,
			[Token(Token = "0x400005A")]
			EnergyRefilled = 22,
			[Token(Token = "0x400005B")]
			NoShieldsHeadsUp = 23,
			[Token(Token = "0x400005C")]
			ShopFreeHeadsUp = 24,
			[Token(Token = "0x400005D")]
			Comeback = 25,
			[Token(Token = "0x400005E")]
			DanaMissionReady = 26
		}

		[Token(Token = "0x1700001E")]
		GameNotificationType? Type
		{
			[Token(Token = "0x6000078")]
			get;
			[Token(Token = "0x6000079")]
			set;
		}

		[Token(Token = "0x1700001F")]
		int? Id
		{
			[Token(Token = "0x600007A")]
			get;
			[Token(Token = "0x600007B")]
			set;
		}

		[Token(Token = "0x17000020")]
		string Title
		{
			[Token(Token = "0x600007C")]
			get;
			[Token(Token = "0x600007D")]
			set;
		}

		[Token(Token = "0x17000021")]
		string Body
		{
			[Token(Token = "0x600007E")]
			get;
			[Token(Token = "0x600007F")]
			set;
		}

		[Token(Token = "0x17000022")]
		string Subtitle
		{
			[Token(Token = "0x6000080")]
			get;
			[Token(Token = "0x6000081")]
			set;
		}

		[Token(Token = "0x17000023")]
		string Data
		{
			[Token(Token = "0x6000082")]
			get;
			[Token(Token = "0x6000083")]
			set;
		}

		[Token(Token = "0x17000024")]
		string notification_id
		{
			[Token(Token = "0x6000084")]
			get;
			[Token(Token = "0x6000085")]
			set;
		}

		[Token(Token = "0x17000025")]
		string message_id
		{
			[Token(Token = "0x6000086")]
			get;
			[Token(Token = "0x6000087")]
			set;
		}

		[Token(Token = "0x17000026")]
		string job_id
		{
			[Token(Token = "0x6000088")]
			get;
			[Token(Token = "0x6000089")]
			set;
		}

		[Token(Token = "0x17000027")]
		string scheduled_at
		{
			[Token(Token = "0x600008A")]
			get;
			[Token(Token = "0x600008B")]
			set;
		}

		[Token(Token = "0x17000028")]
		string Group
		{
			[Token(Token = "0x600008C")]
			get;
			[Token(Token = "0x600008D")]
			set;
		}

		[Token(Token = "0x17000029")]
		int? BadgeNumber
		{
			[Token(Token = "0x600008E")]
			get;
			[Token(Token = "0x600008F")]
			set;
		}

		[Token(Token = "0x1700002A")]
		bool ShouldAutoCancel
		{
			[Token(Token = "0x6000090")]
			get;
			[Token(Token = "0x6000091")]
			set;
		}

		[Token(Token = "0x1700002B")]
		DateTime? DeliveryTime
		{
			[Token(Token = "0x6000092")]
			get;
			[Token(Token = "0x6000093")]
			set;
		}

		[Token(Token = "0x1700002C")]
		bool Scheduled
		{
			[Token(Token = "0x6000094")]
			get;
		}

		[Token(Token = "0x1700002D")]
		string SmallIcon
		{
			[Token(Token = "0x6000095")]
			get;
			[Token(Token = "0x6000096")]
			set;
		}

		[Token(Token = "0x1700002E")]
		string LargeIcon
		{
			[Token(Token = "0x6000097")]
			get;
			[Token(Token = "0x6000098")]
			set;
		}
	}
}
