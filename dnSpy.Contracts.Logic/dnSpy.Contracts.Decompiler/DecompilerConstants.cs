using System;

namespace dnSpy.Contracts.Decompiler;

public static class DecompilerConstants
{
	public static readonly double CSHARP_ILSPY_ORDERUI = 0.0;

	public static readonly double VISUALBASIC_ILSPY_ORDERUI = 100.0;

	public static readonly double IL_ILSPY_ORDERUI = 200.0;

	public static readonly double CSHARP_ILSPY_DEBUG_ORDERUI = 10000.0;

	public static readonly double ILAST_ILSPY_DEBUG_ORDERUI = 20000.0;

	public static readonly Guid LANGUAGE_IL = new Guid("9EF276FD-3293-42A4-B48A-1D6A69086B3D");

	public static readonly Guid LANGUAGE_IL_ILSPY = new Guid("A4F35508-691F-4BD0-B74D-D5D5D1D0E8E6");

	public static readonly Guid LANGUAGE_ILAST_ILSPY = new Guid("CA52A515-12AE-4182-BC88-81ED037C3D32");

	public static readonly Guid LANGUAGE_CSHARP = new Guid("F5A318D4-4B2A-48D2-AE33-F4D2B1EFF4B0");

	public static readonly Guid LANGUAGE_CSHARP_ILSPY = new Guid("4162DADA-67C3-4DE4-A5F3-6552C8353ECE");

	public static readonly Guid LANGUAGE_VISUALBASIC = new Guid("B6849618-8239-4FBB-8DFF-D45EB023C193");

	public static readonly Guid LANGUAGE_VISUALBASIC_ILSPY = new Guid("BBA40092-76B2-4184-8E81-0F1E3ED14E72");

	public static readonly string GENERIC_NAMEUI_IL = "IL";

	public static readonly string GENERIC_NAMEUI_CSHARP = "C#";

	public static readonly string GENERIC_NAMEUI_VISUALBASIC = "Visual Basic";
}
