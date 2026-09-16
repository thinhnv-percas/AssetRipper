using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x2000046")]
	public class RequestConfiguration
	{
		[Token(Token = "0x2000047")]
		public class Builder
		{
			[Token(Token = "0x17000038")]
			[field: Token(Token = "0x4000106")]
			[field: FieldOffset(Offset = "0x10")]
			internal MaxAdContentRating MaxAdContentRating
			{
				[Token(Token = "0x6000303")]
				[Address(RVA = "0x13584A4", Offset = "0x13584A4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<MaxAdContentRating>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x6000304")]
				[Address(RVA = "0x13584AC", Offset = "0x13584AC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MaxAdContentRating>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x17000039")]
			[field: Token(Token = "0x4000107")]
			[field: FieldOffset(Offset = "0x18")]
			internal TagForChildDirectedTreatment? TagForChildDirectedTreatment
			{
				[Token(Token = "0x6000305")]
				[Address(RVA = "0x13584B4", Offset = "0x13584B4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TagForChildDirectedTreatment>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x6000306")]
				[Address(RVA = "0x13584BC", Offset = "0x13584BC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TagForChildDirectedTreatment>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x1700003A")]
			[field: Token(Token = "0x4000108")]
			[field: FieldOffset(Offset = "0x20")]
			internal TagForUnderAgeOfConsent? TagForUnderAgeOfConsent
			{
				[Token(Token = "0x6000307")]
				[Address(RVA = "0x13584C4", Offset = "0x13584C4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TagForUnderAgeOfConsent>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x6000308")]
				[Address(RVA = "0x13584CC", Offset = "0x13584CC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TagForUnderAgeOfConsent>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x1700003B")]
			[field: Token(Token = "0x4000109")]
			[field: FieldOffset(Offset = "0x28")]
			internal List<string> TestDeviceIds
			{
				[Token(Token = "0x6000309")]
				[Address(RVA = "0x13584D4", Offset = "0x13584D4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TestDeviceIds>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x600030A")]
				[Address(RVA = "0x13584DC", Offset = "0x13584DC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TestDeviceIds>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x600030B")]
			[Address(RVA = "0x134B498", Offset = "0x134B498", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = System.Collections.Generic.List`1<System.String>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A368FF]) = v42;\nL_001B:\n\tSystem.Object::.ctor(this);\n\tthis.<MaxAdContentRating>k__BackingField = 0;\n\tthis.<TagForChildDirectedTreatment>k__BackingField = 0;\n\tthis.<TagForUnderAgeOfConsent>k__BackingField = 0;\n\tv48 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v48);\n\tthis.<TestDeviceIds>k__BackingField = v48;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Builder()
			{
				MaxAdContentRating = null;
				TagForChildDirectedTreatment = null;
				TagForUnderAgeOfConsent = null;
				List<string> list = new List<string>();
				TestDeviceIds = list;
			}

			[Token(Token = "0x600030C")]
			[Address(RVA = "0x134B530", Offset = "0x134B530", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MaxAdContentRating>k__BackingField = maxAdContentRating;\n\treturn this;\n")]
			public Builder SetMaxAdContentRating(MaxAdContentRating maxAdContentRating)
			{
				MaxAdContentRating = maxAdContentRating;
				return this;
			}

			[Token(Token = "0x600030D")]
			[Address(RVA = "0x134B520", Offset = "0x134B520", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TagForChildDirectedTreatment>k__BackingField = tagForChildDirectedTreatment;\n\treturn this;\n")]
			public Builder SetTagForChildDirectedTreatment(TagForChildDirectedTreatment? tagForChildDirectedTreatment)
			{
				TagForChildDirectedTreatment = tagForChildDirectedTreatment;
				return this;
			}

			[Token(Token = "0x600030E")]
			[Address(RVA = "0x134B528", Offset = "0x134B528", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TagForUnderAgeOfConsent>k__BackingField = tagForUnderAgeOfConsent;\n\treturn this;\n")]
			public Builder SetTagForUnderAgeOfConsent(TagForUnderAgeOfConsent? tagForUnderAgeOfConsent)
			{
				TagForUnderAgeOfConsent = tagForUnderAgeOfConsent;
				return this;
			}

			[Token(Token = "0x600030F")]
			[Address(RVA = "0x134B538", Offset = "0x134B538", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TestDeviceIds>k__BackingField = testDeviceIds;\n\treturn this;\n")]
			public Builder SetTestDeviceIds(List<string> testDeviceIds)
			{
				TestDeviceIds = testDeviceIds;
				return this;
			}

			[Token(Token = "0x6000310")]
			[Address(RVA = "0x134B540", Offset = "0x134B540", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = GoogleMobileAds.Api.RequestConfiguration;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36900]) = v37;\nL_0014:\n\tv39 = new GoogleMobileAds.Api.RequestConfiguration();\n\tGoogleMobileAds.Api.RequestConfiguration::.ctor(v39, this);\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public RequestConfiguration build()
			{
				return new RequestConfiguration(this);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x4000102")]
		[FieldOffset(Offset = "0x10")]
		private MaxAdContentRating _003CMaxAdContentRating_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000103")]
		[FieldOffset(Offset = "0x18")]
		private TagForChildDirectedTreatment? _003CTagForChildDirectedTreatment_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000104")]
		[FieldOffset(Offset = "0x20")]
		private TagForUnderAgeOfConsent? _003CTagForUnderAgeOfConsent_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000105")]
		[FieldOffset(Offset = "0x28")]
		private List<string> _003CTestDeviceIds_003Ek__BackingField;

		[Token(Token = "0x17000034")]
		public MaxAdContentRating MaxAdContentRating
		{
			[CompilerGenerated]
			[Token(Token = "0x60002F9")]
			[Address(RVA = "0x135839C", Offset = "0x135839C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<MaxAdContentRating>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MaxAdContentRating;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002FA")]
			[Address(RVA = "0x13583A4", Offset = "0x13583A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MaxAdContentRating>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CMaxAdContentRating_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000035")]
		public TagForChildDirectedTreatment? TagForChildDirectedTreatment
		{
			[CompilerGenerated]
			[Token(Token = "0x60002FB")]
			[Address(RVA = "0x13583AC", Offset = "0x13583AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TagForChildDirectedTreatment>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TagForChildDirectedTreatment;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002FC")]
			[Address(RVA = "0x13583B4", Offset = "0x13583B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TagForChildDirectedTreatment>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTagForChildDirectedTreatment_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000036")]
		public TagForUnderAgeOfConsent? TagForUnderAgeOfConsent
		{
			[CompilerGenerated]
			[Token(Token = "0x60002FD")]
			[Address(RVA = "0x13583BC", Offset = "0x13583BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TagForUnderAgeOfConsent>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TagForUnderAgeOfConsent;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002FE")]
			[Address(RVA = "0x13583C4", Offset = "0x13583C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TagForUnderAgeOfConsent>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTagForUnderAgeOfConsent_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000037")]
		public List<string> TestDeviceIds
		{
			[CompilerGenerated]
			[Token(Token = "0x60002FF")]
			[Address(RVA = "0x13583CC", Offset = "0x13583CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TestDeviceIds>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TestDeviceIds;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000300")]
			[Address(RVA = "0x13583D4", Offset = "0x13583D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TestDeviceIds>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CTestDeviceIds_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000301")]
		[Address(RVA = "0x13583DC", Offset = "0x13583DC", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<MaxAdContentRating>k__BackingField = builder.<MaxAdContentRating>k__BackingField;\n\tthis.<TagForChildDirectedTreatment>k__BackingField = builder.<TagForChildDirectedTreatment>k__BackingField;\n\tthis.<TagForUnderAgeOfConsent>k__BackingField = builder.<TagForUnderAgeOfConsent>k__BackingField;\n\tthis.<TestDeviceIds>k__BackingField = builder.<TestDeviceIds>k__BackingField;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private RequestConfiguration(Builder builder)
		{
			MaxAdContentRating = builder.MaxAdContentRating;
			TagForChildDirectedTreatment = builder.TagForChildDirectedTreatment;
			TagForUnderAgeOfConsent = builder.TagForUnderAgeOfConsent;
			TestDeviceIds = builder.TestDeviceIds;
		}

		[Token(Token = "0x6000302")]
		[Address(RVA = "0x1358428", Offset = "0x1358428", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = GoogleMobileAds.Api.RequestConfiguration+Builder;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A368FE]) = v37;\nL_0014:\n\tv39 = new GoogleMobileAds.Api.RequestConfiguration+Builder();\n\tGoogleMobileAds.Api.RequestConfiguration+Builder::.ctor(v39);\n\tv39.<MaxAdContentRating>k__BackingField = this.<MaxAdContentRating>k__BackingField;\n\tv39.<TagForChildDirectedTreatment>k__BackingField = this.<TagForChildDirectedTreatment>k__BackingField;\n\tv39.<TagForUnderAgeOfConsent>k__BackingField = this.<TagForUnderAgeOfConsent>k__BackingField;\n\tv39.<TestDeviceIds>k__BackingField = this.<TestDeviceIds>k__BackingField;\n\treturn v39;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Builder ToBuilder()
		{
			Builder builder = new Builder();
			builder.MaxAdContentRating = MaxAdContentRating;
			builder.TagForChildDirectedTreatment = TagForChildDirectedTreatment;
			builder.TagForUnderAgeOfConsent = TagForUnderAgeOfConsent;
			builder.TestDeviceIds = TestDeviceIds;
			return builder;
		}
	}
}
