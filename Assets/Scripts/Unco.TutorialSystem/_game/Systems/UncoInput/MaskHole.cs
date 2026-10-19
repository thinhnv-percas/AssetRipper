using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.Systems.UncoInput
{
	[Token(Token = "0x200000A")]
	public class MaskHole : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x20")]
		internal CustomButton m_btn;

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x81DEA00", Offset = "0x81DEA00", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = UnityEngine.Component::get_gameObject(this.m_btn);\n\tUnityEngine.GameObject::SetActive(v23, 1);\n\tv36 = this.m_btn;\n\tv36._runtimeConfig = config;\n\tv39 = this.m_btn;\n\tgoto L_002C;\nL_0032:\n\tv147 = 0x220BDA0(v118, v151, v143, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv131 = v147 == v143;\n\tv143 = v147;\n\tif (v131) goto L_005A;\nL_0041:\n\tv151 = System.Delegate::Combine(v143, action);\n\tv97 = v151 == 0;\n\tif (v97) goto L_0032;\n\tv158 = *([v151 @ X0_v11 (System.Delegate)]) == System.Action;\n\tif (v158) goto L_0032;\n\tthrow System.InvalidCastException;\nL_005A:\n\treturn;\nL_002C:\n\tv118 = this.m_btn + 0x20;\n\tv143 = v39._onClick;\n\tgoto L_0041;\n")]
		public void Init(Action action, InputConfig config)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MaskHole::Init");
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x81DEAE8", Offset = "0x81DEAE8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_btn;\n\tv0._onClick = 0;\n\treturn;\n")]
		public void DeInit()
		{
			CustomButton btn = m_btn;
			btn._onClick = null;
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x81DEB08", Offset = "0x81DEB08", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = UnityEngine.Component::get_gameObject(this.m_btn);\n\tUnityEngine.GameObject::SetActive(v10, 0);\n\treturn;\n")]
		public void DisableNew()
		{
			GameObject gameObject = m_btn.gameObject;
			gameObject.SetActive(value: false);
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x81DEB38", Offset = "0x81DEB38", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MaskHole()
		{
		}
	}
}
