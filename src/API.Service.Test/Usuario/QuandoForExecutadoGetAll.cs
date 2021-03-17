using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Dtos.User;
using API.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace API.Service.Test.Usuario
{
    public class QuandoForExecutadoGetAll : UsuariosTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GET All.")]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {
            //Teste de retorno de lista com dados
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUserDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            //Teste de retorno de lista vazia
            var _listResult = new List<UserDto>();
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}