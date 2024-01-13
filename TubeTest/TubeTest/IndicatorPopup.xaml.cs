using CommunityToolkit.Maui.Views;

namespace TubeTest;

public partial class IndicatorPopup : Popup
{
	public IndicatorPopup(IndicatorViewModel bindingContext)
	{
		InitializeComponent();
		BindingContext = bindingContext;
	}
}