using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace AllIn1VfxToolkit
{
	[Token(Token = "0x2000007")]
	public static class RenderPipelineChecker
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000008")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000015")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000016")]
			public static Func<Assembly, IEnumerable<Type>> _003C_003E9__15_0;

			[Token(Token = "0x4000017")]
			public static Func<Assembly, Type, _003C_003Ef__AnonymousType0<Assembly, Type>> _003C_003E9__15_1;

			[Token(Token = "0x4000018")]
			public static Func<_003C_003Ef__AnonymousType0<Assembly, Type>, Type> _003C_003E9__15_3;

			[Token(Token = "0x4000019")]
			public static Func<Type, bool> _003C_003E9__16_0;

			[Token(Token = "0x6000012")]
			[Address(RVA = "0x3C24F3C", Offset = "0x3C24F3C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new AllIn1VfxToolkit.RenderPipelineChecker+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000013")]
			[Address(RVA = "0x3C24FA0", Offset = "0x3C24FA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal IEnumerable<Type> _003CDoesTypeExist_003Eb__15_0(Assembly assembly)
			{
				return GetTypesSafe(assembly);
			}

			internal _003C_003Ef__AnonymousType0<Assembly, Type> _003CDoesTypeExist_003Eb__15_1(Assembly assembly, Type type)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("RenderPipelineChecker._003C_003Ec::_003CDoesTypeExist_003Eb__15_1");
				return default;
			}

			internal Type _003CDoesTypeExist_003Eb__15_3(_003C_003Ef__AnonymousType0<Assembly, Type> _003C_003Eh__TransparentIdentifier0)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("RenderPipelineChecker._003C_003Ec::_003CDoesTypeExist_003Eb__15_3");
				return default;
			}

			internal bool _003CGetTypesSafe_003Eb__16_0(Type x)
			{
				//IL_001f: Expected O, but got I
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ X8_v2 (System.Int32)+E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X0_v1+E4]");
				if ((nint)0 != 0)
				{
					return x != null;
				}
				return x != null;
			}
		}

		[Token(Token = "0x4000010")]
		private const string HDRP_PACKAGE = "HDRenderPipelineAsset";

		[Token(Token = "0x4000011")]
		private const string URP_PACKAGE = "UniversalRenderPipelineAsset";

		[Token(Token = "0x17000003")]
		[field: Token(Token = "0x4000012")]
		public static bool IsHDRP
		{
			[Token(Token = "0x6000009")]
			[Address(RVA = "0x3C2465C", Offset = "0x3C2465C", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\treturn v40.<IsHDRP>k__BackingField;\n")]
			get;
			[Token(Token = "0x600000A")]
			[Address(RVA = "0x3C246A8", Offset = "0x3C246A8", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv45.<IsHDRP>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000004")]
		[field: Token(Token = "0x4000013")]
		public static bool IsURP
		{
			[Token(Token = "0x600000B")]
			[Address(RVA = "0x3C24700", Offset = "0x3C24700", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\treturn v40.<IsURP>k__BackingField;\n")]
			get;
			[Token(Token = "0x600000C")]
			[Address(RVA = "0x3C2474C", Offset = "0x3C2474C", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv45.<IsURP>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000005")]
		[field: Token(Token = "0x4000014")]
		public static bool IsStandardRP
		{
			[Token(Token = "0x600000D")]
			[Address(RVA = "0x3C247A4", Offset = "0x3C247A4", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\treturn v40.<IsStandardRP>k__BackingField;\n")]
			get;
			[Token(Token = "0x600000E")]
			[Address(RVA = "0x3C247F0", Offset = "0x3C247F0", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv45.<IsStandardRP>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x3C24848", Offset = "0x3C24848", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv74.<IsURP>k__BackingField = v67;\n\tv77 = *([B193A83]) & 1;\n\tv78 = v77 == 0;\n\tif (v78) goto L_005A;\nL_003F:\n\tv93 = v87.<IsHDRP>k__BackingField == 0;\n\tif (v93) goto L_0067;\nL_0048:\n\treturn;\nL_004D:\n\t*([B193A82]) = 1;\n\tv88.<IsURP>k__BackingField = v67;\n\tv103 = *([B193A83]) & 1;\n\tv104 = v103 == 0;\n\tv86 = ~v104;\n\tif (v86) goto L_003F;\nL_005A:\n\t*([B193A83]) = 1;\n\tv136 = v114.<IsHDRP>k__BackingField == 0;\n\tv111 = ~v136;\n\tif (v111) goto L_0048;\nL_0067:\n\tgoto L_0070;\n\tgoto L_0080;\nL_001B:\n\tv47 = AllIn1VfxToolkit.RenderPipelineChecker::DoesTypeExist(\"HDRenderPipelineAsset\");\n\tgoto L_002C;\nL_002C:\n\tv65.<IsHDRP>k__BackingField = v47;\n\tv67 = AllIn1VfxToolkit.RenderPipelineChecker::DoesTypeExist(\"UniversalRenderPipelineAsset\");\n\tv71 = *([B193A82]) & 1;\n\tv72 = v71 == 0;\n\tif (v72) goto L_004D;\nL_0070:\n\tv161 = v115.<IsURP>k__BackingField == 0;\n\tv112 = ~v161;\n\tif (v112) goto L_0048;\nL_0080:\n\tv152.<IsStandardRP>k__BackingField = 1;\n\treturn;\n")]
		public static void RefreshData()
		{
			bool flag = DoesTypeExist("HDRenderPipelineAsset");
			IsHDRP = flag;
			bool flag2 = DoesTypeExist("UniversalRenderPipelineAsset");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193A82]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				IsURP = flag2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193A83]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0041;
				}
			}
			else
			{
				_ = 1;
				IsURP = flag2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193A83]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0041;
				}
			}
			_ = 1;
			if (IsHDRP)
			{
				return;
			}
			goto IL_0143;
			IL_0143:
			if (!IsURP)
			{
				IsStandardRP = true;
			}
			return;
			IL_0041:
			if (IsHDRP)
			{
				return;
			}
			goto IL_0143;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x3C249D0", Offset = "0x3C249D0", Length = "0x388")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0044;\n\tv58.className = className;\n\tv77 = System.AppDomain::get_CurrentDomain();\n\tv133 = System.AppDomain::GetAssemblies(v77);\n\tgoto L_005D;\nL_005D:\n\tv192 = v144.<>9__15_0;\n\tv146 = v144.<>9__15_0 == 0;\n\tif (v146) goto L_00F0;\n\tgoto L_006C;\nL_006C:\n\tv233 = v206.<>9__15_1;\n\tv208 = v206.<>9__15_1 == 0;\n\tv209 = ~v208;\n\tif (v209) goto L_008D;\n\tgoto L_007B;\nL_008D:\n\tv246 = System.Linq.Enumerable::SelectMany(v133, v192, v233);\n\tv264 = new System.Func`2<<>f__AnonymousType0`2<System.Reflection.Assembly, System.Type>, System.Boolean>();\n\tSystem.Func`2<<>f__AnonymousType0`2<System.Reflection.Assembly, System.Type>, System.Boolean>::.ctor(v264, v58, Il2CppMethodInfo);\n\tv285 = System.Linq.Enumerable::Where(v246, v264);\n\tgoto L_00A8;\n\tgoto L_00B6;\nL_00C7:\n\tv323 = System.Linq.Enumerable::Select(v285, v318);\n\tv333 = System.Linq.Enumerable::FirstOrDefault(v323);\n\tgoto L_00E4;\nL_00F0:\n\tgoto L_00F8;\n\tv192 = v219;\n\tgoto L_006C;\nL_0044:\n\tv58 = new AllIn1VfxToolkit.RenderPipelineChecker+<>c__DisplayClass15_0();\n\tSystem.Object::.ctor(v58);\nL_007B:\n\tv261 = new System.Func`3<System.Reflection.Assembly, System.Type, <>f__AnonymousType0`2<System.Reflection.Assembly, System.Type>>();\n\tSystem.Func`3<System.Reflection.Assembly, System.Type, <>f__AnonymousType0`2<System.Reflection.Assembly, System.Type>>::.ctor(v261, v256.<>9, Il2CppMethodInfo);\n\tv280.<>9__15_1 = v261;\n\tv233 = v261;\nL_00A8:\n\tv300 = v298.<>9__15_3 == 0;\n\tv301 = ~v300;\n\tv318 = v298.<>9__15_3;\n\tif (v301) goto L_00C7;\nL_00B6:\n\tv331 = new System.Func`2<<>f__AnonymousType0`2<System.Reflection.Assembly, System.Type>, System.Type>();\n\tSystem.Func`2<<>f__AnonymousType0`2<System.Reflection.Assembly, System.Type>, System.Type>::.ctor(v331, v326.<>9, Il2CppMethodInfo);\n\tv341.<>9__15_3 = v331;\n\tv318 = v331;\nL_00E4:\n\treturnVal2 = System.Type::op_Inequality(v333, 0);\n\treturn returnVal2;\nL_00F8:\n\tv219 = new System.Func`2<System.Reflection.Assembly, System.Collections.Generic.IEnumerable`1<System.Type>>();\n\tSystem.Func`2<System.Reflection.Assembly, System.Collections.Generic.IEnumerable`1<System.Type>>::.ctor(v219, v214.<>9, Il2CppMethodInfo);\n\tv266.<>9__15_0 = v219;\n")]
		public static bool DoesTypeExist(string className)
		{
			return AppDomain.CurrentDomain.GetAssemblies().SelectMany(GetTypesSafe).Any(type => type.Name == className);
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x3C24D60", Offset = "0x3C24D60", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv56 = System.Reflection.Assembly::GetTypes(v44);\n\tgoto L_002F;\nL_002F:\n\t;\n\tv71 = v69.<>9__16_0 == 0;\n\tv72 = ~v71;\n\tv93 = v69.<>9__16_0;\n\tif (v72) goto L_008A;\n\tgoto L_0068;\nL_0036:\n\tv63 = new System.NullReferenceException();\n\tgoto L_0094;\nL_0068:\n\tgoto L_0070;\nL_008A:\n\treturnVal1 = System.Linq.Enumerable::Where(v56, v93);\n\treturn returnVal1;\nL_0094:\n\t// 148 Interrupt\nL_0021:\n\tv49 = v44 == 0;\n\tif (v49) goto L_0036;\n\tthrow v63;\nL_0070:\n\tv129 = new System.Func`2<System.Type, System.Boolean>();\n\tSystem.Func`2<System.Type, System.Boolean>::.ctor(v129, v124.<>9, Il2CppMethodInfo);\n\tv155.<>9__16_0 = v129;\n\tv93 = v129;\n")]
		public static IEnumerable<Type> GetTypesSafe(Assembly assembly)
		{
			Assembly assembly2 = default(Assembly);
			if ((object)assembly2 != null)
			{
				Type[] types = assembly2.GetTypes();
				bool flag = _003C_003Ec._003C_003E9__16_0 == null;
				bool flag2 = !flag;
				Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__16_0;
				if (!flag2)
				{
					predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__16_0 = delegate(Type x)
					{
						//IL_001f: Expected O, but got I
						int num = 192761856 + 1336;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ X8_v2 (System.Int32)+E0]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X0_v1+E4]");
						return ((nint)0 != 0) ? (x != null) : (x != null);
					});
				}
				return (IEnumerable<Type>)types.Where(predicate);
			}
			NullReferenceException ex = new NullReferenceException();
			throw ex;
		}
	}
}
