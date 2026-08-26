using System;
using System.Runtime.CompilerServices;

namespace DSMCaps
{
	internal abstract class InstructionDetailBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId, TRegister, TRegisterId> where TDetail : InstructionDetail<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId, TRegister, TRegisterId> where TDisassembleMode : Enum where TGroup : InstructionGroup<TGroupId> where TGroupId : Enum where TInstruction : Instruction<TInstruction, TDetail, TDisassembleMode, TGroup, TGroupId, TInstructionId, TRegister, TRegisterId> where TInstructionId : Enum where TRegister : Register<TRegisterId> where TRegisterId : Enum
	{
		internal TRegister[] AllReadRegisters
		{
			get;
			private set;
		}

		internal TRegister[] AllWrittenRegisters
		{
			get;
			private set;
		}

		internal DisassembleArchitecture DisassembleArchitecture
		{
			get;
			private set;
		}

		internal TDisassembleMode DisassembleMode
		{
			get;
			private set;
		}

		internal TGroup[] Groups
		{
			get;
			private set;
		}

		internal TRegister[] ImplicitlyReadRegisters
		{
			get;
			private set;
		}

		internal TRegister[] ImplicitlyWrittenRegisters
		{
			get;
			private set;
		}

		internal virtual void Build(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020 cNativeInstructionDetail = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A(hInstruction).GetValueOrDefault();
			DisassembleArchitecture = disassembler.DisassembleArchitecture;
			DisassembleMode = CreateDisassembleMode(disassembler.NativeDisassembleMode);
			_003CBuild_003Eg__SetAccessedRegisters_007C28_0(this, disassembler, hInstruction);
			_003CBuild_003Eg__SetGroups_007C28_1(this, disassembler, ref cNativeInstructionDetail);
			_003CBuild_003Eg__SetImplicitlyReadRegisters_007C28_2(this, disassembler, ref cNativeInstructionDetail);
			_003CBuild_003Eg__SetImplicitlyWrittenRegisters_007C28_3(this, disassembler, ref cNativeInstructionDetail);
		}

		private protected abstract TDisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode);

		private protected abstract TGroup CreateInstructionGroup(CapstoneDisassembler disassembler, byte instructionGroupId);

		private protected abstract TRegister CreateRegister(CapstoneDisassembler disassembler, short registerId);

		[CompilerGenerated]
		private static void _003CBuild_003Eg__SetAccessedRegisters_007C28_0(InstructionDetailBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId, TRegister, TRegisterId> @this, CapstoneDisassembler cDisassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A cHInstruction)
		{
			@this.AllReadRegisters = new TRegister[0];
			@this.AllWrittenRegisters = new TRegister[0];
			if (!CapstoneDisassembler.IsDietModeEnabled && cDisassembler.DisassembleArchitecture != DisassembleArchitecture.M68K && cDisassembler.DisassembleArchitecture != DisassembleArchitecture.Mips && cDisassembler.DisassembleArchitecture != DisassembleArchitecture.PowerPc && cDisassembler.DisassembleArchitecture != DisassembleArchitecture.XCore)
			{
				Tuple<short[], short[]> tuple = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A(cDisassembler.Handle, cHInstruction);
				@this.AllReadRegisters = new TRegister[tuple.Item1.Length];
				for (int i = 0; i < @this.AllReadRegisters.Length; i++)
				{
					short registerId = tuple.Item1[i];
					@this.AllReadRegisters[i] = @this.CreateRegister(cDisassembler, registerId);
				}
				@this.AllWrittenRegisters = new TRegister[tuple.Item2.Length];
				for (int j = 0; j < @this.AllWrittenRegisters.Length; j++)
				{
					short registerId2 = tuple.Item2[j];
					@this.AllWrittenRegisters[j] = @this.CreateRegister(cDisassembler, registerId2);
				}
			}
		}

		[CompilerGenerated]
		private static void _003CBuild_003Eg__SetGroups_007C28_1(InstructionDetailBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId, TRegister, TRegisterId> @this, CapstoneDisassembler cDisassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020 cNativeInstructionDetail)
		{
			@this.Groups = new TGroup[cNativeInstructionDetail.GroupCount];
			if (!CapstoneDisassembler.IsDietModeEnabled)
			{
				for (int i = 0; i < @this.Groups.Length; i++)
				{
					byte instructionGroupId = cNativeInstructionDetail.Groups[i];
					@this.Groups[i] = @this.CreateInstructionGroup(cDisassembler, instructionGroupId);
				}
			}
		}

		[CompilerGenerated]
		private static void _003CBuild_003Eg__SetImplicitlyReadRegisters_007C28_2(InstructionDetailBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId, TRegister, TRegisterId> @this, CapstoneDisassembler cDisassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020 cNativeInstructionDetail)
		{
			@this.ImplicitlyReadRegisters = new TRegister[cNativeInstructionDetail.ImplicitlyReadRegisterCount];
			if (!CapstoneDisassembler.IsDietModeEnabled)
			{
				for (int i = 0; i < @this.ImplicitlyReadRegisters.Length; i++)
				{
					short registerId = cNativeInstructionDetail.ImplicitlyReadRegisters[i];
					@this.ImplicitlyReadRegisters[i] = @this.CreateRegister(cDisassembler, registerId);
				}
			}
		}

		[CompilerGenerated]
		private static void _003CBuild_003Eg__SetImplicitlyWrittenRegisters_007C28_3(InstructionDetailBuilder<TDetail, TDisassembleMode, TGroup, TGroupId, TInstruction, TInstructionId, TRegister, TRegisterId> @this, CapstoneDisassembler cDisassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020 cNativeInstructionDetail)
		{
			@this.ImplicitlyWrittenRegisters = new TRegister[cNativeInstructionDetail.ImplicitlyWrittenRegisterCount];
			if (!CapstoneDisassembler.IsDietModeEnabled)
			{
				for (int i = 0; i < @this.ImplicitlyWrittenRegisters.Length; i++)
				{
					short registerId = cNativeInstructionDetail.ImplicitlyWrittenRegisters[i];
					@this.ImplicitlyWrittenRegisters[i] = @this.CreateRegister(cDisassembler, registerId);
				}
			}
		}
	}
}
