using System;
using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1SpriteShader
{
	[Token(Token = "0x2000012")]
	public class DemoRepositionExpositor : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x20")]
		private float paddingX;

		[ContextMenu("RepositionExpositor")]
		[Token(Token = "0x6000047")]
		[Address(RVA = "0x3C2076C", Offset = "0x3C2076C", Length = "0x30C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv79 = UnityEngine.Transform::GetEnumerator(v74);\n\tv162 = v79 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v162) goto L_00CF;\nL_FFFFFFFF:\n\tv302 = 0;\nL_FFFFFFFF:\n\tv307 = v79;\n\tgoto L_00A1;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v248_asT @ TEMPCOND_v17 (UnityEngine.Transform), typeof(UnityEngine.Transform), v276 @ X0_v36 (System.Object)\n\tv248 = v248_asT == 0;\n\tif (v248) goto L_0117;\n\tv242 = this.paddingX * v302;\n\t// 200 MakeStruct v236 @ AGG3C2094C_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v242 @ V0_v8 (System.Single), v69.zero.y (System.Single), v69.zero.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v276, v236);\n\tv302 = v302 + 1;\n\tv679 = v146 == 0;\n\tv278 = ~v679;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv307 = v146;\n\tif (v278) goto L_0049;\nL_00CF:\n\tv283 = new System.NullReferenceException();\nL_FFFFFFFF:\n\t;\n\tgoto L_011C;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv207 = &v146 @ stack_-58_v5 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv142 = 0;\nL_FFFFFFFF:\n\tv464 = &v146 @ stack_-58_v5 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv465 = &v51 @ stack_-60_v1;\nL_FFFFFFFF:\n\tv224 = 0;\n\tgoto L_0106;\n\treturn;\nL_0117:\n\tv391 = new System.InvalidCastException();\n\tgoto L_011C;\nL_0119:\n\tv392 = new System.NullReferenceException();\nL_FFFFFFFF:\n\t;\n\tgoto L_011C;\nL_011C:\n\t// 284 Interrupt\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv207 = &v146 @ stack_-58_v5 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv142 = 0;\nL_011F:\n\tv226 = new System.OutOfMemoryException();\n\tgoto L_012E;\nL_012E:\n\tv321 = v214 != 1;\n\tif (v321) goto L_0139;\n\tv399 = 0x8BF5BC4(v226, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv224 = *([v399 @ X0_v23]);\n\tv426 = 0x8BF5BF4(v399, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv142 = *([v399 @ X0_v23]);\nL_FFFFFFFF:\n\tv464 = v207;\n\tgoto L_00D8;\nL_0139:\n\tv402 = 0x3173D6C(&v142 @ stack_-78_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv428 = 0x8BF0368(v226, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv442 = 0xA1B8(v428, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_001E:\n\tv51 = 0;\n\tgoto L_0032;\n\tthrow System.NullReferenceException;\nL_006F:\n\tv437 = System.Collections.IEnumerator::MoveNext(v307);\n\tv439 = v437 == 0;\n\tif (v439) goto L_FFFFFFFF;\nL_00A1:\n\tv276 = System.Collections.IEnumerator::get_Current(v146);\n\tv394 = v276 == 0;\n\tif (v394) goto L_0119;\nL_0049:\n\tgoto L_006F;\nL_0108:\n\tv573 = v224 == 0;\n\tv218 = ~v573;\n\tif (v218) goto L_011F;\nL_0106:\n\tv214 = 0;\n\tv569 = System.IDisposable::Dispose(0);\nL_00D8:\n\tv469 = 0x21C11D0(*([v464 @ X8_v7]), System.IDisposable, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v465 @ X20_v3]) = v469;\n\tv474 = v469 == 0;\nL_FFFFFFFF:\n\tv214 = System.IDisposable;\n\tif (v474) goto L_0108;\nL_0032:\n\tv74 = UnityEngine.Component::get_transform(this);\n")]
		private void RepositionExpositor()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DemoRepositionExpositor::RepositionExpositor");
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x3C20A78", Offset = "0x3C20A78", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.paddingX = 10f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public DemoRepositionExpositor()
		{
			paddingX = 10f;
		}
	}
}
