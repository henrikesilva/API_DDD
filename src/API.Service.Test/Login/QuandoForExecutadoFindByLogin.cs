using System;
using System.Threading.Tasks;
using API.Domain.Dtos;
using API.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace API.Service.Test.Login
{
    public class QuandoForExecutadoFindByLogin
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método FindByLogin")]
        public async Task E_Possivel_Executar_Metodo_FindByLogin()
        {
           var email = Faker.Internet.Email();
           var objectReturn = new 
           {
                authenticated = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                acessToken = Guid.NewGuid(),
                userName = email,
                message = "Usuário Logado com sucesso"
           };

           var loginDto = new LoginDto
           {
               Email = email
           };

           _serviceMock = new Mock<ILoginService>();
           _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objectReturn);
           _service = _serviceMock.Object;

           var result = await _service.FindByLogin(loginDto);
           Assert.NotNull(result);
        }
    }
}