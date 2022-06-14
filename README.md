### Validações de Cep utilizando o webservice ViaCEP e a Biblioteca Caelum Stella Csharp

Para acessar o webservice:https://viacep.com.br/  
Json que retornou do endereço procurado: viacep.com.br/ws/01001000/json/

Na prática, a classe ViaCEP da biblioteca Caelum funciona internamente:
Ela encapsula métodos de acesso ao webservice da ViaCEP, de maneira conveniente, de forma que cada formato de saída (JSON, XML, objeto Endereco, etc) e modo de acesso (síncrono, assíncrono) produz uma chamada HTTP ao webservice da ViaCEP.

Métodos Assícronos e síncronos:
Métodos assíncronos como GetEnderecoJsonAsync possuem a vantagem para obtenção de endereços, de não bloquear a thread do código chamador, que é essencialmente importante quando você está criando aplicações interativas que devem continuar responsivas mesmo enquanto estão realizando algum trabalho.
