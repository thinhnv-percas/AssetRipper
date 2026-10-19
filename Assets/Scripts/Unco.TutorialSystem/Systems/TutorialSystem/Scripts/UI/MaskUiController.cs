using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Systems.TutorialSystem.Scripts.Data;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.CommonManagers;
using Unco.UncoButtonSystem;
using Unco.Utils;
using UnityEngine;
using UnityEngine.UI;
using _game.CoreGameKit.UiControllers;
using _game.Systems.UncoInput;

namespace Systems.TutorialSystem.Scripts.UI
{
	[Token(Token = "0x2000018")]
	public class MaskUiController : UIController
	{
		[CompilerGenerated]
		[Token(Token = "0x2000019")]
		private sealed class _003C_003Ec__DisplayClass12_0
		{
			[Token(Token = "0x4000065")]
			[FieldOffset(Offset = "0x10")]
			public HoleType holeType;

			[Token(Token = "0x4000066")]
			[FieldOffset(Offset = "0x18")]
			public MaskUiController _003C_003E4__this;

			[Token(Token = "0x4000067")]
			[FieldOffset(Offset = "0x20")]
			public Action _003C_003E9__1;

			[Token(Token = "0x6000085")]
			[Address(RVA = "0x81E1EA4", Offset = "0x81E1EA4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass12_0()
			{
			}

			internal bool _003CInitialize_003Eb__0(Pair<HoleType, Image> x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MaskUiController._003C_003Ec__DisplayClass12_0::_003CInitialize_003Eb__0");
				return default;
			}

			internal void _003CInitialize_003Eb__1()
			{
				_003C_003E4__this.ButtonClick(sendRaycast: false);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200001A")]
		private sealed class _003C_003Ec__DisplayClass13_0
		{
			[Token(Token = "0x4000068")]
			[FieldOffset(Offset = "0x10")]
			public HoleType holeType;

			[Token(Token = "0x4000069")]
			[FieldOffset(Offset = "0x18")]
			public MaskUiController _003C_003E4__this;

			[Token(Token = "0x400006A")]
			[FieldOffset(Offset = "0x20")]
			public Action _003C_003E9__1;

			[Token(Token = "0x6000088")]
			[Address(RVA = "0x81E259C", Offset = "0x81E259C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass13_0()
			{
			}

			internal bool _003CInitializeNewWithRectTransforms_003Eb__0(Pair<HoleType, Image> x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MaskUiController._003C_003Ec__DisplayClass13_0::_003CInitializeNewWithRectTransforms_003Eb__0");
				return default;
			}

			internal void _003CInitializeNewWithRectTransforms_003Eb__1()
			{
				_003C_003E4__this.Hide();
				_003C_003E4__this.ButtonClick(sendRaycast: false);
			}
		}

		[Inject(false)]
		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x48")]
		private CoroutineManager _coroutineManager;

		[SerializeField]
		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x50")]
		private Image m_backGround;

		[SerializeField]
		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0x58")]
		private UncoButton m_passButton;

		[SerializeField]
		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0x60")]
		private RectTransform m_holeParent;

		[SerializeField]
		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0x68")]
		private CanvasGroup m_canvasGroup;

		[SerializeField]
		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x70")]
		private GameObject m_collectAllText;

		[SerializeField]
		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x78")]
		private List<Pair<HoleType, Image>> m_holeList;

		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x80")]
		private readonly List<Image> _holeList;

		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x88")]
		private Action _onComplete;

		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x90")]
		private bool _isForced;

		[Token(Token = "0x1700000F")]
		public List<Image> ActiveHoles
		{
			[Token(Token = "0x6000074")]
			[Address(RVA = "0x81E1930", Offset = "0x81E1930", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ActiveHoles;\n")]
			get
			{
				return _holeList;
			}
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x81E1938", Offset = "0x81E1938", Length = "0x56C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005C;\n\tv70.<>4__this = this;\n\tv70.holeType = holeType;\n\tthis._onComplete = onComplete;\n\tthis._isForced = isForced;\n\tv228 = maskData == 0;\n\tv213 = onComplete;\n\tif (v228) goto L_0163;\n\tv229 = this.m_backGround == 0;\n\tv213 = onComplete;\n\tif (v229) goto L_0163;\n\t// -1 MakeStruct Color_arg @ V0_v5 (UnityEngine.Color), typeof(UnityEngine.Color), maskData.color (UnityEngine.Color), maskData.color.g (System.Single), maskData.color.b (System.Single), maskData.color.a (System.Single)\n\tv313 = UnityEngine.UI.Graphic::set_color(this.m_backGround, Color_arg);\n\tv223 = new System.Predicate`1<Unco.Utils.Pair`2<Systems.TutorialSystem.Scripts.UI.HoleType, UnityEngine.UI.Image>>();\n\tSystem.Predicate`1<Unco.Utils.Pair`2<Systems.TutorialSystem.Scripts.UI.HoleType, UnityEngine.UI.Image>>::.ctor(v223, v70, Il2CppMethodInfo);\n\tv230 = this.m_holeList == 0;\n\tv213 = v70;\n\tif (v230) goto L_0163;\n\tv332 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, System.Object>>::Find(this.m_holeList, v223);\n\tv231 = maskData.holeDataList == 0;\n\tv178 = config;\n\tv213 = v223;\n\tif (v231) goto L_0163;\n\tv467 = System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.Data.RectData>::GetEnumerator(maskData.holeDataList);\n\tv346 = v467._list;\n\tgoto L_00B5;\nL_00B2:\n\tSystems.TutorialSystem.Scripts.UI.MaskUiController::InitializeWorldHole(v520, v560, v467.Current);\nL_00B5:\n\tv531 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v346 @ stack_-80_v5 (System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.Data.RectData>));\n\tv365 = v531 == 0;\n\tif (v365) goto L_0105;\n\tgoto L_00C4;\nL_00C4:\n\tv560 = UnityEngine.Object::Instantiate(v223, this.m_holeParent);\n\tv609 = this.ActiveHoles;\n\tv569 = this.ActiveHoles == 0;\n\tif (v569) goto L_015B;\n\tv593 = v609._version + 1;\n\tv609._version = v593;\n\tv581 = v609._items;\n\tv594 = v609._items == 0;\n\tif (v594) goto L_015B;\n\tv508 = v609.Count;\n\tv596 = v609.Count < v581.Length;\n\tv506 = ~v596;\n\tif (v506) goto L_00E9;\n\tv599 = v609.Count + 1;\n\tv609.Count = v599;\n\tv581[v508 @ X10_v5 (System.Int32)] = v560;\n\tv583 = v560;\n\tv609 = v604;\n\tgoto L_00EB;\nL_00E9:\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.Image>::AddWithResize(this.ActiveHoles, v560);\n\tv583 = v560;\nL_00EB:\n\tv611 = v70.holeType == 0;\n\tv612 = ~v611;\n\tv520 = v609;\n\tif (v612) goto L_00FB;\n\t// -1 MakeStruct Color_arg @ V0_v9 (UnityEngine.Color), typeof(UnityEngine.Color), maskData.color (UnityEngine.Color), maskData.color.g (System.Single), maskData.color.b (System.Single), maskData.color.a (System.Single)\n\tv520 = UnityEngine.UI.Graphic::set_color(v560, Color_arg);\n\tSystems.TutorialSystem.Scripts.UI.MaskUiController::InitializeUiIdHole(v520, v560, v467.Current);\n\tgoto L_00B5;\nL_0105:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v346 @ stack_-80_v5 (System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.Data.RectData>));\n\tv259 = 0xB2A6000 + 0x858;\n\tv255 = 0xB2C1000 + 0xB28;\n\tv251 = 0xB28B000 + 0xE8;\n\tv247 = 0xB2DE000 + 0x1B8;\n\tv162 = &v346 @ stack_-80_v5 (System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.Data.RectData>);\n\tv169 = 0;\n\tv178 = config;\n\tv213 = Il2CppMethodInfo;\n\tv244 = config;\n\tv453 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(this.ActiveHoles);\n\tv379 = v453._list;\n\tv538 = v453.Current == 0;\n\tif (v538) goto L_015D;\n\tv487 = UnityEngine.Component::GetComponent /* +1 sharing this address */(v453.Current, *([v255 @ X25_v2 (System.Int32)]));\n\tv483 = v70.<>9__1;\n\tv566 = v70.<>9__1 == 0;\n\tv567 = ~v566;\n\tif (v567) goto L_0140;\n\tv572 = new *([v251 @ X26_v2 (System.Int32)])();\n\tSystem.Action::.ctor(v572, v70, *([v247 @ X27_v2 (System.Int32)]));\n\tv70.<>9__1 = v572;\n\tv483 = v572;\n\t_game.Systems.UncoInput.MaskHole::Init(v487, v483, v244);\n\tgoto L_0124;\nL_014A:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v379 @ stack_-A0_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>));\n\tSystems.TutorialSystem.Scripts.UI.MaskUiController::InitializeBackgroundClick(this);\n\treturn;\nL_015B:\n\tv585 = new System.NullReferenceException();\n\tv162 = &v346 @ stack_-80_v5 (System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.Data.RectData>);\n\tv169 = 0;\n\tv178 = config;\n\tv214 = v583;\n\tgoto L_0162;\nL_015D:\n\tv552 = new System.NullReferenceException();\n\tv162 = &v346 @ stack_-80_v5 (System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.Data.RectData>);\n\tv169 = 0;\n\tv178 = config;\n\tv214 = this.m_holeParent;\n\tgoto L_0162;\nL_015F:\n\tv586 = new System.NullReferenceException();\n\tv162 = &v379 @ stack_-A0_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>);\n\tv169 = 0;\n\tgoto L_0162;\nL_0162:\n\t// 354 Interrupt\n\tv213 = v214;\nL_0190:\n\tv259 = 0xB2A6000 + 0x858;\n\tv255 = 0xB2C1000 + 0xB28;\n\tv251 = 0xB28B000 + 0xE8;\n\tv247 = 0xB2DE000 + 0x1B8;\n\tv287 = v213 != 1;\n\tif (v287) goto L_01B1;\n\tv291 = 0x8BF5BC4(v260, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv315 = 0x8BF5BF4(v291, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v162);\n\tv301 = *([v291 @ X0_v30]) == 0;\n\tv169 = *([v291 @ X0_v30]);\n\tv213 = Il2CppMethodInfo;\n\tv244 = v178;\n\tif (v301) goto L_0110;\n\tv299 = new System.OutOfMemoryException();\n\tv169 = *([v291 @ X0_v30]);\n\tv260 = v299;\nL_01B1:\n\tv306 = 0x3968ED0(&v169 @ stack_-B8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv317 = 0x8BF0368(v260, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv323 = 0x7C03E68(v317, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_005C:\n\tv70 = new Systems.TutorialSystem.Scripts.UI.MaskUiController+<>c__DisplayClass12_0();\n\tSystem.Object::.ctor(v70);\n\tv79 = v70 == 0;\n\tv213 = 0;\n\tif (v79) goto L_0163;\nL_0163:\n\tv260 = new System.NullReferenceException();\n\tgoto L_0190;\nL_00FB:\n\tv522 = isUiId == 0;\n\tif (v522) goto L_00B2;\nL_0140:\n\tv489 = v487 == 0;\n\tif (v489) goto L_015F;\nL_0124:\n\tv214 = *([v259 @ X24_v2 (System.Int32)]);\n\tv494 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v379 @ stack_-A0_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>));\n\tv425 = v494 == 0;\n\tif (v425) goto L_014A;\nL_0110:\n\tv232 = this.ActiveHoles == 0;\n\tif (v232) goto L_0163;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Initialize(MaskData maskData, bool isUiId, InputConfig config, HoleType holeType, Action onComplete, bool isForced)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MaskUiController::Initialize");
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x81E208C", Offset = "0x81E208C", Length = "0x510")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005B;\n\tv69.holeType = v389;\n\tv69.<>4__this = this;\n\tthis._onComplete = onComplete;\n\tthis._isForced = isForced;\n\tv203 = new System.Predicate`1<Unco.Utils.Pair`2<Systems.TutorialSystem.Scripts.UI.HoleType, UnityEngine.UI.Image>>();\n\tSystem.Predicate`1<Unco.Utils.Pair`2<Systems.TutorialSystem.Scripts.UI.HoleType, UnityEngine.UI.Image>>::.ctor(v203, v69, Il2CppMethodInfo);\n\tv208 = this.m_holeList == 0;\n\tv389 = 0;\n\tv196 = v69;\n\tif (v208) goto L_0148;\n\tv204 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, System.Object>>::Find(this.m_holeList, v203);\n\tv209 = targetRects == 0;\n\tv389 = 0;\n\tv196 = v203;\n\tif (v209) goto L_0148;\n\tv316 = System.Collections.Generic.List`1<UnityEngine.RectTransform>::GetEnumerator(targetRects);\n\tv331 = v316._list;\n\tgoto L_00AB;\nL_00A5:\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.Image>::Add(this.ActiveHoles, v535);\n\tv453 = this.ActiveHoles;\n\tSystems.TutorialSystem.Scripts.UI.MaskUiController::InitializeHoleFromRectTransform(v453, v535, v316.Current);\nL_00AB:\n\tv466 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v331 @ stack_-80_v5 (System.Collections.Generic.List`1<UnityEngine.RectTransform>));\n\tv345 = v466 == 0;\n\tif (v345) goto L_00ED;\n\tgoto L_00B9;\nL_00B9:\n\tv454 = UnityEngine.Object::op_Equality(v316.Current, 0);\n\tv516 = v454 == 0;\n\tv457 = ~v516;\n\tif (v457) goto L_00AB;\n\tgoto L_00C8;\nL_00C8:\n\tv535 = UnityEngine.Object::Instantiate(v203, this.m_holeParent);\n\tv551 = this.ActiveHoles;\n\tv552 = this.ActiveHoles == 0;\n\tif (v552) goto L_0142;\n\tv556 = v551._version + 1;\n\tv551._version = v556;\n\tv456 = v551._items == 0;\n\tif (v456) goto L_0142;\n\tgoto L_00A5;\nL_00ED:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v331 @ stack_-80_v5 (System.Collections.Generic.List`1<UnityEngine.RectTransform>));\n\tv224 = 0xB2C1000 + 0xB28;\n\tv217 = 0xB28B000 + 0xE8;\n\tv195 = 0xB2DE000 + 0x1C8;\n\tv172 = &v331 @ stack_-80_v5 (System.Collections.Generic.List`1<UnityEngine.RectTransform>);\n\tv179 = 0;\n\tv389 = 0;\n\tv200 = Il2CppMethodInfo;\n\tv431 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(this.ActiveHoles);\n\tv357 = v431._list;\n\tv509 = v431.Current == 0;\n\tif (v509) goto L_0144;\n\tv542 = *([v224 @ X25_v2 (System.Int32)]);\n\tv480 = UnityEngine.Component::GetComponent /* +1 sharing this address */(v431.Current, *([v224 @ X25_v2 (System.Int32)]));\n\tv484 = v69.<>9__1;\n\tv528 = v69.<>9__1 == 0;\n\tv529 = ~v528;\n\tv475 = v389;\n\tif (v529) goto L_012B;\n\tv538 = new *([v217 @ X26_v2 (System.Int32)])();\n\tSystem.Action::.ctor(v538, v69, *([v195 @ X27_v1 (System.Int32)]));\n\tv69.<>9__1 = v538;\n\tv475 = 0;\n\tv542 = v538;\n\tv484 = v538;\nL_012B:\n\t_game.Systems.UncoInput.MaskHole::Init(v480, v484, config);\n\tv389 = v475;\n\tgoto L_010B;\nL_0131:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v357 @ stack_-A0_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>));\n\tSystems.TutorialSystem.Scripts.UI.MaskUiController::InitializeBackgroundClick(this);\n\treturn;\nL_0142:\n\tv548 = new System.NullReferenceException();\n\tv172 = &v357 @ stack_-A0_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>);\n\tv179 = 0;\n\tv389 = v475;\n\tv197 = v542;\n\tgoto L_0147;\nL_0144:\n\tv519 = new System.NullReferenceException();\n\tv172 = &v331 @ stack_-80_v5 (System.Collections.Generic.List`1<UnityEngine.RectTransform>);\n\tv179 = 0;\n\tv389 = 0;\n\tv197 = this.m_holeParent;\n\tgoto L_0147;\nL_0147:\n\t// 327 Interrupt\n\tv196 = v197;\nL_017C:\n\t;\n\tv224 = 0xB2C1000 + 0xB28;\n\tv217 = 0xB28B000 + 0xE8;\n\tv195 = 0xB2DE000 + 0x1C8;\n\tv262 = v196 != 1;\n\tif (v262) goto L_0194;\n\tv266 = 0x8BF5BC4(v233, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv285 = 0x8BF5BF4(v266, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v172);\n\tv274 = *([v266 @ X0_v30]) == 0;\n\tv179 = *([v266 @ X0_v30]);\n\tv200 = Il2CppMethodInfo;\n\tif (v274) goto L_00F7;\n\tv272 = new System.OutOfMemoryException();\n\tv179 = *([v266 @ X0_v30]);\n\tv233 = v272;\nL_0194:\n\tv281 = 0x3177294(&v179 @ stack_-B8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv287 = 0x8BF0368(v233, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv295 = 0x7C03E68(v287, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_005B:\n\tv69 = new Systems.TutorialSystem.Scripts.UI.MaskUiController+<>c__DisplayClass13_0();\n\tSystem.Object::.ctor(v69);\n\tv78 = v69 == 0;\n\tv196 = 0;\n\tif (v78) goto L_0148;\nL_0148:\n\tv233 = new System.NullReferenceException();\n\tgoto L_017C;\nL_010B:\n\t;\n\tv489 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v357 @ stack_-A0_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>));\n\tv399 = v489 == 0;\n\tif (v399) goto L_0131;\nL_00F7:\n\tv210 = this.ActiveHoles == 0;\n\tv196 = v200;\n\tif (v210) goto L_0148;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void InitializeNewWithRectTransforms(List<RectTransform> targetRects, InputConfig config, HoleType holeType, Action onComplete, bool isForced = true)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MaskUiController::InitializeNewWithRectTransforms");
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x81E25A4", Offset = "0x81E25A4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = UnityEngine.UI.Graphic::get_rectTransform(hole);\n\tv25 = UnityEngine.Transform::get_position(sourceRect);\n\tUnityEngine.Transform::set_position(v16, v25);\n\tv60 = UnityEngine.RectTransform::get_sizeDelta(sourceRect);\n\tUnityEngine.RectTransform::set_sizeDelta(v16, v60);\n\treturn;\n")]
		private void InitializeHoleFromRectTransform(Graphic hole, RectTransform sourceRect)
		{
			RectTransform rectTransform = hole.rectTransform;
			Vector3 position = sourceRect.position;
			rectTransform.position = position;
			Vector2 sizeDelta = sourceRect.sizeDelta;
			rectTransform.sizeDelta = sizeDelta;
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x81E1F10", Offset = "0x81E1F10", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = UnityEngine.UI.Graphic::get_rectTransform(hole);\n\t// 23 MakeStruct v34 @ AGG81E1F4C_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), rectData.m_Position (UnityEngine.Vector3), rectData.m_Position.y (System.Single), rectData.m_Position.z (System.Single)\n\tUnityEngine.RectTransform::set_anchoredPosition3D(v21, v34);\n\tv31 = rectData.m_AnchorData;\n\tv51 = UnityEngine.UI.Graphic::get_rectTransform(hole);\n\t// 37 MakeStruct v27 @ AGG81E1F74_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v31.m_Min (UnityEngine.Vector2), v31.m_Min.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMin(v51, v27);\n\t// 43 MakeStruct v24 @ AGG81E1F84_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v31.m_Max (UnityEngine.Vector2), v31.m_Max.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMax(v51, v24);\n\tv52 = UnityEngine.UI.Graphic::get_rectTransform(hole);\n\t// 60 MakeStruct v73 @ AGG81E1FAC_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), rectData.m_SizeDelta (UnityEngine.Vector2), rectData.m_SizeDelta.y (System.Single)\n\tUnityEngine.RectTransform::set_sizeDelta(v52, v73);\n\treturn;\n")]
		private void InitializeWorldHole(Graphic hole, RectData rectData)
		{
			RectTransform rectTransform = hole.rectTransform;
			Vector3 anchoredPosition3D = default(Vector3);
			anchoredPosition3D.x = rectData.m_Position.x;
			anchoredPosition3D.y = rectData.m_Position.y;
			anchoredPosition3D.z = rectData.m_Position.z;
			rectTransform.anchoredPosition3D = anchoredPosition3D;
			AnchorData anchorData = rectData.m_AnchorData;
			RectTransform rectTransform2 = hole.rectTransform;
			Vector2 anchorMin = default(Vector2);
			anchorMin.x = anchorData.m_Min.x;
			anchorMin.y = anchorData.m_Min.y;
			rectTransform2.anchorMin = anchorMin;
			Vector2 anchorMax = default(Vector2);
			anchorMax.x = anchorData.m_Max.x;
			anchorMax.y = anchorData.m_Max.y;
			rectTransform2.anchorMax = anchorMax;
			RectTransform rectTransform3 = hole.rectTransform;
			Vector2 sizeDelta = default(Vector2);
			sizeDelta.x = rectData.m_SizeDelta.x;
			sizeDelta.y = rectData.m_SizeDelta.y;
			rectTransform3.sizeDelta = sizeDelta;
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x81E1EAC", Offset = "0x81E1EAC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = UnityEngine.UI.Graphic::get_rectTransform(hole);\n\t// 21 MakeStruct v20 @ AGG81E1EE4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), rectData.m_Position (UnityEngine.Vector3), rectData.m_Position.y (System.Single), rectData.m_Position.z (System.Single)\n\tUnityEngine.Transform::set_position(v17, v20);\n\tv34 = UnityEngine.UI.Graphic::get_rectTransform(hole);\n\t// 36 MakeStruct v53 @ AGG81E1F08_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), rectData.m_SizeDelta (UnityEngine.Vector2), rectData.m_SizeDelta.y (System.Single)\n\tUnityEngine.RectTransform::set_sizeDelta(v34, v53);\n\treturn;\n")]
		private void InitializeUiIdHole(Graphic hole, RectData rectData)
		{
			RectTransform rectTransform = hole.rectTransform;
			Vector3 position = default(Vector3);
			position.x = rectData.m_Position.x;
			position.y = rectData.m_Position.y;
			position.z = rectData.m_Position.z;
			rectTransform.position = position;
			RectTransform rectTransform2 = hole.rectTransform;
			Vector2 sizeDelta = default(Vector2);
			sizeDelta.x = rectData.m_SizeDelta.x;
			sizeDelta.y = rectData.m_SizeDelta.y;
			rectTransform2.sizeDelta = sizeDelta;
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x81E260C", Offset = "0x81E260C", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv74 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(this.ActiveHoles);\n\tv103 = v74._list;\n\tv176 = v74.Current == 0;\n\tif (v176) goto L_0073;\n\tv185 = UnityEngine.Component::GetComponent(v74.Current);\n\tv241 = new System.Action();\n\tSystem.Action::.ctor(v241, this, Il2CppMethodInfo);\n\tv137 = v185 == 0;\n\tif (v137) goto L_0075;\n\tUnco.UncoButtonSystem.UncoButton::AddListener(v185, v241, 1, 1);\n\tgoto L_004A;\nL_0066:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v103 @ stack_-68_v4 (System.Collections.Generic.List`1<UnityEngine.UI.Image>));\nL_0072:\n\treturn;\nL_0073:\n\tv186 = new System.NullReferenceException();\n\tgoto L_0076;\nL_0075:\n\tthrow v241;\nL_0076:\n\t// 118 Interrupt\n\tv88 = 0;\nL_0085:\n\tv152 = Il2CppMethodInfo != 1;\n\tif (v152) goto L_0094;\n\tv158 = 0x8BF5BC4(v118, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv179 = 0x8BF5BF4(v158, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v103 @ stack_-68_v4 (System.Collections.Generic.List`1<UnityEngine.UI.Image>));\n\tv166 = *([v158 @ X0_v11]) == 0;\n\tif (v166) goto L_0072;\n\tv164 = new System.OutOfMemoryException();\n\tv88 = *([v158 @ X0_v11]);\n\tv118 = v164;\nL_0094:\n\tv171 = 0x3968F10(&v88 @ stack_-78 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv181 = 0x8BF0368(v118, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv239 = 0x7C03E68(v181, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_002A:\n\tv103 = 0;\n\tv55 = this.ActiveHoles == 0;\n\tif (v55) goto L_0077;\nL_004A:\n\tv142 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v103 @ stack_-68_v4 (System.Collections.Generic.List`1<UnityEngine.UI.Image>));\n\tv157 = v142 == 0;\n\tif (v157) goto L_0066;\nL_0077:\n\tv118 = new System.NullReferenceException();\n\tgoto L_0085;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void InitializeClickActions()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MaskUiController::InitializeClickActions");
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x81E1FB4", Offset = "0x81E1FB4", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\treturn;\nL_002C:\n\tv96 = UnityEngine.Component::GetComponent(this.m_passButton);\n\tv102 = new System.Action();\n\tSystem.Action::.ctor(v102, this, Il2CppMethodInfo);\n\tUnco.UncoButtonSystem.UncoButton::AddListener(v96, v102, 1, 1);\n\treturn;\nL_001C:\n\tv45 = this._isForced == 0;\n\tif (v45) goto L_002C;\n")]
		private void InitializeBackgroundClick()
		{
			if (_isForced)
			{
				return;
			}
			UncoButton component = m_passButton.GetComponent<UncoButton>();
			Action clickAction = delegate
			{
				Hide();
				ClearListeners();
				if (_onComplete != null)
				{
					_onComplete();
				}
				_onComplete = null;
			};
			component.AddListener(clickAction);
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x81E27DC", Offset = "0x81E27DC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = UnityEngine.GameObject::get_gameObject(this.m_collectAllText);\n\tUnityEngine.GameObject::SetActive(v10, 1);\n\treturn;\n")]
		public void ShowCollect()
		{
			GameObject gameObject = m_collectAllText.gameObject;
			gameObject.SetActive(value: true);
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x81E280C", Offset = "0x81E280C", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv54 = UnityEngine.Camera::get_main();\n\tgoto L_002A;\nL_002A:\n\tv65 = UnityEngine.Object::op_Equality(v54, 0);\n\tv68 = v65 == 0;\n\tif (v68) goto L_0041;\nL_0035:\n\treturn;\nL_0041:\n\tv138 = ~sendRaycast;\n\tif (v138) goto L_0067;\n\tv165 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::get_Item(this.ActiveHoles, 0);\n\tv177 = UnityEngine.Component::GetComponent(v165);\n\tv172 = UnityEngine.Camera::get_main();\n\tv168 = UnityEngine.Transform::get_position(v177);\n\tv147 = UnityEngine.Camera::WorldToScreenPoint(v172, v168);\n\tSystems.TutorialSystem.Scripts.UI.MaskUiController::SendRaycast(this, v147);\nL_0067:\n\t;\n\tv161 = Systems.TutorialSystem.Scripts.UI.MaskUiController::Hide(this);\n\tSystems.TutorialSystem.Scripts.UI.MaskUiController::ClearListeners(this);\n\treturn;\nL_001D:\n\tv46 = this._isForced == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_0035;\n")]
		private void ButtonClick(bool sendRaycast = true)
		{
			if (_isForced)
			{
				return;
			}
			Camera main = Camera.main;
			if (!(main == null))
			{
				if (sendRaycast)
				{
					Component component = ActiveHoles[0];
					RectTransform component2 = component.GetComponent<RectTransform>();
					Camera main2 = Camera.main;
					Vector3 position = component2.position;
					Vector3 position2 = main2.WorldToScreenPoint(position);
					SendRaycast(position2);
				}
				Hide();
				ClearListeners();
			}
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x81E2A00", Offset = "0x81E2A00", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv130 = 0xB2A6000 + 0x850;\n\tv65 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(this.ActiveHoles);\n\tv98 = v65._list;\n\tv201 = v65.Current == 0;\n\tif (v201) goto L_0073;\n\tv209 = UnityEngine.Component::GetComponent(v65.Current);\n\tUnco.UncoButtonSystem.UncoButton::RemoveAllListeners(v209);\n\tv262 = UnityEngine.Component::GetComponent(v65.Current);\n\tv263 = v262 == 0;\n\tif (v263) goto L_0071;\n\tv264 = v262.m_btn;\n\tv165 = v262.m_btn == 0;\n\tif (v165) goto L_0071;\n\tv264._onClick = 0;\n\tgoto L_0044;\nL_0061:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v98 @ stack_-60_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>));\n\tv116 = &v98 @ stack_-60_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>);\n\tv64 = 0;\n\tv127 = Il2CppMethodInfo;\nL_0063:\n\tv143 = this.m_passButton == 0;\n\tif (v143) goto L_0077;\n\tUnco.UncoButtonSystem.UncoButton::RemoveAllListeners(this.m_passButton);\n\treturn;\nL_0071:\n\tv220 = new System.NullReferenceException();\n\tv127 = Il2CppMethodInfo;\n\tgoto L_0076;\nL_0073:\n\tv210 = new System.NullReferenceException();\n\tv127 = Il2CppMethodInfo;\n\tgoto L_0076;\nL_0076:\n\t// 118 Interrupt\n\tv116 = &v98 @ stack_-60_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>);\n\tv64 = 0;\nL_0086:\n\tv179 = v127 != 1;\n\tif (v179) goto L_0095;\n\tv185 = 0x8BF5BC4(v150, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv204 = 0x8BF5BF4(v185, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv127 = *([v130 @ X21_v1 (System.Int32)]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v116);\n\tv193 = *([v185 @ X0_v11]) == 0;\n\tv64 = *([v185 @ X0_v11]);\n\tif (v193) goto L_0063;\n\tv191 = new System.OutOfMemoryException();\n\tv64 = *([v185 @ X0_v11]);\n\tv150 = v191;\nL_0095:\n\tv198 = 0x3968F10(&v64 @ stack_-78 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv206 = 0x8BF0368(v150, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv214 = 0x7C03E68(v206, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0026:\n\tv48 = this.ActiveHoles == 0;\n\tif (v48) goto L_0077;\nL_0044:\n\tv169 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v98 @ stack_-60_v3 (System.Collections.Generic.List`1<UnityEngine.UI.Image>));\n\tv184 = v169 == 0;\n\tif (v184) goto L_0061;\nL_0077:\n\tv150 = new System.NullReferenceException();\n\tgoto L_0086;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void ClearListeners()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MaskUiController::ClearListeners");
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x81E2954", Offset = "0x81E2954", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tUnityEngine.CanvasGroup::set_blocksRaycasts(this.m_canvasGroup, 0);\n\tv63 = new System.Action();\n\tSystem.Action::.ctor(v63, this, Il2CppMethodInfo);\n\tUnco.CommonManagers.CoroutineManager::InvokeEndOfFrame(this._coroutineManager, v63, 1);\n\treturn;\n")]
		private void SendRaycast(Vector3 position)
		{
			m_canvasGroup.blocksRaycasts = false;
			Action action = OpenRaycast;
			_coroutineManager.InvokeEndOfFrame(action);
			[Token(Token = "0x6000084")]
			[Address(RVA = "0x81E2D28", Offset = "0x81E2D28", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.m_canvasGroup, 0);\n\tv63 = ~v55;\n\tif (v63) goto L_0043;\n\tUnityEngine.CanvasGroup::set_blocksRaycasts(this.m_canvasGroup, 1);\n\treturn;\nL_0043:\n\treturn;\n")]
			void OpenRaycast()
			{
				if (m_canvasGroup != null)
				{
					m_canvasGroup.blocksRaycasts = true;
				}
			}
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x81E2BD0", Offset = "0x81E2BD0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.Image>::Clear(v38);\n\tv53 = v38.Count < 1;\n\tif (v53) goto L_0031;\nL_0031:\n\t_game.CoreGameKit.UiControllers.UIController::Hide(this);\n\treturn;\nL_0012:\n\tv38 = this.ActiveHoles;\n\tv39 = this.ActiveHoles == 0;\n\tif (v39) goto L_0031;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Hide()
		{
			List<Image> activeHoles = ActiveHoles;
			if (ActiveHoles != null)
			{
				activeHoles.Clear();
				if (activeHoles.Count < 1)
				{
				}
			}
			base.Hide();
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x81E2C40", Offset = "0x81E2C40", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\t_game.CoreGameKit.UiControllers.UIController::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<UnityEngine.UI.Image>();\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.Image>::.ctor(v48);\n\tthis.ActiveHoles = v48;\n")]
		public MaskUiController()
		{
			List<Image> holeList = new List<Image>();
			_holeList = holeList;
		}
	}
}
