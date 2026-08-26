namespace DevX.Cecil.Cil
{
	public abstract class BaseCodeVisitor : ICodeVisitor
	{
		public virtual void VisitMethodBody(MethodBody body)
		{
		}

		public virtual void VisitInstructionCollection(InstructionCollection instructions)
		{
		}

		public virtual void VisitInstruction(Instruction instr)
		{
		}

		public virtual void VisitExceptionHandlerCollection(ExceptionHandlerCollection seh)
		{
		}

		public virtual void VisitExceptionHandler(ExceptionHandler eh)
		{
		}

		public virtual void VisitVariableDefinitionCollection(VariableDefinitionCollection variables)
		{
		}

		public virtual void VisitVariableDefinition(VariableDefinition var)
		{
		}

		public virtual void VisitScopeCollection(ScopeCollection scopes)
		{
		}

		public virtual void VisitScope(Scope s)
		{
		}

		public virtual void TerminateMethodBody(MethodBody body)
		{
		}
	}
}
