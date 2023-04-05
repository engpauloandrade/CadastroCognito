using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Contracts
{
    public interface IFiltro<DTO> where DTO : class
    {
        public DTO? Dado();
    }
}
