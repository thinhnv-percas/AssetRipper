using System.Runtime.InteropServices;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x200005A")]
	public static class TMP_TextUtilities
	{
		[StructLayout((LayoutKind)0, Size = 24)]
		[Token(Token = "0x200009A")]
		private struct LineSegment
		{
			[Token(Token = "0x4000501")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public Vector3 Point1;

			[Token(Token = "0x4000502")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
			public Vector3 Point2;

			[Token(Token = "0x60005A9")]
			[Address(RVA = "0x84C69C", Offset = "0x84C69C", Length = "0x54")]
			public LineSegment(Vector3 p1, Vector3 p2)
			{
				Point1 = default(Vector3);
				Point2 = default(Vector3);
			}
		}

		[Token(Token = "0x40003F3")]
		private static Vector3[] m_rectWorldCorners;

		[Token(Token = "0x40003F4")]
		private const string k_lookupStringL = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-";

		[Token(Token = "0x40003F5")]
		private const string k_lookupStringU = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-";

		[Token(Token = "0x60004E7")]
		[Address(RVA = "0xC8AE34", Offset = "0xC8AE34", Length = "0x1B8")]
		public static int GetCursorIndexFromPosition(TMP_Text textComponent, Vector3 position, Camera camera)
		{
			return 0;
		}

		[Token(Token = "0x60004E8")]
		[Address(RVA = "0xC8B630", Offset = "0xC8B630", Length = "0x244")]
		public static int GetCursorIndexFromPosition(TMP_Text textComponent, Vector3 position, Camera camera, out CaretPosition cursor)
		{
			cursor = default(CaretPosition);
			return 0;
		}

		[Token(Token = "0x60004E9")]
		[Address(RVA = "0xC8B874", Offset = "0xC8B874", Length = "0x248")]
		public static int FindNearestLine(TMP_Text text, Vector3 position, Camera camera)
		{
			return 0;
		}

		[Token(Token = "0x60004EA")]
		[Address(RVA = "0xC8BABC", Offset = "0xC8BABC", Length = "0x434")]
		public static int FindNearestCharacterOnLine(TMP_Text text, Vector3 position, int line, Camera camera, bool visibleOnly)
		{
			return 0;
		}

		[Token(Token = "0x60004EB")]
		[Address(RVA = "0xC8C3B8", Offset = "0xC8C3B8", Length = "0x184")]
		public static bool IsIntersectingRectTransform(RectTransform rectTransform, Vector3 position, Camera camera)
		{
			return false;
		}

		[Token(Token = "0x60004EC")]
		[Address(RVA = "0xC8C53C", Offset = "0xC8C53C", Length = "0x2D8")]
		public static int FindIntersectingCharacter(TMP_Text text, Vector3 position, Camera camera, bool visibleOnly)
		{
			return 0;
		}

		[Token(Token = "0x60004ED")]
		[Address(RVA = "0xC8AFEC", Offset = "0xC8AFEC", Length = "0x400")]
		public static int FindNearestCharacter(TMP_Text text, Vector3 position, Camera camera, bool visibleOnly)
		{
			return 0;
		}

		[Token(Token = "0x60004EE")]
		[Address(RVA = "0xC8C814", Offset = "0xC8C814", Length = "0x6D0")]
		public static int FindIntersectingWord(TMP_Text text, Vector3 position, Camera camera)
		{
			return 0;
		}

		[Token(Token = "0x60004EF")]
		[Address(RVA = "0xC8CEE4", Offset = "0xC8CEE4", Length = "0x864")]
		public static int FindNearestWord(TMP_Text text, Vector3 position, Camera camera)
		{
			return 0;
		}

		[Token(Token = "0x60004F0")]
		[Address(RVA = "0xC8D748", Offset = "0xC8D748", Length = "0x1EC")]
		public static int FindIntersectingLine(TMP_Text text, Vector3 position, Camera camera)
		{
			return 0;
		}

		[Token(Token = "0x60004F1")]
		[Address(RVA = "0xC8D934", Offset = "0xC8D934", Length = "0x44C")]
		public static int FindIntersectingLink(TMP_Text text, Vector3 position, Camera camera)
		{
			return 0;
		}

		[Token(Token = "0x60004F2")]
		[Address(RVA = "0xC8DD80", Offset = "0xC8DD80", Length = "0x870")]
		public static int FindNearestLink(TMP_Text text, Vector3 position, Camera camera)
		{
			return 0;
		}

		[Token(Token = "0x60004F3")]
		[Address(RVA = "0xC8BEF0", Offset = "0xC8BEF0", Length = "0x258")]
		private static bool PointIntersectRectangle(Vector3 m, Vector3 a, Vector3 b, Vector3 c, Vector3 d)
		{
			return false;
		}

		[Token(Token = "0x60004F4")]
		[Address(RVA = "0xC8B3EC", Offset = "0xC8B3EC", Length = "0x244")]
		public static bool ScreenPointToWorldPointInRectangle(Transform transform, Vector2 screenPoint, Camera cam, out Vector3 worldPoint)
		{
			worldPoint = default(Vector3);
			return false;
		}

		[Token(Token = "0x60004F5")]
		[Address(RVA = "0xC8E5F0", Offset = "0xC8E5F0", Length = "0x224")]
		private static bool IntersectLinePlane(LineSegment line, Vector3 point, Vector3 normal, out Vector3 intersectingPoint)
		{
			intersectingPoint = default(Vector3);
			return false;
		}

		[Token(Token = "0x60004F6")]
		[Address(RVA = "0xC8C148", Offset = "0xC8C148", Length = "0x270")]
		public static float DistanceToLine(Vector3 a, Vector3 b, Vector3 point)
		{
			return 0f;
		}

		[Token(Token = "0x60004F7")]
		[Address(RVA = "0xC8E814", Offset = "0xC8E814", Length = "0x7C")]
		public static char ToLowerFast(char c)
		{
			return '\0';
		}

		[Token(Token = "0x60004F8")]
		[Address(RVA = "0xC8E890", Offset = "0xC8E890", Length = "0x7C")]
		public static char ToUpperFast(char c)
		{
			return '\0';
		}

		[Token(Token = "0x60004F9")]
		[Address(RVA = "0xC8E90C", Offset = "0xC8E90C", Length = "0x78")]
		public static int GetSimpleHashCode(string s)
		{
			return 0;
		}

		[Token(Token = "0x60004FA")]
		[Address(RVA = "0xC8E984", Offset = "0xC8E984", Length = "0xD8")]
		public static uint GetSimpleHashCodeLowercase(string s)
		{
			return 0u;
		}

		[Token(Token = "0x60004FB")]
		[Address(RVA = "0xC8EA5C", Offset = "0xC8EA5C", Length = "0x60")]
		public static int HexToInt(char hex)
		{
			return 0;
		}

		[Token(Token = "0x60004FC")]
		[Address(RVA = "0xC8EABC", Offset = "0xC8EABC", Length = "0x12C")]
		public static int StringHexToInt(string s)
		{
			return 0;
		}
	}
}
