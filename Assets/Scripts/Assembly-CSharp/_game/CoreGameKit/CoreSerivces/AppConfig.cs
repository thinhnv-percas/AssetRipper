using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.CoreSerivces
{
	[Token(Token = "0x2000605")]
	public class AppConfig
	{
		[Token(Token = "0x1700026D")]
		[field: Token(Token = "0x40014D6")]
		[field: FieldOffset(Offset = "0x10")]
		public string Version
		{
			[Token(Token = "0x60019CA")]
			[Address(RVA = "0x3D4DC28", Offset = "0x3D4DC28", Length = "0x8")]
			get;
		}

		[Token(Token = "0x1700026E")]
		[field: Token(Token = "0x40014D7")]
		[field: FieldOffset(Offset = "0x18")]
		public string BuildNumber
		{
			[Token(Token = "0x60019CB")]
			[Address(RVA = "0x3D4DC30", Offset = "0x3D4DC30", Length = "0x8")]
			get;
		}

		[Token(Token = "0x1700026F")]
		public string FullVersion
		{
			[Token(Token = "0x60019CD")]
			[Address(RVA = "0x3D4DD8C", Offset = "0x3D4DD8C", Length = "0x144")]
			get
			{
				return "v" + Version + " (" + BuildNumber + ")";
			}
		}

		[Token(Token = "0x60019CC")]
		[Address(RVA = "0x3D4DC38", Offset = "0x3D4DC38", Length = "0x154")]
		public AppConfig()
		{
			Version = Application.version;
			TextAsset textAsset = Resources.Load<TextAsset>("BuildNumber");
			BuildNumber = ((!(textAsset != null)) ? "0" : textAsset.text.Trim());
		}
	}
}
