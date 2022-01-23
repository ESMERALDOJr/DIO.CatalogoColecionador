using System;

namespace DIO.CatalogoColecionador
{
    public class Catalogo : EntidadeBase    
    {
        // Atributos
        private Marca Marca { get; set; }
        private string Modelo { get; set; }
        private string Descricao { get; set; }
        private int Cod_Miniatura { get; set; }
        private bool Excluido { get; set; }

        //Metodo
        public Catalogo(int id, Marca marca, string modelo, string descricao, int cod_miniatura)
        {
            this.Id = id; 
            this.Marca = marca; 
            this.Modelo = modelo;
            this.Descricao = descricao;
            this.Cod_Miniatura = cod_miniatura;
            this.Excluido = false;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Marca: " + this.Marca + Environment.NewLine;
            retorno += "Modelo: " + this.Modelo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Código da Miniatura: " + this.Cod_Miniatura + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public string retornaModelo()
        {
            return this.Modelo;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}