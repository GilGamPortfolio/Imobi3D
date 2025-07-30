using Imobi3DApp.ViewModels; // Adicione este using

namespace Imobi3DApp.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage(HomeViewModel viewModel) // Injeta a ViewModel
        {
            InitializeComponent();
            BindingContext = viewModel; // Define a ViewModel como contexto de liga��o da View
        }

        // Remova ou modifique este m�todo se voc� usar o Command do ToolbarItem
        // Por enquanto, manteremos o Clicked, mas idealmente seria um Command
        private async void OnAddImovelClicked(object sender, EventArgs e)
        {
            if (BindingContext is HomeViewModel viewModel)
            {
                //await viewModel.AddNewImovelAsync();
            }
        }
    }
}