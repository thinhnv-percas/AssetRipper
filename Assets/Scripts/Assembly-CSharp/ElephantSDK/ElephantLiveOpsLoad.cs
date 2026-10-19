using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace ElephantSDK
{
	[Token(Token = "0x200094F")]
	public class ElephantLiveOpsLoad
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		[Token(Token = "0x60027C2")]
		[Address(RVA = "0x3E45D2C", Offset = "0x3E45D2C", Length = "0x1F0")]
		private static void FirstSceneLoading()
		{
			//IL_0021: Expected O, but got I4
			int num = 187244544 + 1440;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X0_v56+E4]");
			if ((nint)0 != 0)
			{
				if (ElephantCore.Instance == null)
				{
					goto IL_0073;
				}
			}
			else if (ElephantCore.Instance == null)
			{
				goto IL_0073;
			}
			ElephantLiveOpsManager elephantLiveOpsManager = new ElephantLiveOpsManager();
			List<Coroutine> activeDownloads = new List<Coroutine>();
			elephantLiveOpsManager._activeDownloads = activeDownloads;
			ElephantCore.Instance.AddAdapters(elephantLiveOpsManager);
			return;
			IL_0073:
			Debug.LogWarning("Elephant-Liveops failed to load due to uninitialized ElephantCore. Check scene loading order.");
		}

		[Token(Token = "0x60027C3")]
		[Address(RVA = "0x3E45FA8", Offset = "0x3E45FA8", Length = "0x8")]
		public ElephantLiveOpsLoad()
		{
		}
	}
}
