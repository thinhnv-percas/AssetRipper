using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using DG.Tweening.Plugins.Options;

namespace DG.Tweening
{
	[Token(Token = "0x200001A")]
	public abstract class Tweener : Tween
	{
		[Token(Token = "0x40000C5")]
		[FieldOffset(Offset = "0x118")]
		internal bool hasManuallySetStartValue;

		[Token(Token = "0x40000C6")]
		[FieldOffset(Offset = "0x119")]
		internal bool isFromAllowed;

		[Token(Token = "0x6000171")]
		[Address(RVA = "0x160627C", Offset = "0x160627C", Length = "0x1028")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isFromAllowed = 1;\n\tthis.intId = 0xFFFFFC19;\n\tthis.activeId = 0xFFFFFFFF;\n\tthis.delayComplete = 1;\n\tthis.miscInt = 0xFFFFFFFF;\n\tDG.Tweening.Core.ABSSequentiable::.ctor(this);\n\treturn;\n\tIAPDemo::OnInitialized(X0, X1, X2, X3);\n\treturn;\n\tX8 = *([X8]);\n\tX0 = 0x1605008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1025 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Tweener()
		{
			isFromAllowed = true;
			intId = -999;
			activeId = -1;
			delayComplete = true;
			miscInt = -1;
		}

		[Token(Token = "0x6000172")]
		public abstract Tweener ChangeStartValue(object newStartValue, float newDuration = -1f);

		[Token(Token = "0x6000173")]
		public abstract Tweener ChangeEndValue(object newEndValue, float newDuration = -1f, bool snapStartValue = false);

		[Token(Token = "0x6000174")]
		public abstract Tweener ChangeEndValue(object newEndValue, bool snapStartValue);

		[Token(Token = "0x6000175")]
		public abstract Tweener ChangeValues(object newStartValue, object newEndValue, float newDuration = -1f);

		[Token(Token = "0x6000176")]
		internal abstract Tweener SetFrom(bool relative);

		[Token(Token = "0x6000177")]
		[Address(RVA = "0x11B7798", Offset = "0x11B7798", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv42 = *([1EFADF0]);\n\tv43 = *([v42 @ X8_v37]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, getter, setter, endValue, plugin, methodInfo, v45, v46, duration, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2027B02]) = v56;\nL_0021:\n\tv58 = plugin == 0;\n\tif (v58) goto L_0026;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]) = plugin;\n\tgoto L_0030;\nL_0026:\n\tv62 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]) == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0030;\n\tv65 = DG.Tweening.Plugins.Core.PluginsManager::GetDefaultPlugin();\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]) = v65;\n\tv67 = v65 == 0;\n\tif (v67) goto L_008F;\nL_0030:\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]) = getter;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+188]) = setter;\n\tendValue->klass = endValue->klass;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+14C]) = *([endValue @ X3 (T2)+10]);\n\tt.duration = duration;\n\tgoto L_0048;\n\tv144 = *([v76 @ X0_v6 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv145 = v144 == 0;\n\tv146 = ~v145;\n\tif (v146) goto L_0048;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v76, getter, setter, endValue, plugin, methodInfo, v45, v46, v70, v71, v48, v49, v50, v51, v52, v53);\n\tv148 = DG.Tweening.DOTween;\nL_0048:\n\tt.autoKill = v151.defaultAutoKill;\n\tt.isRecyclable = v153.defaultRecyclable;\n\tt.easeType = v155.defaultEaseType;\n\tt.easeOvershootOrAmplitude = v157.defaultEaseOvershootOrAmplitude;\n\tt.easePeriod = v159.defaultEasePeriod;\n\tt.loopType = v161.defaultLoopType;\n\tv174 = v163.defaultAutoPlay != 3;\n\tif (v174) goto L_006A;\n\tgoto L_007E;\nL_006A:\n\tgoto L_0075;\n\tv210 = *([v147 @ X0_v7 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\tif (v212) goto L_0075;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v147, getter, setter, endValue, plugin, methodInfo, v45, v46, v70, v71, v48, v49, v50, v51, v52, v53);\n\tv218 = DG.Tweening.DOTween;\n\tv219 = *([v218 @ X8_v25+B8]);\n\tv215 = *([v219 @ X8_v26+3C]);\nL_0075:\n\tv198 = v163.defaultAutoPlay - 2;\n\tv194 = v198 == 0;\nL_007E:\n\tt.isPlaying = v207;\nL_008A:\n\treturn returnVal2;\nL_008F:\n\tDG.Tweening.Core.Debugger::LogError(\"No suitable plugin found for this type\");\n\tgoto L_008A;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Setup<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t, DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration, ABSTweenPlugin<T1, T2, TPlugOptions> plugin = null) where TPlugOptions : struct, IPlugOptions
		{
			if (plugin == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					ABSTweenPlugin<T1, T2, TPlugOptions> defaultPlugin = PluginsManager.GetDefaultPlugin<T1, T2, TPlugOptions>();
					if (defaultPlugin == null)
					{
						Debugger.LogError("No suitable plugin found for this type");
						return false;
					}
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [endValue @ X3 (T2)+10]");
			_ = 0;
			t.duration = duration;
			t.autoKill = DOTween.defaultAutoKill;
			t.isRecyclable = DOTween.defaultRecyclable;
			t.easeType = DOTween.defaultEaseType;
			t.easeOvershootOrAmplitude = DOTween.defaultEaseOvershootOrAmplitude;
			t.easePeriod = DOTween.defaultEasePeriod;
			t.loopType = DOTween.defaultLoopType;
			int num;
			if (DOTween.defaultAutoPlay == AutoPlay.All)
			{
				num = 1;
			}
			else
			{
				int num2 = (int)(DOTween.defaultAutoPlay - 2);
				bool flag = num2 == 0;
				num = (flag ? 1 : 0);
			}
			t.isPlaying = (byte)num != 0;
			return true;
		}

		[Token(Token = "0x6000178")]
		[Address(RVA = "0xBAE084", Offset = "0xBAE084", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = t.delay >= elapsed;\n\tif (v13) goto L_0013;\n\treturnVal1 = elapsed - t.delay;\n\tt.elapsedDelay = t.delay;\n\tt.delayComplete = 1;\n\treturn returnVal1;\nL_0013:\n\tt.elapsedDelay = elapsed;\n\treturn 0;\n\tthrow System.NullReferenceException;\n\treturn elapsed;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static float DoUpdateDelay<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t, float elapsed) where TPlugOptions : struct, IPlugOptions
		{
			if (t.delay < elapsed)
			{
				float result = elapsed - t.delay;
				t.elapsedDelay = t.delay;
				t.delayComplete = true;
				return result;
			}
			t.elapsedDelay = elapsed;
			return 0f;
		}

		[Token(Token = "0x6000179")]
		[Address(RVA = "0x11B4234", Offset = "0x11B4234", Length = "0x320")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-10_v2;\n\tgoto L_001A;\n\tv24 = *([1EB9458]);\n\tv25 = *([v24 @ X8_v64]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2027AEF]) = v43;\nL_001A:\n\tt.startupDone = 1;\n\tv47 = t.specialStartupMode == 0;\n\tif (v47) goto L_0026;\n\tv108 = DG.Tweening.Tweener::DOStartupSpecials(t);\n\tv110 = v108 == 0;\n\tif (v110) goto L_FFFFFFFF;\nL_0026:\n\tv116 = ~t.hasManuallySetStartValue;\n\tv117 = ~v116;\n\tif (v117) goto L_0076;\n\tgoto L_0037;\n\tv324 = *([v209 @ X0_v28 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv325 = v324 == 0;\n\tv326 = ~v325;\n\tif (v326) goto L_0037;\n\tv403 = \"il2cpp_codegen_runtime_class_init\"(v209, v111, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv328 = DG.Tweening.DOTween;\nL_0037:\n\tv102 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]);\n\tv332 = ~v331.useSafeMode;\n\tif (v332) goto L_005C;\n\tv421 = DG.Tweening.Core.DOGetter`1<T1>::Invoke(*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]));\n\tv422 = v102 == 0;\n\tif (v422) goto L_00A0;\n\tv439 = *([v102 @ X21_v10]);\n\t*([v12 @ X29_v1-40]) = v420;\n\t*([v12 @ X29_v1-30]) = v436;\n\tv190 = *([v439 @ X8_v57+1A8]);\n\tv446 = &v13 @ stack_-10_v2 - 0x40;\n\t*([v439 @ X8_v57+1A0])(v449, v102, t, v446, *([v439 @ X8_v57+1A8]), v29, v30, v31, v32, v436, v420, v35, v36, v37, v38, v39, v40);\n\tgoto L_0071;\nL_005C:\n\tv89 = DG.Tweening.Core.DOGetter`1<T1>::Invoke(*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]));\n\tv454 = &v13 @ stack_-10_v2 - 0x40;\n\tv459 = *([v102 @ X21_v10]);\n\t*([v12 @ X29_v1-40]) = v76;\n\t*([v12 @ X29_v1-30]) = v436;\n\tv190 = *([v459 @ X8_v31+1A8]);\n\t*([v459 @ X8_v31+1A0])(v466, v102, t, v454, *([v459 @ X8_v31+1A8]), v29, v30, v31, v32, v436, v76, v35, v36, v37, v38, v39, v40);\nL_0071:\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]) = v470;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+11C]) = v216;\nL_0076:\n\tv231 = ~t.<isRelative>k__BackingField;\n\tif (v231) goto L_0080;\n\tv163 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]);\n\tv339 = *([v163 @ X0_v26]);\n\t*([v339 @ X8_v21+1B0])(v337, v163, t, *([v339 @ X8_v21+1B8]), v190, v29, v30, v31, v32, v379, v381, v35, v36, v37, v38, v39, v40);\nL_0080:\n\tv164 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]);\n\tv405 = *([v164 @ X0_v21]);\n\t*([v405 @ X8_v16+1C0])(v407, v164, t, *([v405 @ X8_v16+1C8]), v190, v29, v30, v31, v32, v379, v381, v35, v36, v37, v38, v39, v40);\n\tv411 = DG.Tweening.Tweener::DOStartupDurationBased(t);\n\tv412 = t.duration < 0;\n\tv292 = ~v412;\n\tv286 = t.duration == 0;\n\tv413 = ~v286;\n\tv276 = v292 & v413;\n\tif (v276) goto L_FFFFFFFF;\n\tt.easeType = 0x24;\n\tgoto L_0104;\n\tthrow System.NullReferenceException;\nL_00A0:\n\tv428 = new System.NullReferenceException();\n\tgoto L_00AC;\nL_00AC:\n\tv233 = v387 != 1;\n\tif (v233) goto L_0112;\n\tv474 = 0x6D2BC0(v428, v387, v369, v190, v29, v30, v31, v32, v379, v381, v35, v36, v37, v38, v39, v40);\n\tv95 = *([v474 @ X0_v39]);\n\tv264 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v95 @ X19_v11 (System.Exception)]), v369, v190, v29, v30, v31, v32, v379, v381, v35, v36, v37, v38, v39, v40);\n\tv477 = v264 & 1;\n\tv266 = v477 == 0;\n\tif (v266) goto L_0108;\n\tv478 = 0x6D2490(v264, *([v95 @ X19_v11 (System.Exception)]), v369, v190, v29, v30, v31, v32, v379, v381, v35, v36, v37, v38, v39, v40);\n\tgoto L_00D5;\n\tv483 = *([1EA8078]);\n\tv484 = *([v483 @ X8_v53]);\n\tv485 = \"il2cpp_codegen_initialize_method\"(v484, v83, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv487 = 0 | 1;\n\t*([2022B9B]) = v487;\nL_00D5:\n\tv50 = v491._logPriority < 1;\n\tif (v50) goto L_00F0;\n\tv512 = System.Exception::get_TargetSite(v95);\n\tv523 = System.Exception::get_Message(v95);\n\tv501 = System.String::Format(\"Tween startup failed (NULL target/property - {0}): the tween will now be killed ► {1}\", v512, v523);\n\tDG.Tweening.Core.Debugger::LogWarning(v501);\nL_00F0:\n\tgoto L_00FA;\n\tv513 = *([v506 @ X0_v45 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv514 = v513 == 0;\n\tv515 = ~v514;\n\tif (v515) goto L_00FA;\n\tv528 = \"il2cpp_codegen_runtime_class_init\"(v506, v497, v494, v190, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv517 = DG.Tweening.DOTween;\nL_00FA:\n\tv519 = v516.Version + 0x68;\n\tv198 = 0x1075B9C(v519, 3, 0, v190, v29, v30, v31, v32, v379, v381, v35, v36, v37, v38, v39, v40);\nL_0104:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0108:\n\tv274 = 0x6D1E60(8, v261, v252, v254, v29, v30, v31, v32, v257, v258, v35, v36, v37, v38, v39, v40);\n\t*([v274 @ X0_v10]) = *([v268 @ X20_v4]);\n\tv387 = 0x1E8A000 + 0x870;\n\tv344 = 0x6D2A00(v274, v387, 0, v254, v29, v30, v31, v32, v257, v258, v35, v36, v37, v38, v39, v40);\n\tv415 = 0x6D2490(v344, v387, 0, v254, v29, v30, v31, v32, v257, v258, v35, v36, v37, v38, v39, v40);\nL_0112:\n\tv433 = 0x6D2380(v395, v387, 0, v190, v29, v30, v31, v32, v379, v381, v35, v36, v37, v38, v39, v40);\n\treturnVal2 = 0x846AA4(v433, v387, 0, v190, v29, v30, v31, v32, v379, v381, v35, v36, v37, v38, v39, v40);\n\treturn returnVal2;\n// 172 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool DoStartup<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t) where TPlugOptions : struct, IPlugOptions
		{
			//IL_0483: Expected O, but got I
			//IL_0187: Expected O, but got I
			//IL_03f2: Expected O, but got I
			//IL_0126: Expected O, but got I
			//IL_013e: Expected O, but got I
			//IL_0160: Expected O, but got I
			//IL_00ac: Expected O, but got I
			//IL_00ef: Expected O, but got I
			//IL_00fe: Expected O, but got I
			//IL_045f: Expected O, but got I
			//IL_0316: Expected O, but got I4
			object obj2 = default(object);
			object obj = obj2;
			t.startupDone = true;
			IntPtr intPtr = default(IntPtr);
			if (t.specialStartupMode != SpecialStartupMode.None)
			{
				bool flag = DOStartupSpecials(t);
				bool flag2 = !flag;
				intPtr = (IntPtr)0;
				if (flag2)
				{
					goto IL_0320;
				}
			}
			if (!t.hasManuallySetStartValue)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]");
				object obj3 = 0;
				object obj11;
				if (DOTween.useSafeMode)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]");
					T1 val = ((DOGetter<T1>)0)();
					object obj6;
					object obj13;
					if (obj3 == null)
					{
						NullReferenceException ex = new NullReferenceException();
						bool flag3 = intPtr != (IntPtr)1;
						NullReferenceException ex2 = ex;
						if (!flag3)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
							object obj4 = default(object);
							Exception ex3 = (Exception)obj4;
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
							object obj5 = default(object);
							if ((uint)((ulong)(long)(IntPtr)obj5 & 1uL) != 0)
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
								if (Debugger._logPriority >= 1)
								{
									MethodBase targetSite = ex3.TargetSite;
									string message = ex3.Message;
									string message2 = $"Tween startup failed (NULL target/property - {targetSite}): the tween will now be killed ► {message}";
									Debugger.LogWarning(message2);
									obj6 = 0;
								}
								object obj7 = (long)(IntPtr)DOTween.Version + 104L;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1075B9C (inside DG.Tweening.Core.Easing.Flash::WeightedEase +0x170)");
								goto IL_0320;
							}
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
							object obj9 = default(object);
							object obj8 = obj9;
							intPtr = (IntPtr)(32022528 + 2160);
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
							object obj10 = default(object);
							obj6 = obj10;
							object obj12 = default(object);
							obj11 = obj12;
							object obj14 = default(object);
							obj13 = obj14;
							NullReferenceException ex4 = default(NullReferenceException);
							ex2 = ex4;
						}
						Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
						bool result = default(bool);
						return result;
					}
					object obj15 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ X8_v57+1A8]");
					obj6 = 0;
					object obj16 = (long)(IntPtr)obj2 - 64L;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v439 @ X8_v57+1A0] (should have been resolved before IL gen)");
					object obj17 = default(object);
					obj13 = obj17;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]");
					T1 val2 = ((DOGetter<T1>)0)();
					object obj18 = (long)(IntPtr)obj2 - 64L;
					object obj19 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ X8_v31+1A8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v459 @ X8_v31+1A0] (should have been resolved before IL gen)");
					object obj20 = default(object);
					object obj13 = obj20;
				}
				object obj21 = default(object);
				obj11 = obj21;
			}
			if (t._003CisRelative_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]");
				object obj22 = 0;
				object obj23 = obj22;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v339 @ X8_v21+1B0] (should have been resolved before IL gen)");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]");
			object obj24 = 0;
			object obj25 = obj24;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v405 @ X8_v16+1C0] (should have been resolved before IL gen)");
			DOStartupDurationBased(t);
			bool flag4 = t.duration < 0f;
			bool flag5 = !flag4;
			bool flag6 = t.duration == 0f;
			bool flag7 = !flag6;
			if (!(flag5 && flag7))
			{
				t.easeType = Ease.INTERNAL_Zero;
			}
			return true;
			IL_0320:
			return false;
		}

		[Token(Token = "0x600017A")]
		[Address(RVA = "0x1366584", Offset = "0x1366584", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tt.hasManuallySetStartValue = 1;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]) = *([newStartValue @ X1 (T2)+10]);\n\tnewStartValue->klass = newStartValue->klass;\n\tv26 = ~t.startupDone;\n\tif (v26) goto L_0035;\n\tv54 = t.specialStartupMode == 0;\n\tif (v54) goto L_0022;\n\tv82 = DG.Tweening.Tweener::DOStartupSpecials(t);\n\tv84 = v82 == 0;\n\tif (v84) goto L_FFFFFFFF;\nL_0022:\n\tv30 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]);\n\tv64 = *([v30 @ X0_v12]);\n\t*([v64 @ X8_v13+1C0])(v60, v30, t, *([v64 @ X8_v13+1C8]), v42, v43, v44, v45, v46, *([newStartValue @ X1 (T2)+10]), *([newStartValue @ X1 (T2)]), v47, v48, v49, v50, v51, v52);\nL_0035:\n\tv77 = newDuration <= 0;\n\tif (v77) goto L_0045;\n\tt.duration = newDuration;\n\tv88 = ~t.startupDone;\n\tif (v88) goto L_0045;\n\tv92 = DG.Tweening.Tweener::DOStartupDurationBased(t);\nL_0045:\n\tv101 = DG.Tweening.Tween::DoGoto(t, 0f, 0, 2);\nL_004D:\n\treturn v160;\n\tgoto L_004D;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static TweenerCore<T1, T2, TPlugOptions> DoChangeStartValue<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t, T2 newStartValue, float newDuration) where TPlugOptions : struct, IPlugOptions
		{
			//IL_009a: Expected O, but got I
			t.hasManuallySetStartValue = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newStartValue @ X1 (T2)+10]");
			_ = 0;
			if (t.startupDone)
			{
				if (t.specialStartupMode != SpecialStartupMode.None && !DOStartupSpecials(t))
				{
					return null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]");
				object obj = 0;
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v64 @ X8_v13+1C0] (should have been resolved before IL gen)");
			}
			if (newDuration > 0f)
			{
				t.duration = newDuration;
				if (t.startupDone)
				{
					DOStartupDurationBased(t);
				}
			}
			bool flag = Tween.DoGoto(t, 0f, 0, UpdateMode.IgnoreOnUpdate);
			return t;
		}

		[Token(Token = "0x600017B")]
		[Address(RVA = "0x136337C", Offset = "0x136337C", Length = "0x30C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = &v17 @ stack_-10_v2;\n\tgoto L_001C;\n\tv34 = *([1EC5B30]);\n\tv35 = *([v34 @ X8_v53]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, newEndValue, snapStartValue, methodInfo, v37, v38, v39, v40, newDuration, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2028847]) = v50;\nL_001C:\n\t*([v16 @ X29_v1-40]) = *([newEndValue @ X1 (T2)+10]);\n\tnewEndValue->klass = newEndValue->klass;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+14C]) = *([v16 @ X29_v1-40]);\n\tv112 = *([v16 @ X29_v1-50]);\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+13C]) = *([v16 @ X29_v1-50]);\n\tt.<isRelative>k__BackingField = 0;\n\tv59 = ~t.startupDone;\n\tif (v59) goto L_009B;\n\tv83 = t.specialStartupMode == 0;\n\tif (v83) goto L_0037;\n\tv169 = DG.Tweening.Tweener::DOStartupSpecials(t);\n\tv171 = v169 == 0;\n\tif (v171) goto L_FFFFFFFF;\nL_0037:\n\tv176 = snapStartValue == 0;\n\tif (v176) goto L_0067;\n\tgoto L_0047;\n\tv338 = *([v279 @ X0_v47 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv339 = v338 == 0;\n\tv340 = ~v339;\n\tif (v340) goto L_0047;\n\tv403 = \"il2cpp_codegen_runtime_class_init\"(v279, v150, snapStartValue, methodInfo, v37, v38, v39, v40, v56, v41, v42, v43, v44, v45, v46, v47);\n\tv342 = DG.Tweening.DOTween;\nL_0047:\n\tv76 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]);\n\tv124 = t + 0x190;\n\tv346 = ~v345.useSafeMode;\n\tif (v346) goto L_006F;\n\tv331 = DG.Tweening.Core.DOGetter`1<T1>::Invoke(*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]));\n\tv333 = v76 == 0;\n\tif (v333) goto L_00BB;\n\tv424 = *([v76 @ X21_v11]);\n\t*([v16 @ X29_v1-50]) = v325;\n\t*([v16 @ X29_v1-40]) = v421;\n\tv96 = *([v424 @ X8_v46+1A8]);\n\tv431 = &v17 @ stack_-10_v2 - 0x50;\n\t*([v424 @ X8_v46+1A0])(v434, v76, t, v431, *([v424 @ X8_v46+1A8]), v37, v38, v39, v40, v421, v325, v42, v43, v44, v45, v46, v47);\n\tgoto L_0084;\nL_0067:\n\tv124 = t + 0x190;\n\tgoto L_0088;\nL_006F:\n\tv70 = DG.Tweening.Core.DOGetter`1<T1>::Invoke(*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]));\n\tv437 = &v17 @ stack_-10_v2 - 0x50;\n\tv442 = *([v76 @ X21_v11]);\n\t*([v16 @ X29_v1-50]) = v61;\n\t*([v16 @ X29_v1-40]) = v421;\n\tv96 = *([v442 @ X8_v42+1A8]);\n\t*([v442 @ X8_v42+1A0])(v449, v76, t, v437, *([v442 @ X8_v42+1A8]), v37, v38, v39, v40, v421, v61, v42, v43, v44, v45, v46, v47);\nL_0084:\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]) = v458;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+11C]) = v350;\nL_0088:\n\tv155 = *([v124 @ X23_v10]);\n\tv122 = *([v155 @ X0_v45]);\n\t*([v122 @ X8_v32+1C0])(v114, v155, t, *([v122 @ X8_v32+1C8]), v96, v37, v38, v39, v40, v112, v104, v42, v43, v44, v45, v46, v47);\nL_009B:\n\tv136 = newDuration <= 0;\n\tif (v136) goto L_00AB;\n\tt.duration = newDuration;\n\tv178 = ~t.startupDone;\n\tif (v178) goto L_00AB;\n\tv182 = DG.Tweening.Tweener::DOStartupDurationBased(t);\nL_00AB:\n\tv191 = DG.Tweening.Tween::DoGoto(t, 0f, 0, 2);\nL_00B6:\n\treturn v309;\n\tv164 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00BB:\n\tv337 = new System.NullReferenceException();\n\tgoto L_00C7;\nL_00C7:\n\tv213 = v387 != 1;\n\tif (v213) goto L_0103;\n\tv409 = 0x6D2BC0(v337, v387, v377, v248, v37, v38, v39, v40, v262, v254, v42, v43, v44, v45, v46, v47);\n\tv451 = *([v409 @ X0_v13]);\n\tv454 = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v451 @ X8_v7]), v377, v248, v37, v38, v39, v40, v262, v254, v42, v43, v44, v45, v46, v47);\n\tv460 = v454 & 1;\n\tv414 = v460 == 0;\n\tif (v414) goto L_00F9;\n\tv461 = 0x6D2490(v454, *([v451 @ X8_v7]), v377, v248, v37, v38, v39, v40, v262, v254, v42, v43, v44, v45, v46, v47);\n\tgoto L_00E5;\n\tv472 = *([v466 @ X0_v21+E0]);\n\tv473 = v472 == 0;\n\tv474 = ~v473;\n\tif (v474) goto L_00E5;\n\tv476 = \"il2cpp_codegen_runtime_class_init\"(v466, v452, v324, v248, v37, v38, v39, v40, v262, v254, v42, v43, v44, v45, v46, v47);\nL_00E5:\n\tDG.Tweening.Core.TweenManager::Despawn(t, 1);\n\tv489 = *([v268 @ X22_v4 (Il2CppClass<DG.Tweening.DOTween>)]);\n\tgoto L_00F4;\n\tv486 = *([v482 @ X0_v24+E0]);\n\tv487 = v486 == 0;\n\tv488 = ~v487;\n\tif (v488) goto L_00F4;\n\tv493 = \"il2cpp_codegen_runtime_class_init\"(v482, v479, v481, v248, v37, v38, v39, v40, v262, v254, v42, v43, v44, v45, v46, v47);\n\tv490 = *([v268 @ X22_v4 (Il2CppClass<DG.Tweening.DOTween>)]);\nL_00F4:\n\tv492 = *([v489 @ X0_v25+B8]) + 0x68;\n\tv264 = 0x1075B9C(v492, 1, 0, v248, v37, v38, v39, v40, v262, v254, v42, v43, v44, v45, v46, v47);\n\tgoto L_00B6;\nL_00F9:\n\tv463 = 0x6D1E60(8, *([v451 @ X8_v7]), v377, v248, v37, v38, v39, v40, v262, v254, v42, v43, v44, v45, v46, v47);\n\t*([v463 @ X0_v17]) = *([v409 @ X0_v13]);\n\tv387 = 0x1E8A000 + 0x870;\n\tv471 = 0x6D2A00(v463, v387, 0, v248, v37, v38, v39, v40, v262, v254, v42, v43, v44, v45, v46, v47);\n\tv413 = 0x6D2490(v471, v387, 0, v248, v37, v38, v39, v40, v262, v254, v42, v43, v44, v45, v46, v47);\nL_0103:\n\tv418 = 0x6D2380(v398, v387, 0, v248, v37, v38, v39, v40, v262, v254, v42, v43, v44, v45, v46, v47);\n\treturnVal2 = 0x846AA4(v418, v387, 0, v248, v37, v38, v39, v40, v262, v254, v42, v43, v44, v45, v46, v47);\n\treturn returnVal2;\n// 158 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static TweenerCore<T1, T2, TPlugOptions> DoChangeEndValue<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t, T2 newEndValue, float newDuration, bool snapStartValue) where TPlugOptions : struct, IPlugOptions
		{
			//IL_002a: Expected O, but got I
			//IL_015a: Expected O, but got I
			//IL_03a3: Expected O, but got I
			//IL_03b2: Expected O, but got I
			//IL_0170: Expected O, but got I
			//IL_0188: Expected O, but got I
			//IL_00e2: Expected O, but got I
			//IL_0134: Expected O, but got I
			//IL_02cd: Expected O, but got I
			//IL_042f: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newEndValue @ X1 (T2)+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-50]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-50]");
			_ = 0;
			t._003CisRelative_003Ek__BackingField = false;
			if (t.startupDone)
			{
				if (t.specialStartupMode != SpecialStartupMode.None && !DOStartupSpecials(t))
				{
					goto IL_02d2;
				}
				object obj4;
				if (!snapStartValue)
				{
					obj4 = (long)(IntPtr)t + 400L;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]");
					object obj5 = 0;
					obj4 = (long)(IntPtr)t + 400L;
					if (DOTween.useSafeMode)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]");
						T1 val = ((DOGetter<T1>)0)();
						if (obj5 == null)
						{
							NullReferenceException ex = new NullReferenceException();
							IntPtr intPtr = default(IntPtr);
							bool flag = intPtr != (IntPtr)1;
							NullReferenceException ex2 = ex;
							if (!flag)
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
								object obj7 = default(object);
								object obj6 = obj7;
								Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
								object obj8 = default(object);
								if ((uint)((ulong)(long)(IntPtr)obj8 & 1uL) != 0)
								{
									Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
									TweenManager.Despawn(t);
									IntPtr intPtr2 = default(IntPtr);
									object obj9 = (long)intPtr2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ X0_v25+B8]");
									object obj10 = 0L + 104L;
									Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1075B9C (inside DG.Tweening.Core.Easing.Flash::WeightedEase +0x170)");
									goto IL_02d2;
								}
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
								object obj11 = obj7;
								intPtr = (IntPtr)(32022528 + 2160);
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
								NullReferenceException ex3 = default(NullReferenceException);
								ex2 = ex3;
							}
							Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
							TweenerCore<T1, T2, TPlugOptions> result = default(TweenerCore<T1, T2, TPlugOptions>);
							return result;
						}
						object obj12 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ X8_v46+1A8]");
						IntPtr intPtr3 = (IntPtr)0;
						object obj13 = (long)(IntPtr)obj2 - 80L;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v424 @ X8_v46+1A0] (should have been resolved before IL gen)");
						object obj15 = default(object);
						object obj14 = obj15;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+180]");
						T1 val2 = ((DOGetter<T1>)0)();
						object obj16 = (long)(IntPtr)obj2 - 80L;
						object obj17 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ X8_v42+1A8]");
						IntPtr intPtr3 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v442 @ X8_v42+1A0] (should have been resolved before IL gen)");
						object obj18 = default(object);
						object obj14 = obj18;
					}
					object obj19 = default(object);
					obj3 = obj19;
				}
				object obj20 = obj4;
				object obj21 = obj20;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v122 @ X8_v32+1C0] (should have been resolved before IL gen)");
			}
			if (newDuration > 0f)
			{
				t.duration = newDuration;
				if (t.startupDone)
				{
					DOStartupDurationBased(t);
				}
			}
			bool flag2 = Tween.DoGoto(t, 0f, 0, UpdateMode.IgnoreOnUpdate);
			return t;
			IL_02d2:
			return null;
		}

		[Token(Token = "0x600017C")]
		[Address(RVA = "0x1367504", Offset = "0x1367504", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tt.isFrom = 0;\n\tt.<isRelative>k__BackingField = 0;\n\tt.hasManuallySetStartValue = 1;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]) = *([newStartValue @ X1 (T2)+10]);\n\tnewStartValue->klass = newStartValue->klass;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+14C]) = *([newEndValue @ X2 (T2)+10]);\n\tnewEndValue->klass = newEndValue->klass;\n\tv31 = ~t.startupDone;\n\tif (v31) goto L_003D;\n\tv58 = t.specialStartupMode == 0;\n\tif (v58) goto L_002A;\n\tv86 = DG.Tweening.Tweener::DOStartupSpecials(t);\n\tv88 = v86 == 0;\n\tif (v88) goto L_FFFFFFFF;\nL_002A:\n\tv35 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]);\n\tv68 = *([v35 @ X0_v12]);\n\t*([v68 @ X8_v14+1C0])(v64, v35, t, *([v68 @ X8_v14+1C8]), methodInfo, v47, v48, v49, v50, *([newEndValue @ X2 (T2)+10]), *([newEndValue @ X2 (T2)]), v51, v52, v53, v54, v55, v56);\nL_003D:\n\tv81 = newDuration <= 0;\n\tif (v81) goto L_004D;\n\tt.duration = newDuration;\n\tv92 = ~t.startupDone;\n\tif (v92) goto L_004D;\n\tv96 = DG.Tweening.Tweener::DOStartupDurationBased(t);\nL_004D:\n\tv105 = DG.Tweening.Tween::DoGoto(t, 0f, 0, 2);\nL_0055:\n\treturn v164;\n\tgoto L_0055;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static TweenerCore<T1, T2, TPlugOptions> DoChangeValues<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t, T2 newStartValue, T2 newEndValue, float newDuration) where TPlugOptions : struct, IPlugOptions
		{
			//IL_00c8: Expected O, but got I
			t.isFrom = false;
			t._003CisRelative_003Ek__BackingField = false;
			t.hasManuallySetStartValue = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newStartValue @ X1 (T2)+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newEndValue @ X2 (T2)+10]");
			_ = 0;
			if (t.startupDone)
			{
				if (t.specialStartupMode != SpecialStartupMode.None && !DOStartupSpecials(t))
				{
					return null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]");
				object obj = 0;
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v68 @ X8_v14+1C0] (should have been resolved before IL gen)");
			}
			if (newDuration > 0f)
			{
				t.duration = newDuration;
				if (t.startupDone)
				{
					DOStartupDurationBased(t);
				}
			}
			bool flag = Tween.DoGoto(t, 0f, 0, UpdateMode.IgnoreOnUpdate);
			return t;
		}

		[Token(Token = "0x600017D")]
		[Address(RVA = "0x11B2600", Offset = "0x11B2600", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB6CC0]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2027ADC]) = v38;\nL_0013:\n\tv39 = v36 == 0;\n\tif (v39) goto L_004D;\n\tv41 = v36.specialStartupMode - 1;\n\tv42 = v41 < 3;\n\tv43 = ~v42;\n\tv44 = v41 - 3;\n\tv46 = v44 == 0;\n\tv51 = ~v46;\n\tv52 = v43 & v51;\n\tif (v52) goto L_FFFFFFFF;\n\tv56 = 0x182A000 + 0x548;\n\tv58 = *([v56 @ X9_v6 (System.Int32)+v41 @ X8_v9 (System.Int32)*4]) + v56;\n\t// 39 IndirectJump v58 @ X8_v12, v36 @ X0_v1 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), v36 @ X0_v1 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), v66 @ X1_v2 (Il2CppMethodInfo), v63 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX8 = *([1EE7640]);\n\tX1 = *([X8]);\n\tX0 = X19;\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX0 = DG.Tweening.Plugins.Core.SpecialPluginsUtils::SetLookAt(X0, X1);\n\tgoto L_0047;\n\tX8 = *([1EE2D38]);\n\tX1 = *([X8]);\n\tX0 = X19;\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX0 = DG.Tweening.Plugins.Core.SpecialPluginsUtils::SetPunch(X0, X1);\n\tgoto L_0047;\n\tX8 = *([1EE2D38]);\n\tX1 = *([X8]);\n\tX0 = X19;\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX0 = DG.Tweening.Plugins.Core.SpecialPluginsUtils::SetCameraShakePosition(X0, X1);\n\tgoto L_0047;\n\tX8 = *([1EE2D38]);\n\tX1 = *([X8]);\n\tX0 = X19;\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX0 = DG.Tweening.Plugins.Core.SpecialPluginsUtils::SetShake(X0, X1);\nL_0047:\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_006B;\n\tgoto L_0072;\nL_004D:\n\tv54 = new System.NullReferenceException();\n\tgoto L_005C;\n\tgoto L_005C;\n\tgoto L_005C;\n\tgoto L_005C;\nL_005C:\n\tv72 = v66 != 1;\n\tif (v72) goto L_007E;\n\tv125 = 0x6D2BC0(v54, v66, v63, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv135 = *([v125 @ X0_v11]);\n\tv137 = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v135 @ X8_v5]), v63, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv138 = v137 & 1;\n\tv118 = v138 == 0;\n\tif (v118) goto L_0074;\n\tv117 = 0x6D2490(v137, *([v135 @ X8_v5]), v63, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_006B:\n\t;\nL_0072:\n\treturn v107;\nL_0074:\n\tv140 = 0x6D1E60(8, *([v135 @ X8_v5]), v63, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\t*([v140 @ X0_v15]) = *([v125 @ X0_v11]);\n\tv66 = 0x1E8A000 + 0x870;\n\tv142 = 0x6D2A00(v140, v66, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv129 = 0x6D2490(v142, v66, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_007E:\n\tv133 = 0x6D2380(v105, v66, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturnVal2 = 0x846AA4(v133, v66, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn returnVal2;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool DOStartupSpecials<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t) where TPlugOptions : struct, IPlugOptions
		{
			//IL_0099: Expected O, but got I
			TweenerCore<T1, T2, TPlugOptions> tweenerCore = default(TweenerCore<T1, T2, TPlugOptions>);
			if (tweenerCore != null)
			{
				int num = (int)(tweenerCore.specialStartupMode - 1);
				bool flag = num < 3;
				bool flag2 = !flag;
				int num2 = num - 3;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 25337856 + 1352;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X9_v6 (System.Int32)+v41 @ X8_v9 (System.Int32)*4]");
					object obj = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X8_v12 (should have been resolved before IL gen)");
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr = default(IntPtr);
			bool flag5 = intPtr != (IntPtr)1;
			NullReferenceException ex2 = ex;
			if (!flag5)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj3 = default(object);
				object obj2 = obj3;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj4 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj4 & 1uL) != 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					return false;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
				object obj5 = obj3;
				intPtr = (IntPtr)(32022528 + 2160);
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				NullReferenceException ex3 = default(NullReferenceException);
				ex2 = ex3;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			bool result = default(bool);
			return result;
		}

		[Token(Token = "0x600017E")]
		[Address(RVA = "0xBB1594", Offset = "0xBB1594", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = ~t.isSpeedBased;\n\tif (v12) goto L_0021;\n\tv49 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+16C]);\n\tv26 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]);\n\tv49 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]);\n\tv74 = *([v26 @ X0_v4]);\n\t*([v74 @ X8_v9+1D0])(v70, v26, *([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+17C]), &v49 @ V1_v5, *([v74 @ X8_v9+1D8]), v38, v39, v40, v41, t.duration, *([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), *([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]), v43, v44, v45, v46, v47);\n\tt.duration = t.duration;\nL_0021:\n\tv77 = t.loops & 0x80000000;\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_FFFFFFFF;\n\tv96 = t.duration * t.loops;\n\tgoto L_002B;\nL_002B:\n\tt.fullDuration = v96;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DOStartupDurationBased<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t) where TPlugOptions : struct, IPlugOptions
		{
			//IL_00bf: Expected I4, but got I8
			//IL_002e: Expected O, but got I
			//IL_003e: Expected O, but got I
			//IL_004e: Expected O, but got I
			if (t.isSpeedBased)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+16C]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+190]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+15C]");
				obj = 0;
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v74 @ X8_v9+1D0] (should have been resolved before IL gen)");
				t.duration = t.duration;
			}
			float num = (((int)(t.loops & 0x80000000L) != 0) ? float.PositiveInfinity : (t.duration * (float)t.loops));
			t.fullDuration = num;
		}
	}
}
