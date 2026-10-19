using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot
{
	[Serializable]
	[Token(Token = "0x2000030")]
	public class ScreenshotResolution
	{
		[Token(Token = "0x2000031")]
		public enum Orientation
		{
			[Token(Token = "0x400012F")]
			LANDSCAPE = 0,
			[Token(Token = "0x4000130")]
			LANDSCAPE_RIGHT = 1,
			[Token(Token = "0x4000131")]
			PORTRAIT = 2
		}

		[HideInInspector]
		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0x10")]
		public bool m_Active;

		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0x14")]
		public int m_Width;

		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0x18")]
		public int m_Height;

		[Token(Token = "0x400011F")]
		[FieldOffset(Offset = "0x1C")]
		public float m_Scale;

		[Token(Token = "0x4000120")]
		[FieldOffset(Offset = "0x20")]
		public Orientation m_Orientation;

		[HideInInspector]
		[Token(Token = "0x4000121")]
		[FieldOffset(Offset = "0x28")]
		public string m_ResolutionName;

		[HideInInspector]
		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x30")]
		public string m_Category;

		[HideInInspector]
		[Token(Token = "0x4000123")]
		[FieldOffset(Offset = "0x38")]
		public string m_Platform;

		[Token(Token = "0x4000124")]
		[FieldOffset(Offset = "0x40")]
		public int m_PPI;

		[Tooltip("If the Screen.dpi device value returned by Unity is not equals to the real device screen dpi, you can set this value to render the device content like it will be it on the device.")]
		[Token(Token = "0x4000125")]
		[FieldOffset(Offset = "0x44")]
		public int m_ForcedUnityPPI;

		[Token(Token = "0x4000126")]
		[FieldOffset(Offset = "0x48")]
		public Canvas m_DeviceCanvas;

		[HideInInspector]
		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0x50")]
		public string m_Ratio;

		[HideInInspector]
		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x58")]
		public string m_FileName;

		[NonSerialized]
		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0x60")]
		public Texture2D m_Texture;

		[HideInInspector]
		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0x68")]
		public bool m_IgnoreOrientation;

		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0x69")]
		public bool m_DisableSafeArea;

		[Token(Token = "0x400012C")]
		[FieldOffset(Offset = "0x6C")]
		public Rect m_SafeAreaPortrait;

		[Token(Token = "0x400012D")]
		[FieldOffset(Offset = "0x7C")]
		public Rect m_SafeAreaLandscapeLeft;

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x3C3054C", Offset = "0x3C3054C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tthis.m_Ratio = \"\";\n\tthis.m_FileName = \"\";\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tthis.m_Active = 1;\n\tthis.m_Width = 2.291755455191E-311d;\n\tthis.m_Scale = 1f;\n\tthis.m_ResolutionName = \"\";\n\tthis.m_Category = \"Custom\";\n\tthis.m_Platform = \"\";\n")]
		public ScreenshotResolution()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotResolution::.ctor");
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x3C3A68C", Offset = "0x3C3A68C", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tthis.m_Ratio = \"\";\n\tthis.m_FileName = \"\";\n\tSystem.Object::.ctor(this);\n\tAlmostEngine.Screenshot.ScreenshotResolution::Copy(this, res);\n\treturn;\nL_001F:\n\tthis.m_Active = 1;\n\tthis.m_Width = 2.291755455191E-311d;\n\tthis.m_Scale = 1f;\n\tthis.m_ResolutionName = \"\";\n\tthis.m_Category = \"Custom\";\n\tthis.m_Platform = \"\";\n")]
		public ScreenshotResolution(ScreenshotResolution res)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotResolution::.ctor");
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x3C3A778", Offset = "0x3C3A778", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Active = res.m_Active;\n\tthis.m_Width = res.m_Width;\n\tthis.m_Scale = res.m_Scale;\n\tthis.m_Orientation = res.m_Orientation;\n\tthis.m_ResolutionName = res.m_ResolutionName;\n\tthis.m_Category = res.m_Category;\n\tthis.m_Platform = res.m_Platform;\n\tthis.m_PPI = res.m_PPI;\n\tthis.m_Ratio = res.m_Ratio;\n\tthis.m_DeviceCanvas = res.m_DeviceCanvas;\n\tthis.m_FileName = res.m_FileName;\n\tthis.m_SafeAreaPortrait = res.m_SafeAreaPortrait;\n\tthis.m_SafeAreaLandscapeLeft = res.m_SafeAreaLandscapeLeft;\n\treturn;\n")]
		public void Copy(ScreenshotResolution res)
		{
			m_Active = res.m_Active;
			m_Width = res.m_Width;
			m_Height = (int)((uint)res.m_Width >> 32);
			m_Scale = res.m_Scale;
			m_Orientation = res.m_Orientation;
			m_ResolutionName = res.m_ResolutionName;
			m_Category = res.m_Category;
			m_Platform = res.m_Platform;
			m_PPI = res.m_PPI;
			m_ForcedUnityPPI = (int)((uint)res.m_PPI >> 32);
			m_Ratio = res.m_Ratio;
			m_DeviceCanvas = res.m_DeviceCanvas;
			m_FileName = res.m_FileName;
			m_SafeAreaPortrait = res.m_SafeAreaPortrait;
			m_SafeAreaLandscapeLeft = res.m_SafeAreaLandscapeLeft;
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x3C3A834", Offset = "0x3C3A834", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tthis.m_Ratio = \"\";\n\tthis.m_FileName = \"\";\n\tSystem.Object::.ctor(this);\n\tthis.m_Width = width;\n\tthis.m_Height = height;\n\treturn;\nL_0020:\n\tthis.m_Active = 1;\n\tthis.m_Width = 2.291755455191E-311d;\n\tthis.m_Scale = 1f;\n\tthis.m_ResolutionName = \"\";\n\tthis.m_Category = \"Custom\";\n\tthis.m_Platform = \"\";\n")]
		public ScreenshotResolution(int width, int height)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotResolution::.ctor");
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x3C3A920", Offset = "0x3C3A920", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tthis.m_Ratio = \"\";\n\tthis.m_FileName = \"\";\n\tSystem.Object::.ctor(this);\n\tthis.m_Category = category;\n\tthis.m_Width = width;\n\tthis.m_Height = height;\n\tthis.m_ResolutionName = name;\n\tthis.m_PPI = dpi;\n\tAlmostEngine.Screenshot.ScreenshotResolution::UpdateRatio(this);\n\treturn;\nL_0027:\n\tthis.m_Active = 1;\n\tthis.m_Width = 2.291755455191E-311d;\n\tthis.m_Scale = 1f;\n\tthis.m_ResolutionName = \"\";\n\tthis.m_Category = \"Custom\";\n\tthis.m_Platform = \"\";\n")]
		public ScreenshotResolution(string category, int width, int height, string name = "", int dpi = 0)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotResolution::.ctor");
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x3C3231C", Offset = "0x3C3231C", Length = "0x514")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003D;\nL_FFFFFFFF:\n\tv66 = this.m_Width;\nL_FFFFFFFF:\n\tv60 = v61;\nL_FFFFFFFF:\n\tv66 = v67;\nL_FFFFFFFF:\n\tv76 = v60;\n\tgoto L_004D;\nL_FFFFFFFF:\n\tv76 = this.m_Width;\n\tthis.m_Ratio = v104;\n\tv167 = this.m_Width;\n\tv118 = this.m_Width / v76;\n\tv170 = this.m_Height;\n\tv122 = v118 == 8f;\n\tv130 = this.m_Height / v76;\n\tv132 = ~v122;\n\tif (v132) goto L_FFFFFFFF;\n\tv155 = v130 == 5f;\n\tgoto L_0085;\nL_FFFFFFFF:\n\tv155 = 0;\n\tthis.m_Ratio = \"16:10\";\n\tv170 = this.m_Height;\n\tv167 = this.m_Width;\n\tv222 = v178 < 0x3727C5AC;\n\tv221 = v178 == 0x3727C5AC;\n\tv207 = v178 == v178;\n\tv217 = ~v207;\n\tgoto L_00B7;\nL_FFFFFFFF:\n\tv217 = 0;\nL_FFFFFFFF:\n\tv221 = 1;\nL_FFFFFFFF:\n\tv222 = 0;\n\tv229 = v173 + 0xFFFFFFFFBFCCCCCD;\n\tv230 = UnityEngine.Mathf::Abs(v229);\n\tv237 = v230 == 0x3D4CCCCD;\n\tv238 = v230 < 0x3D4CCCCD;\n\tv239 = ~v238;\n\tv247 = ~v239;\n\tv248 = v247 | v237;\n\tv249 = ~v248;\n\tif (v249) goto L_FFFFFFFF;\n\tv332 = v230 < 0x3727C5AC;\n\tv322 = v230 == 0x3727C5AC;\n\tv376 = v230 == v230;\n\tv282 = ~v376;\n\tgoto L_00E0;\nL_FFFFFFFF:\n\tv282 = 0;\nL_FFFFFFFF:\n\tv322 = 1;\nL_FFFFFFFF:\n\tv332 = 0;\n\tv424 = v173 + 0xFFFFFFFFC018F5C3;\n\tv425 = UnityEngine.Mathf::Abs(v424);\n\tv431 = v425 == 0x3D4CCCCD;\n\tv432 = v425 < 0x3D4CCCCD;\n\tv433 = ~v432;\n\tv441 = ~v433;\n\tv442 = v441 | v431;\n\tv443 = ~v442;\n\tif (v443) goto L_FFFFFFFF;\n\tv461 = v425 < 0x3727C5AC;\n\tv460 = v425 == 0x3727C5AC;\n\tv448 = v425 == v425;\n\tv456 = ~v448;\n\tgoto L_0109;\nL_FFFFFFFF:\n\tv456 = 0;\nL_FFFFFFFF:\n\tv460 = 1;\nL_FFFFFFFF:\n\tv461 = 0;\n\tv468 = v173 + 0xFFFFFFFFC0155555;\n\tv469 = UnityEngine.Mathf::Abs(v468);\n\tv487 = v469 == 0x3D4CCCCD;\n\tv488 = v469 < 0x3D4CCCCD;\n\tv489 = ~v488;\n\tv495 = ~v489;\n\tv496 = v495 | v487;\n\tv472 = ~v496;\n\tif (v472) goto L_FFFFFFFF;\n\tv478 = v469 < 0x3727C5AC;\n\tv477 = v469 == 0x3727C5AC;\n\tv501 = v469 == v469;\n\tv473 = ~v501;\n\tgoto L_0132;\nL_FFFFFFFF:\n\tv473 = 0;\nL_FFFFFFFF:\n\tv477 = 1;\nL_FFFFFFFF:\n\tv478 = 0;\n\tv513 = v173 + 0xFFFFFFFFBFE38E39;\n\tv351 = UnityEngine.Mathf::Abs(v513);\n\tv518 = v351 == 0x3D4CCCCD;\n\tv519 = v351 < 0x3D4CCCCD;\n\tv520 = ~v519;\n\tv527 = ~v520;\n\tv528 = v527 | v518;\n\tv273 = ~v528;\n\tif (v273) goto L_FFFFFFFF;\n\tv333 = v351 < 0x3727C5AC;\n\tv323 = v351 == 0x3727C5AC;\n\tv533 = v351 == v351;\n\tv283 = ~v533;\n\tgoto L_015B;\nL_FFFFFFFF:\n\tv283 = 0;\nL_FFFFFFFF:\n\tv323 = 1;\nL_FFFFFFFF:\n\tv333 = 0;\n\tv545 = v173 + 0xFFFFFFFFBFAAAAAB;\n\tv352 = UnityEngine.Mathf::Abs(v545);\n\tv551 = v352 == 0x3D4CCCCD;\n\tv552 = v352 < 0x3D4CCCCD;\n\tv553 = ~v552;\n\tv560 = ~v553;\n\tv561 = v560 | v551;\n\tv274 = ~v561;\n\tif (v274) goto L_FFFFFFFF;\n\tv334 = v352 < 0x3727C5AC;\n\tv324 = v352 == 0x3727C5AC;\n\tv566 = v352 == v352;\n\tv284 = ~v566;\n\tgoto L_0184;\nL_FFFFFFFF:\n\tv284 = 0;\nL_FFFFFFFF:\n\tv324 = 1;\nL_FFFFFFFF:\n\tv334 = 0;\n\tv578 = v173 + 0xFFFFFFFFBFB6DB6E;\n\tv353 = UnityEngine.Mathf::Abs(v578);\n\tv584 = v353 == 0x3D4CCCCD;\n\tv585 = v353 < 0x3D4CCCCD;\n\tv586 = ~v585;\n\tv593 = ~v586;\n\tv594 = v593 | v584;\n\tv275 = ~v594;\n\tif (v275) goto L_FFFFFFFF;\n\tv335 = v353 < 0x3727C5AC;\n\tv325 = v353 == 0x3727C5AC;\n\tv599 = v353 == v353;\n\tv285 = ~v599;\n\tgoto L_01AD;\nL_FFFFFFFF:\n\tv285 = 0;\nL_FFFFFFFF:\n\tv325 = 1;\nL_FFFFFFFF:\n\tv335 = 0;\n\tv609 = v173 + -1.25f;\n\tv354 = UnityEngine.Mathf::Abs(v609);\n\tv615 = v354 == 0x3D4CCCCD;\n\tv616 = v354 < 0x3D4CCCCD;\n\tv617 = ~v616;\n\tv624 = ~v617;\n\tv625 = v624 | v615;\n\tv276 = ~v625;\n\tif (v276) goto L_FFFFFFFF;\n\tv336 = v354 < 0x3727C5AC;\n\tv326 = v354 == 0x3727C5AC;\n\tv630 = v354 == v354;\n\tv286 = ~v630;\n\tgoto L_01D4;\nL_FFFFFFFF:\n\tv286 = 0;\nL_FFFFFFFF:\n\tv326 = 1;\nL_FFFFFFFF:\n\tv336 = 0;\n\tv642 = v173 + 0xFFFFFFFFBFD55555;\n\tv355 = UnityEngine.Mathf::Abs(v642);\n\tv648 = v355 == 0x3D4CCCCD;\n\tv649 = v355 < 0x3D4CCCCD;\n\tv650 = ~v649;\n\tv657 = ~v650;\n\tv658 = v657 | v648;\n\tv277 = ~v658;\n\tif (v277) goto L_FFFFFFFF;\n\tv337 = v355 < 0x3727C5AC;\n\tv327 = v355 == 0x3727C5AC;\n\tv663 = v355 == v355;\n\tv287 = ~v663;\n\tgoto L_01FD;\nL_FFFFFFFF:\n\tv287 = 0;\nL_FFFFFFFF:\n\tv327 = 1;\nL_FFFFFFFF:\n\tv337 = 0;\n\tv673 = v173 + -1.5f;\n\tv356 = UnityEngine.Mathf::Abs(v673);\n\tv679 = v356 == 0x3D4CCCCD;\n\tv680 = v356 < 0x3D4CCCCD;\n\tv681 = ~v680;\n\tv688 = ~v681;\n\tv689 = v688 | v679;\n\tv278 = ~v689;\n\tif (v278) goto L_FFFFFFFF;\n\tv338 = v356 < 0x3727C5AC;\n\tv328 = v356 == 0x3727C5AC;\n\tv694 = v356 == v356;\n\tv288 = ~v694;\n\tgoto L_0224;\nL_FFFFFFFF:\n\tv288 = 0;\nL_FFFFFFFF:\n\tv328 = 1;\nL_FFFFFFFF:\n\tv338 = 0;\n\tv704 = v173 + -2f;\n\tv705 = UnityEngine.Mathf::Abs(v704);\n\tv711 = v705 == 0x3D4CCCCD;\n\tv712 = v705 < 0x3D4CCCCD;\n\tv713 = ~v712;\n\tv721 = ~v713;\n\tv722 = v721 | v711;\n\tv723 = ~v722;\n\tif (v723) goto L_FFFFFFFF;\n\tv741 = v705 < 0x3727C5AC;\n\tv740 = v705 == 0x3727C5AC;\n\tv728 = v705 == v705;\n\tv736 = ~v728;\n\tgoto L_024B;\nL_FFFFFFFF:\n\tv736 = 0;\nL_FFFFFFFF:\n\tv740 = 1;\nL_FFFFFFFF:\n\tv741 = 0;\n\tv748 = v173 + 0xFFFFFFFFC003A06D;\n\tv749 = UnityEngine.Mathf::Abs(v748);\n\tv765 = v749 == 0x3D4CCCCD;\n\tv766 = v749 < 0x3D4CCCCD;\n\tv767 = ~v766;\n\tv773 = ~v767;\n\tv774 = v773 | v765;\n\tv751 = ~v774;\n\tif (v751) goto L_FFFFFFFF;\n\tv757 = v749 < 0x3727C5AC;\n\tv756 = v749 == 0x3727C5AC;\n\tv779 = v749 == v749;\n\tv752 = ~v779;\n\tgoto L_0274;\nL_FFFFFFFF:\n\tv752 = 0;\nL_FFFFFFFF:\n\tv756 = 1;\nL_FFFFFFFF:\n\tv757 = 0;\n\tv791 = v173 + 0xFFFFFFFFC00ABCDF;\n\tv408 = UnityEngine.Mathf::Abs(v791);\n\tv796 = v408 == 0x3D4CCCCD;\n\tv797 = v408 < 0x3D4CCCCD;\n\tv798 = ~v797;\n\tv804 = ~v798;\n\tv805 = v804 | v796;\n\tv389 = ~v805;\n\tif (v389) goto L_FFFFFFFF;\n\tv401 = v408 < 0x3727C5AC;\n\tv399 = v408 == 0x3727C5AC;\n\tv810 = v408 == v408;\n\tv391 = ~v810;\n\tgoto L_029D;\nL_FFFFFFFF:\n\tv391 = 0;\nL_FFFFFFFF:\n\tv399 = 1;\nL_FFFFFFFF:\n\tv401 = 0;\nL_02A2:\n\tv359 = 0xB2EA000 + 0x1D0;\n\tgoto L_02AD;\nL_02A5:\n\tv359 = 0xB2E9000 + 0xED8;\n\tgoto L_02AD;\nL_02A8:\n\tv359 = 0xB2E9000 + 0xB50;\n\tgoto L_02AD;\nL_02AB:\n\tv359 = 0xB2E9000 + 0xEE0;\nL_02B9:\n\treturn;\nL_02BB:\n\tv359 = 0xB2E9000 + 0xB58;\n\tgoto L_02AD;\nL_02BE:\n\tv359 = 0xB2E9000 + 0x9C0;\n\tgoto L_02AD;\nL_02C1:\n\tv359 = 0xB2E9000 + 0x8E8;\n\tgoto L_02AD;\nL_02C4:\n\tv359 = 0xB2EA000 + 0x470;\n\tgoto L_02AD;\nL_02C7:\n\tv359 = 0xB2EA000 + 0x468;\n\tgoto L_02AD;\nL_02CA:\n\tv359 = 0xB2EA000 + 0x2C0;\n\tgoto L_02AD;\nL_003D:\n\tv60 = this.m_Height;\n\tv51 = this.m_Height == 0;\n\tif (v51) goto L_FFFFFFFF;\nL_0042:\n\tv72 = v66 / v60;\n\tv73 = v72 * v60;\n\tv60 = v66 - v73;\n\tv71 = v66 != v73;\nL_FFFFFFFF:\n\tv66 = v60;\n\tif (v71) goto L_0042;\nL_004D:\n\tv81 = this.m_Width / v76;\n\tv82 = v81;\n\tv85 = System.Single::ToString(&v82 @ stack_-44_v1 (System.Single));\n\tv92 = this.m_Height / v76;\n\tv82 = v92;\n\tv96 = System.Single::ToString(&v82 @ stack_-44_v1 (System.Single));\n\tv104 = System.String::Concat(v85, \":\", v96);\nL_0085:\n\tv157 = ~v155;\n\tif (v157) goto L_0091;\nL_00B7:\n\tv223 = v222 == v217;\n\tv224 = ~v221;\n\tv225 = v223 & v224;\n\tif (v225) goto L_02A5;\nL_00E0:\n\tv420 = v332 == v282;\n\tv253 = ~v322;\n\tv263 = v420 & v253;\n\tif (v263) goto L_02A8;\nL_0109:\n\tv462 = v461 == v456;\n\tv463 = ~v460;\n\tv464 = v462 & v463;\n\tif (v464) goto L_02AB;\nL_0132:\n\tv509 = v478 == v473;\n\tv470 = ~v477;\n\tv471 = v509 & v470;\n\tif (v471) goto L_02AB;\nL_015B:\n\tv541 = v333 == v283;\n\tv254 = ~v323;\n\tv264 = v541 & v254;\n\tif (v264) goto L_02BB;\nL_0184:\n\tv574 = v334 == v284;\n\tv255 = ~v324;\n\tv265 = v574 & v255;\n\tif (v265) goto L_02BE;\nL_01AD:\n\tv607 = v335 == v285;\n\tv256 = ~v325;\n\tv266 = v607 & v256;\n\tif (v266) goto L_02C1;\nL_01D4:\n\tv638 = v336 == v286;\n\tv257 = ~v326;\n\tv267 = v638 & v257;\n\tif (v267) goto L_02C4;\nL_01FD:\n\tv671 = v337 == v287;\n\tv258 = ~v327;\n\tv268 = v671 & v258;\n\tif (v268) goto L_02C7;\nL_0224:\n\tv702 = v338 == v288;\n\tv259 = ~v328;\n\tv269 = v702 & v259;\n\tif (v269) goto L_02CA;\nL_024B:\n\tv742 = v741 == v736;\n\tv743 = ~v740;\n\tv744 = v742 & v743;\n\tif (v744) goto L_02A2;\nL_0274:\n\tv787 = v757 == v752;\n\tv385 = ~v756;\n\tv750 = v787 & v385;\n\tif (v750) goto L_02A2;\nL_029D:\n\tv818 = v401 == v391;\n\tv819 = ~v818;\n\tv387 = v819 | v399;\n\tif (v387) goto L_02B9;\nL_02AD:\n\tthis.m_Ratio = *([v359 @ X8_v12 (System.Int32)]);\nL_0091:\n\tv173 = v167 / v170;\n\tv177 = v173 + 0xFFFFFFFFC0066666;\n\tv178 = UnityEngine.Mathf::Abs(v177);\n\tv187 = v178 == 0x3D4CCCCD;\n\tv188 = v178 < 0x3D4CCCCD;\n\tv189 = ~v188;\n\tv197 = ~v189;\n\tv198 = v197 | v187;\n\tv199 = ~v198;\n\tif (v199) goto L_FFFFFFFF;\n")]
		public void UpdateRatio()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotResolution::UpdateRatio");
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x3C3AA7C", Offset = "0x3C3AA7C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = width / height;\n\t// 2 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv9 = v0 < 0x3727C5AC;\n\tv10 = v0 == 0x3727C5AC;\n\tv13 = v0 == v0;\n\tv16 = ~v13;\n\tv20 = v9 == v16;\n\tv21 = ~v10;\n\tv22 = v20 & v21;\n\tv23 = ~v22;\n\tif (v23) goto L_FFFFFFFF;\n\tv40 = v0 == 0x3D4CCCCD;\n\tv26 = v0 < 0x3D4CCCCD;\n\tv39 = ~v26;\n\tgoto L_0024;\nL_FFFFFFFF:\n\tv39 = 1;\nL_FFFFFFFF:\n\tv40 = 0;\nL_0024:\n\tv42 = ~v39;\n\tv43 = v42 | v40;\n\treturn v43;\n")]
		private bool ApproximateRatio(float width, float height, float w, float h)
		{
			float num = width / height;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			bool flag = num < 1E-05f;
			bool flag2 = num == 1E-05f;
			bool flag3 = num == num;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag2;
			bool flag7;
			bool flag9;
			if (flag5 && flag6)
			{
				flag7 = num == 0.05f;
				bool flag8 = num < 0.05f;
				flag9 = !flag8;
			}
			else
			{
				flag9 = true;
				flag7 = false;
			}
			bool flag10 = !flag9;
			return flag10 || flag7;
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x3C3AA58", Offset = "0x3C3AA58", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = v5 == 0;\n\tif (v0) goto L_000C;\nL_0003:\n\tv9 = v2 / v5;\n\tv15 = v9 * v5;\n\tv6 = v2 - v15;\n\tv14 = v2 != v15;\n\tv2 = v5;\n\tv5 = v6;\n\tif (v14) goto L_0003;\n\treturn v6;\nL_000C:\n\treturn v2;\n")]
		private int GCD(int a, int b)
		{
			int num = default(int);
			int num3 = default(int);
			if (num != 0)
			{
				int num5;
				bool flag;
				do
				{
					int num2 = num3 / num;
					int num4 = num2 * num;
					num5 = num3 - num4;
					flag = num3 != num4;
					num3 = num;
					num = num5;
				}
				while (flag);
				return num5;
			}
			return num3;
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0x3C319C0", Offset = "0x3C319C0", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.m_Width < 1;\n\tif (v12) goto L_001D;\n\tv17 = this.m_Height < 0;\n\tv18 = this.m_Height == 0;\n\tv20 = this.m_Height ^ this.m_Height;\n\tv21 = this.m_Height & v20;\n\tv22 = v21 < 0;\n\tv23 = v17 == v22;\n\tv24 = ~v18;\n\tv25 = v23 & v24;\n\treturn v25;\nL_001D:\n\treturn 0;\n")]
		public bool IsValid()
		{
			if (m_Width >= 1)
			{
				bool flag = m_Height < 0;
				bool flag2 = m_Height == 0;
				int num = m_Height ^ m_Height;
				int num2 = m_Height & num;
				bool flag3 = num2 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				return flag4 && flag5;
			}
			return false;
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0x3C3AAB0", Offset = "0x3C3AAB0", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv75 = System.String::Concat(\"\", this.m_ResolutionName, \"   -   \");\n\tv80 = v75;\n\tv106 = System.String::Concat(v102, \"  \", this.m_Ratio);\n\tv109 = this + 0x40;\n\tv121 = v109.m_value < 1;\n\tv136 = v106;\n\tif (v121) goto L_006A;\n\tv125 = System.Int32::ToString(&this.m_PPI (System.Int32));\n\tv135 = System.String::Concat(v106, \"  \", v125, \"ppi\");\n\tv136 = v135;\nL_002C:\n\tAlmostEngine.Screenshot.ScreenshotResolution::UpdateRatio(this);\n\tv61 = System.String::op_Inequality(this.m_ResolutionName, \"\");\n\tv65 = ~v61;\n\tv80 = \"\";\n\tif (v65) goto L_003E;\nL_003E:\n\t;\n\tv87 = System.Int32::ToString(&this.m_Width (System.Int32));\n\tv94 = System.Int32::ToString(&this.m_Height (System.Int32));\n\tv102 = System.String::Concat(v80, v87, \"x\", v94);\nL_006A:\n\t;\n\tv141 = System.Single::ToString(&this.m_Scale (System.Single));\n\treturnVal1 = System.String::Concat(v136, \" scale \", v141);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override string ToString()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotResolution::ToString");
			return default;
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0x3C30620", Offset = "0x3C30620", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.m_IgnoreOrientation == 0;\n\tif (v3) goto L_0007;\nL_FFFFFFFF:\n\tv41 = 0x14;\n\tgoto L_001B;\nL_0007:\n\tv6 = this.m_Orientation < 2;\n\tv7 = ~v6;\n\tv17 = ~v7;\n\tv18 = ~v17;\n\tif (v18) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv41 = 0x14;\n\tgoto L_001B;\nL_FFFFFFFF:\n\tv41 = 0x18;\n\tgoto L_002C;\nL_FFFFFFFF:\n\tv60 = 1f;\nL_FFFFFFFF:\n\treturnVal1 = 0xFFFFFFFF80000000;\n\tgoto L_003F;\nL_FFFFFFFF:\n\treturnVal1 = v61;\nL_001B:\n\tv60 = this.m_Scale;\n\tv47 = this.m_Scale < 0;\n\tv48 = this.m_Scale == 0;\n\tv51 = this.m_Scale == this.m_Scale;\n\tv52 = ~v51;\n\tv54 = v47 == v52;\n\tv55 = ~v48;\n\tv56 = v54 & v55;\n\tv57 = ~v56;\n\tif (v57) goto L_FFFFFFFF;\nL_002C:\n\tv61 = v60 * *([this @ X0 (AlmostEngine.Screenshot.ScreenshotResolution)+v41 @ X8_v2 (System.Int32)]);\n\tv66 = v61 == 0x7F800000;\n\tv74 = ~v66;\n\tif (v74) goto L_FFFFFFFF;\nL_003F:\n\treturn returnVal1;\n")]
		public int ComputeTargetWidth()
		{
			//IL_00b2: Expected I4, but got F4
			if (m_IgnoreOrientation)
			{
				int num = 20;
			}
			else if ((uint)m_Orientation < 2u)
			{
				int num = 20;
			}
			else
			{
				int num = 24;
			}
			float num2 = m_Scale;
			bool flag = m_Scale < 0f;
			bool flag2 = m_Scale == 0f;
			bool flag3 = m_Scale == m_Scale;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag2;
			if (!(flag5 && flag6))
			{
				num2 = 1f;
			}
			float num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (AlmostEngine.Screenshot.ScreenshotResolution)+v41 @ X8_v2 (System.Int32)]");
			float num4 = num3 * 0f;
			if (num4 == 1f / 0f)
			{
				return -2147483648;
			}
			return (int)num4;
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0x3C3067C", Offset = "0x3C3067C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.m_IgnoreOrientation == 0;\n\tif (v3) goto L_0007;\nL_FFFFFFFF:\n\tv41 = 0x18;\n\tgoto L_001B;\nL_0007:\n\tv6 = this.m_Orientation < 2;\n\tv7 = ~v6;\n\tv17 = ~v7;\n\tv18 = ~v17;\n\tif (v18) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv41 = 0x18;\n\tgoto L_001B;\nL_FFFFFFFF:\n\tv41 = 0x14;\n\tgoto L_002C;\nL_FFFFFFFF:\n\tv60 = 1f;\nL_FFFFFFFF:\n\treturnVal1 = 0xFFFFFFFF80000000;\n\tgoto L_003F;\nL_FFFFFFFF:\n\treturnVal1 = v61;\nL_001B:\n\tv60 = this.m_Scale;\n\tv47 = this.m_Scale < 0;\n\tv48 = this.m_Scale == 0;\n\tv51 = this.m_Scale == this.m_Scale;\n\tv52 = ~v51;\n\tv54 = v47 == v52;\n\tv55 = ~v48;\n\tv56 = v54 & v55;\n\tv57 = ~v56;\n\tif (v57) goto L_FFFFFFFF;\nL_002C:\n\tv61 = v60 * *([this @ X0 (AlmostEngine.Screenshot.ScreenshotResolution)+v41 @ X8_v2 (System.Int32)]);\n\tv66 = v61 == 0x7F800000;\n\tv74 = ~v66;\n\tif (v74) goto L_FFFFFFFF;\nL_003F:\n\treturn returnVal1;\n")]
		public int ComputeTargetHeight()
		{
			//IL_00b2: Expected I4, but got F4
			if (m_IgnoreOrientation)
			{
				int num = 24;
			}
			else if ((uint)m_Orientation < 2u)
			{
				int num = 24;
			}
			else
			{
				int num = 20;
			}
			float num2 = m_Scale;
			bool flag = m_Scale < 0f;
			bool flag2 = m_Scale == 0f;
			bool flag3 = m_Scale == m_Scale;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag2;
			if (!(flag5 && flag6))
			{
				num2 = 1f;
			}
			float num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (AlmostEngine.Screenshot.ScreenshotResolution)+v41 @ X8_v2 (System.Int32)]");
			float num4 = num3 * 0f;
			if (num4 == 1f / 0f)
			{
				return -2147483648;
			}
			return (int)num4;
		}
	}
}
