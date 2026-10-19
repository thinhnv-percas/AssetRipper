using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.Ui.CustomButtons
{
	[Token(Token = "0x2000565")]
	public class SystemScreenshotDetector : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x4001276")]
		internal static Action OnScreenshotDetected;

		[Token(Token = "0x4001277")]
		private static SystemScreenshotDetector s_instance;

		[CompilerGenerated]
		[Token(Token = "0x60016A0")]
		[Address(RVA = "0x3D1E9DC", Offset = "0x3D1E9DC", Length = "0xC0")]
		public static void add_OnScreenshotDetected(Action value)
		{
			Action action = OnScreenshotDetected;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnScreenshotDetected, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60016A1")]
		[Address(RVA = "0x3D1EBAC", Offset = "0x3D1EBAC", Length = "0xC0")]
		public static void remove_OnScreenshotDetected(Action value)
		{
			Action action = OnScreenshotDetected;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnScreenshotDetected, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x60016A2")]
		[Address(RVA = "0x3D1F520", Offset = "0x3D1F520", Length = "0x160")]
		private void Awake()
		{
			if (s_instance != null)
			{
				GameObject obj = base.gameObject;
				UnityEngine.Object.Destroy(obj);
			}
			else
			{
				s_instance = this;
				GameObject target = base.gameObject;
				UnityEngine.Object.DontDestroyOnLoad(target);
			}
		}

		[Token(Token = "0x60016A3")]
		[Address(RVA = "0x3D1F680", Offset = "0x3D1F680", Length = "0x40")]
		private void Start()
		{
			GameObject gameObject = base.gameObject;
			string text = gameObject.name;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @56E00");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
		}

		[Token(Token = "0x60016A4")]
		[Address(RVA = "0x3D1F700", Offset = "0x3D1F700", Length = "0x4")]
		private void OnDestroy()
		{
		}

		[Token(Token = "0x60016A5")]
		[Address(RVA = "0x3D1F704", Offset = "0x3D1F704", Length = "0x68")]
		public void NativeScreenshotTaken(string _)
		{
			if (OnScreenshotDetected != null)
			{
				OnScreenshotDetected();
			}
		}

		[DllImport("__Internal")]
		[Token(Token = "0x60016A6")]
		[Address(RVA = "0x3D1F76C", Offset = "0x3D1F76C", Length = "0x28")]
		private static extern void _RegisterScreenshotDetector(string gameObjectName);

		[Token(Token = "0x60016A7")]
		[Address(RVA = "0x3D1F6C0", Offset = "0x3D1F6C0", Length = "0x40")]
		private void RegisterIOSCallback()
		{
			GameObject gameObject = base.gameObject;
			string text = gameObject.name;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1814");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @56E00");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1828");
		}

		[Token(Token = "0x60016A8")]
		[Address(RVA = "0x3D1F794", Offset = "0x3D1F794", Length = "0x8")]
		public SystemScreenshotDetector()
		{
		}
	}
}
