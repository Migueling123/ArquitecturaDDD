namespace Utilitarios.InC
{
    /// <summary>
    /// Inicializa el tipado de la inversion de control
    /// </summary>
    /// <param name="registar"> </param>
    public interface IModulo
    {
        void Initialize(IRegistrarModulo registrar);
    }
}
