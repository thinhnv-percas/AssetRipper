using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.Gif
{
	[Token(Token = "0x20000FD")]
	internal delegate void DecodeCompleteCallback(int taskId, GifMetadata gifMetadata, GifFrameMetadata[] gifFrameMetadata, Color32[][] imageData);
}
