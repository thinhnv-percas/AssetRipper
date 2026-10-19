using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using ElephantSDK;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x2000004")]
	public class ResourceAnalytics : IResourceAnalytics
	{
		[Token(Token = "0x6000003")]
		[Address(RVA = "0x81D016C", Offset = "0x81D016C", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv63 = Unco.ResourceSystem.ResourceType;\n\tv68 = System.Enum::ToString(&v63 @ stack_-58_v2 (Il2CppClass<Unco.ResourceSystem.ResourceType>));\n\tv78 = resourceType != 5;\n\tif (v78) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv124 = \"coin\";\n\tgoto L_0047;\nL_FFFFFFFF:\n\tv124 = v68;\nL_0047:\n\tv175 = System.String::ToString(context.Source);\n\tgoto L_0057;\nL_0057:\n\tElephantSDK.Elephant::Transaction(v124, context.Level, delta, newAmount, v175);\nL_0061:\n\treturn;\nL_0021:\n\tv52 = context.SuppressAnalytics == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0061;\n")]
		public void RecordTransaction(ResourceType resourceType, long delta, long newAmount, TransactionContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceAnalytics::RecordTransaction");
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x81D0278", Offset = "0x81D0278", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ResourceAnalytics()
		{
		}
	}
}
