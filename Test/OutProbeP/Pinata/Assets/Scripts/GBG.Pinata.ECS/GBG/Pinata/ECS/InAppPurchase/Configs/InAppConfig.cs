using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace GBG.Pinata.ECS.InAppPurchase.Configs
{
	[CreateAssetMenu]
	[Token(Token = "0x200005A")]
	public class InAppConfig : ScriptableObject
	{
		[Multiline]
		[Token(Token = "0x40000F8")]
		[FieldOffset(Offset = "0x18")]
		public string AndroidAgreementText;

		[Multiline]
		[Token(Token = "0x40000F9")]
		[FieldOffset(Offset = "0x20")]
		public string IOSAgreementText;

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0xCBF3D0", Offset = "0xCBF3D0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EDE220]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202371F]) = v38;\nL_0018:\n\tthis.AndroidAgreementText = \"These purchases are auto-renewable subscription. Payment will be charged to your Google account at the confirmation of purchase or at the end of the trial period of purchase. The subscription automatically renews unless auto-renew is turned off at least 24 hours before the end of the current period. Your account will be charged for renewal within 24 hours prior to the end of the current period. You can manage and turn off auto-renewal of subscription by going to your account settings on the Google Play after purchase. Any unused portion of a free trial period will be forfeited when the user purchases a subscription to that publication, where applicable.\";\n\tthis.IOSAgreementText = \"These purchases are auto-renewable subscription. Payment will be charged to your AppStore account at the confirmation of purchase or at the end of the trial period of purchase. The subscription automatically renews unless auto-renew is turned off at least 24 hours before the end of the current period. Your account will be charged for renewal within 24 hours prior to the end of the current period. You can manage and turn off auto-renewal of subscription by going to your account settings on the AppStore after purchase. Any unused portion of a free trial period will be forfeited when the user purchases a subscription to that publication, where applicable.\";\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InAppConfig()
		{
			AndroidAgreementText = "These purchases are auto-renewable subscription. Payment will be charged to your Google account at the confirmation of purchase or at the end of the trial period of purchase. The subscription automatically renews unless auto-renew is turned off at least 24 hours before the end of the current period. Your account will be charged for renewal within 24 hours prior to the end of the current period. You can manage and turn off auto-renewal of subscription by going to your account settings on the Google Play after purchase. Any unused portion of a free trial period will be forfeited when the user purchases a subscription to that publication, where applicable.";
			IOSAgreementText = "These purchases are auto-renewable subscription. Payment will be charged to your AppStore account at the confirmation of purchase or at the end of the trial period of purchase. The subscription automatically renews unless auto-renew is turned off at least 24 hours before the end of the current period. Your account will be charged for renewal within 24 hours prior to the end of the current period. You can manage and turn off auto-renewal of subscription by going to your account settings on the AppStore after purchase. Any unused portion of a free trial period will be forfeited when the user purchases a subscription to that publication, where applicable.";
		}
	}
}
