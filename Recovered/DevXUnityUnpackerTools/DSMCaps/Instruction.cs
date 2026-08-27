using System;

namespace DSMCaps
{
	public abstract class Instruction<TSelf, TDetail, TDisassembleMode, TGroup, TGroupId, TId, TRegister, TRegisterId> where TSelf : Instruction<TSelf, TDetail, TDisassembleMode, TGroup, TGroupId, TId, TRegister, TRegisterId> where TDetail : InstructionDetail<TDetail, TDisassembleMode, TGroup, TGroupId, TSelf, TId, TRegister, TRegisterId> where TDisassembleMode : Enum where TGroup : InstructionGroup<TGroupId> where TGroupId : Enum where TId : Enum where TRegister : Register<TRegisterId> where TRegisterId : Enum
	{
		internal readonly TDetail _details;

		internal readonly string _mnemonic;

		internal readonly string _operand;

		public long Address
		{
			get;
		}

		public byte[] Bytes
		{
			get;
		}

		public TDetail Details
		{
			get
			{
				if (_details == null)
				{
					throw new InvalidOperationException("An operation is invalid.");
				}
				return _details;
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

		public bool HasDetails => _details != null;

		public TId Id
		{
			get;
		}

		public bool IsDietModeEnabled => CapstoneDisassembler.IsDietModeEnabled;

		public bool IsSkippedData
		{
			get;
		}

		public string Mnemonic
		{
			get
			{
				CapstoneDisassembler.ThrowIfDietModeIsEnabled();
				return _mnemonic;
			}
		}

		public string Operand
		{
			get
			{
				CapstoneDisassembler.ThrowIfDietModeIsEnabled();
				return _operand;
			}
		}

		internal Instruction(InstructionBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TSelf, TId, TRegister, TRegisterId> builder)
		{
			Address = builder.Address;
			Bytes = builder.Bytes;
			_details = builder.Details;
			DisassembleArchitecture = builder.DisassembleArchitecture;
			DisassembleMode = builder.DisassembleMode;
			Id = builder.Id;
			IsSkippedData = builder.IsSkippedData;
			_mnemonic = builder.Mnemonic;
			_operand = builder.Operand;
		}
	}
}
