# Teste Tecnico CNI

Projeto dividido em backend (C# Console) e frontend (HTML/CSS/JS).

## Estrutura

```txt
Teste-tecnico-cni/
├── backend/
│   └── compra-console/
└── frontend/
    └── servico-interno-web/
```

## Backend - compra-console

Aplicacao de console para leitura de pedidos, geracao de protocolo, ordenacao e exportacao consolidada.

### Funcionalidades

- Leitura de arquivo `.txt` no formato:
  - `Solicitante;Item;Quantidade;Prioridade`
- Agrupamento por pedido (`Solicitante + Prioridade`)
- Geracao de protocolo sequencial (`COMP-0001/2026`, etc.)
- Ordenacao por:
  - item
  - solicitante
- Exibicao no console
- Exportacao consolidada em arquivo unico conforme ordenacao escolhida
- Loop de continuidade:
  - pergunta se deseja integrar um novo pedido

### Arquivos exportados

A exportacao vai para a pasta `salva/` (criada automaticamente ao lado do arquivo de entrada):

- `pedidos-ordenados-por-item.txt`
- `pedidos-ordenados-por-solicitante.txt`

### Como executar

No terminal:

```powershell
cd backend\compra-console
dotnet run
```

Fluxo:

1. Informar caminho do `.txt` (ou Enter para usar `solicitacoes.txt` local)
2. Escolher ordenacao
3. Escolher se deseja exportar
4. Escolher se deseja integrar novo pedido

### Caminho para teste

Use este caminho quando o sistema pedir o arquivo:

`C:\Users\Mathe\Documents\GitHub\Teste-tecnico-cni\backend\compra-console\teste2.txt`

Exemplo de caminho (ajuste conforme sua maquina):

`C:\Users\Mathe\Documents\GitHub\Teste-tecnico-cni\backend\compra-console\teste2.txt`

### Exemplo de entrada

```txt
Joao Silva;Notebook;2;Alta
Joao Silva;Mouse;1;Alta
Joao Silva;Teclado;1;Alta
Maria Souza;Monitor;1;Media
```

### Exemplo de saida exportada

```txt
Numero;Solicitante;Prioridade;Item;Quantidade

COMP-0002/2026;Maria Souza;Media;Monitor;1
COMP-0001/2026;Joao Silva;Alta;Mouse;1
COMP-0001/2026;Joao Silva;Alta;Notebook;2
COMP-0001/2026;Joao Silva;Alta;Teclado;1
```

## Frontend - servico-interno-web

Tela web simples com formulario de solicitacao interna.

### Estrutura

```txt
servico-interno-web/
├── index.html
└── src/
├── main.js
    ├── pages/
    ├── components/
    └── styles/
```

### Funcionalidades

- Captura de dados do formulario
- Validacao de campos obrigatorios
- Exibicao de mensagens de erro
- Renderizacao de resumo da solicitacao

### Como rodar o front

Opcao recomendada (Vite):

1. No terminal, va para a raiz do projeto:
   - `cd C:\Users\Mathe\Documents\GitHub\Teste-tecnico-cni`
2. Entre na pasta do frontend:
   - `cd frontend\servico-interno-web`
3. Instale as dependencias:
   - `npm install`
4. Rode o servidor de desenvolvimento:
   - `npm run dev`
5. Abra a URL exibida no terminal (normalmente `http://localhost:5173`).

Build de producao:

- `npm run build`
- `npm run preview`

## Observacoes

- O backend esta focado em simplicidade, organizacao e aderencia ao escopo de prova.
- As exportacoes ordenadas exibem um item por linha, com quantidade em coluna propria e protocolo repetido quando os itens pertencem ao mesmo pedido.
