using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000035")]
	public class AnimationMatchModifierAsset : SkeletonDataModifierAsset
	{
		[Token(Token = "0x2000036")]
		public static class AnimationTools
		{
			[Token(Token = "0x60000D0")]
			[Address(RVA = "0x150F6E0", Offset = "0x150F6E0", Length = "0xD60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0077;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv217 = Il2CppMethodInfo;\n\tv218 = \"il2cpp_codegen_initialize_runtime_metadata\"(v217, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv388 = Il2CppMethodInfo;\n\tv389 = \"il2cpp_codegen_initialize_runtime_metadata\"(v388, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv394 = Il2CppMethodInfo;\n\tv395 = \"il2cpp_codegen_initialize_runtime_metadata\"(v394, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv405 = Il2CppMethodInfo;\n\tv406 = \"il2cpp_codegen_initialize_runtime_metadata\"(v405, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv441 = System.Collections.Generic.Dictionary`2<System.Int32, Spine.Timeline>;\n\tv442 = \"il2cpp_codegen_initialize_runtime_metadata\"(v441, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv469 = Il2CppMethodInfo;\n\tv470 = \"il2cpp_codegen_initialize_runtime_metadata\"(v469, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv503 = Il2CppMethodInfo;\n\tv504 = \"il2cpp_codegen_initialize_runtime_metadata\"(v503, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv561 = Il2CppMethodInfo;\n\tv562 = \"il2cpp_codegen_initialize_runtime_metadata\"(v561, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv676 = Il2CppMethodInfo;\n\tv677 = \"il2cpp_codegen_initialize_runtime_metadata\"(v676, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv770 = Il2CppMethodInfo;\n\tv771 = \"il2cpp_codegen_initialize_runtime_metadata\"(v770, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv844 = Il2CppMethodInfo;\n\tv845 = \"il2cpp_codegen_initialize_runtime_metadata\"(v844, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv975 = Spine.EventTimeline;\n\tv976 = \"il2cpp_codegen_initialize_runtime_metadata\"(v975, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv993 = Il2CppMethodInfo;\n\tv994 = \"il2cpp_codegen_initialize_runtime_metadata\"(v993, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv1098 = Il2CppMethodInfo;\n\tv1099 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1098, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv1182 = Il2CppMethodInfo;\n\tv1183 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1182, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv1275 = Il2CppMethodInfo;\n\tv1276 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1275, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv1335 = Il2CppMethodInfo;\n\tv1336 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1335, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv1472 = Il2CppMethodInfo;\n\tv1473 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1472, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv1672 = System.Collections.Generic.HashSet`1<System.Int32>;\n\tv1673 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1672, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv1816 = System.IDisposable;\n\tv1817 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1816, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv1909 = System.Collections.Generic.IEnumerable`1<Spine.Animation>;\n\tv1910 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1909, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv1982 = System.Collections.Generic.IEnumerator`1<Spine.Animation>;\n\tv1983 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1982, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv2054 = System.Collections.IEnumerator;\n\tv2055 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2054, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv2116 = Il2CppMethodInfo;\n\tv2117 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2116, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv2196 = Il2CppMethodInfo;\n\tv2197 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2196, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv2258 = Il2CppMethodInfo;\n\tv2259 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2258, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv2298 = System.Collections.Generic.List`1<System.Int32>;\n\tv2299 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2298, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv2344 = Spine.Timeline;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2344, skeletonData, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A37A30]) = v53;\nL_0077:\n\tv60 = animations == 0;\n\tif (v60) goto L_0416;\n\tv64 = skeletonData == 0;\n\tif (v64) goto L_0450;\n\tv226 = new System.Collections.Generic.Dictionary`2<System.Int32, Spine.Timeline>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, Spine.Timeline>::.ctor(v226);\n\tgoto L_00B1;\n\tv407 = *([v396 @ X8_v105+B0]);\n\tv408 = v407 + 8;\n\tv410 = *([v453 @ X10_v118-8]);\n\tv459 = v410 == v397;\n\tif (v459) goto L_00A9;\n\tv432 = v454 - 1;\n\tv430 = v453 + 0x10;\n\tv412 = v454 != 1;\n\tif (v412) goto L_FFFFFFFF;\n\tv433 = v28;\n\tv434 = 0;\n\tv435 = 0xB349B4(v433, v397, v434, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00B1;\nL_00A9:\n\tv472 = *([v453 @ X10_v118]);\n\tv473 = v472 << 4;\n\tv474 = v396 + v473;\n\tv475 = v474 + 0x138;\nL_00B1:\n\tv496 = System.Collections.Generic.IEnumerable`1<Spine.Animation>::GetEnumerator(animations);\nL_00C5:\n\tgoto L_00EB;\n\tv678 = *([v621 @ X8_v109+B0]);\n\tv679 = v678 + 8;\n\tv681 = *([v782 @ X10_v113-8]);\n\tv788 = v681 == v622;\n\tif (v788) goto L_00E4;\n\tv703 = v783 - 1;\n\tv701 = v782 + 0x10;\n\tv683 = v783 != 1;\n\tif (v683) goto L_FFFFFFFF;\n\tv704 = v497;\n\tv705 = 0;\n\tv706 = 0xB349B4(v704, v622, v705, v563, v38, v39, v40, v41, v575, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00EB;\nL_00E4:\n\tv847 = *([v782 @ X10_v113]);\n\tv848 = v847 << 4;\n\tv849 = v621 + v848;\n\tv850 = v849 + 0x138;\nL_00EB:\n\tv870 = System.Collections.IEnumerator::MoveNext(v496);\n\tv872 = v870 == 0;\n\tif (v872) goto L_01C4;\n\tgoto L_011B;\n\tv995 = *([v977 @ X8_v112+B0]);\n\tv996 = v995 + 8;\n\tv998 = *([v1110 @ X10_v108-8]);\n\tv1116 = v998 == v981;\n\tif (v1116) goto L_0114;\n\tv1020 = v1111 - 1;\n\tv1018 = v1110 + 0x10;\n\tv1000 = v1111 != 1;\n\tif (v1000) goto L_FFFFFFFF;\n\tv1021 = v497;\n\tv1022 = 0;\n\tv1023 = 0xB349B4(v1021, v981, v1022, v563, v38, v39, v40, v41, v575, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_011B;\nL_0114:\n\tv1185 = *([v1110 @ X10_v108]);\n\tv1186 = v1185 << 4;\n\tv1187 = v977 + v1186;\n\tv1188 = v1187 + 0x138;\nL_011B:\n\tv1208 = System.Collections.Generic.IEnumerator`1<Spine.Animation>::get_Current(v496);\n\tv1341 = Spine.ExposedList`1<Spine.Timeline>::GetEnumerator(v1208.timelines);\nL_012C:\n\tv1696 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v578 @ stack_-B8_v26 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv1819 = v1696 == 0;\n\tif (v1819) goto L_0196;\n\tv962 = v1475 == 0;\n\tif (v962) goto L_01A7;\n\tgoto L_FFFFFFFF;\n\tv1686 = v1686_asT != 0;\n\tif (v1686) goto L_012C;\n\tgoto L_017B;\n\tv2118 = *([v2069 @ X8_v123+B0]);\n\tv2119 = v2118 + 8;\n\tv2121 = \n// ... truncated")]
			public static void MatchAnimationTimelines(IEnumerable<Animation> animations, SkeletonData skeletonData)
			{
				//IL_020b: Expected O, but got I4
				//IL_0220: Expected I, but got O
				//IL_0a20: Expected I, but got O
				//IL_0a25: Expected I, but got O
				//IL_0252: Expected O, but got I4
				//IL_0257: Expected I, but got O
				//IL_025c: Expected I, but got O
				//IL_0269: Expected I, but got O
				//IL_09f3: Expected O, but got I
				//IL_0052: Expected I, but got O
				//IL_0362: Expected I4, but got O
				//IL_0159: Expected O, but got I
				//IL_05c4: Expected I, but got O
				//IL_05c9: Expected I, but got O
				//IL_05ce: Expected I, but got O
				//IL_07bc: Expected I, but got O
				//IL_07da: Expected I, but got O
				//IL_07eb: Expected I, but got O
				//IL_01b1: Expected I, but got O
				//IL_0c38: Expected O, but got I
				//IL_0769: Expected O, but got I
				//IL_0779: Expected O, but got I
				//IL_0bdb: Expected I, but got O
				//IL_0b56: Expected I, but got O
				//IL_0b5b: Expected I, but got O
				//IL_0b60: Expected I, but got O
				//IL_03c2: Expected I, but got O
				//IL_011a: Expected I, but got O
				//IL_0535: Expected O, but got I
				//IL_0549: Expected O, but got I
				if (animations == null)
				{
					return;
				}
				List<int>.Enumerator enumerator2;
				Dictionary<int, Timeline> dictionary3;
				List<int> list;
				HashSet<int> hashSet;
				IEnumerator<Animation> enumerator4;
				List<int> list2 = default(List<int>);
				IEnumerable<Animation> enumerable;
				nint num5;
				nint num3;
				int num7;
				nint num8;
				HashSet<int> hashSet2;
				Animation current;
				nint num6;
				Animation animation2;
				Timeline timeline2;
				Dictionary<int, Timeline> dictionary4;
				IDisposable disposable;
				SkeletonData skeletonData2;
				if (skeletonData != null)
				{
					Dictionary<int, Timeline> dictionary = new Dictionary<int, Timeline>();
					IEnumerator<Animation> enumerator = animations.GetEnumerator();
					ExposedList<object>.Enumerator enumerator6 = default(ExposedList<object>.Enumerator);
					Timeline timeline = default(Timeline);
					nint num2;
					if (!enumerator.MoveNext())
					{
						bool flag = enumerator == null;
						bool flag2 = !flag;
						enumerator2 = default(List<int>.Enumerator);
						Animation animation = (Animation)10;
						IEnumerator<Animation> enumerator3 = enumerator;
						nint num = unchecked((nint)null);
						Dictionary<int, Timeline> dictionary2 = dictionary;
						IEnumerable<Animation> enumerable2;
						nint num4;
						if (!flag2)
						{
							enumerable = animations;
							enumerator2 = default(List<int>.Enumerator);
							animation2 = (Animation)10;
							num2 = unchecked((nint)null);
							num3 = unchecked((nint)null);
							enumerable2 = animations;
							num4 = unchecked((nint)null);
							dictionary3 = dictionary;
						}
						else
						{
							enumerator3.Dispose();
							enumerable = animations;
							animation2 = animation;
							num2 = unchecked((nint)null);
							num3 = unchecked((nint)null);
							enumerable2 = animations;
							num4 = num;
							dictionary3 = dictionary2;
						}
						bool flag3 = num4 == 0;
						bool flag4 = !flag3;
						skeletonData2 = (SkeletonData)num4;
						if (!flag4)
						{
							if ((nint)animation2 != 10 && animation2 != null)
							{
								return;
							}
							Dictionary<int, Timeline>.KeyCollection keys = dictionary3.Keys;
							list = new List<int>((int)keys);
							hashSet = new HashSet<int>();
							enumerator4 = enumerable2.GetEnumerator();
							if (!enumerator4.MoveNext())
							{
								list2 = list;
								enumerable = (IEnumerable<Animation>)enumerator4;
								num5 = unchecked((nint)null);
								num6 = unchecked((nint)null);
								num3 = unchecked((nint)null);
								num7 = 18;
								num8 = 0;
								hashSet2 = hashSet;
								goto IL_0b2e;
							}
							current = enumerator4.Current;
							hashSet.Clear();
							if (current != null)
							{
								ExposedList<Timeline>.Enumerator enumerator5 = current.Timelines.GetEnumerator();
								num6 = unchecked((nint)null);
								while (enumerator6.MoveNext())
								{
									if (timeline != null)
									{
										EventTimeline eventTimeline = timeline as EventTimeline;
										if (eventTimeline == null)
										{
											int propertyId = timeline.PropertyId;
											bool flag5 = hashSet.Add(propertyId);
											num6 = 0;
										}
										continue;
									}
									goto IL_050b;
								}
								enumerator6.Dispose();
								OutOfMemoryException ex = new OutOfMemoryException();
								NullReferenceException ex2 = new NullReferenceException();
								NullReferenceException ex3 = new NullReferenceException();
							}
							throw hashSet;
						}
						OutOfMemoryException ex4 = new OutOfMemoryException();
						throw new NullReferenceException();
					}
					Animation current2 = enumerator.Current;
					ExposedList<Timeline>.Enumerator enumerator7 = current2.Timelines.GetEnumerator();
					num2 = unchecked((nint)null);
					while (true)
					{
						if (enumerator6.MoveNext())
						{
							if (timeline != null)
							{
								EventTimeline eventTimeline2 = timeline as EventTimeline;
								if (eventTimeline2 == null)
								{
									int propertyId2 = timeline.PropertyId;
									if (dictionary == null)
									{
										NullReferenceException ex5 = new NullReferenceException();
										enumerable = animations;
										enumerator2 = default(List<int>.Enumerator);
										animation2 = (Animation)timeline;
										timeline2 = null;
										num3 = unchecked((nint)null);
										dictionary4 = (Dictionary<int, Timeline>)(object)ex5;
										disposable = enumerator;
										skeletonData2 = skeletonData;
										dictionary3 = dictionary;
										break;
									}
									bool flag6 = dictionary.ContainsKey(propertyId2);
									bool flag7 = !flag6;
									bool flag8 = !flag7;
									num2 = 0;
									if (!flag8)
									{
										Timeline fillerTimeline = GetFillerTimeline(timeline, skeletonData);
										dictionary.Add(propertyId2, fillerTimeline);
										num2 = (nint)fillerTimeline;
									}
								}
								continue;
							}
							NullReferenceException ex6 = new NullReferenceException();
							enumerable = animations;
							enumerator2 = default(List<int>.Enumerator);
							animation2 = (Animation)timeline;
							timeline2 = (Timeline)num2;
							num3 = 0;
							dictionary4 = (Dictionary<int, Timeline>)(object)ex6;
							disposable = enumerator;
							skeletonData2 = skeletonData;
							dictionary3 = dictionary;
							break;
						}
						enumerator6.Dispose();
						throw new OutOfMemoryException();
					}
					goto IL_0b85;
				}
				ArgumentNullException ex7 = new ArgumentNullException("skeletonData", "Timelines can't be matched without a SkeletonData source.");
				throw ex7;
				IL_0b2e:
				if (enumerable != null)
				{
					((IDisposable)null).Dispose();
					num6 = unchecked((nint)null);
					num3 = unchecked((nint)null);
					num8 = unchecked((nint)null);
				}
				bool flag9 = num5 == 0;
				bool flag10 = !flag9;
				animation2 = (Animation)num5;
				skeletonData2 = (SkeletonData)(object)hashSet2;
				if (!flag10)
				{
					if (num7 == 18 || num7 == 0)
					{
						dictionary3.Clear();
						int version = list2._version + 1;
						list2._size = 0;
						list2._version = version;
						hashSet2.Clear();
					}
					return;
				}
				OutOfMemoryException ex8 = new OutOfMemoryException();
				list2 = list2;
				timeline2 = (Timeline)num6;
				dictionary4 = (Dictionary<int, Timeline>)(object)ex8;
				disposable = (IDisposable)num8;
				goto IL_0b85;
				IL_0b85:
				enumerator2.Dispose();
				if (animation2 != null)
				{
					OutOfMemoryException ex9 = new OutOfMemoryException();
					NullReferenceException ex10 = new NullReferenceException();
					throw new NullReferenceException();
				}
				if (num3 == 1)
				{
					dictionary4.Add((int)num3, timeline2);
					Dictionary<int, Timeline> dictionary5 = default(Dictionary<int, Timeline>);
					num5 = (nint)dictionary5;
					dictionary5.Add((int)num3, timeline2);
					num6 = (nint)timeline2;
					num7 = 0;
					num8 = (nint)disposable;
					hashSet2 = (HashSet<int>)(object)skeletonData2;
					goto IL_0b2e;
				}
				if (enumerable != null)
				{
					((IDisposable)enumerable).Dispose();
					timeline2 = null;
					num3 = unchecked((nint)null);
				}
				OutOfMemoryException ex11 = (OutOfMemoryException)(object)dictionary4;
				((Dictionary<int, Timeline>)(object)ex11).Add((int)num3, timeline2);
				Timeline value = timeline2;
				IntPtr intPtr = num3;
				OutOfMemoryException ex12 = new OutOfMemoryException();
				((Dictionary<int, Timeline>)(object)ex12).Add((int)(nint)intPtr, value);
				return;
				IL_050b:
				NullReferenceException ex13 = new NullReferenceException();
				list2 = list;
				enumerable = (IEnumerable<Animation>)enumerator4;
				animation2 = current;
				timeline2 = (Timeline)num6;
				num3 = 0;
				dictionary4 = (Dictionary<int, Timeline>)(object)ex13;
				disposable = (IDisposable)0;
				skeletonData2 = (SkeletonData)(object)hashSet;
				goto IL_0b85;
			}

			[Token(Token = "0x60000D1")]
			[Address(RVA = "0x1510450", Offset = "0x1510450", Length = "0x44C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv18 = Spine.AttachmentTimeline;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skeletonData, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = Spine.ColorTimeline;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, skeletonData, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv116 = Spine.DeformTimeline;\n\tv117 = \"il2cpp_codegen_initialize_runtime_metadata\"(v116, skeletonData, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv410 = Spine.DrawOrderTimeline;\n\tv411 = \"il2cpp_codegen_initialize_runtime_metadata\"(v410, skeletonData, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv439 = Spine.IkConstraintTimeline;\n\tv440 = \"il2cpp_codegen_initialize_runtime_metadata\"(v439, skeletonData, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv468 = Spine.PathConstraintMixTimeline;\n\tv469 = \"il2cpp_codegen_initialize_runtime_metadata\"(v468, skeletonData, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv497 = Spine.PathConstraintPositionTimeline;\n\tv498 = \"il2cpp_codegen_initialize_runtime_metadata\"(v497, skeletonData, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv526 = Spine.PathConstraintSpacingTimeline;\n\tv527 = \"il2cpp_codegen_initialize_runtime_metadata\"(v526, skeletonData, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv555 = Spine.RotateTimeline;\n\tv556 = \"il2cpp_codegen_initialize_runtime_metadata\"(v555, skeletonData, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv584 = Spine.ScaleTimeline;\n\tv585 = \"il2cpp_codegen_initialize_runtime_metadata\"(v584, skeletonData, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv613 = Spine.ShearTimeline;\n\tv614 = \"il2cpp_codegen_initialize_runtime_metadata\"(v613, skeletonData, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv642 = Spine.TransformConstraintTimeline;\n\tv643 = \"il2cpp_codegen_initialize_runtime_metadata\"(v642, skeletonData, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv670 = Spine.TranslateTimeline;\n\tv671 = \"il2cpp_codegen_initialize_runtime_metadata\"(v670, skeletonData, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv699 = Spine.TwoColorTimeline;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v699, skeletonData, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37A31]) = v37;\nL_0039:\n\tv38 = timeline == 0;\n\tif (v38) goto L_01D9;\n\tgoto L_FFFFFFFF;\n\tv126 = v126_asT != 0;\n\tif (v126) goto L_01E0;\n\tgoto L_FFFFFFFF;\n\tv271 = v271_asT != 0;\n\tif (v271) goto L_01E8;\n\tgoto L_FFFFFFFF;\n\tv272 = v272_asT != 0;\n\tif (v272) goto L_01F0;\n\tgoto L_FFFFFFFF;\n\tv273 = v273_asT != 0;\n\tif (v273) goto L_01F8;\n\tgoto L_FFFFFFFF;\n\tv274 = v274_asT != 0;\n\tif (v274) goto L_0201;\n\tgoto L_FFFFFFFF;\n\tv275 = v275_asT != 0;\n\tif (v275) goto L_020A;\n\tgoto L_FFFFFFFF;\n\tv276 = v276_asT != 0;\n\tif (v276) goto L_0213;\n\tgoto L_FFFFFFFF;\n\tv277 = v277_asT != 0;\n\tif (v277) goto L_021B;\n\tgoto L_FFFFFFFF;\n\tv278 = v278_asT != 0;\n\tif (v278) goto L_0222;\n\tgoto L_FFFFFFFF;\n\tv279 = v279_asT != 0;\n\tif (v279) goto L_022B;\n\tgoto L_FFFFFFFF;\n\tv280 = v280_asT != 0;\n\tif (v280) goto L_0234;\n\tgoto L_FFFFFFFF;\n\tv281 = v281_asT != 0;\n\tif (v281) goto L_023D;\n\tgoto L_FFFFFFFF;\n\tv282 = v282_asT != 0;\n\tif (v282) goto L_0246;\n\tgoto L_FFFFFFFF;\n\tv85 = v85_asT != 0;\n\tif (v85) goto L_024F;\nL_01D9:\n\treturn 0;\nL_01E0:\n\treturnVal2 = Spine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::GetFillerTimeline(timeline, skeletonData);\n\treturn returnVal2;\nL_01E8:\n\treturnVal3 = Spine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::GetFillerTimeline(timeline, skeletonData);\n\treturn returnVal3;\nL_01F0:\n\treturnVal4 = Spine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::GetFillerTimeline(timeline, skeletonData);\n\treturn returnVal4;\nL_01F8:\n\treturnVal5 = Spine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::GetFillerTimeline(timeline, skeletonData);\n\treturn returnVal5;\nL_0201:\n\treturnVal6 = Spine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::GetFillerTimeline(timeline, skeletonData);\n\treturn returnVal6;\nL_020A:\n\treturnVal7 = Spine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::GetFillerTimeline(timeline, skeletonData);\n\treturn returnVal7;\nL_0213:\n\treturnVal8 = Spine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::GetFillerTimeline(timeline, skeletonData);\n\treturn returnVal8;\nL_021B:\n\treturnVal9 = Spine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::GetFillerTimeline(timeline, skeletonData);\n\treturn returnVal9;\nL_0222:\n\treturnVal10 = Spine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::GetFillerTimeline(timeline, skeletonData);\n\treturn returnVal10;\nL_022B:\n\treturnVal11 = Spine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::GetFillerTimeline(timeline, skeletonData);\n\treturn returnVal11;\nL_0234:\n\treturnVal12 = Spine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::GetFillerTimeline(timeline, skeletonData);\n\treturn returnVal12;\nL_023D:\n\treturnVal13 = Spine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::GetFillerTimeline(timeline, skeletonData);\n\treturn returnVal13;\nL_0246:\n\treturnVal14 = Spine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::GetFillerTimeline(timeline, skeletonData);\n\treturn returnVal14;\nL_024F:\n\treturnVal15 = Spine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::GetFillerTimeline(timeline, skeletonData);\n\treturn returnVal15;\n// 489 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static Timeline GetFillerTimeline(Timeline timeline, SkeletonData skeletonData)
			{
				if (timeline != null)
				{
					RotateTimeline rotateTimeline = timeline as RotateTimeline;
					if (rotateTimeline != null)
					{
						return GetFillerTimeline((RotateTimeline)timeline, skeletonData);
					}
					TranslateTimeline translateTimeline = timeline as TranslateTimeline;
					if (translateTimeline != null)
					{
						return GetFillerTimeline((TranslateTimeline)timeline, skeletonData);
					}
					ScaleTimeline scaleTimeline = timeline as ScaleTimeline;
					if (scaleTimeline != null)
					{
						return GetFillerTimeline((ScaleTimeline)timeline, skeletonData);
					}
					ShearTimeline shearTimeline = timeline as ShearTimeline;
					if (shearTimeline != null)
					{
						return GetFillerTimeline((ShearTimeline)timeline, skeletonData);
					}
					AttachmentTimeline attachmentTimeline = timeline as AttachmentTimeline;
					if (attachmentTimeline != null)
					{
						return GetFillerTimeline((AttachmentTimeline)timeline, skeletonData);
					}
					ColorTimeline colorTimeline = timeline as ColorTimeline;
					if (colorTimeline != null)
					{
						return GetFillerTimeline((ColorTimeline)timeline, skeletonData);
					}
					TwoColorTimeline twoColorTimeline = timeline as TwoColorTimeline;
					if (twoColorTimeline != null)
					{
						return GetFillerTimeline((TwoColorTimeline)timeline, skeletonData);
					}
					DeformTimeline deformTimeline = timeline as DeformTimeline;
					if (deformTimeline != null)
					{
						return GetFillerTimeline((DeformTimeline)timeline, skeletonData);
					}
					DrawOrderTimeline drawOrderTimeline = timeline as DrawOrderTimeline;
					if (drawOrderTimeline != null)
					{
						return GetFillerTimeline((DrawOrderTimeline)timeline, skeletonData);
					}
					IkConstraintTimeline ikConstraintTimeline = timeline as IkConstraintTimeline;
					if (ikConstraintTimeline != null)
					{
						return GetFillerTimeline((IkConstraintTimeline)timeline, skeletonData);
					}
					TransformConstraintTimeline transformConstraintTimeline = timeline as TransformConstraintTimeline;
					if (transformConstraintTimeline != null)
					{
						return GetFillerTimeline((TransformConstraintTimeline)timeline, skeletonData);
					}
					PathConstraintPositionTimeline pathConstraintPositionTimeline = timeline as PathConstraintPositionTimeline;
					if (pathConstraintPositionTimeline != null)
					{
						return GetFillerTimeline((PathConstraintPositionTimeline)timeline, skeletonData);
					}
					PathConstraintSpacingTimeline pathConstraintSpacingTimeline = timeline as PathConstraintSpacingTimeline;
					if (pathConstraintSpacingTimeline != null)
					{
						return GetFillerTimeline((PathConstraintSpacingTimeline)timeline, skeletonData);
					}
					PathConstraintMixTimeline pathConstraintMixTimeline = timeline as PathConstraintMixTimeline;
					if (pathConstraintMixTimeline != null)
					{
						return GetFillerTimeline((PathConstraintMixTimeline)timeline, skeletonData);
					}
				}
				return null;
			}

			[Token(Token = "0x60000D2")]
			[Address(RVA = "0x151089C", Offset = "0x151089C", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.RotateTimeline;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skeletonData, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A32]) = v37;\nL_0014:\n\tv39 = new Spine.RotateTimeline();\n\tSpine.RotateTimeline::.ctor(v39, 1);\n\tSpine.RotateTimeline::set_BoneIndex(v39, timeline.boneIndex);\n\tSpine.RotateTimeline::SetFrame(v39, 0, 0f, 0f);\n\treturn v39;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static RotateTimeline GetFillerTimeline(RotateTimeline timeline, SkeletonData skeletonData)
			{
				RotateTimeline rotateTimeline = new RotateTimeline(1);
				rotateTimeline.BoneIndex = timeline.PropertyId;
				rotateTimeline.SetFrame(0, 0f, 0f);
				return rotateTimeline;
			}

			[Token(Token = "0x60000D3")]
			[Address(RVA = "0x151092C", Offset = "0x151092C", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.TranslateTimeline;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skeletonData, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A33]) = v37;\nL_0014:\n\tv39 = new Spine.TranslateTimeline();\n\tSpine.TranslateTimeline::.ctor(v39, 1);\n\tSpine.TranslateTimeline::set_BoneIndex(v39, timeline.boneIndex);\n\tSpine.TranslateTimeline::SetFrame(v39, 0, 0f, 0f, 0f);\n\treturn v39;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static TranslateTimeline GetFillerTimeline(TranslateTimeline timeline, SkeletonData skeletonData)
			{
				TranslateTimeline translateTimeline = new TranslateTimeline(1);
				translateTimeline.BoneIndex = timeline.BoneIndex;
				translateTimeline.SetFrame(0, 0f, 0f, 0f);
				return translateTimeline;
			}

			[Token(Token = "0x60000D4")]
			[Address(RVA = "0x15109C0", Offset = "0x15109C0", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.ScaleTimeline;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skeletonData, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A34]) = v37;\nL_0014:\n\tv39 = new Spine.ScaleTimeline();\n\tSpine.ScaleTimeline::.ctor(v39, 1);\n\tSpine.TranslateTimeline::set_BoneIndex(v39, timeline.boneIndex);\n\tSpine.TranslateTimeline::SetFrame(v39, 0, 0f, 0f, 0f);\n\treturn v39;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static ScaleTimeline GetFillerTimeline(ScaleTimeline timeline, SkeletonData skeletonData)
			{
				ScaleTimeline scaleTimeline = new ScaleTimeline(1);
				scaleTimeline.BoneIndex = timeline.BoneIndex;
				scaleTimeline.SetFrame(0, 0f, 0f, 0f);
				return scaleTimeline;
			}

			[Token(Token = "0x60000D5")]
			[Address(RVA = "0x1510A54", Offset = "0x1510A54", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.ShearTimeline;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skeletonData, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A35]) = v37;\nL_0014:\n\tv39 = new Spine.ShearTimeline();\n\tSpine.ShearTimeline::.ctor(v39, 1);\n\tSpine.TranslateTimeline::set_BoneIndex(v39, timeline.boneIndex);\n\tSpine.TranslateTimeline::SetFrame(v39, 0, 0f, 0f, 0f);\n\treturn v39;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static ShearTimeline GetFillerTimeline(ShearTimeline timeline, SkeletonData skeletonData)
			{
				ShearTimeline shearTimeline = new ShearTimeline(1);
				shearTimeline.BoneIndex = timeline.BoneIndex;
				shearTimeline.SetFrame(0, 0f, 0f, 0f);
				return shearTimeline;
			}

			[Token(Token = "0x60000D6")]
			[Address(RVA = "0x1510AE8", Offset = "0x1510AE8", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Spine.AttachmentTimeline;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, skeletonData, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37A36]) = v40;\nL_0016:\n\tv42 = new Spine.AttachmentTimeline();\n\tSpine.AttachmentTimeline::.ctor(v42, 1);\n\tSpine.AttachmentTimeline::set_SlotIndex(v42, timeline.slotIndex);\n\tv93 = skeletonData.slots;\n\tv94 = v93.Items;\n\tv80 = v42.slotIndex;\n\tv95 = v94[v80 @ X9_v3 (System.Int32)];\n\tSpine.AttachmentTimeline::SetFrame(v42, 0, 0f, v95.attachmentName);\n\treturn v42;\n\tv96 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static AttachmentTimeline GetFillerTimeline(AttachmentTimeline timeline, SkeletonData skeletonData)
			{
				AttachmentTimeline attachmentTimeline = new AttachmentTimeline(1);
				attachmentTimeline.SlotIndex = timeline.SlotIndex;
				ExposedList<SlotData> slots = skeletonData.Slots;
				SlotData[] items = slots.Items;
				int slotIndex = attachmentTimeline.SlotIndex;
				SlotData slotData = items[slotIndex];
				attachmentTimeline.SetFrame(0, 0f, slotData.AttachmentName);
				return attachmentTimeline;
			}

			[Token(Token = "0x60000D7")]
			[Address(RVA = "0x1510BB8", Offset = "0x1510BB8", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Spine.ColorTimeline;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, skeletonData, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37A37]) = v40;\nL_0016:\n\tv42 = new Spine.ColorTimeline();\n\tSpine.ColorTimeline::.ctor(v42, 1);\n\tSpine.ColorTimeline::set_SlotIndex(v42, timeline.slotIndex);\n\tv93 = skeletonData.slots;\n\tv94 = v93.Items;\n\tv80 = v42.slotIndex;\n\tv95 = v94[v80 @ X9_v3 (System.Int32)];\n\tSpine.ColorTimeline::SetFrame(v42, 0, 0f, v95.r, v95.g, v95.b, v95.a);\n\treturn v42;\n\tv96 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static ColorTimeline GetFillerTimeline(ColorTimeline timeline, SkeletonData skeletonData)
			{
				ColorTimeline colorTimeline = new ColorTimeline(1);
				colorTimeline.SlotIndex = timeline.SlotIndex;
				ExposedList<SlotData> slots = skeletonData.Slots;
				SlotData[] items = slots.Items;
				int slotIndex = colorTimeline.SlotIndex;
				SlotData slotData = items[slotIndex];
				colorTimeline.SetFrame(0, 0f, slotData.R, slotData.G, slotData.B, slotData.A);
				return colorTimeline;
			}

			[Token(Token = "0x60000D8")]
			[Address(RVA = "0x1510C8C", Offset = "0x1510C8C", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Spine.TwoColorTimeline;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, skeletonData, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37A38]) = v40;\nL_0016:\n\tv42 = new Spine.TwoColorTimeline();\n\tSpine.TwoColorTimeline::.ctor(v42, 1);\n\tSpine.TwoColorTimeline::set_SlotIndex(v42, timeline.slotIndex);\n\tv93 = skeletonData.slots;\n\tv94 = v93.Items;\n\tv80 = v42.slotIndex;\n\tv95 = v94[v80 @ X9_v3 (System.Int32)];\n\tSpine.TwoColorTimeline::SetFrame(v42, 0, 0f, v95.r, v95.g, v95.b, v95.a, v95.r2, v95.g2, v95.b2);\n\treturn v42;\n\tv96 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static TwoColorTimeline GetFillerTimeline(TwoColorTimeline timeline, SkeletonData skeletonData)
			{
				TwoColorTimeline twoColorTimeline = new TwoColorTimeline(1);
				twoColorTimeline.SlotIndex = timeline.SlotIndex;
				ExposedList<SlotData> slots = skeletonData.Slots;
				SlotData[] items = slots.Items;
				int slotIndex = twoColorTimeline.SlotIndex;
				SlotData slotData = items[slotIndex];
				twoColorTimeline.SetFrame(0, 0f, slotData.R, slotData.G, slotData.B, slotData.A, slotData.R2, slotData.G2, slotData.B2);
				return twoColorTimeline;
			}

			[Token(Token = "0x60000D9")]
			[Address(RVA = "0x1510D68", Offset = "0x1510D68", Length = "0xFC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = Spine.DeformTimeline;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, skeletonData, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = System.Single[];\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, skeletonData, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A39]) = v38;\nL_0017:\n\tv40 = new Spine.DeformTimeline();\n\tSpine.DeformTimeline::.ctor(v40, 1);\n\tSpine.DeformTimeline::set_SlotIndex(v40, timeline.slotIndex);\n\tv40.attachment = timeline.attachment;\n\tv56 = Spine.SpineSkeletonExtensions::IsWeighted(timeline.attachment);\n\tv50 = v40.attachment;\n\tv57 = v50.vertices;\n\tv92 = v56 == 0;\n\tif (v92) goto L_003C;\n\t// 55 NewArr v106 @ X0_v10 (System.Single[]), typeof(System.Single[]), [v57 @ X0_v9 (System.Array)+18]\n\tgoto L_0046;\nL_003C:\n\tv100 = System.Array::Clone(v50.vertices);\n\t// 64 IsInst v106 @ X0_v10 (System.Single[]), typeof(System.Single[]), v100 @ X0_v13 (System.Object)\nL_0046:\n\tSpine.DeformTimeline::SetFrame(v40, 0, 0f, v106);\n\treturn v40;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static DeformTimeline GetFillerTimeline(DeformTimeline timeline, SkeletonData skeletonData)
			{
				DeformTimeline deformTimeline = new DeformTimeline(1);
				deformTimeline.SlotIndex = timeline.SlotIndex;
				deformTimeline.Attachment = timeline.Attachment;
				bool flag = timeline.Attachment.IsWeighted();
				VertexAttachment attachment = deformTimeline.Attachment;
				Array vertices = attachment.Vertices;
				float[] vertices2;
				if (flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X0_v9 (System.Array)+18]");
					vertices2 = new float[0];
				}
				else
				{
					object obj = attachment.Vertices.Clone();
					vertices2 = obj as float[];
				}
				deformTimeline.SetFrame(0, 0f, vertices2);
				return deformTimeline;
			}

			[Token(Token = "0x60000DA")]
			[Address(RVA = "0x1510E64", Offset = "0x1510E64", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = Spine.DrawOrderTimeline;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, skeletonData, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37A3A]) = v34;\nL_0012:\n\tv36 = new Spine.DrawOrderTimeline();\n\tSpine.DrawOrderTimeline::.ctor(v36, 1);\n\tSpine.DrawOrderTimeline::SetFrame(v36, 0, 0f, 0);\n\treturn v36;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static DrawOrderTimeline GetFillerTimeline(DrawOrderTimeline timeline, SkeletonData skeletonData)
			{
				DrawOrderTimeline drawOrderTimeline = new DrawOrderTimeline(1);
				drawOrderTimeline.SetFrame(0, 0f, null);
				return drawOrderTimeline;
			}

			[Token(Token = "0x60000DB")]
			[Address(RVA = "0x1510EDC", Offset = "0x1510EDC", Length = "0xCC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Spine.IkConstraintTimeline;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, skeletonData, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37A3B]) = v40;\nL_0016:\n\tv42 = new Spine.IkConstraintTimeline();\n\tSpine.IkConstraintTimeline::.ctor(v42, 1);\n\tv47 = skeletonData.ikConstraints;\n\tv88 = v47.Items;\n\tv81 = timeline.ikConstraintIndex;\n\tv89 = v88[v81 @ X9_v3 (System.Int32)];\n\tSpine.IkConstraintTimeline::SetFrame(v42, 0, 0f, v89.mix, v89.softness, v89.bendDirection, v89.compress, v89.stretch);\n\treturn v42;\n\tv90 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static IkConstraintTimeline GetFillerTimeline(IkConstraintTimeline timeline, SkeletonData skeletonData)
			{
				IkConstraintTimeline ikConstraintTimeline = new IkConstraintTimeline(1);
				ExposedList<IkConstraintData> ikConstraints = skeletonData.IkConstraints;
				IkConstraintData[] items = ikConstraints.Items;
				int ikConstraintIndex = timeline.IkConstraintIndex;
				IkConstraintData ikConstraintData = items[ikConstraintIndex];
				ikConstraintTimeline.SetFrame(0, 0f, ikConstraintData.Mix, ikConstraintData.Softness, ikConstraintData.BendDirection, ikConstraintData.Compress, ikConstraintData.Stretch);
				return ikConstraintTimeline;
			}

			[Token(Token = "0x60000DC")]
			[Address(RVA = "0x1510FA8", Offset = "0x1510FA8", Length = "0xC4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Spine.TransformConstraintTimeline;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, skeletonData, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37A3C]) = v40;\nL_0016:\n\tv42 = new Spine.TransformConstraintTimeline();\n\tSpine.TransformConstraintTimeline::.ctor(v42, 1);\n\tv47 = skeletonData.transformConstraints;\n\tv88 = v47.Items;\n\tv81 = timeline.transformConstraintIndex;\n\tv89 = v88[v81 @ X9_v3 (System.Int32)];\n\tSpine.TransformConstraintTimeline::SetFrame(v42, 0, 0f, v89.rotateMix, v89.translateMix, v89.scaleMix, v89.shearMix);\n\treturn v42;\n\tv90 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static TransformConstraintTimeline GetFillerTimeline(TransformConstraintTimeline timeline, SkeletonData skeletonData)
			{
				TransformConstraintTimeline transformConstraintTimeline = new TransformConstraintTimeline(1);
				ExposedList<TransformConstraintData> transformConstraints = skeletonData.TransformConstraints;
				TransformConstraintData[] items = transformConstraints.Items;
				int transformConstraintIndex = timeline.TransformConstraintIndex;
				TransformConstraintData transformConstraintData = items[transformConstraintIndex];
				transformConstraintTimeline.SetFrame(0, 0f, transformConstraintData.RotateMix, transformConstraintData.TranslateMix, transformConstraintData.ScaleMix, transformConstraintData.ShearMix);
				return transformConstraintTimeline;
			}

			[Token(Token = "0x60000DD")]
			[Address(RVA = "0x151106C", Offset = "0x151106C", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Spine.PathConstraintPositionTimeline;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, skeletonData, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37A3D]) = v40;\nL_0016:\n\tv42 = new Spine.PathConstraintPositionTimeline();\n\tSpine.PathConstraintPositionTimeline::.ctor(v42, 1);\n\tv47 = skeletonData.pathConstraints;\n\tv88 = v47.Items;\n\tv81 = timeline.pathConstraintIndex;\n\tv89 = v88[v81 @ X9_v3 (System.Int32)];\n\tSpine.PathConstraintPositionTimeline::SetFrame(v42, 0, 0f, v89.position);\n\treturn v42;\n\tv90 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static PathConstraintPositionTimeline GetFillerTimeline(PathConstraintPositionTimeline timeline, SkeletonData skeletonData)
			{
				PathConstraintPositionTimeline pathConstraintPositionTimeline = new PathConstraintPositionTimeline(1);
				ExposedList<PathConstraintData> pathConstraints = skeletonData.PathConstraints;
				PathConstraintData[] items = pathConstraints.Items;
				int pathConstraintIndex = timeline.PathConstraintIndex;
				PathConstraintData pathConstraintData = items[pathConstraintIndex];
				pathConstraintPositionTimeline.SetFrame(0, 0f, pathConstraintData.Position);
				return pathConstraintPositionTimeline;
			}

			[Token(Token = "0x60000DE")]
			[Address(RVA = "0x151112C", Offset = "0x151112C", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Spine.PathConstraintSpacingTimeline;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, skeletonData, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37A3E]) = v40;\nL_0016:\n\tv42 = new Spine.PathConstraintSpacingTimeline();\n\tSpine.PathConstraintSpacingTimeline::.ctor(v42, 1);\n\tv47 = skeletonData.pathConstraints;\n\tv88 = v47.Items;\n\tv81 = timeline.pathConstraintIndex;\n\tv89 = v88[v81 @ X9_v3 (System.Int32)];\n\tSpine.PathConstraintPositionTimeline::SetFrame(v42, 0, 0f, v89.spacing);\n\treturn v42;\n\tv90 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static PathConstraintSpacingTimeline GetFillerTimeline(PathConstraintSpacingTimeline timeline, SkeletonData skeletonData)
			{
				PathConstraintSpacingTimeline pathConstraintSpacingTimeline = new PathConstraintSpacingTimeline(1);
				ExposedList<PathConstraintData> pathConstraints = skeletonData.PathConstraints;
				PathConstraintData[] items = pathConstraints.Items;
				int pathConstraintIndex = timeline.PathConstraintIndex;
				PathConstraintData pathConstraintData = items[pathConstraintIndex];
				pathConstraintSpacingTimeline.SetFrame(0, 0f, pathConstraintData.Spacing);
				return pathConstraintSpacingTimeline;
			}

			[Token(Token = "0x60000DF")]
			[Address(RVA = "0x15111EC", Offset = "0x15111EC", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Spine.PathConstraintMixTimeline;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, skeletonData, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37A3F]) = v40;\nL_0016:\n\tv42 = new Spine.PathConstraintMixTimeline();\n\tSpine.PathConstraintMixTimeline::.ctor(v42, 1);\n\tv47 = skeletonData.pathConstraints;\n\tv88 = v47.Items;\n\tv81 = timeline.pathConstraintIndex;\n\tv89 = v88[v81 @ X9_v3 (System.Int32)];\n\tSpine.PathConstraintMixTimeline::SetFrame(v42, 0, 0f, v89.rotateMix, v89.translateMix);\n\treturn v42;\n\tv90 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private static PathConstraintMixTimeline GetFillerTimeline(PathConstraintMixTimeline timeline, SkeletonData skeletonData)
			{
				PathConstraintMixTimeline pathConstraintMixTimeline = new PathConstraintMixTimeline(1);
				ExposedList<PathConstraintData> pathConstraints = skeletonData.PathConstraints;
				PathConstraintData[] items = pathConstraints.Items;
				int pathConstraintIndex = timeline.PathConstraintIndex;
				PathConstraintData pathConstraintData = items[pathConstraintIndex];
				pathConstraintMixTimeline.SetFrame(0, 0f, pathConstraintData.RotateMix, pathConstraintData.TranslateMix);
				return pathConstraintMixTimeline;
			}
		}

		[Token(Token = "0x4000115")]
		[FieldOffset(Offset = "0x18")]
		public bool matchAllAnimations;

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x150F6B8", Offset = "0x150F6B8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = ~this.matchAllAnimations;\n\tif (v4) goto L_000E;\n\tSpine.Unity.Examples.AnimationMatchModifierAsset+AnimationTools::MatchAnimationTimelines(skeletonData.animations, skeletonData);\n\treturn;\nL_000E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Apply(SkeletonData skeletonData)
		{
			if (matchAllAnimations)
			{
				AnimationTools.MatchAnimationTimelines(skeletonData.Animations, skeletonData);
			}
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x1510440", Offset = "0x1510440", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.matchAllAnimations = 1;\n\tSpine.Unity.SkeletonDataModifierAsset::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimationMatchModifierAsset()
		{
			matchAllAnimations = true;
		}
	}
}
