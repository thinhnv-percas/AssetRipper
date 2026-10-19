using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1VfxToolkit
{
	[Token(Token = "0x2000017")]
	public class AllIn1VfxScrollShaderTexture : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0x20")]
		private string texturePropertyName;

		[SerializeField]
		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0x28")]
		private Vector2 scrollSpeed;

		[Space]
		[Header("True changes tex offset, false to change tex scale")]
		[SerializeField]
		[Token(Token = "0x4000079")]
		[FieldOffset(Offset = "0x30")]
		private bool textureOffset;

		[Header("There are 3 modifiers, just pick 1")]
		[Space]
		[SerializeField]
		[Token(Token = "0x400007A")]
		[FieldOffset(Offset = "0x31")]
		private bool backAndForth;

		[SerializeField]
		[Token(Token = "0x400007B")]
		[FieldOffset(Offset = "0x34")]
		private Vector2 maxValue;

		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0x3C")]
		private Vector2 iniValue;

		[Token(Token = "0x400007D")]
		[FieldOffset(Offset = "0x44")]
		private bool goingUpX;

		[Token(Token = "0x400007E")]
		[FieldOffset(Offset = "0x45")]
		private bool goingUpY;

		[Space]
		[SerializeField]
		[Token(Token = "0x400007F")]
		[FieldOffset(Offset = "0x46")]
		private bool applyModulo;

		[SerializeField]
		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0x48")]
		private Vector2 modulo;

		[Space]
		[SerializeField]
		[Token(Token = "0x4000081")]
		[FieldOffset(Offset = "0x50")]
		private bool stopAtValue;

		[SerializeField]
		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0x54")]
		private Vector2 stopValue;

		[Space]
		[SerializeField]
		[Header("If missing uses an instance of the currently used Material")]
		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0x60")]
		private Material mat;

		[Token(Token = "0x4000084")]
		[FieldOffset(Offset = "0x68")]
		private Material originalMat;

		[Token(Token = "0x4000085")]
		[FieldOffset(Offset = "0x70")]
		private bool restoreMaterialOnDisable;

		[Token(Token = "0x4000086")]
		[FieldOffset(Offset = "0x74")]
		private int propertyShaderID;

		[Token(Token = "0x4000087")]
		[FieldOffset(Offset = "0x78")]
		private Vector2 currValue;

		[Token(Token = "0x4000088")]
		[FieldOffset(Offset = "0x80")]
		private bool isValid;

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x3C27BC4", Offset = "0x3C27BC4", Length = "0x470")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tv88 = this + 0x60;\n\tgoto L_001C;\nL_001C:\n\tv63 = UnityEngine.Object::op_Equality(this.mat, 0);\n\tv73 = ~v63;\n\tif (v73) goto L_005B;\n\tv93 = UnityEngine.Component::GetComponent(this);\n\tv118 = UnityEngine.Renderer::get_material(v93);\n\t*([v88 @ X20_v21]) = v118;\n\tv310 = this.mat;\n\tgoto L_0070;\nL_005B:\n\tv105 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v105, this.mat);\n\tthis.originalMat = v105;\n\tthis.restoreMaterialOnDisable = 1;\n\tv310 = this.mat;\n\tgoto L_0070;\nL_0070:\n\tv314 = UnityEngine.Object::op_Equality(v310, 0);\n\tv324 = ~v314;\n\tif (v324) goto L_00AC;\n\tv179 = UnityEngine.Component::get_gameObject(this);\n\tv340 = UnityEngine.Object::get_name(v179);\n\tv345 = System.String::Concat(v340, \" has no valid Material, deleting AllIn1VfxScrollShaderTexture component\");\n\tgoto L_008A;\nL_008A:\n\tgoto L_008D;\nL_008D:\n\tUnityEngine.Debug::LogError(v345);\n\tgoto L_009D;\nL_009D:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\nL_00AC:\n\tv338 = UnityEngine.Material::HasProperty(this.mat, this.texturePropertyName);\n\tv341 = ~v338;\n\tif (v341) goto L_00E9;\n\tv348 = UnityEngine.Shader::PropertyToID(this.texturePropertyName);\n\tthis.propertyShaderID = v348;\n\tv181 = this.mat;\n\tv366 = this.textureOffset != 1;\n\tv183 = this.mat;\n\tif (v366) goto L_011D;\nL_00C4:\n\tv414 = UnityEngine.Material::GetTextureOffset(v181, this.texturePropertyName);\n\tthis.currValue.x = v414;\n\tthis.currValue.y = v414.y;\n\tv436 = this.backAndForth == 0;\n\tif (v436) goto L_0130;\n\tgoto L_0133;\nL_00E9:\n\tv182 = UnityEngine.Component::get_gameObject(this);\n\tv396 = UnityEngine.Object::get_name(v182);\n\tv423 = System.String::Concat(v396, \"'s Material doesn't have a \", this.texturePropertyName, \" texture property\");\n\tgoto L_0102;\nL_0102:\n\tgoto L_0105;\nL_0105:\n\tUnityEngine.Debug::LogError(v423);\n\tgoto L_010C;\nL_010C:\n\tUnityEngine.Object::Destroy(this);\n\tv181 = this.mat;\n\tv381 = this.textureOffset == 1;\n\tv183 = this.mat;\n\tif (v381) goto L_00C4;\nL_011D:\n\tv417 = UnityEngine.Material::GetTextureScale(v183, this.texturePropertyName);\n\tthis.currValue.x = v417;\n\tthis.currValue.y = v417.y;\n\tv440 = this.backAndForth == 0;\n\tv441 = ~v440;\n\tif (v441) goto L_0133;\nL_0130:\n\tv488 = this.stopAtValue != 1;\n\tif (v488) goto L_0189;\nL_0133:\n\tthis.iniValue = this.currValue;\n\tv511 = this.currValue >> 0x20;\n\tv514 = this.maxValue < this.currValue;\n\tv515 = this.maxValue == this.currValue;\n\tv518 = this.maxValue == this.maxValue;\n\tv519 = this.currValue == this.currValue;\n\tv520 = v518 & v519;\n\tv521 = ~v520;\n\tv522 = v514 == v521;\n\tv523 = ~v515;\n\tv524 = v522 & v523;\n\tthis.goingUpX = v524;\n\tv527 = this.scrollSpeed;\n\tv528 = v514 == v521;\n\tv529 = ~v528;\n\tv530 = v529 | v515;\n\tif (v530) goto L_0152;\n\tv568 = this.scrollSpeed < 0;\n\tif (v568) goto L_015D;\n\tgoto L_0162;\nL_0152:\n\tv574 = this.scrollSpeed < 0;\n\tv575 = this.scrollSpeed == 0;\n\tv578 = this.scrollSpeed == this.scrollSpeed;\n\tv579 = ~v578;\n\tv580 = v574 == v579;\n\tv581 = ~v580;\n\tv582 = v581 | v575;\n\tif (v582) goto L_0162;\nL_015D:\n\tv605 = -v527;\n\tv606 = -this.scrollSpeed.y;\n\tthis.scrollSpeed.x = v605;\n\tthis.scrollSpeed.y = v606;\n\tv527 = v605;\n\tv556 = this.scrollSpeed.y < 0;\n\tv546 = ~v556;\n\tif (v546) goto L_0189;\nL_017C:\n\tv543 = -v527;\n\tv541 = -this.scrollSpeed.y;\n\tthis.scrollSpeed.x = v543;\n\tthis.scrollSpeed.y = v541;\nL_018A:\n\tv557 = this.scrollSpeed.y < 0;\n\tv554 = this.scrollSpeed.y == 0;\n\tv560 = this.scrollSpeed.y == this.scrollSpeed.y;\n\tv550 = ~v560;\n\tv635 = v557 == v550;\n\tv540 = ~v554;\n\tv547 = v635 & v540;\n\tif (v547) goto L_017C;\n\tgoto L_0189;\nL_0189:\n\treturn;\nL_0162:\n\tv614 = this.maxValue.y < v511;\n\tv615 = this.maxValue.y == v511;\n\tv618 = this.maxValue.y == this.maxValue.y;\n\tv551 = v511 == v511;\n\tv619 = v618 & v551;\n\tv620 = ~v619;\n\tv621 = v614 == v620;\n\tv539 = ~v615;\n\tv622 = v621 & v539;\n\tthis.goingUpY = v622;\n\tv623 = v614 == v620;\n\tv624 = ~v623;\n\tv625 = v624 | v615;\n\tif (v625) goto L_018A;\n")]
		private void Start()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AllIn1VfxScrollShaderTexture::Start");
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x3C28110", Offset = "0x3C28110", Length = "0x2EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Equality(this.mat, 0);\n\tv68 = ~v59;\n\tif (v68) goto L_0070;\n\tv93 = this.isValid != 1;\n\tif (v93) goto L_0050;\n\tv110 = UnityEngine.Component::get_gameObject(this);\n\tv315 = UnityEngine.Object::get_name(v110);\n\tv121 = System.String::Concat(\"The object \", v315, \" has no Material and you are trying to access it. Please take a look\");\n\tgoto L_0045;\nL_0070:\n\tv103 = UnityEngine.Time::get_deltaTime();\n\tv136 = this.scrollSpeed * v137;\n\tv174 = this.currValue + v136;\n\tthis.currValue = v174;\n\tv149 = this.backAndForth != 1;\n\tif (v149) goto L_00DE;\n\tv258 = this.goingUpX != 1;\n\tif (v258) goto L_009A;\n\tv321 = v174 < this.maxValue;\n\tv325 = v174 == v174;\n\tv326 = this.maxValue == this.maxValue;\n\tv327 = v325 & v326;\n\tv328 = ~v327;\n\tv329 = v321 == v328;\n\tif (v329) goto L_00A4;\n\tgoto L_00B4;\nL_009A:\n\tv332 = v174 == this.iniValue;\n\tv333 = v174 < this.iniValue;\n\tv334 = ~v333;\n\tv339 = ~v332;\n\tv340 = v334 & v339;\n\tif (v340) goto L_00B4;\nL_00A4:\n\tv378 = this.goingUpX ^ 1;\n\tthis.goingUpX = v378;\n\tv380 = -this.scrollSpeed;\n\tthis.scrollSpeed.x = v380;\n\tv288 = v303 < this.maxValue.y;\n\tv450 = v303 == v303;\n\tv280 = this.maxValue.y == this.maxValue.y;\n\tv292 = v450 & v280;\n\tv272 = ~v292;\n\tv268 = v288 == v272;\n\tif (v268) goto L_00CE;\n\tgoto L_00DE;\nL_00C4:\n\tv285 = v303 == this.iniValue.y;\n\tv451 = v303 < this.iniValue.y;\n\tv297 = ~v451;\n\tv453 = ~v285;\n\tv269 = v297 & v453;\n\tif (v269) goto L_00DE;\nL_00CE:\n\tv299 = this.goingUpY ^ 1;\n\tthis.goingUpY = v299;\n\tv264 = -this.scrollSpeed.y;\n\tthis.scrollSpeed.y = v264;\n\tv343 = 0x8BF6440(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v174, this.modulo, v174, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tthis.currValue.x = v174;\n\tv351 = 0x8BF6440(v343, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v303, this.modulo.y, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tthis.currValue.y = v303;\n\tv318 = v303;\n\tv409 = this.goingUpX != 1;\n\tif (v409) goto L_0110;\n\tv454 = v174 < this.stopValue;\n\tv458 = v174 == v174;\n\tv459 = this.stopValue == this.stopValue;\n\tv460 = v458 & v459;\n\tv461 = ~v460;\n\tv462 = v454 == v461;\n\tif (v462) goto L_011A;\n\tgoto L_0126;\nL_0110:\n\tv464 = v174 == this.stopValue;\n\tv465 = v174 < this.stopValue;\n\tv466 = ~v465;\n\tv471 = ~v464;\n\tv472 = v466 & v471;\n\tif (v472) goto L_0126;\nL_011A:\n\tthis.scrollSpeed.x = 0f;\n\tv433 = v318 < this.stopValue.y;\n\tv501 = v318 == v318;\n\tv425 = this.stopValue.y == this.stopValue.y;\n\tv437 = v501 & v425;\n\tv417 = ~v437;\n\tv413 = v433 == v417;\n\tif (v413) goto L_013E;\n\tgoto L_014A;\nL_0134:\n\tv430 = v318 == this.stopValue.y;\n\tv502 = v318 < this.stopValue.y;\n\tv442 = ~v502;\n\tv504 = ~v430;\n\tv414 = v442 & v504;\n\tif (v414) goto L_014A;\nL_013E:\n\tthis.scrollSpeed.y = 0f;\n\t// 347 MakeStruct v158 @ AGG3C283C8_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v174 @ V2_v3 (System.Single), v318 @ V8_v4 (System.Single)\n\tUnityEngine.Material::SetTextureOffset(this.mat, this.propertyShaderID, v158);\n\treturn;\nL_016D:\n\t// 365 MakeStruct v155 @ AGG3C283F4_2_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v174 @ V2_v3 (System.Single), v318 @ V8_v4 (System.Single)\n\tUnityEngine.Material::SetTextureScale(this.mat, this.propertyShaderID, v155);\n\treturn;\nL_0050:\n\treturn;\nL_0045:\n\tUnityEngine.Debug::LogError(v121);\n\tthis.isValid = 0;\nL_00DE:\n\tv313 = this.applyModulo != 1;\n\tv318 = v303;\n\tif (v313) goto L_00F5;\nL_00B4:\n\tv397 = this.goingUpY != 1;\n\tif (v397) goto L_00C4;\nL_014A:\n\tv191 = this.textureOffset != 1;\n\tif (v191) goto L_016D;\nL_0126:\n\tv499 = this.goingUpY != 1;\n\tif (v499) goto L_0134;\nL_00F5:\n\tv362 = this.stopAtValue != 1;\n\tif (v362) goto L_014A;\n")]
		private void Update()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AllIn1VfxScrollShaderTexture::Update");
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x3C283FC", Offset = "0x3C283FC", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ~isXComponent;\n\tif (v0) goto L_000B;\n\tv4 = this.goingUpX ^ 1;\n\tthis.goingUpX = v4;\n\tv5 = 0x28;\n\tv7 = -*([this @ X0 (AllIn1VfxToolkit.AllIn1VfxScrollShaderTexture)+v5 @ X8_v6 (System.Int32)]);\n\t*([this @ X0 (AllIn1VfxToolkit.AllIn1VfxScrollShaderTexture)+v5 @ X8_v6 (System.Int32)]) = v7;\n\treturn;\nL_000B:\n\tv9 = this.goingUpY ^ 1;\n\tthis.goingUpY = v9;\n\tv10 = 0x2C;\n\tv12 = -*([this @ X0 (AllIn1VfxToolkit.AllIn1VfxScrollShaderTexture)+v10 @ X8_v3 (System.Int32)]);\n\t*([this @ X0 (AllIn1VfxToolkit.AllIn1VfxScrollShaderTexture)+v10 @ X8_v3 (System.Int32)]) = v12;\n\treturn;\n")]
		private void FlipGoingUp(bool isXComponent)
		{
			//IL_0087: Expected O, but got I
			//IL_004d: Expected O, but got I
			if (isXComponent)
			{
				int num = (goingUpX ? 1 : 0) ^ 1;
				goingUpX = (byte)num != 0;
				int num2 = 40;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (AllIn1VfxToolkit.AllIn1VfxScrollShaderTexture)+v5 @ X8_v6 (System.Int32)]");
				object obj = -0;
			}
			else
			{
				int num3 = (goingUpY ? 1 : 0) ^ 1;
				goingUpY = (byte)num3 != 0;
				int num4 = 44;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (AllIn1VfxToolkit.AllIn1VfxScrollShaderTexture)+v10 @ X8_v3 (System.Int32)]");
				object obj2 = -0;
			}
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x3C28034", Offset = "0x3C28034", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv52 = 0xB292000 + 0x5A0;\n\tgoto L_0019;\nL_0019:\n\tUnityEngine.Debug::LogError(logError);\n\tv64 = *([v52 @ X22_v9 (System.Int32)]);\n\tv66 = *([v64 @ X0_v19+E4]) == 0;\n\tif (v66) goto L_004B;\n\tUnityEngine.Object::Destroy(this);\n\treturn;\nL_004B:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\n")]
		private void DestroyComponentAndLogError(string logError)
		{
			//IL_002a: Expected O, but got I4
			int num = 187244544 + 1440;
			Debug.LogError(logError);
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X0_v19+E4]");
			if ((nint)0 != 0)
			{
				Object.Destroy(this);
			}
			else
			{
				Object.Destroy(this);
			}
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x3C28440", Offset = "0x3C28440", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.restoreMaterialOnDisable != 1;\n\tif (v11) goto L_0014;\n\tUnityEngine.Material::CopyPropertiesFromMaterial(this.mat, this.originalMat);\n\treturn;\nL_0014:\n\treturn;\n")]
		private void OnDisable()
		{
			if (restoreMaterialOnDisable)
			{
				mat.CopyPropertiesFromMaterial(originalMat);
			}
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x3C28474", Offset = "0x3C28474", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tthis.iniValue.x = v79.zero;\n\tthis.iniValue.y = v79.zero.y;\n\tgoto L_0052;\nL_0048:\n\t*([B193A7E]) = 1;\n\tthis.iniValue = v98.zero;\n\tv101 = *([B193A87]) & 1;\n\tv96 = v101 == 0;\n\tif (v96) goto L_0068;\nL_0052:\n\tthis.modulo = v97.one;\nL_0068:\n\t*([v69 @ X22_v1+A87]) = 1;\n\tthis.modulo = v113.one;\n\tgoto L_0054;\nL_001B:\n\tthis.texturePropertyName = \"_MainTex\";\n\tgoto L_002D;\nL_002D:\n\tthis.scrollSpeed = v66.zero;\n\tthis.textureOffset = 1;\n\tv69 = 0xB193000;\n\tgoto L_003D;\nL_0054:\n\tthis.stopValue = v112.zero;\n\tthis.currValue = v112.zero;\n\tthis.isValid = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_003D:\n\tthis.maxValue = v79.one;\n\tv82 = *([B193A7E]) & 1;\n\tv83 = v82 == 0;\n\tif (v83) goto L_0048;\n")]
		public AllIn1VfxScrollShaderTexture()
		{
			texturePropertyName = "_MainTex";
			scrollSpeed = Vector2.zero;
			textureOffset = true;
			object obj = 186200064;
			maxValue = Vector2.one;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193A7E]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				iniValue.x = Vector2.zero.x;
				iniValue.y = Vector2.zero.y;
			}
			else
			{
				_ = 1;
				iniValue = Vector2.zero;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193A87]");
				if ((int)((nint)0 & (nint)1) == 0)
				{
					_ = 1;
					modulo = Vector2.one;
					goto IL_00d8;
				}
			}
			modulo = Vector2.one;
			goto IL_00d8;
			IL_00d8:
			stopValue = Vector2.zero;
			currValue = Vector2.zero;
			isValid = true;
		}
	}
}
