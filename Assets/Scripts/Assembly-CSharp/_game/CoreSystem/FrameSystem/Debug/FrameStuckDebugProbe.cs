using System;
using System.IO;
using System.Text;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unity.Mathematics;
using UnityEngine;
using _game.CoreSystem.FrameSystem.StuckAnalysis;

namespace _game.CoreSystem.FrameSystem.Debug
{
	[Token(Token = "0x2000504")]
	public class FrameStuckDebugProbe : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x40010C5")]
		[FieldOffset(Offset = "0x20")]
		private KeyCode m_triggerKey;

		[SerializeField]
		[Token(Token = "0x40010C6")]
		[FieldOffset(Offset = "0x24")]
		private float m_cellSize;

		[SerializeField]
		[Token(Token = "0x40010C7")]
		[FieldOffset(Offset = "0x28")]
		private float m_minRelevantY;

		[SerializeField]
		[Token(Token = "0x40010C8")]
		[FieldOffset(Offset = "0x2C")]
		private Color m_trappedColor;

		[Inject(false)]
		[Token(Token = "0x40010C9")]
		[FieldOffset(Offset = "0x40")]
		private FrameController _controller;

		[Token(Token = "0x40010CA")]
		[FieldOffset(Offset = "0x48")]
		private DrainageResult m_lastResult;

		[Token(Token = "0x40010CB")]
		[FieldOffset(Offset = "0x64")]
		private bool m_hasResult;

		[Token(Token = "0x60014F9")]
		[Address(RVA = "0x3D0A5B0", Offset = "0x3D0A5B0", Length = "0x3C")]
		private void Update()
		{
			if (Input.GetKeyDown(m_triggerKey))
			{
				RunAnalyze();
			}
		}

		[Token(Token = "0x60014FA")]
		[Address(RVA = "0x3D0A5EC", Offset = "0x3D0A5EC", Length = "0x4A4")]
		private void RunAnalyze()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameStuckDebugProbe::RunAnalyze");
		}

		[Token(Token = "0x60014FB")]
		[Address(RVA = "0x3D0AA90", Offset = "0x3D0AA90", Length = "0x250")]
		private static void WriteTextToFile(string fileName, string text)
		{
			string dataPath = Application.dataPath;
			string path = Path.Combine(dataPath, "..", "Logs");
			string fullPath = Path.GetFullPath(path);
			DirectoryInfo directoryInfo = Directory.CreateDirectory(fullPath);
			string text2 = Path.Combine(fullPath, fileName);
			File.WriteAllText(text2, text);
			string message = "[FrameStuckDebugProbe] Report written to " + text2;
			UnityEngine.Debug.Log(message);
		}

		[Token(Token = "0x60014FC")]
		[Address(RVA = "0x3D0ACE0", Offset = "0x3D0ACE0", Length = "0x9C")]
		private void OnDrawGizmos()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameStuckDebugProbe::OnDrawGizmos");
		}

		[Token(Token = "0x60014FD")]
		[Address(RVA = "0x3D0AD7C", Offset = "0x3D0AD7C", Length = "0x28")]
		public FrameStuckDebugProbe()
		{
			m_triggerKey = KeyCode.L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [9307F40]");
			m_cellSize = 0f;
			m_trappedColor.b = 1f / 128f;
		}
	}
}
