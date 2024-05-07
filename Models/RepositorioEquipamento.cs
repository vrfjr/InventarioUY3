using System.Collections.Generic;
using System.Linq;

public class RepositorioEquipamento : IRepositorioEquipamento
{
    private List<Equipamento> _equipamentos;
    private int _ultimoId;

    public RepositorioEquipamento()
    {
        _equipamentos = new List<Equipamento>();
        _ultimoId = 0;
    }

    public void AdicionarEquipamento(Equipamento equipamento)
    {
        equipamento.Id = ++_ultimoId;
        _equipamentos.Add(equipamento);
    }

    public void RemoverEquipamento(int id)
    {
        var equipamento = _equipamentos.FirstOrDefault(e => e.Id == id);
        if (equipamento != null)
            _equipamentos.Remove(equipamento);
    }

    public void AtualizarEquipamento(Equipamento equipamento)
    {
        var index = _equipamentos.FindIndex(e => e.Id == equipamento.Id);
        if (index != -1)
            _equipamentos[index] = equipamento;
    }

    public IList<Equipamento> ListarEquipamentos()
    {
        return _equipamentos.ToList();
    }
}
