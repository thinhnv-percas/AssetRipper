using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem.TweenElements
{
	[Token(Token = "0x200000E")]
	public class DelayTweenElement : TweenRootElement
	{
		[SerializeField]
		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x20")]
		private float m_duration;

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x819FDC8", Offset = "0x819FDC8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = sequence;\n\tgoto L_002E;\n\tv66 = PrimeTween.Sequence::ChainDelay(&v22 @ stack_-50_v1 (PrimeTween.Sequence), this.m_duration);\n\treturn;\nL_0048:\n\tv77 = operation;\n\t// 75 Box v80 @ X0_v3 (System.Object), typeof(_game.Scripts.TweenerSystem.SequenceOperation), &v77 @ stack_-54_v1 (_game.Scripts.TweenerSystem.SequenceOperation)\n\tv96 = System.String::Format(\"{0} is not supported for {1}.\", v80, \"DelayTweenElement\");\n\tv132 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v132, v96);\n\tgoto L_0060;\nL_0060:\n\tUnityEngine.Debug::LogException(v132);\n\treturn;\nL_002E:\n\tv59 = operation != 1;\n\tif (v59) goto L_0048;\n")]
		internal override void Prepare(Sequence sequence, SequenceOperation operation, float insertTime)
		{
			Sequence sequence2 = sequence;
			if (operation == SequenceOperation.Chain)
			{
				Sequence sequence3 = sequence2.ChainDelay(m_duration);
				return;
			}
			object arg = operation;
			string message = string.Format("{0} is not supported for {1}.", arg, "DelayTweenElement");
			NotSupportedException exception = new NotSupportedException(message);
			Debug.LogException(exception);
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x819FF08", Offset = "0x819FF08", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public DelayTweenElement()
		{
		}
	}
}
