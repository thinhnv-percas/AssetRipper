using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x200003E")]
	public class AdSize
	{
		[Token(Token = "0x200003F")]
		public enum Type
		{
			[Token(Token = "0x40000EF")]
			Standard = 0,
			[Token(Token = "0x40000F0")]
			SmartBanner = 1,
			[Token(Token = "0x40000F1")]
			AnchoredAdaptive = 2
		}

		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x10")]
		internal Type type;

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x14")]
		internal Orientation orientation;

		[Token(Token = "0x40000E6")]
		[FieldOffset(Offset = "0x18")]
		private int width;

		[Token(Token = "0x40000E7")]
		[FieldOffset(Offset = "0x1C")]
		internal int height;

		[Token(Token = "0x40000E8")]
		public static readonly AdSize Banner;

		[Token(Token = "0x40000E9")]
		public static readonly AdSize MediumRectangle;

		[Token(Token = "0x40000EA")]
		public static readonly AdSize IABBanner;

		[Token(Token = "0x40000EB")]
		public static readonly AdSize Leaderboard;

		[Token(Token = "0x40000EC")]
		public static readonly AdSize SmartBanner;

		[Token(Token = "0x40000ED")]
		public static readonly int FullWidth;

		[Token(Token = "0x17000026")]
		public int Width
		{
			[Token(Token = "0x60002DD")]
			[Address(RVA = "0x1357DE8", Offset = "0x1357DE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.width;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Width;
			}
		}

		[Token(Token = "0x17000027")]
		public int Height
		{
			[Token(Token = "0x60002DE")]
			[Address(RVA = "0x1357DF0", Offset = "0x1357DF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.height;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Height;
			}
		}

		[Token(Token = "0x17000028")]
		public Type AdType
		{
			[Token(Token = "0x60002DF")]
			[Address(RVA = "0x1357DF8", Offset = "0x1357DF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.type;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdType;
			}
		}

		[Token(Token = "0x17000029")]
		internal Orientation Orientation
		{
			[Token(Token = "0x60002E0")]
			[Address(RVA = "0x1357E00", Offset = "0x1357E00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.orientation;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return orientation;
			}
		}

		[Token(Token = "0x60002D7")]
		[Address(RVA = "0x13405D4", Offset = "0x13405D4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.width = width;\n\tthis.height = height;\n\tthis.type = 0;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdSize(int width, int height)
		{
			this.width = width;
			this.height = height;
			type = default(Type);
		}

		[Token(Token = "0x60002D8")]
		[Address(RVA = "0x1357C34", Offset = "0x1357C34", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.width = width;\n\tthis.height = height;\n\tthis.type = type;\n\tthis.orientation = 0;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal AdSize(int width, int height, Type type)
		{
			this.width = width;
			this.height = height;
			this.type = type;
			orientation = default(Orientation);
		}

		[Token(Token = "0x60002D9")]
		[Address(RVA = "0x1357C70", Offset = "0x1357C70", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = GoogleMobileAds.Api.AdSize;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, orientation, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A368F1]) = v40;\nL_0016:\n\tv42 = new GoogleMobileAds.Api.AdSize();\n\tSystem.Object::.ctor(v42);\n\tv42.width = width;\n\tv42.height = 0;\n\tv42.type = 2;\n\tv42.orientation = orientation;\n\treturn v42;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static AdSize CreateAnchoredAdaptiveAdSize(int width, Orientation orientation)
		{
			AdSize adSize = null;
			adSize.width = width;
			adSize.height = 0;
			adSize.type = Type.AnchoredAdaptive;
			adSize.orientation = orientation;
			return adSize;
		}

		[Token(Token = "0x60002DA")]
		[Address(RVA = "0x1357CE0", Offset = "0x1357CE0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = GoogleMobileAds.Api.AdSize;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A368F2]) = v37;\nL_0017:\n\tgoto L_0020;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\treturnVal1 = GoogleMobileAds.Api.AdSize::CreateAnchoredAdaptiveAdSize(width, 1);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AdSize GetLandscapeAnchoredAdaptiveBannerAdSizeWithWidth(int width)
		{
			return CreateAnchoredAdaptiveAdSize(width, Orientation.Landscape);
		}

		[Token(Token = "0x60002DB")]
		[Address(RVA = "0x1357D38", Offset = "0x1357D38", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = GoogleMobileAds.Api.AdSize;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A368F3]) = v37;\nL_0017:\n\tgoto L_0020;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\treturnVal1 = GoogleMobileAds.Api.AdSize::CreateAnchoredAdaptiveAdSize(width, 2);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AdSize GetPortraitAnchoredAdaptiveBannerAdSizeWithWidth(int width)
		{
			return CreateAnchoredAdaptiveAdSize(width, Orientation.Portrait);
		}

		[Token(Token = "0x60002DC")]
		[Address(RVA = "0x1357D90", Offset = "0x1357D90", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = GoogleMobileAds.Api.AdSize;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A368F4]) = v37;\nL_0017:\n\tgoto L_0020;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\treturnVal1 = GoogleMobileAds.Api.AdSize::CreateAnchoredAdaptiveAdSize(width, 0);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AdSize GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(int width)
		{
			return CreateAnchoredAdaptiveAdSize(width, default(Orientation));
		}

		[Token(Token = "0x60002E1")]
		[Address(RVA = "0x1357E08", Offset = "0x1357E08", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = GoogleMobileAds.Api.AdSize;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, obj, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv42 = System.Type;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, obj, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 1;\n\t*([1A368F5]) = v39;\nL_0016:\n\tv40 = obj == 0;\n\tif (v40) goto L_FFFFFFFF;\n\tv47 = System.Object::GetType(this);\n\tv126 = System.Object::GetType(obj);\n\tgoto L_002C;\n\tv199 = v117;\n\tv200 = \"il2cpp_codegen_runtime_class_init\"(v199, v125, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002C:\n\tv113 = System.Type::op_Inequality(v47, v126);\n\tv204 = v113 == 0;\n\tv115 = ~v204;\n\tif (v115) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv230 = v230_asT == 0;\n\tif (v230) goto L_008E;\n\tv53 = this.width != *([obj @ X1 (System.Object)+18]);\n\tif (v53) goto L_FFFFFFFF;\n\tv54 = this.height != *([obj @ X1 (System.Object)+1C]);\n\tif (v54) goto L_FFFFFFFF;\n\tv55 = this.type != *([obj @ X1 (System.Object)+10]);\n\tif (v55) goto L_FFFFFFFF;\n\tv142 = this.orientation - *([obj @ X1 (System.Object)+14]);\n\tv138 = v142 == 0;\n\tgoto L_008C;\nL_008C:\n\treturn returnVal1;\nL_008E:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			//IL_0158: Expected I4, but got O
			//IL_0120: Expected O, but got I
			if (obj != null)
			{
				System.Type type = GetType();
				System.Type type2 = obj.GetType();
				if (!(type != type2))
				{
					AdSize adSize = obj as AdSize;
					if ((object)adSize == null)
					{
						InvalidCastException ex = new InvalidCastException();
						return (byte)(int)ex != 0;
					}
					int num = Width;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+18]");
					if ((nint)num == 0)
					{
						int num2 = Height;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+1C]");
						if ((nint)num2 == 0)
						{
							Type adType = AdType;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+10]");
							if ((nint)adType == (nint)0)
							{
								Orientation num3 = orientation;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [obj @ X1 (System.Object)+14]");
								object obj2 = (nint)num3 - (nint)0;
								return obj2 == null;
							}
						}
					}
				}
			}
			return false;
		}

		[Token(Token = "0x60002E2")]
		[Address(RVA = "0x133F77C", Offset = "0x133F77C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = a == 0;\n\tif (v0) goto L_000A;\n\tv2 = a->klass;\n\tv3 = a->klass->vtable[0];\n\tv4 = a->klass->vtable[0];\n\t// 5 IndirectJump v3 @ X3_v1, a @ X0 (GoogleMobileAds.Api.AdSize), a @ X0 (GoogleMobileAds.Api.AdSize), b @ X1 (GoogleMobileAds.Api.AdSize), v4 @ X2_v1, v3 @ X3_v1, v6 @ X4, v7 @ X5, v8 @ X6, v9 @ X7, v10 @ V0, v11 @ V1, v12 @ V2, v13 @ V3, v14 @ V4, v15 @ V5, v16 @ V6, v17 @ V7\nL_000A:\n\tv22 = b == 0;\n\treturn v22;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator ==(AdSize a, AdSize b)
		{
			//IL_0025: Expected I, but got O
			//IL_0035: Expected O, but got I
			//IL_0045: Expected O, but got I
			if ((object)a != null)
			{
				nint num = (nint)a;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<GoogleMobileAds.Api.AdSize>)+138]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<GoogleMobileAds.Api.AdSize>)+140]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ X3_v1 (should have been resolved before IL gen)");
			}
			return (object)b == null;
		}

		[Token(Token = "0x60002E3")]
		[Address(RVA = "0x1357F30", Offset = "0x1357F30", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = a == 0;\n\tif (v0) goto L_000F;\n\tv50 = GoogleMobileAds.Api.AdSize::Equals(a, b);\n\tgoto L_0015;\nL_000F:\n\tv27 = b == 0;\nL_0015:\n\tv59 = ~v50;\n\treturn v59;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator !=(AdSize a, AdSize b)
		{
			bool flag;
			if ((object)a != null)
			{
				flag = a.Equals(b);
			}
			else
			{
				bool flag2 = (object)b == null;
				flag = flag2;
			}
			return !flag;
		}

		[Token(Token = "0x60002E4")]
		[Address(RVA = "0x1357F60", Offset = "0x1357F60", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this + 0x18;\n\tv14 = System.Int32::GetHashCode(v12);\n\tv16 = this + 0x1C;\n\tv18 = System.Int32::GetHashCode(v16);\n\tv20 = this + 0x10;\n\tv22 = System.Int32::GetHashCode(v20);\n\tv24 = this + 0x14;\n\tv26 = System.Int32::GetHashCode(v24);\n\tv28 = v14 ^ 0x30D;\n\tv30 = v28 * 0xB;\n\tv31 = v30 ^ v18;\n\tv32 = v31 * 0xB;\n\tv33 = v32 ^ v22;\n\tv38 = v33 * 0xB;\n\treturnVal1 = v38 ^ v26;\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override int GetHashCode()
		{
			int num = (int)((nint)this + 24);
			int hashCode = ((int*)num)->GetHashCode();
			int num2 = (int)((nint)this + 28);
			int hashCode2 = ((int*)num2)->GetHashCode();
			int num3 = (int)((nint)this + 16);
			int hashCode3 = ((int*)num3)->GetHashCode();
			int num4 = (int)((nint)this + 20);
			int hashCode4 = ((int*)num4)->GetHashCode();
			int num5 = hashCode ^ 0x30D;
			int num6 = num5 * 11;
			int num7 = num6 ^ hashCode2;
			int num8 = num7 * 11;
			int num9 = num8 ^ hashCode3;
			int num10 = num9 * 11;
			return num10 ^ hashCode4;
		}

		[Token(Token = "0x60002E5")]
		[Address(RVA = "0x1357FE0", Offset = "0x1357FE0", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = GoogleMobileAds.Api.AdSize;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A368F6]) = v34;\nL_0012:\n\tv36 = new GoogleMobileAds.Api.AdSize();\n\tSystem.Object::.ctor(v36);\n\tv36.type = *([407D00]);\n\tv42.Banner = v36;\n\tv44 = new GoogleMobileAds.Api.AdSize();\n\tSystem.Object::.ctor(v44);\n\tv44.type = *([407ED0]);\n\tv50.MediumRectangle = v44;\n\tv51 = new GoogleMobileAds.Api.AdSize();\n\tSystem.Object::.ctor(v51);\n\tv51.type = *([407C40]);\n\tv57.IABBanner = v51;\n\tv58 = new GoogleMobileAds.Api.AdSize();\n\tSystem.Object::.ctor(v58);\n\tv58.type = *([407BB0]);\n\tv64.Leaderboard = v58;\n\tv65 = new GoogleMobileAds.Api.AdSize();\n\tSystem.Object::.ctor(v65);\n\tv65.type = *([407B50]);\n\tv72.SmartBanner = v65;\n\tv72.FullWidth = 0xFFFFFFFF;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static AdSize()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407D00]");
			AdSize banner = new AdSize(0, 0, Type.Standard);
			Banner = banner;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407ED0]");
			AdSize adSize = new AdSize(0, 0, Type.Standard);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407ED0]");
			adSize.type = Type.Standard;
			MediumRectangle = adSize;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407C40]");
			AdSize iABBanner = new AdSize(0, 0, Type.Standard);
			IABBanner = iABBanner;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407BB0]");
			AdSize leaderboard = new AdSize(0, 0, Type.Standard);
			Leaderboard = leaderboard;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407B50]");
			AdSize smartBanner = new AdSize(0, 0, Type.Standard);
			SmartBanner = smartBanner;
			FullWidth = -1;
		}
	}
}
