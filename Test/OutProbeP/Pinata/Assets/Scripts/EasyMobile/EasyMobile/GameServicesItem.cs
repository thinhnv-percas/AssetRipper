using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200003D")]
	public class GameServicesItem
	{
		[SerializeField]
		[Token(Token = "0x40001B7")]
		[FieldOffset(Offset = "0x10")]
		private string _name;

		[SerializeField]
		[Token(Token = "0x40001B8")]
		[FieldOffset(Offset = "0x18")]
		private string _iosId;

		[SerializeField]
		[Token(Token = "0x40001B9")]
		[FieldOffset(Offset = "0x20")]
		private string _androidId;

		[Token(Token = "0x17000105")]
		public string Name
		{
			[Token(Token = "0x6000389")]
			[Address(RVA = "0xBF19C4", Offset = "0xBF19C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
		}

		[Token(Token = "0x17000106")]
		public string IOSId
		{
			[Token(Token = "0x600038A")]
			[Address(RVA = "0xBF19CC", Offset = "0xBF19CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._iosId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IOSId;
			}
		}

		[Token(Token = "0x17000107")]
		public string AndroidId
		{
			[Token(Token = "0x600038B")]
			[Address(RVA = "0xBF19D4", Offset = "0xBF19D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._androidId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AndroidId;
			}
		}

		[Token(Token = "0x17000108")]
		public string Id
		{
			[Token(Token = "0x600038C")]
			[Address(RVA = "0xBF19DC", Offset = "0xBF19DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._androidId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AndroidId;
			}
		}

		[Token(Token = "0x600038D")]
		[Address(RVA = "0xBF19E4", Offset = "0xBF19E4", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._name = name;\n\tthis._iosId = iosId;\n\tthis._androidId = androidId;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameServicesItem(string name, string iosId, string androidId)
		{
			_name = name;
			_iosId = iosId;
			_androidId = androidId;
		}
	}
}
