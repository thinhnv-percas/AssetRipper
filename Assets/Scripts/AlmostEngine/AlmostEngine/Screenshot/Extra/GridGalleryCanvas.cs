using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AlmostEngine.Screenshot.Extra
{
	[Token(Token = "0x2000055")]
	public class GridGalleryCanvas : ScreenshotGallery
	{
		[Token(Token = "0x400020F")]
		[FieldOffset(Offset = "0x50")]
		public GridLayoutGroup m_Grid;

		[Token(Token = "0x4000210")]
		[FieldOffset(Offset = "0x58")]
		public RectTransform m_PreviousButton;

		[Token(Token = "0x4000211")]
		[FieldOffset(Offset = "0x60")]
		public RectTransform m_NextButton;

		[Token(Token = "0x4000212")]
		[FieldOffset(Offset = "0x68")]
		public Text m_PageText;

		[HideInInspector]
		[Token(Token = "0x4000213")]
		[FieldOffset(Offset = "0x70")]
		public int m_CurrentPage;

		[Token(Token = "0x600019C")]
		[Address(RVA = "0x3C445E0", Offset = "0x3C445E0", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv51 = AlmostEngine.Screenshot.Extra.GridGalleryCanvas::ImagesPerPage(v40);\n\tgoto L_0030;\nL_0034:\n\tv75 = v45.Count / v51;\n\tv76 = UnityEngine.Mathf::Ceil(v75);\n\tv95 = v76 == 0x7F800000;\n\tv80 = ~v95;\n\tif (v80) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = 0xFFFFFFFF80000000;\n\tgoto L_004F;\nL_FFFFFFFF:\n\treturnVal2 = v75;\nL_0016:\n\tv45 = v40.m_ImageFiles;\nL_0030:\n\tgoto L_0034;\nL_004F:\n\treturn returnVal2;\n")]
		public virtual int MaxPages()
		{
			//IL_0076: Expected I4, but got F4
			List<TextureExporter.ImageFile> imageFiles = m_ImageFiles;
			int num = ImagesPerPage();
			float num2 = (float)imageFiles.Count / (float)num;
			float num3 = Mathf.Ceil(num2);
			if (num3 == 1f / 0f)
			{
				return -2147483648;
			}
			return (int)num2;
		}

		[Token(Token = "0x600019D")]
		[Address(RVA = "0x3C446B0", Offset = "0x3C446B0", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tv59 = UnityEngine.Component::GetComponent(this.m_Grid);\n\tv78 = UnityEngine.RectTransform::get_rect(v59);\n\tv97 = this.m_Grid;\n\tgoto L_0038;\nL_0038:\n\tgoto L_003A;\nL_003A:\n\tv185 = this.m_Grid == 0;\n\tv92 = ~v185;\n\tif (v92) goto L_004D;\n\tgoto L_00A1;\nL_004D:\n\tv88 = UnityEngine.Component::GetComponent(this.m_Grid);\n\tv79 = UnityEngine.RectTransform::get_rect(v88);\n\tv101 = this.m_Grid;\n\tgoto L_0069;\nL_006B:\n\tv211 = v101.m_CellSize.y + v101.m_Spacing.y;\n\tv154 = v79.height / v211;\n\tv212 = v97.cellSize + v97.spacing;\n\tv213 = v78.width / v212;\n\tv214 = UnityEngine.Mathf::Floor(v213);\n\tv218 = v214 == 0x7F800000;\n\tv226 = ~v218;\n\tif (v226) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv163 = 0xFFFFFFFF80000000;\n\tgoto L_0082;\nL_FFFFFFFF:\n\tv163 = v213;\nL_FFFFFFFF:\n\tv132 = 0xFFFFFFFF80000000;\n\tgoto L_0092;\nL_FFFFFFFF:\n\tv132 = v154;\nL_00A1:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0069:\n\tgoto L_006B;\nL_0082:\n\tv150 = UnityEngine.Mathf::Floor(v154);\n\tv126 = v150 == 0x7F800000;\n\tv111 = ~v126;\n\tif (v111) goto L_FFFFFFFF;\nL_0092:\n\treturnVal2 = v132 * v163;\n\treturn returnVal2;\n")]
		public virtual int ImagesPerPage()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridGalleryCanvas::ImagesPerPage");
			return default;
		}

		[Token(Token = "0x600019E")]
		[Address(RVA = "0x3C44834", Offset = "0x3C44834", Length = "0x3D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv84 = AlmostEngine.Screenshot.Extra.GridGalleryCanvas::MaxPages(this);\n\tv85 = v84 - 1;\n\tthis.m_CurrentPage = v85;\n\tv106 = v90.Count < 1;\n\tif (v106) goto L_0058;\n\tv334 = this.m_CurrentPage & 0x80000000;\n\tv335 = v334 == 0;\n\tif (v335) goto L_0058;\n\tthis.m_CurrentPage = 0;\n\tv171 = 0;\n\tgoto L_0086;\nL_0073:\n\t// 115 MakeStruct v364 @ AGG3C44948_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v363 @ V0_v8 (System.Single), v362 @ V1_v7 (System.Single), 1f\n\tUnityEngine.Transform::set_localScale(v509, v364);\n\tv171 = v171 + 1;\n\tv388 = AlmostEngine.Screenshot.Extra.GridGalleryCanvas::ImagesPerPage(this);\n\tv368 = v171 >= v388;\n\tif (v368) goto L_011D;\nL_0086:\n\tv313 = this.m_ImageFiles;\n\tv175 = v313.Count <= 0;\n\tif (v175) goto L_011D;\n\tv460 = AlmostEngine.Screenshot.Extra.GridGalleryCanvas::ImagesPerPage(this);\n\tv265 = this.m_ImageFiles;\n\tv391 = v460 * this.m_CurrentPage;\n\tv151 = v171 + v391;\n\tv176 = v151 >= v265.Count;\n\tif (v176) goto L_011D;\n\tv464 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.TextureExporter+ImageFile>::get_Item(v265, v151);\n\tv473 = UnityEngine.Component::get_transform(this.m_Grid);\n\tv267 = AlmostEngine.Screenshot.Extra.ScreenshotGallery::InstantiateImageObject(this, v464, v151, v473);\n\tv316 = this.m_Grid;\n\tv269 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.TextureExporter+ImageFile>::get_Item(this.m_ImageFiles, v151);\n\tv489 = UnityEngine.Texture::get_width(v269.m_Texture);\n\tv272 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.TextureExporter+ImageFile>::get_Item(this.m_ImageFiles, v151);\n\tv498 = v316.cellSize / v316.m_CellSize.y;\n\tv274 = UnityEngine.Texture::get_height(v272.m_Texture);\n\tv115 = v489 / v274;\n\tv129 = v115 / v498;\n\tv217 = v129 < 1f;\n\tv501 = v129 == v129;\n\tv203 = 1f == 1f;\n\tv224 = v501 & v203;\n\tv184 = ~v224;\n\tv177 = v217 == v184;\n\tif (v177) goto L_0106;\n\tv275 = UnityEngine.GameObject::GetComponentInChildren(v267);\n\tv509 = UnityEngine.Component::get_transform(v275);\n\tv362 = 1f;\n\tv363 = v129;\n\tgoto L_0073;\nL_0106:\n\tv277 = UnityEngine.GameObject::GetComponentInChildren(v267);\n\tv509 = UnityEngine.Component::get_transform(v277);\n\tv362 = 1f / v129;\n\tv363 = 1f;\n\tgoto L_0073;\nL_011D:\n\tv178 = this.m_CurrentPage <= 0;\n\tif (v178) goto L_012A;\n\tv466 = UnityEngine.Component::get_gameObject(this.m_PreviousButton);\n\tv465 = 1;\n\tgoto L_012F;\nL_012A:\n\tv466 = UnityEngine.Component::get_gameObject(this.m_PreviousButton);\n\tv465 = 0;\n\tv479 = UnityEngine.Component::get_gameObject(this.m_NextButton);\n\tv478 = 1;\n\tgoto L_0153;\nL_014E:\n\tv479 = UnityEngine.Component::get_gameObject(this.m_NextButton);\n\tv478 = 0;\n\tv285 = System.String::Concat(v488, \"/\", v495);\n\tv443 = UnityEngine.UI.Text::set_text(this.m_PageText, v285);\n\treturn;\nL_002B:\n\tv65 = AlmostEngine.Screenshot.Extra.GridGalleryCanvas::MaxPages(this);\n\tv76 = this.m_CurrentPage < v65;\n\tif (v76) goto L_003F;\nL_0058:\n\tv342 = AlmostEngine.Screenshot.Extra.ScreenshotGallery::Clear(this);\n\tv347 = AlmostEngine.Screenshot.Extra.GridGalleryCanvas::ImagesPerPage(this);\n\tv358 = v347 < 1;\n\tif (v358) goto L_011D;\nL_012F:\n\tUnityEngine.GameObject::SetActive(v466, v465);\n\tv470 = AlmostEngine.Screenshot.Extra.GridGalleryCanvas::MaxPages(this);\n\tv320 = v470 - 1;\n\tv179 = this.m_CurrentPage >= v320;\n\tif (v179) goto L_014E;\nL_0153:\n\tUnityEngine.GameObject::SetActive(v479, v478);\n\tv484 = this.m_CurrentPage + 1;\n\tv485 = v484;\n\tv488 = System.Int32::ToString(&v485 @ stack_-74_v3 (System.Int32));\n\tv492 = AlmostEngine.Screenshot.Extra.GridGalleryCanvas::MaxPages(this);\n\tv485 = v492;\n\tv495 = System.Int32::ToString(&v485 @ stack_-74_v3 (System.Int32));\nL_003F:\n\tv90 = this.m_ImageFiles;\n")]
		public override void DoGalleryUpdate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridGalleryCanvas::DoGalleryUpdate");
		}

		[Token(Token = "0x600019F")]
		[Address(RVA = "0x3C44C0C", Offset = "0x3C44C0C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.m_CurrentPage + 1;\n\tthis.m_CurrentPage = v2;\n\tthis = AlmostEngine.Screenshot.Extra.ScreenshotGallery::UpdateGallery(this);\n\treturn;\n")]
		public virtual void NextPageCallback()
		{
			int currentPage = m_CurrentPage + 1;
			m_CurrentPage = currentPage;
			base.UpdateGallery();
		}

		[Token(Token = "0x60001A0")]
		[Address(RVA = "0x3C44C24", Offset = "0x3C44C24", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.m_CurrentPage - 1;\n\tthis.m_CurrentPage = v2;\n\tthis = AlmostEngine.Screenshot.Extra.ScreenshotGallery::UpdateGallery(this);\n\treturn;\n")]
		public virtual void PreviousPageCallback()
		{
			int currentPage = m_CurrentPage - 1;
			m_CurrentPage = currentPage;
			base.UpdateGallery();
		}

		[Token(Token = "0x60001A1")]
		[Address(RVA = "0x3C44C3C", Offset = "0x3C44C3C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v7, 0);\n\treturn;\n")]
		public virtual void CloseCallback()
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}

		[Token(Token = "0x60001A2")]
		[Address(RVA = "0x3C44C64", Offset = "0x3C44C64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tAlmostEngine.Screenshot.Extra.ScreenshotGallery::.ctor(this);\n\treturn;\n")]
		public GridGalleryCanvas()
		{
		}
	}
}
