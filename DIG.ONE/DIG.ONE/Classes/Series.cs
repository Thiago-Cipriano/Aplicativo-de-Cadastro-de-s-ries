using System;
using Dig.One.Classes;
using Dig.One.Enums;

namespace Dig.One.Classes
{
    public class Series : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
		public bool Excluido { get; set; }

		public Series(int id, Genero genero, string titulo, string descricao, int ano){
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
			this.Excluido = false;
		}

		public Series(){}

		public override string ToString(){
			string retorno = "";
			retorno += $"Gênero, {this.Genero}{Environment.NewLine}"; 
			retorno += $"Titulo, {this.Titulo}{Environment.NewLine}";
			retorno += $"Descrição, {this.Descricao}{Environment.NewLine}";
			retorno += $"Ano de Inicio {this.Ano}{Environment.NewLine}";

			return retorno;
		}	

		public string retornaTitulo(){
			return this.Titulo;
		}

		public int retornaId(){
			return this.Id;
		}

		public void excluir(){
			this.Excluido = true;
		}

    }
}
