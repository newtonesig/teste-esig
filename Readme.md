- Breve Resumo das Atividades Realizadas:
No âmbito deste projeto, foram implementadas todas as tarefas delineadas no documento em PDF, 
que foi enviado por e-mail. Para a gestão dos dados, optei por utilizar o SQL Server como sistema de 
gerenciamento de banco de dados por ter mais familiaridade com o mesmo. A lógica de cadastro da tabela 
"pessoa_salario" foi incorporada diretamente no banco de dados. Além disso, foi desenvolvida uma 
trigger sempre que uma nova pessoa é cadastrada ou uma existente é editada. Isso significa que todas 
as operações relacionadas à entidade "Pessoa" (inserção e edição) são refletidas imediatamente na tabela 
"pessoa_salario". Introduzi uma nova entidade denominada "usuário" para a gestão das informações 
de login, com destaque para o fato de que as senhas são armazenadas com criptografia MD5 
(A logica da criptografia tambem está no banco de dados).

- Instruções para Execução em Ambiente Local:
Para executar o sistema em seu ambiente local, siga os passos a seguir:

1 - Instale o CrystalReport em sua máquina, se ainda não estiver instalado.
2- Importe o banco de dados para o seu SQL Server, o arquivo de backup está na raiz do projeto (dbesig.bak).
3- Realize a configuração da string de conexão no arquivo "Web.config", ajustando as informações de 
conexão para refletir as configurações de sua máquina.
4 - Foi criado um usuário com o login "esig" e a senha "1234" mas todos as senhas dos usuários são "1234"