using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AllIn1SpriteShader
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[AddComponentMenu("AllIn1SpriteShader/AddAllIn1Shader")]
	[Token(Token = "0x2000014")]
	public class AllIn1Shader : MonoBehaviour
	{
		[Token(Token = "0x2000015")]
		public enum ShaderTypes
		{
			[Token(Token = "0x400005E")]
			Default = 0,
			[Token(Token = "0x400005F")]
			ScaledTime = 1,
			[Token(Token = "0x4000060")]
			MaskedUI = 2,
			[Token(Token = "0x4000061")]
			Urp2dRenderer = 3,
			[Token(Token = "0x4000062")]
			Lit = 5,
			[Token(Token = "0x4000063")]
			Invalid = 4
		}

		[Token(Token = "0x2000016")]
		private enum AfterSetAction
		{
			[Token(Token = "0x4000065")]
			Clear = 0,
			[Token(Token = "0x4000066")]
			CopyMaterial = 1,
			[Token(Token = "0x4000067")]
			Reset = 2
		}

		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x20")]
		public ShaderTypes currentShaderType;

		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x28")]
		private Material currMaterial;

		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x30")]
		private Material prevMaterial;

		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x38")]
		private bool destroyed;

		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x39")]
		private bool matAssigned;

		[Range(1f, 20f)]
		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x3C")]
		public float normalStrength;

		[Range(0f, 3f)]
		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x40")]
		public int normalSmoothing;

		[HideInInspector]
		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x44")]
		public bool computingNormal;

		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x45")]
		private bool needToWait;

		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x48")]
		private int waitingCycles;

		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x4C")]
		private int timesWeWaited;

		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x50")]
		private SpriteRenderer normalMapSr;

		[Token(Token = "0x4000059")]
		[FieldOffset(Offset = "0x58")]
		private Renderer normalMapRenderer;

		[Token(Token = "0x400005A")]
		[FieldOffset(Offset = "0x60")]
		private bool isSpriteRenderer;

		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x68")]
		private string path;

		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x70")]
		private string subPath;

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x3C21528", Offset = "0x3C21528", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void MakeNewMaterial(bool getShaderTypeFromPrefs, string shaderName = "AllIn1SpriteShader")
		{
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x3C21534", Offset = "0x3C21534", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tthis.currentShaderType = 0;\n\treturn 0;\n")]
		public bool MakeCopy()
		{
			currentShaderType = default(ShaderTypes);
			return false;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x3C2162C", Offset = "0x3C2162C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void ResetAllProperties(bool getShaderTypeFromPrefs, string shaderName)
		{
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x3C215A8", Offset = "0x3C215A8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tthis.currentShaderType = 0;\n\treturn \"AllIn1SpriteShader\";\n")]
		private string GetStringFromShaderType()
		{
			currentShaderType = default(ShaderTypes);
			return "AllIn1SpriteShader";
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x3C2152C", Offset = "0x3C2152C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		private bool SetMaterial(AfterSetAction action, bool getShaderTypeFromPrefs, string shaderName)
		{
			return false;
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x3C21630", Offset = "0x3C21630", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = action == 1;\n\tif (v5) goto L_0015;\n\tv10 = action == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_0017;\n\tAllIn1SpriteShader.AllIn1Shader::ClearAllKeywords(this);\n\treturn;\nL_0015:\n\tUnityEngine.Material::CopyPropertiesFromMaterial(this.currMaterial, this.prevMaterial);\n\treturn;\nL_0017:\n\treturn;\n")]
		private void DoAfterSetAction(AfterSetAction action)
		{
			switch (action)
			{
			case AfterSetAction.Clear:
				ClearAllKeywords();
				break;
			case AfterSetAction.CopyMaterial:
				currMaterial.CopyPropertiesFromMaterial(prevMaterial);
				break;
			}
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x3C21E70", Offset = "0x3C21E70", Length = "0x30C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_002C:\n\tv63 = UnityEngine.Object::op_Inequality(v49, 0);\n\tv67 = ~v63;\n\tif (v67) goto L_0047;\n\tgoto L_0036;\nL_0036:\n\tv93 = UnityEngine.Object::op_Inequality(v49, 0);\n\tv99 = ~v93;\n\tv100 = ~v99;\n\tif (v100) goto L_0067;\nL_FFFFFFFF:\n\t;\n\tgoto L_00D5;\nL_0047:\n\tv88 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0050;\nL_0050:\n\treturnVal1 = UnityEngine.Object::op_Inequality(v88, 0);\n\tv116 = ~returnVal1;\n\tv117 = ~v116;\n\tif (v117) goto L_0080;\n\treturn returnVal1;\nL_0067:\n\tv150 = UnityEngine.Renderer::get_sharedMaterial(v49);\n\tgoto L_006E;\nL_006E:\n\tv134 = UnityEngine.Object::op_Inequality(v150, 0);\n\tv261 = ~v134;\n\tv138 = ~v261;\n\tif (v138) goto L_00C0;\nL_FFFFFFFF:\n\t;\n\tgoto L_00D5;\nL_0080:\n\tv164 = UnityEngine.UI.Graphic::get_material(v88);\n\tv165 = UnityEngine.Object::get_name(v164);\n\tv240 = System.String::Contains(v165, \"AllIn1\");\n\tv275 = ~v240;\n\tif (v275) goto L_00B3;\nL_FFFFFFFF:\n\t;\n\tgoto L_00A5;\nL_00B3:\n\tgoto L_00B4;\nL_00B4:\n\tgoto L_00ED;\nL_00C0:\n\tv166 = UnityEngine.Renderer::get_sharedMaterial(v49);\n\tv167 = UnityEngine.Object::get_name(v166);\n\tv136 = System.String::Contains(v167, \"AllIn1\");\n\tv140 = ~v136;\nL_FFFFFFFF:\n\t;\n\tif (v140) goto L_00D5;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t;\n\tgoto L_00A5;\nL_00D5:\n\tAllIn1SpriteShader.AllIn1Shader::CleanMaterial(this);\n\tgoto L_00ED;\nL_0023:\n\tv49 = UnityEngine.Component::GetComponent(this);\n\tgoto L_002C;\nL_00A5:\n\tthis.currentShaderType = 0;\n\tAllIn1SpriteShader.AllIn1Shader::ClearAllKeywords(this);\n\treturn 1;\nL_00ED:\n\tthis.currentShaderType = 0;\n\treturn 1;\n")]
		public bool TryCreateNew()
		{
			Renderer component = GetComponent<Renderer>();
			if (component != null)
			{
				if (component != null)
				{
					Material sharedMaterial = component.sharedMaterial;
					if (sharedMaterial != null)
					{
						Material sharedMaterial2 = component.sharedMaterial;
						string text = sharedMaterial2.name;
						if (text.Contains("AllIn1"))
						{
							goto IL_01cd;
						}
					}
				}
				CleanMaterial();
			}
			else
			{
				Graphic component2 = GetComponent<Graphic>();
				bool flag = component2 != null;
				if (!flag)
				{
					return flag;
				}
				UnityEngine.Object material = component2.material;
				string text2 = material.name;
				if (text2.Contains("AllIn1"))
				{
					goto IL_01cd;
				}
			}
			currentShaderType = default(ShaderTypes);
			return true;
			IL_01cd:
			currentShaderType = default(ShaderTypes);
			ClearAllKeywords();
			return true;
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x3C21668", Offset = "0x3C21668", Length = "0x808")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_00CF;\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"POLARUV_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"TWISTUV_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"ROTATEUV_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"FISHEYE_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"PINCH_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"SHAKEUV_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"WAVEUV_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"ROUNDWAVEUV_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"DOODLE_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"ZOOMUV_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"FADE_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"TEXTURESCROLL_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"GLOW_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"OUTBASE_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"ONLYOUTLINE_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"OUTTEX_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"OUTDIST_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"DISTORT_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"WIND_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"GRADIENT_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"GRADIENT2COL_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"RADIALGRADIENT_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"COLORSWAP_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"HSV_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"HITEFFECT_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"PIXELATE_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"NEGATIVE_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"GRADIENTCOLORRAMP_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"COLORRAMP_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"GREYSCALE_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"POSTERIZE_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"BLUR_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"MOTIONBLUR_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"GHOST_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"ALPHAOUTLINE_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"INNEROUTLINE_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"ONLYINNEROUTLINE_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"HOLOGRAM_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"CHROMABERR_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"GLITCH_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"FLICKER_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"SHADOW_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"SHINE_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"CONTRAST_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"OVERLAY_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"OVERLAYMULT_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"ALPHACUTOFF_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"ALPHAROUND_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"CHANGECOLOR_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"CHANGECOLOR2_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"CHANGECOLOR3_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"FOG_ON\", 0);\n\treturn;\nL_00CF:\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"RECTSIZE_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"OFFSETUV_ON\", 0);\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"CLIPPING_ON\", 0);\n")]
		public void ClearAllKeywords()
		{
			SetKeyword("RECTSIZE_ON");
			SetKeyword("OFFSETUV_ON");
			SetKeyword("CLIPPING_ON");
			SetKeyword("POLARUV_ON");
			SetKeyword("TWISTUV_ON");
			SetKeyword("ROTATEUV_ON");
			SetKeyword("FISHEYE_ON");
			SetKeyword("PINCH_ON");
			SetKeyword("SHAKEUV_ON");
			SetKeyword("WAVEUV_ON");
			SetKeyword("ROUNDWAVEUV_ON");
			SetKeyword("DOODLE_ON");
			SetKeyword("ZOOMUV_ON");
			SetKeyword("FADE_ON");
			SetKeyword("TEXTURESCROLL_ON");
			SetKeyword("GLOW_ON");
			SetKeyword("OUTBASE_ON");
			SetKeyword("ONLYOUTLINE_ON");
			SetKeyword("OUTTEX_ON");
			SetKeyword("OUTDIST_ON");
			SetKeyword("DISTORT_ON");
			SetKeyword("WIND_ON");
			SetKeyword("GRADIENT_ON");
			SetKeyword("GRADIENT2COL_ON");
			SetKeyword("RADIALGRADIENT_ON");
			SetKeyword("COLORSWAP_ON");
			SetKeyword("HSV_ON");
			SetKeyword("HITEFFECT_ON");
			SetKeyword("PIXELATE_ON");
			SetKeyword("NEGATIVE_ON");
			SetKeyword("GRADIENTCOLORRAMP_ON");
			SetKeyword("COLORRAMP_ON");
			SetKeyword("GREYSCALE_ON");
			SetKeyword("POSTERIZE_ON");
			SetKeyword("BLUR_ON");
			SetKeyword("MOTIONBLUR_ON");
			SetKeyword("GHOST_ON");
			SetKeyword("ALPHAOUTLINE_ON");
			SetKeyword("INNEROUTLINE_ON");
			SetKeyword("ONLYINNEROUTLINE_ON");
			SetKeyword("HOLOGRAM_ON");
			SetKeyword("CHROMABERR_ON");
			SetKeyword("GLITCH_ON");
			SetKeyword("FLICKER_ON");
			SetKeyword("SHADOW_ON");
			SetKeyword("SHINE_ON");
			SetKeyword("CONTRAST_ON");
			SetKeyword("OVERLAY_ON");
			SetKeyword("OVERLAYMULT_ON");
			SetKeyword("ALPHACUTOFF_ON");
			SetKeyword("ALPHAROUND_ON");
			SetKeyword("CHANGECOLOR_ON");
			SetKeyword("CHANGECOLOR2_ON");
			SetKeyword("CHANGECOLOR3_ON");
			SetKeyword("FOG_ON");
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x3C22358", Offset = "0x3C22358", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_0025:\n\treturn;\nL_002C:\n\tgoto L_0030;\nL_0030:\n\tv123 = UnityEngine.Object::op_Equality(this.currMaterial, 0);\n\tv125 = ~v123;\n\tv126 = ~v125;\n\tif (v126) goto L_003D;\n\tgoto L_004F;\nL_003D:\n\tAllIn1SpriteShader.AllIn1Shader::FindCurrMaterial(this);\n\tgoto L_0048;\nL_0048:\n\tv58 = UnityEngine.Object::op_Equality(this.currMaterial, 0);\n\tv148 = v58 == 0;\n\tv60 = ~v148;\n\tif (v60) goto L_0025;\nL_004F:\n\tv140 = state == 0;\n\tif (v140) goto L_006D;\n\tUnityEngine.Material::EnableKeyword(this.currMaterial, keyword);\n\treturn;\nL_006D:\n\tUnityEngine.Material::DisableKeyword(this.currMaterial, keyword);\n\treturn;\nL_001A:\n\tv50 = this.destroyed == 0;\n\tif (v50) goto L_002C;\n")]
		private void SetKeyword(string keyword, bool state = false)
		{
			if (destroyed)
			{
				return;
			}
			if (currMaterial == null)
			{
				FindCurrMaterial();
				if (currMaterial == null)
				{
					return;
				}
			}
			if (state)
			{
				currMaterial.EnableKeyword(keyword);
			}
			else
			{
				currMaterial.DisableKeyword(keyword);
			}
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x3C22478", Offset = "0x3C22478", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([B78D3AB]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_0030;\n\tv26 = UnityEngine.Component::GetComponent(this);\n\tv53 = v26;\n\tgoto L_001B;\nL_001B:\n\tv63 = UnityEngine.Object::op_Inequality(v53, 0);\n\tv75 = ~v63;\n\tif (v75) goto L_0047;\n\tv92 = UnityEngine.Component::GetComponent(this);\n\tv141 = UnityEngine.Renderer::get_sharedMaterial(v92);\n\tgoto L_006C;\nL_0030:\n\t*([B78D3AB]) = 1;\n\tv54 = UnityEngine.Component::GetComponent(this);\n\tv53 = v54;\n\tgoto L_001B;\nL_0047:\n\tv104 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0050;\nL_0050:\n\tv130 = UnityEngine.Object::op_Inequality(v104, 0);\n\tv132 = ~v130;\n\tv133 = ~v132;\n\tif (v133) goto L_0069;\n\treturn;\nL_0069:\n\tv141 = UnityEngine.UI.Graphic::get_material(v104);\nL_006C:\n\tthis.currMaterial = v141;\n\tthis.matAssigned = 1;\n\treturn;\n")]
		private void FindCurrMaterial()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78D3AB]");
			UnityEngine.Object obj;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Renderer component = GetComponent<Renderer>();
				obj = component;
			}
			else
			{
				_ = 1;
				Renderer component2 = GetComponent<Renderer>();
				obj = component2;
			}
			Material material;
			if (obj != null)
			{
				Renderer component3 = GetComponent<Renderer>();
				material = component3.sharedMaterial;
			}
			else
			{
				Graphic component4 = GetComponent<Graphic>();
				if (!(component4 != null))
				{
					return;
				}
				material = component4.material;
			}
			currMaterial = material;
			matAssigned = true;
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x3C2217C", Offset = "0x3C2217C", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_0037:\n\tv74 = UnityEngine.Object::op_Inequality(v53, 0);\n\tv78 = ~v74;\n\tif (v78) goto L_0059;\n\tv83 = UnityEngine.Shader::Find(\"Sprites/Default\");\n\tv118 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v118, v83);\n\tv104 = v53 == 0;\n\tif (v104) goto L_0094;\n\tUnityEngine.Renderer::set_sharedMaterial(v53, v118);\n\tthis.matAssigned = 0;\n\treturn;\nL_0059:\n\tv88 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0062;\nL_0062:\n\tv102 = UnityEngine.Object::op_Inequality(v88, 0);\n\tv105 = ~v102;\n\tv106 = ~v105;\n\tif (v106) goto L_0079;\n\treturn;\nL_0079:\n\tv148 = UnityEngine.Shader::Find(\"Sprites/Default\");\n\tv118 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v118, v148);\n\tv121 = v88 == 0;\n\tif (v121) goto L_0094;\n\tv171 = UnityEngine.UI.Graphic::set_material(v88, v118);\n\tthis.matAssigned = 0;\n\treturn;\nL_0094:\n\tthrow v118;\nL_0028:\n\tv53 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0037;\n")]
		public void CleanMaterial()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AllIn1Shader::CleanMaterial");
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x3C225F4", Offset = "0x3C225F4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		public bool SaveMaterial()
		{
			return false;
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x3C225FC", Offset = "0x3C225FC", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv69 = System.IO.File::Exists(v67);\n\tv70 = ~v69;\n\tif (v70) goto L_003E;\n\tv72 = v55 + 1;\n\tAllIn1SpriteShader.AllIn1Shader::SaveMaterialWithOtherName(this, path, v72);\nL_003E:\n\treturn;\nL_0022:\n\tv57 = System.Int32::ToString(&v55 @ stack_-44_v2 (System.Int32));\n\tv64 = System.String::Concat(path, \"_\", v57);\n\tv67 = System.String::Concat(v64, \".mat\");\n")]
		private void SaveMaterialWithOtherName(string path, int i = 1)
		{
			int num = default(int);
			string text = num.ToString();
			string text2 = path + "_" + text;
			string text3 = text2 + ".mat";
			if (File.Exists(text3))
			{
				int i2 = num + 1;
				SaveMaterialWithOtherName(path, i2);
			}
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x3C226C8", Offset = "0x3C226C8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void DoSaving(string fileName)
		{
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x3C22354", Offset = "0x3C22354", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetSceneDirty()
		{
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x3C22350", Offset = "0x3C22350", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void MissingRenderer()
		{
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x3C226CC", Offset = "0x3C226CC", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tgoto L_0031;\nL_0031:\n\tv72 = UnityEngine.Object::op_Equality(v54, 0);\n\tv79 = ~v72;\n\tv80 = ~v79;\n\tif (v80) goto L_005C;\n\tv206 = v54;\n\tgoto L_003C;\nL_003C:\n\treturnVal1 = UnityEngine.Object::op_Inequality(v206, 0);\n\tv198 = ~returnVal1;\n\tv115 = ~v198;\n\tif (v115) goto L_0073;\nL_0049:\n\treturn returnVal1;\nL_004B:\n\tgoto L_004F;\nL_004F:\n\treturnVal1 = UnityEngine.Object::op_Inequality(v54, 0);\n\tv85 = ~returnVal1;\n\tif (v85) goto L_0049;\n\tgoto L_008D;\nL_005C:\n\tv104 = UnityEngine.Component::get_gameObject(this);\n\tv202 = UnityEngine.GameObject::AddComponent(v104);\n\tv206 = v202;\n\tgoto L_003C;\nL_0073:\n\tv215 = AllIn1SpriteShader.SetAtlasUvs::GetAndSetUVs(v206);\n\tv221 = v215 == 0;\n\tv172 = ~v221;\n\tif (v172) goto L_009C;\n\treturn 0;\nL_008D:\n\tAllIn1SpriteShader.SetAtlasUvs::ResetAtlasUvs(v54);\n\tgoto L_0096;\nL_0096:\n\tUnityEngine.Object::DestroyImmediate(v54);\nL_009C:\n\tAllIn1SpriteShader.AllIn1Shader::SetKeyword(this, \"ATLAS_ON\", activate);\n\treturn 1;\nL_0026:\n\tv54 = UnityEngine.Component::GetComponent(this);\n\tv61 = ~activate;\n\tif (v61) goto L_004B;\n")]
		public bool ToggleSetAtlasUvs(bool activate)
		{
			SetAtlasUvs component = GetComponent<SetAtlasUvs>();
			bool flag;
			if (activate)
			{
				SetAtlasUvs setAtlasUvs;
				if (!(component == null))
				{
					setAtlasUvs = component;
				}
				else
				{
					GameObject gameObject = base.gameObject;
					SetAtlasUvs setAtlasUvs2 = gameObject.AddComponent<SetAtlasUvs>();
					setAtlasUvs = setAtlasUvs2;
				}
				flag = setAtlasUvs != null;
				if (!flag)
				{
					goto IL_007b;
				}
				if (!setAtlasUvs.GetAndSetUVs())
				{
					return false;
				}
			}
			else
			{
				flag = component != null;
				if (!flag)
				{
					goto IL_007b;
				}
				component.ResetAtlasUvs();
				UnityEngine.Object.DestroyImmediate(component);
			}
			SetKeyword("ATLAS_ON", activate);
			return true;
			IL_007b:
			return flag;
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x3C22F48", Offset = "0x3C22F48", Length = "0x554")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0043;\nL_0050:\n\tv87 = UnityEngine.Object::op_Inequality(v66, 0);\n\tv92 = ~v87;\n\tif (v92) goto L_0064;\n\tv306 = UnityEngine.Renderer::get_sharedMaterial(v66);\n\tgoto L_0078;\nL_0064:\n\tgoto L_0068;\nL_0068:\n\tv223 = UnityEngine.Object::op_Inequality(v73, 0);\n\tv294 = ~v223;\n\tif (v294) goto L_FFFFFFFF;\n\tv306 = UnityEngine.UI.Graphic::get_material(v73);\n\tAllIn1SpriteShader.AllIn1Shader::GetAllChildren(this, v444, &v184 @ stack_-68_v2 (System.Collections.Generic.List`1<UnityEngine.Transform>));\n\tv499 = System.Collections.Generic.List`1<UnityEngine.Transform>::GetEnumerator(v314);\n\tv257 = v499._list;\n\tv506 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v257 @ stack_-80_v3 (System.Collections.Generic.List`1<UnityEngine.Transform>));\n\tv507 = ~v506;\n\tif (v507) goto L_0147;\n\tv518 = v499.Current == 0;\n\tif (v518) goto L_0157;\n\tv532 = UnityEngine.Component::get_gameObject(v499.Current);\n\tv536 = v532 == 0;\n\tif (v536) goto L_0159;\n\tv539 = UnityEngine.GameObject::GetComponent(v532);\n\tgoto L_00CD;\nL_00CD:\n\tv281 = UnityEngine.Object::op_Inequality(v539, 0);\n\tv552 = v281 == 0;\n\tif (v552) goto L_00E6;\n\tv283 = v539 == 0;\n\tif (v283) goto L_0166;\n\tUnityEngine.Renderer::set_material(v539, v306);\n\tgoto L_0102;\nL_FFFFFFFF:\n\tv426 = 0;\n\tgoto L_0156;\nL_00E6:\n\tv555 = UnityEngine.Component::get_gameObject(v499.Current);\n\tv559 = v555 == 0;\n\tif (v559) goto L_0168;\n\tv561 = UnityEngine.GameObject::GetComponent(v555);\n\tgoto L_00F5;\nL_00F5:\n\tv578 = UnityEngine.Object::op_Inequality(v561, 0);\n\tv584 = ~v578;\n\tif (v584) goto L_0102;\n\tv583 = v561 == 0;\n\tif (v583) goto L_016A;\n\tv577 = UnityEngine.UI.Graphic::set_material(v561, v306);\n\tv534 = v499.Current == 0;\n\tif (v534) goto L_0157;\n\tv542 = UnityEngine.Component::get_gameObject(v499.Current);\n\tv543 = v542 == 0;\n\tif (v543) goto L_0159;\n\tv610 = UnityEngine.GameObject::GetComponent(v542);\n\tgoto L_011A;\nL_011A:\n\tv346 = UnityEngine.Object::op_Inequality(v610, 0);\n\tv620 = v346 == 0;\n\tif (v620) goto L_0127;\n\tv348 = v610 == 0;\n\tif (v348) goto L_015C;\n\tUnityEngine.Renderer::set_material(v610, v306);\n\tgoto L_0102;\nL_0127:\n\tv599 = UnityEngine.Component::get_gameObject(v499.Current);\n\tv600 = v599 == 0;\n\tif (v600) goto L_015F;\n\tv623 = UnityEngine.GameObject::GetComponent(v599);\n\tgoto L_0136;\nL_0136:\n\tv580 = UnityEngine.Object::op_Inequality(v623, 0);\n\tv585 = v580 == 0;\n\tif (v585) goto L_0102;\n\tv581 = UnityEngine.UI.Graphic::set_material(v623, v306);\n\tgoto L_0102;\nL_0147:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v257 @ stack_-80_v3 (System.Collections.Generic.List`1<UnityEngine.Transform>));\nL_FFFFFFFF:\n\tv426 = v506;\nL_0156:\n\treturn v426;\nL_0157:\n\tv472 = new System.NullReferenceException();\n\tgoto L_0163;\nL_0159:\n\tv473 = new System.NullReferenceException();\n\tgoto L_0163;\nL_0163:\n\t// 355 Interrupt\nL_0166:\n\tgoto L_015C;\nL_0168:\n\tgoto L_015F;\nL_016A:\n\tgoto L_0162;\nL_0043:\n\tv66 = UnityEngine.Component::GetComponent(this);\n\tv73 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0050;\n\tv219 = new System.NullReferenceException();\nL_0078:\n\tv314 = new System.Collections.Generic.List`1<UnityEngine.Transform>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::.ctor(v314);\n\tv184 = v314;\n\tv444 = UnityEngine.Component::get_transform(this);\nL_0102:\n\tv523 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v257 @ stack_-80_v3 (System.Collections.Generic.List`1<UnityEngine.Transform>));\n\tv524 = v523 == 0;\n\tif (v524) goto L_0147;\nL_015C:\n\tv358 = new System.NullReferenceException();\n\tgoto L_0163;\nL_015F:\n\tv474 = new System.NullReferenceException();\n\tgoto L_0163;\nL_0162:\n\tv471 = new System.NullReferenceException();\n")]
		public unsafe bool ApplyMaterialToHierarchy()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AllIn1Shader::ApplyMaterialToHierarchy");
			return default;
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x3C237F4", Offset = "0x3C237F4", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0031:\n\tv72 = UnityEngine.Object::op_Equality(v55, 0);\n\tv74 = ~v72;\n\tif (v74) goto L_0059;\n\tgoto L_0046;\nL_0046:\n\tv114 = UnityEngine.Object::op_Equality(v62, 0);\n\treturn;\nL_0059:\n\treturn;\nL_0024:\n\tv55 = UnityEngine.Component::GetComponent(this);\n\tv62 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0031;\n")]
		public void CheckIfValidTarget()
		{
			Renderer component = GetComponent<Renderer>();
			Graphic component2 = GetComponent<Graphic>();
			if (component == null)
			{
				bool flag = component2 == null;
			}
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x3C2349C", Offset = "0x3C2349C", Length = "0x358")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv193 = 0xB28F000 + 0x8D0;\n\tv68 = UnityEngine.Transform::GetEnumerator(parent);\n\tgoto L_0042;\nL_003C:\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::AddWithResize(*([transforms @ X2 (System.Collections.Generic.List`1<UnityEngine.Transform>&)]), v621);\nL_0040:\n\tAllIn1SpriteShader.AllIn1Shader::GetAllChildren(this, v621, transforms);\nL_0042:\n\tv244 = v120 == 0;\n\tif (v244) goto L_012A;\n\tgoto L_006E;\n\tgoto L_00A0;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v641_asT @ TEMPCOND_v17 (UnityEngine.Transform), typeof(UnityEngine.Transform), v621 @ X0_v35 (System.Object)\n\tv641 = v641_asT == 0;\nL_FFFFFFFF:\n\t;\n\tif (v641) goto L_0128;\nL_00C2:\n\tv653 = transforms->klass;\n\tv654 = *([transforms @ X2 (System.Collections.Generic.List`1<UnityEngine.Transform>&)]) == 0;\n\tif (v654) goto L_0125;\n\tv661 = v653._version + 1;\n\tv653._version = v661;\n\tv230 = v653._items;\n\tv238 = v653._items == 0;\n\tif (v238) goto L_0125;\n\tv228 = v653.Count;\n\tv662 = v653.Count < v230.Length;\n\tv226 = ~v662;\n\tif (v226) goto L_003C;\n\tv663 = v653.Count + 1;\n\tv653.Count = v663;\n\tv230[v228 @ X10_v16 (System.Int32)] = v621;\n\tgoto L_0040;\nL_00E2:\n\tv389 = &v120 @ stack_-58_v6 (System.Collections.IEnumerator);\n\tv390 = &v53 @ stack_-60_v1;\n\tv628 = 0x21C11D0(*([v389 @ X8_v20]), System.IDisposable, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v390 @ X20_v9]) = v628;\n\tv400 = v628 == 0;\nL_FFFFFFFF:\n\tv414 = 0;\nL_FFFFFFFF:\n\tv415 = &v53 @ stack_-60_v1;\nL_FFFFFFFF:\n\tv416 = &v120 @ stack_-58_v6 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv116 = 0;\nL_FFFFFFFF:\n\tv429 = 0;\nL_FFFFFFFF:\n\tv169 = 0;\nL_FFFFFFFF:\n\tv171 = &v53 @ stack_-60_v1;\nL_FFFFFFFF:\n\tv173 = &v120 @ stack_-58_v6 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv116 = 0;\nL_FFFFFFFF:\n\tv180 = System.IDisposable;\nL_FFFFFFFF:\n\tv194 = v193;\nL_FFFFFFFF:\n\tv200 = 0;\n\tif (v400) goto L_0116;\nL_00EB:\n\tv431 = *([v628 @ X0_v18]);\n\tv586 = *([v431 @ X8_v8+12E]);\n\tv433 = *([v431 @ X8_v8+12E]) == 0;\n\tif (v433) goto L_010B;\n\tv585 = *([v431 @ X8_v8+B0]) + 8;\n\tv585 = v585 + 0x10;\n\tv550 = v586 - 1;\n\tv530 = v586 != 1;\nL_FFFFFFFF:\n\tv586 = v550;\n\tif (v530) goto L_00F6;\nL_010B:\n\tv553 = 0x220C5E0(v628, *([v193 @ X22_v5 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv169 = 0;\nL_FFFFFFFF:\n\tv522 = v553;\n\tgoto L_0114;\nL_0110:\n\tv624 = *([v585 @ X10_v9]) << 4;\n\tv625 = v431 + v624;\n\tv522 = v625 + 0x138;\nL_FFFFFFFF:\n\tv169 = v414;\n\treturn;\nL_0125:\n\tv357 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv169 = 0;\nL_FFFFFFFF:\n\t;\n\tgoto L_012D;\nL_0128:\n\tv358 = new System.InvalidCastException();\nL_FFFFFFFF:\n\tv169 = 0;\n\tgoto L_012D;\nL_012A:\n\tv249 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv169 = 0;\nL_FFFFFFFF:\n\t;\n\tgoto L_012D;\nL_012D:\n\t// 301 Interrupt\nL_FFFFFFFF:\n\tv171 = &v53 @ stack_-60_v1;\nL_FFFFFFFF:\n\tv173 = &v120 @ stack_-58_v6 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv116 = 0;\nL_0130:\n\tv202 = new System.OutOfMemoryException();\n\tgoto L_0141;\nL_0141:\n\tv259 = v180 != 1;\n\tif (v259) goto L_0153;\n\tv289 = 0x8BF5BC4(v202, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv429 = *([v289 @ X0_v13]);\n\tv368 = 0x8BF5BF4(v289, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv180 = *([v194 @ X22_v3 (System.Int32)]);\n\tv628 = 0x21C11D0(*([v173 @ stack_-70_v3]), *([v194 @ X22_v3 (System.Int32)]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v171 @ stack_-68_v3]) = v628;\n\tv394 = v628 == 0;\n\tv395 = ~v394;\nL_FFFFFFFF:\n\tv414 = v169;\nL_FFFFFFFF:\n\tv415 = v171;\nL_FFFFFFFF:\n\tv416 = v173;\nL_FFFFFFFF:\n\tv116 = *([v289 @ X0_v13]);\n\tif (v395) goto L_00EB;\nL_FFFFFFFF:\n\tv116 = *([v289 @ X0_v13]);\nL_FFFFFFFF:\n\tv194 = v194;\nL_FFFFFFFF:\n\tv200 = *([v289 @ X0_v13]);\n\tgoto L_0116;\nL_0153:\n\tv292 = 0x3173D6C(&v116 @ stack_-78_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv370 = 0x8BF0368(v202, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv387 = 0xA1B8(v370, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0023:\n\tv53 = 0;\nL_006E:\n\tv379 = System.Collections.IEnumerator::MoveNext(v120);\n\tv381 = v379 == 0;\n\tif (v381) goto L_00E2;\nL_00A0:\n\tv621 = System.Collections.IEnumerator::get_Current(v120);\n\tv361 = v621 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v361) goto L_00C2;\nL_0116:\n\tv524 = v200 == 0;\n\tv190 = ~v524;\nL_FFFFFFFF:\n\tv193 = v194;\n\tif (v190) goto L_0130;\nL_00F6:\n\tv591 = *([v585 @ X10_v9-8]) == *([v193 @ X22_v5 (System.Int32)]);\n\tif (v591) goto L_0110;\nL_0114:\n\tv180 = *([v522 @ X8_v9+8]);\n\t*([v522 @ X8_v9])(v520, v628, *([v522 @ X8_v9+8]), v169, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_FFFFFFFF:\n\tv171 = v415;\nL_FFFFFFFF:\n\tv173 = v416;\nL_FFFFFFFF:\n\tv194 = v193;\nL_FFFFFFFF:\n\tv200 = v429;\n\tthrow System.NullReferenceException;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void GetAllChildren(Transform parent, ref List<Transform> transforms)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AllIn1Shader::GetAllChildren");
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x3C238F8", Offset = "0x3C238F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		public bool RenderToImage()
		{
			return false;
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x3C23900", Offset = "0x3C23900", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		private bool RenderAndSaveTexture(Material targetMaterial, Texture targetTexture)
		{
			return false;
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x3C23908", Offset = "0x3C23908", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv70 = System.IO.File::Exists(v67);\n\tv71 = ~v70;\n\tv83 = v67;\n\tif (v71) goto L_0041;\n\tv73 = v55 + 1;\n\tv77 = AllIn1SpriteShader.AllIn1Shader::GetNewValidPath(this, path, v73);\n\tv83 = v77;\nL_0022:\n\tv57 = System.Int32::ToString(&v55 @ stack_-44_v2 (System.Int32));\n\tv64 = System.String::Concat(path, \"_\", v57);\n\tv67 = System.String::Concat(v64, \".png\");\nL_0041:\n\treturn v83;\n")]
		private string GetNewValidPath(string path, int i = 1)
		{
			int num = default(int);
			string text = num.ToString();
			string text2 = path + "_" + text;
			string text3 = text2 + ".png";
			bool flag = File.Exists(text3);
			bool flag2 = !flag;
			string result = text3;
			if (!flag2)
			{
				int i2 = num + 1;
				string newValidPath = GetNewValidPath(path, i2);
				result = newValidPath;
			}
			return result;
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x3C239E0", Offset = "0x3C239E0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void OnEnable()
		{
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x3C239E4", Offset = "0x3C239E4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void OnDisable()
		{
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x3C239E8", Offset = "0x3C239E8", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.computingNormal != 1;\n\tif (v11) goto L_002E;\n\tv22 = this.needToWait != 1;\n\tif (v22) goto L_002D;\n\tv43 = this.waitingCycles + 1;\n\tthis.waitingCycles = v43;\n\tv24 = v43 < 6;\n\tif (v24) goto L_002E;\n\tthis.needToWait = 0;\n\tv57 = this.timesWeWaited + 1;\n\tthis.timesWeWaited = v57;\n\treturn;\nL_002D:\n\tthis.needToWait = 1;\nL_002E:\n\treturn;\n")]
		protected virtual void OnEditorUpdate()
		{
			if (!computingNormal)
			{
				return;
			}
			if (needToWait)
			{
				if (++waitingCycles >= 6)
				{
					needToWait = false;
					int num = timesWeWaited + 1;
					timesWeWaited = num;
				}
			}
			else
			{
				needToWait = true;
			}
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x3C23A40", Offset = "0x3C23A40", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void CreateAndAssignNormalMap()
		{
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x3C23A44", Offset = "0x3C23A44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.computingNormal = 0;\n\treturn;\n")]
		private void SetNewNormalTexture()
		{
			computingNormal = false;
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0x3C23A34", Offset = "0x3C23A34", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void SetNewNormalTexture2()
		{
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0x3C23A38", Offset = "0x3C23A38", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void SetNewNormalTexture3()
		{
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0x3C23A3C", Offset = "0x3C23A3C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void SetNewNormalTexture4()
		{
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0x3C23A4C", Offset = "0x3C23A4C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.currentShaderType = 4;\n\tthis.normalStrength = 5f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public AllIn1Shader()
		{
			currentShaderType = ShaderTypes.Invalid;
			normalStrength = 5f;
		}
	}
}
