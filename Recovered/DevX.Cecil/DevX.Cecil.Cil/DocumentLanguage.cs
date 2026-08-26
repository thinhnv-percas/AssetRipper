using System;

namespace DevX.Cecil.Cil
{
	public abstract class DocumentLanguage
	{
		public static readonly Guid None = new Guid(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

		public static readonly Guid C = new Guid(1671464724u, 64567, 4562, 144, 76, 0, 192, 79, 163, 2, 161);

		public static readonly Guid Cpp = new Guid(974311607u, 49772, 4560, 180, 66, 0, 160, 36, 74, 29, 210);

		public static readonly Guid CSharp = new Guid(1062298360, 1990, 4563, 144, 83, 0, 192, 79, 163, 2, 161);

		public static readonly Guid Basic = new Guid(974311608u, 49772, 4560, 180, 66, 0, 160, 36, 74, 29, 210);

		public static readonly Guid Java = new Guid(974311604u, 49772, 4560, 180, 66, 0, 160, 36, 74, 29, 210);

		public static readonly Guid Cobol = new Guid(2936302801u, 53473, 4562, 151, 124, 0, 160, 201, 180, 213, 12);

		public static readonly Guid Pascal = new Guid(2936302802u, 53473, 4562, 151, 124, 0, 160, 201, 180, 213, 12);

		public static readonly Guid CIL = new Guid(2936302803u, 53473, 4562, 151, 124, 0, 160, 201, 180, 213, 12);

		public static readonly Guid JScript = new Guid(974311606u, 49772, 4560, 180, 66, 0, 160, 36, 74, 29, 210);

		public static readonly Guid SMC = new Guid(228302715, 26129, 4563, 189, 42, 0, 0, 248, 8, 73, 189);

		public static readonly Guid MCpp = new Guid(1261829608, 1990, 4563, 144, 83, 0, 192, 79, 163, 2, 161);
	}
}
