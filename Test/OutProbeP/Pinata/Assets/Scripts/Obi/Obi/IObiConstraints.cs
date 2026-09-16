using System.Collections.Generic;
using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x2000014")]
	public interface IObiConstraints
	{
		[Token(Token = "0x6000199")]
		ObiActor GetActor();

		[Token(Token = "0x600019A")]
		Oni.ConstraintType? GetConstraintType();

		[Token(Token = "0x600019B")]
		IList<IObiConstraintsBatch> GetBatchInterfaces();

		[Token(Token = "0x600019C")]
		bool AddBatch(IObiConstraintsBatch batch);

		[Token(Token = "0x600019D")]
		bool RemoveBatch(IObiConstraintsBatch batch);

		[Token(Token = "0x600019E")]
		int GetBatchCount();

		[Token(Token = "0x600019F")]
		void Clear();

		[Token(Token = "0x60001A0")]
		bool AddToSolver();

		[Token(Token = "0x60001A1")]
		bool RemoveFromSolver();

		[Token(Token = "0x60001A2")]
		void SetEnabled(bool enabled);

		[Token(Token = "0x60001A3")]
		int GetConstraintCount();

		[Token(Token = "0x60001A4")]
		int GetActiveConstraintCount();

		[Token(Token = "0x60001A5")]
		void DeactivateAllConstraints();

		[Token(Token = "0x60001A6")]
		IObiConstraints Clone(ObiActor actor);
	}
}
