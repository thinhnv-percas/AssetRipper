using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using _game.CoreGameKit.UiControllers.ScriptableObjects;

namespace _game.CoreGameKit.UiControllers
{
	[Token(Token = "0x2000016")]
	public interface IUiFactoryDataStore
	{
		[Token(Token = "0x6000075")]
		UIConfig GetUiConfig(Type type);

		[Token(Token = "0x6000076")]
		UIConfig GetUiConfig<T>() where T : UIController;

		[Token(Token = "0x6000077")]
		UIConfig GetUiConfig(UIController controller);

		[Token(Token = "0x6000078")]
		UIController GetUiControllerFromScene(Type type);

		[Token(Token = "0x6000079")]
		T GetUiControllerFromScene<T>() where T : UIController;

		[Token(Token = "0x600007A")]
		void AddToScene(UIController uiController);

		[Token(Token = "0x600007B")]
		void AddControllerToOrder(UIController uiController);

		[Token(Token = "0x600007C")]
		void RemoveFromScene(UIController uiController);

		[Token(Token = "0x600007D")]
		void UpdateOrderInScene(UIController sceneCache);

		[Token(Token = "0x600007E")]
		UIController GetSceneElement(UIController controller);

		[Token(Token = "0x600007F")]
		List<UIController> GetUiOrder();

		[Token(Token = "0x6000080")]
		List<UIController> GetSceneUiControllers();
	}
}
