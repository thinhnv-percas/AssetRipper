using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751F2C", Offset = "0x751F2C")]
	[Token(Token = "0x200011A")]
	public abstract class EaseFsmAction : FsmStateAction
	{
		[Token(Token = "0x200047C")]
		protected delegate float EasingFunction(float start, float end, float value);

		[Token(Token = "0x200047D")]
		public enum EaseType
		{
			[Token(Token = "0x4002126")]
			easeInQuad = 0,
			[Token(Token = "0x4002127")]
			easeOutQuad = 1,
			[Token(Token = "0x4002128")]
			easeInOutQuad = 2,
			[Token(Token = "0x4002129")]
			easeInCubic = 3,
			[Token(Token = "0x400212A")]
			easeOutCubic = 4,
			[Token(Token = "0x400212B")]
			easeInOutCubic = 5,
			[Token(Token = "0x400212C")]
			easeInQuart = 6,
			[Token(Token = "0x400212D")]
			easeOutQuart = 7,
			[Token(Token = "0x400212E")]
			easeInOutQuart = 8,
			[Token(Token = "0x400212F")]
			easeInQuint = 9,
			[Token(Token = "0x4002130")]
			easeOutQuint = 10,
			[Token(Token = "0x4002131")]
			easeInOutQuint = 11,
			[Token(Token = "0x4002132")]
			easeInSine = 12,
			[Token(Token = "0x4002133")]
			easeOutSine = 13,
			[Token(Token = "0x4002134")]
			easeInOutSine = 14,
			[Token(Token = "0x4002135")]
			easeInExpo = 15,
			[Token(Token = "0x4002136")]
			easeOutExpo = 16,
			[Token(Token = "0x4002137")]
			easeInOutExpo = 17,
			[Token(Token = "0x4002138")]
			easeInCirc = 18,
			[Token(Token = "0x4002139")]
			easeOutCirc = 19,
			[Token(Token = "0x400213A")]
			easeInOutCirc = 20,
			[Token(Token = "0x400213B")]
			linear = 21,
			[Token(Token = "0x400213C")]
			spring = 22,
			[Token(Token = "0x400213D")]
			bounce = 23,
			[Token(Token = "0x400213E")]
			easeInBack = 24,
			[Token(Token = "0x400213F")]
			easeOutBack = 25,
			[Token(Token = "0x4002140")]
			easeInOutBack = 26,
			[Token(Token = "0x4002141")]
			elastic = 27,
			[Token(Token = "0x4002142")]
			punch = 28
		}

		[RequiredField]
		[Token(Token = "0x4001090")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat time;

		[Token(Token = "0x4001091")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat speed;

		[Token(Token = "0x4001092")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat delay;

		[Token(Token = "0x4001093")]
		[FieldOffset(Offset = "0x68")]
		public EaseType easeType;

		[Token(Token = "0x4001094")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool reverse;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1EFC", Offset = "0x7A1EFC")]
		[Token(Token = "0x4001095")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1F34", Offset = "0x7A1F34")]
		[Token(Token = "0x4001096")]
		[FieldOffset(Offset = "0x80")]
		public bool realTime;

		[Token(Token = "0x4001097")]
		[FieldOffset(Offset = "0x88")]
		protected EasingFunction ease;

		[Token(Token = "0x4001098")]
		[FieldOffset(Offset = "0x90")]
		protected float runningTime;

		[Token(Token = "0x4001099")]
		[FieldOffset(Offset = "0x94")]
		protected float lastTime;

		[Token(Token = "0x400109A")]
		[FieldOffset(Offset = "0x98")]
		protected float startTime;

		[Token(Token = "0x400109B")]
		[FieldOffset(Offset = "0x9C")]
		protected float deltaTime;

		[Token(Token = "0x400109C")]
		[FieldOffset(Offset = "0xA0")]
		protected float delayTime;

		[Token(Token = "0x400109D")]
		[FieldOffset(Offset = "0xA4")]
		protected float percentage;

		[Token(Token = "0x400109E")]
		[FieldOffset(Offset = "0xA8")]
		protected internal float[] fromFloats;

		[Token(Token = "0x400109F")]
		[FieldOffset(Offset = "0xB0")]
		protected internal float[] toFloats;

		[Token(Token = "0x40010A0")]
		[FieldOffset(Offset = "0xB8")]
		protected internal float[] resultFloats;

		[Token(Token = "0x40010A1")]
		[FieldOffset(Offset = "0xC0")]
		protected internal bool finishAction;

		[Token(Token = "0x40010A2")]
		[FieldOffset(Offset = "0xC1")]
		protected bool start;

		[Token(Token = "0x40010A3")]
		[FieldOffset(Offset = "0xC2")]
		protected bool finished;

		[Token(Token = "0x40010A4")]
		[FieldOffset(Offset = "0xC3")]
		protected internal bool isRunning;

		[Token(Token = "0x6000658")]
		[Address(RVA = "0xB71154", Offset = "0xB71154", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1F0BAA8]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022900]) = v42;\nL_0016:\n\tthis.easeType = 0x15;\n\tv47 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v47);\n\tv47.value = 1f;\n\tthis.time = v47;\n\tv53 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v53);\n\tv53.useVariable = 1;\n\tthis.delay = v53;\n\tv61 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v61);\n\tv61.useVariable = 1;\n\tthis.speed = v61;\n\tv62 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v62);\n\tv62.value = 0;\n\tthis.realTime = 0;\n\tthis.reverse = v62;\n\tthis.finishEvent = 0;\n\tthis.percentage = 0f;\n\tthis.ease = 0;\n\tthis.runningTime = 0f;\n\t// 74 NewArr v100 @ X0_v14 (System.Single[]), typeof(System.Single[]), 0\n\tthis.fromFloats = v100;\n\t// 78 NewArr v103 @ X0_v16 (System.Single[]), typeof(System.Single[]), 0\n\tthis.toFloats = v103;\n\t// 82 NewArr v84 @ X0_v18 (System.Single[]), typeof(System.Single[]), 0\n\tthis.resultFloats = v84;\n\tthis.finishAction = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			easeType = EaseType.linear;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.Value = 1f;
			time = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			delay = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			speed = fsmFloat3;
			FsmBool fsmBool = new FsmBool();
			fsmBool.value = false;
			realTime = false;
			reverse = fsmBool;
			finishEvent = null;
			percentage = 0f;
			ease = null;
			runningTime = 0f;
			float[] array = new float[0];
			fromFloats = array;
			float[] array2 = new float[0];
			toFloats = array2;
			float[] array3 = new float[0];
			resultFloats = array3;
			finishAction = false;
			start = false;
			finished = false;
			isRunning = false;
		}

		[Token(Token = "0x6000659")]
		[Address(RVA = "0xB71460", Offset = "0xB71460", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.finished = 0;\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::SetEasingFunction(this);\n\tthis.runningTime = 0f;\n\tv14 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv65 = v14 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0027;\n\tv82 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\n\tv73 = v82 == 0;\n\tv68 = ~v73;\n\tv67 = ~v68;\n\tif (v67) goto L_FFFFFFFF;\n\tgoto L_0027;\nL_0027:\n\tthis.percentage = v75;\n\tthis.finishAction = 0;\n\tv84 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tthis.startTime = v84;\n\tv110 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv39 = v110 - this.startTime;\n\tthis.lastTime = v39;\n\tv112 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.delay);\n\tv114 = v112 == 0;\n\tif (v114) goto L_003E;\n\tgoto L_0041;\nL_003E:\n\tv98 = HutongGames.PlayMaker.FsmFloat::get_Value(this.delay);\n\tthis.delayTime = v98;\nL_0041:\n\tthis.delayTime = v98;\n\tthis.start = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			finished = false;
			isRunning = false;
			SetEasingFunction();
			runningTime = 0f;
			bool isNone = reverse.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			float num = 0f;
			if (!flag2)
			{
				num = ((!reverse.Value) ? 0f : 1f);
			}
			percentage = num;
			finishAction = false;
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			startTime = realtimeSinceStartup;
			float realtimeSinceStartup2 = FsmTime.RealtimeSinceStartup;
			float num2 = realtimeSinceStartup2 - startTime;
			lastTime = num2;
			float num3 = (delay.IsNone ? 0f : (delayTime = delay.Value));
			delayTime = num3;
			start = true;
		}

		[Token(Token = "0x600065A")]
		[Address(RVA = "0xB7152C", Offset = "0xB7152C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnExit()
		{
		}

		[Token(Token = "0x600065B")]
		[Address(RVA = "0xB71794", Offset = "0xB71794", Length = "0x260")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = ~this.start;\n\tif (v19) goto L_0042;\n\tv21 = ~this.isRunning;\n\tv22 = ~v21;\n\tif (v22) goto L_0045;\n\tv43 = this.delayTime >= 0;\n\tif (v43) goto L_002A;\n\tthis.isRunning = 1;\n\tthis.start = 0;\n\tv199 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tthis.startTime = v199;\n\tv254 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv36 = v254 - this.startTime;\n\tthis.lastTime = v36;\n\tgoto L_0042;\nL_002A:\n\tv72 = ~this.realTime;\n\tif (v72) goto L_003E;\n\tv256 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv321 = v256 - this.startTime;\n\tv322 = v321 - this.lastTime;\n\tthis.deltaTime = v322;\n\tv323 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv32 = this.delayTime - this.deltaTime;\n\tv37 = v323 - this.startTime;\n\tthis.lastTime = v37;\n\tthis.delayTime = v32;\n\tgoto L_0042;\nL_003E:\n\tv257 = UnityEngine.Time::get_deltaTime();\n\tv34 = this.delayTime - v257;\n\tthis.delayTime = v34;\nL_0042:\n\tv77 = ~this.isRunning;\n\tif (v77) goto L_011A;\nL_0045:\n\tv97 = ~this.finished;\n\tv98 = ~v97;\n\tif (v98) goto L_011A;\n\tv259 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv325 = v259 == 0;\n\tif (v325) goto L_0056;\n\tgoto L_0059;\nL_0056:\n\tv332 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\n\tv328 = v332 ^ 1;\nL_0059:\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::UpdatePercentage(this);\n\tv336 = v328 & 1;\n\tv337 = v336 == 0;\n\tif (v337) goto L_00C0;\n\tv348 = this.percentage >= 1f;\n\tif (v348) goto L_010F;\n\tv189 = this.fromFloats;\nL_0078:\n\tv148 = v124 >= v189.Length;\n\tif (v148) goto L_011A;\n\tv473 = v124 < v189.Length;\n\tv436 = ~v473;\n\tif (v436) goto L_011B;\n\tv268 = this.toFloats;\n\tv479 = v124 < v268.Length;\n\tv303 = ~v479;\n\tif (v303) goto L_011B;\n\tv389 = this.resultFloats;\n\tv405 = HutongGames.PlayMaker.Actions.EaseFsmAction+EasingFunction::Invoke(this.ease, v189[v124 @ X20_v12 (System.Int32)], v268[v124 @ X20_v12 (System.Int32)], this.percentage);\n\tv485 = v124 < v389.Length;\n\tv437 = ~v485;\n\tif (v437) goto L_011B;\n\tv389[v124 @ X20_v12 (System.Int32)] = v405;\n\tv189 = this.fromFloats;\n\tv124 = v124 + 1;\n\tv488 = this.fromFloats == 0;\n\tv442 = ~v488;\n\tif (v442) goto L_0078;\n\tgoto L_010D;\nL_00C0:\n\tv360 = this.percentage <= 0;\n\tif (v360) goto L_010F;\n\tv190 = this.fromFloats;\nL_00D0:\n\tv149 = v125 >= v190.Length;\n\tif (v149) goto L_011A;\n\tv474 = v125 < v190.Length;\n\tv438 = ~v474;\n\tif (v438) goto L_011B;\n\tv269 = this.toFloats;\n\tv480 = v125 < v269.Length;\n\tv304 = ~v480;\n\tif (v304) goto L_011B;\n\tv388 = this.resultFloats;\n\tv404 = HutongGames.PlayMaker.Actions.EaseFsmAction+EasingFunction::Invoke(this.ease, v190[v125 @ X20_v9 (System.Int32)], v269[v125 @ X20_v9 (System.Int32)], this.percentage);\n\tv486 = v125 < v388.Length;\n\tv435 = ~v486;\n\tif (v435) goto L_011B;\n\tv388[v125 @ X20_v9 (System.Int32)] = v404;\n\tv190 = this.fromFloats;\n\tv125 = v125 + 1;\n\tv490 = this.fromFloats == 0;\n\tv439 = ~v490;\n\tif (v439) goto L_00D0;\nL_010D:\n\tthrow System.NullReferenceException;\nL_010F:\n\tthis.finishAction = 1;\n\tthis.finished = 1;\n\tthis.isRunning = 0;\nL_011A:\n\treturn;\nL_011B:\n\tv478 = new System.IndexOutOfRangeException();\n\tthrow v478;\n\tthrow System.NullReferenceException;\n// 189 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (start)
			{
				if (isRunning)
				{
					goto IL_0180;
				}
				if (delayTime < 0f)
				{
					isRunning = true;
					start = false;
					float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
					startTime = realtimeSinceStartup;
					float realtimeSinceStartup2 = FsmTime.RealtimeSinceStartup;
					float num = realtimeSinceStartup2 - startTime;
					lastTime = num;
				}
				else if (realTime)
				{
					float realtimeSinceStartup3 = FsmTime.RealtimeSinceStartup;
					float num2 = realtimeSinceStartup3 - startTime;
					float num3 = num2 - lastTime;
					deltaTime = num3;
					float realtimeSinceStartup4 = FsmTime.RealtimeSinceStartup;
					float num4 = delayTime - deltaTime;
					float num5 = realtimeSinceStartup4 - startTime;
					lastTime = num5;
					delayTime = num4;
				}
				else
				{
					float num6 = Time.deltaTime;
					float num7 = delayTime - num6;
					delayTime = num7;
				}
			}
			if (isRunning)
			{
				goto IL_0180;
			}
			return;
			IL_04c7:
			finishAction = true;
			finished = true;
			isRunning = false;
			return;
			IL_04c1:
			throw new NullReferenceException();
			IL_0180:
			if (finished)
			{
				return;
			}
			int num8;
			if (reverse.IsNone)
			{
				num8 = 1;
			}
			else
			{
				bool value = reverse.Value;
				num8 = (value ? 1 : 0) ^ 1;
			}
			UpdatePercentage();
			if ((num8 & 1) != 0)
			{
				if (!(percentage < 1f))
				{
					goto IL_04c7;
				}
				float[] array = fromFloats;
				int num9 = 0;
				while (true)
				{
					if (num9 < array.Length)
					{
						if (num9 >= array.Length)
						{
							break;
						}
						float[] array2 = toFloats;
						if (num9 >= array2.Length)
						{
							break;
						}
						float[] array3 = resultFloats;
						float num10 = ease(array[num9], array2[num9], percentage);
						if (num9 >= array3.Length)
						{
							break;
						}
						array3[num9] = num10;
						array = fromFloats;
						num9++;
						if (fromFloats != null)
						{
							continue;
						}
						goto IL_04c1;
					}
					return;
				}
			}
			else
			{
				if (!(percentage > 0f))
				{
					goto IL_04c7;
				}
				float[] array4 = fromFloats;
				int num11 = 0;
				while (true)
				{
					if (num11 < array4.Length)
					{
						if (num11 >= array4.Length)
						{
							break;
						}
						float[] array5 = toFloats;
						if (num11 >= array5.Length)
						{
							break;
						}
						float[] array6 = resultFloats;
						float num12 = ease(array4[num11], array5[num11], percentage);
						if (num11 >= array6.Length)
						{
							break;
						}
						array6[num11] = num12;
						array4 = fromFloats;
						num11++;
						if (fromFloats != null)
						{
							continue;
						}
						goto IL_04c1;
					}
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600065C")]
		[Address(RVA = "0xB71EB4", Offset = "0xB71EB4", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = ~this.realTime;\n\tif (v19) goto L_002B;\n\tv21 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv27 = v21 - this.startTime;\n\tv28 = v27 - this.lastTime;\n\tthis.deltaTime = v28;\n\tv29 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv62 = v29 - this.startTime;\n\tthis.lastTime = v62;\n\tv94 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.speed);\n\tv47 = this + 0x90;\n\tv149 = v94 == 0;\n\tif (v149) goto L_003C;\n\tv65 = this.runningTime + this.deltaTime;\n\tgoto L_0047;\nL_002B:\n\tv31 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.speed);\n\tv47 = this + 0x90;\n\tv64 = UnityEngine.Time::get_deltaTime();\n\tv96 = v31 == 0;\n\tif (v96) goto L_0044;\n\tv65 = this.runningTime + v64;\n\tgoto L_0047;\nL_003C:\n\tv159 = HutongGames.PlayMaker.FsmFloat::get_Value(this.speed);\n\tv162 = this.deltaTime * v159;\n\tv65 = this.runningTime + v162;\n\tgoto L_0047;\nL_0044:\n\tv158 = HutongGames.PlayMaker.FsmFloat::get_Value(this.speed);\n\tv161 = v64 * v158;\n\tv65 = this.runningTime + v161;\nL_0047:\n\t*([v47 @ X21_v1]) = v65;\n\tv160 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv164 = v160 == 0;\n\tif (v164) goto L_0056;\n\tgoto L_005D;\nL_0056:\n\tv169 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\nL_005D:\n\tv172 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv140 = this.runningTime / v172;\n\tv137 = 1f - v140;\n\tv100 = v35 != 0;\n\tif (v100) goto L_FFFFFFFF;\n\tgoto L_0070;\nL_0070:\n\tthis.percentage = v140;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void UpdatePercentage()
		{
			//IL_00e9: Expected O, but got I
			//IL_0254: Expected O, but got F4
			//IL_0099: Expected O, but got I
			float num4;
			object obj;
			if (realTime)
			{
				float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
				float num = realtimeSinceStartup - startTime;
				float num2 = num - lastTime;
				deltaTime = num2;
				float realtimeSinceStartup2 = FsmTime.RealtimeSinceStartup;
				float num3 = realtimeSinceStartup2 - startTime;
				lastTime = num3;
				bool isNone = speed.IsNone;
				obj = (long)(IntPtr)this + 144L;
				if (isNone)
				{
					num4 = runningTime + deltaTime;
				}
				else
				{
					float value = speed.Value;
					float num5 = deltaTime * value;
					num4 = runningTime + num5;
				}
			}
			else
			{
				bool isNone2 = speed.IsNone;
				obj = (long)(IntPtr)this + 144L;
				float num6 = Time.deltaTime;
				if (isNone2)
				{
					num4 = runningTime + num6;
				}
				else
				{
					float value2 = speed.Value;
					float num7 = num6 * value2;
					num4 = runningTime + num7;
				}
			}
			obj = num4;
			int num8;
			if (reverse.IsNone)
			{
				num8 = 0;
			}
			else
			{
				bool value3 = reverse.Value;
				num8 = (value3 ? 1 : 0);
			}
			float value4 = time.Value;
			float num9 = runningTime / value4;
			float num10 = 1f - num9;
			if (num8 != 0)
			{
				num9 = num10;
			}
			percentage = num9;
		}

		[Token(Token = "0x600065D")]
		[Address(RVA = "0xB71CE8", Offset = "0xB71CE8", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB9BE8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022901]) = v38;\nL_0013:\n\tv39 = v36.easeType;\n\tv40 = v36.easeType < 0x1C;\n\tv41 = ~v40;\n\tv42 = v36.easeType - 0x1C;\n\tv44 = v42 == 0;\n\tv49 = ~v44;\n\tv50 = v41 & v49;\n\tif (v50) goto L_0086;\n\tv52 = 0x1819000 + 0x9C4;\n\tv56 = *([v52 @ X9_v2 (System.Int32)+v39 @ X8_v3 (HutongGames.PlayMaker.Actions.EaseFsmAction+EaseType)*4]) + v52;\n\t// 38 IndirectJump v56 @ X8_v5, v36 @ X0_v1 (HutongGames.PlayMaker.Actions.EaseFsmAction), v36 @ X0_v1 (HutongGames.PlayMaker.Actions.EaseFsmAction), methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX20 = *([1EAF718]);\n\tgoto L_0077;\n\tX20 = *([1EEEE48]);\n\tgoto L_0077;\n\tX20 = *([1ECF4C0]);\n\tgoto L_0077;\n\tX20 = *([1EBE2E0]);\n\tgoto L_0077;\n\tX20 = *([1EB43B0]);\n\tgoto L_0077;\n\tX20 = *([1EE5230]);\n\tgoto L_0077;\n\tX20 = *([1EC2400]);\n\tgoto L_0077;\n\tX20 = *([1EC5D68]);\n\tgoto L_0077;\n\tX20 = *([1EEB020]);\n\tgoto L_0077;\n\tX20 = *([1EF3AD8]);\n\tgoto L_0077;\n\tX20 = *([1EB2550]);\n\tgoto L_0077;\n\tX20 = *([1EEE5C0]);\n\tgoto L_0077;\n\tX20 = *([1ECEBA8]);\n\tgoto L_0077;\n\tX20 = *([1EB1848]);\n\tgoto L_0077;\n\tX20 = *([1EAF5A0]);\n\tgoto L_0077;\n\tX20 = *([1EFC430]);\n\tgoto L_0077;\n\tX20 = *([1F04E08]);\n\tgoto L_0077;\n\tX20 = *([1EB0890]);\n\tgoto L_0077;\n\tX20 = *([1ED1618]);\n\tgoto L_0077;\n\tX20 = *([1F03020]);\n\tgoto L_0077;\n\tX20 = *([1EEE870]);\n\tgoto L_0077;\n\tX20 = *([1ECD5D8]);\n\tgoto L_0077;\n\tX20 = *([1F074D8]);\n\tgoto L_0077;\n\tX20 = *([1F07F78]);\n\tgoto L_0077;\n\tX20 = *([1EEE3E8]);\n\tgoto L_0077;\n\tX20 = *([1EE6608]);\n\tgoto L_0077;\n\tX20 = *([1EDBE60]);\nL_0077:\n\tX8 = 0x1EF8000;\n\tX8 = *([1EF8258]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\tX9 = *([X8]);\n\t*([X0+20]) = X19;\n\t*([X0+28]) = X8;\n\t*([X0+10]) = X9;\n\t*([X19+88]) = X0;\nL_0086:\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void SetEasingFunction()
		{
			//IL_0029: Expected O, but got I
			while (true)
			{
				EaseType easeType = this.easeType;
				bool flag = this.easeType < EaseType.punch;
				bool flag2 = !flag;
				int num = (int)(this.easeType - 28);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num2 = 25268224 + 2500;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v2 (System.Int32)+v39 @ X8_v3 (HutongGames.PlayMaker.Actions.EaseFsmAction+EaseType)*4]");
					object obj = 0L + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ X8_v5 (should have been resolved before IL gen)");
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x600065E")]
		[Address(RVA = "0xB722A4", Offset = "0xB722A4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EEC6B8]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2022902]) = v44;\nL_001D:\n\tgoto L_002E;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002E;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_002E:\n\treturnVal1 = UnityEngine.Mathf::Lerp(start, end, value);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float linear(float start, float end, float value)
		{
			return Mathf.Lerp(start, end, value);
		}

		[Token(Token = "0x600065F")]
		[Address(RVA = "0xB7232C", Offset = "0xB7232C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1F07FA0]);\n\tv27 = *([v26 @ X8_v14]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2022903]) = v44;\nL_001D:\n\tgoto L_0025;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0025;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0025:\n\tv98 = end - start;\n\tv70 = v98 >= -180f;\n\tif (v70) goto L_0043;\n\tv73 = 360f - start;\n\tv98 = v73 + end;\n\tgoto L_004A;\nL_0043:\n\tv88 = v98 <= 180f;\n\tif (v88) goto L_004A;\n\tv112 = 360f - end;\n\tv113 = v112 + start;\n\tv98 = -v113;\nL_004A:\n\tv103 = v98 * value;\n\treturnVal1 = v103 + start;\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float clerp(float start, float end, float value)
		{
			float num = end - start;
			if (num < -180f)
			{
				float num2 = 360f - start;
				num = num2 + end;
			}
			else if (num > 180f)
			{
				float num3 = 360f - end;
				float num4 = num3 + start;
				num = 0f - num4;
			}
			float num5 = num * value;
			return num5 + start;
		}

		[Token(Token = "0x6000660")]
		[Address(RVA = "0xB723F8", Offset = "0xB723F8", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EF0BC8]);\n\tv33 = *([v32 @ X8_v12]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, start, end, value, v42, v43, v44, v45, v46);\n\tv50 = 0 | 1;\n\t*([2022904]) = v50;\nL_0020:\n\tgoto L_0028;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0028;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v36, v37, v38, v39, v40, v41, start, end, value, v42, v43, v44, v45, v46);\nL_0028:\n\tv66 = UnityEngine.Mathf::Clamp01(value);\n\tv73 = v66 * 2.5f;\n\tv74 = v66 * v73;\n\tv75 = v66 * v74;\n\tv76 = v66 * 3.1415927f;\n\tv77 = v75 + 0.2f;\n\tv78 = v76 * v77;\n\tv79 = 0x6D2D20(0, methodInfo, v36, v37, v38, v39, v40, v41, v78, v76, 0.2f, v42, v43, v44, v45, v46);\n\tv83 = 1f - v66;\n\tv86 = 0x6D1A90(v79, methodInfo, v36, v37, v38, v39, v40, v41, v83, 2.2f, 0.2f, v42, v43, v44, v45, v46);\n\tv89 = v78 * v83;\n\tv90 = v66 + v89;\n\tv93 = v83 * 1.2f;\n\tv94 = v93 + 1f;\n\tv95 = v94 * v90;\n\tv96 = end - start;\n\tv97 = v96 * v95;\n\treturnVal1 = v97 + start;\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float spring(float start, float end, float value)
		{
			float num = Mathf.Clamp01(value);
			float num2 = num * 2.5f;
			float num3 = num * num2;
			float num4 = num * num3;
			float num5 = num * (float)Math.PI;
			float num6 = num4 + 0.2f;
			float num7 = num5 * num6;
			Il2CppRuntime.Boundary("SYSTEM_API:sinf", "Method not found @6D2D20 (native sinf)");
			float num8 = 1f - num;
			Il2CppRuntime.Boundary("SYSTEM_API:powf", "Method not found @6D1A90 (native powf)");
			float num9 = num7 * num8;
			float num10 = num + num9;
			float num11 = num8 * 1.2f;
			float num12 = num11 + 1f;
			float num13 = num12 * num10;
			float num14 = end - start;
			float num15 = num14 * num13;
			return num15 + start;
		}

		[Token(Token = "0x6000661")]
		[Address(RVA = "0xB724FC", Offset = "0xB724FC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * value;\n\tv5 = v3 * value;\n\treturnVal1 = v5 + start;\n\treturn returnVal1;\n")]
		protected float easeInQuad(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * value;
			float num3 = num2 * value;
			return num3 + start;
		}

		[Token(Token = "0x6000662")]
		[Address(RVA = "0xB72510", Offset = "0xB72510", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv4 = v0 * value;\n\tv6 = value + -2f;\n\tv7 = v4 * v6;\n\treturnVal1 = start - v7;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeOutQuad(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * value;
			float num3 = value + -2f;
			float num4 = num2 * num3;
			return start - num4;
		}

		[Token(Token = "0x6000663")]
		[Address(RVA = "0xB7252C", Offset = "0xB7252C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value + value;\n\tv12 = end - start;\n\tv15 = v0 >= 1f;\n\tif (v15) goto L_0015;\n\tv17 = v12 * 0.5f;\n\tv18 = v17 * v0;\n\tv31 = v0 * v18;\n\tgoto L_001C;\nL_0015:\n\tv22 = v0 + -1f;\n\tv23 = v12 * -0.5f;\n\tv25 = v22 + -2f;\n\tv26 = v22 * v25;\n\tv27 = v26 + -1f;\n\tv31 = v23 * v27;\nL_001C:\n\treturnVal1 = v31 + start;\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeInOutQuad(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num5;
			if (num < 1f)
			{
				float num3 = num2 * 0.5f;
				float num4 = num3 * num;
				num5 = num * num4;
			}
			else
			{
				float num6 = num + -1f;
				float num7 = num2 * -0.5f;
				float num8 = num6 + -2f;
				float num9 = num6 * num8;
				float num10 = num9 + -1f;
				num5 = num7 * num10;
			}
			return num5 + start;
		}

		[Token(Token = "0x6000664")]
		[Address(RVA = "0xB72580", Offset = "0xB72580", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * value;\n\tv5 = v3 * value;\n\tv6 = v5 * value;\n\treturnVal1 = v6 + start;\n\treturn returnVal1;\n")]
		protected float easeInCubic(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * value;
			float num3 = num2 * value;
			float num4 = num3 * value;
			return num4 + start;
		}

		[Token(Token = "0x6000665")]
		[Address(RVA = "0xB72598", Offset = "0xB72598", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = value + -1f;\n\tv3 = v1 * v1;\n\tv4 = v1 * v3;\n\tv6 = end - start;\n\tv9 = v4 + 1f;\n\tv10 = v6 * v9;\n\treturnVal1 = v10 + start;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeOutCubic(float start, float end, float value)
		{
			float num = value + -1f;
			float num2 = num * num;
			float num3 = num * num2;
			float num4 = end - start;
			float num5 = num3 + 1f;
			float num6 = num4 * num5;
			return num6 + start;
		}

		[Token(Token = "0x6000666")]
		[Address(RVA = "0xB725C0", Offset = "0xB725C0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value + value;\n\tv12 = end - start;\n\tv15 = v0 >= 1f;\n\tif (v15) goto L_0015;\n\tv17 = v12 * 0.5f;\n\tv18 = v17 * v0;\n\tv19 = v0 * v18;\n\tv32 = v0 * v19;\n\tgoto L_001D;\nL_0015:\n\tv22 = v0 + -2f;\n\tv23 = v22 * v22;\n\tv25 = v22 * v23;\n\tv27 = v12 * 0.5f;\n\tv28 = v25 + 2f;\n\tv32 = v27 * v28;\nL_001D:\n\treturnVal1 = v32 + start;\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeInOutCubic(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num6;
			if (num < 1f)
			{
				float num3 = num2 * 0.5f;
				float num4 = num3 * num;
				float num5 = num * num4;
				num6 = num * num5;
			}
			else
			{
				float num7 = num + -2f;
				float num8 = num7 * num7;
				float num9 = num7 * num8;
				float num10 = num2 * 0.5f;
				float num11 = num9 + 2f;
				num6 = num10 * num11;
			}
			return num6 + start;
		}

		[Token(Token = "0x6000667")]
		[Address(RVA = "0xB72618", Offset = "0xB72618", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * value;\n\tv5 = v3 * value;\n\tv6 = v5 * value;\n\tv7 = v6 * value;\n\treturnVal1 = v7 + start;\n\treturn returnVal1;\n")]
		protected float easeInQuart(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * value;
			float num3 = num2 * value;
			float num4 = num3 * value;
			float num5 = num4 * value;
			return num5 + start;
		}

		[Token(Token = "0x6000668")]
		[Address(RVA = "0xB72634", Offset = "0xB72634", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = value + -1f;\n\tv3 = v1 * v1;\n\tv4 = v1 * v3;\n\tv5 = v1 * v4;\n\tv6 = end - start;\n\tv9 = v5 + -1f;\n\tv10 = v6 * v9;\n\treturnVal1 = start - v10;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeOutQuart(float start, float end, float value)
		{
			float num = value + -1f;
			float num2 = num * num;
			float num3 = num * num2;
			float num4 = num * num3;
			float num5 = end - start;
			float num6 = num4 + -1f;
			float num7 = num5 * num6;
			return start - num7;
		}

		[Token(Token = "0x6000669")]
		[Address(RVA = "0xB7265C", Offset = "0xB7265C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value + value;\n\tv12 = end - start;\n\tv15 = v0 >= 1f;\n\tif (v15) goto L_0017;\n\tv17 = v12 * 0.5f;\n\tv18 = v17 * v0;\n\tv19 = v0 * v18;\n\tv20 = v0 * v19;\n\tv33 = v0 * v20;\n\tgoto L_001E;\nL_0017:\n\tv24 = v0 + -2f;\n\tv25 = v12 * -0.5f;\n\tv26 = v24 * v24;\n\tv27 = v24 * v26;\n\tv28 = v24 * v27;\n\tv29 = v28 + -2f;\n\tv33 = v25 * v29;\nL_001E:\n\treturnVal1 = v33 + start;\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeInOutQuart(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num7;
			if (num < 1f)
			{
				float num3 = num2 * 0.5f;
				float num4 = num3 * num;
				float num5 = num * num4;
				float num6 = num * num5;
				num7 = num * num6;
			}
			else
			{
				float num8 = num + -2f;
				float num9 = num2 * -0.5f;
				float num10 = num8 * num8;
				float num11 = num8 * num10;
				float num12 = num8 * num11;
				float num13 = num12 + -2f;
				num7 = num9 * num13;
			}
			return num7 + start;
		}

		[Token(Token = "0x600066A")]
		[Address(RVA = "0xB726B8", Offset = "0xB726B8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * value;\n\tv5 = v3 * value;\n\tv6 = v5 * value;\n\tv7 = v6 * value;\n\tv8 = v7 * value;\n\treturnVal1 = v8 + start;\n\treturn returnVal1;\n")]
		protected float easeInQuint(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * value;
			float num3 = num2 * value;
			float num4 = num3 * value;
			float num5 = num4 * value;
			float num6 = num5 * value;
			return num6 + start;
		}

		[Token(Token = "0x600066B")]
		[Address(RVA = "0xB726D8", Offset = "0xB726D8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = value + -1f;\n\tv3 = v1 * v1;\n\tv4 = v1 * v3;\n\tv5 = v1 * v4;\n\tv6 = v1 * v5;\n\tv8 = end - start;\n\tv11 = v6 + 1f;\n\tv12 = v8 * v11;\n\treturnVal1 = v12 + start;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeOutQuint(float start, float end, float value)
		{
			float num = value + -1f;
			float num2 = num * num;
			float num3 = num * num2;
			float num4 = num * num3;
			float num5 = num * num4;
			float num6 = end - start;
			float num7 = num5 + 1f;
			float num8 = num6 * num7;
			return num8 + start;
		}

		[Token(Token = "0x600066C")]
		[Address(RVA = "0xB72708", Offset = "0xB72708", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value + value;\n\tv12 = end - start;\n\tv15 = v0 >= 1f;\n\tif (v15) goto L_0017;\n\tv17 = v12 * 0.5f;\n\tv18 = v17 * v0;\n\tv19 = v0 * v18;\n\tv20 = v0 * v19;\n\tv21 = v0 * v20;\n\tv36 = v0 * v21;\n\tgoto L_0021;\nL_0017:\n\tv24 = v0 + -2f;\n\tv25 = v24 * v24;\n\tv26 = v24 * v25;\n\tv27 = v24 * v26;\n\tv29 = v24 * v27;\n\tv31 = v12 * 0.5f;\n\tv32 = v29 + 2f;\n\tv36 = v31 * v32;\nL_0021:\n\treturnVal1 = v36 + start;\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeInOutQuint(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num8;
			if (num < 1f)
			{
				float num3 = num2 * 0.5f;
				float num4 = num3 * num;
				float num5 = num * num4;
				float num6 = num * num5;
				float num7 = num * num6;
				num8 = num * num7;
			}
			else
			{
				float num9 = num + -2f;
				float num10 = num9 * num9;
				float num11 = num9 * num10;
				float num12 = num9 * num11;
				float num13 = num9 * num12;
				float num14 = num2 * 0.5f;
				float num15 = num13 + 2f;
				num8 = num14 * num15;
			}
			return num8 + start;
		}

		[Token(Token = "0x600066D")]
		[Address(RVA = "0xB72770", Offset = "0xB72770", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1ED7EB8]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2022905]) = v44;\nL_0019:\n\tv47 = end - start;\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0026:\n\tv61 = value * 1.5707964f;\n\tv62 = 0x6D3020(UnityEngine.Mathf, methodInfo, v30, v31, v32, v33, v34, v35, v61, end, value, v36, v37, v38, v39, v40);\n\tv63 = v47 * v61;\n\tv64 = v47 - v63;\n\treturnVal1 = v64 + start;\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeInSine(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value * ((float)Math.PI / 2f);
			Il2CppRuntime.Boundary("SYSTEM_API:cosf", "Method not found @6D3020 (native cosf)");
			float num3 = num * num2;
			float num4 = num - num3;
			return num4 + start;
		}

		[Token(Token = "0x600066E")]
		[Address(RVA = "0xB72808", Offset = "0xB72808", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F0C430]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2022906]) = v44;\nL_0019:\n\tv47 = end - start;\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0026:\n\tv61 = value * 1.5707964f;\n\tv62 = 0x6D2D20(UnityEngine.Mathf, methodInfo, v30, v31, v32, v33, v34, v35, v61, end, value, v36, v37, v38, v39, v40);\n\tv63 = v47 * v61;\n\treturnVal1 = v63 + start;\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeOutSine(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value * ((float)Math.PI / 2f);
			Il2CppRuntime.Boundary("SYSTEM_API:sinf", "Method not found @6D2D20 (native sinf)");
			float num3 = num * num2;
			return num3 + start;
		}

		[Token(Token = "0x600066F")]
		[Address(RVA = "0xB7289C", Offset = "0xB7289C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EA4CE8]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2022907]) = v44;\nL_0019:\n\tv47 = end - start;\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0026:\n\tv61 = value * 3.1415927f;\n\tv62 = 0x6D3020(UnityEngine.Mathf, methodInfo, v30, v31, v32, v33, v34, v35, v61, end, value, v36, v37, v38, v39, v40);\n\tv65 = v47 * -0.5f;\n\tv66 = v61 + -1f;\n\tv67 = v65 * v66;\n\treturnVal1 = v67 + start;\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeInOutSine(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value * (float)Math.PI;
			Il2CppRuntime.Boundary("SYSTEM_API:cosf", "Method not found @6D3020 (native cosf)");
			float num3 = num * -0.5f;
			float num4 = num2 + -1f;
			float num5 = num3 * num4;
			return num5 + start;
		}

		[Token(Token = "0x6000670")]
		[Address(RVA = "0xB72940", Offset = "0xB72940", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F08D48]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2022908]) = v44;\nL_0019:\n\tv47 = end - start;\n\tgoto L_0025;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0025;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = value + -1f;\n\tv62 = v60 * 10f;\n\tv63 = 0x6D28C0(UnityEngine.Mathf, methodInfo, v30, v31, v32, v33, v34, v35, v62, 10f, value, v36, v37, v38, v39, v40);\n\tv64 = v47 * v62;\n\treturnVal1 = v64 + start;\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeInExpo(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value + -1f;
			float num3 = num2 * 10f;
			Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:exp2f", "Method not found @6D28C0 (native exp2f)");
			float num4 = num * num3;
			return num4 + start;
		}

		[Token(Token = "0x6000671")]
		[Address(RVA = "0xB729D8", Offset = "0xB729D8", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F0D2F0]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2022909]) = v44;\nL_0019:\n\tv47 = end - start;\n\tgoto L_0025;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0025;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = value * -10f;\n\tv61 = 0x6D28C0(UnityEngine.Mathf, methodInfo, v30, v31, v32, v33, v34, v35, v60, end, value, v36, v37, v38, v39, v40);\n\tv63 = 1f - v60;\n\tv64 = v47 * v63;\n\treturnVal1 = v64 + start;\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeOutExpo(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value * -10f;
			Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:exp2f", "Method not found @6D28C0 (native exp2f)");
			float num3 = 1f - num2;
			float num4 = num * num3;
			return num4 + start;
		}

		[Token(Token = "0x6000672")]
		[Address(RVA = "0xB72A70", Offset = "0xB72A70", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EB6000]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([202290A]) = v44;\nL_0019:\n\tv47 = value + value;\n\tv58 = end - start;\n\tv59 = v47 >= 1f;\n\tif (v59) goto L_003B;\n\tgoto L_0032;\n\tv70 = *([v60 @ X0_v7 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0032;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v30, v31, v32, v33, v34, v35, v48, end, value, v36, v37, v38, v39, v40);\nL_0032:\n\tv78 = v47 + -1f;\n\tv100 = v78 * 10f;\n\tv81 = 0x6D28C0(UnityEngine.Mathf, methodInfo, v30, v31, v32, v33, v34, v35, v100, 10f, value, v36, v37, v38, v39, v40);\n\tv99 = v58 * 0.5f;\n\tgoto L_004C;\nL_003B:\n\tv66 = v47 + -1f;\n\tgoto L_0046;\n\tv82 = *([v64 @ X0_v3 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0046;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v64, methodInfo, v30, v31, v32, v33, v34, v35, v65, end, value, v36, v37, v38, v39, v40);\nL_0046:\n\tv90 = v66 * -10f;\n\tv91 = 0x6D28C0(UnityEngine.Mathf, methodInfo, v30, v31, v32, v33, v34, v35, v90, end, value, v36, v37, v38, v39, v40);\n\tv99 = v58 * 0.5f;\n\tv100 = 2f - v90;\nL_004C:\n\tv105 = v99 * v100;\n\treturnVal1 = v105 + start;\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeInOutExpo(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num4;
			float num5;
			if (num < 1f)
			{
				float num3 = num + -1f;
				num4 = num3 * 10f;
				Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:exp2f", "Method not found @6D28C0 (native exp2f)");
				num5 = num2 * 0.5f;
			}
			else
			{
				float num6 = num + -1f;
				float num7 = num6 * -10f;
				Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:exp2f", "Method not found @6D28C0 (native exp2f)");
				num5 = num2 * 0.5f;
				num4 = 2f - num7;
			}
			float num8 = num5 * num4;
			return num8 + start;
		}

		[Token(Token = "0x6000673")]
		[Address(RVA = "0xB72B60", Offset = "0xB72B60", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EB6B10]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([202290B]) = v44;\nL_001D:\n\tgoto L_0023;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0023:\n\tv58 = value * value;\n\tv60 = 1f - v58;\n\tv75 = UnityEngine.Mathf::Sqrt(v60);\n\tv64 = v75 - v75;\n\tv67 = v75 ^ v75;\n\tv68 = v75 ^ v64;\n\tv69 = v67 & v68;\n\tv70 = v69 < 0;\n\tv71 = end - start;\n\tv72 = ~v70;\n\tif (v72) goto L_0036;\n\tv74 = 0x6D2F50(UnityEngine.Mathf, methodInfo, v30, v31, v32, v33, v34, v35, v60, v60, value, v36, v37, v38, v39, v40);\nL_0036:\n\tv78 = v75 + -1f;\n\tv79 = v71 * v78;\n\treturnVal1 = start - v79;\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeInCirc(float start, float end, float value)
		{
			//IL_004d: Expected O, but got F4
			//IL_005a: Expected O, but got F4
			float num = value * value;
			float num2 = 1f - num;
			float num3 = Mathf.Sqrt(num2);
			float num4 = num3 - num3;
			object obj = num3 ^ num3;
			object obj2 = num3 ^ num4;
			int num5 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag = num5 < 0;
			float num6 = end - start;
			if (flag)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
				num3 = num2;
			}
			float num7 = num3 + -1f;
			float num8 = num6 * num7;
			return start - num8;
		}

		[Token(Token = "0x6000674")]
		[Address(RVA = "0xB72C0C", Offset = "0xB72C0C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EB64C0]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([202290C]) = v44;\nL_001A:\n\tv48 = value + -1f;\n\tgoto L_0025;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0025;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v30, v31, v32, v33, v34, v35, v47, end, value, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = v48 * v48;\n\tv62 = 1f - v60;\n\tv77 = UnityEngine.Mathf::Sqrt(v62);\n\tv66 = v77 - v77;\n\tv69 = v77 ^ v77;\n\tv70 = v77 ^ v66;\n\tv71 = v69 & v70;\n\tv72 = v71 < 0;\n\tv73 = end - start;\n\tv74 = ~v72;\n\tif (v74) goto L_0037;\n\tv76 = 0x6D2F50(UnityEngine.Mathf, methodInfo, v30, v31, v32, v33, v34, v35, v62, v62, value, v36, v37, v38, v39, v40);\nL_0037:\n\tv79 = v73 * v77;\n\treturnVal1 = v79 + start;\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeOutCirc(float start, float end, float value)
		{
			//IL_004d: Expected O, but got F4
			//IL_005a: Expected O, but got F4
			float num = value + -1f;
			float num2 = num * num;
			float num3 = 1f - num2;
			float num4 = Mathf.Sqrt(num3);
			float num5 = num4 - num4;
			object obj = num4 ^ num4;
			object obj2 = num4 ^ num5;
			int num6 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag = num6 < 0;
			float num7 = end - start;
			if (flag)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
				num4 = num3;
			}
			float num8 = num7 * num4;
			return num8 + start;
		}

		[Token(Token = "0x6000675")]
		[Address(RVA = "0xB72CB8", Offset = "0xB72CB8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1EC9790]);\n\tv31 = *([v30 @ X8_v13]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, start, end, value, v40, v41, v42, v43, v44);\n\tv48 = 0 | 1;\n\t*([202290D]) = v48;\nL_001B:\n\tv51 = value + value;\n\tv62 = v51 >= 1f;\n\tif (v62) goto L_0038;\n\tgoto L_0032;\n\tv73 = *([v63 @ X0_v8 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0032;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v63, methodInfo, v34, v35, v36, v37, v38, v39, start, end, value, v40, v41, v42, v43, v44);\nL_0032:\n\tv95 = v51 * v51;\n\tgoto L_0045;\nL_0038:\n\tv69 = v51 + -2f;\n\tgoto L_0042;\n\tv83 = *([v67 @ X0_v5 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0042;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v34, v35, v36, v37, v38, v39, v68, end, value, v40, v41, v42, v43, v44);\nL_0042:\n\tv95 = v69 * v69;\nL_0045:\n\tv99 = 1f - v95;\n\tv114 = UnityEngine.Mathf::Sqrt(v99);\n\tv103 = v114 - v114;\n\tv106 = v114 ^ v114;\n\tv107 = v114 ^ v103;\n\tv108 = v106 & v107;\n\tv109 = v108 < 0;\n\tv110 = end - start;\n\tv111 = ~v109;\n\tif (v111) goto L_0055;\n\tv113 = 0x6D2F50(v96, methodInfo, v34, v35, v36, v37, v38, v39, v99, v99, value, v40, v41, v42, v43, v44);\nL_0055:\n\tv116 = v110 * v93;\n\tv117 = v94 + v114;\n\tv118 = v116 * v117;\n\treturnVal1 = v118 + start;\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeInOutCirc(float start, float end, float value)
		{
			//IL_005c: Expected I, but got O
			//IL_0013: Expected I, but got O
			//IL_014e: Expected O, but got F4
			//IL_015b: Expected O, but got F4
			float num = value + value;
			float num2;
			float num3;
			float num4;
			if (num < 1f)
			{
				IntPtr intPtr = (IntPtr)typeof(Mathf);
				num2 = num * num;
				num3 = -0.5f;
				num4 = -1f;
			}
			else
			{
				float num5 = num + -2f;
				IntPtr intPtr = (IntPtr)typeof(Mathf);
				num2 = num5 * num5;
				num3 = 0.5f;
				num4 = 1f;
			}
			float num6 = 1f - num2;
			float num7 = Mathf.Sqrt(num6);
			float num8 = num7 - num7;
			object obj = num7 ^ num7;
			object obj2 = num7 ^ num8;
			int num9 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag = num9 < 0;
			float num10 = end - start;
			if (flag)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
				num7 = num6;
			}
			float num11 = num10 * num3;
			float num12 = num4 + num7;
			float num13 = num11 * num12;
			return num13 + start;
		}

		[Token(Token = "0x6000676")]
		[Address(RVA = "0xB72DB0", Offset = "0xB72DB0", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = end - start;\n\tv15 = value >= 0.36363637f;\n\tif (v15) goto L_001E;\n\tv18 = value * 7.5625f;\n\tv44 = v18 * value;\n\tgoto L_004C;\nL_001E:\n\tv31 = value >= 0.72727275f;\n\tif (v31) goto L_0036;\n\tv77 = value + -0.54545456f;\n\tv78 = v77 * 7.5625f;\n\tv79 = v77 * v78;\n\tv44 = v79 + 0.75f;\n\tgoto L_004C;\nL_0036:\n\tv49 = value >= 0.9090909090909091d;\n\tif (v49) goto L_0048;\n\tv85 = value + -0.8181818f;\n\tv86 = v85 * 7.5625f;\n\tv87 = v85 * v86;\n\tv44 = v87 + 0.9375f;\n\tgoto L_004C;\nL_0048:\n\tv91 = value + -0.95454544f;\n\tv67 = v91 * 7.5625f;\n\tv92 = v91 * v67;\n\tv44 = v92 + 0.984375f;\nL_004C:\n\tv74 = v2 * v44;\n\treturnVal1 = v74 + start;\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float bounce(float start, float end, float value)
		{
			float num = end - start;
			float num3;
			if (value < 0.36363637f)
			{
				float num2 = value * 7.5625f;
				num3 = num2 * value;
			}
			else if (value < 0.72727275f)
			{
				float num4 = value + -0.54545456f;
				float num5 = num4 * 7.5625f;
				float num6 = num4 * num5;
				num3 = num6 + 0.75f;
			}
			else if ((double)value < 0.9090909090909091)
			{
				float num7 = value + -0.8181818f;
				float num8 = num7 * 7.5625f;
				float num9 = num7 * num8;
				num3 = num9 + 0.9375f;
			}
			else
			{
				float num10 = value + -21f / 22f;
				float num11 = num10 * 7.5625f;
				float num12 = num10 * num11;
				num3 = num12 + 63f / 64f;
			}
			float num13 = num * num3;
			return num13 + start;
		}

		[Token(Token = "0x6000677")]
		[Address(RVA = "0xB72E80", Offset = "0xB72E80", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = end - start;\n\tv7 = v4 * value;\n\tv9 = v7 * value;\n\tv10 = value * 2.70158f;\n\tv11 = v10 + -1.70158f;\n\tv12 = v9 * v11;\n\treturnVal1 = v12 + start;\n\treturn returnVal1;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeInBack(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * value;
			float num3 = num2 * value;
			float num4 = value * 2.70158f;
			float num5 = num4 + -1.70158f;
			float num6 = num3 * num5;
			return num6 + start;
		}

		[Token(Token = "0x6000678")]
		[Address(RVA = "0xB72EB0", Offset = "0xB72EB0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value + -1f;\n\tv7 = v4 * 2.70158f;\n\tv8 = v4 * v4;\n\tv9 = end - start;\n\tv12 = v7 + 1.70158f;\n\tv13 = v8 * v12;\n\tv15 = v13 + 1f;\n\tv16 = v9 * v15;\n\treturnVal1 = v16 + start;\n\treturn returnVal1;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeOutBack(float start, float end, float value)
		{
			float num = value + -1f;
			float num2 = num * 2.70158f;
			float num3 = num * num;
			float num4 = end - start;
			float num5 = num2 + 1.70158f;
			float num6 = num3 * num5;
			float num7 = num6 + 1f;
			float num8 = num4 * num7;
			return num8 + start;
		}

		[Token(Token = "0x6000679")]
		[Address(RVA = "0xB72EF0", Offset = "0xB72EF0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value + value;\n\tv12 = end - start;\n\tv15 = v0 >= 1f;\n\tif (v15) goto L_001C;\n\tv45 = v12 * 0.5f;\n\tv22 = v0 * v0;\n\tv23 = v0 * 3.5949094f;\n\tv24 = v23 + -2.5949094f;\n\tv47 = v22 * v24;\n\tgoto L_0027;\nL_001C:\n\tv29 = v0 + -2f;\n\tv45 = v12 * 0.5f;\n\tv34 = v29 * v29;\n\tv35 = v29 * 3.5949094f;\n\tv36 = v35 + 2.5949094f;\n\tv37 = v34 * v36;\n\tv47 = v37 + 2f;\nL_0027:\n\tv48 = v45 * v47;\n\treturnVal1 = v48 + start;\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float easeInOutBack(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num3;
			float num7;
			if (num < 1f)
			{
				num3 = num2 * 0.5f;
				float num4 = num * num;
				float num5 = num * 3.5949094f;
				float num6 = num5 + -2.5949094f;
				num7 = num4 * num6;
			}
			else
			{
				float num8 = num + -2f;
				num3 = num2 * 0.5f;
				float num9 = num8 * num8;
				float num10 = num8 * 3.5949094f;
				float num11 = num10 + 2.5949094f;
				float num12 = num9 * num11;
				num7 = num12 + 2f;
			}
			float num13 = num3 * num7;
			return num13 + start;
		}

		[Token(Token = "0x600067A")]
		[Address(RVA = "0xB72F74", Offset = "0xB72F74", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EC6B98]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, amplitude, value, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([202290E]) = v43;\nL_001A:\n\tv48 = value == 0;\n\tif (v48) goto L_004C;\n\tv59 = value == 1f;\n\tif (v59) goto L_004C;\n\tgoto L_0039;\n\tv96 = *([v92 @ X0_v3 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0039;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v92, methodInfo, v28, v29, v30, v31, v32, v33, v53, v54, v34, v35, v36, v37, v38, v39);\nL_0039:\n\tv103 = value * -10f;\n\tv104 = 0x6D28C0(UnityEngine.Mathf, methodInfo, v28, v29, v30, v31, v32, v33, v103, 1f, v34, v35, v36, v37, v38, v39);\n\tv108 = value * 6.2831855f;\n\tv109 = v108 / 0.3f;\n\tv79 = 0x6D2D20(v104, methodInfo, v28, v29, v30, v31, v32, v33, v109, 0.3f, v34, v35, v36, v37, v38, v39);\n\tv77 = v103 * amplitude;\n\treturnVal1 = v77 * v109;\nL_004C:\n\treturn returnVal1;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float punch(float amplitude, float value)
		{
			bool flag = value == 0f;
			float result = 0f;
			if (!flag)
			{
				bool flag2 = value == 1f;
				result = 0f;
				if (!flag2)
				{
					float num = value * -10f;
					Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:exp2f", "Method not found @6D28C0 (native exp2f)");
					float num2 = value * ((float)Math.PI * 2f);
					float num3 = num2 / 0.3f;
					Il2CppRuntime.Boundary("SYSTEM_API:sinf", "Method not found @6D2D20 (native sinf)");
					float num4 = num * amplitude;
					result = num4 * num3;
				}
			}
			return result;
		}

		[Token(Token = "0x600067B")]
		[Address(RVA = "0xB73034", Offset = "0xB73034", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EEEA58]);\n\tv29 = *([v28 @ X8_v12]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, start, end, value, v38, v39, v40, v41, v42);\n\tv46 = 0 | 1;\n\t*([202290F]) = v46;\nL_001C:\n\tv51 = value == 0;\n\tif (v51) goto L_0058;\n\tv66 = end - start;\n\tv67 = value != 1f;\n\tif (v67) goto L_0037;\n\tv92 = v66 + start;\n\tgoto L_0058;\nL_0037:\n\tgoto L_003E;\n\tv113 = *([v109 @ X0_v3 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_003E;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v109, methodInfo, v32, v33, v34, v35, v36, v37, v56, end, value, v38, v39, v40, v41, v42);\nL_003E:\n\tv120 = value * -10f;\n\tv121 = 0x6D28C0(UnityEngine.Mathf, methodInfo, v32, v33, v34, v35, v36, v37, v120, end, value, v38, v39, v40, v41, v42);\n\tv125 = value + -0.075f;\n\tv126 = v125 * 6.2831855f;\n\tv127 = v126 / 0.3f;\n\tv89 = 0x6D2D20(v121, methodInfo, v32, v33, v34, v35, v36, v37, v127, 6.2831855f, 0.3f, v38, v39, v40, v41, v42);\n\tv71 = v66 * v120;\n\tv128 = v71 * v127;\n\tv87 = v66 + v128;\n\tv92 = v87 + start;\nL_0058:\n\treturn v92;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected float elastic(float start, float end, float value)
		{
			bool flag = value == 0f;
			float result = start;
			if (!flag)
			{
				float num = end - start;
				if (value == 1f)
				{
					result = num + start;
				}
				else
				{
					float num2 = value * -10f;
					Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:exp2f", "Method not found @6D28C0 (native exp2f)");
					float num3 = value + -0.075f;
					float num4 = num3 * ((float)Math.PI * 2f);
					float num5 = num4 / 0.3f;
					Il2CppRuntime.Boundary("SYSTEM_API:sinf", "Method not found @6D2D20 (native sinf)");
					float num6 = num * num2;
					float num7 = num6 * num5;
					float num8 = num + num7;
					result = num8 + start;
				}
			}
			return result;
		}

		[Token(Token = "0x600067C")]
		[Address(RVA = "0xB719F8", Offset = "0xB719F8", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F050E8]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022910]) = v38;\nL_0014:\n\tthis.easeType = 0x15;\n\t// 25 NewArr v44 @ X0_v3 (System.Single[]), typeof(System.Single[]), 0\n\tthis.fromFloats = v44;\n\t// 29 NewArr v47 @ X0_v5 (System.Single[]), typeof(System.Single[]), 0\n\tthis.toFloats = v47;\n\t// 33 NewArr v50 @ X0_v7 (System.Single[]), typeof(System.Single[]), 0\n\tthis.resultFloats = v50;\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal EaseFsmAction()
		{
			easeType = EaseType.linear;
			float[] array = new float[0];
			fromFloats = array;
			float[] array2 = new float[0];
			toFloats = array2;
			float[] array3 = new float[0];
			resultFloats = array3;
		}
	}
}
