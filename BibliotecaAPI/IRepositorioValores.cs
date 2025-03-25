using BibliotecaAPI.Entidades;

namespace BibliotecaAPI
{
    public interface IRepositorioValores
    {
        // Cualquier clase que implemente esta interfaz obligatoriamente debe implementar un método con esta asignatura
        IEnumerable<Valor> ObtenerValores(); 
    }
}
