namespace CursoOnline.Dominio
{
    public class CursoDto
    {
        public string Nome { get; set; }
        public double CargaHoraria { get; set; }
        public PublicoAlvo PublicoAlvo { get; set; }
        public double ValorCurso { get; set; }
        public string Descricao { get; set; }
    }
}