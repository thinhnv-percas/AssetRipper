using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GoogleMobileAds.Api
{
	[Token(Token = "0x2000049")]
	public class ServerSideVerificationOptions
	{
		[Token(Token = "0x200004A")]
		public class Builder
		{
			[Token(Token = "0x17000040")]
			[field: Token(Token = "0x400010E")]
			[field: FieldOffset(Offset = "0x10")]
			internal string UserId
			{
				[Token(Token = "0x600031B")]
				[Address(RVA = "0x1358558", Offset = "0x1358558", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<UserId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x600031C")]
				[Address(RVA = "0x1358560", Offset = "0x1358560", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<UserId>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x17000041")]
			[field: Token(Token = "0x400010F")]
			[field: FieldOffset(Offset = "0x18")]
			internal string CustomData
			{
				[Token(Token = "0x600031D")]
				[Address(RVA = "0x1358568", Offset = "0x1358568", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CustomData>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
				[Token(Token = "0x600031E")]
				[Address(RVA = "0x1358570", Offset = "0x1358570", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CustomData>k__BackingField = value;\n\treturn;\n")]
				private set;
			}

			[Token(Token = "0x600031F")]
			[Address(RVA = "0x1358578", Offset = "0x1358578", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Builder()
			{
			}

			[Token(Token = "0x6000320")]
			[Address(RVA = "0x1358580", Offset = "0x1358580", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<UserId>k__BackingField = userId;\n\treturn this;\n")]
			public Builder SetUserId(string userId)
			{
				UserId = userId;
				return this;
			}

			[Token(Token = "0x6000321")]
			[Address(RVA = "0x1358588", Offset = "0x1358588", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CustomData>k__BackingField = customData;\n\treturn this;\n")]
			public Builder SetCustomData(string customData)
			{
				CustomData = customData;
				return this;
			}

			[Token(Token = "0x6000322")]
			[Address(RVA = "0x1358590", Offset = "0x1358590", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = GoogleMobileAds.Api.ServerSideVerificationOptions;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36902]) = v37;\nL_0014:\n\tv39 = new GoogleMobileAds.Api.ServerSideVerificationOptions();\n\tGoogleMobileAds.Api.ServerSideVerificationOptions::.ctor(v39, this);\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ServerSideVerificationOptions Build()
			{
				return new ServerSideVerificationOptions(this);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x400010C")]
		[FieldOffset(Offset = "0x10")]
		private string _003CUserId_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400010D")]
		[FieldOffset(Offset = "0x18")]
		private string _003CCustomData_003Ek__BackingField;

		[Token(Token = "0x1700003E")]
		public string UserId
		{
			[CompilerGenerated]
			[Token(Token = "0x6000316")]
			[Address(RVA = "0x1358504", Offset = "0x1358504", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<UserId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UserId;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000317")]
			[Address(RVA = "0x135850C", Offset = "0x135850C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<UserId>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CUserId_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700003F")]
		public string CustomData
		{
			[CompilerGenerated]
			[Token(Token = "0x6000318")]
			[Address(RVA = "0x1358514", Offset = "0x1358514", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CustomData>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CustomData;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000319")]
			[Address(RVA = "0x135851C", Offset = "0x135851C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CustomData>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CCustomData_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x600031A")]
		[Address(RVA = "0x1358524", Offset = "0x1358524", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<UserId>k__BackingField = builder.<UserId>k__BackingField;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ServerSideVerificationOptions(Builder builder)
		{
			UserId = builder.UserId;
		}
	}
}
