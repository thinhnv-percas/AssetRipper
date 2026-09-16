using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionTarget), RVA = "0x753FFC", Offset = "0x753FFC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753FFC", Offset = "0x753FFC")]
	[Token(Token = "0x2000182")]
	public class GetFsmArrayItem : BaseFsmVariableIndexAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AA888", Offset = "0x7AA888")]
		[Token(Token = "0x400128B")]
		[FieldOffset(Offset = "0x80")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AA8D4", Offset = "0x7AA8D4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AA8D4", Offset = "0x7AA8D4")]
		[Token(Token = "0x400128C")]
		[FieldOffset(Offset = "0x88")]
		public FsmString fsmName;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AA924", Offset = "0x7AA924")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AA924", Offset = "0x7AA924")]
		[Token(Token = "0x400128D")]
		[FieldOffset(Offset = "0x90")]
		public FsmString variableName;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AA984", Offset = "0x7AA984")]
		[Token(Token = "0x400128E")]
		[FieldOffset(Offset = "0x98")]
		public FsmInt index;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AA9BC", Offset = "0x7AA9BC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AA9BC", Offset = "0x7AA9BC")]
		[Token(Token = "0x400128F")]
		[FieldOffset(Offset = "0xA0")]
		public FsmVar storeValue;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AAA1C", Offset = "0x7AAA1C")]
		[Token(Token = "0x4001290")]
		[FieldOffset(Offset = "0xA8")]
		public bool everyFrame;

		[Token(Token = "0x6000856")]
		[Address(RVA = "0xA2BD64", Offset = "0xA2BD64", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE1858]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DBA]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v43;\n\tthis.storeValue = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			storeValue = null;
		}

		[Token(Token = "0x6000857")]
		[Address(RVA = "0xA2BDC4", Offset = "0xA2BDC4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmArrayItem::DoGetFsmArray(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetFsmArray();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000858")]
		[Address(RVA = "0xA2BE00", Offset = "0xA2BE00", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EDA130]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021DBB]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv174 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv176 = HutongGames.PlayMaker.Actions.BaseFsmVariableIndexAction::UpdateCache(this, v45, v174);\n\tv215 = v176 == 0;\n\tif (v215) goto L_008F;\n\tv158 = PlayMakerFSM::get_FsmVariables(this.fsm);\n\tv159 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv240 = HutongGames.PlayMaker.FsmVariables::GetFsmArray(v158, v159);\n\tv241 = v240 == 0;\n\tif (v241) goto L_00A4;\n\tv242 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv245 = v242 & 0x80000000;\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\tif (v247) goto L_0095;\n\tv252 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv249 = HutongGames.PlayMaker.FsmArray::get_Length(v240);\n\tv51 = v252 >= v249;\n\tif (v51) goto L_0095;\n\tv116 = HutongGames.PlayMaker.FsmVar::get_NamedVar(this.storeValue);\n\tv256 = HutongGames.PlayMaker.NamedVariable::get_VariableType(v116);\n\tv52 = v240.type != v256;\n\tif (v52) goto L_00B4;\n\tv259 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv160 = HutongGames.PlayMaker.FsmArray::Get(v240, v259);\n\tHutongGames.PlayMaker.FsmVar::SetValue(this.storeValue, v160);\n\treturn;\nL_008F:\n\treturn;\nL_0095:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.indexOutOfRange);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_00A4:\n\tv244 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tHutongGames.PlayMaker.Actions.BaseFsmVariableIndexAction::DoVariableNotFound(this, v244);\n\treturn;\nL_00B4:\n\tv261 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv269 = System.String::Concat(\"Incompatible variable type: \", v261);\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v269);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 156 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetFsmArray()
		{
			//IL_00d9: Expected I4, but got I8
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			string value = fsmName.Value;
			if (!UpdateCache(ownerDefaultTarget, value))
			{
				return;
			}
			FsmVariables fsmVariables = fsm.FsmVariables;
			string value2 = variableName.Value;
			FsmArray fsmArray = fsmVariables.GetFsmArray(value2);
			if (fsmArray != null)
			{
				int value3 = index.Value;
				if ((int)(value3 & 0x80000000L) == 0)
				{
					int value4 = index.Value;
					int length = fsmArray.Length;
					if (value4 < length)
					{
						NamedVariable namedVar = storeValue.NamedVar;
						VariableType variableType = namedVar.VariableType;
						if (fsmArray.TypeConstraint == variableType)
						{
							int value5 = index.Value;
							object value6 = fsmArray.Get(value5);
							storeValue.SetValue(value6);
						}
						else
						{
							string value7 = variableName.Value;
							string text = "Incompatible variable type: " + value7;
							LogWarning(text);
						}
						return;
					}
				}
				Fsm.Event(indexOutOfRange);
				Finish();
			}
			else
			{
				string value8 = variableName.Value;
				DoVariableNotFound(value8);
			}
		}

		[Token(Token = "0x6000859")]
		[Address(RVA = "0xA2C02C", Offset = "0xA2C02C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmArrayItem::DoGetFsmArray(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetFsmArray();
		}

		[Token(Token = "0x600085A")]
		[Address(RVA = "0xA2C030", Offset = "0xA2C030", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseFsmVariableIndexAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetFsmArrayItem()
		{
		}
	}
}
