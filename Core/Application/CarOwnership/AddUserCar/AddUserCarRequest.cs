using Application.CarOwnership.AddUserCar.Contracts;


namespace Application.CarOwnership.AddUserCar;

public class AddUserCarRequest : IAddUserCarRequest
{
    public Guid UserId { get; init; }
    public Guid ModelId { get; init; }


    public AddUserCarRequest(Guid userId, Guid modelId)
    {
        UserId = userId;
        ModelId = modelId;
    }

}