using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreSystem.FrameSystem;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;

namespace _game.CoreSystem.New.GameplayAreaSystem
{
	[Token(Token = "0x2000431")]
	public class GameplayAreaController : MonoBehaviour, IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4000D2E")]
		[FieldOffset(Offset = "0x28")]
		private FramePresetConfig m_config;

		[Token(Token = "0x17000165")]
		[field: Token(Token = "0x4000D2D")]
		[field: FieldOffset(Offset = "0x20")]
		public GameObject ConveyorInstance
		{
			[Token(Token = "0x6001180")]
			[Address(RVA = "0x3CC191C", Offset = "0x3CC191C", Length = "0x8")]
			get;
			[Token(Token = "0x6001181")]
			[Address(RVA = "0x3CC1924", Offset = "0x3CC1924", Length = "0x8")]
			set;
		}

		[Inject(false)]
		[Token(Token = "0x6001182")]
		[Address(RVA = "0x3CC192C", Offset = "0x3CC192C", Length = "0x84")]
		public void Construct()
		{
			FramePresetConfig config = m_config;
			Transform parent = base.transform;
			GameObject gameObject = VisualHandlerUtility.Instantiate(config.ConveyorPrefab, parent);
			ConveyorInstance = gameObject;
		}

		[Token(Token = "0x6001183")]
		[Address(RVA = "0x3CC19B0", Offset = "0x3CC19B0", Length = "0x1C")]
		public void Dispose()
		{
			GameObject go = base.gameObject;
			VisualHandlerUtility.DestroyGo(go);
		}

		[Token(Token = "0x6001184")]
		[Address(RVA = "0x3CC19CC", Offset = "0x3CC19CC", Length = "0x8")]
		public GameplayAreaController()
		{
		}
	}
}
