namespace DevX.Cecil.Cil
{
	public sealed class MethodBody : ICodeVisitable, IScopeProvider, IVariableDefinitionProvider
	{
		private MethodDefinition m_method;

		private int m_maxStack;

		private int m_codeSize;

		private bool m_initLocals;

		private int m_localVarToken;

		private InstructionCollection m_instructions;

		private ExceptionHandlerCollection m_exceptions;

		private VariableDefinitionCollection m_variables;

		private ScopeCollection m_scopes;

		private CilWorker m_cilWorker;

		public MethodDefinition Method => m_method;

		public int MaxStack
		{
			get
			{
				return m_maxStack;
			}
			set
			{
				m_maxStack = value;
			}
		}

		public int CodeSize
		{
			get
			{
				return m_codeSize;
			}
			set
			{
				m_codeSize = value;
			}
		}

		public bool InitLocals
		{
			get
			{
				return m_initLocals;
			}
			set
			{
				m_initLocals = value;
			}
		}

		public int LocalVarToken
		{
			get
			{
				return m_localVarToken;
			}
			set
			{
				m_localVarToken = value;
			}
		}

		public CilWorker CilWorker
		{
			get
			{
				if (m_cilWorker == null)
				{
					m_cilWorker = new CilWorker(this);
				}
				return m_cilWorker;
			}
			set
			{
				m_cilWorker = value;
			}
		}

		public InstructionCollection Instructions => m_instructions;

		public bool HasExceptionHandlers => m_exceptions != null && m_exceptions.Count > 0;

		public ExceptionHandlerCollection ExceptionHandlers
		{
			get
			{
				if (m_exceptions == null)
				{
					m_exceptions = new ExceptionHandlerCollection(this);
				}
				return m_exceptions;
			}
		}

		public bool HasVariables => m_variables != null && m_variables.Count > 0;

		public VariableDefinitionCollection Variables
		{
			get
			{
				if (m_variables == null)
				{
					m_variables = new VariableDefinitionCollection(this);
				}
				return m_variables;
			}
		}

		public bool HasScopes => m_scopes != null && m_scopes.Count > 0;

		public ScopeCollection Scopes
		{
			get
			{
				if (m_scopes == null)
				{
					m_scopes = new ScopeCollection(this);
				}
				return m_scopes;
			}
		}

		public MethodBody(MethodDefinition meth)
		{
			m_method = meth;
			m_instructions = new InstructionCollection(this);
		}

		internal static Instruction GetInstruction(MethodBody oldBody, MethodBody newBody, Instruction i)
		{
			int num = oldBody.Instructions.IndexOf(i);
			if (num > -1 && num < newBody.Instructions.Count)
			{
				return newBody.Instructions[num];
			}
			return newBody.Instructions.Outside;
		}

		internal static MethodBody Clone(MethodBody body, MethodDefinition parent, ImportContext context)
		{
			MethodBody methodBody = new MethodBody(parent);
			methodBody.MaxStack = body.MaxStack;
			methodBody.InitLocals = body.InitLocals;
			methodBody.CodeSize = body.CodeSize;
			CilWorker cilWorker = methodBody.CilWorker;
			if (body.HasVariables)
			{
				foreach (VariableDefinition variable in body.Variables)
				{
					methodBody.Variables.Add(new VariableDefinition(variable.Name, variable.Index, parent, context.Import(variable.VariableType)));
				}
			}
			foreach (Instruction instruction5 in body.Instructions)
			{
				Instruction instruction2 = new Instruction(instruction5.OpCode);
				switch (instruction5.OpCode.OperandType)
				{
				case OperandType.InlineParam:
				case OperandType.ShortInlineParam:
					if (instruction5.Operand == body.Method.This)
					{
						instruction2.Operand = methodBody.Method.This;
					}
					else
					{
						int index2 = body.Method.Parameters.IndexOf((ParameterDefinition)instruction5.Operand);
						instruction2.Operand = parent.Parameters[index2];
					}
					break;
				case OperandType.InlineVar:
				case OperandType.ShortInlineVar:
				{
					int index = body.Variables.IndexOf((VariableDefinition)instruction5.Operand);
					instruction2.Operand = methodBody.Variables[index];
					break;
				}
				case OperandType.InlineField:
					instruction2.Operand = context.Import((FieldReference)instruction5.Operand);
					break;
				case OperandType.InlineMethod:
					instruction2.Operand = context.Import((MethodReference)instruction5.Operand);
					break;
				case OperandType.InlineType:
					instruction2.Operand = context.Import((TypeReference)instruction5.Operand);
					break;
				case OperandType.InlineTok:
					if (instruction5.Operand is TypeReference)
					{
						instruction2.Operand = context.Import((TypeReference)instruction5.Operand);
					}
					else if (instruction5.Operand is FieldReference)
					{
						instruction2.Operand = context.Import((FieldReference)instruction5.Operand);
					}
					else if (instruction5.Operand is MethodReference)
					{
						instruction2.Operand = context.Import((MethodReference)instruction5.Operand);
					}
					break;
				default:
					instruction2.Operand = instruction5.Operand;
					break;
				case OperandType.InlineBrTarget:
				case OperandType.InlineSwitch:
				case OperandType.ShortInlineBrTarget:
					break;
				}
				cilWorker.Append(instruction2);
			}
			for (int i = 0; i < body.Instructions.Count; i++)
			{
				Instruction instruction3 = methodBody.Instructions[i];
				Instruction instruction4 = body.Instructions[i];
				if (instruction3.OpCode.OperandType == OperandType.InlineSwitch)
				{
					Instruction[] array = (Instruction[])instruction4.Operand;
					Instruction[] array2 = new Instruction[array.Length];
					for (int j = 0; j < array2.Length; j++)
					{
						array2[j] = GetInstruction(body, methodBody, array[j]);
					}
					instruction3.Operand = array2;
				}
				else if (instruction3.OpCode.OperandType == OperandType.ShortInlineBrTarget || instruction3.OpCode.OperandType == OperandType.InlineBrTarget)
				{
					instruction3.Operand = GetInstruction(body, methodBody, (Instruction)instruction4.Operand);
				}
			}
			if (!body.HasExceptionHandlers)
			{
				return methodBody;
			}
			foreach (ExceptionHandler exceptionHandler3 in body.ExceptionHandlers)
			{
				ExceptionHandler exceptionHandler2 = new ExceptionHandler(exceptionHandler3.Type);
				exceptionHandler2.TryStart = GetInstruction(body, methodBody, exceptionHandler3.TryStart);
				exceptionHandler2.TryEnd = GetInstruction(body, methodBody, exceptionHandler3.TryEnd);
				exceptionHandler2.HandlerStart = GetInstruction(body, methodBody, exceptionHandler3.HandlerStart);
				exceptionHandler2.HandlerEnd = GetInstruction(body, methodBody, exceptionHandler3.HandlerEnd);
				switch (exceptionHandler3.Type)
				{
				case ExceptionHandlerType.Catch:
					exceptionHandler2.CatchType = context.Import(exceptionHandler3.CatchType);
					break;
				case ExceptionHandlerType.Filter:
					exceptionHandler2.FilterStart = GetInstruction(body, methodBody, exceptionHandler3.FilterStart);
					exceptionHandler2.FilterEnd = GetInstruction(body, methodBody, exceptionHandler3.FilterEnd);
					break;
				}
				methodBody.ExceptionHandlers.Add(exceptionHandler2);
			}
			return methodBody;
		}

		public void Simplify()
		{
			foreach (Instruction instruction in Instructions)
			{
				if (instruction.OpCode.OpCodeType == OpCodeType.Macro)
				{
					switch (instruction.OpCode.Code)
					{
					case Code.Ldarg_0:
						Modify(instruction, OpCodes.Ldarg, CodeReader.GetParameter(this, 0));
						break;
					case Code.Ldarg_1:
						Modify(instruction, OpCodes.Ldarg, CodeReader.GetParameter(this, 1));
						break;
					case Code.Ldarg_2:
						Modify(instruction, OpCodes.Ldarg, CodeReader.GetParameter(this, 2));
						break;
					case Code.Ldarg_3:
						Modify(instruction, OpCodes.Ldarg, CodeReader.GetParameter(this, 3));
						break;
					case Code.Ldloc_0:
						Modify(instruction, OpCodes.Ldloc, CodeReader.GetVariable(this, 0));
						break;
					case Code.Ldloc_1:
						Modify(instruction, OpCodes.Ldloc, CodeReader.GetVariable(this, 1));
						break;
					case Code.Ldloc_2:
						Modify(instruction, OpCodes.Ldloc, CodeReader.GetVariable(this, 2));
						break;
					case Code.Ldloc_3:
						Modify(instruction, OpCodes.Ldloc, CodeReader.GetVariable(this, 3));
						break;
					case Code.Stloc_0:
						Modify(instruction, OpCodes.Stloc, CodeReader.GetVariable(this, 0));
						break;
					case Code.Stloc_1:
						Modify(instruction, OpCodes.Stloc, CodeReader.GetVariable(this, 1));
						break;
					case Code.Stloc_2:
						Modify(instruction, OpCodes.Stloc, CodeReader.GetVariable(this, 2));
						break;
					case Code.Stloc_3:
						Modify(instruction, OpCodes.Stloc, CodeReader.GetVariable(this, 3));
						break;
					case Code.Ldarg_S:
						instruction.OpCode = OpCodes.Ldarg;
						break;
					case Code.Ldarga_S:
						instruction.OpCode = OpCodes.Ldarga;
						break;
					case Code.Starg_S:
						instruction.OpCode = OpCodes.Starg;
						break;
					case Code.Ldloc_S:
						instruction.OpCode = OpCodes.Ldloc;
						break;
					case Code.Ldloca_S:
						instruction.OpCode = OpCodes.Ldloca;
						break;
					case Code.Stloc_S:
						instruction.OpCode = OpCodes.Stloc;
						break;
					case Code.Ldc_I4_M1:
						Modify(instruction, OpCodes.Ldc_I4, -1);
						break;
					case Code.Ldc_I4_0:
						Modify(instruction, OpCodes.Ldc_I4, 0);
						break;
					case Code.Ldc_I4_1:
						Modify(instruction, OpCodes.Ldc_I4, 1);
						break;
					case Code.Ldc_I4_2:
						Modify(instruction, OpCodes.Ldc_I4, 2);
						break;
					case Code.Ldc_I4_3:
						Modify(instruction, OpCodes.Ldc_I4, 3);
						break;
					case Code.Ldc_I4_4:
						Modify(instruction, OpCodes.Ldc_I4, 4);
						break;
					case Code.Ldc_I4_5:
						Modify(instruction, OpCodes.Ldc_I4, 5);
						break;
					case Code.Ldc_I4_6:
						Modify(instruction, OpCodes.Ldc_I4, 6);
						break;
					case Code.Ldc_I4_7:
						Modify(instruction, OpCodes.Ldc_I4, 7);
						break;
					case Code.Ldc_I4_8:
						Modify(instruction, OpCodes.Ldc_I4, 8);
						break;
					case Code.Ldc_I4_S:
						instruction.OpCode = OpCodes.Ldc_I4;
						instruction.Operand = (int)(sbyte)instruction.Operand;
						break;
					case Code.Br_S:
						instruction.OpCode = OpCodes.Br;
						break;
					case Code.Brfalse_S:
						instruction.OpCode = OpCodes.Brfalse;
						break;
					case Code.Brtrue_S:
						instruction.OpCode = OpCodes.Brtrue;
						break;
					case Code.Beq_S:
						instruction.OpCode = OpCodes.Beq;
						break;
					case Code.Bge_S:
						instruction.OpCode = OpCodes.Bge;
						break;
					case Code.Bgt_S:
						instruction.OpCode = OpCodes.Bgt;
						break;
					case Code.Ble_S:
						instruction.OpCode = OpCodes.Ble;
						break;
					case Code.Blt_S:
						instruction.OpCode = OpCodes.Blt;
						break;
					case Code.Bne_Un_S:
						instruction.OpCode = OpCodes.Bne_Un;
						break;
					case Code.Bge_Un_S:
						instruction.OpCode = OpCodes.Bge_Un;
						break;
					case Code.Bgt_Un_S:
						instruction.OpCode = OpCodes.Bgt_Un;
						break;
					case Code.Ble_Un_S:
						instruction.OpCode = OpCodes.Ble_Un;
						break;
					case Code.Blt_Un_S:
						instruction.OpCode = OpCodes.Blt_Un;
						break;
					case Code.Leave_S:
						instruction.OpCode = OpCodes.Leave;
						break;
					}
				}
			}
		}

		public void Optimize()
		{
			foreach (Instruction instruction in m_instructions)
			{
				switch (instruction.OpCode.Code)
				{
				case Code.Ldarg:
				{
					int num2 = m_method.Parameters.IndexOf((ParameterDefinition)instruction.Operand);
					if (num2 == -1 && instruction.Operand == m_method.This)
					{
						num2 = 0;
					}
					else if (m_method.HasThis)
					{
						num2++;
					}
					switch (num2)
					{
					case 0:
						Modify(instruction, OpCodes.Ldarg_0, null);
						break;
					case 1:
						Modify(instruction, OpCodes.Ldarg_1, null);
						break;
					case 2:
						Modify(instruction, OpCodes.Ldarg_2, null);
						break;
					case 3:
						Modify(instruction, OpCodes.Ldarg_3, null);
						break;
					default:
						if (num2 < 256)
						{
							Modify(instruction, OpCodes.Ldarg_S, instruction.Operand);
						}
						break;
					}
					break;
				}
				case Code.Ldloc:
				{
					int num2 = m_variables.IndexOf((VariableDefinition)instruction.Operand);
					switch (num2)
					{
					case 0:
						Modify(instruction, OpCodes.Ldloc_0, null);
						break;
					case 1:
						Modify(instruction, OpCodes.Ldloc_1, null);
						break;
					case 2:
						Modify(instruction, OpCodes.Ldloc_2, null);
						break;
					case 3:
						Modify(instruction, OpCodes.Ldloc_3, null);
						break;
					default:
						if (num2 < 256)
						{
							Modify(instruction, OpCodes.Ldloc_S, instruction.Operand);
						}
						break;
					}
					break;
				}
				case Code.Stloc:
				{
					int num2 = m_variables.IndexOf((VariableDefinition)instruction.Operand);
					switch (num2)
					{
					case 0:
						Modify(instruction, OpCodes.Stloc_0, null);
						break;
					case 1:
						Modify(instruction, OpCodes.Stloc_1, null);
						break;
					case 2:
						Modify(instruction, OpCodes.Stloc_2, null);
						break;
					case 3:
						Modify(instruction, OpCodes.Stloc_3, null);
						break;
					default:
						if (num2 < 256)
						{
							Modify(instruction, OpCodes.Stloc_S, instruction.Operand);
						}
						break;
					}
					break;
				}
				case Code.Ldarga:
				{
					int num2 = m_method.Parameters.IndexOf((ParameterDefinition)instruction.Operand);
					if (num2 == -1 && instruction.Operand == m_method.This)
					{
						num2 = 0;
					}
					else if (m_method.HasThis)
					{
						num2++;
					}
					if (num2 < 256)
					{
						Modify(instruction, OpCodes.Ldarga_S, instruction.Operand);
					}
					break;
				}
				case Code.Ldloca:
					if (m_variables.IndexOf((VariableDefinition)instruction.Operand) < 256)
					{
						Modify(instruction, OpCodes.Ldloca_S, instruction.Operand);
					}
					break;
				case Code.Ldc_I4:
				{
					int num = (int)instruction.Operand;
					switch (num)
					{
					case -1:
						Modify(instruction, OpCodes.Ldc_I4_M1, null);
						break;
					case 0:
						Modify(instruction, OpCodes.Ldc_I4_0, null);
						break;
					case 1:
						Modify(instruction, OpCodes.Ldc_I4_1, null);
						break;
					case 2:
						Modify(instruction, OpCodes.Ldc_I4_2, null);
						break;
					case 3:
						Modify(instruction, OpCodes.Ldc_I4_3, null);
						break;
					case 4:
						Modify(instruction, OpCodes.Ldc_I4_4, null);
						break;
					case 5:
						Modify(instruction, OpCodes.Ldc_I4_5, null);
						break;
					case 6:
						Modify(instruction, OpCodes.Ldc_I4_6, null);
						break;
					case 7:
						Modify(instruction, OpCodes.Ldc_I4_7, null);
						break;
					case 8:
						Modify(instruction, OpCodes.Ldc_I4_8, null);
						break;
					default:
						if (num >= -128 && num < 128)
						{
							Modify(instruction, OpCodes.Ldc_I4_S, (sbyte)num);
						}
						break;
					}
					break;
				}
				}
			}
			OptimizeBranches();
		}

		private void OptimizeBranches()
		{
			ComputeOffsets();
			foreach (Instruction instruction in m_instructions)
			{
				if (instruction.OpCode.OperandType == OperandType.InlineBrTarget && OptimizeBranch(instruction))
				{
					ComputeOffsets();
				}
			}
		}

		private static bool OptimizeBranch(Instruction instr)
		{
			int num = ((Instruction)instr.Operand).Offset - (instr.Offset + instr.OpCode.Size + 4);
			if (num < -128 || num > 127)
			{
				return false;
			}
			switch (instr.OpCode.Code)
			{
			case Code.Br:
				instr.OpCode = OpCodes.Br_S;
				break;
			case Code.Brfalse:
				instr.OpCode = OpCodes.Brfalse_S;
				break;
			case Code.Brtrue:
				instr.OpCode = OpCodes.Brtrue_S;
				break;
			case Code.Beq:
				instr.OpCode = OpCodes.Beq_S;
				break;
			case Code.Bge:
				instr.OpCode = OpCodes.Bge_S;
				break;
			case Code.Bgt:
				instr.OpCode = OpCodes.Bgt_S;
				break;
			case Code.Ble:
				instr.OpCode = OpCodes.Ble_S;
				break;
			case Code.Blt:
				instr.OpCode = OpCodes.Blt_S;
				break;
			case Code.Bne_Un:
				instr.OpCode = OpCodes.Bne_Un_S;
				break;
			case Code.Bge_Un:
				instr.OpCode = OpCodes.Bge_Un_S;
				break;
			case Code.Bgt_Un:
				instr.OpCode = OpCodes.Bgt_Un_S;
				break;
			case Code.Ble_Un:
				instr.OpCode = OpCodes.Ble_Un_S;
				break;
			case Code.Blt_Un:
				instr.OpCode = OpCodes.Blt_Un_S;
				break;
			case Code.Leave:
				instr.OpCode = OpCodes.Leave_S;
				break;
			}
			return true;
		}

		private void ComputeOffsets()
		{
			int num = 0;
			foreach (Instruction instruction in m_instructions)
			{
				instruction.Offset = num;
				num += instruction.GetSize();
			}
		}

		private static void Modify(Instruction i, OpCode op, object operand)
		{
			i.OpCode = op;
			i.Operand = operand;
		}

		public void Accept(ICodeVisitor visitor)
		{
			visitor.VisitMethodBody(this);
			if (HasVariables)
			{
				m_variables.Accept(visitor);
			}
			m_instructions.Accept(visitor);
			if (HasExceptionHandlers)
			{
				m_exceptions.Accept(visitor);
			}
			if (HasScopes)
			{
				m_scopes.Accept(visitor);
			}
			visitor.TerminateMethodBody(this);
		}
	}
}
