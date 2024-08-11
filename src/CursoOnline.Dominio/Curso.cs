
namespace CursoOnline.Dominio
{
    public class Curso
    {
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double ValorCurso { get; private set; }
        public string Descricao { get; private set; }

        //construtores vazio sempre privados para serem
        //usados apenas pela propria classe ou algum ORM
        private Curso() { }

        public Curso(string nome, string descricao, double cargaHoraria, PublicoAlvo publicoAlvo, double valorCurso)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException(Resource.NomeInvalido);
            }

            if (cargaHoraria < 1)
            {
                throw new ArgumentException(Resource.CargaHorariaInvalida);
            }

            if (valorCurso < 1)
            {
                throw new ArgumentException(Resource.valorCursoInvalido);
            }

            if (string.IsNullOrEmpty(descricao))
            {
                throw new ArgumentException(Resource.DescricaoInvalida);
            }

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            ValorCurso = valorCurso;
            Descricao = descricao;
        }

        public void AlteraNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome invalido.");
            }

            Nome = nome;
        }
    }
}