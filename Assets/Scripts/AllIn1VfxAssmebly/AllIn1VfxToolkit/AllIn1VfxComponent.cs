using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AllIn1VfxToolkit
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[AddComponentMenu("AllIn1VfxToolkit/AddAllIn1Vfx")]
	[Token(Token = "0x2000012")]
	public class AllIn1VfxComponent : MonoBehaviour
	{
		[Token(Token = "0x2000013")]
		private enum AfterSetAction
		{
			[Token(Token = "0x4000060")]
			Clear = 0,
			[Token(Token = "0x4000061")]
			CopyMaterial = 1,
			[Token(Token = "0x4000062")]
			Reset = 2
		}

		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x20")]
		private Material currMaterial;

		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x28")]
		private Material prevMaterial;

		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0x30")]
		private bool matAssigned;

		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0x31")]
		private bool destroyed;

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x3C25820", Offset = "0x3C25820", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void MakeNewMaterial(string shaderName = "AllIn1Vfx", bool notifyWhenDone = false)
		{
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x3C2582C", Offset = "0x3C2582C", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this.currMaterial, 0);\n\tv64 = ~v55;\n\tv65 = ~v64;\n\tif (v65) goto L_0036;\n\tgoto L_003F;\nL_0036:\n\tv81 = AllIn1VfxToolkit.AllIn1VfxComponent::FetchCurrentMaterial(this);\n\tv94 = v81 == 0;\n\tv88 = ~v94;\n\tif (v88) goto L_005D;\nL_003F:\n\tv96 = UnityEngine.Material::get_shader(this.currMaterial);\n\tv100 = UnityEngine.Object::get_name(v96);\n\tv115 = System.String::Contains(v100, \"AllIn1Vfx/\");\n\tv117 = ~v115;\n\tif (v117) goto L_005D;\n\tv114 = System.String::Replace(v100, \"AllIn1Vfx/\", \"\");\nL_005D:\n\treturn 0;\n")]
		public bool MakeCopy()
		{
			if (!(currMaterial == null) || !FetchCurrentMaterial())
			{
				Shader shader = currMaterial.shader;
				string text = shader.name;
				if (text.Contains("AllIn1Vfx/"))
				{
					string text2 = text.Replace("AllIn1Vfx/", "");
				}
			}
			return false;
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x3C2594C", Offset = "0x3C2594C", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0029:\n\tv62 = UnityEngine.Object::op_Inequality(v49, 0);\n\tv64 = ~v62;\n\tif (v64) goto L_003E;\n\tv114 = UnityEngine.Renderer::get_sharedMaterial(v49);\n\tgoto L_0053;\nL_003E:\n\tv83 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0047;\nL_0047:\n\tv106 = UnityEngine.Object::op_Inequality(v83, 0);\n\tv153 = ~v106;\n\tif (v153) goto L_006F;\n\tv114 = UnityEngine.UI.Graphic::get_material(v83);\nL_006F:\n\treturn 1;\nL_0020:\n\tv49 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0029;\nL_0053:\n\tthis.currMaterial = v114;\n\treturn 0;\n")]
		private bool FetchCurrentMaterial()
		{
			Renderer component = GetComponent<Renderer>();
			Material material;
			if (component != null)
			{
				material = component.sharedMaterial;
			}
			else
			{
				Graphic component2 = GetComponent<Graphic>();
				if (!(component2 != null))
				{
					return true;
				}
				material = component2.material;
			}
			currMaterial = material;
			return false;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x3C25AAC", Offset = "0x3C25AAC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void ResetAllProperties(string shaderName)
		{
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x3C25824", Offset = "0x3C25824", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		private bool SetMaterial(AfterSetAction action, string shaderName)
		{
			return false;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x3C25AB0", Offset = "0x3C25AB0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = action == 1;\n\tif (v5) goto L_0015;\n\tv10 = action == 0;\n\tv11 = ~v10;\n\tif (v11) goto L_0017;\n\tAllIn1VfxToolkit.AllIn1VfxComponent::ClearAllKeywords(this);\n\treturn;\nL_0015:\n\tUnityEngine.Material::CopyPropertiesFromMaterial(this.currMaterial, this.prevMaterial);\n\treturn;\nL_0017:\n\treturn;\n")]
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

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x3C26410", Offset = "0x3C26410", Length = "0x284")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\nL_002F:\n\tv63 = UnityEngine.Object::op_Inequality(v49, 0);\n\tv68 = ~v63;\n\tif (v68) goto L_004A;\n\tgoto L_0039;\nL_0039:\n\tv96 = UnityEngine.Object::op_Inequality(v49, 0);\n\tv102 = ~v96;\n\tv103 = ~v102;\n\tif (v103) goto L_006A;\n\tgoto L_00C8;\nL_004A:\n\tv91 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0053;\nL_0053:\n\treturnVal1 = UnityEngine.Object::op_Inequality(v91, 0);\n\tv119 = ~returnVal1;\n\tv120 = ~v119;\n\tif (v120) goto L_0083;\n\treturn returnVal1;\nL_006A:\n\tv153 = UnityEngine.Renderer::get_sharedMaterial(v49);\n\tgoto L_0071;\nL_0071:\n\tv137 = UnityEngine.Object::op_Inequality(v153, 0);\n\tv246 = ~v137;\n\tv141 = ~v246;\n\tif (v141) goto L_00AA;\n\tgoto L_00C8;\nL_0083:\n\tv169 = UnityEngine.UI.Graphic::get_material(v91);\n\tv170 = UnityEngine.Material::get_shader(v169);\n\tv171 = UnityEngine.Object::get_name(v170);\n\tv253 = System.String::Contains(v171, \"Vfx\");\n\tv254 = ~v253;\n\tv223 = ~v254;\n\tif (v223) goto L_00BD;\n\treturn 1;\nL_00AA:\n\tv172 = UnityEngine.Renderer::get_sharedMaterial(v49);\n\tv173 = UnityEngine.Material::get_shader(v172);\n\tv174 = UnityEngine.Object::get_name(v173);\n\tv139 = System.String::Contains(v174, \"Vfx\");\n\tv143 = ~v139;\n\tif (v143) goto L_00C8;\nL_00BD:\n\tAllIn1VfxToolkit.AllIn1VfxComponent::ClearAllKeywords(this);\n\treturn 1;\nL_00C8:\n\tAllIn1VfxToolkit.AllIn1VfxComponent::CleanMaterial(this);\n\treturn 1;\nL_0026:\n\tv49 = UnityEngine.Component::GetComponent(this);\n\tgoto L_002F;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
						Shader shader = sharedMaterial2.shader;
						string text = shader.name;
						if (text.Contains("Vfx"))
						{
							goto IL_01cf;
						}
					}
				}
				CleanMaterial();
				return true;
			}
			Graphic component2 = GetComponent<Graphic>();
			bool flag = component2 != null;
			if (!flag)
			{
				return flag;
			}
			Material material = component2.material;
			Shader shader2 = material.shader;
			string text2 = shader2.name;
			if (!text2.Contains("Vfx"))
			{
				return true;
			}
			goto IL_01cf;
			IL_01cf:
			ClearAllKeywords();
			return true;
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x3C25AE8", Offset = "0x3C25AE8", Length = "0x928")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_00E7;\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"DISTORTONLYBACK_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE1SCREENUV_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE2SCREENUV_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE3SCREENUV_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPEDEBUG_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE1CONTRAST_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE1DISTORT_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE1ROTATE_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE1SHAPECOLOR_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE2_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE2CONTRAST_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE2DISTORT_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE2ROTATE_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE2SHAPECOLOR_\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE3_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE3CONTRAST_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE3DISTORT_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE3ROTATE_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE3SHAPECOLOR_\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"GLOW_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"GLOWTEX_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SOFTPART_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"DEPTHGLOW_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"MASK_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"COLORRAMP_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"COLORRAMPGRAD_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"COLORGRADING_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"HSV_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"BLUR_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"BLURISHD_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"POSTERIZE_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"FADE_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"FADEBURN_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"PIXELATE_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"DISTORT_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAKEUV_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"WAVEUV_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"ROUNDWAVEUV_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"TWISTUV_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"DOODLE_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"OFFSETSTREAM_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"TEXTURESCROLL_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"VERTOFFSET_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"RIM_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"BACKFACETINT_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"POLARUV_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"POLARUVDISTORT_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPE1MASK_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"TRAILWIDTH_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"LIGHTANDSHADOW_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPETEXOFFSET_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SHAPEWEIGHTS_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"ALPHACUTOFF_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"ALPHASMOOTHSTEP_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"ALPHAFADE_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"ALPHAFADEUSESHAPE1_\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"ALPHAFADEUSEREDCHAN\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"ALPHAFADETRANSPAREN\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"ALPHAFADEINPUTSTREA\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"CAMDISTFADE_ON\", 0);\n\treturn;\nL_00E7:\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"FOG_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"SCREENDISTORTION_ON\", 0);\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SetKeyword(this, \"DISTORTUSECOL_ON\", 0);\n")]
		public void ClearAllKeywords()
		{
			SetKeyword("FOG_ON");
			SetKeyword("SCREENDISTORTION_ON");
			SetKeyword("DISTORTUSECOL_ON");
			SetKeyword("DISTORTONLYBACK_ON");
			SetKeyword("SHAPE1SCREENUV_ON");
			SetKeyword("SHAPE2SCREENUV_ON");
			SetKeyword("SHAPE3SCREENUV_ON");
			SetKeyword("SHAPEDEBUG_ON");
			SetKeyword("SHAPE1CONTRAST_ON");
			SetKeyword("SHAPE1DISTORT_ON");
			SetKeyword("SHAPE1ROTATE_ON");
			SetKeyword("SHAPE1SHAPECOLOR_ON");
			SetKeyword("SHAPE2_ON");
			SetKeyword("SHAPE2CONTRAST_ON");
			SetKeyword("SHAPE2DISTORT_ON");
			SetKeyword("SHAPE2ROTATE_ON");
			SetKeyword("SHAPE2SHAPECOLOR_");
			SetKeyword("SHAPE3_ON");
			SetKeyword("SHAPE3CONTRAST_ON");
			SetKeyword("SHAPE3DISTORT_ON");
			SetKeyword("SHAPE3ROTATE_ON");
			SetKeyword("SHAPE3SHAPECOLOR_");
			SetKeyword("GLOW_ON");
			SetKeyword("GLOWTEX_ON");
			SetKeyword("SOFTPART_ON");
			SetKeyword("DEPTHGLOW_ON");
			SetKeyword("MASK_ON");
			SetKeyword("COLORRAMP_ON");
			SetKeyword("COLORRAMPGRAD_ON");
			SetKeyword("COLORGRADING_ON");
			SetKeyword("HSV_ON");
			SetKeyword("BLUR_ON");
			SetKeyword("BLURISHD_ON");
			SetKeyword("POSTERIZE_ON");
			SetKeyword("FADE_ON");
			SetKeyword("FADEBURN_ON");
			SetKeyword("PIXELATE_ON");
			SetKeyword("DISTORT_ON");
			SetKeyword("SHAKEUV_ON");
			SetKeyword("WAVEUV_ON");
			SetKeyword("ROUNDWAVEUV_ON");
			SetKeyword("TWISTUV_ON");
			SetKeyword("DOODLE_ON");
			SetKeyword("OFFSETSTREAM_ON");
			SetKeyword("TEXTURESCROLL_ON");
			SetKeyword("VERTOFFSET_ON");
			SetKeyword("RIM_ON");
			SetKeyword("BACKFACETINT_ON");
			SetKeyword("POLARUV_ON");
			SetKeyword("POLARUVDISTORT_ON");
			SetKeyword("SHAPE1MASK_ON");
			SetKeyword("TRAILWIDTH_ON");
			SetKeyword("LIGHTANDSHADOW_ON");
			SetKeyword("SHAPETEXOFFSET_ON");
			SetKeyword("SHAPEWEIGHTS_ON");
			SetKeyword("ALPHACUTOFF_ON");
			SetKeyword("ALPHASMOOTHSTEP_ON");
			SetKeyword("ALPHAFADE_ON");
			SetKeyword("ALPHAFADEUSESHAPE1_");
			SetKeyword("ALPHAFADEUSEREDCHAN");
			SetKeyword("ALPHAFADETRANSPAREN");
			SetKeyword("ALPHAFADEINPUTSTREA");
			SetKeyword("CAMDISTFADE_ON");
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x3C2686C", Offset = "0x3C2686C", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_0025:\n\treturn;\nL_002C:\n\tgoto L_0030;\nL_0030:\n\tv123 = UnityEngine.Object::op_Equality(this.currMaterial, 0);\n\tv125 = ~v123;\n\tv126 = ~v125;\n\tif (v126) goto L_003D;\n\tgoto L_004F;\nL_003D:\n\tAllIn1VfxToolkit.AllIn1VfxComponent::FindCurrMaterial(this);\n\tgoto L_0048;\nL_0048:\n\tv58 = UnityEngine.Object::op_Equality(this.currMaterial, 0);\n\tv148 = v58 == 0;\n\tv60 = ~v148;\n\tif (v60) goto L_0025;\nL_004F:\n\tv140 = state == 0;\n\tif (v140) goto L_006D;\n\tUnityEngine.Material::EnableKeyword(this.currMaterial, keyword);\n\treturn;\nL_006D:\n\tUnityEngine.Material::DisableKeyword(this.currMaterial, keyword);\n\treturn;\nL_001A:\n\tv50 = this.destroyed == 0;\n\tif (v50) goto L_002C;\n")]
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

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x3C2698C", Offset = "0x3C2698C", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([B78D3D9]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_0030;\n\tv26 = UnityEngine.Component::GetComponent(this);\n\tv53 = v26;\n\tgoto L_001B;\nL_001B:\n\tv63 = UnityEngine.Object::op_Inequality(v53, 0);\n\tv75 = ~v63;\n\tif (v75) goto L_0047;\n\tv92 = UnityEngine.Component::GetComponent(this);\n\tv141 = UnityEngine.Renderer::get_sharedMaterial(v92);\n\tgoto L_006C;\nL_0030:\n\t*([B78D3D9]) = 1;\n\tv54 = UnityEngine.Component::GetComponent(this);\n\tv53 = v54;\n\tgoto L_001B;\nL_0047:\n\tv104 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0050;\nL_0050:\n\tv130 = UnityEngine.Object::op_Inequality(v104, 0);\n\tv132 = ~v130;\n\tv133 = ~v132;\n\tif (v133) goto L_0069;\n\treturn;\nL_0069:\n\tv141 = UnityEngine.UI.Graphic::get_material(v104);\nL_006C:\n\tthis.currMaterial = v141;\n\tthis.matAssigned = 1;\n\treturn;\n")]
		private void FindCurrMaterial()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78D3D9]");
			Object obj;
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

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x3C26694", Offset = "0x3C26694", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_0037:\n\tv74 = UnityEngine.Object::op_Inequality(v53, 0);\n\tv78 = ~v74;\n\tif (v78) goto L_0059;\n\tv83 = UnityEngine.Shader::Find(\"Sprites/Default\");\n\tv118 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v118, v83);\n\tv104 = v53 == 0;\n\tif (v104) goto L_0094;\n\tUnityEngine.Renderer::set_sharedMaterial(v53, v118);\n\tthis.matAssigned = 0;\n\treturn;\nL_0059:\n\tv88 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0062;\nL_0062:\n\tv102 = UnityEngine.Object::op_Inequality(v88, 0);\n\tv105 = ~v102;\n\tv106 = ~v105;\n\tif (v106) goto L_0079;\n\treturn;\nL_0079:\n\tv148 = UnityEngine.Shader::Find(\"Sprites/Default\");\n\tv118 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v118, v148);\n\tv121 = v88 == 0;\n\tif (v121) goto L_0094;\n\tv171 = UnityEngine.UI.Graphic::set_material(v88, v118);\n\tthis.matAssigned = 0;\n\treturn;\nL_0094:\n\tthrow v118;\nL_0028:\n\tv53 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0037;\n")]
		public void CleanMaterial()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AllIn1VfxComponent::CleanMaterial");
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x3C26B08", Offset = "0x3C26B08", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		public bool SaveMaterial()
		{
			return false;
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x3C26B10", Offset = "0x3C26B10", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv69 = System.IO.File::Exists(v67);\n\tv70 = ~v69;\n\tif (v70) goto L_003E;\n\tv72 = v55 + 1;\n\tAllIn1VfxToolkit.AllIn1VfxComponent::SaveMaterialWithOtherName(this, path, v72);\nL_003E:\n\treturn;\nL_0022:\n\tv57 = System.Int32::ToString(&v55 @ stack_-44_v2 (System.Int32));\n\tv64 = System.String::Concat(path, \"_\", v57);\n\tv67 = System.String::Concat(v64, \".mat\");\n")]
		private void SaveMaterialWithOtherName(string path, int i = 1)
		{
			int num = default(int);
			string text = num.ToString();
			string text2 = path + "_" + text;
			string path2 = text2 + ".mat";
			if (File.Exists(path2))
			{
				int i2 = num + 1;
				SaveMaterialWithOtherName(path, i2);
			}
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x3C26BDC", Offset = "0x3C26BDC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void DoSaving(string fileName)
		{
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x3C26868", Offset = "0x3C26868", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetSceneDirty()
		{
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x3C25AA8", Offset = "0x3C25AA8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void MissingRenderer()
		{
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x3C26BE0", Offset = "0x3C26BE0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public AllIn1VfxComponent()
		{
		}
	}
}
