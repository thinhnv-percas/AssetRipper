using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x200000F")]
	public class AppleValidator
	{
		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x10")]
		private X509Cert cert;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x18")]
		private AppleReceiptParser parser;

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x15D3154", Offset = "0x15D3154", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EE4278]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, appleRootCertificate, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029A21]) = v41;\nL_0018:\n\tv45 = new UnityEngine.Purchasing.Security.AppleReceiptParser();\n\tSystem.Object::.ctor(v45);\n\tthis.parser = v45;\n\tSystem.Object::.ctor(this);\n\tv53 = new UnityEngine.Purchasing.Security.X509Cert();\n\tUnityEngine.Purchasing.Security.X509Cert::.ctor(v53, appleRootCertificate);\n\tthis.cert = v53;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AppleValidator(byte[] appleRootCertificate)
		{
			AppleReceiptParser appleReceiptParser = new AppleReceiptParser();
			parser = appleReceiptParser;
			X509Cert x509Cert = new X509Cert(appleRootCertificate);
			cert = x509Cert;
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x15D3364", Offset = "0x15D3364", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ED3EB0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, receiptData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029A22]) = v41;\nL_001B:\n\tv48 = UnityEngine.Purchasing.Security.AppleReceiptParser::Parse(this.parser, receiptData, &v46 @ stack_-28_v4 (UnityEngine.Purchasing.Security.PKCS7));\n\tv66 = UnityEngine.Purchasing.Security.PKCS7::Verify(v46, this.cert, v48.<receiptCreationDate>k__BackingField);\n\tv68 = v66 == 0;\n\tif (v68) goto L_0034;\n\treturn v48;\n\tthrow System.NullReferenceException;\nL_0034:\n\tv73 = new UnityEngine.Purchasing.Security.InvalidSignatureException();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v73);\n\tthrow v73;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AppleReceipt Validate(byte[] receiptData)
		{
			AppleReceipt appleReceipt = parser.Parse(receiptData, out var receipt);
			if (receipt.Verify(cert, appleReceipt.receiptCreationDate))
			{
				return appleReceipt;
			}
			InvalidSignatureException ex = (InvalidSignatureException)new IAPSecurityException();
			throw ex;
		}
	}
}
