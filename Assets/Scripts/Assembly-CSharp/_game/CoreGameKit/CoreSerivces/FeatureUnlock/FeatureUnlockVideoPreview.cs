using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace _game.CoreGameKit.CoreSerivces.FeatureUnlock
{
	[RequireComponent(typeof(RawImage))]
	[Token(Token = "0x2000619")]
	public class FeatureUnlockVideoPreview : MonoBehaviour
	{
		[Token(Token = "0x6001A25")]
		[Address(RVA = "0x3D51204", Offset = "0x3D51204", Length = "0x8")]
		public FeatureUnlockVideoPreview()
		{
		}
	}
}
