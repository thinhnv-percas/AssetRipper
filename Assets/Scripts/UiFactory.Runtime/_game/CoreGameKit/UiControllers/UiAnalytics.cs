using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.UiControllers.ScriptableObjects;

namespace _game.CoreGameKit.UiControllers
{
	[Token(Token = "0x2000005")]
	public class UiAnalytics : IUiAnalytics
	{
		[Inject(false)]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x10")]
		private EventBus _eventBus;

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x81A171C", Offset = "0x81A171C", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_0028:\n\tv61 = System.Reflection.MemberInfo::get_Name(uiControllerType);\n\tv97 = System.String::Concat(\"[Analytics] UI Show: \", v61);\n\tgoto L_0037;\n\tUnco.EventBusSystem.Runtime.EventBus::InvokeEvent(this._eventBus, v70);\n\treturn;\nL_0037:\n\tUnityEngine.Debug::Log(v97);\n")]
		public void TrackUiShow(Type uiControllerType, bool sendToAnalytics = true)
		{
			string name = uiControllerType.Name;
			string message = "[Analytics] UI Show: " + name;
			Debug.Log(message);
			UventUiShown args = default(UventUiShown);
			_eventBus.InvokeEvent(args);
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x81A1820", Offset = "0x81A1820", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_0028:\n\tv61 = System.Reflection.MemberInfo::get_Name(uiControllerType);\n\tv97 = System.String::Concat(\"[Analytics] UI Hide: \", v61);\n\tgoto L_0037;\n\tUnco.EventBusSystem.Runtime.EventBus::InvokeEvent(this._eventBus, v70);\n\treturn;\nL_0037:\n\tUnityEngine.Debug::Log(v97);\n")]
		public void TrackUiHide(Type uiControllerType, bool sendToAnalytics = true)
		{
			string name = uiControllerType.Name;
			string message = "[Analytics] UI Hide: " + name;
			Debug.Log(message);
			UventUiHidden args = default(UventUiHidden);
			_eventBus.InvokeEvent(args);
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x81A1924", Offset = "0x81A1924", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0017;\nL_0017:\n\tv51 = UnityEngine.Object::op_Inequality(config, 0);\n\tv58 = ~v51;\n\tif (v58) goto L_0041;\n\treturn config.UseElephantEvent;\nL_0041:\n\treturn 0;\n")]
		public bool ShouldTrack(UIConfig config)
		{
			if (config != null)
			{
				return config.UseElephantEvent;
			}
			return false;
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x81A19DC", Offset = "0x81A19DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public UiAnalytics()
		{
		}
	}
}
