using System;
using System.Threading;
using Cpp2ILInjected;
using ElephantSDK;
using Reflex.Attributes;
using Unco.TextViewSystem;
using UnityEngine;
using _game.CoreGameKit.CoreSerivces;

namespace _game.CoreGameKit.Ui.CustomButtons
{
	[Token(Token = "0x2000561")]
	public class BuildNumberTextView : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4001268")]
		[FieldOffset(Offset = "0x20")]
		private TextView m_textView;

		[Token(Token = "0x4001269")]
		[FieldOffset(Offset = "0x28")]
		private string _version;

		[Token(Token = "0x400126A")]
		[FieldOffset(Offset = "0x30")]
		private string _elephantId;

		[Inject(false)]
		[Token(Token = "0x6001689")]
		[Address(RVA = "0x3D1E778", Offset = "0x3D1E778", Length = "0x154")]
		private void Inject(AppConfig appConfig)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BuildNumberTextView::Inject");
		}

		[Token(Token = "0x600168A")]
		[Address(RVA = "0x3D1E8CC", Offset = "0x3D1E8CC", Length = "0x110")]
		private void OnEnable()
		{
			Action b = OnScreenshotDetected;
			Delegate obj = SystemScreenshotDetector.OnScreenshotDetected;
			bool flag;
			do
			{
				Delegate obj2 = Delegate.Combine(obj, b);
				if ((object)obj2 == null || (object)obj2.GetType() == typeof(Action))
				{
					Delegate obj3 = Interlocked.CompareExchange(ref SystemScreenshotDetector.OnScreenshotDetected, (Action)obj2, (Action)obj);
					flag = (object)obj3 == obj;
					obj = obj3;
					continue;
				}
				throw new InvalidCastException();
			}
			while (!flag);
		}

		[Token(Token = "0x600168B")]
		[Address(RVA = "0x3D1EA9C", Offset = "0x3D1EA9C", Length = "0x110")]
		private void OnDisable()
		{
			Action value = OnScreenshotDetected;
			Delegate obj = SystemScreenshotDetector.OnScreenshotDetected;
			bool flag;
			do
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if ((object)obj2 == null || (object)obj2.GetType() == typeof(Action))
				{
					Delegate obj3 = Interlocked.CompareExchange(ref SystemScreenshotDetector.OnScreenshotDetected, (Action)obj2, (Action)obj);
					flag = (object)obj3 == obj;
					obj = obj3;
					continue;
				}
				throw new InvalidCastException();
			}
			while (!flag);
		}

		[Token(Token = "0x600168C")]
		[Address(RVA = "0x3D1EC6C", Offset = "0x3D1EC6C", Length = "0x78")]
		private void OnScreenshotDetected()
		{
			string text = _version + " - " + _elephantId;
			TextView textView = default(TextView);
			textView.SetText(text);
		}

		[Token(Token = "0x600168D")]
		[Address(RVA = "0x3D1ECE4", Offset = "0x3D1ECE4", Length = "0x8")]
		public BuildNumberTextView()
		{
		}
	}
}
