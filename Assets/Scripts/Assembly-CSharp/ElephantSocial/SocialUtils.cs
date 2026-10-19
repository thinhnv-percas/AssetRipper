using System;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using ElephantSocial.Tournament.Model;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace ElephantSocial
{
	[Token(Token = "0x2000825")]
	public class SocialUtils
	{
		[Token(Token = "0x6002313")]
		[Address(RVA = "0x3DDC428", Offset = "0x3DDC428", Length = "0x208")]
		public static TournamentErrorResponse GetTournamentErrorResponse(UnityWebRequest request)
		{
			//IL_00a2: Expected I8, but got I4
			UnityWebRequest unityWebRequest = default(UnityWebRequest);
			NullReferenceException ex;
			if (unityWebRequest != null)
			{
				DownloadHandler downloadHandler = unityWebRequest.downloadHandler;
				if (downloadHandler != null)
				{
					string text = downloadHandler.text;
					TournamentErrorResponse tournamentErrorResponse = JsonConvert.DeserializeObject<TournamentErrorResponse>(text);
					if (tournamentErrorResponse == null)
					{
						tournamentErrorResponse = (TournamentErrorResponse)FormatterServices.GetUninitializedObject(typeof(TournamentErrorResponse));
						tournamentErrorResponse.Message = "Error code is null";
						tournamentErrorResponse.ErrorCode = 0L;
					}
					return tournamentErrorResponse;
				}
				ex = new NullReferenceException();
			}
			else
			{
				ex = new NullReferenceException();
			}
			throw ex;
		}

		[Token(Token = "0x6002314")]
		[Address(RVA = "0x3DDC674", Offset = "0x3DDC674", Length = "0x8")]
		public SocialUtils()
		{
		}
	}
}
