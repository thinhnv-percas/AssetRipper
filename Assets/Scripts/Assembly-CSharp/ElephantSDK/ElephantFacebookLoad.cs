using Cpp2ILInjected;
using UnityEngine;

namespace ElephantSDK
{
	[Token(Token = "0x2000947")]
	public class ElephantFacebookLoad
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		[Token(Token = "0x600279B")]
		[Address(RVA = "0x3E433E0", Offset = "0x3E433E0", Length = "0x198")]
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
			ElephantFacebookManager adapter = new ElephantFacebookManager();
			ElephantCore.Instance.AddAdapters(adapter);
			return;
			IL_0073:
			Debug.LogWarning("Elephant-Facebook failed to load due to uninitialized ElephantCore. Check scene loading order.");
		}

		[Token(Token = "0x600279C")]
		[Address(RVA = "0x3E43580", Offset = "0x3E43580", Length = "0x8")]
		public ElephantFacebookLoad()
		{
		}
	}
}
