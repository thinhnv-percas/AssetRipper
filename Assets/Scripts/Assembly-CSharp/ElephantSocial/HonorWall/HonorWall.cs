using System;
using Cpp2ILInjected;

namespace ElephantSocial.HonorWall
{
	[Token(Token = "0x20008EE")]
	public class HonorWall
	{
		[Token(Token = "0x4001DDE")]
		private static readonly Lazy<HonorWall> _instance;

		[Token(Token = "0x4001DDF")]
		[FieldOffset(Offset = "0x10")]
		private readonly HonorWallInternal _honorWallInternal;

		[Token(Token = "0x170003E4")]
		public static HonorWall Instance
		{
			[Token(Token = "0x6002593")]
			[Address(RVA = "0x3E08010", Offset = "0x3E08010", Length = "0x94")]
			get
			{
				return _instance.Value;
			}
		}

		[Token(Token = "0x6002594")]
		[Address(RVA = "0x3E080A4", Offset = "0x3E080A4", Length = "0x34")]
		private HonorWall()
		{
			HonorWallInternal instance = HonorWallInternal.GetInstance();
			_honorWallInternal = instance;
		}

		[Token(Token = "0x6002595")]
		[Address(RVA = "0x3E081CC", Offset = "0x3E081CC", Length = "0x1C")]
		public void GetHonors(Action<HonorWallResponse> onSuccess, Action<string> onError)
		{
			_honorWallInternal.GetHonors(onSuccess, onError, onError);
		}

		[Token(Token = "0x6002596")]
		[Address(RVA = "0x3E0838C", Offset = "0x3E0838C", Length = "0x1C")]
		public void GrantHonor(int honorId, Action onSuccess, Action<string> onError)
		{
			_honorWallInternal.GrantHonor(honorId, onSuccess, onError, onError);
		}

		[Token(Token = "0x6002597")]
		[Address(RVA = "0x3E08554", Offset = "0x3E08554", Length = "0x114")]
		static HonorWall()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HonorWall::.cctor");
		}
	}
}
