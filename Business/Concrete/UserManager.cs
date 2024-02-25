using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.Model;
using Business.Profiles.Validation.FluentValidation.Users;
using Business.Requests.Users;
using Business.Responses.Model;
using Business.Responses.Users;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security.Hashing;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _usersDal;
    private readonly UserBusinessRules _usersBusinessRules;
    private readonly IMapper _mapper;
    private readonly ITokenHelper _tokenHelper;
    
    public UserManager(IUserDal usersDal, UserBusinessRules usersBusinessRules, IMapper mapper, ITokenHelper tokenHelper)
    {
        _usersDal = usersDal;
        _usersBusinessRules = usersBusinessRules;
        _mapper = mapper;
        _tokenHelper = tokenHelper;
    }
    
    public AccessToken Login(LoginRequest request)
    {
        User? user = _usersDal.Get(i => i.Email == request.Email);
        
        // Business Rules...

        bool isPasswordCorrect = HashingHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);
        if (!isPasswordCorrect)
            throw new Exception("Şifre yanlış.");

        var userRoles = _usersDal.GetUserRolesByUserId(user.Id);
        
        return _tokenHelper.CreateToken(user, userRoles);
    }

    public void Register(RegisterRequest request)
    {
        byte[] passwordSalt, passwordHash;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

        // TODO: Auto-Mapping
        User user = new User();
        user.FirstName = string.Empty;
        user.LastName = string.Empty;
        user.Email = request.Email;
        user.Approved = false;
        user.PasswordSalt = passwordSalt;
        user.PasswordHash = passwordHash;

        _usersDal.Add(user);
    }
    
    public GetUserListResponse GetList(GetUserListRequest request)
    {
        IList<User> usersList = _usersDal.GetList();

        var response = _mapper.Map<GetUserListResponse>(usersList);
        
        return response;
    }

    public GetUserByIdResponse GetById(GetUserByIdRequest request)
    {
        User? user = _usersDal.Get(predicate: user => user.Id == request.Id);
        //_usersBusinessRules.CheckIfModelExists(user);

        var response = _mapper.Map<GetUserByIdResponse>(user);
        return response;
    }

    public AddUserResponse Add(AddUserRequest request)
    {
        ValidationTool.Validate(new AddUserRequestValidator(), request);
        
        //_usersBusinessRules.CheckIfModelNameExists(request.Name);
        //_usersBusinessRules.CheckIfModelYearShouldBeInLast20Years(request.Year);
        
        // mapping
        var usersToAdd = _mapper.Map<User>(request);
        
        User addedUser = _usersDal.Add(usersToAdd);
        
        // mapping & response
        var response = _mapper.Map<AddUserResponse>(addedUser);
        
        return response;
    }

    public UpdateUserResponse Update(UpdateUserRequest request)
    {
        User? usersToUpdate = _usersDal.Get(predicate: user => user.Id == request.Id); 

        //_modelBusinessRules.CheckIfModelExists(modelToUpdate);
        //_modelBusinessRules.CheckIfModelYearShouldBeInLast20Years(request.Year);
        
        usersToUpdate = _mapper.Map(request, usersToUpdate); 
        User updatedUser = _usersDal.Update(usersToUpdate!); 
        var response = _mapper.Map<UpdateUserResponse>(
            updatedUser 
        );
        return response;
    }

    public DeleteUserResponse Delete(DeleteUserRequest request)
    {
        User? usersToDelete = _usersDal.Get(predicate: user => user.Id == request.Id);
        //_usersBusinessRules.CheckIfModelExists(usersToDelete!);

        User deletedUser = _usersDal.Delete(usersToDelete);
        
        var response = _mapper.Map<DeleteUserResponse>(deletedUser);
        return response;
    }
}