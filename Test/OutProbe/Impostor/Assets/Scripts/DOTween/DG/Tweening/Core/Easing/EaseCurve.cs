using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Core.Easing
{
	[Token(Token = "0x20000C5")]
	public class EaseCurve
	{
		[Token(Token = "0x40002AD")]
		[FieldOffset(Offset = "0x10")]
		private readonly AnimationCurve _animCurve;

		[Token(Token = "0x600049E")]
		[Address(RVA = "0xC35D60", Offset = "0xC35D60", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._animCurve = animCurve;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EaseCurve(AnimationCurve animCurve)
		{
			_animCurve = animCurve;
		}

		[Token(Token = "0x600049F")]
		[Address(RVA = "0xC35D88", Offset = "0xC35D88", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = UnityEngine.AnimationCurve::get_length(this._animCurve);\n\tv83 = v24 - 1;\n\tv85 = UnityEngine.AnimationCurve::get_Item(this._animCurve, v83);\n\tv52 = v85.m_Time;\n\tv31 = UnityEngine.Keyframe::get_time(&v52 @ stack_-70_v2 (System.Single));\n\tv92 = time / duration;\n\tv117 = v92 * v31;\n\treturnVal2 = UnityEngine.AnimationCurve::Evaluate(this._animCurve, v117);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float Evaluate(float time, float duration, float unusedOvershoot, float unusedPeriod)
		{
			int length = _animCurve.length;
			int index = length - 1;
			float time2 = System.Runtime.CompilerServices.Unsafe.As<float, Keyframe>(ref _animCurve[index].m_Time).time;
			float num = time / duration;
			float time3 = num * time2;
			return _animCurve.Evaluate(time3);
		}
	}
}
