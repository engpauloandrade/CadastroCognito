using Amazon.Runtime;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon;
using AutoMapper;
using Cadastro.Application.Contracts;
using Cadastro.Application.DTOs.Usuario;
using Cadastro.Application.Utils;
using Cadastro.Domain;
using Cadastro.Persistence.Contracts;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace Cadastro.Application.Services.Gravacao
{
    public class UsuarioService : IUsuarioService
    {
        public IConfiguration Configuration { get; }
        private IPersistenciaDinamica<Usuario> PersistenciaUsuario;
        private IMapper Mapper;

        //AWS
        private readonly AmazonCognitoIdentityProviderClient cognitoClient;
        private readonly BasicAWSCredentials credentials;

        public UsuarioService(
            IMapper mapper, 
            IPersistenciaDinamica<Usuario> persistenciaUsuario,
            IConfiguration configuration
            )

        {
            this.Configuration = configuration;
            this.Mapper = mapper;
            this.PersistenciaUsuario = persistenciaUsuario;

            credentials = new BasicAWSCredentials(
                Configuration.GetSection("AwsCredentials")["ACCESSKEY"],
                Configuration.GetSection("AwsCredentials")["SECRETKEY"]
            );

            cognitoClient = new AmazonCognitoIdentityProviderClient(credentials, RegionEndpoint.USEast1);
        }
        public async Task<IEnumerable<UsuarioDTO>> PostUsuario(List<UsuarioDTO> usuario)
        {
            string userPoolId = Configuration.GetSection("AwsCredentials")["USERPOOL"];

            var randomBytes = new byte[8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            var novoUsuario = usuario.FirstOrDefault();
            var password = Convert.ToBase64String(randomBytes);

            var request = new AdminCreateUserRequest()
            {
                UserPoolId = userPoolId,
                Username = novoUsuario.Email,
                TemporaryPassword = password,
                UserAttributes = new List<AttributeType>()
                {
                    new AttributeType()
                    {
                        Name = "email",
                        Value = novoUsuario.Email
                    }
                },

                //Não enviar e-mail com login e senha temporária antes de confirmar se todo o cadastro deu certo
                MessageAction = MessageActionType.SUPPRESS
            };

            var response = await cognitoClient.AdminCreateUserAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    IEnumerable<Usuario> modelList = Conversor<Usuario, UsuarioDTO>.ConverteParaD(usuario, Mapper);

                    IEnumerable<Usuario> resultList = await this.PersistenciaUsuario.PostAsync(modelList);

                    //Enviar e-mail de confirmação de cadastro para o usuário
                    var resendRequest = new AdminCreateUserRequest
                    {
                        UserPoolId = userPoolId,
                        Username = novoUsuario.Email,
                        MessageAction = MessageActionType.RESEND
                    };

                    await cognitoClient.AdminCreateUserAsync(resendRequest);

                    return Conversor<Usuario, UsuarioDTO>.ConverteParaListaDTO(resultList, Mapper);
                }
                catch (Exception ex)
                {
                    //Deletar o usuário criado no cognito em caso de erro no cadastro por completo
                    await cognitoClient.AdminDeleteUserAsync(new AdminDeleteUserRequest
                    {
                        UserPoolId = userPoolId,
                        Username = novoUsuario.Email
                    });

                    throw new Exception("Ocorreu um erro ao cadastrar o usuário. Detalhes do erro: " + ex.Message);
                }
            }

             return Enumerable.Empty<UsuarioDTO>();

        }
    }
}
