using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AllIn1SpriteShader
{
	[Token(Token = "0x2000008")]
	public class All1ShaderDemoController : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x20")]
		private DemoCircleExpositor[] expositors;

		[SerializeField]
		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x28")]
		private Text expositorsTitle;

		[SerializeField]
		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x30")]
		private Text expositorsTitleOutline;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x38")]
		public float expositorDistance;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x3C")]
		internal int currExpositor;

		[SerializeField]
		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x40")]
		private GameObject background;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x48")]
		private Material backgroundMat;

		[SerializeField]
		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x50")]
		private float colorLerpSpeed;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x58")]
		private Color[] targetColors;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x60")]
		private Color[] currentColors;

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x3C1DDD0", Offset = "0x3C1DDD0", Length = "0x27C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv246 = 0xB2CA000 + 0x580;\n\tv204 = 0xB28A000 + 0x218;\n\tv201 = 0xB305000 + 0x1D8;\n\tv198 = 0xB305000 + 0x1E0;\n\tv196 = 0xB305000 + 0x1C8;\n\tv194 = 0xB305000 + 0x1D0;\n\tv208 = 0;\n\tv213 = UnityEngine.Component::get_transform(v266[v208 @ X21_v10 (System.Int32)]);\n\tv163 = this.expositorDistance * v208;\n\t// 87 MakeStruct v151 @ AGG3C1DED0_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v163 @ V1_v8 (System.Single), 0\n\tUnityEngine.Transform::set_position(v213, v151);\n\tv266 = this.expositors;\n\tv208 = v208 + 1;\n\tv286 = this.expositors == 0;\n\tv223 = ~v286;\n\tif (v223) goto L_0046;\n\tthrow System.NullReferenceException;\nL_0063:\n\tv216 = UnityEngine.GameObject::GetComponent /* +1 sharing this address */(this.background, *([v246 @ X20_v8 (System.Int32)]));\n\tv241 = *([v216 @ X0_v5]);\n\t*([v241 @ X8_v5+338])(v276, v216, *([v241 @ X8_v5+340]), v136, v38, v39, v40, v41, v42, 0, v163, 0, v130, v47, v48, v49, v50);\n\tthis.backgroundMat = v276;\n\tv285 = \"SzArrayNew\"(*([v204 @ X22_v4 (System.Int32)]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tthis.targetColors = v285;\n\tv144 = this.targetColors;\n\tv175 = UnityEngine.Material::GetColor(this.backgroundMat, *([v201 @ X26_v6 (UnityEngine.Color[])]));\n\t*([v144 @ X27_v2 (UnityEngine.Color[])+20]) = v175;\n\t*([v144 @ X27_v2 (UnityEngine.Color[])+24]) = v175.g;\n\t*([v144 @ X27_v2 (UnityEngine.Color[])+28]) = v175.b;\n\t*([v144 @ X27_v2 (UnityEngine.Color[])+2C]) = v175.a;\n\tv203 = this.targetColors;\n\tv176 = UnityEngine.Material::GetColor(this.backgroundMat, *([v198 @ X25_v6 (UnityEngine.Color[])]));\n\t*([v203 @ X26_v3 (UnityEngine.Color[])+30]) = v176;\n\t*([v203 @ X26_v3 (UnityEngine.Color[])+34]) = v176.g;\n\t*([v203 @ X26_v3 (UnityEngine.Color[])+38]) = v176.b;\n\t*([v203 @ X26_v3 (UnityEngine.Color[])+3C]) = v176.a;\n\tv200 = this.targetColors;\n\tv177 = UnityEngine.Material::GetColor(this.backgroundMat, *([v196 @ X24_v4 (System.Int32)]));\n\t*([v200 @ X25_v3 (UnityEngine.Color[])+40]) = v177;\n\t*([v200 @ X25_v3 (UnityEngine.Color[])+44]) = v177.g;\n\t*([v200 @ X25_v3 (UnityEngine.Color[])+48]) = v177.b;\n\t*([v200 @ X25_v3 (UnityEngine.Color[])+4C]) = v177.a;\n\tv211 = this.targetColors;\n\tv178 = UnityEngine.Material::GetColor(this.backgroundMat, *([v194 @ X23_v4 (System.Int32)]));\n\t*([v211 @ X21_v5 (UnityEngine.Color[])+50]) = v178;\n\t*([v211 @ X21_v5 (UnityEngine.Color[])+54]) = v178.g;\n\t*([v211 @ X21_v5 (UnityEngine.Color[])+58]) = v178.b;\n\t*([v211 @ X21_v5 (UnityEngine.Color[])+5C]) = v178.a;\n\tv362 = System.Array::Clone(this.targetColors);\n\tv365 = 0x21C11D0(v362, *([v204 @ X22_v4 (System.Int32)]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tthis.currentColors = v365;\n\tv369 = 0x21C11D0(v362, *([v204 @ X22_v4 (System.Int32)]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0029:\n\tthis.currExpositor = 0;\n\tAllIn1SpriteShader.All1ShaderDemoController::SetExpositorText(this);\n\tv266 = this.expositors;\nL_0046:\n\tv78 = v208 >= v266.Length;\n\tif (v78) goto L_0063;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("All1ShaderDemoController::Start");
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x3C1E104", Offset = "0x3C1E104", Length = "0x38C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv307 = this.targetColors;\n\tv253 = this.currExpositor / v307.Length;\n\tv376 = v253 * v307.Length;\n\tv267 = this.currExpositor - v376;\n\tv149 = v267 << 4;\n\tv445 = v307 + v149;\n\tv327 = UnityEngine.Time::get_deltaTime();\n\tv155 = *([v445 @ X8_v7+20]) - *([v47 @ X20_v2 (UnityEngine.Color[])+20]);\n\tv448 = this.colorLerpSpeed * v327;\n\tv450 = v448 < 1f;\n\tv451 = v448 == 1f;\n\tv454 = v448 == v448;\n\tv196 = 1f == 1f;\n\tv455 = v454 & v196;\n\tv456 = ~v455;\n\tv457 = v450 == v456;\n\tv86 = ~v451;\n\tv93 = v457 & v86;\n\tv458 = ~v93;\n\tif (v458) goto L_0059;\n\tgoto L_0059;\n\tgoto L_0066;\n\tv308 = this.targetColors;\n\tv469 = this.currExpositor + 1;\n\tv254 = v469 / v308.Length;\n\tv379 = v254 * v308.Length;\n\tv268 = v469 - v379;\n\tv150 = v268 << 4;\n\tv471 = v308 + v150;\n\tv328 = UnityEngine.Time::get_deltaTime();\n\tv156 = *([v471 @ X8_v11+20]) - *([v320 @ X20_v5 (UnityEngine.Color[])+30]);\n\tv474 = this.colorLerpSpeed * v328;\n\tv476 = v474 < 1f;\n\tv477 = v474 == 1f;\n\tv480 = v474 == v474;\n\tv201 = 1f == 1f;\n\tv481 = v480 & v201;\n\tv482 = ~v481;\n\tv483 = v476 == v482;\n\tv87 = ~v477;\n\tv98 = v483 & v87;\n\tv484 = ~v98;\n\tif (v484) goto L_00AC;\n\tgoto L_00AC;\n\tgoto L_00B9;\n\tv309 = this.targetColors;\n\tv496 = this.currExpositor + 2;\n\tv255 = v496 / v309.Length;\n\tv381 = v255 * v309.Length;\n\tv269 = v496 - v381;\n\tv151 = v269 << 4;\n\tv498 = v309 + v151;\n\tv329 = UnityEngine.Time::get_deltaTime();\n\tv157 = *([v498 @ X8_v15+20]) - *([v321 @ X20_v6 (UnityEngine.Color[])+40]);\n\tv503 = this.colorLerpSpeed * v329;\n\tv505 = v503 < 1f;\n\tv506 = v503 == 1f;\n\tv509 = v503 == v503;\n\tv198 = 1f == 1f;\n\tv510 = v509 & v198;\n\tv511 = ~v510;\n\tv512 = v505 == v511;\n\tv88 = ~v506;\n\tv95 = v512 & v88;\n\tv513 = ~v95;\n\tif (v513) goto L_010B;\n\tgoto L_010B;\n\tgoto L_0118;\n\tv310 = this.targetColors;\n\tv523 = this.currExpositor + 3;\n\tv256 = v523 / v310.Length;\n\tv383 = v256 * v310.Length;\n\tv277 = v523 - v383;\n\tv152 = v277 << 4;\n\tv525 = v310 + v152;\n\tv330 = UnityEngine.Time::get_deltaTime();\n\tv158 = *([v525 @ X8_v19+20]) - *([v322 @ X20_v7 (UnityEngine.Color[])+50]);\n\tv528 = this.colorLerpSpeed * v330;\n\tv530 = v528 < 1f;\n\tv531 = v528 == 1f;\n\tv534 = v528 == v528;\n\tv199 = 1f == 1f;\n\tv535 = v534 & v199;\n\tv536 = ~v535;\n\tv537 = v530 == v536;\n\tv89 = ~v531;\n\tv96 = v537 & v89;\n\tv538 = ~v96;\n\tif (v538) goto L_015E;\n\tgoto L_015E;\n\tgoto L_016B;\n\t// 383 MakeStruct v65 @ AGG3C1E3CC_2_v3 (UnityEngine.Color), typeof(UnityEngine.Color), [v311 @ X8_v21 (UnityEngine.Color[])+20], [v311 @ X8_v21 (UnityEngine.Color[])+24], [v311 @ X8_v21 (UnityEngine.Color[])+28], [v311 @ X8_v21 (UnityEngine.Color[])+2C]\n\tUnityEngine.Material::SetColor(this.backgroundMat, \"_GradTopLeftCol\", v65);\n\tv312 = this.currentColors;\n\t// 406 MakeStruct v61 @ AGG3C1E404_2_v3 (UnityEngine.Color), typeof(UnityEngine.Color), [v312 @ X8_v22 (UnityEngine.Color[])+30], [v312 @ X8_v22 (UnityEngine.Color[])+34], [v312 @ X8_v22 (UnityEngine.Color[])+38], [v312 @ X8_v22 (UnityEngine.Color[])+3C]\n\tUnityEngine.Material::SetColor(this.backgroundMat, \"_GradTopRightCol\", v61);\n\tv313 = this.currentColors;\n\t// 435 MakeStruct v57 @ AGG3C1E43C_2_v3 (UnityEngine.Color), typeof(UnityEngine.Color), [v313 @ X8_v23 (UnityEngine.Color[])+40], [v313 @ X8_v23 (UnityEngine.Color[])+44], [v313 @ X8_v23 (UnityEngine.Color[])+48], [v313 @ X8_v23 (UnityEngine.Color[])+4C]\n\tUnityEngine.Material::SetColor(this.backgroundMat, \"_GradBotLeftCol\", v57);\n\tv314 = this.currentColors;\n\t// 465 MakeStruct v395 @ AGG3C1E484_2_v1 (UnityEngine.Color), typeof(UnityEngine.Color), [v314 @ X8_v24 (UnityEngine.Color[])+50], [v314 @ X8_v24 (UnityEngine.Color[])+54], [v314 @ X8_v24 (UnityEngine.Color[])+58], [v314 @ X8_v24 (UnityEngine.Color[])+5C]\n\tUnityEngine.Material::SetColor(this.backgroundMat, \"_GradBotRightCol\", v395);\n\treturn;\nL_001E:\n\tAllIn1SpriteShader.All1ShaderDemoController::GetInput(this);\n\tv47 = this.currentColors;\nL_0059:\n\tv225 = v448 < 0;\n\tv79 = ~v225;\n\tif (v79) goto L_0066;\nL_0066:\n\tv466 = v155 * v467;\n\tv139 = *([v47 @ X20_v2 (UnityEngine.Color[])+20]) + v466;\n\t*([v47 @ X20_v2 (UnityEngine.Color[])+20]) = v139;\n\tv320 = this.currentColors;\nL_00AC:\n\tv226 = v474 < 0;\n\tv80 = ~v226;\n\tif (v80) goto L_00B9;\nL_00B9:\n\tv492 = v156 * v467;\n\tv140 = *([v320 @ X20_v5 (UnityEngine.Color[])+30]) + v492;\n\t*([v320 @ X20_v5 (UnityEngine.Color[])+30]) = v140;\n\tv321 = this.currentColors;\nL_010B:\n\tv227 = v503 < 0;\n\tv81 = ~v227;\n\tif (v81) goto L_0118;\nL_0118:\n\tv521 = v157 * v467;\n\tv141 = *([v321 @ X20_v6 (UnityEngine.Color[])+40]) + v521;\n\t*([v321 @ X20_v6 (UnityEngine.Color[])+40]) = v141;\n\tv322 = this.currentColors;\nL_015E:\n\tv221 = v528 < 0;\n\tv82 = ~v221;\n\tif (v82) goto L_016B;\nL_016B:\n\tv546 = v158 * v467;\n\tv142 = *([v322 @ X20_v7 (UnityEngine.Color[])+50]) + v546;\n\t*([v322 @ X20_v7 (UnityEngine.Color[])+50]) = v142;\n\tv311 = this.currentColors;\n")]
		private void Update()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("All1ShaderDemoController::Update");
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x3C1E490", Offset = "0x3C1E490", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = UnityEngine.Input::GetKeyDown(0x114);\n\tv16 = v14 == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_0013;\n\tv20 = UnityEngine.Input::GetKeyDown(0x61);\n\tv22 = ~v20;\n\tif (v22) goto L_0031;\nL_0013:\n\tv25 = this.expositors;\n\tv27 = this.currExpositor;\n\tAllIn1SpriteShader.DemoCircleExpositor::ChangeTarget(v25[v27 @ X9_v3 (System.Int32)], -1);\n\treturn;\nL_0031:\n\tv108 = UnityEngine.Input::GetKeyDown(0x113);\n\tv126 = v108 == 0;\n\tv127 = ~v126;\n\tif (v127) goto L_003B;\n\tv135 = UnityEngine.Input::GetKeyDown(0x64);\n\tv137 = ~v135;\n\tif (v137) goto L_0059;\nL_003B:\n\tv75 = this.expositors;\n\tv71 = this.currExpositor;\n\tAllIn1SpriteShader.DemoCircleExpositor::ChangeTarget(v75[v71 @ X9_v4 (System.Int32)], 1);\n\treturn;\nL_0059:\n\tv198 = UnityEngine.Input::GetKeyDown(0x111);\n\tv200 = v198 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_0064;\n\tv204 = UnityEngine.Input::GetKeyDown(0x77);\n\tv206 = ~v204;\n\tif (v206) goto L_0088;\nL_0064:\n\tv77 = this.currExpositor - 1;\n\tthis.currExpositor = v77;\n\tv72 = this.expositors;\n\tv222 = v72.Length - 1;\n\tv140 = v77 <= v222;\n\tif (v140) goto L_007A;\n\tv222 = 0;\n\tgoto L_007D;\nL_007A:\n\tv217 = v77 & 0x80000000;\n\tv218 = v217 == 0;\n\tif (v218) goto L_0084;\nL_007D:\n\tthis.currExpositor = v222;\nL_0088:\n\tv215 = UnityEngine.Input::GetKeyDown(0x112);\n\tv220 = v215 == 0;\n\tv221 = ~v220;\n\tif (v221) goto L_0099;\n\tv184 = UnityEngine.Input::GetKeyDown(0x73);\n\tv176 = ~v184;\n\tif (v176) goto L_00A0;\nL_0099:\n\tAllIn1SpriteShader.All1ShaderDemoController::ChangeExpositor(this, 1);\n\treturn;\nL_00A0:\n\treturn;\nL_0084:\n\tAllIn1SpriteShader.All1ShaderDemoController::SetExpositorText(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void GetInput()
		{
			//IL_01fd: Expected I4, but got I8
			if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
			{
				DemoCircleExpositor[] array = expositors;
				int num = currExpositor;
				array[num].ChangeTarget(-1);
				return;
			}
			if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
			{
				DemoCircleExpositor[] array2 = expositors;
				int num2 = currExpositor;
				array2[num2].ChangeTarget(1);
				return;
			}
			if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.W))
			{
				if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
				{
					ChangeExpositor(1);
				}
				return;
			}
			int num3 = --currExpositor;
			DemoCircleExpositor[] array3 = expositors;
			int num4 = array3.Length - 1;
			if (num3 > num4)
			{
				num4 = 0;
			}
			else if ((int)(num3 & 0x80000000L) == 0)
			{
				goto IL_0293;
			}
			currExpositor = num4;
			goto IL_0293;
			IL_0293:
			SetExpositorText();
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x3C1E780", Offset = "0x3C1E780", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.currExpositor + offset;\n\tthis.currExpositor = v2;\n\tv4 = this.expositors;\n\tv45 = v4.Length - 1;\n\tv19 = v2 <= v45;\n\tif (v19) goto L_0017;\n\tv45 = 0;\n\tgoto L_001D;\nL_0017:\n\tv41 = v2 & 0x80000000;\n\tv42 = v41 == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_001D;\n\tAllIn1SpriteShader.All1ShaderDemoController::SetExpositorText(this);\n\treturn;\nL_001D:\n\tthis.currExpositor = v45;\n\tAllIn1SpriteShader.All1ShaderDemoController::SetExpositorText(this);\n\treturn;\n")]
		private void ChangeExpositor(int offset)
		{
			//IL_0077: Expected I4, but got I8
			int num = (currExpositor += offset);
			DemoCircleExpositor[] array = expositors;
			int num2 = array.Length - 1;
			if (num > num2)
			{
				num2 = 0;
			}
			else if ((int)(num & 0x80000000L) == 0)
			{
				SetExpositorText();
				return;
			}
			currExpositor = num2;
			SetExpositorText();
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x3C1E04C", Offset = "0x3C1E04C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.expositors;\n\tv14 = this.currExpositor;\n\tv37 = UnityEngine.Object::get_name(v10[v14 @ X9_v3 (System.Int32)]);\n\tv38 = UnityEngine.UI.Text::set_text(this.expositorsTitle, v37);\n\tv86 = this.expositors;\n\tv75 = this.currExpositor;\n\tv40 = UnityEngine.Object::get_name(v86[v75 @ X9_v5 (System.Int32)]);\n\tv132 = UnityEngine.UI.Text::set_text(v132, v40);\n\treturn;\n")]
		private void SetExpositorText()
		{
			DemoCircleExpositor[] array = expositors;
			int num = currExpositor;
			string text = array[num].name;
			expositorsTitle.text = text;
			DemoCircleExpositor[] array2 = expositors;
			int num2 = currExpositor;
			string text2 = array2[num2].name;
			Text text3 = default(Text);
			text3.text = text2;
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x3C1E7C8", Offset = "0x3C1E7C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.currExpositor;\n")]
		public int GetCurrExpositor()
		{
			return currExpositor;
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x3C1E7D0", Offset = "0x3C1E7D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public All1ShaderDemoController()
		{
		}
	}
}
