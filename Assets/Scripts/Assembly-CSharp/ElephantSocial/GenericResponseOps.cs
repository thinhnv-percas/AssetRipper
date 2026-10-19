using System;
using Cpp2ILInjected;
using ElephantSDK;
using ElephantSocial.Tournament.Model;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace ElephantSocial
{
	[Token(Token = "0x2000817")]
	public abstract class GenericResponseOps
	{
		[Token(Token = "0x17000355")]
		internal ElephantEnvironment ElephantEnvironment
		{
			[Token(Token = "0x6002277")]
			[Address(RVA = "0x3DD50A4", Offset = "0x3DD50A4", Length = "0xFC")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GenericResponseOps::get_ElephantEnvironment");
				return default;
			}
		}

		[Token(Token = "0x6002278")]
		[Address(RVA = "0x3DD5250", Offset = "0x3DD5250", Length = "0x1C")]
		protected internal bool IsProductionEnvironment()
		{
			ElephantEnvironment elephantEnvironment = ElephantEnvironment;
			int num = (int)(elephantEnvironment - 1);
			return num == 0;
		}

		[Token(Token = "0x6002279")]
		[Address(RVA = "0x49833D4", Offset = "0x49833D4", Length = "0x88")]
		protected internal string PrepareBodyJson<T>(T data)
		{
			return JsonConvert.SerializeObject(data);
		}

		[Token(Token = "0x600227A")]
		[Address(RVA = "0x4983120", Offset = "0x4983120", Length = "0xCC")]
		protected internal static void HandleResponse<T>(GenericResponse<T> response, Action<T> onResponse, Action<string> onError)
		{
			//IL_0149: Expected O, but got I
			//IL_0159: Expected O, but got I
			//IL_0169: Expected O, but got I
			if (response != null)
			{
				if (response.responseCode != 201)
				{
					if (response.responseCode == 200)
					{
						if (onResponse == null)
						{
							return;
						}
						object obj = onResponse;
					}
					else
					{
						if (onError == null)
						{
							return;
						}
						string errorMessage = response.errorMessage;
						object obj = onError;
					}
				}
				else
				{
					if (onResponse == null)
					{
						return;
					}
					string errorMessage = null;
					object obj = onResponse;
				}
			}
			else
			{
				string errorMessage = "Response is null";
				object obj = onError;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X19_v2+18]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X19_v2+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X19_v2+28]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v132 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600227B")]
		[Address(RVA = "0x3DD526C", Offset = "0x3DD526C", Length = "0x4C")]
		protected internal static void HandleErrorResponse(UnityWebRequest request, Action<long, string> error)
		{
			TournamentErrorResponse tournamentErrorResponse = SocialUtils.GetTournamentErrorResponse(request);
			error?.Invoke(tournamentErrorResponse.ErrorCode, tournamentErrorResponse.Message);
		}

		[Token(Token = "0x600227C")]
		[Address(RVA = "0x3DD52B8", Offset = "0x3DD52B8", Length = "0x8")]
		protected internal GenericResponseOps()
		{
		}
	}
}
