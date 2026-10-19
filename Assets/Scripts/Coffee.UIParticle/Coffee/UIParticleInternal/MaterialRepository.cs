using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x2000013")]
	internal static class MaterialRepository
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000014")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000013")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000014")]
			public static Func<string, Material> _003C_003E9__5_0;

			[Token(Token = "0x4000015")]
			public static Func<(string shaderName, string[] keywords), Material> _003C_003E9__6_0;

			[Token(Token = "0x6000050")]
			[Address(RVA = "0x3F207B4", Offset = "0x3F207B4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Coffee.UIParticleInternal.MaterialRepository+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000051")]
			[Address(RVA = "0x3F20818", Offset = "0x3F20818", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal Material _003CGet_003Eb__5_0(string x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MaterialRepository._003C_003Ec::_003CGet_003Eb__5_0");
				return default;
			}

			internal Material _003CGet_003Eb__6_0((string shaderName, string[] keywords) x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MaterialRepository._003C_003Ec::_003CGet_003Eb__6_0");
				return default;
			}
		}

		[Token(Token = "0x4000012")]
		internal static readonly ObjectRepository<Material> s_Repository;

		[Token(Token = "0x17000002")]
		public static int count
		{
			[Token(Token = "0x6000048")]
			[Address(RVA = "0x3F200E8", Offset = "0x3F200E8", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_001D;\nL_001D:\n\treturnVal1 = Coffee.UIParticleInternal.ObjectRepository`1<UnityEngine.Material>::get_count(v43.s_Repository);\n\treturn returnVal1;\n")]
			get
			{
				return s_Repository.count;
			}
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x3F2017C", Offset = "0x3F2017C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tgoto L_002C;\nL_002C:\n\treturnVal1 = Coffee.UIParticleInternal.ObjectRepository`1<UnityEngine.Material>::Valid(v55.s_Repository, hash, material);\n\treturn returnVal1;\n")]
		public static bool Valid(Hash128 hash, Material material)
		{
			return s_Repository.Valid(hash, material);
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x3F20238", Offset = "0x3F20238", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tgoto L_002E;\nL_002E:\n\tCoffee.UIParticleInternal.ObjectRepository`1<UnityEngine.Material>::Get(v56.s_Repository, hash, material, onCreate);\n\treturn;\n")]
		public static void Get(Hash128 hash, ref Material material, Func<Material> onCreate)
		{
			s_Repository.Get(hash, ref material, onCreate);
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x3F202FC", Offset = "0x3F202FC", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv113 = 0xB29A000 + 0x4E0;\n\tgoto L_001F;\nL_001F:\n\tv138 = v64.s_Repository;\n\tv77 = *([v113 @ X26_v2 (System.Int32)]);\n\tv68 = *([v77 @ X0_v37+E4]) == 0;\n\tv115 = v64.s_Repository;\n\tif (v68) goto L_0062;\n\tv178 = *([v77 @ X0_v37+B8]);\n\tv141 = *([v178 @ X8_v4+8]);\n\tv88 = *([v178 @ X8_v4+8]) == 0;\n\tv115 = v138;\n\tif (v88) goto L_006B;\nL_003E:\n\tCoffee.UIParticleInternal.ObjectRepository`1<UnityEngine.Material>::Get(v138, hash, material, v141, shaderName);\n\treturn;\nL_0062:\n\tv102 = *([v113 @ X26_v2 (System.Int32)]);\n\tv178 = *([v102 @ X0_v13+B8]);\n\tv141 = *([v178 @ X8_v4+8]);\n\tv121 = *([v178 @ X8_v4+8]) == 0;\n\tv105 = ~v121;\n\tv138 = v138;\n\tv113 = v113;\n\tif (v105) goto L_003E;\nL_006B:\n\tgoto L_0073;\n\tv216 = v115 == 0;\n\tv137 = ~v216;\n\tv138 = v115;\n\tv141 = v183;\n\tif (v137) goto L_003E;\n\tthrow System.NullReferenceException;\nL_0073:\n\tv183 = new System.Func`2<System.String, UnityEngine.Material>();\n\tSystem.Func`2<System.String, UnityEngine.Material>::.ctor(v183, *([v178 @ X8_v4]), Il2CppMethodInfo);\n\tv140 = *([v113 @ X26_v2 (System.Int32)]);\n\tv215 = *([v140 @ X8_v9+B8]) + 8;\n\t*([v215 @ X0_v8]) = v183;\n")]
		public static void Get(Hash128 hash, ref Material material, string shaderName)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MaterialRepository::Get");
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x3F20494", Offset = "0x3F20494", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv84 = 0xB29A000 + 0x4E0;\n\tgoto L_0022;\nL_0022:\n\tv129 = v69.s_Repository;\n\tv82 = *([v84 @ X27_v9 (System.Int32)]);\n\tv73 = *([v82 @ X0_v40+E4]) == 0;\n\tv125 = v84;\n\tv130 = v69.s_Repository;\n\tif (v73) goto L_0054;\n\tv162 = *([v82 @ X0_v40+B8]);\n\tv134 = *([v162 @ X8_v7+10]);\n\tv95 = *([v162 @ X8_v7+10]) == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_007B;\n\tv125 = v84;\n\tv130 = v129;\n\tgoto L_005F;\nL_0054:\n\tv123 = *([v84 @ X27_v9 (System.Int32)]);\n\tv162 = *([v123 @ X0_v16+B8]);\n\tv134 = *([v162 @ X8_v7+10]);\n\tv147 = *([v162 @ X8_v7+10]) == 0;\n\tv128 = ~v147;\n\tv129 = v129;\n\tif (v128) goto L_007B;\nL_005F:\n\tgoto L_0067;\nL_007B:\n\tSystem.ValueTuple`2<System.Object, System.Object>::.ctor(&v143 @ stack_-70_v2, shaderName, keywords);\n\tCoffee.UIParticleInternal.ObjectRepository`1::Get /* +1 sharing this address */(v129, hash, material, v134, v143, 0);\n\treturn;\nL_0067:\n\tv167 = new System.Func`2<System.ValueTuple`2<System.String, System.String[]>, UnityEngine.Material>();\n\tSystem.Func`2<System.ValueTuple`2<System.String, System.String[]>, UnityEngine.Material>::.ctor(v167, *([v162 @ X8_v7]), Il2CppMethodInfo);\n\tv132 = *([v125 @ X27_v4 (System.Int32)]);\n\tv202 = *([v132 @ X8_v12+B8]) + 0x10;\n\t*([v202 @ X0_v11]) = v167;\n\tv129 = v130;\n\tv134 = v167;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void Get(Hash128 hash, ref Material material, string shaderName, string[] keywords)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MaterialRepository::Get");
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x4ACFC20", Offset = "0x4ACFC20", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = *([v25 @ X6+38]) == 0;\n\tv38 = ~v37;\n\tif (v38) goto L_0024;\n\tv53 = *([v25 @ X6+38]) == 0;\n\tif (v53) goto L_0041;\nL_0024:\n\tgoto L_003E;\nL_003E:\n\tCoffee.UIParticleInternal.ObjectRepository`1::Get /* +1 sharing this address */(v76.s_Repository, hash, material, onCreate, source, methodInfo);\n\treturn;\nL_0041:\n\tv80 = 0x220C2B8(v25, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_003E;\n")]
		public static void Get<T>(Hash128 hash, ref Material material, Func<T, Material> onCreate, T source)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X6+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X6+38]");
				if ((nint)0 == 0)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C2B8");
				}
			}
			Il2CppRuntime.Boundary("MANAGED", "Method not found @40CBCB4 (Coffee.UIParticleInternal.ObjectRepository`1::Get, and 1 more at this address)");
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x3F20678", Offset = "0x3F20678", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\tCoffee.UIParticleInternal.ObjectRepository`1<UnityEngine.Material>::Release(v49.s_Repository, material);\n\treturn;\n")]
		public static void Release(ref Material material)
		{
			s_Repository.Release(ref material);
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x3F2071C", Offset = "0x3F2071C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\treturn;\nL_0020:\n\tv49 = new Coffee.UIParticleInternal.ObjectRepository`1<UnityEngine.Material>();\n\tCoffee.UIParticleInternal.ObjectRepository`1<UnityEngine.Material>::.ctor(v49, 0);\n\tv59.s_Repository = v49;\n")]
		static MaterialRepository()
		{
			ObjectRepository<Material> objectRepository = new ObjectRepository<Material>();
			s_Repository = objectRepository;
		}
	}
}
