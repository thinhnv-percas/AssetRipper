using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Unco.UncoButtonSystem
{
	[Serializable]
	[Token(Token = "0x200000C")]
	public class ButtonAnimationConfig
	{
		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x10")]
		public Transform TargetTransform;

		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x18")]
		public TweenSettings UpSettings;

		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x48")]
		public TweenSettings DownSettings;

		[Unit(Units.PercentMultiplier)]
		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x78")]
		public float UpValue;

		[Unit(Units.PercentMultiplier)]
		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x7C")]
		public float DownValue;

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x81BFC70", Offset = "0x81BFC70", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPrimeTween.TweenSettings::.ctor(&v20 @ stack_-50_v2 (PrimeTween.TweenSettings), 0.2f, 9, 1, 0, 0f, 0f, 0, 0);\n\tthis.UpSettings = v20;\n\tthis.UpSettings.cycles = 0;\n\tthis.UpSettings.useUnscaledTime = 0;\n\tPrimeTween.TweenSettings::.ctor(&v49 @ stack_-80_v2 (PrimeTween.TweenSettings), 0.1f, 9, 1, 0, 0f, 0f, 0, 0);\n\tthis.DownSettings = v49;\n\tthis.DownSettings.cycles = 0;\n\tthis.DownSettings.useUnscaledTime = 0;\n\tthis.UpValue = 0.005312499583087629d;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ButtonAnimationConfig()
		{
			TweenSettings upSettings = new TweenSettings(0.2f, Ease.OutCubic);
			UpSettings = upSettings;
			UpSettings.cycles = 0;
			UpSettings.useUnscaledTime = false;
			TweenSettings downSettings = new TweenSettings(0.1f, Ease.OutCubic);
			DownSettings = downSettings;
			DownSettings.cycles = 0;
			DownSettings.useUnscaledTime = false;
			UpValue = 1.02f;
			DownValue = 0.96f;
		}
	}
}
