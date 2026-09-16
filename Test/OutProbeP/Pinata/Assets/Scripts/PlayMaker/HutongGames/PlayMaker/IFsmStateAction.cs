using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x2000079")]
	public interface IFsmStateAction
	{
		[Token(Token = "0x170001CC")]
		bool Enabled
		{
			[Token(Token = "0x600064E")]
			get;
			[Token(Token = "0x600064F")]
			set;
		}

		[Token(Token = "0x6000650")]
		void Init(FsmState state);

		[Token(Token = "0x6000651")]
		void Reset();

		[Token(Token = "0x6000652")]
		void OnEnter();

		[Token(Token = "0x6000653")]
		void OnUpdate();

		[Token(Token = "0x6000654")]
		void OnGUI();

		[Token(Token = "0x6000655")]
		void OnFixedUpdate();

		[Token(Token = "0x6000656")]
		void OnLateUpdate();

		[Token(Token = "0x6000657")]
		void OnExit();

		[Token(Token = "0x6000658")]
		bool Event(FsmEvent fsmEvent);

		[Token(Token = "0x6000659")]
		void DoControllerColliderHit(ControllerColliderHit collider);

		[Token(Token = "0x600065A")]
		void DoCollisionEnter(Collision collisionInfo);

		[Token(Token = "0x600065B")]
		void DoCollisionStay(Collision collisionInfo);

		[Token(Token = "0x600065C")]
		void DoCollisionExit(Collision collisionInfo);

		[Token(Token = "0x600065D")]
		void DoTriggerEnter(Collider other);

		[Token(Token = "0x600065E")]
		void DoTriggerStay(Collider other);

		[Token(Token = "0x600065F")]
		void DoTriggerExit(Collider other);

		[Token(Token = "0x6000660")]
		void Log(string text);

		[Token(Token = "0x6000661")]
		void LogWarning(string text);

		[Token(Token = "0x6000662")]
		void LogError(string text);

		[Token(Token = "0x6000663")]
		string ErrorCheck();
	}
}
