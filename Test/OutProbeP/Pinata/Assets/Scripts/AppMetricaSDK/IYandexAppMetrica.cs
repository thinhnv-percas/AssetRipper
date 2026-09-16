using System;
using System.Collections.Generic;
using Cpp2ILInjected;

[Token(Token = "0x2000005")]
public interface IYandexAppMetrica
{
	[Token(Token = "0x17000005")]
	YandexAppMetricaConfig? ActivationConfig
	{
		[Token(Token = "0x6000027")]
		get;
	}

	[Token(Token = "0x17000006")]
	string LibraryVersion
	{
		[Token(Token = "0x6000030")]
		get;
	}

	[Token(Token = "0x17000007")]
	int LibraryApiLevel
	{
		[Token(Token = "0x6000031")]
		get;
	}

	[Token(Token = "0x14000002")]
	event ConfigUpdateHandler OnActivation;

	[Token(Token = "0x6000028")]
	void ActivateWithConfiguration(YandexAppMetricaConfig config);

	[Token(Token = "0x6000029")]
	void ResumeSession();

	[Token(Token = "0x600002A")]
	void PauseSession();

	[Token(Token = "0x600002B")]
	void ReportEvent(string message);

	[Token(Token = "0x600002C")]
	void ReportEvent(string message, Dictionary<string, object> parameters);

	[Token(Token = "0x600002D")]
	void ReportError(string condition, string stackTrace);

	[Token(Token = "0x600002E")]
	void SetLocationTracking(bool enabled);

	[Token(Token = "0x600002F")]
	void SetLocation(YandexAppMetricaConfig.Coordinates? coordinates);

	[Token(Token = "0x6000032")]
	void SetUserProfileID(string userProfileID);

	[Token(Token = "0x6000033")]
	void ReportUserProfile(YandexAppMetricaUserProfile userProfile);

	[Token(Token = "0x6000034")]
	void ReportRevenue(YandexAppMetricaRevenue revenue);

	[Token(Token = "0x6000035")]
	void SetStatisticsSending(bool enabled);

	[Token(Token = "0x6000036")]
	void SendEventsBuffer();

	[Token(Token = "0x6000037")]
	void RequestAppMetricaDeviceID(Action<string, YandexAppMetricaRequestDeviceIDError?> action);
}
