### ENDPOINTS

### Teacher 
https://localhost:7072/teacher -> criar professor ou listar o professor
estilo do json para criar o professor: 

{
  "personData": {
    "name": "{{$randomFirstName}}",
    "dateOfBirth": "1990-01-01",
    "cpf": "123.456.789-00",
    "rg": "1234567",
    "telephone": "123456789",
    "email": "pessoa@email.com",
    "profission": "Profissão da Pessoa",
    "biometry": "{{$randomNumeric}}",
    "addressId": 1  
  },
  "addressData": {
    "logradouro": "Rua Exemplo",
    "bairro": "Bairro Exemplo",
    "cep": "12345-678",
    "numero": "123",
    "complemento": "Complemento Exemplo",
    "cidade": "Cidade Exemplo",
    "uf": "UF"
  },
  "isActive": true
}

https://localhost:7072/teacher/{id} -> para fazer a exclusão lógica do professor, basta colocar o id que referencia o mesmo que muda o status para false
https://localhost:7072/teacher/{id} -> Para atualizar o professor

### Student 
https://localhost:7072/student -> criar estudante ou listar o estudante
estilo do json para criar o estudante: 

{
  "personData": {
    "name": "{{$randomFirstName}}",
    "dateOfBirth": "1990-01-01",
    "cpf": "123.456.789-00",
    "rg": "1234567",
    "telephone": "123456789",
    "email": "pessoa@email.com",
    "profission": "Profissão da Pessoa",
    "biometry": "{{$randomNumeric}}",
    "addressId": 1  
  },
  "addressData": {
    "logradouro": "Rua Exemplo",
    "bairro": "Bairro Exemplo",
    "cep": "12345-678",
    "numero": "123",
    "complemento": "Complemento Exemplo",
    "cidade": "Cidade Exemplo",
    "uf": "UF"
  },
  "isActive": true
}

https://localhost:7072/student/{id} -> para fazer a exclusão lógica do estudante, basta colocar o id que referencia o mesmo que muda o status para false
https://localhost:7072/student/{id} -> Para atualizar o estudante

### Video 
https://localhost:7072/video -> para criar um vídeo ou listar todos os vídeos com status de ativo
estilo do json para criar um vídeo
{
  
  "title": "{{title}},
  "url": "urlDoVideoDoYoutube"

}

https://localhost:7072/video/{id} -> para fazer a exclusão lógica do video, basta colocar o id que referencia o mesmo que muda o status para false
https://localhost:7072/video/{id} -> para atualizar o video



### Banco de dados mysql

Quando utilizar a API, criar um schema chamado "sucelso" e criar as tabelas, se vocês usarem o entity, da para criar as tabelas. 


a string de conexão é essa: "VideoPlataformConnection": "server=localhost;database=sucelso;user=root;password=root123"
                                                                             nome do banco nome do usuario  do banco e a senha do banco 
