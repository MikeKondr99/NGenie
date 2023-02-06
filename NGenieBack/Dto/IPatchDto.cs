namespace NGenieBack.Dto;

public interface IPatchDto<T> where T : class
{
    public T Patch(T entity);
}
