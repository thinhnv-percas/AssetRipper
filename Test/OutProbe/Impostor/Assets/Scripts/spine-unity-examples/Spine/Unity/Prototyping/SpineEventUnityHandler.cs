using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace Spine.Unity.Prototyping
{
	[Token(Token = "0x200000C")]
	public class SpineEventUnityHandler : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x200000D")]
		public class EventPair
		{
			[SpineEvent(null, null, true, false, false)]
			[Token(Token = "0x4000032")]
			[FieldOffset(Offset = "0x10")]
			public string spineEvent;

			[Token(Token = "0x4000033")]
			[FieldOffset(Offset = "0x18")]
			public UnityEvent unityHandler;

			[Token(Token = "0x4000034")]
			[FieldOffset(Offset = "0x20")]
			public AnimationState.TrackEntryEventDelegate eventDelegate;

			[Token(Token = "0x600002C")]
			[Address(RVA = "0x150A174", Offset = "0x150A174", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public EventPair()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200000E")]
		private sealed class _003C_003Ec__DisplayClass4_0
		{
			[Token(Token = "0x4000035")]
			[FieldOffset(Offset = "0x10")]
			public EventPair ep;

			[Token(Token = "0x4000036")]
			[FieldOffset(Offset = "0x18")]
			public EventData eventData;

			[Token(Token = "0x600002D")]
			[Address(RVA = "0x1509ED0", Offset = "0x1509ED0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass4_0()
			{
			}

			internal void _003CStart_003Eb__0(TrackEntry trackEntry, Event e)
			{
				if (e.Data == eventData)
				{
					EventPair eventPair = ep;
					eventPair.unityHandler.Invoke();
				}
			}
		}

		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x20")]
		public List<EventPair> events;

		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x28")]
		private ISkeletonComponent skeletonComponent;

		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x30")]
		private IAnimationStateComponent animationStateComponent;

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x1509B1C", Offset = "0x1509B1C", Length = "0x3B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv226 = Spine.Unity.IAnimationStateComponent;\n\tv227 = \"il2cpp_codegen_initialize_runtime_metadata\"(v226, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv305 = Spine.Unity.ISkeletonComponent;\n\tv306 = \"il2cpp_codegen_initialize_runtime_metadata\"(v305, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv337 = Il2CppMethodInfo;\n\tv338 = \"il2cpp_codegen_initialize_runtime_metadata\"(v337, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv362 = Spine.AnimationState+TrackEntryEventDelegate;\n\tv363 = \"il2cpp_codegen_initialize_runtime_metadata\"(v362, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv382 = Il2CppMethodInfo;\n\tv383 = \"il2cpp_codegen_initialize_runtime_metadata\"(v382, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv388 = Spine.Unity.Prototyping.SpineEventUnityHandler+<>c__DisplayClass4_0;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v388, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A379E9]) = v48;\nL_0035:\n\tv66 = this.skeletonComponent;\n\tv53 = this.skeletonComponent == 0;\n\tif (v53) goto L_003E;\n\tthis.skeletonComponent = v66;\n\tgoto L_0043;\nL_003E:\n\tv66 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonComponent = v66;\n\tv68 = v66 == 0;\n\tif (v68) goto L_0109;\nL_0043:\n\tv71 = this.animationStateComponent == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_004E;\n\t// 73 IsInst v79 @ X0_v59 (Spine.Unity.IAnimationStateComponent), typeof(Spine.Unity.IAnimationStateComponent), v66 @ X0_v4 (Spine.Unity.ISkeletonComponent)\n\tthis.animationStateComponent = v79;\n\tv83 = v79 == 0;\n\tif (v83) goto L_0109;\nL_004E:\n\tv86 = this.skeletonComponent == 0;\n\tif (v86) goto L_0110;\n\tgoto L_007D;\n\tv307 = *([v229 @ X8_v13+B0]);\n\tv308 = v307 + 8;\n\tv310 = *([v350 @ X10_v17-8]);\n\tv355 = v310 == v232;\n\tif (v355) goto L_0075;\n\tv330 = v349 - 1;\n\tv332 = v350 + 0x10;\n\tv312 = v349 != 1;\n\tif (v312) goto L_FFFFFFFF;\n\tv333 = 1;\n\tv334 = v85;\n\tv335 = 0xB349B4(v334, v232, v333, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_007D;\nL_0075:\n\tv365 = *([v350 @ X10_v17]);\n\tv366 = v365 + 1;\n\tv367 = v366 << 4;\n\tv368 = v229 + v367;\n\tv369 = v368 + 0x138;\nL_007D:\n\tv200 = Spine.Unity.ISkeletonComponent::get_Skeleton(this.skeletonComponent);\n\tv204 = v200 == 0;\n\tif (v204) goto L_0109;\n\tv258 = this.animationStateComponent == 0;\n\tif (v258) goto L_0110;\n\tgoto L_00B0;\n\tv397 = *([v390 @ X8_v16+B0]);\n\tv398 = v397 + 8;\n\tv400 = *([v442 @ X10_v12-8]);\n\tv447 = v400 == v393;\n\tif (v447) goto L_00A9;\n\tv420 = v441 - 1;\n\tv422 = v442 + 0x10;\n\tv402 = v441 != 1;\n\tif (v402) goto L_FFFFFFFF;\n\tv423 = v238;\n\tv424 = 0;\n\tv425 = 0xB349B4(v423, v393, v424, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00B0;\nL_00A9:\n\tv454 = *([v442 @ X10_v12]);\n\tv455 = v454 << 4;\n\tv456 = v390 + v455;\n\tv457 = v456 + 0x138;\nL_00B0:\n\tv255 = Spine.Unity.IAnimationStateComponent::get_AnimationState(this.animationStateComponent);\n\tv259 = this.events == 0;\n\tif (v259) goto L_0110;\n\tv467 = System.Collections.Generic.List`1<Spine.Unity.Prototyping.SpineEventUnityHandler+EventPair>::GetEnumerator(this.events);\nL_00C9:\n\tv488 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v123 @ stack_-88_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv202 = v488 == 0;\n\tif (v202) goto L_00FD;\n\tv491 = new Spine.Unity.Prototyping.SpineEventUnityHandler+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v491);\n\tv494 = v491 == 0;\n\tif (v494) goto L_010C;\n\tv491.ep = v469;\n\tv509 = v200.data == 0;\n\tif (v509) goto L_010A;\n\tv520 = Spine.SkeletonData::FindEvent(v200.data, v469.spineEvent);\n\tv476 = v491.ep;\n\tv491.eventData = v520;\n\tv547 = v476.eventDelegate == 0;\n\tv548 = ~v547;\n\tif (v548) goto L_00F7;\n\tv543 = new Spine.AnimationState+TrackEntryEventDelegate();\n\tSpine.AnimationState+TrackEntryEventDelegate::.ctor(v543, v491, Il2CppMethodInfo);\n\tv476.eventDelegate = v543;\n\tv544 = v491.ep == 0;\n\tif (v544) goto L_010F;\nL_00F7:\n\tSpine.AnimationState::add_Event(v255, v476.eventDelegate);\n\tgoto L_00C9;\nL_00FD:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v123 @ stack_-88_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_0109:\n\treturn;\nL_010A:\n\tthrow v491;\n\tv504 = new System.NullReferenceException();\nL_010C:\n\tthrow v491;\n\tv516 = new System.NullReferenceException();\n\tv533 = new System.NullReferenceException();\nL_010F:\n\tthrow v543;\nL_0110:\n\tv265 = new System.NullReferenceException();\n\tgoto L_0125;\n\tgoto L_0125;\n\tgoto L_0125;\n\tgoto L_0125;\n\tgoto L_0125;\n\tgoto L_0125;\n\tgoto L_0125;\n\tgoto L_0125;\n\tgoto L_0125;\n\tgoto L_0125;\nL_0125:\n\tv141 = v250 != 1;\n\tif (v141) goto L_0135;\n\tv374 = 0x1854E70(v265, v250, v136, v94, v33, v34, v35, v36, v121, v38, v39, v40, v41, v42, v43, v44);\n\tv384 = 0x1854E80(v374, v250, v136, v94, v33, v34, v35, v36, v121, v38, v39, v40, v41, v42, v43, v44);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v109 @ stack_-70_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv203 = *([v374 @ X0_v17]) == 0;\n\tif (v203) goto L_0109;\n\tthrow System.OutOfMemoryException;\nL_0135:\n\tgoto L_013B;\n\tX19 = X0;\nL_013B:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v109 @ stack_-70_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0142;\n\tv427 = System.Collections.Generic.List`1<Spine.Unity.Prototyping.SpineEventUnityHandler+EventPair>+Enumerator<Spine.Unity.Prototyping.SpineEventUnityHandler+EventPair>::Dispose(v265);\nL_0142:\n\tv430 = new System.OutOfMemoryException();\n\tv296 = System.Collections.Generic.List`1<Spine.Unity.Prototyping.SpineEventUnityHandler+EventPair>+Enumerator<Spine.Unity.Prototyping.SpineEventUnityHandler+EventPair>::Dispose(v430);\n\treturn;\n// 180 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Start()
		{
			//IL_00a9: Expected I4, but got O
			//IL_0105: Expected I, but got O
			//IL_03c1: Expected I, but got O
			//IL_024c: Expected O, but got I4
			ISkeletonComponent skeletonComponent = this.skeletonComponent;
			if (this.skeletonComponent != null)
			{
				this.skeletonComponent = skeletonComponent;
			}
			else
			{
				skeletonComponent = (this.skeletonComponent = GetComponent<ISkeletonComponent>());
				if (skeletonComponent == null)
				{
					return;
				}
			}
			bool flag = animationStateComponent == null;
			bool flag2 = !flag;
			int num = 0;
			if (!flag2)
			{
				bool flag3 = (animationStateComponent = skeletonComponent as IAnimationStateComponent) == null;
				num = (int)typeof(IAnimationStateComponent);
				if (flag3)
				{
					return;
				}
			}
			bool flag4 = this.skeletonComponent == null;
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			if (!flag4)
			{
				Skeleton skeleton = this.skeletonComponent.Skeleton;
				if (skeleton == null)
				{
					return;
				}
				bool flag5 = animationStateComponent == null;
				enumerator = default(List<object>.Enumerator);
				nint num2 = unchecked((nint)null);
				num = 0;
				if (!flag5)
				{
					AnimationState animationState = animationStateComponent.AnimationState;
					bool flag6 = events == null;
					enumerator = default(List<object>.Enumerator);
					num2 = unchecked((nint)null);
					num = 0;
					if (!flag6)
					{
						List<EventPair>.Enumerator enumerator2 = events.GetEnumerator();
						List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
						EventPair eventPair = default(EventPair);
						AnimationState.TrackEntryEventDelegate trackEntryEventDelegate;
						while (true)
						{
							if (enumerator3.MoveNext())
							{
								_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass4_0();
								if (CS_0024_003C_003E8__locals10 != null)
								{
									CS_0024_003C_003E8__locals10.ep = eventPair;
									if (skeleton.Data != null)
									{
										EventData eventData = skeleton.Data.FindEvent(eventPair.spineEvent);
										EventPair eventPair2 = CS_0024_003C_003E8__locals10.ep;
										CS_0024_003C_003E8__locals10.eventData = eventData;
										if (eventPair2.eventDelegate == null)
										{
											trackEntryEventDelegate = (eventPair2.eventDelegate = delegate(TrackEntry trackEntry, Event e)
											{
												if (e.Data == CS_0024_003C_003E8__locals10.eventData)
												{
													EventPair eventPair3 = CS_0024_003C_003E8__locals10.ep;
													eventPair3.unityHandler.Invoke();
												}
											});
											bool flag7 = CS_0024_003C_003E8__locals10.ep == null;
											eventPair2 = CS_0024_003C_003E8__locals10.ep;
											object obj = 0;
											num2 = 0;
											if (flag7)
											{
												break;
											}
										}
										animationState.Event += eventPair2.eventDelegate;
										continue;
									}
									throw CS_0024_003C_003E8__locals10;
								}
								throw CS_0024_003C_003E8__locals10;
							}
							enumerator3.Dispose();
							return;
						}
						throw trackEntryEventDelegate;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (num == 1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj2 = default(object);
				if (obj2 != null)
				{
					throw new OutOfMemoryException();
				}
			}
			else
			{
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				((List<EventPair>.Enumerator*)ex2)->Dispose();
			}
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x1509ED8", Offset = "0x1509ED8", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv181 = Spine.Unity.IAnimationStateComponent;\n\tv182 = \"il2cpp_codegen_initialize_runtime_metadata\"(v181, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv233 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v233, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A379EA]) = v38;\nL_0021:\n\tv39 = 0;\n\tv60 = this.animationStateComponent;\n\tv43 = this.animationStateComponent == 0;\n\tif (v43) goto L_002D;\n\tthis.animationStateComponent = v60;\n\tgoto L_0038;\nL_002D:\n\tv51 = UnityEngine.Component::GetComponent(this);\n\tthis.animationStateComponent = v51;\n\tv58 = v51 == 0;\n\tif (v58) goto L_0089;\nL_0038:\n\tgoto L_005E;\n\tv71 = *([v63 @ X8_v5+B0]);\n\tv72 = v71 + 8;\n\tv74 = *([v194 @ X10_v8-8]);\n\tv199 = v74 == v66;\n\tif (v199) goto L_0057;\n\tv104 = v193 - 1;\n\tv106 = v194 + 0x10;\n\tv77 = v193 != 1;\n\tif (v77) goto L_FFFFFFFF;\n\tv107 = v60;\n\tv108 = 0;\n\tv109 = 0xB349B4(v107, v66, v108, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_005E;\nL_0057:\n\tv235 = *([v194 @ X10_v8]);\n\tv236 = v235 << 4;\n\tv237 = v63 + v236;\n\tv238 = v237 + 0x138;\nL_005E:\n\tv246 = Spine.Unity.IAnimationStateComponent::get_AnimationState(v60);\n\tv247 = this.events == 0;\n\tif (v247) goto L_008C;\n\tv254 = System.Collections.Generic.List`1<Spine.Unity.Prototyping.SpineEventUnityHandler+EventPair>::GetEnumerator(this.events);\nL_006F:\n\tv275 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v39 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv164 = v275 == 0;\n\tif (v164) goto L_0082;\n\tv255 = 0;\n\tv287 = *([v255 @ X22_v5 (System.Int32)+20]) == 0;\n\tif (v287) goto L_007E;\n\tSpine.AnimationState::remove_Event(v246, *([v255 @ X22_v5 (System.Int32)+20]));\nL_007E:\n\t*([v255 @ X22_v5 (System.Int32)+20]) = 0;\n\tgoto L_006F;\nL_0082:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v39 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_0089:\n\treturn;\n\tv288 = new System.NullReferenceException();\n\tv259 = new System.NullReferenceException();\nL_008C:\n\tv265 = new System.NullReferenceException();\n\tgoto L_009A;\n\tgoto L_009A;\n\tgoto L_009A;\nL_009A:\n\tv126 = v256 != 1;\n\tif (v126) goto L_00AA;\n\tv280 = 0x1854E70(v265, v256, v266, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv289 = 0x1854E80(v280, v256, v266, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v39 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv165 = *([v280 @ X0_v18]) == 0;\n\tif (v165) goto L_0089;\n\tthrow System.OutOfMemoryException;\nL_00AA:\n\tgoto L_00B0;\n\tX19 = X0;\nL_00B0:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v39 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00B7;\n\tv299 = System.Collections.Generic.List`1<Spine.Unity.Prototyping.SpineEventUnityHandler+EventPair>+Enumerator<Spine.Unity.Prototyping.SpineEventUnityHandler+EventPair>::Dispose(v265);\nL_00B7:\n\tv302 = new System.OutOfMemoryException();\n\tv224 = System.Collections.Generic.List`1<Spine.Unity.Prototyping.SpineEventUnityHandler+EventPair>+Enumerator<Spine.Unity.Prototyping.SpineEventUnityHandler+EventPair>::Dispose(v302);\n\treturn;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void OnDestroy()
		{
			//IL_00e1: Expected O, but got I
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			IAnimationStateComponent animationStateComponent = this.animationStateComponent;
			if (this.animationStateComponent != null)
			{
				this.animationStateComponent = animationStateComponent;
			}
			else
			{
				IAnimationStateComponent animationStateComponent2 = (this.animationStateComponent = GetComponent<IAnimationStateComponent>());
				bool flag = animationStateComponent2 == null;
				animationStateComponent = animationStateComponent2;
				if (flag)
				{
					return;
				}
			}
			AnimationState animationState = animationStateComponent.AnimationState;
			if (events != null)
			{
				List<EventPair>.Enumerator enumerator2 = events.GetEnumerator();
				int num = 0;
				while (enumerator.MoveNext())
				{
					int num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ X22_v5 (System.Int32)+20]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ X22_v5 (System.Int32)+20]");
						animationState.Event -= (AnimationState.TrackEntryEventDelegate)0;
						num = 0;
					}
					_ = 0;
				}
				enumerator.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			int num3 = default(int);
			if (num3 == 1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj != null)
				{
					throw new OutOfMemoryException();
				}
			}
			else
			{
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				((List<EventPair>.Enumerator*)ex2)->Dispose();
			}
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x150A0F8", Offset = "0x150A0F8", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = System.Collections.Generic.List`1<Spine.Unity.Prototyping.SpineEventUnityHandler+EventPair>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A379EB]) = v42;\nL_001A:\n\tv44 = new System.Collections.Generic.List`1<Spine.Unity.Prototyping.SpineEventUnityHandler+EventPair>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.Prototyping.SpineEventUnityHandler+EventPair>::.ctor(v44);\n\tthis.events = v44;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineEventUnityHandler()
		{
			List<EventPair> list = new List<EventPair>();
			events = list;
		}
	}
}
