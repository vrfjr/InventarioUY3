// Equipamento.cs

using System;

public class Equipamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    private string _numeroPatrimonio;

    public string NumeroPatrimonio
    {
        get { return _numeroPatrimonio; }
        set
        {
            if (!ValidarNumeroPatrimonio(value))
                throw new ArgumentException("O número do patrimônio deve ter o formato U0000.");
            _numeroPatrimonio = value;
        }
    }

    // Construtor para inicializar o equipamento com nome e número de patrimônio
    public Equipamento(string nome, string numeroPatrimonio)
    {
        Nome = nome;
        NumeroPatrimonio = numeroPatrimonio;
    }

    // Método para validar o número do patrimônio
    private bool ValidarNumeroPatrimonio(string numeroPatrimonio)
    {
        // Verifica se o número do patrimônio tem o formato U seguido de 4 dígitos
        return numeroPatrimonio != null && numeroPatrimonio.Length == 5 && numeroPatrimonio.StartsWith("U") && int.TryParse(numeroPatrimonio.Substring(1), out _);
    }
}
