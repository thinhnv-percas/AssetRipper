using Cpp2ILInjected;
using UnityEngine;

namespace ElephantSDK
{
	[Token(Token = "0x200096F")]
	public class ElephantPushLoad
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		[Token(Token = "0x6002851")]
		[Address(RVA = "0x3E513DC", Offset = "0x3E513DC", Length = "0x198")]
		private static void FirstSceneLoading()
		{
			//IL_0021: Expected O, but got I4
			int num = 187244544 + 1440;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v43+E4]");
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
			ElephantPushElephantManager adapter = new ElephantPushElephantManager();
			ElephantCore.Instance.AddAdapters(adapter);
			return;
			IL_0073:
			Debug.LogWarning("Elephant-Push failed to load due to uninitialized ElephantCore. Check scene loading order.");
		}

		[Token(Token = "0x6002852")]
		[Address(RVA = "0x3E51574", Offset = "0x3E51574", Length = "0x8")]
		public ElephantPushLoad()
		{
		}
	}
}
