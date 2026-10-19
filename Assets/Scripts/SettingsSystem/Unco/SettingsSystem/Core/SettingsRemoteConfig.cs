using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.SettingsSystem.Core
{
	[Serializable]
	[Token(Token = "0x2000006")]
	public class SettingsRemoteConfig
	{
		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x10")]
		public int Sound;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x14")]
		public int Music;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x18")]
		public int Haptic;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x1C")]
		public int Notification;

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x7AF2238", Offset = "0x7AF2238", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SettingsRemoteConfig()
		{
		}
	}
}
