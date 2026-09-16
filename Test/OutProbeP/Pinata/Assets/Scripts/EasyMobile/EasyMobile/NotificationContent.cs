using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000077")]
	public class NotificationContent
	{
		[Token(Token = "0x40002C1")]
		public const string DEFAULT_ANDROID_SMALL_ICON = "ic_stat_em_default";

		[Token(Token = "0x40002C2")]
		public const string DEFAULT_ANDROID_LARGE_ICON = "ic_large_em_default";

		[Token(Token = "0x40002C3")]
		[FieldOffset(Offset = "0x10")]
		public string title;

		[Token(Token = "0x40002C4")]
		[FieldOffset(Offset = "0x18")]
		public string subtitle;

		[Token(Token = "0x40002C5")]
		[FieldOffset(Offset = "0x20")]
		public string body;

		[Token(Token = "0x40002C6")]
		[FieldOffset(Offset = "0x28")]
		public int badge;

		[Token(Token = "0x40002C7")]
		[FieldOffset(Offset = "0x30")]
		public Dictionary<string, object> userInfo;

		[Token(Token = "0x40002C8")]
		[FieldOffset(Offset = "0x38")]
		public string categoryId;

		[Token(Token = "0x40002C9")]
		[FieldOffset(Offset = "0x40")]
		public string smallIcon;

		[Token(Token = "0x40002CA")]
		[FieldOffset(Offset = "0x48")]
		public string largeIcon;

		[Token(Token = "0x6000566")]
		[Address(RVA = "0xFCF73C", Offset = "0xFCF73C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC3A48]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2025680]) = v38;\nL_0018:\n\tthis.smallIcon = \"ic_stat_em_default\";\n\tthis.largeIcon = \"ic_large_em_default\";\n\tSystem.Object::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NotificationContent()
		{
			smallIcon = "ic_stat_em_default";
			largeIcon = "ic_large_em_default";
		}
	}
}
