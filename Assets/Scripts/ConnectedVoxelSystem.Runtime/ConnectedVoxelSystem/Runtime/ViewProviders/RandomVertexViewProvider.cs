using System;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.OptionalValueSystem;
using UnityEngine;

namespace ConnectedVoxelSystem.Runtime.ViewProviders
{
	[Serializable]
	[Token(Token = "0x2000010")]
	public class RandomVertexViewProvider<T> : IVertexMeshProvider<T>, ISerializationCallbackReceiver where T : struct
	{
		[Serializable]
		[Token(Token = "0x2000011")]
		private struct WeightedView
		{
			[SerializeField]
			[Token(Token = "0x400002D")]
			[FieldOffset(Offset = "0x0")]
			private float m_weight;

			[SerializeReference]
			[Token(Token = "0x400002E")]
			[FieldOffset(Offset = "0x0")]
			private IVertexMeshProvider<T> m_viewProvider;

			[Token(Token = "0x17000010")]
			public float Weight
			{
				[Token(Token = "0x6000055")]
				[Address(RVA = "0x6BDC7E4", Offset = "0x6BDC7E4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Weight;\n")]
				get
				{
					return m_weight;
				}
			}

			[Token(Token = "0x17000011")]
			public IVertexMeshProvider<T> ViewProvider
			{
				[Token(Token = "0x6000056")]
				[Address(RVA = "0x6BDC7EC", Offset = "0x6BDC7EC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ViewProvider;\n")]
				get
				{
					return m_viewProvider;
				}
			}

			[Token(Token = "0x6000057")]
			[Address(RVA = "0x6BDC7F4", Offset = "0x6BDC7F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Weight = value;\n\treturn;\n")]
			public void Internal_SetWeight(float value)
			{
				m_weight = value;
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000012")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400002F")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000030")]
			public static Func<WeightedView, float> _003C_003E9__3_0;

			[Token(Token = "0x4000031")]
			public static Func<WeightedView, float> _003C_003E9__4_0;

			[Token(Token = "0x6000058")]
			[Address(RVA = "0x4F9C0DC", Offset = "0x4F9C0DC", Length = "0x1A0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>;\n\tv19 = *([v16 @ X0_v1 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]) & 1;\n\tv20 = v19 == 0;\n\tif (v20) goto L_002B;\n\tv22 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv25 = *([v22 @ X0_v42 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv26 = v25 == 0;\n\tv47 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv52 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tif (v26) goto L_0034;\nL_0016:\n\tv49 = new v47();\n\tv59 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>;\n\tv77 = *([v59 @ X0_v41 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]);\n\tv62 = *([v59 @ X0_v41 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]) & 1;\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tv100 = v49;\n\tv74 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>;\n\tv107 = v49;\n\tv103 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>;\n\tif (v64) goto L_003E;\nL_001F:\n\tv76 = 0x220C238(v74, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv90 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>;\n\tv93 = *([v76 @ X0_v37+C0]);\n\tv94 = *([v93 @ X8_v43+8]);\n\tv98 = *([v94 @ X8_v44]);\n\tv96 = *([v90 @ X0_v38 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]) & 1;\n\tv97 = v96 == 0;\n\tv103 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>;\n\tif (v97) goto L_0044;\n\tv105 = *([v94 @ X8_v44]);\n\tv107 = v100;\n\tgoto L_0048;\nL_002B:\n\tv27 = 0x220C238(Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv54 = *([v27 @ X0_v34+C0]);\n\tv47 = *([v54 @ X8_v38]);\n\tv56 = *([v47 @ X0_v39 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv57 = v56 == 0;\n\tv44 = ~v57;\n\tv52 = v47;\n\tif (v44) goto L_0016;\nL_0034:\n\tv53 = 0x220C238(v52, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv65 = new v53();\n\tv75 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>;\n\tv77 = *([v75 @ X0_v33 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]);\n\tv88 = *([v75 @ X0_v33 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]) & 1;\n\tv71 = v88 == 0;\n\tv100 = v65;\n\tv74 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>;\n\tv107 = v65;\n\tv103 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>;\n\tif (v71) goto L_001F;\nL_003E:\n\tv83 = Il2CppMethodInfo;\n\tv98 = *([v83 @ X8_v35 (Il2CppMethodInfo)]);\n\tv85 = v77 & 1;\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tv100 = v107;\n\tv105 = *([v83 @ X8_v35 (Il2CppMethodInfo)]);\n\tif (v87) goto L_0048;\nL_0044:\n\tv104 = 0x220C238(v103, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv105 = v98;\n\tv107 = v100;\nL_0048:\n\tv105(v114, v107, Il2CppMethodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv115 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>;\n\tv118 = *([v115 @ X0_v5 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]) & 1;\n\tv119 = v118 == 0;\n\tif (v119) goto L_0070;\n\tv121 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv124 = *([v121 @ X0_v25 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv125 = v124 == 0;\n\tv141 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tif (v125) goto L_0079;\nL_0057:\n\tv133.<>9 = v107;\n\tv134 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>;\n\tv137 = *([v134 @ X0_v24 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]) & 1;\n\tv138 = v137 == 0;\n\tv161 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>;\n\tif (v138) goto L_0083;\nL_005F:\n\tv154 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv157 = *([v154 @ X0_v22 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv158 = v157 == 0;\n\tv184 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tif (v158) goto L_008C;\nL_006F:\n\treturn;\nL_0070:\n\tv126 = 0x220C238(Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv143 = *([v126 @ X0_v16+C0]);\n\tv141 = *([v143 @ X8_v16+10]);\n\tv145 = *([v141 @ X0_v13 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv146 = v145 == 0;\n\tv128 = ~v146;\n\tif (v128) goto L_0057;\nL_0079:\n\tv142 = 0x220C238(v141, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv163 = *([v142 @ X0_v14+B8]);\n\t*([v163 @ X8_v13]) = v107;\n\tv152 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>;\n\tv165 = *([v152 @ X0_v15 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]) & 1;\n\tv166 = v165 == 0;\n\tv148 = ~v166;\n\tv161 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>;\n\tif (v148) goto L_005F;\nL_0083:\n\tv162 = 0x220C238(v161, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv186 = *([v162 @ X0_v11+C0]);\n\tv184 = *([v186 @ X8_v9+10]);\n\tv188 = *([v184 @ X0_v6 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv189 = v188 == 0;\n\tv168 = ~v189;\n\tif (v168) goto L_006F;\nL_008C:\n\tv185 = 0x220C238(v184, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			static _003C_003Ec()
			{
				//IL_019d: Expected O, but got I
				//IL_01a5: Expected I, but got O
				//IL_0099: Expected O, but got I
				//IL_0277: Expected O, but got I
				//IL_02b0: Expected O, but got I
				//IL_0118: Expected O, but got I
				//IL_0128: Expected O, but got I
				//IL_021a: Expected O, but got I
				//IL_040b: Expected O, but got I
				//IL_04e9: Expected O, but got I
				//IL_0478: Expected O, but got I
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X0_v1 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X0_v42 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]");
					int num3 = (int)((nint)0 & (nint)1);
					bool flag = num3 == 0;
					nint num4 = 0;
					nint num5 = 0;
					if (!flag)
					{
						goto IL_007e;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ X0_v34+C0]");
					object obj = 0;
					nint num4 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X0_v39 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]");
					int num6 = (int)((nint)0 & (nint)1);
					bool flag2 = num6 == 0;
					bool flag3 = !flag2;
					nint num5 = num4;
					if (flag3)
					{
						goto IL_007e;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				_003C_003Ec _003C_003Ec2 = null;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X0_v33 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X0_v33 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]");
				int num8 = (int)((nint)0 & (nint)1);
				bool flag4 = num8 == 0;
				_003C_003Ec _003C_003Ec3 = _003C_003Ec2;
				nint num9 = 0;
				_003C_003Ec _003C_003Ec4 = _003C_003Ec2;
				nint num10 = 0;
				if (flag4)
				{
					goto IL_00f3;
				}
				goto IL_0269;
				IL_04ca:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X0_v11+C0]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ X8_v9+10]");
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X0_v6 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					return;
				}
				goto IL_0537;
				IL_03ac:
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X0_v22 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]");
				int num13 = (int)((nint)0 & (nint)1);
				bool flag5 = num13 == 0;
				num11 = 0;
				if (!flag5)
				{
					return;
				}
				goto IL_0537;
				IL_0537:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				return;
				IL_007e:
				_003C_003Ec _003C_003Ec5 = null;
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v41 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]");
				obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v41 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]");
				int num15 = (int)((nint)0 & (nint)1);
				bool flag6 = num15 == 0;
				bool flag7 = !flag6;
				_003C_003Ec3 = _003C_003Ec5;
				num9 = 0;
				_003C_003Ec4 = _003C_003Ec5;
				num10 = 0;
				if (!flag7)
				{
					goto IL_00f3;
				}
				goto IL_0269;
				IL_0269:
				nint num16 = 0;
				object obj4 = num16;
				int num17 = (int)((nint)obj2 & 1);
				bool flag8 = num17 == 0;
				bool flag9 = !flag8;
				_003C_003Ec3 = _003C_003Ec4;
				object obj5 = num16;
				if (!flag9)
				{
					goto IL_02be;
				}
				goto IL_02e2;
				IL_00f3:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X0_v37+C0]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ X8_v43+8]");
				object obj7 = 0;
				obj4 = obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X0_v38 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]");
				int num19 = (int)((nint)0 & (nint)1);
				bool flag10 = num19 == 0;
				num10 = 0;
				if (flag10)
				{
					goto IL_02be;
				}
				obj5 = obj7;
				_003C_003Ec4 = _003C_003Ec3;
				goto IL_02e2;
				IL_02be:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				obj5 = obj4;
				_003C_003Ec4 = _003C_003Ec3;
				goto IL_02e2;
				IL_0364:
				_003C_003E9 = _003C_003Ec4;
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X0_v24 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]");
				int num21 = (int)((nint)0 & (nint)1);
				bool flag11 = num21 == 0;
				nint num22 = 0;
				if (!flag11)
				{
					goto IL_03ac;
				}
				goto IL_04ca;
				IL_02e2:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v105 @ X21_v1 (should have been resolved before IL gen)");
				nint num23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X0_v5 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num24 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X0_v25 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]");
					int num25 = (int)((nint)0 & (nint)1);
					bool flag12 = num25 == 0;
					nint num26 = 0;
					if (!flag12)
					{
						goto IL_0364;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X0_v16+C0]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ X8_v16+10]");
					nint num26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X0_v13 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]");
					if ((uint)((nuint)0u & (nuint)1u) != 0)
					{
						goto IL_0364;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v14+B8]");
				object obj9 = 0;
				obj9 = _003C_003Ec4;
				nint num27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X0_v15 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1+<>c>)+135]");
				int num28 = (int)((nint)0 & (nint)1);
				bool flag13 = num28 == 0;
				bool flag14 = !flag13;
				num22 = 0;
				if (flag14)
				{
					goto IL_03ac;
				}
				goto IL_04ca;
			}

			[Token(Token = "0x6000059")]
			[Address(RVA = "0x4F9C27C", Offset = "0x4F9C27C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal float _003COnBeforeSerialize_003Eb__3_0(WeightedView v)
			{
				WeightedView weightedView = v;
				float weight = weightedView.Weight;
				float result = default(float);
				return result;
			}

			internal float _003COnAfterDeserialize_003Eb__4_0(WeightedView v)
			{
				WeightedView weightedView = v;
				float weight = weightedView.Weight;
				float result = default(float);
				return result;
			}
		}

		[SerializeField]
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x0")]
		private WeightedView[] m_views;

		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x0")]
		private float _totalWeight;

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x5FA93A4", Offset = "0x5FA93A4", Length = "0x394")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv45 = *([A4731E0]);\n\tv50 = Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>;\n\tv54 = *([v50 @ X8_v6 (Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>)+FC]) + 0xF;\n\tv55 = v54 & 0x1FFFFFFF0;\n\t// 35 StackAlloc v702 @ X19_v8 (System.Byte*), v55 @ X9_v2 (System.Int32)\n\t// 38 StackAlloc v59 @ X20_v1 (System.Byte*), v55 @ X9_v2 (System.Int32)\n\t// 41 StackAlloc v62 @ X21_v1 (System.Byte*), v55 @ X9_v2 (System.Int32)\n\t// 44 StackAlloc v65 @ X22_v1 (System.Byte*), v55 @ X9_v2 (System.Int32)\n\tv68 = 0;\n\tv699 = UnityEngine.Random::get_value();\n\tv302 = this.m_views;\n\tv72 = this.m_views == 0;\n\tif (v72) goto L_00C8;\n\tv74 = v302.Length == 0;\n\tif (v74) goto L_00C8;\n\tv120 = v302.Length < 1;\n\tv314 = rotation;\n\tif (v120) goto L_007D;\n\tv271 = v699 * this._totalWeight;\n\tv272 = this.m_views + 0x20;\n\tv424 = 0;\n\tv467 = 0;\n\tv307 = ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>::get_Weight(&v309 @ stack_-E0_v11 (ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>));\n\tv424 = v424 + v699;\n\tv467 = v467 + 1;\n\tv283 = v467 < v302.Length;\n\tif (v283) goto L_004C;\n\tv302 = this.m_views;\n\tv314 = rotation;\nL_007D:\n\tv496 = v302.Length << 0x20;\n\tv497 = 0xFFFFFFFF00000000 + v496;\n\tv419 = v497 >> 0x1C;\n\tv461 = v302 + v419;\n\tv501 = v461 + 0x20;\n\tv502 = ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>::get_ViewProvider(v501);\n\tv506 = 0x8BF6A1C(v702, frontRight, *([v50 @ X8_v6 (Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv522 = 0x8BF6A1C(v59, frontLeft, *([v50 @ X8_v6 (Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv530 = 0x8BF6A1C(v62, rearLeft, *([v50 @ X8_v6 (Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv453 = 0x8BF6A1C(v65, rearRight, *([v50 @ X8_v6 (Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv583 = Il2CppClass<ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>>;\n\tgoto L_00A7;\n\tv679 = *([v704 @ X8_v25 (Il2CppClass<ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>>)+B0]) + 8;\n\tv679 = v679 + 0x10;\n\tv624 = v645 - 1;\n\tv591 = v645 != 1;\n\tv645 = v624;\n\tif (v591) goto L_00AD;\n\tv577 = v314;\n\tv205 = v502;\n\tgoto L_0138;\nL_00C8:\n\tv79 = Il2CppMethodInfo;\n\t*([v79 @ X1_v6 (Il2CppMethodInfo)+10])(v258, *([v79 @ X1_v6 (Il2CppMethodInfo)]), Il2CppMethodInfo, 0, 0, &v83 @ stack_-B0_v5 (Unco.OptionalValueSystem.Optional`1<ConnectedVoxelSystem.Runtime.VertexView`1<T>>), rearRight, methodInfo, v87, v699, v685, v89, v90, v91, v92, v93, v94);\n\tv98 = *([A4731E0]);\n\tv109 = *([v98 @ X9_v8]) != *([v45 @ X8_v2]);\n\tv192 = v83;\n\tv257 = v83;\n\tif (v109) goto L_015A;\nL_00F1:\n\treturn v192;\nL_00F5:\n\tv514 = ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>::get_ViewProvider(&v309 @ stack_-E0_v11 (ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>));\n\tv518 = 0x8BF6A1C(v702, frontRight, *([v50 @ X8_v6 (Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv526 = 0x8BF6A1C(v59, frontLeft, *([v50 @ X8_v6 (Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv534 = 0x8BF6A1C(v62, rearLeft, *([v50 @ X8_v6 (Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv454 = 0x8BF6A1C(v65, rearRight, *([v50 @ X8_v6 (Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv583 = Il2CppClass<ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>>;\n\tgoto L_0118;\n\tv679 = *([v704 @ X8_v25 (Il2CppClass<ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>>)+B0]) + 8;\n\tv679 = v679 + 0x10;\n\tv623 = v666 - 1;\n\tv590 = v666 != 1;\n\tv577 = rotation;\n\tv205 = v514;\n\tv666 = v623;\n\tif (v590) goto L_011E;\nL_0138:\n\tv723 = 0x220C5E0(v205, v583, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_013F;\nL_013B:\n\tv709 = *([v679 @ X10_v6]) << 4;\n\tv710 = v704 + v709;\n\tv723 = v710 + 0x138;\nL_015A:\n\tv266 = 0x8BF5CF0(v258, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v257, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv469 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\nL_004C:\n\tv309 = *([v272 @ X19_v11+v467 @ X28_v12 (System.Int32)*16]);\n\tv489 = ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>::get_Weight(&v309 @ stack_-E0_v11 (ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>));\n\tv699 = v424 + *([v272 @ X19_v11+v467 @ X28_v12 (System.Int32)*16]);\n\tv440 = v271 == v699;\n\tv492 = v271 < v699;\n\tv446 = ~v492;\n\tv494 = ~v446;\n\tv430 = v494 | v440;\n\tif (v430) goto L_00F5;\nL_00A7:\n\tv704 = *([v502 @ X0_v22 (ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>)]);\n\tv645 = *([v704 @ X8_v25 (Il2CppClass<ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>>)+12E]);\n\tv562 = *([v704 @ X8_v25 (Il2CppClass<ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>>)+12E]) == 0;\n\tv577 = v314;\n\tv205 = v502;\n\tif (v562) goto L_0138;\nL_00AD:\n\t;\n\tv650 = *([v679 @ X10_v6-8]) == v583;\n\tv577 = v314;\n\tv205 = v502;\n\tif (v650) goto L_013B;\nL_0118:\n\tv704 = *([v514 @ X0_v38 (ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>)]);\n\tv666 = *([v704 @ X8_v25 (Il2CppClass<ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>>)+12E]);\n\tv571 = *([v704 @ X8_v25 (Il2CppClass<ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>>)+12E]) == 0;\n\tv577 = rotation;\n\tv205 = v514;\n\tif (v571) goto L_0138;\nL_011E:\n\t;\n\tv671 = *([v679 @ X10_v6-8]) == v583;\n\tv577 = rotation;\n\tv205 = v514;\n\tif (v671) goto L_013B;\nL_013F:\n\tv83 = &v577 @ stack_-C4_v7 (ConnectedVoxelSystem.Runtime.VertexRotation);\n\tv135 = v702;\n\tv132 = v59;\n\tv129 = v62;\n\tv126 = v65;\n\tv157 = *([v723 @ X0_v12+8]);\n\t*([v157 @ X1_v8 (Il2CppMethodInfo)+10])(v258, *([v157 @ X1_v8 (Il2CppMethodInfo)+8]), *([v723 @ X0_v12+8]), v205, &v83 @ stack_-B0_v5 (Unco.OptionalValueSystem.Optional`1<ConnectedVoxelSystem.Runtime.VertexView`1<T>>), &v123 @ stack_-C0_v5 (Unco.OptionalValueSystem.Optional`1<ConnectedVoxelSystem.Runtime.VertexView`1<T>>), rearRight, methodInfo, v87, v699, this._totalWeight, v89, v90, v91, v92, v93, v94);\n\tv730 = *([A4731E0]);\n\tv181 = *([v730 @ X9_v12]) == *([v45 @ X8_v2]);\n\tv192 = v123;\n\tv257 = v123;\n\tif (v181) goto L_00F1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe Optional<VertexView<T>> Evaluate(VertexRotation rotation, Voxel<T> frontRight, Voxel<T> frontLeft, Voxel<T> rearLeft, Voxel<T> rearRight)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RandomVertexViewProvider::Evaluate");
			return default;
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x5FA9738", Offset = "0x5FA9738", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv28 = *([v25 @ X0_v1 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv29 = v28 == 0;\n\tif (v29) goto L_0026;\n\tgoto L_001A;\nL_001A:\n\tv54 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv57 = *([v54 @ X0_v39 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv58 = v57 == 0;\nL_FFFFFFFF:\n\tv68 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\nL_FFFFFFFF:\n\tv78 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tif (v58) goto L_0035;\nL_0020:\n\tv72 = *([v68 @ X0_v37 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+B8]);\n\tv93 = *([v72 @ X9_v22 (Il2CppStaticFields<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+8]);\n\tv74 = *([v72 @ X9_v22 (Il2CppStaticFields<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+8]) == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0081;\n\tgoto L_003D;\nL_0026:\n\tv32 = System.Func`2<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>, System.Single>::.ctor(Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>, methodInfo, v33);\n\tv63 = *([v32 @ X0_v36 (System.Func`2<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>, System.Single>)+E4]) == 0;\n\tv48 = ~v63;\n\tif (v48) goto L_001A;\n\tv69 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv83 = *([v69 @ X0_v35 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv84 = v83 == 0;\n\tv67 = ~v84;\nL_FFFFFFFF:\n\tv68 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\nL_FFFFFFFF:\n\tv78 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tif (v67) goto L_0020;\nL_0035:\n\tv80 = 0x220C238(v78, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv98 = *([v80 @ X0_v32+B8]);\n\tv93 = *([v98 @ X9_v17+8]);\n\tv121 = *([v98 @ X9_v17+8]) == 0;\n\tv101 = ~v121;\n\tif (v101) goto L_0081;\nL_003D:\n\tv128 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv131 = *([v128 @ X0_v6 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv132 = v131 == 0;\n\tif (v132) goto L_008D;\n\tgoto L_0048;\nL_0048:\n\tv143 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv146 = *([v143 @ X0_v30 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv147 = v146 == 0;\nL_FFFFFFFF:\n\tv171 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tif (v147) goto L_009C;\nL_004F:\n\tv92 = v161.<>9;\nL_FFFFFFFF:\n\tv191 = Il2CppClass<System.Func`2<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>, System.Single>>;\n\tgoto L_0058;\nL_0058:\n\tv193 = new v191();\n\tv202 = System.Func`2<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>, System.Single>::.ctor(v193, v92, Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv212 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tgoto L_006D;\nL_FFFFFFFF:\n\tv93 = v193;\nL_008D:\n\tv135 = 0x220C238(Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv152 = *([v135 @ X0_v13+E4]) == 0;\n\tv137 = ~v152;\n\tif (v137) goto L_0048;\n\tv158 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv176 = *([v158 @ X0_v12 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv177 = v176 == 0;\n\tv156 = ~v177;\nL_FFFFFFFF:\n\tv171 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tif (v156) goto L_004F;\nL_009C:\n\tv173 = 0x220C238(v171, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv181 = *([v173 @ X0_v8+B8]);\n\tv92 = *([v181 @ X9_v4]);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv191 = Il2CppClass<System.Func`2<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>, System.Single>>;\n\tgoto L_0058;\nL_0081:\n\tv112 = System.Linq.Enumerable::Sum(this.m_views, v93);\n\tthis._totalWeight = v39;\n\treturn;\nL_006D:\n\tv97 = *([v212 @ X0_v18 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+B8]);\n\t*([v97 @ X9_v10 (Il2CppStaticFields<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+8]) = v193;\n\tgoto L_FFFFFFFF;\n")]
		public void OnBeforeSerialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RandomVertexViewProvider::OnBeforeSerialize");
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x5FA9920", Offset = "0x5FA9920", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv28 = *([v25 @ X0_v1 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv29 = v28 == 0;\n\tif (v29) goto L_0026;\n\tgoto L_001A;\nL_001A:\n\tv54 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv57 = *([v54 @ X0_v39 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv58 = v57 == 0;\nL_FFFFFFFF:\n\tv68 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\nL_FFFFFFFF:\n\tv78 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tif (v58) goto L_0035;\nL_0020:\n\tv72 = *([v68 @ X0_v37 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+B8]);\n\tv93 = *([v72 @ X9_v23 (Il2CppStaticFields<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+10]);\n\tv74 = *([v72 @ X9_v23 (Il2CppStaticFields<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+10]) == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0081;\n\tgoto L_003D;\nL_0026:\n\tv32 = System.Func`2<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>, System.Single>::.ctor(Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>, methodInfo, v33);\n\tv63 = *([v32 @ X0_v36 (System.Func`2<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>, System.Single>)+E4]) == 0;\n\tv48 = ~v63;\n\tif (v48) goto L_001A;\n\tv69 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv83 = *([v69 @ X0_v35 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv84 = v83 == 0;\n\tv67 = ~v84;\nL_FFFFFFFF:\n\tv68 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\nL_FFFFFFFF:\n\tv78 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tif (v67) goto L_0020;\nL_0035:\n\tv80 = 0x220C238(v78, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv98 = *([v80 @ X0_v32+B8]);\n\tv93 = *([v98 @ X9_v18+10]);\n\tv121 = *([v98 @ X9_v18+10]) == 0;\n\tv101 = ~v121;\n\tif (v101) goto L_0081;\nL_003D:\n\tv128 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv131 = *([v128 @ X0_v6 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv132 = v131 == 0;\n\tif (v132) goto L_008D;\n\tgoto L_0048;\nL_0048:\n\tv143 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv146 = *([v143 @ X0_v30 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv147 = v146 == 0;\nL_FFFFFFFF:\n\tv171 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tif (v147) goto L_009C;\nL_004F:\n\tv92 = v161.<>9;\nL_FFFFFFFF:\n\tv191 = Il2CppClass<System.Func`2<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>, System.Single>>;\n\tgoto L_0058;\nL_0058:\n\tv193 = new v191();\n\tv202 = System.Func`2<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>, System.Single>::.ctor(v193, v92, Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv212 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tgoto L_006D;\nL_FFFFFFFF:\n\tv93 = v193;\nL_008D:\n\tv135 = 0x220C238(Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv152 = *([v135 @ X0_v13+E4]) == 0;\n\tv137 = ~v152;\n\tif (v137) goto L_0048;\n\tv158 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tv176 = *([v158 @ X0_v12 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+135]) & 1;\n\tv177 = v176 == 0;\n\tv156 = ~v177;\nL_FFFFFFFF:\n\tv171 = Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>;\n\tif (v156) goto L_004F;\nL_009C:\n\tv173 = 0x220C238(v171, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv181 = *([v173 @ X0_v8+B8]);\n\tv92 = *([v181 @ X9_v4]);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv191 = Il2CppClass<System.Func`2<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+WeightedView<T>, System.Single>>;\n\tgoto L_0058;\nL_0081:\n\tv112 = System.Linq.Enumerable::Sum(this.m_views, v93);\n\tthis._totalWeight = v39;\n\treturn;\nL_006D:\n\tv97 = *([v212 @ X0_v18 (Il2CppClass<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+B8]);\n\t*([v97 @ X9_v11 (Il2CppStaticFields<ConnectedVoxelSystem.Runtime.ViewProviders.RandomVertexViewProvider`1<T>+<>c<T>>)+10]) = v193;\n\tgoto L_FFFFFFFF;\n")]
		public void OnAfterDeserialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RandomVertexViewProvider::OnAfterDeserialize");
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x5FA9B0C", Offset = "0x5FA9B0C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public RandomVertexViewProvider()
		{
		}
	}
}
