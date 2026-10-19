using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace Systems.TutorialSystem.Scripts
{
	[Token(Token = "0x200000D")]
	public class TutorialArrow : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x20")]
		private bool m_AnimateOnEnable;

		[SerializeField]
		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x28")]
		private RectTransform m_Arrow;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x30")]
		private RectTransform _child;

		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x38")]
		private Tween _punchTween;

		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x48")]
		private float _defaultPos;

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x81DF614", Offset = "0x81DF614", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.RectTransform::get_anchoredPosition(this.m_Arrow);\n\tthis._defaultPos = v15.y;\n\treturn;\n")]
		private void Awake()
		{
			_defaultPos = m_Arrow.anchoredPosition.y;
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x81DF648", Offset = "0x81DF648", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.m_AnimateOnEnable != 1;\n\tif (v11) goto L_000E;\n\tSystems.TutorialSystem.Scripts.TutorialArrow::Animate(this);\n\treturn;\nL_000E:\n\treturn;\n")]
		private void OnEnable()
		{
			if (m_AnimateOnEnable)
			{
				Animate();
			}
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x81DF7A0", Offset = "0x81DF7A0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPrimeTween.Tween::Stop(&this._punchTween (PrimeTween.Tween));\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			_punchTween.Stop();
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x81DF65C", Offset = "0x81DF65C", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this._child, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_003C;\n\treturn;\nL_003C:\n\tv138 = UnityEngine.Component::get_gameObject(this._child);\n\tUnityEngine.GameObject::SetActive(v138, 1);\n\tv140 = UnityEngine.RectTransform::get_anchoredPosition(this._child);\n\t// 77 MakeStruct v104 @ AGG81DF734_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v140 @ V0_v2 (UnityEngine.Vector2), this._defaultPos (System.Single)\n\tUnityEngine.RectTransform::set_anchoredPosition(this._child, v104);\n\tPrimeTween.Tween::Stop(&this._punchTween (PrimeTween.Tween));\n\tv157 = PrimeTween.Tween::UIAnchoredPositionY(this._child, -50f, 0.3f, 0, -1, 1, 0f, 0f, 0);\n\tthis._punchTween.id = v157;\n\tthis._punchTween.tween = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Animate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TutorialArrow::Animate");
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x81DF7AC", Offset = "0x81DF7AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public TutorialArrow()
		{
		}
	}
}
