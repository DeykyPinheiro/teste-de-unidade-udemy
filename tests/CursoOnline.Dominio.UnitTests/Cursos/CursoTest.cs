using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.Dominio.UnitTests.Cursos
{
    public class CursoTest
    {
        private string nome = "Informatica básica";
        private double cargaHoraria = 80;
        private string publicoAlvo = "Estudantes";
        private double valorCurso = 349.50;

        [Fact]
        public void DeveCriarCurso()
        {
            Curso curso = new Curso(nome, cargaHoraria, publicoAlvo, valorCurso);

            Assert.NotNull(curso);
            Assert.Equal(nome, curso.Nome);
            Assert.Equal(cargaHoraria, curso.CargaHoraria);
            Assert.Equal(publicoAlvo, curso.PublicoAlvo);
            Assert.Equal(valorCurso, curso.ValorCurso);
        }
    }
}
