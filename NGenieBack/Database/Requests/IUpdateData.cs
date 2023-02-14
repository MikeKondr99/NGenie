namespace NGenieBack.Database.Requests;

public interface IUpdateData<T>
{
    T Update(T data);
}
