using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

namespace Unco.UncoButtonSystem
{
	[Token(Token = "0x200000A")]
	public class ScalePunchAnimation : IButtonAnimation, IDisposable
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200000B")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000048")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000049")]
			public static Action<ScalePunchAnimation> _003C_003E9__7_0;

			[Token(Token = "0x6000018")]
			[Address(RVA = "0x81BFBF8", Offset = "0x81BFBF8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Unco.UncoButtonSystem.ScalePunchAnimation+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000019")]
			[Address(RVA = "0x81BFC5C", Offset = "0x81BFC5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003COnMouseUp_003Eb__7_0(ScalePunchAnimation t)
			{
				if (t != null)
				{
					t._activated = false;
				}
			}
		}

		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x10")]
		private readonly ButtonAnimationConfig _config;

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x18")]
		private readonly UncoButton _button;

		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x20")]
		private readonly Vector3 _defaultScale;

		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x2C")]
		private bool _activated;

		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x30")]
		private Sequence _activeSequence;

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x81BF2C0", Offset = "0x81BF2C0", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tgoto L_002F;\nL_002F:\n\tv76 = UnityEngine.Object::op_Implicit(config.TargetTransform);\n\tv79 = v76 == 0;\n\tif (v79) goto L_0041;\n\tv67 = config.TargetTransform;\n\tgoto L_0045;\nL_0041:\n\tv67 = UnityEngine.Component::get_transform(this._button);\nL_0045:\n\tv90 = UnityEngine.Transform::get_localScale(v67);\n\tthis._defaultScale.x = v90;\n\tthis._defaultScale.y = v90.y;\n\tthis._defaultScale.z = v90.z;\n\treturn;\nL_0018:\n\tSystem.Object::.ctor(this);\n\tthis._button = btn;\n\tthis._config = config;\n")]
		public ScalePunchAnimation(UncoButton btn, ButtonAnimationConfig config)
		{
			_button = btn;
			_config = config;
			Vector3 localScale = ((!config.TargetTransform) ? _button.transform : config.TargetTransform).localScale;
			_defaultScale.x = localScale.x;
			_defaultScale.y = localScale.y;
			_defaultScale.z = localScale.z;
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x81BF3AC", Offset = "0x81BF3AC", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv40 = *([v38 @ X0_v2 (UnityEngine.Behaviour)+20]);\n\tv66 = *([v40 @ X8_v4+D8]) != 1;\n\tif (v66) goto L_007F;\n\tv113 = UnityEngine.Behaviour::get_enabled(v38);\n\tv151 = ~v113;\n\tif (v151) goto L_007F;\n\tthis._activated = 1;\n\tPrimeTween.Sequence::Stop(&this._activeSequence (PrimeTween.Sequence));\n\tv92 = PrimeTween.Sequence::Create(1, 0, 1, 1, 0);\n\tv50 = v92;\n\tv47 = 0;\n\tv102 = this._config;\n\tgoto L_0041;\nL_0041:\n\tv204 = UnityEngine.Object::op_Implicit(v102.TargetTransform);\n\tv209 = v204 == 0;\n\tif (v209) goto L_0058;\n\tv153 = this._config;\n\tv221 = v153.TargetTransform;\n\tgoto L_0060;\nL_0058:\n\tv221 = UnityEngine.Component::get_transform(this._button);\n\tv153 = this._config;\nL_0060:\n\tv131 = this._defaultScale * v153.DownValue;\n\tv135 = this._defaultScale.y * v153.DownValue;\n\tv133 = this._defaultScale.z * v153.DownValue;\n\tv124 = v153.DownSettings;\n\t// 107 MakeStruct v115 @ AGG81BF4E0_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v131 @ V0_v3 (System.Single), v135 @ V1_v3 (System.Single), v133 @ V2_v3 (System.Single)\n\tv229 = PrimeTween.Tween::Scale(v221, v115, &v124 @ stack_-60_v2 (PrimeTween.TweenSettings));\n\tv234 = PrimeTween.Sequence::Group(&v50 @ stack_-30_v3 (PrimeTween.Sequence), v229);\n\tthis._activeSequence.root.tween = v229;\n\tthis._activeSequence.root.id = v234;\nL_007F:\n\treturn;\nL_0012:\n\tv38 = this._button;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnMouseDown()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScalePunchAnimation::OnMouseDown");
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x81BF544", Offset = "0x81BF544", Length = "0x470")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\nL_002D:\n\tv60 = UnityEngine.Behaviour::get_enabled(this._button);\n\tv207 = ~v60;\n\tif (v207) goto L_0173;\n\tv187 = this._button;\n\tv188 = v187.Button;\n\tv339 = v188.interactable == 0;\n\tv272 = ~v339;\n\tif (v272) goto L_0047;\n\tv249 = this._activated != 1;\n\tif (v249) goto L_0173;\nL_0047:\n\tv189 = this._config;\n\tv117 = v189.UpSettings * 0.5f;\n\tPrimeTween.TweenSettings::.ctor(&v111 @ stack_-70_v4 (PrimeTween.TweenSettings), v117, v189.UpSettings.ease, 1, 0, 0f, 0f, 0, 0);\n\tv190 = this._config;\n\tv326 = v190.UpSettings.ease;\n\tv332 = 0x93B2000 + 0x4D8;\n\tv345 = v190.UpSettings.ease < 0x1E;\n\tv155 = ~v345;\n\tv151 = v190.UpSettings.ease - 0x1E;\n\tv143 = v151 == 0;\n\tv346 = ~v143;\n\tv123 = v155 & v346;\n\tif (v123) goto L_00A8;\n\tv299 = *([v332 @ X20_v6 (System.Int32)+v326 @ X1_v5 (PrimeTween.Ease)]) << 2;\n\tv305 = 0x81BF668 + v299;\n\t// 111 IndirectJump v305 @ X9_v8 (System.Int32), &v111 @ stack_-70_v4 (PrimeTween.TweenSettings), &v111 @ stack_-70_v4 (PrimeTween.TweenSettings), v190.UpSettings.ease (PrimeTween.Ease), 1, 0, 0, 0, 0, v34 @ X7, v117 @ V0_v5 (System.Single), 0, 0, v38 @ V3, v39 @ V4, v40 @ V5, v41 @ V6, v42 @ V7\n\tthis._activeSequence.root.id = v358;\n\tthis._activeSequence.root.tween = 0;\n\tv191 = this._config;\n\tgoto L_00CE;\nL_00CE:\n\tv365 = UnityEngine.Object::op_Implicit(v191.TargetTransform);\n\tv370 = v365 == 0;\n\tif (v370) goto L_00E5;\n\tv384 = this._config;\n\tv382 = v384.TargetTransform;\n\tgoto L_00ED;\nL_00E5:\n\tv382 = UnityEngine.Component::get_transform(this._button);\n\tv384 = this._config;\nL_00ED:\n\tv119 = this._defaultScale * v384.UpValue;\n\tv115 = this._defaultScale.y * v384.UpValue;\n\tv109 = this._defaultScale.z * v384.UpValue;\n\tv74 = v111;\n\t// 248 MakeStruct v65 @ AGG81BF828_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v119 @ V0_v9 (System.Single), v115 @ V1_v7 (System.Single), v109 @ V2_v6 (System.Single)\n\tv392 = PrimeTween.Tween::Scale(v382, v65, &v74 @ stack_-D0_v3 (PrimeTween.TweenSettings));\n\tv171 = PrimeTween.Sequence::Chain(&this._activeSequence (PrimeTween.Sequence), v392);\n\tv195 = this._config;\n\tgoto L_010A;\nL_010A:\n\tv399 = UnityEngine.Object::op_Implicit(v195.TargetTransform);\n\tv404 = v399 == 0;\n\tif (v404) goto L_0121;\n\tv196 = this._config;\n\tv418 = v196.TargetTransform;\n\tgoto L_0127;\nL_0121:\n\tv418 = UnityEngine.Component::get_transform(this._button);\nL_0127:\n\tv74 = v62;\n\t// 301 MakeStruct v215 @ AGG81BF8C8_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this._defaultScale (UnityEngine.Vector3), this._defaultScale.y (System.Single), this._defaultScale.z (System.Single)\n\tv425 = PrimeTween.Tween::Scale(v418, v215, &v74 @ stack_-D0_v3 (PrimeTween.TweenSettings));\n\tv432 = PrimeTween.Sequence::Chain(&this._activeSequence (PrimeTween.Sequence), v425);\n\tgoto L_013D;\nL_013D:\n\tv240 = v437.<>9__7_0;\n\tv439 = v437.<>9__7_0 == 0;\n\tv440 = ~v439;\n\tif (v440) goto L_0166;\n\tgoto L_014C;\nL_014C:\n\tgoto L_0154;\n\tv240 = v474;\nL_0173:\n\treturn;\nL_00A8:\n\tv118 = v190.UpSettings * 0.5f;\n\tPrimeTween.TweenSettings::.ctor(&v62 @ stack_-A0_v4 (PrimeTween.TweenSettings), v118, v190.UpSettings.ease, 1, 0, 0f, 0f, 0, 0);\n\tPrimeTween.Sequence::Stop(&this._activeSequence (PrimeTween.Sequence));\n\tv358 = PrimeTween.Sequence::Create(1, 0, 1, 1, 0);\nL_0166:\n\t;\n\tv269 = PrimeTween.Sequence::ChainCallback(&this._activeSequence (PrimeTween.Sequence), this, v240, 0);\nL_0154:\n\tv474 = new System.Action`1<Unco.UncoButtonSystem.ScalePunchAnimation>();\n\tSystem.Action`1<Unco.UncoButtonSystem.ScalePunchAnimation>::.ctor(v474, v469.<>9, Il2CppMethodInfo);\n\tv480.<>9__7_0 = v474;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnMouseUp()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScalePunchAnimation::OnMouseUp");
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x81BFB38", Offset = "0x81BFB38", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tgoto L_0021;\nL_0021:\n\tv69 = UnityEngine.Object::op_Implicit(v40.TargetTransform);\n\tv72 = v69 == 0;\n\tif (v72) goto L_0036;\n\tv63 = this._config;\n\tv57 = v63.TargetTransform;\n\tgoto L_0042;\nL_0036:\n\tv57 = UnityEngine.Component::get_transform(this._button);\nL_0042:\n\t// 66 MakeStruct v77 @ AGG81BFBF0_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this._defaultScale (UnityEngine.Vector3), this._defaultScale.y (System.Single), this._defaultScale.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v57, v77);\n\treturn;\nL_0012:\n\t;\n\tPrimeTween.Sequence::Stop(&this._activeSequence (PrimeTween.Sequence));\n\tv40 = this._config;\n")]
		public void Dispose()
		{
			_activeSequence.Stop();
			ButtonAnimationConfig config = _config;
			Transform transform;
			if ((bool)config.TargetTransform)
			{
				ButtonAnimationConfig config2 = _config;
				transform = config2.TargetTransform;
			}
			else
			{
				transform = _button.transform;
			}
			Vector3 localScale = default(Vector3);
			localScale.x = _defaultScale.x;
			localScale.y = _defaultScale.y;
			localScale.z = _defaultScale.z;
			transform.localScale = localScale;
		}
	}
}
