using System;
using Cpp2ILInjected;

namespace Mycom.Tracker.Unity.Internal.Interfaces
{
	[Token(Token = "0x200000B")]
	internal interface ITrackerParams : IDisposable
	{
		[Token(Token = "0x600005D")]
		int GetAge();

		[Token(Token = "0x600005E")]
		int GetBufferingPeriod();

		[Token(Token = "0x600005F")]
		string[] GetCustomUserIds();

		[Token(Token = "0x6000060")]
		string[] GetEmails();

		[Token(Token = "0x6000061")]
		int GetForcingPeriod();

		[Token(Token = "0x6000062")]
		GenderEnum GetGender();

		[Token(Token = "0x6000063")]
		string[] GetIcqIds();

		[Token(Token = "0x6000064")]
		string GetId();

		[Token(Token = "0x6000065")]
		string GetLang();

		[Token(Token = "0x6000066")]
		int GetLaunchTimeout();

		[Token(Token = "0x6000067")]
		string GetMrgsAppId();

		[Token(Token = "0x6000068")]
		string GetMrgsId();

		[Token(Token = "0x6000069")]
		string GetMrgsUserId();

		[Token(Token = "0x600006A")]
		string[] GetOkIds();

		[Token(Token = "0x600006B")]
		string[] GetPhones();

		[Token(Token = "0x600006C")]
		string[] GetVkIds();

		[Token(Token = "0x600006D")]
		bool IsTrackingEnvironmentEnabled();

		[Token(Token = "0x600006E")]
		bool IsTrackingLaunchEnabled();

		[Token(Token = "0x600006F")]
		bool IsTrackingLocationEnabled();

		[Token(Token = "0x6000070")]
		void SetAge(int value);

		[Token(Token = "0x6000071")]
		void SetBufferingPeriod(int value);

		[Token(Token = "0x6000072")]
		void SetCustomUserIds(string[] value);

		[Token(Token = "0x6000073")]
		void SetEmails(string[] value);

		[Token(Token = "0x6000074")]
		void SetForcingPeriod(int value);

		[Token(Token = "0x6000075")]
		void SetGender(GenderEnum value);

		[Token(Token = "0x6000076")]
		void SetRegion(RegionEnum value);

		[Token(Token = "0x6000077")]
		void SetIcqIds(string[] value);

		[Token(Token = "0x6000078")]
		void SetLang(string value);

		[Token(Token = "0x6000079")]
		void SetLaunchTimeout(int value);

		[Token(Token = "0x600007A")]
		void SetMrgsAppId(string value);

		[Token(Token = "0x600007B")]
		void SetMrgsId(string value);

		[Token(Token = "0x600007C")]
		void SetMrgsUserId(string value);

		[Token(Token = "0x600007D")]
		void SetOkIds(string[] value);

		[Token(Token = "0x600007E")]
		void SetPhones(string[] value);

		[Token(Token = "0x600007F")]
		void SetTrackingEnvironmentEnabled(bool value);

		[Token(Token = "0x6000080")]
		void SetTrackingLaunchEnabled(bool value);

		[Token(Token = "0x6000081")]
		void SetTrackingLocationEnabled(bool value);

		[Token(Token = "0x6000082")]
		void SetVkIds(string[] value);

		[Token(Token = "0x6000083")]
		void SetProxyHost(string value);
	}
}
