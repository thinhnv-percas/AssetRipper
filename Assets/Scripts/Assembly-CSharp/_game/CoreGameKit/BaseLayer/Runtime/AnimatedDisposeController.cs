using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using _game.CoreGameKit.BaseLayer.Controller;

namespace _game.CoreGameKit.BaseLayer.Runtime
{
	[Token(Token = "0x20006ED")]
	public class AnimatedDisposeController
	{
		[Token(Token = "0x400174D")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<IAnimatedDisposable> _animatedDisposables;

		[Token(Token = "0x6001D4C")]
		[Address(RVA = "0x3D76E8C", Offset = "0x3D76E8C", Length = "0x180")]
		public void PlayDisposeAnimations(Action onComplete)
		{
			List<object> list = ((IEnumerable<object>)_animatedDisposables).ToList();
			List<IAnimatedDisposable> activeDisposables = (List<IAnimatedDisposable>)(object)list;
			List<IAnimatedDisposable> list2 = activeDisposables;
			if (list2.Count != 0)
			{
				Action<IAnimatedDisposable> action = delegate(IAnimatedDisposable x)
				{
					Action<IAnimatedDisposable> onComplete2 = OnDisposed;
					x.DisposeAnimated(onComplete2);
				};
				_animatedDisposables.ForEach(action);
			}
			else if (onComplete != null)
			{
				onComplete();
			}
			[Token(Token = "0x6001D51")]
			[Address(RVA = "0x3D77250", Offset = "0x3D77250", Length = "0xA8")]
			void OnDisposed(IAnimatedDisposable obj)
			{
				IAnimatedDisposable item = default(IAnimatedDisposable);
				bool flag = activeDisposables.Remove(item);
				List<IAnimatedDisposable> list3 = activeDisposables;
				if (list3.Count == 0 && onComplete != null)
				{
					onComplete();
				}
			}
		}

		[Token(Token = "0x6001D4D")]
		[Address(RVA = "0x3D77014", Offset = "0x3D77014", Length = "0xB4")]
		public void Register(IAnimatedDisposable animator)
		{
			List<IAnimatedDisposable> animatedDisposables = _animatedDisposables;
			IAnimatedDisposable item = default(IAnimatedDisposable);
			animatedDisposables.Add(item);
		}

		[Token(Token = "0x6001D4E")]
		[Address(RVA = "0x3D770C8", Offset = "0x3D770C8", Length = "0x8C")]
		public AnimatedDisposeController()
		{
			List<IAnimatedDisposable> animatedDisposables = new List<IAnimatedDisposable>();
			_animatedDisposables = animatedDisposables;
		}
	}
}
