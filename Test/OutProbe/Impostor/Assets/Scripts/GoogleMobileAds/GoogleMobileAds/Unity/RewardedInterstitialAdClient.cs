using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Unity
{
	[Token(Token = "0x2000010")]
	public class RewardedInterstitialAdClient : RewardingAdBaseClient, IRewardedInterstitialAdClient
	{
		[Token(Token = "0x600006D")]
		[Address(RVA = "0x13422E8", Offset = "0x13422E8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void CreateRewardedInterstitialAd()
		{
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x13422EC", Offset = "0x13422EC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGoogleMobileAds.Unity.RewardingAdBaseClient::LoadAd(this, adUnitID);\n\treturn;\n")]
		public void LoadAd(string adUnitID, AdRequest request)
		{
			base.LoadAd((AdRequest)(object)adUnitID);
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x133E39C", Offset = "0x133E39C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = GoogleMobileAds.Unity.RewardingAdBaseClient;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A36774]) = v37;\nL_0017:\n\tgoto L_001F;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\tGoogleMobileAds.Unity.RewardingAdBaseClient::.ctor(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RewardedInterstitialAdClient()
		{
		}
	}
}
