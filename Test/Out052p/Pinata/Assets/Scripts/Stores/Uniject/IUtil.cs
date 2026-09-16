using System;
using System.Collections;
using Cpp2ILInjected;
using UnityEngine;

namespace Uniject
{
	[Token(Token = "0x2000002")]
	internal interface IUtil
	{
		[Token(Token = "0x17000001")]
		RuntimePlatform platform
		{
			[Token(Token = "0x6000001")]
			get;
		}

		[Token(Token = "0x17000002")]
		string persistentDataPath
		{
			[Token(Token = "0x6000002")]
			get;
		}

		[Token(Token = "0x17000003")]
		string cloudProjectId
		{
			[Token(Token = "0x6000003")]
			get;
		}

		[Token(Token = "0x17000004")]
		string deviceUniqueIdentifier
		{
			[Token(Token = "0x6000004")]
			get;
		}

		[Token(Token = "0x17000005")]
		string unityVersion
		{
			[Token(Token = "0x6000005")]
			get;
		}

		[Token(Token = "0x17000006")]
		string userId
		{
			[Token(Token = "0x6000006")]
			get;
		}

		[Token(Token = "0x17000007")]
		string gameVersion
		{
			[Token(Token = "0x6000007")]
			get;
		}

		[Token(Token = "0x17000008")]
		ulong sessionId
		{
			[Token(Token = "0x6000008")]
			get;
		}

		[Token(Token = "0x17000009")]
		string operatingSystem
		{
			[Token(Token = "0x6000009")]
			get;
		}

		[Token(Token = "0x1700000A")]
		int screenWidth
		{
			[Token(Token = "0x600000A")]
			get;
		}

		[Token(Token = "0x1700000B")]
		int screenHeight
		{
			[Token(Token = "0x600000B")]
			get;
		}

		[Token(Token = "0x1700000C")]
		float screenDpi
		{
			[Token(Token = "0x600000C")]
			get;
		}

		[Token(Token = "0x1700000D")]
		string screenOrientation
		{
			[Token(Token = "0x600000D")]
			get;
		}

		[Token(Token = "0x600000E")]
		object InitiateCoroutine(IEnumerator start);

		[Token(Token = "0x600000F")]
		void InitiateCoroutine(IEnumerator start, int delayInSeconds);

		[Token(Token = "0x6000010")]
		void RunOnMainThread(Action runnable);

		[Token(Token = "0x6000011")]
		void AddPauseListener(Action<bool> runnable);

		[Token(Token = "0x6000012")]
		bool IsClassOrSubclass(Type potentialBase, Type potentialDescendant);
	}
}
