using Imobi3DApp.Views; // Adicione este using

namespace Imobi3DApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registra a rota para a HomePage (se você precisar navegar para ela de outros lugares)
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));

            // Registre a rota para a página de novo imóvel (crie-a mais tarde)
            // Routing.RegisterRoute(nameof(NewImovelPage), typeof(NewImovelPage));
        }
    }
}