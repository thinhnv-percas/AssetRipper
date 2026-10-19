using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts
{
	[Token(Token = "0x20001E9")]
	public class LockMono : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000624")]
		[FieldOffset(Offset = "0x20")]
		private Transform m_keyTarget;

		[SerializeField]
		[Token(Token = "0x4000625")]
		[FieldOffset(Offset = "0x28")]
		private Transform m_targetBone;

		[SerializeField]
		[Token(Token = "0x4000626")]
		[FieldOffset(Offset = "0x30")]
		private float m_unlockBoneLocalZ;

		[SerializeField]
		[Token(Token = "0x4000627")]
		[FieldOffset(Offset = "0x38")]
		private TweenSettings m_boneRotateSettings;

		[Token(Token = "0x170000BA")]
		public Transform KeyTargetTransform
		{
			[Token(Token = "0x60008B9")]
			[Address(RVA = "0x3E853AC", Offset = "0x3E853AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.KeyTargetTransform;\n")]
			get
			{
				return m_keyTarget;
			}
		}

		[Token(Token = "0x60008BA")]
		[Address(RVA = "0x3E853B4", Offset = "0x3E853B4", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tgoto L_003E;\nL_003E:\n\tv84 = UnityEngine.Object::op_Equality(this.m_targetBone, 0);\n\tv87 = v84 == 0;\n\tif (v87) goto L_0050;\n\tv141 = v67;\n\tgoto L_00AD;\nL_0050:\n\tv158 = UnityEngine.Transform::get_localRotation(this.m_targetBone);\n\tv52.startRot.x = v158;\n\tv52.startRot.y = v158.y;\n\tv52.startRot.z = v158.z;\n\tv52.startRot.w = v158.w;\n\tv195 = UnityEngine.Quaternion::Internal_ToEulerRad(v158);\n\tv201 = v195 * 0x42652EE1;\n\tv202 = v195.y * 0x42652EE1;\n\tv203 = v195.z * 0x42652EE1;\n\t// 102 MakeStruct v114 @ AGG3E854EC_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v201 @ V0_v5 (System.Single), v202 @ V1_v5 (System.Single), v203 @ V2_v5 (System.Single)\n\tv205 = UnityEngine.Quaternion::Internal_MakePositive(v114);\n\tv212 = v205 * 0x3C8EFA35;\n\tv213 = v205.y * 0x3C8EFA35;\n\tv217 = this.m_unlockBoneLocalZ * 0xFFFFFFFFBC8EFA35;\n\t// 117 MakeStruct v111 @ AGG3E8551C_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v212 @ V0_v7 (System.Single), v213 @ V1_v7 (System.Single), v217 @ V2_v8 (System.Single)\n\tv219 = UnityEngine.Quaternion::Internal_FromEulerRad(v111);\n\tv52.endRot.x = v219;\n\tv52.endRot.y = v219.y;\n\tv52.endRot.z = v219.z;\n\tv52.endRot.w = v219.w;\n\tv108 = this.m_boneRotateSettings;\n\tv228 = new System.Action`2<UnityEngine.Transform, System.Single>();\n\tSystem.Action`2<UnityEngine.Transform, System.Single>::.ctor(v228, v52, Il2CppMethodInfo);\n\tv239 = PrimeTween.Tween::Custom(this.m_targetBone, 0f, 1f, &v108 @ stack_-70_v2 (PrimeTween.TweenSettings), v228);\n\tv138 = PrimeTween.Sequence::Chain(&v128 @ stack_-80_v3 (PrimeTween.Sequence), v239);\n\tv141 = v128;\nL_0027:\n\tv52 = new _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.LockMono+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v52);\n\tv67 = PrimeTween.Sequence::Create(1, 0, 1, 0, 0);\nL_00AD:\n\treturn v141;\n")]
		public Sequence PlayUnlockAnim()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LockMono::PlayUnlockAnim");
			return default;
		}

		[Token(Token = "0x60008BB")]
		[Address(RVA = "0x3E855DC", Offset = "0x3E855DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public LockMono()
		{
		}
	}
}
