using System;
using Cpp2ILInjected;
using Unity.Collections;
using UnityEngine;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime
{
	[Token(Token = "0x2000448")]
	public struct NativeAnimationCurve : IDisposable
	{
		[Token(Token = "0x4000D86")]
		private const int Samples = 64;

		[Token(Token = "0x4000D87")]
		[FieldOffset(Offset = "0x0")]
		private NativeArray<float> _values;

		[Token(Token = "0x1700018B")]
		public bool IsCreated
		{
			[Token(Token = "0x60011F8")]
			[Address(RVA = "0x3CC746C", Offset = "0x3CC746C", Length = "0x48")]
			get
			{
				bool flag = (object)_values == null;
				return !flag;
			}
		}

		[Token(Token = "0x60011F9")]
		[Address(RVA = "0x3CC74B4", Offset = "0x3CC74B4", Length = "0xC8")]
		public NativeAnimationCurve(AnimationCurve curve, Allocator allocator)
		{
			Allocator allocator2 = default(Allocator);
			NativeArray<float> values = new NativeArray<float>(64, allocator2);
			_values = values;
			if (curve != null)
			{
				int num = 0;
				do
				{
					float time = (float)num / 63f;
					float num2 = curve.Evaluate(time);
					NativeArray<float> values2 = _values;
					num++;
				}
				while (num != 64);
			}
		}

		[Token(Token = "0x60011FA")]
		[Address(RVA = "0x3CC757C", Offset = "0x3CC757C", Length = "0x84")]
		public float Sample(float t)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NativeAnimationCurve::Sample");
			return default;
		}

		[Token(Token = "0x60011FB")]
		[Address(RVA = "0x3CC7600", Offset = "0x3CC7600", Length = "0x70")]
		public unsafe void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NativeAnimationCurve::Dispose");
		}
	}
}
