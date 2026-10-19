using System;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.UiControllers.ScriptableObjects;

namespace _game.CoreGameKit.UiControllers
{
	[Token(Token = "0x2000015")]
	public interface IUiFactory
	{
		[Token(Token = "0x17000004")]
		RectTransform RectTransform
		{
			[Token(Token = "0x6000069")]
			get;
		}

		[Token(Token = "0x600006A")]
		UIController Show(Type type);

		[Token(Token = "0x600006B")]
		UIController Show(Type type, Instancer customInstancer);

		[Token(Token = "0x600006C")]
		UIController Get(Type type);

		[Token(Token = "0x600006D")]
		bool Exist(Type type);

		[Token(Token = "0x600006E")]
		void ForceHideIfExist(Type type);

		[Token(Token = "0x600006F")]
		void ForceHideIfExist<T>() where T : UIController;

		[Token(Token = "0x6000070")]
		void Internal_Show<T>(T uiController) where T : UIController;

		[Token(Token = "0x6000071")]
		void Hide(UIController uiController, bool shouldRemove = true, Action onComplete = null);

		[Token(Token = "0x6000072")]
		void RemoveFromScene(UIController uiController);

		[Token(Token = "0x6000073")]
		void ForceHide(UIController uiController);

		[Token(Token = "0x6000074")]
		LocationData GetLocation(UILocation location);
	}
}
