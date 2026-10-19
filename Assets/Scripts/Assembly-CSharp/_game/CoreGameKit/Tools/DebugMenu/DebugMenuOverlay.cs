using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tools.DebugMenu
{
	[Token(Token = "0x20005B1")]
	public class DebugMenuOverlay : MonoBehaviour
	{
		[Token(Token = "0x4001390")]
		private const float k_ButtonHeight = 36f;

		[Token(Token = "0x4001391")]
		private const float k_ButtonWidth = 140f;

		[Token(Token = "0x4001392")]
		private const float k_Padding = 6f;

		[Token(Token = "0x4001393")]
		[FieldOffset(Offset = "0x20")]
		internal DebugMenuController _controller;

		[Token(Token = "0x4001394")]
		[FieldOffset(Offset = "0x28")]
		private readonly List<PinnedTriggerHandle> _cache;

		[Token(Token = "0x4001395")]
		[FieldOffset(Offset = "0x30")]
		private int _cacheFrame;

		[Token(Token = "0x600184F")]
		[Address(RVA = "0x3D36DDC", Offset = "0x3D36DDC", Length = "0x8")]
		public void SetController(DebugMenuController controller)
		{
			_controller = controller;
		}

		[Token(Token = "0x6001850")]
		[Address(RVA = "0x3D36DE4", Offset = "0x3D36DE4", Length = "0x13C")]
		private void Update()
		{
			if (_controller == null)
			{
				return;
			}
			RefreshCacheIfNeeded();
			List<PinnedTriggerHandle> cache = _cache;
			int num = 0;
			while (num < cache.Count)
			{
				PinnedTriggerHandle pinnedTriggerHandle = cache[num];
				if (pinnedTriggerHandle.Hotkey != KeyCode.None && Input.GetKeyDown(pinnedTriggerHandle.Hotkey) && pinnedTriggerHandle.Invoke != null)
				{
					pinnedTriggerHandle.Invoke();
				}
				num++;
				cache = _cache;
			}
		}

		[Token(Token = "0x6001851")]
		[Address(RVA = "0x3D375C8", Offset = "0x3D375C8", Length = "0x3BC")]
		private unsafe void OnGUI()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugMenuOverlay::OnGUI");
		}

		[Token(Token = "0x6001852")]
		[Address(RVA = "0x3D36F20", Offset = "0x3D36F20", Length = "0x6A8")]
		private unsafe void RefreshCacheIfNeeded()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugMenuOverlay::RefreshCacheIfNeeded");
		}

		[Token(Token = "0x6001853")]
		[Address(RVA = "0x3D379E4", Offset = "0x3D379E4", Length = "0x94")]
		public DebugMenuOverlay()
		{
			List<PinnedTriggerHandle> cache = new List<PinnedTriggerHandle>();
			_cache = cache;
			_cacheFrame = -1;
		}
	}
}
