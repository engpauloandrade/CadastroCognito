using AutoMapper;


namespace Cadastro.Application.Utils
{
    public static class Conversor<D, DTO> where D : class where DTO : class
    {
        public static IEnumerable<DTO> ConverteParaListaDTO(IEnumerable<D> listaDominio, IMapper mapper)
        {
            if (listaDominio == null)
            {
                throw new ArgumentNullException("Não há dados para o identificador de conta informado.");
            }
            else
            {
                List<DTO> retorno = new List<DTO>();
                foreach (D dominio in listaDominio)
                {
                    retorno.Add(mapper.Map<DTO>(dominio));
                }
                return retorno;
            }
        }

        public static DTO ConverteParaDTO(D dominio, IMapper mapper)
        {
            if (dominio == null)
            {
                throw new ArgumentNullException("Não há dados para o identificador de conta informado.");
            }
            else
            {
                return mapper.Map<DTO>(dominio);
            }
        }

        public static IEnumerable<DTO> ConverteParaDTO(IEnumerable<D> listaDominio, IMapper mapper)
        {
            if (listaDominio == null)
            {
                throw new ArgumentNullException("Não há dados para o identificador de conta informado.");
            }
            else
            {
                List<DTO> retorno = new List<DTO>();
                foreach (D dominio in listaDominio)
                {
                    retorno.Add(mapper.Map<DTO>(dominio));
                }
                return retorno;
            }
        }

        public static IEnumerable<D> ConverteParaD(IEnumerable<DTO> listaDTO, IMapper mapper)
        {
            if (listaDTO == null)
            {
                throw new ArgumentNullException("Não há dados para o identificador de conta informado.");
            }
            else
            {
                List<D> retorno = new List<D>();
                foreach (DTO dto in listaDTO)
                {
                    retorno.Add(mapper.Map<D>(dto));
                }
                return retorno;
            }
        }
    }
}
