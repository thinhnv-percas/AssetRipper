using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tools.AutoScreenshot
{
	[CreateAssetMenu(menuName = "CoreGameKit/Tools/Auto Screenshot Config")]
	[Token(Token = "0x20005C8")]
	public class AutoScreenshotConfig : ScriptableObject
	{
		[Token(Token = "0x4001406")]
		[FieldOffset(Offset = "0x18")]
		public int LevelRangeMin;

		[Token(Token = "0x4001407")]
		[FieldOffset(Offset = "0x1C")]
		public int LevelRangeMax;

		[Token(Token = "0x4001408")]
		[FieldOffset(Offset = "0x20")]
		public float DelayAfterCaptureBeforeNext;

		[Tooltip("RunState SS'den sonra Win mi Fail mi tetiklensin")]
		[Token(Token = "0x4001409")]
		[FieldOffset(Offset = "0x24")]
		public AfterRunAction AfterRunAction;

		[Tooltip("Boş ise mevcut çözünürlükte capture alınır. Doluysa listedeki tüm aktif çözünürlüklerde capture alınır.")]
		[Token(Token = "0x400140A")]
		[FieldOffset(Offset = "0x28")]
		public List<ScreenshotResolutionEntry> Resolutions;

		[Token(Token = "0x400140B")]
		[FieldOffset(Offset = "0x30")]
		public List<ScreenshotTriggerEntry> Triggers;

		[Token(Token = "0x60018D8")]
		[Address(RVA = "0x3D415E8", Offset = "0x3D415E8", Length = "0xEC")]
		public AutoScreenshotConfig()
		{
			LevelRangeMax = 100;
			List<ScreenshotResolutionEntry> resolutions = new List<ScreenshotResolutionEntry>();
			Resolutions = resolutions;
			List<ScreenshotTriggerEntry> triggers = new List<ScreenshotTriggerEntry>();
			Triggers = triggers;
		}
	}
}
