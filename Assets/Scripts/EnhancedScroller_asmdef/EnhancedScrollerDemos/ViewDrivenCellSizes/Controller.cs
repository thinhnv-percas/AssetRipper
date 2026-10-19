using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.ViewDrivenCellSizes
{
	[Token(Token = "0x200005B")]
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x20")]
		private List<Data> _data;

		[Token(Token = "0x4000179")]
		[FieldOffset(Offset = "0x28")]
		private bool _calculateLayout;

		[Token(Token = "0x400017A")]
		[FieldOffset(Offset = "0x30")]
		public EnhancedScroller scroller;

		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x38")]
		public EnhancedScrollerCellView cellViewPrefab;

		[Token(Token = "0x60001C6")]
		[Address(RVA = "0x402C014", Offset = "0x402C014", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\tv66 = this.scroller;\n\tv66.Delegate = this;\n\tv66._reloadData = 1;\n\tEnhancedScrollerDemos.ViewDrivenCellSizes.Controller::LoadData(this);\n\treturn;\n")]
		private void Start()
		{
			Application.targetFrameRate = 60;
			EnhancedScroller enhancedScroller = scroller;
			enhancedScroller._delegate = this;
			enhancedScroller._reloadData = true;
			LoadData();
		}

		[Token(Token = "0x60001C7")]
		[Address(RVA = "0x402C0C4", Offset = "0x402C0C4", Length = "0x968")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0056;\n\tv148 = 0xA;\n\tgoto L_0074;\nL_0068:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>::Add(v165, v390);\n\tv148 = v148 + 0xB;\n\tv130 = v148 == 0x57;\n\tif (v130) goto L_0305;\nL_0074:\n\tv166 = this._data;\n\tv168 = new EnhancedScrollerDemos.ViewDrivenCellSizes.Data();\n\tEnhancedScrollerDemos.ViewDrivenCellSizes.Data::.ctor(v168);\n\tv168.cellSize = 0f;\n\tv181 = v148 - 0xA;\n\tv182 = v181;\n\tv185 = System.Int32::ToString(&v182 @ stack_-64_v4 (System.Int32));\n\tv482 = System.String::Concat(v185, \" Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam augue enim, scelerisque ac diam nec, efficitur aliquam orci. Vivamus laoreet, libero ut aliquet convallis, dolor elit auctor purus, eget dapibus elit libero at lacus. Aliquam imperdiet sem ultricies ultrices vestibulum. Proin feugiat et dui sit amet ultrices. Quisque porta lacus justo, non ornare nulla eleifend at. Nunc malesuada eget neque sit amet viverra. Donec et lectus ac lorem elementum porttitor. Praesent urna felis, dapibus eu nunc varius, varius tincidunt ante. Vestibulum vitae nulla malesuada, consequat justo eu, dapibus elit. Nulla tristique enim et convallis facilisis.\");\n\tv168.someText = v482;\n\tgoto L_00AF;\nL_00AF:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>::Add(v166, v168);\n\tv467 = this._data;\n\tv372 = new EnhancedScrollerDemos.ViewDrivenCellSizes.Data();\n\tEnhancedScrollerDemos.ViewDrivenCellSizes.Data::.ctor(v372);\n\tv372.cellSize = 0f;\n\tv576 = v148 - 9;\n\tv182 = v576;\n\tv579 = System.Int32::ToString(&v182 @ stack_-64_v4 (System.Int32));\n\tv582 = System.String::Concat(v579, \" Nunc convallis, ipsum a porta viverra, tortor velit feugiat est, eget consectetur ex metus vel diam.\");\n\tv372.someText = v582;\n\tgoto L_00EB;\nL_00EB:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>::Add(v467, v372);\n\tv468 = this._data;\n\tv374 = new EnhancedScrollerDemos.ViewDrivenCellSizes.Data();\n\tEnhancedScrollerDemos.ViewDrivenCellSizes.Data::.ctor(v374);\n\tv374.cellSize = 0f;\n\tv602 = v148 - 8;\n\tv182 = v602;\n\tv605 = System.Int32::ToString(&v182 @ stack_-64_v4 (System.Int32));\n\tv608 = System.String::Concat(v605, \" Phasellus laoreet vitae lectus sit amet venenatis. Duis scelerisque ultricies tincidunt. Cras ullamcorper lectus sed risus porttitor, id viverra urna venenatis. Maecenas in odio sed mi tempus porta et a justo. Nullam non ullamcorper est. Nam rhoncus nulla quis commodo aliquam. Maecenas pulvinar est sed ex iaculis, eu pretium tellus placerat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Praesent in ipsum faucibus, fringilla lectus id, congue est. \");\n\tv374.someText = v608;\n\tgoto L_0127;\nL_0127:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>::Add(v468, v374);\n\tv469 = this._data;\n\tv376 = new EnhancedScrollerDemos.ViewDrivenCellSizes.Data();\n\tEnhancedScrollerDemos.ViewDrivenCellSizes.Data::.ctor(v376);\n\tv376.cellSize = 0f;\n\tv628 = v148 - 7;\n\tv182 = v628;\n\tv631 = System.Int32::ToString(&v182 @ stack_-64_v4 (System.Int32));\n\tv634 = System.String::Concat(v631, \" Fusce ex lectus.\");\n\tv376.someText = v634;\n\tgoto L_0163;\nL_0163:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>::Add(v469, v376);\n\tv470 = this._data;\n\tv378 = new EnhancedScrollerDemos.ViewDrivenCellSizes.Data();\n\tEnhancedScrollerDemos.ViewDrivenCellSizes.Data::.ctor(v378);\n\tv378.cellSize = 0f;\n\tv654 = v148 - 6;\n\tv182 = v654;\n\tv657 = System.Int32::ToString(&v182 @ stack_-64_v4 (System.Int32));\n\tv660 = System.String::Concat(v657, \" Fusce mollis elementum sem euismod malesuada. Aenean et convallis turpis. Suspendisse potenti.\");\n\tv378.someText = v660;\n\tgoto L_019F;\nL_019F:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>::Add(v470, v378);\n\tv471 = this._data;\n\tv380 = new EnhancedScrollerDemos.ViewDrivenCellSizes.Data();\n\tEnhancedScrollerDemos.ViewDrivenCellSizes.Data::.ctor(v380);\n\tv380.cellSize = 0f;\n\tv680 = v148 - 5;\n\tv182 = v680;\n\tv683 = System.Int32::ToString(&v182 @ stack_-64_v4 (System.Int32));\n\tv686 = System.String::Concat(v683, \" Fusce nec sapien orci. Pellentesque mollis ligula vitae interdum imperdiet. Aenean ultricies velit at turpis luctus, nec lacinia ligula malesuada. Nulla facilisi. Donec at nisi lorem. Aenean vestibulum velit velit, sed eleifend dui sodales in. Nunc vulputate, nulla non facilisis hendrerit, neque dolor lacinia orci, et fermentum nunc quam vel purus. Donec gravida massa non ullamcorper consectetur. Sed pellentesque leo ac ornare egestas. \");\n\tv380.someText = v686;\n\tgoto L_01DB;\nL_01DB:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>::Add(v471, v380);\n\tv472 = this._data;\n\tv382 = new EnhancedScrollerDemos.ViewDrivenCellSizes.Data();\n\tEnhancedScrollerDemos.ViewDrivenCellSizes.Data::.ctor(v382);\n\tv382.cellSize = 0f;\n\tv706 = v148 - 4;\n\tv182 = v706;\n\tv709 = System.Int32::ToString(&v182 @ stack_-64_v4 (System.Int32));\n\tv712 = System.String::Concat(v709, \" Curabitur non dignissim turpis, vel viverra elit. Cras in sem rhoncus, gravida velit ut, consectetur erat. Proin ac aliquet nulla. Mauris quis augue nisi. Sed purus magna, mollis sed massa ac, scelerisque lobortis leo. Nullam at facilisis ex. Nullam ut accumsan orci. Integer vitae dictum felis, quis tristique sem. Suspendisse potenti. Curabitur bibendum eleifend eros at porta. Ut malesuada consectetur arcu nec lacinia. \");\n\tv382.someText = v712;\n\tgoto L_0217;\nL_0217:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>::Add(v472, v382);\n\tv473 = this._data;\n\tv384 = new EnhancedScrollerDemos.ViewDrivenCellSizes.Data();\n\tEnhancedScrollerDemos.ViewDrivenCellSizes.Data::.ctor(v384);\n\tv384.cellSize = 0f;\n\tv456 = v148 - 3;\n\tv182 = v456;\n\tv734 = System.Int32::ToString(&v182 @ stack_-64_v4 (System.Int32));\n\tv736 = System.String::Concat(v734, \" Pellentesque pulvinar ac arcu fermentum interdum. Pellentesque gravida faucibus ipsum at blandit. Vestibulum pharetra erat sit amet feugiat sodales. Nunc et dui viverra tellus efficitur egestas. Sed ex mauris, eleifend in nisi sed, consequat tincidunt elit. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel bibendum enim. Etiam feugiat nulla ac dui commodo, eget vehicula est scelerisque. In metus neque, congue a justo ac, consequat lacinia neque. Vivamus non velit vitae ex dictum pharetra. Aliquam blandit nisi eget libero feugiat porta. \");\n\tv384.someText = v736;\n\tgoto L_0251;\nL_0251:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>::Add(v473, v384);\n\tv474 = this._data;\n\tv386 = new EnhancedScrollerDemos.ViewDrivenCellSizes.Data();\n\tEnhancedScrollerDemos.ViewDrivenCellSizes.Data::.ctor(v386);\n\tv386.cellSize = 0f;\n\tv459 = v148 - 2;\n\tv182 = v459;\n\tv758 = System.Int32::ToString(&v182 @ stack_-64_v4 (System.Int32));\n\tv760 = System.String::Concat(v758, \" Proin bibendum ligula a pulvinar convallis. Mauris tincidunt tempor ipsum id viverra. Vivamus congue ipsum venenatis tellus semper, vel venenatis mauris finibus. Vivamus a nisl in lacus fermentum varius. Mauris bibendum magna placerat risus interdum, vitae facilisis nulla pellentesque. Curabitur vehicula odio quis magna pulvinar, et lacinia ante bibendum. Morbi laoreet eleifend ante, quis luctus augue luctus sit amet. Sed consectetur enim et orci posuere euismod. Curabitur sollicitudin metus eu nisl dictum suscipit. \");\n\tv386.someText = v760;\n\tgoto L_028B;\nL_028B:\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>::Add(v474, v386);\n\tv475 = this._data;\n\tv388 = new EnhancedScrollerDemos.ViewDrivenCellSizes.Data();\n\tEnhancedScrollerDemos.ViewDrivenCellSizes.Data::.ctor(v388);\n\tv388.cellSize = 0f;\n\tv462 = v148 - 1;\n\tv182 = v462;\n\tv782 = System.Int32::ToString(&v182 @ stack_-64_v4 (System.Int32));\n\tv784 = System.String::Concat(v782, \" Sed gravida augue ligula, tempus auctor ante rutrum sit amet. Vestibulum finibus magna ut viverra rhoncus. Vestibulum rutrum eu nibh interdum imperdiet. Curabitur ac nunc\n// ... truncated")]
		private void LoadData()
		{
			List<Data> data = new List<Data>();
			_data = data;
			int num = 10;
			do
			{
				List<Data> data2 = _data;
				Data data3 = new Data();
				data3.cellSize = 0f;
				int num2 = num - 10;
				int num3 = num2;
				string text = num3.ToString();
				string someText = text + " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam augue enim, scelerisque ac diam nec, efficitur aliquam orci. Vivamus laoreet, libero ut aliquet convallis, dolor elit auctor purus, eget dapibus elit libero at lacus. Aliquam imperdiet sem ultricies ultrices vestibulum. Proin feugiat et dui sit amet ultrices. Quisque porta lacus justo, non ornare nulla eleifend at. Nunc malesuada eget neque sit amet viverra. Donec et lectus ac lorem elementum porttitor. Praesent urna felis, dapibus eu nunc varius, varius tincidunt ante. Vestibulum vitae nulla malesuada, consequat justo eu, dapibus elit. Nulla tristique enim et convallis facilisis.";
				data3.someText = someText;
				data2.Add(data3);
				List<Data> data4 = _data;
				Data data5 = new Data();
				data5.cellSize = 0f;
				int num4 = num - 9;
				num3 = num4;
				string text2 = num3.ToString();
				string someText2 = text2 + " Nunc convallis, ipsum a porta viverra, tortor velit feugiat est, eget consectetur ex metus vel diam.";
				data5.someText = someText2;
				data4.Add(data5);
				List<Data> data6 = _data;
				Data data7 = new Data();
				data7.cellSize = 0f;
				int num5 = num - 8;
				num3 = num5;
				string text3 = num3.ToString();
				string someText3 = text3 + " Phasellus laoreet vitae lectus sit amet venenatis. Duis scelerisque ultricies tincidunt. Cras ullamcorper lectus sed risus porttitor, id viverra urna venenatis. Maecenas in odio sed mi tempus porta et a justo. Nullam non ullamcorper est. Nam rhoncus nulla quis commodo aliquam. Maecenas pulvinar est sed ex iaculis, eu pretium tellus placerat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Praesent in ipsum faucibus, fringilla lectus id, congue est. ";
				data7.someText = someText3;
				data6.Add(data7);
				List<Data> data8 = _data;
				Data data9 = new Data();
				data9.cellSize = 0f;
				int num6 = num - 7;
				num3 = num6;
				string text4 = num3.ToString();
				string someText4 = text4 + " Fusce ex lectus.";
				data9.someText = someText4;
				data8.Add(data9);
				List<Data> data10 = _data;
				Data data11 = new Data();
				data11.cellSize = 0f;
				int num7 = num - 6;
				num3 = num7;
				string text5 = num3.ToString();
				string someText5 = text5 + " Fusce mollis elementum sem euismod malesuada. Aenean et convallis turpis. Suspendisse potenti.";
				data11.someText = someText5;
				data10.Add(data11);
				List<Data> data12 = _data;
				Data data13 = new Data();
				data13.cellSize = 0f;
				int num8 = num - 5;
				num3 = num8;
				string text6 = num3.ToString();
				string someText6 = text6 + " Fusce nec sapien orci. Pellentesque mollis ligula vitae interdum imperdiet. Aenean ultricies velit at turpis luctus, nec lacinia ligula malesuada. Nulla facilisi. Donec at nisi lorem. Aenean vestibulum velit velit, sed eleifend dui sodales in. Nunc vulputate, nulla non facilisis hendrerit, neque dolor lacinia orci, et fermentum nunc quam vel purus. Donec gravida massa non ullamcorper consectetur. Sed pellentesque leo ac ornare egestas. ";
				data13.someText = someText6;
				data12.Add(data13);
				List<Data> data14 = _data;
				Data data15 = new Data();
				data15.cellSize = 0f;
				int num9 = num - 4;
				num3 = num9;
				string text7 = num3.ToString();
				string someText7 = text7 + " Curabitur non dignissim turpis, vel viverra elit. Cras in sem rhoncus, gravida velit ut, consectetur erat. Proin ac aliquet nulla. Mauris quis augue nisi. Sed purus magna, mollis sed massa ac, scelerisque lobortis leo. Nullam at facilisis ex. Nullam ut accumsan orci. Integer vitae dictum felis, quis tristique sem. Suspendisse potenti. Curabitur bibendum eleifend eros at porta. Ut malesuada consectetur arcu nec lacinia. ";
				data15.someText = someText7;
				data14.Add(data15);
				List<Data> data16 = _data;
				Data data17 = new Data();
				data17.cellSize = 0f;
				int num10 = num - 3;
				num3 = num10;
				string text8 = num3.ToString();
				string someText8 = text8 + " Pellentesque pulvinar ac arcu fermentum interdum. Pellentesque gravida faucibus ipsum at blandit. Vestibulum pharetra erat sit amet feugiat sodales. Nunc et dui viverra tellus efficitur egestas. Sed ex mauris, eleifend in nisi sed, consequat tincidunt elit. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel bibendum enim. Etiam feugiat nulla ac dui commodo, eget vehicula est scelerisque. In metus neque, congue a justo ac, consequat lacinia neque. Vivamus non velit vitae ex dictum pharetra. Aliquam blandit nisi eget libero feugiat porta. ";
				data17.someText = someText8;
				data16.Add(data17);
				List<Data> data18 = _data;
				Data data19 = new Data();
				data19.cellSize = 0f;
				int num11 = num - 2;
				num3 = num11;
				string text9 = num3.ToString();
				string someText9 = text9 + " Proin bibendum ligula a pulvinar convallis. Mauris tincidunt tempor ipsum id viverra. Vivamus congue ipsum venenatis tellus semper, vel venenatis mauris finibus. Vivamus a nisl in lacus fermentum varius. Mauris bibendum magna placerat risus interdum, vitae facilisis nulla pellentesque. Curabitur vehicula odio quis magna pulvinar, et lacinia ante bibendum. Morbi laoreet eleifend ante, quis luctus augue luctus sit amet. Sed consectetur enim et orci posuere euismod. Curabitur sollicitudin metus eu nisl dictum suscipit. ";
				data19.someText = someText9;
				data18.Add(data19);
				List<Data> data20 = _data;
				Data data21 = new Data();
				data21.cellSize = 0f;
				int num12 = num - 1;
				num3 = num12;
				string text10 = num3.ToString();
				string someText10 = text10 + " Sed gravida augue ligula, tempus auctor ante rutrum sit amet. Vestibulum finibus magna ut viverra rhoncus. Vestibulum rutrum eu nibh interdum imperdiet. Curabitur ac nunc a turpis ultricies dictum. Phasellus in molestie eros. Morbi porta imperdiet odio sed pharetra. Cras blandit tincidunt ultricies. ";
				data21.someText = someText10;
				data20.Add(data21);
				List<Data> data22 = _data;
				Data data23 = new Data();
				data23.cellSize = 0f;
				num3 = num;
				string text11 = num3.ToString();
				string someText11 = text11 + " Integer pellentesque viverra orci, sollicitudin luctus dui rhoncus sed. Duis placerat at felis vel placerat. Mauris massa urna, scelerisque vitae posuere vitae, ultrices in nibh. Mauris posuere hendrerit viverra. In lacinia urna nibh, ut lobortis lectus finibus et. Aliquam arcu dolor, suscipit eget massa id, eleifend dapibus est. Quisque eget bibendum urna. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum pulvinar ornare. Aliquam venenatis eget nunc et euismod. ";
				data23.someText = someText11;
				data22.Add(data23);
				num += 11;
			}
			while (num != 87);
			ResizeScroller();
		}

		[Token(Token = "0x60001C8")]
		[Address(RVA = "0x402CAF4", Offset = "0x402CAF4", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ClearActive(this.scroller);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ClearRecycled(this.scroller);\n\tv175 = this.scroller == 0;\n\tv132 = &v117 @ stack_-60_v3 (System.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>);\n\tv143 = 0;\n\tv144 = Il2CppMethodInfo;\n\tv155 = v157;\n\tv158 = v160;\n\tif (v175) goto L_00C1;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollPosition(this.scroller, 0f);\n\tv176 = this._data == 0;\n\tv132 = v134;\n\tv144 = methodInfo;\n\tv155 = v3;\n\tv158 = v1;\n\tif (v176) goto L_00C1;\n\tv160 = 0xB28D000 + 0x18;\n\tv157 = 0xB2E5000 + 0xF00;\n\tv248 = System.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>::GetEnumerator(this._data);\n\tv125 = v248.Current;\n\tv117 = v248._list;\n\tv125.cellSize = 0f;\n\tgoto L_0059;\nL_0064:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v117 @ stack_-60_v3 (System.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>));\n\tv135 = &v117 @ stack_-60_v3 (System.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>);\n\tv143 = 0;\nL_0065:\n\tv151 = this._data;\n\tv169 = new *([v160 @ X24_v2 (System.Int32)])();\n\tEnhancedScrollerDemos.ViewDrivenCellSizes.Data::.ctor(v169);\n\tv177 = v169 == 0;\n\tv132 = v134;\n\tv144 = methodInfo;\n\tv155 = v3;\n\tv158 = v1;\n\tif (v177) goto L_00C1;\n\tv169.cellSize = 0f;\n\tv186 = this._data;\n\tv178 = this._data == 0;\n\tv132 = v135;\n\tv144 = 0;\n\tv155 = v157;\n\tv158 = v160;\n\tif (v178) goto L_00C1;\n\tv111 = v186.Count;\n\tv336 = System.Int32::ToString(&v111 @ stack_-64_v4 (System.Int32));\n\tv338 = System.String::Concat(v336, *([v157 @ X23_v2 (System.Int32)]));\n\tv169.someText = v338;\n\tv179 = this._data == 0;\n\tv132 = v135;\n\tv144 = 0;\n\tv155 = v157;\n\tv158 = v160;\n\tif (v179) goto L_00C1;\n\tv342 = v151._version + 1;\n\tv151._version = v342;\n\tv180 = v151._items == 0;\n\tv132 = v135;\n\tv144 = v338;\n\tv155 = v157;\n\tv158 = v160;\n\tif (v180) goto L_00C1;\n\tgoto L_009C;\nL_009C:\n\t;\n\tSystem.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>::Add(this._data, v169);\n\tv148 = v169;\n\tEnhancedScrollerDemos.ViewDrivenCellSizes.Controller::ResizeScroller(this);\n\tv189 = this._data;\n\tv181 = this._data == 0;\n\tv132 = v135;\n\tv144 = v338;\n\tv155 = v157;\n\tv158 = v160;\n\tif (v181) goto L_00C1;\n\tv182 = this.scroller == 0;\n\tv132 = v135;\n\tv144 = v148;\n\tv155 = v157;\n\tv158 = v160;\n\tif (v182) goto L_00C1;\n\tv312 = v189.Count - 1;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::JumpToDataIndex(this.scroller, v312, 1f, 1f, 1, 0, 0f, 0, 0, 0);\n\treturn;\nL_00CD:\n\tv211 = v144 != 1;\n\tv225 = v193;\n\tif (v211) goto L_00DD;\n\tv216 = 0x8BF5BC4(v193, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv233 = 0x8BF5BF4(v216, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v132);\n\tv224 = *([v216 @ X0_v11]) == 0;\n\tv135 = v132;\n\tv143 = *([v216 @ X0_v11]);\n\tv157 = v155;\n\tv160 = v158;\n\tif (v224) goto L_0065;\n\tv222 = new System.OutOfMemoryException();\n\tv143 = *([v216 @ X0_v11]);\n\tv225 = v222;\n\treturn;\nL_002D:\n\tv49 = this.scroller == 0;\n\tv132 = v135;\n\tv144 = v148;\n\tv155 = v157;\n\tv158 = v160;\n\tif (v49) goto L_00C1;\nL_00C1:\n\tv193 = new System.NullReferenceException();\n\tgoto L_00CD;\nL_0059:\n\tv259 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v117 @ stack_-60_v3 (System.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>));\n\tv270 = v259 == 0;\n\tif (v270) goto L_0064;\nL_00DD:\n\tv228 = 0x319ACC8(&v143 @ stack_-80_v4 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv235 = 0x8BF0368(v225, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv250 = 0xA1B8(v235, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void AddNewRow()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Controller::AddNewRow");
		}

		[Token(Token = "0x60001C9")]
		[Address(RVA = "0x402CA2C", Offset = "0x402CA2C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tv47 = UnityEngine.Component::GetComponent(this.scroller);\n\tv62 = UnityEngine.RectTransform::get_sizeDelta(v47);\n\t// 39 MakeStruct v53 @ AGG402CAA0_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v62 @ V0_v2 (UnityEngine.Vector2), 2139095039\n\tUnityEngine.RectTransform::set_sizeDelta(v47, v53);\n\tthis._calculateLayout = 1;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\tUnityEngine.RectTransform::set_sizeDelta(v47, v62);\n\tthis._calculateLayout = 0;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this.scroller, 0f);\n\treturn;\n")]
		private void ResizeScroller()
		{
			RectTransform component = scroller.GetComponent<RectTransform>();
			Vector2 sizeDelta = component.sizeDelta;
			Vector2 sizeDelta2 = default(Vector2);
			sizeDelta2.x = sizeDelta.x;
			sizeDelta2.y = 3.4028235E+38f;
			component.sizeDelta = sizeDelta2;
			_calculateLayout = true;
			scroller.ReloadData();
			component.sizeDelta = sizeDelta;
			_calculateLayout = false;
			scroller.ReloadData();
		}

		[Token(Token = "0x60001CA")]
		[Address(RVA = "0x402CDAC", Offset = "0x402CDAC", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\treturn v38.Count;\nL_0012:\n\tv38 = this._data;\n")]
		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			List<Data> data = _data;
			return data.Count;
		}

		[Token(Token = "0x60001CB")]
		[Address(RVA = "0x402CDF8", Offset = "0x402CDF8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = System.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>::get_Item(this._data, dataIndex);\n\treturn v49.cellSize;\n")]
		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			Data data = _data[dataIndex];
			return data.cellSize;
		}

		[Token(Token = "0x60001CC")]
		[Address(RVA = "0x402CE68", Offset = "0x402CE68", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv50 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetCellView(scroller, this.cellViewPrefab);\n\tv135 = v50 == 0;\n\tif (v135) goto L_0031;\n\tgoto L_FFFFFFFF;\nL_0031:\n\tv185 = this._data;\n\tv148 = this._data == 0;\n\tv123 = ~v148;\nL_FFFFFFFF:\n\tv132 = 0;\n\tif (v123) goto L_0050;\n\tgoto L_0060;\nL_FFFFFFFF:\n\t// -1 IsInst v56_asT @ TEMPCSEL_v3 (EnhancedScrollerDemos.ViewDrivenCellSizes.CellView), typeof(EnhancedScrollerDemos.ViewDrivenCellSizes.CellView), v50 @ X0_v5 (EnhancedUI.EnhancedScroller.EnhancedScrollerCellView)\n\tv56 = v56_asT == 0;\n\tif (v56) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv133 = v50;\n\tgoto L_0049;\nL_FFFFFFFF:\n\tv133 = 0;\nL_0050:\n\tv120 = System.Collections.Generic.List`1<EnhancedScrollerDemos.ViewDrivenCellSizes.Data>::get_Item(v185, dataIndex);\n\tEnhancedScrollerDemos.ViewDrivenCellSizes.CellView::SetData(v132, v120, this._calculateLayout);\n\treturn v132;\nL_0060:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0049:\n\tv185 = this._data;\nL_FFFFFFFF:\n\tv132 = v133;\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			EnhancedScrollerCellView cellView = scroller.GetCellView(cellViewPrefab);
			List<Data> data;
			CellView cellView2;
			if ((object)cellView == null)
			{
				data = _data;
				bool flag = _data == null;
				bool flag2 = !flag;
				cellView2 = null;
				if (!flag2)
				{
					return (EnhancedScrollerCellView)(object)new NullReferenceException();
				}
			}
			else
			{
				EnhancedScrollerCellView enhancedScrollerCellView = ((!(cellView is CellView)) ? null : cellView);
				data = _data;
				cellView2 = (CellView)enhancedScrollerCellView;
			}
			Data data2 = data[dataIndex];
			cellView2.SetData(data2, _calculateLayout);
			return cellView2;
		}

		[Token(Token = "0x60001CD")]
		[Address(RVA = "0x402CF50", Offset = "0x402CF50", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Controller()
		{
		}
	}
}
