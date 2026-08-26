using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class Win32
{
	public struct PIXELFORMATDESCRIPTOR
	{
		public ushort nSize;

		public ushort nVersion;

		public uint dwFlags;

		public byte iPixelType;

		public byte cColorBits;

		public byte cRedBits;

		public byte cRedShift;

		public byte cGreenBits;

		public byte cGreenShift;

		public byte cBlueBits;

		public byte cBlueShift;

		public byte cAlphaBits;

		public byte cAlphaShift;

		public byte cAccumBits;

		public byte cAccumRedBits;

		public byte cAccumGreenBits;

		public byte cAccumBlueBits;

		public byte cAccumAlphaBits;

		public byte cDepthBits;

		public byte cStencilBits;

		public byte cAuxBuffers;

		public byte iLayerType;

		public byte bReserved;

		public uint dwLayerMask;

		public uint dwVisibleMask;

		public uint dwDamageMask;

		public PIXELFORMATDESCRIPTOR(ushort nVersion, uint dwFlags, byte iPixelType, byte cColorBits, byte cRedBits, byte cRedShift, byte cGreenBits, byte cGreenShift, byte cBlueBits, byte cBlueShift, byte cAlphaBits, byte cAlphaShift, byte cAccumBits, byte cAccumRedBits, byte cAccumGreenBits, byte cAccumBlueBits, byte cAccumAlphaBits, byte cDepthBits, byte cStencilBits, byte cAuxBuffers, byte iLayerType, byte bReserved, uint dwLayerMask, uint dwVisibleMask, uint dwDamageMask)
		{
			nSize = 38;
			this.nVersion = nVersion;
			this.dwFlags = dwFlags;
			this.iPixelType = iPixelType;
			this.cColorBits = cColorBits;
			this.cRedBits = cRedBits;
			this.cRedShift = cRedShift;
			this.cGreenBits = cGreenBits;
			this.cGreenShift = cGreenShift;
			this.cBlueBits = cBlueBits;
			this.cBlueShift = cBlueShift;
			this.cAlphaBits = cAlphaBits;
			this.cAlphaShift = cAlphaShift;
			this.cAccumBits = cAccumBits;
			this.cAccumRedBits = cAccumRedBits;
			this.cAccumGreenBits = cAccumGreenBits;
			this.cAccumBlueBits = cAccumBlueBits;
			this.cAccumAlphaBits = cAccumAlphaBits;
			this.cDepthBits = cDepthBits;
			this.cStencilBits = cStencilBits;
			this.cAuxBuffers = cAuxBuffers;
			this.iLayerType = iLayerType;
			this.bReserved = bReserved;
			this.dwLayerMask = dwLayerMask;
			this.dwVisibleMask = dwVisibleMask;
			this.dwDamageMask = dwDamageMask;
		}
	}

	public struct MSG
	{
		public IntPtr hwnd;

		public uint message;

		public uint wParam;

		public uint lParam;

		public uint time;

		public POINT pt;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct POINT
	{
		public int X;

		public int Y;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct RECT
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	public struct WINDOWPOS
	{
		public IntPtr hwnd;

		public IntPtr hwndAfter;

		public int x;

		public int y;

		public int cx;

		public int cy;

		public uint flags;
	}

	public struct NCCALCSIZE_PARAMS
	{
		public RECT rgc;

		public WINDOWPOS wndpos;
	}

	public struct PAINTSTRUCT
	{
		public IntPtr hdc;

		public int fErase;

		public RECT rcPaint;

		public int fRestore;

		public int fIncUpdate;

		public int Reserved1;

		public int Reserved2;

		public int Reserved3;

		public int Reserved4;

		public int Reserved5;

		public int Reserved6;

		public int Reserved7;

		public int Reserved8;
	}

	public struct NETRESOURCE_W
	{
		public uint dwScope;

		public uint dwType;

		public uint dwDisplayType;

		public uint dwUsage;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpLocalName;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpRemoteName;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpComment;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpProvider;
	}

	public const uint WS_OVERLAPPED = 0u;

	public const uint WS_POPUP = 2147483648u;

	public const uint WS_CHILD = 1073741824u;

	public const uint WS_MINIMIZE = 536870912u;

	public const uint WS_VISIBLE = 268435456u;

	public const uint WS_DISABLED = 134217728u;

	public const uint WS_CLIPSIBLINGS = 67108864u;

	public const uint WS_CLIPCHILDREN = 33554432u;

	public const uint WS_MAXIMIZE = 16777216u;

	public const uint WS_CAPTION = 12582912u;

	public const uint WS_BORDER = 8388608u;

	public const uint WS_DLGFRAME = 4194304u;

	public const uint WS_VSCROLL = 2097152u;

	public const uint WS_HSCROLL = 1048576u;

	public const uint WS_SYSMENU = 524288u;

	public const uint WS_THICKFRAME = 262144u;

	public const uint WS_GROUP = 131072u;

	public const uint WS_TABSTOP = 65536u;

	public const uint WS_MINIMIZEBOX = 131072u;

	public const uint WS_MAXIMIZEBOX = 65536u;

	public const uint WS_TILED = 0u;

	public const uint WS_ICONIC = 536870912u;

	public const uint WS_SIZEBOX = 262144u;

	public const int SM_REMOTESESSION = 4096;

	public const int PM_NOREMOVE = 0;

	public const int PM_REMOVE = 1;

	public const int PM_NOYIELD = 2;

	public const int HTERROR = -2;

	public const int HTTRANSPARENT = -1;

	public const int HTNOWHERE = 0;

	public const int HTCLIENT = 1;

	public const int HTCAPTION = 2;

	public const int HTSYSMENU = 3;

	public const int HTGROWBOX = 4;

	public const int HTSIZE = 4;

	public const int HTMENU = 5;

	public const int HTHSCROLL = 6;

	public const int HTVSCROLL = 7;

	public const int HTMINBUTTON = 8;

	public const int HTMAXBUTTON = 9;

	public const int HTLEFT = 10;

	public const int HTRIGHT = 11;

	public const int HTTOP = 12;

	public const int HTTOPLEFT = 13;

	public const int HTTOPRIGHT = 14;

	public const int HTBOTTOM = 15;

	public const int HTBOTTOMLEFT = 16;

	public const int HTBOTTOMRIGHT = 17;

	public const int HTBORDER = 18;

	public const int HTREDUCE = 8;

	public const int HTZOOM = 9;

	public const int HTSIZEFIRST = 10;

	public const int HTSIZELAST = 17;

	public const int HTOBJECT = 19;

	public const int HTCLOSE = 20;

	public const int HTHELP = 21;

	public const int GW_HWNDFIRST = 0;

	public const int GW_HWNDLAST = 1;

	public const int GW_HWNDNEXT = 2;

	public const int GW_HWNDPREV = 3;

	public const int GW_OWNER = 4;

	public const int GW_CHILD = 5;

	public const int GWL_WNDPROC = -4;

	public const int GWL_HINSTANCE = -6;

	public const int GWL_HWNDPARENT = -8;

	public const int GWL_STYLE = -16;

	public const int GWL_EXSTYLE = -20;

	public const int GWL_USERDATA = -21;

	public const int GWL_ID = -12;

	public const int WM_NULL = 0;

	public const int WM_CREATE = 1;

	public const int WM_DESTROY = 2;

	public const int WM_MOVE = 3;

	public const int WM_SIZE = 5;

	public const int WM_ACTIVATE = 6;

	public const int WA_INACTIVE = 0;

	public const int WA_ACTIVE = 1;

	public const int WA_CLICKACTIVE = 2;

	public const int WM_SETFOCUS = 7;

	public const int WM_KILLFOCUS = 8;

	public const int WM_ENABLE = 10;

	public const int WM_SETREDRAW = 11;

	public const int WM_SETTEXT = 12;

	public const int WM_GETTEXT = 13;

	public const int WM_GETTEXTLENGTH = 14;

	public const int WM_PAINT = 15;

	public const int WM_CLOSE = 16;

	public const int WM_QUERYENDSESSION = 17;

	public const int WM_QUERYOPEN = 19;

	public const int WM_ENDSESSION = 22;

	public const int WM_QUIT = 18;

	public const int WM_ERASEBKGND = 20;

	public const int WM_SYSCOLORCHANGE = 21;

	public const int WM_SHOWWINDOW = 24;

	public const int WM_WININICHANGE = 26;

	public const int WM_SETTINGCHANGE = 26;

	public const int WM_DEVMODECHANGE = 27;

	public const int WM_ACTIVATEAPP = 28;

	public const int WM_FONTCHANGE = 29;

	public const int WM_TIMECHANGE = 30;

	public const int WM_CANCELMODE = 31;

	public const int WM_SETCURSOR = 32;

	public const int WM_MOUSEACTIVATE = 33;

	public const int WM_CHILDACTIVATE = 34;

	public const int WM_QUEUESYNC = 35;

	public const int WM_GETMINMAXINFO = 36;

	public const int WM_PAINTICON = 38;

	public const int WM_ICONERASEBKGND = 39;

	public const int WM_NEXTDLGCTL = 40;

	public const int WM_SPOOLERSTATUS = 42;

	public const int WM_DRAWITEM = 43;

	public const int WM_MEASUREITEM = 44;

	public const int WM_DELETEITEM = 45;

	public const int WM_VKEYTOITEM = 46;

	public const int WM_CHARTOITEM = 47;

	public const int WM_SETFONT = 48;

	public const int WM_GETFONT = 49;

	public const int WM_SETHOTKEY = 50;

	public const int WM_GETHOTKEY = 51;

	public const int WM_QUERYDRAGICON = 55;

	public const int WM_COMPAREITEM = 57;

	public const int WM_GETOBJECT = 61;

	public const int WM_COMPACTING = 65;

	public const int WM_COMMNOTIFY = 68;

	public const int WM_WINDOWPOSCHANGING = 70;

	public const int WM_WINDOWPOSCHANGED = 71;

	public const int WM_POWER = 72;

	public const int PWR_OK = 1;

	public const int PWR_FAIL = -1;

	public const int PWR_SUSPENDREQUEST = 1;

	public const int PWR_SUSPENDRESUME = 2;

	public const int PWR_CRITICALRESUME = 3;

	public const int WM_COPYDATA = 74;

	public const int WM_CANCELJOURNAL = 75;

	public const int WM_NOTIFY = 78;

	public const int WM_INPUTLANGCHANGEREQUEST = 80;

	public const int WM_INPUTLANGCHANGE = 81;

	public const int WM_TCARD = 82;

	public const int WM_HELP = 83;

	public const int WM_USERCHANGED = 84;

	public const int WM_NOTIFYFORMAT = 85;

	public const int NFR_ANSI = 1;

	public const int NFR_UNICODE = 2;

	public const int NF_QUERY = 3;

	public const int NF_REQUERY = 4;

	public const int WM_CONTEXTMENU = 123;

	public const int WM_STYLECHANGING = 124;

	public const int WM_STYLECHANGED = 125;

	public const int WM_DISPLAYCHANGE = 126;

	public const int WM_GETICON = 127;

	public const int WM_SETICON = 128;

	public const int WM_NCCREATE = 129;

	public const int WM_NCDESTROY = 130;

	public const int WM_NCCALCSIZE = 131;

	public const int WM_NCHITTEST = 132;

	public const int WM_NCPAINT = 133;

	public const int WM_NCACTIVATE = 134;

	public const int WM_GETDLGCODE = 135;

	public const int WM_SYNCPAINT = 136;

	public const int WM_NCMOUSEMOVE = 160;

	public const int WM_NCLBUTTONDOWN = 161;

	public const int WM_NCLBUTTONUP = 162;

	public const int WM_NCLBUTTONDBLCLK = 163;

	public const int WM_NCRBUTTONDOWN = 164;

	public const int WM_NCRBUTTONUP = 165;

	public const int WM_NCRBUTTONDBLCLK = 166;

	public const int WM_NCMBUTTONDOWN = 167;

	public const int WM_NCMBUTTONUP = 168;

	public const int WM_NCMBUTTONDBLCLK = 169;

	public const int WM_NCXBUTTONDOWN = 171;

	public const int WM_NCXBUTTONUP = 172;

	public const int WM_NCXBUTTONDBLCLK = 173;

	public const int WM_INPUT = 255;

	public const int WM_KEYFIRST = 256;

	public const int WM_KEYDOWN = 256;

	public const int WM_KEYUP = 257;

	public const int WM_CHAR = 258;

	public const int WM_DEADCHAR = 259;

	public const int WM_SYSKEYDOWN = 260;

	public const int WM_SYSKEYUP = 261;

	public const int WM_SYSCHAR = 262;

	public const int WM_SYSDEADCHAR = 263;

	public const int WM_UNICHAR = 265;

	public const int WM_KEYLAST = 265;

	public const int UNICODE_NOCHAR = 65535;

	public const int WM_IME_STARTCOMPOSITION = 269;

	public const int WM_IME_ENDCOMPOSITION = 270;

	public const int WM_IME_COMPOSITION = 271;

	public const int WM_IME_KEYLAST = 271;

	public const int WM_INITDIALOG = 272;

	public const int WM_COMMAND = 273;

	public const int WM_SYSCOMMAND = 274;

	public const int WM_TIMER = 275;

	public const int WM_HSCROLL = 276;

	public const int WM_VSCROLL = 277;

	public const int WM_INITMENU = 278;

	public const int WM_INITMENUPOPUP = 279;

	public const int WM_MENUSELECT = 287;

	public const int WM_MENUCHAR = 288;

	public const int WM_ENTERIDLE = 289;

	public const int WM_MENURBUTTONUP = 290;

	public const int WM_MENUDRAG = 291;

	public const int WM_MENUGETOBJECT = 292;

	public const int WM_UNINITMENUPOPUP = 293;

	public const int WM_MENUCOMMAND = 294;

	public const int WM_CHANGEUISTATE = 295;

	public const int WM_UPDATEUISTATE = 296;

	public const int WM_QUERYUISTATE = 297;

	public const int UIS_SET = 1;

	public const int UIS_CLEAR = 2;

	public const int UIS_INITIALIZE = 3;

	public const int UISF_HIDEFOCUS = 1;

	public const int UISF_HIDEACCEL = 2;

	public const int UISF_ACTIVE = 4;

	public const int WM_CTLCOLORMSGBOX = 306;

	public const int WM_CTLCOLOREDIT = 307;

	public const int WM_CTLCOLORLISTBOX = 308;

	public const int WM_CTLCOLORBTN = 309;

	public const int WM_CTLCOLORDLG = 310;

	public const int WM_CTLCOLORSCROLLBAR = 311;

	public const int WM_CTLCOLORSTATIC = 312;

	public const int MN_GETHMENU = 481;

	public const int WM_MOUSEFIRST = 512;

	public const int WM_MOUSEMOVE = 512;

	public const int WM_LBUTTONDOWN = 513;

	public const int WM_LBUTTONUP = 514;

	public const int WM_LBUTTONDBLCLK = 515;

	public const int WM_RBUTTONDOWN = 516;

	public const int WM_RBUTTONUP = 517;

	public const int WM_RBUTTONDBLCLK = 518;

	public const int WM_MBUTTONDOWN = 519;

	public const int WM_MBUTTONUP = 520;

	public const int WM_MBUTTONDBLCLK = 521;

	public const int WM_MOUSEWHEEL = 522;

	public const int WM_XBUTTONDOWN = 523;

	public const int WM_XBUTTONUP = 524;

	public const int WM_XBUTTONDBLCLK = 525;

	public const int WM_MOUSELAST = 525;

	public const int WHEEL_DELTA = 120;

	public const int XBUTTON1 = 1;

	public const int XBUTTON2 = 2;

	public const int WM_PARENTNOTIFY = 528;

	public const int WM_ENTERMENULOOP = 529;

	public const int WM_EXITMENULOOP = 530;

	public const int WM_NEXTMENU = 531;

	public const int WM_SIZING = 532;

	public const int WM_CAPTURECHANGED = 533;

	public const int WM_MOVING = 534;

	public const int WM_POWERBROADCAST = 536;

	public const int PBT_APMQUERYSUSPEND = 0;

	public const int PBT_APMQUERYSTANDBY = 1;

	public const int PBT_APMQUERYSUSPENDFAILED = 2;

	public const int PBT_APMQUERYSTANDBYFAILED = 3;

	public const int PBT_APMSUSPEND = 4;

	public const int PBT_APMSTANDBY = 5;

	public const int PBT_APMRESUMECRITICAL = 6;

	public const int PBT_APMRESUMESUSPEND = 7;

	public const int PBT_APMRESUMESTANDBY = 8;

	public const int PBTF_APMRESUMEFROMFAILURE = 1;

	public const int PBT_APMBATTERYLOW = 9;

	public const int PBT_APMPOWERSTATUSCHANGE = 10;

	public const int PBT_APMOEMEVENT = 11;

	public const int PBT_APMRESUMEAUTOMATIC = 18;

	public const int WM_DEVICECHANGE = 537;

	public const int WM_MDICREATE = 544;

	public const int WM_MDIDESTROY = 545;

	public const int WM_MDIACTIVATE = 546;

	public const int WM_MDIRESTORE = 547;

	public const int WM_MDINEXT = 548;

	public const int WM_MDIMAXIMIZE = 549;

	public const int WM_MDITILE = 550;

	public const int WM_MDICASCADE = 551;

	public const int WM_MDIICONARRANGE = 552;

	public const int WM_MDIGETACTIVE = 553;

	public const int WM_MDISETMENU = 560;

	public const int WM_ENTERSIZEMOVE = 561;

	public const int WM_EXITSIZEMOVE = 562;

	public const int WM_DROPFILES = 563;

	public const int WM_MDIREFRESHMENU = 564;

	public const int WM_IME_SETCONTEXT = 641;

	public const int WM_IME_NOTIFY = 642;

	public const int WM_IME_CONTROL = 643;

	public const int WM_IME_COMPOSITIONFULL = 644;

	public const int WM_IME_SELECT = 645;

	public const int WM_IME_CHAR = 646;

	public const int WM_IME_REQUEST = 648;

	public const int WM_IME_KEYDOWN = 656;

	public const int WM_IME_KEYUP = 657;

	public const int WM_MOUSEHOVER = 673;

	public const int WM_MOUSELEAVE = 675;

	public const int WM_NCMOUSEHOVER = 672;

	public const int WM_NCMOUSELEAVE = 674;

	public const int WM_WTSSESSION_CHANGE = 689;

	public const int WM_TABLET_FIRST = 704;

	public const int WM_TABLET_LAST = 735;

	public const int WM_CUT = 768;

	public const int WM_COPY = 769;

	public const int WM_PASTE = 770;

	public const int WM_CLEAR = 771;

	public const int WM_UNDO = 772;

	public const int WM_RENDERFORMAT = 773;

	public const int WM_RENDERALLFORMATS = 774;

	public const int WM_DESTROYCLIPBOARD = 775;

	public const int WM_DRAWCLIPBOARD = 776;

	public const int WM_PAINTCLIPBOARD = 777;

	public const int WM_VSCROLLCLIPBOARD = 778;

	public const int WM_SIZECLIPBOARD = 779;

	public const int WM_ASKCBFORMATNAME = 780;

	public const int WM_CHANGECBCHAIN = 781;

	public const int WM_HSCROLLCLIPBOARD = 782;

	public const int WM_QUERYNEWPALETTE = 783;

	public const int WM_PALETTEISCHANGING = 784;

	public const int WM_PALETTECHANGED = 785;

	public const int WM_HOTKEY = 786;

	public const int WM_PRINT = 791;

	public const int WM_PRINTCLIENT = 792;

	public const int WM_APPCOMMAND = 793;

	public const int WM_THEMECHANGED = 794;

	public const int WM_HANDHELDFIRST = 856;

	public const int WM_HANDHELDLAST = 863;

	public const int WM_AFXFIRST = 864;

	public const int WM_AFXLAST = 895;

	public const int WM_PENWINFIRST = 896;

	public const int WM_PENWINLAST = 911;

	public const int WM_APP = 32768;

	public const int VK_LBUTTON = 1;

	public const int VK_RBUTTON = 2;

	public const int VK_CANCEL = 3;

	public const int VK_MBUTTON = 4;

	public const int VK_XBUTTON1 = 5;

	public const int VK_XBUTTON2 = 6;

	public const int VK_BACK = 8;

	public const int VK_TAB = 9;

	public const int VK_CLEAR = 12;

	public const int VK_RETURN = 13;

	public const int VK_SHIFT = 16;

	public const int VK_CONTROL = 17;

	public const int VK_MENU = 18;

	public const int VK_PAUSE = 19;

	public const int VK_CAPITAL = 20;

	public const int VK_KANA = 21;

	public const int VK_HANGEUL = 21;

	public const int VK_HANGUL = 21;

	public const int VK_JUNJA = 23;

	public const int VK_FINAL = 24;

	public const int VK_HANJA = 25;

	public const int VK_KANJI = 25;

	public const int VK_ESCAPE = 27;

	public const int VK_CONVERT = 28;

	public const int VK_NONCONVERT = 29;

	public const int VK_ACCEPT = 30;

	public const int VK_MODECHANGE = 31;

	public const int VK_SPACE = 32;

	public const int VK_PRIOR = 33;

	public const int VK_NEXT = 34;

	public const int VK_END = 35;

	public const int VK_HOME = 36;

	public const int VK_LEFT = 37;

	public const int VK_UP = 38;

	public const int VK_RIGHT = 39;

	public const int VK_DOWN = 40;

	public const int VK_SELECT = 41;

	public const int VK_PRINT = 42;

	public const int VK_EXECUTE = 43;

	public const int VK_SNAPSHOT = 44;

	public const int VK_INSERT = 45;

	public const int VK_DELETE = 46;

	public const int VK_HELP = 47;

	public const int VK_LWIN = 91;

	public const int VK_RWIN = 92;

	public const int VK_APPS = 93;

	public const int VK_SLEEP = 95;

	public const int VK_NUMPAD0 = 96;

	public const int VK_NUMPAD1 = 97;

	public const int VK_NUMPAD2 = 98;

	public const int VK_NUMPAD3 = 99;

	public const int VK_NUMPAD4 = 100;

	public const int VK_NUMPAD5 = 101;

	public const int VK_NUMPAD6 = 102;

	public const int VK_NUMPAD7 = 103;

	public const int VK_NUMPAD8 = 104;

	public const int VK_NUMPAD9 = 105;

	public const int VK_MULTIPLY = 106;

	public const int VK_ADD = 107;

	public const int VK_SEPARATOR = 108;

	public const int VK_SUBTRACT = 109;

	public const int VK_DECIMAL = 110;

	public const int VK_DIVIDE = 111;

	public const int VK_F1 = 112;

	public const int VK_F2 = 113;

	public const int VK_F3 = 114;

	public const int VK_F4 = 115;

	public const int VK_F5 = 116;

	public const int VK_F6 = 117;

	public const int VK_F7 = 118;

	public const int VK_F8 = 119;

	public const int VK_F9 = 120;

	public const int VK_F10 = 121;

	public const int VK_F11 = 122;

	public const int VK_F12 = 123;

	public const int VK_F13 = 124;

	public const int VK_F14 = 125;

	public const int VK_F15 = 126;

	public const int VK_F16 = 127;

	public const int VK_F17 = 128;

	public const int VK_F18 = 129;

	public const int VK_F19 = 130;

	public const int VK_F20 = 131;

	public const int VK_F21 = 132;

	public const int VK_F22 = 133;

	public const int VK_F23 = 134;

	public const int VK_F24 = 135;

	public const int VK_NUMLOCK = 144;

	public const int VK_SCROLL = 145;

	public const int VK_OEM_NEC_EQUAL = 146;

	public const int VK_OEM_FJ_JISHO = 146;

	public const int VK_OEM_FJ_MASSHOU = 147;

	public const int VK_OEM_FJ_TOUROKU = 148;

	public const int VK_OEM_FJ_LOYA = 149;

	public const int VK_OEM_FJ_ROYA = 150;

	public const int VK_LSHIFT = 160;

	public const int VK_RSHIFT = 161;

	public const int VK_LCONTROL = 162;

	public const int VK_RCONTROL = 163;

	public const int VK_LMENU = 164;

	public const int VK_RMENU = 165;

	public const int PFD_DOUBLEBUFFER = 1;

	public const int PFD_STEREO = 2;

	public const int PFD_DRAW_TO_WINDOW = 4;

	public const int PFD_DRAW_TO_BITMAP = 8;

	public const int PFD_SUPPORT_GDI = 16;

	public const int PFD_SUPPORT_OPENGL = 32;

	public const int PFD_GENERIC_FORMAT = 64;

	public const int PFD_NEED_PALETTE = 128;

	public const int PFD_NEED_SYSTEM_PALETTE = 256;

	public const int PFD_SWAP_EXCHANGE = 512;

	public const int PFD_SWAP_COPY = 1024;

	public const int PFD_SWAP_LAYER_BUFFERS = 2048;

	public const int PFD_GENERIC_ACCELERATED = 4096;

	public const int PFD_SUPPORT_DIRECTDRAW = 8192;

	public const int PFD_TYPE_RGBA = 0;

	public const int PFD_TYPE_COLORINDEX = 1;

	public const int PFD_MAIN_PLANE = 0;

	public const int PFD_OVERLAY_PLANE = 1;

	public const int PFD_UNDERLAY_PLANE = -1;

	private const uint _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020 = 0u;

	private const uint _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A = 1u;

	private const uint _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020 = 2u;

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern int GetSystemMetrics(int _0020);

	public static bool IsRemoteSession()
	{
		if (GetSystemMetrics(4096) != 0)
		{
			return true;
		}
		return false;
	}

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern uint LockWindowUpdate(IntPtr _0020);

	public static uint LockWindowUpdate(Control ctrl)
	{
		if (ctrl == null)
		{
			return LockWindowUpdate(IntPtr.Zero);
		}
		return LockWindowUpdate(ctrl.Handle);
	}

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern uint PeekMessage(ref MSG _0020, IntPtr _0020_000A, uint _0020_0020, uint _0020_000A_000A, uint _0020_000A_0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr DispatchMessage(ref MSG _0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern short GetAsyncKeyState(int _0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern int SetScrollPos(IntPtr _0020, int _0020_000A, int _0020_0020, int _0020_000A_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern int GetScrollPos(IntPtr _0020, int _0020_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern int SetScrollRange(IntPtr _0020, int _0020_000A, int _0020_0020, int _0020_000A_000A, int _0020_000A_0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern int GetScrollRange(IntPtr _0020, int _0020_000A, ref int _0020_0020, ref int _0020_000A_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern uint SetWindowLong(IntPtr _0020, int _0020_000A, uint _0020_0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr FindWindow(string _0020, string _0020_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr FindWindowEx(IntPtr _0020, IntPtr _0020_000A, string _0020_0020, string _0020_000A_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern uint ShowWindow(IntPtr _0020, int _0020_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern int PostMessage(IntPtr _0020, uint _0020_000A, int _0020_0020, int _0020_000A_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern int SendMessage(IntPtr _0020, uint _0020_000A, int _0020_0020, int _0020_000A_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern uint GetWindowLong(IntPtr _0020, int _0020_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern uint SetForegroundWindow(IntPtr _0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr SetActiveWindow(IntPtr _0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr GetParent(IntPtr _0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr GetActiveWindow();

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr GetForegroundWindow();

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern int BringWindowToTop(IntPtr _0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern void SwitchToThisWindow(IntPtr _0020, int _0020_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr SetFocus(IntPtr _0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern uint SetWindowText(IntPtr _0020, string _0020_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr GetDC(IntPtr _0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr GetWindowDC(IntPtr _0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr ReleaseDC(IntPtr _0020, IntPtr _0020_000A);

	[DllImport("Gdi32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr CreateCompatibleDC(IntPtr _0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern int GetClassName(IntPtr _0020, char[] _0020_000A, int _0020_0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern int GetWindowText(IntPtr _0020, char[] _0020_000A, int _0020_0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr GetWindow(IntPtr _0020, int _0020_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern bool IsWindow(IntPtr _0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern bool IsWindowVisible(IntPtr _0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern int GetClientRect(IntPtr _0020, ref RECT _0020_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern int GetClientRect(IntPtr _0020, [In] [Out] ref Rectangle _0020_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern bool MoveWindow(IntPtr _0020, int _0020_000A, int _0020_0020, int _0020_000A_000A, int _0020_000A_0020, bool _0020_0020_000A);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern bool UpdateWindow(IntPtr _0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern bool InvalidateRect(IntPtr _0020, ref Rectangle _0020_000A, bool _0020_0020);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern bool ValidateRect(IntPtr _0020, ref Rectangle _0020_000A);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern bool GetWindowRect(IntPtr _0020, [In] [Out] ref Rectangle _0020_000A);

	[DllImport("User32.dll")]
	public static extern int GetUpdateRect(IntPtr _0020, ref RECT _0020_000A, bool _0020_0020);

	[DllImport("User32.dll", SetLastError = true)]
	public static extern bool GetWindowRect(IntPtr _0020, ref RECT _0020_000A);

	[DllImport("User32.dll")]
	public static extern IntPtr BeginPaint(IntPtr _0020, ref PAINTSTRUCT _0020_000A);

	[DllImport("User32.dll")]
	public static extern bool EndPaint(IntPtr _0020, ref PAINTSTRUCT _0020_000A);

	[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
	public static extern uint GetCurrentProcessId();

	[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
	public static extern uint GetTickCount();

	[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
	public static extern void ExitProcess(uint _0020);

	[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
	public static extern uint IsDebuggerPresent();

	[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
	public static extern void SetLastError(uint _0020);

	[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
	public static extern uint GetLastError();

	[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
	public static extern uint WinExec(string _0020, uint _0020_000A);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern uint SetPixelFormat(IntPtr _0020, int _0020_000A, ref PIXELFORMATDESCRIPTOR _0020_0020);

	[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	internal static extern int ChoosePixelFormat(IntPtr _0020, ref PIXELFORMATDESCRIPTOR _0020_000A);

	[DllImport("Mpr.dll", CharSet = CharSet.Unicode)]
	internal static extern uint WNetAddConnection2W(ref NETRESOURCE_W _0020, string _0020_000A, string _0020_0020, uint _0020_000A_000A);

	[DllImport("Mpr.dll", CharSet = CharSet.Unicode)]
	internal static extern uint WNetCancelConnection2W(string _0020, uint _0020_000A, uint _0020_0020);

	public static bool OpenRemoteShare(string path, string user_name, string password)
	{
		if (path == null || path.Length == 0)
		{
			return false;
		}
		NETRESOURCE_W nETRESOURCE_W = default(NETRESOURCE_W);
		nETRESOURCE_W.dwDisplayType = 0u;
		nETRESOURCE_W.dwScope = 0u;
		nETRESOURCE_W.dwUsage = 0u;
		nETRESOURCE_W.lpLocalName = null;
		nETRESOURCE_W.dwType = 1u;
		nETRESOURCE_W.lpRemoteName = path;
		nETRESOURCE_W.lpProvider = null;
		uint num = WNetAddConnection2W(ref nETRESOURCE_W, password, user_name, 0u);
		if (num != 0)
		{
			throw new Exception(new Win32Exception((int)num).Message);
		}
		return true;
	}

	public static bool CloseRemoteShare(string path)
	{
		try
		{
			if (WNetCancelConnection2W(path, 0u, 1u) != 0)
			{
				return false;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}
}
