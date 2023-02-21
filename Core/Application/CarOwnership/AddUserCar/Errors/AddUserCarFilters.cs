using ErrorHandler.Traversable;
using Application.Authentication.Register.Contracts;
using Application.CarOwnership.AddUserCar.Contracts;


namespace Application.CarOwnership.AddUserCar.Errors;

public class AddUserCarFilters : FilterChain<IAddUserCarRequest>
{
    protected override Enum SuccessInfo { get; init; }

	public AddUserCarFilters()
	{
		SuccessInfo = AddUserCarInfo.SuccessfulUserCarRegistration;

		AddFilter<IRegisterQueries>(
			(request, queries) => !queries.UserExists(request.UserId),
			AddUserCarInfo.InvalidUser);

		//Check if Model is Valid
	}
}