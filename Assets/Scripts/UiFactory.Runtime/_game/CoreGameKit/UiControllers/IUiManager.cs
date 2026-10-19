using System;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.UiControllers.ScriptableObjects;

namespace _game.CoreGameKit.UiControllers
{
	[Token(Token = "0x2000017")]
	public interface IUiManager
	{
		[Token(Token = "0x6000081")]
		T Show<T>() where T : UIController;

		[Token(Token = "0x6000082")]
		UIController Show(Type type);

		[Token(Token = "0x6000083")]
		UIController Show(Type type, Instancer customInstancer);

		[Token(Token = "0x6000084")]
		T Get<T>() where T : UIController;

		[Token(Token = "0x6000085")]
		UIController Get(Type type);

		[Token(Token = "0x6000086")]
		bool Exist<T>() where T : UIController;

		[Token(Token = "0x6000087")]
		bool Exist(Type type);

		[Token(Token = "0x6000088")]
		void ForceHideIfExist<T>();

		[Token(Token = "0x6000089")]
		void ForceHideIfExist(Type type);

		[Token(Token = "0x600008A")]
		void Hide<T>() where T : UIController;

		[Token(Token = "0x600008B")]
		void Hide(Type type);

		[Token(Token = "0x600008C")]
		void Hide<T>(Action onComplete) where T : UIController;

		[Token(Token = "0x600008D")]
		void Hide(Type type, Action onComplete);

		[Token(Token = "0x600008E")]
		bool IsOverUI(Vector2 mousePosition);

		[Token(Token = "0x600008F")]
		UIConfig GetUiConfig<T>() where T : UIController;

		[Token(Token = "0x6000090")]
		IUiFactory GetFactory(CanvasLocation canvasLocation);
	}
}
