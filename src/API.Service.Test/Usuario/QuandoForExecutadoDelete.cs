using System;
using System.Threading.Tasks;
using API.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace API.Service.Test.Usuario
{
    public class QuandoForExecutadoDelete : UsuariosTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Delete.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            //Qualquer valor diferente de IdUsuario
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(IdUsuario))
                        .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var delete = await _service.Delete(IdUsuario);
            Assert.True(delete);

            //Qualquer valor diferente de IdUsuario
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);
            _service = _serviceMock.Object;

            delete = await _service.Delete(Guid.NewGuid());
            Assert.False(delete);
        }
    }
}