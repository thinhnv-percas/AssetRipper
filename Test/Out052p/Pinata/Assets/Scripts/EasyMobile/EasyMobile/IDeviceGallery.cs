using System;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x2000068")]
	public interface IDeviceGallery
	{
		[Token(Token = "0x600050C")]
		void Pick(Action<string, MediaResult[]> callback);

		[Token(Token = "0x600050D")]
		void SaveImage(Texture2D image, string name, ImageFormat format = ImageFormat.JPG, Action<string> callback = null);

		[Token(Token = "0x600050E")]
		void LoadImage(MediaResult media, Action<string, Texture2D> callback, int maxSize = -1);
	}
}
