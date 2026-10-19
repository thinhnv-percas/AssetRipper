using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000016")]
public class BackgroundMaterialController : MonoBehaviour
{
	[SerializeField]
	[Token(Token = "0x4000021")]
	[FieldOffset(Offset = "0x20")]
	private List<BackgroundPreset> _presets;

	[Token(Token = "0x1700000E")]
	public IReadOnlyList<BackgroundPreset> Presets
	{
		[Token(Token = "0x6000045")]
		[Address(RVA = "0x3C61F24", Offset = "0x3C61F24", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._presets;\n")]
		get
		{
			return _presets;
		}
	}

	[Token(Token = "0x6000046")]
	[Address(RVA = "0x3C61F2C", Offset = "0x3C61F2C", Length = "0x3DC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tv68 = this._presets;\n\tv133 = v68.Count <= index;\n\tif (v133) goto L_0131;\n\tv268 = System.Collections.Generic.List`1<BackgroundPreset>::get_Item(v68, index);\n\tv398 = &v126 @ stack_-B8 (System.Int32);\n\tv399 = System.Collections.Generic.List`1<RendererMaterialGroup>::GetEnumerator(v268.Groups);\n\tv126 = v126.m_value;\n\tv408 = *([v398 @ X8_v14+10]);\n\tv227 = v126.m_value;\n\tv504 = *([v398 @ X8_v14+10]) == 0;\n\tif (v504) goto L_0132;\n\tgoto L_008C;\nL_008C:\n\tv476 = UnityEngine.Object::op_Equality(*([v408 @ stack_-A8_v5+10]), 0);\n\tv520 = v476 == 0;\n\tv479 = ~v520;\n\tif (v479) goto L_007B;\n\tv572 = *([v408 @ stack_-A8_v5+10]) == 0;\n\tif (v572) goto L_0134;\n\tv581 = UnityEngine.Renderer::get_sharedMaterials(*([v408 @ stack_-A8_v5+10]));\n\tv573 = *([v408 @ stack_-A8_v5+18]) == 0;\n\tif (v573) goto L_0138;\n\tv587 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(*([v408 @ stack_-A8_v5+18]));\n\tv126 = *([v587 @ X0_v38]);\n\tv442 = *([v587 @ X0_v38+10]);\n\tv435 = *([v587 @ X0_v38]);\n\tv431 = v581 + 0x20;\n\tv591 = v581 == 0;\n\tif (v591) goto L_00E4;\nL_00B0:\n\tv608 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v435 @ stack_-A0_v8 (System.Int32));\n\tv623 = v608 == 0;\n\tif (v623) goto L_010F;\n\tv625 = *([v587 @ X0_v38+10]) == 0;\nL_FFFFFFFF:\n\t;\n\tif (v625) goto L_00F1;\n\tv632 = *([v442 @ stack_-A8_v8+10]) & 0x80000000;\n\tv633 = v632 == 0;\n\tv611 = ~v633;\n\tif (v611) goto L_00B0;\n\tv576 = v581.Length;\n\tv534 = *([v442 @ stack_-A8_v8+10]) >= v581.Length;\n\tif (v534) goto L_00B0;\n\tv640 = *([v442 @ stack_-A8_v8+18]) == 0;\nL_FFFFFFFF:\n\t;\n\tif (v640) goto L_00D2;\n\tv643 = 0x21C11D0(*([v442 @ stack_-A8_v8+18]), UnityEngine.Material, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv571 = v643 == 0;\n\tif (v571) goto L_00F5;\n\tv576 = v581.Length;\nL_FFFFFFFF:\n\t;\n\tv592 = *([v442 @ stack_-A8_v8+10]) << 3;\n\tv647 = v431 + v592;\n\t*([v647 @ X0_v56]) = *([v442 @ stack_-A8_v8+18]);\n\tgoto L_00B0;\nL_00E4:\n\tv618 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v435 @ stack_-A0_v8 (System.Int32));\n\tv624 = ~v618;\n\tif (v624) goto L_010F;\n\tv631 = *([v587 @ X0_v38+10]) == 0;\nL_FFFFFFFF:\n\t;\n\tif (v631) goto L_00F1;\n\tv637 = *([v442 @ stack_-A8_v8+10]) & 0x80000000;\n\tv638 = v637 == 0;\n\tv568 = ~v638;\n\tif (v568) goto L_00E4;\n\tv560 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv126 = 0;\nL_FFFFFFFF:\n\t;\n\tgoto L_013B;\nL_00F1:\n\tv561 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv126 = 0;\n\tgoto L_013B;\nL_00F3:\n\tv562 = new System.IndexOutOfRangeException();\nL_FFFFFFFF:\n\tv126 = 0;\n\tgoto L_013B;\nL_00F5:\n\tv648 = new System.ArrayTypeMismatchException();\n\tthrow v648;\nL_010F:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v435 @ stack_-A0_v8 (System.Int32));\n\tgoto L_013A;\n\tv480 = *([v408 @ stack_-A8_v5+10]) == 0;\n\tif (v480) goto L_0136;\n\tUnityEngine.Renderer::set_sharedMaterials(*([v408 @ stack_-A8_v5+10]), v581);\nL_FFFFFFFF:\n\tv126 = 0;\n\tgoto L_007B;\nL_FFFFFFFF:\n\tv308 = &v227 @ stack_-80_v6 (System.Int32);\nL_FFFFFFFF:\n\tv99 = 0;\nL_FFFFFFFF:\n\tv179 = 0;\nL_0131:\n\treturn;\nL_0132:\n\tv514 = new System.NullReferenceException();\nL_FFFFFFFF:\n\t;\n\tgoto L_013B;\nL_0134:\n\tv564 = new System.NullReferenceException();\nL_FFFFFFFF:\n\t;\n\tgoto L_013B;\nL_0136:\n\tv565 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv126 = 0;\nL_FFFFFFFF:\n\t;\n\tgoto L_013B;\nL_0138:\n\tv566 = new System.NullReferenceException();\nL_FFFFFFFF:\n\t;\n\tgoto L_013B;\nL_013A:\n\tv559 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv126 = 0;\nL_FFFFFFFF:\n\t;\nL_013B:\n\t// 315 Interrupt\nL_FFFFFFFF:\n\tv308 = &v227 @ stack_-80_v6 (System.Int32);\nL_FFFFFFFF:\n\tv99 = 0;\nL_013E:\n\tv383 = new System.OutOfMemoryException();\n\tv388 = 0x3178FD8(&v126 @ stack_-B8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_015A;\n\tv418 = 0x8BF5BC4(v383, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv179 = *([v418 @ X0_v19]);\n\tv494 = 0x8BF5BF4(v418, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv99 = *([v418 @ X0_v19]);\n\tgoto L_0120;\n\treturn;\nL_003C:\n\tv435 = 0;\n\tv62 = index & 0x80000000;\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0131;\n\tthrow System.NullReferenceException;\nL_007B:\n\tv491 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v227 @ stack_-80_v6 (System.Int32));\n\tv501 = v491 == 0;\n\tif (v501) goto L_FFFFFFFF;\nL_00D2:\n\tv646 = *([v442 @ stack_-A8_v8+10]) < v576;\n\tv557 = ~v646;\n\tif (v557) goto L_00F3;\nL_015A:\n\tv336 = Il2CppMethodInfo != 1;\n\tif (v336) goto L_0164;\nL_0120:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v308);\n\tv515 = v179 == 0;\n\tv170 = ~v515;\n\tif (v170) goto L_013E;\nL_0164:\n\tv420 = 0x3179018(&v99 @ stack_-C8_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv496 = 0x8BF0368(v383, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv354 = 0xA1B8(v496, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe void ApplyPreset(int index)
	{
		global::AssetRipperInjected.RecoveryStub.Missing("BackgroundMaterialController::ApplyPreset");
	}

	[Token(Token = "0x6000047")]
	[Address(RVA = "0x3C62308", Offset = "0x3C62308", Length = "0x8C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<BackgroundPreset>();\n\tSystem.Collections.Generic.List`1<BackgroundPreset>::.ctor(v48);\n\tthis._presets = v48;\n")]
	public BackgroundMaterialController()
	{
		List<BackgroundPreset> presets = new List<BackgroundPreset>();
		_presets = presets;
	}
}
