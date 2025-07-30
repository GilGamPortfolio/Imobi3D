using CommunityToolkit.Mvvm.ComponentModel; // Para ObservableObject e ObservableProperty
using CommunityToolkit.Mvvm.Input;       // Para AsyncRelayCommand
using Imobi3DApp.Database;
using Imobi3DApp.Models;
using System.Collections.ObjectModel;     // Para ObservableCollection
using System.Threading.Tasks;             // Para Task
using Imobi3DApp.Views; // Para referenciar a página de detalhes (futuramente)

namespace Imobi3DApp.ViewModels
{
    // A classe precisa herdar de ObservableObject para usar os atributos [ObservableProperty]
    // e notificar a UI sobre mudanças nas propriedades.
    public partial class HomeViewModel : ObservableObject
    {
        private readonly AppDbContext _appDbContext;

        // Propriedade para a lista de imóveis. Usamos ObservableCollection
        // para que a UI seja atualizada automaticamente quando itens forem adicionados/removidos.
        [ObservableProperty]
        private ObservableCollection<Imovel> _imoveis;

        // Propriedade para controlar a visibilidade da mensagem "Nenhum imóvel cadastrado"
        [ObservableProperty]
        private bool _isNoImovelMessageVisible = true;

        public HomeViewModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Imoveis = new ObservableCollection<Imovel>();
            LoadImoveisCommand.Execute(null); // Carrega os imóveis ao inicializar a ViewModel
        }

        // Comando para carregar os imóveis do banco de dados
        [RelayCommand]
        private async Task LoadImoveisAsync()
        {
            var imoveisFromDb = await _appDbContext.GetImoveis().ToListAsync();
            Imoveis.Clear();
            foreach (var imovel in imoveisFromDb)
            {
                Imoveis.Add(imovel);
            }
            IsNoImovelMessageVisible = !Imoveis.Any(); // Atualiza a visibilidade da mensagem
        }

        // Comando para adicionar um novo imóvel (navegar para outra página)
        [RelayCommand]
        private async Task AddNewImovelAsync()
        {
            // Futuramente, navegaremos para uma página de adição/edição de imóvel
            // await Shell.Current.GoToAsync(nameof(NewImovelPage)); // Nome da página de criação/edição
            // Por enquanto, apenas para testes, você pode adicionar um imóvel fake
            // await _appDbContext.SaveImovelAsync(new Imovel { Nome = $"Imóvel Teste {DateTime.Now.Second}", Descricao = "Descrição de teste." });
            // await LoadImoveisAsync(); // Recarrega a lista
        }

        // Comando para lidar com a seleção de um imóvel (futuro)
        [RelayCommand]
        private async Task SelectImovelAsync(Imovel imovel)
        {
            if (imovel == null)
                return;

            // Lógica para exibir detalhes do imóvel ou editá-lo
            // Ex: await Shell.Current.GoToAsync($"{nameof(ImovelDetailPage)}?Id={imovel.Id}");
        }
    }
}