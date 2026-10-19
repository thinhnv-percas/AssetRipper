using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;

namespace _game.Systems.Offers
{
	[Token(Token = "0x2000764")]
	public class OfferService : IDisposable
	{
		[Token(Token = "0x40018B4")]
		[FieldOffset(Offset = "0x10")]
		internal readonly List<OfferElement> _offers;

		[Token(Token = "0x40018B5")]
		[FieldOffset(Offset = "0x18")]
		private bool _isShowingOffer;

		[Token(Token = "0x170002FA")]
		public bool IsShowingOffer
		{
			[Token(Token = "0x6001F2E")]
			[Address(RVA = "0x3D8CF20", Offset = "0x3D8CF20", Length = "0x8")]
			get
			{
				return _isShowingOffer;
			}
		}

		[Token(Token = "0x6001F2F")]
		[Address(RVA = "0x3D8CF28", Offset = "0x3D8CF28", Length = "0x144")]
		public void AddOffer(OfferElement offer)
		{
			if (!_offers.Contains(offer))
			{
				bool isPriority = offer.IsPriority;
				List<OfferElement> offers = _offers;
				if (isPriority)
				{
					offers.Insert(0, offer);
				}
				else
				{
					offers.Add(offer);
				}
			}
		}

		[Token(Token = "0x6001F30")]
		[Address(RVA = "0x3D8D06C", Offset = "0x3D8D06C", Length = "0xDC")]
		public void RemoveOffer(OfferId id)
		{
			Predicate<OfferElement> match = delegate(OfferElement o)
			{
				OfferId offerId = o.GetOfferId();
				int num2 = offerId - id;
				return num2 == 0;
			};
			int num = _offers.RemoveAll(match);
		}

		[Token(Token = "0x6001F31")]
		[Address(RVA = "0x3D8D150", Offset = "0x3D8D150", Length = "0xDC")]
		public OfferElement GetOffer(OfferId id)
		{
			Predicate<OfferElement> match = delegate(OfferElement o)
			{
				OfferId offerId = o.GetOfferId();
				int num = offerId - id;
				return num == 0;
			};
			return _offers.Find(match);
		}

		[Token(Token = "0x6001F32")]
		[Address(RVA = "0x3D8B4BC", Offset = "0x3D8B4BC", Length = "0x1AC")]
		public bool TryShowNext(Instancer instancer, Action onAllComplete = null)
		{
			if (!IsShowingOffer)
			{
				List<OfferElement> offers = _offers;
				int num = 0;
				while (num < offers.Count)
				{
					OfferElement offerElement = offers[num];
					if (offerElement.IsDisabled || !offerElement.IsActive())
					{
						num++;
						offers = _offers;
						continue;
					}
					_isShowingOffer = true;
					Action onComplete = delegate
					{
						OfferService offerService = this;
						offerService._isShowingOffer = false;
						bool flag = offerService.TryShowNext(instancer, onAllComplete);
						if (onAllComplete != null && !flag)
						{
							onAllComplete();
						}
					};
					offerElement.Trigger(instancer, onComplete);
					return true;
				}
			}
			return false;
		}

		[Token(Token = "0x6001F33")]
		[Address(RVA = "0x3D8D23C", Offset = "0x3D8D23C", Length = "0x44")]
		private void OnOfferComplete(Instancer instancer, Action onAllComplete)
		{
			_isShowingOffer = false;
			bool flag = TryShowNext(instancer, onAllComplete);
			if (onAllComplete != null && !flag)
			{
				onAllComplete();
			}
		}

		[Token(Token = "0x6001F34")]
		[Address(RVA = "0x3D8D280", Offset = "0x3D8D280", Length = "0x17C")]
		public unsafe void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OfferService::Dispose");
		}

		[Token(Token = "0x6001F35")]
		[Address(RVA = "0x3D8D3FC", Offset = "0x3D8D3FC", Length = "0x8C")]
		public OfferService()
		{
			List<OfferElement> offers = new List<OfferElement>();
			_offers = offers;
		}
	}
}
