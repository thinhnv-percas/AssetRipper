using Cpp2ILInjected;
using UnityEngine;

namespace ElephantSDK
{
	[Token(Token = "0x2000943")]
	public class ElephantAdjustLoad : MonoBehaviour
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		[Token(Token = "0x6002788")]
		[Address(RVA = "0x3E4229C", Offset = "0x3E4229C", Length = "0x198")]
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
			ElephantAdjustManager adapter = new ElephantAdjustManager();
			ElephantCore.Instance.AddAdapters(adapter);
			return;
			IL_0073:
			Debug.LogWarning("Elephant-Adjust failed to load due to uninitialized ElephantCore. Check scene loading order.");
		}

		[Token(Token = "0x6002789")]
		[Address(RVA = "0x3E4243C", Offset = "0x3E4243C", Length = "0x8")]
		public ElephantAdjustLoad()
		{
		}
	}
}
