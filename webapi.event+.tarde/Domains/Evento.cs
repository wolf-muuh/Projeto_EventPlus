﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data do evento é obrigatória")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do evento é obrigatório")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do evento é obrigatória")]
        public string? Descricao { get; set; }

        //Ref.Tabela tipo evento
        [Required(ErrorMessage = "O id do tipo do evento é obrigatório")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TipoEvento? TipoEvento { get; set; }

        //Ref. tabela Instituição
        [Required(ErrorMessage = "A instituição do evento é obrigatória")]
        public Guid IdInstituicao { get; set; }

        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }


    }
}
