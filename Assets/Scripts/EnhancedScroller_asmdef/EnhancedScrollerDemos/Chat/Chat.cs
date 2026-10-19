using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.Chat
{
	[Token(Token = "0x2000022")]
	public class Chat : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x40000D9")]
		[FieldOffset(Offset = "0x20")]
		private List<Data> _data;

		[Token(Token = "0x40000DA")]
		[FieldOffset(Offset = "0x28")]
		private float _totalCellSize;

		[Token(Token = "0x40000DB")]
		[FieldOffset(Offset = "0x2C")]
		private float _oldScrollPosition;

		[Token(Token = "0x40000DC")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScroller scroller;

		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x38")]
		public InputField myInputField;

		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x40")]
		public InputField otherInputField;

		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x48")]
		public EnhancedScrollerCellView myTextCellViewPrefab;

		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x50")]
		public EnhancedScrollerCellView otherTextCellViewPrefab;

		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0x58")]
		public EnhancedScrollerCellView spacerCellViewPrefab;

		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x60")]
		public int characterWidth;

		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x64")]
		public int characterHeight;

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x4024070", Offset = "0x4024070", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0018;\nL_0018:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv75 = this.scroller;\n\tv63 = this.scroller == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0042;\n\tgoto L_0093;\nL_0042:\n\tv75.Delegate = this;\n\tv75._reloadData = 1;\n\tv151 = new System.Collections.Generic.List`1<EnhancedScrollerDemos.Chat.Data>();\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.Chat.Data>::.ctor(v151);\n\tthis._data = v151;\n\tv142 = this._data;\n\tv134 = new EnhancedScrollerDemos.Chat.Data();\n\tSystem.Object::.ctor(v134);\n\tv134.cellType = 0;\n\tgoto L_0081;\nL_0081:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.Chat.Data>::Add(v142, v134);\n\tEnhancedScrollerDemos.Chat.Chat::ResizeScroller(this);\n\tUnityEngine.UI.InputField::ActivateInputField(this.myInputField);\n\treturn;\nL_0093:\n\tthrow System.NullReferenceException;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			EnhancedScroller enhancedScroller = scroller;
			if ((object)scroller != null)
			{
				enhancedScroller._delegate = this;
				enhancedScroller._reloadData = true;
				List<Data> data = new List<Data>();
				_data = data;
				List<Data> data2 = _data;
				Data data3 = new Data();
				data3.cellType = default(Data.CellType);
				data2.Add(data3);
				ResizeScroller();
				myInputField.ActivateInputField();
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x4024480", Offset = "0x4024480", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = UnityEngine.Input::GetKeyDown(0xD);\n\tv15 = ~v14;\n\tif (v15) goto L_003F;\n\tv16 = this.myInputField;\n\tv64 = v16.isFocused != 1;\n\tif (v64) goto L_0023;\n\tEnhancedScrollerDemos.Chat.Chat::SendButton_Click(this);\n\treturn;\nL_0023:\n\tv75 = this.otherInputField;\n\tv20 = v75.isFocused != 1;\n\tif (v20) goto L_003F;\n\tEnhancedScrollerDemos.Chat.Chat::OtherSendButton_Click(this);\n\treturn;\nL_003F:\n\treturn;\n")]
		private void Update()
		{
			if (!Input.GetKeyDown(KeyCode.Return))
			{
				return;
			}
			InputField inputField = myInputField;
			if (inputField.isFocused)
			{
				SendButton_Click();
				return;
			}
			InputField inputField2 = otherInputField;
			if (inputField2.isFocused)
			{
				OtherSendButton_Click();
			}
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0x40245F8", Offset = "0x40245F8", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\nL_002F:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ClearActive(this.scroller);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ClearRecycled(this.scroller);\n\tv141 = this.scroller;\n\tthis._oldScrollPosition = v141._scrollPosition;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollPosition(v141, 0f);\n\tv143 = UnityEngine.Component::GetComponent(this.scroller);\n\tv138 = UnityEngine.RectTransform::get_sizeDelta(v143);\n\tgoto L_005D;\nL_0060:\n\tv119 = this._data;\n\tv144 = new EnhancedScrollerDemos.Chat.Data();\n\tSystem.Object::.ctor(v144);\n\tv269 = text.Length * this.characterWidth;\n\tv270 = v269 / v138;\n\tv271 = UnityEngine.Mathf::Ceil(v270);\n\tv273 = v270 + 1;\n\tv108 = v271 == 0x7F800000;\n\tv89 = ~v108;\n\tif (v89) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv280 = 0xCF;\n\tgoto L_0084;\nL_FFFFFFFF:\n\tv280 = v273;\n\tgoto L_00AF;\nL_00AF:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.Chat.Data>::Add(v119, v144);\nL_FFFFFFFF:\n\t;\n\tEnhancedScrollerDemos.Chat.Chat::ResizeScroller(this);\n\tv163 = this._data;\n\tv147 = new System.Action();\n\tSystem.Action::.ctor(v147, this, Il2CppMethodInfo);\n\tv217 = v163.Count - 1;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::JumpToDataIndex(this.scroller, v217, 1f, 1f, 1, 0x11, 0.5f, v147, 0, 0);\n\treturn;\nL_005D:\n\tgoto L_0060;\nL_0084:\n\tv144.someText = text;\n\tv139 = v280 * this.characterHeight;\n\tv144.cellType = cellType;\n\tv144.cellSize = v139;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddNewRow(Data.CellType cellType, string text)
		{
			scroller.ClearActive();
			scroller.ClearRecycled();
			EnhancedScroller enhancedScroller = scroller;
			_oldScrollPosition = enhancedScroller._scrollPosition;
			enhancedScroller.ScrollPosition = 0f;
			RectTransform component = scroller.GetComponent<RectTransform>();
			Vector2 sizeDelta = component.sizeDelta;
			List<Data> data = _data;
			Data data2 = new Data();
			int num = text.Length * characterWidth;
			float num2 = (float)num / sizeDelta.x;
			float num3 = Mathf.Ceil(num2);
			float num4 = num2 + 1E-45f;
			float num5 = ((num3 != 1f / 0f) ? num4 : 2.9E-43f);
			data2.someText = text;
			float cellSize = num5 * (float)characterHeight;
			data2.cellType = cellType;
			data2.cellSize = cellSize;
			data.Add(data2);
			ResizeScroller();
			List<Data> data3 = _data;
			Action jumpComplete = ResetSpacer;
			int dataIndex = data3.Count - 1;
			scroller.JumpToDataIndex(dataIndex, 1f, 1f, useSpacing: true, EnhancedScroller.TweenType.easeInOutSine, 0.5f, jumpComplete);
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0x402423C", Offset = "0x402423C", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv62 = v55.scrollDirection == 0;\n\tif (v62) goto L_0037;\n\tv159 = UnityEngine.RectTransform::get_rect(v55._scrollRectTransform);\n\tv287 = this.scroller;\n\tv285 = this.scroller == 0;\n\tv203 = ~v285;\n\tv139 = v159.width;\n\tif (v203) goto L_0040;\n\tgoto L_00DD;\nL_0037:\n\tv160 = UnityEngine.RectTransform::get_rect(v55._scrollRectTransform);\n\tv287 = this.scroller;\n\tv139 = v160.height;\nL_0040:\n\tv161 = EnhancedUI.EnhancedScroller.EnhancedScroller::get_ScrollSize(v287);\n\tv189 = UnityEngine.Component::GetComponent(this.scroller);\n\tv162 = UnityEngine.RectTransform::get_sizeDelta(v189);\n\t// 85 MakeStruct v127 @ AGG4024328_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v162 @ V0_v4 (UnityEngine.Vector2), 2139095039\n\tUnityEngine.RectTransform::set_sizeDelta(v189, v127);\n\tv223 = this.scroller;\n\tv192 = UnityEngine.RectOffset::get_top(v223.padding);\n\tv224 = this.scroller;\n\tv293 = UnityEngine.RectOffset::get_bottom(v224.padding);\n\tv225 = v293 + v192;\n\tthis._totalCellSize = v225;\n\tv324 = this._data;\n\tv306 = v324.Count < 2;\n\tif (v306) goto L_00AD;\n\tv119 = v225;\n\tv123 = 1;\n\tv329 = v324;\n\tgoto L_0090;\nL_007F:\n\tv321 = v195.cellSize + v320;\n\tv318 = v119 + v321;\n\tthis._totalCellSize = v318;\n\tv123 = v123 + 1;\n\tv309 = v123 >= v329.Count;\n\tv119 = v318;\n\tv324 = v329;\n\tif (v309) goto L_00AD;\nL_0090:\n\tv195 = System.Collections.Generic.List`1<EnhancedScrollerDemos.Chat.Data>::get_Item(v329, v123);\n\tv329 = this._data;\n\tv332 = v329.Count - 1;\n\tv73 = v123 >= v332;\n\tv320 = 0;\n\tif (v73) goto L_007F;\n\tv182 = this.scroller;\n\tv320 = v182.spacing;\n\tgoto L_007F;\nL_00AD:\n\tv197 = System.Collections.Generic.List`1<EnhancedScrollerDemos.Chat.Data>::get_Item(v324, 0);\n\tv197.cellSize = v139;\n\tUnityEngine.RectTransform::set_sizeDelta(v189, v162);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\tv199 = this._data;\n\tv179 = v199.Count - 1;\n\tv200 = System.Collections.Generic.List`1<EnhancedScrollerDemos.Chat.Data>::get_Item(v199, v179);\n\tv270 = this._oldScrollPosition - v161;\n\tv337 = this._totalCellSize - v200.cellSize;\n\tv272 = v270 + v337;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollPosition(this.scroller, v272);\n\treturn;\nL_00DD:\n\tthrow System.NullReferenceException;\nL_0020:\n\tv55 = this.scroller;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ResizeScroller()
		{
			//IL_0213: Expected I4, but got F4
			EnhancedScroller enhancedScroller = scroller;
			EnhancedScroller enhancedScroller2;
			float cellSize;
			if (enhancedScroller.scrollDirection != EnhancedScroller.ScrollDirectionEnum.Vertical)
			{
				Rect rect = enhancedScroller._scrollRectTransform.rect;
				enhancedScroller2 = scroller;
				bool flag = (object)scroller == null;
				bool flag2 = !flag;
				cellSize = rect.width;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				Rect rect2 = enhancedScroller._scrollRectTransform.rect;
				enhancedScroller2 = scroller;
				cellSize = rect2.height;
			}
			float scrollSize = enhancedScroller2.ScrollSize;
			RectTransform component = scroller.GetComponent<RectTransform>();
			Vector2 sizeDelta = component.sizeDelta;
			Vector2 sizeDelta2 = default(Vector2);
			sizeDelta2.x = sizeDelta.x;
			sizeDelta2.y = 3.4028235E+38f;
			component.sizeDelta = sizeDelta2;
			EnhancedScroller enhancedScroller3 = scroller;
			int top = enhancedScroller3.padding.top;
			EnhancedScroller enhancedScroller4 = scroller;
			int bottom = enhancedScroller4.padding.bottom;
			int num = bottom + top;
			_totalCellSize = num;
			List<Data> list = _data;
			if (list.Count >= 2)
			{
				int num2 = num;
				int num3 = 1;
				List<Data> list2 = list;
				bool flag4;
				do
				{
					Data data = list2[num3];
					list2 = _data;
					int num4 = list2.Count - 1;
					bool flag3 = num3 >= num4;
					float num5 = 0f;
					if (!flag3)
					{
						EnhancedScroller enhancedScroller5 = scroller;
						num5 = enhancedScroller5.spacing;
					}
					float num6 = data.cellSize + num5;
					float num7 = (_totalCellSize = (float)num2 + num6);
					num3++;
					flag4 = num3 >= list2.Count;
					num2 = (int)num7;
					list = list2;
				}
				while (!flag4);
			}
			Data data2 = list[0];
			data2.cellSize = cellSize;
			component.sizeDelta = sizeDelta;
			scroller.ReloadData();
			List<Data> data3 = _data;
			int index = data3.Count - 1;
			Data data4 = data3[index];
			float num8 = _oldScrollPosition - scrollSize;
			float num9 = _totalCellSize - data4.cellSize;
			float scrollPosition = num8 + num9;
			scroller.ScrollPosition = scrollPosition;
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0x402488C", Offset = "0x402488C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv44 = System.Collections.Generic.List`1<EnhancedScrollerDemos.Chat.Data>::get_Item(this._data, 0);\n\tv80 = this.scroller;\n\tv84 = v80.scrollDirection == 0;\n\tif (v84) goto L_0030;\n\tv58 = UnityEngine.RectTransform::get_rect(v80._scrollRectTransform);\n\tv52 = v58.width;\n\tv104 = v44 == 0;\n\tv75 = ~v104;\n\tif (v75) goto L_0038;\n\tgoto L_0047;\nL_0030:\n\tv59 = UnityEngine.RectTransform::get_rect(v80._scrollRectTransform);\n\tv52 = v59.height;\nL_0038:\n\tv110 = v52 - this._totalCellSize;\n\tv60 = UnityEngine.Mathf::Max(v110, 0f);\n\tv44.cellSize = v60;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 1f);\n\treturn;\nL_0047:\n\tthrow System.NullReferenceException;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ResetSpacer()
		{
			Data data = _data[0];
			EnhancedScroller enhancedScroller = scroller;
			float num;
			if (enhancedScroller.scrollDirection != EnhancedScroller.ScrollDirectionEnum.Vertical)
			{
				num = enhancedScroller._scrollRectTransform.rect.width;
				if (data == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				num = enhancedScroller._scrollRectTransform.rect.height;
			}
			float a = num - _totalCellSize;
			float cellSize = Mathf.Max(a, 0f);
			data.cellSize = cellSize;
			scroller.ReloadData(1f);
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x40244F8", Offset = "0x40244F8", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tEnhancedScrollerDemos.Chat.Chat::AddNewRow(this, 1, v38.text);\n\tUnityEngine.UI.InputField::set_text(this.myInputField, \"\");\n\tUnityEngine.UI.InputField::ActivateInputField(this.myInputField);\n\treturn;\nL_0012:\n\tv38 = this.myInputField;\n")]
		public void SendButton_Click()
		{
			InputField inputField = myInputField;
			AddNewRow(Data.CellType.MyText, inputField.text);
			myInputField.text = "";
			myInputField.ActivateInputField();
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0x4024578", Offset = "0x4024578", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tEnhancedScrollerDemos.Chat.Chat::AddNewRow(this, 2, v38.text);\n\tUnityEngine.UI.InputField::set_text(this.otherInputField, \"\");\n\tUnityEngine.UI.InputField::ActivateInputField(this.otherInputField);\n\treturn;\nL_0012:\n\tv38 = this.otherInputField;\n")]
		public void OtherSendButton_Click()
		{
			InputField inputField = otherInputField;
			AddNewRow(Data.CellType.OtherText, inputField.text);
			otherInputField.text = "";
			otherInputField.ActivateInputField();
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x4024948", Offset = "0x4024948", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\treturn v38.Count;\nL_0012:\n\tv38 = this._data;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			List<Data> data = _data;
			return data.Count;
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0x4024994", Offset = "0x4024994", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = System.Collections.Generic.List`1<EnhancedScrollerDemos.Chat.Data>::get_Item(this._data, dataIndex);\n\treturn v49.cellSize;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			Data data = _data[dataIndex];
			return data.cellSize;
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0x4024A04", Offset = "0x4024A04", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv60 = System.Collections.Generic.List`1<EnhancedScrollerDemos.Chat.Data>::get_Item(this._data, dataIndex);\n\tv83 = v60.cellType != 1;\n\tif (v83) goto L_007C;\n\tv241 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.myTextCellViewPrefab);\n\tv237 = v241 == 0;\n\tv238 = ~v237;\n\tif (v238) goto L_008E;\n\tgoto L_FFFFFFFF;\nL_0045:\n\tv144 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.spacerCellViewPrefab);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v85_asT @ TEMPCOND_v3 (EnhancedScrollerDemos.Chat.CellView), typeof(EnhancedScrollerDemos.Chat.CellView), v144 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tUnityEngine.Object::set_name(v144, \"Spacer\");\n\treturn v144;\nL_007C:\n\tv241 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.otherTextCellViewPrefab);\n\tv239 = v241 == 0;\n\tif (v239) goto L_FFFFFFFF;\nL_008E:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv168 = 0;\n\tgoto L_00A8;\nL_FFFFFFFF:\n\t// -1 IsInst v287_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.Chat.CellView), typeof(EnhancedScrollerDemos.Chat.CellView), v241 @ X0_v22 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv287 = v287_asT == 0;\n\tif (v287) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv168 = v241;\n\tgoto L_00A8;\nL_FFFFFFFF:\n\tv168 = 0;\n\tUnityEngine.Object::set_name(v168, v145);\n\tv147 = System.Collections.Generic.List`1<EnhancedScrollerDemos.Chat.Data>::get_Item(this._data, v165);\n\tv148 = *([v168 @ X20_v5 (UnityEngine.Object)+38]);\n\tv206 = *([v148 @ X0_v18]);\n\t*([v206 @ X8_v12+5E8])(v299, v148, v147.someText, *([v206 @ X8_v12+5F0]), cellIndex, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturn v168;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0020:\n\tv46 = dataIndex == 0;\n\tif (v46) goto L_0045;\nL_00A8:\n\tv296 = System.Int32::ToString(&v165 @ stack_-34_v3 (System.Int32));\n\tv145 = System.String::Concat(\"Cell \", v296);\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			//IL_0172: Expected O, but got I
			UnityEngine.Object obj;
			if (dataIndex != 0)
			{
				Data data = _data[dataIndex];
				EnhancedScrollerCellView cellView;
				if (data.cellType == Data.CellType.MyText)
				{
					cellView = scroller.GetCellView(myTextCellViewPrefab);
					if ((object)cellView == null)
					{
						goto IL_00f1;
					}
				}
				else
				{
					cellView = scroller.GetCellView(otherTextCellViewPrefab);
					if ((object)cellView == null)
					{
						goto IL_00f1;
					}
				}
				obj = ((!(cellView is CellView)) ? null : cellView);
				goto IL_01b9;
			}
			EnhancedScrollerCellView cellView3 = scroller.GetCellView(spacerCellViewPrefab);
			CellView cellView4 = cellView3 as CellView;
			cellView3.name = "Spacer";
			return cellView3;
			IL_00f1:
			obj = null;
			goto IL_01b9;
			IL_01b9:
			int index = default(int);
			string text = index.ToString();
			string text2 = "Cell " + text;
			obj.name = text2;
			Data data2 = _data[index];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X20_v5 (UnityEngine.Object)+38]");
			object obj2 = 0;
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v206 @ X8_v12+5E8] (should have been resolved before IL gen)");
			return (EnhancedScrollerCellView)obj;
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0x4024C0C", Offset = "0x4024C0C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.characterWidth = 5.5171890569E-313d;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Chat()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Chat::.ctor");
		}
	}
}
