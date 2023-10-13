- Breve Resumo das Atividades Realizadas:
No �mbito deste projeto, foram implementadas todas as tarefas delineadas no documento em PDF, 
que foi enviado por e-mail. Para a gest�o dos dados, optei por utilizar o SQL Server como sistema de 
gerenciamento de banco de dados por ter mais familiaridade com o mesmo. A l�gica de cadastro da tabela 
"pessoa_salario" foi incorporada diretamente no banco de dados. Al�m disso, foi desenvolvida uma 
trigger sempre que uma nova pessoa � cadastrada ou uma existente � editada. Isso significa que todas 
as opera��es relacionadas � entidade "Pessoa" (inser��o e edi��o) s�o refletidas imediatamente na tabela 
"pessoa_salario". Introduzi uma nova entidade denominada "usu�rio" para a gest�o das informa��es 
de login, com destaque para o fato de que as senhas s�o armazenadas com criptografia MD5 
(A logica da criptografia tambem est� no banco de dados).

- Instru��es para Execu��o em Ambiente Local:
Para executar o sistema em seu ambiente local, siga os passos a seguir:

1 - Instale o CrystalReport em sua m�quina, se ainda n�o estiver instalado.
2- Importe o banco de dados para o seu SQL Server, o arquivo de backup est� na raiz do projeto (dbesig.bak).
3- Realize a configura��o da string de conex�o no arquivo "Web.config", ajustando as informa��es de 
conex�o para refletir as configura��es de sua m�quina.
4 - Foi criado um usu�rio com o login "esig" e a senha "1234" mas todos as senhas dos usu�rios s�o "1234"