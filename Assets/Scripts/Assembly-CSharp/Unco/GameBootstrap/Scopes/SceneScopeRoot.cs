using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.GameBootstrap.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unco.GameBootstrap.Scopes
{
	[Token(Token = "0x20007C8")]
	public class SceneScopeRoot : MonoBehaviour
	{
		[Token(Token = "0x60020DE")]
		[Address(RVA = "0x3DBD864", Offset = "0x3DBD864", Length = "0x148")]
		private void Awake()
		{
			GameBootstrapper gameBootstrapper = Object.FindFirstObjectByType<GameBootstrapper>();
			if (gameBootstrapper == null)
			{
				Debug.LogWarning("[SceneScopeRoot] GameBootstrapper not found. Scene scope will use GlobalScope.");
				return;
			}
			Scene activeScene = SceneManager.GetActiveScene();
			Scene scene = activeScene;
			string sceneName = scene.name;
			if (gameBootstrapper._scopeRegistry != null)
			{
				ContainerInstance containerInstance = gameBootstrapper._scopeRegistry.CreateSceneScope(sceneName);
			}
		}

		[Token(Token = "0x60020DF")]
		[Address(RVA = "0x3DBDB2C", Offset = "0x3DBDB2C", Length = "0x9C")]
		private void OnDestroy()
		{
			GameBootstrapper gameBootstrapper = Object.FindFirstObjectByType<GameBootstrapper>();
			if (gameBootstrapper != null && gameBootstrapper._scopeRegistry != null)
			{
				gameBootstrapper._scopeRegistry.DisposeSceneScope();
			}
		}

		[Token(Token = "0x60020E0")]
		[Address(RVA = "0x3DBDD44", Offset = "0x3DBDD44", Length = "0x8")]
		public SceneScopeRoot()
		{
		}
	}
}
