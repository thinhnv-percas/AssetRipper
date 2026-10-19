using System;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;

namespace _game.CoreSystem.New.GameplayAreaSystem
{
	[Token(Token = "0x2000433")]
	public class MoldBgMono : MonoBehaviour, IDisposable, IDifficultyMaterialController
	{
		[Token(Token = "0x6001186")]
		[Address(RVA = "0x3CC19D4", Offset = "0x3CC19D4", Length = "0x1C")]
		public void Dispose()
		{
			GameObject go = base.gameObject;
			VisualHandlerUtility.DestroyGo(go);
		}

		[Token(Token = "0x6001187")]
		[Address(RVA = "0x3CC19F0", Offset = "0x3CC19F0", Length = "0x58")]
		public BackgroundMaterialController GetMatController()
		{
			return GetComponent<BackgroundMaterialController>();
		}

		[Token(Token = "0x6001188")]
		[Address(RVA = "0x3CC1A48", Offset = "0x3CC1A48", Length = "0x8")]
		public MoldBgMono()
		{
		}
	}
}
