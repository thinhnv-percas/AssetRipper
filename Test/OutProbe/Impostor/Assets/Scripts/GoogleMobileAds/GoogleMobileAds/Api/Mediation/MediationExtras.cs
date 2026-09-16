using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GoogleMobileAds.Api.Mediation
{
	[Token(Token = "0x2000059")]
	public abstract class MediationExtras
	{
		[CompilerGenerated]
		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0x10")]
		private Dictionary<string, string> _003CExtras_003Ek__BackingField;

		[Token(Token = "0x17000045")]
		public Dictionary<string, string> Extras
		{
			[CompilerGenerated]
			[Token(Token = "0x60003AD")]
			[Address(RVA = "0x135E39C", Offset = "0x135E39C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Extras>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Extras;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003AE")]
			[Address(RVA = "0x135E3A4", Offset = "0x135E3A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Extras>k__BackingField = value;\n\treturn;\n")]
			protected set
			{
				_003CExtras_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000046")]
		public abstract string AndroidMediationExtraBuilderClassName
		{
			[Token(Token = "0x60003B0")]
			get;
		}

		[Token(Token = "0x17000047")]
		public abstract string IOSMediationExtraBuilderClassName
		{
			[Token(Token = "0x60003B1")]
			get;
		}

		[Token(Token = "0x60003AF")]
		[Address(RVA = "0x135E3AC", Offset = "0x135E3AC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = System.Collections.Generic.Dictionary`2<System.String, System.String>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A3696D]) = v42;\nL_001B:\n\tSystem.Object::.ctor(this);\n\tv48 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v48);\n\tthis.<Extras>k__BackingField = v48;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MediationExtras()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			Extras = dictionary;
		}
	}
}
