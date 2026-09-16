using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200008F")]
	public class ConsentDialogComposerSettings
	{
		[SerializeField]
		[Token(Token = "0x400035C")]
		[FieldOffset(Offset = "0x10")]
		private int mToggleSelectedIndex;

		[SerializeField]
		[Token(Token = "0x400035D")]
		[FieldOffset(Offset = "0x14")]
		private int mButtonSelectedIndex;

		[SerializeField]
		[Token(Token = "0x400035E")]
		[FieldOffset(Offset = "0x18")]
		private bool mEnableCopyPasteMode;

		[Token(Token = "0x60005F9")]
		[Address(RVA = "0xA53F30", Offset = "0xA53F30", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConsentDialogComposerSettings()
		{
		}
	}
}
