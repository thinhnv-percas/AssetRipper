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
	[Token(Token = "0x2000070")]
	public abstract class Tweener : Tween
	{
		[Token(Token = "0x400014E")]
		[FieldOffset(Offset = "0x120")]
		internal bool hasManuallySetStartValue;

		[Token(Token = "0x400014F")]
		[FieldOffset(Offset = "0x121")]
		internal bool isFromAllowed;

		[Token(Token = "0x60002A9")]
		[Address(RVA = "0xC1CC74", Offset = "0xC1CC74", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isFromAllowed = 1;\n\tthis.intId = 0xFFFFFC19;\n\tthis.activeId = 0xFFFFFFFF;\n\tthis.delayComplete = 1;\n\tthis.miscInt = 0xFFFFFFFF;\n\tDG.Tweening.Core.ABSSequentiable::.ctor(this);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Tweener()
		{
			isFromAllowed = true;
			intId = -999;
			activeId = -1;
			delayComplete = true;
			miscInt = -1;
		}

		[Token(Token = "0x60002AA")]
		public abstract Tweener ChangeStartValue(object newStartValue, float newDuration = -1f);

		[Token(Token = "0x60002AB")]
		public abstract Tweener ChangeEndValue(object newEndValue, float newDuration = -1f, bool snapStartValue = false);

		[Token(Token = "0x60002AC")]
		public abstract Tweener ChangeEndValue(object newEndValue, bool snapStartValue);

		[Token(Token = "0x60002AD")]
		public abstract Tweener ChangeValues(object newStartValue, object newEndValue, float newDuration = -1f);

		[Token(Token = "0x60002AE")]
		internal abstract Tweener SetFrom(bool relative);

		[Token(Token = "0x60002AF")]
		[Address(RVA = "0xCC3EDC", Offset = "0xCC3EDC", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv43 = *([plugin @ X4 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+38]) == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_0028;\n\tv66 = *([plugin @ X4 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+38]) == 0;\n\tv58 = ~v66;\n\tif (v58) goto L_0028;\n\tv55 = 0xB3490C(plugin, getter, setter, endValue, plugin, methodInfo, v49, v50, duration, v34, v32, v30, v28, v51, v52, v53);\nL_0028:\n\tv64 = endValue == 0;\n\tif (v64) goto L_002D;\n\tt._color32Type = endValue;\n\tgoto L_0036;\nL_002D:\n\tv68 = t._color32Type == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0036;\n\tv76 = *([plugin @ X4 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+38]);\n\tv72 = DG.Tweening.Plugins.Core.PluginsManager::GetDefaultPlugin /* +1 sharing this address */(*([v76 @ X8_v16+10]));\n\tt._color32Type = v72;\n\tv74 = v72 == 0;\n\tif (v74) goto L_0085;\nL_0036:\n\tt.tweenPlugin = getter;\n\tt._colorType = setter;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+134]) = duration;\n\tt.changeValue = v34;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+13C]) = v32;\n\tt.plugOptions = v30;\n\tt.duration = v28;\n\tgoto L_0048;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v79, getter, setter, endValue, plugin, methodInfo, v49, v50, duration, v34, v32, v30, v28, v51, v52, v53);\n\tv150 = DG.Tweening.DOTween;\nL_0048:\n\tt.autoKill = v151.defaultAutoKill;\n\tt.isRecyclable = v151.defaultRecyclable;\n\tt.easeType = v151.defaultEaseType;\n\tt.easeOvershootOrAmplitude = v151.defaultEaseOvershootOrAmplitude;\n\tt.loopType = v151.defaultLoopType;\n\tv167 = v151.defaultAutoPlay != 3;\n\tif (v167) goto L_0062;\n\tgoto L_0072;\nL_0062:\n\tgoto L_0069;\n\tv200 = \"il2cpp_codegen_runtime_class_init\"(v149, getter, setter, endValue, plugin, methodInfo, v49, v50, v155, v34, v32, v30, v28, v51, v52, v53);\n\tv206 = DG.Tweening.DOTween;\n\tv207 = *([v206 @ X8_v11+B8]);\n\tv202 = *([v207 @ X8_v12+44]);\nL_0069:\n\tv190 = v151.defaultAutoPlay - 2;\n\tv186 = v190 == 0;\nL_0072:\n\tt.isPlaying = v197;\nL_007F:\n\treturn returnVal2;\nL_0085:\n\tDG.Tweening.Core.Debugger::LogError(\"No suitable plugin found for this type\", 0);\n\tgoto L_007F;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Setup<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t, DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration, ABSTweenPlugin<T1, T2, TPlugOptions> plugin = null) where TPlugOptions : struct, IPlugOptions
		{
			//IL_00e0: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [plugin @ X4 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [plugin @ X4 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+38]");
				if ((nint)0 == 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B3490C");
				}
			}
			if (endValue != null)
			{
				t._color32Type = (Type)endValue;
			}
			else if ((object)t._color32Type == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [plugin @ X4 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+38]");
				object obj = 0;
				Il2CppRuntime.Boundary("MANAGED", "Method not found @C8AC4C (DG.Tweening.Plugins.Core.PluginsManager::GetDefaultPlugin, and 1 more at this address)");
				Type type = default(Type);
				t._color32Type = type;
				if ((object)type == null)
				{
					Debugger.LogError("No suitable plugin found for this type");
					return false;
				}
			}
			t.tweenPlugin = (ABSTweenPlugin<T1, T2, TPlugOptions>)(object)getter;
			t._colorType = (Type)(object)setter;
			T2 changeValue = default(T2);
			t.changeValue = changeValue;
			TPlugOptions plugOptions = default(TPlugOptions);
			t.plugOptions = plugOptions;
			float num = default(float);
			t.duration = num;
			t.autoKill = DOTween.defaultAutoKill;
			t.isRecyclable = DOTween.defaultRecyclable;
			t.easeType = DOTween.defaultEaseType;
			t.easeOvershootOrAmplitude = DOTween.defaultEaseOvershootOrAmplitude;
			t.loopType = DOTween.defaultLoopType;
			bool flag;
			if (DOTween.defaultAutoPlay == AutoPlay.All)
			{
				flag = true;
			}
			else
			{
				int num2 = (int)(DOTween.defaultAutoPlay - 2);
				bool flag2 = num2 == 0;
				flag = flag2;
			}
			t.isPlaying = flag;
			return true;
		}

		[Token(Token = "0x60002B0")]
		[Address(RVA = "0xCC3A2C", Offset = "0xCC3A2C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = t.delay >= elapsed;\n\tif (v15) goto L_0015;\n\tt.elapsedDelay = t.delay;\n\tt.delayComplete = 1;\n\treturnVal2 = elapsed - t.delay;\n\tgoto L_0019;\nL_0015:\n\tt.elapsedDelay = elapsed;\nL_0019:\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn elapsed;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static float DoUpdateDelay<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t, float elapsed) where TPlugOptions : struct, IPlugOptions
		{
			if (t.delay < elapsed)
			{
				t.elapsedDelay = t.delay;
				t.delayComplete = true;
				return elapsed - t.delay;
			}
			t.elapsedDelay = elapsed;
			return 0f;
		}

		[Token(Token = "0x60002B1")]
		[Address(RVA = "0xCBFB24", Offset = "0xCBFB24", Length = "0x314")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tgoto L_0018;\n\tv33 = 0xB3490C(v289, v289, v278, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0018:\n\tt.startupDone = 1;\n\tv42 = t.specialStartupMode == 0;\n\tif (v42) goto L_0023;\n\tv124 = DG.Tweening.Tweener::DOStartupSpecials(t);\n\tv127 = v124 == 0;\n\tif (v127) goto L_FFFFFFFF;\nL_0023:\n\tv130 = ~t.hasManuallySetStartValue;\n\tv131 = ~v130;\n\tif (v131) goto L_008C;\n\tgoto L_0032;\n\tv219 = \"il2cpp_codegen_runtime_class_init\"(v156, v88, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv220 = DG.Tweening.DOTween;\nL_0032:\n\tv223 = ~v221.useSafeMode;\n\tif (v223) goto L_0046;\n\tv271 = ~t.isFrom;\n\tif (v271) goto L_0057;\n\tv325 = ~t.<isRelative>k__BackingField;\n\tif (v325) goto L_FFFFFFFF;\n\tv334 = t.isBlendable - 1;\n\tv336 = v334 == 0;\n\tv341 = ~v336;\n\tgoto L_006D;\nL_0046:\n\tv272 = ~t.isFrom;\n\tif (v272) goto L_006F;\n\tv328 = ~t.<isRelative>k__BackingField;\n\tif (v328) goto L_FFFFFFFF;\n\tv356 = t.isBlendable == 0;\n\tgoto L_0089;\nL_0057:\n\tv299 = t.tweenPlugin;\n\t*([v299 @ X8_v31 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+18])(v348, *([v299 @ X8_v31 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+40]), *([v299 @ X8_v31 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+28]), v278, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv349 = t._color32Type == 0;\n\tif (v349) goto L_00B4;\n\tv386 = System.Reflection.MemberInfo::get_Name(t._color32Type);\n\tgoto L_007F;\nL_006D:\n\tv380 = DG.Tweening.Core.TweenerCore`3::SetFrom(t, v374);\n\tgoto L_008A;\nL_006F:\n\tv115 = t.tweenPlugin;\n\t*([v115 @ X8_v25 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+18])(v102, *([v115 @ X8_v25 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+40]), *([v115 @ X8_v25 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+28]), v278, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv408 = System.Reflection.MemberInfo::get_Name(t._color32Type);\nL_007F:\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+124]) = v24;\n\tt.startValue = v25;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]) = v26;\n\tt.endValue = v27;\n\tgoto L_008C;\nL_0089:\n\tv402 = DG.Tweening.Core.TweenerCore`3::SetFrom(t, v396);\nL_008A:\n\tt.<isRelative>k__BackingField = 0;\nL_008C:\n\tv185 = ~t.<isRelative>k__BackingField;\n\tif (v185) goto L_009D;\n\tv228 = System.Type::get_DeclaringType(t._color32Type);\nL_009D:\n\tv275 = System.Type::get_ReflectedType(t._color32Type);\n\tDG.Tweening.Tweener::DOStartupDurationBased(t);\n\tv329 = t.duration < 0;\n\tv255 = ~v329;\n\tv249 = t.duration == 0;\n\tv330 = ~v249;\n\tv239 = v255 & v330;\n\tif (v239) goto L_FFFFFFFF;\n\tt.easeType = 0x24;\n\tgoto L_0104;\n\tv350 = new System.NullReferenceException();\nL_00B4:\n\tv293 = new System.NullReferenceException();\n\tgoto L_00C3;\n\tgoto L_00C3;\n\tgoto L_00C3;\n\tgoto L_00C3;\nL_00C3:\n\tv49 = v289 != 1;\n\tif (v49) goto L_0111;\n\tv411 = 0x1854E70(v293, v289, v278, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv118 = *([v411 @ X0_v38]);\n\tv146 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v118 @ X8_v32]), v278, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv415 = v146 & 1;\n\tv148 = v415 == 0;\n\tif (v148) goto L_0107;\n\tv416 = 0x1854E80(v146, *([v118 @ X8_v32]), v278, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv105 = DG.Tweening.Core.Debugger::ShouldLogSafeModeCapturedError();\n\tv419 = v105 == 0;\n\tif (v419) goto L_00F4;\n\tv438 = System.Exception::get_TargetSite(*([v411 @ X0_v38]));\n\tv443 = System.Exception::get_Message(*([v411 @ X0_v38]));\n\tv428 = System.String::Format(\"Tween startup failed (NULL target/property - {0}): the tween will now be killed ► {1}\", v438, v443);\n\tDG.Tweening.Core.Debugger::LogSafeModeCapturedError(v428, t);\nL_00F4:\n\tgoto L_00FC;\n\tv447 = \"il2cpp_codegen_runtime_class_init\"(v435, v424, v421, v192, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_00FC:\n\tv211 = v451.Version + 0x74;\n\tDG.Tweening.Core.SafeModeReport::Add(v211, 3);\nL_0104:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0107:\n\tv153 = 0x1854E90(8, v143, v132, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\t*([v153 @ X0_v8]) = *([v149 @ X20_v3]);\n\tv289 = 0x185A000 + 0xF88;\n\tv190 = 0x1854EA0(v153, v289, 0, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv232 = 0x1854E80(v190, v289, 0, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0111:\n\tv301 = 0xBD3CD0(v296, v289, 0, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\treturnVal2 = 0x9DACB4(v301, v289, 0, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\treturn returnVal2;\n// 178 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static bool DoStartup<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t) where TPlugOptions : struct, IPlugOptions
		{
			//IL_00fb: Expected O, but got I4
			//IL_03ed: Expected O, but got I
			t.startupDone = true;
			nint num = default(nint);
			if (t.specialStartupMode != SpecialStartupMode.None)
			{
				bool flag = DOStartupSpecials(t);
				bool flag2 = !flag;
				num = 0;
				if (flag2)
				{
					goto IL_0400;
				}
			}
			if (!t.hasManuallySetStartValue)
			{
				if (DOTween.useSafeMode)
				{
					if (!t.isFrom)
					{
						ABSTweenPlugin<T1, T2, TPlugOptions> tweenPlugin = t.tweenPlugin;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v299 @ X8_v31 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+18] (should have been resolved before IL gen)");
						if ((object)t._color32Type != null)
						{
							string name = t._color32Type.Name;
							goto IL_04f0;
						}
						NullReferenceException ex = new NullReferenceException();
						bool flag3 = num != 1;
						NullReferenceException ex2 = ex;
						if (!flag3)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
							object obj2 = default(object);
							object obj = obj2;
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
							object obj3 = default(object);
							if ((int)((nint)obj3 & 1) != 0)
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
								if (Debugger.ShouldLogSafeModeCapturedError())
								{
									MethodBase targetSite = ((Exception)obj2).TargetSite;
									string message = ((Exception)obj2).Message;
									string message2 = $"Tween startup failed (NULL target/property - {targetSite}): the tween will now be killed ► {message}";
									Debugger.LogSafeModeCapturedError(message2, t);
								}
								SafeModeReport safeModeReport = (SafeModeReport)((nint)DOTween.Version + 116);
								((SafeModeReport*)safeModeReport)->Add(SafeModeReport.SafeModeReportType.StartupFailure);
								goto IL_0400;
							}
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @1854E90 (native __cxa_allocate_exception)");
							object obj5 = default(object);
							object obj4 = obj5;
							num = 25538440;
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @1854EA0 (native __cxa_throw)");
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
							NullReferenceException ex3 = default(NullReferenceException);
							ex2 = ex3;
						}
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
						bool result = default(bool);
						return result;
					}
					bool flag6;
					if (t._003CisRelative_003Ek__BackingField)
					{
						object obj6 = (t.isBlendable ? 1 : 0) - 1;
						bool flag4 = obj6 == null;
						bool flag5 = !flag4;
						flag6 = flag5;
					}
					else
					{
						flag6 = false;
					}
					Tweener tweener = ((TweenerCore<, , >)(object)t).SetFrom(flag6);
				}
				else
				{
					if (!t.isFrom)
					{
						ABSTweenPlugin<T1, T2, TPlugOptions> tweenPlugin2 = t.tweenPlugin;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v115 @ X8_v25 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+18] (should have been resolved before IL gen)");
						string name2 = t._color32Type.Name;
						goto IL_04f0;
					}
					bool flag8;
					if (t._003CisRelative_003Ek__BackingField)
					{
						bool flag7 = !t.isBlendable;
						flag8 = flag7;
					}
					else
					{
						flag8 = false;
					}
					Tweener tweener2 = ((TweenerCore<, , >)(object)t).SetFrom(flag8);
				}
				t._003CisRelative_003Ek__BackingField = false;
			}
			goto IL_048c;
			IL_04f0:
			T2 startValue = default(T2);
			t.startValue = startValue;
			T2 endValue = default(T2);
			t.endValue = endValue;
			goto IL_048c;
			IL_0400:
			return false;
			IL_048c:
			if (t._003CisRelative_003Ek__BackingField)
			{
				Type declaringType = t._color32Type.DeclaringType;
			}
			Type reflectedType = t._color32Type.ReflectedType;
			DOStartupDurationBased(t);
			bool flag9 = t.duration < 0f;
			bool flag10 = !flag9;
			bool flag11 = t.duration == 0f;
			bool flag12 = !flag11;
			if (!(flag10 && flag12))
			{
				t.easeType = Ease.INTERNAL_Zero;
			}
			return true;
		}

		[Token(Token = "0x60002B2")]
		[Address(RVA = "0xCBD3E0", Offset = "0xCBD3E0", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = *([newStartValue @ X1 (T2)+38]) == 0;\n\tv32 = ~v31;\n\tif (v32) goto L_001A;\n\tv34 = 0xB3490C(newStartValue, newStartValue, methodInfo, v36, v37, v38, v39, v40, newDuration, v26, v24, v22, v20, v41, v42, v43);\nL_001A:\n\tt.hasManuallySetStartValue = 1;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+124]) = newDuration;\n\tt.startValue = v26;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]) = v24;\n\tt.endValue = v22;\n\tv48 = ~t.startupDone;\n\tif (v48) goto L_003E;\n\tv61 = t.specialStartupMode == 0;\n\tif (v61) goto L_0032;\n\tv85 = *([newStartValue @ X1 (T2)+38]);\n\tv88 = DG.Tweening.Tweener::DOStartupSpecials /* +1 sharing this address */(t, *([v85 @ X8_v12+10]));\n\tv166 = v88 & 1;\n\tv91 = v166 == 0;\n\tif (v91) goto L_FFFFFFFF;\nL_0032:\n\tv69 = System.Type::get_ReflectedType(t._color32Type);\nL_003E:\n\tv84 = v20 <= 0;\n\tif (v84) goto L_004D;\n\tt.duration = v20;\n\tv93 = ~t.startupDone;\n\tif (v93) goto L_004D;\n\tv100 = *([newStartValue @ X1 (T2)+38]);\n\tDG.Tweening.Tweener::DOStartupDurationBased /* +1 sharing this address */(t, *([v100 @ X8_v7+28]));\nL_004D:\n\tv106 = DG.Tweening.Tween::DoGoto(t, 0f, 0, 2);\nL_0058:\n\treturn v168;\n\tgoto L_0058;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static TweenerCore<T1, T2, TPlugOptions> DoChangeStartValue<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t, T2 newStartValue, float newDuration) where TPlugOptions : struct, IPlugOptions
		{
			//IL_00c6: Expected O, but got I
			//IL_0153: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newStartValue @ X1 (T2)+38]");
			if ((nint)0 == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B3490C");
			}
			t.hasManuallySetStartValue = true;
			T2 startValue = default(T2);
			t.startValue = startValue;
			T2 endValue = default(T2);
			t.endValue = endValue;
			if (t.startupDone)
			{
				if (t.specialStartupMode != SpecialStartupMode.None)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newStartValue @ X1 (T2)+38]");
					object obj = 0;
					Il2CppRuntime.Boundary("MANAGED", "Method not found @CBAD9C (DG.Tweening.Tweener::DOStartupSpecials, and 1 more at this address)");
					object obj2 = default(object);
					if ((int)((nint)obj2 & 1) == 0)
					{
						return null;
					}
				}
				Type reflectedType = t._color32Type.ReflectedType;
			}
			float num = default(float);
			if (num > 0f)
			{
				t.duration = num;
				if (t.startupDone)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newStartValue @ X1 (T2)+38]");
					object obj3 = 0;
					Il2CppRuntime.Boundary("MANAGED", "Method not found @CBA2F4 (DG.Tweening.Tweener::DOStartupDurationBased, and 1 more at this address)");
				}
			}
			bool flag = Tween.DoGoto(t, 0f, 0, UpdateMode.IgnoreOnUpdate);
			return t;
		}

		[Token(Token = "0x60002B3")]
		[Address(RVA = "0xCB981C", Offset = "0xCB981C", Length = "0x300")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv36 = *([v301 @ X2_v1 (System.Boolean)+38]) == 0;\n\tv37 = ~v36;\n\tif (v37) goto L_0023;\n\tv58 = *([v301 @ X2_v1 (System.Boolean)+38]) == 0;\n\tv54 = ~v58;\n\tif (v54) goto L_0023;\n\tv52 = 0xB3490C(v301, v305, v301, methodInfo, v43, v44, v45, v46, newDuration, v31, v29, v27, v25, v47, v48, v49);\nL_0023:\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+134]) = newDuration;\n\tt.changeValue = v31;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+13C]) = v29;\n\tt.plugOptions = v27;\n\tt.<isRelative>k__BackingField = 0;\n\tv60 = ~t.startupDone;\n\tif (v60) goto L_0078;\n\tv121 = t.specialStartupMode == 0;\n\tif (v121) goto L_0032;\n\tv168 = DG.Tweening.Tweener::DOStartupSpecials /* +1 sharing this address */(t, v305);\n\tv191 = v168 & 1;\n\tv171 = v191 == 0;\n\tif (v171) goto L_FFFFFFFF;\nL_0032:\n\tv172 = v305 & 1;\n\tv173 = v172 == 0;\n\tif (v173) goto L_006C;\n\tgoto L_0041;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v194, newEndValue, snapStartValue, methodInfo, v43, v44, v45, v46, newDuration, v31, v29, v27, v25, v47, v48, v49);\n\tv274 = DG.Tweening.DOTween;\nL_0041:\n\tv115 = t.tweenPlugin;\n\tv276 = ~v275.useSafeMode;\n\tif (v276) goto L_0058;\n\t*([v115 @ X8_v18 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+18])(v332, *([v115 @ X8_v18 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+40]), *([v115 @ X8_v18 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+28]), v301, methodInfo, v43, v44, v45, v46, newDuration, v31, v29, v27, v25, v47, v48, v49);\n\tv333 = t._color32Type == 0;\n\tif (v333) goto L_0094;\n\tv341 = System.Reflection.MemberInfo::get_Name(t._color32Type);\n\tgoto L_0061;\nL_0058:\n\t*([v115 @ X8_v18 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+18])(v102, *([v115 @ X8_v18 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+40]), *([v115 @ X8_v18 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+28]), v301, methodInfo, v43, v44, v45, v46, newDuration, v31, v29, v27, v25, v47, v48, v49);\n\tv348 = System.Reflection.MemberInfo::get_Name(t._color32Type);\nL_0061:\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+124]) = newDuration;\n\tt.startValue = v31;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]) = v29;\n\tt.endValue = v27;\nL_006C:\n\tv129 = System.Type::get_ReflectedType(t._color32Type);\nL_0078:\n\tv145 = v25 <= 0;\n\tif (v145) goto L_0085;\n\tt.duration = v25;\n\tv175 = ~t.startupDone;\n\tif (v175) goto L_0085;\n\tDG.Tweening.Tweener::DOStartupDurationBased /* +1 sharing this address */(t, v305);\nL_0085:\n\tv185 = DG.Tweening.Tween::DoGoto(t, 0f, 0, 2);\nL_0092:\n\treturn v243;\n\tv334 = new System.NullReferenceException();\nL_0094:\n\tv323 = new System.NullReferenceException();\n\tgoto L_00A2;\n\tgoto L_00A2;\n\tgoto L_00A2;\nL_00A2:\n\tv63 = v305 != 1;\n\tif (v63) goto L_00FE;\n\tv351 = 0x1854E70(v323, v305, v301, methodInfo, v43, v44, v45, v46, newDuration, v31, v29, v27, v25, v47, v48, v49);\n\tv116 = *([v351 @ X0_v35]);\n\tv159 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v116 @ X8_v21]), v301, methodInfo, v43, v44, v45, v46, newDuration, v31, v29, v27, v25, v47, v48, v49);\n\tv355 = v159 & 1;\n\tv161 = v355 == 0;\n\tif (v161) goto L_00F4;\n\tv356 = 0x1854E80(v159, *([v116 @ X8_v21]), v301, methodInfo, v43, v44, v45, v46, newDuration, v31, v29, v27, v25, v47, v48, v49);\n\tv103 = DG.Tweening.Core.Debugger::ShouldLogSafeModeCapturedError();\n\tv359 = v103 == 0;\n\tif (v359) goto L_00DA;\n\tv380 = System.Exception::get_TargetSite(*([v351 @ X0_v35]));\n\tv388 = System.Exception::get_Message(*([v351 @ X0_v35]));\n\tv391 = System.Exception::get_StackTrace(*([v351 @ X0_v35]));\n\tv370 = System.String::Format(\"Target or field is missing/null ({0}) ► {1}\\n\\n{2}\\n\\n\", v380, v388, v391);\n\tDG.Tweening.Core.Debugger::LogSafeModeCapturedError(v370, t);\nL_00DA:\n\tgoto L_00DF;\n\tv395 = \"il2cpp_codegen_runtime_class_init\"(v377, v366, v363, v264, v262, v44, v45, v46, newDuration, v31, v29, v27, v25, v47, v48, v49);\nL_00DF:\n\tDG.Tweening.Core.TweenManager::Despawn(t, 1);\n\tgoto L_00EE;\n\tv407 = \"il2cpp_codegen_runtime_class_init\"(v404, v397, v399, v264, v262, v44, v45, v46, newDuration, v31, v29, v27, v25, v47, v48, v49);\nL_00EE:\n\tv269 = v411.Version + 0x74;\n\tDG.Tweening.Core.SafeModeReport::Add(v269, 1);\n\tgoto L_0092;\n\tthrow System.NullReferenceException;\nL_00F4:\n\tv166 = 0x1854E90(8, v157, v155, methodInfo, v43, v44, v45, v46, newDuration, v31, v29, v27, v25, v47, v48, v49);\n\t*([v166 @ X0_v8]) = *([v162 @ X20_v3]);\n\tv305 = 0x185A000 + 0xF88;\n\tv190 = 0x1854EA0(v166, v305, 0, methodInfo, v43, v44, v45, v46, newDuration, v31, v29, v27, v25, v47, v48, v49);\n\tv261 = 0x1854E80(v190, v305, 0, methodInfo, v43, v44, v45, v46, newDuration, v31, v29, v27, v25, v47, v48, v49);\nL_00FE:\n\tv327 = 0xBD3CD0(v318, v305, 0, methodInfo, v43, v44, v45, v46, newDuration, v31, v29, v27, v25, v47, v48, v49);\n\treturnVal2 = 0x9DACB4(v327, v305, 0, methodInfo, v43, v44, v45, v46, newDuration, v31, v29, v27, v25, v47, v48, v49);\n\treturn returnVal2;\n// 169 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static TweenerCore<T1, T2, TPlugOptions> DoChangeEndValue<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t, T2 newEndValue, float newDuration, bool snapStartValue) where TPlugOptions : struct, IPlugOptions
		{
			//IL_03d6: Expected O, but got I4
			//IL_0393: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ X2_v1 (System.Boolean)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ X2_v1 (System.Boolean)+38]");
				if ((nint)0 == 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B3490C");
				}
			}
			T2 val = default(T2);
			t.changeValue = val;
			T2 val2 = default(T2);
			t.plugOptions = (TPlugOptions)val2;
			t._003CisRelative_003Ek__BackingField = false;
			if (t.startupDone)
			{
				if (t.specialStartupMode != SpecialStartupMode.None)
				{
					Il2CppRuntime.Boundary("MANAGED", "Method not found @CBAD9C (DG.Tweening.Tweener::DOStartupSpecials, and 1 more at this address)");
					object obj = default(object);
					if ((int)((nint)obj & 1) == 0)
					{
						goto IL_03a6;
					}
				}
				T2 val3 = default(T2);
				if ((int)((nint)val3 & 1) != 0)
				{
					ABSTweenPlugin<T1, T2, TPlugOptions> tweenPlugin = t.tweenPlugin;
					if (DOTween.useSafeMode)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v115 @ X8_v18 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+18] (should have been resolved before IL gen)");
						if ((object)t._color32Type == null)
						{
							NullReferenceException ex = new NullReferenceException();
							bool flag = (nint)val3 != 1;
							NullReferenceException ex2 = ex;
							if (!flag)
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
								object obj3 = default(object);
								object obj2 = obj3;
								Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
								object obj4 = default(object);
								if ((int)((nint)obj4 & 1) != 0)
								{
									Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
									if (Debugger.ShouldLogSafeModeCapturedError())
									{
										MethodBase targetSite = ((Exception)obj3).TargetSite;
										string message = ((Exception)obj3).Message;
										string stackTrace = ((Exception)obj3).StackTrace;
										string message2 = $"Target or field is missing/null ({targetSite}) ► {message}\n\n{stackTrace}\n\n";
										Debugger.LogSafeModeCapturedError(message2, t);
									}
									TweenManager.Despawn(t);
									SafeModeReport safeModeReport = (SafeModeReport)((nint)DOTween.Version + 116);
									((SafeModeReport*)safeModeReport)->Add(SafeModeReport.SafeModeReportType.TargetOrFieldMissing);
									goto IL_03a6;
								}
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @1854E90 (native __cxa_allocate_exception)");
								object obj6 = default(object);
								object obj5 = obj6;
								val3 = (T2)(25534464 + 3976);
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @1854EA0 (native __cxa_throw)");
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
								NullReferenceException ex3 = default(NullReferenceException);
								ex2 = ex3;
							}
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
							TweenerCore<T1, T2, TPlugOptions> result = default(TweenerCore<T1, T2, TPlugOptions>);
							return result;
						}
						string name = t._color32Type.Name;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v115 @ X8_v18 (DG.Tweening.Plugins.Core.ABSTweenPlugin`3<T1, T2, TPlugOptions>)+18] (should have been resolved before IL gen)");
						string name2 = t._color32Type.Name;
					}
					t.startValue = val;
					t.endValue = val2;
				}
				Type reflectedType = t._color32Type.ReflectedType;
				val3 = (T2)t;
			}
			float num = default(float);
			if (num > 0f)
			{
				t.duration = num;
				if (t.startupDone)
				{
					Il2CppRuntime.Boundary("MANAGED", "Method not found @CBA2F4 (DG.Tweening.Tweener::DOStartupDurationBased, and 1 more at this address)");
				}
			}
			bool flag2 = Tween.DoGoto(t, 0f, 0, UpdateMode.IgnoreOnUpdate);
			return t;
			IL_03a6:
			return null;
		}

		[Token(Token = "0x60002B4")]
		[Address(RVA = "0xCBE628", Offset = "0xCBE628", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv43 = *([newStartValue @ X1 (T2)+38]) == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_0020;\n\tv46 = 0xB3490C(newStartValue, newStartValue, newEndValue, methodInfo, v49, v50, v51, v52, newDuration, v38, v36, v34, v32, v30, v28, v26);\nL_0020:\n\tt.isFrom = 0;\n\tt.<isRelative>k__BackingField = 0;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+124]) = newDuration;\n\tt.startValue = v38;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+12C]) = v36;\n\tt.endValue = v34;\n\tt.hasManuallySetStartValue = 1;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+134]) = v32;\n\tt.changeValue = v30;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>)+13C]) = v28;\n\tt.plugOptions = v26;\n\tv57 = ~t.startupDone;\n\tif (v57) goto L_004B;\n\tv70 = t.specialStartupMode == 0;\n\tif (v70) goto L_003E;\n\tv96 = *([newStartValue @ X1 (T2)+38]);\n\tv99 = DG.Tweening.Tweener::DOStartupSpecials /* +1 sharing this address */(t, *([v96 @ X8_v12+10]));\n\tv183 = v99 & 1;\n\tv102 = v183 == 0;\n\tif (v102) goto L_FFFFFFFF;\nL_003E:\n\tv78 = System.Type::get_ReflectedType(t._color32Type);\nL_004B:\n\tv95 = v83 <= 0;\n\tif (v95) goto L_005A;\n\tt.duration = v83;\n\tv104 = ~t.startupDone;\n\tif (v104) goto L_005A;\n\tv111 = *([newStartValue @ X1 (T2)+38]);\n\tDG.Tweening.Tweener::DOStartupDurationBased /* +1 sharing this address */(t, *([v111 @ X8_v7+28]));\nL_005A:\n\tv117 = DG.Tweening.Tween::DoGoto(t, 0f, 0, 2);\nL_0068:\n\treturn v185;\n\tgoto L_0068;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static TweenerCore<T1, T2, TPlugOptions> DoChangeValues<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t, T2 newStartValue, T2 newEndValue, float newDuration) where TPlugOptions : struct, IPlugOptions
		{
			//IL_0106: Expected O, but got I
			//IL_0193: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newStartValue @ X1 (T2)+38]");
			if ((nint)0 == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B3490C");
			}
			t.isFrom = false;
			t._003CisRelative_003Ek__BackingField = false;
			T2 startValue = default(T2);
			t.startValue = startValue;
			T2 endValue = default(T2);
			t.endValue = endValue;
			t.hasManuallySetStartValue = true;
			T2 changeValue = default(T2);
			t.changeValue = changeValue;
			TPlugOptions plugOptions = default(TPlugOptions);
			t.plugOptions = plugOptions;
			if (t.startupDone)
			{
				if (t.specialStartupMode != SpecialStartupMode.None)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newStartValue @ X1 (T2)+38]");
					object obj = 0;
					Il2CppRuntime.Boundary("MANAGED", "Method not found @CBAD9C (DG.Tweening.Tweener::DOStartupSpecials, and 1 more at this address)");
					object obj2 = default(object);
					if ((int)((nint)obj2 & 1) == 0)
					{
						return null;
					}
				}
				Type reflectedType = t._color32Type.ReflectedType;
			}
			float num = default(float);
			if (num > 0f)
			{
				t.duration = num;
				if (t.startupDone)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [newStartValue @ X1 (T2)+38]");
					object obj3 = 0;
					Il2CppRuntime.Boundary("MANAGED", "Method not found @CBA2F4 (DG.Tweening.Tweener::DOStartupDurationBased, and 1 more at this address)");
				}
			}
			bool flag = Tween.DoGoto(t, 0f, 0, UpdateMode.IgnoreOnUpdate);
			return t;
		}

		[Token(Token = "0x60002B5")]
		[Address(RVA = "0xCB6D9C", Offset = "0xCB6D9C", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3[], DG.Tweening.Plugins.Options.Vector3ArrayOptions>;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv37 = DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v37, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35851]) = v34;\nL_0013:\n\tv35 = v31 == 0;\n\tif (v35) goto L_00CE;\n\tv39 = v31.specialStartupMode - 1;\n\tv40 = v39 < 3;\n\tv41 = ~v40;\n\tv42 = v39 - 3;\n\tv44 = v42 == 0;\n\tv49 = ~v44;\n\tv50 = v41 & v49;\n\tif (v50) goto L_FFFFFFFF;\n\tv53 = 0x424000 + 0x21C;\n\tv56 = *([v53 @ X9_v2 (System.Int32)+v39 @ X8_v9 (System.Int32)]) << 2;\n\tv57 = 0xCBAE00 + v56;\n\t// 41 IndirectJump v57 @ X10_v2 (System.Int32), v31 @ X0_v1 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), v31 @ X0_v1 (DG.Tweening.Core.TweenerCore`3<T1, T2, TPlugOptions>), v65 @ X1_v2 (Il2CppMethodInfo), v62 @ X2_v1, v18 @ X3, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\n\tX8 = *([19376B0]);\n\tX9 = *([X19]);\n\tX8 = *([X8]);\n\tX11 = *([X9+130]);\n\tX10 = *([X8+130]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_009E;\n\tX0 = 0;\n\tgoto L_00B1;\n\tX8 = *([1938208]);\n\tX9 = *([X19]);\n\tX8 = *([X8]);\n\tX11 = *([X9+130]);\n\tX10 = *([X8+130]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0072;\n\tX0 = 0;\n\tgoto L_0085;\n\tX8 = *([1938208]);\n\tX9 = *([X19]);\n\tX8 = *([X8]);\n\tX11 = *([X9+130]);\n\tX10 = *([X8+130]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_0088;\n\tX0 = 0;\n\tgoto L_009B;\n\tX8 = *([1938208]);\n\tX9 = *([X19]);\n\tX8 = *([X8]);\n\tX11 = *([X9+130]);\n\tX10 = *([X8+130]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_00B4;\n\tX0 = 0;\n\tgoto L_00C7;\nL_0072:\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_0083;\n\tX0 = X19;\n\tgoto L_0084;\nL_0083:\n\tX0 = 0;\nL_0084:\n\t;\nL_0085:\n\tX1 = 0;\n\tX0 = DG.Tweening.Plugins.Core.SpecialPluginsUtils::SetPunch(X0, X1);\n\tgoto L_00C9;\nL_0088:\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_0099;\n\tX0 = X19;\n\tgoto L_009A;\nL_0099:\n\tX0 = 0;\nL_009A:\n\t;\nL_009B:\n\tX1 = 0;\n\tX0 = DG.Tweening.Plugins.Core.SpecialPluginsUtils::SetCameraShakePosition(X0, X1);\n\tgoto L_00C9;\nL_009E:\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_00AF;\n\tX0 = X19;\n\tgoto L_00B0;\nL_00AF:\n\tX0 = 0;\nL_00B0:\n\t;\nL_00B1:\n\tX1 = 0;\n\tX0 = DG.Tweening.Plugins.Core.SpecialPluginsUtils::SetLookAt(X0, X1);\n\tgoto L_00C9;\nL_00B4:\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_00C5;\n\tX0 = X19;\n\tgoto L_00C6;\nL_00C5:\n\tX0 = 0;\nL_00C6:\n\t;\nL_00C7:\n\tX1 = 0;\n\tX0 = DG.Tweening.Plugins.Core.SpecialPluginsUtils::SetShake(X0, X1);\nL_00C9:\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00EC;\n\tgoto L_00F2;\nL_00CE:\n\tv51 = new System.NullReferenceException();\n\tgoto L_00DD;\n\tgoto L_00DD;\n\tgoto L_00DD;\n\tgoto L_00DD;\nL_00DD:\n\tv76 = v65 != 1;\n\tif (v76) goto L_00FE;\n\tv125 = 0x1854E70(v51, v65, v62, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv137 = *([v125 @ X0_v10]);\n\tv138 = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v137 @ X8_v5]), v62, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv139 = v138 & 1;\n\tv118 = v139 == 0;\n\tif (v118) goto L_00F4;\n\tv117 = 0x1854E80(v138, *([v137 @ X8_v5]), v62, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_00EC:\n\t;\nL_00F2:\n\treturn v111;\nL_00F4:\n\tv141 = 0x1854E90(8, *([v137 @ X8_v5]), v62, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\t*([v141 @ X0_v16]) = *([v125 @ X0_v10]);\n\tv65 = 0x185A000 + 0xF88;\n\tv143 = 0x1854EA0(v141, v65, 0, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv129 = 0x1854E80(v143, v65, 0, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_00FE:\n\tv133 = 0xBD3CD0(v109, v65, 0, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\treturnVal2 = 0x9DACB4(v133, v65, 0, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\treturn returnVal2;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool DOStartupSpecials<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t) where TPlugOptions : struct, IPlugOptions
		{
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
					int num3 = 4341760 + 540;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v2 (System.Int32)+v39 @ X8_v9 (System.Int32)]");
					int num4 = (int)((nint)0 << 2);
					int num5 = 13348352 + num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v57 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			nint num6 = default(nint);
			bool flag5 = num6 != 1;
			NullReferenceException ex2 = ex;
			if (!flag5)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
				object obj2 = default(object);
				object obj = obj2;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj3 = default(object);
				if ((int)((nint)obj3 & 1) != 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					return false;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @1854E90 (native __cxa_allocate_exception)");
				object obj4 = obj2;
				num6 = 25538440;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @1854EA0 (native __cxa_throw)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
				NullReferenceException ex3 = default(NullReferenceException);
				ex2 = ex3;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			bool result = default(bool);
			return result;
		}

		[Token(Token = "0x60002B6")]
		[Address(RVA = "0xCB62F4", Offset = "0xCB62F4", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = ~t.isSpeedBased;\n\tif (v8) goto L_0018;\n\tv50 = System.Reflection.MemberInfo::get_Module(t._color32Type);\n\tt.duration = t.duration;\nL_0018:\n\tv55 = t.loops & 0x80000000;\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_FFFFFFFF;\n\tv69 = t.duration * t.loops;\n\tgoto L_0022;\nL_0022:\n\tt.fullDuration = v69;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DOStartupDurationBased<T1, T2, TPlugOptions>(TweenerCore<T1, T2, TPlugOptions> t) where TPlugOptions : struct, IPlugOptions
		{
			//IL_008a: Expected I4, but got I8
			if (t.isSpeedBased)
			{
				Module module = ((MemberInfo)t._color32Type).Module;
				t.duration = t.duration;
			}
			float num = (((int)(t.loops & 0x80000000L) != 0) ? float.PositiveInfinity : (t.duration * (float)t.loops));
			t.fullDuration = num;
		}
	}
}
