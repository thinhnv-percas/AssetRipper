using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Services;

namespace _game.CoreGameKit.Tools.DebugMenu
{
	[Token(Token = "0x20005AD")]
	public class DebugMenuController : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20005AE")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400138B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400138C")]
			public static Func<IDebugModule, bool> _003C_003E9__13_0;

			[Token(Token = "0x400138D")]
			public static Func<IDebugModule, int> _003C_003E9__13_1;

			[Token(Token = "0x6001846")]
			[Address(RVA = "0x3D369DC", Offset = "0x3D369DC", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001847")]
			[Address(RVA = "0x3D36A40", Offset = "0x3D36A40", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CInitialize_003Eb__13_0(IDebugModule m)
			{
				bool flag = m == null;
				return !flag;
			}

			internal int _003CInitialize_003Eb__13_1(IDebugModule m)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("DebugMenuController._003C_003Ec::_003CInitialize_003Eb__13_1");
				return default;
			}
		}

		[Token(Token = "0x4001380")]
		private const float k_PanelWidthRatio = 0.94f;

		[Token(Token = "0x4001381")]
		private const float k_PanelHeightRatio = 0.86f;

		[Token(Token = "0x4001382")]
		private const float k_TopMarginVirtual = 60f;

		[Token(Token = "0x4001383")]
		private const float k_TabBarHeight = 38f;

		[Token(Token = "0x4001384")]
		private const float k_HeaderHeight = 44f;

		[Token(Token = "0x4001385")]
		private const float k_Padding = 8f;

		[Token(Token = "0x4001386")]
		[FieldOffset(Offset = "0x20")]
		internal IDebugModule[] _modules;

		[Inject(true)]
		[Token(Token = "0x4001387")]
		[FieldOffset(Offset = "0x28")]
		private InputBlockService _inputBlockService;

		[Token(Token = "0x4001388")]
		[FieldOffset(Offset = "0x30")]
		private IDisposable _inputBlock;

		[Token(Token = "0x4001389")]
		[FieldOffset(Offset = "0x38")]
		private int _activeIndex;

		[Token(Token = "0x400138A")]
		[FieldOffset(Offset = "0x3C")]
		private bool _isOpen;

		[Token(Token = "0x1700023B")]
		public bool IsOpen
		{
			[Token(Token = "0x600183A")]
			[Address(RVA = "0x3D3475C", Offset = "0x3D3475C", Length = "0x8")]
			get
			{
				return _isOpen;
			}
		}

		[Token(Token = "0x1700023C")]
		public IEnumerable<IDebugModule> Modules
		{
			[Token(Token = "0x600183F")]
			[Address(RVA = "0x3D34D40", Offset = "0x3D34D40", Length = "0x8")]
			get
			{
				return _modules;
			}
		}

		[Inject(false)]
		[Token(Token = "0x600183B")]
		[Address(RVA = "0x3D34764", Offset = "0x3D34764", Length = "0x2D4")]
		private void Initialize(IEnumerable<IDebugModule> modules)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugMenuController::Initialize");
		}

		[Token(Token = "0x600183C")]
		[Address(RVA = "0x3D34A38", Offset = "0x3D34A38", Length = "0x10")]
		public void Toggle()
		{
			bool open = !IsOpen;
			SetOpen(open);
		}

		[Token(Token = "0x600183D")]
		[Address(RVA = "0x3D34A48", Offset = "0x3D34A48", Length = "0x248")]
		public void SetOpen(bool open)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugMenuController::SetOpen");
		}

		[Token(Token = "0x600183E")]
		[Address(RVA = "0x3D34C90", Offset = "0x3D34C90", Length = "0xB0")]
		private void OnDisable()
		{
			if (_inputBlock != null)
			{
				_inputBlock.Dispose();
			}
			_inputBlock = null;
		}

		[Token(Token = "0x6001840")]
		[Address(RVA = "0x3D34D48", Offset = "0x3D34D48", Length = "0x290")]
		private unsafe void OnGUI()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugMenuController::OnGUI");
		}

		[Token(Token = "0x6001841")]
		[Address(RVA = "0x3D35D30", Offset = "0x3D35D30", Length = "0x2E4")]
		private void DrawHeader(Rect panelRect)
		{
			Color color = default(Color);
			color.r = DebugMenuStyle.BgHeader.r;
			color.g = DebugMenuStyle.BgHeader.g;
			color.b = DebugMenuStyle.BgHeader.b;
			color.a = DebugMenuStyle.BgHeader.a;
			Texture2D image = TextureCache.Get(color);
			Rect position = default(Rect);
			position.x = panelRect.x;
			position.y = panelRect.y;
			position.width = panelRect.width;
			position.height = 44f;
			GUI.DrawTexture(position, image);
			float x = panelRect.x + 16f;
			float width = panelRect.width + -60f;
			DebugMenuStyle.EnsureInit();
			Rect position2 = default(Rect);
			position2.x = x;
			position2.y = panelRect.y;
			position2.width = width;
			position2.height = 44f;
			GUI.Label(position2, "Debug Menu", DebugMenuStyle.s_title);
			float num = panelRect.width + panelRect.x;
			float num2 = num + 2.72E-43f;
			float x2 = num2 + -8f;
			float y = panelRect.y + 6f;
			DebugMenuStyle.EnsureInit();
			Rect position3 = default(Rect);
			position3.x = x2;
			position3.y = y;
			position3.width = 9.2E-44f;
			position3.height = 9.2E-44f;
			if (GUI.Button(position3, "X", DebugMenuStyle.s_closeButton))
			{
				SetOpen(open: false);
			}
			Color color2 = GUI.color;
			Color color3 = default(Color);
			color3.r = DebugMenuStyle.Accent.r;
			color3.g = DebugMenuStyle.Accent.g;
			color3.b = DebugMenuStyle.Accent.b;
			color3.a = DebugMenuStyle.Accent.a;
			GUI.color = color3;
			float y2 = panelRect.y + 44f;
			Texture2D white = TextureCache.White;
			Rect position4 = default(Rect);
			position4.x = panelRect.x;
			position4.y = y2;
			position4.width = panelRect.width;
			position4.height = 2f;
			GUI.DrawTexture(position4, white);
			GUI.color = color2;
		}

		[Token(Token = "0x6001842")]
		[Address(RVA = "0x3D36014", Offset = "0x3D36014", Length = "0x384")]
		private void DrawTabBar(Rect panelRect)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugMenuController::DrawTabBar");
		}

		[Token(Token = "0x6001843")]
		[Address(RVA = "0x3D36398", Offset = "0x3D36398", Length = "0x13C")]
		private void DrawBody(Rect panelRect)
		{
			//IL_00bf: Expected I4, but got I8
			int activeIndex = _activeIndex;
			if ((int)(_activeIndex & 0x80000000L) == 0)
			{
				IDebugModule[] modules = _modules;
				if (_activeIndex < modules.Length)
				{
					float x = panelRect.x + 8f;
					float y = panelRect.y + 94f;
					float width = panelRect.width + -16f;
					float num = panelRect.height + -94f;
					float height = num + -8f;
					Rect contentArea = default(Rect);
					contentArea.x = x;
					contentArea.y = y;
					contentArea.width = width;
					contentArea.height = height;
					modules[activeIndex].DrawGUI(contentArea);
				}
			}
		}

		[Token(Token = "0x6001844")]
		[Address(RVA = "0x3D364D4", Offset = "0x3D364D4", Length = "0xC0")]
		private void ConsumePanelEvents(Rect panelRect)
		{
			Event current = Event.current;
			if (current == null)
			{
				return;
			}
			if (current.type != EventType.MouseDown)
			{
				EventType type = current.type;
				if (type != EventType.MouseUp)
				{
					EventType type2 = current.type;
					if (type2 != EventType.MouseDrag)
					{
						return;
					}
				}
			}
			Vector2 mousePosition = current.mousePosition;
			float num = panelRect.x + panelRect.width;
			float num2 = panelRect.y + panelRect.height;
			bool flag = mousePosition.x < panelRect.x;
			bool flag2 = mousePosition.x == mousePosition.x;
			bool flag3 = panelRect.x == panelRect.x;
			bool flag4 = flag2 && flag3;
			bool flag5 = !flag4;
			bool flag6;
			bool flag10;
			if (flag == flag5 && mousePosition.x < num)
			{
				flag6 = mousePosition.y < panelRect.y;
				bool flag7 = mousePosition.y == mousePosition.y;
				bool flag8 = panelRect.y == panelRect.y;
				bool flag9 = flag7 && flag8;
				flag10 = !flag9;
			}
			else
			{
				flag10 = false;
				flag6 = true;
			}
			if (flag6 == flag10 && mousePosition.y < num2)
			{
				current.Use();
			}
		}

		[Token(Token = "0x6001845")]
		[Address(RVA = "0x3D368E8", Offset = "0x3D368E8", Length = "0xF4")]
		public DebugMenuController()
		{
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DC29]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				_ = 1;
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v24 (Il2CppClass<System.EmptyArray`1<_game.CoreGameKit.Tools.DebugMenu.IDebugModule>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X0_v5+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			_modules = Array.Empty<IDebugModule>();
		}
	}
}
