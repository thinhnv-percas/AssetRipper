using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Tracking
{
	[Token(Token = "0x200057F")]
	public class TrackingConfig : ScriptableObject
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000580")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40012EF")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40012F0")]
			public static Func<TrackerEntry, bool> _003C_003E9__1_0;

			[Token(Token = "0x600172B")]
			[Address(RVA = "0x3D28578", Offset = "0x3D28578", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600172C")]
			[Address(RVA = "0x3D285DC", Offset = "0x3D285DC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CGetTrackerEntries_003Eb__1_0(TrackerEntry x)
			{
				if (x.enabled)
				{
					bool flag = x.tracker == null;
					return !flag;
				}
				return false;
			}
		}

		[SerializeField]
		[Token(Token = "0x40012EE")]
		[FieldOffset(Offset = "0x18")]
		private TrackerEntry[] m_trackerList;

		[Token(Token = "0x6001729")]
		[Address(RVA = "0x3D28440", Offset = "0x3D28440", Length = "0x130")]
		public IEnumerable<TrackerEntry> GetTrackerEntries()
		{
			bool flag = _003C_003Ec._003C_003E9__1_0 == null;
			bool flag2 = !flag;
			Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__1_0;
			IEnumerable<object> trackerList = m_trackerList;
			if (!flag2)
			{
				predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__1_0 = delegate(TrackerEntry x)
				{
					if (x.enabled)
					{
						bool flag3 = x.tracker == null;
						return !flag3;
					}
					return false;
				});
				trackerList = m_trackerList;
			}
			return (IEnumerable<TrackerEntry>)trackerList.Where(predicate);
		}

		[Token(Token = "0x600172A")]
		[Address(RVA = "0x3D28570", Offset = "0x3D28570", Length = "0x8")]
		public TrackingConfig()
		{
		}
	}
}
