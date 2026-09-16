using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using LipingShare.LCLib.Asn1Processor;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000010")]
	public class AppleReceiptParser
	{
		[Token(Token = "0x400001E")]
		private static Dictionary<string, object> _mostRecentReceiptData;

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x15D222C", Offset = "0x15D222C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = 0;\n\treturnVal1 = UnityEngine.Purchasing.Security.AppleReceiptParser::Parse(this, receiptData, &v7 @ stack_-18_v1 (UnityEngine.Purchasing.Security.PKCS7));\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AppleReceipt Parse(byte[] receiptData)
		{
			PKCS7 receipt = null;
			return Parse(receiptData, out receipt);
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x15D2250", Offset = "0x15D2250", Length = "0x4E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv36 = *([1EAA4A0]);\n\tv37 = *([v36 @ X8_v77]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, receiptData, receipt, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2029A1C]) = v54;\nL_0022:\n\tgoto L_0033;\n\tv61 = *([v57 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.Security.AppleReceiptParser>)+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\t// 38 Jump @b101\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v57, receiptData, receipt, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv65 = UnityEngine.Purchasing.Security.AppleReceiptParser;\nL_0033:\n\tv78 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v68._mostRecentReceiptData, \"k_AppleReceiptKey\");\n\tv177 = v78 == 0;\n\tif (v177) goto L_00E8;\n\tgoto L_004A;\n\tv326 = *([v226 @ X0_v53 (Il2CppClass<UnityEngine.Purchasing.Security.AppleReceiptParser>)+E0]);\n\tv327 = v326 == 0;\n\tv328 = ~v327;\n\t// 63 ConditionalJump @b102, v328 @ TEMP_v73\n\tv369 = \"il2cpp_codegen_runtime_class_init\"(v226, v76, v77, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv330 = UnityEngine.Purchasing.Security.AppleReceiptParser;\nL_004A:\n\tv249 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v168._mostRecentReceiptData, \"k_PKCS7Key\");\n\tv254 = v249 == 0;\n\tif (v254) goto L_00E8;\n\tgoto L_0061;\n\tv450 = *([v446 @ X0_v57 (Il2CppClass<UnityEngine.Purchasing.Security.AppleReceiptParser>)+E0]);\n\tv451 = v450 == 0;\n\tv452 = ~v451;\n\t// 86 ConditionalJump @b103, v452 @ TEMP_v71\n\tv469 = \"il2cpp_codegen_runtime_class_init\"(v446, v145, v139, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv454 = UnityEngine.Purchasing.Security.AppleReceiptParser;\nL_0061:\n\tv250 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v169._mostRecentReceiptData, \"k_ReceiptBytesKey\");\n\tv255 = v250 == 0;\n\tif (v255) goto L_00E8;\n\tgoto L_0078;\n\tv553 = *([v482 @ X0_v61 (Il2CppClass<UnityEngine.Purchasing.Security.AppleReceiptParser>)+E0]);\n\tv554 = v553 == 0;\n\tv555 = ~v554;\n\t// 109 ConditionalJump @b104, v555 @ TEMP_v69\n\tv603 = \"il2cpp_codegen_runtime_class_init\"(v482, v146, v140, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv557 = UnityEngine.Purchasing.Security.AppleReceiptParser;\nL_0078:\n\tv607 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v170._mostRecentReceiptData, \"k_ReceiptBytesKey\");\n\tv667 = v607 == 0;\n\tif (v667) goto L_FFFFFFFF;\n\t// 129 IsInst v723 @ X0_v81 (System.Byte[]), typeof(System.Byte[]), v607 @ X0_v64 (Il2CppMethodInfo)\n\tv744 = v723 == 0;\n\tv730 = ~v744;\n\tif (v730) goto L_008E;\n\tthrow System.InvalidCastException;\nL_008E:\n\tv251 = UnityEngine.Purchasing.Security.AppleReceiptParser::ArrayEquals(receiptData, v147);\n\tv256 = v251 == 0;\n\tif (v256) goto L_00E8;\n\tgoto L_00A3;\n\tv760 = *([v755 @ X0_v68 (Il2CppClass<UnityEngine.Purchasing.Security.AppleReceiptParser>)+E0]);\n\tv761 = v760 == 0;\n\tv762 = ~v761;\n\t// 154 ConditionalJump @b106, v762 @ TEMP_v64\n\tv768 = \"il2cpp_codegen_runtime_class_init\"(v755, v147, v141, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv764 = UnityEngine.Purchasing.Security.AppleReceiptParser;\nL_00A3:\n\tv770 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v171._mostRecentReceiptData, \"k_PKCS7Key\");\n\tv253 = v770 == 0;\n\tif (v253) goto L_017F;\n\tgoto L_FFFFFFFF;\n\tv799 = v799_asT == 0;\n\tif (v799) goto L_00E4;\n\t*([receipt @ X2 (UnityEngine.Purchasing.Security.PKCS7&)]) = v770;\n\tgoto L_FFFFFFFF;\n\tv810 = v810_asT != 0;\n\tif (v810) goto L_0187;\nL_00E4:\n\tthrow System.InvalidCastException;\nL_00E8:\n\tv264 = new System.IO.MemoryStream();\n\tSystem.IO.MemoryStream::.ctor(v264, receiptData);\n\tv373 = new LipingShare.LCLib.Asn1Processor.Asn1Parser();\n\tLipingShare.LCLib.Asn1Processor.Asn1Parser::.ctor(v373);\n\tLipingShare.LCLib.Asn1Processor.Asn1Parser::LoadData(v373, v264);\n\tv474 = new UnityEngine.Purchasing.Security.PKCS7();\n\tSystem.Object::.ctor(v474);\n\tv474.root = v373.rootNode;\n\tUnityEngine.Purchasing.Security.PKCS7::CheckStructure(v474);\n\t*([receipt @ X2 (UnityEngine.Purchasing.Security.PKCS7&)]) = v474;\n\tv561 = UnityEngine.Purchasing.Security.AppleReceiptParser::ParseReceipt(this, v474.<data>k__BackingField);\n\tgoto L_011E;\n\tv668 = *([v608 @ X0_v46 (Il2CppClass<UnityEngine.Purchasing.Security.AppleReceiptParser>)+E0]);\n\tv669 = v668 == 0;\n\tv670 = ~v669;\n\t// 274 ConditionalJump @b108, v670 @ TEMP_v35\n\tv733 = \"il2cpp_codegen_runtime_class_init\"(v608, v355, v211, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv672 = UnityEngine.Purchasing.Security.AppleReceiptParser;\nL_011E:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v366._mostRecentReceiptData, \"k_AppleReceiptKey\", v561);\n\tv430 = receipt->klass;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v407._mostRecentReceiptData, \"k_PKCS7Key\", *([receipt @ X2 (UnityEngine.Purchasing.Security.PKCS7&)]));\n\tv438 = v443._mostRecentReceiptData == 0;\n\tif (v438) goto L_01B5;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v443._mostRecentReceiptData, \"k_ReceiptBytesKey\", receiptData);\n\tv588 = v264 == 0;\n\tif (v588) goto L_0167;\nL_013F:\n\tgoto L_0166;\n\tv637 = *([v598 @ X8_v15+B0]);\n\tv638 = 0;\n\tv639 = v637 + 8;\n\tv641 = *([v708 @ X11_v14-8]);\n\tv713 = v641 == v601;\n\tif (v713) goto L_015F;\n\tv661 = v707 + 1;\n\tv735 = v661 < v600;\n\tv659 = ~v735;\n\tv663 = v708 + 0x10;\n\tv643 = ~v659;\n\tif (v643) goto L_FFFFFFFF;\n\tv664 = v596;\n\tv665 = 0;\n\tv666 = 0x8909C4(v664, v601, v665, v563, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0166;\nL_015F:\n\tv736 = *([v708 @ X11_v14]);\n\tv737 = v736 << 4;\n\tv738 = v598 + v737;\n\tv739 = v738 + 0x130;\nL_0166:\n\tSystem.IDisposable::Dispose(v596);\nL_0167:\n\tv636 = v315 + 1;\n\tv283 = v636 == 0;\n\tv273 = ~v283;\n\tif (v273) goto L_017E;\n\tv675 = v317 == 0;\n\tv311 = ~v675;\n\tif (v311) goto L_01B2;\nL_017E:\n\treturn v692;\nL_017F:\n\t*([receipt @ X2 (UnityEngine.Purchasing.Security.PKCS7&)]) = 0;\nL_0187:\n\tv691 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v172._mostRecentReceiptData, \"k_AppleReceiptKey\");\n\tv158 = v691 == 0;\n\tif (v158) goto L_017E;\n\tgoto L_FFFFFFFF;\n\tv681 = v681_asT != 0;\n\tif (v681) goto L_017E;\n\tv151 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_01B2:\n\tv325 = new System.TypeLoadException();\n\tv368 = new System.NullReferenceException();\n\tv409 = new System.NullReferenceException();\nL_01B5:\n\tv445 = new System.NullReferenceException();\n\tgoto L_01C8;\n\tgoto L_01C8;\n\tgoto L_01C8;\n\tgoto L_01C8;\n\tgoto L_01C8;\n\tgoto L_01C8;\n\tgoto L_01C8;\n\tgoto L_01C8;\n\tgoto L_01C8;\nL_01C8:\n\tv468 = v432 != 1;\n\tif (v468) goto L_01D3;\n\tv475 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v445, v432, v430);\n\tv592 = *([v475 @ X0_v9]);\n\tv481 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v475, v432, v430);\n\tv489 = v596 == 0;\n\tv490 = ~v489;\n\tif (v490) goto L_013F;\n\tgoto L_0167;\nL_01D3:\n\treturnVal1 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v445, v432, v430);\n\treturn returnVal1;\n// 307 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe AppleReceipt Parse(byte[] receiptData, out PKCS7 receipt)
		{
			//IL_00c1: Expected I, but got O
			//IL_046d: Expected I4, but got O
			//IL_00e7: Expected O, but got I
			//IL_04d0: Expected I4, but got O
			receipt = null;
			ref PKCS7 reference;
			if (_mostRecentReceiptData.ContainsKey("k_AppleReceiptKey") && _mostRecentReceiptData.ContainsKey("k_PKCS7Key") && _mostRecentReceiptData.ContainsKey("k_ReceiptBytesKey"))
			{
				IntPtr intPtr = (IntPtr)_mostRecentReceiptData.get_Item("k_ReceiptBytesKey");
				byte[] b;
				if (intPtr != (IntPtr)0)
				{
					byte[] array = ((long)intPtr) as byte[];
					bool flag = array == null;
					bool flag2 = !flag;
					b = array;
					if (!flag2)
					{
						throw new InvalidCastException();
					}
				}
				else
				{
					b = null;
				}
				if (ArrayEquals(receiptData, b))
				{
					object obj = _mostRecentReceiptData.get_Item("k_PKCS7Key");
					if (obj != null)
					{
						PKCS7 pKCS = obj as PKCS7;
						if (pKCS != null)
						{
							reference = ref *(PKCS7*)obj;
							PKCS7 pKCS2 = obj as PKCS7;
							if (pKCS2 != null)
							{
								goto IL_0363;
							}
						}
						throw new InvalidCastException();
					}
					reference = ref *(PKCS7*)null;
					goto IL_0363;
				}
			}
			MemoryStream memoryStream = new MemoryStream(receiptData);
			Asn1Parser asn1Parser = new Asn1Parser();
			asn1Parser.LoadData(memoryStream);
			PKCS7 pKCS3 = null;
			pKCS3.root = asn1Parser.RootNode;
			pKCS3.CheckStructure();
			reference = ref *(PKCS7*)pKCS3;
			AppleReceipt appleReceipt = ParseReceipt(pKCS3.data);
			_mostRecentReceiptData.set_Item("k_AppleReceiptKey", (object)appleReceipt);
			PKCS7 value = receipt;
			_mostRecentReceiptData.set_Item("k_PKCS7Key", (object)receipt);
			bool flag3 = _mostRecentReceiptData == null;
			string text = "k_PKCS7Key";
			MemoryStream memoryStream2 = memoryStream;
			if (flag3)
			{
				goto IL_0426;
			}
			_mostRecentReceiptData.set_Item("k_ReceiptBytesKey", (object)receiptData);
			bool flag4 = memoryStream == null;
			AppleReceipt appleReceipt2 = appleReceipt;
			int num = 0;
			int num2 = 0;
			memoryStream2 = memoryStream;
			AppleReceipt result = appleReceipt;
			int num3 = 0;
			int num4 = 0;
			MemoryStream memoryStream3 = memoryStream;
			if (flag4)
			{
				goto IL_0526;
			}
			goto IL_055c;
			IL_0526:
			if (num3 + 1 != 0 || num4 == 0)
			{
				goto IL_0350;
			}
			TypeLoadException ex = new TypeLoadException();
			NullReferenceException ex2 = new NullReferenceException();
			text = null;
			NullReferenceException ex3 = new NullReferenceException();
			value = null;
			memoryStream2 = memoryStream3;
			goto IL_0426;
			IL_0363:
			AppleReceipt appleReceipt3 = (AppleReceipt)_mostRecentReceiptData.get_Item("k_AppleReceiptKey");
			bool flag5 = appleReceipt3 == null;
			result = appleReceipt3;
			if (!flag5)
			{
				AppleReceipt appleReceipt4 = appleReceipt3 as AppleReceipt;
				bool flag6 = appleReceipt4 != null;
				result = appleReceipt3;
				if (!flag6)
				{
					InvalidCastException ex4 = new InvalidCastException();
					throw new NullReferenceException();
				}
			}
			goto IL_0350;
			IL_055c:
			((IDisposable)memoryStream2).Dispose();
			result = appleReceipt2;
			num3 = num;
			num4 = num2;
			memoryStream3 = memoryStream2;
			goto IL_0526;
			IL_0426:
			NullReferenceException ex5 = new NullReferenceException();
			if ((IntPtr)text == (IntPtr)1)
			{
				((Dictionary<string, object>)(object)ex5).set_Item(text, (object)value);
				object obj2 = default(object);
				num2 = (int)obj2;
				((Dictionary<string, object>)obj2).set_Item(text, (object)value);
				bool flag7 = memoryStream2 == null;
				bool flag8 = !flag7;
				appleReceipt2 = null;
				num = -1;
				if (flag8)
				{
					goto IL_055c;
				}
				result = null;
				num3 = -1;
				num4 = (int)obj2;
				memoryStream3 = memoryStream2;
				goto IL_0526;
			}
			((Dictionary<string, object>)(object)ex5).set_Item(text, (object)value);
			AppleReceipt result2 = default(AppleReceipt);
			return result2;
			IL_0350:
			return result;
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x15D2760", Offset = "0x15D2760", Length = "0x428")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = *([1F08FA8]);\n\tv35 = *([v34 @ X8_v35]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, data, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 0 | 1;\n\t*([2029A1D]) = v54;\nL_001C:\n\tv56 = data == 0;\n\tif (v56) goto L_018F;\n\tv57 = data.childNodeList;\n\tv124 = System.Collections.ArrayList::get_Count(v57);\n\tv81 = v124 != 1;\n\tif (v81) goto L_018F;\n\tv215 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(data, 0);\n\tv226 = new UnityEngine.Purchasing.Security.AppleReceipt();\n\tSystem.Object::.ctor(v226);\n\tv301 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>::.ctor(v301);\n\tv57 = v215.childNodeList;\n\tv147 = 0x183F000 + 0x424;\nL_0056:\n\tv407 = System.Collections.ArrayList::get_Count(v57);\n\tv152 = v407 <= v146;\n\tif (v152) goto L_0178;\n\tv196 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v215, v146);\n\tv57 = v196.childNodeList;\n\tv430 = System.Collections.ArrayList::get_Count(v196.childNodeList);\n\tv153 = v430 != 3;\n\tif (v153) goto L_016B;\n\tv198 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v196, 0);\n\tv438 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v198);\n\tgoto L_008F;\n\tv443 = *([v209 @ X8_v25+E0]);\n\tv444 = v443 == 0;\n\tv445 = ~v444;\n\tif (v445) goto L_008F;\n\tv450 = v209;\n\tv447 = \"il2cpp_codegen_runtime_class_init\"(v450, v189, v140, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_008F:\n\tv449 = LipingShare.LCLib.Asn1Processor.Asn1Util::BytesToLong(v438);\n\tv284 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v196, 2);\n\tv335 = v449 <= 0xC;\n\tif (v335) goto L_00CE;\n\tv350 = v449 == 0x11;\n\tif (v350) goto L_013B;\n\tv154 = v449 != 0x13;\n\tif (v154) goto L_016B;\n\tv373 = System.Text.Encoding::get_UTF8();\n\tv199 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v284, 0);\n\tv374 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v199);\n\tv395 = *([v373 @ X0_v60 (System.Text.Encoding)]);\n\tv312 = *([v395 @ X8_v32 (Il2CppClass<System.Text.Encoding>)+358]);\n\tv375 = System.Text.Encoding::GetString(v373, v374);\n\t*([v226 @ X0_v14 (System.Object)+30]) = v375;\n\tgoto L_016B;\nL_00CE:\n\tv210 = v449 - 2;\n\tv464 = v210 < 3;\n\tv465 = ~v464;\n\tv466 = v210 - 3;\n\tv468 = v466 == 0;\n\tv473 = ~v465;\n\tv474 = v473 | v468;\n\tif (v474) goto L_0110;\n\tv155 = v449 != 0xC;\n\tif (v155) goto L_016B;\n\tv376 = System.Text.Encoding::get_UTF8();\n\tv200 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v284, 0);\n\tv377 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v200);\n\tv490 = *([v376 @ X0_v42 (System.Text.Encoding)]);\n\tv312 = *([v490 @ X8_v30 (Il2CppClass<System.Text.Encoding>)+358]);\n\tv493 = System.Text.Encoding::GetString(v376, v377);\n\tgoto L_0107;\n\tv497 = *([v396 @ X8_v31+E0]);\n\tv498 = v497 == 0;\n\tv499 = ~v498;\n\tif (v499) goto L_0107;\n\tv506 = v396;\n\tv501 = \"il2cpp_codegen_runtime_class_init\"(v506, v363, v314, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0107:\n\tv505 = System.DateTime::Parse(v493);\n\tv57 = 0xE95E88(&v505 @ X0_v50 (System.DateTime), 0, *([v490 @ X8_v30 (Il2CppClass<System.Text.Encoding>)+358]), v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([v226 @ X0_v14 (System.Object)+38]) = v57;\n\tgoto L_016B;\nL_0110:\n\tv477 = v210 < 3;\n\tv276 = ~v477;\n\tv273 = v210 - 3;\n\tv267 = v273 == 0;\n\tv478 = ~v267;\n\tv252 = v276 & v478;\n\tif (v252) goto L_016B;\n\tv484 = v210 & 0xFFFFFFFF;\n\tv292 = *([v147 @ X28_v7 (System.Int32)+v484 @ X8_v27 (System.Int64)*4]) + v147;\n\t// 287 IndirectJump v292 @ X8_v29, v284 @ X0_v40 (LipingShare.LCLib.Asn1Processor.Asn1Node), v284 @ X0_v40 (LipingShare.LCLib.Asn1Processor.Asn1Node), 2, v312 @ X2_v7 (Il2CppMethodInfo), v38 @ X3, v39 @ X4, v40 @ X5, v41 @ X6, v42 @ X7, v43 @ V0, v44 @ V1, v45 @ V2, v46 @ V3, v47 @ V4, v48 @ V5, v49 @ V6, v50 @ V7\n\tX0 = 0;\n\tX0 = System.Text.Encoding::get_UTF8(X0);\n\tX24 = X0;\n\tif (TEMP) goto L_0171;\n\tX0 = X23;\n\tX1 = 0;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(X0, X1, X2);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(X0, X1);\n\tX1 = X0;\n\tif (TEMP) goto L_0171;\n\tX8 = *([X24]);\n\tX0 = X24;\n\tX9 = *([X8+350]);\n\tX2 = *([X8+358]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0171;\n\t*([X19+10]) = X0;\n\tgoto L_016B;\nL_013B:\n\tv482 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v284, 0);\n\tv379 = UnityEngine.Purchasing.Security.AppleReceiptParser::ParseInAppReceipt(v482, v482);\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>::Add(v301, v379);\n\tgoto L_016B;\n\tX0 = 0;\n\tX0 = System.Text.Encoding::get_UTF8(X0);\n\tX24 = X0;\n\tif (TEMP) goto L_0171;\n\tX0 = X23;\n\tX1 = 0;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(X0, X1, X2);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(X0, X1);\n\tX1 = X0;\n\tif (TEMP) goto L_0171;\n\tX8 = *([X24]);\n\tX0 = X24;\n\tX9 = *([X8+350]);\n\tX2 = *([X8+358]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0171;\n\t*([X19+18]) = X0;\n\tgoto L_016B;\n\tif (TEMP) goto L_0171;\n\tX0 = X23;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(X0, X1);\n\tif (TEMP) goto L_0171;\n\t*([X19+20]) = X0;\n\tgoto L_016B;\n\tif (TEMP) goto L_0171;\n\tX0 = X23;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(X0, X1);\n\tif (TEMP) goto L_0171;\n\t*([X19+28]) = X0;\nL_016B:\n\tv57 = v215.childNodeList;\n\tv146 = v146 + 1;\n\tv437 = v215.childNodeList == 0;\n\tv383 = ~v437;\n\tif (v383) goto L_0056;\nL_0171:\n\tthrow System.NullReferenceException;\nL_0178:\n\tv381 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt>::ToArray(v301);\n\t*([v226 @ X0_v14 (System.Object)+40]) = v381;\n\treturn v226;\n\tthrow System.NullReferenceException;\nL_018F:\n\tv137 = new UnityEngine.Purchasing.Security.InvalidPKCS7Data();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v137);\n\tthrow v137;\n// 254 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private AppleReceipt ParseReceipt(Asn1Node data)
		{
			//IL_03bd: Expected O, but got I
			//IL_02e8: Expected I, but got O
			//IL_01ee: Expected I, but got O
			if (data != null)
			{
				ArrayList childNodeList = data.childNodeList;
				int count = childNodeList.Count;
				if (count == 1)
				{
					Asn1Node childNode = data.GetChildNode(0);
					object result = new AppleReceipt();
					List<AppleInAppPurchaseReceipt> list = new List<AppleInAppPurchaseReceipt>();
					childNodeList = childNode.childNodeList;
					int num = 25423872 + 1060;
					int num2 = 0;
					while (true)
					{
						int count2 = childNodeList.Count;
						if (count2 <= num2)
						{
							break;
						}
						Asn1Node childNode2 = childNode.GetChildNode(num2);
						childNodeList = childNode2.childNodeList;
						int count3 = childNode2.childNodeList.Count;
						Asn1Node childNode4;
						IntPtr intPtr2;
						if (count3 == 3)
						{
							Asn1Node childNode3 = childNode2.GetChildNode(0);
							byte[] data2 = childNode3.Data;
							long num3 = Asn1Util.BytesToLong(data2);
							childNode4 = childNode2.GetChildNode(2);
							if (num3 > 12)
							{
								switch (num3)
								{
								case 19L:
								{
									Encoding uTF = Encoding.UTF8;
									Asn1Node childNode5 = childNode4.GetChildNode(0);
									byte[] data3 = childNode5.Data;
									IntPtr intPtr = (IntPtr)uTF;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X8_v32 (Il2CppClass<System.Text.Encoding>)+358]");
									intPtr2 = (IntPtr)0;
									string text = uTF.GetString(data3);
									goto IL_045a;
								}
								case 17L:
									break;
								default:
									goto IL_045a;
								}
								goto IL_03c7;
							}
							long num4 = num3 - 2;
							bool flag = num4 < 3;
							bool flag2 = !flag;
							long num5 = num4 - 3;
							bool flag3 = num5 == 0;
							bool flag4 = !flag2;
							if (!(flag4 || flag3))
							{
								if (num3 == 12)
								{
									Encoding uTF2 = Encoding.UTF8;
									Asn1Node childNode6 = childNode4.GetChildNode(0);
									byte[] data4 = childNode6.Data;
									IntPtr intPtr3 = (IntPtr)uTF2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ X8_v30 (Il2CppClass<System.Text.Encoding>)+358]");
									intPtr2 = (IntPtr)0;
									string s = uTF2.GetString(data4);
									DateTime dateTime = DateTime.Parse(s);
									Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E95E88 (inside System.DateTime::ParseExact +0x1C0)");
								}
							}
							else
							{
								bool flag5 = num4 < 3;
								bool flag6 = !flag5;
								long num6 = num4 - 3;
								bool flag7 = num6 == 0;
								bool flag8 = !flag7;
								if (!(flag6 && flag8))
								{
									long num7 = num4 & 0xFFFFFFFFL;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ X28_v7 (System.Int32)+v484 @ X8_v27 (System.Int64)*4]");
									object obj = 0L + (long)num;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v292 @ X8_v29 (should have been resolved before IL gen)");
									goto IL_03c7;
								}
							}
						}
						goto IL_045a;
						IL_045a:
						childNodeList = childNode.childNodeList;
						num2++;
						if (childNode.childNodeList == null)
						{
							throw new NullReferenceException();
						}
						continue;
						IL_03c7:
						Asn1Node childNode7 = childNode4.GetChildNode(0);
						AppleInAppPurchaseReceipt item = ((AppleReceiptParser)(object)childNode7).ParseInAppReceipt(childNode7);
						list.Add(item);
						intPtr2 = (IntPtr)0;
						goto IL_045a;
					}
					AppleInAppPurchaseReceipt[] array = list.ToArray();
					return (AppleReceipt)result;
				}
			}
			InvalidPKCS7Data invalidPKCS7Data = (InvalidPKCS7Data)new IAPSecurityException();
			throw invalidPKCS7Data;
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x15D2B8C", Offset = "0x15D2B8C", Length = "0x444")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EFEB98]);\n\tv31 = *([v30 @ X8_v18]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, inApp, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 0 | 1;\n\t*([2029A1E]) = v50;\nL_001C:\n\tv54 = new UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt();\n\tSystem.Object::.ctor(v54);\n\tv149 = inApp.childNodeList;\n\tv113 = 0x183F000 + 0x434;\n\tgoto L_0171;\nL_002F:\n\tv221 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(inApp, v110);\n\tv241 = System.Collections.ArrayList::get_Count(v221.childNodeList);\n\tv225 = v241 != 3;\n\tif (v225) goto L_006B;\n\tv237 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v221, 0);\n\tv257 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v237);\n\tgoto L_0058;\n\tv263 = *([v258 @ X8_v11+E0]);\n\tv264 = v263 == 0;\n\tv265 = ~v264;\n\tif (v265) goto L_0058;\n\tv270 = v258;\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v270, v235, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0058:\n\tv269 = LipingShare.LCLib.Asn1Processor.Asn1Util::BytesToLong(v257);\n\tv207 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v221, 2);\n\tv255 = v269 - 0x6A5;\n\tv272 = v255 < 0x12;\n\tv252 = ~v272;\n\tv251 = v255 - 0x12;\n\tv249 = v251 == 0;\n\tv273 = ~v252;\n\tv244 = v273 | v249;\n\tif (v244) goto L_0071;\nL_006B:\n\tv149 = inApp.childNodeList;\n\tv110 = v110 + 1;\n\tv256 = inApp.childNodeList == 0;\n\tv126 = ~v256;\n\tif (v126) goto L_0171;\n\tgoto L_018E;\nL_0071:\n\tv274 = v255 < 0x12;\n\tv190 = ~v274;\n\tv188 = v255 - 0x12;\n\tv184 = v188 == 0;\n\tv275 = ~v184;\n\tv174 = v190 & v275;\n\tif (v174) goto L_006B;\n\tv276 = v255 & 0xFFFFFFFF;\n\tv214 = *([v113 @ X25_v3 (System.Int32)+v276 @ X8_v13 (System.Int64)*4]) + v113;\n\t// 128 IndirectJump v214 @ X8_v15, v207 @ X0_v26 (LipingShare.LCLib.Asn1Processor.Asn1Node), v207 @ X0_v26 (LipingShare.LCLib.Asn1Processor.Asn1Node), 2, methodInfo @ X2 (Il2CppMethodInfo), v34 @ X3, v35 @ X4, v36 @ X5, v37 @ X6, v38 @ X7, v39 @ V0, v40 @ V1, v41 @ V2, v42 @ V3, v43 @ V4, v44 @ V5, v45 @ V6, v46 @ V7\n\tif (TEMP) goto L_018E;\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(X0, X1, X2);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(X0, X1);\n\tX8 = *([X24]);\n\tX22 = X0;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0095;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0095;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0095:\n\tX0 = X22;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Util::BytesToLong(X0, X1);\n\tif (TEMP) goto L_018E;\n\t*([X20+10]) = X0;\n\tgoto L_006B;\n\tX0 = 0;\n\tX0 = System.Text.Encoding::get_UTF8(X0);\n\tX23 = X0;\n\tif (TEMP) goto L_018E;\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(X0, X1, X2);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(X0, X1);\n\tX1 = X0;\n\tif (TEMP) goto L_018E;\n\tX8 = *([X23]);\n\tX0 = X23;\n\tX9 = *([X8+350]);\n\tX2 = *([X8+358]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_018E;\n\t*([X20+18]) = X0;\n\tgoto L_006B;\n\tX0 = 0;\n\tX0 = System.Text.Encoding::get_UTF8(X0);\n\tX23 = X0;\n\tif (TEMP) goto L_018E;\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(X0, X1, X2);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(X0, X1);\n\tX1 = X0;\n\tif (TEMP) goto L_018E;\n\tX8 = *([X23]);\n\tX0 = X23;\n\tX9 = *([X8+350]);\n\tX2 = *([X8+358]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_018E;\n\t*([X20+20]) = X0;\n\tgoto L_006B;\n\tX0 = *([X26]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00D3;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00D3;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00D3:\n\tX0 = X22;\n\tX0 = UnityEngine.Purchasing.Security.AppleReceiptParser::TryParseDateTimeNode(X0, X1);\n\tif (TEMP) goto L_018E;\n\t*([X20+30]) = X0;\n\tgoto L_006B;\n\tX0 = 0;\n\tX0 = System.Text.Encoding::get_UTF8(X0);\n\tX23 = X0;\n\tif (TEMP) goto L_018E;\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(X0, X1, X2);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(X0, X1);\n\tX1 = X0;\n\tif (TEMP) goto L_018E;\n\tX8 = *([X23]);\n\tX0 = X23;\n\tX9 = *([X8+350]);\n\tX2 = *([X8+358]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_018E;\n\t*([X20+28]) = X0;\n\tgoto L_006B;\n\tX0 = *([X26]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00FA;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00FA;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00FA:\n\tX0 = X22;\n\tX0 = UnityEngine.Purchasing.Security.AppleReceiptParser::TryParseDateTimeNode(X0, X1);\n\tif (TEMP) goto L_018E;\n\t*([X20+38]) = X0;\n\tgoto L_006B;\n\tif (TEMP) goto L_018E;\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(X0, X1, X2);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(X0, X1);\n\tX8 = *([X24]);\n\tX22 = X0;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0114;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0114;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0114:\n\tX0 = X22;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Util::BytesToLong(X0, X1);\n\tif (TEMP) goto L_018E;\n\t*([X20+54]) = X0;\n\tgoto L_006B;\n\tX0 = *([X26]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0124;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0124;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0124:\n\tX0 = X22;\n\tX0 = UnityEngine.Purchasing.Security.AppleReceiptParser::TryParseDateTimeNode(X0, X1);\n\tif (TEMP) goto L_018E;\n\t*([X20+40]) = X0;\n\tgoto L_006B;\n\tX0 = *([X26]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0134;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0134;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0134:\n\tX0 = X22;\n\tX0 = UnityEngine.Purchasing.Security.AppleReceiptParser::TryParseDateTimeNode(X0, X1);\n\tif (TEMP) goto L_018E;\n\t*([X20+48]) = X0;\n\tgoto L_006B;\n\tif (TEMP) goto L_018E;\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(X0, X1, X2);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(X0, X1);\n\tX8 = *([X24]);\n\tX22 = X0;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_014E;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_014E;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_014E:\n\tX0 = X22;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Util::BytesToLong(X0, X1);\n\tif (TEMP) goto L_018E;\n\t*([X20+50]) = X0;\n\tgoto L_006B;\n\tif (TEMP) goto L_018E;\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(X0, X1, X2);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(X0, X1);\n\tX8 = *([X24]);\n\tX22 = X0;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0168;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0168;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0168:\n\tX0 = X22;\n\tX0 = LipingShare.LCLib.Asn1Processor.Asn1Util::BytesToLong(X0, X1);\n\tif (TEMP) goto L_018E;\n\t*([X20+58]) = X0;\n\tgoto L_006B;\nL_0171:\n\tv155 = System.Collections.ArrayList::get_Count(v149);\n\tv166 = v155 > v110;\n\tif (v166) goto L_002F;\n\treturn v54;\n\tthrow System.NullReferenceException;\nL_018E:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 150 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private AppleInAppPurchaseReceipt ParseInAppReceipt(Asn1Node inApp)
		{
			//IL_0205: Expected O, but got I
			AppleInAppPurchaseReceipt result = new AppleInAppPurchaseReceipt();
			ArrayList childNodeList = inApp.childNodeList;
			int num = 25423872 + 1076;
			int num2 = 0;
			do
			{
				IL_020f:
				int count = childNodeList.Count;
				if (count > num2)
				{
					Asn1Node childNode = inApp.GetChildNode(num2);
					int count2 = childNode.childNodeList.Count;
					if (count2 == 3)
					{
						Asn1Node childNode2 = childNode.GetChildNode(0);
						byte[] data = childNode2.Data;
						long num3 = Asn1Util.BytesToLong(data);
						Asn1Node childNode3 = childNode.GetChildNode(2);
						long num4 = num3 - 1701;
						bool flag = num4 < 18;
						bool flag2 = !flag;
						long num5 = num4 - 18;
						bool flag3 = num5 == 0;
						bool flag4 = !flag2;
						if (flag4 || flag3)
						{
							bool flag5 = num4 < 18;
							bool flag6 = !flag5;
							long num6 = num4 - 18;
							bool flag7 = num6 == 0;
							bool flag8 = !flag7;
							if (!(flag6 && flag8))
							{
								long num7 = num4 & 0xFFFFFFFFL;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X25_v3 (System.Int32)+v276 @ X8_v13 (System.Int64)*4]");
								object obj = 0L + (long)num;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v214 @ X8_v15 (should have been resolved before IL gen)");
								goto IL_020f;
							}
						}
					}
					childNodeList = inApp.childNodeList;
					num2++;
					continue;
				}
				return result;
			}
			while (inApp.childNodeList != null);
			return (AppleInAppPurchaseReceipt)(object)new NullReferenceException();
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x15D2FD0", Offset = "0x15D2FD0", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EC3740]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029A1F]) = v38;\nL_0015:\n\tv41 = System.Text.Encoding::get_UTF8();\n\tv46 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(node, 0);\n\tv50 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v46);\n\tv82 = *([v41 @ X0_v3 (System.Text.Encoding)]);\n\tv85 = System.Text.Encoding::GetString(v41, v50);\n\tv88 = System.String::IsNullOrEmpty(v85);\n\tv94 = v88 == 0;\n\tif (v94) goto L_0040;\n\tgoto L_003C;\n\tv99 = *([v91 @ X8_v4 (Il2CppClass<System.DateTime>)+E0]);\n\tv100 = v99 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_003C;\n\tv120 = v91;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v120, v86, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv107 = System.DateTime;\nL_003C:\n\treturnVal2 = v108.MinValue;\n\tgoto L_0053;\nL_0040:\n\tgoto L_0049;\n\tv110 = *([v91 @ X8_v4 (Il2CppClass<System.DateTime>)+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_0049;\n\tv124 = v91;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v124, v86, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0049:\n\tv119 = System.DateTime::Parse(v85);\n\treturnVal2 = 0xE95E88(&v119 @ X0_v17 (System.DateTime), 0, *([v82 @ X8_v3 (Il2CppClass<System.Text.Encoding>)+358]), v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0053:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static DateTime TryParseDateTimeNode(Asn1Node node)
		{
			//IL_0036: Expected I, but got O
			Encoding uTF = Encoding.UTF8;
			Asn1Node childNode = node.GetChildNode(0);
			byte[] data = childNode.Data;
			IntPtr intPtr = (IntPtr)uTF;
			string text = uTF.GetString(data);
			if (!string.IsNullOrEmpty(text))
			{
				DateTime dateTime = DateTime.Parse(text);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E95E88 (inside System.DateTime::ParseExact +0x1C0)");
				DateTime result = default(DateTime);
				return result;
			}
			return DateTime.MinValue;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0xD6C5E4", Offset = "0xD6C5E4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv215 = a.Length;\n\tv44 = a.Length != b.Length;\n\tif (v44) goto L_FFFFFFFF;\n\tv59 = a.Length < 1;\n\tif (v59) goto L_FFFFFFFF;\n\tv113 = b.Length == 0;\n\tif (v113) goto L_0056;\nL_0029:\n\tv226 = v75 < v215;\n\tv102 = ~v226;\n\tif (v102) goto L_0056;\n\tv227 = b + v75;\n\tv108 = a + v75;\n\tv228 = v108 + 0x20;\n\tv69 = 0xE90634(v228, *([v227 @ X8_v7+20]), 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv229 = v69 & 1;\n\tv111 = v229 == 0;\n\tif (v111) goto L_FFFFFFFF;\n\tv215 = a.Length;\n\tv138 = v75 + 1;\n\tv120 = v138 >= a.Length;\n\tif (v120) goto L_FFFFFFFF;\n\tv231 = v138 < b.Length;\n\tv214 = ~v231;\n\tv206 = ~v214;\n\tif (v206) goto L_0029;\nL_0056:\n\tv217 = new System.IndexOutOfRangeException();\n\tthrow v217;\n\tgoto L_0063;\nL_0063:\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ArrayEquals<T>(T[] a, T[] b) where T : IEquatable<T>
		{
			//IL_0087: Expected O, but got I
			//IL_0095: Expected O, but got I
			//IL_00a4: Expected O, but got I
			int num = a.Length;
			if (a.Length != b.Length)
			{
				goto IL_0162;
			}
			if (a.Length >= 1)
			{
				if (b.Length != 0)
				{
					int num2 = 0;
					object obj4 = default(object);
					while (num2 < num)
					{
						object obj = (long)(IntPtr)b + (long)num2;
						object obj2 = (long)(IntPtr)a + (long)num2;
						object obj3 = (long)(IntPtr)obj2 + 32L;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E90634 (inside System.Buffer::memcpy1 +0x214)");
						if ((int)((long)(IntPtr)obj4 & 1L) == 0)
						{
							goto IL_0162;
						}
						num = a.Length;
						int num3 = num2 + 1;
						if (num3 < a.Length)
						{
							bool flag = num3 < b.Length;
							bool flag2 = !flag;
							bool flag3 = !flag2;
							num2 = num3;
							if (!flag3)
							{
								break;
							}
							continue;
						}
						goto IL_0170;
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_0170;
			IL_0162:
			return false;
			IL_0170:
			return true;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x15D30D8", Offset = "0x15D30D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AppleReceiptParser()
		{
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x15D30E0", Offset = "0x15D30E0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EFA9C8]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029A20]) = v35;\nL_0014:\n\tv39 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v39);\n\tv47._mostRecentReceiptData = v39;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static AppleReceiptParser()
		{
			Dictionary<string, object> mostRecentReceiptData = new Dictionary<string, object>();
			_mostRecentReceiptData = mostRecentReceiptData;
		}
	}
}
