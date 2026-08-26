using System;
using System.Reflection.Emit;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public sealed class LocalVariable : INamedBlockVariable, ILocalVariable
	{
		[Flags]
		public enum Flags
		{
			Used = 0x1,
			IsThis = 0x2,
			AddressTaken = 0x4,
			CompilerGenerated = 0x8,
			Constant = 0x10,
			ForeachVariable = 0x20,
			FixedVariable = 0x40,
			UsingVariable = 0x80,
			IsLocked = 0x100,
			ReadonlyMask = 0xE0
		}

		private TypeSpec type;

		private readonly string name;

		private readonly Location loc;

		private readonly Block block;

		private Flags flags;

		private Constant const_value;

		public VariableInfo VariableInfo;

		private HoistedVariable hoisted_variant;

		private LocalBuilder builder;

		public bool AddressTaken => (flags & Flags.AddressTaken) != (Flags)0;

		public Block Block => block;

		public Constant ConstantValue
		{
			get
			{
				return const_value;
			}
			set
			{
				const_value = value;
			}
		}

		public HoistedVariable HoistedVariant
		{
			get
			{
				return hoisted_variant;
			}
			set
			{
				hoisted_variant = value;
			}
		}

		public bool IsDeclared => type != null;

		public bool IsCompilerGenerated => (flags & Flags.CompilerGenerated) != (Flags)0;

		public bool IsConstant => (flags & Flags.Constant) != (Flags)0;

		public bool IsLocked
		{
			get
			{
				return (flags & Flags.IsLocked) != (Flags)0;
			}
			set
			{
				flags = (value ? (flags | Flags.IsLocked) : (flags & ~Flags.IsLocked));
			}
		}

		public bool IsThis => (flags & Flags.IsThis) != (Flags)0;

		public bool IsFixed => (flags & Flags.FixedVariable) != (Flags)0;

		bool INamedBlockVariable.IsParameter => false;

		public bool IsReadonly => (flags & Flags.ReadonlyMask) != (Flags)0;

		public Location Location => loc;

		public string Name => name;

		public TypeSpec Type
		{
			get
			{
				return type;
			}
			set
			{
				type = value;
			}
		}

		public LocalVariable(Block block, string name, Location loc)
		{
			this.block = block;
			this.name = name;
			this.loc = loc;
		}

		public LocalVariable(Block block, string name, Flags flags, Location loc)
			: this(block, name, loc)
		{
			this.flags = flags;
		}

		public LocalVariable(LocalVariable li, string name, Location loc)
			: this(li.block, name, li.flags, loc)
		{
		}

		public void CreateBuilder(EmitContext ec)
		{
			if ((flags & Flags.Used) == (Flags)0)
			{
				if (VariableInfo == null)
				{
					throw new InternalErrorException("VariableInfo is null and the variable `{0}' is not used", name);
				}
				if (VariableInfo.IsEverAssigned)
				{
					ec.Report.Warning(219, 3, Location, "The variable `{0}' is assigned but its value is never used", Name);
				}
				else
				{
					ec.Report.Warning(168, 3, Location, "The variable `{0}' is declared but never used", Name);
				}
			}
			if (HoistedVariant != null)
			{
				return;
			}
			if (builder != null)
			{
				if ((flags & Flags.CompilerGenerated) != 0)
				{
					return;
				}
				throw new InternalErrorException("Already created variable `{0}'", name);
			}
			builder = ec.DeclareLocal(Type, IsFixed);
			if (!ec.HasSet(BuilderContext.Options.OmitDebugInfo) && (flags & Flags.CompilerGenerated) == (Flags)0)
			{
				ec.DefineLocalVariable(name, builder);
			}
		}

		public static LocalVariable CreateCompilerGenerated(TypeSpec type, Block block, Location loc)
		{
			return new LocalVariable(block, GetCompilerGeneratedName(block), Flags.Used | Flags.CompilerGenerated, loc)
			{
				Type = type
			};
		}

		public Expression CreateReferenceExpression(ResolveContext rc, Location loc)
		{
			if (IsConstant && const_value != null)
			{
				return Constant.CreateConstantFromValue(Type, const_value.GetValue(), loc);
			}
			return new LocalVariableReference(this, loc);
		}

		public void Emit(EmitContext ec)
		{
			if ((flags & Flags.CompilerGenerated) != 0)
			{
				CreateBuilder(ec);
			}
			ec.Emit(OpCodes.Ldloc, builder);
		}

		public void EmitAssign(EmitContext ec)
		{
			if ((flags & Flags.CompilerGenerated) != 0)
			{
				CreateBuilder(ec);
			}
			ec.Emit(OpCodes.Stloc, builder);
		}

		public void EmitAddressOf(EmitContext ec)
		{
			if ((flags & Flags.CompilerGenerated) != 0)
			{
				CreateBuilder(ec);
			}
			ec.Emit(OpCodes.Ldloca, builder);
		}

		public static string GetCompilerGeneratedName(Block block)
		{
			return "$locvar" + block.ParametersBlock.TemporaryLocalsCount++.ToString("X");
		}

		public string GetReadOnlyContext()
		{
			switch (flags & Flags.ReadonlyMask)
			{
			case Flags.FixedVariable:
				return "fixed variable";
			case Flags.ForeachVariable:
				return "foreach iteration variable";
			case Flags.UsingVariable:
				return "using variable";
			default:
				throw new InternalErrorException("Variable is not readonly");
			}
		}

		public bool IsThisAssigned(FlowAnalysisContext fc, Block block)
		{
			if (VariableInfo == null)
			{
				throw new Exception();
			}
			if (IsAssigned(fc))
			{
				return true;
			}
			return VariableInfo.IsFullyInitialized(fc, block.StartLocation);
		}

		public bool IsAssigned(FlowAnalysisContext fc)
		{
			return fc.IsDefinitelyAssigned(VariableInfo);
		}

		public void PrepareAssignmentAnalysis(BlockContext bc)
		{
			if ((flags & (Flags.CompilerGenerated | Flags.Constant | Flags.ForeachVariable | Flags.FixedVariable | Flags.UsingVariable)) == (Flags)0)
			{
				VariableInfo = VariableInfo.Create(bc, this);
			}
		}

		public void SetIsUsed()
		{
			flags |= Flags.Used;
		}

		public void SetHasAddressTaken()
		{
			flags |= (Flags.Used | Flags.AddressTaken);
		}

		public override string ToString()
		{
			return $"LocalInfo ({name},{type},{VariableInfo},{Location})";
		}
	}
}
