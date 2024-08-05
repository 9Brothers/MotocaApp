# Instruções

Para rodar esse projeto é extremamente simples, basta executar o comando abaixo e tudo certo:

```shell
docker-compose up
```

Na primeira execução, talvez possa demorar um pouco para fazer o build das imagens, criação de fila e execução de migration nos bancos.

Este projeto é composto por duas WebAPI's, sendo elas:
- [Core](http://localhost:5167/swagger)
- [Platform](http://localhost:5192/swagger)

O swagger da Platform está pegando os endpoints de Administrator da Core, porém, eles não estão disponíveis na Platform.

Também está disponível um arquivo [json](Motoca.postman_collection.json) com uma collection do [**Postman**]((Motoca.postman_collection.json)) que usei para auxiliar alguns testes.

Qualquer dúvida podem me chamar. 😉