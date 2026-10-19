using Cpp2ILInjected;

namespace _game.CoreGameKit.Tools
{
	[Token(Token = "0x20005A1")]
	public class LevelDetails
	{
		[Token(Token = "0x1700021A")]
		[field: Token(Token = "0x400134A")]
		[field: FieldOffset(Offset = "0x10")]
		public string LevelId
		{
			[Token(Token = "0x60017D3")]
			[Address(RVA = "0x3D30BC0", Offset = "0x3D30BC0", Length = "0x8")]
			get;
			[Token(Token = "0x60017D4")]
			[Address(RVA = "0x3D30BC8", Offset = "0x3D30BC8", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700021B")]
		[field: Token(Token = "0x400134B")]
		[field: FieldOffset(Offset = "0x18")]
		public string LevelName
		{
			[Token(Token = "0x60017D5")]
			[Address(RVA = "0x3D30BD0", Offset = "0x3D30BD0", Length = "0x8")]
			get;
			[Token(Token = "0x60017D6")]
			[Address(RVA = "0x3D30BD8", Offset = "0x3D30BD8", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700021C")]
		[field: Token(Token = "0x400134C")]
		[field: FieldOffset(Offset = "0x20")]
		public string EnvironmentId
		{
			[Token(Token = "0x60017D7")]
			[Address(RVA = "0x3D30BE0", Offset = "0x3D30BE0", Length = "0x8")]
			get;
			[Token(Token = "0x60017D8")]
			[Address(RVA = "0x3D30BE8", Offset = "0x3D30BE8", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700021D")]
		[field: Token(Token = "0x400134D")]
		[field: FieldOffset(Offset = "0x28")]
		public int SlotCount
		{
			[Token(Token = "0x60017D9")]
			[Address(RVA = "0x3D30BF0", Offset = "0x3D30BF0", Length = "0x8")]
			get;
			[Token(Token = "0x60017DA")]
			[Address(RVA = "0x3D30BF8", Offset = "0x3D30BF8", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700021E")]
		[field: Token(Token = "0x400134E")]
		[field: FieldOffset(Offset = "0x30")]
		public string Difficulty
		{
			[Token(Token = "0x60017DB")]
			[Address(RVA = "0x3D30C00", Offset = "0x3D30C00", Length = "0x8")]
			get;
			[Token(Token = "0x60017DC")]
			[Address(RVA = "0x3D30C08", Offset = "0x3D30C08", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700021F")]
		[field: Token(Token = "0x400134F")]
		[field: FieldOffset(Offset = "0x38")]
		public float Time
		{
			[Token(Token = "0x60017DD")]
			[Address(RVA = "0x3D30C10", Offset = "0x3D30C10", Length = "0x8")]
			get;
			[Token(Token = "0x60017DE")]
			[Address(RVA = "0x3D30C18", Offset = "0x3D30C18", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000220")]
		[field: Token(Token = "0x4001350")]
		[field: FieldOffset(Offset = "0x40")]
		public string Question
		{
			[Token(Token = "0x60017DF")]
			[Address(RVA = "0x3D30C20", Offset = "0x3D30C20", Length = "0x8")]
			get;
			[Token(Token = "0x60017E0")]
			[Address(RVA = "0x3D30C28", Offset = "0x3D30C28", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000221")]
		[field: Token(Token = "0x4001351")]
		[field: FieldOffset(Offset = "0x48")]
		public int AnswerCount
		{
			[Token(Token = "0x60017E1")]
			[Address(RVA = "0x3D30C30", Offset = "0x3D30C30", Length = "0x8")]
			get;
			[Token(Token = "0x60017E2")]
			[Address(RVA = "0x3D30C38", Offset = "0x3D30C38", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000222")]
		[field: Token(Token = "0x4001352")]
		[field: FieldOffset(Offset = "0x4C")]
		public int CorrectAnswerIndex
		{
			[Token(Token = "0x60017E3")]
			[Address(RVA = "0x3D30C40", Offset = "0x3D30C40", Length = "0x8")]
			get;
			[Token(Token = "0x60017E4")]
			[Address(RVA = "0x3D30C48", Offset = "0x3D30C48", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000223")]
		[field: Token(Token = "0x4001353")]
		[field: FieldOffset(Offset = "0x50")]
		public string UnlockedFeatureId
		{
			[Token(Token = "0x60017E5")]
			[Address(RVA = "0x3D30C50", Offset = "0x3D30C50", Length = "0x8")]
			get;
			[Token(Token = "0x60017E6")]
			[Address(RVA = "0x3D30C58", Offset = "0x3D30C58", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000224")]
		[field: Token(Token = "0x4001354")]
		[field: FieldOffset(Offset = "0x58")]
		public bool LandHome
		{
			[Token(Token = "0x60017E7")]
			[Address(RVA = "0x3D30C60", Offset = "0x3D30C60", Length = "0x8")]
			get;
			[Token(Token = "0x60017E8")]
			[Address(RVA = "0x3D30C68", Offset = "0x3D30C68", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000225")]
		[field: Token(Token = "0x4001355")]
		[field: FieldOffset(Offset = "0x59")]
		public bool HasReward
		{
			[Token(Token = "0x60017E9")]
			[Address(RVA = "0x3D30C70", Offset = "0x3D30C70", Length = "0x8")]
			get;
			[Token(Token = "0x60017EA")]
			[Address(RVA = "0x3D30C78", Offset = "0x3D30C78", Length = "0x8")]
			set;
		}

		[Token(Token = "0x60017EB")]
		[Address(RVA = "0x3D30C80", Offset = "0x3D30C80", Length = "0x8")]
		public LevelDetails()
		{
		}
	}
}
