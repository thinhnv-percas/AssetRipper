using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Token(Token = "0x2000110")]
	public abstract class AnimateFsmAction : FsmStateAction
	{
		[Token(Token = "0x200047A")]
		public enum Calculation
		{
			[Token(Token = "0x4002115")]
			None = 0,
			[Token(Token = "0x4002116")]
			SetValue = 1,
			[Token(Token = "0x4002117")]
			AddToValue = 2,
			[Token(Token = "0x4002118")]
			SubtractFromValue = 3,
			[Token(Token = "0x4002119")]
			SubtractValueFromCurve = 4,
			[Token(Token = "0x400211A")]
			MultiplyValue = 5,
			[Token(Token = "0x400211B")]
			DivideValue = 6,
			[Token(Token = "0x400211C")]
			DivideCurveByValue = 7
		}

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A14A4", Offset = "0x7A14A4")]
		[Token(Token = "0x400101C")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat time;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A14DC", Offset = "0x7A14DC")]
		[Token(Token = "0x400101D")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat speed;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1514", Offset = "0x7A1514")]
		[Token(Token = "0x400101E")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat delay;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A154C", Offset = "0x7A154C")]
		[Token(Token = "0x400101F")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool ignoreCurveOffset;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1584", Offset = "0x7A1584")]
		[Token(Token = "0x4001020")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A15BC", Offset = "0x7A15BC")]
		[Token(Token = "0x4001021")]
		[FieldOffset(Offset = "0x78")]
		public bool realTime;

		[Token(Token = "0x4001022")]
		[FieldOffset(Offset = "0x7C")]
		private float startTime;

		[Token(Token = "0x4001023")]
		[FieldOffset(Offset = "0x80")]
		private float currentTime;

		[Token(Token = "0x4001024")]
		[FieldOffset(Offset = "0x88")]
		private float[] endTimes;

		[Token(Token = "0x4001025")]
		[FieldOffset(Offset = "0x90")]
		private float lastTime;

		[Token(Token = "0x4001026")]
		[FieldOffset(Offset = "0x94")]
		private float deltaTime;

		[Token(Token = "0x4001027")]
		[FieldOffset(Offset = "0x98")]
		private float delayTime;

		[Token(Token = "0x4001028")]
		[FieldOffset(Offset = "0xA0")]
		private float[] keyOffsets;

		[Token(Token = "0x4001029")]
		[FieldOffset(Offset = "0xA8")]
		protected internal AnimationCurve[] curves;

		[Token(Token = "0x400102A")]
		[FieldOffset(Offset = "0xB0")]
		protected internal Calculation[] calculations;

		[Token(Token = "0x400102B")]
		[FieldOffset(Offset = "0xB8")]
		protected internal float[] resultFloats;

		[Token(Token = "0x400102C")]
		[FieldOffset(Offset = "0xC0")]
		protected internal float[] fromFloats;

		[Token(Token = "0x400102D")]
		[FieldOffset(Offset = "0xC8")]
		protected float[] toFloats;

		[Token(Token = "0x400102E")]
		[FieldOffset(Offset = "0xD0")]
		protected internal bool finishAction;

		[Token(Token = "0x400102F")]
		[FieldOffset(Offset = "0xD1")]
		protected internal bool isRunning;

		[Token(Token = "0x4001030")]
		[FieldOffset(Offset = "0xD2")]
		protected internal bool looping;

		[Token(Token = "0x4001031")]
		[FieldOffset(Offset = "0xD3")]
		private bool start;

		[Token(Token = "0x4001032")]
		[FieldOffset(Offset = "0xD4")]
		private float largestEndTime;

		[Token(Token = "0x6000622")]
		[Address(RVA = "0xA140F0", Offset = "0xA140F0", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF85F8]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021D2F]) = v42;\nL_0015:\n\tthis.finishEvent = 0;\n\tthis.realTime = 0;\n\tv46 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.time = v46;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.speed = v52;\n\tv61 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v61);\n\tv61.useVariable = 1;\n\tthis.delay = v61;\n\tv62 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v62);\n\tv62.value = 1;\n\tthis.ignoreCurveOffset = v62;\n\t// 69 NewArr v101 @ X0_v14 (System.Single[]), typeof(System.Single[]), 0\n\tthis.resultFloats = v101;\n\t// 73 NewArr v104 @ X0_v16 (System.Single[]), typeof(System.Single[]), 0\n\tthis.fromFloats = v104;\n\t// 77 NewArr v107 @ X0_v18 (System.Single[]), typeof(System.Single[]), 0\n\tthis.toFloats = v107;\n\t// 81 NewArr v110 @ X0_v20 (System.Single[]), typeof(System.Single[]), 0\n\tthis.endTimes = v110;\n\t// 85 NewArr v113 @ X0_v22 (System.Single[]), typeof(System.Single[]), 0\n\tthis.keyOffsets = v113;\n\t// 91 NewArr v84 @ X0_v24 (UnityEngine.AnimationCurve[]), typeof(UnityEngine.AnimationCurve[]), 0\n\tthis.curves = v84;\n\tthis.finishAction = 0;\n\tthis.start = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			finishEvent = null;
			realTime = false;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			time = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			speed = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			delay = fsmFloat3;
			FsmBool fsmBool = new FsmBool();
			fsmBool.value = true;
			ignoreCurveOffset = fsmBool;
			float[] array = new float[0];
			resultFloats = array;
			float[] array2 = new float[0];
			fromFloats = array2;
			float[] array3 = new float[0];
			toFloats = array3;
			float[] array4 = new float[0];
			endTimes = array4;
			float[] array5 = new float[0];
			keyOffsets = array5;
			AnimationCurve[] array6 = new AnimationCurve[0];
			curves = array6;
			finishAction = false;
			start = false;
		}

		[Token(Token = "0x6000623")]
		[Address(RVA = "0xA145D8", Offset = "0xA145D8", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tthis.startTime = v11;\n\tv13 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tthis.deltaTime = 0f;\n\tthis.currentTime = 0f;\n\tv16 = v13 - this.startTime;\n\tthis.finishAction = 0;\n\tthis.lastTime = v16;\n\tthis.looping = 0;\n\tv19 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.delay);\n\tv42 = v19 == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_0023;\n\tv47 = HutongGames.PlayMaker.FsmFloat::get_Value(this.delay);\n\tthis.delayTime = v47;\nL_0023:\n\tthis.delayTime = v47;\n\tthis.start = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			startTime = realtimeSinceStartup;
			float realtimeSinceStartup2 = FsmTime.RealtimeSinceStartup;
			deltaTime = 0f;
			currentTime = 0f;
			float num = realtimeSinceStartup2 - startTime;
			finishAction = false;
			isRunning = false;
			lastTime = num;
			looping = false;
			bool isNone = delay.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			float num2 = 0f;
			if (!flag2)
			{
				num2 = (delayTime = delay.Value);
			}
			delayTime = num2;
			start = true;
		}

		[Token(Token = "0x6000624")]
		[Address(RVA = "0xA14660", Offset = "0xA14660", Length = "0x534")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1ECDEE0]);\n\tv33 = *([v32 @ X8_v71]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021D30]) = v52;\nL_001A:\n\tv53 = this.curves;\n\t// 33 NewArr v59 @ X0_v7 (System.Single[]), typeof(System.Single[]), v53.Length\n\tv436 = this.curves;\n\tthis.endTimes = v59;\n\t// 40 NewArr v383 @ X0_v9 (System.Single[]), typeof(System.Single[]), v436.Length\n\tv630 = this.curves;\n\tthis.keyOffsets = v383;\n\tthis.largestEndTime = 0f;\nL_003B:\n\tv65 = v353 >= v630.Length;\n\tif (v65) goto L_0204;\n\tv640 = v353 < v630.Length;\n\tv320 = ~v640;\n\tif (v320) goto L_02AD;\n\tv653 = v630[v353 @ X21_v4 (System.Int32)] == 0;\n\tif (v653) goto L_0098;\n\tv384 = UnityEngine.AnimationCurve::get_keys(v630[v353 @ X21_v4 (System.Int32)]);\n\tv748 = v384.Length == 0;\n\tif (v748) goto L_0098;\n\tv438 = this.curves;\n\tv822 = v353 < v438.Length;\n\tv321 = ~v822;\n\tif (v321) goto L_02AD;\n\tv114 = this.keyOffsets;\n\tv388 = UnityEngine.AnimationCurve::get_keys(v438[v353 @ X21_v4 (System.Int32)]);\n\tv826 = v388.Length == 0;\n\tif (v826) goto L_00AB;\n\tv385 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.time);\n\tv840 = v385 == 0;\n\tif (v840) goto L_00B3;\n\tv439 = this.curves;\n\tv843 = v353 < v439.Length;\n\tv322 = ~v843;\n\tif (v322) goto L_02AD;\n\tv513 = UnityEngine.AnimationCurve::get_keys(v439[v353 @ X21_v4 (System.Int32)]);\n\tv718 = v513.Length == 0;\n\tif (v718) goto L_02AD;\n\tv857 = v513 + 0x20;\n\tv386 = 0x101CD48(v857, 0, v36, v37, v38, v39, v40, v41, v104, v76, v44, v45, v46, v47, v48, v49);\n\tv860 = this.keyOffsets == 0;\n\tv412 = ~v860;\n\tif (v412) goto L_0116;\n\tgoto L_02B2;\nL_0098:\n\tv441 = this.endTimes;\n\tv766 = v353 < v441.Length;\n\tv708 = ~v766;\n\tif (v708) goto L_02AD;\n\tv441[v353 @ X21_v4 (System.Int32)] = 0xBF800000;\n\tgoto L_01F4;\nL_00AB:\n\tv827 = this.keyOffsets == 0;\n\tv414 = ~v827;\n\tif (v414) goto L_0116;\n\tgoto L_02B2;\nL_00B3:\n\tv100 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv443 = this.curves;\n\tv853 = v353 < v443.Length;\n\tv323 = ~v853;\n\tif (v323) goto L_02AD;\n\tv390 = UnityEngine.AnimationCurve::get_keys(v443[v353 @ X21_v4 (System.Int32)]);\n\tv444 = this.curves;\n\tv861 = v353 < v444.Length;\n\tv324 = ~v861;\n\tif (v324) goto L_02AD;\n\tv391 = UnityEngine.AnimationCurve::get_length(v444[v353 @ X21_v4 (System.Int32)]);\n\tv722 = v391 - 1;\n\tv875 = v722 < v390.Length;\n\tv325 = ~v875;\n\tif (v325) goto L_02AD;\n\tv878 = v722 * 0x1C;\n\tv879 = v390 + v878;\n\tv880 = v879 + 0x20;\n\tv392 = 0x101CD48(v880, 0, v36, v37, v38, v39, v40, v41, v100, v76, v44, v45, v46, v47, v48, v49);\n\tv446 = this.curves;\n\tv882 = v353 < v446.Length;\n\tv326 = ~v882;\n\tif (v326) goto L_02AD;\n\tv517 = UnityEngine.AnimationCurve::get_keys(v446[v353 @ X21_v4 (System.Int32)]);\n\tv719 = v517.Length == 0;\n\tif (v719) goto L_02AD;\n\tv899 = v517 + 0x20;\n\tv393 = 0x101CD48(v899, 0, v36, v37, v38, v39, v40, v41, v100, v76, v44, v45, v46, v47, v48, v49);\n\tv76 = v100 / v100;\n\tv104 = v76 * v100;\nL_0116:\n\tv838 = v353 < v114.Length;\n\tv327 = ~v838;\n\tif (v327) goto L_02AD;\n\tv114[v353 @ X21_v4 (System.Int32)] = v104;\n\tv842 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.ignoreCurveOffset);\n\tv845 = v842 == 0;\n\tv846 = ~v845;\n\tif (v846) goto L_0147;\n\tv394 = HutongGames.PlayMaker.FsmBool::get_Value(this.ignoreCurveOffset);\n\tv851 = v394 == 0;\n\tif (v851) goto L_0147;\n\tv448 = this.keyOffsets;\n\tv858 = v353 < v448.Length;\n\tv709 = ~v858;\n\tif (v709) goto L_02AD;\nL_0147:\n\tthis.currentTime = v93;\n\tv395 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.time);\n\tv115 = this.endTimes;\n\tv856 = v395 == 0;\n\tif (v856) goto L_0196;\n\tv449 = this.curves;\n\tv859 = v353 < v449.Length;\n\tv329 = ~v859;\n\tif (v329) goto L_02AD;\n\tv396 = UnityEngine.AnimationCurve::get_keys(v449[v353 @ X21_v4 (System.Int32)]);\n\tv450 = this.curves;\n\tv873 = v353 < v450.Length;\n\tv330 = ~v873;\n\tif (v330) goto L_02AD;\n\tv397 = UnityEngine.AnimationCurve::get_length(v450[v353 @ X21_v4 (System.Int32)]);\n\tv724 = v397 - 1;\n\tv883 = v724 < v396.Length;\n\tv331 = ~v883;\n\tif (v331) goto L_02AD;\n\tv885 = v724 * 0x1C;\n\tv452 = v396 + v885;\n\tv886 = v452 + 0x20;\n\tv398 = 0x101CD48(v886, 0, v36, v37, v38, v39, v40, v41, v104, v76, v44, v45, v46, v47, v48, v49);\n\tv887 = v115 == 0;\n\tv424 = ~v887;\n\tif (v424) goto L_019A;\n\tgoto L_02B2;\nL_0196:\n\tv104 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\nL_019A:\n\tv871 = v353 < v115.Length;\n\tv332 = ~v871;\n\tif (v332) goto L_02AD;\n\tv115[v353 @ X21_v4 (System.Int32)] = v104;\n\tv454 = this.endTimes;\n\tv874 = v353 < v454.Length;\n\tv710 = ~v874;\n\tif (v710) goto L_02AD;\n\tv76 = this.largestEndTime;\n\tv66 = this.largestEndTime >= v454[v353 @ X21_v4 (System.Int32)];\n\tif (v66) goto L_01C6;\n\tthis.largestEndTime = v454[v353 @ X21_v4 (System.Int32)];\nL_01C6:\n\tv881 = ~this.looping;\n\tv812 = ~v881;\n\tif (v812) goto L_01F4;\n\tv455 = this.curves;\n\tv884 = v353 < v455.Length;\n\tv499 = ~v884;\n\tif (v499) goto L_02AD;\n\tv810 = UnityEngine.AnimationCurve::get_postWrapMode(v455[v353 @ X21_v4 (System.Int32)]);\n\tv890 = v810 - 2;\n\tv892 = v890 == 0;\n\tv807 = v810 - 4;\n\tv805 = v807 == 0;\n\tv814 = v805 | v892;\n\tthis.looping = v814;\nL_01F4:\n\tv630 = this.curves;\n\tv353 = v353 + 1;\n\tv816 = this.curves == 0;\n\tv428 = ~v816;\n\tif (v428) goto L_003B;\n\tgoto L_02B2;\nL_0204:\n\tv651 = v630.Length < 1;\n\tif (v651) goto L_02AB;\nL_0215:\n\tv68 = this.largestEndTime <= 0;\n\tif (v68) goto L_023F;\n\tv457 = this.endTimes;\n\tv793 = v469 < v457.Length;\n\tv711 = ~v793;\n\tif (v711) goto L_02AD;\n\tv770 = v469 << 2;\n\tv817 = v457 + v770;\n\tv789 = v817 + 0x20;\n\tv768 = *([v789 @ X8_v24]) != -1f;\n\tif (v768) goto L_023F;\n\t*([v789 @ X8_v24]) = this.largestEndTime;\n\tgoto L_028D;\nL_023F:\n\tv69 = this.largestEndTime != 0;\n\tif (v69) goto L_028D;\n\tv458 = this.endTimes;\n\tv819 = v469 < v458.Length;\n\tv712 = ~v819;\n\tif (v712) goto L_02AD;\n\tv70 = v458[v469 @ X20_v11 (System.Int32)] != -1f;\n\tif (v70) goto L_028D;\n\tv403 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.time);\n\tv343 = this.endTimes;\n\tv825 = v403 == 0;\n\tif (v825) goto L_027C;\n\tv828 = v469 < v343.Length;\n\tv713 = ~v828;\n\tif (v713) goto L_02AD;\n\tv343[v469 @ X20_v11 (System.Int32)] = 0x3F800000;\n\tgoto L_028D;\nL_027C:\n\tv109 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv841 = v469 < v343.Length;\n\tv714 = ~v841;\n\tif (v714) goto L_02AD;\n\tv343[v469 @ X20_v11 (System.Int32)] = v109;\nL_028D:\n\tv460 = this.curves;\n\tv469 = v469 + 1;\n\tv730 = v469 < v460.Length;\n\tif (v730) goto L_0215;\nL_02AB:\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::UpdateAnimation(this);\n\treturn;\nL_02AD:\n\tv728 = new System.IndexOutOfRangeException();\n\tthrow v728;\nL_02B2:\n\tthrow System.NullReferenceException;\n// 483 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void Init()
		{
			//IL_0945: Expected O, but got I
			//IL_0954: Expected O, but got I
			//IL_0980: Expected O, but got F4
			//IL_0222: Expected O, but got I
			//IL_03ea: Expected O, but got I
			//IL_03f9: Expected O, but got I
			//IL_06e7: Expected O, but got I
			//IL_06f6: Expected O, but got I
			//IL_0489: Expected O, but got I
			AnimationCurve[] array = curves;
			float[] array2 = new float[array.Length];
			AnimationCurve[] array3 = curves;
			endTimes = array2;
			float[] array4 = new float[array3.Length];
			AnimationCurve[] array5 = curves;
			keyOffsets = array4;
			largestEndTime = 0f;
			int num = 0;
			float num2 = default(float);
			do
			{
				float[] array7;
				if (num < array5.Length)
				{
					if (num < array5.Length)
					{
						if (array5[num] != null)
						{
							Keyframe[] keys = array5[num].keys;
							if (keys.Length != 0)
							{
								AnimationCurve[] array6 = curves;
								if (num < array6.Length)
								{
									array7 = keyOffsets;
									Keyframe[] keys2 = array6[num].keys;
									if (keys2.Length == 0)
									{
										bool flag = keyOffsets == null;
										bool flag2 = !flag;
										num2 = 0f;
										if (!flag2)
										{
											break;
										}
										goto IL_04bb;
									}
									if (time.IsNone)
									{
										AnimationCurve[] array8 = curves;
										if (num < array8.Length)
										{
											Keyframe[] keys3 = array8[num].keys;
											if (keys3.Length != 0)
											{
												object obj = (long)(IntPtr)keys3 + 32L;
												Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101CD48 (inside UnityEngine.Internal.ExcludeFromDocsAttribute::.ctor +0x8)");
												if (keyOffsets == null)
												{
													break;
												}
												goto IL_04bb;
											}
										}
									}
									else
									{
										float value = time.Value;
										AnimationCurve[] array9 = curves;
										if (num < array9.Length)
										{
											Keyframe[] keys4 = array9[num].keys;
											AnimationCurve[] array10 = curves;
											if (num < array10.Length)
											{
												int length = array10[num].length;
												int num3 = length - 1;
												if (num3 < keys4.Length)
												{
													int num4 = num3 * 28;
													object obj2 = (long)(IntPtr)keys4 + (long)num4;
													object obj3 = (long)(IntPtr)obj2 + 32L;
													Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101CD48 (inside UnityEngine.Internal.ExcludeFromDocsAttribute::.ctor +0x8)");
													AnimationCurve[] array11 = curves;
													if (num < array11.Length)
													{
														Keyframe[] keys5 = array11[num].keys;
														if (keys5.Length != 0)
														{
															object obj4 = (long)(IntPtr)keys5 + 32L;
															Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101CD48 (inside UnityEngine.Internal.ExcludeFromDocsAttribute::.ctor +0x8)");
															float num5 = value / value;
															num2 = num5 * value;
															goto IL_04bb;
														}
													}
												}
											}
										}
									}
								}
								goto IL_0b0b;
							}
						}
						float[] array12 = endTimes;
						if (num < array12.Length)
						{
							array12[num] = -1f;
							goto IL_0b2e;
						}
					}
				}
				else
				{
					if (array5.Length < 1)
					{
						goto IL_0b04;
					}
					int num6 = 0;
					while (true)
					{
						if (largestEndTime > 0f)
						{
							float[] array13 = endTimes;
							if (num6 >= array13.Length)
							{
								break;
							}
							int num7 = num6 << 2;
							object obj5 = (long)(IntPtr)array13 + (long)num7;
							object obj6 = (long)(IntPtr)obj5 + 32L;
							if ((float)obj6 == -1f)
							{
								obj6 = largestEndTime;
								goto IL_0bb6;
							}
						}
						if (largestEndTime == 0f)
						{
							float[] array14 = endTimes;
							if (num6 >= array14.Length)
							{
								break;
							}
							if (array14[num6] == -1f)
							{
								bool isNone = time.IsNone;
								float[] array15 = endTimes;
								if (isNone)
								{
									if (num6 >= array15.Length)
									{
										break;
									}
									array15[num6] = 1f;
								}
								else
								{
									float value2 = time.Value;
									if (num6 >= array15.Length)
									{
										break;
									}
									array15[num6] = value2;
								}
							}
						}
						goto IL_0bb6;
						IL_0bb6:
						AnimationCurve[] array16 = curves;
						num6++;
						if (num6 < array16.Length)
						{
							continue;
						}
						goto IL_0b04;
					}
				}
				goto IL_0b0b;
				IL_0748:
				float[] array17;
				if (num < array17.Length)
				{
					array17[num] = num2;
					float[] array18 = endTimes;
					if (num < array18.Length)
					{
						float num5 = largestEndTime;
						if (largestEndTime < array18[num])
						{
							largestEndTime = array18[num];
						}
						bool flag3 = !looping;
						bool flag4 = !flag3;
						num2 = array18[num];
						if (!flag4)
						{
							AnimationCurve[] array19 = curves;
							if (num >= array19.Length)
							{
								goto IL_0b0b;
							}
							WrapMode postWrapMode = array19[num].postWrapMode;
							int num8 = (int)(postWrapMode - 2);
							bool flag5 = num8 == 0;
							int num9 = (int)(postWrapMode - 4);
							bool flag6 = num9 == 0;
							bool flag7 = flag6 || flag5;
							looping = flag7;
							num2 = array18[num];
						}
						goto IL_0b2e;
					}
				}
				goto IL_0b0b;
				IL_04bb:
				if (num < array7.Length)
				{
					array7[num] = num2;
					bool isNone2 = ignoreCurveOffset.IsNone;
					bool flag8 = !isNone2;
					bool flag9 = !flag8;
					float num10 = 0f;
					if (!flag9)
					{
						bool value3 = ignoreCurveOffset.Value;
						bool flag10 = !value3;
						num10 = 0f;
						if (!flag10)
						{
							float[] array20 = keyOffsets;
							if (num >= array20.Length)
							{
								goto IL_0b0b;
							}
							num10 = array20[num];
						}
					}
					currentTime = num10;
					bool isNone3 = time.IsNone;
					array17 = endTimes;
					if (!isNone3)
					{
						num2 = time.Value;
						goto IL_0748;
					}
					AnimationCurve[] array21 = curves;
					if (num < array21.Length)
					{
						Keyframe[] keys6 = array21[num].keys;
						AnimationCurve[] array22 = curves;
						if (num < array22.Length)
						{
							int length2 = array22[num].length;
							int num11 = length2 - 1;
							if (num11 < keys6.Length)
							{
								int num12 = num11 * 28;
								object obj7 = (long)(IntPtr)keys6 + (long)num12;
								object obj8 = (long)(IntPtr)obj7 + 32L;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101CD48 (inside UnityEngine.Internal.ExcludeFromDocsAttribute::.ctor +0x8)");
								if (array17 == null)
								{
									break;
								}
								goto IL_0748;
							}
						}
					}
				}
				goto IL_0b0b;
				IL_0b04:
				UpdateAnimation();
				return;
				IL_0b0b:
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
				IL_0b2e:
				array5 = curves;
				num++;
			}
			while (curves != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000625")]
		[Address(RVA = "0xA14CCC", Offset = "0xA14CCC", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::CheckStart(this);\n\tv12 = ~this.isRunning;\n\tif (v12) goto L_0019;\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::UpdateTime(this);\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::UpdateAnimation(this);\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::CheckFinished(this);\n\treturn;\nL_0019:\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			CheckStart();
			if (isRunning)
			{
				UpdateTime();
				UpdateAnimation();
				CheckFinished();
			}
		}

		[Token(Token = "0x6000626")]
		[Address(RVA = "0xA15C90", Offset = "0xA15C90", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this.isRunning;\n\tif (v13) goto L_0011;\nL_000F:\n\treturn;\nL_0011:\n\tv60 = ~this.start;\n\tif (v60) goto L_000F;\n\tv32 = this.delayTime >= 0;\n\tif (v32) goto L_0024;\n\tthis.isRunning = 1;\n\tthis.start = 0;\n\tgoto L_000F;\nL_0024:\n\tv61 = ~this.realTime;\n\tif (v61) goto L_0038;\n\tv72 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv76 = v72 - this.startTime;\n\tv77 = v76 - this.lastTime;\n\tthis.deltaTime = v77;\n\tv78 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv25 = v78 - this.startTime;\n\tv22 = this.delayTime - this.deltaTime;\n\tthis.lastTime = v25;\n\tthis.delayTime = v22;\n\tgoto L_000F;\nL_0038:\n\tv73 = UnityEngine.Time::get_deltaTime();\n\tv26 = this.delayTime - v73;\n\tthis.delayTime = v26;\n\tgoto L_000F;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CheckStart()
		{
			if (!isRunning && start)
			{
				if (delayTime < 0f)
				{
					isRunning = true;
					start = false;
				}
				else if (realTime)
				{
					float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
					float num = realtimeSinceStartup - startTime;
					float num2 = num - lastTime;
					deltaTime = num2;
					float realtimeSinceStartup2 = FsmTime.RealtimeSinceStartup;
					float num3 = realtimeSinceStartup2 - startTime;
					float num4 = delayTime - deltaTime;
					lastTime = num3;
					delayTime = num4;
				}
				else
				{
					float num5 = Time.deltaTime;
					float num6 = delayTime - num5;
					delayTime = num6;
				}
			}
		}

		[Token(Token = "0x6000627")]
		[Address(RVA = "0xA15D3C", Offset = "0xA15D3C", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = ~this.realTime;\n\tif (v19) goto L_002B;\n\tv21 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv27 = v21 - this.startTime;\n\tv28 = v27 - this.lastTime;\n\tthis.deltaTime = v28;\n\tv29 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv52 = v29 - this.startTime;\n\tthis.lastTime = v52;\n\tv77 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.speed);\n\tv114 = this + 0x80;\n\tv108 = v77 == 0;\n\tif (v108) goto L_003C;\n\tv97 = this.currentTime + this.deltaTime;\n\tgoto L_0047;\nL_002B:\n\tv31 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.speed);\n\tv114 = this + 0x80;\n\tv54 = UnityEngine.Time::get_deltaTime();\n\tv79 = v31 == 0;\n\tif (v79) goto L_0044;\n\tv97 = this.currentTime + v54;\n\tgoto L_0047;\nL_003C:\n\tv120 = HutongGames.PlayMaker.FsmFloat::get_Value(this.speed);\n\tv122 = this.deltaTime * v120;\n\tv97 = this.currentTime + v122;\n\tgoto L_0047;\nL_0044:\n\tv119 = HutongGames.PlayMaker.FsmFloat::get_Value(this.speed);\n\tv121 = v54 * v119;\n\tv97 = this.currentTime + v121;\nL_0047:\n\t*([v114 @ X21_v1]) = v97;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateTime()
		{
			//IL_00e9: Expected O, but got I
			//IL_019c: Expected O, but got F4
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
				obj = (long)(IntPtr)this + 128L;
				if (isNone)
				{
					num4 = currentTime + deltaTime;
				}
				else
				{
					float value = speed.Value;
					float num5 = deltaTime * value;
					num4 = currentTime + num5;
				}
			}
			else
			{
				bool isNone2 = speed.IsNone;
				obj = (long)(IntPtr)this + 128L;
				float num6 = Time.deltaTime;
				if (isNone2)
				{
					num4 = currentTime + num6;
				}
				else
				{
					float value2 = speed.Value;
					float num7 = num6 * value2;
					num4 = currentTime + num7;
				}
			}
			obj = num4;
		}

		[Token(Token = "0x6000628")]
		[Address(RVA = "0xA15214", Offset = "0xA15214", Length = "0xA7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv170 = this.curves;\n\tv38 = 0x1818000 + 0x818;\n\tgoto L_0505;\nL_001B:\n\tv224 = v122 < v170.Length;\n\tv117 = ~v224;\n\tif (v117) goto L_0517;\n\tv326 = v170[v122 @ X22_v6 (System.Int32)] == 0;\n\tif (v326) goto L_0052;\n\tv188 = UnityEngine.AnimationCurve::get_keys(v170[v122 @ X22_v6 (System.Int32)]);\n\tv346 = v188 == 0;\n\tif (v346) goto L_0523;\n\tv342 = v188.Length == 0;\n\tif (v342) goto L_0052;\n\tv207 = this.calculations;\n\tv350 = v122 < v207.Length;\n\tv336 = ~v350;\n\tif (v336) goto L_0517;\n\tv278 = v122 << 2;\n\tv354 = v207 + v278;\n\tv355 = *([v354 @ X8_v17+20]);\n\tv356 = *([v354 @ X8_v17+20]) < 7;\n\tv304 = ~v356;\n\tv301 = *([v354 @ X8_v17+20]) - 7;\n\tv295 = v301 == 0;\n\tv357 = ~v295;\n\tv271 = v304 & v357;\n\tif (v271) goto L_0074;\n\tv320 = *([v38 @ X23_v6 (System.Int32)+v355 @ X8_v18*4]) + v38;\n\t// 81 IndirectJump v320 @ X8_v20, v188 @ X0_v20 (UnityEngine.Keyframe[]), v188 @ X0_v20 (UnityEngine.Keyframe[]), 0, v42 @ X2, v143 @ X3, v144 @ X4, v145 @ X5, v146 @ X6, v147 @ X7, v46 @ V0_v6 (System.Single), v148 @ V1, v149 @ V2, v150 @ V3, v151 @ V4, v152 @ V5, v153 @ V6, v154 @ V7\nL_0052:\n\tv139 = this.fromFloats;\n\tv348 = v122 < v139.Length;\n\tv118 = ~v348;\n\tif (v118) goto L_051F;\n\tv49 = this.resultFloats;\n\tv349 = v122 < v49.Length;\n\tv248 = ~v349;\n\tif (v248) goto L_051F;\nL_0073:\n\tv49[v122 @ X22_v6 (System.Int32)] = v139[v122 @ X22_v6 (System.Int32)];\nL_0074:\n\tv170 = this.curves;\n\tv122 = v122 + 1;\n\tv363 = this.curves == 0;\n\tv136 = ~v363;\n\tif (v136) goto L_0505;\n\tgoto L_051C;\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_0523;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.NamedVariable::get_IsNone(X0, X1);\n\tX8 = *([X19+A8]);\n\tif (TEMP) goto L_051E;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0517;\n\tTEMPSHIFT = X25 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX26 = *([X19+B8]);\n\tX20 = *([X8+20]);\n\tV8 = *([X19+80]);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_01CE;\n\tif (TEMP) goto L_051E;\n\tX0 = X20;\n\tV0 = V8;\n\tgoto L_0217;\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_0523;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.NamedVariable::get_IsNone(X0, X1);\n\tX8 = *([X19+C0]);\n\tif (TEMP) goto L_051E;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0517;\n\tX9 = *([X19+A8]);\n\tif (TEMP) goto L_051E;\n\tX10 = *([X9+18]);\n\tC = X22 < X10;\n\tC = ~C;\n\tTEMP1 = X22 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X10;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0517;\n\tTEMPSHIFT = X25 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tTEMPSHIFT = X25 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX26 = *([X19+B8]);\n\tV11 = *([X8+20]);\n\tX20 = *([X9+20]);\n\tV8 = *([X19+80]);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0446;\n\tif (TEMP) goto L_051E;\n\tX0 = X20;\n\tV0 = V8;\n\tgoto L_048F;\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_0523;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.NamedVariable::get_IsNone(X0, X1);\n\tX8 = *([X19+C0]);\n\tif (TEMP) goto L_051E;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0517;\n\tX9 = *([X19+A8]);\n\tif (TEMP) goto L_051E;\n\tX10 = *([X9+18]);\n\tC = X22 < X10;\n\tC = ~C;\n\tTEMP1 = X22 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X10;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0517;\n\tTEMPSHIFT = X25 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tTEMPSHIFT = X25 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX26 = *([X19+B8]);\n\tV11 = *([X8+20]);\n\tX20 = *([X9+20]);\n\tV8 = *([X19+80]);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_04A0;\n\tif (TEMP) goto L_051E;\n\tX0 = X20;\n\tV0 = V8;\n\tgoto L_04E9;\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_0523;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.NamedVariable::get_IsNone(X0, X1);\n\tX8 = *([X19+A8]);\n\tif (TEMP) goto L_051E;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0517;\n\tTEMPSHIFT = X25 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX26 = *([X19+B8]);\n\tX20 = *([X8+20]);\n\tV8 = *([X19+80]);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_021D;\n\tif (TEMP) goto L_051E;\n\tX0 = X20;\n\tV0 = V8;\n\tgoto L_0266;\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_0523;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.NamedVariable::get_IsNone(X0, X1);\n\tX8 = *([X19+A8]);\n\tif (TEMP) goto L_051E;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0517;\n\tTEMPSHIFT = X25 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX26 = *([X19+B8]);\n\tX20 = *([X8+20]);\n\tV8 = *([X19+80]);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0288;\n\tif (TEMP) goto L_051E;\n\tX0 = X20;\n\tV0 = V8;\n\tgoto L_02D1;\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_0523;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.NamedVariable::get_IsNone(X0, X1);\n\tX8 = *([X19+A8]);\n\tif (TEMP) goto L_051E;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0517;\n\tTEMPSHIFT = X25 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX26 = *([X19+B8]);\n\tX20 = *([X8+20]);\n\tV8 = *([X19+80]);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_02F3;\n\tif (TEMP) goto L_051E;\n\tX0 = X20;\n\tV0 = V8;\n\tX1 = 0;\n\tV0 = UnityEngine.AnimationCurve::Evaluate(X0, V0, X1);\n\tC = V0 < 0;\n\tC = ~C;\n\tTEMP1 = V0 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ 0;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tV0 = V10;\n\tif (Z) goto L_03B8;\n\tX8 = *([X19+C0]);\n\tif (TEMP) goto L_051E;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0517;\n\tX9 = *([X19+A8]);\n\tif (TEMP) goto L_051E;\n\tX10 = *([X9+18]);\n\tC = X22 < X10;\n\tC = ~C;\n\tTEMP1 = X22 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X10;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0517;\n\tTEMPSHIFT = X25 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX0 = *([X9+20]);\n\tif (TEMP) goto L_0523;\n\tTEMPSHIFT = X25 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tV0 = *([X19+80]);\n\tV8 = *([X8+20]);\n\tX1 = 0;\n\tV0 = UnityEngine.AnimationCurve::Evaluate(X0, V0, X1);\n\tV0 = V8 / V0;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_03BA;\n\tgoto L_051E;\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_0523;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.NamedVariable::get_IsNone(X0, X1);\n\tX8 = *([X19+C0]);\n\tif (TEMP) goto L_051E;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0517;\n\tTEMPSHIFT = X25 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tV0 = *([X8+20]);\n\tX26 = *([X19+B8]);\n\tC = V0 < 0;\n\tC = ~C;\n\tTEMP1 = V0 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ 0;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tV0 = V10;\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_03C7;\n\tif (Z) goto L_0437;\n\tX8 = *([X19+A8]);\n\tif (TEMP) goto L_051C;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_051F;\n\tTEMPSHIFT = X25 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = *([X8+20]);\n\tif (TEMP) goto L_0524;\n\tV0 = *([X19+80]);\n\tgoto L_0423;\nL_01CE:\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_0523;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tX8 = *([X19+A8]);\n\tV9 = V0;\n\tif (TEMP) goto L_051E;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0517;\n\tTEMPSHIFT = X25 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = *([X8+20]);\n\tif (TEMP) goto L_0523;\n\tX1 = 0;\n\tX0 = UnityEngine.AnimationCurve::get_keys(X0, X1);\n\tX8 = *([X19+A8]);\n\tX21 = X0;\n\tif (TEMP) goto L_051E;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0517;\n\tTEMPSHIFT = X25 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = *([X8+20]);\n\tif (TEMP) goto L_0523;\n\tX1 = 0;\n\tX0 = UnityEngine.AnimationCurve::get_length(X0, X1);\n\tif (TEMP) goto L_051E\n// ... truncated")]
		public void UpdateAnimation()
		{
			//IL_0121: Expected O, but got I
			//IL_0131: Expected O, but got I
			//IL_0169: Expected O, but got I
			//IL_01b3: Expected O, but got I
			AnimationCurve[] array = curves;
			int num = 25264128 + 2072;
			int num2 = 0;
			while (true)
			{
				if (num2 >= array.Length)
				{
					return;
				}
				if (num2 < array.Length)
				{
					if (array[num2] != null)
					{
						Keyframe[] keys = array[num2].keys;
						if (keys == null)
						{
							break;
						}
						if (keys.Length != 0)
						{
							Calculation[] array2 = calculations;
							if (num2 >= array2.Length)
							{
								goto IL_0251;
							}
							int num3 = num2 << 2;
							object obj = (long)(IntPtr)array2 + (long)num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ X8_v17+20]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ X8_v17+20]");
							bool flag = 0L < 7L;
							bool flag2 = !flag;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ X8_v17+20]");
							object obj3 = -7;
							bool flag3 = obj3 == null;
							bool flag4 = !flag3;
							if (flag2 && flag4)
							{
								goto IL_0281;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X23_v6 (System.Int32)+v355 @ X8_v18*4]");
							object obj4 = 0L + (long)num;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v320 @ X8_v20 (should have been resolved before IL gen)");
						}
					}
					float[] array3 = fromFloats;
					if (num2 < array3.Length)
					{
						float[] array4 = resultFloats;
						if (num2 < array4.Length)
						{
							array4[num2] = array3[num2];
							float num4 = array3[num2];
							goto IL_0281;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				goto IL_0251;
				IL_0251:
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
				throw ex2;
				IL_0281:
				array = curves;
				num2++;
				if (curves == null)
				{
					throw new NullReferenceException();
				}
			}
			NullReferenceException ex3 = new NullReferenceException();
			throw ex3;
		}

		[Token(Token = "0x6000629")]
		[Address(RVA = "0xA15E38", Offset = "0xA15E38", Length = "0x10A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = ~this.isRunning;\n\tif (v8) goto L_004F;\n\tv10 = ~this.looping;\n\tv11 = ~v10;\n\tif (v11) goto L_004F;\n\tv63 = this.endTimes;\n\tthis.finishAction = 1;\n\tv58 = this.endTimes == 0;\n\tif (v58) goto L_0055;\n\tv136 = v63.Length;\n\tv118 = v63.Length < 1;\n\tif (v118) goto L_FFFFFFFF;\nL_001F:\n\tv176 = v126 < v136;\n\tv135 = ~v176;\n\tif (v135) goto L_0050;\n\tv187 = this.currentTime >= v63[v126 @ X10_v5 (System.Int32)];\n\tif (v187) goto L_003A;\n\tthis.finishAction = 0;\nL_003A:\n\tv136 = v63.Length;\n\tv126 = v126 + 1;\n\tv157 = v126 < v63.Length;\n\tif (v157) goto L_001F;\n\tgoto L_004A;\nL_004A:\n\tv60 = v55 ^ 1;\n\tthis.isRunning = v60;\nL_004F:\n\treturn;\nL_0050:\n\tv188 = new System.IndexOutOfRangeException();\n\tthrow v188;\nL_0055:\n\tv73 = new System.NullReferenceException();\n\tHutongGames.PlayMaker.Actions.DOTweenMaterialTilingProperty::Reset(v73);\n\treturn;\n\tX0 = *([X20]);\n\tX0 = 0xA15008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1078 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CheckFinished()
		{
			if (!isRunning || looping)
			{
				return;
			}
			float[] array = endTimes;
			finishAction = true;
			if (endTimes != null)
			{
				int num = array.Length;
				int num3;
				if (array.Length >= 1)
				{
					int num2 = 0;
					num3 = 1;
					do
					{
						if (num2 < num)
						{
							if (currentTime < array[num2])
							{
								finishAction = false;
								num3 = 0;
							}
							num = array.Length;
							num2++;
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (num2 < array.Length);
				}
				else
				{
					num3 = 1;
				}
				int num4 = num3 ^ 1;
				isRunning = (byte)num4 != 0;
			}
			else
			{
				NullReferenceException ex2 = new NullReferenceException();
				((DOTweenMaterialTilingProperty)(object)ex2).Reset();
			}
		}

		[Token(Token = "0x600062A")]
		[Address(RVA = "0xA14D1C", Offset = "0xA14D1C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal AnimateFsmAction()
		{
		}
	}
}
