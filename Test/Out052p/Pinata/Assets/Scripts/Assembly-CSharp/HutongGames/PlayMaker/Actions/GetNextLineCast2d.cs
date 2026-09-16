using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A6BC", Offset = "0x75A6BC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75A6BC", Offset = "0x75A6BC")]
	[Token(Token = "0x20002BC")]
	public class GetNextLineCast2d : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BC254", Offset = "0x7BC254")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC254", Offset = "0x7BC254")]
		[Token(Token = "0x40017C0")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault fromGameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC2B4", Offset = "0x7BC2B4")]
		[Token(Token = "0x40017C1")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 fromPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC2EC", Offset = "0x7BC2EC")]
		[Token(Token = "0x40017C2")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject toGameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC324", Offset = "0x7BC324")]
		[Token(Token = "0x40017C3")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector2 toPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC35C", Offset = "0x7BC35C")]
		[Token(Token = "0x40017C4")]
		[FieldOffset(Offset = "0x70")]
		public FsmInt minDepth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC394", Offset = "0x7BC394")]
		[Token(Token = "0x40017C5")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt maxDepth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC3CC", Offset = "0x7BC3CC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BC3CC", Offset = "0x7BC3CC")]
		[Token(Token = "0x40017C6")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool resetFlag;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BC41C", Offset = "0x7BC41C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BC41C", Offset = "0x7BC41C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC41C", Offset = "0x7BC41C")]
		[Token(Token = "0x40017C7")]
		[FieldOffset(Offset = "0x88")]
		public FsmInt[] layerMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC490", Offset = "0x7BC490")]
		[Token(Token = "0x40017C8")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool invertMask;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BC4C8", Offset = "0x7BC4C8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC4C8", Offset = "0x7BC4C8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BC4C8", Offset = "0x7BC4C8")]
		[Token(Token = "0x40017C9")]
		[FieldOffset(Offset = "0x98")]
		public FsmInt collidersCount;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BC53C", Offset = "0x7BC53C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC53C", Offset = "0x7BC53C")]
		[Token(Token = "0x40017CA")]
		[FieldOffset(Offset = "0xA0")]
		public FsmGameObject storeNextCollider;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC58C", Offset = "0x7BC58C")]
		[Token(Token = "0x40017CB")]
		[FieldOffset(Offset = "0xA8")]
		public FsmVector2 storeNextHitPoint;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC5C4", Offset = "0x7BC5C4")]
		[Token(Token = "0x40017CC")]
		[FieldOffset(Offset = "0xB0")]
		public FsmVector2 storeNextHitNormal;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC5FC", Offset = "0x7BC5FC")]
		[Token(Token = "0x40017CD")]
		[FieldOffset(Offset = "0xB8")]
		public FsmFloat storeNextHitDistance;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC634", Offset = "0x7BC634")]
		[Token(Token = "0x40017CE")]
		[FieldOffset(Offset = "0xC0")]
		public FsmEvent loopEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BC66C", Offset = "0x7BC66C")]
		[Token(Token = "0x40017CF")]
		[FieldOffset(Offset = "0xC8")]
		public FsmEvent finishedEvent;

		[Token(Token = "0x40017D0")]
		[FieldOffset(Offset = "0xD0")]
		private RaycastHit2D[] hits;

		[Token(Token = "0x40017D1")]
		[FieldOffset(Offset = "0xD8")]
		private int colliderCount;

		[Token(Token = "0x40017D2")]
		[FieldOffset(Offset = "0xDC")]
		private int nextColliderIndex;

		[Token(Token = "0x6000DB2")]
		[Address(RVA = "0xA30648", Offset = "0xA30648", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EDE208]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DEE]) = v42;\nL_0015:\n\tthis.fromGameObject = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.fromPosition = v46;\n\tthis.toGameObject = 0;\n\tv52 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.toPosition = v52;\n\tv62 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v62);\n\tv62.useVariable = 1;\n\tthis.minDepth = v62;\n\tv63 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v63);\n\tv63.useVariable = 1;\n\tthis.maxDepth = v63;\n\t// 69 NewArr v101 @ X0_v14 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v101;\n\tv85 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v85;\n\tthis.resetFlag = 0;\n\tthis.finishedEvent = 0;\n\tthis.storeNextHitDistance = 0;\n\tthis.storeNextHitPoint = 0;\n\tthis.collidersCount = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			fromGameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			fromPosition = fsmVector;
			toGameObject = null;
			FsmVector2 fsmVector2 = new FsmVector2();
			fsmVector2.useVariable = true;
			toPosition = fsmVector2;
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
			finishedEvent = null;
			storeNextHitDistance = null;
			storeNextHitPoint = null;
			collidersCount = null;
		}

		[Token(Token = "0x6000DB3")]
		[Address(RVA = "0xA30774", Offset = "0xA30774", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.hits == 0;\n\tif (v11) goto L_0012;\n\tv18 = HutongGames.PlayMaker.FsmBool::get_Value(this.resetFlag);\n\tv20 = v18 == 0;\n\tif (v20) goto L_0022;\nL_0012:\n\tthis.nextColliderIndex = 0;\n\tv22 = HutongGames.PlayMaker.Actions.GetNextLineCast2d::GetLineCastAll(this);\n\tthis.hits = v22;\n\tv45 = this.collidersCount;\n\tthis.colliderCount = v22.Length;\n\tv45.value = v22.Length;\n\tv53 = this.resetFlag;\n\tv53.value = 0;\nL_0022:\n\tHutongGames.PlayMaker.Actions.GetNextLineCast2d::DoGetNextCollider(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (hits == null || resetFlag.Value)
			{
				nextColliderIndex = 0;
				RaycastHit2D[] array = (hits = GetLineCastAll());
				FsmInt fsmInt = collidersCount;
				colliderCount = array.Length;
				fsmInt.Value = array.Length;
				FsmBool fsmBool = resetFlag;
				fsmBool.value = false;
			}
			DoGetNextCollider();
			Finish();
		}

		[Token(Token = "0x6000DB4")]
		[Address(RVA = "0xA30B0C", Offset = "0xA30B0C", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv18 = *([1EC6B28]);\n\tv19 = *([v18 @ X8_v32]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DEF]) = v38;\nL_001F:\n\tv51 = this.nextColliderIndex >= this.colliderCount;\n\tif (v51) goto L_00D4;\n\tv52 = this.hits;\n\tv57 = this.nextColliderIndex < v52.Length;\n\tv58 = ~v57;\n\tif (v58) goto L_00F7;\n\tv260 = this.nextColliderIndex * 0x24;\n\tv261 = v52 + v260;\n\tv263 = *([v261 @ X8_v8+20]);\n\tgoto L_004E;\n\tv278 = *([v266 @ X0_v11+E0]);\n\tv279 = v278 == 0;\n\tv280 = ~v279;\n\tif (v280) goto L_004E;\n\tv282 = \"il2cpp_codegen_runtime_class_init\"(v266, methodInfo, v22, v23, v24, v25, v26, v27, v263, v29, v30, v31, v32, v33, v34, v35);\nL_004E:\n\tHutongGames.PlayMaker.Fsm::RecordLastRaycastHit2DInfo(this.fsm, &v263 @ V0_v5 (System.Single));\n\tv167 = this.hits;\n\tv323 = this.nextColliderIndex < v167.Length;\n\tv133 = ~v323;\n\tif (v133) goto L_00F7;\n\tv324 = this.nextColliderIndex * 0x24;\n\tv168 = v167 + v324;\n\tv325 = v168 + 0x20;\n\tv245 = 0x16415C8(v325, 0, 0, v23, v24, v25, v26, v27, v52[this.nextColliderIndex (System.Int32)].m_Normal, v263, v30, v31, v32, v33, v34, v35);\n\tv152 = UnityEngine.Component::get_gameObject(v245);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeNextCollider, v152);\n\tv169 = this.hits;\n\tv327 = this.nextColliderIndex < v169.Length;\n\tv134 = ~v327;\n\tif (v134) goto L_00F7;\n\tv178 = this.storeNextHitPoint;\n\tv328 = this.nextColliderIndex * 0x24;\n\tv170 = v169 + v328;\n\tv329 = v170 + 0x20;\n\tv154 = 0x16415A8(v329, 0, 0, v23, v24, v25, v26, v27, v52[this.nextColliderIndex (System.Int32)].m_Normal, v263, v30, v31, v32, v33, v34, v35);\n\tv178.value = v52[this.nextColliderIndex (System.Int32)].m_Normal;\n\tv178.value.y = v263;\n\tv171 = this.hits;\n\tv330 = this.nextColliderIndex < v171.Length;\n\tv135 = ~v330;\n\tif (v135) goto L_00F7;\n\tv179 = this.storeNextHitNormal;\n\tv331 = this.nextColliderIndex * 0x24;\n\tv172 = v171 + v331;\n\tv332 = v172 + 0x20;\n\tv155 = 0x16415B0(v332, 0, 0, v23, v24, v25, v26, v27, v52[this.nextColliderIndex (System.Int32)].m_Normal, v263, v30, v31, v32, v33, v34, v35);\n\tv179.value = v52[this.nextColliderIndex (System.Int32)].m_Normal;\n\tv179.value.y = v263;\n\tv173 = this.hits;\n\tv333 = this.nextColliderIndex < v173.Length;\n\tv136 = ~v333;\n\tif (v136) goto L_00F7;\n\tv180 = this.storeNextHitDistance;\n\tv334 = this.nextColliderIndex * 0x24;\n\tv174 = v173 + v334;\n\tv335 = v174 + 0x20;\n\tv156 = 0x16415C0(v335, 0, 0, v23, v24, v25, v26, v27, v52[this.nextColliderIndex (System.Int32)].m_Normal, v263, v30, v31, v32, v33, v34, v35);\n\tv180.value = v52[this.nextColliderIndex (System.Int32)].m_Normal;\n\tv190 = this.nextColliderIndex >= this.colliderCount;\n\tif (v190) goto L_00E5;\n\tv345 = this.loopEvent;\n\tv255 = this.nextColliderIndex + 1;\n\tthis.nextColliderIndex = v255;\n\tv338 = this.loopEvent == 0;\n\tif (v338) goto L_00F4;\n\tv346 = this.fsm;\n\tv343 = this.fsm == 0;\n\tv251 = ~v343;\n\tif (v251) goto L_00EE;\n\tgoto L_00FB;\nL_00D4:\n\tthis.hits = 0;\n\tthis.nextColliderIndex = 0;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishedEvent);\n\treturn;\nL_00E5:\n\t// 229 NewArr v342 @ X0_v27 (UnityEngine.RaycastHit2D[]), typeof(UnityEngine.RaycastHit2D[]), 0\n\tv346 = this.fsm;\n\tthis.hits = v342;\n\tthis.nextColliderIndex = 0;\n\tv345 = this.finishedEvent;\nL_00EE:\n\tHutongGames.PlayMaker.Fsm::Event(v346, v345);\nL_00F4:\n\treturn;\n\tv182 = new System.NullReferenceException();\nL_00F7:\n\tv277 = new System.IndexOutOfRangeException();\n\tthrow v277;\nL_00FB:\n\tthrow System.NullReferenceException;\n// 162 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void DoGetNextCollider()
		{
			//IL_005d: Expected O, but got I
			//IL_006d: Expected F4, but got I
			//IL_0081: Expected O, but got Ref
			//IL_00d9: Expected O, but got I
			//IL_00e8: Expected O, but got I
			//IL_017a: Expected O, but got I
			//IL_0189: Expected O, but got I
			//IL_0229: Expected O, but got I
			//IL_0238: Expected O, but got I
			//IL_02d8: Expected O, but got I
			//IL_02e7: Expected O, but got I
			if (nextColliderIndex < colliderCount)
			{
				RaycastHit2D[] array = hits;
				if (nextColliderIndex < array.Length)
				{
					int num = nextColliderIndex * 36;
					object obj = (long)(IntPtr)array + (long)num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ X8_v8+20]");
					float y = 0f;
					Fsm.RecordLastRaycastHit2DInfo(Fsm, (RaycastHit2D)(&y));
					RaycastHit2D[] array2 = hits;
					if (nextColliderIndex < array2.Length)
					{
						int num2 = nextColliderIndex * 36;
						object obj2 = (long)(IntPtr)array2 + (long)num2;
						object obj3 = (long)(IntPtr)obj2 + 32L;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415C8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0xA0)");
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
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415A8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x80)");
							fsmVector.value = array[nextColliderIndex].m_Normal;
							fsmVector.value.y = y;
							RaycastHit2D[] array4 = hits;
							if (nextColliderIndex < array4.Length)
							{
								FsmVector2 fsmVector2 = storeNextHitNormal;
								int num4 = nextColliderIndex * 36;
								object obj6 = (long)(IntPtr)array4 + (long)num4;
								object obj7 = (long)(IntPtr)obj6 + 32L;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415B0 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x88)");
								fsmVector2.value = array[nextColliderIndex].m_Normal;
								fsmVector2.value.y = y;
								RaycastHit2D[] array5 = hits;
								if (nextColliderIndex < array5.Length)
								{
									FsmFloat fsmFloat = storeNextHitDistance;
									int num5 = nextColliderIndex * 36;
									object obj8 = (long)(IntPtr)array5 + (long)num5;
									object obj9 = (long)(IntPtr)obj8 + 32L;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415C0 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x98)");
									fsmFloat.Value = array[nextColliderIndex].m_Normal.x;
									FsmEvent fsmEvent;
									Fsm fsm;
									if (nextColliderIndex < colliderCount)
									{
										fsmEvent = loopEvent;
										int num6 = nextColliderIndex + 1;
										nextColliderIndex = num6;
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
										RaycastHit2D[] array6 = new RaycastHit2D[0];
										fsm = Fsm;
										hits = array6;
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
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			hits = null;
			nextColliderIndex = 0;
			Fsm.Event(finishedEvent);
		}

		[Token(Token = "0x6000DB5")]
		[Address(RVA = "0xA307FC", Offset = "0xA307FC", Length = "0x310")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1EC6910]);\n\tv33 = *([v32 @ X8_v21]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021DF0]) = v52;\nL_001A:\n\tv53 = this.fromPosition;\n\tv79 = v53.value.y;\n\tv105 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.fromGameObject);\n\tgoto L_0036;\n\tv184 = *([v96 @ X8_v6+E0]);\n\tv185 = v184 == 0;\n\tv186 = ~v185;\n\tif (v186) goto L_0036;\n\tv270 = v96;\n\tv188 = \"il2cpp_codegen_runtime_class_init\"(v270, v103, v104, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0036:\n\tv88 = UnityEngine.Object::op_Inequality(v105, 0);\n\tv272 = v88 == 0;\n\tif (v272) goto L_0051;\n\tv148 = UnityEngine.GameObject::get_transform(v105);\n\tv126 = UnityEngine.Transform::get_position(v148);\n\tv149 = UnityEngine.GameObject::get_transform(v105);\n\tv82 = v53.value + v126;\n\tv275 = UnityEngine.Transform::get_position(v149);\n\tv79 = v79 + v275.y;\nL_0051:\n\tv98 = this.toPosition;\n\tv116 = v98.value.y;\n\tv282 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tgoto L_006A;\n\tv288 = *([v97 @ X8_v8+E0]);\n\tv289 = v288 == 0;\n\tv290 = ~v289;\n\tif (v290) goto L_006A;\n\tv295 = v97;\n\tv292 = \"il2cpp_codegen_runtime_class_init\"(v295, v281, v75, v37, v38, v39, v40, v41, v67, v65, v63, v45, v46, v47, v48, v49);\nL_006A:\n\tv89 = UnityEngine.Object::op_Inequality(v282, 0);\n\tv297 = v89 == 0;\n\tif (v297) goto L_0089;\n\tv151 = UnityEngine.GameObject::get_transform(v282);\n\tv127 = UnityEngine.Transform::get_position(v151);\n\tv152 = UnityEngine.GameObject::get_transform(v282);\n\tv113 = v98.value + v127;\n\tv302 = UnityEngine.Transform::get_position(v152);\n\tv116 = v116 + v302.y;\nL_0089:\n\tv307 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.minDepth);\n\tv309 = v307 == 0;\n\tif (v309) goto L_00C7;\n\tv312 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxDepth);\n\tv314 = v312 == 0;\n\tif (v314) goto L_00C7;\n\tv324 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv332 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v324);\n\tgoto L_00BF;\n\tv342 = *([v262 @ X8_v18+E0]);\n\tv343 = v342 == 0;\n\tv344 = ~v343;\n\tif (v344) goto L_00BF;\n\tv350 = v262;\n\tv346 = \"il2cpp_codegen_runtime_class_init\"(v350, v330, v241, v37, v38, v39, v40, v41, v128, v124, v120, v45, v46, v47, v48, v49);\nL_00BF:\n\t// 191 MakeStruct v205 @ AGGA30A10_0_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v82 @ V9_v4 (System.Single), v79 @ V8_v4 (System.Single)\n\t// 192 MakeStruct v202 @ AGGA30A10_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v113 @ V11_v4 (System.Single), v116 @ V10_v5 (System.Single)\n\treturnVal2 = UnityEngine.Physics2D::LinecastAll(v205, v202, v332);\n\treturn returnVal2;\nL_00C7:\n\tv316 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.minDepth);\n\tv319 = v316 == 0;\n\tif (v319) goto L_00D2;\n\tgoto L_00D8;\nL_00D2:\n\tv328 = HutongGames.PlayMaker.FsmInt::get_Value(this.minDepth);\nL_00D8:\n\tv333 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxDepth);\n\tv341 = v333 == 0;\n\tif (v341) goto L_00E3;\n\tgoto L_00EA;\nL_00E3:\n\tv354 = HutongGames.PlayMaker.FsmInt::get_Value(this.maxDepth);\nL_00EA:\n\tv358 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv361 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v358);\n\tgoto L_0111;\n\tv368 = *([v263 @ X8_v13+E0]);\n\tv369 = v368 == 0;\n\tv370 = ~v369;\n\tif (v370) goto L_0111;\n\tv374 = v263;\n\tv372 = \"il2cpp_codegen_runtime_class_init\"(v374, v359, v242, v37, v38, v39, v40, v41, v128, v124, v120, v45, v46, v47, v48, v49);\nL_0111:\n\t// 273 MakeStruct v196 @ AGGA30B00_0_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v82 @ V9_v4 (System.Single), v79 @ V8_v4 (System.Single)\n\t// 274 MakeStruct v193 @ AGGA30B00_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v113 @ V11_v4 (System.Single), v116 @ V10_v5 (System.Single)\n\treturnVal3 = UnityEngine.Physics2D::LinecastAll(v196, v193, v361, v111, v107);\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 192 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private RaycastHit2D[] GetLineCastAll()
		{
			FsmVector2 fsmVector = fromPosition;
			float num = fsmVector.value.y;
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(fromGameObject);
			bool flag = ownerDefaultTarget != null;
			bool flag2 = !flag;
			float x = fsmVector.value.x;
			if (!flag2)
			{
				Transform transform = ownerDefaultTarget.transform;
				Vector3 position = transform.position;
				Transform transform2 = ownerDefaultTarget.transform;
				x = fsmVector.value.x + position.x;
				num += transform2.position.y;
			}
			FsmVector2 fsmVector2 = toPosition;
			float num2 = fsmVector2.value.y;
			GameObject value = toGameObject.Value;
			bool flag3 = value != null;
			bool flag4 = !flag3;
			float x2 = fsmVector2.value.x;
			if (!flag4)
			{
				Transform transform3 = value.transform;
				Vector3 position2 = transform3.position;
				Transform transform4 = value.transform;
				x2 = fsmVector2.value.x + position2.x;
				num2 += transform4.position.y;
			}
			if (minDepth.IsNone && maxDepth.IsNone)
			{
				bool value2 = invertMask.Value;
				int num3 = ActionHelpers.LayerArrayToLayerMask(layerMask, value2);
				Vector2 start = default(Vector2);
				start.x = x;
				start.y = num;
				Vector2 end = default(Vector2);
				end.x = x2;
				end.y = num2;
				return Physics2D.LinecastAll(start, end, num3);
			}
			float num4;
			if (minDepth.IsNone)
			{
				num4 = float.NegativeInfinity;
			}
			else
			{
				int value3 = minDepth.Value;
				num4 = value3;
			}
			float num5;
			if (maxDepth.IsNone)
			{
				num5 = float.PositiveInfinity;
			}
			else
			{
				int value4 = maxDepth.Value;
				num5 = value4;
			}
			bool value5 = invertMask.Value;
			int num6 = ActionHelpers.LayerArrayToLayerMask(layerMask, value5);
			Vector2 start2 = default(Vector2);
			start2.x = x;
			start2.y = num;
			Vector2 end2 = default(Vector2);
			end2.x = x2;
			end2.y = num2;
			return Physics2D.LinecastAll(start2, end2, num6, num4, num5);
		}

		[Token(Token = "0x6000DB6")]
		[Address(RVA = "0xA30D74", Offset = "0xA30D74", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetNextLineCast2d()
		{
		}
	}
}
