using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Newtonsoft.Json;
using UnityEngine;

namespace ElephantSDK
{
	[Token(Token = "0x2000950")]
	public class ElephantLiveOpsManager : ILiveOpsElephantAdapter, IElephantAdapter
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000951")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001F5E")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001F5F")]
			public static Action<string> _003C_003E9__4_1;

			[Token(Token = "0x4001F60")]
			public static Action<string> _003C_003E9__7_1;

			[Token(Token = "0x4001F61")]
			public static Func<string, string> _003C_003E9__10_0;

			[Token(Token = "0x60027D1")]
			[Address(RVA = "0x3E47E94", Offset = "0x3E47E94", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60027D2")]
			[Address(RVA = "0x3E47EF8", Offset = "0x3E47EF8", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003CRetrieveOfferAssetUrls_003Eb__4_1(string s)
			{
				string text = default(string);
				string message = "Could not retrieve URL's: " + text;
				ElephantLog.Log("OFFERUI", message);
			}

			internal void _003CDownloadTextureCoroutine_003Eb__7_1(string s)
			{
				string text = default(string);
				string message = "Could not download texture: " + text;
				ElephantLog.Log("OFFERUI", message);
			}

			internal string _003CCleanupUnusedAssets_003Eb__10_0(string url)
			{
				return Utils.GetFileNameFromUrl(url);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000954")]
		private sealed class _003CDownloadTextureCoroutine_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001F66")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001F67")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001F68")]
			[FieldOffset(Offset = "0x20")]
			public string url;

			[Token(Token = "0x17000460")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60027DE")]
				[Address(RVA = "0x3E486EC", Offset = "0x3E486EC", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000461")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60027E0")]
				[Address(RVA = "0x3E48734", Offset = "0x3E48734", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60027DB")]
			[Address(RVA = "0x3E47264", Offset = "0x3E47264", Length = "0x2C")]
			public _003CDownloadTextureCoroutine_003Ed__7(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60027DC")]
			[Address(RVA = "0x3E484B4", Offset = "0x3E484B4", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60027DD")]
			[Address(RVA = "0x3E484B8", Offset = "0x3E484B8", Length = "0x234")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ElephantLiveOpsManager._003CDownloadTextureCoroutine_003Ed__7::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60027DF")]
			[Address(RVA = "0x3E486F4", Offset = "0x3E486F4", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000955")]
		private sealed class _003CWaitForAllDownloads_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001F69")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001F6A")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001F6B")]
			[FieldOffset(Offset = "0x20")]
			public ElephantLiveOpsManager _003C_003E4__this;

			[Token(Token = "0x4001F6C")]
			[FieldOffset(Offset = "0x28")]
			private List<Coroutine>.Enumerator _003C_003E7__wrap1;

			[Token(Token = "0x17000462")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60027E5")]
				[Address(RVA = "0x3E48A88", Offset = "0x3E48A88", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000463")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60027E7")]
				[Address(RVA = "0x3E48AD0", Offset = "0x3E48AD0", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60027E1")]
			[Address(RVA = "0x3E47680", Offset = "0x3E47680", Length = "0x2C")]
			public _003CWaitForAllDownloads_003Ed__9(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60027E2")]
			[Address(RVA = "0x3E4873C", Offset = "0x3E4873C", Length = "0x78")]
			unsafe void IDisposable.Dispose()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ElephantLiveOpsManager._003CWaitForAllDownloads_003Ed__9::Dispose");
			}

			[Token(Token = "0x60027E3")]
			[Address(RVA = "0x3E487B4", Offset = "0x3E487B4", Length = "0x278")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ElephantLiveOpsManager._003CWaitForAllDownloads_003Ed__9::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x60027E4")]
			[Address(RVA = "0x3E48A2C", Offset = "0x3E48A2C", Length = "0x5C")]
			private unsafe void _003C_003Em__Finally1()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ElephantLiveOpsManager._003CWaitForAllDownloads_003Ed__9::_003C_003Em__Finally1");
			}

			[DebuggerHidden]
			[Token(Token = "0x60027E6")]
			[Address(RVA = "0x3E48A90", Offset = "0x3E48A90", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4001F5B")]
		[FieldOffset(Offset = "0x10")]
		private bool isOfferAssetsReady;

		[Token(Token = "0x4001F5C")]
		[FieldOffset(Offset = "0x11")]
		private bool isOfferProductsReady;

		[Token(Token = "0x4001F5D")]
		[FieldOffset(Offset = "0x18")]
		internal List<Coroutine> _activeDownloads;

		[Token(Token = "0x60027C4")]
		[Address(RVA = "0x3E45FB0", Offset = "0x3E45FB0", Length = "0x88")]
		public Offer GetCurrentOfferResponse()
		{
			OfferAssetManager instance = OfferAssetManager._instance;
			if (OfferAssetManager._instance == null)
			{
				OfferAssetManager instance2 = new OfferAssetManager();
				OfferAssetManager._instance = instance2;
				instance = OfferAssetManager._instance;
			}
			return instance.currentOfferResponse;
		}

		[Token(Token = "0x60027C5")]
		[Address(RVA = "0x3E460D8", Offset = "0x3E460D8", Length = "0x3AC")]
		public void RetrieveOfferAssetUrls()
		{
			ElephantLog.Log("LIVEOPS-ELEPHANT", "RetrieveOfferAssetUrls is Called");
			RemoteConfig instance = RemoteConfig.GetInstance();
			if (!instance.GetBool("live_ops_tool_enabled"))
			{
				return;
			}
			BaseData baseData = new BaseData();
			SessionData currentSession = ElephantCore.Instance.GetCurrentSession();
			baseData.FillBaseData(currentSession.start_time);
			string data = JsonConvert.SerializeObject(baseData);
			SessionData currentSession2 = ElephantCore.Instance.GetCurrentSession();
			ElephantData value = new ElephantData(data, currentSession2.start_time);
			string bodyJsonString = JsonConvert.SerializeObject(value);
			GenericNetworkManager<OfferUiUrls> genericNetworkManager = new GenericNetworkManager<OfferUiUrls>();
			Action<GenericResponse<OfferUiUrls>> onResponse = delegate(GenericResponse<OfferUiUrls> response)
			{
				DownloadAndCacheOfferAssets(response.data);
			};
			Action<string> onError = _003C_003Ec._003C_003E9__4_1;
			bool flag = _003C_003Ec._003C_003E9__4_1 == null;
			string url = "https://liveopsapi.rollic.gs/api/v2/offers/assets";
			if (!flag)
			{
				if (genericNetworkManager == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				onError = (_003C_003Ec._003C_003E9__4_1 = delegate
				{
					string text = default(string);
					string message = "Could not retrieve URL's: " + text;
					ElephantLog.Log("OFFERUI", message);
				});
				url = "https://liveopsapi.rollic.gs/api/v2/offers/assets";
			}
			IEnumerator routine = genericNetworkManager.PostWithResponse(url, bodyJsonString, onResponse, onError);
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(routine);
		}

		[Token(Token = "0x60027C6")]
		[Address(RVA = "0x3E46484", Offset = "0x3E46484", Length = "0x564")]
		private unsafe void DownloadAndCacheOfferAssets(OfferUiUrls offerUiUrls)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantLiveOpsManager::DownloadAndCacheOfferAssets");
		}

		[Token(Token = "0x60027C7")]
		[Address(RVA = "0x3E469E8", Offset = "0x3E469E8", Length = "0x2AC")]
		private void DownloadTexture(string url)
		{
			string fileNameFromUrl = Utils.GetFileNameFromUrl(url);
			if (Utils.IsFileExistsInSubdirectory(fileNameFromUrl))
			{
				OfferAssetManager instance = OfferAssetManager._instance;
				if (OfferAssetManager._instance == null)
				{
					OfferAssetManager instance2 = new OfferAssetManager();
					OfferAssetManager._instance = instance2;
					instance = OfferAssetManager._instance;
				}
				List<string> offerUrls = instance.offerUrls;
				offerUrls.Add(url);
			}
			else
			{
				_003CDownloadTextureCoroutine_003Ed__7 _003CDownloadTextureCoroutine_003Ed__8 = (_003CDownloadTextureCoroutine_003Ed__7)FormatterServices.GetUninitializedObject(typeof(_003CDownloadTextureCoroutine_003Ed__7));
				_003CDownloadTextureCoroutine_003Ed__8._003C_003E1__state = 0;
				_003CDownloadTextureCoroutine_003Ed__8.url = url;
				Coroutine item = ElephantCore.Instance.StartCoroutine(_003CDownloadTextureCoroutine_003Ed__8);
				List<Coroutine> activeDownloads = _activeDownloads;
				activeDownloads.Add(item);
			}
		}

		[IteratorStateMachine(typeof(_003CDownloadTextureCoroutine_003Ed__7))]
		[Token(Token = "0x60027C8")]
		[Address(RVA = "0x3E471EC", Offset = "0x3E471EC", Length = "0x78")]
		private IEnumerator DownloadTextureCoroutine(string url)
		{
			_003CDownloadTextureCoroutine_003Ed__7 _003CDownloadTextureCoroutine_003Ed__8 = (_003CDownloadTextureCoroutine_003Ed__7)FormatterServices.GetUninitializedObject(typeof(_003CDownloadTextureCoroutine_003Ed__7));
			_003CDownloadTextureCoroutine_003Ed__8._003C_003E1__state = 0;
			_003CDownloadTextureCoroutine_003Ed__8.url = url;
			return _003CDownloadTextureCoroutine_003Ed__8;
		}

		[Token(Token = "0x60027C9")]
		[Address(RVA = "0x3E47290", Offset = "0x3E47290", Length = "0x3E8")]
		public void OfferGenerateRequest(OfferMetaData offerMetaData, Action<OfferData> callback)
		{
			ElephantLog.Log("LIVEOPS-ELEPHANT", "OfferGenerateRequest is Called");
			long num = Utils.Timestamp();
			ElephantCore instance = ElephantCore.Instance;
			if ((object)ElephantCore.Instance != null)
			{
				OfferMetaData offerMetaData2 = offerMetaData;
				long num2 = (offerMetaData2.sessionPlaytime = num - instance.realSessionId);
				long totalPlaytime = instance.timeSpend + num2;
				offerMetaData2.totalPlaytime = totalPlaytime;
				OfferMetaDataRequest value = OfferMetaDataRequest.FillOfferMetaDataRequest(offerMetaData2);
				string data = JsonConvert.SerializeObject(value);
				SessionData currentSession = ElephantCore.Instance.GetCurrentSession();
				ElephantData value2 = new ElephantData(data, currentSession.start_time);
				string bodyJsonString = JsonConvert.SerializeObject(value2);
				GenericNetworkManager<Offer> genericNetworkManager = new GenericNetworkManager<Offer>();
				RemoteConfig instance2 = RemoteConfig.GetInstance();
				float value3 = instance2.GetFloat("offer_time_out", 3f);
				Action<GenericResponse<Offer>> onResponse = delegate(GenericResponse<Offer> response)
				{
					if (response.data != null)
					{
						OfferData offerData = OfferData.FromResponse(response.data);
						callback(offerData);
						if (offerData.Show)
						{
							OfferAssetManager instance3 = OfferAssetManager._instance;
							if (OfferAssetManager._instance == null)
							{
								OfferAssetManager instance4 = new OfferAssetManager();
								OfferAssetManager._instance = instance4;
								instance3 = OfferAssetManager._instance;
							}
							instance3.currentOfferResponse = response.data;
							instance3.offerUIData = offerData.OfferUIData;
							instance3.SetTemplateFields(offerData.TemplateFields, offerData.OfferName);
							instance3.currentOffer = offerData;
							instance3.offerMetaData = offerMetaData;
							ElephantLiveOpsManager elephantLiveOpsManager = default(ElephantLiveOpsManager);
							elephantLiveOpsManager.AddOfferUIManager();
							ElephantCore.Instance.TriggerOnOfferUIFetched();
						}
					}
				};
				Action<string> onError = delegate
				{
					callback(null);
				};
				float? timeout = value3;
				IEnumerator routine = genericNetworkManager.PostWithResponse("https://liveopsapi.rollic.gs/api/v2/offers", bodyJsonString, onResponse, onError, timeout);
				Coroutine coroutine = ElephantCore.Instance.StartCoroutine(routine);
				return;
			}
			throw new NullReferenceException();
		}

		[IteratorStateMachine(typeof(_003CWaitForAllDownloads_003Ed__9))]
		[Token(Token = "0x60027CA")]
		[Address(RVA = "0x3E46C94", Offset = "0x3E46C94", Length = "0x78")]
		private IEnumerator WaitForAllDownloads()
		{
			_003CWaitForAllDownloads_003Ed__9 _003CWaitForAllDownloads_003Ed__10 = (_003CWaitForAllDownloads_003Ed__9)FormatterServices.GetUninitializedObject(typeof(_003CWaitForAllDownloads_003Ed__9));
			_003CWaitForAllDownloads_003Ed__10._003C_003E1__state = 0;
			_003CWaitForAllDownloads_003Ed__10._003C_003E4__this = this;
			return _003CWaitForAllDownloads_003Ed__10;
		}

		[Token(Token = "0x60027CB")]
		[Address(RVA = "0x3E46D0C", Offset = "0x3E46D0C", Length = "0x4E0")]
		private void CleanupUnusedAssets(List<string> currentUrls)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantLiveOpsManager::CleanupUnusedAssets");
		}

		[Token(Token = "0x60027CC")]
		[Address(RVA = "0x3E476AC", Offset = "0x3E476AC", Length = "0x17C")]
		private void DeleteAllAssets()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantLiveOpsManager::DeleteAllAssets");
		}

		[Token(Token = "0x60027CD")]
		[Address(RVA = "0x3E47828", Offset = "0x3E47828", Length = "0x1F8")]
		private void AddOfferUIManager()
		{
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1544");
			Type type = default(Type);
			if (type != null)
			{
				GameObject gameObject = ElephantCore.Instance.gameObject;
				Component component = gameObject.GetComponent(type);
				if (!(component != null))
				{
					ElephantLog.Log("OFFERUI", "OfferUIManager added.");
					GameObject gameObject2 = ElephantCore.Instance.gameObject;
					Component component2 = gameObject2.AddComponent(type);
				}
			}
			else
			{
				ElephantLog.Log("OFFERUI", "Could not add OfferUIManager.");
			}
		}

		[Token(Token = "0x60027CE")]
		[Address(RVA = "0x3E47A20", Offset = "0x3E47A20", Length = "0x45C")]
		public void ReceiveLocalizedPrice(string concatenatedPrices)
		{
			ElephantLog.Log("LIVEOPS-ELEPHANT", "ReceiveLocalizedPrice is Called");
			ElephantLog.Log("OFFERUI", concatenatedPrices);
			string[] array = concatenatedPrices.Split(';');
			if (array.Length >= 1)
			{
				int num = 0;
				do
				{
					if (!string.IsNullOrEmpty(array[num]))
					{
						string[] array2 = array[num].Split(':');
						if (array2.Length == 4)
						{
							string filter = "OFFER PRICE for " + array2[0];
							string message = array2[1] + " " + array2[2] + " " + array2[3];
							ElephantLog.Log(filter, message);
							OfferAssetManager instance = OfferAssetManager._instance;
							if (OfferAssetManager._instance == null)
							{
								OfferAssetManager instance2 = new OfferAssetManager();
								OfferAssetManager._instance = instance2;
								instance = OfferAssetManager._instance;
							}
							string value = array2[1] + " " + array2[2] + " " + array2[3];
							if (instance.localPricingCache == null)
							{
								throw new NullReferenceException();
							}
							instance.localPricingCache.Add(array2[0], value);
						}
					}
					num++;
				}
				while (num < array.Length);
			}
			isOfferProductsReady = true;
			ElephantLog.Log("OFFEUI", "Offer products ready.");
			Elephant.TriggerLiveOpsReady(isOfferAssetsReady, isOfferProductsReady);
		}

		[Token(Token = "0x60027CF")]
		[Address(RVA = "0x3E45F1C", Offset = "0x3E45F1C", Length = "0x8C")]
		public ElephantLiveOpsManager()
		{
			List<Coroutine> activeDownloads = new List<Coroutine>();
			_activeDownloads = activeDownloads;
		}
	}
}
