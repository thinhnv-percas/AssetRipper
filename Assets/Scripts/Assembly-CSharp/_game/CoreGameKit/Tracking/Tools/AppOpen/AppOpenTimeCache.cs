using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.GameBootstrap.Core;
using Unco.Utils;
using UnityEngine;

namespace _game.CoreGameKit.Tracking.Tools.AppOpen
{
	[Token(Token = "0x2000597")]
	public class AppOpenTimeCache : ITracker
	{
		[Token(Token = "0x4001340")]
		[FieldOffset(Offset = "0x10")]
		internal string _name;

		[Token(Token = "0x4001341")]
		[FieldOffset(Offset = "0x18")]
		private float _cachedTime;

		[Token(Token = "0x4001342")]
		[FieldOffset(Offset = "0x1C")]
		private bool _hasCachedTime;

		[Token(Token = "0x4001343")]
		[FieldOffset(Offset = "0x20")]
		private TrackingRouter _router;

		[Token(Token = "0x60017B5")]
		[Address(RVA = "0x3D303AC", Offset = "0x3D303AC", Length = "0x58")]
		public ITracker GetInstance()
		{
			return new AppOpenTimeCache();
		}

		[Token(Token = "0x60017B6")]
		[Address(RVA = "0x3D3040C", Offset = "0x3D3040C", Length = "0x8")]
		public void SetRouter(TrackingRouter router)
		{
			_router = router;
		}

		[Inject(false)]
		[Token(Token = "0x60017B7")]
		[Address(RVA = "0x3D30414", Offset = "0x3D30414", Length = "0x3C")]
		private void Inject(ScopeContext scopeContext)
		{
			_name = scopeContext.ScopeName;
			CacheStartUpTime();
		}

		[Token(Token = "0x60017B8")]
		[Address(RVA = "0x3D30450", Offset = "0x3D30450", Length = "0xD0")]
		private void CacheStartUpTime()
		{
			float num = (_cachedTime = Time.realtimeSinceStartup);
			_hasCachedTime = true;
			float num2 = num;
			int num3 = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			string message = $"App open time cached for {_name}: {arg}";
			Debug.LogWarning(message);
		}

		[Token(Token = "0x60017B9")]
		[Address(RVA = "0x3D30520", Offset = "0x3D30520", Length = "0x4")]
		public void BeginTracking()
		{
		}

		[Token(Token = "0x60017BA")]
		[Address(RVA = "0x3D30524", Offset = "0x3D30524", Length = "0x4")]
		public void EndTracking()
		{
		}

		[Token(Token = "0x60017BB")]
		[Address(RVA = "0x3D30528", Offset = "0x3D30528", Length = "0x58")]
		public string GetEventName()
		{
			return _name + "_open_time";
		}

		[Token(Token = "0x60017BC")]
		[Address(RVA = "0x3D30580", Offset = "0x3D30580", Length = "0x19C")]
		public List<Pair<string, string>> GetCachedData()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AppOpenTimeCache::GetCachedData");
			return default;
		}

		[Token(Token = "0x60017BD")]
		[Address(RVA = "0x3D30404", Offset = "0x3D30404", Length = "0x8")]
		public AppOpenTimeCache()
		{
		}
	}
}
