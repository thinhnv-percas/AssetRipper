using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Profiling;

namespace TMPro
{
	[Token(Token = "0x20000A5")]
	public class TMP_UpdateManager
	{
		[Token(Token = "0x40005FA")]
		private static TMP_UpdateManager s_Instance;

		[Token(Token = "0x40005FB")]
		[FieldOffset(Offset = "0x10")]
		private readonly HashSet<int> m_LayoutQueueLookup;

		[Token(Token = "0x40005FC")]
		[FieldOffset(Offset = "0x18")]
		private readonly List<TMP_Text> m_LayoutRebuildQueue;

		[Token(Token = "0x40005FD")]
		[FieldOffset(Offset = "0x20")]
		private readonly HashSet<int> m_GraphicQueueLookup;

		[Token(Token = "0x40005FE")]
		[FieldOffset(Offset = "0x28")]
		private readonly List<TMP_Text> m_GraphicRebuildQueue;

		[Token(Token = "0x40005FF")]
		[FieldOffset(Offset = "0x30")]
		private readonly HashSet<int> m_InternalUpdateLookup;

		[Token(Token = "0x4000600")]
		[FieldOffset(Offset = "0x38")]
		private readonly List<TMP_Text> m_InternalUpdateQueue;

		[Token(Token = "0x4000601")]
		[FieldOffset(Offset = "0x40")]
		private readonly HashSet<int> m_CullingUpdateLookup;

		[Token(Token = "0x4000602")]
		[FieldOffset(Offset = "0x48")]
		private readonly List<TMP_Text> m_CullingUpdateQueue;

		[Token(Token = "0x4000603")]
		private static ProfilerMarker k_RegisterTextObjectForUpdateMarker;

		[Token(Token = "0x4000604")]
		private static ProfilerMarker k_RegisterTextElementForGraphicRebuildMarker;

		[Token(Token = "0x4000605")]
		private static ProfilerMarker k_RegisterTextElementForCullingUpdateMarker;

		[Token(Token = "0x4000606")]
		private static ProfilerMarker k_UnregisterTextObjectForUpdateMarker;

		[Token(Token = "0x4000607")]
		private static ProfilerMarker k_UnregisterTextElementForGraphicRebuildMarker;

		[Token(Token = "0x17000171")]
		private static TMP_UpdateManager instance
		{
			[Token(Token = "0x6000634")]
			[Address(RVA = "0x1614678", Offset = "0x1614678", Length = "0xA0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000635")]
		[Address(RVA = "0x1614718", Offset = "0x1614718", Length = "0x1AC")]
		private TMP_UpdateManager()
		{
		}

		[Token(Token = "0x6000636")]
		[Address(RVA = "0x16148C4", Offset = "0x16148C4", Length = "0x60")]
		internal static void RegisterTextObjectForUpdate(TMP_Text textObject)
		{
		}

		[Token(Token = "0x6000637")]
		[Address(RVA = "0x1614924", Offset = "0x1614924", Length = "0x110")]
		private void InternalRegisterTextObjectForUpdate(TMP_Text textObject)
		{
		}

		[Token(Token = "0x6000638")]
		[Address(RVA = "0x1614A34", Offset = "0x1614A34", Length = "0x60")]
		public static void RegisterTextElementForLayoutRebuild(TMP_Text element)
		{
		}

		[Token(Token = "0x6000639")]
		[Address(RVA = "0x1614A94", Offset = "0x1614A94", Length = "0x110")]
		private void InternalRegisterTextElementForLayoutRebuild(TMP_Text element)
		{
		}

		[Token(Token = "0x600063A")]
		[Address(RVA = "0x1614BA4", Offset = "0x1614BA4", Length = "0x60")]
		public static void RegisterTextElementForGraphicRebuild(TMP_Text element)
		{
		}

		[Token(Token = "0x600063B")]
		[Address(RVA = "0x1614C04", Offset = "0x1614C04", Length = "0x110")]
		private void InternalRegisterTextElementForGraphicRebuild(TMP_Text element)
		{
		}

		[Token(Token = "0x600063C")]
		[Address(RVA = "0x1614D14", Offset = "0x1614D14", Length = "0x60")]
		public static void RegisterTextElementForCullingUpdate(TMP_Text element)
		{
		}

		[Token(Token = "0x600063D")]
		[Address(RVA = "0x1614D74", Offset = "0x1614D74", Length = "0x110")]
		private void InternalRegisterTextElementForCullingUpdate(TMP_Text element)
		{
		}

		[Token(Token = "0x600063E")]
		[Address(RVA = "0x1614E84", Offset = "0x1614E84", Length = "0x4")]
		private void OnCameraPreCull()
		{
		}

		[Token(Token = "0x600063F")]
		[Address(RVA = "0x1614E88", Offset = "0x1614E88", Length = "0x254")]
		private void DoRebuilds()
		{
		}

		[Token(Token = "0x6000640")]
		[Address(RVA = "0x16150DC", Offset = "0x16150DC", Length = "0x60")]
		internal static void UnRegisterTextObjectForUpdate(TMP_Text textObject)
		{
		}

		[Token(Token = "0x6000641")]
		[Address(RVA = "0x16151D4", Offset = "0x16151D4", Length = "0x80")]
		public static void UnRegisterTextElementForRebuild(TMP_Text element)
		{
		}

		[Token(Token = "0x6000642")]
		[Address(RVA = "0x1615254", Offset = "0x1615254", Length = "0x98")]
		private void InternalUnRegisterTextElementForGraphicRebuild(TMP_Text element)
		{
		}

		[Token(Token = "0x6000643")]
		[Address(RVA = "0x16152EC", Offset = "0x16152EC", Length = "0x98")]
		private void InternalUnRegisterTextElementForLayoutRebuild(TMP_Text element)
		{
		}

		[Token(Token = "0x6000644")]
		[Address(RVA = "0x161513C", Offset = "0x161513C", Length = "0x98")]
		private void InternalUnRegisterTextObjectForUpdate(TMP_Text textObject)
		{
		}
	}
}
