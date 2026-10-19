using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors
{
	[Token(Token = "0x20006E0")]
	public class ShowUiBehavior<T> : IStateBehavior where T : UIController
	{
		[Token(Token = "0x400170A")]
		[FieldOffset(Offset = "0x0")]
		private UiManager _uiFactory;

		[Token(Token = "0x400170B")]
		[FieldOffset(Offset = "0x0")]
		private readonly float _delay;

		[Token(Token = "0x400170C")]
		[FieldOffset(Offset = "0x0")]
		private float _elapsed;

		[Token(Token = "0x400170D")]
		[FieldOffset(Offset = "0x0")]
		private bool _shown;

		[Token(Token = "0x6001D04")]
		[Address(RVA = "0x626B880", Offset = "0x626B880", Length = "0x34")]
		public ShowUiBehavior(float delay = 0f)
		{
			_delay = delay;
		}

		[Inject(false)]
		[Token(Token = "0x6001D05")]
		[Address(RVA = "0x626B8B4", Offset = "0x626B8B4", Length = "0x8")]
		public void Initialize(UiManager uiFactory)
		{
			_uiFactory = uiFactory;
		}

		[Token(Token = "0x6001D06")]
		[Address(RVA = "0x626B8BC", Offset = "0x626B8BC", Length = "0x44")]
		public void OnStateEnter()
		{
			_elapsed = 0f;
			_shown = false;
			bool flag = _delay == 0f;
			bool flag2 = _delay < 0f;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			if (flag4 || flag)
			{
				_shown = true;
				T val = _uiFactory.Show<T>();
			}
		}

		[Token(Token = "0x6001D07")]
		[Address(RVA = "0x626B900", Offset = "0x626B900", Length = "0x80")]
		public void OnStateUpdate()
		{
			if (!_shown)
			{
				float deltaTime = Time.deltaTime;
				if (!((_elapsed += deltaTime) < _delay))
				{
					_shown = true;
					T val = _uiFactory.Show<T>();
				}
			}
		}

		[Token(Token = "0x6001D08")]
		[Address(RVA = "0x626B980", Offset = "0x626B980", Length = "0x24")]
		public void OnStateExit()
		{
			_uiFactory.Hide<T>();
		}
	}
}
