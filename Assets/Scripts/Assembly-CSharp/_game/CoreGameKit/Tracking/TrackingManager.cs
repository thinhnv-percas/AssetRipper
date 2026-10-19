using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using Unco.ResourceSystem;
using Unco.Utils;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.CoreSystem.HealthSystem;

namespace _game.CoreGameKit.Tracking
{
	[Token(Token = "0x2000584")]
	public class TrackingManager : IDisposable
	{
		[Inject(false)]
		[Token(Token = "0x4001310")]
		[FieldOffset(Offset = "0x10")]
		private ILevelList _levelList;

		[Inject(false)]
		[Token(Token = "0x4001311")]
		[FieldOffset(Offset = "0x18")]
		private HealthController _healthController;

		[Token(Token = "0x4001312")]
		[FieldOffset(Offset = "0x20")]
		internal TrackerEntry[] _entries;

		[Token(Token = "0x4001313")]
		[FieldOffset(Offset = "0x28")]
		private TrackingRouter _defaultRouter;

		[Token(Token = "0x6001734")]
		[Address(RVA = "0x3D287A8", Offset = "0x3D287A8", Length = "0x80")]
		public TrackingManager(TrackingConfig config)
		{
			_entries = (TrackerEntry[])((IEnumerable<object>)config.GetTrackerEntries()).ToArray();
		}

		[Inject(true)]
		[Token(Token = "0x6001735")]
		[Address(RVA = "0x3D28830", Offset = "0x3D28830", Length = "0x3F0")]
		public void Initialize(Instancer instancer, ILevelProgressService progressService)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TrackingManager::Initialize");
		}

		[Token(Token = "0x6001736")]
		[Address(RVA = "0x3D28E30", Offset = "0x3D28E30", Length = "0x104")]
		public void Dispose()
		{
			TrackerEntry[] entries = _entries;
			if (entries.Length >= 1)
			{
				int num = 0;
				do
				{
					TrackerEntry trackerEntry = entries[num];
					trackerEntry.tracker.EndTracking();
					num++;
				}
				while (num < entries.Length);
			}
			_entries = null;
		}

		[Token(Token = "0x6001737")]
		[Address(RVA = "0x3D28F34", Offset = "0x3D28F34", Length = "0x18")]
		public void Event(TrackingKey eventName, Params parameters = null)
		{
			_defaultRouter.Event(eventName, parameters);
		}

		[Token(Token = "0x6001738")]
		[Address(RVA = "0x3D29144", Offset = "0x3D29144", Length = "0x18")]
		public void SendCustomEvent(string eventName, Params parameters)
		{
			_defaultRouter.SendCustomEvent(eventName, parameters);
		}

		[Token(Token = "0x6001739")]
		[Address(RVA = "0x3D29334", Offset = "0x3D29334", Length = "0x18")]
		public void SendCustomEvent(string eventName, List<Pair<string, string>> pair)
		{
			_defaultRouter.SendCustomEvent(eventName, pair);
		}

		[Token(Token = "0x600173A")]
		[Address(RVA = "0x3D29514", Offset = "0x3D29514", Length = "0x3C")]
		public unsafe void Transaction(string type, long delta, long newAmount, TransactionContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TrackingManager::Transaction");
		}

		[Token(Token = "0x600173B")]
		[Address(RVA = "0x3D28C84", Offset = "0x3D28C84", Length = "0x1AC")]
		private static ITrackingSender[] BuildSenders(TrackerEntry entry, ElephantSender elephant, FirebaseSender firebase)
		{
			List<ITrackingSender> list = new List<ITrackingSender>(2);
			if (!entry.logToElephant)
			{
				if (!entry.logToFirebase)
				{
					goto IL_009e;
				}
			}
			else
			{
				list.Add(elephant);
				if (!entry.logToFirebase)
				{
					goto IL_009e;
				}
			}
			list.Add(firebase);
			goto IL_00da;
			IL_00da:
			return list.ToArray();
			IL_009e:
			if (list == null)
			{
				throw new NullReferenceException();
			}
			goto IL_00da;
		}
	}
}
