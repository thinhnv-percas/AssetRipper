using Cpp2ILInjected;
using UnityEngine;

namespace ElephantSDK
{
	[Token(Token = "0x200094E")]
	public class ElephantHelpShiftLoad
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		[Token(Token = "0x60027C0")]
		[Address(RVA = "0x3E45B8C", Offset = "0x3E45B8C", Length = "0x198")]
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
			ElephantHelpShift adapter = new ElephantHelpShift();
			ElephantCore.Instance.AddAdapters(adapter);
			return;
			IL_0073:
			Debug.LogWarning("Elephant-HelpShift failed to load due to uninitialized ElephantCore. Check scene loading order.");
		}

		[Token(Token = "0x60027C1")]
		[Address(RVA = "0x3E45D24", Offset = "0x3E45D24", Length = "0x8")]
		public ElephantHelpShiftLoad()
		{
		}
	}
}
