using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Tarefa
    {
        [Key]
        public int CD_TAREFA { get; set; }
        public string DS_TAREFA { get; set; }
        public DateTime DT_CADASTRO { get; set; }
        //public Pessoa CD_PESSOA { get; set; }
    }
}
