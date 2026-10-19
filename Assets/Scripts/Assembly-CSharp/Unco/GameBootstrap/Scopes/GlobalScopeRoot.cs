using Cpp2ILInjected;
using UnityEngine;

namespace Unco.GameBootstrap.Scopes
{
	[Token(Token = "0x20007C7")]
	public class GlobalScopeRoot : MonoBehaviour
	{
		[Token(Token = "0x60020DC")]
		[Address(RVA = "0x3DBD754", Offset = "0x3DBD754", Length = "0x108")]
		private void Awake()
		{
			int num = 187502592 + 96;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @4B00ED0 (UnityEngine.Object::FindFirstObjectByType, and 1 more at this address)");
			Object obj = default(Object);
			if (obj == null)
			{
				Debug.LogError("[GlobalScopeRoot] GameBootstrapper not found in scene. GlobalScope may not be initialized correctly.");
			}
		}

		[Token(Token = "0x60020DD")]
		[Address(RVA = "0x3DBD85C", Offset = "0x3DBD85C", Length = "0x8")]
		public GlobalScopeRoot()
		{
		}
	}
}
