using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity
{
	[Token(Token = "0x2000011")]
	internal abstract class FacebookBase : IFacebookImplementation, IFacebook, IFacebookResultHandler
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000012")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000033")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000034")]
			public static Func<string, bool> _003C_003E9__41_0;

			[Token(Token = "0x6000097")]
			[Address(RVA = "0xD2D9F0", Offset = "0xD2D9F0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1ED6F38]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023C1C]) = v37;\nL_0015:\n\tv41 = new Facebook.Unity.FacebookBase+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000098")]
			[Address(RVA = "0xD2DA54", Offset = "0xD2DA54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CValidateAppRequestArgs_003Eb__41_0(string toWhom)
			{
				return string.IsNullOrEmpty(toWhom);
			}
		}

		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x10")]
		internal InitDelegate onInitCompleteDelegate;

		[CompilerGenerated]
		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x18")]
		private bool _003CInitialized_003Ek__BackingField;

		[Token(Token = "0x17000023")]
		public abstract bool LimitEventUsage
		{
			[Token(Token = "0x6000075")]
			get;
			[Token(Token = "0x6000076")]
			set;
		}

		[Token(Token = "0x17000024")]
		public abstract string SDKName
		{
			[Token(Token = "0x6000077")]
			get;
		}

		[Token(Token = "0x17000025")]
		public abstract string SDKVersion
		{
			[Token(Token = "0x6000078")]
			get;
		}

		[Token(Token = "0x17000026")]
		public virtual string SDKUserAgent
		{
			[Token(Token = "0x6000079")]
			[Address(RVA = "0xD1E2AC", Offset = "0xD1E2AC", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = Facebook.Unity.FacebookBase::get_SDKName(this);\n\tv35 = Facebook.Unity.FacebookBase::get_SDKVersion(this);\n\treturnVal1 = Facebook.Unity.Utilities::GetUserAgent(v15, v35);\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string sDKName = SDKName;
				string sDKVersion = SDKVersion;
				return Utilities.GetUserAgent(sDKName, sDKVersion);
			}
		}

		[Token(Token = "0x17000027")]
		public bool LoggedIn
		{
			[Token(Token = "0x600007A")]
			[Address(RVA = "0xD2CC28", Offset = "0xD2CC28", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EDA540]);\n\tv15 = *([v14 @ X8_v17]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023C15]) = v35;\nL_0015:\n\tgoto L_0020;\n\tv41 = *([1F0D7D0]);\n\tv42 = *([v41 @ X8_v14]);\n\tv43 = \"il2cpp_codegen_initialize_method\"(v42, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = 0 | 1;\n\t*([2021D32]) = v46;\nL_0020:\n\tv51 = v50.<CurrentAccessToken>k__BackingField;\n\tv52 = v50.<CurrentAccessToken>k__BackingField == 0;\n\tif (v52) goto L_0040;\n\tgoto L_0031;\n\tv64 = *([v56 @ X0_v4+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0031;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0031:\n\tv72 = System.DateTime::get_UtcNow();\n\treturnVal2 = System.DateTime::op_GreaterThan(v51.<ExpirationTime>k__BackingField, v72);\n\treturn returnVal2;\nL_0040:\n\treturn 0;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				AccessToken _003CCurrentAccessToken_003Ek__BackingField = AccessToken.CurrentAccessToken;
				if (AccessToken.CurrentAccessToken != null)
				{
					DateTime utcNow = DateTime.UtcNow;
					return _003CCurrentAccessToken_003Ek__BackingField.ExpirationTime > utcNow;
				}
				return false;
			}
		}

		[Token(Token = "0x17000028")]
		public bool Initialized
		{
			[CompilerGenerated]
			[Token(Token = "0x600007B")]
			[Address(RVA = "0xD2CCE8", Offset = "0xD2CCE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Initialized>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Initialized;
			}
			[CompilerGenerated]
			[Token(Token = "0x600007C")]
			[Address(RVA = "0xD2CCF0", Offset = "0xD2CCF0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Initialized>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CInitialized_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000029")]
		[field: Token(Token = "0x4000032")]
		[field: FieldOffset(Offset = "0x20")]
		protected CallbackManager CallbackManager
		{
			[Token(Token = "0x600007D")]
			[Address(RVA = "0xD2CCFC", Offset = "0xD2CCFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CallbackManager>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600007E")]
			[Address(RVA = "0xD2CD04", Offset = "0xD2CD04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CallbackManager>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0xD1DD7C", Offset = "0xD1DD7C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<CallbackManager>k__BackingField = callbackManager;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected FacebookBase(CallbackManager callbackManager)
		{
			CallbackManager = callbackManager;
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0xD2CD0C", Offset = "0xD2CD0C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.onInitCompleteDelegate = onInitComplete;\n\treturn;\n")]
		public virtual void Init(InitDelegate onInitComplete)
		{
			onInitCompleteDelegate = onInitComplete;
		}

		[Token(Token = "0x6000080")]
		public abstract void LogInWithPublishPermissions(IEnumerable<string> scope, FacebookDelegate<ILoginResult> callback);

		[Token(Token = "0x6000081")]
		public abstract void LogInWithReadPermissions(IEnumerable<string> scope, FacebookDelegate<ILoginResult> callback);

		[Token(Token = "0x6000082")]
		[Address(RVA = "0xD1ED20", Offset = "0xD1ED20", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ED9370]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2023CAB]) = v34;\nL_0014:\n\tv38.<CurrentAccessToken>k__BackingField = 0;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void LogOut()
		{
			AccessToken.CurrentAccessToken = null;
		}

		[Token(Token = "0x6000083")]
		public abstract void AppRequest(string message, OGActionType? actionType, string objectId, IEnumerable<string> to, IEnumerable<object> filters, IEnumerable<string> excludeIds, int? maxRecipients, string data, string title, FacebookDelegate<IAppRequestResult> callback);

		[Token(Token = "0x6000084")]
		public abstract void ShareLink(Uri contentURL, string contentTitle, string contentDescription, Uri photoURL, FacebookDelegate<IShareResult> callback);

		[Token(Token = "0x6000085")]
		public abstract void FeedShare(string toId, Uri link, string linkName, string linkCaption, string linkDescription, Uri picture, string mediaSource, FacebookDelegate<IShareResult> callback);

		[Token(Token = "0x6000086")]
		[Address(RVA = "0xD2CD14", Offset = "0xD2CD14", Length = "0x2CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EF64B8]);\n\tv35 = *([v34 @ X8_v44]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, query, method, formData, callback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 0 | 1;\n\t*([2023C16]) = v51;\nL_001B:\n\tv52 = v82 == 0;\n\tif (v52) goto L_0027;\n\tv54 = Facebook.Unity.FacebookBase::CopyByValue(v48, v82);\n\tv60 = v54 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0030;\n\tgoto L_0110;\nL_0027:\n\tv58 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v58);\nL_0030:\n\tv73 = *([v70 @ X21_v3]);\n\tv80 = *([v73 @ X8_v5+126]) == 0;\n\tif (v80) goto L_0056;\n\tv212 = *([v73 @ X8_v5+B0]) + 8;\nL_0041:\n\tv217 = *([v212 @ X11_v19-8]) == System.Collections.Generic.IDictionary`2<System.String, System.String>;\n\tif (v217) goto L_0059;\n\tv211 = v211 + 1;\n\tv286 = v211 < *([v73 @ X8_v5+126]);\n\tv193 = ~v286;\n\tv212 = v212 + 0x10;\n\tv177 = ~v193;\n\tif (v177) goto L_0041;\nL_0056:\n\tv293 = 0x8909C4(v70, System.Collections.Generic.IDictionary`2<System.String, System.String>, 3, v82, callback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_005E;\nL_0059:\n\tv288 = *([v212 @ X11_v19]) + 3;\n\tv289 = v288 << 4;\n\tv290 = v73 + v289;\n\tv293 = v290 + 0x130;\nL_005E:\n\t;\n\t*([v293 @ X0_v6])(v318, v70, \"access_token\", *([v293 @ X0_v6+8]), v82, callback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv297 = v318 == 0;\n\tv298 = ~v297;\n\tif (v298) goto L_00CB;\n\tv318 = System.String::Contains(query, \"access_token=\");\n\tv331 = v318 == 0;\n\tv323 = ~v331;\n\tif (v323) goto L_00CB;\n\tgoto L_007E;\n\tv343 = *([v334 @ X0_v19 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv344 = v343 == 0;\n\tv345 = ~v344;\n\tif (v345) goto L_007E;\n\tv347 = \"il2cpp_codegen_runtime_class_init\"(v334, v150, v94, formData, callback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_007E:\n\tv350 = Facebook.Unity.FB::get_IsLoggedIn();\n\tv382 = v350 == 0;\n\tif (v382) goto L_009B;\n\tgoto L_0096;\n\tv420 = *([1F0D7D0]);\n\tv421 = *([v420 @ X8_v34]);\n\tv422 = \"il2cpp_codegen_initialize_method\"(v421, v150, v94, formData, callback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv424 = 0 | 1;\n\t*([2021D32]) = v424;\nL_0096:\n\tgoto L_009B;\nL_009B:\n\tv435 = *([v70 @ X21_v3]);\n\tv322 = *([v435 @ X8_v19+126]) == 0;\n\tif (v322) goto L_00BE;\n\tv479 = *([v435 @ X8_v19+B0]) + 8;\nL_00A9:\n\tv484 = *([v479 @ X11_v14-8]) == System.Collections.Generic.IDictionary`2<System.String, System.String>;\n\tif (v484) goto L_00C1;\n\tv478 = v478 + 1;\n\tv489 = v478 < *([v435 @ X8_v19+126]);\n\tv460 = ~v489;\n\tv479 = v479 + 0x10;\n\tv444 = ~v460;\n\tif (v444) goto L_00A9;\nL_00BE:\n\tv496 = 0x8909C4(v70, System.Collections.Generic.IDictionary`2<System.String, System.String>, 1, v82, callback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00CA;\nL_00C1:\n\tv491 = *([v479 @ X11_v14]) + 1;\n\tv492 = v491 << 4;\n\tv493 = v435 + v492;\n\tv496 = v493 + 0x130;\nL_00CA:\n\t*([v496 @ X0_v23])(v318, v70, \"access_token\", v429.Empty, *([v496 @ X0_v23+8]), callback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00CB:\n\tv327 = Facebook.Unity.FBUnityUtility::get_AsyncRequestStringWrapper();\n\tv153 = Facebook.Unity.FacebookBase::GetGraphUrl(v327, query);\n\tv339 = *([v327 @ X0_v10 (Facebook.Unity.IAsyncRequestStringWrapper)]);\n\tv271 = *([v339 @ X8_v9 (Il2CppClass<Facebook.Unity.IAsyncRequestStringWrapper>)+126]) == 0;\n\tif (v271) goto L_00F6;\n\tv394 = *([v339 @ X8_v9 (Il2CppClass<Facebook.Unity.IAsyncRequestStringWrapper>)+B0]) + 8;\nL_00E1:\n\tv399 = *([v394 @ X11_v8-8]) == Facebook.Unity.IAsyncRequestStringWrapper;\n\tif (v399) goto L_00F9;\n\tv393 = v393 + 1;\n\tv411 = v393 < *([v339 @ X8_v9 (Il2CppClass<Facebook.Unity.IAsyncRequestStringWrapper>)+126]);\n\tv373 = ~v411;\n\tv394 = v394 + 0x10;\n\tv357 = ~v373;\n\tif (v357) goto L_00E1;\nL_00F6:\n\tv418 = 0x8909C4(v327, Facebook.Unity.IAsyncRequestStringWrapper, 1, *([v496 @ X0_v23+8]), callback, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00FD;\nL_00F9:\n\tv413 = *([v394 @ X11_v8]) + 1;\n\tv414 = v413 << 4;\n\tv415 = v339 + v414;\n\tv418 = v415 + 0x130;\nL_00FD:\n\tv229 = *([v418 @ X0_v12]);\n\tv227 = *([v418 @ X0_v12+8]);\n\t// 270 IndirectJump v229 @ X6_v1, v327 @ X0_v10 (Facebook.Unity.IAsyncRequestStringWrapper), v327 @ X0_v10 (Facebook.Unity.IAsyncRequestStringWrapper), v153 @ X0_v11 (System.Uri), method @ X2 (Facebook.Unity.HttpMethod), v70 @ X21_v3, callback @ X4 (Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IGraphResult>), v227 @ X5_v1, v229 @ X6_v1, v39 @ X7, v40 @ V0, v41 @ V1, v42 @ V2, v43 @ V3, v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\nL_0110:\n\tthrow System.NullReferenceException;\n// 173 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void API(string query, HttpMethod method, IDictionary<string, string> formData, FacebookDelegate<IGraphResult> callback)
		{
			//IL_00a7: Expected O, but got I
			//IL_029b: Expected I, but got O
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Expected O, but got Unknown
			//IL_0146: Expected O, but got I
			//IL_0155: Expected O, but got I
			//IL_00f3: Expected O, but got I
			//IL_04d1: Expected O, but got I
			//IL_02d6: Expected O, but got I
			//IL_0353: Unknown result type (might be due to invalid IL or missing references)
			//IL_0358: Expected O, but got Unknown
			//IL_0375: Expected O, but got I
			//IL_0384: Expected O, but got I
			//IL_0322: Expected O, but got I
			//IL_01e0: Expected O, but got I
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Expected O, but got Unknown
			//IL_027f: Expected O, but got I
			//IL_028e: Expected O, but got I
			//IL_022c: Expected O, but got I
			IDictionary<string, string> dictionary = default(IDictionary<string, string>);
			object obj;
			if (dictionary != null)
			{
				IDictionary<string, string> dictionary2 = CopyByValue(dictionary);
				bool flag = dictionary2 == null;
				bool flag2 = !flag;
				obj = dictionary2;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
				obj = dictionary3;
			}
			object obj2 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X8_v5+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_010c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X8_v5+B0]");
			object obj3 = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ X11_v19-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, string>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X8_v5+126]");
				bool flag3 = (long)num2 < 0L;
				bool flag4 = !flag3;
				obj3 = (long)(IntPtr)obj3 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_010c;
			}
			object obj4 = obj3 + 3;
			int num3 = (int)((long)(IntPtr)obj4 << 4);
			object obj5 = (long)(IntPtr)obj2 + (long)num3;
			object obj6 = (long)(IntPtr)obj5 + 304L;
			goto IL_03d6;
			IL_04b9:
			object obj8 = default(object);
			object obj7 = obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ X0_v12+8]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v229 @ X6_v1 (should have been resolved before IL gen)");
			return;
			IL_03d6:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v293 @ X0_v6] (should have been resolved before IL gen)");
			bool flag5 = default(bool);
			if (flag5 || query.Contains("access_token="))
			{
				goto IL_0409;
			}
			if (FB.IsLoggedIn)
			{
			}
			object obj10 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ X8_v19+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0245;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ X8_v19+B0]");
			object obj11 = 0L + 8L;
			int num4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ X11_v14-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, string>))
				{
					break;
				}
				num4++;
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ X8_v19+126]");
				bool flag6 = (long)num5 < 0L;
				bool flag7 = !flag6;
				obj11 = (long)(IntPtr)obj11 + 16L;
				if (!flag7)
				{
					continue;
				}
				goto IL_0245;
			}
			object obj12 = obj11 + 1;
			int num6 = (int)((long)(IntPtr)obj12 << 4);
			object obj13 = (long)(IntPtr)obj10 + (long)num6;
			object obj14 = (long)(IntPtr)obj13 + 304L;
			goto IL_047f;
			IL_010c:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_03d6;
			IL_0245:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_047f;
			IL_047f:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v496 @ X0_v23] (should have been resolved before IL gen)");
			goto IL_0409;
			IL_0409:
			IAsyncRequestStringWrapper asyncRequestStringWrapper = FBUnityUtility.AsyncRequestStringWrapper;
			Uri graphUrl = ((FacebookBase)asyncRequestStringWrapper).GetGraphUrl(query);
			IntPtr intPtr = (IntPtr)asyncRequestStringWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X8_v9 (Il2CppClass<Facebook.Unity.IAsyncRequestStringWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_033b;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X8_v9 (Il2CppClass<Facebook.Unity.IAsyncRequestStringWrapper>)+B0]");
			object obj15 = 0L + 8L;
			int num7 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ X11_v8-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IAsyncRequestStringWrapper))
				{
					break;
				}
				num7++;
				int num8 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X8_v9 (Il2CppClass<Facebook.Unity.IAsyncRequestStringWrapper>)+126]");
				bool flag8 = (long)num8 < 0L;
				bool flag9 = !flag8;
				obj15 = (long)(IntPtr)obj15 + 16L;
				if (!flag9)
				{
					continue;
				}
				goto IL_033b;
			}
			object obj16 = obj15 + 1;
			int num9 = (int)((long)(IntPtr)obj16 << 4);
			object obj17 = (long)intPtr + (long)num9;
			obj8 = (long)(IntPtr)obj17 + 304L;
			goto IL_04b9;
			IL_033b:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_04b9;
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0xD2D414", Offset = "0xD2D414", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EE9D10]);\n\tv31 = *([v30 @ X8_v30]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, query, method, formData, callback, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([2023C17]) = v47;\nL_0019:\n\tv48 = formData == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_0027;\n\tv53 = new UnityEngine.WWWForm();\n\tUnityEngine.WWWForm::.ctor(v53);\nL_0027:\n\tgoto L_0033;\n\tv65 = *([1F0D7D0]);\n\tv66 = *([v65 @ X8_v25]);\n\tv67 = \"il2cpp_codegen_initialize_method\"(v66, v54, method, formData, callback, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv70 = 0 | 1;\n\t*([2021D32]) = v70;\nL_0033:\n\tv76 = v74.<CurrentAccessToken>k__BackingField == 0;\n\tif (v76) goto L_0046;\n\tv78 = v57 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0046;\n\tgoto L_0089;\nL_0046:\n\tUnityEngine.WWWForm::AddField(v57, \"access_token\", v86.Empty);\n\tv108 = Facebook.Unity.FBUnityUtility::get_AsyncRequestStringWrapper();\n\tv98 = Facebook.Unity.FacebookBase::GetGraphUrl(v108, query);\n\tgoto L_0087;\n\tv188 = *([v184 @ X8_v15+B0]);\n\tv189 = 0;\n\tv190 = v188 + 8;\n\tv192 = *([v228 @ X11_v5-8]);\n\tv234 = v192 == v187;\n\tif (v234) goto L_0074;\n\tv214 = v229 + 1;\n\tv239 = v214 < v186;\n\tv210 = ~v239;\n\tv212 = v228 + 0x10;\n\tv194 = ~v210;\n\tif (v194) goto L_FFFFFFFF;\n\tv215 = v105;\n\tv216 = 0;\n\tv217 = 0x8909C4(v215, v187, v216, v91, callback, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0087;\nL_0074:\n\tv240 = *([v228 @ X11_v5]);\n\tv241 = v240 << 4;\n\tv242 = v184 + v241;\n\tv243 = v242 + 0x130;\nL_0087:\n\tFacebook.Unity.IAsyncRequestStringWrapper::Request(v108, v98, method, v57, callback);\nL_0089:\n\tthrow System.NullReferenceException;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void API(string query, HttpMethod method, WWWForm formData, FacebookDelegate<IGraphResult> callback)
		{
			bool flag = formData == null;
			bool flag2 = !flag;
			WWWForm wWWForm = formData;
			if (!flag2)
			{
				WWWForm wWWForm2 = new WWWForm();
				wWWForm = wWWForm2;
			}
			if (AccessToken.CurrentAccessToken == null || wWWForm != null)
			{
				wWWForm.AddField("access_token", string.Empty);
				IAsyncRequestStringWrapper asyncRequestStringWrapper = FBUnityUtility.AsyncRequestStringWrapper;
				Uri graphUrl = ((FacebookBase)asyncRequestStringWrapper).GetGraphUrl(query);
				asyncRequestStringWrapper.Request(graphUrl, method, wWWForm, callback);
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000088")]
		public abstract void ActivateApp(string appId = null);

		[Token(Token = "0x6000089")]
		public abstract void GetAppLink(FacebookDelegate<IAppLinkResult> callback);

		[Token(Token = "0x600008A")]
		public abstract void AppEventsLogEvent(string logEvent, float? valueToSum, Dictionary<string, object> parameters);

		[Token(Token = "0x600008B")]
		public abstract void AppEventsLogPurchase(float logPurchase, string currency, Dictionary<string, object> parameters);

		[Token(Token = "0x600008C")]
		[Address(RVA = "0xD2D59C", Offset = "0xD2D59C", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1ED30D8]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, resultContainer, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2023C18]) = v45;\nL_0018:\n\tthis.<Initialized>k__BackingField = 1;\n\tv50 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>::.ctor(v50, this, Il2CppMethodInfo);\n\tv75 = resultContainer.<ResultDictionary>k__BackingField;\n\tv69 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, v50);\n\tv87 = *([v75 @ X21_v4 (Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>)]);\n\tv94 = *([v87 @ X8_v12 (Il2CppClass<Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>>)+126]) == 0;\n\tif (v94) goto L_005B;\n\tv201 = *([v87 @ X8_v12 (Il2CppClass<Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>>)+B0]) + 8;\nL_0046:\n\tv207 = *([v201 @ X11_v5-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v207) goto L_005E;\n\tv202 = v202 + 1;\n\tv212 = v202 < *([v87 @ X8_v12 (Il2CppClass<Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>>)+126]);\n\tv183 = ~v212;\n\tv201 = v201 + 0x10;\n\tv167 = ~v183;\n\tif (v167) goto L_0046;\nL_005B:\n\tv219 = Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>::.ctor(v75, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 1);\n\tgoto L_0067;\nL_005E:\n\tv214 = *([v201 @ X11_v5]) + 1;\n\tv215 = v214 << 4;\n\tv216 = v87 + v215;\n\tv219 = v216 + 0x130;\nL_0067:\n\t*([v219 @ X0_v10 (Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>)])(v226, v75, \"callback_id\", v69, *([v219 @ X0_v10 (Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>)+8]), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv156 = this->klass;\n\tv139 = this->klass->vtable[44];\n\tv141 = this->klass->vtable[44];\n\t// 117 IndirectJump v139 @ X3_v3, this @ X0 (Facebook.Unity.FacebookBase), this @ X0 (Facebook.Unity.FacebookBase), resultContainer @ X1 (Facebook.Unity.ResultContainer), v141 @ X2_v7, v139 @ X3_v3, v31 @ X4, v32 @ X5, v33 @ X6, v34 @ X7, v35 @ V0, v36 @ V1, v37 @ V2, v38 @ V3, v39 @ V4, v40 @ V5, v41 @ V6, v42 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void OnInitComplete(ResultContainer resultContainer)
		{
			//IL_0032: Expected I, but got O
			//IL_0170: Expected I, but got O
			//IL_0180: Expected O, but got I
			//IL_0190: Expected O, but got I
			//IL_006d: Expected O, but got I
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_0102: Expected O, but got I
			//IL_0111: Expected O, but got I
			//IL_00b9: Expected O, but got I
			Initialized = true;
			FacebookDelegate<ILoginResult> callback = delegate
			{
				if (onInitCompleteDelegate != null)
				{
					onInitCompleteDelegate();
				}
			};
			FacebookDelegate<ILoginResult> resultDictionary = (FacebookDelegate<ILoginResult>)(object)resultContainer.ResultDictionary;
			string text = CallbackManager.AddFacebookDelegate(callback);
			IntPtr intPtr = (IntPtr)resultDictionary;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X8_v12 (Il2CppClass<Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X8_v12 (Il2CppClass<Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ X11_v5-8]");
					if ((IntPtr)0 != (IntPtr)typeof(IDictionary<string, object>))
					{
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X8_v12 (Il2CppClass<Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>>)+126]");
						bool flag = (long)num2 < 0L;
						flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						continue;
					}
					object obj2 = obj + 1;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					FacebookDelegate<ILoginResult> facebookDelegate = (FacebookDelegate<ILoginResult>)((long)(IntPtr)obj3 + 304L);
					break;
				}
				while (!flag2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v219 @ X0_v10 (Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>)] (should have been resolved before IL gen)");
			IntPtr intPtr2 = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X8_v15 (Il2CppClass<Facebook.Unity.FacebookBase>)+3F0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X8_v15 (Il2CppClass<Facebook.Unity.FacebookBase>)+3F8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v139 @ X3_v3 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600008D")]
		public abstract void OnLoginComplete(ResultContainer resultContainer);

		[Token(Token = "0x600008E")]
		[Address(RVA = "0xD2D6F4", Offset = "0xD2D6F4", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ED9370]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, resultContainer, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2023CAB]) = v34;\nL_0014:\n\tv38.<CurrentAccessToken>k__BackingField = 0;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnLogoutComplete(ResultContainer resultContainer)
		{
			AccessToken.CurrentAccessToken = null;
		}

		[Token(Token = "0x600008F")]
		public abstract void OnGetAppLinkComplete(ResultContainer resultContainer);

		[Token(Token = "0x6000090")]
		public abstract void OnAppRequestsComplete(ResultContainer resultContainer);

		[Token(Token = "0x6000091")]
		public abstract void OnShareLinkComplete(ResultContainer resultContainer);

		[Token(Token = "0x6000092")]
		[Address(RVA = "0xD1EFCC", Offset = "0xD1EFCC", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([2023C19]) & 1;\n\tv27 = v26 == 0;\n\tv28 = ~v27;\n\tif (v28) goto L_001C;\n\tv31 = 0xD34EA0(this, message, actionType, objectId, to, filters, excludeIds, maxRecipients, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn;\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2023C19]) = X8;\nL_001C:\n\tv46 = System.String::IsNullOrEmpty(message);\n\tv48 = v46 == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_0090;\n\tv128 = System.String::IsNullOrEmpty(objectId);\n\tv134 = v128 == 0;\n\tif (v134) goto L_003B;\n\tv139 = actionType & 0xFF00000000;\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_004A;\n\tv180 = System.String::IsNullOrEmpty(objectId);\n\tv195 = v180 == 0;\n\tv168 = ~v195;\n\tif (v168) goto L_004A;\n\tv163 = new System.ArgumentNullException();\n\tgoto L_00AB;\nL_003B:\n\tv142 = actionType < 1;\n\tv143 = ~v142;\n\tv144 = actionType - 1;\n\tv146 = v144 == 0;\n\tv151 = ~v146;\n\tv152 = v143 & v151;\n\tif (v152) goto L_00A2;\n\tv186 = actionType & 0xFF00000000;\n\tv184 = v186 == 0;\n\tif (v184) goto L_00A2;\nL_004A:\n\tv187 = to == 0;\n\tif (v187) goto L_008C;\n\tgoto L_005A;\n\tv212 = *([v197 @ X0_v12 (Il2CppClass<Facebook.Unity.FacebookBase+<>c>)+E0]);\n\tv213 = v212 == 0;\n\tv214 = ~v213;\n\tif (v214) goto L_005A;\n\tv225 = \"il2cpp_codegen_runtime_class_init\"(v197, v181, actionType, objectId, to, filters, excludeIds, maxRecipients, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv216 = Facebook.Unity.FacebookBase+<>c;\nL_005A:\n\tv172 = v219.<>9__41_0;\n\tv221 = v219.<>9__41_0 == 0;\n\tv222 = ~v221;\n\tif (v222) goto L_007F;\n\tgoto L_006D;\n\tv245 = *([v215 @ X0_v13 (Il2CppClass<Facebook.Unity.FacebookBase+<>c>)+E0]);\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\tif (v247) goto L_006D;\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v215, v181, actionType, objectId, to, filters, excludeIds, maxRecipients, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv264 = Facebook.Unity.FacebookBase+<>c;\n\tv252 = *([v264 @ X8_v28+B8]);\nL_006D:\n\tv236 = new System.Func`2<System.String, System.Boolean>();\n\tSystem.Func`2<System.String, System.Boolean>::.ctor(v236, v251.<>9, Il2CppMethodInfo);\n\tv242.<>9__41_0 = v236;\nL_007F:\n\tv202 = System.Linq.Enumerable::Any(to, v172);\n\tv257 = v202 == 0;\n\tv169 = ~v257;\n\tif (v169) goto L_0099;\nL_008C:\n\treturn;\nL_0090:\n\tv163 = new System.ArgumentNullException();\n\tgoto L_00AB;\nL_0099:\n\tv163 = new System.ArgumentNullException();\n\tgoto L_00AB;\nL_00A2:\n\tv163 = new System.ArgumentNullException();\nL_00AB:\n\tSystem.ArgumentNullException::.ctor(v163, *([v173 @ X8_v2 (System.String)]), *([v97 @ X9_v1 (System.String)]));\n\tthrow v163;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal unsafe void ValidateAppRequestArgs(string message, OGActionType? actionType, string objectId, IEnumerable<string> to = null, IEnumerable<object> filters = null, IEnumerable<string> excludeIds = null, int? maxRecipients = null, string data = "", string title = "", FacebookDelegate<IAppRequestResult> callback = null)
		{
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Expected O, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected I4, but got Unknown
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Expected I4, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2023C19]");
			if (0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @D34EA0 (inside Facebook.Unity.Utilities+<>c::<ParsePermissionFromResult>b__18_0 +0x3C)");
				return;
			}
			ArgumentNullException ex;
			string text = default(string);
			string text2 = default(string);
			if (!string.IsNullOrEmpty(message))
			{
				if (string.IsNullOrEmpty(objectId))
				{
					if ((int)((_003F?)actionType & 0xFF00000000L) != 0 || string.IsNullOrEmpty(objectId))
					{
						goto IL_018e;
					}
					ex = new ArgumentNullException();
					text = "actionType must be specified if objectId is provided";
					text2 = "actionType";
				}
				else
				{
					bool flag = (long)(IntPtr)(void*)actionType < 1L;
					bool flag2 = !flag;
					object obj = (_003F?)actionType - 1;
					bool flag3 = obj == null;
					bool flag4 = !flag3;
					if (!(flag2 && flag4) && (int)((_003F?)actionType & 0xFF00000000L) != 0)
					{
						goto IL_018e;
					}
					ex = new ArgumentNullException();
					text = "objectId must be set if and only if action type is SEND or ASKFOR";
					text2 = "objectId";
				}
			}
			else
			{
				ex = new ArgumentNullException(text2, text);
				text = "message cannot be null or empty!";
				text2 = "message";
			}
			goto IL_0253;
			IL_018e:
			if (to == null)
			{
				return;
			}
			Func<string, bool> predicate = _003C_003Ec._003C_003E9__41_0;
			if (_003C_003Ec._003C_003E9__41_0 == null)
			{
				predicate = (_003C_003Ec._003C_003E9__41_0 = (string toWhom) => string.IsNullOrEmpty(toWhom));
			}
			if (!to.Any(predicate))
			{
				return;
			}
			ex = new ArgumentNullException();
			text = "'to' cannot contain any null or empty strings";
			text2 = "to";
			goto IL_0253;
			IL_0253:
			throw ex;
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0xD2D744", Offset = "0xD2D744", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = result.<AccessToken>k__BackingField == 0;\n\tif (v20) goto L_002A;\n\tgoto L_001E;\n\tv56 = *([1ED9370]);\n\tv57 = *([v56 @ X8_v10]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, result, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv60 = 0 | 1;\n\t*([2023CAB]) = v60;\nL_001E:\n\tv29.<CurrentAccessToken>k__BackingField = result.<AccessToken>k__BackingField;\nL_002A:\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, result);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void OnAuthResponse(LoginResult result)
		{
			if (result.AccessToken != null)
			{
				AccessToken.CurrentAccessToken = result.AccessToken;
			}
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0xD2CFE0", Offset = "0xD2CFE0", Length = "0x36C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1ED2A58]);\n\tv27 = *([v26 @ X8_v36]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, data, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 0 | 1;\n\t*([2023C1A]) = v46;\nL_0017:\n\tv47 = v252 == 0;\n\tif (v47) goto L_0107;\n\tgoto L_0046;\n\tv122 = *([v49 @ X8_v11+B0]);\n\tv123 = 0;\n\tv124 = v122 + 8;\n\tv126 = *([v162 @ X11_v35-8]);\n\tv168 = v126 == v52;\n\tif (v168) goto L_003F;\n\tv148 = v163 + 1;\n\tv183 = v148 < v51;\n\tv144 = ~v183;\n\tv146 = v162 + 0x10;\n\tv128 = ~v144;\n\tif (v128) goto L_FFFFFFFF;\n\tv149 = v20;\n\tv150 = 0;\n\tv151 = 0x8909C4(v149, v52, v150, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0046;\nL_003F:\n\tv184 = *([v162 @ X11_v35]);\n\tv185 = v184 << 4;\n\tv186 = v49 + v185;\n\tv187 = v186 + 0x130;\nL_0046:\n\tv208 = System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::get_Count(v252);\n\tv214 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v214, v208);\n\tgoto L_0080;\n\tv323 = *([v276 @ X8_v19+B0]);\n\tv324 = 0;\n\tv325 = v323 + 8;\n\tv327 = *([v442 @ X11_v30-8]);\n\tv448 = v327 == v279;\n\tif (v448) goto L_0079;\n\tv349 = v443 + 1;\n\tv484 = v349 < v278;\n\tv345 = ~v484;\n\tv347 = v442 + 0x10;\n\tv329 = ~v345;\n\tif (v329) goto L_FFFFFFFF;\n\tv350 = v20;\n\tv351 = 0;\n\tv352 = 0x8909C4(v350, v279, v351, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0080;\nL_0079:\n\tv485 = *([v442 @ X11_v30]);\n\tv486 = v485 << 4;\n\tv487 = v276 + v486;\n\tv488 = v487 + 0x130;\nL_0080:\n\tv509 = System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::GetEnumerator(v252);\nL_008E:\n\tgoto L_00B5;\n\tv591 = *([v585 @ X8_v24+B0]);\n\tv592 = 0;\n\tv593 = v591 + 8;\n\tv595 = *([v641 @ X11_v25-8]);\n\tv647 = v595 == v586;\n\tif (v647) goto L_00AE;\n\tv617 = v642 + 1;\n\tv652 = v617 < v587;\n\tv613 = ~v652;\n\tv615 = v641 + 0x10;\n\tv597 = ~v613;\n\tif (v597) goto L_FFFFFFFF;\n\tv618 = v115;\n\tv619 = 0;\n\tv620 = 0x8909C4(v618, v586, v619, v66, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00B5;\nL_00AE:\n\tv653 = *([v641 @ X11_v25]);\n\tv654 = v653 << 4;\n\tv655 = v585 + v654;\n\tv656 = v655 + 0x130;\nL_00B5:\n\tv393 = System.Collections.IEnumerator::MoveNext(v509);\n\tv661 = v393 == 0;\n\tif (v661) goto L_00FE;\n\tgoto L_00E4;\n\tv667 = *([v662 @ X8_v27+B0]);\n\tv668 = 0;\n\tv669 = v667 + 8;\n\tv671 = *([v707 @ X11_v20-8]);\n\tv713 = v671 == v663;\n\tif (v713) goto L_00DD;\n\tv693 = v708 + 1;\n\tv718 = v693 < v664;\n\tv689 = ~v718;\n\tv691 = v707 + 0x10;\n\tv673 = ~v689;\n\tif (v673) goto L_FFFFFFFF;\n\tv694 = v115;\n\tv695 = 0;\n\tv696 = 0x8909C4(v694, v663, v695, v66, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00E4;\nL_00DD:\n\tv719 = *([v707 @ X11_v20]);\n\tv720 = v719 << 4;\n\tv721 = v662 + v720;\n\tv722 = v721 + 0x130;\nL_00E4:\n\tv627 = System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::get_Current(v509);\n\tgoto L_FFFFFFFF;\n\tv730 = System.String::ToCharArray(0);\n\tv626 = System.String::CreateString(0, v730);\n\tv735 = v214 == 0;\n\tv628 = ~v735;\n\tif (v628) goto L_00FA;\n\tgoto L_0105;\nL_00FA:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v214, v627, v543);\n\tgoto L_008E;\nL_00FE:\n\tv666 = v509 == 0;\n\tv395 = ~v666;\n\tif (v395) goto L_0125;\n\tgoto L_014D;\n\tthrow System.NullReferenceException;\nL_0105:\n\tthrow System.NullReferenceException;\nL_0107:\n\tv121 = new System.NullReferenceException();\n\tgoto L_0117;\n\tgoto L_0117;\n\tgoto L_0117;\n\tgoto L_0117;\n\tgoto L_0117;\n\tgoto L_0117;\nL_0117:\n\tv182 = v252 != 1;\n\tif (v182) goto L_0166;\n\tv215 = System.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v121, v252, v230);\n\tv357 = *([v215 @ X0_v18 (System.Collections.Generic.Dictionary`2<System.String, System.String>)]);\n\tv274 = System.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v215, v252, v230);\n\tv282 = v252 == 0;\n\tif (v282) goto L_014D;\nL_0125:\n\tgoto L_014C;\n\tv453 = *([v401 @ X8_v6+B0]);\n\tv454 = 0;\n\tv455 = v453 + 8;\n\tv457 = *([v523 @ X11_v8-8]);\n\tv529 = v457 == v404;\n\tif (v529) goto L_0145;\n\tv479 = v524 + 1;\n\tv577 = v479 < v403;\n\tv475 = ~v577;\n\tv477 = v523 + 0x10;\n\tv459 = ~v475;\n\tif (v459) goto L_FFFFFFFF;\n\tv480 = v396;\n\tv481 = 0;\n\tv482 = 0x8909C4(v480, v404, v481, v361, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_014C;\nL_0145:\n\tv578 = *([v523 @ X11_v8]);\n\tv579 = v578 << 4;\n\tv580 = v401 + v579;\n\tv581 = v580 + 0x130;\nL_014C:\n\tSystem.IDisposable::Dispose(v396);\nL_014D:\n\tv431 = v225 + 1;\n\tv243 = v431 == 0;\n\tv233 = ~v243;\n\tif (v233) goto L_0161;\n\tv483 = v223 == 0;\n\tv261 = ~v483;\n\tif (v261) goto L_0165;\nL_0161:\n\treturn v267;\nL_0165:\n\tv259 = new System.TypeLoadException();\nL_0166:\n\treturnVal1 = System.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v258, 0, 0);\n\treturn returnVal1;\n// 198 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IDictionary<string, string> CopyByValue(IDictionary<string, string> data)
		{
			//IL_020e: Expected O, but got I4
			//IL_0136: Expected O, but got I
			//IL_013e: Expected I, but got O
			//IL_014f: Expected O, but got I
			//IL_017c: Expected I, but got O
			//IL_018f: Expected O, but got I4
			//IL_00a6: Expected I, but got O
			//IL_00d2: Expected I, but got O
			IDictionary<string, string> dictionary = default(IDictionary<string, string>);
			bool flag = dictionary == null;
			Dictionary<string, string> dictionary2 = (Dictionary<string, string>)33697792;
			Dictionary<string, string> dictionary3;
			IntPtr intPtr2;
			int num;
			IDisposable disposable;
			IntPtr intPtr3;
			int num2;
			Dictionary<string, string> result;
			if (flag)
			{
				NullReferenceException ex = new NullReferenceException();
				bool flag2 = (IntPtr)dictionary != (IntPtr)1;
				dictionary3 = (Dictionary<string, string>)(object)ex;
				if (flag2)
				{
					goto IL_01e6;
				}
				IntPtr intPtr = default(IntPtr);
				((Dictionary<string, string>)(object)ex).set_Item((string)(object)dictionary, (string)(long)intPtr);
				Dictionary<string, string> dictionary4 = default(Dictionary<string, string>);
				intPtr2 = (IntPtr)dictionary4;
				dictionary4.set_Item((string)(object)dictionary, (string)(long)intPtr);
				bool flag3 = dictionary == null;
				num = -1;
				disposable = (IDisposable)dictionary;
				intPtr3 = (IntPtr)dictionary4;
				num2 = -1;
				result = (Dictionary<string, string>)33697792;
				if (flag3)
				{
					goto IL_028c;
				}
			}
			else
			{
				int count = dictionary.Count;
				Dictionary<string, string> dictionary5 = new Dictionary<string, string>(count);
				IEnumerator<KeyValuePair<string, string>> enumerator = dictionary.GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, string> current = enumerator.Current;
					string value = null;
					dictionary5.set_Item((string)current, value);
				}
				bool flag4 = enumerator == null;
				bool flag5 = !flag4;
				intPtr2 = (IntPtr)null;
				num = 0;
				disposable = enumerator;
				dictionary2 = dictionary5;
				if (!flag5)
				{
					intPtr3 = (IntPtr)null;
					num2 = 0;
					result = dictionary5;
					goto IL_028c;
				}
			}
			disposable.Dispose();
			intPtr3 = intPtr2;
			num2 = num;
			result = dictionary2;
			goto IL_028c;
			IL_028c:
			if (num2 + 1 != 0 || intPtr3 == (IntPtr)0)
			{
				return result;
			}
			TypeLoadException ex2 = new TypeLoadException();
			dictionary3 = (Dictionary<string, string>)(object)ex2;
			goto IL_01e6;
			IL_01e6:
			dictionary3.set_Item((string)null, (string)null);
			IDictionary<string, string> result2 = default(IDictionary<string, string>);
			return result2;
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0xD2D34C", Offset = "0xD2D34C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EFD7B0]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, query, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2023C1B]) = v40;\nL_0016:\n\tv43 = System.String::IsNullOrEmpty(query);\n\tv45 = v43 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_002B;\n\tv43 = System.String::StartsWith(query, \"/\");\n\tv58 = v43 == 0;\n\tif (v58) goto L_002B;\n\tv55 = System.String::Substring(query, 1);\nL_002B:\n\tv63 = Facebook.Unity.Constants::get_GraphUrl();\n\tv73 = new System.Uri();\n\tSystem.Uri::.ctor(v73, v63, v59);\n\treturn v73;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Uri GetGraphUrl(string query)
		{
			//IL_0056: Expected I4, but got O
			bool flag = string.IsNullOrEmpty(query);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			string relativeUri = query;
			if (!flag3)
			{
				flag = query.StartsWith("/");
				bool flag4 = !flag;
				relativeUri = query;
				if (!flag4)
				{
					string text = query.Substring(1);
					flag = (byte)(int)text != 0;
					relativeUri = text;
				}
			}
			Uri graphUrl = Constants.GraphUrl;
			return new Uri(graphUrl, relativeUri);
		}
	}
}
