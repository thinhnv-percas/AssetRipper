using System;
using Cpp2ILInjected;

namespace _game.Systems.ElephantStorage
{
	[Serializable]
	[Token(Token = "0x2000784")]
	public class HealthStorageData
	{
		[Token(Token = "0x1700030A")]
		[field: Token(Token = "0x4001907")]
		[field: FieldOffset(Offset = "0x10")]
		public int CurrentHealth
		{
			[Token(Token = "0x6001FC1")]
			[Address(RVA = "0x3D94274", Offset = "0x3D94274", Length = "0x8")]
			get;
			[Token(Token = "0x6001FC2")]
			[Address(RVA = "0x3D9427C", Offset = "0x3D9427C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700030B")]
		[field: Token(Token = "0x4001908")]
		[field: FieldOffset(Offset = "0x14")]
		public float InfiniteDuration
		{
			[Token(Token = "0x6001FC3")]
			[Address(RVA = "0x3D94284", Offset = "0x3D94284", Length = "0x8")]
			get;
			[Token(Token = "0x6001FC4")]
			[Address(RVA = "0x3D9428C", Offset = "0x3D9428C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700030C")]
		[field: Token(Token = "0x4001909")]
		[field: FieldOffset(Offset = "0x18")]
		public string PendingHealthTime
		{
			[Token(Token = "0x6001FC5")]
			[Address(RVA = "0x3D94294", Offset = "0x3D94294", Length = "0x8")]
			get;
			[Token(Token = "0x6001FC6")]
			[Address(RVA = "0x3D9429C", Offset = "0x3D9429C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700030D")]
		[field: Token(Token = "0x400190A")]
		[field: FieldOffset(Offset = "0x20")]
		public bool InitialInfiniteAcquired
		{
			[Token(Token = "0x6001FC7")]
			[Address(RVA = "0x3D942A4", Offset = "0x3D942A4", Length = "0x8")]
			get;
			[Token(Token = "0x6001FC8")]
			[Address(RVA = "0x3D942AC", Offset = "0x3D942AC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6001FC9")]
		[Address(RVA = "0x3D940F8", Offset = "0x3D940F8", Length = "0x64")]
		public HealthStorageData()
		{
			PendingHealthTime = "";
		}
	}
}
