namespace FCG.Business.Models;

public sealed class Evento
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public DateTime Data { get; set; }
    public string Descricao { get; set; }

    public Evento (string nome, DateTime data, string descricao)
    {
        this.Nome = nome;
        this.Data = data;
        this.Descricao = descricao;
    }
    public Evento() { }
}
