# MedTechC

MedTechC é uma aplicação ASP.NET Core para gerenciar prontuários médicos, seguindo o protocolo de Manchester para priorização de atendimentos.

## Funcionalidades

- **Prontuários**:
  - Listar todos os prontuários
  - Obter prontuário por ID
  - Obter prontuários por ID do paciente
  - Obter prontuários por nome do paciente
  - Adicionar um novo prontuário
  - Atualizar um prontuário por ID
  - Deletar um prontuário por ID
  - Obter o próximo prontuário para atendimento seguindo o protocolo de Manchester

## Estrutura do Projeto

- **Models**:
  - `ProntuarioModel.cs`: Define o modelo de dados para prontuários.
  - `PacienteModel.cs`: Define o modelo de dados para pacientes.

- **Data**:
  - `ProntuarioMap.cs`: Configura o mapeamento do modelo `ProntuarioModel`.

- **Repositories**:
  - `IProntuarioRepository.cs`: Interface para o repositório de prontuários.
  - `ProntuarioRepository.cs`: Implementação do repositório de prontuários.

- **Controllers**:
  - `ProntuarioController.cs`: Controlador para expor os endpoints de prontuários.

## Endpoints

### Prontuário

- **GET** `/api/prontuario`
  - Retorna todos os prontuários.

- **GET** `/api/prontuario/{id}`
  - Retorna um prontuário pelo ID.

- **GET** `/api/prontuario/paciente/{pacienteId}`
  - Retorna prontuários pelo ID do paciente.

- **GET** `/api/prontuario/paciente/nome/{nome}`
  - Retorna prontuários pelo nome do paciente.

- **POST** `/api/prontuario`
  - Adiciona um novo prontuário.

- **PUT** `/api/prontuario/{id}`
  - Atualiza um prontuário pelo ID.

- **DELETE** `/api/prontuario/{id}`
  - Deleta um prontuário pelo ID.

- **GET** `/api/prontuario/next`
  - Retorna o próximo prontuário para atendimento seguindo o protocolo de Manchester.

## Configuração

1. Clone o repositório: ``` git clone https://github.com/seu-usuario/MedTechC.git ```
2. Navegue até o diretório do projeto: ``` cd MedTechC ```
3. Instale as dependências: ``` dotnet restore ```
4. Configure o banco de dados no arquivo `appsettings.json`
5. Execute as migrações para criar o banco de dados: ``` dotnet ef database update ```
6. Inicie a aplicação: ``` dotnet run ```

## Contribuição

1. Faça um fork do projeto.
2. Crie uma branch para sua feature (`git checkout -b feature/nova-feature`).
3. Commit suas mudanças (`git commit -am 'Adiciona nova feature'`).
4. Faça o push para a branch (`git push origin feature/nova-feature`).
5. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
