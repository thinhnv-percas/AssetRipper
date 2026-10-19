using Cpp2ILInjected;
using Unco.GameBootstrap.Core;
using UnityEngine;

namespace Unco.GameBootstrap.Scopes
{
	[Token(Token = "0x20007C6")]
	public class FeatureScopeRoot : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4001A04")]
		[FieldOffset(Offset = "0x20")]
		private string _featureTag;

		[Token(Token = "0x60020D9")]
		[Address(RVA = "0x3DBD460", Offset = "0x3DBD460", Length = "0x9C")]
		private void Awake()
		{
			if (string.IsNullOrEmpty(_featureTag))
			{
				Debug.LogError("[FeatureScopeRoot] FeatureTag is not set");
				base.enabled = false;
			}
		}

		[Token(Token = "0x60020DA")]
		[Address(RVA = "0x3DBD4FC", Offset = "0x3DBD4FC", Length = "0xB0")]
		private void OnDestroy()
		{
			GameBootstrapper gameBootstrapper = Object.FindFirstObjectByType<GameBootstrapper>();
			if (gameBootstrapper != null && gameBootstrapper._scopeRegistry != null)
			{
				gameBootstrapper._scopeRegistry.DisposeFeatureScope(_featureTag);
			}
		}

		[Token(Token = "0x60020DB")]
		[Address(RVA = "0x3DBD74C", Offset = "0x3DBD74C", Length = "0x8")]
		public FeatureScopeRoot()
		{
		}
	}
}
