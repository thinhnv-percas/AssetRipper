using System;
using Cpp2ILInjected;
using ElephantSDK;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace _game.CoreGameKit.IntroScene
{
	[Token(Token = "0x20005F6")]
	public class RemoteConfigReadyService
	{
		[Token(Token = "0x4001488")]
		[FieldOffset(Offset = "0x10")]
		private readonly AsyncInitTracker _tracker;

		[Token(Token = "0x4001489")]
		[FieldOffset(Offset = "0x18")]
		private AsyncInitHandle _handle;

		[Token(Token = "0x600197F")]
		[Address(RVA = "0x3D48FF0", Offset = "0x3D48FF0", Length = "0x198")]
		public RemoteConfigReadyService(AsyncInitTracker tracker)
		{
			_tracker = tracker;
			_handle = _tracker.Track();
			if (ElephantCore.Instance == null)
			{
				OnConfigLoaded();
			}
			else
			{
				ElephantCore.add_onRemoteConfigLoaded(OnConfigLoaded);
			}
		}

		[Token(Token = "0x6001980")]
		[Address(RVA = "0x3D49188", Offset = "0x3D49188", Length = "0x16C")]
		private void OnConfigLoaded()
		{
			//IL_0021: Expected O, but got I4
			int num = 187244544 + 1440;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X0_v41+E4]");
			bool flag = (nint)0 == 0;
			UnityEngine.Object instance = ElephantCore.Instance;
			if (!flag)
			{
				if (!(instance != null))
				{
					goto IL_0081;
				}
			}
			else
			{
				bool flag2 = ElephantCore.Instance != null;
				bool flag3 = !flag2;
				instance = ElephantCore.Instance;
				if (flag3)
				{
					goto IL_0081;
				}
			}
			OnRemoteConfigLoaded onRemoteConfigLoaded = OnConfigLoaded;
			ElephantCore.remove_onRemoteConfigLoaded(onRemoteConfigLoaded);
			AsyncInitHandle handle = _handle;
			bool flag4 = _handle == null;
			bool flag5 = !flag4;
			OnRemoteConfigLoaded value = onRemoteConfigLoaded;
			if (!flag5)
			{
				while (true)
				{
					NullReferenceException ex = new NullReferenceException();
					ElephantCore.remove_onRemoteConfigLoaded(value);
					handle = _handle;
					if (_handle != null)
					{
						break;
					}
					value = (OnRemoteConfigLoaded)(object)instance;
				}
			}
			goto IL_0090;
			IL_0090:
			handle.Complete();
			return;
			IL_0081:
			handle = _handle;
			goto IL_0090;
		}
	}
}
