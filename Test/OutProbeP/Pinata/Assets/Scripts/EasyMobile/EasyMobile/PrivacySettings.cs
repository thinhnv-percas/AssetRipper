using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200008E")]
	public class PrivacySettings
	{
		[SerializeField]
		[Token(Token = "0x400035A")]
		[FieldOffset(Offset = "0x10")]
		private ConsentDialog mDefaultConsentDialog;

		[SerializeField]
		[Token(Token = "0x400035B")]
		[FieldOffset(Offset = "0x18")]
		private ConsentDialogComposerSettings mConsentDialogComposerSettings;

		[Token(Token = "0x170001B2")]
		public ConsentDialog DefaultConsentDialog
		{
			[Token(Token = "0x60005F7")]
			[Address(RVA = "0xFD2720", Offset = "0xFD2720", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultConsentDialog;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultConsentDialog;
			}
		}

		[Token(Token = "0x60005F8")]
		[Address(RVA = "0xFD2728", Offset = "0xFD2728", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PrivacySettings()
		{
		}
	}
}
