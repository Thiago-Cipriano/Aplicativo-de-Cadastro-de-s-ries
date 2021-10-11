using System.Collections.Generic;
using System.Linq;
using Dig.One.Interfaces;

namespace Dig.One.Classes
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> seriesList = new List<Series>();

        public void Atualiza(int id, Series entidade)
        {
            this.seriesList[id] = entidade;
        }

        public void Excluir(int id)
        {
            this.seriesList[id].excluir();
        }

        public void Insere(Series entidade)
        {
            this.seriesList.Add(entidade);
        }

        public List<Series> Lista()
        {
            return this.seriesList.Where( x => !x.Excluido).ToList();
        }

        public int ProximoId()
        {
            return this.seriesList.Count;
        }

        public Series RetornaPorId(int id)
        {
            return this.seriesList[id];
        }
    }
}