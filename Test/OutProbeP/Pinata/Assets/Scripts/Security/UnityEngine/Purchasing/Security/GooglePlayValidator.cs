using System;
using System.Collections.Generic;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x200000E")]
	internal class GooglePlayValidator
	{
		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x10")]
		private RSAKey key;

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x15D393C", Offset = "0x15D393C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1F0EEB8]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, rsaKey, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029A27]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tv47 = new UnityEngine.Purchasing.Security.RSAKey();\n\tUnityEngine.Purchasing.Security.RSAKey::.ctor(v47, rsaKey);\n\tthis.key = v47;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GooglePlayValidator(byte[] rsaKey)
		{
			RSAKey rSAKey = new RSAKey(rsaKey);
			key = rSAKey;
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x15D404C", Offset = "0x15D404C", Length = "0x36C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = &v19 @ stack_-10_v2;\n\tgoto L_001B;\n\tv32 = *([1EED110]);\n\tv33 = *([v32 @ X8_v54]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, receipt, signature, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2029A28]) = v50;\nL_001B:\n\t*([v18 @ X29_v1-38]) = 0;\n\tv56 = 0;\n\tv58 = System.Text.Encoding::get_UTF8();\n\tv64 = System.Text.Encoding::GetBytes(v58, receipt);\n\tgoto L_003A;\n\tv153 = *([v68 @ X8_v19+E0]);\n\tv154 = v153 == 0;\n\tv155 = ~v154;\n\tif (v155) goto L_003A;\n\tv207 = v68;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v207, v61, v63, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_003A:\n\tv161 = System.Convert::FromBase64String(signature);\n\tv262 = UnityEngine.Purchasing.Security.RSAKey::Verify(this.key, v64, v161);\n\tv312 = v262 == 0;\n\tif (v312) goto L_0133;\n\tv139 = UnityEngine.Purchasing.MiniJson::JsonDecode(receipt);\n\tgoto L_FFFFFFFF;\n\tv100 = v100_asT == 0;\n\tif (v100) goto L_012C;\n\tv472 = &v19 @ stack_-10_v2 - 0x38;\n\tv476 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v139, \"orderId\", v472);\n\tv532 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v139, \"packageName\", &v92 @ stack_-58_v11 (System.Object));\n\tv588 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v139, \"productId\", &v90 @ stack_-60_v11 (System.Object));\n\tv595 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v139, \"purchaseToken\", &v88 @ stack_-68_v11 (System.Object));\n\tv661 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v139, \"purchaseTime\", &v86 @ stack_-70_v11 (System.Object));\n\tv667 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v139, \"purchaseState\", &v84 @ stack_-78_v11 (System.Object));\n\tv669 = 0xE93B78(&v56 @ stack_-80_v1, 0x7B2, 1, 1, 0, 0, 0, 1, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv224 = v224_asT == 0;\n\tif (v224) goto L_012F;\n\tv673 = \"il2cpp_vm_object_unbox\"(v86, System.Int64, 1, 1, 0, 0, 0, 1, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv248 = 0xE946C0(&v56 @ stack_-80_v1, 0, 1, 1, 0, 0, 0, 1, *([v673 @ X0_v54]), v41, v42, v43, v44, v45, v46, v47);\n\tv277 = v277_asT == 0;\n\tif (v277) goto L_012F;\n\tv678 = \"il2cpp_vm_object_unbox\"(v84, System.Int64, 1, 1, 0, 0, 0, 1, *([v673 @ X0_v54]), v41, v42, v43, v44, v45, v46, v47);\n\tv414 = *([v18 @ X29_v1-38]);\n\tv403 = new UnityEngine.Purchasing.Security.GooglePlayReceipt();\n\tv405 = v90 == 0;\n\tif (v405) goto L_00EB;\n\tv380 = *([v90 @ stack_-60_v11 (System.Object)]) != System.String;\n\tif (v380) goto L_013D;\nL_00EB:\n\tv460 = *([v18 @ X29_v1-38]) == 0;\n\tif (v460) goto L_00F9;\n\tv437 = *([v414 @ X22_v12 (System.String)]) != System.String;\n\tif (v437) goto L_013F;\nL_00F9:\n\tv517 = v92 == 0;\n\tif (v517) goto L_0107;\n\tv494 = *([v92 @ stack_-58_v11 (System.Object)]) != System.String;\n\tif (v494) goto L_0141;\nL_0107:\n\tv573 = v88 == 0;\n\tif (v573) goto L_0117;\n\tv550 = *([v88 @ stack_-68_v11 (System.Object)]) != System.String;\n\tif (v550) goto L_0143;\nL_0117:\n\tSystem.Object::.ctor(v403);\n\tv403.<productID>k__BackingField = v90;\n\tv403.<transactionID>k__BackingField = *([v18 @ X29_v1-38]);\n\tv403.<packageName>k__BackingField = v92;\n\tv403.<purchaseToken>k__BackingField = v88;\n\tv403.<purchaseDate>k__BackingField = v248;\n\tv403.<purchaseState>k__BackingField = *([v678 @ X0_v58]);\n\treturn v403;\n\tthrow System.NullReferenceException;\nL_012C:\n\tthrow System.InvalidCastException;\n\tv259 = new System.NullReferenceException();\nL_012F:\n\tthrow System.InvalidCastException;\nL_0133:\n\tv348 = new UnityEngine.Purchasing.Security.InvalidSignatureException();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v348);\n\tthrow v348;\nL_013D:\n\tthrow System.InvalidCastException;\nL_013F:\n\tthrow System.InvalidCastException;\nL_0141:\n\tthrow System.InvalidCastException;\nL_0143:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 246 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe GooglePlayReceipt Validate(string receipt, string signature)
		{
			//IL_03d0: Expected O, but got I4
			//IL_016d: Expected I8, but got O
			//IL_01bb: Expected I8, but got O
			//IL_01f8: Expected O, but got I
			//IL_0348: Expected O, but got I
			//IL_037c: Expected I4, but got O
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			object obj3 = 0;
			Encoding uTF = Encoding.UTF8;
			byte[] bytes = uTF.GetBytes(receipt);
			byte[] signature2 = Convert.FromBase64String(signature);
			if (key.Verify(bytes, signature2))
			{
				object obj4 = MiniJson.JsonDecode(receipt);
				Dictionary<string, object> dictionary = obj4 as Dictionary<string, object>;
				if (dictionary != null)
				{
					bool flag = ((Dictionary<string, object>)obj4).TryGetValue("orderId", out *(object*)((long)(IntPtr)obj2 - 56L));
					bool flag2 = ((Dictionary<string, object>)obj4).TryGetValue("packageName", out object value);
					bool flag3 = ((Dictionary<string, object>)obj4).TryGetValue("productId", out object value2);
					bool flag4 = ((Dictionary<string, object>)obj4).TryGetValue("purchaseToken", out object value3);
					bool flag5 = ((Dictionary<string, object>)obj4).TryGetValue("purchaseTime", out object value4);
					bool flag6 = ((Dictionary<string, object>)obj4).TryGetValue("purchaseState", out object value5);
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E93B78 (inside System.DateTime::TimeToTicks +0xF0)");
					long num = (long)((value4 is long) ? value4 : null);
					if (num != 0)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E946C0 (inside System.DateTime::TimeToTicks +0xC38)");
						long num2 = (long)((value5 is long) ? value5 : null);
						if (num2 != 0)
						{
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-38]");
							string text = (string)0;
							GooglePlayReceipt googlePlayReceipt = null;
							if (value2 == null || (object)value2.GetType() == typeof(string))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-38]");
								if ((IntPtr)0 == (IntPtr)0 || (object)text.GetType() == typeof(string))
								{
									if (value == null || (object)value.GetType() == typeof(string))
									{
										if (value3 == null || (object)value3.GetType() == typeof(string))
										{
											googlePlayReceipt.productID = (string)value2;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-38]");
											googlePlayReceipt.transactionID = (string)0;
											googlePlayReceipt.packageName = (string)value;
											googlePlayReceipt._003CpurchaseToken_003Ek__BackingField = (string)value3;
											DateTime _003CpurchaseDate_003Ek__BackingField = default(DateTime);
											googlePlayReceipt.purchaseDate = _003CpurchaseDate_003Ek__BackingField;
											object obj5 = default(object);
											googlePlayReceipt._003CpurchaseState_003Ek__BackingField = (GooglePurchaseState)obj5;
											return googlePlayReceipt;
										}
										return (GooglePlayReceipt)(object)new InvalidCastException();
									}
									throw new InvalidCastException();
								}
								throw new InvalidCastException();
							}
							throw new InvalidCastException();
						}
					}
					throw new InvalidCastException();
				}
				throw new InvalidCastException();
			}
			InvalidSignatureException ex = (InvalidSignatureException)new IAPSecurityException();
			throw ex;
		}
	}
}
