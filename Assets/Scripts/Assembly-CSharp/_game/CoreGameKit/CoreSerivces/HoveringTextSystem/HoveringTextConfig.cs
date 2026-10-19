using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Unco.TextViewSystem;
using Unco.Utils;
using UnityEngine;

namespace _game.CoreGameKit.CoreSerivces.HoveringTextSystem
{
	[Token(Token = "0x200060E")]
	internal class HoveringTextConfig : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x40014EA")]
		[FieldOffset(Offset = "0x18")]
		internal Pair<string, TextView>[] m_viewList;

		[Token(Token = "0x6001A07")]
		[Address(RVA = "0x3D4F864", Offset = "0x3D4F864", Length = "0xB8")]
		public TextView Get(string config)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HoveringTextConfig::Get");
			return default;
		}

		[Token(Token = "0x6001A08")]
		[Address(RVA = "0x3D4F91C", Offset = "0x3D4F91C", Length = "0x8")]
		public HoveringTextConfig()
		{
		}
	}
}
