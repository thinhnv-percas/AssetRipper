using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x200000B")]
	public interface IObiConstraintsBatch
	{
		[Token(Token = "0x17000013")]
		int constraintCount
		{
			[Token(Token = "0x6000127")]
			get;
		}

		[Token(Token = "0x17000014")]
		int activeConstraintCount
		{
			[Token(Token = "0x6000128")]
			get;
			[Token(Token = "0x6000129")]
			set;
		}

		[Token(Token = "0x17000015")]
		int initialActiveConstraintCount
		{
			[Token(Token = "0x600012A")]
			get;
			[Token(Token = "0x600012B")]
			set;
		}

		[Token(Token = "0x17000016")]
		Oni.ConstraintType constraintType
		{
			[Token(Token = "0x600012C")]
			get;
		}

		[Token(Token = "0x17000017")]
		IntPtr oniBatch
		{
			[Token(Token = "0x600012D")]
			get;
		}

		[Token(Token = "0x600012E")]
		IObiConstraintsBatch Clone();

		[Token(Token = "0x600012F")]
		void AddToSolver(IObiConstraints constraints);

		[Token(Token = "0x6000130")]
		void RemoveFromSolver(IObiConstraints constraints);

		[Token(Token = "0x6000131")]
		bool DeactivateConstraint(int constraintIndex);

		[Token(Token = "0x6000132")]
		bool ActivateConstraint(int constraintIndex);

		[Token(Token = "0x6000133")]
		void DeactivateAllConstraints();

		[Token(Token = "0x6000134")]
		void SetEnabled(bool enabled);

		[Token(Token = "0x6000135")]
		void Clear();

		[Token(Token = "0x6000136")]
		void GetParticlesInvolved(int index, List<int> particles);

		[Token(Token = "0x6000137")]
		void ParticlesSwapped(int index, int newIndex);
	}
}
