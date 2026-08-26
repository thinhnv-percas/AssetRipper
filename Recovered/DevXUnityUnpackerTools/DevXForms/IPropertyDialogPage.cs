namespace DevXForms
{
	public interface IPropertyDialogPage
	{
		void BeforeDeactivated(object dataObject);

		void BeforeActivated(object dataObject);
	}
}
