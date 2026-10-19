using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.SelectionDemo
{
	[Token(Token = "0x2000077")]
	public class SelectionDemo : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x40001E9")]
		[FieldOffset(Offset = "0x20")]
		private SmallList<InventoryData> _data;

		[Token(Token = "0x40001EA")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller vScroller;

		[Token(Token = "0x40001EB")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScroller hScroller;

		[Token(Token = "0x40001EC")]
		[FieldOffset(Offset = "0x38")]
		public EnhancedScrollerCellView vCellViewPrefab;

		[Token(Token = "0x40001ED")]
		[FieldOffset(Offset = "0x40")]
		public EnhancedScrollerCellView hCellViewPrefab;

		[Token(Token = "0x40001EE")]
		[FieldOffset(Offset = "0x48")]
		public Image selectedImage;

		[Token(Token = "0x40001EF")]
		[FieldOffset(Offset = "0x50")]
		public Text selectedImageText;

		[Token(Token = "0x40001F0")]
		[FieldOffset(Offset = "0x58")]
		public string resourcePath;

		[Token(Token = "0x600023F")]
		[Address(RVA = "0x40307C4", Offset = "0x40307C4", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0029:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv63 = UnityEngine.GameObject::Find(\"Mask Toggle\");\n\tv70 = UnityEngine.GameObject::GetComponent(v63);\n\tEnhancedScrollerDemos.SelectionDemo.SelectionDemo::MaskToggle_OnValueChanged(this, v70.isOn);\n\tv78 = UnityEngine.GameObject::Find(\"Loop Toggle\");\n\tv79 = UnityEngine.GameObject::GetComponent(v78);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_Loop(this.vScroller, v79.isOn);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_Loop(this.hScroller, v79.isOn);\n\tEnhancedScrollerDemos.SelectionDemo.SelectionDemo::CellViewSelected(this, 0);\n\treturn;\nL_0025:\n\tgoto L_0029;\n")]
		private void Awake()
		{
			Application.targetFrameRate = 60;
			GameObject gameObject = GameObject.Find("Mask Toggle");
			Toggle component = gameObject.GetComponent<Toggle>();
			MaskToggle_OnValueChanged(component.isOn);
			GameObject gameObject2 = GameObject.Find("Loop Toggle");
			Toggle component2 = gameObject2.GetComponent<Toggle>();
			vScroller.Loop = component2.isOn;
			hScroller.Loop = component2.isOn;
			CellViewSelected(null);
		}

		[Token(Token = "0x6000240")]
		[Address(RVA = "0x4030C2C", Offset = "0x4030C2C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_Delegate(this.vScroller, this);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_Delegate(this.hScroller, this);\n\tEnhancedScrollerDemos.SelectionDemo.SelectionDemo::Reload(this);\n\treturn;\n")]
		private void Start()
		{
			vScroller.Delegate = this;
			hScroller.Delegate = this;
			Reload();
		}

		[Token(Token = "0x6000241")]
		[Address(RVA = "0x4030C78", Offset = "0x4030C78", Length = "0x7B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0076;\n\tv117 = 0;\n\tv162 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.SelectionDemo.InventoryData>::get_Item(v120, v117);\n\tv162.selectedChanged = 0;\n\tv117 = v117 + 1;\n\tv120 = this._data;\n\tv314 = this._data == 0;\n\tv153 = ~v314;\n\tif (v153) goto L_0087;\n\tthrow System.NullReferenceException;\nL_009F:\n\tv136 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.SelectionDemo.InventoryData>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.SelectionDemo.InventoryData>::.ctor(v136);\n\t*([v128 @ X20_v7]) = v136;\n\tv172 = new EnhancedScrollerDemos.SelectionDemo.InventoryData();\n\tSystem.Object::.ctor(v172);\n\tv172.itemName = \"Sword\";\n\tv172.itemCost = *([93096A0]);\n\tv331 = System.String::Concat(this.resourcePath, \"/sword\");\n\tv172.spritePath = v331;\n\tv172.itemDescription = \"Broadsword with a double-edged blade\";\n\tEnhancedUI.SmallList`1<System.Object>::Add(*([v128 @ X20_v7]), v172);\n\tv263 = new EnhancedScrollerDemos.SelectionDemo.InventoryData();\n\tSystem.Object::.ctor(v263);\n\tv263.itemName = \"Shield\";\n\tv263.itemCost = *([93096B0]);\n\tv379 = System.String::Concat(this.resourcePath, \"/shield\");\n\tv263.spritePath = v379;\n\tv263.itemDescription = \"Steel shield to deflect your enemy's blows\";\n\tEnhancedUI.SmallList`1<System.Object>::Add(*([v128 @ X20_v7]), v263);\n\tv265 = new EnhancedScrollerDemos.SelectionDemo.InventoryData();\n\tSystem.Object::.ctor(v265);\n\tv265.itemName = \"Amulet\";\n\tv265.itemCost = *([93096C0]);\n\tv426 = System.String::Concat(this.resourcePath, \"/amulet\");\n\tv265.spritePath = v426;\n\tv265.itemDescription = \"Magic amulet restores your health points gradually over time\";\n\tEnhancedUI.SmallList`1<System.Object>::Add(*([v128 @ X20_v7]), v265);\n\tv267 = new EnhancedScrollerDemos.SelectionDemo.InventoryData();\n\tSystem.Object::.ctor(v267);\n\tv267.itemName = \"Helmet\";\n\tv267.itemCost = *([93096D0]);\n\tv460 = System.String::Concat(this.resourcePath, \"/helmet\");\n\tv267.spritePath = v460;\n\tv267.itemDescription = \"Standard helm will decrease your vulnerability\";\n\tEnhancedUI.SmallList`1<System.Object>::Add(*([v128 @ X20_v7]), v267);\n\tv269 = new EnhancedScrollerDemos.SelectionDemo.InventoryData();\n\tSystem.Object::.ctor(v269);\n\tv269.itemName = \"Boots\";\n\tv269.itemCost = *([93096E0]);\n\tv480 = System.String::Concat(this.resourcePath, \"/boots\");\n\tv269.spritePath = v480;\n\tv269.itemDescription = \"Boots of speed will double your movement points\";\n\tEnhancedUI.SmallList`1<System.Object>::Add(*([v128 @ X20_v7]), v269);\n\tv271 = new EnhancedScrollerDemos.SelectionDemo.InventoryData();\n\tSystem.Object::.ctor(v271);\n\tv271.itemName = \"Bracers\";\n\tv271.itemCost = *([93096F0]);\n\tv500 = System.String::Concat(this.resourcePath, \"/bracers\");\n\tv271.spritePath = v500;\n\tv271.itemDescription = \"Bracers will upgrade your overall armor\";\n\tEnhancedUI.SmallList`1<System.Object>::Add(*([v128 @ X20_v7]), v271);\n\tv273 = new EnhancedScrollerDemos.SelectionDemo.InventoryData();\n\tSystem.Object::.ctor(v273);\n\tv273.itemName = \"Crossbow\";\n\tv273.itemCost = *([9309700]);\n\tv520 = System.String::Concat(this.resourcePath, \"/crossbow\");\n\tv273.spritePath = v520;\n\tv273.itemDescription = \"Crossbow can attack from long range\";\n\tEnhancedUI.SmallList`1<System.Object>::Add(*([v128 @ X20_v7]), v273);\n\tv275 = new EnhancedScrollerDemos.SelectionDemo.InventoryData();\n\tSystem.Object::.ctor(v275);\n\tv275.itemName = \"Fire Ring\";\n\tv275.itemCost = *([9309710]);\n\tv540 = System.String::Concat(this.resourcePath, \"/fireRing\");\n\tv275.spritePath = v540;\n\tv275.itemDescription = \"Fire ring gives you the magical ability to cast fireball spells\";\n\tEnhancedUI.SmallList`1<System.Object>::Add(*([v128 @ X20_v7]), v275);\n\tv277 = new EnhancedScrollerDemos.SelectionDemo.InventoryData();\n\tSystem.Object::.ctor(v277);\n\tv277.itemName = \"Knapsack\";\n\tv277.itemCost = *([92D95B0]);\n\tv560 = System.String::Concat(this.resourcePath, \"/knapsack\");\n\tv277.spritePath = v560;\n\tv277.itemDescription = \"Knapsack will increase your carrying capacity by twofold\";\n\tEnhancedUI.SmallList`1<System.Object>::Add(*([v128 @ X20_v7]), v277);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.vScroller, 0f);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.hScroller, 0f);\n\treturn;\nL_0076:\n\tv128 = this + 0x20;\n\tv120 = this._data;\n\tv54 = this._data == 0;\n\tif (v54) goto L_009F;\nL_0087:\n\tv63 = v117 >= v120.Count;\n\tif (v63) goto L_009F;\n")]
		private void Reload()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SelectionDemo::Reload");
		}

		[Token(Token = "0x6000242")]
		[Address(RVA = "0x40309BC", Offset = "0x40309BC", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv53 = UnityEngine.Object::op_Equality(cellView, 0);\n\tv61 = ~v53;\n\tif (v61) goto L_005E;\n\tv88 = UnityEngine.Component::get_gameObject(this.selectedImage);\n\tUnityEngine.GameObject::SetActive(v88, 0);\n\tv305 = 0xB2F8000 + 0xA68;\n\tgoto L_00EE;\nL_005E:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v95_asT @ TEMPCOND_v4 (EnhancedScrollerDemos.SelectionDemo.InventoryCellView), typeof(EnhancedScrollerDemos.SelectionDemo.InventoryCellView), cellView @ X1 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv297 = this._data;\nL_FFFFFFFF:\n\tv212 = 0;\n\tgoto L_0084;\nL_0076:\n\tv212 = v212 + 1;\n\tv297 = this._data;\nL_0084:\n\tv96 = v212 >= v297.Count;\n\tif (v96) goto L_00B7;\n\tv181 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.SelectionDemo.InventoryData>::get_Item(v297, v212);\n\tv312 = *([cellView @ X1 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)+A0]) - v212;\n\tv314 = v312 == 0;\n\tv325 = v181.Selected == v314;\n\tif (v325) goto L_0076;\n\tv181.Selected = v314;\n\tv331 = v181.selectedChanged == 0;\n\tif (v331) goto L_0076;\n\tv338 = *([cellView @ X1 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)+A0]) - v212;\n\tv336 = v338 == 0;\n\tEnhancedScrollerDemos.SelectionDemo.SelectedChangedDelegate::Invoke(v181.selectedChanged, v336);\n\tgoto L_0076;\nL_00B7:\n\tv183 = UnityEngine.Component::get_gameObject(this.selectedImage);\n\tUnityEngine.GameObject::SetActive(v183, 1);\n\tv185 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.SelectionDemo.InventoryData>::get_Item(this._data, *([cellView @ X1 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)+A0]));\n\tv352 = System.String::Concat(v185.spritePath, \"_v\");\n\tv186 = UnityEngine.Resources::Load(v352);\n\tUnityEngine.UI.Image::set_sprite(this.selectedImage, v186);\n\tv188 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.SelectionDemo.InventoryData>::get_Item(this._data, *([cellView @ X1 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)+A0]));\n\tv305 = v188 + 0x10;\n\tthrow System.NullReferenceException;\nL_00EE:\n\tv267 = UnityEngine.UI.Text::set_text(v267, *([v305 @ X8_v2 (System.Int32)]));\nL_00EE:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CellViewSelected(EnhancedScrollerCellView cellView)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SelectionDemo::CellViewSelected");
		}

		[Token(Token = "0x6000243")]
		[Address(RVA = "0x40308E8", Offset = "0x40308E8", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv48 = UnityEngine.Component::GetComponent(this.vScroller);\n\tUnityEngine.Behaviour::set_enabled(v48, val);\n\tv56 = UnityEngine.Component::GetComponent(this.hScroller);\n\tUnityEngine.Behaviour::set_enabled(v56, val);\n\treturn;\n")]
		public void MaskToggle_OnValueChanged(bool val)
		{
			Mask component = vScroller.GetComponent<Mask>();
			component.enabled = val;
			Mask component2 = hScroller.GetComponent<Mask>();
			component2.enabled = val;
		}

		[Token(Token = "0x6000244")]
		[Address(RVA = "0x4030978", Offset = "0x4030978", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_Loop(this.vScroller, val);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_Loop(this.hScroller, val);\n\treturn;\n")]
		public void LoopToggle_OnValueChanged(bool val)
		{
			vScroller.Loop = val;
			hScroller.Loop = val;
		}

		[Token(Token = "0x6000245")]
		[Address(RVA = "0x403142C", Offset = "0x403142C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._data;\n\treturn v0.Count;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			SmallList<InventoryData> data = _data;
			return data.Count;
		}

		[Token(Token = "0x6000246")]
		[Address(RVA = "0x4031448", Offset = "0x4031448", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_0021:\n\tv55 = UnityEngine.Object::op_Equality(scroller, this.vScroller);\n\tv60 = v55 == 0;\n\tv69 = ~v60;\n\tv70 = ~v69;\n\tif (v70) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 0x43A00000;\n\tgoto L_003D;\nL_FFFFFFFF:\n\treturnVal1 = 0x43160000;\nL_001C:\n\tgoto L_0021;\nL_003D:\n\treturn returnVal1;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			if (scroller == vScroller)
			{
				return 320f;
			}
			return 150f;
		}

		[Token(Token = "0x6000247")]
		[Address(RVA = "0x40314D4", Offset = "0x40314D4", Length = "0x28C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tgoto L_001E;\nL_001E:\n\tv85 = UnityEngine.Object::op_Equality(scroller, this.vScroller);\n\tv74 = scroller == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_004E;\n\tgoto L_00F2;\nL_004E:\n\tv94 = v85 == 0;\n\tv101 = ~v94;\n\tv102 = ~v101;\n\tif (v102) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv191 = 0x38;\n\tgoto L_005F;\nL_FFFFFFFF:\n\tv191 = 0x40;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv184 = 0;\n\tgoto L_0088;\nL_FFFFFFFF:\n\t// -1 IsInst v293_asT @ TEMPCSEL_v5 (EnhancedScrollerDemos.SelectionDemo.InventoryCellView), typeof(EnhancedScrollerDemos.SelectionDemo.InventoryCellView), v195 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv293 = v293_asT == 0;\n\tif (v293) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv184 = v195;\n\tgoto L_0088;\nL_FFFFFFFF:\n\tv184 = 0;\nL_0095:\n\tv317 = UnityEngine.Object::op_Equality(scroller, this.vScroller);\n\tv150 = v317 == 0;\n\tv132 = ~v150;\n\tv129 = ~v132;\n\tif (v129) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv181 = v117;\n\tgoto L_00AE;\nL_FFFFFFFF:\n\tv181 = v107;\nL_00AE:\n\tv171 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.SelectionDemo.InventoryData>::get_Item(this._data, dataIndex);\n\tv172 = System.String::Concat(*([v181 @ X8_v8 (System.Int32)]), \" \", v171.itemName);\n\tUnityEngine.Object::set_name(v184, v172);\n\tv331 = new EnhancedScrollerDemos.SelectionDemo.SelectedDelegate();\n\tEnhancedScrollerDemos.SelectionDemo.SelectedDelegate::.ctor(v331, this, Il2CppMethodInfo);\n\t*([v184 @ X22_v4 (UnityEngine.Object)+A8]) = v331;\n\tv338 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.SelectionDemo.InventoryData>::get_Item(this._data, dataIndex);\n\tgoto L_00DF;\nL_00F2:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_005F:\n\tv195 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, *([this @ X0 (EnhancedScrollerDemos.SelectionDemo.SelectionDemo)+v191 @ X8_v5 (System.Int32)]));\n\tv245 = v195 == 0;\n\tif (v245) goto L_FFFFFFFF;\nL_0088:\n\tv117 = 0xB302000 + 0x8A0;\n\tv107 = 0xB2F4000 + 0x920;\n\tgoto L_0095;\nL_00DF:\n\tv351 = UnityEngine.Object::op_Equality(scroller, this.vScroller);\n\tEnhancedScrollerDemos.SelectionDemo.InventoryCellView::SetData(v184, dataIndex, v338, v351);\n\treturn v184;\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SelectionDemo::GetCellView");
			return default;
		}

		[Token(Token = "0x6000248")]
		[Address(RVA = "0x4031760", Offset = "0x4031760", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SelectionDemo()
		{
		}
	}
}
