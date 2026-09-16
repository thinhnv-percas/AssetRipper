using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;

namespace TMPro
{
	[Token(Token = "0x200005B")]
	public class TMP_UpdateManager
	{
		[Token(Token = "0x40003F6")]
		private static TMP_UpdateManager s_Instance;

		[Token(Token = "0x40003F7")]
		[FieldOffset(Offset = "0x10")]
		private readonly List<TMP_Text> m_LayoutRebuildQueue;

		[Token(Token = "0x40003F8")]
		[FieldOffset(Offset = "0x18")]
		private Dictionary<int, int> m_LayoutQueueLookup;

		[Token(Token = "0x40003F9")]
		[FieldOffset(Offset = "0x20")]
		private readonly List<TMP_Text> m_GraphicRebuildQueue;

		[Token(Token = "0x40003FA")]
		[FieldOffset(Offset = "0x28")]
		private Dictionary<int, int> m_GraphicQueueLookup;

		[Token(Token = "0x40003FB")]
		[FieldOffset(Offset = "0x30")]
		private readonly List<TMP_Text> m_InternalUpdateQueue;

		[Token(Token = "0x40003FC")]
		[FieldOffset(Offset = "0x38")]
		private Dictionary<int, int> m_InternalUpdateLookup;

		[Token(Token = "0x1700013B")]
		public static TMP_UpdateManager instance
		{
			[Token(Token = "0x60004FE")]
			[Address(RVA = "0xC8EC5C", Offset = "0xC8EC5C", Length = "0x7C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60004FF")]
		[Address(RVA = "0xC8ECD8", Offset = "0xC8ECD8", Length = "0x1BC")]
		protected TMP_UpdateManager()
		{
		}

		[Token(Token = "0x6000500")]
		[Address(RVA = "0xC8EE94", Offset = "0xC8EE94", Length = "0x2C")]
		internal static void RegisterTextObjectForUpdate(TMP_Text textObject)
		{
		}

		[Token(Token = "0x6000501")]
		[Address(RVA = "0xC8EEC0", Offset = "0xC8EEC0", Length = "0xD4")]
		private void InternalRegisterTextObjectForUpdate(TMP_Text textObject)
		{
		}

		[Token(Token = "0x6000502")]
		[Address(RVA = "0xC8EF94", Offset = "0xC8EF94", Length = "0x2C")]
		public static void RegisterTextElementForLayoutRebuild(TMP_Text element)
		{
		}

		[Token(Token = "0x6000503")]
		[Address(RVA = "0xC8EFC0", Offset = "0xC8EFC0", Length = "0xD4")]
		private bool InternalRegisterTextElementForLayoutRebuild(TMP_Text element)
		{
			return false;
		}

		[Token(Token = "0x6000504")]
		[Address(RVA = "0xC8F094", Offset = "0xC8F094", Length = "0x2C")]
		public static void RegisterTextElementForGraphicRebuild(TMP_Text element)
		{
		}

		[Token(Token = "0x6000505")]
		[Address(RVA = "0xC8F0C0", Offset = "0xC8F0C0", Length = "0xD4")]
		private bool InternalRegisterTextElementForGraphicRebuild(TMP_Text element)
		{
			return false;
		}

		[Token(Token = "0x6000506")]
		[Address(RVA = "0xC8F194", Offset = "0xC8F194", Length = "0x4")]
		private void OnBeginFrameRendering(ScriptableRenderContext renderContext, Camera[] cameras)
		{
		}

		[Token(Token = "0x6000507")]
		[Address(RVA = "0xC8F36C", Offset = "0xC8F36C", Length = "0x4")]
		private void OnCameraPreCull(Camera cam)
		{
		}

		[Token(Token = "0x6000508")]
		[Address(RVA = "0xC8F198", Offset = "0xC8F198", Length = "0x1D4")]
		private void DoRebuilds()
		{
		}

		[Token(Token = "0x6000509")]
		[Address(RVA = "0xC8F370", Offset = "0xC8F370", Length = "0x2C")]
		internal static void UnRegisterTextObjectForUpdate(TMP_Text textObject)
		{
		}

		[Token(Token = "0x600050A")]
		[Address(RVA = "0xC8F440", Offset = "0xC8F440", Length = "0x4C")]
		public static void UnRegisterTextElementForRebuild(TMP_Text element)
		{
		}

		[Token(Token = "0x600050B")]
		[Address(RVA = "0xC8F48C", Offset = "0xC8F48C", Length = "0xA4")]
		private void InternalUnRegisterTextElementForGraphicRebuild(TMP_Text element)
		{
		}

		[Token(Token = "0x600050C")]
		[Address(RVA = "0xC8F530", Offset = "0xC8F530", Length = "0xA4")]
		private void InternalUnRegisterTextElementForLayoutRebuild(TMP_Text element)
		{
		}

		[Token(Token = "0x600050D")]
		[Address(RVA = "0xC8F39C", Offset = "0xC8F39C", Length = "0xA4")]
		private void InternalUnRegisterTextObjectForUpdate(TMP_Text textObject)
		{
		}
	}
}
