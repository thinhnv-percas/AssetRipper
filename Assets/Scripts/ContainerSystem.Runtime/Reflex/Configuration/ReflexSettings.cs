using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Logging;
using UnityEngine;

namespace Reflex.Configuration
{
	[Token(Token = "0x2000039")]
	internal sealed class ReflexSettings : ScriptableObject
	{
		[Token(Token = "0x4000054")]
		private static ReflexSettings _instance;

		[SerializeField]
		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x18")]
		private LogLevel m_logLevel;

		[Token(Token = "0x1700001F")]
		public static LogLevel LogLevel
		{
			[Token(Token = "0x60000C7")]
			[Address(RVA = "0x3F318DC", Offset = "0x3F318DC", Length = "0x188")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv57 = UnityEngine.Object::op_Equality(v23._instance, 0);\n\tv66 = ~v57;\n\tv67 = ~v66;\n\tif (v67) goto L_0059;\n\tv115 = v83._instance;\n\tgoto L_0029;\nL_0029:\n\tv120 = UnityEngine.Object::op_Equality(v115, 0);\n\tv137 = v120 == 0;\n\tif (v137) goto L_0072;\n\treturn 1;\nL_0059:\n\tv100 = UnityEngine.Resources::Load(\"ReflexSettings\");\n\tv130._instance = v100;\n\tv115 = v143._instance;\n\tgoto L_0029;\nL_0072:\n\tv169 = v168._instance;\n\treturn v169.m_logLevel;\n")]
			get
			{
				Object instance;
				if (!(_instance == null))
				{
					instance = _instance;
				}
				else
				{
					ReflexSettings instance2 = Resources.Load<ReflexSettings>("ReflexSettings");
					_instance = instance2;
					instance = _instance;
				}
				if (instance == null)
				{
					return LogLevel.Warning;
				}
				ReflexSettings instance3 = _instance;
				return instance3.m_logLevel;
			}
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x3F37C58", Offset = "0x3F37C58", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_002C:\n\tReflex.Logging.ReflexLogger::UpdateLogLevel(v53);\n\treturn;\nL_001D:\n\tv48._instance = this;\n\tv53 = Reflex.Configuration.ReflexSettings::get_LogLevel();\n\tgoto L_002C;\n")]
		private void OnValidate()
		{
			_instance = this;
			LogLevel logLevel = LogLevel;
			ReflexLogger.UpdateLogLevel(logLevel);
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x3F37CFC", Offset = "0x3F37CFC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public ReflexSettings()
		{
		}
	}
}
