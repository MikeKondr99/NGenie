using NGenieBack.Database.Models;

namespace NGenieBack.Database.Requests;

public interface ICreateData<T>
{
    T Create();
}

