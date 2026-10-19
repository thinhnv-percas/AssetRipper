using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AlmostEngine.SimpleLocalization
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Text))]
	[Token(Token = "0x2000077")]
	public class SimpleTextLocalizer : ISimpleLocalizer
	{
		[Serializable]
		[Token(Token = "0x2000078")]
		public class Localization : SerializableDictionary<string, string>
		{
			[Token(Token = "0x6000224")]
			[Address(RVA = "0x3C4C2EC", Offset = "0x3C4C2EC", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tAlmostEngine.SerializableDictionary`2<System.String, System.String>::.ctor(this);\n\treturn;\n")]
			public Localization()
			{
			}
		}

		[HideInInspector]
		[Token(Token = "0x400026A")]
		[FieldOffset(Offset = "0x20")]
		public string m_OriginalText;

		[Token(Token = "0x400026B")]
		[FieldOffset(Offset = "0x28")]
		public Localization m_Localisations;

		[Token(Token = "0x400026C")]
		[FieldOffset(Offset = "0x30")]
		private Text m_Text;

		[Token(Token = "0x600021F")]
		[Address(RVA = "0x3C4BF08", Offset = "0x3C4BF08", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_002A:\n\tv62 = UnityEngine.Object::op_Equality(this.m_Text, 0);\n\tv65 = ~v62;\n\tif (v65) goto L_003A;\n\tv70 = UnityEngine.Component::GetComponent(this);\n\tthis.m_Text = v70;\nL_003A:\n\tgoto L_004A;\nL_0023:\n\tgoto L_002A;\nL_004A:\n\tv89 = AlmostEngine.SimpleLocalization.SimpleTextLocalizer::OnLanguageChanged(v89, v84.m_CurrentLanguageID);\nL_004A:\n\treturn;\n")]
		private void OnEnable()
		{
			if (m_Text == null)
			{
				Text component = GetComponent<Text>();
				m_Text = component;
			}
			SimpleTextLocalizer simpleTextLocalizer = default(SimpleTextLocalizer);
			simpleTextLocalizer.OnLanguageChanged(SimpleLocalizationLanguagesAsset.m_CurrentLanguageID);
		}

		[Token(Token = "0x6000220")]
		[Address(RVA = "0x3C4BFEC", Offset = "0x3C4BFEC", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv53 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>::ContainsKey(this.m_Localisations, ID);\n\tv77 = ~v53;\n\tif (v77) goto L_0055;\n\tv122 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>::get_Item(this.m_Localisations, ID);\n\tv81 = System.String::op_Inequality(v122, \"\");\n\tv83 = ~v81;\n\tif (v83) goto L_0055;\n\tv63 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>::get_Item(this.m_Localisations, ID);\n\tv107 = UnityEngine.UI.Text::set_text(v107, v63);\n\treturn;\nL_0055:\n\tv89 = AlmostEngine.SimpleLocalization.SimpleTextLocalizer::Restore(v89);\nL_0055:\n\treturn;\n")]
		public override void OnLanguageChanged(string ID)
		{
			if (((Dictionary<object, object>)(object)m_Localisations).ContainsKey((object)ID))
			{
				string text = (string)((Dictionary<object, object>)(object)m_Localisations)[(object)ID];
				if (text != "")
				{
					string text2 = (string)((Dictionary<object, object>)(object)m_Localisations)[(object)ID];
					Text text3 = default(Text);
					text3.text = text2;
					return;
				}
			}
			SimpleTextLocalizer simpleTextLocalizer = default(SimpleTextLocalizer);
			simpleTextLocalizer.Restore();
		}

		[Token(Token = "0x6000221")]
		[Address(RVA = "0x3C4C0F0", Offset = "0x3C4C0F0", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = UnityEngine.UI.Text::get_text(this.m_Text);\n\tthis.m_OriginalText = v17;\n\treturn;\n")]
		public override void Save()
		{
			string text = m_Text.text;
			m_OriginalText = text;
		}

		[Token(Token = "0x6000222")]
		[Address(RVA = "0x3C4C134", Offset = "0x3C4C134", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this.m_Text, 0);\n\tv65 = v55 == 0;\n\tif (v65) goto L_0039;\n\tgoto L_0044;\nL_0039:\n\tv84 = System.String::op_Equality(this.m_OriginalText, \"\");\n\tv91 = v84 == 0;\n\tif (v91) goto L_0053;\nL_0044:\n\treturn;\nL_0053:\n\tv112 = UnityEngine.UI.Text::set_text(v112, this.m_OriginalText);\nL_0053:\n\treturn;\n")]
		public override void Restore()
		{
			if (!(m_Text == null) && !(m_OriginalText == ""))
			{
				Text text = default(Text);
				text.text = m_OriginalText;
			}
		}

		[Token(Token = "0x6000223")]
		[Address(RVA = "0x3C4C224", Offset = "0x3C4C224", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\treturn;\nL_001E:\n\tthis.m_OriginalText = \"\";\n\tv54 = new AlmostEngine.SimpleLocalization.SimpleTextLocalizer+Localization();\n\tgoto L_0032;\nL_0032:\n\tAlmostEngine.SimpleLocalization.SimpleTextLocalizer+Localization::.ctor(v54);\n\tthis.m_Localisations = v54;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n")]
		public SimpleTextLocalizer()
		{
			m_OriginalText = "";
			Localization localisations = new Localization();
			m_Localisations = localisations;
		}
	}
}
