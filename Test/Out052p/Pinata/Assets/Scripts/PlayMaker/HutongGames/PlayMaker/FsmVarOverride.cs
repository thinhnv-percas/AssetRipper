using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000048")]
	public class FsmVarOverride
	{
		[Token(Token = "0x4000105")]
		[FieldOffset(Offset = "0x10")]
		public NamedVariable variable;

		[Token(Token = "0x4000106")]
		[FieldOffset(Offset = "0x18")]
		public FsmVar fsmVar;

		[Token(Token = "0x4000107")]
		[FieldOffset(Offset = "0x20")]
		public bool isEdited;

		[Token(Token = "0x600014B")]
		[Address(RVA = "0xE49398", Offset = "0xE49398", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EB1588]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, source, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024777]) = v43;\nL_0018:\n\tSystem.Object::.ctor(this);\n\tv47 = source.variable;\n\tv57 = new HutongGames.PlayMaker.NamedVariable();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v57, v47.name);\n\tthis.variable = v57;\n\tv69 = new HutongGames.PlayMaker.FsmVar();\n\tHutongGames.PlayMaker.FsmVar::.ctor(v69, source.fsmVar);\n\tthis.fsmVar = v69;\n\tthis.isEdited = source.isEdited;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVarOverride(FsmVarOverride source)
		{
			variable = new NamedVariable(source.variable.Name);
			fsmVar = new FsmVar(source.fsmVar);
			isEdited = source.isEdited;
		}

		[Token(Token = "0x600014C")]
		[Address(RVA = "0xE494DC", Offset = "0xE494DC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EAD660]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, namedVar, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2024778]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tthis.variable = namedVar;\n\tv47 = new HutongGames.PlayMaker.FsmVar();\n\tHutongGames.PlayMaker.FsmVar::.ctor(v47, namedVar);\n\tthis.fsmVar = v47;\n\tthis.isEdited = 0;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmVarOverride(NamedVariable namedVar)
		{
			variable = namedVar;
			FsmVar fsmVar = new FsmVar(namedVar);
			this.fsmVar = fsmVar;
			isEdited = false;
		}

		[Token(Token = "0x600014D")]
		[Address(RVA = "0xE49560", Offset = "0xE49560", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.variable;\n\tv20 = HutongGames.PlayMaker.FsmVariables::GetVariable(variables, v10.name);\n\tthis.variable = v20;\n\tHutongGames.PlayMaker.FsmVar::ApplyValueTo(this.fsmVar, v20);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Apply(FsmVariables variables)
		{
			NamedVariable namedVariable = variable;
			NamedVariable targetVariable = (variable = variables.GetVariable(namedVariable.Name));
			fsmVar.ApplyValueTo(targetVariable);
		}
	}
}
