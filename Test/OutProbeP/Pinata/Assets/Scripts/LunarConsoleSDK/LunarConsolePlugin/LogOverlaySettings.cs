using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace LunarConsolePlugin
{
	[Serializable]
	[Token(Token = "0x2000013")]
	public class LogOverlaySettings
	{
		[SerializeField]
		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x10")]
		public bool enabled;

		[SerializeField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x73C964", Offset = "0x73C964")]
		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x14")]
		public int maxVisibleLines;

		[SerializeField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x73C9B0", Offset = "0x73C9B0")]
		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x18")]
		public float timeout;

		[SerializeField]
		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x20")]
		public LogOverlayColors colors;

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x13D5A8C", Offset = "0x13D5A8C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EE3650]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028A63]) = v38;\nL_0015:\n\tthis.maxVisibleLines = 0x3F80000000000003;\n\tv44 = new LunarConsolePlugin.LogOverlayColors();\n\tLunarConsolePlugin.LogOverlayColors::.ctor(v44);\n\tthis.colors = v44;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LogOverlaySettings()
		{
			//IL_001b: Expected I4, but got I8
			base._002Ector();
			maxVisibleLines = 3;
			LogOverlayColors logOverlayColors = new LogOverlayColors();
			colors = logOverlayColors;
		}
	}
}
