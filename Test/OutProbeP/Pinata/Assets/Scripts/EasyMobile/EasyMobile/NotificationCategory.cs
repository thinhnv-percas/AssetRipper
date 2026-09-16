using System;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000075")]
	public class NotificationCategory
	{
		[Token(Token = "0x2000135")]
		public enum Importance
		{
			[Token(Token = "0x400052F")]
			Default = 0,
			[Token(Token = "0x4000530")]
			High = 1,
			[Token(Token = "0x4000531")]
			Low = 2,
			[Token(Token = "0x4000532")]
			Min = 4,
			[Token(Token = "0x4000533")]
			None = 5,
			[Token(Token = "0x4000534")]
			Unspecified = 6
		}

		[Token(Token = "0x2000136")]
		public enum LightOptions
		{
			[Token(Token = "0x4000536")]
			Off = 0,
			[Token(Token = "0x4000537")]
			Default = 1,
			[Token(Token = "0x4000538")]
			Custom = 2
		}

		[Token(Token = "0x2000137")]
		public enum SoundOptions
		{
			[Token(Token = "0x400053A")]
			Off = 0,
			[Token(Token = "0x400053B")]
			Default = 1,
			[Token(Token = "0x400053C")]
			Custom = 2
		}

		[Token(Token = "0x2000138")]
		public enum VibrationOptions
		{
			[Token(Token = "0x400053E")]
			Off = 0,
			[Token(Token = "0x400053F")]
			Default = 1,
			[Token(Token = "0x4000540")]
			Custom = 2
		}

		[Token(Token = "0x2000139")]
		public enum LockScreenVisibilityOptions
		{
			[Token(Token = "0x4000542")]
			Secret = 0,
			[Token(Token = "0x4000543")]
			Private = 1,
			[Token(Token = "0x4000544")]
			Public = 2
		}

		[Serializable]
		[StructLayout((LayoutKind)0, Size = 16)]
		[Token(Token = "0x200013A")]
		public struct ActionButton
		{
			[Token(Token = "0x4000545")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public string id;

			[Token(Token = "0x4000546")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public string title;
		}

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x732F58", Offset = "0x732F58")]
		[Token(Token = "0x40002B1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public string id;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x732F90", Offset = "0x732F90")]
		[Token(Token = "0x40002B2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public string groupId;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x732FC8", Offset = "0x732FC8")]
		[Token(Token = "0x40002B3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		public string name;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x733000", Offset = "0x733000")]
		[Token(Token = "0x40002B4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		public string description;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x733038", Offset = "0x733038")]
		[Token(Token = "0x40002B5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		public Importance importance;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x733070", Offset = "0x733070")]
		[Token(Token = "0x40002B6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x34")]
		public bool enableBadge;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7330A8", Offset = "0x7330A8")]
		[Token(Token = "0x40002B7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
		public LightOptions lights;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7330E0", Offset = "0x7330E0")]
		[Token(Token = "0x40002B8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3C")]
		public Color lightColor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x733118", Offset = "0x733118")]
		[Token(Token = "0x40002B9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4C")]
		public VibrationOptions vibration;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x733150", Offset = "0x733150")]
		[Token(Token = "0x40002BA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
		public int[] vibrationPattern;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x733188", Offset = "0x733188")]
		[Token(Token = "0x40002BB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
		public LockScreenVisibilityOptions lockScreenVisibility;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7331C0", Offset = "0x7331C0")]
		[Token(Token = "0x40002BC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x5C")]
		public SoundOptions sound;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7331F8", Offset = "0x7331F8")]
		[Token(Token = "0x40002BD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
		public string soundName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x733230", Offset = "0x733230")]
		[Token(Token = "0x40002BE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x68")]
		public ActionButton[] actionButtons;

		[Token(Token = "0x6000564")]
		[Address(RVA = "0xFCF6E8", Offset = "0xFCF6E8", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.enableBadge = 1;\n\tthis.lights = 1;\n\tv14 = UnityEngine.Color::get_white();\n\tthis.lightColor = v14;\n\tthis.lightColor.g = v14.g;\n\tthis.lightColor.b = v14.b;\n\tthis.lightColor.a = v14.a;\n\tthis.vibration = 1;\n\tthis.lockScreenVisibility = 2;\n\tthis.sound = 1;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NotificationCategory()
		{
			enableBadge = true;
			lights = LightOptions.Default;
			Color color = (lightColor = Color.white);
			lightColor.g = color.g;
			lightColor.b = color.b;
			lightColor.a = color.a;
			vibration = VibrationOptions.Default;
			lockScreenVisibility = LockScreenVisibilityOptions.Public;
			sound = SoundOptions.Default;
		}
	}
}
