using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x2000075")]
	public abstract class PlayMakerUiEventBase : MonoBehaviour
	{
		[Token(Token = "0x40002C5")]
		[FieldOffset(Offset = "0x18")]
		public List<PlayMakerFSM> targetFsms;

		[NonSerialized]
		[Token(Token = "0x40002C6")]
		[FieldOffset(Offset = "0x20")]
		protected internal bool initialized;

		[Token(Token = "0x6000347")]
		[Address(RVA = "0x98BE88", Offset = "0x98BE88", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EE5A48]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, fsm, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216DD]) = v41;\nL_0017:\n\tv44 = HutongGames.PlayMaker.PlayMakerUiEventBase::TargetsFsm(this, fsm);\n\tv46 = v44 == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_0024;\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::Add(this.targetFsms, fsm);\nL_0024:\n\tv58 = this->klass;\n\tv64 = this->klass->vtable[4];\n\tv65 = this->klass->vtable[4];\n\t// 46 IndirectJump v64 @ X2_v2, this @ X0 (HutongGames.PlayMaker.PlayMakerUiEventBase), this @ X0 (HutongGames.PlayMaker.PlayMakerUiEventBase), v65 @ X1_v3, v64 @ X2_v2, v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddTargetFsm(PlayMakerFSM fsm)
		{
			//IL_001e: Expected I, but got O
			//IL_002e: Expected O, but got I
			//IL_003e: Expected O, but got I
			while (true)
			{
				if (!TargetsFsm(fsm))
				{
					targetFsms.Add(fsm);
				}
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X8_v4 (Il2CppClass<HutongGames.PlayMaker.PlayMakerUiEventBase>)+170]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X8_v4 (Il2CppClass<HutongGames.PlayMaker.PlayMakerUiEventBase>)+178]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v64 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000348")]
		[Address(RVA = "0x98BF10", Offset = "0x98BF10", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EC1170]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsm, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20216DE]) = v45;\nL_0017:\n\tv118 = this.targetFsms;\nL_0027:\n\tv129 = v114 >= v118._size;\n\tif (v129) goto L_FFFFFFFF;\n\tv150 = v118._size < v114;\n\tv86 = ~v150;\n\tv83 = v118._size - v114;\n\tv77 = v83 == 0;\n\tv151 = ~v77;\n\tv62 = v86 & v151;\n\tif (v62) goto L_0037;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0037:\n\tv183 = v118._items;\n\tgoto L_0048;\n\tv188 = *([v184 @ X0_v10+E0]);\n\tv189 = v188 == 0;\n\tv190 = ~v189;\n\tif (v190) goto L_0048;\n\tv192 = \"il2cpp_codegen_runtime_class_init\"(v184, v102, v101, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0048:\n\tv92 = UnityEngine.Object::op_Equality(fsm, v183[v114 @ X22_v6 (System.Int32)]);\n\tv196 = v92 == 0;\n\tv170 = ~v196;\n\tif (v170) goto L_FFFFFFFF;\n\tv118 = this.targetFsms;\n\tv114 = v114 + 1;\n\tv197 = this.targetFsms == 0;\n\tv94 = ~v197;\n\tif (v94) goto L_0027;\n\tthrow System.NullReferenceException;\n\tgoto L_005F;\nL_005F:\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool TargetsFsm(PlayMakerFSM fsm)
		{
			List<PlayMakerFSM> list = targetFsms;
			int num = 0;
			while (true)
			{
				if (num < list.Count)
				{
					bool flag = list.Count < num;
					bool flag2 = !flag;
					int num2 = list.Count - num;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					PlayMakerFSM[] items = list._items;
					if (fsm == items[num])
					{
						break;
					}
					list = targetFsms;
					num++;
					if (targetFsms == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return false;
			}
			return true;
		}

		[Token(Token = "0x6000349")]
		[Address(RVA = "0x98BFEC", Offset = "0x98BFEC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv2 = this->klass->vtable[4];\n\tv3 = this->klass->vtable[4];\n\t// 3 IndirectJump v2 @ X2_v1, this @ X0 (HutongGames.PlayMaker.PlayMakerUiEventBase), this @ X0 (HutongGames.PlayMaker.PlayMakerUiEventBase), v3 @ X1_v1, v2 @ X2_v1, v4 @ X3, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn;\n")]
		protected void OnEnable()
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.PlayMakerUiEventBase>)+170]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.PlayMakerUiEventBase>)+178]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600034A")]
		[Address(RVA = "0x98BFF8", Offset = "0x98BFF8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv2 = this->klass->vtable[4];\n\tv3 = this->klass->vtable[4];\n\t// 3 IndirectJump v2 @ X2_v1, this @ X0 (HutongGames.PlayMaker.PlayMakerUiEventBase), this @ X0 (HutongGames.PlayMaker.PlayMakerUiEventBase), v3 @ X1_v1, v2 @ X2_v1, v4 @ X3, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn;\n")]
		public void PreProcess()
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.PlayMakerUiEventBase>)+170]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.PlayMakerUiEventBase>)+178]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600034B")]
		[Address(RVA = "0x98C004", Offset = "0x98C004", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.initialized = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void Initialize()
		{
			initialized = true;
		}

		[Token(Token = "0x600034C")]
		[Address(RVA = "0x98B3F8", Offset = "0x98B3F8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F10270]);\n\tv25 = *([v24 @ X8_v11]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, fsmEvent, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20216DF]) = v43;\nL_0016:\n\tv115 = this.targetFsms;\nL_0024:\n\tv126 = v87 >= v115._size;\n\tif (v126) goto L_0055;\n\tv151 = v115._size < v87;\n\tv83 = ~v151;\n\tv80 = v115._size - v87;\n\tv74 = v80 == 0;\n\tv152 = ~v74;\n\tv59 = v83 & v152;\n\tif (v59) goto L_0034;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0034:\n\tv179 = v115._items;\n\tv182 = PlayMakerFSM::get_Fsm(v179[v87 @ X22_v5 (System.Int32)]);\n\tv90 = UnityEngine.Component::get_gameObject(this);\n\tHutongGames.PlayMaker.Fsm::Event(v182, v90, fsmEvent);\n\tv115 = this.targetFsms;\n\tv87 = v87 + 1;\n\tv185 = this.targetFsms == 0;\n\tv92 = ~v185;\n\tif (v92) goto L_0024;\n\tthrow System.NullReferenceException;\nL_0055:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void SendEvent(FsmEvent fsmEvent)
		{
			List<PlayMakerFSM> list = targetFsms;
			int num = 0;
			while (num < list.Count)
			{
				bool flag = list.Count < num;
				bool flag2 = !flag;
				int num2 = list.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				PlayMakerFSM[] items = list._items;
				Fsm fsm = items[num].Fsm;
				GameObject fromGameObject = base.gameObject;
				fsm.Event(fromGameObject, fsmEvent);
				list = targetFsms;
				num++;
				if (targetFsms == null)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x600034D")]
		[Address(RVA = "0x98B4C8", Offset = "0x98B4C8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA8FE8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20216E0]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<PlayMakerFSM>();\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::.ctor(v42);\n\tthis.targetFsms = v42;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal PlayMakerUiEventBase()
		{
			List<PlayMakerFSM> list = new List<PlayMakerFSM>();
			targetFsms = list;
		}
	}
}
