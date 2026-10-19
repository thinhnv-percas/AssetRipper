using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.SimpleLocalization
{
	[CreateAssetMenu(fileName = "LocalizationLanguages", menuName = "AlmostEngine/Simple Localization/LocalizationLanguages")]
	[Token(Token = "0x2000076")]
	public class SimpleLocalizationLanguagesAsset : ScriptableObject
	{
		[Token(Token = "0x4000267")]
		[FieldOffset(Offset = "0x18")]
		public string m_DefaultLanguage;

		[Token(Token = "0x4000268")]
		[FieldOffset(Offset = "0x20")]
		public List<string> m_Languages;

		[Token(Token = "0x4000269")]
		public static string m_CurrentLanguageID = "";

		[Token(Token = "0x600021C")]
		[Address(RVA = "0x3C48164", Offset = "0x3C48164", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0032:\n\tv71 = UnityEngine.Object::FindObjectsOfType();\n\tv85 = v71.Length < 1;\n\tif (v85) goto L_0062;\n\tv130 = 0;\nL_004C:\n\tv159 = AlmostEngine.SimpleLocalization.ISimpleLocalizer::OnLanguageChanged(v71[v130 @ X21_v8 (System.Int32)], id);\n\tv130 = v130 + 1;\n\tv141 = v130 < v71.Length;\n\tif (v141) goto L_004C;\nL_0062:\n\treturn;\nL_0022:\n\tgoto L_0028;\nL_0028:\n\tv59.m_CurrentLanguageID = id;\n\tgoto L_0032;\n")]
		public static void SetLanguage(string id)
		{
			m_CurrentLanguageID = id;
			ISimpleLocalizer[] array = Object.FindObjectsOfType<ISimpleLocalizer>();
			if (array.Length >= 1)
			{
				int num = 0;
				do
				{
					array[num].OnLanguageChanged(id);
					num++;
				}
				while (num < array.Length);
			}
		}

		[Token(Token = "0x600021D")]
		[Address(RVA = "0x3C4BDE4", Offset = "0x3C4BDE4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tthis.m_Languages = v61;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\nL_0025:\n\tthis.m_DefaultLanguage = \"eng\";\n\tv61 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v61);\n")]
		public SimpleLocalizationLanguagesAsset()
		{
			m_DefaultLanguage = "eng";
			List<string> languages = new List<string>();
			m_Languages = languages;
		}
	}
}
