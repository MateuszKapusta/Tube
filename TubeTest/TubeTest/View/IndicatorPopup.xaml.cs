using CommunityToolkit.Maui.Views;
using TubeTest.ViewModel;

namespace TubeTest;

public partial class IndicatorPopup : Popup
{
	public IndicatorPopup(IndicatorViewModel bindingContext)
	{
		InitializeComponent();
		BindingContext = bindingContext;
	}
}