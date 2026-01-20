using System.ComponentModel.DataAnnotations;  // Necessário para validação

namespace CrudMVCApp.Models
{
    public class Item
    {
        public int Id { get; set; } // ID único do item

        [Required(ErrorMessage = "O Nome é obrigatório.")] // Adiciona validação para Nome
        public string Nome { get; set; } // Nome do item

        [Required(ErrorMessage = "A Descrição é obrigatória.")] // Adiciona validação para Descrição
        public string Descricao { get; set; } // Descrição do item
    }
}

