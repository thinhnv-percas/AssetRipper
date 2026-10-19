using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Cpp2ILInjected;
using Newtonsoft.Json;
using UnityEngine;

namespace ElephantSDK
{
	[Token(Token = "0x200095B")]
	public static class ElephantPayments
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200095C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001F9C")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001F9D")]
			public static Action<GenericResponse<List<ElephantProduct>>> _003C_003E9__8_0;

			[Token(Token = "0x4001F9E")]
			public static Action<string> _003C_003E9__8_1;

			[Token(Token = "0x4001F9F")]
			public static Func<string, bool> _003C_003E9__37_0;

			[Token(Token = "0x600281B")]
			[Address(RVA = "0x3E4F384", Offset = "0x3E4F384", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600281C")]
			[Address(RVA = "0x3E4F3E8", Offset = "0x3E4F3E8", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003CFetchProducts_003Eb__8_0(GenericResponse<List<ElephantProduct>> response)
			{
				if (response == null || response.data == null)
				{
					List<ElephantProduct> data = new List<ElephantProduct>();
					response.data = data;
				}
				Params obj = Params.New();
				List<ElephantProduct> data2 = response.data;
				Params parameters = obj.Set("product_count", data2.Count);
				Elephant.Event("elephant_ds_product_fetched", -1, parameters);
				if (OnProductsFetched != null)
				{
					OnProductsFetched(response.data);
				}
			}

			internal void _003CFetchProducts_003Eb__8_1(string error)
			{
				RaiseError(ElephantPaymentErrorType.ProductsFetchFailed, "Failed to fetch products.", error);
			}

			internal bool _003CProcessConfirmationQueue_003Eb__37_0(string id)
			{
				bool flag = _activeConfirmations.Contains(id);
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200095F")]
		private sealed class _003C_003Ec__DisplayClass37_0
		{
			[Token(Token = "0x4001FA2")]
			[FieldOffset(Offset = "0x10")]
			public string transactionId;

			[Token(Token = "0x6002825")]
			[Address(RVA = "0x3E4EB28", Offset = "0x3E4EB28", Length = "0x8")]
			public _003C_003Ec__DisplayClass37_0()
			{
			}

			internal void _003CProcessConfirmationQueue_003Eb__1()
			{
				if (_pendingPaymentInfo == null)
				{
					goto IL_01de;
				}
				bool flag = _pendingPaymentInfo.TryGetValue(transactionId, out var value);
				string value2;
				Params obj;
				double value3;
				if (value != null)
				{
					ElephantProduct purchasedProduct = value.purchasedProduct;
					if (value.purchasedProduct != null)
					{
						value2 = purchasedProduct.productId;
						double? num = null;
						num = purchasedProduct.price;
						obj = Params.New();
						bool flag2 = obj == null;
						bool flag3 = !flag2;
						value3 = 0.0;
						if (flag3)
						{
							goto IL_011d;
						}
						goto IL_01de;
					}
				}
				obj = Params.New();
				value3 = 0.0;
				value2 = null;
				goto IL_011d;
				IL_01de:
				throw new NullReferenceException();
				IL_011d:
				Params obj2 = obj.Set("product_id", value2);
				Params obj3 = obj2.Set("price", value3);
				Params parameters = obj3.Set("transaction_id", transactionId);
				Elephant.Event("elephant_ds_payment_completed", -1, parameters);
				bool flag4 = _confirmationQueue.Remove(transactionId);
				bool flag5 = _activeConfirmations.Remove(transactionId);
				bool flag6 = _pendingPaymentInfo.Remove(transactionId);
				SaveConfirmationQueue();
			}

			internal void _003CProcessConfirmationQueue_003Eb__2(string error)
			{
				bool flag = _activeConfirmations.Remove(transactionId);
				RaiseError(ElephantPaymentErrorType.ConfirmPurchaseBackendFailed, "Failed to confirm purchase with backend.", error, null, transactionId);
				SaveConfirmationQueue();
			}
		}

		[Token(Token = "0x4001F82")]
		public static Action<List<ElephantProduct>> OnProductsFetched;

		[Token(Token = "0x4001F83")]
		public static Action<ElephantPayment> OnPaymentPending;

		[Token(Token = "0x4001F84")]
		public static Action<ElephantPaymentsError> OnError;

		[Token(Token = "0x4001F85")]
		public static Action OnPaymentDialogueClosed;

		[Token(Token = "0x4001F86")]
		private static bool _isPurchaseFlowActive;

		[Token(Token = "0x4001F87")]
		private static Coroutine _activePollingCoroutine;

		[Token(Token = "0x4001F88")]
		private static bool _isTestMode;

		[Token(Token = "0x4001F89")]
		private static bool _isInitialized;

		[Token(Token = "0x4001F8A")]
		private static bool _isCheckingPurchases;

		[Token(Token = "0x4001F8B")]
		private static bool _hasLoggedCheckingEvent;

		[Token(Token = "0x4001F8C")]
		private static HashSet<string> _confirmationQueue;

		[Token(Token = "0x4001F8D")]
		private static HashSet<string> _activeConfirmations;

		[Token(Token = "0x4001F8E")]
		private static HashSet<string> _knownPendingTransactionIds;

		[Token(Token = "0x4001F8F")]
		private static Dictionary<string, ElephantPayment> _pendingPaymentInfo;

		[Token(Token = "0x4001F90")]
		private static HashSet<string> _notifiedPendingThisSession;

		[Token(Token = "0x4001F91")]
		private const string PlayerPrefsQueueKey = "ELEPHANT_CONFIRM_QUEUE";

		[Token(Token = "0x4001F92")]
		private const string EVENT_ESCROW_STARTED = "elephant_ds_escrow_started";

		[Token(Token = "0x4001F93")]
		private const string EVENT_ESCROW_COMPLETED = "elephant_ds_escrow_completed";

		[Token(Token = "0x4001F94")]
		private const string EVENT_ESCROW_FAILED = "elephant_ds_escrow_failed";

		[Token(Token = "0x4001F95")]
		private const string EVENT_CHECKOUT_STARTED = "elephant_ds_checkout_started";

		[Token(Token = "0x4001F96")]
		private const string EVENT_CHECKOUT_COMPLETED = "elephant_ds_checkout_completed";

		[Token(Token = "0x4001F97")]
		private const string EVENT_PAYMENT_CHECKING = "elephant_ds_payment_checking";

		[Token(Token = "0x4001F98")]
		private const string EVENT_PAYMENT_PENDING = "elephant_ds_payment_pending";

		[Token(Token = "0x4001F99")]
		private const string EVENT_PAYMENT_COMPLETED = "elephant_ds_payment_completed";

		[Token(Token = "0x4001F9A")]
		private const string EVENT_PRODUCT_FETCHING = "elephant_ds_product_fetching";

		[Token(Token = "0x4001F9B")]
		private const string EVENT_PRODUCT_FETCHED = "elephant_ds_product_fetched";

		[Token(Token = "0x6002809")]
		[Address(RVA = "0x3E4BD48", Offset = "0x3E4BD48", Length = "0x308")]
		public static void Initialize(Action<List<ElephantProduct>> onProductsFetched, Action<ElephantPayment> onPaymentPending, Action<ElephantPaymentsError> onError)
		{
			if (!_isInitialized)
			{
				RemoteConfig instance = RemoteConfig.GetInstance();
				bool isTestMode = instance.GetBool("ds_payments_test_enabled");
				_isTestMode = isTestMode;
				RemoteConfig instance2 = RemoteConfig.GetInstance();
				bool _003CIsDevUrlEnabled_003Ek__BackingField = instance2.GetBool("ds_payments_dev_env_enabled");
				ElephantConstants.IsDevUrlEnabled = _003CIsDevUrlEnabled_003Ek__BackingField;
				OnProductsFetched = onProductsFetched;
				OnPaymentPending = onPaymentPending;
				OnError = onError;
				_notifiedPendingThisSession.Clear();
				LoadConfirmationQueue();
				Action<string> value = OnWebViewClosed;
				Elephant.add_OnWebViewClosed(value);
				Action value2 = OnAppFocus;
				Elephant.add_OnApplicationFocusTrue(value2);
				_isInitialized = true;
				FetchProducts();
				CheckPendingPayments();
				ProcessConfirmationQueue();
			}
		}

		[Token(Token = "0x600280A")]
		[Address(RVA = "0x3E4C2E4", Offset = "0x3E4C2E4", Length = "0x4C4")]
		public static void FetchProducts()
		{
			//IL_0021: Expected O, but got I4
			int num = 187244544 + 1440;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X0_v142+E4]");
			if ((nint)0 != 0)
			{
				if (ElephantCore.Instance == null)
				{
					goto IL_0073;
				}
			}
			else if (ElephantCore.Instance == null)
			{
				goto IL_0073;
			}
			Elephant.Event("elephant_ds_product_fetching", -1);
			ListPaymentsRequest value = ListPaymentsRequest.Create();
			string data = JsonConvert.SerializeObject(value);
			if ((object)ElephantCore.Instance == null)
			{
				goto IL_0277;
			}
			SessionData currentSession = ElephantCore.Instance.GetCurrentSession();
			ElephantData value2 = new ElephantData(data, currentSession.start_time);
			string bodyJsonString = JsonConvert.SerializeObject(value2);
			GenericNetworkManager<List<ElephantProduct>> genericNetworkManager = new GenericNetworkManager<List<ElephantProduct>>();
			string dS_LIST_PRODUCTS = ElephantConstants.DS_LIST_PRODUCTS;
			Action<GenericResponse<List<ElephantProduct>>> action = _003C_003Ec._003C_003E9__8_0;
			if (_003C_003Ec._003C_003E9__8_0 == null)
			{
				action = (_003C_003Ec._003C_003E9__8_0 = delegate(GenericResponse<List<ElephantProduct>> response)
				{
					if (response == null || response.data == null)
					{
						List<ElephantProduct> data2 = new List<ElephantProduct>();
						response.data = data2;
					}
					Params obj2 = Params.New();
					List<ElephantProduct> data3 = response.data;
					Params parameters = obj2.Set("product_count", data3.Count);
					Elephant.Event("elephant_ds_product_fetched", -1, parameters);
					if (OnProductsFetched != null)
					{
						OnProductsFetched(response.data);
					}
				});
			}
			Action<string> onError = _003C_003Ec._003C_003E9__8_1;
			if (_003C_003Ec._003C_003E9__8_1 != null)
			{
				if (genericNetworkManager == null)
				{
					goto IL_0277;
				}
			}
			else
			{
				onError = (_003C_003Ec._003C_003E9__8_1 = delegate(string error)
				{
					RaiseError(ElephantPaymentErrorType.ProductsFetchFailed, "Failed to fetch products.", error);
				});
				action = action;
			}
			IEnumerator routine = genericNetworkManager.PostWithResponse(dS_LIST_PRODUCTS, bodyJsonString, action, onError);
			Coroutine coroutine = ElephantCore.Instance.StartCoroutine(routine);
			return;
			IL_0277:
			throw new NullReferenceException();
			IL_0073:
			RaiseError(ElephantPaymentErrorType.ProductsFetchFailed, "ElephantCore.Instance is null while fetching products.");
		}

		[Token(Token = "0x600280B")]
		[Address(RVA = "0x3E4D3D4", Offset = "0x3E4D3D4", Length = "0x4F0")]
		public static void PurchaseWeb(string productId, Action onPaymentDialogueClosed = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantPayments::PurchaseWeb");
		}

		[Token(Token = "0x600280C")]
		[Address(RVA = "0x3E4D9A8", Offset = "0x3E4D9A8", Length = "0x78")]
		public static void CheckForPendingPurchases()
		{
			CheckPendingPayments();
		}

		[Token(Token = "0x600280D")]
		[Address(RVA = "0x3E4DA20", Offset = "0x3E4DA20", Length = "0x3B4")]
		public static void ConfirmPurchase(ElephantPayment payment)
		{
			if (payment == null || string.IsNullOrEmpty(payment.transactionId))
			{
				RaiseError(ElephantPaymentErrorType.ConfirmPurchaseInvalidTransaction, "ConfirmPurchase called with null or empty transactionId.");
			}
			else if (_knownPendingTransactionIds.Contains(payment.transactionId) || _confirmationQueue.Contains(payment.transactionId))
			{
				if (!_confirmationQueue.Contains(payment.transactionId))
				{
					ElephantProduct purchasedProduct = payment.purchasedProduct;
					double revenue = ((payment.purchasedProduct == null) ? 0.0 : purchasedProduct.price);
					ElephantCore instance = ElephantCore.Instance;
					if ((object)ElephantCore.Instance != null && instance.AdjustElephantAdapter != null)
					{
						instance.AdjustElephantAdapter.TrackPurchaseRevenue(AdjustTokens.Ds_payment, revenue, "USD");
					}
					bool flag = _confirmationQueue.Add(payment.transactionId);
					_pendingPaymentInfo[payment.transactionId] = payment;
					SaveConfirmationQueue();
				}
				ProcessConfirmationQueue();
			}
			else
			{
				ElephantProduct purchasedProduct2 = payment.purchasedProduct;
				string productId;
				string message;
				if (payment.purchasedProduct != null)
				{
					productId = purchasedProduct2.productId;
					message = "ConfirmPurchase called for transaction that is not reported as pending.";
				}
				else
				{
					message = "ConfirmPurchase called for transaction that is not reported as pending.";
					productId = null;
				}
				RaiseError(ElephantPaymentErrorType.ConfirmPurchaseInvalidTransaction, message, null, productId, payment.transactionId);
			}
		}

		[Token(Token = "0x600280E")]
		[Address(RVA = "0x3E4DFAC", Offset = "0x3E4DFAC", Length = "0x1B8")]
		private static void OnAppFocus()
		{
			if (_isPurchaseFlowActive)
			{
				_isPurchaseFlowActive = false;
				if (OnPaymentDialogueClosed != null)
				{
					OnPaymentDialogueClosed();
				}
				Params obj = Params.New();
				Params parameters = obj.Set("reason", "focus");
				Elephant.Event("elephant_ds_checkout_completed", -1, parameters);
				StartPollingIfNeeded();
			}
			else
			{
				CheckPendingPayments();
			}
			ProcessConfirmationQueue();
		}

		[Token(Token = "0x600280F")]
		[Address(RVA = "0x3E4E3CC", Offset = "0x3E4E3CC", Length = "0x1B4")]
		private static void OnWebViewClosed(string reason)
		{
			if (_isPurchaseFlowActive)
			{
				_isPurchaseFlowActive = false;
				if (OnPaymentDialogueClosed != null)
				{
					OnPaymentDialogueClosed();
				}
				Params obj = Params.New();
				Params parameters = obj.Set("reason", reason);
				Elephant.Event("elephant_ds_checkout_completed", -1, parameters);
				StartPollingIfNeeded();
			}
			else
			{
				CheckPendingPayments();
			}
			ProcessConfirmationQueue();
		}

		[Token(Token = "0x6002810")]
		[Address(RVA = "0x3E4E164", Offset = "0x3E4E164", Length = "0x268")]
		private static void StartPollingIfNeeded()
		{
			//IL_0021: Expected O, but got I4
			int num = 187244544 + 1440;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v66+E4]");
			if ((nint)0 != 0)
			{
				if (ElephantCore.Instance == null)
				{
					return;
				}
			}
			else if (ElephantCore.Instance == null)
			{
				return;
			}
			if (_activePollingCoroutine != null)
			{
				ElephantCore.Instance.StopCoroutine(_activePollingCoroutine);
				_activePollingCoroutine = null;
			}
			int num2 = 187269120 + 2640;
			object routine = new object();
			_ = 0;
			Coroutine activePollingCoroutine = ElephantCore.Instance.StartCoroutine((IEnumerator)routine);
			_activePollingCoroutine = activePollingCoroutine;
		}

		[Token(Token = "0x6002811")]
		[Address(RVA = "0x3E4E580", Offset = "0x3E4E580", Length = "0x5C")]
		private static IEnumerator PollForPendingPayments()
		{
			RemoteConfig instance = RemoteConfig.GetInstance();
			int num = instance.GetInt("ds_polling_max_attempts", 8);
			int maxAttempts = num;
			RemoteConfig instance2 = RemoteConfig.GetInstance();
			float num2 = instance2.GetFloat("ds_polling_initial_interval", 1f);
			RemoteConfig instance3 = RemoteConfig.GetInstance();
			float num3 = instance3.GetFloat("ds_polling_max_interval", 9.2E-44f);
			float maxInterval = num3;
			RemoteConfig instance4 = RemoteConfig.GetInstance();
			float num4 = instance4.GetFloat("ds_polling_timeout", 5f);
			float timeout = num4;
			HashSet<string> notifiedPendingThisSession = _notifiedPendingThisSession;
			int initialCount = notifiedPendingThisSession.Count;
			float currentInterval = num2;
			int i = 0;
			if (0 < maxAttempts)
			{
				int num6;
				do
				{
					bool isComplete = false;
					float? timeout2 = timeout;
					Action onComplete = delegate
					{
						isComplete = true;
					};
					CheckPendingPayments(timeout2, onComplete);
					while (!isComplete)
					{
						yield return null;
					}
					HashSet<string> notifiedPendingThisSession2 = _notifiedPendingThisSession;
					if (notifiedPendingThisSession2.Count > initialCount)
					{
						_activePollingCoroutine = null;
						yield break;
					}
					yield return new WaitForSeconds(currentInterval);
					float num5 = currentInterval + currentInterval;
					if (!(num5 < maxInterval))
					{
						num5 = maxInterval;
					}
					currentInterval = num5;
					num6 = i + 1;
					i = num6;
				}
				while (num6 < maxAttempts);
			}
			_activePollingCoroutine = null;
		}

		[Token(Token = "0x6002812")]
		[Address(RVA = "0x3E4C7A8", Offset = "0x3E4C7A8", Length = "0x4CC")]
		private static void CheckPendingPayments(float? timeout = null, Action onComplete = null)
		{
			if (_isCheckingPurchases || !_isInitialized || ElephantCore.Instance == null)
			{
				if (onComplete != null)
				{
					onComplete();
				}
				return;
			}
			if (!_hasLoggedCheckingEvent)
			{
				_hasLoggedCheckingEvent = true;
				Elephant.Event("elephant_ds_payment_checking", -1);
			}
			_isCheckingPurchases = true;
			ListPaymentsRequest value = ListPaymentsRequest.Create();
			string data = JsonConvert.SerializeObject(value);
			if ((object)ElephantCore.Instance != null)
			{
				SessionData currentSession = ElephantCore.Instance.GetCurrentSession();
				ElephantData value2 = new ElephantData(data, currentSession.start_time);
				string bodyJsonString = JsonConvert.SerializeObject(value2);
				GenericNetworkManager<List<ElephantPayment>> genericNetworkManager = new GenericNetworkManager<List<ElephantPayment>>();
				string dS_LIST_PAYMENTS = ElephantConstants.DS_LIST_PAYMENTS;
				Action<GenericResponse<List<ElephantPayment>>> onResponse = delegate(GenericResponse<List<ElephantPayment>> response)
				{
					_isCheckingPurchases = false;
					OnPendingPurchasesReceived(response);
					if (onComplete != null)
					{
						onComplete();
					}
				};
				Action<string> onError = delegate(string error)
				{
					_isCheckingPurchases = false;
					RaiseError(ElephantPaymentErrorType.PendingCheckFailed, "Failed to check pending payments.", error);
					if (onComplete != null)
					{
						onComplete();
					}
				};
				IEnumerator routine = genericNetworkManager.PostWithResponse(dS_LIST_PAYMENTS, bodyJsonString, onResponse, onError, timeout);
				Coroutine coroutine = ElephantCore.Instance.StartCoroutine(routine);
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6002813")]
		[Address(RVA = "0x3E4E610", Offset = "0x3E4E610", Length = "0x510")]
		private unsafe static void OnPendingPurchasesReceived(GenericResponse<List<ElephantPayment>> response)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantPayments::OnPendingPurchasesReceived");
		}

		[Token(Token = "0x6002814")]
		[Address(RVA = "0x3E4CC74", Offset = "0x3E4CC74", Length = "0x4E8")]
		private unsafe static void ProcessConfirmationQueue()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantPayments::ProcessConfirmationQueue");
		}

		[Token(Token = "0x6002815")]
		[Address(RVA = "0x3E4EB30", Offset = "0x3E4EB30", Length = "0x2CC")]
		private static IEnumerator NotifyPurchaseClaimed(string transactionId, Action onSuccess, Action<string> onError)
		{
			MarkPaymentProcessedRequest value = MarkPaymentProcessedRequest.Create(transactionId);
			string data = JsonConvert.SerializeObject(value);
			if ((object)ElephantCore.Instance != null)
			{
				SessionData currentSession = ElephantCore.Instance.GetCurrentSession();
				ElephantData value2 = new ElephantData(data, currentSession.start_time);
				string bodyJsonString = JsonConvert.SerializeObject(value2);
				GenericNetworkManager<object> genericNetworkManager = new GenericNetworkManager<object>();
				string dS_MARK_PAYMENT_PROCESSED = ElephantConstants.DS_MARK_PAYMENT_PROCESSED;
				Action<GenericResponse<object>> onResponse = delegate
				{
					if (onSuccess != null)
					{
						onSuccess();
					}
				};
				Action<string> onError2 = delegate(string error)
				{
					if (onError != null)
					{
						onError(error);
					}
				};
				return genericNetworkManager.PostWithResponse(dS_MARK_PAYMENT_PROCESSED, bodyJsonString, onResponse, onError2);
			}
			return (IEnumerator)new NullReferenceException();
		}

		[Token(Token = "0x6002816")]
		[Address(RVA = "0x3E4DDD4", Offset = "0x3E4DDD4", Length = "0x1D8")]
		private static void SaveConfirmationQueue()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantPayments::SaveConfirmationQueue");
		}

		[Token(Token = "0x6002817")]
		[Address(RVA = "0x3E4C050", Offset = "0x3E4C050", Length = "0x294")]
		private static void LoadConfirmationQueue()
		{
			if (_confirmationQueue != null)
			{
				_confirmationQueue.Clear();
				if (PlayerPrefs.HasKey("ELEPHANT_CONFIRM_QUEUE"))
				{
					string value = PlayerPrefs.GetString("ELEPHANT_CONFIRM_QUEUE");
					List<string> list = JsonConvert.DeserializeObject<List<string>>(value);
					if (list != null)
					{
						HashSet<string> confirmationQueue = new HashSet<string>((IEqualityComparer<string>)list);
						_confirmationQueue = confirmationQueue;
					}
				}
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6002818")]
		[Address(RVA = "0x3E4EED0", Offset = "0x3E4EED0", Length = "0x348")]
		private static string BuildCheckoutUrl(string escrowCode, long expiry, bool useWebView)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantPayments::BuildCheckoutUrl");
			return default;
		}

		[Token(Token = "0x6002819")]
		[Address(RVA = "0x3E4D15C", Offset = "0x3E4D15C", Length = "0x1C0")]
		private static void RaiseError(ElephantPaymentErrorType type, string message, string rawError = null, string productId = null, string transactionId = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantPayments::RaiseError");
		}

		[Token(Token = "0x600281A")]
		[Address(RVA = "0x3E4F220", Offset = "0x3E4F220", Length = "0x164")]
		static ElephantPayments()
		{
			HashSet<string> confirmationQueue = new HashSet<string>();
			_confirmationQueue = confirmationQueue;
			HashSet<string> activeConfirmations = new HashSet<string>();
			_activeConfirmations = activeConfirmations;
			HashSet<string> knownPendingTransactionIds = new HashSet<string>();
			_knownPendingTransactionIds = knownPendingTransactionIds;
			Dictionary<string, ElephantPayment> pendingPaymentInfo = new Dictionary<string, ElephantPayment>();
			_pendingPaymentInfo = pendingPaymentInfo;
			HashSet<string> notifiedPendingThisSession = new HashSet<string>();
			_notifiedPendingThisSession = notifiedPendingThisSession;
		}
	}
}
