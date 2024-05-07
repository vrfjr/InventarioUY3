using System.Collections.Generic;

public interface IRepositorioEquipamento
{
    void AdicionarEquipamento(Equipamento equipamento);
    void RemoverEquipamento(int id);
    void AtualizarEquipamento(Equipamento equipamento);
    IList<Equipamento> ListarEquipamentos();
}
