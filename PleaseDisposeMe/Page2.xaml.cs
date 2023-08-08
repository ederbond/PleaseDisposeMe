namespace PleaseDisposeMe;

public partial class Page2 : ContentPage
{
	public Page2(Page2ViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}

