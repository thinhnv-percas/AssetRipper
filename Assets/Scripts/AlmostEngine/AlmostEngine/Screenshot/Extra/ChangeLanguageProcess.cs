using AlmostEngine.SimpleLocalization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot.Extra
{
	[Token(Token = "0x200005F")]
	public class ChangeLanguageProcess : ScreenshotProcess
	{
		[Token(Token = "0x4000233")]
		[FieldOffset(Offset = "0x28")]
		public string m_LanguageID;

		[Token(Token = "0x60001C6")]
		[Address(RVA = "0x3C48078", Offset = "0x3C48078", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0029:\n\tUnityEngine.Debug::Log(v52);\n\tgoto L_0037;\nL_0037:\n\tAlmostEngine.SimpleLocalization.SimpleLocalizationLanguagesAsset::SetLanguage(this.m_LanguageID);\n\treturn;\nL_0023:\n\tv52 = System.String::Concat(\"Change language process! \", this.m_LanguageID);\n\tgoto L_0029;\n")]
		public override void Process(ScreenshotResolution res)
		{
			string message = "Change language process! " + m_LanguageID;
			Debug.Log(message);
			SimpleLocalizationLanguagesAsset.SetLanguage(m_LanguageID);
		}

		[Token(Token = "0x60001C7")]
		[Address(RVA = "0x3C4825C", Offset = "0x3C4825C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tAlmostEngine.Screenshot.ScreenshotProcess::.ctor(this);\n\treturn;\n")]
		public ChangeLanguageProcess()
		{
		}
	}
}
