using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Mycom.Tracker.Unity.Internal.Interfaces;
using UnityEngine.Purchasing;

namespace Mycom.Tracker.Unity.Internal.Implementations.Fake
{
	[Token(Token = "0x200000C")]
	internal sealed class Tracker : ITracker, IDisposable
	{
		[Token(Token = "0x4000010")]
		public static ITracker Instance;

		[Token(Token = "0x17000021")]
		public MyTrackerParams MyTrackerParams
		{
			[Token(Token = "0x6000084")]
			[Address(RVA = "0x16229C8", Offset = "0x16229C8", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1ECA2C0]);\n\tv17 = *([v16 @ X8_v8]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A309]) = v37;\nL_0015:\n\tv41 = new Mycom.Tracker.Unity.Internal.Implementations.Fake.TrackerParams();\n\tSystem.Object::.ctor(v41);\n\tv47 = new Mycom.Tracker.Unity.MyTrackerParams();\n\tSystem.Object::.ctor(v47);\n\tv47._trackerParams = v41;\n\treturn v47;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				TrackerParams trackerParams = new TrackerParams();
				MyTrackerParams myTrackerParams = null;
				myTrackerParams._trackerParams = trackerParams;
				return myTrackerParams;
			}
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x1622A4C", Offset = "0x1622A4C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void Create(string id)
		{
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x1622A50", Offset = "0x1622A50", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void Dispose()
		{
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x1622A54", Offset = "0x1622A54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Flush()
		{
			return false;
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0x1622A5C", Offset = "0x1622A5C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void Init()
		{
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x1622A60", Offset = "0x1622A60", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsDebugMode()
		{
			return false;
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x1622A68", Offset = "0x1622A68", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsEnabled()
		{
			return false;
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x1622A70", Offset = "0x1622A70", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetAttributionListener(Action<MyTrackerAttribution> listener)
		{
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x1622A74", Offset = "0x1622A74", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetDebugMode(bool value)
		{
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x1622A78", Offset = "0x1622A78", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetEnabled(bool value)
		{
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x1622A7C", Offset = "0x1622A7C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrackEvent(string name, IDictionary<string, string> eventParams = null)
		{
			return false;
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x1622A84", Offset = "0x1622A84", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrackInviteEvent(IDictionary<string, string> eventParams = null)
		{
			return false;
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x1622A8C", Offset = "0x1622A8C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrackLevelEvent(int? level = null, IDictionary<string, string> eventParams = null)
		{
			return false;
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x1622A94", Offset = "0x1622A94", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrackLoginEvent(IDictionary<string, string> eventParams = null)
		{
			return false;
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x1622A9C", Offset = "0x1622A9C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrackRegistrationEvent(IDictionary<string, string> eventParams = null)
		{
			return false;
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x1622AA4", Offset = "0x1622AA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrackPurchaseEvent(string skuDetails, string purchaseData, string dataSignature, IDictionary<string, string> eventParams = null)
		{
			return false;
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0x1622AAC", Offset = "0x1622AAC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrackPurchaseEvent(Product product, IDictionary<string, string> eventParams = null)
		{
			return false;
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x1622AB4", Offset = "0x1622AB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Tracker()
		{
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x1622ABC", Offset = "0x1622ABC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EFF2E0]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A30A]) = v37;\nL_0015:\n\tv41 = new Mycom.Tracker.Unity.Internal.Implementations.Fake.Tracker();\n\tSystem.Object::.ctor(v41);\n\tv45.Instance = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static Tracker()
		{
			Tracker instance = new Tracker();
			Instance = instance;
		}
	}
}
