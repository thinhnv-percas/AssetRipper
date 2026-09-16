using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753AF4", Offset = "0x753AF4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x753AF4", Offset = "0x753AF4")]
	[Token(Token = "0x2000175")]
	public class ArrayForEach : RunFSMAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A9794", Offset = "0x7A9794")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9794", Offset = "0x7A9794")]
		[Token(Token = "0x400124F")]
		[FieldOffset(Offset = "0x58")]
		public FsmArray array;

		[HideTypeFilter]
		[AttributeAttribute(Type = typeof(MatchElementTypeAttribute), RVA = "0x7A97F4", Offset = "0x7A97F4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A97F4", Offset = "0x7A97F4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A97F4", Offset = "0x7A97F4")]
		[Token(Token = "0x4001250")]
		[FieldOffset(Offset = "0x60")]
		public FsmVar storeItem;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A9878", Offset = "0x7A9878")]
		[Token(Token = "0x4001251")]
		[FieldOffset(Offset = "0x68")]
		public FsmTemplateControl fsmTemplateControl;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A98B0", Offset = "0x7A98B0")]
		[Token(Token = "0x4001252")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent finishEvent;

		[Token(Token = "0x4001253")]
		[FieldOffset(Offset = "0x78")]
		private int currentIndex;

		[Token(Token = "0x600081C")]
		[Address(RVA = "0xA89124", Offset = "0xA89124", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFD968]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221B3]) = v38;\nL_0013:\n\tthis.array = 0;\n\tv42 = new HutongGames.PlayMaker.FsmTemplateControl();\n\tHutongGames.PlayMaker.FsmTemplateControl::.ctor(v42);\n\tthis.fsmTemplateControl = v42;\n\tthis.runFsm = 0;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			array = null;
			FsmTemplateControl fsmTemplateControl = new FsmTemplateControl();
			this.fsmTemplateControl = fsmTemplateControl;
			runFsm = null;
		}

		[Token(Token = "0x600081D")]
		[Address(RVA = "0xA8918C", Offset = "0xA8918C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EDA1D0]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221B4]) = v38;\nL_0014:\n\tv40 = this.array == 0;\n\tif (v40) goto L_003E;\n\tv41 = this.fsmTemplateControl;\n\tgoto L_0029;\n\tv91 = *([v70 @ X0_v6+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_0029;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v70, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0029:\n\tv54 = UnityEngine.Object::op_Inequality(v41.fsmTemplate, 0);\n\tv58 = v54 == 0;\n\tif (v58) goto L_003E;\n\tv55 = UnityEngine.Application::get_isPlaying();\n\tv59 = v55 == 0;\n\tif (v59) goto L_003E;\n\tv53 = HutongGames.PlayMaker.Fsm::CreateSubFsm(this.fsm, this.fsmTemplateControl);\n\tthis.runFsm = v53;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Awake()
		{
			if (array != null)
			{
				FsmTemplateControl fsmTemplateControl = this.fsmTemplateControl;
				if (fsmTemplateControl.fsmTemplate != null && Application.isPlaying)
				{
					Fsm fsm = Fsm.CreateSubFsm(this.fsmTemplateControl);
					runFsm = fsm;
				}
			}
		}

		[Token(Token = "0x600081E")]
		[Address(RVA = "0xA89240", Offset = "0xA89240", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.array == 0;\n\tif (v2) goto L_000A;\n\tv4 = this.runFsm == 0;\n\tif (v4) goto L_000A;\n\tthis.currentIndex = 0;\n\tHutongGames.PlayMaker.Actions.ArrayForEach::StartFsm(this);\n\treturn;\nL_000A:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (array != null && runFsm != null)
			{
				currentIndex = 0;
				StartFsm();
			}
			else
			{
				Finish();
			}
		}

		[Token(Token = "0x600081F")]
		[Address(RVA = "0xA892F4", Offset = "0xA892F4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::Update(this.runFsm);\n\tv29 = this.runFsm;\n\tv39 = ~v29.<Finished>k__BackingField;\n\tif (v39) goto L_001F;\n\tv42 = this.currentIndex + 1;\n\tthis.currentIndex = v42;\n\tHutongGames.PlayMaker.Actions.ArrayForEach::StartFsm(this);\n\treturn;\nL_001F:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			runFsm.Update();
			Fsm fsm = runFsm;
			if (fsm.Finished)
			{
				int num = currentIndex + 1;
				currentIndex = num;
				StartFsm();
			}
		}

		[Token(Token = "0x6000820")]
		[Address(RVA = "0xA89368", Offset = "0xA89368", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::FixedUpdate(this.runFsm);\n\tv29 = this.runFsm;\n\tv39 = ~v29.<Finished>k__BackingField;\n\tif (v39) goto L_001F;\n\tv42 = this.currentIndex + 1;\n\tthis.currentIndex = v42;\n\tHutongGames.PlayMaker.Actions.ArrayForEach::StartFsm(this);\n\treturn;\nL_001F:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			runFsm.FixedUpdate();
			Fsm fsm = runFsm;
			if (fsm.Finished)
			{
				int num = currentIndex + 1;
				currentIndex = num;
				StartFsm();
			}
		}

		[Token(Token = "0x6000821")]
		[Address(RVA = "0xA893CC", Offset = "0xA893CC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::LateUpdate(this.runFsm);\n\tv29 = this.runFsm;\n\tv39 = ~v29.<Finished>k__BackingField;\n\tif (v39) goto L_001F;\n\tv42 = this.currentIndex + 1;\n\tthis.currentIndex = v42;\n\tHutongGames.PlayMaker.Actions.ArrayForEach::StartFsm(this);\n\treturn;\nL_001F:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLateUpdate()
		{
			runFsm.LateUpdate();
			Fsm fsm = runFsm;
			if (fsm.Finished)
			{
				int num = currentIndex + 1;
				currentIndex = num;
				StartFsm();
			}
		}

		[Token(Token = "0x6000822")]
		[Address(RVA = "0xA89358", Offset = "0xA89358", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.currentIndex + 1;\n\tthis.currentIndex = v2;\n\tHutongGames.PlayMaker.Actions.ArrayForEach::StartFsm(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StartNextFsm()
		{
			int num = currentIndex + 1;
			currentIndex = num;
			StartFsm();
		}

		[Token(Token = "0x6000823")]
		[Address(RVA = "0xA89260", Offset = "0xA89260", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv71 = this.array;\n\tv51 = this.currentIndex;\nL_000C:\n\tv72 = HutongGames.PlayMaker.FsmArray::get_Length(v71);\n\tv23 = v51 >= v72;\n\tif (v23) goto L_002E;\n\tHutongGames.PlayMaker.Actions.ArrayForEach::DoStartFsm(this);\n\tv21 = this.runFsm;\n\tv128 = ~v21.<Finished>k__BackingField;\n\tif (v128) goto L_003D;\n\tv71 = this.array;\n\tv51 = this.currentIndex + 1;\n\tthis.currentIndex = v51;\n\tv129 = this.array == 0;\n\tv53 = ~v129;\n\tif (v53) goto L_000C;\n\tthrow System.NullReferenceException;\nL_002E:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_003D:\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StartFsm()
		{
			FsmArray fsmArray = array;
			int num = currentIndex;
			do
			{
				int length = fsmArray.Length;
				if (num < length)
				{
					DoStartFsm();
					Fsm fsm = runFsm;
					if (fsm.Finished)
					{
						fsmArray = array;
						num = ++currentIndex;
						continue;
					}
					return;
				}
				Fsm.Event(finishEvent);
				Finish();
				return;
			}
			while (array != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000824")]
		[Address(RVA = "0xA89430", Offset = "0xA89430", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmArray::get_Values(this.array);\n\tv98 = this.currentIndex;\n\tv104 = this.currentIndex < v16.Length;\n\tv47 = ~v104;\n\tif (v47) goto L_0048;\n\tHutongGames.PlayMaker.FsmVar::SetValue(this.storeItem, v16[v98 @ X8_v4 (System.Int32)]);\n\tHutongGames.PlayMaker.FsmTemplateControl::UpdateValues(this.fsmTemplateControl);\n\tHutongGames.PlayMaker.FsmTemplateControl::ApplyOverrides(this.fsmTemplateControl, this.runFsm);\n\tHutongGames.PlayMaker.Fsm::OnEnable(this.runFsm);\n\tv71 = this.runFsm;\n\tv150 = ~v71.<Started>k__BackingField;\n\tif (v150) goto L_0045;\n\treturn;\nL_0045:\n\tHutongGames.PlayMaker.Fsm::Start(v71);\n\treturn;\n\tv72 = new System.NullReferenceException();\nL_0048:\n\tv103 = new System.IndexOutOfRangeException();\n\tthrow v103;\n\tthrow System.NullReferenceException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoStartFsm()
		{
			object[] values = array.Values;
			int num = currentIndex;
			if (currentIndex < values.Length)
			{
				storeItem.SetValue(values[num]);
				fsmTemplateControl.UpdateValues();
				fsmTemplateControl.ApplyOverrides(runFsm);
				runFsm.OnEnable();
				Fsm fsm = runFsm;
				if (!fsm.Started)
				{
					fsm.Start();
				}
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000825")]
		[Address(RVA = "0xA894FC", Offset = "0xA894FC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void CheckIfFinished()
		{
		}

		[Token(Token = "0x6000826")]
		[Address(RVA = "0xA89500", Offset = "0xA89500", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F0DD98]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221B5]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmTemplateControl();\n\tHutongGames.PlayMaker.FsmTemplateControl::.ctor(v42);\n\tthis.fsmTemplateControl = v42;\n\tHutongGames.PlayMaker.Actions.RunFSMAction::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayForEach()
		{
			FsmTemplateControl fsmTemplateControl = new FsmTemplateControl();
			this.fsmTemplateControl = fsmTemplateControl;
		}
	}
}
