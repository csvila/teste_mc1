# Teste - Desenvolvimento de Software MC1

Implementação simples de uma API feita em dotnet

- Desenvolvido em:
  - VSCode
  - .net core 2.1
  - macOS
- Foi adicionado o swagger para facilitar os testes
- Usado injecao de dependencia entre Controler e Domain e singleton na Infrastrucure
- Para executar basta executar os comandos:

```
dotnet restore
dotnet run
```
- ou para rodar com o docker execute os comandos:
````
docker build -t mc1api .
docker run -d -p 8080:80 --name myapp mc1api
