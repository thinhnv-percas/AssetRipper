using System.Collections.Generic;
using System.Windows.Forms;

namespace DevXForms
{
	public class ViewMap : Panel
	{
		internal object _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A;

		internal Dictionary<object, Control> _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020 = new Dictionary<object, Control>();

		public object CurKey
		{
			get
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A;
			}
			set
			{
				SelectView(value);
			}
		}

		public void AddView(object key, Control view)
		{
			view.Dock = DockStyle.Fill;
			view.Visible = false;
			Form form = view as Form;
			if (form != null)
			{
				form.TopLevel = false;
				form.FormBorderStyle = FormBorderStyle.None;
			}
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020[key] = view;
			if (!base.Controls.Contains(view))
			{
				base.Controls.Add(view);
			}
		}

		public Control GetView(object key)
		{
			if (key == null)
			{
				return null;
			}
			if (_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020.ContainsKey(key))
			{
				return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020[key];
			}
			return null;
		}

		public void SelectView(object key)
		{
			Control view = GetView(key);
			foreach (Control value in _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020.Values)
			{
				if (view != value)
				{
					value.Hide();
				}
			}
			view?.Show();
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A = key;
		}
	}
}
