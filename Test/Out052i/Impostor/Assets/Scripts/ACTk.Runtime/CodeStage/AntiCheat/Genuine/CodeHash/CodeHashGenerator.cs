using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using CodeStage.AntiCheat.Common;
using Cpp2ILInjected;
using UnityEngine;

namespace CodeStage.AntiCheat.Genuine.CodeHash
{
	[DisallowMultipleComponent]
	[AddComponentMenu(null)]
	[Token(Token = "0x200002C")]
	public class CodeHashGenerator : KeepAliveBehaviour<CodeHashGenerator>, ICodeHashGenerator
	{
		[CompilerGenerated]
		[Token(Token = "0x200002D")]
		private sealed class _003CCalculationAwaiter_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40000D7")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40000D8")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40000D9")]
			[FieldOffset(Offset = "0x20")]
			public CodeHashGenerator _003C_003E4__this;

			[Token(Token = "0x1700001F")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000356")]
				[Address(RVA = "0xBE9810", Offset = "0xBE9810", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000020")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000358")]
				[Address(RVA = "0xBE9850", Offset = "0xBE9850", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000353")]
			[Address(RVA = "0xBE96B0", Offset = "0xBE96B0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CCalculationAwaiter_003Ed__20(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000354")]
			[Address(RVA = "0xBE975C", Offset = "0xBE975C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000355")]
			[Address(RVA = "0xBE9760", Offset = "0xBE9760", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3550F]) = v33;\nL_0011:\n\tv35 = this.<>1__state < 2;\n\tv36 = ~v35;\n\tif (v36) goto L_FFFFFFFF;\n\tv44 = this.<>4__this;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv56 = v44.currentWorker;\n\tv76 = ~v56.<IsBusy>k__BackingField;\n\tif (v76) goto L_002C;\n\tthis.<>1__state = 1;\n\tthis.<>2__current = v44.cachedWaitForSeconds;\n\tgoto L_003D;\nL_002C:\n\tv44.<LastResult>k__BackingField = v56.<Result>k__BackingField;\n\tv61 = v95.HashGenerated == 0;\n\tif (v61) goto L_FFFFFFFF;\n\tCodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResultHandler::Invoke(v95.HashGenerated, v56.<Result>k__BackingField);\nL_003D:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				if (_003C_003E1__state < 2)
				{
					CodeHashGenerator codeHashGenerator = _003C_003E4__this;
					_003C_003E1__state = -1;
					BaseWorker currentWorker = codeHashGenerator.currentWorker;
					if (currentWorker.IsBusy)
					{
						_003C_003E1__state = 1;
						_003C_003E2__current = codeHashGenerator.cachedWaitForSeconds;
						return true;
					}
					codeHashGenerator.LastResult = currentWorker.Result;
					if (CodeHashGenerator.HashGenerated != null)
					{
						CodeHashGenerator.HashGenerated(currentWorker.Result);
					}
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000357")]
			[Address(RVA = "0xBE9818", Offset = "0xBE9818", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x40000D3")]
		private static HashGeneratorResultHandler m_HashGenerated;

		[CompilerGenerated]
		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0x28")]
		private HashGeneratorResult _003CLastResult_003Ek__BackingField;

		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x30")]
		private readonly WaitForSeconds cachedWaitForSeconds;

		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x38")]
		private BaseWorker currentWorker;

		[Token(Token = "0x1700001D")]
		public HashGeneratorResult LastResult
		{
			[CompilerGenerated]
			[Token(Token = "0x6000345")]
			[Address(RVA = "0xBE8CC8", Offset = "0xBE8CC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<LastResult>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LastResult;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000346")]
			[Address(RVA = "0xBE8CD0", Offset = "0xBE8CD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<LastResult>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CLastResult_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700001E")]
		public bool IsBusy
		{
			[Token(Token = "0x600034A")]
			[Address(RVA = "0xBE8E3C", Offset = "0xBE8E3C", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.currentWorker;\n\tv2 = this.currentWorker == 0;\n\tif (v2) goto L_0011;\n\tv8 = v0.<IsBusy>k__BackingField == 0;\n\tv13 = ~v8;\n\treturn v13;\nL_0011:\n\treturn 0;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				BaseWorker baseWorker = currentWorker;
				if (currentWorker != null)
				{
					bool flag = !baseWorker.IsBusy;
					return !flag;
				}
				return false;
			}
		}

		[Token(Token = "0x14000003")]
		public static event HashGeneratorResultHandler HashGenerated
		{
			[CompilerGenerated]
			[Token(Token = "0x6000343")]
			[Address(RVA = "0xBE8B58", Offset = "0xBE8B58", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv20 = CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResultHandler;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A35504]) = v40;\nL_001F:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0034;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResultHandler;\n\tif (v105) goto L_0049;\nL_0034:\n\tv83 = 0xAF4130(v79.HashGenerated, v93, v88, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001F;\n\treturn;\nL_0049:\n\tthrow System.InvalidCastException;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				Delegate obj = CodeHashGenerator.m_HashGenerated;
				Delegate obj3 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if ((object)obj2 != null && (object)obj2.GetType() != typeof(HashGeneratorResultHandler))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj != obj3;
					obj = obj3;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000344")]
			[Address(RVA = "0xBE8C10", Offset = "0xBE8C10", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv20 = CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResultHandler;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A35505]) = v40;\nL_001F:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0034;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResultHandler;\n\tif (v105) goto L_0049;\nL_0034:\n\tv83 = 0xAF4130(v79.HashGenerated, v93, v88, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001F;\n\treturn;\nL_0049:\n\tthrow System.InvalidCastException;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				Delegate obj = CodeHashGenerator.m_HashGenerated;
				Delegate obj3 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if ((object)obj2 != null && (object)obj2.GetType() != typeof(HashGeneratorResultHandler))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AF4130");
					bool flag = (object)obj != obj3;
					obj = obj3;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x6000347")]
		[Address(RVA = "0xBE8CD8", Offset = "0xBE8CD8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsTargetPlatformCompatible()
		{
			return true;
		}

		[Token(Token = "0x6000348")]
		[Address(RVA = "0xBE8CE0", Offset = "0xBE8CE0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35506]) = v34;\nL_0016:\n\treturnVal1 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator>::get_GetOrCreateInstance();\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static CodeHashGenerator AddToSceneOrGetExisting()
		{
			return KeepAliveBehaviour<CodeHashGenerator>.GetOrCreateInstance;
		}

		[Token(Token = "0x6000349")]
		[Address(RVA = "0xBE8D20", Offset = "0xBE8D20", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35507]) = v34;\nL_0012:\n\tv36 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator>::get_GetOrCreateInstance();\n\treturnVal1 = CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator::GenerateInternal(v36);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ICodeHashGenerator Generate()
		{
			CodeHashGenerator getOrCreateInstance = KeepAliveBehaviour<CodeHashGenerator>.GetOrCreateInstance;
			return getOrCreateInstance.GenerateInternal();
		}

		[Token(Token = "0x600034B")]
		[Address(RVA = "0xBE8E5C", Offset = "0xBE8E5C", Length = "0x564")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0048;\n\tv28 = CodeStage.AntiCheat.Genuine.CodeHash.FileFilter;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv67 = System.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv71 = \"global-metadata\";\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv275 = \"libMonoPosixHelper\";\n\tv276 = \"il2cpp_codegen_initialize_runtime_metadata\"(v275, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv280 = \"libmonobdwgc\";\n\tv281 = \"il2cpp_codegen_initialize_runtime_metadata\"(v280, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv332 = \"dat\";\n\tv333 = \"il2cpp_codegen_initialize_runtime_metadata\"(v332, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv343 = \"classes\";\n\tv344 = \"il2cpp_codegen_initialize_runtime_metadata\"(v343, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv349 = \"libil2cpp\";\n\tv350 = \"il2cpp_codegen_initialize_runtime_metadata\"(v349, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv352 = \"dll\";\n\tv353 = \"il2cpp_codegen_initialize_runtime_metadata\"(v352, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv355 = \"libmain\";\n\tv356 = \"il2cpp_codegen_initialize_runtime_metadata\"(v355, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv364 = \"dex\";\n\tv365 = \"il2cpp_codegen_initialize_runtime_metadata\"(v364, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv368 = \"libunity\";\n\tv369 = \"il2cpp_codegen_initialize_runtime_metadata\"(v368, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv379 = \"so\";\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v379, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A35508]) = v48;\nL_0048:\n\tv50 = new System.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>();\n\tSystem.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>::.ctor(v50);\n\tv60 = new CodeStage.AntiCheat.Genuine.CodeHash.FileFilter();\n\tSystem.Object::.ctor(v60);\n\tv60.filterExtension = \"dex\";\n\tv60.filterFileName = \"classes\";\n\tv249 = v50._items;\n\tv182 = v50._version + 1;\n\tv50._version = v182;\n\tv183 = v50._size;\n\tv282 = v50._size < v249.Length;\n\tv164 = ~v282;\n\tif (v164) goto L_007D;\n\tv334 = v50._size + 1;\n\tv50._size = v334;\n\tv249[v183 @ X10_v5 (System.Int32)] = v60;\n\tgoto L_007F;\nL_007D:\n\tSystem.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>::AddWithResize(v50, v60);\nL_007F:\n\tv223 = new CodeStage.AntiCheat.Genuine.CodeHash.FileFilter();\n\tSystem.Object::.ctor(v223);\n\tv223.filterExtension = \"so\";\n\tv223.filterFileName = \"libunity\";\n\tv251 = v50._items;\n\tv184 = v50._version + 1;\n\tv50._version = v184;\n\tv185 = v50._size;\n\tv366 = v50._size < v251.Length;\n\tv165 = ~v366;\n\tif (v165) goto L_00AB;\n\tv370 = v50._size + 1;\n\tv50._size = v370;\n\tv251[v185 @ X10_v8 (System.Int32)] = v223;\n\tgoto L_00AD;\nL_00AB:\n\tSystem.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>::AddWithResize(v50, v223);\nL_00AD:\n\tv224 = new CodeStage.AntiCheat.Genuine.CodeHash.FileFilter();\n\tSystem.Object::.ctor(v224);\n\tv224.filterExtension = \"so\";\n\tv224.filterFileName = \"libil2cpp\";\n\tv253 = v50._items;\n\tv186 = v50._version + 1;\n\tv50._version = v186;\n\tv187 = v50._size;\n\tv388 = v50._size < v253.Length;\n\tv166 = ~v388;\n\tif (v166) goto L_00D7;\n\tv389 = v50._size + 1;\n\tv50._size = v389;\n\tv253[v187 @ X10_v11 (System.Int32)] = v224;\n\tgoto L_00D9;\nL_00D7:\n\tSystem.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>::AddWithResize(v50, v224);\nL_00D9:\n\tv225 = new CodeStage.AntiCheat.Genuine.CodeHash.FileFilter();\n\tSystem.Object::.ctor(v225);\n\tv225.filterExtension = \"so\";\n\tv225.filterFileName = \"libmain\";\n\tv255 = v50._items;\n\tv188 = v50._version + 1;\n\tv50._version = v188;\n\tv189 = v50._size;\n\tv405 = v50._size < v255.Length;\n\tv167 = ~v405;\n\tif (v167) goto L_0103;\n\tv406 = v50._size + 1;\n\tv50._size = v406;\n\tv255[v189 @ X10_v14 (System.Int32)] = v225;\n\tgoto L_0105;\nL_0103:\n\tSystem.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>::AddWithResize(v50, v225);\nL_0105:\n\tv226 = new CodeStage.AntiCheat.Genuine.CodeHash.FileFilter();\n\tSystem.Object::.ctor(v226);\n\tv226.filterExtension = \"so\";\n\tv226.filterFileName = \"libMonoPosixHelper\";\n\tv257 = v50._items;\n\tv190 = v50._version + 1;\n\tv50._version = v190;\n\tv191 = v50._size;\n\tv422 = v50._size < v257.Length;\n\tv168 = ~v422;\n\tif (v168) goto L_012F;\n\tv423 = v50._size + 1;\n\tv50._size = v423;\n\tv257[v191 @ X10_v17 (System.Int32)] = v226;\n\tgoto L_0131;\nL_012F:\n\tSystem.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>::AddWithResize(v50, v226);\nL_0131:\n\tv227 = new CodeStage.AntiCheat.Genuine.CodeHash.FileFilter();\n\tSystem.Object::.ctor(v227);\n\tv227.filterExtension = \"so\";\n\tv227.filterFileName = \"libmonobdwgc\";\n\tv259 = v50._items;\n\tv192 = v50._version + 1;\n\tv50._version = v192;\n\tv193 = v50._size;\n\tv439 = v50._size < v259.Length;\n\tv169 = ~v439;\n\tif (v169) goto L_015B;\n\tv440 = v50._size + 1;\n\tv50._size = v440;\n\tv259[v193 @ X10_v20 (System.Int32)] = v227;\n\tgoto L_015D;\nL_015B:\n\tSystem.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>::AddWithResize(v50, v227);\nL_015D:\n\tv228 = new CodeStage.AntiCheat.Genuine.CodeHash.FileFilter();\n\tSystem.Object::.ctor(v228);\n\tv228.filterExtension = \"dat\";\n\tv228.filterFileName = \"global-metadata\";\n\tv261 = v50._items;\n\tv194 = v50._version + 1;\n\tv50._version = v194;\n\tv195 = v50._size;\n\tv458 = v50._size < v261.Length;\n\tv170 = ~v458;\n\tif (v170) goto L_018C;\n\tv459 = v50._size + 1;\n\tv50._size = v459;\n\tv261[v195 @ X10_v24 (System.Int32)] = v228;\n\tv463 = il2Cpp == 0;\n\tif (v463) goto L_0192;\n\tgoto L_01C7;\nL_018C:\n\tSystem.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>::AddWithResize(v50, v228);\n\tv475 = il2Cpp == 0;\n\tv472 = ~v475;\n\tif (v472) goto L_01C7;\nL_0192:\n\tv229 = new CodeStage.AntiCheat.Genuine.CodeHash.FileFilter();\n\tSystem.Object::.ctor(v229);\n\tv229.filterExtension = \"dll\";\n\tv263 = v50._items;\n\tv196 = v50._version + 1;\n\tv50._version = v196;\n\tv487 = v50._size;\n\tv503 = v50._size < v263.Length;\n\tv485 = ~v503;\n\tif (v485) goto L_01BA;\n\tv488 = v50._size + 1;\n\tv50._size = v488;\n\tv263[v487 @ X10_v28 (System.Int32)] = v229;\n\tgoto L_01C7;\nL_01BA:\n\tSystem.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>::AddWithResize(v50, v229);\nL_01C7:\n\treturnVal2 = System.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>::ToArray(v50);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 286 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static FileFilter[] GetFileFiltersAndroid(bool il2Cpp)
		{
			List<FileFilter> list = new List<FileFilter>();
			FileFilter fileFilter = new FileFilter();
			fileFilter.filterExtension = "dex";
			fileFilter.filterFileName = "classes";
			FileFilter[] items = list._items;
			int version = list._version + 1;
			list._version = version;
			int count = list.Count;
			if (list.Count < items.Length)
			{
				int size = list.Count + 1;
				list._size = size;
				items[count] = fileFilter;
			}
			else
			{
				list.Add(fileFilter);
			}
			FileFilter fileFilter2 = new FileFilter();
			fileFilter2.filterExtension = "so";
			fileFilter2.filterFileName = "libunity";
			FileFilter[] items2 = list._items;
			int version2 = list._version + 1;
			list._version = version2;
			int count2 = list.Count;
			if (list.Count < items2.Length)
			{
				int size2 = list.Count + 1;
				list._size = size2;
				items2[count2] = fileFilter2;
			}
			else
			{
				list.Add(fileFilter2);
			}
			FileFilter fileFilter3 = new FileFilter();
			fileFilter3.filterExtension = "so";
			fileFilter3.filterFileName = "libil2cpp";
			FileFilter[] items3 = list._items;
			int version3 = list._version + 1;
			list._version = version3;
			int count3 = list.Count;
			if (list.Count < items3.Length)
			{
				int size3 = list.Count + 1;
				list._size = size3;
				items3[count3] = fileFilter3;
			}
			else
			{
				list.Add(fileFilter3);
			}
			FileFilter fileFilter4 = new FileFilter();
			fileFilter4.filterExtension = "so";
			fileFilter4.filterFileName = "libmain";
			FileFilter[] items4 = list._items;
			int version4 = list._version + 1;
			list._version = version4;
			int count4 = list.Count;
			if (list.Count < items4.Length)
			{
				int size4 = list.Count + 1;
				list._size = size4;
				items4[count4] = fileFilter4;
			}
			else
			{
				list.Add(fileFilter4);
			}
			FileFilter fileFilter5 = new FileFilter();
			fileFilter5.filterExtension = "so";
			fileFilter5.filterFileName = "libMonoPosixHelper";
			FileFilter[] items5 = list._items;
			int version5 = list._version + 1;
			list._version = version5;
			int count5 = list.Count;
			if (list.Count < items5.Length)
			{
				int size5 = list.Count + 1;
				list._size = size5;
				items5[count5] = fileFilter5;
			}
			else
			{
				list.Add(fileFilter5);
			}
			FileFilter fileFilter6 = new FileFilter();
			fileFilter6.filterExtension = "so";
			fileFilter6.filterFileName = "libmonobdwgc";
			FileFilter[] items6 = list._items;
			int version6 = list._version + 1;
			list._version = version6;
			int count6 = list.Count;
			if (list.Count < items6.Length)
			{
				int size6 = list.Count + 1;
				list._size = size6;
				items6[count6] = fileFilter6;
			}
			else
			{
				list.Add(fileFilter6);
			}
			FileFilter fileFilter7 = new FileFilter();
			fileFilter7.filterExtension = "dat";
			fileFilter7.filterFileName = "global-metadata";
			FileFilter[] items7 = list._items;
			int version7 = list._version + 1;
			list._version = version7;
			int count7 = list.Count;
			if (list.Count < items7.Length)
			{
				int size7 = list.Count + 1;
				list._size = size7;
				items7[count7] = fileFilter7;
				if (!il2Cpp)
				{
					goto IL_0660;
				}
			}
			else
			{
				list.Add(fileFilter7);
				if (!il2Cpp)
				{
					goto IL_0660;
				}
			}
			goto IL_0732;
			IL_0732:
			return list.ToArray();
			IL_0660:
			FileFilter fileFilter8 = new FileFilter();
			fileFilter8.filterExtension = "dll";
			FileFilter[] items8 = list._items;
			int version8 = list._version + 1;
			list._version = version8;
			int count8 = list.Count;
			if (list.Count < items8.Length)
			{
				int size8 = list.Count + 1;
				list._size = size8;
				items8[count8] = fileFilter8;
			}
			else
			{
				list.Add(fileFilter8);
			}
			goto IL_0732;
		}

		[Token(Token = "0x600034C")]
		[Address(RVA = "0xBE93C8", Offset = "0xBE93C8", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv22 = CodeStage.AntiCheat.Genuine.CodeHash.FileFilter;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv62 = System.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv66 = \"exe\";\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv132 = \"dll\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v132, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv43 = 1;\n\t*([1A35509]) = v43;\nL_002A:\n\tv45 = new System.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>();\n\tSystem.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>::.ctor(v45);\n\tv55 = new CodeStage.AntiCheat.Genuine.CodeHash.FileFilter();\n\tSystem.Object::.ctor(v55);\n\tv55.filterExtension = \"dll\";\n\tv123 = v45._items;\n\tv111 = v45._version + 1;\n\tv45._version = v111;\n\tv112 = v45._size;\n\tv135 = v45._size < v123.Length;\n\tv100 = ~v135;\n\tif (v100) goto L_005B;\n\tv179 = v45._size + 1;\n\tv45._size = v179;\n\tv123[v112 @ X10_v4 (System.Int32)] = v55;\n\tgoto L_005D;\nL_005B:\n\tSystem.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>::AddWithResize(v45, v55);\nL_005D:\n\tv117 = new CodeStage.AntiCheat.Genuine.CodeHash.FileFilter();\n\tSystem.Object::.ctor(v117);\n\tv117.filterExtension = \"exe\";\n\tv125 = v45._items;\n\tv113 = v45._version + 1;\n\tv45._version = v113;\n\tv163 = v45._size;\n\tv196 = v45._size < v125.Length;\n\tv157 = ~v196;\n\tif (v157) goto L_0087;\n\tv197 = v45._size + 1;\n\tv45._size = v197;\n\tv125[v163 @ X10_v7 (System.Int32)] = v117;\n\tgoto L_0090;\nL_0087:\n\tSystem.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>::AddWithResize(v45, v117);\nL_0090:\n\treturnVal2 = System.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileFilter>::ToArray(v45);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static FileFilter[] GetFileFiltersStandaloneWindows(bool il2Cpp)
		{
			List<FileFilter> list = new List<FileFilter>();
			FileFilter fileFilter = new FileFilter();
			fileFilter.filterExtension = "dll";
			FileFilter[] items = list._items;
			int version = list._version + 1;
			list._version = version;
			int count = list.Count;
			if (list.Count < items.Length)
			{
				int size = list.Count + 1;
				list._size = size;
				items[count] = fileFilter;
			}
			else
			{
				list.Add(fileFilter);
			}
			FileFilter fileFilter2 = new FileFilter();
			fileFilter2.filterExtension = "exe";
			FileFilter[] items2 = list._items;
			int version2 = list._version + 1;
			list._version = version2;
			int count2 = list.Count;
			if (list.Count < items2.Length)
			{
				int size2 = list.Count + 1;
				list._size = size2;
				items2[count2] = fileFilter2;
			}
			else
			{
				list.Add(fileFilter2);
			}
			return list.ToArray();
		}

		[Token(Token = "0x600034D")]
		[Address(RVA = "0xBE9590", Offset = "0xBE9590", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator::Generate();\n\treturn returnVal1;\n")]
		ICodeHashGenerator ICodeHashGenerator.Generate()
		{
			return Generate();
		}

		[Token(Token = "0x600034E")]
		[Address(RVA = "0xBE9594", Offset = "0xBE9594", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = Il2CppMethodInfo;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A3550A]) = v42;\nL_001B:\n\tCodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator>::OnDestroy(this);\n\tv52.HashGenerated = 0;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnDestroy()
		{
			base.OnDestroy();
			CodeHashGenerator.HashGenerated = null;
		}

		[Token(Token = "0x600034F")]
		[Address(RVA = "0xBE9608", Offset = "0xBE9608", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = \"CodeHashGenerator\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3550B]) = v34;\nL_0016:\n\treturn \"CodeHashGenerator\";\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override string GetComponentName()
		{
			return "CodeHashGenerator";
		}

		[Token(Token = "0x6000350")]
		[Address(RVA = "0xBE8D6C", Offset = "0xBE8D6C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3550C]) = v34;\nL_0014:\n\tv36 = this.<LastResult>k__BackingField == 0;\n\tif (v36) goto L_0022;\n\tv44 = v42.HashGenerated == 0;\n\tif (v44) goto L_003D;\n\tCodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResultHandler::Invoke(v42.HashGenerated, this.<LastResult>k__BackingField);\n\tgoto L_003D;\nL_0022:\n\tthis.currentWorker = 0;\n\tv48 = new CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker();\n\tCodeStage.AntiCheat.Genuine.CodeHash.BaseWorker::.ctor(v48);\n\tthis.currentWorker = v48;\n\tv63 = v48 == 0;\n\tif (v63) goto L_003E;\n\tv85 = CodeStage.AntiCheat.Genuine.CodeHash.AndroidWorker::Execute(v48);\n\tv87 = CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator::CalculationAwaiter(this);\n\tv61 = UnityEngine.MonoBehaviour::StartCoroutine(this, v87);\nL_003D:\n\treturn this;\nL_003E:\n\tthrow v48;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private ICodeHashGenerator GenerateInternal()
		{
			if (LastResult != null)
			{
				if (CodeHashGenerator.HashGenerated != null)
				{
					CodeHashGenerator.HashGenerated(LastResult);
				}
			}
			else
			{
				currentWorker = null;
				AndroidWorker androidWorker = (AndroidWorker)(currentWorker = new BaseWorker());
				if (androidWorker == null)
				{
					throw androidWorker;
				}
				androidWorker.Execute();
				IEnumerator routine = CalculationAwaiter();
				Coroutine coroutine = StartCoroutine(routine);
			}
			return this;
		}

		[IteratorStateMachine(typeof(_003CCalculationAwaiter_003Ed__20))]
		[Token(Token = "0x6000351")]
		[Address(RVA = "0xBE9650", Offset = "0xBE9650", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator+<CalculationAwaiter>d__20;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3550D]) = v37;\nL_0014:\n\tv39 = new CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator+<CalculationAwaiter>d__20();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator CalculationAwaiter()
		{
			_003CCalculationAwaiter_003Ed__20 _003CCalculationAwaiter_003Ed__21 = null;
			_003CCalculationAwaiter_003Ed__21._003C_003E1__state = 0;
			_003CCalculationAwaiter_003Ed__21._003C_003E4__this = this;
			return _003CCalculationAwaiter_003Ed__21;
		}

		[Token(Token = "0x6000352")]
		[Address(RVA = "0xBE96D8", Offset = "0xBE96D8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = UnityEngine.WaitForSeconds;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A3550E]) = v42;\nL_001A:\n\tv44 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v44, 0.3f);\n\tthis.cachedWaitForSeconds = v44;\n\tCodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Genuine.CodeHash.CodeHashGenerator>::.ctor(this);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CodeHashGenerator()
		{
			WaitForSeconds waitForSeconds = new WaitForSeconds(0.3f);
			cachedWaitForSeconds = waitForSeconds;
		}
	}
}
