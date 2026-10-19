using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.OptionalValueSystem;
using UnityEngine;

namespace ConnectedVoxelSystem.Runtime.ViewProviders
{
	[Serializable]
	[Token(Token = "0x2000013")]
	public class RotationVertexViewProvider<T> : IVertexMeshProvider<T> where T : struct
	{
		[Serializable]
		[Token(Token = "0x2000014")]
		private struct RotationViewPair
		{
			[SerializeField]
			[Token(Token = "0x4000033")]
			[FieldOffset(Offset = "0x0")]
			private VertexRotation m_rotation;

			[SerializeReference]
			[Token(Token = "0x4000034")]
			[FieldOffset(Offset = "0x0")]
			private IVertexMeshProvider<T> m_viewProvider;

			[Token(Token = "0x17000012")]
			public VertexRotation Rotation
			{
				[Token(Token = "0x600005E")]
				[Address(RVA = "0x6245598", Offset = "0x6245598", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Rotation;\n")]
				get
				{
					return m_rotation;
				}
			}

			[Token(Token = "0x17000013")]
			public IVertexMeshProvider<T> ViewProvider
			{
				[Token(Token = "0x600005F")]
				[Address(RVA = "0x62455A0", Offset = "0x62455A0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ViewProvider;\n")]
				get
				{
					return m_viewProvider;
				}
			}
		}

		[SerializeField]
		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x0")]
		private RotationViewPair[] m_colorPatternViewList;

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x6245334", Offset = "0x6245334", Length = "0x25C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv27 = *([A4731E0]);\n\tv33 = Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>;\n\tv37 = *([v33 @ X9_v1 (Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>)+FC]) + 0xF;\n\tv38 = v37 & 0x1FFFFFFF0;\n\t// 26 StackAlloc v39 @ X19_v1 (System.Byte*), v38 @ X10_v2 (System.Int32)\n\t// 29 StackAlloc v42 @ X20_v1 (System.Byte*), v38 @ X10_v2 (System.Int32)\n\t// 32 StackAlloc v45 @ X21_v1 (System.Byte*), v38 @ X10_v2 (System.Int32)\n\t// 35 StackAlloc v48 @ X22_v1 (System.Byte*), v38 @ X10_v2 (System.Int32)\n\tv51 = 0;\n\tv52 = this.m_colorPatternViewList;\n\tv66 = v52.Length < 1;\n\tif (v66) goto L_0061;\n\tv117 = v52 + 0x20;\n\tv120 = 0;\n\tv120 = v120 + 1;\n\tv220 = v120 < v52.Length;\n\tif (v220) goto L_0040;\nL_0087:\n\treturn returnVal2;\nL_008D:\n\tv412 = ConnectedVoxelSystem.Runtime.ViewProviders.RotationVertexViewProvider`1<T>+RotationViewPair<T>::get_ViewProvider(&v186 @ stack_-C0_v7 (ConnectedVoxelSystem.Runtime.ViewProviders.RotationVertexViewProvider`1<T>+RotationViewPair<T>));\n\tv416 = 0x8BF6A1C(v39, frontRight, *([v33 @ X9_v1 (Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv421 = 0x8BF6A1C(v42, frontLeft, *([v33 @ X9_v1 (Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv425 = 0x8BF6A1C(v45, rearLeft, *([v33 @ X9_v1 (Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv110 = 0x8BF6A1C(v48, rearRight, *([v33 @ X9_v1 (Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00AD;\n\tv481 = *([v440 @ X8_v23 (Il2CppClass<ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>>)+B0]) + 8;\n\tv481 = v481 + 0x10;\n\tv467 = v482 - 1;\n\tv447 = v482 != 1;\n\tv482 = v467;\n\tif (v447) goto L_00B4;\nL_00CE:\n\tv498 = 0x220C5E0(v412, Il2CppClass<ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00D5;\nL_00D1:\n\tv494 = *([v481 @ X10_v10]) << 4;\n\tv495 = v440 + v494;\n\tv498 = v495 + 0x138;\nL_00F1:\n\tv109 = 0x8BF5CF0(v360, v112, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0061:\n\tv240 = Il2CppMethodInfo;\n\t*([v240 @ X1_v3 (Il2CppMethodInfo)+10])(v247, *([v240 @ X1_v3 (Il2CppMethodInfo)]), Il2CppMethodInfo, 0, 0, &v244 @ stack_-90_v2 (Unco.OptionalValueSystem.Optional`1<ConnectedVoxelSystem.Runtime.VertexView`1<T>>), rearRight, methodInfo, v196, *([v117 @ X27_v6+v120 @ X26_v7 (System.Int32)*16]), v197, v198, v199, v200, v201, v202, v203);\n\tv252 = *([A4731E0]);\n\tv263 = *([v252 @ X9_v9]) != *([v27 @ X8_v2]);\n\treturnVal2 = v244;\n\tv360 = v244;\n\tv112 = v81;\n\tif (v263) goto L_00F1;\nL_0040:\n\tv186 = *([v117 @ X27_v6+v120 @ X26_v7 (System.Int32)*16]);\n\tv207 = ConnectedVoxelSystem.Runtime.ViewProviders.RotationVertexViewProvider`1<T>+RotationViewPair<T>::get_Rotation(&v186 @ stack_-C0_v7 (ConnectedVoxelSystem.Runtime.ViewProviders.RotationVertexViewProvider`1<T>+RotationViewPair<T>));\n\tv165 = v207 == rotation;\n\tif (v165) goto L_008D;\nL_00AD:\n\tv296 = rotation;\n\tv440 = *([v412 @ X0_v14 (ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>)]);\n\tv482 = *([v440 @ X8_v23 (Il2CppClass<ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>>)+12E]);\n\tv339 = *([v440 @ X8_v23 (Il2CppClass<ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>>)+12E]) == 0;\n\tif (v339) goto L_00CE;\nL_00B4:\n\t;\n\tv487 = *([v481 @ X10_v10-8]) == Il2CppClass<ConnectedVoxelSystem.Runtime.IVertexMeshProvider`1<T>>;\n\tif (v487) goto L_00D1;\nL_00D5:\n\tv244 = &v296 @ stack_-A4_v4 (ConnectedVoxelSystem.Runtime.VertexRotation);\n\tv510 = *([v498 @ X0_v24+8]);\n\t*([v510 @ X1_v16+10])(v513, *([v510 @ X1_v16+8]), *([v498 @ X0_v24+8]), v412, &v244 @ stack_-90_v2 (Unco.OptionalValueSystem.Optional`1<ConnectedVoxelSystem.Runtime.VertexView`1<T>>), &v284 @ stack_-A0_v4 (Unco.OptionalValueSystem.Optional`1<ConnectedVoxelSystem.Runtime.VertexView`1<T>>), rearRight, methodInfo, v196, *([v117 @ X27_v6+v120 @ X26_v7 (System.Int32)*16]), v197, v198, v199, v200, v201, v202, v203);\n\tv516 = *([A4731E0]);\n\tv331 = *([v516 @ X9_v16]) == *([v27 @ X8_v2]);\n\treturnVal2 = v284;\n\tv360 = v284;\n\tv112 = v514;\n\tif (v331) goto L_0087;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe Optional<VertexView<T>> Evaluate(VertexRotation rotation, Voxel<T> frontRight, Voxel<T> frontLeft, Voxel<T> rearLeft, Voxel<T> rearRight)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RotationVertexViewProvider::Evaluate");
			return default;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x6245590", Offset = "0x6245590", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public RotationVertexViewProvider()
		{
		}
	}
}
