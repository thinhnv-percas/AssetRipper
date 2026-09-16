using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x741834", Offset = "0x741834")]
	[Token(Token = "0x2000010")]
	public abstract class PropertyGroupAttribute : Attribute
	{
		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x10")]
		public string GroupID;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x18")]
		public string GroupName;

		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x20")]
		public int Order;

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x167F2A0", Offset = "0x167F2A0", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.GroupID = groupId;\n\tthis.Order = order;\n\tv23 = System.String::LastIndexOf(groupId, 0x2F);\n\tv39 = v23 & 0x80000000;\n\tv40 = v39 == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0029;\n\tv52 = v23 >= groupId.m_stringLength;\n\tif (v52) goto L_0029;\n\tv78 = v23 + 1;\n\tv76 = System.String::Substring(groupId, v78);\nL_0029:\n\tthis.GroupName = v79;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PropertyGroupAttribute(string groupId, int order)
		{
			//IL_0043: Expected I4, but got I8
			base._002Ector();
			GroupID = groupId;
			Order = order;
			int num = groupId.LastIndexOf('/');
			int num2 = (int)(num & 0x80000000L);
			bool flag = num2 == 0;
			bool flag2 = !flag;
			string groupName = groupId;
			if (!flag2)
			{
				bool flag3 = num >= groupId.Length;
				groupName = groupId;
				if (!flag3)
				{
					int startIndex = num + 1;
					string text = groupId.Substring(startIndex);
					groupName = text;
				}
			}
			GroupName = groupName;
		}
	}
}
