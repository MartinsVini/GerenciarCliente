namespace GerenciarCliente
{
    public interface DAO<T>
    {
        Task<List<T>> BuscarTodos();
        Task<T> BuscarPorEmail(string email);
        Task<T> Adicionar(T t);
        Task<T> Atualizar(T t, string email);
        Task<bool> Apagar(string email);
        Task<bool> Logar(string email, string senha);

      


    }
}
