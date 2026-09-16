using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Core.Easing
{
	[Token(Token = "0x200005F")]
	public class EaseCurve
	{
		[Token(Token = "0x40001B8")]
		[FieldOffset(Offset = "0x10")]
		internal readonly AnimationCurve _animCurve;

		[Token(Token = "0x60002F3")]
		[Address(RVA = "0x1072538", Offset = "0x1072538", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._animCurve = animCurve;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EaseCurve(AnimationCurve animCurve)
		{
			_animCurve = animCurve;
		}

		[Token(Token = "0x60002F4")]
		[Address(RVA = "0x1072564", Offset = "0x1072564", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = UnityEngine.AnimationCurve::get_length(this._animCurve);\n\tv30 = v28 - 1;\n\tv35 = UnityEngine.AnimationCurve::get_Item(this._animCurve, v30);\n\tv62 = v35.m_Time;\n\tv89 = 0x101CD48(&v62 @ stack_-70_v2 (System.Single), 0, 0, v77, v78, v79, v80, v81, v35.m_OutTangent, v35.m_Time, unusedOvershoot, unusedPeriod, v84, v85, v86, v87);\n\tv94 = time / duration;\n\tv121 = v94 * v35.m_OutTangent;\n\treturnVal2 = UnityEngine.AnimationCurve::Evaluate(this._animCurve, v121);\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float Evaluate(float time, float duration, float unusedOvershoot, float unusedPeriod)
		{
			int length = _animCurve.length;
			int index = length - 1;
			Keyframe keyframe = _animCurve.get_Item(index);
			float time2 = keyframe.time;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101CD48 (inside UnityEngine.Internal.ExcludeFromDocsAttribute::.ctor +0x8)");
			float num = time / duration;
			float time3 = num * keyframe.m_OutTangent;
			return _animCurve.Evaluate(time3);
		}
	}
}
