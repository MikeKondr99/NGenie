using OneOf;

namespace NGenieBack.Repositories;

public struct ServiceUnavaliable { }
public struct EntityNotFound { }
public struct EntityAlreadyExists { }

[GenerateOneOf]
public partial class GetAllResult<T> : OneOfBase<T, ServiceUnavaliable> { }

[GenerateOneOf]
public partial class GetOneResult<T> : OneOfBase<T, ServiceUnavaliable,EntityNotFound> { }



