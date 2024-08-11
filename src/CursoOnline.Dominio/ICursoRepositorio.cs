namespace CursoOnline.Dominio
{
    public interface ICursoRepositorio
    {
        Curso Adicionar(Curso data);
        Curso ObterPeloNome(string nome);
    }
}
