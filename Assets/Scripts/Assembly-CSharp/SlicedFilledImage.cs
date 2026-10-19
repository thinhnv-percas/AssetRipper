using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.U2D;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
[AddComponentMenu("UI/Sliced Filled Image", 11)]
[Token(Token = "0x2000017")]
public class SlicedFilledImage : MaskableGraphic, ISerializationCallbackReceiver, ILayoutElement, ICanvasRaycastFilter
{
	[Token(Token = "0x2000018")]
	private static class SetPropertyUtility
	{
		[Token(Token = "0x6000074")]
		[Address(RVA = "0x42CD98C", Offset = "0x42CD98C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv24 = 0x220C2B8(methodInfo, newValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv46 = *([v43 @ X0_v3 (System.Collections.Generic.EqualityComparer`1<T>)]);\n\t*([v46 @ X8_v3 (Il2CppClass<System.Collections.Generic.EqualityComparer`1<T>>)+1B8])(v50, v43, *([currentValue @ X0 (T&)]), newValue, *([v46 @ X8_v3 (Il2CppClass<System.Collections.Generic.EqualityComparer`1<T>>)+1C0]), v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = v50 & 1;\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0021;\n\t*([currentValue @ X0 (T&)]) = newValue;\nL_0013:\n\tv43 = System.Collections.Generic.EqualityComparer`1<T>::get_Default();\nL_0021:\n\treturnVal1 = v50 ^ 1;\n\treturn returnVal1;\n")]
		public static bool SetStruct<T>(ref T currentValue, T newValue) where T : struct
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage.SetPropertyUtility::SetStruct");
			return default;
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x42CD918", Offset = "0x42CD918", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = *([v82 @ X0_v1 (T&)]);\n\tv2 = v23 | *([v82 @ X0_v1 (T&)]);\n\tv4 = v2 == 0;\n\tv5 = ~v4;\n\tif (v5) goto L_000D;\n\treturn 0;\nL_000D:\n\tv17 = *([v82 @ X0_v1 (T&)]) == 0;\n\tif (v17) goto L_0023;\n\tv56 = *([v0 @ X8_v1 (T)]);\n\t*([v56 @ X9_v3 (Il2CppClass<T>)+138])(v64, *([v82 @ X0_v1 (T&)]), v23, *([v56 @ X9_v3 (Il2CppClass<T>)+140]), v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77);\n\tv79 = v64 & 1;\n\tv53 = v79 == 0;\n\tif (v53) goto L_0023;\n\treturn 0;\nL_0023:\n\t*([v82 @ X0_v1 (T&)]) = v23;\n\treturn 1;\n")]
		public static bool SetClass<T>(ref T currentValue, T newValue) where T : class
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage.SetPropertyUtility::SetClass");
			return default;
		}
	}

	[Token(Token = "0x2000019")]
	public enum FillDirection
	{
		[Token(Token = "0x4000031")]
		Right = 0,
		[Token(Token = "0x4000032")]
		Left = 1,
		[Token(Token = "0x4000033")]
		Up = 2,
		[Token(Token = "0x4000034")]
		Down = 3
	}

	[Token(Token = "0x4000022")]
	private static readonly Vector3[] s_Vertices;

	[Token(Token = "0x4000023")]
	private static readonly Vector2[] s_UVs;

	[Token(Token = "0x4000024")]
	private static readonly Vector2[] s_SlicedVertices;

	[Token(Token = "0x4000025")]
	private static readonly Vector2[] s_SlicedUVs;

	[SerializeField]
	[Token(Token = "0x4000026")]
	[FieldOffset(Offset = "0xD8")]
	private Sprite m_Sprite;

	[SerializeField]
	[Token(Token = "0x4000027")]
	[FieldOffset(Offset = "0xE0")]
	private FillDirection m_FillDirection;

	[Range(0f, 1f)]
	[SerializeField]
	[Token(Token = "0x4000028")]
	[FieldOffset(Offset = "0xE4")]
	private float m_FillAmount;

	[SerializeField]
	[Token(Token = "0x4000029")]
	[FieldOffset(Offset = "0xE8")]
	private bool m_FillCenter;

	[SerializeField]
	[Token(Token = "0x400002A")]
	[FieldOffset(Offset = "0xEC")]
	private float m_PixelsPerUnitMultiplier;

	[NonSerialized]
	[Token(Token = "0x400002B")]
	[FieldOffset(Offset = "0xF0")]
	private Sprite m_OverrideSprite;

	[Token(Token = "0x400002D")]
	[FieldOffset(Offset = "0xFC")]
	private bool m_Tracked;

	[Token(Token = "0x400002E")]
	private static List<SlicedFilledImage> m_TrackedTexturelessImages;

	[Token(Token = "0x400002F")]
	private static bool s_Initialized;

	[Token(Token = "0x1700000F")]
	public Sprite sprite
	{
		[Token(Token = "0x6000048")]
		[Address(RVA = "0x3C62394", Offset = "0x3C62394", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.sprite;\n")]
		get
		{
			return m_Sprite;
		}
		[Token(Token = "0x6000049")]
		[Address(RVA = "0x3C6239C", Offset = "0x3C6239C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv56 = UnityEngine.UI.Graphic::SetAllDirty(this);\n\tSlicedFilledImage::TrackImage(this);\n\treturn;\nL_0033:\n\treturn;\nL_0019:\n\t;\n\tv50 = SlicedFilledImage+SetPropertyUtility::SetClass(&this.m_Sprite (UnityEngine.Sprite), v42);\n\tv51 = ~v50;\n\tif (v51) goto L_0033;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			Sprite newValue = default(Sprite);
			if (SetPropertyUtility.SetClass(ref m_Sprite, newValue))
			{
				base.SetAllDirty();
				TrackImage();
			}
		}
	}

	[Token(Token = "0x17000010")]
	public FillDirection fillDirection
	{
		[Token(Token = "0x600004A")]
		[Address(RVA = "0x3C62748", Offset = "0x3C62748", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fillDirection;\n")]
		get
		{
			return m_FillDirection;
		}
		[Token(Token = "0x600004B")]
		[Address(RVA = "0x3C62750", Offset = "0x3C62750", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv55 = UnityEngine.UI.Graphic::SetVerticesDirty(v55);\n\treturn;\nL_0030:\n\treturn;\nL_0019:\n\t;\n\tv50 = SlicedFilledImage+SetPropertyUtility::SetStruct(&this.m_FillDirection (SlicedFilledImage+FillDirection), value);\n\tv51 = ~v50;\n\tif (v51) goto L_0030;\n")]
		set
		{
			if (SetPropertyUtility.SetStruct(ref m_FillDirection, value))
			{
				SlicedFilledImage slicedFilledImage = default(SlicedFilledImage);
				slicedFilledImage.SetVerticesDirty();
			}
		}
	}

	[Token(Token = "0x17000011")]
	public float fillAmount
	{
		[Token(Token = "0x600004C")]
		[Address(RVA = "0x3C627D4", Offset = "0x3C627D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fillAmount;\n")]
		get
		{
			return m_FillAmount;
		}
		[Token(Token = "0x600004D")]
		[Address(RVA = "0x3C627DC", Offset = "0x3C627DC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_FFFFFFFF:\n\tv75 = 1f;\n\tgoto L_002B;\nL_FFFFFFFF:\n\tv75 = value;\nL_FFFFFFFF:\n\tv75 = 0;\n\tgoto L_0039;\n\tv83 = UnityEngine.UI.Graphic::SetVerticesDirty(v83);\n\treturn;\nL_0054:\n\treturn;\nL_001A:\n\tv50 = value < 1f;\n\tv51 = value == 1f;\n\tv54 = value == value;\n\tv55 = 1f == 1f;\n\tv56 = v54 & v55;\n\tv57 = ~v56;\n\tv58 = v50 == v57;\n\tv59 = ~v51;\n\tv60 = v58 & v59;\n\tv61 = ~v60;\n\tif (v61) goto L_FFFFFFFF;\nL_002B:\n\tv65 = value < 0;\n\tv72 = ~v65;\n\tif (v72) goto L_0039;\nL_0039:\n\t;\n\tv78 = SlicedFilledImage+SetPropertyUtility::SetStruct(&this.m_FillAmount (System.Single), v75);\n\tv79 = ~v78;\n\tif (v79) goto L_0054;\n")]
		set
		{
			bool flag = value < 1f;
			bool flag2 = value == 1f;
			bool flag3 = value == value;
			bool flag4 = 1f == 1f;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			float newValue = ((!(flag7 && flag8)) ? value : 1f);
			if (value < 0f)
			{
				newValue = 0f;
			}
			if (SetPropertyUtility.SetStruct(ref m_FillAmount, newValue))
			{
				SlicedFilledImage slicedFilledImage = default(SlicedFilledImage);
				slicedFilledImage.SetVerticesDirty();
			}
		}
	}

	[Token(Token = "0x17000012")]
	public bool fillCenter
	{
		[Token(Token = "0x600004E")]
		[Address(RVA = "0x3C62880", Offset = "0x3C62880", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fillCenter;\n")]
		get
		{
			return m_FillCenter;
		}
		[Token(Token = "0x600004F")]
		[Address(RVA = "0x3C62888", Offset = "0x3C62888", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv55 = UnityEngine.UI.Graphic::SetVerticesDirty(v55);\n\treturn;\nL_0030:\n\treturn;\nL_0019:\n\t;\n\tv50 = SlicedFilledImage+SetPropertyUtility::SetStruct(&this.m_FillCenter (System.Boolean), v42);\n\tv51 = ~v50;\n\tif (v51) goto L_0030;\n")]
		set
		{
			bool newValue = default(bool);
			if (SetPropertyUtility.SetStruct(ref m_FillCenter, newValue))
			{
				SlicedFilledImage slicedFilledImage = default(SlicedFilledImage);
				slicedFilledImage.SetVerticesDirty();
			}
		}
	}

	[Token(Token = "0x17000013")]
	public float pixelsPerUnitMultiplier
	{
		[Token(Token = "0x6000050")]
		[Address(RVA = "0x3C6290C", Offset = "0x3C6290C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.pixelsPerUnitMultiplier;\n")]
		get
		{
			return m_PixelsPerUnitMultiplier;
		}
		[Token(Token = "0x6000051")]
		[Address(RVA = "0x3C62914", Offset = "0x3C62914", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = v15 < 0x3C23D70A;\n\tv12 = ~v3;\n\tif (v12) goto L_0011;\n\tgoto L_0011;\nL_0011:\n\tthis.pixelsPerUnitMultiplier = 0.01f;\n\treturn;\n")]
		set
		{
			float num = default(float);
			if (num < 0.01f)
			{
			}
			m_PixelsPerUnitMultiplier = 0.01f;
		}
	}

	[Token(Token = "0x17000014")]
	public float pixelsPerUnit
	{
		[Token(Token = "0x6000052")]
		[Address(RVA = "0x3C62930", Offset = "0x3C62930", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = 0xB78D000;\n\tv26 = *([B78D6D5]) & 1;\n\tv27 = v26 == 0;\n\tif (v27) goto L_0079;\n\tv87 = 0xB292000 + 0x5A0;\n\tv32 = *([B78D6D6]) & 1;\n\tv33 = v32 == 0;\nL_FFFFFFFF:\n\tv69 = v87;\n\tif (v33) goto L_0086;\nL_001A:\n\tv82 = this + 0xF0;\nL_FFFFFFFF:\n\tv95 = this.m_OverrideSprite;\n\tgoto L_0023;\nL_0023:\n\tv101 = UnityEngine.Object::op_Inequality(v95, 0);\n\tv110 = v101 == 0;\n\tv117 = ~v110;\n\tv118 = ~v117;\n\tif (v118) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv121 = 0xF0;\n\tgoto L_0037;\nL_FFFFFFFF:\n\tv121 = 0xD8;\n\tv128 = UnityEngine.Object::op_Implicit(*([this @ X0 (SlicedFilledImage)+v121 @ X8_v10 (System.Int32)]));\n\tv130 = ~v128;\n\tif (v130) goto L_009C;\nL_0044:\n\tgoto L_004A;\nL_0055:\n\tv171 = UnityEngine.Object::op_Inequality(*([v82 @ X22_v4]), 0);\n\tv191 = v171 == 0;\n\tv179 = ~v191;\n\tv177 = ~v179;\n\tif (v177) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv288 = v82;\n\tgoto L_006A;\nL_FFFFFFFF:\n\tv288 = v157;\nL_006A:\n\tv175 = UnityEngine.Sprite::get_pixelsPerUnit(*([v288 @ X8_v24]));\n\tv226 = UnityEngine.UI.Graphic::get_canvas(this);\n\tv207 = *([v87 @ X21_v5 (System.Int32)]);\n\tv378 = *([v207 @ X8_v25+E4]) == 0;\n\tv205 = ~v378;\nL_FFFFFFFF:\n\tv241 = v175;\nL_FFFFFFFF:\n\tv201 = v226;\n\tif (v205) goto L_00A2;\nL_FFFFFFFF:\n\tv292 = v175;\n\tgoto L_00B2;\nL_0079:\n\t*([v24 @ X20_v1+6D5]) = 1;\n\tv87 = 0xB292000 + 0x5A0;\n\tv77 = *([B78D6D6]) & 1;\n\tv78 = v77 == 0;\n\tv58 = ~v78;\nL_FFFFFFFF:\n\tv69 = v87;\n\tif (v58) goto L_001A;\nL_0086:\n\t*([B78D6D6]) = 1;\n\tv82 = this + 0xF0;\nL_FFFFFFFF:\n\tv87 = v69;\nL_FFFFFFFF:\n\tv95 = this.m_OverrideSprite;\n\tgoto L_0023;\nL_0094:\n\tv133 = UnityEngine.Object::op_Implicit(*([this @ X0 (SlicedFilledImage)+v121 @ X8_v10 (System.Int32)]));\n\tv150 = ~v133;\n\tv137 = ~v150;\n\tif (v137) goto L_0044;\nL_009C:\n\tv226 = UnityEngine.UI.Graphic::get_canvas(this);\n\tv163 = *([v87 @ X21_v5 (System.Int32)]);\n\tv165 = *([v163 @ X8_v20+E4]) == 0;\nL_FFFFFFFF:\n\tv241 = 0x42C80000;\nL_FFFFFFFF:\n\tv201 = v226;\nL_FFFFFFFF:\n\tv292 = 0x42C80000;\n\tif (v165) goto L_00B2;\nL_00A2:\n\tv210 = UnityEngine.Object::op_Implicit(v201);\n\tv235 = ~v210;\nL_FFFFFFFF:\n\tv292 = v241;\n\tif (v235) goto L_FFFFFFFF;\nL_00A7:\n\tv264 = UnityEngine.UI.Graphic::get_canvas(this);\n\tv293 = UnityEngine.Canvas::get_referencePixelsPerUnit(v264);\nL_FFFFFFFF:\n\tv292 = v241;\n\tgoto L_00B9;\nL_00B2:\n\tv238 = UnityEngine.Object::op_Implicit(v226);\n\tv287 = ~v238;\n\tv259 = ~v287;\nL_FFFFFFFF:\n\tv241 = v292;\n\tif (v259) goto L_00A7;\nL_FFFFFFFF:\n\tv293 = 0x42C80000;\nL_0037:\n\tv123 = *([v87 @ X21_v5 (System.Int32)]);\n\tv125 = *([v123 @ X0_v14+E4]) == 0;\n\tif (v125) goto L_0094;\nL_004A:\n\tv157 = this + 0xD8;\n\tgoto L_0055;\nL_00B9:\n\tv315 = v292 * this.pixelsPerUnitMultiplier;\n\treturnVal1 = v315 / v293;\n\treturn returnVal1;\n")]
		get
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::get_pixelsPerUnit");
			return default;
		}
	}

	[Token(Token = "0x17000015")]
	public Sprite overrideSprite
	{
		[Token(Token = "0x6000053")]
		[Address(RVA = "0x3C62BC0", Offset = "0x3C62BC0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0020:\n\tv54 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv59 = v54 == 0;\n\tv66 = ~v59;\n\tv67 = ~v66;\n\tif (v67) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv70 = 0xF0;\n\tgoto L_003B;\nL_FFFFFFFF:\n\tv70 = 0xD8;\nL_001B:\n\tgoto L_0020;\nL_003B:\n\treturn *([this @ X0 (SlicedFilledImage)+v70 @ X8_v5 (System.Int32)]);\n")]
		get
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::get_overrideSprite");
			return default;
		}
		[Token(Token = "0x6000054")]
		[Address(RVA = "0x3C62C44", Offset = "0x3C62C44", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv56 = UnityEngine.UI.Graphic::SetAllDirty(this);\n\tSlicedFilledImage::TrackImage(this);\n\treturn;\nL_0033:\n\treturn;\nL_0019:\n\t;\n\tv50 = SlicedFilledImage+SetPropertyUtility::SetClass(&this.m_OverrideSprite (UnityEngine.Sprite), v42);\n\tv51 = ~v50;\n\tif (v51) goto L_0033;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			Sprite newValue = default(Sprite);
			if (SetPropertyUtility.SetClass(ref m_OverrideSprite, newValue))
			{
				base.SetAllDirty();
				TrackImage();
			}
		}
	}

	[Token(Token = "0x17000016")]
	private Sprite activeSprite
	{
		[Token(Token = "0x6000055")]
		[Address(RVA = "0x3C62B3C", Offset = "0x3C62B3C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0020:\n\tv54 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv59 = v54 == 0;\n\tv66 = ~v59;\n\tv67 = ~v66;\n\tif (v67) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv70 = 0xF0;\n\tgoto L_003B;\nL_FFFFFFFF:\n\tv70 = 0xD8;\nL_001B:\n\tgoto L_0020;\nL_003B:\n\treturn *([this @ X0 (SlicedFilledImage)+v70 @ X8_v5 (System.Int32)]);\n")]
		get
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::get_activeSprite");
			return default;
		}
	}

	[Token(Token = "0x17000017")]
	public override Texture mainTexture
	{
		[Token(Token = "0x6000056")]
		[Address(RVA = "0x3C62CD0", Offset = "0x3C62CD0", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = 0xB78D000;\n\tv22 = *([B78D6D7]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_007B;\n\tv82 = 0xB292000 + 0x5A0;\n\tv28 = *([B78D6D6]) & 1;\n\tv29 = v28 == 0;\nL_FFFFFFFF:\n\tv66 = v82;\n\tif (v29) goto L_0088;\nL_0018:\n\tv77 = this + 0xF0;\nL_FFFFFFFF:\n\tv90 = this.m_OverrideSprite;\n\tgoto L_0021;\nL_0021:\n\tv96 = UnityEngine.Object::op_Inequality(v90, 0);\n\tv109 = v96 == 0;\n\tv116 = ~v109;\n\tv117 = ~v116;\n\tif (v117) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv120 = 0xF0;\n\tgoto L_0035;\nL_FFFFFFFF:\n\tv120 = 0xD8;\n\tv128 = UnityEngine.Object::op_Inequality(*([this @ X0 (SlicedFilledImage)+v120 @ X8_v10 (System.Int32)]), 0);\n\tv130 = ~v128;\n\tif (v130) goto L_009F;\nL_0043:\n\tgoto L_0049;\nL_0054:\n\tv180 = UnityEngine.Object::op_Inequality(*([v77 @ X22_v4]), 0);\n\tv191 = v180 == 0;\n\tv196 = ~v191;\n\tv197 = ~v196;\n\tif (v197) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv262 = v77;\n\tgoto L_0072;\nL_FFFFFFFF:\n\tv262 = v163;\nL_0072:\n\treturnVal3 = UnityEngine.Sprite::get_texture(*([v262 @ X8_v24]));\n\treturn returnVal3;\nL_007B:\n\t*([v20 @ X20_v1+6D7]) = 1;\n\tv82 = 0xB292000 + 0x5A0;\n\tv103 = *([B78D6D6]) & 1;\n\tv104 = v103 == 0;\n\tv55 = ~v104;\nL_FFFFFFFF:\n\tv66 = v82;\n\tif (v55) goto L_0018;\nL_0088:\n\t*([B78D6D6]) = 1;\n\tv77 = this + 0xF0;\nL_FFFFFFFF:\n\tv82 = v66;\nL_FFFFFFFF:\n\tv90 = this.m_OverrideSprite;\n\tgoto L_0021;\nL_0097:\n\tv134 = UnityEngine.Object::op_Inequality(*([this @ X0 (SlicedFilledImage)+v120 @ X8_v10 (System.Int32)]), 0);\n\tv156 = ~v134;\n\tv139 = ~v156;\n\tif (v139) goto L_0043;\nL_009F:\n\tv152 = SlicedFilledImage::get_material(this);\n\tv153 = *([v82 @ X21_v5 (System.Int32)]);\n\tv155 = *([v153 @ X8_v14+E4]) == 0;\n\tif (v155) goto L_00B1;\n\tv171 = UnityEngine.Object::op_Inequality(v152, 0);\n\tv181 = ~v171;\n\tv182 = ~v181;\n\tif (v182) goto L_00B8;\n\tgoto L_00EB;\nL_00B1:\n\tv186 = UnityEngine.Object::op_Inequality(v152, 0);\n\tv202 = ~v186;\n\tif (v202) goto L_00EB;\nL_00B8:\n\tv208 = SlicedFilledImage::get_material(this);\n\tv237 = UnityEngine.Material::get_mainTexture(v208);\n\tv227 = *([v82 @ X21_v5 (System.Int32)]);\n\tv280 = *([v227 @ X8_v19+E4]) == 0;\n\tif (v280) goto L_00E0;\n\tv222 = UnityEngine.Object::op_Inequality(v237, 0);\n\tv225 = v222 == 0;\n\tif (v225) goto L_00EB;\nL_00CB:\n\tv255 = SlicedFilledImage::get_material(this);\n\treturnVal4 = UnityEngine.Material::get_mainTexture(v255);\n\treturn returnVal4;\nL_00E0:\n\tv221 = UnityEngine.Object::op_Inequality(v237, 0);\n\tv334 = v221 == 0;\n\tv224 = ~v334;\n\tif (v224) goto L_00CB;\nL_00EB:\n\tgoto L_00F9;\nL_0035:\n\tv122 = *([v82 @ X21_v5 (System.Int32)]);\n\tv124 = *([v122 @ X0_v17+E4]) == 0;\n\tif (v124) goto L_0097;\nL_0049:\n\tv163 = this + 0xD8;\n\tgoto L_0054;\nL_00F9:\n\treturn v270.s_WhiteTexture;\n")]
		get
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::get_mainTexture");
			return default;
		}
	}

	[Token(Token = "0x17000018")]
	public bool hasBorder
	{
		[Token(Token = "0x6000057")]
		[Address(RVA = "0x3C62F64", Offset = "0x3C62F64", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = 0xB78D000;\n\tv22 = *([B78D6D8]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_004E;\n\tv83 = 0xB292000 + 0x5A0;\n\tv28 = *([B78D6D6]) & 1;\n\tv29 = v28 == 0;\nL_FFFFFFFF:\n\tv65 = v83;\n\tif (v29) goto L_005B;\nL_0018:\n\tv78 = this + 0xF0;\nL_FFFFFFFF:\n\tv91 = this.m_OverrideSprite;\n\tgoto L_0021;\nL_0021:\n\tv97 = UnityEngine.Object::op_Inequality(v91, 0);\n\tv106 = v97 == 0;\n\tv113 = ~v106;\n\tv114 = ~v113;\n\tif (v114) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv117 = 0xF0;\n\tgoto L_0035;\nL_FFFFFFFF:\n\tv117 = 0xD8;\n\treturnVal1 = UnityEngine.Object::op_Inequality(*([this @ X0 (SlicedFilledImage)+v117 @ X8_v10 (System.Int32)]), 0);\n\tv127 = ~returnVal1;\n\tv128 = ~v127;\n\tif (v128) goto L_0071;\nL_0049:\n\treturn returnVal1;\nL_004E:\n\t*([v20 @ X20_v1+6D8]) = 1;\n\tv83 = 0xB292000 + 0x5A0;\n\tv73 = *([B78D6D6]) & 1;\n\tv74 = v73 == 0;\n\tv54 = ~v74;\nL_FFFFFFFF:\n\tv65 = v83;\n\tif (v54) goto L_0018;\nL_005B:\n\t*([B78D6D6]) = 1;\n\tv78 = this + 0xF0;\nL_FFFFFFFF:\n\tv83 = v65;\nL_FFFFFFFF:\n\tv91 = this.m_OverrideSprite;\n\tgoto L_0021;\nL_006A:\n\treturnVal1 = UnityEngine.Object::op_Inequality(*([this @ X0 (SlicedFilledImage)+v117 @ X8_v10 (System.Int32)]), 0);\n\tv137 = ~returnVal1;\n\tif (v137) goto L_0049;\nL_0071:\n\tgoto L_0077;\nL_0082:\n\tv234 = UnityEngine.Object::op_Inequality(*([v78 @ X21_v4]), 0);\n\tv185 = v234 == 0;\n\tv173 = ~v185;\n\tv170 = ~v173;\n\tif (v170) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv212 = v78;\n\tgoto L_0097;\nL_FFFFFFFF:\n\tv212 = v215;\nL_0097:\n\tv239 = UnityEngine.Sprite::get_border(*([v212 @ X8_v15]));\n\tv241 = v239 * v239;\n\tv242 = v239.y * v239.y;\n\tv243 = v241 + v242;\n\tv244 = v239.z * v239.z;\n\tv245 = v244 + v243;\n\tv162 = v239.w * v239.w;\n\tv164 = v162 + v245;\n\tv187 = v164 < 0;\n\tv184 = v164 == 0;\n\tv190 = v164 == v164;\n\tv175 = ~v190;\n\tv247 = v187 == v175;\n\tv156 = ~v184;\n\tv172 = v247 & v156;\n\treturn v172;\nL_0035:\n\tv119 = *([v83 @ X22_v5 (System.Int32)]);\n\tv121 = *([v119 @ X0_v14+E4]) == 0;\n\tif (v121) goto L_006A;\nL_0077:\n\tv215 = this + 0xD8;\n\tgoto L_0082;\n")]
		get
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::get_hasBorder");
			return default;
		}
	}

	[Token(Token = "0x17000019")]
	public override Material material
	{
		[Token(Token = "0x6000058")]
		[Address(RVA = "0x3C63110", Offset = "0x3C63110", Length = "0x248")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Inequality(this.m_Material, 0);\n\tv68 = ~v59;\n\tif (v68) goto L_0043;\n\treturn this.m_Material;\nL_0043:\n\tgoto L_004A;\nL_0055:\n\tv221 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv226 = v221 == 0;\n\tv232 = ~v226;\n\tv233 = ~v232;\n\tif (v233) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv236 = 0xF0;\n\tgoto L_006C;\nL_FFFFFFFF:\n\tv236 = 0xD8;\nL_006F:\n\tv243 = UnityEngine.Object::op_Implicit(*([this @ X0 (SlicedFilledImage)+v236 @ X8_v7 (System.Int32)]));\n\tv245 = ~v243;\n\tv246 = ~v245;\n\tif (v246) goto L_007E;\n\tgoto L_00D7;\nL_007E:\n\tgoto L_0084;\nL_008F:\n\tv287 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv134 = v287 == 0;\n\tv109 = ~v134;\n\tv105 = ~v109;\n\tif (v105) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv190 = v161;\n\tgoto L_00A4;\nL_FFFFFFFF:\n\tv190 = v152;\nL_00A4:\n\tv293 = UnityEngine.Sprite::get_associatedAlphaSplitTexture(*([v190 @ X8_v14]));\n\tgoto L_00AB;\nL_00AB:\n\tv267 = UnityEngine.Object::op_Inequality(v293, 0);\n\tv269 = ~v267;\n\tif (v269) goto L_00D7;\n\tgoto L_00BE;\nL_00BE:\n\treturnVal3 = UnityEngine.UI.Image::get_defaultETC1GraphicMaterial();\n\treturn returnVal3;\nL_00D7:\n\tv176 = UnityEngine.UI.Graphic::get_defaultMaterial(v176);\nL_00D7:\n\treturn this;\nL_004A:\n\tv161 = this + 0xF0;\n\tgoto L_0055;\nL_006C:\n\tgoto L_006F;\nL_0084:\n\tv152 = this + 0xD8;\n\tgoto L_008F;\n")]
		get
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::get_material");
			return default;
		}
		[Token(Token = "0x6000059")]
		[Address(RVA = "0x3C63358", Offset = "0x3C63358", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UI.Graphic::set_material(this, value);\n\treturn;\n")]
		set
		{
			base.material = value;
		}
	}

	[Token(Token = "0x1700001A")]
	[field: Token(Token = "0x400002C")]
	[field: FieldOffset(Offset = "0xF8")]
	public float alphaHitTestMinimumThreshold
	{
		[Token(Token = "0x600005A")]
		[Address(RVA = "0x3C63360", Offset = "0x3C63360", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.alphaHitTestMinimumThreshold;\n")]
		get;
		[Token(Token = "0x600005B")]
		[Address(RVA = "0x3C63368", Offset = "0x3C63368", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.alphaHitTestMinimumThreshold = value;\n\treturn;\n")]
		set;
	}

	[Token(Token = "0x1700001B")]
	int ILayoutElement.layoutPriority
	{
		[Token(Token = "0x6000064")]
		[Address(RVA = "0x3C64C40", Offset = "0x3C64C40", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		get
		{
			return 0;
		}
	}

	[Token(Token = "0x1700001C")]
	float ILayoutElement.minWidth
	{
		[Token(Token = "0x6000065")]
		[Address(RVA = "0x3C64C48", Offset = "0x3C64C48", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		get
		{
			return 0f;
		}
	}

	[Token(Token = "0x1700001D")]
	float ILayoutElement.minHeight
	{
		[Token(Token = "0x6000066")]
		[Address(RVA = "0x3C64C50", Offset = "0x3C64C50", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		get
		{
			return 0f;
		}
	}

	[Token(Token = "0x1700001E")]
	float ILayoutElement.flexibleWidth
	{
		[Token(Token = "0x6000067")]
		[Address(RVA = "0x3C64C58", Offset = "0x3C64C58", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn -1f;\n")]
		get
		{
			return -1f;
		}
	}

	[Token(Token = "0x1700001F")]
	float ILayoutElement.flexibleHeight
	{
		[Token(Token = "0x6000068")]
		[Address(RVA = "0x3C64C60", Offset = "0x3C64C60", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn -1f;\n")]
		get
		{
			return -1f;
		}
	}

	[Token(Token = "0x17000020")]
	float ILayoutElement.preferredWidth
	{
		[Token(Token = "0x6000069")]
		[Address(RVA = "0x3C64C68", Offset = "0x3C64C68", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = 0xB78D000;\n\tv22 = *([B78D6DD]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_004D;\n\tv78 = 0xB292000 + 0x5A0;\n\tv28 = *([B78D6D6]) & 1;\n\tv29 = v28 == 0;\nL_FFFFFFFF:\n\tv63 = v78;\n\tif (v29) goto L_005A;\nL_FFFFFFFF:\n\tv86 = this.m_OverrideSprite;\n\tgoto L_001F;\nL_001F:\n\tv92 = UnityEngine.Object::op_Inequality(v86, 0);\n\tv100 = v92 == 0;\n\tv107 = ~v100;\n\tv108 = ~v107;\n\tif (v108) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv111 = 0xF0;\n\tgoto L_0033;\nL_FFFFFFFF:\n\tv111 = 0xD8;\n\tv119 = UnityEngine.Object::op_Equality(*([this @ X0 (SlicedFilledImage)+v111 @ X8_v10 (System.Int32)]), 0);\n\tv123 = v119 == 0;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v123) goto L_0071;\nL_0048:\n\treturn returnVal1;\nL_004D:\n\t*([v20 @ X20_v1+6DD]) = 1;\n\tv78 = 0xB292000 + 0x5A0;\n\tv71 = *([B78D6D6]) & 1;\n\tv72 = v71 == 0;\n\tv54 = ~v72;\nL_FFFFFFFF:\n\tv63 = v78;\n\tif (v54) goto L_FFFFFFFF;\nL_005A:\n\t*([B78D6D6]) = 1;\nL_FFFFFFFF:\n\tv78 = v63;\nL_FFFFFFFF:\n\tv86 = this.m_OverrideSprite;\n\tgoto L_001F;\nL_0067:\n\tv127 = UnityEngine.Object::op_Equality(*([this @ X0 (SlicedFilledImage)+v111 @ X8_v10 (System.Int32)]), 0);\n\tv153 = v127 == 0;\n\tv134 = ~v153;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v134) goto L_0048;\nL_0071:\n\tgoto L_007C;\nL_0081:\n\tv220 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv179 = v220 == 0;\n\tv167 = ~v179;\n\tv165 = ~v167;\n\tif (v165) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv199 = 0xF0;\n\tgoto L_0096;\nL_FFFFFFFF:\n\tv199 = 0xD8;\nL_0033:\n\tv113 = *([v78 @ X21_v5 (System.Int32)]);\n\tv115 = *([v113 @ X0_v14+E4]) == 0;\n\tif (v115) goto L_0067;\nL_007C:\n\tgoto L_0081;\nL_0096:\n\tv226 = UnityEngine.Sprites.DataUtility::GetMinSize(*([this @ X0 (SlicedFilledImage)+v199 @ X8_v16 (System.Int32)]));\n\tv228 = SlicedFilledImage::get_pixelsPerUnit(this);\n\treturnVal2 = v226 / v228;\n\treturn returnVal2;\n")]
		get
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::get_preferredWidth");
			return default;
		}
	}

	[Token(Token = "0x17000021")]
	float ILayoutElement.preferredHeight
	{
		[Token(Token = "0x600006A")]
		[Address(RVA = "0x3C64DFC", Offset = "0x3C64DFC", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = 0xB78D000;\n\tv22 = *([B78D6DE]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_004D;\n\tv78 = 0xB292000 + 0x5A0;\n\tv28 = *([B78D6D6]) & 1;\n\tv29 = v28 == 0;\nL_FFFFFFFF:\n\tv63 = v78;\n\tif (v29) goto L_005A;\nL_FFFFFFFF:\n\tv86 = this.m_OverrideSprite;\n\tgoto L_001F;\nL_001F:\n\tv92 = UnityEngine.Object::op_Inequality(v86, 0);\n\tv100 = v92 == 0;\n\tv107 = ~v100;\n\tv108 = ~v107;\n\tif (v108) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv111 = 0xF0;\n\tgoto L_0033;\nL_FFFFFFFF:\n\tv111 = 0xD8;\n\tv119 = UnityEngine.Object::op_Equality(*([this @ X0 (SlicedFilledImage)+v111 @ X8_v10 (System.Int32)]), 0);\n\tv123 = v119 == 0;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v123) goto L_0071;\nL_0048:\n\treturn returnVal1;\nL_004D:\n\t*([v20 @ X20_v1+6DE]) = 1;\n\tv78 = 0xB292000 + 0x5A0;\n\tv71 = *([B78D6D6]) & 1;\n\tv72 = v71 == 0;\n\tv54 = ~v72;\nL_FFFFFFFF:\n\tv63 = v78;\n\tif (v54) goto L_FFFFFFFF;\nL_005A:\n\t*([B78D6D6]) = 1;\nL_FFFFFFFF:\n\tv78 = v63;\nL_FFFFFFFF:\n\tv86 = this.m_OverrideSprite;\n\tgoto L_001F;\nL_0067:\n\tv127 = UnityEngine.Object::op_Equality(*([this @ X0 (SlicedFilledImage)+v111 @ X8_v10 (System.Int32)]), 0);\n\tv153 = v127 == 0;\n\tv134 = ~v153;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v134) goto L_0048;\nL_0071:\n\tgoto L_007C;\nL_0081:\n\tv220 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv179 = v220 == 0;\n\tv167 = ~v179;\n\tv165 = ~v167;\n\tif (v165) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv199 = 0xF0;\n\tgoto L_0096;\nL_FFFFFFFF:\n\tv199 = 0xD8;\nL_0033:\n\tv113 = *([v78 @ X21_v5 (System.Int32)]);\n\tv115 = *([v113 @ X0_v14+E4]) == 0;\n\tif (v115) goto L_0067;\nL_007C:\n\tgoto L_0081;\nL_0096:\n\tv226 = UnityEngine.Sprites.DataUtility::GetMinSize(*([this @ X0 (SlicedFilledImage)+v199 @ X8_v16 (System.Int32)]));\n\tv228 = SlicedFilledImage::get_pixelsPerUnit(this);\n\treturnVal2 = v226.y / v228;\n\treturn returnVal2;\n")]
		get
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::get_preferredHeight");
			return default;
		}
	}

	[Token(Token = "0x600005C")]
	[Address(RVA = "0x3C63370", Offset = "0x3C63370", Length = "0x3C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.fillAmount = 1f;\n\tthis.fillCenter = 1;\n\tthis.pixelsPerUnitMultiplier = 1f;\n\tUnityEngine.UI.MaskableGraphic::.ctor(this);\n\tthis.<useLegacyMeshGeneration>k__BackingField = 0;\n\treturn;\n")]
	protected SlicedFilledImage()
	{
		global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::.ctor");
	}

	[Token(Token = "0x600005D")]
	[Address(RVA = "0x3C633AC", Offset = "0x3C633AC", Length = "0x28")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UI.MaskableGraphic::OnEnable(this);\n\tSlicedFilledImage::TrackImage(this);\n\treturn;\n")]
	protected override void OnEnable()
	{
		base.OnEnable();
		TrackImage();
	}

	[Token(Token = "0x600005E")]
	[Address(RVA = "0x3C633D4", Offset = "0x3C633D4", Length = "0xC0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UI.MaskableGraphic::OnDisable(this);\n\tv27 = this.m_Tracked != 1;\n\tif (v27) goto L_0033;\n\tgoto L_0021;\nL_0021:\n\tgoto L_002A;\nL_002A:\n\tv38 = System.Collections.Generic.List`1<SlicedFilledImage>::Remove(v93.m_TrackedTexturelessImages, this);\n\tthis.m_Tracked = 0;\nL_0033:\n\treturn;\n")]
	protected override void OnDisable()
	{
		base.OnDisable();
		if (m_Tracked)
		{
			bool flag = m_TrackedTexturelessImages.Remove(this);
			m_Tracked = false;
		}
	}

	[Token(Token = "0x600005F")]
	[Address(RVA = "0x3C63540", Offset = "0x3C63540", Length = "0x12C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = 0xB78D000;\n\tv20 = *([B78D6DA]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_004C;\n\tv73 = 0xB292000 + 0x5A0;\n\tv26 = *([B78D6D6]) & 1;\n\tv27 = v26 == 0;\nL_FFFFFFFF:\n\tv59 = v73;\n\tif (v27) goto L_0059;\nL_FFFFFFFF:\n\tv81 = this.m_OverrideSprite;\n\tgoto L_001E;\nL_001E:\n\tv87 = UnityEngine.Object::op_Inequality(v81, 0);\n\tv95 = v87 == 0;\n\tv102 = ~v95;\n\tv103 = ~v102;\n\tif (v103) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv106 = 0xF0;\n\tgoto L_0032;\nL_FFFFFFFF:\n\tv106 = 0xD8;\n\tv114 = UnityEngine.Object::op_Equality(*([this @ X0 (SlicedFilledImage)+v106 @ X8_v10 (System.Int32)]), 0);\n\tv116 = ~v114;\nL_FFFFFFFF:\n\t;\n\tif (v116) goto L_0073;\nL_0046:\n\tUnityEngine.UI.Graphic::OnPopulateMesh(this, vh);\n\treturn;\nL_004C:\n\t*([v18 @ X21_v1+6DA]) = 1;\n\tv73 = 0xB292000 + 0x5A0;\n\tv68 = *([B78D6D6]) & 1;\n\tv69 = v68 == 0;\n\tv49 = ~v69;\nL_FFFFFFFF:\n\tv59 = v73;\n\tif (v49) goto L_FFFFFFFF;\nL_0059:\n\t*([B78D6D6]) = 1;\nL_FFFFFFFF:\n\tv73 = v59;\nL_FFFFFFFF:\n\tv81 = this.m_OverrideSprite;\n\tgoto L_001E;\nL_0066:\n\tv120 = UnityEngine.Object::op_Equality(*([this @ X0 (SlicedFilledImage)+v106 @ X8_v10 (System.Int32)]), 0);\n\tv147 = ~v120;\n\tv125 = ~v147;\nL_FFFFFFFF:\n\t;\n\tif (v125) goto L_0046;\nL_0073:\n\tSlicedFilledImage::GenerateSlicedFilledSprite(this, vh);\n\treturn;\nL_0032:\n\tv108 = *([v73 @ X22_v5 (System.Int32)]);\n\tv110 = *([v108 @ X0_v14+E4]) == 0;\n\tif (v110) goto L_0066;\n")]
	protected override void OnPopulateMesh(VertexHelper vh)
	{
		global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::OnPopulateMesh");
	}

	[Token(Token = "0x6000060")]
	[Address(RVA = "0x3C64170", Offset = "0x3C64170", Length = "0x1E8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_0032:\n\tv73 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv78 = v73 == 0;\n\tv85 = ~v78;\n\tv86 = ~v85;\n\tif (v86) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv89 = 0xF0;\n\tgoto L_0049;\nL_FFFFFFFF:\n\tv89 = 0xD8;\nL_004D:\n\tv97 = UnityEngine.Object::op_Equality(*([this @ X0 (SlicedFilledImage)+v89 @ X8_v7 (System.Int32)]), 0);\n\tv99 = ~v97;\n\tif (v99) goto L_006E;\n\tv111 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tUnityEngine.CanvasRenderer::SetAlphaTexture(v111, 0);\n\treturn;\nL_006E:\n\tgoto L_0074;\nL_007F:\n\tv186 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv157 = v186 == 0;\n\tv147 = ~v157;\n\tv145 = ~v147;\n\tif (v145) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv179 = v62;\n\tgoto L_0094;\nL_FFFFFFFF:\n\tv179 = v128;\nL_0094:\n\tv236 = UnityEngine.Sprite::get_associatedAlphaSplitTexture(*([v179 @ X8_v13]));\n\tgoto L_009D;\nL_009D:\n\tv242 = UnityEngine.Object::op_Inequality(v236, 0);\n\tv244 = ~v242;\n\tif (v244) goto L_00C3;\n\tv172 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tUnityEngine.CanvasRenderer::SetAlphaTexture(v172, v236);\n\treturn;\nL_00C3:\n\treturn;\nL_001A:\n\tUnityEngine.UI.Graphic::UpdateMaterial(this);\n\tgoto L_0027;\nL_0027:\n\tv62 = this + 0xF0;\n\tgoto L_0032;\nL_0049:\n\tgoto L_004D;\nL_0074:\n\tv128 = this + 0xD8;\n\tgoto L_007F;\n")]
	protected override void UpdateMaterial()
	{
		global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::UpdateMaterial");
	}

	[Token(Token = "0x6000061")]
	[Address(RVA = "0x3C6366C", Offset = "0x3C6366C", Length = "0xB04")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tUnityEngine.UI.VertexHelper::Clear(vh);\n\tv519 = this.fillAmount < 0x3A83126F;\n\tif (v519) goto L_056A;\n\tv529 = UnityEngine.UI.Graphic::GetPixelAdjustedRect(this);\n\tgoto L_004D;\nL_0058:\n\tv779 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv784 = v779 == 0;\n\tv791 = ~v784;\n\tv792 = ~v791;\n\tif (v792) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv795 = 0xF0;\n\tgoto L_006D;\nL_FFFFFFFF:\n\tv795 = 0xD8;\nL_0086:\n\tv191 = this + 0xD8;\n\tv822 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv827 = v822 == 0;\n\tv833 = ~v827;\n\tv834 = ~v833;\n\tif (v834) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv837 = 0xF0;\n\tgoto L_009F;\nL_FFFFFFFF:\n\tv837 = 0xD8;\n\tgoto L_00BF;\nL_00C4:\n\tv877 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv886 = v877 == 0;\n\tv891 = ~v886;\n\tv892 = ~v891;\n\tif (v892) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv898 = v122;\n\tgoto L_00D7;\nL_FFFFFFFF:\n\tv898 = v191;\nL_00F5:\n\tv930 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv390 = v930 == 0;\n\tv219 = ~v390;\n\tv214 = ~v219;\n\tif (v214) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv495 = v122;\n\tgoto L_010A;\nL_FFFFFFFF:\n\tv495 = v191;\nL_010A:\n\tv979 = UnityEngine.Sprite::get_border(*([v495 @ X8_v50]));\n\tv437 = SlicedFilledImage::get_pixelsPerUnit(this);\n\tv458 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\tv186 = v979 / v437;\n\tv171 = v979.z / v437;\n\tv1063 = UnityEngine.RectTransform::get_rect(v458);\n\tv1074 = v1063.width == 0;\n\tif (v1074) goto L_012B;\n\tv1101 = v529.width / v1063.width;\n\tv186 = v186 * v1101;\n\tv171 = v171 * v1101;\n\tv1130 = v1108 == 0;\n\tif (v1130) goto L_0143;\n\tv1136 = v529.width / v1108;\n\tv171 = v171 * v1136;\n\tv186 = v186 * v1136;\nL_FFFFFFFF:\n\tv202 = v431;\n\tgoto L_0151;\nL_FFFFFFFF:\n\tv202 = v319;\nL_FFFFFFFF:\n\tv196 = v1107;\n\tgoto L_0157;\nL_FFFFFFFF:\n\tv196 = v140;\n\tv1232 = v1211 == 0;\n\tif (v1232) goto L_016D;\n\tv1240 = v529.height / v1211;\n\tv202 = v202 * v1240;\n\tv196 = v196 * v1240;\n\tv306 = v446 / v444;\n\tv315 = v446.y / v444;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+20]) = v306;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+24]) = v315;\n\tv1442 = v446.z / v444;\n\tv1444 = v446.w / v444;\n\tv438 = v529.height - v1444;\n\tv425 = v529.width - v1442;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+38]) = v425;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+3C]) = v438;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+28]) = v186;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+2C]) = v196;\n\tv138 = v529.width - v171;\n\tv134 = v529.height - v202;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+30]) = v138;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+34]) = v134;\n\tgoto L_01A3;\nL_01A3:\n\tv1447 = v529 + v306;\n\tv1449 = v529.y + v315;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+20]) = v1447;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+24]) = v1449;\n\tv1450 = v529 + v186;\n\tv1451 = v529.y + v196;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+28]) = v1450;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+2C]) = v1451;\n\tv1452 = v529 + v138;\n\tv1453 = v529.y + v134;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+30]) = v1452;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+34]) = v1453;\n\tv1454 = v529 + v425;\n\tv1455 = v529.y + v438;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+38]) = v1454;\n\t*([v501 @ X8_v53 (UnityEngine.Vector2[])+3C]) = v1455;\n\tgoto L_028F;\nL_01B9:\n\tgoto L_01C4;\nL_01C9:\n\tv881 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv398 = v881 == 0;\n\tv226 = ~v398;\n\tv216 = ~v226;\n\tif (v216) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv503 = v122;\n\tgoto L_01DE;\nL_FFFFFFFF:\n\tv503 = v191;\nL_01DE:\n\tv906 = UnityEngine.Sprite::get_rect(*([v503 @ X8_v20]));\n\tv921 = 0xB193000;\n\tgoto L_01F5;\nL_01FB:\n\tv948 = 0x8BF6AF4(&v946 @ stack_-A8_v2 (System.Double), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v906.width, v906.y, v906.width, v906.height, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv951 = v906.width < 0;\n\tv955 = v906.width == v906.width;\n\tv956 = ~v955;\n\tv957 = v951 == v956;\n\tif (v957) goto L_0216;\n\tv960 = v906.width == -0.5d;\n\tv967 = ~v960;\n\tif (v967) goto L_04C0;\nL_FFFFFFFF:\n\tv998 = -1d;\nL_FFFFFFFF:\n\tv999 = v946;\nL_FFFFFFFF:\n\tv1000 = v946;\n\tgoto L_0222;\nL_0216:\n\tv970 = v906.width == 0.5d;\n\tv977 = ~v970;\n\tif (v977) goto L_04C7;\nL_FFFFFFFF:\n\tv998 = 1d;\nL_FFFFFFFF:\n\tv999 = v946;\nL_FFFFFFFF:\n\tv1000 = v946;\nL_FFFFFFFF:\n\tv1019 = v999;\n\tgoto L_022F;\nL_FFFFFFFF:\n\tv1019 = v1001;\nL_FFFFFFFF:\n\tv587 = v1019;\n\tgoto L_04D8;\n\t*([v240 @ X9_v9 (UnityEngine.Vector2[])+20]) = v798;\n\t*([v240 @ X9_v9 (UnityEngine.Vector2[])+24]) = v798.y;\n\t*([v240 @ X9_v9 (UnityEngine.Vector2[])+28]) = v443;\n\t*([v240 @ X9_v9 (UnityEngine.Vector2[])+2C]) = v443.y;\n\t*([v240 @ X9_v9 (UnityEngine.Vector2[])+30]) = v443.z;\n\t*([v240 @ X9_v9 (UnityEngine.Vector2[])+34]) = v443.w;\n\t*([v240 @ X9_v9 (UnityEngine.Vector2[])+38]) = v798.z;\n\t*([v240 @ X9_v9 (UnityEngine.Vector2[])+3C]) = v798.w;\n\tv1481 = this.fillDirection < 1;\n\tv382 = ~v1481;\n\tv365 = this.fillDirection - 1;\n\tv399 = v365 == 0;\n\tv1482 = ~v399;\n\tv227 = v382 & v1482;\n\tif (v227) goto L_02FB;\n\tgoto L_02D8;\n\tv1540 = *([v504 @ X8_v97 (UnityEngine.Vector2[])+20]);\n\tv1552 = *([v504 @ X8_v97 (UnityEngine.Vector2[])+38]) - *([v504 @ X8_v97 (UnityEngine.Vector2[])+20]);\n\tv1525 = *([v504 @ X8_v97 (UnityEngine.Vector2[])+38]) > *([v504 @ X8_v97 (UnityEngine.Vector2[])+20]);\n\tif (v1525) goto L_0320;\nL_FFFFFFFF:\n\tv172 = *([v504 @ X8_v97 (UnityEngine.Vector2[])+20]);\nL_FFFFFFFF:\n\tv182 = 1f;\n\tgoto L_FFFFFFFF;\nL_02FB:\n\tgoto L_02FF;\n\tv1540 = *([v505 @ X8_v93 (UnityEngine.Vector2[])+24]);\n\tv1552 = *([v505 @ X8_v93 (UnityEngine.Vector2[])+3C]) - *([v505 @ X8_v93 (UnityEngine.Vector2[])+24]);\n\tv1538 = *([v505 @ X8_v93 (UnityEngine.Vector2[])+3C]) <= *([v505 @ X8_v93 (UnityEngine.Vector2[])+24]);\nL_FFFFFFFF:\n\tv172 = *([v505 @ X8_v93 (UnityEngine.Vector2[])+24]);\nL_FFFFFFFF:\n\tv182 = 1f;\n\tif (v1538) goto L_FFFFFFFF;\nL_0320:\n\tv182 = 1f / v1552;\nL_FFFFFFFF:\n\tv172 = v1540;\nL_0329:\n\tv641 = v280 == 3;\nL_FFFFFFFF:\n\tv123 = v280;\n\tif (v641) goto L_056A;\nL_0330:\n\tv280 = v123 + 1;\n\tv284 = v123 << 3;\n\tv192 = v280 << 3;\nL_FFFFFFFF:\n\tv104 = 0;\n\tgoto L_0349;\nL_FFFFFFFF:\n\tv551 = 2;\nL_0349:\n\tv1645 = v104 != 1;\n\tif (v1645) goto L_035A;\n\tv1655 = v123 != 1;\n\tif (v1655) goto L_035A;\n\tv1666 = this.fillCenter == 0;\n\tif (v1666) goto L_FFFFFFFF;\nL_035A:\n\tv551 = v104 + 1;\n\tv230 = this.fillDirection > 1;\n\tif (v230) goto L_0399;\n\tv1673 = this.fillDirection == 0;\n\tif (v1673) goto L_03DE;\n\tv228 = this.fillDirection != 1;\nL_FFFFFFFF:\n\tv203 = 0;\nL_FFFFFFFF:\n\tv288 = 0;\n\tif (v228) goto L_03CF;\n\tgoto L_038E;\nL_038E:\n\tv1817 = v1799.s_SlicedVertices + 0x20;\n\tv1819 = *([v1817 @ X8_v89+v192 @ X25_v7 (System.Int32)]) - v172;\n\tv1820 = v182 * v1819;\n\tv288 = 1f - v1820;\n\tv1849 = *([v1817 @ X8_v89+v284 @ X24_v7 (System.Int32)]);\n\tgoto L_03CB;\nL_0399:\n\tv403 = this.fillDirection == 2;\n\tif (v403) goto L_0411;\n\tv229 = this.fillDirection != 3;\nL_FFFFFFFF:\n\tv203 = 0;\nL_FFFFFFFF:\n\tv288 = 0;\n\tif (v229) goto L_03CF;\n\tgoto L_03C1;\nL_03C1:\n\tv1831 = v1803.s_SlicedVertices + 0x20;\n\tv1832 = v551 << 3;\n\tv1833 = v1831 + v1832;\n\tv1835 = *([v1833 @ X9_v24+4]) - v172;\n\tv1836 = v182 * v1835;\n\tv288 = 1f - v1836;\n\tv1838 = v104 << 3;\n\tv1839 = v1831 + v1838;\n\tv1849 = *([v1839 @ X8_v81+4]);\n\tgoto L_0447;\nL_03DE:\n\tgoto L_03FA;\nL_03FA:\n\tv1750 = v1788.s_SlicedVertices + 0x20;\n\tv1826 = *([v1750 @ X8_v85+v284 @ X24_v7 (System.Int32)]) - v172;\n\tv288 = v182 * v1826;\n\tv1828 = *([v1750 @ X8_v85+v192 @ X25_v7 (System.Int32)]) - v172;\n\tv203 = v182 * v1828;\n\tv1738 = v288 < this.fillAmount;\n\tv1830 = v288 == v288;\n\tv1722 = this.fillAmount == this.fillAmount;\n\tv1726 = v1830 & v1722;\n\tv1718 = ~v1726;\n\tv1702 = v1738 == v1718;\n\tif (v1702) goto L_033A;\n\tgoto L_0447;\nL_0411:\n\tgoto L_042D;\nL_042D:\n\tv1841 = v1795.s_SlicedVertices + 0x20;\n\tv1842 = v104 << 3;\n\tv1705 = v1841 + v1842;\n\tv1844 = *([v1705 @ X9_v22+4]) - v172;\n\tv288 = v182 * v1844;\n\tv1691 = v551 << 3;\n\tv1751 = v1841 + v1691;\n\tv1846 = *([v1751 @ X8_v76+4]) - v172;\n\tv203 = v182 * v1846;\n\tv1739 = v288 < this.fillAmount;\n\tv1848 = v288 == v288;\n\tv1723 = this.fillAmount == this.fillAmount;\n\tv1727 = v1848 & v1723;\n\tv1719 = ~v1727;\n\tv1703 = v1739 == v1719;\n\tif (v1703) goto L_033A;\nL_0447:\n\tgoto L_04A3;\nL_04A3:\n\tv1859 = v243.s_SlicedVertices + 0x20;\n// ... truncated")]
	private void GenerateSlicedFilledSprite(VertexHelper vh)
	{
		global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::GenerateSlicedFilledSprite");
	}

	[Token(Token = "0x6000062")]
	[Address(RVA = "0x3C64860", Offset = "0x3C64860", Length = "0x3E0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv265 = border.y;\n\tv254 = border.w;\n\tv33 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\tv35 = v33 == 0;\n\tif (v35) goto L_0089;\n\tv37 = UnityEngine.RectTransform::get_rect(v33);\n\tv49 = v37.width == 0;\n\tv54 = adjustedRect.height / v37.height;\nL_FFFFFFFF:\n\tv83 = border;\nL_FFFFFFFF:\n\tv84 = border.z;\n\tif (v49) goto L_002A;\n\tv79 = adjustedRect.width / v37.width;\n\tv83 = v79 * border;\n\tv84 = v79 * border.z;\n\tgoto L_003A;\nL_FFFFFFFF:\n\tv123 = v83;\n\tgoto L_0040;\nL_FFFFFFFF:\n\tv123 = v94;\n\tgoto L_004F;\nL_FFFFFFFF:\n\treturnVal1 = v83;\n\tgoto L_0056;\nL_FFFFFFFF:\n\treturnVal1 = v123;\n\tgoto L_0064;\nL_FFFFFFFF:\n\tv254 = v228;\n\tgoto L_006A;\nL_FFFFFFFF:\n\tv265 = v227;\n\tv284 = v266 == 0;\n\tif (v284) goto L_0088;\nL_0089:\n\tthrow System.NullReferenceException;\nL_002A:\n\tv85 = v83 + v84;\n\tv87 = v85 == 0;\n\tv92 = adjustedRect.width / v85;\n\tv94 = v92 * v83;\n\tv95 = ~v87;\n\tif (v95) goto L_003A;\nL_003A:\n\tv113 = ~v87;\n\tif (v113) goto L_FFFFFFFF;\nL_0040:\n\tv124 = adjustedRect.width < v85;\n\tv132 = ~v124;\n\tv133 = ~v132;\n\tif (v133) goto L_004F;\nL_004F:\n\tv164 = ~v124;\n\tv165 = ~v164;\n\tif (v165) goto L_FFFFFFFF;\nL_0056:\n\tv227 = v54 * v265;\n\tv228 = v54 * v254;\n\tv230 = v37.height == 0;\n\tv235 = ~v230;\n\tif (v235) goto L_FFFFFFFF;\nL_0064:\n\tv255 = ~v230;\n\tif (v255) goto L_FFFFFFFF;\nL_006A:\n\tv266 = v265 + v254;\n\tv267 = adjustedRect.height < v266;\n\tv275 = ~v267;\n\tif (v275) goto L_0088;\nL_0088:\n\treturn returnVal1;\n")]
	private Vector4 GetAdjustedBorders(Vector4 border, Rect adjustedRect)
	{
		float num = border.y;
		float num2 = border.w;
		RectTransform rectTransform = base.rectTransform;
		if ((object)rectTransform != null)
		{
			Rect rect = rectTransform.rect;
			bool flag = rect.width == 0f;
			float num3 = adjustedRect.height / rect.height;
			float num4 = border.x;
			float num5 = border.z;
			if (!flag)
			{
				float num6 = adjustedRect.width / rect.width;
				num4 = num6 * border.x;
				num5 = num6 * border.z;
			}
			float num7 = num4 + num5;
			bool flag2 = num7 == 0f;
			float num8 = adjustedRect.width / num7;
			float num9 = num8 * num4;
			if (flag2)
			{
			}
			float x = ((!flag2) ? num9 : num4);
			bool flag3 = adjustedRect.width < num7;
			if (!flag3)
			{
			}
			Vector4 result = default(Vector4);
			if (!flag3)
			{
				result.x = num4;
			}
			else
			{
				result.x = x;
			}
			float num10 = num3 * num;
			float num11 = num3 * num2;
			bool flag4 = rect.height == 0f;
			if (!flag4)
			{
				num2 = num11;
			}
			if (!flag4)
			{
				num = num10;
			}
			float num12 = num + num2;
			if (!(adjustedRect.height < num12) || num12 == 0f)
			{
				return result;
			}
		}
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000063")]
	[Address(RVA = "0x3C64358", Offset = "0x3C64358", Length = "0x508")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv367 = uvs.z;\nL_FFFFFFFF:\n\tv351 = vertices;\nL_FFFFFFFF:\n\tv353 = vertices.y;\nL_FFFFFFFF:\n\tv355 = vertices.z;\nL_FFFFFFFF:\n\tv357 = vertices.w;\nL_FFFFFFFF:\n\tv359 = uvs;\nL_FFFFFFFF:\n\tv361 = uvs.y;\nL_FFFFFFFF:\n\tv363 = uvs.w;\n\tgoto L_003F;\n\treturn;\nL_005C:\n\tv124 = fillAmount < 1f;\n\tif (v124) goto L_0070;\n\tgoto L_006B;\nL_006B:\n\tv376 = v374.s_Vertices == 0;\n\tv377 = ~v376;\n\tif (v377) goto L_0124;\n\tgoto L_0277;\nL_0070:\n\tv291 = vertices.z - vertices;\n\tv292 = v291 * fillAmount;\n\tv293 = vertices + v292;\n\tv294 = uvs.z - uvs;\n\tv295 = v294 * fillAmount;\n\tv296 = uvs + v295;\n\tv297 = vertices.w - vertices.y;\n\tv298 = v297 * fillAmount;\n\tv369 = vertices.w - v298;\n\tv300 = uvs.w - uvs.y;\n\tv301 = v300 * fillAmount;\n\tv365 = uvs.w - v301;\n\tv305 = this.fillDirection - 1;\n\tv307 = v305 == 0;\n\tv329 = vertices.y + v298;\n\tv327 = uvs.y + v301;\n\tv314 = vertices.z - v292;\n\tv315 = uvs.z - v295;\n\tv316 = ~v307;\n\tv317 = ~v316;\n\tif (v317) goto L_FFFFFFFF;\n\tgoto L_0090;\nL_FFFFFFFF:\n\tv327 = uvs.w;\nL_FFFFFFFF:\n\tv372 = v359;\n\tgoto L_0097;\nL_FFFFFFFF:\n\tv372 = v315;\nL_FFFFFFFF:\n\tv343 = v351;\n\tgoto L_009E;\nL_FFFFFFFF:\n\tv343 = v314;\n\tgoto L_00AE;\nL_FFFFFFFF:\n\tv329 = v357;\nL_FFFFFFFF:\n\tv327 = v363;\n\tgoto L_00B4;\n\tgoto L_00BA;\nL_FFFFFFFF:\n\tv365 = v361;\nL_FFFFFFFF:\n\tv372 = v359;\n\tgoto L_00C0;\nL_FFFFFFFF:\n\tv343 = v351;\n\tgoto L_00C6;\n\tgoto L_00CC;\nL_FFFFFFFF:\n\tv369 = v353;\nL_FFFFFFFF:\n\tv329 = v357;\n\tgoto L_00DB;\n\tgoto L_00E1;\nL_FFFFFFFF:\n\tv363 = v327;\nL_FFFFFFFF:\n\tv367 = v296;\n\tgoto L_00E7;\n\tgoto L_00ED;\nL_FFFFFFFF:\n\tv361 = v365;\n\tgoto L_00F3;\nL_FFFFFFFF:\n\tv359 = v372;\n\tgoto L_0102;\nL_FFFFFFFF:\n\tv351 = v343;\n\tgoto L_0108;\nL_FFFFFFFF:\n\tv353 = v369;\nL_FFFFFFFF:\n\tv355 = v293;\n\tgoto L_010E;\n\tgoto L_0118;\nL_FFFFFFFF:\n\tv357 = v329;\nL_0124:\n\t*([v415 @ X9_v2 (UnityEngine.Vector3[])+20]) = v351;\n\t*([v415 @ X9_v2 (UnityEngine.Vector3[])+24]) = v353;\n\t*([v415 @ X9_v2 (UnityEngine.Vector3[])+28]) = 0;\n\t*([v415 @ X9_v2 (UnityEngine.Vector3[])+2C]) = v351;\n\t*([v415 @ X9_v2 (UnityEngine.Vector3[])+30]) = v357;\n\t*([v415 @ X9_v2 (UnityEngine.Vector3[])+34]) = 0;\n\t*([v415 @ X9_v2 (UnityEngine.Vector3[])+38]) = v355;\n\t*([v415 @ X9_v2 (UnityEngine.Vector3[])+3C]) = v357;\n\t*([v415 @ X9_v2 (UnityEngine.Vector3[])+40]) = 0;\n\t*([v415 @ X9_v2 (UnityEngine.Vector3[])+44]) = v355;\n\t*([v415 @ X9_v2 (UnityEngine.Vector3[])+48]) = v353;\n\t*([v415 @ X9_v2 (UnityEngine.Vector3[])+4C]) = 0;\n\tv558 = v428.s_UVs;\n\t*([v558 @ X8_v8 (UnityEngine.Vector2[])+20]) = v359;\n\t*([v558 @ X8_v8 (UnityEngine.Vector2[])+24]) = v361;\n\t*([v558 @ X8_v8 (UnityEngine.Vector2[])+28]) = v359;\n\t*([v558 @ X8_v8 (UnityEngine.Vector2[])+2C]) = v363;\n\t*([v558 @ X8_v8 (UnityEngine.Vector2[])+30]) = v367;\n\t*([v558 @ X8_v8 (UnityEngine.Vector2[])+34]) = v363;\n\t*([v558 @ X8_v8 (UnityEngine.Vector2[])+38]) = v367;\n\t*([v558 @ X8_v8 (UnityEngine.Vector2[])+3C]) = v361;\n\tv682 = UnityEngine.UI.VertexHelper::get_currentVertCount(vh);\n\tgoto L_018C;\n\tv698 = UnityEngine.UI.Graphic::get_color(this);\n\tv538 = 0x3C6492C(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv559 = v702.s_UVs;\n\t// 430 MakeStruct v164 @ AGG3C64648_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v562 @ X8_v11 (UnityEngine.Vector3[])+20], [v562 @ X8_v11 (UnityEngine.Vector3[])+24], [v562 @ X8_v11 (UnityEngine.Vector3[])+28]\n\t// 431 MakeStruct v160 @ AGG3C64648_3_v3 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), [v559 @ X8_v15 (UnityEngine.Vector2[])+20], [v559 @ X8_v15 (UnityEngine.Vector2[])+24], 0, 0\n\tUnityEngine.UI.VertexHelper::AddVert(vh, v164, v538, v160);\n\tgoto L_01B9;\n\tv731 = UnityEngine.UI.Graphic::get_color(this);\n\tv539 = 0x3C6492C(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv560 = v736.s_UVs;\n\t// 483 MakeStruct v156 @ AGG3C646DC_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v563 @ X8_v18 (UnityEngine.Vector3[])+2C], [v563 @ X8_v18 (UnityEngine.Vector3[])+30], [v563 @ X8_v18 (UnityEngine.Vector3[])+34]\n\t// 484 MakeStruct v152 @ AGG3C646DC_3_v3 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), [v560 @ X8_v22 (UnityEngine.Vector2[])+28], [v560 @ X8_v22 (UnityEngine.Vector2[])+2C], 0, 0\n\tUnityEngine.UI.VertexHelper::AddVert(vh, v156, v539, v152);\n\tgoto L_01EE;\n\tv757 = UnityEngine.UI.Graphic::get_color(this);\n\tv540 = 0x3C6492C(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv561 = v762.s_UVs;\n\t// 546 MakeStruct v148 @ AGG3C64770_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v564 @ X8_v25 (UnityEngine.Vector3[])+38], [v564 @ X8_v25 (UnityEngine.Vector3[])+3C], [v564 @ X8_v25 (UnityEngine.Vector3[])+40]\n\t// 547 MakeStruct v144 @ AGG3C64770_3_v3 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), [v561 @ X8_v29 (UnityEngine.Vector2[])+30], [v561 @ X8_v29 (UnityEngine.Vector2[])+34], 0, 0\n\tUnityEngine.UI.VertexHelper::AddVert(vh, v148, v540, v144);\n\tgoto L_022D;\n\tv782 = UnityEngine.UI.Graphic::get_color(this);\n\tv541 = 0x3C6492C(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv234 = v785.s_UVs;\n\t// 599 MakeStruct v141 @ AGG3C64804_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v565 @ X8_v32 (UnityEngine.Vector3[])+44], [v565 @ X8_v32 (UnityEngine.Vector3[])+48], [v565 @ X8_v32 (UnityEngine.Vector3[])+4C]\n\t// 600 MakeStruct v138 @ AGG3C64804_3_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), [v234 @ X8_v36 (UnityEngine.Vector2[])+38], [v234 @ X8_v36 (UnityEngine.Vector2[])+3C], 0, 0\n\tUnityEngine.UI.VertexHelper::AddVert(vh, v141, v541, v138);\n\tv789 = v682 + 1;\n\tv790 = v682 + 2;\n\tUnityEngine.UI.VertexHelper::AddTriangle(vh, v682, v789, v790);\n\tv170 = v682 + 2;\n\tv167 = v682 + 3;\n\tUnityEngine.UI.VertexHelper::AddTriangle(vh, v170, v167, v682);\n\treturn;\nL_0277:\n\tthrow System.NullReferenceException;\nL_003F:\n\tv98 = this.fillAmount < 0x3A83126F;\n\tv106 = ~v98;\n\tif (v106) goto L_005C;\nL_0090:\n\tv446 = ~v307;\n\tv447 = ~v446;\n\tif (v447) goto L_FFFFFFFF;\nL_0097:\n\tv652 = ~v307;\n\tv653 = ~v652;\n\tif (v653) goto L_FFFFFFFF;\nL_009E:\n\tv321 = ~v307;\n\tv658 = ~v321;\n\tif (v658) goto L_FFFFFFFF;\nL_00AE:\n\tv672 = this.fillDirection != 3;\n\tif (v672) goto L_00B4;\nL_00B4:\n\tv678 = this.fillDirection != 3;\n\tif (v678) goto L_FFFFFFFF;\nL_00BA:\n\tv683 = this.fillDirection != 3;\n\tif (v683) goto L_00C0;\nL_00C0:\n\tv693 = this.fillDirection != 3;\n\tif (v693) goto L_00C6;\nL_00C6:\n\tv700 = this.fillDirection != 3;\n\tif (v700) goto L_FFFFFFFF;\nL_00CC:\n\tv705 = this.fillDirection != 3;\n\tif (v705) goto L_00DB;\nL_00DB:\n\tv722 = this.fillDirection != 0;\n\tif (v722) goto L_FFFFFFFF;\nL_00E1:\n\tv728 = this.fillDirection != 0;\n\tif (v728) goto L_00E7;\nL_00E7:\n\tv737 = this.fillDirection != 0;\n\tif (v737) goto L_FFFFFFFF;\nL_00ED:\n\tv741 = this.fillDirection != 0;\n\tif (v741) goto L_FFFFFFFF;\nL_00F3:\n\tv751 = this.fillDirection != 0;\n\tif (v751) goto L_FFFFFFFF;\nL_0102:\n\tv760 = this.fillDirection != 0;\n\tif (v760) goto L_FFFFFFFF;\nL_0108:\n\tv766 = this.fillDirection != 0;\n\tif (v766) goto L_010E;\nL_010E:\n\tv319 = this.fillDirection != 0;\n\tif (v319) goto L_FFFFFFFF;\nL_0118:\n\tgoto L_006B;\nL_018C:\n\tv562 = v692.s_Vertices;\nL_01B9:\n\tv563 = v725.s_Vertices;\nL_01EE:\n\tv564 = v750.s_Vertices;\nL_022D:\n\tv565 = v776.s_Vertices;\n")]
	private void GenerateFilledSprite(VertexHelper vh, Vector4 vertices, Vector4 uvs, float fillAmount)
	{
		//IL_0461: Expected F4, but got I
		//IL_0476: Expected F4, but got I
		//IL_048b: Expected F4, but got I
		//IL_04a0: Expected F4, but got I
		//IL_04b5: Expected F4, but got I
		//IL_0527: Expected F4, but got I
		//IL_053c: Expected F4, but got I
		//IL_0551: Expected F4, but got I
		//IL_0566: Expected F4, but got I
		//IL_057b: Expected F4, but got I
		//IL_05ed: Expected F4, but got I
		//IL_0602: Expected F4, but got I
		//IL_0617: Expected F4, but got I
		//IL_062c: Expected F4, but got I
		//IL_0641: Expected F4, but got I
		//IL_06b3: Expected F4, but got I
		//IL_06c8: Expected F4, but got I
		//IL_06dd: Expected F4, but got I
		//IL_06f2: Expected F4, but got I
		//IL_0707: Expected F4, but got I
		float z = uvs.z;
		Vector4 vector = vertices;
		float y = vertices.y;
		float z2 = vertices.z;
		float w = vertices.w;
		Vector4 vector2 = uvs;
		float y2 = uvs.y;
		float w2 = uvs.w;
		if (this.fillAmount < 0.001f)
		{
			return;
		}
		if (fillAmount < 1f)
		{
			float num = vertices.z - vertices.x;
			float num2 = num * fillAmount;
			float num3 = vertices.x + num2;
			float num4 = uvs.z - uvs.x;
			float num5 = num4 * fillAmount;
			float num6 = uvs.x + num5;
			float num7 = vertices.w - vertices.y;
			float num8 = num7 * fillAmount;
			float num9 = vertices.w - num8;
			float num10 = uvs.w - uvs.y;
			float num11 = num10 * fillAmount;
			float num12 = uvs.w - num11;
			int num13 = (int)(fillDirection - 1);
			bool flag = num13 == 0;
			float num14 = vertices.y + num8;
			float num15 = uvs.y + num11;
			float x = vertices.z - num2;
			float x2 = uvs.z - num5;
			if (flag)
			{
				num15 = uvs.w;
			}
			Vector4 vector3 = default(Vector4);
			if (!flag)
			{
				vector3 = vector2;
			}
			else
			{
				vector3.x = x2;
			}
			Vector4 vector4 = default(Vector4);
			if (!flag)
			{
				vector4 = vector;
			}
			else
			{
				vector4.x = x;
			}
			if (flag)
			{
				num14 = w;
			}
			if (fillDirection == FillDirection.Down)
			{
				num15 = w2;
			}
			if (fillDirection != FillDirection.Down)
			{
				num12 = y2;
			}
			if (fillDirection == FillDirection.Down)
			{
				vector3 = vector2;
			}
			if (fillDirection == FillDirection.Down)
			{
				vector4 = vector;
			}
			if (fillDirection != FillDirection.Down)
			{
				num9 = y;
			}
			if (fillDirection == FillDirection.Down)
			{
				num14 = w;
			}
			if (fillDirection != FillDirection.Right)
			{
				w2 = num15;
			}
			if (fillDirection == FillDirection.Right)
			{
				z = num6;
			}
			if (fillDirection != FillDirection.Right)
			{
				y2 = num12;
			}
			if (fillDirection != FillDirection.Right)
			{
				vector2 = vector3;
			}
			if (fillDirection != FillDirection.Right)
			{
				vector = vector4;
			}
			if (fillDirection != FillDirection.Right)
			{
				y = num9;
			}
			if (fillDirection == FillDirection.Right)
			{
				z2 = num3;
			}
			if (fillDirection != FillDirection.Right)
			{
				w = num14;
			}
		}
		if (s_Vertices != null)
		{
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Vector2[] array = s_UVs;
			int currentVertCount = vh.currentVertCount;
			Vector3[] array2 = s_Vertices;
			Color color = base.color;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C6492C (inside SlicedFilledImage::GetAdjustedBorders +0xCC)");
			Vector2[] array3 = s_UVs;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ X8_v11 (UnityEngine.Vector3[])+20]");
			Vector3 position = default(Vector3);
			position.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ X8_v11 (UnityEngine.Vector3[])+24]");
			position.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ X8_v11 (UnityEngine.Vector3[])+28]");
			position.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ X8_v15 (UnityEngine.Vector2[])+20]");
			Vector4 uv = default(Vector4);
			uv.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ X8_v15 (UnityEngine.Vector2[])+24]");
			uv.y = 0f;
			uv.z = 0f;
			uv.w = 0f;
			Color32 color2 = default(Color32);
			vh.AddVert(position, color2, uv);
			Vector3[] array4 = s_Vertices;
			Color color3 = base.color;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C6492C (inside SlicedFilledImage::GetAdjustedBorders +0xCC)");
			Vector2[] array5 = s_UVs;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ X8_v18 (UnityEngine.Vector3[])+2C]");
			Vector3 position2 = default(Vector3);
			position2.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ X8_v18 (UnityEngine.Vector3[])+30]");
			position2.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ X8_v18 (UnityEngine.Vector3[])+34]");
			position2.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ X8_v22 (UnityEngine.Vector2[])+28]");
			Vector4 uv2 = default(Vector4);
			uv2.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ X8_v22 (UnityEngine.Vector2[])+2C]");
			uv2.y = 0f;
			uv2.z = 0f;
			uv2.w = 0f;
			Color32 color4 = default(Color32);
			vh.AddVert(position2, color4, uv2);
			Vector3[] array6 = s_Vertices;
			Color color5 = base.color;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C6492C (inside SlicedFilledImage::GetAdjustedBorders +0xCC)");
			Vector2[] array7 = s_UVs;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ X8_v25 (UnityEngine.Vector3[])+38]");
			Vector3 position3 = default(Vector3);
			position3.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ X8_v25 (UnityEngine.Vector3[])+3C]");
			position3.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ X8_v25 (UnityEngine.Vector3[])+40]");
			position3.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ X8_v29 (UnityEngine.Vector2[])+30]");
			Vector4 uv3 = default(Vector4);
			uv3.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ X8_v29 (UnityEngine.Vector2[])+34]");
			uv3.y = 0f;
			uv3.z = 0f;
			uv3.w = 0f;
			Color32 color6 = default(Color32);
			vh.AddVert(position3, color6, uv3);
			Vector3[] array8 = s_Vertices;
			Color color7 = base.color;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C6492C (inside SlicedFilledImage::GetAdjustedBorders +0xCC)");
			Vector2[] array9 = s_UVs;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ X8_v32 (UnityEngine.Vector3[])+44]");
			Vector3 position4 = default(Vector3);
			position4.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ X8_v32 (UnityEngine.Vector3[])+48]");
			position4.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ X8_v32 (UnityEngine.Vector3[])+4C]");
			position4.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ X8_v36 (UnityEngine.Vector2[])+38]");
			Vector4 uv4 = default(Vector4);
			uv4.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ X8_v36 (UnityEngine.Vector2[])+3C]");
			uv4.y = 0f;
			uv4.z = 0f;
			uv4.w = 0f;
			Color32 color8 = default(Color32);
			vh.AddVert(position4, color8, uv4);
			int idx = currentVertCount + 1;
			int idx2 = currentVertCount + 2;
			vh.AddTriangle(currentVertCount, idx, idx2);
			int idx3 = currentVertCount + 2;
			int idx4 = currentVertCount + 3;
			vh.AddTriangle(idx3, idx4, currentVertCount);
			return;
		}
		throw new NullReferenceException();
	}

	[Token(Token = "0x600006B")]
	[Address(RVA = "0x3C64F90", Offset = "0x3C64F90", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	void ILayoutElement.CalculateLayoutInputHorizontal()
	{
	}

	[Token(Token = "0x600006C")]
	[Address(RVA = "0x3C64F94", Offset = "0x3C64F94", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	void ILayoutElement.CalculateLayoutInputVertical()
	{
	}

	[Token(Token = "0x600006D")]
	[Address(RVA = "0x3C64F98", Offset = "0x3C64F98", Length = "0x864")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv83 = this.alphaHitTestMinimumThreshold < 1f;\n\tv84 = this.alphaHitTestMinimumThreshold == 1f;\n\tv87 = this.alphaHitTestMinimumThreshold == this.alphaHitTestMinimumThreshold;\n\tv88 = 1f == 1f;\n\tv89 = v87 & v88;\n\tv90 = ~v89;\n\tv91 = v83 == v90;\n\tv92 = ~v84;\n\tv93 = v91 & v92;\n\tif (v93) goto L_FFFFFFFF;\n\tgoto L_004B;\nL_0058:\n\tv481 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv132 = v481 == 0;\n\tv121 = ~v132;\n\tv99 = ~v121;\n\tif (v99) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv486 = 0xF0;\n\tgoto L_006F;\nL_FFFFFFFF:\n\tv486 = 0xD8;\nL_0073:\n\tv136 = UnityEngine.Object::op_Equality(*([this @ X0 (SlicedFilledImage)+v486 @ X8_v10 (System.Int32)]), 0);\n\tv139 = v136 == 0;\n\tif (v139) goto L_0084;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_03DC;\nL_0084:\n\tv509 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\tgoto L_0096;\n\tv513 = UnityEngine.UI.Graphic::GetPixelAdjustedRect(this);\n\tv522 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\tv523 = v522 == 0;\n\tif (v523) goto L_042E;\n\tv525 = UnityEngine.RectTransform::get_pivot(v522);\n\tv695 = v513.width * v525;\n\tv562 = v298 + v695;\n\tv652 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\tv662 = v652 == 0;\n\tif (v662) goto L_042E;\n\tv705 = UnityEngine.RectTransform::get_pivot(v652);\n\tv723 = v513.height * v705.y;\n\tv566 = v187 + v723;\n\tgoto L_00C3;\nL_00CE:\n\tv743 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv643 = v743 == 0;\n\tv613 = ~v643;\n\tv572 = ~v613;\n\tif (v572) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv674 = v97;\n\tgoto L_00E0;\nL_FFFFFFFF:\n\tv674 = v268;\n\tv567 = UnityEngine.Sprite::get_rect(*([v674 @ X8_v21]));\n\tgoto L_00F8;\nL_00FD:\n\tv765 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv640 = v765 == 0;\n\tv610 = ~v640;\n\tv570 = ~v610;\n\tif (v570) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv671 = v97;\n\tgoto L_010F;\nL_FFFFFFFF:\n\tv671 = v268;\n\tv770 = UnityEngine.Sprite::get_border(*([v671 @ X8_v25]));\n\tv563 = SlicedFilledImage::get_pixelsPerUnit(this);\n\tv653 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\tv663 = v653 == 0;\n\tif (v663) goto L_042E;\n\tv531 = v770 / v563;\n\tv543 = v770.z / v563;\n\tv776 = UnityEngine.RectTransform::get_rect(v653);\n\tv781 = v776.width == 0;\n\tif (v781) goto L_0136;\n\tv786 = v513.width / v776.width;\n\tv531 = v531 * v786;\n\tv543 = v543 * v786;\n\tv806 = v794 == 0;\n\tif (v806) goto L_014E;\n\tv812 = v513.width / v794;\n\tv543 = v543 * v812;\n\tv531 = v531 * v812;\n\tgoto L_015C;\nL_FFFFFFFF:\n\tv861 = v821;\n\tgoto L_0162;\nL_FFFFFFFF:\n\tv854 = v820;\n\tv847 = v836 == 0;\n\tif (v847) goto L_0179;\n\tv853 = v513.height / v836;\n\tv861 = v861 * v853;\n\tv854 = v854 * v853;\n\tv874 = v513.width - v562;\n\tv876 = v874 == v543;\n\tv877 = v874 < v543;\n\tv878 = ~v877;\n\tv883 = ~v878;\n\tv884 = v883 | v876;\n\tif (v884) goto L_022A;\n\tv898 = v567.width - v770.z;\n\tv899 = v898 - v770;\n\tv900 = v513.width - v543;\n\tv903 = v531 == v900;\nL_FFFFFFFF:\n\tv989 = 0;\n\tif (v903) goto L_01C1;\n\tv973 = v562 - v531;\n\tv974 = v900 - v531;\n\tv975 = v973 / v974;\n\tv977 = v975 < 1f;\n\tv978 = v975 == 1f;\n\tv981 = v975 == v975;\n\tv982 = 1f == 1f;\n\tv983 = v981 & v982;\n\tv984 = ~v983;\n\tv985 = v977 == v984;\n\tv986 = ~v978;\n\tv987 = v985 & v986;\n\tv988 = ~v987;\n\tif (v988) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv993 = 1f;\n\tgoto L_01B4;\nL_FFFFFFFF:\n\tv993 = v975;\nL_FFFFFFFF:\n\tv989 = 0;\n\tgoto L_01C1;\nL_FFFFFFFF:\n\tv989 = v993;\nL_FFFFFFFF:\n\tv1210 = 0;\n\tgoto L_01CD;\nL_FFFFFFFF:\n\tv1210 = v989;\nL_01D3:\n\tv887 = v566 == v854;\n\tv888 = v566 < v854;\n\tv889 = ~v888;\n\tv894 = ~v889;\n\tv895 = v894 | v887;\nL_FFFFFFFF:\n\tv1094 = v562;\nL_FFFFFFFF:\n\tv922 = v566;\nL_FFFFFFFF:\n\tv189 = v562;\n\tif (v895) goto L_023A;\nL_01DD:\n\tv944 = v513.height - v922;\n\tv946 = v944 == v861;\n\tv947 = v944 < v861;\n\tv948 = ~v947;\n\tv953 = ~v948;\n\tv954 = v953 | v946;\n\tif (v954) goto L_03A3;\n\tv1032 = v567.height - v770.w;\n\tv1033 = v1032 - v770.y;\n\tv1034 = v513.height - v861;\n\tv1037 = v854 == v1034;\nL_FFFFFFFF:\n\tv1133 = 0;\n\tif (v1037) goto L_021A;\n\tv1117 = v922 - v854;\n\tv1118 = v1034 - v854;\n\tv1119 = v1117 / v1118;\n\tv1121 = v1119 < 1f;\n\tv1122 = v1119 == 1f;\n\tv1125 = v1119 == v1119;\n\tv1126 = 1f == 1f;\n\tv1127 = v1125 & v1126;\n\tv1128 = ~v1127;\n\tv1129 = v1121 == v1128;\n\tv1130 = ~v1122;\n\tv1131 = v1129 & v1130;\n\tv1132 = ~v1131;\n\tif (v1132) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1137 = 1f;\n\tgoto L_020D;\nL_FFFFFFFF:\n\tv1137 = v1119;\nL_FFFFFFFF:\n\tv1133 = 0;\n\tgoto L_021A;\nL_FFFFFFFF:\n\tv1133 = v1137;\nL_FFFFFFFF:\n\tv1218 = 0;\n\tgoto L_0226;\nL_FFFFFFFF:\n\tv1218 = v1133;\nL_022A:\n\tv912 = v513.width - v567.width;\n\tv925 = v562 - v912;\nL_023A:\n\tv971 = *([B78D6D6]) & 1;\n\tv972 = v971 == 0;\nL_FFFFFFFF:\n\tv186 = v566;\nL_FFFFFFFF:\n\tv1093 = v566;\nL_FFFFFFFF:\n\tv1094 = v189;\n\tif (v972) goto L_03AF;\nL_FFFFFFFF:\n\tv1192 = this.m_OverrideSprite;\n\tgoto L_0244;\nL_0244:\n\tv1203 = UnityEngine.Object::op_Inequality(v1192, 0);\n\tv644 = v1203 == 0;\n\tv614 = ~v644;\n\tv573 = ~v614;\n\tif (v573) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv675 = v97;\n\tgoto L_0256;\nL_FFFFFFFF:\n\tv675 = v268;\n\tv1223 = UnityEngine.Sprite::get_textureRect(*([v675 @ X8_v31]));\n\tv1226 = v189 / v1223.width;\n\tv1228 = v1226 < 1f;\n\tv1229 = v1226 == 1f;\n\tv1232 = v1226 == v1226;\n\tv1233 = 1f == 1f;\n\tv1234 = v1232 & v1233;\n\tv1235 = ~v1234;\n\tv1236 = v1228 == v1235;\n\tv606 = ~v1229;\n\tv1237 = v1236 & v606;\n\tv1238 = ~v1237;\n\tif (v1238) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv689 = 1f;\n\tgoto L_0276;\nL_FFFFFFFF:\n\tv689 = v1226;\nL_FFFFFFFF:\n\tv167 = 0;\n\tgoto L_0287;\nL_FFFFFFFF:\n\tv167 = v689;\nL_FFFFFFFF:\n\tv672 = v97;\n\tgoto L_02AB;\nL_FFFFFFFF:\n\tv672 = v268;\n\tv654 = UnityEngine.Sprite::get_texture(*([v672 @ X8_v35]));\n\tv664 = v654 == 0;\n\tif (v664) goto L_042E;\n\tv1276 = v186 / v1223.height;\n\tv1277 = UnityEngine.Texture::get_width(v654);\n\tv1279 = v1276 < 1f;\n\tv1280 = v1276 == 1f;\n\tv1283 = v1276 == v1276;\n\tv1284 = 1f == 1f;\n\tv1285 = v1283 & v1284;\n\tv1286 = ~v1285;\n\tv1287 = v1279 == v1286;\n\tv607 = ~v1280;\n\tv1288 = v1287 & v607;\n\tv1289 = ~v1288;\n\tif (v1289) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv565 = 1f;\n\tgoto L_02C9;\nL_FFFFFFFF:\n\tv565 = v1276;\nL_FFFFFFFF:\n\tv176 = 0;\n\tgoto L_02DA;\nL_FFFFFFFF:\n\tv176 = v565;\nL_FFFFFFFF:\n\tv673 = v97;\n\tgoto L_02FE;\nL_FFFFFFFF:\n\tv673 = v268;\n\tv655 = UnityEngine.Sprite::get_texture(*([v673 @ X8_v40]));\n\tv264 = v655 == 0;\n\tif (v264) goto L_042E;\n\tv1324 = v1223.width + v1223;\n\tv1325 = v1324 - v1223;\n\tv1326 = v1223.height + v1223.y;\n\tv1327 = v1325 * v167;\n\tv1328 = v1326 - v1223.y;\n\tv1329 = v1223 + v1327;\n\tv276 = v1328 * v176;\n\tv270 = v1329 / v1277;\n\tv1330 = v1223.y + v276;\n\tv261 = UnityEngine.Texture::get_height(v655);\n\tv272 = v1330 / v261;\n\tv1341 = this.fillDirection > 1;\n\tif (v1341) goto L_0343;\n\tv263 = this.fillDirection == 0;\n\tif (v263) goto L_03BC;\n\tv1356 = this.fillDirection != 1;\n\tif (v1356) goto L_0367;\n\tv277 = 1f - v270;\n\tv257 = v277 < this.fillAmount;\n\tv252 = v277 == this.fillAmount;\n\tv1374 = v277 == v277;\n\tv237 = this.fillAmount == this.fillAmount;\n\tv242 = v1374 & v237;\n\tv232 = ~v242;\n\tv1375 = v257 == v232;\n\tv222 = ~v252;\n\tv227 = v1375 & v222;\n\tif (v227) goto L_FFFFFFFF;\n\tgoto L_0367;\nL_0343:\n\tv1346 = this.fillDirection == 2;\n\tif (v1346) goto L_03DE;\n\tv1368 = this.fillDirection != 3;\n\tif (v1368) goto L_0367;\n\tv278 = 1f - v272;\n\tv258 = v278 < this.fillAmount;\n\tv253 = v278 == this.fillAmount;\n\tv1392 = v278 == v278;\n\tv238 = this.fillAmount == this.fillAmount;\n\tv243 = v1392 & v238;\n\tv233 = ~v243;\n\tv1393 = v258 == v233;\n\tv223 = ~v253;\n\tv228 = v1393 & v223;\n\tif (v228) goto L_FFFFFFFF;\nL_0367:\n\tgoto L_0372;\nL_0377:\n\tv1407 = UnityEngine.Object::op_Inequality(this.m_OverrideSprite, 0);\n\tv714 = v1407 == 0;\n\tv709 = ~v714;\n\tv308 = ~v709;\n\tif (v308) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv346 = v97;\n\tgoto L_0389;\nL_FFFFFFFF:\n\tv346 = v268;\n\tv1412 = UnityEngine.Sprite::get_texture(*([v346 @ X8_v46]));\n\tv343 = v1412 == 0;\n\tif (v343) goto L_03ED;\n\tv1415 = UnityEngine.Texture2D::GetPixelBilinear(v1412, v270, v272);\n\tv337 = v1415.a < this.alphaHitTestMinimumThreshold;\n\tv1417 = v1415.a == v1415.a;\n\tv329 = this.alphaHitTestMinimumThreshold == this.alphaHitTestMinimumThreshold;\n\tv331 = v1417 & v329;\n\tv327 = ~v331;\n\tv325 = v337 == v327;\nL_FFFFFFFF:\n\treturnVal1 = v325;\n\tgoto L_03DC;\nL_03A3:\n\tv1046 = v513.height - v567.height;\n\tv1061 = v922 - v1046;\nL_03AF:\n\t*([B78D6D6]) = 1;\nL_FFFFFFFF:\n\tv186 = v1093;\nL_FFFFFFFF:\n\tv189 = v1094;\nL_FFFFFFFF:\n\tv1192 = this.m_OverrideSprite;\n\tgoto L_02\n// ... truncated")]
	bool ICanvasRaycastFilter.IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
	{
		global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::IsRaycastLocationValid");
		return default;
	}

	[Token(Token = "0x600006E")]
	[Address(RVA = "0x3C657FC", Offset = "0x3C657FC", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
	}

	[Token(Token = "0x600006F")]
	[Address(RVA = "0x3C65800", Offset = "0x3C65800", Length = "0x24")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.fillAmount < 1f;\n\tv4 = this.fillAmount == 1f;\n\tv7 = this.fillAmount == this.fillAmount;\n\tv8 = 1f == 1f;\n\tv9 = v7 & v8;\n\tv10 = ~v9;\n\tv11 = v3 == v10;\n\tv12 = ~v4;\n\tv13 = v11 & v12;\n\tv14 = ~v13;\n\tif (v14) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv17 = 1f;\n\tgoto L_0013;\nL_FFFFFFFF:\n\tv17 = this.fillAmount;\nL_FFFFFFFF:\n\tv28 = 0;\n\tgoto L_0020;\nL_FFFFFFFF:\n\tv28 = v17;\nL_0013:\n\tv18 = this.fillAmount < 0;\n\tv25 = ~v18;\n\tif (v25) goto L_FFFFFFFF;\nL_0020:\n\tthis.fillAmount = v28;\n\treturn;\n")]
	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
		bool flag = fillAmount < 1f;
		bool flag2 = fillAmount == 1f;
		bool flag3 = fillAmount == fillAmount;
		bool flag4 = 1f == 1f;
		bool flag5 = flag3 && flag4;
		bool flag6 = !flag5;
		bool flag7 = flag == flag6;
		bool flag8 = !flag2;
		float num = ((!(flag7 && flag8)) ? fillAmount : 1f);
		float num2 = ((!(fillAmount < 0f)) ? num : 0f);
		m_FillAmount = num2;
	}

	[Token(Token = "0x6000070")]
	[Address(RVA = "0x3C62428", Offset = "0x3C62428", Length = "0x320")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = 0xB78D000;\n\tv22 = *([B78D6E0]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_005A;\n\tv83 = 0xB292000 + 0x5A0;\n\tv28 = *([B78D6D6]) & 1;\n\tv29 = v28 == 0;\nL_FFFFFFFF:\n\tv66 = v83;\n\tif (v29) goto L_0067;\nL_0018:\n\tv78 = this + 0xF0;\nL_FFFFFFFF:\n\tv91 = this.m_OverrideSprite;\n\tgoto L_0021;\nL_0021:\n\tv97 = UnityEngine.Object::op_Inequality(v91, 0);\n\tv109 = v97 == 0;\n\tv116 = ~v109;\n\tv117 = ~v116;\n\tif (v117) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv125 = 0xF0;\n\tgoto L_0035;\nL_FFFFFFFF:\n\tv125 = 0xD8;\n\tv137 = UnityEngine.Object::op_Inequality(*([this @ X0 (SlicedFilledImage)+v125 @ X8_v10 (System.Int32)]), 0);\n\tv139 = ~v137;\n\tv140 = ~v139;\n\tif (v140) goto L_007D;\nL_0049:\n\treturn;\nL_005A:\n\t*([v20 @ X20_v1+6E0]) = 1;\n\tv83 = 0xB292000 + 0x5A0;\n\tv132 = *([B78D6D6]) & 1;\n\tv133 = v132 == 0;\n\tv55 = ~v133;\nL_FFFFFFFF:\n\tv66 = v83;\n\tif (v55) goto L_0018;\nL_0067:\n\t*([B78D6D6]) = 1;\n\tv78 = this + 0xF0;\nL_FFFFFFFF:\n\tv83 = v66;\nL_FFFFFFFF:\n\tv91 = this.m_OverrideSprite;\n\tgoto L_0021;\nL_0076:\n\tv144 = UnityEngine.Object::op_Inequality(*([this @ X0 (SlicedFilledImage)+v125 @ X8_v10 (System.Int32)]), 0);\n\tv179 = ~v144;\n\tif (v179) goto L_0049;\nL_007D:\n\tgoto L_0083;\nL_008E:\n\tv284 = UnityEngine.Object::op_Inequality(*([v78 @ X22_v4]), 0);\n\tv160 = v284 == 0;\n\tv148 = ~v160;\n\tv146 = ~v148;\n\tif (v146) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv288 = v78;\n\tgoto L_00A3;\nL_FFFFFFFF:\n\tv288 = v177;\nL_00A3:\n\tv292 = UnityEngine.Sprite::get_texture(*([v288 @ X8_v15]));\n\tv183 = *([v83 @ X21_v5 (System.Int32)]);\n\tv316 = *([v183 @ X8_v17+E4]) == 0;\n\tif (v316) goto L_00B4;\n\tv174 = UnityEngine.Object::op_Equality(v292, 0);\n\tv180 = ~v174;\n\tif (v180) goto L_0049;\n\tgoto L_00BC;\nL_00B4:\n\tv175 = UnityEngine.Object::op_Equality(v292, 0);\n\tv181 = ~v175;\n\tif (v181) goto L_0049;\nL_00BC:\n\tgoto L_00C0;\nL_00C0:\n\tv332 = v329.s_Initialized == 0;\n\tif (v332) goto L_00D6;\n\tgoto L_00C6;\nL_00C6:\n\t;\n\tv363 = v310.m_TrackedTexturelessImages == 0;\n\tv308 = ~v363;\n\tif (v308) goto L_00F9;\n\tgoto L_0124;\nL_00D6:\n\tv348 = new System.Action`1<UnityEngine.U2D.SpriteAtlas>();\n\tSystem.Action`1<UnityEngine.U2D.SpriteAtlas>::.ctor(v348, 0, Il2CppMethodInfo);\n\tUnityEngine.U2D.SpriteAtlasManager::add_atlasRegistered(v348);\n\tgoto L_00EA;\nL_00F9:\n\t;\n\tgoto L_0117;\nL_0117:\n\tSystem.Collections.Generic.List`1<SlicedFilledImage>::Add(v310.m_TrackedTexturelessImages, this);\n\tthis.m_Tracked = 1;\n\treturn;\nL_0124:\n\tthrow System.NullReferenceException;\nL_0035:\n\tv127 = *([v83 @ X21_v5 (System.Int32)]);\n\tv129 = *([v127 @ X0_v26+E4]) == 0;\n\tif (v129) goto L_0076;\nL_0083:\n\tv177 = this + 0xD8;\n\tgoto L_008E;\nL_00EA:\n\tv397.s_Initialized = 1;\n\tgoto L_00C6;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void TrackImage()
	{
		global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::TrackImage");
	}

	[Token(Token = "0x6000071")]
	[Address(RVA = "0x3C63494", Offset = "0x3C63494", Length = "0xAC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001C;\nL_001C:\n\tv69 = System.Collections.Generic.List`1<SlicedFilledImage>::Remove(v49.m_TrackedTexturelessImages, this);\n\tthis.m_Tracked = 0;\n\treturn;\n")]
	private void UnTrackImage()
	{
		bool flag = m_TrackedTexturelessImages.Remove(this);
		m_Tracked = false;
	}

	[Token(Token = "0x6000072")]
	[Address(RVA = "0x3C65824", Offset = "0x3C65824", Length = "0x264")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tgoto L_001B;\nL_001B:\n\tv185 = v61.m_TrackedTexturelessImages;\n\tv63 = v61.m_TrackedTexturelessImages == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0039;\n\tgoto L_00E7;\nL_0039:\n\tv190 = v185.Count;\n\tv82 = v185.Count < 1;\n\tv88 = v185.Count - 1;\n\tif (v82) goto L_00BB;\n\tv194 = spriteAtlas == 0;\n\tif (v194) goto L_00BF;\n\tgoto L_0060;\nL_005A:\n\tv205 = v190 <= 0;\n\tif (v205) goto L_00BB;\nL_0060:\n\tgoto L_0067;\nL_0067:\n\tv190 = v190 - 1;\n\tv169 = System.Collections.Generic.List`1<SlicedFilledImage>::get_Item(v183.m_TrackedTexturelessImages, v190);\n\tgoto L_007C;\nL_0081:\n\tv335 = UnityEngine.Object::op_Inequality(v169.m_OverrideSprite, 0);\n\tv154 = v335 == 0;\n\tv124 = ~v154;\n\tv105 = ~v124;\n\tif (v105) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv339 = 0xF0;\n\tgoto L_0095;\nL_FFFFFFFF:\n\tv339 = 0xD8;\n\tv346 = UnityEngine.UI.Graphic::SetAllDirty(v169);\n\tgoto L_00AC;\nL_00AC:\n\tSystem.Collections.Generic.List`1<SlicedFilledImage>::RemoveAt(v186.m_TrackedTexturelessImages, v190);\n\tgoto L_005A;\nL_00BB:\n\treturn;\nL_00BF:\n\tgoto L_00CB;\nL_00CB:\n\tv171 = System.Collections.Generic.List`1<SlicedFilledImage>::get_Item(v61.m_TrackedTexturelessImages, v88);\n\tgoto L_00E1;\nL_00E6:\n\tv168 = UnityEngine.Object::op_Inequality(v171.m_OverrideSprite, 0);\nL_00E7:\n\tthrow System.NullReferenceException;\nL_007C:\n\tgoto L_0081;\nL_0095:\n\tv342 = UnityEngine.U2D.SpriteAtlas::CanBindTo(spriteAtlas, *([v169 @ X0_v22 (SlicedFilledImage)+v339 @ X8_v21 (System.Int32)]));\n\tv343 = ~v342;\n\tif (v343) goto L_005A;\nL_00E1:\n\tgoto L_00E6;\n")]
	private static void RebuildImage(SpriteAtlas spriteAtlas)
	{
		global::AssetRipperInjected.RecoveryStub.Missing("SlicedFilledImage::RebuildImage");
	}

	[Token(Token = "0x6000073")]
	[Address(RVA = "0x3C65A88", Offset = "0x3C65A88", Length = "0x144")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv77.s_UVs = v71;\n\t// 62 NewArr v84 @ X0_v12 (UnityEngine.Vector2[]), typeof(UnityEngine.Vector2[]), 4\n\tv87.s_SlicedVertices = v84;\n\t// 71 NewArr v92 @ X0_v17 (UnityEngine.Vector2[]), typeof(UnityEngine.Vector2[]), 4\n\tv95.s_SlicedUVs = v92;\n\tv99 = new System.Collections.Generic.List`1<SlicedFilledImage>();\n\tSystem.Collections.Generic.List`1<SlicedFilledImage>::.ctor(v99);\n\tv103.m_TrackedTexturelessImages = v99;\n\treturn;\nL_002D:\n\t// 45 NewArr v58 @ X0_v3 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), 4\n\tv64.s_Vertices = v58;\n\t// 53 NewArr v71 @ X0_v7 (UnityEngine.Vector2[]), typeof(UnityEngine.Vector2[]), 4\n")]
	static SlicedFilledImage()
	{
		Vector3[] array = new Vector3[4];
		s_Vertices = array;
		Vector2[] array2 = new Vector2[4];
		s_UVs = array2;
		Vector2[] array3 = new Vector2[4];
		s_SlicedVertices = array3;
		Vector2[] array4 = new Vector2[4];
		s_SlicedUVs = array4;
		List<SlicedFilledImage> trackedTexturelessImages = new List<SlicedFilledImage>();
		m_TrackedTexturelessImages = trackedTexturelessImages;
	}
}
