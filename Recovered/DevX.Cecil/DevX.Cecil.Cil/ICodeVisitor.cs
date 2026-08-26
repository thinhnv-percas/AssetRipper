namespace DevX.Cecil.Cil
{
	public interface ICodeVisitor
	{
		void VisitMethodBody(MethodBody body);

		void VisitInstructionCollection(InstructionCollection instructions);

		void VisitInstruction(Instruction instr);

		void VisitExceptionHandlerCollection(ExceptionHandlerCollection seh);

		void VisitExceptionHandler(ExceptionHandler eh);

		void VisitVariableDefinitionCollection(VariableDefinitionCollection variables);

		void VisitVariableDefinition(VariableDefinition var);

		void VisitScopeCollection(ScopeCollection scopes);

		void VisitScope(Scope scope);

		void TerminateMethodBody(MethodBody body);
	}
}
