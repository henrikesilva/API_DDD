using System.Threading.Tasks;
using API.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace API.Service.Test.Usuario
{
    public class QuandoForExecutadoCreate : UsuariosTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Create.")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            //Teste de retorno de criação de dados
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);
        }
    }
}