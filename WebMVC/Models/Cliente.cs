using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMVC.Models
{

    [Table("tblCliente")]
    public class Cliente
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("CPF")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("RG")]
        [Display(Name = "RG")]
        public string RG { get; set; }


        [Column("DataExpedicao")]
        [Display(Name = "Data Expedição")]
        public DateTime DataExpedicao { get; set; }


        [Column("OrgaoExpedicao")]
        [Display(Name = "Orgão Expedicao")]
        public string OrgaoExpedicao { get; set; }

        [Column("UF_Expedicao")]
        [Display(Name = "UF Expedicao")]
        public string UF_Expedicao { get; set; }

        [Column("DataNascimento")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("Sexo")]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Column("EstadoCivil")]
        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }


        // Dados Endereço cliente

        [Column("CEP")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Column("Logradouro")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Column("Numero")]
        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Column("Complemento")]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Column("Bairro")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Column("Cidade")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Column("UF")]
        [Display(Name = "UF")]
        public string UF { get; set; }
    }
}
