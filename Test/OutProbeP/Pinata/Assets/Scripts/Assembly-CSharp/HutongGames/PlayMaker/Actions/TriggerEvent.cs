using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A34C", Offset = "0x75A34C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75A34C", Offset = "0x75A34C")]
	[Token(Token = "0x20002B1")]
	public class TriggerEvent : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BB438", Offset = "0x7BB438")]
		[Token(Token = "0x400178E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BB470", Offset = "0x7BB470")]
		[Token(Token = "0x400178F")]
		[FieldOffset(Offset = "0x58")]
		public TriggerType trigger;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BB4A8", Offset = "0x7BB4A8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BB4A8", Offset = "0x7BB4A8")]
		[Token(Token = "0x4001790")]
		[FieldOffset(Offset = "0x60")]
		public FsmString collideTag;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BB4F8", Offset = "0x7BB4F8")]
		[Token(Token = "0x4001791")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent sendEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BB530", Offset = "0x7BB530")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BB530", Offset = "0x7BB530")]
		[Token(Token = "0x4001792")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject storeCollider;

		[Token(Token = "0x4001793")]
		[FieldOffset(Offset = "0x78")]
		private PlayMakerProxyBase cachedProxy;

		[Token(Token = "0x6000D63")]
		[Address(RVA = "0x9A1D9C", Offset = "0x9A1D9C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDEF90]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217D9]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tthis.trigger = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.sendEvent = 0;\n\tthis.storeCollider = 0;\n\tthis.collideTag = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			trigger = default(TriggerType);
			FsmString fsmString = "";
			sendEvent = null;
			storeCollider = null;
			collideTag = fsmString;
		}

		[Token(Token = "0x6000D64")]
		[Address(RVA = "0x9A1E00", Offset = "0x9A1E00", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF52A0]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217DA]) = v38;\nL_0013:\n\tv52 = this.gameObject;\n\tv40 = this.gameObject == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0022;\n\tv45 = new HutongGames.PlayMaker.FsmOwnerDefault();\n\tHutongGames.PlayMaker.FsmOwnerDefault::.ctor(v45);\n\tthis.gameObject = v45;\nL_0022:\n\tv55 = v52.ownerOption == 0;\n\tif (v55) goto L_0031;\n\tHutongGames.PlayMaker.Actions.TriggerEvent::GetProxyComponent(this);\n\treturn;\nL_0031:\n\tv66 = this.trigger == 2;\n\tif (v66) goto L_005A;\n\tv75 = this.trigger == 1;\n\tif (v75) goto L_0066;\n\tv148 = this.trigger == 0;\n\tv128 = ~v148;\n\tif (v128) goto L_006D;\n\tHutongGames.PlayMaker.Fsm::set_HandleTriggerEnter(this.fsm, 1);\n\treturn;\nL_005A:\n\tHutongGames.PlayMaker.Fsm::set_HandleTriggerExit(this.fsm, 1);\n\treturn;\nL_0066:\n\tHutongGames.PlayMaker.Fsm::set_HandleTriggerStay(this.fsm, 1);\n\treturn;\nL_006D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (gameObject == null)
			{
				fsmOwnerDefault = (gameObject = new FsmOwnerDefault());
			}
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GetProxyComponent();
			}
			else if (trigger != TriggerType.OnTriggerExit)
			{
				if (trigger != TriggerType.OnTriggerStay)
				{
					if (trigger == TriggerType.OnTriggerEnter)
					{
						Fsm.HandleTriggerEnter = true;
					}
				}
				else
				{
					Fsm.HandleTriggerStay = true;
				}
			}
			else
			{
				Fsm.HandleTriggerExit = true;
			}
		}

		[Token(Token = "0x6000D65")]
		[Address(RVA = "0x9A2040", Offset = "0x9A2040", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EB4B28]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20217DB]) = v40;\nL_0014:\n\tv41 = this.gameObject;\n\tv44 = v41.ownerOption == 0;\n\tif (v44) goto L_0054;\n\tgoto L_002A;\n\tv80 = *([v71 @ X0_v5+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_002A;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v71, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002A:\n\tv88 = UnityEngine.Object::op_Equality(this.cachedProxy, 0);\n\tv109 = v88 == 0;\n\tif (v109) goto L_0031;\n\tHutongGames.PlayMaker.Actions.TriggerEvent::GetProxyComponent(this);\nL_0031:\n\tHutongGames.PlayMaker.Actions.TriggerEvent::AddCallback(this);\n\tv62 = this.gameObject;\n\tv57 = new System.Action();\n\tSystem.Action::.ctor(v57, this, Il2CppMethodInfo);\n\tHutongGames.PlayMaker.FsmGameObject::add_OnChange(v62.gameObject, v57);\n\treturn;\nL_0054:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				if (cachedProxy == null)
				{
					GetProxyComponent();
				}
				AddCallback();
				FsmOwnerDefault fsmOwnerDefault2 = gameObject;
				Action value = UpdateCallback;
				fsmOwnerDefault2.GameObject.OnChange += value;
			}
		}

		[Token(Token = "0x6000D66")]
		[Address(RVA = "0x9A2270", Offset = "0x9A2270", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EBBA20]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20217DC]) = v40;\nL_0014:\n\tv41 = this.gameObject;\n\tv44 = v41.ownerOption == 0;\n\tif (v44) goto L_003E;\n\tHutongGames.PlayMaker.Actions.TriggerEvent::RemoveCallback(this);\n\tv60 = this.gameObject;\n\tv55 = new System.Action();\n\tSystem.Action::.ctor(v55, this, Il2CppMethodInfo);\n\tHutongGames.PlayMaker.FsmGameObject::remove_OnChange(v60.gameObject, v55);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				RemoveCallback();
				FsmOwnerDefault fsmOwnerDefault2 = gameObject;
				Action value = UpdateCallback;
				fsmOwnerDefault2.GameObject.OnChange -= value;
			}
		}

		[Token(Token = "0x6000D67")]
		[Address(RVA = "0x9A2460", Offset = "0x9A2460", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.TriggerEvent::RemoveCallback(this);\n\tHutongGames.PlayMaker.Actions.TriggerEvent::GetProxyComponent(this);\n\tHutongGames.PlayMaker.Actions.TriggerEvent::AddCallback(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateCallback()
		{
			RemoveCallback();
			GetProxyComponent();
			AddCallback();
		}

		[Token(Token = "0x6000D68")]
		[Address(RVA = "0x9A1EF8", Offset = "0x9A1EF8", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F03750]);\n\tv19 = *([v18 @ X8_v33]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217DD]) = v38;\nL_0013:\n\tv39 = this.gameObject;\n\tthis.cachedProxy = 0;\n\tv45 = HutongGames.PlayMaker.FsmGameObject::get_Value(v39.gameObject);\n\tgoto L_002D;\n\tv56 = *([v52 @ X8_v6+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_002D;\n\tv110 = v52;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v110, v44, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tv66 = UnityEngine.Object::op_Equality(v45, 0);\n\tv112 = v66 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_007F;\n\tv119 = this.trigger == 2;\n\tif (v119) goto L_005F;\n\tv133 = this.trigger == 1;\n\tif (v133) goto L_006E;\n\tv152 = this.trigger == 0;\n\tv143 = ~v152;\n\tif (v143) goto L_007F;\n\tgoto L_FFFFFFFF;\n\tv188 = *([v170 @ X0_v20+E0]);\n\tv189 = v188 == 0;\n\tv190 = ~v189;\n\tif (v190) goto L_FFFFFFFF;\n\tv191 = \"il2cpp_codegen_runtime_class_init\"(v170, v64, v65, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0078;\nL_005F:\n\tgoto L_FFFFFFFF;\n\tv159 = *([v148 @ X0_v14+E0]);\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_FFFFFFFF;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v148, v64, v65, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0078;\nL_006E:\n\tgoto L_FFFFFFFF;\n\tv174 = *([v155 @ X0_v17+E0]);\n\tv175 = v174 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_FFFFFFFF;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v155, v64, v65, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0078:\n\tv141 = PlayMakerFSM::GetEventHandlerComponent /* +15 sharing this address */(v45, *([v144 @ X8_v9 (Il2CppMethodInfo)]));\n\tthis.cachedProxy = v141;\nL_007F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void GetProxyComponent()
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			cachedProxy = null;
			GameObject value = fsmOwnerDefault.GameObject.Value;
			if (value == null)
			{
				return;
			}
			if (trigger != TriggerType.OnTriggerExit)
			{
				if (trigger != TriggerType.OnTriggerStay)
				{
					if (trigger != TriggerType.OnTriggerEnter)
					{
						return;
					}
					IntPtr intPtr = (IntPtr)0;
				}
				else
				{
					IntPtr intPtr = (IntPtr)0;
				}
			}
			else
			{
				IntPtr intPtr = (IntPtr)0;
			}
			Il2CppRuntime.Boundary("MANAGED", "Method not found @B89164 (PlayMakerFSM::GetEventHandlerComponent, and 15 more at this address)");
			PlayMakerProxyBase playMakerProxyBase = default(PlayMakerProxyBase);
			cachedProxy = playMakerProxyBase;
		}

		[Token(Token = "0x6000D69")]
		[Address(RVA = "0x9A2140", Offset = "0x9A2140", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1F034E8]);\n\tv21 = *([v20 @ X8_v25]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20217DE]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this.cachedProxy, 0);\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_004F;\n\tv67 = this.trigger == 2;\n\tif (v67) goto L_0051;\n\tv86 = this.trigger == 1;\n\tif (v86) goto L_0059;\n\tv153 = this.trigger == 0;\n\tv97 = ~v153;\n\tif (v97) goto L_004F;\n\tv150 = this.cachedProxy;\n\tv168 = new PlayMakerProxyBase+TriggerEvent();\n\tgoto L_0063;\nL_004F:\n\treturn;\nL_0051:\n\tv150 = this.cachedProxy;\n\tv168 = new PlayMakerProxyBase+TriggerEvent();\n\tgoto L_0063;\nL_0059:\n\tv150 = this.cachedProxy;\n\tv168 = new PlayMakerProxyBase+TriggerEvent();\nL_0063:\n\tPlayMakerProxyBase+TriggerEvent::.ctor(v168, this, *([v147 @ X8_v9 (Il2CppMethodInfo)]));\n\tPlayMakerProxyBase::AddTriggerEventCallback(v150, v168);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddCallback()
		{
			if (cachedProxy == null)
			{
				return;
			}
			PlayMakerProxyBase playMakerProxyBase;
			PlayMakerProxyBase.TriggerEvent triggerEvent;
			if (trigger != TriggerType.OnTriggerExit)
			{
				if (trigger != TriggerType.OnTriggerStay)
				{
					if (trigger != TriggerType.OnTriggerEnter)
					{
						return;
					}
					playMakerProxyBase = cachedProxy;
					triggerEvent = null;
					IntPtr intPtr = (IntPtr)0;
				}
				else
				{
					playMakerProxyBase = cachedProxy;
					triggerEvent = null;
					IntPtr intPtr = (IntPtr)0;
				}
			}
			else
			{
				playMakerProxyBase = cachedProxy;
				Cpp2ILHelpers.NoteDecompilerIssue("Delegate over an unresolved function pointer: TriggerEvent");
				triggerEvent = null;
				IntPtr intPtr = (IntPtr)0;
			}
			playMakerProxyBase.AddTriggerEventCallback(triggerEvent);
		}

		[Token(Token = "0x6000D6A")]
		[Address(RVA = "0x9A2330", Offset = "0x9A2330", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1F0DED0]);\n\tv21 = *([v20 @ X8_v25]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20217DF]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this.cachedProxy, 0);\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_004F;\n\tv67 = this.trigger == 2;\n\tif (v67) goto L_0051;\n\tv86 = this.trigger == 1;\n\tif (v86) goto L_0059;\n\tv153 = this.trigger == 0;\n\tv97 = ~v153;\n\tif (v97) goto L_004F;\n\tv150 = this.cachedProxy;\n\tv168 = new PlayMakerProxyBase+TriggerEvent();\n\tgoto L_0063;\nL_004F:\n\treturn;\nL_0051:\n\tv150 = this.cachedProxy;\n\tv168 = new PlayMakerProxyBase+TriggerEvent();\n\tgoto L_0063;\nL_0059:\n\tv150 = this.cachedProxy;\n\tv168 = new PlayMakerProxyBase+TriggerEvent();\nL_0063:\n\tPlayMakerProxyBase+TriggerEvent::.ctor(v168, this, *([v147 @ X8_v9 (Il2CppMethodInfo)]));\n\tPlayMakerProxyBase::RemoveTriggerEventCallback(v150, v168);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RemoveCallback()
		{
			if (cachedProxy == null)
			{
				return;
			}
			PlayMakerProxyBase playMakerProxyBase;
			PlayMakerProxyBase.TriggerEvent triggerEvent;
			if (trigger != TriggerType.OnTriggerExit)
			{
				if (trigger != TriggerType.OnTriggerStay)
				{
					if (trigger != TriggerType.OnTriggerEnter)
					{
						return;
					}
					playMakerProxyBase = cachedProxy;
					triggerEvent = null;
					IntPtr intPtr = (IntPtr)0;
				}
				else
				{
					playMakerProxyBase = cachedProxy;
					triggerEvent = null;
					IntPtr intPtr = (IntPtr)0;
				}
			}
			else
			{
				playMakerProxyBase = cachedProxy;
				Cpp2ILHelpers.NoteDecompilerIssue("Delegate over an unresolved function pointer: TriggerEvent");
				triggerEvent = null;
				IntPtr intPtr = (IntPtr)0;
			}
			playMakerProxyBase.RemoveTriggerEventCallback(triggerEvent);
		}

		[Token(Token = "0x6000D6B")]
		[Address(RVA = "0x9A248C", Offset = "0x9A248C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = UnityEngine.Component::get_gameObject(collisionInfo);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeCollider, v14);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StoreCollisionInfo(Collider collisionInfo)
		{
			GameObject value = collisionInfo.gameObject;
			storeCollider.Value = value;
		}

		[Token(Token = "0x6000D6C")]
		[Address(RVA = "0x9A24D0", Offset = "0x9A24D0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.gameObject;\n\tv4 = v0.ownerOption == 0;\n\tif (v4) goto L_0007;\n\treturn;\nL_0007:\n\tHutongGames.PlayMaker.Actions.TriggerEvent::TriggerEnter(this, other);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoTriggerEnter(Collider other)
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption == OwnerDefaultOption.UseOwner)
			{
				TriggerEnter(other);
			}
		}

		[Token(Token = "0x6000D6D")]
		[Address(RVA = "0x9A2560", Offset = "0x9A2560", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.gameObject;\n\tv4 = v0.ownerOption == 0;\n\tif (v4) goto L_0007;\n\treturn;\nL_0007:\n\tHutongGames.PlayMaker.Actions.TriggerEvent::TriggerStay(this, other);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoTriggerStay(Collider other)
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption == OwnerDefaultOption.UseOwner)
			{
				TriggerStay(other);
			}
		}

		[Token(Token = "0x6000D6E")]
		[Address(RVA = "0x9A25F4", Offset = "0x9A25F4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.gameObject;\n\tv4 = v0.ownerOption == 0;\n\tif (v4) goto L_0007;\n\treturn;\nL_0007:\n\tHutongGames.PlayMaker.Actions.TriggerEvent::TriggerExit(this, other);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoTriggerExit(Collider other)
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			if (fsmOwnerDefault.OwnerOption == OwnerDefaultOption.UseOwner)
			{
				TriggerExit(other);
			}
		}

		[Token(Token = "0x6000D6F")]
		[Address(RVA = "0x9A24F8", Offset = "0x9A24F8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = this.trigger == 0;\n\tv16 = ~v15;\n\tif (v16) goto L_0027;\n\tv20 = HutongGames.PlayMaker.FsmStateAction::TagMatches(this.collideTag, other);\n\tv26 = v20 == 0;\n\tif (v26) goto L_0027;\n\tHutongGames.PlayMaker.Actions.TriggerEvent::StoreCollisionInfo(this, other);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\treturn;\nL_0027:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void TriggerEnter(Collider other)
		{
			if (trigger == TriggerType.OnTriggerEnter && FsmStateAction.TagMatches(collideTag, other))
			{
				StoreCollisionInfo(other);
				Fsm.Event(sendEvent);
			}
		}

		[Token(Token = "0x6000D70")]
		[Address(RVA = "0x9A2588", Offset = "0x9A2588", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = this.trigger != 1;\n\tif (v24) goto L_002F;\n\tv28 = HutongGames.PlayMaker.FsmStateAction::TagMatches(this.collideTag, other);\n\tv31 = v28 == 0;\n\tif (v31) goto L_002F;\n\tHutongGames.PlayMaker.Actions.TriggerEvent::StoreCollisionInfo(this, other);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\treturn;\nL_002F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void TriggerStay(Collider other)
		{
			if (trigger == TriggerType.OnTriggerStay && FsmStateAction.TagMatches(collideTag, other))
			{
				StoreCollisionInfo(other);
				Fsm.Event(sendEvent);
			}
		}

		[Token(Token = "0x6000D71")]
		[Address(RVA = "0x9A261C", Offset = "0x9A261C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = this.trigger != 2;\n\tif (v24) goto L_002F;\n\tv28 = HutongGames.PlayMaker.FsmStateAction::TagMatches(this.collideTag, other);\n\tv31 = v28 == 0;\n\tif (v31) goto L_002F;\n\tHutongGames.PlayMaker.Actions.TriggerEvent::StoreCollisionInfo(this, other);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\n\treturn;\nL_002F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void TriggerExit(Collider other)
		{
			if (trigger == TriggerType.OnTriggerExit && FsmStateAction.TagMatches(collideTag, other))
			{
				StoreCollisionInfo(other);
				Fsm.Event(sendEvent);
			}
		}

		[Token(Token = "0x6000D72")]
		[Address(RVA = "0x9A2688", Offset = "0x9A2688", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\treturnVal2 = HutongGames.PlayMaker.ActionHelpers::CheckPhysicsSetup(v12);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			return ActionHelpers.CheckPhysicsSetup(ownerDefaultTarget);
		}

		[Token(Token = "0x6000D73")]
		[Address(RVA = "0x9A26B8", Offset = "0x9A26B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TriggerEvent()
		{
		}
	}
}
