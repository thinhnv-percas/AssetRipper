using System;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.ExpandingCells
{
	[Token(Token = "0x2000025")]
	public class CellView : EnhancedScrollerCellView
	{
		[Token(Token = "0x40000EB")]
		[FieldOffset(Offset = "0x38")]
		private Tween tween;

		[Token(Token = "0x40000EC")]
		[FieldOffset(Offset = "0x40")]
		private LayoutElement layoutElement;

		[Token(Token = "0x40000ED")]
		[FieldOffset(Offset = "0x48")]
		private Data data;

		[Token(Token = "0x40000EE")]
		[FieldOffset(Offset = "0x50")]
		public Text dataIndexText;

		[Token(Token = "0x40000EF")]
		[FieldOffset(Offset = "0x58")]
		public Text headerText;

		[Token(Token = "0x40000F0")]
		[FieldOffset(Offset = "0x60")]
		public Text descriptionText;

		[Token(Token = "0x40000F1")]
		[FieldOffset(Offset = "0x68")]
		public Action<int, int> initializeTween;

		[Token(Token = "0x40000F2")]
		[FieldOffset(Offset = "0x70")]
		public Action<int, int, float, float> updateTween;

		[Token(Token = "0x40000F3")]
		[FieldOffset(Offset = "0x78")]
		public Action<int, int> endTween;

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0x4024C20", Offset = "0x4024C20", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tthis.layoutElement = v58;\n\treturn;\nL_001D:\n\tv49 = UnityEngine.Component::GetComponent(this);\n\tthis.tween = v49;\n\tv58 = UnityEngine.Component::GetComponent(this);\n")]
		private void Start()
		{
			Tween component = GetComponent<Tween>();
			tween = component;
			LayoutElement component2 = GetComponent<LayoutElement>();
			layoutElement = component2;
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0x4024CB4", Offset = "0x4024CB4", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = dataIndex;\n\tthis.dataIndex = dataIndex;\n\tthis.initializeTween = initializeTween;\n\tthis.updateTween = updateTween;\n\tthis.endTween = endTween;\n\tv50 = System.Int32::ToString(&v22 @ stack_-34_v1 (System.Int32));\n\tv57 = UnityEngine.UI.Text::set_text(this.dataIndexText, v50);\n\tv82 = UnityEngine.UI.Text::set_text(this.headerText, data.headerText);\n\tv104 = UnityEngine.UI.Text::set_text(this.descriptionText, data.descriptionText);\n\tUnityEngine.Behaviour::set_enabled(this.descriptionText, data.isExpanded);\n\tthis.data = data;\n\treturn;\n")]
		public void SetData(Data data, int dataIndex, float collapsedSize, float expandedSize, Action<int, int> initializeTween, Action<int, int, float, float> updateTween, Action<int, int> endTween)
		{
			int num = dataIndex;
			base.dataIndex = dataIndex;
			this.initializeTween = initializeTween;
			this.updateTween = updateTween;
			this.endTween = endTween;
			string text = num.ToString();
			dataIndexText.text = text;
			headerText.text = data.headerText;
			descriptionText.text = data.descriptionText;
			descriptionText.enabled = data.isExpanded;
			this.data = data;
		}

		[Token(Token = "0x60000FD")]
		[Address(RVA = "0x4024DB4", Offset = "0x4024DB4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.initializeTween == 0;\n\tif (v2) goto L_0009;\n\tSystem.Action`2<System.Int32, System.Int32>::Invoke(this.initializeTween, this.dataIndex, this.cellIndex);\n\treturn;\nL_0009:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CellButton_Clicked()
		{
			if (initializeTween != null)
			{
				initializeTween(dataIndex, cellIndex);
			}
		}

		[Token(Token = "0x60000FE")]
		[Address(RVA = "0x4024DD4", Offset = "0x4024DD4", Length = "0x328")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_0028:\n\tUnityEngine.Behaviour::set_enabled(this.descriptionText, 0);\n\tv144 = this.data;\n\tv160 = v144.isExpanded == 0;\n\tif (v160) goto L_0077;\n\tv129 = UnityEngine.UI.LayoutElement::set_minHeight(this.layoutElement, v144.collapsedSize);\n\tv255 = this.data;\n\tv247 = v255.tweenType == 0;\n\tif (v247) goto L_00DF;\n\tv252 = new System.Action`2<System.Single, System.Single>();\n\tSystem.Action`2<System.Single, System.Single>::.ctor(v252, this, Il2CppMethodInfo);\n\tv130 = new System.Action();\n\tSystem.Action::.ctor(v130, this, Il2CppMethodInfo);\n\tgoto L_0067;\n\tv303.tweenType = v255.tweenType;\n\tv303.time = v255.tweenTimeExpand;\n\tv303.start = v255.collapsedSize;\n\tv325 = v303;\n\tv326 = v130;\n\tv334 = v252;\n\tgoto L_00BB;\nL_0077:\n\t;\n\tv131 = UnityEngine.UI.LayoutElement::set_minHeight(this.layoutElement, v144.expandedSize);\n\tv255 = this.data;\n\tv248 = v255.tweenType == 0;\n\tif (v248) goto L_00DF;\n\tv260 = new System.Action`2<System.Single, System.Single>();\n\tSystem.Action`2<System.Single, System.Single>::.ctor(v260, this, Il2CppMethodInfo);\n\tv132 = new System.Action();\n\tSystem.Action::.ctor(v132, this, Il2CppMethodInfo);\n\tgoto L_00AB;\n\tv311.tweenType = v255.tweenType;\n\tv311.time = v255.tweenTimeCollapse;\n\t// 183 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv311.start = v144.expandedSize;\n\tv325 = v311;\n\tv326 = v132;\n\tv334 = v260;\n\treturn;\nL_00DF:\n\tv64 = v255.isExpanded != 1;\n\tif (v64) goto L_00E7;\n\tUnityEngine.Behaviour::set_enabled(this.descriptionText, 1);\nL_00E7:\n\t;\n\tv229 = this.endTween == 0;\n\tif (v229) goto L_010A;\n\tSystem.Action`2<System.Int32, System.Int32>::Invoke(this.endTween, this.dataIndex, this.cellIndex);\n\treturn;\nL_010A:\n\treturn;\nL_0067:\n\tv303 = new EnhancedUI.EnhancedScroller.Tween+<TweenPosition>d__2();\n\tSystem.Object::.ctor(v303);\n\tv303.<>1__state = 0;\n\tv303.<>4__this = this.tween;\nL_00BB:\n\tv325.tweenUpdated = v334;\n\tv325.tweenComplete = v326;\n\tv224 = UnityEngine.MonoBehaviour::StartCoroutine(this, v325);\nL_00AB:\n\tv311 = new EnhancedUI.EnhancedScroller.Tween+<TweenPosition>d__2();\n\tSystem.Object::.ctor(v311);\n\tv311.<>1__state = 0;\n\tv311.<>4__this = this.tween;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void BeginTween()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CellView::BeginTween");
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0x4025168", Offset = "0x4025168", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = UnityEngine.UI.LayoutElement::get_minHeight(this.layoutElement);\n\tv39 = newValue + delta;\n\tv44 = UnityEngine.UI.LayoutElement::set_minHeight(this.layoutElement, v39);\n\tv45 = this.updateTween;\n\tv46 = this.updateTween == 0;\n\tif (v46) goto L_0032;\n\tSystem.Action`4<System.Int32, System.Int32, System.Single, System.Single>::Invoke(this.updateTween, this.dataIndex, this.cellIndex, v45.method, v45.invoke_impl);\n\treturn;\nL_0032:\n\treturn;\n")]
		private void TweenUpdated(float newValue, float delta)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CellView::TweenUpdated");
		}

		[Token(Token = "0x6000100")]
		[Address(RVA = "0x40250FC", Offset = "0x40250FC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.data;\n\tv24 = v10.isExpanded != 1;\n\tif (v24) goto L_001C;\n\tUnityEngine.Behaviour::set_enabled(this.descriptionText, 1);\nL_001C:\n\t;\n\tv72 = this.endTween == 0;\n\tif (v72) goto L_002F;\n\tSystem.Action`2<System.Int32, System.Int32>::Invoke(this.endTween, this.dataIndex, this.cellIndex);\n\treturn;\nL_002F:\n\treturn;\n")]
		private void TweenCompleted()
		{
			Data data = this.data;
			if (data.isExpanded)
			{
				descriptionText.enabled = true;
			}
			if (endTween != null)
			{
				endTween(dataIndex, cellIndex);
			}
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0x40251FC", Offset = "0x40251FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CellView()
		{
		}
	}
}
