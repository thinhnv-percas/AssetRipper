using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[StructLayout((LayoutKind)0, Size = 48)]
	[Token(Token = "0x2000052")]
	public struct SavedGameInfoUpdate
	{
		[StructLayout((LayoutKind)0, Size = 48)]
		[Token(Token = "0x2000124")]
		public struct Builder
		{
			[Token(Token = "0x40004EB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			internal bool _descriptionUpdated;

			[Token(Token = "0x40004EC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			internal string _newDescription;

			[Token(Token = "0x40004ED")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			internal bool _coverImageUpdated;

			[Token(Token = "0x40004EE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			internal byte[] _newPngCoverImage;

			[Token(Token = "0x40004EF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			internal bool _playedTimeUpdated;

			[Token(Token = "0x40004F0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			internal TimeSpan _newPlayedTime;

			[Token(Token = "0x6000978")]
			[Address(RVA = "0x854E18", Offset = "0x854E18", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._coverImageUpdated = 1;\n\tthis._newPngCoverImage = description;\n\treturnBuffer._playedTimeUpdated = *([this @ X0 (EasyMobile.SavedGameInfoUpdate+Builder)+30]);\n\treturnBuffer._coverImageUpdated = this._playedTimeUpdated;\n\treturnBuffer._descriptionUpdated = this._coverImageUpdated;\n\treturn this;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe Builder WithUpdatedDescription(string description)
			{
				//IL_0025: Expected native int or pointer, but got O
				//IL_0034: Expected native int or pointer, but got O
				//IL_0043: Expected native int or pointer, but got O
				//IL_004a: Expected O, but got Ref
				_coverImageUpdated = true;
				_newPngCoverImage = (byte[])(object)description;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EasyMobile.SavedGameInfoUpdate+Builder)+30]");
				Builder builder = default(Builder);
				((Builder*)(IntPtr)builder)->_playedTimeUpdated = false;
				((Builder*)(IntPtr)builder)->_coverImageUpdated = _playedTimeUpdated;
				((Builder*)(IntPtr)builder)->_descriptionUpdated = _coverImageUpdated;
				return (Builder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			}

			[Token(Token = "0x6000979")]
			[Address(RVA = "0x854E40", Offset = "0x854E40", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._playedTimeUpdated = 1;\n\tthis._newPlayedTime = newPngCoverImage;\n\treturnBuffer._playedTimeUpdated = *([this @ X0 (EasyMobile.SavedGameInfoUpdate+Builder)+30]);\n\treturnBuffer._descriptionUpdated = this._coverImageUpdated;\n\treturnBuffer._coverImageUpdated = this._playedTimeUpdated;\n\treturn this;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe Builder WithUpdatedPngCoverImage(byte[] newPngCoverImage)
			{
				//IL_0025: Expected native int or pointer, but got O
				//IL_0034: Expected native int or pointer, but got O
				//IL_0043: Expected native int or pointer, but got O
				//IL_004a: Expected O, but got Ref
				_playedTimeUpdated = true;
				_newPlayedTime = (TimeSpan)newPngCoverImage;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EasyMobile.SavedGameInfoUpdate+Builder)+30]");
				Builder builder = default(Builder);
				((Builder*)(IntPtr)builder)->_playedTimeUpdated = false;
				((Builder*)(IntPtr)builder)->_descriptionUpdated = _coverImageUpdated;
				((Builder*)(IntPtr)builder)->_coverImageUpdated = _playedTimeUpdated;
				return (Builder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			}

			[Token(Token = "0x600097A")]
			[Address(RVA = "0x854E68", Offset = "0x854E68", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (EasyMobile.SavedGameInfoUpdate+Builder)+30]) = 1;\n\t*([this @ X0 (EasyMobile.SavedGameInfoUpdate+Builder)+38]) = newPlayedTime;\n\treturnBuffer._coverImageUpdated = this._playedTimeUpdated;\n\treturnBuffer._descriptionUpdated = this._coverImageUpdated;\n\treturnBuffer._playedTimeUpdated = *([this @ X0 (EasyMobile.SavedGameInfoUpdate+Builder)+30]);\n\treturn this;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe Builder WithUpdatedPlayedTime(TimeSpan newPlayedTime)
			{
				//IL_0015: Expected native int or pointer, but got O
				//IL_0024: Expected native int or pointer, but got O
				//IL_0039: Expected native int or pointer, but got O
				//IL_0040: Expected O, but got Ref
				_ = 1;
				Builder builder = default(Builder);
				((Builder*)(IntPtr)builder)->_coverImageUpdated = _playedTimeUpdated;
				((Builder*)(IntPtr)builder)->_descriptionUpdated = _coverImageUpdated;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EasyMobile.SavedGameInfoUpdate+Builder)+30]");
				((Builder*)(IntPtr)builder)->_playedTimeUpdated = false;
				return (Builder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			}

			[Token(Token = "0x600097B")]
			[Address(RVA = "0x854E90", Offset = "0x854E90", Length = "0x1C8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this._coverImageUpdated == 0;\n\tv17 = ~v11;\n\tv23 = this._playedTimeUpdated == 0;\n\treturnBuffer._descriptionUpdated = 0;\n\treturnBuffer._coverImageUpdated = 0;\n\treturnBuffer._descriptionUpdated = v17;\n\tv29 = ~v23;\n\tv35 = *([this @ X0 (EasyMobile.SavedGameInfoUpdate+Builder)+30]) == 0;\n\treturnBuffer._coverImageUpdated = v29;\n\tv40 = ~v35;\n\treturnBuffer._newDescription = this._newPngCoverImage;\n\treturnBuffer._newPngCoverImage = this._newPlayedTime;\n\treturnBuffer._playedTimeUpdated = 0;\n\treturnBuffer._newPlayedTime = *([this @ X0 (EasyMobile.SavedGameInfoUpdate+Builder)+38]);\n\treturnBuffer._playedTimeUpdated = v40;\n\treturn this;\n\tX8 = *([X0+18]);\n\tC = X1 < X8;\n\tC = ~C;\n\tTEMP1 = X1 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ X8;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0041;\n\tTEMPSHIFT = X1 << 3;\n\tX8 = X0 + TEMPSHIFT;\n\tX0 = *([X8+20]);\n\treturn X0;\nL_0041:\n\t// 65 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 73 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX8 = *([X0]);\n\tX19 = X1;\n\t*([X19]) = X8;\n\tX0 = *([X0+8]);\n\tif (TEMP) goto L_005F;\n\tX8 = *([X0]);\n\tX8 = *([X8+12F]);\n\tTEMP = X8 & 8;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0065;\n\tX1 = *([1EEEF48]);\n\tX0 = 0x8D8314(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+8]) = X0;\n\tgoto L_0060;\nL_005F:\n\t*([X19+8]) = 0;\nL_0060:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 99 ShiftStack 32\n\treturn X0;\nL_0065:\n\tX1 = 0x1EEE000;\n\tX1 = *([1EEEF48]);\n\tX0 = 0x8D831C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+8]) = X0;\n\tX8 = *([X0]);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX1 = *([X8+8]);\n\tX19 = stack[0];\n\t// 110 ShiftStack 32\n\t// 111 IndirectJump X1, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\t// 112 ShiftStack -48\n\tstack[0] = X21;\n\tstack[10] = X20;\n\tstack[18] = X19;\n\tstack[20] = X29;\n\tstack[28] = X30;\n\tX29 = &stack[20];\n\tX8 = *([20257A5]);\n\tX20 = X1;\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0085;\n\tX8 = *([1EC95D0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([20257A5]) = X8;\nL_0085:\n\tX8 = *([X19]);\n\t*([X20]) = X8;\n\tX0 = *([X19+8]);\n\tif (TEMP) goto L_009F;\n\tX8 = *([1EECE88]);\n\tX1 = *([X8]);\n\tX0 = 0x8D8318(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20+8]) = X0;\n\tX8 = *([X0]);\n\tX8 = *([X8+12F]);\n\tTEMP = X8 & 8;\n\tif (TEMP) goto L_00A0;\n\tX2 = *([X19+8]);\n\tX1 = *([1EEEF48]);\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 156 ShiftStack 48\n\tX0 = 0x8D83B8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\nL_009F:\n\t*([X20+8]) = 0;\nL_00A0:\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 165 ShiftStack 48\n\treturn X0;\n\t// 167 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = *([X19+8]);\n\tif (TEMP) goto L_00B4;\n\tX8 = *([X0]);\n\tX8 = *([X8+10]);\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+8]) = 0;\nL_00B4:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 183 ShiftStack 32\n\treturn X0;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe SavedGameInfoUpdate Build()
			{
				//IL_0036: Expected native int or pointer, but got O
				//IL_0044: Expected native int or pointer, but got O
				//IL_0051: Expected native int or pointer, but got O
				//IL_0080: Expected native int or pointer, but got O
				//IL_009a: Expected native int or pointer, but got O
				//IL_00a9: Expected native int or pointer, but got O
				//IL_00b7: Expected native int or pointer, but got O
				//IL_00d1: Expected O, but got I
				//IL_00cc: Expected native int or pointer, but got O
				//IL_00d9: Expected native int or pointer, but got O
				//IL_00e0: Expected O, but got Ref
				bool flag = !_coverImageUpdated;
				bool descriptionUpdated = !flag;
				bool flag2 = !_playedTimeUpdated;
				SavedGameInfoUpdate savedGameInfoUpdate = default(SavedGameInfoUpdate);
				((SavedGameInfoUpdate*)(IntPtr)savedGameInfoUpdate)->_descriptionUpdated = false;
				((SavedGameInfoUpdate*)(IntPtr)savedGameInfoUpdate)->_coverImageUpdated = false;
				((SavedGameInfoUpdate*)(IntPtr)savedGameInfoUpdate)->_descriptionUpdated = descriptionUpdated;
				bool coverImageUpdated = !flag2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EasyMobile.SavedGameInfoUpdate+Builder)+30]");
				bool flag3 = (IntPtr)0 == (IntPtr)0;
				((SavedGameInfoUpdate*)(IntPtr)savedGameInfoUpdate)->_coverImageUpdated = coverImageUpdated;
				bool playedTimeUpdated = !flag3;
				System.Runtime.CompilerServices.Unsafe.Write(&((SavedGameInfoUpdate*)(IntPtr)savedGameInfoUpdate)->_newDescription, _newPngCoverImage);
				System.Runtime.CompilerServices.Unsafe.Write(&((SavedGameInfoUpdate*)(IntPtr)savedGameInfoUpdate)->_newPngCoverImage, (byte[])_newPlayedTime);
				((SavedGameInfoUpdate*)(IntPtr)savedGameInfoUpdate)->_playedTimeUpdated = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EasyMobile.SavedGameInfoUpdate+Builder)+38]");
				((SavedGameInfoUpdate*)(IntPtr)savedGameInfoUpdate)->_newPlayedTime = (TimeSpan)0;
				((SavedGameInfoUpdate*)(IntPtr)savedGameInfoUpdate)->_playedTimeUpdated = playedTimeUpdated;
				return (SavedGameInfoUpdate)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			}
		}

		[Token(Token = "0x40001F0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private readonly bool _descriptionUpdated;

		[Token(Token = "0x40001F1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		private readonly string _newDescription;

		[Token(Token = "0x40001F2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		private readonly bool _coverImageUpdated;

		[Token(Token = "0x40001F3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		private readonly byte[] _newPngCoverImage;

		[Token(Token = "0x40001F4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		private readonly bool _playedTimeUpdated;

		[Token(Token = "0x40001F5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		private readonly TimeSpan _newPlayedTime;

		[Token(Token = "0x1700013B")]
		public bool IsDescriptionUpdated
		{
			[Token(Token = "0x6000426")]
			[Address(RVA = "0x854CAC", Offset = "0x854CAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._coverImageUpdated;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsCoverImageUpdated;
			}
		}

		[Token(Token = "0x1700013C")]
		public string UpdatedDescription
		{
			[Token(Token = "0x6000427")]
			[Address(RVA = "0x854CB4", Offset = "0x854CB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._newPngCoverImage;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return (string)(object)UpdatedPngCoverImage;
			}
		}

		[Token(Token = "0x1700013D")]
		public bool IsCoverImageUpdated
		{
			[Token(Token = "0x6000428")]
			[Address(RVA = "0x854CBC", Offset = "0x854CBC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._playedTimeUpdated;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsPlayedTimeUpdated;
			}
		}

		[Token(Token = "0x1700013E")]
		public byte[] UpdatedPngCoverImage
		{
			[Token(Token = "0x6000429")]
			[Address(RVA = "0x854CC4", Offset = "0x854CC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._newPlayedTime;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return (byte[])_newPlayedTime;
			}
		}

		[Token(Token = "0x1700013F")]
		public bool IsPlayedTimeUpdated
		{
			[Token(Token = "0x600042A")]
			[Address(RVA = "0x854CCC", Offset = "0x854CCC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (EasyMobile.SavedGameInfoUpdate)+30]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EasyMobile.SavedGameInfoUpdate)+30]");
				return false;
			}
		}

		[Token(Token = "0x17000140")]
		public TimeSpan UpdatedPlayedTime
		{
			[Token(Token = "0x600042B")]
			[Address(RVA = "0x854CD4", Offset = "0x854CD4", Length = "0x144")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (EasyMobile.SavedGameInfoUpdate)+38]);\n\t// 2 ShiftStack -32\n\tstack[0] = X20;\n\tstack[8] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX8 = *([X19]);\n\tX20 = X1;\n\t*([X20]) = X8;\n\tX0 = *([X19+8]);\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20+8]) = X0;\n\tX8 = *([X19+10]);\n\tX0 = 0 | 0x10;\n\t*([X20+10]) = X8;\n\tX1 = *([X19+18]);\n\tX0 = 0x8D82E8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20+18]) = X0;\n\tX8 = *([X19+20]);\n\t*([X20+20]) = X8;\n\tX8 = *([X19+28]);\n\t*([X20+28]) = X8;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 29 ShiftStack 32\n\treturn X0;\n\t// 31 ShiftStack -48\n\tstack[0] = X21;\n\tstack[10] = X20;\n\tstack[18] = X19;\n\tstack[20] = X29;\n\tstack[28] = X30;\n\tX29 = &stack[20];\n\tX8 = *([20256C0]);\n\tX19 = X1;\n\tX20 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0034;\n\tX8 = *([1EB3AD0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([20256C0]) = X8;\nL_0034:\n\tX8 = *([X20]);\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\t*([X19]) = X8;\n\tX0 = *([X20+8]);\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+8]) = X0;\n\tX8 = *([X20+10]);\n\tX9 = *([1F0FFA0]);\n\tX0 = 0 | 0x10;\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\t*([X19+10]) = X8;\n\tX1 = *([X9]);\n\tX2 = *([X20+18]);\n\tX0 = 0x8D82EC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+18]) = X0;\n\tX8 = *([X20+20]);\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\t*([X19+20]) = X8;\n\tX8 = *([X20+28]);\n\t*([X19+28]) = X8;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 108 ShiftStack 48\n\treturn X0;\n\t// 110 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = *([X19+8]);\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+18]);\n\t*([X19+8]) = 0;\n\tX0 = 0x8D82F0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+18]) = 0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 125 ShiftStack 32\n\treturn X0;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EasyMobile.SavedGameInfoUpdate)+38]");
				return (TimeSpan)0;
			}
		}

		[Token(Token = "0x6000425")]
		[Address(RVA = "0x854C60", Offset = "0x854C60", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = builder._descriptionUpdated == 0;\n\tv16 = ~v11;\n\tv22 = builder._coverImageUpdated == 0;\n\tthis._coverImageUpdated = v16;\n\tv28 = ~v22;\n\tv34 = builder._playedTimeUpdated == 0;\n\tthis._playedTimeUpdated = v28;\n\tv39 = ~v34;\n\tthis._newPngCoverImage = builder._newDescription;\n\tthis._newPlayedTime = builder._newPngCoverImage;\n\t*([this @ X0 (EasyMobile.SavedGameInfoUpdate)+30]) = v39;\n\t*([this @ X0 (EasyMobile.SavedGameInfoUpdate)+38]) = builder._newPlayedTime;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private SavedGameInfoUpdate(Builder builder)
		{
			bool flag = !builder._descriptionUpdated;
			bool coverImageUpdated = !flag;
			bool flag2 = !builder._coverImageUpdated;
			_coverImageUpdated = coverImageUpdated;
			bool playedTimeUpdated = !flag2;
			bool flag3 = !builder._playedTimeUpdated;
			_playedTimeUpdated = playedTimeUpdated;
			bool flag4 = !flag3;
			_newPngCoverImage = (byte[])(object)builder._newDescription;
			_newPlayedTime = (TimeSpan)builder._newPngCoverImage;
			_ = builder._newPlayedTime;
		}
	}
}
