using System;
using System.Runtime.CompilerServices;

namespace DSMCaps
{
	internal abstract class InstructionBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TId, TRegister, TRegisterId> where TDetail : InstructionDetail<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TId, TRegister, TRegisterId> where TDisassembleMode : Enum where TGroup : InstructionGroup<TGroupId> where TGroupId : Enum where TInstruction : Instruction<TInstruction, TDetail, TDisassembleMode, TGroup, TGroupId, TId, TRegister, TRegisterId> where TId : Enum where TRegister : Register<TRegisterId> where TRegisterId : Enum
	{
		internal long Address
		{
			get;
			set;
		}

		internal byte[] Bytes
		{
			get;
			set;
		}

		internal TDetail Details
		{
			get;
			set;
		}

		internal DisassembleArchitecture DisassembleArchitecture
		{
			get;
			set;
		}

		internal TDisassembleMode DisassembleMode
		{
			get;
			set;
		}

		internal TId Id
		{
			get;
			set;
		}

		internal bool IsSkippedData
		{
			get;
			set;
		}

		internal string Mnemonic
		{
			get;
			set;
		}

		internal string Operand
		{
			get;
			set;
		}

		internal InstructionBuilder()
		{
			Address = 0L;
			Bytes = new byte[0];
			Details = null;
			Id = default(TId);
			IsSkippedData = false;
			Mnemonic = null;
			Operand = null;
		}

		internal virtual void Build(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A cNativeInstruction = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020(hInstruction);
			Address = cNativeInstruction.Address;
			DisassembleArchitecture = disassembler.DisassembleArchitecture;
			DisassembleMode = CreateDisassembleMode(disassembler.NativeDisassembleMode);
			Id = CreateId(cNativeInstruction.Id);
			IsSkippedData = (disassembler.EnableSkipDataMode && cNativeInstruction.Id <= 0);
			Mnemonic = ((!CapstoneDisassembler.IsDietModeEnabled) ? cNativeInstruction.Mnemonic : null);
			Operand = ((!CapstoneDisassembler.IsDietModeEnabled) ? cNativeInstruction.Operand : null);
			_003CBuild_003Eg__SetBytes_007C37_0(this, ref cNativeInstruction);
			_003CBuild_003Eg__SetDetails_007C37_1(this, disassembler, hInstruction, ref cNativeInstruction);
		}

		internal protected abstract TDetail CreateDetails(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction);

		internal protected abstract TDisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode);

		internal protected abstract TId CreateId(int id);

		[CompilerGenerated]
		internal static void _003CBuild_003Eg__SetBytes_007C37_0(InstructionBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TId, TRegister, TRegisterId> @this, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A cNativeInstruction)
		{
			@this.Bytes = new byte[0];
			if (cNativeInstruction.Id >= 0)
			{
				@this.Bytes = new byte[cNativeInstruction.Size];
				for (int i = 0; i < @this.Bytes.Length; i++)
				{
					@this.Bytes[i] = cNativeInstruction.Bytes[i];
				}
			}
		}

		[CompilerGenerated]
		internal static void _003CBuild_003Eg__SetDetails_007C37_1(InstructionBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TId, TRegister, TRegisterId> @this, CapstoneDisassembler cDisassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A cHInstruction, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A cNativeInstruction)
		{
			bool num = cNativeInstruction.Details != IntPtr.Zero;
			bool enableInstructionDetails = cDisassembler.EnableInstructionDetails;
			@this.Details = null;
			if ((num & enableInstructionDetails) && cNativeInstruction.Id > 0)
			{
				@this.Details = @this.CreateDetails(cDisassembler, cHInstruction);
			}
		}
	}
}
