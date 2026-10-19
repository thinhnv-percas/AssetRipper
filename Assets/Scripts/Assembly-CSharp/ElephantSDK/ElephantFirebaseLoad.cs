using Cpp2ILInjected;
using UnityEngine;

namespace ElephantSDK
{
	[Token(Token = "0x2000949")]
	public class ElephantFirebaseLoad : MonoBehaviour
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		[Token(Token = "0x60027A2")]
		[Address(RVA = "0x3E43984", Offset = "0x3E43984", Length = "0x198")]
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
			ElephantFirebaseManager adapter = new ElephantFirebaseManager();
			ElephantCore.Instance.AddAdapters(adapter);
			return;
			IL_0073:
			Debug.LogWarning("Elephant-Firebase failed to load due to uninitialized ElephantCore. Check scene loading order.");
		}

		[Token(Token = "0x60027A3")]
		[Address(RVA = "0x3E43B24", Offset = "0x3E43B24", Length = "0x8")]
		public ElephantFirebaseLoad()
		{
		}
	}
}
