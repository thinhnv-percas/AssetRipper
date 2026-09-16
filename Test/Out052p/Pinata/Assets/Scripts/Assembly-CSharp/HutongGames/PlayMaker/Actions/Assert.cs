using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using PlayMaker.ConditionalExpression;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755140", Offset = "0x755140")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755140", Offset = "0x755140")]
	[Token(Token = "0x20001B4")]
	public class Assert : FsmStateAction, IEvaluatorContext
	{
		[Token(Token = "0x2000485")]
		public enum AssertType
		{
			[Token(Token = "0x400215F")]
			IsTrue = 0,
			[Token(Token = "0x4002160")]
			IsFalse = 1
		}

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7AE058", Offset = "0x7AE058")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE058", Offset = "0x7AE058")]
		[Token(Token = "0x400136D")]
		[FieldOffset(Offset = "0x60")]
		public FsmString expression;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE0A8", Offset = "0x7AE0A8")]
		[Token(Token = "0x400136E")]
		[FieldOffset(Offset = "0x68")]
		public AssertType assert;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE0E0", Offset = "0x7AE0E0")]
		[Token(Token = "0x400136F")]
		[FieldOffset(Offset = "0x6C")]
		public bool everyFrame;

		[Token(Token = "0x4001370")]
		[FieldOffset(Offset = "0x70")]
		private string cachedExpression;

		[Token(Token = "0x1700005F")]
		public CompiledAst Ast
		{
			[CompilerGenerated]
			[Token(Token = "0x6000942")]
			[Address(RVA = "0xA8A820", Offset = "0xA8A820", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Ast>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Ast;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000943")]
			[Address(RVA = "0xA8A828", Offset = "0xA8A828", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Ast>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Ast = value;
			}
		}

		[Token(Token = "0x17000060")]
		public string LastErrorMessage
		{
			[CompilerGenerated]
			[Token(Token = "0x6000944")]
			[Address(RVA = "0xA8A830", Offset = "0xA8A830", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<LastErrorMessage>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LastErrorMessage;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000945")]
			[Address(RVA = "0xA8A838", Offset = "0xA8A838", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<LastErrorMessage>k__BackingField = value;\n\treturn;\n")]
			set
			{
				LastErrorMessage = value;
			}
		}

		[Token(Token = "0x6000946")]
		[Address(RVA = "0xA8A840", Offset = "0xA8A840", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC2A80]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, name, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20221BD]) = v41;\nL_0015:\n\tv42 = this.fsm;\n\tv49 = HutongGames.PlayMaker.FsmVariables::GetVariable(v42.variables, name);\n\tv54 = v49 == 0;\n\tif (v54) goto L_0036;\n\tv67 = new HutongGames.PlayMaker.FsmVar();\n\tHutongGames.PlayMaker.FsmVar::.ctor(v67, v49);\n\treturn v67;\n\tthrow System.NullReferenceException;\nL_0036:\n\tv63 = new PlayMaker.ConditionalExpression.VariableNotFoundException();\n\tPlayMaker.ConditionalExpression.VariableNotFoundException::.ctor(v63, name);\n\tthrow v63;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		FsmVar IEvaluatorContext.GetVariable(string name)
		{
			Fsm fsm = Fsm;
			NamedVariable variable = fsm.Variables.GetVariable(name);
			if (variable != null)
			{
				return new FsmVar(variable);
			}
			VariableNotFoundException ex = new VariableNotFoundException(name);
			throw ex;
		}

		[Token(Token = "0x6000947")]
		[Address(RVA = "0xA8A914", Offset = "0xA8A914", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Assert()
		{
		}
	}
}
