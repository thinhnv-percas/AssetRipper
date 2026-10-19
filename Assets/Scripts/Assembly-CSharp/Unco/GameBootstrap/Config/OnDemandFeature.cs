using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.GameBootstrap.Config
{
	[Serializable]
	[Token(Token = "0x20007EA")]
	public class OnDemandFeature
	{
		[SerializeField]
		[Token(Token = "0x4001A72")]
		[FieldOffset(Offset = "0x10")]
		private string _tag;

		[SerializeField]
		[Token(Token = "0x4001A73")]
		[FieldOffset(Offset = "0x18")]
		internal InstallerGroupSo _groupSo;

		[Token(Token = "0x17000346")]
		public string Tag
		{
			[Token(Token = "0x6002177")]
			[Address(RVA = "0x3DC6970", Offset = "0x3DC6970", Length = "0x8")]
			get
			{
				return _tag;
			}
		}

		[Token(Token = "0x17000347")]
		public InstallRequest InstallRequest
		{
			[Token(Token = "0x6002178")]
			[Address(RVA = "0x3DC1C84", Offset = "0x3DC1C84", Length = "0x18")]
			get
			{
				return _groupSo.CreateInstallRequest();
			}
		}

		[Token(Token = "0x6002179")]
		[Address(RVA = "0x3DC6A0C", Offset = "0x3DC6A0C", Length = "0x50")]
		public OnDemandFeature(string tag, InstallerGroupSo groupSo)
		{
			_tag = tag;
			_groupSo = groupSo;
		}
	}
}
