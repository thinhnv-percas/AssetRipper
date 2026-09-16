using System;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000067")]
	public interface IDeviceCamera
	{
		[Token(Token = "0x6000509")]
		bool IsCameraAvailable(CameraType cameraType);

		[Token(Token = "0x600050A")]
		void TakePicture(CameraType cameraType, Action<string, MediaResult> callback);

		[Token(Token = "0x600050B")]
		void RecordVideo(CameraType cameraType, Action<string, MediaResult> callback);
	}
}
