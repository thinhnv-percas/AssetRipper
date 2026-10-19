using AssetRipperInjected;
using Cpp2ILInjected;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.EventSystems;

namespace EnhancedScrollerDemos.FlickSnap
{
	[Token(Token = "0x2000020")]
	public class FlickSnap : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler
	{
		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0x20")]
		public EnhancedScroller scroller;

		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0x28")]
		public EnhancedScroller.TweenType snapTweenType;

		[Token(Token = "0x40000D1")]
		[FieldOffset(Offset = "0x2C")]
		public float snapTweenTime;

		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0x34")]
		private bool _isDragging;

		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0x38")]
		private Vector2 _dragStartPosition;

		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x40")]
		private int _currentIndex;

		[Token(Token = "0x1700001F")]
		[field: Token(Token = "0x40000D2")]
		[field: FieldOffset(Offset = "0x30")]
		public int MaxDataElements
		{
			[Token(Token = "0x60000E8")]
			[Address(RVA = "0x4023E0C", Offset = "0x4023E0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.MaxDataElements;\n")]
			get;
			[Token(Token = "0x60000E9")]
			[Address(RVA = "0x4023E14", Offset = "0x4023E14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.MaxDataElements = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0x4023E1C", Offset = "0x4023E1C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.scroller;\n\tv19 = v14.IsTweening == 0;\n\tv20 = ~v19;\n\tif (v20) goto L_0062;\n\tthis._isDragging = 1;\n\tthis._dragStartPosition = data.position;\n\tgoto L_0025;\n\tgoto L_0056;\nL_FFFFFFFF:\n\tv88 = 0;\n\tgoto L_0057;\nL_0062:\n\treturn;\nL_0025:\n\tv143 = v14.Delegate == 0;\n\tif (v143) goto L_FFFFFFFF;\nL_0056:\n\tv88 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetNumberOfCells(v14.Delegate, v14);\nL_0057:\n\tv199 = v14.StartCellViewIndex / v88;\n\tv99 = v199 * v88;\n\tv97 = v14.StartCellViewIndex - v99;\n\tthis._currentIndex = v97;\n")]
		public void OnBeginDrag(PointerEventData data)
		{
			EnhancedScroller enhancedScroller = scroller;
			if (!enhancedScroller.IsTweening)
			{
				_isDragging = true;
				_dragStartPosition = data.position;
				int num = ((enhancedScroller.Delegate != null) ? enhancedScroller.Delegate.GetNumberOfCells(enhancedScroller) : 0);
				int num2 = enhancedScroller.StartCellViewIndex / num;
				int num3 = num2 * num;
				int currentIndex = enhancedScroller.StartCellViewIndex - num3;
				_currentIndex = currentIndex;
			}
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0x4023F10", Offset = "0x4023F10", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = this._isDragging != 1;\n\tif (v17) goto L_0078;\n\tthis._isDragging = 0;\n\tv73 = data.<position>k__BackingField.y >= this._dragStartPosition.y;\n\tif (v73) goto L_0030;\n\tv75 = this._currentIndex + -1;\n\tv35 = v75 != -1;\n\tif (v35) goto L_0046;\n\tgoto L_0078;\nL_0030:\n\tv36 = data.<position>k__BackingField.y <= this._dragStartPosition.y;\n\tif (v36) goto L_0078;\n\tv75 = this._currentIndex + 1;\n\tv53 = v75 == -1;\n\tif (v53) goto L_0078;\nL_0046:\n\tv131 = this.MaxDataElements - 1;\n\tv176 = v75 - v131;\n\tv177 = v176 < 0;\n\tv179 = v75 ^ v131;\n\tv180 = v75 ^ v176;\n\tv181 = v179 & v180;\n\tv182 = v181 < 0;\n\tv183 = v177 == v182;\n\tv184 = ~v183;\n\tv185 = ~v184;\n\tif (v185) goto L_005B;\nL_FFFFFFFF:\n\tv131 = v75;\n\tgoto L_005B;\nL_FFFFFFFF:\n\tv126 = 0;\n\tgoto L_0073;\nL_FFFFFFFF:\n\tv126 = v131;\nL_0078:\n\treturn;\nL_005B:\n\tv156 = v75 < 0;\n\tv150 = v75 ^ v75;\n\tv148 = v75 & v150;\n\tv146 = v148 < 0;\n\tv189 = v156 == v146;\n\tv144 = ~v189;\n\tv128 = ~v144;\n\tif (v128) goto L_FFFFFFFF;\nL_0073:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::JumpToDataIndex(this.scroller, v126, 0f, 0f, 1, this.snapTweenType, this.snapTweenTime, 0, 0, 0);\n\treturn;\n")]
		public void OnEndDrag(PointerEventData data)
		{
			if (!_isDragging)
			{
				return;
			}
			_isDragging = false;
			int num;
			if (data.position.y < _dragStartPosition.y)
			{
				num = _currentIndex + -1;
				if (num == -1)
				{
					return;
				}
			}
			else
			{
				if (!(data.position.y > _dragStartPosition.y))
				{
					return;
				}
				num = _currentIndex + 1;
				if (num == -1)
				{
					return;
				}
			}
			int num2 = MaxDataElements - 1;
			int num3 = num - num2;
			bool flag = num3 < 0;
			int num4 = num ^ num2;
			int num5 = num ^ num3;
			int num6 = num4 & num5;
			bool flag2 = num6 < 0;
			if (flag != flag2)
			{
				num2 = num;
			}
			bool flag3 = num < 0;
			int num7 = num ^ num;
			int num8 = num & num7;
			bool flag4 = num8 < 0;
			int dataIndex = ((flag3 == flag4) ? num2 : 0);
			scroller.JumpToDataIndex(dataIndex, 0f, 0f, useSpacing: true, snapTweenType, snapTweenTime);
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x4023FC8", Offset = "0x4023FC8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\t*([this @ X0 (EnhancedScrollerDemos.FlickSnap.FlickSnap)+38]) = v48.zero;\n\t*([this @ X0 (EnhancedScrollerDemos.FlickSnap.FlickSnap)+40]) = -1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public FlickSnap()
		{
			_ = Vector2.zero;
			_ = -1;
		}
	}
}
