namespace DevXForms
{
	public class HitInfo
	{
		public enum eHitType
		{
			kColumnHeader = 1,
			kColumnHeaderResize
		}

		public eHitType HitType;

		public TreeListColumn Column;
	}
}
