using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200006E")]
	public class NativeApisSettings
	{
		[SerializeField]
		[Token(Token = "0x400028C")]
		[FieldOffset(Offset = "0x10")]
		private bool mIsMediaEnabled;

		[SerializeField]
		[Token(Token = "0x400028D")]
		[FieldOffset(Offset = "0x18")]
		private MediaApiSettings mMediaSettings;

		[SerializeField]
		[Token(Token = "0x400028E")]
		[FieldOffset(Offset = "0x20")]
		private bool mIsContactsEnabled;

		[SerializeField]
		[Token(Token = "0x400028F")]
		[FieldOffset(Offset = "0x28")]
		private ContactsApiSettings mContactsSettings;

		[Token(Token = "0x1700017A")]
		public bool IsMediaEnabled
		{
			[Token(Token = "0x600051C")]
			[Address(RVA = "0xFCE4A8", Offset = "0xFCE4A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIsMediaEnabled;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsMediaEnabled;
			}
		}

		[Token(Token = "0x1700017B")]
		public MediaApiSettings Media
		{
			[Token(Token = "0x600051D")]
			[Address(RVA = "0xFCE4B0", Offset = "0xFCE4B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mMediaSettings;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Media;
			}
		}

		[Token(Token = "0x1700017C")]
		public bool IsContactsEnabled
		{
			[Token(Token = "0x600051E")]
			[Address(RVA = "0xFCE4B8", Offset = "0xFCE4B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIsContactsEnabled;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsContactsEnabled;
			}
		}

		[Token(Token = "0x1700017D")]
		public ContactsApiSettings Contacts
		{
			[Token(Token = "0x600051F")]
			[Address(RVA = "0xFCE4C0", Offset = "0xFCE4C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mContactsSettings;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Contacts;
			}
		}

		[Token(Token = "0x6000520")]
		[Address(RVA = "0xFCE4C8", Offset = "0xFCE4C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NativeApisSettings()
		{
		}
	}
}
