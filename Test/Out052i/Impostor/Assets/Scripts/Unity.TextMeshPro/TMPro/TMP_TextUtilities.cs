using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x20000A3")]
	public static class TMP_TextUtilities
	{
		[Token(Token = "0x20000A4")]
		private struct LineSegment
		{
			[Token(Token = "0x40005F8")]
			[FieldOffset(Offset = "0x0")]
			public Vector3 Point1;

			[Token(Token = "0x40005F9")]
			[FieldOffset(Offset = "0xC")]
			public Vector3 Point2;

			[Token(Token = "0x6000633")]
			[Address(RVA = "0x1614668", Offset = "0x1614668", Length = "0x10")]
			public LineSegment(Vector3 p1, Vector3 p2)
			{
				Point1 = default(Vector3);
				Point2 = default(Vector3);
			}
		}

		[Token(Token = "0x40005F5")]
		private static Vector3[] m_rectWorldCorners;

		[Token(Token = "0x40005F6")]
		private const string k_lookupStringL = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-";

		[Token(Token = "0x40005F7")]
		private const string k_lookupStringU = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-";

		[Token(Token = "0x600061A")]
		[Address(RVA = "0x16117E4", Offset = "0x16117E4", Length = "0x164")]
		public static int GetCursorIndexFromPosition(TMP_Text textComponent, Vector3 position, Camera camera)
		{
			return 0;
		}

		[Token(Token = "0x600061B")]
		[Address(RVA = "0x1611F94", Offset = "0x1611F94", Length = "0x1E0")]
		public static int GetCursorIndexFromPosition(TMP_Text textComponent, Vector3 position, Camera camera, out CaretPosition cursor)
		{
			cursor = default(CaretPosition);
			return 0;
		}

		[Token(Token = "0x600061C")]
		[Address(RVA = "0x1612174", Offset = "0x1612174", Length = "0x180")]
		public static int FindNearestLine(TMP_Text text, Vector3 position, Camera camera)
		{
			return 0;
		}

		[Token(Token = "0x600061D")]
		[Address(RVA = "0x16122F4", Offset = "0x16122F4", Length = "0x36C")]
		public static int FindNearestCharacterOnLine(TMP_Text text, Vector3 position, int line, Camera camera, bool visibleOnly)
		{
			return 0;
		}

		[Token(Token = "0x600061E")]
		[Address(RVA = "0x16127E8", Offset = "0x16127E8", Length = "0x11C")]
		public static bool IsIntersectingRectTransform(RectTransform rectTransform, Vector3 position, Camera camera)
		{
			return false;
		}

		[Token(Token = "0x600061F")]
		[Address(RVA = "0x1612904", Offset = "0x1612904", Length = "0x208")]
		public static int FindIntersectingCharacter(TMP_Text text, Vector3 position, Camera camera, bool visibleOnly)
		{
			return 0;
		}

		[Token(Token = "0x6000620")]
		[Address(RVA = "0x1611948", Offset = "0x1611948", Length = "0x328")]
		public static int FindNearestCharacter(TMP_Text text, Vector3 position, Camera camera, bool visibleOnly)
		{
			return 0;
		}

		[Token(Token = "0x6000621")]
		[Address(RVA = "0x1612B0C", Offset = "0x1612B0C", Length = "0x410")]
		public static int FindIntersectingWord(TMP_Text text, Vector3 position, Camera camera)
		{
			return 0;
		}

		[Token(Token = "0x6000622")]
		[Address(RVA = "0x1612F1C", Offset = "0x1612F1C", Length = "0x5C4")]
		public static int FindNearestWord(TMP_Text text, Vector3 position, Camera camera)
		{
			return 0;
		}

		[Token(Token = "0x6000623")]
		[Address(RVA = "0x16134E0", Offset = "0x16134E0", Length = "0x158")]
		public static int FindIntersectingLine(TMP_Text text, Vector3 position, Camera camera)
		{
			return 0;
		}

		[Token(Token = "0x6000624")]
		[Address(RVA = "0x1613638", Offset = "0x1613638", Length = "0x340")]
		public static int FindIntersectingLink(TMP_Text text, Vector3 position, Camera camera)
		{
			return 0;
		}

		[Token(Token = "0x6000625")]
		[Address(RVA = "0x1613978", Offset = "0x1613978", Length = "0x714")]
		public static int FindNearestLink(TMP_Text text, Vector3 position, Camera camera)
		{
			return 0;
		}

		[Token(Token = "0x6000626")]
		[Address(RVA = "0x1612660", Offset = "0x1612660", Length = "0xC0")]
		private static bool PointIntersectRectangle(Vector3 m, Vector3 a, Vector3 b, Vector3 c, Vector3 d)
		{
			return false;
		}

		[Token(Token = "0x6000627")]
		[Address(RVA = "0x1611C70", Offset = "0x1611C70", Length = "0x324")]
		public static bool ScreenPointToWorldPointInRectangle(Transform transform, Vector2 screenPoint, Camera cam, out Vector3 worldPoint)
		{
			worldPoint = default(Vector3);
			return false;
		}

		[Token(Token = "0x6000628")]
		[Address(RVA = "0x161408C", Offset = "0x161408C", Length = "0x170")]
		private static bool IntersectLinePlane(LineSegment line, Vector3 point, Vector3 normal, out Vector3 intersectingPoint)
		{
			intersectingPoint = default(Vector3);
			return false;
		}

		[Token(Token = "0x6000629")]
		[Address(RVA = "0x1612720", Offset = "0x1612720", Length = "0xC8")]
		public static float DistanceToLine(Vector3 a, Vector3 b, Vector3 point)
		{
			return 0f;
		}

		[Token(Token = "0x600062A")]
		[Address(RVA = "0x16141FC", Offset = "0x16141FC", Length = "0x74")]
		public static char ToLowerFast(char c)
		{
			return '\0';
		}

		[Token(Token = "0x600062B")]
		[Address(RVA = "0x1614270", Offset = "0x1614270", Length = "0x74")]
		public static char ToUpperFast(char c)
		{
			return '\0';
		}

		[Token(Token = "0x600062C")]
		[Address(RVA = "0x16142E4", Offset = "0x16142E4", Length = "0x74")]
		internal static uint ToUpperASCIIFast(uint c)
		{
			return 0u;
		}

		[Token(Token = "0x600062D")]
		[Address(RVA = "0x1614358", Offset = "0x1614358", Length = "0xBC")]
		public static int GetHashCode(string s)
		{
			return 0;
		}

		[Token(Token = "0x600062E")]
		[Address(RVA = "0x160BFC4", Offset = "0x160BFC4", Length = "0x6C")]
		public static int GetSimpleHashCode(string s)
		{
			return 0;
		}

		[Token(Token = "0x600062F")]
		[Address(RVA = "0x1614414", Offset = "0x1614414", Length = "0xBC")]
		public static uint GetSimpleHashCodeLowercase(string s)
		{
			return 0u;
		}

		[Token(Token = "0x6000630")]
		[Address(RVA = "0x16144D0", Offset = "0x16144D0", Length = "0x2C")]
		public static int HexToInt(char hex)
		{
			return 0;
		}

		[Token(Token = "0x6000631")]
		[Address(RVA = "0x16144FC", Offset = "0x16144FC", Length = "0x104")]
		public static int StringHexToInt(string s)
		{
			return 0;
		}
	}
}
