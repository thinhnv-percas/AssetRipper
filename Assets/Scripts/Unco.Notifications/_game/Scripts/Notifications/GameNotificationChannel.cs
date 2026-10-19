using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Scripts.Notifications
{
	[Token(Token = "0x2000008")]
	public struct GameNotificationChannel
	{
		[Token(Token = "0x2000009")]
		public enum NotificationStyle
		{
			[Token(Token = "0x400001F")]
			None = 0,
			[Token(Token = "0x4000020")]
			NoSound = 2,
			[Token(Token = "0x4000021")]
			Default = 3,
			[Token(Token = "0x4000022")]
			Popup = 4
		}

		[Token(Token = "0x200000A")]
		public enum PrivacyMode
		{
			[Token(Token = "0x4000024")]
			Secret = -1,
			[Token(Token = "0x4000025")]
			Private = 0,
			[Token(Token = "0x4000026")]
			Public = 1
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200000B")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000027")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000028")]
			public static Func<long, int> _003C_003E9__13_0;

			[Token(Token = "0x6000049")]
			[Address(RVA = "0x81B5764", Offset = "0x81B5764", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.Scripts.Notifications.GameNotificationChannel+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600004A")]
			[Address(RVA = "0x81B57C8", Offset = "0x81B57C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal int _003C_002Ector_003Eb__13_0(long v)
			{
				//IL_0005: Expected I4, but got I8
				return (int)v;
			}
		}

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x0")]
		public readonly string Id;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x8")]
		public readonly string Name;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x10")]
		public readonly string Description;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x18")]
		public readonly bool ShowsBadge;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x19")]
		public readonly bool ShowLights;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x1A")]
		public readonly bool Vibrates;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x1B")]
		public readonly bool HighPriority;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x1C")]
		public readonly NotificationStyle Style;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x20")]
		public readonly PrivacyMode Privacy;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x28")]
		public readonly int[] VibrationPattern;

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x81B54FC", Offset = "0x81B54FC", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ShowsBadge = 0;\n\tthis.VibrationPattern = 0;\n\tthis.Name = 0;\n\tthis.Id = id;\n\tthis.Name = name;\n\tthis.Description = description;\n\tthis.ShowsBadge = 1;\n\tthis.Style = 2.121995793E-314d;\n\tthis.VibrationPattern = 0;\n\treturn;\n")]
		public GameNotificationChannel(string id, string name, string description)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameNotificationChannel::.ctor");
			this = default;
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x81B5594", Offset = "0x81B5594", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tthis.ShowsBadge = showsBadge;\n\tthis.ShowLights = showLights;\n\tthis.Vibrates = vibrates;\n\tthis.HighPriority = highPriority;\n\tthis.Style = style;\n\tthis.Privacy = privacy;\n\tv96 = vibrationPattern == 0;\n\tif (v96) goto L_FFFFFFFF;\n\tgoto L_0058;\n\tgoto L_0067;\nL_0078:\n\tv169 = System.Linq.Enumerable::Select(vibrationPattern, v138);\n\tv127 = System.Linq.Enumerable::ToArray(v169);\nL_FFFFFFFF:\n\tv124 = v127;\n\tgoto L_007F;\nL_FFFFFFFF:\n\tv124 = 0;\nL_0033:\n\tthis.Id = v65;\n\tthis.Name = name;\n\tthis.Description = description;\nL_0058:\n\tv138 = v113.<>9__13_0;\n\tv115 = v113.<>9__13_0 == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_0078;\nL_0067:\n\tv177 = new System.Func`2<System.Int64, System.Int32>();\n\tSystem.Func`2<System.Int64, System.Int32>::.ctor(v177, v172.<>9, Il2CppMethodInfo);\n\tv183.<>9__13_0 = v177;\nL_FFFFFFFF:\n\tv138 = v177;\nL_007F:\n\tthis.VibrationPattern = v124;\n\treturn;\n")]
		public GameNotificationChannel(string id, string name, string description, NotificationStyle style, bool showsBadge = true, bool showLights = false, bool vibrates = true, bool highPriority = false, PrivacyMode privacy = PrivacyMode.Public, long[] vibrationPattern = null)
		{
			string id2 = default(string);
			Id = id2;
			Name = name;
			Description = description;
			ShowsBadge = showsBadge;
			ShowLights = showLights;
			Vibrates = vibrates;
			HighPriority = highPriority;
			Style = style;
			Privacy = privacy;
			int[] vibrationPattern2;
			if (vibrationPattern == null)
			{
				vibrationPattern2 = null;
			}
			else
			{
				Func<long, int> selector = _003C_003Ec._003C_003E9__13_0;
				if (_003C_003Ec._003C_003E9__13_0 == null)
				{
					selector = (_003C_003Ec._003C_003E9__13_0 = delegate(long v)
					{
						//IL_0005: Expected I4, but got I8
						return (int)v;
					});
				}
				IEnumerable<int> source = vibrationPattern.Select(selector);
				int[] array = source.ToArray();
				vibrationPattern2 = array;
			}
			VibrationPattern = vibrationPattern2;
		}
	}
}
