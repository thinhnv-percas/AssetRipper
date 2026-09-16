using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000037")]
	public class IronSourceSettings
	{
		[Serializable]
		[Token(Token = "0x2000111")]
		public class SegmentSettings
		{
			[Token(Token = "0x4000492")]
			[FieldOffset(Offset = "0x10")]
			public int age;

			[Token(Token = "0x4000493")]
			[FieldOffset(Offset = "0x18")]
			public string gender;

			[Token(Token = "0x4000494")]
			[FieldOffset(Offset = "0x20")]
			public int level;

			[Token(Token = "0x4000495")]
			[FieldOffset(Offset = "0x24")]
			public bool isPaying;

			[Token(Token = "0x4000496")]
			[FieldOffset(Offset = "0x28")]
			public long userCreationDate;

			[Token(Token = "0x4000497")]
			[FieldOffset(Offset = "0x30")]
			public double iapt;

			[Token(Token = "0x4000498")]
			[FieldOffset(Offset = "0x38")]
			public string segmentName;

			[Token(Token = "0x4000499")]
			[FieldOffset(Offset = "0x40")]
			public StringStringSerializableDictionary customParams;

			[Token(Token = "0x600094B")]
			[Address(RVA = "0xB54F14", Offset = "0xB54F14", Length = "0x160")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EBCE70]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227C5]) = v38;\nL_0018:\n\tv44 = 0;\n\tv46 = new IronSourceSegment();\n\tIronSourceSegment::.ctor(v46);\n\tv49 = v46 == 0;\n\tif (v49) goto L_004C;\n\tv46.age = this.age;\n\tv46.gender = this.gender;\n\tv46.level = this.level;\n\tv46.isPaying = this.isPaying;\n\tv46.userCreationDate = this.userCreationDate;\n\tv46.iapt = this.iapt;\n\tv46.segmentName = this.segmentName;\n\tv58 = this.customParams == 0;\n\tif (v58) goto L_006A;\n\tv65 = System.Collections.Generic.Dictionary`2<System.String, System.String>::GetEnumerator(this.customParams);\nL_003A:\n\tv150 = System.Collections.Generic.Dictionary`2<System.String, System.String>+Enumerator<System.String, System.String>::MoveNext(&v44 @ stack_-48_v1 (System.Collections.Generic.Dictionary`2<System.String, System.String>+Enumerator<System.String, System.String>));\n\tv132 = v150 == 0;\n\tif (v132) goto L_0047;\n\tIronSourceSegment::setCustom(v46, 0, v158);\n\tgoto L_003A;\nL_0047:\n\treturnVal3 = System.Collections.Generic.Dictionary`2<System.String, System.String>+Enumerator<System.String, System.String>::MoveNext(&v44 @ stack_-48_v1 (System.Collections.Generic.Dictionary`2<System.String, System.String>+Enumerator<System.String, System.String>));\n\treturn returnVal3;\n\tX0 = 0xDE9790(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_006A;\nL_004C:\n\tv60 = new System.NullReferenceException();\n\tgoto L_0058;\nL_0058:\n\tgoto L_006B;\n\tv151 = 0x6D2BC0(v60, 0, v22, v23, v24, v25, v26, v27, 0, v29, v30, v31, v32, v33, v34, v35);\n\tv154 = 0x6D2490(v151, 0, v22, v23, v24, v25, v26, v27, 0, v29, v30, v31, v32, v33, v34, v35);\n\tv96 = System.Collections.Generic.Dictionary`2<System.String, System.String>+Enumerator<System.String, System.String>::Dispose(&v44 @ stack_-48_v1 (System.Collections.Generic.Dictionary`2<System.String, System.String>+Enumerator<System.String, System.String>));\n\tv163 = *([v151 @ X0_v12]) == 0;\n\tv98 = ~v163;\n\tif (v98) goto L_006F;\nL_006A:\n\treturn v46;\nL_006B:\n\tv152 = 0x6D2380(v60, 0, v22, v23, v24, v25, v26, v27, 0, v29, v30, v31, v32, v33, v34, v35);\nL_006F:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public IronSourceSegment ToIronSourceSegment()
			{
				//IL_00c1: Expected O, but got I4
				Dictionary<string, string>.Enumerator enumerator = default(Dictionary<string, string>.Enumerator);
				IronSourceSegment ironSourceSegment = new IronSourceSegment();
				if (ironSourceSegment != null)
				{
					ironSourceSegment.age = age;
					ironSourceSegment.gender = gender;
					ironSourceSegment.level = level;
					ironSourceSegment.isPaying = (isPaying ? 1 : 0);
					ironSourceSegment.userCreationDate = userCreationDate;
					ironSourceSegment.iapt = iapt;
					ironSourceSegment.segmentName = segmentName;
					if (customParams != null)
					{
						Dictionary<string, string>.Enumerator enumerator2 = customParams.GetEnumerator();
						string value = default(string);
						while (enumerator.MoveNext())
						{
							ironSourceSegment.setCustom(null, value);
						}
						return (IronSourceSegment)enumerator.MoveNext();
					}
					return ironSourceSegment;
				}
				NullReferenceException ex = new NullReferenceException();
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				return (IronSourceSegment)(object)new TypeLoadException();
			}

			[Token(Token = "0x600094C")]
			[Address(RVA = "0xB55560", Offset = "0xB55560", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SegmentSettings()
			{
			}
		}

		[Token(Token = "0x2000112")]
		public enum IronSourceBannerType
		{
			[Token(Token = "0x400049B")]
			Banner = 0,
			[Token(Token = "0x400049C")]
			LargeBanner = 1,
			[Token(Token = "0x400049D")]
			RectangleBanner = 2,
			[Token(Token = "0x400049E")]
			SmartBanner = 3
		}

		[SerializeField]
		[Token(Token = "0x400018A")]
		[FieldOffset(Offset = "0x10")]
		private AdId mAppId;

		[SerializeField]
		[Token(Token = "0x400018B")]
		[FieldOffset(Offset = "0x18")]
		private bool mUseAdvancedSetting;

		[SerializeField]
		[Token(Token = "0x400018C")]
		[FieldOffset(Offset = "0x20")]
		private SegmentSettings mSegments;

		[Token(Token = "0x170000DF")]
		public AdId AppId
		{
			[Token(Token = "0x6000316")]
			[Address(RVA = "0xB55524", Offset = "0xB55524", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAppId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AppId;
			}
			[Token(Token = "0x6000317")]
			[Address(RVA = "0xB5552C", Offset = "0xB5552C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAppId = value;\n\treturn;\n")]
			set
			{
				AppId = value;
			}
		}

		[Token(Token = "0x170000E0")]
		public bool UseAdvancedSetting
		{
			[Token(Token = "0x6000318")]
			[Address(RVA = "0xB55534", Offset = "0xB55534", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mUseAdvancedSetting;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UseAdvancedSetting;
			}
			[Token(Token = "0x6000319")]
			[Address(RVA = "0xB5553C", Offset = "0xB5553C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mUseAdvancedSetting = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mUseAdvancedSetting = value;
			}
		}

		[Token(Token = "0x170000E1")]
		public SegmentSettings Segments
		{
			[Token(Token = "0x600031A")]
			[Address(RVA = "0xB55548", Offset = "0xB55548", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mSegments;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Segments;
			}
			[Token(Token = "0x600031B")]
			[Address(RVA = "0xB55550", Offset = "0xB55550", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mSegments = value;\n\treturn;\n")]
			set
			{
				Segments = value;
			}
		}

		[Token(Token = "0x600031C")]
		[Address(RVA = "0xB55558", Offset = "0xB55558", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IronSourceSettings()
		{
		}
	}
}
