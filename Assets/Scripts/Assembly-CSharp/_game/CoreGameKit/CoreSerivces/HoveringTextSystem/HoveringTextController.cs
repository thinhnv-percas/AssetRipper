using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using PrimeTween;
using Unco.TextViewSystem;
using Unco.Utils;
using Unity.Mathematics;
using UnityEngine;

namespace _game.CoreGameKit.CoreSerivces.HoveringTextSystem
{
	[Token(Token = "0x200060F")]
	public class HoveringTextController : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x2000610")]
		private struct AnimationCurve3
		{
			[SerializeField]
			[Token(Token = "0x40014F1")]
			[FieldOffset(Offset = "0x0")]
			private bool m_seperateAxis;

			[SerializeField]
			[Token(Token = "0x40014F2")]
			[FieldOffset(Offset = "0x8")]
			private AnimationCurve m_curvex;

			[SerializeField]
			[Token(Token = "0x40014F3")]
			[FieldOffset(Offset = "0x10")]
			private AnimationCurve m_curvey;

			[SerializeField]
			[Token(Token = "0x40014F4")]
			[FieldOffset(Offset = "0x18")]
			private AnimationCurve m_curvez;

			[Token(Token = "0x6001A0C")]
			[Address(RVA = "0x3D4FD4C", Offset = "0x3D4FD4C", Length = "0xC0")]
			public float3 Evaluate(float t)
			{
				//IL_007d: Expected O, but got F4
				//IL_006a: Expected O, but got F4
				if (m_seperateAxis)
				{
					float num = m_curvex.Evaluate(t);
					float num2 = m_curvey.Evaluate(t);
					float num3 = m_curvez.Evaluate(t);
					return (float3)num;
				}
				return (float3)m_curvex.Evaluate(t);
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000611")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40014F5")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40014F6")]
			public static Action<GameObject> _003C_003E9__6_1;

			[Token(Token = "0x6001A0D")]
			[Address(RVA = "0x3D4FE0C", Offset = "0x3D4FE0C", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001A0E")]
			[Address(RVA = "0x3D4FE70", Offset = "0x3D4FE70", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003CDisplay_003Eb__6_1(GameObject instance)
			{
				UnityEngine.Object.Destroy(instance);
			}
		}

		[SerializeField]
		[Token(Token = "0x40014EB")]
		[FieldOffset(Offset = "0x20")]
		private HoveringTextConfig m_config;

		[SerializeField]
		[Token(Token = "0x40014EC")]
		[FieldOffset(Offset = "0x28")]
		private Transform m_textParent;

		[SerializeField]
		[Token(Token = "0x40014ED")]
		[FieldOffset(Offset = "0x30")]
		private float m_duration;

		[SerializeField]
		[Token(Token = "0x40014EE")]
		[FieldOffset(Offset = "0x38")]
		private AnimationCurve m_positionCurve;

		[SerializeField]
		[Token(Token = "0x40014EF")]
		[FieldOffset(Offset = "0x40")]
		private AnimationCurve3 m_scaleCurve;

		[SerializeField]
		[Token(Token = "0x40014F0")]
		[FieldOffset(Offset = "0x60")]
		private AnimationCurve m_alphaCurve;

		[Token(Token = "0x6001A09")]
		[Address(RVA = "0x3D4F924", Offset = "0x3D4F924", Length = "0x2E8")]
		public void Display(string text, string config = "default")
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HoveringTextController::Display");
		}

		[Token(Token = "0x6001A0A")]
		[Address(RVA = "0x3D4FC0C", Offset = "0x3D4FC0C", Length = "0x8")]
		public HoveringTextController()
		{
		}
	}
}
