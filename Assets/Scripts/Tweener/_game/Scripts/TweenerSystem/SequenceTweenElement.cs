using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem
{
	[Token(Token = "0x2000004")]
	public class SequenceTweenElement : TweenRootElement
	{
		[Serializable]
		[Token(Token = "0x2000005")]
		private struct SequenceElement
		{
			[SerializeField]
			[Token(Token = "0x4000008")]
			[FieldOffset(Offset = "0x0")]
			private float m_insertTime;

			[SerializeField]
			[Token(Token = "0x4000009")]
			[FieldOffset(Offset = "0x4")]
			private SequenceOperation m_operation;

			[SerializeField]
			[Token(Token = "0x400000A")]
			[FieldOffset(Offset = "0x8")]
			private TweenRootElement m_tweenElement;

			[Token(Token = "0x17000001")]
			public TweenRootElement TweenElement
			{
				[Token(Token = "0x6000006")]
				[Address(RVA = "0x819F4A8", Offset = "0x819F4A8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.TweenElement;\n")]
				get
				{
					return m_tweenElement;
				}
			}

			[Token(Token = "0x17000002")]
			public SequenceOperation Operation
			{
				[Token(Token = "0x6000007")]
				[Address(RVA = "0x819F4B0", Offset = "0x819F4B0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Operation;\n")]
				get
				{
					return m_operation;
				}
			}

			[Token(Token = "0x17000003")]
			public float InsertTime
			{
				[Token(Token = "0x6000008")]
				[Address(RVA = "0x819F4B8", Offset = "0x819F4B8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.InsertTime;\n")]
				get
				{
					return m_insertTime;
				}
			}
		}

		[SerializeField]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x20")]
		private SequenceElement[] m_subElements;

		[SerializeField]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x28")]
		private bool m_useUnscaledTime;

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x819F16C", Offset = "0x819F16C", Length = "0x278")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = sequence;\n\tv33 = operation == 2;\n\tif (v33) goto L_00A3;\n\tv42 = operation == 1;\n\tif (v42) goto L_0067;\n\tv56 = operation == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_00E5;\n\tv73 = PrimeTween.Sequence::Create(1, 0, 1, this.m_useUnscaledTime, 0);\n\tv224 = this.m_subElements;\n\tv297 = v224.Length < 1;\n\tif (v297) goto L_005F;\n\tv164 = v224 + 0x28;\n\tv167 = 0;\n\tv482 = *([v190 @ X0_v44]);\n\t*([v482 @ X8_v17+178])(v419, v190, v73, 0, *([v164 @ X23_v15-4]), *([v482 @ X8_v17+180]), 0, v133, v134, *([v164 @ X23_v15-8]), v135, v136, v137, v138, v139, v140, v141);\n\tv167 = v167 + 1;\n\tv164 = v164 + 0x10;\n\tv411 = v167 < v224.Length;\n\tif (v411) goto L_0041;\nL_005F:\n\tv373 = PrimeTween.Sequence::Group(&v24 @ stack_-60_v1 (PrimeTween.Sequence), v73);\n\tgoto L_00E3;\nL_0067:\n\tv64 = PrimeTween.Sequence::Create(1, 0, 1, this.m_useUnscaledTime, 0);\n\tv142 = this.m_subElements;\n\tv238 = v142.Length < 1;\n\tif (v238) goto L_009A;\n\tv165 = v142 + 0x28;\n\tv168 = 0;\n\tv479 = *([v191 @ X0_v36]);\n\t*([v479 @ X8_v12+178])(v323, v191, v64, 0, *([v165 @ X23_v11-4]), *([v479 @ X8_v12+180]), 0, v133, v134, *([v165 @ X23_v11-8]), v135, v136, v137, v138, v139, v140, v141);\n\tv168 = v168 + 1;\n\tv165 = v165 + 0x10;\n\tv313 = v168 < v142.Length;\n\tif (v313) goto L_007C;\nL_009A:\n\tv347 = PrimeTween.Sequence::Chain(&v24 @ stack_-60_v1 (PrimeTween.Sequence), v64);\n\tgoto L_00E3;\nL_00A3:\n\tv55 = PrimeTween.Sequence::Create(1, 0, 1, this.m_useUnscaledTime, 0);\n\tv65 = this.m_subElements;\n\tv157 = v65.Length < 1;\n\tif (v157) goto L_00D7;\n\tv166 = v65 + 0x28;\n\tv169 = 0;\n\tv434 = *([v192 @ X0_v28]);\n\t*([v434 @ X8_v7+178])(v260, v192, v55, 0, *([v166 @ X23_v7-4]), *([v434 @ X8_v7+180]), 0, v133, v134, *([v166 @ X23_v7-8]), v135, v136, v137, v138, v139, v140, v141);\n\tv169 = v169 + 1;\n\tv166 = v166 + 0x10;\n\tv250 = v169 < v65.Length;\n\tif (v250) goto L_00B8;\nL_00D7:\n\tv285 = PrimeTween.Sequence::Insert(&v24 @ stack_-60_v1 (PrimeTween.Sequence), insertTime, v55);\nL_00E3:\n\treturn;\nL_00E5:\n\tv129 = v107;\n\tv131 = 0xB294000 + 0x1A0;\n\tv226 = \"il2cpp_vm_object_box\"(v131, &v129 @ stack_-64_v1 (_game.Scripts.TweenerSystem.SequenceOperation), v101, v107, v98, v95, v133, v134, v79, v135, v136, v137, v138, v139, v140, v141);\n\tv300 = 0xB28B000 + 0x608;\n\tv431 = new v300();\n\tv477 = 0xB30E000 + 0x638;\n\tSystem.ArgumentOutOfRangeException::.ctor(v431, v477, v226, 0);\n\tthrow v431;\nL_0041:\n\tv190 = *([v164 @ X23_v15]);\nL_007C:\n\tv191 = *([v165 @ X23_v11]);\nL_00B8:\n\tv192 = *([v166 @ X23_v7]);\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override void Prepare(Sequence sequence, SequenceOperation operation, float insertTime)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SequenceTweenElement::Prepare");
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x819F3E4", Offset = "0x819F3E4", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = PrimeTween.Sequence::Create(1, 0, 1, this.m_useUnscaledTime, 0);\n\tv27 = this.m_subElements;\n\tv42 = v27.Length < 1;\n\tif (v42) goto L_004D;\n\tv82 = v27 + 0x28;\n\tv158 = v82;\n\tv52 = 0;\n\tv187 = *([v94 @ X0_v8]);\n\t*([v187 @ X8_v6+178])(v145, v94, v26, 0, *([v82 @ X8_v5-4]), *([v187 @ X8_v6+180]), 0, v98, v99, *([v82 @ X8_v5-8]), v100, v101, v102, v103, v104, v105, v106);\n\tv52 = v52 + 1;\n\tv118 = v52 < v27.Length;\n\tv82 = v158;\n\tif (v118) goto L_0027;\nL_004D:\n\treturn v26;\nL_0027:\n\tv94 = *([v158 @ X23_v5]);\n\tv158 = v158 + 0x10;\n")]
		private Sequence GetSequence()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SequenceTweenElement::GetSequence");
			return default;
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x819F498", Offset = "0x819F498", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public SequenceTweenElement()
		{
		}
	}
}
