using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.MultipleCellTypesDemo
{
	[Token(Token = "0x2000080")]
	public class MultipleCellTypesDemo : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x40001FC")]
		[FieldOffset(Offset = "0x20")]
		private SmallList<Data> _data;

		[Token(Token = "0x40001FD")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller scroller;

		[Token(Token = "0x40001FE")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScrollerCellView headerCellViewPrefab;

		[Token(Token = "0x40001FF")]
		[FieldOffset(Offset = "0x38")]
		public EnhancedScrollerCellView rowCellViewPrefab;

		[Token(Token = "0x4000200")]
		[FieldOffset(Offset = "0x40")]
		public EnhancedScrollerCellView footerCellViewPrefab;

		[Token(Token = "0x4000201")]
		[FieldOffset(Offset = "0x48")]
		public string resourcePath;

		[Token(Token = "0x6000254")]
		[Address(RVA = "0x4031AC4", Offset = "0x4031AC4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_Delegate(this.scroller, this);\n\tEnhancedScrollerDemos.MultipleCellTypesDemo.MultipleCellTypesDemo::LoadData(this);\n\treturn;\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			scroller.Delegate = this;
			LoadData();
		}

		[Token(Token = "0x6000255")]
		[Address(RVA = "0x4031B68", Offset = "0x4031B68", Length = "0x9E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0069;\n\tv81 = new EnhancedScrollerDemos.MultipleCellTypesDemo.HeaderData();\n\tSystem.Object::.ctor(v81);\n\tv81.category = \"Platinum Players\";\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v81);\n\tv197 = new EnhancedScrollerDemos.MultipleCellTypesDemo.RowData();\n\tSystem.Object::.ctor(v197);\n\tv197.userName = \"John Smith\";\n\tv399 = System.String::Concat(this.resourcePath, \"/avatar_male\");\n\tv197.userAvatarSpritePath = v399;\n\tv197.userHighScore = 0x1455DBF;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v197);\n\tv199 = new EnhancedScrollerDemos.MultipleCellTypesDemo.RowData();\n\tSystem.Object::.ctor(v199);\n\tv199.userName = \"Jane Doe\";\n\tv439 = System.String::Concat(this.resourcePath, \"/avatar_female\");\n\tv199.userAvatarSpritePath = v439;\n\tv199.userHighScore = 0x13D4783;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v199);\n\tv201 = new EnhancedScrollerDemos.MultipleCellTypesDemo.RowData();\n\tSystem.Object::.ctor(v201);\n\tv201.userName = \"Julie Prost\";\n\tv462 = System.String::Concat(this.resourcePath, \"/avatar_female\");\n\tv201.userAvatarSpritePath = v462;\n\tv201.userHighScore = 0x13023E4;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v201);\n\tv203 = new EnhancedScrollerDemos.MultipleCellTypesDemo.FooterData();\n\tSystem.Object::.ctor(v203);\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v203);\n\tv204 = new EnhancedScrollerDemos.MultipleCellTypesDemo.HeaderData();\n\tSystem.Object::.ctor(v204);\n\tv204.category = \"Gold Players\";\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v204);\n\tv206 = new EnhancedScrollerDemos.MultipleCellTypesDemo.RowData();\n\tSystem.Object::.ctor(v206);\n\tv206.userName = \"Jim Bob\";\n\tv487 = System.String::Concat(this.resourcePath, \"/avatar_male\");\n\tv206.userAvatarSpritePath = v487;\n\tv206.userHighScore = 0xF4A94;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v206);\n\tv208 = new EnhancedScrollerDemos.MultipleCellTypesDemo.RowData();\n\tSystem.Object::.ctor(v208);\n\tv208.userName = \"Susan Anthony\";\n\tv502 = System.String::Concat(this.resourcePath, \"/avatar_female\");\n\tv208.userAvatarSpritePath = v502;\n\tv208.userHighScore = 0xF2002;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v208);\n\tv210 = new EnhancedScrollerDemos.MultipleCellTypesDemo.FooterData();\n\tSystem.Object::.ctor(v210);\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v210);\n\tv211 = new EnhancedScrollerDemos.MultipleCellTypesDemo.HeaderData();\n\tSystem.Object::.ctor(v211);\n\tv211.category = \"Silver Players\";\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v211);\n\tv213 = new EnhancedScrollerDemos.MultipleCellTypesDemo.RowData();\n\tSystem.Object::.ctor(v213);\n\tv213.userName = \"Gary Richards\";\n\tv527 = System.String::Concat(this.resourcePath, \"/avatar_male\");\n\tv213.userAvatarSpritePath = v527;\n\tv213.userHighScore = 0xDD1FB;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v213);\n\tv215 = new EnhancedScrollerDemos.MultipleCellTypesDemo.RowData();\n\tSystem.Object::.ctor(v215);\n\tv215.userName = \"John Doe\";\n\tv542 = System.String::Concat(this.resourcePath, \"/avatar_male\");\n\tv215.userAvatarSpritePath = v542;\n\tv215.userHighScore = 0xAB76E;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v215);\n\tv217 = new EnhancedScrollerDemos.MultipleCellTypesDemo.RowData();\n\tSystem.Object::.ctor(v217);\n\tv217.userName = \"Lisa Ford\";\n\tv557 = System.String::Concat(this.resourcePath, \"/avatar_female\");\n\tv217.userAvatarSpritePath = v557;\n\tv217.userHighScore = 0xAA5A7;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v217);\n\tv219 = new EnhancedScrollerDemos.MultipleCellTypesDemo.RowData();\n\tSystem.Object::.ctor(v219);\n\tv219.userName = \"Jacob Morris\";\n\tv572 = System.String::Concat(this.resourcePath, \"/avatar_male\");\n\tv219.userAvatarSpritePath = v572;\n\tv219.userHighScore = 0x63F31;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v219);\n\tv221 = new EnhancedScrollerDemos.MultipleCellTypesDemo.RowData();\n\tSystem.Object::.ctor(v221);\n\tv221.userName = \"Carolyn Shephard\";\n\tv587 = System.String::Concat(this.resourcePath, \"/avatar_female\");\n\tv221.userAvatarSpritePath = v587;\n\tv221.userHighScore = 0x197A0;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v221);\n\tv223 = new EnhancedScrollerDemos.MultipleCellTypesDemo.RowData();\n\tSystem.Object::.ctor(v223);\n\tv223.userName = \"Guy Wilson\";\n\tv602 = System.String::Concat(this.resourcePath, \"/avatar_male\");\n\tv223.userAvatarSpritePath = v602;\n\tv223.userHighScore = 0x15901;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v223);\n\tv225 = new EnhancedScrollerDemos.MultipleCellTypesDemo.RowData();\n\tSystem.Object::.ctor(v225);\n\tv225.userName = \"Jackie Jones\";\n\tv617 = System.String::Concat(this.resourcePath, \"/avatar_female\");\n\tv225.userAvatarSpritePath = v617;\n\tv225.userHighScore = 0x515A;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v225);\n\tv227 = new EnhancedScrollerDemos.MultipleCellTypesDemo.RowData();\n\tSystem.Object::.ctor(v227);\n\tv227.userName = \"Sally Brewer\";\n\tv631 = System.String::Concat(this.resourcePath, \"/avatar_female\");\n\tv227.userAvatarSpritePath = v631;\n\tv227.userHighScore = 0x43ED;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v227);\n\tv229 = new EnhancedScrollerDemos.MultipleCellTypesDemo.RowData();\n\tSystem.Object::.ctor(v229);\n\tv229.userName = \"Joe West\";\n\tv645 = System.String::Concat(this.resourcePath, \"/avatar_male\");\n\tv229.userAvatarSpritePath = v645;\n\tv229.userHighScore = 0xB66;\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v229);\n\tv231 = new EnhancedScrollerDemos.MultipleCellTypesDemo.FooterData();\n\tSystem.Object::.ctor(v231);\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::Add(this._data, v231);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\nL_0069:\n\tv62 = new EnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>();\n\tEnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::.ctor(v62);\n\tthis._data = v62;\n")]
		private void LoadData()
		{
			//IL_008c: Expected I8, but got I4
			//IL_00f6: Expected I8, but got I4
			//IL_0160: Expected I8, but got I4
			//IL_0223: Expected I8, but got I4
			//IL_028d: Expected I8, but got I4
			//IL_0350: Expected I8, but got I4
			//IL_03ba: Expected I8, but got I4
			//IL_0424: Expected I8, but got I4
			//IL_048e: Expected I8, but got I4
			//IL_04f8: Expected I8, but got I4
			//IL_0562: Expected I8, but got I4
			//IL_05cc: Expected I8, but got I4
			//IL_0636: Expected I8, but got I4
			//IL_06a0: Expected I8, but got I4
			SmallList<Data> data = new SmallList<Data>();
			_data = data;
			HeaderData headerData = new HeaderData();
			headerData.category = "Platinum Players";
			_data.Add(headerData);
			RowData rowData = new RowData();
			rowData.userName = "John Smith";
			string userAvatarSpritePath = resourcePath + "/avatar_male";
			rowData.userAvatarSpritePath = userAvatarSpritePath;
			rowData.userHighScore = 21323199uL;
			_data.Add(rowData);
			RowData rowData2 = new RowData();
			rowData2.userName = "Jane Doe";
			string userAvatarSpritePath2 = resourcePath + "/avatar_female";
			rowData2.userAvatarSpritePath = userAvatarSpritePath2;
			rowData2.userHighScore = 20793219uL;
			_data.Add(rowData2);
			RowData rowData3 = new RowData();
			rowData3.userName = "Julie Prost";
			string userAvatarSpritePath3 = resourcePath + "/avatar_female";
			rowData3.userAvatarSpritePath = userAvatarSpritePath3;
			rowData3.userHighScore = 19932132uL;
			_data.Add(rowData3);
			FooterData item = new FooterData();
			_data.Add(item);
			HeaderData headerData2 = new HeaderData();
			headerData2.category = "Gold Players";
			_data.Add(headerData2);
			RowData rowData4 = new RowData();
			rowData4.userName = "Jim Bob";
			string userAvatarSpritePath4 = resourcePath + "/avatar_male";
			rowData4.userAvatarSpritePath = userAvatarSpritePath4;
			rowData4.userHighScore = 1002132uL;
			_data.Add(rowData4);
			RowData rowData5 = new RowData();
			rowData5.userName = "Susan Anthony";
			string userAvatarSpritePath5 = resourcePath + "/avatar_female";
			rowData5.userAvatarSpritePath = userAvatarSpritePath5;
			rowData5.userHighScore = 991234uL;
			_data.Add(rowData5);
			FooterData item2 = new FooterData();
			_data.Add(item2);
			HeaderData headerData3 = new HeaderData();
			headerData3.category = "Silver Players";
			_data.Add(headerData3);
			RowData rowData6 = new RowData();
			rowData6.userName = "Gary Richards";
			string userAvatarSpritePath6 = resourcePath + "/avatar_male";
			rowData6.userAvatarSpritePath = userAvatarSpritePath6;
			rowData6.userHighScore = 905723uL;
			_data.Add(rowData6);
			RowData rowData7 = new RowData();
			rowData7.userName = "John Doe";
			string userAvatarSpritePath7 = resourcePath + "/avatar_male";
			rowData7.userAvatarSpritePath = userAvatarSpritePath7;
			rowData7.userHighScore = 702318uL;
			_data.Add(rowData7);
			RowData rowData8 = new RowData();
			rowData8.userName = "Lisa Ford";
			string userAvatarSpritePath8 = resourcePath + "/avatar_female";
			rowData8.userAvatarSpritePath = userAvatarSpritePath8;
			rowData8.userHighScore = 697767uL;
			_data.Add(rowData8);
			RowData rowData9 = new RowData();
			rowData9.userName = "Jacob Morris";
			string userAvatarSpritePath9 = resourcePath + "/avatar_male";
			rowData9.userAvatarSpritePath = userAvatarSpritePath9;
			rowData9.userHighScore = 409393uL;
			_data.Add(rowData9);
			RowData rowData10 = new RowData();
			rowData10.userName = "Carolyn Shephard";
			string userAvatarSpritePath10 = resourcePath + "/avatar_female";
			rowData10.userAvatarSpritePath = userAvatarSpritePath10;
			rowData10.userHighScore = 104352uL;
			_data.Add(rowData10);
			RowData rowData11 = new RowData();
			rowData11.userName = "Guy Wilson";
			string userAvatarSpritePath11 = resourcePath + "/avatar_male";
			rowData11.userAvatarSpritePath = userAvatarSpritePath11;
			rowData11.userHighScore = 88321uL;
			_data.Add(rowData11);
			RowData rowData12 = new RowData();
			rowData12.userName = "Jackie Jones";
			string userAvatarSpritePath12 = resourcePath + "/avatar_female";
			rowData12.userAvatarSpritePath = userAvatarSpritePath12;
			rowData12.userHighScore = 20826uL;
			_data.Add(rowData12);
			RowData rowData13 = new RowData();
			rowData13.userName = "Sally Brewer";
			string userAvatarSpritePath13 = resourcePath + "/avatar_female";
			rowData13.userAvatarSpritePath = userAvatarSpritePath13;
			rowData13.userHighScore = 17389uL;
			_data.Add(rowData13);
			RowData rowData14 = new RowData();
			rowData14.userName = "Joe West";
			string userAvatarSpritePath14 = resourcePath + "/avatar_male";
			rowData14.userAvatarSpritePath = userAvatarSpritePath14;
			rowData14.userHighScore = 2918uL;
			_data.Add(rowData14);
			FooterData item3 = new FooterData();
			_data.Add(item3);
			scroller.ReloadData();
		}

		[Token(Token = "0x6000256")]
		[Address(RVA = "0x4032550", Offset = "0x4032550", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._data;\n\treturn v0.Count;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			SmallList<Data> data = _data;
			return data.Count;
		}

		[Token(Token = "0x6000257")]
		[Address(RVA = "0x403256C", Offset = "0x403256C", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv53 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::get_Item(this._data, dataIndex);\n\tv105 = v53 == 0;\n\tif (v105) goto L_0049;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v127_asT @ Z_v7 (EnhancedScrollerDemos.MultipleCellTypesDemo.HeaderData), typeof(EnhancedScrollerDemos.MultipleCellTypesDemo.HeaderData), v53 @ X0_v5 (EnhancedScrollerDemos.MultipleCellTypesDemo.Data)\n\tv127 = v127_asT != 0;\n\tif (v127) goto L_008E;\nL_0049:\n\tv190 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::get_Item(this._data, dataIndex);\n\tv192 = v190 == 0;\n\tif (v192) goto L_0065;\n\tgoto L_FFFFFFFF;\nL_0065:\n\treturn 0x42B40000;\nL_FFFFFFFF:\n\t// -1 IsInst v134_asT @ TEMPCSEL_v1 (EnhancedScrollerDemos.MultipleCellTypesDemo.RowData), typeof(EnhancedScrollerDemos.MultipleCellTypesDemo.RowData), v190 @ X0_v7 (EnhancedScrollerDemos.MultipleCellTypesDemo.Data)\n\tv134 = v134_asT == 0;\n\tif (v134) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal4 = 0x42C80000;\n\tgoto L_0084;\nL_FFFFFFFF:\n\treturnVal4 = 0x42B40000;\nL_008E:\n\treturn 0x428C0000;\nL_0084:\n\treturn returnVal4;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			Data data = _data[dataIndex];
			if (data == null || !(data is HeaderData))
			{
				Data data2 = _data[dataIndex];
				if (data2 == null)
				{
					return 90f;
				}
				if (data2 is RowData)
				{
					return 100f;
				}
				return 90f;
			}
			return 70f;
		}

		[Token(Token = "0x6000258")]
		[Address(RVA = "0x40326B0", Offset = "0x40326B0", Length = "0x374")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\nL_0037:\n\tv58 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::get_Item(this._data, dataIndex);\n\tv380 = v58 == 0;\n\tif (v380) goto L_005E;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v174_asT @ Z_v17 (EnhancedScrollerDemos.MultipleCellTypesDemo.HeaderData), typeof(EnhancedScrollerDemos.MultipleCellTypesDemo.HeaderData), v58 @ X0_v5 (EnhancedScrollerDemos.MultipleCellTypesDemo.Data)\n\tv174 = v174_asT != 0;\n\tif (v174) goto L_00B9;\nL_005E:\n\tv324 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::get_Item(this._data, dataIndex);\n\tv458 = v324 == 0;\n\tif (v458) goto L_0085;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v176_asT @ Z_v9 (EnhancedScrollerDemos.MultipleCellTypesDemo.RowData), typeof(EnhancedScrollerDemos.MultipleCellTypesDemo.RowData), v324 @ X0_v17 (EnhancedScrollerDemos.MultipleCellTypesDemo.Data)\n\tv176 = v176_asT != 0;\n\tif (v176) goto L_00D7;\nL_0085:\n\tv325 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.footerCellViewPrefab);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v84_asT @ TEMPCOND_v7 (EnhancedScrollerDemos.MultipleCellTypesDemo.CellViewFooter), typeof(EnhancedScrollerDemos.MultipleCellTypesDemo.CellViewFooter), v325 @ X0_v19 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tUnityEngine.Object::set_name(v325, \"[Footer]\");\n\tv548 = this._data;\n\tv538 = this._data == 0;\n\tv339 = ~v538;\nL_FFFFFFFF:\n\tv550 = v325;\n\tif (v339) goto L_0177;\n\tgoto L_0189;\nL_00B9:\n\tv463 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.headerCellViewPrefab);\n\tv478 = v463 == 0;\n\tif (v478) goto L_00CD;\n\tgoto L_FFFFFFFF;\nL_00CD:\n\tv501 = this._data;\n\tv497 = this._data == 0;\n\tv341 = ~v497;\nL_FFFFFFFF:\n\tv371 = 0;\n\tif (v341) goto L_0108;\n\tgoto L_0189;\nL_00D7:\n\tv504 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.rowCellViewPrefab);\n\tv510 = v504 == 0;\n\tif (v510) goto L_00EB;\n\tgoto L_FFFFFFFF;\nL_00EB:\n\tv536 = this._data;\n\tv527 = this._data == 0;\n\tv343 = ~v527;\nL_FFFFFFFF:\n\tv372 = 0;\n\tif (v343) goto L_0145;\n\tgoto L_0189;\nL_FFFFFFFF:\n\t// -1 IsInst v64_asT @ TEMPCSEL_v7 (EnhancedScrollerDemos.MultipleCellTypesDemo.CellViewHeader), typeof(EnhancedScrollerDemos.MultipleCellTypesDemo.CellViewHeader), v463 @ X0_v29 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv64 = v64_asT == 0;\n\tif (v64) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv371 = v463;\n\tgoto L_0103;\nL_FFFFFFFF:\n\tv371 = 0;\nL_0108:\n\tv329 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::get_Item(v501, dataIndex);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v88_asT @ TEMPCOND_v13 (EnhancedScrollerDemos.MultipleCellTypesDemo.HeaderData), typeof(EnhancedScrollerDemos.MultipleCellTypesDemo.HeaderData), v329 @ X0_v31 (EnhancedScrollerDemos.MultipleCellTypesDemo.Data)\n\tv310 = *([v329 @ X0_v31 (EnhancedScrollerDemos.MultipleCellTypesDemo.Data)+10]);\n\tv363 = 0xB303000 + 0x8E0;\nL_FFFFFFFF:\n\tv373 = v371;\n\tgoto L_016B;\nL_FFFFFFFF:\n\t// -1 IsInst v65_asT @ TEMPCSEL_v5 (EnhancedScrollerDemos.MultipleCellTypesDemo.CellViewRow), typeof(EnhancedScrollerDemos.MultipleCellTypesDemo.CellViewRow), v504 @ X0_v23 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv65 = v65_asT == 0;\n\tif (v65) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv372 = v504;\n\tgoto L_0140;\nL_FFFFFFFF:\n\tv372 = 0;\nL_0145:\n\tv330 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::get_Item(v536, dataIndex);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v90_asT @ TEMPCOND_v10 (EnhancedScrollerDemos.MultipleCellTypesDemo.RowData), typeof(EnhancedScrollerDemos.MultipleCellTypesDemo.RowData), v330 @ X0_v25 (EnhancedScrollerDemos.MultipleCellTypesDemo.Data)\n\tv310 = *([v330 @ X0_v25 (EnhancedScrollerDemos.MultipleCellTypesDemo.Data)+10]);\n\tv363 = 0xB303000 + 0xC60;\nL_FFFFFFFF:\n\tv373 = v372;\n\tUnityEngine.Object::set_name(v373, v331);\n\tv548 = this._data;\nL_FFFFFFFF:\n\tv550 = v373;\nL_0177:\n\tv553 = EnhancedUI.SmallList`1<EnhancedScrollerDemos.MultipleCellTypesDemo.Data>::get_Item(v548, dataIndex);\n\tv438 = *([v550 @ X21_v4 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)]);\n\t*([v438 @ X8_v6 (Il2CppClass<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>)+188])(v562, v550, v553, *([v438 @ X8_v6 (Il2CppClass<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>)+190]), cellIndex, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\treturn v550;\nL_0189:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0103:\n\tv501 = this._data;\nL_016B:\n\tv331 = System.String::Concat(*([v363 @ X8_v4 (System.Int32)]), v310);\nL_0140:\n\tv536 = this._data;\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MultipleCellTypesDemo::GetCellView");
			return default;
		}

		[Token(Token = "0x6000259")]
		[Address(RVA = "0x4032A24", Offset = "0x4032A24", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MultipleCellTypesDemo()
		{
		}
	}
}
