using SQLite;

namespace Imobi3DApp.Models
{
    public class Imovel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        // Futuramente, teremos uma lista de cômodos associada a este imóvel
        // public List<Comodo> Comodos { get; set; } // Isso será populado separadamente ou via relação em um banco relacional mais complexo
    }
}