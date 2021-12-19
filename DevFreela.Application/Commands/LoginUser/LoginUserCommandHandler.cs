using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        
        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }
        
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Utilizar o mesmo algoritmo para criar o hash dessa senha.
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            
            // Busca no banco de dados um User que tenha meu e-mail e minha senha em formato de hash
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);
            
            // Se não existir, erro no login.
            if (user == null)
            {
                return null;
            }

            // Se existir gera o token com os dados do usuario
            var token = _authService.GenerateJwtToken(user.Email, user.Role);
            
            var loginUserViewModel = new LoginUserViewModel(user.Email, token);

            return loginUserViewModel;
        }
    }
}