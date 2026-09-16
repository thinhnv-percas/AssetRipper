using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionTarget), RVA = "0x75414C", Offset = "0x75414C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75414C", Offset = "0x75414C")]
	[Token(Token = "0x2000184")]
	public class SetFsmArrayItem : BaseFsmVariableIndexAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AABE8", Offset = "0x7AABE8")]
		[Token(Token = "0x4001296")]
		[FieldOffset(Offset = "0x80")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AAC34", Offset = "0x7AAC34")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AAC34", Offset = "0x7AAC34")]
		[Token(Token = "0x4001297")]
		[FieldOffset(Offset = "0x88")]
		public FsmString fsmName;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AAC84", Offset = "0x7AAC84")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AAC84", Offset = "0x7AAC84")]
		[Token(Token = "0x4001298")]
		[FieldOffset(Offset = "0x90")]
		public FsmString variableName;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AACE4", Offset = "0x7AACE4")]
		[Token(Token = "0x4001299")]
		[FieldOffset(Offset = "0x98")]
		public FsmInt index;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AAD1C", Offset = "0x7AAD1C")]
		[Token(Token = "0x400129A")]
		[FieldOffset(Offset = "0xA0")]
		public FsmVar value;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AAD68", Offset = "0x7AAD68")]
		[Token(Token = "0x400129B")]
		[FieldOffset(Offset = "0xA8")]
		public bool everyFrame;

		[Token(Token = "0x600085F")]
		[Address(RVA = "0x990DF8", Offset = "0x990DF8", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0CD10]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021723]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v43;\n\tthis.value = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			value = null;
		}

		[Token(Token = "0x6000860")]
		[Address(RVA = "0x990E58", Offset = "0x990E58", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetFsmArrayItem::DoSetFsmArray(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetFsmArray();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000861")]
		[Address(RVA = "0x990E94", Offset = "0x990E94", Length = "0x240")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EF9FA8]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021724]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv177 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv179 = HutongGames.PlayMaker.Actions.BaseFsmVariableIndexAction::UpdateCache(this, v45, v177);\n\tv220 = v179 == 0;\n\tif (v220) goto L_0095;\n\tv160 = PlayMakerFSM::get_FsmVariables(this.fsm);\n\tv161 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv245 = HutongGames.PlayMaker.FsmVariables::GetFsmArray(v160, v161);\n\tv246 = v245 == 0;\n\tif (v246) goto L_00AA;\n\tv247 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv250 = v247 & 0x80000000;\n\tv251 = v250 == 0;\n\tv252 = ~v251;\n\tif (v252) goto L_009B;\n\tv257 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv254 = HutongGames.PlayMaker.FsmArray::get_Length(v245);\n\tv51 = v257 >= v254;\n\tif (v51) goto L_009B;\n\tv117 = HutongGames.PlayMaker.FsmVar::get_NamedVar(this.value);\n\tv261 = HutongGames.PlayMaker.NamedVariable::get_VariableType(v117);\n\tv52 = v245.type != v261;\n\tif (v52) goto L_00BA;\n\tHutongGames.PlayMaker.FsmVar::UpdateValue(this.value);\n\tv162 = HutongGames.PlayMaker.FsmInt::get_Value(this.index);\n\tv273 = HutongGames.PlayMaker.FsmVar::GetValue(this.value);\n\tHutongGames.PlayMaker.FsmArray::Set(v245, v162, v273);\n\treturn;\nL_0095:\n\treturn;\nL_009B:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.indexOutOfRange);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_00AA:\n\tv249 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tHutongGames.PlayMaker.Actions.BaseFsmVariableIndexAction::DoVariableNotFound(this, v249);\n\treturn;\nL_00BA:\n\tv264 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv270 = System.String::Concat(\"Incompatible variable type: \", v264);\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v270);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 161 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetFsmArray()
		{
			//IL_00d9: Expected I4, but got I8
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			string text = fsmName.Value;
			if (!UpdateCache(ownerDefaultTarget, text))
			{
				return;
			}
			FsmVariables fsmVariables = fsm.FsmVariables;
			string text2 = variableName.Value;
			FsmArray fsmArray = fsmVariables.GetFsmArray(text2);
			if (fsmArray != null)
			{
				int num = index.Value;
				if ((int)(num & 0x80000000L) == 0)
				{
					int num2 = index.Value;
					int length = fsmArray.Length;
					if (num2 < length)
					{
						NamedVariable namedVar = value.NamedVar;
						VariableType variableType = namedVar.VariableType;
						if (fsmArray.TypeConstraint == variableType)
						{
							value.UpdateValue();
							int num3 = index.Value;
							object obj = value.GetValue();
							fsmArray.Set(num3, obj);
						}
						else
						{
							string text3 = variableName.Value;
							string text4 = "Incompatible variable type: " + text3;
							LogWarning(text4);
						}
						return;
					}
				}
				Fsm.Event(indexOutOfRange);
				Finish();
			}
			else
			{
				string text5 = variableName.Value;
				DoVariableNotFound(text5);
			}
		}

		[Token(Token = "0x6000862")]
		[Address(RVA = "0x9910D4", Offset = "0x9910D4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetFsmArrayItem::DoSetFsmArray(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetFsmArray();
		}

		[Token(Token = "0x6000863")]
		[Address(RVA = "0x9910D8", Offset = "0x9910D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BaseFsmVariableIndexAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetFsmArrayItem()
		{
		}
	}
}
