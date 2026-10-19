using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AlmostEngine.Screenshot.Extra
{
	[Token(Token = "0x2000056")]
	public class RawImageDisplayer : MonoBehaviour
	{
		[Token(Token = "0x2000057")]
		public enum RatioScaleMode
		{
			[Token(Token = "0x400021B")]
			WIDTH = 0,
			[Token(Token = "0x400021C")]
			HEIGHT = 1
		}

		[Token(Token = "0x4000214")]
		[FieldOffset(Offset = "0x20")]
		public string m_FileName;

		[Token(Token = "0x4000215")]
		[FieldOffset(Offset = "0x28")]
		public RawImage m_RawImage;

		[Token(Token = "0x4000216")]
		[FieldOffset(Offset = "0x30")]
		private float m_DefaultSize;

		[Token(Token = "0x4000217")]
		[FieldOffset(Offset = "0x34")]
		private float m_DefaultRatio;

		[Token(Token = "0x4000218")]
		[FieldOffset(Offset = "0x38")]
		public bool m_AdaptRatio;

		[Token(Token = "0x4000219")]
		[FieldOffset(Offset = "0x3C")]
		public RatioScaleMode m_RatioScaleMode;

		[Token(Token = "0x60001A3")]
		[Address(RVA = "0x3C46794", Offset = "0x3C46794", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_002F:\n\tv66 = UnityEngine.Object::op_Equality(this.m_RawImage, 0);\n\tv70 = ~v66;\n\tif (v70) goto L_003E;\n\tv77 = UnityEngine.Component::GetComponent(this);\n\tthis.m_RawImage = v77;\nL_003E:\n\tv86 = UnityEngine.Component::GetComponent(this);\n\tv88 = this.m_RatioScaleMode == 0;\n\tif (v88) goto L_0053;\n\tv92 = UnityEngine.RectTransform::get_rect(v86);\n\tthis.m_DefaultSize = v92.height;\n\tv174 = UnityEngine.Component::GetComponent(this);\n\tv127 = v174 == 0;\n\tv119 = ~v127;\n\tif (v119) goto L_005F;\n\tgoto L_008E;\nL_0053:\n\tv108 = UnityEngine.RectTransform::get_rect(v86);\n\tthis.m_DefaultSize = v108.width;\n\tv174 = UnityEngine.Component::GetComponent(this);\nL_005F:\n\tv109 = UnityEngine.RectTransform::get_rect(v174);\n\tv117 = UnityEngine.Component::GetComponent(this);\n\tv181 = UnityEngine.RectTransform::get_rect(v117);\n\tv147 = v109.width / v181.height;\n\tthis.m_DefaultRatio = v147;\n\tv154 = System.String::op_Inequality(this.m_FileName, \"\");\n\tv156 = ~v154;\n\tif (v156) goto L_008D;\n\tAlmostEngine.Screenshot.Extra.RawImageDisplayer::Load(this);\n\treturn;\nL_008D:\n\treturn;\nL_008E:\n\tthrow System.NullReferenceException;\nL_0028:\n\tgoto L_002F;\n")]
		private void Awake()
		{
			if (m_RawImage == null)
			{
				RawImage component = GetComponent<RawImage>();
				m_RawImage = component;
			}
			RectTransform component2 = GetComponent<RectTransform>();
			RectTransform component3;
			if (m_RatioScaleMode != RatioScaleMode.WIDTH)
			{
				m_DefaultSize = component2.rect.height;
				component3 = GetComponent<RectTransform>();
				if ((object)component3 == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				m_DefaultSize = component2.rect.width;
				component3 = GetComponent<RectTransform>();
			}
			Rect rect = component3.rect;
			RectTransform component4 = GetComponent<RectTransform>();
			Rect rect2 = component4.rect;
			float defaultRatio = rect.width / rect2.height;
			m_DefaultRatio = defaultRatio;
			if (m_FileName != "")
			{
				Load();
			}
		}

		[Token(Token = "0x60001A4")]
		[Address(RVA = "0x3C46AA4", Offset = "0x3C46AA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_FileName = filename;\n\treturn;\n")]
		public void SetFilename(string filename)
		{
			m_FileName = filename;
		}

		[Token(Token = "0x60001A5")]
		[Address(RVA = "0x3C46924", Offset = "0x3C46924", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Equality(this.m_RawImage, 0);\n\tv68 = v59 == 0;\n\tif (v68) goto L_0036;\n\tgoto L_0079;\nL_0036:\n\tv83 = AlmostEngine.Screenshot.TextureExporter::LoadFromFile(this.m_FileName);\n\tUnityEngine.UI.RawImage::set_texture(this.m_RawImage, v83);\n\tv88 = this.m_AdaptRatio != 1;\n\tif (v88) goto L_0079;\n\tv222 = this.m_RawImage;\n\tv209 = UnityEngine.Texture::get_width(v222.texture);\n\tv223 = this.m_RawImage;\n\tv228 = UnityEngine.Texture::get_height(v223.texture);\n\tv200 = v209 / v228;\n\tv198 = v200 / this.m_DefaultRatio;\n\tv230 = this.m_RatioScaleMode == 0;\n\tif (v230) goto L_007D;\n\tv181 = UnityEngine.Component::get_transform(this.m_RawImage);\n\tv148 = 1f;\n\tv151 = v198;\n\tgoto L_008D;\nL_0079:\n\treturn;\nL_007D:\n\tv181 = UnityEngine.Component::get_transform(this.m_RawImage);\n\tv148 = 1f / v198;\n\tv151 = 1f;\nL_008D:\n\t// 141 MakeStruct v134 @ AGG3C46A9C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v151 @ V0_v3 (System.Single), v148 @ V1_v4 (System.Single), 1f\n\tUnityEngine.Transform::set_localScale(v181, v134);\n\treturn;\n")]
		public void Load()
		{
			if (m_RawImage == null)
			{
				return;
			}
			Texture2D texture = TextureExporter.LoadFromFile(m_FileName);
			m_RawImage.texture = texture;
			if (m_AdaptRatio)
			{
				RawImage rawImage = m_RawImage;
				int width = rawImage.texture.width;
				RawImage rawImage2 = m_RawImage;
				int height = rawImage2.texture.height;
				int num = width / height;
				float num2 = (float)num / m_DefaultRatio;
				Transform transform;
				float y;
				float x;
				if (m_RatioScaleMode != RatioScaleMode.WIDTH)
				{
					transform = m_RawImage.transform;
					y = 1f;
					x = num2;
				}
				else
				{
					transform = m_RawImage.transform;
					y = 1f / num2;
					x = 1f;
				}
				Vector3 localScale = default(Vector3);
				localScale.x = x;
				localScale.y = y;
				localScale.z = 1f;
				transform.localScale = localScale;
			}
		}

		[Token(Token = "0x60001A6")]
		[Address(RVA = "0x3C46AAC", Offset = "0x3C46AAC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_AdaptRatio = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public RawImageDisplayer()
		{
			m_AdaptRatio = true;
		}
	}
}
