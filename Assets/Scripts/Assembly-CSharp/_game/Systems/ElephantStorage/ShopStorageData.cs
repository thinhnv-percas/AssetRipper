using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.Systems.ElephantStorage
{
	[Serializable]
	[Token(Token = "0x2000785")]
	public class ShopStorageData
	{
		[Token(Token = "0x1700030E")]
		[field: Token(Token = "0x400190B")]
		[field: FieldOffset(Offset = "0x10")]
		public List<string> PurchaseHistory
		{
			[Token(Token = "0x6001FCA")]
			[Address(RVA = "0x3D942B4", Offset = "0x3D942B4", Length = "0x8")]
			get;
			[Token(Token = "0x6001FCB")]
			[Address(RVA = "0x3D942BC", Offset = "0x3D942BC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6001FCC")]
		[Address(RVA = "0x3D9415C", Offset = "0x3D9415C", Length = "0x8C")]
		public ShopStorageData()
		{
			List<string> list = new List<string>();
			PurchaseHistory = list;
		}
	}
}
