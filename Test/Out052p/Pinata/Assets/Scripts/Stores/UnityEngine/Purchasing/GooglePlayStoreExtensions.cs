using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000027")]
	internal class GooglePlayStoreExtensions : AndroidJavaProxy, IGooglePlayStoreExtensions, IStoreExtension, IGooglePlayConfiguration, IStoreConfiguration
	{
		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0x20")]
		private AndroidJavaObject m_Java;

		[Token(Token = "0x600009A")]
		[Address(RVA = "0xC61A54", Offset = "0xC61A54", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA68F8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202333B]) = v38;\nL_0019:\n\tgoto L_0029;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0029;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0029:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.unity.purchasing.googleplay.GooglePlayPurchasing\");\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GooglePlayStoreExtensions()
			: base("com.unity.purchasing.googleplay.GooglePlayPurchasing")
		{
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0xC61AC8", Offset = "0xC61AC8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Java = java;\n\treturn;\n")]
		public void SetAndroidJavaObject(AndroidJavaObject java)
		{
			m_Java = java;
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0xC61AD0", Offset = "0xC61AD0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetPublicKey(string key)
		{
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0xC61AD4", Offset = "0xC61AD4", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EAA460]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, oldSku, newSku, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202333C]) = v44;\nL_001C:\n\t// 28 NewArr v50 @ X0_v3 (System.Object[]), typeof(System.Object[]), 2\n\tv53 = oldSku == 0;\n\tif (v53) goto L_0028;\n\t// 37 IsInst v95 @ X0_v21, typeof(System.Object), oldSku @ X1 (System.String)\nL_0028:\n\tv129 = v50.Length;\n\tv102 = v50.Length == 0;\n\tif (v102) goto L_0053;\n\tv50[0] = oldSku;\n\tv132 = newSku == 0;\n\tif (v132) goto L_0035;\n\t// 49 IsInst v151 @ X0_v19, typeof(System.Object), newSku @ X2 (System.String)\n\tv129 = v50.Length;\nL_0035:\n\tv159 = v129 < 1;\n\tv120 = ~v159;\n\tv118 = v129 - 1;\n\tv114 = v118 == 0;\n\tv160 = ~v120;\n\tv104 = v160 | v114;\n\tif (v104) goto L_0053;\n\tv50[1] = newSku;\n\tUnityEngine.AndroidJavaObject::Call(this.m_Java, \"UpgradeDowngradeSubscription\", v50);\n\treturn;\nL_0053:\n\tv147 = new System.IndexOutOfRangeException();\n\tgoto L_0058;\n\tv156 = new System.ArrayTypeMismatchException();\nL_0058:\n\tthrow v194;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpgradeDowngradeSubscription(string oldSku, string newSku)
		{
			//IL_003e: Expected O, but got I4
			//IL_0128: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			object[] array = new object[2];
			if (oldSku != null)
			{
				object obj = oldSku as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = oldSku;
				if (newSku != null)
				{
					object obj3 = newSku as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = newSku;
					m_Java.Call("UpgradeDowngradeSubscription", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0xC61BD0", Offset = "0xC61BD0", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EDB790]);\n\tv23 = *([v22 @ X8_v31]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202333D]) = v42;\nL_0018:\n\tv46 = 0;\n\tv55 = UnityEngine.AndroidJavaObject::Get(this.m_Java, \"productJSON\");\n\tv122 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v122);\n\tv105 = UnityEngine.Purchasing.MiniJson::JsonDecode(v55);\n\tgoto L_FFFFFFFF;\n\tv129 = v129_asT == 0;\n\tif (v129) goto L_0087;\n\tv210 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::GetEnumerator(v105);\nL_0060:\n\tv305 = System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>::MoveNext(&v46 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>));\n\tv279 = v305 == 0;\n\tif (v279) goto L_007F;\n\tv300 = v310 == 0;\n\tif (v300) goto L_0079;\n\tv324 = *([v310 @ stack_-40 (System.String)]) != System.String;\n\tif (v324) goto L_0085;\nL_0079:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v122, 0, v310);\n\tgoto L_0060;\nL_007F:\n\tv278 = System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>::Dispose(&v46 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>));\n\tgoto L_00A8;\n\tthrow System.NullReferenceException;\nL_0085:\n\tv104 = new System.InvalidCastException();\n\tv117 = new System.NullReferenceException();\nL_0087:\n\tv167 = new System.InvalidCastException();\n\tgoto L_0093;\n\tgoto L_0093;\nL_0093:\n\tv180 = v156 != 1;\n\tif (v180) goto L_00A9;\n\tv181 = UnityEngine.AndroidJavaObject::Get(v167, v156);\n\tv187 = UnityEngine.AndroidJavaObject::Get(v181, v156);\n\tv191 = System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>::Dispose(&v46 @ stack_-58_v1 (System.Collections.Generic.Dictionary`2<System.String, System.Object>+Enumerator<System.String, System.Object>));\n\tv211 = *([v181 @ X0_v11 (System.String)]) == 0;\n\tv193 = ~v211;\n\tif (v193) goto L_00AD;\nL_00A8:\n\treturn v280;\nL_00A9:\n\tv182 = UnityEngine.AndroidJavaObject::Get(v167, v156);\nL_00AD:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Dictionary<string, string> GetProductJSONDictionary()
		{
			//IL_0049: Expected I, but got O
			//IL_0081: Expected I, but got O
			//IL_00ad: Expected I, but got O
			//IL_0207: Expected O, but got I
			//IL_01aa: Expected O, but got I
			//IL_01bb: Expected O, but got I
			//IL_0102: Expected I, but got O
			Dictionary<string, object>.Enumerator enumerator = default(Dictionary<string, object>.Enumerator);
			string json = m_Java.Get<string>("productJSON");
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			object obj = MiniJson.JsonDecode(json);
			IntPtr intPtr = (IntPtr)typeof(Dictionary<string, object>);
			Dictionary<string, string> dictionary2 = dictionary;
			Dictionary<string, object> dictionary3 = obj as Dictionary<string, object>;
			bool flag = dictionary3 == null;
			intPtr = (IntPtr)typeof(Dictionary<string, object>);
			dictionary2 = dictionary;
			if (flag)
			{
				goto IL_016f;
			}
			object enumerator2 = ((Dictionary<string, object>)obj).GetEnumerator();
			IntPtr intPtr2;
			string text = default(string);
			IntPtr intPtr3;
			for (intPtr2 = (IntPtr)enumerator; enumerator.MoveNext(); dictionary.Add(null, text), intPtr2 = intPtr3)
			{
				bool flag2 = text == null;
				intPtr3 = intPtr2;
				if (flag2)
				{
					continue;
				}
				bool flag3 = (object)text.GetType() != typeof(string);
				intPtr3 = (IntPtr)typeof(string);
				if (!flag3)
				{
					continue;
				}
				goto IL_0142;
			}
			enumerator.Dispose();
			dictionary2 = dictionary;
			goto IL_01f5;
			IL_016f:
			InvalidCastException ex = new InvalidCastException();
			if (intPtr == (IntPtr)1)
			{
				string text2 = ((AndroidJavaObject)(object)ex).Get<string>((string)(long)intPtr);
				string text3 = ((AndroidJavaObject)(object)text2).Get<string>((string)(long)intPtr);
				enumerator.Dispose();
				if (text2 == null)
				{
					goto IL_01f5;
				}
			}
			else
			{
				string text4 = ((AndroidJavaObject)(object)ex).Get<string>((string)(long)intPtr);
			}
			return (Dictionary<string, string>)(object)new TypeLoadException();
			IL_01f5:
			return dictionary2;
			IL_0142:
			InvalidCastException ex2 = new InvalidCastException();
			intPtr = intPtr2;
			dictionary2 = dictionary;
			NullReferenceException ex3 = new NullReferenceException();
			goto IL_016f;
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0xC61DAC", Offset = "0xC61DAC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EB3EB0]);\n\tv25 = *([v24 @ X8_v18]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, callback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202333E]) = v43;\nL_001B:\n\t// 27 NewArr v49 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv55 = new UnityEngine.Purchasing.GooglePlayStoreCallback();\n\tUnityEngine.Purchasing.GooglePlayStoreCallback::.ctor(v55, callback);\n\tv59 = v55 == 0;\n\tif (v59) goto L_0030;\n\t// 44 IsInst v73 @ X0_v16, typeof(System.Object), v55 @ X0_v5 (UnityEngine.Purchasing.GooglePlayStoreCallback)\nL_0030:\n\tv77 = v49.Length == 0;\n\tif (v77) goto L_0046;\n\tv49[0] = v55;\n\tUnityEngine.AndroidJavaObject::Call(this.m_Java, \"RestoreTransactions\", v49);\n\treturn;\n\tv69 = new System.NullReferenceException();\nL_0046:\n\tv82 = new System.IndexOutOfRangeException();\n\tgoto L_004B;\n\tv83 = new System.ArrayTypeMismatchException();\nL_004B:\n\tthrow v97;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestoreTransactions(Action<bool> callback)
		{
			object[] array = new object[1];
			GooglePlayStoreCallback googlePlayStoreCallback = new GooglePlayStoreCallback(callback);
			if (googlePlayStoreCallback != null)
			{
				object obj = googlePlayStoreCallback as object;
			}
			if (array.Length != 0)
			{
				array[0] = googlePlayStoreCallback;
				m_Java.Call("RestoreTransactions", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0xC61E98", Offset = "0xC61E98", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EFA450]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, productId, transactionId, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202333F]) = v44;\nL_001C:\n\t// 28 NewArr v50 @ X0_v3 (System.Object[]), typeof(System.Object[]), 2\n\tv53 = productId == 0;\n\tif (v53) goto L_0028;\n\t// 37 IsInst v95 @ X0_v21, typeof(System.Object), productId @ X1 (System.String)\nL_0028:\n\tv129 = v50.Length;\n\tv102 = v50.Length == 0;\n\tif (v102) goto L_0053;\n\tv50[0] = productId;\n\tv132 = transactionId == 0;\n\tif (v132) goto L_0035;\n\t// 49 IsInst v151 @ X0_v19, typeof(System.Object), transactionId @ X2 (System.String)\n\tv129 = v50.Length;\nL_0035:\n\tv159 = v129 < 1;\n\tv120 = ~v159;\n\tv118 = v129 - 1;\n\tv114 = v118 == 0;\n\tv160 = ~v120;\n\tv104 = v160 | v114;\n\tif (v104) goto L_0053;\n\tv50[1] = transactionId;\n\tUnityEngine.AndroidJavaObject::Call(this.m_Java, \"FinishAdditionalTransaction\", v50);\n\treturn;\nL_0053:\n\tv147 = new System.IndexOutOfRangeException();\n\tgoto L_0058;\n\tv156 = new System.ArrayTypeMismatchException();\nL_0058:\n\tthrow v194;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FinishAdditionalTransaction(string productId, string transactionId)
		{
			//IL_003e: Expected O, but got I4
			//IL_0128: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			object[] array = new object[2];
			if (productId != null)
			{
				object obj = productId as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = productId;
				if (transactionId != null)
				{
					object obj3 = transactionId as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = transactionId;
					m_Java.Call("FinishAdditionalTransaction", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
