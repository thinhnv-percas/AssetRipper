using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751BB4", Offset = "0x751BB4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751BB4", Offset = "0x751BB4")]
	[Token(Token = "0x200010E")]
	public class AnimateFloat : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1304", Offset = "0x7A1304")]
		[Token(Token = "0x4001010")]
		[FieldOffset(Offset = "0x50")]
		public FsmAnimationCurve animCurve;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A1350", Offset = "0x7A1350")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1350", Offset = "0x7A1350")]
		[Token(Token = "0x4001011")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat floatVariable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A13B0", Offset = "0x7A13B0")]
		[Token(Token = "0x4001012")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A13E8", Offset = "0x7A13E8")]
		[Token(Token = "0x4001013")]
		[FieldOffset(Offset = "0x68")]
		public bool realTime;

		[Token(Token = "0x4001014")]
		[FieldOffset(Offset = "0x6C")]
		private float startTime;

		[Token(Token = "0x4001015")]
		[FieldOffset(Offset = "0x70")]
		private float currentTime;

		[Token(Token = "0x4001016")]
		[FieldOffset(Offset = "0x74")]
		private float endTime;

		[Token(Token = "0x4001017")]
		[FieldOffset(Offset = "0x78")]
		private bool looping;

		[Token(Token = "0x6000619")]
		[Address(RVA = "0xA14D24", Offset = "0xA14D24", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.realTime = 0;\n\tthis.floatVariable = 0;\n\tthis.finishEvent = 0;\n\tthis.animCurve = 0;\n\treturn;\n")]
		public override void Reset()
		{
			realTime = false;
			floatVariable = null;
			finishEvent = null;
			animCurve = null;
		}

		[Token(Token = "0x600061A")]
		[Address(RVA = "0xA14D34", Offset = "0xA14D34", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv14 = this.animCurve;\n\tthis.startTime = v13;\n\tthis.currentTime = 0f;\n\tv15 = this.animCurve == 0;\n\tif (v15) goto L_0076;\n\tv17 = v14.curve == 0;\n\tif (v17) goto L_0076;\n\tv26 = UnityEngine.AnimationCurve::get_keys(v14.curve);\n\tv22 = v26.Length == 0;\n\tif (v22) goto L_0076;\n\tv147 = this.animCurve;\n\tv185 = UnityEngine.AnimationCurve::get_keys(v147.curve);\n\tv148 = this.animCurve;\n\tv179 = UnityEngine.AnimationCurve::get_length(v148.curve);\n\tv177 = v179 - 1;\n\tv190 = v177 < v185.Length;\n\tv127 = ~v190;\n\tif (v127) goto L_007B;\n\tv191 = v177 * 0x1C;\n\tv192 = v185 + v191;\n\tv193 = v192 + 0x20;\n\tv186 = 0x101CD48(v193, 0, v35, v160, v161, v162, v163, v164, v13, v165, v166, v167, v168, v169, v170, v171);\n\tv149 = this.animCurve;\n\tthis.endTime = v13;\n\tv187 = UnityEngine.AnimationCurve::get_postWrapMode(v149.curve);\n\tv196 = v187 - 2;\n\tv198 = v196 == 0;\n\tv89 = this.animCurve;\n\tv68 = v187 - 4;\n\tv60 = v68 == 0;\n\tv76 = v60 | v198;\n\tthis.looping = v76;\n\tv188 = this.floatVariable;\n\tv92 = UnityEngine.AnimationCurve::Evaluate(v89.curve, 0f);\n\tv188.value = v92;\n\treturn;\nL_0076:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tv153 = new System.NullReferenceException();\n\tv159 = new System.NullReferenceException();\nL_007B:\n\tv180 = new System.IndexOutOfRangeException();\n\tthrow v180;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_0139: Expected O, but got I
			//IL_0148: Expected O, but got I
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			FsmAnimationCurve fsmAnimationCurve = animCurve;
			startTime = realtimeSinceStartup;
			currentTime = 0f;
			if (animCurve != null && fsmAnimationCurve.curve != null)
			{
				Keyframe[] keys = fsmAnimationCurve.curve.keys;
				if (keys.Length != 0)
				{
					FsmAnimationCurve fsmAnimationCurve2 = animCurve;
					Keyframe[] keys2 = fsmAnimationCurve2.curve.keys;
					FsmAnimationCurve fsmAnimationCurve3 = animCurve;
					int length = fsmAnimationCurve3.curve.length;
					int num = length - 1;
					if (num < keys2.Length)
					{
						int num2 = num * 28;
						object obj = (long)(IntPtr)keys2 + (long)num2;
						object obj2 = (long)(IntPtr)obj + 32L;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101CD48 (inside UnityEngine.Internal.ExcludeFromDocsAttribute::.ctor +0x8)");
						FsmAnimationCurve fsmAnimationCurve4 = animCurve;
						endTime = realtimeSinceStartup;
						WrapMode postWrapMode = fsmAnimationCurve4.curve.postWrapMode;
						int num3 = (int)(postWrapMode - 2);
						bool flag = num3 == 0;
						FsmAnimationCurve fsmAnimationCurve5 = animCurve;
						int num4 = (int)(postWrapMode - 4);
						bool flag2 = num4 == 0;
						bool flag3 = flag2 || flag;
						looping = flag3;
						FsmFloat fsmFloat = floatVariable;
						float value = fsmAnimationCurve5.curve.Evaluate(0f);
						fsmFloat.Value = value;
						return;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			Finish();
		}

		[Token(Token = "0x600061B")]
		[Address(RVA = "0xA14E6C", Offset = "0xA14E6C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = ~this.realTime;\n\tif (v15) goto L_0012;\n\tv17 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv38 = v17 - this.startTime;\n\tgoto L_0014;\nL_0012:\n\tv20 = UnityEngine.Time::get_deltaTime();\n\tv38 = this.currentTime + v20;\nL_0014:\n\tv29 = this.animCurve;\n\tthis.currentTime = v38;\n\tv30 = this.animCurve == 0;\n\tif (v30) goto L_002D;\n\tv32 = v29.curve == 0;\n\tif (v32) goto L_002D;\n\tv37 = this.floatVariable;\n\tv42 = this.floatVariable == 0;\n\tif (v42) goto L_002D;\n\tv70 = UnityEngine.AnimationCurve::Evaluate(v29.curve, v38);\n\tv37.value = v70;\n\tv38 = this.currentTime;\nL_002D:\n\tv54 = v38 < this.endTime;\n\tif (v54) goto L_004B;\n\tv56 = ~this.looping;\n\tv57 = ~v56;\n\tif (v57) goto L_0037;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\nL_0037:\n\tv63 = this.finishEvent == 0;\n\tif (v63) goto L_004B;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\n\treturn;\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			float num;
			if (realTime)
			{
				float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
				num = realtimeSinceStartup - startTime;
			}
			else
			{
				float deltaTime = Time.deltaTime;
				num = currentTime + deltaTime;
			}
			FsmAnimationCurve fsmAnimationCurve = animCurve;
			currentTime = num;
			if (animCurve != null && fsmAnimationCurve.curve != null)
			{
				FsmFloat fsmFloat = floatVariable;
				if (floatVariable != null)
				{
					float value = fsmAnimationCurve.curve.Evaluate(num);
					fsmFloat.Value = value;
					num = currentTime;
				}
			}
			if (!(num < endTime))
			{
				if (!looping)
				{
					Finish();
				}
				if (finishEvent != null)
				{
					Fsm.Event(finishEvent);
				}
			}
		}

		[Token(Token = "0x600061C")]
		[Address(RVA = "0xA14F30", Offset = "0xA14F30", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimateFloat()
		{
		}
	}
}
