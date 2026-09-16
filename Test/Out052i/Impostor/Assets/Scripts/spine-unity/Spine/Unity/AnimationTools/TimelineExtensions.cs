using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.AnimationTools
{
	[Token(Token = "0x20000C6")]
	public static class TimelineExtensions
	{
		[Token(Token = "0x60006FC")]
		[Address(RVA = "0x1572690", Offset = "0x1572690", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = timeline.frames;\n\tv160 = v18[0] <= time;\n\tif (v160) goto L_0040;\n\tgoto L_002F;\n\tv310 = UnityEngine.Vector2;\n\tv311 = \"il2cpp_codegen_initialize_runtime_metadata\"(v310, skeletonData, methodInfo, v136, v137, v138, v139, v140, v148, v30, v23, v141, v142, v143, v144, v145);\n\tv314 = 1;\n\t*([1A35518]) = v314;\nL_002F:\n\treturnVal2 = v318.zeroVector;\n\tgoto L_00F3;\nL_0040:\n\tv323 = v18.Length << 0x20;\n\tv324 = 0xFFFFFFFD00000000 + v323;\n\tv173 = v324 >> 0x1E;\n\tv175 = v18 + v173;\n\tv326 = *([v175 @ X9_v7+20]) < time;\n\tv327 = ~v326;\n\tv328 = *([v175 @ X9_v7+20]) - time;\n\tv330 = v328 == 0;\n\tv335 = ~v327;\n\tv74 = v335 | v330;\n\tif (v74) goto L_00C3;\n\tv180 = Spine.Animation::BinarySearch(v18, time, 3);\n\tv241 = v180 - 2;\n\tv165 = v180 - 3;\n\tv381 = v180 * 0x55555556;\n\tv177 = v381 >> 0x3F;\n\tv382 = v381 >> 0x20;\n\tv161 = time - v18[v180 @ X0_v8 (System.Int32)];\n\tv383 = v18[v165 @ X11_v6 (System.Int32)] - v18[v180 @ X0_v8 (System.Int32)];\n\tv384 = v382 + v177;\n\tv385 = v161 / v383;\n\tv172 = v384 - 1;\n\tv386 = 1f - v385;\n\tv240 = Spine.CurveTimeline::GetCurvePercent(timeline, v172, v386);\n\tv242 = v180 + 1;\n\tv391 = v18[v242 @ X8_v19 (System.Int32)] - v18[v241 @ X8_v13 (System.Int32)];\n\tv393 = v240 * v391;\n\tv118 = v18[v241 @ X8_v13 (System.Int32)] + v393;\n\tv394 = skeletonData == 0;\n\tv355 = ~v394;\n\tif (v355) goto L_00CF;\n\tgoto L_00F3;\nL_00C3:\n\tv358 = v18.Length << 0x20;\n\tv361 = v358 + 0xFFFFFFFE00000000;\n\tv344 = v18 + 0x20;\n\tv353 = v361 >> 0x1E;\n\treturnVal2 = *([v344 @ X11_v5+v353 @ X8_v12 (System.Int32)]);\n\tv356 = skeletonData == 0;\n\tif (v356) goto L_00F3;\nL_00CF:\n\tv125 = skeletonData.bones;\n\tv126 = v125.Items;\n\tv67 = *([1A35018]);\n\tv127 = v126[v67 @ X9_v9];\n\tv350 = v118 + v127.x;\nL_00F3:\n\treturn returnVal2;\n\tv69 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 189 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector2 Evaluate(this TranslateTimeline timeline, float time, SkeletonData skeletonData = null)
		{
			//IL_0064: Expected I4, but got I8
			//IL_0080: Expected O, but got I
			//IL_0291: Expected O, but got I8
			//IL_02a0: Expected O, but got I
			//IL_02bf: Expected O, but got I
			//IL_02de: Expected F4, but got I
			//IL_0320: Expected O, but got I
			//IL_0357: Expected O, but got F4
			//IL_026a: Expected O, but got F4
			float[] frames = timeline.Frames;
			float num18;
			Vector2 result;
			if (!(frames[0] > time))
			{
				int num = frames.Length << 32;
				int num2 = (int)(-12884901888L + num);
				int num3 = num2 >> 30;
				object obj = (nint)frames + num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ X9_v7+20]");
				bool flag = 0f < time;
				bool flag2 = !flag;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ X9_v7+20]");
				float num4 = 0f - time;
				bool flag3 = num4 == 0f;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					int num5 = Animation.BinarySearch(frames, time, 3);
					int num6 = num5 - 2;
					int num7 = num5 - 3;
					int num8 = num5 * 1431655766;
					int num9 = num8 >> 63;
					int num10 = num8 >> 32;
					float num11 = time - frames[num5];
					float num12 = frames[num7] - frames[num5];
					int num13 = num10 + num9;
					float num14 = num11 / num12;
					int frameIndex = num13 - 1;
					float percent = 1f - num14;
					float curvePercent = timeline.GetCurvePercent(frameIndex, percent);
					int num15 = num5 + 1;
					float num16 = frames[num15] - frames[num6];
					float num17 = curvePercent * num16;
					num18 = frames[num6] + num17;
					if (skeletonData != null)
					{
						goto IL_02ec;
					}
					result = (Vector2)num18;
				}
				else
				{
					int num19 = frames.Length << 32;
					object obj2 = num19 + -8589934592L;
					object obj3 = (nint)frames + 32;
					int num20 = (int)((nint)obj2 >> 30);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ X11_v5+v353 @ X8_v12 (System.Int32)]");
					result = (Vector2)0;
					bool flag5 = skeletonData == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ X11_v5+v353 @ X8_v12 (System.Int32)]");
					num18 = 0f;
					if (!flag5)
					{
						goto IL_02ec;
					}
				}
			}
			else
			{
				result = Vector2.zero;
			}
			goto IL_036a;
			IL_02ec:
			ExposedList<BoneData> bones = skeletonData.Bones;
			BoneData[] items = bones.Items;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1A35018]");
			object obj4 = 0;
			BoneData boneData = items[obj4];
			float num21 = num18 + boneData.X;
			result = (Vector2)num21;
			goto IL_036a;
			IL_036a:
			return result;
		}

		[Token(Token = "0x60006FD")]
		[Address(RVA = "0x157289C", Offset = "0x157289C", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, boneIndex, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, boneIndex, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv135 = Il2CppMethodInfo;\n\tv136 = \"il2cpp_codegen_initialize_runtime_metadata\"(v135, boneIndex, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv148 = Il2CppMethodInfo;\n\tv149 = \"il2cpp_codegen_initialize_runtime_metadata\"(v148, boneIndex, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv164 = Spine.TranslateTimeline;\n\tv165 = \"il2cpp_codegen_initialize_runtime_metadata\"(v164, boneIndex, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv230 = Spine.TranslateTimeline;\n\tv231 = \"il2cpp_codegen_initialize_runtime_metadata\"(v230, boneIndex, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv238 = System.Type;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v238, boneIndex, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 1;\n\t*([1A37CF7]) = v49;\nL_002D:\n\tv53 = a == 0;\n\tif (v53) goto L_00A6;\n\tv58 = a.timelines == 0;\n\tif (v58) goto L_00A6;\n\tv146 = Spine.ExposedList`1<Spine.Timeline>::GetEnumerator(a.timelines);\nL_0047:\n\tv217 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v109 @ stack_-88_v3 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv233 = v217 == 0;\n\tif (v233) goto L_FFFFFFFF;\n\tv246 = System.Object::GetType(v151);\n\tgoto L_005B;\n\tv327 = \"il2cpp_codegen_runtime_class_init\"(v276, v245, v96, v33, v34, v35, v36, v37, v107, v39, v40, v41, v42, v43, v44, v45);\nL_005B:\n\tv281 = System.Type::GetTypeFromHandle(Spine.TranslateTimeline);\n\tv210 = *([v246 @ X0_v31 (System.Type)]);\n\tv96 = *([v210 @ X8_v13 (Il2CppClass<System.Type>)+280]);\n\tv205 = System.Type::IsSubclassOf(v246, v281);\n\tv365 = v205 == 0;\n\tv207 = ~v365;\n\tif (v207) goto L_0047;\n\tgoto L_FFFFFFFF;\n\tv168 = v168_asT == 0;\n\tif (v168) goto L_0047;\n\tv169 = *([v151 @ stack_-78 (System.Object)+18]) != boneIndex;\n\tif (v169) goto L_0047;\n\tgoto L_0096;\nL_0096:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v109 @ stack_-88_v3 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_00A3:\n\treturn v310;\n\tv247 = new System.NullReferenceException();\n\tv124 = new System.NullReferenceException();\nL_00A6:\n\tv133 = new System.NullReferenceException();\n\tgoto L_00B7;\n\tgoto L_00B7;\n\tgoto L_00B7;\n\tgoto L_00B7;\n\tgoto L_00B7;\n\tgoto L_00B7;\nL_00B7:\n\tv162 = v117 != 1;\n\tif (v162) goto L_00C5;\n\tv219 = 0x1854E70(v133, v117, v95, v33, v34, v35, v36, v37, v109, v39, v40, v41, v42, v43, v44, v45);\n\tv310 = *([v219 @ X0_v13]);\n\tv234 = 0x1854E80(v219, v117, v95, v33, v34, v35, v36, v37, v109, v39, v40, v41, v42, v43, v44, v45);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v104 @ stack_-70_v2 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv225 = *([v219 @ X0_v13]) == 0;\n\tif (v225) goto L_00A3;\n\tthrow System.OutOfMemoryException;\nL_00C5:\n\tgoto L_00C9;\n\tX19 = X0;\nL_00C9:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v104 @ stack_-70_v2 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00D0;\n\tv272 = 0xBD3CD0(v133, *([v111 @ X23_v1 (Il2CppMethodInfo)]), v95, v33, v34, v35, v36, v37, v109, v39, v40, v41, v42, v43, v44, v45);\nL_00D0:\n\tv275 = new System.OutOfMemoryException();\n\treturnVal2 = 0x9DACB4(v275, *([v111 @ X23_v1 (Il2CppMethodInfo)]), v95, v33, v34, v35, v36, v37, v109, v39, v40, v41, v42, v43, v44, v45);\n\treturn returnVal2;\n// 142 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TranslateTimeline FindTranslateTimelineForBone(this Animation a, int boneIndex)
		{
			//IL_0089: Expected I, but got O
			bool flag = a == null;
			nint num = default(nint);
			IntPtr intPtr = num;
			ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
			int num2 = boneIndex;
			TranslateTimeline result;
			if (!flag)
			{
				bool flag2 = a.Timelines == null;
				intPtr = num;
				ExposedList<object>.Enumerator enumerator2 = default(ExposedList<object>.Enumerator);
				enumerator = enumerator2;
				nint num3 = 0;
				int num4 = default(int);
				num2 = num4;
				if (!flag2)
				{
					ExposedList<Timeline>.Enumerator enumerator3 = a.Timelines.GetEnumerator();
					object obj = default(object);
					object obj2;
					while (true)
					{
						if (enumerator2.MoveNext())
						{
							Type type = obj.GetType();
							Type typeFromHandle = typeof(TranslateTimeline);
							nint num5 = (nint)type;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ X8_v13 (Il2CppClass<System.Type>)+280]");
							num = 0;
							if (type.IsSubclassOf(typeFromHandle))
							{
								continue;
							}
							TranslateTimeline translateTimeline = obj as TranslateTimeline;
							if (translateTimeline != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ stack_-78 (System.Object)+18]");
								if ((nint)0 == boneIndex)
								{
									obj2 = obj;
									break;
								}
							}
							continue;
						}
						obj2 = null;
						break;
					}
					enumerator2.Dispose();
					result = (TranslateTimeline)obj2;
					goto IL_0140;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (num2 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				object obj3 = default(object);
				result = (TranslateTimeline)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				if (obj3 != null)
				{
					throw new OutOfMemoryException();
				}
				goto IL_0140;
			}
			enumerator.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
			TranslateTimeline result2 = default(TranslateTimeline);
			return result2;
			IL_0140:
			return result;
		}
	}
}
