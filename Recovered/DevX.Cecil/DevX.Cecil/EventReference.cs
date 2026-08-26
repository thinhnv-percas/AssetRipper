namespace DevX.Cecil
{
	public abstract class EventReference : MemberReference
	{
		private TypeReference m_eventType;

		public TypeReference EventType
		{
			get
			{
				return m_eventType;
			}
			set
			{
				m_eventType = value;
			}
		}

		public EventReference(string name, TypeReference eventType)
			: base(name)
		{
			m_eventType = eventType;
		}

		public abstract EventDefinition Resolve();

		public override string ToString()
		{
			return m_eventType.FullName + " " + base.ToString();
		}
	}
}
