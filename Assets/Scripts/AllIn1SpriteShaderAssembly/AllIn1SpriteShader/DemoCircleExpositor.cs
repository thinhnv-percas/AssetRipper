using System;
using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1SpriteShader
{
	[Token(Token = "0x200000F")]
	public class DemoCircleExpositor : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x20")]
		private float radius;

		[SerializeField]
		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x24")]
		private float rotateSpeed;

		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0x28")]
		private float zOffset;

		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x30")]
		private Transform[] items;

		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0x38")]
		private int count;

		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0x3C")]
		private int currentTarget;

		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0x40")]
		private float offsetRotation;

		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0x44")]
		private float iniY;

		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x48")]
		private Quaternion dummyRotation;

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x3C1FC3C", Offset = "0x3C1FC3C", Length = "0x4BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv64 = UnityEngine.Transform::get_rotation(v55);\n\tthis.dummyRotation.x = v64;\n\tthis.dummyRotation.y = v64.y;\n\tthis.dummyRotation.z = v64.z;\n\tthis.dummyRotation.w = v64.w;\n\tv187 = UnityEngine.Component::get_transform(this);\n\tv173 = UnityEngine.Transform::get_position(v187);\n\tthis.iniY = v173.y;\n\tv188 = UnityEngine.Component::get_transform(this);\n\tv366 = UnityEngine.Transform::get_childCount(v188);\n\t// 70 NewArr v369 @ X0_v22 (UnityEngine.Transform[]), typeof(UnityEngine.Transform[]), v366 @ X0_v20 (System.Int32)\n\tthis.items = v369;\n\tv189 = UnityEngine.Component::get_transform(this);\n\tv430 = UnityEngine.Transform::GetEnumerator(v189);\n\tv434 = v430 == 0;\nL_FFFFFFFF:\n\tv474 = 0;\n\tif (v434) goto L_0111;\nL_FFFFFFFF:\n\tv505 = v430;\n\tv626 = v153 == 0;\n\tif (v626) goto L_0118;\n\tgoto L_00BC;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v552_asT @ TEMPCOND_v28 (UnityEngine.Transform), typeof(UnityEngine.Transform), v846 @ X0_v61 (System.Object)\n\tv552 = v552_asT == 0;\n\tif (v552) goto L_0114;\n\tv445 = this.items;\n\tv946 = this.items == 0;\nL_FFFFFFFF:\n\tv348 = UnityEngine.Transform;\n\tif (v946) goto L_011A;\n\tv443 = this.count;\n\tv960 = 0x21C11D0(v846, UnityEngine.Transform, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv623 = v960 == 0;\n\tif (v623) goto L_011C;\n\tv975 = this.count < v445.Length;\n\tv956 = ~v975;\n\tv948 = ~v956;\n\tif (v948) goto L_0107;\nL_FFFFFFFF:\n\tv348 = UnityEngine.Transform;\n\tgoto L_0116;\nL_00F5:\n\tv445 = this.items;\n\tv913 = this.items == 0;\nL_FFFFFFFF:\n\tv348 = 0;\n\tif (v913) goto L_011A;\n\tv443 = this.count;\n\tv937 = this.count < v445.Length;\n\tv938 = ~v937;\nL_FFFFFFFF:\n\tv348 = 0;\n\tif (v938) goto L_0116;\nL_0107:\n\tv445[v443 @ X24_v11 (System.Int32)] = v846;\n\tv481 = this.count + 1;\n\tthis.count = v481;\n\tv971 = v153 == 0;\n\tv479 = ~v971;\nL_FFFFFFFF:\n\tv474 = v846;\nL_FFFFFFFF:\n\tv505 = v153;\n\tif (v479) goto L_0064;\nL_0111:\n\tv484 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv348 = v474;\nL_FFFFFFFF:\n\tv349 = v484;\n\tgoto L_011F;\nL_0114:\n\tv619 = new System.InvalidCastException();\nL_FFFFFFFF:\n\tv348 = UnityEngine.Transform;\nL_FFFFFFFF:\n\tv349 = v619;\n\tgoto L_011F;\nL_0116:\n\tv620 = new System.IndexOutOfRangeException();\nL_FFFFFFFF:\n\tv349 = v620;\n\tgoto L_011F;\nL_0118:\n\tv621 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv348 = 0;\nL_FFFFFFFF:\n\tv349 = v621;\n\tgoto L_011F;\nL_011A:\n\tv622 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv349 = v622;\n\tgoto L_011F;\nL_011C:\n\tv976 = new System.ArrayTypeMismatchException();\nL_FFFFFFFF:\n\tv348 = 0;\n\tthrow v976;\nL_011F:\n\t// 287 Interrupt\n\tgoto L_012F;\nL_012F:\n\tv313 = v348 != 1;\nL_FFFFFFFF:\n\tv151 = 0;\n\tif (v313) goto L_01EA;\n\tv668 = 0x8BF5BC4(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv686 = 0x8BF5BF4(v668, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv151 = *([v668 @ X0_v50]);\nL_0137:\n\tv693 = &v153 @ stack_-58_v7 (System.Collections.IEnumerator);\n\tv696 = 0x21C11D0(*([v693 @ X8_v10]), System.IDisposable, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv701 = &v51 @ stack_-60_v1;\n\t*([v701 @ X8_v11]) = v696;\n\tv702 = v696 == 0;\n\tif (v702) goto L_016C;\n\tgoto L_016A;\n\tv925 = this.count;\n\tv811 = 0x43B40000 / this.count;\n\tthis.offsetRotation = v811;\n\tv822 = this.count < 1;\n\tif (v822) goto L_01B8;\nL_FFFFFFFF:\n\tv209 = 0;\n\tv888 = v174 * this.radius;\n\tv974 = v925 * this.radius;\n\tv884 = -v974;\n\t// 421 MakeStruct v873 @ AGG3C20034_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v888 @ V0_v20 (System.Single), this.iniY (System.Single), v884 @ V2_v14 (System.Single)\n\tUnityEngine.Transform::set_position(v204[v209 @ X20_v16 (System.Int32)], v873);\n\tv925 = this.count;\n\tv209 = v209 + 1;\n\tv874 = v209 < this.count;\n\tif (v874) goto L_0186;\nL_01B8:\n\tv175 = this.radius + 0xFFFFFFFFC2200000;\n\tthis.zOffset = v175;\n\tv900 = UnityEngine.Component::get_transform(this);\n\tv192 = UnityEngine.Component::get_transform(this);\n\tv176 = UnityEngine.Transform::get_position(v192);\n\tv193 = UnityEngine.Component::get_transform(this);\n\tv177 = UnityEngine.Transform::get_position(v193);\n\t// 471 MakeStruct v376 @ AGG3C200B4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v176 @ V0_v12 (UnityEngine.Vector3), v177.y (System.Single), this.zOffset (System.Single)\n\tUnityEngine.Transform::set_position(v900, v376);\n\treturn;\nL_01E7:\n\tv349 = new System.OutOfMemoryException();\nL_01EA:\n\tv359 = 0x3173D6C(&v151 @ stack_-78_v6 (UnityEngine.Transform), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv362 = 0x8BF0368(v349, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv363 = 0xA1B8(v362, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0021:\n\tv51 = 0;\n\tv55 = UnityEngine.Component::get_transform(this);\nL_008A:\n\tv665 = System.Collections.IEnumerator::MoveNext(v505);\n\tv667 = v665 == 0;\nL_FFFFFFFF:\n\tv151 = 0;\n\tif (v667) goto L_0137;\nL_00BC:\n\tv846 = System.Collections.IEnumerator::get_Current(v153);\n\tv624 = v846 == 0;\n\tif (v624) goto L_00F5;\nL_0064:\n\tgoto L_008A;\nL_016C:\n\tv756 = v151 == 0;\n\tv293 = ~v756;\n\tif (v293) goto L_01E7;\nL_016A:\n\tv752 = System.IDisposable::Dispose(0);\nL_0186:\n\tv927 = v209 * 0x40490FDB;\n\tv928 = v927 + v927;\n\tv174 = v928 / v925;\n\tv190 = 0x8BF5CD8(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v174, v925, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv204 = this.items;\n")]
		private void Start()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DemoCircleExpositor::Start");
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x3C200F8", Offset = "0x3C200F8", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = UnityEngine.Component::get_transform(this);\n\tv33 = UnityEngine.Component::get_transform(this);\n\tv36 = UnityEngine.Transform::get_rotation(v33);\n\tv106 = UnityEngine.Time::get_deltaTime();\n\tv107 = this.rotateSpeed * v106;\n\t// 52 MakeStruct v39 @ AGG3C20194_1_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), this.dummyRotation (UnityEngine.Quaternion), this.dummyRotation.y (System.Single), this.dummyRotation.z (System.Single), this.dummyRotation.w (System.Single)\n\tv88 = UnityEngine.Quaternion::Slerp(v36, v39, v107);\n\tUnityEngine.Transform::set_rotation(v29, v88);\n\treturn;\n")]
		private void Update()
		{
			Transform transform = base.transform;
			Transform transform2 = base.transform;
			Quaternion rotation = transform2.rotation;
			float deltaTime = Time.deltaTime;
			float t = rotateSpeed * deltaTime;
			Quaternion b = default(Quaternion);
			b.x = dummyRotation.x;
			b.y = dummyRotation.y;
			b.z = dummyRotation.z;
			b.w = dummyRotation.w;
			Quaternion rotation2 = Quaternion.Slerp(rotation, b, t);
			transform.rotation = rotation2;
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x3C1E5F4", Offset = "0x3C1E5F4", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = this.currentTarget + offset;\n\tthis.currentTarget = v16;\n\tv18 = this.items;\n\tv55 = v18.Length - 1;\n\tv35 = v16 <= v55;\n\tif (v35) goto L_0021;\n\tv55 = 0;\n\tgoto L_0024;\nL_0021:\n\tv52 = v16 & 0x80000000;\n\tv53 = v52 == 0;\n\tif (v53) goto L_0032;\nL_0024:\n\tthis.currentTarget = v55;\nL_0032:\n\tgoto L_003D;\nL_003D:\n\tv176 = this.offsetRotation * offset;\n\tv177 = v172.upVector.z * v176;\n\tv179 = v172.upVector * v180;\n\t// 67 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv182 = v179 * v176;\n\tv184 = v177 * 0x3C8EFA35;\n\t// 73 MakeStruct v72 @ AGG3C1E6C8_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v182 @ V0_v7 (System.Single), v121 @ V0.S1, v184 @ V2_v3 (System.Single)\n\tv186 = UnityEngine.Quaternion::Internal_FromEulerRad(v72);\n\t// 80 NotImplemented \"Instruction ZIP1 not yet implemented.\"\n\t// 81 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 84 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 85 NotImplemented \"Instruction EXT not yet implemented.\"\n\t// 87 NotImplemented \"Instruction EXT not yet implemented.\"\n\tv193 = v48 * v186;\n\tv198 = this.dummyRotation * v47;\n\tv110 = v193 + v198;\n\tv199 = v193 - v198;\n\t// 102 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 103 NotImplemented \"Instruction UZP2 not yet implemented.\"\n\tv134 = this.dummyRotation.y * v186.z;\n\tv93 = v110 + v134;\n\tv202 = v199 - v134;\n\t// 109 NotImplemented \"Instruction EXT not yet implemented.\"\n\tv203 = this.dummyRotation.y * v202;\n\t// 112 NotImplemented \"Instruction EXT not yet implemented.\"\n\t// 113 NotImplemented \"Instruction ZIP1 not yet implemented.\"\n\t// 114 NotImplemented \"Instruction ZIP2 not yet implemented.\"\n\tv112 = v93 - v203;\n\tthis.dummyRotation = v112;\n\treturn;\n")]
		public void ChangeTarget(int offset)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DemoCircleExpositor::ChangeTarget");
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x3C201C8", Offset = "0x3C201C8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.radius = 524288.1291503906d;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public DemoCircleExpositor()
		{
			radius = 40f;
			rotateSpeed = 10f;
		}
	}
}
