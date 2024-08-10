using static CursoOnline.Dominio.UnitTests.Cursos.CursoTest;

namespace CursoOnline.Dominio.UnitTests.Cursos
{
    public class Curso
    {
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double ValorCurso { get; private set; }

        //construtores vazio sempre privados para serem
        //usados apenas pela propria classe ou algum ORM
        private Curso() { }

        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valorCurso)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            ValorCurso = valorCurso;
        }
    }
}