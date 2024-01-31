using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.Model;
using Business.Profiles.Validation.FluentValidation.Users;
using Business.Requests.Users;
using Business.Responses.Model;
using Business.Responses.Users;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class UsersManager : IUsersService
{
    private readonly IUsersDal _usersDal;
    private readonly UsersBusinessRules _usersBusinessRules;
    private readonly IMapper _mapper;
    
    public UsersManager(IUsersDal usersDal, UsersBusinessRules usersBusinessRules, IMapper mapper)
    {
        _usersDal = usersDal;
        _usersBusinessRules = usersBusinessRules;
        _mapper = mapper;
    }
    
    public GetUsersListResponse GetList(GetUsersListRequest request)
    {
        IList<Users> usersList = _usersDal.GetList();

        var response = _mapper.Map<GetUsersListResponse>(usersList);
        
        return response;
    }

    public GetUsersByIdResponse GetById(GetUsersByIdRequest request)
    {
        Users? users = _usersDal.Get(predicate: users => users.Id == request.Id);
        //_usersBusinessRules.CheckIfModelExists(users);

        var response = _mapper.Map<GetUsersByIdResponse>(users);
        return response;
    }

    public AddUsersResponse Add(AddUsersRequest request)
    {
        ValidationTool.Validate(new AddUsersRequestValidator(), request);
        
        //_usersBusinessRules.CheckIfModelNameExists(request.Name);
        //_usersBusinessRules.CheckIfModelYearShouldBeInLast20Years(request.Year);
        
        // mapping
        var usersToAdd = _mapper.Map<Users>(request);
        
        Users addedUsers = _usersDal.Add(usersToAdd);
        
        // mapping & response
        var response = _mapper.Map<AddUsersResponse>(addedUsers);
        
        return response;
    }

    public UpdateUsersResponse Update(UpdateUsersRequest request)
    {
        Users? usersToUpdate = _usersDal.Get(predicate: users => users.Id == request.Id); 

        //_modelBusinessRules.CheckIfModelExists(modelToUpdate);
        //_modelBusinessRules.CheckIfModelYearShouldBeInLast20Years(request.Year);
        
        usersToUpdate = _mapper.Map(request, usersToUpdate); 
        Users updatedUsers = _usersDal.Update(usersToUpdate!); 
        var response = _mapper.Map<UpdateUsersResponse>(
            updatedUsers 
        );
        return response;
    }

    public DeleteUsersResponse Delete(DeleteUsersRequest request)
    {
        Users? usersToDelete = _usersDal.Get(predicate: users => users.Id == request.Id);
        //_usersBusinessRules.CheckIfModelExists(usersToDelete!);

        Users deletedUsers = _usersDal.Delete(usersToDelete);
        
        var response = _mapper.Map<DeleteUsersResponse>(deletedUsers);
        return response;
    }
}