using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AllIn1SpriteShader
{
	[ExecuteInEditMode]
	[Token(Token = "0x2000018")]
	public class SetAtlasUvs : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x20")]
		private bool updateEveryFrame;

		[Tooltip("If using a Sprite Renderer it will use the material property instead of sharedMaterial")]
		[SerializeField]
		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0x21")]
		private bool useMaterialInstanceIfPossible;

		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0x28")]
		private Renderer render;

		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0x30")]
		private SpriteRenderer spriteRender;

		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x38")]
		private Image uiImage;

		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0x40")]
		private bool isUI;

		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0x44")]
		private readonly int minXuv;

		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x48")]
		private readonly int maxXuv;

		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x4C")]
		private readonly int minYuv;

		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x50")]
		private readonly int maxYuv;

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x3C23DB8", Offset = "0x3C23DB8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tAllIn1SpriteShader.SetAtlasUvs::Setup(this);\n\treturn;\n")]
		private void Start()
		{
			Setup();
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x3C23EC4", Offset = "0x3C23EC4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tAllIn1SpriteShader.SetAtlasUvs::Setup(this);\n\treturn;\n")]
		private void Reset()
		{
			Setup();
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x3C23DBC", Offset = "0x3C23DBC", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = *([B78D3B5]) & 1;\n\tv15 = v14 == 0;\n\tif (v15) goto L_001D;\n\tv17 = AllIn1SpriteShader.SetAtlasUvs::GetRendererReferencesIfNeeded(this);\n\tv36 = ~v17;\n\tv37 = ~v36;\n\tif (v37) goto L_0023;\nL_0013:\n\tv49 = this.updateEveryFrame == 0;\n\tif (v49) goto L_002E;\n\tgoto L_005D;\nL_001D:\n\t*([B78D3B5]) = 1;\n\tv42 = AllIn1SpriteShader.SetAtlasUvs::GetRendererReferencesIfNeeded(this);\n\tv44 = ~v42;\n\tif (v44) goto L_0013;\nL_0023:\n\tv54 = AllIn1SpriteShader.SetAtlasUvs::GetAndSetUVs(this);\n\tv67 = this.updateEveryFrame == 0;\n\tv58 = ~v67;\n\tif (v58) goto L_005D;\nL_002E:\n\tgoto L_0030;\nL_0030:\n\tv76 = UnityEngine.Application::get_isPlaying();\n\tv109 = ~v76;\n\tv81 = ~v109;\n\tif (v81) goto L_003F;\n\tgoto L_005D;\nL_003F:\n\tgoto L_0043;\nL_0043:\n\tv78 = UnityEngine.Object::op_Inequality(this, 0);\n\tv83 = ~v78;\n\tif (v83) goto L_005D;\n\tUnityEngine.Behaviour::set_enabled(this, 0);\n\treturn;\nL_005D:\n\treturn;\n")]
		private void Setup()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78D3B5]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				if (!GetRendererReferencesIfNeeded())
				{
					goto IL_0061;
				}
			}
			else
			{
				_ = 1;
				if (!GetRendererReferencesIfNeeded())
				{
					goto IL_0061;
				}
			}
			bool andSetUVs = GetAndSetUVs();
			if (!updateEveryFrame)
			{
				goto IL_00e7;
			}
			return;
			IL_00e7:
			if (Application.isPlaying && this != null)
			{
				base.enabled = false;
			}
			return;
			IL_0061:
			if (updateEveryFrame)
			{
				return;
			}
			goto IL_00e7;
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0x3C24250", Offset = "0x3C24250", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.updateEveryFrame != 1;\n\tif (v11) goto L_000E;\n\tv12 = AllIn1SpriteShader.SetAtlasUvs::GetAndSetUVs(this);\n\treturn;\nL_000E:\n\treturn;\n")]
		private void Update()
		{
			if (updateEveryFrame)
			{
				bool andSetUVs = GetAndSetUVs();
			}
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x3C228BC", Offset = "0x3C228BC", Length = "0x43C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv59 = this.isUI == 0;\n\tif (v59) goto L_00AD;\n\tv138 = this.uiImage;\n\tv261 = UnityEngine.Sprite::get_textureRect(v138.sprite);\n\tv391 = this.uiImage;\n\tv311 = UnityEngine.Sprite::get_texture(v391.sprite);\n\tv312 = UnityEngine.Texture::get_width(v311);\n\tv392 = this.uiImage;\n\tv314 = UnityEngine.Sprite::get_texture(v392.sprite);\n\tv315 = UnityEngine.Texture::get_width(v314);\n\tv393 = this.uiImage;\n\tv317 = UnityEngine.Sprite::get_texture(v393.sprite);\n\tv318 = UnityEngine.Texture::get_height(v317);\n\tv394 = this.uiImage;\n\tv320 = UnityEngine.Sprite::get_texture(v394.sprite);\n\tv444 = UnityEngine.Texture::get_height(v320);\n\tv322 = UnityEngine.UI.Image::get_material(this.uiImage);\n\tv252 = v261 / v312;\n\tUnityEngine.Material::SetFloat(v322, this.minXuv, v252);\n\tv324 = UnityEngine.UI.Image::get_material(this.uiImage);\n\tv447 = v261.width / v315;\n\tv263 = v252 + v447;\n\tUnityEngine.Material::SetFloat(v324, this.maxXuv, v263);\n\tv326 = UnityEngine.UI.Image::get_material(this.uiImage);\n\tv248 = v261.y / v318;\n\tUnityEngine.Material::SetFloat(v326, this.minYuv, v248);\n\tv459 = UnityEngine.UI.Image::get_material(this.uiImage);\n\tv461 = v261.height / v444;\n\tv113 = v248 + v461;\n\tv117 = returnVal1;\n\tgoto L_015A;\nL_00AD:\n\tv329 = UnityEngine.SpriteRenderer::get_sprite(this.spriteRender);\n\tv265 = UnityEngine.Sprite::get_textureRect(v329);\n\tv330 = UnityEngine.Sprite::get_texture(v329);\n\tv410 = UnityEngine.Texture::get_width(v330);\n\tv331 = UnityEngine.Sprite::get_texture(v329);\n\tv414 = UnityEngine.Texture::get_width(v331);\n\tv332 = UnityEngine.Sprite::get_texture(v329);\n\tv417 = UnityEngine.Texture::get_height(v332);\n\tv333 = UnityEngine.Sprite::get_texture(v329);\n\tv250 = v265 / v410;\n\tv254 = v265.width / v414;\n\tv243 = v265.y / v417;\n\tv424 = UnityEngine.Texture::get_height(v333);\n\tv246 = v265.height / v424;\n\tv205 = this.useMaterialInstanceIfPossible != 1;\n\tif (v205) goto L_0133;\n\tgoto L_00FC;\nL_00FC:\n\tv433 = UnityEngine.Application::get_isPlaying();\n\tv436 = ~v433;\n\tif (v436) goto L_0133;\n\tv335 = UnityEngine.Renderer::get_material(this.render);\n\tUnityEngine.Material::SetFloat(v335, this.minXuv, v250);\n\tv337 = UnityEngine.Renderer::get_material(this.render);\n\tv268 = v250 + v254;\n\tUnityEngine.Material::SetFloat(v337, this.maxXuv, v268);\n\tv339 = UnityEngine.Renderer::get_material(this.render);\n\tUnityEngine.Material::SetFloat(v339, this.minYuv, v243);\n\tv459 = UnityEngine.Renderer::get_material(this.render);\n\tv462 = v459 == 0;\n\tv382 = ~v462;\n\tif (v382) goto L_0157;\n\tgoto L_016A;\nL_0133:\n\tv343 = UnityEngine.Renderer::get_sharedMaterial(this.render);\n\tUnityEngine.Material::SetFloat(v343, this.minXuv, v250);\n\tv345 = UnityEngine.Renderer::get_sharedMaterial(this.render);\n\tv271 = v250 + v254;\n\tUnityEngine.Material::SetFloat(v345, this.maxXuv, v271);\n\tv347 = UnityEngine.Renderer::get_sharedMaterial(this.render);\n\tUnityEngine.Material::SetFloat(v347, this.minYuv, v243);\n\tv459 = UnityEngine.Renderer::get_sharedMaterial(this.render);\nL_0157:\n\tv113 = v243 + v246;\n\tv117 = returnVal1;\nL_016A:\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_001B:\n\treturnVal1 = AllIn1SpriteShader.SetAtlasUvs::GetRendererReferencesIfNeeded(this);\n\tv56 = ~returnVal1;\n\tif (v56) goto L_0169;\nL_0169:\n\treturn returnVal1;\nL_015A:\n\tUnityEngine.Material::SetFloat(v459, this.maxYuv, v113);\n\treturnVal1 = v117;\n")]
		public bool GetAndSetUVs()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SetAtlasUvs::GetAndSetUVs");
			return default;
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x3C22CF8", Offset = "0x3C22CF8", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv43 = this.isUI == 0;\n\tif (v43) goto L_005C;\n\tv130 = UnityEngine.UI.Image::get_material(this.uiImage);\n\tUnityEngine.Material::SetFloat(v130, this.minXuv, 0f);\n\tv175 = UnityEngine.UI.Image::get_material(this.uiImage);\n\tUnityEngine.Material::SetFloat(v175, this.maxXuv, 1f);\n\tv177 = UnityEngine.UI.Image::get_material(this.uiImage);\n\tUnityEngine.Material::SetFloat(v177, this.minYuv, 0f);\n\tv113 = UnityEngine.UI.Image::get_material(this.uiImage);\n\tv239 = v113 == 0;\n\tv201 = ~v239;\n\tif (v201) goto L_00C8;\n\tgoto L_00CA;\nL_0051:\n\treturn;\nL_005C:\n\tv60 = this.useMaterialInstanceIfPossible != 1;\n\tif (v60) goto L_009C;\n\tgoto L_0065;\nL_0065:\n\tv229 = UnityEngine.Application::get_isPlaying();\n\tv232 = ~v229;\n\tif (v232) goto L_009C;\n\tv181 = UnityEngine.Renderer::get_material(this.render);\n\tUnityEngine.Material::SetFloat(v181, this.minXuv, 0f);\n\tv183 = UnityEngine.Renderer::get_material(this.render);\n\tUnityEngine.Material::SetFloat(v183, this.maxXuv, 1f);\n\tv185 = UnityEngine.Renderer::get_material(this.render);\n\tUnityEngine.Material::SetFloat(v185, this.minYuv, 0f);\n\tv113 = UnityEngine.Renderer::get_material(this.render);\n\tv243 = v113 == 0;\n\tv209 = ~v243;\n\tif (v209) goto L_00C8;\n\tgoto L_00CA;\nL_009C:\n\tv189 = UnityEngine.Renderer::get_sharedMaterial(this.render);\n\tUnityEngine.Material::SetFloat(v189, this.minXuv, 0f);\n\tv191 = UnityEngine.Renderer::get_sharedMaterial(this.render);\n\tUnityEngine.Material::SetFloat(v191, this.maxXuv, 1f);\n\tv193 = UnityEngine.Renderer::get_sharedMaterial(this.render);\n\tUnityEngine.Material::SetFloat(v193, this.minYuv, 0f);\n\tv113 = UnityEngine.Renderer::get_sharedMaterial(this.render);\nL_00C8:\n\tUnityEngine.Material::SetFloat(v113, this.maxYuv, 1f);\n\treturn;\nL_00CA:\n\tthrow System.NullReferenceException;\nL_0013:\n\tv39 = AllIn1SpriteShader.SetAtlasUvs::GetRendererReferencesIfNeeded(this);\n\tv40 = ~v39;\n\tif (v40) goto L_0051;\n")]
		public void ResetAtlasUvs()
		{
			if (!GetRendererReferencesIfNeeded())
			{
				return;
			}
			Material material4;
			if (isUI)
			{
				Material material = uiImage.material;
				material.SetFloat(minXuv, 0f);
				Material material2 = uiImage.material;
				material2.SetFloat(maxXuv, 1f);
				Material material3 = uiImage.material;
				material3.SetFloat(minYuv, 0f);
				material4 = uiImage.material;
				if ((object)material4 == null)
				{
					goto IL_029c;
				}
			}
			else if (useMaterialInstanceIfPossible && Application.isPlaying)
			{
				Material material5 = render.material;
				material5.SetFloat(minXuv, 0f);
				Material material6 = render.material;
				material6.SetFloat(maxXuv, 1f);
				Material material7 = render.material;
				material7.SetFloat(minYuv, 0f);
				material4 = render.material;
				if ((object)material4 == null)
				{
					goto IL_029c;
				}
			}
			else
			{
				Material sharedMaterial = render.sharedMaterial;
				sharedMaterial.SetFloat(minXuv, 0f);
				Material sharedMaterial2 = render.sharedMaterial;
				sharedMaterial2.SetFloat(maxXuv, 1f);
				Material sharedMaterial3 = render.sharedMaterial;
				sharedMaterial3.SetFloat(minYuv, 0f);
				material4 = render.sharedMaterial;
			}
			material4.SetFloat(maxYuv, 1f);
			return;
			IL_029c:
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x3C24264", Offset = "0x3C24264", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.updateEveryFrame = everyFrame;\n\treturn;\n")]
		public void UpdateEveryFrame(bool everyFrame)
		{
			updateEveryFrame = everyFrame;
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x3C23EC8", Offset = "0x3C23EC8", Length = "0x388")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv147 = this + 0x30;\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Equality(this.spriteRender, 0);\n\tv69 = ~v59;\n\tv70 = ~v69;\n\tif (v70) goto L_0059;\n\tv110 = this.spriteRender;\n\tgoto L_0026;\nL_0026:\n\tv120 = UnityEngine.Object::op_Inequality(v110, 0);\n\tv134 = ~v120;\n\tif (v134) goto L_0072;\n\tv165 = UnityEngine.SpriteRenderer::get_sprite(*([v147 @ X20_v22]));\n\tgoto L_0034;\nL_0034:\n\tv183 = UnityEngine.Object::op_Equality(v165, 0);\n\tv245 = ~v183;\n\tif (v245) goto L_00AA;\n\tgoto L_00F5;\nL_0059:\n\tv101 = UnityEngine.Component::GetComponent(this);\n\tthis.spriteRender = v101;\n\tv110 = this.spriteRender;\n\tv147 = v147;\n\tgoto L_0026;\nL_0072:\n\tgoto L_0076;\nL_0076:\n\tv170 = UnityEngine.Object::op_Equality(this.uiImage, 0);\n\tv175 = ~v170;\n\tv176 = ~v175;\n\tif (v176) goto L_0086;\n\tgoto L_00C6;\nL_0086:\n\tv244 = UnityEngine.Component::GetComponent(this);\n\tthis.uiImage = v244;\n\tgoto L_0093;\nL_0093:\n\tv258 = UnityEngine.Object::op_Inequality(this.uiImage, 0);\n\tv361 = v258 == 0;\n\tv261 = ~v361;\n\tif (v261) goto L_00C6;\n\tgoto L_00F5;\nL_00AA:\n\tgoto L_00AF;\nL_00AF:\n\tv321 = UnityEngine.Object::op_Equality(this.render, 0);\n\tv333 = v321 == 0;\n\tv334 = ~v333;\n\tv339 = 0;\n\tif (v334) goto L_00D4;\n\tv354 = 0;\n\tgoto L_00DA;\nL_00C6:\n\tgoto L_00CB;\nL_00CB:\n\tv295 = UnityEngine.Object::op_Equality(this.render, 0);\n\tv324 = ~v295;\n\tv339 = 1;\n\tv354 = 1;\n\tif (v324) goto L_00DA;\nL_00D4:\n\tv347 = UnityEngine.Component::GetComponent(this);\n\tthis.render = v347;\n\tv354 = v339;\nL_00E3:\n\tv367 = UnityEngine.Object::op_Equality(this.spriteRender, 0);\n\tv370 = ~v367;\n\tif (v370) goto L_0113;\n\tgoto L_00EE;\nL_00EE:\n\tv304 = UnityEngine.Object::op_Equality(this.uiImage, 0);\n\tv309 = ~v304;\n\tif (v309) goto L_0124;\nL_00F5:\n\tgoto L_00F9;\nL_00F9:\n\tUnityEngine.Object::DestroyImmediate(this);\n\treturn 0;\nL_0113:\n\treturn 1;\nL_0124:\n\treturn 1;\nL_00DA:\n\tthis.isUI = v354;\n\tgoto L_00E3;\n")]
		private bool GetRendererReferencesIfNeeded()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SetAtlasUvs::GetRendererReferencesIfNeeded");
			return default;
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x3C2426C", Offset = "0x3C2426C", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tthis.minYuv = v69;\n\tv74 = UnityEngine.Shader::PropertyToID(\"_MaxYUV\");\n\tthis.maxYuv = v74;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_0029:\n\tv57 = UnityEngine.Shader::PropertyToID(\"_MinXUV\");\n\tthis.minXuv = v57;\n\tv63 = UnityEngine.Shader::PropertyToID(\"_MaxXUV\");\n\tthis.maxXuv = v63;\n\tv69 = UnityEngine.Shader::PropertyToID(\"_MinYUV\");\n")]
		public SetAtlasUvs()
		{
			int num = Shader.PropertyToID("_MinXUV");
			minXuv = num;
			int num2 = Shader.PropertyToID("_MaxXUV");
			maxXuv = num2;
			int num3 = Shader.PropertyToID("_MinYUV");
			minYuv = num3;
			int num4 = Shader.PropertyToID("_MaxYUV");
			maxYuv = num4;
		}
	}
}
