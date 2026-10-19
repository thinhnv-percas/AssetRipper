using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace _game.Scripts.TweenerSystem
{
	[Token(Token = "0x2000006")]
	public abstract class TweenElement<T> : TweenRootElement where T : struct
	{
		[SerializeField]
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x0")]
		protected TweenSettings<T> m_settings;

		[Token(Token = "0x17000004")]
		public TweenSettings<T> Settings
		{
			[Token(Token = "0x6000009")]
			[Address(RVA = "0x6570028", Offset = "0x6570028", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([v3 @ X8+20]) = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElement`1<T>)+40]);\n\t*([v3 @ X8+30]) = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElement`1<T>)+50]);\n\t*([v3 @ X8+40]) = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElement`1<T>)+60]);\n\t*([v3 @ X8+50]) = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElement`1<T>)+70]);\n\t*([v3 @ X8]) = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElement`1<T>)+20]);\n\t*([v3 @ X8+10]) = *([this @ X0 (_game.Scripts.TweenerSystem.TweenElement`1<T>)+30]);\n\treturn this;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TweenElement::get_Settings");
				return default;
			}
		}

		[Token(Token = "0x17000005")]
		protected internal abstract UnityEngine.Object Target
		{
			[Token(Token = "0x600000A")]
			get;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x657004C", Offset = "0x657004C", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = sequence;\n\tgoto L_001F;\nL_002A:\n\tv67 = UnityEngine.Object::op_Equality(v61, 0);\n\tv72 = v67 == 0;\n\tif (v72) goto L_003E;\n\tgoto L_0083;\nL_003E:\n\tv87 = operation == 2;\n\tif (v87) goto L_006B;\n\tv118 = operation == 1;\n\tif (v118) goto L_005E;\n\tv201 = operation == 0;\n\tv141 = ~v201;\n\tif (v141) goto L_0084;\n\tv145 = this->klass;\n\t*([v145 @ X8_v8 (Il2CppClass<_game.Scripts.TweenerSystem.TweenElement`1<T>>)+198])(v210, this, *([v145 @ X8_v8 (Il2CppClass<_game.Scripts.TweenerSystem.TweenElement`1<T>>)+1A0]), 0, operation, methodInfo, v44, v45, v46, insertTime, v47, v48, v49, v50, v51, v52, v53);\n\tv138 = PrimeTween.Sequence::Group(&v30 @ stack_-60_v1 (PrimeTween.Sequence), v210);\n\tgoto L_0083;\nL_005E:\n\tv146 = this->klass;\n\t*([v146 @ X8_v7 (Il2CppClass<_game.Scripts.TweenerSystem.TweenElement`1<T>>)+198])(v204, this, *([v146 @ X8_v7 (Il2CppClass<_game.Scripts.TweenerSystem.TweenElement`1<T>>)+1A0]), 0, operation, methodInfo, v44, v45, v46, insertTime, v47, v48, v49, v50, v51, v52, v53);\n\tv139 = PrimeTween.Sequence::Chain(&v30 @ stack_-60_v1 (PrimeTween.Sequence), v204);\n\tgoto L_0083;\nL_006B:\n\tv144 = this->klass;\n\t*([v144 @ X8_v6 (Il2CppClass<_game.Scripts.TweenerSystem.TweenElement`1<T>>)+198])(v160, this, *([v144 @ X8_v6 (Il2CppClass<_game.Scripts.TweenerSystem.TweenElement`1<T>>)+1A0]), 0, operation, methodInfo, v44, v45, v46, insertTime, v47, v48, v49, v50, v51, v52, v53);\n\tv137 = PrimeTween.Sequence::Insert(&v30 @ stack_-60_v1 (PrimeTween.Sequence), insertTime, v160);\nL_0083:\n\treturn;\nL_0084:\n\tv168 = operation;\n\tv215 = 0xB294000 + 0x1A0;\n\tv218 = \"il2cpp_vm_object_box\"(v215, &v168 @ stack_-64_v1 (_game.Scripts.TweenerSystem.SequenceOperation), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv220 = 0xB28B000 + 0x608;\n\tv222 = new v220();\n\tv224 = 0xB30E000 + 0x638;\n\tSystem.ArgumentOutOfRangeException::.ctor(v222, v224, v218, 0);\n\tthrow v222;\nL_001F:\n\tv57 = this->klass;\n\t*([v57 @ X8_v3 (Il2CppClass<_game.Scripts.TweenerSystem.TweenElement`1<T>>)+188])(v61, this, *([v57 @ X8_v3 (Il2CppClass<_game.Scripts.TweenerSystem.TweenElement`1<T>>)+190]), v33, operation, methodInfo, v44, v45, v46, insertTime, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_002A;\n")]
		internal override void Prepare(Sequence sequence, SequenceOperation operation, float insertTime)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TweenElement::Prepare");
		}

		[Token(Token = "0x600000C")]
		protected internal abstract Tween GetTween();

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x6570214", Offset = "0x6570214", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.Scripts.TweenerSystem.TweenRootElement::.ctor(this);\n\treturn;\n")]
		public TweenElement()
		{
		}
	}
}
