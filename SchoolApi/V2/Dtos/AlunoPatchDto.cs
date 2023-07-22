using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.V2.Dtos
{
    /// <summary>
    /// Este � o DTO de Aluno para Registrar.
    /// </summary>
    public class AlunoPatchDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}