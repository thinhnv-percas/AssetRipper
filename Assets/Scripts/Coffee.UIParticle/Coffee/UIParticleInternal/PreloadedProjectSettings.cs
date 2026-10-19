using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x2000009")]
	public abstract class PreloadedProjectSettings : ScriptableObject
	{
		[Token(Token = "0x600001E")]
		[Address(RVA = "0x3F1F960", Offset = "0x3F1F960", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		protected internal PreloadedProjectSettings()
		{
		}
	}
	[Token(Token = "0x200000A")]
	public abstract class PreloadedProjectSettings<T> : PreloadedProjectSettings where T : PreloadedProjectSettings<T>
	{
		[Token(Token = "0x4000009")]
		private static T s_Instance;

		[Token(Token = "0x17000001")]
		public static T instance
		{
			[Token(Token = "0x600001F")]
			[Address(RVA = "0x5F1E98C", Offset = "0x5F1E98C", Length = "0x1B8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_0025:\n\tgoto L_002D;\nL_002D:\n\tgoto L_0031;\nL_0031:\n\tv71 = UnityEngine.Object::op_Implicit(v61.s_Instance);\n\tv77 = v71 == 0;\n\tif (v77) goto L_0055;\n\tgoto L_0045;\nL_0045:\n\tgoto L_0051;\nL_0051:\n\treturn v100.s_Instance;\nL_0055:\n\tgoto L_0059;\nL_0059:\n\tv97 = UnityEngine.ScriptableObject::CreateInstance();\n\tv110 = Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1>;\n\tv113 = *([v110 @ X0_v14 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1>)+135]) & 1;\n\tv114 = v113 == 0;\n\tif (v114) goto L_0085;\n\tv136 = Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>;\n\tv139 = *([v136 @ X0_v33 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>)+135]) & 1;\n\tv140 = v139 == 0;\n\tv154 = Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>;\n\tif (v140) goto L_008E;\nL_0069:\n\tv148.s_Instance = v97;\n\tv149 = Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1>;\n\tv152 = *([v149 @ X0_v32 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1>)+135]) & 1;\n\tv153 = v152 == 0;\n\tv175 = Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1>;\n\tif (v153) goto L_0098;\nL_0077:\n\tgoto L_0084;\nL_0084:\n\treturn v97;\nL_0085:\n\tv141 = 0x220C238(Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv158 = *([v141 @ X0_v21+C0]);\n\tv154 = *([v158 @ X8_v22+10]);\n\tv160 = *([v154 @ X0_v18 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>)+135]) & 1;\n\tv161 = v160 == 0;\n\tv145 = ~v161;\n\tif (v145) goto L_0069;\nL_008E:\n\tv157 = 0x220C238(v154, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv179 = *([v157 @ X0_v19+B8]);\n\t*([v179 @ X8_v19]) = v97;\n\tv163 = Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1>;\n\tv181 = *([v163 @ X0_v20 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1>)+135]) & 1;\n\tv182 = v181 == 0;\n\tv165 = ~v182;\n\tv175 = Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1>;\n\tif (v165) goto L_0077;\nL_0098:\n\tv178 = 0x220C238(v175, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00A0;\nL_00A0:\n\tgoto L_0084;\nL_001A:\n\tgoto L_0025;\n")]
			get
			{
				//IL_0141: Expected O, but got I
				//IL_01ae: Expected O, but got I
				if ((bool)s_Instance)
				{
					return s_Instance;
				}
				T val = ScriptableObject.CreateInstance<T>();
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X0_v14 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ X0_v33 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>)+135]");
					int num3 = (int)((nint)0 & (nint)1);
					bool flag = num3 == 0;
					nint num4 = 0;
					if (!flag)
					{
						goto IL_00d0;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X0_v21+C0]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ X8_v22+10]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X0_v18 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>)+135]");
					if ((uint)((nuint)0u & (nuint)1u) != 0)
					{
						goto IL_00d0;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X0_v19+B8]");
				object obj2 = 0;
				obj2 = val;
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X0_v20 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1>)+135]");
				int num6 = (int)((nint)0 & (nint)1);
				bool flag2 = num6 == 0;
				bool flag3 = !flag2;
				nint num7 = 0;
				if (flag3)
				{
					goto IL_011d;
				}
				goto IL_0200;
				IL_00d0:
				s_Instance = val;
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X0_v32 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1>)+135]");
				int num9 = (int)((nint)0 & (nint)1);
				bool flag4 = num9 == 0;
				num7 = 0;
				if (!flag4)
				{
					goto IL_011d;
				}
				goto IL_0200;
				IL_0200:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				goto IL_011d;
				IL_011d:
				return val;
			}
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x5F1EB44", Offset = "0x5F1EB44", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_0024:\n\tgoto L_0027;\nL_0027:\n\tv68 = UnityEngine.Object::op_Implicit(v52.s_Instance);\n\tv77 = v68 == 0;\n\tif (v77) goto L_004B;\n\treturn;\nL_004B:\n\tgoto L_0050;\n\tv146.s_Instance = v137;\n\tv147 = Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>;\n\tv150 = *([v147 @ X0_v21 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>)+135]) & 1;\n\tv151 = v150 == 0;\nL_FFFFFFFF:\n\tv169 = Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>;\n\tif (v151) goto L_0086;\nL_FFFFFFFF:\n\tv190 = Il2CppClass<T>;\n\tgoto L_006E;\nL_007A:\n\tv152 = 0x220C238(Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv174 = *([v152 @ X0_v15+B8]);\n\t*([v174 @ X9_v5]) = v137;\n\tv156 = Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>;\n\tv176 = *([v156 @ X0_v16 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>)+135]) & 1;\n\tv177 = v176 == 0;\n\tv158 = ~v177;\nL_FFFFFFFF:\n\tv169 = Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>;\n\tif (v158) goto L_FFFFFFFF;\nL_0086:\n\tv172 = 0x220C238(v169, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv190 = Il2CppClass<T>;\n\tgoto L_006E;\nL_001E:\n\tgoto L_0024;\nL_0050:\n\tv137 = 0x21C11D0(this, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv141 = Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>;\n\tv144 = *([v141 @ X0_v7 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>)+135]) & 1;\n\tv145 = v144 == 0;\n\tif (v145) goto L_007A;\nL_006E:\n\tv195 = 0x21C11D0(this, v190, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		protected virtual void OnEnable()
		{
			//IL_00ad: Expected O, but got I
			if ((bool)s_Instance)
			{
				return;
			}
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X0_v7 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>)+135]");
			T val = default(T);
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				s_Instance = val;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ X0_v21 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>)+135]");
				int num3 = (int)((nint)0 & (nint)1);
				bool flag = num3 == 0;
				nint num4 = 0;
				if (!flag)
				{
					goto IL_0083;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X0_v15+B8]");
				object obj = 0;
				obj = val;
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X0_v16 (Il2CppClass<Coffee.UIParticleInternal.PreloadedProjectSettings`1<T>>)+135]");
				int num6 = (int)((nint)0 & (nint)1);
				bool flag2 = num6 == 0;
				bool flag3 = !flag2;
				nint num4 = 0;
				if (flag3)
				{
					goto IL_0083;
				}
			}
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			nint num7 = 0;
			goto IL_016b;
			IL_0083:
			num7 = 0;
			goto IL_016b;
			IL_016b:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x5F1ECE4", Offset = "0x5F1ECE4", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_0024:\n\tgoto L_0028;\nL_0028:\n\tv69 = UnityEngine.Object::op_Inequality(v52.s_Instance, this);\n\tv78 = v69 == 0;\n\tif (v78) goto L_004D;\n\treturn;\nL_004D:\n\tgoto L_0050;\nL_0050:\n\tv122.s_Instance = 0;\n\treturn;\nL_001E:\n\tgoto L_0024;\n")]
		protected virtual void OnDisable()
		{
			if (!(s_Instance != this))
			{
				s_Instance = null;
			}
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x5F1EDD8", Offset = "0x5F1EDD8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tCoffee.UIParticleInternal.PreloadedProjectSettings::.ctor(this);\n\treturn;\n")]
		protected internal PreloadedProjectSettings()
		{
		}
	}
}
