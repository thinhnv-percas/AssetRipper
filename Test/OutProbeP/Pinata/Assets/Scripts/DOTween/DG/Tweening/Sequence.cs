using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Core.Enums;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000014")]
	public sealed class Sequence : Tween
	{
		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0x118")]
		internal readonly List<Tween> sequencedTweens;

		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0x120")]
		private readonly List<ABSSequentiable> _sequencedObjs;

		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0x128")]
		internal float lastTweenInsertTime;

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x10E1A1C", Offset = "0x10E1A1C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC9850]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20274F4]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<DG.Tweening.Tween>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::.ctor(v42);\n\tthis.sequencedTweens = v42;\n\tv50 = new System.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::.ctor(v50);\n\tthis._sequencedObjs = v50;\n\tDG.Tweening.Tween::.ctor(this);\n\tv57 = this->klass;\n\tthis.tweenType = 1;\n\tv61 = this->klass->vtable[4];\n\tv62 = this->klass->vtable[4];\n\t// 53 IndirectJump v61 @ X2_v1, this @ X0 (DG.Tweening.Sequence), this @ X0 (DG.Tweening.Sequence), v62 @ X1_v4, v61 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Sequence()
		{
			//IL_001f: Expected I, but got O
			//IL_003a: Expected O, but got I
			//IL_004a: Expected O, but got I
			base._002Ector();
			while (true)
			{
				List<Tween> list = new List<Tween>();
				sequencedTweens = list;
				List<ABSSequentiable> sequencedObjs = new List<ABSSequentiable>();
				_sequencedObjs = sequencedObjs;
				IntPtr intPtr = (IntPtr)this;
				tweenType = TweenType.Sequence;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v11 (Il2CppClass<DG.Tweening.Sequence>)+170]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v11 (Il2CppClass<DG.Tweening.Sequence>)+178]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v61 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x10E1ACC", Offset = "0x10E1ACC", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = *([1EAF738]);\n\tv29 = *([v28 @ X8_v14]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, t, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20274F5]) = v47;\nL_001A:\n\tv125 = t.loops;\n\tv50 = t.loops + 1;\n\tv52 = v50 == 0;\n\tv55 = ~v52;\n\tif (v55) goto L_002A;\n\tt.loops = 1;\nL_002A:\n\tv83 = inSequence._sequencedObjs;\n\tv94 = t.duration * v125;\n\tv79 = t.delay + v94;\n\tv90 = v79 + inSequence.duration;\n\tinSequence.duration = v90;\n\tv148 = v83._size < 1;\n\tif (v148) goto L_0077;\nL_0040:\n\tv192 = v61 < v83._size;\n\tv106 = ~v192;\n\tv98 = ~v106;\n\tif (v98) goto L_004D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_004D:\n\tv194 = v83._items;\n\tv124 = v194[v61 @ X22_v5 (System.Int32)];\n\tv61 = v61 + 1;\n\tv89 = v79 + v124.sequencedPosition;\n\tv93 = v79 + v124.sequencedEndPosition;\n\tv124.sequencedPosition = v89;\n\tv124.sequencedEndPosition = v93;\n\tv97 = v61 >= v83._size;\n\tif (v97) goto L_0077;\n\tv83 = inSequence._sequencedObjs;\n\tv199 = inSequence._sequencedObjs == 0;\n\tv119 = ~v199;\n\tif (v119) goto L_0040;\n\tthrow System.NullReferenceException;\nL_0077:\n\treturnVal1 = DG.Tweening.Sequence::DoInsert(inSequence, t, 0f);\n\treturn returnVal1;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Sequence DoPrepend(Sequence inSequence, Tween t)
		{
			int num = t.loops;
			if (t.loops + 1 == 0)
			{
				t.loops = 1;
				num = 1;
			}
			List<ABSSequentiable> sequencedObjs = inSequence._sequencedObjs;
			float num2 = t.duration * (float)num;
			float num3 = t.delay + num2;
			float num4 = num3 + inSequence.duration;
			inSequence.duration = num4;
			if (sequencedObjs.Count >= 1)
			{
				int num5 = 0;
				while (true)
				{
					if (num5 >= sequencedObjs.Count)
					{
						throw new ArgumentOutOfRangeException();
					}
					ABSSequentiable[] items = sequencedObjs._items;
					ABSSequentiable aBSSequentiable = items[num5];
					num5++;
					float num6 = num3 + aBSSequentiable.sequencedPosition;
					float num7 = num3 + aBSSequentiable.sequencedEndPosition;
					aBSSequentiable.sequencedPosition = num6;
					aBSSequentiable.sequencedEndPosition = num7;
					if (num5 >= sequencedObjs.Count)
					{
						break;
					}
					sequencedObjs = inSequence._sequencedObjs;
					if (inSequence._sequencedObjs == null)
					{
						throw new NullReferenceException();
					}
				}
			}
			return DoInsert(inSequence, t, 0f);
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x10E1BD8", Offset = "0x10E1BD8", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1F0AA28]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, t, methodInfo, v30, v31, v32, v33, v34, atPosition, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20274F6]) = v44;\nL_001D:\n\tgoto L_0025;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0025;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, t, methodInfo, v30, v31, v32, v33, v34, atPosition, v35, v36, v37, v38, v39, v40, v41);\nL_0025:\n\tDG.Tweening.Core.TweenManager::AddActiveTweenToSequence(t);\n\tv66 = t.delay + atPosition;\n\tinSequence.lastTweenInsertTime = v66;\n\tv109 = t.loops;\n\tt.creationLocked = 1;\n\tt.isSequenced = 1;\n\tt.sequenceParent = inSequence;\n\tv68 = t.loops + 1;\n\tv70 = v68 == 0;\n\tv73 = ~v70;\n\tif (v73) goto L_003D;\n\tt.loops = 1;\nL_003D:\n\tt.elapsedDelay = 0f;\n\tt.delay = 0f;\n\tv125 = t.duration * v109;\n\tv89 = v66 + v125;\n\tt.delayComplete = 1;\n\tt.isSpeedBased = 0;\n\tt.sequencedPosition = v66;\n\tt.sequencedEndPosition = v89;\n\tv94 = v89 <= inSequence.duration;\n\tif (v94) goto L_005B;\n\tinSequence.duration = v89;\nL_005B:\n\tSystem.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::Add(inSequence._sequencedObjs, t);\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::Add(inSequence.sequencedTweens, t);\n\treturn inSequence;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Sequence DoInsert(Sequence inSequence, Tween t, float atPosition)
		{
			TweenManager.AddActiveTweenToSequence(t);
			float num = (inSequence.lastTweenInsertTime = t.delay + atPosition);
			int num2 = t.loops;
			t.creationLocked = true;
			t.isSequenced = true;
			t.sequenceParent = inSequence;
			if (t.loops + 1 == 0)
			{
				t.loops = 1;
				num2 = 1;
			}
			t.elapsedDelay = 0f;
			t.delay = 0f;
			float num3 = t.duration * (float)num2;
			float num4 = num + num3;
			t.delayComplete = true;
			t.isSpeedBased = false;
			t.autoKill = false;
			t.sequencedPosition = num;
			t.sequencedEndPosition = num4;
			if (num4 > inSequence.duration)
			{
				inSequence.duration = num4;
			}
			inSequence._sequencedObjs.Add(t);
			inSequence.sequencedTweens.Add(t);
			return inSequence;
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x10E1D0C", Offset = "0x10E1D0C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = inSequence.duration + interval;\n\tinSequence.lastTweenInsertTime = inSequence.duration;\n\tinSequence.duration = v4;\n\treturn inSequence;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Sequence DoAppendInterval(Sequence inSequence, float interval)
		{
			float num = inSequence.duration + interval;
			inSequence.lastTweenInsertTime = inSequence.duration;
			inSequence.duration = num;
			return inSequence;
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x10E1D34", Offset = "0x10E1D34", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1F01498]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, interval, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20274F7]) = v45;\nL_001A:\n\tv98 = inSequence._sequencedObjs;\n\tinSequence.lastTweenInsertTime = 0f;\n\tv49 = inSequence.duration + interval;\n\tinSequence.duration = v49;\n\tv123 = v98._size < 1;\n\tif (v123) goto L_0063;\nL_002F:\n\tv165 = v59 < v98._size;\n\tv95 = ~v165;\n\tv63 = ~v95;\n\tif (v63) goto L_003C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003C:\n\tv167 = v98._items;\n\tv108 = v167[v59 @ X21_v5 (System.Int32)];\n\tv59 = v59 + 1;\n\tv100 = v108.sequencedPosition + interval;\n\tv52 = v108.sequencedEndPosition + interval;\n\tv108.sequencedPosition = v100;\n\tv108.sequencedEndPosition = v52;\n\tv61 = v59 >= v98._size;\n\tif (v61) goto L_0063;\n\tv98 = inSequence._sequencedObjs;\n\tv172 = inSequence._sequencedObjs == 0;\n\tv105 = ~v172;\n\tif (v105) goto L_002F;\n\tthrow System.NullReferenceException;\nL_0063:\n\treturn inSequence;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Sequence DoPrependInterval(Sequence inSequence, float interval)
		{
			List<ABSSequentiable> sequencedObjs = inSequence._sequencedObjs;
			inSequence.lastTweenInsertTime = 0f;
			float num = inSequence.duration + interval;
			inSequence.duration = num;
			if (sequencedObjs.Count >= 1)
			{
				int num2 = 0;
				while (true)
				{
					if (num2 >= sequencedObjs.Count)
					{
						throw new ArgumentOutOfRangeException();
					}
					ABSSequentiable[] items = sequencedObjs._items;
					ABSSequentiable aBSSequentiable = items[num2];
					num2++;
					float num3 = aBSSequentiable.sequencedPosition + interval;
					float num4 = aBSSequentiable.sequencedEndPosition + interval;
					aBSSequentiable.sequencedPosition = num3;
					aBSSequentiable.sequencedEndPosition = num4;
					if (num2 >= sequencedObjs.Count)
					{
						break;
					}
					sequencedObjs = inSequence._sequencedObjs;
					if (inSequence._sequencedObjs == null)
					{
						throw new NullReferenceException();
					}
				}
			}
			return inSequence;
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x10E1E08", Offset = "0x10E1E08", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EEF000]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, callback, methodInfo, v30, v31, v32, v33, v34, atPosition, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20274F8]) = v44;\nL_0019:\n\tinSequence.lastTweenInsertTime = atPosition;\n\tv49 = new DG.Tweening.Core.SequenceCallback();\n\tDG.Tweening.Core.SequenceCallback::.ctor(v49, atPosition, callback);\n\tv49.sequencedPosition = atPosition;\n\tv49.sequencedEndPosition = atPosition;\n\tSystem.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::Add(inSequence._sequencedObjs, v49);\n\tv76 = inSequence.duration >= atPosition;\n\tif (v76) goto L_0044;\n\tinSequence.duration = atPosition;\nL_0044:\n\treturn inSequence;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Sequence DoInsertCallback(Sequence inSequence, TweenCallback callback, float atPosition)
		{
			inSequence.lastTweenInsertTime = atPosition;
			SequenceCallback sequenceCallback = new SequenceCallback(atPosition, callback);
			sequenceCallback.sequencedPosition = atPosition;
			sequenceCallback.sequencedEndPosition = atPosition;
			inSequence._sequencedObjs.Add(sequenceCallback);
			if (inSequence.duration < atPosition)
			{
				inSequence.duration = atPosition;
			}
			return inSequence;
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x10E1ECC", Offset = "0x10E1ECC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ED7810]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20274F9]) = v38;\nL_0015:\n\tDG.Tweening.Tween::Reset(this);\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::Clear(this.sequencedTweens);\n\tSystem.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::Clear(this._sequencedObjs);\n\tthis.lastTweenInsertTime = 0f;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override void Reset()
		{
			base.Reset();
			sequencedTweens.Clear();
			_sequencedObjs.Clear();
			lastTweenInsertTime = 0f;
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0x10E1F50", Offset = "0x10E1F50", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFCA78]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20274FA]) = v42;\nL_0015:\n\tv107 = this.sequencedTweens;\n\tv56 = v107._size < 1;\n\tif (v56) goto L_FFFFFFFF;\nL_0027:\n\tv174 = v146 < v107._size;\n\tv155 = ~v174;\n\tv147 = ~v155;\n\tif (v147) goto L_0034;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0034:\n\tv202 = v107._items;\n\tv97 = DG.Tweening.Tween::Validate(v202[v146 @ X21_v7 (System.Int32)]);\n\tv138 = v97 == 0;\n\tif (v138) goto L_FFFFFFFF;\n\tv146 = v146 + 1;\n\tv70 = v146 >= v107._size;\n\tif (v70) goto L_FFFFFFFF;\n\tv107 = this.sequencedTweens;\n\tv205 = this.sequencedTweens == 0;\n\tv99 = ~v205;\n\tif (v99) goto L_0027;\n\tthrow System.NullReferenceException;\n\tgoto L_005D;\nL_005D:\n\treturn returnVal1;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override bool Validate()
		{
			List<Tween> list = sequencedTweens;
			if (list.Count >= 1)
			{
				int num = 0;
				while (true)
				{
					if (num >= list.Count)
					{
						throw new ArgumentOutOfRangeException();
					}
					Tween[] items = list._items;
					if (items[num].Validate())
					{
						num++;
						if (num >= list.Count)
						{
							break;
						}
						list = sequencedTweens;
						if (sequencedTweens == null)
						{
							throw new NullReferenceException();
						}
						continue;
					}
					return false;
				}
			}
			return true;
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x10E200C", Offset = "0x10E200C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = DG.Tweening.Sequence::DoStartup(this);\n\treturn returnVal1;\n")]
		internal override bool Startup()
		{
			return DoStartup(this);
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x10E2160", Offset = "0x10E2160", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = DG.Tweening.Sequence::DoApplyTween(this, prevPosition, prevCompletedLoops, newCompletedSteps, useInversePosition, updateMode);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override bool ApplyTween(float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode, UpdateNotice updateNotice)
		{
			return DoApplyTween(this, prevPosition, prevCompletedLoops, newCompletedSteps, useInversePosition, updateMode);
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0x10E2458", Offset = "0x10E2458", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBDE20]);\n\tv19 = *([v18 @ X8_v29]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20274FB]) = v38;\nL_0019:\n\tgoto L_0024;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b7\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0024:\n\ts.autoKill = v54.defaultAutoKill;\n\ts.isRecyclable = v56.defaultRecyclable;\n\tv69 = v58.defaultAutoPlay != 3;\n\tif (v69) goto L_003A;\n\tgoto L_004D;\nL_003A:\n\tgoto L_0045;\n\tv104 = *([v53 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_0045;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv107 = DG.Tweening.DOTween;\n\tv157 = *([v107 @ X0_v13+B8]);\n\tv109 = *([v157 @ X8_v23+3C]);\nL_0045:\n\tv92 = v58.defaultAutoPlay - 1;\n\tv88 = v92 == 0;\nL_004D:\n\ts.isPlaying = v99;\n\tgoto L_005B;\n\tv145 = *([v95 @ X0_v7 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tgoto L_005B;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v95, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv148 = DG.Tweening.DOTween;\nL_005B:\n\ts.easeType = 1;\n\ts.loopType = v150.defaultLoopType;\n\ts.easeOvershootOrAmplitude = v152.defaultEaseOvershootOrAmplitude;\n\ts.easePeriod = v154.defaultEasePeriod;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void Setup(Sequence s)
		{
			s.autoKill = DOTween.defaultAutoKill;
			s.isRecyclable = DOTween.defaultRecyclable;
			int num;
			if (DOTween.defaultAutoPlay == AutoPlay.All)
			{
				num = 1;
			}
			else
			{
				int num2 = (int)(DOTween.defaultAutoPlay - 1);
				bool flag = num2 == 0;
				num = (flag ? 1 : 0);
			}
			s.isPlaying = (byte)num != 0;
			s.easeType = Ease.Linear;
			s.loopType = DOTween.defaultLoopType;
			s.easeOvershootOrAmplitude = DOTween.defaultEaseOvershootOrAmplitude;
			s.easePeriod = DOTween.defaultEasePeriod;
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x10E2010", Offset = "0x10E2010", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1ED1AE8]);\n\tv25 = *([v24 @ X8_v26]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20274FC]) = v44;\nL_0018:\n\tv46 = s.sequencedTweens;\n\tv135 = v46._size == 0;\n\tv136 = ~v135;\n\tif (v136) goto L_002D;\n\tv126 = s._sequencedObjs;\n\tv211 = v126._size == 0;\n\tv166 = ~v211;\n\tif (v166) goto L_002D;\n\tv163 = DG.Tweening.Sequence::IsAnyCallbackSet(s);\n\tv165 = v163 == 0;\n\tif (v165) goto L_FFFFFFFF;\nL_002D:\n\ts.startupDone = 1;\n\tv170 = s.loops & 0x80000000;\n\tv171 = v170 == 0;\n\tv172 = ~v171;\n\tif (v172) goto L_FFFFFFFF;\n\tv109 = s.duration * s.loops;\n\tgoto L_0039;\nL_0039:\n\ts.fullDuration = v109;\n\tDG.Tweening.Sequence::StableSortSequencedObjs(s._sequencedObjs);\n\tv155 = ~s.<isRelative>k__BackingField;\n\tif (v155) goto L_FFFFFFFF;\n\tv235 = s.sequencedTweens;\n\tv177 = v235._size < 1;\n\tif (v177) goto L_0096;\nL_0051:\n\tv237 = v58 < v235._size;\n\tv102 = ~v237;\n\tv62 = ~v102;\n\tif (v62) goto L_005F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_005F:\n\tv239 = ~s.isBlendable;\n\tv240 = ~v239;\n\tif (v240) goto L_007A;\n\tv55 = s.sequencedTweens;\n\tv252 = v58 < v55._size;\n\tv103 = ~v252;\n\tv63 = ~v103;\n\tif (v63) goto L_0073;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0073:\n\tv255 = v55._items;\n\tv129 = v255[v58 @ X22_v6 (System.Int32)];\n\tv129.<isRelative>k__BackingField = 1;\nL_007A:\n\tv58 = v58 + 1;\n\tv60 = v58 >= v235._size;\n\tif (v60) goto L_FFFFFFFF;\n\tv235 = s.sequencedTweens;\n\tv253 = s.sequencedTweens == 0;\n\tv119 = ~v253;\n\tif (v119) goto L_0051;\n\tthrow System.NullReferenceException;\nL_0096:\n\treturn v201;\n\tgoto L_0096;\n\treturn X0;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool DoStartup(Sequence s)
		{
			//IL_00d2: Expected I4, but got I8
			List<Tween> list = s.sequencedTweens;
			int result;
			if (list.Count == 0)
			{
				List<ABSSequentiable> sequencedObjs = s._sequencedObjs;
				if (sequencedObjs.Count == 0 && !IsAnyCallbackSet(s))
				{
					result = 0;
					goto IL_02c4;
				}
			}
			s.startupDone = true;
			float num = (((int)(s.loops & 0x80000000L) != 0) ? float.PositiveInfinity : (s.duration * (float)s.loops));
			s.fullDuration = num;
			StableSortSequencedObjs(s._sequencedObjs);
			if (s.isRelative)
			{
				List<Tween> list2 = s.sequencedTweens;
				bool flag = list2.Count < 1;
				result = 1;
				if (flag)
				{
					goto IL_02c4;
				}
				int num2 = 0;
				while (true)
				{
					if (num2 >= list2.Count)
					{
						throw new ArgumentOutOfRangeException();
					}
					if (!s.isBlendable)
					{
						List<Tween> list3 = s.sequencedTweens;
						if (num2 >= list3.Count)
						{
							throw new ArgumentOutOfRangeException();
						}
						Tween[] items = list3._items;
						Tween tween = items[num2];
						tween.isRelative = true;
					}
					num2++;
					if (num2 >= list2.Count)
					{
						break;
					}
					list2 = s.sequencedTweens;
					if (s.sequencedTweens == null)
					{
						throw new NullReferenceException();
					}
				}
			}
			result = 1;
			goto IL_02c4;
			IL_02c4:
			return (byte)result != 0;
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x10E2168", Offset = "0x10E2168", Length = "0x2F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv52 = *([1EB6980]);\n\tv53 = *([v52 @ X8_v26]);\n\tv54 = \"il2cpp_codegen_initialize_method\"(v53, prevCompletedLoops, newCompletedSteps, useInversePosition, updateMode, methodInfo, v56, v57, prevPosition, v58, v59, v60, v61, v62, v63, v64);\n\tv67 = 0 | 1;\n\t*([20274FD]) = v67;\nL_0027:\n\tv435 = s.<position>k__BackingField;\n\tv75 = s.easeType == 1;\n\tif (v75) goto L_004F;\n\tv89 = DG.Tweening.Core.Easing.EaseManager::Evaluate(s.easeType, s.customEase, prevPosition, s.duration, s.easeOvershootOrAmplitude, s.easePeriod);\n\tv442 = s.duration * v89;\n\tv97 = DG.Tweening.Core.Easing.EaseManager::Evaluate(s.easeType, s.customEase, s.<position>k__BackingField, s.duration, s.easeOvershootOrAmplitude, s.easePeriod);\n\tv435 = s.duration * v97;\nL_004F:\n\tv121 = s.loopType != 1;\n\tif (v121) goto L_FFFFFFFF;\n\tv266 = prevCompletedLoops & 1;\n\tv128 = v442 < s.duration;\n\tif (v128) goto L_0065;\n\tv266 = v266 ^ 1;\n\tgoto L_0065;\nL_0065:\n\tv280 = v266 == 0;\n\tv285 = ~v280;\n\tv290 = s.isBackwards == 0;\n\tv295 = ~v290;\n\tv296 = ~v295;\n\tif (v296) goto L_FFFFFFFF;\n\tgoto L_0087;\nL_0087:\n\tv310 = newCompletedSteps < 1;\n\tif (v310) goto L_009D;\n\tv311 = updateMode == 0;\n\tif (v311) goto L_FFFFFFFF;\n\tv379 = newCompletedSteps & 1;\n\tv366 = v379 == 0;\n\tif (v366) goto L_009D;\n\tv326 = s.loopType != 1;\n\tif (v326) goto L_009D;\n\tv375 = v376 ^ 1;\n\tv442 = s.duration - v442;\nL_009D:\n\tv378 = useInversePosition == 0;\n\tif (v378) goto L_00BA;\n\tv412 = s.duration;\n\tv442 = s.duration - v442;\nL_00A1:\n\tv435 = v412 - v435;\nL_00BA:\n\treturnVal2 = DG.Tweening.Sequence::ApplyInternalCycle(s, v442, v435, updateMode, useInversePosition, v376, 0);\n\treturn returnVal2;\nL_00C5:\n\tv496 = v458 < 0;\n\tv497 = v458 == 0;\n\tv499 = v458 ^ v458;\n\tv500 = v458 & v499;\n\tv501 = v500 < 0;\n\tv313 = v376 ^ 1;\n\tv502 = v496 == v501;\n\tv503 = ~v497;\n\tv504 = v502 & v503;\n\tv505 = ~v504;\n\tif (v505) goto L_FFFFFFFF;\n\tgoto L_00D7;\nL_00D7:\n\tv511 = v458 > 0;\n\tif (v511) goto L_00E6;\n\tv512 = v313 & 1;\n\tv513 = v512 == 0;\n\tv514 = ~v513;\n\tif (v514) goto L_00E6;\n\tv520 = ~s.isBackwards;\n\tif (v520) goto L_00E3;\n\tgoto L_00E6;\nL_00E3:\n\tv462 = s.duration - v466;\nL_00E6:\n\tv525 = v376 == 0;\n\tv526 = ~v525;\n\tif (v526) goto L_00F1;\n\tv469 = s.duration;\nL_00F1:\n\tv487 = DG.Tweening.Sequence::ApplyInternalCycle(s, v462, v469, 0, useInversePosition, v376, 1);\n\tv531 = v487 == 0;\n\tv489 = ~v531;\n\tif (v489) goto L_015B;\n\tv458 = v458 + 1;\n\tv318 = s.loopType != 1;\n\tif (v318) goto L_0112;\n\tgoto L_0112;\nL_0112:\n\tv460 = v458 < newCompletedSteps;\n\tif (v460) goto L_00C5;\n\tv578 = s.completedLoops != s.completedLoops;\n\tif (v578) goto L_0143;\n\tgoto L_012F;\n\tv606 = *([v581 @ X0_v17+E0]);\n\tv607 = v606 == 0;\n\tv608 = ~v607;\n\tif (v608) goto L_012F;\n\tv609 = \"il2cpp_codegen_runtime_class_init\"(v581, v193, v182, v156, v153, methodInfo, v56, v57, v467, v465, v100, v98, v61, v62, v63, v64);\nL_012F:\n\tv611 = s.<position>k__BackingField - s.<position>k__BackingField;\n\tv332 = UnityEngine.Mathf::Abs(v611);\n\tv585 = v332 <= 1E-45f;\n\tif (v585) goto L_0166;\nL_0143:\n\tv551 = s.<active>k__BackingField == 0;\nL_015B:\n\treturn v559;\nL_0166:\n\tv327 = newCompletedSteps != 1;\n\tif (v327) goto L_016C;\n\tv558 = ~s.isComplete;\n\tif (v558) goto L_0171;\n\tgoto L_015B;\nL_016C:\n\tv616 = ~s.isComplete;\n\tv367 = ~v616;\n\tif (v367) goto L_009D;\nL_0171:\n\tv620 = useInversePosition == 0;\n\tif (v620) goto L_017F;\n\tv442 = s.duration;\nL_017F:\n\tv402 = v469 <= 0;\n\tif (v402) goto L_018E;\n\tv626 = s.loopType == 0;\n\tv627 = ~v626;\n\tif (v627) goto L_018E;\n\tv634 = DG.Tweening.Sequence::ApplyInternalCycle(s, s.duration, 0f, 1, 0, 0, 0);\nL_018E:\n\tv441 = useInversePosition == 0;\n\tif (v441) goto L_00BA;\n\tv412 = s.duration;\n\tgoto L_00A1;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 287 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool DoApplyTween(Sequence s, float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode)
		{
			float num = s.position;
			bool flag = s.easeType == Ease.Linear;
			float num2 = prevPosition;
			if (!flag)
			{
				float num3 = EaseManager.Evaluate(s.easeType, s.customEase, prevPosition, s.duration, s.easeOvershootOrAmplitude, s.easePeriod);
				num2 = s.duration * num3;
				float num4 = EaseManager.Evaluate(s.easeType, s.customEase, s.position, s.duration, s.easeOvershootOrAmplitude, s.easePeriod);
				num = s.duration * num4;
			}
			int num5;
			if (s.loopType == LoopType.Yoyo)
			{
				num5 = prevCompletedLoops & 1;
				if (!(num2 < s.duration))
				{
					num5 ^= 1;
				}
			}
			else
			{
				num5 = 0;
			}
			bool flag2 = num5 == 0;
			bool flag3 = !flag2;
			bool flag4 = ((!s.isBackwards) ? flag3 : flag2);
			float num8;
			int result;
			if (newCompletedSteps >= 1)
			{
				if (updateMode == UpdateMode.Update)
				{
					int num6 = 0;
					float num7 = num2;
					num8 = 0f;
					while (true)
					{
						bool flag5 = num6 < 0;
						bool flag6 = num6 == 0;
						int num9 = num6 ^ num6;
						int num10 = num6 & num9;
						bool flag7 = num10 < 0;
						int num11 = (flag4 ? 1 : 0) ^ 1;
						bool flag8 = flag5 == flag7;
						bool flag9 = !flag6;
						float num12 = ((!(flag8 && flag9)) ? num7 : num8);
						if (num6 <= 0 && (num11 & 1) == 0)
						{
							num12 = ((!s.isBackwards) ? (s.duration - num7) : num7);
						}
						bool flag10 = !flag4;
						bool flag11 = !flag10;
						num8 = 0f;
						if (!flag11)
						{
							num8 = s.duration;
						}
						bool flag12 = ApplyInternalCycle(s, num12, num8, default(UpdateMode), useInversePosition, flag4, multiCycleStep: true);
						bool flag13 = !flag12;
						bool flag14 = !flag13;
						result = 1;
						if (flag14)
						{
							break;
						}
						num6++;
						if (s.loopType == LoopType.Yoyo)
						{
							flag4 = (byte)num11 != 0;
						}
						bool flag15 = num6 < newCompletedSteps;
						num7 = num12;
						if (flag15)
						{
							continue;
						}
						goto IL_031a;
					}
					goto IL_05ed;
				}
				if ((newCompletedSteps & 1) != 0 && s.loopType == LoopType.Yoyo)
				{
					int num13 = (flag4 ? 1 : 0) ^ 1;
					num2 = s.duration - num2;
					flag4 = (byte)num13 != 0;
				}
			}
			goto IL_0582;
			IL_0638:
			return ApplyInternalCycle(s, num2, num, updateMode, useInversePosition, flag4);
			IL_0663:
			float num14;
			num = num14 - num;
			goto IL_0638;
			IL_031a:
			if (s.completedLoops == s.completedLoops)
			{
				float f = s.position - s.position;
				float num15 = Mathf.Abs(f);
				if (!(num15 > float.Epsilon))
				{
					if (newCompletedSteps == 1)
					{
						if (s.isComplete)
						{
							result = 0;
							goto IL_05ed;
						}
					}
					else if (s.isComplete)
					{
						goto IL_0582;
					}
					bool flag16 = !useInversePosition;
					num2 = 0f;
					if (!flag16)
					{
						num2 = s.duration;
					}
					if (num8 > 0f && s.loopType == LoopType.Restart)
					{
						bool flag17 = ApplyInternalCycle(s, s.duration, 0f, UpdateMode.Goto, useInverse: false, prevPosIsInverse: false);
					}
					if (!useInversePosition)
					{
						goto IL_0638;
					}
					num14 = s.duration;
					goto IL_0663;
				}
			}
			bool flag18 = !s.active;
			result = (flag18 ? 1 : 0);
			goto IL_05ed;
			IL_05ed:
			return (byte)result != 0;
			IL_0582:
			if (!useInversePosition)
			{
				goto IL_0638;
			}
			num14 = s.duration;
			num2 = s.duration - num2;
			goto IL_0663;
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x10E2714", Offset = "0x10E2714", Length = "0x6DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv54 = *([1EDCBD0]);\n\tv55 = *([v54 @ X8_v121]);\n\tv56 = \"il2cpp_codegen_initialize_method\"(v55, updateMode, useInverse, prevPosIsInverse, multiCycleStep, methodInfo, v58, v59, fromPos, toPos, v60, v61, v62, v63, v64, v65);\n\tv68 = 0 | 1;\n\t*([20274FE]) = v68;\nL_0027:\n\tv70 = s._sequencedObjs;\n\tv484 = v70._size;\n\tv280 = toPos >= fromPos;\n\tif (v280) goto L_01B6;\n\tv840 = v70._size - 1;\n\tv338 = v840 & 0x80000000;\n\tv339 = v338 == 0;\n\tv340 = ~v339;\n\tif (v340) goto L_FFFFFFFF;\n\tv406 = prevPosIsInverse ^ 1;\n\tv413 = updateMode == 0;\n\tv129 = v413 & prevPosIsInverse;\n\tgoto L_01A8;\nL_004F:\n\tv663 = ~s.isPlaying;\n\tif (v663) goto L_0054;\n\tv489 = ~s.isPlaying;\n\tif (v489) goto L_FFFFFFFF;\nL_0054:\n\tv254 = s._sequencedObjs;\n\tv736 = v254._size < v840;\n\tv225 = ~v736;\n\tv215 = v254._size - v840;\n\tv195 = v215 == 0;\n\tv737 = ~v195;\n\tv145 = v225 & v737;\n\tif (v145) goto L_0066;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0066:\n\tv742 = v254._items;\n\tv255 = v742[v840 @ X24_v17 (System.Int32)];\n\tv749 = v255.sequencedEndPosition < toPos;\n\tif (v749) goto L_0085;\n\tv778 = v255.sequencedPosition <= fromPos;\n\tif (v778) goto L_0094;\nL_0085:\n\tv840 = v840 - 1;\n\tv842 = v840 & 0x80000000;\n\tv490 = v842 == 0;\n\tif (v490) goto L_01A8;\n\tgoto L_FFFFFFFF;\nL_0094:\n\tv788 = v255.tweenType != 2;\n\tif (v788) goto L_00AA;\n\tv828 = ~v129;\n\tif (v828) goto L_0085;\n\tv824 = DG.Tweening.Tween::OnTweenCallback(v255.onStart);\n\tgoto L_0085;\nL_00AA:\n\tgoto L_FFFFFFFF;\n\tv146 = v146_asT == 0;\n\tif (v146) goto L_03A5;\n\tv829 = ~v255.startupDone;\n\tif (v829) goto L_0085;\n\tv255.isBackwards = 1;\n\tv1009 = toPos - v255.sequencedPosition;\n\tv95 = UnityEngine.Mathf::Max(v1009, 0f);\n\tgoto L_00D0;\n\tv1033 = *([v1008 @ X0_v52+E0]);\n\tv1034 = v1033 == 0;\n\tv1035 = ~v1034;\n\tif (v1035) goto L_00D0;\n\tv1037 = \"il2cpp_codegen_runtime_class_init\"(v1008, v361, v89, v84, multiCycleStep, methodInfo, v58, v59, v1009, toPos, v60, v61, v62, v63, v64, v65);\nL_00D0:\n\tv826 = DG.Tweening.Core.TweenManager::Goto(v742[v840 @ X24_v17 (System.Int32)], v95, 0, updateMode);\n\tv1073 = v826 == 0;\n\tif (v1073) goto L_0133;\n\tgoto L_00E9;\n\tv1105 = *([v1093 @ X0_v56 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv1106 = v1105 == 0;\n\tv1107 = ~v1106;\n\tif (v1107) goto L_00E9;\n\tv1121 = \"il2cpp_codegen_runtime_class_init\"(v1093, v112, v90, v85, multiCycleStep, methodInfo, v58, v59, v117, toPos, v60, v61, v62, v63, v64, v65);\n\tv1108 = DG.Tweening.DOTween;\nL_00E9:\n\tv196 = v1111.nestedTweenFailureBehaviour == 1;\n\tif (v196) goto L_FFFFFFFF;\n\tv259 = s.sequencedTweens;\n\tv147 = v259._size != 1;\n\tif (v147) goto L_0116;\n\tv260 = s._sequencedObjs;\n\tv703 = v260._size != 1;\n\tif (v703) goto L_0116;\n\tv722 = DG.Tweening.Sequence::IsAnyCallbackSet(s);\n\tv724 = v722 == 0;\n\tif (v724) goto L_FFFFFFFF;\nL_0116:\n\tgoto L_011F;\n\tv1159 = *([v1144 @ X0_v59+E0]);\n\tv1160 = v1159 == 0;\n\tv1161 = ~v1160;\n\tif (v1161) goto L_011F;\n\tv1163 = \"il2cpp_codegen_runtime_class_init\"(v1144, v112, v90, v85, multiCycleStep, methodInfo, v58, v59, v117, toPos, v60, v61, v62, v63, v64, v65);\nL_011F:\n\tDG.Tweening.Core.TweenManager::Despawn(v742[v840 @ X24_v17 (System.Int32)], 0);\n\tSystem.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::RemoveAt(s._sequencedObjs, v840);\n\tv825 = System.Collections.Generic.List`1<DG.Tweening.Tween>::Remove(s.sequencedTweens, v742[v840 @ X24_v17 (System.Int32)]);\n\tv840 = v840 - 1;\n\tgoto L_0085;\nL_0133:\n\tv830 = multiCycleStep == 0;\n\tif (v830) goto L_0085;\n\tv789 = v255.tweenType != 1;\n\tif (v789) goto L_0085;\n\tv1122 = s.<position>k__BackingField < 0;\n\tv822 = ~v1122;\n\tv810 = s.<position>k__BackingField == 0;\n\tv1123 = ~v822;\n\tv790 = v1123 | v810;\n\tif (v790) goto L_0155;\n\tv1136 = s.completedLoops == 0;\n\tv1137 = ~v1136;\n\tif (v1137) goto L_0158;\n\tv1148 = s.isBackwards;\n\tgoto L_0177;\nL_0155:\n\tv831 = s.completedLoops == 0;\n\tif (v831) goto L_01A5;\nL_0158:\n\tv1152 = ~s.isBackwards;\n\tif (v1152) goto L_FFFFFFFF;\n\tv1170 = s.completedLoops >= s.loops;\n\tif (v1170) goto L_016B;\n\tgoto L_0177;\n\tgoto L_0177;\nL_016B:\n\tv1192 = s.loops + 1;\n\tv1181 = v1192 == 0;\nL_0177:\n\tv1201 = v1166 == 0;\n\tv1206 = ~v1201;\n\tv811 = v255.isBackwards == 0;\n\tv791 = ~v811;\n\tv779 = ~v791;\n\tif (v779) goto L_FFFFFFFF;\n\tgoto L_018F;\nL_018F:\n\tv782 = v1282 ^ useInverse;\n\tv1283 = v1148 == 0;\n\tif (v1283) goto L_01A2;\n\tv1288 = useInverse == 0;\n\tv1289 = ~v1288;\n\tif (v1289) goto L_01A2;\n\tv1301 = v782 ^ v406;\n\tv1302 = v1301 & 1;\n\tv1303 = v1302 == 0;\n\tv1304 = ~v1303;\n\tif (v1304) goto L_019E;\nL_019D:\n\tv787 = v255.duration;\nL_019E:\n\tv255.<position>k__BackingField = v787;\n\tgoto L_0085;\nL_01A2:\n\tv1293 = v782 == 0;\n\tif (v1293) goto L_019D;\n\tgoto L_019E;\nL_01A5:\n\tv255.<position>k__BackingField = 0f;\n\tgoto L_0085;\nL_01A8:\n\tv580 = ~s.<active>k__BackingField;\n\tv581 = ~v580;\n\tif (v581) goto L_004F;\n\tgoto L_FFFFFFFF;\nL_01B6:\n\tv351 = v70._size < 1;\n\tif (v351) goto L_FFFFFFFF;\n\tv504 = prevPosIsInverse ^ 1;\n\tgoto L_0388;\nL_01BF:\n\tv732 = ~s.isPlaying;\n\tif (v732) goto L_01C4;\n\tv491 = ~s.isPlaying;\n\tif (v491) goto L_FFFFFFFF;\nL_01C4:\n\tv130 = s._sequencedObjs;\n\tv739 = v130._size < v944;\n\tv229 = ~v739;\n\tv219 = v130._size - v944;\n\tv199 = v219 == 0;\n\tv740 = ~v199;\n\tv149 = v229 & v740;\n\tif (v149) goto L_01D6;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01D6:\n\tv744 = v130._items;\n\tv131 = v744[v944 @ X24_v13 (System.Int32)];\n\tv766 = v131.sequencedPosition <= toPos;\n\tif (v766) goto L_0203;\nL_01EA:\n\tv944 = v944 + 1;\n\tv458 = v944 < v484;\n\tif (v458) goto L_0388;\n\tgoto L_FFFFFFFF;\nL_0203:\n\tv959 = v131.sequencedPosition <= 0;\n\tif (v959) goto L_0212;\n\tv961 = v131.sequencedEndPosition < fromPos;\n\tv918 = ~v961;\n\tv910 = v131.sequencedEndPosition - fromPos;\n\tv894 = v910 == 0;\n\tv962 = ~v918;\n\tv855 = v962 | v894;\n\tif (v855) goto L_01EA;\nL_0212:\n\tv973 = v131.sequencedPosition < 0;\n\tv974 = ~v973;\n\tv977 = v131.sequencedPosition == 0;\n\tv982 = ~v977;\n\tv856 = v974 & v982;\n\tif (v856) goto L_0233;\n\tv903 = v131.sequencedEndPosition < fromPos;\n\tif (v903) goto L_01EA;\nL_0233:\n\tv857 = v131.tweenType != 2;\n\tif (v857) goto L_0260;\n\tv998 = updateMode == 0;\n\tv929 = ~v998;\n\tif (v929) goto L_01EA;\n\tv1002 = ~s.isBackwards;\n\tv1003 = ~v1002;\n\tif (v1003) goto L_0243;\n\tv1011 = useInverse == 0;\n\tv1012 = ~v1011;\n\tif (v1012) goto L_0243;\n\tv1014 = prevPosIsInverse == 0;\n\tif (v1014) goto L_024E;\nL_0243:\n\tv930 = ~s.isBackwards;\n\tif (v930) goto L_01EA;\n\tv931 = useInverse == 0;\n\tif (v931) goto L_01EA;\n\tv1042 = prevPosIsInverse == 0;\n\tv932 = ~v1042;\n\tif (v932) goto L_01EA;\nL_024E:\n\tv926 = DG.Tweening.Tween::OnTweenCallback(v131.onStart);\n\tgoto L_01EA;\nL_0260:\n\tgoto L_FFFFFFFF;\n\tv301 = v301_asT == 0;\n\tif (v301) goto L_03A3;\n\tv1015 = toPos - v131.sequencedPosition;\n\tv97 = UnityEngine.Mathf::Max(v1015, 0f);\n\tv1022 = v131.sequencedEndPosition < toPos;\n\tv1023 = ~v1022;\n\tv1024 = v131.sequencedEndPosition - toPos;\n\tv1026 = v1024 == 0;\n\tv1031 = ~v1026;\n\tv1032 = v1023 & v1031;\n\tif (v1032) goto L_029E;\n\tv1044 = ~v131.startupDone;\n\tv1045 = ~v1044;\n\tif (v1045) goto L_029B;\n\tgoto L_0290;\n\tv1098 = *([v1074 @ X0_v41+E0]);\n\tv1099 = v1098 == 0;\n\tv1100 = ~v1099;\n\tif (v1100) goto L_0290;\n\tv1102 = \"il2cpp_codegen_runtime_class_init\"(v1074, v291, v91, v86, multiCycleStep, methodInfo, v58, v59, v1015, v82, v60, v61, v62, v63, v64, v65);\nL_0290:\n\tDG.Tweening.Core.TweenManager::ForceInit(v744[v944 @ X24_v13 (System.Int32)], 1);\nL_029B:\n\tv1053 = v97 >= v131.fullDuration;\n\tif (v1053) goto L_029E;\nL_029E:\n\tv131.isBackwards = 0;\n\tgoto L_02AE;\n\tv1084 = *([v1068 @ X0_v21+E0]);\n\tv1085 = v1084 == 0;\n\tv1086 = ~v1085;\n\tgoto L_02AE;\n\tv1088 = \"il2cpp_codegen_runtime_class_init\"(v1068, v1049, v1046, v86, multiCycleStep, methodInfo, v58, v59, v1051, v82, v60, v61, v62, v63, v64, v65);\nL_02AE:\n\tv928 = DG.Tweening.Core.TweenManager::Goto(v744[v944 @ X24_v13 (System.Int32)], v97, 0, updateMode);\n\tv1104 = v928 == 0;\n\tif (v1104) goto L_0312;\n\tgoto L_02C7;\n\tv1124 = *([v1116 @ X0_v25 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv1125 = v1124 == 0;\n\tv1126 = ~v1125;\n\tif (v1126) goto L_02C7;\n\tv1138 = \"il2cpp_codegen_runtime_class_init\"(v1116, v114, v92, v87, multiCycleStep, methodInfo, v58, v59, v119, v82, v60, v61, v62, v63, v64, v65);\n\tv1127 = DG.Tweening.DOTween;\nL_02C7:\n\tv200 = v1130.nestedTweenFailureBehaviour == 1;\n\tif (v20\n// ... truncated")]
		private static bool ApplyInternalCycle(Sequence s, float fromPos, float toPos, UpdateMode updateMode, bool useInverse, bool prevPosIsInverse, bool multiCycleStep = false)
		{
			//IL_006a: Expected I4, but got I8
			//IL_020b: Expected I4, but got I8
			//IL_1074: Expected I4, but got O
			List<ABSSequentiable> sequencedObjs = s._sequencedObjs;
			int num = sequencedObjs.Count;
			if (toPos < fromPos)
			{
				int num2 = sequencedObjs.Count - 1;
				if ((int)(num2 & 0x80000000L) == 0)
				{
					int num3 = (prevPosIsInverse ? 1 : 0) ^ 1;
					bool flag = updateMode == UpdateMode.Update;
					bool flag2 = flag && prevPosIsInverse;
					while (s.active)
					{
						Tween tween;
						bool flag12;
						int num5;
						if (!s.isPlaying || s.isPlaying)
						{
							List<ABSSequentiable> sequencedObjs2 = s._sequencedObjs;
							bool flag3 = sequencedObjs2.Count < num2;
							bool flag4 = !flag3;
							int num4 = sequencedObjs2.Count - num2;
							bool flag5 = num4 == 0;
							bool flag6 = !flag5;
							if (!(flag4 && flag6))
							{
								throw new ArgumentOutOfRangeException();
							}
							ABSSequentiable[] items = sequencedObjs2._items;
							tween = (Tween)items[num2];
							if (!(tween.sequencedEndPosition < toPos) && !(tween.sequencedPosition > fromPos))
							{
								if (tween.tweenType == TweenType.Callback)
								{
									if (flag2)
									{
										bool flag7 = Tween.OnTweenCallback(tween.onStart);
									}
								}
								else
								{
									Tween tween2 = items[num2] as Tween;
									if (tween2 == null)
									{
										InvalidCastException ex = new InvalidCastException();
										NullReferenceException ex2 = new NullReferenceException();
										return (byte)(int)ex2 != 0;
									}
									if (tween.startupDone)
									{
										tween.isBackwards = true;
										float a = toPos - tween.sequencedPosition;
										float to = Mathf.Max(a, 0f);
										if (!TweenManager.Goto((Tween)items[num2], to, andPlay: false, updateMode))
										{
											if (multiCycleStep && tween.tweenType == TweenType.Sequence)
											{
												bool flag8 = s.position < 0f;
												bool flag9 = !flag8;
												bool flag10 = s.position == 0f;
												bool flag11 = !flag9;
												if (!(flag11 || flag10))
												{
													if (s.completedLoops == 0)
													{
														flag12 = s.isBackwards;
														num5 = 1;
														goto IL_1092;
													}
												}
												else if (s.completedLoops == 0)
												{
													tween.position = 0f;
													goto IL_01eb;
												}
												if (s.isBackwards)
												{
													if (s.completedLoops < s.loops)
													{
														num5 = 1;
														flag12 = true;
													}
													else
													{
														int num6 = s.loops + 1;
														bool flag13 = num6 == 0;
														num5 = (flag13 ? 1 : 0);
														flag12 = true;
													}
												}
												else
												{
													num5 = (s.isBackwards ? 1 : 0);
													flag12 = false;
												}
												goto IL_1092;
											}
										}
										else
										{
											if (DOTween.nestedTweenFailureBehaviour == NestedTweenFailureBehaviour.KillWholeSequence)
											{
												break;
											}
											List<Tween> list = s.sequencedTweens;
											if (list.Count == 1)
											{
												List<ABSSequentiable> sequencedObjs3 = s._sequencedObjs;
												if (sequencedObjs3.Count == 1 && !IsAnyCallbackSet(s))
												{
													break;
												}
											}
											TweenManager.Despawn((Tween)items[num2], modifyActiveLists: false);
											s._sequencedObjs.RemoveAt(num2);
											bool flag14 = s.sequencedTweens.Remove((Tween)items[num2]);
											num2--;
										}
									}
								}
							}
							goto IL_01eb;
						}
						goto IL_1044;
						IL_06a0:
						float num7 = tween.duration;
						goto IL_110e;
						IL_1092:
						bool flag15 = num5 == 0;
						bool flag16 = !flag15;
						bool flag17 = ((!tween.isBackwards) ? flag16 : flag15);
						bool flag18 = flag17 ^ useInverse;
						if (flag12 && !useInverse)
						{
							int num8 = (flag18 ? 1 : 0) ^ num3;
							int num9 = num8 & 1;
							bool flag19 = num9 == 0;
							bool flag20 = !flag19;
							num7 = 0f;
							if (!flag20)
							{
								goto IL_06a0;
							}
						}
						else
						{
							if (!flag18)
							{
								goto IL_06a0;
							}
							num7 = 0f;
						}
						goto IL_110e;
						IL_01eb:
						num2--;
						if ((int)(num2 & 0x80000000L) == 0)
						{
							continue;
						}
						goto IL_1044;
						IL_110e:
						tween.position = num7;
						goto IL_01eb;
					}
					goto IL_1036;
				}
			}
			else if (sequencedObjs.Count >= 1)
			{
				int num10 = (prevPosIsInverse ? 1 : 0) ^ 1;
				int num11 = 0;
				while (s.active)
				{
					Tween tween3;
					bool flag42;
					int num16;
					if (!s.isPlaying || s.isPlaying)
					{
						List<ABSSequentiable> sequencedObjs4 = s._sequencedObjs;
						bool flag21 = sequencedObjs4.Count < num11;
						bool flag22 = !flag21;
						int num12 = sequencedObjs4.Count - num11;
						bool flag23 = num12 == 0;
						bool flag24 = !flag23;
						if (!(flag22 && flag24))
						{
							throw new ArgumentOutOfRangeException();
						}
						ABSSequentiable[] items2 = sequencedObjs4._items;
						tween3 = (Tween)items2[num11];
						if (!(tween3.sequencedPosition > toPos))
						{
							if (tween3.sequencedPosition > 0f)
							{
								bool flag25 = tween3.sequencedEndPosition < fromPos;
								bool flag26 = !flag25;
								float num13 = tween3.sequencedEndPosition - fromPos;
								bool flag27 = num13 == 0f;
								bool flag28 = !flag26;
								if (flag28 || flag27)
								{
									goto IL_0863;
								}
							}
							bool flag29 = tween3.sequencedPosition < 0f;
							bool flag30 = !flag29;
							bool flag31 = tween3.sequencedPosition == 0f;
							bool flag32 = !flag31;
							if ((flag30 && flag32) || !(tween3.sequencedEndPosition < fromPos))
							{
								if (tween3.tweenType == TweenType.Callback)
								{
									if (updateMode == UpdateMode.Update && ((!s.isBackwards && !useInverse && !prevPosIsInverse) || (s.isBackwards && useInverse && !prevPosIsInverse)))
									{
										bool flag33 = Tween.OnTweenCallback(tween3.onStart);
									}
								}
								else
								{
									Tween tween4 = items2[num11] as Tween;
									if (tween4 == null)
									{
										throw new InvalidCastException();
									}
									float a2 = toPos - tween3.sequencedPosition;
									float num14 = Mathf.Max(a2, 0f);
									bool flag34 = tween3.sequencedEndPosition < toPos;
									bool flag35 = !flag34;
									float num15 = tween3.sequencedEndPosition - toPos;
									bool flag36 = num15 == 0f;
									bool flag37 = !flag36;
									if (!(flag35 && flag37))
									{
										if (!tween3.startupDone)
										{
											TweenManager.ForceInit((Tween)items2[num11], isSequenced: true);
										}
										if (num14 < tween3.fullDuration)
										{
											num14 = tween3.fullDuration;
										}
									}
									tween3.isBackwards = false;
									if (!TweenManager.Goto((Tween)items2[num11], num14, andPlay: false, updateMode))
									{
										if (multiCycleStep && tween3.tweenType == TweenType.Sequence)
										{
											bool flag38 = s.position < 0f;
											bool flag39 = !flag38;
											bool flag40 = s.position == 0f;
											bool flag41 = !flag39;
											if (!(flag41 || flag40))
											{
												if (s.completedLoops == 0)
												{
													flag42 = s.isBackwards;
													num16 = 1;
													goto IL_1151;
												}
											}
											else if (s.completedLoops == 0)
											{
												tween3.position = 0f;
												goto IL_0863;
											}
											if (s.isBackwards)
											{
												num16 = 0;
												flag42 = true;
											}
											else if (s.completedLoops < s.loops)
											{
												num16 = 1;
												flag42 = false;
											}
											else
											{
												int num17 = s.loops + 1;
												bool flag43 = num17 == 0;
												num16 = (flag43 ? 1 : 0);
												flag42 = false;
											}
											goto IL_1151;
										}
									}
									else
									{
										if (DOTween.nestedTweenFailureBehaviour == NestedTweenFailureBehaviour.KillWholeSequence)
										{
											break;
										}
										List<Tween> list2 = s.sequencedTweens;
										if (list2.Count == 1)
										{
											List<ABSSequentiable> sequencedObjs5 = s._sequencedObjs;
											if (sequencedObjs5.Count == 1 && !IsAnyCallbackSet(s))
											{
												break;
											}
										}
										TweenManager.Despawn((Tween)items2[num11], modifyActiveLists: false);
										s._sequencedObjs.RemoveAt(num11);
										bool flag44 = s.sequencedTweens.Remove((Tween)items2[num11]);
										num11--;
										num--;
									}
								}
							}
						}
						goto IL_0863;
					}
					goto IL_1044;
					IL_0fd0:
					float num18 = tween3.duration;
					goto IL_11cd;
					IL_1151:
					bool flag45 = num16 == 0;
					bool flag46 = !flag45;
					bool flag47 = ((!tween3.isBackwards) ? flag46 : flag45);
					bool flag48 = flag47 ^ useInverse;
					if (flag42 && !useInverse)
					{
						int num19 = (flag48 ? 1 : 0) ^ num10;
						int num20 = num19 & 1;
						bool flag49 = num20 == 0;
						bool flag50 = !flag49;
						num18 = 0f;
						if (!flag50)
						{
							goto IL_0fd0;
						}
					}
					else
					{
						if (!flag48)
						{
							goto IL_0fd0;
						}
						num18 = 0f;
					}
					goto IL_11cd;
					IL_11cd:
					tween3.position = num18;
					goto IL_0863;
					IL_0863:
					num11++;
					if (num11 < num)
					{
						continue;
					}
					goto IL_1044;
				}
				goto IL_1036;
			}
			goto IL_1044;
			IL_1036:
			return true;
			IL_1044:
			return false;
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x10E25C8", Offset = "0x10E25C8", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv30 = *([1EAF4D8]);\n\tv31 = *([v30 @ X8_v22]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20274FF]) = v50;\nL_0026:\n\tv63 = list._size < 2;\n\tif (v63) goto L_00AA;\n\tgoto L_0030;\nL_002E:\n\tv205 = list._size;\n\tv86 = v86 + 1;\nL_0030:\n\tv208 = v82 < v205;\n\tv209 = ~v208;\n\tv217 = ~v209;\n\tif (v217) goto L_003D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003D:\n\tv248 = list._items;\n\tv124 = v248[v82 @ X24_v5 (System.Int32)];\nL_0043:\n\tv284 = list._size < v80;\n\tv114 = ~v284;\n\tv111 = list._size - v80;\n\tv105 = v111 == 0;\n\tv285 = ~v105;\n\tv90 = v114 & v285;\n\tif (v90) goto L_0051;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0051:\n\tv287 = list._items;\n\tv75 = v287[v80 @ X26_v6 (System.Int32)];\n\tv299 = v75.sequencedPosition <= v124.sequencedPosition;\n\tif (v299) goto L_008E;\n\tv254 = v80 + 1;\n\tv301 = list._size < v80;\n\tv302 = ~v301;\n\tv303 = list._size - v80;\n\tv305 = v303 == 0;\n\tv310 = ~v305;\n\tv311 = v302 & v310;\n\tif (v311) goto L_007F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv333 = list._items;\nL_007F:\n\tSystem.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::set_Item(list, v254, v256);\n\tv282 = v80 + 1;\n\tv145 = v80 - 1;\n\tv261 = v282 >= 2;\n\tif (v261) goto L_0043;\nL_008E:\n\tv131 = v145 + 1;\n\tSystem.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::set_Item(list, v131, v248[v82 @ X24_v5 (System.Int32)]);\n\tv82 = v82 + 1;\n\tv152 = v82 < list._size;\n\tif (v152) goto L_002E;\nL_00AA:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void StableSortSequencedObjs(List<ABSSequentiable> list)
		{
			if (list.Count < 2)
			{
				return;
			}
			int num = 1;
			int num2 = 0;
			int count = list.Count;
			while (true)
			{
				if (num >= count)
				{
					throw new ArgumentOutOfRangeException();
				}
				ABSSequentiable[] items = list._items;
				ABSSequentiable aBSSequentiable = items[num];
				int num3 = num2;
				int num5;
				bool flag11;
				do
				{
					bool flag = list.Count < num3;
					bool flag2 = !flag;
					int num4 = list.Count - num3;
					bool flag3 = num4 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					ABSSequentiable[] items2 = list._items;
					ABSSequentiable aBSSequentiable2 = items2[num3];
					bool flag5 = !(aBSSequentiable2.sequencedPosition > aBSSequentiable.sequencedPosition);
					num5 = num3;
					if (flag5)
					{
						break;
					}
					int index = num3 + 1;
					bool flag6 = list.Count < num3;
					bool flag7 = !flag6;
					int num6 = list.Count - num3;
					bool flag8 = num6 == 0;
					bool flag9 = !flag8;
					bool flag10 = flag7 && flag9;
					ABSSequentiable value = items2[num3];
					if (!flag10)
					{
						throw new ArgumentOutOfRangeException();
					}
					list.set_Item(index, value);
					int num7 = num3 + 1;
					num5 = num3 - 1;
					flag11 = num7 >= 2;
					num3 = num5;
				}
				while (flag11);
				int index2 = num5 + 1;
				list.set_Item(index2, items[num]);
				num++;
				if (num < list.Count)
				{
					count = list.Count;
					num2++;
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x10E2568", Offset = "0x10E2568", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = s.onComplete == 0;\n\tv4 = ~v3;\n\tif (v4) goto L_001E;\n\tv27 = s.onKill == 0;\n\tv28 = ~v27;\n\tif (v28) goto L_001E;\n\tv42 = s.onPause == 0;\n\tv37 = ~v42;\n\tif (v37) goto L_001E;\n\tv81 = s.onPlay == 0;\n\tv38 = ~v81;\n\tif (v38) goto L_001E;\n\tv82 = s.onRewind == 0;\n\tv39 = ~v82;\n\tif (v39) goto L_001E;\n\tv83 = s.onStart == 0;\n\tv40 = ~v83;\n\tif (v40) goto L_001E;\n\tv36 = s.onStepComplete == 0;\n\tif (v36) goto L_0024;\nL_001E:\n\treturn 1;\nL_0024:\n\tv65 = s.onUpdate == 0;\n\tv50 = ~v65;\n\treturn v50;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsAnyCallbackSet(Sequence s)
		{
			if (s.onComplete != null || s.onKill != null || s.onPause != null || s.onPlay != null || s.onRewind != null || s.onStart != null || s.onStepComplete != null)
			{
				return true;
			}
			bool flag = s.onUpdate == null;
			return !flag;
		}
	}
}
