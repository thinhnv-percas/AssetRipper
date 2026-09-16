using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x2000007")]
	internal class CallbackManager
	{
		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x10")]
		private IDictionary<string, object> facebookDelegates;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x18")]
		private int nextAsyncId;

		[Token(Token = "0x6000028")]
		[Address(RVA = "0xBAE7A4", Offset = "0xBAE7A4", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EAD7A0]);\n\tv25 = *([v24 @ X8_v11]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, callback, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022C28]) = v43;\nL_0016:\n\tv44 = callback == 0;\n\tif (v44) goto L_0051;\n\tv45 = this + 0x18;\n\tv48 = this.facebookDelegates;\n\tv49 = this.nextAsyncId + 1;\n\tthis.nextAsyncId = v49;\n\tv51 = 0xDC3560(v45, 0, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv129 = *([v48 @ X21_v3 (System.Collections.Generic.IDictionary`2<System.String, System.Object>)]);\n\tv117 = *([v129 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v117) goto L_0047;\n\tv174 = *([v129 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_0032:\n\tv180 = *([v174 @ X11_v5-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v180) goto L_0053;\n\tv175 = v175 + 1;\n\tv185 = v175 < *([v129 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv156 = ~v185;\n\tv174 = v174 + 0x10;\n\tv140 = ~v156;\n\tif (v140) goto L_0032;\nL_0047:\n\tv192 = 0x8909C4(v48, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 4, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_005C;\nL_0051:\n\treturn 0;\nL_0053:\n\tv187 = *([v174 @ X11_v5]) + 4;\n\tv188 = v187 << 4;\n\tv189 = v129 + v188;\n\tv192 = v189 + 0x130;\nL_005C:\n\t*([v192 @ X0_v7])(v196, v48, v51, callback, *([v192 @ X0_v7+8]), v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturnVal3 = 0xDC3560(v45, 0, callback, *([v192 @ X0_v7+8]), v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string AddFacebookDelegate<T>(FacebookDelegate<T> callback) where T : IResult
		{
			//IL_0011: Expected O, but got I
			//IL_004c: Expected I, but got O
			//IL_0087: Expected O, but got I
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Expected O, but got Unknown
			//IL_0128: Expected O, but got I
			//IL_0137: Expected O, but got I
			//IL_00d3: Expected O, but got I
			if (callback != null)
			{
				object obj = (long)(IntPtr)this + 24L;
				IDictionary<string, object> dictionary = facebookDelegates;
				int num = nextAsyncId + 1;
				nextAsyncId = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
				IntPtr intPtr = (IntPtr)dictionary;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ec;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
				object obj2 = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v5 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
					bool flag = (long)num3 < 0L;
					bool flag2 = !flag;
					obj2 = (long)(IntPtr)obj2 + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ec;
				}
				object obj3 = obj2 + 4;
				int num4 = (int)((long)(IntPtr)obj3 << 4);
				object obj4 = (long)intPtr + (long)num4;
				object obj5 = (long)(IntPtr)obj4 + 304L;
				goto IL_0183;
			}
			return null;
			IL_0183:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v192 @ X0_v7] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
			string result = default(string);
			return result;
			IL_00ec:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0183;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0xD1D724", Offset = "0xD1D724", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1F064D8]);\n\tv29 = *([v28 @ X8_v27]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, result, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023B5F]) = v47;\nL_0019:\n\tv49 = result == 0;\n\tif (v49) goto L_0119;\n\tgoto L_0048;\n\tv169 = *([v51 @ X8_v4+B0]);\n\tv170 = 0;\n\tv171 = v169 + 8;\n\tv173 = *([v263 @ X11_v31-8]);\n\tv268 = v173 == v54;\n\tif (v268) goto L_0041;\n\tv193 = v262 + 1;\n\tv273 = v193 < v53;\n\tv191 = ~v273;\n\tv195 = v263 + 0x10;\n\tv175 = ~v191;\n\tif (v175) goto L_FFFFFFFF;\n\tv196 = v20;\n\tv197 = 0;\n\tv198 = 0x8909C4(v196, v54, v197, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0048;\nL_0041:\n\tv274 = *([v263 @ X11_v31]);\n\tv275 = v274 << 4;\n\tv276 = v51 + v275;\n\tv277 = v276 + 0x130;\nL_0048:\n\tv145 = Facebook.Unity.IInternalResult::get_CallbackId(result);\n\tv149 = v145 == 0;\n\tif (v149) goto L_0119;\n\tv160 = this.facebookDelegates;\n\tgoto L_0077;\n\tv285 = *([v281 @ X8_v7+B0]);\n\tv286 = 0;\n\tv287 = v285 + 8;\n\tv289 = *([v326 @ X11_v26-8]);\n\tv331 = v289 == v282;\n\tif (v331) goto L_0070;\n\tv309 = v325 + 1;\n\tv336 = v309 < v283;\n\tv307 = ~v336;\n\tv311 = v326 + 0x10;\n\tv291 = ~v307;\n\tif (v291) goto L_FFFFFFFF;\n\tv312 = v20;\n\tv313 = 0;\n\tv314 = 0x8909C4(v312, v282, v313, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0077;\nL_0070:\n\tv337 = *([v326 @ X11_v26]);\n\tv338 = v337 << 4;\n\tv339 = v281 + v338;\n\tv340 = v339 + 0x130;\nL_0077:\n\tv361 = Facebook.Unity.IInternalResult::get_CallbackId(result);\n\tv364 = *([v160 @ X21_v4 (System.Collections.Generic.IDictionary`2<System.String, System.Object>)]);\n\tv367 = *([v364 @ X8_v11 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v367) goto L_009F;\n\tv430 = *([v364 @ X8_v11 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_008A:\n\tv435 = *([v430 @ X11_v21-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v435) goto L_00A2;\n\tv429 = v429 + 1;\n\tv440 = v429 < *([v364 @ X8_v11 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv411 = ~v440;\n\tv430 = v430 + 0x10;\n\tv395 = ~v411;\n\tif (v395) goto L_008A;\nL_009F:\n\tv447 = 0x8909C4(v160, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 6, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00AB;\nL_00A2:\n\tv442 = *([v430 @ X11_v21]) + 6;\n\tv443 = v442 << 4;\n\tv444 = v364 + v443;\n\tv447 = v444 + 0x130;\nL_00AB:\n\t*([v447 @ X0_v12])(v146, v160, v361, &v66 @ stack_-48_v4 (System.Object), *([v447 @ X0_v12+8]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv450 = v146 & 1;\n\tv150 = v450 == 0;\n\tif (v150) goto L_0119;\n\tFacebook.Unity.CallbackManager::CallCallback(v66, result);\n\tgoto L_00DE;\n\tv457 = *([v453 @ X8_v14+B0]);\n\tv458 = 0;\n\tv459 = v457 + 8;\n\tv461 = *([v498 @ X11_v16-8]);\n\tv503 = v461 == v454;\n\tif (v503) goto L_00D7;\n\tv481 = v497 + 1;\n\tv508 = v481 < v455;\n\tv479 = ~v508;\n\tv483 = v498 + 0x10;\n\tv463 = ~v479;\n\tif (v463) goto L_FFFFFFFF;\n\tv484 = v20;\n\tv485 = 0;\n\tv486 = 0x8909C4(v484, v454, v485, v57, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00DE;\nL_00D7:\n\tv509 = *([v498 @ X11_v16]);\n\tv510 = v509 << 4;\n\tv511 = v453 + v510;\n\tv512 = v511 + 0x130;\nL_00DE:\n\tv385 = Facebook.Unity.IInternalResult::get_CallbackId(result);\n\tgoto L_010F;\n\tv519 = *([v516 @ X8_v17+B0]);\n\tv520 = 0;\n\tv521 = v519 + 8;\n\tv523 = *([v560 @ X11_v11-8]);\n\tv565 = v523 == v517;\n\tif (v565) goto L_0106;\n\tv543 = v559 + 1;\n\tv570 = v543 < v518;\n\tv541 = ~v570;\n\tv545 = v560 + 0x10;\n\tv525 = ~v541;\n\tif (v525) goto L_FFFFFFFF;\n\tv546 = 5;\n\tv547 = v152;\n\tv548 = 0x8909C4(v547, v517, v546, v57, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_010F;\nL_0106:\n\tv571 = *([v560 @ X11_v11]);\n\tv572 = v571 + 5;\n\tv573 = v572 << 4;\n\tv574 = v516 + v573;\n\tv575 = v574 + 0x130;\nL_010F:\n\tv144 = System.Collections.Generic.IDictionary`2<System.String, System.Object>::Remove(this.facebookDelegates, v385);\nL_0119:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 159 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnFacebookResponse(IInternalResult result)
		{
			//IL_0021: Expected I, but got O
			//IL_005c: Expected O, but got I
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Expected O, but got Unknown
			//IL_00fb: Expected O, but got I
			//IL_010a: Expected O, but got I
			//IL_00a8: Expected O, but got I
			if (result == null)
			{
				return;
			}
			string callbackId = result.CallbackId;
			if (callbackId == null)
			{
				return;
			}
			IDictionary<string, object> dictionary = facebookDelegates;
			string callbackId2 = result.CallbackId;
			IntPtr intPtr = (IntPtr)dictionary;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v11 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v11 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ X11_v21-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ X8_v11 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c1;
			}
			object obj2 = obj + 6;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_01a9;
			IL_00c1:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_01a9;
			IL_01a9:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v447 @ X0_v12] (should have been resolved before IL gen)");
			object obj5 = default(object);
			if ((uint)((ulong)(long)(IntPtr)obj5 & 1uL) != 0)
			{
				object callback = default(object);
				CallCallback(callback, result);
				string callbackId3 = result.CallbackId;
				bool flag3 = facebookDelegates.Remove(callbackId3);
			}
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0xD1D9C0", Offset = "0xD1D9C0", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC3498]);\n\tv23 = *([v22 @ X8_v33]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, result, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B60]) = v41;\nL_0015:\n\tv42 = callback == 0;\n\tif (v42) goto L_0078;\n\tv43 = result == 0;\n\tif (v43) goto L_0078;\n\tv66 = Facebook.Unity.CallbackManager::TryCallCallback(callback, result);\n\tv121 = v66 == 0;\n\tv76 = ~v121;\n\tif (v76) goto L_0078;\n\tv67 = Facebook.Unity.CallbackManager::TryCallCallback(callback, result);\n\tv125 = v67 == 0;\n\tv77 = ~v125;\n\tif (v77) goto L_0078;\n\tv68 = Facebook.Unity.CallbackManager::TryCallCallback(callback, result);\n\tv129 = v68 == 0;\n\tv78 = ~v129;\n\tif (v78) goto L_0078;\n\tv69 = Facebook.Unity.CallbackManager::TryCallCallback(callback, result);\n\tv133 = v69 == 0;\n\tv79 = ~v133;\n\tif (v79) goto L_0078;\n\tv70 = Facebook.Unity.CallbackManager::TryCallCallback(callback, result);\n\tv137 = v70 == 0;\n\tv80 = ~v137;\n\tif (v80) goto L_0078;\n\tv71 = Facebook.Unity.CallbackManager::TryCallCallback(callback, result);\n\tv141 = v71 == 0;\n\tv81 = ~v141;\n\tif (v81) goto L_0078;\n\tv72 = Facebook.Unity.CallbackManager::TryCallCallback(callback, result);\n\tv145 = v72 == 0;\n\tv82 = ~v145;\n\tif (v82) goto L_0078;\n\tv73 = Facebook.Unity.CallbackManager::TryCallCallback(callback, result);\n\tv149 = v73 == 0;\n\tv83 = ~v149;\n\tif (v83) goto L_0078;\n\tv65 = Facebook.Unity.CallbackManager::TryCallCallback(callback, result);\n\tv75 = v65 == 0;\n\tif (v75) goto L_007B;\nL_0078:\n\treturn;\nL_007B:\n\tv155 = Facebook.Unity.CallbackManager::TryCallCallback(callback, 0);\n\tv158 = System.Object::GetType(callback);\n\tv161 = Facebook.Unity.CallbackManager::TryCallCallback(v158, 0);\n\tv165 = System.Type::get_FullName(v158);\n\tv172 = System.String::Concat(\"Unexpected result type: \", v165);\n\tv177 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v177, v172);\n\tthrow v177;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void CallCallback(object callback, IResult result)
		{
			if (callback == null || result == null || TryCallCallback<IAppRequestResult>(callback, result) || TryCallCallback<IShareResult>(callback, result) || TryCallCallback<IGroupCreateResult>(callback, result) || TryCallCallback<IGroupJoinResult>(callback, result) || TryCallCallback<IPayResult>(callback, result) || TryCallCallback<IAppLinkResult>(callback, result) || TryCallCallback<ILoginResult>(callback, result) || TryCallCallback<IAccessTokenRefreshResult>(callback, result) || TryCallCallback<IHasLicenseResult>(callback, result))
			{
				return;
			}
			bool flag = TryCallCallback<IHasLicenseResult>(callback, null);
			Type type = callback.GetType();
			bool flag2 = TryCallCallback<IHasLicenseResult>(type, null);
			string fullName = type.FullName;
			string message = "Unexpected result type: " + fullName;
			NotSupportedException ex = new NotSupportedException(message);
			throw ex;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x11B95B4", Offset = "0x11B95B4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv28 = v23;\n\tv29 = 0x8907BC(v28, result, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0017:\n\t// 23 IsInst v46 @ X0_v3 (Facebook.Unity.FacebookDelegate`1<T>), typeof(Facebook.Unity.FacebookDelegate`1<T>), callback @ X0 (System.Object)\n\tv48 = v46 == 0;\n\tif (v48) goto L_0040;\n\tgoto L_0026;\n\tv78 = v50;\n\tv79 = 0x8907BC(v78, v45, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0026:\n\tv81 = result == 0;\n\tif (v81) goto L_FFFFFFFF;\n\t// 42 IsInst v84 @ X0_v12 (T), typeof(T), result @ X1 (Facebook.Unity.IResult)\n\tv93 = v84 == 0;\n\tv90 = ~v93;\n\tif (v90) goto L_0036;\n\tthrow System.InvalidCastException;\nL_0036:\n\tv96 = Facebook.Unity.FacebookDelegate`1<T>::Invoke(v46, v63);\nL_0040:\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool TryCallCallback<T>(object callback, IResult result) where T : IResult
		{
			//IL_0029: Expected I4, but got O
			FacebookDelegate<T> facebookDelegate = callback as FacebookDelegate<T>;
			bool flag = facebookDelegate == null;
			bool result2 = (byte)(int)facebookDelegate != 0;
			if (!flag)
			{
				T result3;
				if (result != null)
				{
					T val = (T)((result is T) ? result : null);
					bool flag2 = val == null;
					bool flag3 = !flag2;
					result3 = val;
					if (!flag3)
					{
						throw new InvalidCastException();
					}
				}
				else
				{
					result3 = (T)null;
				}
				facebookDelegate(result3);
				result2 = true;
			}
			return result2;
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0xD1DBA4", Offset = "0xD1DBA4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EEDF58]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023B61]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v42);\n\tthis.facebookDelegates = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CallbackManager()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			facebookDelegates = dictionary;
		}
	}
}
