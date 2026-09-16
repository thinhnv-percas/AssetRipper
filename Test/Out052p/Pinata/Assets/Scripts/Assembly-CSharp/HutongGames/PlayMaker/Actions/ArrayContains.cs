using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753A54", Offset = "0x753A54")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x753A54", Offset = "0x753A54")]
	[Token(Token = "0x2000173")]
	public class ArrayContains : FsmStateAction
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000480")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400214B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400214C")]
			public static Predicate<object> _003C_003E9__8_0;

			[Token(Token = "0x600159E")]
			[Address(RVA = "0xA88F10", Offset = "0xA88F10", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EB8228]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20221B1]) = v37;\nL_0015:\n\tv41 = new HutongGames.PlayMaker.Actions.ArrayContains+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600159F")]
			[Address(RVA = "0xA88F74", Offset = "0xA88F74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CDoCheckContainsValue_003Eb__8_0(object x)
			{
				//IL_0025: Expected I, but got O
				//IL_0035: Expected O, but got I
				//IL_0045: Expected O, but got I
				if (x != null)
				{
					IntPtr intPtr = (IntPtr)x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<System.Object>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<System.Object>)+138]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v5 @ X3_v1 (should have been resolved before IL gen)");
				}
				return true;
			}
		}

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A9498", Offset = "0x7A9498")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9498", Offset = "0x7A9498")]
		[Token(Token = "0x4001246")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array;

		[RequiredField]
		[AttributeAttribute(Type = typeof(MatchElementTypeAttribute), RVA = "0x7A94F8", Offset = "0x7A94F8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A94F8", Offset = "0x7A94F8")]
		[Token(Token = "0x4001247")]
		[FieldOffset(Offset = "0x58")]
		public FsmVar value;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A9568", Offset = "0x7A9568")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9568", Offset = "0x7A9568")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A9568", Offset = "0x7A9568")]
		[Token(Token = "0x4001248")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt index;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A95DC", Offset = "0x7A95DC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A95DC", Offset = "0x7A95DC")]
		[Token(Token = "0x4001249")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool isContained;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A962C", Offset = "0x7A962C")]
		[Token(Token = "0x400124A")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent isContainedEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9664", Offset = "0x7A9664")]
		[Token(Token = "0x400124B")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent isNotContainedEvent;

		[Token(Token = "0x6000814")]
		[Address(RVA = "0xA88CD8", Offset = "0xA88CD8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.index = 0;\n\tthis.isContainedEvent = 0;\n\tthis.array = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			index = null;
			isContainedEvent = null;
			array = null;
		}

		[Token(Token = "0x6000815")]
		[Address(RVA = "0xA88CE8", Offset = "0xA88CE8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ArrayContains::DoCheckContainsValue(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoCheckContainsValue();
			Finish();
		}

		[Token(Token = "0x6000816")]
		[Address(RVA = "0xA88D10", Offset = "0xA88D10", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1ECE180]);\n\tv25 = *([v24 @ X8_v30]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20221B0]) = v44;\nL_001A:\n\tHutongGames.PlayMaker.FsmVar::UpdateValue(this.value);\n\tv133 = HutongGames.PlayMaker.FsmVar::GetValue(this.value);\n\tv134 = v133 == 0;\n\tif (v134) goto L_0035;\n\tv63 = HutongGames.PlayMaker.FsmVar::GetValue(this.value);\n\tv167 = System.Object::Equals(v63, 0);\n\tv169 = v167 == 0;\n\tif (v169) goto L_0072;\nL_0035:\n\tv171 = HutongGames.PlayMaker.FsmArray::get_Values(this.array);\n\tgoto L_0046;\n\tv180 = *([v175 @ X8_v10 (Il2CppClass<HutongGames.PlayMaker.Actions.ArrayContains+<>c>)+E0]);\n\tv181 = v180 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_0046;\n\tv193 = v175;\n\tv185 = \"il2cpp_codegen_runtime_class_init\"(v193, v170, v49, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv188 = HutongGames.PlayMaker.Actions.ArrayContains+<>c;\nL_0046:\n\tv201 = v189.<>9__8_0;\n\tv191 = v189.<>9__8_0 == 0;\n\tv192 = ~v191;\n\tif (v192) goto L_006C;\n\tgoto L_005A;\n\tv223 = *([v187 @ X8_v11 (Il2CppClass<HutongGames.PlayMaker.Actions.ArrayContains+<>c>)+E0]);\n\tv224 = v223 == 0;\n\tv225 = ~v224;\n\tif (v225) goto L_005A;\n\tv235 = v187;\n\tv229 = \"il2cpp_codegen_runtime_class_init\"(v235, v170, v49, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv231 = HutongGames.PlayMaker.Actions.ArrayContains+<>c;\n\tv227 = *([v231 @ X8_v22+B8]);\nL_005A:\n\tv212 = new System.Predicate`1<System.Object>();\n\tSystem.Predicate`1<System.Object>::.ctor(v212, v226.<>9, Il2CppMethodInfo);\n\tv216.<>9__8_0 = v212;\nL_006C:\n\tv116 = System.Array::FindIndex(v171, v201);\n\tgoto L_0080;\nL_0072:\n\tv115 = HutongGames.PlayMaker.FsmArray::get_Values(this.array);\n\tv247 = HutongGames.PlayMaker.FsmVar::GetValue(this.value);\n\tv116 = System.Array::IndexOf(v115, v247);\nL_0080:\n\tv125 = this.isContained;\n\tv249 = v116 + 1;\n\tv91 = v249 == 0;\n\tv80 = ~v91;\n\tv125.value = v80;\n\tv126 = this.index;\n\tv126.value = v116;\n\tv252 = v116 + 1;\n\tv92 = v252 == 0;\n\tif (v92) goto L_009C;\n\tv154 = this.isContainedEvent;\n\tgoto L_00A7;\nL_009C:\n\tv154 = this.isNotContainedEvent;\nL_00A7:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v154);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoCheckContainsValue()
		{
			value.UpdateValue();
			object obj = value.GetValue();
			int num;
			if (obj != null)
			{
				object obj2 = value.GetValue();
				if (!obj2.Equals(null))
				{
					object[] values = array.Values;
					object obj3 = value.GetValue();
					num = Array.IndexOf(values, obj3);
					goto IL_00d2;
				}
			}
			object[] values2 = array.Values;
			Predicate<object> match = _003C_003Ec._003C_003E9__8_0;
			if (_003C_003Ec._003C_003E9__8_0 == null)
			{
				match = (_003C_003Ec._003C_003E9__8_0 = delegate(object x)
				{
					//IL_0025: Expected I, but got O
					//IL_0035: Expected O, but got I
					//IL_0045: Expected O, but got I
					if (x != null)
					{
						IntPtr intPtr = (IntPtr)x;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<System.Object>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<System.Object>)+138]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v5 @ X3_v1 (should have been resolved before IL gen)");
					}
					return true;
				});
			}
			num = Array.FindIndex(values2, match);
			goto IL_00d2;
			IL_00d2:
			FsmBool fsmBool = isContained;
			int num2 = num + 1;
			bool flag = num2 == 0;
			bool flag2 = !flag;
			fsmBool.value = flag2;
			FsmInt fsmInt = index;
			fsmInt.Value = num;
			FsmEvent fsmEvent = ((num + 1 == 0) ? isNotContainedEvent : isContainedEvent);
			Fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000817")]
		[Address(RVA = "0xA88F08", Offset = "0xA88F08", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayContains()
		{
		}
	}
}
