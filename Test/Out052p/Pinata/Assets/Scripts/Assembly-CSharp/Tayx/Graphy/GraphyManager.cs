using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Tayx.Graphy.Advanced;
using Tayx.Graphy.Audio;
using Tayx.Graphy.Fps;
using Tayx.Graphy.Ram;
using Tayx.Graphy.Utils;
using UnityEngine;

namespace Tayx.Graphy
{
	[Token(Token = "0x200002D")]
	public class GraphyManager : G_Singleton<GraphyManager>
	{
		[Token(Token = "0x2000463")]
		public enum Mode
		{
			[Token(Token = "0x400209A")]
			FULL = 0,
			[Token(Token = "0x400209B")]
			LIGHT = 1
		}

		[Token(Token = "0x2000464")]
		public enum ModuleType
		{
			[Token(Token = "0x400209D")]
			FPS = 0,
			[Token(Token = "0x400209E")]
			RAM = 1,
			[Token(Token = "0x400209F")]
			AUDIO = 2,
			[Token(Token = "0x40020A0")]
			ADVANCED = 3
		}

		[Token(Token = "0x2000465")]
		public enum ModuleState
		{
			[Token(Token = "0x40020A2")]
			FULL = 0,
			[Token(Token = "0x40020A3")]
			TEXT = 1,
			[Token(Token = "0x40020A4")]
			BASIC = 2,
			[Token(Token = "0x40020A5")]
			BACKGROUND = 3,
			[Token(Token = "0x40020A6")]
			OFF = 4
		}

		[Token(Token = "0x2000466")]
		public enum ModulePosition
		{
			[Token(Token = "0x40020A8")]
			TOP_RIGHT = 0,
			[Token(Token = "0x40020A9")]
			TOP_LEFT = 1,
			[Token(Token = "0x40020AA")]
			BOTTOM_RIGHT = 2,
			[Token(Token = "0x40020AB")]
			BOTTOM_LEFT = 3,
			[Token(Token = "0x40020AC")]
			FREE = 4
		}

		[Token(Token = "0x2000467")]
		public enum LookForAudioListener
		{
			[Token(Token = "0x40020AE")]
			ALWAYS = 0,
			[Token(Token = "0x40020AF")]
			ON_SCENE_LOAD = 1,
			[Token(Token = "0x40020B0")]
			NEVER = 2
		}

		[Token(Token = "0x2000468")]
		public enum ModulePreset
		{
			[Token(Token = "0x40020B2")]
			FPS_BASIC = 0,
			[Token(Token = "0x40020B3")]
			FPS_TEXT = 1,
			[Token(Token = "0x40020B4")]
			FPS_FULL = 2,
			[Token(Token = "0x40020B5")]
			FPS_TEXT_RAM_TEXT = 3,
			[Token(Token = "0x40020B6")]
			FPS_FULL_RAM_TEXT = 4,
			[Token(Token = "0x40020B7")]
			FPS_FULL_RAM_FULL = 5,
			[Token(Token = "0x40020B8")]
			FPS_TEXT_RAM_TEXT_AUDIO_TEXT = 6,
			[Token(Token = "0x40020B9")]
			FPS_FULL_RAM_TEXT_AUDIO_TEXT = 7,
			[Token(Token = "0x40020BA")]
			FPS_FULL_RAM_FULL_AUDIO_TEXT = 8,
			[Token(Token = "0x40020BB")]
			FPS_FULL_RAM_FULL_AUDIO_FULL = 9,
			[Token(Token = "0x40020BC")]
			FPS_FULL_RAM_FULL_AUDIO_FULL_ADVANCED_FULL = 10,
			[Token(Token = "0x40020BD")]
			FPS_BASIC_ADVANCED_FULL = 11
		}

		[SerializeField]
		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x18")]
		internal Mode m_graphyMode;

		[SerializeField]
		[Token(Token = "0x400010C")]
		[FieldOffset(Offset = "0x1C")]
		private bool m_enableOnStartup;

		[SerializeField]
		[Token(Token = "0x400010D")]
		[FieldOffset(Offset = "0x1D")]
		private bool m_keepAlive;

		[SerializeField]
		[Token(Token = "0x400010E")]
		[FieldOffset(Offset = "0x1E")]
		internal bool m_background;

		[SerializeField]
		[Token(Token = "0x400010F")]
		[FieldOffset(Offset = "0x20")]
		internal Color m_backgroundColor;

		[SerializeField]
		[Token(Token = "0x4000110")]
		[FieldOffset(Offset = "0x30")]
		private bool m_enableHotkeys;

		[SerializeField]
		[Token(Token = "0x4000111")]
		[FieldOffset(Offset = "0x34")]
		private KeyCode m_toggleModeKeyCode;

		[SerializeField]
		[Token(Token = "0x4000112")]
		[FieldOffset(Offset = "0x38")]
		private bool m_toggleModeCtrl;

		[SerializeField]
		[Token(Token = "0x4000113")]
		[FieldOffset(Offset = "0x39")]
		private bool m_toggleModeAlt;

		[SerializeField]
		[Token(Token = "0x4000114")]
		[FieldOffset(Offset = "0x3C")]
		private KeyCode m_toggleActiveKeyCode;

		[SerializeField]
		[Token(Token = "0x4000115")]
		[FieldOffset(Offset = "0x40")]
		private bool m_toggleActiveCtrl;

		[SerializeField]
		[Token(Token = "0x4000116")]
		[FieldOffset(Offset = "0x41")]
		private bool m_toggleActiveAlt;

		[SerializeField]
		[Token(Token = "0x4000117")]
		[FieldOffset(Offset = "0x44")]
		private ModulePosition m_graphModulePosition;

		[SerializeField]
		[Token(Token = "0x4000118")]
		[FieldOffset(Offset = "0x48")]
		private ModuleState m_fpsModuleState;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x7641D8", Offset = "0x7641D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7641D8", Offset = "0x7641D8")]
		[SerializeField]
		[Token(Token = "0x4000119")]
		[FieldOffset(Offset = "0x4C")]
		private int m_timeToResetMinMaxFps;

		[SerializeField]
		[Token(Token = "0x400011A")]
		[FieldOffset(Offset = "0x50")]
		internal Color m_goodFpsColor;

		[SerializeField]
		[Token(Token = "0x400011B")]
		[FieldOffset(Offset = "0x60")]
		private int m_goodFpsThreshold;

		[SerializeField]
		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0x64")]
		internal Color m_cautionFpsColor;

		[SerializeField]
		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0x74")]
		private int m_cautionFpsThreshold;

		[SerializeField]
		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0x78")]
		internal Color m_criticalFpsColor;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x764290", Offset = "0x764290")]
		[SerializeField]
		[Token(Token = "0x400011F")]
		[FieldOffset(Offset = "0x88")]
		private int m_fpsGraphResolution;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x7642D4", Offset = "0x7642D4")]
		[SerializeField]
		[Token(Token = "0x4000120")]
		[FieldOffset(Offset = "0x8C")]
		private int m_fpsTextUpdateRate;

		[SerializeField]
		[Token(Token = "0x4000121")]
		[FieldOffset(Offset = "0x90")]
		private ModuleState m_ramModuleState;

		[SerializeField]
		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x94")]
		internal Color m_allocatedRamColor;

		[SerializeField]
		[Token(Token = "0x4000123")]
		[FieldOffset(Offset = "0xA4")]
		internal Color m_reservedRamColor;

		[SerializeField]
		[Token(Token = "0x4000124")]
		[FieldOffset(Offset = "0xB4")]
		internal Color m_monoRamColor;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x764358", Offset = "0x764358")]
		[SerializeField]
		[Token(Token = "0x4000125")]
		[FieldOffset(Offset = "0xC4")]
		private int m_ramGraphResolution;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x76439C", Offset = "0x76439C")]
		[SerializeField]
		[Token(Token = "0x4000126")]
		[FieldOffset(Offset = "0xC8")]
		private int m_ramTextUpdateRate;

		[SerializeField]
		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0xCC")]
		private ModuleState m_audioModuleState;

		[SerializeField]
		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0xD0")]
		private LookForAudioListener m_findAudioListenerInCameraIfNull;

		[SerializeField]
		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0xD8")]
		private AudioListener m_audioListener;

		[SerializeField]
		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0xE0")]
		internal Color m_audioGraphColor;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x764420", Offset = "0x764420")]
		[SerializeField]
		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0xF0")]
		private int m_audioGraphResolution;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x764464", Offset = "0x764464")]
		[SerializeField]
		[Token(Token = "0x400012C")]
		[FieldOffset(Offset = "0xF4")]
		private int m_audioTextUpdateRate;

		[SerializeField]
		[Token(Token = "0x400012D")]
		[FieldOffset(Offset = "0xF8")]
		private FFTWindow m_FFTWindow;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7644B8", Offset = "0x7644B8")]
		[SerializeField]
		[Token(Token = "0x400012E")]
		[FieldOffset(Offset = "0xFC")]
		private int m_spectrumSize;

		[SerializeField]
		[Token(Token = "0x400012F")]
		[FieldOffset(Offset = "0x100")]
		private ModulePosition m_advancedModulePosition;

		[SerializeField]
		[Token(Token = "0x4000130")]
		[FieldOffset(Offset = "0x104")]
		private ModuleState m_advancedModuleState;

		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0x108")]
		private bool m_initialized;

		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x109")]
		private bool m_active;

		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0x10A")]
		private bool m_focused;

		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0x110")]
		private G_FpsManager m_fpsManager;

		[Token(Token = "0x4000135")]
		[FieldOffset(Offset = "0x118")]
		private G_RamManager m_ramManager;

		[Token(Token = "0x4000136")]
		[FieldOffset(Offset = "0x120")]
		private G_AudioManager m_audioManager;

		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0x128")]
		private G_AdvancedData m_advancedData;

		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0x130")]
		private G_FpsMonitor m_fpsMonitor;

		[Token(Token = "0x4000139")]
		[FieldOffset(Offset = "0x138")]
		private G_RamMonitor m_ramMonitor;

		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x140")]
		private G_AudioMonitor m_audioMonitor;

		[Token(Token = "0x400013B")]
		[FieldOffset(Offset = "0x148")]
		private ModulePreset m_modulePresetState;

		[Token(Token = "0x1700000B")]
		public Mode GraphyMode
		{
			[Token(Token = "0x60000FA")]
			[Address(RVA = "0xB15E80", Offset = "0xB15E80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_graphyMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GraphyMode;
			}
			[Token(Token = "0x60000FB")]
			[Address(RVA = "0xB0FD54", Offset = "0xB0FD54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_graphyMode = value;\n\tTayx.Graphy.GraphyManager::UpdateAllParameters(this);\n\treturn;\n")]
			set
			{
				m_graphyMode = value;
				UpdateAllParameters();
			}
		}

		[Token(Token = "0x1700000C")]
		public bool EnableOnStartup
		{
			[Token(Token = "0x60000FC")]
			[Address(RVA = "0xB15ED8", Offset = "0xB15ED8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_enableOnStartup;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EnableOnStartup;
			}
		}

		[Token(Token = "0x1700000D")]
		public bool KeepAlive
		{
			[Token(Token = "0x60000FD")]
			[Address(RVA = "0xB15EE0", Offset = "0xB15EE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_keepAlive;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return KeepAlive;
			}
		}

		[Token(Token = "0x1700000E")]
		public bool Background
		{
			[Token(Token = "0x60000FE")]
			[Address(RVA = "0xB15EE8", Offset = "0xB15EE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_background;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Background;
			}
			[Token(Token = "0x60000FF")]
			[Address(RVA = "0xB0FB14", Offset = "0xB0FB14", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_background = value;\n\tTayx.Graphy.GraphyManager::UpdateAllParameters(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_background = value;
				UpdateAllParameters();
			}
		}

		[Token(Token = "0x1700000F")]
		public Color BackgroundColor
		{
			[Token(Token = "0x6000100")]
			[Address(RVA = "0xB15EF0", Offset = "0xB15EF0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_backgroundColor;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_backgroundColor;
			}
			[Token(Token = "0x6000101")]
			[Address(RVA = "0xB0FCAC", Offset = "0xB0FCAC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_backgroundColor = value;\n\tthis.m_backgroundColor.g = value.g;\n\tthis.m_backgroundColor.b = value.b;\n\tthis.m_backgroundColor.a = value.a;\n\tTayx.Graphy.GraphyManager::UpdateAllParameters(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_backgroundColor = value;
				m_backgroundColor.g = value.g;
				m_backgroundColor.b = value.b;
				m_backgroundColor.a = value.a;
				UpdateAllParameters();
			}
		}

		[Token(Token = "0x17000010")]
		public ModulePosition GraphModulePosition
		{
			[Token(Token = "0x6000102")]
			[Address(RVA = "0xB15EFC", Offset = "0xB15EFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_graphModulePosition;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GraphModulePosition;
			}
			[Token(Token = "0x6000103")]
			[Address(RVA = "0xB0FD74", Offset = "0xB0FD74", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_graphModulePosition = value;\n\tTayx.Graphy.Fps.G_FpsManager::SetPosition(this.m_fpsManager, value);\n\tTayx.Graphy.Ram.G_RamManager::SetPosition(this.m_ramManager, this.m_graphModulePosition);\n\tTayx.Graphy.Audio.G_AudioManager::SetPosition(this.m_audioManager, this.m_graphModulePosition);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_graphModulePosition = value;
				m_fpsManager.SetPosition(value);
				m_ramManager.SetPosition(GraphModulePosition);
				m_audioManager.SetPosition(GraphModulePosition);
			}
		}

		[Token(Token = "0x17000011")]
		public ModuleState FpsModuleState
		{
			[Token(Token = "0x6000104")]
			[Address(RVA = "0xB15F04", Offset = "0xB15F04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_fpsModuleState;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FpsModuleState;
			}
			[Token(Token = "0x6000105")]
			[Address(RVA = "0xB0FDDC", Offset = "0xB0FDDC", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_fpsModuleState = value;\n\tTayx.Graphy.Fps.G_FpsManager::SetState(this.m_fpsManager, value, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_fpsModuleState = value;
				m_fpsManager.SetState(value);
			}
		}

		[Token(Token = "0x17000012")]
		public int TimeToResetMinMaxFps
		{
			[Token(Token = "0x6000106")]
			[Address(RVA = "0xB15F0C", Offset = "0xB15F0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_timeToResetMinMaxFps;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TimeToResetMinMaxFps;
			}
			[Token(Token = "0x6000107")]
			[Address(RVA = "0xB10410", Offset = "0xB10410", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_timeToResetMinMaxFps = value;\n\tTayx.Graphy.Fps.G_FpsManager::UpdateParameters(this.m_fpsManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_timeToResetMinMaxFps = value;
				m_fpsManager.UpdateParameters();
			}
		}

		[Token(Token = "0x17000013")]
		public Color GoodFPSColor
		{
			[Token(Token = "0x6000108")]
			[Address(RVA = "0xB15F14", Offset = "0xB15F14", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_goodFpsColor;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_goodFpsColor;
			}
			[Token(Token = "0x6000109")]
			[Address(RVA = "0xB10068", Offset = "0xB10068", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_goodFpsColor = value;\n\tthis.m_goodFpsColor.g = value.g;\n\tthis.m_goodFpsColor.b = value.b;\n\tthis.m_goodFpsColor.a = value.a;\n\tTayx.Graphy.Fps.G_FpsManager::UpdateParameters(this.m_fpsManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_goodFpsColor = value;
				m_goodFpsColor.g = value.g;
				m_goodFpsColor.b = value.b;
				m_goodFpsColor.a = value.a;
				m_fpsManager.UpdateParameters();
			}
		}

		[Token(Token = "0x17000014")]
		public Color CautionFPSColor
		{
			[Token(Token = "0x600010A")]
			[Address(RVA = "0xB15F20", Offset = "0xB15F20", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_cautionFpsColor;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_cautionFpsColor;
			}
			[Token(Token = "0x600010B")]
			[Address(RVA = "0xB1021C", Offset = "0xB1021C", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_cautionFpsColor = value;\n\tthis.m_cautionFpsColor.g = value.g;\n\tthis.m_cautionFpsColor.b = value.b;\n\tthis.m_cautionFpsColor.a = value.a;\n\tTayx.Graphy.Fps.G_FpsManager::UpdateParameters(this.m_fpsManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_cautionFpsColor = value;
				m_cautionFpsColor.g = value.g;
				m_cautionFpsColor.b = value.b;
				m_cautionFpsColor.a = value.a;
				m_fpsManager.UpdateParameters();
			}
		}

		[Token(Token = "0x17000015")]
		public Color CriticalFPSColor
		{
			[Token(Token = "0x600010C")]
			[Address(RVA = "0xB15F2C", Offset = "0xB15F2C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_criticalFpsColor;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_criticalFpsColor;
			}
			[Token(Token = "0x600010D")]
			[Address(RVA = "0xB103D0", Offset = "0xB103D0", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_criticalFpsColor = value;\n\tthis.m_criticalFpsColor.g = value.g;\n\tthis.m_criticalFpsColor.b = value.b;\n\tthis.m_criticalFpsColor.a = value.a;\n\tTayx.Graphy.Fps.G_FpsManager::UpdateParameters(this.m_fpsManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_criticalFpsColor = value;
				m_criticalFpsColor.g = value.g;
				m_criticalFpsColor.b = value.b;
				m_criticalFpsColor.a = value.a;
				m_fpsManager.UpdateParameters();
			}
		}

		[Token(Token = "0x17000016")]
		public int GoodFPSThreshold
		{
			[Token(Token = "0x600010E")]
			[Address(RVA = "0xB15F38", Offset = "0xB15F38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_goodFpsThreshold;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GoodFPSThreshold;
			}
			[Token(Token = "0x600010F")]
			[Address(RVA = "0xB0FE4C", Offset = "0xB0FE4C", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_goodFpsThreshold = value;\n\tTayx.Graphy.Fps.G_FpsManager::UpdateParameters(this.m_fpsManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_goodFpsThreshold = value;
				m_fpsManager.UpdateParameters();
			}
		}

		[Token(Token = "0x17000017")]
		public int CautionFPSThreshold
		{
			[Token(Token = "0x6000110")]
			[Address(RVA = "0xB15F40", Offset = "0xB15F40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_cautionFpsThreshold;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CautionFPSThreshold;
			}
			[Token(Token = "0x6000111")]
			[Address(RVA = "0xB0FEB8", Offset = "0xB0FEB8", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_cautionFpsThreshold = value;\n\tTayx.Graphy.Fps.G_FpsManager::UpdateParameters(this.m_fpsManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_cautionFpsThreshold = value;
				m_fpsManager.UpdateParameters();
			}
		}

		[Token(Token = "0x17000018")]
		public int FpsGraphResolution
		{
			[Token(Token = "0x6000112")]
			[Address(RVA = "0xB15F48", Offset = "0xB15F48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_fpsGraphResolution;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FpsGraphResolution;
			}
			[Token(Token = "0x6000113")]
			[Address(RVA = "0xB1044C", Offset = "0xB1044C", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_fpsGraphResolution = value;\n\tTayx.Graphy.Fps.G_FpsManager::UpdateParameters(this.m_fpsManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_fpsGraphResolution = value;
				m_fpsManager.UpdateParameters();
			}
		}

		[Token(Token = "0x17000019")]
		public int FpsTextUpdateRate
		{
			[Token(Token = "0x6000114")]
			[Address(RVA = "0xB15F50", Offset = "0xB15F50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_fpsTextUpdateRate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FpsTextUpdateRate;
			}
			[Token(Token = "0x6000115")]
			[Address(RVA = "0xB10488", Offset = "0xB10488", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_fpsTextUpdateRate = value;\n\tTayx.Graphy.Fps.G_FpsManager::UpdateParameters(this.m_fpsManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_fpsTextUpdateRate = value;
				m_fpsManager.UpdateParameters();
			}
		}

		[Token(Token = "0x1700001A")]
		public float CurrentFPS
		{
			[Token(Token = "0x6000116")]
			[Address(RVA = "0xB15F58", Offset = "0xB15F58", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_fpsMonitor;\n\treturn v0.m_currentFps;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				G_FpsMonitor fpsMonitor = m_fpsMonitor;
				return fpsMonitor.CurrentFPS;
			}
		}

		[Token(Token = "0x1700001B")]
		public float AverageFPS
		{
			[Token(Token = "0x6000117")]
			[Address(RVA = "0xB15F78", Offset = "0xB15F78", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_fpsMonitor;\n\treturn v0.m_avgFps;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				G_FpsMonitor fpsMonitor = m_fpsMonitor;
				return fpsMonitor.AverageFPS;
			}
		}

		[Token(Token = "0x1700001C")]
		public float MinFPS
		{
			[Token(Token = "0x6000118")]
			[Address(RVA = "0xB15F98", Offset = "0xB15F98", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_fpsMonitor;\n\treturn v0.m_minFps;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				G_FpsMonitor fpsMonitor = m_fpsMonitor;
				return fpsMonitor.MinFPS;
			}
		}

		[Token(Token = "0x1700001D")]
		public float MaxFPS
		{
			[Token(Token = "0x6000119")]
			[Address(RVA = "0xB15FB8", Offset = "0xB15FB8", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_fpsMonitor;\n\treturn v0.m_maxFps;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				G_FpsMonitor fpsMonitor = m_fpsMonitor;
				return fpsMonitor.MaxFPS;
			}
		}

		[Token(Token = "0x1700001E")]
		public ModuleState RamModuleState
		{
			[Token(Token = "0x600011A")]
			[Address(RVA = "0xB15FD8", Offset = "0xB15FD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_ramModuleState;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RamModuleState;
			}
			[Token(Token = "0x600011B")]
			[Address(RVA = "0xB104C0", Offset = "0xB104C0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_ramModuleState = value;\n\tTayx.Graphy.Ram.G_RamManager::SetState(this.m_ramManager, value, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_ramModuleState = value;
				m_ramManager.SetState(value);
			}
		}

		[Token(Token = "0x1700001F")]
		public Color AllocatedRamColor
		{
			[Token(Token = "0x600011C")]
			[Address(RVA = "0xB15FE0", Offset = "0xB15FE0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_allocatedRamColor;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_allocatedRamColor;
			}
			[Token(Token = "0x600011D")]
			[Address(RVA = "0xB10830", Offset = "0xB10830", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_allocatedRamColor = value;\n\tthis.m_allocatedRamColor.g = value.g;\n\tthis.m_allocatedRamColor.b = value.b;\n\tthis.m_allocatedRamColor.a = value.a;\n\tTayx.Graphy.Ram.G_RamManager::UpdateParameters(this.m_ramManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_allocatedRamColor = value;
				m_allocatedRamColor.g = value.g;
				m_allocatedRamColor.b = value.b;
				m_allocatedRamColor.a = value.a;
				m_ramManager.UpdateParameters();
			}
		}

		[Token(Token = "0x17000020")]
		public Color ReservedRamColor
		{
			[Token(Token = "0x600011E")]
			[Address(RVA = "0xB15FEC", Offset = "0xB15FEC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_reservedRamColor;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_reservedRamColor;
			}
			[Token(Token = "0x600011F")]
			[Address(RVA = "0xB10678", Offset = "0xB10678", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_reservedRamColor = value;\n\tthis.m_reservedRamColor.g = value.g;\n\tthis.m_reservedRamColor.b = value.b;\n\tthis.m_reservedRamColor.a = value.a;\n\tTayx.Graphy.Ram.G_RamManager::UpdateParameters(this.m_ramManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_reservedRamColor = value;
				m_reservedRamColor.g = value.g;
				m_reservedRamColor.b = value.b;
				m_reservedRamColor.a = value.a;
				m_ramManager.UpdateParameters();
			}
		}

		[Token(Token = "0x17000021")]
		public Color MonoRamColor
		{
			[Token(Token = "0x6000120")]
			[Address(RVA = "0xB15FF8", Offset = "0xB15FF8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_monoRamColor;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_monoRamColor;
			}
			[Token(Token = "0x6000121")]
			[Address(RVA = "0xB109E8", Offset = "0xB109E8", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_monoRamColor = value;\n\tthis.m_monoRamColor.g = value.g;\n\tthis.m_monoRamColor.b = value.b;\n\tthis.m_monoRamColor.a = value.a;\n\tTayx.Graphy.Ram.G_RamManager::UpdateParameters(this.m_ramManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_monoRamColor = value;
				m_monoRamColor.g = value.g;
				m_monoRamColor.b = value.b;
				m_monoRamColor.a = value.a;
				m_ramManager.UpdateParameters();
			}
		}

		[Token(Token = "0x17000022")]
		public int RamGraphResolution
		{
			[Token(Token = "0x6000122")]
			[Address(RVA = "0xB16004", Offset = "0xB16004", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_ramGraphResolution;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RamGraphResolution;
			}
			[Token(Token = "0x6000123")]
			[Address(RVA = "0xB10A2C", Offset = "0xB10A2C", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_ramGraphResolution = value;\n\tTayx.Graphy.Ram.G_RamManager::UpdateParameters(this.m_ramManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_ramGraphResolution = value;
				m_ramManager.UpdateParameters();
			}
		}

		[Token(Token = "0x17000023")]
		public int RamTextUpdateRate
		{
			[Token(Token = "0x6000124")]
			[Address(RVA = "0xB1600C", Offset = "0xB1600C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_ramTextUpdateRate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RamTextUpdateRate;
			}
			[Token(Token = "0x6000125")]
			[Address(RVA = "0xB10A6C", Offset = "0xB10A6C", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_ramTextUpdateRate = value;\n\tTayx.Graphy.Ram.G_RamManager::UpdateParameters(this.m_ramManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_ramTextUpdateRate = value;
				m_ramManager.UpdateParameters();
			}
		}

		[Token(Token = "0x17000024")]
		public float AllocatedRam
		{
			[Token(Token = "0x6000126")]
			[Address(RVA = "0xB16014", Offset = "0xB16014", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_ramMonitor;\n\treturn v0.m_allocatedRam;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				G_RamMonitor ramMonitor = m_ramMonitor;
				return ramMonitor.AllocatedRam;
			}
		}

		[Token(Token = "0x17000025")]
		public float ReservedRam
		{
			[Token(Token = "0x6000127")]
			[Address(RVA = "0xB16034", Offset = "0xB16034", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_ramMonitor;\n\treturn v0.m_reservedRam;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				G_RamMonitor ramMonitor = m_ramMonitor;
				return ramMonitor.ReservedRam;
			}
		}

		[Token(Token = "0x17000026")]
		public float MonoRam
		{
			[Token(Token = "0x6000128")]
			[Address(RVA = "0xB16054", Offset = "0xB16054", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_ramMonitor;\n\treturn v0.m_monoRam;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				G_RamMonitor ramMonitor = m_ramMonitor;
				return ramMonitor.MonoRam;
			}
		}

		[Token(Token = "0x17000027")]
		public ModuleState AudioModuleState
		{
			[Token(Token = "0x6000129")]
			[Address(RVA = "0xB16074", Offset = "0xB16074", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_audioModuleState;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AudioModuleState;
			}
			[Token(Token = "0x600012A")]
			[Address(RVA = "0xB10AA8", Offset = "0xB10AA8", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_audioModuleState = value;\n\tTayx.Graphy.Audio.G_AudioManager::SetState(this.m_audioManager, value, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_audioModuleState = value;
				m_audioManager.SetState(value);
			}
		}

		[Token(Token = "0x17000028")]
		public AudioListener AudioListener
		{
			[Token(Token = "0x600012B")]
			[Address(RVA = "0xB1607C", Offset = "0xB1607C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_audioListener;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AudioListener;
			}
			[Token(Token = "0x600012C")]
			[Address(RVA = "0xB16084", Offset = "0xB16084", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_audioListener = value;\n\tTayx.Graphy.Audio.G_AudioManager::UpdateParameters(this.m_audioManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_audioListener = value;
				m_audioManager.UpdateParameters();
			}
		}

		[Token(Token = "0x17000029")]
		public LookForAudioListener FindAudioListenerInCameraIfNull
		{
			[Token(Token = "0x600012D")]
			[Address(RVA = "0xB160A4", Offset = "0xB160A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_findAudioListenerInCameraIfNull;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FindAudioListenerInCameraIfNull;
			}
			[Token(Token = "0x600012E")]
			[Address(RVA = "0xB10C98", Offset = "0xB10C98", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_findAudioListenerInCameraIfNull = value;\n\tTayx.Graphy.Audio.G_AudioManager::UpdateParameters(this.m_audioManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_findAudioListenerInCameraIfNull = value;
				m_audioManager.UpdateParameters();
			}
		}

		[Token(Token = "0x1700002A")]
		public Color AudioGraphColor
		{
			[Token(Token = "0x600012F")]
			[Address(RVA = "0xB160AC", Offset = "0xB160AC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_audioGraphColor;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_audioGraphColor;
			}
			[Token(Token = "0x6000130")]
			[Address(RVA = "0xB10C5C", Offset = "0xB10C5C", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_audioGraphColor = value;\n\tthis.m_audioGraphColor.g = value.g;\n\tthis.m_audioGraphColor.b = value.b;\n\tthis.m_audioGraphColor.a = value.a;\n\tTayx.Graphy.Audio.G_AudioManager::UpdateParameters(this.m_audioManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_audioGraphColor = value;
				m_audioGraphColor.g = value.g;
				m_audioGraphColor.b = value.b;
				m_audioGraphColor.a = value.a;
				m_audioManager.UpdateParameters();
			}
		}

		[Token(Token = "0x1700002B")]
		public int AudioGraphResolution
		{
			[Token(Token = "0x6000131")]
			[Address(RVA = "0xB160B8", Offset = "0xB160B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_audioGraphResolution;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AudioGraphResolution;
			}
			[Token(Token = "0x6000132")]
			[Address(RVA = "0xB10D48", Offset = "0xB10D48", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_audioGraphResolution = value;\n\tTayx.Graphy.Audio.G_AudioManager::UpdateParameters(this.m_audioManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_audioGraphResolution = value;
				m_audioManager.UpdateParameters();
			}
		}

		[Token(Token = "0x1700002C")]
		public int AudioTextUpdateRate
		{
			[Token(Token = "0x6000133")]
			[Address(RVA = "0xB160C0", Offset = "0xB160C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_audioTextUpdateRate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AudioTextUpdateRate;
			}
			[Token(Token = "0x6000134")]
			[Address(RVA = "0xB10D84", Offset = "0xB10D84", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_audioTextUpdateRate = value;\n\tTayx.Graphy.Audio.G_AudioManager::UpdateParameters(this.m_audioManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_audioTextUpdateRate = value;
				m_audioManager.UpdateParameters();
			}
		}

		[Token(Token = "0x1700002D")]
		public FFTWindow FftWindow
		{
			[Token(Token = "0x6000135")]
			[Address(RVA = "0xB160C8", Offset = "0xB160C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_FFTWindow;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FftWindow;
			}
			[Token(Token = "0x6000136")]
			[Address(RVA = "0xB10CD0", Offset = "0xB10CD0", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_FFTWindow = value;\n\tTayx.Graphy.Audio.G_AudioManager::UpdateParameters(this.m_audioManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_FFTWindow = value;
				m_audioManager.UpdateParameters();
			}
		}

		[Token(Token = "0x1700002E")]
		public int SpectrumSize
		{
			[Token(Token = "0x6000137")]
			[Address(RVA = "0xB160D0", Offset = "0xB160D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_spectrumSize;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SpectrumSize;
			}
			[Token(Token = "0x6000138")]
			[Address(RVA = "0xB10D0C", Offset = "0xB10D0C", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_spectrumSize = value;\n\tTayx.Graphy.Audio.G_AudioManager::UpdateParameters(this.m_audioManager);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_spectrumSize = value;
				m_audioManager.UpdateParameters();
			}
		}

		[Token(Token = "0x1700002F")]
		public float[] Spectrum
		{
			[Token(Token = "0x6000139")]
			[Address(RVA = "0xB160D8", Offset = "0xB160D8", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_audioMonitor;\n\treturn v0.m_spectrum;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				G_AudioMonitor audioMonitor = m_audioMonitor;
				return audioMonitor.Spectrum;
			}
		}

		[Token(Token = "0x17000030")]
		public float MaxDB
		{
			[Token(Token = "0x600013A")]
			[Address(RVA = "0xB160F8", Offset = "0xB160F8", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_audioMonitor;\n\treturn v0.m_maxDB;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				G_AudioMonitor audioMonitor = m_audioMonitor;
				return audioMonitor.MaxDB;
			}
		}

		[Token(Token = "0x17000031")]
		public ModuleState AdvancedModuleState
		{
			[Token(Token = "0x600013B")]
			[Address(RVA = "0xB16118", Offset = "0xB16118", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_advancedModuleState;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdvancedModuleState;
			}
			[Token(Token = "0x600013C")]
			[Address(RVA = "0xB10E00", Offset = "0xB10E00", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_advancedModuleState = value;\n\tTayx.Graphy.Advanced.G_AdvancedData::SetState(this.m_advancedData, value, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_advancedModuleState = value;
				m_advancedData.SetState(value);
			}
		}

		[Token(Token = "0x17000032")]
		public ModulePosition AdvancedModulePosition
		{
			[Token(Token = "0x600013D")]
			[Address(RVA = "0xB16120", Offset = "0xB16120", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_advancedModulePosition;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdvancedModulePosition;
			}
			[Token(Token = "0x600013E")]
			[Address(RVA = "0xB10DBC", Offset = "0xB10DBC", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_advancedModulePosition = value;\n\tTayx.Graphy.Advanced.G_AdvancedData::SetPosition(this.m_advancedData, value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_advancedModulePosition = value;
				m_advancedData.SetPosition(value);
			}
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0xB15BE8", Offset = "0xB15BE8", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = &v15 @ stack_-10_v2;\n\tgoto L_0020;\n\tv24 = *([1ED3760]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022551]) = v44;\nL_0020:\n\tthis.m_enableOnStartup = 0x101;\n\tthis.m_background = 1;\n\tv50 = 0;\n\tv57 = 0x101059C(&v50 @ stack_-50_v1 (System.Single), 0, v28, v29, v30, v31, v32, v33, 0, 0, 0, 0.3f, v38, v39, v40, v41);\n\tthis.m_toggleModeKeyCode = 0x67;\n\tthis.m_toggleActiveKeyCode = 0x68;\n\tv66 = &v15 @ stack_-10_v2 - 0x28;\n\tthis.m_timeToResetMinMaxFps = 0xA;\n\tthis.m_enableHotkeys = 1;\n\tthis.m_toggleModeCtrl = 1;\n\tthis.m_toggleActiveCtrl = 1;\n\tthis.m_backgroundColor.r = 0f;\n\tthis.m_backgroundColor.g = v60;\n\tthis.m_backgroundColor.a = v62;\n\t*([v14 @ X29_v1-28]) = 0;\n\tv72 = 0x1010E50(v66, 0x76, 0xD4, 0x3A, 0xFF, 0, v32, v33, 0, 0, 0, 0.3f, v38, v39, v40, v41);\n\tv75 = UnityEngine.Color32::op_Implicit(*([v14 @ X29_v1-28]));\n\tthis.m_goodFpsColor = v75;\n\tthis.m_goodFpsColor.g = v75.g;\n\tthis.m_goodFpsColor.b = v75.b;\n\tthis.m_goodFpsColor.a = v75.a;\n\tthis.m_goodFpsThreshold = 0x3C;\n\tv81 = 0;\n\tv87 = 0x1010E50(&v81 @ stack_-58_v1 (UnityEngine.Color32), 0xF3, 0xE8, 0, 0xFF, 0, v32, v33, v75, v75.g, v75.b, v75.a, v38, v39, v40, v41);\n\tv90 = UnityEngine.Color32::op_Implicit(0);\n\tthis.m_cautionFpsColor = v90;\n\tthis.m_cautionFpsColor.g = v90.g;\n\tthis.m_cautionFpsColor.b = v90.b;\n\tthis.m_cautionFpsColor.a = v90.a;\n\tthis.m_cautionFpsThreshold = 0x1E;\n\tv96 = 0;\n\tv102 = 0x1010E50(&v96 @ stack_-60_v1 (UnityEngine.Color32), 0xDC, 0x29, 0x1E, 0xFF, 0, v32, v33, v90, v90.g, v90.b, v90.a, v38, v39, v40, v41);\n\tv105 = UnityEngine.Color32::op_Implicit(0);\n\tthis.m_criticalFpsColor = v105;\n\tthis.m_criticalFpsColor.g = v105.g;\n\tthis.m_criticalFpsColor.b = v105.b;\n\tthis.m_criticalFpsColor.a = v105.a;\n\tthis.m_fpsGraphResolution = 0x300000097;\n\tv112 = 0;\n\tv118 = 0x1010E50(&v112 @ stack_-68_v1 (UnityEngine.Color32), 0xFF, 0xBE, 0x3C, 0xFF, 0, v32, v33, v105, v105.g, v105.b, v105.a, v38, v39, v40, v41);\n\tv121 = UnityEngine.Color32::op_Implicit(0);\n\tthis.m_allocatedRamColor = v121;\n\tthis.m_allocatedRamColor.g = v121.g;\n\tthis.m_allocatedRamColor.b = v121.b;\n\tthis.m_allocatedRamColor.a = v121.a;\n\tv126 = 0;\n\tv132 = 0x1010E50(&v126 @ stack_-70_v1 (UnityEngine.Color32), 0xCD, 0x54, 0xE5, 0xFF, 0, v32, v33, v121, v121.g, v121.b, v121.a, v38, v39, v40, v41);\n\tv135 = UnityEngine.Color32::op_Implicit(0);\n\tthis.m_reservedRamColor = v135;\n\tthis.m_reservedRamColor.g = v135.g;\n\tthis.m_reservedRamColor.b = v135.b;\n\tthis.m_reservedRamColor.a = v135.a;\n\tv143 = 0;\n\tv148 = 0x101059C(&v143 @ stack_-80_v1 (System.Single), 0, 0x54, 0xE5, 0xFF, 0, v32, v33, 0.3f, 0.65f, 1f, 1f, v38, v39, v40, v41);\n\tthis.m_ramGraphResolution = 0x300000097;\n\tthis.m_monoRamColor.r = 0f;\n\tthis.m_monoRamColor.g = v151;\n\tthis.m_monoRamColor.a = v153;\n\tthis.m_findAudioListenerInCameraIfNull = 1;\n\tv155 = UnityEngine.Color::get_white();\n\tthis.m_audioGraphColor = v155;\n\tthis.m_audioGraphColor.g = v155.g;\n\tthis.m_advancedModulePosition = 3;\n\tthis.m_audioGraphColor.b = v155.b;\n\tthis.m_audioGraphColor.a = v155.a;\n\tthis.m_audioGraphResolution = *([1819240]);\n\tthis.m_active = 0x101;\n\tthis.m_modulePresetState = 0xB;\n\tgoto L_00C9;\n\tv170 = *([v166 @ X0_v22+E0]);\n\tv171 = v170 == 0;\n\tv172 = ~v171;\n\tif (v172) goto L_00C9;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v166, v146, v128, v129, v130, v131, v32, v33, v160, v156, v157, v158, v38, v39, v40, v41);\nL_00C9:\n\tTayx.Graphy.Utils.G_Singleton`1<Tayx.Graphy.GraphyManager>::.ctor(this);\n\treturn;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected GraphyManager()
		{
			//IL_03b0: Expected O, but got I
			//IL_03fb: Expected F4, but got O
			//IL_042b: Expected O, but got I
			//IL_029f: Expected F4, but got O
			object obj2 = default(object);
			object obj = obj2;
			m_enableOnStartup = true;
			m_keepAlive = true;
			m_background = true;
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			m_toggleModeKeyCode = KeyCode.G;
			m_toggleActiveKeyCode = KeyCode.H;
			object obj3 = (long)(IntPtr)obj2 - 40L;
			m_timeToResetMinMaxFps = 10;
			m_enableHotkeys = true;
			m_toggleModeCtrl = true;
			m_toggleActiveCtrl = true;
			m_backgroundColor.r = 0f;
			object obj4 = default(object);
			m_backgroundColor.g = (float)obj4;
			float a = default(float);
			m_backgroundColor.a = a;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-28]");
			Color color = (m_goodFpsColor = (Color32)0);
			m_goodFpsColor.g = color.g;
			m_goodFpsColor.b = color.b;
			m_goodFpsColor.a = color.a;
			m_goodFpsThreshold = 60;
			Color32 color2 = default(Color32);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
			Color color3 = (m_cautionFpsColor = default(Color32));
			m_cautionFpsColor.g = color3.g;
			m_cautionFpsColor.b = color3.b;
			m_cautionFpsColor.a = color3.a;
			m_cautionFpsThreshold = 30;
			Color32 color4 = default(Color32);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
			Color color5 = (m_criticalFpsColor = default(Color32));
			m_criticalFpsColor.g = color5.g;
			m_criticalFpsColor.b = color5.b;
			m_criticalFpsColor.a = color5.a;
			m_fpsGraphResolution = 151;
			m_fpsTextUpdateRate = 3;
			Color32 color6 = default(Color32);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
			Color color7 = (m_allocatedRamColor = default(Color32));
			m_allocatedRamColor.g = color7.g;
			m_allocatedRamColor.b = color7.b;
			m_allocatedRamColor.a = color7.a;
			Color32 color8 = default(Color32);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1010E50 (inside UnityEngine.Color::op_Implicit +0x4)");
			Color color9 = (m_reservedRamColor = default(Color32));
			m_reservedRamColor.g = color9.g;
			m_reservedRamColor.b = color9.b;
			m_reservedRamColor.a = color9.a;
			float num2 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			m_ramGraphResolution = 151;
			m_ramTextUpdateRate = 3;
			m_monoRamColor.r = 0f;
			object obj5 = default(object);
			m_monoRamColor.g = (float)obj5;
			float a2 = default(float);
			m_monoRamColor.a = a2;
			m_findAudioListenerInCameraIfNull = LookForAudioListener.ON_SCENE_LOAD;
			Color color10 = (m_audioGraphColor = Color.white);
			m_audioGraphColor.g = color10.g;
			m_advancedModulePosition = ModulePosition.BOTTOM_LEFT;
			m_audioGraphColor.b = color10.b;
			m_audioGraphColor.a = color10.a;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1819240]");
			m_audioGraphResolution = 0;
			m_active = true;
			m_focused = true;
			m_modulePresetState = ModulePreset.FPS_BASIC_ADVANCED_FULL;
			base._002Ector();
		}

		[Token(Token = "0x600013F")]
		[Address(RVA = "0xB16128", Offset = "0xB16128", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.GraphyManager::Init(this);\n\treturn;\n")]
		private void Start()
		{
			Init();
		}

		[Token(Token = "0x6000140")]
		[Address(RVA = "0xB165BC", Offset = "0xB165BC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.m_focused;\n\tif (v2) goto L_0008;\n\tv4 = ~this.m_enableHotkeys;\n\tif (v4) goto L_0008;\n\tTayx.Graphy.GraphyManager::CheckForHotkeyPresses(this);\n\treturn;\nL_0008:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			if (m_focused && m_enableHotkeys)
			{
				CheckForHotkeyPresses();
			}
		}

		[Token(Token = "0x6000141")]
		[Address(RVA = "0xB16764", Offset = "0xB16764", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_focused = isFocused;\n\tv4 = ~this.m_initialized;\n\tif (v4) goto L_000A;\n\tv6 = isFocused == 0;\n\tif (v6) goto L_000A;\n\tTayx.Graphy.GraphyManager::RefreshAllParameters(this);\n\treturn;\nL_000A:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationFocus(bool isFocused)
		{
			m_focused = isFocused;
			if (m_initialized && isFocused)
			{
				RefreshAllParameters();
			}
		}

		[Token(Token = "0x6000142")]
		[Address(RVA = "0xB167D0", Offset = "0xB167D0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = moduleType < 3;\n\tv14 = ~v12;\n\tv24 = ~v14;\n\tif (v24) goto L_0021;\n\tv25 = moduleType != 3;\n\tif (v25) goto L_003C;\n\tTayx.Graphy.Advanced.G_AdvancedData::SetPosition(this.m_advancedData, modulePosition);\n\treturn;\nL_0021:\n\tthis.m_graphModulePosition = modulePosition;\n\tTayx.Graphy.Ram.G_RamManager::SetPosition(this.m_ramManager, modulePosition);\n\tTayx.Graphy.Fps.G_FpsManager::SetPosition(this.m_fpsManager, modulePosition);\n\tTayx.Graphy.Audio.G_AudioManager::SetPosition(this.m_audioManager, modulePosition);\n\treturn;\nL_003C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetModulePosition(ModuleType moduleType, ModulePosition modulePosition)
		{
			if (moduleType >= ModuleType.ADVANCED)
			{
				if (moduleType == ModuleType.ADVANCED)
				{
					m_advancedData.SetPosition(modulePosition);
				}
			}
			else
			{
				m_graphModulePosition = modulePosition;
				m_ramManager.SetPosition(modulePosition);
				m_fpsManager.SetPosition(modulePosition);
				m_audioManager.SetPosition(modulePosition);
			}
		}

		[Token(Token = "0x6000143")]
		[Address(RVA = "0xB16858", Offset = "0xB16858", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = moduleType < 3;\n\tv8 = ~v6;\n\tv9 = moduleType - 3;\n\tv11 = v9 == 0;\n\tv16 = ~v11;\n\tv17 = v8 & v16;\n\tif (v17) goto L_002D;\n\tv20 = 0x1819000 + 0x2FC;\n\tv22 = *([v20 @ X9_v2 (System.Int32)+moduleType @ X1 (Tayx.Graphy.GraphyManager+ModuleType)*4]) + v20;\n\t// 21 IndirectJump v22 @ X8_v3, this @ X0 (Tayx.Graphy.GraphyManager), this @ X0 (Tayx.Graphy.GraphyManager), moduleType @ X1 (Tayx.Graphy.GraphyManager+ModuleType), moduleState @ X2 (Tayx.Graphy.GraphyManager+ModuleState), methodInfo @ X3 (Il2CppMethodInfo), v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX0 = *([X0+110]);\n\tif (TEMP) goto L_0043;\n\tX1 = X2;\n\tX2 = 0;\n\tX29 = stack[0];\n\tX30 = stack[8];\n\t// 29 ShiftStack 16\n\tTayx.Graphy.Fps.G_FpsManager::SetState(X0, X1, X2, X3);\n\treturn;\n\tX0 = *([X0+120]);\n\tif (TEMP) goto L_0043;\n\tX1 = X2;\n\tX2 = 0;\n\tX29 = stack[0];\n\tX30 = stack[8];\n\t// 39 ShiftStack 16\n\tTayx.Graphy.Audio.G_AudioManager::SetState(X0, X1, X2, X3);\n\treturn;\nL_002D:\n\treturn;\n\tX0 = *([X0+118]);\n\tif (TEMP) goto L_0043;\n\tX1 = X2;\n\tX2 = 0;\n\tX3 = 0;\n\tX29 = stack[0];\n\tX30 = stack[8];\n\t// 54 ShiftStack 16\n\tTayx.Graphy.Ram.G_RamManager::SetState(X0, X1, X2, X3);\n\treturn;\n\tX0 = *([X0+128]);\n\tif (TEMP) goto L_0043;\n\tX1 = X2;\n\tX2 = 0;\n\tX29 = stack[0];\n\tX30 = stack[8];\n\t// 64 ShiftStack 16\n\tTayx.Graphy.Advanced.G_AdvancedData::SetState(X0, X1, X2, X3);\n\treturn;\nL_0043:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetModuleMode(ModuleType moduleType, ModuleState moduleState)
		{
			//IL_0081: Expected O, but got I
			bool flag = moduleType < ModuleType.ADVANCED;
			bool flag2 = !flag;
			int num = (int)(moduleType - 3);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25268224 + 764;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X9_v2 (System.Int32)+moduleType @ X1 (Tayx.Graphy.GraphyManager+ModuleType)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v22 @ X8_v3 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000144")]
		[Address(RVA = "0xB168F0", Offset = "0xB168F0", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv20 = *([1EDD8D0]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022552]) = v40;\nL_001E:\n\tgoto L_0026;\n\tv51 = *([v44 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0026;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0026:\n\tv60 = System.Type::GetTypeFromHandle(Tayx.Graphy.GraphyManager+ModulePreset);\n\tgoto L_0037;\n\tv68 = *([v64 @ X8_v10+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0037;\n\tv78 = v64;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v78, v59, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0037:\n\tv77 = System.Enum::GetNames(v60);\n\tv81 = v77.Length - 1;\n\tv91 = this.m_modulePresetState >= v81;\n\tif (v91) goto L_FFFFFFFF;\n\tv94 = this.m_modulePresetState + 1;\n\tgoto L_004B;\nL_004B:\n\tthis.m_modulePresetState = v96;\n\tTayx.Graphy.GraphyManager::SetPreset(this, v96);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ToggleModes()
		{
			Type typeFromHandle = typeof(ModulePreset);
			string[] names = Enum.GetNames(typeFromHandle);
			int num = names.Length - 1;
			ModulePreset modulePreset;
			if ((int)m_modulePresetState < num)
			{
				int num2 = (int)(m_modulePresetState + 1);
				modulePreset = (ModulePreset)num2;
			}
			else
			{
				modulePreset = default(ModulePreset);
			}
			m_modulePresetState = modulePreset;
			SetPreset(modulePreset);
		}

		[Token(Token = "0x6000145")]
		[Address(RVA = "0xB169D8", Offset = "0xB169D8", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = modulePreset < 0xB;\n\tv12 = ~v10;\n\tv13 = modulePreset - 0xB;\n\tv15 = v13 == 0;\n\tthis.m_modulePresetState = modulePreset;\n\tv20 = ~v15;\n\tv21 = v12 & v20;\n\tif (v21) goto L_0022;\n\tv24 = 0x1819000 + 0x30C;\n\tv26 = *([v24 @ X9_v2 (System.Int32)+modulePreset @ X1 (Tayx.Graphy.GraphyManager+ModulePreset)*4]) + v24;\n\t// 24 IndirectJump v26 @ X8_v3, this @ X0 (Tayx.Graphy.GraphyManager), this @ X0 (Tayx.Graphy.GraphyManager), modulePreset @ X1 (Tayx.Graphy.GraphyManager+ModulePreset), methodInfo @ X2 (Il2CppMethodInfo), v28 @ X3, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tX0 = *([X19+110]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0 | 2;\n\tgoto L_002C;\nL_0022:\n\treturn;\n\tX0 = *([X19+110]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0 | 1;\n\tgoto L_002C;\n\tX0 = *([X19+110]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0;\nL_002C:\n\tX2 = 0;\n\tTayx.Graphy.Fps.G_FpsManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+118]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0 | 4;\n\tgoto L_004D;\n\tX0 = *([X19+110]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0 | 1;\n\tgoto L_003C;\n\tX0 = *([X19+110]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0;\nL_003C:\n\tX2 = 0;\n\tTayx.Graphy.Fps.G_FpsManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+118]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0 | 1;\n\tgoto L_004D;\n\tX0 = *([X19+110]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0;\n\tX2 = 0;\n\tTayx.Graphy.Fps.G_FpsManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+118]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0;\nL_004D:\n\tX2 = 0;\n\tX3 = 0;\n\tTayx.Graphy.Ram.G_RamManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+120]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0 | 4;\n\tgoto L_0088;\n\tX0 = *([X19+110]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0 | 1;\n\tgoto L_005E;\n\tX0 = *([X19+110]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0;\nL_005E:\n\tX2 = 0;\n\tTayx.Graphy.Fps.G_FpsManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+118]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0 | 1;\n\tgoto L_006F;\n\tX0 = *([X19+110]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0;\n\tX2 = 0;\n\tTayx.Graphy.Fps.G_FpsManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+118]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0;\nL_006F:\n\tX2 = 0;\n\tX3 = 0;\n\tTayx.Graphy.Ram.G_RamManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+120]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0 | 1;\n\tgoto L_0088;\n\tX0 = *([X19+110]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0;\n\tX2 = 0;\n\tTayx.Graphy.Fps.G_FpsManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+118]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0;\n\tX2 = 0;\n\tX3 = 0;\n\tTayx.Graphy.Ram.G_RamManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+120]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0;\nL_0088:\n\tX2 = 0;\n\tTayx.Graphy.Audio.G_AudioManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+128]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0 | 4;\nL_008E:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX2 = 0;\n\tX19 = stack[0];\n\t// 146 ShiftStack 32\n\tTayx.Graphy.Advanced.G_AdvancedData::SetState(X0, X1, X2, X3);\n\treturn;\n\tX0 = *([X19+110]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0;\n\tX2 = 0;\n\tTayx.Graphy.Fps.G_FpsManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+118]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0;\n\tX2 = 0;\n\tX3 = 0;\n\tTayx.Graphy.Ram.G_RamManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+120]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0;\n\tgoto L_00B8;\n\tX0 = *([X19+110]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0 | 2;\n\tX2 = 0;\n\tTayx.Graphy.Fps.G_FpsManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+118]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0 | 4;\n\tX2 = 0;\n\tX3 = 0;\n\tTayx.Graphy.Ram.G_RamManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+120]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0 | 4;\nL_00B8:\n\tX2 = 0;\n\tTayx.Graphy.Audio.G_AudioManager::SetState(X0, X1, X2, X3);\n\tX0 = *([X19+128]);\n\tif (TEMP) goto L_00BF;\n\tX1 = 0;\n\tgoto L_008E;\nL_00BF:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPreset(ModulePreset modulePreset)
		{
			//IL_008b: Expected O, but got I
			bool flag = modulePreset < ModulePreset.FPS_BASIC_ADVANCED_FULL;
			bool flag2 = !flag;
			int num = (int)(modulePreset - 11);
			bool flag3 = num == 0;
			m_modulePresetState = modulePreset;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25268224 + 780;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X9_v2 (System.Int32)+modulePreset @ X1 (Tayx.Graphy.GraphyManager+ModulePreset)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v26 @ X8_v3 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000146")]
		[Address(RVA = "0xB16C28", Offset = "0xB16C28", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.m_active;\n\tif (v2) goto L_0005;\n\tTayx.Graphy.GraphyManager::Disable(this);\n\treturn;\nL_0005:\n\tTayx.Graphy.GraphyManager::Enable(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ToggleActive()
		{
			if (m_active)
			{
				Disable();
			}
			else
			{
				Enable();
			}
		}

		[Token(Token = "0x6000147")]
		[Address(RVA = "0xB16C38", Offset = "0xB16C38", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.m_fpsManager;\n\tTayx.Graphy.Fps.G_FpsManager::SetState(this.m_fpsManager, v10.m_previousModuleState, 0);\n\tTayx.Graphy.Ram.G_RamManager::RestorePreviousState(this.m_ramManager);\n\tv28 = this.m_audioManager;\n\tTayx.Graphy.Audio.G_AudioManager::SetState(this.m_audioManager, v28.m_previousModuleState, 0);\n\tv29 = this.m_advancedData;\n\tTayx.Graphy.Advanced.G_AdvancedData::SetState(this.m_advancedData, v29.m_previousModuleState, 0);\n\tthis.m_active = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Enable()
		{
			G_FpsManager fpsManager = m_fpsManager;
			m_fpsManager.SetState(fpsManager.m_previousModuleState);
			m_ramManager.RestorePreviousState();
			G_AudioManager audioManager = m_audioManager;
			m_audioManager.SetState(audioManager.m_previousModuleState);
			G_AdvancedData advancedData = m_advancedData;
			m_advancedData.SetState(advancedData.m_previousModuleState);
			m_active = true;
		}

		[Token(Token = "0x6000148")]
		[Address(RVA = "0xB16CAC", Offset = "0xB16CAC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Fps.G_FpsManager::SetState(this.m_fpsManager, 4, 0);\n\tTayx.Graphy.Ram.G_RamManager::SetState(this.m_ramManager, 4, 0);\n\tTayx.Graphy.Audio.G_AudioManager::SetState(this.m_audioManager, 4, 0);\n\tTayx.Graphy.Advanced.G_AdvancedData::SetState(this.m_advancedData, 4, 0);\n\tthis.m_active = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Disable()
		{
			m_fpsManager.SetState(ModuleState.OFF);
			m_ramManager.SetState(ModuleState.OFF);
			m_audioManager.SetState(ModuleState.OFF);
			m_advancedData.SetState(ModuleState.OFF);
			m_active = false;
		}

		[Token(Token = "0x6000149")]
		[Address(RVA = "0xB1612C", Offset = "0xB1612C", Length = "0x490")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EBBCF8]);\n\tv19 = *([v18 @ X8_v90]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022553]) = v38;\nL_0014:\n\tv40 = ~this.m_keepAlive;\n\tif (v40) goto L_003B;\n\tv43 = UnityEngine.Component::get_transform(this);\n\tv78 = UnityEngine.Transform::get_root(v43);\n\tv170 = UnityEngine.Component::get_gameObject(v78);\n\tgoto L_0031;\n\tv271 = *([v54 @ X8_v87+E0]);\n\tv272 = v271 == 0;\n\tv273 = ~v272;\n\tif (v273) goto L_0031;\n\tv281 = v54;\n\tv275 = \"il2cpp_codegen_runtime_class_init\"(v281, v169, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0031:\n\tUnityEngine.Object::DontDestroyOnLoad(v170);\nL_003B:\n\tgoto L_0043;\n\tv67 = *([v59 @ X0_v5+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0043;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v59, v47, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0043:\n\tv76 = System.Type::GetTypeFromHandle(Tayx.Graphy.Fps.G_FpsMonitor);\n\tv167 = UnityEngine.Component::GetComponentInChildren(this, v76, 1);\n\tv168 = v167 == 0;\n\tif (v168) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0070;\n\tv249 = v249_asT == 0;\n\tif (v249) goto L_FFFFFFFF;\n\tgoto L_0070;\nL_0070:\n\tthis.m_fpsMonitor = v263;\n\tv270 = System.Type::GetTypeFromHandle(Tayx.Graphy.Ram.G_RamMonitor);\n\tv280 = UnityEngine.Component::GetComponentInChildren(this, v270, 1);\n\tv282 = v280 == 0;\n\tif (v282) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00A2;\n\tv324 = v324_asT == 0;\n\tif (v324) goto L_FFFFFFFF;\n\tgoto L_00A2;\nL_00A2:\n\tthis.m_ramMonitor = v338;\n\tv345 = System.Type::GetTypeFromHandle(Tayx.Graphy.Audio.G_AudioMonitor);\n\tv350 = UnityEngine.Component::GetComponentInChildren(this, v345, 1);\n\tv351 = v350 == 0;\n\tif (v351) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00D4;\n\tv393 = v393_asT == 0;\n\tif (v393) goto L_FFFFFFFF;\n\tgoto L_00D4;\nL_00D4:\n\tthis.m_audioMonitor = v407;\n\tv414 = System.Type::GetTypeFromHandle(Tayx.Graphy.Fps.G_FpsManager);\n\tv419 = UnityEngine.Component::GetComponentInChildren(this, v414, 1);\n\tv420 = v419 == 0;\n\tif (v420) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0106;\n\tv462 = v462_asT == 0;\n\tif (v462) goto L_FFFFFFFF;\n\tgoto L_0106;\nL_0106:\n\tthis.m_fpsManager = v476;\n\tv483 = System.Type::GetTypeFromHandle(Tayx.Graphy.Ram.G_RamManager);\n\tv488 = UnityEngine.Component::GetComponentInChildren(this, v483, 1);\n\tv489 = v488 == 0;\n\tif (v489) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0138;\n\tv531 = v531_asT == 0;\n\tif (v531) goto L_FFFFFFFF;\n\tgoto L_0138;\nL_0138:\n\tthis.m_ramManager = v545;\n\tv552 = System.Type::GetTypeFromHandle(Tayx.Graphy.Audio.G_AudioManager);\n\tv557 = UnityEngine.Component::GetComponentInChildren(this, v552, 1);\n\tv558 = v557 == 0;\n\tif (v558) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_016A;\n\tv600 = v600_asT == 0;\n\tif (v600) goto L_FFFFFFFF;\n\tgoto L_016A;\nL_016A:\n\tthis.m_audioManager = v614;\n\tv621 = System.Type::GetTypeFromHandle(Tayx.Graphy.Advanced.G_AdvancedData);\n\tv623 = UnityEngine.Component::GetComponentInChildren(this, v621, 1);\n\tv624 = v623 == 0;\n\tif (v624) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_019D;\n\tv666 = v666_asT == 0;\n\tif (v666) goto L_FFFFFFFF;\n\tgoto L_019D;\nL_019D:\n\tthis.m_advancedData = v159;\n\tTayx.Graphy.Fps.G_FpsManager::SetPosition(this.m_fpsManager, this.m_graphModulePosition);\n\tTayx.Graphy.Ram.G_RamManager::SetPosition(this.m_ramManager, this.m_graphModulePosition);\n\tTayx.Graphy.Audio.G_AudioManager::SetPosition(this.m_audioManager, this.m_graphModulePosition);\n\tTayx.Graphy.Advanced.G_AdvancedData::SetPosition(this.m_advancedData, this.m_advancedModulePosition);\n\tTayx.Graphy.Fps.G_FpsManager::SetState(this.m_fpsManager, this.m_fpsModuleState, 0);\n\tTayx.Graphy.Ram.G_RamManager::SetState(this.m_ramManager, this.m_ramModuleState, 0);\n\tTayx.Graphy.Audio.G_AudioManager::SetState(this.m_audioManager, this.m_audioModuleState, 0);\n\tTayx.Graphy.Advanced.G_AdvancedData::SetState(this.m_advancedData, this.m_advancedModuleState, 0);\n\tv671 = ~this.m_enableOnStartup;\n\tv672 = ~v671;\n\tif (v672) goto L_01DC;\n\tTayx.Graphy.GraphyManager::ToggleActive(this);\n\tv145 = UnityEngine.Component::GetComponent(this);\n\tUnityEngine.Behaviour::set_enabled(v145, 1);\nL_01DC:\n\tthis.m_initialized = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 372 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Init()
		{
			if (KeepAlive)
			{
				Transform transform = base.transform;
				Transform root = transform.root;
				GameObject target = root.gameObject;
				UnityEngine.Object.DontDestroyOnLoad(target);
			}
			Type typeFromHandle = typeof(G_FpsMonitor);
			Component componentInChildren = GetComponentInChildren(typeFromHandle, includeInactive: true);
			Component fpsMonitor;
			if ((object)componentInChildren == null)
			{
				fpsMonitor = null;
			}
			else
			{
				G_FpsMonitor g_FpsMonitor = componentInChildren as G_FpsMonitor;
				fpsMonitor = (((object)g_FpsMonitor == null) ? null : componentInChildren);
			}
			m_fpsMonitor = (G_FpsMonitor)fpsMonitor;
			Type typeFromHandle2 = typeof(G_RamMonitor);
			Component componentInChildren2 = GetComponentInChildren(typeFromHandle2, includeInactive: true);
			Component ramMonitor;
			if ((object)componentInChildren2 == null)
			{
				ramMonitor = null;
			}
			else
			{
				G_RamMonitor g_RamMonitor = componentInChildren2 as G_RamMonitor;
				ramMonitor = (((object)g_RamMonitor == null) ? null : componentInChildren2);
			}
			m_ramMonitor = (G_RamMonitor)ramMonitor;
			Type typeFromHandle3 = typeof(G_AudioMonitor);
			Component componentInChildren3 = GetComponentInChildren(typeFromHandle3, includeInactive: true);
			Component audioMonitor;
			if ((object)componentInChildren3 == null)
			{
				audioMonitor = null;
			}
			else
			{
				G_AudioMonitor g_AudioMonitor = componentInChildren3 as G_AudioMonitor;
				audioMonitor = (((object)g_AudioMonitor == null) ? null : componentInChildren3);
			}
			m_audioMonitor = (G_AudioMonitor)audioMonitor;
			Type typeFromHandle4 = typeof(G_FpsManager);
			Component componentInChildren4 = GetComponentInChildren(typeFromHandle4, includeInactive: true);
			Component fpsManager;
			if ((object)componentInChildren4 == null)
			{
				fpsManager = null;
			}
			else
			{
				G_FpsManager g_FpsManager = componentInChildren4 as G_FpsManager;
				fpsManager = (((object)g_FpsManager == null) ? null : componentInChildren4);
			}
			m_fpsManager = (G_FpsManager)fpsManager;
			Type typeFromHandle5 = typeof(G_RamManager);
			Component componentInChildren5 = GetComponentInChildren(typeFromHandle5, includeInactive: true);
			Component ramManager;
			if ((object)componentInChildren5 == null)
			{
				ramManager = null;
			}
			else
			{
				G_RamManager g_RamManager = componentInChildren5 as G_RamManager;
				ramManager = (((object)g_RamManager == null) ? null : componentInChildren5);
			}
			m_ramManager = (G_RamManager)ramManager;
			Type typeFromHandle6 = typeof(G_AudioManager);
			Component componentInChildren6 = GetComponentInChildren(typeFromHandle6, includeInactive: true);
			Component audioManager;
			if ((object)componentInChildren6 == null)
			{
				audioManager = null;
			}
			else
			{
				G_AudioManager g_AudioManager = componentInChildren6 as G_AudioManager;
				audioManager = (((object)g_AudioManager == null) ? null : componentInChildren6);
			}
			m_audioManager = (G_AudioManager)audioManager;
			Type typeFromHandle7 = typeof(G_AdvancedData);
			Component componentInChildren7 = GetComponentInChildren(typeFromHandle7, includeInactive: true);
			Component advancedData;
			if ((object)componentInChildren7 == null)
			{
				advancedData = null;
			}
			else
			{
				G_AdvancedData g_AdvancedData = componentInChildren7 as G_AdvancedData;
				advancedData = (((object)g_AdvancedData == null) ? null : componentInChildren7);
			}
			m_advancedData = (G_AdvancedData)advancedData;
			m_fpsManager.SetPosition(GraphModulePosition);
			m_ramManager.SetPosition(GraphModulePosition);
			m_audioManager.SetPosition(GraphModulePosition);
			m_advancedData.SetPosition(AdvancedModulePosition);
			m_fpsManager.SetState(FpsModuleState);
			m_ramManager.SetState(RamModuleState);
			m_audioManager.SetState(AudioModuleState);
			m_advancedData.SetState(AdvancedModuleState);
			if (!EnableOnStartup)
			{
				ToggleActive();
				Canvas component = GetComponent<Canvas>();
				component.enabled = true;
			}
			m_initialized = true;
		}

		[Token(Token = "0x600014A")]
		[Address(RVA = "0xB165D4", Offset = "0xB165D4", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv61 = this.m_toggleModeKeyCode;\n\tv13 = ~this.m_toggleModeCtrl;\n\tif (v13) goto L_002D;\n\tv14 = ~this.m_toggleModeAlt;\n\tif (v14) goto L_0039;\n\tv18 = Tayx.Graphy.GraphyManager::CheckFor3KeyPress(this, v61, 0x132, 0x134);\n\tv29 = v18 == 0;\n\tv30 = ~v29;\n\tif (v30) goto L_0045;\n\tv61 = this.m_toggleModeKeyCode;\n\tv43 = Tayx.Graphy.GraphyManager::CheckFor3KeyPress(v18, this.m_toggleModeKeyCode, 0x131, 0x134);\n\tv71 = v43 == 0;\n\tv58 = ~v71;\n\tif (v58) goto L_0045;\n\tv61 = this.m_toggleModeKeyCode;\n\tv46 = Tayx.Graphy.GraphyManager::CheckFor3KeyPress(v43, this.m_toggleModeKeyCode, 0x131, 0x133);\n\tv87 = v46 == 0;\n\tv59 = ~v87;\n\tif (v59) goto L_0045;\n\tv61 = this.m_toggleModeKeyCode;\n\tv47 = Tayx.Graphy.GraphyManager::CheckFor3KeyPress(v46, this.m_toggleModeKeyCode, 0x132, 0x133);\n\tv111 = v47 == 0;\n\tv60 = ~v111;\n\tif (v60) goto L_0045;\n\tgoto L_0048;\nL_002D:\n\tv15 = ~this.m_toggleModeAlt;\n\tif (v15) goto L_008D;\n\tv24 = Tayx.Graphy.GraphyManager::CheckFor2KeyPress(this, v61, 0x134);\n\tv35 = v24 == 0;\n\tv36 = ~v35;\n\tif (v36) goto L_0045;\n\tv61 = this.m_toggleModeKeyCode;\n\tgoto L_0040;\nL_0039:\n\tv21 = Tayx.Graphy.GraphyManager::CheckFor2KeyPress(this, v61, 0x132);\n\tv32 = v21 == 0;\n\tv33 = ~v32;\n\tif (v33) goto L_0045;\n\tv61 = this.m_toggleModeKeyCode;\nL_0040:\n\tv45 = Tayx.Graphy.GraphyManager::CheckFor2KeyPress(v81, v61, v52);\n\tv57 = v45 == 0;\n\tif (v57) goto L_0048;\nL_0045:\n\tTayx.Graphy.GraphyManager::ToggleModes(this);\nL_0048:\n\tv132 = this.m_toggleActiveKeyCode;\n\tv80 = ~this.m_toggleActiveCtrl;\n\tif (v80) goto L_006D;\n\tv83 = ~this.m_toggleActiveAlt;\n\tif (v83) goto L_0079;\n\tv90 = Tayx.Graphy.GraphyManager::CheckFor3KeyPress(v72, v132, 0x132, 0x134);\n\tv99 = v90 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0089;\n\tv132 = this.m_toggleActiveKeyCode;\n\tv115 = Tayx.Graphy.GraphyManager::CheckFor3KeyPress(v90, this.m_toggleActiveKeyCode, 0x131, 0x134);\n\tv153 = v115 == 0;\n\tv129 = ~v153;\n\tif (v129) goto L_0089;\n\tv132 = this.m_toggleActiveKeyCode;\n\tv118 = Tayx.Graphy.GraphyManager::CheckFor3KeyPress(v115, this.m_toggleActiveKeyCode, 0x131, 0x133);\n\tv166 = v118 == 0;\n\tv130 = ~v166;\n\tif (v130) goto L_0089;\n\tv132 = this.m_toggleActiveKeyCode;\n\tv119 = Tayx.Graphy.GraphyManager::CheckFor3KeyPress(v118, this.m_toggleActiveKeyCode, 0x132, 0x133);\n\tv168 = v119 == 0;\n\tv131 = ~v168;\n\tif (v131) goto L_0089;\n\tgoto L_009E;\nL_006D:\n\tv84 = ~this.m_toggleActiveAlt;\n\tif (v84) goto L_0095;\n\tv94 = Tayx.Graphy.GraphyManager::CheckFor2KeyPress(v72, v132, 0x134);\n\tv105 = v94 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_0089;\n\tv132 = this.m_toggleActiveKeyCode;\n\tgoto L_0080;\nL_0079:\n\tv92 = Tayx.Graphy.GraphyManager::CheckFor2KeyPress(v72, v132, 0x132);\n\tv102 = v92 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_0089;\n\tv132 = this.m_toggleActiveKeyCode;\nL_0080:\n\tv117 = Tayx.Graphy.GraphyManager::CheckFor2KeyPress(v154, v132, v124);\n\tv128 = v117 == 0;\n\tif (v128) goto L_009E;\nL_0089:\n\tTayx.Graphy.GraphyManager::ToggleActive(this);\n\treturn;\nL_008D:\n\tv27 = UnityEngine.Input::GetKeyDown(this.m_toggleModeKeyCode);\n\tv38 = v27 == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_0045;\n\tgoto L_0048;\nL_0095:\n\tv97 = UnityEngine.Input::GetKeyDown(this.m_toggleActiveKeyCode);\n\tv108 = v97 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_0089;\nL_009E:\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CheckForHotkeyPresses()
		{
			//IL_04fd: Expected O, but got I4
			//IL_01e7: Expected O, but got I4
			//IL_0242: Expected O, but got I4
			//IL_0571: Expected O, but got I4
			//IL_00a4: Expected O, but got I4
			//IL_00f4: Expected O, but got I4
			//IL_0441: Expected O, but got I4
			//IL_049f: Expected O, but got I4
			//IL_0307: Expected O, but got I4
			//IL_0144: Expected O, but got I4
			//IL_0356: Expected O, but got I4
			//IL_0179: Expected O, but got I4
			//IL_03a5: Expected O, but got I4
			KeyCode toggleModeKeyCode = m_toggleModeKeyCode;
			GraphyManager graphyManager;
			GraphyManager graphyManager2;
			KeyCode key;
			if (m_toggleModeCtrl)
			{
				if (m_toggleModeAlt)
				{
					bool flag = CheckFor3KeyPress(toggleModeKeyCode, KeyCode.LeftControl, KeyCode.LeftAlt);
					if (!flag)
					{
						toggleModeKeyCode = m_toggleModeKeyCode;
						bool flag2 = ((GraphyManager)flag).CheckFor3KeyPress(m_toggleModeKeyCode, KeyCode.RightControl, KeyCode.LeftAlt);
						if (!flag2)
						{
							toggleModeKeyCode = m_toggleModeKeyCode;
							bool flag3 = ((GraphyManager)flag2).CheckFor3KeyPress(m_toggleModeKeyCode, KeyCode.RightControl, KeyCode.RightAlt);
							if (!flag3)
							{
								toggleModeKeyCode = m_toggleModeKeyCode;
								bool flag4 = ((GraphyManager)flag3).CheckFor3KeyPress(m_toggleModeKeyCode, KeyCode.LeftControl, KeyCode.RightAlt);
								if (!flag4)
								{
									graphyManager = (GraphyManager)flag4;
									goto IL_0261;
								}
							}
						}
					}
				}
				else
				{
					bool flag5 = CheckFor2KeyPress(toggleModeKeyCode, KeyCode.LeftControl);
					if (!flag5)
					{
						toggleModeKeyCode = m_toggleModeKeyCode;
						graphyManager2 = (GraphyManager)flag5;
						key = KeyCode.RightControl;
						goto IL_0545;
					}
				}
			}
			else if (m_toggleModeAlt)
			{
				bool flag6 = CheckFor2KeyPress(toggleModeKeyCode, KeyCode.LeftAlt);
				if (!flag6)
				{
					toggleModeKeyCode = m_toggleModeKeyCode;
					graphyManager2 = (GraphyManager)flag6;
					key = KeyCode.RightAlt;
					goto IL_0545;
				}
			}
			else
			{
				bool keyDown = Input.GetKeyDown(m_toggleModeKeyCode);
				bool flag7 = !keyDown;
				bool flag8 = !flag7;
				toggleModeKeyCode = default(KeyCode);
				if (!flag8)
				{
					graphyManager = (GraphyManager)keyDown;
					goto IL_0261;
				}
			}
			goto IL_0250;
			IL_0545:
			bool flag9 = graphyManager2.CheckFor2KeyPress(toggleModeKeyCode, key);
			bool flag10 = !flag9;
			graphyManager = (GraphyManager)flag9;
			if (!flag10)
			{
				goto IL_0250;
			}
			goto IL_0261;
			IL_0261:
			KeyCode toggleActiveKeyCode = m_toggleActiveKeyCode;
			GraphyManager graphyManager3;
			KeyCode key2;
			if (m_toggleActiveCtrl)
			{
				if (m_toggleActiveAlt)
				{
					bool flag11 = graphyManager.CheckFor3KeyPress(toggleActiveKeyCode, KeyCode.LeftControl, KeyCode.LeftAlt);
					if (!flag11)
					{
						toggleActiveKeyCode = m_toggleActiveKeyCode;
						bool flag12 = ((GraphyManager)flag11).CheckFor3KeyPress(m_toggleActiveKeyCode, KeyCode.RightControl, KeyCode.LeftAlt);
						if (!flag12)
						{
							toggleActiveKeyCode = m_toggleActiveKeyCode;
							bool flag13 = ((GraphyManager)flag12).CheckFor3KeyPress(m_toggleActiveKeyCode, KeyCode.RightControl, KeyCode.RightAlt);
							if (!flag13)
							{
								toggleActiveKeyCode = m_toggleActiveKeyCode;
								if (!((GraphyManager)flag13).CheckFor3KeyPress(m_toggleActiveKeyCode, KeyCode.LeftControl, KeyCode.RightAlt))
								{
									return;
								}
							}
						}
					}
				}
				else
				{
					bool flag14 = graphyManager.CheckFor2KeyPress(toggleActiveKeyCode, KeyCode.LeftControl);
					if (!flag14)
					{
						toggleActiveKeyCode = m_toggleActiveKeyCode;
						graphyManager3 = (GraphyManager)flag14;
						key2 = KeyCode.RightControl;
						goto IL_0580;
					}
				}
			}
			else if (m_toggleActiveAlt)
			{
				bool flag15 = graphyManager.CheckFor2KeyPress(toggleActiveKeyCode, KeyCode.LeftAlt);
				if (!flag15)
				{
					toggleActiveKeyCode = m_toggleActiveKeyCode;
					graphyManager3 = (GraphyManager)flag15;
					key2 = KeyCode.RightAlt;
					goto IL_0580;
				}
			}
			else
			{
				bool keyDown2 = Input.GetKeyDown(m_toggleActiveKeyCode);
				bool flag16 = !keyDown2;
				bool flag17 = !flag16;
				toggleActiveKeyCode = default(KeyCode);
				if (!flag17)
				{
					return;
				}
			}
			goto IL_04ad;
			IL_0580:
			if (!graphyManager3.CheckFor2KeyPress(toggleActiveKeyCode, key2))
			{
				return;
			}
			goto IL_04ad;
			IL_0250:
			ToggleModes();
			graphyManager = this;
			goto IL_0261;
			IL_04ad:
			ToggleActive();
		}

		[Token(Token = "0x600014B")]
		[Address(RVA = "0xB16E64", Offset = "0xB16E64", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Input::GetKeyDown(key);\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool CheckFor1KeyPress(KeyCode key)
		{
			return Input.GetKeyDown(key);
		}

		[Token(Token = "0x600014C")]
		[Address(RVA = "0xB16DF4", Offset = "0xB16DF4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = UnityEngine.Input::GetKeyDown(key1);\n\tv18 = v16 == 0;\n\tif (v18) goto L_0018;\n\tv21 = UnityEngine.Input::GetKey(key2);\n\tv23 = v21 == 0;\n\tif (v23) goto L_0018;\n\tgoto L_002B;\nL_0018:\n\tv28 = UnityEngine.Input::GetKeyDown(key2);\n\tv31 = v28 == 0;\n\tif (v31) goto L_FFFFFFFF;\n\treturnVal2 = UnityEngine.Input::GetKey(key1);\n\treturn returnVal2;\nL_002B:\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool CheckFor2KeyPress(KeyCode key1, KeyCode key2)
		{
			if (Input.GetKeyDown(key1) && Input.GetKey(key2))
			{
				return true;
			}
			if (Input.GetKeyDown(key2))
			{
				return Input.GetKey(key1);
			}
			return false;
		}

		[Token(Token = "0x600014D")]
		[Address(RVA = "0xB16D24", Offset = "0xB16D24", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = UnityEngine.Input::GetKeyDown(key1);\n\tv22 = v20 == 0;\n\tif (v22) goto L_001F;\n\tv25 = UnityEngine.Input::GetKey(key2);\n\tv28 = v25 == 0;\n\tif (v28) goto L_001F;\n\tv32 = UnityEngine.Input::GetKey(key3);\n\tv54 = v32 == 0;\n\tv27 = ~v54;\n\tif (v27) goto L_FFFFFFFF;\nL_001F:\n\tv35 = UnityEngine.Input::GetKeyDown(key2);\n\tv38 = v35 == 0;\n\tif (v38) goto L_0033;\n\tv42 = UnityEngine.Input::GetKey(key1);\n\tv44 = v42 == 0;\n\tif (v44) goto L_0033;\n\tv49 = UnityEngine.Input::GetKey(key3);\n\tv45 = v49 == 0;\n\tif (v45) goto L_0033;\n\tgoto L_004E;\nL_0033:\n\tv52 = UnityEngine.Input::GetKeyDown(key3);\n\tv57 = v52 == 0;\n\tif (v57) goto L_FFFFFFFF;\n\tv65 = UnityEngine.Input::GetKey(key1);\n\tv67 = v65 == 0;\n\tif (v67) goto L_FFFFFFFF;\n\treturnVal2 = UnityEngine.Input::GetKey(key2);\n\treturn returnVal2;\nL_004E:\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool CheckFor3KeyPress(KeyCode key1, KeyCode key2, KeyCode key3)
		{
			if ((Input.GetKeyDown(key1) && Input.GetKey(key2) && Input.GetKey(key3)) || (Input.GetKeyDown(key2) && Input.GetKey(key1) && Input.GetKey(key3)))
			{
				return true;
			}
			if (Input.GetKeyDown(key3) && Input.GetKey(key1))
			{
				return Input.GetKey(key2);
			}
			return false;
		}

		[Token(Token = "0x600014E")]
		[Address(RVA = "0xB15E88", Offset = "0xB15E88", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Fps.G_FpsManager::UpdateParameters(this.m_fpsManager);\n\tTayx.Graphy.Ram.G_RamManager::UpdateParameters(this.m_ramManager);\n\tTayx.Graphy.Audio.G_AudioManager::UpdateParameters(this.m_audioManager);\n\tTayx.Graphy.Advanced.G_AdvancedData::UpdateParameters(this.m_advancedData);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void UpdateAllParameters()
		{
			m_fpsManager.UpdateParameters();
			m_ramManager.UpdateParameters();
			m_audioManager.UpdateParameters();
			m_advancedData.UpdateParameters();
		}

		[Token(Token = "0x600014F")]
		[Address(RVA = "0xB16780", Offset = "0xB16780", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Fps.G_FpsManager::RefreshParameters(this.m_fpsManager);\n\tTayx.Graphy.Ram.G_RamManager::RefreshParameters(this.m_ramManager);\n\tTayx.Graphy.Audio.G_AudioManager::RefreshParameters(this.m_audioManager);\n\tTayx.Graphy.Advanced.G_AdvancedData::RefreshParameters(this.m_advancedData);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RefreshAllParameters()
		{
			m_fpsManager.RefreshParameters();
			m_ramManager.RefreshParameters();
			m_audioManager.RefreshParameters();
			m_advancedData.RefreshParameters();
		}
	}
}
