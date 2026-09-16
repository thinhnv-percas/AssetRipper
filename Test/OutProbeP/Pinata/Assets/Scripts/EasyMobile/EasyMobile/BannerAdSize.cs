using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000023")]
	public class BannerAdSize
	{
		[CompilerGenerated]
		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x10")]
		private bool _003CIsSmartBanner_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0x14")]
		private int _003CWidth_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0x18")]
		private int _003CHeight_003Ek__BackingField;

		[Token(Token = "0x400012B")]
		public static readonly BannerAdSize Banner;

		[Token(Token = "0x400012C")]
		public static readonly BannerAdSize MediumRectangle;

		[Token(Token = "0x400012D")]
		public static readonly BannerAdSize IABBanner;

		[Token(Token = "0x400012E")]
		public static readonly BannerAdSize Leaderboard;

		[Token(Token = "0x400012F")]
		public static readonly BannerAdSize SmartBanner;

		[Token(Token = "0x17000039")]
		public bool IsSmartBanner
		{
			[CompilerGenerated]
			[Token(Token = "0x6000105")]
			[Address(RVA = "0xA4EBFC", Offset = "0xA4EBFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsSmartBanner>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsSmartBanner;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000106")]
			[Address(RVA = "0xA4EC04", Offset = "0xA4EC04", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsSmartBanner>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CIsSmartBanner_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700003A")]
		public int Width
		{
			[CompilerGenerated]
			[Token(Token = "0x6000107")]
			[Address(RVA = "0xA4EC10", Offset = "0xA4EC10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Width>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Width;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000108")]
			[Address(RVA = "0xA4EC18", Offset = "0xA4EC18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Width>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CWidth_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700003B")]
		public int Height
		{
			[CompilerGenerated]
			[Token(Token = "0x6000109")]
			[Address(RVA = "0xA4EC20", Offset = "0xA4EC20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Height>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Height;
			}
			[CompilerGenerated]
			[Token(Token = "0x600010A")]
			[Address(RVA = "0xA4EC28", Offset = "0xA4EC28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Height>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CHeight_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x600010B")]
		[Address(RVA = "0xA4EC30", Offset = "0xA4EC30", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<IsSmartBanner>k__BackingField = 0;\n\tthis.<Width>k__BackingField = width;\n\tthis.<Height>k__BackingField = height;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BannerAdSize(int width, int height)
		{
			IsSmartBanner = false;
			Width = width;
			Height = height;
		}

		[Token(Token = "0x600010C")]
		[Address(RVA = "0xA4EC6C", Offset = "0xA4EC6C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<IsSmartBanner>k__BackingField = isSmartBanner;\n\tthis.<Width>k__BackingField = 0;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private BannerAdSize(bool isSmartBanner)
		{
			IsSmartBanner = isSmartBanner;
			Width = 0;
			Height = 0;
		}

		[Token(Token = "0x600010D")]
		[Address(RVA = "0xA4ECA0", Offset = "0xA4ECA0", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EEF0F0]);\n\tv23 = *([v22 @ X8_v21]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, obj, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F49]) = v41;\nL_0017:\n\tv44 = EasyMobile.BannerAdSize;\n\tv45 = obj == 0;\n\tif (v45) goto L_003D;\n\tgoto L_FFFFFFFF;\n\tgoto L_003D;\n\tv60 = v60_asT == 0;\n\tif (v60) goto L_FFFFFFFF;\n\tgoto L_003D;\nL_003D:\n\tv99 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.BannerAdSize>)+12F]) & 2;\n\tv100 = v99 == 0;\n\tif (v100) goto L_0043;\n\tv105 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.BannerAdSize>)+E0]) == 0;\n\tif (v105) goto L_006E;\nL_0043:\n\tv108 = v92 == 0;\n\tif (v108) goto L_FFFFFFFF;\nL_004A:\n\tv119 = System.Object::Equals(v92, 0);\n\tv121 = v119 == 0;\n\tif (v121) goto L_0056;\n\tgoto L_0091;\nL_0056:\n\tv160 = this.<IsSmartBanner>k__BackingField == 0;\n\tv165 = ~v160;\n\tv171 = *([v92 @ X20_v2 (System.Object)+10]) == 0;\n\tv144 = this.<IsSmartBanner>k__BackingField | *([v92 @ X20_v2 (System.Object)+10]);\n\tv176 = ~v171;\n\tv149 = v144 == 0;\n\tif (v149) goto L_007D;\n\treturnVal1 = v165 & v176;\n\tgoto L_0091;\nL_006E:\n\tv153 = v92 == 0;\n\tv112 = ~v153;\n\tif (v112) goto L_004A;\n\tgoto L_FFFFFFFF;\nL_007D:\n\tv124 = this.<Width>k__BackingField != *([v92 @ X20_v2 (System.Object)+14]);\n\tif (v124) goto L_FFFFFFFF;\n\tv194 = this.<Height>k__BackingField - *([v92 @ X20_v2 (System.Object)+18]);\n\tv190 = v194 == 0;\nL_0091:\n\treturn returnVal1;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			//IL_01eb: Expected I, but got O
			//IL_01c1: Expected O, but got I
			IntPtr intPtr = (IntPtr)typeof(BannerAdSize);
			bool flag = obj == null;
			object obj2 = obj;
			if (!flag)
			{
				BannerAdSize bannerAdSize = obj as BannerAdSize;
				obj2 = (((object)bannerAdSize == null) ? null : obj);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v2 (Il2CppClass<EasyMobile.BannerAdSize>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v2 (Il2CppClass<EasyMobile.BannerAdSize>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					if (obj2 != null)
					{
						goto IL_0097;
					}
					goto IL_00c2;
				}
			}
			if (obj2 != null)
			{
				goto IL_0097;
			}
			goto IL_00c2;
			IL_0097:
			if (!obj2.Equals(null))
			{
				bool flag2 = !IsSmartBanner;
				bool flag3 = !flag2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X20_v2 (System.Object)+10]");
				bool flag4 = (IntPtr)0 == (IntPtr)0;
				bool isSmartBanner = IsSmartBanner;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X20_v2 (System.Object)+10]");
				int num = (int)((long)(isSmartBanner ? 1 : 0) | 0L);
				bool flag5 = !flag4;
				if (num != 0)
				{
					return flag3 && flag5;
				}
				int width = Width;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X20_v2 (System.Object)+14]");
				if ((IntPtr)width == (IntPtr)0)
				{
					int height = Height;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X20_v2 (System.Object)+18]");
					object obj3 = (long)height - 0L;
					return obj3 == null;
				}
			}
			goto IL_00c2;
			IL_00c2:
			return false;
		}

		[Token(Token = "0x600010E")]
		[Address(RVA = "0xA432D4", Offset = "0xA432D4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = a == 0;\n\tif (v0) goto L_000A;\n\tv2 = a->klass;\n\tv3 = a->klass->vtable[0];\n\tv4 = a->klass->vtable[0];\n\t// 5 IndirectJump v3 @ X3_v1, a @ X0 (EasyMobile.BannerAdSize), a @ X0 (EasyMobile.BannerAdSize), b @ X1 (EasyMobile.BannerAdSize), v4 @ X2_v1, v3 @ X3_v1, v6 @ X4, v7 @ X5, v8 @ X6, v9 @ X7, v10 @ V0, v11 @ V1, v12 @ V2, v13 @ V3, v14 @ V4, v15 @ V5, v16 @ V6, v17 @ V7\nL_000A:\n\tv22 = b == 0;\n\treturn v22;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator ==(BannerAdSize a, BannerAdSize b)
		{
			//IL_0025: Expected I, but got O
			//IL_0035: Expected O, but got I
			//IL_0045: Expected O, but got I
			if ((object)a != null)
			{
				IntPtr intPtr = (IntPtr)a;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.BannerAdSize>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.BannerAdSize>)+138]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ X3_v1 (should have been resolved before IL gen)");
			}
			return (object)b == null;
		}

		[Token(Token = "0x600010F")]
		[Address(RVA = "0xA4EDB4", Offset = "0xA4EDB4", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EB1548]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, b, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F4A]) = v41;\nL_0017:\n\tv44 = EasyMobile.BannerAdSize;\n\tv46 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.BannerAdSize>)+12F]) & 2;\n\tv47 = v46 == 0;\n\tif (v47) goto L_001F;\n\tv49 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.BannerAdSize>)+E0]) == 0;\n\tif (v49) goto L_0029;\nL_001F:\n\tv52 = a == 0;\n\tif (v52) goto L_0030;\nL_0026:\n\tv98 = EasyMobile.BannerAdSize::Equals(a, b);\n\tgoto L_003A;\nL_0029:\n\tv77 = a == 0;\n\tv56 = ~v77;\n\tif (v56) goto L_0026;\nL_0030:\n\tv71 = b == 0;\nL_003A:\n\tv105 = ~v98;\n\treturn v105;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator !=(BannerAdSize a, BannerAdSize b)
		{
			//IL_00af: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(BannerAdSize);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v2 (Il2CppClass<EasyMobile.BannerAdSize>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v2 (Il2CppClass<EasyMobile.BannerAdSize>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					if ((object)a != null)
					{
						goto IL_0047;
					}
					goto IL_0085;
				}
			}
			if ((object)a != null)
			{
				goto IL_0047;
			}
			goto IL_0085;
			IL_0047:
			bool flag = a.Equals(b);
			goto IL_00e2;
			IL_00e2:
			return !flag;
			IL_0085:
			bool flag2 = (object)b == null;
			flag = flag2;
			goto IL_00e2;
		}

		[Token(Token = "0x6000110")]
		[Address(RVA = "0xA4EE50", Offset = "0xA4EE50", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.<IsSmartBanner>k__BackingField;\n\tv18 = 0xE8F13C(&v14 @ X8_v1 (System.Boolean), 0, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv33 = this.<Width>k__BackingField;\n\tv38 = 0xDC3558(&v33 @ X8_v2 (System.Int32), 0, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv39 = this.<Height>k__BackingField;\n\tv44 = 0xDC3558(&v39 @ X8_v3 (System.Int32), 0, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv46 = v18 * 0x17;\n\tv47 = v38 + v46;\n\tv52 = v47 * 0x17;\n\tv14 = v44 + v52;\n\treturnVal1 = v14 + 0x327F7;\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			//IL_005f: Expected O, but got I
			//IL_006e: Expected O, but got I
			//IL_007d: Expected O, but got I
			bool isSmartBanner = IsSmartBanner;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E8F13C (inside System.BitConverter::.cctor +0x54)");
			int width = Width;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3558 (inside System.InvalidCastException::.ctor +0x280)");
			int height = Height;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3558 (inside System.InvalidCastException::.ctor +0x280)");
			object obj2 = default(object);
			object obj = (long)(IntPtr)obj2 * 23L;
			object obj4 = default(object);
			object obj3 = (long)(IntPtr)obj4 + (long)(IntPtr)obj;
			object obj5 = (long)(IntPtr)obj3 * 23L;
			object obj6 = default(object);
			isSmartBanner = (byte)((ulong)(long)(IntPtr)obj6 + (ulong)(long)(IntPtr)obj5) != 0;
			return (isSmartBanner ? 1 : 0) + 206839;
		}

		[Token(Token = "0x6000111")]
		[Address(RVA = "0xA4EED0", Offset = "0xA4EED0", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1ED2E10]);\n\tv17 = *([v16 @ X8_v20]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021F4B]) = v37;\nL_0015:\n\tv41 = new EasyMobile.BannerAdSize();\n\tSystem.Object::.ctor(v41);\n\tv41.<IsSmartBanner>k__BackingField = 0;\n\tv41.<Width>k__BackingField = 0x3200000140;\n\tv47.Banner = v41;\n\tv49 = new EasyMobile.BannerAdSize();\n\tSystem.Object::.ctor(v49);\n\tv49.<IsSmartBanner>k__BackingField = 0;\n\tv49.<Width>k__BackingField = 0xFA0000012C;\n\tv55.MediumRectangle = v49;\n\tv56 = new EasyMobile.BannerAdSize();\n\tSystem.Object::.ctor(v56);\n\tv56.<IsSmartBanner>k__BackingField = 0;\n\tv56.<Width>k__BackingField = 0x3C000001FC;\n\tv62.IABBanner = v56;\n\tv63 = new EasyMobile.BannerAdSize();\n\tSystem.Object::.ctor(v63);\n\tv63.<IsSmartBanner>k__BackingField = 0;\n\tv63.<Width>k__BackingField = 0x5A000002D8;\n\tv69.Leaderboard = v63;\n\tv70 = new EasyMobile.BannerAdSize();\n\tSystem.Object::.ctor(v70);\n\tv70.<IsSmartBanner>k__BackingField = 1;\n\tv70.<Width>k__BackingField = 0;\n\tv75.SmartBanner = v70;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static BannerAdSize()
		{
			BannerAdSize bannerAdSize = null;
			bannerAdSize.IsSmartBanner = false;
			bannerAdSize.Width = 320;
			bannerAdSize.Height = 50;
			Banner = bannerAdSize;
			BannerAdSize bannerAdSize2 = null;
			bannerAdSize2.IsSmartBanner = false;
			bannerAdSize2.Width = 300;
			bannerAdSize2.Height = 250;
			MediumRectangle = bannerAdSize2;
			BannerAdSize bannerAdSize3 = null;
			bannerAdSize3.IsSmartBanner = false;
			bannerAdSize3.Width = 508;
			bannerAdSize3.Height = 60;
			IABBanner = bannerAdSize3;
			BannerAdSize bannerAdSize4 = null;
			bannerAdSize4.IsSmartBanner = false;
			bannerAdSize4.Width = 728;
			bannerAdSize4.Height = 90;
			Leaderboard = bannerAdSize4;
			BannerAdSize bannerAdSize5 = null;
			bannerAdSize5.IsSmartBanner = true;
			bannerAdSize5.Width = 0;
			bannerAdSize5.Height = 0;
			SmartBanner = bannerAdSize5;
		}
	}
}
