using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A7FC", Offset = "0x75A7FC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75A7FC", Offset = "0x75A7FC")]
	[Token(Token = "0x20002C0")]
	public class GetNextRayCast2d : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BD124", Offset = "0x7BD124")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD124", Offset = "0x7BD124")]
		[Token(Token = "0x4001800")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault fromGameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD184", Offset = "0x7BD184")]
		[Token(Token = "0x4001801")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 fromPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD1BC", Offset = "0x7BD1BC")]
		[Token(Token = "0x4001802")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector2 direction;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD1F4", Offset = "0x7BD1F4")]
		[Token(Token = "0x4001803")]
		[FieldOffset(Offset = "0x68")]
		public Space space;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD22C", Offset = "0x7BD22C")]
		[Token(Token = "0x4001804")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat distance;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD264", Offset = "0x7BD264")]
		[Token(Token = "0x4001805")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt minDepth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD29C", Offset = "0x7BD29C")]
		[Token(Token = "0x4001806")]
		[FieldOffset(Offset = "0x80")]
		public FsmInt maxDepth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD2D4", Offset = "0x7BD2D4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BD2D4", Offset = "0x7BD2D4")]
		[Token(Token = "0x4001807")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool resetFlag;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BD324", Offset = "0x7BD324")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BD324", Offset = "0x7BD324")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD324", Offset = "0x7BD324")]
		[Token(Token = "0x4001808")]
		[FieldOffset(Offset = "0x90")]
		public FsmInt[] layerMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD398", Offset = "0x7BD398")]
		[Token(Token = "0x4001809")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool invertMask;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BD3D0", Offset = "0x7BD3D0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD3D0", Offset = "0x7BD3D0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BD3D0", Offset = "0x7BD3D0")]
		[Token(Token = "0x400180A")]
		[FieldOffset(Offset = "0xA0")]
		public FsmInt collidersCount;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BD444", Offset = "0x7BD444")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD444", Offset = "0x7BD444")]
		[Token(Token = "0x400180B")]
		[FieldOffset(Offset = "0xA8")]
		public FsmGameObject storeNextCollider;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BD494", Offset = "0x7BD494")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD494", Offset = "0x7BD494")]
		[Token(Token = "0x400180C")]
		[FieldOffset(Offset = "0xB0")]
		public FsmVector2 storeNextHitPoint;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BD4E4", Offset = "0x7BD4E4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD4E4", Offset = "0x7BD4E4")]
		[Token(Token = "0x400180D")]
		[FieldOffset(Offset = "0xB8")]
		public FsmVector2 storeNextHitNormal;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BD534", Offset = "0x7BD534")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD534", Offset = "0x7BD534")]
		[Token(Token = "0x400180E")]
		[FieldOffset(Offset = "0xC0")]
		public FsmFloat storeNextHitDistance;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BD584", Offset = "0x7BD584")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD584", Offset = "0x7BD584")]
		[Token(Token = "0x400180F")]
		[FieldOffset(Offset = "0xC8")]
		public FsmFloat storeNextHitFraction;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD5D4", Offset = "0x7BD5D4")]
		[Token(Token = "0x4001810")]
		[FieldOffset(Offset = "0xD0")]
		public FsmEvent loopEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BD60C", Offset = "0x7BD60C")]
		[Token(Token = "0x4001811")]
		[FieldOffset(Offset = "0xD8")]
		public FsmEvent finishedEvent;

		[Token(Token = "0x4001812")]
		[FieldOffset(Offset = "0xE0")]
		private RaycastHit2D[] hits;

		[Token(Token = "0x4001813")]
		[FieldOffset(Offset = "0xE8")]
		private int colliderCount;

		[Token(Token = "0x4001814")]
		[FieldOffset(Offset = "0xEC")]
		private int nextColliderIndex;

		[Token(Token = "0x6000DC6")]
		[Address(RVA = "0xA31CF8", Offset = "0xA31CF8", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F04938]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DF7]) = v42;\nL_0015:\n\tthis.fromGameObject = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.fromPosition = v46;\n\tv52 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.direction = v52;\n\tthis.space = 1;\n\tv62 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v62);\n\tv62.useVariable = 1;\n\tthis.minDepth = v62;\n\tv63 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v63);\n\tv63.useVariable = 1;\n\tthis.maxDepth = v63;\n\t// 69 NewArr v101 @ X0_v14 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v101;\n\tv85 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v85;\n\tthis.resetFlag = 0;\n\tthis.storeNextHitDistance = 0;\n\tthis.loopEvent = 0;\n\tthis.collidersCount = 0;\n\tthis.storeNextHitPoint = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			fromGameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			fromPosition = fsmVector;
			FsmVector2 fsmVector2 = new FsmVector2();
			fsmVector2.useVariable = true;
			direction = fsmVector2;
			space = Space.Self;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			minDepth = fsmInt;
			FsmInt fsmInt2 = new FsmInt();
			fsmInt2.useVariable = true;
			maxDepth = fsmInt2;
			FsmInt[] array = new FsmInt[0];
			layerMask = array;
			FsmBool fsmBool = false;
			invertMask = fsmBool;
			resetFlag = null;
			storeNextHitDistance = null;
			loopEvent = null;
			collidersCount = null;
			storeNextHitPoint = null;
		}

		[Token(Token = "0x6000DC7")]
		[Address(RVA = "0xA31E20", Offset = "0xA31E20", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.hits == 0;\n\tif (v11) goto L_0012;\n\tv18 = HutongGames.PlayMaker.FsmBool::get_Value(this.resetFlag);\n\tv20 = v18 == 0;\n\tif (v20) goto L_0022;\nL_0012:\n\tthis.nextColliderIndex = 0;\n\tv22 = HutongGames.PlayMaker.Actions.GetNextRayCast2d::GetRayCastAll(this);\n\tthis.hits = v22;\n\tv45 = this.collidersCount;\n\tthis.colliderCount = v22.Length;\n\tv45.value = v22.Length;\n\tv53 = this.resetFlag;\n\tv53.value = 0;\nL_0022:\n\tHutongGames.PlayMaker.Actions.GetNextRayCast2d::DoGetNextCollider(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (hits == null || resetFlag.Value)
			{
				nextColliderIndex = 0;
				RaycastHit2D[] array = (hits = GetRayCastAll());
				FsmInt fsmInt = collidersCount;
				colliderCount = array.Length;
				fsmInt.Value = array.Length;
				FsmBool fsmBool = resetFlag;
				fsmBool.value = false;
			}
			DoGetNextCollider();
			Finish();
		}

		[Token(Token = "0x6000DC8")]
		[Address(RVA = "0xA322A0", Offset = "0xA322A0", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv18 = *([1EA94E0]);\n\tv19 = *([v18 @ X8_v34]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DF8]) = v38;\nL_001F:\n\tv51 = this.nextColliderIndex >= this.colliderCount;\n\tif (v51) goto L_00ED;\n\tv52 = this.hits;\n\tv57 = this.nextColliderIndex < v52.Length;\n\tv58 = ~v57;\n\tif (v58) goto L_0110;\n\tv277 = this.nextColliderIndex * 0x24;\n\tv278 = v52 + v277;\n\tv280 = *([v278 @ X8_v8+20]);\n\tgoto L_004E;\n\tv296 = *([v283 @ X0_v11+E0]);\n\tv297 = v296 == 0;\n\tv298 = ~v297;\n\tif (v298) goto L_004E;\n\tv300 = \"il2cpp_codegen_runtime_class_init\"(v283, methodInfo, v22, v23, v24, v25, v26, v27, v280, v29, v30, v31, v32, v33, v34, v35);\nL_004E:\n\tHutongGames.PlayMaker.Fsm::RecordLastRaycastHit2DInfo(this.fsm, &v280 @ V0_v5 (System.Single));\n\tv181 = this.hits;\n\tv341 = this.nextColliderIndex < v181.Length;\n\tv141 = ~v341;\n\tif (v141) goto L_0110;\n\tv342 = this.nextColliderIndex * 0x24;\n\tv182 = v181 + v342;\n\tv343 = v182 + 0x20;\n\tv262 = 0x16415C8(v343, 0, 0, v23, v24, v25, v26, v27, v52[this.nextColliderIndex (System.Int32)].m_Normal, v280, v30, v31, v32, v33, v34, v35);\n\tv163 = UnityEngine.Component::get_gameObject(v262);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeNextCollider, v163);\n\tv183 = this.hits;\n\tv345 = this.nextColliderIndex < v183.Length;\n\tv142 = ~v345;\n\tif (v142) goto L_0110;\n\tv194 = this.storeNextHitPoint;\n\tv346 = this.nextColliderIndex * 0x24;\n\tv184 = v183 + v346;\n\tv347 = v184 + 0x20;\n\tv165 = 0x16415A8(v347, 0, 0, v23, v24, v25, v26, v27, v52[this.nextColliderIndex (System.Int32)].m_Normal, v280, v30, v31, v32, v33, v34, v35);\n\tv194.value = v52[this.nextColliderIndex (System.Int32)].m_Normal;\n\tv194.value.y = v280;\n\tv185 = this.hits;\n\tv348 = this.nextColliderIndex < v185.Length;\n\tv143 = ~v348;\n\tif (v143) goto L_0110;\n\tv195 = this.storeNextHitNormal;\n\tv349 = this.nextColliderIndex * 0x24;\n\tv186 = v185 + v349;\n\tv350 = v186 + 0x20;\n\tv166 = 0x16415B0(v350, 0, 0, v23, v24, v25, v26, v27, v52[this.nextColliderIndex (System.Int32)].m_Normal, v280, v30, v31, v32, v33, v34, v35);\n\tv195.value = v52[this.nextColliderIndex (System.Int32)].m_Normal;\n\tv195.value.y = v280;\n\tv187 = this.hits;\n\tv351 = this.nextColliderIndex < v187.Length;\n\tv144 = ~v351;\n\tif (v144) goto L_0110;\n\tv196 = this.storeNextHitDistance;\n\tv352 = this.nextColliderIndex * 0x24;\n\tv188 = v187 + v352;\n\tv353 = v188 + 0x20;\n\tv167 = 0x16415B8(v353, 0, 0, v23, v24, v25, v26, v27, v52[this.nextColliderIndex (System.Int32)].m_Normal, v280, v30, v31, v32, v33, v34, v35);\n\tv196.value = v52[this.nextColliderIndex (System.Int32)].m_Normal;\n\tv189 = this.hits;\n\tv354 = this.nextColliderIndex < v189.Length;\n\tv145 = ~v354;\n\tif (v145) goto L_0110;\n\tv197 = this.storeNextHitFraction;\n\tv355 = this.nextColliderIndex * 0x24;\n\tv190 = v189 + v355;\n\tv356 = v190 + 0x20;\n\tv168 = 0x16415C0(v356, 0, 0, v23, v24, v25, v26, v27, v52[this.nextColliderIndex (System.Int32)].m_Normal, v280, v30, v31, v32, v33, v34, v35);\n\tv197.value = v52[this.nextColliderIndex (System.Int32)].m_Normal;\n\tv207 = this.nextColliderIndex >= this.colliderCount;\n\tif (v207) goto L_00FE;\n\tv366 = this.loopEvent;\n\tv272 = this.nextColliderIndex + 1;\n\tthis.nextColliderIndex = v272;\n\tv359 = this.loopEvent == 0;\n\tif (v359) goto L_010D;\n\tv367 = this.fsm;\n\tv364 = this.fsm == 0;\n\tv268 = ~v364;\n\tif (v268) goto L_0107;\n\tgoto L_0114;\nL_00ED:\n\tthis.hits = 0;\n\tthis.nextColliderIndex = 0;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishedEvent);\n\treturn;\nL_00FE:\n\t// 254 NewArr v363 @ X0_v29 (UnityEngine.RaycastHit2D[]), typeof(UnityEngine.RaycastHit2D[]), 0\n\tv367 = this.fsm;\n\tthis.hits = v363;\n\tthis.nextColliderIndex = 0;\n\tv366 = this.finishedEvent;\nL_0107:\n\tHutongGames.PlayMaker.Fsm::Event(v367, v366);\nL_010D:\n\treturn;\n\tv199 = new System.NullReferenceException();\nL_0110:\n\tv295 = new System.IndexOutOfRangeException();\n\tthrow v295;\nL_0114:\n\tthrow System.NullReferenceException;\n// 177 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void DoGetNextCollider()
		{
			//IL_005d: Expected O, but got I
			//IL_006d: Expected F4, but got I
			//IL_0081: Expected O, but got Ref
			//IL_00d9: Expected O, but got I
			//IL_00e8: Expected O, but got I
			//IL_017f: Expected O, but got I
			//IL_018e: Expected O, but got I
			//IL_0233: Expected O, but got I
			//IL_0242: Expected O, but got I
			//IL_02e7: Expected O, but got I
			//IL_02f6: Expected O, but got I
			//IL_038e: Expected O, but got I
			//IL_039d: Expected O, but got I
			if (nextColliderIndex < colliderCount)
			{
				RaycastHit2D[] array = hits;
				if (nextColliderIndex < array.Length)
				{
					int num = nextColliderIndex * 36;
					object obj = (long)(IntPtr)array + (long)num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ X8_v8+20]");
					float y = 0f;
					Fsm.RecordLastRaycastHit2DInfo(Fsm, (RaycastHit2D)(&y));
					RaycastHit2D[] array2 = hits;
					if (nextColliderIndex < array2.Length)
					{
						int num2 = nextColliderIndex * 36;
						object obj2 = (long)(IntPtr)array2 + (long)num2;
						object obj3 = (long)(IntPtr)obj2 + 32L;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16415C8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0xA0)");
						Component component = default(Component);
						GameObject gameObject = component.gameObject;
						storeNextCollider.Value = gameObject;
						RaycastHit2D[] array3 = hits;
						if (nextColliderIndex < array3.Length)
						{
							FsmVector2 fsmVector = storeNextHitPoint;
							int num3 = nextColliderIndex * 36;
							object obj4 = (long)(IntPtr)array3 + (long)num3;
							object obj5 = (long)(IntPtr)obj4 + 32L;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16415A8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x80)");
							fsmVector.value = array[nextColliderIndex].m_Normal;
							fsmVector.value.y = y;
							RaycastHit2D[] array4 = hits;
							if (nextColliderIndex < array4.Length)
							{
								FsmVector2 fsmVector2 = storeNextHitNormal;
								int num4 = nextColliderIndex * 36;
								object obj6 = (long)(IntPtr)array4 + (long)num4;
								object obj7 = (long)(IntPtr)obj6 + 32L;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16415B0 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x88)");
								fsmVector2.value = array[nextColliderIndex].m_Normal;
								fsmVector2.value.y = y;
								RaycastHit2D[] array5 = hits;
								if (nextColliderIndex < array5.Length)
								{
									FsmFloat fsmFloat = storeNextHitDistance;
									int num5 = nextColliderIndex * 36;
									object obj8 = (long)(IntPtr)array5 + (long)num5;
									object obj9 = (long)(IntPtr)obj8 + 32L;
									Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16415B8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x90)");
									fsmFloat.Value = array[nextColliderIndex].m_Normal.x;
									RaycastHit2D[] array6 = hits;
									if (nextColliderIndex < array6.Length)
									{
										FsmFloat fsmFloat2 = storeNextHitFraction;
										int num6 = nextColliderIndex * 36;
										object obj10 = (long)(IntPtr)array6 + (long)num6;
										object obj11 = (long)(IntPtr)obj10 + 32L;
										Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16415C0 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x98)");
										fsmFloat2.Value = array[nextColliderIndex].m_Normal.x;
										FsmEvent fsmEvent;
										Fsm fsm;
										if (nextColliderIndex < colliderCount)
										{
											fsmEvent = loopEvent;
											int num7 = nextColliderIndex + 1;
											nextColliderIndex = num7;
											if (loopEvent == null)
											{
												return;
											}
											fsm = Fsm;
											if (Fsm == null)
											{
												throw new NullReferenceException();
											}
										}
										else
										{
											RaycastHit2D[] array7 = new RaycastHit2D[0];
											fsm = Fsm;
											hits = array7;
											nextColliderIndex = 0;
											fsmEvent = finishedEvent;
										}
										fsm.Event(fsmEvent);
										return;
									}
								}
							}
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			hits = null;
			nextColliderIndex = 0;
			Fsm.Event(finishedEvent);
		}

		[Token(Token = "0x6000DC9")]
		[Address(RVA = "0xA31EA8", Offset = "0xA31EA8", Length = "0x3F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv36 = *([1EDF100]);\n\tv37 = *([v36 @ X8_v38]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2021DF9]) = v56;\nL_0021:\n\tv61 = HutongGames.PlayMaker.FsmFloat::get_Value(this.distance);\n\tgoto L_0031;\n\tv299 = *([v219 @ X0_v8+E0]);\n\tv300 = v299 == 0;\n\tv301 = ~v300;\n\tif (v301) goto L_0031;\n\tv303 = \"il2cpp_codegen_runtime_class_init\"(v219, v60, v40, v41, v42, v43, v44, v45, v61, v47, v48, v49, v50, v51, v52, v53);\nL_0031:\n\tv156 = UnityEngine.Mathf::Abs(v61);\n\tgoto L_0048;\n\tv403 = *([v307 @ X0_v10 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv404 = v403 == 0;\n\tv405 = ~v404;\n\tif (v405) goto L_0048;\n\tv411 = \"il2cpp_codegen_runtime_class_init\"(v307, v60, v40, v41, v42, v43, v44, v45, v61, v47, v48, v49, v50, v51, v52, v53);\n\tv407 = UnityEngine.Mathf;\nL_0048:\n\tv85 = v156 >= v207.Epsilon;\n\tif (v85) goto L_0055;\n\t// 78 NewArr returnVal2 @ X0_v12 (UnityEngine.RaycastHit2D[]), typeof(UnityEngine.RaycastHit2D[]), 0\n\tgoto L_016E;\nL_0055:\n\tv277 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.fromGameObject);\n\tv291 = this.fromPosition;\n\tv158 = v291.value.y;\n\tgoto L_006B;\n\tv462 = *([v459 @ X0_v15+E0]);\n\tv463 = v462 == 0;\n\tv464 = ~v463;\n\tif (v464) goto L_006B;\n\tv466 = \"il2cpp_codegen_runtime_class_init\"(v459, v270, v264, v41, v42, v43, v44, v45, v160, v47, v48, v49, v50, v51, v52, v53);\nL_006B:\n\tv278 = UnityEngine.Object::op_Inequality(v277, 0);\n\tv470 = v278 == 0;\n\tif (v470) goto L_008A;\n\tv180 = UnityEngine.GameObject::get_transform(v277);\n\tv161 = UnityEngine.Transform::get_position(v180);\n\tv181 = UnityEngine.GameObject::get_transform(v277);\n\tv149 = v291.value + v161;\n\tv475 = UnityEngine.Transform::get_position(v181);\n\tv158 = v158 + v475.y;\nL_008A:\n\tv267 = HutongGames.PlayMaker.FsmFloat::get_Value(this.distance);\n\tv86 = v267 <= 0;\n\tif (v86) goto L_FFFFFFFF;\n\tv267 = HutongGames.PlayMaker.FsmFloat::get_Value(this.distance);\n\tgoto L_00A1;\nL_00A1:\n\tv294 = this.direction;\n\tv146 = v294.value;\n\tv493 = 0x1588F3C(&v146 @ X9_v5 (UnityEngine.Vector2), 0, 0, v41, v42, v43, v44, v45, v267, v475.y, v475.z, v49, v50, v51, v52, v53);\n\tgoto L_00BA;\n\tv498 = *([v494 @ X0_v24+E0]);\n\tv499 = v498 == 0;\n\tv500 = ~v499;\n\tif (v500) goto L_00BA;\n\tv502 = \"il2cpp_codegen_runtime_class_init\"(v494, v492, v153, v41, v42, v43, v44, v45, v267, v141, v137, v49, v50, v51, v52, v53);\nL_00BA:\n\tv279 = UnityEngine.Object::op_Inequality(v277, 0);\n\tv507 = v279 == 0;\n\tif (v507) goto L_00EC;\n\tv237 = this.space != 1;\n\tif (v237) goto L_00EC;\n\tv280 = UnityEngine.GameObject::get_transform(v277);\n\tv293 = this.direction;\n\tv227 = 0;\n\tv281 = 0x1586898(&v227 @ stack_-80_v5, 0, 0, v41, v42, v43, v44, v45, v293.value, v293.value.y, 0, v49, v50, v51, v52, v53);\n\t// 226 MakeStruct v509 @ AGGA320F4_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v534 @ stack_-7C, 0\n\tv514 = UnityEngine.Transform::TransformDirection(v280, v509);\nL_00EC:\n\tv519 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.minDepth);\n\tv522 = v519 == 0;\n\tif (v522) goto L_011F;\n\tv524 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxDepth);\n\tv526 = v524 == 0;\n\tif (v526) goto L_011F;\n\tv540 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv548 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v540);\n\tgoto L_0117;\n\tv557 = *([v456 @ X8_v27+E0]);\n\tv558 = v557 == 0;\n\tv559 = ~v558;\n\tif (v559) goto L_0117;\n\tv564 = v456;\n\tv561 = \"il2cpp_codegen_runtime_class_init\"(v564, v546, v442, v41, v42, v43, v44, v45, v163, v142, v138, v49, v50, v51, v52, v53);\nL_0117:\n\t// 279 MakeStruct v424 @ AGGA32190_0_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v149 @ V9_v6 (System.Single), v158 @ V8_v8 (System.Single)\n\t// 280 MakeStruct v423 @ AGGA32190_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v78 @ V11_v6 (System.Single), v76 @ V12_v6 (System.Single)\n\treturnVal2 = UnityEngine.Physics2D::RaycastAll(v424, v423, v134, v548);\n\tgoto L_016E;\nL_011F:\n\tv528 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.minDepth);\n\tv531 = v528 == 0;\n\tif (v531) goto L_012A;\n\tgoto L_0130;\nL_012A:\n\tv544 = HutongGames.PlayMaker.FsmInt::get_Value(this.minDepth);\nL_0130:\n\tv549 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxDepth);\n\tv556 = v549 == 0;\n\tif (v556) goto L_013A;\n\tgoto L_0141;\nL_013A:\n\tv568 = HutongGames.PlayMaker.FsmInt::get_Value(this.maxDepth);\nL_0141:\n\tv572 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv575 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v572);\n\tgoto L_015D;\n\tv581 = *([v455 @ X8_v23+E0]);\n\tv582 = v581 == 0;\n\tv583 = ~v582;\n\tif (v583) goto L_015D;\n\tv587 = v455;\n\tv585 = \"il2cpp_codegen_runtime_class_init\"(v587, v573, v441, v41, v42, v43, v44, v45, v163, v142, v138, v49, v50, v51, v52, v53);\nL_015D:\n\t// 349 MakeStruct v418 @ AGGA3226C_0_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v149 @ V9_v6 (System.Single), v158 @ V8_v8 (System.Single)\n\t// 350 MakeStruct v417 @ AGGA3226C_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v78 @ V11_v6 (System.Single), v76 @ V12_v6 (System.Single)\n\treturnVal2 = UnityEngine.Physics2D::RaycastAll(v418, v417, v134, v575, v65, v63);\nL_016E:\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 258 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private RaycastHit2D[] GetRayCastAll()
		{
			//IL_0243: Expected O, but got I4
			//IL_0272: Expected F4, but got O
			float value = distance.Value;
			float num = Mathf.Abs(value);
			if (num < Mathf.Epsilon)
			{
				return new RaycastHit2D[0];
			}
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(fromGameObject);
			FsmVector2 fsmVector = fromPosition;
			float num2 = fsmVector.value.y;
			bool flag = ownerDefaultTarget != null;
			bool flag2 = !flag;
			float x = fsmVector.value.x;
			Vector3 position2 = default(Vector3);
			if (!flag2)
			{
				Transform transform = ownerDefaultTarget.transform;
				Vector3 position = transform.position;
				Transform transform2 = ownerDefaultTarget.transform;
				x = fsmVector.value.x + position.x;
				position2 = transform2.position;
				num2 += position2.y;
			}
			float value2 = distance.Value;
			float num3;
			if (value2 > 0f)
			{
				value2 = distance.Value;
				num3 = value2;
			}
			else
			{
				num3 = float.PositiveInfinity;
			}
			FsmVector2 fsmVector2 = direction;
			Vector2 value3 = fsmVector2.value;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588F3C (inside UnityEngine.Vector2::get_zero +0x68)");
			bool flag3 = ownerDefaultTarget != null;
			bool flag4 = !flag3;
			float y = position2.y;
			float x2 = value2;
			if (!flag4)
			{
				bool flag5 = space != Space.Self;
				y = position2.y;
				x2 = value2;
				if (!flag5)
				{
					Transform transform3 = ownerDefaultTarget.transform;
					FsmVector2 fsmVector3 = direction;
					object obj = 0;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
					Vector3 vector = default(Vector3);
					vector.x = 0f;
					object obj2 = default(object);
					vector.y = (float)obj2;
					vector.z = 0f;
					Vector3 vector2 = transform3.TransformDirection(vector);
					y = vector2.y;
					x2 = vector2.x;
				}
			}
			if (minDepth.IsNone && maxDepth.IsNone)
			{
				bool value4 = invertMask.Value;
				int num4 = ActionHelpers.LayerArrayToLayerMask(layerMask, value4);
				Vector2 origin = default(Vector2);
				origin.x = x;
				origin.y = num2;
				Vector2 vector3 = default(Vector2);
				vector3.x = x2;
				vector3.y = y;
				return Physics2D.RaycastAll(origin, vector3, num3, num4);
			}
			float num5;
			if (minDepth.IsNone)
			{
				num5 = float.NegativeInfinity;
			}
			else
			{
				int value5 = minDepth.Value;
				num5 = value5;
			}
			float num6;
			if (maxDepth.IsNone)
			{
				num6 = float.PositiveInfinity;
			}
			else
			{
				int value6 = maxDepth.Value;
				num6 = value6;
			}
			bool value7 = invertMask.Value;
			int num7 = ActionHelpers.LayerArrayToLayerMask(layerMask, value7);
			Vector2 origin2 = default(Vector2);
			origin2.x = x;
			origin2.y = num2;
			Vector2 vector4 = default(Vector2);
			vector4.x = x2;
			vector4.y = y;
			return Physics2D.RaycastAll(origin2, vector4, num3, num7, num5, num6);
		}

		[Token(Token = "0x6000DCA")]
		[Address(RVA = "0xA32540", Offset = "0xA32540", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetNextRayCast2d()
		{
		}
	}
}
