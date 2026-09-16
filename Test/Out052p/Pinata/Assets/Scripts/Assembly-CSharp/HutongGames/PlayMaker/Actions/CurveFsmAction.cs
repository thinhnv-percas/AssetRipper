using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751DA4", Offset = "0x751DA4")]
	[Token(Token = "0x2000115")]
	public abstract class CurveFsmAction : FsmStateAction
	{
		[Token(Token = "0x200047B")]
		public enum Calculation
		{
			[Token(Token = "0x400211E")]
			None = 0,
			[Token(Token = "0x400211F")]
			AddToValue = 1,
			[Token(Token = "0x4002120")]
			SubtractFromValue = 2,
			[Token(Token = "0x4002121")]
			SubtractValueFromCurve = 3,
			[Token(Token = "0x4002122")]
			MultiplyValue = 4,
			[Token(Token = "0x4002123")]
			DivideValue = 5,
			[Token(Token = "0x4002124")]
			DivideCurveByValue = 6
		}

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1A84", Offset = "0x7A1A84")]
		[Token(Token = "0x4001058")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat time;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1ABC", Offset = "0x7A1ABC")]
		[Token(Token = "0x4001059")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat speed;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1AF4", Offset = "0x7A1AF4")]
		[Token(Token = "0x400105A")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat delay;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1B2C", Offset = "0x7A1B2C")]
		[Token(Token = "0x400105B")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool ignoreCurveOffset;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1B64", Offset = "0x7A1B64")]
		[Token(Token = "0x400105C")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A1B9C", Offset = "0x7A1B9C")]
		[Token(Token = "0x400105D")]
		[FieldOffset(Offset = "0x78")]
		public bool realTime;

		[Token(Token = "0x400105E")]
		[FieldOffset(Offset = "0x7C")]
		private float startTime;

		[Token(Token = "0x400105F")]
		[FieldOffset(Offset = "0x80")]
		private float currentTime;

		[Token(Token = "0x4001060")]
		[FieldOffset(Offset = "0x88")]
		private float[] endTimes;

		[Token(Token = "0x4001061")]
		[FieldOffset(Offset = "0x90")]
		private float lastTime;

		[Token(Token = "0x4001062")]
		[FieldOffset(Offset = "0x94")]
		private float deltaTime;

		[Token(Token = "0x4001063")]
		[FieldOffset(Offset = "0x98")]
		private float delayTime;

		[Token(Token = "0x4001064")]
		[FieldOffset(Offset = "0xA0")]
		private float[] keyOffsets;

		[Token(Token = "0x4001065")]
		[FieldOffset(Offset = "0xA8")]
		protected internal AnimationCurve[] curves;

		[Token(Token = "0x4001066")]
		[FieldOffset(Offset = "0xB0")]
		protected internal Calculation[] calculations;

		[Token(Token = "0x4001067")]
		[FieldOffset(Offset = "0xB8")]
		protected internal float[] resultFloats;

		[Token(Token = "0x4001068")]
		[FieldOffset(Offset = "0xC0")]
		protected internal float[] fromFloats;

		[Token(Token = "0x4001069")]
		[FieldOffset(Offset = "0xC8")]
		protected internal float[] toFloats;

		[Token(Token = "0x400106A")]
		[FieldOffset(Offset = "0xD0")]
		private float[] distances;

		[Token(Token = "0x400106B")]
		[FieldOffset(Offset = "0xD8")]
		protected internal bool finishAction;

		[Token(Token = "0x400106C")]
		[FieldOffset(Offset = "0xD9")]
		protected internal bool isRunning;

		[Token(Token = "0x400106D")]
		[FieldOffset(Offset = "0xDA")]
		protected internal bool looping;

		[Token(Token = "0x400106E")]
		[FieldOffset(Offset = "0xDB")]
		private bool start;

		[Token(Token = "0x400106F")]
		[FieldOffset(Offset = "0xDC")]
		private float largestEndTime;

		[Token(Token = "0x600063F")]
		[Address(RVA = "0xA93918", Offset = "0xA93918", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EBD328]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202220D]) = v42;\nL_0015:\n\tthis.finishEvent = 0;\n\tthis.realTime = 0;\n\tv46 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.time = v46;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.speed = v52;\n\tv61 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v61);\n\tv61.useVariable = 1;\n\tthis.delay = v61;\n\tv62 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v62);\n\tv62.value = 1;\n\tthis.ignoreCurveOffset = v62;\n\t// 69 NewArr v101 @ X0_v14 (System.Single[]), typeof(System.Single[]), 0\n\tthis.resultFloats = v101;\n\t// 73 NewArr v104 @ X0_v16 (System.Single[]), typeof(System.Single[]), 0\n\tthis.fromFloats = v104;\n\t// 77 NewArr v107 @ X0_v18 (System.Single[]), typeof(System.Single[]), 0\n\tthis.toFloats = v107;\n\t// 81 NewArr v110 @ X0_v20 (System.Single[]), typeof(System.Single[]), 0\n\tthis.distances = v110;\n\t// 85 NewArr v113 @ X0_v22 (System.Single[]), typeof(System.Single[]), 0\n\tthis.endTimes = v113;\n\t// 89 NewArr v116 @ X0_v24 (System.Single[]), typeof(System.Single[]), 0\n\tthis.keyOffsets = v116;\n\t// 95 NewArr v84 @ X0_v26 (UnityEngine.AnimationCurve[]), typeof(UnityEngine.AnimationCurve[]), 0\n\tthis.curves = v84;\n\tthis.finishAction = 0;\n\tthis.start = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			distances = array4;
			float[] array5 = new float[0];
			endTimes = array5;
			float[] array6 = new float[0];
			keyOffsets = array6;
			AnimationCurve[] array7 = new AnimationCurve[0];
			curves = array7;
			finishAction = false;
			start = false;
		}

		[Token(Token = "0x6000640")]
		[Address(RVA = "0xA93EA4", Offset = "0xA93EA4", Length = "0x88")]
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

		[Token(Token = "0x6000641")]
		[Address(RVA = "0xA93F2C", Offset = "0xA93F2C", Length = "0x5B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1F00E28]);\n\tv35 = *([v34 @ X8_v77]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202220E]) = v54;\nL_001B:\n\tv55 = this.curves;\n\t// 34 NewArr v61 @ X0_v8 (System.Single[]), typeof(System.Single[]), v55.Length\n\tv486 = this.curves;\n\tthis.endTimes = v61;\n\t// 41 NewArr v428 @ X0_v10 (System.Single[]), typeof(System.Single[]), v486.Length\n\tv734 = this.curves;\n\tthis.keyOffsets = v428;\n\tthis.largestEndTime = 0f;\nL_003C:\n\tv78 = v396 >= v734.Length;\n\tif (v78) goto L_01F3;\n\tv744 = v396 < v734.Length;\n\tv360 = ~v744;\n\tif (v360) goto L_02EA;\n\tv757 = v734[v396 @ X22_v6 (System.Int32)] == 0;\n\tif (v757) goto L_0099;\n\tv429 = UnityEngine.AnimationCurve::get_keys(v734[v396 @ X22_v6 (System.Int32)]);\n\tv857 = v429.Length == 0;\n\tif (v857) goto L_0099;\n\tv488 = this.curves;\n\tv935 = v396 < v488.Length;\n\tv361 = ~v935;\n\tif (v361) goto L_02EA;\n\tv130 = this.keyOffsets;\n\tv433 = UnityEngine.AnimationCurve::get_keys(v488[v396 @ X22_v6 (System.Int32)]);\n\tv941 = v433.Length == 0;\n\tif (v941) goto L_00AC;\n\tv430 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.time);\n\tv962 = v430 == 0;\n\tif (v962) goto L_00B4;\n\tv489 = this.curves;\n\tv965 = v396 < v489.Length;\n\tv362 = ~v965;\n\tif (v362) goto L_02EA;\n\tv569 = UnityEngine.AnimationCurve::get_keys(v489[v396 @ X22_v6 (System.Int32)]);\n\tv831 = v569.Length == 0;\n\tif (v831) goto L_02EA;\n\tv979 = v569 + 0x20;\n\tv431 = 0x101CD48(v979, 0, v38, v39, v40, v41, v42, v43, v119, v90, v46, v47, v48, v49, v50, v51);\n\tv982 = this.keyOffsets == 0;\n\tv458 = ~v982;\n\tif (v458) goto L_0117;\n\tgoto L_02DB;\nL_0099:\n\tv491 = this.endTimes;\n\tv876 = v396 < v491.Length;\n\tv820 = ~v876;\n\tif (v820) goto L_02EA;\n\tv491[v396 @ X22_v6 (System.Int32)] = 0xBF800000;\n\tgoto L_01E3;\nL_00AC:\n\tv943 = this.keyOffsets == 0;\n\tv460 = ~v943;\n\tif (v460) goto L_0117;\n\tgoto L_02DB;\nL_00B4:\n\tv115 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv493 = this.curves;\n\tv975 = v396 < v493.Length;\n\tv363 = ~v975;\n\tif (v363) goto L_02EA;\n\tv435 = UnityEngine.AnimationCurve::get_keys(v493[v396 @ X22_v6 (System.Int32)]);\n\tv494 = this.curves;\n\tv983 = v396 < v494.Length;\n\tv364 = ~v983;\n\tif (v364) goto L_02EA;\n\tv436 = UnityEngine.AnimationCurve::get_length(v494[v396 @ X22_v6 (System.Int32)]);\n\tv835 = v436 - 1;\n\tv997 = v835 < v435.Length;\n\tv365 = ~v997;\n\tif (v365) goto L_02EA;\n\tv1000 = v835 * 0x1C;\n\tv1001 = v435 + v1000;\n\tv1002 = v1001 + 0x20;\n\tv437 = 0x101CD48(v1002, 0, v38, v39, v40, v41, v42, v43, v115, v90, v46, v47, v48, v49, v50, v51);\n\tv496 = this.curves;\n\tv1004 = v396 < v496.Length;\n\tv366 = ~v1004;\n\tif (v366) goto L_02EA;\n\tv573 = UnityEngine.AnimationCurve::get_keys(v496[v396 @ X22_v6 (System.Int32)]);\n\tv832 = v573.Length == 0;\n\tif (v832) goto L_02EA;\n\tv1012 = v573 + 0x20;\n\tv438 = 0x101CD48(v1012, 0, v38, v39, v40, v41, v42, v43, v115, v90, v46, v47, v48, v49, v50, v51);\n\tv90 = v115 / v115;\n\tv119 = v90 * v115;\nL_0117:\n\tv960 = v396 < v130.Length;\n\tv367 = ~v960;\n\tif (v367) goto L_02EA;\n\tv130[v396 @ X22_v6 (System.Int32)] = v119;\n\tv964 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.ignoreCurveOffset);\n\tv967 = v964 == 0;\n\tv968 = ~v967;\n\tif (v968) goto L_0148;\n\tv439 = HutongGames.PlayMaker.FsmBool::get_Value(this.ignoreCurveOffset);\n\tv973 = v439 == 0;\n\tif (v973) goto L_0148;\n\tv498 = this.keyOffsets;\n\tv980 = v396 < v498.Length;\n\tv821 = ~v980;\n\tif (v821) goto L_02EA;\nL_0148:\n\tthis.currentTime = v108;\n\tv440 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.time);\n\tv131 = this.endTimes;\n\tv978 = v440 == 0;\n\tif (v978) goto L_0197;\n\tv499 = this.curves;\n\tv981 = v396 < v499.Length;\n\tv369 = ~v981;\n\tif (v369) goto L_02EA;\n\tv441 = UnityEngine.AnimationCurve::get_keys(v499[v396 @ X22_v6 (System.Int32)]);\n\tv500 = this.curves;\n\tv995 = v396 < v500.Length;\n\tv370 = ~v995;\n\tif (v370) goto L_02EA;\n\tv442 = UnityEngine.AnimationCurve::get_length(v500[v396 @ X22_v6 (System.Int32)]);\n\tv837 = v442 - 1;\n\tv1005 = v837 < v441.Length;\n\tv371 = ~v1005;\n\tif (v371) goto L_02EA;\n\tv1007 = v837 * 0x1C;\n\tv502 = v441 + v1007;\n\tv1008 = v502 + 0x20;\n\tv443 = 0x101CD48(v1008, 0, v38, v39, v40, v41, v42, v43, v119, v90, v46, v47, v48, v49, v50, v51);\n\tv1009 = v131 == 0;\n\tv470 = ~v1009;\n\tif (v470) goto L_019B;\n\tgoto L_02DB;\nL_0197:\n\tv119 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\nL_019B:\n\tv993 = v396 < v131.Length;\n\tv372 = ~v993;\n\tif (v372) goto L_02EA;\n\tv131[v396 @ X22_v6 (System.Int32)] = v119;\n\tv504 = this.endTimes;\n\tv996 = v396 < v504.Length;\n\tv822 = ~v996;\n\tif (v822) goto L_02EA;\n\tv90 = this.largestEndTime;\n\tv79 = this.largestEndTime >= v504[v396 @ X22_v6 (System.Int32)];\n\tif (v79) goto L_01C7;\n\tthis.largestEndTime = v504[v396 @ X22_v6 (System.Int32)];\nL_01C7:\n\tv1003 = ~this.looping;\n\tv914 = ~v1003;\n\tif (v914) goto L_01E3;\n\tv505 = this.curves;\n\tv1006 = v396 < v505.Length;\n\tv554 = ~v1006;\n\tif (v554) goto L_02EA;\n\tv1011 = UnityEngine.AnimationCurve::get_postWrapMode(v505[v396 @ X22_v6 (System.Int32)]);\n\tv912 = HutongGames.PlayMaker.ActionHelpers::IsLoopingWrapMode(v1011);\n\tthis.looping = v912;\nL_01E3:\n\tv734 = this.curves;\n\tv396 = v396 + 1;\n\tv918 = this.curves == 0;\n\tv474 = ~v918;\n\tif (v474) goto L_003C;\n\tgoto L_02DB;\nL_01F3:\n\tv755 = v734.Length < 1;\n\tif (v755) goto L_028D;\nL_01F8:\n\tv119 = this.largestEndTime;\n\tv81 = this.largestEndTime <= 0;\n\tif (v81) goto L_022E;\n\tv507 = this.endTimes;\n\tv903 = v522 < v507.Length;\n\tv823 = ~v903;\n\tif (v823) goto L_02EA;\n\tv880 = v522 << 2;\n\tv919 = v507 + v880;\n\tv899 = v919 + 0x20;\n\tv97 = *([v899 @ X8_v31]);\n\tv878 = *([v899 @ X8_v31]) != -1f;\n\tif (v878) goto L_022E;\n\t*([v899 @ X8_v31]) = this.largestEndTime;\n\tgoto L_027C;\nL_022E:\n\tv82 = v119 != 0;\n\tif (v82) goto L_027C;\n\tv508 = this.endTimes;\n\tv921 = v522 < v508.Length;\n\tv824 = ~v921;\n\tif (v824) goto L_02EA;\n\tv83 = v508[v522 @ X20_v10 (System.Int32)] != -1f;\n\tif (v83) goto L_027C;\n\tv448 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.time);\n\tv386 = this.endTimes;\n\tv940 = v448 == 0;\n\tif (v940) goto L_026B;\n\tv944 = v522 < v386.Length;\n\tv825 = ~v944;\n\tif (v825) goto L_02EA;\n\tv386[v522 @ X20_v10 (System.Int32)] = 0x3F800000;\n\tgoto L_027C;\nL_026B:\n\tv119 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv963 = v522 < v386.Length;\n\tv826 = ~v963;\n\tif (v826) goto L_02EA;\n\tv386[v522 @ X20_v10 (System.Int32)] = v119;\nL_027C:\n\tv513 = this.curves;\n\tv522 = v522 + 1;\n\tv843 = v522 < v513.Length;\n\tif (v843) goto L_01F8;\nL_028D:\n\tv510 = this.fromFloats;\n\t// 658 NewArr v427 @ X0_v17 (System.Single[]), typeof(System.Single[]), v510.Length\n\tv512 = this.fromFloats;\n\tthis.distances = v427;\nL_02A2:\n\tv76 = v155 >= v512.Length;\n\tif (v76) goto L_02E9;\n\tv74 = this.toFloats;\n\tv937 = v155 < v74.Length;\n\tv827 = ~v937;\n\tif (v827) goto L_02EA;\n\tv938 = v155 < v512.Length;\n\tv380 = ~v938;\n\tif (v380) goto L_02EA;\n\tv63 = this.distances;\n\tv942 = v155 < v63.Length;\n\tv358 = ~v942;\n\tif (v358) goto L_02EA;\n\tv134 = v155 + 1;\n\tv112 = v74[v155 @ X9_v9 (System.Int32)] - v512[v155 @ X9_v9 (System.Int32)];\n\tv63[v155 @ X9_v9 (System.Int32)] = v112;\n\tv512 = this.fromFloats;\n\tv950 = this.fromFloats == 0;\n\tv453 = ~v950;\n\tif (v453) goto L_02A2;\nL_02DB:\n\tthrow System.NullReferenceException;\nL_02E9:\n\treturn;\nL_02EA:\n\tv841 = new System.IndexOutOfRangeException();\n\tthrow v841;\n\treturn;\n// 520 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void Init()
		{
			//IL_08fe: Expected O, but got I
			//IL_090d: Expected O, but got I
			//IL_0915: Expected F4, but got O
			//IL_0941: Expected O, but got F4
			//IL_0220: Expected O, but got I
			//IL_03e3: Expected O, but got I
			//IL_03f2: Expected O, but got I
			//IL_06d6: Expected O, but got I
			//IL_06e5: Expected O, but got I
			//IL_047d: Expected O, but got I
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
			float num5 = default(float);
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
										goto IL_04aa;
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
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101CD48 (inside UnityEngine.Internal.ExcludeFromDocsAttribute::.ctor +0x8)");
												if (keyOffsets == null)
												{
													break;
												}
												goto IL_04aa;
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
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101CD48 (inside UnityEngine.Internal.ExcludeFromDocsAttribute::.ctor +0x8)");
													AnimationCurve[] array11 = curves;
													if (num < array11.Length)
													{
														Keyframe[] keys5 = array11[num].keys;
														if (keys5.Length != 0)
														{
															object obj4 = (long)(IntPtr)keys5 + 32L;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101CD48 (inside UnityEngine.Internal.ExcludeFromDocsAttribute::.ctor +0x8)");
															num5 = value / value;
															num2 = num5 * value;
															goto IL_04aa;
														}
													}
												}
											}
										}
									}
								}
								goto IL_0c45;
							}
						}
						float[] array12 = endTimes;
						if (num < array12.Length)
						{
							array12[num] = -1f;
							goto IL_0c68;
						}
					}
				}
				else
				{
					if (array5.Length < 1)
					{
						goto IL_0aea;
					}
					float num6 = num5;
					int num7 = 0;
					while (true)
					{
						num2 = largestEndTime;
						if (largestEndTime > 0f)
						{
							float[] array13 = endTimes;
							if (num7 >= array13.Length)
							{
								break;
							}
							int num8 = num7 << 2;
							object obj5 = (long)(IntPtr)array13 + (long)num8;
							object obj6 = (long)(IntPtr)obj5 + 32L;
							num6 = (float)obj6;
							if ((float)obj6 == -1f)
							{
								obj6 = largestEndTime;
								goto IL_0cf0;
							}
						}
						if (num2 == 0f)
						{
							float[] array14 = endTimes;
							if (num7 >= array14.Length)
							{
								break;
							}
							bool flag3 = array14[num7] != -1f;
							num2 = array14[num7];
							if (!flag3)
							{
								bool isNone = time.IsNone;
								float[] array15 = endTimes;
								if (isNone)
								{
									if (num7 >= array15.Length)
									{
										break;
									}
									array15[num7] = 1f;
									num2 = array14[num7];
								}
								else
								{
									num2 = time.Value;
									if (num7 >= array15.Length)
									{
										break;
									}
									array15[num7] = num2;
								}
							}
						}
						goto IL_0cf0;
						IL_0cf0:
						AnimationCurve[] array16 = curves;
						num7++;
						bool flag4 = num7 < array16.Length;
						num5 = num6;
						if (flag4)
						{
							continue;
						}
						goto IL_0aea;
					}
				}
				goto IL_0c45;
				IL_0730:
				float[] array17;
				if (num < array17.Length)
				{
					array17[num] = num2;
					float[] array18 = endTimes;
					if (num < array18.Length)
					{
						num5 = largestEndTime;
						if (largestEndTime < array18[num])
						{
							largestEndTime = array18[num];
						}
						bool flag5 = !looping;
						bool flag6 = !flag5;
						num2 = array18[num];
						if (!flag6)
						{
							AnimationCurve[] array19 = curves;
							if (num >= array19.Length)
							{
								goto IL_0c45;
							}
							WrapMode postWrapMode = array19[num].postWrapMode;
							bool flag7 = ActionHelpers.IsLoopingWrapMode(postWrapMode);
							looping = flag7;
							num2 = array18[num];
						}
						goto IL_0c68;
					}
				}
				goto IL_0c45;
				IL_04aa:
				if (num < array7.Length)
				{
					array7[num] = num2;
					bool isNone2 = ignoreCurveOffset.IsNone;
					bool flag8 = !isNone2;
					bool flag9 = !flag8;
					float num9 = 0f;
					if (!flag9)
					{
						bool value2 = ignoreCurveOffset.Value;
						bool flag10 = !value2;
						num9 = 0f;
						if (!flag10)
						{
							float[] array20 = keyOffsets;
							if (num >= array20.Length)
							{
								goto IL_0c45;
							}
							num9 = array20[num];
						}
					}
					currentTime = num9;
					bool isNone3 = time.IsNone;
					array17 = endTimes;
					if (!isNone3)
					{
						num2 = time.Value;
						goto IL_0730;
					}
					AnimationCurve[] array21 = curves;
					if (num < array21.Length)
					{
						Keyframe[] keys6 = array21[num].keys;
						AnimationCurve[] array22 = curves;
						if (num < array22.Length)
						{
							int length2 = array22[num].length;
							int num10 = length2 - 1;
							if (num10 < keys6.Length)
							{
								int num11 = num10 * 28;
								object obj7 = (long)(IntPtr)keys6 + (long)num11;
								object obj8 = (long)(IntPtr)obj7 + 32L;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101CD48 (inside UnityEngine.Internal.ExcludeFromDocsAttribute::.ctor +0x8)");
								if (array17 == null)
								{
									break;
								}
								goto IL_0730;
							}
						}
					}
				}
				goto IL_0c45;
				IL_0c45:
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
				IL_0aea:
				float[] array23 = fromFloats;
				float[] array24 = new float[array23.Length];
				float[] array25 = fromFloats;
				distances = array24;
				int num12 = 0;
				while (true)
				{
					if (num12 < array25.Length)
					{
						float[] array26 = toFloats;
						if (num12 >= array26.Length || num12 >= array25.Length)
						{
							break;
						}
						float[] array27 = distances;
						if (num12 >= array27.Length)
						{
							break;
						}
						int num13 = num12 + 1;
						float num14 = array26[num12] - array25[num12];
						array27[num12] = num14;
						array25 = fromFloats;
						bool flag11 = fromFloats == null;
						bool flag12 = !flag11;
						num12 = num13;
						if (!flag12)
						{
							goto end_IL_0d4e;
						}
						continue;
					}
					return;
				}
				goto IL_0c45;
				IL_0c68:
				array5 = curves;
				num++;
				continue;
				end_IL_0d4e:
				break;
			}
			while (curves != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000642")]
		[Address(RVA = "0xA94674", Offset = "0xA94674", Length = "0x1070")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv39 = ~this.isRunning;\n\tv40 = ~v39;\n\tif (v40) goto L_004F;\n\tv42 = ~this.start;\n\tif (v42) goto L_004C;\n\tv103 = this.delayTime >= 0;\n\tif (v103) goto L_0034;\n\tthis.isRunning = 1;\n\tthis.start = 0;\n\tv224 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tthis.startTime = v224;\n\tv318 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv525 = this.startTime;\n\tv109 = v318 - this.startTime;\n\tthis.lastTime = v109;\n\tgoto L_004C;\nL_0034:\n\tv115 = ~this.realTime;\n\tif (v115) goto L_0048;\n\tv320 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv434 = v320 - this.startTime;\n\tv435 = v434 - this.lastTime;\n\tthis.deltaTime = v435;\n\tv436 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv522 = this.deltaTime;\n\tv519 = this.delayTime;\n\tv110 = v436 - this.startTime;\n\tv525 = this.delayTime - this.deltaTime;\n\tthis.lastTime = v110;\n\tthis.delayTime = v525;\n\tgoto L_004C;\nL_0048:\n\tv321 = UnityEngine.Time::get_deltaTime();\n\tv108 = this.delayTime - v321;\n\tthis.delayTime = v108;\nL_004C:\n\tv87 = ~this.isRunning;\n\tif (v87) goto L_07F6;\nL_004F:\n\tv91 = ~this.finishAction;\n\tv92 = ~v91;\n\tif (v92) goto L_07F6;\n\tv120 = ~this.realTime;\n\tif (v120) goto L_0073;\n\tv226 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv522 = this.lastTime;\n\tv325 = v226 - this.startTime;\n\tv326 = v325 - this.lastTime;\n\tthis.deltaTime = v326;\n\tv327 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv525 = this.startTime;\n\tv376 = v327 - this.startTime;\n\tthis.lastTime = v376;\n\tv459 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.speed);\n\tv155 = this + 0x80;\n\tv464 = v459 == 0;\n\tif (v464) goto L_0084;\n\tv529 = this.currentTime + this.deltaTime;\n\tgoto L_008F;\nL_0073:\n\tv329 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.speed);\n\tv155 = this + 0x80;\n\tv377 = UnityEngine.Time::get_deltaTime();\n\tv461 = v329 == 0;\n\tif (v461) goto L_008C;\n\tv529 = this.currentTime + v377;\n\tgoto L_008F;\nL_0084:\n\tv482 = HutongGames.PlayMaker.FsmFloat::get_Value(this.speed);\n\tv597 = this.deltaTime * v482;\n\tv529 = this.currentTime + v597;\n\tgoto L_008F;\nL_008C:\n\tv481 = HutongGames.PlayMaker.FsmFloat::get_Value(this.speed);\n\tv596 = v377 * v481;\n\tv529 = this.currentTime + v596;\nL_008F:\n\t*([v155 @ X21_v3]) = v529;\n\tv609 = this.curves;\n\tv149 = 0x1818000 + 0xE98;\nL_00A2:\n\tv173 = v147 >= v609.Length;\n\tif (v173) goto L_07A1;\n\tv650 = v147 < v609.Length;\n\tv408 = ~v650;\n\tif (v408) goto L_07F9;\n\tv655 = v609[v147 @ X22_v8 (System.Int32)] == 0;\n\tif (v655) goto L_012A;\n\tv279 = UnityEngine.AnimationCurve::get_keys(v609[v147 @ X22_v8 (System.Int32)]);\n\tv743 = v279.Length == 0;\n\tif (v743) goto L_012A;\n\tv648 = this.calculations;\n\tv802 = v147 < v648.Length;\n\tv644 = ~v802;\n\tif (v644) goto L_07F9;\n\tv248 = v147 << 2;\n\tv808 = v648 + v248;\n\tv809 = *([v808 @ X8_v31+20]);\n\tv810 = *([v808 @ X8_v31+20]) < 6;\n\tv306 = ~v810;\n\tv303 = *([v808 @ X8_v31+20]) - 6;\n\tv297 = v303 == 0;\n\tv811 = ~v297;\n\tv282 = v306 & v811;\n\tif (v282) goto L_070C;\n\tv314 = *([v149 @ X23_v8 (System.Int32)+v809 @ X8_v32*4]) + v149;\n\t// 218 IndirectJump v314 @ X8_v34, v279 @ X0_v24 (UnityEngine.Keyframe[]), v279 @ X0_v24 (UnityEngine.Keyframe[]), 0, v234 @ X2, v423 @ X3, v424 @ X4, v425 @ X5, v426 @ X6, v427 @ X7, v529 @ V0_v12 (System.Single), v525 @ V1_v12 (System.Single), v522 @ V2_v9 (System.Single), v519 @ V3_v8 (System.Single), v428 @ V4, v429 @ V5, v430 @ V6, v431 @ V7\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_0804;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.NamedVariable::get_IsNone(X0, X1);\n\tX8 = *([X19+C0]);\n\tif (TEMP) goto L_07F8;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_07FD;\n\tX9 = *([X19+D0]);\n\tif (TEMP) goto L_07F8;\n\tX10 = *([X9+18]);\n\tC = X22 < X10;\n\tC = ~C;\n\tTEMP1 = X22 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X10;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_07FD;\n\tTEMPSHIFT = X26 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tTEMPSHIFT = X26 << 2;\n\tX9 = X9 + TEMPSHIFT;\n\tX27 = *([X19+B8]);\n\tV8 = *([X8+20]);\n\tV9 = *([X9+20]);\n\tV10 = *([X19+80]);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_041D;\n\tX8 = *([X19+88]);\n\tif (TEMP) goto L_07F8;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_07FD;\n\tif (TEMP) goto L_07F8;\n\tX9 = *([X27+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_07FD;\n\tTEMPSHIFT = X26 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tV0 = *([X8+20]);\n\tgoto L_01A3;\nL_012A:\n\tv531 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.time);\n\tv766 = v531 == 0;\n\tif (v766) goto L_016D;\n\tv589 = this.fromFloats;\n\tv803 = v147 < v589.Length;\n\tv572 = ~v803;\n\tif (v572) goto L_07FD;\n\tv496 = this.distances;\n\tv840 = v147 < v496.Length;\n\tv729 = ~v840;\n\tif (v729) goto L_07FD;\n\tv814 = this.resultFloats;\n\tv522 = this.currentTime;\n\tv534 = this.largestEndTime != 0;\n\tif (v534) goto L_01AA;\n\tv845 = v147 < v814.Length;\n\tv730 = ~v845;\n\tv684 = ~v730;\n\tif (v684) goto L_01B5;\n\tgoto L_07FD;\nL_016D:\n\tv457 = this.fromFloats;\n\tv804 = v147 < v457.Length;\n\tv574 = ~v804;\n\tif (v574) goto L_07FD;\n\tv440 = this.distances;\n\tv841 = v147 < v440.Length;\n\tv453 = ~v841;\n\tif (v453) goto L_07FD;\n\tv814 = this.resultFloats;\nL_0195:\n\tv528 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv862 = v147 < v814.Length;\n\tv731 = ~v862;\n\tif (v731) goto L_07FD;\nL_01A3:\n\tv866 = this.currentTime / v528;\n\tv867 = v440[v147 @ X22_v8 (System.Int32)] * v866;\n\tv529 = v457[v147 @ X22_v8 (System.Int32)] + v867;\n\tgoto L_070B;\nL_01AA:\n\tv846 = v147 < v814.Length;\n\tv732 = ~v846;\n\tif (v732) goto L_07FD;\n\tv522 = v522 / this.largestEndTime;\nL_01B5:\n\tv525 = v496[v147 @ X22_v8 (System.Int32)] * v522;\nL_01B6:\n\tv529 = v589[v147 @ X22_v8 (System.Int32)] + v525;\n\tgoto L_070B;\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_0803;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.NamedVariable::get_IsNone(X0, X1);\n\tX8 = *([X19+C0]);\n\tif (TEMP) goto L_0802;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_07F9;\n\tX9 = *([X19+D0]);\n\tif (TEMP) goto L_0802;\n\tX10 = *([X9+18]);\n\tC = X22 < X10;\n\tC = ~C;\n\tTEMP1 = X22 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X10;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_07F9;\n\tTEMPSHIFT = X26 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tTEMPSHIFT = X26 << 2;\n\tX9 = X9 + TEMPSHIFT;\n\tX27 = *([X19+B8]);\n\tV11 = *([X8+20]);\n\tV12 = *([X9+20]);\n\tV8 = *([X19+80]);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0422;\n\tX8 = *([X19+88]);\n\tif (TEMP) goto L_0802;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_07F9;\n\tX9 = *([X19+A8]);\n\tif (TEMP) goto L_0802;\n\tX10 = *([X9+18]);\n\tC = X22 < X10;\n\tC = ~C;\n\tTEMP1 = X22 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X10;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_07F9;\n\tTEMPSHIFT = X26 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX0 = *([X9+20]);\n\tif (TEMP) goto L_0803;\n\tTEMPSHIFT = X26 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tV9 = *([X8+20]);\n\tV0 = V8;\n\tgoto L_0483;\n\tX0 = *([X19+50]);\n\tif (TEMP) goto L_0803;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.NamedVariable::get_IsNone(X0, X1);\n\tX8 = *([X19+C0]);\n\tif (TEMP) goto L_0802;\n\tX9 = *([X8+18]);\n\tC = X22 < X9;\n\tC = ~C;\n\tTEMP1 = X22 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X9;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_07F9;\n\tX9 = *([X19+D0]);\n\tif (TEMP) goto L_0802;\n\tX10 = *([X9+18]);\n\tC = X22 < X10;\n\tC = ~C;\n\tTEMP1 = X22 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ X10;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_07F9;\n\tTEMPSHIFT = X26 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tTEMPSHIFT = X26 << 2;\n\tX9 = X9 + TEMPSHIFT;\n\tX27 = *([X19+B8]);\n\tV11 = *([X8+20]);\n\tV12 = *([X9+20]);\n\tV8 = *([X19+80]);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0497;\n\tX8 = *([X19+88]);\n\tif (TEMP) goto L_0802;\n\tX9 = *([X8+18]\n// ... truncated")]
		public override void OnUpdate()
		{
			//IL_02c1: Expected O, but got I
			//IL_0872: Expected O, but got F4
			//IL_0271: Expected O, but got I
			//IL_0466: Expected O, but got I
			//IL_0476: Expected O, but got I
			//IL_04ae: Expected O, but got I
			//IL_04f8: Expected O, but got I
			if (!isRunning)
			{
				if (start)
				{
					if (delayTime < 0f)
					{
						isRunning = true;
						start = false;
						float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
						startTime = realtimeSinceStartup;
						float realtimeSinceStartup2 = FsmTime.RealtimeSinceStartup;
						float num = startTime;
						float num2 = realtimeSinceStartup2 - startTime;
						lastTime = num2;
					}
					else if (realTime)
					{
						float realtimeSinceStartup3 = FsmTime.RealtimeSinceStartup;
						float num3 = realtimeSinceStartup3 - startTime;
						float num4 = num3 - lastTime;
						deltaTime = num4;
						float realtimeSinceStartup4 = FsmTime.RealtimeSinceStartup;
						float num5 = deltaTime;
						float num6 = delayTime;
						float num7 = realtimeSinceStartup4 - startTime;
						float num = delayTime - deltaTime;
						lastTime = num7;
						delayTime = num;
					}
					else
					{
						float num8 = Time.deltaTime;
						float num9 = delayTime - num8;
						delayTime = num9;
					}
				}
				if (!isRunning)
				{
					return;
				}
			}
			if (finishAction)
			{
				return;
			}
			object obj;
			float num13;
			if (realTime)
			{
				float realtimeSinceStartup5 = FsmTime.RealtimeSinceStartup;
				float num5 = lastTime;
				float num10 = realtimeSinceStartup5 - startTime;
				float num11 = num10 - lastTime;
				deltaTime = num11;
				float realtimeSinceStartup6 = FsmTime.RealtimeSinceStartup;
				float num = startTime;
				float num12 = realtimeSinceStartup6 - startTime;
				lastTime = num12;
				bool isNone = speed.IsNone;
				obj = (long)(IntPtr)this + 128L;
				if (isNone)
				{
					num13 = currentTime + deltaTime;
				}
				else
				{
					float value = speed.Value;
					float num14 = deltaTime * value;
					num13 = currentTime + num14;
				}
			}
			else
			{
				bool isNone2 = speed.IsNone;
				obj = (long)(IntPtr)this + 128L;
				float num15 = Time.deltaTime;
				if (isNone2)
				{
					num13 = currentTime + num15;
				}
				else
				{
					float value2 = speed.Value;
					float num16 = num15 * value2;
					num13 = currentTime + num16;
				}
			}
			obj = num13;
			AnimationCurve[] array = curves;
			int num17 = 25264128 + 3736;
			int num18 = 0;
			int num23;
			while (true)
			{
				float[] array5;
				if (num18 < array.Length)
				{
					if (num18 >= array.Length)
					{
						goto IL_0832;
					}
					if (array[num18] != null)
					{
						Keyframe[] keys = array[num18].keys;
						if (keys.Length != 0)
						{
							Calculation[] array2 = calculations;
							if (num18 >= array2.Length)
							{
								goto IL_0832;
							}
							int num19 = num18 << 2;
							object obj2 = (long)(IntPtr)array2 + (long)num19;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ X8_v31+20]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ X8_v31+20]");
							bool flag = 0L < 6L;
							bool flag2 = !flag;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ X8_v31+20]");
							object obj4 = -6;
							bool flag3 = obj4 == null;
							bool flag4 = !flag3;
							if (flag2 && flag4)
							{
								goto IL_0881;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X23_v8 (System.Int32)+v809 @ X8_v32*4]");
							object obj5 = 0L + (long)num17;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v314 @ X8_v34 (should have been resolved before IL gen)");
						}
					}
					if (time.IsNone)
					{
						float[] array3 = fromFloats;
						if (num18 < array3.Length)
						{
							float[] array4 = distances;
							if (num18 < array4.Length)
							{
								array5 = resultFloats;
								float num5 = currentTime;
								if (largestEndTime == 0f)
								{
									if (num18 >= array5.Length)
									{
										goto IL_0840;
									}
								}
								else
								{
									if (num18 >= array5.Length)
									{
										goto IL_0840;
									}
									num5 /= largestEndTime;
								}
								float num = array4[num18] * num5;
								num13 = array3[num18] + num;
								goto IL_073c;
							}
						}
					}
					else
					{
						float[] array6 = fromFloats;
						if (num18 < array6.Length)
						{
							float[] array7 = distances;
							if (num18 < array7.Length)
							{
								array5 = resultFloats;
								float value3 = time.Value;
								if (num18 < array5.Length)
								{
									float num20 = currentTime / value3;
									float num21 = array7[num18] * num20;
									num13 = array6[num18] + num21;
									goto IL_073c;
								}
							}
						}
					}
				}
				else
				{
					if (!isRunning)
					{
						return;
					}
					float[] array8 = endTimes;
					finishAction = true;
					int num22 = array8.Length;
					if (array8.Length < 1)
					{
						num23 = 1;
						break;
					}
					int num24 = 0;
					num23 = 1;
					while (num24 < num22)
					{
						if (currentTime < array8[num24])
						{
							finishAction = false;
							num23 = 0;
						}
						num22 = array8.Length;
						num24++;
						if (num24 >= array8.Length)
						{
							goto end_IL_0964;
						}
					}
				}
				goto IL_0840;
				IL_073c:
				array5[num18] = num13;
				goto IL_0881;
				IL_0881:
				array = curves;
				num18++;
				if (curves != null)
				{
					continue;
				}
				NullReferenceException ex = new NullReferenceException();
				goto IL_0832;
				IL_0832:
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
				throw ex2;
				IL_0840:
				IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
				throw ex3;
				continue;
				end_IL_0964:
				break;
			}
			int num25 = num23 ^ 1;
			isRunning = (byte)num25 != 0;
		}

		[Token(Token = "0x6000643")]
		[Address(RVA = "0xA956EC", Offset = "0xA956EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal CurveFsmAction()
		{
		}
	}
}
