using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RemoteManagementSystem;

namespace _game.CoreGameKit.BaseLayer.Services
{
	[Token(Token = "0x2000659")]
	public class KeepPlayingCostService
	{
		[Token(Token = "0x40015CD")]
		private const int FallbackCost = 100;

		[Token(Token = "0x40015CE")]
		[FieldOffset(Offset = "0x10")]
		private int _attemptCount;

		[Token(Token = "0x40015CF")]
		[FieldOffset(Offset = "0x18")]
		private KeepPlayingConfig _config;

		[Token(Token = "0x17000292")]
		public int AttemptCount
		{
			[Token(Token = "0x6001AE7")]
			[Address(RVA = "0x3D57898", Offset = "0x3D57898", Length = "0x8")]
			get
			{
				return _attemptCount;
			}
		}

		[Inject(false)]
		[Token(Token = "0x6001AE4")]
		[Address(RVA = "0x3D577C4", Offset = "0x3D577C4", Length = "0x74")]
		public void Construct(RemoteConfigManager remoteConfigManager)
		{
			KeepPlayingConfig json = remoteConfigManager.GetJson<KeepPlayingConfig>(RemoteKey.keep_playing_config);
			_config = json;
		}

		[Token(Token = "0x6001AE5")]
		[Address(RVA = "0x3D57838", Offset = "0x3D57838", Length = "0x50")]
		public int GetCurrentCost()
		{
			//IL_009a: Expected O, but got I4
			KeepPlayingConfig config = _config;
			if (_config != null)
			{
				int[] costTiers = config.CostTiers;
				if (config.CostTiers != null && costTiers.Length != 0)
				{
					int num = AttemptCount;
					int num2 = costTiers.Length - 1;
					object obj = AttemptCount - costTiers.Length;
					bool flag = (nint)obj < 0;
					int num3 = AttemptCount ^ costTiers.Length;
					int num4 = (int)(AttemptCount ^ (nint)obj);
					int num5 = num3 & num4;
					bool flag2 = num5 < 0;
					if (flag == flag2)
					{
						num = num2;
					}
					return costTiers[num];
				}
			}
			return 100;
		}

		[Token(Token = "0x6001AE6")]
		[Address(RVA = "0x3D57888", Offset = "0x3D57888", Length = "0x10")]
		public void IncrementAttempt()
		{
			int attemptCount = AttemptCount + 1;
			_attemptCount = attemptCount;
		}

		[Token(Token = "0x6001AE8")]
		[Address(RVA = "0x3D578A0", Offset = "0x3D578A0", Length = "0x8")]
		public KeepPlayingCostService()
		{
		}
	}
}
