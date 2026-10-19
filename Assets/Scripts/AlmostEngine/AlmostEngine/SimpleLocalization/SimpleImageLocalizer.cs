using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AlmostEngine.SimpleLocalization
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(RawImage))]
	[Token(Token = "0x2000074")]
	public class SimpleImageLocalizer : ISimpleLocalizer
	{
		[Serializable]
		[Token(Token = "0x2000075")]
		public class Localization : SerializableDictionary<string, Texture>
		{
			[Token(Token = "0x600021B")]
			[Address(RVA = "0x3C4BD8C", Offset = "0x3C4BD8C", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tAlmostEngine.SerializableDictionary`2<System.String, UnityEngine.Texture>::.ctor(this);\n\treturn;\n")]
			public Localization()
			{
			}
		}

		[HideInInspector]
		[Token(Token = "0x4000264")]
		[FieldOffset(Offset = "0x20")]
		public Texture m_OriginalTexture;

		[Token(Token = "0x4000265")]
		[FieldOffset(Offset = "0x28")]
		public Localization m_Localisations;

		[Token(Token = "0x4000266")]
		[FieldOffset(Offset = "0x30")]
		private RawImage m_Image;

		[Token(Token = "0x6000216")]
		[Address(RVA = "0x3C4B9C0", Offset = "0x3C4B9C0", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_002A:\n\tv62 = UnityEngine.Object::op_Equality(this.m_Image, 0);\n\tv65 = ~v62;\n\tif (v65) goto L_003A;\n\tv70 = UnityEngine.Component::GetComponent(this);\n\tthis.m_Image = v70;\nL_003A:\n\tgoto L_004A;\nL_0023:\n\tgoto L_002A;\nL_004A:\n\tv89 = AlmostEngine.SimpleLocalization.SimpleImageLocalizer::OnLanguageChanged(v89, v84.m_CurrentLanguageID);\nL_004A:\n\treturn;\n")]
		private void OnEnable()
		{
			if (m_Image == null)
			{
				RawImage component = GetComponent<RawImage>();
				m_Image = component;
			}
			SimpleImageLocalizer simpleImageLocalizer = default(SimpleImageLocalizer);
			simpleImageLocalizer.OnLanguageChanged(SimpleLocalizationLanguagesAsset.m_CurrentLanguageID);
		}

		[Token(Token = "0x6000217")]
		[Address(RVA = "0x3C4BAA4", Offset = "0x3C4BAA4", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv53 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>::ContainsKey(this.m_Localisations, ID);\n\tv82 = ~v53;\n\tif (v82) goto L_0062;\n\tv134 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>::get_Item(this.m_Localisations, ID);\n\tgoto L_0035;\nL_0035:\n\tv94 = UnityEngine.Object::op_Inequality(v134, 0);\n\tv97 = ~v94;\n\tif (v97) goto L_0062;\n\tv68 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>::get_Item(this.m_Localisations, ID);\n\tUnityEngine.UI.RawImage::set_texture(this.m_Image, v68);\n\treturn;\nL_0062:\n\tv103 = AlmostEngine.SimpleLocalization.SimpleImageLocalizer::Restore(v103);\nL_0062:\n\treturn;\n")]
		public override void OnLanguageChanged(string ID)
		{
			if (((Dictionary<object, object>)(object)m_Localisations).ContainsKey((object)ID))
			{
				UnityEngine.Object obj = (UnityEngine.Object)((Dictionary<object, object>)(object)m_Localisations)[(object)ID];
				if (obj != null)
				{
					Texture texture = (Texture)((Dictionary<object, object>)(object)m_Localisations)[(object)ID];
					m_Image.texture = texture;
					return;
				}
			}
			SimpleImageLocalizer simpleImageLocalizer = default(SimpleImageLocalizer);
			simpleImageLocalizer.Restore();
		}

		[Token(Token = "0x6000218")]
		[Address(RVA = "0x3C4BBCC", Offset = "0x3C4BBCC", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_Image;\n\tthis.m_OriginalTexture = v0.texture;\n\treturn;\n")]
		public override void Save()
		{
			RawImage image = m_Image;
			m_OriginalTexture = image.texture;
		}

		[Token(Token = "0x6000219")]
		[Address(RVA = "0x3C4BBEC", Offset = "0x3C4BBEC", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this.m_Image, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_0035;\n\tgoto L_0044;\nL_0035:\n\tgoto L_0039;\nL_0039:\n\tv89 = UnityEngine.Object::op_Equality(this.m_OriginalTexture, 0);\n\tv92 = v89 == 0;\n\tif (v92) goto L_005A;\nL_0044:\n\treturn;\nL_005A:\n\tUnityEngine.UI.RawImage::set_texture(this.m_Image, this.m_OriginalTexture);\n\treturn;\n")]
		public override void Restore()
		{
			if (!(m_Image == null) && !(m_OriginalTexture == null))
			{
				m_Image.texture = m_OriginalTexture;
			}
		}

		[Token(Token = "0x600021A")]
		[Address(RVA = "0x3C4BCE8", Offset = "0x3C4BCE8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn;\nL_0017:\n\tv45 = new AlmostEngine.SimpleLocalization.SimpleImageLocalizer+Localization();\n\tgoto L_0028;\nL_0028:\n\tAlmostEngine.SimpleLocalization.SimpleImageLocalizer+Localization::.ctor(v45);\n\tthis.m_Localisations = v45;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n")]
		public SimpleImageLocalizer()
		{
			Localization localisations = new Localization();
			m_Localisations = localisations;
		}
	}
}
