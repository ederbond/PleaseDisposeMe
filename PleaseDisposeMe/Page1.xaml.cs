namespace PleaseDisposeMe;

public partial class Page1 : ContentPage
{
	public Page1(Page1ViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}

