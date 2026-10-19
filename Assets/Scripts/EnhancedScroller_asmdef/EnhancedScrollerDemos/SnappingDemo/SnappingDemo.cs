using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.SnappingDemo
{
	[Token(Token = "0x2000067")]
	public class SnappingDemo : MonoBehaviour
	{
		[Token(Token = "0x2000068")]
		private enum GameStateEnum
		{
			[Token(Token = "0x40001AC")]
			Initializing = 0,
			[Token(Token = "0x40001AD")]
			Playing = 1,
			[Token(Token = "0x40001AE")]
			GameOver = 2
		}

		[Token(Token = "0x4000198")]
		[FieldOffset(Offset = "0x20")]
		private SlotController[] _slotControllers;

		[Token(Token = "0x4000199")]
		[FieldOffset(Offset = "0x28")]
		private int[] _snappedDataIndices;

		[Token(Token = "0x400019A")]
		[FieldOffset(Offset = "0x30")]
		private int _credits;

		[Token(Token = "0x400019B")]
		[FieldOffset(Offset = "0x34")]
		private int _snapCount;

		[Token(Token = "0x400019C")]
		[FieldOffset(Offset = "0x38")]
		private GameStateEnum _gameState;

		[Token(Token = "0x400019D")]
		[FieldOffset(Offset = "0x3C")]
		public float minVelocity;

		[Token(Token = "0x400019E")]
		[FieldOffset(Offset = "0x40")]
		public float maxVelocity;

		[Token(Token = "0x400019F")]
		[FieldOffset(Offset = "0x44")]
		public int cherryIndex;

		[Token(Token = "0x40001A0")]
		[FieldOffset(Offset = "0x48")]
		public int sevenIndex;

		[Token(Token = "0x40001A1")]
		[FieldOffset(Offset = "0x4C")]
		public int tripleBarIndex;

		[Token(Token = "0x40001A2")]
		[FieldOffset(Offset = "0x50")]
		public int bigWinIndex;

		[Token(Token = "0x40001A3")]
		[FieldOffset(Offset = "0x54")]
		public int blankIndex;

		[Token(Token = "0x40001A4")]
		[FieldOffset(Offset = "0x58")]
		public Sprite[] slotSprites;

		[Token(Token = "0x40001A5")]
		[FieldOffset(Offset = "0x60")]
		public Button pullLeverButton;

		[Token(Token = "0x40001A6")]
		[FieldOffset(Offset = "0x68")]
		public Text creditsText;

		[Token(Token = "0x40001A7")]
		[FieldOffset(Offset = "0x70")]
		public int startingCredits;

		[Token(Token = "0x40001A8")]
		[FieldOffset(Offset = "0x78")]
		public GameObject playingPanel;

		[Token(Token = "0x40001A9")]
		[FieldOffset(Offset = "0x80")]
		public GameObject gameOverPanel;

		[Token(Token = "0x40001AA")]
		[FieldOffset(Offset = "0x88")]
		public PlayWin playWin;

		[Token(Token = "0x1700002D")]
		private int Credits
		{
			[Token(Token = "0x6000201")]
			[Address(RVA = "0x402E4D4", Offset = "0x402E4D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._credits;\n")]
			get
			{
				return _credits;
			}
			[Token(Token = "0x6000202")]
			[Address(RVA = "0x402E4DC", Offset = "0x402E4DC", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv46 = ~value;\n\tv47 = value & v46;\n\tthis._credits = v47;\n\tv49 = v47;\n\tv51 = 0xB7D5000 + 0x538;\n\tv54 = \"il2cpp_vm_object_box\"(*([v51 @ X8_v6 (System.Int32)+48]), &v49 @ stack_-34_v2 (System.Int32), methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv68 = System.String::Format(\"{0:n0}\", v54);\n\tv134 = UnityEngine.UI.Text::set_text(this.creditsText, v68);\n\tv70 = UnityEngine.Component::get_gameObject(this.pullLeverButton);\n\tv107 = this._credits < 0;\n\tv104 = this._credits == 0;\n\tv98 = this._credits ^ this._credits;\n\tv95 = this._credits & v98;\n\tv92 = v95 < 0;\n\tv136 = v107 == v92;\n\tv86 = ~v104;\n\tv89 = v136 & v86;\n\tUnityEngine.GameObject::SetActive(v70, v89);\n\treturn;\n")]
			set
			{
				int num = ~value;
				int num2 = (_credits = value & num);
				int num3 = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				string text = $"{arg:n0}";
				creditsText.text = text;
				GameObject gameObject = pullLeverButton.gameObject;
				bool flag = _credits < 0;
				bool flag2 = _credits == 0;
				int num4 = _credits ^ _credits;
				int num5 = _credits & num4;
				bool flag3 = num5 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				bool active = flag4 && flag5;
				gameObject.SetActive(active);
			}
		}

		[Token(Token = "0x1700002E")]
		private GameStateEnum GameState
		{
			[Token(Token = "0x6000203")]
			[Address(RVA = "0x402E5B4", Offset = "0x402E5B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._gameState;\n")]
			get
			{
				return _gameState;
			}
			[Token(Token = "0x6000204")]
			[Address(RVA = "0x402E5BC", Offset = "0x402E5BC", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._gameState = value;\n\tv17 = value == 2;\n\tif (v17) goto L_005D;\n\tv31 = value != 1;\n\tif (v31) goto L_006F;\n\tv34 = this._slotControllers;\n\tv63 = v34.Length;\n\tv128 = v34.Length < 1;\n\tif (v128) goto L_0045;\n\tv72 = v34 + 0x20;\n\tv55 = *([v54 @ X11_v4+28]);\n\t*([v55 @ X11_v5+3C]) = 1;\n\tv72 = v72 + 8;\n\tv164 = v63 - 1;\n\tv167 = v63 != 1;\n\tv63 = v164;\n\tif (v167) goto L_002F;\nL_0045:\n\tEnhancedScrollerDemos.SnappingDemo.SnappingDemo::set_Credits(this, this.startingCredits);\n\tUnityEngine.GameObject::SetActive(this.playingPanel, 1);\n\tUnityEngine.GameObject::SetActive(this.gameOverPanel, 0);\n\treturn;\nL_005D:\n\tUnityEngine.GameObject::SetActive(this.playingPanel, 0);\n\tUnityEngine.GameObject::SetActive(this.gameOverPanel, 1);\n\treturn;\nL_006F:\n\treturn;\nL_002F:\n\tv54 = *([v72 @ X9_v5]);\n")]
			set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SnappingDemo::set_GameState");
			}
		}

		[Token(Token = "0x6000205")]
		[Address(RVA = "0x402E698", Offset = "0x402E698", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\nL_002E:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tthis._gameState = 0;\n\tv69 = UnityEngine.Component::get_gameObject(this);\n\tv79 = UnityEngine.GameObject::GetComponentsInChildren(v69);\n\tthis._slotControllers = v79;\n\tv145 = this._slotControllers;\n\t// 70 NewArr v209 @ X0_v13 (System.Int32[]), typeof(System.Int32[]), v145.Length\n\tthis._snappedDataIndices = v209;\n\tv122 = this._slotControllers;\n\tv223 = v122.Length < 1;\n\tif (v223) goto L_008E;\n\tv93 = 0;\n\tv151 = v146.scroller;\n\tv135 = new EnhancedUI.EnhancedScroller.ScrollerSnappedDelegate();\n\tEnhancedUI.EnhancedScroller.ScrollerSnappedDelegate::.ctor(v135, this, Il2CppMethodInfo);\n\tv151.scrollerSnapped = v135;\n\tv93 = v93 + 1;\n\tv232 = v93 < v122.Length;\n\tif (v232) goto L_0063;\nL_008E:\n\treturn;\nL_002A:\n\tgoto L_002E;\nL_0063:\n\tv146 = v122[v93 @ X23_v5 (System.Int32)];\n")]
		private void Awake()
		{
			Application.targetFrameRate = 60;
			_gameState = default(GameStateEnum);
			GameObject gameObject = base.gameObject;
			SlotController[] componentsInChildren = gameObject.GetComponentsInChildren<SlotController>();
			_slotControllers = componentsInChildren;
			SlotController[] slotControllers = _slotControllers;
			int[] snappedDataIndices = new int[slotControllers.Length];
			_snappedDataIndices = snappedDataIndices;
			SlotController[] slotControllers2 = _slotControllers;
			if (slotControllers2.Length >= 1)
			{
				int num = 0;
				do
				{
					SlotController slotController = slotControllers2[num];
					EnhancedScroller scroller = slotController.scroller;
					ScrollerSnappedDelegate scrollerSnapped = ScrollerSnapped;
					scroller.scrollerSnapped = scrollerSnapped;
					num++;
				}
				while (num < slotControllers2.Length);
			}
		}

		[Token(Token = "0x6000206")]
		[Address(RVA = "0x402E824", Offset = "0x402E824", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this._slotControllers;\n\tv28 = v14.Length < 1;\n\tif (v28) goto L_0035;\n\tv37 = 0;\nL_001F:\n\tEnhancedScrollerDemos.SnappingDemo.SlotController::Reload(v14[v37 @ X21_v5 (System.Int32)], this.slotSprites);\n\tv37 = v37 + 1;\n\tv96 = v37 < v14.Length;\n\tif (v96) goto L_001F;\nL_0035:\n\treturn;\n")]
		private void Start()
		{
			SlotController[] slotControllers = _slotControllers;
			if (slotControllers.Length >= 1)
			{
				int num = 0;
				do
				{
					slotControllers[num].Reload(slotSprites);
					num++;
				}
				while (num < slotControllers.Length);
			}
		}

		[Token(Token = "0x6000207")]
		[Address(RVA = "0x402E888", Offset = "0x402E888", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this._gameState == 0;\n\tif (v2) goto L_0005;\n\treturn;\nL_0005:\n\tEnhancedScrollerDemos.SnappingDemo.SnappingDemo::set_GameState(this, 1);\n\treturn;\n")]
		private void LateUpdate()
		{
			if (_gameState == GameStateEnum.Initializing)
			{
				GameState = GameStateEnum.Playing;
			}
		}

		[Token(Token = "0x6000208")]
		[Address(RVA = "0x402E89C", Offset = "0x402E89C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._snapCount = 0;\n\tv25 = this._credits - 1;\n\tEnhancedScrollerDemos.SnappingDemo.SnappingDemo::set_Credits(this, v25);\n\tUnityEngine.UI.Selectable::set_interactable(this.pullLeverButton, 0);\n\tv81 = this._slotControllers;\n\tv117 = v81.Length < 1;\n\tif (v117) goto L_0066;\nL_FFFFFFFF:\n\tv52 = 0;\n\tv177 = -v178;\n\tv206 = v204 < 0.5f;\n\tv207 = v204 == 0.5f;\n\tv210 = v204 == v204;\n\tv211 = 0.5f == 0.5f;\n\tv212 = v210 & v211;\n\tv213 = ~v212;\n\tv214 = v206 == v213;\n\tv176 = ~v207;\n\tv215 = v214 & v176;\n\tv175 = ~v215;\n\tif (v175) goto L_FFFFFFFF;\n\tgoto L_004C;\nL_FFFFFFFF:\n\tv178 = v177;\nL_0066:\n\treturn;\nL_004C:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_LinearVelocity(v32.scroller, v178);\n\tv52 = v52 + 1;\n\tv184 = v52 < v81.Length;\n\tif (v184) goto L_002A;\nL_002A:\n\tv32 = v81[v52 @ X21_v5 (System.Int32)];\n\tv204 = UnityEngine.Random::Range(0f, 1f);\n\tv178 = UnityEngine.Random::Range(this.minVelocity, this.maxVelocity);\n")]
		public void PullLeverButton_OnClick()
		{
			_snapCount = 0;
			int credits = _credits - 1;
			Credits = credits;
			pullLeverButton.interactable = false;
			SlotController[] slotControllers = _slotControllers;
			if (slotControllers.Length < 1)
			{
				return;
			}
			int num = 0;
			do
			{
				SlotController slotController = slotControllers[num];
				float num2 = Random.Range(0f, 1f);
				float num3 = Random.Range(minVelocity, maxVelocity);
				float num4 = 0f - num3;
				bool flag = num2 < 0.5f;
				bool flag2 = num2 == 0.5f;
				bool flag3 = num2 == num2;
				bool flag4 = 0.5f == 0.5f;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag2;
				if (!(flag7 && flag8))
				{
					num3 = num4;
				}
				slotController.scroller.LinearVelocity = num3;
				num++;
			}
			while (num < slotControllers.Length);
		}

		[Token(Token = "0x6000209")]
		[Address(RVA = "0x402E96C", Offset = "0x402E96C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedScrollerDemos.SnappingDemo.SnappingDemo::set_GameState(this, 1);\n\treturn;\n")]
		public void ResetButton_OnClick()
		{
			GameState = GameStateEnum.Playing;
		}

		[Token(Token = "0x600020A")]
		[Address(RVA = "0x402E974", Offset = "0x402E974", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = this._gameState != 1;\n\tif (v21) goto L_0047;\n\tv23 = this._snapCount;\n\tv24 = this._snapCount + 1;\n\tthis._snapCount = v24;\n\tv25 = this._snappedDataIndices;\n\tv25[v23 @ X8_v3 (System.Int32)] = dataIndex;\n\tv107 = this._slotControllers;\n\tv49 = this._snapCount != v107.Length;\n\tif (v49) goto L_0040;\n\tEnhancedScrollerDemos.SnappingDemo.SnappingDemo::TallyScore(this);\n\tUnityEngine.UI.Selectable::set_interactable(this.pullLeverButton, 1);\nL_0040:\n\tv42 = this._credits == 0;\n\tif (v42) goto L_0049;\nL_0047:\n\treturn;\nL_0049:\n\tthis._gameState = 2;\n\tUnityEngine.GameObject::SetActive(this.playingPanel, 0);\n\tUnityEngine.GameObject::SetActive(this.gameOverPanel, 1);\n\treturn;\n")]
		private void ScrollerSnapped(EnhancedScroller scroller, int cellIndex, int dataIndex, EnhancedScrollerCellView cellView)
		{
			if (_gameState == GameStateEnum.Playing)
			{
				int snapCount = _snapCount;
				int snapCount2 = _snapCount + 1;
				_snapCount = snapCount2;
				int[] snappedDataIndices = _snappedDataIndices;
				snappedDataIndices[snapCount] = dataIndex;
				SlotController[] slotControllers = _slotControllers;
				if (_snapCount == slotControllers.Length)
				{
					TallyScore();
					pullLeverButton.interactable = true;
				}
				if (_credits == 0)
				{
					_gameState = GameStateEnum.GameOver;
					playingPanel.SetActive(value: false);
					gameOverPanel.SetActive(value: true);
				}
			}
		}

		[Token(Token = "0x600020B")]
		[Address(RVA = "0x402EA40", Offset = "0x402EA40", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._snapCount = 0;\n\tv11 = this._snappedDataIndices;\n\tv158 = v11[0] - this.blankIndex;\n\tv160 = v158 == 0;\n\tv165 = ~v160;\n\tv166 = ~v165;\n\tif (v166) goto L_FFFFFFFF;\n\tv169 = v11[1] - this.blankIndex;\n\tv184 = v169 == 0;\n\tgoto L_0042;\nL_FFFFFFFF:\n\tv184 = 1;\n\tv192 = v11[2] - this.blankIndex;\n\tv207 = v192 == 0;\n\tgoto L_0054;\nL_FFFFFFFF:\n\tv207 = 1;\nL_005B:\n\treturn;\nL_0065:\n\tv232 = v11[0] != v11[1];\n\tif (v232) goto L_FFFFFFFF;\n\tv235 = v11[0] - v11[2];\n\tv250 = v235 == 0;\n\tgoto L_0076;\nL_FFFFFFFF:\n\tv250 = 0;\n\tv256 = v11[0] - this.cherryIndex;\n\tv258 = v256 == 0;\n\tv263 = ~v258;\n\tv264 = ~v263;\n\tif (v264) goto L_FFFFFFFF;\n\tv278 = v11[1] - this.cherryIndex;\n\tv305 = v278 == 0;\n\tgoto L_0093;\nL_FFFFFFFF:\n\tv305 = 1;\n\tv340 = v11[2] - this.cherryIndex;\n\tv219 = v340 == 0;\n\tgoto L_00A5;\nL_FFFFFFFF:\n\tv219 = 1;\nL_FFFFFFFF:\n\tv22 = 3;\n\tgoto L_00E6;\nL_00B3:\n\tv275 = v11[0] != this.sevenIndex;\n\tif (v275) goto L_00C1;\nL_FFFFFFFF:\n\tv22 = 0x3E8;\n\tgoto L_00E6;\nL_00C1:\n\tv300 = v11[0] != this.bigWinIndex;\n\tif (v300) goto L_00CF;\nL_FFFFFFFF:\n\tv22 = 0x96;\n\tgoto L_00E6;\nL_00CF:\n\tv316 = v11[0] != this.tripleBarIndex;\n\tif (v316) goto L_00DF;\nL_FFFFFFFF:\n\tv22 = 0x46;\n\tgoto L_00E6;\nL_00DF:\n\tv315 = v11[0] != this.cherryIndex;\n\tif (v315) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv22 = 0x28;\n\tgoto L_00E6;\nL_FFFFFFFF:\n\tv22 = 0x14;\n\tEnhancedScrollerDemos.SnappingDemo.PlayWin::Play(this.playWin, v22);\n\treturn;\nL_0042:\n\tv188 = ~v184;\n\tv189 = ~v188;\n\tif (v189) goto L_FFFFFFFF;\nL_0054:\n\tv211 = ~v207;\n\tif (v211) goto L_0065;\nL_0076:\n\tif (v250) goto L_00B3;\nL_0093:\n\tv309 = ~v305;\n\tv212 = ~v309;\n\tif (v212) goto L_FFFFFFFF;\nL_00A5:\n\tv214 = ~v219;\n\tif (v214) goto L_005B;\nL_00E6:\n\tv17 = this._credits + v22;\n\tEnhancedScrollerDemos.SnappingDemo.SnappingDemo::set_Credits(this, v17);\n")]
		private void TallyScore()
		{
			_snapCount = 0;
			int[] snappedDataIndices = _snappedDataIndices;
			bool flag;
			if (snappedDataIndices[0] - blankIndex != 0)
			{
				int num = snappedDataIndices[1] - blankIndex;
				flag = num == 0;
			}
			else
			{
				flag = true;
			}
			bool flag2;
			if (!flag)
			{
				int num2 = snappedDataIndices[2] - blankIndex;
				flag2 = num2 == 0;
			}
			else
			{
				flag2 = true;
			}
			if (flag2)
			{
				return;
			}
			bool flag3;
			if (snappedDataIndices[0] == snappedDataIndices[1])
			{
				int num3 = snappedDataIndices[0] - snappedDataIndices[2];
				flag3 = num3 == 0;
			}
			else
			{
				flag3 = false;
			}
			int num4;
			if (flag3)
			{
				num4 = ((snappedDataIndices[0] == sevenIndex) ? 1000 : ((snappedDataIndices[0] == bigWinIndex) ? 150 : ((snappedDataIndices[0] == tripleBarIndex) ? 70 : ((snappedDataIndices[0] != cherryIndex) ? 20 : 40))));
			}
			else
			{
				bool flag4;
				if (snappedDataIndices[0] - cherryIndex != 0)
				{
					int num5 = snappedDataIndices[1] - cherryIndex;
					flag4 = num5 == 0;
				}
				else
				{
					flag4 = true;
				}
				bool flag5;
				if (!flag4)
				{
					int num6 = snappedDataIndices[2] - cherryIndex;
					flag5 = num6 == 0;
				}
				else
				{
					flag5 = true;
				}
				if (!flag5)
				{
					return;
				}
				num4 = 3;
			}
			int credits = _credits + num4;
			Credits = credits;
			playWin.Play(num4);
		}

		[Token(Token = "0x600020C")]
		[Address(RVA = "0x402EB40", Offset = "0x402EB40", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SnappingDemo()
		{
		}
	}
}
