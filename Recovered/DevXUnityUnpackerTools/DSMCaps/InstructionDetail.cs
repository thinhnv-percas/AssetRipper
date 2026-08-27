using System;
using System.Linq;

namespace DSMCaps
{
	public abstract class InstructionDetail<TSelf, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId, TRegister, TRegisterId> where TSelf : InstructionDetail<TSelf, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId, TRegister, TRegisterId> where TDisassembleMode : Enum where TGroup : InstructionGroup<TGroupId> where TGroupId : Enum where TInstruction : Instruction<TInstruction, TSelf, TDisassembleMode, TGroup, TGroupId, TInstructionId, TRegister, TRegisterId> where TInstructionId : Enum where TRegister : Register<TRegisterId> where TRegisterId : Enum
	{
		internal readonly TRegister[] _allReadRegisters;

		internal readonly TRegister[] _allWrittenRegisters;

		internal readonly Lazy<TRegister[]> _explicitlyReadRegisters;

		internal readonly Lazy<TRegister[]> _explicitlyWrittenRegisters;

		internal readonly TGroup[] _groups;

		internal readonly TRegister[] _implicitlyReadRegisters;

		internal readonly TRegister[] _implicitlyWrittenRegisters;

		public TRegister[] AllReadRegisters
		{
			get
			{
				CapstoneDisassembler.ThrowIfDietModeIsEnabled();
				if (IsDisassembleArchitectureUnsupported())
				{
					throw new NotSupportedException("An operation is unsupported.");
				}
				return _allReadRegisters;
			}
		}

		public TRegister[] AllWrittenRegisters
		{
			get
			{
				CapstoneDisassembler.ThrowIfDietModeIsEnabled();
				if (IsDisassembleArchitectureUnsupported())
				{
					throw new NotSupportedException("An operation is unsupported.");
				}
				return _allWrittenRegisters;
			}
		}

		public DisassembleArchitecture DisassembleArchitecture
		{
			get;
		}

		public TDisassembleMode DisassembleMode
		{
			get;
		}

		public TRegister[] ExplicitlyReadRegisters
		{
			get
			{
				CapstoneDisassembler.ThrowIfDietModeIsEnabled();
				if (IsDisassembleArchitectureUnsupported())
				{
					throw new NotSupportedException("An operation is unsupported.");
				}
				return _explicitlyReadRegisters.Value;
			}
		}

		public TRegister[] ExplicitlyWrittenRegisters
		{
			get
			{
				CapstoneDisassembler.ThrowIfDietModeIsEnabled();
				if (IsDisassembleArchitectureUnsupported())
				{
					throw new NotSupportedException("An operation is unsupported.");
				}
				return _explicitlyWrittenRegisters.Value;
			}
		}

		public TGroup[] Groups
		{
			get
			{
				CapstoneDisassembler.ThrowIfDietModeIsEnabled();
				return _groups;
			}
		}

		public TRegister[] ImplicitlyReadRegisters
		{
			get
			{
				CapstoneDisassembler.ThrowIfDietModeIsEnabled();
				return _implicitlyReadRegisters;
			}
		}

		public TRegister[] ImplicitlyWrittenRegisters
		{
			get
			{
				CapstoneDisassembler.ThrowIfDietModeIsEnabled();
				return _implicitlyWrittenRegisters;
			}
		}

		public bool IsDietModeEnabled => CapstoneDisassembler.IsDietModeEnabled;

		internal InstructionDetail(InstructionDetailBuilder<TSelf, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId, TRegister, TRegisterId> builder)
		{
			_allReadRegisters = builder.AllReadRegisters;
			_allWrittenRegisters = builder.AllWrittenRegisters;
			DisassembleArchitecture = builder.DisassembleArchitecture;
			DisassembleMode = builder.DisassembleMode;
			_explicitlyReadRegisters = new Lazy<TRegister[]>(OnExplicitlyReadRegistersLazyInitialization);
			_explicitlyWrittenRegisters = new Lazy<TRegister[]>(OnExplicitlyWrittenRegistersLazyInitialization);
			_groups = builder.Groups;
			_implicitlyReadRegisters = builder.ImplicitlyReadRegisters;
			_implicitlyWrittenRegisters = builder.ImplicitlyWrittenRegisters;
		}

		public bool BelongsToGroup(string instructionGroupName)
		{
			return Groups.Any((TGroup g) => g.Name == instructionGroupName);
		}

		public bool BelongsToGroup(TGroupId instructionGroupId)
		{
			return Groups.Any((TGroup g) => g.Id.Equals(instructionGroupId));
		}

		internal bool IsDisassembleArchitectureUnsupported()
		{
			if (DisassembleArchitecture != DisassembleArchitecture.M68K && DisassembleArchitecture != DisassembleArchitecture.Mips && DisassembleArchitecture != DisassembleArchitecture.PowerPc)
			{
				return DisassembleArchitecture == DisassembleArchitecture.XCore;
			}
			return true;
		}

		public bool IsRegisterExplicitlyRead(string registerName)
		{
			return ExplicitlyReadRegisters.Any((TRegister r) => r.Name == registerName);
		}

		public bool IsRegisterExplicitlyRead(TRegisterId registerId)
		{
			return ExplicitlyReadRegisters.Any((TRegister r) => r.Id.Equals(registerId));
		}

		public bool IsRegisterExplicitlyWritten(string registerName)
		{
			return ExplicitlyWrittenRegisters.Any((TRegister r) => r.Name == registerName);
		}

		public bool IsRegisterExplicitlyWritten(TRegisterId registerId)
		{
			return ExplicitlyWrittenRegisters.Any((TRegister r) => r.Id.Equals(registerId));
		}

		public bool IsRegisterImplicitlyRead(string registerName)
		{
			return ImplicitlyReadRegisters.Any((TRegister r) => r.Name == registerName);
		}

		public bool IsRegisterImplicitlyRead(TRegisterId registerId)
		{
			return ImplicitlyReadRegisters.Any((TRegister r) => r.Id.Equals(registerId));
		}

		public bool IsRegisterImplicitlyWritten(string registerName)
		{
			return ImplicitlyWrittenRegisters.Any((TRegister r) => r.Name == registerName);
		}

		public bool IsRegisterImplicitlyWritten(TRegisterId registerId)
		{
			return ImplicitlyWrittenRegisters.Any((TRegister r) => r.Id.Equals(registerId));
		}

		public bool IsRegisterRead(string registerName)
		{
			if (!IsDisassembleArchitectureUnsupported())
			{
				return AllReadRegisters.Any((TRegister r) => r.Name == registerName);
			}
			return ImplicitlyReadRegisters.Any((TRegister r) => r.Name == registerName);
		}

		public bool IsRegisterRead(TRegisterId registerId)
		{
			if (!IsDisassembleArchitectureUnsupported())
			{
				return AllReadRegisters.Any((TRegister r) => r.Id.Equals(registerId));
			}
			return ImplicitlyReadRegisters.Any((TRegister r) => r.Id.Equals(registerId));
		}

		public bool IsRegisterWritten(string registerName)
		{
			if (!IsDisassembleArchitectureUnsupported())
			{
				return AllWrittenRegisters.Any((TRegister r) => r.Name == registerName);
			}
			return ImplicitlyWrittenRegisters.Any((TRegister r) => r.Name == registerName);
		}

		public bool IsRegisterWritten(TRegisterId registerId)
		{
			if (!IsDisassembleArchitectureUnsupported())
			{
				return AllWrittenRegisters.Any((TRegister r) => r.Id.Equals(registerId));
			}
			return ImplicitlyWrittenRegisters.Any((TRegister r) => r.Id.Equals(registerId));
		}

		internal TRegister[] OnExplicitlyReadRegistersLazyInitialization()
		{
			return _allReadRegisters.Except(_implicitlyReadRegisters).ToArray();
		}

		internal TRegister[] OnExplicitlyWrittenRegistersLazyInitialization()
		{
			return _allWrittenRegisters.Except(_implicitlyWrittenRegisters).ToArray();
		}
	}
}
