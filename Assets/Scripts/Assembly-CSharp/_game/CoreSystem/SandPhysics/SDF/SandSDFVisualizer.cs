using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.SandPhysics.SDF
{
	[ExecuteAlways]
	[Token(Token = "0x2000113")]
	public class SandSDFVisualizer : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400038B")]
		[FieldOffset(Offset = "0x20")]
		private bool m_showFilledCells;

		[SerializeField]
		[Token(Token = "0x400038C")]
		[FieldOffset(Offset = "0x21")]
		private bool m_showZeroIsoline;

		[SerializeField]
		[Token(Token = "0x400038D")]
		[FieldOffset(Offset = "0x22")]
		private bool m_showGradient;

		[SerializeField]
		[Token(Token = "0x400038E")]
		[FieldOffset(Offset = "0x24")]
		private Color m_insideColor;

		[SerializeField]
		[Token(Token = "0x400038F")]
		[FieldOffset(Offset = "0x34")]
		private Color m_outsideColor;

		[SerializeField]
		[Token(Token = "0x4000390")]
		[FieldOffset(Offset = "0x44")]
		private Color m_isolineColor;

		[SerializeField]
		[Token(Token = "0x4000391")]
		[FieldOffset(Offset = "0x54")]
		private Color m_gradientColor;

		[SerializeField]
		[Token(Token = "0x4000392")]
		[FieldOffset(Offset = "0x64")]
		private int m_cellStride;

		[SerializeField]
		[Token(Token = "0x4000393")]
		[FieldOffset(Offset = "0x68")]
		private int m_maxGizmoCells;

		[Token(Token = "0x60005CB")]
		[Address(RVA = "0x3DAE924", Offset = "0x3DAE924", Length = "0xB98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tgoto L_0023;\nL_0023:\n\tv78 = UnityEngine.Application::get_isPlaying();\n\tv85 = ~v78;\n\tv86 = ~v85;\n\tif (v86) goto L_003E;\n\tgoto L_056E;\nL_003E:\n\tgoto L_0046;\n\tv349 = v361.SDF;\n\tv356 = v361.SDF == 0;\n\tif (v356) goto L_056E;\n\tv296 = v349._sdf.IsBuilt != 1;\n\tif (v296) goto L_056E;\n\tv627 = v349._sdf.gridHeight * v349._sdf.gridWidth;\n\tv631 = this.m_cellStride * this.m_cellStride;\n\tv632 = v627 / v631;\n\tv644 = v632 <= this.m_maxGizmoCells;\nL_FFFFFFFF:\n\tv283 = this.m_cellStride;\n\tif (v644) goto L_00A4;\n\tv647 = v627 / this.m_maxGizmoCells;\n\tv649 = 0x3DAD6F8(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v647, this.m_maxGizmoCells, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv679 = 0x3DAE12C(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv816 = v647 - 1;\n\tv817 = v816 < 0;\n\tv818 = v816 == 0;\n\tv819 = v647 ^ 1;\n\tv667 = v647 ^ v816;\n\tv665 = v819 & v667;\n\tv820 = v665 < 0;\n\tv821 = v817 == v820;\n\tv653 = ~v818;\n\tv822 = v821 & v653;\n\tv823 = ~v822;\n\tif (v823) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv681 = v647;\n\tgoto L_008B;\nL_FFFFFFFF:\n\tv681 = 1;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv681 = 1;\n\tv765 = v349._sdf.gridHeight;\n\tv705 = v349._sdf.gridHeight < 1;\n\tif (v705) goto L_01DA;\n\tv758 = v361.<Params>k__BackingField.ParticleRadius * 4f;\n\tv826 = v361.<Params>k__BackingField.ParticleRadius < 0;\n\tv827 = v361.<Params>k__BackingField.ParticleRadius == 0;\n\tv830 = v361.<Params>k__BackingField.ParticleRadius == v361.<Params>k__BackingField.ParticleRadius;\n\tv831 = ~v830;\n\tv834 = v826 == v831;\n\tv755 = ~v827;\n\tv835 = v834 & v755;\n\tv754 = ~v835;\n\tif (v754) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv751 = v758;\n\tgoto L_00C8;\nL_FFFFFFFF:\n\tv751 = 0x3E23D70A;\n\tv747 = v349._sdf.cellSize * v283;\n\t// 221 NotImplemented \"Instruction BIF not yet implemented.\"\nL_FFFFFFFF:\n\tv1032 = 0;\n\tgoto L_0102;\nL_00EA:\n\tv765 = v349._sdf.gridHeight;\nL_0102:\n\tv1060 = v1422 < 1;\n\tif (v1060) goto L_00EC;\n\tv1188 = v1032 + 0.5f;\nL_FFFFFFFF:\n\tv1403 = 0;\nL_FFFFFFFF:\n\tv1529 = 0x38000000;\n\tgoto L_0123;\nL_FFFFFFFF:\n\tv1529 = 0;\nL_FFFFFFFF:\n\tv1582 = v1543;\n\tgoto L_0138;\nL_FFFFFFFF:\n\tv1582 = v1537;\nL_FFFFFFFF:\n\tv1631 = 0x34;\n\tgoto L_014D;\nL_FFFFFFFF:\n\tv1631 = 0x24;\nL_FFFFFFFF:\n\tv1410 = 0x38;\n\tgoto L_0157;\nL_FFFFFFFF:\n\tv1410 = 0x28;\nL_FFFFFFFF:\n\tv1206 = 0x3C;\n\tgoto L_015F;\nL_FFFFFFFF:\n\tv1206 = 0x2C;\nL_FFFFFFFF:\n\tv1199 = 0x40;\n\tgoto L_016B;\nL_FFFFFFFF:\n\tv1199 = 0x30;\n\tv1876 = v1937 < 1f;\n\tv1875 = v1937 == 1f;\n\tv1853 = v1937 == v1937;\n\tv1854 = 1f == 1f;\n\tv1855 = v1853 & v1854;\n\tv1874 = ~v1855;\n\tgoto L_0189;\nL_FFFFFFFF:\n\tv1874 = 0;\nL_FFFFFFFF:\n\tv1875 = 0;\nL_FFFFFFFF:\n\tv1876 = 0;\n\tgoto L_0192;\nL_FFFFFFFF:\n\tv1937 = 1f;\nL_FFFFFFFF:\n\tv1937 = 0;\n\tgoto L_019F;\n\tv1962 = UnityEngine.Transform::get_position(v1813);\n\tv1989 = v1403 + 0.5f;\n\tv1990 = v1989 * v349._sdf.cellSize;\n\tv1204 = v349._sdf.origin + v1990;\n\tv1991 = v1188 * v349._sdf.cellSize;\n\tv1203 = v349._sdf.origin.y + v1991;\n\t// 445 MakeStruct v1191 @ AGG3DAEC50_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1204 @ V0_v76 (System.Single), v1203 @ V1_v70 (System.Single), v1962.z (System.Single)\n\t// 446 MakeStruct v1190 @ AGG3DAEC50_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v747 @ V8_v12 (System.Single), v747 @ V8_v12 (System.Single), 0\n\tUnityEngine.Gizmos::DrawCube(v1191, v1190);\n\tv1403 = v1403 + v283;\n\tv1422 = v349._sdf.gridWidth;\n\tv1209 = v1403 < v349._sdf.gridWidth;\n\tif (v1209) goto L_0108;\n\tgoto L_00EA;\nL_01DA:\n\tv812 = this.m_showZeroIsoline != 1;\n\tif (v812) goto L_03E2;\n\tv1252 = this.m_isolineColor.a;\n\t// 481 MakeStruct v491 @ AGG3DAEC84_0_v4 (UnityEngine.Color), typeof(UnityEngine.Color), this.m_isolineColor (UnityEngine.Color), this.m_isolineColor.g (System.Single), this.m_isolineColor.b (System.Single), this.m_isolineColor.a (System.Single)\n\tUnityEngine.Gizmos::set_color(v491);\n\tv880 = v349._sdf.gridHeight;\n\tv912 = v349._sdf.gridHeight - 1;\n\tv882 = v912 < 1;\n\tif (v882) goto L_03E2;\n\tv913 = v349._sdf.gridWidth;\n\t// 501 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 503 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 506 NotImplemented \"Instruction DUP not yet implemented.\"\nL_FFFFFFFF:\n\tv527 = 0;\n\tgoto L_0211;\nL_0202:\n\tv880 = v349._sdf.gridHeight;\nL_0211:\n\tv998 = v913 - 1;\n\tv539 = v527 + 1;\n\tv1009 = v998 < 1;\n\tif (v1009) goto L_0203;\n\tv1261 = v539 + 0.5f;\nL_FFFFFFFF:\n\tv524 = 1;\n\tgoto L_024F;\nL_0233:\n\tv913 = v349._sdf.gridWidth;\n\tv1264 = v349._sdf.gridWidth - 1;\n\tv1100 = v524 + 1;\n\tv1103 = v524 >= v1264;\nL_FFFFFFFF:\n\tv524 = v1100;\n\tif (v1103) goto L_0202;\nL_024F:\n\t// 591 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 592 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 595 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 599 NotImplemented \"Instruction CMEQ not yet implemented.\"\n\tv1295 = v1252 & 0x38;\n\tv1297 = v1295 + 0x38;\n\tv1298 = v1295 + this.m_isolineColor;\n\tv1299 = v1298 + this.m_isolineColor;\n\t// 608 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 609 NotImplemented \"Instruction BIF not yet implemented.\"\n\t// 610 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv1300 = v1261 & 0x80;\n\tv1077 = v1299 | v1300;\n\t// 616 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 617 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 619 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 623 NotImplemented \"Instruction CMEQ not yet implemented.\"\n\tv1306 = v1297 & 0x38;\n\tv1252 = v1306 + 0x38;\n\tv1309 = v1306 + this.m_isolineColor;\n\tv1310 = v1309 + this.m_isolineColor;\n\t// 629 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 630 NotImplemented \"Instruction BIF not yet implemented.\"\n\t// 631 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv1311 = v1300 & 0x80;\n\tv1312 = v1310 | v1311;\n\tv1313 = v1077 < 0;\n\tv1317 = v1077 == v1077;\n\tv1318 = ~v1317;\n\tv1319 = v1313 == v1318;\n\tv1323 = v1313 == v1318;\n\tv1324 = ~v1323;\n\tif (v1324) goto L_FFFFFFFF;\n\tv1517 = 2 + 1;\n\tgoto L_028A;\nL_FFFFFFFF:\n\tv1517 = 2;\nL_FFFFFFFF:\n\tv1569 = v1319;\n\tgoto L_0298;\nL_FFFFFFFF:\n\tv1569 = v1517;\nL_FFFFFFFF:\n\tv1616 = v1569;\n\tgoto L_02A8;\nL_FFFFFFFF:\n\tv1616 = v1570;\nL_FFFFFFFF:\n\tv616 = v1616;\n\tgoto L_02BB;\nL_FFFFFFFF:\n\tv616 = v1619;\n\tv1678 = v616 - 0xF;\n\tv1713 = v1678 == 0;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1713 = 1;\n\tv1725 = UnityEngine.Component::get_transform(this);\n\tv1771 = UnityEngine.Transform::get_position(v1725);\n\tv1814 = UnityEngine.Component::get_transform(this);\n\tv1883 = UnityEngine.Transform::get_position(v1814);\n\tv1815 = UnityEngine.Component::get_transform(this);\n\tv1913 = UnityEngine.Transform::get_position(v1815);\n\tv610 = UnityEngine.Component::get_transform(this);\n\tv1960 = UnityEngine.Transform::get_position(v610);\n\t// 779 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 782 NotImplemented \"Instruction TRN1 not yet implemented.\"\n\t// 785 NotImplemented \"Instruction FABD not yet implemented.\"\n\t// 786 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 787 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 791 NotImplemented \"Instruction BSL not yet implemented.\"\n\t// 792 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 793 NotImplemented \"Instruction BSL not yet implemented.\"\n\t// 794 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 795 NotImplemented \"Instruction CMHI not yet implemented.\"\n\t// 797 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\tv1974 = v1960 & 0xFFFFFFFFFFFFFFC0;\n\t// 800 NotImplemented \"Instruction BSL not yet implemented.\"\n\t// 801 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv1975 = ~v1960;\n\tv1976 = v1974 & v1975;\n\t// 804 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 805 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 806 NotImplemented \"Instruction UMOV not yet implemented.\"\n\tv1979 = v1616 & 1;\n\tv1981 = v1979 == 0;\n\t\n// ... truncated")]
		private void OnDrawGizmos()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandSDFVisualizer::OnDrawGizmos");
		}

		[Token(Token = "0x60005CC")]
		[Address(RVA = "0x3DAF4BC", Offset = "0x3DAF4BC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv27 = UnityEngine.Component::get_transform(this);\n\tv31 = UnityEngine.Transform::get_position(v27);\n\tv49 = ix + 0.5f;\n\tv50 = v49 * sdf.cellSize;\n\treturnVal1 = sdf.origin + v50;\n\treturn returnVal1;\n")]
		private Vector3 CellCenter(in SandSDFData sdf, int ix, int iy)
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			float num = (float)ix + 0.5f;
			float num2 = num * sdf.cellSize;
			float x = sdf.origin.x + num2;
			Vector3 result = default(Vector3);
			result.x = x;
			return result;
		}

		[Token(Token = "0x60005CD")]
		[Address(RVA = "0x3DAF530", Offset = "0x3DAF530", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = va - vb;\n\t// 5 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv9 = va / v6;\n\tv13 = vb < 0x358637BD;\n\tv22 = ~v13;\n\tif (v22) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv25 = 0.5f;\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv25 = v9;\nL_FFFFFFFF:\n\tv30 = 0.5f;\n\tgoto L_0023;\n\tv63 = v25 < 1f;\n\tv62 = v25 == 1f;\n\tv50 = v25 == v25;\n\tv51 = 1f == 1f;\n\tv52 = v50 & v51;\n\tv58 = ~v52;\n\tgoto L_003E;\nL_FFFFFFFF:\n\tv58 = 0;\nL_FFFFFFFF:\n\tv62 = 0;\nL_FFFFFFFF:\n\tv63 = 0;\nL_FFFFFFFF:\n\tv81 = v25;\n\tgoto L_0047;\nL_FFFFFFFF:\n\tv81 = 1f;\nL_FFFFFFFF:\n\tv81 = 0;\n\tgoto L_0054;\nL_FFFFFFFF:\n\tv96 = 1f;\n\tgoto L_0065;\nL_FFFFFFFF:\n\tv96 = v81;\nL_0019:\n\tv30 = UnityEngine.Mathf::Abs(v9);\n\tv27 = ~v13;\n\tif (v27) goto L_0023;\nL_0023:\n\tv34 = v30 < 0x7F800001;\n\tv35 = ~v34;\n\tv44 = ~v35;\n\tv45 = ~v44;\n\tif (v45) goto L_FFFFFFFF;\nL_003E:\n\tv64 = v63 == v58;\n\tv65 = ~v64;\n\tv66 = v65 | v62;\n\tv67 = ~v66;\n\tif (v67) goto L_FFFFFFFF;\nL_0047:\n\tv71 = v81 < 0;\n\tv78 = ~v71;\n\tif (v78) goto L_0054;\nL_0054:\n\tv82 = v81 < 1f;\n\tv83 = v81 == 1f;\n\tv86 = v81 == v81;\n\tv87 = 1f == 1f;\n\tv88 = v86 & v87;\n\tv89 = ~v88;\n\tv90 = v82 == v89;\n\tv91 = ~v83;\n\tv92 = v90 & v91;\n\tv93 = ~v92;\n\tif (v93) goto L_FFFFFFFF;\nL_0065:\n\tv97 = b - a;\n\tv98 = v97 * v96;\n\treturnVal1 = a + v98;\n\treturn returnVal1;\n")]
		private static Vector3 LerpZero(Vector3 a, Vector3 b, float va, float vb)
		{
			float num = va - vb;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			float num2 = va / num;
			bool flag = vb < 1E-06f;
			float num3 = ((!flag) ? num2 : 0.5f);
			float num4 = Mathf.Abs(num2);
			if (flag)
			{
				num4 = 0.5f;
			}
			bool flag2;
			bool flag3;
			bool flag7;
			if (num4 < 0f / 0f)
			{
				flag2 = num3 < 1f;
				flag3 = num3 == 1f;
				bool flag4 = num3 == num3;
				bool flag5 = 1f == 1f;
				bool flag6 = flag4 && flag5;
				flag7 = !flag6;
			}
			else
			{
				flag7 = false;
				flag3 = false;
				flag2 = false;
			}
			bool flag8 = flag2 == flag7;
			bool flag9 = !flag8;
			float num5 = ((!(flag9 || flag3)) ? 1f : num3);
			if (num5 < 0f)
			{
				num5 = 0f;
			}
			bool flag10 = num5 < 1f;
			bool flag11 = num5 == 1f;
			bool flag12 = num5 == num5;
			bool flag13 = 1f == 1f;
			bool flag14 = flag12 && flag13;
			bool flag15 = !flag14;
			bool flag16 = flag10 == flag15;
			bool flag17 = !flag11;
			float num6 = ((!(flag16 && flag17)) ? num5 : 1f);
			float num7 = b.x - a.x;
			float num8 = num7 * num6;
			float x = a.x + num8;
			Vector3 result = default(Vector3);
			result.x = x;
			return result;
		}

		[Token(Token = "0x60005CE")]
		[Address(RVA = "0x3DAF5B4", Offset = "0x3DAF5B4", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_showFilledCells = 0x101;\n\tthis.m_insideColor = *([9308130]);\n\tthis.m_outsideColor = *([9308140]);\n\tthis.m_isolineColor = *([92A4640]);\n\tthis.m_gradientColor = *([9308150]);\n\tthis.m_cellStride = 1.06099789548264E-309d;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SandSDFVisualizer()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandSDFVisualizer::.ctor");
		}
	}
}
