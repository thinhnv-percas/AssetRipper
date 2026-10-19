using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace _game.CoreGameKit.UiControllers
{
	[RequireComponent(typeof(CanvasScaler))]
	[Token(Token = "0x200001C")]
	public class ScreenMatchUpdater : MonoBehaviour
	{
		[Token(Token = "0x200001D")]
		public enum MatchMode
		{
			[Token(Token = "0x400003A")]
			Ipad = 0,
			[Token(Token = "0x400003B")]
			IphoneX = 1,
			[Token(Token = "0x400003C")]
			FullHD = 2
		}

		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x20")]
		private MatchMode _editorMatchMode;

		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x28")]
		private CanvasScaler _canvasScaler;

		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x30")]
		public bool IsDebug;

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x81A5F44", Offset = "0x81A5F44", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv51.matchWidthOrHeight = 0f;\n\treturn;\nL_0018:\n\tv46 = UnityEngine.Component::GetComponent(this);\n\tthis._canvasScaler = v46;\n\tv51 = this._canvasScaler;\n")]
		private void Awake()
		{
			CanvasScaler component = GetComponent<CanvasScaler>();
			_canvasScaler = component;
			CanvasScaler canvasScaler = _canvasScaler;
			canvasScaler.matchWidthOrHeight = 0f;
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x81A5FD8", Offset = "0x81A5FD8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._canvasScaler;\n\tv0.matchWidthOrHeight = 0f;\n\treturn;\n")]
		private void Start()
		{
			CanvasScaler canvasScaler = _canvasScaler;
			canvasScaler.matchWidthOrHeight = 0f;
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x81A5FBC", Offset = "0x81A5FBC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._canvasScaler;\n\tv0.matchWidthOrHeight = 0f;\n\treturn;\n")]
		private void SetMatch()
		{
			CanvasScaler canvasScaler = _canvasScaler;
			canvasScaler.matchWidthOrHeight = 0f;
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x81A5FF4", Offset = "0x81A5FF4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		public static bool IsIpad()
		{
			return false;
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x81A5FFC", Offset = "0x81A5FFC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ScreenMatchUpdater()
		{
		}
	}
}
