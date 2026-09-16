using System;
using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity.Gameroom
{
	[Token(Token = "0x200004F")]
	internal class GameroomFacebookGameObject : FacebookGameObject, IFacebookCallbackHandler
	{
		[Token(Token = "0x17000069")]
		protected IGameroomFacebookImplementation GameroomFacebookImpl
		{
			[Token(Token = "0x60001CC")]
			[Address(RVA = "0xD2FF70", Offset = "0xD2FF70", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EF3B38]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C46]) = v38;\nL_0014:\n\tv40 = this.<Facebook>k__BackingField == 0;\n\tif (v40) goto L_FFFFFFFF;\n\t// 27 IsInst returnVal1 @ X0_v2 (Facebook.Unity.Gameroom.IGameroomFacebookImplementation), typeof(Facebook.Unity.Gameroom.IGameroomFacebookImplementation), this.<Facebook>k__BackingField (Facebook.Unity.IFacebookImplementation)\n\tv56 = returnVal1 == 0;\n\tv52 = ~v56;\n\tif (v52) goto L_0028;\n\tthrow System.InvalidCastException;\nL_0028:\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				IGameroomFacebookImplementation gameroomFacebookImplementation;
				if (Facebook != null)
				{
					gameroomFacebookImplementation = Facebook as IGameroomFacebookImplementation;
					if (gameroomFacebookImplementation == null)
					{
						throw new InvalidCastException();
					}
				}
				else
				{
					gameroomFacebookImplementation = null;
				}
				return gameroomFacebookImplementation;
			}
		}

		[Token(Token = "0x60001CD")]
		[Address(RVA = "0xD2FFE4", Offset = "0xD2FFE4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = Facebook.Unity.Gameroom.GameroomFacebookGameObject::WaitForPipeResponse(this, onCompleteDelegate, callbackId);\n\tv20 = UnityEngine.MonoBehaviour::StartCoroutine(this, v10);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void WaitForResponse(GameroomFacebook.OnComplete onCompleteDelegate, string callbackId)
		{
			IEnumerator routine = WaitForPipeResponse(onCompleteDelegate, callbackId);
			Coroutine coroutine = StartCoroutine(routine);
		}

		[Token(Token = "0x60001CE")]
		[Address(RVA = "0xD30098", Offset = "0xD30098", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected override void OnAwake()
		{
		}

		[Token(Token = "0x60001CF")]
		[Address(RVA = "0xD30010", Offset = "0xD30010", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1ED9D30]);\n\tv27 = *([v26 @ X8_v6]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, onCompleteDelegate, callbackId, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C47]) = v44;\nL_001A:\n\tv48 = new Facebook.Unity.Gameroom.GameroomFacebookGameObject+<WaitForPipeResponse>d__4();\n\tSystem.Object::.ctor(v48);\n\tv48.<>1__state = 0;\n\tv48.<>4__this = this;\n\tv48.onCompleteDelegate = onCompleteDelegate;\n\tv48.callbackId = callbackId;\n\treturn v48;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator WaitForPipeResponse(GameroomFacebook.OnComplete onCompleteDelegate, string callbackId)
		{
			_003CWaitForPipeResponse_003Ed__4 _003CWaitForPipeResponse_003Ed__5 = null;
			_003CWaitForPipeResponse_003Ed__5._003C_003E1__state = 0;
			_003CWaitForPipeResponse_003Ed__5._003C_003E4__this = this;
			_003CWaitForPipeResponse_003Ed__5.onCompleteDelegate = onCompleteDelegate;
			_003CWaitForPipeResponse_003Ed__5.callbackId = callbackId;
			return _003CWaitForPipeResponse_003Ed__5;
		}

		[Token(Token = "0x60001D0")]
		[Address(RVA = "0xD300C8", Offset = "0xD300C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameroomFacebookGameObject()
		{
		}
	}
}
