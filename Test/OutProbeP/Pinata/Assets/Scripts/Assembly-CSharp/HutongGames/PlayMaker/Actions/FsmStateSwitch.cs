using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758994", Offset = "0x758994")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x758994", Offset = "0x758994")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758994", Offset = "0x758994")]
	[Token(Token = "0x2000263")]
	public class FsmStateSwitch : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5EB8", Offset = "0x7B5EB8")]
		[Token(Token = "0x4001619")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B5F04", Offset = "0x7B5F04")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5F04", Offset = "0x7B5F04")]
		[Token(Token = "0x400161A")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7B5F54", Offset = "0x7B5F54")]
		[Token(Token = "0x400161B")]
		[FieldOffset(Offset = "0x60")]
		public FsmString[] compareTo;

		[Token(Token = "0x400161C")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent[] sendEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5FBC", Offset = "0x7B5FBC")]
		[Token(Token = "0x400161D")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x400161E")]
		[FieldOffset(Offset = "0x78")]
		private GameObject previousGo;

		[Token(Token = "0x400161F")]
		[FieldOffset(Offset = "0x80")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x6000BEB")]
		[Address(RVA = "0xB777B4", Offset = "0xB777B4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB8FE8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022938]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tthis.fsmName = 0;\n\t// 25 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmString[]), typeof(HutongGames.PlayMaker.FsmString[]), 1\n\tthis.compareTo = v43;\n\t// 31 NewArr v48 @ X0_v5 (HutongGames.PlayMaker.FsmEvent[]), typeof(HutongGames.PlayMaker.FsmEvent[]), 1\n\tthis.sendEvent = v48;\n\tthis.everyFrame = 0;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			fsmName = null;
			FsmString[] array = new FsmString[1];
			compareTo = array;
			FsmEvent[] array2 = new FsmEvent[1];
			sendEvent = array2;
			everyFrame = false;
		}

		[Token(Token = "0x6000BEC")]
		[Address(RVA = "0xB7782C", Offset = "0xB7782C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FsmStateSwitch::DoFsmStateSwitch(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoFsmStateSwitch();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000BED")]
		[Address(RVA = "0xB77A60", Offset = "0xB77A60", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FsmStateSwitch::DoFsmStateSwitch(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoFsmStateSwitch();
		}

		[Token(Token = "0x6000BEE")]
		[Address(RVA = "0xB77868", Offset = "0xB77868", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1F06CF8]);\n\tv25 = *([v24 @ X8_v22]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022939]) = v44;\nL_001A:\n\tv48 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tgoto L_002C;\n\tv163 = *([v131 @ X8_v5+E0]);\n\tv164 = v163 == 0;\n\tv165 = ~v164;\n\tif (v165) goto L_002C;\n\tv176 = v131;\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v176, v47, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002C:\n\tv172 = UnityEngine.Object::op_Equality(v48, 0);\n\tv178 = v172 == 0;\n\tv179 = ~v178;\n\tif (v179) goto L_00A6;\n\tgoto L_003F;\n\tv273 = *([v180 @ X0_v13+E0]);\n\tv274 = v273 == 0;\n\tv275 = ~v274;\n\tif (v275) goto L_003F;\n\tv277 = \"il2cpp_codegen_runtime_class_init\"(v180, v170, v171, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_003F:\n\tv280 = UnityEngine.Object::op_Inequality(v48, this.previousGo);\n\tv282 = v280 == 0;\n\tif (v282) goto L_0053;\n\tv287 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv295 = HutongGames.PlayMaker.ActionHelpers::GetGameObjectFsm(v48, v287);\n\tv88 = this + 0x80;\n\tthis.fsm = v295;\n\tthis.previousGo = v48;\n\tgoto L_0059;\nL_0053:\n\tv88 = this + 0x80;\nL_0059:\n\tgoto L_0062;\n\tv302 = *([v297 @ X0_v18+E0]);\n\tv303 = v302 == 0;\n\tv304 = ~v303;\n\tgoto L_0062;\n\tv306 = \"il2cpp_codegen_runtime_class_init\"(v297, v292, v290, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0062:\n\tv225 = UnityEngine.Object::op_Equality(v91, 0);\n\tv311 = v225 == 0;\n\tv228 = ~v311;\n\tif (v228) goto L_00A6;\n\tv313 = PlayMakerFSM::get_ActiveStateName(*([v88 @ X23_v5]));\n\tv160 = this.compareTo;\nL_007B:\n\tv51 = v92 >= v160.Length;\n\tif (v51) goto L_00A6;\n\tv333 = v92 < v160.Length;\n\tv85 = ~v333;\n\tif (v85) goto L_00C7;\n\tv335 = HutongGames.PlayMaker.FsmString::get_Value(v160[v92 @ X21_v9 (System.Int32)]);\n\tv155 = System.String::op_Equality(v313, v335);\n\tv338 = v155 == 0;\n\tv339 = ~v338;\n\tif (v339) goto L_00A7;\n\tv160 = this.compareTo;\n\tv92 = v92 + 1;\n\tv340 = this.compareTo == 0;\n\tv319 = ~v340;\n\tif (v319) goto L_007B;\n\tthrow System.NullReferenceException;\nL_00A6:\n\treturn;\nL_00A7:\n\tv125 = this.sendEvent;\n\tv341 = v92 < v125.Length;\n\tv86 = ~v341;\n\tif (v86) goto L_00C7;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v125[v92 @ X21_v9 (System.Int32)]);\n\treturn;\n\tv129 = new System.NullReferenceException();\nL_00C7:\n\tv162 = new System.IndexOutOfRangeException();\n\tthrow v162;\n\treturn;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoFsmStateSwitch()
		{
			//IL_00e2: Expected O, but got I
			//IL_00b5: Expected O, but got I
			GameObject value = gameObject.Value;
			if (value == null)
			{
				return;
			}
			object obj;
			UnityEngine.Object obj2;
			if (value != previousGo)
			{
				string value2 = fsmName.Value;
				PlayMakerFSM gameObjectFsm = ActionHelpers.GetGameObjectFsm(value, value2);
				obj = (long)(IntPtr)this + 128L;
				fsm = gameObjectFsm;
				previousGo = value;
				obj2 = gameObjectFsm;
			}
			else
			{
				obj = (long)(IntPtr)this + 128L;
				obj2 = fsm;
			}
			if (obj2 == null)
			{
				return;
			}
			string activeStateName = ((PlayMakerFSM)obj).ActiveStateName;
			FsmString[] array = compareTo;
			int num = 0;
			while (true)
			{
				if (num >= array.Length)
				{
					return;
				}
				if (num >= array.Length)
				{
					break;
				}
				string value3 = array[num].Value;
				if (!(activeStateName == value3))
				{
					array = compareTo;
					num++;
					if (compareTo == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				FsmEvent[] array2 = sendEvent;
				if (num >= array2.Length)
				{
					break;
				}
				Fsm.Event(array2[num]);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000BEF")]
		[Address(RVA = "0xB77A64", Offset = "0xB77A64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmStateSwitch()
		{
		}
	}
}
