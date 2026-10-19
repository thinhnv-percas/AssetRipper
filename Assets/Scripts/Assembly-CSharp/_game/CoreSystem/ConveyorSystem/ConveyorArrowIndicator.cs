using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;
using _game.CoreSystem.SandPhysics;

namespace _game.CoreSystem.ConveyorSystem
{
	[Token(Token = "0x200050D")]
	public class ConveyorArrowIndicator : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x40010E1")]
		[FieldOffset(Offset = "0x20")]
		private GameObject m_arrowPrefab;

		[SerializeField]
		[Token(Token = "0x40010E2")]
		[FieldOffset(Offset = "0x28")]
		private int m_arrowCount;

		[SerializeField]
		[Token(Token = "0x40010E3")]
		[FieldOffset(Offset = "0x2C")]
		private float m_duration;

		[SerializeField]
		[Token(Token = "0x40010E4")]
		[FieldOffset(Offset = "0x30")]
		private float m_zOffset;

		[SerializeField]
		[Token(Token = "0x40010E5")]
		[FieldOffset(Offset = "0x34")]
		private float m_normalOffset;

		[SerializeField]
		[Token(Token = "0x40010E6")]
		[FieldOffset(Offset = "0x38")]
		private float m_sizeMultiplier;

		[Token(Token = "0x40010E7")]
		private const int LutSize = 1024;

		[Token(Token = "0x40010E8")]
		[FieldOffset(Offset = "0x40")]
		private SplineContainer _splineContainer;

		[Token(Token = "0x40010E9")]
		[FieldOffset(Offset = "0x48")]
		private bool _reverse;

		[Token(Token = "0x40010EA")]
		[FieldOffset(Offset = "0x4C")]
		internal float _phase;

		[Token(Token = "0x40010EB")]
		[FieldOffset(Offset = "0x50")]
		private Transform[] _arrows;

		[Token(Token = "0x40010EC")]
		[FieldOffset(Offset = "0x58")]
		private float[] _arcLengthLUT;

		[Token(Token = "0x6001500")]
		[Address(RVA = "0x3D0ADF0", Offset = "0x3D0ADF0", Length = "0x25C")]
		public void Initialize(SplineContainer splineContainer, bool reverse)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorArrowIndicator::Initialize");
		}

		[Token(Token = "0x6001501")]
		[Address(RVA = "0x3D0B2BC", Offset = "0x3D0B2BC", Length = "0x1DC")]
		private void SpawnArrows()
		{
			Transform[] arrows = new Transform[m_arrowCount];
			_arrows = arrows;
			if (m_arrowCount < 1)
			{
				return;
			}
			int num = 32;
			int num2 = 0;
			Vector3 localScale = default(Vector3);
			object obj = default(object);
			while (true)
			{
				Transform parent = base.transform;
				GameObject gameObject = UnityEngine.Object.Instantiate(m_arrowPrefab, parent);
				gameObject.SetActive(value: true);
				Transform transform = gameObject.transform;
				float z = Vector3.one.z * m_sizeMultiplier;
				float y = m_sizeMultiplier * Vector3.one.y;
				float x = m_sizeMultiplier * Vector3.one.x;
				localScale.x = x;
				localScale.y = y;
				localScale.z = z;
				transform.localScale = localScale;
				Transform[] arrows2 = _arrows;
				Transform transform2 = gameObject.transform;
				if ((object)transform2 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					if (obj == null)
					{
						break;
					}
				}
				num2++;
				num += 8;
				if (num2 >= m_arrowCount)
				{
					return;
				}
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6001502")]
		[Address(RVA = "0x3D0B054", Offset = "0x3D0B054", Length = "0x268")]
		private void BuildArcLengthLUT(Spline spline)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorArrowIndicator::BuildArcLengthLUT");
		}

		[Token(Token = "0x6001503")]
		[Address(RVA = "0x3D0B904", Offset = "0x3D0B904", Length = "0xD8")]
		private float ArcLengthToParametricT(float d)
		{
			bool flag = d < 1f;
			bool flag2 = d == 1f;
			bool flag3 = d == d;
			bool flag4 = 1f == 1f;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			float num = ((!(flag7 && flag8)) ? d : 1f);
			float num2 = ((!(d < 0f)) ? num : 0f);
			int num3 = 1024;
			int num4 = 0;
			while (true)
			{
				int num5 = num3 - 1;
				int num6 = num4;
				int num8;
				bool flag13;
				do
				{
					if (num6 < num5)
					{
						float[] arcLengthLUT = _arcLengthLUT;
						int num7 = num6 + num3;
						num8 = num7 >> 1;
						bool flag9 = arcLengthLUT[num8] == num2;
						bool flag10 = arcLengthLUT[num8] < num2;
						bool flag11 = !flag10;
						bool flag12 = !flag11;
						flag13 = flag12 || flag9;
						num6 = num8;
						continue;
					}
					float[] arcLengthLUT2 = _arcLengthLUT;
					float num9 = arcLengthLUT2[num3] - arcLengthLUT2[num6];
					bool flag14 = !(arcLengthLUT2[num3] > arcLengthLUT2[num6]);
					float num10 = 0f;
					if (!flag14)
					{
						float num11 = num2 - arcLengthLUT2[num6];
						num10 = num11 / num9;
					}
					float num12 = num10 + (float)num6;
					return num12 * 0.0009765625f;
				}
				while (flag13);
				num3 = num8;
				num4 = num8;
			}
		}

		[Token(Token = "0x6001504")]
		[Address(RVA = "0x3D0B9DC", Offset = "0x3D0B9DC", Length = "0x130")]
		private void Update()
		{
			if (_arrows == null || _splineContainer == null)
			{
				return;
			}
			bool flag = SandSpeedScales.ConveyorSpeedFactor == 0f;
			bool flag2 = SandSpeedScales.ConveyorSpeedFactor < 0f;
			bool flag3 = !flag2;
			bool flag4 = !flag;
			if (flag3 && flag4)
			{
				bool flag5 = m_duration == 0f;
				bool flag6 = m_duration < 0f;
				bool flag7 = !flag6;
				bool flag8 = !flag7;
				if (!(flag8 || flag5))
				{
					float deltaTime = Time.deltaTime;
					float num = SandSpeedScales.ConveyorSpeedFactor / m_duration;
					float num2 = num * deltaTime;
					float num3 = _phase + num2;
					float num4 = Mathf.Floor(num3);
					EvaluateArrows(_phase = num3 - num4);
				}
			}
		}

		[Token(Token = "0x6001505")]
		[Address(RVA = "0x3D0B498", Offset = "0x3D0B498", Length = "0x46C")]
		private void EvaluateArrows(float t)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorArrowIndicator::EvaluateArrows");
		}

		[Token(Token = "0x6001506")]
		[Address(RVA = "0x3D0B04C", Offset = "0x3D0B04C", Length = "0x8")]
		public void Stop()
		{
			_phase = 0f;
			DestroyArrows();
		}

		[Token(Token = "0x6001507")]
		[Address(RVA = "0x3D0BB0C", Offset = "0x3D0BB0C", Length = "0x120")]
		internal void DestroyArrows()
		{
			Transform[] arrows = _arrows;
			if (_arrows == null)
			{
				return;
			}
			if (arrows.Length >= 1)
			{
				int num = 0;
				do
				{
					if (arrows[num] != null)
					{
						GameObject obj = arrows[num].gameObject;
						UnityEngine.Object.Destroy(obj);
					}
					num++;
				}
				while (num < arrows.Length);
			}
			_arrows = null;
		}

		[Token(Token = "0x6001508")]
		[Address(RVA = "0x3D0BC2C", Offset = "0x3D0BC2C", Length = "0x4")]
		private void OnDestroy()
		{
			DestroyArrows();
		}

		[Token(Token = "0x6001509")]
		[Address(RVA = "0x3D0BC30", Offset = "0x3D0BC30", Length = "0x1C")]
		public ConveyorArrowIndicator()
		{
			m_arrowCount = 6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [9307F50]");
			m_duration = 0f;
		}
	}
}
