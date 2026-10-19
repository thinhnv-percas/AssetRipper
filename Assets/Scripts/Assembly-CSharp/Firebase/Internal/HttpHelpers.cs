using System;
using System.Collections;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Cpp2ILInjected;
using UnityEngine;

namespace Firebase.Internal
{
	[Token(Token = "0x2000812")]
	internal static class HttpHelpers
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000813")]
		private struct _003CSetRequestHeaders_003Ed__0 : IAsyncStateMachine
		{
			[Token(Token = "0x4001B21")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001B22")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001B23")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public HttpRequestMessage request;

			[Token(Token = "0x4001B24")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public FirebaseApp firebaseApp;

			[Token(Token = "0x4001B25")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private TaskAwaiter _003C_003Eu__1;

			[Token(Token = "0x6002271")]
			[Address(RVA = "0x3DD43B0", Offset = "0x3DD43B0", Length = "0x4E8")]
			private void MoveNext()
			{
				NullReferenceException ex;
				if (_003C_003E1__state != 0)
				{
					if (request != null)
					{
						HttpRequestHeaders headers = request.Headers;
						if (firebaseApp != null)
						{
							AppOptions options = firebaseApp.Options;
							if (options != null)
							{
								if (headers != null)
								{
									headers.Add("x-goog-api-key", options.ApiKey);
									if (FirebaseInterops._sdkVersionFetcher != null)
									{
										string value = FirebaseInterops._sdkVersionFetcher.Value;
										if (request != null)
										{
											HttpRequestHeaders headers2 = request.Headers;
											string value2 = "gl-csharp/8.0 fire/" + value;
											if (headers2 != null)
											{
												headers2.Add("x-goog-api-client", value2);
												if (!FirebaseInterops.GetIsDataCollectionDefaultEnabled(firebaseApp))
												{
													goto IL_0263;
												}
												if (request != null)
												{
													HttpRequestHeaders headers3 = request.Headers;
													if (firebaseApp != null)
													{
														AppOptions options2 = firebaseApp.Options;
														if (options2 != null)
														{
															if (headers3 != null)
															{
																headers3.Add("X-Firebase-AppId", options2.AppId);
																if (request != null)
																{
																	HttpRequestHeaders headers4 = request.Headers;
																	string version = Application.version;
																	if (headers4 != null)
																	{
																		headers4.Add("X-Firebase-AppVersion", version);
																		goto IL_0263;
																	}
																	ex = new NullReferenceException();
																}
																else
																{
																	ex = new NullReferenceException();
																}
															}
															else
															{
																ex = new NullReferenceException();
															}
														}
														else
														{
															ex = new NullReferenceException();
														}
													}
													else
													{
														ex = new NullReferenceException();
													}
												}
												else
												{
													ex = new NullReferenceException();
												}
											}
											else
											{
												ex = new NullReferenceException();
											}
										}
										else
										{
											ex = new NullReferenceException();
										}
									}
									else
									{
										ex = new NullReferenceException();
									}
								}
								else
								{
									ex = new NullReferenceException();
								}
							}
							else
							{
								ex = new NullReferenceException();
							}
						}
						else
						{
							ex = new NullReferenceException();
						}
					}
					else
					{
						ex = new NullReferenceException();
					}
					goto IL_0414;
				}
				_003C_003Eu__1 = default(TaskAwaiter);
				_003C_003E1__state = -1;
				TaskAwaiter awaiter = _003C_003Eu__1;
				goto IL_046c;
				IL_0414:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
				return;
				IL_0263:
				Task task = FirebaseInterops.AddFirebaseTokensAsync(request, firebaseApp);
				if (task != null)
				{
					TaskAwaiter awaiter2 = task.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = awaiter;
						_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_046c;
				}
				ex = new NullReferenceException();
				goto IL_0414;
				IL_046c:
				awaiter.GetResult();
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetResult();
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002272")]
			[Address(RVA = "0x3DD4898", Offset = "0x3DD4898", Length = "0x6C")]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_003C_003Et__builder.SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000814")]
		private struct _003CValidateHttpResponse_003Ed__1 : IAsyncStateMachine
		{
			[Token(Token = "0x4001B26")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4001B27")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncTaskMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4001B28")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public HttpResponseMessage response;

			[Token(Token = "0x4001B29")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private TaskAwaiter<string> _003C_003Eu__1;

			[Token(Token = "0x6002273")]
			[Address(RVA = "0x3DD4904", Offset = "0x3DD4904", Length = "0x528")]
			private void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HttpHelpers._003CValidateHttpResponse_003Ed__1::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002274")]
			[Address(RVA = "0x3DD4E2C", Offset = "0x3DD4E2C", Length = "0x6C")]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_003C_003Et__builder.SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[AsyncStateMachine(typeof(_003CSetRequestHeaders_003Ed__0))]
		[Token(Token = "0x600226F")]
		[Address(RVA = "0x3DD41D0", Offset = "0x3DD41D0", Length = "0xFC")]
		internal static Task SetRequestHeaders(HttpRequestMessage request, FirebaseApp firebaseApp)
		{
			AsyncTaskMethodBuilder _003C_003Et__builder = AsyncTaskMethodBuilder.Create();
			_003CSetRequestHeaders_003Ed__0 stateMachine = default(_003CSetRequestHeaders_003Ed__0);
			stateMachine._003C_003Et__builder = _003C_003Et__builder;
			stateMachine.request = request;
			stateMachine.firebaseApp = firebaseApp;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return stateMachine._003C_003Et__builder.Task;
		}

		[AsyncStateMachine(typeof(_003CValidateHttpResponse_003Ed__1))]
		[Token(Token = "0x6002270")]
		[Address(RVA = "0x3DD42CC", Offset = "0x3DD42CC", Length = "0xE4")]
		internal static Task ValidateHttpResponse(HttpResponseMessage response)
		{
			AsyncTaskMethodBuilder _003C_003Et__builder = AsyncTaskMethodBuilder.Create();
			_003CValidateHttpResponse_003Ed__1 stateMachine = default(_003CValidateHttpResponse_003Ed__1);
			stateMachine._003C_003Et__builder = _003C_003Et__builder;
			stateMachine.response = response;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
			return stateMachine._003C_003Et__builder.Task;
		}
	}
}
