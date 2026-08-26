using DevXUnityUnpackerTools._WPF;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms.Integration;

[Designer("System.Windows.Forms.Design.ControlDesigner, System.Design")]
[DesignerSerializer("System.ComponentModel.Design.Serialization.TypeCodeDomSerializer , System.Design", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design")]
public class _3DView_WinformsHost : ElementHost
{
	public _3DView MainControll = new _3DView();

	public _3DView_WinformsHost()
	{
		base.Child = MainControll;
	}
}
