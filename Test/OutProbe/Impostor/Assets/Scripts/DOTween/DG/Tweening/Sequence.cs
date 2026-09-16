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
	[Token(Token = "0x200001E")]
	public sealed class Sequence : Tween
	{
		[Token(Token = "0x400008B")]
		[FieldOffset(Offset = "0x120")]
		internal readonly List<Tween> sequencedTweens;

		[Token(Token = "0x400008C")]
		[FieldOffset(Offset = "0x128")]
		private readonly List<ABSSequentiable> _sequencedObjs;

		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0x130")]
		internal float lastTweenInsertTime;

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0xC0E334", Offset = "0xC0E334", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv59 = System.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv64 = System.Collections.Generic.List`1<DG.Tweening.Tween>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A356D7]) = v50;\nL_0026:\n\tv52 = new System.Collections.Generic.List`1<DG.Tweening.Tween>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::.ctor(v52);\n\tthis.sequencedTweens = v52;\n\tv62 = new System.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>();\n\tSystem.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::.ctor(v62);\n\tthis._sequencedObjs = v62;\n\tthis.intId = 0xFFFFFC19;\n\tthis.activeId = 0xFFFFFFFF;\n\tthis.delayComplete = 1;\n\tthis.miscInt = 0xFFFFFFFF;\n\tDG.Tweening.Core.ABSSequentiable::.ctor(this);\n\tv72 = this->klass;\n\tthis.tweenType = 1;\n\tv76 = this->klass->vtable[4];\n\tv77 = this->klass->vtable[4];\n\t// 72 IndirectJump v76 @ X2_v1, this @ X0 (DG.Tweening.Sequence), this @ X0 (DG.Tweening.Sequence), v77 @ X1_v4, v76 @ X2_v1, v34 @ X3, v35 @ X4, v36 @ X5, v37 @ X6, v38 @ X7, v39 @ V0, v40 @ V1, v41 @ V2, v42 @ V3, v43 @ V4, v44 @ V5, v45 @ V6, v46 @ V7\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Sequence()
		{
			//IL_004b: Expected I, but got O
			//IL_0066: Expected O, but got I
			//IL_0076: Expected O, but got I
			base._002Ector();
			while (true)
			{
				List<Tween> list = new List<Tween>();
				sequencedTweens = list;
				List<ABSSequentiable> sequencedObjs = new List<ABSSequentiable>();
				_sequencedObjs = sequencedObjs;
				intId = -999;
				activeId = -1;
				delayComplete = true;
				miscInt = -1;
				nint num = (nint)this;
				tweenType = TweenType.Sequence;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X8_v4 (Il2CppClass<DG.Tweening.Sequence>)+178]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X8_v4 (Il2CppClass<DG.Tweening.Sequence>)+180]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v76 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0xC0E44C", Offset = "0xC0E44C", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, t, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, t, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv127 = \"Infinite loops aren't allowed inside a Sequence (only on the Sequence itself) and will be changed to int.MaxValue\";\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v127, t, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A356D8]) = v43;\nL_001D:\n\tv121 = t.loops;\n\tv49 = t.loops + 1;\n\tv51 = v49 == 0;\n\tv54 = ~v51;\n\tif (v54) goto L_0034;\n\tt.loops = 0x7FFFFFFF;\n\tDG.Tweening.Core.Debugger::LogWarning(\"Infinite loops aren't allowed inside a Sequence (only on the Sequence itself) and will be changed to int.MaxValue\", t);\n\tv121 = t.loops;\nL_0034:\n\tv184 = inSequence._sequencedObjs;\n\tv177 = t.duration * v121;\n\tv81 = t.delay + v177;\n\tv84 = v81 + inSequence.duration;\n\tinSequence.duration = v84;\n\tv92 = v184._size < 1;\n\tif (v92) goto L_006F;\n\t// 75 NotImplemented \"Instruction DUP not yet implemented.\"\nL_004E:\n\tv113 = System.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::get_Item(v184, v124);\n\tv124 = v124 + 1;\n\tv103 = v184._size == v124;\n\tv80 = v1 + v113.sequencedPosition;\n\tv113.sequencedPosition = v80;\n\tif (v103) goto L_006F;\n\tv184 = inSequence._sequencedObjs;\n\tv188 = inSequence._sequencedObjs == 0;\n\tv116 = ~v188;\n\tif (v116) goto L_004E;\n\tthrow System.NullReferenceException;\nL_006F:\n\treturnVal1 = DG.Tweening.Sequence::DoInsert(inSequence, t, 0f);\n\treturn returnVal1;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Sequence DoPrepend(Sequence inSequence, Tween t)
		{
			int num = t.loops;
			if (t.loops + 1 == 0)
			{
				t.loops = int.MaxValue;
				Debugger.LogWarning("Infinite loops aren't allowed inside a Sequence (only on the Sequence itself) and will be changed to int.MaxValue", t);
				num = t.loops;
			}
			List<ABSSequentiable> sequencedObjs = inSequence._sequencedObjs;
			float num2 = t.duration * (float)num;
			float num3 = t.delay + num2;
			float num4 = num3 + inSequence.duration;
			inSequence.duration = num4;
			if (sequencedObjs.Count >= 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				int num5 = 0;
				object obj = default(object);
				while (true)
				{
					ABSSequentiable aBSSequentiable = sequencedObjs[num5];
					num5++;
					bool flag = sequencedObjs.Count == num5;
					float num6 = (float)obj + aBSSequentiable.sequencedPosition;
					aBSSequentiable.sequencedPosition = num6;
					if (flag)
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

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0xC0E56C", Offset = "0xC0E56C", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, t, methodInfo, v31, v32, v33, v34, v35, atPosition, v36, v37, v38, v39, v40, v41, v42);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, t, methodInfo, v31, v32, v33, v34, v35, atPosition, v36, v37, v38, v39, v40, v41, v42);\n\tv59 = DG.Tweening.Core.TweenManager;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, t, methodInfo, v31, v32, v33, v34, v35, atPosition, v36, v37, v38, v39, v40, v41, v42);\n\tv63 = \"SpeedBased tweens are not allowed inside a Sequence: interpreting speed as duration\";\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, t, methodInfo, v31, v32, v33, v34, v35, atPosition, v36, v37, v38, v39, v40, v41, v42);\n\tv148 = \"Infinite loops aren't allowed inside a Sequence (only on the Sequence itself) and will be changed to int.MaxValue\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v148, t, methodInfo, v31, v32, v33, v34, v35, atPosition, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A356D9]) = v46;\nL_0028:\n\tgoto L_002C;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v47, t, methodInfo, v31, v32, v33, v34, v35, atPosition, v36, v37, v38, v39, v40, v41, v42);\nL_002C:\n\tDG.Tweening.Core.TweenManager::AddActiveTweenToSequence(t);\n\tv138 = t.delay + atPosition;\n\tinSequence.lastTweenInsertTime = v138;\n\tv166 = t.loops;\n\tt.creationLocked = 1;\n\tt.isSequenced = 1;\n\tt.sequenceParent = inSequence;\n\tv151 = t.loops + 1;\n\tv153 = v151 == 0;\n\tv156 = ~v153;\n\tif (v156) goto L_004C;\n\tt.loops = 0x7FFFFFFF;\n\tDG.Tweening.Core.Debugger::LogWarning(\"Infinite loops aren't allowed inside a Sequence (only on the Sequence itself) and will be changed to int.MaxValue\", t);\n\tv166 = t.loops;\nL_004C:\n\tt.autoKill = 0;\n\tv67 = t.duration * v166;\n\tt.elapsedDelay = 0f;\n\tt.delay = 0f;\n\tt.delayComplete = 1;\n\tv171 = ~t.isSpeedBased;\n\tif (v171) goto L_005A;\n\tt.isSpeedBased = 0;\n\tDG.Tweening.Core.Debugger::LogWarning(\"SpeedBased tweens are not allowed inside a Sequence: interpreting speed as duration\", t);\nL_005A:\n\tv125 = v138 + v67;\n\tt.sequencedPosition = v138;\n\tt.sequencedEndPosition = v125;\n\tv107 = v125 <= inSequence.duration;\n\tif (v107) goto L_006C;\n\tinSequence.duration = v125;\nL_006C:\n\tv130 = inSequence._sequencedObjs;\n\tv140 = v130._items;\n\tv76 = v130._version + 1;\n\tv130._version = v76;\n\tv77 = v130._size;\n\tv234 = v130._size < v140.Length;\n\tv115 = ~v234;\n\tif (v115) goto L_008E;\n\tv235 = v130._size + 1;\n\tv130._size = v235;\n\tv140[v77 @ X10_v4 (System.Int32)] = t;\n\tgoto L_008F;\nL_008E:\n\tSystem.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::AddWithResize(v130, t);\nL_008F:\n\tv131 = inSequence.sequencedTweens;\n\tv142 = v131._items;\n\tv78 = v131._version + 1;\n\tv131._version = v78;\n\tv181 = v131._size;\n\tv245 = v131._size < v142.Length;\n\tv199 = ~v245;\n\tif (v199) goto L_00B1;\n\tv246 = v131._size + 1;\n\tv131._size = v246;\n\tv142[v181 @ X10_v7 (System.Int32)] = t;\n\tgoto L_00BB;\nL_00B1:\n\tSystem.Collections.Generic.List`1<DG.Tweening.Tween>::AddWithResize(v131, t);\nL_00BB:\n\treturn inSequence;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				t.loops = int.MaxValue;
				Debugger.LogWarning("Infinite loops aren't allowed inside a Sequence (only on the Sequence itself) and will be changed to int.MaxValue", t);
				num2 = t.loops;
			}
			t.autoKill = false;
			float num3 = t.duration * (float)num2;
			t.elapsedDelay = 0f;
			t.delay = 0f;
			t.delayComplete = true;
			if (t.isSpeedBased)
			{
				t.isSpeedBased = false;
				Debugger.LogWarning("SpeedBased tweens are not allowed inside a Sequence: interpreting speed as duration", t);
			}
			float num4 = num + num3;
			t.sequencedPosition = num;
			t.sequencedEndPosition = num4;
			if (num4 > inSequence.duration)
			{
				inSequence.duration = num4;
			}
			List<ABSSequentiable> sequencedObjs = inSequence._sequencedObjs;
			ABSSequentiable[] items = sequencedObjs._items;
			int version = sequencedObjs._version + 1;
			sequencedObjs._version = version;
			int count = sequencedObjs.Count;
			if (sequencedObjs.Count < items.Length)
			{
				int size = sequencedObjs.Count + 1;
				sequencedObjs._size = size;
				items[count] = t;
			}
			else
			{
				sequencedObjs.Add(t);
			}
			List<Tween> list = inSequence.sequencedTweens;
			Tween[] items2 = list._items;
			int version2 = list._version + 1;
			list._version = version2;
			int count2 = list.Count;
			if (list.Count < items2.Length)
			{
				int size2 = list.Count + 1;
				list._size = size2;
				items2[count2] = t;
			}
			else
			{
				list.Add(t);
			}
			return inSequence;
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0xC0E784", Offset = "0xC0E784", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = inSequence.duration + interval;\n\tinSequence.lastTweenInsertTime = inSequence.duration;\n\tinSequence.duration = v5;\n\treturn inSequence;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Sequence DoAppendInterval(Sequence inSequence, float interval)
		{
			float num = inSequence.duration + interval;
			inSequence.lastTweenInsertTime = inSequence.duration;
			inSequence.duration = num;
			return inSequence;
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0xC0E7A8", Offset = "0xC0E7A8", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = Il2CppMethodInfo;\n\tv21 = interval;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v25, v26, v27, v28, v29, v30, interval, v31, v32, v33, v34, v35, v36, v37);\n\tv48 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v25, v26, v27, v28, v29, v30, interval, v31, v32, v33, v34, v35, v36, v37);\n\tv39 = v21;\n\tv45 = 1;\n\t*([1A356DA]) = v45;\nL_001B:\n\tv149 = inSequence._sequencedObjs;\n\tinSequence.lastTweenInsertTime = 0f;\n\tv51 = inSequence.duration + v38;\n\tinSequence.duration = v51;\n\tv60 = v149._size < 1;\n\tif (v60) goto L_0052;\n\t// 49 NotImplemented \"Instruction DUP not yet implemented.\"\nL_0034:\n\tv102 = System.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::get_Item(v149, v108);\n\tv108 = v108 + 1;\n\tv79 = v149._size == v108;\n\tv98 = v102.sequencedPosition + v1;\n\tv102.sequencedPosition = v98;\n\tif (v79) goto L_0052;\n\tv149 = inSequence._sequencedObjs;\n\tv153 = inSequence._sequencedObjs == 0;\n\tv104 = ~v153;\n\tif (v104) goto L_0034;\n\tthrow System.NullReferenceException;\nL_0052:\n\treturn inSequence;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Sequence DoPrependInterval(Sequence inSequence, float interval)
		{
			List<ABSSequentiable> sequencedObjs = inSequence._sequencedObjs;
			inSequence.lastTweenInsertTime = 0f;
			float num2 = default(float);
			float num = inSequence.duration + num2;
			inSequence.duration = num;
			if (sequencedObjs.Count >= 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				int num3 = 0;
				object obj = default(object);
				while (true)
				{
					ABSSequentiable aBSSequentiable = sequencedObjs[num3];
					num3++;
					bool flag = sequencedObjs.Count == num3;
					float num4 = aBSSequentiable.sequencedPosition + (float)obj;
					aBSSequentiable.sequencedPosition = num4;
					if (flag)
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

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0xC0E87C", Offset = "0xC0E87C", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, callback, methodInfo, v25, v26, v27, v28, v29, atPosition, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = DG.Tweening.Core.SequenceCallback;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, callback, methodInfo, v25, v26, v27, v28, v29, atPosition, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A356DB]) = v40;\nL_001B:\n\tinSequence.lastTweenInsertTime = atPosition;\n\tv47 = new DG.Tweening.Core.SequenceCallback();\n\tDG.Tweening.Core.SequenceCallback::.ctor(v47, atPosition, callback);\n\tv47.sequencedPosition = atPosition;\n\tv47.sequencedEndPosition = atPosition;\n\tv61 = inSequence._sequencedObjs;\n\tv67 = v61._items;\n\tv50 = v61._version + 1;\n\tv61._version = v50;\n\tv107 = v61._size;\n\tv132 = v61._size < v67.Length;\n\tv133 = ~v132;\n\tif (v133) goto L_0049;\n\tv141 = v61._size + 1;\n\tv61._size = v141;\n\tv67[v107 @ X10_v4 (System.Int32)] = v47;\n\tgoto L_0054;\nL_0049:\n\tSystem.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::AddWithResize(v61, v47);\nL_0054:\n\tv74 = inSequence.duration >= atPosition;\n\tif (v74) goto L_005E;\n\tinSequence.duration = atPosition;\nL_005E:\n\treturn inSequence;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Sequence DoInsertCallback(Sequence inSequence, TweenCallback callback, float atPosition)
		{
			inSequence.lastTweenInsertTime = atPosition;
			SequenceCallback sequenceCallback = new SequenceCallback(atPosition, callback);
			sequenceCallback.sequencedPosition = atPosition;
			sequenceCallback.sequencedEndPosition = atPosition;
			List<ABSSequentiable> sequencedObjs = inSequence._sequencedObjs;
			ABSSequentiable[] items = sequencedObjs._items;
			int version = sequencedObjs._version + 1;
			sequencedObjs._version = version;
			int count = sequencedObjs.Count;
			if (sequencedObjs.Count < items.Length)
			{
				int size = sequencedObjs.Count + 1;
				sequencedObjs._size = size;
				items[count] = sequenceCallback;
			}
			else
			{
				sequencedObjs.Add(sequenceCallback);
			}
			if (inSequence.duration < atPosition)
			{
				inSequence.duration = atPosition;
			}
			return inSequence;
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0xC0E97C", Offset = "0xC0E97C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.delay >= elapsed;\n\tif (v12) goto L_0011;\n\treturnVal1 = elapsed - this.delay;\n\tthis.elapsedDelay = this.delay;\n\tthis.delayComplete = 1;\n\treturn returnVal1;\nL_0011:\n\tthis.elapsedDelay = elapsed;\n\treturn 0;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override float UpdateDelay(float elapsed)
		{
			if (delay < elapsed)
			{
				float result = elapsed - delay;
				elapsedDelay = delay;
				delayComplete = true;
				return result;
			}
			elapsedDelay = elapsed;
			return 0f;
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0xC0E9A8", Offset = "0xC0E9A8", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv37 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v37, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A356DC]) = v34;\nL_0014:\n\tDG.Tweening.Tween::Reset(this);\n\tv38 = this.sequencedTweens;\n\tv42 = v38._version + 1;\n\tv38._size = 0;\n\tv38._version = v42;\n\tv53 = v38._size < 1;\n\tif (v53) goto L_002D;\n\tSystem.Array::Clear(v38._items, 0, v38._size);\nL_002D:\n\tv84 = this._sequencedObjs;\n\tv91 = v84._version + 1;\n\tv84._size = 0;\n\tv84._version = v91;\n\tv102 = v84._size < 1;\n\tif (v102) goto L_0045;\n\tSystem.Array::Clear(v84._items, 0, v84._size);\nL_0045:\n\tthis.lastTweenInsertTime = 0f;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override void Reset()
		{
			base.Reset();
			List<Tween> list = sequencedTweens;
			int version = list._version + 1;
			list._size = 0;
			list._version = version;
			if (list.Count >= 1)
			{
				Array.Clear(list._items, 0, list.Count);
			}
			List<ABSSequentiable> sequencedObjs = _sequencedObjs;
			int version2 = sequencedObjs._version + 1;
			sequencedObjs._size = 0;
			sequencedObjs._version = version2;
			if (sequencedObjs.Count >= 1)
			{
				Array.Clear(sequencedObjs._items, 0, sequencedObjs.Count);
			}
			lastTweenInsertTime = 0f;
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0xC0EAE0", Offset = "0xC0EAE0", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv44 = Il2CppMethodInfo;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A356DD]) = v40;\nL_0016:\n\tv146 = this.sequencedTweens;\n\tv56 = v146._size < 1;\n\tif (v56) goto L_FFFFFFFF;\nL_002B:\n\tv61 = v71 - 1;\n\tv112 = System.Collections.Generic.List`1<DG.Tweening.Tween>::get_Item(v146, v61);\n\tv164 = DG.Tweening.Tween::Validate(v112);\n\tv166 = v164 == 0;\n\tif (v166) goto L_0053;\n\tv181 = v71 - v146._size;\n\tv182 = v181 < 0;\n\tv184 = v71 ^ v146._size;\n\tv185 = v71 ^ v181;\n\tv186 = v184 & v185;\n\tv187 = v186 < 0;\n\tv188 = v182 == v187;\n\tv75 = ~v188;\n\tv95 = v146._size == v71;\n\tif (v95) goto L_0053;\n\tv146 = this.sequencedTweens;\n\tv71 = v71 + 1;\n\tv190 = this.sequencedTweens == 0;\n\tv114 = ~v190;\n\tif (v114) goto L_002B;\n\tthrow System.NullReferenceException;\nL_0053:\n\tv169 = ~v151;\n\treturnVal1 = v169 & 1;\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override bool Validate()
		{
			List<Tween> list = sequencedTweens;
			bool flag;
			if (list.Count >= 1)
			{
				flag = true;
				int num = 1;
				while (true)
				{
					int index = num - 1;
					Tween tween = list[index];
					if (!tween.Validate())
					{
						break;
					}
					int num2 = num - list.Count;
					bool flag2 = num2 < 0;
					int num3 = num ^ list.Count;
					int num4 = num ^ num2;
					int num5 = num3 & num4;
					bool flag3 = num5 < 0;
					bool flag4 = flag2 == flag3;
					bool flag5 = !flag4;
					bool flag6 = list.Count == num;
					flag = flag5;
					if (flag6)
					{
						break;
					}
					list = sequencedTweens;
					num++;
					bool flag7 = sequencedTweens == null;
					bool flag8 = !flag7;
					flag = flag5;
					if (!flag8)
					{
						throw new NullReferenceException();
					}
				}
			}
			else
			{
				flag = false;
			}
			int num6 = ((!flag) ? 1 : 0);
			return (byte)(num6 & 1) != 0;
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0xC0EB9C", Offset = "0xC0EB9C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = DG.Tweening.Sequence::DoStartup(this);\n\treturn returnVal1;\n")]
		internal override bool Startup()
		{
			return DoStartup(this);
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0xC0EDE8", Offset = "0xC0EDE8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = DG.Tweening.Sequence::DoApplyTween(this, prevPosition, prevCompletedLoops, newCompletedSteps, useInversePosition, updateMode);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal override bool ApplyTween(float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode, UpdateNotice updateNotice)
		{
			return DoApplyTween(this, prevPosition, prevCompletedLoops, newCompletedSteps, useInversePosition, updateMode);
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0xC08B04", Offset = "0xC08B04", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = DG.Tweening.DOTween;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A356DE]) = v37;\nL_0017:\n\tgoto L_001E;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = DG.Tweening.DOTween;\nL_001E:\n\ts.autoKill = v46.defaultAutoKill;\n\ts.isRecyclable = v46.defaultRecyclable;\n\tv59 = v46.defaultAutoPlay != 3;\n\tif (v59) goto L_0032;\n\tgoto L_0041;\nL_0032:\n\tgoto L_0039;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv91 = DG.Tweening.DOTween;\n\tv136 = *([v91 @ X0_v11+B8]);\n\tv93 = *([v136 @ X8_v11+44]);\nL_0039:\n\tv78 = v46.defaultAutoPlay - 1;\n\tv74 = v78 == 0;\nL_0041:\n\ts.isPlaying = v85;\n\tgoto L_004B;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v82, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv135 = DG.Tweening.DOTween;\nL_004B:\n\ts.easeType = 1;\n\ts.loopType = v129.defaultLoopType;\n\ts.easeOvershootOrAmplitude = v129.defaultEaseOvershootOrAmplitude;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void Setup(Sequence s)
		{
			s.autoKill = DOTween.defaultAutoKill;
			s.isRecyclable = DOTween.defaultRecyclable;
			bool flag;
			if (DOTween.defaultAutoPlay == AutoPlay.All)
			{
				flag = true;
			}
			else
			{
				int num = (int)(DOTween.defaultAutoPlay - 1);
				bool flag2 = num == 0;
				flag = flag2;
			}
			s.isPlaying = flag;
			s.easeType = Ease.Linear;
			s.loopType = DOTween.defaultLoopType;
			s.easeOvershootOrAmplitude = DOTween.defaultEaseOvershootOrAmplitude;
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0xC0EBA0", Offset = "0xC0EBA0", Length = "0x248")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv177 = Il2CppMethodInfo;\n\tv178 = \"il2cpp_codegen_initialize_runtime_metadata\"(v177, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv223 = Il2CppMethodInfo;\n\tv224 = \"il2cpp_codegen_initialize_runtime_metadata\"(v223, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv306 = DG.Tweening.Core.TweenManager;\n\tv307 = \"il2cpp_codegen_initialize_runtime_metadata\"(v306, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv368 = DG.Tweening.Tween;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v368, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A356DF]) = v50;\nL_0029:\n\tv55 = s._sequencedObjs;\n\tv150 = s.sequencedTweens;\n\tv226 = v150._size | v55._size;\n\tv227 = v226 == 0;\n\tv228 = ~v227;\n\tif (v228) goto L_003C;\n\tv309 = DG.Tweening.Sequence::IsAnyCallbackSet(s);\n\tv288 = v309 == 0;\n\tif (v288) goto L_FFFFFFFF;\nL_003C:\n\ts.startupDone = 1;\n\tv313 = s.loops & 0x80000000;\n\tv314 = v313 == 0;\n\tv315 = ~v314;\n\tif (v315) goto L_FFFFFFFF;\n\tv142 = s.duration * s.loops;\n\tgoto L_0048;\nL_0048:\n\ts.fullDuration = v142;\n\tDG.Tweening.Sequence::StableSortSequencedObjs(s._sequencedObjs);\n\tv214 = ~s.<isRelative>k__BackingField;\n\tif (v214) goto L_0084;\n\tv432 = s.sequencedTweens;\n\tv96 = v432._size - 1;\n\tv92 = v432._size < 1;\n\tif (v92) goto L_0084;\nL_0064:\n\tv435 = System.Collections.Generic.List`1<DG.Tweening.Tween>::get_Item(v432, v173);\n\tv438 = ~s.isBlendable;\n\tv439 = ~v438;\n\tif (v439) goto L_0076;\n\tv156 = System.Collections.Generic.List`1<DG.Tweening.Tween>::get_Item(s.sequencedTweens, v173);\n\tv156.<isRelative>k__BackingField = 1;\nL_0076:\n\tv119 = v96 == v173;\n\tif (v119) goto L_0084;\n\tv432 = s.sequencedTweens;\n\tv173 = v173 + 1;\n\tv445 = s.sequencedTweens == 0;\n\tv160 = ~v445;\n\tif (v160) goto L_0064;\n\tthrow System.NullReferenceException;\nL_0084:\n\tv221 = ~s.isInverted;\n\tif (v221) goto L_00F0;\n\tv239 = v55._size < 1;\n\tif (v239) goto L_00F0;\nL_009F:\n\tv158 = System.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::get_Item(s._sequencedObjs, v174);\n\tv380 = v158.tweenType == 0;\n\tv362 = ~v380;\n\tif (v362) goto L_00D5;\n\tgoto L_FFFFFFFF;\n\tv401 = v401_asT == 0;\n\tif (v401) goto L_00F2;\n\tgoto L_00CE;\n\tv440 = \"il2cpp_codegen_runtime_class_init\"(v436, v331, v84, v58, v35, v36, v37, v38, v143, v140, v41, v42, v43, v44, v45, v46);\nL_00CE:\n\tv418 = v158.duration * v158.loops;\n\tv419 = DG.Tweening.Core.TweenManager::Goto(v158, v418, 0, 3);\n\tv158.isInverted = 1;\nL_00D5:\n\tv174 = v174 + 1;\n\tv259 = v55._size != v174;\n\tif (v259) goto L_009F;\n\tgoto L_00F0;\nL_00F0:\n\treturn returnVal1;\nL_00F2:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 168 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool DoStartup(Sequence s)
		{
			//IL_00b7: Expected I4, but got I8
			//IL_0329: Expected I4, but got O
			List<ABSSequentiable> sequencedObjs = s._sequencedObjs;
			List<Tween> list = s.sequencedTweens;
			bool result;
			if ((list.Count | sequencedObjs.Count) != 0 || IsAnyCallbackSet(s))
			{
				s.startupDone = true;
				float num = (((int)(s.loops & 0x80000000L) != 0) ? float.PositiveInfinity : (s.duration * (float)s.loops));
				s.fullDuration = num;
				StableSortSequencedObjs(s._sequencedObjs);
				if (s.isRelative)
				{
					List<Tween> list2 = s.sequencedTweens;
					int num2 = list2.Count - 1;
					if (list2.Count >= 1)
					{
						int num3 = 0;
						while (true)
						{
							Tween tween = list2[num3];
							if (!s.isBlendable)
							{
								Tween tween2 = s.sequencedTweens[num3];
								tween2.isRelative = true;
							}
							if (num2 == num3)
							{
								break;
							}
							list2 = s.sequencedTweens;
							num3++;
							if (s.sequencedTweens == null)
							{
								throw new NullReferenceException();
							}
						}
					}
				}
				bool flag = !s.isInverted;
				result = true;
				if (!flag)
				{
					bool flag2 = sequencedObjs.Count < 1;
					result = true;
					if (!flag2)
					{
						int num4 = 0;
						do
						{
							Tween tween3 = (Tween)s._sequencedObjs[num4];
							if (tween3.tweenType == TweenType.Tweener)
							{
								Tween tween4 = tween3 as Tween;
								if (tween4 == null)
								{
									InvalidCastException ex = new InvalidCastException();
									return (byte)(int)ex != 0;
								}
								float to = tween3.duration * (float)tween3.loops;
								bool flag3 = TweenManager.Goto(tween3, to, andPlay: false, UpdateMode.IgnoreOnComplete);
								tween3.isInverted = true;
							}
							num4++;
						}
						while (sequencedObjs.Count != num4);
						result = true;
					}
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0xC0EDF0", Offset = "0xC0EDF0", Length = "0x348")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv50 = System.Math;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, prevCompletedLoops, newCompletedSteps, useInversePosition, updateMode, methodInfo, v53, v54, prevPosition, v55, v56, v57, v58, v59, v60, v61);\n\tv64 = 1;\n\t*([1A356E0]) = v64;\nL_0026:\n\tv528 = s.<position>k__BackingField;\n\tv73 = s.isInverted == 0;\n\tv78 = ~v73;\n\tv84 = s.easeType == 1;\n\tif (v84) goto L_0050;\n\tv97 = DG.Tweening.Core.Easing.EaseManager::Evaluate(s.easeType, s.customEase, prevPosition, s.duration, s.easeOvershootOrAmplitude, s.easePeriod);\n\tv535 = s.duration * v97;\n\tv105 = DG.Tweening.Core.Easing.EaseManager::Evaluate(s.easeType, s.customEase, s.<position>k__BackingField, s.duration, s.easeOvershootOrAmplitude, s.easePeriod);\n\tv528 = s.duration * v105;\nL_0050:\n\tv120 = v78 ^ useInversePosition;\n\tv121 = s.loops + 1;\n\tv123 = v121 == 0;\n\tif (v123) goto L_006E;\n\tv138 = s.loops <= 1;\n\tif (v138) goto L_FFFFFFFF;\nL_006E:\n\tv158 = s.loopType != 1;\n\tif (v158) goto L_FFFFFFFF;\n\tv314 = prevCompletedLoops & 1;\n\tv308 = v535 < s.duration;\n\tif (v308) goto L_0084;\n\tv314 = v314 ^ 1;\n\tgoto L_0084;\nL_0084:\n\tv331 = v314 == 0;\n\tv337 = ~v331;\n\tif (s.isBackwards) goto L_FFFFFFFF;\n\tgoto L_00A0;\nL_00A0:\n\tv354 = s.isInverted == 0;\n\tv359 = ~v354;\n\tv596 = v198 ^ v359;\n\tv371 = newCompletedSteps < 1;\n\tif (v371) goto L_00DB;\n\tv372 = updateMode == 0;\n\tif (v372) goto L_FFFFFFFF;\n\tv453 = s.loops + 1;\n\tv468 = v453 == 0;\n\tif (v468) goto L_00C8;\n\tv406 = s.loops < 2;\n\tif (v406) goto L_00DB;\nL_00C8:\n\tv547 = newCompletedSteps & 1;\n\tv452 = v547 == 0;\n\tif (v452) goto L_00DB;\n\tv405 = s.loopType != 1;\n\tif (v405) goto L_00DB;\n\tv463 = v596 ^ 1;\n\tv535 = s.duration - v535;\nL_00DB:\n\tv466 = v120 == 0;\n\tif (v466) goto L_00F8;\n\tv503 = s.duration;\n\tv535 = s.duration - v535;\nL_00DF:\n\tv528 = v503 - v528;\nL_00F8:\n\treturnVal2 = DG.Tweening.Sequence::ApplyInternalCycle(s, v535, v528, updateMode, v120, v596, 0);\n\treturn returnVal2;\nL_0102:\n\tv599 = v386 - newCompletedSteps;\n\tv600 = v599 < 0;\n\tv601 = v599 == 0;\n\tv602 = v386 ^ newCompletedSteps;\n\tv603 = v386 ^ v599;\n\tv604 = v602 & v603;\n\tv605 = v604 < 0;\n\tv374 = v596 ^ 1;\n\tv606 = v600 == v605;\n\tv607 = ~v601;\n\tv608 = v606 & v607;\n\tv609 = ~v608;\n\tif (v609) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_0118:\n\tv645 = v384 == v386;\n\tif (v645) goto L_0182;\n\tv653 = v386 < 0;\n\tv654 = v386 == 0;\n\tv656 = v386 ^ v386;\n\tv657 = v386 & v656;\n\tv658 = v657 < 0;\n\tv659 = v653 == v658;\n\tv660 = ~v654;\n\tv661 = v659 & v660;\n\tv663 = v661 | v374;\n\tv664 = v653 == v658;\n\tv556 = ~v654;\n\tv665 = v664 & v556;\n\tv615 = ~v665;\n\tif (v615) goto L_FFFFFFFF;\n\tgoto L_0135;\nL_0135:\n\tv721 = v663 & 1;\n\tv722 = v721 == 0;\n\tv723 = ~v722;\n\tif (v723) goto L_0142;\n\tv738 = ~s.isBackwards;\n\tif (v738) goto L_013F;\n\tgoto L_0142;\nL_013F:\n\tv560 = s.duration - v399;\nL_0142:\n\tv746 = v596 == 0;\n\tv747 = ~v746;\n\tif (v747) goto L_014D;\n\tv403 = s.duration;\nL_014D:\n\tv591 = DG.Tweening.Sequence::ApplyInternalCycle(s, v560, v403, 0, v120, v596, 1);\n\tv753 = v591 == 0;\n\tv732 = ~v753;\n\tif (v732) goto L_01BA;\n\tv386 = v386 + 1;\n\tv593 = s.loops + 1;\n\tv759 = v593 == 0;\n\tif (v759) goto L_0171;\n\tv620 = s.loops < 2;\n\tif (v620) goto L_0118;\nL_0171:\n\tv554 = s.loopType != 1;\n\tif (v554) goto L_0177;\n\tgoto L_0177;\nL_0177:\n\tgoto L_0102;\nL_0182:\n\tv676 = s.completedLoops != s.completedLoops;\n\tif (v676) goto L_01A2;\n\tgoto L_018E;\n\tv724 = \"il2cpp_codegen_runtime_class_init\"(v681, v401, v394, v378, v376, methodInfo, v53, v54, v399, v617, v108, v106, v58, v59, v60, v61);\nL_018E:\n\t// 398 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv688 = v399 <= 1;\n\tif (v688) goto L_01C5;\nL_01A2:\n\tv714 = s.<active>k__BackingField == 0;\nL_01BA:\n\treturn v734;\nL_01C5:\n\tv408 = newCompletedSteps != 1;\n\tif (v408) goto L_01CB;\n\tv733 = ~s.isComplete;\n\tif (v733) goto L_01D0;\n\tgoto L_01BA;\nL_01CB:\n\tv751 = ~s.isComplete;\n\tv454 = ~v751;\n\tif (v454) goto L_00DB;\nL_01D0:\n\tv757 = v120 == 0;\n\tif (v757) goto L_01DE;\n\tv535 = s.duration;\nL_01DE:\n\tv511 = v403 <= 0;\n\tif (v511) goto L_01ED;\n\tv778 = s.loopType == 0;\n\tv779 = ~v778;\n\tif (v779) goto L_01ED;\n\tv786 = DG.Tweening.Sequence::ApplyInternalCycle(s, s.duration, 0f, 1, 0, 0, 0);\nL_01ED:\n\tv534 = v120 == 0;\n\tif (v534) goto L_00F8;\n\tv503 = s.duration;\n\tgoto L_00DF;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 353 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool DoApplyTween(Sequence s, float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode)
		{
			float num = s.position;
			bool flag = !s.isInverted;
			bool flag2 = !flag;
			bool flag3 = s.easeType == Ease.Linear;
			float num2 = prevPosition;
			if (!flag3)
			{
				float num3 = EaseManager.Evaluate(s.easeType, s.customEase, prevPosition, s.duration, s.easeOvershootOrAmplitude, s.easePeriod);
				num2 = s.duration * num3;
				float num4 = EaseManager.Evaluate(s.easeType, s.customEase, s.position, s.duration, s.easeOvershootOrAmplitude, s.easePeriod);
				num = s.duration * num4;
			}
			bool flag4 = flag2 ^ useInversePosition;
			int num5;
			if ((s.loops + 1 == 0 || s.loops > 1) && s.loopType == LoopType.Yoyo)
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
			bool flag5 = num5 == 0;
			bool flag6 = !flag5;
			bool flag7 = (s.isBackwards ? flag5 : flag6);
			bool flag8 = !s.isInverted;
			bool flag9 = !flag8;
			bool flag10 = flag7 ^ flag9;
			bool result;
			float num19;
			if (newCompletedSteps >= 1)
			{
				if (updateMode == UpdateMode.Update)
				{
					int num6 = 0;
					float num7 = num2;
					float num8 = 0f;
					float num15;
					while (true)
					{
						int num9 = num6 - newCompletedSteps;
						bool flag11 = num9 < 0;
						bool flag12 = num9 == 0;
						int num10 = num6 ^ newCompletedSteps;
						int num11 = num6 ^ num9;
						int num12 = num10 & num11;
						bool flag13 = num12 < 0;
						int num13 = (flag10 ? 1 : 0) ^ 1;
						bool flag14 = flag11 == flag13;
						bool flag15 = !flag12;
						int num14 = ((!(flag14 && flag15)) ? newCompletedSteps : num6);
						num15 = num7;
						while (num14 != num6)
						{
							bool flag16 = num6 < 0;
							bool flag17 = num6 == 0;
							int num16 = num6 ^ num6;
							int num17 = num6 & num16;
							bool flag18 = num17 < 0;
							bool flag19 = flag16 == flag18;
							bool flag20 = !flag17;
							bool flag21 = flag19 && flag20;
							int num18 = (flag21 ? 1 : 0) | num13;
							bool flag22 = flag16 == flag18;
							bool flag23 = !flag17;
							num7 = ((!(flag22 && flag23)) ? num15 : num8);
							if ((num18 & 1) == 0)
							{
								num7 = ((!s.isBackwards) ? (s.duration - num15) : num15);
							}
							bool flag24 = !flag10;
							bool flag25 = !flag24;
							num8 = 0f;
							if (!flag25)
							{
								num8 = s.duration;
							}
							bool flag26 = ApplyInternalCycle(s, num7, num8, default(UpdateMode), flag4, flag10, multiCycleStep: true);
							bool flag27 = !flag26;
							bool flag28 = !flag27;
							result = true;
							if (!flag28)
							{
								num6++;
								if (s.loops + 1 != 0)
								{
									bool flag29 = s.loops < 2;
									num15 = num7;
									if (flag29)
									{
										continue;
									}
								}
								goto IL_049a;
							}
							goto IL_07c8;
						}
						break;
						IL_049a:
						if (s.loopType == LoopType.Yoyo)
						{
							flag10 = (byte)num13 != 0;
						}
					}
					if (s.completedLoops == s.completedLoops)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
						if (!(num15 > float.Epsilon))
						{
							if (newCompletedSteps == 1)
							{
								if (s.isComplete)
								{
									result = false;
									goto IL_07c8;
								}
							}
							else if (s.isComplete)
							{
								goto IL_0737;
							}
							bool flag30 = !flag4;
							num2 = 0f;
							if (!flag30)
							{
								num2 = s.duration;
							}
							if (num8 > 0f && s.loopType == LoopType.Restart)
							{
								bool flag31 = ApplyInternalCycle(s, s.duration, 0f, UpdateMode.Goto, useInverse: false, prevPosIsInverse: false);
							}
							if (!flag4)
							{
								goto IL_0810;
							}
							num19 = s.duration;
							goto IL_083b;
						}
					}
					bool flag32 = !s.active;
					result = flag32;
					goto IL_07c8;
				}
				if ((s.loops + 1 == 0 || s.loops >= 2) && (newCompletedSteps & 1) != 0 && s.loopType == LoopType.Yoyo)
				{
					int num20 = (flag10 ? 1 : 0) ^ 1;
					num2 = s.duration - num2;
					flag10 = (byte)num20 != 0;
				}
			}
			goto IL_0737;
			IL_083b:
			num = num19 - num;
			goto IL_0810;
			IL_0810:
			return ApplyInternalCycle(s, num2, num, updateMode, flag4, flag10);
			IL_0737:
			if (!flag4)
			{
				goto IL_0810;
			}
			num19 = s.duration;
			num2 = s.duration - num2;
			goto IL_083b;
			IL_07c8:
			return result;
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0xC0F2C4", Offset = "0xC0F2C4", Length = "0x744")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv52 = DG.Tweening.DOTween;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, updateMode, useInverse, prevPosIsInverse, multiCycleStep, methodInfo, v55, v56, fromPos, toPos, v57, v58, v59, v60, v61, v62);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, updateMode, useInverse, prevPosIsInverse, multiCycleStep, methodInfo, v55, v56, fromPos, toPos, v57, v58, v59, v60, v61, v62);\n\tv331 = Il2CppMethodInfo;\n\tv332 = \"il2cpp_codegen_initialize_runtime_metadata\"(v331, updateMode, useInverse, prevPosIsInverse, multiCycleStep, methodInfo, v55, v56, fromPos, toPos, v57, v58, v59, v60, v61, v62);\n\tv428 = Il2CppMethodInfo;\n\tv429 = \"il2cpp_codegen_initialize_runtime_metadata\"(v428, updateMode, useInverse, prevPosIsInverse, multiCycleStep, methodInfo, v55, v56, fromPos, toPos, v57, v58, v59, v60, v61, v62);\n\tv452 = Il2CppMethodInfo;\n\tv453 = \"il2cpp_codegen_initialize_runtime_metadata\"(v452, updateMode, useInverse, prevPosIsInverse, multiCycleStep, methodInfo, v55, v56, fromPos, toPos, v57, v58, v59, v60, v61, v62);\n\tv658 = Il2CppMethodInfo;\n\tv659 = \"il2cpp_codegen_initialize_runtime_metadata\"(v658, updateMode, useInverse, prevPosIsInverse, multiCycleStep, methodInfo, v55, v56, fromPos, toPos, v57, v58, v59, v60, v61, v62);\n\tv726 = DG.Tweening.Core.TweenManager;\n\tv727 = \"il2cpp_codegen_initialize_runtime_metadata\"(v726, updateMode, useInverse, prevPosIsInverse, multiCycleStep, methodInfo, v55, v56, fromPos, toPos, v57, v58, v59, v60, v61, v62);\n\tv760 = DG.Tweening.Tween;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v760, updateMode, useInverse, prevPosIsInverse, multiCycleStep, methodInfo, v55, v56, fromPos, toPos, v57, v58, v59, v60, v61, v62);\n\tv66 = 1;\n\t*([1A356E1]) = v66;\nL_003A:\n\tv71 = s._sequencedObjs;\n\tv540 = v71._size;\n\tv343 = toPos >= fromPos;\n\tif (v343) goto L_01CD;\n\tv433 = v71._size < 1;\n\tv864 = v71._size - 1;\n\tif (v433) goto L_FFFFFFFF;\n\tv462 = updateMode == 0;\n\tv468 = v462 & prevPosIsInverse;\nL_0069:\n\tv668 = ~s.<active>k__BackingField;\n\tif (v668) goto L_FFFFFFFF;\n\tv316 = s.isPlaying ^ 0xFF;\n\tv547 = s.isPlaying & v316;\n\tv220 = v547 == 0;\n\tv170 = ~v220;\n\tif (v170) goto L_FFFFFFFF;\n\tv265 = System.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::get_Item(s._sequencedObjs, v864);\n\tv765 = v265.sequencedEndPosition < toPos;\n\tif (v765) goto L_009F;\n\tv794 = v265.sequencedPosition <= fromPos;\n\tif (v794) goto L_00AF;\nL_009F:\n\tv567 = v864 - 1;\n\tv513 = v864 > 0;\n\tif (v513) goto L_0069;\n\tgoto L_FFFFFFFF;\nL_00AF:\n\tv805 = v265.tweenType != 2;\n\tif (v805) goto L_00B8;\n\tv852 = ~v468;\n\tif (v852) goto L_009F;\n\tv849 = DG.Tweening.Tween::OnTweenCallback(v265.onStart, s);\n\tgoto L_009F;\nL_00B8:\n\tv420 = *([v265 @ X0_v45 (DG.Tweening.Tween)]);\n\tv360 = *([v510 @ X29_v17 (Il2CppClass<DG.Tweening.Tween>)]);\n\tv1018 = *([v420 @ X8_v65 (Il2CppClass<DG.Tweening.Tween>)+130]) < *([v360 @ X1_v21+130]);\n\tv407 = ~v1018;\n\tv368 = ~v407;\n\tif (v368) goto L_03AE;\n\tv101 = *([v360 @ X1_v21+130]) << 3;\n\tv1031 = *([v420 @ X8_v65 (Il2CppClass<DG.Tweening.Tween>)+C8]) + v101;\n\tv171 = *([v1031 @ X8_v67-8]) != v360;\n\tif (v171) goto L_03AE;\n\tv853 = ~v265.startupDone;\n\tif (v853) goto L_009F;\n\tv265.isBackwards = 1;\n\tv1044 = toPos - v265.sequencedPosition;\n\tv95 = UnityEngine.Mathf::Max(v1044, 0f);\n\tv1053 = ~s.isInverted;\n\tif (v1053) goto L_00E8;\n\tv95 = v265.fullDuration - v95;\nL_00E8:\n\tgoto L_00EF;\n\tv1105 = \"il2cpp_codegen_runtime_class_init\"(v1073, v360, v142, v89, multiCycleStep, methodInfo, v55, v56, v1070, toPos, v57, v58, v59, v60, v61, v62);\nL_00EF:\n\tv851 = DG.Tweening.Core.TweenManager::Goto(v265, v95, 0, updateMode);\n\tv1127 = v851 == 0;\n\tif (v1127) goto L_0153;\n\tgoto L_0106;\n\tv1140 = \"il2cpp_codegen_runtime_class_init\"(v1133, v132, v143, v90, multiCycleStep, methodInfo, v55, v56, v126, toPos, v57, v58, v59, v60, v61, v62);\n\tv1141 = DG.Tweening.DOTween;\nL_0106:\n\tv221 = v1142.nestedTweenFailureBehaviour == 1;\n\tif (v221) goto L_FFFFFFFF;\n\tv317 = s.sequencedTweens;\n\tv172 = v317._size != 1;\n\tif (v172) goto L_013A;\n\tv318 = s._sequencedObjs;\n\tv729 = v318._size != 1;\n\tif (v729) goto L_013A;\n\tv748 = DG.Tweening.Sequence::IsAnyCallbackSet(s);\n\tv750 = v748 == 0;\n\tif (v750) goto L_FFFFFFFF;\nL_013A:\n\tgoto L_013F;\n\tv1181 = \"il2cpp_codegen_runtime_class_init\"(v1168, v132, v143, v90, multiCycleStep, methodInfo, v55, v56, v126, toPos, v57, v58, v59, v60, v61, v62);\nL_013F:\n\tDG.Tweening.Core.TweenManager::Despawn(v265, 0);\n\tSystem.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::RemoveAt(s._sequencedObjs, v864);\n\tv850 = System.Collections.Generic.List`1<DG.Tweening.Tween>::Remove(s.sequencedTweens, v265);\n\tv864 = v864 - 1;\n\tgoto L_009F;\nL_0153:\n\tv854 = multiCycleStep == 0;\n\tif (v854) goto L_009F;\n\tv806 = v265.tweenType != 1;\n\tif (v806) goto L_009F;\n\tv1149 = s.<position>k__BackingField < 0;\n\tv847 = ~v1149;\n\tv832 = s.<position>k__BackingField == 0;\n\tv1150 = ~v847;\n\tv807 = v1150 | v832;\n\tif (v807) goto L_0174;\n\tv1159 = s.completedLoops == 0;\n\tv1160 = ~v1159;\n\tif (v1160) goto L_0176;\n\tv1240 = s.isBackwards;\n\tgoto L_FFFFFFFF;\nL_0174:\n\tv855 = s.completedLoops == 0;\n\tif (v855) goto L_01C1;\nL_0176:\n\tv1223 = s.isBackwards;\n\tv1174 = ~s.isBackwards;\n\tif (v1174) goto L_FFFFFFFF;\n\tv1187 = s.completedLoops >= s.loops;\n\tif (v1187) goto L_018A;\n\tgoto L_0196;\n\tgoto L_0196;\nL_018A:\n\tv1239 = s.loops + 1;\n\tv1232 = v1239 == 0;\nL_0196:\n\tv1246 = v1223 == 0;\n\tv808 = ~v1246;\n\tif (v265.isBackwards) goto L_FFFFFFFF;\n\tgoto L_01AD;\nL_01AD:\n\tv797 = v1319 ^ useInverse;\n\tv1320 = ~v1240;\n\tif (v1320) goto L_01BE;\n\tv1327 = useInverse == 0;\n\tv1328 = ~v1327;\n\tif (v1328) goto L_01BE;\n\tv1335 = v797 ^ prevPosIsInverse;\n\tv1338 = v1335 == 0;\n\tif (v1338) goto L_01BA;\nL_01B9:\n\tv800 = v265.duration;\nL_01BA:\n\tv265.<position>k__BackingField = v800;\n\tgoto L_009F;\nL_01BE:\n\tv1332 = v797 == 0;\n\tif (v1332) goto L_01B9;\n\tgoto L_01BA;\nL_01C1:\n\tv265.<position>k__BackingField = 0f;\n\tgoto L_009F;\nL_01CD:\n\tv450 = v71._size < 1;\n\tif (v450) goto L_FFFFFFFF;\nL_01D8:\n\tv724 = ~s.<active>k__BackingField;\n\tif (v724) goto L_FFFFFFFF;\n\tv321 = s.isPlaying ^ 0xFF;\n\tv549 = s.isPlaying & v321;\n\tv224 = v549 == 0;\n\tv174 = ~v224;\n\tif (v174) goto L_FFFFFFFF;\n\tv270 = System.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::get_Item(s._sequencedObjs, v978);\n\tv782 = v270.sequencedPosition <= toPos;\n\tif (v782) goto L_0213;\nL_01FA:\n\tv978 = v978 + 1;\n\tv514 = v978 < v540;\n\tif (v514) goto L_01D8;\n\tgoto L_FFFFFFFF;\nL_0213:\n\tv993 = v270.sequencedPosition <= 0;\n\tif (v993) goto L_0222;\n\tv996 = v270.sequencedEndPosition < fromPos;\n\tv951 = ~v996;\n\tv943 = v270.sequencedEndPosition - fromPos;\n\tv923 = v943 == 0;\n\tv997 = ~v951;\n\tv882 = v997 | v923;\n\tif (v882) goto L_01FA;\nL_0222:\n\tv1008 = v270.sequencedPosition < 0;\n\tv1009 = ~v1008;\n\tv1012 = v270.sequencedPosition == 0;\n\tv1017 = ~v1012;\n\tv883 = v1009 & v1017;\n\tif (v883) goto L_0243;\n\tv934 = v270.sequencedEndPosition < fromPos;\n\tif (v934) goto L_01FA;\nL_0243:\n\tv884 = v270.tweenType != 2;\n\tif (v884) goto L_0272;\n\tv1033 = updateMode == 0;\n\tv964 = ~v1033;\n\tif (v964) goto L_01FA;\n\tv1037 = ~s.isBackwards;\n\tv1038 = ~v1037;\n\tif (v1038) goto L_0254;\n\tv1047 = useInverse == 0;\n\tv1048 = ~v1047;\n\tif (v1048) goto L_0254;\n\tv1050 = prevPosIsInverse == 0;\n\tif (v1050) goto L_0260;\nL_0254:\n\tv965 = s.isBackwards & useInverse;\n\tv926 = v965 == 0;\n\tif (v926) goto L_01FA;\n\tv1056 = prevPosIsInverse == 0;\n\tv966 = ~v1056;\n\tif (v966) goto L_01FA;\nL_0260:\n\tv961 = DG.Tweening.Tween::OnTweenCallback(v270.onStart, s);\n\tgoto L_01FA;\nL_0272:\n\tgoto L_FFFFFFFF;\n\tv370 = v370_asT == 0;\n\tif (v370) goto L_03AE;\n\tv1051 = toPos - v270.sequencedPosition;\n\tv97 = UnityEngine.Mathf::Max(v1051, 0f);\n\tv1057 = v270.sequencedEndPosition < toPos;\n\tv1058 = ~v1057;\n\tv1059 = v270.sequencedEndPosition - toPos;\n\tv1061 = v1059 == 0;\n\tv1066 = ~v1061;\n\tv1067 = v1058 & v1066;\n\tif (v1067) goto L_02AE;\n\tv1078 = ~v270.startupDone;\n\tv1079 = ~v1078;\n\tif (v1079) goto L_02AB;\n\tgoto L_02A0;\n\tv1128 = \"il2cpp_codegen_runtime_class_init\"(v1110, v361, v147, v91, multiCycleStep, methodInfo, v55, v56, v1051, v83, v57, v58, v59, v60, v61, v62);\nL_02A0:\n\tDG.Tweening.Core.TweenManager::ForceInit(v270, 1);\nL_02AB:\n\tv1088 = v97 >= v270.fullDurati\n// ... truncated")]
		private static bool ApplyInternalCycle(Sequence s, float fromPos, float toPos, UpdateMode updateMode, bool useInverse, bool prevPosIsInverse, bool multiCycleStep = false)
		{
			//IL_00a4: Expected I, but got O
			//IL_01f3: Expected I, but got O
			//IL_01fb: Expected O, but got I
			//IL_0f03: Expected I4, but got O
			//IL_026b: Expected O, but got I
			List<ABSSequentiable> sequencedObjs = s._sequencedObjs;
			int num = sequencedObjs.Count;
			if (toPos < fromPos)
			{
				bool flag = sequencedObjs.Count < 1;
				int num2 = sequencedObjs.Count - 1;
				if (flag)
				{
					goto IL_0ed9;
				}
				bool flag2 = updateMode == UpdateMode.Update;
				bool flag3 = flag2 && prevPosIsInverse;
				nint num3 = (nint)typeof(Tween);
				while (s.active)
				{
					int num4 = (s.isPlaying ? 1 : 0) ^ 0xFF;
					Tween tween;
					bool flag8;
					bool flag9;
					if (((s.isPlaying ? 1u : 0u) & (uint)num4) == 0)
					{
						tween = (Tween)s._sequencedObjs[num2];
						if (!(tween.sequencedEndPosition < toPos) && !(tween.sequencedPosition > fromPos))
						{
							if (tween.tweenType != TweenType.Callback)
							{
								nint num5 = (nint)tween;
								object obj = num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ X8_v65 (Il2CppClass<DG.Tweening.Tween>)+130]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ X1_v21+130]");
								if (num6 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ X1_v21+130]");
									int num7 = (int)((nint)0 << 3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ X8_v65 (Il2CppClass<DG.Tweening.Tween>)+C8]");
									object obj2 = (nint)0 + (nint)num7;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ X8_v67-8]");
									if (0 == (nint)obj)
									{
										if (tween.startupDone)
										{
											tween.isBackwards = true;
											float a = toPos - tween.sequencedPosition;
											float num8 = Mathf.Max(a, 0f);
											if (s.isInverted)
											{
												num8 = tween.fullDuration - num8;
											}
											if (!TweenManager.Goto(tween, num8, andPlay: false, updateMode))
											{
												if (multiCycleStep && tween.tweenType == TweenType.Sequence)
												{
													bool flag4 = s.position < 0f;
													bool flag5 = !flag4;
													bool flag6 = s.position == 0f;
													bool flag7 = !flag5;
													if (!(flag7 || flag6))
													{
														if (s.completedLoops == 0)
														{
															flag8 = s.isBackwards;
															goto IL_0f44;
														}
													}
													else if (s.completedLoops == 0)
													{
														tween.position = 0f;
														goto IL_015a;
													}
													flag9 = s.isBackwards;
													if (s.isBackwards)
													{
														if (s.completedLoops < s.loops)
														{
															flag8 = true;
															goto IL_0f44;
														}
														int num9 = s.loops + 1;
														bool flag10 = num9 == 0;
														flag9 = flag10;
														flag8 = true;
													}
													else
													{
														flag8 = false;
													}
													goto IL_0f52;
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
													List<ABSSequentiable> sequencedObjs2 = s._sequencedObjs;
													if (sequencedObjs2.Count == 1 && !IsAnyCallbackSet(s))
													{
														break;
													}
												}
												TweenManager.Despawn(tween, modifyActiveLists: false);
												s._sequencedObjs.RemoveAt(num2);
												bool flag11 = s.sequencedTweens.Remove(tween);
												num2--;
											}
										}
										goto IL_015a;
									}
								}
								goto IL_0ef5;
							}
							if (flag3)
							{
								bool flag12 = Tween.OnTweenCallback(tween.onStart, s);
							}
						}
						goto IL_015a;
					}
					goto IL_0ed9;
					IL_0fa5:
					float num10;
					tween.position = num10;
					goto IL_015a;
					IL_0f44:
					flag9 = true;
					goto IL_0f52;
					IL_0f52:
					bool flag13 = !flag9;
					bool flag14 = !flag13;
					bool flag15 = (tween.isBackwards ? flag13 : flag14);
					bool flag16 = flag15 ^ useInverse;
					if (flag8 && !useInverse)
					{
						bool flag17 = flag16 ^ prevPosIsInverse;
						bool flag18 = !flag17;
						num10 = 0f;
						if (!flag18)
						{
							goto IL_0665;
						}
					}
					else
					{
						if (!flag16)
						{
							goto IL_0665;
						}
						num10 = 0f;
					}
					goto IL_0fa5;
					IL_0665:
					num10 = tween.duration;
					goto IL_0fa5;
					IL_015a:
					int num11 = num2 - 1;
					bool flag19 = num2 > 0;
					num2 = num11;
					if (flag19)
					{
						continue;
					}
					goto IL_0ed9;
				}
			}
			else
			{
				if (sequencedObjs.Count < 1)
				{
					goto IL_0ed9;
				}
				int num12 = 0;
				while (s.active)
				{
					int num13 = (s.isPlaying ? 1 : 0) ^ 0xFF;
					Tween tween2;
					bool flag37;
					bool flag38;
					if (((s.isPlaying ? 1u : 0u) & (uint)num13) == 0)
					{
						tween2 = (Tween)s._sequencedObjs[num12];
						if (!(tween2.sequencedPosition > toPos))
						{
							if (tween2.sequencedPosition > 0f)
							{
								bool flag20 = tween2.sequencedEndPosition < fromPos;
								bool flag21 = !flag20;
								float num14 = tween2.sequencedEndPosition - fromPos;
								bool flag22 = num14 == 0f;
								bool flag23 = !flag21;
								if (flag23 || flag22)
								{
									goto IL_0775;
								}
							}
							bool flag24 = tween2.sequencedPosition < 0f;
							bool flag25 = !flag24;
							bool flag26 = tween2.sequencedPosition == 0f;
							bool flag27 = !flag26;
							if ((flag25 && flag27) || !(tween2.sequencedEndPosition < fromPos))
							{
								if (tween2.tweenType == TweenType.Callback)
								{
									if (updateMode == UpdateMode.Update && ((!s.isBackwards && !useInverse && !prevPosIsInverse) || (s.isBackwards && useInverse && !prevPosIsInverse)))
									{
										bool flag28 = Tween.OnTweenCallback(tween2.onStart, s);
									}
								}
								else
								{
									Tween tween3 = tween2 as Tween;
									if (tween3 == null)
									{
										goto IL_0ef5;
									}
									float a2 = toPos - tween2.sequencedPosition;
									float num15 = Mathf.Max(a2, 0f);
									bool flag29 = tween2.sequencedEndPosition < toPos;
									bool flag30 = !flag29;
									float num16 = tween2.sequencedEndPosition - toPos;
									bool flag31 = num16 == 0f;
									bool flag32 = !flag31;
									if (!(flag30 && flag32))
									{
										if (!tween2.startupDone)
										{
											TweenManager.ForceInit(tween2, isSequenced: true);
										}
										if (num15 < tween2.fullDuration)
										{
											num15 = tween2.fullDuration;
										}
									}
									tween2.isBackwards = false;
									if (s.isInverted)
									{
										num15 = tween2.fullDuration - num15;
									}
									if (!TweenManager.Goto(tween2, num15, andPlay: false, updateMode))
									{
										if (multiCycleStep && tween2.tweenType == TweenType.Sequence)
										{
											bool flag33 = s.position < 0f;
											bool flag34 = !flag33;
											bool flag35 = s.position == 0f;
											bool flag36 = !flag34;
											if (!(flag36 || flag35))
											{
												if (s.completedLoops == 0)
												{
													flag37 = s.isBackwards;
													goto IL_101f;
												}
											}
											else if (s.completedLoops == 0)
											{
												tween2.position = 0f;
												goto IL_0775;
											}
											if (s.isBackwards)
											{
												flag38 = false;
												flag37 = true;
											}
											else
											{
												if (s.completedLoops < s.loops)
												{
													flag37 = false;
													goto IL_101f;
												}
												int num17 = s.loops + 1;
												bool flag39 = num17 == 0;
												flag38 = flag39;
												flag37 = false;
											}
											goto IL_102d;
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
											List<ABSSequentiable> sequencedObjs3 = s._sequencedObjs;
											if (sequencedObjs3.Count == 1 && !IsAnyCallbackSet(s))
											{
												break;
											}
										}
										TweenManager.Despawn(tween2, modifyActiveLists: false);
										s._sequencedObjs.RemoveAt(num12);
										bool flag40 = s.sequencedTweens.Remove(tween2);
										num12--;
										num--;
									}
								}
							}
						}
						goto IL_0775;
					}
					goto IL_0ed9;
					IL_101f:
					flag38 = true;
					goto IL_102d;
					IL_0775:
					num12++;
					if (num12 < num)
					{
						continue;
					}
					goto IL_0ed9;
					IL_1080:
					float num18;
					tween2.position = num18;
					goto IL_0775;
					IL_0e9c:
					num18 = tween2.duration;
					goto IL_1080;
					IL_102d:
					bool flag41 = !flag38;
					bool flag42 = !flag41;
					bool flag43 = (tween2.isBackwards ? flag41 : flag42);
					bool flag44 = flag43 ^ useInverse;
					if (flag37 && !useInverse)
					{
						bool flag45 = flag44 ^ prevPosIsInverse;
						bool flag46 = !flag45;
						num18 = 0f;
						if (!flag46)
						{
							goto IL_0e9c;
						}
					}
					else
					{
						if (!flag44)
						{
							goto IL_0e9c;
						}
						num18 = 0f;
					}
					goto IL_1080;
				}
			}
			return true;
			IL_0ed9:
			return false;
			IL_0ef5:
			InvalidCastException ex = new InvalidCastException();
			return (byte)(int)ex != 0;
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0xC0F198", Offset = "0xC0F198", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv122 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v122, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A356E2]) = v46;\nL_0029:\n\tv62 = list._size < 2;\n\tif (v62) goto L_0080;\nL_0033:\n\tv199 = System.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::get_Item(list, v119);\nL_0037:\n\tv64 = v138 - 1;\n\tv112 = System.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::get_Item(list, v64);\n\tv259 = v112.sequencedPosition <= v199.sequencedPosition;\n\tif (v259) goto L_0069;\n\tv263 = System.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::get_Item(list, v64);\n\tSystem.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::set_Item(list, v138, v263);\n\tv246 = v64 + 1;\n\tv234 = v246 >= 2;\n\tif (v234) goto L_0037;\nL_0069:\n\tSystem.Collections.Generic.List`1<DG.Tweening.Core.ABSSequentiable>::set_Item(list, v138, v199);\n\tv119 = v119 + 1;\n\tv143 = v119 != list._size;\n\tif (v143) goto L_0033;\nL_0080:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void StableSortSequencedObjs(List<ABSSequentiable> list)
		{
			if (list.Count < 2)
			{
				return;
			}
			int num = 1;
			do
			{
				ABSSequentiable aBSSequentiable = list[num];
				int num2 = num;
				while (true)
				{
					int num3 = num2 - 1;
					ABSSequentiable aBSSequentiable2 = list[num3];
					if (!(aBSSequentiable2.sequencedPosition > aBSSequentiable.sequencedPosition))
					{
						break;
					}
					ABSSequentiable value = list[num3];
					list[num2] = value;
					int num4 = num3 + 1;
					bool flag = num4 >= 2;
					num2 = num3;
					if (!flag)
					{
						num2 = 0;
						break;
					}
				}
				list[num2] = aBSSequentiable;
				num++;
			}
			while (num != list.Count);
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0xC0F138", Offset = "0xC0F138", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = s.onComplete == 0;\n\tv6 = ~v5;\n\tif (v6) goto L_FFFFFFFF;\n\tv24 = s.onKill == 0;\n\tv25 = ~v24;\n\tif (v25) goto L_FFFFFFFF;\n\tv39 = s.onPause == 0;\n\tv34 = ~v39;\n\tif (v34) goto L_FFFFFFFF;\n\tv87 = s.onPlay == 0;\n\tv35 = ~v87;\n\tif (v35) goto L_FFFFFFFF;\n\tv88 = s.onRewind == 0;\n\tv36 = ~v88;\n\tif (v36) goto L_FFFFFFFF;\n\tv89 = s.onStart == 0;\n\tv37 = ~v89;\n\tif (v37) goto L_FFFFFFFF;\n\tv33 = s.onStepComplete == 0;\n\tif (v33) goto L_0028;\nL_0022:\n\treturn returnVal2;\nL_0028:\n\tv57 = s.onUpdate == 0;\n\tv42 = ~v57;\n\tgoto L_0022;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
