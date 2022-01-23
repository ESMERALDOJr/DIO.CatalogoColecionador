using System;
using System.Collections.Generic;
using DIO.CatalogoColecionador.Interfaces;

namespace DIO.CatalogoColecionador
{
    public class CatalogoRepositorio : IRepositorio<Catalogo>
    {
        private List<Catalogo> listaCatalogo = new List<Catalogo>();
        public void Atualiza(int id, Catalogo objeto)
        {
            listaCatalogo[id] = objeto;
        }
        public void Exclui(int id)
        {
            listaCatalogo[id].Excluir();
        }
        public void Insere(Catalogo objeto)
        {
            listaCatalogo.Add(objeto);
        }
        public List<Catalogo> Lista()
        {
            return listaCatalogo;
        }
        public int ProximoId()
        {
            return listaCatalogo.Count;
        }
        public Catalogo RetornaPorId(int id)
        {
            return listaCatalogo[id];
        }

        void IRepositorio<Catalogo>.Atualizar(int id, Catalogo entidade)
        {
            throw new NotImplementedException();
        }
    }
}