using System;
using Systems.FlowSystem.Scripts.Core;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreGameKit.Ui.UiControllers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Flows
{
	[Serializable]
	[Token(Token = "0x20005FB")]
	public class FollowGameObjectFlow : LevelBasedFlowStep
	{
		[SerializeField]
		[Token(Token = "0x400149B")]
		[FieldOffset(Offset = "0x60")]
		private GameObject m_example;

		[Inject(false)]
		[Token(Token = "0x400149C")]
		[FieldOffset(Offset = "0x68")]
		private UiManager _uiManager;

		[Token(Token = "0x400149D")]
		[FieldOffset(Offset = "0x70")]
		private SwipeTutorialUiController _swipeTutorial;

		[Token(Token = "0x17000265")]
		public override FlowId FlowId
		{
			[Token(Token = "0x6001991")]
			[Address(RVA = "0x3D4A75C", Offset = "0x3D4A75C", Length = "0x8")]
			get
			{
				return FlowId.ExampleFollowFlow;
			}
		}

		[Token(Token = "0x6001992")]
		[Address(RVA = "0x3D4A764", Offset = "0x3D4A764", Length = "0xA0")]
		protected override void StartTutorial()
		{
			GameObject gameObject = m_example.gameObject;
			GameObject target = UnityEngine.Object.Instantiate(gameObject);
			ShowTutorial(target);
		}

		[Token(Token = "0x6001993")]
		[Address(RVA = "0x3D4A804", Offset = "0x3D4A804", Length = "0x14C")]
		private void ShowTutorial(GameObject target)
		{
			SwipeTutorialUiController swipeTutorial = _uiManager.Show<SwipeTutorialUiController>();
			_swipeTutorial = swipeTutorial;
			GameObject gameObject = target.gameObject;
			Action onRequiredInputCompleted = OnComplete;
			Vector3 endWorldPoint = default(Vector3);
			endWorldPoint.x = Vector3.zero.x;
			endWorldPoint.y = Vector3.zero.y;
			endWorldPoint.z = Vector3.zero.z;
			_swipeTutorial.PlaySwipeFollowingGameObject(gameObject, endWorldPoint, onRequiredInputCompleted);
		}

		[Token(Token = "0x6001994")]
		[Address(RVA = "0x3D4A950", Offset = "0x3D4A950", Length = "0x8")]
		private void OnComplete()
		{
			SetFlowCompleted();
		}

		[Token(Token = "0x6001995")]
		[Address(RVA = "0x3D4A958", Offset = "0x3D4A958", Length = "0x8")]
		public FollowGameObjectFlow()
		{
		}
	}
}
