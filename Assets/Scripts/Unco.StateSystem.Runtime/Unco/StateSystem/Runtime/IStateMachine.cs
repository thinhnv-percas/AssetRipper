using System;
using Cpp2ILInjected;

namespace Unco.StateSystem.Runtime
{
	[Token(Token = "0x2000004")]
	public interface IStateMachine
	{
		[Token(Token = "0x17000001")]
		State CurrentState
		{
			[Token(Token = "0x6000004")]
			get;
		}

		[Token(Token = "0x14000001")]
		event Action<State, State> OnStateChanged;

		[Token(Token = "0x6000003")]
		void SetState(State state);

		[Token(Token = "0x6000007")]
		void Update();

		[Token(Token = "0x6000008")]
		void FixedUpdate();

		[Token(Token = "0x6000009")]
		void LateUpdate();
	}
}
