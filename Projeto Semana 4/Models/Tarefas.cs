using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Semana_4.Models
{
	public class Tarefas
	{
        public int TarefasID { get; set; }

		public string? CaminhoImagem { get; set; }

		[Display(Name = "Tarefa")]
		public string? NomeTarefa { get; set; }

		[Display(Name = "Descrição")]
		public string ? Descricao { get; set; }

		[Display(Name = "Data")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		public DateTime Data {  get; set; }

		[Display(Name = "Status")]
		public string? Status { get; set; }
    }
}
