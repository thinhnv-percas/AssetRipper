using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.RewardSystem;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Token(Token = "0x2000663")]
	public class LevelContext
	{
		[CompilerGenerated]
		[Token(Token = "0x40015D9")]
		[FieldOffset(Offset = "0x18")]
		internal readonly LootDrop _003CReward_003Ek__BackingField;

		[Token(Token = "0x17000294")]
		[field: Token(Token = "0x40015D8")]
		[field: FieldOffset(Offset = "0x10")]
		public int Level
		{
			[Token(Token = "0x6001AF3")]
			[Address(RVA = "0x3D57920", Offset = "0x3D57920", Length = "0x8")]
			get;
		}

		[Token(Token = "0x17000295")]
		public LootDrop Reward
		{
			[CompilerGenerated]
			[Token(Token = "0x6001AF4")]
			[Address(RVA = "0x3D57928", Offset = "0x3D57928", Length = "0x14")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LevelContext::get_Reward");
				return default;
			}
		}

		[Token(Token = "0x17000296")]
		[field: Token(Token = "0x40015DA")]
		[field: FieldOffset(Offset = "0x30")]
		public bool IsLoop
		{
			[Token(Token = "0x6001AF5")]
			[Address(RVA = "0x3D5793C", Offset = "0x3D5793C", Length = "0x8")]
			get;
		}

		[Token(Token = "0x17000297")]
		[field: Token(Token = "0x40015DB")]
		[field: FieldOffset(Offset = "0x34")]
		public int LoopTurnId
		{
			[Token(Token = "0x6001AF6")]
			[Address(RVA = "0x3D57944", Offset = "0x3D57944", Length = "0x8")]
			get;
		}

		[Token(Token = "0x6001AF7")]
		[Address(RVA = "0x3D5794C", Offset = "0x3D5794C", Length = "0x6C")]
		public LevelContext(int level, LootDrop reward, bool isLoop, int loopTurnId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelContext::.ctor");
		}
	}
}
