namespace Application.CarOwnership.AddUserCar.Contracts;

public interface IAddUserCarRequest
{
    Guid UserId { get; }
    Guid ModelId { get; }
}