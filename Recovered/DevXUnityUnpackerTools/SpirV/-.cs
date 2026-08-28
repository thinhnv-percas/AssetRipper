using @as;
using BrotliSharpLib;
using DevXForms;
using FMOD;
using ICSharpCode.SharpZipLib.Tar;
using LZO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Unreal;
using Wasm;

namespace SpirV
{
	internal sealed class _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020
	{
		internal readonly BinaryReader _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020;

		internal readonly bool _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A;

		public bool EndOfStream => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020.BaseStream.Position == _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020.BaseStream.Length;

		public _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020(BinaryReader reader)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020 = reader;
			uint num = _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020.ReadUInt32();
			if (num == _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.MagicNumber)
			{
				_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A = true;
				return;
			}
			if (_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A(num) == _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020.MagicNumber)
			{
				_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A = false;
				return;
			}
			throw new Exception("Invalid magic number");
		}

		public uint ReadDWord()
		{
			if (_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A)
			{
				return _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020.ReadUInt32();
			}
			return _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A(_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020.ReadUInt32());
		}

		internal static uint _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A(uint _0020)
		{
			return (_0020 << 24) | ((_0020 & 0xFF00) << 8) | ((_0020 >> 8) & 0xFF00) | (_0020 >> 24);
		}
	}
	internal class _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020
	{
		public class ToolInfo
		{
			[CompilerGenerated]
			internal readonly string _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A;

			[CompilerGenerated]
			internal readonly string _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020;

			public string Name
			{
				get;
			}

			public string Vendor
			{
				get;
			}

			public ToolInfo(string vendor)
			{
				_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020 = vendor;
			}

			public ToolInfo(string vendor, string name)
			{
				_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020 = vendor;
				_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A = name;
			}
		}

		internal static readonly Dictionary<int, ToolInfo> _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A = new Dictionary<int, ToolInfo>
		{
			{
				0,
				new ToolInfo("Khronos")
			},
			{
				1,
				new ToolInfo("LunarG")
			},
			{
				2,
				new ToolInfo("Valve")
			},
			{
				3,
				new ToolInfo("Codeplay")
			},
			{
				4,
				new ToolInfo("NVIDIA")
			},
			{
				5,
				new ToolInfo("ARM")
			},
			{
				6,
				new ToolInfo("Khronos", "LLVM/SPIR-V Translator")
			},
			{
				7,
				new ToolInfo("Khronos", "SPIR-V Tools Assembler")
			},
			{
				8,
				new ToolInfo("Khronos", "Glslang Reference Front End")
			},
			{
				9,
				new ToolInfo("Qualcomm")
			},
			{
				10,
				new ToolInfo("AMD")
			},
			{
				11,
				new ToolInfo("Intel")
			},
			{
				12,
				new ToolInfo("Imagination")
			},
			{
				13,
				new ToolInfo("Google", "Shaderc over Glslang")
			},
			{
				14,
				new ToolInfo("Google", "spiregg")
			},
			{
				15,
				new ToolInfo("Google", "rspirv")
			},
			{
				16,
				new ToolInfo("X-LEGEND", "Mesa-IR/SPIR-V Translator")
			},
			{
				17,
				new ToolInfo("Khronos", "SPIR-V Tools Linker")
			}
		};

		public static uint MagicNumber => 119734787u;

		public static uint Version => 66048u;

		public static uint Revision => 2u;

		public static uint OpCodeMask => 65535u;

		public static uint WordCountShift => 16u;

		public static IDictionary<int, ToolInfo> Tools => _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A;
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020(object _0020, DSP_PARAMETER_DESC_UNION _0020_000A, object _0020_0020)
		{
			((MainForm)null)._0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A((string)null);
			((_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A)null)._0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020();
			((TypeSection)null).FunctionTypes = null;
			_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A I_0 = ((_0020_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020)null)._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020;
			((MainForm)null)._0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A((object)null, (EventArgs)null);
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A
	{
		// Dead decoy method removed (referenced an unresolved IL generic-parameter leak escaped as unbound generic syntax, e.g. `!0`/`!!0`); see FINDINGS.md §5.
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A
	{
		internal unsafe void _0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020(decimal _0020)
		{
			((_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020)null).ReadBlock();
			HashManager._0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020(null);
			GlobalVariable.ReadFrom(null);
			_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020._0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020(ref *(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020._0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020*)null);
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020(VER_UE4 _0020, object _0020_000A, bool _0020_0020, short _0020_000A_000A)
		{
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020()
		{
			((_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020)null)._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A();
			return 948012019;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A
	{
		internal unsafe string _0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020(byte[] _0020, int _0020_000A, int _0020_0020)
		{
			((_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020)null)._0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A((object)null, ref *(_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020._0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020*)null);
			((_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020)null)._0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020();
			((ImageInfo)null)._0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020();
			return "1171540330";
		}
	}
}
